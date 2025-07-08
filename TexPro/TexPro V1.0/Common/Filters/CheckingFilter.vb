
Imports BL

Public Class CheckingFilter

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
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GRNFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLCMB()
            If RDBPARTYSUMRY.Checked = True Then TXTTEMP.Text = "PARTYWISESUMMARY"
            If RDBQUALITYSUMRY.Checked = True Then TXTTEMP.Text = "QUALITYWISESUMMARY"
            If RDBPARTYWISEDETAIL.Checked = True Then TXTTEMP.Text = "PARTYWISEDETAIL"
            If RDBMONTHSUMRY.Checked = True Then TXTTEMP.Text = "MONTHWISESUMMARY"
            If RDBCHKSUMRY.Checked = True Then TXTTEMP.Text = "CHECKSUMMARY"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillQUALITY()
        Try
            If CMBQUALITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DISTINCT QUALITY ", "", " CHECKING_OPENING_VIEW ", " AND CHECKING_OPENING_VIEW.cmpid = " & CmpId & " AND CHECKING_OPENING_VIEW.LOCATIONID = " & Locationid & " AND CHECKING_OPENING_VIEW.YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "QUALITY"
                    CMBQUALITY.DataSource = dt
                    CMBQUALITY.DisplayMember = "QUALITY"
                    CMBQUALITY.Text = ""
                End If
                CMBQUALITY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim ObjGRN As New GRNReportDesign
            ObjGRN.MdiParent = MDIMain
            ObjGRN.selfor_ss = "1=1"
            getFromToDate()

            If chkdate.Checked = True Then
                ObjGRN.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
                ObjGRN.TODATE = Format(dtto.Value, "MM/dd/yyyy")
                ObjGRN.PERIOD = "CHECKING REPORT - " & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                ObjGRN.FROMDATE = Format(AccFrom, "MM/dd/yyyy")
                ObjGRN.TODATE = Format(AccTo, "MM/dd/yyyy")
                ObjGRN.PERIOD = "CHECKING REPORT - " & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If


            If RDBDTLS.Checked = True Then
                ObjGRN.FRMSTRING = "CHECKDETAILS"
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKINGMASTER.CHECK_YEARID}=" & YearId & " and {@CHECKDATE} in date " & fromD & " to date " & toD & ""
                ObjGRN.MdiParent = MDIMain
                ObjGRN.Show()
                Exit Sub
            End If

            If RDBMONTHSUMRY.Checked = True Then
                If chkdate.CheckState = CheckState.Checked Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {@GRNDATE} in date " & fromD & " to date " & toD & ""
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKINGMASTER.CHECK_YEARID}=" & YearId
                ObjGRN.Show()
                Exit Sub
            End If

            If chkdate.Checked = True Then
                ObjGRN.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
                ObjGRN.TODATE = Format(dtto.Value, "MM/dd/yyyy")
                ObjGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.CHECKDATE} in date " & fromD & " to date " & toD & ""
                'Else
                '    ObjGRN.OPENINGDATE = Format(DateAdd(DateInterval.Day, -1, AccFrom), "MM/dd/yyyy")
                '    ObjGRN.FROMDATE = Format(AccFrom, "MM/dd/yyyy")
                '    ObjGRN.TODATE = Format(AccTo, "MM/dd/yyyy")
                '    ObjGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If TXTLOT.Text <> "" Then
                ObjGRN.FRMSTRING = "LOT"
                ObjGRN.summary = True
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CUTVIEW.LOTNO}='" & TXTLOT.Text & "'"
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CUTVIEW.CMPID}=" & CmpId & " and {CUTVIEW.LOCATIONID}=" & Locationid & " and {CUTVIEW.YEARID}=" & YearId

            ElseIf RDBPARTYSUMRY.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.NAME}='" & cmbname.Text & "'"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.CMPID}=" & CmpId & " and {CHECKING_OPENING_VIEW.LOCATIONID}=" & Locationid & " and {CHECKING_OPENING_VIEW.YEARID}=" & YearId

            ElseIf RDBQUALITYSUMRY.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.NAME}='" & cmbname.Text & "'"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.CMPID}=" & CmpId & " and {CHECKING_OPENING_VIEW.LOCATIONID}=" & Locationid & " and {CHECKING_OPENING_VIEW.YEARID}=" & YearId

            ElseIf RDBPARTYWISEDETAIL.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.NAME}='" & cmbname.Text & "'"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.CMPID}=" & CmpId & " and {CHECKING_OPENING_VIEW.LOCATIONID}=" & Locationid & " and {CHECKING_OPENING_VIEW.YEARID}=" & YearId

            ElseIf RDBCHKSUMRY.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.NAME}='" & cmbname.Text & "'"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {CHECKING_OPENING_VIEW.CMPID}=" & CmpId & " and {CHECKING_OPENING_VIEW.LOCATIONID}=" & Locationid & " and {CHECKING_OPENING_VIEW.YEARID}=" & YearId

            ElseIf TXTLOT.Text <> "" Then
                ObjGRN.FRMSTRING = "LOT"
                ObjGRN.summary = True
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {COMMAND.LOTNO}='" & TXTLOT.Text & "'"
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {COMMAND.CMPID}=" & CmpId & " and {COMMAND.LOCATIONID}=" & Locationid & " and {COMMAND.YEARID}=" & YearId
            End If

            ObjGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RDBITEM_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBPARTYSUMRY.CheckedChanged
        Try
            If RDBPARTYSUMRY.Checked = True Then TXTTEMP.Text = "PARTYWISESUMMARY"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBQUALITY_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBQUALITYSUMRY.CheckedChanged
        Try
            If RDBQUALITYSUMRY.Checked = True Then TXTTEMP.Text = "QUALITYWISESUMMARY"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBPARTY_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBPARTYWISEDETAIL.CheckedChanged
        Try
            If RDBPARTYWISEDETAIL.Checked = True Then TXTTEMP.Text = "PARTYWISEDETAIL"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBMONTH_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBMONTHSUMRY.CheckedChanged
        Try
            If RDBMONTHSUMRY.Checked = True Then TXTTEMP.Text = "MONTHWISESUMMARY"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBCHKSUMRY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBCHKSUMRY.CheckedChanged
        Try
            If RDBCHKSUMRY.Checked = True Then TXTTEMP.Text = "CHECKSUMMARY"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class