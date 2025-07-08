
Imports BL

Public Class PriceListFilter
    Private Sub PriceListFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        fillcmb()
    End Sub


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJPL As New PriceListDesign
            OBJPL.MdiParent = MDIMain
            OBJPL.WHERECLAUSE = " {LEDGERS.ACC_YEARID} = " & YearId
            If cmbname.Text.Trim <> "" Then OBJPL.WHERECLAUSE = OBJPL.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME} ='" & cmbname.Text & "'"
            If cmbitemname.Text <> "" Then OBJPL.WHERECLAUSE = OBJPL.WHERECLAUSE & " AND {ITEMMASTER.ITEM_NAME} = '" & cmbitemname.Text.Trim & "'"
            OBJPL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class