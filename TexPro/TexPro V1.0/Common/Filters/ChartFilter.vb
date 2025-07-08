
Imports BL

Public Class ChartFilter

    Sub FILLCMB()
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChartFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOW REPORT
                Call cmdshow_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChartFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'", "Sundry Debtors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim WHERECLAUSE As String = ""
            Dim FRMSTRING As String = ""
            If cmbname.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND PARTYNAME = '" & cmbname.Text.Trim & "' "
            If cmbmerchant.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND MERCHANT = '" & cmbmerchant.Text.Trim & "' "
            
            Dim objclspreq As New ClsCommon()
            Dim dt As New DataTable
            If RBNAME.Checked = True Then
                dt = objclspreq.search(" PARTYNAME, SUM(MTRS ) AS TOTALMTRS ", "", " GDN_VIEW ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY PARTYNAME HAVING SUM(MTRS) > " & Val(TXTMTRS.Text.Trim) & " ORDER BY TOTALMTRS, PARTYNAME ")
                FRMSTRING = "PARTYWISE"
            ElseIf RBMERCHANTWISE.Checked = True Then
                dt = objclspreq.search(" MERCHANT, SUM(MTRS ) AS TOTALMTRS ", "", " GDN_VIEW ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY MERCHANT HAVING SUM(MTRS) > " & Val(TXTMTRS.Text.Trim) & " ORDER BY TOTALMTRS, MERCHANT ")
                FRMSTRING = "MERCHANTWISE"
            ElseIf RBMONTH.Checked = True Then
                dt = objclspreq.search(" DATENAME(MONTH,GDN_VIEW.GDNDATE) AS MONTHNAME, SUM(MTRS ) AS TOTALMTRS ", "", " GDN_VIEW ", WHERECLAUSE & "  AND CMPID = " & CmpId & " AND locationid = " & Locationid & " AND yearid = " & YearId & " GROUP BY DATENAME(MONTH,GDN_VIEW.GDNDATE), MONTH(GDN_VIEW.GDNDATE) HAVING SUM(MTRS) > " & Val(TXTMTRS.Text.Trim) & " ORDER BY MONTH(GDN_VIEW.GDNDATE) ")
                FRMSTRING = "MONTHWISE"
            End If
            If dt.Rows.Count = 0 Then
                MsgBox("No Records Found", MsgBoxStyle.Critical, "Texpro")
                Exit Sub
            End If
            Dim objrep As New clsReportDesigner("Analytical Report", System.AppDomain.CurrentDomain.BaseDirectory & "Analytical Report.xlsx", 2)
            objrep.CHART_REPORT_EXCEL(dt, CmpId, Locationid, YearId, "ANALYTICAL REPORT", FRMSTRING)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress
        numdotkeypress(e, TXTMTRS, Me)
    End Sub
End Class