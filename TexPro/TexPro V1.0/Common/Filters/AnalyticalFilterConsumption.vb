
Imports System.ComponentModel
Imports BL

Public Class AnalyticalFilterConsumption

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillcmb()
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
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

    Private Sub AnalyticalFilterConsumption_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

            Dim WHERECLAUSE As String = " AND CONSUMPTION.CONSUME_YEARID = " & YearId
            Dim FRMSTRING As String = ""
            Dim PERIOD As String = ""

            If cmbmerchant.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(ITEMMASTER.item_name, '') ='" & cmbmerchant.Text.Trim & "'"
            If CMBDEPARTMENT.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME, '') ='" & CMBDEPARTMENT.Text.Trim & "'"
            If chkdate.CheckState = CheckState.Checked Then
                PERIOD = Format(Convert.ToDateTime(dtfrom.Value.Date).Date, "dd/MM/yyyy") & "-" & Format(Convert.ToDateTime(dtto.Value.Date).Date, "dd/MM/yyyy")
                WHERECLAUSE = WHERECLAUSE & " AND CONSUMPTION.CONSUME_DATE >='" & Format(Convert.ToDateTime(dtfrom.Value.Date).Date, "MM/dd/yyyy") & "' AND CONSUMPTION.CONSUME_DATE <='" & Format(Convert.ToDateTime(dtto.Value.Date).Date, "MM/dd/yyyy") & "'"
            Else
                PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
            End If

            Dim OBJCMN As New ClsCommon()
            Dim dt As New DataTable
            If RDBTOPDEPARTMENT.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME, '') AS DEPARTMENTNAME, ISNULL(SUM(CONSUMPTION_DESC.CONSUME_QTY), 0) AS QTY, 0 AS MTRS, ISNULL(SUM(ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE, 0) * ISNULL(CONSUMPTION_DESC.CONSUME_QTY, 0)), 0) AS AMOUNT ", "", " CONSUMPTION INNER JOIN CONSUMPTION_DESC ON CONSUMPTION.CONSUME_no = CONSUMPTION_DESC.CONSUME_NO AND CONSUMPTION.CONSUME_YEARID = CONSUMPTION_DESC.CONSUME_YEARID INNER JOIN ITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = ITEMMASTER.item_id  LEFT OUTER JOIN DEPARTMENTMASTER ON DEPARTMENTMASTER.DEPARTMENT_id = CONSUMPTION.CONSUME_departmentid LEFT OUTER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID  ", WHERECLAUSE & " GROUP BY ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME, '') HAVING  ISNULL(SUM(CONSUMPTION_DESC.CONSUME_QTY), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY AMOUNT DESC")
                FRMSTRING = "CONSUMPTIONDEPARTMENTWISE"

            ElseIf RDBTOPITEM.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEMNAME, ISNULL(SUM(CONSUMPTION_DESC.CONSUME_QTY), 0) AS QTY, 0 AS MTRS, ISNULL(SUM(ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE, 0) * ISNULL(CONSUMPTION_DESC.CONSUME_QTY, 0)), 0) AS AMOUNT ", "", " CONSUMPTION INNER JOIN CONSUMPTION_DESC ON CONSUMPTION.CONSUME_no = CONSUMPTION_DESC.CONSUME_NO AND CONSUMPTION.CONSUME_YEARID = CONSUMPTION_DESC.CONSUME_YEARID INNER JOIN ITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = ITEMMASTER.item_id  LEFT OUTER JOIN DEPARTMENTMASTER ON DEPARTMENTMASTER.DEPARTMENT_id = CONSUMPTION.CONSUME_departmentid LEFT OUTER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID ", WHERECLAUSE & " GROUP BY ISNULL(ITEMMASTER.ITEM_NAME, '') HAVING  ISNULL(SUM(CONSUMPTION_DESC.CONSUME_QTY), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY AMOUNT DESC")
                FRMSTRING = "CONSUMPTIONITEMWISE"

            ElseIf RDBMONTHLY.Checked = True Then
                dt = OBJCMN.search(" DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) AS MONTHNAME, ISNULL(SUM(CONSUMPTION_DESC.CONSUME_QTY), 0) AS QTY, 0 AS MTRS, ISNULL(SUM(ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE, 0) * ISNULL(CONSUMPTION_DESC.CONSUME_QTY, 0)), 0) AS AMOUNT ", "", " CONSUMPTION INNER JOIN CONSUMPTION_DESC ON CONSUMPTION.CONSUME_no = CONSUMPTION_DESC.CONSUME_NO AND CONSUMPTION.CONSUME_YEARID = CONSUMPTION_DESC.CONSUME_YEARID INNER JOIN ITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = ITEMMASTER.item_id  LEFT OUTER JOIN DEPARTMENTMASTER ON DEPARTMENTMASTER.DEPARTMENT_id = CONSUMPTION.CONSUME_departmentid LEFT OUTER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID ", WHERECLAUSE & " GROUP BY DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) HAVING  ISNULL(SUM(CONSUMPTION_DESC.CONSUME_QTY), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY CASE WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'April' then 1 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'May' then 2 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'June' then 3 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'July' then 4 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'August' then 5 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'September' then 6 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'October' then 7 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'November' then 8 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'December' then 9 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'January' then 10 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'February' then 11 WHEN DATENAME(MONTH,(CONSUMPTION.CONSUME_DATE)) = 'March' then 12 else 13 end ")
                FRMSTRING = "CONSUMPTIONMONTHLY"

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