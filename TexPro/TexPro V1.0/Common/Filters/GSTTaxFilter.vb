
Imports BL

Public Class GSTTaxFilter

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSTTaxFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.S) Then
                cmdshow_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            If RBGSTSUMMARY.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("GST Summary", System.AppDomain.CurrentDomain.BaseDirectory & "GST Summary.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GSTSUMMARY_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    Else
                        OBJRPT.GSTSUMMARY_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("GST Summary", System.AppDomain.CurrentDomain.BaseDirectory & "GST Summary.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GSTSUMMARY_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    Else
                        OBJRPT.GSTSUMMARY_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "GST Summary.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBGSTSALEDETAILS.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("GST Sale Details", System.AppDomain.CurrentDomain.BaseDirectory & "GST Sale Details.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GSTSALEDETAILS_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    Else
                        OBJRPT.GSTSALEDETAILS_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("GST Sale Details", System.AppDomain.CurrentDomain.BaseDirectory & "GST Sale Details.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GSTSALEDETAILS_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    Else
                        OBJRPT.GSTSALEDETAILS_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "GST Sale Details.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If

            ElseIf RBGSTPURCHASEDETAILS.Checked = True Then

                If MsgBox("Wish To Mail Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Dim OBJRPT As New clsReportDesigner("GST Purchase Details", System.AppDomain.CurrentDomain.BaseDirectory & "GST Purchase Details.xlsx", 2)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GSTPURCHASEDETAILS_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    Else
                        OBJRPT.GSTPURCHASEDETAILS_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    End If
                    Exit Sub
                Else
                    Dim OBJRPT As New clsReportDesigner("GST Purchase Details", System.AppDomain.CurrentDomain.BaseDirectory & "GST Purchase Details.xlsx", 0)
                    If chkdate.CheckState = CheckState.Checked Then
                        OBJRPT.GSTPURCHASEDETAILS_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    Else
                        OBJRPT.GSTPURCHASEDETAILS_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    End If

                    'MAIL EXCEL AS ATTACHMENTS
                    Dim TEMPATTACHMENT As String = System.AppDomain.CurrentDomain.BaseDirectory & "GST Purchase Details.xlsx"
                    Dim objmail As New SendMail
                    objmail.attachment = TEMPATTACHMENT
                    objmail.Show()
                    objmail.BringToFront()
                    Windows.Forms.Cursor.Current = Cursors.Arrow

                    Exit Sub
                End If


            ElseIf RBGSTR1.Checked = True Then

                Dim OBJRPT As New clsReportDesigner("B2B", System.AppDomain.CurrentDomain.BaseDirectory & "B2B.xlsx", 2)
                Dim OBJRPTB2CL As New clsReportDesigner("B2CL", System.AppDomain.CurrentDomain.BaseDirectory & "B2CL.xlsx", 2)
                Dim OBJRPTB2CS As New clsReportDesigner("B2CS", System.AppDomain.CurrentDomain.BaseDirectory & "B2CS.xlsx", 2)
                Dim OBJRPTCDNR As New clsReportDesigner("CDNR", System.AppDomain.CurrentDomain.BaseDirectory & "CDNR.xlsx", 2)
                Dim OBJRPTCDNUR As New clsReportDesigner("CDNUR", System.AppDomain.CurrentDomain.BaseDirectory & "CDNUR.xlsx", 2)
                Dim OBJRPTHSN As New clsReportDesigner("HSN", System.AppDomain.CurrentDomain.BaseDirectory & "HSN.xlsx", 2)
                If chkdate.CheckState = CheckState.Checked Then
                    OBJRPT.GSTB2B_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    OBJRPTB2CL.GSTB2CL_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    OBJRPTB2CS.GSTB2CS_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    OBJRPTCDNR.GSTCDNR_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    OBJRPTCDNUR.GSTCDNUR_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, CMBREGISTER.Text.Trim)
                    OBJRPTHSN.GSTHSN_EXCEL(CmpId, YearId, dtfrom.Value.Date, dtto.Value.Date, INVOICESCREENTYPE, CMBREGISTER.Text.Trim)
                Else
                    OBJRPT.GSTB2B_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    OBJRPTB2CL.GSTB2CL_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    OBJRPTB2CS.GSTB2CS_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    OBJRPTCDNR.GSTCDNR_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    OBJRPTCDNUR.GSTCDNUR_EXCEL(CmpId, YearId, AccFrom, AccTo, CMBREGISTER.Text.Trim)
                    OBJRPTHSN.GSTHSN_EXCEL(CmpId, YearId, AccFrom, AccTo, INVOICESCREENTYPE, CMBREGISTER.Text.Trim)
                End If
                Exit Sub

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSTTaxFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillregister(CMBREGISTER, " AND (REGISTER_TYPE ='SALE' OR REGISTER_TYPE = 'PURCHASE')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class