
Imports BL

Public Class SelectChecking

    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for ok
            Call cmdok_Click(sender, e)
        End If
    End Sub

    Private Sub SelectGRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal WHERECLAUSE As String = "")
        Try
            Dim OBJCMN As New ClsCommon()
            Dim DTDATA As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK, 0 AS CHECKINGCHGS, * ", "", " GRSTOCKVIEW ", " AND YEARID = " & YearId & " ORDER BY DATE, FROMNO")
            gridbilldetails.DataSource = DTDATA
            If DTDATA.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("DONO")
            DT.Columns.Add("DATE")
            DT.Columns.Add("NAME")
            DT.Columns.Add("REJPCS")
            DT.Columns.Add("REJMTRS")
            DT.Columns.Add("TOTALPCS")
            DT.Columns.Add("CHECKINGCHGS")
            DT.Columns.Add("FROMNO")
            DT.Columns.Add("FROMTYPE")


            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(DTROW("CHK")) = True Then
                    DT.Rows.Add(DTROW("LOTNO"), DTROW("DONO"), DTROW("DATE"), DTROW("NAME"), Val(DTROW("REJPCS")), Val(DTROW("REJMTRS")), Val(DTROW("TOTALPCS")), Val(DTROW("CHECKINGCHGS")), Val(DTROW("FROMNO")), DTROW("FROMTYPE"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class