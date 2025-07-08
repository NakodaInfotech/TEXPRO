
Imports BL

Public Class FinalCuttingFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub FinalCuttingFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND (PROCESSMASTER.PROCESS_TYPE='JOB IN' OR PROCESSMASTER.PROCESS_TYPE='MFG2' OR PROCESSMASTER.PROCESS_TYPE='LOOSE STOCK')", False)
            If cmbMerchant.Text.Trim = "" Then fillitemname(cmbMerchant, " AND ITEMMASTER.ITEM_FRMSTRING='MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            Dim objwo As New mfgdesign
            objwo.MdiParent = MDIMain
            objwo.selfor_po = "1=1"
            objwo.HIDERATE = CHKHIDERATE.Checked


            If TXTJOBNO.Text.Trim <> "" Then objwo.selfor_po = objwo.selfor_po & " and {FINALCUTTINGPROCESS.FCP_JOBNO}='" & TXTJOBNO.Text & "'"
            If cmbprocess.Text.Trim <> "" Then objwo.selfor_po = objwo.selfor_po & " and {PROCESSMASTER.PROCESS_NAME}='" & cmbprocess.Text & "'"
            If cmbMerchant.Text.Trim <> "" Then objwo.selfor_po = objwo.selfor_po & " and {ITEMMASTER.ITEM_NAME}='" & cmbMerchant.Text & "'"

            If chkdate.Checked = True Then
                getFromToDate()
                objwo.selfor_po = objwo.selfor_po & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                objwo.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                objwo.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            objwo.selfor_po = objwo.selfor_po & " and {FINALCUTTINGPROCESS.FCP_yearid}=" & YearId
            objwo.frmstring = "FCPVALUELOSS"
            objwo.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class