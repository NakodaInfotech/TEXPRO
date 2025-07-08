
Imports BL

Public Class DiscountDetails

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, GRIDDISCNAME.GetFocusedRowCellValue("DISCNAME"), GRIDDISCNAME.GetFocusedRowCellValue("DISCID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal EDIT As Boolean, ByVal DISCNAME As String, ByVal TEMPID As Integer)
        Try
            If TEMPID = 0 Then Exit Sub
            Dim OBJDISC As New DiscountMaster
            OBJDISC.MdiParent = MDIMain
            OBJDISC.TEMPDISCNAME = DISCNAME
            OBJDISC.TEMPID = TEMPID
            OBJDISC.EDIT = EDIT
            OBJDISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DiscountDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then
                showform(False, "", 0)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DiscountDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillnamegrid()
            fillgrid(GRIDDISCNAME.GetFocusedRowCellValue("DISCID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillnamegrid()
        Try
            Dim objcmn As New ClsCommon
            Dim dt As DataTable = objcmn.search(" DISC_NAME AS DISCNAME, DISC_id AS DISCID  ", "", " DISCOUNTMASTER ", " and DISCOUNTMASTER.DISC_YEARID = " & YearId & " ORDER BY DISCOUNTMASTER.DISC_NAME ")
            GRIDDISCNAMEDETAILS.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal DISCID As Integer)
        Try
            If DISCID = 0 Then Exit Sub
            Dim objcmn As New ClsCommon
            Dim dtuser As DataTable = objcmn.search(" ITEMMASTER.item_name AS ITEMNAME, DISCOUNTMASTER_DESC.DISC_RATE AS RATE ", "", " DISCOUNTMASTER_DESC INNER JOIN ITEMMASTER ON DISCOUNTMASTER_DESC.DISC_ITEMID = ITEMMASTER.item_id ", " AND DISCOUNTMASTER_DESC.DISC_ID = " & DISCID & " AND DISCOUNTMASTER_DESC.DISC_YEARID = " & YearId)
            griddetails.DataSource = dtuser
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDUSERNAME_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDDISCNAME.Click
        Try
            fillgrid(GRIDDISCNAME.GetFocusedRowCellValue("DISCID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDUSERNAME_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GRIDDISCNAME.FocusedRowChanged
        Try
            fillgrid(GRIDDISCNAME.GetFocusedRowCellValue("DISCID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDDISCNAMEDETAILS_DoubleClick(sender As Object, e As EventArgs) Handles GRIDDISCNAMEDETAILS.DoubleClick
        Try
            showform(True, GRIDDISCNAME.GetFocusedRowCellValue("DISCNAME"), GRIDDISCNAME.GetFocusedRowCellValue("DISCID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class