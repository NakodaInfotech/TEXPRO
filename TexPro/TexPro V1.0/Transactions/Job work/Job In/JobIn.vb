
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class JobIn

    Dim COPY As Boolean = False
    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public tempjino As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public Shared selectjitable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        'cmbname.Enabled = True
        cmbname.Text = ""
        CMBFROM.Text = ""
        CMBFROM.Enabled = True

        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        txtadd.Clear()
        JIdate.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Mydate
        txttransref.Clear()
        txttransremarks.Clear()
        cmbname.Enabled = True
        CMBQUALITY.Text = ""
        txtremarks.Clear()

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""
        TXTJONO.Clear()
        TXTJOSRNO.Clear()
        TXTPSSRNO.Clear()
        TXTMFGNO.Clear()
        TXTMFGSRNO.Clear()
        TXTLOTNO.Clear()
        TXTLOTSRNO.Clear()

        TXTCHECKNO.Clear()
        TXTCHECKSRNO.Clear()

        TXTTYPE.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos

        gridJI.RowCount = 0

        cmdselectJO.Enabled = True
        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        getmaxno()


        LBLTOTALMTRS.Text = 0
        LBLTOTALPCS.Text = 0





        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0


            For Each ROW As DataGridViewRow In gridJI.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(Gpcs.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbname.Focus()
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles JIdate.Validating
        If Not datecheck(JIdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JI_no),0) + 1 ", "JOBIN", " AND JI_cmpid=" & CmpId & " and JI_locationid=" & Locationid & " and JI_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtJino.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If

            If CMBFROM.Text.Trim.Length = 0 Then
                EP.SetError(CMBFROM, " Please Select Process Name")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If

            If gridJI.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            For Each ROW As DataGridViewRow In gridJI.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    If Val(ROW.Cells(Gmtrs.Index).EditedFormattedValue) = 0 Then
                        EP.SetError(CMBFROM, "Value Cannot be 0")
                        bln = False
                    End If
                End If
            Next


            If Not datecheck(JIdate.Value) Then bln = False

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(JIdate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBFROM.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(txttransremarks.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(LBLTOTALPCS.Text.Trim)
            alParaval.Add(LBLTOTALMTRS.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim JOBNO As String = ""
            Dim BALENO As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim CUT As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim JONO As String = ""
            Dim JOGRIDSRNO As String = ""
            Dim PSGRIDSRNO As String = ""
            Dim CHECKNO As String = ""
            Dim CHECKSRNO As String = ""
            Dim MFGNO As String = ""
            Dim MFGSRNO As String = ""
            Dim LOTNO As String = ""
            Dim LOTSRNO As String = ""
            Dim GRNTYPE As String = ""

            Dim JIDONE As String = ""      'WHETHER JO IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In gridJI.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        JOBNO = row.Cells(GJOBNO.Index).Value.ToString
                        BALENO = row.Cells(Gbaleno.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        PCS = row.Cells(Gpcs.Index).Value.ToString
                        MTRS = row.Cells(Gmtrs.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            JIDONE = 1
                        Else
                            JIDONE = 0
                        End If
                        JONO = row.Cells(GJONO.Index).Value.ToString
                        JOGRIDSRNO = row.Cells(GJOSRNO.Index).Value.ToString
                        PSGRIDSRNO = row.Cells(GPSGRIDSRNO.Index).Value.ToString
                        CHECKNO = row.Cells(GCHECKNO.Index).Value.ToString
                        CHECKSRNO = row.Cells(GCHECKSRNO.Index).Value.ToString
                        MFGNO = row.Cells(GMFGNO.Index).Value.ToString
                        MFGSRNO = row.Cells(GMFGSRNO.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        LOTSRNO = row.Cells(GLOTSRNO.Index).Value.ToString
                        GRNTYPE = row.Cells(GGRNTYPE.Index).Value.ToString


                    Else

                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value.ToString
                        JOBNO = JOBNO & "," & row.Cells(GJOBNO.Index).Value.ToString
                        BALENO = BALENO & "," & row.Cells(Gbaleno.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "," & row.Cells(GCOLOR.Index).Value.ToString
                        CUT = CUT & "," & row.Cells(GCUT.Index).Value.ToString
                        PCS = PCS & "," & row.Cells(Gpcs.Index).Value.ToString
                        MTRS = MTRS & "," & row.Cells(Gmtrs.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            JIDONE = JIDONE & "," & "1"
                        Else
                            JIDONE = JIDONE & "," & "0"
                        End If
                        JONO = JONO & "," & row.Cells(GJONO.Index).Value.ToString
                        JOGRIDSRNO = JOGRIDSRNO & "," & row.Cells(GJOSRNO.Index).Value.ToString
                        PSGRIDSRNO = PSGRIDSRNO & "," & row.Cells(GPSGRIDSRNO.Index).Value.ToString
                        CHECKNO = CHECKNO & "," & row.Cells(GCHECKNO.Index).Value.ToString
                        CHECKSRNO = CHECKSRNO & "," & row.Cells(GCHECKSRNO.Index).Value.ToString
                        MFGNO = MFGNO & "," & row.Cells(GMFGNO.Index).Value.ToString
                        MFGSRNO = MFGSRNO & "," & row.Cells(GMFGSRNO.Index).Value.ToString
                        LOTNO = LOTNO & "," & row.Cells(GLOTNO.Index).Value.ToString
                        LOTSRNO = LOTSRNO & "," & row.Cells(GLOTSRNO.Index).Value.ToString
                        GRNTYPE = GRNTYPE & "," & row.Cells(GGRNTYPE.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(JOBNO)
            alParaval.Add(BALENO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(CUT)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(JIDONE)
            alParaval.Add(JONO)
            alParaval.Add(JOGRIDSRNO)
            alParaval.Add(PSGRIDSRNO)
            alParaval.Add(CHECKNO)
            alParaval.Add(CHECKSRNO)
            alParaval.Add(MFGNO)
            alParaval.Add(MFGSRNO)
            alParaval.Add(LOTNO)
            alParaval.Add(LOTSRNO)
            alParaval.Add(GRNTYPE)



            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "," & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "," & row.Cells(1).Value.ToString
                        name = name & "," & row.Cells(2).Value.ToString
                        imgpath = imgpath & "," & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "," & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)


            Dim objCLSJI As New ClsJI()
            objCLSJI.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objCLSJI.save()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempjino)

                IntResult = objCLSJI.Update()
                MsgBox("Details Updated")

            End If
            edit = False

            TEMPMSG = MsgBox("Wish to Print JO?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                'Call PrintToolStripButton_Click(sender, e)
            End If

            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next


            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub jobin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                'Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.P Then       'for COPY
                Call pbcopy_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                'Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
                'Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
                Call cmdselectpo_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub jobin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub JI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB WORK IN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objCLSJI As New ClsJI()
                Dim dttable As New DataTable

                dttable = objCLSJI.selectJO(tempjino, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        txtJino.Text = tempjino
                        JIdate.Value = Format(Convert.ToDateTime(dr("JIDATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)

                        CMBFROM.Text = dr("PROCESSNAME").ToString
                        CMBFROM.Enabled = False

                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("transrefno").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txttransremarks.Text = dr("transremarks").ToString
                        CMBGODOWN.Text = dr("GODOWN")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        gridJI.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("JOBNO").ToString, dr("BALENO").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("COLOR").ToString, dr("CUT").ToString, Format(dr("PCS"), "0.00"), Format(dr("MTRS"), "0.00"), dr("GRIDDONE").ToString, dr("JONO"), dr("JOGRIDSRNO"), dr("psGRIDSRNO"), dr("CHECKNO"), dr("CHECKSRNO"), dr("MFGNO"), dr("MFGSRNO"), dr("LOTNO"), dr("LOTSRNO"), dr("GRNTYPE").ToString)


                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    total()
                End If


                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" JI_GRIDSRNO AS GRIDSRNO, JI_REMARKS AS REMARKS, JI_NAME AS NAME, JI_IMGPATH AS IMGPATH, JI_NEWIMGPATH AS NEWIMGPATH", "", " JOBIN_UPLOAD", " AND JI_NO = " & tempjino & " AND JI_CMPID = " & CmpId & " AND JI_LOCATIONID = " & Locationid & " AND JI_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If




                chkchange.CheckState = CheckState.Checked
            End If



        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(CMBQUALITY, edit)
            fillDESIGN(cmbdesign, cmbitemname.Text)
            fillCOLOR(cmbcolor)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            FILLPROCESS(CMBFROM, "", edit)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJJOB As New JobInDetails
            OBJJOB.MdiParent = MDIMain
            OBJJOB.Show()
            OBJJOB.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectJO.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            selectjitable.Clear()
            Dim OBJSELECTPO As New SelectJobOut

            OBJSELECTPO.ShowDialog()


            Dim i As Integer = 0
            If selectjitable.Rows.Count > 0 Then
                chkchange.Checked = True
                If edit = False Then gridJI.RowCount = 0
                For i = 0 To selectjitable.Rows.Count - 1
                    cmbname.Text = selectjitable.Rows(i).Item("NAME")
                    gridJI.Rows.Add(i + 1, selectjitable.Rows(i).Item("PIECETYPE"), selectjitable.Rows(i).Item("JONO"), selectjitable.Rows(i).Item("BALENO"), selectjitable.Rows(i).Item("ITEMNAME"), selectjitable.Rows(i).Item("QUALITY"), selectjitable.Rows(i).Item("DESIGN"), selectjitable.Rows(i).Item("COLOR"), selectjitable.Rows(i).Item("CUT"), Format(Val(selectjitable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectjitable.Rows(i).Item("MTRS")), "0.00"), 0, selectjitable.Rows(i).Item("JONO"), selectjitable.Rows(i).Item("JOGRIDSRNO"), selectjitable.Rows(i).Item("PSGRIDSRNO"), selectjitable.Rows(i).Item("CHECKNO"), selectjitable.Rows(i).Item("CHECKSRNO"), selectjitable.Rows(i).Item("MFGNO"), selectjitable.Rows(i).Item("MFGSRNO"), selectjitable.Rows(i).Item("LOTNO"), selectjitable.Rows(i).Item("LOTSRNO"), selectjitable.Rows(i).Item("GRNTYPE"))
                Next
                If cmbname.Text.Trim <> "" Then cmbname.Enabled = False
                gridJI.FirstDisplayedScrollingRowIndex = gridJI.RowCount - 1
                getsrno(gridJI)
                cmbname.Focus()
            End If
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridJI.RowCount = 0
            tempjino = Val(tstxtbillno.Text)
            If tempjino > 0 Then
                edit = True
                JI_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub fillgridscan()
        Try
            If gridUPLOADdoubleclick = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf gridUPLOADdoubleclick = True Then

                gridupload.Item(0, tempUPLOADrow).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, tempUPLOADrow).Value = txtuploadname.Text.Trim
                gridupload.Item(3, tempUPLOADrow).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, tempUPLOADrow).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, tempUPLOADrow).Value = TXTFILENAME.Text.Trim

                gridUPLOADdoubleclick = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpeg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtJino.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                gridUPLOADdoubleclick = True
                tempUPLOADrow = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If gridUPLOADdoubleclick = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub


    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            gridJI.RowCount = 0

            tempjino = Val(txtJino.Text) - 1
            If tempjino > 0 Then
                edit = True
                JI_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            tempjino = Val(txtJino.Text) + 1
            getmaxno()
            clear()
            If Val(txtJino.Text) - 1 >= tempjino Then
                edit = True
                JI_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub GRIDJI_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridJI.CellValidating
        Try
            Dim colNum As Integer = gridJI.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case Gpcs.Index, Gmtrs.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridJI.CurrentCell.Value = Nothing Then gridJI.CurrentCell.Value = "0.00"
                        gridJI.CurrentCell.Value = Convert.ToDecimal(gridJI.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub gridJI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridJI.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridJI.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridJI.Rows.RemoveAt(gridJI.CurrentRow.Index)
                getsrno(gridJI)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        Try
            If cmbitemname.Text.Trim <> "" And Val(txtPCS.Text.Trim) > 0 And Val(TXTMTRS.Text.Trim) > 0 Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                CMBPIECETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridJI.Enabled = True

        If gridDoubleClick = False And COPY = True Then
            gridJI.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, TXTJOBNO.Text.Trim, TXTBALENO.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, cmbdesign.Text.Trim, cmbcolor.Text.Trim, txtcutsize.Text, Format(Val(txtPCS.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), 0, TXTJONO.Text, TXTJOSRNO.Text, TXTPSSRNO.Text, TXTCHECKNO.Text, TXTCHECKSRNO.Text, TXTMFGNO.Text, TXTMFGSRNO.Text, TXTLOTNO.Text, TXTLOTSRNO.Text, TXTTYPE.Text)
            getsrno(gridJI)
            COPY = False
        ElseIf gridDoubleClick = True Then
            gridJI.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            gridJI.Item(GPIECETYPE.Index, temprow).Value = CMBPIECETYPE.Text.Trim
            gridJI.Item(GJOBNO.Index, temprow).Value = TXTJOBNO.Text.Trim
            gridJI.Item(Gbaleno.Index, temprow).Value = TXTBALENO.Text.Trim
            gridJI.Item(GITEMNAME.Index, temprow).Value = cmbitemname.Text.Trim
            gridJI.Item(GQUALITY.Index, temprow).Value = CMBQUALITY.Text.Trim
            gridJI.Item(GDESIGN.Index, temprow).Value = cmbdesign.Text.Trim
            gridJI.Item(GCOLOR.Index, temprow).Value = cmbcolor.Text.Trim
            gridJI.Item(GCUT.Index, temprow).Value = txtcutsize.Text.Trim
            gridJI.Item(Gpcs.Index, temprow).Value = Format(Val(txtPCS.Text.Trim), "0.00")
            gridJI.Item(Gmtrs.Index, temprow).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            gridDoubleClick = False
        End If

        gridJI.FirstDisplayedScrollingRowIndex = gridJI.RowCount - 1

        txtsrno.Clear()
        cmbitemname.Text = ""
        TXTJOBNO.Clear()
        CMBQUALITY.Text = ""
        CMBPIECETYPE.Text = ""
        TXTBALENO.Clear()
        cmbcolor.Text = ""
        txtPCS.Clear()
        txtcutsize.Clear()
        TXTMTRS.Clear()
        txtsrno.Focus()
        TXTJONO.Clear()
        TXTJOSRNO.Clear()
        TXTPSSRNO.Clear()
        TXTMFGNO.Clear()
        TXTMFGSRNO.Clear()
        TXTLOTNO.Clear()
        TXTLOTSRNO.Clear()

        TXTCHECKNO.Clear()
        TXTCHECKSRNO.Clear()

        TXTTYPE.Clear()
    End Sub

    Private Sub GRIDJI_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridJI.CellDoubleClick
        If e.RowIndex >= 0 And gridJI.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(gridJI.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from GRN")
                Exit Sub
            End If


            gridDoubleClick = True
            txtsrno.Text = gridJI.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = gridJI.Item(GITEMNAME.Index, e.RowIndex).Value.ToString
            TXTBALENO.Text = gridJI.Item(Gbaleno.Index, e.RowIndex).Value.ToString
            CMBQUALITY.Text = gridJI.Item(GQUALITY.Index, e.RowIndex).Value.ToString
            TXTJOBNO.Text = gridJI.Item(GJOBNO.Index, e.RowIndex).Value.ToString
            CMBPIECETYPE.Text = gridJI.Item(GPIECETYPE.Index, e.RowIndex).Value.ToString
            cmbdesign.Text = gridJI.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = gridJI.Item(GCOLOR.Index, e.RowIndex).Value.ToString
            txtcutsize.Text = gridJI.Item(GCUT.Index, e.RowIndex).Value.ToString
            txtPCS.Text = gridJI.Item(Gpcs.Index, e.RowIndex).Value.ToString
            TXTMTRS.Text = gridJI.Item(Gmtrs.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            fillCOLOR(cmbcolor)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            COLORvalidate(cmbcolor, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' or ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbpiecetype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.GotFocus
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbpiecetype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesign.GotFocus
        Try
            If cmbdesign.Text.Trim = "" Then fillDESIGN(cmbdesign, cmbitemname.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesign.Validating
        Try
            If cmbdesign.Text.Trim <> "" Then DESIGNvalidate(cmbdesign, e, Me, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub pbcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbcopy.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            If gridDoubleClick = True Then
                MsgBox("Copy function is disabled in grid line edit mode")
                txtsrno.Focus()
                Exit Sub
            End If

            If gridJI.RowCount > 0 Then

                COPY = True
                For Each ROW As DataGridViewRow In gridJI.SelectedRows
                    txtsrno.Text = gridJI.RowCount + 1
                    CMBPIECETYPE.Text = ROW.Cells(GPIECETYPE.Index).Value.ToString
                    TXTJOBNO.Text = ROW.Cells(GJOBNO.Index).Value.ToString
                    TXTBALENO.Text = ROW.Cells(Gbaleno.Index).Value.ToString
                    cmbcolor.Text = ROW.Cells(GCOLOR.Index).Value.ToString
                    cmbdesign.Text = ROW.Cells(GDESIGN.Index).Value.ToString
                    CMBQUALITY.Text = ROW.Cells(GQUALITY.Index).Value.ToString
                    cmbitemname.Text = ROW.Cells(GITEMNAME.Index).Value.ToString
                    txtcutsize.Text = ROW.Cells(GCUT.Index).Value.ToString
                    txtPCS.Text = ROW.Cells(Gpcs.Index).Value.ToString
                    TXTMTRS.Text = ROW.Cells(Gmtrs.Index).Value.ToString
                    TXTJONO.Text = ROW.Cells(GJONO.Index).Value.ToString
                    TXTJOSRNO.Text = ROW.Cells(GJOSRNO.Index).Value.ToString
                    TXTPSSRNO.Text = ROW.Cells(GPSGRIDSRNO.Index).Value.ToString
                    TXTMFGNO.Text = ROW.Cells(GMFGNO.Index).Value.ToString
                    TXTMFGSRNO.Text = ROW.Cells(GMFGSRNO.Index).Value.ToString
                    TXTLOTNO.Text = ROW.Cells(GLOTNO.Index).Value.ToString
                    TXTLOTSRNO.Text = ROW.Cells(GLOTSRNO.Index).Value.ToString

                    TXTCHECKNO.Text = ROW.Cells(GCHECKNO.Index).Value
                    TXTCHECKSRNO.Text = ROW.Cells(GCHECKSRNO.Index).Value

                    TXTTYPE.Text = ROW.Cells(GGRNTYPE.Index).Value.ToString
                    temprow = ROW.Index
                    CMBPIECETYPE.Focus()
                Next

                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcutsize_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcutsize.Validating
        Try
            If Val(txtcutsize.Text.Trim) > 0 And Val(txtPCS.Text.Trim) > 0 Then
                TXTMTRS.Text = Val(txtcutsize.Text.Trim) * Val(txtPCS.Text.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtPCS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPCS.Validating
        Try
            If Val(txtcutsize.Text.Trim) > 0 And Val(txtPCS.Text.Trim) > 0 Then
                TXTMTRS.Text = Val(txtcutsize.Text.Trim) * Val(txtPCS.Text.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Validated
        Try
            If CMBFROM.Text.Trim <> "" Then CMBFROM.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Packing Slip Raised against this Job,Please Delete Packing Slip First?")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Job?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(tempjino)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJMFG As New ClsJI()
                    OBJMFG.alParaval = alParaval
                    IntResult = OBJMFG.Delete()
                    MsgBox("job Deleted")
                    clear()
                    edit = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub CMBGODOWN_Enter(sender As Object, e As EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then FILLGODOWN(CMBGODOWN, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(sender As Object, e As CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class