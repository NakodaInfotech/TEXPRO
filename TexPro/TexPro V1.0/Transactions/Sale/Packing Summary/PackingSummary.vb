
Imports System.ComponentModel
Imports BL

Public Class PackingSummary

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Public transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public TEMPPACKNO As Integer     'used for poation no while editing
    Public templotno As Integer     'used for poation no while editing
    Dim GRIDINVOICEDOUBLECLICK, GRIDBALEDOUBLECLICK, GRIDBLEACHDOUBLECLICK As Boolean
    Dim temprow, TEMPINVROW, TEMPBALEROW, TEMPBLEACHROW As Integer
    Dim TEMPPACKINGSUMMARY As Integer
    Public Shared SELECTMFGTABLE As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim billcopy As Boolean = False      'USED FOR RIGHT MANAGEMAENT
    Dim OPENINGCLAUSEFORLOT As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()
        tstxtbillno.Clear()
        CMBNAME.Text = ""
        CMBMERCHANT.Text = ""
        TXTFINALMTRS.Clear()
        TXTLONGATION.Clear()

        TXTFOLD.Clear()
        TXTNEWFOLD.Clear()

        TXTSUMMNO.Clear()
        SUMMDATE.Value = Mydate

        TXTREMARKS.Clear()
        TXTSAMPLEMTRS.Clear()
        TXTFENTMTRS.Clear()
        TXTSHORTPCS.Clear()
        TXTSHORTMTRS.Clear()
        TXTREJPCS.Clear()
        TXTREJMTRS.Clear()
        TXTGOODGUTMTRS.Clear()
        TXTRACKSMTRS.Clear()
        TXTLESSPER.Clear()
        TXTLESSMTRS.Clear()


        lbllocked.Visible = False
        PBlock.Visible = False

        TXTLOTSRNO.Clear()
        CMBLOTNO.Text = ""
        CMBGRIDQUALITY.Text = ""
        TXTLOTPCS.Clear()
        TXTLOTMTRS.Clear()
        TXTLOTWT.Clear()
        GRIDLOT.RowCount = 0


        TXTBALESRNO.Clear()
        TXTBALENO.Clear()
        TXTMERCHANT.Clear()
        TXTBALEPCS.Clear()
        TXTBALEMTRS.Clear()
        TXTBALECONVMTRS.Clear()
        TXTBALEFROMNO.Clear()
        TXTBALEFROMTYPE.Clear()
        GRIDBALE.RowCount = 0


        TXTINVSRNO.Clear()
        TXTINVOICENO.Clear()
        TXTINVPCS.Clear()
        TXTINVMTRS.Clear()
        GRIDINVOICE.RowCount = 0
        GRIDBLEACH.RowCount = 0


        TXTBSRNO.Text = GRIDBLEACH.RowCount + 1
        TXTBDECMTRS.Clear()
        TXTBWT.Clear()
        TXTBREEDPICK.Clear()
        TXTBWIDTH.Clear()
        TXTBFOLD.Clear()
        TXTBGRAMS.Clear()
        TXTTOTALBDECMTRS.Clear()
        TXTTOTALBWT.Clear()
        TXTTOTALBGRAMS.Clear()
        TXTAVGDECMTRS.Clear()
        TXTADDROWS.Clear()
        TXTAVGWT.Clear()
        TXTAVGGRAMS.Clear()


        TXTREADYWIDTH.Clear()


        gridDoubleClick = False
        GRIDINVOICEDOUBLECLICK = False
        GRIDBALEDOUBLECLICK = False

        GETMAXNO()

        CHKCUTTINGCHGS.CheckState = CheckState.Unchecked
        CHKCARTONCHGS.CheckState = CheckState.Unchecked
        CHKFELT.CheckState = CheckState.Unchecked

        LBLTOTALLOTPCS.Text = 0
        LBLTOTALLOTMTRS.Text = 0
        LBLTOTALLOTWT.Text = 0
        LBLTOTALBALES.Text = 0
        LBLTOTALBALEPCS.Text = 0
        LBLTOTALBALEMTRS.Text = 0
        LBLTOTALBALECONVMTRS.Text = 0
        LBLTOTALINVPCS.Text = 0
        LBLTOTALINVMTRS.Text = 0

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALLOTPCS.Text = 0
            LBLTOTALLOTMTRS.Text = 0
            LBLTOTALLOTWT.Text = 0
            LBLTOTALBALES.Text = 0
            LBLTOTALBALEPCS.Text = 0
            LBLTOTALBALEMTRS.Text = 0
            LBLTOTALBALECONVMTRS.Text = 0
            LBLTOTALINVPCS.Text = 0
            LBLTOTALINVMTRS.Text = 0

            TXTFINALMTRS.Text = 0
            TXTLONGATION.Text = 0

            TXTTOTALBDECMTRS.Text = 0.0
            TXTTOTALBWT.Text = 0.0
            TXTTOTALBGRAMS.Text = 0.0
            TXTAVGDECMTRS.Text = 0.0
            TXTAVGWT.Text = 0.0
            TXTAVGGRAMS.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDLOT.Rows
                LBLTOTALLOTPCS.Text = Format(Val(LBLTOTALLOTPCS.Text) + Val(ROW.Cells(GLOTPCS.Index).Value), "0.00")
                LBLTOTALLOTMTRS.Text = Format(Val(LBLTOTALLOTMTRS.Text) + Val(ROW.Cells(GLOTMTRS.Index).Value), "0.00")
                LBLTOTALLOTWT.Text = Format(Val(LBLTOTALLOTWT.Text) + Val(ROW.Cells(GLOTWT.Index).Value), "0.000")
            Next

            For Each ROW As DataGridViewRow In GRIDBALE.Rows
                LBLTOTALBALEPCS.Text = Format(Val(LBLTOTALBALEPCS.Text) + Val(ROW.Cells(GBALEPCS.Index).Value), "0.00")
                LBLTOTALBALEMTRS.Text = Format(Val(LBLTOTALBALEMTRS.Text) + Val(ROW.Cells(GBALEMTRS.Index).Value), "0.00")
                LBLTOTALBALECONVMTRS.Text = Format(Val(LBLTOTALBALECONVMTRS.Text) + Val(ROW.Cells(GBALECONVMTRS.Index).Value), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
                LBLTOTALINVPCS.Text = Format(Val(LBLTOTALINVPCS.Text) + Val(ROW.Cells(GINVPCS.Index).Value), "0.00")
                LBLTOTALINVMTRS.Text = Format(Val(LBLTOTALINVMTRS.Text) + Val(ROW.Cells(GINVMTRS.Index).Value), "0.00")
            Next

            If Val(TXTLESSPER.Text.Trim) <> 0 Then TXTLESSMTRS.Text = Format((Val(LBLTOTALLOTMTRS.Text.Trim) * Val(TXTLESSPER.Text.Trim)) / 100, "0.00")

            TXTFINALMTRS.Text = Format(Val(LBLTOTALBALECONVMTRS.Text.Trim) + Val(TXTSAMPLEMTRS.Text.Trim) + Val(TXTFENTMTRS.Text.Trim) + Val(TXTSHORTMTRS.Text.Trim) + Val(TXTREJMTRS.Text.Trim) + Val(TXTGOODGUTMTRS.Text.Trim) + Val(TXTRACKSMTRS.Text.Trim) + Val(TXTLESSMTRS.Text.Trim), "0.00")
            TXTLONGATION.Text = Format(((Val(TXTFINALMTRS.Text.Trim) - Val(LBLTOTALLOTMTRS.Text.Trim)) / Val(LBLTOTALLOTMTRS.Text.Trim)) * 100, "0.00")


            For Each ROW As DataGridViewRow In GRIDBLEACH.Rows
                If ROW.Cells(BSRNO.Index).Value <> Nothing Then
                    TXTTOTALBDECMTRS.Text = Format(Val(TXTTOTALBDECMTRS.Text) + Val(ROW.Cells(BMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALBWT.Text = Format(Val(TXTTOTALBWT.Text) + Val(ROW.Cells(BWT.Index).EditedFormattedValue), "0.000")

                    ROW.Cells(BGRAMS.Index).Value = Format(Val(ROW.Cells(BWT.Index).EditedFormattedValue) / Val(ROW.Cells(BMTRS.Index).EditedFormattedValue), "0.000")
                    ROW.Cells(BGRAMS.Index).Value = Format(Val(ROW.Cells(BGRAMS.Index).EditedFormattedValue) + Val(ROW.Cells(BGRAMS.Index).EditedFormattedValue) * ((100 - Val(ROW.Cells(BFOLD.Index).EditedFormattedValue)) / 100), "0.000")

                    TXTTOTALBGRAMS.Text = Format(Val(TXTTOTALBGRAMS.Text) + Val(ROW.Cells(BGRAMS.Index).EditedFormattedValue), "0.000")
                End If
            Next

            LBLTOTALBALES.Text = GRIDBALE.RowCount
            TXTAVGDECMTRS.Text = Format(Val(TXTTOTALBDECMTRS.Text) / Val(GRIDBLEACH.RowCount), "0.00")
            TXTAVGWT.Text = Format(Val(TXTTOTALBWT.Text) / Val(GRIDBLEACH.RowCount), "0.000")
            TXTAVGGRAMS.Text = Format(Val(TXTTOTALBGRAMS.Text) / Val(GRIDBLEACH.RowCount), "0.000")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Sub GETMAXNO()
        Dim DTTABLE As DataTable = getmax(" isnull(max(PS_NO),0) + 1 ", "PACKINGSUMMARY", " AND PS_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSUMMNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub TXTLOTPCS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTLOTPCS.KeyPress, TXTBALEPCS.KeyPress, TXTINVPCS.KeyPress, TXTSHORTPCS.KeyPress, TXTREJPCS.KeyPress, TXTSUMMNO.KeyPress, TXTBALENO.KeyPress, TXTINVOICENO.KeyPress, TXTNEWFOLD.KeyPress, TXTADDROWS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTLOTMTRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTLOTMTRS.KeyPress, TXTLOTWT.KeyPress, TXTBALEMTRS.KeyPress, TXTINVMTRS.KeyPress, TXTBALECONVMTRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Select Party Name ")
                BLN = False
            End If

            If CMBMERCHANT.Text.Trim.Length = 0 Then
                EP.SetError(CMBMERCHANT, "Please Enter Quality Name")
                BLN = False
            End If

            Dim OBJCMN As New ClsCommon
            Dim dt As New DataTable
            If edit = False Then
                dt = OBJCMN.search(" PS_NO ", "", " PACKINGSUMMARY ", "  and PS_NO=" & Val(TXTSUMMNO.Text) & " and PS_yearid= " & YearId)
                If dt.Rows.Count > 0 Then
                    EP.SetError(TXTSUMMNO, "Packing No. Already exist?")
                    BLN = False
                End If
            End If

            If ClientName <> "DHANLAXMI" And ClientName <> "SHUBHLAXMI" Then
                If GRIDLOT.RowCount = 0 Then
                    EP.SetError(CMBNAME, "Enter Lot Details")
                    BLN = False
                End If
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Invoice Made, Delete Invoice First")
                BLN = False
            End If

            If Not datecheck(SUMMDATE.Value) Then BLN = False

            Return BLN
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Val(TXTSUMMNO.Text))
            alParaval.Add(SUMMDATE.Value.Date)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBMERCHANT.Text.Trim)
            alParaval.Add(Val(TXTFINALMTRS.Text.Trim))
            alParaval.Add(Val(TXTLONGATION.Text.Trim))

            alParaval.Add(Val(TXTFOLD.Text.Trim))
            alParaval.Add(Val(TXTNEWFOLD.Text.Trim))


            alParaval.Add(Val(TXTSAMPLEMTRS.Text.Trim))
            alParaval.Add(Val(TXTSHORTPCS.Text.Trim))
            alParaval.Add(Val(TXTREJPCS.Text.Trim))

            alParaval.Add(Val(TXTFENTMTRS.Text.Trim))
            alParaval.Add(Val(TXTSHORTMTRS.Text.Trim))
            alParaval.Add(Val(TXTREJMTRS.Text.Trim))

            alParaval.Add(Val(TXTGOODGUTMTRS.Text.Trim))
            alParaval.Add(Val(TXTRACKSMTRS.Text.Trim))
            alParaval.Add(Val(TXTLESSPER.Text.Trim))
            alParaval.Add(Val(TXTLESSMTRS.Text.Trim))

            alParaval.Add(TXTREADYWIDTH.Text.Trim)

            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(Val(LBLTOTALLOTPCS.Text))
            alParaval.Add(Val(LBLTOTALLOTMTRS.Text))
            alParaval.Add(Val(LBLTOTALLOTWT.Text))
            alParaval.Add(Val(LBLTOTALBALES.Text))
            alParaval.Add(Val(LBLTOTALBALEPCS.Text))
            alParaval.Add(Val(LBLTOTALBALEMTRS.Text))
            alParaval.Add(Val(LBLTOTALBALECONVMTRS.Text))
            alParaval.Add(Val(LBLTOTALINVPCS.Text))
            alParaval.Add(Val(LBLTOTALINVMTRS.Text))


            alParaval.Add(Val(TXTTOTALBDECMTRS.Text.Trim))
            alParaval.Add(Val(TXTTOTALBWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALBGRAMS.Text.Trim))
            alParaval.Add(Val(TXTAVGDECMTRS.Text.Trim))
            alParaval.Add(Val(TXTAVGWT.Text.Trim))
            alParaval.Add(Val(TXTAVGGRAMS.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)
            alParaval.Add(Userid)




            Dim LOTSRNO As String = ""
            Dim LOTNO As String = ""
            Dim LOTQUALITY As String = ""
            Dim LOTRECDDATE As String = ""
            Dim LOTPCS As String = ""
            Dim LOTMTRS As String = ""
            Dim LOTWT As String = ""

            Dim BALESRNO As String = ""
            Dim BALENO As String = ""
            Dim MARCHANT As String = ""
            Dim BALEPCS As String = ""
            Dim BALEMTRS As String = ""
            Dim BALECONVMTRS As String = ""
            Dim BALEFROMNO As String = ""
            Dim BALEFROMTYPE As String = ""

            Dim INVSRNO As String = ""
            Dim INVOICENO As String = ""
            Dim INVPCS As String = ""
            Dim INVMTRS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDLOT.Rows
                If row.Cells(0).Value <> Nothing Then
                    If LOTSRNO = "" Then
                        LOTSRNO = Val(row.Cells(GLOTSRNO.Index).Value)
                        LOTNO = Val(row.Cells(GLOTNO.Index).Value)
                        LOTQUALITY = row.Cells(GQUALITY.Index).Value
                        LOTRECDDATE = Format(Convert.ToDateTime(row.Cells(GRECDDATE.Index).Value).Date, "MM/dd/yyyy")
                        LOTPCS = Val(row.Cells(GLOTPCS.Index).Value)
                        LOTMTRS = Val(row.Cells(GLOTMTRS.Index).Value)
                        LOTWT = Val(row.Cells(GLOTWT.Index).Value)
                    Else
                        LOTSRNO = LOTSRNO & "|" & Val(row.Cells(GLOTSRNO.Index).Value)
                        LOTNO = LOTNO & "|" & Val(row.Cells(GLOTNO.Index).Value)
                        LOTQUALITY = LOTQUALITY & "|" & row.Cells(GQUALITY.Index).Value
                        LOTRECDDATE = LOTRECDDATE & "|" & Format(Convert.ToDateTime(row.Cells(GRECDDATE.Index).Value).Date, "MM/dd/yyyy")
                        LOTPCS = LOTPCS & "|" & Val(row.Cells(GLOTPCS.Index).Value)
                        LOTMTRS = LOTMTRS & "|" & Val(row.Cells(GLOTMTRS.Index).Value)
                        LOTWT = LOTWT & "|" & Val(row.Cells(GLOTWT.Index).Value)
                    End If
                End If
            Next


            For Each row As Windows.Forms.DataGridViewRow In GRIDBALE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If BALESRNO = "" Then
                        BALESRNO = Val(row.Cells(GBALESRNO.Index).Value)
                        BALENO = Val(row.Cells(GBALENO.Index).Value)
                        MARCHANT = row.Cells(GMERCHANT.Index).Value
                        BALEPCS = Val(row.Cells(GBALEPCS.Index).Value)
                        BALEMTRS = Val(row.Cells(GBALEMTRS.Index).Value)
                        BALECONVMTRS = Val(row.Cells(GBALECONVMTRS.Index).Value)
                        BALEFROMNO = Val(row.Cells(GBALEFROMNO.Index).Value)
                        BALEFROMTYPE = row.Cells(GBALEFROMTYPE.Index).Value
                    Else
                        BALESRNO = BALESRNO & "|" & Val(row.Cells(GBALESRNO.Index).Value)
                        BALENO = BALENO & "|" & Val(row.Cells(GBALENO.Index).Value)
                        MARCHANT = MARCHANT & "|" & row.Cells(GMERCHANT.Index).Value
                        BALEPCS = BALEPCS & "|" & Val(row.Cells(GBALEPCS.Index).Value)
                        BALEMTRS = BALEMTRS & "|" & Val(row.Cells(GBALEMTRS.Index).Value)
                        BALECONVMTRS = BALECONVMTRS & "|" & Val(row.Cells(GBALECONVMTRS.Index).Value)
                        BALEFROMNO = BALEFROMNO & "|" & Val(row.Cells(GBALEFROMNO.Index).Value)
                        BALEFROMTYPE = BALEFROMTYPE & "|" & row.Cells(GBALEFROMTYPE.Index).Value
                    End If
                End If
            Next

            For Each row As Windows.Forms.DataGridViewRow In GRIDINVOICE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If INVSRNO = "" Then
                        INVSRNO = Val(row.Cells(GINVSRNO.Index).Value)
                        INVOICENO = Val(row.Cells(GINVNO.Index).Value)
                        INVPCS = Val(row.Cells(GINVPCS.Index).Value)
                        INVMTRS = Val(row.Cells(GINVMTRS.Index).Value)
                    Else
                        INVSRNO = INVSRNO & "|" & Val(row.Cells(GINVSRNO.Index).Value)
                        INVOICENO = INVOICENO & "|" & Val(row.Cells(GINVNO.Index).Value)
                        INVPCS = INVPCS & "|" & Val(row.Cells(GINVPCS.Index).Value)
                        INVMTRS = INVMTRS & "|" & Val(row.Cells(GINVMTRS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(LOTSRNO)
            alParaval.Add(LOTNO)
            alParaval.Add(LOTQUALITY)
            alParaval.Add(LOTRECDDATE)
            alParaval.Add(LOTPCS)
            alParaval.Add(LOTMTRS)
            alParaval.Add(LOTWT)

            alParaval.Add(BALESRNO)
            alParaval.Add(BALENO)
            alParaval.Add(MARCHANT)
            alParaval.Add(BALEPCS)
            alParaval.Add(BALEMTRS)
            alParaval.Add(BALECONVMTRS)
            alParaval.Add(BALEFROMNO)
            alParaval.Add(BALEFROMTYPE)

            alParaval.Add(INVSRNO)
            alParaval.Add(INVOICENO)
            alParaval.Add(INVPCS)
            alParaval.Add(INVMTRS)

            alParaval.Add(CHKCUTTINGCHGS.Checked)
            alParaval.Add(CHKCARTONCHGS.Checked)
            alParaval.Add(CHKFELT.Checked)


            Dim BLEACHSRNO As String = ""
            Dim BLEACHMTRS As String = ""
            Dim BLEACHWT As String = ""
            Dim BLEACHREEDPICK As String = ""
            Dim BLEACHWIDTH As String = ""
            Dim BLEACHFOLD As String = ""
            Dim BLEACHGRAMS As String = ""

            'Saving Upload Grid
            For Each ROW As Windows.Forms.DataGridViewRow In GRIDBLEACH.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If BLEACHSRNO = "" Then
                        BLEACHSRNO = Val(ROW.Cells(BSRNO.Index).Value)
                        BLEACHMTRS = Val(ROW.Cells(BMTRS.Index).Value)
                        BLEACHWT = Val(ROW.Cells(BWT.Index).Value)
                        BLEACHREEDPICK = ROW.Cells(BREEDPICK.Index).Value
                        BLEACHWIDTH = Val(ROW.Cells(BWIDTH.Index).Value)
                        BLEACHFOLD = Val(ROW.Cells(BFOLD.Index).Value)
                        BLEACHGRAMS = Val(ROW.Cells(BGRAMS.Index).Value)
                    Else
                        BLEACHSRNO = BLEACHSRNO & "|" & Val(ROW.Cells(BSRNO.Index).Value)
                        BLEACHMTRS = BLEACHMTRS & "|" & Val(ROW.Cells(BMTRS.Index).Value)
                        BLEACHWT = BLEACHWT & "|" & Val(ROW.Cells(BWT.Index).Value)
                        BLEACHREEDPICK = BLEACHREEDPICK & "|" & ROW.Cells(BREEDPICK.Index).Value
                        BLEACHWIDTH = BLEACHWIDTH & "|" & Val(ROW.Cells(BWIDTH.Index).Value)
                        BLEACHFOLD = BLEACHFOLD & "|" & Val(ROW.Cells(BFOLD.Index).Value)
                        BLEACHGRAMS = BLEACHGRAMS & "|" & Val(ROW.Cells(BGRAMS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(BLEACHSRNO)
            alParaval.Add(BLEACHMTRS)
            alParaval.Add(BLEACHWT)
            alParaval.Add(BLEACHREEDPICK)
            alParaval.Add(BLEACHWIDTH)
            alParaval.Add(BLEACHFOLD)
            alParaval.Add(BLEACHGRAMS)

            Dim objclsFPS As New ClsPackingSummary()
            objclsFPS.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsFPS.SAVE()
                TEMPPACKNO = DTTABLE.Rows(0).Item(0)
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPACKNO)

                IntResult = objclsFPS.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False
            PRINTREPORT()





            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub PackingSummary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then
            TabControl1.SelectedIndex = (1)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3 Then
            TabControl1.SelectedIndex = (2)
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDLOT.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            Dim TEMPMSG As Integer = MsgBox("Print Packing Summary?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJGDN As New GDNDESIGN
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "PACKINGSUMMARY"
                If GRIDLOT.RowCount > 0 AndAlso GRIDLOT.Rows(0).Cells(GQUALITY.Index).Value <> "" Then OBJGDN.MONOGRAMQUALITYNAME = GRIDLOT.Rows(0).Cells(GQUALITY.Index).Value
                OBJGDN.FORMULA = "{PACKINGSUMMARY.PS_no}=" & Val(TEMPPACKNO) & " And {PACKINGSUMMARY.PS_YEARID}=" & YearId
                OBJGDN.vendorname = CMBNAME.Text.Trim
                OBJGDN.Show()
            End If


            If ClientName <> "SHUBHLAXMI" Then Exit Sub
            If MsgBox("Wish To Print Bleach Wt Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJGDNINS = New GDNDESIGN
            OBJGDNINS.GDNNO = Val(TEMPPACKNO)
            OBJGDNINS.FRMSTRING = "BLEACHWTREPORT"
            OBJGDNINS.MdiParent = MDIMain
            OBJGDNINS.FORMULA = "{PACKINGSUMMARY.PS_no}=" & Val(TEMPPACKNO) & " And {PACKINGSUMMARY.PS_YEARID}=" & YearId
            OBJGDNINS.vendorname = CMBNAME.Text.Trim
            OBJGDNINS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PackingSummary_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PACKING SLIP'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()


            If edit = True Then


                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsPackingSummary()
                Dim ALPARAVAL As New ArrayList
                Dim dttable As New DataTable

                ALPARAVAL.Add(TEMPPACKNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)
                OBJCHECKING.alParaval = ALPARAVAL
                dttable = OBJCHECKING.selectPACK(TEMPPACKNO, CmpId, YearId)

                If dttable.Rows.Count > 0 Then
                    TXTSUMMNO.Text = TEMPPACKNO
                    'TXTSUMMNO.Text = Convert.ToString(dttable.Rows(0).Item("TEMPPACKNO").ToString)
                    SUMMDATE.Value = Format(Convert.ToDateTime(dttable.Rows(0).Item("DATE")).Date, "dd/MM/yyyy")
                    CMBNAME.Text = Convert.ToString(dttable.Rows(0).Item("NAME").ToString)
                    CMBMERCHANT.Text = Convert.ToString(dttable.Rows(0).Item("QUALITY").ToString)
                    TXTFINALMTRS.Text = Convert.ToString(dttable.Rows(0).Item("FINALMTR").ToString)
                    TXTLONGATION.Text = Convert.ToString(dttable.Rows(0).Item("LONGATION").ToString)

                    TXTFOLD.Text = Convert.ToString(dttable.Rows(0).Item("FOLD").ToString)
                    TXTNEWFOLD.Text = Convert.ToString(dttable.Rows(0).Item("NEWFOLD").ToString)

                    TXTSAMPLEMTRS.Text = Convert.ToString(dttable.Rows(0).Item("SAMPLEMTRS").ToString)
                    TXTSHORTPCS.Text = Convert.ToString(dttable.Rows(0).Item("SHORTPCS").ToString)
                    TXTREJPCS.Text = Convert.ToString(dttable.Rows(0).Item("REJPCS").ToString)
                    TXTFENTMTRS.Text = Convert.ToString(dttable.Rows(0).Item("FENTMTRS").ToString)
                    TXTSHORTMTRS.Text = Convert.ToString(dttable.Rows(0).Item("SHORTMTRS").ToString)
                    TXTREJMTRS.Text = Convert.ToString(dttable.Rows(0).Item("REJMTRS").ToString)
                    TXTGOODGUTMTRS.Text = Convert.ToString(dttable.Rows(0).Item("GOODCUTMTRS").ToString)
                    TXTRACKSMTRS.Text = Convert.ToString(dttable.Rows(0).Item("RACKSMTRS").ToString)
                    TXTLESSPER.Text = Convert.ToString(dttable.Rows(0).Item("LESSPER").ToString)
                    TXTLESSMTRS.Text = Convert.ToString(dttable.Rows(0).Item("LESSMTRS").ToString)
                    TXTREADYWIDTH.Text = Convert.ToString(dttable.Rows(0).Item("READYWIDTH").ToString)
                    TXTREMARKS.Text = Convert.ToString(dttable.Rows(0).Item("REMARKS").ToString)
                    LBLTOTALLOTPCS.Text = Convert.ToString(dttable.Rows(0).Item("TOTALLOTPCS").ToString)
                    LBLTOTALLOTMTRS.Text = Convert.ToString(dttable.Rows(0).Item("TOTALLOTMTRS").ToString)
                    LBLTOTALLOTWT.Text = Convert.ToString(dttable.Rows(0).Item("TOTALLOTWT").ToString)
                    LBLTOTALBALEPCS.Text = Convert.ToString(dttable.Rows(0).Item("TOTALBALEPCS").ToString)
                    LBLTOTALBALEMTRS.Text = Convert.ToString(dttable.Rows(0).Item("TOTALBALEMTRS").ToString)
                    LBLTOTALINVPCS.Text = Convert.ToString(dttable.Rows(0).Item("TOTALINVPCS").ToString)
                    LBLTOTALINVMTRS.Text = Convert.ToString(dttable.Rows(0).Item("TOTALINVMTRS").ToString)

                    CHKCUTTINGCHGS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("CUTTINGCHGS"))
                    CHKCARTONCHGS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("CARTONCHGS"))
                    CHKFELT.Checked = Convert.ToBoolean(dttable.Rows(0).Item("FELT"))

                    If Convert.ToBoolean(dttable.Rows(0).Item("INVDONE")) = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


                    'ITEM GRID
                    For Each ROW As DataRow In dttable.Rows
                        If Val(ROW("LOTNO")) > 0 Then GRIDLOT.Rows.Add(Val(ROW("LOTSRNO")), ROW("LOTNO"), ROW("LOTQUALITY"), Format(Convert.ToDateTime(ROW("LOTRECDDATE")).Date, "dd/MM/yyyy"), ROW("LOTPCS"), Val(ROW("LOTMTRS")), Val(ROW("LOTWT")))
                    Next


                    'GRIDBALE
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" PACKINGSUMMARY_BALEDESC.PS_BALESRNO AS BALESRNO ,PACKINGSUMMARY_BALEDESC.PS_BALENO AS BALENO, ISNULL(ItemMaster.item_name ,'') As MERCHANT, PACKINGSUMMARY_BALEDESC.PS_BALEPCS AS BALEPCS, PACKINGSUMMARY_BALEDESC.PS_BALEMTRS AS BALEMTRS, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALECONVMTRS,0) AS BALECONVMTRS, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALEFROMNO,0) AS BALEFROMNO, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALEFROMTYPE,'') AS BALEFROMTYPE   ", "", " PACKINGSUMMARY_BALEDESC LEFT OUTER JOIN ITEMMASTER ON PACKINGSUMMARY_BALEDESC.PS_MERCHANTID = ITEMMASTER.item_id   ", " AND PACKINGSUMMARY_BALEDESC.PS_NO = " & TEMPPACKNO & " AND PACKINGSUMMARY_BALEDESC.PS_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            GRIDBALE.Rows.Add(DTR("BALESRNO"), DTR("BALENO"), DTR("MERCHANT"), DTR("BALEPCS"), DTR("BALEMTRS"), DTR("BALECONVMTRS"), DTR("BALEFROMNO"), DTR("BALEFROMTYPE"))
                        Next
                    End If


                    'INVOICEGRID
                    DT = OBJCMN.search(" PACKINGSUMMARY_INVOICEDESC.PS_INVSRNO AS INVSRNO, PACKINGSUMMARY_INVOICEDESC.PS_INVNO AS INVNO,PACKINGSUMMARY_INVOICEDESC.PS_INVPCS AS INVPCS,PACKINGSUMMARY_INVOICEDESC.PS_INVMTRS AS INVMTRS ", "", "PACKINGSUMMARY_INVOICEDESC ", " AND PACKINGSUMMARY_INVOICEDESC.PS_NO = " & Val(TEMPPACKNO) & " AND PS_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            GRIDINVOICE.Rows.Add(DTR("INVSRNO"), Val(DTR("INVNO")), Val(DTR("INVPCS")), Val(DTR("INVMTRS")))
                        Next
                        'getsrno(GRIDINVOICE)
                    End If

                    'BLEACHWT GRID
                    dttable = OBJCMN.search(" ISNULL(PS_GRIDSRNO, 0) AS BSRNO, ISNULL(PS_DECMTRS, 0) AS BMTRS, ISNULL(PS_WT, 0) AS BWT, ISNULL(PS_REEDPICK, '') AS BREEDPICK, ISNULL(PS_WIDTH, 0) AS BWIDTH, ISNULL(PS_FOLD, 0) AS BFOLD, ISNULL(PS_GRAMS, 0) AS BGRAMS ", "", " PACKINGSUMMARY_BLEACHDESC ", " AND PS_NO = " & Val(TEMPPACKNO) & " AND PS_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            GRIDBLEACH.Rows.Add(DTR("BSRNO"), Val(DTR("BMTRS")), Format(Val(DTR("BWT")), "0.000"), DTR("BREEDPICK"), Val(DTR("BWIDTH")), Val(DTR("BFOLD")), Format(Val(DTR("BGRAMS")), "0.000"))
                        Next
                    End If

                    TOTAL()
                End If
            End If

        Catch ex As Exception
            Throw ex
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

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If lbllocked.Visible = True Then
                    MsgBox("Packing Raised Delete Despatch First", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Delete Packing?", MsgBoxStyle.YesNo) = vbYes Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(TEMPPACKNO)
                        alParaval.Add(Userid)
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(YearId)


                        Dim ClsGRNChecking As New ClsPackingSummary()
                        ClsGRNChecking.alParaval = alParaval
                        IntResult = ClsGRNChecking.Delete()
                        MsgBox("Packing Deleted")
                        clear()
                        edit = False
                    End If
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBGRIDQUALITY.Text.Trim = "" Then fillQUALITY(CMBGRIDQUALITY, edit)
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

            Dim objgrndetails As New PackingSummaryDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
            objgrndetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTSAMPLEMTRS_Validated(sender As Object, e As EventArgs) Handles TXTSAMPLEMTRS.Validated, TXTFENTMTRS.Validated, TXTSHORTMTRS.Validated, TXTREJMTRS.Validated, TXTGOODGUTMTRS.Validated, TXTRACKSMTRS.Validated, TXTLESSPER.Validated, TXTLESSMTRS.Validated
        TOTAL()
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, txtadd, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' OR ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDLOT.Rows.Add(Val(TXTLOTSRNO.Text.Trim), CMBLOTNO.Text.Trim, CMBMERCHANT.Text.Trim, Format(DTLOTRECDDATE.Value.Date, "dd/MM/yyyy"), Format(Val(TXTLOTPCS.Text.Trim), "0.00"), Format(Val(TXTLOTMTRS.Text.Trim), "0.00"), Format(Val(TXTLOTWT.Text.Trim), "0.000"))
            getsrno(GRIDLOT)
        ElseIf gridDoubleClick = True Then
            GRIDLOT.Item(GLOTSRNO.Index, temprow).Value = Val(TXTLOTSRNO.Text.Trim)
            GRIDLOT.Item(GLOTNO.Index, temprow).Value = CMBLOTNO.Text.Trim
            GRIDLOT.Item(GQUALITY.Index, temprow).Value = CMBMERCHANT.Text.Trim
            GRIDLOT.Item(GRECDDATE.Index, temprow).Value = Format(DTLOTRECDDATE.Value.Date, "dd/MM/yyyy")
            GRIDLOT.Item(GLOTPCS.Index, temprow).Value = Format(Val(TXTLOTPCS.Text.Trim), "0.00")
            GRIDLOT.Item(GLOTMTRS.Index, temprow).Value = Format(Val(TXTLOTMTRS.Text.Trim), "0.00")
            GRIDLOT.Item(GLOTWT.Index, temprow).Value = Format(Val(TXTLOTWT.Text.Trim), "0.000")

            gridDoubleClick = False
        End If
        TOTAL()
        TXTLOTSRNO.Text = GRIDLOT.RowCount + 1
        CMBLOTNO.Text = ""
        CMBMERCHANT.Text = ""
        DTLOTRECDDATE.Value = Now.Date
        TXTLOTPCS.Clear()
        TXTLOTMTRS.Clear()
        TXTLOTWT.Clear()
        CMBLOTNO.Focus()

        GRIDLOT.FirstDisplayedScrollingRowIndex = GRIDLOT.RowCount - 1


    End Sub

    Sub FILLBALE()

        If GRIDBALEDOUBLECLICK = False Then
            GRIDBALE.Rows.Add(Val(TXTBALESRNO.Text.Trim), Val(TXTBALENO.Text.Trim), TXTMERCHANT.Text.Trim, Val(TXTBALEPCS.Text.Trim), Val(TXTBALEMTRS.Text.Trim), Val(TXTBALECONVMTRS.Text.Trim), TXTBALEFROMNO.Text.Trim, TXTBALEFROMTYPE.Text.Trim)
            getsrno(GRIDBALE)
        ElseIf GRIDBALEDOUBLECLICK = True Then

            GRIDBALE.Item(GBALESRNO.Index, TEMPBALEROW).Value = Val(TXTBALESRNO.Text.Trim)
            GRIDBALE.Item(GBALENO.Index, TEMPBALEROW).Value = Val(TXTBALENO.Text.Trim)
            GRIDBALE.Item(GMERCHANT.Index, TEMPBALEROW).Value = TXTMERCHANT.Text.Trim
            GRIDBALE.Item(GBALEPCS.Index, TEMPBALEROW).Value = Format(Val(TXTBALEPCS.Text.Trim), "0.00")
            GRIDBALE.Item(GBALEMTRS.Index, TEMPBALEROW).Value = Format(Val(TXTBALEMTRS.Text.Trim), "0.00")
            GRIDBALE.Item(GBALECONVMTRS.Index, TEMPBALEROW).Value = Format(Val(TXTBALECONVMTRS.Text.Trim), "0.00")
            GRIDBALEDOUBLECLICK = False

        End If

        TXTBALESRNO.Text = GRIDBALE.RowCount + 1
        TXTBALENO.Text = Val(TXTBALENO.Text) + 1
        TXTMERCHANT.Clear()
        TXTBALEPCS.Clear()
        TXTBALEMTRS.Clear()
        TXTBALECONVMTRS.Clear()

        TXTBALENO.Focus()

        GRIDBALE.FirstDisplayedScrollingRowIndex = GRIDBALE.RowCount - 1

    End Sub

    Sub FILLGRIDINVOICE()

        If GRIDINVOICEDOUBLECLICK = False Then
            GRIDINVOICE.Rows.Add(Val(TXTINVSRNO.Text.Trim), TXTINVOICENO.Text.Trim, TXTINVPCS.Text.Trim, TXTINVMTRS.Text.Trim)
            getsrno(GRIDINVOICE)
        ElseIf GRIDINVOICEDOUBLECLICK = True Then

            GRIDINVOICE.Item(GINVSRNO.Index, TEMPINVROW).Value = TXTINVSRNO.Text.Trim
            GRIDINVOICE.Item(GINVNO.Index, TEMPINVROW).Value = TXTINVOICENO.Text.Trim
            GRIDINVOICE.Item(GINVPCS.Index, TEMPINVROW).Value = TXTINVPCS.Text.Trim
            GRIDINVOICE.Item(GINVMTRS.Index, TEMPINVROW).Value = TXTINVMTRS.Text.Trim
            GRIDINVOICEDOUBLECLICK = False

        End If

        TXTINVSRNO.Clear()
        TXTINVOICENO.Clear()
        TXTINVPCS.Clear()
        TXTINVMTRS.Clear()

        TXTINVOICENO.Focus()

        GRIDINVOICE.FirstDisplayedScrollingRowIndex = GRIDINVOICE.RowCount - 1

        If GRIDINVOICE.RowCount > 0 Then
            TXTINVSRNO.Text = Val(GRIDINVOICE.Rows(GRIDINVOICE.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTINVSRNO.Text = 1
        End If

    End Sub

    Sub FILLBLEACHGRID()

        If GRIDBLEACHDOUBLECLICK = False Then
            GRIDBLEACH.Rows.Add(Val(TXTBSRNO.Text.Trim), Val(TXTBDECMTRS.Text.Trim), Format(Val(TXTBWT.Text.Trim), "0.000"), TXTBREEDPICK.Text.Trim, Val(TXTBWIDTH.Text.Trim), Val(TXTBFOLD.Text.Trim), Format(Val(TXTBGRAMS.Text.Trim)), "0.000")
            getsrno(GRIDBLEACH)
        ElseIf GRIDBLEACHDOUBLECLICK = True Then
            GRIDBLEACH.Item(BSRNO.Index, TEMPBLEACHROW).Value = Val(TXTBSRNO.Text.Trim)
            GRIDBLEACH.Item(BMTRS.Index, TEMPBLEACHROW).Value = Val(TXTBDECMTRS.Text.Trim)
            GRIDBLEACH.Item(BWT.Index, TEMPBLEACHROW).Value = Format(Val(TXTBWT.Text.Trim), "0.000")
            GRIDBLEACH.Item(BREEDPICK.Index, TEMPBLEACHROW).Value = TXTBREEDPICK.Text.Trim
            GRIDBLEACH.Item(BWIDTH.Index, TEMPBLEACHROW).Value = Val(TXTBWIDTH.Text.Trim)
            GRIDBLEACH.Item(BFOLD.Index, TEMPBLEACHROW).Value = Val(TXTBFOLD.Text.Trim)
            GRIDBLEACH.Item(BGRAMS.Index, TEMPBLEACHROW).Value = Format(Val(TXTBGRAMS.Text.Trim), "0.000")
            GRIDBLEACHDOUBLECLICK = False
        End If

        TOTAL()

        GRIDBLEACH.FirstDisplayedScrollingRowIndex = GRIDBLEACH.RowCount - 1

        TXTBSRNO.Text = GRIDBLEACH.RowCount + 1
        TXTBDECMTRS.Clear()
        TXTBWT.Clear()
        TXTBREEDPICK.Clear()
        TXTBWIDTH.Clear()
        'TXTBFOLD.Clear()
        TXTBGRAMS.Clear()
        TXTBDECMTRS.Focus()

    End Sub

    Private Sub GRIDBALE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBALE.CellDoubleClick
        Try
            If GRIDBALE.Rows(e.RowIndex).Cells(GBALESRNO.Index).Value <> Nothing Then
                GRIDBALEDOUBLECLICK = True
                TEMPBALEROW = e.RowIndex
                TXTBALESRNO.Text = GRIDBALE.Rows(e.RowIndex).Cells(GBALESRNO.Index).Value
                TXTBALENO.Text = GRIDBALE.Rows(e.RowIndex).Cells(GBALENO.Index).Value
                TXTMERCHANT.Text = GRIDBALE.Rows(e.RowIndex).Cells(GMERCHANT.Index).Value
                TXTBALEPCS.Text = GRIDBALE.Rows(e.RowIndex).Cells(GBALEPCS.Index).Value
                TXTBALEMTRS.Text = GRIDBALE.Rows(e.RowIndex).Cells(GBALEMTRS.Index).Value

                TXTBALENO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDLOT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDLOT.CellDoubleClick
        Try
            If GRIDLOT.Rows(e.RowIndex).Cells(GLOTSRNO.Index).Value <> Nothing Then
                gridDoubleClick = True
                temprow = e.RowIndex
                TXTLOTSRNO.Text = GRIDLOT.Rows(e.RowIndex).Cells(GLOTSRNO.Index).Value
                CMBLOTNO.Text = GRIDLOT.Rows(e.RowIndex).Cells(GLOTNO.Index).Value
                CMBMERCHANT.Text = GRIDLOT.Rows(e.RowIndex).Cells(GQUALITY.Index).Value
                DTLOTRECDDATE.Value = Format(Convert.ToDateTime(GRIDLOT.Rows(e.RowIndex).Cells(GRECDDATE.Index).Value).Date, "dd/MM/yyyy")
                TXTLOTPCS.Text = GRIDLOT.Rows(e.RowIndex).Cells(GLOTPCS.Index).Value
                TXTLOTMTRS.Text = GRIDLOT.Rows(e.RowIndex).Cells(GLOTMTRS.Index).Value
                TXTLOTWT.Text = GRIDLOT.Rows(e.RowIndex).Cells(GLOTWT.Index).Value
                CMBLOTNO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINVOICE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDINVOICE.CellDoubleClick
        Try
            If GRIDINVOICE.Rows(e.RowIndex).Cells(GINVSRNO.Index).Value <> Nothing Then
                GRIDINVOICEDOUBLECLICK = True
                TEMPINVROW = e.RowIndex
                TXTINVSRNO.Text = GRIDINVOICE.Rows(e.RowIndex).Cells(GINVSRNO.Index).Value
                TXTINVOICENO.Text = GRIDINVOICE.Rows(e.RowIndex).Cells(GINVNO.Index).Value
                TXTINVPCS.Text = GRIDINVOICE.Rows(e.RowIndex).Cells(GINVPCS.Index).Value
                TXTINVMTRS.Text = GRIDINVOICE.Rows(e.RowIndex).Cells(GINVMTRS.Index).Value

                TXTINVOICENO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLOTNO.Enter
        Try

            If CMBLOTNO.Text.Trim = "" And CMBNAME.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" DISTINCT LOTNO", "", " GREYDETAIL_VIEW", " AND NAME = '" & CMBNAME.Text.Trim & "' and yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "LOTNO"
                    CMBLOTNO.DataSource = dt
                    CMBLOTNO.DisplayMember = "LOTNO"
                    CMBLOTNO.Text = ""
                End If
                CMBLOTNO.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            TEMPPACKNO = Val(TXTSUMMNO.Text) + 1
            GETMAXNO()
            clear()
            If Val(TXTSUMMNO.Text) - 1 >= TEMPPACKNO Then
                edit = True
                PackingSummary_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDBALE.RowCount = 0

            TEMPPACKNO = Val(TXTSUMMNO.Text) - 1
            If TEMPPACKNO > 0 Then
                edit = True
                PackingSummary_Load(sender, e)
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

    Private Sub TXTLOTWT_Validated(sender As Object, e As EventArgs) Handles TXTLOTWT.Validated
        Try
            If Val(CMBLOTNO.Text.Trim) > 0 And CMBMERCHANT.Text.Trim <> "" Then

                'CHECK IF SAME LOT IS PRESENT IN GRID OR NOT
                For Each ROW As DataGridViewRow In GRIDLOT.Rows
                    If Val(ROW.Cells(GLOTNO.Index).Value) = Val(CMBLOTNO.Text.Trim) And gridDoubleClick = False Then
                        MsgBox("Lot No Already Present in the Grid Below", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                fillgrid()
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTINVMTRS_Validated(sender As Object, e As EventArgs) Handles TXTINVMTRS.Validated
        Try
            'If Val(TXTINVPCS.Text.Trim) = 0 Then TXTINVOICENO.Text = 1
            If Val(TXTINVPCS.Text.Trim) > 0 Then
                'If Val(lblbalmtrs.Text) < -50 And CMBFROM.Text = "WHITE FOLDING" Then
                '    MsgBox("No Mtrs Found in this lot", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If
                FILLGRIDINVOICE()
                TOTAL()
            Else
                If ClientName = "TULSI" Or ClientName = "SHREENATH" Then MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub gridSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDLOT.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDLOT.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDLOT.Rows.RemoveAt(GRIDLOT.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDLOT)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDBALE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBALE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBALE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDBALEDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDBALE.Rows.RemoveAt(GRIDBALE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDBALE)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDINVOICE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDINVOICE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDINVOICE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDINVOICEDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDINVOICE.Rows.RemoveAt(GRIDINVOICE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDINVOICE)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBALENO_Validated(sender As Object, e As EventArgs) Handles TXTBALENO.Validated
        Try
            If TXTBALENO.Text.Trim <> "" And CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("MERCHANT, FROMNO, FROMTYPE, FBNO AS FOLD, sum(PCS) as PCS, sum(MTRS) AS MTRS ", "", " ALLBALE_VIEW ", " and BALENO = " & Val(TXTBALENO.Text.Trim) & " AND NAME = '" & CMBNAME.Text.Trim & "' AND PACKSUMMDONE = 'FALSE' AND YEARID = " & YearId & OPENINGCLAUSEFORLOT & " GROUP BY MERCHANT, FROMNO, FROMTYPE, FBNO")
                If DT.Rows.Count > 0 Then

                    TXTFOLD.Text = DT.Rows(0).Item("FOLD")
                    TXTNEWFOLD.Text = DT.Rows(0).Item("FOLD")

                    TXTMERCHANT.Text = DT.Rows(0).Item("MERCHANT")
                    TXTBALEPCS.Text = Val(DT.Rows(0).Item("PCS"))
                    TXTBALEMTRS.Text = Val(DT.Rows(0).Item("MTRS"))
                    TXTBALECONVMTRS.Text = Val(DT.Rows(0).Item("MTRS"))
                    TXTBALEFROMNO.Text = DT.Rows(0).Item("FROMNO")
                    TXTBALEFROMTYPE.Text = DT.Rows(0).Item("FROMTYPE")

                    'FETCH LOTNOS AUTO WITH RESPECT TO BALENO
                    'BEFORE ADDING IN LOTGRID CHECK WHETHER IT IS ALREADY PRESENT IN GRID OR NOT, IF PRESENT THEN DONT ADD IN GRID
                    'WHILE ADDING LOTNO IN GRID FETCH ITS BALPCS | BALMTRS | AND WT FROM GREYDETAILS_VIEW
                    Dim DTTABLE As DataTable = OBJCMN.search("*", "", "ALLBALE_VIEW", " and BALENO = " & Val(TXTBALENO.Text.Trim) & OPENINGCLAUSEFORLOT & " AND NAME = '" & CMBNAME.Text.Trim & "' and YEARID = " & YearId)
                    For Each DTROW As DataRow In DTTABLE.Rows

                        'CHECK WHETHER LOTNO IS PRESENT IN GRID OR NOT, IF NOT THEN ADD IN GRID
                        For Each ROW As DataGridViewRow In GRIDLOT.Rows
                            If Val(ROW.Cells(GLOTNO.Index).Value) = Val(DTROW("LOTNO")) Then GoTo SKIPADDROW
                        Next

                        'FETCH DETAILS OF LOTNO FROM GREYDETAILS_VIEW AND ADD IN LOTGRID
                        Dim DTLOT As DataTable = OBJCMN.search("ISNULL(SUM(BALPCS),0) AS PCS, ISNULL(SUM(BALMTRS),0) AS MTRS, SUM(WT) AS WT, QUALITY, DATE", "", "GREYDETAIL_VIEW", " AND LOTNO = " & Val(DTROW("LOTNO")) & " AND YEARID = " & YearId & OPENINGCLAUSEFORLOT & " GROUP BY QUALITY, FROMTYPE, DATE")
                        If DTLOT.Rows.Count > 0 Then GRIDLOT.Rows.Add(GRIDLOT.RowCount + 1, DTROW("LOTNO"), DTLOT.Rows(0).Item("QUALITY"), Format(Convert.ToDateTime(DTLOT.Rows(0).Item("DATE")).Date, "dd/MM/yyyy"), Val(DTLOT.Rows(0).Item("PCS")), Val(DTLOT.Rows(0).Item("MTRS")), Val(DTLOT.Rows(0).Item("WT")))
                        TOTAL()

SKIPADDROW:

                    Next


                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ENTERLOTDATA(ByVal DRROW() As DataRow)
        Try
            TXTLOTPCS.Text = Val(DRROW(0).Item("PCS"))
            TXTLOTMTRS.Text = Val(DRROW(0).Item("MTRS"))
            TXTLOTWT.Text = Val(DRROW(0).Item("WT"))
            CMBGRIDQUALITY.Text = DRROW(0).Item("QUALITY")
            TXTBALEFROMTYPE.Text = DRROW(0).Item("FROMTYPE")
            DTLOTRECDDATE.Value = Format(Convert.ToDateTime(DRROW(0).Item("DATE")).Date, "dd/MM/yyyy")
            TXTREADYWIDTH.Text = DRROW(0).Item("READYWIDTH")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validated(sender As Object, e As EventArgs) Handles CMBLOTNO.Validated
        Try
            If CMBLOTNO.Text.Trim <> "" And gridDoubleClick = False Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(BALPCS),0) AS PCS, ISNULL(SUM(BALMTRS),0) AS MTRS, ISNULL(SUM(WT),0) AS WT, QUALITY, DATE, FROMTYPE, ISNULL(READYWIDTH,'') AS READYWIDTH", "", "GREYDETAIL_VIEW", " AND LOTNO = " & Val(CMBLOTNO.Text.Trim) & " AND YEARID = " & YearId & " GROUP BY QUALITY, DATE, FROMTYPE, ISNULL(READYWIDTH,'')")
                If DT.Rows.Count > 0 Then
                    If DT.Rows.Count > 1 Then
                        If MsgBox("Wish to Fetch Data from Opening?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Dim DRROW() As DataRow = DT.Select("FROMTYPE = 'OPENING'")
                            OPENINGCLAUSEFORLOT = " AND FROMTYPE = 'OPENING'"
                            ENTERLOTDATA(DRROW)
                        Else
                            Dim DRROW() As DataRow = DT.Select("FROMTYPE = 'CHECKING'")
                            'DONT CHANGE DONE BY GULKIT
                            OPENINGCLAUSEFORLOT = " AND FROMTYPE <> 'OPENING'"
                            ENTERLOTDATA(DRROW)
                        End If
                    Else
                        Dim DRROW() As DataRow = DT.Select("")
                        ENTERLOTDATA(DRROW)
                    End If

                End If

                'FETCH PARTYNAME AND MERCHANTNAME WITH RESPECT TO LOTNO
                If ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM" Then
                    DT = OBJCMN.search(" DISTINCT NAME, MAINMERCHANT, BALENO, PACKSUMMDONE", "", "ALLBALE_VIEW", " AND PACKSUMMDONE = 'FALSE' AND LOTNO = " & Val(CMBLOTNO.Text.Trim) & OPENINGCLAUSEFORLOT & " AND YEARID = " & YearId & " ORDER BY BALENO")
                    For Each ROW As DataRow In DT.Rows

                        If Convert.ToBoolean(ROW("PACKSUMMDONE")) = True Then
                            If MsgBox("Packing Summary already made for this Lot No, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                CMBLOTNO.Text = ""
                                TXTLOTPCS.Clear()
                                TXTLOTMTRS.Clear()
                                TXTLOTWT.Clear()
                                Exit Sub
                            End If
                        End If

                        CMBNAME.Text = ROW("NAME")
                        CMBMERCHANT.Text = ROW("MAINMERCHANT")

                        TXTBALENO.Text = ROW("BALENO")
                        TXTBALENO_Validated(sender, e)
                        TXTBALECONVMTRS_Validated(sender, e)
                        TOTAL()

                        TXTBALENO.Clear()
                        CMBLOTNO.Text = ""
                        TXTLOTPCS.Clear()
                        TXTLOTMTRS.Clear()
                        TXTLOTWT.Clear()
                    Next
                End If
            Else
                TXTBALENO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCONVMTRS_Click(sender As Object, e As EventArgs) Handles CMDCONVMTRS.Click
        Try
            If Val(TXTNEWFOLD.Text.Trim) <> Val(TXTFOLD.Text.Trim) And GRIDBALE.RowCount > 0 Then
                For Each ROW As DataGridViewRow In GRIDBALE.Rows
                    ROW.Cells(GBALECONVMTRS.Index).Value = Format((Val(TXTFOLD.Text.Trim) * Val(ROW.Cells(GBALEMTRS.Index).Value)) / Val(TXTNEWFOLD.Text.Trim), "0.00")
                Next
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSAMPLEMTRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSAMPLEMTRS.KeyPress, TXTFENTMTRS.KeyPress, TXTSHORTMTRS.KeyPress, TXTREJMTRS.KeyPress, TXTGOODGUTMTRS.KeyPress, TXTRACKSMTRS.KeyPress, TXTLESSPER.KeyPress, TXTLESSMTRS.KeyPress
        AMOUNTNUMDOTKYEPRESS(e, sender, Me)
    End Sub

    Private Sub CMBGRIDQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBGRIDQUALITY.Enter
        Try
            If CMBGRIDQUALITY.Text.Trim = "" Then fillQUALITY(CMBGRIDQUALITY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBGRIDQUALITY.Validating
        Try
            If CMBGRIDQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBGRIDQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PackingSummary_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "DHANLAXMI" Then
                CHKCUTTINGCHGS.Visible = True
                CHKCARTONCHGS.Visible = True
                CHKFELT.Visible = True
                LBLNEWFOLD.Visible = True
                TXTNEWFOLD.Visible = True
                CMDCONVMTRS.Visible = True
            End If


            'TEMPORARILY OPEN MERCHANT NAME MANUALLY
            If ClientName = "MONOGRAM" Then
                TXTMERCHANT.ReadOnly = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALECONVMTRS_Validated(sender As Object, e As EventArgs) Handles TXTBALECONVMTRS.Validated
        Try
            If Val(TXTBALENO.Text.Trim) > 0 And Val(TXTBALEPCS.Text.Trim) > 0 And Val(TXTBALEMTRS.Text.Trim) > 0 Then

                'CHECK IF SAME BALENO IS PRESENT IN GRID OR NOT
                For Each ROW As DataGridViewRow In GRIDBALE.Rows
                    If Val(ROW.Cells(GBALENO.Index).Value) = Val(TXTBALENO.Text.Trim) Then
                        MsgBox("Bale No Already Present in the Grid Below", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                FILLBALE()
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            GRIDBALE.RowCount = 0
            TEMPPACKNO = Val(tstxtbillno.Text)
            If TEMPPACKNO > 0 Then
                edit = True
                PackingSummary_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBGRAMS_Validating(sender As Object, e As CancelEventArgs) Handles TXTBGRAMS.Validating
        Try
            If Val(TXTBDECMTRS.Text.Trim) > 0 And Val(TXTBWT.Text.Trim) > 0 And TXTBREEDPICK.Text.Trim <> "" And Val(TXTBWIDTH.Text.Trim) > 0 And Val(TXTBFOLD.Text.Trim) > 0 Then
                FILLBLEACHGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBLEACH_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBLEACH.CellDoubleClick
        Try
            If GRIDBLEACH.CurrentRow.Index >= 0 And GRIDBLEACH.Item(BSRNO.Index, GRIDBLEACH.CurrentRow.Index).Value <> Nothing Then
                GRIDBLEACHDOUBLECLICK = True

                TXTBSRNO.Text = Val(GRIDBLEACH.Item(BSRNO.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBDECMTRS.Text = Val(GRIDBLEACH.Item(BMTRS.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBWT.Text = Val(GRIDBLEACH.Item(BWT.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBREEDPICK.Text = GRIDBLEACH.Item(BREEDPICK.Index, GRIDBLEACH.CurrentRow.Index).Value.ToString
                TXTBWIDTH.Text = Val(GRIDBLEACH.Item(BWIDTH.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBFOLD.Text = Val(GRIDBLEACH.Item(BFOLD.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBGRAMS.Text = Val(GRIDBLEACH.Item(BGRAMS.Index, GRIDBLEACH.CurrentRow.Index).Value)

                TEMPBLEACHROW = GRIDBLEACH.CurrentRow.Index
                TXTBDECMTRS.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBLEACH_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBLEACH.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBLEACH.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDBLEACHDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDBLEACH.Rows.RemoveAt(GRIDBLEACH.CurrentRow.Index)
                getsrno(GRIDBLEACH)
                TOTAL()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub BLEACHCALC()
        Try
            If Val(TXTBDECMTRS.Text.Trim) > 0 And Val(TXTBWT.Text.Trim) > 0 And Val(TXTBFOLD.Text.Trim) > 0 Then
                TXTBGRAMS.Text = Format(Val(TXTBWT.Text.Trim) / Val(TXTBDECMTRS.Text.Trim), "0.000")
                TXTBGRAMS.Text = Format(Val(TXTBGRAMS.Text.Trim) + Val(TXTBGRAMS.Text) * ((100 - Val(TXTBFOLD.Text.Trim)) / 100), "0.000")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBFOLD_Validated(sender As Object, e As EventArgs) Handles TXTBFOLD.Validated, TXTBDECMTRS.Validated, TXTBWT.Validated
        BLEACHCALC()
    End Sub

    Private Sub TXTADDROWS_Validated(sender As Object, e As EventArgs) Handles TXTADDROWS.Validated
        Try
            If Val(TXTADDROWS.Text.Trim) > 0 Then
                If MsgBox("Add Rows?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                For I As Integer = 1 To Val(TXTADDROWS.Text.Trim)
                    GRIDBLEACH.Rows.Add(0, 0, 0, "", 0, 0, 0)
                Next
                getsrno(GRIDBLEACH)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBLEACH_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDBLEACH.CellValidating
        Try

            Dim COLNUM As Integer = GRIDBLEACH.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case COLNUM

                Case BMTRS.Index, BWT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDBLEACH.CurrentCell.Value = Nothing Then GRIDBLEACH.CurrentCell.Value = "0.00"
                        GRIDBLEACH.CurrentCell.Value = Convert.ToDecimal(GRIDBLEACH.Item(COLNUM, e.RowIndex).Value)
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case BFOLD.Index
                    Dim dDebit As Integer
                    Dim bValid As Boolean = Integer.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDBLEACH.CurrentCell.Value = Nothing Then GRIDBLEACH.CurrentCell.Value = "0"
                        GRIDBLEACH.CurrentCell.Value = Convert.ToInt32(GRIDBLEACH.Item(COLNUM, e.RowIndex).Value)
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
End Class