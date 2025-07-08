
Imports System.ComponentModel
Imports BL

Public Class BaleStockFilter

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
            If cmbratetype.Text.Trim = "" Then fillRATETYPE(cmbratetype, edit)
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
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

            DT = OBJCMN.search("SUBCATEGORY_name AS SUBCATEGORY", "", " SUBCATEGORYMASTER ", " AND SUBCATEGORY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                Dim NEWDT As DataTable = DT.DefaultView.ToTable(True, "SUBCATEGORY")
                NEWDT.DefaultView.Sort = "SUBCATEGORY"
                For Each dr As DataRowView In NEWDT.DefaultView
                    CLB_SUBCATEGORY.Items.Add(Convert.ToString(dr("SUBCATEGORY")), False)
                Next
            End If

            DT = OBJCMN.search("FOLD_name AS FOLD", "", " FOLDMASTER ", " AND FOLD_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                Dim NEWDT As DataTable = DT.DefaultView.ToTable(True, "FOLD")
                NEWDT.DefaultView.Sort = "FOLD"
                For Each dr As DataRowView In NEWDT.DefaultView
                    CLB_FOLD.Items.Add(Convert.ToString(dr("FOLD")), False)
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

    Private Sub StoreStockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcmb()
        cmbtype.SelectedIndex = (0)
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            Dim objwo As New FPSDESIGN
            objwo.MdiParent = MDIMain
            objwo.SELFORMULA = "1=1"

            If cmbmerchant.Text.Trim <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.merchant}='" & cmbmerchant.Text & "'"
            'If CMBCATEGORY.Text.Trim <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.CATEGORY}='" & CMBCATEGORY.Text & "'"
            If TXTMERCHANT.Text.Trim <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.merchant} LIKE '*" & TXTMERCHANT.Text & "*'"
            If TXTBALENO.Text.Trim <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.BALENO}=" & TXTBALENO.Text
            If cmbname.Text.Trim <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.name}='" & cmbname.Text & "'"
            If cmbratetype.Text.Trim <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.name}='" & cmbname.Text & "'"

            Dim CHECKED_GRADE As CheckedListBox.CheckedItemCollection = CLB_GRADE.CheckedItems
            Dim PIECETYPE As String = ""
            For Each item As Object In CHECKED_GRADE
                If PIECETYPE = "" Then
                    PIECETYPE = "'" & item.ToString() & "'"
                Else
                    PIECETYPE = PIECETYPE & ",'" & item.ToString() & "'"
                End If
            Next item

            If PIECETYPE <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and ({BALESTOCK_VIEW.PIECETYPE} IN [" & PIECETYPE & "])"



            Dim CHECKED_DEPARTMENT As CheckedListBox.CheckedItemCollection = CLB_DEPARTMENT.CheckedItems
            Dim DEPARTMENT As String = ""
            For Each item As Object In CHECKED_DEPARTMENT
                If DEPARTMENT = "" Then
                    DEPARTMENT = "'" & item.ToString() & "'"
                Else
                    DEPARTMENT = DEPARTMENT & ",'" & item.ToString() & "'"
                End If
            Next item
            If DEPARTMENT <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and ({BALESTOCK_VIEW.DEPARTMENT} IN [" & DEPARTMENT & "])"


            Dim CHECKED_CATEGORY As CheckedListBox.CheckedItemCollection = CLB_CATEGORY.CheckedItems
            Dim CATEGORY As String = ""
            For Each item As Object In CHECKED_CATEGORY
                If CATEGORY = "" Then
                    CATEGORY = "'" & item.ToString() & "'"
                Else
                    CATEGORY = CATEGORY & ",'" & item.ToString() & "'"
                End If
            Next item
            If CATEGORY <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and ({BALESTOCK_VIEW.CATEGORY} IN [" & CATEGORY & "])"



            Dim CHECKED_SUBCATEGORY As CheckedListBox.CheckedItemCollection = CLB_SUBCATEGORY.CheckedItems
            Dim SUBCATEGORY As String = ""
            For Each item As Object In CHECKED_SUBCATEGORY
                If SUBCATEGORY = "" Then
                    SUBCATEGORY = "'" & item.ToString() & "'"
                Else
                    SUBCATEGORY = SUBCATEGORY & ",'" & item.ToString() & "'"
                End If
            Next item
            If SUBCATEGORY <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and ({BALESTOCK_VIEW.SUBCATEGORY} IN [" & SUBCATEGORY & "])"



            Dim CHECKED_FOLD As CheckedListBox.CheckedItemCollection = CLB_FOLD.CheckedItems
            Dim FOLD As String = ""
            For Each item As Object In CHECKED_FOLD
                If FOLD = "" Then
                    FOLD = "'" & item.ToString() & "'"
                Else
                    FOLD = FOLD & ",'" & item.ToString() & "'"
                End If
            Next item
            If FOLD <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and ({BALESTOCK_VIEW.FOLD} IN [" & FOLD & "])"




            If TXTJOBNO.Text.Trim <> "" Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.JOBNO}='" & TXTJOBNO.Text & "'"
            If chkdate.Checked = True Then
                getFromToDate()
                objwo.SELFORMULA = objwo.SELFORMULA & " and ({BALESTOCK_VIEW.date} in date " & fromD & " to date " & toD & ")"
                objwo.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                objwo.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                If RDBSTOCKINHAND.Checked = True Then objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.CHALLANNO}=0 "
            End If



            If cmbtype.Text.Trim = "Final Packing" Then
                objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.type} IN ['BALE','FINALPACKING'] "
            ElseIf cmbtype.Text.Trim = "Job" Then
                objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.type} IN ['JOBBALE','PSJOB'] "
            End If

            objwo.SELFORMULA = objwo.SELFORMULA & " and {BALESTOCK_VIEW.yearid}=" & YearId


            objwo.BALEFILTER = ""
            If rdbdetail.Checked = True Then
                If RDBSTOCK.Checked = True Then
                    objwo.FRMSTRING = "BALEREGISTER"
                ElseIf RDBSTOCKINHAND.Checked = True Then
                    If CHKVALUE.CheckState = CheckState.Unchecked Then
                        objwo.FRMSTRING = "FULLDETAILS"
                    Else
                        objwo.FRMSTRING = "FULLDETAILSVALUE"
                    End If
                End If
            ElseIf RBCUTWISE.Checked = True Then
                objwo.FRMSTRING = "CUTWISE"
            ElseIf RBMERCHANT.Checked = True Then
                objwo.FRMSTRING = "MERCHANTWISE"
            ElseIf RBRATE.Checked = True Then
                objwo.FRMSTRING = "RATEREPORT"
            ElseIf RadioMerchantDetail.Checked = True Then
                objwo.FRMSTRING = "MERCHANTWISEDETAIL"
            ElseIf RDBDESIGN.Checked = True Then
                objwo.FRMSTRING = "DESIGNWISEDETAIL"
            ElseIf RBDEPTWISE.Checked = True Then
                objwo.FRMSTRING = "DEPTWISEDETAIL"
            ElseIf RBDEPTSUMM.Checked = True Then
                objwo.FRMSTRING = "DEPTWISESUMM"
            ElseIf RBMERCHANTNOTOTAL.Checked = True Then
                objwo.FRMSTRING = "MERCHANTWISENOTOTAL"
            ElseIf RBJOBWISE.Checked = True Then
                objwo.FRMSTRING = "JOBWISE"
            ElseIf RBJOBSUMM.Checked = True Then
                objwo.FRMSTRING = "JOBSUMM"
            ElseIf RDBLOTDETAILS.Checked = True Then
                objwo.FRMSTRING = "LOTBALESTOCK"
            ElseIf RBCATEGORYNOTOTAL.Checked = True Then
                objwo.FRMSTRING = "CATEGORYWISENOTOTAL"
            ElseIf RBDEPARTMENTNOTOTAL.Checked = True Then
                objwo.FRMSTRING = "DEPARTMENTWISENOTOTAL"
            ElseIf RBGRADENOTOTAL.Checked = True Then
                objwo.FRMSTRING = "GRADEWISENOTOTAL"
            End If

            objwo.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbratetype_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbratetype.Enter
        Try
            If cmbratetype.Text.Trim = "" Then fillRATETYPE(cmbratetype, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbratetype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbratetype.Validating
        Try
            If cmbratetype.Text.Trim <> "" Then RATETYPEVALIDATE(cmbratetype, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RDBSTOCKINHAND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBSTOCKINHAND.CheckedChanged
        Try
            RBRATE.Visible = RDBSTOCKINHAND.Checked
            If RBRATE.Visible = False Then
                RBRATE.Checked = False
                rdbdetail.Checked = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBSTOCK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBSTOCK.CheckedChanged
        Try
            If RDBSTOCK.Checked = True Then
                RadioMerchantDetail.Visible = False
                RadioMerchantDetail.Checked = False
                RDBDESIGN.Visible = False
                RDBDESIGN.Checked = False
                'RBJOBWISE.Visible = False
                'RBJOBWISE.Checked = False
            Else
                RadioMerchantDetail.Visible = True
                RDBDESIGN.Visible = True
                'RBJOBWISE.Visible = True
            End If

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