
Imports BL

Public Class SelectDyeing


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim objclspreq As New ClsCommon()
            Dim dt As DataTable = objclspreq.search(" DISTINCT DYEINGRECIPE.DYEING_NO AS CHARTNAME, COLORMASTER.COLOR_name AS MATCHING, DYEINGRECIPE.DYEING_ID AS DYEINGID ", "", "   DYEINGRECIPE_DESC INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID LEFT OUTER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid ", "  AND DYEINGRECIPE.DYEING_CMPID = " & CmpId & " AND DYEINGRECIPE.DYEING_LOCATIONID  = " & Locationid & " AND DYEINGRECIPE.DYEING_YEARID = " & YearId & where)
            gridname.DataSource = dt

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim DT As New DataTable
        DT.Columns.Add("GRIDSRNO")
        DT.Columns.Add("DYEINGNO")
        DT.Columns.Add("MATCHING")
        DT.Columns.Add("PERPCS")
        DT.Columns.Add("TOTALCOST")
        DT.Columns.Add("DYEINGID")
        DT.Columns.Add("GMS")

        Dim SELECTEDROWS As Int32() = gridledger.GetSelectedRows()
        For J As Integer = 0 To Val(SELECTEDROWS.Length - 1)
            Dim ROW As DataRow = gridledger.GetDataRow(SELECTEDROWS(J))
            Dim objclspreq As New ClsCommon()
            Dim DT1 As New DataTable
            DT1 = objclspreq.search(" DYEINGRECIPE_DESC.DYEING_SRNO AS GRIDSRNO, DYEINGRECIPE.DYEING_NO AS DYEINGNO, COLORMASTER.COLOR_name AS MATCHING,  DYEINGRECIPE_DESC.DYEING_PERPCS AS PERPCS,  DYEINGRECIPE_DESC.DYEING_TOTALCOST AS TOTALCOST, DYEINGRECIPE.DYEING_ID AS DYEINGID, ISNULL(DYEINGRECIPE.DYEING_GMS,0) AS GMS ", "", "    DYEINGRECIPE_DESC INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID LEFT OUTER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid  ", " AND COLOR_NAME='" & ROW("MATCHING") & "' AND DYEINGRECIPE.DYEING_NO='" & ROW("CHARTNAME") & "' AND DYEINGRECIPE.DYEING_YEARID = " & YearId)
            For I As Integer = 0 To DT1.Rows.Count - 1
                DT.Rows.Add(Val(DT1.Rows(I).Item("GRIDSRNO")), DT1.Rows(I).Item("DYEINGNO"), DT1.Rows(I).Item("MATCHING"), Val(DT1.Rows(I).Item("PERPCS")), Val(DT1.Rows(I).Item("TOTALCOST")), Val(DT1.Rows(I).Item("DYEINGID")), Val(DT1.Rows(I).Item("GMS")))
            Next
        Next
        DyeingRecipe.dt_SELECT = DT
        Me.Close()
    End Sub

End Class