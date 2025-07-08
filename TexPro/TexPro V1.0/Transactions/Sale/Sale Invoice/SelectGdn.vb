
Imports BL

Public Class SelectGdn

    Dim tempindex, i As Integer
    Public PARTYNAME As String = ""
    Public DT1 As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectMfgforPS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectMfgforPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 100
            fillgrid("")
            gridbilldetails.ForceInitialize()
            gridbill.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objclspreq As New ClsCommon()
            Dim DT As New DataTable
            If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                DT = objclspreq.search(" DISTINCT CAST (0 AS BIT) AS CHK, PACKINGSUMMARY.PS_NO AS GDNNO, PACKINGSUMMARY.PS_date AS GDNDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALENO,'') AS BALENO, ISNULL(ITEM_NAME, '') AS ITEMNAME, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALEPCS, 0) AS PCS, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALEMTRS, 0) AS MTRS, PACKINGSUMMARY_BALEDESC.PS_BALESRNO AS GRIDSRNO, ISNULL(PACKINGSUMMARY.PS_READYWIDTH,'') AS READYWIDTH ", "", "  PACKINGSUMMARY INNER JOIN PACKINGSUMMARY_BALEDESC ON PACKINGSUMMARY.PS_NO = PACKINGSUMMARY_BALEDESC.PS_NO AND PACKINGSUMMARY.PS_YEARID = PACKINGSUMMARY_BALEDESC.PS_YEARID INNER JOIN LEDGERS ON PACKINGSUMMARY.PS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON PACKINGSUMMARY_BALEDESC.PS_MERCHANTID = ITEMMASTER.ITEM_ID ", "  AND PACKINGSUMMARY.PS_INVDONE = 0 AND LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "' AND PACKINGSUMMARY.PS_YEARID = " & YearId & WHERE & " ORDER BY PACKINGSUMMARY.PS_NO, PACKINGSUMMARY_BALEDESC.PS_BALESRNO")
            Else
                DT = objclspreq.search(" DISTINCT CAST (0 AS BIT) AS CHK, GDN.GDN_NO AS GDNNO, GDN.GDN_date AS GDNDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GDN_PSDESC.GDN_PSNO,'') AS BALENO, ISNULL(ITEM_NAME, '') AS ITEMNAME, ISNULL(GDN_PSDESC.GDN_PCS, 0) AS PCS, ISNULL(GDN_PSDESC.GDN_MTRS, 0) AS MTRS, GDN_PSDESC.GDN_SRNO AS GRIDSRNO, '' AS READYWIDTH ", "", "  GDN INNER JOIN GDN_PSDESC ON GDN.GDN_NO = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID LEFT OUTER JOIN LEDGERS ON GDN_PSDESC.GDN_PARTYID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON GDN_MERCHANTID = ITEM_ID ", "  AND GDN_PSDESC.GDN_DONE = 0 AND LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "' AND GDN.GDN_YEARID = " & YearId & WHERE & " ORDER BY GDN.GDN_NO, GDN_PSDESC.GDN_SRNO")
            End If
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT1.Columns.Add("GDNNO")
            DT1.Columns.Add("GDNDATE")
            DT1.Columns.Add("NAME")
            DT1.Columns.Add("BALENO")
            DT1.Columns.Add("ITEMNAME")
            DT1.Columns.Add("PCS")
            DT1.Columns.Add("MTRS")
            DT1.Columns.Add("SRNO")
            DT1.Columns.Add("READYWIDTH")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT1.Rows.Add(dtrow("GDNNO"), dtrow("GDNDATE"), dtrow("NAME"), dtrow("BALENO"), dtrow("ITEMNAME"), Val(dtrow("PCS")), Val(dtrow("MTRS")), Val(dtrow("GRIDSRNO")), dtrow("READYWIDTH"))
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