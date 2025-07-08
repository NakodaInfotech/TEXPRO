Imports BL
Imports System.Windows.Forms
Imports System.IO
Public Class ProcessOut

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridproDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public temppono As Integer     'used for poation no while editing
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
        'cmbname.Enabled = True
        cmbname.Text = ""
        cmbtoname.Text = ""


        txtadd.Clear()
        POdate.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Mydate
        cmbprocess.Text = ""
        txtremarks.Clear()
        CMBLOTNO.Text = ""
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
        cmdgrn.Enabled = True
        'clearing itemgrid textboxes and combos

        gridpo.RowCount = 0
        GRIDPROGRAM.RowCount = 0
        gridupload.RowCount = 0
        chkdirectout.Checked = False
        Challandone.Checked = False
        CHKPROGRAM.Checked = False
        cmdselectJO.Enabled = True
        gridproDoubleClick = False
        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        getmaxno()

        TXTBALENO.Clear()
        CMBPIECETYPE.Text = ""
        cmbitemname.Text = ""

        cmbcolor.Text = ""
        txtcutsize.Clear()
        txtproPCS.Clear()
        TXTPROMTRS.Clear()


        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If


        If GRIDPROGRAM.RowCount > 0 Then
            TXTPROSRNO.Text = Val(GRIDPROGRAM.Rows(GRIDPROGRAM.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTPROSRNO.Text = 1
        End If
        If gridpo.RowCount > 0 Then
            TXTSRNO.Text = Val(gridpo.Rows(gridpo.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTSRNO.Text = 1
        End If

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0

            LBLTOTALPCS.Text = 0.0
            LBLTOTALMTRS.Text = 0

            LBLPROTOTALMTRS.Text = 0.0
            LBLPROTOTALPCS.Text = 0.0

            For Each ROW As DataGridViewRow In gridpo.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    If Val(ROW.Cells(GCUT.Index).EditedFormattedValue) > 0 Then ROW.Cells(GMTRS.Index).Value = Format(Val(ROW.Cells(GCUT.Index).EditedFormattedValue) * Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")

                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next
            For Each ROW As DataGridViewRow In GRIDPROGRAM.Rows
                If ROW.Cells(GPROSRNO.Index).Value <> Nothing Then
                    If Val(ROW.Cells(GPROCUT.Index).EditedFormattedValue) > 0 Then ROW.Cells(GPROMTRS.Index).Value = Format(Val(ROW.Cells(GPROCUT.Index).EditedFormattedValue) * Val(ROW.Cells(GPROSAREE.Index).EditedFormattedValue), "0.00")

                    LBLPROTOTALMTRS.Text = Format(Val(LBLPROTOTALMTRS.Text) + Val(ROW.Cells(GPROMTRS.Index).EditedFormattedValue), "0.00")
                    LBLPROTOTALPCS.Text = Format(Val(LBLPROTOTALPCS.Text) + Val(ROW.Cells(GPROSAREE.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbtoname.Focus()
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles POdate.Validating
        If Not datecheck(POdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PO_no),0) + 1 ", "PROCESSOUT", " AND PO_cmpid=" & CmpId & " and PO_locationid=" & Locationid & " and PO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtpono.Text = DTTABLE.Rows(0).Item(0)
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
            If cmbtoname.Text.Trim.Length = 0 Then
                EP.SetError(cmbtoname, " Please Fill Company Name ")
                bln = False
            End If


            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If

            If gridpo.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If
            If chkdirectout.Checked = True Then
                EP.SetError(TabControl1, "Direct Raised Change From GRN")
                bln = False
            End If

            If Not datecheck(POdate.Value) Then bln = False

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
            alParaval.Add(Format(POdate.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(cmbtoname.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add("")
            alParaval.Add("")

            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLPROTOTALPCS.Text))
            alParaval.Add(Val(LBLPROTOTALMTRS.Text))


            alParaval.Add(cmbprocess.Text.Trim)
            alParaval.Add(Format(recDAte.Value.Date, "MM/dd/yyyy"))

            If CHKPROGRAM.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)

            End If
            If Challandone.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)

            End If
            alParaval.Add(CMBGODOWN.Text.Trim)

            alParaval.Add(txtremarks.Text.Trim)
            If chkdirectout.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)

            End If
            
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
            Dim JOBNO As String = ""
            Dim GRIDLRNO As String = ""
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
            Dim GRNTYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In gridpo.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        PROCESS = row.Cells(gprocess.Index).Value.ToString
                        JOBNO = row.Cells(GJOBNO.Index).Value.ToString
                        GRIDLRNO = row.Cells(GLRNO.Index).Value.ToString
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
                        BALENO = BALENO & "," & row.Cells(GBALENO.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "," & row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                        PROCESS = PROCESS & "," & row.Cells(gprocess.Index).Value.ToString
                        JOBNO = JOBNO & "," & row.Cells(GJOBNO.Index).Value.ToString
                        GRIDLRNO = GRIDLRNO & "," & row.Cells(GLRNO.Index).Value.ToString
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
            alParaval.Add(JOBNO)
            alParaval.Add(GRIDLRNO)
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
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objCLSPROCESSOUT.save()

                txtpono.Text = DTTABLE.Rows(0).Item(0)

                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(temppono)

                IntResult = objCLSPROCESSOUT.Update()
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

    Private Sub cmbmerchant_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" And cmbmerchant.Text.Trim <> "GREY MATERIAL" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            'If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            'If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub PO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

                Dim objCLSPROCESSOUT As New ClsProcessOut()
                Dim dttable As New DataTable

                dttable = objCLSPROCESSOUT.selectPROCESSOUT(temppono, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        txtpono.Text = temppono
                        POdate.Value = Format(Convert.ToDateTime(dr("podate")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        cmbtoname.Text = Convert.ToString(dr("TONAME").ToString)



                        cmbprocess.Text = dr("PROCESS").ToString
                        CMBLOTNO.Text = dr("lotno").ToString
                        cmbtrans.Text = dr("TRANSNAME").ToString
                        CMBGODOWN.Text = dr("GODOWN").ToString

                        txtlrno.Text = dr("LRNO").ToString
                        txtadd.Text = dr("FROMADD").ToString
                        txtdeladd.Text = dr("TOADD").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        gridpo.Rows.Add(dr("GRIDSRNO").ToString, dr("LOTNO").ToString, dr("PIECETYPE").ToString, dr("BALENO").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("GRIDPROCESS").ToString, "", "", dr("COLOR").ToString, Format(dr("CUT"), "0.00"), Format(dr("PCS"), "0.00"), Format(dr("MTRS"), "0.00"), Format(dr("OUTPCS"), "0.00"), Format(dr("OUTMTRS"), "0.00"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), dr("GRNNO"), dr("GRNSRNO"))
                        If Convert.ToBoolean(dr("directout")) = True Then
                            gridpo.Rows(gridpo.RowCount - 1).ReadOnly = True

                            gridpo.Rows(gridpo.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            chkdirectout.Checked = True
                        End If
                        If Convert.ToBoolean(dr("CHALLAN")) = True Then
                            Challandone.Checked = True
                        Else
                            Challandone.Checked = False
                        End If

                        If Convert.ToBoolean(dr("PROGRAM")) = True Then
                            CHKPROGRAM.Checked = True
                        Else
                            CHKPROGRAM.Checked = False
                        End If
                        If Convert.ToDecimal(dr("OUTMTRS")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                End If


                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" PO_GRIDSRNO AS GRIDSRNO, PO_REMARKS AS REMARKS, PO_NAME AS NAME, PO_IMGPATH AS IMGPATH, PO_NEWIMGPATH AS NEWIMGPATH", "", " PROCESSOUT_UPLOAD", " AND PO_NO = " & temppono & " AND PO_CMPID = " & CmpId & " AND PO_LOCATIONID = " & Locationid & " AND PO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If

                dttable = OBJCMN.search("   PROCESSOUT_PRODESC.PO_GRIDSRNO AS GRIDSRNO, PROCESSOUT_PRODESC.PO_LOTNO AS LOTNO, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, COLORMASTER.COLOR_name AS COLOR, PROCESSOUT_PRODESC.PO_CUT AS CUT, PROCESSOUT_PRODESC.PO_PCS AS PCS, PROCESSOUT_PRODESC.PO_MTRS AS MTRS, PROCESSOUT_PRODESC.PO_OUTMTRS AS OUTMTRS, PROCESSOUT_PRODESC.PO_PROPONO AS PROPONO, PROCESSOUT_PRODESC.PO_PROPOSRNO AS PROPOSRNO ", "", "      PROCESSOUT_PRODESC LEFT OUTER JOIN COLORMASTER ON PROCESSOUT_PRODESC.PO_COLORID = COLORMASTER.COLOR_id AND PROCESSOUT_PRODESC.PO_CMPID = COLORMASTER.COLOR_cmpid AND PROCESSOUT_PRODESC.PO_LOCATIONID = COLORMASTER.COLOR_locationid AND PROCESSOUT_PRODESC.PO_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN QUALITYMASTER ON PROCESSOUT_PRODESC.PO_QUALITYID = QUALITYMASTER.QUALITY_id AND PROCESSOUT_PRODESC.PO_CMPID = QUALITYMASTER.QUALITY_cmpid AND PROCESSOUT_PRODESC.PO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PROCESSOUT_PRODESC.PO_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON PROCESSOUT_PRODESC.PO_ITEMID = ITEMMASTER.item_id AND PROCESSOUT_PRODESC.PO_CMPID = ITEMMASTER.item_cmpid AND PROCESSOUT_PRODESC.PO_LOCATIONID = ITEMMASTER.item_locationid AND PROCESSOUT_PRODESC.PO_YEARID = ITEMMASTER.item_yearid ", " AND PO_NO = " & temppono & " AND PO_CMPID = " & CmpId & " AND PO_LOCATIONID = " & Locationid & " AND PO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDPROGRAM.Rows.Add(DTR("GRIDSRNO"), DTR("lotno"), DTR("ITEMNAME"), DTR("QUALITY"), "", "", DTR("COLOR"), DTR("CUT"), DTR("PCS"), DTR("MTRS"), DTR("OUTMTRS"), DTR("PROPONO"), DTR("PROPOSRNO"))
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
            If cmbtoname.Text.Trim = "" Then fillname(cmbtoname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            'If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

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

            Dim objgrndetails As New ProcessOutDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
            objgrndetails.BringToFront()
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


    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectJO.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            selectpotable.Clear()
            Dim OBJSELECTPO As New SelectInward
            OBJSELECTPO.FRMSTRING = "PROCESSOUT"

            OBJSELECTPO.ShowDialog()

            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable

            Dim i As Integer = 0
            If selectpotable.Rows.Count > 0 Then
                cmdselectJO.Enabled = False
                chkchange.Checked = True
                If edit = False Then gridpo.RowCount = 0
                For i = 0 To selectpotable.Rows.Count - 1
                    cmbname.Text = selectpotable.Rows(i).Item("NAME")

                    gridpo.Rows.Add(i + 1, selectpotable.Rows(i).Item("LOTNO"), selectpotable.Rows(i).Item("PIECETYPE"), selectpotable.Rows(i).Item("BALENO"), selectpotable.Rows(i).Item("ITEMNAME"), selectpotable.Rows(i).Item("QUALITY"), selectpotable.Rows(i).Item("PROCESS"), selectpotable.Rows(i).Item("JOBNO"), selectpotable.Rows(i).Item("LRNO"), selectpotable.Rows(i).Item("COLOR"), selectpotable.Rows(i).Item("CUT"), Format(Val(selectpotable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectpotable.Rows(i).Item("MTRS")), "0.00"), 0, 0, Val(selectpotable.Rows(i).Item("FROMNO")), Val(selectpotable.Rows(i).Item("FROMSRNO")), selectpotable.Rows(i).Item("FROMTYPE"), Val(selectpotable.Rows(i).Item("GRNNO")), Val(selectpotable.Rows(i).Item("GRNSRNO")))

                Next
                gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1
                getsrno(gridpo)
                cmbname.Focus()
            End If
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridpo.RowCount = 0
            temppono = Val(tstxtbillno.Text)
            If temppono > 0 Then
                edit = True
                PO_Load(sender, e)
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtpono.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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
            gridpo.RowCount = 0

            temppono = Val(txtpono.Text) - 1
            If temppono > 0 Then
                edit = True
                PO_Load(sender, e)
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
            temppono = Val(txtpono.Text) + 1
            getmaxno()
            clear()
            If Val(txtpono.Text) - 1 >= temppono Then
                edit = True
                PO_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPROGRAM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPROGRAM.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDPROGRAM.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
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
            If cmbname.Text.Trim <> "" Then
                Dim objCLSprocessin As New ClsCommon()
                Dim dttable As New DataTable
                dttable = objCLSprocessin.search(" DISTINCT PROCESSOUT_DESC.PO_LOTNO  ", "", "       PROCESSOUT INNER JOIN LEDGERS ON PROCESSOUT.PO_TOledgerid = LEDGERS.Acc_id AND PROCESSOUT.PO_cmpid = LEDGERS.Acc_cmpid AND PROCESSOUT.PO_locationid = LEDGERS.Acc_locationid AND PROCESSOUT.PO_yearid = LEDGERS.Acc_yearid INNER JOIN PROCESSOUT_DESC ON PROCESSOUT.PO_cmpid = PROCESSOUT_DESC.PO_CMPID AND PROCESSOUT.PO_locationid = PROCESSOUT_DESC.PO_LOCATIONID AND PROCESSOUT.PO_yearid = PROCESSOUT_DESC.PO_YEARID ", " AND ACC_CMPNAME='" & cmbname.Text & "'  AND PROCESSOUT_DESC.PO_CMPID = " & CmpId & " AND PROCESSOUT_DESC.PO_LOCATIONID = " & Locationid & " AND (PROCESSOUT_DESC.PO_MTRS-PROCESSOUT_DESC.PO_OUTMTRS) >0 AND PROCESSOUT_DESC.PO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For I As Integer = 0 To dttable.Rows.Count - 1
                        CMBLOTNO.Items.Add(dttable.Rows(I).Item(0))
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbTOname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtoname.Enter
        Try
            If cmbtoname.Text.Trim = "" Then fillname(cmbtoname, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbTOname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtoname.Validating
        Try
            If cmbtoname.Text.Trim <> "" Then namevalidate(cmbtoname, e, Me, txtdeladd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
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

    Private Sub cmdgrn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgrn.Click
        'Try

        '    If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
        '        MsgBox("Insufficient Rights")
        '        Exit Sub
        '    End If


        '    selectpotable.Clear()
        '    Dim OBJSELECTPO As New SelectInward
        '    OBJSELECTPO.FRMSTRING = "INWARD"
        '    OBJSELECTPO.ShowDialog()


        '    Dim i As Integer = 0
        '    If selectpotable.Rows.Count > 0 Then
        '        chkchange.Checked = True
        '        cmdgrn.Enabled = False
        '        If edit = False Then gridpo.RowCount = 0
        '        For i = 0 To selectpotable.Rows.Count - 1
        '            cmbname.Text = selectpotable.Rows(i).Item("NAME")
        '            txtadd.Text = selectpotable.Rows(i).Item("ADDRESS")
        '            gridpo.Rows.Add(i + 1, selectpotable.Rows(i).Item("ITEMNAME"), "", selectpotable.Rows(i).Item("QUALITY"), Format(Val(selectpotable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectpotable.Rows(i).Item("MTRS")), "0.00"), Format(Val(selectpotable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectpotable.Rows(i).Item("MTRS")), "0.00"), 0, 0, 0, 0, Val(selectpotable.Rows(i).Item("LINO")), Val(selectpotable.Rows(i).Item("LIGRIDSRNO")), 0, 0, 0)
        '        Next
        '        gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1
        '        getsrno(gridpo)
        '        cmbname.Focus()
        '    End If
        '    total()

        'Catch ex As Exception
        '    Throw ex
        'End Try
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

    Private Sub GRIDPROGRAM_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPROGRAM.CellValidating
        Try
            Dim colNum As Integer = GRIDPROGRAM.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GPCS.Index
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
            If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        Try
            If cmbitemname.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillgrid()

        gridpo.Enabled = True

        If gridDoubleClick = False Then
            gridpo.Rows.Add(Val(TXTSRNO.Text.Trim), CMBLOTNO.Text.Trim, CMBPIECETYPE.Text.Trim, TXTBALENO.Text.Trim, cmbitemname.Text.Trim, TXTQUALITY.Text.Trim, txtprocess.Text.Trim, TXTJOBNO.Text.Trim, TXTGRIDLRNO.Text.Trim, cmbcolor.Text.Trim, txtcut.Text, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), 0, 0, Val(txtfromno.Text), Val(txtfromsrno.Text), txtfromtype.Text.Trim, Val(txtgrnno.Text), Val(txtgrnsrno.Text), txtgrntype.Text)
            getsrno(gridpo)
        ElseIf gridDoubleClick = True Then
            gridpo.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            gridpo.Item(GPIECETYPE.Index, temprow).Value = CMBPIECETYPE.Text.Trim
            gridpo.Item(GMERCHANT.Index, temprow).Value = cmbitemname.Text.Trim
            gridpo.Item(GJOBNO.Index, temprow).Value = TXTJOBNO.Text.Trim
            gridpo.Item(GBALENO.Index, temprow).Value = TXTBALENO.Text.Trim
            gridpo.Item(GLRNO.Index, temprow).Value = TXTGRIDLRNO.Text.Trim
            gridpo.Item(GCOLOR.Index, temprow).Value = cmbcolor.Text.Trim
            gridpo.Item(GCUT.Index, temprow).Value = txtcut.Text.Trim
            gridpo.Item(GPCS.Index, temprow).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
            gridpo.Item(GMTRS.Index, temprow).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            gridDoubleClick = False
        End If
        total()
        gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1

        TXTSRNO.Clear()
        cmbitemname.Text = ""
        TXTBALENO.Clear()
        cmbcolor.Text = ""
        TXTPCS.Clear()
        txtcutsize.Clear()
        TXTMTRS.Clear()
        TXTSRNO.Focus()

    End Sub
    Sub fillPROgrid()

        GRIDPROGRAM.Enabled = True

        If gridproDoubleClick = False Then
            GRIDPROGRAM.Rows.Add(Val(TXTPROSRNO.Text.Trim), CMBPROLOTNO.Text.Trim, cmbmerchant.Text.Trim, TXTPROQUALITY.Text.Trim, "", "", CMBPROCOLOR.Text.Trim, txtcutsize.Text, Format(Val(txtproPCS.Text.Trim), "0.00"), Format(Val(TXTPROMTRS.Text.Trim), "0.00"), 0, 0, 0)
            getsrno(GRIDPROGRAM)
        ElseIf gridproDoubleClick = True Then
            GRIDPROGRAM.Item(GPROSRNO.Index, temprow).Value = Val(TXTPROSRNO.Text.Trim)
            GRIDPROGRAM.Item(GPROMERCHANT.Index, temprow).Value = cmbmerchant.Text.Trim

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
        cmbmerchant.Text = ""
        CMBPROCOLOR.Text = ""
        txtproPCS.Clear()
        txtcutsize.Clear()
        TXTPROMTRS.Clear()
        TXTPROSRNO.Focus()

    End Sub
    Private Sub GRIDPO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpo.CellDoubleClick
        If e.RowIndex >= 0 And gridpo.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToDecimal(gridpo.Rows(e.RowIndex).Cells(GOUTMTRS.Index).Value) > 0 Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from GRN")
                Exit Sub
            End If


            gridproDoubleClick = True
            TXTSRNO.Text = gridpo.Item(GSRNO.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = gridpo.Item(GMERCHANT.Index, e.RowIndex).Value.ToString
            CMBPIECETYPE.Text = gridpo.Item(GPIECETYPE.Index, e.RowIndex).Value.ToString
            TXTBALENO.Text = gridpo.Item(GBALENO.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = gridpo.Item(GCOLOR.Index, e.RowIndex).Value.ToString
            txtcut.Text = gridpo.Item(GCUT.Index, e.RowIndex).Value.ToString
            TXTPCS.Text = gridpo.Item(GPCS.Index, e.RowIndex).Value.ToString
            TXTMTRS.Text = gridpo.Item(GMTRS.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            TXTSRNO.Focus()
        End If
    End Sub

    Private Sub GRIDPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpo.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridpo.RowCount > 0 Then

                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                gridpo.Rows.RemoveAt(gridpo.CurrentRow.Index)
                getsrno(gridpo)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub GRIDPO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridpo.CellValidating
        Try
            Dim colNum As Integer = gridpo.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPCS.Index, GMTRS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridpo.CurrentCell.Value = Nothing Then gridpo.CurrentCell.Value = "0.00"
                        gridpo.CurrentCell.Value = Convert.ToDecimal(gridpo.Item(colNum, e.RowIndex).Value)
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



    Private Sub TXTSRNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSRNO.Enter
        If gridDoubleClick = False Then

            If gridpo.RowCount > 0 Then
                TXTSRNO.Text = Val(gridpo.Rows(gridpo.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If

    End Sub




    Private Sub CMBLOTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOTNO.Validating
        Try
            If CMBLOTNO.Text.Trim <> "" Then
                Dim objCLSprocessin As New ClsCommon()
                Dim dttable As New DataTable
                Dim MTRS As Double
                For Each ROW As DataGridViewRow In gridpo.Rows
                    If ROW.Cells(GLOTNO.Index).Value = CMBLOTNO.Text Then

                        MTRS = MTRS + ROW.Cells(GMTRS.Index).Value
                    End If
                Next
                dttable = objCLSprocessin.search("  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(PROCESSOUT_DESC.PO_NO, 0) AS FROMNO, ISNULL(PROCESSOUT_DESC.PO_GRIDSRNO, 0) AS FROMSRNO, 'OUT' AS FROMTYPE, ISNULL(PROCESSOUT_DESC.PO_GRNNO, 0) AS GRNNO, ISNULL(PROCESSOUT_DESC.PO_GRNSRNO, 0) AS GRNSRNO, ISNULL(PROCESSOUT_DESC.PO_GRNTYPE, '') AS GRNTYPE, ITEMMASTER.item_name AS ITEMNAME ", "", "       PROCESSOUT INNER JOIN LEDGERS ON PROCESSOUT.PO_TOledgerid = LEDGERS.Acc_id AND PROCESSOUT.PO_cmpid = LEDGERS.Acc_cmpid AND PROCESSOUT.PO_locationid = LEDGERS.Acc_locationid AND PROCESSOUT.PO_yearid = LEDGERS.Acc_yearid INNER JOIN PROCESSOUT_DESC ON PROCESSOUT.PO_cmpid = PROCESSOUT_DESC.PO_CMPID AND PROCESSOUT.PO_locationid = PROCESSOUT_DESC.PO_LOCATIONID AND PROCESSOUT.PO_yearid = PROCESSOUT_DESC.PO_YEARID INNER JOIN QUALITYMASTER ON PROCESSOUT_DESC.PO_QUALITYID = QUALITYMASTER.QUALITY_id AND PROCESSOUT_DESC.PO_CMPID = QUALITYMASTER.QUALITY_cmpid AND PROCESSOUT_DESC.PO_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PROCESSOUT_DESC.PO_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON PROCESSOUT_DESC.PO_ITEMID = ITEMMASTER.item_id AND PROCESSOUT_DESC.PO_CMPID = ITEMMASTER.item_cmpid AND PROCESSOUT_DESC.PO_LOCATIONID = ITEMMASTER.item_locationid AND PROCESSOUT_DESC.PO_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON PROCESSOUT.PO_PROCESSID = PROCESSMASTER.PROCESS_ID AND PROCESSOUT.PO_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESSOUT.PO_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESSOUT.PO_yearid = PROCESSMASTER.PROCESS_YEARID", " AND (PROCESSOUT_DESC.PO_MTRS-PROCESSOUT_DESC.PO_OUTMTRS)>0 AND ACC_CMPNAME='" & cmbname.Text & "' AND PROCESSOUT_DESC.PO_LOTNO = '" & CMBLOTNO.Text & "' AND PROCESSOUT_DESC.PO_CMPID = " & CmpId & " AND PROCESSOUT_DESC.PO_LOCATIONID = " & Locationid & " AND PROCESSOUT_DESC.PO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For i As Integer = 0 To dttable.Rows.Count - 1
                        txtprocess.Text = dttable.Rows(i).Item("PROCESS")
                        txtfromno.Text = dttable.Rows(i).Item("FROMNO")
                        txtfromsrno.Text = dttable.Rows(i).Item("FROMSRNO")
                        txtfromtype.Text = dttable.Rows(i).Item("FROMTYPE")
                        cmbitemname.Text = dttable.Rows(i).Item("ITEMNAME")
                        TXTQUALITY.Text = dttable.Rows(i).Item("QUALITY")

                        cmbitemname.Enabled = False
                        txtgrnno.Text = dttable.Rows(i).Item("GRNNO")
                        txtgrnsrno.Text = dttable.Rows(i).Item("GRNSRNO")
                        txtgrntype.Text = dttable.Rows(i).Item("GRNTYPE")
                    Next i
                Else
                    MsgBox("Lot No and Party Does Not match")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then printreport(temppono)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub printreport(ByVal pono As Integer)

    End Sub

    Private Sub TXTPCS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPCS.Validating
        If Val(TXTPCS.Text) > 0 Then
            TXTMTRS.Text = Format(Val(TXTPCS.Text) * Val(txtcut.Text), "0.00")
        End If
    End Sub

    Private Sub TXTPROMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPROMTRS.Validated
        Try
            If cmbmerchant.Text.Trim <> "" And Val(txtproPCS.Text.Trim) > 0 Then
                fillPROgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class