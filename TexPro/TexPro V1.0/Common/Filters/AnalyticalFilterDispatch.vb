
Imports System.ComponentModel
Imports BL

Public Class AnalyticalFilterDispatch

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillcmb()
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
            If CMBSTATE.Text.Trim = "" Then fillSTATE(CMBSTATE)
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " AND GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'AGENT'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND GROUP_SECONDARY = 'Sundry Debtors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")


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
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
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
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try

            If Val(TXTTOP.Text.Trim) = 0 And (RDBTOPPARTY.Checked = True Or RDBTOPCITY.Checked = True Or RDBTOPMERCHANT.Checked = True Or RDBTOPAGENT.Checked = True Or RDBTOPSTATE.Checked = True) Then
                MsgBox("Enter Value", MsgBoxStyle.Critical)
                TXTTOP.Focus()
                Exit Sub
            End If

            Dim WHERECLAUSE As String = " AND GDN.GDN_YEARID = " & YearId
            Dim FRMSTRING As String = ""
            Dim PERIOD As String = ""

            If cmbmerchant.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(ITEMMASTER.item_name, '') ='" & cmbmerchant.Text.Trim & "'"
            If TXTMERCHANT.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(ITEMMASTER.item_name, '') LIKE '*" & TXTMERCHANT.Text.Trim & "*'"
            If CMBCITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(CITYMASTER.city_name, '') ='" & CMBCITY.Text.Trim.Trim & "'"
            If CMBSTATE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(STATEMASTER.state_name, '') ='" & CMBSTATE.Text.Trim.Trim & "'"
            If CMBAGENT.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(AGENTLEDGERS.Acc_cmpname, '') ='" & CMBAGENT.Text.Trim & "'"

            If CMBTYPE.Text.Trim = "JOB" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(GDN_PSDESC.GDN_TYPE, '') ='PSJOB'"
            If CMBTYPE.Text.Trim = "ACTUAL DISPATCH" Then WHERECLAUSE = WHERECLAUSE & " and ISNULL(GDN_PSDESC.GDN_TYPE, '') <>'PSJOB'"

            If chkdate.CheckState = CheckState.Checked Then
                PERIOD = Format(Convert.ToDateTime(dtfrom.Value.Date).Date, "dd/MM/yyyy") & "-" & Format(Convert.ToDateTime(dtto.Value.Date).Date, "dd/MM/yyyy")
                WHERECLAUSE = WHERECLAUSE & " AND GDN.GDN_DATE >='" & Format(Convert.ToDateTime(dtfrom.Value.Date).Date, "MM/dd/yyyy") & "' AND GDN.GDN_DATE <='" & Format(Convert.ToDateTime(dtto.Value.Date).Date, "MM/dd/yyyy") & "'"
            Else
                PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
            End If


            Dim CHECKED_GRADE As CheckedListBox.CheckedItemCollection = CLB_GRADE.CheckedItems
            Dim PIECETYPE As String = ""
            For Each item As Object In CHECKED_GRADE
                If PIECETYPE = "" Then
                    PIECETYPE = "'" & item.ToString() & "'"
                Else
                    PIECETYPE = PIECETYPE & ",'" & item.ToString() & "'"
                End If
            Next item

            If PIECETYPE <> "" Then WHERECLAUSE = WHERECLAUSE & " and (PIECETYPEMASTER.PIECETYPE_NAME) IN (" & PIECETYPE & "))"



            Dim CHECKED_DEPARTMENT As CheckedListBox.CheckedItemCollection = CLB_DEPARTMENT.CheckedItems
            Dim DEPARTMENT As String = ""
            For Each item As Object In CHECKED_DEPARTMENT
                If DEPARTMENT = "" Then
                    DEPARTMENT = "'" & item.ToString() & "'"
                Else
                    DEPARTMENT = DEPARTMENT & ",'" & item.ToString() & "'"
                End If
            Next item
            If DEPARTMENT <> "" Then WHERECLAUSE = WHERECLAUSE & " and ((DEPARTMENTMASTER.DEPARTMENT_NAME, '') IN (" & DEPARTMENT & "))"


            Dim CHECKED_CATEGORY As CheckedListBox.CheckedItemCollection = CLB_CATEGORY.CheckedItems
            Dim CATEGORY As String = ""
            For Each item As Object In CHECKED_CATEGORY
                If CATEGORY = "" Then
                    CATEGORY = "'" & item.ToString() & "'"
                Else
                    CATEGORY = CATEGORY & ",'" & item.ToString() & "'"
                End If
            Next item
            If CATEGORY <> "" Then WHERECLAUSE = WHERECLAUSE & " and ((CATEGORYMASTER.CATEGORY_NAME) IN (" & CATEGORY & "))"



            Dim OBJCMN As New ClsCommon()
            Dim dt As New DataTable
            If RDBTOPPARTY.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(PARTYNAME.Acc_cmpname, '') AS PARTYNAME, ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) AS MTRS, ISNULL(SUM(GDN_PSDESC.GDN_PCS), 0) AS PCS, ISNULL(SUM((MERCHANT_RATE*GDN_PSDESC.GDN_PCS)),0) ", "", " PIECETYPEMASTER INNER JOIN MERCHANTPRICELIST ON PIECETYPEMASTER.PIECETYPE_id = MERCHANTPRICELIST.MERCHANT_PIECETYPEID RIGHT OUTER JOIN DEPARTMENTMASTER RIGHT OUTER JOIN CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER ON CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid ON DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN QUALITYMASTER RIGHT OUTER JOIN FINALPACKINGSLIP RIGHT OUTER JOIN LEDGERS AS AGENTLEDGERS RIGHT OUTER JOIN GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID ON AGENTLEDGERS.Acc_id = GDN.GDN_AGENTID ON  FINALPACKINGSLIP.FPS_NO = GDN_PSDESC.GDN_PSNO AND FINALPACKINGSLIP.FPS_YEARID = GDN_PSDESC.GDN_YEARID LEFT OUTER JOIN CITYMASTER RIGHT OUTER JOIN STATEMASTER RIGHT OUTER JOIN LEDGERS AS PARTYNAME ON STATEMASTER.state_id = PARTYNAME.Acc_stateid ON CITYMASTER.city_id = PARTYNAME.Acc_cityid ON GDN_PSDESC.GDN_PARTYID = PARTYNAME.Acc_id ON  QUALITYMASTER.QUALITY_id = GDN_PSDESC.GDN_QUALITYID ON ITEMMASTER.item_id = GDN_PSDESC.GDN_MERCHANTID ON MERCHANTPRICELIST.MERCHANT_ID = ITEMMASTER.item_id AND PIECETYPEMASTER.PIECETYPE_id = GDN_PSDESC.GDN_PIECETYPEID RIGHT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_transid = TRANSLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(PARTYNAME.Acc_cmpname, '') HAVING  ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY MTRS DESC")
                FRMSTRING = "PARTYWISE"

            ElseIf RDBTOPMERCHANT.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(ITEMMASTER.item_name, '') as MERCHANT, ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) AS MTRS, ISNULL(SUM(GDN_PSDESC.GDN_PCS), 0) AS PCS, ISNULL(SUM((MERCHANT_RATE*GDN_PSDESC.GDN_PCS)),0) ", "", " PIECETYPEMASTER INNER JOIN MERCHANTPRICELIST ON PIECETYPEMASTER.PIECETYPE_id = MERCHANTPRICELIST.MERCHANT_PIECETYPEID RIGHT OUTER JOIN DEPARTMENTMASTER RIGHT OUTER JOIN CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER ON CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid ON DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN QUALITYMASTER RIGHT OUTER JOIN FINALPACKINGSLIP RIGHT OUTER JOIN LEDGERS AS AGENTLEDGERS RIGHT OUTER JOIN GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID ON AGENTLEDGERS.Acc_id = GDN.GDN_AGENTID ON  FINALPACKINGSLIP.FPS_NO = GDN_PSDESC.GDN_PSNO AND FINALPACKINGSLIP.FPS_YEARID = GDN_PSDESC.GDN_YEARID LEFT OUTER JOIN CITYMASTER RIGHT OUTER JOIN STATEMASTER RIGHT OUTER JOIN LEDGERS AS PARTYNAME ON STATEMASTER.state_id = PARTYNAME.Acc_stateid ON CITYMASTER.city_id = PARTYNAME.Acc_cityid ON GDN_PSDESC.GDN_PARTYID = PARTYNAME.Acc_id ON  QUALITYMASTER.QUALITY_id = GDN_PSDESC.GDN_QUALITYID ON ITEMMASTER.item_id = GDN_PSDESC.GDN_MERCHANTID ON MERCHANTPRICELIST.MERCHANT_ID = ITEMMASTER.item_id AND PIECETYPEMASTER.PIECETYPE_id = GDN_PSDESC.GDN_PIECETYPEID RIGHT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_transid = TRANSLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(ITEMMASTER.item_name, '') HAVING  ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY MTRS DESC")
                FRMSTRING = "MERCHANTWISE"

            ElseIf RDBTOPCITY.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(CITYMASTER.city_name, '') AS CITYNAME, ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) AS MTRS, ISNULL(SUM(GDN_PSDESC.GDN_PCS), 0) AS PCS, ISNULL(SUM((MERCHANT_RATE*GDN_PSDESC.GDN_PCS)),0) ", "", " PIECETYPEMASTER INNER JOIN MERCHANTPRICELIST ON PIECETYPEMASTER.PIECETYPE_id = MERCHANTPRICELIST.MERCHANT_PIECETYPEID RIGHT OUTER JOIN DEPARTMENTMASTER RIGHT OUTER JOIN CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER ON CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid ON DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN QUALITYMASTER RIGHT OUTER JOIN FINALPACKINGSLIP RIGHT OUTER JOIN LEDGERS AS AGENTLEDGERS RIGHT OUTER JOIN GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID ON AGENTLEDGERS.Acc_id = GDN.GDN_AGENTID ON  FINALPACKINGSLIP.FPS_NO = GDN_PSDESC.GDN_PSNO AND FINALPACKINGSLIP.FPS_YEARID = GDN_PSDESC.GDN_YEARID LEFT OUTER JOIN CITYMASTER RIGHT OUTER JOIN STATEMASTER RIGHT OUTER JOIN LEDGERS AS PARTYNAME ON STATEMASTER.state_id = PARTYNAME.Acc_stateid ON CITYMASTER.city_id = PARTYNAME.Acc_cityid ON GDN_PSDESC.GDN_PARTYID = PARTYNAME.Acc_id ON  QUALITYMASTER.QUALITY_id = GDN_PSDESC.GDN_QUALITYID ON ITEMMASTER.item_id = GDN_PSDESC.GDN_MERCHANTID ON MERCHANTPRICELIST.MERCHANT_ID = ITEMMASTER.item_id AND PIECETYPEMASTER.PIECETYPE_id = GDN_PSDESC.GDN_PIECETYPEID RIGHT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_transid = TRANSLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(CITYMASTER.city_name, '') HAVING  ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY MTRS DESC")
                FRMSTRING = "CITYWISE"

            ElseIf RDBTOPSTATE.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) AS MTRS, ISNULL(SUM(GDN_PSDESC.GDN_PCS), 0) AS PCS, ISNULL(SUM((MERCHANT_RATE*GDN_PSDESC.GDN_PCS)),0) ", "", " PIECETYPEMASTER INNER JOIN MERCHANTPRICELIST ON PIECETYPEMASTER.PIECETYPE_id = MERCHANTPRICELIST.MERCHANT_PIECETYPEID RIGHT OUTER JOIN DEPARTMENTMASTER RIGHT OUTER JOIN CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER ON CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid ON DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN QUALITYMASTER RIGHT OUTER JOIN FINALPACKINGSLIP RIGHT OUTER JOIN LEDGERS AS AGENTLEDGERS RIGHT OUTER JOIN GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID ON AGENTLEDGERS.Acc_id = GDN.GDN_AGENTID ON  FINALPACKINGSLIP.FPS_NO = GDN_PSDESC.GDN_PSNO AND FINALPACKINGSLIP.FPS_YEARID = GDN_PSDESC.GDN_YEARID LEFT OUTER JOIN CITYMASTER RIGHT OUTER JOIN STATEMASTER RIGHT OUTER JOIN LEDGERS AS PARTYNAME ON STATEMASTER.state_id = PARTYNAME.Acc_stateid ON CITYMASTER.city_id = PARTYNAME.Acc_cityid ON GDN_PSDESC.GDN_PARTYID = PARTYNAME.Acc_id ON  QUALITYMASTER.QUALITY_id = GDN_PSDESC.GDN_QUALITYID ON ITEMMASTER.item_id = GDN_PSDESC.GDN_MERCHANTID ON MERCHANTPRICELIST.MERCHANT_ID = ITEMMASTER.item_id AND PIECETYPEMASTER.PIECETYPE_id = GDN_PSDESC.GDN_PIECETYPEID RIGHT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_transid = TRANSLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(STATEMASTER.state_name, '') HAVING  ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY MTRS DESC")
                FRMSTRING = "STATEWISE"

            ElseIf RDBTOPAGENT.Checked = True Then
                dt = OBJCMN.search(" TOP " & Val(TXTTOP.Text.Trim) & " ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENTNAME, ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) AS MTRS, ISNULL(SUM(GDN_PSDESC.GDN_PCS), 0) AS PCS, ISNULL(SUM((MERCHANT_RATE*GDN_PSDESC.GDN_PCS)),0) ", "", " PIECETYPEMASTER INNER JOIN MERCHANTPRICELIST ON PIECETYPEMASTER.PIECETYPE_id = MERCHANTPRICELIST.MERCHANT_PIECETYPEID RIGHT OUTER JOIN DEPARTMENTMASTER RIGHT OUTER JOIN CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER ON CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid ON DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN QUALITYMASTER RIGHT OUTER JOIN FINALPACKINGSLIP RIGHT OUTER JOIN LEDGERS AS AGENTLEDGERS RIGHT OUTER JOIN GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID ON AGENTLEDGERS.Acc_id = GDN.GDN_AGENTID ON  FINALPACKINGSLIP.FPS_NO = GDN_PSDESC.GDN_PSNO AND FINALPACKINGSLIP.FPS_YEARID = GDN_PSDESC.GDN_YEARID LEFT OUTER JOIN CITYMASTER RIGHT OUTER JOIN STATEMASTER RIGHT OUTER JOIN LEDGERS AS PARTYNAME ON STATEMASTER.state_id = PARTYNAME.Acc_stateid ON CITYMASTER.city_id = PARTYNAME.Acc_cityid ON GDN_PSDESC.GDN_PARTYID = PARTYNAME.Acc_id ON  QUALITYMASTER.QUALITY_id = GDN_PSDESC.GDN_QUALITYID ON ITEMMASTER.item_id = GDN_PSDESC.GDN_MERCHANTID ON MERCHANTPRICELIST.MERCHANT_ID = ITEMMASTER.item_id AND PIECETYPEMASTER.PIECETYPE_id = GDN_PSDESC.GDN_PIECETYPEID RIGHT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_transid = TRANSLEDGERS.Acc_id ", WHERECLAUSE & " GROUP BY ISNULL(AGENTLEDGERS.Acc_cmpname, '') HAVING  ISNULL(SUM(GDN_PSDESC.GDN_MTRS), 0) > " & Val(TXTMTRSGREATER.Text.Trim) & " ORDER BY MTRS DESC")
                FRMSTRING = "AGENTWISE"

            End If

            Dim objrep As New clsReportDesigner("Analytical Report", System.AppDomain.CurrentDomain.BaseDirectory & "Analytical Report.xlsx", 2)
            objrep.CHART_REPORT_EXCEL(dt, CmpId, Locationid, YearId, "ANALYTICAL REPORT", FRMSTRING, PERIOD)

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
End Class