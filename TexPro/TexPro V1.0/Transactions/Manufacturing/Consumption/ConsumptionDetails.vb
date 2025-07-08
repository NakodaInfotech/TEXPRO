
Imports BL
Imports System.Windows.Forms

Public Class ConsumptionDetails

    Public edit As Boolean
    Dim TEMPCONSUMENO As Integer
    Public WHERECLAUSE As String
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
        DTROW = USERRIGHTS.Select("FormName = 'GRN'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" and dbo.CONSUMPTION.CONSUME_CMPID=" & CmpId & " and dbo.CONSUMPTION.CONSUME_locationid=" & Locationid & " and dbo.CONSUMPTION.CONSUME_yearid=" & YearId & " order by dbo.CONSUMPTION.CONSUME_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CONSUMPTION.CONSUME_no AS SRNO, CONSUMPTION.CONSUME_date AS DATE, CONSUMPTION.CONSUME_ISSUETO AS ISSUETO, DEPARTMENTMASTER.DEPARTMENT_name AS DEPARTMENTNAME, ITEMMASTER.item_name AS ITEMNAME, CONSUMPTION_DESC.CONSUME_QTY AS QTY, ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE, 0) AS RATE, ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE, 0) * ISNULL(CONSUMPTION_DESC.CONSUME_QTY, 0) AS AMOUNT ", "", " ITEMMASTER INNER JOIN CONSUMPTION_DESC ON ITEMMASTER.item_id = CONSUMPTION_DESC.CONSUME_ITEMID AND ITEMMASTER.item_cmpid = CONSUMPTION_DESC.CONSUME_cmpid AND ITEMMASTER.item_locationid = CONSUMPTION_DESC.CONSUME_locationid AND ITEMMASTER.item_yearid = CONSUMPTION_DESC.CONSUME_yearid INNER JOIN CONSUMPTION ON CONSUMPTION_DESC.CONSUME_no = CONSUMPTION.CONSUME_no AND CONSUMPTION_DESC.CONSUME_cmpid = CONSUMPTION.CONSUME_cmpid AND CONSUMPTION_DESC.CONSUME_locationid = CONSUMPTION.CONSUME_locationid AND CONSUMPTION_DESC.CONSUME_yearid = CONSUMPTION.CONSUME_yearid LEFT OUTER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID LEFT OUTER JOIN DEPARTMENTMASTER ON CONSUMPTION.CONSUME_DEPARTMENTid = DEPARTMENTMASTER.DEPARTMENT_id AND CONSUMPTION.CONSUME_cmpid = DEPARTMENTMASTER.DEPARTMENT_cmpid AND CONSUMPTION.CONSUME_locationid = DEPARTMENTMASTER.DEPARTMENT_locationid AND CONSUMPTION.CONSUME_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid ", WHERECLAUSE & tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal CONSUMENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New Consumption
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPCONSUMENO = CONSUMENO
                objREQ.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            'If USERADD = False Then
            '    MsgBox("Insufficient Rights")
            '    Exit Sub
            'End If
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

            Dim PATH As String = Application.StartupPath & "\Consumption Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Credit Note Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Credit Note Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.CONSUMPTION.CONSUME_CMPID=" & CmpId & " and dbo.CONSUMPTION.CONSUME_locationid=" & Locationid & " and dbo.CONSUMPTION.CONSUME_yearid=" & YearId & " order by dbo.CONSUMPTION.CONSUME_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class