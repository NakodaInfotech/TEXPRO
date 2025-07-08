
Imports BL

Public Class CuttingFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub CuttingFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim OBJSTOCK As New CuttingDesign

            OBJSTOCK.CONDITION = "{CUTTING_VIEW.CMPID}= " & CmpId & " and {CUTTING_VIEW.LOCATIONID}= " & Locationid & " and {CUTTING_VIEW.YEARID}= " & YearId

            If cmbMerchant.Text.Trim <> "" Then OBJSTOCK.CONDITION = OBJSTOCK.CONDITION & " and {CUTTING_VIEW.ITEMNAME}='" & cmbMerchant.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then OBJSTOCK.CONDITION = OBJSTOCK.CONDITION & " and {CUTTING_VIEW.DESIGN}='" & CMBDESIGN.Text.Trim & "'"
            If CMBJOB.Text.Trim <> "" Then OBJSTOCK.CONDITION = OBJSTOCK.CONDITION & " and {CUTTING_VIEW.JOBNO}='" & CMBJOB.Text.Trim & "'"

            If chkdate.Checked = True Then
                getFromToDate()
                OBJSTOCK.CONDITION = OBJSTOCK.CONDITION & " and ({@date} in date " & fromD & " to date " & toD & ")"
                OBJSTOCK.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy")
            Else
                OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CHKVALUE.CheckState = CheckState.Unchecked Then
                OBJSTOCK.FRMSTRING = "CUTTINGDTLS"
            Else
                OBJSTOCK.FRMSTRING = "CUTTINGDTLSVALUE"
            End If

            OBJSTOCK.MdiParent = MDIMain
            OBJSTOCK.Show()

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

    Private Sub CuttingFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcombos()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            Dim dt As DataTable
            Dim objclscomm As New ClsCommon()
            If cmbMerchant.Text.Trim = "" Then fillitemname(cmbMerchant, " AND ITEMMASTER.ITEM_FRMSTRING='MERCHANT'")
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbMerchant.Text)
            dt = objclscomm.search("DISTINCT JOBNO ", "", " CUTTING_VIEW ", " AND cmpid=" & CmpId & " and Locationid=" & Locationid & " and Yearid=" & YearId & " ORDER BY JOBNO")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "JOBNO"
                CMBJOB.DataSource = dt
                CMBJOB.DisplayMember = "JOBNO"
                CMBJOB.Text = ""
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class