
Imports BL

Public Class SaleOrderDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SALEOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SALEOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("SALEORDER.SO_NO AS SONO, SALEORDER.SO_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname,'') AS SHIPTO, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENT, ISNULL(TRANSLEDGERS.Acc_cmpname,'') AS TRANSNAME, SALEORDER.SO_PONO AS PONO, ISNULL(CITYMASTER.city_name,'') AS CITY, SALEORDER.SO_TOTALBALES AS TOTALBALES, SALEORDER.SO_TOTALAMT AS TOTALAMT, SALEORDER.SO_REMARKS AS REMARKS, SALEORDER_DESC.SO_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNRECIPE.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, SALEORDER_DESC.SO_BALES AS BALES, SALEORDER_DESC.SO_RATE AS RATE, SALEORDER_DESC.SO_AMT AS AMT, SALEORDER_DESC.SO_GRIDREMARKS AS GRIDREMARKS, SALEORDER_DESC.SO_CLOSED AS CLOSED, SALEORDER_DESC.SO_OUTBALES AS OUTBALES, (SALEORDER_DESC.SO_BALES - SALEORDER_DESC.SO_OUTBALES) AS BALBALES ", "", " SALEORDER INNER JOIN SALEORDER_DESC ON SALEORDER.SO_NO = SALEORDER_DESC.SO_NO AND SALEORDER.SO_YEARID = SALEORDER_DESC.SO_YEARID INNER JOIN LEDGERS ON SALEORDER.SO_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN CITYMASTER ON SALEORDER.SO_CITYID = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON SALEORDER.SO_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON SALEORDER.SO_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON SALEORDER.SO_SHIPTOID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON SALEORDER_DESC.SO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNRECIPE ON SALEORDER_DESC.SO_DESIGNID = DESIGNRECIPE.DESIGN_ID", " AND SALEORDER.SO_YEARID = " & YearId & " ORDER BY SALEORDER.SO_NO")
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal SOno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPO As New SaleOrder
                objPO.MdiParent = MDIMain
                objPO.edit = editval
                objPO.tempsono = SOno
                objPO.Show()
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

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Sale Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Sale Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                If Val(ROW("OUTBALES")) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightYellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class