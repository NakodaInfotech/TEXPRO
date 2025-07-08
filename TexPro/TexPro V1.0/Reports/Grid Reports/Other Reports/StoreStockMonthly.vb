
Imports BL

Public Class StoreStockMonthly

    Public WHERECLAUSE As String = ""
    Public ITEMNAME As String = "" 'FOR PASSIGNG ITEMNAME FURTHER FOR DETAILS
    

    Private Sub StoreStockMonthly_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" [MONTHNAME], SUM(INWARDS) AS INWARDS, SUM(RETURNING) AS RETURNING, SUM(DESPATCH) AS DESPATCH ", "", " (SELECT DATENAME(MONTH,DATE) as [MONTHNAME], SUM(QTY) AS INWARDS,  0 AS RETURNING, 0 AS DESPATCH, CMPID, LOCATIONID, YEARID FROM dbo.VIEW_STORE_STOCK  WHERE (TYPE = 'INWARDS') " & WHERECLAUSE & " GROUP BY DATENAME(MONTH,DATE),  CMPID, LOCATIONID, YEARID  UNION ALL SELECT DATENAME(MONTH,DATE)as [MONTHNAME], 0 AS INWARDS,  SUM(QTY) AS RETURNING, 0 AS DESPATCH, CMPID, LOCATIONID, YEARID FROM dbo.VIEW_STORE_STOCK WHERE (TYPE = 'RETURNING') " & WHERECLAUSE & " GROUP BY DATENAME(MONTH,DATE),  CMPID, LOCATIONID, YEARID UNION ALL SELECT DATENAME(MONTH,DATE) AS  [MONTHNAME], 0 AS INWARDS, 0 AS RETURNING, SUM(QTY) AS DESPATCH, CMPID, LOCATIONID, YEARID FROM dbo.VIEW_STORE_STOCK  WHERE (TYPE = 'DESPATCH' OR TYPE = 'ISSUE') " & WHERECLAUSE & " GROUP BY DATENAME(MONTH,DATE), CMPID, LOCATIONID, YEARID) as T ", " AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " GROUP BY [MONTHNAME] ORDER BY case [MONTHNAME] When 'April' then 1 When 'May' then 2 When 'June' then 3 When 'July' then 4 When 'August' then 5 When 'September' then 6 When 'October' then 7 When 'November' then 8 When 'December' then 9 When 'January' then 10 When 'February' then 11 When 'March' then 12 end;")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
            Dim DTTABLE = objclsCMST.search(" SUM(QTY) AS CLOSING ", "", " VIEW_STORE_STOCK ", WHERECLAUSE & " AND CMPID = " & CmpId & " AND YEARID = " & YearId & " GROUP BY CMPID , YEARID")
            If DTTABLE.Rows.Count > 0 Then TXTCLOSING.Text = Format(Val(DTTABLE.Rows(0).Item("CLOSING")), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreStockMonthly_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Monthwise Stock Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Monthwise Stock Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Monthwise Stock REport", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDETAILS.Click
        Try
            SHOWFORM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        Try
            Dim DTROW As DataRow = gridbill.GetFocusedDataRow()
            Dim FROMDATE As DateTime = getfirstdate(CmpId, DTROW("MONTHNAME"))
            Dim TODATE As DateTime = getlastdate(CmpId, DTROW("MONTHNAME"))

            Dim OBJSTORE As New ConsumptionDetails
            If ITEMNAME.Trim <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND ITEMMASTER.ITEM_NAME = '" & ITEMNAME.Trim & "'"
            OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND CONSUMPTION.CONSUME_date >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND CONSUMPTION.CONSUME_date <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'"
            OBJSTORE.MdiParent = MDIMain
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            SHOWFORM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class