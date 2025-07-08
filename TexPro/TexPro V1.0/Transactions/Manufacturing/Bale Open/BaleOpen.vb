
Imports BL

Public Class BaleOpen

    Public TEMPBONO As Integer
    Public EDIT As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim IntResult As Integer

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Cursor.Current = Cursors.WaitCursor

            Dim alParaval As New ArrayList

            alParaval.Add(BODATE.Value)
            alParaval.Add(TXTBALENO.Text.Trim)
            alParaval.Add(TXTTYPE.Text.Trim)
            alParaval.Add(cmbmerchant.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)

            alParaval.Add(Val(TXTTOTALPCS.Text.Trim))
            alParaval.Add(Val(TXTTOTALMTRS.Text.Trim))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)



            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim LOTNO As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim DONE As String = ""             'WHETHER BALE OPEN IS DONE FOR THIS LINE
            Dim OUTMTRS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDFPS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(gpiecetype.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        PCS = Val(row.Cells(gpcs.Index).Value)
                        MTRS = Val(row.Cells(GMTRS.Index).Value)

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = "1"
                        Else
                            DONE = "0"
                        End If

                        OUTMTRS = Val(row.Cells(GOUTMTRS.Index).Value)

                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "," & row.Cells(gpiecetype.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(GMERCHANT.Index).Value.ToString
                        CUT = CUT & "," & row.Cells(GCUT.Index).Value.ToString
                        DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "," & row.Cells(gcolor.Index).Value.ToString
                        LOTNO = LOTNO & "," & row.Cells(GLOTNO.Index).Value
                        PCS = PCS & "," & Val(row.Cells(gpcs.Index).Value)
                        MTRS = MTRS & "," & Val(row.Cells(GMTRS.Index).Value)

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "," & "1"
                        Else
                            DONE = DONE & "," & "0"
                        End If

                        OUTMTRS = OUTMTRS & "," & Val(row.Cells(GOUTMTRS.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(CUT)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(DONE)
            alParaval.Add(OUTMTRS)



            Dim OBJMFG As New ClsBO()
            OBJMFG.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJMFG.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempbono)
                IntResult = OBJMFG.Update()
                MsgBox("Details Updated")
            End If

            clear()
            TXTBALENO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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

    Sub clear()

        TXTBONO.Clear()
        BODATE.Value = Mydate
        TXTBALENO.Clear()
        TXTBALENO.Enabled = True
        TXTTYPE.Clear()

        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        cmbmerchant.Text = ""
        CMBNAME.Text = ""
        GRIDFPS.RowCount = 0

        TXTTOTALMTRS.Clear()
        TXTTOTALPCS.Clear()

        txtremarks.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        getmaxno()

    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(BO_NO),0) + 1 ", " BALEOPEN", " AND BO_cmpid=" & CmpId & " and BO_locationid=" & Locationid & " and BO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTBONO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub fillcmb()
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " and ITEM_FRMSTRING='MERCHANT'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            FILLGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PackingSlip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

                Dim OBJCHECKING As New ClsBO()
                Dim ALPARAVAL As New ArrayList

                Dim dttable As New DataTable

                ALPARAVAL.Add(tempbono)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCHECKING.alParaval = ALPARAVAL
                dttable = OBJCHECKING.selectBO()
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        TXTBONO.Text = TEMPBONO
                        BODATE.Value = Format(Convert.ToDateTime(DR("DATE")).Date, "dd/MM/yyyy")
                        cmbmerchant.Text = Convert.ToString(DR("MAINMERCHANT").ToString)
                        CMBNAME.Text = Convert.ToString(DR("NAME").ToString)
                        CMBGODOWN.Text = Convert.ToString(DR("GODOWN").ToString)
                        TXTBALENO.Text = Convert.ToString(DR("BALENO").ToString)
                        TXTTYPE.Text = Convert.ToString(DR("TYPE").ToString)
                        TXTBALENO.Enabled = False
                        txtremarks.Text = DR("REMARKS")
                        GRIDFPS.Rows.Add(DR("GRIDSRNO").ToString, DR("PIECETYPE").ToString, DR("MERCHANT").ToString, Format(Val(DR("CUT")), "0.00"), DR("DESIGNNO").ToString, DR("COLOR").ToString, DR("LOTNO"), Format(Val(DR("PCS")), "0.00"), Format(Val(DR("MTRS")), "0.00"), DR("DONE"), Format(Val(DR("OUTMTRS")), "0.00"))
                    Next
                    TOTAL()
                End If

                chkchange.CheckState = CheckState.Checked

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try

            tempbono = Val(tstxtbillno.Text)
            If tempbono > 0 Then
                edit = True
                PackingSlip_Load(sender, e)
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

            tempbono = Val(TXTBONO.Text) - 1
            If tempbono > 0 Then
                edit = True
                PackingSlip_Load(sender, e)
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
            tempbono = Val(TXTBONO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTBONO.Text) - 1 >= tempbono Then
                edit = True
                PackingSlip_Load(sender, e)
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

                If lbllocked.Visible = True Then
                    MsgBox("Form Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Bale Open?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(tempbono)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJMFG As New ClsBO()
                    OBJMFG.alParaval = alParaval
                    IntResult = OBJMFG.Delete()
                    MsgBox("Bale Open Deleted")
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

    Private Sub TXTBALENO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBALENO.Validating
        Try
            If EDIT = True Then Exit Sub
            If TXTBALENO.Text <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TYPE, MAINMERCHANT, NAME, PIECETYPE, MERCHANT,CUT,DESIGNNO,  COLOR,LOTNO, PCS, MTRS  ", "", "   BALE_VIEW ", " AND DONE=0 AND BALENO=" & TXTBALENO.Text & " and YEARID=" & YearId & " and cmpID= " & CmpId & " and LOCATIONID =" & Locationid)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        TXTTYPE.Text = DTROW("TYPE")
                        cmbmerchant.Text = DTROW("MAINMERCHANT")
                        CMBNAME.Text = DTROW("NAME")
                        GRIDFPS.Rows.Add(0, DTROW("PIECETYPE"), DTROW("MERCHANT"), Format(Val(DTROW("CUT")), "0.00"), DTROW("DESIGNNO"), DTROW("COLOR"), DTROW("LOTNO"), Format(Val(DTROW("PCS")), "0"), Format(Val(DTROW("MTRS")), "0.00"), 0)
                    Next
                    getsrno(GRIDFPS)
                    TOTAL()
                    TXTBALENO.Enabled = False
                Else
                    MsgBox("Invalid Bale No or Bale Locked", MsgBoxStyle.Critical)
                    TXTBALENO.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALMTRS.Text = 0.0
            TXTTOTALPCS.Text = 0.0
            If GRIDFPS.RowCount > 0 Then
                For Each ROW As DataGridViewRow In GRIDFPS.Rows
                    TXTTOTALMTRS.Text = Format(Val(TXTTOTALMTRS.Text.Trim) + Val(ROW.Cells(GMTRS.Index).Value), "0.00")
                    TXTTOTALPCS.Text = Format(Val(TXTTOTALPCS.Text.Trim) + Val(ROW.Cells(gpcs.Index).Value), "0")
                Next
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

            Dim OBJPSDETAILS As New BaleOpenDetails
            OBJPSDETAILS.MdiParent = MDIMain
            OBJPSDETAILS.Show()
            OBJPSDETAILS.BringToFront()
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            EDIT = False
            TXTBALENO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BaleOpen_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If UserName = "Admin" Then CMBGODOWN.Enabled = True
    End Sub
End Class