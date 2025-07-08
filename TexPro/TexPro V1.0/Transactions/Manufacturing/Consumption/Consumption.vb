

Imports BL
Imports System.Windows.Forms

Public Class Consumption

    'following two variables is only for used in edit mode....
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer

    Public edit As Boolean
    Public TEMPCONSUMENO As String
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
                Dim objclsCMST As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclsCMST.search(" ISNULL(sum(qty),0) ", "  ", " view_store_stock", " and itemname='" & cmbitemname.Text.Trim & "' and yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    lblsih.Text = Format(Val(dt.Rows(0).Item(0)), "0.000")
                Else
                    lblsih.Text = 0
                End If

                dt = objclsCMST.search(" isnull(sum(qty),0) ", "  ", " view_store_stock", " and itemname='" & cmbitemname.Text.Trim & "' and type='issue' and date between '" & Format(DateAdd(DateInterval.Month, -1, Date.Now), "MM/dd/yyyy") & "' and '" & Format(Date.Now, "MM/dd/yyyy") & "' and yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    lbllmc.Text = dt.Rows(0).Item(0)
                Else
                    lbllmc.Text = 0
                End If
                dt = objclsCMST.search(" ISNULL(PURCHASEMASTER_DESC.BILL_rate,0),max(PURCHASEMASTER.bill_date) ", "  ", "   PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_DESC.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_DESC.BILL_REGISTERID AND PURCHASEMASTER.BILL_INITIALS = PURCHASEMASTER_DESC.BILL_INITIALS AND PURCHASEMASTER.BILL_CMPID = PURCHASEMASTER_DESC.BILL_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = PURCHASEMASTER_DESC.BILL_locationid AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_DESC.BILL_yearid INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id AND PURCHASEMASTER_DESC.BILL_cmpid = ITEMMASTER.item_cmpid AND PURCHASEMASTER_DESC.BILL_locationid = ITEMMASTER.item_locationid AND PURCHASEMASTER_DESC.BILL_yearid = ITEMMASTER.item_yearid", " and item_name='" & cmbitemname.Text.Trim & "' and PURCHASEMASTER.BILL_yearid=" & YearId & " group by bill_rate")
                If dt.Rows.Count > 0 Then
                    lbllpr.Text = dt.Rows(0).Item(0)
                Else
                    lbllpr.Text = 0
                End If

                If edit = True Then
                    dt = objclsCMST.search(" ISNULL(CONSUME_QTY,0) AS QTY ", "  ", "   CONSUMPTION_DESC INNER JOIN ITEMMASTER ON item_id = CONSUME_ITEMID ", " AND CONSUME_no = " & TEMPCONSUMENO & " and item_name='" & cmbitemname.Text.Trim & "' and CONSUME_yearid=" & YearId)
                    If dt.Rows.Count > 0 Then lblsih.Text = Format(Val(lblsih.Text) + Val(dt.Rows(0).Item(0)), "0.000")
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

    Private Sub cmbmerchant_enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.GotFocus
        Try
            If cmbdesignno.Text <> "" And (CMBProcess.Text = "PROCIAN PRINTING" Or CMBProcess.Text.Trim = "PIGMENT PRINTING") Then
                If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR, "   INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesignno.Text & "' AND  itemmaster.item_name='" & cmbmerchant.Text & "' AND  processmaster.process_name='" & CMBProcess.Text & "'")
            ElseIf CMBDYEING.Text <> "" And CMBProcess.Text = "DYEING" Then
                If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID ", " AND DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub CMBDYEING_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDYEING.GotFocus
        Try
            If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDYEING.Validating
        Try
            If CMBDYEING.Text.Trim <> "" Then dyeingvalidate(CMBDYEING, e, Me)
            CMBCOLOR.Text = ""
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If cmbdesignno.Text <> "" And (CMBProcess.Text = "PROCIAN PRINTING" Or CMBProcess.Text.Trim = "PIGMENT PRINTING") Then
                If CMBCOLOR.Text.Trim <> "" Then COLORvalidate(CMBCOLOR, e, Me, "   INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesignno.Text & "' AND  itemmaster.item_name='" & cmbmerchant.Text & "' AND  processmaster.process_name='" & CMBProcess.Text & "'")
                Dim dt1 As New DataTable
                Dim OBJCMN As New ClsCommon
                dt1 = OBJCMN.search(" ITEMMASTER.item_name AS ITEM,sum(0) as wt  ", "", "     DESIGNRECIPE INNER JOIN DESIGNRECIPE_DESC ON DESIGNRECIPE.DESIGN_ID = DESIGNRECIPE_DESC.DESIGN_ID AND DESIGNRECIPE.DESIGN_CMPID = DESIGNRECIPE_DESC.DESIGN_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DESIGNRECIPE_CONSUMPTION ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE_CONSUMPTION.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_SRNO = DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER_1.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER_1.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER_1.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = SCREENMASTER.SCREEN_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = SCREENMASTER.SCREEN_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = SCREENMASTER.SCREEN_yearid ", " AND itemmaster_1.item_name = '" & cmbmerchant.Text.Trim & "' AND processmaster.process_name = '" & CMBProcess.Text.Trim & "' AND colormaster.color_name = '" & CMBCOLOR.Text.Trim & "' AND DESIGNRECIPE.DESIGN_NO='" & cmbdesignno.Text.Trim & "'   AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " GROUP BY ITEMMASTER.item_name")
                If dt1.Rows.Count > 0 Then
                    GRIDCONSUME.RowCount = 0

                    For j As Integer = 0 To dt1.Rows.Count - 1
                        GRIDCONSUME.Rows.Add(0, dt1.Rows(j).Item("item"), "", 0, "KGS")
                    Next
                End If
                getsrno(GRIDCONSUME)
                qtytotal()
            ElseIf CMBDYEING.Text <> "" And CMBProcess.Text = "DYEING" Then
                If CMBCOLOR.Text.Trim <> "" Then COLORvalidate(CMBCOLOR, e, Me, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID", " AND  DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")
                If CMBCOLOR.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" Then
                    Dim dttable As New DataTable
                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search("  ITEMMASTER.item_name AS ITEM, DYEINGRECIPE_CONSUMPTION.DYEING_QTY, DYEINGRECIPE_DESC.DYEING_PERPCS, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE ", "", "      DYEINGRECIPE INNER JOIN DYEINGRECIPE_DESC ON DYEINGRECIPE.DYEING_ID = DYEINGRECIPE_DESC.DYEING_ID AND DYEINGRECIPE.DYEING_CMPID = DYEINGRECIPE_DESC.DYEING_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DYEINGRECIPE_CONSUMPTION ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE_CONSUMPTION.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_SRNO = DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE_CONSUMPTION.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE_CONSUMPTION.DYEING_YEARID INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DYEINGRECIPE.DYEING_PROCESSID = PROCESSMASTER.PROCESS_ID AND DYEINGRECIPE.DYEING_CMPID = PROCESSMASTER.PROCESS_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  PROCESSMASTER.PROCESS_NAME = '" & CMBProcess.Text.Trim & "' AND COLORMASTER.COLOR_name ='" & CMBCOLOR.Text.Trim & "' AND dyeingRECIPE.dyeing_NO ='" & CMBDYEING.Text & "' AND dyeingRECIPE.dyeing_CMPID =" & CmpId & " AND dyeingRECIPE.dyeing_LOCATIONID =" & Locationid & " AND dyeingRECIPE.dyeing_YEARID =" & YearId)
                    If dttable.Rows.Count > 0 Then
                        GRIDCONSUME.RowCount = 0

                        For j As Integer = 0 To dttable.Rows.Count - 1
                            GRIDCONSUME.Rows.Add(0, dttable.Rows(j).Item("item"), "", Val(dttable.Rows(j).Item("DYEING_QTY")), "KGS")
                        Next
                    End If
                    getsrno(GRIDCONSUME)
                    qtytotal()
                End If

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesignno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesignno.GotFocus
        Try
            If cmbdesignno.Text.Trim = "" Then fillDESIGN(cmbdesignno, cmbmerchant.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesignno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesignno.Validating
        Try
            If cmbdesignno.Text.Trim <> "" Then DESIGNvalidate(cmbdesignno, e, Me, cmbmerchant.Text)
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
        CONSUMEdate.Value = Mydate
        CMBISSUETO.Text = ""
        EP.Clear()
        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        txtqty.Clear()
        cmbqtyunit.Text = ""

        txtremarks.Clear()
        CMBCOLOR.Text = ""
        CMBProcess.Text = ""
        cmbdesignno.Text = ""
        CMBDYEING.Text = ""
        cmbmerchant.Text = ""
        GRIDCONSUME.RowCount = 0
        lbltotalqty.Text = 0.0

        lblsih.Text = 0
        lbllmc.Text = 0
        lbllpr.Text = 0

        lbllocked.Visible = False
        PBlock.Visible = False
        gridDoubleClick = False
        tempRow = 0


        'If UserName = "Admin" Then
        '    cmbdepartment.Enabled = True
        'Else
        '    cmbdepartment.Enabled = False
        '    cmbdepartment.Text = DEPARTMENTNAME
        'End If


        getmax_CONSUME_no() 'this function is for to get max value from the Purchase CONSUMEuisition table

        If GRIDCONSUME.RowCount > 0 Then
            txtsrno.Text = Val(GRIDCONSUME.Rows(GRIDCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub

    Sub getmax_CONSUME_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CONSUME_no),0) + 1 ", "CONSUMPTION", " AND CONSUME_cmpid=" & CmpId & " and CONSUME_LOCATIONID=" & Locationid & " and CONSUME_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCONSUMENO.Text = DTTABLE.Rows(0).Item(0)
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
        GRIDCONSUME.Enabled = True
        If gridDoubleClick = False Then
            GRIDCONSUME.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, txtgridremarks.Text.Trim, Val(txtqty.Text.Trim), cmbqtyunit.Text.Trim)
            getsrno(GRIDCONSUME)
        ElseIf gridDoubleClick = True Then
            GRIDCONSUME.Item(gsrno.Index, tempRow).Value = Val(txtsrno.Text.Trim)
            GRIDCONSUME.Item(gitemname.Index, tempRow).Value = cmbitemname.Text.Trim
            GRIDCONSUME.Item(gdesc.Index, tempRow).Value = txtgridremarks.Text.Trim
            GRIDCONSUME.Item(gQty.Index, tempRow).Value = Val(txtqty.Text.Trim)
            GRIDCONSUME.Item(gqtyunit.Index, tempRow).Value = cmbqtyunit.Text.Trim

            gridDoubleClick = False

        End If
        qtytotal()
        GRIDCONSUME.FirstDisplayedScrollingRowIndex = GRIDCONSUME.RowCount - 1

        txtsrno.Text = GRIDCONSUME.RowCount + 1
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        txtqty.Clear()
        cmbqtyunit.Text = ""
        cmbitemname.Focus()

    End Sub

    Sub qtytotal()
        lbltotalqty.Text = 0
        For Each row As DataGridViewRow In GRIDCONSUME.Rows
            If Val(row.Cells(gQty.Index).EditedFormattedValue) <> 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
        Next
    End Sub

    Private Sub gridpurchaseCONSUME_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCONSUME.CellDoubleClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And GRIDCONSUME.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then
            If Convert.ToBoolean(GRIDCONSUME.Item(GDONE.Index, e.RowIndex).Value) = False Then
                gridDoubleClick = True
                txtsrno.Text = GRIDCONSUME.Item(gsrno.Index, e.RowIndex).Value
                cmbitemname.Text = GRIDCONSUME.Item(gitemname.Index, e.RowIndex).Value
                txtgridremarks.Text = GRIDCONSUME.Item(gdesc.Index, e.RowIndex).Value
                txtqty.Text = GRIDCONSUME.Item(gQty.Index, e.RowIndex).Value
                cmbqtyunit.Text = GRIDCONSUME.Item(gqtyunit.Index, e.RowIndex).Value
                tempRow = e.RowIndex
                cmbitemname.Focus()
            Else
                MsgBox("Item Locked. First Delete Entry From Quotation")
            End If
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CONSUMEdate.Focus()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            qtytotal()

            Dim alParaval As New ArrayList

            alParaval.Add(CONSUMEdate.Value)
            alParaval.Add(CMBISSUETO.Text.Trim)
            alParaval.Add(cmbdepartment.Text.Trim)
            alParaval.Add(lbltotalqty.Text.Trim)
            alParaval.Add(CMBProcess.Text.Trim)
            alParaval.Add(CMBDYEING.Text.Trim)
            alParaval.Add(cmbmerchant.Text.Trim)
            alParaval.Add(cmbdesignno.Text.Trim)
            alParaval.Add(CMBCOLOR.Text.Trim)
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

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONSUME.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value
                        qtyunit = row.Cells(gqtyunit.Index).Value

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value.ToString
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(gridremarks)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)


            Dim objclsCONSUME As New ClsCONSUME
            objclsCONSUME.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsCONSUME.save()
                MessageBox.Show("Details Added")
            Else
                alParaval.Add(TEMPCONSUMENO)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsCONSUME.Update()
                MsgBox("Details Updated")
            End If
            edit = False
            Dim TEMPMSG As Integer
            TEMPMSG = MsgBox("WISH TO PRINT", MsgBoxStyle.YesNo)

            If TEMPMSG = vbYes Then
                Dim OBJGN As New consumedesign
                OBJGN.CONSUMENO = TXTCONSUMENO.Text
                OBJGN.MdiParent = MDIMain
                OBJGN.selfor_po = "{CONSUMPTION.CONSUME_no}=" & TXTCONSUMENO.Text & " and {CONSUMPTION.CONSUME_cmpid}=" & CmpId & " and {CONSUMPTION.CONSUME_locationid}=" & Locationid & " and {CONSUMPTION.CONSUME_yearid}=" & YearId
                OBJGN.Show()
            End If
            clear()
            CMBISSUETO.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBISSUETO.Text.Trim.Length = 0 Then
            EP.SetError(CMBISSUETO, "Enter Issue To")
            bln = False
        End If

        If cmbdepartment.Text.Trim.Length = 0 Then
            EP.SetError(cmbdepartment, "Enter Department")
            bln = False
        End If

        If GRIDCONSUME.RowCount = 0 Then
            EP.SetError(txtqty, "Enter Item Details")
            bln = False
        End If

        If edit = False Then
            Dim OBJCMN As New ClsCommon
            For Each ROW As DataGridViewRow In GRIDCONSUME.Rows
                Dim DT As DataTable = OBJCMN.search(" ISNULL(sum(qty),0) ", "  ", " view_store_stock", " and itemname='" & ROW.Cells(gitemname.Index).Value & "' and yearid=" & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item(0)) - Val(ROW.Cells(gQty.Index).Value) < 0 Then
                        EP.SetError(lblsih, "Negative Stock for Item Name " & ROW.Cells(gitemname.Index).Value)
                        bln = False
                    End If
                Else
                    EP.SetError(lblsih, "Negative Stock for Item Name " & ROW.Cells(gitemname.Index).Value)
                    bln = False
                End If
            Next
        End If

        'If Val(lblsih.Text) < 0 Then
        '    EP.SetError(lblsih, "Negative Stock")
        '    bln = False
        'ElseIf Val(lblsih.Text) - Val(lbltotalqty.Text) < 0 Then
        '    EP.SetError(lblsih, "Negative Stock")
        '    bln = False
        'End If



        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Quotation Raised, Delete Quotation First")
            bln = False
        End If

        If Not datecheck(CONSUMEdate.Value) Then bln = False
        Return bln
    End Function

    Private Sub PurchaseCONSUMEuisition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PurchaseCONSUMEuisition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Sub fillcmb()
        If CMBProcess.Text.Trim = "" Then FILLPROCESS(CMBProcess, " AND PROCESSMASTER.PROCESS_TYPE<>''", edit)
        If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
        filldepartment(cmbdepartment, edit)
        fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        fillDESIGN(cmbdesignno, cmbmerchant.Text)
        If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR)
        fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        fillunit(cmbqtyunit)

        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT DISTINCT CONSUME_ISSUETO AS ISSUETO FROM CONSUMPTION WHERE CONSUME_YEARID = " & YearId, "", "")
        CMBISSUETO.DataSource = DT
        CMBISSUETO.DisplayMember = "ISSUETO"
        CMBISSUETO.Text = ""

    End Sub

    Private Sub PurchaseCONSUMEuisition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
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
                Dim objclsCONSUME As New ClsCONSUME

                ALPARAVAL.Add(TEMPCONSUMENO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsCONSUME.alParaval = ALPARAVAL
                Dim dt As DataTable = objclsCONSUME.selectconsume()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTCONSUMENO.Text = TEMPCONSUMENO
                        CONSUMEdate.Value = Convert.ToDateTime(dr("CONSUMEDATE"))
                        CMBISSUETO.Text = Convert.ToString(dr("ISSUETO"))
                        cmbdepartment.Text = Convert.ToString(dr("DEPARTMENT"))
                        CMBProcess.Text = Convert.ToString(dr("PROCESS"))
                        CMBDYEING.Text = Convert.ToString(dr("DYEINGNO"))
                        cmbmerchant.Text = Convert.ToString(dr("MERCHANT"))
                        cmbdesignno.Text = Convert.ToString(dr("DESIGNNO"))
                        CMBCOLOR.Text = Convert.ToString(dr("COLOR"))
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        GRIDCONSUME.Rows.Add(dr("gridsrno").ToString, dr("ITEMNAME").ToString, dr("DESC").ToString, Val(dr("QTY")), dr("QTYUNIT").ToString)

                    Next
                    GRIDCONSUME.FirstDisplayedScrollingRowIndex = GRIDCONSUME.RowCount - 1
                End If

                chkchange.CheckState = CheckState.Checked
                qtytotal()
            End If

            'If gridDoubleClick = False Then
            If GRIDCONSUME.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCONSUME.Rows(GRIDCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
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
            If GRIDCONSUME.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCONSUME.Rows(GRIDCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True Then
                Dim BLN As Boolean = True
                Dim TEMPMSG As Integer = MsgBox("Delete CONSUME?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJPR As New ClsCONSUME

                    ALPARAVAL.Add(TEMPCONSUMENO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJPR.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJPR.Delete()
                    MsgBox("Purchase CONSUMEuest Deleted")
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
        TEMPCONSUMENO = Val(TXTCONSUMENO.Text) - 1
        clear()
        If TEMPCONSUMENO > 0 Then
            edit = True
            PurchaseCONSUMEuisition_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        TEMPCONSUMENO = Val(TXTCONSUMENO.Text) + 1
        getmax_CONSUME_no()
        clear()
        If Val(TXTCONSUMENO.Text) - 1 >= TEMPCONSUMENO Then
            edit = True
            PurchaseCONSUMEuisition_Load(sender, e)
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

    Private Sub CONSUMEdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CONSUMEdate.Validating
        If Not datecheck(CONSUMEdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub


    Private Sub gridpurchaseCONSUME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCONSUME.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCONSUME.RowCount > 0 Then


                GRIDCONSUME.Rows.RemoveAt(GRIDCONSUME.CurrentRow.Index)
                qtytotal()
                getsrno(GRIDCONSUME)
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
        TEMPCONSUMENO = Val(tstxtbillno.Text)
        clear()
        If TEMPCONSUMENO > 0 Then
            edit = True
            PurchaseCONSUMEuisition_Load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub cmbqtyunit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.Validated
        Try
            If cmbitemname.Text.Trim <> "" And cmbqtyunit.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 Then
                EP.Clear()
                If GRIDCONSUME.RowCount > 0 Then
                    If (gridDoubleClick = False) Or (gridDoubleClick = True And LCase(cmbitemname.Text.Trim) <> LCase(GRIDCONSUME.Item(gitemname.Index, tempRow).Value)) Then
                        If CHECKITEMNAME() Then
                            Exit Sub
                        End If
                    End If
                End If
                fillgrid()
                qtytotal()
                grpdyeing.Enabled = False
                CMBCOLOR.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKITEMNAME() As Boolean
        Try
            Dim BLN As Boolean = False
            For Each ROW As DataGridViewRow In GRIDCONSUME.Rows
                If ROW.Cells(gitemname.Index).Value = cmbitemname.Text.Trim Then
                    BLN = True
                    EP.SetError(CMBProcess, "Item Name already Present below")
                    Exit For
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                Dim OBJGN As New consumedesign
                OBJGN.CONSUMENO = TEMPCONSUMENO
                OBJGN.MdiParent = MDIMain
                OBJGN.CONDITION = "{CONSUMPTION.CONSUME_no}=" & TEMPCONSUMENO & " and {CONSUMPTION.CONSUME_cmpid}=" & CmpId & " and {CONSUMPTION.CONSUME_locationid}=" & Locationid & " and {CONSUMPTION.CONSUME_yearid}=" & YearId
                OBJGN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridCONSUME_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDCONSUME.CellValidating
        Try
            Dim colNum As Integer = GRIDCONSUME.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gQty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCONSUME.CurrentCell.Value = Nothing Then GRIDCONSUME.CurrentCell.Value = "0.00"
                        GRIDCONSUME.CurrentCell.Value = Convert.ToDecimal(GRIDCONSUME.Item(colNum, e.RowIndex).Value)
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
        If GRIDCONSUME.RowCount = 0 And edit = False Then

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable

            DT = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, PROCESS_DESC.PROCESS_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, PROCESS_DESC.PROCESS_RATE AS RATE", "", " PROCESS_DESC INNER JOIN ITEMMASTER ON PROCESS_DESC.PROCESS_ITEMid = ITEMMASTER.item_id AND PROCESS_DESC.PROCESS_cmpid = ITEMMASTER.item_cmpid AND PROCESS_DESC.PROCESS_locationid = ITEMMASTER.item_locationid AND PROCESS_DESC.PROCESS_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PROCESS_DESC.PROCESS_cmpid = UNITMASTER.unit_cmpid AND PROCESS_DESC.PROCESS_locationid = UNITMASTER.unit_locationid AND PROCESS_DESC.PROCESS_yearid = UNITMASTER.unit_yearid AND PROCESS_DESC.PROCESS_unitid = UNITMASTER.unit_id INNER JOIN PROCESSMASTER ON PROCESS_DESC.PROCESS_id = PROCESSMASTER.PROCESS_ID AND PROCESS_DESC.PROCESS_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESS_DESC.PROCESS_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESS_DESC.PROCESS_yearid = PROCESSMASTER.PROCESS_YEARID", " AND PROCESSMASTER.PROCESS_NAME = '" & CMBProcess.Text.Trim & "' AND PROCESS_DESC.PROCESS_CMPID = " & CmpId & " AND PROCESS_DESC.PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_DESC.PROCESS_YEARID= " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDCONSUME.Rows.Add(0, DTROW("ITEMNAME"), "", DTROW("QTY"), DTROW("UNIT"))
                Next
                getsrno(GRIDCONSUME)
                qtytotal()
            End If
        End If
    End Sub
End Class