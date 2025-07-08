Imports BL
Public Class Mfg1Filter
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public FRMSTRING As String


    Private Sub Filter_for_Stock_Party_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdshowreport_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            Dim objstock As New mfgdesign
            objstock.SHOWOURQUALITY = CHKOURQUALITY.Checked
            Dim formula As String = ""

            If RDBLOTDETAIL.Checked = True Then
                formula = "{CUTVIEW.CMPID}= " & CmpId & " and {CUTVIEW.LOCATIONID}= " & Locationid & " and {CUTVIEW.YEARID}= " & YearId
                If TXTLOTNO.Text.Trim <> "" Then
                    formula = formula & " and {CUTVIEW.LOTNO}='" & TXTLOTNO.Text.Trim & "'"
                End If
                objstock.frmstring = "LOTHISTORY"
                If chkdate.Checked = True Then
                    getFromToDate(dtfrom.Value, dtto.Value)
                    formula = formula & " and ({CUTVIEW.DATE} in date " & fromD & " to date " & toD & ")"
                    'formula = formula & " and {mfg1_view.date} <=#" & Format(dtto.Value, "MM/dd/yyyy") & "#"
                    objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                    objstock.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
                    objstock.STARTDATE = Format(startdate.Value, "MM/dd/yyyy")
                    objstock.TODATE = Format(dtto.Value, "MM/dd/yyyy")
                Else
                    objstock.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If
            ElseIf RDBLOTSUMMARY.Checked = True Then
                formula = "{CUTVIEW.CMPID}= " & CmpId & " and {CUTVIEW.LOCATIONID}= " & Locationid & " and {CUTVIEW.YEARID}= " & YearId
                If TXTLOTNO.Text.Trim <> "" Then
                    formula = formula & " and {CUTVIEW.LOTNO}='" & TXTLOTNO.Text.Trim & "'"
                End If
                objstock.frmstring = "LOTSUMMARY"
                If chkdate.Checked = True Then
                    getFromToDate(dtfrom.Value, dtto.Value)
                    formula = formula & " and ({CUTVIEW.DATE} in date " & fromD & " to date " & toD & ")"
                    'formula = formula & " and {mfg1_view.date} <=#" & Format(dtto.Value, "MM/dd/yyyy") & "#"
                    objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                    objstock.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
                    objstock.STARTDATE = Format(startdate.Value, "MM/dd/yyyy")
                    objstock.TODATE = Format(dtto.Value, "MM/dd/yyyy")
                Else
                    objstock.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If
            ElseIf chkfull.Checked = False Then
                '
                formula = " {mfg1_view.YEARID}= " & YearId
                If cmbprocess.Text.Trim <> "" Then
                    formula = formula & " and {mfg1_view.Process}='" & cmbprocess.Text.Trim & "'"
                End If
                If cmbQuality.Text.Trim <> "" Then
                    formula = formula & " and {mfg1_view.Quality}='" & cmbQuality.Text.Trim & "'"
                End If
                If TXTLOTNO.Text.Trim <> "" Then
                    formula = formula & " and {mfg1_view.LOTNO}=" & TXTLOTNO.Text.Trim
                End If
                If rdbdetail.Checked = True Then
                    If TXTLOTNO.Text = "" Then
                        If CHKVALUE.CheckState = CheckState.Unchecked Then
                            objstock.frmstring = "MFGDETAIL"
                        Else
                            objstock.frmstring = "MFGDETAILVALUE"
                        End If
                    Else
                        objstock.frmstring = "MFGLOTDETAIL"
                    End If
                ElseIf Rdbsummary.Checked = True Then
                    If TXTLOTNO.Text = "" Then
                        objstock.frmstring = "MFGSUMMARY"
                    Else
                        objstock.frmstring = "MFGLOTSUMMARY"
                    End If
                ElseIf RDBMONTHLY.Checked = True Then
                    objstock.frmstring = "MFGMONTHLY"
                End If

                If chkNEGATIVE.Checked = True Then
                    objstock.positive = 0
                Else
                    objstock.positive = 1
                End If
                If chkdate.Checked = True Then
                    getFromToDate(dtfrom.Value, dtto.Value)
                    formula = formula & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                    'formula = formula & " and {mfg1_view.date} >= #" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "# AND  {mfg1_view.date} <= #" & Format(dtto.Value.Date, "MM/dd/yyyy") & "#"
                    objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                    objstock.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
                    objstock.STARTDATE = Format(startdate.Value, "MM/dd/yyyy")
                    objstock.TODATE = Format(dtto.Value, "MM/dd/yyyy")
                Else
                    objstock.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If


                'NO DATE FILTER IS APPLIED HERE (DONE BY GULKIT AS TOTAL IS NOT POSSIBLE IN CRYSTAL REPORT)
                'Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" SUM(FINAL.INMTRS) INMTRS ,SUM(FINAL.OUTMTRS) OUTMTRS, SUM(FINAL.PENDINGMTRS) PENDINGMTRS ", "", " (SELECT T.LOTNO , SUM(INMTRS) AS INMTRS, SUM(OUTMTRS) AS OUTMTRS ,(SUM(INMTRS)- SUM(OUTMTRS)) AS PENDINGMTRS   FROM (SELECT LOTNO, SUM(MTRS) AS INMTRS,0 AS OUTMTRS, 0 AS PENDINGMTRS  FROM VIEW_SUMMARY_MFG1 WHERE MTRS > 0 AND YEARID = " & YearId & " GROUP BY LOTNO   UNION ALL SELECT LOTNO, 0 AS INMTRS, SUM(MTRS) * (-1) AS OUTMTRS, 0 AS PENDINGMTRS  FROM VIEW_SUMMARY_MFG1 WHERE MTRS < 0 AND YEARID = " & YearId & " GROUP BY LOTNO ) AS T GROUP BY T.LOTNO HAVING (SUM(INMTRS)- SUM(OUTMTRS)) > 1 ) AS FINAL ", " ")
                'If DT.Rows.Count > 0 Then
                '    objstock.TOTALPENDING = DT.Rows(0).Item("PENDINGMTRS")
                '    objstock.TOTALINWARD = DT.Rows(0).Item("INMTRS")
                '    objstock.TOTALOUTWARD = DT.Rows(0).Item("OUTMTRS")
                'End If

            Else

                formula = "{mfg1_view.CMPID}= " & CmpId & " and {mfg1_view.LOCATIONID}= " & Locationid & " and {mfg1_view.YEARID}= " & YearId
                If cmbprocess.Text.Trim <> "" Then formula = formula & " and {mfg1_view.Process Name}='" & cmbprocess.Text.Trim & "'"
                If cmbQuality.Text.Trim <> "" Then formula = formula & " and {mfg1_view.Quality}='" & cmbQuality.Text.Trim & "'"
                If RDBINPROCESS.Checked = True Then formula = formula & " and {mfg1_view.MTRS} - {mfg1_view.OUTMTRS}>0"
                If RDBDONE.Checked = True Then formula = formula & " and {mfg1_view.MTRS} - {mfg1_view.OUTMTRS}<=0"

                If rdbdetail.Checked = True Then
                    objstock.frmstring = "MFGFULLDETAIL"
                ElseIf Rdbsummary.Checked = True Then
                    objstock.frmstring = "MFGFULLSUMMARY"
                ElseIf RDBMONTHLY.Checked = True Then
                    objstock.frmstring = "MFGFULLMONTHLY"
                End If
                If chkdate.Checked = True Then
                    getFromToDate(startdate.Value, dtto.Value)
                    formula = formula & " and ({@date} in date " & fromD & " to date " & toD & ")"
                    objstock.PERIOD = Format(startdate.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                Else
                    objstock.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If

            End If

            objstock.MdiParent = MDIMain
            objstock.selfor_po = formula

            objstock.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub getFromToDate(ByVal from As Date, ByVal upto As Date)
        a1 = DatePart(DateInterval.Day, from)
        a2 = DatePart(DateInterval.Month, from)
        a3 = DatePart(DateInterval.Year, from)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, upto)
        a12 = DatePart(DateInterval.Month, upto)
        a13 = DatePart(DateInterval.Year, upto)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Filter_for_Stock_Party_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dtfrom.Value = DateAdd(DateInterval.Day, -1, AccFrom)
            fillcombos()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE='MFG'", False)

            Dim dt As DataTable
            Dim objclscomm As New ClsCommon()
            
            If cmbQuality.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster

                dt = objclscommon.search(" Quality_name ", "", " QualityMaster ", " and Quality_cmpid=" & CmpId & " and Quality_LOCATIONid=" & Locationid & " and Quality_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Quality_name"
                    cmbQuality.DataSource = dt
                    cmbQuality.DisplayMember = "Quality_name"
                    cmbQuality.Text = ""
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkfull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkfull.CheckedChanged
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class