
Imports BL

Public Class Filter_for_Stock_Party
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public filtfrmString As String
    Public filtpartystock As String

    Private Sub Filter_for_Stock_Party_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdshowreport_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            If filtpartystock = "On_Approval_Partywise_Stock" Then
                Dim rpt As New stock_partywise_approval

                Dim formula As String
                formula = " {ApprovalStock_View.CMPID}= " & CmpId & " and {ApprovalStock_View.LOCATIONID}= " & Locationid & " and {ApprovalStock_View.YEARID}= " & YearId

                If cmbitemname.Text.Trim <> "" Then
                    formula = formula & " and {ApprovalStock_View.Item_Name}='" & cmbitemname.Text.Trim & "'"
                End If
                If cmbColor.Text.Trim <> "" Then
                    formula = formula & " and {ApprovalStock_View.color_name}='" & cmbColor.Text.Trim & "'"
                End If

                If cmbQuality.Text.Trim <> "" Then
                    formula = formula & " and {ApprovalStock_View.Quality_name}='" & cmbQuality.Text.Trim & "'"
                End If
                If cmbname.Text.Trim <> "" Then
                    formula = formula & " and {ApprovalStock_View.acc_cmpname}='" & cmbname.Text.Trim & "'"
                End If
                If cmbunit.Text.Trim <> "" Then
                    formula = formula & " and {ApprovalStock_View.unit_abbr}='" & cmbunit.Text.Trim & "'"
                End If

                If chkdate.Checked = True Then
                    getFromToDate()
                    formula = formula & " and {ApprovalStock_View.date} in date " & fromD & " to date " & toD & ""
                End If
                Dim objstock As New stock_approval
                objstock.MdiParent = MDIMain
                objstock.selformula_approved_partywise = formula
                objstock.heading = "Party Wise On Approval Stock"

                objstock.Show()
            ElseIf filtpartystock = "Approved_Partywise_Stock" Then
                Dim rpt As New stock_PartyWise_approved

                Dim formula As String
                formula = " {ApprovedStock_View.CMPID}= " & CmpId & " and {ApprovedStock_View.LOCATIONID}= " & Locationid & " and {ApprovedStock_View.YEARID}= " & YearId

                If cmbitemname.Text.Trim <> "" Then
                    formula = formula & " and {ApprovedStock_View.Item_Name}='" & cmbitemname.Text.Trim & "'"
                End If
                If cmbColor.Text.Trim <> "" Then
                    formula = formula & " and {ApprovedStock_View.color_name}='" & cmbColor.Text.Trim & "'"
                End If

                If cmbQuality.Text.Trim <> "" Then
                    formula = formula & " and {ApprovedStock_View.Quality_name}='" & cmbQuality.Text.Trim & "'"
                End If
                If cmbname.Text.Trim <> "" Then
                    formula = formula & " and {ApprovedStock_View.acc_cmpname}='" & cmbname.Text.Trim & "'"
                End If
                If cmbunit.Text.Trim <> "" Then
                    formula = formula & " and {ApprovedStock_View.unit_abbr}='" & cmbunit.Text.Trim & "'"
                End If

                If chkdate.Checked = True Then
                    getFromToDate()
                    formula = formula & " and {ApprovedStock_View.date} in date " & fromD & " to date " & toD & ""
                End If
                Dim objstock As New Stocks_Approved
                objstock.MdiParent = MDIMain
                objstock.selformula_approved = formula
                objstock.heading = "Party Wise On Approved Stock"

                objstock.Show()
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
            If filtpartystock = "G.R.N" Then
                Me.Text = "G.R.N"
                lblheading.Text = "G.R.N"

            End If

            fillcombos()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, True)

            If cmbitemname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" item_name ", "", " itemMaster ", " and item_cmpid=" & CmpId & " and item_LOCATIONid=" & Locationid & " and item_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "item_name"
                    cmbitemname.DataSource = dt
                    cmbitemname.DisplayMember = "item_name"
                    cmbitemname.Text = ""
                End If
            End If

            If cmbQuality.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" Quality_name ", "", " QualityMaster ", " and Quality_cmpid=" & CmpId & " and Quality_LOCATIONid=" & Locationid & " and Quality_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Quality_name"
                    cmbQuality.DataSource = dt
                    cmbQuality.DisplayMember = "Quality_name"
                    cmbQuality.Text = ""
                End If
            End If
            If cmbColor.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" color_name ", "", " colorMaster ", " and color_cmpid=" & CmpId & " and color_LOCATIONid=" & Locationid & " and color_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "color_name"
                    cmbColor.DataSource = dt
                    cmbColor.DisplayMember = "color_name"
                    cmbColor.Text = ""
                End If
            End If
            If cmbunit.Text.Trim = "" Then
                Try
                    Dim objclspreq As New ClsCommon()
                    Dim dt As DataTable
                    dt = objclspreq.search(" unit_abbr ", "", " UnitMaster   ", " AND Unit_CMPID = " & CmpId & " AND Unit_LOCATIONID = " & Locationid & " AND Unit_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.Sort = "unit_abbr"
                        cmbunit.DataSource = dt
                        cmbunit.DisplayMember = "unit_abbr"
                    End If
                    cmbunit.SelectAll()
                Catch ex As Exception
                    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
                End Try
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    
End Class