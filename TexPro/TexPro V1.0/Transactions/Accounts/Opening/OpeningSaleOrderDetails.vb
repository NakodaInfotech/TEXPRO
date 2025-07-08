

Imports BL

Public Class OpeningSaleOrderDetails

    Public edit As Boolean
    Dim TEMPSONO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub OPENINGSALEOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub OPENINGSALEOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" OPENINGSALEORDER.OSO_NO AS SONO, OPENINGSALEORDER.OSO_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname,'') AS SHIPTO, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENT, ISNULL(TRANSLEDGERS.Acc_cmpname,'') AS TRANSNAME, OPENINGSALEORDER.OSO_PONO AS PONO, ISNULL(CITYMASTER.city_name,'') AS CITY, OPENINGSALEORDER.OSO_TOTALBALES AS TOTALBALES, OPENINGSALEORDER.OSO_TOTALAMT AS TOTALAMT, OPENINGSALEORDER.OSO_REMARKS AS REMARKS, OPENINGSALEORDER_DESC.OSO_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(DESIGNRECIPE.DESIGN_NO,'') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, OPENINGSALEORDER_DESC.OSO_BALES AS BALES, OPENINGSALEORDER_DESC.OSO_RATE AS RATE, OPENINGSALEORDER_DESC.OSO_AMT AS AMT, OPENINGSALEORDER_DESC.OSO_GRIDREMARKS AS GRIDREMARKS, OPENINGSALEORDER_DESC.OSO_CLOSED AS CLOSED, OPENINGSALEORDER_DESC.OSO_OUTBALES AS OUTBALES ", "", " OPENINGSALEORDER INNER JOIN OPENINGSALEORDER_DESC ON OPENINGSALEORDER.OSO_NO = OPENINGSALEORDER_DESC.OSO_NO AND OPENINGSALEORDER.OSO_YEARID = OPENINGSALEORDER_DESC.OSO_YEARID INNER JOIN LEDGERS ON OPENINGSALEORDER.OSO_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON OPENINGSALEORDER_DESC.OSO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN CITYMASTER ON OPENINGSALEORDER.OSO_CITYID = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON OPENINGSALEORDER.OSO_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGSALEORDER.OSO_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON OPENINGSALEORDER.OSO_SHIPTOID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON OPENINGSALEORDER_DESC.OSO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNRECIPE ON OPENINGSALEORDER_DESC.OSO_DESIGNID = DESIGNRECIPE.DESIGN_ID ") ', TEMPSONO)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
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
                Dim objPO As New OpeningSaleOrder
                objPO.MdiParent = MDIMain
                objPO.EDIT = editval
                objPO.TEMPSONO = SOno
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
            Dim PATH As String = Application.StartupPath & "\Opening Sale Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Opening Sale Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Opening Sale Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Opening Sale Order Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
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