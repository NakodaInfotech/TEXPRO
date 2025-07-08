
Imports BL
Imports System.IO

Public Class DesignIssue


    Public TEMPSKETCHNO As String
    Public TEMPISSUENO As Integer
    Public EDIT As Boolean

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If CMBMERCHANT.Text.Trim = "" Then FILLISSUEMERCHANT(CMBMERCHANT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            TXTAMOUNT.Clear()

            TXTAMOUNT.Text = Format((Val(TXTSMALL1.Text.Trim) * Val(TXTSMALLRATE.Text.Trim)) + (Val(TXTMACHINE.Text.Trim) * Val(TXTMACRATE.Text.Trim)) + (Val(TXTTABLE.Text.Trim) * Val(TXTTABLERATE.Text.Trim)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        EP.Clear()
        ISSDATE.Value = Mydate
        TXTSKETCHNO.Clear()
        CMBNAME.Text = ""
        TXTMACHINE.Clear()
        TXTSMALL1.Clear()
        TXTBIG.Clear()
        TXTTABLE.Clear()
        CMBMERCHANT.Text = ""
        TXTREMARKS.Clear()
        TXTRECDATE.Clear()
        TXTDESIGNNO.Clear()
        TXTBILLNO.Clear()
        TXTBILLDATE.Clear()

        TXTSMALLRATE.Text = 500
        TXTMACRATE.Text = 700
        TXTTABLERATE.Text = 800

        PBPHOTO.Image = Nothing

        getmaxno()

    End Sub

    Private Sub DesignIssue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignIssue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then

                Dim OBJDESIGN As New ClsDesignIssue()
                Dim ALPARAVAL As New ArrayList

                Dim dttable As New DataTable

                ALPARAVAL.Add(TEMPISSUENO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJDESIGN.alParaval = ALPARAVAL
                dttable = OBJDESIGN.SELECTDESIGNISSUE()
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows
                        TXTISSUENO.Text = TEMPISSUENO
                        ISSDATE.Value = Format(Convert.ToDateTime(dr("ISSDATE")).Date, "dd/MM/yyyy")
                        TXTSKETCHNO.Text = dr("SKETCHNO")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        TXTMACHINE.Text = Val(dr("MACHINE"))
                        TXTSMALL1.Text = Val(dr("SMALL1"))
                        TXTBIG.Text = Val(dr("BIG"))
                        TXTTABLE.Text = Val(dr("TABLE"))
                        CMBMERCHANT.Text = Convert.ToString(dr("MERCHANT").ToString)
                        TXTRECDATE.Text = dr("RECDATE")
                        TXTDESIGNNO.Text = Convert.ToString(dr("DESIGNNO").ToString)
                        TXTBILLDATE.Text = dr("BILLDATE")
                        TXTBILLNO.Text = Convert.ToString(dr("BILLNO").ToString)
                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)
                        TXTSMALLRATE.Text = Val(dr("SMALLRATE"))
                        TXTMACRATE.Text = Val(dr("MACRATE"))
                        TXTTABLERATE.Text = Val(dr("TABLERATE"))
                        TXTAMOUNT.Text = Val(dr("AMOUNT"))
                    Next

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                        PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                        TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                    Else
                        PBPHOTO.Image = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        ISSDATE.Focus()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If TXTSKETCHNO.Text.Trim = "" Then
            EP.SetError(TXTSKETCHNO, "Sketch No cannot be blank")
            bln = False
        End If

        If CMBNAME.Text.Trim = "" Then
            EP.SetError(CMBNAME, "Party Name cannot be blank")
            bln = False
        End If

        If CMBMERCHANT.Text.Trim = "" Then
            EP.SetError(CMBMERCHANT, "Merchant No cannot be blank")
            bln = False
        End If

        If Val(TXTMACHINE.Text.Trim) = 0 And Val(TXTSMALL1.Text.Trim) = 0 And Val(TXTBIG.Text.Trim) = 0 And Val(TXTTABLE.Text.Trim) = 0 Then
            EP.SetError(TXTMACHINE, "Enter Atlest 1 Screen")
            bln = False
        End If

        If TXTRECDATE.Text <> "  /  /" Then
            If TXTDESIGNNO.Text.Trim = "" Then
                EP.SetError(TXTDESIGNNO, "Enter Design No")
                bln = False
            End If
            If Convert.ToDateTime(TXTRECDATE.Text).Date < ISSDATE.Value.Date Then
                EP.SetError(TXTRECDATE, " Please Enter Proper Date")
                bln = False
            End If
        End If

        Return bln
    End Function

    Private Function DUPLICATE() As Boolean
        Dim bln As Boolean = True

        If TXTSKETCHNO.Text.Trim <> "" Then
            uppercase(TXTSKETCHNO)
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(TXTSKETCHNO.Text) <> LCase(TEMPSKETCHNO)) Then
                dt = objclscommon.search("DESIGN_SKETCHNO", "", " DESIGNISSUEMASTER ", " AND DESIGN_SKETCHNO = '" & TXTSKETCHNO.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    EP.SetError(TXTSKETCHNO, "Sketch No Already Exists")
                    bln = False
                End If
            End If
        End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            EP.Clear()
            If Not DUPLICATE() Then
                Exit Sub
            End If


            Dim alParaval As New ArrayList

            alParaval.Add(ISSDATE.Value.Date)
            alParaval.Add(TXTSKETCHNO.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Val(TXTMACHINE.Text.Trim))
            alParaval.Add(Val(TXTSMALL1.Text.Trim))
            alParaval.Add(Val(TXTBIG.Text.Trim))
            alParaval.Add(Val(TXTTABLE.Text.Trim))
            alParaval.Add(CMBMERCHANT.Text.Trim)
            alParaval.Add(TXTRECDATE.Text)
            alParaval.Add(TXTDESIGNNO.Text.Trim)
            alParaval.Add(TXTBILLDATE.Text)
            alParaval.Add(TXTBILLNO.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)

            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            alParaval.Add(Val(TXTSMALLRATE.Text.Trim))
            alParaval.Add(Val(TXTMACRATE.Text.Trim))
            alParaval.Add(Val(TXTTABLERATE.Text.Trim))
            alParaval.Add(Val(TXTAMOUNT.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJDESIGN As New ClsDesignIssue
            OBJDESIGN.alParaval = alParaval

            If EDIT = False Then
                IntResult = OBJDESIGN.SAVE()
                MsgBox("Entry Added")
            Else
                alParaval.Add(TEMPISSUENO)
                IntResult = OBJDESIGN.Update()
                MsgBox("Entry Updated")
            End If

            clear()
            EDIT = False
            ISSDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub TXTSKETCHNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSKETCHNO.Validating
        Try
            EP.Clear()
            If TXTSKETCHNO.Text.Trim <> "" Then
                If Not DUPLICATE() Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBIG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBIG.KeyPress, TXTTABLE.KeyPress, TXTMACHINE.KeyPress, TXTSMALL1.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then FILLISSUEMERCHANT(CMBMERCHANT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then ISSUEMERCHANTVALIDATE(CMBMERCHANT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJDESIGN As New DesignIssueRegister
            OBJDESIGN.MdiParent = MDIMain
            OBJDESIGN.Show()
            OBJDESIGN.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then

                Dim TEMPMSG As Integer = MsgBox("Delete Entry?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPISSUENO)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJDESIGN As New ClsDesignIssue
                    OBJDESIGN.alParaval = alParaval
                    IntResult = OBJDESIGN.Delete()
                    MsgBox("Entry Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpeg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTPHOTOIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTPHOTOIMGPATH.Text.Trim.Length <> 0 Then PBPHOTO.ImageLocation = TXTPHOTOIMGPATH.Text.Trim
    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        Try
            PBPHOTO.Image = Nothing
            TXTPHOTOIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If TXTPHOTOIMGPATH.Text.Trim <> "" Then
                If Path.GetExtension(TXTPHOTOIMGPATH.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(TXTPHOTOIMGPATH.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBPHOTO.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRECDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRECDATE.Validating
        Try
            If TXTRECDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(TXTRECDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBILLDATE.Validating
        Try
            If TXTBILLDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(TXTBILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(DESIGN_ISSNO),0) + 1 ", " DESIGNISSUEMASTER", " AND DESIGN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTISSUENO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            TXTSKETCHNO.Text = ""

            TEMPISSUENO = Val(TXTISSUENO.Text) - 1
            If TEMPISSUENO > 0 Then
                EDIT = True
                DesignIssue_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TEMPISSUENO = Val(TXTISSUENO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTISSUENO.Text) - 1 >= TEMPISSUENO Then
                EDIT = True
                DesignIssue_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            TXTSKETCHNO.Text = ""
            TEMPISSUENO = Val(tstxtbillno.Text)
            If TEMPISSUENO > 0 Then
                EDIT = True
                DesignIssue_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTSMALLRATE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSMALLRATE.KeyPress, TXTMACRATE.KeyPress, TXTTABLERATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTSMALL1_Validated(sender As Object, e As EventArgs) Handles TXTSMALL1.Validated, TXTMACHINE.Validated, TXTTABLE.Validated, TXTMACRATE.Validated, TXTSMALLRATE.Validated, TXTTABLERATE.Validated
        TOTAL()
    End Sub
End Class