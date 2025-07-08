
Imports BL

Public Class SelectMfgforPS
    Public final As Boolean = False

    Public MfgNO As Integer = 0
    Public PROCESSNAME As String = ""
    Public TYPE As String = ""
    Public FRMSTRING As String = ""
    Public GODOWN As String = ""
    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn

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
        Me.Text = " Select Mfg"
        cmbselect.SelectedIndex = (0)
        'fillgrid()
        If PROCESSNAME <> "WHITE FOLDING" Then fillcheckboxlist()
    End Sub

    Sub fillgrid(Optional ByVal WHERE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor


            'If MfgNO <> 0 Then where = " AND PACKINGSLIPVIEW.MFGNO  = " & MfgNO
            'If PROCESSNAME <> "" Then
            '    where = 
            'Else
            WHERE = WHERE & " AND PACKINGSLIPVIEW.PROCESSNAME = '" & PROCESSNAME & "'"
            Dim objclspreq As New ClsCommon()
            Dim DT As New DataTable

            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" And PROCESSNAME = "" Then
                WHERE = WHERE & " AND PACKINGSLIPVIEW.GRNTYPE = 'LOOSE'"
                DT = objclspreq.Execute_Any_String("SELECT TYPE, MFGNO AS [Sr.], MFGSRNO, MFGDATE, PIECETYPE AS [Piece],  ITEMNAME as [Item Name], QUALITY as [Quality], REED as Reed, PICK as Pick, COLOR as Color, DESIGNNO as Design, CUT as Cut, RECDPCS as Pcs, ROUND(RECDMTRS-OUTMTRS,2) as Mtrs, CHECKNO , CHECKSRNO, GRIDMFGNO, GRIDMFGSRNO, LOTNO AS [Lot No],JOBNO, LOTSRNO,CHARTNO,SAREE,WT,GRNTYPE FROM PACKINGSLIPVIEW WHERE YEARID = " & YearId & " " & WHERE & " order by PACKINGSLIPVIEW.Mfgno, PACKINGSLIPVIEW.MfgSRNO", "", "")
            Else
                DT = objclspreq.Execute_Any_String("SELECT TYPE, MFGNO AS [Sr.], MFGSRNO, MFGDATE, PIECETYPE AS [Piece],  ITEMNAME as [Item Name], QUALITY as [Quality], REED as Reed, PICK as Pick, COLOR as Color, DESIGNNO as Design, CUT as Cut, RECDPCS as Pcs, RECDMTRS as Mtrs, CHECKNO , CHECKSRNO, GRIDMFGNO, GRIDMFGSRNO, LOTNO AS [Lot No],JOBNO, LOTSRNO,CHARTNO,SAREE,WT,GRNTYPE FROM PACKINGSLIPVIEW WHERE ISNULL(GODOWN,'') = '" & GODOWN & "' AND LOCATIONID = 0 AND CMPID = " & CmpId & " AND YEARID = " & YearId & " " & WHERE & " order by PACKINGSLIPVIEW.Mfgno, PACKINGSLIPVIEW.MfgSRNO", "", "")
            End If

            'End If

            gridmfg.DataSource = DT

            If DT.Rows.Count > 0 Then

                If ADDCOL = False Then
                    gridmfg.Columns.Insert(0, col)
                    ADDCOL = True
                End If

                gridmfg.Columns(0).Width = 40 'CHECK BOK
                gridmfg.Columns(1).Visible = False 'type
                gridmfg.Columns(2).Visible = False 'SRNO
                gridmfg.Columns(3).Visible = False  'MFGSRNO
                gridmfg.Columns(4).Visible = False   'DATE
                gridmfg.Columns(5).Width = 70 'piecetype
                gridmfg.Columns(6).Width = 150  'ITEM NAME
                gridmfg.Columns(7).Visible = False 'Quality
                gridmfg.Columns(8).Visible = False  'REED
                gridmfg.Columns(9).Visible = False   'PICK
                gridmfg.Columns(10).Width = 60 'color
                gridmfg.Columns(11).Width = 60 'designno
                gridmfg.Columns(12).Width = 40 'cut
                gridmfg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridmfg.Columns(13).Width = 40 'pcs
                gridmfg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridmfg.Columns(14).Width = 60 'MTRS
                gridmfg.Columns(15).Visible = False  'checkno
                gridmfg.Columns(16).Visible = False 'checksrno
                gridmfg.Columns(17).Visible = False 'gridmfgno
                gridmfg.Columns(18).Visible = False 'gridmfgsrno
                gridmfg.Columns(19).Width = 70  'lot (for MFG)
                gridmfg.Columns(20).Width = 70  'JOB NO
                gridmfg.Columns(21).Visible = False  'lotsrno (for MFG)
                gridmfg.Columns(22).Width = 70  'CHARTNO
                gridmfg.Columns(23).Width = 70  'SAREE
                gridmfg.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridmfg.Columns(24).Visible = False 'WT
                gridmfg.Columns(25).Visible = False 'GRNTYPE


                gridmfg.Columns(14).DefaultCellStyle.Format = "N2"
                gridmfg.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount - 1

            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmfg.CellClick
        'Dim N As String = ""
        'Dim M As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        For i = 0 To gridmfg.RowCount - 1
            With gridmfg.Rows(i).Cells(0)
                'If .Value = True Then N = gridmfg.Item(1, i).Value.ToString
                'If .Value = True Then M = gridmfg.Item(5, i).Value.ToString
            End With
        Next

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

            If FRMSTRING = "MFG" Then
                Dim dt As New DataTable

                dt.Columns.Add("TYPE")
                dt.Columns.Add("PIECETYPE")
                dt.Columns.Add("ITEMNAME")
                dt.Columns.Add("QUALITY")
                dt.Columns.Add("REED")
                dt.Columns.Add("PICK")
                dt.Columns.Add("COLOR")
                dt.Columns.Add("DESIGNNO")
                dt.Columns.Add("CUT")
                dt.Columns.Add("PCS")
                dt.Columns.Add("MTRS")
                dt.Columns.Add("CHECKNO")
                dt.Columns.Add("CHECKSRNO")
                dt.Columns.Add("MFGNO")
                dt.Columns.Add("MFGSRNO")
                dt.Columns.Add("LOTNO")
                dt.Columns.Add("jobno")
                dt.Columns.Add("LOTSRNO")
                dt.Columns.Add("CHARTNO")
                dt.Columns.Add("SAREE")
                dt.Columns.Add("WT")
                dt.Columns.Add("GRNTYPE")


                For Each row As DataGridViewRow In gridmfg.Rows
                    If row.Cells(0).Value = True Then
                        dt.Rows.Add(row.Cells(1).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(19).Value, row.Cells(20).Value, row.Cells(21).Value, row.Cells(22).Value, row.Cells(23).Value, row.Cells(24).Value, row.Cells(25).Value)
                    End If
                Next
                If final = False Then
                    PackingSlip.SELECTPS = dt
                Else
                    finalPackingslip.SELECTMFGTABLE = dt

                End If

                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            If chkall.Checked = True Then
                For i As Integer = 0 To gridmfg.RowCount - 1
                    'If gridmfg.CurrentRow.Index >= 0 Then
                    With gridmfg.Rows(i).Cells(0)

                        .Value = True

                    End With
                    'End If
                Next
            Else
                For i As Integer = 0 To gridmfg.RowCount - 1
                    'If gridmfg.CurrentRow.Index >= 0 Then
                    With gridmfg.Rows(i).Cells(0)
                        .Value = False
                    End With
                    'End If
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim WHERECLAUSE As String = ""

        '***************search for DESIGN NO ****************

        Dim checked_DESIGNNO As CheckedListBox.CheckedItemCollection = CLB_designno.CheckedItems
        Dim DESIGNNO As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_DESIGNNO
            If DESIGNNO = "" Then
                DESIGNNO = "'" & item.ToString() & "'"
            Else
                DESIGNNO = DESIGNNO & ",'" & item.ToString() & "'"
            End If
        Next item

        If DESIGNNO <> "" Then
            WHERECLAUSE = WHERECLAUSE & " and DESIGNNO IN (" & DESIGNNO & ")"
        End If
        '*********end of current Block ********


        '***************search for JOB NO ****************
        Dim checked_JOBNO As CheckedListBox.CheckedItemCollection = CLB_JOBNO.CheckedItems
        Dim JOBNO As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_JOBNO
            If JOBNO = "" Then
                JOBNO = "'" & item.ToString() & "'"
            Else
                JOBNO = JOBNO & ",'" & item.ToString() & "'"
            End If
        Next item
      
        If JOBNO <> "" Then
            WHERECLAUSE = WHERECLAUSE & " and JOBNO IN (" & JOBNO & ")"
        End If

        '*********end of current Block ********
        '***************search for DESIGN NO ****************


        Dim checked_MERCHANT As CheckedListBox.CheckedItemCollection = CLB_ITEMNAME.CheckedItems
        Dim MERCHANT As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_MERCHANT
            If MERCHANT = "" Then
                MERCHANT = "'" & item.ToString() & "'"
            Else
                MERCHANT = MERCHANT & ",'" & item.ToString() & "'"
            End If
        Next item

        If MERCHANT <> "" Then
            WHERECLAUSE = WHERECLAUSE & " and [ITEMNAME] IN (" & MERCHANT & ")"
        End If
        '*********end of current Block ********
        '***************search for PICETYPE  ****************
        Dim checked_PIECETYPE As CheckedListBox.CheckedItemCollection = clb_piecetype.CheckedItems
        Dim PIECETYPE As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_PIECETYPE
            If PIECETYPE = "" Then
                PIECETYPE = "'" & item.ToString() & "'"
            Else
                PIECETYPE = PIECETYPE & ",'" & item.ToString() & "'"
            End If
        Next item

        If PIECETYPE <> "" Then
            WHERECLAUSE = WHERECLAUSE & " and PIECETYPE IN (" & PIECETYPE & ")"
        End If

        '*********end of current Block ********
        fillgrid(WHERECLAUSE)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        fillgrid()
        fillcheckboxlist()
    End Sub

    Private Sub chkall_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Dim N As String = ""
            Dim M As String = ""

            Dim tempindex As Integer
            Dim i As Integer

            If gridmfg.RowCount > 0 Then
                If chkall.Checked = True And gridmfg.RowCount > 110 Then
                    MsgBox("Too Many Rows Selected")
                    Exit Sub
                End If
                For i = 0 To gridmfg.RowCount - 1
                    With gridmfg.Rows(i).Cells(0)
                        'If .Value = True Then N = gridmfg.Item(20, i).Value.ToString
                        'If .Value = True Then M = gridmfg.Item(10, i).Value.ToString
                    End With
                Next


                If chkall.Checked = True Then
                    For i = 0 To gridmfg.RowCount - 1
                        With gridmfg.Rows(i).Cells(0)

                            'If ((gridmfg.Item(20, i).Value.ToString = N) Or N = Nothing) And ((gridmfg.Item(10, i).Value.ToString = M) Or M = Nothing) Then
                            .Value = True
                            'N = gridmfg.Item(20, i).Value.ToString
                            'M = gridmfg.Item(10, i).Value.ToString
                            tempindex = i
                            'End If
                        End With

                    Next
                Else
                    For i = 0 To gridmfg.RowCount - 1

                        With gridmfg.Rows(i).Cells(0)
                            .Value = False
                        End With

                    Next
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkjobno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkjobno.CheckedChanged
        If chkjobno.Checked = True Then
            For i As Integer = 0 To CLB_JOBNO.Items.Count - 1
                CLB_JOBNO.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_JOBNO.Items.Count - 1
                CLB_JOBNO.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chkdesignno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdesignno.CheckedChanged
        If chkdesignno.Checked = True Then
            For i As Integer = 0 To CLB_designno.Items.Count - 1
                CLB_designno.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_designno.Items.Count - 1
                CLB_designno.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chkpiecetype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpiecetype.CheckedChanged
        If chkpiecetype.Checked = True Then
            For i As Integer = 0 To clb_piecetype.Items.Count - 1
                clb_piecetype.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To clb_piecetype.Items.Count - 1
                clb_piecetype.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chkmerchant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmerchant.CheckedChanged
        If chkmerchant.Checked = True Then
            For i As Integer = 0 To CLB_ITEMNAME.Items.Count - 1
                CLB_ITEMNAME.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_ITEMNAME.Items.Count - 1
                CLB_ITEMNAME.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub txtsearch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated

        Dim rowno, b As Integer
        Dim obj As New CheckedListBox
        rowno = 0

        If cmbselect.Text = "Job No" Then
            obj = CLB_JOBNO
        ElseIf cmbselect.Text = "Design No" Then
            obj = CLB_designno
        ElseIf cmbselect.Text = "Merchant" Then
            obj = CLB_ITEMNAME
        ElseIf cmbselect.Text = "Piece Type" Then
            obj = clb_piecetype
        ElseIf cmbselect.Text = "Lot No" Then
            If txtsearch.Text.Trim <> "" Then
                fillgrid(" AND LOTNO in (" & txtsearch.Text.Trim & ")")
            Else
                fillgrid("")
            End If
        End If

        For b = 1 To obj.Items.Count

            txttempname.Text = obj.Items(rowno)
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtsearch.TextLength
            If LCase(txtsearch.Text.Trim) = LCase(txttempname.SelectedText.Trim) Then
                obj.SelectedIndex = rowno
                obj.Focus()
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Sub fillcheckboxlist()
        Dim dt As DataTable
        Dim objclscomm As New ClsCommon()

        'Fill CUSTOMER
        dt = objclscomm.search(" DISTINCT DESIGNNO ", "", " PACKINGSLIPVIEW ", " AND PROCESSNAME = '" & PROCESSNAME & "' AND CMPID = " & CmpId & " AND LOCATIONID = 0 AND  Yearid=" & YearId & " AND DESIGNNO <> ''")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_designno.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If
        'Fill CUSTOMER
        dt = objclscomm.search(" DISTINCT PIECETYPE ", "", " PACKINGSLIPVIEW ", " AND PROCESSNAME = '" & PROCESSNAME & "' AND CMPID = " & CmpId & " AND LOCATIONID = 0 AND  Yearid=" & YearId & " AND PIECETYPE<> '' ORDER BY PIECETYPE")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                clb_piecetype.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If

        'Fill CUSTOMER
        dt = objclscomm.search(" DISTINCT ITEMNAME ", "", " PACKINGSLIPVIEW ", " AND PROCESSNAME = '" & PROCESSNAME & "' AND CMPID = " & CmpId & " AND LOCATIONID = 0 AND Yearid=" & YearId & " AND ITEMNAME <> '' ")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_ITEMNAME.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If


        dt = objclscomm.search(" DISTINCT PACKINGSLIPVIEW.JOBNO ", "", " PACKINGSLIPVIEW ", " AND PROCESSNAME = '" & PROCESSNAME & "' AND CMPID = " & CmpId & " AND LOCATIONID = 0 AND YEARID =" & YearId & " AND JOBNO <> '' ORDER BY JOBNO")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_JOBNO.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If
    End Sub
End Class