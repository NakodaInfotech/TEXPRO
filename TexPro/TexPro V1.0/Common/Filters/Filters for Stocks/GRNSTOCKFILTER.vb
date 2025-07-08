Imports System.ComponentModel

Public Class GRNSTOCKFILTER
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub Filter_for_Stock_Party_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdshowreport_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try

            Dim formula As String = ""

            Dim objstock As New GRNDETAILDESIGN
            objstock.MdiParent = MDIMain
            objstock.SHOWOURQUALITY = CHKOURQUALITY.Checked

            If RDBSTOCKWITHPO.Checked = True Or RDBSTOCKWITHPODETAILS.Checked = True Then
                formula = " {GREYSTOCKWITHPO.YEARID}= " & YearId
                If cmbQuality.Text.Trim <> "" Then formula = formula & " and {GREYSTOCKWITHPO.QUALITYNAME}='" & cmbQuality.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then formula = formula & " and {GREYSTOCKWITHPO.QUALITYCATEGORY}='" & CMBCATEGORY.Text.Trim & "'"
                objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                objstock.selfor_GRN = formula
                If RDBSTOCKWITHPO.Checked = True Then objstock.FRMSTRING = "GREYSTOCKWITHPO" Else objstock.FRMSTRING = "GREYSTOCKWITHPODETAILS"
                objstock.Show()
                Exit Sub
            End If


            If cmbtype.Text = "UnChecked" Or cmbtype.Text = "Total Mtrs" Then
                formula = " {grn_VIEW.YEARID}= " & YearId

                If cmbQuality.Text.Trim <> "" Then formula = formula & " and {grn_VIEW.Quality}='" & cmbQuality.Text.Trim & "'"
                If cmbname.Text.Trim <> "" Then formula = formula & " and {grn_VIEW.name}='" & cmbname.Text.Trim & "'"
                If CMBGODOWN.Text.Trim <> "" Then formula = formula & " and {grn_VIEW.GODOWN}='" & CMBGODOWN.Text.Trim & "'"

                If chkdate.Checked = True Then
                    getFromToDate()
                Else
                    dtfrom.Value = AccFrom.Date
                    dtto.Value = AccTo.Date
                    getFromToDate()
                End If

                If cmbtype.Text = "UnChecked" Then
                    If rdbmonthly.Checked = False Then formula = formula & " AND  (({GRN_VIEW.CHECKDONE} = 'A' AND {@DATE} in date " & fromD & " to date " & toD & ") OR ({GRN_VIEW.CHECKDONE} = 'B' AND {@DATE} > #" & Format(dtto.Value.Date, "MM/dd/yyyy") & "# )) " Else formula = formula & " AND  {@CHECKDATE} in date " & fromD & " to date " & toD & ""
                Else
                    formula = formula & " and {grn_VIEW.date} in date " & fromD & " to date " & toD & ""
                End If



                If CHKVALUE.CheckState = CheckState.Unchecked Then
                    If rdbdetail.Checked = True Then
                        objstock.FRMSTRING = "GREYUNCHK"
                    ElseIf rdbsummary.Checked = True Then
                        objstock.FRMSTRING = "GREYUNCHKSUMMARY"
                    ElseIf rdbmonthly.Checked = True Then
                        If cmbtype.Text.Trim = "UnChecked" Then formula = formula & " and {grn_VIEW.CHECKMTRS}=0"
                        If cmbname.Text.Trim <> "" Then
                            objstock.FRMSTRING = "PARTYMONTHLY"
                        Else
                            objstock.FRMSTRING = "MONTHLY"
                        End If
                    End If
                Else
                    If rdbdetail.Checked = True Then
                        objstock.FRMSTRING = "GREYUNCHKVALUE"
                    ElseIf rdbsummary.Checked = True Then
                        objstock.FRMSTRING = "GREYUNCHKSUMMARYVALUE"
                    ElseIf rdbmonthly.Checked = True Then
                        If cmbtype.Text.Trim = "UnChecked" Then formula = formula & " and {grn_VIEW.CHECKMTRS}=0"
                        If cmbname.Text.Trim <> "" Then
                            objstock.FRMSTRING = "PARTYMONTHLY"
                        Else
                            objstock.FRMSTRING = "MONTHLY"
                        End If
                    End If
                End If
                objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")

            ElseIf cmbtype.Text = "All" Then

                formula = " {CHECKINGALL_GRN_VIEW.CMPID}= " & CmpId & " and {CHECKINGALL_GRN_VIEW.LOCATIONID}= " & Locationid & " and {CHECKINGALL_GRN_VIEW.YEARID}= " & YearId

                If cmbQuality.Text.Trim <> "" Then
                    formula = formula & " and {CHECKINGALL_GRN_VIEW.Quality}='" & cmbQuality.Text.Trim & "'"
                End If
                If cmbname.Text.Trim <> "" Then
                    formula = formula & " and {CHECKINGALL_GRN_VIEW.name}='" & cmbname.Text.Trim & "'"
                End If

                If chkdate.Checked = True Then
                    getFromToDate()
                    If cmbtype.Text = "All" Then formula = formula
                    formula = formula & " and {CHECKINGALL_GRN_VIEW.date} in date " & fromD & " to date " & toD & ""
                End If
                If rdbdetail.Checked = True Then
                    objstock.FRMSTRING = "CHECKINGALLGRN"
                ElseIf rdbmonthly.Checked = True Then

                    If cmbtype.Text.Trim = "ALL" Then formula = formula
                    If cmbname.Text.Trim <> "" Then
                        objstock.FRMSTRING = "CHECKINGMONTHLY"
                    Else
                        objstock.FRMSTRING = "MONTHLY"
                    End If

                End If
                objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")

            ElseIf cmbtype.Text.Trim = "Checked" Then
                formula = " {CHECK_VIEW.CMPID}= " & CmpId & " and {CHECK_VIEW.LOCATIONID}= " & Locationid & " and {CHECK_VIEW.YEARID}= " & YearId

                If cmbQuality.Text.Trim <> "" Then formula = formula & " and {CHECK_VIEW.Quality}='" & cmbQuality.Text.Trim & "'"
                If CMBGODOWN.Text.Trim <> "" Then formula = formula & " and {CHECK_VIEW.GODOWN}='" & CMBGODOWN.Text.Trim & "'"
                If cmbname.Text.Trim <> "" Then
                    If ClientName = "TULSI" Or ClientName = "SHREENATH" Then formula = formula & " and {CHECK_VIEW.name}='" & cmbname.Text.Trim & "'" Else formula = formula & " and {CHECK_VIEW.LEDGERNAME}='" & cmbname.Text.Trim & "'"
                End If
                If chkdate.Checked = True Then
                    getFromToDate()
                    formula = formula & " and {@DATE} in date " & fromD & " to date " & toD & ""
                    objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                Else
                    objstock.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If

                If CHKVALUE.CheckState = CheckState.Unchecked Then
                    If rdbdetail.Checked = True Then
                        objstock.FRMSTRING = "GREYCHK"
                    ElseIf rdbsummary.Checked = True Then
                        objstock.FRMSTRING = "GREYCHKSUMMARY"
                    ElseIf rdbmonthly.Checked = True Then
                        formula = Replace(formula, "CHECK_VIEW", "grn_VIEW")
                        formula = Replace(formula, "grn_VIEW.date", "grn_VIEW.checkdate")
                        formula = formula & " and {grn_VIEW.CHECKMTRS}>0"
                        If cmbname.Text.Trim <> "" Then
                            objstock.FRMSTRING = "PARTYMONTHLY"
                        Else
                            objstock.FRMSTRING = "MONTHLY"
                        End If
                    End If
                Else
                    If rdbdetail.Checked = True Then
                        objstock.FRMSTRING = "GREYCHKVALUE"
                    ElseIf rdbsummary.Checked = True Then
                        objstock.FRMSTRING = "GREYCHKSUMMARYVALUE"
                    ElseIf rdbmonthly.Checked = True Then
                        formula = Replace(formula, "CHECK_VIEW", "grn_VIEW")
                        formula = Replace(formula, "grn_VIEW.date", "grn_VIEW.checkdate")
                        formula = formula & " and {grn_VIEW.CHECKMTRS}>0"
                        If cmbname.Text.Trim <> "" Then
                            objstock.FRMSTRING = "PARTYMONTHLY"
                        Else
                            objstock.FRMSTRING = "MONTHLY"
                        End If
                    End If
                End If

            End If
            objstock.selfor_GRN = formula


            objstock.Show()


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Filter_for_Stock_Party_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcombos()
            cmbtype.SelectedIndex = (0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False)
            If cmbQuality.Text.Trim = "" Then fillQUALITY(cmbQuality, False)
            If CMBGODOWN.Text.Trim = "" Then FILLGODOWN(CMBGODOWN, False)
            fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(sender As Object, e As EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class