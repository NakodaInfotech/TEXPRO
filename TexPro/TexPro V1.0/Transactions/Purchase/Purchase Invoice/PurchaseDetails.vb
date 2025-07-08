
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base

Public Class PurchaseDetails

    Dim PURCHASEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub PURCHASEMASTERDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
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
            Dim dt As DataTable
            dt = objclsCMST.search("  dbo.PURCHASEMASTER.BILL_NO AS [Sr. No], dbo.PURCHASEMASTER.BILL_DATE AS Date, dbo.ledgers.acc_cmpname AS [Party Name], dbo.PURCHASEMASTER.BILL_partybillNO AS [PartyBillNo], dbo.PURCHASEMASTER.BILL_partybilldate AS [PartyBillDate],dbo.PURCHASEMASTER.BILL_ChallanNO AS [Challan No.],dbo.PURCHASEMASTER.BILL_Challandate AS [Challan Date],ITEMMASTER.ITEM_NAME AS ITEMNAME,PURCHASEMASTER_DESC.BILL_QTY AS QTY, PURCHASEMASTER_DESC.BILL_RATE AS RATE,PURCHASEMASTER_DESC.BILL_AMT AS AMT, PURCHASEMASTER_DESC.BILL_DISCAMT AS DISCAMT, PURCHASEMASTER_DESC.BILL_SPDISCAMT AS SPDISCAMT, PURCHASEMASTER_DESC.BILL_OTHERAMT AS OTHERAMT, PURCHASEMASTER_DESC.BILL_TAXABLEAMT AS TAXABLEAMT, PURCHASEMASTER_DESC.BILL_CGSTAMT AS CGSTAMT, PURCHASEMASTER_DESC.BILL_SGSTAMT AS SGSTAMT, PURCHASEMASTER_DESC.BILL_IGSTAMT AS IGSTAMT, PURCHASEMASTER_DESC.BILL_GRIDTOTAL AS GRIDTOTAL, BILL_GRANDTOTAL AS GTOTAL, BILL_GRNNO AS GRNNO, PURCHASEMASTER.BILL_DISPUTE AS DISPUTED, PURCHASEMASTER.BILL_CHKED AS CHECKED, ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME,'') AS DEPARTMENT   ", "", "   PURCHASEMASTER INNER JOIN ledgers ON PURCHASEMASTER.BILL_LEDGERID = ledgers.acc_id INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID AND PURCHASEMASTER.BILL_INITIALS = PURCHASEMASTER_DESC.BILL_INITIALS AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_DESC.BILL_yearid INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.ITEM_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID", tepmcondition)
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
                Dim OBJBILL As New PurchaseMaster
                OBJBILL.MdiParent = MDIMain
                OBJBILL.EDIT = editval
                OBJBILL.TEMPBILLNO = billno
                OBJBILL.TEMPREGNAME = cmbregister.Text.Trim
                OBJBILL.Show()
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
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURCHASEREGID = dt.Rows(0).Item(0)
                    fillgrid(" and dbo.PURCHASEMASTER.BILL_cmpid=" & CmpId & " and PURCHASEMASTER.BILL_locationid = " & Locationid & " and PURCHASEMASTER.BILL_yearid = " & YearId & " AND PURCHASEMASTER.BILL_registerid = " & PURCHASEREGID & " order by dbo.PURCHASEMASTER.BILL_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("Sr. No"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCopy.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            Dim TEMPMSG As Integer
            TEMPMSG = MsgBox("Wish to Copy Bill No " & gridbill.GetFocusedRowCellValue("Sr. No"), MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                alParaval.Add(gridbill.GetFocusedRowCellValue("Sr. No"))
                alParaval.Add(cmbregister.Text.Trim)
                alParaval.Add(CmpId)

                Dim OBJBILL As New ClsPurchaseMaster()
                OBJBILL.alParaval = alParaval

                IntResult = OBJBILL.COPY()
                MessageBox.Show("Details Copied")
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_locationid = " & Locationid & " and register_yearid = " & YearId)

                If dt.Rows.Count > 0 Then
                    PURCHASEREGID = dt.Rows(0).Item(0)
                    fillgrid(" and dbo.PURCHASEMASTER.BILL_cmpid=" & CmpId & " and PURCHASEMASTER.BILL_locationid = " & Locationid & " and PURCHASEMASTER.BILL_yearid = " & YearId & " AND PURCHASEMASTER.BILL_registerid = " & PURCHASEREGID & " order by dbo.PURCHASEMASTER.BILL_no ")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Purchase Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("CHECKED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles gridbill.CellValueChanged
        If IsDBNull(e.Value) = True Then Exit Sub
        Dim ROW As DataRow = gridbill.GetFocusedDataRow
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        On Error Resume Next
        If ROW("CHECKED") = True Then
            DT = OBJCMN.Execute_Any_String("UPDATE PURCHASEMASTER SET BILL_CHKED = 1 FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID WHERE BILL_NO = " & ROW("Sr. No") & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND BILL_YEARID = " & YearId, "", "")
        Else
            DT = OBJCMN.Execute_Any_String("UPDATE PURCHASEMASTER SET BILL_CHKED = 0 FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID WHERE BILL_NO = " & ROW("Sr. No") & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND BILL_YEARID = " & YearId, "", "")
        End If

        If ROW("DISPUTED") = True Then
            DT = OBJCMN.Execute_Any_String("UPDATE PURCHASEMASTER SET BILL_DISPUTE = 1 FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID WHERE BILL_NO = " & ROW("Sr. No") & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND BILL_YEARID = " & YearId, "", "")
        Else
            DT = OBJCMN.Execute_Any_String("UPDATE PURCHASEMASTER SET BILL_DISPUTE = 0 FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID WHERE BILL_NO = " & ROW("Sr. No") & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND BILL_YEARID = " & YearId, "", "")
        End If
    End Sub

    Private Sub PurchaseDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "TULSI" Then GDISPUTE.Caption = "Bill Checked By Boss"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class