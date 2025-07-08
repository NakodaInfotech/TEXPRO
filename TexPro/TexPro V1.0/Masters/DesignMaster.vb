
Imports BL
Imports System.IO

Public Class DesignMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPDESIGNNO As String        'Used for TEMPDESIGNNO while edit mode
    Public TEMPDESIGNID As Integer         'Used for TEMPDESIGNNO while edit mode
    Public edit As Boolean           'Used for edit
    Dim OLDIMGPATH As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(TEMPDESIGNNO) <> LCase(txtname.Text.Trim)) Then
                dt = objclscommon.search("DESIGN_NAME AS DESIGN", "", " DESIGNMASTER ", " and DESIGN_NAME = '" & txtname.Text.Trim & "' and DESIGN_cmpid =" & CmpId & " and DESIGN_Locationid =" & Locationid & " and DESIGN_Yearid =" & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Design Name Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                    e.Cancel = True
                End If
            End If
            pcase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTOURLOCATION.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJDESIGN As New ClsDesignMaster
            OBJDESIGN.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJDESIGN.save()
                MsgBox("Details Added")
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPDESIGNID)
                IntResult = OBJDESIGN.Update()
                MsgBox("Details Updated")
                edit = False

            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Name")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub DesignMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If edit = True Then
                dttable = objCommon.search(" DESIGN_name AS DESIGN, DESIGN_REMARKS AS REMARKS, DESIGN_IMGPATH AS IMGPATH", "", "DESIGNMaster", " and DESIGN_NAME = '" & TEMPDESIGNNO & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_locationid = " & Locationid & " and DESIGN_yearid = " & YearId)
            Else
                txtname.Text = TEMPDESIGNNO
            End If
            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item("DESIGN").ToString
                txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString
                pbimage.ImageLocation = dttable.Rows(0).Item("IMGPATH")
                txtimgpath.Text = dttable.Rows(0).Item("IMGPATH")
                TXTOURLOCATION.Text = dttable.Rows(0).Item("IMGPATH")
                OLDIMGPATH = dttable.Rows(0).Item("IMGPATH")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg)|*.bmp;*.jpg"
        OpenFileDialog1.ShowDialog()

        txtimgpath.Text = OpenFileDialog1.FileName
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName

        TXTOURLOCATION.Text = "\\Tulsisaree\e\Software\DESIGN\" & txtname.Text.Trim & TXTFILENAME.Text.Trim

        If FileIO.FileSystem.DirectoryExists("\\Tulsisaree\e\Software\DESIGN") = False Then FileIO.FileSystem.CreateDirectory("\\Tulsisaree\e\Software\DESIGN")
        If FileIO.FileSystem.FileExists(TXTOURLOCATION.Text.Trim) = False Then FileIO.FileSystem.CopyFile(txtimgpath.Text.Trim, TXTOURLOCATION.Text.Trim, True)

        On Error Resume Next
        If txtimgpath.Text.Trim.Length <> 0 Then
            pbimage.ImageLocation = txtimgpath.Text.Trim
            pbimage.Load(txtimgpath.Text.Trim)
        End If
    End Sub

    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged

    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        Try
            If FileIO.FileSystem.FileExists(TXTOURLOCATION.Text.Trim) = True Then FileIO.FileSystem.DeleteFile(TXTOURLOCATION.Text.Trim)
            pbimage.ImageLocation = ""
            txtimgpath.Clear()
            TXTFILENAME.Clear()
            TXTOURLOCATION.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = pbimage.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                Dim OBJDESIGN As New ClsDesignRecipe
                OBJDESIGN.alParaval.Add(TEMPDESIGNID)
                OBJDESIGN.alParaval.Add(YearId)
                Dim DTTABLE As DataTable = OBJDESIGN.DELETE()
                MsgBox(DTTABLE.Rows(0).Item(0))
                edit = False
                clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class