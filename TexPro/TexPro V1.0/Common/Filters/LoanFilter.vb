
Imports BL

Public Class LoanFilter

    Dim edit, summary As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub FILLCMB()
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEM_FRMSTRING = 'ITEM'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoanFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOW REPORT
                Call cmdshow_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoanFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJLOAN As New LoanDesign
            OBJLOAN.MdiParent = MDIMain
            OBJLOAN.selfor_po = "1=1 and {LOANVIEW.YEARID}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJLOAN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJLOAN.selfor_po = OBJLOAN.selfor_po & " and {LOANVIEW.DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJLOAN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If cmbname.Text.Trim <> "" Then OBJLOAN.selfor_po = OBJLOAN.selfor_po & " and {LOANVIEW.NAME}='" & cmbname.Text & "'"
            If cmbitemname.Text.Trim <> "" Then OBJLOAN.selfor_po = OBJLOAN.selfor_po & " and {LOANVIEW.ITEMNAME}='" & cmbitemname.Text.Trim & "'"
            If CHKBALANCE.CheckState = CheckState.Checked Then OBJLOAN.SHOWALL = 1

            If RDBPARTY.Checked = True Then
                OBJLOAN.FRMSTRING = "LOANPARTY"
            ElseIf RDBITEM.Checked = True Then
                OBJLOAN.FRMSTRING = "LOANITEM"
            End If

            OBJLOAN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class