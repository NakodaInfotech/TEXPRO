
Imports BL
Imports System.Windows.Forms

Public Class DyeingRecipeDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub DYEINGRecipeDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
            Call cmdadd_Click(sender, e)
        End If
    End Sub

    Private Sub DYEINGRecipeDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DYEING MASTER'")
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
            Dim dttable As DataTable = OBJCMN.search(" DISTINCT DYEING_NO AS DYEINGNO,DYEING_ID AS DYEINGID", "", " DYEINGRECIPE", " AND DYEING_CMPID = " & CmpId & " AND DYEING_LOCATIONID  = " & Locationid & " AND DYEING_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then gridname.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMATCHING(ByVal DYEINGID As String)
        Try
            Dim OBJCMN As New ClsCommon
            If DYEINGID <> "" Then
                Dim dttable As DataTable = OBJCMN.search(" DYEINGRECIPE_DESC.DYEING_SRNO AS GRIDSRNO, COLORMASTER.COLOR_name AS COLOR, DYEINGRECIPE.DYEING_LOGO AS IMGPATH, DYEINGRECIPE.DYEING_REMARKS AS REMARKS ", "", " DYEINGRECIPE_DESC INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID LEFT OUTER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id ", " AND DYEINGRECIPE.DYEING_ID = " & DYEINGID & " AND DYEINGRECIPE.DYEING_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtremarks.Text = dttable.Rows(0).Item("REMARKS")
                    If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                        pbimage.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                        txtimgpath.Text = dttable.Rows(0).Item("IMGPATH").ToString
                    Else
                        pbimage.Image = Nothing
                    End If
                    gridmatching.DataSource = dttable
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETRECIPE(ByVal DYEINGNO As String, ByVal MATCHING As String, ByVal GRIDSRNO As Integer)
        Try
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, DYEINGRECIPE_CONSUMPTION.DYEING_QTY AS QTY ", "", "   DYEINGRECIPE_CONSUMPTION INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid ", " AND DYEINGRECIPE_CONSUMPTION.DYEING_id = '" & DYEINGNO & "'  AND DYEINGRECIPE_CONSUMPTION.DYEING_SRNO = " & GRIDSRNO & " AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = " & CmpId & " AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID  = " & Locationid & " AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                gridrecipe.DataSource = dttable
                'pbimage.ImageLocation = dttable.Rows(0).Item("IMGPATH")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DYEINGNO"), matchingview.GetFocusedRowCellValue("MATCHING"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal DYEINGNO As String, ByVal MATCHING As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (gridledger.RowCount > 0 And editval = True) Then
                Dim objDYEING As New DyeingRecipe
                objDYEING.MdiParent = MDIMain
                objDYEING.edit = editval
                objDYEING.TEMPDYEINGNO = DYEINGNO
                'objDYEING.TEMPMATCHING = MATCHING
                objDYEING.Show()
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
            showform(False, "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("DYEINGID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATCHINGVIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles matchingview.Click
        Try
            GETRECIPE(gridledger.GetFocusedRowCellValue("DYEINGid"), matchingview.GetFocusedRowCellValue("MATCHING"), matchingview.GetFocusedRowCellValue("GRIDSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATCHINGVIEW_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles matchingview.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DYEINGNO"), matchingview.GetFocusedRowCellValue("MATCHING"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("DYEINGID"))
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
            GETRECIPE(gridledger.GetFocusedRowCellValue("DYEINGID"), matchingview.GetFocusedRowCellValue("MATCHING"), matchingview.GetFocusedRowCellValue("GRIDSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridname.Click
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("DYEINGID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(sender As Object, e As EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DYEINGNO"), matchingview.GetFocusedRowCellValue("MATCHING"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class