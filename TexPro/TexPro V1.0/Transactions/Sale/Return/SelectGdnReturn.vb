
Imports BL
Imports System.Windows.Forms

Public Class SelectGdnReturn

    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public Cmpname As String = ""
    Public DT1 As New DataTable

    Private Sub SelectGdnReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Top = 100
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGdnReturn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable = objclspreq.search(" GDN.GDN_no AS GDNNO, GDN.GDN_DATE AS DATE, GDN_PSDESC.GDN_SRNO AS SRNO, PARTYNAME.Acc_cmpname AS [Party Name], GDN_PSDESC.GDN_PSNO AS [Bale No], ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS [Piece Type], ISNULL(ITEMMASTER.item_name, '') AS [Merchant Name], GDN_PSDESC.GDN_CUT AS [Cut], GDN_PSDESC.GDN_PCS AS Pcs, GDN_PSDESC.GDN_WT AS Wt, GDN_PSDESC.GDN_MTRS AS Mtrs ", "", " GDN INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id AND GDN.GDN_CMPID = LEDGERS.Acc_cmpid AND GDN.GDN_LOCATIONID = LEDGERS.Acc_locationid AND GDN.GDN_YEARID = LEDGERS.Acc_yearid INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_CMPID = GDN_PSDESC.GDN_CMPID AND GDN.GDN_LOCATIONID = GDN_PSDESC.GDN_LOCATIONID AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID LEFT OUTER JOIN LEDGERS AS PARTYNAME ON GDN_PSDESC.GDN_PARTYID = PARTYNAME.Acc_id AND GDN_PSDESC.GDN_CMPID = PARTYNAME.Acc_cmpid AND GDN_PSDESC.GDN_LOCATIONID = PARTYNAME.Acc_locationid AND GDN_PSDESC.GDN_YEARID = PARTYNAME.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON GDN.GDN_transid = LEDGERS_2.Acc_id AND GDN.GDN_CMPID = LEDGERS_2.Acc_cmpid AND GDN.GDN_LOCATIONID = LEDGERS_2.Acc_locationid AND GDN.GDN_YEARID = LEDGERS_2.Acc_yearid LEFT OUTER JOIN QUALITYMASTER ON GDN_PSDESC.GDN_QUALITYID = QUALITYMASTER.QUALITY_id AND GDN_PSDESC.GDN_CMPID = QUALITYMASTER.QUALITY_cmpid AND GDN_PSDESC.GDN_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND GDN_PSDESC.GDN_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON GDN_PSDESC.GDN_MERCHANTID = ITEMMASTER.item_id AND GDN_PSDESC.GDN_CMPID = ITEMMASTER.item_cmpid AND GDN_PSDESC.GDN_LOCATIONID = ITEMMASTER.item_locationid AND GDN_PSDESC.GDN_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PIECETYPEMASTER ON GDN_PSDESC.GDN_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND GDN_PSDESC.GDN_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND GDN_PSDESC.GDN_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND GDN_PSDESC.GDN_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON GDN.GDN_AGENTID = LEDGERS_1.Acc_id AND GDN.GDN_CMPID = LEDGERS_1.Acc_cmpid AND GDN.GDN_LOCATIONID = LEDGERS_1.Acc_locationid AND GDN.GDN_YEARID = LEDGERS_1.Acc_yearid LEFT OUTER JOIN ADDRESSMASTER ON GDN.GDN_CONSIGNEEID = ADDRESSMASTER.ADDRESS_ID AND GDN.GDN_CMPID = ADDRESSMASTER.ADDRESS_cmpid AND GDN.GDN_LOCATIONID = ADDRESSMASTER.ADDRESS_locationid AND GDN.GDN_YEARID = ADDRESSMASTER.ADDRESS_yearid ", where & "  and PARTYNAME.Acc_cmpname ='" & Cmpname & "'AND GDN.GDN_CMPID = " & CmpId & " AND GDN.GDN_LOCATIONID = " & Locationid & " AND GDN.GDN_YEARID = " & YearId)

            If DT.Rows.Count > 0 Then
                gridwo.DataSource = DT
                If ADDCOL = False Then
                    gridwo.Columns.Insert(0, col)
                    ADDCOL = True
                End If

                gridwo.Columns(0).Width = 40 'CHECKNO
                gridwo.Columns(1).Visible = False 'GDNNO
                gridwo.Columns(2).Width = 80    'DATE
                gridwo.Columns(3).Visible = False 'GDNSRNO
                gridwo.Columns(4).Width = 200 'PARTY NAME
                gridwo.Columns(5).Width = 100 'BALENO
                gridwo.Columns(6).Width = 120 'PIECE TYPE
                gridwo.Columns(7).Width = 230 'MERCHANT
                gridwo.Columns(8).Width = 50 'CUT
                gridwo.Columns(9).Width = 80 'PCS
                gridwo.Columns(10).Width = 50 'WT
                gridwo.Columns(11).Width = 80 'MTRS

                gridwo.Columns(8).DefaultCellStyle.Format = "N2"
                gridwo.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridwo.Columns(9).DefaultCellStyle.Format = "N2"
                gridwo.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridwo.Columns(10).DefaultCellStyle.Format = "N2"
                gridwo.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridwo.Columns(11).DefaultCellStyle.Format = "N2"
                gridwo.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                gridwo.FirstDisplayedScrollingRowIndex = gridwo.RowCount - 1

            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtsearch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            If txtsearch.Text <> "" Then
                If cmbselect.Text = "GDN No." Then
                    fillgrid(" and GDN_PSDESC.GDN_psno =" & Val(txtsearch.Text))
                ElseIf cmbselect.Text = "Bale No." Then
                    fillgrid(" and GDN_PSDESC.GDN_PSNO = " & Val(txtsearch.Text))
                End If
            End If
        End If
    End Sub

    Private Sub gridwo_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridwo.CellClick
        Try
            Dim N As String = ""
            Dim tempindex As Integer
            Dim i As Integer

            If e.RowIndex >= 0 Then
                With gridwo.Rows(e.RowIndex).Cells(0)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True
                        tempindex = e.RowIndex
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            DT1.Columns.Add("GDNNO")
            DT1.Columns.Add("GDNDATE")
            DT1.Columns.Add("GDNGRIDSRNO")
            DT1.Columns.Add("NAME")
            DT1.Columns.Add("BALENO")
            DT1.Columns.Add("PIECETYPE")
            DT1.Columns.Add("MERCHANT")
            DT1.Columns.Add("CUT")
            DT1.Columns.Add("PCS")
            DT1.Columns.Add("WT")
            DT1.Columns.Add("MTRS")

            For Each ROW As DataGridViewRow In gridwo.Rows
                If Convert.ToBoolean(ROW.Cells(0).Value) = True Then
                    DT1.Rows.Add(ROW.Cells(1).Value, ROW.Cells(2).Value, ROW.Cells(3).Value, ROW.Cells(4).Value, ROW.Cells(5).Value, ROW.Cells(6).Value, ROW.Cells(7).Value, ROW.Cells(8).Value, ROW.Cells(9).Value, ROW.Cells(10).Value, ROW.Cells(11).Value)
                End If
            Next

            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            If chkall.Checked = True Then
                For i As Integer = 0 To gridwo.RowCount - 1
                    With gridwo.Rows(i).Cells(0)

                        .Value = True
                    End With
                Next
            Else
                For i As Integer = 0 To gridwo.RowCount - 1

                    With gridwo.Rows(i).Cells(0)
                        .Value = False
                    End With

                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TXTTO_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTO.Validated
        Try
            If cmbselect.Text.Trim <> "" And txtsearch.Text <> "" Then
                If cmbselect.Text = "Bale No." Then
                    If Val(TXTTO.Text) > 0 Then
                        Dim STR As String = " AND GDN_PSDESC.GDN_PSNO>=" & Val(txtsearch.Text)
                        If Val(TXTTO.Text.Trim) > 0 Then STR = STR & " AND GDN_PSDESC.GDN_PSNO<=" & Val(TXTTO.Text)
                        fillgrid(STR)
                    Else
                        fillgrid(" AND GDN_PSDESC.GDN_PSNO=" & Val(txtsearch.Text))
                    End If

                Else
                    '  fillgrid("")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class