
Imports BL
Imports System.Windows.Forms

Public Class SelectPs

    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public FRMSTR As String = ""
    Public PARTYNAME As String = ""
    Public baleno As String = ""

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
        cmbselect.Text = "Bale No"
        fillcheckboxlist()
        'fillgrid("")
    End Sub

    Sub fillcheckboxlist()
        Dim dt As DataTable
        Dim objclscomm As New ClsCommon()

        Dim WHERECLAUSE As String = ""
        If PARTYNAME <> "" Then WHERECLAUSE = " AND NAME = '" & PARTYNAME & "'"
        If FRMSTR = "PROFORMA" Then
            WHERECLAUSE = WHERECLAUSE & " AND BALENO NOT IN (SELECT INVOICE_PSNO FROM PROFORMAINVOICEMASTER_DESC WHERE INVOICE_PSNO <> '' AND INVOICE_YEARID = " & YearId & ")"
        ElseIf FRMSTR = "BALE" Then
            WHERECLAUSE = WHERECLAUSE & " AND (TYPE<>'PSJOB' AND  TYPE <> 'JOBBALE') AND DONE=0 AND BALENO NOT IN " & baleno
        ElseIf FRMSTR = "JOB" Then
            WHERECLAUSE = WHERECLAUSE & " AND (TYPE='PSJOB' OR TYPE='JOBBALE') AND DONE=0  AND BALENO NOT IN " & baleno
        End If

        'Fill BALENO
        dt = objclscomm.search(" BALENO ", "", " BALE_VIEW ", " AND Yearid=" & YearId & " AND BALENO <> '' " & WHERECLAUSE)
        If dt.Rows.Count > 0 Then
            Dim NEWDT As DataTable = dt.DefaultView.ToTable(True, "BALENO")
            NEWDT.DefaultView.Sort = "BALENO"
            For Each dr As DataRowView In NEWDT.DefaultView
                CLB_BALENO.Items.Add(Convert.ToString(dr("BALENO")), False)
            Next
        End If


        'Fill LOTNO
        dt = objclscomm.search(" DISTINCT LOTNO ", "", " BALE_VIEW ", " AND Yearid=" & YearId & " AND BALENO <> '' " & WHERECLAUSE)
        If dt.Rows.Count > 0 Then
            Dim NEWDT As DataTable = dt.DefaultView.ToTable(True, "LOTNO")
            NEWDT.DefaultView.Sort = "LOTNO"
            For Each dr As DataRowView In NEWDT.DefaultView
                CLB_LOTNO.Items.Add(Convert.ToString(dr("LOTNO")), False)
            Next
        End If


        ''Fill MERCHANT
        'dt = objclscomm.Execute_Any_String("SELECT DISTINCT MERCHANT FROM BALE_VIEW", " ", " WHERE BALE_VIEW.cmpid=" & CmpId & " and BALE_VIEW.Locationid=" & Locationid & " and Yearid=" & YearId & " AND MERCHANT <> ''" & WHERECLAUSE)
        'If dt.Rows.Count > 0 Then
        '    For Each dr As DataRow In dt.Rows
        '        CLB_ITEMNAME.Items.Add(Convert.ToString(dr(0)), False)
        '    Next
        'End If

    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If PARTYNAME <> "" Then WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & PARTYNAME & "'"

            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable
            If FRMSTR = "JOB" Then
                DT = objclspreq.search(" BALENO, FBNO, PIECETYPE, MERCHANT, CUT, QUALITY, ROUND(SUM(PCS), 0) AS PCS, ROUND(SUM(MTRS), 2) AS MTRS, ROUND(SUM(WT), 2) AS WT, NAME, TYPE ", "", " BALE_VIEW  ", WHERECLAUSE & "  AND (TYPE='PSJOB' OR TYPE='JOBBALE') AND DONE=0 AND YEARID = " & YearId & " and BALENO not in " & baleno & " GROUP BY BALENO, FBNO, PIECETYPE, MERCHANT, CUT, QUALITY, NAME, TYPE")
            ElseIf FRMSTR = "BALE" Then
                DT = objclspreq.search(" BALENO, FBNO, PIECETYPE, MERCHANT, CUT, QUALITY, ROUND(SUM(PCS), 0) AS PCS, ROUND(SUM(MTRS), 2) AS MTRS, ROUND(SUM(WT), 2) AS WT, NAME, TYPE ", "", " BALE_VIEW  ", WHERECLAUSE & "  AND (TYPE<>'PSJOB' AND TYPE <> 'JOBBALE')  AND DONE=0 AND YEARID = " & YearId & " and BALENO not in " & baleno & " GROUP BY BALENO, FBNO, PIECETYPE, MERCHANT, CUT, QUALITY, NAME, TYPE")
            ElseIf FRMSTR = "PROFORMA" Then
                DT = objclspreq.search(" BALENO, FBNO, PIECETYPE, MERCHANT, CUT, QUALITY, ROUND(SUM(PCS), 0) AS PCS, ROUND(SUM(MTRS), 2) AS MTRS, ROUND(SUM(WT), 2) AS WT, NAME, TYPE ", "", " BALE_VIEW  ", WHERECLAUSE & "  AND YEARID = " & YearId & " AND BALENO NOT IN (SELECT INVOICE_PSNO FROM PROFORMAINVOICEMASTER_DESC WHERE INVOICE_YEARID = " & YearId & ") GROUP BY BALENO, FBNO, PIECETYPE, MERCHANT, CUT, QUALITY, NAME, TYPE")
            End If

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSEARCH.Click
        Dim WHERECLAUSE As String = ""

        '***************search for BALENO ****************

        Dim CHECKED_BALENO As CheckedListBox.CheckedItemCollection = CLB_BALENO.CheckedItems
        Dim BALENO As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In CHECKED_BALENO
            If BALENO = "" Then
                BALENO = "'" & item.ToString() & "'"
            Else
                BALENO = BALENO & ",'" & item.ToString() & "'"
            End If
        Next item

        If BALENO <> "" Then WHERECLAUSE = WHERECLAUSE & " and BALENO IN (" & BALENO & ")"
        '*********end of current Block ********


        '***************search for LOTNO ****************
        Dim CHECKED_LOTNO As CheckedListBox.CheckedItemCollection = CLB_LOTNO.CheckedItems
        Dim LOTNO As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In CHECKED_LOTNO
            If LOTNO = "" Then
                LOTNO = "'" & item.ToString() & "'"
            Else
                LOTNO = LOTNO & ",'" & item.ToString() & "'"
            End If
        Next item

        If LOTNO <> "" Then WHERECLAUSE = WHERECLAUSE & " and LOTNO IN (" & LOTNO & ")"
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
            WHERECLAUSE = WHERECLAUSE & " and MERCHANT IN (" & MERCHANT & ")"
        End If
        '*********end of current Block ********

        fillgrid(WHERECLAUSE)
        chkall.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        fillgrid("")
        fillcheckboxlist()
    End Sub

    Private Sub gridWO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridwo.CellClick
        Dim N As String = ""
        Dim tempindex As Integer

        ''CHECKING SIMILAR LOCATION
        'For i = 0 To gridwo.RowCount - 1
        '    With gridwo.Rows(i).Cells(0)
        '        If .Value = True Then
        '            N = gridwo.Item(1, i).Value.ToString

        '        End If
        '    End With
        'Next

        If e.RowIndex >= 0 Then
            With gridwo.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    'If (gridwo.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
                    .Value = True
                    'WO = gridwo.Rows(e.RowIndex).Cells(1).Value
                    tempindex = e.RowIndex
                    'End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim objclspreq As New ClsCommon()
            Dim DT1 As New DataTable
            DT1.Columns.Add("BALENO")
            DT1.Columns.Add("FBNO")
            DT1.Columns.Add("PIECETYPE")
            DT1.Columns.Add("MERCHANT")
            DT1.Columns.Add("CUT")
            DT1.Columns.Add("QUALITY")
            DT1.Columns.Add("PCS")
            DT1.Columns.Add("MTRS")
            DT1.Columns.Add("WT")
            DT1.Columns.Add("NAME")
            DT1.Columns.Add("TYPE")
            For Each ROW As DataGridViewRow In gridwo.Rows
                If ROW.Cells(0).Value = True Then
                    DT1.Rows.Add(ROW.Cells(1).Value, ROW.Cells(2).Value, ROW.Cells(3).Value, ROW.Cells(4).Value, ROW.Cells(5).Value, ROW.Cells(6).Value, ROW.Cells(7).Value, ROW.Cells(8).Value, ROW.Cells(9).Value, ROW.Cells(10).Value, ROW.Cells(11).Value)
                End If
            Next
            If FRMSTR = "PROFORMA" Then
                ProformaInvoice.selectsotable = DT1

            Else
                GDN.selectpstable = DT1

            End If
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated

        Dim rowno, b As Integer
        Dim obj As New CheckedListBox
        rowno = 0

        If cmbselect.Text = "Bale No" Then
            obj = CLB_BALENO
        ElseIf cmbselect.Text = "Lot No" Then
            obj = CLB_LOTNO
        ElseIf cmbselect.Text = "Merchant Name" Then
            obj = CLB_ITEMNAME
        End If

        For b = 1 To obj.Items.Count

            txttempname.Text = obj.Items(rowno)
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = TXTFROM.TextLength
            If LCase(TXTFROM.Text.Trim) = LCase(txttempname.SelectedText.Trim) Then
                obj.SelectedIndex = rowno
                obj.Focus()
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Private Sub TXTTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTO.Validated
        If cmbselect.Text.Trim <> "" And TXTFROM.Text <> "" Then
            If cmbselect.Text = "Bale No" Then
                If Val(TXTTO.Text) > 0 Then
                    Dim STR As String = " AND [BALENO]>=" & Val(TXTFROM.Text)
                    If Val(TXTTO.Text.Trim) > 0 Then STR = STR & " AND [BALENO]<=" & Val(TXTTO.Text)
                    fillgrid(STR)
                Else
                    fillgrid(" AND [BALENO]=" & Val(TXTFROM.Text))
                End If
            ElseIf cmbselect.Text = "Merchant Name" Then
                fillgrid(" AND  MERCHANT LIKE '" & TXTFROM.Text & "%'")
            End If
        Else
            fillgrid("")
        End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Dim N As String = ""
            Dim M As String = ""

            Dim tempindex As Integer
            Dim i As Integer

            If gridwo.RowCount > 0 Then
                If chkall.Checked = True Then
                    For i = 0 To gridwo.RowCount - 1
                        With gridwo.Rows(i).Cells(0)
                            .Value = True
                             tempindex = i
                        End With
                    Next
                Else
                    For i = 0 To gridwo.RowCount - 1
                        With gridwo.Rows(i).Cells(0)
                            .Value = False
                        End With
                    Next
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class