
Imports BL

Public Class SelectSO

    Public PARTYNAME As String = ""
    Public DT As New DataTable

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
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Dim WHERE As String = ""
            If PARTYNAME <> "" Then WHERE = " And ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & PARTYNAME & "'"

            Dim OBJCMN As New ClsCommon()
            Dim DT As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK,  ALLSALEORDER.SO_NO AS SONO, ALLSALEORDER.SO_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ALLSALEORDER_DESC.SO_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ALLSALEORDER_DESC.SO_PERSONALMERCHANT,'') AS PERSONALMERCHANT, ISNULL(DESIGNRECIPE.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ROUND(ALLSALEORDER_DESC.BALBALES,0) AS BALES, ALLSALEORDER.TYPE, ISNULL(ALLSALEORDER.SO_PONO, '') AS PONO, ALLSALEORDER_DESC.SO_RATE AS RATE, ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENTNAME, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSNAME, ISNULL(CITYMASTER.city_name, '') AS CITYNAME, ALLSALEORDER.SO_REMARKS AS REMARKS, ALLSALEORDER_DESC.SO_GRIDREMARKS AS GRIDREMARKS ", "", " ALLSALEORDER INNER JOIN ALLSALEORDER_DESC ON ALLSALEORDER.SO_NO = ALLSALEORDER_DESC.SO_NO AND ALLSALEORDER.SO_YEARID = ALLSALEORDER_DESC.SO_YEARID AND ALLSALEORDER.TYPE = ALLSALEORDER_DESC.TYPE INNER JOIN LEDGERS ON ALLSALEORDER.SO_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON ALLSALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN CITYMASTER ON ALLSALEORDER.SO_CITYID = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON ALLSALEORDER.SO_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON ALLSALEORDER.SO_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON ALLSALEORDER_DESC.SO_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNRECIPE ON ALLSALEORDER_DESC.SO_DESIGNID = DESIGNRECIPE.DESIGN_ID LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON ALLSALEORDER.SO_SHIPTOID = SHIPTOLEDGERS.Acc_id ", WHERE & " AND ALLSALEORDER.SO_YEARID = " & YearId & " AND ROUND(ALLSALEORDER_DESC.BALBALES,0) > 0 AND ALLSALEORDER_DESC.SO_CLOSED = 0 ORDER BY ALLSALEORDER.SO_NO, ALLSALEORDER_DESC.SO_GRIDSRNO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT.Columns.Add("DATE")
            DT.Columns.Add("NAME")
            DT.Columns.Add("ITEMNAME")
            DT.Columns.Add("DESIGNNO")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("BALES")
            DT.Columns.Add("PONO")
            DT.Columns.Add("AGENTNAME")
            DT.Columns.Add("TRANSNAME")
            DT.Columns.Add("CITYNAME")
            DT.Columns.Add("SHIPTO")
            DT.Columns.Add("RATE")
            DT.Columns.Add("SONO")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("TYPE")
            DT.Columns.Add("REMARKS")


            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("DATE"), dtrow("NAME"), dtrow("ITEMNAME"), dtrow("DESIGNNO"), dtrow("COLOR"), Val(dtrow("BALES")), dtrow("PONO"), dtrow("AGENTNAME"), dtrow("TRANSNAME"), dtrow("CITYNAME"), dtrow("SHIPTO"), Val(dtrow("RATE")), Val(dtrow("SONO")), Val(dtrow("GRIDSRNO")), dtrow("TYPE"), dtrow("REMARKS"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class