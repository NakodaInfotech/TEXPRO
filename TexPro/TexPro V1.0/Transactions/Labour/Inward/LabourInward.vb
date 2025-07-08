
Imports BL
Imports System.Windows.Forms
Imports System.IO
Public Class LabourInward

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Dim gridcheckdoubleclick As Boolean
    Dim gridproDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public OUTedit As Boolean          'used for editing
    Public templino As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Dim tempcheckrow As Integer
    Dim tempprorow As Integer
    Public Shared selectPOtable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        cmbname.Enabled = True
        cmbname.Text = ""
        CMBWEAVER.Text = ""
        CMBBROKER.Text = ""
        CMBSENDER.Text = ""
        CMBQUALITY.Text = ""
        cmbGodown.Text = ""
        CMBTONAME.Text = ""
        cmbprocess.Text = ""
        TXTLOTNO.Clear()
        txtpAppmtrs.Clear()
        txtpApppcs.Clear()
        txtpchkpcs.Clear()
        txtpcheckmtrs.Clear()
        txtpshortmtrs.Clear()
        txtpshortpcs.Clear()
        txtprejpcs.Clear()
        txtprejmtrs.Clear()
        dtpchallan.Value = Mydate
        txtchallan.Clear()
        txtpono.Clear()
        podate.Value = Mydate
        txtadd.Clear()
        grndate.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Mydate
        txttransref.Clear()
        txttransremarks.Clear()
        TabControl1.SelectedIndex = (0)
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

        'clearing itemgrid textboxes and combos
        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        CMBQUALITY.Text = ""
        TXTREED.Clear()
        TXTPICK.Clear()
        cmbcolor.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        TXTWT.Clear()
        gridgrn.RowCount = 0
        GRIDPROGRAM.RowCount = 0
        cmbtrans.Text = ""
        txtlrno.Clear()

        cmdselectPO.Enabled = True
        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        gridproDoubleClick = False

        getmaxno()
        LBLTOTALMTRS.Text = 0
        LBLTOTALMTRS.Text = 0
        TXTTOTALBALES.Clear()
        lbltotalqty.Text = 0
        LBLTOTALWT.Text = 0

        gridchecking.RowCount = 0

        If gridchecking.RowCount > 0 Then
            txtchecksrno.Text = Val(gridchecking.Rows(gridchecking.RowCount - 1).Cells(0).Value) + 1
        Else
            txtchecksrno.Text = 1
        End If

        If GRIDPROGRAM.RowCount > 0 Then
            TXTPROSRNO.Text = Val(GRIDPROGRAM.Rows(GRIDPROGRAM.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTPROSRNO.Text = 1
        End If

        If gridgrn.RowCount > 0 Then
            txtsrno.Text = Val(gridgrn.Rows(gridgrn.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0
            lbltotalappMtrs.Text = 0.0
            lbltotalapppcs.Text = 0.0

            For Each ROW As DataGridViewRow In gridgrn.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then

                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")

                End If
            Next
            For Each ROW As DataGridViewRow In gridchecking.Rows
                If ROW.Cells(gchecksrno.Index).Value <> Nothing Then

                    lbltotalappMtrs.Text = Format(Val(lbltotalappMtrs.Text) + Val(ROW.Cells(gAppMtrs.Index).EditedFormattedValue), "0.00")
                    lbltotalapppcs.Text = Format(Val(lbltotalapppcs.Text) + Val(ROW.Cells(gAppPcs.Index).EditedFormattedValue), "0.00")

                End If
            Next
            If gridgrn.RowCount > 0 Then
                gridgrn.Rows(0).Cells(gAcceptedpcs.Index).Value = Format(Val(lbltotalapppcs.Text.Trim), "0.00")
                gridgrn.Rows(0).Cells(gAcceptedMtrs.Index).Value = Format(Val(lbltotalappMtrs.Text.Trim), "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        OUTedit = False

        edit = False
        cmbname.Focus()
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grndate.Validating
        If Not datecheck(grndate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(LI_no),0) + 1 ", " LABOURINWARD ", " AND LI_cmpid=" & CmpId & " and LI_locationid=" & Locationid & " and LI_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtgrnno.Text = DTTABLE.Rows(0).Item(0)
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

            If gridgrn.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            'For Each row As DataGridViewRow In gridgrn.Rows
            '    Dim OBJCMN As New ClsCommon
            '    Dim DT As DataTable = OBJCMN.search("MATERIAL_NAME", "", "  ITEMMASTER INNER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id AND ITEMMASTER.item_cmpid = MATERIALTYPEMASTER.material_cmpid AND ITEMMASTER.item_locationid = MATERIALTYPEMASTER.material_locationid AND ITEMMASTER.item_yearid = MATERIALTYPEMASTER.material_yearid ", " AND ITEMMASTER.ITEM_NAME = '" & row.Cells(gitemname.Index).Value & "' AND ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
            '    If Val(row.Cells(GMTRS.Index).Value) = 0 And (DT.Rows(0).Item(0) = "Raw Material" Or DT.Rows(0).Item(0) = "Semi Finished Goods" Or DT.Rows(0).Item(0) = "Finished Goods") Then
            '        EP.SetError(TabControl1, "MTRS Cannot be kept Blank")
            '        bln = False
            '    End If
            'Next

            If Not datecheck(grndate.Value) Then bln = False
            If Not datecheck(dtpchallan.Value) Then bln = False

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
            If gridchecking.RowCount > 0 Then ADDPOUT(TXTPOUTNO)
            Dim alParaval As New ArrayList

            alParaval.Add(grndate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(CMBWEAVER.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)
            alParaval.Add(CMBSENDER.Text.Trim)
            alParaval.Add(CMBTONAME.Text.Trim)
            alParaval.Add(TXTPOUTNO.Text.Trim)
            alParaval.Add(cmbprocess.Text.Trim)
            alParaval.Add(txtchallan.Text.Trim)
            alParaval.Add(Format(dtpchallan.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(Format(podate.Value.Date, "MM/dd/yyyy"))


            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(txttransremarks.Text.Trim)

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(TXTTOTALBALES.Text.Trim)
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim gridremarks As String = ""
            Dim QUALITY As String = ""
            Dim REED As String = ""
            Dim PICK As String = ""
            Dim COLOR As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim BALES As String = ""
            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim poNO As String = ""
            Dim pogridsrno As String = ""
            Dim ACCPCS As String = ""
            Dim ACCMTRS As String = ""
            Dim RETURNPCS As String = ""
            Dim CHECKDONE As String = ""
            Dim DONE As String = ""
            Dim OUTDONE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In gridgrn.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        REED = row.Cells(GREED.Index).Value.ToString
                        PICK = row.Cells(GPICK.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value
                        WT = row.Cells(GWT.Index).Value

                        If row.Cells(gpono.Index).Value <> Nothing Then
                            poNO = row.Cells(gpono.Index).Value
                        Else
                            poNO = "0"
                        End If

                        If row.Cells(gpogridsrno.Index).Value <> Nothing Then
                            pogridsrno = row.Cells(gpogridsrno.Index).Value
                        Else
                            pogridsrno = 0
                        End If
                        
                        ACCPCS = row.Cells(gAcceptedpcs.Index).Value
                        ACCMTRS = row.Cells(gAcceptedMtrs.Index).Value
                        RETURNPCS = row.Cells(greturnpcs.Index).Value
                        If row.Cells(GCHECKDONE.Index).Value = True Then
                            CHECKDONE = 1
                        Else
                            CHECKDONE = 0
                        End If
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        If row.Cells(GOUTDONE.Index).Value = True Then
                            OUTDONE = 1
                        Else
                            OUTDONE = 0
                        End If

                    Else

                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(gitemname.Index).Value
                        gridremarks = gridremarks & "," & row.Cells(gdesc.Index).Value.ToString
                        QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                        REED = REED & "," & row.Cells(GREED.Index).Value.ToString
                        PICK = PICK & "," & row.Cells(GPICK.Index).Value.ToString
                        COLOR = COLOR & "," & row.Cells(gcolor.Index).Value.ToString
                        qty = qty & "," & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "," & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "," & row.Cells(GMTRS.Index).Value
                        WT = WT & "," & row.Cells(GWT.Index).Value

                        If row.Cells(gpono.Index).Value <> Nothing Then
                            poNO = poNO & "," & row.Cells(gpono.Index).Value
                        Else
                            poNO = poNO & "," & " 0"
                        End If

                        If row.Cells(gpogridsrno.Index).Value <> Nothing Then
                            pogridsrno = pogridsrno & "," & Val(row.Cells(gpogridsrno.Index).Value)
                        Else
                            pogridsrno = pogridsrno & "," & " 0"
                        End If
                     
                        ACCPCS = ACCPCS & "," & row.Cells(gAcceptedpcs.Index).Value
                        ACCMTRS = ACCMTRS & "," & row.Cells(gAcceptedMtrs.Index).Value
                        RETURNPCS = RETURNPCS & "," & row.Cells(greturnpcs.Index).Value
                        If row.Cells(GCHECKDONE.Index).Value = True Then
                            CHECKDONE = CHECKDONE & "," & "1"
                        Else
                            CHECKDONE = CHECKDONE & "," & "0"
                        End If
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "," & "1"
                        Else
                            DONE = DONE & "," & "0"
                        End If
                        If row.Cells(GOUTDONE.Index).Value = True Then
                            OUTDONE = OUTDONE & "," & "1"
                        Else
                            OUTDONE = OUTDONE & "," & "0"
                        End If
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(gridremarks)
            alParaval.Add(QUALITY)
            alParaval.Add(REED)
            alParaval.Add(PICK)
            alParaval.Add(COLOR)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(poNO)
            alParaval.Add(pogridsrno)
            alParaval.Add(ACCPCS)
            alParaval.Add(ACCMTRS)
            alParaval.Add(RETURNPCS)
            alParaval.Add(CHECKDONE)
            alParaval.Add(DONE)
            alParaval.Add(OUTDONE)




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


            Dim CHECKSRNO As String = ""
            Dim LOTNO As String = ""
            Dim CHECKDATE As String = ""
            Dim CHECKPCS As String = ""
            Dim CHECKMTRS As String = ""
            Dim REJPCS As String = ""
            Dim REJMTRS As String = ""
            Dim SHORTAGEPCS As String = ""
            Dim SHORTAGEMTRS As String = ""
            Dim APPRPCS As String = ""
            Dim APPRMTRS As String = ""
            For Each row As Windows.Forms.DataGridViewRow In gridchecking.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CHECKSRNO = "" Then
                        CHECKSRNO = row.Cells(gchecksrno.Index).Value.ToString
                        LOTNO = row.Cells(glotno.Index).Value.ToString
                        CHECKDATE = Format(DateTime.Parse(row.Cells(gcheckDate.Index).Value, New System.Globalization.CultureInfo("en-CA").DateTimeFormat), "MM/dd/yyyy")
                        CHECKPCS = row.Cells(gRecpcs.Index).Value.ToString
                        CHECKMTRS = row.Cells(gRecMtrs.Index).Value.ToString
                        SHORTAGEPCS = row.Cells(gShortPcs.Index).Value.ToString
                        SHORTAGEMTRS = row.Cells(gShortMtrs.Index).Value.ToString
                        REJPCS = row.Cells(gRejectPcs.Index).Value.ToString
                        REJMTRS = row.Cells(gRejectMtrs.Index).Value.ToString
                        APPRPCS = row.Cells(gAppPcs.Index).Value
                        APPRMTRS = row.Cells(gAppMtrs.Index).Value


                    Else
                        CHECKSRNO = CHECKSRNO & "," & row.Cells(gchecksrno.Index).Value.ToString
                        LOTNO = LOTNO & "," & row.Cells(glotno.Index).Value.ToString
                        CHECKDATE = CHECKDATE & "," & Format(DateTime.Parse(row.Cells(gcheckDate.Index).Value, New System.Globalization.CultureInfo("en-CA").DateTimeFormat), "MM/dd/yyyy")
                        CHECKPCS = CHECKPCS & "," & row.Cells(gRecpcs.Index).Value.ToString
                        CHECKMTRS = CHECKMTRS & "," & row.Cells(gRecMtrs.Index).Value.ToString
                        SHORTAGEPCS = SHORTAGEPCS & "," & row.Cells(gShortPcs.Index).Value.ToString
                        SHORTAGEMTRS = SHORTAGEMTRS & "," & row.Cells(gShortMtrs.Index).Value.ToString
                        REJPCS = REJPCS & "," & row.Cells(gRejectPcs.Index).Value.ToString
                        REJMTRS = REJMTRS & "," & row.Cells(gRejectMtrs.Index).Value.ToString
                        APPRPCS = APPRPCS & "," & row.Cells(gAppPcs.Index).Value
                        APPRMTRS = APPRMTRS & "," & row.Cells(gAppMtrs.Index).Value

                    End If
                End If
            Next

            alParaval.Add(CHECKSRNO)
            alParaval.Add(LOTNO)
            alParaval.Add(CHECKDATE)
            alParaval.Add(CHECKPCS)
            alParaval.Add(CHECKMTRS)
            alParaval.Add(REJPCS)
            alParaval.Add(REJMTRS)
            alParaval.Add(SHORTAGEPCS)
            alParaval.Add(SHORTAGEMTRS)
            alParaval.Add(APPRPCS)
            alParaval.Add(APPRMTRS)

            Dim objclsGRN As New Clsli()
            objclsGRN.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsGRN.save()
                MsgBox("Details Added")
                txtgrnno.Text = DTTABLE.Rows(0).Item(0)
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(templino)

                IntResult = objclsGRN.Update()
                MsgBox("Details Updated")

            End If
            edit = False
            OUTedit = False


            TEMPMSG = MsgBox("Wish to Print GRN?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJGRN As New GRNDesign

                OBJGRN.MdiParent = MDIMain
                OBJGRN.selfor_GRN = "{LABOURINWARD.li_NO}=" & templino & "  and {LABOURINWARD.li_cmpid}=" & CmpId & " and {LABOURINWARD.li_locationid}=" & Locationid & " and {LABOURINWARD.li_yearid}=" & YearId
                OBJGRN.vendorname = cmbname.Text.Trim
                OBJGRN.Show()
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

    Private Sub LI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.KeyCode = Windows.Forms.Keys.F3 Then       'for Delete
            TabControl1.SelectedIndex = (2)
        ElseIf e.KeyCode = Windows.Forms.Keys.F4 Then       'for Delete
            TabControl1.SelectedIndex = (3)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
            ' Call cmdclear_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.P Then       'for COPY
            Call pbcopy_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub LI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub LI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'LABOUR PROCESS'")

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

                Dim objclsGRN As New Clsli()
                Dim dttable As New DataTable

                dttable = objclsGRN.selectLABOURINWARD(templino, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows


                        txtgrnno.Text = templino
                        grndate.Value = Format(Convert.ToDateTime(dr("GRNDATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        CMBTONAME.Text = Convert.ToString(dr("TONAME").ToString)
                        CMBWEAVER.Text = Convert.ToString(dr("WEAVER").ToString)
                        CMBBROKER.Text = Convert.ToString(dr("BROKER").ToString)
                        CMBSENDER.Text = Convert.ToString(dr("SENDER").ToString)
                        cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbprocess.Text = Convert.ToString(dr("PROCESS").ToString)
                        TXTPOUTNO.Text = dr("POUTNO").ToString
                        checkingDate.Value = Format(Convert.ToDateTime(dr("CHECKDATE")).Date, "dd/MM/yyyy")
                        txtchallan.Text = Convert.ToString(dr("CHALLANNO").ToString)

                        dtpchallan.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        txtpono.Text = Convert.ToString(dr("PONO").ToString)
                        podate.Value = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")


                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("transrefno").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txttransremarks.Text = dr("transremarks").ToString

                        TXTTOTALBALES.Text = Format(Val(dr("TOTALBALES")), "0.00")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        gridgrn.Rows.Add(dr("GRIDSRNO").ToString, dr("QUALITY").ToString, dr("ITEMNAME").ToString, dr("DESC").ToString, dr("REED").ToString, dr("PICK").ToString, dr("COLOR"), Format(dr("qty"), "0.00"), dr("QTYUNIT").ToString, Format(dr("MTRS"), "0.00"), Format(dr("WT"), "0.00"), Format(dr("ACCPCS"), "0.00"), Format(dr("ACCMTRS"), "0.00"), dr("GRIDPONO"), dr("GRIDPOSRNO"), dr("RETURNPCS"), dr("CHECKDONE").ToString, dr("GRIDDONE").ToString, dr("OUTDONE").ToString)


                     
                        If Convert.ToBoolean(dr("CHECKDONE")) = True Or Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            gridgrn.Rows(gridgrn.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    total()
                    validate()
                End If


                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" LI_GRIDSRNO AS GRIDSRNO, LI_REMARKS AS REMARKS, LI_NAME AS NAME, LI_IMGPATH AS IMGPATH, LI_NEWIMGPATH AS NEWIMGPATH", "", " LABOURINWARD_UPLOAD", " AND LI_NO = " & templino & " AND LI_CMPID = " & CmpId & " AND LI_LOCATIONID = " & Locationid & " AND LI_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If


                dttable = OBJCMN.search("      LI_GRIDSRNO AS GRIDSRNO, LI_LOTNO AS LOTNO, LI_CHECKDATE AS DATE, LI_CHECKPCS AS RECPCS, LI_CHECKMTRS AS RECMTRS, LI_REJPCS AS REJPCS, LI_REJMTRS AS REJMTRS, LI_SHORTPCS AS SHORTPCS, LI_SHORTMTRS AS SHORTMTRS, LI_APPROVEDPCS AS APPRPCS, LI_APPROVEDMTRS AS APPRMTRS ", "", "  LABOURINWARD_CHECKDESC", " AND LI_NO = " & templino & " AND LI_CMPID = " & CmpId & " AND LI_LOCATIONID = " & Locationid & " AND LI_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    OUTedit = True
                    For Each DTR As DataRow In dttable.Rows
                        gridchecking.Rows.Add(DTR("GRIDSRNO"), DTR("LOTNO"), Format(DTR("DATE"), "dd/MM/yyyy"), DTR("RECPCS"), Format(DTR("RECMTRS"), "0.00"), DTR("REJPCS"), Format(DTR("REJMTRS"), "0.00"), DTR("SHORTPCS"), Format(DTR("SHORTMTRS"), "0.00"), DTR("APPRPCS"), Format(DTR("APPRMTRS"), "0.00"))
                    Next
                End If
                If Val(TXTPOUTNO.Text) > 0 Then
                    dttable = OBJCMN.search("   PROCESSOUT_PRODESC.PO_GRIDSRNO AS GRIDSRNO, PROCESSOUT_PRODESC.PO_LOTNO AS LOTNO, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, COLORMASTER.COLOR_name AS COLOR, PROCESSOUT_PRODESC.PO_CUT AS CUT, PROCESSOUT_PRODESC.PO_PCS AS PCS, PROCESSOUT_PRODESC.PO_MTRS AS MTRS, PROCESSOUT_PRODESC.PO_OUTMTRS AS OUTMTRS, PROCESSOUT_PRODESC.PO_PROPONO AS PROPONO, PROCESSOUT_PRODESC.PO_PROPOSRNO AS PROPOSRNO ", "", "      PROCESSOUT_PRODESC LEFT OUTER JOIN COLORMASTER ON PROCESSOUT_PRODESC.PO_COLORID = COLORMASTER.COLOR_id AND PROCESSOUT_PRODESC.PO_CMPID = COLORMASTER.COLOR_cmpid AND PROCESSOUT_PRODESC.PO_LOCATIONID = COLORMASTER.COLOR_locationid AND PROCESSOUT_PRODESC.PO_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN QUALITYMASTER ON PROCESSOUT_PRODESC.PO_QUALITYID = QUALITYMASTER.QUALITY_id AND PROCESSOUT_PRODESC.PO_CMPID = QUALITYMASTER.QUALITY_cmpid AND PROCESSOUT_PRODESC.PO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PROCESSOUT_PRODESC.PO_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON PROCESSOUT_PRODESC.PO_ITEMID = ITEMMASTER.item_id AND PROCESSOUT_PRODESC.PO_CMPID = ITEMMASTER.item_cmpid AND PROCESSOUT_PRODESC.PO_LOCATIONID = ITEMMASTER.item_locationid AND PROCESSOUT_PRODESC.PO_YEARID = ITEMMASTER.item_yearid ", " AND PO_NO = " & Val(TXTPOUTNO.Text) & " AND PO_CMPID = " & CmpId & " AND PO_LOCATIONID = " & Locationid & " AND PO_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            GRIDPROGRAM.Rows.Add(DTR("GRIDSRNO"), DTR("lotno"), DTR("ITEMNAME"), DTR("QUALITY"), "", "", DTR("COLOR"), DTR("CUT"), DTR("PCS"), DTR("MTRS"), DTR("OUTMTRS"), DTR("PROPONO"), DTR("PROPOSRNO"))
                        Next
                    End If
                End If
                If txtpono.Text.Trim.Trim.Length = 0 Then
                    cmdselectPO.Enabled = False
                    cmbname.Enabled = True
                Else
                    cmdselectPO.Enabled = True
                    cmbname.Enabled = False
                End If

                chkchange.CheckState = CheckState.Checked
            End If

            If gridgrn.RowCount > 0 Then
                txtsrno.Text = Val(gridgrn.Rows(gridgrn.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
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
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            'If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, edit)
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, "", edit)

            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If FRMSTRING = "Inwards" Then
                fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            Else
                fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

            End If
            fillQUALITY(CMBQUALITY, edit)
            fillunit(cmbqtyunit)
            fillCOLOR(cmbcolor)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    'Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGodown.Enter
    '    Try
    '        If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, edit)
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
    '    Try
    '        If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub
    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objgrndetails As New GRNDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.FRMSTRING = FRMSTRING
            objgrndetails.Show()
            objgrndetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub CMBPROCESS_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocess.Enter
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, "", edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprocess.Validating
        Try
            'If cmbprocess.Text.Trim <> "" Then PROCESSVALIDATE(cmbprocess, e, Me)
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
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors")
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


    Private Sub dtpchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpchallan.Validating
        If Not datecheck(dtpchallan.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectPO.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            selectPOtable.Clear()
            Dim OBJSELECTPO As New SelectPO
            If edit = True Then OBJSELECTPO.PONO = Val(txtpono.Text.Trim)
            OBJSELECTPO.ShowDialog()


            Dim i As Integer = 0
            If selectPOtable.Rows.Count > 0 Then
                chkchange.Checked = True
                If edit = False Then gridgrn.RowCount = 0
                Dim POGRIDSRNO As String = ""
                Dim tempno As Integer = 0
                cmbname.Text = selectPOtable.Rows(0).Item("NAME")

                txtpono.Text = selectPOtable.Rows(0).Item("PONO")
                podate.Value = selectPOtable.Rows(0).Item("PODATE")
                CMBTONAME.Text = selectPOtable.Rows(0).Item("TONAME")

                For i = 0 To selectPOtable.Rows.Count - 1

                    gridgrn.Rows.Add(i + 1, selectPOtable.Rows(i).Item("QUALITY"), selectPOtable.Rows(i).Item("ITEMNAME"), selectPOtable.Rows(i).Item("DESC"), selectPOtable.Rows(i).Item("REED"), selectPOtable.Rows(i).Item("PICK"), selectPOtable.Rows(i).Item("COLOR"), Format(Val(selectPOtable.Rows(i).Item("QTY")), "0.00"), selectPOtable.Rows(i).Item("QTYUNIT"), 0, 0, selectPOtable.Rows(i).Item("PONO"), selectPOtable.Rows(i).Item("GRIDSRNO"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    If POGRIDSRNO = "" Then
                        POGRIDSRNO = selectPOtable.Rows(i).Item("GRIDSRNO")
                        tempno = selectPOtable.Rows(i).Item("GRIDSRNO")
                    Else
                        If tempno <> selectPOtable.Rows(i).Item("GRIDSRNO") Then
                            POGRIDSRNO = POGRIDSRNO & "," & selectPOtable.Rows(i).Item("GRIDSRNO")
                            tempno = selectPOtable.Rows(i).Item("GRIDSRNO")
                        End If
                    End If

                Next
                gridgrn.FirstDisplayedScrollingRowIndex = gridgrn.RowCount - 1
                'total()
                getsrno(gridgrn)
                cmbname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridgrn.RowCount = 0
            templino = Val(tstxtbillno.Text)
            If templino > 0 Then
                edit = True
                LI_Load(sender, e)
            Else
                clear()
                OUTedit = False
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridgrn.Enabled = True

        If gridDoubleClick = False Then
            gridgrn.Rows.Add(Val(txtsrno.Text.Trim), CMBQUALITY.Text.Trim, cmbitemname.Text.Trim, txtgridremarks.Text.Trim, Val(TXTREED.Text.Trim), Val(TXTPICK.Text.Trim), cmbcolor.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), 0, 0, 0, 0, 0, 0)
            getsrno(gridgrn)
        ElseIf gridDoubleClick = True Then
            gridgrn.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            gridgrn.Item(gitemname.Index, temprow).Value = cmbitemname.Text.Trim
            gridgrn.Item(gdesc.Index, temprow).Value = txtgridremarks.Text.Trim
            gridgrn.Item(GQUALITY.Index, temprow).Value = CMBQUALITY.Text.Trim
            gridgrn.Item(GREED.Index, temprow).Value = TXTREED.Text.Trim
            gridgrn.Item(GPICK.Index, temprow).Value = TXTPICK.Text.Trim

            gridgrn.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim
            gridgrn.Item(gQty.Index, temprow).Value = Format(Val(txtqty.Text.Trim), "0.00")
            gridgrn.Item(gqtyunit.Index, temprow).Value = cmbqtyunit.Text.Trim
            gridgrn.Item(GMTRS.Index, temprow).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            gridgrn.Item(GWT.Index, temprow).Value = Format(Val(TXTWT.Text.Trim), "0.00")

            gridDoubleClick = False
        End If

        total()

        gridgrn.FirstDisplayedScrollingRowIndex = gridgrn.RowCount - 1

        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        CMBQUALITY.Text = ""
        TXTREED.Clear()
        TXTPICK.Clear()
        cmbcolor.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        TXTWT.Clear()



        If gridgrn.RowCount > 0 Then
            txtsrno.Text = Val(gridgrn.Rows(gridgrn.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        txtsrno.Focus()

    End Sub
    Sub fillcheckgrid()

        gridchecking.Enabled = True

        If gridDoubleClick = False Then
            gridchecking.Rows.Add(Val(txtchecksrno.Text.Trim), TXTLOTNO.Text.Trim, Format(checkingDate.Value, "dd/MM/yyyy"), Val(txtpchkpcs.Text.Trim), Format(Val(txtpcheckmtrs.Text.Trim), "0.00"), Val(txtprejpcs.Text.Trim), Format(Val(txtprejmtrs.Text.Trim), "0.00"), Val(txtpshortpcs.Text.Trim), Format(Val(txtpshortmtrs.Text.Trim), "0.00"), Val(txtpApppcs.Text.Trim), Format(Val(txtpAppmtrs.Text.Trim), "0.00"))
            getsrno(gridchecking)
        ElseIf gridcheckdoubleclick = True Then
            gridchecking.Item(gRejectMtrs.Index, temprow).Value = Format(Val(txtprejmtrs.Text.Trim), "0.00")
            gridchecking.Item(gRejectPcs.Index, temprow).Value = txtprejpcs.Text.Trim
            gridchecking.Item(gShortPcs.Index, temprow).Value = txtpshortpcs.Text.Trim
            gridchecking.Item(gAppPcs.Index, temprow).Value = txtpApppcs.Text.Trim
            gridchecking.Item(glotno.Index, temprow).Value = TXTLOTNO.Text.Trim

            gridchecking.Item(gAppMtrs.Index, temprow).Value = Format(Val(txtpAppmtrs.Text.Trim), "0.00")
            gridchecking.Item(gShortMtrs.Index, temprow).Value = Format(Val(txtpshortmtrs.Text.Trim), "0.00")


            gridcheckdoubleclick = False
        End If

        total()

        gridchecking.FirstDisplayedScrollingRowIndex = gridchecking.RowCount - 1

        txtchecksrno.Clear()
        TXTLOTNO.Clear()
        txtpAppmtrs.Clear()
        txtpApppcs.Clear()
        txtpchkpcs.Clear()
        txtprejpcs.Clear()
        txtprejmtrs.Clear()
        txtpcheckmtrs.Clear()
        txtpshortmtrs.Clear()
        txtpshortpcs.Clear()
        



        If gridchecking.RowCount > 0 Then
            txtchecksrno.Text = Val(gridchecking.Rows(gridchecking.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        txtchecksrno.Focus()

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

            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                txtuploadsrno.Text = 1
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

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpeg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtgrnno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub cmbprocolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCOLOR.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPROCOLOR.Text.Trim = "" Then fillCOLOR(CMBPROCOLOR)


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbprocolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCOLOR.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPROCOLOR.Text.Trim <> "" Then COLORvalidate(CMBPROCOLOR, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
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

    Private Sub gridLI_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgrn.CellDoubleClick
        If e.RowIndex >= 0 And gridgrn.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            'If Convert.ToBoolean(gridgrn.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
            '    MsgBox("Item Locked. First Delete from Invoice")
            '    Exit Sub
            'End If

            'If Convert.ToBoolean(gridgrn.Rows(e.RowIndex).Cells(GCHECKDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
            '    MsgBox("Item Locked. First Delete from Checking")
            '    Exit Sub
            'End If


            gridDoubleClick = True
            txtsrno.Text = gridgrn.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = gridgrn.Item(gitemname.Index, e.RowIndex).Value.ToString
            txtgridremarks.Text = gridgrn.Item(gdesc.Index, e.RowIndex).Value.ToString
            CMBQUALITY.Text = gridgrn.Item(GQUALITY.Index, e.RowIndex).Value.ToString
            TXTREED.Text = gridgrn.Item(GREED.Index, e.RowIndex).Value.ToString
            TXTPICK.Text = gridgrn.Item(GPICK.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = gridgrn.Item(gcolor.Index, e.RowIndex).Value.ToString
            txtqty.Text = gridgrn.Item(gQty.Index, e.RowIndex).Value.ToString
            cmbqtyunit.Text = gridgrn.Item(gqtyunit.Index, e.RowIndex).Value.ToString
            TXTMTRS.Text = gridgrn.Item(GMTRS.Index, e.RowIndex).Value.ToString

            TXTWT.Text = gridgrn.Item(GWT.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            gridgrn.RowCount = 0


            templino = Val(txtgrnno.Text) - 1
            If templino > 0 Then
                edit = True
                LI_Load(sender, e)
            Else
                clear()
                OUTedit = False
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
            templino = Val(txtgrnno.Text) + 1

            getmaxno()
            clear()
            If Val(txtgrnno.Text) - 1 >= templino Then
                edit = True
                LI_Load(sender, e)
            Else
                clear()
                OUTedit = False
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdot(e, txtqty, Me)
    End Sub

    Private Sub txtTOTALBALES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTALBALES.KeyPress
        numdot(e, TXTTOTALBALES, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub podate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles podate.Validating
        If Not datecheck(podate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            Dim done As Boolean
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As New DataTable
                DTTABLE = getmax(" LI_done ", " LABOURINWARD_DESC", " and LI_no=" & txtgrnno.Text.Trim & " AND LI_cmpid=" & CmpId & " AND LI_LOCATIONID = " & Locationid & " AND LI_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then
                    done = DTTABLE.Rows(0).Item(0)
                End If
                If done = True Then
                    MsgBox("Checking Raised Delete Checking First", MsgBoxStyle.Critical)
                Else

                    TEMPMSG = MsgBox("Delete GRN?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(txtgrnno.Text.Trim)
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(YearId)

                        Dim Clsgrn As New Clsli()
                        Clsgrn.alParaval = alParaval
                        IntResult = Clsgrn.Delete()
                        MsgBox("GRN Deleted")
                        clear()
                        edit = False
                    End If
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.GotFocus
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbqtyunit.Validating
        Try
            If cmbqtyunit.Text.Trim <> "" Then unitvalidate(cmbqtyunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridLI_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridgrn.CellValidating
        Try
            Dim colNum As Integer = gridgrn.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GWT.Index, gQty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridgrn.CurrentCell.Value = Nothing Then gridgrn.CurrentCell.Value = "0.00"
                        gridgrn.CurrentCell.Value = Convert.ToDecimal(gridgrn.Item(colNum, e.RowIndex).Value)
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

    Private Sub gridLI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridgrn.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridgrn.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                gridgrn.Rows.RemoveAt(gridgrn.CurrentRow.Index)
                getsrno(gridgrn)
                total()

            End If
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
    Sub ADDPOUT(ByRef POOUT As TextBox)
        Dim alParaval As New ArrayList

        alParaval.Add(Format(grndate.Value.Date, "MM/dd/yyyy"))
        alParaval.Add(cmbname.Text.Trim)
        alParaval.Add(CMBTONAME.Text.Trim)
        alParaval.Add(cmbtrans.Text.Trim)
        alParaval.Add(txtlrno.Text.Trim)
        alParaval.Add(lrdate.Value)
        alParaval.Add(txttransref.Text.Trim)
        alParaval.Add(txttransremarks.Text.Trim)

        alParaval.Add(Val(lbltotalqty.Text))
        alParaval.Add(Val(LBLTOTALMTRS.Text))

        alParaval.Add(0)
        alParaval.Add(0)


        alParaval.Add(cmbprocess.Text.Trim)
        alParaval.Add(Format(grndate.Value.Date, "MM/dd/yyyy"))
        alParaval.Add(0)
        alParaval.Add(0)
        alParaval.Add(cmbGodown.Text.Trim)

        alParaval.Add(txtremarks.Text.Trim)
        alParaval.Add(1)
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
        Dim DYEINGNO As String = ""
        Dim DESIGNNO As String = ""
        Dim COLOR As String = ""
        Dim CUT As String = ""
        Dim APPRPCS As String = ""
        Dim APPRMTRS As String = ""
        Dim OUTPCS As String = ""
        Dim OUTMTRS As String = ""
        Dim FROMNO As String = ""
        Dim FROMSRNO As String = ""
        Dim FROMTYPE As String = ""
        Dim GRNNO As String = ""
        Dim GRNSRNO As String = ""




        For Each row As Windows.Forms.DataGridViewRow In gridchecking.Rows
            If row.Cells(0).Value <> Nothing Then
                If gridsrno = "" Then
                    gridsrno = row.Cells(gchecksrno.Index).Value.ToString
                    LOTNO = row.Cells(glotno.Index).Value.ToString

                    ITEMNAME = gridgrn.Rows(0).Cells(gitemname.Index).Value.ToString
                    QUALITY = gridgrn.Rows(0).Cells(GQUALITY.Index).Value.ToString
                    PROCESS = cmbprocess.Text

                    APPRPCS = row.Cells(gAppPcs.Index).Value
                    APPRMTRS = row.Cells(gAppMtrs.Index).Value

                    OUTPCS = 0
                    OUTMTRS = 0
                    FROMNO = txtgrnno.Text
                    FROMSRNO = 1
                    FROMTYPE = "LI"
                    GRNNO = txtgrnno.Text
                    GRNSRNO = 1

                Else

                    gridsrno = gridsrno & "," & row.Cells(gchecksrno.Index).Value
                    QUALITY = QUALITY & "," & gridgrn.Rows(0).Cells(GQUALITY.Index).Value.ToString
                    ITEMNAME = ITEMNAME & "," & gridgrn.Rows(0).Cells(gitemname.Index).Value.ToString
                    LOTNO = LOTNO & "," & row.Cells(glotno.Index).Value
                    PROCESS = PROCESS & "," & cmbprocess.Text

                    APPRPCS = APPRPCS & "," & row.Cells(gAppPcs.Index).Value
                    APPRMTRS = APPRMTRS & "," & row.Cells(gAppMtrs.Index).Value
                    OUTPCS = OUTPCS & "," & "0"
                    OUTMTRS = OUTMTRS & "," & "0"
                    FROMNO = FROMNO & "," & txtgrnno.Text
                    FROMSRNO = FROMSRNO & "," & "1"
                    FROMTYPE = FROMTYPE & "," & "LI"
                    GRNNO = GRNNO & "," & Val(txtgrnno.Text)
                    GRNSRNO = GRNSRNO & "," & "1"


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
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")
        alParaval.Add("")

        alParaval.Add(APPRPCS)
        alParaval.Add(APPRMTRS)
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


        Dim prosrno As String = ""

        Dim PROLOTNO As String = ""
        Dim PROMERCHANT As String = ""
        Dim PROQUALITY As String = ""

        Dim PROJOBNO As String = ""
        Dim PROGRIDLRNO As String = ""
        Dim PROCOLOR As String = ""
        Dim PROCUT As String = ""
        Dim PROSAREE As String = ""
        Dim PROMTRS As String = ""
        Dim PROOUTMTRS As String = ""
        Dim PROPONO As String = ""
        Dim PROPOSRNO As String = ""


        For Each row As Windows.Forms.DataGridViewRow In GRIDPROGRAM.Rows
            If row.Cells(0).Value <> Nothing Then
                If prosrno = "" Then
                    prosrno = row.Cells(GPROSRNO.Index).Value.ToString
                    PROLOTNO = row.Cells(gPROLOTNO.Index).Value.ToString
                    PROMERCHANT = row.Cells(GPROMERCHANT.Index).Value.ToString

                    PROMERCHANT = row.Cells(GPROMERCHANT.Index).Value.ToString
                    PROQUALITY = row.Cells(GPROQUALITY.Index).Value.ToString
                    PROCOLOR = row.Cells(GPROCOLOR.Index).Value.ToString
                    PROCUT = row.Cells(GPROCUT.Index).Value.ToString
                    PROSAREE = row.Cells(GPROSAREE.Index).Value.ToString
                    PROMTRS = row.Cells(GPROMTRS.Index).Value.ToString
                    PROOUTMTRS = row.Cells(GPROOUTMTRS.Index).Value.ToString
                    PROPONO = row.Cells(GPROPONO.Index).Value.ToString
                    PROPOSRNO = row.Cells(GPROPOSRNO.Index).Value.ToString



                Else

                    prosrno = prosrno & "," & row.Cells(GPROSRNO.Index).Value.ToString
                    PROLOTNO = PROLOTNO & "," & row.Cells(gPROLOTNO.Index).Value.ToString
                    PROMERCHANT = PROMERCHANT & "," & row.Cells(GPROMERCHANT.Index).Value.ToString

                    PROQUALITY = PROQUALITY & "," & row.Cells(GPROQUALITY.Index).Value.ToString

                    PROCOLOR = PROCOLOR & "," & row.Cells(GPROCOLOR.Index).Value.ToString
                    PROCUT = PROCUT & "," & row.Cells(GPROCUT.Index).Value.ToString
                    PROSAREE = PROSAREE & "," & row.Cells(GPROSAREE.Index).Value.ToString
                    PROMTRS = PROMTRS & "," & row.Cells(GPROMTRS.Index).Value.ToString
                    PROOUTMTRS = PROOUTMTRS & "," & row.Cells(GPROOUTMTRS.Index).Value.ToString
                    PROPONO = PROPONO & "," & row.Cells(GPROPONO.Index).Value.ToString
                    PROPOSRNO = PROPOSRNO & "," & row.Cells(GPROPOSRNO.Index).Value.ToString


                End If
            End If
        Next

        alParaval.Add(prosrno)
        alParaval.Add(PROLOTNO)
        alParaval.Add(PROMERCHANT)
        alParaval.Add(PROQUALITY)
        alParaval.Add(PROJOBNO)
        alParaval.Add(PROGRIDLRNO)
        alParaval.Add(PROCOLOR)
        alParaval.Add(PROCUT)
        alParaval.Add(PROSAREE)
        alParaval.Add(PROMTRS)
        alParaval.Add(PROOUTMTRS)
        alParaval.Add(PROPONO)
        alParaval.Add(PROPOSRNO)

        Dim objCLSPROCESSOUT As New ClsProcessOut()
        objCLSPROCESSOUT.alParaval = alParaval
        If OUTedit = False Then
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim DTTABLE As DataTable = objCLSPROCESSOUT.save()
            'MsgBox("Details Added")
            TXTPOUTNO.Text = DTTABLE.Rows(0).Item(0)

        Else
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            alParaval.Add(POOUT.Text)

            IntResult = objCLSPROCESSOUT.Update()


        End If


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

    Private Sub TXTREED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREED.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPICK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPICK.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBBROKER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBROKER.Enter
        Try
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKER.Validating
        Try
            If CMBBROKER.Text.Trim <> "" Then namevalidate(CMBBROKER, e, Me, TXTWEAVERADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress
        numdot(e, TXTMTRS, Me)
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdot(e, TXTWT, Me)
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
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMBTONAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTONAME.Enter
        Try
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTONAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTONAME.Validating
        Try
            If CMBTONAME.Text.Trim <> "" Then namevalidate(CMBTONAME, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTWT.Validated
        Try

            If Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            Throw ex
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

            If gridgrn.RowCount > 0 Then

                For Each ROW As DataGridViewRow In gridgrn.SelectedRows
                    txtsrno.Text = gridgrn.RowCount + 1
                    cmbitemname.Text = ROW.Cells(gitemname.Index).Value.ToString
                    txtgridremarks.Text = ROW.Cells(gdesc.Index).Value.ToString
                    CMBQUALITY.Text = ROW.Cells(GQUALITY.Index).Value.ToString
                    TXTREED.Text = ROW.Cells(GREED.Index).Value.ToString
                    TXTPICK.Text = ROW.Cells(GPICK.Index).Value.ToString
                    cmbcolor.Text = ROW.Cells(gcolor.Index).Value.ToString
                    txtqty.Text = ROW.Cells(gQty.Index).Value.ToString
                    cmbqtyunit.Text = ROW.Cells(gqtyunit.Index).Value.ToString
                    TXTMTRS.Text = ROW.Cells(GMTRS.Index).Value.ToString
                    TXTWT.Text = ROW.Cells(GWT.Index).Value.ToString

                    txtqty.Focus()
                Next

                'End If
            End If
        Catch ex As Exception
            Throw ex
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                Dim OBJGRN As New GRNDesign

                OBJGRN.MdiParent = MDIMain
                OBJGRN.selfor_GRN = "{LABOURINWARD.li_NO}=" & templino & "  and {LABOURINWARD.li_cmpid}=" & CmpId & " and {LABOURINWARD.li_locationid}=" & Locationid & " and {LABOURINWARD.li_yearid}=" & YearId
                OBJGRN.vendorname = cmbname.Text.Trim
                OBJGRN.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSENDER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSENDER.Enter
        Try
            If CMBSENDER.Text.Trim = "" Then fillname(CMBSENDER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSENDER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSENDER.Validating
        Try
            If CMBSENDER.Text.Trim <> "" Then namevalidate(CMBSENDER, e, Me, TXTWEAVERADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEAVER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBWEAVER.Enter
        Try
            If CMBWEAVER.Text.Trim = "" Then FILLWEAVER(CMBWEAVER, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEAVER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBWEAVER.Validating
        Try
            If CMBWEAVER.Text.Trim <> "" Then WEAVERvalidate(CMBWEAVER, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItemname.Enter
        Try
            cmbItemname.Text = "GREY MATERIAL"

            If cmbItemname.Text.Trim = "" Then fillitemname(cmbItemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")



        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbItemname.Validating
        Try
            If cmbItemname.Text.Trim <> "" And cmbItemname.Text.Trim <> "GREY MATERIAL" Then itemvalidate(cmbItemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub txtpchkpcs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpchkpcs.Validated
        Validate()
    End Sub
    Sub validate()
      
        txtpAppmtrs.Text = Format(Val(txtpcheckmtrs.Text) - Val(txtprejmtrs.Text) - Val(txtpshortmtrs.Text), "0.00")
        txtpApppcs.Text = Format(Val(txtpchkpcs.Text) - Val(txtprejpcs.Text) - Val(txtpshortpcs.Text), "0.00")
    End Sub

    Private Sub txtpcheckmtrs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpcheckmtrs.Validated
        validate()
    End Sub

    Private Sub txtprejpcs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprejpcs.Validated
        validate()
    End Sub

    Private Sub txtprejmtrs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprejmtrs.Validated
        validate()
    End Sub

    Private Sub txtpshortpcs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpshortpcs.Validated
        validate()
    End Sub

    Private Sub txtpshortmtrs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpshortmtrs.Validated
        validate()
    End Sub

    Private Sub txtpApppcs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpApppcs.Validated
        validate()
    End Sub

    Private Sub txtpAppmtrs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpAppmtrs.Validated
        Try
            validate()
            If Val(txtpAppmtrs.Text) <> 0 And Val(txtpApppcs.Text) <> 0 Then
                fillcheckgrid()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

  
   
    Private Sub gridchecking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridchecking.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridchecking.RowCount > 0 Then
                If gridcheckdoubleclick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                gridchecking.Rows.RemoveAt(gridchecking.CurrentRow.Index)
                getsrno(gridchecking)
                total()
                validate()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPROMTRS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPROMTRS.Validating
        Try
            If cmbitemname.Text.Trim <> "" And Val(txtproPCS.Text.Trim) > 0 Then
                fillprogrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillPROgrid()

        GRIDPROGRAM.Enabled = True

        If gridproDoubleClick = False Then
            GRIDPROGRAM.Rows.Add(Val(TXTPROSRNO.Text.Trim), CMBPROLOTNO.Text.Trim, cmbItemname.Text.Trim, gridgrn.Rows(gridgrn.CurrentRow.Index).Cells(GQUALITY.Index).Value, "", "", CMBPROCOLOR.Text.Trim, txtcutsize.Text, Format(Val(txtproPCS.Text.Trim), "0.00"), Format(Val(TXTPROMTRS.Text.Trim), "0.00"), 0, 0, 0)
            getsrno(GRIDPROGRAM)
        ElseIf gridproDoubleClick = True Then
            GRIDPROGRAM.Item(GPROSRNO.Index, temprow).Value = Val(TXTPROSRNO.Text.Trim)
            GRIDPROGRAM.Item(GPROMERCHANT.Index, temprow).Value = cmbItemname.Text.Trim

            GRIDPROGRAM.Item(GPROCOLOR.Index, temprow).Value = CMBPROCOLOR.Text.Trim
            GRIDPROGRAM.Item(GPROCUT.Index, temprow).Value = txtcutsize.Text.Trim
            GRIDPROGRAM.Item(GPROSAREE.Index, temprow).Value = Format(Val(txtproPCS.Text.Trim), "0.00")
            GRIDPROGRAM.Item(GPROMTRS.Index, temprow).Value = Format(Val(TXTPROMTRS.Text.Trim), "0.00")
            gridproDoubleClick = False
        End If
        total()
        GRIDPROGRAM.FirstDisplayedScrollingRowIndex = GRIDPROGRAM.RowCount - 1
        CMBPROLOTNO.Text = ""
        TXTPROSRNO.Clear()
        cmbItemname.Text = ""
        CMBPROCOLOR.Text = ""
        txtproPCS.Clear()
        txtcutsize.Clear()
        TXTPROMTRS.Clear()
        TXTPROSRNO.Focus()

        If GRIDPROGRAM.RowCount > 0 Then
            TXTPROSRNO.Text = Val(GRIDPROGRAM.Rows(GRIDPROGRAM.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTPROSRNO.Text = 1
        End If
    End Sub

    Private Sub gridchecking_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridchecking.CellDoubleClick
        If e.RowIndex >= 0 And gridchecking.Item(gchecksrno.Index, e.RowIndex).Value <> Nothing Then

        
            gridcheckdoubleclick = True
            txtchecksrno.Text = gridchecking.Item(gchecksrno.Index, e.RowIndex).Value.ToString
            txtpchkpcs.Text = gridchecking.Item(gRecpcs.Index, e.RowIndex).Value.ToString
            txtpcheckmtrs.Text = gridchecking.Item(gRecMtrs.Index, e.RowIndex).Value.ToString
            txtprejpcs.Text = gridchecking.Item(gRejectPcs.Index, e.RowIndex).Value.ToString
            txtprejmtrs.Text = gridchecking.Item(gRejectMtrs.Index, e.RowIndex).Value.ToString
            txtpshortmtrs.Text = gridchecking.Item(gShortMtrs.Index, e.RowIndex).Value.ToString
            txtpshortpcs.Text = gridchecking.Item(gShortPcs.Index, e.RowIndex).Value.ToString
            txtpApppcs.Text = gridchecking.Item(gAppPcs.Index, e.RowIndex).Value.ToString
            txtpAppmtrs.Text = gridchecking.Item(gAppMtrs.Index, e.RowIndex).Value.ToString

            tempcheckrow = e.RowIndex
            txtchecksrno.Focus()
        End If

    End Sub

    Private Sub GRIDPROGRAM_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPROGRAM.CellDoubleClick
        If e.RowIndex >= 0 And GRIDPROGRAM.Item(GPROSRNO.Index, e.RowIndex).Value <> Nothing Then


            gridproDoubleClick = True
            TXTPROSRNO.Text = gridchecking.Item(GPROSRNO.Index, e.RowIndex).Value.ToString
            CMBPROLOTNO.Text = gridchecking.Item(gPROLOTNO.Index, e.RowIndex).Value.ToString
            CMBPROCOLOR.Text = gridchecking.Item(GPROCOLOR.Index, e.RowIndex).Value.ToString
            txtcutsize.Text = gridchecking.Item(GPROCUT.Index, e.RowIndex).Value.ToString
            cmbItemname.Text = gridchecking.Item(GPROMERCHANT.Index, e.RowIndex).Value.ToString
            TXTPROMTRS.Text = gridchecking.Item(GPROMTRS.Index, e.RowIndex).Value.ToString
            txtproPCS.Text = gridchecking.Item(GPROSAREE.Index, e.RowIndex).Value.ToString

            tempprorow = e.RowIndex
            TXTPROSRNO.Focus()
        End If

    End Sub

   
End Class