
Imports BL

Public Class OpeningStock

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Public TYPE As String
    Public edit As Boolean
    Public tempMsg As Integer

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If gridstock.RowCount = 0 Then
            EP.SetError(txtpcs, "Enter Item Details")
            bln = False
        End If

        For Each row As DataGridViewRow In gridstock.Rows
            If (Val(row.Cells(Gpcs.Index).Value) = 0 And Val(row.Cells(gMtrs.Index).Value) = 0) Then
                EP.SetError(txtpcs, "pcs Cannot be 0")
                bln = False
            End If
        Next

        Return bln
    End Function

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            Dim alParaval As New ArrayList
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            
            Dim subtype As String = ""
            Dim LOTNO As String = ""
            Dim GODOWN As String = ""
            Dim MERCHANT As String = ""
            Dim quality As String = ""
            Dim process As String = ""
            Dim name As String = ""
            Dim PIECETYPE As String = ""
            Dim bale As String = ""
            Dim jobno As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""
            Dim dyeing As String = ""
            Dim COLOR As String = ""
            Dim wt As String = ""
            Dim RATE As String = ""
            Dim GREYWIDTH As String = ""
            Dim READYWIDTH As String = ""
            Dim LOTRECDDATE As String = ""
            Dim pcs As String = ""
            Dim unit As String = ""
            Dim saree As String = ""
            Dim mtrs As String = ""
            Dim outmtrs As String = ""
            Dim outPcs As String = ""
            Dim done As String = ""
            Dim returnpcs As String = ""
            Dim TRANSFERDONE As String = ""
            Dim PACKSUMMDONE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In gridstock.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString

                        subtype = row.Cells(gsubtype.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        GODOWN = row.Cells(GGODOWN.Index).Value.ToString
                        MERCHANT = row.Cells(GMERCHANT.Index).Value.ToString
                        quality = row.Cells(gQuality.Index).Value.ToString
                        process = row.Cells(gProcess.Index).Value.ToString
                        name = row.Cells(gname.Index).Value.ToString
                        PIECETYPE = row.Cells(gpiecetype.Index).Value.ToString
                        bale = row.Cells(GBALE.Index).Value.ToString
                        jobno = row.Cells(gjobno.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        dyeing = row.Cells(gdyeing.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        wt = row.Cells(GWT.Index).Value.ToString
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        GREYWIDTH = row.Cells(GGREYWIDTH.Index).Value
                        READYWIDTH = row.Cells(GREADYWIDTH.Index).Value
                        LOTRECDDATE = Format(Convert.ToDateTime(row.Cells(GRECDDATE.Index).Value).Date, "MM/dd/yyyy")
                        pcs = row.Cells(Gpcs.Index).Value.ToString
                        unit = row.Cells(Gunit.Index).Value.ToString
                        saree = row.Cells(GSAREE.Index).Value
                        mtrs = row.Cells(gMtrs.Index).Value
                        outPcs = row.Cells(gOutpcs.Index).Value
                        outmtrs = row.Cells(goutmtrs.Index).Value
                        done = row.Cells(gdone.Index).Value
                        returnpcs = row.Cells(greturnpcs.Index).Value
                        TRANSFERDONE = row.Cells(GTRANSFERDONE.Index).Value
                        PACKSUMMDONE = row.Cells(GPACKSUMMDONE.Index).Value

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value.ToString
                        subtype = subtype & "|" & row.Cells(gsubtype.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        GODOWN = GODOWN & "|" & row.Cells(GGODOWN.Index).Value.ToString
                        MERCHANT = MERCHANT & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        quality = quality & "|" & row.Cells(gQuality.Index).Value.ToString
                        process = process & "|" & row.Cells(gProcess.Index).Value.ToString
                        name = name & "|" & row.Cells(gname.Index).Value.ToString
                        PIECETYPE = PIECETYPE & "|" & row.Cells(gpiecetype.Index).Value.ToString
                        bale = bale & "|" & row.Cells(GBALE.Index).Value.ToString
                        jobno = jobno & "|" & row.Cells(gjobno.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(GCUT.Index).Value
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        dyeing = dyeing & "|" & row.Cells(gdyeing.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        wt = wt & "|" & row.Cells(GWT.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        GREYWIDTH = GREYWIDTH & "|" & row.Cells(GGREYWIDTH.Index).Value
                        READYWIDTH = READYWIDTH & "|" & row.Cells(GREADYWIDTH.Index).Value
                        LOTRECDDATE = LOTRECDDATE & "|" & Format(Convert.ToDateTime(row.Cells(GRECDDATE.Index).Value).Date, "MM/dd/yyyy")
                        pcs = pcs & "|" & row.Cells(Gpcs.Index).Value.ToString
                        unit = unit & "|" & row.Cells(Gunit.Index).Value.ToString
                        saree = saree & "|" & row.Cells(GSAREE.Index).Value
                        mtrs = mtrs & "|" & row.Cells(gMtrs.Index).Value
                        outPcs = outPcs & "|" & row.Cells(gOutpcs.Index).Value
                        outmtrs = outmtrs & "|" & row.Cells(goutmtrs.Index).Value
                        done = done & "|" & row.Cells(gdone.Index).Value
                        returnpcs = returnpcs & "|" & row.Cells(greturnpcs.Index).Value
                        TRANSFERDONE = TRANSFERDONE & "|" & row.Cells(GTRANSFERDONE.Index).Value
                        PACKSUMMDONE = PACKSUMMDONE & "|" & row.Cells(GPACKSUMMDONE.Index).Value
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(Format(openingdate.Value, "MM/dd/yyyy"))
            alParaval.Add(cmbtype.Text)
            alParaval.Add(subtype)
            alParaval.Add(LOTNO)
            alParaval.Add(GODOWN)
            alParaval.Add(MERCHANT)
            alParaval.Add(quality)
            alParaval.Add(process)
            alParaval.Add(name)
            alParaval.Add(PIECETYPE)
            alParaval.Add(bale)
            alParaval.Add(jobno)
            alParaval.Add(CUT)
            alParaval.Add(DESIGN)
            alParaval.Add(dyeing)
            alParaval.Add(COLOR)
            alParaval.Add(wt)
            alParaval.Add(RATE)
            alParaval.Add(GREYWIDTH)
            alParaval.Add(READYWIDTH)
            alParaval.Add(LOTRECDDATE)
            alParaval.Add(pcs)
            alParaval.Add(unit)
            alParaval.Add(saree)
            alParaval.Add(mtrs)
            alParaval.Add(outmtrs)
            alParaval.Add(outPcs)
            alParaval.Add(done)
            alParaval.Add(returnpcs)
            alParaval.Add(TRANSFERDONE)
            alParaval.Add(PACKSUMMDONE)


            Dim objstock As New ClsStockMaster()
            objstock.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                'FIRST DELETE AND THEN INSERT
                Dim OBJCMN As New ClsCommon
                Dim DTDEL As DataTable = OBJCMN.Execute_Any_String("DELETE FROM STOCKMASTER WHERE SM_TYPE = '" & cmbtype.Text.Trim & "' AND SM_YEARID = " & YearId, "", "")
                IntResult = objstock.SAVE()

                MsgBox("Details Added")
            End If

            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub gridstock_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridstock.CellValidating

        Dim colNum As Integer = gridstock.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum
            Case Gpcs.Index, gMtrs.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                If bValid Then
                    If gridstock.CurrentCell.Value = Nothing Then gridstock.CurrentCell.Value = "0.00"
                    gridstock.CurrentCell.Value = Convert.ToDecimal(gridstock.Item(colNum, e.RowIndex).Value)
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub gridSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridstock.CellDoubleClick
        If e.RowIndex >= 0 And gridstock.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToDecimal(gridstock.Rows(e.RowIndex).Cells(goutmtrs.Index).Value) > 0 Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from SALEORDER")
                Exit Sub
            End If


            gridDoubleClick = True
            txtsrno.Text = gridstock.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbsubtype.Text = gridstock.Item(gsubtype.Index, e.RowIndex).Value.ToString
            TXTLOTNO.Text = gridstock.Item(GLOTNO.Index, e.RowIndex).Value.ToString
            CMBGODOWN.Text = gridstock.Item(GGODOWN.Index, e.RowIndex).Value
            cmbmerchant.Text = gridstock.Item(GMERCHANT.Index, e.RowIndex).Value.ToString
            cmbquality.Text = gridstock.Item(gQuality.Index, e.RowIndex).Value.ToString
            cmbprocess.Text = gridstock.Item(gProcess.Index, e.RowIndex).Value.ToString
            cmbname.Text = gridstock.Item(gname.Index, e.RowIndex).Value.ToString
            cmbpiecetype.Text = gridstock.Item(gpiecetype.Index, e.RowIndex).Value.ToString
            txtbale.Text = gridstock.Item(GBALE.Index, e.RowIndex).Value.ToString
            txtjobno.Text = gridstock.Item(gjobno.Index, e.RowIndex).Value.ToString
            txtcut.Text = gridstock.Item(GCUT.Index, e.RowIndex).Value.ToString

            cmbdesign.Text = gridstock.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            cmbdyeing.Text = gridstock.Item(gdyeing.Index, e.RowIndex).Value.ToString
            cmbcolor.Text = gridstock.Item(gcolor.Index, e.RowIndex).Value.ToString

            TXTWT.Text = gridstock.Item(GWT.Index, e.RowIndex).Value.ToString
            TXTRATE.Text = Val(gridstock.Item(GRATE.Index, e.RowIndex).Value)
            TXTGREYWIDTH.Text = gridstock.Item(GGREYWIDTH.Index, e.RowIndex).Value
            TXTREADYWIDTH.Text = gridstock.Item(GREADYWIDTH.Index, e.RowIndex).Value
            DTLOTRECD.Value = Convert.ToDateTime(gridstock.Item(GRECDDATE.Index, e.RowIndex).Value)
            txtpcs.Text = gridstock.Item(Gpcs.Index, e.RowIndex).Value.ToString
            cmbunit.Text = gridstock.Item(Gunit.Index, e.RowIndex).Value.ToString
            txtsaree.Text = gridstock.Item(GSAREE.Index, e.RowIndex).Value.ToString
            txtMtrs.Text = gridstock.Item(gMtrs.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " and (GROUPMASTER.GROUP_NAME = 'Sundry Creditors' or GROUPMASTER.GROUP_NAME = 'Sundry Debtors')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and (GROUPMASTER.GROUP_NAME = 'Sundry Creditors' or GROUPMASTER.GROUP_NAME = 'Sundry Debtors')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbtype.Text = "STORE" Then
                If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING IN ('ITEM')")
            Else
                If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING IN ('MERCHANT')")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbtype.Text = "STORE" Then
                If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING IN ('ITEM') ", "ITEM")
            Else
                If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING IN ('MERCHANT','ITEM') ", "MERCHANT")
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpiecetype.Enter
        Try
            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpiecetype.Validating
        Try
            If cmbpiecetype.Text.Trim <> "" Then PIECETYPEvalidate(cmbpiecetype, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbtype.Text = "STORE" Then
                If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING IN ('ITEM')")
            Else
                If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING IN ('MERCHANT')")
            End If
            fillQUALITY(cmbquality, edit)
            fillname(cmbname, edit, " and (GROUPMASTER.GROUP_NAME = 'Sundry Creditors' or GROUPMASTER.GROUP_NAME = 'Sundry Debtors')")
            fillPIECETYPE(cmbpiecetype)
            fillDESIGN(cmbdesign, cmbmerchant.Text)
            If cmbdyeing.Text.Trim = "" Then filldyeing(cmbdyeing)
            fillCOLOR(cmbcolor)
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
            If cmbprocess.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" distinct process_NAME ", "", " processmaster ", " and process_cmpid=" & CmpId & " and process_locationid = " & Locationid & " and process_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "process_NAME"
                    cmbprocess.DataSource = dt
                    cmbprocess.DisplayMember = "process_NAME"
                    cmbprocess.Text = ""
                End If
                cmbprocess.SelectAll()
            End If
            cmbunit.Text = "pcs"
            FILLGODOWN(CMBGODOWN, edit)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridstock.Enabled = True

        If gridDoubleClick = False Then
            gridstock.Rows.Add(Val(txtsrno.Text.Trim), Format(openingdate.Value, "dd/MM/yyyy"), cmbtype.Text.Trim, cmbsubtype.Text.Trim, TXTLOTNO.Text.Trim, CMBGODOWN.Text.Trim, cmbmerchant.Text.Trim, cmbquality.Text.Trim, cmbprocess.Text.Trim, cmbname.Text.Trim, cmbpiecetype.Text.Trim, txtbale.Text, txtjobno.Text.Trim, txtcut.Text.Trim, cmbdesign.Text.Trim, cmbdyeing.Text.Trim, cmbcolor.Text.Trim, Val(TXTWT.Text.Trim), Val(TXTRATE.Text.Trim), TXTGREYWIDTH.Text.Trim, TXTREADYWIDTH.Text.Trim, Format(DTLOTRECD.Value.Date, "dd/MM/yyyy"), Val(txtpcs.Text.Trim), cmbunit.Text.Trim, Val(txtsaree.Text.Trim), Val(txtMtrs.Text.Trim), 0, 0, 0, 0, 0, 0)
            getsrno(gridstock)
            gridstock.FirstDisplayedScrollingRowIndex = gridstock.RowCount - 1
        ElseIf gridDoubleClick = True Then
            gridstock.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)

            gridstock.Item(gType.Index, temprow).Value = cmbtype.Text.Trim
            gridstock.Item(gsubtype.Index, temprow).Value = cmbsubtype.Text.Trim
            gridstock.Item(GLOTNO.Index, temprow).Value = TXTLOTNO.Text.Trim
            gridstock.Item(GGODOWN.Index, temprow).Value = CMBGODOWN.Text.Trim
            gridstock.Item(GMERCHANT.Index, temprow).Value = cmbmerchant.Text.Trim
            gridstock.Item(gQuality.Index, temprow).Value = cmbquality.Text.Trim
            gridstock.Item(gProcess.Index, temprow).Value = cmbprocess.Text.Trim
            gridstock.Item(gname.Index, temprow).Value = cmbname.Text.Trim
            gridstock.Item(gpiecetype.Index, temprow).Value = cmbpiecetype.Text.Trim
            gridstock.Item(GBALE.Index, temprow).Value = txtbale.Text.Trim
            gridstock.Item(gjobno.Index, temprow).Value = txtjobno.Text.Trim
            gridstock.Item(GCUT.Index, temprow).Value = txtcut.Text.Trim
            gridstock.Item(GDESIGN.Index, temprow).Value = cmbdesign.Text.Trim
            gridstock.Item(gdyeing.Index, temprow).Value = cmbdyeing.Text.Trim
            gridstock.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim

            gridstock.Item(GWT.Index, temprow).Value = Val(TXTWT.Text.Trim)
            gridstock.Item(GRATE.Index, temprow).Value = Val(TXTRATE.Text.Trim)
            gridstock.Item(GGREYWIDTH.Index, temprow).Value = TXTGREYWIDTH.Text.Trim
            gridstock.Item(GREADYWIDTH.Index, temprow).Value = TXTREADYWIDTH.Text.Trim
            gridstock.Item(GRECDDATE.Index, temprow).Value = Format(DTLOTRECD.Value.Date, "dd/MM/yyyy")
            gridstock.Item(Gpcs.Index, temprow).Value = Val(txtpcs.Text.Trim)
            gridstock.Item(Gunit.Index, temprow).Value = cmbunit.Text.Trim
            gridstock.Item(GSAREE.Index, temprow).Value = txtsaree.Text.Trim
            gridstock.Item(gMtrs.Index, temprow).Value = txtMtrs.Text.Trim

            gridDoubleClick = False
        End If


        txtsrno.Clear()
        'cmbmerchant.Text = ""
        TXTLOTNO.Clear()
        cmbpiecetype.Text = ""
        cmbcolor.Text = ""
        cmbquality.Text = ""
        txtMtrs.Clear()
        txtpcs.Clear()
        txtsaree.Clear()
        cmbdesign.Text = ""
        txtcut.Clear()
        TXTWT.Clear()
        TXTRATE.Clear()
        TXTGREYWIDTH.Clear()
        TXTREADYWIDTH.Clear()
        DTLOTRECD.Value = openingdate.Value

        txtsrno.Text = gridstock.RowCount + 1

    End Sub
   
    Private Sub txtMtrs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMtrs.Validated
        Dim BLN As Boolean = True
        If TYPE = "GREY" Or TYPE = "GRSTOCK" Then
            If cmbsubtype.Text.Trim <> "" And TXTLOTNO.Text.Trim <> "" And cmbmerchant.Text.Trim <> "" And cmbquality.Text.Trim <> "" And cmbname.Text.Trim <> "" And Val(txtpcs.Text) > 0 And cmbunit.Text.Trim <> "" And Val(txtMtrs.Text) > 0 Then
                fillgrid()
            Else
                BLN = False
            End If
        ElseIf TYPE = "STORE" Then
            If cmbmerchant.Text.Trim <> "" And Val(txtpcs.Text) <> 0 And cmbunit.Text.Trim <> "" Then
                fillgrid()
            Else
                BLN = False
            End If
        ElseIf TYPE = "PROCESS" Then
            If TXTLOTNO.Text.Trim <> "" And cmbmerchant.Text.Trim <> "" And cmbprocess.Text.Trim <> "" And cmbpiecetype.Text.Trim <> "" And Val(txtpcs.Text) <> 0 And cmbunit.Text.Trim <> "" And Val(txtMtrs.Text) <> 0 Then
                fillgrid()
            Else
                BLN = False
            End If
        ElseIf TYPE = "BALE" Then
            If cmbmerchant.Text.Trim <> "" And TXTLOTNO.Text.Trim <> "" And txtbale.Text.Trim <> "" And Val(txtpcs.Text) > 0 And cmbunit.Text.Trim <> "" And Val(txtMtrs.Text) > 0 Then
                fillgrid()
            Else
                BLN = False
            End If
        ElseIf TYPE = "JOBBALE" Then
            If cmbmerchant.Text.Trim <> "" And cmbmerchant.Text.Trim <> "" And txtbale.Text.Trim <> "" And txtcut.Text.Trim > 0 And Val(txtpcs.Text) > 0 And cmbunit.Text.Trim <> "" And Val(txtMtrs.Text) > 0 Then
                fillgrid()
            Else
                BLN = False
            End If
        ElseIf TYPE = "JOBOUT" Then
            If cmbmerchant.Text.Trim <> "" And TXTLOTNO.Text.Trim <> "" And cmbname.Text.Trim <> "" And txtjobno.Text.Trim <> "" And txtbale.Text.Trim <> "" And Val(txtpcs.Text) > 0 And cmbunit.Text.Trim <> "" And Val(txtsaree.Text.Trim) > 0 And Val(txtMtrs.Text) > 0 Then
                fillgrid()
            Else
                BLN = False
            End If
        ElseIf TYPE = "LOOSE" Then
            If cmbmerchant.Text.Trim <> "" And Val(txtpcs.Text) > 0 And cmbpiecetype.Text.Trim <> "" And cmbunit.Text.Trim <> "" And Val(txtMtrs.Text) > 0 Then
                fillgrid()
            Else
                BLN = False
            End If
        End If


        If BLN = False Then
            MsgBox("Enter Proper Details")
            Exit Sub
        End If
    End Sub

    Private Sub OpeningStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdOK_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub OpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()

            If TYPE = "GREY" Or TYPE = "GRSTOCK" Then
                cmbtype.Text = TYPE
                cmbtype.Enabled = False
                cmbmerchant.Text = "GREY MATERIAL"
                cmbmerchant.Enabled = False
                GMERCHANT.HeaderText = "Item Name"
                'cmbname.Enabled = False
                cmbprocess.Enabled = False
                cmbpiecetype.Enabled = False
                txtcut.Enabled = False
                txtbale.Enabled = False
                txtsaree.Enabled = False
                txtjobno.Enabled = False
                cmbcolor.Enabled = False
                cmbdesign.Enabled = False
                cmbdyeing.Enabled = False
            ElseIf TYPE = "STORE" Then
                cmbtype.Text = "STORE"
                cmbtype.Enabled = False
                fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
                cmbsubtype.Enabled = False
                txtsaree.Enabled = False
                GMERCHANT.HeaderText = "Item Name"
                'cmbname.Enabled = False
                TXTLOTNO.Enabled = False
                cmbquality.Enabled = False
                cmbprocess.Enabled = False
                cmbpiecetype.Enabled = False
                txtcut.Enabled = False
                txtbale.Enabled = False
                txtjobno.Enabled = False
                cmbcolor.Enabled = False
                cmbdesign.Enabled = False
                cmbdyeing.Enabled = False
                txtMtrs.Enabled = False

            ElseIf TYPE = "BALE" Then
                cmbtype.Text = "BALE"
                cmbtype.Enabled = False
                cmbsubtype.Enabled = False

                'cmbname.Enabled = False
                fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            ElseIf TYPE = "JOBOUT" Then
                cmbtype.Text = "JOBOUT"
                cmbtype.Enabled = False
                cmbsubtype.Enabled = False

                fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

            ElseIf TYPE = "JOBBALE" Then
                cmbtype.Text = "JOBBALE"
                cmbtype.Enabled = False
                cmbsubtype.Enabled = False

                fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

            ElseIf TYPE = "LOOSE" Then
                cmbtype.Text = "LOOSE"
                cmbtype.Enabled = False
                cmbsubtype.Enabled = False

                fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

            ElseIf TYPE = "PROCESS" Then
                cmbtype.Text = "PROCESS"
                cmbtype.Enabled = False
                openingdate.Enabled = True
                cmbsubtype.Enabled = False
                fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
                cmbmerchant.Text = "GREY MATERIAL"
                cmbname.Enabled = False
            End If

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search("   ISNULL(STOCKMASTER.SM_GRIDSRNO, 0) AS GRIDSRNO,  STOCKMASTER.SM_LOTNO AS LOTNO, ISNULL(GODOWN_NAME,'') AS GODOWN, STOCKMASTER.SM_DATE AS DATE, STOCKMASTER.SM_TYPE AS TYPE, STOCKMASTER.SM_SUBTYPE AS SUBTYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(DESIGNRECIPE.DESIGN_NO, '') AS DESIGN, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(DYEINGRECIPE.DYEING_NO, '') AS DYEING, ISNULL(STOCKMASTER.SM_BALENO, '') AS BALENO, ISNULL(STOCKMASTER.SM_JOBNO, '') AS JOBNO, ISNULL(STOCKMASTER.SM_CUT, 0) AS CUT, ISNULL(STOCKMASTER.SM_SAREE, 0) AS SAREE,ISNULL(STOCKMASTER.SM_wt, 0) AS wt, ISNULL(STOCKMASTER.SM_RATE, 0) AS RATE, ISNULL(STOCKMASTER.SM_GREYWIDTH,'') AS GREYWIDTH, ISNULL(STOCKMASTER.SM_READYWIDTH,'') AS READYWIDTH, ISNULL(STOCKMASTER.SM_LOTRECDDATE, SM_DATE) AS LOTRECDDATE, ISNULL(STOCKMASTER.SM_PCS, 0) AS PCS, ISNULL(STOCKMASTER.SM_MTRS, 0) AS MTRS, ISNULL(STOCKMASTER.SM_RECDPCS,0) AS OUTPCS, ISNULL(STOCKMASTER.SM_RECDMTRS,0) AS OUTMTRS,  ISNULL(STOCKMASTER.SM_DONE,0) AS DONE,  ISNULL(STOCKMASTER.SM_RETURNPCS,0) AS RETURNPCS, ISNULL(STOCKMASTER.SM_TRANSFERDONE,0) AS TRANSFERDONE, ISNULL(STOCKMASTER.SM_PACKSUMMDONE,0) AS PACKSUMMDONE ", "", "  STOCKMASTER LEFT OUTER JOIN DYEINGRECIPE ON STOCKMASTER.SM_DYEINGID = DYEINGRECIPE.DYEING_ID AND STOCKMASTER.SM_CMPID = DYEINGRECIPE.DYEING_CMPID AND STOCKMASTER.SM_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND STOCKMASTER.SM_YEARID = DYEINGRECIPE.DYEING_YEARID LEFT OUTER JOIN PIECETYPEMASTER ON STOCKMASTER.SM_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND STOCKMASTER.SM_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND STOCKMASTER.SM_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND STOCKMASTER.SM_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN QUALITYMASTER ON STOCKMASTER.SM_QUALITYID = QUALITYMASTER.QUALITY_id AND STOCKMASTER.SM_CMPID = QUALITYMASTER.QUALITY_cmpid AND STOCKMASTER.SM_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND STOCKMASTER.SM_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN PROCESSMASTER ON STOCKMASTER.SM_YEARID = PROCESSMASTER.PROCESS_YEARID AND STOCKMASTER.SM_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND STOCKMASTER.SM_CMPID = PROCESSMASTER.PROCESS_CMPID AND STOCKMASTER.SM_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN DESIGNRECIPE ON STOCKMASTER.SM_DESIGNID = DESIGNRECIPE.DESIGN_ID AND STOCKMASTER.SM_ITEMID = DESIGNRECIPE.DESIGN_ITEMID AND STOCKMASTER.SM_CMPID = DESIGNRECIPE.DESIGN_CMPID AND STOCKMASTER.SM_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND STOCKMASTER.SM_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERID = LEDGERS.Acc_id AND STOCKMASTER.SM_CMPID = LEDGERS.Acc_cmpid AND STOCKMASTER.SM_LOCATIONID = LEDGERS.Acc_locationid AND STOCKMASTER.SM_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN UNITMASTER ON STOCKMASTER.SM_UNITID = UNITMASTER.unit_id AND STOCKMASTER.SM_CMPID = UNITMASTER.unit_cmpid AND STOCKMASTER.SM_LOCATIONID = UNITMASTER.unit_locationid AND STOCKMASTER.SM_YEARID = UNITMASTER.unit_yearid LEFT OUTER JOIN COLORMASTER ON STOCKMASTER.SM_COLORID = COLORMASTER.COLOR_id AND STOCKMASTER.SM_CMPID = COLORMASTER.COLOR_cmpid AND STOCKMASTER.SM_LOCATIONID = COLORMASTER.COLOR_locationid AND STOCKMASTER.SM_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN ITEMMASTER ON STOCKMASTER.SM_ITEMID = ITEMMASTER.item_id AND STOCKMASTER.SM_CMPID = ITEMMASTER.item_cmpid AND STOCKMASTER.SM_LOCATIONID = ITEMMASTER.item_locationid AND STOCKMASTER.SM_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN GODOWNMASTER ON STOCKMASTER.SM_GODOWNID = GODOWN_ID", " AND STOCKMASTER.SM_TYPE = '" & TYPE & "' AND STOCKMASTER.SM_YEARID = " & YearId & " ORDER BY [GRIDSRNO]")
            For Each DR As DataRow In dttable.Rows
                gridstock.Rows.Add(DR("GRIDSRNO"), DR("DATE"), DR("TYPE"), DR("SUBTYPE"), DR("LOTNO"), DR("GODOWN"), DR("ITEMNAME"), DR("QUALITY"), DR("PROCESS"), DR("NAME"), DR("PIECETYPE"), DR("BALENO"), DR("JOBNO"), Format(DR("CUT"), "0.000"), DR("DESIGN"), DR("DYEING"), DR("COLOR"), DR("wt"), Val(DR("RATE")), DR("GREYWIDTH"), DR("READYWIDTH"), Format(Convert.ToDateTime(DR("LOTRECDDATE")).Date, "dd/MM/yyyy"), DR("PCS"), DR("UNIT"), DR("SAREE"), Format(DR("MTRS"), "0.00"), Format(DR("OUTPCS"), "0.00"), Format(DR("OUTMTRS"), "0.00"), DR("DONE"), DR("RETURNPCS"), DR("TRANSFERDONE"), DR("PACKSUMMDONE"))
                openingdate.Value = Format(DR("DATE"), "dd/MM/yyyy")
            Next

            txtsrno.Text = gridstock.RowCount + 1

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbunit.Validated
        Try
            If cmbtype.Text = "STORE" Then
                If cmbmerchant.Text.Trim <> "" And Val(txtpcs.Text) <> 0 And cmbunit.Text.Trim <> "" Then
                    fillgrid()
                Else
                    If cmbmerchant.Text.Trim = "" Then
                        MsgBox("Please Fill Item Name ")
                        cmbmerchant.Focus()
                        Exit Sub
                    End If


                    If Val(txtpcs.Text.Trim) = 0 Then
                        MsgBox("Please Fill Quantity ")
                        txtpcs.Focus()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
        Try
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdyeing.GotFocus
        Try
            If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdyeing.Validating
        Try
            If CMBDYEING.Text.Trim <> "" Then dyeingvalidate(CMBDYEING, e, Me)
            CMBCOLOR.Text = ""
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
            If cmbdesign.Text.Trim <> "" Then DESIGNvalidate(cmbdesign, e, Me, cmbmerchant.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbcolor.Text.Trim = "" And cmbdyeing.Text.Trim <> "" And cmbdesign.Text.Trim = "" Then
                fillCOLOR(cmbcolor, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID ", " AND DYEINGRECIPE.DYEING_NO='" & cmbdyeing.Text & "'")
            ElseIf cmbcolor.Text.Trim = "" And cmbdesign.Text.Trim <> "" Then
                fillCOLOR(cmbcolor, "  INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesign.Text & "'")
            Else
                fillCOLOR(cmbcolor)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbcolor.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" And cmbdesign.Text.Trim = "" Then
                COLORvalidate(cmbcolor, e, Me, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID", " AND  DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")
            ElseIf cmbcolor.Text.Trim <> "" And cmbdesign.Text.Trim <> "" Then
                COLORvalidate(cmbcolor, e, Me, " INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesign.Text & "'")
            Else
                COLORvalidate(cmbcolor, e, Me)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbquality_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbquality.Enter
        Try
            If cmbquality.Text.Trim = "" Then fillQUALITY(cmbquality, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbquality_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbquality.Validating
        Try
            If cmbquality.Text.Trim <> "" Then QUALITYVALIDATE(cmbquality, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim TEMPMSG As Integer = MsgBox("Print Report in Excel Format?", MsgBoxStyle.YesNo)
        If TEMPMSG = vbYes Then
            Dim objrep As New clsReportDesigner("OPENING REPORT", System.AppDomain.CurrentDomain.BaseDirectory & "OPENINGREPORT.xlsx", 2)

            Dim CONDITION As String = ""
           
            objrep.OPENING_Report(cmbtype.Text, CmpId, Locationid, YearId, CONDITION)
        End If
    End Sub

    Private Sub gridstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridstock.KeyDown
        If gridstock.Rows.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                gridstock.Rows.RemoveAt(gridstock.CurrentRow.Index)
            End If
            'If gridstock.Rows(gridstock.CurrentRow.Index).Cells(gOutpcs.Index).Value = 0 Then
            '    gridstock.Rows.RemoveAt(gridstock.CurrentRow.Index)
            'End If
        End If
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTSEARCHLOTNO_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSEARCHLOTNO.Validated
        For Each ROW As DataGridViewRow In gridstock.Rows
            If LCase(ROW.Cells(GLOTNO.Index).Value) = LCase(TXTSEARCHLOTNO.Text.Trim) Then
                gridstock.FirstDisplayedScrollingRowIndex = ROW.Index
                gridstock.Rows(ROW.Index).Selected = True
                TXTSEARCHLOTNO.Clear()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txtMtrs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMtrs.KeyPress, txtpcs.KeyPress, TXTWT.KeyPress, txtcut.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class