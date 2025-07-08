Imports BL

Public Class GRNFilter

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
            If cmbitemname.Text.Trim = "" Then fillitem()
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
            If RDBITEM.Checked = True Then TXTTEMP.Text = "ITEM"
            If RDBQUALITY.Checked = True Then TXTTEMP.Text = "QUALITY"
            If RDBPARTY.Checked = True Then TXTTEMP.Text = "PARTY"
            If RDBMONTH.Checked = True Then TXTTEMP.Text = "MONTH"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillitem()
        Try
            If cmbitemname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DISTINCT ITEM ", "", " GRNSTOCK_VIEW ", " AND GRNSTOCK_VIEW.cmpid = " & CmpId & " AND GRNSTOCK_VIEW.LOCATIONID = " & Locationid & " AND GRNSTOCK_VIEW.YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ITEM"
                    cmbitemname.DataSource = dt
                    cmbitemname.DisplayMember = "ITEM"
                    cmbitemname.Text = ""
                End If
                cmbitemname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillQUALITY()
        Try
            If CMBQUALITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DISTINCT QUALITY ", "", " GRNSTOCK_VIEW ", " AND GRNSTOCK_VIEW.cmpid = " & CmpId & " AND GRNSTOCK_VIEW.LOCATIONID = " & Locationid & " AND GRNSTOCK_VIEW.YEARID = " & YearId)
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

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitem()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim ObjGRN As New GRNReportDesign
            ObjGRN.FRMSTRING = TXTTEMP.Text
            ObjGRN.MdiParent = MDIMain
            ObjGRN.selfor_ss = "1=1"

            If chkdate.Checked = True Then
                getFromToDate()
                ObjGRN.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
                ObjGRN.TODATE = Format(dtto.Value, "MM/dd/yyyy")
                ObjGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.GRNDATE} in date " & fromD & " to date " & toD & ""
            End If

            If CHKSUMMARY.Checked = True Then
                ObjGRN.summary = True
            Else
                ObjGRN.summary = False
            End If

            If RDBITEM.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.CMPID}=" & CmpId & " and {GRNSTOCK_VIEW.LOCATIONID}=" & Locationid & " and {GRNSTOCK_VIEW.YEARID}=" & YearId

            ElseIf RDBQUALITY.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.CMPID}=" & CmpId & " and {GRNSTOCK_VIEW.LOCATIONID}=" & Locationid & " and {GRNSTOCK_VIEW.YEARID}=" & YearId

            ElseIf RDBPARTY.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.CMPID}=" & CmpId & " and {GRNSTOCK_VIEW.LOCATIONID}=" & Locationid & " and {GRNSTOCK_VIEW.YEARID}=" & YearId

            ElseIf RDBMONTH.Checked = True Then
                If cmbname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"

                ObjGRN.selfor_ss = ObjGRN.selfor_ss & " and {GRNSTOCK_VIEW.CMPID}=" & CmpId & " and {GRNSTOCK_VIEW.LOCATIONID}=" & Locationid & " and {GRNSTOCK_VIEW.YEARID}=" & YearId

            ElseIf RBGRNMTRS.Checked = True Then
                Dim OBJGREY As New GreyRegisterReport
                OBJGREY.MdiParent = MDIMain
                OBJGREY.FRMSTRING = "GREYMTRS"
                If chkdate.CheckState = CheckState.Checked Then
                    OBJGREY.FROMDATE = dtfrom.Value.Date
                    OBJGREY.TODATE = dtto.Value.Date
                Else
                    OBJGREY.FROMDATE = AccFrom.Date
                    OBJGREY.TODATE = AccTo.Date
                End If
                If cmbname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"
                OBJGREY.Show()
                Exit Sub

            ElseIf RBGRNQUALITYMTRS.Checked = True Then
                Dim OBJGREY As New GreyRegisterReportQualityWise
                OBJGREY.MdiParent = MDIMain
                OBJGREY.FRMSTRING = "GREYMTRS"
                If chkdate.CheckState = CheckState.Checked Then
                    OBJGREY.FROMDATE = dtfrom.Value.Date
                    OBJGREY.TODATE = dtto.Value.Date
                Else
                    OBJGREY.FROMDATE = AccFrom.Date
                    OBJGREY.TODATE = AccTo.Date
                End If
                If cmbname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"
                OBJGREY.Show()
                Exit Sub

            ElseIf RBGRNPCS.Checked = True Then
                Dim OBJGREY As New GreyRegisterReport
                OBJGREY.MdiParent = MDIMain
                OBJGREY.FRMSTRING = "GREYPCS"
                If chkdate.CheckState = CheckState.Checked Then
                    OBJGREY.FROMDATE = dtfrom.Value.Date
                    OBJGREY.TODATE = dtto.Value.Date
                Else
                    OBJGREY.FROMDATE = AccFrom.Date
                    OBJGREY.TODATE = AccTo.Date
                End If
                If cmbname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"
                OBJGREY.Show()
                Exit Sub

            ElseIf RBGRNQUALITYPCS.Checked = True Then
                Dim OBJGREY As New GreyRegisterReportQualityWise
                OBJGREY.MdiParent = MDIMain
                OBJGREY.FRMSTRING = "GREYPCS"
                If chkdate.CheckState = CheckState.Checked Then
                    OBJGREY.FROMDATE = dtfrom.Value.Date
                    OBJGREY.TODATE = dtto.Value.Date
                Else
                    OBJGREY.FROMDATE = AccFrom.Date
                    OBJGREY.TODATE = AccTo.Date
                End If
                If cmbname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.NAME}='" & cmbname.Text & "'"
                If cmbitemname.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and ({GRNSTOCK_VIEW.ITEM}='" & cmbitemname.Text.Trim & "')"
                If CMBQUALITY.Text <> "" Then OBJGREY.WHERECLAUSE = OBJGREY.WHERECLAUSE & " and {GRNSTOCK_VIEW.QUALITY}='" & CMBQUALITY.Text & "'"
                OBJGREY.Show()
                Exit Sub
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

    Private Sub RDBITEM_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBITEM.CheckedChanged
        Try
            If RDBITEM.Checked = True Then TXTTEMP.Text = "ITEM"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBQUALITY_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBQUALITY.CheckedChanged
        Try
            If RDBQUALITY.Checked = True Then TXTTEMP.Text = "QUALITY"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBPARTY_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBPARTY.CheckedChanged
        Try
            If RDBPARTY.Checked = True Then TXTTEMP.Text = "PARTY"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBMONTH_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBMONTH.CheckedChanged
        Try
            If RDBMONTH.Checked = True Then TXTTEMP.Text = "MONTH"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSUMMARY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSUMMARY.CheckedChanged
        Try
            If CHKSUMMARY.Checked = True Then
                RDBMONTH.Enabled = False
                RDBITEM.Checked = True
            End If

            If CHKSUMMARY.Checked = False Then RDBMONTH.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class