Imports BL
Public Class SwapLotno

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Cursor.Current = Cursors.WaitCursor

            Dim alParaval As New ArrayList
            Dim intresult As Integer

           
            alParaval.Add(txtlotno.Text)
            alParaval.Add(txtswaplotno.Text)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)


            Dim OBJMFG As New ClsCommon()
            OBJMFG.alParaval = alParaval
            IntResult = OBJMFG.swaplotno()
            MsgBox("Details Added")


            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SwapLotno_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If UserName <> "Admin" Then
                MsgBox("You Do have Enough Right")
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class