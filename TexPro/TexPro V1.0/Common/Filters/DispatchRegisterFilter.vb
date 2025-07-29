
Imports System.ComponentModel
Imports BL

Public Class DispatchRegisterFilter

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
            If CMBSTATE.Text.Trim = "" Then fillSTATE(CMBSTATE)
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " AND GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'AGENT'")
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)

            'Fill PIECETYPE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("PIECETYPE_NAME AS PIECETYPE", "", " PIECETYPEMASTER ", " AND PIECETYPE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                Dim NEWDT As DataTable = DT.DefaultView.ToTable(True, "PIECETYPE")
                NEWDT.DefaultView.Sort = "PIECETYPE"
                For Each dr As DataRowView In NEWDT.DefaultView
                    CLB_GRADE.Items.Add(Convert.ToString(dr("PIECETYPE")), False)
                Next
            End If

            DT = OBJCMN.search("DEPARTMENT_name AS DEPARTMENT", "", " DEPARTMENTMASTER ", " AND DEPARTMENT_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                Dim NEWDT As DataTable = DT.DefaultView.ToTable(True, "DEPARTMENT")
                NEWDT.DefaultView.Sort = "DEPARTMENT"
                For Each dr As DataRowView In NEWDT.DefaultView
                    CLB_DEPARTMENT.Items.Add(Convert.ToString(dr("DEPARTMENT")), False)
                Next
            End If


            DT = OBJCMN.search("CATEGORY_name AS CATEGORY", "", " CATEGORYMASTER ", " AND CATEGORY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                Dim NEWDT As DataTable = DT.DefaultView.ToTable(True, "CATEGORY")
                NEWDT.DefaultView.Sort = "CATEGORY"
                For Each dr As DataRowView In NEWDT.DefaultView
                    CLB_CATEGORY.Items.Add(Convert.ToString(dr("CATEGORY")), False)
                Next
            End If

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

    Private Sub DispatchRegisterFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreStockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcmb()
        cmbtype.SelectedIndex = (0)
        opdate.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            If CHKGRID.CheckState = CheckState.Unchecked Then
                Dim objwo As New GDNDESIGN
                objwo.MdiParent = MDIMain



                If cmbtype.Text = "Job" Then

                    objwo.FORMULA = " {GDN.GDN_YEARID}=" & YearId & " AND ({GDN_PSDESC.GDN_TYPE} = 'PSJOB' OR {GDN_PSDESC.GDN_TYPE} = 'JOBBALE') "
                    If cmbmerchant.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ITEMMASTER.ITEM_NAME}='" & cmbmerchant.Text.Trim & "'"
                    'If CMBCATEGORY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"
                    If TXTMERCHANT.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ITEMMASTER.ITEM_NAME} LIKE '*" & TXTMERCHANT.Text.Trim & "*'"
                    If cmbname.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {LEDGERS.ACC_CMPNAME}='" & cmbname.Text & "'"
                    If CMBCITY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {CITYMASTER.CITY_NAME}='" & CMBCITY.Text.Trim.Trim & "'"
                    If CMBSTATE.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {STATEMASTER.STATE_NAME}='" & CMBSTATE.Text.Trim.Trim & "'"

                    If rdbsummary.Checked = True Then
                        objwo.FRMSTRING = "JOBSUMMARY"
                    ElseIf rdbdetail.Checked = True Then
                        objwo.FRMSTRING = "JOBDETAIL"
                    ElseIf rdbmonthly.Checked = True Then
                        objwo.FRMSTRING = "JOBMONTHLY"
                    End If
                Else

                    objwo.FORMULA = " {GDN.yearid}=" & YearId

                    Dim CHECKED_GRADE As CheckedListBox.CheckedItemCollection = CLB_GRADE.CheckedItems
                    Dim PIECETYPE As String = ""
                    For Each item As Object In CHECKED_GRADE
                        If PIECETYPE = "" Then
                            PIECETYPE = "'" & item.ToString() & "'"
                        Else
                            PIECETYPE = PIECETYPE & ",'" & item.ToString() & "'"
                        End If
                    Next item
                    If PIECETYPE <> "" Then objwo.FORMULA = objwo.FORMULA & " and ({gdn.PIECETYPE} IN [" & PIECETYPE & "])"



                    Dim CHECKED_DEPARTMENT As CheckedListBox.CheckedItemCollection = CLB_DEPARTMENT.CheckedItems
                    Dim DEPARTMENT As String = ""
                    For Each item As Object In CHECKED_DEPARTMENT
                        If DEPARTMENT = "" Then
                            DEPARTMENT = "'" & item.ToString() & "'"
                        Else
                            DEPARTMENT = DEPARTMENT & ",'" & item.ToString() & "'"
                        End If
                    Next item
                    If DEPARTMENT <> "" Then objwo.FORMULA = objwo.FORMULA & " and ({gdn.DEPARTMENT} IN [" & DEPARTMENT & "])"


                    Dim CHECKED_CATEGORY As CheckedListBox.CheckedItemCollection = CLB_CATEGORY.CheckedItems
                    Dim CATEGORY As String = ""
                    For Each item As Object In CHECKED_CATEGORY
                        If CATEGORY = "" Then
                            CATEGORY = "'" & item.ToString() & "'"
                        Else
                            CATEGORY = CATEGORY & ",'" & item.ToString() & "'"
                        End If
                    Next item
                    If CATEGORY <> "" Then objwo.FORMULA = objwo.FORMULA & " and ({gdn.CATEGORY} IN [" & CATEGORY & "])"




                    If cmbmerchant.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.merchant}='" & cmbmerchant.Text.Trim & "'"
                    'If CMBCATEGORY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.CATEGORY}='" & CMBCATEGORY.Text.Trim & "'"
                    If TXTMERCHANT.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.merchant} LIKE '*" & TXTMERCHANT.Text.Trim & "*'"
                    If CMBCITY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.CITYNAME}='" & CMBCITY.Text.Trim.Trim & "'"
                    If CMBSTATE.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.STATENAME}='" & CMBSTATE.Text.Trim.Trim & "'"
                    If Val(TXTBALENO.Text.Trim) <> 0 Then objwo.FORMULA = objwo.FORMULA & " and {gdn.PSNO}=" & Val(TXTBALENO.Text.Trim)
                    If TXTJOBNO.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.JOBNO}='" & TXTJOBNO.Text.Trim & "'"
                    If CMBAGENT.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {gdn.AGENTNAME}='" & CMBAGENT.Text.Trim & "'"

                    If cmbname.Text.Trim <> "" Then
                        objwo.FORMULA = objwo.FORMULA & " and {gdn.partyname}='" & cmbname.Text & "'"
                        objwo.period = UCase(cmbname.Text.Trim) & "  "
                    End If

                    If rdbdetail.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHDETAIL"
                    ElseIf rdbsummary.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHSUMMARY"
                    ElseIf rdbmonthly.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHMONTHLY"
                    ElseIf RDBDEPTMONTHLY.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHDEPTMONTHLY"
                    ElseIf RBMONTHLYPARTYWISE.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHMONTHLYPARTYWISE"
                    ElseIf RBAGENTMONTHLY.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHAGENTMONTHLY"
                    ElseIf RBAGENTPARTY.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHAGENTMERCHANT"
                    ElseIf RDBSUMMARYWITHBILL.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHSUMMARYBILLNO"
                    ElseIf RBAGENTITEM.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHAGENTPARTY"
                    ElseIf RBDESIGNBALE.Checked = True Or RBDESIGNBALESUMM.Checked = True Then

                        If RBDESIGNBALE.Checked = True Then objwo.FRMSTRING = "DISPATCHDESIGNBALE" Else objwo.FRMSTRING = "DISPATCHDESIGNBALESUMM"
                        objwo.FORMULA = " {GDN.GDN_YEARID} = " & YearId
                        If cmbtype.Text.Trim = "Job" Then objwo.FORMULA = objwo.FORMULA & " and ({ALLBALE_VIEW.TYPE}='JOBBALE' or {ALLBALE_VIEW.TYPE}='PSJOB')" Else objwo.FORMULA = objwo.FORMULA & " and {ALLBALE_VIEW.TYPE}<>'JOBBALE' AND {ALLBALE_VIEW.TYPE}<>'PSJOB'"
                        If cmbmerchant.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ALLBALE_VIEW.MERCHANT}='" & cmbmerchant.Text.Trim & "'"
                        If TXTMERCHANT.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ALLBALE_VIEW.MERCHANT} LIKE '*" & TXTMERCHANT.Text.Trim & "*'"
                        If TXTJOBNO.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ALLBALE_VIEW.JOB NO}='" & TXTJOBNO.Text.Trim & "'"
                        If CMBAGENT.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {AGENTLEDGERS.ACC_CMPNAME}='" & CMBAGENT.Text.Trim & "'"
                        If cmbname.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {LEDGERS.ACC_CMPNAME}='" & cmbname.Text.Trim & "'"
                        If cmbDesign.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ALLBALE_VIEW.DESIGNNO}='" & cmbDesign.Text.Trim & "'"
                        If chkdate.Checked = True Then
                            getFromToDate()
                            If RBJOB.Checked = False And RBPROG.Checked = False Then objwo.FORMULA = objwo.FORMULA & " and ({@GDNDATE} in date " & fromD & " to date " & toD & ")" Else objwo.FORMULA = objwo.FORMULA & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                            objwo.period = objwo.period & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                        Else
                            objwo.period = objwo.period & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                        End If
                        objwo.Show()
                        Exit Sub

                    ElseIf RBJOB.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHJOBWISE"
                        'FOR THIS CREATE NEW FORMULA DONT CHANGE THIS, DONE BY GULKIT
                        objwo.FORMULA = " {GDN.GDN_YEARID}= " & YearId & " AND {FINALPACKINGSLIP.FPS_JOBNO} <> ''"
                        If cmbmerchant.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ITEMMASTER.ITEM_NAME}='" & cmbmerchant.Text & "'"
                        'If CMBCATEGORY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"
                        If TXTMERCHANT.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ITEMMASTER.ITEM_NAME} LIKE '*" & TXTMERCHANT.Text & "*'"
                        If CMBCITY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {CITYMASTER.CITY_NAME}='" & CMBCITY.Text.Trim & "'"
                        If CMBSTATE.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {STATEMASTER.STATE_NAME}='" & CMBSTATE.Text.Trim & "'"
                        If Val(TXTBALENO.Text.Trim) > 0 Then objwo.FORMULA = objwo.FORMULA & " and {FINALPACKINGSLIP.FPS_NO}=" & Val(TXTBALENO.Text)
                        If TXTJOBNO.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {FINALPACKINGSLIP.FPS_JOBNO}='" & TXTJOBNO.Text & "'"
                        If cmbname.Text.Trim <> "" Then
                            objwo.FORMULA = objwo.FORMULA & " and {LEDGERS.ACC_CMPNAME}='" & cmbname.Text & "'"
                            objwo.period = UCase(cmbname.Text.Trim) & "  "
                        End If
                    ElseIf RBPROG.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHPROGWISE"
                        'FOR THIS CREATE NEW FORMULA DONT CHANGE THIS, DONE BY GULKIT
                        objwo.FORMULA = " {GDN.GDN_YEARID}= " & YearId & " AND {FINALPACKINGSLIP.FPS_PROGNO} <> 0"
                        If cmbmerchant.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ITEMMASTER.ITEM_NAME}='" & cmbmerchant.Text & "'"
                        'If CMBCATEGORY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {CATEGORYMASTER.CATEGORY_NAME}='" & CMBCATEGORY.Text.Trim & "'"
                        If TXTMERCHANT.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {ITEMMASTER.ITEM_NAME} LIKE '*" & TXTMERCHANT.Text & "*'"
                        If CMBCITY.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {CITYMASTER.CITY_NAME}='" & CMBCITY.Text.Trim & "'"
                        If CMBSTATE.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {STATEMASTER.STATE_NAME}='" & CMBSTATE.Text.Trim & "'"
                        If Val(TXTBALENO.Text.Trim) > 0 Then objwo.FORMULA = objwo.FORMULA & " and {FINALPACKINGSLIP.FPS_NO}=" & Val(TXTBALENO.Text)
                        If TXTJOBNO.Text.Trim <> "" Then objwo.FORMULA = objwo.FORMULA & " and {FINALPACKINGSLIP.FPS_JOBNO}='" & TXTJOBNO.Text & "'"
                        If Val(TXTPROGNO.Text.Trim) > 0 Then objwo.FORMULA = objwo.FORMULA & " and {FINALPACKINGSLIP.FPS_PROGNO}=" & Val(TXTPROGNO.Text)
                        If cmbname.Text.Trim <> "" Then
                            objwo.FORMULA = objwo.FORMULA & " and {LEDGERS.ACC_CMPNAME}='" & cmbname.Text & "'"
                            objwo.period = UCase(cmbname.Text.Trim) & "  "
                        End If
                    ElseIf RBCATEGORY.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHCATEGORY"
                    ElseIf RBCATEGORYMONTHLY.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHCATEGORYMONTHLY"
                    ElseIf RBDEPT.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHDEPT"
                    ElseIf RBGRADE.Checked = True Then
                        objwo.FRMSTRING = "DISPATCHGRADE"
                    End If
                    If RBJOB.Checked = False And RBPROG.Checked = False Then objwo.FORMULA = objwo.FORMULA & " and {gdn.type} IN ['BALE','FINALPACKING'] "
                End If


                'GET PREVIOS TOTAL OF CURENT MONTH
                If RBJOB.Checked = False And RBPROG.Checked = False Then
                    Dim OBJ As New ClsCommon()
                    Dim dt As New DataTable
                    If chkdate.Checked = True Then
                        Dim COND As String
                        If cmbtype.Text = "Job" Then
                            COND = "GDN_VIEW.YEARID = " & YearId & " And (GDN_VIEW.TYPE = 'PSJOB' Or GDN_VIEW.TYPE ='JOBBALE') "
                        Else
                            COND = Replace(objwo.FORMULA, "{", " ")
                            COND = Replace(COND, "}", " ")
                            COND = Replace(COND, "[", " (")
                            COND = Replace(COND, "]", ") ")
                            COND = Replace(COND, "1=1", " ")
                            COND = Replace(COND, "GDN", "GDN_VIEW")
                            COND = Replace(COND, "gdn", "GDN_VIEW")
                        End If
                        dt = OBJ.search(" ISNULL(SUM(PCS),0),ISNULL(SUM(MTRS),0) ", "", " GDN_VIEW ", " AND " & COND & " and GDNDATE <'" & Format(dtfrom.Value, "MM/dd/yyyy") & "' AND MONTH(GDNDATE) = " & dtfrom.Value.Date.Month)
                        If dt.Rows.Count > 0 Then
                            objwo.TOTALPCS = Val(dt.Rows(0).Item(0))
                            objwo.TOTALMTRS = Val(dt.Rows(0).Item(1))
                        Else
                            objwo.TOTALPCS = 0
                            objwo.TOTALMTRS = 0
                        End If
                    End If
                End If

                If chkdate.Checked = True Then
                    getFromToDate()
                    If RBJOB.Checked = False And RBPROG.Checked = False Then objwo.FORMULA = objwo.FORMULA & " and ({@GDNDATE} in date " & fromD & " to date " & toD & ")" Else objwo.FORMULA = objwo.FORMULA & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                    objwo.period = objwo.period & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                Else
                    objwo.period = objwo.period & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If
                objwo.Show()

            Else

                Dim WHERE As String = " AND 1 = 1 "
                If cmbname.Text.Trim <> "" Then WHERE = WHERE & " AND PARTYNAMELEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "'"
                If cmbmerchant.Text.Trim <> "" Then WHERE = WHERE & " AND ITEM_NAME = '" & cmbmerchant.Text.Trim & "'"
                'If CMBCATEGORY.Text.Trim <> "" Then WHERE = WHERE & " AND CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "'"
                If TXTMERCHANT.Text.Trim <> "" Then WHERE = WHERE & " AND ITEM_NAME LIKE '%" & TXTMERCHANT.Text.Trim & "%'"
                If CMBCITY.Text.Trim <> "" Then WHERE = " AND CITY_NAME = '" & CMBCITY.Text.Trim & "'"
                If CMBSTATE.Text.Trim <> "" Then WHERE = " AND STATE_NAME = '" & CMBSTATE.Text.Trim & "'"
                If TXTBALENO.Text.Trim <> "" Then WHERE = WHERE & " AND GDN_PSDESC.GDN_PSNO = '" & cmbmerchant.Text.Trim & "'"
                If cmbtype.Text.Trim <> "" Then
                    If cmbtype.Text.Trim = "Job" Then
                        WHERE = WHERE & " AND GDN_PSDESC.GDN_TYPE IN ('JOBBALE','PSJOB')"
                    Else
                        WHERE = WHERE & " AND GDN_PSDESC.GDN_TYPE IN ('BALE','FINALPACKING')"

                    End If
                End If
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