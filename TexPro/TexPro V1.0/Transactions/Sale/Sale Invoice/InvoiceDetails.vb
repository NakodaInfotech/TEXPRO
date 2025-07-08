
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class InvoiceDetails

    Dim SALEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public multi As Boolean = False
    Public fromno, tono As Integer
    Public PARTYNAME As String

    Private Sub InvoiceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" INVOICEMASTER.INVOICE_NO AS SRNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(INVOICEMASTER.INVOICE_REFNO, '') AS REFNO, ISNULL(LEDGER.Acc_cmpname, '') AS NAME, ISNULL(LEDGER.Acc_add, '') AS ADDRESS, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_EWAYBILLNO, '') AS EWAYBILLNO, ISNULL(LEDGERS.Acc_cmpname, '') AS AGENTNAME, ISNULL(TRANSNAME.Acc_cmpname, '') AS TRANSNAME, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL, INVOICEMASTER.INVOICE_DISPUTE AS DISPUTED, INVOICEMASTER.INVOICE_CHECKED AS CHECKED, INVOICEMASTER.INVOICE_REMARKS AS REMARKS, ISNULL(LEDGER.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) AS TOTALTAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_CGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(INVOICEMASTER.INVOICE_SGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(INVOICEMASTER.INVOICE_IGSTAMT, 0) AS TOTALIGSTAMT, ISNULL(INVOICEMASTER.INVOICE_CHALLANNO, '') AS CHALLANNO, ISNULL(INVOICEMASTER.INVOICE_CHALLANDATE, GETDATE()) AS CHALLANDATE,ISNULL(PACKINGLEDGERS.Acc_cmpname, '') AS PACKING, ISNULL(INVOICEMASTER.INVOICE_LONGATION,0) AS LONGATION, ISNULL(PROCESSTYPEMASTER.PROCESSTYPE_NAME,'') AS PROCESSTYPE ", " ", " INVOICEMASTER INNER JOIN LEDGERS AS LEDGER ON INVOICEMASTER.INVOICE_LEDGERID = LEDGER.Acc_id AND INVOICEMASTER.INVOICE_CMPID = LEDGER.Acc_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = LEDGER.Acc_locationid AND INVOICEMASTER.INVOICE_YEARID = LEDGER.Acc_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id AND INVOICEMASTER.INVOICE_CMPID = REGISTERMASTER.register_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = REGISTERMASTER.register_locationid AND INVOICEMASTER.INVOICE_YEARID = REGISTERMASTER.register_yearid LEFT OUTER JOIN LEDGERS AS PACKINGLEDGERS ON INVOICEMASTER.INVOICE_PACKINGID = PACKINGLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGER.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS ON INVOICEMASTER.INVOICE_YEARID = LEDGERS.Acc_yearid AND INVOICEMASTER.INVOICE_LOCATIONID = LEDGERS.Acc_locationid AND INVOICEMASTER.INVOICE_CMPID = LEDGERS.Acc_cmpid AND INVOICEMASTER.INVOICE_AGENTID = LEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON LEDGER.Acc_yearid = CITYMASTER.city_yearid AND LEDGER.Acc_locationid = CITYMASTER.city_locationid AND LEDGER.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGER.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS TRANSNAME ON INVOICEMASTER.INVOICE_TRANSID = TRANSNAME.Acc_id AND INVOICEMASTER.INVOICE_CMPID = TRANSNAME.Acc_cmpid AND InvoiceMaster.INVOICE_LOCATIONID = TRANSNAME.Acc_locationid And InvoiceMaster.INVOICE_YEARID = TRANSNAME.Acc_yearid LEFT OUTER JOIN PROCESSTYPEMASTER ON INVOICE_PROCESSTYPEID = PROCESSTYPE_ID", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND (INVOICEMASTER.INVOICE_CMPID = '" & CmpId & "') AND (INVOICEMASTER.INVOICE_LOCATIONID = '" & Locationid & "') AND (INVOICEMASTER.INVOICE_YEARID = '" & YearId & "') ORDER BY INVOICEMASTER.INVOICE_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBILL As New InvoiceMaster
                OBJBILL.MdiParent = MDIMain
                OBJBILL.edit = editval
                OBJBILL.tempinvoiceno = billno
                OBJBILL.TEMPREGNAME = cmbregister.Text.Trim
                OBJBILL.Show()
                '  Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    SALEREGID = dt.Rows(0).Item(0)
                    fillgrid(" and INVOICEMASTER.INVOICE_yearid = " & YearId & " AND INVOICEMASTER.INVOICE_registerid = " & SALEREGID & " order by dbo.INVOICEMASTER.INVOICE_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridINVOICE_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub newprint()
        If multi = True Then
            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
                Exit Sub
            Else
                fromno = Val(TXTFROM.Text.Trim)
                tono = Val(TXTTO.Text.Trim)
                PARTYNAME = cmbregister.Text.Trim
                Dim tempMsg As Integer
                tempMsg = MsgBox("Wish to Print Invoice from " & fromno & " To " & tono & " ?", MsgBoxStyle.YesNo)
                If tempMsg = vbYes Then
                    'serverprop(fromno, tono, PARTYNAME)
                    multi = False
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        'Try
        '    If Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0 Then Exit Sub
        '    If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
        '        MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If
        '    Dim tempMsg As Integer
        '    tempMsg = MsgBox("Wish to Print Invoice from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo)
        '    If tempMsg = vbYes Then
        '        SERVERPROPDIRECT()
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If MsgBox("Wish to Print Invoice from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then
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
                Dim OBJINVOICE As New saledesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.INVOICECOPYNAME = "CUSTOMER COPY"
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(STATE_REMARK,'') AS STATECODE", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATE_ID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID ", " AND INVOICEMASTER.INVOICE_NO = " & Val(I) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("STATECODE") <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                OBJINVOICE.registername = cmbregister.Text.Trim
                OBJINVOICE.PRINTSETTING = PrintDialog
                OBJINVOICE.INVNO = Val(I)
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Invoice"
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

                Dim OBJINVOICE As New saledesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.INVOICECOPYNAME = "CUSTOMER COPY"
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(STATE_REMARK,'') AS STATECODE", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATE_ID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID ", " AND INVOICEMASTER.INVOICE_NO = " & Val(ROW("SRNO")) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("STATECODE") <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
                OBJINVOICE.registername = cmbregister.Text.Trim
                OBJINVOICE.PRINTSETTING = PrintDialog
                OBJINVOICE.INVNO = Val(ROW("SRNO"))
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Invoice"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub SERVERPROPDIRECT()
    '    Try
    '        For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
    '            Dim OBJINVOICE As New saledesign
    '            OBJINVOICE.MdiParent = MDIMain
    '            OBJINVOICE.DIRECTPRINT = True
    '            OBJINVOICE.FRMSTRING = "INVOICE"
    '            Dim OBJCMN As New ClsCommon
    '            Dim DT As DataTable = OBJCMN.search("ISNULL(STATE_REMARK,'') AS STATECODE", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.ACC_STATEID = STATE_ID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID ", " AND INVOICEMASTER.INVOICE_NO = " & Val(I) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
    '            If DT.Rows(0).Item("STATECODE") <> CMPSTATECODE Then OBJINVOICE.IGSTFORMAT = True
    '            OBJINVOICE.registername = cmbregister.Text.Trim
    '            OBJINVOICE.INVNO = Val(I)
    '            OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '            OBJINVOICE.Show()
    '            OBJINVOICE.Close()
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub InvoiceDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillregister(cmbregister, " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)

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
                    MsgBox("Enter Proper Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Invoice from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJGRID As New InvoiceMasterGridDetails
            OBJGRID.MdiParent = MDIMain
            OBJGRID.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CHECKED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMULTI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMULTI.CheckedChanged
        Try
            If CHKMULTI.Checked = True Then
                multi = True
                TXTFROM.Focus()
            Else
                multi = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Sale Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Sale Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class