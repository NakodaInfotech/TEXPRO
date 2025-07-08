
Imports BL
Imports System.Windows.Forms

Public Class SelectPR

    Public frmstring As String
    Dim addcol As Boolean = False   'for adding col in grid
    Dim col As New DataGridViewCheckBoxColumn
    Public PRNO As Integer = 0  'for whereclause in fillgrid

    Private Sub SelectPR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Top = 100
        fillgrid()
    End Sub

    Sub fillgrid()
        Try

            Cursor.Current = Cursors.WaitCursor

            Dim where As String = "  and PURCHASEREQUEST.preq_cmpid=" & CmpId & " and  PURCHASEREQUEST.preq_locationid=" & Locationid & " and  PURCHASEREQUEST.preq_yearid=" & YearId
            If PRNO <> 0 Then where = " and PURCHASEREQUEST.PREQ_NO = " & PRNO
            Dim objpurreq As New ClsCommon()
            Dim dttable As DataTable = objpurreq.search("PURCHASEREQUEST.PREQ_NO AS [Sr No.], PURCHASEREQUEST.PREQ_DATE AS Date, PURCHASEREQUEST.PREQ_VALIDTILLDATE AS [Valid Till], isnull(PURCHASEREQUEST.PREQ_REQBY,'') AS [Request By], isnull(DEPARTMENTMASTER.DEPARTMENT_name,'') AS Department, PURCHASEREQUEST_DESC.PREQ_GRIDSRNO AS GRIDSRNO, isnull(ITEMMASTER.item_name,'') AS [Item Name], isnull(PURCHASEREQUEST_DESC.PREQ_GRIDREMARKS,'') AS [Description], isnull(QUALITYMASTER.QUALITY_name,'') AS Quality, isnull(PURCHASEREQUEST_DESC.PREQ_REED,'') AS Reed, isnull(PURCHASEREQUEST_DESC.PREQ_PICK,'') AS Pick, isnull(COLORMASTER.COLOR_name,'') AS Color, (PURCHASEREQUEST_DESC.PREQ_QTY - PURCHASEREQUEST_DESC.PREQ_RECDQTY) AS Qty, isnull(UNITMASTER.unit_abbr,'') AS [Qty Unit]", "", " PURCHASEREQUEST INNER JOIN PURCHASEREQUEST_DESC ON PURCHASEREQUEST.PREQ_NO = PURCHASEREQUEST_DESC.PREQ_NO AND PURCHASEREQUEST.PREQ_CMPID = PURCHASEREQUEST_DESC.PREQ_CMPID AND PURCHASEREQUEST.PREQ_LOCATIONID = PURCHASEREQUEST_DESC.PREQ_LOCATIONID AND PURCHASEREQUEST.PREQ_YEARID = PURCHASEREQUEST_DESC.PREQ_YEARID LEFT OUTER JOIN UNITMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = UNITMASTER.unit_yearid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = UNITMASTER.unit_locationid AND PURCHASEREQUEST_DESC.PREQ_CMPID = UNITMASTER.unit_cmpid AND PURCHASEREQUEST_DESC.PREQ_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN COLORMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = COLORMASTER.COLOR_yearid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = COLORMASTER.COLOR_locationid AND PURCHASEREQUEST_DESC.PREQ_CMPID = COLORMASTER.COLOR_cmpid AND PURCHASEREQUEST_DESC.PREQ_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = QUALITYMASTER.QUALITY_yearid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PURCHASEREQUEST_DESC.PREQ_CMPID = QUALITYMASTER.QUALITY_cmpid AND PURCHASEREQUEST_DESC.PREQ_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON PURCHASEREQUEST_DESC.PREQ_ITEMID = ITEMMASTER.item_id AND PURCHASEREQUEST_DESC.PREQ_CMPID = ITEMMASTER.item_cmpid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = ITEMMASTER.item_locationid AND PURCHASEREQUEST_DESC.PREQ_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN DEPARTMENTMASTER ON PURCHASEREQUEST.PREQ_YEARID = DEPARTMENTMASTER.DEPARTMENT_yearid AND PURCHASEREQUEST.PREQ_LOCATIONID = DEPARTMENTMASTER.DEPARTMENT_locationid AND PURCHASEREQUEST.PREQ_CMPID = DEPARTMENTMASTER.DEPARTMENT_cmpid AND PURCHASEREQUEST.PREQ_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id ", " AND PURCHASEREQUEST_DESC.PREQ_DONE= 'False' " & where & " order by dbo.PURCHASEREQUEST.PREQ_NO")

            If dttable.Rows.Count > 0 Then

                gridprequisition.DataSource = dttable

                'Dim col As New DataGridViewCheckBoxColumn
                If addcol = False Then
                    gridprequisition.Columns.Insert(0, col)
                    addcol = True
                End If

                gridprequisition.Columns(0).Width = 50  'Check Box
                gridprequisition.Columns(1).Width = 70  'Sr
                gridprequisition.Columns(2).Width = 80  'Date
                gridprequisition.Columns(3).Width = 90  'valid till
                gridprequisition.Columns(4).Width = 150 'Req By
                gridprequisition.Columns(5).Width = 100  'Deaprtment
                gridprequisition.Columns(6).Width = 10  'gridsrno
                gridprequisition.Columns(7).Width = 150 'Item Name
                gridprequisition.Columns(8).Width = 150  'desc
                gridprequisition.Columns(9).Width = 80  'Quality
                gridprequisition.Columns(10).Width = 60  'Reed
                gridprequisition.Columns(11).Width = 60 'Pick
                gridprequisition.Columns(12).Width = 80 'Color
                gridprequisition.Columns(13).Width = 80 'qty
                gridprequisition.Columns(14).Width = 90 'qtyunit

                gridprequisition.Columns(6).Visible = False 'Grid Sr No

                gridprequisition.Columns(13).DefaultCellStyle.Format = "N2"
                gridprequisition.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                gridprequisition.FirstDisplayedScrollingRowIndex = gridprequisition.RowCount - 1

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub gridprequisition_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridprequisition.CellClick

        Dim N As String = ""
        Dim tempindex As Integer

        'ALLOW MULTIPLE PR
        'CHECKING SIMILAR LOCATION
        'For i = 0 To gridprequisition.RowCount - 1
        '    With gridprequisition.Rows(i).Cells(0)
        '        If .Value = True Then N = gridprequisition.Item(0, i).Value.ToString
        '    End With
        'Next

        If e.RowIndex >= 0 Then
            With gridprequisition.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    If (gridprequisition.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
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
            dt.Columns.Add("PRNO")
            dt.Columns.Add("PRDATE")
            dt.Columns.Add("GRIDSRNO")
            dt.Columns.Add("ITEMNAME")
            dt.Columns.Add("DESC")
            dt.Columns.Add("QUALITY")
            dt.Columns.Add("REED")
            dt.Columns.Add("PICK")
            dt.Columns.Add("COLOR")
            dt.Columns.Add("qty")
            dt.Columns.Add("qtyunit")

            For Each row As DataGridViewRow In gridprequisition.Rows
                If row.Cells(0).Value = True Then
                    dt.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value)
                End If
            Next
            PurchaseQuotation.selectPRtable = dt
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectPR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtsearch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            Dim rowno, b As Integer
            fillgrid()
            rowno = 0
            For b = 1 To gridprequisition.RowCount
                If cmbselect.Text = "Sr No." Then
                    txttempname.Text = gridprequisition.Item(1, rowno).Value.ToString()
                ElseIf cmbselect.Text = "Request By" Then
                    txttempname.Text = gridprequisition.Item(4, rowno).Value.ToString()
                ElseIf cmbselect.Text = "Item Name" Then
                    txttempname.Text = gridprequisition.Item(7, rowno).Value.ToString()
                End If
                txttempname.SelectionStart = 0
                txttempname.SelectionLength = txtsearch.TextLength
                If LCase(txtsearch.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                    gridprequisition.Rows.RemoveAt(rowno)
                Else
                    rowno = rowno + 1
                End If
            Next
        End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Dim i As Integer
            If chkall.Checked = True Then
                For i = 0 To gridprequisition.RowCount - 1
                    If gridprequisition.CurrentRow.Index >= 0 Then
                        With gridprequisition.Rows(i).Cells(0)
                            .Value = True
                        End With
                    End If
                Next
            Else
                For i = 0 To gridprequisition.RowCount - 1
                    If gridprequisition.CurrentRow.Index >= 0 Then
                        With gridprequisition.Rows(i).Cells(0)
                            .Value = False
                        End With
                    End If
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class