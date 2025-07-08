
Imports BL
Imports System.Windows.Forms

Public Class DesignRecipeDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub DesignRecipeDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
            Call cmdadd_Click(sender, e)
        End If
    End Sub

    Private Sub DesignRecipeDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DESIGN MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridname()
        Try
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search(" DISTINCT DESIGN_NO AS DESIGNNO,ISNULL(ITEMMASTER.ITEM_NAME,'') AS MERCHANT,DESIGN_ID AS DESIGNID, DESIGN_IMGPATH AS IMGPATH", "", " DESIGNRECIPE LEFT OUTER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id ", " AND DESIGN_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then gridname.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMATCHING(ByVal DESIGNID As String, Optional ByVal IMGPATH As String = "")
        Try
            If DESIGNID <> Nothing Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" DESIGNRECIPE_DESC.DESIGN_SRNO AS GRIDSRNO, COLORMASTER.COLOR_name AS MATCHING, SCREENMASTER.SCREEN_name AS SCREEN, DESIGNRECIPE_DESC.DESIGN_SHADE AS SHADE, DESIGNRECIPE.DESIGN_LOGO AS IMGPATH, ISNULL(DESIGNRECIPE.DESIGN_REMARKS,'') AS REMARKS ", "", " DESIGNRECIPE_DESC INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID LEFT OUTER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id LEFT OUTER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id ", " AND DESIGNRECIPE.DESIGN_ID= " & DESIGNID & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " ORDER BY SCREENMASTER.SCREEN_name")
                If dttable.Rows.Count > 0 Then
                    If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                        pbimage.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                        txtimgpath.Text = dttable.Rows(0).Item("IMGPATH").ToString
                    Else
                        pbimage.Image = Nothing
                    End If
                    gridmatching.DataSource = dttable
                    txtremarks.Text = dttable.Rows(0).Item("REMARKS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETRECIPE(ByVal DESIGNNO As String, ByVal MATCHING As String, ByVal GRIDSRNO As Integer)
        Try
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, DESIGNRECIPE_CONSUMPTION.DESIGN_PART AS QTY, DESIGNRECIPE_CONSUMPTION.DESIGN_RATE AS RATE, DESIGNRECIPE_CONSUMPTION.DESIGN_COST AS COST ", "", "   DESIGNRECIPE_CONSUMPTION INNER JOIN COLORMASTER ON DESIGNRECIPE_CONSUMPTION.DESIGN_COLORID = COLORMASTER.COLOR_id INNER JOIN ITEMMASTER ON DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = ITEMMASTER.item_id ", " AND DESIGNRECIPE_CONSUMPTION.DESIGN_id = '" & DESIGNNO & "'  AND DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO = " & GRIDSRNO & " AND COLORMASTER.COLOR_NAME = '" & MATCHING & "' AND DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then gridrecipe.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DESIGNNO"), matchingview.GetFocusedRowCellValue("MATCHING"), gridledger.GetFocusedRowCellValue("MERCHANT"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal DESIGNNO As String, ByVal MATCHING As String, ByVal MERCHANT As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (gridledger.RowCount > 0 And editval = True) Then
                Dim objDESIGN As New DesignRecipe
                objDESIGN.MdiParent = MDIMain
                objDESIGN.edit = editval
                objDESIGN.TEMPDESIGNNO = DESIGNNO
                objDESIGN.TEMPMERCHANT = MERCHANT
                objDESIGN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "", "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("DESIGNID"), gridledger.GetFocusedRowCellValue("IMGPATH"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATCHINGVIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles matchingview.Click
        Try
            GETRECIPE(gridledger.GetFocusedRowCellValue("DESIGNid"), matchingview.GetFocusedRowCellValue("MATCHING"), matchingview.GetFocusedRowCellValue("GRIDSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATCHINGVIEW_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles matchingview.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DESIGNNO"), matchingview.GetFocusedRowCellValue("MATCHING"), gridledger.GetFocusedRowCellValue("MERCHANT"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DESIGNNO"), matchingview.GetFocusedRowCellValue("MATCHING"), gridledger.GetFocusedRowCellValue("MERCHANT"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("DESIGNID"), gridledger.GetFocusedRowCellValue("IMGPATH"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub matchingview_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles matchingview.FocusedRowChanged
        Try
            GETRECIPE(gridledger.GetFocusedRowCellValue("DESIGNID"), matchingview.GetFocusedRowCellValue("MATCHING"), matchingview.GetFocusedRowCellValue("GRIDSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridname.Click
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("DESIGNID"), gridledger.GetFocusedRowCellValue("IMGPATH"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class