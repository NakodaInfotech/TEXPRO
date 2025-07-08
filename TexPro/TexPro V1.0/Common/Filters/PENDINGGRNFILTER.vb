Imports BL
Public Class PENDINGGRNFILTER
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
            Dim rpt As New stock_partywise_approval

            Dim formula As String
            formula = " {grn.CMPID}= " & CmpId & " and {grn.LOCATIONID}= " & Locationid & " and {grn.YEARID}= " & YearId

            If cmbitemname.Text.Trim <> "" Then
                formula = formula & " and {grn.ItemName}='" & cmbitemname.Text.Trim & "'"
            End If
            If cmbColor.Text.Trim <> "" Then
                formula = formula & " and {grn.color}='" & cmbColor.Text.Trim & "'"
            End If

            If cmbQuality.Text.Trim <> "" Then
                formula = formula & " and {grn.Quality}='" & cmbQuality.Text.Trim & "'"
            End If
            If cmbname.Text.Trim <> "" Then
                formula = formula & " and {grn.name}='" & cmbname.Text.Trim & "'"
            End If
            If cmbunit.Text.Trim <> "" Then
                formula = formula & " and {grn.unit}='" & cmbunit.Text.Trim & "'"
            End If
            If cmbtype.Text.Trim <> "" Then
                formula = formula & " and {grn.type}='" & cmbtype.Text.Trim & "'"
            End If
            If chkdate.Checked = True Then
                getFromToDate()
                formula = formula & " and {grn.date} in date " & fromD & " to date " & toD & ""
            End If
            If chkpending.Checked = True And chkdone.Checked = False Then
                formula = formula & " and {grn.done}=False"
            ElseIf chkpending.Checked = False And chkdone.Checked = True Then
                formula = formula & " and {grn.done}=True"
            End If
            Dim objstock As New GRNDETAILDESIGN
            objstock.MdiParent = MDIMain
            objstock.selfor_GRN = formula


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

    Private Sub Filter_for_Stock_Party_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
          

            fillcombos()
            cmbtype.SelectedIndex = (0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False)

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