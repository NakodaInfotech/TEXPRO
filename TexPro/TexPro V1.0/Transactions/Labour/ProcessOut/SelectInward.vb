Imports BL
Imports System.Windows.Forms
Public Class SelectInward

    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public FRMSTRING As String
    Public GODOWN As String
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectMfgforPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectMfgforPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        Me.Text = " Select Mfg"
        fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor


            Dim DT As New DataTable
            Dim objclspreq As New ClsCommon()
            If FRMSTRING = "PROCESSOUT" Or FRMSTRING = "PROCESSIN" Then
                DT = objclspreq.search(" PARTYPACKINGSLIP_DESC.pps_NO , PARTYPACKINGSLIP_DESC.pps_LOTNO AS LOTNO, ISNULL(LEDGERS_1.Acc_cmpname, '') AS TONAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(COLORMASTER.COLOR_name, '') AS CHARTNO, PARTYPACKINGSLIP_DESC.pps_CUT AS CUT, PARTYPACKINGSLIP_DESC.pps_PCS AS PCS, (PARTYPACKINGSLIP_DESC.pps_MTRS-PARTYPACKINGSLIP_DESC.pps_outMTRS) AS MTRS, PARTYPACKINGSLIP_DESC.pps_GRIDSRNO, 'PARTYPACKINGSLIP' AS FROMTYPE, PARTYPACKINGSLIP_DESC.pps_GRNNO, PARTYPACKINGSLIP_DESC.pps_GRNSRNO,  PARTYPACKINGSLIP_DESC.pps_BALENO AS BALENO,  PARTYPACKINGSLIP_DESC.pps_JOBNO AS JOBNO, PARTYPACKINGSLIP_DESC.pps_GRIDLRNO AS LRNO, GODOWNMASTER.GODOWN_name", "", "          PARTYPACKINGSLIP INNER JOIN PARTYPACKINGSLIP_DESC ON PARTYPACKINGSLIP.pps_no = PARTYPACKINGSLIP_DESC.pps_NO AND PARTYPACKINGSLIP.pps_cmpid = PARTYPACKINGSLIP_DESC.pps_CMPID AND PARTYPACKINGSLIP.pps_locationid = PARTYPACKINGSLIP_DESC.pps_LOCATIONID AND PARTYPACKINGSLIP.pps_yearid = PARTYPACKINGSLIP_DESC.pps_YEARID INNER JOIN ITEMMASTER ON PARTYPACKINGSLIP_DESC.pps_ITEMID = ITEMMASTER.item_id AND PARTYPACKINGSLIP_DESC.pps_CMPID = ITEMMASTER.item_cmpid AND PARTYPACKINGSLIP_DESC.pps_LOCATIONID = ITEMMASTER.item_locationid AND PARTYPACKINGSLIP_DESC.pps_YEARID = ITEMMASTER.item_yearid INNER JOIN LEDGERS AS LEDGERS_1 ON PARTYPACKINGSLIP.pps_cmpid = LEDGERS_1.Acc_cmpid AND PARTYPACKINGSLIP.pps_locationid = LEDGERS_1.Acc_locationid AND PARTYPACKINGSLIP.pps_yearid = LEDGERS_1.Acc_yearid AND PARTYPACKINGSLIP.pps_ledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN GODOWNMASTER ON PARTYPACKINGSLIP.pps_GODOWNID = GODOWNMASTER.GODOWN_id AND PARTYPACKINGSLIP.pps_cmpid = GODOWNMASTER.GODOWN_cmpid AND PARTYPACKINGSLIP.pps_locationid = GODOWNMASTER.GODOWN_locationid AND PARTYPACKINGSLIP.pps_yearid = GODOWNMASTER.GODOWN_yearid LEFT OUTER JOIN PROCESSMASTER ON PARTYPACKINGSLIP_DESC.pps_PROCESSID = PROCESSMASTER.PROCESS_ID AND PARTYPACKINGSLIP.pps_cmpid = PROCESSMASTER.PROCESS_CMPID AND PARTYPACKINGSLIP.pps_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PARTYPACKINGSLIP.pps_yearid = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PIECETYPEMASTER ON PARTYPACKINGSLIP_DESC.pps_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND PARTYPACKINGSLIP_DESC.pps_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND  PARTYPACKINGSLIP_DESC.pps_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND PARTYPACKINGSLIP_DESC.pps_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN COLORMASTER ON PARTYPACKINGSLIP_DESC.pps_COLORID = COLORMASTER.COLOR_id AND PARTYPACKINGSLIP_DESC.pps_CMPID = COLORMASTER.COLOR_cmpid AND PARTYPACKINGSLIP_DESC.pps_LOCATIONID = COLORMASTER.COLOR_locationid AND PARTYPACKINGSLIP_DESC.pps_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN QUALITYMASTER ON PARTYPACKINGSLIP_DESC.pps_QUALITYID = QUALITYMASTER.QUALITY_id AND PARTYPACKINGSLIP_DESC.pps_CMPID = QUALITYMASTER.QUALITY_cmpid AND PARTYPACKINGSLIP_DESC.pps_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PARTYPACKINGSLIP_DESC.pps_YEARID = QUALITYMASTER.QUALITY_yearid ", "  and PARTYPACKINGSLIP_DESC.pps_CMPID = " & CmpId & where & "  AND (PARTYPACKINGSLIP_DESC.PPS_MTRS-PARTYPACKINGSLIP_DESC.PPS_OUTMTRS)>0 AND  PARTYPACKINGSLIP_DESC.pps_LOCATIONID = " & Locationid & " AND PARTYPACKINGSLIP_DESC.pps_YEARID = " & YearId & "  order by  LOTNO")

            ElseIf FRMSTRING = "PARTYPACKINGSLIP" Then
                DT = objclspreq.search(" PROCESSOUT_DESC.PO_NO AS [D.O No.], PROCESSOUT_DESC.PO_LOTNO AS LOTNO, ISNULL(LEDGERS_1.Acc_cmpname, '') AS TONAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME,  ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME,'') AS PROCESS, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(COLORMASTER.COLOR_name, '') AS CHARTNO, PROCESSOUT_DESC.PO_CUT AS CUT, PROCESSOUT_DESC.PO_PCS AS PCS, (PROCESSOUT_DESC.PO_MTRS -PROCESSOUT_DESC.PO_OUTMTRS) AS MTRS,  PROCESSOUT_DESC.PO_GRIDSRNO, 'OUT' AS FROMTYPE, PROCESSOUT_DESC.PO_GRNNO, PROCESSOUT_DESC.PO_GRNSRNO,  PROCESSOUT_DESC.PO_BALENO AS BALENO,  PROCESSOUT_DESC.PO_JOBNO AS JOBNO,  PROCESSOUT_DESC.PO_GRIDLRNO AS LRNO  ", "", "         PROCESSOUT INNER JOIN PROCESSOUT_DESC ON PROCESSOUT.PO_no = PROCESSOUT_DESC.PO_NO AND PROCESSOUT.PO_cmpid = PROCESSOUT_DESC.PO_CMPID AND PROCESSOUT.PO_locationid = PROCESSOUT_DESC.PO_LOCATIONID AND PROCESSOUT.PO_yearid = PROCESSOUT_DESC.PO_YEARID INNER JOIN ITEMMASTER ON PROCESSOUT_DESC.PO_ITEMID = ITEMMASTER.item_id AND PROCESSOUT_DESC.PO_CMPID = ITEMMASTER.item_cmpid AND PROCESSOUT_DESC.PO_LOCATIONID = ITEMMASTER.item_locationid AND PROCESSOUT_DESC.PO_YEARID = ITEMMASTER.item_yearid INNER JOIN LEDGERS AS LEDGERS_1 ON PROCESSOUT.PO_TOledgerid = LEDGERS_1.Acc_id AND PROCESSOUT.PO_cmpid = LEDGERS_1.Acc_cmpid AND PROCESSOUT.PO_locationid = LEDGERS_1.Acc_locationid AND PROCESSOUT.PO_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN PROCESSMASTER ON PROCESSOUT.PO_PROCESSID = PROCESSMASTER.PROCESS_ID AND PROCESSOUT.PO_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESSOUT.PO_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESSOUT.PO_yearid = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PIECETYPEMASTER ON PROCESSOUT_DESC.PO_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND PROCESSOUT_DESC.PO_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND PROCESSOUT_DESC.PO_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND PROCESSOUT_DESC.PO_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN COLORMASTER ON PROCESSOUT_DESC.PO_COLORID = COLORMASTER.COLOR_id AND PROCESSOUT_DESC.PO_CMPID = COLORMASTER.COLOR_cmpid AND PROCESSOUT_DESC.PO_LOCATIONID = COLORMASTER.COLOR_locationid AND PROCESSOUT_DESC.PO_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN QUALITYMASTER ON PROCESSOUT_DESC.PO_QUALITYID = QUALITYMASTER.QUALITY_id AND PROCESSOUT_DESC.PO_CMPID = QUALITYMASTER.QUALITY_cmpid AND PROCESSOUT_DESC.PO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PROCESSOUT_DESC.PO_YEARID = QUALITYMASTER.QUALITY_yearid", " AND (PROCESSOUT_DESC.PO_MTRS-PROCESSOUT_DESC.PO_OUTMTRS)>0 and PROCESSOUT_DESC.PO_CMPID = " & CmpId & where & " AND PROCESSOUT_DESC.PO_LOCATIONID = " & Locationid & " AND PROCESSOUT_DESC.PO_YEARID = " & YearId & "  order by  LOTNO")
            End If

            gridmfg.DataSource = DT
            If DT.Rows.Count > 0 Then

                If ADDCOL = False Then
                    gridmfg.Columns.Insert(0, col)
                    ADDCOL = True
                End If

                gridmfg.Columns(0).Width = 40 'CHECK BOK
                gridmfg.Columns(1).Width = 40 'CHECK BOK
                gridmfg.Columns(2).Width = 40 'CHECK BOK
                gridmfg.Columns(3).Width = 140 'SRNO
                gridmfg.Columns(4).Width = 100 'SRNO
                gridmfg.Columns(5).Width = 80 'SRNO
                gridmfg.Columns(6).Width = 80 'SRNO
                gridmfg.Columns(7).Width = 80 'SRNO
                gridmfg.Columns(8).Width = 60 'SRNO
                gridmfg.Columns(9).Width = 60 'SRNO
                gridmfg.Columns(10).Width = 60 'SRNO
                gridmfg.Columns(11).Width = 60 'SRNO
                If FRMSTRING = "PROCESSOUT" Or FRMSTRING = "PROCESSIN" Or FRMSTRING = "PARTYPACKINGSLIP" Then
                    gridmfg.Columns(1).Visible = False 'SRNO
                Else
                    gridmfg.Columns(1).Visible = True 'SRNO

                End If
                gridmfg.Columns(12).Visible = False 'SRNO
                gridmfg.Columns(13).Visible = False 'SRNO
                gridmfg.Columns(14).Visible = False 'SRNO
                gridmfg.Columns(15).Visible = False 'SRNO
                gridmfg.Columns(16).Visible = False 'SRNO



                gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount - 1

            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            If txtsearch.Text <> "" Then
                If FRMSTRING = "PARTYPACKINGSLIP" Then
                    If cmbselect.Text = "Lot No." Then
                        fillgrid(" AND PROCESSOUT_DESC.PO_LOTNO LIKE '" & txtsearch.Text & "%'") ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()
                    ElseIf cmbselect.Text = "D.O. No." Then
                        fillgrid(" AND PROCESSOUT_DESC.PO_no=" & txtsearch.Text) ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()

                    End If
                ElseIf FRMSTRING = "PROCESSOUT" Or FRMSTRING = "PROCESSIN" Or FRMSTRING = "CHALLAN" Then
                    If cmbselect.Text = "Lot No." Then
                        fillgrid(" AND PARTYPACKINGSLIP_DESC.PPS_LOTNO LIKE '" & txtsearch.Text & "%'") ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()
                    ElseIf cmbselect.Text = "D.O. No." Then
                        fillgrid(" AND PARTYPACKINGSLIP_DESC.PPS_no=" & txtsearch.Text) ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()

                    End If
                End If
            End If

        End If
    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmfg.CellClick
        If e.RowIndex >= 0 Then
            With gridmfg.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                    tempindex = e.RowIndex
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try


            Dim dt As New DataTable

            dt.Columns.Add("FROMNO")
            dt.Columns.Add("LOTNO")
            dt.Columns.Add("NAME")
            dt.Columns.Add("ITEMNAME")
            dt.Columns.Add("QUALITY")
            dt.Columns.Add("PROCESS")
            dt.Columns.Add("PIECETYPE")
            dt.Columns.Add("COLOR")
            dt.Columns.Add("CUT")
            dt.Columns.Add("PCS")
            dt.Columns.Add("MTRS")
            dt.Columns.Add("FROMSRNO")
            dt.Columns.Add("FROMTYPE")
            dt.Columns.Add("GRNNO")
            dt.Columns.Add("GRNSRNO")

            dt.Columns.Add("BALENO")
            dt.Columns.Add("JOBNO")
            dt.Columns.Add("LRNO")
            For Each row As DataGridViewRow In gridmfg.Rows
                If row.Cells(0).Value = True Then
                    dt.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value, row.Cells(18).Value)
                End If
            Next

            If FRMSTRING = "PROCESSOUT" Then
                ProcessOut.selectpotable = dt
            ElseIf FRMSTRING = "PROCESSIN" Then
                ProcessIn.selectpotable = dt
            ElseIf FRMSTRING = "PARTYPACKINGSLIP" Then
                PartyPackingSlip.selectpotable = dt
              
            End If


            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    
    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Dim N As String = "0"
            Dim M As String = "0"
            Dim tempindex As Integer
            Dim i As Integer

            If gridmfg.RowCount > 0 Then
                If chkall.Checked = True And gridmfg.RowCount > 110 Then
                    MsgBox("Too Many Rows Selected")
                    Exit Sub
                End If
                For i = 0 To gridmfg.RowCount - 1
                    With gridmfg.Rows(i).Cells(0)
                        If .Value = True Then N = gridmfg.Item(3, i).Value.ToString

                    End With
                Next


                If chkall.Checked = True Then
                    For i = 0 To gridmfg.RowCount - 1
                        'If gridmfg.CurrentRow.Index >= 0 Then
                        With gridmfg.Rows(i).Cells(0)

                            'If ((gridmfg.Item(1, i).Value.ToString = N) Or N = Nothing) And ((gridmfg.Item(5, i).Value.ToString = M) Or M = Nothing) Then
                            .Value = True
                            N = gridmfg.Item(3, i).Value.ToString

                            tempindex = i
                            'End If
                        End With
                        'End If
                    Next
                Else
                    For i = 0 To gridmfg.RowCount - 1
                        'If Val(gridmfg.CurrentRow.Index) >= 0 Then
                        With gridmfg.Rows(i).Cells(0)
                            .Value = False
                        End With
                        'End If
                    Next
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class