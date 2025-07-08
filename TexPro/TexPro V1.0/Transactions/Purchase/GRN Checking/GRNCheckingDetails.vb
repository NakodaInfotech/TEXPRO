
Imports BL

Public Class GRNCheckingDetails

    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Public GRNCHECKINGLOTNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.CHECKINGMASTER.CHECK_yearid=" & YearId & " order by dbo.CHECKINGMASTER.CHECK_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CHECKINGMASTER.CHECK_NO AS CHECKNO, CHECKINGMASTER.CHECK_DATE AS DATE, ISNULL(CUSTOMERLEDGERS.Acc_cmpname,'') AS CUSTOMERNAME, LEDGERS.Acc_cmpname AS NAME, CHECKINGMASTER.CHECK_LOTNO AS GRNNO, ISNULL(GODOWN_NAME,'') AS GODOWN,  CHECKINGMASTER.CHECK_GRNPCS AS RECDPCS, CHECKINGMASTER.CHECK_GRNMTRS AS RECDMTRS,  CHECKINGMASTER.CHECK_GRNPCS AS CHECKEDPCS, CHECKINGMASTER.CHECK_TOTALCHECKEDMTRS AS CHECKEDMTRS, CHECKINGMASTER.CHECK_REJECTEDPCS AS REJPCS, CHECKINGMASTER.CHECK_REJECTEDMTRS AS REJMTRS, CHECKINGMASTER.CHECK_BALPCS AS BALPCS, CHECKINGMASTER.CHECK_BALMTRS AS BALMTRS,   CHECKINGMASTER.CHECK_TOTALDIFF AS SHORTAGE,  ISNULL(CHECKINGMASTER.CHECK_QUALITYWT, 0) AS QUALITYWT,  (ISNULL(CHECKINGMASTER.CHECK_QUALITYWT, 0)*CHECKINGMASTER.CHECK_BALPCS*100) AS TOTALWT, (ISNULL(CHECKINGMASTER.CHECK_QUALITYWT, 0)*CHECKINGMASTER.CHECK_BALMTRS) AS TOTALWTMTRS,  ISNULL(CONTRACTOR_NAME,'') AS CONTRACTOR, ISNULL(CHECKINGMASTER.CHECK_HANDCHECKING,0) AS HANDCHECKING  ", "", "   CHECKINGMASTER LEFT OUTER JOIN LEDGERS ON CHECKINGMASTER.CHECK_VENDORID = LEDGERS.Acc_id LEFT OUTER JOIN CONTRACTORMASTER ON CHECK_CONTRACTORID = CONTRACTOR_ID LEFT OUTER JOIN GODOWNMASTER ON CHECK_GODOWNID = GODOWN_ID LEFT OUTER JOIN LEDGERS AS CUSTOMERLEDGERS ON CHECKINGMASTER.CHECK_LEDGERID = CUSTOMERLEDGERS.Acc_id", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal GRNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objCHECKINGMASTER As New GRNChecking
                objCHECKINGMASTER.MdiParent = MDIMain
                objCHECKINGMASTER.edit = editval
                objCHECKINGMASTER.TEMPCHECKINGNO = GRNNO
                objCHECKINGMASTER.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Checking Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Checking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Checking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal FRMSTRING As String = "CHECKING", Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJGRN As New GRNCheckingDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = FRMSTRING
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.GRNCHECKINGNO = Val(I)
                OBJGRN.GRNCHECKINGLOTNO = Val(I)
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\" & FRMSTRING & "_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = FRMSTRING
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal FRMSTRING As String = "CHECKING", Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJGRN As New GRNCheckingDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = FRMSTRING
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.GRNCHECKINGNO = Val(ROW("CHECKNO"))
                OBJGRN.GRNCHECKINGLOTNO = Val(ROW("GRNNO"))
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\" & FRMSTRING & "_" & Val(ROW("GRNNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = FRMSTRING
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckingReportToolStripMenuItem.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Checking Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Checking from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Checking ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DOReportToolStripMenuItem.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Checking Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Checking from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT("RETURN", False)
                End If
            Else
                If MsgBox("Wish to Print Selected Checking ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED("RETURN", False)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECKREPORTMAIL_Click(sender As Object, e As EventArgs) Handles CHECKREPORTMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Checking", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Checking from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT("CHECKING", True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Checking ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED("CHECKING", True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOREPORTMAIL_Click(sender As Object, e As EventArgs) Handles DOREPORTMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Checking", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Checking from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT("RETURN", True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Checking ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED("RETURN", True)
                End If
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
            showform(True, gridbill.GetFocusedRowCellValue("CHECKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CHECKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNCheckingDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "MONOGRAM" Then GTOTALWT.Visible = False Else GTOTALWTMTRS.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class