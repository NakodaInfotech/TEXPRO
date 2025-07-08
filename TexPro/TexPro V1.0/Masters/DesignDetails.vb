
Imports BL
Imports System.Windows.Forms

Public Class DesignDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub DesignDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
            Call cmdadd_Click(sender, e)
        End If
    End Sub

    Private Sub DesignDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim dttable As DataTable = OBJCMN.search(" DESIGN_NAME AS DESIGNNO, DESIGN_ID AS DESIGNID, DESIGN_IMGPATH AS IMGPATH", "", " DESIGNMASTER ", " AND DESIGN_CMPID = " & CmpId & " AND DESIGN_LOCATIONID  = " & Locationid & " AND DESIGN_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then gridname.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DESIGNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal DESIGNNO As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (gridledger.RowCount > 0 And editval = True) Then
                Dim objDESIGN As New DesignMaster
                objDESIGN.MdiParent = MDIMain
                objDESIGN.edit = editval
                objDESIGN.TEMPDESIGNNO = DESIGNNO
                objDESIGN.Show()
                Me.Close()
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
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("DESIGNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("IMGPATH"))
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

    Private Sub gridname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridname.Click
        Try
            GETMATCHING(gridledger.GetFocusedRowCellValue("IMGPATH"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMATCHING(Optional ByVal IMGPATH As String = "")
        Try
            pbimage.ImageLocation = IMGPATH
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If pbimage.ImageLocation <> "" Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.ImageLocation = pbimage.ImageLocation
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class