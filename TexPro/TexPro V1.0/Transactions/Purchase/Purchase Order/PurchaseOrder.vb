
Imports BL

Public Class PurchaseOrder
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public tempono As Integer
    Dim tempMsg As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_po_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(po_no),0) + 1 ", "PURCHASEORDER", " and po_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        CMBNAME.Text = ""
        CMBNAME.Enabled = True

        PODATE.Text = Now.Date

        'GET LAST 3 MONTHS NAME
        GMONTH1.HeaderText = MonthName(Now.Date.AddMonths(-3).Month)
        GMONTH2.HeaderText = MonthName(Now.Date.AddMonths(-2).Month)
        GMONTH3.HeaderText = MonthName(Now.Date.AddMonths(-1).Month)


        TXTREFNO.Clear()
        CHKAUTOFILL.CheckState = CheckState.Unchecked

        TXTSRNO.Text = 1
        CMBITEMNAME.Text = ""
        TXTGRIDREMARKS.Clear()
        TXTMONTH1.Text = ""
        TXTMONTH2.Clear()
        TXTMONTH3.Clear()
        TXTSTOCK.Clear()
        TXTQTY.Clear()
        CMBQTYUNIT.Text = ""
        TXTRATE.Clear()
        TXTAMOUNT.Clear()

        EP.Clear()

        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        PBlock.Visible = False
        txtremarks.Clear()

        txtinwords.Clear()
        txtadd.Clear()
        LBLTOTALAMT.Text = "0.00"
        LBLTOTALQTY.Text = "0.00"

        GRIDPO.RowCount = 0
        GRIDPUR.RowCount = 0

        getmax_po_no()
        GRIDDOUBLECLICK = False
        CMBORDERTYPE.SelectedIndex = 0

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub PurchaseOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                GRIDPO.Focus()
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            fillunit(CMBQTYUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsPO As New ClsPurchaseOrder()
                Dim dt_po As DataTable = objclsPO.selectpo(tempono, CmpId, Locationid, YearId)


                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows

                        TXTPONO.Text = dr("PONO")
                        PODATE.Text = Format(Convert.ToDateTime(dr("PODATE")), "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        TXTREFNO.Text = Convert.ToString(dr("REFNO"))
                        CMBORDERTYPE.Text = Convert.ToString(dr("ORDERTYPE"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))

                        GRIDPO.Rows.Add(dr("POGRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("GRIDREMARKS").ToString, Val(dr("MONTH1")), Val(dr("MONTH2")), Val(dr("MONTH3")), Val(dr("STOCK")), Format(Val(dr("QTY")), "0.00"), dr("UNIT").ToString, Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMT")), "0.00"), Val(dr("RECDQTY")), dr("GRIDPODONE"), dr("CLOSED"))

                        If Val(dr("RECDQTY")) > 0 Then
                            GRIDPO.Rows(GRIDPO.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            CMBNAME.Enabled = False
                        End If

                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            GRIDPO.Rows(GRIDPO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    GRIDPO.FirstDisplayedScrollingRowIndex = GRIDPO.RowCount - 1

                End If
                total()
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(PODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)
            alParaval.Add(CMBORDERTYPE.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALAMT.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim gridremarks As String = ""
            Dim MONTH1 As String = ""
            Dim MONTH2 As String = ""
            Dim MONTH3 As String = ""
            Dim STOCK As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim rate As String = ""
            Dim amount As String = ""
            Dim recdqty As String = ""      'Qty recd in GRN
            Dim GRNDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim CLOSED As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        MONTH1 = Val(row.Cells(GMONTH1.Index).Value)
                        MONTH2 = Val(row.Cells(GMONTH2.Index).Value)
                        MONTH3 = Val(row.Cells(GMONTH3.Index).Value)
                        STOCK = Val(row.Cells(GSTOCK.Index).Value)
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        rate = row.Cells(grate.Index).Value
                        amount = row.Cells(gamt.Index).Value
                        recdqty = row.Cells(grecdqty.Index).Value
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then GRNDONE = 1 Else GRNDONE = 0
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        MONTH1 = MONTH1 & "|" & Val(row.Cells(GMONTH1.Index).Value)
                        MONTH2 = MONTH2 & "|" & Val(row.Cells(GMONTH2.Index).Value)
                        MONTH3 = MONTH3 & "|" & Val(row.Cells(GMONTH3.Index).Value)
                        STOCK = STOCK & "|" & Val(row.Cells(GSTOCK.Index).Value)
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        rate = rate & "|" & row.Cells(grate.Index).Value
                        amount = amount & "|" & row.Cells(gamt.Index).Value
                        recdqty = recdqty & "|" & row.Cells(grecdqty.Index).Value
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then GRNDONE = GRNDONE & "|" & "1" Else GRNDONE = GRNDONE & "|" & "0"
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(gridremarks)
            alParaval.Add(MONTH1)
            alParaval.Add(MONTH2)
            alParaval.Add(MONTH3)
            alParaval.Add(STOCK)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(rate)
            alParaval.Add(amount)
            alParaval.Add(recdqty)
            alParaval.Add(GRNDONE)
            alParaval.Add(CLOSED)

            alParaval.Add(txtinwords.Text.Trim)

            Dim objclsPurord As New ClsPurchaseOrder()
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
                alParaval.Add(tempono)

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
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Company Name ")
            bln = False
        End If

        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked")
            bln = False
        End If


LINE1:
        'WE HAVE TO REMOVE ALL 0 ITEMS WHICH COMES AUTO FROM AUTOFILL
        For Each ROW As DataGridViewRow In GRIDPO.Rows
            If Val(ROW.Cells(gQty.Index).Value) <= 0 Then
                GRIDPO.Rows.RemoveAt(ROW.Index)
                GoTo LINE1
            End If
        Next
        getsrno(GRIDPO)


        If PODATE.Text = "__/__/____" Then
            EP.SetError(PODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(PODATE.Text) Then
                EP.SetError(PODATE, "Date not in Accounting Year")
                bln = False
            End If
        End If
        total()
        Return bln
    End Function

    Sub total()

        LBLTOTALQTY.Text = "0.00"
        LBLTOTALAMT.Text = "0.00"

        For Each row As DataGridViewRow In GRIDPO.Rows
            If Val(row.Cells(gQty.Index).EditedFormattedValue) <> 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(row.Cells(gQty.Index).Value), "0.00")
            If Val(row.Cells(grate.Index).EditedFormattedValue) <> 0 Then row.Cells(gamt.Index).Value = Format(Val(row.Cells(grate.Index).EditedFormattedValue) * Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
            If Val(row.Cells(gamt.Index).EditedFormattedValue) <> 0 Then LBLTOTALAMT.Text = Val(LBLTOTALAMT.Text) + Val(row.Cells(gamt.Index).EditedFormattedValue)
        Next

    End Sub

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.GotFocus
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If GRIDDOUBLECLICK = False Then TXTSRNO.Text = GRIDPO.RowCount + 1
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
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

        GRIDPO.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDPO.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMNAME.Text.Trim, TXTGRIDREMARKS.Text.Trim, Val(TXTMONTH1.Text.Trim), Val(TXTMONTH2.Text.Trim), Val(TXTMONTH3.Text.Trim), Val(TXTSTOCK.Text.Trim), Val(TXTQTY.Text.Trim), CMBQTYUNIT.Text.Trim, Val(TXTRATE.Text.Trim), Val(TXTAMOUNT.Text.Trim), 0, 0, 0)
            getsrno(GRIDPO)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDPO.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDPO.Item(gitemname.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDPO.Item(gdesc.Index, TEMPROW).Value = TXTGRIDREMARKS.Text.Trim
            GRIDPO.Item(GMONTH1.Index, TEMPROW).Value = Val(TXTMONTH1.Text.Trim)
            GRIDPO.Item(GMONTH2.Index, TEMPROW).Value = Val(TXTMONTH2.Text.Trim)
            GRIDPO.Item(GMONTH3.Index, TEMPROW).Value = Val(TXTMONTH3.Text.Trim)
            GRIDPO.Item(GSTOCK.Index, TEMPROW).Value = Val(TXTSTOCK.Text.Trim)
            GRIDPO.Item(gQty.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
            GRIDPO.Item(gqtyunit.Index, TEMPROW).Value = CMBQTYUNIT.Text.Trim
            GRIDPO.Item(grate.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            GRIDPO.Item(gamt.Index, TEMPROW).Value = Val(TXTAMOUNT.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        GRIDPO.FirstDisplayedScrollingRowIndex = GRIDPO.RowCount - 1

        TXTSRNO.Text = GRIDPO.RowCount + 1
        CMBITEMNAME.Text = ""
        TXTGRIDREMARKS.Clear()
        TXTMONTH1.Clear()
        TXTMONTH2.Clear()
        TXTMONTH3.Clear()
        TXTSTOCK.Clear()
        TXTQTY.Clear()
        CMBQTYUNIT.Text = ""
        TXTRATE.Clear()
        TXTAMOUNT.Clear()

        CMBITEMNAME.Focus()

    End Sub

    Private Sub gridpo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPO.CellDoubleClick
        If e.RowIndex >= 0 And GRIDPO.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then
            EDITROW()
        End If
    End Sub

    Private Sub txtrate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        CALC()
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PODATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PODATE.GotFocus
        PODATE.SelectAll()
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
                Else
                    'GET LAST 3 MONTHS NAME
                    GMONTH1.HeaderText = MonthName(Convert.ToDateTime(PODATE.Text).Date.AddMonths(-3).Month)
                    GMONTH2.HeaderText = MonthName(Convert.ToDateTime(PODATE.Text).Date.AddMonths(-2).Month)
                    GMONTH3.HeaderText = MonthName(Convert.ToDateTime(PODATE.Text).Date.AddMonths(-1).Month)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
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
                alParaval.Add(tempono)
                alParaval.Add(Userid)
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(YearId)

                Dim clspo As New ClsPurchaseOrder()
                clspo.alParaval = alParaval
                IntResult = clspo.Delete()
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

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQTYUNIT.GotFocus
        Try
            If CMBQTYUNIT.Text.Trim = "" Then fillunit(CMBQTYUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQTYUNIT.Validating
        Try
            If CMBQTYUNIT.Text.Trim <> "" Then unitvalidate(CMBQTYUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridpo_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPO.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = GRIDPO.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case grate.Index, gQty.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDPO.CurrentCell.Value = Nothing Then GRIDPO.CurrentCell.Value = "0.00"
                    GRIDPO.CurrentCell.Value = Convert.ToDecimal(GRIDPO.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    GRIDPO.Rows(e.RowIndex).Cells(gamt.Index).Value = Format(Val(GRIDPO.Rows(e.RowIndex).Cells(grate.Index).EditedFormattedValue) * Val(GRIDPO.Rows(e.RowIndex).Cells(gQty.Index).EditedFormattedValue), "0.00")
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If
                total()

        End Select
    End Sub

    Sub EDITROW()
        Try
            If GRIDPO.CurrentRow.Index >= 0 And GRIDPO.Item(gsrno.Index, GRIDPO.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(GRIDPO.CurrentRow.Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPO.CurrentRow.Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPO.Item(gsrno.Index, GRIDPO.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDPO.Item(gitemname.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTGRIDREMARKS.Text = GRIDPO.Item(gdesc.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTMONTH1.Text = GRIDPO.Item(GMONTH1.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTMONTH2.Text = GRIDPO.Item(GMONTH2.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTMONTH3.Text = GRIDPO.Item(GMONTH3.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTSTOCK.Text = GRIDPO.Item(GSTOCK.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDPO.Item(gQty.Index, GRIDPO.CurrentRow.Index).Value.ToString
                CMBQTYUNIT.Text = GRIDPO.Item(gqtyunit.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDPO.Item(grate.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDPO.Item(gamt.Index, GRIDPO.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDPO.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPO.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDPO.RowCount > 0 Then

                If Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDPO.Rows.RemoveAt(GRIDPO.CurrentRow.Index)
                total()
                getsrno(GRIDPO)
                total()

            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPO.RowCount = 0
                tempono = Val(tstxtbillno.Text)
                If tempono > 0 Then
                    EDIT = True
                    PurchaseOrder_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objpodtls As New PurchaseOrderDetails
            objpodtls.MdiParent = MDIMain
            objpodtls.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call cmdok_Click(sender, e)
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJPO As New PurchaseOrderDesign
            OBJPO.MdiParent = MDIMain
            OBJPO.FRMSTRING = "POREPORT"
            OBJPO.FORMULA = "{PURCHASEORDER.PO_NO}=" & Val(TXTPONO.Text) & " and {PURCHASEORDER.PO_yearid}=" & YearId
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPREVIOUS.Click
        Try
            GRIDPO.RowCount = 0
LINE1:
            tempono = Val(TXTPONO.Text) - 1
            If tempono > 0 Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPO.RowCount = 0 And tempono > 1 Then
                TXTPONO.Text = tempono
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDPO.RowCount = 0
LINE1:
            tempono = Val(TXTPONO.Text) + 1
            getmax_po_no()
            Dim MAXNO As Integer = TXTPONO.Text.Trim
            clear()
            If Val(TXTPONO.Text) - 1 >= tempono Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPO.RowCount = 0 And tempono < MAXNO Then
                TXTPONO.Text = tempono
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTQTY.Validating
        CALC()
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then cmbcode.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTAMOUNT.Text = Format(Val(TXTQTY.Text) * Val(TXTRATE.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "ITEM"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
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

            Dim objINVDTLS As New PurchaseOrderDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            ' Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub TXTAMOUNT_Validated(sender As Object, e As EventArgs) Handles TXTAMOUNT.Validated
        Try
            If CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBQTYUNIT.Text.Trim <> "" Then
                fillgrid()
                total()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            'FETCH ALL ITEMNAMES WITH RESPECT TO SELECTED PARTY
            If CMBNAME.Text.Trim <> "" And CHKAUTOFILL.CheckState = CheckState.Checked Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME, ISNULL(UNITMASTER.UNIT_ABBR,'') AS UNIT", "", " ITEMMASTER INNER JOIN LEDGERS ON ITEM_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN UNITMASTER ON ITEM_UNITID = UNITMASTER.UNIT_ID", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID = " & YearId & " ORDER BY ITEMMASTER.ITEM_NAME")
                For Each DTROW As DataRow In DT.Rows
                    GETCONSUMPTION(DTROW("ITEMNAME"))
                    GETSTOCK(DTROW("ITEMNAME"))
                    GRIDPO.Rows.Add(0, DTROW("ITEMNAME"), "", Val(TXTMONTH1.Text.Trim), Val(TXTMONTH2.Text.Trim), Val(TXTMONTH3.Text.Trim), Val(TXTSTOCK.Text.Trim), 0, DTROW("UNIT"), 0, 0, 0, 0, 0)
                    TXTMONTH1.Clear()
                    TXTMONTH2.Clear()
                    TXTMONTH3.Clear()
                    TXTSTOCK.Clear()
                Next
                getsrno(GRIDPO)
                CMBNAME.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETCONSUMPTION(ITEMNAME As String)
        Try
            'GET LAST 3 MONTHIS CONSUMPTION WITH RESPECT TO ITEMNAME AND IRRESPECTIVE TO YEARID
            'DONT ADD YEARID CLAUSE
            Dim MONTH1, MONTH2, MONTH3 As Integer
            MONTH1 = Convert.ToDateTime(PODATE.Text).Date.AddMonths(-3).Month
            MONTH2 = Convert.ToDateTime(PODATE.Text).Date.AddMonths(-2).Month
            MONTH3 = Convert.ToDateTime(PODATE.Text).Date.AddMonths(-1).Month

            Dim TEMPDATE As Date = (Convert.ToDateTime(PODATE.Text).Date.AddMonths(-3))
            Dim STARTDATE As New Date(TEMPDATE.Year, MONTH1, 1)
            Dim ENDDATE As New Date(TEMPDATE.Year, MONTH1, TEMPDATE.DaysInMonth(TEMPDATE.Year, TEMPDATE.Month))


            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search("ISNULL(SUM(CONSUME_QTY),0) AS QTY", "", " CONSUMPTION_DESC INNER JOIN CONSUMPTION ON CONSUMPTION.CONSUME_NO = CONSUMPTION_DESC.CONSUME_no AND CONSUMPTION.CONSUME_YEARID = CONSUMPTION_DESC.CONSUME_yearid INNER JOIN ITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = ITEM_ID  ", " AND ITEMMASTER.ITEM_NAME = '" & ITEMNAME & "' AND CONSUME_DATE>= '" & Format(STARTDATE.Date, "MM/dd/yyyy") & "' AND CONSUME_DATE <= '" & Format(ENDDATE.Date, "MM/dd/yyyy") & "'")
            Dim DT As DataTable = OBJCMN.search("ISNULL(SUM(QTY),0) AS QTY", "", " VIEW_STORE_STOCK ", " AND ITEMNAME = '" & ITEMNAME & "' AND DATE>= '" & Format(STARTDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(ENDDATE.Date, "MM/dd/yyyy") & "' AND TYPE = 'ISSUE'")
            If DT.Rows.Count > 0 Then TXTMONTH1.Text = Val(DT.Rows(0).Item("QTY"))


            TEMPDATE = (Convert.ToDateTime(PODATE.Text).Date.AddMonths(-2))
            STARTDATE = New Date(TEMPDATE.Year, MONTH2, 1)
            ENDDATE = New Date(TEMPDATE.Year, MONTH2, TEMPDATE.DaysInMonth(TEMPDATE.Year, TEMPDATE.Month))

            'DT = OBJCMN.search("ISNULL(SUM(CONSUME_QTY),0) AS QTY", "", " CONSUMPTION_DESC INNER JOIN CONSUMPTION ON CONSUMPTION.CONSUME_NO = CONSUMPTION_DESC.CONSUME_no AND CONSUMPTION.CONSUME_YEARID = CONSUMPTION_DESC.CONSUME_yearid INNER JOIN ITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = ITEM_ID  ", " AND ITEMMASTER.ITEM_NAME = '" & ITEMNAME & "' AND CONSUME_DATE>= '" & Format(STARTDATE.Date, "MM/dd/yyyy") & "' AND CONSUME_DATE <= '" & Format(ENDDATE.Date, "MM/dd/yyyy") & "'")
            DT = OBJCMN.search("ISNULL(SUM(QTY),0) AS QTY", "", " VIEW_STORE_STOCK ", " AND ITEMNAME = '" & ITEMNAME & "' AND DATE>= '" & Format(STARTDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(ENDDATE.Date, "MM/dd/yyyy") & "' AND TYPE = 'ISSUE'")
            If DT.Rows.Count > 0 Then TXTMONTH2.Text = Val(DT.Rows(0).Item("QTY"))


            TEMPDATE = (Convert.ToDateTime(PODATE.Text).Date.AddMonths(-1))
            STARTDATE = New Date(TEMPDATE.Year, MONTH3, 1)
            ENDDATE = New Date(TEMPDATE.Year, MONTH3, TEMPDATE.DaysInMonth(TEMPDATE.Year, TEMPDATE.Month))

            'DT = OBJCMN.search("ISNULL(SUM(CONSUME_QTY),0) AS QTY", "", " CONSUMPTION_DESC INNER JOIN CONSUMPTION ON CONSUMPTION.CONSUME_NO = CONSUMPTION_DESC.CONSUME_no AND CONSUMPTION.CONSUME_YEARID = CONSUMPTION_DESC.CONSUME_yearid INNER JOIN ITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = ITEM_ID  ", " AND ITEMMASTER.ITEM_NAME = '" & ITEMNAME & "' AND CONSUME_DATE>= '" & Format(STARTDATE.Date, "MM/dd/yyyy") & "' AND CONSUME_DATE <= '" & Format(ENDDATE.Date, "MM/dd/yyyy") & "'")
            DT = OBJCMN.search("ISNULL(SUM(QTY),0) AS QTY", "", " VIEW_STORE_STOCK ", " AND ITEMNAME = '" & ITEMNAME & "' AND DATE>= '" & Format(STARTDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(ENDDATE.Date, "MM/dd/yyyy") & "' and type = 'ISSUE'")
            If DT.Rows.Count > 0 Then TXTMONTH3.Text = Val(DT.Rows(0).Item("QTY"))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETSTOCK(ITEMNAME As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT STORESTOCK.BALANCE  ", "", " STORESTOCK ", " AND ITEMNAME = '" & ITEMNAME & "' AND YEARID =" & YearId)
            If DT.Rows.Count > 0 Then TXTSTOCK.Text = Val(DT.Rows(0).Item("BALANCE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETPURCHASE(ITEMNAME As String)
        Try
            GRIDPUR.RowCount = 0
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" TOP 5 ISNULL(PURCHASEMASTER.BILL_NO,0) AS BILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS BILLDATE, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(PURCHASEMASTER_DESC.BILL_QTY,0) AS QTY, ISNULL(PURCHASEMASTER_DESC.BILL_RATE,0) AS RATE, ISNULL(PURCHASEMASTER_DESC.BILL_AMT,0) AS AMT ", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_NO AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = ACC_ID INNER JOIN ITEMMASTER ON BILL_ITEMID  = ITEM_ID ", " AND ITEMMASTER.ITEM_NAME = '" & ITEMNAME & "' ORDER BY PURCHASEMASTER.BILL_PARTYBILLDATE DESC ")
            For Each DTROW As DataRow In DT.Rows
                GRIDPUR.Rows.Add(0, Format(Convert.ToDateTime(DTROW("BILLDATE")).Date, "dd/MM/yyyy"), DTROW("NAME"), Format(Val(DTROW("QTY")), "0.00"), Format(Val(DTROW("RATE")), "0.00"), Format(Val(DTROW("AMT")), "0.00"))
            Next
            getsrno(GRIDPUR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validated(sender As Object, e As EventArgs) Handles CMBITEMNAME.Validated
        Try
            If CMBITEMNAME.Text.Trim <> "" Then
                GETCONSUMPTION(CMBITEMNAME.Text.Trim)
                GETSTOCK(CMBITEMNAME.Text.Trim)
                GETPURCHASE(CMBITEMNAME.Text.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPO_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPO.RowEnter
        Try
            If e.RowIndex >= 0 AndAlso GRIDPO.SelectedRows.Count > 0 Then GETPURCHASE(GRIDPO.Rows(e.RowIndex).Cells(gitemname.Index).EditedFormattedValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

