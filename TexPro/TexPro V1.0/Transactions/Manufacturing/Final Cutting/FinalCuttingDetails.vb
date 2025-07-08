
Imports BL

Public Class finalcuttingdetails

    Public edit As Boolean
    Dim TEMPFCPNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PRequisitionDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PRequisitionDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'MFG'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" FINALCUTTINGPROCESS.FCP_NO AS SRNO, FINALCUTTINGPROCESS.FCP_DATE AS DATE, PROCESSMASTER.PROCESS_NAME AS PROCESS, FINALCUTTINGPROCESS.FCP_JOBNO AS JOBNO, ITEMMASTER.item_name AS MERCHANT, FINALCUTTINGPROCESS.FCP_TOTALSAREE AS SAREE, FINALCUTTINGPROCESS.FCP_TOTALMTRS AS MTRS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(FINALCUTTINGPROCESS.FCP_REFNO,'') AS REFNO, ISNULL(FINALCUTTINGPROCESS.FCP_INVOICENO,'') AS INVNO, ISNULL(FCP_GREYMTRS,0) AS GREYMTRS, ISNULL(FCP_SHORTAGEPER,0) AS SHORTAGEPER, ISNULL(FCP_DIFFMTRS,0) AS DIFFMTRS ", "", "   FINALCUTTINGPROCESS INNER JOIN PROCESSMASTER ON FINALCUTTINGPROCESS.FCP_FROMPROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN ITEMMASTER ON FINALCUTTINGPROCESS.FCP_MERCHANTID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON FINALCUTTINGPROCESS.FCP_LEDGERID = LEDGERS.ACC_ID", " and dbo.FINALCUTTINGPROCESS.FCP_CMPID=" & CmpId & " and dbo.FINALCUTTINGPROCESS.FCP_locationid=" & Locationid & " and dbo.FINALCUTTINGPROCESS.FCP_yearid=" & YearId & " order by dbo.FINALCUTTINGPROCESS.FCP_no ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal PONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New FinalCuttingProcess
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPFCPNO = PONO
                objREQ.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\FINALCUTTINGPROCESS DETAILS.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "FINALCUTTINGPROCESS DETAILS"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "FINALCUTTINGPROCESS DETAILS", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class