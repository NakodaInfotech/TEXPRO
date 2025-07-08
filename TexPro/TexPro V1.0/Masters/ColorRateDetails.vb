
Imports BL

Public Class ColorRateDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub ColorRateDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub ColorRateDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()

            If GRIDCOLOR.RowCount > 0 Then GRIDCOLOR.FirstDisplayedScrollingRowIndex = GRIDCOLOR.RowCount - 1

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search(" CR_NO AS COLOR, CR_RATE AS RATE, CR_ID AS ID, ISNULL(PROCESSMASTER.PROCESS_NAME,'') AS PROCESS", "", "COLORRATEMASTER LEFT OUTER JOIN PROCESSMASTER ON CR_PROCESSID = PROCESS_ID", " and CR_yearid = " & YearId & " ORDER BY CR_NO ")
        If dttable.Rows.Count > 0 Then
            GRIDCOLOR.DataSource = dttable
            GRIDCOLOR.Columns(0).HeaderText = "Color"
            GRIDCOLOR.Columns(1).HeaderText = "Rate"
            GRIDCOLOR.Columns(3).HeaderText = "Process"

            GRIDCOLOR.Columns(0).Width = 80
            GRIDCOLOR.Columns(1).Width = 80
            GRIDCOLOR.Columns(2).Visible = False
            GRIDCOLOR.Columns(3).Width = 150
        End If

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDCOLOR.Item(0, GRIDCOLOR.CurrentRow.Index).Value.ToString, GRIDCOLOR.Item(2, GRIDCOLOR.CurrentRow.Index).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal NAME As String, ByVal ID As Integer)
        Try

            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCOLOR As New ColorRateMaster
            OBJCOLOR.edit = editval
            OBJCOLOR.MdiParent = MDIMain
            OBJCOLOR.TempName = name
            OBJCOLOR.TempID = ID
            OBJCOLOR.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCOLOR.CellDoubleClick
        Try
            showform(True, GRIDCOLOR.Item(0, GRIDCOLOR.CurrentRow.Index).Value.ToString, GRIDCOLOR.Item(2, GRIDCOLOR.CurrentRow.Index).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtgroup_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgroup.Validated
        Dim rowno, b As Integer
        fillgrid()
        rowno = 0
        For b = 1 To GRIDCOLOR.RowCount
            txttempname.Text = GRIDCOLOR.Item(0, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtgroup.TextLength
            If LCase(txtgroup.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                GRIDCOLOR.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

End Class