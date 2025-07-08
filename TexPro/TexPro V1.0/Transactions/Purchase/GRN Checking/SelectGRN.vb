
Imports BL

Public Class SelectGRN
    Public GRNNO As Integer = 0
    Dim tempindex, i As Integer
    Public GODOWN As String = ""
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectGRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim where As String = " AND (MATERIAL = 'Finished Goods' OR MATERIAL = 'Raw Material' OR MATERIAL = 'Semi Finished Goods')"
            Dim OBJCMN As New ClsCommon()
            Dim DT1 As DataTable = OBJCMN.search(" [Lot No.] ,[Qty],[Unit],[Mtrs],[Quality],[Date],[Name],[GRIDSRNO],[Item Name],[Description],[Reed],[Pick],[Color],[TYPE],[BROKER], GRNNO, RATE, WEAVER, SENDER, BALENOS, ISNULL(GODOWN,'') AS GODOWN, ISNULL(GREYWIDTH,'') AS Width, ISNULL(READYWIDTH,'') AS READYWIDTH ", "", "   GRN_VIEW ", " and CHECKDONE='A' AND ISNULL(GODOWN,'') = '" & GODOWN & "' AND YEARID = " & YearId & WHERECLAUSE & "  order by [Lot No.]")
            gridbilldetails.DataSource = DT1
            If DT1.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            dt.Columns.Add("LOTNO")
            dt.Columns.Add("qty")
            dt.Columns.Add("qtyunit")
            dt.Columns.Add("MTRS")
            dt.Columns.Add("QUALITY")
            dt.Columns.Add("GRNDATE")
            dt.Columns.Add("NAME")
            dt.Columns.Add("GRIDSRNO")
            dt.Columns.Add("ITEMNAME")
            dt.Columns.Add("DESC")
            dt.Columns.Add("REED")
            dt.Columns.Add("PICK")
            dt.Columns.Add("COLOR")
            dt.Columns.Add("TYPE")
            dt.Columns.Add("BROKER")
            dt.Columns.Add("GRNNO")
            dt.Columns.Add("RATE")
            dt.Columns.Add("WEAVER")
            dt.Columns.Add("SENDER")
            dt.Columns.Add("BALENOS")
            dt.Columns.Add("GREYWIDTH")
            dt.Columns.Add("READYWIDTH")


            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            If SELECTEDROWS.Length > 1 Then
                MsgBox("Select Only 1 Lot", MsgBoxStyle.Critical)
                Exit Sub
            End If
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                dt.Rows.Add(DTROW("Lot No."), Val(DTROW("Qty")), DTROW("Unit"), Val(DTROW("Mtrs")), DTROW("Quality"), DTROW("Date"), DTROW("Name"), Val(DTROW("GRIDSRNO")), DTROW("Item Name"), DTROW("Description"), DTROW("Reed"), DTROW("Pick"), DTROW("Color"), DTROW("TYPE"), DTROW("BROKER"), Val(DTROW("GRNNO")), Val(DTROW("RATE")), DTROW("WEAVER"), DTROW("SENDER"), DTROW("BALENOS"), DTROW("Width"), DTROW("READYWIDTH"))
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class