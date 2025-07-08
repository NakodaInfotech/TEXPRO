
Imports System.ComponentModel
Imports BL

Public Class StoreInFilter

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
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreInFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreInFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJGRN As New GRNReportDesign
            OBJGRN.MdiParent = MDIMain
            OBJGRN.selfor_ss = " {GRN.GRN_TYPE} = 'Inwards' AND {GRN.GRN_YEARID} = " & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
                OBJGRN.TODATE = Format(dtto.Value, "MM/dd/yyyy")
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJGRN.selfor_ss = OBJGRN.selfor_ss & " and {@DATE} in date " & fromD & " to date " & toD & ""
            End If
            If cmbname.Text <> "" Then OBJGRN.selfor_ss = OBJGRN.selfor_ss & " and {LEDGERS.ACC_CMPNAME}='" & cmbname.Text & "'"
            If cmbitemname.Text <> "" Then OBJGRN.selfor_ss = OBJGRN.selfor_ss & " and {ITEMMASTER.ITEM_NAME}='" & cmbitemname.Text.Trim & "'"
            If TXTITEMLIKE.Text <> "" Then OBJGRN.selfor_ss = OBJGRN.selfor_ss & " and {ITEMMASTER.ITEM_NAME} LIKE '*" & TXTITEMLIKE.Text & "*'"

            If RDBDETAILS.Checked = True Then
                OBJGRN.FRMSTRING = "STOREDETAILS"
            ElseIf RDBITEM.Checked = True Then
                OBJGRN.FRMSTRING = "STOREITEM"
            ElseIf RDBPARTY.Checked = True Then
                OBJGRN.FRMSTRING = "STOREPARTY"
            End If

            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(sender As Object, e As CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class