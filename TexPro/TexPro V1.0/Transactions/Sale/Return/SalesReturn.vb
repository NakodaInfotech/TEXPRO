
Imports System.Windows.Forms
Imports System.IO
Imports BL

Public Class SalesReturn

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public TEMPRETURNNO As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        EP.Clear()
        cmbname.Enabled = True
        cmbname.Text = ""
        tstxtbillno.Clear()
        txtadd.Clear()
        RETURNDATE.Value = Mydate
        txtchallanno.Clear()
        TXTEWAYBILLNO.Clear()

        CMBTRANS.Text = ""
        TXTLRNO.Clear()
        LRDATE.Value = Mydate
        txttransref.Clear()
        TXTTRANSREMARKS.Clear()
        txtremarks.Clear()
        cmbcity.Text = ""
        lbltotalpcs.Text = "0.00"
        lbltotalmtrs.Text = "0.00"
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
        CMBTRANS.Text = ""

        'clearing itemgrid textboxes and combos
        txtsrno.Clear()
        cmbpiecetype.Text = ""
        TXTDESC.Clear()
        cmbmerchant.Text = ""
        txtwidth.Clear()
        txtcut.Clear()
        cmbdesign.Text = ""
        cmbcolor.Text = ""
        txtpcs.Clear()
        txtwt.Clear()
        txtmtrs.Clear()
        GRIDRETURN.RowCount = 0

        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        getmaxno()

        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If

    End Sub

    Sub TOTAL()
        Try
            lbltotalpcs.Text = 0.0
            lbltotalmtrs.Text = 0.0
            If GRIDRETURN.RowCount > 0 Then
                For Each ROW As DataGridViewRow In GRIDRETURN.Rows
                    If ROW.Cells(gsrno.Index).Value <> Nothing Then
                        lbltotalpcs.Text = Format(Val(lbltotalpcs.Text) + Val(ROW.Cells(gpcs.Index).Value), "0.00")
                        lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(ROW.Cells(GMTRS.Index).Value), "0.00")
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            edit = False
            cmbname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RETURNDATE.Validating
        If Not datecheck(RETURNDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SALE_NO),0) + 1 ", "SALERETURN", " AND SALE_cmpid=" & CmpId & " and SALE_locationid=" & Locationid & " and SALE_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTSALERETURNNO.Text = DTTABLE.Rows(0).Item(0)
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

            For Each row As DataGridViewRow In GRIDRETURN.Rows
                If row.Cells(GMTRS.Index).Value = 0 Then
                    EP.SetError(lbltotalmtrs, "Mtrs cannot be zero?")
                    bln = False
                End If

                'If row.Cells(gpiecetype.Index).Value = 0 Then
                '    EP.SetError(cmbname, "Piece Type cannot be blank")
                '    bln = False
                'End If

                'If row.Cells(GMERCHANT.Index).Value = 0 Then
                '    EP.SetError(cmbname, "Merchant cannot be blank")
                '    bln = False
                'End If

            Next

            If GRIDRETURN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If Not datecheck(RETURNDATE.Value) Then bln = False

            'If Convert.ToDateTime(RETURNDATE.Text).Date >= "01/02/2018" Then
            '    If Val(txtgrandtotal.Text.Trim) > 50000 And TXTEWAYBILLNO.Text.Trim = "" Then
            '        If MsgBox("Eway Bill No Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '            bln = False
            '        End If
            '    End If
            'End If

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

            alParaval.Add(RETURNDATE.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(txtchallanno.Text.Trim)
            alParaval.Add(Challandate.Value)

            alParaval.Add(TXTEWAYBILLNO.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(TXTLRNO.Text.Trim)
            alParaval.Add(LRDATE.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(TXTTRANSREMARKS.Text.Trim)

            alParaval.Add(Val(lbltotalpcs.Text))
            alParaval.Add(Val(lbltotalmtrs.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim DESC As String = ""
            Dim MERCHANT As String = ""
            Dim WIDTH As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim WT As String = ""
            Dim MTRS As String = ""
            Dim GRIDDONE As String = ""             'WHETHER GDN IS DONE FOR THIS LINE
            Dim OUTPCS As String = ""             'WHETHER GDN IS DONE FOR THIS LINE
            Dim OUTMTRS As String = ""             'WHETHER GDN IS DONE FOR THIS LINE
            Dim GRIDCHALLANNO As String = ""          'WHETHER GDN IS DONE FOR THIS LINE
            Dim GRIDCHSRNO As String = ""          'WHETHER GDN IS DONE FOR THIS LINE

            For Each row As Windows.Forms.DataGridViewRow In GRIDRETURN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(gpiecetype.Index).Value.ToString
                        DESC = row.Cells(gdesc.Index).Value.ToString
                        MERCHANT = row.Cells(GMERCHANT.Index).Value.ToString
                        WIDTH = row.Cells(gwidth.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        PCS = row.Cells(gpcs.Index).Value.ToString
                        WT = row.Cells(gwt.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = 1
                        Else
                            GRIDDONE = 0
                        End If

                        OUTPCS = Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)
                        GRIDCHALLANNO = row.Cells(GCHALLANNO.Index).Value.ToString
                        GRIDCHSRNO = row.Cells(GCHALLANSRNO.Index).Value.ToString
                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "," & row.Cells(gpiecetype.Index).Value
                        DESC = DESC & "," & row.Cells(gdesc.Index).Value
                        MERCHANT = MERCHANT & "," & row.Cells(GMERCHANT.Index).Value
                        WIDTH = WIDTH & "," & row.Cells(gwidth.Index).Value.ToString
                        CUT = CUT & "," & row.Cells(GCUT.Index).Value.ToString
                        DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "," & row.Cells(gcolor.Index).Value.ToString
                        PCS = PCS & "," & row.Cells(gpcs.Index).Value.ToString
                        WT = WT & "," & row.Cells(gwt.Index).Value.ToString
                        MTRS = MTRS & "," & row.Cells(GMTRS.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = GRIDDONE & "," & "1"
                        Else
                            GRIDDONE = GRIDDONE & "," & "0"
                        End If

                        OUTPCS = OUTPCS & "," & Val(row.Cells(GOUTPCS.Index).Value)
                        OUTMTRS = OUTMTRS & "," & Val(row.Cells(GOUTMTRS.Index).Value)
                        GRIDCHALLANNO = GRIDCHALLANNO & "," & row.Cells(GCHALLANNO.Index).Value.ToString
                        GRIDCHSRNO = GRIDCHSRNO & "," & row.Cells(GCHALLANSRNO.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(DESC)
            alParaval.Add(MERCHANT)
            alParaval.Add(WIDTH)
            alParaval.Add(CUT)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(WT)
            alParaval.Add(MTRS)
            alParaval.Add(GRIDDONE)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)
            alParaval.Add(GRIDCHALLANNO)
            alParaval.Add(GRIDCHSRNO)

            Dim griduploadsrno As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim imgpath As String = ""
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

            Dim objclsSaleReturn As New ClsSaleReturn
            objclsSaleREturn.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsSaleREturn.save()
                MsgBox("Details Added")
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPRETURNNO)
                IntResult = objclsSaleReturn.Update()
                MsgBox("Details Updated")
            End If
            edit = False
            TEMPMSG = MsgBox("Wish to Print Sale Return?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If edit = True Then
                    PRINTREPORT(TEMPRETURNNO)
                Else
                    PRINTREPORT(TXTSALERETURNNO.Text.Trim)
                End If
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

    Private Sub SaleReturn(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
                Call CMDSELECT_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub SaleReturn(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress, MyBase.KeyDown
    '    If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    'End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
            If cmbcity.Text.Trim = "" Then fillcity(cmbcity)
            fillDESIGN(cmbdesign, cmbmerchant.Text)
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
            Dim OBJRETURNDTLS As New SaleReturnDetail
            OBJRETURNDTLS.MdiParent = MDIMain
            OBJRETURNDTLS.Show()
            OBJRETURNDTLS.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
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

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmdupload.Click
        Try
            GRIDRETURN.RowCount = 0
            TEMPRETURNNO = Val(tstxtbillno.Text)
            If TEMPRETURNNO > 0 Then
                edit = True
                SaleReturn_Load(sender, e)
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTSALERETURNNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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
            GRIDRETURN.RowCount = 0

            TEMPRETURNNO = Val(TXTSALERETURNNO.Text) - 1
            If TEMPRETURNNO > 0 Then
                edit = True
                SaleReturn_Load(sender, e)
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
            TEMPRETURNNO = Val(TXTSALERETURNNO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTSALERETURNNO.Text) - 1 >= TEMPRETURNNO Then
                edit = True
                SaleReturn_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDRETURN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRETURN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDRETURN.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If Val(GRIDRETURN.Item(GOUTMTRS.Index, GRIDRETURN.CurrentRow.Index).Value) > 0 Then
                    MsgBox("You Cannot Delete This Row, Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                GRIDRETURN.Rows.RemoveAt(GRIDRETURN.CurrentRow.Index)
                getsrno(GRIDRETURN)
                TOTAL()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')", "SUNDRY DEBTORS")
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

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmtrs.Validated
        Try
            If cmbpiecetype.Text.Trim <> "" And cmbmerchant.Text.Trim <> "" And Val(txtpcs.Text.Trim) > 0 And Val(txtmtrs.Text.Trim) > 0 Then
                fillgrid()
                TOTAL()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        GRIDRETURN.Enabled = True
        If gridDoubleClick = True Then
            GRIDRETURN.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDRETURN.Item(gpiecetype.Index, temprow).Value = cmbpiecetype.Text.Trim
            GRIDRETURN.Item(gdesc.Index, temprow).Value = TXTDESC.Text.Trim
            GRIDRETURN.Item(GMERCHANT.Index, temprow).Value = cmbmerchant.Text.Trim
            GRIDRETURN.Item(gwidth.Index, temprow).Value = txtwidth.Text.Trim
            GRIDRETURN.Item(GCUT.Index, temprow).Value = txtcut.Text.Trim
            GRIDRETURN.Item(GDESIGN.Index, temprow).Value = cmbdesign.Text.Trim
            GRIDRETURN.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim
            GRIDRETURN.Item(gpcs.Index, temprow).Value = Format(Val(txtpcs.Text.Trim), "0.00")
            GRIDRETURN.Item(gwt.Index, temprow).Value = Format(Val(txtwt.Text.Trim), "0.00")
            GRIDRETURN.Item(GMTRS.Index, temprow).Value = Format(Val(txtmtrs.Text.Trim), "0.00")

            gridDoubleClick = False
        Else
            GRIDRETURN.Rows.Add(0, cmbpiecetype.Text.Trim, TXTDESC.Text.Trim, cmbmerchant.Text.Trim, Format(Val(txtwidth.Text.Trim), "0.00"), Format(Val(txtcut.Text.Trim), "0.00"), cmbdesign.Text.Trim, cmbcolor.Text.Trim, Format(Val(txtpcs.Text.Trim), "0.00"), Format(Val(txtwt.Text.Trim), "0.00"), Format(Val(txtmtrs.Text.Trim), "0.00"), 0, 0, 0, 0, 0)
            getsrno(GRIDRETURN)
        End If

        GRIDRETURN.FirstDisplayedScrollingRowIndex = GRIDRETURN.RowCount - 1

        txtsrno.Clear()
        getsrno(GRIDRETURN)
        cmbcolor.Text = ""
        cmbdesign.Text = ""
        txtpcs.Clear()
        txtmtrs.Clear()
        txtwt.Clear()

        If GRIDRETURN.RowCount > 0 Then
            txtsrno.Text = Val(GRIDRETURN.Rows(GRIDRETURN.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        txtsrno.Focus()
    End Sub

    Private Sub GRIDRETURN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRETURN.CellDoubleClick
        If e.RowIndex >= 0 And GRIDRETURN.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Val(GRIDRETURN.Item(GOUTMTRS.Index, e.RowIndex).Value) > 0 Then
                MsgBox("Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            gridDoubleClick = True
            txtsrno.Text = GRIDRETURN.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbpiecetype.Text = GRIDRETURN.Item(gpiecetype.Index, e.RowIndex).Value.ToString
            TXTDESC.Text = GRIDRETURN.Item(gdesc.Index, e.RowIndex).Value.ToString
            cmbmerchant.Text = GRIDRETURN.Item(GMERCHANT.Index, e.RowIndex).Value.ToString
            txtwidth.Text = GRIDRETURN.Item(gwidth.Index, e.RowIndex).Value.ToString
            txtcut.Text = GRIDRETURN.Item(GCUT.Index, e.RowIndex).Value.ToString
            cmbdesign.Text = GRIDRETURN.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = GRIDRETURN.Item(gcolor.Index, e.RowIndex).Value.ToString
            txtpcs.Text = GRIDRETURN.Item(gpcs.Index, e.RowIndex).Value.ToString
            txtwt.Text = GRIDRETURN.Item(gwt.Index, e.RowIndex).Value.ToString
            txtmtrs.Text = GRIDRETURN.Item(GMTRS.Index, e.RowIndex).Value.ToString
            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT')", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesign.GotFocus
        Try
            If cmbdesign.Text.Trim = "" Then fillDESIGN(cmbdesign, cmbmerchant.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesign.Validating
        Try
            If cmbdesign.Text.Trim <> "" Then DESIGNvalidate(cmbdesign, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDRETURN_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDRETURN.CellValidating
        Try
            Dim colNum As Integer = GRIDRETURN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gpcs.Index, GCUT.Index, GMTRS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDRETURN.CurrentCell.Value = Nothing Then GRIDRETURN.CurrentCell.Value = "0.00"
                        GRIDRETURN.CurrentCell.Value = Convert.ToDecimal(GRIDRETURN.Item(colNum, e.RowIndex).Value)

                        TOTAL()
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

    Private Sub CMDSELECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECT.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If cmbname.Text = "" Then
                MsgBox("Select Party Name First ")
                cmbname.Focus()
                Exit Sub
            End If


            Dim DT As New DataTable
            Dim OBJSELECTGDN As New SelectGdnReturn
            OBJSELECTGDN.Cmpname = cmbname.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DT = OBJSELECTGDN.DT1

            Dim i As Integer = 0

            If DT.Rows.Count > 0 Then
                chkchange.Checked = True
                For Each DTROW As DataRow In DT.Rows
                    GRIDRETURN.Rows.Add(0, DTROW("PIECETYPE"), "", DTROW("MERCHANT"), 0.0, DTROW("CUT"), "", "", DTROW("PCS"), Format(Val(DTROW("WT")), "0.00"), Format(Val(DTROW("MTRS")), "0.00"), 0, 0, 0, DTROW("GDNNO"), DTROW("GDNGRIDSRNO"))
                    Challandate.Text = Format(Convert.ToDateTime(DTROW("GDNDATE")).Date, "dd/MM/yyyy")
                Next
                Dim DV As DataView = DT.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "GDNNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If txtchallanno.Text.Trim = "" Then
                        txtchallanno.Text = DTR("GDNNO").ToString
                    Else
                        txtchallanno.Text = txtchallanno.Text & "," & DTR("GDNNO").ToString
                    End If
                Next
                getsrno(GRIDRETURN)
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbpiecetype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpiecetype.GotFocus
        Try
            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbpiecetype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpiecetype.Validating
        Try
            If cmbpiecetype.Text.Trim <> "" Then PIECETYPEvalidate(cmbpiecetype, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            If Val(txtcut.Text.Trim) > 0 And Val(txtpcs.Text.Trim) > 0 Then txtmtrs.Text = Format(Val(txtcut.Text.Trim) * Val(txtpcs.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpcs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpcs.Validating
        CALC()
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDRETURN.RowCount = 0
            TEMPRETURNNO = Val(tstxtbillno.Text)
            If TEMPRETURNNO > 0 Then
                edit = True
                SaleReturn_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click

        Try
            If edit = True Then PRINTREPORT(TEMPRETURNNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

        'Try
        '    'If edit = True Then
        '    '    Dim OBJGRN As New fspdesign
        '    '    If GRIDFPS.Rows(0).Cells(gpiecetype.Index).Value = "GOOD CUT" Then
        '    '        OBJGRN.goodcut = True
        '    '    End If
        '    '    OBJGRN.MdiParent = MDIMain
        '    '    OBJGRN.selformula = "{finalpackingslip.fps_NO}=" & TEMPRETURNNO & " and {finalpackingslip.fps_cmpid}=" & CmpId & " and {finalpackingslip.fps_locationid}=" & Locationid & " and {finalpackingslip.fps_yearid}=" & YearId
        '    '    OBJGRN.HEADER = CHKHEADER.Checked
        '    '    OBJGRN.Show()
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Sub PRINTREPORT(ByVal SALENO As Integer)
        Try
            'Dim TEMPMSG As Integer = MsgBox("Print Sale Return Invoice?", MsgBoxStyle.YesNo)
            'If TEMPMSG = vbYes Then
            Dim OBJGDN As New GDNDESIGN
            OBJGDN.MdiParent = MDIMain
            OBJGDN.FRMSTRING = "SALERETURN"
            OBJGDN.FORMULA = "{SALERETURN.SALE_no}=" & Val(SALENO) & " and {SALERETURN.SALE_cmpid}=" & CmpId & " and {SALERETURN.SALE_locationid}=" & Locationid & " and {SALERETURN.SALE_yearid}=" & YearId
            OBJGDN.Show()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub txtcut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcut.Validated
        CALC()
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub SaleReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE RETURN'")
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

                Dim OBJCHECKING As New ClsSaleReturn()
                Dim ALPARAVAL As New ArrayList
                Dim dttable As New DataTable

                ALPARAVAL.Add(TEMPRETURNNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCHECKING.alParaval = ALPARAVAL

                dttable = OBJCHECKING.SELECTRETURN()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSALERETURNNO.Text = TEMPRETURNNO
                        RETURNDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)

                        txtchallanno.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        Challandate.Value = Format(Convert.ToDateTime(dr("CHALLANDATE").DATE), "dd/MM/yyyy")

                        TXTEWAYBILLNO.Text = Convert.ToString(dr("EWAYBILLNO"))
                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        cmbcity.Text = dr("CITY").ToString
                        txttransref.Text = dr("transrefno").ToString
                        TXTLRNO.Text = dr("LRNO").ToString
                        LRDATE.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        TXTTRANSREMARKS.Text = dr("transremarks").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        GRIDRETURN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("DESC").ToString, dr("MERCHANT"), Format(Val(dr("WIDTH")), "0.00"), Format(Val(dr("CUT")), "0.00"), dr("DESIGNNO"), dr("COLOR"), Format(Val(dr("PCS")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), dr("GRIDDONE").ToString, Val(dr("OUTPCS")), Val(dr("OUTMTRS")), dr("GRIDCHALLANNO"), dr("GRIDCHSRNO"))
                        If Convert.ToBoolean(dr("GRIDDONE")) = True Or Val(dr("OUTMTRS")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    TOTAL()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" SALE_GRIDSRNO AS GRIDSRNO, SALE_REMARKS AS REMARKS, SALE_NAME AS NAME, SALE_IMGPATH AS IMGPATH, SALE_NEWIMGPATH AS NEWIMGPATH", "", " SALERETURN_UPLOAD", " AND SALE_NO = " & TEMPRETURNNO & " AND SALE_CMPID = " & CmpId & " AND SALE_LOCATIONID = " & Locationid & " AND SALE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If

                chkchange.CheckState = CheckState.Checked
            End If

            If GRIDRETURN.RowCount > 0 Then
                txtsrno.Text = Val(GRIDRETURN.Rows(GRIDRETURN.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
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
                    MsgBox("Return Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Delete Sale Return?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTSALERETURNNO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)

                    Dim ObjSaleRet As New ClsSaleReturn()
                    ObjSaleRet.alParaval = alParaval
                    IntResult = ObjSaleRet.Delete()
                    MsgBox("Packing Deleted")
                    clear()
                    edit = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class