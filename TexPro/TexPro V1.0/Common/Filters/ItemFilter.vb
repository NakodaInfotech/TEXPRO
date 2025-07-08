
Public Class ItemFilter

    Private Sub ItemFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click

        Dim objwo As New ItemReport
        objwo.MdiParent = MDIMain
        objwo.selfor_ss = "1=1"

        If rdbItem.Checked = True Then objwo.selfor_ss = objwo.selfor_ss & " and ITEMMASTER.item_name ='" & cmbitemname.Text & "'"
        If rdbPartyWise.Checked = True Then objwo.selfor_ss = objwo.selfor_ss & " and LEDGERS.Acc_CMPname='" & cmbname.Text & "'"
        If cmbitemname.Text = "" And cmbname.Text = "" Then objwo.selfor_ss = "1=1"
        If CMBCATEGORY.Text.Trim <> "" Then objwo.selfor_ss = objwo.selfor_ss & " AND CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' "

        If chkdate.Checked = True Then
            objwo.selfor_ss = objwo.selfor_ss & " and GRN.grn_date BETWEEN '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
        Else
            objwo.selfor_ss = objwo.selfor_ss & " and GRN.grn_date BETWEEN '" & Format(AccFrom, "MM/dd/yyyy") & "' and '" & Format(AccTo, "MM/dd/yyyy") & "'"
        End If
        objwo.Show()

    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class