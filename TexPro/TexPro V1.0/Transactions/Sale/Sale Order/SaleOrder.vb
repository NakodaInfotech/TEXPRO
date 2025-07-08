
Imports BL

Public Class SaleOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim PARTYPONO As String
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPSONO As String

    Sub CLEAR()

        TSTXTBILLNO.Clear()
        EP.Clear()

        TXTSONO.Clear()
        SODATE.Value = Mydate

        CMBNAME.Text = ""
        CMBSHIPTO.Text = ""
        CMBAGENT.Text = ""
        CMBTRANSPORT.Text = ""

        TXTPONO.Clear()
        CMBCITY.Text = ""


        GRIDSO.RowCount = 0
        TXTSRNO.Text = 1
        CMBITEMNAME.Text = ""
        TXTPERSONALMERCHANT.Clear()
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTBALES.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        TXTGRIDREMARKS.Clear()


        LBLLOCKED.Visible = False
        PBLOCK.Visible = False
        LBLCLOSED.Visible = False

        TXTREMARKS.Clear()

        GETMAX_SO_NO()
        GRIDDOUBLECLICK = False

        LBLTOTALBALES.Text = 0.0
        LBLTOTALAMT.Text = 0.0

        TXTSTOCKBALE.Clear()
        TXTSTOCKPCS.Clear()
        TXTSTOCKMTRS.Clear()


    End Sub

    Sub GETMAX_SO_NO()
        Dim DTTABLE As DataTable = getmax(" isnull(max(SO_no),0) + 1 ", "SALEORDER", " and SO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTSONO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'AGENT'")
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEMNAME.Text)
            If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SALEORDER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf E.Alt = True And e.KeyCode = KEYS.Left Then
                Call TOOLPREVIOUS_Click(sender, e)
            ElseIf E.Alt = True And e.KeyCode = KEYS.Right Then
                Call TOOLNEXT_Click(sender, e)
            ElseIf e.KeyCode = Keys.F2 Then
                TSTXTBILLNO.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SALEORDER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSO As New ClsSaleOrder()
                OBJSO.alParaval.Add(TEMPSONO)
                OBJSO.alParaval.Add(YearId)
                Dim DT As DataTable = OBJSO.SELECTSO()

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows

                        TXTSONO.Text = TEMPSONO
                        SODATE.Value = Convert.ToDateTime(DR("DATE"))

                        CMBNAME.Text = DR("NAME")
                        CMBSHIPTO.Text = Convert.ToString(DR("SHIPTO"))
                        CMBAGENT.Text = Convert.ToString(DR("AGENT"))
                        CMBTRANSPORT.Text = DR("TRANSNAME").ToString
                        TXTPONO.Text = Convert.ToString(DR("PONO"))
                        CMBCITY.Text = Convert.ToString(DR("CITY"))

                        GRIDSO.Rows.Add(Val(DR("GRIDSRNO")), DR("ITEMNAME"), DR("PERSONALMERCHANT"), DR("DESIGNNO"), DR("COLOR"), Val(DR("BALES")), Format(Val(DR("RATE")), "0.00"), Format(Val(DR("AMT")), "0.00"), DR("GRIDREMARKS"), DR("CLOSED"), Val(DR("OUTBALES")))

                        If Val(DR("OUTBALES")) > 0 Or Convert.ToBoolean(DR("CLOSED")) = True Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            LBLLOCKED.Visible = True
                            PBLOCK.Visible = True
                            If Convert.ToBoolean(DR("CLOSED")) = True Then LBLCLOSED.Visible = True
                        End If

                        TXTREMARKS.Text = Convert.ToString(DR("REMARKS"))

                    Next
                    GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1
                    TOTAL()

                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TOTAL()

        LBLTOTALBALES.Text = 0.0
        LBLTOTALAMT.Text = 0.0

        If GRIDSO.RowCount > 0 Then
            For Each row As DataGridViewRow In GRIDSO.Rows
                If Val(row.Cells(GBALES.Index).EditedFormattedValue) > 0 Then LBLTOTALBALES.Text = Format(Val(LBLTOTALBALES.Text) + Val(row.Cells(GBALES.Index).EditedFormattedValue), "0")
                If Val(row.Cells(GBALES.Index).EditedFormattedValue) > 0 And Val(row.Cells(GRATE.Index).EditedFormattedValue) > 0 Then row.Cells(GAMOUNT.Index).Value = Format(Val(row.Cells(GRATE.Index).EditedFormattedValue) * Val(row.Cells(GBALES.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GAMOUNT.Index).EditedFormattedValue) > 0 Then LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(row.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
            Next
        End If

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub TOOLPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPREVIOUS.Click
        Try
            GRIDSO.RowCount = 0
            TEMPSONO = Val(TXTSONO.Text) - 1
            If TEMPSONO > 0 Then
                EDIT = True
                SALEORDER_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDSO.RowCount = 0
            TEMPSONO = Val(TXTSONO.Text) + 1
            GETMAX_SO_NO()
            CLEAR()
            If Val(TXTSONO.Text) - 1 >= TEMPSONO Then
                EDIT = True
                SALEORDER_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_NAME = 'Sundry debtors'", "Sundry Debtors", "ACCOUNTS", CMBTRANSPORT.Text, CMBAGENT.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHIPTO.Enter
        Try
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHIPTO.Validating
        Try
            If CMBSHIPTO.Text.Trim <> "" Then namevalidate(CMBSHIPTO, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_NAME = 'Sundry debtors'", "Sundry Debtors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_NAME = 'Sundry CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORT.Enter
        Try
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORT.Validating
        Try
            If CMBTRANSPORT.Text.Trim <> "" Then namevalidate(CMBTRANSPORT, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'", "Sundry Creditors", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCITY.Enter
        Try
            If CMBCITY.Text.Trim <> "" Then fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Validated
        Try
            If CMBITEMNAME.Text.Trim <> "" Then GETSTOCK(CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETSTOCK(ByVal MERCHANTNAME As String)
        Try
            If MERCHANTNAME <> "" Then
                'GET BALE STOCK
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" COUNT(DISTINCT BALENO) AS TOTALBALES, ISNULL(SUM(PCS),0) AS TOTALPCS, ISNULL(SUM(MTRS),0) AS TOTALMTRS ", "", " BALESTOCK_VIEW ", " AND MERCHANT = '" & MERCHANTNAME & "' AND CHALLANNO = 0 AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTOCKBALE.Text = Val(DT.Rows(0).Item("TOTALBALES"))
                    TXTSTOCKPCS.Text = Val(DT.Rows(0).Item("TOTALPCS"))
                    TXTSTOCKMTRS.Text = Val(DT.Rows(0).Item("TOTALMTRS"))
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEMNAME.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me, CMBITEMNAME.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORvalidate(CMBCOLOR, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
            CMBNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            If EDIT = False Then Exit Sub
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If LBLLOCKED.Visible = True Then
                MsgBox("Unable to Delete, Sale Order Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Delete Sale Order ?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub

            Dim OBJSO As New ClsSaleOrder()
            OBJSO.alParaval.Add(TEMPSONO)
            OBJSO.alParaval.Add(YearId)
            Dim IntResult As Integer = OBJSO.Delete()
            MsgBox("Sale Order Deleted Successfully")
            EDIT = False
            CLEAR()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDSO.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDSO.Rows(GRIDSO.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTBALES_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALES.KeyPress, TSTXTBILLNO.KeyPress
        Try
            numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated, TXTBALES.Validated
        Try
            TXTAMOUNT.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTBALES.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDREMARKS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGRIDREMARKS.Validated
        If CMBITEMNAME.Text.Trim <> "" And Val(TXTBALES.Text.Trim) > 0 Then
            FILLGRID()
            TOTAL()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Sub FILLGRID()

        If GRIDDOUBLECLICK = False Then
            GRIDSO.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMNAME.Text.Trim, TXTPERSONALMERCHANT.Text.Trim, CMBDESIGN.Text.Trim, CMBCOLOR.Text.Trim, Val(TXTBALES.Text.Trim), Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"), TXTGRIDREMARKS.Text.Trim, 0, 0)
            GETSRNO(GRIDSO)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSO.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDSO.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDSO.Item(GPERSONALMERCHANT.Index, TEMPROW).Value = TXTPERSONALMERCHANT.Text.Trim
            GRIDSO.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDSO.Item(GCOLOR.Index, TEMPROW).Value = CMBCOLOR.Text.Trim
            GRIDSO.Item(GBALES.Index, TEMPROW).Value = Val(TXTBALES.Text.Trim)
            GRIDSO.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDSO.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")
            GRIDSO.Item(GDESC.Index, TEMPROW).Value = TXTGRIDREMARKS.Text.Trim

            GRIDDOUBLECLICK = False
        End If

        GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1

        TXTSRNO.Text = GRIDSO.RowCount + 1
        CMBITEMNAME.Text = ""
        TXTPERSONALMERCHANT.Clear()
        CMBDESIGN.Text = ""
        CMBCOLOR.Text = ""
        TXTBALES.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        TXTGRIDREMARKS.Clear()
        CMBITEMNAME.Focus()

    End Sub

    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSO.CellDoubleClick
        If e.RowIndex >= 0 And GRIDSO.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(GRIDSO.Rows(e.RowIndex).Cells(GCLOSED.Index).Value) = True Or Val(GRIDSO.Rows(e.RowIndex).Cells(GOUTBALES.Index).Value) > 0 Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from Challan")
                Exit Sub
            End If


            GRIDDOUBLECLICK = True
            TXTSRNO.Text = Val(GRIDSO.Item(GSRNO.Index, e.RowIndex).Value)
            CMBITEMNAME.Text = GRIDSO.Item(GITEMNAME.Index, e.RowIndex).Value.ToString
            TXTPERSONALMERCHANT.Text = GRIDSO.Item(GPERSONALMERCHANT.Index, e.RowIndex).Value.ToString
            CMBDESIGN.Text = GRIDSO.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            CMBCOLOR.Text = GRIDSO.Item(GCOLOR.Index, e.RowIndex).Value.ToString
            TXTBALES.Text = Val(GRIDSO.Item(GBALES.Index, e.RowIndex).Value)
            TXTRATE.Text = Val(GRIDSO.Item(GRATE.Index, e.RowIndex).Value)
            TXTAMOUNT.Text = Val(GRIDSO.Item(GAMOUNT.Index, e.RowIndex).Value)
            TXTGRIDREMARKS.Text = GRIDSO.Item(GDESC.Index, e.RowIndex).Value.ToString

            TEMPROW = e.RowIndex
            CMBITEMNAME.Focus()

        End If
    End Sub

    Private Sub GRIDSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSO.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDSO.RowCount > 0 Then

                If Convert.ToBoolean(GRIDSO.CurrentRow.Cells(GCLOSED.Index).Value) = True Or Val(GRIDSO.CurrentRow.Cells(GOUTBALES.Index).Value) > 0 Then 'If row.Cells(16).Value <> "0" Then 
                    MsgBox("Item Locked. First Delete from Challan")
                    Exit Sub
                End If

                'dont allow user if any of the grid line is in EDIT mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in EDITed Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDSO.Rows.RemoveAt(GRIDSO.CurrentRow.Index)
                GETSRNO(GRIDSO)
                TOTAL()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDSO_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSO.CellValidating
        ''  CODE FOR NUMERIC CHECK ONLY
        Dim colNum As Integer = GRIDSO.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case GRATE.Index, GBALES.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDSO.CurrentCell.Value = Nothing Then GRIDSO.CurrentCell.Value = "0.00"
                    GRIDSO.CurrentCell.Value = Convert.ToDecimal(GRIDSO.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                End If

        End Select
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Name ")
            BLN = False
        End If

        If GRIDSO.RowCount = 0 Then
            EP.SetError(TXTAMOUNT, "Enter Item Details")
            BLN = False
        End If

        If Val(LBLTOTALBALES.Text) = 0 Then
            EP.SetError(LBLTOTALBALES, "Enter Item Details")
            BLN = False
        End If

        If LBLLOCKED.Visible = True Then
            EP.SetError(LBLLOCKED, "Challan Raised, Delete Challan First")
            BLN = False
        End If

        Return BLN

    End Function

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim IntResult As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(SODATE.Value)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBSHIPTO.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(CMBTRANSPORT.Text.Trim)
            alParaval.Add(TXTPONO.Text.Trim)
            alParaval.Add(CMBCITY.Text.Trim)

            alParaval.Add(Val(LBLTOTALBALES.Text.Trim))
            alParaval.Add(Val(LBLTOTALAMT.Text.Trim))

            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim PERSONALMERCHANT As String = ""
            Dim DESIGNNO As String = ""
            Dim COLOR As String = ""
            Dim BALES As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim GRIDREMARKS As String = ""
            Dim CLOSED As String = ""
            Dim OUTBALES As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDSO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        PERSONALMERCHANT = row.Cells(GPERSONALMERCHANT.Index).Value.ToString
                        DESIGNNO = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        BALES = Val(row.Cells(GBALES.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value)
                        GRIDREMARKS = row.Cells(GDESC.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                        OUTBALES = Val(row.Cells(GOUTBALES.Index).Value)

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        PERSONALMERCHANT = PERSONALMERCHANT & "|" & row.Cells(GPERSONALMERCHANT.Index).Value
                        DESIGNNO = DESIGNNO & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        BALES = BALES & "|" & Val(row.Cells(GBALES.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value)
                        GRIDREMARKS = GRIDREMARKS & "|" & row.Cells(GDESC.Index).Value

                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"

                        OUTBALES = OUTBALES & "|" & Val(row.Cells(GOUTBALES.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(PERSONALMERCHANT)
            alParaval.Add(DESIGNNO)
            alParaval.Add(COLOR)
            alParaval.Add(BALES)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(GRIDREMARKS)
            alParaval.Add(CLOSED)
            alParaval.Add(OUTBALES)


            Dim OBJSO As New ClsSaleOrder()
            OBJSO.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = OBJSO.SAVE()
                MessageBox.Show("Details Added")

            Else
                alParaval.Add(TEMPSONO)

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = OBJSO.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False

            End If

            PRINTREPORT()
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish To Print Sale Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJSO As New SaleOrderDesign
            OBJSO.MdiParent = MDIMain
            OBJSO.FRMSTRING = "SOREPORT"
            OBJSO.PARTYNAME = CMBNAME.Text.Trim
            OBJSO.AGENTNAME = CMBAGENT.Text.Trim
            OBJSO.SHIPTONAME = CMBSHIPTO.Text.Trim
            OBJSO.SONO = Val(TXTSONO.Text.Trim)
            OBJSO.FORMULA = "{saleOrder.so_no}=" & Val(TXTSONO.Text) & " and {saleOrder.SO_yearid}=" & YearId
            OBJSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TSTXTBILLNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TSTXTBILLNO.Validating
        Try
            GRIDSO.RowCount = 0
            TEMPSONO = Val(TSTXTBILLNO.Text)
            If TEMPSONO > 0 Then
                EDIT = True
                SALEORDER_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
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

            Dim OBJSO As New SaleOrderDetails
            OBJSO.MdiParent = MDIMain
            OBJSO.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                If CMBSHIPTO.Text.Trim = "" Then CMBSHIPTO.Text = CMBNAME.Text.Trim
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(CITYMASTER.CITY_NAME,'') AS CITY", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBCITY.Text = DT.Rows(0).Item("CITY")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class