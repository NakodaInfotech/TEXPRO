
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BL
Imports System.ComponentModel

Public Class GRNChecking

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPCHECKINGNO As Integer     'used for poation no while editing
    Public GRNCHECKINGLOTNO As String
    Dim temprow As Integer
    Public Shared selectGRNtable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()
        CMDSELECTGRN.Enabled = True

        tstxtbillno.Clear()
        GRIDCHECKING.RowCount = 0
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        TXTTOTALPARTYMTRS.Text = 0.0
        TXTTOTALCHECKEDMTRS.Text = 0.0
        TXTTOTALDIFF.Text = 0.0
        TXTTOTALWT.Text = 0.0

        TXTRECPCS.Text = 0.0
        TXTRECMTRS.Text = 0.0
        TXTREJPCS.Text = 0.0
        TXTREJMTRS.Text = 0.0
        TXTBALPCS.Text = 0.0
        TXTBALMTRS.Text = 0.0
        TXTOPSHORTAGE.Text = 0.0
        txtshortage.Text = 0.0
        TXTSHORTAGEPER.Text = 0.0

        TXTCOPYLINES.Clear()
        txttslotno.Clear()
        TXTCHECKINGNO.Clear()
        cmbname.Enabled = True
        cmbname.Text = ""
        CMBPARTYGROUP.Text = ""
        TXTWEAVERNAME.Clear()
        TXTBROKER.Clear()
        TXTBALENOS.Clear()

        txtadd.Clear()
        TXTSUPPNAME.Clear()
        CHECKINGDATE.Value = Mydate
        CMBQUALITY.Text = ""

        TXTCOUNT.Clear()
        TXTWIDTH.Clear()
        TXTREADYWIDTH.Clear()

        TXTLOTNO.Text = 0.0
        GRNDATE.Value = Mydate

        TXTGRNQTY.Text = 0.0
        TXTGRNMTRS.Text = 0.0

        TXTRATE.Clear()
        TXTGRADE.Clear()

        txtremarks.Clear()

        CHKYARDS.CheckState = CheckState.Unchecked
        CMDYARDS.Enabled = True
        CHKHANDCHECKING.Checked = False

        lbllocked.Visible = False
        PBlock.Visible = False

        TXTITEMNAME.Clear()
        TXTQUALITY.Clear()
        TXTREED.Clear()
        TXTPICK.Clear()
        TXTCOLOR.Clear()
        CMBCONTRACTOR.Text = ""

        'clearing itemgrid textboxes and combos
        txtsrno.Clear()
        TXTGRIDREMARKS.Clear()
        TXTPARTYMTRS.Clear()
        TXTCHECKEDMTRS.Clear()
        CMBAPPOROVED.SelectedIndex = 0
        TXTDIFF.Text = 0.0
        TXTWT.Clear()

        TXTPCSMTRS.Clear()
        TXTPCSMTRSWT.Clear()
        TXTQUALITYWT.Clear()
        TXTCHECKINGCHGS.Clear()

        CMDSELECTGRN.Enabled = True
        gridDoubleClick = False
        getmaxno()


        TXTTOTALPARTYMTRS.Text = 0.0
        TXTTOTALCHECKEDMTRS.Text = 0.0
        TXTTOTALDIFF.Text = 0.0
        TXTTOTALWT.Text = 0.0
        txtsrno.Text = Val(GRIDCHECKING.RowCount) + 1

    End Sub

    Sub total()
        Try
            TXTTOTALPARTYMTRS.Text = 0.0
            TXTTOTALCHECKEDMTRS.Text = 0.0
            TXTTOTALDIFF.Text = 0.0
            TXTTOTALWT.Text = 0.0
            TXTSHORTAGEPER.Text = 0.0
            TXTOPSHORTAGE.Text = 0.0

            TXTRECPCS.Text = 0.0
            TXTRECMTRS.Text = 0.0
            TXTBALPCS.Text = 0.0
            TXTBALMTRS.Text = 0.0
            TXTREJMTRS.Text = 0.0
            TXTPCSMTRS.Text = 0
            TXTPCSMTRSWT.Text = 0

            TXTREJPCS.Text = 0.0
            TXTQUALITYWT.Clear()


            For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then

                    ROW.Cells(GDIFF.Index).Value = Format(Val(ROW.Cells(GPARTYMTRS.Index).EditedFormattedValue) - Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")

                    TXTTOTALPARTYMTRS.Text = Format(Val(TXTTOTALPARTYMTRS.Text) + Val(ROW.Cells(GPARTYMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALCHECKEDMTRS.Text = Format(Val(TXTTOTALCHECKEDMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALDIFF.Text = Format(Val(TXTTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue), "0.00")

                    TXTTOTALWT.Text = Format(Val(TXTTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.000")

                    TXTRECPCS.Text = Format(Val(TXTRECPCS.Text.Trim) + 1, "0.00")
                    TXTRECMTRS.Text = Format(Val(TXTRECMTRS.Text.Trim) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    If Val(ROW.Cells(GWT.Index).EditedFormattedValue) > 0 Then
                            TXTPCSMTRS.Text = Format(Val(TXTPCSMTRS.Text.Trim) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                            TXTPCSMTRSWT.Text = Format(Val(TXTPCSMTRSWT.Text.Trim) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.000")
                        End If

                    If ROW.Cells(GAPPROVED.Index).Value = "No" Then
                        TXTREJPCS.Text = Format(Val(TXTREJPCS.Text.Trim) + 1, "0.00")
                        TXTREJMTRS.Text = Format(Val(TXTREJMTRS.Text.Trim) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    End If

                    If ROW.Cells(GAPPROVED.Index).Value = "No" Then ROW.DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next

            TXTBALPCS.Text = Format(Val(TXTRECPCS.Text.Trim) - Val(TXTREJPCS.Text.Trim), "0.00")
            TXTBALMTRS.Text = Format(Val(TXTRECMTRS.Text.Trim) - Val(TXTREJMTRS.Text.Trim), "0.00")
            TXTOPSHORTAGE.Text = Format(Val(TXTGRNMTRS.Text) - Val(TXTTOTALPARTYMTRS.Text.Trim), "0.00")
            txtshortage.Text = Format(Val(TXTTOTALPARTYMTRS.Text) - Val(TXTTOTALCHECKEDMTRS.Text.Trim), "0.00")
            TXTSHORTAGEPER.Text = Format((TXTTOTALDIFF.Text.Trim / TXTBALMTRS.Text.Trim) * 100, "0.00")
            TXTQUALITYWT.Text = Format(Val(TXTPCSMTRSWT.Text.Trim) / Val(TXTPCSMTRS.Text.Trim), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbname.Focus()
    End Sub

    Private Sub CHECKINGdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKINGDATE.Validating
        If Not datecheck(CHECKINGDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CHECK_NO),0) + 1 ", " CHECKINGMASTER", " AND CHECK_cmpid=" & CmpId & " and CHECK_locationid=" & Locationid & " and CHECK_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCHECKINGNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If

            If TXTLOTNO.Text.Trim.Length = 0 Then
                EP.SetError(TXTLOTNO, "Please Select GRN.")
                bln = False
            End If

            'If TXTWIDTH.Text.Trim.Length = 0 Then
            '    EP.SetError(TXTWIDTH, "Please Enter Width")
            '    bln = False
            'End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Item Used in Mfg, Delete Mfg First")
                bln = False
            End If

            If Val(TXTRECPCS.Text.Trim) <> Val(TXTGRNQTY.Text.Trim) Then
                EP.SetError(TXTRECPCS, "Checking Pcs Does Not Match the Recd Pcs")
                bln = False
            End If
            If GRNDATE.Value.Date > CHECKINGDATE.Value.Date Then
                EP.SetError(GRNDATE, "Checking Date cannot be before Receiveing Date")
                bln = False
            End If

            If ClientName = "TULSI" And CHECKINGDATE.Value.Date > Now.Date Then
                If MsgBox("Checking Date is Greater than Current Date, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    EP.SetError(GRNDATE, "Checking Date cannot be greater than Current Date")
                    bln = False
                End If
            End If


            If GRIDCHECKING.RowCount = 0 Then
                EP.SetError(TXTWT, "Fill Item Details")
                bln = False
            End If
            Dim wt, n As Double
            n = 0
            For Each row As DataGridViewRow In GRIDCHECKING.Rows
                If Val(row.Cells(GPARTYMTRS.Index).Value) = 0 And ClientName <> "DHANLAXMI" Then
                    EP.SetError(TXTWT, "Party MTRS Cannot be kept Blank")
                    bln = False
                End If
                If Val(row.Cells(GMTRS.Index).Value) = 0 And ClientName <> "SHUBHLAXMI" And ClientName <> "DHANLAXMI" Then
                    EP.SetError(TXTWT, "MTRS Cannot be kept Blank")
                    bln = False
                End If
                If Convert.ToString(row.Cells(Gdesc.Index).Value) = Nothing Then
                    row.Cells(Gdesc.Index).Value = " "
                End If
                If Val(row.Cells(GWT.Index).Value) <> 0 And Convert.ToBoolean(row.Cells(GDONE.Index).Value) = False Then
                    wt = wt + Val(row.Cells(GWT.Index).Value)
                    n = n + 1
                End If
            Next
            If n > 0 And wt > 0 And (ClientName = "TULSI" Or ClientName = "SHREENATH") Then
                wt = Val(wt / n)
                For Each row As DataGridViewRow In GRIDCHECKING.Rows
                    If Val(row.Cells(GWT.Index).Value) = 0 And Convert.ToBoolean(row.Cells(GDONE.Index).Value) = False Then
                        row.Cells(GWT.Index).Value = wt
                    End If
                Next

            End If


            If (ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI") And CMBCONTRACTOR.Text.Trim = "" Then
                EP.SetError(CMBCONTRACTOR, "Enter Contractor Name")
                bln = False
            End If

            If Not datecheck(CHECKINGDATE.Value) Then bln = False


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
            alParaval.Add(CHECKINGDATE.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(TXTSUPPNAME.Text.Trim)
            alParaval.Add(CMBPARTYGROUP.Text.Trim)
            alParaval.Add(TXTWEAVERNAME.Text.Trim)
            alParaval.Add(TXTBROKER.Text.Trim)

            alParaval.Add(TXTBALENOS.Text.Trim)

            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(TXTGRNNO.Text.Trim)
            alParaval.Add(TXTGRNGRIDSRNO.Text.Trim)
            alParaval.Add(GRNDATE.Value.Date)
            alParaval.Add(Val(TXTGRNQTY.Text.Trim))
            alParaval.Add(Val(TXTGRNMTRS.Text.Trim))
            alParaval.Add(CMBQUALITY.Text.Trim)
            alParaval.Add(TXTCOUNT.Text.Trim)
            alParaval.Add(TXTWIDTH.Text.Trim)
            alParaval.Add(TXTREADYWIDTH.Text.Trim)

            alParaval.Add(Val(TXTRATE.Text.Trim))
            alParaval.Add(TXTGRADE.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)

            alParaval.Add(TXTITEMNAME.Text.Trim)
            alParaval.Add(TXTQUALITY.Text.Trim)
            alParaval.Add(TXTREED.Text.Trim)
            alParaval.Add(TXTPICK.Text.Trim)
            alParaval.Add(TXTCOLOR.Text.Trim)
            alParaval.Add(CMBCONTRACTOR.Text.Trim)


            alParaval.Add(Val(TXTTOTALPARTYMTRS.Text))
            alParaval.Add(TXTTOTALCHECKEDMTRS.Text.Trim)

            alParaval.Add(Val(TXTTOTALDIFF.Text))
            alParaval.Add(Val(TXTTOTALWT.Text))
            alParaval.Add(Val(TXTREJPCS.Text))
            alParaval.Add(Val(TXTBALPCS.Text))
            alParaval.Add(Val(TXTREJMTRS.Text))
            alParaval.Add(Val(TXTBALMTRS.Text))
            alParaval.Add(0)

            alParaval.Add(Val(TXTPCSMTRS.Text))
            alParaval.Add(Val(TXTPCSMTRSWT.Text))
            alParaval.Add(Val(TXTQUALITYWT.Text))
            alParaval.Add(Val(TXTCHECKINGCHGS.Text))
            alParaval.Add(Val(TXTSHORTAGEPER.Text))
            alParaval.Add(Val(TXTOPSHORTAGE.Text))


            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CHKYARDS.Checked)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim gridremarks As String = ""
            Dim PARTYMTRS As String = ""
            Dim CHECKEDMTRS As String = ""
            Dim DIFF As String = ""
            Dim WT As String = ""
            Dim CHECKINGDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim APPROVED As String = ""      'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDCHECKING.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        gridremarks = UCase(row.Cells(Gdesc.Index).Value.ToString.Trim)
                        PARTYMTRS = row.Cells(GPARTYMTRS.Index).Value.ToString
                        CHECKEDMTRS = row.Cells(GMTRS.Index).Value.ToString
                        If row.Cells(GAPPROVED.Index).Value = "Yes" Then
                            APPROVED = 1
                        Else
                            APPROVED = 0
                        End If
                        DIFF = row.Cells(GDIFF.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            CHECKINGDONE = 1
                        Else
                            CHECKINGDONE = 0
                        End If

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        If row.Cells(Gdesc.Index).Value <> " " Then
                            gridremarks = gridremarks & "|" & UCase(row.Cells(Gdesc.Index).Value.ToString.Trim)
                        Else
                            gridremarks = gridremarks & "|" & UCase(row.Cells(Gdesc.Index).Value.ToString.Trim)
                        End If
                        PARTYMTRS = PARTYMTRS & "|" & row.Cells(GPARTYMTRS.Index).Value.ToString
                        CHECKEDMTRS = CHECKEDMTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
                        If row.Cells(GAPPROVED.Index).Value = "Yes" Then
                            APPROVED = APPROVED & "|" & "1"
                        Else
                            APPROVED = APPROVED & "|" & "0"

                        End If
                        DIFF = DIFF & "|" & row.Cells(GDIFF.Index).Value
                        WT = WT & "|" & row.Cells(GWT.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            CHECKINGDONE = CHECKINGDONE & "|" & "1"
                        Else
                            CHECKINGDONE = CHECKINGDONE & "|" & "0"
                        End If



                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(gridremarks)
            alParaval.Add(PARTYMTRS)
            alParaval.Add(CHECKEDMTRS)
            alParaval.Add(APPROVED)
            alParaval.Add(DIFF)
            alParaval.Add(WT)
            alParaval.Add(CHECKINGDONE)
            alParaval.Add(TXTTYPE.Text)
            alParaval.Add(CHKHANDCHECKING.Checked)


            Dim OBJCHECKING As New ClsGRNChecking()
            OBJCHECKING.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJCHECKING.SAVE()
                MsgBox("Details Added")


                TEMPMSG = MsgBox("Wish to Print Checking Report?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJGRN As New GRNCheckingDesign
                    OBJGRN.GRNCHECKINGNO = Val(TXTCHECKINGNO.Text.Trim)
                    OBJGRN.FRMSTRING = "CHECKING"
                    OBJGRN.MdiParent = MDIMain
                    OBJGRN.WHERECLAUSE = "{CHECKINGMASTER.CHECK_no} = " & Val(TXTCHECKINGNO.Text.Trim) & " and {CHECKINGMASTER.CHECK_cmpid}=" & CmpId & " and {CHECKINGMASTER.CHECK_locationid}=" & Locationid & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId
                    OBJGRN.Show()
                End If

                If Val(TXTREJPCS.Text.Trim) > 0 Then
                    TEMPMSG = MsgBox("Wish to Print D.O?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        If TXTREJPCS.Text <> 0 Then
                            serverprop()

                        End If
                    End If
                End If
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCHECKINGNO)

                IntResult = OBJCHECKING.UPDATE()
                MsgBox("Details Updated")

                TEMPMSG = MsgBox("Wish to Print Checking Report?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJGRN As New GRNCheckingDesign
                    OBJGRN.GRNCHECKINGNO = TEMPCHECKINGNO
                    OBJGRN.FRMSTRING = "CHECKING"
                    OBJGRN.MdiParent = MDIMain
                    OBJGRN.WHERECLAUSE = "{CHECKINGMASTER.CHECK_no}=" & TEMPCHECKINGNO & " and {CHECKINGMASTER.CHECK_cmpid}=" & CmpId & " and {CHECKINGMASTER.CHECK_locationid}=" & Locationid & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId
                    OBJGRN.Show()
                End If
                TEMPMSG = MsgBox("Wish to Print D.O?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    serverprop()

                End If
            End If
            edit = False



            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRNChecking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.P Then       'for CLEAR
            Call CheckingReportToolStripMenuItem_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
            Call cmdselectGRN_Click(sender, e)
        ElseIf e.KeyCode = Windows.Forms.Keys.F1 Then       'for CLEAR
            txttslotno.Focus()
        End If
    End Sub

    Private Sub GRNChecking_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub GRNChecking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
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

                Dim OBJCHECKING As New ClsGRNChecking()
                Dim dttable As New DataTable

                dttable = OBJCHECKING.selectCHECKING(TEMPCHECKINGNO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then
                    CMDSELECTGRN.Enabled = False

                    For Each dr As DataRow In dttable.Rows
                        cmbname.Enabled = False
                        TXTCHECKINGNO.Text = TEMPCHECKINGNO
                        GRNCHECKINGLOTNO = Convert.ToString(dr("LOTNO").ToString)
                        'GRNDATE.Value = Format(Convert.ToDateTime(dr("GRNDATE")).Date, "dd/MM/yyyy")
                        CHECKINGDATE.Value = Format(Convert.ToDateTime(dr("CHECKDATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        TXTSUPPNAME.Text = Convert.ToString(dr("SUPPNAME").ToString)
                        CMBPARTYGROUP.Text = Convert.ToString(dr("PARTYGROUP").ToString)
                        TXTWEAVERNAME.Text = Convert.ToString(dr("WEAVERNAME").ToString)
                        TXTBROKER.Text = Convert.ToString(dr("BROKERNAME").ToString)
                        TXTBALENOS.Text = Convert.ToString(dr("BALENOS").ToString)

                        txtadd.Text = Convert.ToString(dr("ADD").ToString)
                        CMBQUALITY.Text = Convert.ToString(dr("NEWQUALITY").ToString)
                        TXTCOUNT.Text = Convert.ToString(dr("COUNT").ToString)
                        TXTWIDTH.Text = Convert.ToString(dr("WIDTH").ToString)
                        TXTREADYWIDTH.Text = Convert.ToString(dr("READYWIDTH").ToString)

                        'GRN DETAILS
                        TXTLOTNO.Text = Convert.ToString(dr("LOTNO").ToString)
                        TXTGRNNO.Text = Convert.ToString(dr("GRNNO").ToString)
                        TXTGRNGRIDSRNO.Text = Convert.ToString(dr("GRNGRIDSRNO").ToString)
                        'GRNDATE.Value = Format(Convert.ToDateTime(dr("GRNDATE")).Date, "dd/MM/yyyy")
                        'TXTGRNQTY.Text = Convert.ToString(dr("GRNQTY").ToString)

                        TXTRATE.Text = Val(dr("RATE"))
                        TXTGRADE.Text = Convert.ToString(dr("GRADE").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)


                        'ITEM DETAILS
                        TXTITEMNAME.Text = Convert.ToString(dr("ITEMNAME").ToString)
                        TXTQUALITY.Text = Convert.ToString(dr("QUALITY").ToString)
                        TXTREED.Text = Convert.ToString(dr("REED").ToString)
                        TXTPICK.Text = Convert.ToString(dr("PICK").ToString)
                        TXTCOLOR.Text = Convert.ToString(dr("COLOR").ToString)
                        CMBCONTRACTOR.Text = dr("CONTRACTOR")

                        TXTTYPE.Text = Convert.ToString(dr("TYPE").ToString)


                        TXTRECMTRS.Text = Val(dr("TOTALCHECKEDMTRS"))
                        TXTREJPCS.Text = Val(dr("REJPCS"))
                        TXTREJMTRS.Text = Val(dr("REJMTRS"))
                        TXTBALPCS.Text = Val(dr("BALPCS"))
                        TXTBALMTRS.Text = Val(dr("BALMTRS"))

                        TXTPCSMTRS.Text = Val(dr("PCSMTRS"))
                        TXTPCSMTRSWT.Text = Val(dr("PCSMTRSWT"))
                        TXTQUALITYWT.Text = Val(dr("QUALITYWT"))
                        TXTCHECKINGCHGS.Text = Val(dr("CHECKINGCHGS"))
                        TXTSHORTAGEPER.Text = Val(dr("SHORTAGEPER"))
                        TXTOPSHORTAGE.Text = Val(dr("OPSHORTAGE"))

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        CHKHANDCHECKING.Checked = Convert.ToBoolean(dr("HANDCHECKING"))
                        CHKYARDS.Checked = Convert.ToBoolean(dr("YARDS"))
                        If CHKYARDS.CheckState = CheckState.Checked Then CMDYARDS.Enabled = False



                        'Item Grid
                        GRIDCHECKING.Rows.Add(dr("GRIDSRNO").ToString, Format(dr("PARTYMTRS"), "0.00"), Format(dr("CHECKEDMTRS"), "0.00"), dr("GRIDREMARKS").ToString, dr("APPROVED"), Format(dr("DIFF"), "0.00"), Format(dr("WT"), "0.000"), dr("DONE").ToString)

                    Next
                    total()
                    GRIDCHECKING.FirstDisplayedScrollingRowIndex = GRIDCHECKING.RowCount - 1
                End If
                Dim OBJ As New ClsCommon()
                Dim dt As New DataTable
                If TXTTYPE.Text = "G.R.N" Then
                    dt = OBJ.search(" grn_TOTALqty,GRN_DATE,GRN_TOTALMTRS ", "", " grn ", " AND GRN_TYPE = 'G.R.N' and grn_no=" & TXTGRNNO.Text.Trim & "  and grn_yearid=" & YearId)
                    If dt.Rows.Count > 0 Then
                        TXTGRNQTY.Text = dt.Rows(0).Item(0)
                        GRNDATE.Value = dt.Rows(0).Item(1)
                        TXTGRNMTRS.Text = dt.Rows(0).Item(2)
                    End If
                Else
                    'GET DATA FROM OPENING
                    dt = OBJ.search(" SM_PCS AS PCS, SM_DATE AS DATE, SM_MTRS AS MTRS  ", "", " STOCKMASTER ", " AND SM_NO =" & Val(TXTGRNNO.Text.Trim) & "  and SM_yearid=" & YearId)
                    If dt.Rows.Count > 0 Then
                        TXTGRNQTY.Text = Val(dt.Rows(0).Item("PCS"))
                        GRNDATE.Value = dt.Rows(0).Item("DATE")
                        TXTGRNMTRS.Text = Val(dt.Rows(0).Item("MTRS"))
                    End If

                End If

                For Each row As DataGridViewRow In GRIDCHECKING.Rows
                    If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then 'row.Cells(16).Value <> "" Or
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
                        'lbllocked.Visible = True
                        'PBlock.Visible = True
                    End If
                Next
                total()
                chkchange.CheckState = CheckState.Checked
            End If

            If GRIDCHECKING.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).Cells(0).Value) + 1
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
            If cmbname.Text.Trim = "" Then
                If ClientName = "TULSI" Or ClientName = "SHREENATH" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ") Else fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ")
            End If
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBCONTRACTOR.Text.Trim = "" Then fillCONTRACTOR(CMBCONTRACTOR)
            If CMBGODOWN.Text.Trim = "" Then FILLGODOWN(CMBGODOWN, False)
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

            Dim OBJCHECKING As New GRNCheckingDetails
            OBJCHECKING.MdiParent = MDIMain
            OBJCHECKING.Show()
            OBJCHECKING.BringToFront()
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

    Private Sub cmdselectGRN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDSELECTGRN.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            selectGRNtable.Clear()
            Dim OBJSELECTGRN As New SelectGRN
            OBJSELECTGRN.GODOWN = CMBGODOWN.Text.Trim
            selectGRNtable = OBJSELECTGRN.DT
            OBJSELECTGRN.ShowDialog()


            Dim i As Integer = 0
            If selectGRNtable.Rows.Count > 0 Then
                chkchange.Checked = True
                If edit = False Then GRIDCHECKING.RowCount = 0
                Dim POGRIDSRNO As String = ""
                Dim tempno As Integer = 0



                For i = 0 To selectGRNtable.Rows.Count - 1

                    If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                        cmbname.Text = selectGRNtable.Rows(i).Item("BROKER")
                        TXTSUPPNAME.Text = selectGRNtable.Rows(i).Item("NAME")
                    Else
                        cmbname.Text = selectGRNtable.Rows(i).Item("NAME")
                        TXTSUPPNAME.Text = selectGRNtable.Rows(i).Item("SENDER")
                    End If

                    TXTWEAVERNAME.Text = selectGRNtable.Rows(i).Item("WEAVER")
                    TXTBROKER.Text = selectGRNtable.Rows(i).Item("BROKER")
                    TXTBALENOS.Text = selectGRNtable.Rows(i).Item("BALENOS")
                    TXTWIDTH.Text = selectGRNtable.Rows(i).Item("GREYWIDTH")
                    TXTREADYWIDTH.Text = selectGRNtable.Rows(i).Item("READYWIDTH")

                    TXTITEMNAME.Text = selectGRNtable.Rows(i).Item("ITEMNAME")
                    txtremarks.Text = selectGRNtable.Rows(i).Item("DESC")
                    TXTQUALITY.Text = selectGRNtable.Rows(i).Item("QUALITY")
                    CMBQUALITY.Text = selectGRNtable.Rows(i).Item("QUALITY")
                    TXTREED.Text = selectGRNtable.Rows(i).Item("REED")
                    TXTPICK.Text = selectGRNtable.Rows(i).Item("PICK")
                    TXTCOLOR.Text = selectGRNtable.Rows(i).Item("COLOR")
                    TXTGRNQTY.Text = Format(Val(selectGRNtable.Rows(i).Item("QTY")), "0.00")
                    TXTGRNMTRS.Text = Format(Val(selectGRNtable.Rows(i).Item("MTRS")), "0.00")
                    TXTLOTNO.Text = selectGRNtable.Rows(i).Item("LOTNO")
                    TXTGRNNO.Text = selectGRNtable.Rows(i).Item("GRNNO")
                    TXTGRNGRIDSRNO.Text = selectGRNtable.Rows(i).Item("GRIDSRNO")
                    TXTTYPE.Text = selectGRNtable.Rows(i).Item("TYPE")
                    GRNDATE.Value = Format(Convert.ToDateTime(selectGRNtable.Rows(i).Item("GRNDATE")).Date, "dd/MM/yyyy")


                    TXTRATE.Text = Val(selectGRNtable.Rows(i).Item("RATE"))

                    'If POGRIDSRNO = "" Then
                    '    POGRIDSRNO = selectGRNtable.Rows(i).Item("GRIDSRNO")
                    '    tempno = selectGRNtable.Rows(i).Item("GRIDSRNO")
                    'Else
                    '    If tempno <> selectGRNtable.Rows(i).Item("GRIDSRNO") Then
                    '        POGRIDSRNO = POGRIDSRNO & "," & selectGRNtable.Rows(i).Item("GRIDSRNO")
                    '        tempno = selectGRNtable.Rows(i).Item("GRIDSRNO")
                    '    End If
                    'End If

                Next
                Dim OBJ As New ClsCommon()
                Dim dt As New DataTable
                dt = OBJ.search(" grn_TOTALqty,GRN_DATE,GRN_TOTALMTRS ", "", " grn ", " and grn_no=" & TXTLOTNO.Text.Trim & " and grn_cmpid=" & CmpId & " and grn_locationid=" & Locationid & " and grn_yearid=" & YearId & " and grn_type='G.R.N'")
                'If dt.Rows.Count > 0 Then
                '    TXTGRNQTY.Text = dt.Rows(0).Item(0)
                '    GRNDATE.Value = dt.Rows(0).Item(1)
                '    TXTGRNMTRS.Text = dt.Rows(0).Item(2)

                'End If
                total()
                getsrno(GRIDCHECKING)
                'cmbname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDCHECKING.RowCount = 0
            TEMPCHECKINGNO = Val(tstxtbillno.Text)
            If TEMPCHECKINGNO > 0 Then
                edit = True
                GRNChecking_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDCHECKING.Enabled = True
        If CMBAPPOROVED.Text = "No" Then TXTDIFF.Text = 0
        If gridDoubleClick = False Then

            GRIDCHECKING.Rows.Add(Val(txtsrno.Text.Trim), Format(Val(TXTPARTYMTRS.Text.Trim), "0.00"), Format(Val(TXTCHECKEDMTRS.Text.Trim), "0.00"), TXTGRIDREMARKS.Text.Trim, CMBAPPOROVED.Text.Trim, Format(Val(TXTDIFF.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.000"), 0)
            getsrno(GRIDCHECKING)
        ElseIf gridDoubleClick = True Then
            GRIDCHECKING.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDCHECKING.Item(GPARTYMTRS.Index, temprow).Value = TXTPARTYMTRS.Text.Trim

            If CMBAPPOROVED.Text = "No" Then TXTCHECKEDMTRS.Text = Val(TXTPARTYMTRS.Text.Trim)

            GRIDCHECKING.Item(GMTRS.Index, temprow).Value = TXTCHECKEDMTRS.Text.Trim
            GRIDCHECKING.Item(Gdesc.Index, temprow).Value = TXTGRIDREMARKS.Text.Trim
            GRIDCHECKING.Item(GAPPROVED.Index, temprow).Value = CMBAPPOROVED.Text.Trim
            GRIDCHECKING.Item(GDIFF.Index, temprow).Value = Format(Val(TXTDIFF.Text.Trim), "0.00")
            GRIDCHECKING.Item(GWT.Index, temprow).Value = Format(Val(TXTWT.Text.Trim), "0.000")
            gridDoubleClick = False
        End If

        total()

        GRIDCHECKING.FirstDisplayedScrollingRowIndex = GRIDCHECKING.RowCount - 1
        If gridDoubleClick = False Then
            If GRIDCHECKING.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If

        TXTGRIDREMARKS.Clear()
        TXTPARTYMTRS.Clear()
        TXTCHECKEDMTRS.Clear()
        TXTDIFF.Clear()

        TXTPARTYMTRS.Focus()

    End Sub

    Private Sub GRIDCHECKING_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHECKING.CellDoubleClick
        If e.RowIndex >= 0 And GRIDCHECKING.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            If Convert.ToBoolean(GRIDCHECKING.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                MsgBox("Item Locked. First Delete from MFG")
                Exit Sub
            End If


            gridDoubleClick = True
            txtsrno.Text = GRIDCHECKING.Item(gsrno.Index, e.RowIndex).Value.ToString
            TXTGRIDREMARKS.Text = GRIDCHECKING.Item(Gdesc.Index, e.RowIndex).Value.ToString
            TXTPARTYMTRS.Text = GRIDCHECKING.Item(GPARTYMTRS.Index, e.RowIndex).Value.ToString
            TXTCHECKEDMTRS.Text = GRIDCHECKING.Item(GMTRS.Index, e.RowIndex).Value.ToString
            CMBAPPOROVED.Text = GRIDCHECKING.Item(GAPPROVED.Index, e.RowIndex).Value.ToString
            TXTDIFF.Text = GRIDCHECKING.Item(GDIFF.Index, e.RowIndex).Value.ToString
            TXTWT.Text = GRIDCHECKING.Item(GWT.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            TXTPARTYMTRS.Focus()
        End If
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDCHECKING.RowCount = 0

            TEMPCHECKINGNO = Val(TXTCHECKINGNO.Text) - 1
            If TEMPCHECKINGNO > 0 Then
                edit = True
                GRNChecking_Load(sender, e)
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
            TEMPCHECKINGNO = Val(TXTCHECKINGNO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTCHECKINGNO.Text) - 1 >= TEMPCHECKINGNO Then
                edit = True
                GRNChecking_Load(sender, e)
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

            Dim done As Boolean
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                'Dim DTTABLE As New DataTable
                'DTTABLE = getmax(" CHECK_done ", " CHECKINGMASTER_DESC", " and CHECK_no=" & TXTCHECKINGNO.Text.Trim & " AND CHECK_DONE='TRUE' AND GRN_cmpid=" & CmpId & " AND GRN_LOCATIONID = " & Locationid & " AND GRN_YEARID = " & YearId)
                'If DTTABLE.Rows.Count > 0 Then
                '    done = DTTABLE.Rows(0).Item(0)
                'End If
                If done = True Then
                    MsgBox("Checking Raised Delete Checking First", MsgBoxStyle.Critical)
                Else

                    TEMPMSG = MsgBox("Delete CHECKING?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTCHECKINGNO.Text.Trim)
                        alParaval.Add(Userid)
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(YearId)
                        alParaval.Add(TXTTYPE.Text)

                        Dim ClsGRNChecking As New ClsGRNChecking()
                        ClsGRNChecking.alParaval = alParaval
                        IntResult = ClsGRNChecking.Delete()
                        MsgBox("CHECKING Deleted")
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

    Private Sub GRIDCHECKING_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDCHECKING.CellValidating
        Try
            Dim colNum As Integer = GRIDCHECKING.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GWT.Index, GPARTYMTRS.Index, GDIFF.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDCHECKING.CurrentCell.Value = Nothing Then GRIDCHECKING.CurrentCell.Value = "0.00"
                        If colNum = GWT.Index Then GRIDCHECKING.CurrentCell.Value = Format(Convert.ToDecimal(GRIDCHECKING.Item(colNum, e.RowIndex).Value), "0.000") Else GRIDCHECKING.CurrentCell.Value = Format(Convert.ToDecimal(GRIDCHECKING.Item(colNum, e.RowIndex).Value), "0.00")

                        If (ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI") And Format(Val(GRIDCHECKING.Rows(e.RowIndex).Cells(GPARTYMTRS.Index).EditedFormattedValue - GRIDCHECKING.Rows(e.RowIndex).Cells(GMTRS.Index).EditedFormattedValue), "0.00") < 0 Then
                            If MsgBox("Checcked Mtrs Greater then Party Mtrs, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If

                        GRIDCHECKING.Rows(e.RowIndex).Cells(GDIFF.Index).Value = Format(Val(GRIDCHECKING.Rows(e.RowIndex).Cells(GPARTYMTRS.Index).EditedFormattedValue - GRIDCHECKING.Rows(e.RowIndex).Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                        total()
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

    Private Sub GRIDCHECKING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHECKING.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDCHECKING.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                'For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                'If Convert.ToBoolean(ROW.Cells(GDONE.Index).Value) = True And (ROW.Cells(GAPPROVED.Index).Value) = "Yes" Then
                '    MessageBox.Show("Some Item has been locked, You Cannot Delete This Row")
                '    Exit Sub
                '    End If
                'Next
                If Convert.ToBoolean(GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GDONE.Index).Value) = True Then
                    MessageBox.Show(" Item has been locked, You Cannot Delete This Row")
                    Exit Sub
                End If
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCHECKING.Rows.RemoveAt(GRIDCHECKING.CurrentRow.Index)
                getsrno(GRIDCHECKING)

            ElseIf e.KeyCode = Keys.F9 Then
                If GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GAPPROVED.Index).Value = "Yes" Then
                    GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GAPPROVED.Index).Value = "No"
                Else
                    GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GAPPROVED.Index).Value = "Yes"
                    GRIDCHECKING.CurrentRow.DefaultCellStyle.BackColor = Color.Empty
                End If
                If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GMTRS.Index).Value = GRIDCHECKING.Rows(GRIDCHECKING.CurrentRow.Index).Cells(GPARTYMTRS.Index).Value
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdot(e, TXTWT, Me)
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then
                If ClientName = "TULSI" Or ClientName = "SHREENATH" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ") Else fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                If ClientName = "TULSI" Or ClientName = "SHREENATH" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ", "Sundry Creditors", "ACCOUNTS") Else namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ", "Sundry Debtors", "ACCOUNTS")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTWT.Validated
        Try
            If Val(TXTLOTNO.Text.Trim) = 0 Or Val(TXTGRNGRIDSRNO.Text.Trim) = 0 Then
                MsgBox("Select GRN Properly", MsgBoxStyle.Critical)
                Exit Sub
                cmbname.Focus()
            End If

            If Val(GRIDCHECKING.RowCount) + 1 > Val(TXTGRNQTY.Text.Trim) And gridDoubleClick = False Then
                MsgBox("Extra Pcs Not Allowed, All Pcs Entered", MsgBoxStyle.Critical)
                Exit Sub
                cmbname.Focus()
            End If

            If Val(TXTPARTYMTRS.Text.Trim) > 0 And Val(TXTCHECKEDMTRS.Text.Trim) > 0 Then

                'IF APPROVED = NO THEN PARTY MTRS AND CHECKED MTRS SHOULD BE SAME
                If CMBAPPOROVED.Text = "No" Then TXTCHECKEDMTRS.Text = Val(TXTPARTYMTRS.Text)

                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPARTYMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPARTYMTRS.KeyPress
        numdot(e, TXTPARTYMTRS, Me)
    End Sub

    Private Sub TXTCHECKEDMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHECKEDMTRS.KeyPress, TXTRECMTRS.KeyPress, TXTBALMTRS.KeyPress, TXTPCSMTRS.KeyPress, TXTPCSMTRSWT.KeyPress, TXTCHECKINGCHGS.KeyPress, TXTSHORTAGEPER.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCHECKEDMTRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCHECKEDMTRS.Validated
        TXTDIFF.Text = Format(Val(TXTCHECKEDMTRS.Text) - Val(TXTPARTYMTRS.Text), "0.00")
    End Sub

    Private Sub TXTPARTYMTRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPARTYMTRS.Validated
        TXTDIFF.Text = Format(Val(TXTCHECKEDMTRS.Text) - Val(TXTPARTYMTRS.Text), "0.00")
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

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If GRIDCHECKING.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCHECKING.Rows(GRIDCHECKING.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub pbcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbcopy.Click
        Try
            If Val(TXTCOPYLINES.Text.Trim) > 0 And GRIDCHECKING.RowCount > 0 Then
                TEMPMSG = MsgBox("Wish To Copy Line", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    For I As Integer = 1 To Val(TXTCOPYLINES.Text.Trim) - 1
                        Dim ROW As DataGridViewRow = GRIDCHECKING.Rows(0).Clone()
                        GRIDCHECKING.Rows.Add(0, GRIDCHECKING.Rows(0).Cells(GPARTYMTRS.Index).Value, GRIDCHECKING.Rows(0).Cells(GMTRS.Index).Value, GRIDCHECKING.Rows(0).Cells(Gdesc.Index).Value, GRIDCHECKING.Rows(0).Cells(GAPPROVED.Index).Value, GRIDCHECKING.Rows(0).Cells(GDIFF.Index).Value, GRIDCHECKING.Rows(0).Cells(GWT.Index).Value, 0)
                    Next
                    getsrno(GRIDCHECKING)
                    total()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckingReportToolStripMenuItem.Click
        Try
            If edit = True Then
                Dim OBJGRN As New GRNCheckingDesign
                OBJGRN.GRNCHECKINGNO = TEMPCHECKINGNO
                OBJGRN.GRNCHECKINGLOTNO = GRNCHECKINGLOTNO
                OBJGRN.FRMSTRING = "CHECKING"
                OBJGRN.VENDORNAME = cmbname.Text.Trim
                OBJGRN.MdiParent = MDIMain
                OBJGRN.WHERECLAUSE = "{CHECKINGMASTER.CHECK_no}=" & TEMPCHECKINGNO & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOReportToolStripMenuItem.Click
        Try
            If edit = True AndAlso TXTREJPCS.Text > 0 Then
                'WE NEED TO SHOW REPORT SO WE HAVE COMMENTED THIS CODE
                'serverprop()

                Dim OBJGRN As New GRNCheckingDesign
                OBJGRN.WHERECLAUSE = "{CHECKINGMASTER.CHECK_no}=" & TXTCHECKINGNO.Text & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId
                OBJGRN.FRMSTRING = "RETURN"
                OBJGRN.MdiParent = MDIMain
                OBJGRN.GRNCHECKINGNO = TEMPCHECKINGNO
                OBJGRN.GRNCHECKINGLOTNO = GRNCHECKINGLOTNO
                OBJGRN.Show()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        Dim objgp As New GRNCheckingDesign
        Dim rptreturnGRNCHECKING As New RETURNGRNCheckingreport
        '**************** SET SERVER ************************
        Dim crtableLogonInfo As New TableLogOnInfo
        Dim crConnecttionInfo As New ConnectionInfo
        Dim crTables As Tables
        Dim crTable As Table

        With crConnecttionInfo
            .ServerName = SERVERNAME
            .DatabaseName = DatabaseName
            .UserID = DBUSERNAME
            .Password = Dbpassword
            .IntegratedSecurity = Dbsecurity
        End With

        crTables = rptreturnGRNCHECKING.Database.Tables
        For Each crTable In crTables
            crtableLogonInfo = crTable.LogOnInfo
            crtableLogonInfo.ConnectionInfo = crConnecttionInfo
            crTable.ApplyLogOnInfo(crtableLogonInfo)
        Next

        '************************ END *******************


        objgp.MdiParent = MDIMain
        If ClientName = "TULSI" Or ClientName = "SHREENATH" Then rptreturnGRNCHECKING.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
        rptreturnGRNCHECKING.RecordSelectionFormula = "{CHECKINGMASTER.CHECK_no}=" & TXTCHECKINGNO.Text & " and {CHECKINGMASTER.CHECK_cmpid}=" & CmpId & " and {CHECKINGMASTER.CHECK_locationid}=" & Locationid & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId
        rptreturnGRNCHECKING.PrintToPrinter(1, True, 0, 0)

        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE CHECKINGMASTER SET CHECK_DOPRINTED = 1 WHERE CHECK_NO = " & TEMPCHECKINGNO & " AND CHECK_YEARID = " & YearId, "", "")

    End Sub

    Private Sub cmdAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAuto.Click
        If GRIDCHECKING.RowCount = 0 Then
            Dim DRILL0 As Integer = MsgBox("Enter 0 Values?", MsgBoxStyle.YesNo)
            For i As Integer = 0 To Val(TXTGRNQTY.Text) - 1
                If DRILL0 = vbYes Then GRIDCHECKING.Rows.Add(i + 1, 0, 0, "", "Yes", 0.0, 0.0, 0) Else GRIDCHECKING.Rows.Add(i + 1, Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), "", "Yes", 0.0, 0.0, 0)
            Next
            total()

        Else
            'WE NEED TO COPY PARTY MTRS TO CHECKED MTRS
            If MsgBox("Copy Party Mtrs in Checked Mtrs?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                ROW.Cells(GMTRS.Index).Value = Val(ROW.Cells(GPARTYMTRS.Index).Value)
            Next
            total()
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GRIDCHECKING.RowCount = 0 Then
            For i As Integer = 0 To Val(TXTGRNQTY.Text) - 1
                GRIDCHECKING.Rows.Add(i + 1, Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), Format((TXTGRNMTRS.Text / TXTGRNQTY.Text), "0.00"), "", "No", 0.0, 0.0, 0)
            Next
            total()
        End If
    End Sub

    Private Sub CMBAPPOROVED_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAPPOROVED.Validating
        If CMBAPPOROVED.Text = "NO" Then
            TXTDIFF.Text = 0
        Else
            TXTDIFF.Text = Val(TXTPARTYMTRS.Text) - Val(TXTCHECKEDMTRS.Text)
        End If
    End Sub

    Private Sub txttslotno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttslotno.Validating
        Try
            If Val(txttslotno.Text) > 0 Then
                GRIDCHECKING.RowCount = 0
                Dim dt As DataTable
                Dim objcls As New ClsCommon()
                dt = objcls.search(" CHECKINGMASTER.CHECK_NO ", "", " CHECKINGMASTER ", " and CHECKINGMASTER.CHECK_LOTNO=" & Val(txttslotno.Text) & " and CHECKINGMASTER.CHECK_CMPID=" & CmpId & "  and CHECKINGMASTER.CHECK_LOCATIONID=" & Locationid & " and CHECKINGMASTER.CHECK_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    TEMPCHECKINGNO = Val(dt.Rows(0).Item(0))
                    If TEMPCHECKINGNO > 0 Then
                        edit = True
                        GRNChecking_Load(sender, e)
                    End If
                Else
                    MsgBox("NO RECORD FOUND")
                    clear()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTWT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTWT.Validating
        Try
            If Val(TXTWT.Text.Trim) > 20 Then
                MsgBox("Wt/Pcs cannot be so much")
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBPARTYGROUP_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPARTYGROUP.Enter
        Try
            If CMBPARTYGROUP.Text.Trim = "" Then FILLPARTYGROUP(CMBPARTYGROUP, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYGROUP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYGROUP.Validating
        Try
            If CMBPARTYGROUP.Text.Trim <> "" Then PARTYGROUPVALIDATE(CMBPARTYGROUP, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNChecking_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            'If ClientName = "MONOGRAM" Then
            '    TXTRECMTRS.ReadOnly = False
            '    TXTRECMTRS.TabStop = True
            '    TXTBALPCS.ReadOnly = False
            '    TXTBALPCS.TabStop = True
            '    TXTBALMTRS.ReadOnly = False
            '    TXTBALMTRS.TabStop = True
            '    TXTPCSMTRS.TabStop = True
            'End If

            If ClientName = "SHUBHLAXMI" Then
                CHKYARDS.Visible = True
                CMDYARDS.Visible = True
            End If

            If ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI" Then
                TXTSHORTAGEPER.ReadOnly = False
                CMBCONTRACTOR.BackColor = Color.LemonChiffon
                TOOLEXCEL.Visible = True
            End If

            If UserName = "Admin" Then CMBGODOWN.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALPCS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTBALPCS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRECMTRS_Validated(sender As Object, e As EventArgs) Handles TXTRECMTRS.Validated
        Try
            'If ClientName = "MONOGRAM" And Val(TXTRECMTRS.Text.Trim) > 0 And GRIDCHECKING.RowCount > 0 Then
            '    GRIDCHECKING.Rows(GRIDCHECKING.Rows.Count - 1).Cells(GMTRS.Index).Value = Val(GRIDCHECKING.Rows(GRIDCHECKING.Rows.Count - 1).Cells(GPARTYMTRS.Index).Value) - (Val(TXTGRNMTRS.Text.Trim) - Val(TXTRECMTRS.Text.Trim))
            '    total()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALPCS_Validated(sender As Object, e As EventArgs) Handles TXTBALPCS.Validated
        Try
            'If ClientName = "MONOGRAM" And Val(TXTBALPCS.Text.Trim) > 0 And GRIDCHECKING.RowCount > 0 And Val(TXTBALPCS.Text.Trim) <= GRIDCHECKING.RowCount Then
            '    For I As Integer = 0 To ((Val(TXTRECPCS.Text.Trim) - Val(TXTBALPCS.Text.Trim)) - 1)
            '        GRIDCHECKING.Rows(I).Cells(GAPPROVED.Index).Value = "No"
            '    Next
            '    total()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALMTRS_Validated(sender As Object, e As EventArgs) Handles TXTBALMTRS.Validated
        Try
            'If ClientName = "MONOGRAM" And Val(TXTBALMTRS.Text.Trim) > 0 And GRIDCHECKING.RowCount > 0 And Val(TXTBALMTRS.Text.Trim) <= Val(TXTRECMTRS.Text.Trim) Then
            '    TXTREJMTRS.Text = Val(TXTRECMTRS.Text.Trim) - Val(TXTBALMTRS.Text.Trim)
            '    total()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPCSMTRS_Validated(sender As Object, e As EventArgs) Handles TXTPCSMTRS.Validated, TXTPCSMTRSWT.Validated
        total()
    End Sub

    Private Sub CMDSELECTGRN_Validated(sender As Object, e As EventArgs) Handles CMDSELECTGRN.Validated
        If ClientName = "MONOGRAM" Then CMBCONTRACTOR.Focus()
    End Sub

    Private Sub cmbcontractor_Enter(sender As Object, e As EventArgs) Handles CMBCONTRACTOR.Enter
        Try
            If CMBCONTRACTOR.Text.Trim = "" Then fillCONTRACTOR(CMBCONTRACTOR)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDYARDS_Click(sender As Object, e As EventArgs) Handles CMDYARDS.Click
        Try
            If edit = False And CHKYARDS.CheckState = CheckState.Checked And GRIDCHECKING.RowCount > 0 Then
                For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                    ROW.Cells(GPARTYMTRS.Index).Value = Format(Val(ROW.Cells(GPARTYMTRS.Index).Value) * 0.9144, "0.00")
                    ROW.Cells(GMTRS.Index).Value = Format(Val(ROW.Cells(GMTRS.Index).Value) * 0.9144, "0.00")
                Next
                CMDYARDS.Enabled = False
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbCONTRACTOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCONTRACTOR.Validating
        Try
            If CMBCONTRACTOR.Text.Trim <> "" Then CONTRACTORvalidate(CMBCONTRACTOR, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCONTRACTOR_Validated(sender As Object, e As EventArgs) Handles CMBCONTRACTOR.Validated
        If ClientName = "MONOGRAM" Then TXTRECMTRS.Focus()
    End Sub

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try
            If edit = False Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CHECK_GRIDSRNO,0) AS GRIDSRNO, ISNULL(CHECK_PARTYMTRS,0) AS PARTYMTRS, ISNULL(CHECK_CHECKEDMTRS,0) AS CHECKEDMTRS, ISNULL(CHECK_GRIDREMARKS,'') AS GRIDREMARKS", "", " CHECKINGMASTER_DESC ", " AND CHECK_NO = " & Val(TXTCHECKINGNO.Text.Trim) & " AND CHECK_YEARID = " & YearId)
            gridbilldetails.DataSource = DT

            Dim PATH As String = Application.StartupPath & "\Checking Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Checking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Checking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSHORTAGEPER_Validated(sender As Object, e As EventArgs) Handles TXTSHORTAGEPER.Validated
        Try
            If ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI" Then
                If GRIDCHECKING.RowCount > 0 Then
                    If MsgBox("Wish to Calculate Shrinkage Automatially?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                End If

                For Each ROW As DataGridViewRow In GRIDCHECKING.Rows
                    If Val(ROW.Cells(GPARTYMTRS.Index).Value) > 0 And ROW.Cells(GAPPROVED.Index).Value = "Yes" Then ROW.Cells(GMTRS.Index).Value = Format(Val(ROW.Cells(GPARTYMTRS.Index).Value) - ((Val(TXTSHORTAGEPER.Text.Trim) * Val(ROW.Cells(GPARTYMTRS.Index).Value)) / 100), "0.0")
                Next
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(sender As Object, e As EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then FILLGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(sender As Object, e As CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class