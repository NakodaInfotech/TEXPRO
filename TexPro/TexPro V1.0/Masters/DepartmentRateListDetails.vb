Imports BL
Public Class DepartmentRateListDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub addressDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then
            showform(False, "", "")
        End If
    End Sub

    Private Sub addressDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PROCESS MASTER'")
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

        Dim dttable As DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search(" distinct  DEPARTMENTMASTER.DEPARTMENT_name AS DEPARTMENT, PROCESSMASTER.PROCESS_NAME AS PROCESS ", "", " DEPARTMENTPRICELIST INNER JOIN DEPARTMENTMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_ID = DEPARTMENTMASTER.DEPARTMENT_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = DEPARTMENTMASTER.DEPARTMENT_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = DEPARTMENTMASTER.DEPARTMENT_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN PROCESSMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_PROCESSID = PROCESSMASTER.PROCESS_ID AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = PROCESSMASTER.PROCESS_CMPID AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = PROCESSMASTER.PROCESS_YEARID ", " and DEPARTMENTPRICELIST.DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENTPRICELIST.DEPARTMENT_locationid = " & Locationid & " and DEPARTMENTPRICELIST.DEPARTMENT_yearid = " & YearId)
        If dttable.Rows.Count > 0 Then
            gridaddress.DataSource = dttable

            'gridaddress.Columns(1).HeaderText = "Buyer"
            'gridaddress.Columns(2).HeaderText = "Consignee"
            'gridaddress.Columns(0).Visible = False

            'gridaddress.Columns(1).Width = 180
            'gridaddress.Columns(2).Width = 180
            'gridaddress.Columns(3).Width = 180
            'gridaddress.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic

            gridaddress.FirstDisplayedScrollingRowIndex = gridaddress.RowCount - 1
        End If
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridaddress.Item(0, gridaddress.CurrentRow.Index).Value.ToString, gridaddress.Item(1, gridaddress.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal DEPARTMENT As String, ByVal PROCESS As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objDepartmentRateList As New DepartmentRateList
            objDepartmentRateList.edit = editval
            objDepartmentRateList.MdiParent = MDIMain
            objDepartmentRateList.tempDepartmentName = DEPARTMENT
            objDepartmentRateList.tempprocessName = PROCESS
            objDepartmentRateList.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridaddress_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridaddress.CellDoubleClick
        Try
            showform(True, gridaddress.Item(0, gridaddress.CurrentRow.Index).Value.ToString, gridaddress.Item(1, gridaddress.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

 
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class