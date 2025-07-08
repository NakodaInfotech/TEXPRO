
Imports BL

Public Class StoreStockFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS') ", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdepartment_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdepartment.Enter
        Try
            If cmbdepartment.Text.Trim = "" Then filldepartment(cmbdepartment, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdepartment_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdepartment.Validating
        Try
            If cmbdepartment.Text.Trim <> "" Then DEPARTMENTVALIDATE(cmbdepartment, e, Me)
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

    Sub fillcmb()
        Try
            dtopening.Value = DateAdd(DateInterval.Day, -1, AccFrom)

            If cmbdepartment.Text.Trim = "" Then filldepartment(cmbdepartment, edit)
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            If cmbratetype.Text.Trim = "" Then fillRATETYPE(cmbratetype, edit)
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("DEPARTMENT_name AS DEPARTMENT", "", " DEPARTMENTMASTER ", " AND DEPARTMENT_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                Dim NEWDT As DataTable = DT.DefaultView.ToTable(True, "DEPARTMENT")
                NEWDT.DefaultView.Sort = "DEPARTMENT"
                For Each dr As DataRowView In NEWDT.DefaultView
                    CLB_DEPARTMENT.Items.Add(Convert.ToString(dr("DEPARTMENT")), False)
                Next
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbratetype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbratetype.GotFocus
        Try
            If cmbratetype.Text.Trim = "" Then fillRATETYPE(cmbratetype, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbratetype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbratetype.Validating
        Try
            If cmbratetype.Text.Trim <> "" Then RATETYPEVALIDATE(cmbratetype, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StoreStockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcmb()
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Dim objwo As New StoreStockdesign
        objwo.MdiParent = MDIMain
        objwo.selfor_ss = "1=1 and {view_store_stock.material}<>'Misc.'"
        If cmbitemname.Text <> "" Then
            objwo.selfor_ss = objwo.selfor_ss & " and {view_store_stock.itemname}='" & cmbitemname.Text & "'"
        End If
        If cmbdepartment.Text <> "" Then
            objwo.selfor_ss = objwo.selfor_ss & " and {view_store_stock.department}='" & cmbdepartment.Text & "'"
        End If
        If cmbname.Text <> "" Then
            objwo.selfor_ss = objwo.selfor_ss & " and {view_store_stock.name}='" & cmbname.Text & "'"
        End If
        If cmbratetype.Text <> "" Then
            objwo.selfor_ss = objwo.selfor_ss & " and {ratetypemaster.ratetype_name}='" & cmbratetype.Text & "'"
            'Else
            '    objwo.selfor_ss = objwo.selfor_ss & " and ISNULL({ratetypemaster.ratetype_name}) "

        End If

        If chkdate.Checked = True Then
            getFromToDate()
            If Format(dtfrom.Value, "dd/MM/yyyy") < Format(dtopening.Value, "dd/MM/yyyy") Then
                objwo.OPENINGDATE = Format(dtopening.Value, "MM/dd/yyyy")
            Else
                objwo.OPENINGDATE = Format(DateAdd(DateInterval.Day, -1, dtfrom.Value), "MM/dd/yyyy")
            End If
            objwo.FROMDATE = Format(dtfrom.Value, "MM/dd/yyyy")
            objwo.TODATE = Format(dtto.Value, "MM/dd/yyyy")
            objwo.selfor_ss = objwo.selfor_ss & " and ({view_store_stock.date} in date " & fromD & " to date " & toD & ")"
            objwo.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
        Else
            objwo.OPENINGDATE = Format(DateAdd(DateInterval.Day, -1, AccFrom), "MM/dd/yyyy")
            objwo.FROMDATE = Format(AccFrom, "MM/dd/yyyy")
            objwo.TODATE = Format(AccTo, "MM/dd/yyyy")
            objwo.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
        End If


        If RBMONTHWISE.Checked = True Then
            objwo.selfor_ss = objwo.selfor_ss & " and ({view_store_stock.type}='INWARDS' OR {view_store_stock.type}='RETURNING' OR {view_store_stock.type}='OPENING')"
            'ElseIf RBCONSUMEMONTHLY.Checked = True Then
            '    objwo.selfor_ss = objwo.selfor_ss & " and ({view_store_stock.type}='ISSUE' OR {view_store_stock.type}='DESPATCH')"
            'ElseIf RBDETAILS.Checked = True Then
            '    objwo.DETAIL = True
        End If
        objwo.selfor_ss = objwo.selfor_ss & " and {view_store_stock.cmpid}=" & CmpId & " and {view_store_stock.locationid}=" & Locationid & " and {view_store_stock.yearid}=" & YearId


        objwo.Show()

    End Sub

    Private Sub cmdexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREPORT.Click
        Try
            Dim WHERECLAUSE1 As String = ""
            Dim WHERECLAUSE2 As String = ""
            Dim WHERECLAUSE3 As String = ""
            Dim CHECKED_DEPARTMENT As CheckedListBox.CheckedItemCollection = CLB_DEPARTMENT.CheckedItems
            Dim DEPARTMENT As String = ""
            For Each item As Object In CHECKED_DEPARTMENT
                If DEPARTMENT = "" Then
                    DEPARTMENT = "'" & item.ToString() & "'"
                Else
                    DEPARTMENT = DEPARTMENT & ",'" & item.ToString() & "'"
                End If
            Next item
            If DEPARTMENT <> "" Then
                WHERECLAUSE1 = WHERECLAUSE1 & " and DEPARTMENT IN (" & DEPARTMENT & ")"
                WHERECLAUSE2 = WHERECLAUSE2 & " and ({STORESTOCK_DETAILS.DEPARTMENT} IN [" & DEPARTMENT & "])"
                WHERECLAUSE2 = WHERECLAUSE2 & " and ({DEPARTMENTMASTER.DEPARTMENT_NAME} IN [" & DEPARTMENT & "])"
            End If


            If RBSTORE.Checked = True Then
                Dim OBJSTORE As New StoreStock
                OBJSTORE.MdiParent = MDIMain
                OBJSTORE.FRMSTRING = "STOCKONHAND"
                If cmbitemname.Text.Trim <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND ITEMNAME = '" & cmbitemname.Text.Trim & "'"
                If cmbdepartment.Text.Trim <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND DEPARTMENT = '" & cmbdepartment.Text.Trim & "'"
                If WHERECLAUSE1 <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & WHERECLAUSE1
                If cmbratetype.Text.Trim <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND (RATETYPE = '" & cmbratetype.Text.Trim & "' OR RATETYPE = '')"
                'If chkdate.Checked = True Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJSTORE.Show()
            ElseIf RBMONTHWISE.Checked = True Then
                Dim OBJSTORE As New StoreStockMonthly
                OBJSTORE.MdiParent = MDIMain
                If cmbitemname.Text.Trim <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND ITEMNAME = '" & cmbitemname.Text.Trim & "'"
                If cmbdepartment.Text.Trim <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND DEPARTMENT = '" & cmbdepartment.Text.Trim & "'"
                If WHERECLAUSE1 <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & WHERECLAUSE1
                If chkdate.Checked = True Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJSTORE.ITEMNAME = cmbitemname.Text.Trim
                OBJSTORE.Show()
            ElseIf RBDEPARTMENTWISE.Checked = True Then
                Dim OBJSTORE As New StoreStockdesign
                OBJSTORE.FRMSTRING = "DEPARTMENTDETAIL"
                OBJSTORE.selfor_ss = " {STORESTOCK_DETAILS.YEARID}= " & YearId & " AND {DEPARTMENTMASTER.DEPARTMENT_INVENTORY}=True "
                If cmbitemname.Text.Trim <> "" Then OBJSTORE.selfor_ss = OBJSTORE.selfor_ss + " AND {STORESTOCK_DETAILS.ITEMNAME}='" & cmbitemname.Text.Trim & "'"
                If cmbdepartment.Text.Trim <> "" Then OBJSTORE.selfor_ss = OBJSTORE.selfor_ss + " AND {STORESTOCK_DETAILS.DEPARTMENT}='" & cmbdepartment.Text.Trim & "'"
                If WHERECLAUSE2 <> "" Then OBJSTORE.selfor_ss = OBJSTORE.selfor_ss + WHERECLAUSE2
                If chkdate.CheckState = CheckState.Unchecked Then
                    OBJSTORE.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
                Else
                    OBJSTORE.FROMDATE = Format(dtfrom.Value.Date, "dd/MM/yyyy")
                    OBJSTORE.TODATE = Format(dtto.Value.Date, "dd/MM/yyyy")
                    OBJSTORE.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy")
                End If
                OBJSTORE.MdiParent = MDIMain
                OBJSTORE.Show()

            ElseIf RBDEPARTMENTWISEPURRATE.Checked = True Then
                Cursor.Current = Cursors.WaitCursor
                Dim WHERECLAUSE As String = ""
                If cmbitemname.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & cmbitemname.Text.Trim & "'"
                If cmbdepartment.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND DEPARTMENT = '" & cmbdepartment.Text.Trim & "'"
                If WHERECLAUSE1 <> "" Then WHERECLAUSE = WHERECLAUSE & WHERECLAUSE1
                Dim OBJREP As New clsReportDesigner("Store Stock Details - Avg Purchase Rate", System.AppDomain.CurrentDomain.BaseDirectory & "Store Stock Details - Avg Purchase Rate.xlsx", 2)
                If chkdate.CheckState = CheckState.Checked Then
                    OBJREP.STORESTOCKDTLS_AVGPUR_REPORT_EXCEL(CmpId, Locationid, YearId, dtfrom.Value.Date, dtto.Value.Date, chkdate.Checked, "STORE STOCK DETAILS - AVG PUR RATE", Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy"), WHERECLAUSE)
                Else
                    OBJREP.STORESTOCKDTLS_AVGPUR_REPORT_EXCEL(CmpId, Locationid, YearId, AccFrom, AccTo, chkdate.Checked, "STORE STOCK DETAILS - AVG PUR RATE", Format(AccFrom, "dd/MM/yyyy") & "-" & Format(AccTo, "dd/MM/yyyy"), WHERECLAUSE)
                End If
                Cursor.Current = Cursors.Default

            ElseIf RDBDEPRTSUMM.Checked = True Then
                Dim OBJSTORE As New StoreStockdesign
                OBJSTORE.FRMSTRING = "DEPARTMENTSUMMARY"
                OBJSTORE.selfor_ss = " {STORESTOCK_DETAILS.YEARID}= " & YearId & " AND {DEPARTMENTMASTER.DEPARTMENT_INVENTORY}=True"
                If WHERECLAUSE3 <> "" Then OBJSTORE.selfor_ss = OBJSTORE.selfor_ss & WHERECLAUSE3
                '  If cmbratetype.Text.Trim <> "" Then OBJSTORE.selfor_ss = OBJSTORE.selfor_ss & " AND {RATETYPEMASTER.RATETYPE_NAME} = '" & cmbratetype.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Unchecked Then
                    OBJSTORE.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
                Else
                    OBJSTORE.FROMDATE = Format(dtfrom.Value.Date, "dd/MM/yyyy")
                    OBJSTORE.TODATE = Format(dtto.Value.Date, "dd/MM/yyyy")
                    OBJSTORE.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy")
                End If
                OBJSTORE.MdiParent = MDIMain
                OBJSTORE.Show()

            ElseIf RBDEPARTMENTSUMMPURRATE.Checked = True Then
                Cursor.Current = Cursors.WaitCursor
                Dim WHERECLAUSE As String = ""
                If cmbitemname.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ITEMNAME = '" & cmbitemname.Text.Trim & "'"
                If cmbdepartment.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND DEPARTMENT = '" & cmbdepartment.Text.Trim & "'"
                If WHERECLAUSE1 <> "" Then WHERECLAUSE = WHERECLAUSE & WHERECLAUSE1
                Dim OBJREP As New clsReportDesigner("Store Stock Summ - Avg Purchase Rate", System.AppDomain.CurrentDomain.BaseDirectory & "Store Stock Summ - Avg Purchase Rate.xlsx", 2)
                If chkdate.CheckState = CheckState.Checked Then
                    OBJREP.STORESTOCKSUMM_AVGPUR_REPORT_EXCEL(CmpId, Locationid, YearId, dtfrom.Value.Date, dtto.Value.Date, chkdate.Checked, "STORE STOCK SUMM - AVG PUR RATE", Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy"), WHERECLAUSE)
                Else
                    OBJREP.STORESTOCKSUMM_AVGPUR_REPORT_EXCEL(CmpId, Locationid, YearId, AccFrom, AccTo, chkdate.Checked, "STORE STOCK SUMM - AVG PUR RATE", Format(AccFrom, "dd/MM/yyyy") & "-" & Format(AccTo, "dd/MM/yyyy"), WHERECLAUSE)
                End If
                Cursor.Current = Cursors.Default

            ElseIf RBCONSUMED.Checked = True Then
                Dim OBJSTORE As New ConsumptionDetails
                If cmbitemname.Text.Trim <> "" Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND ITEMMASTER.ITEM_NAME = '" & cmbitemname.Text.Trim & "'"
                If chkdate.Checked = True Then OBJSTORE.WHERECLAUSE = OBJSTORE.WHERECLAUSE & " AND CONSUMPTION.CONSUME_date >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND CONSUMPTION.CONSUME_date <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJSTORE.MdiParent = MDIMain
                OBJSTORE.Show()

            ElseIf RBDEPTCONSUMED.Checked = True Or RBDEPTCONSUMEDSUMM.Checked = True Then
                Dim OBJSTORE As New StoreStockdesign
                OBJSTORE.FRMSTRING = "DEPARTMENTCONSUME"
                Dim WHERECLAUSE As String = "{CONSUMPTION.CONSUME_YEARID} = " & YearId
                If cmbitemname.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND {ITEMMASTER.ITEM_NAME} = '" & cmbitemname.Text.Trim & "'"
                If RBDEPTCONSUMEDSUMM.Checked = True Then OBJSTORE.CONSUMESUMM = 1

                If cmbdepartment.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND {DEPARTMENTMASTER.DEPARTMENT_NAME} = '" & cmbdepartment.Text.Trim & "'"
                If WHERECLAUSE3 <> "" Then WHERECLAUSE = WHERECLAUSE & WHERECLAUSE3
                If TXTISSUETO.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND {CONSUMPTION.CONSUME_ISSUETO}= '" & TXTISSUETO.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Unchecked Then
                    OBJSTORE.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
                Else
                    getFromToDate()
                    OBJSTORE.FROMDATE = Format(dtfrom.Value.Date, "dd/MM/yyyy")
                    OBJSTORE.TODATE = Format(dtto.Value.Date, "dd/MM/yyyy")
                    OBJSTORE.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy")
                    WHERECLAUSE = WHERECLAUSE & " AND ({@DATE} in date " & fromD & " to date " & toD & ")"
                End If
                OBJSTORE.selfor_ss = WHERECLAUSE
                OBJSTORE.MdiParent = MDIMain
                OBJSTORE.Show()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class