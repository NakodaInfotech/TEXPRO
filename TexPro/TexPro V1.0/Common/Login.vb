Imports BL

Public Class Login

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        End
    End Sub

    Sub CHECKVERSION()

        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable

            DT = OBJCMN.Execute_Any_String(" SELECT VERSION_NO AS VERSION, VERSION_CLIENTNAME AS CLIENTNAME, VERSION_REPORTTYPE AS REPORTTYPE, ISNULL(VERSION_MANUALLOTNO,0) AS MANUALLOTNO, ISNULL(VERSION_MANUALINVNO,0) AS MANUALINVNO, ISNULL(VERSION_ALLOWEWAYBILL,0) AS ALLOWEWAYBILL, ISNULL(VERSION_PRINTEWAYBILL,0) AS PRINTEWAYBILL, ISNULL(VERSION_ALLOWEINVOICE,0) AS ALLOWEINVOICE FROM VERSION ", "", "")
            If DT.Rows.Count > 0 Then
                ClientName = DT.Rows(0).Item("CLIENTNAME")
                ALLOWMANUALLOTNO = Convert.ToBoolean(DT.Rows(0).Item("MANUALLOTNO"))
                ALLOWMANUALINVNO = Convert.ToBoolean(DT.Rows(0).Item("MANUALINVNO"))
                ALLOWEWAYBILL = Convert.ToBoolean(DT.Rows(0).Item("ALLOWEWAYBILL"))
                PRINTEWAYBILL = Convert.ToBoolean(DT.Rows(0).Item("PRINTEWAYBILL"))
                ALLOWEINVOICE = Convert.ToBoolean(DT.Rows(0).Item("ALLOWEINVOICE"))


                If ClientName = "DHANLAXMI" Then
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "MONOGRAM" Then
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "SHUBHLAXMI" Then
                    If Now.Date > DateTime.Parse("15.07.2025 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "TULSI" Then
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                ElseIf ClientName = "SHREENATH" Then
                    If Now.Date > DateTime.Parse("15.04.2026 00:00") Then
                        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_NO='1.0.0000'", "", "")
                        GoTo LINE1
                    End If
                Else
                    GoTo LINE1
                End If

                If DT.Rows(0).Item("VERSION") <> "1.0.036" Then
                    MsgBox("Please Install New Version", MsgBoxStyle.Critical)
LINE1:
                    MsgBox(" VERSION EXPIRED PLEASE CONTACT NAKODA INFOTECH ON +9987603607", MsgBoxStyle.Critical)
                    End
                End If

            Else
                'IF CLIENTNAME IS NOT PRESENT
                End
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            CHECKVERSION()
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            Dim objlogin As New clsLogin
            UserName = txtusername.Text.Trim
            Mydate = Format(objlogin.getdate(), "dd/MM/yyyy")
            Cmpdetails.Show()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then
                Throw ex
            End If
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtusername.Text.Trim.Length = 0 Then
            Ep.SetError(txtusername, "Fill User Name")
            bln = False
        End If

        If txtpassword.Text.Trim.Length = 0 Then
            Ep.SetError(txtpassword, "Fill Password")
            bln = False
        End If

        Dim objcmn As New ClsCommon
        Dim dt As DataTable = objcmn.Execute_Any_String(" SELECT User_id, User_password FROM UserMaster WHERE user_namE= '" & txtusername.Text.Trim & "'", "", "")
        If dt.Rows.Count > 0 Then
            For Each DTROW As DataRow In dt.Rows
                If txtpassword.Text.Trim <> DTROW(1).ToString Then
                    bln = False
                Else
                    Userid = DTROW(0)
                    bln = True
                    Exit For
                End If
            Next
        Else
            Ep.SetError(txtusername, "Invalid User")
            bln = False
        End If
        If bln = False Then Ep.SetError(txtpassword, "Incorrect Password")

        Return bln
    End Function

    Private Sub txtusername_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtusername.Validated
        txtusername.Text = StrConv(txtusername.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub Login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.L Then       'for Login
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            End
        ElseIf e.KeyCode = Windows.Forms.Keys.Enter Then
            'SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtusername.Text.Trim <> "" And txtpassword.Text.Trim <> "" Then Call cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Login_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
