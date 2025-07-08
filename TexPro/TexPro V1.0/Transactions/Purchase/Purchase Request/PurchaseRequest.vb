
Imports BL
Imports System.Windows.Forms

Public Class PurchaseRequest

    'following two variables is only for used in edit mode....
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer

    Public edit As Boolean
    Public tempreqno As String
    Public tempMsg As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
            If cmbitemname.Text.Trim <> "" Then
                Dim objclsCMST As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclsCMST.search(" ISNULL(sum(qty),0) ", "  ", " view_store_stock", " and itemname='" & cmbitemname.Text.Trim & "' and cmpid=" & CmpId & " and locationid=" & Locationid & " and yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    lblsih.Text = dt.Rows(0).Item(0)
                Else
                    lblsih.Text = 0
                End If
               
                dt = objclsCMST.search(" isnull(sum(qty),0) ", "  ", " view_store_stock", " and itemname='" & cmbitemname.Text.Trim & "' and type='issue' and date between '" & Format(DateAdd(DateInterval.Month, -1, Date.Now), "MM/dd/yyyy") & "' and '" & Format(Date.Now, "MM/dd/yyyy") & "' and cmpid=" & CmpId & " and locationid=" & Locationid & " and yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    lbllmc.Text = dt.Rows(0).Item(0)
                Else
                    lbllmc.Text = 0
                End If
                dt = objclsCMST.search(" ISNULL(PURCHASEMASTER_DESC.BILL_rate,0) ", "  ", "   PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID AND PURCHASEMASTER.BILL_INITIALS = PURCHASEMASTER_DESC.BILL_INITIALS AND PURCHASEMASTER.BILL_CMPID = PURCHASEMASTER_DESC.BILL_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = PURCHASEMASTER_DESC.BILL_locationid AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_DESC.BILL_yearid INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id AND PURCHASEMASTER_DESC.BILL_cmpid = ITEMMASTER.item_cmpid AND PURCHASEMASTER_DESC.BILL_locationid = ITEMMASTER.item_locationid AND PURCHASEMASTER_DESC.BILL_yearid = ITEMMASTER.item_yearid", " and item_name='" & cmbitemname.Text.Trim & "'  and PURCHASEMASTER.BILL_cmpid=" & CmpId & " and PURCHASEMASTER.BILL_locationid=" & Locationid & " and PURCHASEMASTER.BILL_yearid=" & YearId & " GROUP BY PURCHASEMASTER_DESC.BILL_rate order by bill_date desc")
                If dt.Rows.Count > 0 Then
                    lbllpr.Text = dt.Rows(0).Item(0)
                Else
                    lbllpr.Text = 0
                End If
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

    Sub clear()

        tstxtbillno.Clear()
        txtreqby.Clear()
        cmbdepartment.Text = ""
        reqdate.Value = Mydate
        dtvalidtill.Value = Mydate

        EP.Clear()
        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        CMBQUALITY.Text = ""
        TXTREED.Clear()
        TXTPICK.Clear()
        cmbcolor.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""

        txtremarks.Clear()
        lblsih.Text = 0.0
        lbllmc.Text = 0.0
        lbllpr.Text = 0.0
        gridreq.RowCount = 0
        lbltotalqty.Text = 0.0

        txtreqby.Focus()
        lbllocked.Visible = False
        PBlock.Visible = False
        gridDoubleClick = False

        CHKGREY.CheckState = CheckState.Unchecked

        If UserName = "Admin" Then
            txtreqby.Enabled = True
            cmbdepartment.Enabled = True
        Else
            txtreqby.Enabled = False
            cmbdepartment.Enabled = False
            txtreqby.Text = UserName
            cmbdepartment.Text = DEPARTMENTNAME
        End If


        getmax_preq_no() 'this function is for to get max value from the Purchase Requisition table

        If gridreq.RowCount > 0 Then
            txtsrno.Text = Val(gridreq.Rows(gridreq.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Sub getmax_preq_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PREQ_no),0) + 1 ", "PURCHASEREQUEST", " AND preq_cmpid=" & CmpId & " and PREQ_LOCATIONID=" & Locationid & " and PREQ_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtprno.Text = DTTABLE.Rows(0).Item(0)
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
        gridreq.Enabled = True
        If gridDoubleClick = False Then
            gridreq.Rows.Add(0, Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, txtgridremarks.Text.Trim, CMBQUALITY.Text.Trim, Val(TXTREED.Text.Trim), Val(TXTPICK.Text.Trim), cmbcolor.Text.Trim, Val(txtqty.Text.Trim), cmbqtyunit.Text.Trim, 0, 0, 0)
            getsrno(gridreq)
        ElseIf gridDoubleClick = True Then
            gridreq.Item(gsrno.Index, tempRow).Value = Val(txtsrno.Text.Trim)
            gridreq.Item(gitemname.Index, tempRow).Value = cmbitemname.Text.Trim
            gridreq.Item(gdesc.Index, tempRow).Value = txtgridremarks.Text.Trim
            gridreq.Item(GQUALITY.Index, tempRow).Value = CMBQUALITY.Text.Trim
            gridreq.Item(GREED.Index, tempRow).Value = TXTREED.Text.Trim
            gridreq.Item(GPICK.Index, tempRow).Value = TXTPICK.Text.Trim
            gridreq.Item(gcolor.Index, tempRow).Value = cmbcolor.Text.Trim
            gridreq.Item(gQty.Index, tempRow).Value = Val(txtqty.Text.Trim)
            gridreq.Item(gqtyunit.Index, tempRow).Value = cmbqtyunit.Text.Trim

            gridDoubleClick = False

        End If

        gridreq.FirstDisplayedScrollingRowIndex = gridreq.RowCount - 1

        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        CMBQUALITY.Text = ""
        TXTREED.Clear()
        TXTPICK.Clear()
        cmbcolor.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        txtsrno.Focus()

    End Sub

    Sub qtytotal()
        lbltotalqty.Text = "0.00"
        For Each row As DataGridViewRow In gridreq.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).Value), "0.00")
            End If
        Next
    End Sub

    Private Sub gridpurchasereq_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridreq.CellDoubleClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And gridreq.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then
            If Convert.ToBoolean(gridreq.Item(GDONE.Index, e.RowIndex).Value) = False Then
                gridDoubleClick = True
                txtsrno.Text = gridreq.Item(gsrno.Index, e.RowIndex).Value
                cmbitemname.Text = gridreq.Item(gitemname.Index, e.RowIndex).Value
                txtgridremarks.Text = gridreq.Item(gdesc.Index, e.RowIndex).Value
                CMBQUALITY.Text = gridreq.Item(GQUALITY.Index, e.RowIndex).Value
                TXTREED.Text = gridreq.Item(GREED.Index, e.RowIndex).Value
                TXTPICK.Text = gridreq.Item(GPICK.Index, e.RowIndex).Value
                cmbcolor.Text = gridreq.Item(gcolor.Index, e.RowIndex).Value
                txtqty.Text = gridreq.Item(gQty.Index, e.RowIndex).Value
                cmbqtyunit.Text = gridreq.Item(gqtyunit.Index, e.RowIndex).Value
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

            alParaval.Add(reqdate.Value)
            alParaval.Add(dtvalidtill.Value)
            alParaval.Add(txtreqby.Text.Trim)
            alParaval.Add(cmbdepartment.Text.Trim)
            alParaval.Add(lbltotalqty.Text.Trim)
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
            Dim RECDQTY As String = ""
            Dim GRIDDONE As String = ""
            Dim gridmailed As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridreq.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        REED = row.Cells(GREED.Index).Value.ToString
                        PICK = row.Cells(GPICK.Index).Value
                        COLOR = row.Cells(gcolor.Index).Value
                        qty = row.Cells(gQty.Index).Value
                        qtyunit = row.Cells(gqtyunit.Index).Value
                        RECDQTY = row.Cells(grecdqty.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = 1
                        Else
                            GRIDDONE = 0
                        End If

                        If Convert.ToBoolean(row.Cells(GMAILED.Index).Value) = True Then
                            gridmailed = 1
                        Else
                            gridmailed = 0
                        End If

                    Else
                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(gitemname.Index).Value.ToString
                        gridremarks = gridremarks & "," & row.Cells(gdesc.Index).Value.ToString
                        QUALITY = QUALITY & "," & row.Cells(GQUALITY.Index).Value.ToString
                        REED = REED & "," & row.Cells(GREED.Index).Value.ToString
                        PICK = PICK & "," & row.Cells(GPICK.Index).Value
                        COLOR = COLOR & "," & row.Cells(gcolor.Index).Value
                        qty = qty & "," & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "," & row.Cells(gqtyunit.Index).Value
                        RECDQTY = RECDQTY & "," & row.Cells(grecdqty.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRIDDONE = GRIDDONE & "," & 1
                        Else
                            GRIDDONE = GRIDDONE & "," & 0
                        End If

                        If Convert.ToBoolean(row.Cells(GMAILED.Index).Value) = True Then
                            gridmailed = gridmailed & "," & 1
                        Else
                            gridmailed = gridmailed & "," & 0
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
            alParaval.Add(RECDQTY)
            alParaval.Add(GRIDDONE)
            alParaval.Add(gridmailed)


            Dim objclsPReq As New ClsPurchaseRequest
            objclsPReq.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsPReq.save()
                MessageBox.Show("Details Added")
            Else
                alParaval.Add(tempreqno)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsPReq.Update()
                MsgBox("Details Updated")
            End If
            edit = False


            Dim TEMPMSG As Integer = MsgBox("Print Report in Excel Format?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim objrep As New clsReportDesigner("Purchase Request", System.AppDomain.CurrentDomain.BaseDirectory & "PURCHASEREQUEST.xlsx", 2)

                Dim CONDITION As String = ""
                For Each ROW As DataGridViewRow In gridreq.Rows
                    If Convert.ToBoolean(ROW.Cells(CHKMAIL.Index).Value) = True Then
                        If CONDITION = "" Then
                            CONDITION = " GRIDSRNO = " & ROW.Cells(gsrno.Index).Value
                        Else
                            CONDITION = CONDITION & " OR GRIDSRNO = " & ROW.Cells(gsrno.Index).Value
                        End If
                    End If
                Next
                If edit = False Then
                    objrep.RPT_PR_Report(txtprno.Text.Trim, CmpId, Locationid, YearId, CONDITION, CHKGREY.CheckState)
                Else
                    objrep.RPT_PR_Report(tempreqno, CmpId, Locationid, YearId, CONDITION, CHKGREY.CheckState)
                End If
            End If

            clear()
            txtreqby.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If txtreqby.Text.Trim.Length = 0 Then
            EP.SetError(txtreqby, "Enter Req. by")
            bln = False
        End If

        If cmbdepartment.Text.Trim.Length = 0 Then
            EP.SetError(cmbdepartment, "Enter Department")
            bln = False
        End If

        If gridreq.RowCount = 0 Then
            EP.SetError(txtqty, "Enter Item Details")
            bln = False
        End If

        If chkchange.CheckState = CheckState.Unchecked Then
            EP.SetError(txtqty, "Enter Item Details")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Quotation Raised, Delete Quotation First")
            bln = False
        End If

        If Not datecheck(reqdate.Value) Then bln = False
        Return bln
    End Function

    Private Sub PurchaseRequisition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            'Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            'Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PurchaseRequisition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Sub FILLCMB()
        Try
            filldepartment(cmbdepartment, edit)
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            fillQUALITY(CMBQUALITY, edit)
            fillCOLOR(cmbcolor)
            fillunit(cmbqtyunit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRequisition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE REQUEST'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            FILLCMB()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim objclspreq As New ClsPurchaseRequest

                ALPARAVAL.Add(tempreqno)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclspreq.alParaval = ALPARAVAL
                Dim dt As DataTable = objclspreq.selectPURREQ()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtprno.Text = tempreqno
                        reqdate.Value = Convert.ToDateTime(dr("REQDATE"))
                        dtvalidtill.Value = Convert.ToDateTime(dr("VALIDdate"))
                        txtreqby.Text = Convert.ToString(dr("requestby"))
                        cmbdepartment.Text = Convert.ToString(dr("DEPARTMENT"))
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        gridreq.Rows.Add(0, dr("gridsrno").ToString, dr("ITEMNAME").ToString, dr("DESC").ToString, dr("QUALITY").ToString, dr("REED").ToString, dr("PICK").ToString, dr("COLOR").ToString, dr("QTY").ToString, dr("QTYUNIT").ToString, dr("RECDQTY").ToString, dr("done").ToString, dr("MAILED").ToString)

                    Next
                    gridreq.FirstDisplayedScrollingRowIndex = gridreq.RowCount - 1
                End If

                'code for to change colour of grid line Item if particular grid line item is done 
                For Each row As DataGridViewRow In gridreq.Rows
                    If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If
                    If Convert.ToBoolean(row.Cells(GMAILED.Index).Value) = True Then row.Cells(CHKMAIL.Index).Value = True
                Next
                'end of current blok

                chkchange.CheckState = CheckState.Checked
                qtytotal()
            End If

            'If gridDoubleClick = False Then
            If gridreq.RowCount > 0 Then
                txtsrno.Text = Val(gridreq.Rows(gridreq.RowCount - 1).Cells(gsrno.Index).Value) + 1
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
            If gridreq.RowCount > 0 Then
                txtsrno.Text = Val(gridreq.Rows(gridreq.RowCount - 1).Cells(gsrno.Index).Value) + 1
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

                'CHCKING FOR LOCK
                For Each ROW As DataGridViewRow In gridreq.Rows
                    If Convert.ToBoolean(ROW.Cells(GDONE.Index).Value) = True Then
                        BLN = False
                    End If
                Next

                If lbllocked.Visible = True Then BLN = False

                If BLN = False Then
                    MsgBox("Quotation Raised, Delete Quotation First", MsgBoxStyle.Critical)
                    Exit Sub
                Else

                    Dim TEMPMSG As Integer = MsgBox("Delete Purchase Request?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim ALPARAVAL As New ArrayList
                        Dim OBJPR As New ClsCONSUME

                        ALPARAVAL.Add(tempreqno)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJPR.alParaval = ALPARAVAL
                        Dim IntResult As Integer = OBJPR.Delete()
                        MsgBox("Purchase Request Deleted")
                        clear()

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

            Dim objprdetails As New PurchaseRequestDetails
            objprdetails.MdiParent = MDIMain
            objprdetails.Show()
            objprdetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        tempreqno = Val(txtprno.Text) - 1
        clear()
        If tempreqno > 0 Then
            edit = True
            PurchaseRequisition_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        tempreqno = Val(txtprno.Text) + 1
        getmax_preq_no()
        clear()
        If Val(txtprno.Text) - 1 >= tempreqno Then
            edit = True
            PurchaseRequisition_Load(sender, e)
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

    Private Sub preqdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles reqdate.Validating
        If Not datecheck(reqdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            If edit = True And gridreq.RowCount > 0 Then
                Dim TEMPMSG As Integer = MsgBox("Print Report in Excel Format?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim objrep As New clsReportDesigner("Purchase Request", System.AppDomain.CurrentDomain.BaseDirectory & "PURCHASEREQUEST.xlsx", 2)

                    Dim CONDITION As String = ""
                    For Each ROW As DataGridViewRow In gridreq.Rows
                        If Convert.ToBoolean(ROW.Cells(CHKMAIL.Index).Value) = True Then
                            If CONDITION = "" Then
                                CONDITION = " GRIDSRNO = " & ROW.Cells(gsrno.Index).Value
                            Else
                                CONDITION = CONDITION & " OR GRIDSRNO = " & ROW.Cells(gsrno.Index).Value
                            End If
                        End If
                    Next
                    objrep.RPT_PR_Report(tempreqno, CmpId, Locationid, YearId, CONDITION, CHKGREY.CheckState)
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridpurchasereq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridreq.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridreq.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block


                'if selected row is yellow don't allow it to delete 
                If edit = True Then
                    Dim isyellow As Boolean = False
                    For Each row As DataGridViewRow In gridreq.SelectedRows
                        isyellow = Convert.ToBoolean(row.Cells(GDONE.Index).Value)
                    Next
                    If isyellow = True Then
                        MessageBox.Show("Row is Locked, You Cannot Delete This Row")
                        Exit Sub
                    End If
                End If
                'End of current Block

                gridreq.Rows.RemoveAt(gridreq.CurrentRow.Index)
                qtytotal()
                getsrno(gridreq)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub gridreq_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridreq.CellClick


        Dim N As String = ""

        ''CHECKING SIMILAR LOCATION
        'For i = 0 To gridprequisition.RowCount - 1
        '    With gridprequisition.Rows(i).Cells(0)
        '        If .Value = True Then N = gridprequisition.Item(5, i).Value.ToString
        '    End With
        'Next

        If e.RowIndex >= 0 And e.ColumnIndex = CHKMAIL.Index Then
            With gridreq.Rows(e.RowIndex).Cells(CHKMAIL.Index)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
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
        tempreqno = Val(tstxtbillno.Text)
        clear()
        If tempreqno > 0 Then
            edit = True
            PurchaseRequisition_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            If edit = True And gridreq.RowCount > 0 Then
                Dim objrep As New clsReportDesigner("Purchase Request", System.AppDomain.CurrentDomain.BaseDirectory & "PURCHASEREQUEST.xlsx", 0)

                Dim CONDITION As String = ""
                For Each ROW As DataGridViewRow In gridreq.Rows
                    If Convert.ToBoolean(ROW.Cells(CHKMAIL.Index).Value) = True Then
                        If CONDITION = "" Then
                            CONDITION = " GRIDSRNO = " & ROW.Cells(gsrno.Index).Value
                        Else
                            CONDITION = CONDITION & " OR GRIDSRNO = " & ROW.Cells(gsrno.Index).Value
                        End If
                    End If
                Next
                objrep.RPT_PR_Report(tempreqno, CmpId, Locationid, YearId, CONDITION, CHKGREY.CheckState)


                Dim objMAIL As New SendMail
                objMAIL.MdiParent = MDIMain
                objMAIL.subject = "PURCHASEREQUEST"
                objMAIL.attachment = System.AppDomain.CurrentDomain.BaseDirectory & "PURCHASEREQUEST.xlsx"
                objMAIL.Show()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtgPICK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPICK.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtREED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREED.KeyPress
        numkeypress(e, sender, Me)
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

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            For Each ROW As DataGridViewRow In gridreq.Rows
                ROW.Cells(CHKMAIL.Index).Value = CHKSELECTALL.CheckState
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
End Class