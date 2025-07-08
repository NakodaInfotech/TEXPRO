
Imports BL

Public Class JobOutFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub JobOutFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobOutFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcmb()
        Try
            fillname(cmbname, False, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click

        Dim formula As String

        formula = " {JOBOUT.JO_YEARID}= " & YearId

        Dim objstock As New JODESIGN
        If cmbname.Text.Trim <> "" Then formula = formula & " and {LEDGERS.ACC_CMPNAME}='" & cmbname.Text.Trim & "'"
        If cmbitemname.Text.Trim <> "" Then formula = formula & " and {ITEMMASTER.ITEM_NAME}='" & cmbitemname.Text.Trim & "'"
        If chkdate.Checked = True Then
            getFromToDate()
            formula = formula & " and {@DATE} in date " & fromD & " to date " & toD & ""
            objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
        Else
            objstock.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy")
        End If

        If RDBDETAIL.Checked = True Then objstock.FRMSTRING = "JODTLS"
        If RDBPARTYWISEDETAIL.Checked = True Then objstock.FRMSTRING = "JOPARTYWISE"
        If RDBMONTHLY.Checked = True Then objstock.FRMSTRING = "JOMONTHLY"

        objstock.MdiParent = MDIMain
        objstock.FORMULA = formula

        objstock.Show()
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
End Class