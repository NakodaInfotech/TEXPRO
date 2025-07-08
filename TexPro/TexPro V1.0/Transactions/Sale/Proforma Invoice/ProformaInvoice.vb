
Imports BL
Imports System.Windows.Forms

Public Class ProformaInvoice

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public Shared selectsotable As New DataTable
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Dim gridUPLOADdoubleclick As Boolean
    Public edit As Boolean
    Public tempinvoiceno As String

    Public tempMsg As Integer
    Dim tempUPLOADrow As Integer

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbformno.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)

            alParaval.Add(CMBCONSIGNEE.Text.Trim)
            alParaval.Add(INVOICEdate.Value)

            alParaval.Add(txtdeliveryadd.Text)
            alParaval.Add(TXTREFNO.Text.Trim)
            alParaval.Add(TXTGDNNO.Text.Trim)
            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(podate.Value)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)

            alParaval.Add(lbltotalqty.Text.Trim)
            alParaval.Add(lbltotalmtrs.Text.Trim)
            alParaval.Add(lbltotalamt.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)



            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(txttransremarks.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

            If lbllocked.Visible = False Then
                alParaval.Add(0)    'PO DONE
            Else
                alParaval.Add(1)    'PO DONE
            End If


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim psno As String = ""
            Dim fbno As String = ""
            Dim PIECETYPE As String = ""
            Dim MERCHANT As String = ""
            Dim CUT As String = ""
            Dim quality As String = ""

            Dim qty As String = ""
            Dim mtrs As String = ""
            Dim WT As String = ""
            Dim PER As String = ""
            Dim rate As String = ""
            Dim amount As String = ""
            Dim INVOICEDONE As String = ""
            Dim gdngridsrno As String = ""


            For Each row As Windows.Forms.DataGridViewRow In gridinvoice.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        psno = row.Cells(gbaleno.Index).Value.ToString
                        fbno = row.Cells(gfbno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        MERCHANT = row.Cells(GMERCHANT.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value
                        quality = row.Cells(gQuality.Index).Value.ToString

                        qty = row.Cells(GQTY.Index).Value
                        mtrs = row.Cells(GMTRS.Index).Value
                        WT = row.Cells(gwt.Index).Value
                        PER = row.Cells(gPer.Index).Value
                        rate = row.Cells(grate.Index).Value
                        amount = row.Cells(gamt.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            INVOICEDONE = 1
                        Else
                            INVOICEDONE = 0
                        End If
                        gdngridsrno = row.Cells(ggdngridsrno.Index).Value

                    Else

                        gridsrno = gridsrno & "," & row.Cells(GSRNO.Index).Value
                        psno = psno & "," & row.Cells(gbaleno.Index).Value.ToString
                        fbno = fbno & "," & row.Cells(gfbno.Index).Value.ToString
                        PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value.ToString
                        MERCHANT = MERCHANT & "," & row.Cells(GMERCHANT.Index).Value
                        CUT = CUT & "," & row.Cells(GCUT.Index).Value
                        quality = quality & "," & row.Cells(gQuality.Index).Value.ToString

                        qty = qty & "," & row.Cells(GQTY.Index).Value
                        mtrs = mtrs & "," & row.Cells(GMTRS.Index).Value
                        WT = WT & "," & row.Cells(gwt.Index).Value
                        PER = PER & "," & row.Cells(gPer.Index).Value
                        rate = rate & "," & row.Cells(grate.Index).Value
                        amount = amount & "," & row.Cells(gamt.Index).Value


                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            INVOICEDONE = INVOICEDONE & "," & " 1"
                        Else
                            INVOICEDONE = INVOICEDONE & "," & " 0"
                        End If
                        gdngridsrno = gdngridsrno & "," & row.Cells(ggdngridsrno.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(psno)
            alParaval.Add(fbno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(MERCHANT)
            alParaval.Add(CUT)
            alParaval.Add(quality)

            alParaval.Add(qty)
            alParaval.Add(mtrs)
            alParaval.Add(WT)
            alParaval.Add(PER)
            alParaval.Add(rate)
            alParaval.Add(amount)
            alParaval.Add(INVOICEDONE)
            alParaval.Add(gdngridsrno)


            Dim objclsPurord As New ClsProformaInvoice()
            objclsPurord.alParaval = alParaval



            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsPurord.save()

                MessageBox.Show("Details Added")

            Else
                alParaval.Add(tempinvoiceno)

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsPurord.Update()
                MessageBox.Show("Details Updated")
                edit = False

            End If
            tempMsg = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            If tempMsg = vbYes Then
                Dim OBJINVOICE As New InvoiceDesign
                OBJINVOICE.INVOICE = False
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.FORMULA = "{PROFORMAINVOICEMASTER.INVOICE_no}=" & Val(TXTINVOICENO.Text) & " and {PROFORMAINVOICEMASTER.INVOICE_cmpid}=" & CmpId & " and {PROFORMAINVOICEMASTER.INVOICE_locationid}=" & Locationid & " and {PROFORMAINVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If
            clear()
            cmbname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXIT.Click
        Me.Close()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        TXTBALENO.Clear()
        cmbname.Text = ""
        txtpono.Clear()
        CMBCONSIGNEE.Text = ""
        CMBAGENT.Text = ""
        cmbcity.Text = ""

        INVOICEdate.Value = Mydate
        txtdeliveryadd.Clear()
        TXTREFNO.Text = ""


        EP.Clear()
        cmbtrans.Text = ""
        txttransref.Clear()
        TXTTRANSADD.Clear()
        txttransremarks.Clear()
        txtlrno.Clear()
        lrdate.Value = Mydate
        lbllocked.Visible = False
        PBlock.Visible = False

        txtremarks.Clear()
        txtinwordedu.Clear()
        txtinwordexcise.Clear()
        txtinwordhse.Clear()
        txtinwords.Clear()
        txtadd.Clear()

        lbltotalamt.Text = 0.0
        lbltotalmtrs.Text = 0.0
        lbltotalqty.Text = 0.0

        gridinvoice.RowCount = 0
        getmax_INVOICE_no()
        gridDoubleClick = False
        gridDoubleClick = False
        gridUPLOADdoubleclick = False

    End Sub

    Sub getmax_INVOICE_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(INVOICE_no),0) + 1 ", "PROFORMAINVOICEMASTER", " AND INVOICE_cmpid=" & CmpId & " and INVOICE_locationid=" & Locationid & " and INVOICE_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTINVOICENO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub total()
        lbltotalamt.Text = 0.0
        lbltotalqty.Text = 0.0
        lbltotalmtrs.Text = 0.0
        If gridinvoice.RowCount > 0 Then
            For Each row As DataGridViewRow In gridinvoice.Rows
                If row.Cells(gPer.Index).EditedFormattedValue = "PCS" Then
                    row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).EditedFormattedValue) * Val(row.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                ElseIf row.Cells(gPer.Index).EditedFormattedValue = "MTRS" Then
                    row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).EditedFormattedValue) * Val(row.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                ElseIf row.Cells(gPer.Index).EditedFormattedValue = "WT" Then
                    row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).EditedFormattedValue) * Val(row.Cells(gwt.Index).EditedFormattedValue), "0.00")
                End If

                If Val(row.Cells(GQTY.Index).Value) <> 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GMTRS.Index).Value) <> 0 Then lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(row.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(gamt.Index).Value) <> 0 Then lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(gamt.Index).EditedFormattedValue), "0.00")
            Next
            If Val(lbltotalamt.Text) > 0 Then txtinwords.Text = NumToWord(Val(lbltotalamt.Text))
        Else
            lbltotalqty.Text = "0.00"
            lbltotalamt.Text = "0.00"
        End If
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If


        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "PROFORMA Raised, Delete PROFORMA First")
            bln = False

        End If
        Return bln
    End Function

    Private Sub PROFORMAINVOICEMASTER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()
            cmbname.Enabled = True

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim objclsINVOICE As New ClsProformaInvoice()
                Dim dt_po As DataTable = objclsINVOICE.selectINVOICE(tempinvoiceno, CmpId, Locationid, YearId)


                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows


                        TXTINVOICENO.Text = dr("INVOICENO")
                        INVOICEdate.Value = Convert.ToDateTime(dr("INVOICEdate"))


                        cmbname.Text = Convert.ToString(dr("NAME"))
                        txtadd.Text = Convert.ToString(dr("ADD"))
                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        CMBCONSIGNEE.Text = Convert.ToString(dr("CONSIGNEE"))
                        cmbcity.Text = Convert.ToString(dr("CITY"))

                        txtpono.Text = Convert.ToString(dr("poNO"))
                        TXTGDNNO.Text = Convert.ToString(dr("GDNNO"))
                        TXTREFNO.Text = Convert.ToString(dr("SONO"))
                        podate.Value = Convert.ToDateTime(dr("POdate"))


                        gridinvoice.Rows.Add(dr("GRIDSRNO"), dr("PSNO"), dr("FBNO"), dr("PIECETYPE").ToString, dr("MERCHANT").ToString, Format(Val(dr("CUT")), "0.00"), dr("QUALITY").ToString, Format(Val(dr("PCS")), "0.00"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("WT")), "0.00"), dr("PER").ToString, Format(Val(dr("rate")), "0.00"), Format(Val(dr("amt")), "0.00"), dr("GRIDDONE").ToString, dr("GDNGRIDSRNO").ToString)

                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("transrefno").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txttransremarks.Text = dr("transremarks").ToString
                        If dr("DONE").ToString = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                    Next
                    gridinvoice.FirstDisplayedScrollingRowIndex = gridinvoice.RowCount - 1

                    For Each row As DataGridViewRow In gridinvoice.Rows
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then 'row.Cells(16).Value <> "" Or
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
                            cmbname.Enabled = False
                        End If
                    Next



                End If
                chkchange.CheckState = CheckState.Checked
                total()

            End If



        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
            If CMBCONSIGNEE.Text.Trim = "" Then FILLCONSIGNEE()
            If cmbcity.Text.Trim = "" Then fillcity(cmbcity)
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False

        cmbname.Focus()
    End Sub

    Private Sub PROFORMAINVOICEMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdOK_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
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

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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
                    MsgBox("Unable to Delete, Proforma Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                tempMsg = MsgBox("Delete PROFORMA ?", MsgBoxStyle.YesNo)
                If tempMsg = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTINVOICENO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim clspo As New ClsProformaInvoice()
                    clspo.alParaval = alParaval
                    IntResult = clspo.Delete()
                    MsgBox("PROFORMA Deleted")
                    clear()
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridINVOICE_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridinvoice.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = gridinvoice.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, GQTY.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridinvoice.CurrentCell.Value = Nothing Then gridinvoice.CurrentCell.Value = "0.00"
                    gridinvoice.CurrentCell.Value = Convert.ToDecimal(gridinvoice.Item(colNum, e.RowIndex).Value)
                    If Convert.ToString(gridinvoice.Rows(e.RowIndex).Cells(gPer.Index).EditedFormattedValue) = "PCS" Then
                        gridinvoice.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridinvoice.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridinvoice.Rows(e.RowIndex).Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    ElseIf Convert.ToString(gridinvoice.Rows(e.RowIndex).Cells(gPer.Index).EditedFormattedValue) = "MTRS" Then
                        gridinvoice.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridinvoice.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridinvoice.Rows(e.RowIndex).Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    ElseIf Convert.ToString(gridinvoice.Rows(e.RowIndex).Cells(gPer.Index).EditedFormattedValue) = "WT" Then
                        gridinvoice.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridinvoice.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridinvoice.Rows(e.RowIndex).Cells(gwt.Index).EditedFormattedValue), "0.00")
                    End If

                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                total()
            Case gPer.Index
                If gridinvoice.Rows(e.RowIndex).Cells(gPer.Index).EditedFormattedValue = "PCS" Then
                    gridinvoice.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridinvoice.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridinvoice.Rows(e.RowIndex).Cells(GQTY.Index).EditedFormattedValue), "0.00")
                ElseIf gridinvoice.Rows(e.RowIndex).Cells(gPer.Index).EditedFormattedValue = "MTRS" Then
                    gridinvoice.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridinvoice.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridinvoice.Rows(e.RowIndex).Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                ElseIf gridinvoice.Rows(e.RowIndex).Cells(gPer.Index).EditedFormattedValue = "WT" Then
                    gridinvoice.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridinvoice.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridinvoice.Rows(e.RowIndex).Cells(gwt.Index).EditedFormattedValue), "0.00")
                End If

                For I As Integer = gridinvoice.CurrentRow.Index + 1 To gridinvoice.RowCount - 1
                    gridinvoice.Item(gPer.Index, I).Value = gridinvoice.Item(gPer.Index, I - 1).EditedFormattedValue
                Next
                total()

        End Select
    End Sub

    Private Sub gridINVOICE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridinvoice.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridinvoice.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                gridinvoice.Rows.RemoveAt(gridinvoice.CurrentRow.Index)
                total()
                getsrno(gridinvoice)
                total()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridinvoice.RowCount = 0
            tempinvoiceno = Val(tstxtbillno.Text)
            If tempinvoiceno > 0 Then
                edit = True
                PROFORMAINVOICEMASTER_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolprevious.Click
        Try
            gridinvoice.RowCount = 0
            tempinvoiceno = Val(TXTINVOICENO.Text) - 1

            If tempinvoiceno > 0 Then
                edit = True
                PROFORMAINVOICEMASTER_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridinvoice.RowCount = 0
            tempinvoiceno = Val(TXTINVOICENO.Text) + 1
            getmax_INVOICE_no()
            clear()

            If Val(TXTINVOICENO.Text) - 1 >= tempinvoiceno Then
                edit = True
                PROFORMAINVOICEMASTER_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                Dim OBJINVOICE As New InvoiceDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.INVOICE = False
                If chkprintsingle.Checked = True Then OBJINVOICE.SIN = True
                OBJINVOICE.FORMULA = "{proformainvoicemaster.INVOICE_no}=" & Val(TXTINVOICENO.Text) & " and {proformainvoicemaster.INVOICE_cmpid}=" & CmpId & " and {proformainvoicemaster.INVOICE_locationid}=" & Locationid & " and {proformainvoicemaster.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If
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

    Private Sub cmdselectOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectOrder.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            selectsotable.Clear()
            Dim OBJSELECTPO As New SelectPs
            OBJSELECTPO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTPO.FRMSTR = "PROFORMA"
            OBJSELECTPO.ShowDialog()


            Dim i As Integer = 0
            If selectsotable.Rows.Count > 0 Then
                chkchange.Checked = True

                For i = 0 To selectsotable.Rows.Count - 1
                    'cmbname.Text = selectsotable.Rows(i).Item("NAME")
                    'TXTGDNNO.Text = selectsotable.Rows(i).Item("GDNNO")
                    'CMBCONSIGNEE.Text = selectsotable.Rows(i).Item("consignee")
                    'cmbtrans.Text = selectsotable.Rows(i).Item("transname")

                    'txtagent.Text = selectsotable.Rows(i).Item("agent")
                    'txtpono.Text = selectsotable.Rows(i).Item("pono")
                    'podate.Value = Convert.ToDateTime(selectsotable.Rows(i).Item("podate"))

                    'GETTING TOP RATE FROM MERCHANTMASTER
                    Dim RATE As Double = 0
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("  TOP (1) ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) AS RATE", "", " ITEMMASTER INNER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID ", " AND ITEMMASTER.ITEM_NAME = '" & selectsotable.Rows(i).Item("merchant") & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER.ITEM_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        RATE = Format(Val(DT.Rows(0).Item("RATE")), "0.00")
                    End If

                    gridinvoice.Rows.Add(0, selectsotable.Rows(i).Item("BALENO"), selectsotable.Rows(i).Item("FBNO"), selectsotable.Rows(i).Item("piecetype"), selectsotable.Rows(i).Item("merchant"), selectsotable.Rows(i).Item("cut"), selectsotable.Rows(i).Item("QUALITY"), Format(Val(selectsotable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectsotable.Rows(i).Item("MTRS")), "0.00"), Format(Val(selectsotable.Rows(i).Item("WT")), "0.00"), "PCS", RATE, 0, 0, 0)
                Next
                gridinvoice.FirstDisplayedScrollingRowIndex = gridinvoice.RowCount - 1
                getsrno(gridinvoice)
                cmbname.Focus()
            End If
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCONSIGNEE()
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCONSIGNEE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DISTINCT ADDRESS_alias ", "", "   ADDRESSMASTER  ", "  and  ADDRESS_cmpid=" & CmpId & " and ADDRESS_Locationid=" & Locationid & " and ADDRESS_Yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ADDRESS_alias"
                    CMBCONSIGNEE.DataSource = dt
                    CMBCONSIGNEE.DisplayMember = "ADDRESS_alias"
                End If
                CMBCONSIGNEE.SelectAll()
                CMBCONSIGNEE.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCONSIGNEE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCONSIGNEE.GotFocus
        Try
            FILLCONSIGNEE()
            
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBCONSIGNEE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCONSIGNEE.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCONSIGNEE.Text.Trim <> "" Then
                pcase(CMBCONSIGNEE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ADDRESS_full", "", " ADDRESSMASTER  ", "  and ADDRESS_alias = '" & CMBCONSIGNEE.Text.Trim & "' and ADDRESS_cmpid = " & CmpId & " and ADDRESS_Locationid = " & Locationid & " and ADDRESS_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCONSIGNEE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("ADDRESS not present, Add New?", MsgBoxStyle.YesNo, CmpName)
                    If tempmsg = vbYes Then

                        CMBCONSIGNEE.Text = a
                        Dim objADDRESSmaster As New addressMaster
                        objADDRESSmaster.txtname.Text = CMBCONSIGNEE.Text
                        objADDRESSmaster.cmbname.Text = cmbname.Text
                        objADDRESSmaster.cmbname.Enabled = False
                        objADDRESSmaster.ShowDialog()
                        dt = objclscommon.search("ADDRESS_alias", "", "ADDRESSMaster", " and ADDRESS_alias = '" & CMBCONSIGNEE.Text.Trim & "' and ADDRESS_cmpid = " & CmpId & " and ADDRESS_Locationid = " & Locationid & " and ADDRESS_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBCONSIGNEE.DataSource
                            If CMBCONSIGNEE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCONSIGNEE.Text.Trim)
                                    CMBCONSIGNEE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtdeliveryadd.Text = dt.Rows(0).Item(0).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Private Sub TXTBALENO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBALENO.Validating
        Try
            If TXTBALENO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOP 1 INVOICE_NO AS INVOICENO ", "", " PROFORMAINVOICEMASTER_DESC", " AND INVOICE_CMPID = " & CmpId & " AND INVOICE_LOCATIONID = " & Locationid & " AND INVOICE_YEARID = " & YearId & " AND INVOICE_PSNO = '" & TXTBALENO.Text.Trim & "'")
                If DT.Rows.Count > 0 Then
                    tstxtbillno.Text = DT.Rows(0).Item(0)
                    Call tstxtbillno_Validating(sender, e)
                Else
                    MsgBox("Bale No not Present", MsgBoxStyle.Critical)
                    TXTBALENO.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim objINVOICE As New ProformaInvoiceDetails
            objINVOICE.MdiParent = MDIMain
            objINVOICE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUP_SECONDARY = 'Sundry Debtors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(TRANSLEDGERS.Acc_cmpname,'') AS TRANSNAME, ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENTNAME, ISNULL(CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON LEDGERS.ACC_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON LEDGERS.ACC_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbtrans.Text = DT.Rows(0).Item("TRANSNAME")
                    CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    cmbcity.Text = DT.Rows(0).Item("CITYNAME")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUP_SECONDARY = 'Sundry Debtors'", "Sundry Debtors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then fillcity(cmbcity)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then CITYVALIDATE(cmbcity, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, e, Me, txtadd, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class