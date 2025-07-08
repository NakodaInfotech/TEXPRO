Imports BL
Imports System.Windows.Forms
Imports System.IO
Public Class ProcessIn

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public TEMPPINO As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public Shared selectpotable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        cmbname.Text = ""

        txtadd.Clear()
        Pidate.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Mydate
        
        txtremarks.Clear()

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""


        lbllocked.Visible = False
        PBlock.Visible = False

        'gridpi.RowCount = 0
        GRIDPROGRAM.RowCount = 0
        gridupload.RowCount = 0

        cmdselectJO.Enabled = True
        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        getmaxno()

        CMBQUALITY.Text = ""
        LBLTOTALMTRS.Text = 0
        LBLTOTALPCS.Text = 0

        TXTBALENO.Clear()
        CMBPIECETYPE.Text = ""
        cmbitemname.Text = ""
        
        cmbcolor.Text = ""
        txtcutsize.Clear()
        txtPCS.Clear()
        TXTMTRS.Clear()


        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If


        If GRIDPROGRAM.RowCount > 0 Then
            txtsrno.Text = Val(GRIDPROGRAM.Rows(GRIDPROGRAM.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDPROGRAM.Rows

                LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False

    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Pidate.Validating
        If Not datecheck(Pidate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PI_no),0) + 1 ", "processin", " AND PI_cmpid=" & CmpId & " and PI_locationid=" & Locationid & " and PI_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtpino.Text = DTTABLE.Rows(0).Item(0)
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



            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If

            If GRIDPROGRAM.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If


            If Not datecheck(Pidate.Value) Then bln = False

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

            alParaval.Add(Pidate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(TextBox2.Text.Trim)

            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add("")
            alParaval.Add("")
            alParaval.Add(LBLTOTALPCS.Text.Trim)
            alParaval.Add(LBLTOTALMTRS.Text.Trim)


            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(0)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim LOTNO As String = ""
            Dim PIECETYPE As String = ""
            Dim BALENO As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim PROCESS As String = ""
            Dim GRIDLRNO As String = ""
            Dim JOBNO As String = ""
            Dim COLOR As String = ""
            Dim CUT As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim GRNNO As String = ""
            Dim GRNSRNO As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPROGRAM.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        BALENO = row.Cells(Gbaleno.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        PROCESS = row.Cells(gprocess.Index).Value.ToString
                        GRIDLRNO = row.Cells(Ggridlrno.Index).Value.ToString
                        JOBNO = row.Cells(gJOBNO.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        PCS = row.Cells(GPCS.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString

                        OUTPCS = row.Cells(GOUTPCS.Index).Value.ToString
                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value.ToString

                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

                        GRNNO = row.Cells(GGRNNO.Index).Value.ToString
                        GRNSRNO = row.Cells(GGRNSRNO.Index).Value.ToString

                    Else

                        gridsrno = gridsrno & "," & row.Cells(GSRNO.Index).Value.ToString
                        LOTNO = LOTNO & "," & row.Cells(GLOTNO.Index).Value.ToString
                        PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value.ToString
                        BALENO = BALENO & "," & row.Cells(Gbaleno.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "," & row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                        PROCESS = PROCESS & "," & row.Cells(gprocess.Index).Value.ToString
                        GRIDLRNO = GRIDLRNO & "," & row.Cells(Ggridlrno.Index).Value.ToString
                        JOBNO = JOBNO & "," & row.Cells(gJOBNO.Index).Value.ToString
                        COLOR = COLOR & "," & row.Cells(GCOLOR.Index).Value.ToString
                        CUT = CUT & "," & row.Cells(GCUT.Index).Value.ToString
                        PCS = PCS & "," & row.Cells(GPCS.Index).Value.ToString
                        MTRS = MTRS & "," & row.Cells(GMTRS.Index).Value.ToString

                        OUTPCS = OUTPCS & "," & row.Cells(GOUTPCS.Index).Value.ToString
                        OUTMTRS = OUTMTRS & "," & row.Cells(GOUTMTRS.Index).Value.ToString

                        FROMNO = FROMNO & "," & row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = FROMSRNO & "," & row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "," & row.Cells(GFROMTYPE.Index).Value.ToString

                        GRNNO = GRNNO & "," & row.Cells(GGRNNO.Index).Value.ToString
                        GRNSRNO = GRNSRNO & "," & row.Cells(GGRNSRNO.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(LOTNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(BALENO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(PROCESS)
            alParaval.Add(GRIDLRNO)
            alParaval.Add(JOBNO)
            alParaval.Add(COLOR)
            alParaval.Add(CUT)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)

            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNSRNO)



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






            Dim objCLSprocessin As New Clsprocessin()
            objCLSprocessin.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objCLSprocessin.save()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPINO)

                IntResult = objCLSprocessin.Update()
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

    Private Sub GRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            ' Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            'Call cmddelete_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
            ' Call cmdclear_Click(sender, e)
        ElseIf e.Alt = True And (e.KeyCode = Windows.Forms.Keys.D1 Or e.KeyCode = Windows.Forms.Keys.NumPad1) Then       'for CLEAR
            TabControl1.Focus()
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And (e.KeyCode = Windows.Forms.Keys.D2 Or e.KeyCode = Windows.Forms.Keys.NumPad2) Then       'for CLEAR
            TabControl1.SelectedIndex = (1)

        ElseIf e.Alt = True And (e.KeyCode = Windows.Forms.Keys.D3 Or e.KeyCode = Windows.Forms.Keys.NumPad3) Then       'for CLEAR
            TabControl1.SelectedIndex = (2)
        ElseIf e.Alt = True And (e.KeyCode = Windows.Forms.Keys.D4 Or e.KeyCode = Windows.Forms.Keys.NumPad4) Then       'for CLEAR
            TabControl1.SelectedIndex = (3)

        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub PI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
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

                Dim objCLSprocessin As New Clsprocessin()
                Dim dttable As New DataTable

                dttable = objCLSprocessin.selectPROCESSIN(TEMPPINO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        txtpino.Text = TEMPPINO
                        Pidate.Value = Format(Convert.ToDateTime(dr("pIdate")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)

                        cmbtrans.Text = dr("TRANSNAME").ToString
                        ' txttransref.Text = dr("TRANSrefno").ToString
                        txtlrno.Text = dr("LRNO").ToString

                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        ' txttransremarks.Text = dr("transremarks").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        GRIDPROGRAM.Rows.Add(dr("GRIDSRNO").ToString, dr("LOTNO").ToString, dr("PIECETYPE").ToString, dr("BALENO").ToString, dr("MERCHANT").ToString, dr("QUALITY").ToString, dr("PROCESS").ToString, dr("GRIDLRNO").ToString, dr("JOBNO").ToString, dr("COLOR").ToString, dr("CUT").ToString, Format(dr("PCS"), "0.00"), Format(dr("MTRS"), "0.00"), Format(dr("OUTPCS"), "0.00"), Format(dr("OUTMTRS"), "0.00"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), dr("GRNNO"), dr("GRNSRNO"), "")


                        If Convert.ToDecimal(dr("OUTMTRS")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                End If


                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" PI_GRIDSRNO AS GRIDSRNO, PI_REMARKS AS REMARKS, PI_NAME AS NAME, PI_IMGPATH AS IMGPATH, PI_NEWIMGPATH AS NEWIMGPATH", "", " processin_UPLOAD", " AND PI_NO = " & TEMPPINO & " AND PI_CMPID = " & CmpId & " AND PI_LOCATIONID = " & Locationid & " AND PI_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If



                total()
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

            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            'If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, edit)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)

            fillCOLOR(cmbcolor)

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

            'Dim objgrndetails As New processinDetails
            'objgrndetails.MdiParent = MDIMain
            'objgrndetails.Show()
            'objgrndetails.BringToFront()
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
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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


    Private Sub cmdselectPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectJO.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            selectpotable.Clear()
            Dim OBJSELECTPO As New SelectInward
            OBJSELECTPO.FRMSTRING = "PROCESSIN"

            OBJSELECTPO.ShowDialog()

            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable

            Dim i As Integer = 0
            If selectpotable.Rows.Count > 0 Then
                cmdselectJO.Enabled = False
                chkchange.Checked = True
                If edit = False Then GRIDPROGRAM.RowCount = 0
                For i = 0 To selectpotable.Rows.Count - 1
                    cmbname.Text = selectpotable.Rows(i).Item("NAME")

                    GRIDPROGRAM.Rows.Add(i + 1, selectpotable.Rows(i).Item("LOTNO"), selectpotable.Rows(i).Item("PIECETYPE"), selectpotable.Rows(i).Item("BALENO"), selectpotable.Rows(i).Item("ITEMNAME"), selectpotable.Rows(i).Item("QUALITY"), selectpotable.Rows(i).Item("PROCESS"), selectpotable.Rows(i).Item("JOBNO"), selectpotable.Rows(i).Item("LRNO"), selectpotable.Rows(i).Item("COLOR"), selectpotable.Rows(i).Item("CUT"), Format(Val(selectpotable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectpotable.Rows(i).Item("MTRS")), "0.00"), 0, 0, Val(selectpotable.Rows(i).Item("FROMNO")), Val(selectpotable.Rows(i).Item("FROMSRNO")), selectpotable.Rows(i).Item("FROMTYPE"), Val(selectpotable.Rows(i).Item("GRNNO")), Val(selectpotable.Rows(i).Item("GRNSRNO")))

                Next
                GRIDPROGRAM.FirstDisplayedScrollingRowIndex = GRIDPROGRAM.RowCount - 1
                getsrno(GRIDPROGRAM)
                cmbname.Focus()
            End If
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDPROGRAM.RowCount = 0
            TEMPPINO = Val(tstxtbillno.Text)
            If TEMPPINO > 0 Then
                edit = True
                PI_Load(sender, e)
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtpino.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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
            GRIDPROGRAM.RowCount = 0

            TEMPPINO = Val(txtpino.Text) - 1
            If TEMPPINO > 0 Then
                edit = True
                PI_Load(sender, e)
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
            TEMPPINO = Val(txtpino.Text) + 1
            getmaxno()
            clear()
            If Val(txtpino.Text) - 1 >= TEMPPINO Then
                edit = True
                PI_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridPI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Try
            If e.KeyCode = Keys.Delete And GRIDPROGRAM.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDPROGRAM.Rows.RemoveAt(GRIDPROGRAM.CurrentRow.Index)
                getsrno(GRIDPROGRAM)

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
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
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





    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' OR ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
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

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        Try
            If cmbitemname.Text.Trim <> "" And Val(txtPCS.Text.Trim) > 0 Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillgrid()

        GRIDPROGRAM.Enabled = True

        If gridDoubleClick = False Then
            GRIDPROGRAM.Rows.Add(Val(txtsrno.Text.Trim), txtlotno.Text.Trim, CMBPIECETYPE.Text.Trim, TXTBALENO.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, txtprocess.Text.Trim, TXTGRIDLRNO.Text.Trim, TXTJOBNO.Text.Trim, cmbcolor.Text.Trim, txtcutsize.Text, Format(Val(txtPCS.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), 0, 0, Val(txtfromno.Text), Val(txtfromsrno.Text), txtfromtype.Text.Trim, Val(txtgrnno.Text), Val(txtgrnsrno.Text), txtgrntype.Text)
            getsrno(GRIDPROGRAM)
        ElseIf gridDoubleClick = True Then
            GRIDPROGRAM.Item(GSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDPROGRAM.Item(GPIECETYPE.Index, temprow).Value = CMBPIECETYPE.Text.Trim
            GRIDPROGRAM.Item(GMERCHANT.Index, temprow).Value = cmbitemname.Text.Trim
            GRIDPROGRAM.Item(Ggridlrno.Index, temprow).Value = TXTGRIDLRNO.Text.Trim
            GRIDPROGRAM.Item(Gbaleno.Index, temprow).Value = TXTBALENO.Text.Trim
            GRIDPROGRAM.Item(GMERCHANT.Index, temprow).Value = cmbitemname.Text.Trim
            GRIDPROGRAM.Item(GQUALITY.Index, temprow).Value = CMBQUALITY.Text.Trim
            GRIDPROGRAM.Item(gJOBNO.Index, temprow).Value = TXTJOBNO.Text.Trim
            GRIDPROGRAM.Item(GCOLOR.Index, temprow).Value = cmbcolor.Text.Trim
            GRIDPROGRAM.Item(GCUT.Index, temprow).Value = txtcutsize.Text.Trim
            GRIDPROGRAM.Item(GPCS.Index, temprow).Value = Format(Val(txtPCS.Text.Trim), "0.00")
            GRIDPROGRAM.Item(GMTRS.Index, temprow).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            gridDoubleClick = False
        End If
        total()
        GRIDPROGRAM.FirstDisplayedScrollingRowIndex = GRIDPROGRAM.RowCount - 1

        txtsrno.Clear()
        cmbitemname.Text = ""
        TXTGRIDLRNO.Text = ""
        CMBQUALITY.Text = ""

        TXTBALENO.Clear()
        cmbcolor.Text = ""
        txtPCS.Clear()
        txtcutsize.Clear()
        TXTMTRS.Clear()
        txtsrno.Focus()

    End Sub

    Private Sub GRIDPROGRAM_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPROGRAM.CellDoubleClick
        If e.RowIndex >= 0 And GRIDPROGRAM.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToDecimal(GRIDPROGRAM.Rows(e.RowIndex).Cells(GOUTMTRS.Index).Value) > 0 Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from GRN")
                Exit Sub
            End If


            gridDoubleClick = True
            txtsrno.Text = GRIDPROGRAM.Item(GSRNO.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = GRIDPROGRAM.Item(GMERCHANT.Index, e.RowIndex).Value.ToString
            CMBPIECETYPE.Text = GRIDPROGRAM.Item(GPIECETYPE.Index, e.RowIndex).Value.ToString
            TXTBALENO.Text = GRIDPROGRAM.Item(Gbaleno.Index, e.RowIndex).Value.ToString
            CMBQUALITY.Text = GRIDPROGRAM.Item(GQUALITY.Index, e.RowIndex).Value.ToString
            TXTGRIDLRNO.Text = GRIDPROGRAM.Item(Ggridlrno.Index, e.RowIndex).Value.ToString
            CMBPIECETYPE.Text = GRIDPROGRAM.Item(GPIECETYPE.Index, e.RowIndex).Value.ToString
            TXTJOBNO.Text = GRIDPROGRAM.Item(gJOBNO.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = GRIDPROGRAM.Item(GCOLOR.Index, e.RowIndex).Value.ToString
            txtcutsize.Text = GRIDPROGRAM.Item(GCUT.Index, e.RowIndex).Value.ToString
            txtPCS.Text = GRIDPROGRAM.Item(GPCS.Index, e.RowIndex).Value.ToString
            TXTMTRS.Text = GRIDPROGRAM.Item(GMTRS.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub

    Private Sub GRIDPROGRAM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPROGRAM.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDPROGRAM.RowCount > 0 Then

                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDPROGRAM.Rows.RemoveAt(GRIDPROGRAM.CurrentRow.Index)
                getsrno(GRIDPROGRAM)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub GRIDPROGRAM_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPROGRAM.CellValidating
        Try
            Dim colNum As Integer = GRIDPROGRAM.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case Gpcs.Index, Gmtrs.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDPROGRAM.CurrentCell.Value = Nothing Then GRIDPROGRAM.CurrentCell.Value = "0.00"
                        GRIDPROGRAM.CurrentCell.Value = Convert.ToDecimal(GRIDPROGRAM.Item(colNum, e.RowIndex).Value)
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

   

    Private Sub txtlotno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtlotno.Validating
        'Try
        '    If txtlotno.Text <> "" Then
        '        Dim objCLSprocessin As New ClsCommon()
        '        Dim dttable As New DataTable
        '        dttable = objCLSprocessin.search(" ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, ISNULL(QUALITYMASTER.QUALITY_name,'') AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME,'') AS PROCESS, ISNULL(PROCESSOUT_DESC.PO_NO,0) AS FROMNO, ISNULL(PROCESSOUT_DESC.PO_GRIDSRNO,0) AS FROMSRNO, 'OUT' AS FROMTYPE, ISNULL(PROCESSOUT_DESC.PO_GRNNO,0) AS GRNNO, ISNULL(PROCESSOUT_DESC.PO_GRNSRNO,0) AS GRNSRNO, ISNULL(PROCESSOUT_DESC.PO_GRNTYPE,'') AS GRNTYPE", "", " PROCESSOUT INNER JOIN LEDGERS ON PROCESSOUT.PO_TOledgerid = LEDGERS.Acc_id AND PROCESSOUT.PO_cmpid = LEDGERS.Acc_cmpid AND PROCESSOUT.PO_locationid = LEDGERS.Acc_locationid AND PROCESSOUT.PO_yearid = LEDGERS.Acc_yearid INNER JOIN PROCESSOUT_DESC ON PROCESSOUT.PO_cmpid = PROCESSOUT_DESC.PO_CMPID AND PROCESSOUT.PO_locationid = PROCESSOUT_DESC.PO_LOCATIONID AND PROCESSOUT.PO_yearid = PROCESSOUT_DESC.PO_YEARID INNER JOIN QUALITYMASTER ON PROCESSOUT_DESC.PO_QUALITYID = QUALITYMASTER.QUALITY_id AND PROCESSOUT_DESC.PO_CMPID = QUALITYMASTER.QUALITY_cmpid AND PROCESSOUT_DESC.PO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PROCESSOUT_DESC.PO_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN PROCESSMASTER ON PROCESSOUT.PO_PROCESSID = PROCESSMASTER.PROCESS_ID AND PROCESSOUT.PO_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESSOUT.PO_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESSOUT.PO_yearid = PROCESSMASTER.PROCESS_YEARID ", " AND ACC_CMPNAME='" & cmbname.Text & "' AND PROCESSOUT.PO_LOTNO = '" & txtlotno.Text & "' AND PROCESSOUT_DESC.PO_CMPID = " & CmpId & " AND PROCESSOUT_DESC.PO_LOCATIONID = " & Locationid & " AND PROCESSOUT_DESC.PO_YEARID = " & YearId)
        '        If dttable.Rows.Count > 0 Then
        '            txtprocess.Text = dttable.Rows(0).Item("PROCESS")
        '            txtfromno.Text = dttable.Rows(0).Item("FROMNO")
        '            txtfromsrno.Text = dttable.Rows(0).Item("FROMSRNO")
        '            txtfromtype.Text = dttable.Rows(0).Item("FROMTYPE")
        '            txtgrnno.Text = dttable.Rows(0).Item("GRNNO")
        '            txtgrnsrno.Text = dttable.Rows(0).Item("GRNSRNO")
        '            txtgrntype.Text = dttable.Rows(0).Item("GRNTYPE")
        '        Else
        '            MsgBox("Lot No and Party Does Not match")
        '            e.Cancel = True
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub txtPCS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPCS.Validating
        If Val(txtcutsize.Text) > 0 And Val(txtPCS.Text) > 0 Then
            TXTMTRS.Text = Format(Val(txtcutsize.Text) * Val(txtPCS.Text), "0.00")
        End If
    End Sub

    Private Sub txtcutsize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcutsize.Validating
        If Val(txtcutsize.Text) > 0 And Val(txtPCS.Text) > 0 Then
            TXTMTRS.Text = Format(Val(txtcutsize.Text) * Val(txtPCS.Text), "0.00")
        End If
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGodown.Enter
        Try
            'If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
        Try
            'If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class