
Imports BL
Imports System.Windows.Forms
Public Class COPYFINALPACKING

    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub SelectPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim objclspreq As New ClsCommon()
            Dim dt As DataTable
            dt = objclspreq.search("   max(FINALPACKINGSLIP.FPS_NO) AS BALENO  ", "", " FINALPACKINGSLIP ", "  AND FPS_CMPID = " & CmpId & " AND FPS_LOCATIONID  = " & Locationid & " AND FPS_YEARID = " & YearId & where)
            If dt.Rows.Count > 0 Then

                griddesign.DataSource = dt
                'Dim col As New DataGridViewCheckBoxColumn
                If ADDCOL = False Then
                    griddesign.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                griddesign.Columns(0).Width = 50 'CHECK BOK
                griddesign.Columns(1).Width = 100 'CHECK BOK
                
                griddesign.FirstDisplayedScrollingRowIndex = griddesign.RowCount - 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            If cmbselect.Text = "BALE NO" Then
                fillgrid(" AND FPS_NO=" & Val(txtsearch.Text))
            End If
        End If
    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles griddesign.CellClick
        Dim N As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        'CHECKING SIMILAR LOCATION
        For i = 0 To griddesign.RowCount - 1
            With griddesign.Rows(i).Cells(0)
                If .Value = True Then N = griddesign.Item(1, i).Value.ToString
            End With
        Next

        If e.RowIndex >= 0 Then
            With griddesign.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    'If (griddesign.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
                    .Value = True
                    tempindex = e.RowIndex
                    'End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim DT As New DataTable
        DT.Columns.Add("SRNO")
        DT.Columns.Add("PIECETYPE")
        DT.Columns.Add("DESC")
        DT.Columns.Add("MERCHANT")
        DT.Columns.Add("WIDTH")
        DT.Columns.Add("CUT")
        DT.Columns.Add("DESIGN")
        DT.Columns.Add("COLOR")
        DT.Columns.Add("LOTNO")
        DT.Columns.Add("PCS")
        DT.Columns.Add("BUNDLE")
        DT.Columns.Add("TOTAL")
        DT.Columns.Add("NAME")
        DT.Columns.Add("PROCESS")
        DT.Columns.Add("ITEMNAME")
        DT.Columns.Add("DYEINGNO")
        DT.Columns.Add("JOBNO")
        DT.Columns.Add("ORDERNO")
        DT.Columns.Add("PACKEDBY")
        DT.Columns.Add("PROGNO")
        DT.Columns.Add("TYPE")

        For Each ROW As DataGridViewRow In griddesign.Rows
            If ROW.Cells(0).Value = True Then
                Dim objclspreq As New ClsCommon()
                Dim DT1 As New DataTable
                DT1 = objclspreq.search("    FINALPACKINGSLIP_DESC.FPS_GRIDSRNO AS GRIDSRNO, PIECETYPEMASTER.PIECETYPE_name AS PIECETYPE,FINALPACKINGSLIP_DESC.FPS_DESC AS [DESC],ITEMMASTER.item_name AS MERCHANT,  FINALPACKINGSLIP_DESC.FPS_WIDTH AS WIDTH, FINALPACKINGSLIP_DESC.FPS_CUT AS CUT, DESIGNRECIPE.DESIGN_NO AS DESIGNNO, COLORMASTER.COLOR_name AS COLOR, FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO, FINALPACKINGSLIP_DESC.FPS_PCS AS PCS, FINALPACKINGSLIP_DESC.FPS_BUNDLE AS BUNDLE, FINALPACKINGSLIP_DESC.FPS_TOTAL AS TOTAL, LEDGERS.Acc_cmpname AS NAME, PROCESSMASTER.PROCESS_NAME AS PROCESS, ITEMMASTER_1.item_name AS ITEMNAME, DYEINGRECIPE.DYEING_NO AS DYEINGNO, FINALPACKINGSLIP.FPS_JOBNO AS JOBNO, FINALPACKINGSLIP.FPS_ORDERNO AS ORDERNO, FINALPACKINGSLIP.FPS_PACKEDBY AS PACKEDBY, FINALPACKINGSLIP.FPS_PROGNO AS PROGNO, FINALPACKINGSLIP.FPS_TYPE AS TYPE ", "", "     FINALPACKINGSLIP INNER JOIN FINALPACKINGSLIP_DESC ON FINALPACKINGSLIP.FPS_NO = FINALPACKINGSLIP_DESC.FPS_NO AND FINALPACKINGSLIP.FPS_CMPID = FINALPACKINGSLIP_DESC.FPS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = FINALPACKINGSLIP_DESC.FPS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = FINALPACKINGSLIP_DESC.FPS_YEARID INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID AND FINALPACKINGSLIP.FPS_CMPID = PROCESSMASTER.PROCESS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PIECETYPEMASTER ON FINALPACKINGSLIP_DESC.FPS_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALPACKINGSLIP_DESC.FPS_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALPACKINGSLIP_DESC.FPS_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALPACKINGSLIP_DESC.FPS_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN ITEMMASTER ON FINALPACKINGSLIP_DESC.FPS_ITEMID = ITEMMASTER.item_id AND FINALPACKINGSLIP_DESC.FPS_CMPID = ITEMMASTER.item_cmpid AND FINALPACKINGSLIP_DESC.FPS_LOCATIONID = ITEMMASTER.item_locationid AND FINALPACKINGSLIP_DESC.FPS_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN COLORMASTER ON FINALPACKINGSLIP_DESC.FPS_COLORID = COLORMASTER.COLOR_id AND FINALPACKINGSLIP_DESC.FPS_CMPID = COLORMASTER.COLOR_cmpid AND FINALPACKINGSLIP_DESC.FPS_LOCATIONID = COLORMASTER.COLOR_locationid AND FINALPACKINGSLIP_DESC.FPS_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN DESIGNRECIPE ON FINALPACKINGSLIP_DESC.FPS_DESIGNID = DESIGNRECIPE.DESIGN_ID AND FINALPACKINGSLIP_DESC.FPS_CMPID = DESIGNRECIPE.DESIGN_CMPID AND FINALPACKINGSLIP_DESC.FPS_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND FINALPACKINGSLIP_DESC.FPS_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN DYEINGRECIPE ON FINALPACKINGSLIP.FPS_DYEINGID = DYEINGRECIPE.DYEING_ID AND FINALPACKINGSLIP.FPS_CMPID = DYEINGRECIPE.DYEING_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = DYEINGRECIPE.DYEING_YEARID LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 ON FINALPACKINGSLIP.FPS_MERCHANTID = ITEMMASTER_1.item_id AND FINALPACKINGSLIP.FPS_CMPID = ITEMMASTER_1.item_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = ITEMMASTER_1.item_locationid AND FINALPACKINGSLIP.FPS_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN LEDGERS ON FINALPACKINGSLIP.FPS_LEDGERID = LEDGERS.Acc_id AND FINALPACKINGSLIP.FPS_CMPID = LEDGERS.Acc_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = LEDGERS.Acc_locationid AND FINALPACKINGSLIP.FPS_YEARID = LEDGERS.Acc_yearid ", " AND FINALPACKINGSLIP_DESC.FPS_NO=" & ROW.Cells(1).Value & " AND FINALPACKINGSLIP_DESC.FPS_CMPID = " & CmpId & " AND FINALPACKINGSLIP_DESC.FPS_LOCATIONID  = " & Locationid & " AND FINALPACKINGSLIP_DESC.FPS_YEARID = " & YearId)
                For I As Integer = 0 To DT1.Rows.Count - 1
                    DT.Rows.Add(DT1.Rows(I).Item(0), DT1.Rows(I).Item(1), DT1.Rows(I).Item(2), DT1.Rows(I).Item(3), DT1.Rows(I).Item(4), DT1.Rows(I).Item(5), DT1.Rows(I).Item(6), DT1.Rows(I).Item(7), DT1.Rows(I).Item(8), DT1.Rows(I).Item(9), DT1.Rows(I).Item(10), DT1.Rows(I).Item(11), DT1.Rows(I).Item(12), DT1.Rows(I).Item(13), DT1.Rows(I).Item(14), DT1.Rows(I).Item(15), DT1.Rows(I).Item(16), DT1.Rows(I).Item(17), DT1.Rows(I).Item(18), DT1.Rows(I).Item(19), DT1.Rows(I).Item(20))

                Next
            End If
        Next
        finalPackingslip.dt_SELECT = DT
        Me.Close()
    End Sub

    Private Sub gridquotation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles griddesign.CellDoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class