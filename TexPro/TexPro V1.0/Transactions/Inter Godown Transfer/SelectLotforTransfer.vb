
Imports BL

Public Class SelectLotforTransfer

    Public GODOWN As String = ""
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectLotforTransfer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectLotforTransfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid()
        gridbilldetails.ForceInitialize()
        gridbill.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon()
            Dim DT1 As DataTable = OBJCMN.search("CAST (0 AS BIT) AS CHK, LEDGERNAME AS PARTYNAME, QUALITY, [Lot No] AS LOTNO, SUM(PCS) AS PCS, SUM(MTRS) AS MTRS, [Sr.] AS FROMNO, 0 AS FROMSRNO, FROMTYPE", "", " CHECK_VIEW", " AND ISNULL(TRANSFERDONE,0) = 'FALSE' AND GODOWN = '" & GODOWN & "' AND YEARID = " & YearId & " GROUP BY LEDGERNAME, QUALITY, [Lot No], [Sr.] ,  FROMTYPE")
            gridbilldetails.DataSource = DT1
            If DT1.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT.Columns.Add("NAME")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("PCS")
            DT.Columns.Add("MTRS")
            DT.Columns.Add("FROMNO")
            DT.Columns.Add("FROMSRNO")
            DT.Columns.Add("FROMTYPE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("PARTYNAME"), dtrow("QUALITY"), dtrow("LOTNO"), Val(dtrow("PCS")), Val(dtrow("MTRS")), Val(dtrow("FROMNO")), Val(dtrow("FROMSRNO")), dtrow("FROMTYPE"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = chkall.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class