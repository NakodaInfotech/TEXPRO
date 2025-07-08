
Imports BL
Imports System.Windows.Forms

Public Class selectdesign
   
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public TEMPNAME As String

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
            dt = objclspreq.search("   DISTINCT  DESIGNRECIPE.DESIGN_NO AS DESIGNNO,  ITEMMASTER.ITEM_NAME AS MERCHANT, COLORMASTER.COLOR_name AS MATCHING ,DESIGNRECIPE.DESIGN_ID AS DESIGNID ", "", "   DESIGNRECIPE_DESC INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = COLORMASTER.COLOR_yearid ", "  AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & where)
            If dt.Rows.Count > 0 Then

                griddesign.DataSource = dt
                'Dim col As New DataGridViewCheckBoxColumn
                If ADDCOL = False Then
                    griddesign.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                griddesign.Columns(0).Width = 50 'CHECK BOK
                griddesign.Columns(1).Width = 100 'CHECK BOK
                griddesign.Columns(2).Width = 100 'CHECK BOK
                griddesign.Columns(3).Width = 100 'CHECK BOK
                griddesign.Columns(4).Visible = False


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
            If cmbselect.Text = "DESIGN NO" Then
                fillgrid(" AND DESIGN_NO LIKE '" & txtsearch.Text & "%'")
            ElseIf cmbselect.Text = "MATCHING" Then
                fillgrid(" AND COLOR_NAME LIKE '" & txtsearch.Text & "%'")
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
        DT.Columns.Add("GRIDSRNO")
        DT.Columns.Add("DESIGNNO")
        DT.Columns.Add("MATCHING")
        DT.Columns.Add("SCREEN")
        DT.Columns.Add("SHADE")
        DT.Columns.Add("PERCENT")
        DT.Columns.Add("TOTALPART")
        DT.Columns.Add("TOTALCOST")
        DT.Columns.Add("DESIGNID")
        DT.Columns.Add("MERCHANT")
        For Each ROW As DataGridViewRow In griddesign.Rows
            If ROW.Cells(0).Value = True Then
                Dim objclspreq As New ClsCommon()
                Dim DT1 As New DataTable
                DT1 = objclspreq.search("   DESIGNRECIPE_DESC.DESIGN_SRNO AS GRIDSRNO, DESIGNRECIPE.DESIGN_NO AS DESIGNNO, COLORMASTER.COLOR_name AS MATCHING, SCREENMASTER.SCREEN_name AS SCREEN, DESIGNRECIPE_DESC.DESIGN_SHADE AS SHADE, DESIGNRECIPE_DESC.DESIGN_PERCENT, DESIGNRECIPE_DESC.DESIGN_TOTALPART, DESIGNRECIPE_DESC.DESIGN_TOTALCOST, DESIGNRECIPE.DESIGN_ID AS DESIGNID,ITEMMASTER.ITEM_NAME ", "", "    DESIGNRECIPE_DESC INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = SCREENMASTER.SCREEN_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = SCREENMASTER.SCREEN_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = SCREENMASTER.SCREEN_yearid", " AND COLOR_NAME='" & ROW.Cells(3).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & ROW.Cells(1).Value & "'  AND ITEMMASTER.ITEM_NAME='" & ROW.Cells(2).Value & "' AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " ORDER BY COLORMASTER.COLOR_name, SCREENMASTER.SCREEN_name")
                For I As Integer = 0 To DT1.Rows.Count - 1
                    DT.Rows.Add(DT1.Rows(I).Item(0), DT1.Rows(I).Item(1), DT1.Rows(I).Item(2), DT1.Rows(I).Item(3), DT1.Rows(I).Item(4), DT1.Rows(I).Item(5), DT1.Rows(I).Item(6), DT1.Rows(I).Item(7), DT1.Rows(I).Item(8), DT1.Rows(I).Item(9))

                Next
            End If
        Next
        DesignRecipe.dt_SELECT = DT
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