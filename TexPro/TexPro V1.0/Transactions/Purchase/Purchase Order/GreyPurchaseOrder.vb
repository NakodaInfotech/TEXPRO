
Imports System.ComponentModel
Imports System.IO
Imports BL

Public Class GreyPurchaseOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPPONO As Integer
    Dim ALLOWMANUALPONO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub getmax_po_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(po_no),0) + 1 ", "GREYPURCHASEORDER", " and po_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE  = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE  = 'TRANSPORT'", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        If ALLOWMANUALPONO = True Then
            TXTPONO.ReadOnly = False
            TXTPONO.BackColor = Color.LemonChiffon
        Else
            TXTPONO.ReadOnly = True
            TXTPONO.BackColor = Color.Linen
        End If


        tstxtbillno.Clear()
        cmbname.Text = ""
        cmbname.Enabled = True
        TXTMOBILENO.Clear()

        txtdiscount.Clear()
        txtquotation.Clear()
        quotationdate.Value = Now.Date
        PODATE.Text = Now.Date
        txtRefno.Clear()
        TXTDELPERIOD.Clear()
        duedate.Value = Now.Date
        TXTCRDAYS.Clear()
        CMBTRANS.Text = ""
        CMBBROKER.Text = ""

        txtsrno.Text = 1
        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        txtrate.Clear()
        TXTAMOUNT.Clear()
        EP.Clear()

        CHKVERIFY.CheckState = CheckState.Checked
        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        PBlock.Visible = False
        txtremarks.Clear()
        txtinwordedu.Clear()
        txtinwordexcise.Clear()
        txtinwordhse.Clear()
        txtinwords.Clear()
        txtadd.Clear()
        lbltotalamt.Text = "0.00"
        lbltotalqty.Text = "0.00"
        LBLTOTALMTRS.Text = 0
        gridpo.RowCount = 0
        getmax_po_no()
        cmdselectQuot.Enabled = True
        GRIDDOUBLECLICK = False

        txtbillamt.Text = 0.0
        txtdisper.Text = 0.0
        txtdisamt.Text = 0.0
        txtpfper.Text = 0.0
        txtpfamt.Text = 0.0
        txttestchgs.Text = 0.0
        txtnett.Text = 0.0

        TXTEXCISE.Text = 0.0
        txtexciseAMT.Text = 0.0

        TXTEDUCESS.Text = 0.0
        txteducessAMT.Text = 0.0

        TXTHSECESS.Text = 0.0
        txthsecessAMT.Text = 0.0

        txtsubtotal.Text = 0.0

        cmbtax.Text = ""
        txttax.Text = 0.0

        cmbaddtax.Text = ""
        txtaddtax.Text = 0.0

        txtfrper.Text = 0.0
        txtfreight.Text = 0.0

        cmboctroi.Text = ""
        txtoctroi.Text = 0.0

        txtinspchgs.Text = 0.0
        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0
        txtremarks.Clear()


        chkexcise.Checked = False
        getexcise()

        TXTCITY.Clear()
        CMBORDERTYPE.SelectedIndex = 0

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbname.Focus()
    End Sub

    Private Sub GreyPurchaseOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                gridpo.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call TOOLPREVIOUS_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call TOOLNEXT_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call TOOLPRINT_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS'")
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            fillagentledger(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
            fillQUALITY(CMBQUALITY, EDIT)
            fillunit(cmbqtyunit)
            fillname(CMBTRANS, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE  = 'TRANSPORT'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GreyPurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            If ClientName = "SUPRIYA" Then ALLOWMANUALPONO = True
            fillcmb()
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim objclsPO As New ClsGreyPurchaseOrder()
                Dim DTPO As DataTable = objclsPO.SELECTPO(TEMPPONO, CmpId, Locationid, YearId)
                If DTPO.Rows.Count > 0 Then
                    For Each dr As DataRow In DTPO.Rows

                        TXTPONO.Text = dr("PONO")
                        TXTPONO.ReadOnly = True

                        PODATE.Text = Format(Convert.ToDateTime(dr("PODATE")), "dd/MM/yyyy")
                        TXTCRDAYS.Text = Val(dr("CRDAYS"))
                        TXTDELPERIOD.Text = Val(dr("DELDAYS"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))


                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTMOBILENO.Text = Convert.ToString(dr("MOBILENO"))
                        txtdiscount.Text = Convert.ToString(dr("DISCOUNT"))

                        txtquotation.Text = Convert.ToString(dr("QUOTNO"))
                        txtRefno.Text = Convert.ToString(dr("REFNO"))
                        quotationdate.Value = Convert.ToDateTime(dr("QUOTDATE"))

                        CMBTRANS.Text = Convert.ToString(dr("TRANSNAME"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        CMBBROKER.Text = Convert.ToString(dr("BROKER"))
                        CMBORDERTYPE.Text = Convert.ToString(dr("ORDERTYPE"))
                        TXTCITY.Text = Convert.ToString(dr("CITYNAME"))

                        gridpo.Rows.Add(Val(dr("POGRIDSRNO")), dr("ITEMNAME"), dr("QUALITY"), Format(Val(dr("POQTY")), "0.00"), dr("Unit"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("rate")), "0.00"), dr("PER"), Format(Val(dr("amt")), "0.00"), Val(dr("RECDQTY")), dr("GRIDPODONE"), dr("CLOSED"))

                        txtdisper.Text = dr("PO_DISPER")
                        txtdisamt.Text = dr("PO_DISAMT")
                        txtpfper.Text = dr("PO_PFPER")
                        txtpfamt.Text = dr("PO_PFAMT")
                        txttestchgs.Text = dr("PO_TESTCHGS")
                        txtnett.Text = dr("PO_NETT")

                        txtsubtotal.Text = dr("PO_SUBTOTAL")
                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("PO_TAXAMT")
                        cmbaddtax.Text = dr("ADDTAXNAME")
                        txtaddtax.Text = dr("PO_ADDTAXAMT")
                        txtfrper.Text = dr("PO_FRPER")
                        txtfreight.Text = dr("PO_FREIGHT")
                        cmboctroi.Text = dr("OCTROINAME")
                        txtoctroi.Text = dr("PO_OCTROIAMT")
                        txtinspchgs.Text = dr("PO_INSAMT")
                        txtroundoff.Text = dr("PO_ROUNDOFF")
                        txtgrandtotal.Text = dr("PO_GRANDTOTAL")

                        If Convert.ToBoolean(dr("VERIFIED")) = True Then CHKVERIFY.CheckState = CheckState.Checked


                        If Val(dr("RECDQTY")) > 0 Or Val(dr("RECDMTRS")) > 0 Then
                            gridpo.Rows(gridpo.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            cmbname.Enabled = False
                            cmdselectQuot.Enabled = False
                        End If


                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            gridpo.Rows(gridpo.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1

                End If
                chkchange.CheckState = CheckState.Checked
                TOTAL()
            Else
                EDIT = False
                clear()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBBROKER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBROKER.Enter
        Try
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKER.Validating
        Try
            If CMBBROKER.Text.Trim <> "" Then namevalidate(CMBBROKER, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT' ", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTPONO.ReadOnly = False Then
                alParaval.Add(Val(TXTPONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(PODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(duedate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(Val(TXTDELPERIOD.Text.Trim))
            alParaval.Add(txtRefno.Text.Trim)
            alParaval.Add(txtquotation.Text.Trim)
            alParaval.Add(quotationdate.Value)
            alParaval.Add(txtdiscount.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBORDERTYPE.Text.Trim)
            alParaval.Add(Val(lbltotalqty.Text.Trim))
            alParaval.Add(Val(LBLTOTALMTRS.Text.Trim))
            alParaval.Add(Val(lbltotalamt.Text.Trim))


            alParaval.Add(txtdisper.Text.Trim)
            alParaval.Add(txtdisamt.Text.Trim)
            alParaval.Add(txtpfper.Text.Trim)
            alParaval.Add(txtpfamt.Text.Trim)
            alParaval.Add(txttestchgs.Text.Trim)
            alParaval.Add(txtnett.Text.Trim)
            alParaval.Add(Val(TXTEXCISEID.Text.Trim))
            alParaval.Add(TXTEXCISE.Text.Trim)
            alParaval.Add(txtexciseAMT.Text.Trim)
            alParaval.Add(TXTEDUCESS.Text.Trim)
            alParaval.Add(txteducessAMT.Text.Trim)
            alParaval.Add(TXTHSECESS.Text.Trim)
            alParaval.Add(txthsecessAMT.Text.Trim)
            alParaval.Add(txtsubtotal.Text.Trim)
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(txttax.Text.Trim)
            alParaval.Add(cmbaddtax.Text.Trim)
            alParaval.Add(txtaddtax.Text.Trim)
            alParaval.Add(txtfrper.Text.Trim)
            alParaval.Add(txtfreight.Text.Trim)
            alParaval.Add(cmboctroi.Text.Trim)
            alParaval.Add(txtoctroi.Text.Trim)
            alParaval.Add(txtinspchgs.Text.Trim)
            alParaval.Add(txtroundoff.Text.Trim)
            alParaval.Add(txtgrandtotal.Text.Trim)

            If lbllocked.Visible = False Then alParaval.Add(0) Else alParaval.Add(1) 'PO DONE

            alParaval.Add(CHKVERIFY.Checked)    'VERIFIED (keep verified for everyone)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim MTRS As String = ""
            Dim rate As String = ""
            Dim PER As String = ""
            Dim amount As String = ""
            Dim recdqty As String = ""      'Qty recd in GRN
            Dim GRNDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim CLOSED As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridpo.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        rate = row.Cells(grate.Index).Value
                        PER = row.Cells(gper.Index).Value.ToString
                        amount = row.Cells(gamt.Index).Value
                        recdqty = row.Cells(grecdqty.Index).Value
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then GRNDONE = 1 Else GRNDONE = 0
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
                        rate = rate & "|" & row.Cells(grate.Index).Value
                        PER = PER & "|" & row.Cells(gper.Index).Value.ToString
                        amount = amount & "|" & row.Cells(gamt.Index).Value
                        recdqty = recdqty & "|" & row.Cells(grecdqty.Index).Value
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then GRNDONE = GRNDONE & "|" & "1" Else GRNDONE = GRNDONE & "|" & "0"
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(PER)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(rate)
            alParaval.Add(amount)
            alParaval.Add(recdqty)
            alParaval.Add(GRNDONE)
            alParaval.Add(CLOSED)

            alParaval.Add(txtinwords.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)

            Dim objclsPurord As New ClsGreyPurchaseOrder()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTPONO.Text = DT.Rows(0).Item(0)
            Else
                alParaval.Add(TEMPPONO)

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT()

            clear()
            cmbname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If


        If ClientName <> "MOMAI" Then
            For Each row As DataGridViewRow In gridpo.Rows
                If Val(row.Cells(GMTRS.Index).Value) = 0 Then
                    EP.SetError(txtqty, "Mtrs Cannot be 0")
                    bln = False
                End If
            Next
        End If

        If ALLOWMANUALPONO = True Then
            If TXTPONO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(GREYPURCHASEORDER.PO_NO,0)  AS PONO", "", " GREYPURCHASEORDER ", "  AND GREYPURCHASEORDER.PO_NO=" & Val(TXTPONO.Text.Trim) & " AND GREYPURCHASEORDER.PO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTPONO, "Purchase Order No Already Exist")
                    bln = False
                End If
            End If
        End If


        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked")
            bln = False
        End If


        If PODATE.Text = "__/__/____" Then
            EP.SetError(PODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(PODATE.Text) Then
                EP.SetError(PODATE, "Date not in Accounting Year")
                bln = False
            End If
        End If
        TOTAL()
        Return bln
    End Function

    Sub TOTAL()

        Dim temptaxper As Double = 0
        Dim tempaddtaxper As Double = 0
        Dim tempoctroitaxper As Double = 0

        lbltotalqty.Text = "0.00"
        LBLTOTALMTRS.Text = 0
        lbltotalamt.Text = "0.00"

        txtbillamt.Text = 0.0
        txtdisamt.Text = 0.0
        txtpfamt.Text = 0.0
        txtnett.Text = 0.0

        txtexciseAMT.Text = 0.0
        txteducessAMT.Text = 0.0
        txthsecessAMT.Text = 0.0

        txtsubtotal.Text = 0.0

        txttax.Text = 0.0
        txtaddtax.Text = 0.0
        If Val(txtfrper.Text.Trim) > 0 Then txtfreight.Text = 0.0
        txtoctroi.Text = 0.0

        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0


        For Each row As DataGridViewRow In gridpo.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).Value), "0.00")
            If Val(row.Cells(GMTRS.Index).Value) <> 0 Then LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(GMTRS.Index).Value), "0.00")

            If Val(row.Cells(grate.Index).Value) <> 0 Then
                If ClientName = "AVIS" Then
                    If CMBPER.Text = "Pcs" Then row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).Value) * Val(row.Cells(gQty.Index).Value), "0.00") Else row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).Value) * Val(row.Cells(GMTRS.Index).Value), "0.00")
                Else
                    row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).Value) * Val(row.Cells(GMTRS.Index).Value), "0.00")
                End If
            End If

            If Val(row.Cells(gamt.Index).Value) <> 0 Then lbltotalamt.Text = Val(lbltotalamt.Text) + Val(row.Cells(gamt.Index).Value)
        Next

        txtbillamt.Text = Val(lbltotalamt.Text.Trim)
        txtdisamt.Text = (Val(txtdisper.Text) * Val(txtbillamt.Text)) / 100
        txtpfamt.Text = (Val(txtpfper.Text) * Val(txtbillamt.Text)) / 100

        txtnett.Text = (txtbillamt.Text) - Val(txtdisamt.Text) + Val(txtpfamt.Text) + Val(txttestchgs.Text)

        txtexciseAMT.Text = (Val(TXTEXCISE.Text) * Val(txtnett.Text)) / 100
        txteducessAMT.Text = Val((Val(TXTEDUCESS.Text) * Val(txtexciseAMT.Text)) / 100)
        txthsecessAMT.Text = (Val(TXTHSECESS.Text) * Val(txtexciseAMT.Text)) / 100

        txtsubtotal.Text = Val(txtnett.Text) + Val(txteducessAMT.Text) + Val(txtexciseAMT.Text) + Val(txthsecessAMT.Text)


        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then temptaxper = dt.Rows(0).Item(1)

        dt.Reset()
        dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbaddtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then tempaddtaxper = dt.Rows(0).Item(1)

        txttax.Text = (Val(temptaxper) * Val(txtsubtotal.Text)) / 100
        txtaddtax.Text = (Val(tempaddtaxper) * Val(txtsubtotal.Text)) / 100
        If Val(txtfrper.Text.Trim) > 0 Then txtfreight.Text = (Val(txtfrper.Text) * Val(txtbillamt.Text)) / 100

        dt.Reset()
        dt = objclscommon.search("OCTROI_NAME,OCTROI_octroi", "", "OCTROIMaster", " and OCTROI_NAME = '" & cmboctroi.Text.Trim & "' and OCTROI_cmpid = " & CmpId & " and OCTROI_Locationid = " & Locationid & " and OCTROI_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then tempoctroitaxper = dt.Rows(0).Item(1)

        txtoctroi.Text = (Val(tempoctroitaxper) * (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text))) / 100
        txtgrandtotal.Text = Format(Val(txtoctroi.Text) + Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text) + Val(txtinspchgs.Text), "0")

        txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text) + Val(txtoctroi.Text) + Val(txtinspchgs.Text)), "0.00")
        txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

        If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
        If Val(txtexciseAMT.Text) > 0 Then txtinwordexcise.Text = CurrencyToWord(txtexciseAMT.Text)
        If Val(txteducessAMT.Text) > 0 Then txtinwordedu.Text = CurrencyToWord(txteducessAMT.Text)
        If Val(txthsecessAMT.Text) > 0 Then txtinwordhse.Text = CurrencyToWord(txthsecessAMT.Text)


    End Sub

    Sub getexcise()
        'Try
        '    If chkexcise.CheckState = CheckState.Checked Then
        '        TXTEXCISEID.Text = 0
        '        TXTEXCISE.Text = 0.0
        '        TXTEDUCESS.Text = 0.0
        '        TXTHSECESS.Text = 0.0
        '        Dim objcmn As New ClsCommon
        '        Dim DT As DataTable = objcmn.search(" ISNULL(MAX(EXCISE_ID),0)", "", " EXCISEMASTER ", " AND EXCISE_wef <= '" & Format(podate.Value.Date, "MM/dd/yyyy") & "' AND EXCISE_CMPID = " & CmpId & " AND EXCISE_LOCATIONID = " & Locationid & " AND EXCISE_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then
        '            TXTEXCISEID.Text = DT.Rows(0).Item(0)
        '        End If

        '        DT.Reset()
        '        DT = objcmn.search(" EXCISE_NAME, EXCISE_EDU, EXCISE_HSE", "", " EXCISEMASTER", " AND EXCISE_ID = " & TXTEXCISEID.Text.Trim & "AND EXCISE_CMPID = " & CmpId & " AND EXCISE_LOCATIONID = " & Locationid & " AND EXCISE_YEARID = " & YearId)
        '        If DT.Rows.Count > 0 Then
        '            TXTEXCISE.Text = DT.Rows(0).Item(0)
        '            TXTEDUCESS.Text = DT.Rows(0).Item(1)
        '            TXTHSECESS.Text = DT.Rows(0).Item(2)
        '            total()
        '        End If
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If gridpo.RowCount > 0 Then
                txtsrno.Text = Val(gridpo.Rows(gridpo.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
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
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
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

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridpo.Enabled = True
        If GRIDDOUBLECLICK = False Then
            gridpo.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, Val(txtqty.Text.Trim), cmbqtyunit.Text.Trim, Val(TXTMTRS.Text.Trim), Val(txtrate.Text.Trim), CMBPER.Text.Trim, Val(TXTAMOUNT.Text.Trim), 0, 0, 0)
            getsrno(gridpo)
        ElseIf GRIDDOUBLECLICK = True Then
            gridpo.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            gridpo.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
            gridpo.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            gridpo.Item(gQty.Index, TEMPROW).Value = Val(txtqty.Text.Trim)
            gridpo.Item(gqtyunit.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
            gridpo.Item(GMTRS.Index, TEMPROW).Value = Val(TXTMTRS.Text.Trim)
            gridpo.Item(grate.Index, TEMPROW).Value = Val(txtrate.Text.Trim)
            gridpo.Item(gper.Index, TEMPROW).Value = CMBPER.Text
            gridpo.Item(gamt.Index, TEMPROW).Value = Val(TXTAMOUNT.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        gridpo.FirstDisplayedScrollingRowIndex = gridpo.RowCount - 1

        txtsrno.Text = gridpo.RowCount + 1
        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        txtrate.Clear()
        TXTAMOUNT.Clear()

        cmbitemname.Focus()

    End Sub

    Private Sub gridpo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpo.CellDoubleClick
        If e.RowIndex >= 0 And gridpo.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(gridpo.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(gridpo.Rows(e.RowIndex).Cells(GCLOSED.Index).Value) = True Then
                MsgBox("Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If


            GRIDDOUBLECLICK = True
            txtsrno.Text = gridpo.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = gridpo.Item(gitemname.Index, e.RowIndex).Value.ToString
            CMBQUALITY.Text = gridpo.Item(GQUALITY.Index, e.RowIndex).Value.ToString
            txtqty.Text = gridpo.Item(gQty.Index, e.RowIndex).Value.ToString
            cmbqtyunit.Text = gridpo.Item(gqtyunit.Index, e.RowIndex).Value.ToString
            TXTMTRS.Text = gridpo.Item(GMTRS.Index, e.RowIndex).Value.ToString
            txtrate.Text = gridpo.Item(grate.Index, e.RowIndex).Value.ToString
            CMBPER.Text = gridpo.Item(gper.Index, e.RowIndex).Value.ToString
            TXTAMOUNT.Text = gridpo.Item(gamt.Index, e.RowIndex).Value.ToString

            TEMPROW = e.RowIndex
            cmbitemname.Focus()
        End If
    End Sub

    Private Sub txtrate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        If cmbitemname.Text.Trim <> "" And CMBQUALITY.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And Val(TXTMTRS.Text.Trim) > 0 Then
            CALC()
            fillgrid()
            TOTAL()
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTMTRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdot(e, txtrate, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PODATE.GotFocus
        PODATE.SelectionStart = 0
    End Sub

    Private Sub PODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PODATE.Validating
        Try
            If PODATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PODATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
                    MsgBox("PO Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Order ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TEMPPONO)
                alParaval.Add(YearId)

                Dim clspo As New ClsGreyPurchaseOrder()
                clspo.alParaval = alParaval
                IntResult = clspo.DELETE()
                MsgBox("Purchase Order Deleted")
                clear()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ", "Sundry Debtors", "ACCOUNTS", CMBTRANS.Text, CMBBROKER.Text)
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_CRDAYS,0),  ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO, ISNULL(LEDGERS.ACC_EMAIL,'') AS EMAIL, ISNULL(CITYMASTER.city_name,'') AS CITYNAME", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id  ", " AND ledgers.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ledgers.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(TXTCRDAYS.Text.Trim) = 0 Then TXTCRDAYS.Text = Val(DT.Rows(0).Item(0))
                    TXTMOBILENO.Text = DT.Rows(0).Item("MOBILENO")
                    TXTEMAILADD.Text = DT.Rows(0).Item("EMAIL")
                    TXTCITY.Text = DT.Rows(0).Item("CITYNAME")
                End If
            End If

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

    Private Sub gridpo_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridpo.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = gridpo.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, gQty.Index, gamt.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridpo.CurrentCell.Value = Nothing Then gridpo.CurrentCell.Value = "0.00"
                    gridpo.CurrentCell.Value = Convert.ToDecimal(gridpo.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    gridpo.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(gridpo.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(gridpo.Rows(e.RowIndex).Cells(gQty.Index).EditedFormattedValue), "0.00")
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                total()

        End Select
    End Sub

    Sub EDITROW()
        Try
            If gridpo.CurrentRow.Index >= 0 And gridpo.Item(gsrno.Index, gridpo.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(gridpo.Rows(gridpo.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(gridpo.Rows(gridpo.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                txtsrno.Text = gridpo.Item(gsrno.Index, gridpo.CurrentRow.Index).Value.ToString
                cmbitemname.Text = gridpo.Item(gitemname.Index, gridpo.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = gridpo.Item(GQUALITY.Index, gridpo.CurrentRow.Index).Value.ToString
                txtqty.Text = gridpo.Item(gQty.Index, gridpo.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = gridpo.Item(gqtyunit.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = gridpo.Item(GMTRS.Index, gridpo.CurrentRow.Index).Value.ToString
                txtrate.Text = gridpo.Item(grate.Index, gridpo.CurrentRow.Index).Value.ToString
                CMBPER.Text = gridpo.Item(gper.Index, gridpo.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = gridpo.Item(gamt.Index, gridpo.CurrentRow.Index).Value.ToString

                TEMPROW = gridpo.CurrentRow.Index
                cmbitemname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpo.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridpo.RowCount > 0 Then

                If Convert.ToBoolean(gridpo.Rows(gridpo.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(gridpo.Rows(gridpo.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                gridpo.Rows.RemoveAt(gridpo.CurrentRow.Index)
                total()
                getsrno(gridpo)
                total()

            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And gridpo.RowCount > 0 Then
                If gridpo.CurrentRow.Cells(gitemname.Index).Value <> "" Then gridpo.Rows.Add(CloneWithValues(gridpo.CurrentRow))
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridpo.RowCount = 0
                TEMPPONO = Val(tstxtbillno.Text)
                If TEMPPONO > 0 Then
                    EDIT = True
                    GreyPurchaseOrder_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtdisper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdisper.KeyPress
        Try
            numdotkeypress(e, txtdisper, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtdisper_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdisper.Validated
        total()
    End Sub

    Private Sub txtfrper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfrper.KeyPress
        Try
            numdotkeypress(e, txtfrper, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtfrper_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfrper.Validated
        total()
    End Sub

    Private Sub txttestchgs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttestchgs.KeyPress
        Try
            numdotkeypress(e, txttestchgs, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txttestchgs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttestchgs.Validated
        total()
    End Sub

    Private Sub chkexcise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexcise.CheckedChanged
        If chkexcise.Checked = True Then
            TXTEXCISE.ReadOnly = True
            txtexciseAMT.ReadOnly = True
            TXTEDUCESS.ReadOnly = True
            txteducessAMT.ReadOnly = True
            TXTHSECESS.ReadOnly = True
            txthsecessAMT.ReadOnly = True
            getexcise()
        Else
            TXTEXCISEID.Text = 0
            TXTEXCISE.Text = 0.0
            txtexciseAMT.Text = 0.0
            TXTEDUCESS.Text = 0.0
            txteducessAMT.Text = 0.0
            TXTHSECESS.Text = 0.0
            txthsecessAMT.Text = 0.0
        End If
        total()
    End Sub

    Private Sub txtinspchgs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinspchgs.KeyPress
        Try
            numdotkeypress(e, txtinspchgs, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtinspchgs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinspchgs.Validated
        total()
    End Sub

    Private Sub txtpfper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpfper.KeyPress
        Try
            numdotkeypress(e, txtpfper, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtpfper_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpfper.Validated
        total()
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJPO As New PurchaseOrderDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.PARTYNAME = cmbname.Text.Trim
            OBJPO.AGENTNAME = CMBBROKER.Text.Trim
            OBJPO.FRMSTRING = "GREYPOREPORT"
            OBJPO.FORMULA = "{GREYPURCHASEORDER.PO_NO}=" & Val(TXTPONO.Text) & " and {GREYPURCHASEORDER.PO_yearid}=" & YearId
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPREVIOUS.Click
        Try
            gridpo.RowCount = 0
LINE1:
            TEMPPONO = Val(TXTPONO.Text) - 1
            If TEMPPONO > 0 Then
                EDIT = True
                GreyPurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If gridpo.RowCount = 0 And TEMPPONO > 1 Then
                TXTPONO.Text = TEMPPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            gridpo.RowCount = 0
LINE1:
            TEMPPONO = Val(TXTPONO.Text) + 1
            getmax_po_no()
            Dim MAXNO As Integer = TXTPONO.Text.Trim
            clear()
            If Val(TXTPONO.Text) - 1 >= TEMPPONO Then
                EDIT = True
                GreyPurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If gridpo.RowCount = 0 And TEMPPONO < MAXNO Then
                TXTPONO.Text = TEMPPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtfreight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfreight.KeyPress
        Try
            numdotkeypress(e, txtfreight, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtfreight_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfreight.Validated
        total()
    End Sub

    Private Sub txtqty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtqty.Validating
        CALC()
    End Sub

    Private Sub TXTREED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPICK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmbtoname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcode.Enter
        Try
            If cmbcode.Text.Trim = "" Then fillACCCODE(cmbcode, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND  LEDGERS.ACC_TYPE='ACCOUNTS'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDELPERIOD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDELPERIOD.Validated
        Try
            If PODATE.Text <> "__/__/____" Then
                If Val(TXTDELPERIOD.Text.Trim) > 0 Then duedate.Value = Convert.ToDateTime(PODATE.Text).Date.AddDays(Val(TXTDELPERIOD.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTAMOUNT.Text = Format(Val(TXTMTRS.Text) * Val(txtrate.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        CALC()
    End Sub

    Private Sub CMBBROKER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBROKER.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then cmbcode.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBBROKER.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then cmbitemname.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub duedate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles duedate.Validated
        Try
            If PODATE.Text <> "__/__/____" And Val(TXTDELPERIOD.Text.Trim) = 0 Then TXTDELPERIOD.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(PODATE.Text).Date, duedate.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New GreyPurchaseOrderDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub TOOLCLOSE_Click(sender As Object, e As EventArgs)
        Try
            Dim OBJPO As New PurchaseOrderClose
            OBJPO.MdiParent = MDIMain
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtdiscount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdiscount.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPONO_Validating(sender As Object, e As CancelEventArgs) Handles TXTPONO.Validating
        Try
            If Val(TXTPONO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(GREYPURCHASEORDER.PO_NO,0)  AS PONO", "", " GREYPURCHASEORDER ", "  AND GREYPURCHASEORDER.PO_NO=" & Val(TXTPONO.Text.Trim) & " AND GREYPURCHASEORDER.PO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Purchase Order No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(sender As Object, e As EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Enter(sender As Object, e As EventArgs) Handles cmbqtyunit.Enter
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class