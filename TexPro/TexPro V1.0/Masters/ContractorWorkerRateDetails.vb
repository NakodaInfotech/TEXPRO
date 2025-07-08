
Imports BL

Public Class ContractorWorkerRateDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ContractorWorkerRateDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Then   'for Exit
            showform(False, "", 0)
        End If
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("CONTRACTOR"), GRIDBILL.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ContractorWorkerRateDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim objClsCommon As New ClsCommonMaster
        Dim dttable As DataTable = objClsCommon.search(" CR_WORKER AS WORKER, CR_RATE AS RATE, CR_DAYRATE AS DAYRATE, CR_NIGHTRATE AS NIGHTRATE, CR_ID AS ID, ISNULL(PROCESSMASTER.PROCESS_NAME,'') AS PROCESS, ISNULL(CONTRACTORMASTER.CONTRACTOR_NAME,'') AS CONTRACTOR", "", "CONTRACTORWORKERRATE LEFT OUTER JOIN PROCESSMASTER ON CR_PROCESSID = PROCESS_ID LEFT OUTER JOIN CONTRACTORMASTER ON CR_CONTRACTORID = CONTRACTOR_ID", " and CR_yearid = " & YearId & " ORDER BY CR_WORKER ")
        GRIDBILLDETAILS.DataSource = dttable

    End Sub

    Sub showform(ByVal editval As Boolean, ByVal NAME As String, ByVal ID As Integer)
        Try
            Dim OBJWORKER As New ContractorWorkerRate
            OBJWORKER.edit = editval
            OBJWORKER.MdiParent = MDIMain
            OBJWORKER.TempName = NAME
            OBJWORKER.TempID = ID
            OBJWORKER.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADDNEW.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(sender As Object, e As EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("CONTRACTOR"), GRIDBILL.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class