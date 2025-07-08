
Imports BL

Public Class JobPackingFilter

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

            OBJFPS.SELFORMULA = " {VIEW_BALE_DETAIL.YEARID}=" & YearId & " AND ({VIEW_BALE_DETAIL.tp} = 'job') "

            If cmbname.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {VIEW_BALE_DETAIL.NAME}='" & cmbname.Text.Trim & "'"
            If cmbmerchant.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {VIEW_BALE_DETAIL.MERCHANT}='" & cmbmerchant.Text.Trim & "'"
            If TXTMERCHANT.Text.Trim <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {VIEW_BALE_DETAIL.MERCHANT} LIKE '*" & TXTMERCHANT.Text.Trim & "*'"
            If Val(TXTBALENO.Text.Trim) <> 0 Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and {VIEW_BALE_DETAIL.BALENO}=" & Val(TXTBALENO.Text.Trim)


            Dim CHECKED_GRADE As CheckedListBox.CheckedItemCollection = CLB_GRADE.CheckedItems
            Dim PIECETYPE As String = ""
            For Each item As Object In CHECKED_GRADE
                If PIECETYPE = "" Then
                    PIECETYPE = "'" & item.ToString() & "'"
                Else
                    PIECETYPE = PIECETYPE & ",'" & item.ToString() & "'"
                End If
            Next item

            If PIECETYPE <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({VIEW_BALE_DETAIL.PIECETYPE} IN [" & PIECETYPE & "])"



            'Dim CHECKED_DEPARTMENT As CheckedListBox.CheckedItemCollection = CLB_DEPARTMENT.CheckedItems
            'Dim DEPARTMENT As String = ""
            'For Each item As Object In CHECKED_DEPARTMENT
            '    If DEPARTMENT = "" Then
            '        DEPARTMENT = "'" & item.ToString() & "'"
            '    Else
            '        DEPARTMENT = DEPARTMENT & ",'" & item.ToString() & "'"
            '    End If
            'Next item
            'If DEPARTMENT <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({BALE_VIEW.DEPARTMENT} IN [" & DEPARTMENT & "])"


            'Dim CHECKED_CATEGORY As CheckedListBox.CheckedItemCollection = CLB_CATEGORY.CheckedItems
            'Dim CATEGORY As String = ""
            'For Each item As Object In CHECKED_CATEGORY
            '    If CATEGORY = "" Then
            '        CATEGORY = "'" & item.ToString() & "'"
            '    Else
            '        CATEGORY = CATEGORY & ",'" & item.ToString() & "'"
            '    End If
            'Next item
            'If CATEGORY <> "" Then OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({BALE_VIEW.CATEGORY} IN [" & CATEGORY & "])"



            If chkdate.Checked = True Then
                getFromToDate()
                OBJFPS.SELFORMULA = OBJFPS.SELFORMULA & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                OBJFPS.PERIOD = OBJFPS.PERIOD & Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                OBJFPS.PERIOD = OBJFPS.PERIOD & Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If rdbdetail.Checked = True Then
                OBJFPS.FRMSTRING = "PSDTLS"
            ElseIf RDBITEMWISE.Checked = True Then
                OBJFPS.FRMSTRING = "PSMERCHANT"
            ElseIf RDBPARTYWISEDETAILS.Checked = True Then
                OBJFPS.FRMSTRING = "PSPARTYDTLS"
            ElseIf RDBPARTYMERCHANTSUMM.Checked = True Then
                OBJFPS.FRMSTRING = "PSPARTYMERCHANTSUMM"
            End If
            OBJFPS.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class