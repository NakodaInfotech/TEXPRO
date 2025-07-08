
Imports System.ComponentModel
Imports BL

Public Class ContractorWorkerRate

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public EDIT As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub TXTWORKER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWORKER.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTWORKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTWORKER.Validating
        Try
            If Val(TXTWORKER.Text.Trim) <> 0 And CMBPROCESS.Text.Trim <> "" Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TempName) <> LCase(TXTWORKER.Text.Trim)) Then
                    dt = objclscommon.search("CR_WORKER AS WORKER", "", "ContractorWorkerRate LEFT OUTER JOIN PROCESSMASTER ON CR_PROCESSID = PROCESS_ID  LEFT OUTER JOIN CONTRACTORMASTER ON CR_CONTRACTORID= CONTRACTOR_ID", " and CR_WORKER = " & Val(TXTWORKER.Text.Trim) & " and PROCESS_NAME = '" & CMBPROCESS.Text.Trim & "'  and CONTRACTOR_NAME = '" & CMBCONTRACTOR.Text.Trim & "' and CR_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Worker Rate Already Exists In This Process", MsgBoxStyle.Critical, "Tex Pro")
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
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(CMBCONTRACTOR.Text.Trim)
            alParaval.Add(Val(TXTWORKER.Text.Trim))
            alParaval.Add(Val(TXTRATE.Text.Trim))
            alParaval.Add(Val(TXTDAYRATE.Text.Trim))
            alParaval.Add(Val(TXTNIGHTRATE.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim OBJWORKER As New ClsContractorWorkerRate
            OBJWORKER.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJWORKER.SAVE()
                MsgBox("Details Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TempID)
                IntResult = OBJWORKER.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            clear()
            TXTWORKER.Focus()
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
        If CMBCONTRACTOR.Text.Trim = "" Then
            EP.SetError(CMBCONTRACTOR, "Select Contractor")
            bln = False
        End If

        If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
            If Val(TXTWORKER.Text.Trim) = 0 Then
                EP.SetError(TXTWORKER, "Enter Worker")
                bln = False
            End If
            If Val(TXTRATE.Text.Trim) = 0 Then
                EP.SetError(TXTRATE, "Enter Rate")
                bln = False
            End If
        Else
            If Val(TXTDAYRATE.Text.Trim) = 0 Then
                EP.SetError(TXTDAYRATE, "Enter Day Rate")
                bln = False
            End If
            If Val(TXTNIGHTRATE.Text.Trim) = 0 Then
                EP.SetError(TXTNIGHTRATE, "Enter Night Rate")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub clear()
        CMBCONTRACTOR.Text = ""
        TXTRATE.Clear()
        TXTWORKER.Clear()
        TXTDAYRATE.Clear()
        TXTNIGHTRATE.Clear()
    End Sub

    Private Sub ContractorWorkerRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub ContractorWorkerRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            If CMBCONTRACTOR.Text.Trim = "" Then fillCONTRACTOR(CMBCONTRACTOR)

            If edit = True Then
                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search(" CR_WORKER AS WORKER, CR_RATE AS RATE, CR_DAYRATE AS DAYRATE, CR_NIGHTRATE AS NIGHTRATE, ISNULL(PROCESS_NAME,'') AS PROCESS, ISNULL(CONTRACTORMASTER.CONTRACTOR_NAME,'') AS CONTRACTOR", "", "ContractorWorkerRate  LEFT OUTER JOIN PROCESSMASTER ON CR_PROCESSID = PROCESS_ID LEFT OUTER JOIN CONTRACTORMASTER ON CR_CONTRACTORID= CONTRACTOR_ID", " and CR_id = " & TempID & " and CR_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TXTWORKER.Text = Val(dttable.Rows(0).Item("WORKER"))
                    TXTRATE.Text = Val(dttable.Rows(0).Item("RATE"))
                    CMBPROCESS.Text = dttable.Rows(0).Item("PROCESS")
                    CMBCONTRACTOR.Text = dttable.Rows(0).Item("CONTRACTOR")
                    TXTDAYRATE.Text = Val(dttable.Rows(0).Item("DAYRATE"))
                    TXTNIGHTRATE.Text = Val(dttable.Rows(0).Item("NIGHTRATE"))
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = False Then

                If MsgBox("Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJRATE As New ClsContractorWorkerRate
                OBJRATE.alParaval.Add(TempID)
                OBJRATE.alParaval.Add(YearId)
                OBJRATE.DELETE()
                MsgBox("Entry Deleted Successfully", MsgBoxStyle.Critical)
                EDIT = False
                clear()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTDAYRATE.KeyPress, TXTNIGHTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBCONTRACTOR_Enter(sender As Object, e As EventArgs) Handles CMBCONTRACTOR.Enter
        Try
            If CMBCONTRACTOR.Text.Trim = "" Then fillCONTRACTOR(CMBCONTRACTOR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCONTRACTOR_Validating(sender As Object, e As CancelEventArgs) Handles CMBCONTRACTOR.Validating
        Try
            If CMBCONTRACTOR.Text.Trim <> "" Then CONTRACTORvalidate(CMBCONTRACTOR, e, Me)


            If CMBCONTRACTOR.Text.Trim <> "" And CMBPROCESS.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TempName) <> LCase(CMBCONTRACTOR.Text.Trim)) Then
                    dt = objclscommon.search("CR_DAYRATE AS DAYRATE", "", "ContractorWorkerRate LEFT OUTER JOIN PROCESSMASTER ON CR_PROCESSID = PROCESS_ID  LEFT OUTER JOIN CONTRACTORMASTER ON CR_CONTRACTORID= CONTRACTOR_ID", " and PROCESS_NAME = '" & CMBPROCESS.Text.Trim & "'  and CONTRACTOR_NAME = '" & CMBCONTRACTOR.Text.Trim & "' and CR_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Rate Already Exists For This Contractor", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContractorWorkerRate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                LBLWORKER.Visible = True
                TXTWORKER.Visible = True
                LBLRATE.Visible = True
                TXTRATE.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class