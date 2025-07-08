
Imports BL
Imports System.Windows.Forms

Public Class MaterialUse

    'following two variables is only for used in edit mode....
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer

    Public edit As Boolean
    Public TEMPMATERIALUSENO As String
    Public tempMsg As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM' AND (MATERIALTYPEMASTER.MATERIAL_NAME='Stores & Supplies - Production' or   MATERIALTYPEMASTER.MATERIAL_NAME='Pakaging Material')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM' and (MATERIALTYPEMASTER.MATERIAL_NAME='Stores & Supplies - Production' or   MATERIALTYPEMASTER.MATERIAL_NAME='Pakaging Material')", "ITEM")
            If cmbitemname.Text.Trim <> "" Then

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdepartment_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdepartment.Enter
        Try
            If cmbdepartment.Text.Trim = "" Then filldepartment(cmbdepartment, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdepartment_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdepartment.Validating
        Try
            If cmbdepartment.Text.Trim <> "" Then DEPARTMENTVALIDATE(cmbdepartment, e, Me)
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

    Sub clear()

        tstxtbillno.Clear()
        cmbdepartment.Text = ""
        MATERIALUSEdate.Value = Mydate
        EP.Clear()
        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        txtqty.Clear()
        cmbqtyunit.Text = ""

        txtremarks.Clear()
        CMBProcess.Text = ""

        gridMATERIALUSE.RowCount = 0
        lbltotalqty.Text = 0.0

        lbllocked.Visible = False
        PBlock.Visible = False
        gridDoubleClick = False



        getmax_MATERIALUSE_no() 'this function is for to get max value from the Purchase MATERIALUSEuisition table

        If gridMATERIALUSE.RowCount > 0 Then
            txtsrno.Text = Val(gridMATERIALUSE.Rows(gridMATERIALUSE.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Sub getmax_MATERIALUSE_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(MATERIALUSE_no),0) + 1 ", "CONSUMPTION", " AND MATERIALUSE_cmpid=" & CmpId & " and MATERIALUSE_LOCATIONID=" & Locationid & " and MATERIALUSE_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTMATERIALUSENO.Text = DTTABLE.Rows(0).Item(0)
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
        gridMATERIALUSE.Enabled = True
        If gridDoubleClick = False Then
            gridMATERIALUSE.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, txtgridremarks.Text.Trim, Val(txtqty.Text.Trim), cmbqtyunit.Text.Trim)
            getsrno(gridMATERIALUSE)
        ElseIf gridDoubleClick = True Then
            gridMATERIALUSE.Item(gsrno.Index, tempRow).Value = Val(txtsrno.Text.Trim)
            gridMATERIALUSE.Item(gitemname.Index, tempRow).Value = cmbitemname.Text.Trim
            gridMATERIALUSE.Item(gdesc.Index, tempRow).Value = txtgridremarks.Text.Trim
            gridMATERIALUSE.Item(gQty.Index, tempRow).Value = Val(txtqty.Text.Trim)
            gridMATERIALUSE.Item(gqtyunit.Index, tempRow).Value = cmbqtyunit.Text.Trim

            gridDoubleClick = False

        End If
        qtytotal()
        gridMATERIALUSE.FirstDisplayedScrollingRowIndex = gridMATERIALUSE.RowCount - 1

        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        txtqty.Clear()
        cmbqtyunit.Text = ""
        txtsrno.Focus()
        If gridMATERIALUSE.RowCount > 0 Then
            txtsrno.Text = Val(gridMATERIALUSE.Rows(gridMATERIALUSE.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If
    End Sub

    Sub qtytotal()
        lbltotalqty.Text = "0.00"
        For Each row As DataGridViewRow In gridMATERIALUSE.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).Value), "0.00")
            End If
        Next
    End Sub

    Private Sub gridpurchaseMATERIALUSE_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMATERIALUSE.CellDoubleClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And gridMATERIALUSE.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then
            If Convert.ToBoolean(gridMATERIALUSE.Item(GDONE.Index, e.RowIndex).Value) = False Then
                gridDoubleClick = True
                txtsrno.Text = gridMATERIALUSE.Item(gsrno.Index, e.RowIndex).Value
                cmbitemname.Text = gridMATERIALUSE.Item(gitemname.Index, e.RowIndex).Value
                txtgridremarks.Text = gridMATERIALUSE.Item(gdesc.Index, e.RowIndex).Value
                txtqty.Text = gridMATERIALUSE.Item(gQty.Index, e.RowIndex).Value
                cmbqtyunit.Text = gridMATERIALUSE.Item(gqtyunit.Index, e.RowIndex).Value
                tempRow = e.RowIndex
                txtsrno.Focus()
            Else
                MsgBox("Item Locked. First Delete Entry From Quotation")
            End If
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(MATERIALUSEdate.Value)
            alParaval.Add(cmbdepartment.Text.Trim)
            alParaval.Add(lbltotalqty.Text.Trim)
            alParaval.Add(CMBProcess.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim gridremarks As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridMATERIALUSE.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value
                        qtyunit = row.Cells(gqtyunit.Index).Value

                    Else
                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(gitemname.Index).Value.ToString
                        gridremarks = gridremarks & "," & row.Cells(gdesc.Index).Value.ToString
                        qty = qty & "," & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "," & row.Cells(gqtyunit.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(gridremarks)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)


            Dim objclsMATERIALUSE As New ClsMATERIALUSE
            objclsMATERIALUSE.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsMATERIALUSE.save()
                MessageBox.Show("Details Added")
            Else
                alParaval.Add(TEMPMATERIALUSENO)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsMATERIALUSE.Update()
                MsgBox("Details Updated")
            End If
            edit = False
            Dim TEMPMSG As Integer
            TEMPMSG = MsgBox("WISH TO PRINT", MsgBoxStyle.YesNo)

            If TEMPMSG = vbYes Then
                'Dim OBJGN As New MATERIALUSEdesign
                'OBJGN.MATERIALUSENO = TXTMATERIALUSENO.Text
                'OBJGN.MdiParent = MDIMain
                'OBJGN.selfor_po = "{CONSUMPTION.MATERIALUSE_no}=" & TXTMATERIALUSENO.Text & " and {CONSUMPTION.MATERIALUSE_cmpid}=" & CmpId & " and {CONSUMPTION.MATERIALUSE_locationid}=" & Locationid & " and {CONSUMPTION.MATERIALUSE_yearid}=" & YearId
                'OBJGN.Show()
            End If
            clear()
            cmbdepartment.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True



        If cmbdepartment.Text.Trim.Length = 0 Then
            EP.SetError(cmbdepartment, "Enter Department")
            bln = False
        End If

        If gridMATERIALUSE.RowCount = 0 Then
            EP.SetError(txtqty, "Enter Item Details")
            bln = False
        End If


        If Not datecheck(MATERIALUSEdate.Value) Then bln = False
        Return bln
    End Function

    Private Sub PurchaseMATERIALUSEuisition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            ' Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            ' Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PurchaseMATERIALUSEuisition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub
    Sub fillcmb()
        If CMBProcess.Text.Trim = "" Then FILLPROCESS(CMBProcess, " AND PROCESSMASTER.PROCESS_TYPE<>''", edit)
        filldepartment(cmbdepartment, edit)
        fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        fillunit(cmbqtyunit)
    End Sub
    Private Sub PurchaseMATERIALUSEuisition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList
                Dim objclsMATERIALUSE As New ClsMATERIALUSE

                ALPARAVAL.Add(TEMPMATERIALUSENO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsMATERIALUSE.alParaval = ALPARAVAL
                Dim dt As DataTable = objclsMATERIALUSE.selectMATERIALUSE()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTMATERIALUSENO.Text = TEMPMATERIALUSENO
                        MATERIALUSEdate.Value = Convert.ToDateTime(dr("MATERIALUSEDATE"))
                        cmbdepartment.Text = Convert.ToString(dr("DEPARTMENT"))
                        CMBProcess.Text = Convert.ToString(dr("PROCESS"))
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        gridMATERIALUSE.Rows.Add(dr("gridsrno").ToString, dr("ITEMNAME").ToString, dr("DESC").ToString, dr("QTY").ToString, dr("QTYUNIT").ToString)

                    Next
                    gridMATERIALUSE.FirstDisplayedScrollingRowIndex = gridMATERIALUSE.RowCount - 1
                End If

                chkchange.CheckState = CheckState.Checked
                qtytotal()
            End If

            'If gridDoubleClick = False Then
            If gridMATERIALUSE.RowCount > 0 Then
                txtsrno.Text = Val(gridMATERIALUSE.Rows(gridMATERIALUSE.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If gridMATERIALUSE.RowCount > 0 Then
                txtsrno.Text = Val(gridMATERIALUSE.Rows(gridMATERIALUSE.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdot(e, txtqty, Me)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True Then
                Dim BLN As Boolean = True
                Dim TEMPMSG As Integer = MsgBox("Delete MATERIALUSE?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJPR As New ClsMATERIALUSE

                    ALPARAVAL.Add(TEMPMATERIALUSENO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJPR.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJPR.Delete()
                    MsgBox("Purchase MATERIALUSEuest Deleted")
                    clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objprdetails As New ConsumptionDetails
            objprdetails.MdiParent = MDIMain
            objprdetails.Show()
            objprdetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        TEMPMATERIALUSENO = Val(TXTMATERIALUSENO.Text) - 1
        clear()
        If TEMPMATERIALUSENO > 0 Then
            edit = True
            PurchaseMATERIALUSEuisition_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        TEMPMATERIALUSENO = Val(TXTMATERIALUSENO.Text) + 1
        getmax_MATERIALUSE_no()
        clear()
        If Val(TXTMATERIALUSENO.Text) - 1 >= TEMPMATERIALUSENO Then
            edit = True
            PurchaseMATERIALUSEuisition_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub MATERIALUSEdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MATERIALUSEdate.Validating
        If Not datecheck(MATERIALUSEdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub


    Private Sub gridpurchaseMATERIALUSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridMATERIALUSE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridMATERIALUSE.RowCount > 0 Then


                gridMATERIALUSE.Rows.RemoveAt(gridMATERIALUSE.CurrentRow.Index)
                qtytotal()
                getsrno(gridMATERIALUSE)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub tstxtbillno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        TEMPMATERIALUSENO = Val(tstxtbillno.Text)
        clear()
        If TEMPMATERIALUSENO > 0 Then
            edit = True
            PurchaseMATERIALUSEuisition_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub cmbqtyunit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.Validated
        Try
            If cmbitemname.Text.Trim <> "" And cmbqtyunit.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 Then
                fillgrid()
                qtytotal()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                'Dim OBJGN As New MATERIALUSEdesign
                'OBJGN.MATERIALUSENO = TEMPMATERIALUSENO
                'OBJGN.MdiParent = MDIMain
                'OBJGN.selfor_po = "{CONSUMPTION.MATERIALUSE_no}=" & TEMPMATERIALUSENO & " and {CONSUMPTION.MATERIALUSE_cmpid}=" & CmpId & " and {CONSUMPTION.MATERIALUSE_locationid}=" & Locationid & " and {CONSUMPTION.MATERIALUSE_yearid}=" & YearId
                'OBJGN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridMATERIALUSE_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridMATERIALUSE.CellValidating
        Try
            Dim colNum As Integer = gridMATERIALUSE.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gQty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridMATERIALUSE.CurrentCell.Value = Nothing Then gridMATERIALUSE.CurrentCell.Value = "0.00"
                        gridMATERIALUSE.CurrentCell.Value = Convert.ToDecimal(gridMATERIALUSE.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        qtytotal()
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

    Private Sub CMBProcess_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBProcess.Validating
        If gridMATERIALUSE.RowCount = 0 And edit = False Then

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable

            DT = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, PROCESS_DESC.PROCESS_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, PROCESS_DESC.PROCESS_RATE AS RATE", "", " PROCESS_DESC INNER JOIN ITEMMASTER ON PROCESS_DESC.PROCESS_ITEMid = ITEMMASTER.item_id AND PROCESS_DESC.PROCESS_cmpid = ITEMMASTER.item_cmpid AND PROCESS_DESC.PROCESS_locationid = ITEMMASTER.item_locationid AND PROCESS_DESC.PROCESS_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PROCESS_DESC.PROCESS_cmpid = UNITMASTER.unit_cmpid AND PROCESS_DESC.PROCESS_locationid = UNITMASTER.unit_locationid AND PROCESS_DESC.PROCESS_yearid = UNITMASTER.unit_yearid AND PROCESS_DESC.PROCESS_unitid = UNITMASTER.unit_id INNER JOIN PROCESSMASTER ON PROCESS_DESC.PROCESS_id = PROCESSMASTER.PROCESS_ID AND PROCESS_DESC.PROCESS_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESS_DESC.PROCESS_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESS_DESC.PROCESS_yearid = PROCESSMASTER.PROCESS_YEARID", " AND PROCESSMASTER.PROCESS_NAME = '" & CMBProcess.Text.Trim & "' AND PROCESS_DESC.PROCESS_CMPID = " & CmpId & " AND PROCESS_DESC.PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_DESC.PROCESS_YEARID= " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    gridMATERIALUSE.Rows.Add(0, DTROW("ITEMNAME"), "", DTROW("QTY"), DTROW("UNIT"))
                Next
                getsrno(gridMATERIALUSE)
                qtytotal()
            End If
        End If
    End Sub
End Class