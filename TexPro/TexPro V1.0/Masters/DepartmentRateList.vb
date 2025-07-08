
Imports BL
Imports System.Windows.Forms
Public Class DepartmentRateList
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean
    Public tempprocessName As String
    Public tempDepartmentName As String
    Public Shared dt_SELECT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

   

    Private Sub CMBDEPARTMENT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartment.GotFocus
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillgrid()

        If gridDoubleClick = False Then
            gridMerchant.Rows.Add(CMBMERCHANT.Text.Trim, Val(txtrate.Text.Trim))
        ElseIf gridDoubleClick = True Then
            gridMerchant.Rows(tempRow).Cells(gMeRchant.Index).Value = CMBMERCHANT.Text.Trim
            gridMerchant.Rows(tempRow).Cells(Grate.Index).Value = Val(txtrate.Text.Trim)

            gridDoubleClick = False
        End If
        gridMerchant.FirstDisplayedScrollingRowIndex = gridMerchant.RowCount - 1
        txtrate.Clear()
        CMBMERCHANT.Focus()

    End Sub

    Private Sub cmbDepartment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartment.Validated
        If cmbDepartment.Text.Trim <> "" And edit = False Then
            'pcase(cmbDepartment)
            'Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" item_name", "", " ITEMMASTER ", " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    gridMerchant.RowCount = 0
            '    For Each DTROW As DataRow In DT.Rows
            '        gridMerchant.Rows.Add(DTROW("item_name"), 0)

            '    Next
            'End If

        End If
    End Sub

    Private Sub CMBDEPARTMENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbDepartment.Validating
        Try
            If cmbDepartment.Text.Trim <> "" Then DEPARTMENTVALIDATE(cmbDepartment, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

           

            Dim checked_processname As CheckedListBox.CheckedItemCollection = CLB_Process.CheckedItems
            For Each process_name As Object In checked_processname
                Dim IntResult As Integer
                Dim alParaval As New ArrayList
                alParaval.Add(cmbDepartment.Text.Trim)
                alParaval.Add(process_name)

                Dim itemname As String = ""
                Dim RATE As String = ""

                For Each row As Windows.Forms.DataGridViewRow In gridMerchant.Rows
                    If itemname = "" Then
                        itemname = row.Cells(gMeRchant.Index).Value

                        RATE = row.Cells(Grate.Index).Value

                    Else
                        itemname = itemname & "," & row.Cells(gMeRchant.Index).Value

                        RATE = RATE & "," & row.Cells(Grate.Index).Value

                    End If
                Next

                alParaval.Add(itemname)

                alParaval.Add(RATE)

                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(Userid)
                alParaval.Add(YearId)
                alParaval.Add(0)


                Dim obclsprocessmaster As New ClsDepartmentMaster
                obclsprocessmaster.alParaval = alParaval
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = obclsprocessmaster.savedepartmentpricelist()



            Next process_name
            MsgBox("Details Added")

            clear()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        gridMerchant.RowCount = 0
        For i As Integer = 0 To CLB_Process.Items.Count - 1
            CLB_Process.SetItemChecked(i, False)
        Next
        cmbDepartment.Text = ""

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable
        Dim processname As String = ""
        Dim checked_processname As CheckedListBox.CheckedItemCollection = CLB_Process.CheckedItems
        For Each process_name As Object In checked_processname



            If (edit = False) Or (edit = True And (LCase(cmbDepartment.Text) <> LCase(tempDepartmentName) Or LCase(process_name.ToString()) <> LCase(tempprocessName))) Then


                dt = objclscommon.search(" distinct   dbo.ITEMMASTER.item_name ", "", "        DEPARTMENTPRICELIST INNER JOIN DEPARTMENTMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_ID = DEPARTMENTMASTER.DEPARTMENT_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = DEPARTMENTMASTER.DEPARTMENT_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = DEPARTMENTMASTER.DEPARTMENT_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN PROCESSMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_PROCESSID = PROCESSMASTER.PROCESS_ID AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = PROCESSMASTER.PROCESS_CMPID AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_MERCHANTID = ITEMMASTER.item_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = ITEMMASTER.item_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = ITEMMASTER.item_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = ITEMMASTER.item_yearid ", " and  dbo.DEPARTMENTMASTER.DEPARTMENT_name = '" & cmbDepartment.Text.Trim & "' and  dbo.processMASTER.process_name='" & process_name.ToString() & "' and DEPARTMENTPRICELIST.DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENTPRICELIST.DEPARTMENT_locationid = " & Locationid & " and DEPARTMENTPRICELIST.DEPARTMENT_yearid = " & YearId)


                If dt.Rows.Count > 0 Then
                    MsgBox(process_name.ToString() & " Already Exists", MsgBoxStyle.Critical, CmpName)
                    bln = False
                    GoTo line1
                End If
            End If
        Next process_name
line1:

        If cmbDepartment.Text.Trim.Length = 0 Then
            EP.SetError(cmbDepartment, "Please Select Department Name")
            bln = False
        End If
        Return bln
    End Function
    Private Sub GRIDMERCHANT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMerchant.CellDoubleClick
        If e.RowIndex >= 0 And gridMerchant.Item(gMeRchant.Index, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            CMBMERCHANT.Text = gridMerchant.Item(gMeRchant.Index, e.RowIndex).Value
            txtrate.Text = gridMerchant.Item(Grate.Index, e.RowIndex).Value
            tempRow = e.RowIndex
            CMBMERCHANT.Focus()
        End If
    End Sub

    Private Sub gridMerchant_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridMerchant.CellValidating
        Try
            Dim colNum As Integer = gridMerchant.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case Grate.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridMerchant.CurrentCell.Value = Nothing Then gridMerchant.CurrentCell.Value = "0.00"
                        gridMerchant.CurrentCell.Value = Convert.ToDecimal(gridMerchant.Item(colNum, e.RowIndex).Value)

                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridMerchant_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridMerchant.KeyDown
        If e.KeyCode = Keys.Delete Then
            gridMerchant.Rows.RemoveAt(gridMerchant.CurrentRow.Index)
        End If
    End Sub



    Private Sub processMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub processMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PROCESS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillcombos()

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster

                dttable = objCommon.search("      DEPARTMENTMASTER.DEPARTMENT_name AS DEPARTMENT, PROCESSMASTER.PROCESS_NAME AS PROCESS, ITEMMASTER.item_name, DEPARTMENTPRICELIST.DEPARTMENT_RATE ", "", "    DEPARTMENTPRICELIST INNER JOIN DEPARTMENTMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_ID = DEPARTMENTMASTER.DEPARTMENT_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = DEPARTMENTMASTER.DEPARTMENT_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = DEPARTMENTMASTER.DEPARTMENT_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN PROCESSMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_PROCESSID = PROCESSMASTER.PROCESS_ID AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = PROCESSMASTER.PROCESS_CMPID AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_MERCHANTID = ITEMMASTER.item_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = ITEMMASTER.item_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = ITEMMASTER.item_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = ITEMMASTER.item_yearid ", " and dbo.departmentmaster.department_name = '" & tempDepartmentName & "' and dbo.processmaster.process_name = '" & tempprocessName & "' and DEPARTMENTPRICELIST.DEPARTMENT_cmpID=" & CmpId & " and DEPARTMENTPRICELIST.DEPARTMENT_locationID = " & Locationid & " and DEPARTMENTPRICELIST.DEPARTMENT_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    CLB_Process.Items.Clear()
                    CLB_Process.Items.Add(tempprocessName, True)

                    For Each dr As DataRow In dttable.Rows
                        cmbDepartment.Text = tempDepartmentName
                        
                        gridMerchant.Rows.Add(dr(2).ToString, Val(dr(3)))

                    Next
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        
        If edit = False Then
            CLB_Process.Items.Clear()
            Dim dt As DataTable
            Dim objclscomm As New ClsCommon()
            dt = objclscomm.search(" PROCESS_name ", "", " PROCESSMASTER", " and PROCESS_cmpid=" & CmpId & " AND PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_YEARID = " & YearId & " Order by process_name ")

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    CLB_Process.Items.Add(Convert.ToString(dr(0)), False)
                Next
            End If
        End If



        filldepartment(cmbDepartment, edit)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try
            If cmbDepartment.Text.Trim = "" Then
                MsgBox("Select department First", MsgBoxStyle.Critical, CmpName)
                cmbDepartment.Focus()
            End If
            If CMBMERCHANT.Text.Trim <> "" Then
                'CHECK WHETHER ITEM IS PRESENT IN GRID BELOW OR NOT
                For Each ROW As DataGridViewRow In gridMerchant.Rows
                    If (LCase(ROW.Cells(gMeRchant.Index).Value) = LCase(CMBMERCHANT.Text.Trim) And gridDoubleClick = False) Or (LCase(ROW.Cells(gMeRchant.Index).Value) = LCase(CMBMERCHANT.Text.Trim) And gridDoubleClick = True And tempRow <> ROW.Index) Then
                        MsgBox("Item Already Present in Grid Below", MsgBoxStyle.Critical)
                        CMBMERCHANT.Focus()
                        Exit Sub
                    End If
                Next
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub chkProcessall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProcessall.CheckedChanged
        If chkProcessall.Checked = True Then
            For i As Integer = 0 To CLB_Process.Items.Count - 1
                CLB_Process.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_Process.Items.Count - 1
                CLB_Process.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        dt_SELECT.Clear()
        Dim OBJSELECTPO As New SelectDeparment
        OBJSELECTPO.ShowDialog()
        For I As Integer = 0 To dt_SELECT.Rows.Count - 1
            gridMerchant.Rows.Add(dt_SELECT.Rows(I).Item("MERCHANT"), dt_SELECT.Rows(I).Item("RATE"))
        Next
    End Sub
End Class