
Imports BL

Public Class PackingSummaryGridDetails

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PackingSummaryGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PackingSummaryGridDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PACKING SLIP'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid("and dbo.PACKINGSUMMARY.PS_CMPID=" & CmpId & "  and dbo.PACKINGSUMMARY.PS_yearid=" & YearId & " order by dbo.PACKINGSUMMARY.PS_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" PACKINGSUMMARY.PS_no AS TEMPPACKNO, PACKINGSUMMARY.PS_date AS DATE, LEDGERS.Acc_cmpname AS NAME,  ITEMMASTER.ITEM_NAME AS QUALITY,  PACKINGSUMMARY.PS_REMARKS AS REMARKS, PACKINGSUMMARY.PS_LBLBALETOTALPCS AS PCS, PACKINGSUMMARY.PS_FINALMTR AS FINALMTR, PACKINGSUMMARY.PS_LONGATION AS LONGATION, PACKINGSUMMARY.PS_SAMPLEMTR AS SAMPLEMTRS, PACKINGSUMMARY.PS_SHORTPCS AS SHORTPCS,PACKINGSUMMARY.PS_REJPCS AS REJPCS, PACKINGSUMMARY.PS_FENTMTRS AS FENTMTRS,PACKINGSUMMARY.PS_SHORTMTRS AS SHORTMTRS,PACKINGSUMMARY.PS_REJMTRS AS REJMTRS,   PACKINGSUMMARY.PS_GOODCUTMTRS AS GOODCUTMTRS,PACKINGSUMMARY.PS_RACKSMTRS RACKSMTRS ,PACKINGSUMMARY.PS_LESSPER AS LESSPER,  PACKINGSUMMARY.PS_LESSMTRS AS LESSMTRS, ISNULL(PACKINGSUMMARY_LOTDESC.PS_LOTNO,0) AS LOTNO, ISNULL(PACKINGSUMMARY.PS_CARTONCHGS,0) AS CARTONCHGS, ISNULL(PACKINGSUMMARY.PS_CUTTINGCHGS,0) AS CUTTINGCHGS, ISNULL(PACKINGSUMMARY.PS_FELT,0) AS FELT ", "", " PACKINGSUMMARY LEFT OUTER JOIN PACKINGSUMMARY_LOTDESC ON PACKINGSUMMARY.PS_NO = PACKINGSUMMARY_LOTDESC.PS_NO AND PACKINGSUMMARY.PS_YEARID = PACKINGSUMMARY_LOTDESC.PS_YEARID LEFT OUTER JOIN LEDGERS ON PACKINGSUMMARY.PS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON PACKINGSUMMARY.PS_QUALITYID = ITEMMASTER.item_id ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal TEMPPACKNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPACKINGSUMMARY As New PackingSummary
                objPACKINGSUMMARY.MdiParent = MDIMain
                objPACKINGSUMMARY.edit = editval
                objPACKINGSUMMARY.TEMPPACKNO = TEMPPACKNO
                objPACKINGSUMMARY.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPPACKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click_1(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Summary Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Packing Summary from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Packing Summary ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJGRN As New GDNDESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = "PACKINGSUMMARY"
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.PRINTSETTING = PrintDialog
                OBJGRN.GDNNO = Val(I)
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PACKINGSUMMARY_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "PACKINGSUMMARY"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJGRN As New GDNDESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = "PACKINGSUMMARY"
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.PRINTSETTING = PrintDialog
                OBJGRN.GDNNO = Val(ROW("TEMPPACKNO"))
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PACKINGSUMMARY_" & Val(ROW("TEMPPACKNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "PACKINGSUMMARY"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Summary Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Packing Summary from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Packing Summary ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPPACKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Summary Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Summary Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Summary Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.PACKINGSUMMARY.PS_yearid=" & YearId & " order by dbo.PACKINGSUMMARY.PS_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class