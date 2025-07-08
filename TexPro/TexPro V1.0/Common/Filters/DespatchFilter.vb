
Imports BL

Public Class DespatchFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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

    Sub fillcmb()
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
            fillname(CMBTRANSPORT, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StoreStockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcmb()
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            If CHKGRID.CheckState = CheckState.Unchecked Then

                Dim objwo As New GDNDESIGN
                objwo.MdiParent = MDIMain
                objwo.FORMULA = "1=1"
                If cmbmerchant.Text <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.merchant}='" & cmbmerchant.Text & "'"
                If CMBCITY.Text <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.CITYNAME}='" & CMBCITY.Text.Trim & "'"
                If TXTMERCHANT.Text <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.merchant} LIKE '*" & TXTMERCHANT.Text & "*'"
                If cmbname.Text <> "" Then
                    objwo.FORMULA = objwo.FORMULA & " and {gdn.partyname}='" & cmbname.Text & "'"
                    objwo.period = UCase(cmbname.Text.Trim) & "  "
                End If
                If chkdate.Checked = True Then
                    getFromToDate()
                    objwo.FORMULA = objwo.FORMULA & " and ({gdn.gdndate} in date " & fromD & " to date " & toD & ")"
                    objwo.period = objwo.period & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                Else
                    objwo.period = objwo.period & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If
                If CMBTRANSPORT.Text <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.TRANSNAME}='" & CMBTRANSPORT.Text & "'"

                objwo.FORMULA = objwo.FORMULA & " and {gdn.cmpid}=" & CmpId & " and {gdn.locationid}=" & Locationid & " and {gdn.yearid}=" & YearId

                If RBTRANSPORT.Checked = True Then
                    objwo.FRMSTRING = "GDNTRANSPORT"
                ElseIf rdbdetail.Checked = True And (cmbgroupby.Text = "" Or cmbgroupby.Text = "Despatch No.") Then
                    objwo.FRMSTRING = "GDNDETAIL"
                ElseIf RBCITY.Checked = True Then
                    objwo.FRMSTRING = "GDNCITY"
                ElseIf rdbdetail.Checked = False And (cmbgroupby.Text = "" Or cmbgroupby.Text = "Despatch No.") Then
                    objwo.FRMSTRING = "GDNSUMMARY"
                ElseIf rdbdetail.Checked = True And cmbgroupby.Text = "Customer" Then
                    objwo.FRMSTRING = "GDNPARTYDETAIL"
                ElseIf rdbdetail.Checked = False And cmbgroupby.Text = "Customer" Then
                    objwo.FRMSTRING = "GDNPARTYSUMMARY"
                ElseIf rdbdetail.Checked = True And cmbgroupby.Text = "Merchant" Then
                    objwo.FRMSTRING = "GDNITEMDETAIL"
                ElseIf rdbdetail.Checked = False And cmbgroupby.Text = "Merchant" Then
                    objwo.FRMSTRING = "GDNITEMSUMMARY"
                End If
                objwo.Show()

            Else

                Dim WHERE As String = " AND 1 = 1 "
                If cmbname.Text.Trim <> "" Then WHERE = WHERE & " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "'"
                If cmbmerchant.Text.Trim <> "" Then WHERE = WHERE & " AND ITEM_NAME = '" & cmbmerchant.Text.Trim & "'"
                If TXTMERCHANT.Text <> "" Then WHERE = WHERE & " AND ITEM_NAME LIKE '" & TXTMERCHANT.Text & "'"
                If TXTBALENO.Text.Trim <> "" Then WHERE = WHERE & " AND GDN_PSDESC.GDN_PSNO = " & TXTBALENO.Text.Trim
                If CMBCITY.Text.Trim <> "" Then WHERE = WHERE & " AND CITY_NAME = '" & CMBCITY.Text.Trim & "'"
                If CMBTRANSPORT.Text.Trim <> "" Then WHERE = WHERE & " AND TRANSPORTLEDGERS.Acc_cmpname = '" & CMBTRANSPORT.Text.Trim & "'"
                If RBPENDINGLR.Checked = True Then WHERE = WHERE & " AND ISNULL(GDN_PSDESC.GDN_LRNO,'') = ''"
                getFromToDate()
                If chkdate.Checked = True Then WHERE = WHERE & " and GDN.GDN_date >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and GDN.GDN_date <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

                'SHOW IN GRID
                Dim OBJGDN As New GDNDetailsReport
                OBJGDN.MdiParent = MdiParent
                OBJGDN.WHERE = WHERE
                OBJGDN.Show()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCITY.Enter
        Try
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORT.Enter
        Try
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, False, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORT.Validating
        Try
            If CMBTRANSPORT.Text.Trim <> "" Then namevalidate(CMBTRANSPORT, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class