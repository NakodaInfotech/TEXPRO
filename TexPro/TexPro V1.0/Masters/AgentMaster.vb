
Imports BL
Imports System.Windows.Forms
Imports System.IO
Public Class AgentMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean = False
    Public tempagentName As String
    Public tempagentId As Integer
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub txtrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, txtrate, Me)
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList


            alParaval.Add(CMBAGENT.Text.Trim)

            Dim name As String = ""
            Dim merchant As String = ""
            Dim RATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridname.Rows
                If name = "" Then
                    name = row.Cells(gName.Index).Value
                    merchant = row.Cells(gMerchant.Index).Value
                    RATE = row.Cells(Grate.Index).Value
                Else
                    name = name & "," & row.Cells(gName.Index).Value
                    merchant = merchant & "," & row.Cells(gMerchant.Index).Value
                    RATE = RATE & "," & row.Cells(Grate.Index).Value

                End If
            Next

            alParaval.Add(name)
            alParaval.Add(merchant)
            alParaval.Add(RATE)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim obclsagentmaster As New ClsAccountsMaster
            obclsagentmaster.alParaval = alParaval
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            'IntResult = obclsagentmaster.saveagentDESC()
            'MsgBox("Details Added")

            clear()
            CMBAGENT.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        gridname.RowCount = 0
        cmbname.Text = ""
        cmbmerchant.Text = ""
        TXTRATE.Clear()
        CMBAGENT.Text = ""
        txtremarks.Clear()
        edit = False
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If CMBAGENT.Text.Trim.Length = 0 Then
            EP.SetError(CMBAGENT, "Please Select agent Name")
            bln = False
        End If

        If gridname.RowCount = 0 Then
            EP.SetError(TXTRATE, "Please Fill Item Details")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.GotFocus
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbagent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then
                namevalidate(CMBAGENT, e, Me, txtremarks, " and GROUPMASTER.GROUP_NAME = 'Sundry debtors'")

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, e, Me, txtremarks, " and GROUPMASTER.GROUP_NAME = 'Sundry debtors'")

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbmerchant_enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillname(cmbmerchant, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Sub fillgrid()

        If gridDoubleClick = False Then
            gridname.Rows.Add(cmbname.Text.Trim, cmbmerchant.Text.Trim, Val(TXTRATE.Text.Trim))
        ElseIf gridDoubleClick = True Then
            gridname.Rows(tempRow).Cells(gName.Index).Value = cmbname.Text.Trim
            gridname.Rows(tempRow).Cells(gMerchant.Index).Value = cmbmerchant.Text.Trim
            gridname.Rows(tempRow).Cells(Grate.Index).Value = Val(TXTRATE.Text.Trim)

            gridDoubleClick = False
        End If
        gridname.FirstDisplayedScrollingRowIndex = gridname.RowCount - 1

        TXTRATE.Clear()
        cmbmerchant.Text = ""
        cmbname.Text = ""
        cmbname.Focus()

    End Sub

    Private Sub gridname_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridname.CellDoubleClick
        If e.RowIndex >= 0 And gridname.Item(gName.Index, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            cmbname.Text = gridname.Item(gName.Index, e.RowIndex).Value
            TXTRATE.Text = gridname.Item(Grate.Index, e.RowIndex).Value
            cmbmerchant.Text = gridname.Item(gMerchant.Index, e.RowIndex).Value
            tempRow = e.RowIndex
            cmbname.Focus()
        End If
    End Sub

    Private Sub gridname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridname.KeyDown
        If e.KeyCode = Keys.Delete Then
            gridname.Rows.RemoveAt(gridname.CurrentRow.Index)
        End If
    End Sub

    Private Sub AgentMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    Private Sub AgentMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AGENT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillcmb()
            CMBAGENT.Text = tempagentName

            If edit = True Then

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster

                dttable = objCommon.search("", "", "  ", " and ITEMMASTER.Item_cmpid = " & CmpId & " and ITEMMASTER.Item_locationid = " & Locationid & " and ITEMMASTER.Item_yearid = " & YearId)
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        tempagentId = ROW("AGENTID")
                        If ROW("NAME") <> "" Then gridname.Rows.Add(ROW("NAME"), ROW("MERCHANT"), ROW("RATE"))

                    Next
                End If


            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")
            If cmbmerchant.Text.Trim = "" Then fillname(cmbmerchant, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class