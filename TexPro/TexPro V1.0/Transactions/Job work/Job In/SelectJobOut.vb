
Imports BL
Imports System.Windows.Forms

Public Class SelectJobOut

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
        fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal WHERE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable = objclspreq.search("  [JO NO] AS [Jo. No.], DATE as Date, NAME as Name, ROUND(SUM(MTRS),2) AS Mtrs, SUM(TOTAL) AS Pcs", "", "  JOBOUT_VIEW2 ", " AND YEARID = " & YearId & WHERE & " GROUP BY [JO NO], DATE, NAME")
            gridmfg.DataSource = DT
            If DT.Rows.Count > 0 Then
                If ADDCOL = False Then
                    gridmfg.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                gridmfg.Columns(0).Width = 40 'CHECK BOK
                gridmfg.Columns(1).Width = 80 'JO NO
                gridmfg.Columns(2).Width = 100 'DATE
                gridmfg.Columns(3).Width = 300 'NAME
                gridmfg.Columns(4).Width = 100 'MTRS
                gridmfg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridmfg.Columns(5).Width = 60 'PCS
                gridmfg.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
                If cmbselect.Text = "Job No." Then
                    fillgrid(" and [JO NO] in (" & txtsearch.Text & ")")
                ElseIf cmbselect.Text = "Lot No." Then
                    fillgrid(" and LOTNO in (" & txtsearch.Text & ")")
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
            Dim JOB As String = ""
            For Each ROW As DataGridViewRow In gridmfg.Rows
                If Convert.ToBoolean(ROW.Cells(0).Value) = True Then
                    If JOB = "" Then
                        JOB = ROW.Cells(1).Value
                    Else
                        JOB = JOB & "," & ROW.Cells(1).Value
                    End If
                End If
            Next
            If JOB <> "" Then
                JOB = " AND [JO NO] IN (" & JOB & ")"
            End If
            Dim objclspreq As New ClsCommon()
            Dim DT As New DataTable
            DT = objclspreq.search(" [JO NO] as JONO, JO_GRIDSRno AS JOGRIDSRNO, JOBNO, NAME,[BALE NO] AS BALENO, PSGRIDSRNO, [PIECE TYPE] AS PIECETYPE, ITEM AS ITEMNAME, CUT, DESIGN, QUALITY, COLOR, TOTAL AS PCS, MTRS, PS_CHECKNO AS CHECKNO, PS_CHECKSRNO AS CHECKSRNO, PS_MFGNO AS MFGNO, PS_MFGSRNO MFGSRNO, PS_LOTNO AS LOTNO, PS_LOTSRNO AS LOTSRNO, PS_GRNTYPE AS GRNTYPE, CMPID, LOCATIONID, YEARID ", "", "  JOBOUT_VIEW2 ", " and CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & JOB & "")
            JobIn.selectjitable = DT
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


End Class