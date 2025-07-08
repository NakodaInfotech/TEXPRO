
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class PurchaseQuotation

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim PARTYQUOT As String      'used for refno while edit mode
    Public edit As Boolean      'used for editing
    Public tempquotationno As Integer   'used for quotation no while editing
    Dim temprow As Integer
    Public tempMsg As Integer
    Public Shared selectPRtable As New System.Data.DataTable

    Sub clear()

        tstxtbillno.Clear()
        cmbname.Text = ""
        txtadd.Clear()
        txtquotation.Clear()
        quotationdate.Value = Mydate
        dtppartyref.Value = Mydate
        dtvalidtill.Value = Mydate
        txtPRNO.Clear()
        txtref.Clear()
        pbsoftcopy.ImageLocation = ""
        txtimgpath.Clear()

        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        TXTREED.Clear()
        TXTPICK.Clear()
        CMBQUALITY.Text = ""
        cmbcolor.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        txtrate.Clear()
        txtamount.Clear()

        txtremarks.Clear()
        lbltotalamt.Text = 0.0
        lbltotalqty.Text = 0.0
        gridQuotation.RowCount = 0

        txtPRNO.Enabled = True

        getmaxno()
        lbllocked.Visible = False
        PBlock.Visible = False
        EP.Clear()
        gridDoubleClick = False

        If gridQuotation.RowCount > 0 Then
            txtsrno.Text = Val(gridQuotation.Rows(gridQuotation.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbname.Focus()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.pdf;*.doc;*.JPEG;*.JPG)|*.pdf;*.doc;*.jpeg;*.jpg"
        OpenFileDialog1.ShowDialog()

        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            pbsoftcopy.ImageLocation = txtimgpath.Text.Trim
            pbsoftcopy.Load(txtimgpath.Text.Trim)

            'code to upload image on server (now just copy file locally)
            'Dim clsRequest As System.Net.FtpWebRequest = _
            '             DirectCast(System.Net.WebRequest.Create("ftp://ftp.hemindnet00.web705.discountasp.net/WO/" & txtsono.Text), System.Net.FtpWebRequest)
            'clsRequest.Credentials = New System.Net.NetworkCredential("0094814|hemindnet00", "infosys123")
            'clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            '' read in file...
            ''Dim bFile() As Byte = System.IO.File.ReadAllBytes(gridupload.Rows(0).Cells(3).Value)
            'Dim bFile() As Byte = System.IO.File.ReadAllBytes(txtimgpath.Text.Trim)
            '' upload file...
            'Dim clsStream As System.IO.Stream = _
            '    clsRequest.GetRequestStream()
            'clsStream.Write(bFile, 0, bFile.Length)
            'clsStream.Close()
            'clsStream.Dispose()

            If System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Uploaded Files\") = False Then
                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory & "\Uploaded Files")
            End If

            If System.IO.File.Exists(txtimgpath.Text.Trim) = True Then
                Dim EXTENSION As String = Path.GetExtension(txtimgpath.Text.Trim)
                If EXTENSION <> ".pdf" Then
                    System.IO.File.Copy(txtimgpath.Text.Trim, System.AppDomain.CurrentDomain.BaseDirectory & "Uploaded Files\PQUOT-" & txtquotation.Text.Trim & EXTENSION, True)
                    MsgBox("File Uploaded Successfully", MsgBoxStyle.OkOnly, "Tex Pro")
                Else
                    pbsoftcopy.Load(System.AppDomain.CurrentDomain.BaseDirectory & "PDF.jpg")
                End If
            End If

        End If
    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        pbsoftcopy.ImageLocation = ""
        txtimgpath.Clear()
    End Sub

    Private Sub quotationdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles quotationdate.Validating
        If Not datecheck(quotationdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtref_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtref.Validating
        Try

            If txtref.Text.Trim.Length > 0 Then
                If (edit = False) Or (edit = True And LCase(PARTYQUOT) <> LCase(txtref.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As New System.Data.DataTable
                    dt = objclscommon.search(" PURCHASEQUOTATION.Quotation_PARTYQUOTNO, LEDGERS.ACC_cmpname", "", "  dbo.PURCHASEQUOTATION INNER JOIN  dbo.LEDGERS ON dbo.LEDGERS.ACC_id = dbo.PURCHASEQUOTATION.quotation_ledgerid AND dbo.PURCHASEQUOTATION.quotation_cmpid = dbo.LEDGERS.ACC_cmpid AND dbo.PURCHASEQUOTATION.quotation_yearid = dbo.LEDGERS.ACC_yearid AND dbo.PURCHASEQUOTATION.quotation_locationid = dbo.LEDGERS.ACC_locationid   ", " and PURCHASEQUOTATION.quotation_PARTYQUOTno = '" & txtref.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' and dbo.PURCHASEQUOTATION.quotation_cmpid=" & CmpId & " and dbo.PURCHASEQUOTATION.quotation_locationid=" & Locationid & " and dbo.PURCHASEQUOTATION.quotation_yearid=" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Party Quotation No. Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Sub total()

        If gridQuotation.RowCount > 0 Then
            lbltotalqty.Text = "0.00"
            lbltotalamt.Text = "0.00"

            For Each row As DataGridViewRow In gridQuotation.Rows
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).Value), "0.00")
                lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(gamt.Index).Value), "0.00")
            Next
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(gsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            gridQuotation.Enabled = True

            If gridDoubleClick = False Then
                gridQuotation.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, txtgridremarks.Text.Trim, CMBQUALITY.Text.Trim, Val(TXTREED.Text.Trim), Val(TXTPICK.Text.Trim), cmbcolor.Text.Trim, Val(txtqty.Text.Trim), cmbqtyunit.Text.Trim, Val(txtrate.Text.Trim), Val(txtamount.Text.Trim), 0, 0, 0, 0)
                getsrno(gridQuotation)
            ElseIf gridDoubleClick = True Then

                gridQuotation.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
                gridQuotation.Item(gitemname.Index, temprow).Value = cmbitemname.Text.Trim
                gridQuotation.Item(gdesc.Index, temprow).Value = txtgridremarks.Text.Trim
                gridQuotation.Item(GQUALITY.Index, temprow).Value = CMBQUALITY.Text.Trim
                gridQuotation.Item(GREED.Index, temprow).Value = TXTREED.Text.Trim
                gridQuotation.Item(GPICK.Index, temprow).Value = TXTPICK.Text.Trim
                gridQuotation.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim
                gridQuotation.Item(gQty.Index, temprow).Value = Val(txtqty.Text.Trim)
                gridQuotation.Item(gqtyunit.Index, temprow).Value = cmbqtyunit.Text.Trim
                gridQuotation.Item(grate.Index, temprow).Value = Val(txtrate.Text.Trim)
                gridQuotation.Item(gamt.Index, temprow).Value = Val(txtamount.Text.Trim)

                gridDoubleClick = False

            End If
            total()
            gridQuotation.FirstDisplayedScrollingRowIndex = gridQuotation.RowCount - 1

            txtsrno.Clear()
            cmbitemname.Text = ""
            txtgridremarks.Clear()
            CMBQUALITY.Text = ""
            TXTREED.Clear()
            TXTPICK.Clear()
            cmbcolor.Text = ""
            txtqty.Clear()
            cmbqtyunit.Text = ""
            txtrate.Clear()
            txtamount.Clear()
            txtsrno.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridQuotation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridQuotation.CellDoubleClick
        If e.RowIndex >= 0 And gridQuotation.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(gridQuotation.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from GRN")
                Exit Sub
            End If


            gridDoubleClick = True
            txtsrno.Text = gridQuotation.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = gridQuotation.Item(gitemname.Index, e.RowIndex).Value.ToString
            txtgridremarks.Text = gridQuotation.Item(gdesc.Index, e.RowIndex).Value.ToString
            CMBQUALITY.Text = gridQuotation.Item(GQUALITY.Index, e.RowIndex).Value.ToString
            TXTREED.Text = gridQuotation.Item(GREED.Index, e.RowIndex).Value.ToString
            TXTPICK.Text = gridQuotation.Item(GPICK.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = gridQuotation.Item(gcolor.Index, e.RowIndex).Value.ToString
            txtqty.Text = gridQuotation.Item(gQty.Index, e.RowIndex).Value.ToString
            cmbqtyunit.Text = gridQuotation.Item(gqtyunit.Index, e.RowIndex).Value.ToString
            txtrate.Text = gridQuotation.Item(grate.Index, e.RowIndex).Value.ToString
            txtamount.Text = gridQuotation.Item(gamt.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            txtsrno.Focus()
        End If

    End Sub

    Private Sub gridorders_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridQuotation.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = gridQuotation.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, gQty.Index, gamt.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridQuotation.CurrentCell.Value = Nothing Then gridQuotation.CurrentCell.Value = "0.00"
                    gridQuotation.CurrentCell.Value = Convert.ToDecimal(gridQuotation.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    gridQuotation.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridQuotation.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridQuotation.Rows(e.RowIndex).Cells(gQty.Index).EditedFormattedValue), "0.00")
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                total()

        End Select
    End Sub

    Private Sub gridQUOTATION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridQuotation.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridQuotation.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridQuotation.Rows.RemoveAt(gridQuotation.CurrentRow.Index)
                total()
                getsrno(gridQuotation)
                total()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_NAME = 'Sundry Creditors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbname.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " and GROUPMASTER.GROUP_NAME = 'Sundry Creditors'", "Sundry Creditors")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqty.Validated
        Try
            If Val(txtqty.Text) > 0 And Val(txtrate.Text) > 0 Then txtamount.Text = Val(txtqty.Text) * Val(txtrate.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If gridQuotation.RowCount > 0 Then
                txtsrno.Text = Val(gridQuotation.Rows(gridQuotation.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsrno.KeyPress
        If AscW(e.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
            e.KeyChar = ""
        End If
    End Sub

    Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, "Select Name")
            bln = False
        End If

        'If txtref.Text.Trim.Length = 0 Then
        '    EP.SetError(txtref, "Fill Party Quot No")
        '    bln = False
        'End If

        If gridQuotation.RowCount = 0 Then
            EP.SetError(txtamount, "Enter Item Details")
            bln = False
        End If

        For Each row As DataGridViewRow In gridQuotation.Rows
            If row.Cells(gqtyunit.Index).Value.ToString = "" Then
                EP.SetError(txtamount, "Unit Cannot be Blank")
                bln = False
            End If

            If Val(row.Cells(gQty.Index).Value) = 0 Then
                EP.SetError(txtamount, "Qty Cannot be 0")
                bln = False
            End If

            If Val(row.Cells(grate.Index).Value) = 0 Then
                EP.SetError(txtamount, "Rate Cannot be 0")
                bln = False
            End If

            If Val(row.Cells(gamt.Index).Value) = 0 Then
                EP.SetError(txtamount, "Amount Cannot be 0")
                bln = False
            End If

        Next

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "PO Raised, Delete PO First")
            bln = False
        End If

        'If chkchange.CheckState = CheckState.Unchecked Then
        '    EP.SetError(txtamount, "Enter Item Details")
        '    bln = False
        'End If

        If Not datecheck(dtppartyref.Value) Then bln = False
        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(quotationdate.Value)
            alParaval.Add(txtPRNO.Text.Trim)
            alParaval.Add(txtref.Text.Trim)
            alParaval.Add(dtppartyref.Value)
            alParaval.Add(dtvalidtill.Value)

            Dim imagepath As String
            imagepath = pbsoftcopy.ImageLocation
            If imagepath = Nothing Then imagepath = ""

            alParaval.Add(imagepath)
            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(lbltotalamt.Text))
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
            Dim rate As String = ""
            Dim amount As String = ""
            Dim recdqty As String = ""      'Qty recd in GRN
            Dim DONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRIDPRNO As String = "" 'value of prno variable we r capuuring it internally for to take number of PR of each line item of grid
            Dim prgridsrno As String = "" 'value of prgridsrno variable we r capuuring it internally for to take number of PR of each line item of grid

            For Each row As System.Windows.Forms.DataGridViewRow In gridQuotation.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
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
                        rate = row.Cells(grate.Index).Value
                        amount = row.Cells(gamt.Index).Value
                        recdqty = row.Cells(grecdqty.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        GRIDPRNO = row.Cells(GPRNO.Index).Value
                        prgridsrno = row.Cells(gprgridsrno.Index).Value

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
                        rate = rate & "," & row.Cells(grate.Index).Value
                        amount = amount & "," & row.Cells(gamt.Index).Value
                        recdqty = recdqty & "," & row.Cells(grecdqty.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "," & 1
                        Else
                            DONE = DONE & "," & 0
                        End If

                        GRIDPRNO = GRIDPRNO & "," & Val(row.Cells(GPRNO.Index).Value)
                        prgridsrno = prgridsrno & "," & Val(row.Cells(gprgridsrno.Index).Value)

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
            alParaval.Add(rate)
            alParaval.Add(amount)
            alParaval.Add(recdqty)
            alParaval.Add(DONE)
            alParaval.Add(GRIDPRNO)
            alParaval.Add(prgridsrno)

            Dim objclsPurQuo As New ClsPurchaseQuotation()
            objclsPurQuo.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTNEW As DataTable = objclsPurQuo.save()
                MsgBox("Details Added")
                PRINTREPORT(DTNEW.Rows(0).Item(0))

            ElseIf edit = True Then
                alParaval.Add(tempquotationno)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsPurQuo.Update()
                MsgBox("Details Updated")
                PRINTREPORT(tempquotationno)
            End If
            edit = False

            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub PurchaseQuotation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = System.Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = System.Windows.Forms.Keys.X) Or (e.KeyCode = System.Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = System.Windows.Forms.Keys.D Then       'for Delete
            Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PurchaseQuotation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub PurchaseQuotation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE QUOTATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            quotationdate.Value = Mydate
            getmaxno()
            lbllocked.Visible = False
            PBlock.Visible = False
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, "")
            fillunit(cmbqtyunit)


            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim CLSCMN As New ClsPurchaseQuotation()
                Dim dttable As New System.Data.DataTable
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(tempquotationno)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                CLSCMN.alParaval = ALPARAVAL
                dttable = CLSCMN.selectquotation()

                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        txtquotation.Text = Val(tempquotationno)
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        quotationdate.Value = Convert.ToDateTime(dr("DATE"))
                        txtPRNO.Text = Convert.ToString(dr("PRNO"))
                        txtPRNO.Enabled = False

                        txtref.Text = Convert.ToString(dr("PARTYQUOTNO"))
                        PARTYQUOT = txtref.Text.Trim
                        dtppartyref.Value = Convert.ToDateTime(dr("PARTYQUOTDATE"))
                        dtvalidtill.Value = Convert.ToDateTime(dr("VALIDTILL"))
                        pbsoftcopy.ImageLocation = Convert.ToString(dr("IMGPATH"))
                        txtimgpath.Text = Convert.ToString(dr("IMGPATH"))

                        If pbsoftcopy.ImageLocation <> "" Then pbsoftcopy.Load(txtimgpath.Text.Trim)

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))

                        gridQuotation.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("DESC").ToString, dr("QUALITY").ToString, dr("REED").ToString, dr("PICK").ToString, dr("COLOR").ToString, Format(dr("QTY"), "0.00"), dr("QTYUNIT").ToString, Format(dr("RATE"), "0.00"), Format(dr("AMT"), "0.00"), dr("RECDQTY").ToString, dr("DONE").ToString, dr("GPRNO"), dr("PRGRIDSRNO").ToString)

                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            gridQuotation.Rows(gridQuotation.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                    Next
                    gridQuotation.FirstDisplayedScrollingRowIndex = gridQuotation.RowCount - 1

                End If
                total()
                chkchange.CheckState = CheckState.Checked
            End If
            If gridQuotation.RowCount > 0 Then
                txtsrno.Text = Val(gridQuotation.Rows(gridQuotation.RowCount - 1).Cells(1).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub getmaxno()
        Dim DTTABLE As New System.Data.DataTable
        DTTABLE = getmax(" isnull(max(quotation_no),0) + 1 ", "PurchaseQuotation", "  and quotation_cmpid=" & CmpId & " and quotation_locationid=" & Locationid & " and quotation_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtquotation.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objquodetails As New PurchaseQuotationDetails
            objquodetails.MdiParent = MDIMain
            objquodetails.Show()
            objquodetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdot(e, txtrate, Me)
    End Sub

    Private Sub txtamount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamount.KeyPress
        numdot(e, txtamount, Me)
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try
            If Val(txtqty.Text) > 0 And Val(txtrate.Text) > 0 Then txtamount.Text = Val(txtqty.Text) * Val(txtrate.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdot(e, txtqty, Me)
    End Sub

    Private Sub cmdselectPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectPR.Click

        selectPRtable.Clear()
        Dim objselectpr As New SelectPR
        If edit = True Then objselectpr.PRNO = Val(txtPRNO.Text.Trim)
        objselectpr.ShowDialog()


        Dim i As Integer = 0
        If selectPRtable.Rows.Count > 0 Then
            txtPRNO.Enabled = False
            chkchange.Checked = True
            If edit = False Then gridQuotation.RowCount = 0
            Dim PRGRIDSRNO As String = ""
            Dim tempno As Integer = 0

            dtppartyref.Value = selectPRtable.Rows(0).Item("PRDATE")

            For i = 0 To selectPRtable.Rows.Count - 1

                If txtPRNO.Text.Trim = "" Then
                    txtPRNO.Text = selectPRtable.Rows(i).Item("PRNO")
                Else
                    txtPRNO.Text = txtPRNO.Text & "," & selectPRtable.Rows(i).Item("PRNO")
                End If

                gridQuotation.Rows.Add(i + 1, selectPRtable.Rows(i).Item("ITEMNAME"), selectPRtable.Rows(i).Item("DESC"), selectPRtable.Rows(i).Item("QUALITY"), selectPRtable.Rows(i).Item("REED"), selectPRtable.Rows(i).Item("PICK"), selectPRtable.Rows(i).Item("COLOR"), selectPRtable.Rows(i).Item("QTY"), selectPRtable.Rows(i).Item("QTYUNIT"), 0.0, 0.0, 0, 0, selectPRtable.Rows(0).Item("PRNO"), selectPRtable.Rows(i).Item("GRIDSRNO"))
                If PRGRIDSRNO = "" Then
                    PRGRIDSRNO = selectPRtable.Rows(i).Item("GRIDSRNO")
                    tempno = selectPRtable.Rows(i).Item("GRIDSRNO")
                Else
                    If tempno <> selectPRtable.Rows(i).Item("GRIDSRNO") Then
                        PRGRIDSRNO = PRGRIDSRNO & "," & selectPRtable.Rows(i).Item("GRIDSRNO")
                        tempno = selectPRtable.Rows(i).Item("GRIDSRNO")
                    End If
                End If

            Next
            gridQuotation.FirstDisplayedScrollingRowIndex = gridQuotation.RowCount - 1
            total()
            getsrno(gridQuotation)

        End If

    End Sub

    Private Sub txtamount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtamount.Validating
        Try

            If cmbitemname.Text.Trim <> "" And Val(txtqty.Text) > 0 And cmbqtyunit.Text.Trim <> "" Then
                fillgrid()
            Else
                If cmbitemname.Text.Trim = "" Then
                    MsgBox("Please Fill Item/Set Name ")
                    cmbitemname.Focus()
                    Exit Sub
                End If
                If cmbqtyunit.Text.Trim = "" Then
                    MsgBox("Please Fill Qty Unit")
                    cmbqtyunit.Focus()
                    Exit Sub
                End If
                If Val(txtqty.Text) = 0 Then
                    MsgBox("Please Fill Quantity ")
                    txtqty.Focus()
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridQuotation.RowCount = 0
            tempquotationno = Val(txtquotation.Text) - 1
            If tempquotationno > 0 Then
                edit = True
                PurchaseQuotation_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridQuotation.RowCount = 0
            tempquotationno = Val(txtquotation.Text) + 1
            clear()
            If Val(txtquotation.Text) - 1 >= tempquotationno Then
                edit = True
                PurchaseQuotation_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try

            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim CLSCMN As New ClsCommon
                Dim CLSPR As New ClsPurchaseQuotation()
                Dim IntResult As Integer
                Dim dttable As New System.Data.DataTable
                dttable = CLSCMN.search(" QUOTATION_done", "", " PURCHASEQUOTATION", " and QUOTATION_no = " & tempquotationno & " and QUOTATION_cmpid=" & CmpId & " and QUOTATION_locationid=" & Locationid & " and QUOTATION_yearid=" & YearId)
                If dttable.Rows.Count > 0 Then
                    If dttable.Rows(0).Item(0) = True Then
                        MsgBox("P.O. Raised. First Delete the P.O.")
                        Exit Sub
                    Else
                        Dim tempMsg As Integer = MsgBox("Delete Purchase Quotation ?", MsgBoxStyle.YesNo)
                        If tempMsg = vbYes Then
                            Dim alParaval As New ArrayList
                            alParaval.Add(tempquotationno)
                            alParaval.Add(CmpId)
                            alParaval.Add(Locationid)
                            alParaval.Add(YearId)
                            CLSPR.alParaval = alParaval
                            IntResult = CLSPR.Delete()
                            MsgBox("Purchase Quotation Deleted")
                            clear()
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(tempquotationno)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal QUOTNO As Integer)
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print Quot?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub
            Dim OBJGRN As New GRNDesign
            OBJGRN.GRNNO = QUOTNO
            OBJGRN.FRMSTRING = "QUOT"
            OBJGRN.MdiParent = MDIMain
            OBJGRN.selfor_GRN = "{PURCHASEQUOTATION.QUOTATION_NO}=" & QUOTNO & " AND {PURCHASEQUOTATION.QUOTATION_cmpid}=" & CmpId & " and {PURCHASEQUOTATION.QUOTATION_locationid}=" & Locationid & " and {PURCHASEQUOTATION.QUOTATION_yearid}=" & YearId
            OBJGRN.vendorname = cmbname.Text.Trim
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbitemname.KeyPress
        commakeypress(e, cmbitemname, Me)
    End Sub

    Private Sub txtgridremarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgridremarks.KeyPress
        commakeypress(e, txtgridremarks, Me)
    End Sub

    Private Sub cmbqtyunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbqtyunit.KeyPress
        commakeypress(e, cmbqtyunit, Me)
    End Sub

    Private Sub CMDDOWNLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDOWNLOAD.Click
        'Try
        '    txtimgpath.Text = System.AppDomain.CurrentDomain.BaseDirectory & "Uploaded Files\PQUOT-" & txtquotation.Text.Trim

        '    Dim EXTENSION = Path.GetExtension(txtimgpath.Text)
        '    'If EXTENSION <> ".pdf" Then
        '    '    System.IO.File.Copy(txtimgpath.Text.Trim, System.AppDomain.CurrentDomain.BaseDirectory & "Uploaded Files\PQUOT-" & txtquotation.Text.Trim & EXTENSION, True)
        '    '    MsgBox("File Uploaded Successfully", MsgBoxStyle.OkOnly, "Tex Pro")
        '    'Else
        '    '    pbsoftcopy.Load(System.AppDomain.CurrentDomain.BaseDirectory & "PDF.jpg")
        '    'End If

        '    System.IO.File.Copy(System.AppDomain.CurrentDomain.BaseDirectory & "Uploaded Files\PQUOT-" & txtquotation.Text.Trim, "C:\PQUOT-" & txtquotation.Text.Trim)
        '    MsgBox("Download Complete")
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub dtppartyref_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtppartyref.Validating
        If Not datecheck(dtppartyref.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub dtvalidtill_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtvalidtill.Validating
        If Not datecheck(dtvalidtill.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        tempquotationno = Val(tstxtbillno.Text)
        clear()
        If tempquotationno > 0 Then
            edit = True
            PurchaseQuotation_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub TXTREED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREED.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPICK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPICK.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub cmduploadPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmduploadPR.Click
        Try
            OpenFileDialog1.Filter = "Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
            OpenFileDialog1.ShowDialog()

            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open(OpenFileDialog1.FileName, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")
            '' To find range in excel and send them to combo box(cboName)
            'For Each cPart In oSheet.Range("U6")
            '    txtPRNO.Text = (cPart.Value)
            'Next cPart

            'GRID
            Dim DT As New System.Data.DataTable
            DT.Columns.Add("SRNO")
            DT.Columns.Add("ITEMNAME")
            DT.Columns.Add("DESC")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("REED")
            DT.Columns.Add("PICK")
            DT.Columns.Add("COLOR")
            DT.Columns.Add("QTY")
            DT.Columns.Add("QTYUNIT")
            DT.Columns.Add("RATE")
            DT.Columns.Add("AMT")
            DT.Columns.Add("PRGRIDSRNO")

            txtPRNO.Text = oSheet.Range("U6").Value


            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            For I As Integer = 13 To Convert.ToDouble(oSheet.Range("U7").Value) + 12
                Dim DTROW As System.Data.DataRow = DT.NewRow()
                DTROW("SRNO") = oSheet.Range("A" & I.ToString).Value
                DTROW("ITEMNAME") = oSheet.Range("B" & I.ToString).Value
                DTROW("DESC") = oSheet.Range("G" & I.ToString).Value
                DTROW("QUALITY") = oSheet.Range("L" & I.ToString).Value
                DTROW("REED") = oSheet.Range("M" & I.ToString).Value
                DTROW("PICK") = oSheet.Range("N" & I.ToString).Value
                DTROW("COLOR") = oSheet.Range("O" & I.ToString).Value
                DTROW("QTY") = oSheet.Range("Q" & I.ToString).Value
                DTROW("QTYUNIT") = oSheet.Range("R" & I.ToString).Value
                DTROW("RATE") = oSheet.Range("S" & I.ToString).Value
                DTROW("AMT") = oSheet.Range("T" & I.ToString).Value
                DTROW("PRGRIDSRNO") = oSheet.Range("U" & I.ToString).Value

                DT.Rows.Add(DTROW)
            Next

            If DT.Rows.Count > 0 Then
                For Each ROW As System.Data.DataRow In DT.Rows
                    If IsDBNull(ROW("RATE")) = True Then ROW("RATE") = 0
                    If IsDBNull(ROW("AMT")) = True Then ROW("AMT") = 0
                    gridQuotation.Rows.Add(ROW("SRNO"), ROW("ITEMNAME"), ROW("DESC"), ROW("QUALITY"), ROW("REED"), ROW("PICK"), ROW("COLOR"), ROW("QTY"), ROW("QTYUNIT"), ROW("RATE"), ROW("AMT"), 0, 0, oSheet.Range("U6").Value, ROW("PRGRIDSRNO"))
                Next
                total()
            End If

            oBook.Close()

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
                    objVIEW.pbsoftcopy.ImageLocation = pbsoftcopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function getdata() As Boolean
        Try
            Dim bln As Boolean = False

            'get data from purchase request
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("PURCHASEREQUEST.PREQ_NO AS [PRNO], PURCHASEREQUEST.PREQ_DATE AS DATE, PURCHASEREQUEST_DESC.PREQ_GRIDSRNO AS GRIDSRNO, isnull(ITEMMASTER.item_name,'') AS [ITEMNAME], isnull(PURCHASEREQUEST_DESC.PREQ_GRIDREMARKS,'') AS [DESC], isnull(QUALITYMASTER.QUALITY_name,'') AS QUALITY, isnull(PURCHASEREQUEST_DESC.PREQ_REED,'') AS REED, isnull(PURCHASEREQUEST_DESC.PREQ_PICK,'') AS PICK, isnull(COLORMASTER.COLOR_name,'') AS COLOR, (PURCHASEREQUEST_DESC.PREQ_QTY - PURCHASEREQUEST_DESC.PREQ_RECDQTY) AS QTY, isnull(UNITMASTER.unit_abbr,'') AS QTYUNIT ", "", " PURCHASEREQUEST INNER JOIN PURCHASEREQUEST_DESC ON PURCHASEREQUEST.PREQ_NO = PURCHASEREQUEST_DESC.PREQ_NO AND PURCHASEREQUEST.PREQ_CMPID = PURCHASEREQUEST_DESC.PREQ_CMPID AND PURCHASEREQUEST.PREQ_LOCATIONID = PURCHASEREQUEST_DESC.PREQ_LOCATIONID AND PURCHASEREQUEST.PREQ_YEARID = PURCHASEREQUEST_DESC.PREQ_YEARID LEFT OUTER JOIN UNITMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = UNITMASTER.unit_yearid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = UNITMASTER.unit_locationid AND PURCHASEREQUEST_DESC.PREQ_CMPID = UNITMASTER.unit_cmpid AND PURCHASEREQUEST_DESC.PREQ_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN COLORMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = COLORMASTER.COLOR_yearid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = COLORMASTER.COLOR_locationid AND PURCHASEREQUEST_DESC.PREQ_CMPID = COLORMASTER.COLOR_cmpid AND PURCHASEREQUEST_DESC.PREQ_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = QUALITYMASTER.QUALITY_yearid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PURCHASEREQUEST_DESC.PREQ_CMPID = QUALITYMASTER.QUALITY_cmpid AND PURCHASEREQUEST_DESC.PREQ_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON PURCHASEREQUEST_DESC.PREQ_ITEMID = ITEMMASTER.item_id AND PURCHASEREQUEST_DESC.PREQ_CMPID = ITEMMASTER.item_cmpid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = ITEMMASTER.item_locationid AND PURCHASEREQUEST_DESC.PREQ_YEARID = ITEMMASTER.item_yearid ", " and PURCHASEREQUEST.PREQ_NO = " & Val(txtPRNO.Text.Trim) & " AND PURCHASEREQUEST_DESC.PREQ_DONE= 'False'  And PurchaseRequest.preq_cmpid = " & CmpId & " And PurchaseRequest.preq_locationid = " & Locationid & " And PurchaseRequest.preq_yearid = " & YearId & " order by dbo.PURCHASEREQUEST.PREQ_NO")
            If DT.Rows.Count > 0 Then
                bln = True

                chkchange.Checked = True
                If edit = False Then gridQuotation.RowCount = 0
                Dim PRGRIDSRNO As String = ""
                Dim tempno As Integer = 0
                dtppartyref.Value = DT.Rows(0).Item("DATE")

                For i As Integer = 0 To DT.Rows.Count - 1

                    gridQuotation.Rows.Add(i + 1, DT.Rows(i).Item("ITEMNAME"), DT.Rows(i).Item("DESC"), DT.Rows(i).Item("QUALITY"), DT.Rows(i).Item("REED"), DT.Rows(i).Item("PICK"), DT.Rows(i).Item("COLOR"), DT.Rows(i).Item("QTY"), DT.Rows(i).Item("QTYUNIT"), 0.0, 0.0, 0, 0, DT.Rows(i).Item("PRNO"), DT.Rows(i).Item("GRIDSRNO"))
                    If PRGRIDSRNO = "" Then
                        PRGRIDSRNO = DT.Rows(i).Item("GRIDSRNO")
                        tempno = DT.Rows(i).Item("GRIDSRNO")
                    Else
                        If tempno <> DT.Rows(i).Item("GRIDSRNO") Then
                            PRGRIDSRNO = PRGRIDSRNO & "," & DT.Rows(i).Item("GRIDSRNO")
                            tempno = DT.Rows(i).Item("GRIDSRNO")

                        End If
                    End If

                Next
                gridQuotation.FirstDisplayedScrollingRowIndex = gridQuotation.RowCount - 1
                total()
                getsrno(gridQuotation)

            End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub txtPRNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPRNO.Validating
        Try
            If txtPRNO.Text.Trim <> "" Then
                If Not getdata() Then
                    MsgBox("Invalid Request No.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                txtPRNO.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class