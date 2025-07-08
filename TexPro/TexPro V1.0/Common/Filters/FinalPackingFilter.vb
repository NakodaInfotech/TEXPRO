
Imports BL

Public Class FinalPackingFilter

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
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
            If CMBPROCESSTYPE.Text.Trim = "" Then FILLPROCESSTYPE(CMBPROCESSTYPE, False)

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

    Private Sub FinalPackingFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FinalPackingFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcmb()
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            Dim OBJFPS As New FPSDESIGN
            OBJFPS.MdiParent = MDIMain

            OBJFPS.SELFORMULA = " {FINALPACKINGSLIP.FPS_YEARID}=" & YearId

            If cmbname.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {LEDGERS.ACC_CMPNAME}='" & cmbname.Text.Trim & "'"
            If cmbmerchant.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {ITEMMASTER.ITEM_NAME}='" & cmbmerchant.Text.Trim & "'"
            If TXTMERCHANT.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {ITEMMASTER.ITEM_NAME} LIKE '*" & TXTMERCHANT.Text.Trim & "*'"
            If Val(TXTBALENO.Text.Trim) <> 0 Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {FINALPACKINGSLIP.FPS_NO}=" & Val(TXTBALENO.Text.Trim)
            If CMBDYEING.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {DYEINGRECIPE.DYEING_NO}='" & CMBDYEING.Text.Trim & "'"
            If TXTPROGNO.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {FINALPACKINGSLIP.FPS_PROGNO}=" & Val(TXTPROGNO.Text.Trim)
            If TXTJOBNO.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {FINALPACKINGSLIP.FPS_JOBNO}='" & TXTJOBNO.Text.Trim & "'"
            If TXTORDERNO.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {FINALPACKINGSLIP.FPS_ORDERNO}='" & TXTORDERNO.Text.Trim & "'"
            If CMBFROM.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {PROCESSMASTER.PROCESS_NAME}='" & CMBFROM.Text.Trim & "'"
            If CMBPROCESSTYPE.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {PROCESSTYPEMASTER.PROCESSTYPE_NAME}='" & CMBPROCESSTYPE.Text.Trim & "'"


            Dim CHECKED_GRADE As CheckedListBox.CheckedItemCollection = CLB_GRADE.CheckedItems
            Dim PIECETYPE As String = ""
            For Each item As Object In CHECKED_GRADE
                If PIECETYPE = "" Then
                    PIECETYPE = "'" & item.ToString() & "'"
                Else
                    PIECETYPE = PIECETYPE & ",'" & item.ToString() & "'"
                End If
            Next item

            If PIECETYPE <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({PIECETYPEMASTER.PIECETYPE_NAME} IN [" & PIECETYPE & "])"



            Dim CHECKED_DEPARTMENT As CheckedListBox.CheckedItemCollection = CLB_DEPARTMENT.CheckedItems
            Dim DEPARTMENT As String = ""
            For Each item As Object In CHECKED_DEPARTMENT
                If DEPARTMENT = "" Then
                    DEPARTMENT = "'" & item.ToString() & "'"
                Else
                    DEPARTMENT = DEPARTMENT & ",'" & item.ToString() & "'"
                End If
            Next item
            If DEPARTMENT <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({DEPARTMENTMASTER.DEPARTMENT_NAME} IN [" & DEPARTMENT & "])"


            Dim CHECKED_CATEGORY As CheckedListBox.CheckedItemCollection = CLB_CATEGORY.CheckedItems
            Dim CATEGORY As String = ""
            For Each item As Object In CHECKED_CATEGORY
                If CATEGORY = "" Then
                    CATEGORY = "'" & item.ToString() & "'"
                Else
                    CATEGORY = CATEGORY & ",'" & item.ToString() & "'"
                End If
            Next item
            If CATEGORY <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({CATEGORYMASTER.CATEGORY_NAME} IN [" & CATEGORY & "])"



            If chkdate.Checked = True Then
                getFromToDate()
                OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                OBJFPS.PERIOD = OBJFPS.PERIOD & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                OBJFPS.PERIOD = OBJFPS.PERIOD & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If rdbdetail.Checked = True Then
                OBJFPS.FRMSTRING = "FPSDTLS"
            ElseIf RDBITEMWISE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Checked Then OBJFPS.FRMSTRING = "FPSITEMSUMM" Else OBJFPS.FRMSTRING = "FPSITEMDTLS"
            ElseIf RDBPROCESSTYPESUMM.Checked = True Then
                OBJFPS.FRMSTRING = "FPSPROCESSTYPE"
            ElseIf RDBLOTDETAILS.Checked = True Then
                OBJFPS.FRMSTRING = "FPSLOTSUMM"
            ElseIf RDBCATEGORYWISE.Checked = True Then
                OBJFPS.FRMSTRING = "FPSCATEGORY"
            ElseIf RDBDEPTWISE.Checked = True Then
                OBJFPS.FRMSTRING = "FPSDEPARTMENT"
            ElseIf RDBGRADEWISE.Checked = True Then
                OBJFPS.FRMSTRING = "FPSPIECETYPE"
            End If
            OBJFPS.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class