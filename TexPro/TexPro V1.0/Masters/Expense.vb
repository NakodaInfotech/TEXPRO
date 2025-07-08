Imports BL
Imports System.Windows.Forms
Imports System.Data

Public Class Expense
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean = False
    Public tempprocessName As String
    Public tempprocessId As Integer

    Sub FillCombo()
        Try
            If cmbProcess.Text.Trim = "" Then FILLPROCESS(cmbProcess, " AND PROCESS_TYPE<>''", edit)
            fillitemname(cmbQuality, " AND ITEMMASTER.ITEM_FRMSTRING='MERCHANT'")
            fillEXPENSE(cmbexpensename, edit)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(cmbProcess.Text.Trim)

            Dim EXPENSENAME As String = ""
            Dim QUALITY As String = ""
            Dim RATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDRATE.Rows
                If EXPENSENAME = "" Then
                    EXPENSENAME = row.Cells(gname.Index).Value.ToString
                    QUALITY = row.Cells(GQuality.Index).Value.ToString
                    RATE = Val(row.Cells(grate.Index).Value)
                Else
                    EXPENSENAME = EXPENSENAME & "," & row.Cells(gname.Index).Value.ToString
                    QUALITY = QUALITY & "," & row.Cells(GQuality.Index).Value.ToString
                    RATE = RATE & "," & Val(row.Cells(grate.Index).Value)
                End If
            Next

            alParaval.Add(EXPENSENAME)
            alParaval.Add(QUALITY)
            alParaval.Add(RATE)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim obclsexpns As New ClsExpense
            obclsexpns.alParaval = alParaval
            'If USERADD = False Then
            '    MsgBox("Insufficient Rights")
            '    Exit Sub
            'End If
            IntResult = obclsexpns.save()
            MsgBox("Details Added")

            clear()
            cmbProcess.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbProcess.Text.Trim.Length = 0 Then
            Ep.SetError(cmbProcess, "Fill Item Name")
            bln = False
        End If

        If GRIDRATE.RowCount = 0 Then
            Ep.SetError(GRIDRATE, "Fill The Grid")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()

        GRIDRATE.RowCount = 0
        cmbProcess.Text = ""
        cmbexpensename.Text = ""
        cmbQuality.Text = ""
        txtrate.Clear()
        txtremarks.Clear()
        edit = False
    End Sub

    Private Sub Expense_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'EXPENSE MASTER'")
            'USERADD = DTROW(0).Item(1)
            'USEREDIT = DTROW(0).Item(2)
            'USERVIEW = DTROW(0).Item(3)
            'USERDELETE = DTROW(0).Item(4)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                cmbProcess.Text = ""
            End If
            FillCombo()
            cmbProcess.Text = tempprocessName

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDRATE.Rows.Add(cmbexpensename.Text.Trim, cmbQuality.Text.Trim, Val(txtrate.Text.Trim))
        ElseIf gridDoubleClick = True Then
            GRIDRATE.Rows(tempRow).Cells(gname.Index).Value = cmbexpensename.Text.Trim
            GRIDRATE.Rows(tempRow).Cells(GQuality.Index).Value = cmbQuality.Text.Trim
            GRIDRATE.Rows(tempRow).Cells(grate.Index).Value = Format(Val(txtrate.Text.Trim), "0.00")

            gridDoubleClick = False
        End If
        GRIDRATE.FirstDisplayedScrollingRowIndex = GRIDRATE.RowCount - 1
        cmbexpensename.Text = ""
        txtrate.Clear()
        cmbexpensename.Focus()
    End Sub

    Private Sub GRIDRATE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRATE.CellDoubleClick
        If e.RowIndex >= 0 And GRIDRATE.Item(gname.Index, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            cmbexpensename.Text = GRIDRATE.Item(gname.Index, e.RowIndex).Value
            cmbQuality.Text = GRIDRATE.Item(GQuality.Index, e.RowIndex).Value
            txtrate.Text = GRIDRATE.Item(grate.Index, e.RowIndex).Value
            tempRow = e.RowIndex
            cmbexpensename.Focus()
        End If
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRATE.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDRATE.Rows.RemoveAt(GRIDRATE.CurrentRow.Index)
        End If
    End Sub

    Private Sub cmbQuality_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbQuality.GotFocus
        Try
            If cmbQuality.Text.Trim = "" Then fillitemname(cmbQuality, " AND ITEMMASTER.ITEM_FRMSTRING='MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try
            If cmbProcess.Text.Trim = "" Then
                MsgBox("Select Process First", MsgBoxStyle.Critical, CmpName)
                cmbProcess.Focus()
            End If
            If cmbexpensename.Text.Trim <> "" And cmbQuality.Text.Trim <> "" And txtrate.Text.Trim <> "" Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
                cmbexpensename.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbProcess_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbProcess.Validating
        Try
            If cmbProcess.Text.Trim <> "" Then
                pcase(cmbProcess)

                'GETTING DATA FOR EDIT MODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" EXPENSEMASTER.EXP_NAME AS EXPENSENAME, ITEMMASTER.item_name AS QUALITY, EXPENSE_DESC.EXP_RATE AS RATE, EXPENSE_DESC.EXP_REMARKS AS REMARKS", "", " EXPENSE_DESC LEFT OUTER JOIN PROCESSMASTER ON EXPENSE_DESC.EXP_yearid = PROCESSMASTER.PROCESS_YEARID AND EXPENSE_DESC.EXP_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND EXPENSE_DESC.EXP_cmpid = PROCESSMASTER.PROCESS_CMPID AND EXPENSE_DESC.EXP_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN ITEMMASTER ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_locationid = ITEMMASTER.item_locationid AND EXPENSE_DESC.EXP_cmpid = ITEMMASTER.item_cmpid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id LEFT OUTER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid AND EXPENSE_DESC.EXP_locationid = EXPENSEMASTER.EXP_locationid AND EXPENSE_DESC.EXP_cmpid = EXPENSEMASTER.EXP_cmpid AND EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id", " AND PROCESSMASTER.PROCESS_NAME = '" & cmbProcess.Text.Trim & "' AND EXPENSE_DESC.EXP_CMPID = " & CmpId & " AND EXPENSE_DESC.EXP_LOCATIONID = " & Locationid & " AND EXPENSE_DESC.EXP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    GRIDRATE.RowCount = 0
                    For Each DTROW As DataRow In DT.Rows
                        GRIDRATE.Rows.Add(DTROW("EXPENSENAME"), DTROW("QUALITY"), Format(DTROW("RATE"), "0.00"))
                        txtremarks.Text = DTROW("REMARKS")
                    Next
                Else
                    GRIDRATE.RowCount = 0
                End If
                edit = True


            End If
        Catch ex As Exception
            'GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbexpensename_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbexpensename.Validating
        Try
            If cmbexpensename.Text.Trim <> "" Then EXPENSEVALIDATE(cmbexpensename, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbProcess_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcess.Enter
        Try
            If cmbProcess.Text.Trim <> "" Then
                pcase(cmbProcess)

                'GETTING DATA FOR EDIT MODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" EXPENSEMASTER.EXP_NAME AS EXPENSENAME, ITEMMASTER.item_name AS QUALITY, EXPENSE_DESC.EXP_RATE AS RATE, EXPENSE_DESC.EXP_REMARKS AS REMARKS", "", " EXPENSE_DESC LEFT OUTER JOIN PROCESSMASTER ON EXPENSE_DESC.EXP_yearid = PROCESSMASTER.PROCESS_YEARID AND EXPENSE_DESC.EXP_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND EXPENSE_DESC.EXP_cmpid = PROCESSMASTER.PROCESS_CMPID AND EXPENSE_DESC.EXP_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN ITEMMASTER ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_locationid = ITEMMASTER.item_locationid AND EXPENSE_DESC.EXP_cmpid = ITEMMASTER.item_cmpid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id LEFT OUTER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid AND EXPENSE_DESC.EXP_locationid = EXPENSEMASTER.EXP_locationid AND EXPENSE_DESC.EXP_cmpid = EXPENSEMASTER.EXP_cmpid AND EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id", " AND PROCESSMASTER.PROCESS_NAME = '" & cmbProcess.Text.Trim & "' AND EXPENSE_DESC.EXP_CMPID = " & CmpId & " AND EXPENSE_DESC.EXP_LOCATIONID = " & Locationid & " AND EXPENSE_DESC.EXP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    GRIDRATE.RowCount = 0
                    For Each DTROW As DataRow In DT.Rows
                        GRIDRATE.Rows.Add(DTROW("EXPENSENAME"), DTROW("QUALITY"), Format(DTROW("RATE"), "0.00"))
                        txtremarks.Text = DTROW("REMARKS")
                    Next
                    edit = True
                End If

            End If
        Catch ex As Exception
            'GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        Try
            numdotkeypress(e, txtrate, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbexpensename_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbexpensename.Enter
        Try
            If cmbexpensename.Text.Trim = "" Then fillEXPENSE(cmbexpensename, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Expense_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQuality_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbQuality.Validating
        Try
            If cmbQuality.Text.Trim <> "" Then itemvalidate(cmbQuality, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSEARCHQUALITY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSEARCHQUALITY.Validated
        For Each ROW As DataGridViewRow In GRIDRATE.Rows
            If ROW.Cells(gname.Index).Value = Nothing Then GoTo NEXTLINE
            If IsDBNull((ROW.Cells(GQuality.Index).Value)) = True Then GoTo NEXTLINE
            If LCase(ROW.Cells(gname.Index).Value) = LCase(TXTSEARCHEXPNAME.Text.Trim) And LCase(ROW.Cells(GQuality.Index).Value) = LCase(TXTSEARCHQUALITY.Text.Trim) Then
                GRIDRATE.FirstDisplayedScrollingRowIndex = ROW.Index
                GRIDRATE.Rows(ROW.Index).Selected = True
                TXTSEARCHEXPNAME.Clear()
                TXTSEARCHQUALITY.Clear()
                Exit Sub
            End If
NEXTLINE:
        Next
    End Sub
End Class