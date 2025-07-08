
Imports BL

Public Class ColorRateMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub TXTCOLOR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOLOR.KeyPress
        numkeypress(e, TXTCOLOR, Me)
    End Sub

    Private Sub TXTCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOLOR.Validating
        Try
            If Val(TXTCOLOR.Text.Trim) <> 0 And CMBPROCESS.Text.Trim <> "" Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TempName) <> LCase(TXTCOLOR.Text.Trim)) Then
                    dt = objclscommon.search("CR_NO AS COLOR", "", "COLORRATEMASTER LEFT OUTER JOIN PROCESSMASTER ON CR_PROCESSID = PROCESS_ID", " and CR_NO= " & Val(TXTCOLOR.Text.Trim) & " and PROCESS_NAME = '" & CMBPROCESS.Text.Trim & "' and CR_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Color Already Exists In This Process", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                End If
            End If
            pcase(TXTRATE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(Val(TXTCOLOR.Text.Trim))
            alParaval.Add(Val(TXTRATE.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            
            Dim OBJCOLOR As New ClsColorRateMaster
            OBJCOLOR.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJCOLOR.SAVE()
                MsgBox("Details Added")
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TempID)
                IntResult = OBJCOLOR.UPDATE()
                MsgBox("Details Updated")
                edit = False

            End If
            clear()
            TXTCOLOR.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True
        If CMBPROCESS.Text.Trim = "" Then
            EP.SetError(CMBPROCESS, "Select Process")
            bln = False
        End If
        If Val(TXTCOLOR.Text.Trim) = 0 Then
            EP.SetError(TXTCOLOR, "Enter Color")
            bln = False
        End If
        If Val(TXTRATE.Text.Trim) = 0 Then
            EP.SetError(TXTRATE, "Enter Rate")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        TXTRATE.Clear()
        TXTCOLOR.Clear()
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If edit = False Then

                If MsgBox("Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJCOLOR As New ClsColorRateMaster
                OBJCOLOR.alParaval.Add(TempID)
                OBJCOLOR.alParaval.Add(YearId)
                OBJCOLOR.DELETE()
                MsgBox("Entry Deleted Successfully", MsgBoxStyle.Critical)
                edit = False
                clear()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ColorRateMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub ColorRateMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS, "", False)

            If edit = True Then
                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search(" CR_NO AS COLOR, CR_RATE AS RATE, ISNULL(PROCESS_NAME,'') AS PROCESS", "", "COLORRATEMASTER  LEFT OUTER JOIN PROCESSMASTER ON CR_PROCESSID = PROCESS_ID", " and CR_id = " & TempID & " and CR_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TXTCOLOR.Text = Val(dttable.Rows(0).Item("COLOR"))
                    TXTRATE.Text = Val(dttable.Rows(0).Item("RATE"))
                    CMBPROCESS.Text = dttable.Rows(0).Item("PROCESS")
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class