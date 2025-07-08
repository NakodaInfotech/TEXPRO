
Imports System.ComponentModel
Imports BL

Public Class AnalyticalFilterPurchase

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillcmb()
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " AND GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'AGENT'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS')", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AnalyticalFilterPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreStockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcmb()
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try

            If Val(TXTTOP.Text.Trim) = 0 And (RDBTOPITEM.Checked = True Or RDBTOPDEPARTMENT.Checked = True) Then
                MsgBox("Enter Value", MsgBoxStyle.Critical)
                TXTTOP.Focus()
                Exit Sub
            End If

            Dim WHERECLAUSE As String = " AND PURCHASEMASTER.BILL_YEARID = " & YearId
            Dim FRMSTRING As String = ""
            Dim PERIOD As String = ""

            If cmbname.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(LEDGERS.ACC_CMPNAME, '') ='" & cmbname.Text.Trim & "'"
            If CMBAGENT.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(AGENTLEDGERS.ACC_CMPNAME, '') ='" & CMBAGENT.Text.Trim & "'"
            If cmbmerchant.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(ITEMMASTER.item_name, '') ='" & cmbmerchant.Text.Trim & "'"
            If CMBDEPARTMENT.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME, '') ='" & CMBDEPARTMENT.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then
                PERIOD = Format(Convert.ToDateTime(dtfrom.Value.Date).Date, "dd/MM/yyyy") & "-" & Format(Convert.ToDateTime(dtto.Value.Date).Date, "dd/MM/yyyy")
                WHERECLAUSE = WHERECLAUSE & " AND PURCHASEMASTER.BILL_PARTYBILLDATE >='" & Format(Convert.ToDateTime(dtfrom.Value.Date).Date, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_PARTYBILLDATE <='" & Format(Convert.ToDateTime(dtto.Value.Date).Date, "MM/dd/yyyy") & "'"
            Else
                PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
            End If

            Dim OBJCMN As New ClsCommon()
            Dim dt As New DataTable
            If RDBTOPDEPARTMENT.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME, '') AS DEPARTMENTNAME, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_QTY), 0) AS QTY, 0 AS MTRS, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) AS AMOUNT ", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON PURCHASEMASTER.BILL_AGENTID = AGENTLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME, '') HAVING  ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY AMOUNT DESC")
                FRMSTRING = "PURDEPARTMENTWISE"

            ElseIf RDBTOPITEM.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEMNAME, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_QTY), 0) AS QTY, 0 AS MTRS, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) AS AMOUNT ", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON PURCHASEMASTER.BILL_AGENTID = AGENTLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(ITEMMASTER.ITEM_NAME, '') HAVING  ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY AMOUNT DESC")
                FRMSTRING = "PURITEMWISE"

            ElseIf RDBTOPAGENT.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(AGENTLEDGERS.ACC_CMPNAME, '') AS AGENTNAME, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_QTY), 0) AS QTY, 0 AS MTRS, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) AS AMOUNT ", "", "  PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON PURCHASEMASTER.BILL_AGENTID = AGENTLEDGERS.Acc_id  ", WHERECLAUSE & " GROUP BY ISNULL(AGENTLEDGERS.ACC_CMPNAME, '') HAVING  ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY AMOUNT DESC")
                FRMSTRING = "PURAGENTWISE"

            ElseIf RDBTOPPARTY.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(LEDGERS.ACC_CMPNAME, '') AS NAME, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_QTY), 0) AS QTY, 0 AS MTRS, ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) AS AMOUNT ", "", "  PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON PURCHASEMASTER.BILL_AGENTID = AGENTLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(LEDGERS.ACC_CMPNAME, '') HAVING  ISNULL(SUM(PURCHASEMASTER_DESC.BILL_GRIDTOTAL), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY AMOUNT DESC")
                FRMSTRING = "PURPARTYWISE"

            End If

            Dim objrep As New clsReportDesigner("Analytical Report", System.AppDomain.CurrentDomain.BaseDirectory & "Analytical Report.xlsx", 2)
            objrep.CHART_REPORT_EXCEL(dt, CmpId, Locationid, YearId, "ANALYTICAL REPORT", FRMSTRING, PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class