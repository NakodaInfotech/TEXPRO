
Imports System.ComponentModel
Imports BL

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class gatePass

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public transref As String      'used for refno, gp, inv while edit mode
    Public edit As Boolean          'used for editing
    Public tempgpno As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        If ClientName = "TULSI" Or ClientName = "SHREENATH" Then TXTRATE.Text = 2.0
        If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then TXTRATE.Text = 7.0
        chkRate.CheckState = CheckState.Unchecked
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        GRIDGP.RowCount = 0


        gpdate.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Mydate
        txttransref.Clear()
        txttransremarks.Clear()

        txtremarks.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos


        cmdselectGRN.Enabled = True
        getmaxno()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False

    End Sub

    Private Sub gpdate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles gpdate.Validated
        Try
            CALCULATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gpdate.Validating
        If Not datecheck(gpdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(gp_no),0) + 1 ", "GATEPASS", " AND gp_cmpid=" & CmpId & " and gp_locationid=" & Locationid & " and gp_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtgpno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbtrans.Text.Trim.Length = 0 Then
                EP.SetError(cmbtrans, " Please Fill Company Name ")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If

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

            alParaval.Add(gpdate.Value)
            alParaval.Add(CMBGODOWN.Text.Trim)

            Dim gridsrno As String = ""
            Dim name As String = ""
            Dim lotno As String = ""
            Dim dono As String = ""
            Dim dodate As String = ""         'value of poNO
            Dim days As String = ""   'value of poGRIDSRNO
            Dim rejpcs As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim REJMTRS As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim totalpcs As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim amt As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim chkamt As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim FROMNO As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim FROMTYPE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDGP.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        name = row.Cells(gname.Index).Value.ToString
                        lotno = row.Cells(GLOTNO.Index).Value.ToString
                        dono = row.Cells(gdono.Index).Value.ToString
                        dodate = Format(Convert.ToDateTime(row.Cells(gdodate.Index).Value), "MM/dd/yyyy")
                        days = row.Cells(gDays.Index).Value.ToString
                        rejpcs = row.Cells(grejPcs.Index).Value.ToString
                        REJMTRS = Val(row.Cells(GREJMTRS.Index).Value)
                        totalpcs = row.Cells(gtotalpcs.Index).Value.ToString
                        amt = row.Cells(gAmt.Index).Value.ToString
                        chkamt = row.Cells(gChkamt.Index).Value.ToString
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        name = name & "|" & row.Cells(gname.Index).Value.ToString
                        lotno = lotno & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        dono = dono & "|" & row.Cells(gdono.Index).Value.ToString
                        dodate = dodate & "|" & Format(Convert.ToDateTime(row.Cells(gdodate.Index).Value), "MM/dd/yyyy")
                        days = days & "|" & row.Cells(gDays.Index).Value.ToString
                        rejpcs = rejpcs & "|" & row.Cells(grejPcs.Index).Value.ToString
                        REJMTRS = REJMTRS & "|" & Val(row.Cells(GREJMTRS.Index).Value)
                        totalpcs = totalpcs & "|" & row.Cells(gtotalpcs.Index).Value.ToString
                        amt = amt & "|" & row.Cells(gAmt.Index).Value.ToString
                        chkamt = chkamt & "|" & row.Cells(gChkamt.Index).Value.ToString
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(name)
            alParaval.Add(lotno)
            alParaval.Add(dono)
            alParaval.Add(dodate)
            alParaval.Add(days)
            alParaval.Add(rejpcs)
            alParaval.Add(REJMTRS)
            alParaval.Add(totalpcs)
            alParaval.Add(amt)
            alParaval.Add(chkamt)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMTYPE)

            alParaval.Add(TXTRATE.Text)
            alParaval.Add(TXTCHKRATE.Text)


            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(txttransremarks.Text.Trim)

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJGP As New Clsgp()
            OBJGP.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJGP.SAVE()
                MsgBox("Details Added")
                txtgpno.Text = DTTABLE.Rows(0).Item(0)
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempgpno)
                IntResult = OBJGP.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False

            If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                If MsgBox("Wish To Print", MsgBoxStyle.YesNo) = vbYes Then serverprop()
            Else
                PRINTREPORT()
            End If

            clear()
            cmbtrans.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ' Call cmdclear_Click(sender, e)

        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub gp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GATE PASS'")
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

                Dim objclsJO As New Clsgp()
                Dim dttable As New DataTable

                dttable = objclsJO.selectGRN(tempgpno, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        txtgpno.Text = tempgpno
                        gpdate.Value = Format(Convert.ToDateTime(dr("gpdate")).Date, "dd/MM/yyyy")
                        CMBGODOWN.Text = dr("GODOWN")

                        GRIDGP.Rows.Add(Val(dr("GRIDSRNO").ToString), Convert.ToString(dr("NAME").ToString), Convert.ToString(dr("lotno").ToString), Val(dr("dono").ToString), Format(Convert.ToDateTime(dr("DODATE")).Date, "dd/MM/yyyy"), Val(dr("DAYS").ToString), Val(dr("REJPCS").ToString), Val(dr("REJMTRS")), Val(dr("TOTALPCS").ToString), Val(dr("AMT").ToString), Val(dr("CHKAMT").ToString), Val(dr("FROMNO")), dr("FROMTYPE"))

                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("TRANSrefno").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txttransremarks.Text = dr("transremarks").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                End If

                chkchange.CheckState = CheckState.Checked
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            FILLGODOWN(CMBGODOWN, False)
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

            Dim OBJgatepassdetails As New gatepassdetails
            OBJgatepassdetails.MdiParent = MDIMain
            OBJgatepassdetails.Show()
            OBJgatepassdetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'", "Sundry Creditors")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdselectGRN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectGRN.Click
        Try
            Dim OBJSELECTPO As New SelectChecking
            OBJSELECTPO.ShowDialog()
            Dim DT As DataTable = OBJSELECTPO.DT

            Dim i As Integer = 0
            For Each ROW As DataRow In DT.Rows

                'CHECK WHETHER LOTNO IS ALREADY PRESENT IN GRID OR NOT
                For Each CHECKROW As DataGridViewRow In GRIDGP.Rows
                    If ROW("DONO") <> "" And LCase(CHECKROW.Cells(gdono.Index).Value) = LCase(ROW("DONO")) And LCase(CHECKROW.Cells(GLOTNO.Index).Value) = LCase(ROW("LOTNO")) Then GoTo LINE1
                Next

                GRIDGP.Rows.Add(i + 1, ROW("NAME"), ROW("LOTNO"), ROW("DONO"), Format(Convert.ToDateTime(ROW("DATE")).Date, "dd/MM/yyyy"), 0, Val(ROW("REJPCS")), Val(ROW("REJMTRS")), Val(ROW("TOTALPCS")), 0, Val(ROW("CHECKINGCHGS")), Val(ROW("FROMNO")), ROW("FROMTYPE"))

LINE1:
            Next
            getsrno(GRIDGP)
            CALCULATE()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALCULATE()
        Try
            For Each row As DataGridViewRow In GRIDGP.Rows
                row.Cells("gdays").Value = 0
                If (DateDiff(DateInterval.Day, row.Cells("gdodate").Value, gpdate.Value) - 6) > 0 Then row.Cells("gdays").Value = DateDiff(DateInterval.Day, row.Cells("gdodate").Value, gpdate.Value) - 6
                row.Cells("GAMT").Value = Format(Val(row.Cells("gdays").Value) * Val(row.Cells("grejpcs").Value) * Val(TXTRATE.Text.Trim), "0.00")
                If Format((Val(row.Cells("gtotalpcs").Value) / 2), "0") <= Val(row.Cells("grejpcs").Value) Then row.Cells("gchkamt").Value = Format(Val(row.Cells("gdays").Value) * Val(row.Cells("grejpcs").Value) * Val(TXTCHKRATE.Text.Trim), "0.00")
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                tempgpno = Val(tstxtbillno.Text)
                If tempgpno > 0 Then
                    edit = True
                    gp_Load(sender, e)
                Else
                    clear()
                    edit = False
                End If
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

            tempgpno = Val(txtgpno.Text) - 1
            If tempgpno > 0 Then
                edit = True
                gp_Load(sender, e)
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
            tempgpno = Val(txtgpno.Text) + 1
            getmaxno()
            clear()
            If Val(txtgpno.Text) - 1 >= tempgpno Then
                edit = True
                gp_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                    If MsgBox("Wish To Print", MsgBoxStyle.YesNo) = vbYes Then serverprop()
                Else
                    PRINTREPORT()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish To Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJGP As New GPDESIGN
            OBJGP.MdiParent = MDIMain
            OBJGP.selfor_po = "{gatepass.gp_no}=" & Val(txtgpno.Text.Trim) & " and {gatepass.gp_yearid}=" & YearId
            OBJGP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        Dim objgp As New GPDESIGN
        Dim RPTGP_TULSI As New GPREPORT_TULSI
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

        crTables = RPTGP_TULSI.Database.Tables
        For Each crTable In crTables
            crtableLogonInfo = crTable.LogOnInfo
            crtableLogonInfo.ConnectionInfo = crConnecttionInfo
            crTable.ApplyLogOnInfo(crtableLogonInfo)
        Next

        '************************ END *******************


        objgp.MdiParent = MDIMain
        RPTGP_TULSI.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
        RPTGP_TULSI.RecordSelectionFormula = "{gatepass.gp_no}=" & txtgpno.Text & " and {gatepass.gp_cmpid}=" & CmpId & " and {gatepass.gp_yearid}=" & YearId & " and {gatepass.gp_locationid}=" & Locationid
        RPTGP_TULSI.PrintToPrinter(1, True, 0, 0)
    End Sub

    Private Sub chkRate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRate.CheckedChanged
        Try
            If chkRate.CheckState = CheckState.Checked Then
                TXTRATE.Enabled = True
                TXTCHKRATE.Enabled = True
                TXTRATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdot(e, TXTRATE, Me)
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        Try
            'txtamt.Text = Format(Val(txtdays.Text) * Val(txtrejpcs.Text) * Val(TXTRATE.Text.Trim), "0.00")
            TXTRATE.Enabled = False
            TXTCHKRATE.Focus()
            CALCULATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = False Then Exit Sub
            If MsgBox("Wish to Delete Gate Pass?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJGP As New Clsgp
            OBJGP.alParaval.Add(tempgpno)
            OBJGP.alParaval.Add(CmpId)
            OBJGP.alParaval.Add(0)
            OBJGP.alParaval.Add(YearId)
            Dim INTRES As Integer = OBJGP.Delete

            MsgBox("Entry Deleted Successfully")
            edit = False
            clear()
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
    Private Sub TXTCHKRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCHKRATE.Validated
        Try
            chkRate.CheckState = CheckState.Unchecked
            'If Format((Val(TXTTOTALPCS.Text.Trim) / 2), "0") <= Val(txtrejpcs.Text.Trim) Then txtchkamt.Text = Format(Val(txtdays.Text) * Val(txtrejpcs.Text) * Val(TXTCHKRATE.Text.Trim), "0.00")
            TXTCHKRATE.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDGP.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDGP.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDGP.Rows.RemoveAt(GRIDGP.CurrentRow.Index)
                getsrno(GRIDGP)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gatePass_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If UserName = "Admin" Then CMBGODOWN.Enabled = True
    End Sub

    Private Sub CMBGODOWN_Enter(sender As Object, e As EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then FILLGODOWN(CMBGODOWN, False)
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