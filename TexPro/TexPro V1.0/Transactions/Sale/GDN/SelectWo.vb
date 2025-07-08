Imports BL
Imports System.Windows.Forms

Public Class SelectWOforGDN
    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Dim WO As Integer
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
        Me.Top = 100

        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim where As String = ""

            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable = objclspreq.search("  SALEORDER.so_no AS SONO, SALEORDER.so_date AS SODATE, LEDGERS.Acc_cmpname AS CMPNAME, SALEORDER.so_pono AS PONO, SALEORDER.so_podate AS PODATE, LEDGERS_1.Acc_cmpname AS AGENT ", "", "   SALEORDER INNER JOIN LEDGERS ON SALEORDER.so_ledgerid = LEDGERS.Acc_id AND SALEORDER.SO_CMPID = LEDGERS.Acc_cmpid AND SALEORDER.SO_LOCATIONID = LEDGERS.Acc_locationid AND SALEORDER.SO_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON SALEORDER.so_Agentid = LEDGERS_1.Acc_id AND SALEORDER.SO_CMPID = LEDGERS_1.Acc_cmpid AND SALEORDER.SO_LOCATIONID = LEDGERS_1.Acc_locationid AND SALEORDER.SO_YEARID = LEDGERS_1.Acc_yearid ", " and SALEORDER.so_DONE=0 and SALEORDER.so_CMPID = " & CmpId & " AND SALEORDER.so_LOCATIONID = " & Locationid & " AND SALEORDER.so_YEARID = " & YearId & " ORDER BY SONO")

            If DT.Rows.Count > 0 Then

                gridwo.DataSource = DT
                If ADDCOL = False Then
                    gridwo.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                gridwo.Columns(0).Width = 40 'CHECK BOK
                gridwo.FirstDisplayedScrollingRowIndex = gridwo.RowCount - 1

            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
           

        End If
    End Sub

    Private Sub gridWO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridwo.CellClick
        Dim N As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        'CHECKING SIMILAR LOCATION
        For i = 0 To gridwo.RowCount - 1
            With gridwo.Rows(i).Cells(0)
                If .Value = True Then
                    N = gridwo.Item(1, i).Value.ToString

                End If
            End With
        Next

        If e.RowIndex >= 0 Then
            With gridwo.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    If (gridwo.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
                        .Value = True
                        WO = gridwo.Rows(e.RowIndex).Cells(1).Value
                        tempindex = e.RowIndex
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim objclspreq As New ClsCommon()
            Dim DT1 As DataTable = objclspreq.search(" SALEORDER.so_no AS SONO, SALEORDER.so_date AS SODATE, LEDGERS.Acc_cmpname AS CMPNAME, SALEORDER_DESC.SO_GRIDSRNO AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(SALEORDER_DESC.SO_CUTSIZE,0) AS CUT, ISNULL(DESIGNRECIPE.DESIGN_NO,'') AS DESIGN, ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, ISNULL(SALEORDER_DESC.SO_gridremarks,'') AS gridremarks, SALEORDER_DESC.SO_bales AS Bales, SALEORDER_DESC.SO_QTY AS PCS, SALEORDER_DESC.SO_RATE AS RATE, SALEORDER_DESC.SO_AMT AS AMT, ISNULL(ADDRESSMASTER.ADDRESS_ALIAS,'') AS CONSIGNEE, ISNULL(LEDGERS_1.Acc_cmpname,'') AS AGENT, SALEORDER.so_pono AS PONO, SALEORDER.so_podate AS PODATE ", "", "    SALEORDER INNER JOIN SALEORDER_DESC ON SALEORDER.so_no = SALEORDER_DESC.SO_NO AND SALEORDER.SO_CMPID = SALEORDER_DESC.SO_CMPID AND SALEORDER.SO_LOCATIONID = SALEORDER_DESC.SO_LOCATIONID AND SALEORDER.SO_YEARID = SALEORDER_DESC.SO_YEARID INNER JOIN LEDGERS ON SALEORDER.so_ledgerid = LEDGERS.Acc_id AND SALEORDER.SO_CMPID = LEDGERS.Acc_cmpid AND SALEORDER.SO_LOCATIONID = LEDGERS.Acc_locationid AND SALEORDER.SO_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON SALEORDER.so_Agentid = LEDGERS_1.Acc_id AND SALEORDER.SO_CMPID = LEDGERS_1.Acc_cmpid AND SALEORDER.SO_LOCATIONID = LEDGERS_1.Acc_locationid AND SALEORDER.SO_YEARID = LEDGERS_1.Acc_yearid LEFT OUTER JOIN ADDRESSMASTER ON SALEORDER.so_CONSIGNEEID = ADDRESSMASTER.ADDRESS_ID AND SALEORDER.SO_CMPID = ADDRESSMASTER.ADDRESS_cmpid AND SALEORDER.SO_LOCATIONID = ADDRESSMASTER.ADDRESS_locationid AND SALEORDER.SO_YEARID = ADDRESSMASTER.ADDRESS_yearid LEFT OUTER JOIN COLORMASTER ON SALEORDER_DESC.SO_COLORID = COLORMASTER.COLOR_id AND SALEORDER_DESC.SO_CMPID = COLORMASTER.COLOR_cmpid AND SALEORDER_DESC.SO_LOCATIONID = COLORMASTER.COLOR_locationid AND SALEORDER_DESC.SO_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN ITEMMASTER ON SALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id AND SALEORDER_DESC.SO_CMPID = ITEMMASTER.item_cmpid AND SALEORDER_DESC.SO_LOCATIONID = ITEMMASTER.item_locationid AND SALEORDER_DESC.SO_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN DESIGNRECIPE ON SALEORDER_DESC.SO_DESIGNID = DESIGNRECIPE.DESIGN_ID AND SALEORDER_DESC.SO_CMPID = DESIGNRECIPE.DESIGN_CMPID AND SALEORDER_DESC.SO_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND SALEORDER_DESC.SO_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN PIECETYPEMASTER ON SALEORDER_DESC.SO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND SALEORDER_DESC.SO_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND SALEORDER_DESC.SO_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND SALEORDER_DESC.SO_YEARID = PIECETYPEMASTER.PIECETYPE_yearid ", " and SALEORDER.so_NO = " & WO & " and SALEORDER.so_CMPID = " & CmpId & " AND SALEORDER.so_LOCATIONID = " & Locationid & " AND SALEORDER.so_YEARID = " & YearId)
           
            GDN.selectgdntable = DT1
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class