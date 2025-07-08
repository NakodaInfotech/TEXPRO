
Imports BL

Public Class mfgfilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public filtfrmString As String
    Public filtpartystock As String

    Private Sub Filter_for_Stock_Party_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try

            If RBCONTRACTORBILL.Checked = True And ClientName = "TULSI" Then

                Dim OBJBILL As New clsReportDesigner("CONTRACTOR BILL", System.AppDomain.CurrentDomain.BaseDirectory & "CONTRACTOR BILL.xlsx", 2)
                Dim WHERECLAUSE As String = ""

                Dim process As String = ""
                Dim checked_processname As CheckedListBox.CheckedItemCollection = CLB_Process.CheckedItems
                For Each process_name As Object In checked_processname
                    If process = "" Then
                        process = "'" & process_name.ToString & "'"
                    Else
                        process = process & ",'" & process_name.ToString & "'"
                    End If
                Next process_name
                If process <> "" Then
                    WHERECLAUSE = WHERECLAUSE & " and PROCESSMASTER.process_NAME in (" & process & ")"
                End If

                If chkdate.CheckState = CheckState.Checked Then
                    WHERECLAUSE = WHERECLAUSE & " and MFG_DATE >= '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and MFG_DATE <= '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                    OBJBILL.MFG_CONTRACTORBILL_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBCONTRACTOR.Text.Trim, WHERECLAUSE)
                Else
                    OBJBILL.MFG_CONTRACTORBILL_EXCEL(CmpId, YearId, AccFrom.Date, AccTo.Date, CMBCONTRACTOR.Text.Trim, WHERECLAUSE)
                End If
                Exit Sub
            End If




            If RBCONTRACTORBILL.Checked = True And ClientName = "DHANLAXMI" Then
                Dim OBJMFG As New mfgdesign
                OBJMFG.selfor_po = "{MFGMASTER.MFG_YEARID} = " & YearId


                If CMBCONTRACTOR.Text.Trim <> "" Then OBJMFG.selfor_po = OBJMFG.selfor_po & " AND {CONTRACTORMASTER.CONTRACTOR_NAME} = '" & CMBCONTRACTOR.Text.Trim & "'"

                Dim process As String = ""
                Dim checked_processname As CheckedListBox.CheckedItemCollection = CLB_Process.CheckedItems
                For Each process_name As Object In checked_processname
                    If process = "" Then
                        process = "'" & process_name.ToString & "'"
                    Else
                        process = process & ",'" & process_name.ToString & "'"
                    End If
                Next process_name
                If process <> "" Then
                    OBJMFG.selfor_po = OBJMFG.selfor_po & " and {PROCESSMASTER.process_NAME} in [" & process & "]"
                End If

                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJMFG.selfor_po = OBJMFG.selfor_po & " and {@date} in date " & fromD & " to date " & toD & ""
                    OBJMFG.PERIOD = "CONTRACTOR BILL - " & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                Else
                    OBJMFG.PERIOD = "CONTRACTOR BILL - " & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If

                OBJMFG.frmstring = "CONTRACTORBILL"
                OBJMFG.MdiParent = MDIMain
                OBJMFG.Show()
                Exit Sub
            End If



            Dim PERIOD As String = ""
            Dim tempmsg As Integer = MsgBox("WISH To PRINT EXCEL?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then
                Dim strq As String = ""
                Dim CONDITION As String = ""
                Dim NOTCONDITION As String = ""
                If cmbQuality.Text.Trim <> "" Then
                    strq = strq & " And QUALITYMASTER.Quality_name='" & cmbQuality.Text.Trim & "'"
                End If
                Dim process As String = ""
                Dim checked_processname As CheckedListBox.CheckedItemCollection = CLB_Process.CheckedItems
                For Each process_name As Object In checked_processname
                    If process = "" Then
                        process = "'" & process_name.ToString & "'"
                    Else
                        process = process & ",'" & process_name.ToString & "'"
                    End If
                Next process_name
                If process <> "" Then
                    strq = strq & " and PROCESSMASTER_1.process_NAME in (" & process & ")"
                End If

                'If cmbprocess.Text.Trim <> "" Then
                '    strq = strq & " and PROCESSMASTER_1.process_NAME='" & cmbprocess.Text.Trim & "'"
                'End If
                If chkdate.Checked = True Then
                    CONDITION = CONDITION & " and MFG_DATE BETWEEN '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                    NOTCONDITION = NOTCONDITION & " and MFG_DATE NOT BETWEEN '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                If chkcompleted.Checked = True And CHKONPROCESS.Checked = False Then
                    CONDITION = CONDITION & " and MFGMASTER_DESC.MFG_DONE='TRUE'"
                ElseIf chkcompleted.Checked = False And CHKONPROCESS.Checked = True Then
                    CONDITION = CONDITION & " and MFGMASTER_DESC.MFG_DONE='FALSE'"
                End If
                Dim objrep As New clsReportDesigner("MFG DETAIL", System.AppDomain.CurrentDomain.BaseDirectory & "MFGDETAIL.xlsx", 2)


                objrep.MFG_CONSUMPTION_EXCEL(strq, CmpId, Locationid, YearId, CONDITION, NOTCONDITION)

            Else

                Dim formula As String = ""
                Dim WHERECLAUSE As String = ""
                If cmbprocess.Text = "PROCIAN PRINTING" Or cmbprocess.Text = "PIGMENT PRINTING" Then
                    formula = " {MFGMASTER2.MFG_CMPID}= " & CmpId & " and {MFGMASTER2.MFG_LOCATIONID}= " & Locationid & " and {MFGMASTER2.MFG_YEARID}= " & YearId
                    WHERECLAUSE = " MFGMASTER2.MFG_CMPID = " & CmpId & " and MFGMASTER2.MFG_LOCATIONID = " & Locationid & " and MFGMASTER2.MFG_YEARID= " & YearId

                    If cmbQuality.Text.Trim <> "" Then
                        formula = formula & " and {QUALITYMASTER.Quality_name}='" & cmbQuality.Text.Trim & "'"
                    End If
                    If CMBCONTRACTOR.Text.Trim <> "" Then
                        formula = formula & " and {contractormaster.contractor_name}='" & CMBCONTRACTOR.Text.Trim & "'"
                        WHERECLAUSE = WHERECLAUSE & " AND contractormaster.contractor_name ='" & CMBCONTRACTOR.Text.Trim & "'"
                    End If
                    'If cmbprocess.Text.Trim <> "" Then
                    '    formula = formula & " and {PROCESSMASTER.process_NAME}='" & cmbprocess.Text.Trim & "'"
                    'End If
                    If chkcompleted.Checked = True And CHKONPROCESS.Checked = False Then
                        formula = formula & " and {MFGMASTER2.MFG_DONE}=TRUE"
                        WHERECLAUSE = WHERECLAUSE & " AND MFGMASTER2.MFG_DONE = 'TRUE'"
                    ElseIf chkcompleted.Checked = False And CHKONPROCESS.Checked = True Then
                        formula = formula & " and {MFGMASTER2.MFG_DONE}=FALSE"
                        WHERECLAUSE = WHERECLAUSE & " AND MFGMASTER2.MFG_DONE = 'FALSE'"
                    End If


                    If chkdate.Checked = True Then
                        getFromToDate()
                        formula = formula & " and {@date} in date " & fromD & " to date " & toD & ""
                        WHERECLAUSE = WHERECLAUSE & " AND MFG_DESC >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MFG_DESC <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    Else
                        WHERECLAUSE = WHERECLAUSE & " AND MFG_DESC >= '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND MFG_DESC <= '" & Format(AccTo.Date, "MM/dd/yyyy") & "'"
                    End If

                ElseIf cmbprocess.Text.Trim = "DYEING" Then


                    formula = " {MFG.CMPID}= " & CmpId & " and {MFG.LOCATIONID}= " & Locationid & " and {mfg.YEARID}= " & YearId

                    If chkcompleted.Checked = True And CHKONPROCESS.Checked = False Then
                        formula = formula & " and {mfg.DONE}=TRUE"
                    ElseIf chkcompleted.Checked = False And CHKONPROCESS.Checked = True Then
                        formula = formula & " and {mfg.DONE}=FALSE"
                    End If
                    If cmbQuality.Text.Trim <> "" Then
                        formula = formula & " and {mfg.Quality}='" & cmbQuality.Text.Trim & "'"
                    End If

                    Dim process As String = ""
                    Dim checked_processname As CheckedListBox.CheckedItemCollection = CLB_Process.CheckedItems
                    For Each process_name As Object In checked_processname
                        If process = "" Then
                            process = "'" & process_name.ToString & "'"
                        Else
                            process = process & ",'" & process_name.ToString & "'"
                        End If
                    Next process_name
                    If process <> "" Then
                        formula = formula & " and {mfg.TOPROCESS} in [" & process & "]"
                    End If



                    If chkdate.Checked = True Then
                        getFromToDate()
                        formula = formula & " and {@date} in date " & fromD & " to date " & toD & ""
                        PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                    Else
                        PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                    End If

                Else

                    formula = " {mfg1_VIEW.CMPID}= " & CmpId & " and {mfg1_VIEW.LOCATIONID}= " & Locationid & " and {mfg.YEARID}= " & YearId

                    If chkcompleted.Checked = True And CHKONPROCESS.Checked = False Then
                        formula = formula & " and {mfg1_VIEW.DONE}=TRUE"
                    ElseIf chkcompleted.Checked = False And CHKONPROCESS.Checked = True Then
                        formula = formula & " and {mfg1_VIEW.DONE}=FALSE"
                    End If
                    If cmbQuality.Text.Trim <> "" Then
                        formula = formula & " and {mfg1_VIEW.Quality}='" & cmbQuality.Text.Trim & "'"
                    End If

                    Dim process As String = ""
                    Dim checked_processname As CheckedListBox.CheckedItemCollection = CLB_Process.CheckedItems
                    For Each process_name As Object In checked_processname
                        If process = "" Then
                            process = "'" & process_name.ToString & "'"
                        Else
                            process = process & ",'" & process_name.ToString & "'"
                        End If
                    Next process_name
                    If process <> "" Then
                        formula = formula & " and {mfg1_VIEW.TOPROCESS} in [" & process & "]"
                    End If



                    If chkdate.Checked = True Then
                        getFromToDate()
                        formula = formula & " and {@date} in date " & fromD & " to date " & toD & ""
                    End If
                End If

                Dim objstock As New mfgdesign
                'If cmbprocess.Text.Trim = "DYEING" Then
                '    objstock.frmstring = "DYEING"
                '    objstock.MdiParent = MDIMain
                '    objstock.selfor_po = formula
                '    objstock.PERIOD = PERIOD
                '    objstock.Show()
                'Else
                If cmbprocess.Text.Trim = "PROCIAN PRINTING" Or cmbprocess.Text.Trim = "PIGMENT PRINTING" Then
                    Dim OBJCONTRACTOR As New ContractorRate
                    OBJCONTRACTOR.MdiParent = MDIMain
                    OBJCONTRACTOR.WHERE = WHERECLAUSE & " AND PROCESS_NAME = '" & cmbprocess.Text.Trim & "'"
                    OBJCONTRACTOR.Show()
                Else
                    Dim OBJMFG As New MfgDetails
                    OBJMFG.MdiParent = MDIMain
                    OBJMFG.WHERECLAUSE = " AND TOPROCESS.PROCESS_NAME = '" & cmbprocess.Text.Trim & "'"
                    If CHKONPROCESS.Checked = True Then OBJMFG.WHERECLAUSE = OBJMFG.WHERECLAUSE & " AND MFGMASTER_DESC.MFG_DONE = 0"
                    If chkcompleted.Checked = True Then OBJMFG.WHERECLAUSE = OBJMFG.WHERECLAUSE & " AND MFGMASTER_DESC.MFG_DONE = 1"
                    If CMBCONTRACTOR.Text.Trim <> "" Then OBJMFG.WHERECLAUSE = OBJMFG.WHERECLAUSE & " AND CONTRACTORMASTER.CONTRACTOR_NAME = '" & CMBCONTRACTOR.Text.Trim & "'"
                    If chkdate.CheckState = CheckState.Checked Then OBJMFG.WHERECLAUSE = OBJMFG.WHERECLAUSE & " AND MFGMASTER.MFG_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MFGMASTER.MFG_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    OBJMFG.Show()
                End If

            End If

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
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE<>''", True)
            CLB_Process.Items.Clear()
            Dim dt As DataTable
            Dim objclscomm As New ClsCommon()
            dt = objclscomm.search(" PROCESS_name ", "", " PROCESSMASTER", " and PROCESS_cmpid=" & CmpId & " AND PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_YEARID = " & YearId & " Order by process_name ")

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    CLB_Process.Items.Add(Convert.ToString(dr(0)), False)
                Next
            End If

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

    Private Sub CLB_Process_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLB_Process.SelectedIndexChanged
        cmbprocess.Text = CLB_Process.SelectedItem
    End Sub

    Private Sub CMBCONTRACTOR_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCONTRACTOR.Enter
        Try
            If CMBCONTRACTOR.Text.Trim = "" Then fillCONTRACTOR(CMBCONTRACTOR)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBCONTRACTOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCONTRACTOR.Validating
        Try
            If CMBCONTRACTOR.Text.Trim <> "" Then CONTRACTORvalidate(CMBCONTRACTOR, e, Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CMBCONTRACTOR_Validated(sender As Object, e As EventArgs) Handles CMBCONTRACTOR.Validated
        Try
            If CMBCONTRACTOR.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT CR_DAYRATE AS DAYRATE, CR_NIGHTRATE AS NIGHTRATE FROM CONTRACTORWORKERRATE  LEFT OUTER JOIN CONTRACTORMASTER ON CR_CONTRACTORID= CONTRACTOR_ID  WHERE CONTRACTOR_NAME = '" & CMBCONTRACTOR.Text.Trim & "' and CR_Yearid =" & YearId, "", "")
                If DT.Rows.Count > 0 Then
                    TXTDAYRATE.Text = Val(DT.Rows(0).Item("DAYRATE"))
                    TXTNIGHTRATE.Text = Val(DT.Rows(0).Item("NIGHTRATE"))
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTESIC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTESIC.KeyPress, TXTOTHERAMT.KeyPress, TXTDAYRATE.KeyPress, TXTNIGHTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class