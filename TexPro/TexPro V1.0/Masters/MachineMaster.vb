
Imports BL
Imports System.Windows.Forms

Public Class MachineMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public TEMPPROCESSNAME As String           'Used for edit name
    Public tempNO As String           'Used for edit NO
    Public tempid As Integer            'Used for edit id

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If Not DUPLICATION() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBMACHINENAME.Text.Trim)
            alParaval.Add(TXTSUPPNAME.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(TXTMACNO.Text.Trim)
            alParaval.Add(TXTMANPERMAC.Text.Trim)
            alParaval.Add(TXTLABPERMAC.Text.Trim)
            alParaval.Add(TXTCOSTPERHR.Text.Trim)
            alParaval.Add(TXTCAPPERHR.Text.Trim)
            alParaval.Add(TXTPOWERPERHR.Text.Trim)
            alParaval.Add(TXTAVG.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objmachine As New ClsMachineMaster
            objmachine.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objmachine.save()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempid)
                'objCity.alParaval = alParaval
                IntResult = objmachine.Update()
                MsgBox("Details Updated")
                edit = False

            End If
            clear()
            CMBMACHINENAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean

        Dim bln As Boolean = True

        If CMBMACHINENAME.Text.Trim.Length = 0 Then
            Ep.SetError(CMBMACHINENAME, "Fill Name")
            bln = False
        End If

        If CMBPROCESS.Text.Trim.Length = 0 Then
            Ep.SetError(CMBPROCESS, "Fill PROCESS")
            bln = False
        End If

        If TXTMACNO.Text.Trim.Length = 0 Then
            Ep.SetError(TXTMACNO, "Fill NO")
            bln = False
        End If

        If TXTCOSTPERHR.Text.Trim.Length = 0 Then
            Ep.SetError(TXTCOSTPERHR, "Fill Cost / Hr")
            bln = False
        End If

        If TXTLABPERMAC.Text.Trim.Length = 0 Then
            Ep.SetError(TXTLABPERMAC, "Fill Lab / Hr")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        CMBMACHINENAME.Text = ""
        txtremarks.Clear()
        TXTSUPPNAME.Clear()
        CMBPROCESS.Text = ""
        TXTMACNO.Clear()
        TXTMANPERMAC.Clear()
        TXTLABPERMAC.Clear()
        TXTCOSTPERHR.Clear()
        TXTCAPPERHR.Clear()
        TXTPOWERPERHR.Clear()
        TXTAVG.Clear()
        CMBPROCESS.Enabled = True
    End Sub

    Private Sub CMBMACHINENAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMACHINENAME.Enter
        Try
            If CMBMACHINENAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("MACHINE_name", "", " MACHINEMASTER ", " and MACHINE_cmpid = " & CmpId & " and MACHINE_locationid = " & Locationid & " and MACHINE_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "MACHINE_name"
                    CMBMACHINENAME.DataSource = dt
                    CMBMACHINENAME.DisplayMember = "MACHINE_name"
                    CMBMACHINENAME.Text = ""
                End If
                CMBMACHINENAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmachinename_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMACHINENAME.Validating
        Try
            If Not DUPLICATION() Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function DUPLICATION() As Boolean
        Try
            Dim bln As Boolean = True
            If CMBPROCESS.Text.Trim <> "" And Val(TXTMACNO.Text.Trim) <> 0 Then
                If (edit = False) Or (edit = True And LCase(TEMPPROCESSNAME) <> LCase(CMBPROCESS.Text.Trim) And LCase(tempNO) <> LCase(TXTMACNO.Text.Trim)) Then
                    ' search duplication 
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    dt = objclscommon.search("machine_name", "", " machineMASTER INNER JOIN PROCESSMASTER ON MACHINE_PROCESSID = PROCESS_ID AND MACHINE_CMPID = PROCESS_CMPID AND MACHINE_LOCATIONID = PROCESS_LOCATIONID AND MACHINE_YEARID = PROCESS_YEARID ", " and PROCESS_name = '" & CMBPROCESS.Text.Trim & "'  and machine_NO = '" & TXTMACNO.Text.Trim & "' AND machine_CMPID=" & CmpId & " AND machine_locationID=" & Locationid & " AND machine_yearID=" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Machine with same No Already Exists in this Process", MsgBoxStyle.Critical, "")
                        bln = False
                    End If
                    pcase(CMBMACHINENAME)
                End If
            End If
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub machinemaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'fOR sAVE
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub machinemaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MACHINE MASTER'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        Me.Text = "Machine Master"

        FILLPROCESS(CMBPROCESS, " AND PROCESSMASTER.PROCESS_TYPE<>''", edit)

        If edit = True Then

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster
            dttable = objCommon.search("    MACHINEMASTER.MACHINE_name, MACHINEMASTER.MACHINE_SUPPNAME, PROCESSMASTER.PROCESS_NAME, MACHINEMASTER.MACHINE_no, MACHINEMASTER.MACHINE_manpermac, MACHINEMASTER.MACHINE_labpermac, MACHINEMASTER.MACHINE_costperhr, MACHINEMASTER.MACHINE_capperhr, MACHINEMASTER.MACHINE_powerperhr, MachineMaster.MACHINE_avgperhr, MachineMaster.MACHINE_remarks ", "", "    MACHINEMASTER INNER JOIN PROCESSMASTER ON MACHINEMASTER.MACHINE_processid = PROCESSMASTER.PROCESS_ID AND MACHINEMASTER.MACHINE_cmpid = PROCESSMASTER.PROCESS_CMPID AND  MACHINEMASTER.MACHINE_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND MACHINEMASTER.MACHINE_yearid = PROCESSMASTER.PROCESS_YEARID ", " and machine_id = " & tempid & " AND machine_CMPID=" & CmpId & " AND machine_locationID=" & Locationid & " AND machine_yearID=" & YearId)

            If dttable.Rows.Count > 0 Then
                CMBMACHINENAME.Text = dttable.Rows(0).Item(0).ToString
                TXTSUPPNAME.Text = dttable.Rows(0).Item(1).ToString
                CMBPROCESS.Text = dttable.Rows(0).Item(2).ToString
                TEMPPROCESSNAME = CMBPROCESS.Text.Trim
                TXTMACNO.Text = dttable.Rows(0).Item(3).ToString
                TXTMANPERMAC.Text = dttable.Rows(0).Item(4).ToString
                TXTLABPERMAC.Text = dttable.Rows(0).Item(5).ToString
                TXTCOSTPERHR.Text = dttable.Rows(0).Item(6).ToString
                TXTCAPPERHR.Text = dttable.Rows(0).Item(7).ToString
                TXTPOWERPERHR.Text = dttable.Rows(0).Item(8).ToString
                TXTAVG.Text = dttable.Rows(0).Item(9).ToString
                txtremarks.Text = dttable.Rows(0).Item(10).ToString

                CMBPROCESS.Enabled = False
            End If
        End If

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete machine Permanently?", MsgBoxStyle.YesNo, "TEX PRO")
                If tempmsg = vbYes Then

                    Dim OBJmachine As New ClsmachineMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(CMBMACHINENAME.Text.Trim)
                    ALPARAVAL.Add(TXTMACNO.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJmachine.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJmachine.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS, " AND PROCESSMASTER.PROCESS_TYPE<>''", edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAVG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAVG.KeyPress
        Try
            numdotkeypress(e, TXTAVG, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCAPPERHR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCAPPERHR.KeyPress
        Try
            numdotkeypress(e, TXTCAPPERHR, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOSTPERHR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOSTPERHR.KeyPress
        Try
            numdotkeypress(e, TXTCOSTPERHR, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLABPERMAC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLABPERMAC.KeyPress
        Try
            numdotkeypress(e, TXTLABPERMAC, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMACNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMACNO.KeyPress
        Try
            numkeypress(e, TXTMACNO, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMANPERMAC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMANPERMAC.KeyPress
        Try
            numkeypress(e, TXTMANPERMAC, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPOWERPERHR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPOWERPERHR.KeyPress
        Try
            numdotkeypress(e, TXTPOWERPERHR, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMACNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMACNO.Validating
        Try
            If Not DUPLICATION() Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class