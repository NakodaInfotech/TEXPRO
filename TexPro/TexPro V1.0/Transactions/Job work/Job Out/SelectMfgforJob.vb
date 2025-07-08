Imports BL
Imports System.Windows.Forms

Public Class SelectMfgforJob

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

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor


            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable = objclspreq.search(" * ", "", "  JOBBALE_VIEW ", " and YEARID = " & YearId & where & " AND BALENO NOT IN (SELECT JO_BALENO FROM JOBOUT_DESC WHERE JO_YEARID = " & YearId & ") order by  [BALENO]")

            If DT.Rows.Count > 0 Then

                gridmfg.DataSource = DT
                If ADDCOL = False Then
                    gridmfg.Columns.Insert(0, col)
                    ADDCOL = True
                End If

                gridmfg.Columns(0).Width = 40 'CHECK BOK

                gridmfg.Columns(2).Width = 40 'SRNO




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
          
            If cmbselect.Text = "Bale No." Then
                fillgrid(" and baleno=" & Val(txtsearch.Text))
            ElseIf cmbselect.Text = "Quality" Then
                fillgrid(" and Quality='" & txtsearch.Text & "'")
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
    Private Sub TXTTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTO.Validated
        If cmbselect.Text.Trim <> "" And txtsearch.Text <> "" Then
            If cmbselect.Text = "Bale No." Then
                If Val(TXTTO.Text) > 0 Then
                    Dim STR As String = " AND [BALENO]>=" & Val(txtsearch.Text)
                    If Val(TXTTO.Text.Trim) > 0 Then STR = STR & " AND [BALENO]<=" & Val(TXTTO.Text)
                    fillgrid(STR)
                Else
                    fillgrid(" AND [BALENO]=" & Val(txtsearch.Text))
                End If
            ElseIf cmbselect.Text = "Merchant Name" Then
                fillgrid(" AND  MERCHANT LIKE '" & txtsearch.Text & "%'")
            End If
        Else
            fillgrid("")
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try


            Dim dt As New DataTable

            dt.Columns.Add("JOBNO")
            dt.Columns.Add("BALENO")
            dt.Columns.Add("PCS")
            dt.Columns.Add("MTRS")
            dt.Columns.Add("NAME")

           

            For Each row As DataGridViewRow In gridmfg.Rows
                If row.Cells(0).Value = True Then
                    dt.Rows.Add(row.Cells(4).Value, row.Cells(1).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(13).Value)
                End If
            Next
            JobOut.selectjotable = dt
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    'Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
    '    Try
    '        Dim N As String = ""
    '        Dim M As String = ""
    '        Dim tempindex As Integer
    '        Dim i As Integer

    '        For i = 0 To gridmfg.RowCount - 1
    '            With gridmfg.Rows(i).Cells(0)
    '                If .Value = True Then N = gridmfg.Item(1, i).Value.ToString
    '                If .Value = True Then M = gridmfg.Item(5, i).Value.ToString
    '            End With
    '        Next

    '        If chkall.Checked = True Then
    '            For i = 0 To gridmfg.RowCount - 1
    '                If gridmfg.CurrentRow.Index >= 0 Then
    '                    With gridmfg.Rows(i).Cells(0)

    '                        If ((gridmfg.Item(1, i).Value.ToString = N) Or N = Nothing) And ((gridmfg.Item(5, i).Value.ToString = M) Or M = Nothing) Then
    '                            .Value = True
    '                            N = gridmfg.Item(1, i).Value.ToString
    '                            M = gridmfg.Item(5, i).Value.ToString
    '                            tempindex = i
    '                        End If
    '                    End With
    '                End If
    '            Next
    '        Else
    '            For i = 0 To gridmfg.RowCount - 1
    '                If gridmfg.CurrentRow.Index >= 0 Then
    '                    With gridmfg.Rows(i).Cells(0)
    '                        .Value = False
    '                    End With
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub
End Class