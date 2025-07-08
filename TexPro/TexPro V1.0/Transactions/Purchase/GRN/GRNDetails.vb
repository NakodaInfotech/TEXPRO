
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class GRNDetails

    Public edit As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

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
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If FRMSTRING = "GRN" Then
                cmbtype.Text = "G.R.N"
                gridbill.Columns("ITEMNAME").Visible = False
            ElseIf FRMSTRING = "GRNJOB" Then
                cmbtype.Text = "Job Work"
            Else
                cmbtype.Text = "Inwards"
                chkParty.Visible = True
                chkParty.Checked = False
                chkItem.Visible = True
                chkItem.Checked = False
                gridbill.Columns("QUALITY").Visible = False
                gridbill.Columns("MTRS").Visible = False
                gridbill.Columns("PARTYMTRS").Visible = False
                gridbill.Columns("UNCHECKED").Visible = False
                gridbill.Columns("checkmtrs").Visible = False
                gridbill.Columns("SHORTAGE").Visible = False
                gridbill.Columns("rejmtrs").Visible = False
                gridbill.Columns("ACCEPTED").Visible = False
            End If

            fillgrid(" and grn.grn_type='" & cmbtype.Text & "' and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("  GRN.grn_no AS GRNNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GODOWN_NAME,'') AS GODOWN, SENDERLEDGERS.Acc_cmpname AS SENDERNAME, BROKERLEDGERS.Acc_cmpname AS BROKER, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, ISNULL(MERCHANTMASTER.ITEM_NAME,'') AS MERCHANT, ISNULL(GRN_EWBNO,'') AS EWBNO, GRN_DESC.GRN_QTY AS QTY, GRN_DESC.GRN_MTRS AS MTRS, ISNULL(GRN_RATE,0) AS RATE, ISNULL(CHECKINGMASTER.CHECK_TOTALPARTYMTRS,0) AS PARTYMTRS, CASE WHEN GRN_DESC.GRN_CHECKDONE = '0' THEN GRN_DESC.GRN_MTRS ELSE 0 END AS UNCHECKED, ISNULL(CHECKINGMASTER.CHECK_TOTALCHECKEDMTRS,0) AS checkmtrs, ISNULL(CHECKINGMASTER.CHECK_REJECTEDMTRS,0) AS rejmtrs, ISNULL(CHECKINGMASTER.CHECK_TOTALDIFF,0) AS SHORTAGE, ISNULL(CHECKINGMASTER.CHECK_BALMTRS,0) AS ACCEPTED, GRN.grn_remarks AS REMARKS, ISNULL(WEAVERMASTER.WEAVER_NAME,'') AS WEAVER, ISNULL(GRN.GRN_AVGGRAMS,0) AS AVGGRAMS, ISNULL(GRN.GRN_TOTALBALES,0) AS BALES, ISNULL(GRN_DESC.GRN_GRIDREMARKS,'') AS GRIDREMARKS, ISNULL(GRN_DESC.GRN_LABTEST,'') AS LABTEST, ISNULL(OURQUALITYMASTER.QUALITY_NAME,'') AS OURQUALITY, ISNULL(GRN.GRN_PONO,'') AS PONO ", "", " GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN WEAVERMASTER ON GRN.GRN_WEAVERID = WEAVER_ID LEFT OUTER JOIN ITEMMASTER AS MERCHANTMASTER ON GRN_MERCHANTID = MERCHANTMASTER.ITEM_ID INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE AND GRN.grn_yearid = GRN_DESC.GRN_YEARID LEFT OUTER JOIN LEDGERS AS SENDERLEDGERS ON GRN.grn_SENDERID = SENDERLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS BROKERLEDGERS ON GRN.grn_BROKERID = BROKERLEDGERS.Acc_id LEFT OUTER JOIN CHECKINGMASTER ON GRN.grn_yearid = CHECKINGMASTER.CHECK_YEARID AND GRN.grn_no = CHECKINGMASTER.CHECK_GRNNO AND GRN.GRN_TYPE = CHECKINGMASTER.CHECK_TYPE LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWN_ID LEFT OUTER JOIN QUALITYMASTER AS OURQUALITYMASTER ON QUALITYMASTER.QUALITY_OURQUALITYID = OURQUALITYMASTER.QUALITY_ID", tepmcondition)
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

            If chkParty.Checked = True Or chkItem.Checked = True Then
                Dim objwo As New ItemReport
                objwo.MdiParent = MDIMain
                objwo.selfor_ss = "1=1"
                If chkParty.Checked = True Then objwo.selfor_ss = objwo.selfor_ss & " and LEDGERS.Acc_name='" & gridbill.GetFocusedRowCellValue("NAME") & "'"
                If chkItem.Checked = True Then objwo.selfor_ss = objwo.selfor_ss & " and ITEMMASTER.item_name='" & gridbill.GetFocusedRowCellValue("ITEMNAME") & "'"
                objwo.Show()
            Else
                If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                    Dim objGRN As New GRN
                    objGRN.MdiParent = MDIMain
                    objGRN.edit = editval
                    objGRN.tempgrnno = GRNNO

                    objGRN.temptypename = cmbtype.Text.Trim
                    objGRN.FRMSTRING = FRMSTRING
                    objGRN.Show()
                    'Me.Close()
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
            showform(True, gridbill.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        Try
            If cmbtype.Text.Trim <> "" Then fillgrid(" and grn.grn_type='" & cmbtype.Text & "' and dbo.GRN.GRN_CMPID=" & CmpId & " and dbo.GRN.GRN_locationid=" & Locationid & " and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper GRN Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print GRN from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected GRN ?", MsgBoxStyle.YesNo) = vbYes Then
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
            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJGRN As New GRNDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = "GRN"
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.GRNNO = Val(I)
                OBJGRN.GRNTYPE = cmbtype.Text.Trim
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\GRN_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "GRN"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJGRN As New GRNDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = "GRN"
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.GRNNO = Val(ROW("GRNNO"))
                OBJGRN.GRNTYPE = cmbtype.Text.Trim
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\GRN_" & Val(ROW("GRNNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "GRN"
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
                    MsgBox("Enter Proper GRN", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail GRN from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected GRN ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\GRN Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "GRN Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRN Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and grn.grn_type='" & cmbtype.Text & "' and dbo.GRN.GRN_CMPID=" & CmpId & " and dbo.GRN.GRN_locationid=" & Locationid & " and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                GMERCHANT.Visible = False
                GWEAVER.Visible = False
                GSENDERNAME.Visible = False
                GAVGGRAMS.Visible = False
                GOURQUALITY.Visible = True
                GOURQUALITY.VisibleIndex = GQUALITY.VisibleIndex + 1
            End If

            If cmbtype.Text.Trim = "Inwards" Then
                Me.Text = "Store Inward Details"
                GWEAVER.Visible = False
                GSENDERNAME.Visible = False
                GBROKER.Visible = False
                GAVGGRAMS.Visible = False
                GMERCHANT.Visible = False
                GBALES.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("LABTEST")) = "APPROVED" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("LABTEST")) = "REJECTED" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("LABTEST")) = "HOLD" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightBlue
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class