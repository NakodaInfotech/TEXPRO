
Imports BL
Imports System.Windows.Forms
Public Class SelectDeparment

    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn

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
            dt = objclspreq.search(" distinct  DEPARTMENTMASTER.DEPARTMENT_name AS DEPARTMENT, PROCESSMASTER.PROCESS_NAME AS PROCESS ", "", " DEPARTMENTPRICELIST INNER JOIN DEPARTMENTMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_ID = DEPARTMENTMASTER.DEPARTMENT_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = DEPARTMENTMASTER.DEPARTMENT_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = DEPARTMENTMASTER.DEPARTMENT_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN PROCESSMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_PROCESSID = PROCESSMASTER.PROCESS_ID AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = PROCESSMASTER.PROCESS_CMPID AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = PROCESSMASTER.PROCESS_YEARID ", " and DEPARTMENTPRICELIST.DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENTPRICELIST.DEPARTMENT_locationid = " & Locationid & " and DEPARTMENTPRICELIST.DEPARTMENT_yearid = " & YearId)
            'dt = objclspreq.search("   DISTINCT  DYEINGRECIPE.DYEING_NO AS DYEINGNO, COLORMASTER.COLOR_name AS MATCHING ,DYEINGRECIPE.DYEING_ID AS DYEINGID ", "", "   DYEINGRECIPE_DESC INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID LEFT OUTER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid ", "  AND DYEINGRECIPE.DYEING_CMPID = " & CmpId & " AND DYEINGRECIPE.DYEING_LOCATIONID  = " & Locationid & " AND DYEINGRECIPE.DYEING_YEARID = " & YearId & where & " ORDER BY DYEINGNO")
            If dt.Rows.Count > 0 Then

                gridDepartment.DataSource = dt
                'Dim col As New DataGridViewCheckBoxColumn
                If ADDCOL = False Then
                    gridDepartment.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                gridDepartment.Columns(0).Width = 50 'CHECK BOK
                gridDepartment.Columns(1).Width = 100 'CHECK BOK
                gridDepartment.Columns(2).Width = 100 'CHECK BOK
                'gridDepartment.Columns(3).Visible = False


                gridDepartment.FirstDisplayedScrollingRowIndex = gridDepartment.RowCount - 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            If cmbselect.Text = "Department" Then
                fillgrid(" AND Department_name LIKE '" & txtsearch.Text & "%'")
            ElseIf cmbselect.Text = "Process" Then
                fillgrid(" AND Process_NAME LIKE '" & txtsearch.Text & "%'")
            End If
        End If
    End Sub

    Private Sub gridquotation_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDepartment.CellClick
        Dim N As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        'CHECKING SIMILAR LOCATION
        For i = 0 To gridDepartment.RowCount - 1
            With gridDepartment.Rows(i).Cells(0)
                If .Value = True Then N = gridDepartment.Item(1, i).Value.ToString
            End With
        Next

        If e.RowIndex >= 0 Then
            With gridDepartment.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    'If (gridDYEING.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
                    .Value = True
                    tempindex = e.RowIndex
                    'End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim DT As New DataTable
        DT.Columns.Add("MERCHANT")
        DT.Columns.Add("RATE")

        For Each ROW As DataGridViewRow In gridDepartment.Rows
            If ROW.Cells(0).Value = True Then
                Dim objclspreq As New ClsCommon()
                Dim DT1 As New DataTable
                DT1 = objclspreq.search(" ITEMMASTER.item_name, DEPARTMENTPRICELIST.DEPARTMENT_RATE ", "", "    DEPARTMENTPRICELIST INNER JOIN DEPARTMENTMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_ID = DEPARTMENTMASTER.DEPARTMENT_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = DEPARTMENTMASTER.DEPARTMENT_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = DEPARTMENTMASTER.DEPARTMENT_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN PROCESSMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_PROCESSID = PROCESSMASTER.PROCESS_ID AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = PROCESSMASTER.PROCESS_CMPID AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON DEPARTMENTPRICELIST.DEPARTMENT_MERCHANTID = ITEMMASTER.item_id AND DEPARTMENTPRICELIST.DEPARTMENT_CMPID = ITEMMASTER.item_cmpid AND DEPARTMENTPRICELIST.DEPARTMENT_LOCATIONID = ITEMMASTER.item_locationid AND DEPARTMENTPRICELIST.DEPARTMENT_YEARID = ITEMMASTER.item_yearid ", " and dbo.departmentmaster.department_name = '" & ROW.Cells(1).Value & "' and dbo.processmaster.process_name = '" & ROW.Cells(2).Value & "' and DEPARTMENTPRICELIST.DEPARTMENT_cmpID=" & CmpId & " and DEPARTMENTPRICELIST.DEPARTMENT_locationID = " & Locationid & " and DEPARTMENTPRICELIST.DEPARTMENT_YEARID = " & YearId & " ORDER BY  ITEMMASTER.item_name")
                For I As Integer = 0 To DT1.Rows.Count - 1
                    DT.Rows.Add(DT1.Rows(I).Item(0), DT1.Rows(I).Item(1))

                Next
            End If
        Next
        DepartmentRateList.dt_SELECT = DT
        Me.Close()
    End Sub

    Private Sub gridquotation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDepartment.CellDoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class