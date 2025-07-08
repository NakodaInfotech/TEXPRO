
Imports BL
Imports System.Windows.Forms

Public Class CuttingProcess

    'following two variables is only for used in edit mode....
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public Shared selectMFGtable As New DataTable
    Public edit As Boolean
    Public tempcpno As String
    Public tempMsg As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbmerchant_enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Validated
        Try
            If cmbmerchant.Text.Trim <> "" Then cmbmerchant.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor, "   INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesignno.Text & "' AND  itemmaster.item_name='" & cmbmerchant.Text & "'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me, "   INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesignno.Text & "' AND  itemmaster.item_name='" & cmbmerchant.Text & "'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbCONTRACTOR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcontractor.GotFocus
        Try
            If cmbcontractor.Text.Trim = "" Then fillCONTRACTOR(cmbcontractor)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbCONTRACTOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcontractor.Validating
        Try
            If cmbcontractor.Text.Trim <> "" Then CONTRACTORvalidate(cmbcontractor, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbSUPERVISIOR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsupervisior.GotFocus
        Try
            If cmbsupervisior.Text.Trim = "" Then fillSUPERVISIOR(cmbsupervisior)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbSUPERVISIOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsupervisior.Validating
        Try
            If cmbsupervisior.Text.Trim <> "" Then SUPERVISIORvalidate(cmbsupervisior, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesignno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesignno.GotFocus
        Try
            If cmbdesignno.Text.Trim = "" Then
                If ClientName = "SHREENATH" Then
                    FILLDESIGNNAME()
                Else
                    fillDESIGN(cmbdesignno, cmbmerchant.Text)
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesignno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesignno.Validated
        If ClientName <> "SHREENATH" Then
            fillCOLOR(cmbcolor, "   INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesignno.Text & "' AND  itemmaster.item_name='" & cmbmerchant.Text & "'")

            On Error Resume Next
            cmbcolor.SelectedIndex = (1)
        End If
    End Sub

    Private Sub cmbdesignno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesignno.Validating
        Try
            If cmbdesignno.Text.Trim <> "" Then
                If ClientName = "SHREENATH" Then
                    DESIGNNAMEVALIDATE(e)
                Else
                    DESIGNvalidate(cmbdesignno, e, Me, cmbmerchant.Text)
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        CMBGENERATE.SelectedIndex = 0

        EP.Clear()
        txtsrno.Clear()
        CMBITEMNAME.Text = ""
        txtgridremarks.Clear()
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        CPdate.Value = Mydate
        selectMFGtable.Clear()

        cmbcolor.Text = ""
        txtpcs.Clear()
        txtpcsmtrs.Clear()
        txtsaree.Clear()
        txtmtrs.Clear()
        TXTMFGNO.Clear()
        txtjobno.Clear()
        LBLACTCONSUMEDAMT.Text = 0
        LBLACTCONSUMEDQTY.Text = 0.0
        LBLDEFCONSUMEDAMT.Text = 0.0
        LBLDEFCONSUMEDQTY.Text = 0.0
        lbltotalsaree.Text = 0.0
        lbltotalmtrs.Text = 0.0
        lbltotalpcs.Text = 0.0
        lbltotalpcsmtrs.Text = 0.0
        txttotalmtrs.Text = 0.0
        TXTBALANCEMTRS.Text = 0.0
        txtselectedmtrs.Clear()
        txtcut.Clear()
        cmbmerchant.Text = ""
        txtlotno.Clear()
        cmbdesignno.Text = ""
        cmbcontractor.Text = ""
        cmbsupervisior.Text = ""
        cmbfromprocess.Text = ""
        cmbmerchant.Enabled = True

        txtremarks.Clear()
        txtquality.Clear()
        gridCP.RowCount = 0
        lbltotalpcsmtrs.Text = 0.0

        cmbfromprocess.Enabled = True
        CMDSELECTMFG.Enabled = True

        lbllocked.Visible = False
        PBlock.Visible = False
        gridDoubleClick = False

        getmax_CP_no() 'this function is for to get max value from the Purchase Requisition table

        If gridCP.RowCount > 0 Then
            txtsrno.Text = Val(gridCP.Rows(gridCP.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Sub getmax_CP_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CP_no),0) + 1 ", "CUTTINGPROCESS", " AND CP_cmpid=" & CmpId & " and CP_LOCATIONID=" & Locationid & " and CP_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCPNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub fillgrid()
        gridCP.Enabled = True
        If gridDoubleClick = False Then
            gridCP.Rows.Add(Val(txtsrno.Text.Trim), cmbpiecetype.Text.Trim, txtgridremarks.Text.Trim, cmbcolor.Text.Trim, Val(txtpcs.Text.Trim), Val(txtpcsmtrs.Text.Trim), txtsaree.Text.Trim, Val(txtmtrs.Text.Trim), 0, 0, 0, 0)
            getsrno(gridCP)
        ElseIf gridDoubleClick = True Then
            gridCP.Item(gsrno.Index, tempRow).Value = Val(txtsrno.Text.Trim)
            gridCP.Item(gpiecetype.Index, tempRow).Value = cmbpiecetype.Text.Trim
            gridCP.Item(gdesc.Index, tempRow).Value = txtgridremarks.Text.Trim
            gridCP.Item(gcolor.Index, tempRow).Value = cmbcolor.Text.Trim
            gridCP.Item(gpcs.Index, tempRow).Value = txtpcs.Text.Trim
            gridCP.Item(Gpcsmtrs.Index, tempRow).Value = txtpcsmtrs.Text.Trim
            gridCP.Item(gsaree.Index, tempRow).Value = txtsaree.Text.Trim
            gridCP.Item(Gmtrs.Index, tempRow).Value = Val(txtmtrs.Text.Trim)

            gridDoubleClick = False

        End If

        gridCP.FirstDisplayedScrollingRowIndex = gridCP.RowCount - 1
        pcstotal()
        txtsrno.Clear()
        'cmbpiecetype.Text = ""
        txtgridremarks.Clear()
        cmbcolor.Text = ""
        txtpcs.Clear()
        txtpcsmtrs.Clear()
        txtsaree.Clear()
        txtmtrs.Clear()

        txtsrno.Focus()

    End Sub

    Sub pcstotal()
        lbltotalpcs.Text = "0.00"
        lbltotalpcsmtrs.Text = "0.00"
        lbltotalsaree.Text = "0.00"
        lbltotalmtrs.Text = "0.00"
        For Each row As DataGridViewRow In gridCP.Rows
            If Val(row.Cells(gpcs.Index).Value) <> 0 Then
                lbltotalpcs.Text = Format(Val(lbltotalpcs.Text) + Val(row.Cells(gpcs.Index).Value), "0.00")
                lbltotalpcsmtrs.Text = Format(Val(lbltotalpcsmtrs.Text) + Val(row.Cells(Gpcsmtrs.Index).Value), "0.00")
                lbltotalsaree.Text = Format(Val(lbltotalsaree.Text) + Val(row.Cells(gsaree.Index).Value), "0.00")
                lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(row.Cells(Gmtrs.Index).Value), "0.00")
            End If
        Next
        txttotalmtrs.Text = lbltotalmtrs.Text
        If Val(txtselectedmtrs.Text.Trim) > 0 Then TXTBALANCEMTRS.Text = Format(Val(txtselectedmtrs.Text.Trim) - Val(txttotalmtrs.Text.Trim), "0.00")
    End Sub

    Private Sub gridpurchasereq_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCP.CellDoubleClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And gridCP.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then
            If Convert.ToBoolean(gridCP.Item(GDONE.Index, e.RowIndex).Value) = False Then
                gridDoubleClick = True
                txtsrno.Text = gridCP.Item(gsrno.Index, e.RowIndex).Value
                cmbpiecetype.Text = gridCP.Item(gpiecetype.Index, e.RowIndex).Value
                txtgridremarks.Text = gridCP.Item(gdesc.Index, e.RowIndex).Value
                cmbcolor.Text = gridCP.Item(gcolor.Index, e.RowIndex).Value
                txtpcs.Text = gridCP.Item(gpcs.Index, e.RowIndex).Value
                txtpcsmtrs.Text = gridCP.Item(Gpcsmtrs.Index, e.RowIndex).Value
                txtsaree.Text = gridCP.Item(gsaree.Index, e.RowIndex).Value
                txtmtrs.Text = gridCP.Item(Gmtrs.Index, e.RowIndex).Value

                tempRow = e.RowIndex
                txtsrno.Focus()
            Else
                MsgBox("Item Locked. First Delete Entry From Quotation")
            End If
        End If
    End Sub

    Sub generatejob()
        Dim objps As New PackingSlip
        
        objps.MdiParent = MDIMain
        objps.Show()
        For Each row As DataGridViewRow In gridCP.Rows
            objps.GRIDMFG.Rows.Add(0, row.Cells(gpiecetype.Index).Value, "", cmbmerchant.Text, txtcut.Text, cmbdesignno.Text, txtquality.Text, row.Cells(gcolor.Index).Value, txtlotno.Text, 0, 0, row.Cells(gsaree.Index).Value, Format(Val(row.Cells(Gmtrs.Index).Value), "0.00"), 0, "CUTTING", TXTCPNO.Text, row.Cells(gsrno.Index).Value, TXTCPNO.Text, row.Cells(gsrno.Index).Value, 0, selectMFGtable.Rows(0).Item("TYPE"))
        Next
        objps.CMBFROM.Text = "CUTTING"
        objps.CMBFROM.Enabled = False
        objps.getsrno(objps.GRIDMFG)
        objps.BringToFront()
       
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbfromprocess.Focus()
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

            alParaval.Add(CPdate.Value)

            alParaval.Add(cmbfromprocess.Text.Trim)
            alParaval.Add(cmbmerchant.Text.Trim)
            alParaval.Add(cmbcontractor.Text.Trim)
            alParaval.Add(cmbsupervisior.Text.Trim)
            alParaval.Add(Val(txtlotno.Text.Trim))
            alParaval.Add(txtquality.Text.Trim)
            alParaval.Add(Val(txtcut.Text.Trim))
            alParaval.Add(cmbdesignno.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)

            alParaval.Add(lbltotalpcs.Text.Trim)
            alParaval.Add(lbltotalpcsmtrs.Text.Trim)
            alParaval.Add(lbltotalsaree.Text.Trim)
            alParaval.Add(lbltotalmtrs.Text.Trim)
            alParaval.Add(0)
            alParaval.Add(txtjobno.text.trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            If CHKCOMPLETED.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            Dim gridsrno As String = ""
            Dim PIECETYPE As String = ""
            Dim gridremarks As String = ""
            Dim COLOR As String = ""
            Dim pcs As String = ""
            Dim pcsmtrs As String = ""
            Dim saree As String = ""
            Dim mtrs As String = ""
            Dim GRIDDONE As String = ""
            Dim MFGRECDPCS As String = ""
            Dim MFGRECDMTRS As String = ""
            Dim MFGRECDSAREE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridCP.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value
                        PIECETYPE = row.Cells(gpiecetype.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value
                        pcs = row.Cells(gpcs.Index).Value
                        pcsmtrs = row.Cells(Gpcsmtrs.Index).Value
                        saree = row.Cells(gsaree.Index).Value
                        mtrs = row.Cells(Gmtrs.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = 1
                        Else
                            GRIDDONE = 0
                        End If
                        MFGRECDPCS = row.Cells(GRECDPCS.Index).Value
                        MFGRECDMTRS = row.Cells(GRECDMTRS.Index).Value
                        MFGRECDSAREE = row.Cells(GRECDSAREE.Index).Value


                    Else
                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "," & row.Cells(gpiecetype.Index).Value.ToString
                        gridremarks = gridremarks & "," & row.Cells(gdesc.Index).Value.ToString
                        COLOR = COLOR & "," & row.Cells(gcolor.Index).Value
                        pcs = pcs & "," & row.Cells(gpcs.Index).Value
                        pcsmtrs = pcsmtrs & "," & row.Cells(Gpcsmtrs.Index).Value
                        saree = saree & "," & row.Cells(gsaree.Index).Value
                        mtrs = mtrs & "," & row.Cells(Gmtrs.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = GRIDDONE & "," & 1
                        Else
                            GRIDDONE = GRIDDONE & "," & 0
                        End If
                        MFGRECDPCS = MFGRECDPCS & "," & row.Cells(GRECDPCS.Index).Value
                        MFGRECDMTRS = MFGRECDMTRS & "," & row.Cells(GRECDMTRS.Index).Value
                        MFGRECDSAREE = MFGRECDSAREE & "," & row.Cells(GRECDSAREE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(gridremarks)
            alParaval.Add(COLOR)
            alParaval.Add(pcs)
            alParaval.Add(pcsmtrs)
            alParaval.Add(saree)
            alParaval.Add(mtrs)
            alParaval.Add(GRIDDONE)
            alParaval.Add(MFGRECDPCS)
            alParaval.Add(MFGRECDMTRS)
            alParaval.Add(MFGRECDSAREE)


            Dim CONSUMEDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim DEFQTY As String = ""
            Dim ACTQTY As String = ""
            Dim UNIT As String = ""
            Dim DEFRATE As String = ""
            Dim ACTRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONSUMPTION.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CONSUMEDSRNO = "" Then
                        CONSUMEDSRNO = row.Cells(GCONSUMEDSRNO.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        DEFQTY = row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = row.Cells(GactQty.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = row.Cells(GdefRATE.Index).Value.ToString
                        ACTRATE = row.Cells(gActRate.Index).Value.ToString

                    Else

                        CONSUMEDSRNO = CONSUMEDSRNO & "," & row.Cells(GCONSUMEDSRNO.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value
                        gridremarks = gridremarks & "," & row.Cells(gdesc.Index).Value.ToString
                        DEFQTY = DEFQTY & "," & row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = ACTQTY & "," & row.Cells(GactQty.Index).Value.ToString
                        UNIT = UNIT & "," & row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = DEFRATE & "," & row.Cells(GdefRATE.Index).Value
                        ACTRATE = ACTRATE & "," & row.Cells(gActRate.Index).Value

                    End If
                End If
            Next

            alParaval.Add(CONSUMEDSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(DEFQTY)
            alParaval.Add(ACTQTY)
            alParaval.Add(UNIT)
            alParaval.Add(DEFRATE)
            alParaval.Add(ACTRATE)

            Dim CHECKGRIDSRNO As String = ""

            Dim INMTRS As String = ""
            Dim RECDMTRS As String = ""
            Dim DONE As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim CHECKNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim CHECKSRNO As String = ""    'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGNO As String = ""            'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE

            Dim LOTSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim TYPE As String = ""          'WHETHER GRN IS DONE FOR THIS LINE

            For Each dr As DataRow In selectMFGtable.Rows
                If dr("RECDMTRS") > 0 Then
                    If CHECKGRIDSRNO = "" Then
                        CHECKGRIDSRNO = dr("CHECKGRIDSRNO")
                        INMTRS = dr("INMTRS")
                        RECDMTRS = dr("RECDMTRS")
                        DONE = 0

                        CHECKNO = dr("CHECKNO")
                        CHECKSRNO = dr("CHECKSRNO")
                        MFGNO = dr("MFGNO")
                        MFGSRNO = dr("MFGSRNO")
                        LOTSRNO = dr("LOTSRNO")
                        TYPE = dr("TYPE").ToString
                    Else

                        CHECKGRIDSRNO = CHECKGRIDSRNO & "," & dr("CHECKGRIDSRNO")
                        INMTRS = INMTRS & "," & dr("INMTRS")
                        RECDMTRS = RECDMTRS & "," & dr("RECDMTRS")
                        DONE = DONE & "," & 0
                        CHECKNO = CHECKNO & "," & dr("CHECKNO")
                        CHECKSRNO = CHECKSRNO & "," & dr("CHECKSRNO")
                        MFGNO = MFGNO & "," & dr("MFGNO")
                        MFGSRNO = MFGSRNO & "," & dr("MFGSRNO")
                        LOTSRNO = LOTSRNO & "," & dr("LOTSRNO")
                        TYPE = TYPE & "," & dr("TYPE").ToString
                    End If
                End If
            Next

            alParaval.Add(CHECKGRIDSRNO)
            alParaval.Add(INMTRS)
            alParaval.Add(RECDMTRS)
            alParaval.Add(DONE)
            alParaval.Add(CHECKNO)
            alParaval.Add(CHECKSRNO)
            alParaval.Add(MFGNO)
            alParaval.Add(MFGSRNO)
            alParaval.Add(LOTSRNO)
            alParaval.Add(TYPE)

            Dim objclsCP As New ClsCuttingProcess
            objclsCP.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsCP.save()
                MessageBox.Show("Details Added")
            Else
                alParaval.Add(tempcpno)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsCP.Update()
                MsgBox("Details Updated")
            End If
            edit = False


            If edit = False Then
                Dim TEMPMSG As Integer = MsgBox("Generate Job Packing Slip?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then If CMBGENERATE.Text = "Job Packing Slip" Then generatejob()
            End If

            clear()
            cmbfromprocess.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If gridCP.RowCount = 0 Then
            EP.SetError(txtpcs, "Enter Item Details")
            bln = False
        End If

      
        Dim TOTALMTRS As Double = lbltotalmtrs.Text
        If TOTALMTRS > 0 Then
            For Each dr As DataRow In selectMFGtable.Rows

                If TOTALMTRS >= dr("INMTRS") Then
                    dr("RECDMTRS") = dr("INMTRS")
                    TOTALMTRS = TOTALMTRS - dr("INMTRS")
                    dr("CHECKDONE") = True
                Else
                    dr("RECDMTRS") = TOTALMTRS
                    TOTALMTRS = 0
                    dr("CHECKDONE") = False
                End If


            Next
        End If
        'End If


        'DONT ALLOW TO SAVE MORE THAN STOCKMTRS
        'DONE BY GULKIT, AS IT IS CREATING ISSUE
        'Dim OBJCMN As New ClsCommon
        'Dim DT As DataTable = OBJCMN.search("SUM(MTRS) as MTRS", "", "VIEW_SUMMARY_MFG1", " AND LOTNO = " & Val(txtlotno.Text.Trim) & " AND YEARID = " & YearId)
        'If DT.Rows.Count > 0 AndAlso Val(lbltotalmtrs.Text.Trim) > Val(DT.Rows(0).Item("MTRS")) Then
        '    EP.SetError(cmbmerchant, "Mtrs Greater then Stock Mtrs")
        '    bln = False
        'End If



        If cmbmerchant.Text.Trim.Length = 0 Then
            EP.SetError(cmbmerchant, "Please Select Item")
            bln = False
        End If

        'MTRS CANNOT BE NEGATIVE
        If TXTBALANCEMTRS.Text < 0 Then
            EP.SetError(TXTBALANCEMTRS, "Mtrs cannot be Negative")
            bln = False
        End If

        If txtcut.Text.Trim.Length = 0 Then
            EP.SetError(txtcut, "Enter Cut Size")
            bln = False
        End If

        If chkchange.CheckState = CheckState.Unchecked Then
            EP.SetError(txtpcs, "Enter Item Details")
            bln = False
        End If

        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Mfg Raised, Delete Mfg First")
        '    bln = False
        'End If

        If Not datecheck(CPdate.Value) Then bln = False
        Return bln
    End Function

    Private Sub CUTTINGPROCESS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                ' Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
6:
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
                'Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
                Call CMDSELECTMFG_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CUTTINGPROCESS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Sub FILLDESIGNNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search(" DESIGN_NAME AS DESIGNNAME", "", "  DESIGNMASTER ", " and DESIGN_cmpid=" & CmpId & " and DESIGN_locationid = " & Locationid & " and DESIGN_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DESIGNNAME"
                cmbdesignno.DataSource = dt
                cmbdesignno.DisplayMember = "DESIGNNAME"
                cmbdesignno.Text = ""
            End If
            cmbdesignno.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DESIGNNAMEVALIDATE(ByRef e As System.ComponentModel.CancelEventArgs)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbdesignno.Text.Trim <> "" Then
                pcase(cmbdesignno)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("DESIGN_NAME AS DESIGNNAME ", "", " DESIGNMASTER ", " and DESIGN_NAME = '" & cmbdesignno.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbdesignno.Text.Trim
                    Dim tempmsg As Integer = MsgBox("DESIGN not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        cmbdesignno.Text = a
                        Dim OBJDESIGN As New DesignMaster
                        OBJDESIGN.TEMPDESIGNNO = cmbdesignno.Text.Trim()
                        OBJDESIGN.ShowDialog()
                        dt = objclscommon.search("DESIGN_NAME ", "", "  DESIGNMASTER  ", " and DESIGN_NAME = '" & cmbdesignno.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbdesignno.DataSource
                            If cmbdesignno.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbdesignno.Text.Trim)
                                    cmbdesignno.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CUTTINGPROCESS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)



            fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillCOLOR(cmbcolor)
            fillPIECETYPE(cmbpiecetype)
            fillunit(cmbunit)
            fillCONTRACTOR(cmbcontractor)
            fillSUPERVISIOR(cmbsupervisior)
            FILLGODOWN(CMBGODOWN, False)
            If ClientName = "SHREENATH" Then
                FILLDESIGNNAME()
            Else
                fillDESIGN(cmbdesignno, cmbmerchant.Text)
            End If
            FILLPROCESS(cmbfromprocess, " AND (PROCESSMASTER.PROCESS_TYPE='MFG' OR PROCESSMASTER.PROCESS_TYPE='CHECKING')", False)

            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim objclsCP As New ClsCuttingProcess

                ALPARAVAL.Add(tempcpno)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsCP.alParaval = ALPARAVAL
                Dim dt As DataTable = objclsCP.selectCP()
                Dim GRIDSRNO As Integer = 0
                Dim CHECKGRIDSRNO As Integer = 0
                Dim CONSUMEGRIDSRNO As Integer = 0

                If dt.Rows.Count > 0 Then


                    For Each dr As DataRow In dt.Rows

                        TXTCPNO.Text = tempcpno
                        CPdate.Value = Convert.ToDateTime(dr("CPdate"))
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        txtcut.Text = Convert.ToString(dr("CUT"))
                        txtlotno.Text = Convert.ToString(dr("LOTNO"))
                        txtquality.Text = Convert.ToString(dr("QUALITY"))
                        cmbcontractor.Text = Convert.ToString(dr("CONTRACTOR"))
                        cmbdesignno.Text = Convert.ToString(dr("DESIGNNO"))
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        cmbmerchant.Text = Convert.ToString(dr("MERCHANT"))
                        cmbsupervisior.Text = Convert.ToString(dr("SUPERVISIOR"))
                        txttotalmtrs.Text = Convert.ToString(dr("TOTALMTRS"))
                        txtjobno.Text = Convert.ToString(dr("JOBNO"))
                        cmbfromprocess.Text = Convert.ToString(dr("PROCESS").ToString)
                        If dr("gridsrno") <> GRIDSRNO Then
                            gridCP.Rows.Add(dr("gridsrno").ToString, dr("PIECETYPE").ToString, dr("DESC").ToString, dr("COLOR").ToString, dr("pcs").ToString, dr("pcsmtrs").ToString, dr("saree").ToString, dr("MTRS").ToString, dr("GRIDdone").ToString, dr("MFGRECDPCS"), dr("MFGRECDMTRS"), dr("MFGRECDSAREE"))
                        End If
                        If Val(dr("LOTNO")) = 0 Then
                            CMDSELECTMFG.Enabled = True
                        End If
                    Next

                    'If cmbfromprocess.Text <> "" Then
                    '    cmbfromprocess.Enabled = False
                    'End If
                    gridCP.FirstDisplayedScrollingRowIndex = gridCP.RowCount - 1
                End If

                'code for to change colour of grid line Item if particular grid line item is done 
                For Each row As DataGridViewRow In gridCP.Rows
                    If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If

                Next
                'end of current blok
                Dim OBJCMN As New ClsCommon
                dt = OBJCMN.search("  CUTTINGPROCESS_CONSUMED.CP_SRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, CUTTINGPROCESS_CONSUMED.CP_DEFQTY AS DEFQTY,CUTTINGPROCESS_CONSUMED.CP_ACTQTY AS ACTQTY, UNITMASTER.unit_abbr AS UNIT, CUTTINGPROCESS_CONSUMED.CP_DEFRATE AS DEFRATE, CUTTINGPROCESS_CONSUMED.CP_ACTRATE AS ACTRATE", "", " CUTTINGPROCESS_CONSUMED INNER JOIN ITEMMASTER ON CUTTINGPROCESS_CONSUMED.CP_ITEMID = ITEMMASTER.item_id AND CUTTINGPROCESS_CONSUMED.CP_CMPID = ITEMMASTER.item_cmpid AND CUTTINGPROCESS_CONSUMED.CP_LOCATIONID = ITEMMASTER.item_locationid AND CUTTINGPROCESS_CONSUMED.CP_YEARID = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON CUTTINGPROCESS_CONSUMED.CP_UNITID = UNITMASTER.unit_id AND CUTTINGPROCESS_CONSUMED.CP_CMPID = UNITMASTER.unit_cmpid AND CUTTINGPROCESS_CONSUMED.CP_LOCATIONID = UNITMASTER.unit_locationid AND CUTTINGPROCESS_CONSUMED.CP_YEARID = UNITMASTER.unit_yearid", " AND CUTTINGPROCESS_CONSUMED.CP_NO = " & tempcpno & " AND CUTTINGPROCESS_CONSUMED.CP_CMPID = " & CmpId & " AND CUTTINGPROCESS_CONSUMED.CP_LOCATIONID  = " & Locationid & " AND CUTTINGPROCESS_CONSUMED.CP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        GRIDCONSUMPTION.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEMNAME"), Format(DR("DEFQTY"), "0.00"), Format(DR("ACTQTY"), "0.00"), DR("UNIT"), Format(DR("DEFRATE"), "0.00"), Format(DR("ACTRATE"), "0.00"))
                    Next
                End If

                dt = OBJCMN.search(" CP_NO AS CPNO, CP_CHECKSRNO AS CHECKSRNO, CP_INMTRS AS INMTRS, CP_RECDMTRS AS RECDMTRS, CP_CHECKDONE AS CHECKDONE, CP_CHECKNO AS CHECKNO, CP_CHECKGRIDSRNO AS CHECKGRIDSRNO, CP_MFGNO AS MFGNO, CP_MFGSRNO AS MFGSRNO, CP_LOTNO AS LOTNO, CP_LOTSRNO AS LOTSRNO, CP_TYPE AS TYPE ", "", " CUTTINGPROCESS_CHECKDESC", " AND CUTTINGPROCESS_CHECKDESC.CP_NO = " & tempcpno & " AND CUTTINGPROCESS_CHECKDESC.CP_CMPID = " & CmpId & " AND CUTTINGPROCESS_CHECKDESC.CP_LOCATIONID  = " & Locationid & " AND CUTTINGPROCESS_CHECKDESC.CP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then

                    'Dim I As Integer = 0
                    'Dim NEWDT As New DataTable 'dt.Columns.Add("CHECKNO")
                    'NEWDT.Columns.Add("CHECKNO")
                    'NEWDT.Columns.Add("CHECKSRNO")
                    'NEWDT.Columns.Add("MFGNO")
                    'NEWDT.Columns.Add("MFGSRNO")
                    'NEWDT.Columns.Add("LOTNO")
                    'NEWDT.Columns.Add("LOTSRNO")
                    'NEWDT.Columns.Add("TYPE")
                    'NEWDT.Columns.Add("ITEMNAME")
                    'NEWDT.Columns.Add("QUALITY")
                    'NEWDT.Columns.Add("REED")
                    'NEWDT.Columns.Add("PICK")
                    'NEWDT.Columns.Add("CHECKGRIDSRNO")
                    'NEWDT.Columns.Add("INMTRS", System.Type.GetType("System.Decimal"))
                    'NEWDT.Columns.Add("RECDMTRS", System.Type.GetType("System.Decimal"))
                    'NEWDT.Columns.Add("CHECKDONE")
                    'dt = OBJCMN.search("  MFGMASTER_DESC.MFG_CHECKNO AS CHECKNO, MFGMASTER_DESC.MFG_CHECKGRIDSRNO AS CHECKSRNO, MFGMASTER_DESC.MFG_NO AS [MFGNO], MFGMASTER_DESC.MFG_SRNO AS [MFGSRNO], MFGMASTER_DESC.MFG_LOTNO AS [LOTNO], MFGMASTER_DESC.MFG_LOTSRNO AS [LOTSRNO], MFGMASTER_DESC.MFG_TYPE AS [TYPE],ITEMMASTER.item_name AS [ITEMNAME], QUALITYMASTER.QUALITY_name AS [QUALITY], 	MFGMASTER.MFG_REED AS REED, MFGMASTER.MFG_PICK AS PICK, 0 AS CHECKGRIDSRNO,	COLORMASTER.COLOR_name AS Color, ISNULL(MFGMASTER_DESC.MFG_RECDMTRS,0)  AS INMTRS ", "", " dbo.MFGMASTER INNER JOIN dbo.PROCESSMASTER ON MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID AND MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN dbo.ITEMMASTER ON MFGMASTER.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER.MFG_YEARID = ITEMMASTER.item_yearid INNER JOIN dbo.MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID INNER JOIN dbo.PIECETYPEMASTER ON MFGMASTER_DESC.MFG_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND MFGMASTER_DESC.MFG_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND MFGMASTER_DESC.MFG_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND MFGMASTER_DESC.MFG_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN dbo.CUTTINGPROCESS_DESCVIEW ON dbo.MFGMASTER_DESC.MFG_NO = dbo.CUTTINGPROCESS_DESCVIEW.CP_MFGNO AND dbo.MFGMASTER_DESC.MFG_SRNO = dbo.CUTTINGPROCESS_DESCVIEW.CP_MFGSRNO AND dbo.MFGMASTER_DESC.MFG_CHECKNO = dbo.CUTTINGPROCESS_DESCVIEW.CP_CHECKNO AND dbo.MFGMASTER_DESC.MFG_CHECKGRIDSRNO = dbo.CUTTINGPROCESS_DESCVIEW.CP_CHECKGRIDSRNO  LEFT OUTER JOIN dbo.COLORMASTER ON MFGMASTER_DESC.MFG_YEARID = COLORMASTER.COLOR_yearid AND MFGMASTER_DESC.MFG_LOCATIONID = COLORMASTER.COLOR_locationid AND MFGMASTER_DESC.MFG_CMPID = COLORMASTER.COLOR_cmpid AND MFGMASTER_DESC.MFG_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN dbo.QUALITYMASTER ON MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND MFGMASTER.MFG_NO = " & Val(dt.Rows(0).Item(0)) & " AND MFGMASTER.MFG_CMPID = " & CmpId & " AND MFGMASTER.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER.MFG_YEARID = " & YearId)
                    'If dt.Rows.Count > 0 Then
                    '    For Each NDTROW As DataRow In dt.Rows
                    '        I = I + 1
                    '        NEWDT.Rows.Add(NDTROW("CHECKNO"), NDTROW("CHECKSRNO"), NDTROW("MFGNO"), NDTROW("MFGSRNO"), NDTROW("LOTNO"), NDTROW("LOTSRNO"), NDTROW("TYPE"), NDTROW("ITEMNAME"), NDTROW("QUALITY"), NDTROW("REED"), NDTROW("PICK"), I, NDTROW("INMTRS"), 0, 0)
                    '    Next
                    'End If
                    CuttingProcess.selectMFGtable = dt
                    txtselectedmtrs.Text = dt.Compute("sum([RECDMTRS])", "")
                    txtlotno.Text = dt.Rows(0).Item("lotno")
                End If
                '***************************************



                chkchange.CheckState = CheckState.Checked
                pcstotal()
                If Val(txttotalmtrs.Text) > 0 Then cmbfromprocess.Enabled = False
            End If

            If edit = False Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable

                FILLMACHINENO()


                GRIDCONSUMPTION.RowCount = 0

                DT = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, PROCESS_DESC.PROCESS_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, PROCESS_DESC.PROCESS_RATE AS RATE", "", " PROCESS_DESC INNER JOIN ITEMMASTER ON PROCESS_DESC.PROCESS_ITEMid = ITEMMASTER.item_id AND PROCESS_DESC.PROCESS_cmpid = ITEMMASTER.item_cmpid AND PROCESS_DESC.PROCESS_locationid = ITEMMASTER.item_locationid AND PROCESS_DESC.PROCESS_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PROCESS_DESC.PROCESS_cmpid = UNITMASTER.unit_cmpid AND PROCESS_DESC.PROCESS_locationid = UNITMASTER.unit_locationid AND PROCESS_DESC.PROCESS_yearid = UNITMASTER.unit_yearid AND PROCESS_DESC.PROCESS_unitid = UNITMASTER.unit_id INNER JOIN PROCESSMASTER ON PROCESS_DESC.PROCESS_id = PROCESSMASTER.PROCESS_ID AND PROCESS_DESC.PROCESS_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESS_DESC.PROCESS_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESS_DESC.PROCESS_yearid = PROCESSMASTER.PROCESS_YEARID", " AND PROCESSMASTER.PROCESS_NAME = 'CUTTING' AND PROCESS_DESC.PROCESS_CMPID = " & CmpId & " AND PROCESS_DESC.PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_DESC.PROCESS_YEARID= " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows
                        GRIDCONSUMPTION.Rows.Add(0, DR("ITEMNAME"), DR("QTY"), DR("QTY"), DR("UNIT"), DR("RATE"), DR("RATE"))
                    Next
                    getsrno(GRIDCONSUMPTION)
                    TOTALCONSUMPTION()
                End If

            End If
            'If cmbfromprocess.Text <> "" And lbltotalmtrs.Text <> 0 Then CMDSELECTMFG.Enabled = False

            'If gridDoubleClick = False Then
            If gridCP.RowCount > 0 Then
                txtsrno.Text = Val(gridCP.Rows(gridCP.RowCount - 1).Cells(gsrno.Index).Value) + 1
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
            If gridCP.RowCount > 0 Then
                txtsrno.Text = Val(gridCP.Rows(gridCP.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtpcs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpcs.KeyPress
        numdot(e, txtpcs, Me)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim IntResult As Integer
            If edit = True Then
                Dim BLN As Boolean = True

                'CHCKING FOR LOCK
                For Each ROW As DataGridViewRow In gridCP.Rows
                    If Convert.ToBoolean(ROW.Cells(GDONE.Index).Value) = True Then
                        BLN = False
                    End If
                Next

                If lbllocked.Visible = True Then BLN = False

                If BLN = False Then
                    MsgBox("mFG Raised, Delete MFG First", MsgBoxStyle.Critical)
                    Exit Sub
                Else

                    tempMsg = MsgBox("Delete MFG?", MsgBoxStyle.YesNo)
                    If tempMsg = vbYes Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(tempcpno)
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(YearId)

                        Dim OBJMFG As New ClsCuttingProcess()
                        OBJMFG.alParaval = alParaval
                        IntResult = OBJMFG.Delete()
                        MsgBox("MFG Deleted")
                        clear()
                        edit = False
                    End If
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

            Dim objprdetails As New CuttingProcessDetails
            objprdetails.MdiParent = MDIMain
            objprdetails.Show()
            objprdetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        tempcpno = Val(TXTCPNO.Text) - 1
        clear()
        If tempcpno > 0 Then
            edit = True
            CUTTINGPROCESS_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        tempcpno = Val(TXTCPNO.Text) + 1
        getmax_CP_no()
        clear()
        If Val(TXTCPNO.Text) - 1 >= tempcpno Then
            edit = True
            CUTTINGPROCESS_Load(sender, e)
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

    Private Sub CPdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CPdate.Validating
        If Not datecheck(CPdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click

        Try
            If edit = True Then PRINTREPORT(tempcpno)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal CPNO As Integer)
        Try
            'Dim TEMPMSG As Integer = MsgBox("Print Sale Return Invoice?", MsgBoxStyle.YesNo)
            'If TEMPMSG = vbYes Then
            Dim OBJCP As New CPDESIGN
            OBJCP.MdiParent = MDIMain
            OBJCP.selformula = "{CUTTINGPROCESS.CP_no}=" & CPNO & " and {CUTTINGPROCESS.CP_cmpid}=" & CmpId & " and {CUTTINGPROCESS.CP_locationid}=" & Locationid & " and {CUTTINGPROCESS.CP_yearid}=" & YearId
            OBJCP.Show()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpurchasereq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridCP.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridCP.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                If edit = True Then
                    Dim isyellow As Boolean = False
                    For Each row As DataGridViewRow In gridCP.SelectedRows
                        isyellow = Convert.ToBoolean(row.Cells(GDONE.Index).Value)
                    Next
                    If isyellow = True Then
                        MessageBox.Show("Row is Locked, You Cannot Delete This Row")
                        Exit Sub
                    End If
                End If
                'End of current Block

                gridCP.Rows.RemoveAt(gridCP.CurrentRow.Index)
                pcstotal()
                getsrno(gridCP)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub txtgridremarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgridremarks.KeyPress
        commakeypress(e, txtgridremarks, Me)
    End Sub
    Private Sub tstxtbillno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        tempcpno = Val(tstxtbillno.Text)
        clear()
        If tempcpno > 0 Then
            edit = True
            CUTTINGPROCESS_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub CMDSELECTMFG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTMFG.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If cmbfromprocess.Text <> "" Then
                Dim OBJSELECTMFG As New SelectMfg
                OBJSELECTMFG.FRMSTRING = "MFG"
                OBJSELECTMFG.CUTTING = True
                OBJSELECTMFG.GODOWN = CMBGODOWN.Text.Trim
                OBJSELECTMFG.PROCESSNAME = cmbfromprocess.Text.Trim
                OBJSELECTMFG.ShowDialog()

                Dim i As Integer = 0
                If selectMFGtable.Rows.Count > 0 Then
                    chkchange.Checked = True
                    cmbfromprocess.Enabled = False
                    CMDSELECTMFG.Enabled = False
                    'gridCP.RowCount = 0
                    cmbfromprocess.Enabled = False
                    txtlotno.Text = selectMFGtable.Rows(0).Item("lotno")
                    txtquality.Text = selectMFGtable.Rows(0).Item("quality").ToString
                    TXTMFGNO.Text = selectMFGtable.Rows(0).Item("MFGNO")

                    'GET SELECTED MTRS FROM VIEW_SUMMARY_MFG1
                    'txtselectedmtrs.Text = selectMFGtable.Compute(" sum([INMTRS])", "")
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("SUM(MTRS) AS MTRS", "", " VIEW_SUMMARY_MFG1 ", " AND LOTNO = " & Val(txtlotno.Text.Trim) & " AND YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        txtselectedmtrs.Text = Val(DT.Rows(0).Item("MTRS"))
                    End If

                    If Val(txtselectedmtrs.Text.Trim) > 0 Then CMDSELECTMFG.Enabled = False
                End If
                pcstotal()
            Else
                MsgBox("Select Process First!", MsgBoxStyle.Critical)
                cmbfromprocess.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpcsmtrs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpcsmtrs.Validating
        calcmtrs()
    End Sub

    Sub calcmtrs()
        If Val(txtcut.Text) > 0 And Val(txtpcs.Text) > 0 And Val(txtpcsmtrs.Text) > 0 Then
            txtmtrs.Text = Val(txtpcs.Text) * Val(txtpcsmtrs.Text)
            txtsaree.Text = Math.Ceiling(Val(txtmtrs.Text) / Val(txtcut.Text))
        End If
    End Sub

    Private Sub txtpcs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpcs.Validating
        calcmtrs()
    End Sub

    Private Sub txtcut_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcut.Enter
        If cmbdesignno.Text <> "" And edit = False And gridCP.RowCount = 0 Then

            For I As Integer = 0 To cmbcolor.Items.Count - 1
                cmbcolor.SelectedIndex = (I)
                gridCP.Rows.Add(I + 1, "FRESH", "", cmbcolor.Text, 0, 0, 0, 0, 0, 0, 0, 0)

            Next

        End If
    End Sub

    Private Sub txtcut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcut.Validating
        If gridCP.RowCount > 0 Then
            For Each row As DataGridViewRow In gridCP.Rows
                If Val(txtcut.Text) > 0 And row.Cells(gpcs.Index).Value > 0 And Val(row.Cells(Gpcsmtrs.Index).Value) > 0 Then
                    row.Cells(Gmtrs.Index).Value = Val(row.Cells(gpcs.Index).Value) * Val(row.Cells(Gpcsmtrs.Index).Value)
                    row.Cells(gsaree.Index).Value = Math.Floor(Val(row.Cells(Gmtrs.Index).Value) / Val(txtcut.Text))
                End If
            Next
        Else
            calcmtrs()

        End If
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

    Private Sub txtmtrs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmtrs.Validating
        If cmbpiecetype.Text <> "" Then

            If Val(txtmtrs.Text) <> 0 And Val(txtlotno.Text) = 0 Then
                MsgBox("Select Lot First")
                Exit Sub
            End If
            fillgrid()
        End If
    End Sub

    Private Sub cmbFROMPROCESS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfromprocess.GotFocus
        Try
            If cmbfromprocess.Text.Trim = "" Then FILLPROCESS(cmbfromprocess, " And (PROCESSMASTER.PROCESS_TYPE='MFG' OR PROCESSMASTER.PROCESS_TYPE='CHECKING')", False)
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

    Sub TOTALCONSUMPTION()
        Try
            LBLACTCONSUMEDQTY.Text = 0.0
            LBLACTCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDCONSUMPTION.Rows
                If ROW.Cells(GCONSUMEDSRNO.Index).Value <> Nothing Then
                    LBLACTCONSUMEDQTY.Text = Format(Val(LBLACTCONSUMEDQTY.Text) + Val(ROW.Cells(GactQty.Index).EditedFormattedValue), "0.00")
                    LBLACTCONSUMEDAMT.Text = Format(Val(LBLACTCONSUMEDAMT.Text) + Val(ROW.Cells(gActRate.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDQTY.Text = Format(Val(LBLDEFCONSUMEDQTY.Text) + Val(ROW.Cells(GdefQTY.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDAMT.Text = Format(Val(LBLDEFCONSUMEDAMT.Text) + Val(ROW.Cells(GdefRATE.Index).EditedFormattedValue), "0.00")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTACTRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTACTRATE.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" And Val(txtactqty.Text.Trim) > 0 And cmbunit.Text.Trim <> "" Then

                'CHECK WHETHER ITEM IS PRESENT IN GRID BELOW OR NOT
                For Each ROW As DataGridViewRow In GRIDCONSUMPTION.Rows
                    If (LCase(ROW.Cells(GITEMNAME.Index).Value) = LCase(CMBITEMNAME.Text.Trim) And gridDoubleClick = False) Or (LCase(ROW.Cells(GITEMNAME.Index).Value) = LCase(CMBITEMNAME.Text.Trim) And gridDoubleClick = True And tempRow <> ROW.Index) Then
                        MsgBox("Item Already Present in Grid Below", MsgBoxStyle.Critical)
                        CMBITEMNAME.Focus()
                        Exit Sub
                    End If
                Next

                fillCONSUMPTIONgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCONSUMPTIONgrid()

        If gridDoubleClick = False Then
            GRIDCONSUMPTION.Rows.Add(Val(txtsrno.Text.Trim), CMBITEMNAME.Text.Trim, Format(Val(txtdefqty.Text.Trim), "0.00"), Format(Val(txtactqty.Text.Trim), "0.00"), cmbunit.Text.Trim, Format(Val(txtdefrate.Text.Trim), "0.00"), Format(Val(TXTACTRATE.Text.Trim), "0.00"))
            getsrno(GRIDCONSUMPTION)
        ElseIf gridDoubleClick = True Then
            GRIDCONSUMPTION.Item(GCONSUMEDSRNO.Index, tempRow).Value = Val(txtsrno.Text.Trim)
            GRIDCONSUMPTION.Item(GITEMNAME.Index, tempRow).Value = CMBITEMNAME.Text.Trim
            GRIDCONSUMPTION.Item(GdefQTY.Index, tempRow).Value = Format(Val(txtdefqty.Text.Trim), "0.00")
            GRIDCONSUMPTION.Item(GactQty.Index, tempRow).Value = Format(Val(txtactqty.Text.Trim), "0.00")
            GRIDCONSUMPTION.Item(GUNIT.Index, tempRow).Value = cmbunit.Text.Trim
            GRIDCONSUMPTION.Item(GdefRATE.Index, tempRow).Value = Format(Val(txtdefrate.Text.Trim), "0.00")
            GRIDCONSUMPTION.Item(gActRate.Index, tempRow).Value = Format(Val(TXTACTRATE.Text.Trim), "0.00")
            gridDoubleClick = False
        End If

        TOTALCONSUMPTION()

        GRIDCONSUMPTION.FirstDisplayedScrollingRowIndex = GRIDCONSUMPTION.RowCount - 1
        If gridDoubleClick = False Then
            If GRIDCONSUMPTION.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCONSUMPTION.Rows(GRIDCONSUMPTION.RowCount - 1).Cells(GCONSUMEDSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If

        CMBITEMNAME.Text = ""
        txtactqty.Clear()
        txtdefqty.Clear()
        cmbunit.Text = ""
        TXTACTRATE.Clear()
        txtdefrate.Clear()
        txtsrno.Focus()

    End Sub

    Private Sub GRIDCONSUMPTION_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCONSUMPTION.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCONSUMPTION.Item(GCONSUMEDSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                txtsrno.Text = GRIDCONSUMPTION.Item(GCONSUMEDSRNO.Index, e.RowIndex).Value.ToString
                CMBITEMNAME.Text = GRIDCONSUMPTION.Item(GITEMNAME.Index, e.RowIndex).Value.ToString
                txtdefqty.Text = GRIDCONSUMPTION.Item(GdefQTY.Index, e.RowIndex).Value.ToString
                txtactqty.Text = GRIDCONSUMPTION.Item(GactQty.Index, e.RowIndex).Value.ToString
                cmbunit.Text = GRIDCONSUMPTION.Item(GUNIT.Index, e.RowIndex).Value.ToString
                txtdefrate.Text = GRIDCONSUMPTION.Item(GdefRATE.Index, e.RowIndex).Value.ToString
                TXTACTRATE.Text = GRIDCONSUMPTION.Item(gActRate.Index, e.RowIndex).Value.ToString

                tempRow = e.RowIndex
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLMACHINENO()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            'FILLING MACHINES FROM MACHINE MASTER
            DT = OBJCMN.search(" MACHINE_NO", "", " MACHINEMASTER INNER JOIN PROCESSMASTER ON MACHINE_PROCESSID = PROCESS_ID AND MACHINE_CMPID = PROCESS_CMPID AND MACHINE_LOCATIONID = PROCESS_LOCATIONID AND MACHINE_YEARID = PROCESS_YEARID", " AND PROCESS_NAME = 'CUTTING' AND MACHINE_CMPID = " & CmpId & " AND MACHINE_LOCATIONID = " & Locationid & " AND MACHINE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "MACHINE_NO"
                cmbmachineno.DataSource = DT
                cmbmachineno.DisplayMember = "MACHINE_NO"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
        Try
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunit.KeyPress
        commakeypress(e, cmbunit, Me)
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND itemmaster.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBITEMNAME.KeyPress
        commakeypress(e, CMBITEMNAME, Me)

    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND itemmaster.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

            If gridCP.RowCount > 0 Then


                For Each ROW As DataGridViewRow In gridCP.SelectedRows
                    txtsrno.Text = gridCP.RowCount + 1
                    cmbpiecetype.Text = ROW.Cells(gpiecetype.Index).Value.ToString
                    txtgridremarks.Text = ROW.Cells(gdesc.Index).Value.ToString

                    cmbcolor.Text = ROW.Cells(gcolor.Index).Value.ToString
                    txtpcs.Text = ROW.Cells(gpcs.Index).Value.ToString
                    txtpcsmtrs.Text = ROW.Cells(Gpcsmtrs.Index).Value.ToString

                    txtsaree.Text = ROW.Cells(gsaree.Index).Value.ToString
                    txtmtrs.Text = ROW.Cells(Gmtrs.Index).Value.ToString


                    cmbcolor.Focus()
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GRIDCONSUMPTION_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDCONSUMPTION.CellValidating
        Try
            Dim colNum As Integer = GRIDCONSUMPTION.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GactQty.Index, gActRate.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCONSUMPTION.CurrentCell.Value = Nothing Then GRIDCONSUMPTION.CurrentCell.Value = "0.00"
                        GRIDCONSUMPTION.CurrentCell.Value = Convert.ToDecimal(GRIDCONSUMPTION.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTALCONSUMPTION()
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

    Private Sub cmbfromprocess_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfromprocess.Validated
        Try
            If cmbfromprocess.Text.Trim <> "" Then cmbfromprocess.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmachineno_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmachineno.Enter
        FILLMACHINENO()
    End Sub

    Private Sub CuttingProcess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If UserName = "Admin" Then CMBGODOWN.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class