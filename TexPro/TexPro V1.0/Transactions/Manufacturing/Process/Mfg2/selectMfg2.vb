
Imports BL
Imports System.Windows.Forms

Public Class selectMfg2

    Public MfgNO As Integer = 0
    Public Fcutting As Boolean = False
    Public PROCESSNAME As String = ""
    Public WHERE As String = ""
    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public GODOWN As String = ""

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
        If PROCESSNAME = "CUTTING" Then
            Me.Text = " Select Cutting"
        Else
            Me.Text = " Select Mfg (Printing)"

        End If
        fillcheckboxlist()
        cmbselect.SelectedIndex = (1)
        txtsearch.Focus()
        'fillgrid()
    End Sub

    Sub fillcheckboxlist()
        Dim dt As DataTable
        Dim objclscomm As New ClsCommon()

        'Fill DESIGNRECIPE
        dt = objclscomm.search(" DISTINCT DESIGN_NO ", "", " DESIGNRECIPE ", " AND DESIGNRECIPE.DESIGN_Yearid=" & YearId & " ORDER BY DESIGNRECIPE.DESIGN_NO")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_designno.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If


        'Fill LOTNO
        If ClientName = "SHREENATH" Then
            dt = objclscomm.search(" DISTINCT  [Lot No.] AS LOTNO ", "", " GRN_VIEW ", " AND CHECKDONE='A' and Yearid=" & YearId & " ORDER BY LOTNO")
        Else
            dt = objclscomm.search(" DISTINCT LOTNO ", "", " MFG2_VIEW ", " AND DONE = 0 and Yearid=" & YearId & " ORDER BY LOTNO")
        End If
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_LOTNO.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If


        'Fill ITEMNAME
        dt = objclscomm.search(" DISTINCT ITEM_NAME ", "", " ITEMMASTER ", " AND ITEMMASTER.ITEM_Yearid=" & YearId & " AND ITEM_FRMSTRING ='MERCHANT' ORDER BY ITEMMASTER.ITEM_NAME")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_ITEMNAME.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If

        'Fill CUSTOMER
        If PROCESSNAME = "CUTTING" Then
            dt = objclscomm.search(" DISTINCT CP_JOBNO ", "", " CUTTINGPROCESS ", " AND CUTTINGPROCESS.CP_Yearid=" & YearId & " ORDER BY CUTTINGPROCESS.CP_JOBNO")
        ElseIf PROCESSNAME = "JOB IN" Then
            dt = objclscomm.search(" DISTINCT JOBNO", "", " PACKINGSLIPVIEW ", " AND PROCESSNAME='JOB IN' and Yearid=" & YearId & " AND CMPID = " & CmpId & " AND LOCATIONID = 0 ORDER BY JOBNO")
        ElseIf PROCESSNAME = "LOOSE STOCK" Then
            dt = objclscomm.search(" DISTINCT JOBNO ", "", " PACKINGSLIPVIEW ", " AND GRNTYPE='LOOSE' and Yearid=" & YearId & " AND CMPID = " & CmpId & " AND LOCATIONID = 0 ORDER BY JOBNO")
        Else
            dt = objclscomm.search(" T.JOBNO ", "", " (SELECT DISTINCT MFG_JOBNO AS JOBNO FROM MFGMASTER2 WHERE MFGMASTER2.MFG_Yearid=" & YearId & " AND MFGMASTER2.MFG_CMPID=" & CmpId & " AND MFGMASTER2.MFG_LOCATIONID= 0 UNION ALL SELECT DISTINCT SM_JOBNO FROM STOCKMASTER WHERE SM_Yearid=" & YearId & " AND SM_CMPID = " & CmpId & " AND SM_LOCATIONID = 0) AS T", " ORDER BY T.JOBNO")
        End If
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_JOBNO.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If
    End Sub

    Private Sub chkcust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdesignno.CheckedChanged
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

    Sub fillgrid(Optional ByVal WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor

            If MfgNO <> 0 Then WHERE = WHERE & " AND MFGNO  = " & MfgNO
            If PROCESSNAME <> "" And PROCESSNAME <> "CUTTING" Then WHERE = " AND PROCESS = '" & PROCESSNAME & "'"

            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable

            If PROCESSNAME = "CUTTING" Then
                WHERECLAUSE.Replace("DESIGNNO", "DESIGN")
                DT = objclspreq.search(" * ", "", " CUTTING_VIEW ", "   " & WHERE & " AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND CMPID = " & CmpId & WHERECLAUSE & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId) 'and CUTTINGPROCESS_DESC.CP_GRIDDONE='False' ' NO NEED INSTEAD USE PCS-RECDPCS
            ElseIf PROCESSNAME = "JOB IN" Then
                DT = objclspreq.search(" MFGNO,MFGDATE,PROCESSNAME,ITEMNAME,CONTRACTOR,SUPERVISOR,LOTNO,QUALITY,CUT,DESIGNNO,MFGSRNO,PIECETYPE,COLOR,INPCS,0,SAREE,INMTRS,LOTSRNO,GRNTYPE,JOBNO,0,0 ", "", " PACKINGSLIPVIEW ", " AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND PROCESSNAME='JOB IN' " & WHERECLAUSE & " AND YEARID = " & YearId) 'and CUTTINGPROCESS_DESC.CP_GRIDDONE='False' ' NO NEED INSTEAD USE PCS-RECDPCS
            ElseIf PROCESSNAME = "LOOSE STOCK" Then
                DT = objclspreq.search(" MFGNO,MFGDATE,PROCESSNAME,ITEMNAME,CONTRACTOR,SUPERVISOR,LOTNO,QUALITY,CUT,DESIGNNO,MFGSRNO,PIECETYPE,COLOR,INPCS,0,SAREE,INMTRS,LOTSRNO,TYPE,JOBNO,0,0 ", "", " PACKINGSLIPVIEW ", " AND PROCESSNAME = ''  AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND (GRNTYPE='LOOSE' OR GRNTYPE='SALERETURN')  " & WHERECLAUSE & " AND YEARID = " & YearId)
            ElseIf PROCESSNAME = "FINAL CUTTING" Then
                DT = objclspreq.search(" * ", "", "(SELECT FINALCUTTINGPROCESS_PCSDESC.FCP_NO AS FCPNO, FINALCUTTINGPROCESS.FCP_DATE AS DATE, 'FINAL CUTTING' AS PROCESSNAME, ITEMMASTER.item_name AS ITEMNAME, ISNULL(CONTRACTORMASTER.CONTRACTOR_name, '') AS CONTRACTOR, ISNULL(SUPERVISIORMASTER.SUPERVISIOR_name, '') AS SUPERVISOR, ISNULL(FINALCUTTINGPROCESS.FCP_JOBNO, '') AS LOTNO, '' AS QUALITY, FINALCUTTINGPROCESS_PCSDESC.FCP_CUT AS CUT, ISNULL(DESIGNRECIPE.DESIGN_NO,'') AS DESIGNNO, FINALCUTTINGPROCESS_PCSDESC.FCP_CONSRNO AS FCPSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, '' AS COLOR, (FINALCUTTINGPROCESS_PCSDESC.FCP_SAREE - FINALCUTTINGPROCESS_PCSDESC.FCP_OUTSAREE) AS INPCS, 0 AS Expr1, (FINALCUTTINGPROCESS_PCSDESC.FCP_SAREE - FINALCUTTINGPROCESS_PCSDESC.FCP_OUTSAREE) AS SAREE, ((FINALCUTTINGPROCESS_PCSDESC.FCP_SAREE - FINALCUTTINGPROCESS_PCSDESC.FCP_OUTSAREE)* FINALCUTTINGPROCESS_PCSDESC.FCP_CUT) AS INMTRS, 0 AS LOTSRNO, 'FINAL CUTTING' AS GRNTYPE, FINALCUTTINGPROCESS.FCP_JOBNO AS JOBNO FROM FINALCUTTINGPROCESS INNER JOIN FINALCUTTINGPROCESS_PCSDESC ON FINALCUTTINGPROCESS.FCP_NO = FINALCUTTINGPROCESS_PCSDESC.FCP_NO AND FINALCUTTINGPROCESS.FCP_CMPID = FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID AND FINALCUTTINGPROCESS.FCP_LOCATIONID = FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID AND FINALCUTTINGPROCESS.FCP_YEARID = FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN DESIGNRECIPE ON FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = DESIGNRECIPE.DESIGN_yearid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = DESIGNRECIPE.DESIGN_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = DESIGNRECIPE.DESIGN_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_DESIGNID = DESIGNRECIPE.DESIGN_id LEFT OUTER JOIN SUPERVISIORMASTER ON FINALCUTTINGPROCESS.FCP_YEARID = SUPERVISIORMASTER.SUPERVISIOR_yearid AND FINALCUTTINGPROCESS.FCP_LOCATIONID = SUPERVISIORMASTER.SUPERVISIOR_locationid AND FINALCUTTINGPROCESS.FCP_CMPID = SUPERVISIORMASTER.SUPERVISIOR_cmpid AND FINALCUTTINGPROCESS.FCP_SUPERVISIORID = SUPERVISIORMASTER.SUPERVISIOR_id LEFT OUTER JOIN CONTRACTORMASTER ON FINALCUTTINGPROCESS.FCP_YEARID = CONTRACTORMASTER.CONTRACTOR_yearid AND FINALCUTTINGPROCESS.FCP_LOCATIONID = CONTRACTORMASTER.CONTRACTOR_locationid AND FINALCUTTINGPROCESS.FCP_CMPID = CONTRACTORMASTER.CONTRACTOR_cmpid AND FINALCUTTINGPROCESS.FCP_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id LEFT OUTER JOIN ITEMMASTER ON FINALCUTTINGPROCESS.FCP_MERCHANTID = ITEMMASTER.item_id AND FINALCUTTINGPROCESS.FCP_CMPID = ITEMMASTER.item_cmpid AND FinalCuttingProcess.FCP_LOCATIONID = ItemMaster.item_locationid And FinalCuttingProcess.FCP_YEARID = ItemMaster.item_yearid LEFT OUTER JOIN GODOWNMASTER ON FCP_GODOWNID = GODOWN_ID WHERE FINALCUTTINGPROCESS.FCP_CMPID = " & CmpId & " AND (FINALCUTTINGPROCESS_PCSDESC.FCP_SAREE - FINALCUTTINGPROCESS_PCSDESC.FCP_OUTSAREE ) > 0 AND ISNULL(GODOWN_NAME,'') = '" & GODOWN & "' AND FINALCUTTINGPROCESS.FCP_LOCATIONID  = " & Locationid & " AND FINALCUTTINGPROCESS.FCP_YEARID  = " & YearId & ") AS T ", WHERECLAUSE)

                'FOR SHREENATH WE WILL FETCH FROM GRN AND OPENING
            ElseIf PROCESSNAME = "FINISHING" And ClientName = "SHREENATH" Then
                DT = objclspreq.search(" GRNNO AS MFGNO, DATE AS MFGDATE, '" & PROCESSNAME & "' AS PROCESSNAME, [Item Name] AS MERCHANTNAME, NAME AS CONTRACTOR, '' AS SUPERVISOR, [Lot No.] AS LOTNO, QUALITY, 0 AS CUT, '' AS DESIGNNO, GRIDSRNO AS SRNO, 'FRESH' AS PIECETYPE, '' AS COLOR, QTY AS INPCS, 0, 0 AS SAREE, MTRS AS INMTRS, GRIDSRNO AS LOTSRNO, TYPE AS GRNTYPE, CAST([Lot No.] AS VARCHAR(50)) AS JOBNO, 0 , 0 ", "", " GRN_VIEW ", " and CHECKDONE='A' AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND YEARID = " & YearId & WHERECLAUSE & "  order by [Lot No.] ")

            Else
                WHERECLAUSE = WHERECLAUSE.ToString.Replace("DESIGNNO", "DESIGN")
                DT = objclspreq.search(" * ", "", " MFG2_VIEW ", " " & WHERE & " AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & WHERECLAUSE & " AND YEARID = " & YearId & "  ")
            End If
            gridmfg.DataSource = DT

            If DT.Rows.Count > 0 Then
                If ADDCOL = False Then
                    gridmfg.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                gridmfg.Columns(0).Width = 40 'CHECK BOK
                gridmfg.Columns(1).Visible = False 'MFGNO
                gridmfg.Columns(2).Width = 80   'MFGDATE
                gridmfg.Columns(3).Width = 90   'PROCESSNAME
                gridmfg.Columns(4).Width = 80       'ITEMNAME
                gridmfg.Columns(5).Visible = False  'CONTRACTOR
                gridmfg.Columns(6).Visible = False  'SUPERVISOR
                gridmfg.Columns(7).Width = 60       'LOTNO
                gridmfg.Columns(8).Width = 90       'QUALITY
                gridmfg.Columns(9).Width = 50       'CUT
                gridmfg.Columns(10).Width = 60      'DESIGNNO
                gridmfg.Columns(11).Visible = False 'SRNO
                gridmfg.Columns(12).Visible = False 'PIECETYPE
                gridmfg.Columns(13).Visible = False 'COLOR
                gridmfg.Columns(14).Visible = False 'INPCS
                gridmfg.Columns(15).Visible = False '0
                gridmfg.Columns(16).Width = 80      'SAREE
                gridmfg.Columns(17).Width = 80      'INMTRS
                gridmfg.Columns(18).Visible = False 'LOTSRNO
                gridmfg.Columns(19).Visible = False 'GRNTYPE
                gridmfg.Columns(20).Width = 60      'JOBNO
                If PROCESSNAME <> "CUTTING" And PROCESSNAME <> "FINAL CUTTING" Then
                    gridmfg.Columns(21).Visible = False
                    gridmfg.Columns(22).Visible = False
                End If

                gridmfg.Columns(14).DefaultCellStyle.Format = "N2"
                gridmfg.Columns(15).DefaultCellStyle.Format = "N2"
                gridmfg.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridmfg.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridmfg.Columns(16).DefaultCellStyle.Format = "N2"
                gridmfg.Columns(17).DefaultCellStyle.Format = "N2"
                gridmfg.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridmfg.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                gridmfg.FirstDisplayedScrollingRowIndex = gridmfg.RowCount - 1

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub


    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridmfg.CellClick
        Dim N As String = ""
        Dim M As String = ""
        Dim tempindex As Integer
        Dim i As Integer


        For i = 0 To gridmfg.RowCount - 1
            With gridmfg.Rows(i).Cells(0)
                If .Value = True Then N = gridmfg.Item(20, i).Value.ToString
                'And Fcutting = False
                If .Value = True Then M = gridmfg.Item(10, i).Value.ToString
            End With
        Next

        If e.RowIndex >= 0 Then
            With gridmfg.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    If Fcutting = True And ((gridmfg.Item(20, e.RowIndex).Value.ToString = N) Or N = Nothing) Then
                        .Value = True
                        tempindex = e.RowIndex

                    Else 'If ((gridmfg.Item(20, e.RowIndex).Value.ToString = N) Or N = Nothing) And ((gridmfg.Item(10, e.RowIndex).Value.ToString = M) Or M = Nothing) Then
                        'And Fcutting = False 
                        .Value = True
                        tempindex = e.RowIndex
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try


            Dim dt As New DataTable
            dt.Columns.Add("CPNO")
            dt.Columns.Add("MFGDATE")
            dt.Columns.Add("GRIDSRNO")
            dt.Columns.Add("MERCHANT")
            dt.Columns.Add("CONTRACTOR")
            dt.Columns.Add("SUPERVISIOR")
            dt.Columns.Add("LOTNO")
            dt.Columns.Add("LOTSRNO")
            dt.Columns.Add("QUALITY")
            dt.Columns.Add("CUT")
            dt.Columns.Add("DESIGN")
            dt.Columns.Add("PIECETYPE")
            dt.Columns.Add("COLOR")
            dt.Columns.Add("PCS")
            dt.Columns.Add("PCSMTRS")
            dt.Columns.Add("SAREE")
            dt.Columns.Add("MTRS")

            dt.Columns.Add("MFGNO")
            dt.Columns.Add("MFGSRNO")
            dt.Columns.Add("TYPE")
            dt.Columns.Add("JOBNO")


            For Each row As DataGridViewRow In gridmfg.Rows
                If row.Cells(0).Value = True Then
                    If PROCESSNAME = "CUTTING" Then
                        'FROM GRN CEHCKING
                        dt.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(11).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(18).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value, 0, 0, row.Cells(19).Value, row.Cells(20).Value)
                    ElseIf PROCESSNAME = "FINAL CUTTING" Then
                        'FROM GRN CEHCKING
                        dt.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(11).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(18).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value, 0, 0, row.Cells(19).Value, row.Cells(20).Value)
                    Else
                        'dt.Rows.Add(row.Cells(1).Value, row.Cells(11).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(18).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value, row.Cells(21).Value, row.Cells(22).Value, row.Cells(19).Value, row.Cells(20).Value)
                        dt.Rows.Add(row.Cells(21).Value, row.Cells(2).Value, row.Cells(22).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(18).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value, row.Cells(1).Value, row.Cells(11).Value, row.Cells(19).Value, row.Cells(20).Value)

                    End If
                End If
            Next
            If Fcutting = False Then
                Mfg2.SELECTMFG = dt
            Else
                FinalCuttingProcess.SELECTMFG = dt

            End If
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSEARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSEARCH.Click

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


        '***************search for DESIGN NO ****************
        Dim checked_LOTNO As CheckedListBox.CheckedItemCollection = CLB_LOTNO.CheckedItems
        Dim LOTNO As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_LOTNO
            If LOTNO = "" Then
                LOTNO = "'" & item.ToString() & "'"
            Else
                LOTNO = LOTNO & ",'" & item.ToString() & "'"
            End If
        Next item
        If LOTNO <> "" Then
            If ClientName = "SHREENATH" Then WHERECLAUSE = WHERECLAUSE & " and [Lot No.] IN (" & LOTNO & ")" Else WHERECLAUSE = WHERECLAUSE & " and LOTNO IN (" & LOTNO & ")"
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
        If PROCESSNAME = "CUTTING" Then
            If JOBNO <> "" Then
                WHERECLAUSE = WHERECLAUSE & " and JOBNO IN (" & JOBNO & ")"
            End If
        Else
            If JOBNO <> "" Then
                WHERECLAUSE = WHERECLAUSE & " and JOBNO IN (" & JOBNO & ")"
            End If
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
            If ClientName = "SHREENATH" Then WHERECLAUSE = WHERECLAUSE & " and [Item Name] IN (" & MERCHANT & ")" Else WHERECLAUSE = WHERECLAUSE & " and ITEMNAME IN (" & MERCHANT & ")"
        End If
        '*********end of current Block ********

        fillgrid(WHERECLAUSE)
        chkall.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEARSEARCH.Click
        fillgrid()
        fillcheckboxlist()
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
        ElseIf cmbselect.Text = "Lot No" Then
            obj = CLB_LOTNO
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

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
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
                        If .Value = True Then N = gridmfg.Item(20, i).Value.ToString
                        'And Fcutting = False
                        If .Value = True Then M = gridmfg.Item(10, i).Value.ToString
                    End With
                Next


                If chkall.Checked = True Then
                    For i = 0 To gridmfg.RowCount - 1
                        With gridmfg.Rows(i).Cells(0)

                            If ((gridmfg.Item(20, i).Value.ToString = N) Or N = Nothing) And ((gridmfg.Item(10, i).Value.ToString = M) Or M = Nothing) Or (((gridmfg.Item(20, i).Value.ToString = N) Or N = Nothing) And Fcutting = True) Then
                                .Value = True
                                N = gridmfg.Item(20, i).Value.ToString
                                M = gridmfg.Item(10, i).Value.ToString
                                tempindex = i
                            End If
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

    Private Sub CHKLOTNO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKLOTNO.CheckedChanged
        If CHKLOTNO.Checked = True Then
            For i As Integer = 0 To CLB_LOTNO.Items.Count - 1
                CLB_LOTNO.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_LOTNO.Items.Count - 1
                CLB_LOTNO.SetItemChecked(i, False)
            Next
        End If
    End Sub
End Class