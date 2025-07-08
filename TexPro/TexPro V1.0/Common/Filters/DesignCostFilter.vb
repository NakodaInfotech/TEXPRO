
Imports BL

Public Class DesignCostFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub DesignCostFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim formula As String = "{MFGMASTER2.MFG_CMPID}= " & CmpId & " and {MFGMASTER2.MFG_LOCATIONID}= " & Locationid & " and {MFGMASTER2.MFG_YEARID}= " & YearId
            If cmbprocess.Text.Trim <> "" Then formula = formula & " and {PROCESSMASTER.PROCESS_NAME}='" & cmbprocess.Text.Trim & "'"
            If cmbMerchant.Text.Trim <> "" Then formula = formula & " and {ITEMMASTER.item_name}='" & cmbMerchant.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then formula = formula & " and {DESIGNRECIPE.DESIGN_NO}='" & CMBDESIGN.Text.Trim & "'"
            If CMBJOB.Text.Trim <> "" Then formula = formula & " and {MFGMASTER2.MFG_JOBNO}='" & CMBJOB.Text.Trim & "'"
            If CMBDEPARTMENT.Text.Trim <> "" Then formula = formula & " and {DEPARTMENTMASTER.DEPARTMENT_NAME}='" & CMBDEPARTMENT.Text.Trim & "'"


            If rdbdetail.Checked = True Then
                objstock.frmstring = "MFG2COSTDETAILS"
            ElseIf Rdbsummary.Checked = True Then
                objstock.frmstring = "MFG2COSTSUMMARY"
            ElseIf RBSUPERSUMMARY.Checked = True Then
                objstock.frmstring = "MFG2COSTSUPERSUMMARY"
            ElseIf RBMERCHANTSUPERSUMM.Checked = True Then
                objstock.frmstring = "MFG2COSTMERCHANTSUPERSUMMARY"
            ElseIf RBMERCHANTSCREENCOST.Checked = True Then
                objstock.frmstring = "MFG2COSTMERCHANTSCREENSUMMARY"
            ElseIf RBSCREENCOST.Checked = True Then
                objstock.frmstring = "MFG2COSTSCREENSUMMARY"
            ElseIf RBJOBCOSTSUMMARY.Checked = True Then
                objstock.frmstring = "MFG2JOBCOSTSUMMARY"
            End If
            
            If chkdate.Checked = True Then
                getFromToDate()
                formula = formula & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                objstock.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            objstock.MdiParent = MDIMain
            objstock.selfor_po = formula
            objstock.Show()

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

    Private Sub DesignCostFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcombos()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE in ('MFG2','CUTTING')", False)

            Dim dt As DataTable
            Dim objclscomm As New ClsCommon()

            If cmbMerchant.Text.Trim = "" Then fillitemname(cmbMerchant, " AND ITEMMASTER.ITEM_FRMSTRING='MERCHANT'")
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbMerchant.Text)
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, False)

            dt = objclscomm.search(" DISTINCT MFG_JOBNO", "", " MFGMASTER2 ", " AND MFGMASTER2.MFG_cmpid=" & CmpId & " and MFGMASTER2.MFG_Locationid=" & Locationid & " and MFGMASTER2.MFG_Yearid=" & YearId & " ORDER BY MFGMASTER2.MFG_JOBNO")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "MFG_JOBNO"
                CMBJOB.DataSource = dt
                CMBJOB.DisplayMember = "MFG_JOBNO"
                CMBJOB.Text = ""
            End If
            
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class