
Imports BL

Public Class Mfg

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPMFGNO As Integer     'used for poation no while editing
    Dim temprow As Integer
    Public Shared SELECTGRN As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim a As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        CHKRECD.CheckState = CheckState.Checked
        CMDSELECT.Enabled = True


        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        tstxtbillno.Clear()
        TXTMFGNO.Clear()
        CHKPCS.CheckState = False
        cmbmachineno.DataSource = Nothing
        cmbcontractor.Text = ""
        CMBSUPERVISOR.Text = ""
        CMBDYEING.Text = ""
        CMBCOLOR.Text = ""

        TXTDEGREE.Clear()


        CMBFROM.Text = ""
        CMBTO.Text = ""
        cmbprgno.Text = ""

        CMBMERCHANT.Text = ""
        TXTITEMNAME.Clear()
        TXTCOLOR.Clear()
        TXTQUALITY.Clear()
        TXTREED.Clear()
        TXTPICK.Clear()

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
        txtremarks.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos
        txtsrno.Clear()
        CMBITEMNAME.Text = ""
        txtdefqty.Clear()
        txtactqty.Clear()
        txtdefrate.Clear()
        TXTACTRATE.Clear()
        cmbunit.Text = "KGS"
        GRIDCONSUMPTION.RowCount = 0
        GRIDMFG.RowCount = 0
        GRIDSUMM.RowCount = 0


        CMDSELECT.Enabled = True
        CMBFROM.Enabled = True
        CMBTO.Enabled = True
        gridDoubleClick = False
        getmaxno()


        If GRIDCONSUMPTION.RowCount > 0 Then
            txtsrno.Text = Val(GRIDCONSUMPTION.Rows(GRIDCONSUMPTION.RowCount - 1).Cells(GCONSUMEDSRNO.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        gridhelper.RowCount = 0
        txthsrno.Clear()
        cmbdesignation.Text = ""
        txthelpers.Clear()
        txthelpername.Clear()
        If gridhelper.RowCount > 0 Then
            txthsrno.Text = Val(gridhelper.Rows(gridhelper.RowCount - 1).Cells(GHSRNO.Index).Value) + 1
        Else
            txthsrno.Text = 1
        End If

        TXT100MTRSWT.Clear()
        TXTTOTALPCS.Text = 0.0
        LBLTOTALMTRS.Text = 0.0
        LBLTOTALRECDMTRS.Text = 0.0
        LBLTOTALDIFF.Text = 0.0
        LBLTOTALWT.Text = 0.0
        CMBDYEING.Enabled = True
        grpdyeing.Enabled = False
        LBLDEFCONSUMEDQTY.Text = 0.0
        LBLACTCONSUMEDQTY.Text = 0.0
        LBLDEFCONSUMEDAMT.Text = 0.0
        LBLACTCONSUMEDAMT.Text = 0.0
        CHKPCS.Enabled = True

        TXTITEMSTOCK.Clear()
    End Sub

    Sub TOTALCONSUMPTION()
        Try
            LBLACTCONSUMEDQTY.Text = 0.0
            LBLACTCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDQTY.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDCONSUMPTION.Rows
                If ROW.Cells(GCONSUMEDSRNO.Index).Value <> Nothing Then
                    ROW.Cells(gdefamt.Index).Value = Val(ROW.Cells(GdefQTY.Index).EditedFormattedValue) * Val(ROW.Cells(GdefRATE.Index).EditedFormattedValue)
                    ROW.Cells(gactamt.Index).Value = Val(ROW.Cells(GactQty.Index).EditedFormattedValue) * Val(ROW.Cells(gActRate.Index).EditedFormattedValue)

                    LBLACTCONSUMEDQTY.Text = Format(Val(LBLACTCONSUMEDQTY.Text) + Val(ROW.Cells(GactQty.Index).EditedFormattedValue), "0.00")
                    LBLACTCONSUMEDAMT.Text = Format(Val(LBLACTCONSUMEDAMT.Text) + Val(ROW.Cells(gactamt.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDQTY.Text = Format(Val(LBLDEFCONSUMEDQTY.Text) + Val(ROW.Cells(GdefQTY.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDAMT.Text = Format(Val(LBLDEFCONSUMEDAMT.Text) + Val(ROW.Cells(gdefamt.Index).EditedFormattedValue), "0.00")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALRECDMTRS.Text = 0.0
            LBLTOTALDIFF.Text = 0.0
            LBLTOTALWT.Text = 0.0
            TXTTOTALPCS.Text = 0.0

            GRIDSUMM.RowCount = 0
            Dim DONE As Boolean = False

            For Each ROW As DataGridViewRow In GRIDMFG.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    ROW.Cells(GDIFF.Index).Value = Format(Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue) - Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALRECDMTRS.Text = Format(Val(LBLTOTALRECDMTRS.Text) + Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALDIFF.Text = Format(Val(LBLTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    TXTTOTALPCS.Text = Format(Val(TXTTOTALPCS.Text) + Val(ROW.Cells(GINPCS.Index).EditedFormattedValue), "0.00")
                    'calculate % of difference
                    If Val(ROW.Cells(GDIFF.Index).EditedFormattedValue) > 0 Then
                        ROW.Cells(GPERCENT.Index).Value = Format((Val(ROW.Cells(GDIFF.Index).EditedFormattedValue) / Val(ROW.Cells(GMTRS.Index).EditedFormattedValue)) * 100, "0.00")
                    Else
                        ROW.Cells(GPERCENT.Index).Value = Format(((Val(ROW.Cells(GDIFF.Index).EditedFormattedValue) * (-1)) / Val(ROW.Cells(GMTRS.Index).EditedFormattedValue)) * 100, "0.00")
                    End If
                End If

                DONE = False
                If Val(ROW.Cells(GINPCS.Index).EditedFormattedValue) > 0 Then
                    If GRIDSUMM.RowCount = 0 Then
                        GRIDSUMM.Rows.Add(ROW.Cells(GLOTNO.Index).Value, Val(ROW.Cells(GINPCS.Index).Value), Format(Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue), "0.00"))
                    Else
                        For Each SUMMROW As DataGridViewRow In GRIDSUMM.Rows
                            If SUMMROW.Cells(SLOTNO.Index).Value = ROW.Cells(GLOTNO.Index).Value Then
                                SUMMROW.Cells(SPCS.Index).Value = Val(SUMMROW.Cells(SPCS.Index).Value) + Val(ROW.Cells(GINPCS.Index).EditedFormattedValue)
                                SUMMROW.Cells(SMTRS.Index).Value = Val(SUMMROW.Cells(SMTRS.Index).Value) + Val(ROW.Cells(GRECDMTRS.Index).EditedFormattedValue)
                                DONE = True
                            End If
                        Next
                        If DONE = False Then GRIDSUMM.Rows.Add(ROW.Cells(GLOTNO.Index).Value, Val(ROW.Cells(GINPCS.Index).Value), Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00"))
                    End If
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
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
        Else
            'TXTDATEDIFF.Text = DateDiff(DateInterval.Hour, INTIME.Value, OUTTIME.Value)
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(MFG_NO),0) + 1 ", " MFGMASTER", " AND MFG_cmpid=" & CmpId & " and MFG_locationid=" & Locationid & " and MFG_yearid=" & YearId)
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

            If ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM" Then
                If CMBTO.Text = "DYEING" And GRIDCONSUMPTION.RowCount = 0 Then
                    EP.SetError(CMBTO, "Please Calculate Consumption")
                    bln = False
                End If
                If cmbcontractor.Text.Trim.Length = 0 Then
                    EP.SetError(cmbcontractor, "Please Select Contractor")
                    bln = False
                End If
            End If

            If TXTITEMNAME.Text.Trim.Length = 0 Then
                EP.SetError(TXTITEMNAME, "Please Select Item")
                bln = False
            End If

            If GRIDMFG.RowCount = 0 Then
                EP.SetError(TXTITEMNAME, "Please Select Item")
                bln = False
            End If

            'If lbllocked.Visible = True Then
            '    EP.SetError(lbllocked, "Item Used in Mfg, Delete Mfg First")
            '    bln = False
            'End If


            For Each row As DataGridViewRow In GRIDMFG.Rows
                If Val(row.Cells(GMTRS.Index).Value) = 0 Then
                    EP.SetError(TXTTOTALPCS, "Please Select Item")
                    bln = False
                End If
                'If Val(row.Cells(GRECDMTRS.Index).Value) = 0 Then
                '    EP.SetError(TXTTOTALPCS, "Recd Mtrs Cannot be Zero")
                '    bln = False
                'End If
                If CMBDYEING.Text.Trim <> "" Then
                    row.Cells(gdyeingno.Index).Value = CMBDYEING.Text

                End If
                If CMBCOLOR.Text.Trim <> "" Then
                    row.Cells(Gcolor.Index).Value = CMBCOLOR.Text
                End If
            Next

            If Not datecheck(MFGDATE.Value) Then bln = False

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

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

    Private Sub cmbSUPERVISIOR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSUPERVISOR.GotFocus
        Try
            If CMBSUPERVISOR.Text.Trim = "" Then fillSUPERVISIOR(CMBSUPERVISOR)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbSUPERVISIOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSUPERVISOR.Validating
        Try
            If CMBSUPERVISOR.Text.Trim <> "" Then SUPERVISIORvalidate(CMBSUPERVISOR, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

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
            alParaval.Add(cmbshift.Text.Trim)
            alParaval.Add(TXTDEGREE.Text.Trim)
            alParaval.Add(cmbcontractor.Text.Trim)
            alParaval.Add(CMBSUPERVISOR.Text.Trim)
            alParaval.Add(cmbprgno.Text.Trim)
            alParaval.Add(CMBDYEING.Text.Trim)
            alParaval.Add(CMBCOLOR.Text.Trim)
            alParaval.Add(INTIME.Value)
            alParaval.Add(OUTTIME.Value)
            alParaval.Add(DTDATEDIFF.Value)

            alParaval.Add(CMBMERCHANT.Text.Trim)
            alParaval.Add(TXTITEMNAME.Text.Trim)
            alParaval.Add(TXTQUALITY.Text.Trim)
            alParaval.Add(TXTREED.Text.Trim)
            alParaval.Add(TXTPICK.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)


            alParaval.Add(Val(TXTTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALRECDMTRS.Text))
            alParaval.Add(Val(LBLTOTALDIFF.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLDEFCONSUMEDQTY.Text))
            alParaval.Add(Val(LBLACTCONSUMEDQTY.Text))
            alParaval.Add(Val(LBLDEFCONSUMEDAMT.Text))
            alParaval.Add(Val(LBLACTCONSUMEDAMT.Text))


            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim gridremarks As String = ""
            Dim MTRS As String = ""
            Dim INPCS As String = ""
            Dim RECDMTRS As String = ""
            Dim DIFF As String = ""
            Dim WT As String = ""
            Dim DONE As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim CHECKNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim CHECKGRIDSRNO As String = ""    'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGNO As String = ""            'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim LOTNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim LOTSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim RATE As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim TYPE As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim DYEING As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim COLOR As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim OUTPCS As String = ""
            Dim OUTMTRS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDMFG.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        INPCS = row.Cells(GINPCS.Index).Value.ToString
                        RECDMTRS = row.Cells(GRECDMTRS.Index).Value.ToString
                        DIFF = row.Cells(GDIFF.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = "1"
                        Else
                            DONE = "0"
                        End If
                        CHECKNO = row.Cells(GGRNCHECKNO.Index).Value
                        CHECKGRIDSRNO = row.Cells(GGRNCHECKSRNO.Index).Value
                        MFGNO = row.Cells(GMFGNO.Index).Value
                        MFGSRNO = row.Cells(GMFGSRNO.Index).Value
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        LOTSRNO = row.Cells(GLOTSRNO.Index).Value
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        TYPE = row.Cells(gtype.Index).Value
                        DYEING = row.Cells(gdyeingno.Index).Value
                        COLOR = row.Cells(Gcolor.Index).Value
                        OUTPCS = row.Cells(goutpcs.Index).Value
                        OUTMTRS = row.Cells(GOUTMTRS.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value
                        gridremarks = gridremarks & "," & row.Cells(gdesc.Index).Value.ToString
                        MTRS = MTRS & "," & row.Cells(GMTRS.Index).Value.ToString
                        INPCS = INPCS & "," & row.Cells(GINPCS.Index).Value.ToString
                        RECDMTRS = RECDMTRS & "," & row.Cells(GRECDMTRS.Index).Value.ToString
                        DIFF = DIFF & "," & row.Cells(GDIFF.Index).Value
                        WT = WT & "," & row.Cells(GWT.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "," & "1"
                        Else
                            DONE = DONE & "," & "0"
                        End If
                        CHECKNO = CHECKNO & "," & row.Cells(GGRNCHECKNO.Index).Value
                        CHECKGRIDSRNO = CHECKGRIDSRNO & "," & row.Cells(GGRNCHECKSRNO.Index).Value
                        MFGNO = MFGNO & "," & row.Cells(GMFGNO.Index).Value
                        MFGSRNO = MFGSRNO & "," & row.Cells(GMFGSRNO.Index).Value
                        LOTNO = LOTNO & "," & row.Cells(GLOTNO.Index).Value
                        LOTSRNO = LOTSRNO & "," & row.Cells(GLOTSRNO.Index).Value
                        RATE = RATE & "," & Val(row.Cells(GRATE.Index).Value)
                        TYPE = TYPE & "," & row.Cells(gtype.Index).Value
                        DYEING = DYEING & "," & row.Cells(gdyeingno.Index).Value
                        COLOR = COLOR & "," & row.Cells(Gcolor.Index).Value
                        OUTPCS = OUTPCS & "," & row.Cells(goutpcs.Index).Value
                        OUTMTRS = OUTMTRS & "," & row.Cells(GOUTMTRS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(gridremarks)
            alParaval.Add(MTRS)
            alParaval.Add(INPCS)
            alParaval.Add(RECDMTRS)
            alParaval.Add(DIFF)
            alParaval.Add(WT)
            alParaval.Add(DONE)
            alParaval.Add(CHECKNO)
            alParaval.Add(CHECKGRIDSRNO)
            alParaval.Add(MFGNO)
            alParaval.Add(MFGSRNO)
            alParaval.Add(LOTNO)
            alParaval.Add(LOTSRNO)
            alParaval.Add(RATE)
            alParaval.Add(TYPE)
            alParaval.Add(DYEING)
            alParaval.Add(COLOR)
            alParaval.Add(OUTPCS)
            alParaval.Add(OUTMTRS)


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

            alParaval.Add(Val(TXT100MTRSWT.Text.Trim))


            Dim OBJMFG As New ClsMfg()
            OBJMFG.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJMFG.save()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPMFGNO)

                IntResult = OBJMFG.Update()
                MsgBox("Details Updated")
            End If

            PRINTREPORT()
            edit = False

            clear()
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
                '  Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
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
            clear()
            Dim dttable As New DataTable
            Dim OBJCMN As New ClsCommon

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsMfg()
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

                        FILLMACHINENO()
                        cmbmachineno.Text = Convert.ToString(dr("MACHINENO").ToString)
                        cmbshift.Text = Convert.ToString(dr("SHIFT").ToString)
                        TXTDEGREE.Text = Convert.ToString(dr("DEGREE").ToString)
                        cmbcontractor.Text = Convert.ToString(dr("CONTRACTOR").ToString)
                        CMBSUPERVISOR.Text = Convert.ToString(dr("SUPERVISOR").ToString)
                        CMBDYEING.Text = Convert.ToString(dr("DYEING").ToString)
                        CMBCOLOR.Text = Convert.ToString(dr("COLOR").ToString)
                        cmbprgno.Text = dr("prgno")

                        INTIME.Value = Convert.ToDateTime(dr("INTIME"))
                        OUTTIME.Value = Convert.ToDateTime(dr("OUTTIME"))


                        'ITEM DETAILS
                        CMBMERCHANT.Text = Convert.ToString(dr("MERCHANT").ToString)
                        TXTITEMNAME.Text = Convert.ToString(dr("ITEMNAME").ToString)
                        TXTQUALITY.Text = Convert.ToString(dr("QUALITY").ToString)
                        TXTREED.Text = Convert.ToString(dr("REED").ToString)
                        TXTPICK.Text = Convert.ToString(dr("PICK").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        TXTCOLOR.Text = Convert.ToString(dr("COLOR").ToString)

                        TXTTOTALPCS.Text = Convert.ToString(dr("TOTALPCS").ToString)

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)


                        'Item Grid
                        GRIDMFG.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("GRIDREMARKS").ToString, Format(dr("MTRS"), "0.00"), Format(dr("INPCS"), "0.00"), Format(dr("RECDMTRS"), "0.00"), Format(dr("DIFF"), "0.00"), Format(dr("WT"), "0.00"), dr("DONE").ToString, dr("CHECKNO"), dr("CHECKGRIDSRNO"), dr("GRIDMFGNO"), dr("MFGSRNO"), dr("LOTNO"), dr("LOTSRNO"), 0, Format(Val(dr("RATE")), "0.00"), dr("TYPE"), dr("DYEING"), Convert.ToString(dr("COLOR").ToString), Format(dr("OUTPCS"), "0.00"), Format(dr("OUTMTRS"), "0.00"))
                        If dr("INPCS") > 1 Then
                            GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(GINPCS.Index).ReadOnly = False
                        Else
                            GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(GINPCS.Index).ReadOnly = True
                        End If
                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(GINPCS.Index).ReadOnly = True
                            PBlock.Visible = True
                            GRIDMFG.Rows(GRIDMFG.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If
                        If CMBTO.Text.Trim = "DYEING" Then grpdyeing.Enabled = True

                        TXT100MTRSWT.Text = Val(dr("WT100MTRS"))

                    Next


                    CMBFROM.Enabled = False
                    CMBTO.Enabled = False
                    TOTAL()

                    If Val(LBLTOTALDIFF.Text.Trim) <> 0 Then CHKRECD.CheckState = CheckState.Unchecked


                End If

                dttable = OBJCMN.search("  MFGMASTER_CONSUMED.MFG_SRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, MFGMASTER_CONSUMED.MFG_defQTY AS defQTY, MFGMASTER_CONSUMED.MFG_ACTQTY AS actQTY, UNITMASTER.unit_abbr AS UNIT, MFGMASTER_CONSUMED.MFG_DEFRATE AS DEFRATE, MFGMASTER_CONSUMED.MFG_ACTRATE AS ACTRATE", "", " MFGMASTER_CONSUMED INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON MFGMASTER_CONSUMED.MFG_UNITID = UNITMASTER.unit_id AND MFGMASTER_CONSUMED.MFG_CMPID = UNITMASTER.unit_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = UNITMASTER.unit_locationid AND MFGMASTER_CONSUMED.MFG_YEARID = UNITMASTER.unit_yearid", " AND MFGMASTER_CONSUMED.MFG_NO = " & TEMPMFGNO & " AND MFGMASTER_CONSUMED.MFG_CMPID = " & CmpId & " AND MFGMASTER_CONSUMED.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER_CONSUMED.MFG_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        GRIDCONSUMPTION.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEMNAME"), Format(DR("DEFQTY"), "0.000"), Format(DR("ACTQTY"), "0.000"), DR("UNIT"), Format(DR("DEFRATE"), "0.000"), Format(DR("ACTRATE"), "0.000"))
                    Next
                    getsrno(GRIDCONSUMPTION)
                    TOTALCONSUMPTION()
                End If

                dttable = OBJCMN.search(" MFGMASTER_HELPERS.MFG_SRNO AS SRNO, DESIGNATIONMASTER.DESIGNATION_name AS DESIGNATION, MFGMASTER_HELPERS.MFG_HELPERS AS HELPERS, MFGMASTER_HELPERS.MFG_HELPERNAMES AS HELPERNAMES ", "", "  MFGMASTER_HELPERS INNER JOIN DESIGNATIONMASTER ON MFGMASTER_HELPERS.MFG_DESIGNATIONID = DESIGNATIONMASTER.DESIGNATION_id AND MFGMASTER_HELPERS.MFG_CMPID = DESIGNATIONMASTER.DESIGNATION_cmpid AND MFGMASTER_HELPERS.MFG_LOCATIONID = DESIGNATIONMASTER.DESIGNATION_locationid AND MFGMASTER_HELPERS.MFG_YEARID = DESIGNATIONMASTER.DESIGNATION_yearid ", " AND MFGMASTER_HELPERS.MFG_NO = " & TEMPMFGNO & " AND MFGMASTER_HELPERS.MFG_CMPID = " & CmpId & " AND MFGMASTER_HELPERS.MFG_LOCATIONID  = " & Locationid & " AND MFGMASTER_HELPERS.MFG_YEARID = " & YearId & " ORDER BY MFGMASTER_HELPERS.MFG_SRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        gridhelper.Rows.Add(DR("SRNO").ToString, DR("DESIGNATION"), DR("HELPERS").ToString, DR("HELPERNAMES").ToString)
                    Next
                    getsrno(gridhelper)

                End If

                chkchange.CheckState = CheckState.Checked
            End If



            dttable = OBJCMN.search("  ITEMMASTER.item_name AS ITEM, DYEINGRECIPE_CONSUMPTION.DYEING_QTY, DYEINGRECIPE_DESC.DYEING_PERPCS, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE ", "", "      DYEINGRECIPE INNER JOIN DYEINGRECIPE_DESC ON DYEINGRECIPE.DYEING_ID = DYEINGRECIPE_DESC.DYEING_ID AND DYEINGRECIPE.DYEING_CMPID = DYEINGRECIPE_DESC.DYEING_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DYEINGRECIPE_CONSUMPTION ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE_CONSUMPTION.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_SRNO = DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE_CONSUMPTION.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE_CONSUMPTION.DYEING_YEARID INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DYEINGRECIPE.DYEING_PROCESSID = PROCESSMASTER.PROCESS_ID AND DYEINGRECIPE.DYEING_CMPID = PROCESSMASTER.PROCESS_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND COLORMASTER.COLOR_name ='" & CMBCOLOR.Text.Trim & "' AND dyeingRECIPE.dyeing_NO ='" & CMBDYEING.Text & "' AND dyeingRECIPE.dyeing_CMPID =" & CmpId & " AND dyeingRECIPE.dyeing_LOCATIONID =" & Locationid & " AND dyeingRECIPE.dyeing_YEARID =" & YearId)
            If dttable.Rows.Count > 0 And GRIDCONSUMPTION.RowCount = 0 Then
                For j As Integer = 0 To dttable.Rows.Count - 1
                    GRIDCONSUMPTION.Rows.Add(0, dttable.Rows(j).Item("item"), Val((GRIDMFG.RowCount) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), Val((GRIDMFG.RowCount) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), "KGS", Val(dttable.Rows(j).Item("RATE")), Val(dttable.Rows(j).Item("RATE")))
                Next
                getsrno(GRIDCONSUMPTION)
                TOTALCONSUMPTION()
            End If

            getsrno(GRIDCONSUMPTION)
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
            'If UserName <> "Admin" Then
            '    If CMBTO.Text.Trim = "" Then FILLPROCESS(CMBTO, " AND ((PROCESSMASTER.PROCESS_TYPE='CHECKING' or PROCESSMASTER.PROCESS_TYPE='MFG') and process_userid=" & Userid & ")", edit)
            '    If CMBFROM.Text.Trim = "" Then FILLPROCESS(CMBFROM, " AND (PROCESSMASTER.PROCESS_TYPE='CHECKING' OR  PROCESSMASTER.PROCESS_TYPE='MFG')", edit)
            'Else
            If CMBFROM.Text.Trim = "" Then FILLPROCESS(CMBFROM, " AND (PROCESSMASTER.PROCESS_TYPE='CHECKING' OR  PROCESSMASTER.PROCESS_TYPE='MFG')", edit)
            If CMBTO.Text.Trim = "" Then FILLPROCESS(CMBTO, " AND (PROCESSMASTER.PROCESS_TYPE='CHECKING' OR  PROCESSMASTER.PROCESS_TYPE='MFG')", edit)

            'End If
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
            If cmbdesignation.Text.Trim = "" Then filldesignation(cmbdesignation)
            If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR)
            If cmbcontractor.Text.Trim = "" Then fillCONTRACTOR(cmbcontractor)
            If CMBSUPERVISOR.Text.Trim = "" Then fillSUPERVISIOR(CMBSUPERVISOR)
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            FILLGODOWN(CMBGODOWN, edit)
            cmbprgno.Text = ""
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

            Dim OBJMFGDETAILS As New MfgDetails
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

            SELECTGRN.Clear()
            Dim OBJSELECTMFG As New SelectMfg
            OBJSELECTMFG.FRMSTRING = "MFG"
            OBJSELECTMFG.PROCESSNAME = CMBFROM.Text.Trim
            OBJSELECTMFG.GODOWN = CMBGODOWN.Text.Trim
            If GRIDMFG.RowCount > 0 Then
                Dim strLOTNO As String = ""
                Dim strselected As String = ""
                For Each row As DataGridViewRow In GRIDMFG.Rows
                    If strselected = "" Then
                        strLOTNO = Val(row.Cells(GLOTNO.Index).Value)
                        strselected = " " & Val(row.Cells(GLOTNO.Index).Value)
                    Else
                        If strLOTNO <> Val(row.Cells(GLOTNO.Index).Value) Then
                            strselected = strselected & "," & Val(row.Cells(GLOTNO.Index).Value)
                            strLOTNO = Val(row.Cells(GLOTNO.Index).Value)

                        End If
                    End If
                    If strselected <> "" Then OBJSELECTMFG.WHERE1 = " AND [Lot No] NOT IN (" & strselected & ")"
                Next
            End If
            OBJSELECTMFG.ShowDialog()


            Dim i As Integer = 0
            If SELECTGRN.Rows.Count > 0 Then

                CHKRECD.CheckState = CheckState.Checked
                CMBFROM.Enabled = False
                CMBTO.Enabled = False
                chkchange.Checked = True
                'If edit = False Then GRIDMFG.RowCount = 0

                For i = 0 To SELECTGRN.Rows.Count - 1

                    TXTITEMNAME.Text = SELECTGRN.Rows(i).Item("ITEMNAME")
                    TXTQUALITY.Text = SELECTGRN.Rows(i).Item("QUALITY")
                    TXTREED.Text = SELECTGRN.Rows(i).Item("REED")
                    TXTPICK.Text = SELECTGRN.Rows(i).Item("PICK")
                    TXTCOLOR.Text = SELECTGRN.Rows(i).Item("COLOR")

                    GRIDMFG.Rows.Add(0, "FRESH", "", Format(Val(SELECTGRN.Rows(i).Item("MTRS")), "0.00"), Val(SELECTGRN.Rows(i).Item("PCS")), Format(Val(SELECTGRN.Rows(i).Item("MTRS")), "0.00"), 0.0, Format(Val(SELECTGRN.Rows(i).Item("WT")), "0.00"), 0, SELECTGRN.Rows(i).Item("CHECKNO"), SELECTGRN.Rows(i).Item("CHECKSRNO"), SELECTGRN.Rows(i).Item("MFGNO"), SELECTGRN.Rows(i).Item("MFGSRNO"), SELECTGRN.Rows(i).Item("LOTNO"), SELECTGRN.Rows(i).Item("LOTSRNO"), 0, Format(Val(SELECTGRN.Rows(i).Item("RATE")), "0.00"), SELECTGRN.Rows(i).Item("TYPE"), "", "", 0, 0)
                    If GRIDMFG.Rows(i).Cells(GINPCS.Index).Value > 1 Then
                        GRIDMFG.Rows(i).Cells(GINPCS.Index).ReadOnly = False
                    Else
                        GRIDMFG.Rows(i).Cells(GINPCS.Index).ReadOnly = True
                    End If
                    ', SELECTGRN.Rows(i).Item("TYPE")

                Next
                TXTTOTALPCS.Text = Val(GRIDMFG.RowCount)
                If CMBTO.Text.Trim = "DYEING" Then grpdyeing.Enabled = True
                getsrno(GRIDMFG)
                TOTAL()
                CMBFROM.Focus()






                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable
                If ClientName <> "DHANLAXMI" Then
                    GRIDCONSUMPTION.RowCount = 0
                    DT = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, PROCESS_DESC.PROCESS_QTY AS QTY,PROCESS_DESC.PROCESS_PERPCS AS PERPCS, UNITMASTER.unit_abbr AS UNIT, PROCESS_DESC.PROCESS_RATE AS RATE", "", " PROCESS_DESC INNER JOIN ITEMMASTER ON PROCESS_DESC.PROCESS_ITEMid = ITEMMASTER.item_id AND PROCESS_DESC.PROCESS_cmpid = ITEMMASTER.item_cmpid AND PROCESS_DESC.PROCESS_locationid = ITEMMASTER.item_locationid AND PROCESS_DESC.PROCESS_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PROCESS_DESC.PROCESS_cmpid = UNITMASTER.unit_cmpid AND PROCESS_DESC.PROCESS_locationid = UNITMASTER.unit_locationid AND PROCESS_DESC.PROCESS_yearid = UNITMASTER.unit_yearid AND PROCESS_DESC.PROCESS_unitid = UNITMASTER.unit_id INNER JOIN PROCESSMASTER ON PROCESS_DESC.PROCESS_id = PROCESSMASTER.PROCESS_ID AND PROCESS_DESC.PROCESS_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESS_DESC.PROCESS_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESS_DESC.PROCESS_yearid = PROCESSMASTER.PROCESS_YEARID", " AND PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND PROCESS_DESC.PROCESS_CMPID = " & CmpId & " AND PROCESS_DESC.PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_DESC.PROCESS_YEARID= " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTROW As DataRow In DT.Rows
                            GRIDCONSUMPTION.Rows.Add(0, DTROW("ITEMNAME"), Format(DTROW("QTY") * GRIDMFG.RowCount / DTROW("PERPCS"), "0.000"), Format(DTROW("QTY"), "0.000"), DTROW("UNIT"), DTROW("RATE"), DTROW("RATE"))
                        Next
                        getsrno(GRIDCONSUMPTION)
                        TOTALCONSUMPTION()
                    End If

                Else
                    'FETCH QUALITYWT FROM CHECKINGMASTER
                    DT = OBJCMN.search("CHECK_QUALITYWT AS QUALITYWT", "", "CHECKINGMASTER ", " AND CHECK_LOTNO = " & Val(GRIDMFG.Rows(0).Cells(GLOTNO.Index).Value) & " AND CHECK_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXT100MTRSWT.Text = Format(Val(DT.Rows(0).Item("QUALITYWT")) * 100, "0.00")

                End If
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
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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
                clear()
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
            clear()
            If Val(TXTMFGNO.Text) - 1 >= TEMPMFGNO Then
                edit = True
                Mfg_Load(sender, e)
            Else
                clear()
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

                'Dim DTTABLE As New DataTable
                'DTTABLE = getmax(" MFG_done ", " MFGMASTER_DESC", "  AND MFG_done=1 and MFG_no=" & TXTMFGNO.Text.Trim & " AND MFG_cmpid=" & CmpId & " AND MFG_LOCATIONID = " & Locationid & " AND MFG_YEARID = " & YearId)
                'If DTTABLE.Rows.Count > 0 Then
                '    MsgBox("PROCESS Raised Delete PROCESS First", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If

                TEMPMSG = MsgBox("Delete MFG?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPMFGNO)
                    alParaval.Add(Userid)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJMFG As New ClsMfg()
                    OBJMFG.alParaval = alParaval
                    IntResult = OBJMFG.Delete()
                    MsgBox("MFG Deleted")
                    clear()
                    edit = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDMFG_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDMFG.CellValidating
        Try
            Dim colNum As Integer = GRIDMFG.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GRECDMTRS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDMFG.CurrentCell.Value = Nothing Then GRIDMFG.CurrentCell.Value = "0.00"
                        GRIDMFG.CurrentCell.Value = Convert.ToDecimal(GRIDMFG.Item(colNum, e.RowIndex).Value)

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

    Private Sub GRIDMFG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDMFG.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMFG.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                If Convert.ToBoolean(GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GDONE.Index).Value) = False Then
                    GRIDMFG.Rows.RemoveAt(GRIDMFG.CurrentRow.Index)
                Else
                    MsgBox("CANNOT DELETE THIS ROW")
                End If
                If lbllocked.Visible = False Then
                    getsrno(GRIDMFG)
                End If
                TOTAL()

                If CMBCOLOR.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" Then
                    Dim dttable As New DataTable
                    Dim OBJCMN As New ClsCommon
                    GRIDCONSUMPTION.RowCount = 0
                    dttable = OBJCMN.search("  ITEMMASTER.item_name AS ITEM, DYEINGRECIPE_CONSUMPTION.DYEING_QTY, DYEINGRECIPE_DESC.DYEING_PERPCS, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE ", "", "      DYEINGRECIPE INNER JOIN DYEINGRECIPE_DESC ON DYEINGRECIPE.DYEING_ID = DYEINGRECIPE_DESC.DYEING_ID AND DYEINGRECIPE.DYEING_CMPID = DYEINGRECIPE_DESC.DYEING_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DYEINGRECIPE_CONSUMPTION ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE_CONSUMPTION.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_SRNO = DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE_CONSUMPTION.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE_CONSUMPTION.DYEING_YEARID INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DYEINGRECIPE.DYEING_PROCESSID = PROCESSMASTER.PROCESS_ID AND DYEINGRECIPE.DYEING_CMPID = PROCESSMASTER.PROCESS_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND COLORMASTER.COLOR_name ='" & CMBCOLOR.Text.Trim & "' AND dyeingRECIPE.dyeing_NO ='" & CMBDYEING.Text & "' AND dyeingRECIPE.dyeing_CMPID =" & CmpId & " AND dyeingRECIPE.dyeing_LOCATIONID =" & Locationid & " AND dyeingRECIPE.dyeing_YEARID =" & YearId)
                    If dttable.Rows.Count > 0 Then
                        For j As Integer = 0 To dttable.Rows.Count - 1
                            GRIDCONSUMPTION.Rows.Add(0, dttable.Rows(j).Item("item"), Val((GRIDMFG.RowCount) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), Val((GRIDMFG.RowCount) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), "KGS", Val(dttable.Rows(j).Item("RATE")), Val(dttable.Rows(j).Item("RATE")))
                        Next
                    End If
                    If lbllocked.Visible = False Then

                        getsrno(GRIDCONSUMPTION)
                    End If
                    TOTALCONSUMPTION()

                Else
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable
                    GRIDCONSUMPTION.RowCount = 0
                    DT = OBJCMN.search(" ITEMMASTER.item_name AS ITEMNAME, PROCESS_DESC.PROCESS_QTY AS QTY,PROCESS_DESC.PROCESS_PERPCS AS PERPCS, UNITMASTER.unit_abbr AS UNIT, PROCESS_DESC.PROCESS_RATE AS RATE", "", " PROCESS_DESC INNER JOIN ITEMMASTER ON PROCESS_DESC.PROCESS_ITEMid = ITEMMASTER.item_id AND PROCESS_DESC.PROCESS_cmpid = ITEMMASTER.item_cmpid AND PROCESS_DESC.PROCESS_locationid = ITEMMASTER.item_locationid AND PROCESS_DESC.PROCESS_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PROCESS_DESC.PROCESS_cmpid = UNITMASTER.unit_cmpid AND PROCESS_DESC.PROCESS_locationid = UNITMASTER.unit_locationid AND PROCESS_DESC.PROCESS_yearid = UNITMASTER.unit_yearid AND PROCESS_DESC.PROCESS_unitid = UNITMASTER.unit_id INNER JOIN PROCESSMASTER ON PROCESS_DESC.PROCESS_id = PROCESSMASTER.PROCESS_ID AND PROCESS_DESC.PROCESS_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESS_DESC.PROCESS_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESS_DESC.PROCESS_yearid = PROCESSMASTER.PROCESS_YEARID", " AND PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND PROCESS_DESC.PROCESS_CMPID = " & CmpId & " AND PROCESS_DESC.PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_DESC.PROCESS_YEARID= " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTROW As DataRow In DT.Rows
                            GRIDCONSUMPTION.Rows.Add(0, DTROW("ITEMNAME"), Format(DTROW("QTY") * GRIDMFG.RowCount / DTROW("PERPCS"), "0.000"), Format(DTROW("QTY"), "0.000"), DTROW("UNIT"), DTROW("RATE"), DTROW("RATE"))
                        Next
                        getsrno(GRIDCONSUMPTION)
                        TOTALCONSUMPTION()
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKRECD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKRECD.CheckedChanged
        Try

            If GRIDMFG.RowCount > 0 And edit = False And a = 0 Then
                If CHKRECD.CheckState = CheckState.Checked Then
                    For Each ROW As DataGridViewRow In GRIDMFG.Rows
                        If ROW.Cells(GRECDMTRS.Index).Value = 0 Then
                            ROW.Cells(GRECDMTRS.Index).Value = Val(ROW.Cells(GMTRS.Index).Value)
                            ROW.Cells(GDIFF.Index).Value = 0.0
                            a = 1
                        End If
                    Next
                Else
                    For Each ROW As DataGridViewRow In GRIDMFG.Rows
                        ROW.Cells(GRECDMTRS.Index).Value = 0.0
                        ROW.Cells(GDIFF.Index).Value = Val(ROW.Cells(GMTRS.Index).Value)
                    Next
                End If
                If a = 1 Then
                    CHKRECD.CheckState = False
                End If
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTO.Validated
        Try
            If CMBTO.Text.Trim <> "" Then
                CMBTO.Enabled = False

                'GET CONTRACTOR AND SUPERVISOR WITH RESPECT TO PROCESS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(CONTRACTOR_NAME,'') AS CONTRACTOR, ISNULL(SUPERVISIOR_NAME,'') AS SUPERVISOR", "", " PROCESSMASTER INNER JOIN  PROCESSCONTRACTOR ON PROCESSMASTER.PROCESS_ID = PROCESSCONTRACTOR.PROCESSID INNER JOIN CONTRACTORMASTER ON PROCESSCONTRACTOR.CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id INNER JOIN SUPERVISIORMASTER ON PROCESSCONTRACTOR.SUPERVISORID = SUPERVISIORMASTER.SUPERVISIOR_id  ", " AND PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If cmbcontractor.Text.Trim = "" Then cmbcontractor.Text = DT.Rows(0).Item("CONTRACTOR")
                    If CMBSUPERVISOR.Text.Trim = "" Then CMBSUPERVISOR.Text = DT.Rows(0).Item("SUPERVISOR")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTO.Validating
        Try
            If edit = False And CMBTO.Text.Trim <> "" Then

                'GETTING CONSUMPTION
                If GRIDCONSUMPTION.RowCount > 0 Then
                    TEMPMSG = MsgBox("Item's Already Present, Delete from Grid?", MsgBoxStyle.YesNo, CmpName)
                    If TEMPMFGNO = vbNo Then Exit Sub
                End If
                GRIDCONSUMPTION.RowCount = 0

            End If
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
        numdotkeypress(e, txtactqty, Me)
    End Sub

    Private Sub TXTACTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTACTRATE.KeyPress
        numdotkeypress(e, TXTACTRATE, Me)

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
            If CMBITEMNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable = OBJCMN.search("  ITEMMASTER_RATEDESC.ITEM_RATE ", "", "   ITEMMASTER INNER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID INNER JOIN RATETYPEMASTER ON ITEMMASTER_RATEDESC.ITEM_RATETYPEID = RATETYPEMASTER.RATETYPE_id AND ITEMMASTER_RATEDESC.ITEM_CMPID = RATETYPEMASTER.RATETYPE_cmpid AND ITEMMASTER_RATEDESC.ITEM_LOCATIONID = RATETYPEMASTER.RATETYPE_locationid AND ITEMMASTER_RATEDESC.ITEM_YEARID = RATETYPEMASTER.RATETYPE_yearid", " and ITEMMASTER.item_name = '" & CMBITEMNAME.Text.Trim & "' and RATETYPEMASTER.RATETYPE_name='MASTER RATE' And ITEMMASTER.item_cmpid = " & CmpId & " And ITEMMASTER.item_locationid = " & Locationid & " And ITEMMASTER.item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    txtdefrate.Text = dt.Rows(0).Item(0)
                    TXTACTRATE.Text = dt.Rows(0).Item(0)
                End If

                'GET LAST PURCHASE RATE FROM PURCHASEMASTER IRRESPECTIVE TO YEARID
                'DONT PUT YEARID CLAUSE JUST FECH RATES OF LAST PURCHASE WITH RESPECT TO ITEMNAME
                If ClientName <> "TULSI" Then
                    Dim DTRATE As DataTable = OBJCMN.search(" TOP 1 ISNULL(PURCHASEMASTER_DESC.BILL_RATE, 0) AS RATE, ISNULL(HSNMASTER.HSN_IGST,0) AS IGST ", "", " PURCHASEMASTER_DESC INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID AND  PURCHASEMASTER_DESC.BILL_yearid = PURCHASEMASTER.BILL_YEARID LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND ITEMMASTER.ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' ORDER BY PURCHASEMASTER.BILL_DATE DESC ")
                    If DTRATE.Rows.Count > 0 Then
                        txtdefrate.Text = Val(DTRATE.Rows(0).Item("RATE"))
                        TXTACTRATE.Text = Val(DTRATE.Rows(0).Item("RATE"))

                        'REMOVED AS PER PAREEN ON 23-06-22
                        'AGAIN STARTED AS PER REQUEST ON 28-03-23
                        'AGAIN REMOVED AS PER REQUEST ON 12-04-22
                        'WE HAVE FETCHED RATE WITH GST FOR MONOGRAM
                        'If ClientName = "MONOGRAM" Then
                        '    txtdefrate.Text = Format(Val(txtdefrate.Text.Trim) + (Val(txtdefrate.Text.Trim) * Val(DTRATE.Rows(0).Item("IGST")) / 100), "0.00")
                        '    TXTACTRATE.Text = Format(Val(txtdefrate.Text.Trim), "0.00")
                        'End If

                    End If
                End If
            End If
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

    Sub fillCONSUMPTIONgrid()

        If gridDoubleClick = False Then
            GRIDCONSUMPTION.Rows.Add(Val(txtsrno.Text.Trim), CMBITEMNAME.Text.Trim, Format(Val(txtdefqty.Text.Trim), "0.00"), Format(Val(txtactqty.Text.Trim), "0.00"), cmbunit.Text.Trim, Format(Val(txtdefrate.Text.Trim), "0.00"), Format(Val(TXTACTRATE.Text.Trim), "0.00"), 0, 0)
            getsrno(GRIDCONSUMPTION)
        ElseIf gridDoubleClick = True Then
            GRIDCONSUMPTION.Item(GCONSUMEDSRNO.Index, tempRow).Value = Val(txtsrno.Text.Trim)
            GRIDCONSUMPTION.Item(GITEMNAME.Index, tempRow).Value = CMBITEMNAME.Text.Trim
            GRIDCONSUMPTION.Item(GdefQTY.Index, temprow).Value = Format(Val(txtdefqty.Text.Trim), "0.000")
            GRIDCONSUMPTION.Item(GactQty.Index, temprow).Value = Format(Val(txtactqty.Text.Trim), "0.000")
            GRIDCONSUMPTION.Item(GUNIT.Index, tempRow).Value = cmbunit.Text.Trim
            GRIDCONSUMPTION.Item(GdefRATE.Index, temprow).Value = Format(Val(txtdefrate.Text.Trim), "0.000")
            GRIDCONSUMPTION.Item(gActRate.Index, temprow).Value = Format(Val(TXTACTRATE.Text.Trim), "0.000")
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
        'cmbunit.Text = ""
        TXTACTRATE.Clear()
        txtdefrate.Clear()

        'as we want to take the same wt for all
        'TXTWT.Clear()

        txtsrno.Focus()

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

    Private Sub CMBFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Validated
        Try
            If CMBFROM.Text.Trim <> "" Then CMBFROM.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmachineno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmachineno.GotFocus
        Try
            'FILLMACHINENO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.GotFocus
        Try
            If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID ", " AND DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORvalidate(CMBCOLOR, e, Me, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID", " AND  DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")


            'WE WILL CALC OON CLICK OF CALCBUTTON
            If ClientName <> "DHANLAXMI" And ClientName <> "MONORAM" Then
                If CMBCOLOR.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" Then
                    Dim dttable As New DataTable
                    Dim OBJCMN As New ClsCommon
                    GRIDCONSUMPTION.RowCount = 0
                    dttable = OBJCMN.search("  ITEMMASTER.item_name AS ITEM, DYEINGRECIPE_CONSUMPTION.DYEING_QTY, DYEINGRECIPE_DESC.DYEING_PERPCS, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE ", "", "      DYEINGRECIPE INNER JOIN DYEINGRECIPE_DESC ON DYEINGRECIPE.DYEING_ID = DYEINGRECIPE_DESC.DYEING_ID AND DYEINGRECIPE.DYEING_CMPID = DYEINGRECIPE_DESC.DYEING_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DYEINGRECIPE_CONSUMPTION ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE_CONSUMPTION.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_SRNO = DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE_CONSUMPTION.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE_CONSUMPTION.DYEING_YEARID INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DYEINGRECIPE.DYEING_PROCESSID = PROCESSMASTER.PROCESS_ID AND DYEINGRECIPE.DYEING_CMPID = PROCESSMASTER.PROCESS_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND COLORMASTER.COLOR_name ='" & CMBCOLOR.Text.Trim & "' AND dyeingRECIPE.dyeing_NO ='" & CMBDYEING.Text & "' AND dyeingRECIPE.dyeing_CMPID =" & CmpId & " AND dyeingRECIPE.dyeing_LOCATIONID =" & Locationid & " AND dyeingRECIPE.dyeing_YEARID =" & YearId)
                    If dttable.Rows.Count > 0 Then
                        For j As Integer = 0 To dttable.Rows.Count - 1
                            GRIDCONSUMPTION.Rows.Add(0, dttable.Rows(j).Item("item"), Format(Val((TXTTOTALPCS.Text) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), "0.000"), Format(Val((TXTTOTALPCS.Text) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), "0.000"), "KGS", Val(dttable.Rows(j).Item("RATE")), Val(dttable.Rows(j).Item("RATE")))
                        Next
                    End If
                    getsrno(GRIDCONSUMPTION)
                    TOTALCONSUMPTION()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDYEING.GotFocus
        If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
    End Sub

    Private Sub CMBDYEING_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDYEING.Validated
        If CMBDYEING.Text <> "" Then CMBDYEING.Enabled = False
    End Sub

    Private Sub CMBDYEING_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDYEING.Validating
        Try
            If CMBDYEING.Text.Trim <> "" Then dyeingvalidate(CMBDYEING, e, Me)

            CMBCOLOR.Text = ""
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    '    Private Sub TextBox2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '        If Val(TXTAPPMTRS.Text) <> 0 And Val(TXTAPPPCS.Text) <> 0 Then
    '            Dim MAX, MIN, APPROX As Integer
    '            Dim summ As Double
    '            APPROX = Val(TXTAPPMTRS.Text) / Val(TXTAPPPCS.Text)
    '            MAX = APPROX
    '            MIN = APPROX
    '            Dim DT As New DataTable
    '            DT.Columns.Add("PIECE")
    '            DT.Columns.Add("DESC")
    '            DT.Columns.Add("IN", System.Type.GetType("System.Decimal"))
    '            DT.Columns.Add("REC", System.Type.GetType("System.Decimal"))
    '            DT.Columns.Add("DIFF", System.Type.GetType("System.Decimal"))
    '            DT.Columns.Add("WT", System.Type.GetType("System.Decimal"))
    '            DT.Columns.Add("DONE")
    '            DT.Columns.Add("CHECK")
    '            DT.Columns.Add("CHECKSRNO")
    '            DT.Columns.Add("MFGNO")
    '            DT.Columns.Add("MFGSRNO")
    '            DT.Columns.Add("LOTNO")
    '            DT.Columns.Add("LOTSRNO")
    '            DT.Columns.Add("PER")
    '            DT.Columns.Add("TYPE")
    '            DT.Columns.Add("INPCS", System.Type.GetType("System.Decimal"))

    '            DT.Columns.Add("OUTPCS")
    'line1:
    '            MAX = MAX + 1
    '            MIN = MIN - 1
    '            For Each ROW As DataGridViewRow In GRIDMFG.Rows
    '                If ROW.Cells(GRECDMTRS.Index).Value > MIN And ROW.Cells(GRECDMTRS.Index).Value <= MAX Then
    '                    DT.Rows.Add(ROW.Cells(1).Value, ROW.Cells(2).Value, ROW.Cells(3).Value, ROW.Cells(4).Value, ROW.Cells(5).Value, ROW.Cells(6).Value, ROW.Cells(7).Value, ROW.Cells(8).Value, ROW.Cells(9).Value, ROW.Cells(10).Value, ROW.Cells(11).Value, ROW.Cells(12).Value, ROW.Cells(13).Value, ROW.Cells(14).Value, ROW.Cells(15).Value)
    '                End If
    '            Next
    '            If DT.Rows.Count < Val(TXTAPPPCS.Text) Then
    '                GoTo line1
    '            ElseIf DT.Rows.Count >= Val(TXTAPPPCS.Text) Then
    '                GRIDMFG.RowCount = 0

    'line2:
    '                summ = DT.Compute("sum([rec])", "")
    '                If APPROX <> Format(summ / DT.Rows.Count, "0") Then
    '                    APPROX = summ / (DT.Rows.Count)
    '                    MAX = APPROX
    '                    MIN = APPROX
    '                End If
    '                MAX = MAX + 1
    '                MIN = MIN - 1
    'line3:
    '                If GRIDMFG.RowCount <> Val(TXTAPPPCS.Text) Then
    '                    For i As Integer = 0 To DT.Rows.Count - 1
    '                        If Val(DT.Rows(i).Item("rec")) > Val(MIN) And Val(DT.Rows(i).Item("rec")) < Val(MAX) Then
    '                            GRIDMFG.Rows.Add(0, DT.Rows(i).Item(0), DT.Rows(i).Item(1), DT.Rows(i).Item(2), DT.Rows(i).Item(3), DT.Rows(i).Item(4), DT.Rows(i).Item(5), DT.Rows(i).Item(6), DT.Rows(i).Item(7), DT.Rows(i).Item(8), DT.Rows(i).Item(9), DT.Rows(i).Item(10), DT.Rows(i).Item(11), DT.Rows(i).Item(12), DT.Rows(i).Item(13), DT.Rows(i).Item(14))
    '                            If GRIDMFG.RowCount = Val(TXTAPPPCS.Text) Then GoTo line4
    '                            DT.Rows.RemoveAt(i)
    '                            GoTo line3

    '                        End If
    '                    Next

    '                    If GRIDMFG.RowCount < TXTAPPPCS.Text Then
    '                        GoTo line2
    '                    End If
    '                    If CMBCOLOR.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" Then
    '                        Dim dttable As New DataTable
    '                        Dim OBJCMN As New ClsCommon
    '                        GRIDCONSUMPTION.RowCount = 0
    '                        dttable = OBJCMN.search("  ITEMMASTER.item_name AS ITEM, DYEINGRECIPE_CONSUMPTION.DYEING_QTY, DYEINGRECIPE_DESC.DYEING_PERPCS, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE ", "", "      DYEINGRECIPE INNER JOIN DYEINGRECIPE_DESC ON DYEINGRECIPE.DYEING_ID = DYEINGRECIPE_DESC.DYEING_ID AND DYEINGRECIPE.DYEING_CMPID = DYEINGRECIPE_DESC.DYEING_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DYEINGRECIPE_CONSUMPTION ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE_CONSUMPTION.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_SRNO = DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE_CONSUMPTION.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE_CONSUMPTION.DYEING_YEARID INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DYEINGRECIPE.DYEING_PROCESSID = PROCESSMASTER.PROCESS_ID AND DYEINGRECIPE.DYEING_CMPID = PROCESSMASTER.PROCESS_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = PROCESSMASTER.PROCESS_YEARID ", " AND  PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND COLORMASTER.COLOR_name ='" & CMBCOLOR.Text.Trim & "' AND dyeingRECIPE.dyeing_NO ='" & CMBDYEING.Text & "' AND dyeingRECIPE.dyeing_CMPID =" & CmpId & " AND dyeingRECIPE.dyeing_LOCATIONID =" & Locationid & " AND dyeingRECIPE.dyeing_YEARID =" & YearId)
    '                        If dttable.Rows.Count > 0 Then
    '                            For j As Integer = 0 To dttable.Rows.Count - 1
    '                                GRIDCONSUMPTION.Rows.Add(0, dttable.Rows(j).Item("item"), Format(Val((GRIDMFG.RowCount) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), "0.00"), Format(Val((GRIDMFG.RowCount) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEING_PERPCS"))), "0.000"), "KGS", Val(dttable.Rows(j).Item("RATE")), Val(dttable.Rows(j).Item("RATE")))
    '                            Next
    '                        End If
    '                        getsrno(GRIDCONSUMPTION)
    '                        TOTALCONSUMPTION()
    '                    End If
    '                End If
    '            End If
    'line4:
    '            getsrno(GRIDMFG)
    '            TOTAL()
    '        End If
    '    End Sub

    Private Sub cmbprgno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprgno.GotFocus
        Try
            If cmbprgno.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" DISTINCT  PRGMASTER_DESC.prg_no ", "", "    PRGMASTER INNER JOIN PROCESSMASTER ON PRGMASTER.PRG_PROCESSID = PROCESSMASTER.PROCESS_ID AND PRGMASTER.PRG_cmpid = PROCESSMASTER.PROCESS_CMPID AND  PRGMASTER.PRG_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PRGMASTER.PRG_yearid = PROCESSMASTER.PROCESS_YEARID INNER JOIN PRGMASTER_DESC ON PRGMASTER.PRG_no = PRGMASTER_DESC.PRG_no AND PRGMASTER.PRG_cmpid = PRGMASTER_DESC.PRG_cmpid AND PRGMASTER.PRG_locationid = PRGMASTER_DESC.PRG_locationid AND PRGMASTER.PRG_yearid = PRGMASTER_DESC.PRG_yearid ", " and PROCESSMASTER.PROCESS_name='" & CMBTO.Text & "' and  PRGMASTER_DESC.prg_closed ='False' and  PRGMASTER_DESC.prg_cmpid=" & CmpId & " and  PRGMASTER_DESC.prg_locationid = " & Locationid & " and  PRGMASTER_DESC.prg_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "prg_no"
                    cmbprgno.DataSource = dt
                    cmbprgno.DisplayMember = "prg_no"
                    cmbprgno.Text = ""
                End If
                cmbprgno.SelectAll()
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

    Private Sub txthelpers_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthelpers.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txthsrno_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthsrno.Enter

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

    Private Sub TXTAPPPCS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub cmbshift_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbshift.Validated
        If cmbshift.Text = "Day" Then
            INTIME.Value = Now.Date & " 08:01:00 AM"
            OUTTIME.Value = Now.Date & " 07:59:00 PM"
        Else
            INTIME.Value = Now.Date & " 08:01:00 PM"
            OUTTIME.Value = Now.Date & " 07:59:00 AM"

        End If
    End Sub

    Private Sub CHKPCS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPCS.CheckedChanged
        If CHKPCS.Checked = True Then
            If GRIDMFG.RowCount > 0 Then
                If GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GINPCS.Index).Value > 1 Then
                    For I As Integer = 1 To GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GINPCS.Index).Value

                        GRIDMFG.Rows.Add(0, "FRESH", "", Format(Val(GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GMTRS.Index).Value) / GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GINPCS.Index).Value, "0.00"), 1, Format(Val(GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GMTRS.Index).Value) / GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GINPCS.Index).Value, "0.00"), 0.0, Format(Val(GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GWT.Index).Value), "0.00"), 0, GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GGRNCHECKNO.Index).Value, GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GGRNCHECKSRNO.Index).Value, GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GMFGNO.Index).Value, GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GMFGSRNO.Index).Value, GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GLOTNO.Index).Value, GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GLOTSRNO.Index).Value, 0, Val(GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(GRATE.Index).Value), GRIDMFG.Rows(GRIDMFG.CurrentRow.Index).Cells(gtype.Index).Value, "", "", 0, 0)


                    Next I
                    GRIDMFG.Rows.RemoveAt(GRIDMFG.CurrentRow.Index)
                    getsrno(GRIDMFG)
                End If
            End If
        End If
    End Sub

    Sub PRINTREPORT()
        Try
            If CMBTO.Text.Trim = "READY FOR PROCESS" Or CMBTO.Text.Trim = "BHATTI" Then
                If MsgBox("Wish To Print ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJMFG As New mfgdesign
                OBJMFG.frmstring = "MFGREPORT"
                OBJMFG.selfor_po = "{MFGMASTER.MFG_NO} = " & Val(TXTMFGNO.Text.Trim) & " AND {MFGMASTER.MFG_YEARID} = " & YearId
                OBJMFG.MdiParent = MDIMain
                OBJMFG.Show()
            End If

            If (ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM") And CMBTO.Text.Trim = "DYEING" Then
                If MsgBox("Wish To Print Dyeing Issue Slip?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJDYEING As New mfgdesign
                OBJDYEING.frmstring = "DYEINGISSUESLIP"
                OBJDYEING.selfor_po = "{MFGMASTER.MFG_NO} = " & Val(TXTMFGNO.Text.Trim) & " AND {MFGMASTER.MFG_YEARID} = " & YearId
                OBJDYEING.MdiParent = MDIMain

                'GET DISTINCT LOTNOS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("DISTINCT MFG_LOTNO AS LOTNO, GREYDETAIL_VIEW.WT ", "", "MFGMASTER_DESC LEFT OUTER JOIN GREYDETAIL_VIEW ON MFGMASTER_DESC.MFG_LOTNO = GREYDETAIL_VIEW.LOTNO AND MFGMASTER_DESC.MFG_YEARID = GREYDETAIL_VIEW.YEARID ", " AND MFGMASTER_DESC.MFG_NO = " & Val(TXTMFGNO.Text.Trim) & " AND MFGMASTER_DESC.MFG_YEARID = " & YearId)
                For Each DTROW As DataRow In DT.Rows
                    If OBJDYEING.QUALITYWT = 0 Then OBJDYEING.QUALITYWT = Format(Val(DTROW("WT")), "0.000")
                    If OBJDYEING.LOTNO = "" Then OBJDYEING.LOTNO = DTROW("LOTNO") Else OBJDYEING.LOTNO = OBJDYEING.LOTNO & "|" & DTROW("LOTNO")
                Next

                OBJDYEING.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        For Each row As DataGridViewRow In GRIDMFG.Rows
            row.Cells(GOUTMTRS.Index).Value = row.Cells(GMTRS.Index).Value
            row.Cells(goutpcs.Index).Value = row.Cells(GINPCS.Index).Value
            row.Cells(GDONE.Index).Value = True
        Next
    End Sub

    Private Sub CMDCALC_Click(sender As Object, e As EventArgs) Handles CMDCALC.Click
        Try
            'THIS CALC IS DIFFERENT FOR DHANLAXMI
            If CMBCOLOR.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" And Val(TXT100MTRSWT.Text.Trim) > 0 Then
                Dim TOTALWT As Double = Format((Val(TXT100MTRSWT.Text.Trim) * Val(LBLTOTALRECDMTRS.Text)) / 100, "0.00")
                Dim dttable As New DataTable
                Dim OBJCMN As New ClsCommon
                Dim RATE As Double = 0.0
                GRIDCONSUMPTION.RowCount = 0
                dttable = OBJCMN.search("  ITEMMASTER.item_name AS ITEM, DYEINGRECIPE_CONSUMPTION.DYEING_QTY, DYEINGRECIPE_DESC.DYEING_PERPCS, ISNULL(DYEINGRECIPE_CONSUMPTION.DYEING_NOCALC,0) AS NOCALC, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE, DYEINGRECIPE.DYEING_GMS AS DYEINGWT, ISNULL(HSNMASTER.HSN_IGST,0) AS IGST ", "", "      DYEINGRECIPE INNER JOIN DYEINGRECIPE_DESC ON DYEINGRECIPE.DYEING_ID = DYEINGRECIPE_DESC.DYEING_ID AND DYEINGRECIPE.DYEING_CMPID = DYEINGRECIPE_DESC.DYEING_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN COLORMASTER ON DYEINGRECIPE_DESC.DYEING_MATCHINGID = COLORMASTER.COLOR_id AND DYEINGRECIPE_DESC.DYEING_CMPID = COLORMASTER.COLOR_cmpid AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = COLORMASTER.COLOR_locationid AND DYEINGRECIPE_DESC.DYEING_YEARID = COLORMASTER.COLOR_yearid INNER JOIN DYEINGRECIPE_CONSUMPTION ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE_CONSUMPTION.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_SRNO = DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE_CONSUMPTION.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE_CONSUMPTION.DYEING_YEARID INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON DYEINGRECIPE.DYEING_PROCESSID = PROCESSMASTER.PROCESS_ID AND DYEINGRECIPE.DYEING_CMPID = PROCESSMASTER.PROCESS_CMPID AND DYEINGRECIPE.DYEING_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND DYEINGRECIPE.DYEING_YEARID = PROCESSMASTER.PROCESS_YEARID  LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND  PROCESSMASTER.PROCESS_NAME = '" & CMBTO.Text.Trim & "' AND COLORMASTER.COLOR_name ='" & CMBCOLOR.Text.Trim & "' AND dyeingRECIPE.dyeing_NO ='" & CMBDYEING.Text & "' AND dyeingRECIPE.dyeing_CMPID =" & CmpId & " AND dyeingRECIPE.dyeing_LOCATIONID =" & Locationid & " AND dyeingRECIPE.dyeing_YEARID =" & YearId & " ORDER BY DYEINGRECIPE_CONSUMPTION.DYEING_CONSRNO")
                If dttable.Rows.Count > 0 Then
                    For j As Integer = 0 To dttable.Rows.Count - 1

                        'GET LAST PURCHASE RATE FROM PURCHASEMASTER IRRESPECTIVE TO YEARID
                        'DONT PUT YEARID CLAUSE JUST FECH RATES OF LAST PURCHASE WITH RESPECT TO ITEMNAME
                        Dim DTRATE As DataTable = OBJCMN.search(" TOP 1 ISNULL(PURCHASEMASTER_DESC.BILL_RATE, 0) AS RATE, ISNULL(HSNMASTER.HSN_IGST,0) AS IGST ", "", " PURCHASEMASTER_DESC INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID AND  PURCHASEMASTER_DESC.BILL_yearid = PURCHASEMASTER.BILL_YEARID  LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID ", " AND ITEMMASTER.ITEM_NAME = '" & dttable.Rows(j).Item("item") & "' ORDER BY PURCHASEMASTER.BILL_DATE DESC ")
                        If DTRATE.Rows.Count > 0 Then
                            RATE = Val(DTRATE.Rows(0).Item("RATE"))

                            'REMOVED AS PER PAREEN ON 23-06-22
                            'AGAIN STARTED AS PER REQUEST ON 28-03-23
                            'AGAIN REMOVED AS PER REQUEST ON 12-04-22
                            ''WE HAVE FETCHED RATE WITH GST FOR MONOGRAM
                            'If ClientName = "MONOGRAM" Then
                            '    RATE = Format(Val(RATE) + (Val(RATE) * Val(DTRATE.Rows(0).Item("IGST")) / 100), "0.00")
                            'End If

                        Else
                            RATE = Val(dttable.Rows(j).Item("RATE"))

                            'REMOVED AS PER PAREEN ON 23-06-22
                            'AGAIN STARTED AS PER REQUEST ON 28-03-23
                            'AGAIN REMOVED AS PER REQUEST ON 12-04-22
                            ''WE HAVE FETCHED RATE WITH GST FOR MONOGRAM
                            'If ClientName = "MONOGRAM" Then
                            '    RATE = Format(Val(RATE) + (Val(RATE) * Val(dttable.Rows(j).Item("IGST")) / 100), "0.00")
                            'End If
                        End If


                        'IF NO CALC IS CHECKED IN DYEINGRECIPE THEN DONT CALC WITH RESPECT TO GRAMS
                        If Convert.ToBoolean(dttable.Rows(j).Item("NOCALC")) = False Then
                            GRIDCONSUMPTION.Rows.Add(0, dttable.Rows(j).Item("item"), Format(Val((TOTALWT) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEINGWT"))), "0.000"), Format(Val((TOTALWT) * Val(dttable.Rows(j).Item("DYEING_QTY")) / Val(dttable.Rows(j).Item("DYEINGWT"))), "0.000"), "KGS", RATE, RATE)
                        Else
                            GRIDCONSUMPTION.Rows.Add(0, dttable.Rows(j).Item("item"), Format(Val(dttable.Rows(j).Item("DYEING_QTY")), "0.000"), Format(Val(dttable.Rows(j).Item("DYEING_QTY")), "0.000"), "KGS", RATE, RATE)
                        End If
                    Next
                End If
                getsrno(GRIDCONSUMPTION)
                TOTALCONSUMPTION()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Mfg_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM" Then
                cmbcontractor.BackColor = Color.LemonChiffon
                LBLWT.Visible = True
                TXT100MTRSWT.Visible = True
                CMDCALC.Visible = True
                txtdefqty.Enabled = False
                GdefQTY.ReadOnly = True
            End If
            If UserName = "Admin" Then CMBGODOWN.Enabled = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validated(sender As Object, e As EventArgs) Handles CMBITEMNAME.Validated
        Try
            GETITEMSTOCK(CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETITEMSTOCK(ITEMNAME As String)
        Try
            If ITEMNAME = "" Then Exit Sub
            TXTITEMSTOCK.Clear()
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT ROUND(BALANCE,2) AS TOTALWT FROM STORESTOCK WHERE YEARID = " & YearId & " AND ITEMNAME = '" & ITEMNAME & "'", "", "")
            If DT.Rows.Count > 0 Then TXTITEMSTOCK.Text = Val(DT.Rows(0).Item("TOTALWT"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCONSUMPTION_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDCONSUMPTION.CellClick
        Try
            If GRIDCONSUMPTION.CurrentRow.Cells(GITEMNAME.Index).Value <> "" Then GETITEMSTOCK(GRIDCONSUMPTION.CurrentRow.Cells(GITEMNAME.Index).Value)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class