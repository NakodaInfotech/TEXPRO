
Imports BL

Public Class ExciseMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean           'Used for edit
    Public tempexciseName As String
    Public tempexciseId As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill name Name")
            bln = False
        End If

        If txtedu.Text.Trim.Length = 0 Then
            Ep.SetError(txtedu, "Fill edu excise")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtedu.Text.Trim)
            alParaval.Add(txthse.Text.Trim)
            alParaval.Add(dtpwef.Value)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            Dim objclsexciseMaster As New ClsexciseMaster
            objclsexciseMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsexciseMaster.save()
                MsgBox("Details Added")
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempexciseId)
                IntResult = objclsexciseMaster.Update()
                MsgBox("Details Updated")

            End If
            edit = False
            clear()
            txtname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        txtedu.Clear()
        txtname.Clear()
        txthse.Clear()
        dtpwef.Value = Mydate
        txtremarks.Clear()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(tempexciseName) <> LCase(txtname.Text.Trim)) Then
                dt = objclscommon.search("excise_name", "", "exciseMaster", " and excise_name= '" & txtname.Text.Trim & "' and excise_cmpid = " & CmpId & " and excise_locationid = " & Locationid & " and excise_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("name Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                    e.Cancel = True
                End If
            End If
            pcase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub exciseMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub exciseMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'TAX MASTER'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If edit = True Then

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster
            dttable = objCommon.search(" excise_name, excise_edu,excise_hse,excise_wef, excise_remarks", "", "exciseMaster", " and excise_id = " & tempexciseId & " and excise_cmpid = " & CmpId & " and excise_locationid = " & Locationid & " and excise_yearid = " & YearId)
            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0)
                txtedu.Text = dttable.Rows(0).Item(1)
                txthse.Text = dttable.Rows(0).Item(2)
                dtpwef.Value = dttable.Rows(0).Item(3)
                txtremarks.Text = dttable.Rows(0).Item(4)
            End If
        End If
    End Sub

    Private Sub txtedu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtedu.KeyPress
        numdotkeypress(e, txtedu, Me)
    End Sub

    Private Sub txthse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthse.KeyPress
        numdotkeypress(e, txthse, Me)
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
End Class