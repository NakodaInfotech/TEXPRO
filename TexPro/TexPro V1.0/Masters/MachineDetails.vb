
Imports BL

Public Class MachineDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", "", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal NO As String, ByVal id As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objmachinemaster As New MachineMaster
            objmachinemaster.edit = editval
            objmachinemaster.MdiParent = MDIMain
            objmachinemaster.tempname = name
            objmachinemaster.CMBMACHINENAME.Text = name
            objmachinemaster.TXTMACNO.Text = NO
            objmachinemaster.tempid = id
            objmachinemaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub machineDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then               'FOR new
            showform(False, "", "", 0)
        End If
    End Sub

    Private Sub machineDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MACHINE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        dttable = objClsCommon.search(" MACHINEMASTER.MACHINE_id AS [MACHINE ID], MACHINEMASTER.MACHINE_name AS [Machine Name], isnull(MACHINEMASTER.MACHINE_SUPPNAME,'') AS [Supp Name], PROCESSMASTER.PROCESS_NAME AS Process, MACHINEMASTER.MACHINE_no AS [No.], MACHINEMASTER.MACHINE_manpermac AS [Man / Mac], MACHINEMASTER.MACHINE_labpermac AS [Lab / Mac], MACHINEMASTER.MACHINE_costperhr AS [Cost / Hr], MACHINEMASTER.MACHINE_capperhr AS [Cap / Hr], MACHINEMASTER.MACHINE_powerperhr AS [Power / Hr], MACHINEMASTER.MACHINE_avgperhr AS [Avg Time] ", "", " MACHINEMASTER INNER JOIN PROCESSMASTER ON MACHINEMASTER.MACHINE_processid = PROCESSMASTER.PROCESS_ID AND MACHINEMASTER.MACHINE_cmpid = PROCESSMASTER.PROCESS_CMPID AND MACHINEMASTER.MACHINE_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND MACHINEMASTER.MACHINE_yearid = PROCESSMASTER.PROCESS_YEARID", " and machine_cmpid=" & CmpId & " and MACHINE_LOCATIONID = " & Locationid & " AND MACHINE_YEARID = " & YearId)
        If dttable.Rows.Count > 0 Then
            GRIDMACHINE.DataSource = dttable
            GRIDMACHINE.Columns(0).Visible = False
            GRIDMACHINE.Columns(1).Width = 150
            GRIDMACHINE.Columns(2).Width = 200

            GRIDMACHINE.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
            GRIDMACHINE.FirstDisplayedScrollingRowIndex = GRIDMACHINE.RowCount - 1
        End If

    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDMACHINE.Item(1, GRIDMACHINE.CurrentRow.Index).Value.ToString, GRIDMACHINE.Item(2, GRIDMACHINE.CurrentRow.Index).Value.ToString, GRIDMACHINE.Item(0, GRIDMACHINE.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMACHINE.CellDoubleClick
        Try
            showform(True, GRIDMACHINE.Item(1, GRIDMACHINE.CurrentRow.Index).Value.ToString, GRIDMACHINE.Item(2, GRIDMACHINE.CurrentRow.Index).Value.ToString, GRIDMACHINE.Item(0, GRIDMACHINE.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcmp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcmp.Validated

        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To GRIDMACHINE.RowCount
            txttempname.Text = GRIDMACHINE.Item(1, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtcmp.TextLength
            If LCase(txtcmp.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                GRIDMACHINE.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class