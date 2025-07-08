
Imports BL
Imports System.IO
Imports System.ComponentModel

Public Class Mfg2

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim COPY As Boolean = False
    Dim gridITEMDoubleClick As Boolean
    Dim gridEXTRADoubleClick As Boolean

    Public edit As Boolean          'used for editing
    Public TEMPMFGNO As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim TEMPITEMROW As Integer
    Dim dt_colorwt As New DataTable
    Dim dt_CONSUMPTION As New DataTable
    Public Shared SELECTMFG As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        EP.Clear()
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        CHKRECD.CheckState = CheckState.Checked
        CHKCHANGEDESIGNNO.CheckState = CheckState.Unchecked
        CHKCHANGEMERCHANT.CheckState = CheckState.Unchecked
        TXTDESIGN.ReadOnly = True
        TXTMERCHANT.ReadOnly = True
        tstxtbillno.Clear()
        LBLTOTALPCS.Text = 0.0
        LBLTOTALSAREE.Text = 0.0
        LBLTOTALMTRS.Text = 0.0
        LBLTOTALRECDPCS.Text = 0.0
        LBLTOTALRECDSAREE.Text = 0.0
        LBLTOTALRECDMTRS.Text = 0.0
        LBLTOTALDIFF.Text = 0.0
        LBLACTCONSUMEDAMT.Text = 0
        LBLACTCONSUMEDQTY.Text = 0.0
        LBLDEFCONSUMEDAMT.Text = 0.0
        LBLDEFCONSUMEDQTY.Text = 0.0
        LBLGRIDTOTAL.Text = 0.0
        LBLGRIDAVRG.Text = 0.0
        txtjobno.Clear()
        txtsrno.Clear()
        CMBITEMNAME.Text = ""
        txtdefqty.Clear()
        txtactqty.Clear()
        cmbunit.Text = ""
        txtdefrate.Clear()
        TXTACTRATE.Clear()
        CMBDEPARTMENT.Text = ""

        CMBDYEING.Text = ""
        CMBCLR.Text = ""
        CMBDYEING.Enabled = True

        TXTMFGNO.Clear()

        MFGDATE.Value = Mydate
        TXTGRIDREMARKS.Text = Mydate

        CMBFROM.Text = ""
        CMBTO.Text = ""
        INTIME.Value = Format(Now, "dd/MM/yyyy  hh:mm:ss tt")
        OUTTIME.Value = Format(Now, "dd/MM/yyyy  hh:mm:ss tt")
        cmbshift.Text = "Day"
        If cmbshift.Text = "Day" Then
            INTIME.Value = Now.Date & " 08:01:00 AM"
            OUTTIME.Value = Now.Date & " 07:59:00 PM"
        Else
            INTIME.Value = Now.Date & " 08:01:00 PM"
            OUTTIME.Value = Now.Date & " 07:59:00 AM"

        End If
        cmbcontractor.Text = ""
        cmbsupervisior.Text = ""
        cmbmachineno.DataSource = Nothing

        TXTMERCHANT.Clear()
        txtlotno.Clear()
        TXTCUT.Clear()
        TXTDESIGN.Clear()
        txtquality.Clear()

        txtremarks.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

        dt_colorwt.Reset()
        dt_colorwt.Columns.Add("srno")
        dt_colorwt.Columns.Add("colsrno")
        dt_colorwt.Columns.Add("screen")
        dt_colorwt.Columns.Add("shade")
        dt_colorwt.Columns.Add("wt", System.Type.GetType("System.Decimal"))

        dt_CONSUMPTION.Reset()
        dt_CONSUMPTION.Columns.Add("srno1")
        dt_CONSUMPTION.Columns.Add("colsrno1")
        dt_CONSUMPTION.Columns.Add("ITEMNAME1")
        dt_CONSUMPTION.Columns.Add("PERCENT1", System.Type.GetType("System.Decimal"))
        dt_CONSUMPTION.Columns.Add("TOTALPART1", System.Type.GetType("System.Decimal"))
        dt_CONSUMPTION.Columns.Add("PART1", System.Type.GetType("System.Decimal"))
        dt_CONSUMPTION.Columns.Add("RATE1", System.Type.GetType("System.Decimal"))
        dt_CONSUMPTION.Columns.Add("TOTALWT1", System.Type.GetType("System.Decimal"))
        dt_CONSUMPTION.Columns.Add("WT1", System.Type.GetType("System.Decimal"))


        'clearing itemgrid textboxes and combos
        GRIDMFG.RowCount = 0
        GRIDCONSUMPTION.RowCount = 0
        GRIDCOLORWT.RowCount = 0

        TXTPCSFORCALC.Clear()

        TXTITEMSRNO.Clear()
        cmbpiecetype.Text = ""
        TXTGRIDREMARKS.Clear()
        cmbcolor.Text = ""
        TXTPCS.Clear()
        txtmtrs.Clear()
        TXTRECDMTRS.Clear()
        txtrecsaree.Clear()
        TXTRECDPCS.Clear()
        TXTDIFF.Clear()

        TXTCUTTINGNO.Clear()
        TXTCUTTINGSRNO.Clear()
        TXTGRIDMFGNO.Clear()
        TXTMFGSRNO.Clear()
        TXTGRIDLOTNO.Clear()
        TXTLOTSRNO.Clear()
        txtcoloramt.Text = 0
        txtcolorrate.Text = 0
        txtlabouramt.Text = 0
        txtlabourrate.Text = 0
        lbltotalExtraAmt.Text = 0
        TXTEXTRAAMT.Text = 0
        txtExtraRate.Text = 0
        txtExtrasrno.Text = 1
        gridhelper.RowCount = 0
        GRIDEXTRA.RowCount = 0
        txthsrno.Clear()
        cmbdesignation.Text = ""
        txthelpers.Clear()
        txthelpername.Clear()
        If gridhelper.RowCount > 0 Then
            txthsrno.Text = Val(gridhelper.Rows(gridhelper.RowCount - 1).Cells(GHSRNO.Index).Value) + 1
        Else
            txthsrno.Text = 1
        End If
        If GRIDEXTRA.RowCount > 0 Then
            txtExtrasrno.Text = Val(GRIDEXTRA.Rows(GRIDEXTRA.RowCount - 1).Cells(gextrasrno.Index).Value) + 1
        Else
            txtExtrasrno.Text = 1
        End If


        CMDSELECT.Enabled = True
        CMBFROM.Enabled = True
        CMBTO.Enabled = True
        gridDoubleClick = False
        gridITEMDoubleClick = False
        getmaxno()

        TXTWORKER.Clear()
        CHKPRESENT.CheckState = CheckState.Checked

        If GRIDCONSUMPTION.RowCount > 0 Then
            txtsrno.Text = Val(GRIDCONSUMPTION.Rows(GRIDCONSUMPTION.RowCount - 1).Cells(GCONSUMEDSRNO.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        If GRIDMFG.RowCount > 0 Then
            TXTITEMSRNO.Text = Val(GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            TXTITEMSRNO.Text = 1
        End If

    End Sub

    Sub TOTALCONSUMPTION()
        Try
            LBLACTCONSUMEDQTY.Text = 0.0
            LBLACTCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDQTY.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDCONSUMPTION.Rows
                If ROW.Cells(GCONSUMEDSRNO.Index).Value <> Nothing Then
                    ROW.Cells(gdefamt.Index).Value = Val(ROW.Cells(GdefQTY.Index).EditedFormattedValue) * Val(ROW.Cells(GdefRATE.Index).EditedFormattedValue)
                    ROW.Cells(gActAmt.Index).Value = Val(ROW.Cells(GactQty.Index).EditedFormattedValue) * Val(ROW.Cells(gActRate.Index).EditedFormattedValue)

                    LBLACTCONSUMEDQTY.Text = Format(Val(LBLACTCONSUMEDQTY.Text) + Val(ROW.Cells(GactQty.Index).EditedFormattedValue), "0.00")
                    LBLACTCONSUMEDAMT.Text = Format(Val(LBLACTCONSUMEDAMT.Text) + Val(ROW.Cells(gActAmt.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDQTY.Text = Format(Val(LBLDEFCONSUMEDQTY.Text) + Val(ROW.Cells(GdefQTY.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDAMT.Text = Format(Val(LBLDEFCONSUMEDAMT.Text) + Val(ROW.Cells(gdefamt.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDYEING.GotFocus
        Try
            If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            Dim AVGTOTAL As Double = 0
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALRECDMTRS.Text = 0.0
            LBLTOTALDIFF.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            LBLTOTALSAREE.Text = 0.0
            LBLTOTALRECDPCS.Text = 0.0
            LBLTOTALRECDSAREE.Text = 0.0
            lbltotalExtraAmt.Text = 0.0
            LBLGRIDTOTAL.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDMFG.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    ROW.Cells(GDIFF.Index).Value = Format(Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue) - Val(ROW.Cells(GMTRS.Index).Value), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALSAREE.Text = Format(Val(LBLTOTALSAREE.Text) + Val(ROW.Cells(ginsaree.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALRECDPCS.Text = Format(Val(LBLTOTALRECDPCS.Text) + Val(ROW.Cells(GRECDPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALRECDMTRS.Text = Format(Val(LBLTOTALRECDMTRS.Text) + Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALRECDSAREE.Text = Format(Val(LBLTOTALRECDSAREE.Text) + Val(ROW.Cells(grecsaree.Index).EditedFormattedValue), "0.00")
                    LBLTOTALDIFF.Text = Format(Val(LBLTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue), "0.00")

                    ROW.Cells(GCOLAMT.Index).Value = 0
                    For Each DTROW As DataRow In dt_colorwt.Rows
                        If DTROW("SRNO") = ROW.Cells(gsrno.Index).Value Then
                            DT = OBJCMN.search("  COLORMASTER.COLOR_name AS COLOR, DESIGNRECIPE_DESC.DESIGN_TOTALCOST AS AMT", "", " DESIGNRECIPE_DESC INNER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = COLORMASTER.COLOR_yearid INNER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = SCREENMASTER.SCREEN_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = SCREENMASTER.SCREEN_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = SCREENMASTER.SCREEN_yearid INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid  ", " AND DESIGN_NO = '" & TXTDESIGN.Text.Trim & "' AND ITEM_NAME ='" & TXTMERCHANT.Text.Trim & "' AND SCREEN_NAME = '" & DTROW("SCREEN") & "' and  COLORMASTER.COLOR_name = '" & ROW.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId)
                            If DT.Rows.Count > 0 Then ROW.Cells(GCOLAMT.Index).Value = ROW.Cells(GCOLAMT.Index).Value + Format(DT.Rows(0).Item("AMT") * Val(DTROW("WT")), "0.00")
                        End If
                    Next


                    LBLGRIDTOTAL.Text = Format(Val(LBLGRIDTOTAL.Text) + Val(ROW.Cells(GCOLAMT.Index).EditedFormattedValue), "0.00")
                    ROW.Cells(GAVG.Index).Value = Format(Val(ROW.Cells(GCOLAMT.Index).EditedFormattedValue) / Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue), "0.00")
                    AVGTOTAL = Format(Val(AVGTOTAL) + Val(ROW.Cells(GAVG.Index).EditedFormattedValue), "0.00")
                End If
            Next

            For Each ROW As DataGridViewRow In GRIDEXTRA.Rows
                If ROW.Cells(gextrasrno.Index).Value <> Nothing Then
                    If ROW.Cells(GRATEON.Index).Value = "MTRS" Then
                        lbltotalExtraAmt.Text = Format(Val(lbltotalExtraAmt.Text) + (Val(ROW.Cells(gextraRate.Index).Value) * Val(LBLTOTALRECDMTRS.Text.Trim)), "0.00")
                    Else
                        lbltotalExtraAmt.Text = Format(Val(lbltotalExtraAmt.Text) + (Val(ROW.Cells(gextraRate.Index).Value) * Val(LBLTOTALRECDSAREE.Text.Trim)), "0.00")

                    End If
                End If
            Next

            LBLGRIDAVRG.Text = Format(Val(LBLGRIDTOTAL.Text.Trim) / Val(LBLTOTALRECDMTRS.Text.Trim), "0.00")
            txtlabouramt.Text = Val(txtlabourrate.Text) * Val(LBLTOTALRECDMTRS.Text.Trim)
            txtcoloramt.Text = Val(txtcolorrate.Text) * Val(LBLTOTALRECDMTRS.Text.Trim)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
        CMBFROM.Focus()
    End Sub

    Private Sub MFGDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MFGDATE.Validating
        If Not datecheck(MFGDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub INTIME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles INTIME.Validating
        If Not datecheck(INTIME.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub OUTTIME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OUTTIME.Validating
        If Not datecheck(OUTTIME.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(MFG_NO),0) + 1 ", " MFGMASTER2", " AND MFG_cmpid=" & CmpId & " and MFG_locationid=" & Locationid & " and MFG_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTMFGNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBTO.Text.Trim.Length = 0 Then
                EP.SetError(CMBTO, " Select Process")
                bln = False
            End If

            If cmbmachineno.Text.Trim.Length = 0 Then
                EP.SetError(cmbmachineno, "Please Select Machine No.")
                bln = False
            End If

            If TXTMERCHANT.Text.Trim.Length = 0 Then
                EP.SetError(TXTMERCHANT, "Please Select Item")
                bln = False
            End If


            If CMBDEPARTMENT.Text.Trim.Length = 0 Then
                EP.SetError(CMBDEPARTMENT, "Please Select Department")
                bln = False
            End If


            If GRIDMFG.RowCount = 0 Then
                EP.SetError(TXTMERCHANT, "Please Select Item")
                bln = False
            End If


            For Each ROW As DataGridViewRow In GRIDMFG.Rows
                If IsDBNull(ROW.Cells(gcolorwt.Index).Value) = False Then
                    If Convert.ToDecimal(ROW.Cells(gcolorwt.Index).Value) > 0 Then
LINE1:
                        For i As Integer = 0 To dt_colorwt.Rows.Count - 1
                            If IsDBNull(dt_colorwt.Rows(i).Item("SRNO")) = True Then
                                dt_colorwt.Rows(i).Item("SRNO") = 0
                            End If
                            If IsDBNull(dt_colorwt.Rows(i).Item("WT")) = True Then
                                dt_colorwt.Rows(i).Item("WT") = 0
                            End If
                            If dt_colorwt.Rows(i).Item("SRNO") = ROW.Cells(gsrno.Index).Value And dt_colorwt.Rows(i).Item("WT") = 0 Then
                                dt_colorwt.Rows.RemoveAt(i)
                                GoTo LINE1
                            End If
                        Next
                    End If
                End If
            Next
            'If lbllocked.Visible = True Then
            '    EP.SetError(lbllocked, "Item Used in Mfg, Delete Mfg First")
            '    bln = False
            'End If


            If Not datecheck(MFGDATE.Value) Then bln = False

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(MFGDATE.Value)
            alParaval.Add(CMBFROM.Text.Trim)
            alParaval.Add(CMBTO.Text.Trim)
            alParaval.Add(cmbmachineno.Text.Trim)
            alParaval.Add(cmbsupervisior.Text.Trim)
            alParaval.Add(INTIME.Value)
            alParaval.Add(OUTTIME.Value)
            alParaval.Add(DTDATEDIFF.Value)

            alParaval.Add(TXTMERCHANT.Text.Trim)
            alParaval.Add(Val(txtlotno.Text.Trim))
            alParaval.Add(Val(TXTCUT.Text.Trim))
            alParaval.Add(TXTDESIGN.Text.Trim)
            alParaval.Add(txtquality.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)


            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALSAREE.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALRECDPCS.Text))
            alParaval.Add(Val(LBLTOTALRECDSAREE.Text))
            alParaval.Add(Val(LBLTOTALRECDMTRS.Text))
            alParaval.Add(Val(LBLTOTALDIFF.Text))
            alParaval.Add(Val(LBLDEFCONSUMEDQTY.Text))
            alParaval.Add(Val(LBLACTCONSUMEDQTY.Text))
            alParaval.Add(Val(LBLDEFCONSUMEDAMT.Text))
            alParaval.Add(Val(LBLACTCONSUMEDAMT.Text))
            alParaval.Add(Val(LBLGRIDTOTAL.Text))
            alParaval.Add(Val(LBLGRIDAVRG.Text))
            alParaval.Add(txtjobno.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CMBDYEING.Text.Trim)
            alParaval.Add(CMBCLR.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim CONTRACTOR As String = ""
            Dim gridremarks As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim INSAREE As String = ""
            Dim MTRS As String = ""
            Dim RECDPCS As String = ""
            Dim RECDMTRS As String = ""
            Dim RECSAREE As String = ""
            Dim DIFF As String = ""
            Dim COLWT As String = ""
            Dim COLAMT As String = ""
            Dim DONE As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim CUTTINGNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim CUTTINGSRNO As String = ""    'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGNO As String = ""            'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim LOTNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim LOTSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE

            Dim TYPE As String = ""          'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDMFG.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        CONTRACTOR = row.Cells(gcontractor.Index).Value.ToString
                        gridremarks = Format(Convert.ToDateTime(row.Cells(gdesc.Index).Value.ToString), "MM/dd/yyyy")
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        PCS = row.Cells(GPCS.Index).Value.ToString
                        INSAREE = row.Cells(ginsaree.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        RECDPCS = row.Cells(GRECDPCS.Index).Value.ToString
                        RECSAREE = row.Cells(grecsaree.Index).Value.ToString
                        RECDMTRS = row.Cells(GRECDMTRS.Index).Value.ToString
                        DIFF = row.Cells(GDIFF.Index).Value.ToString
                        COLWT = row.Cells(gcolorwt.Index).Value.ToString
                        COLAMT = row.Cells(GCOLAMT.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        CUTTINGNO = row.Cells(GCUTTINGNO.Index).Value
                        CUTTINGSRNO = row.Cells(GCUTTINGSRNO.Index).Value
                        MFGNO = row.Cells(GMFGNO.Index).Value
                        MFGSRNO = row.Cells(GMFGSRNO.Index).Value
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        LOTSRNO = row.Cells(GLOTSRNO.Index).Value
                        TYPE = row.Cells(GTYPE.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value
                        CONTRACTOR = CONTRACTOR & "," & row.Cells(gcontractor.Index).Value.ToString
                        gridremarks = gridremarks & "," & Format(Convert.ToDateTime(row.Cells(gdesc.Index).Value.ToString), "MM/dd/yyyy")
                        COLOR = COLOR & "," & row.Cells(GCOLOR.Index).Value.ToString
                        PCS = PCS & "," & row.Cells(GPCS.Index).Value.ToString
                        INSAREE = INSAREE & "," & row.Cells(ginsaree.Index).Value.ToString
                        MTRS = MTRS & "," & row.Cells(GMTRS.Index).Value.ToString
                        RECDPCS = RECDPCS & "," & row.Cells(GRECDPCS.Index).Value.ToString
                        RECSAREE = RECSAREE & "," & row.Cells(grecsaree.Index).Value.ToString
                        RECDMTRS = RECDMTRS & "," & row.Cells(GRECDMTRS.Index).Value.ToString
                        DIFF = DIFF & "," & row.Cells(GDIFF.Index).Value
                        COLWT = COLWT & "," & row.Cells(gcolorwt.Index).Value.ToString
                        COLAMT = COLAMT & "," & row.Cells(GCOLAMT.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "," & "1"
                        Else
                            DONE = DONE & "," & "0"
                        End If
                        CUTTINGNO = CUTTINGNO & "," & row.Cells(GCUTTINGNO.Index).Value
                        CUTTINGSRNO = CUTTINGSRNO & "," & row.Cells(GCUTTINGSRNO.Index).Value
                        MFGNO = MFGNO & "," & row.Cells(GMFGNO.Index).Value
                        MFGSRNO = MFGSRNO & "," & row.Cells(GMFGSRNO.Index).Value
                        LOTNO = LOTNO & "," & row.Cells(GLOTNO.Index).Value
                        LOTSRNO = LOTSRNO & "," & row.Cells(GLOTSRNO.Index).Value

                        TYPE = TYPE & "," & row.Cells(GTYPE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(CONTRACTOR)
            alParaval.Add(gridremarks)
            alParaval.Add(COLOR)
            alParaval.Add(PCS)
            alParaval.Add(INSAREE)
            alParaval.Add(MTRS)
            alParaval.Add(RECDPCS)
            alParaval.Add(RECSAREE)
            alParaval.Add(RECDMTRS)
            alParaval.Add(DIFF)
            alParaval.Add(COLWT)
            alParaval.Add(COLAMT)
            alParaval.Add(DONE)
            alParaval.Add(CUTTINGNO)
            alParaval.Add(CUTTINGSRNO)
            alParaval.Add(MFGNO)
            alParaval.Add(MFGSRNO)
            alParaval.Add(LOTNO)
            alParaval.Add(LOTSRNO)
            alParaval.Add(TYPE)



            Dim CONSUMEDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim DEFQTY As String = ""
            Dim ACTQTY As String = ""
            Dim UNIT As String = ""
            Dim DEFRATE As String = ""
            Dim ACTRATE As String = ""
            Dim DEFAMT As String = ""
            Dim ACTAMT As String = ""
            Dim MAINSRNO As String = ""
            Dim COLSRNO As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONSUMPTION.Rows
                If row.Cells(0).Value <> Nothing Or row.Cells(GactQty.Index).Value <> 0 Then
                    If CONSUMEDSRNO = "" Then
                        CONSUMEDSRNO = row.Cells(GCONSUMEDSRNO.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        DEFQTY = row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = row.Cells(GactQty.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = row.Cells(GdefRATE.Index).Value.ToString
                        ACTRATE = row.Cells(gActRate.Index).Value.ToString
                        DEFAMT = row.Cells(gdefamt.Index).Value.ToString
                        ACTAMT = row.Cells(gActAmt.Index).Value.ToString
                        MAINSRNO = row.Cells(gmaingridno.Index).Value.ToString
                        COLSRNO = row.Cells(gcolgridno.Index).Value.ToString
                    Else

                        CONSUMEDSRNO = CONSUMEDSRNO & "," & row.Cells(GCONSUMEDSRNO.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value
                        DEFQTY = DEFQTY & "," & row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = ACTQTY & "," & row.Cells(GactQty.Index).Value.ToString
                        UNIT = UNIT & "," & row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = DEFRATE & "," & row.Cells(GdefRATE.Index).Value
                        ACTRATE = ACTRATE & "," & row.Cells(gActRate.Index).Value
                        DEFAMT = DEFAMT & "," & row.Cells(gdefamt.Index).Value.ToString
                        ACTAMT = ACTAMT & "," & row.Cells(gActAmt.Index).Value.ToString
                        MAINSRNO = MAINSRNO & "," & row.Cells(gmaingridno.Index).Value.ToString
                        COLSRNO = COLSRNO & "," & row.Cells(gcolgridno.Index).Value.ToString
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
            alParaval.Add(DEFAMT)
            alParaval.Add(ACTAMT)
            alParaval.Add(MAINSRNO)
            alParaval.Add(COLSRNO)

            Dim gridno As String = ""
            Dim colgridno As String = ""
            Dim screen As String = ""
            Dim shade As String = ""
            Dim wt As String = ""

            For i As Integer = 0 To dt_colorwt.Rows.Count - 1
                If dt_colorwt.Rows(i).Item(0) <> Nothing Then
                    If gridno = "" Then
                        gridno = Val(dt_colorwt.Rows(i).Item("srno"))
                        colgridno = Val(dt_colorwt.Rows(i).Item("colsrno"))
                        screen = dt_colorwt.Rows(i).Item("screen").ToString
                        shade = dt_colorwt.Rows(i).Item("shade")
                        wt = dt_colorwt.Rows(i).Item("wt")
                    Else
                        gridno = gridno & "," & Val(dt_colorwt.Rows(i).Item("srno"))
                        colgridno = colgridno & "," & Val(dt_colorwt.Rows(i).Item("colsrno"))
                        screen = screen & "," & dt_colorwt.Rows(i).Item("screen").ToString
                        shade = shade & "," & dt_colorwt.Rows(i).Item("shade")
                        wt = wt & "," & dt_colorwt.Rows(i).Item("wt")
                    End If
                End If
            Next

            alParaval.Add(gridno)
            alParaval.Add(colgridno)
            alParaval.Add(screen)
            alParaval.Add(shade)
            alParaval.Add(wt)

            'helpers 
            Dim HSRNO As String = ""
            Dim DESIGNATION As String = ""
            Dim HELPERS As String = ""
            Dim HELPERNAMES As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridhelper.Rows
                If row.Cells(0).Value <> Nothing Then
                    If HSRNO = "" Then
                        HSRNO = row.Cells(GHSRNO.Index).Value.ToString
                        DESIGNATION = row.Cells(gdesignation.Index).Value.ToString
                        HELPERS = row.Cells(ghelpers.Index).Value.ToString
                        HELPERNAMES = row.Cells(gHelperName.Index).Value.ToString

                    Else

                        HSRNO = HSRNO & "," & row.Cells(GHSRNO.Index).Value.ToString
                        DESIGNATION = DESIGNATION & "," & row.Cells(gdesignation.Index).Value.ToString
                        HELPERS = HELPERS & "," & row.Cells(ghelpers.Index).Value.ToString
                        HELPERNAMES = HELPERNAMES & "," & row.Cells(gHelperName.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(HSRNO)
            alParaval.Add(DESIGNATION)
            alParaval.Add(HELPERS)
            alParaval.Add(HELPERNAMES)

            alParaval.Add(Val(txtlabourrate.Text.Trim))
            alParaval.Add(Val(txtlabouramt.Text.Trim))
            alParaval.Add(cmbCOLORRATE.Text)
            alParaval.Add(Val(txtcolorrate.Text.Trim))
            alParaval.Add(Val(txtcoloramt.Text.Trim))
            alParaval.Add(lbltotalExtraAmt.Text.Trim)

            'helpers 
            Dim EXTRASRNO As String = ""
            Dim EXTRANAME As String = ""
            Dim RATEON As String = ""
            Dim EXTRARATE As String = ""
            Dim EXTRAAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDEXTRA.Rows
                If row.Cells(0).Value <> Nothing Then
                    If EXTRASRNO = "" Then
                        EXTRASRNO = row.Cells(gextrasrno.Index).Value.ToString
                        EXTRANAME = row.Cells(gextraName.Index).Value.ToString
                        RATEON = row.Cells(GRATEON.Index).Value.ToString
                        EXTRARATE = row.Cells(gextraRate.Index).Value.ToString
                        EXTRAAMT = row.Cells(gExtraAmt.Index).Value.ToString

                    Else

                        EXTRASRNO = EXTRASRNO & "," & row.Cells(gextrasrno.Index).Value.ToString
                        EXTRANAME = EXTRANAME & "," & row.Cells(gextraName.Index).Value.ToString
                        RATEON = RATEON & "," & row.Cells(GRATEON.Index).Value.ToString
                        EXTRARATE = EXTRARATE & "," & row.Cells(gextraRate.Index).Value.ToString
                        EXTRAAMT = EXTRAAMT & "," & row.Cells(gExtraAmt.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(EXTRASRNO)
            alParaval.Add(EXTRANAME)
            alParaval.Add(RATEON)
            alParaval.Add(EXTRARATE)
            alParaval.Add(EXTRAAMT)

            alParaval.Add(Val(TXTWORKER.Text.Trim))
            alParaval.Add(CHKPRESENT.Checked)
            alParaval.Add(CMBDEPARTMENT.Text.Trim)

            Dim OBJMFG As New ClsMfg2()
            OBJMFG.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJMFG.SAVE()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPMFGNO)

                IntResult = OBJMFG.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False
            Dim TEMPMSG As Integer = MsgBox("WISH TO PRINT", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJGRN As New mfgdesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.frmstring = "MFG2"
                OBJGRN.selfor_po = "{MFGMASTER2.MFG_NO}=" & TXTMFGNO.Text & " and {MFGMASTER2.MFG_cmpid}=" & CmpId & " and {MFGMASTER2.MFG_locationid}=" & Locationid & " and {MFGMASTER2.MFG_yearid}=" & YearId
                OBJGRN.Show()
            End If
            CLEAR()
            CMBFROM.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Mfg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                'Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
                'Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
                Call CMDSELECT_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Mfg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub Mfg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            CLEAR()
            Dim dttable As New DataTable

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsMfg2()
                Dim ALPARAVAL As New ArrayList


                ALPARAVAL.Add(TEMPMFGNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCHECKING.alParaval = ALPARAVAL
                dttable = OBJCHECKING.selectmfg()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTMFGNO.Text = TEMPMFGNO
                        MFGDATE.Value = Format(Convert.ToDateTime(dr("MFGDATE")).Date, "dd/MM/yyyy")
                        CMBFROM.Text = Convert.ToString(dr("FROMPROCESS").ToString)
                        CMBTO.Text = Convert.ToString(dr("TOPROCESS").ToString)


                        CMBDYEING.Text = Convert.ToString(dr("CHART").ToString)
                        CMBCLR.Text = Convert.ToString(dr("NEWCOLOR").ToString)


                        FILLMACHINENO()
                        cmbmachineno.Text = Convert.ToString(dr("MACHINENO").ToString)

                        INTIME.Value = Convert.ToDateTime(dr("INTIME"))
                        OUTTIME.Value = Convert.ToDateTime(dr("OUTTIME"))


                        TXTDESIGN.Text = Convert.ToString(dr("DESIGN").ToString)
                        TXTCUT.Text = Convert.ToString(dr("CUT").ToString)
                        TXTMERCHANT.Text = Convert.ToString(dr("MERCHANT").ToString)
                        txtlotno.Text = Convert.ToString(dr("LOTNO").ToString)
                        cmbmachineno.Text = Convert.ToString(dr("MACHINENO").ToString)
                        cmbsupervisior.Text = Convert.ToString(dr("SUPERVISIOR").ToString)
                        cmbcontractor.Text = Convert.ToString(dr("CONTRACTOR").ToString)
                        txtquality.Text = Convert.ToString(dr("QUALITY").ToString)
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        txtjobno.Text = Convert.ToString(dr("JOBNO").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)

                        txtlabourrate.Text = Convert.ToString(dr("LABOURRATE").ToString)
                        txtlabouramt.Text = Convert.ToString(dr("LABOURAMT").ToString)
                        cmbCOLORRATE.Text = Convert.ToString(dr("COLORS").ToString)
                        txtcolorrate.Text = Convert.ToString(dr("COLORRATE").ToString)
                        txtcoloramt.Text = Convert.ToString(dr("COLORAMT").ToString)
                        lbltotalExtraAmt.Text = Convert.ToString(dr("TOTALEXTRAAMT").ToString)

                        If Val(dr("DIFF").ToString) <> 0 Then CHKRECD.CheckState = CheckState.Unchecked

                        'Item Grid
                        If Val(dr("GRIDSRNO").ToString) <> 0 Then GRIDMFG.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("CONTRACTOR").ToString, Format(Convert.ToDateTime(dr("DESC")).Date, "dd/MM/yyyy"), dr("COLOR").ToString, Format(dr("PCS"), "0.00"), Format(dr("SAREE"), "0.00"), Format(dr("MTRS"), "0.00"), Format(dr("RECDPCS"), "0.00"), Format(dr("RECDSAREE"), "0.00"), Format(dr("RECDMTRS"), "0.00"), Format(dr("DIFF"), "0.00"), Format(dr("COLWT"), "0.00"), 0, 0, dr("GRIDDONE").ToString, dr("CpNO"), dr("CPSRNO"), dr("GRIDMFGNO"), dr("MFGSRNO"), dr("LOTNO"), dr("LOTSRNO"), dr("TYPE"))

                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            GRIDMFG.Rows(GRIDMFG.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                        txtimgpath.Text = dr("IMGPATH")

                        TXTWORKER.Text = Val(dr("WORKER"))
                        CHKPRESENT.Checked = Convert.ToBoolean(dr("CONTRACTORPRESENT"))
                        CMBDEPARTMENT.Text = dr("DEPARTMENT")


                    Next

                    CMBFROM.Enabled = False
                    CMBTO.Enabled = False
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search("  MFGMASTER2_CONSUMED.MFG_SRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, MFGMASTER2_CONSUMED.MFG_defQTY AS defQTY, MFGMASTER2_CONSUMED.MFG_ACTQTY AS actQTY, UNITMASTER.unit_abbr AS UNIT, MFGMASTER2_CONSUMED.MFG_DEFRATE AS DEFRATE, MFGMASTER2_CONSUMED.MFG_ACTRATE AS ACTRATE, MFGMASTER2_CONSUMED.MFG_DEFAMT AS DEFAMT, MFGMASTER2_CONSUMED.MFG_ACTAMT AS ACTAMT, MFGMASTER2_CONSUMED.MFG_MAINSRNO AS MAINSRNO, MFGMASTER2_CONSUMED.MFG_COLSRNO AS COLSRNO", "", " MFGMASTER2_CONSUMED INNER JOIN ITEMMASTER ON MFGMASTER2_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER2_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER2_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER2_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON MFGMASTER2_CONSUMED.MFG_UNITID = UNITMASTER.unit_id AND MFGMASTER2_CONSUMED.MFG_CMPID = UNITMASTER.unit_cmpid AND MFGMASTER2_CONSUMED.MFG_LOCATIONID = UNITMASTER.unit_locationid AND MFGMASTER2_CONSUMED.MFG_YEARID = UNITMASTER.unit_yearid", " AND MFGMASTER2_CONSUMED.MFG_NO = " & TEMPMFGNO & " AND MFGMASTER2_CONSUMED.MFG_CMPID = " & CmpId & " AND MFGMASTER2_CONSUMED.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER2_CONSUMED.MFG_YEARID = " & YearId & " ORDER BY [GRIDSRNO]")
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        GRIDCONSUMPTION.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEMNAME"), Format(DR("DEFQTY"), "0.000"), Format(DR("ACTQTY"), "0.000"), DR("UNIT"), Format(DR("DEFRATE"), "0.00"), Format(DR("ACTRATE"), "0.00"), Format(DR("DEFAMT"), "0.00"), Format(DR("ACTAMT"), "0.00"), DR("MAINSRNO"), DR("COLSRNO"))
                    Next
                End If

                dttable = OBJCMN.search(" MFGMASTER2_HELPERS.MFG_SRNO AS SRNO, DESIGNATIONMASTER.DESIGNATION_name AS DESIGNATION, MFGMASTER2_HELPERS.MFG_HELPERS AS HELPERS, MFGMASTER2_HELPERS.MFG_HELPERNAMES AS HELPERNAMES ", "", "  MFGMASTER2_HELPERS INNER JOIN DESIGNATIONMASTER ON MFGMASTER2_HELPERS.MFG_DESIGNATIONID = DESIGNATIONMASTER.DESIGNATION_id AND MFGMASTER2_HELPERS.MFG_CMPID = DESIGNATIONMASTER.DESIGNATION_cmpid AND MFGMASTER2_HELPERS.MFG_LOCATIONID = DESIGNATIONMASTER.DESIGNATION_locationid AND MFGMASTER2_HELPERS.MFG_YEARID = DESIGNATIONMASTER.DESIGNATION_yearid ", " AND MFGMASTER2_HELPERS.MFG_NO = " & TEMPMFGNO & " AND MFGMASTER2_HELPERS.MFG_CMPID = " & CmpId & " AND MFGMASTER2_HELPERS.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER2_HELPERS.MFG_YEARID = " & YearId & " ORDER BY MFGMASTER2_HELPERS.MFG_SRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        gridhelper.Rows.Add(DR("SRNO").ToString, DR("DESIGNATION"), DR("HELPERS").ToString, DR("HELPERNAMES").ToString)
                    Next
                    getsrno(gridhelper)

                End If

                dttable = OBJCMN.search(" MFGMASTER2_EXTRAAMT.MFG_SRNO AS SRNO, EXTRAMASTER.EXTRA_name AS EXTRA, MFGMASTER2_EXTRAAMT.MFG_RATE AS EXTRARATE, MFGMASTER2_EXTRAAMT.MFG_AMT AS EXTRAAMT, MFGMASTER2_EXTRAAMT.MFG_RATEON AS RATEON ", "", "  MFGMASTER2_EXTRAAMT INNER JOIN EXTRAMASTER ON MFGMASTER2_EXTRAAMT.MFG_EXTRAID = EXTRAMASTER.EXTRA_id AND MFGMASTER2_EXTRAAMT.MFG_CMPID = EXTRAMASTER.EXTRA_cmpid AND MFGMASTER2_EXTRAAMT.MFG_LOCATIONID = EXTRAMASTER.EXTRA_locationid AND MFGMASTER2_EXTRAAMT.MFG_YEARID = EXTRAMASTER.EXTRA_yearid ", " AND MFGMASTER2_EXTRAAMT.MFG_NO = " & TEMPMFGNO & " AND MFGMASTER2_EXTRAAMT.MFG_CMPID = " & CmpId & " AND MFGMASTER2_EXTRAAMT.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER2_EXTRAAMT.MFG_YEARID = " & YearId & " ORDER BY MFGMASTER2_EXTRAAMT.MFG_SRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        GRIDEXTRA.Rows.Add(DR("SRNO").ToString, DR("EXTRA"), DR("RATEON").ToString, DR("EXTRARATE").ToString, DR("EXTRAAMT").ToString)
                    Next
                    getsrno(GRIDEXTRA)

                End If

                dttable = OBJCMN.search("  MFGMASTER2_COLORWT.MFG_SRNO AS GRIDSRNO,MFGMASTER2_COLORWT.MFG_COLSRNO AS COLSRNO, SCREENMASTER.SCREEN_name AS SCREENNAME, MFGMASTER2_COLORWT.MFG_SHADE AS SHADE, MFGMASTER2_COLORWT.MFG_WT AS WT ", "", " MFGMASTER2_COLORWT LEFT OUTER JOIN SCREENMASTER ON MFGMASTER2_COLORWT.MFG_SCREENID = SCREENMASTER.SCREEN_id AND MFGMASTER2_COLORWT.MFG_CMPID = SCREENMASTER.SCREEN_cmpid AND MFGMASTER2_COLORWT.MFG_LOCATIONID = SCREENMASTER.SCREEN_locationid AND MFGMASTER2_COLORWT.MFG_YEARID = SCREENMASTER.SCREEN_yearid ", " AND MFGMASTER2_COLORWT.MFG_NO = " & TEMPMFGNO & " AND MFGMASTER2_COLORWT.MFG_CMPID = " & CmpId & " AND MFGMASTER2_COLORWT.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER2_COLORWT.MFG_YEARID = " & YearId & " order by GRIDSRNO,colsrno")
                Dim dt1 As New DataTable
                If dttable.Rows.Count > 0 Then
                    Dim srno As Integer = 0
                    For Each DR As DataRow In dttable.Rows
                        'If DR("COLSRNO") <> srno Then
                        dt_colorwt.Rows.Add(DR("GRIDSRNO"), DR("COLSRNO"), DR("SCREENNAME"), DR("SHADE"), Format(DR("WT"), "0.00"))

                        'End If
                        'srno = DR("COLSRNO")
                    Next
                End If
                For Each row As DataGridViewRow In GRIDMFG.Rows
                    For Each DR As DataRow In dttable.Rows
                        dt1 = OBJCMN.search(" dbo.ITEMMASTER.item_name AS ITEM, dbo.DESIGNRECIPE_DESC.DESIGN_PERCENT AS [PERCENT], dbo.DESIGNRECIPE_DESC.DESIGN_TOTALPART AS TOTALPART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_PART AS PART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_RATE AS RATE, 0 AS TOTALWT, 0 AS WT ", "", "      dbo.DESIGNRECIPE INNER JOIN dbo.DESIGNRECIPE_DESC ON dbo.DESIGNRECIPE.DESIGN_ID = dbo.DESIGNRECIPE_DESC.DESIGN_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.DESIGNRECIPE_DESC.DESIGN_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN dbo.COLORMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_MATCHINGID = dbo.COLORMASTER.COLOR_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.COLORMASTER.COLOR_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.COLORMASTER.COLOR_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.COLORMASTER.COLOR_yearid INNER JOIN dbo.DESIGNRECIPE_CONSUMPTION ON dbo.DESIGNRECIPE_DESC.DESIGN_ID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ID AND dbo.DESIGNRECIPE_DESC.DESIGN_SRNO = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID INNER JOIN dbo.ITEMMASTER ON dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = dbo.ITEMMASTER.item_id AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = dbo.ITEMMASTER.item_cmpid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = dbo.ITEMMASTER.item_locationid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = dbo.ITEMMASTER.item_yearid LEFT OUTER JOIN dbo.ITEMMASTER AS ITEMMASTER_1 ON dbo.DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER_1.item_id AND dbo.DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER_1.item_cmpid AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER_1.item_locationid AND dbo.DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN dbo.PROCESSMASTER ON dbo.DESIGNRECIPE.DESIGN_PROCESSID = dbo.PROCESSMASTER.PROCESS_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.PROCESSMASTER.PROCESS_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.PROCESSMASTER.PROCESS_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN dbo.SCREENMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_SCREENID = dbo.SCREENMASTER.SCREEN_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.SCREENMASTER.SCREEN_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.SCREENMASTER.SCREEN_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.SCREENMASTER.SCREEN_yearid ", " AND itemmaster_1.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "'  AND DESIGNRECIPE_desc.DESIGN_shade='" & DR("shade") & "' and SCREENMASTER.SCREEN_name='" & DR("SCREENNAME") & "'  AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId)
                        If dt1.Rows.Count > 0 Then
                            For j As Integer = 0 To dt1.Rows.Count - 1
                                dt_CONSUMPTION.Rows.Add(Convert.ToDecimal(DR("GRIDSRNO")), DR("COLSRNO"), dt1.Rows(j).Item("item"), Val(dt1.Rows(j).Item("percent")), Val(dt1.Rows(j).Item("TOTALPART")), Val(dt1.Rows(j).Item("PART")), Val(dt1.Rows(j).Item("RATE")), Val(DR("WT")), Val(dt1.Rows(j).Item("WT")))
                            Next
                        End If
                    Next
                Next
                chkchange.CheckState = CheckState.Checked
            End If
            TOTAL()

            TOTALCONSUMPTION()
            If GRIDCONSUMPTION.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCONSUMPTION.Rows(GRIDCONSUMPTION.RowCount - 1).Cells(GCONSUMEDSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBFROM.Text.Trim = "" Then FILLPROCESS(CMBFROM, " AND (PROCESSMASTER.PROCESS_TYPE='JOB IN' OR PROCESSMASTER.PROCESS_TYPE='FINAL CUTTING' OR PROCESSMASTER.PROCESS_TYPE='CUTTING' OR  PROCESSMASTER.PROCESS_TYPE='MFG2')", edit)
            If CMBTO.Text.Trim = "" Then FILLPROCESS(CMBTO, " AND ( PROCESSMASTER.PROCESS_TYPE='MFG2')", edit)
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
            If cmbdesignation.Text.Trim = "" Then filldesignation(cmbdesignation)
            If cmbcontractor.Text.Trim = "" Then fillCONTRACTOR(cmbcontractor)
            If cmbsupervisior.Text.Trim = "" Then fillSUPERVISIOR(cmbsupervisior)
            If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)
            If cmbCOLORRATE.Text.Trim = "" Then fillCOLORRATE(cmbCOLORRATE)
            If cmbextra.Text.Trim = "" Then fillEXTRA(cmbextra)
            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
            If CMBCLR.Text.Trim = "" Then fillCOLOR(CMBCLR)
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, False)
            FILLGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJMFGDETAILS As New Mfg2Details
            OBJMFGDETAILS.MdiParent = MDIMain
            OBJMFGDETAILS.Show()
            OBJMFGDETAILS.BringToFront()
            Me.Close()
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

    Private Sub CMDSELECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECT.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If CMBTO.Text.Trim = "" Then
                MsgBox("Select Process First", MsgBoxStyle.Critical)
                CMBTO.Focus()
                Exit Sub
            End If

            If CMBFROM.Text.Trim = "" Then
                MsgBox("Select Process First", MsgBoxStyle.Critical)
                CMBFROM.Focus()
                Exit Sub
            End If
            SELECTMFG.Clear()
            Dim WHERE As String = ""
            If edit = True Then WHERE = " AND DESIGN = '" & TXTDESIGN.Text.Trim & "' AND JOBNO = '" & txtjobno.Text.Trim & "' "

            Dim OBJSELECTMFG As New selectMfg2
            OBJSELECTMFG.WHERE = WHERE
            OBJSELECTMFG.PROCESSNAME = CMBFROM.Text.Trim
            OBJSELECTMFG.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTMFG.ShowDialog()


            Dim i As Integer = 0
            If SELECTMFG.Rows.Count > 0 Then
                CMBFROM.Enabled = False
                CMBTO.Enabled = False
                CHKRECD.CheckState = CheckState.Checked

                chkchange.Checked = True
                'If edit = False Then GRIDMFG.RowCount = 0

                For i = 0 To SELECTMFG.Rows.Count - 1

                    TXTMERCHANT.Text = SELECTMFG.Rows(i).Item("MERCHANT")
                    txtquality.Text = SELECTMFG.Rows(i).Item("QUALITY").ToString
                    If CHKCHANGEDESIGNNO.Checked = False Then TXTDESIGN.Text = SELECTMFG.Rows(i).Item("DESIGN").ToString
                    txtlotno.Text = SELECTMFG.Rows(i).Item("LOTNO").ToString
                    txtjobno.Text = SELECTMFG.Rows(i).Item("JOBNO").ToString
                    TXTCUT.Text = SELECTMFG.Rows(i).Item("cut")
                    TXTTYPE.Text = SELECTMFG.Rows(i).Item("TYPE").ToString
                    GRIDMFG.Rows.Add(0, SELECTMFG.Rows(i).Item("PIECETYPE"), SELECTMFG.Rows(i).Item("CONTRACTOR"), Format(Convert.ToDateTime(SELECTMFG.Rows(i).Item("MFGDATE")).Date, "dd/MM/yyyy"), SELECTMFG.Rows(i).Item("color"), Format(Val(SELECTMFG.Rows(i).Item("PCS")), "0.00"), Format(Val(SELECTMFG.Rows(i).Item("Saree")), "0.00"), Format(Val(SELECTMFG.Rows(i).Item("MTRS")), "0.00"), Format(Val(SELECTMFG.Rows(i).Item("PCS")), "0.00"), Format(Val(SELECTMFG.Rows(i).Item("saree")), "0.00"), Format(Val(SELECTMFG.Rows(i).Item("MTRS")), "0.00"), 0, 0, 0, 0, 0, SELECTMFG.Rows(i).Item("cpno"), SELECTMFG.Rows(i).Item("gridsrno"), SELECTMFG.Rows(i).Item("MFGno"), SELECTMFG.Rows(i).Item("MFGsrno"), SELECTMFG.Rows(i).Item("LOTNO"), SELECTMFG.Rows(i).Item("LOTSRNO"), SELECTMFG.Rows(i).Item("TYPE"))

                Next

                getsrno(GRIDMFG)
                Dim dt As New DataTable
                Dim dt1 As New DataTable
                Dim OBJCMN As New ClsCommon
                For Each row As DataGridViewRow In GRIDMFG.Rows
                    dt = OBJCMN.search(" SCREENMASTER.SCREEN_name, DESIGNRECIPE_DESC.DESIGN_SHADE ", "", "  DESIGNRECIPE INNER JOIN DESIGNRECIPE_DESC ON DESIGNRECIPE.DESIGN_ID = DESIGNRECIPE_DESC.DESIGN_ID AND DESIGNRECIPE.DESIGN_YEARID = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id INNER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " order BY DESIGNRECIPE_DESC.DESIGN_SRNO")
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            dt_colorwt.Rows.Add(row.Cells(gsrno.Index).Value, i + 1, dt.Rows(i).Item(0), dt.Rows(i).Item(1), 0)
                            dt1 = OBJCMN.search(" dbo.ITEMMASTER.item_name AS ITEM, dbo.DESIGNRECIPE_DESC.DESIGN_PERCENT AS [PERCENT], dbo.DESIGNRECIPE_DESC.DESIGN_TOTALPART AS TOTALPART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_PART AS PART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_RATE AS RATE, 0 AS TOTALWT, 0 AS WT ", "", "      dbo.DESIGNRECIPE INNER JOIN dbo.DESIGNRECIPE_DESC ON dbo.DESIGNRECIPE.DESIGN_ID = dbo.DESIGNRECIPE_DESC.DESIGN_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.DESIGNRECIPE_DESC.DESIGN_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN dbo.COLORMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_MATCHINGID = dbo.COLORMASTER.COLOR_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.COLORMASTER.COLOR_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.COLORMASTER.COLOR_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.COLORMASTER.COLOR_yearid INNER JOIN dbo.DESIGNRECIPE_CONSUMPTION ON dbo.DESIGNRECIPE_DESC.DESIGN_ID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ID AND dbo.DESIGNRECIPE_DESC.DESIGN_SRNO = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID INNER JOIN dbo.ITEMMASTER ON dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = dbo.ITEMMASTER.item_id AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = dbo.ITEMMASTER.item_cmpid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = dbo.ITEMMASTER.item_locationid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = dbo.ITEMMASTER.item_yearid LEFT OUTER JOIN dbo.ITEMMASTER AS ITEMMASTER_1 ON dbo.DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER_1.item_id AND dbo.DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER_1.item_cmpid AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER_1.item_locationid AND dbo.DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN dbo.PROCESSMASTER ON dbo.DESIGNRECIPE.DESIGN_PROCESSID = dbo.PROCESSMASTER.PROCESS_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.PROCESSMASTER.PROCESS_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.PROCESSMASTER.PROCESS_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN dbo.SCREENMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_SCREENID = dbo.SCREENMASTER.SCREEN_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.SCREENMASTER.SCREEN_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.SCREENMASTER.SCREEN_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.SCREENMASTER.SCREEN_yearid ", " AND itemmaster_1.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' and SCREENMASTER.SCREEN_name='" & dt.Rows(i).Item(0) & "'  AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " ORDER BY DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO")
                            If dt1.Rows.Count > 0 Then
                                For j As Integer = 0 To dt1.Rows.Count - 1
                                    dt_CONSUMPTION.Rows.Add(Convert.ToDecimal(row.Cells(gsrno.Index).Value), i + 1, dt1.Rows(j).Item("item"), Val(dt1.Rows(j).Item("percent")), Val(dt1.Rows(j).Item("TOTALPART")), Val(dt1.Rows(j).Item("PART")), Val(dt1.Rows(j).Item("RATE")), Val(dt1.Rows(j).Item("TOTALWT")), Val(dt1.Rows(j).Item("WT")))
                                Next
                            End If
                        Next
                    End If
                Next
                If TXTDESIGN.Text.Trim <> "" Then
                    'CHANGES DONE BY GULKIT
                    'dt = OBJCMN.search("   CASE WHEN ISNULL(DESIGN_COLBILL1, 0) > ISNULL(DESIGN_COLBILL2, 0) THEN ISNULL(DESIGN_COLBILL1, 0) ELSE ISNULL(DESIGN_COLBILL2, 0) END AS COLBILL, CASE WHEN ISNULL(DESIGN_COLBILL1, 0) > ISNULL(DESIGN_COLBILL2, 0) THEN ISNULL(COLORRATEMASTER.CR_RATE, 0) ELSE ISNULL(COLORRATEMASTER_1.CR_RATE, 0) END AS COLBILLRATE ", "", "       DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN COLORRATEMASTER ON DESIGNRECIPE.DESIGN_COLBILL1 = COLORRATEMASTER.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER.CR_yearid INNER JOIN COLORRATEMASTER AS COLORRATEMASTER_1 ON DESIGNRECIPE.DESIGN_COLBILL2 = COLORRATEMASTER_1.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER_1.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER_1.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER_1.CR_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID  = " & Locationid & " AND  ITEMMASTER.ITEM_YEARID = " & YearId)
                    dt = OBJCMN.search("   DESIGN_COLBILL1 AS COLBILL, COLORRATEMASTER.CR_RATE AS COLBILLRATE ", "", " DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN COLORRATEMASTER ON DESIGNRECIPE.DESIGN_COLBILL1 = COLORRATEMASTER.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER.CR_yearid INNER JOIN COLORRATEMASTER AS COLORRATEMASTER_1 ON DESIGNRECIPE.DESIGN_COLBILL2 = COLORRATEMASTER_1.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER_1.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER_1.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER_1.CR_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID  = " & Locationid & " AND  ITEMMASTER.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        cmbCOLORRATE.Text = dt.Rows(0).Item(0)
                        txtcolorrate.Text = dt.Rows(0).Item(1)
                        txtcoloramt.Text = Val(txtcolorrate.Text) * Val(LBLTOTALRECDMTRS.Text.Trim)
                    Else
                        txtcolorrate.Text = 0
                        txtcoloramt.Text = 0
                    End If
                End If
                If TXTMERCHANT.Text.Trim <> "" Then
                    dt = OBJCMN.search("  ITEMMASTER_RATEDESC.ITEM_RATE ", "", "     ITEMMASTER INNER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID INNER JOIN RATETYPEMASTER ON ITEMMASTER_RATEDESC.ITEM_RATETYPEID = RATETYPEMASTER.RATETYPE_id AND ITEMMASTER_RATEDESC.ITEM_CMPID = RATETYPEMASTER.RATETYPE_cmpid AND ITEMMASTER_RATEDESC.ITEM_LOCATIONID = RATETYPEMASTER.RATETYPE_locationid AND ITEMMASTER_RATEDESC.ITEM_YEARID = RATETYPEMASTER.RATETYPE_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID  = " & Locationid & " AND RATETYPEMASTER.RATETYPE_NAME='LABOUR RATE' AND  ITEMMASTER.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        txtlabourrate.Text = dt.Rows(0).Item(0)
                    Else
                        txtlabourrate.Text = 0
                        txtlabouramt.Text = 0
                    End If
                End If
                TOTAL()
                CMBFROM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDMFG.RowCount = 0
            TEMPMFGNO = Val(tstxtbillno.Text)
            If TEMPMFGNO > 0 Then
                edit = True
                Mfg_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If (Val(TXTCUTTINGNO.Text.Trim) = 0 Or Val(TXTCUTTINGSRNO.Text.Trim) = 0 Or Val(TXTGRIDLOTNO.Text.Trim) = 0) And TXTTYPE.Text <> "PROCESS" Then
            MsgBox("Copy Line Item, Then Add", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If gridITEMDoubleClick = False And Val(TXTCUTTINGNO.Text.Trim) > 0 And Val(TXTCUTTINGSRNO.Text.Trim) > 0 And Val(TXTGRIDLOTNO.Text.Trim) > 0 Then
            If COPY = True Then
                GRIDMFG.Rows.Add(Val(TXTITEMSRNO.Text.Trim), cmbpiecetype.Text.Trim, cmbcontractor.Text.Trim, TXTGRIDREMARKS.Text.Trim, cmbcolor.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(txtinsaree.Text.Trim), "0.00"), Format(Val(txtmtrs.Text.Trim), "0.00"), Format(Val(TXTRECDPCS.Text.Trim), "0.00"), Format(Val(txtrecsaree.Text.Trim), "0.00"), Format(Val(TXTRECDMTRS.Text.Trim), "0.00"), Format(Val(TXTDIFF.Text.Trim), "0.00"), Format(Val(txtcolwt.Text.Trim), "0.00"), 0, 0, Val(TXTCUTTINGNO.Text.Trim), Val(TXTCUTTINGSRNO.Text.Trim), Val(TXTGRIDMFGNO.Text.Trim), Val(TXTMFGSRNO.Text.Trim), Val(TXTGRIDLOTNO.Text.Trim), Val(TXTLOTSRNO.Text.Trim), TXTTYPE.Text.Trim)

                GRIDMFG.Item(GPCS.Index, temprow).Value = Format(Val(GRIDMFG.Item(GPCS.Index, temprow).Value) - Val(TXTPCS.Text.Trim), "0.00")
                GRIDMFG.Item(GMTRS.Index, temprow).Value = Format(GRIDMFG.Item(GMTRS.Index, temprow).Value - Val(txtmtrs.Text.Trim), "0.00")
                GRIDMFG.Item(ginsaree.Index, temprow).Value = Format(GRIDMFG.Item(ginsaree.Index, temprow).Value - Val(txtinsaree.Text.Trim), "0.00")
                GRIDMFG.Item(GRECDPCS.Index, temprow).Value = Format(GRIDMFG.Item(GRECDPCS.Index, temprow).Value - Val(TXTRECDPCS.Text.Trim), "0.00")
                GRIDMFG.Item(grecsaree.Index, temprow).Value = Format(GRIDMFG.Item(grecsaree.Index, temprow).Value - Val(txtrecsaree.Text.Trim), "0.00")
                GRIDMFG.Item(GRECDMTRS.Index, temprow).Value = Format(GRIDMFG.Item(GRECDMTRS.Index, temprow).Value - Val(TXTRECDMTRS.Text.Trim), "0.00")
                GRIDMFG.Item(GDIFF.Index, temprow).Value = Format(GRIDMFG.Item(GDIFF.Index, temprow).Value - Val(TXTDIFF.Text.Trim), "0.00")
            End If
            getsrno(GRIDMFG)
        ElseIf gridITEMDoubleClick = True Then
            GRIDMFG.Item(gsrno.Index, TEMPITEMROW).Value = Val(TXTITEMSRNO.Text.Trim)
            GRIDMFG.Item(GPIECETYPE.Index, TEMPITEMROW).Value = cmbpiecetype.Text.Trim
            GRIDMFG.Item(gcontractor.Index, TEMPITEMROW).Value = cmbcontractor.Text.Trim
            GRIDMFG.Item(gdesc.Index, TEMPITEMROW).Value = TXTGRIDREMARKS.Text.Trim
            GRIDMFG.Item(GCOLOR.Index, TEMPITEMROW).Value = cmbcolor.Text.Trim
            GRIDMFG.Item(GPCS.Index, TEMPITEMROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
            GRIDMFG.Item(GMTRS.Index, TEMPITEMROW).Value = Format(Val(txtmtrs.Text.Trim), "0.00")
            GRIDMFG.Item(ginsaree.Index, TEMPITEMROW).Value = Format(Val(txtinsaree.Text.Trim), "0.00")
            GRIDMFG.Item(gcolorwt.Index, TEMPITEMROW).Value = Format(Val(txtcolwt.Text.Trim), "0.00")
            GRIDMFG.Item(GRECDPCS.Index, TEMPITEMROW).Value = Format(Val(TXTRECDPCS.Text.Trim), "0.00")
            GRIDMFG.Item(grecsaree.Index, TEMPITEMROW).Value = Format(Val(txtrecsaree.Text.Trim), "0.00")
            GRIDMFG.Item(GRECDMTRS.Index, TEMPITEMROW).Value = Format(Val(TXTRECDMTRS.Text.Trim), "0.00")
            GRIDMFG.Item(GDIFF.Index, TEMPITEMROW).Value = Format(Val(TXTDIFF.Text.Trim), "0.00")
            gridITEMDoubleClick = False
        End If

        TOTAL()
        COPY = False

        GRIDMFG.FirstDisplayedScrollingRowIndex = GRIDMFG.RowCount - 1
        If gridDoubleClick = False Then
            If GRIDMFG.RowCount > 0 Then
                TXTITEMSRNO.Text = Val(GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                TXTITEMSRNO.Text = 1
            End If
        End If

        cmbpiecetype.Text = ""
        TXTGRIDREMARKS.Clear()
        cmbcolor.Text = ""
        cmbcontractor.Text = ""
        TXTPCS.Clear()
        txtmtrs.Clear()
        TXTRECDPCS.Clear()
        TXTRECDMTRS.Clear()
        TXTDIFF.Clear()
        txtinsaree.Clear()
        txtrecsaree.Clear()
        TXTCUTTINGNO.Clear()
        TXTCUTTINGSRNO.Clear()
        TXTGRIDMFGNO.Clear()
        TXTMFGSRNO.Clear()
        TXTGRIDLOTNO.Clear()
        TXTTYPE.Clear()
        TXTLOTSRNO.Clear()
        txtcolwt.Clear()
        TXTITEMSRNO.Focus()

    End Sub

    Sub fillCONSUMPTIONgrid()
        If gridDoubleClick = False Then
            GRIDCONSUMPTION.Rows.Add(Val(txtsrno.Text.Trim), CMBITEMNAME.Text.Trim, Format(Val(txtdefqty.Text.Trim), "0.00"), Format(Val(txtactqty.Text.Trim), "0.00"), cmbunit.Text.Trim, Format(Val(txtdefrate.Text.Trim), "0.00"), Format(Val(TXTACTRATE.Text.Trim), "0.00"))
            getsrno(GRIDCONSUMPTION)
        ElseIf gridDoubleClick = True Then
            GRIDCONSUMPTION.Item(GCONSUMEDSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDCONSUMPTION.Item(GITEMNAME.Index, temprow).Value = CMBITEMNAME.Text.Trim
            GRIDCONSUMPTION.Item(GdefQTY.Index, temprow).Value = Format(Val(txtdefqty.Text.Trim), "0.00")
            GRIDCONSUMPTION.Item(GactQty.Index, temprow).Value = Format(Val(txtactqty.Text.Trim), "0.00")
            GRIDCONSUMPTION.Item(GUNIT.Index, temprow).Value = cmbunit.Text.Trim
            GRIDCONSUMPTION.Item(GdefRATE.Index, temprow).Value = Format(Val(txtdefrate.Text.Trim), "0.00")
            GRIDCONSUMPTION.Item(gActRate.Index, temprow).Value = Format(Val(TXTACTRATE.Text.Trim), "0.00")
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

        'as we want to take the same wt for all
        'TXTWT.Clear()

        txtsrno.Focus()

    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDMFG.RowCount = 0

            TEMPMFGNO = Val(TXTMFGNO.Text) - 1
            If TEMPMFGNO > 0 Then
                edit = True
                Mfg_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            TEMPMFGNO = Val(TXTMFGNO.Text) + 1
            getmaxno()
            CLEAR()
            If Val(TXTMFGNO.Text) - 1 >= TEMPMFGNO Then
                edit = True
                Mfg_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
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

                Dim DTTABLE As New DataTable
                DTTABLE = getmax(" MFG_done ", " MFGMASTER2_DESC", " and MFG_no=" & TXTMFGNO.Text.Trim & "  and MFG_done=1 AND MFG_cmpid=" & CmpId & " AND MFG_LOCATIONID = " & Locationid & " AND MFG_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then
                    MsgBox("Mfg Raised Delete Mfg First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete MFG?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPMFGNO)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJMFG As New ClsMfg2()
                    OBJMFG.alParaval = alParaval
                    IntResult = OBJMFG.Delete()
                    MsgBox("MFG Deleted")
                    CLEAR()
                    edit = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCONSUMPTION_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDCONSUMPTION.CellValidating
        Try
            Dim colNum As Integer = GRIDCONSUMPTION.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GactQty.Index, gActAmt.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCONSUMPTION.CurrentCell.Value = Nothing Then GRIDCONSUMPTION.CurrentCell.Value = "0.00"
                        GRIDCONSUMPTION.CurrentCell.Value = Convert.ToDecimal(GRIDCONSUMPTION.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDMFG_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMFG.CellDoubleClick
        Try
            If e.RowIndex = -1 Then
                Exit Sub
            End If

            If e.RowIndex >= 0 And GRIDMFG.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then
                'If Convert.ToBoolean(GRIDMFG.Item(GDONE.Index, e.RowIndex).Value) = False Then
                gridITEMDoubleClick = True
                TXTITEMSRNO.Text = GRIDMFG.Item(gsrno.Index, e.RowIndex).Value
                cmbpiecetype.Text = GRIDMFG.Item(GPIECETYPE.Index, e.RowIndex).Value
                cmbcontractor.Text = GRIDMFG.Item(gcontractor.Index, e.RowIndex).Value
                TXTGRIDREMARKS.Text = GRIDMFG.Item(gdesc.Index, e.RowIndex).Value
                cmbcolor.Text = GRIDMFG.Item(GCOLOR.Index, e.RowIndex).Value
                TXTPCS.Text = GRIDMFG.Item(GPCS.Index, e.RowIndex).Value
                txtinsaree.Text = GRIDMFG.Item(ginsaree.Index, e.RowIndex).Value
                txtrecsaree.Text = GRIDMFG.Item(grecsaree.Index, e.RowIndex).Value
                txtmtrs.Text = GRIDMFG.Item(GMTRS.Index, e.RowIndex).Value
                txtcolwt.Text = GRIDMFG.Item(gcolorwt.Index, e.RowIndex).Value
                TXTRECDPCS.Text = GRIDMFG.Item(GRECDPCS.Index, e.RowIndex).Value
                TXTRECDMTRS.Text = GRIDMFG.Item(GRECDMTRS.Index, e.RowIndex).Value
                TXTDIFF.Text = GRIDMFG.Item(GDIFF.Index, e.RowIndex).Value
                TXTCUTTINGNO.Text = GRIDMFG.Item(GCUTTINGNO.Index, e.RowIndex).Value
                TXTCUTTINGSRNO.Text = GRIDMFG.Item(GCUTTINGSRNO.Index, e.RowIndex).Value
                TXTGRIDMFGNO.Text = GRIDMFG.Item(GMFGNO.Index, e.RowIndex).Value
                TXTMFGSRNO.Text = GRIDMFG.Item(GMFGSRNO.Index, e.RowIndex).Value
                TXTGRIDLOTNO.Text = GRIDMFG.Item(GLOTNO.Index, e.RowIndex).Value
                TXTLOTSRNO.Text = Val(GRIDMFG.Item(GLOTSRNO.Index, e.RowIndex).Value.ToString)
                TXTTYPE.Text = GRIDMFG.Item(GTYPE.Index, e.RowIndex).Value.ToString

                TEMPITEMROW = e.RowIndex
                TXTITEMSRNO.Focus()
                '  Else
                '        MsgBox("Item Locked. First Delete Entry From Mfg")
                ' End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMFG_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDMFG.CellValidating
        Try
            Dim colNum As Integer = GRIDMFG.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GRECDMTRS.Index, GRECDPCS.Index, grecsaree.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDMFG.CurrentCell.Value = Nothing Then GRIDMFG.CurrentCell.Value = "0.00"
                        GRIDMFG.CurrentCell.Value = Convert.ToDecimal(GRIDMFG.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        If e.ColumnIndex = grecsaree.Index And e.FormattedValue <> GRIDMFG.Rows(e.RowIndex).Cells(ginsaree.Index).Value Then
                            GRIDMFG.Rows(e.RowIndex).Cells(GRECDMTRS.Index).Value = Format(TXTCUT.Text * GRIDMFG.Rows(e.RowIndex).Cells(grecsaree.Index).EditedFormattedValue, "0.00")
                        End If
                        TOTAL()
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

    Private Sub GRIDCONSUMPTION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCONSUMPTION.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCONSUMPTION.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCONSUMPTION.Rows.RemoveAt(GRIDCONSUMPTION.CurrentRow.Index)
                getsrno(GRIDCONSUMPTION)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDMFG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDMFG.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMFG.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
LINE1:
                For I As Integer = 0 To dt_colorwt.Rows.Count - 1
                    If GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells("GSRNO").Value = Val(dt_colorwt.Rows(I).Item("SRNO")) Then
                        dt_colorwt.Rows.RemoveAt(I)
                        GoTo LINE1
                    End If
                Next
                For I As Integer = 0 To dt_colorwt.Rows.Count - 1
                    If GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells("GSRNO").Value < Val(dt_colorwt.Rows(I).Item("SRNO")) Then
                        dt_colorwt.Rows(I).Item("SRNO") = Val(dt_colorwt.Rows(I).Item("SRNO")) - 1

                    End If
                Next
LINE2:
                For I As Integer = 0 To dt_CONSUMPTION.Rows.Count - 1
                    If GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells("GSRNO").Value = Val(dt_CONSUMPTION.Rows(I).Item("SRNO1")) Then
                        dt_CONSUMPTION.Rows.RemoveAt(I)
                        GoTo LINE2
                    End If
                Next
                For I As Integer = 0 To dt_CONSUMPTION.Rows.Count - 1
                    If GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells("GSRNO").Value < Val(dt_CONSUMPTION.Rows(I).Item("SRNO1")) Then
                        dt_CONSUMPTION.Rows(I).Item("SRNO1") = Val(dt_CONSUMPTION.Rows(I).Item("SRNO1")) - 1

                    End If
                Next
LINE3:
                For I As Integer = 0 To GRIDCONSUMPTION.Rows.Count - 1
                    If GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells("GSRNO").Value = Val(GRIDCONSUMPTION.Rows(I).Cells("GMAINGRIDNO").Value) Then
                        GRIDCONSUMPTION.Rows.RemoveAt(I)
                        GoTo LINE3
                    End If
                Next
                GRIDMFG.Rows.RemoveAt(GRIDMFG.CurrentRow.Index)
                getsrno(GRIDMFG)
                getsrno(GRIDCONSUMPTION)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTACTRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTACTRATE.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" And Val(txtactqty.Text.Trim) > 0 And cmbunit.Text.Trim <> "" Then

                'CHECK WHETHER ITEM IS PRESENT IN GRID BELOW OR NOT
                For Each ROW As DataGridViewRow In GRIDCONSUMPTION.Rows
                    If (LCase(ROW.Cells(GITEMNAME.Index).Value) = LCase(CMBITEMNAME.Text.Trim) And gridDoubleClick = False) Or (LCase(ROW.Cells(GITEMNAME.Index).Value) = LCase(CMBITEMNAME.Text.Trim) And gridDoubleClick = True And temprow <> ROW.Index) Then
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

    Private Sub CHKRECD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKRECD.CheckedChanged
        Try
            If GRIDMFG.RowCount > 0 Then
                If CHKRECD.CheckState = CheckState.Checked Then
                    For Each ROW As DataGridViewRow In GRIDMFG.Rows
                        ROW.Cells(GRECDPCS.Index).Value = Val(ROW.Cells(GPCS.Index).Value)
                        ROW.Cells(GRECDMTRS.Index).Value = Val(ROW.Cells(GMTRS.Index).Value)
                        ROW.Cells(GDIFF.Index).Value = 0.0
                    Next
                Else
                    For Each ROW As DataGridViewRow In GRIDMFG.Rows
                        ROW.Cells(GRECDPCS.Index).Value = 0.0
                        ROW.Cells(GRECDMTRS.Index).Value = 0.0
                        ROW.Cells(GDIFF.Index).Value = Val(ROW.Cells(GMTRS.Index).Value)
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTO.Validated
        Try
            If CMBTO.Text.Trim <> "" Then CMBTO.Enabled = False
            If edit = False Then GRIDCONSUMPTION.RowCount = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTO.Validating
        Try
            If edit = False And CMBTO.Text.Trim <> "" Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable

                'GETTING CONSUMPTION
                If GRIDCONSUMPTION.RowCount > 0 Then
                    TEMPMSG = MsgBox("Item's Already Present, Delete from Grid?", MsgBoxStyle.YesNo, CmpName)
                    If TEMPMFGNO = vbNo Then Exit Sub
                End If
                GRIDCONSUMPTION.RowCount = 0

                DT = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, PROCESS_DESC.PROCESS_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, PROCESS_DESC.PROCESS_RATE AS RATE", "", " PROCESS_DESC INNER JOIN ITEMMASTER ON PROCESS_DESC.PROCESS_ITEMid = ITEMMASTER.item_id AND PROCESS_DESC.PROCESS_cmpid = ITEMMASTER.item_cmpid AND PROCESS_DESC.PROCESS_locationid = ITEMMASTER.item_locationid AND PROCESS_DESC.PROCESS_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PROCESS_DESC.PROCESS_cmpid = UNITMASTER.unit_cmpid AND PROCESS_DESC.PROCESS_locationid = UNITMASTER.unit_locationid AND PROCESS_DESC.PROCESS_yearid = UNITMASTER.unit_yearid AND PROCESS_DESC.PROCESS_unitid = UNITMASTER.unit_id INNER JOIN PROCESSMASTER ON PROCESS_DESC.PROCESS_id = PROCESSMASTER.PROCESS_ID AND PROCESS_DESC.PROCESS_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESS_DESC.PROCESS_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESS_DESC.PROCESS_yearid = PROCESSMASTER.PROCESS_YEARID", " AND PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND PROCESS_DESC.PROCESS_CMPID = " & CmpId & " AND PROCESS_DESC.PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_DESC.PROCESS_YEARID= " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        GRIDCONSUMPTION.Rows.Add(0, DTROW("ITEMNAME"), DTROW("QTY"), DTROW("QTY"), DTROW("UNIT"), DTROW("RATE"), DTROW("RATE"), DTROW("QTY") * DTROW("RATE"), DTROW("QTY") * DTROW("RATE"), 0, 0)
                    Next
                    getsrno(GRIDCONSUMPTION)
                    TOTALCONSUMPTION()
                End If

            End If
            FILLMACHINENO()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmachineno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmachineno.GotFocus
        Try
            FILLMACHINENO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLMACHINENO()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            'FILLING MACHINES FROM MACHINE MASTER
            DT = OBJCMN.search(" MACHINE_NO", "", " MACHINEMASTER INNER JOIN PROCESSMASTER ON MACHINE_PROCESSID = PROCESS_ID AND MACHINE_CMPID = PROCESS_CMPID AND MACHINE_LOCATIONID = PROCESS_LOCATIONID AND MACHINE_YEARID = PROCESS_YEARID", " AND PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND MACHINE_CMPID = " & CmpId & " AND MACHINE_LOCATIONID = " & Locationid & " AND MACHINE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "MACHINE_NO"
                cmbmachineno.DataSource = DT
                cmbmachineno.DisplayMember = "MACHINE_NO"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtactqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtactqty.KeyPress
        numdot(e, txtactqty, Me)
    End Sub

    Private Sub TXTACTRATE_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTACTRATE.KeyPress
        numdot(e, TXTACTRATE, Me)
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

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
        Try
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

                temprow = e.RowIndex
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDIFF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDIFF.Validated
        Try
            If cmbcolor.Text.Trim <> "" And Val(TXTPCS.Text.Trim) > 0 And Val(txtmtrs.Text.Trim) > 0 And cmbpiecetype.Text.Trim <> "" Then
                If Val(TXTRECDPCS.Text) > Val(TXTPCS.Text) Or Val(txtrecsaree.Text) > Val(txtinsaree.Text) Then
                    MsgBox("Pcs Or Saree is Greater than Recd Pcs")
                    Exit Sub
                End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
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

            If GRIDMFG.RowCount > 0 Then

                COPY = True
                For Each ROW As DataGridViewRow In GRIDMFG.SelectedRows
                    TXTITEMSRNO.Text = GRIDMFG.RowCount + 1
                    cmbpiecetype.Text = ROW.Cells(GPIECETYPE.Index).Value.ToString
                    TXTGRIDREMARKS.Text = ROW.Cells(gdesc.Index).Value.ToString
                    cmbcolor.Text = ROW.Cells(GCOLOR.Index).Value.ToString
                    TXTPCS.Text = ROW.Cells(GPCS.Index).Value.ToString
                    txtmtrs.Text = ROW.Cells(GMTRS.Index).Value.ToString
                    txtinsaree.Text = ROW.Cells(ginsaree.Index).Value.ToString
                    txtrecsaree.Text = ROW.Cells(grecsaree.Index).Value.ToString
                    TXTRECDPCS.Text = ROW.Cells(GRECDPCS.Index).Value.ToString
                    TXTRECDMTRS.Text = ROW.Cells(GRECDMTRS.Index).Value.ToString
                    txtcolwt.Text = ROW.Cells(gcolorwt.Index).Value.ToString

                    TXTCUTTINGNO.Text = ROW.Cells(GCUTTINGNO.Index).Value
                    TXTCUTTINGSRNO.Text = ROW.Cells(GCUTTINGSRNO.Index).Value
                    TXTGRIDMFGNO.Text = ROW.Cells(GMFGNO.Index).Value
                    TXTMFGSRNO.Text = ROW.Cells(GMFGSRNO.Index).Value
                    TXTGRIDLOTNO.Text = ROW.Cells(GLOTNO.Index).Value
                    TXTLOTSRNO.Text = Val(ROW.Cells(GLOTSRNO.Index).Value.ToString)
                    TXTTYPE.Text = Val(ROW.Cells(GTYPE.Index).Value.ToString)
                    temprow = ROW.Index
                    TXTRECDPCS.Focus()
                Next

                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Validated
        Try
            If CMBFROM.Text.Trim <> "" Then CMBFROM.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtinsaree_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtinsaree.Validating

        txtrecsaree.Text = Val(txtinsaree.Text)
        'txtmtrs.Text = Format(Val(TXTCUT.Text) * Val(txtinsaree.Text), "0.00")
        'TXTRECDMTRS.Text = Format(Val(TXTCUT.Text) * Val(txtinsaree.Text), "0.00")

    End Sub

    Private Sub txtrecsaree_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrecsaree.Validating
        If Val(txtrecsaree.Text) <> 0 And COPY = True Then
            TXTRECDMTRS.Text = Format(Val(TXTCUT.Text) * Val(txtrecsaree.Text), "0.00")
        End If
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

    Private Sub GRIDMFG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMFG.CellClick
        If GRIDMFG.Rows.Count > 0 Then
            GRIDCOLORWT.RowCount = 0

            For i As Integer = 0 To dt_colorwt.Rows.Count - 1
                If dt_colorwt.Rows(i).Item(0) = GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(0).Value Then
                    GRIDCOLORWT.Rows.Add(dt_colorwt.Rows(i).Item(1), dt_colorwt.Rows(i).Item(2), dt_colorwt.Rows(i).Item(3), dt_colorwt.Rows(i).Item(4), dt_colorwt.Rows(i).Item(0))
                End If
            Next
            If dt_colorwt.Rows.Count = 0 Then
                Dim dt As New DataTable
                Dim dt1 As New DataTable
                Dim OBJCMN As New ClsCommon
                For Each row As DataGridViewRow In GRIDMFG.Rows
                    dt = OBJCMN.search("   SCREENMASTER.SCREEN_name, DESIGNRECIPE_DESC.DESIGN_SHADE ", "", "  DESIGNRECIPE INNER JOIN DESIGNRECIPE_DESC ON DESIGNRECIPE.DESIGN_ID = DESIGNRECIPE_DESC.DESIGN_ID AND DESIGNRECIPE.DESIGN_CMPID = DESIGNRECIPE_DESC.DESIGN_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = COLORMASTER.COLOR_yearid INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = SCREENMASTER.SCREEN_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = SCREENMASTER.SCREEN_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = SCREENMASTER.SCREEN_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            dt_colorwt.Rows.Add(row.Cells(gsrno.Index).Value, i + 1, dt.Rows(i).Item(0), dt.Rows(i).Item(1), 0)
                            dt1 = OBJCMN.search(" dbo.ITEMMASTER.item_name AS ITEM, dbo.DESIGNRECIPE_DESC.DESIGN_PERCENT AS [PERCENT], dbo.DESIGNRECIPE_DESC.DESIGN_TOTALPART AS TOTALPART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_PART AS PART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_RATE AS RATE, 0 AS TOTALWT, 0 AS WT ", "", "      dbo.DESIGNRECIPE INNER JOIN dbo.DESIGNRECIPE_DESC ON dbo.DESIGNRECIPE.DESIGN_ID = dbo.DESIGNRECIPE_DESC.DESIGN_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.DESIGNRECIPE_DESC.DESIGN_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN dbo.COLORMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_MATCHINGID = dbo.COLORMASTER.COLOR_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.COLORMASTER.COLOR_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.COLORMASTER.COLOR_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.COLORMASTER.COLOR_yearid INNER JOIN dbo.DESIGNRECIPE_CONSUMPTION ON dbo.DESIGNRECIPE_DESC.DESIGN_ID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ID AND dbo.DESIGNRECIPE_DESC.DESIGN_SRNO = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID INNER JOIN dbo.ITEMMASTER ON dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = dbo.ITEMMASTER.item_id AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = dbo.ITEMMASTER.item_cmpid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = dbo.ITEMMASTER.item_locationid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = dbo.ITEMMASTER.item_yearid LEFT OUTER JOIN dbo.ITEMMASTER AS ITEMMASTER_1 ON dbo.DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER_1.item_id AND dbo.DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER_1.item_cmpid AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER_1.item_locationid AND dbo.DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN dbo.PROCESSMASTER ON dbo.DESIGNRECIPE.DESIGN_PROCESSID = dbo.PROCESSMASTER.PROCESS_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.PROCESSMASTER.PROCESS_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.PROCESSMASTER.PROCESS_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN dbo.SCREENMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_SCREENID = dbo.SCREENMASTER.SCREEN_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.SCREENMASTER.SCREEN_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.SCREENMASTER.SCREEN_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.SCREENMASTER.SCREEN_yearid ", " AND itemmaster_1.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' and SCREENMASTER.SCREEN_name='" & dt.Rows(i).Item(0) & "'  AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId)
                            If dt1.Rows.Count > 0 Then
                                For j As Integer = 0 To dt1.Rows.Count - 1
                                    dt_CONSUMPTION.Rows.Add(Convert.ToDecimal(row.Cells(gsrno.Index).Value), i + 1, dt1.Rows(j).Item("item"), Val(dt1.Rows(j).Item("percent")), Val(dt1.Rows(j).Item("TOTALPART")), Val(dt1.Rows(j).Item("PART")), Val(dt1.Rows(j).Item("RATE")), Val(dt1.Rows(j).Item("TOTALWT")), Val(dt1.Rows(j).Item("WT")))
                                Next
                            End If
                        Next
                    End If
                Next
                TOTALCONSUMPTION()
            End If
        End If
    End Sub

    Private Sub GRIDCOLORWT_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDCOLORWT.CellValidating
        Try
            Dim colNum As Integer = GRIDCOLORWT.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gwt.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    GRIDCONSUMPTION.RowCount = 0
                    If bValid Then
                        If GRIDCOLORWT.CurrentCell.Value = Nothing Then GRIDCOLORWT.CurrentCell.Value = "0.00"
                        GRIDCOLORWT.CurrentCell.Value = Convert.ToDecimal(GRIDCOLORWT.Item(colNum, e.RowIndex).Value)
                        For I As Integer = 0 To dt_colorwt.Rows.Count - 1
                            If GRIDCOLORWT.Rows(e.RowIndex).Cells(4).Value = dt_colorwt.Rows(I).Item(0) And GRIDCOLORWT.Rows(e.RowIndex).Cells(0).Value = dt_colorwt.Rows(I).Item(1) Then
                                dt_colorwt.Rows(I).Item(4) = GRIDCOLORWT.Rows(e.RowIndex).Cells(gwt.Index).EditedFormattedValue
                                For j As Integer = 0 To dt_CONSUMPTION.Rows.Count - 1
                                    If GRIDCOLORWT.Rows(e.RowIndex).Cells(4).Value = dt_CONSUMPTION.Rows(j).Item(0) And GRIDCOLORWT.Rows(e.RowIndex).Cells(0).Value = dt_CONSUMPTION.Rows(j).Item(1) Then
                                        dt_CONSUMPTION.Rows(j).Item("totalwt1") = GRIDCOLORWT.Rows(e.RowIndex).Cells(gwt.Index).EditedFormattedValue
                                        If dt_CONSUMPTION.Rows(j).Item("part1") <> 0 And dt_CONSUMPTION.Rows(j).Item("percent1") <> 0 And (dt_CONSUMPTION.Rows(j).Item("totalwt1")) <> 0 And dt_CONSUMPTION.Rows(j).Item("totalpart1") <> 0 Then
                                            dt_CONSUMPTION.Rows(j).Item("wt1") = (dt_CONSUMPTION.Rows(j).Item("totalwt1") * dt_CONSUMPTION.Rows(j).Item("percent1") * dt_CONSUMPTION.Rows(j).Item("part1")) / (100 * dt_CONSUMPTION.Rows(j).Item("totalpart1"))
                                        ElseIf (dt_CONSUMPTION.Rows(j).Item("totalwt1")) <> 0 And dt_CONSUMPTION.Rows(j).Item("percent1") <> 0 Then
                                            dt_CONSUMPTION.Rows(j).Item("wt1") = dt_CONSUMPTION.Rows(j).Item("totalwt1") - (dt_CONSUMPTION.Rows(j).Item("totalwt1") * dt_CONSUMPTION.Rows(j).Item("percent1") / 100)
                                        End If
                                    End If
                                Next
                            End If
                        Next
                        If dt_CONSUMPTION.Rows.Count > 0 Then
                            For j As Integer = 0 To dt_CONSUMPTION.Rows.Count - 1
                                GRIDCONSUMPTION.Rows.Add(0, dt_CONSUMPTION.Rows(j).Item("itemname1"), dt_CONSUMPTION.Rows(j).Item("wt1"), dt_CONSUMPTION.Rows(j).Item("wt1"), "KGS", dt_CONSUMPTION.Rows(j).Item("rate1"), dt_CONSUMPTION.Rows(j).Item("rate1"), Val(dt_CONSUMPTION.Rows(j).Item("wt1")) * Val(dt_CONSUMPTION.Rows(j).Item("rate1")), Val(dt_CONSUMPTION.Rows(j).Item("wt1")) * Val(dt_CONSUMPTION.Rows(j).Item("rate1")), dt_CONSUMPTION.Rows(j).Item("SRNO1"), dt_CONSUMPTION.Rows(j).Item("COLSRNO1"))
                            Next
                        End If
                        If GRIDMFG.RowCount > 0 Then
                            GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(gcolorwt.Index).Value = dt_colorwt.Compute(" sum([wt])", " srno =" & GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(0).Value)
                            getsrno(GRIDCONSUMPTION)
                            TOTAL()
                            TOTALCONSUMPTION()
                        End If


                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case GCOLWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)
                    GRIDCONSUMPTION.RowCount = 0
                    If bValid Then
                        If GRIDCOLORWT.CurrentCell.Value = Nothing Then GRIDCOLORWT.CurrentCell.Value = "0.00"
                        GRIDCOLORWT.CurrentCell.Value = Convert.ToDecimal(GRIDCOLORWT.Item(colNum, e.RowIndex).Value)
                        If GRIDMFG.Rows.Count > 0 Then GRIDCOLORWT.Item(gwt.Index, e.RowIndex).Value = Format((Val(GRIDCOLORWT.Item(GCOLWT.Index, e.RowIndex).EditedFormattedValue) / Val(TXTPCSFORCALC.Text.Trim)) * Val(GRIDMFG.Item(GPCS.Index, GRIDCOLORWT.Rows(e.RowIndex).Cells(gmainsrno.Index).Value - 1).Value), "0.000")
                        For I As Integer = 0 To dt_colorwt.Rows.Count - 1
                            If GRIDCOLORWT.Rows(e.RowIndex).Cells(4).Value = dt_colorwt.Rows(I).Item(0) And GRIDCOLORWT.Rows(e.RowIndex).Cells(0).Value = dt_colorwt.Rows(I).Item(1) Then
                                dt_colorwt.Rows(I).Item(4) = GRIDCOLORWT.Rows(e.RowIndex).Cells(gwt.Index).EditedFormattedValue
                                For j As Integer = 0 To dt_CONSUMPTION.Rows.Count - 1
                                    If GRIDCOLORWT.Rows(e.RowIndex).Cells(4).Value = dt_CONSUMPTION.Rows(j).Item(0) And GRIDCOLORWT.Rows(e.RowIndex).Cells(0).Value = dt_CONSUMPTION.Rows(j).Item(1) Then
                                        dt_CONSUMPTION.Rows(j).Item("totalwt1") = GRIDCOLORWT.Rows(e.RowIndex).Cells(gwt.Index).EditedFormattedValue
                                        If dt_CONSUMPTION.Rows(j).Item("part1") <> 0 And dt_CONSUMPTION.Rows(j).Item("percent1") <> 0 And (dt_CONSUMPTION.Rows(j).Item("totalwt1")) <> 0 And dt_CONSUMPTION.Rows(j).Item("totalpart1") <> 0 Then
                                            dt_CONSUMPTION.Rows(j).Item("wt1") = (dt_CONSUMPTION.Rows(j).Item("totalwt1") * dt_CONSUMPTION.Rows(j).Item("percent1") * dt_CONSUMPTION.Rows(j).Item("part1")) / (100 * dt_CONSUMPTION.Rows(j).Item("totalpart1"))
                                        ElseIf (dt_CONSUMPTION.Rows(j).Item("totalwt1")) <> 0 And dt_CONSUMPTION.Rows(j).Item("percent1") <> 0 Then
                                            dt_CONSUMPTION.Rows(j).Item("wt1") = dt_CONSUMPTION.Rows(j).Item("totalwt1") - (dt_CONSUMPTION.Rows(j).Item("totalwt1") * dt_CONSUMPTION.Rows(j).Item("percent1") / 100)
                                        End If
                                    End If
                                Next
                            End If
                        Next
                        If dt_CONSUMPTION.Rows.Count > 0 Then
                            For j As Integer = 0 To dt_CONSUMPTION.Rows.Count - 1
                                GRIDCONSUMPTION.Rows.Add(0, dt_CONSUMPTION.Rows(j).Item("itemname1"), dt_CONSUMPTION.Rows(j).Item("wt1"), dt_CONSUMPTION.Rows(j).Item("wt1"), "KGS", dt_CONSUMPTION.Rows(j).Item("rate1"), dt_CONSUMPTION.Rows(j).Item("rate1"), Val(dt_CONSUMPTION.Rows(j).Item("wt1")) * Val(dt_CONSUMPTION.Rows(j).Item("rate1")), Val(dt_CONSUMPTION.Rows(j).Item("wt1")) * Val(dt_CONSUMPTION.Rows(j).Item("rate1")), dt_CONSUMPTION.Rows(j).Item("SRNO1"), dt_CONSUMPTION.Rows(j).Item("COLSRNO1"))
                            Next
                        End If
                        If GRIDMFG.RowCount > 0 Then
                            GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(gcolorwt.Index).Value = dt_colorwt.Compute(" sum([wt])", " srno ='" & Val(GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(0).Value) & "'")
                            getsrno(GRIDCONSUMPTION)
                            TOTAL()
                            TOTALCONSUMPTION()
                        End If
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

    Private Sub TXTEXTRAAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTEXTRAAMT.Validated
        Try
            If cmbextra.Text.Trim <> "" Then

                'CHECK WHETHER ITEM IS PRESENT IN GRID BELOW OR NOT
                For Each ROW As DataGridViewRow In GRIDEXTRA.Rows
                    If (LCase(ROW.Cells(gextraName.Index).Value) = LCase(cmbextra.Text.Trim) And gridEXTRADoubleClick = False) Or (LCase(ROW.Cells(gextraName.Index).Value) = LCase(cmbextra.Text.Trim) And gridEXTRADoubleClick = True And temprow <> ROW.Index) Then
                        MsgBox("Item Already Present in Grid Below", MsgBoxStyle.Critical)
                        cmbextra.Focus()
                        Exit Sub
                    End If
                Next

                fillEXTRAgrid()
                TOTAL()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                txtExtrasrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txthelpername_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthelpername.Validated
        Try
            If cmbdesignation.Text.Trim <> "" Then

                'CHECK WHETHER ITEM IS PRESENT IN GRID BELOW OR NOT
                For Each ROW As DataGridViewRow In gridhelper.Rows
                    If (LCase(ROW.Cells(gdesignation.Index).Value) = LCase(cmbdesignation.Text.Trim) And gridDoubleClick = False) Or (LCase(ROW.Cells(gdesignation.Index).Value) = LCase(cmbdesignation.Text.Trim) And gridDoubleClick = True And temprow <> ROW.Index) Then
                        MsgBox("Item Already Present in Grid Below", MsgBoxStyle.Critical)
                        cmbdesignation.Focus()
                        Exit Sub
                    End If
                Next

                fillHELPERSgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                txthsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillHELPERSgrid()

        If gridDoubleClick = False Then
            gridhelper.Rows.Add(Val(txthsrno.Text.Trim), cmbdesignation.Text.Trim, Format(Val(txthelpers.Text.Trim), "0"), txthelpername.Text.Trim)
            getsrno(gridhelper)
        ElseIf gridDoubleClick = True Then
            gridhelper.Item(GHSRNO.Index, temprow).Value = Val(txthsrno.Text.Trim)
            gridhelper.Item(gdesignation.Index, temprow).Value = cmbdesignation.Text.Trim
            gridhelper.Item(ghelpers.Index, temprow).Value = Format(Val(txthelpers.Text.Trim), "0")
            gridhelper.Item(gHelperName.Index, temprow).Value = txthelpername.Text.Trim

            gridDoubleClick = False
        End If

        gridhelper.FirstDisplayedScrollingRowIndex = gridhelper.RowCount - 1
        If gridDoubleClick = False Then
            If gridhelper.RowCount > 0 Then
                txthsrno.Text = Val(gridhelper.Rows(gridhelper.RowCount - 1).Cells(GHSRNO.Index).Value) + 1
            Else
                txthsrno.Text = 1
            End If
        End If

        cmbdesignation.Text = ""
        txthelpername.Clear()
        txthelpers.Clear()
        txthsrno.Focus()

    End Sub

    Sub fillEXTRAgrid()

        If gridEXTRADoubleClick = False Then
            GRIDEXTRA.Rows.Add(Val(txtExtrasrno.Text.Trim), cmbextra.Text.Trim, cmbrateon.Text.Trim, Format(Val(txtExtraRate.Text.Trim), "0.000"), TXTEXTRAAMT.Text.Trim)
            getsrno(GRIDEXTRA)
        ElseIf gridEXTRADoubleClick = True Then
            GRIDEXTRA.Item(gextrasrno.Index, temprow).Value = Val(txtExtrasrno.Text.Trim)
            GRIDEXTRA.Item(gextraName.Index, temprow).Value = cmbextra.Text.Trim
            GRIDEXTRA.Item(GRATEON.Index, temprow).Value = cmbrateon.Text.Trim
            GRIDEXTRA.Item(gextraRate.Index, temprow).Value = Format(Val(txtExtraRate.Text.Trim), "0.000")
            GRIDEXTRA.Item(gExtraAmt.Index, temprow).Value = TXTEXTRAAMT.Text.Trim

            gridEXTRADoubleClick = False
        End If

        GRIDEXTRA.FirstDisplayedScrollingRowIndex = GRIDEXTRA.RowCount - 1
        If gridDoubleClick = False Then
            If GRIDEXTRA.RowCount > 0 Then
                txtExtrasrno.Text = Val(GRIDEXTRA.Rows(GRIDEXTRA.RowCount - 1).Cells(gextrasrno.Index).Value) + 1
            Else
                txtExtrasrno.Text = 1
            End If
        End If

        cmbextra.Text = ""
        TXTEXTRAAMT.Clear()
        cmbrateon.Text = ""
        txtExtraRate.Clear()
        txtExtrasrno.Focus()

    End Sub


    Private Sub CMBdesignation_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesignation.GotFocus
        Try
            If cmbdesignation.Text.Trim = "" Then filldesignation(cmbdesignation)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBdesignation_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesignation.Validating
        Try
            If cmbdesignation.Text.Trim <> "" Then designationvalidate(cmbdesignation, e, Me)
            cmbcolor.Text = ""
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txthelpers_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthelpers.KeyPress, TXTWORKER.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTEXTRARATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtExtraRate.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub gridhelper_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridhelper.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridhelper.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                gridhelper.Rows.RemoveAt(gridhelper.CurrentRow.Index)
                getsrno(gridhelper)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDEXTRA_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDEXTRA.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDEXTRA.Item(gextrasrno.Index, e.RowIndex).Value <> Nothing Then

                gridEXTRADoubleClick = True
                txtExtrasrno.Text = GRIDEXTRA.Item(gextrasrno.Index, e.RowIndex).Value.ToString
                cmbextra.Text = GRIDEXTRA.Item(gextraName.Index, e.RowIndex).Value.ToString
                cmbrateon.Text = GRIDEXTRA.Item(GRATEON.Index, e.RowIndex).Value.ToString
                txtExtraRate.Text = GRIDEXTRA.Item(gextraRate.Index, e.RowIndex).Value.ToString
                TXTEXTRAAMT.Text = GRIDEXTRA.Item(gExtraAmt.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                txtExtrasrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridEXTRA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDEXTRA.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDEXTRA.RowCount > 0 Then
                If gridEXTRADoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDEXTRA.Rows.RemoveAt(GRIDEXTRA.CurrentRow.Index)
                getsrno(GRIDEXTRA)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub TXTPCS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPCS.Validating
        TXTRECDPCS.Text = TXTPCS.Text
    End Sub

    Private Sub cmbshift_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbshift.Validating

        If cmbshift.Text = "Day" Then
            INTIME.Value = Now.Date & " 08:01:00 AM"
            OUTTIME.Value = Now.Date & " 07:59:00 PM"
        Else
            INTIME.Value = Now.Date & " 08:01:00 PM"
            OUTTIME.Value = Now.Date & " 07:59:00 AM"
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then

                'serverprop()
                Dim OBJGRN As New mfgdesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.frmstring = "MFG2"
                OBJGRN.selfor_po = "{MFGMASTER2.MFG_NO}=" & TEMPMFGNO & " and {MFGMASTER2.MFG_cmpid}=" & CmpId & " and {MFGMASTER2.MFG_locationid}=" & Locationid & " and {MFGMASTER2.MFG_yearid}=" & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbCOLORRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbCOLORRATE.Validating
        Try
            If TXTDESIGN.Text.Trim <> "" Then
                Dim DT As DataTable
                Dim OBJCMN As New ClsCommon
                DT = OBJCMN.search("   COLORRATEMASTER.CR_RATE AS COLBILLRATE ", "", " COLORRATEMASTER ", " AND COLORRATEMASTER.CR_NO=" & cmbCOLORRATE.Text & "  AND COLORRATEMASTER.CR_CMPID = " & CmpId & " AND COLORRATEMASTER.CR_LOCATIONID  = " & Locationid & " AND  COLORRATEMASTER.CR_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    txtcolorrate.Text = DT.Rows(0).Item(0)
                    txtcoloramt.Text = Val(txtcolorrate.Text) * Val(LBLTOTALRECDMTRS.Text.Trim)
                Else
                    txtcolorrate.Text = 0
                    txtcoloramt.Text = 0
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbextra_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbextra.Validating
        Try
            If cmbextra.Text.Trim <> "" Then
                Dim DT As DataTable
                Dim OBJCMN As New ClsCommon
                DT = OBJCMN.search("   EXTRAMASTER.EXTRA_RATE AS RATE,EXTRAMASTER.EXTRA_RATEON ", "", "      EXTRAMASTER ", " AND EXTRAMASTER.EXTRA_NAME='" & cmbextra.Text.Trim & "'  AND EXTRAMASTER.EXTRA_CMPID = " & CmpId & " AND EXTRAMASTER.EXTRA_LOCATIONID  = " & Locationid & " AND  EXTRAMASTER.EXTRA_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbrateon.Text = DT.Rows(0).Item(1)
                    txtExtraRate.Text = DT.Rows(0).Item(0)
                    If DT.Rows(0).Item(1) = "MTRS" Then
                        TXTEXTRAAMT.Text = Val(txtExtraRate.Text) * Val(LBLTOTALRECDMTRS.Text.Trim)
                    Else
                        TXTEXTRAAMT.Text = Val(txtExtraRate.Text) * Val(LBLTOTALRECDSAREE.Text.Trim)
                    End If
                Else
                    txtExtraRate.Text = 0
                    TXTEXTRAAMT.Text = 0
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtExtraRate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtExtraRate.Validating
        Try
            If Val(txtExtraRate.Text.Trim) > 0 Then
                If cmbrateon.Text = "MTRS" Then
                    If Val(LBLTOTALRECDMTRS.Text) <> 0 Then
                        TXTEXTRAAMT.Text = Val(LBLTOTALRECDMTRS.Text) * Val(txtExtraRate.Text.Trim)
                    Else
                        TXTEXTRAAMT.Text = Val(LBLTOTALRECDSAREE.Text) * Val(txtExtraRate.Text.Trim)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim OBJCMN As New ClsCommon
        dt_CONSUMPTION.Rows.Clear()
        dt_colorwt.Rows.Clear()
        For Each row As DataGridViewRow In GRIDMFG.Rows
            dt = OBJCMN.search("   SCREENMASTER.SCREEN_name, DESIGNRECIPE_DESC.DESIGN_SHADE ", "", "  DESIGNRECIPE LEFT OUTER JOIN DESIGNRECIPE_DESC ON DESIGNRECIPE.DESIGN_ID = DESIGNRECIPE_DESC.DESIGN_ID AND DESIGNRECIPE.DESIGN_CMPID = DESIGNRECIPE_DESC.DESIGN_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = COLORMASTER.COLOR_yearid INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID AND DESIGNRECIPE.DESIGN_CMPID = PROCESSMASTER.PROCESS_CMPID AND DESIGNRECIPE.DESIGN_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DESIGNRECIPE.DESIGN_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id AND DESIGNRECIPE_DESC.DESIGN_CMPID = SCREENMASTER.SCREEN_cmpid AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = SCREENMASTER.SCREEN_locationid AND DESIGNRECIPE_DESC.DESIGN_YEARID = SCREENMASTER.SCREEN_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " ORDER BY SCREENMASTER.SCREEN_name")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt_colorwt.Rows.Add(row.Cells(gsrno.Index).Value, i + 1, dt.Rows(i).Item(0), dt.Rows(i).Item(1), 0)
                    If row.Cells(gsrno.Index).Value = 2 Then
                        MsgBox("")
                    End If
                    dt1 = OBJCMN.search(" dbo.ITEMMASTER.item_name AS ITEM, dbo.DESIGNRECIPE_DESC.DESIGN_PERCENT AS [PERCENT], dbo.DESIGNRECIPE_DESC.DESIGN_TOTALPART AS TOTALPART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_PART AS PART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_RATE AS RATE, 0 AS TOTALWT, 0 AS WT ", "", "      dbo.DESIGNRECIPE INNER JOIN dbo.DESIGNRECIPE_DESC ON dbo.DESIGNRECIPE.DESIGN_ID = dbo.DESIGNRECIPE_DESC.DESIGN_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.DESIGNRECIPE_DESC.DESIGN_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN dbo.COLORMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_MATCHINGID = dbo.COLORMASTER.COLOR_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.COLORMASTER.COLOR_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.COLORMASTER.COLOR_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.COLORMASTER.COLOR_yearid LEFT OUTER JOIN dbo.DESIGNRECIPE_CONSUMPTION ON dbo.DESIGNRECIPE_DESC.DESIGN_ID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ID AND dbo.DESIGNRECIPE_DESC.DESIGN_SRNO = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID INNER JOIN dbo.ITEMMASTER ON dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = dbo.ITEMMASTER.item_id AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = dbo.ITEMMASTER.item_cmpid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = dbo.ITEMMASTER.item_locationid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = dbo.ITEMMASTER.item_yearid LEFT OUTER JOIN dbo.ITEMMASTER AS ITEMMASTER_1 ON dbo.DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER_1.item_id AND dbo.DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER_1.item_cmpid AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER_1.item_locationid AND dbo.DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN dbo.PROCESSMASTER ON dbo.DESIGNRECIPE.DESIGN_PROCESSID = dbo.PROCESSMASTER.PROCESS_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.PROCESSMASTER.PROCESS_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.PROCESSMASTER.PROCESS_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN dbo.SCREENMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_SCREENID = dbo.SCREENMASTER.SCREEN_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.SCREENMASTER.SCREEN_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.SCREENMASTER.SCREEN_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.SCREENMASTER.SCREEN_yearid ", " AND itemmaster_1.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' and SCREENMASTER.SCREEN_name='" & dt.Rows(i).Item(0) & "'  AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        For j As Integer = 0 To dt1.Rows.Count - 1
                            dt_CONSUMPTION.Rows.Add(Convert.ToDecimal(row.Cells(gsrno.Index).Value), i + 1, dt1.Rows(j).Item("item"), Val(dt1.Rows(j).Item("percent")), Val(dt1.Rows(j).Item("TOTALPART")), Val(dt1.Rows(j).Item("PART")), Val(dt1.Rows(j).Item("RATE")), Val(dt1.Rows(j).Item("TOTALWT")), Val(dt1.Rows(j).Item("WT")))
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub CMBDYEING_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDYEING.Validating
        Try
            If CMBDYEING.Text.Trim <> "" Then dyeingvalidate(CMBDYEING, e, Me)
            CMBCLR.Text = ""
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDYEING.Validated
        If CMBDYEING.Text <> "" Then CMBDYEING.Enabled = False
    End Sub

    Private Sub CMBCLR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCLR.GotFocus
        Try
            If CMBCLR.Text.Trim = "" Then fillCOLOR(CMBCLR, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID ", " AND DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCLR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCLR.Validating
        Try
            If CMBCLR.Text.Trim <> "" Then COLORvalidate(CMBCLR, e, Me, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID", " AND  DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")


            If CMBCLR.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" And CMBTO.Text.Trim = "MFG2 DYEING" Then
                Dim dttable As New DataTable
                Dim OBJCMN As New ClsCommon
                GRIDCONSUMPTION.RowCount = 0
                dttable = OBJCMN.search("  ITEMMASTER.item_name AS ITEM, DYEINGRECIPE_CONSUMPTION.DYEING_QTY, DYEINGRECIPE_DESC.DYEING_PERPCS, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE ", "", "      DYEINGRECIPE INNER JOIN DYEINGRECIPE_DESC ON DYEINGRECIPE.DYEING_ID = DYEINGRECIPE_DESC.DYEING_ID AND DYEINGRECIPE.DYEING_CMPID = DYEINGRECIPE_DESC.DYEING_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DYEINGRECIPE_CONSUMPTION ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE_CONSUMPTION.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_SRNO = DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE_CONSUMPTION.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE_CONSUMPTION.DYEING_YEARID INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DYEINGRECIPE.DYEING_PROCESSID = PROCESSMASTER.PROCESS_ID AND DYEINGRECIPE.DYEING_CMPID = PROCESSMASTER.PROCESS_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  PROCESSMASTER.PROCESS_NAME = 'DYEING' AND COLORMASTER.COLOR_name ='" & CMBCLR.Text.Trim & "' AND dyeingRECIPE.dyeing_NO ='" & CMBDYEING.Text & "' AND dyeingRECIPE.dyeing_CMPID =" & CmpId & " AND dyeingRECIPE.dyeing_LOCATIONID =" & Locationid & " AND dyeingRECIPE.dyeing_YEARID =" & YearId)
                If dttable.Rows.Count > 0 Then
                    For j As Integer = 0 To dttable.Rows.Count - 1
                        GRIDCONSUMPTION.Rows.Add(0, dttable.Rows(j).Item("item"), Format(Val((LBLTOTALPCS.Text) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), "0.00"), Format(Val(dttable.Rows(j).Item("DYEING_QTY")), "0.000"), "KGS", Val(dttable.Rows(j).Item("RATE")), Val(dttable.Rows(j).Item("RATE")), 0, 0, 0, 0)
                    Next
                End If
                getsrno(GRIDCONSUMPTION)
                TOTALCONSUMPTION()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            'GET THE IMAGE FROM DESIGNRECIPE 
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("DESIGN_LOGO AS LOGO", "", "DESIGNRECIPE", " AND DESIGN_NO = '" & TXTDESIGN.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If IsDBNull(DT.Rows(0).Item("LOGO")) = False Then
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = Image.FromStream(New IO.MemoryStream(DirectCast(DT.Rows(0).Item("LOGO"), Byte())))
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKDESIGNNO_CheckedChanged(sender As Object, e As EventArgs) Handles CHKCHANGEDESIGNNO.CheckedChanged
        Try
            TXTDESIGN.ReadOnly = Not CHKCHANGEDESIGNNO.Checked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Mfg2_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If UserName = "Admin" Then CMBGODOWN.Enabled = True
    End Sub

    Private Sub CHKCHANGEMERCHANT_CheckedChanged(sender As Object, e As EventArgs) Handles CHKCHANGEMERCHANT.CheckedChanged
        Try
            TXTMERCHANT.ReadOnly = Not CHKCHANGEMERCHANT.Checked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDESIGN_Validating(sender As Object, e As CancelEventArgs) Handles TXTDESIGN.Validating
        Try
            If TXTDESIGN.Text.Trim <> "" And CHKCHANGEDESIGNNO.Checked = True Then
                dt_CONSUMPTION.Clear()
                dt_colorwt.Clear()
                getsrno(GRIDMFG)
                Dim dt As New DataTable
                Dim dt1 As New DataTable
                Dim OBJCMN As New ClsCommon
                For Each row As DataGridViewRow In GRIDMFG.Rows
                    dt = OBJCMN.search(" SCREENMASTER.SCREEN_name, DESIGNRECIPE_DESC.DESIGN_SHADE ", "", "  DESIGNRECIPE INNER JOIN DESIGNRECIPE_DESC ON DESIGNRECIPE.DESIGN_ID = DESIGNRECIPE_DESC.DESIGN_ID AND DESIGNRECIPE.DESIGN_YEARID = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN COLORMASTER ON DESIGNRECIPE_DESC.DESIGN_MATCHINGID = COLORMASTER.COLOR_id INNER JOIN PROCESSMASTER ON DESIGNRECIPE.DESIGN_PROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id INNER JOIN SCREENMASTER ON DESIGNRECIPE_DESC.DESIGN_SCREENID = SCREENMASTER.SCREEN_id ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " order BY DESIGNRECIPE_DESC.DESIGN_SRNO")
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            dt_colorwt.Rows.Add(row.Cells(gsrno.Index).Value, i + 1, dt.Rows(i).Item(0), dt.Rows(i).Item(1), 0)
                            dt1 = OBJCMN.search(" dbo.ITEMMASTER.item_name AS ITEM, dbo.DESIGNRECIPE_DESC.DESIGN_PERCENT AS [PERCENT], dbo.DESIGNRECIPE_DESC.DESIGN_TOTALPART AS TOTALPART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_PART AS PART, dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_RATE AS RATE, 0 AS TOTALWT, 0 AS WT ", "", "      dbo.DESIGNRECIPE INNER JOIN dbo.DESIGNRECIPE_DESC ON dbo.DESIGNRECIPE.DESIGN_ID = dbo.DESIGNRECIPE_DESC.DESIGN_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.DESIGNRECIPE_DESC.DESIGN_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN dbo.COLORMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_MATCHINGID = dbo.COLORMASTER.COLOR_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.COLORMASTER.COLOR_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.COLORMASTER.COLOR_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.COLORMASTER.COLOR_yearid INNER JOIN dbo.DESIGNRECIPE_CONSUMPTION ON dbo.DESIGNRECIPE_DESC.DESIGN_ID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ID AND dbo.DESIGNRECIPE_DESC.DESIGN_SRNO = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID INNER JOIN dbo.ITEMMASTER ON dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = dbo.ITEMMASTER.item_id AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = dbo.ITEMMASTER.item_cmpid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = dbo.ITEMMASTER.item_locationid AND dbo.DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = dbo.ITEMMASTER.item_yearid LEFT OUTER JOIN dbo.ITEMMASTER AS ITEMMASTER_1 ON dbo.DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER_1.item_id AND dbo.DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER_1.item_cmpid AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER_1.item_locationid AND dbo.DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN dbo.PROCESSMASTER ON dbo.DESIGNRECIPE.DESIGN_PROCESSID = dbo.PROCESSMASTER.PROCESS_ID AND dbo.DESIGNRECIPE.DESIGN_CMPID = dbo.PROCESSMASTER.PROCESS_CMPID AND dbo.DESIGNRECIPE.DESIGN_LOCATIONID = dbo.PROCESSMASTER.PROCESS_LOCATIONID AND dbo.DESIGNRECIPE.DESIGN_YEARID = dbo.PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN dbo.SCREENMASTER ON dbo.DESIGNRECIPE_DESC.DESIGN_SCREENID = dbo.SCREENMASTER.SCREEN_id AND dbo.DESIGNRECIPE_DESC.DESIGN_CMPID = dbo.SCREENMASTER.SCREEN_cmpid AND dbo.DESIGNRECIPE_DESC.DESIGN_LOCATIONID = dbo.SCREENMASTER.SCREEN_locationid AND dbo.DESIGNRECIPE_DESC.DESIGN_YEARID = dbo.SCREENMASTER.SCREEN_yearid ", " AND itemmaster_1.item_name = '" & TXTMERCHANT.Text.Trim & "' AND processmaster.process_name = '" & CMBTO.Text.Trim & "' AND colormaster.color_name = '" & row.Cells(GCOLOR.Index).Value & "' AND DESIGNRECIPE.DESIGN_NO='" & TXTDESIGN.Text.Trim & "' and SCREENMASTER.SCREEN_name='" & dt.Rows(i).Item(0) & "'  AND DESIGNRECIPE.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " ORDER BY DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO")
                            If dt1.Rows.Count > 0 Then
                                For j As Integer = 0 To dt1.Rows.Count - 1
                                    dt_CONSUMPTION.Rows.Add(Convert.ToDecimal(row.Cells(gsrno.Index).Value), i + 1, dt1.Rows(j).Item("item"), Val(dt1.Rows(j).Item("percent")), Val(dt1.Rows(j).Item("TOTALPART")), Val(dt1.Rows(j).Item("PART")), Val(dt1.Rows(j).Item("RATE")), Val(dt1.Rows(j).Item("TOTALWT")), Val(dt1.Rows(j).Item("WT")))
                                Next
                            End If
                        Next
                    End If
                Next
                If TXTDESIGN.Text.Trim <> "" Then
                    'CHANGES DONE BY GULKIT
                    'dt = OBJCMN.search("   CASE WHEN ISNULL(DESIGN_COLBILL1, 0) > ISNULL(DESIGN_COLBILL2, 0) THEN ISNULL(DESIGN_COLBILL1, 0) ELSE ISNULL(DESIGN_COLBILL2, 0) END AS COLBILL, CASE WHEN ISNULL(DESIGN_COLBILL1, 0) > ISNULL(DESIGN_COLBILL2, 0) THEN ISNULL(COLORRATEMASTER.CR_RATE, 0) ELSE ISNULL(COLORRATEMASTER_1.CR_RATE, 0) END AS COLBILLRATE ", "", "       DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN COLORRATEMASTER ON DESIGNRECIPE.DESIGN_COLBILL1 = COLORRATEMASTER.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER.CR_yearid INNER JOIN COLORRATEMASTER AS COLORRATEMASTER_1 ON DESIGNRECIPE.DESIGN_COLBILL2 = COLORRATEMASTER_1.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER_1.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER_1.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER_1.CR_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID  = " & Locationid & " AND  ITEMMASTER.ITEM_YEARID = " & YearId)
                    dt = OBJCMN.search("   DESIGN_COLBILL1 AS COLBILL, COLORRATEMASTER.CR_RATE AS COLBILLRATE ", "", " DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN COLORRATEMASTER ON DESIGNRECIPE.DESIGN_COLBILL1 = COLORRATEMASTER.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER.CR_yearid INNER JOIN COLORRATEMASTER AS COLORRATEMASTER_1 ON DESIGNRECIPE.DESIGN_COLBILL2 = COLORRATEMASTER_1.CR_NO AND DESIGNRECIPE.DESIGN_CMPID = COLORRATEMASTER_1.CR_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = COLORRATEMASTER_1.CR_locationid AND DESIGNRECIPE.DESIGN_YEARID = COLORRATEMASTER_1.CR_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND DESIGN_NO='" & TXTDESIGN.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID  = " & Locationid & " AND  ITEMMASTER.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        cmbCOLORRATE.Text = dt.Rows(0).Item(0)
                        txtcolorrate.Text = dt.Rows(0).Item(1)
                        txtcoloramt.Text = Val(txtcolorrate.Text) * Val(LBLTOTALRECDMTRS.Text.Trim)
                    Else
                        txtcolorrate.Text = 0
                        txtcoloramt.Text = 0
                    End If
                End If
                If TXTMERCHANT.Text.Trim <> "" Then
                    dt = OBJCMN.search("  ITEMMASTER_RATEDESC.ITEM_RATE ", "", "     ITEMMASTER INNER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID INNER JOIN RATETYPEMASTER ON ITEMMASTER_RATEDESC.ITEM_RATETYPEID = RATETYPEMASTER.RATETYPE_id AND ITEMMASTER_RATEDESC.ITEM_CMPID = RATETYPEMASTER.RATETYPE_cmpid AND ITEMMASTER_RATEDESC.ITEM_LOCATIONID = RATETYPEMASTER.RATETYPE_locationid AND ITEMMASTER_RATEDESC.ITEM_YEARID = RATETYPEMASTER.RATETYPE_yearid ", " AND itemmaster.item_name = '" & TXTMERCHANT.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID  = " & Locationid & " AND RATETYPEMASTER.RATETYPE_NAME='LABOUR RATE' AND  ITEMMASTER.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        txtlabourrate.Text = dt.Rows(0).Item(0)
                    Else
                        txtlabourrate.Text = 0
                        txtlabouramt.Text = 0
                    End If
                End If
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class