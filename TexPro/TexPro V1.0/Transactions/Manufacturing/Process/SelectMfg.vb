
Imports BL
Imports System.Windows.Forms

Public Class SelectMfg

    Public MfgNO As Integer = 0
    Public PROCESSNAME As String = ""
    Public FRMSTRING As String = ""
    Public GODOWN As String = ""
    Public WHERE1 As String = ""
    Public CUTTING As Boolean = False
    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectMfg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectMfg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        Me.Text = " Select Mfg"
        If FRMSTRING = "MFG" Then
            Mfg.SELECTGRN.Clear()
        Else

        End If
        cmbselect.SelectedIndex = (1)
        CMBPCSMTRS.SelectedIndex = (0)
        txtsearch.Focus()

        'fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal whereclause As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim where As String = ""
            
            If FRMSTRING = "MFG" Then

                If MfgNO <> 0 Then where = " AND [SR.]  = " & MfgNO
                If PROCESSNAME <> "" Then where = " AND [PROCESS NAME]= '" & PROCESSNAME & "'"
                
                Dim objclspreq As New ClsCommon()
                Dim DT As New DataTable

                If PROCESSNAME = "" Then
                    If CUTTING = False Then
                        If txttempname.Text <> "" Then
                            If CMBPCSMTRS.Text = "PCS" Then
                                
                            Else
                                'whereclause = whereclause & " and CHECK_CHECKEDMTRS in (" & txttempname.Text & ")"
                                whereclause = whereclause & " and MTRS in (" & txttempname.Text & ")"

                            End If
                        End If
                        'DT = objclspreq.search(" CHECKINGMASTER_DESC.CHECK_NO AS [Sr.], CHECKINGMASTER_DESC.CHECK_GRIDSRNO AS CHECKSRNO, CHECKINGMASTER.CHECK_DATE AS [Date], LEDGERS.Acc_cmpname AS [Name], CHECKINGMASTER.CHECK_GRNNO AS [Lot No], CHECKINGMASTER.CHECK_GRNGRIDSRNO AS GRNSRNO, ITEMMASTER.item_name AS [Item Name], ISNULL(QUALITYMASTER.QUALITY_name,'') AS [Quality], CHECKINGMASTER.CHECK_REED AS [Reed], CHECKINGMASTER.CHECK_PICK AS [Pick], ISNULL(COLORMASTER.COLOR_name,'') AS [Color], CHECKINGMASTER_DESC.CHECK_CHECKEDMTRS AS [Mtrs], CHECKINGMASTER_DESC.CHECK_WT AS [Wt.], CHECKINGMASTER_DESC.CHECK_NO AS CHECKNO, CHECKINGMASTER_DESC.CHECK_GRIDSRNO AS CHECKSRNO, '1' AS [Pcs],CHECKINGMASTER.check_type as [TYPE]", "", " CHECKINGMASTER INNER JOIN CHECKINGMASTER_DESC ON CHECKINGMASTER.CHECK_NO = CHECKINGMASTER_DESC.CHECK_NO AND CHECKINGMASTER.CHECK_CMPID = CHECKINGMASTER_DESC.CHECK_CMPID AND CHECKINGMASTER.CHECK_LOCATIONID = CHECKINGMASTER_DESC.CHECK_LOCATIONID AND CHECKINGMASTER.CHECK_YEARID = CHECKINGMASTER_DESC.CHECK_YEARID INNER JOIN ITEMMASTER ON CHECKINGMASTER.CHECK_ITEMID = ITEMMASTER.item_id AND CHECKINGMASTER.CHECK_CMPID = ITEMMASTER.item_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = ITEMMASTER.item_locationid AND CHECKINGMASTER.CHECK_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN QUALITYMASTER ON CHECKINGMASTER.CHECK_CMPID = QUALITYMASTER.QUALITY_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND CHECKINGMASTER.CHECK_YEARID = QUALITYMASTER.QUALITY_yearid AND CHECKINGMASTER.CHECK_NEWQUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON CHECKINGMASTER.CHECK_COLORID = COLORMASTER.COLOR_id AND CHECKINGMASTER.CHECK_CMPID = COLORMASTER.COLOR_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = COLORMASTER.COLOR_locationid AND CHECKINGMASTER.CHECK_YEARID = COLORMASTER.COLOR_yearid INNER JOIN LEDGERS ON CHECKINGMASTER.CHECK_VENDORID = LEDGERS.Acc_id AND CHECKINGMASTER.CHECK_CMPID = LEDGERS.Acc_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = LEDGERS.Acc_locationid AND CHECKINGMASTER.CHECK_YEARID = LEDGERS.Acc_yearid", " and CHECKINGMASTER_DESC.CHECK_CHECKINGDONE='False' AND CHECKINGMASTER_DESC.CHECK_APPROVED = 'True' " & where & " AND CHECKINGMASTER.CHECK_CMPID = " & CmpId & " AND CHECKINGMASTER.CHECK_LOCATIONID = " & Locationid & " AND CHECKINGMASTER.CHECK_YEARID = " & YearId & whereclause & "  order by CHECKINGMASTER_DESC.CHECK_no, CHECKINGMASTER_DESC.CHECK_GRIDSRNO")
                        DT = objclspreq.search(" * ", "", " CHECK_VIEW", " AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & whereclause & WHERE1 & "  order by CHECKNO, CHECKSRNO")
                    End If
                Else
                    If CUTTING = False Then
                        If txttempname.Text <> "" Then
                            If CMBPCSMTRS.Text = "PCS" Then
                                whereclause = whereclause & " and CHECKSRNO in (" & txttempname.Text & ")"
                            Else
                                whereclause = whereclause & " and OUTMTRS in (" & txttempname.Text & ")"
                            End If
                        End If
                        DT = objclspreq.search(" distinct [Sr.],[MFGSRNO],[Date],[Process Name],[Lot No],[GRNSRNO],[Item Name],[Quality],[Reed],[Pick],[Color],(Mtrs-outmtrs) as mtrs,[Wt.],[CHECKNO],[CHECKSRNO],[TYPE],(PCS-outpcs) as pcs,[CMPID],[LOCATIONID],[YEARID]", "", " MFG1_VIEW ", "  " & where & " AND PCS-OUTPCS>0 AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & whereclause & WHERE1 & "  order by [SR.], MFGSRNO")
                    Else

                        DT = objclspreq.search(" distinct [Sr.],[MFGSRNO],[Date],[Process Name],[Lot No],[GRNSRNO],[Item Name],[Quality],[Reed],[Pick],[Color],(Mtrs-outmtrs) as mtrs,[Wt.],[CHECKNO],[CHECKSRNO],[TYPE],(PCS-outpcs) as pcs,[CMPID],[LOCATIONID],[YEARID]", "", " MFG1_VIEW ", "  " & where & " AND MTRS-OUTMTRS>0 AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND YEARID = " & YearId & whereclause & WHERE1 & "  order by [SR.], MFGSRNO")

                    End If
                End If
                gridmfg.DataSource = DT

                If DT.Rows.Count > 0 Then

                    If ADDCOL = False Then
                        gridmfg.Columns.Insert(0, col)
                        ADDCOL = True
                    End If

                    gridmfg.Columns(0).Width = 40 'CHECK BOK
                    gridmfg.Columns(1).Width = 40 'SRNO
                    gridmfg.Columns(2).Visible = False  'MFGSRNO
                    gridmfg.Columns(3).Visible = False   'DATE
                    gridmfg.Columns(4).Width = 200  'NAME
                    gridmfg.Columns(5).Width = 70 'grn no
                    gridmfg.Columns(6).Visible = False  'GRN SRNO
                    gridmfg.Columns(7).Width = 150  'ITEM NAME
                    gridmfg.Columns(8).Width = 100  'Quality
                    gridmfg.Columns(9).Width = 50  'Reed
                    gridmfg.Columns(10).Width = 50 'Pick
                    gridmfg.Columns(11).Width = 60 'color
                    gridmfg.Columns(12).Width = 60 'MTRS
                    gridmfg.Columns(13).Width = 60 'WT



                    gridmfg.Columns(1).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(2).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(3).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(4).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(6).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(7).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(9).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(10).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(11).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(13).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(14).Visible = False  'checkno (for MFG)
                    gridmfg.Columns(15).Visible = False  'checksrno (for MFG)

                    gridmfg.Columns(17).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(18).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(19).Visible = False  'checksrno (for MFG)
                    gridmfg.Columns(20).Visible = False  'checksrno (for MFG)


                    If gridmfg.ColumnCount > 21 Then
                        gridmfg.Columns(21).Visible = False  'checksrno (for MFG)
                        gridmfg.Columns(22).Visible = False  'checksrno (for MFG)
                        gridmfg.Columns(23).Visible = False  'checksrno (for MFG)
                        gridmfg.Columns(24).Visible = False  'checksrno (for MFG)
                        gridmfg.Columns(25).Visible = False  'checksrno (for MFG)
                        gridmfg.Columns(26).Visible = False  'checksrno (for MFG)
                        gridmfg.Columns(27).Visible = False  'checksrno (for MFG)

                        gridmfg.Columns(28).Width = 200 'checksrno (for MFG)

                    End If



                    gridmfg.Columns(12).DefaultCellStyle.Format = "N2"
                    gridmfg.Columns(13).DefaultCellStyle.Format = "N2"
                    gridmfg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    gridmfg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount - 1

                End If
            Else

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
                If cmbselect.Text = "Lot No." Then
                    If PROCESSNAME = "" Then
                        'If CUTTING = False Then
                        fillgrid(" AND [lot no]=" & Val(txtsearch.Text)) ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()
                        'Else

                        '    fillgrid(" AND MFGMASTER_DESC_1.MFG_LOTNO=" & Val(txtsearch.Text)) ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()

                        'End If
                    Else
                        fillgrid(" AND [LOT NO]=" & Val(txtsearch.Text)) ' txttempname.Text = gridmfg.Item(5, rowno).Value.ToString()

                    End If
                ElseIf cmbselect.Text = "Name" Then
                    fillgrid(" AND LEDGERS.Acc_cmpname  LIKE '" & txtsearch.Text & "%'")
                ElseIf cmbselect.Text = "Item Name" Then
                    fillgrid(" AND [ITEM NAME] LIKE '" & txtsearch.Text & "%'")

                ElseIf cmbselect.Text = "Quality" Then
                    fillgrid(" AND QUALITY LIKE '" & txtsearch.Text & "%'")

                End If
            Else
                fillgrid()
            End If
        End If
           


    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmfg.CellClick
        Dim N As String = ""
        Dim M As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        If CUTTING = True Then
            For i = 0 To gridmfg.RowCount - 1
                With gridmfg.Rows(i).Cells(0)
                    If .Value = True Then N = gridmfg.Item(1, i).Value.ToString
                    If .Value = True Then M = gridmfg.Item(5, i).Value.ToString
                End With
            Next
        End If
        If e.RowIndex >= 0 Then
            With gridmfg.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    'If ((gridmfg.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing) And ((gridmfg.Item(5, e.RowIndex).Value.ToString = M) Or M = Nothing) Then
                    .Value = True
                    tempindex = e.RowIndex
                    'End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If FRMSTRING = "MFG" And CUTTING = False Then
                Dim dt As New DataTable
                dt.Columns.Add("CHECKNO")
                dt.Columns.Add("CHECKSRNO")
                dt.Columns.Add("MFGNO")
                dt.Columns.Add("MFGSRNO")
                dt.Columns.Add("LOTNO")
                dt.Columns.Add("LOTSRNO")
                dt.Columns.Add("ITEMNAME")
                dt.Columns.Add("QUALITY")
                dt.Columns.Add("REED")
                dt.Columns.Add("PICK")
                dt.Columns.Add("COLOR")
                dt.Columns.Add("MTRS")
                dt.Columns.Add("WT")
                dt.Columns.Add("TYPE")
                dt.Columns.Add("pcs")
                dt.Columns.Add("RATE")



                For Each row As DataGridViewRow In gridmfg.Rows
                    If row.Cells(0).Value = True Then
                        If PROCESSNAME = "" Then
                            'FROM GRN CEHCKING
                            dt.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, 0, 0, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(17).Value, row.Cells(16).Value, Val(row.Cells(21).Value))
                        Else
                            'FROM MFG
                            dt.Rows.Add(row.Cells(14).Value, row.Cells(15).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(16).Value, row.Cells(17).Value, 0)
                        End If
                    End If
                Next
                Mfg.SELECTGRN = dt
                Me.Close()
            Else

                'CODE BY GULKIT
                Dim dt As New DataTable
                

                Dim OBJCMN As New ClsCommon
                Dim TMFGNO As Integer
                Dim GRIDSRNO As Integer
                

                Dim I As Integer = 0
                Dim NEWDT As New DataTable 'dt.Columns.Add("CHECKNO")
                NEWDT.Columns.Add("CHECKNO")
                NEWDT.Columns.Add("CHECKSRNO")
                NEWDT.Columns.Add("MFGNO")
                NEWDT.Columns.Add("MFGSRNO")
                NEWDT.Columns.Add("LOTNO")
                NEWDT.Columns.Add("LOTSRNO")
                NEWDT.Columns.Add("ITEMNAME")
                NEWDT.Columns.Add("QUALITY")
                NEWDT.Columns.Add("REED")
                NEWDT.Columns.Add("PICK")
                NEWDT.Columns.Add("COLOR")
                NEWDT.Columns.Add("INMTRS", System.Type.GetType("System.Decimal"))
                NEWDT.Columns.Add("RECDMTRS", System.Type.GetType("System.Decimal"))
                NEWDT.Columns.Add("CHECKDONE")
                NEWDT.Columns.Add("TYPE")
                NEWDT.Columns.Add("pcs")
                NEWDT.Columns.Add("CHECKGRIDSRNO")


                'NEWDT.Columns.Add("CHECKNO")
                'NEWDT.Columns.Add("CHECKSRNO")
                'NEWDT.Columns.Add("MFGNO")
                'NEWDT.Columns.Add("MFGSRNO")
                'NEWDT.Columns.Add("LOTNO")
                'NEWDT.Columns.Add("LOTSRNO")
                'NEWDT.Columns.Add("ITEMNAME")
                'NEWDT.Columns.Add("QUALITY")
                'NEWDT.Columns.Add("REED")
                'NEWDT.Columns.Add("PICK")
                'NEWDT.Columns.Add("COLOR")
                'NEWDT.Columns.Add("INMTRS", System.Type.GetType("System.Decimal"))
                'NEWDT.Columns.Add("RECDMTRS", System.Type.GetType("System.Decimal"))
                'NEWDT.Columns.Add("CHECKDONE")

                CuttingProcess.selectMFGtable.Clear()

                For Each row As DataGridViewRow In gridmfg.Rows
                    If row.Cells(0).Value = True Then
                        'TMFGNO = row.Cells(1).Value
                        'GRIDSRNO = row.Cells(2).Value
                        ''dt = OBJCMN.search("  MFGMASTER_DESC.MFG_CHECKNO AS CHECKNO, MFGMASTER_DESC.MFG_CHECKGRIDSRNO AS CHECKSRNO, MFGMASTER_DESC.MFG_NO AS [MFGNO], MFGMASTER_DESC.MFG_SRNO AS [MFGSRNO], MFGMASTER_DESC.MFG_LOTNO AS [LOTNO], MFGMASTER_DESC.MFG_LOTSRNO AS [LOTSRNO],MFGMASTER_DESC.MFG_TYPE AS [TYPE], ITEMMASTER.item_name AS [ITEMNAME], QUALITYMASTER.QUALITY_name AS [QUALITY], 	MFGMASTER.MFG_REED AS REED, MFGMASTER.MFG_PICK AS PICK, 0 AS CHECKGRIDSRNO,	 ISNULL(MFGMASTER_DESC.MFG_RECDMTRS, 0) - ISNULL(CUTTINGPROCESS_DESCVIEW.RECDMTRS, 0) AS INMTRS ", "", " MFGMASTER INNER JOIN PROCESSMASTER ON MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID AND MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN ITEMMASTER ON MFGMASTER.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER.MFG_YEARID = ITEMMASTER.item_yearid INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID INNER JOIN PIECETYPEMASTER ON MFGMASTER_DESC.MFG_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND MFGMASTER_DESC.MFG_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND MFGMASTER_DESC.MFG_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND MFGMASTER_DESC.MFG_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN CUTTINGPROCESS_DESCVIEW ON MFGMASTER_DESC.MFG_NO = CUTTINGPROCESS_DESCVIEW.CP_MFGNO AND MFGMASTER_DESC.MFG_SRNO = CUTTINGPROCESS_DESCVIEW.CP_MFGSRNO AND MFGMASTER_DESC.MFG_CHECKNO = CUTTINGPROCESS_DESCVIEW.CP_CHECKNO AND MFGMASTER_DESC.MFG_CHECKGRIDSRNO = CUTTINGPROCESS_DESCVIEW.CP_CHECKGRIDSRNO  LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND MFGMASTER.MFG_NO = " & Val(TMFGNO) & " AND MFGMASTER_DESC.MFG_SRNO = " & Val(GRIDSRNO) & " AND MFGMASTER.MFG_CMPID = " & CmpId & " AND MFGMASTER.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER.MFG_YEARID = " & YearId)

                        'dt = OBJCMN.search("    CHECKNO, CHECKSRNO, [Sr.] AS MFGNO, MFGSRNO, [Lot No] AS LOTNO, GRNSRNO, TYPE, [Item Name] AS ITEMNAME, Quality, Reed, Pick,CHECKSRNO AS CHECKGRIDSRNO, (Mtrs-OUTMTRS) AS MTRS  " ,""," (MFG1_VIEW) " ," AND [sr.] = " & Val(TMFGNO) & " AND MFGMASTER_DESC.MFG_SRNO = " & Val(GRIDSRNO) & " AND MFGMASTER.MFG_CMPID = " & CmpId & " AND MFGMASTER.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER.MFG_YEARID = " & YearId
                        'If dt.Rows.Count > 0 Then
                        '    For Each DTROW As DataRow In dt.Rows
                        '        I = I + 1
                        '        NEWDT.Rows.Add(DTROW("CHECKNO"), DTROW("CHECKSRNO"), DTROW("MFGNO"), DTROW("MFGSRNO"), DTROW("LOTNO"), DTROW("LOTSRNO"), DTROW("TYPE").ToString.Trim, DTROW("ITEMNAME"), DTROW("QUALITY"), DTROW("REED"), DTROW("PICK"), I, DTROW("INMTRS"), 0, 0)
                        '    Next
                        'End If
                        If row.Cells(0).Value = True Then
                            
                            'FROM MFG
                            NEWDT.Rows.Add(row.Cells(14).Value, row.Cells(15).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, 0, 0, row.Cells(16).Value, row.Cells(17).Value, 0)

                        End If
                    End If
                Next


                CuttingProcess.selectMFGtable = NEWDT
                Me.Close()
            End If
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
                
                For i = 0 To gridmfg.RowCount - 1
                    With gridmfg.Rows(i).Cells(0)
                        If .Value = True Then N = gridmfg.Item(1, i).Value.ToString
                        If .Value = True Then M = gridmfg.Item(5, i).Value.ToString
                    End With
                Next


                If chkall.Checked = True Then
                    For i = 0 To gridmfg.RowCount - 1
                        'If gridmfg.CurrentRow.Index >= 0 Then
                        With gridmfg.Rows(i).Cells(0)

                            'If ((gridmfg.Item(1, i).Value.ToString = N) Or N = Nothing) And ((gridmfg.Item(5, i).Value.ToString = M) Or M = Nothing) Then
                            .Value = True
                            N = gridmfg.Item(1, i).Value.ToString
                            M = gridmfg.Item(5, i).Value.ToString
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


    Private Sub txttempname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttempname.Validated
        If CMBPCSMTRS.Text = "PCS" And Val(txttempname.Text) <> 0 Then
LINE1:
            For I As Integer = 0 To gridmfg.RowCount - 1
                If I > Val(txttempname.Text) - 1 Then
                    gridmfg.Rows.RemoveAt(I)
                    GoTo LINE1
                End If
            Next
            If gridmfg.RowCount > 0 Then txtsearch.Enabled = False
            If Val(gridmfg.RowCount) <> Val(txttempname.Text) And Val(txttempname.Text) > 0 Then
                MsgBox(Val(gridmfg.RowCount) & " Pcs Available")
                txttempname.Text = Val(gridmfg.RowCount)
            End If
        End If
    End Sub
End Class