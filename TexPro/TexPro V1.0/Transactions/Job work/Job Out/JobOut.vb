
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class JobOut

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public tempjono As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public Shared selectjotable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        EP.Clear()
        TXTSEARCHBALENO.Clear()
        CMBNAME.Enabled = True
        CMBNAME.Text = ""
        CMBAGENT.Text = ""
        cmbmerchant.Text = ""

        TXTPOSTER.Clear()
        TXTPHOTO.Clear()
        TXTCRDAYS.Clear()
        DELDATE.Value = Mydate
        TXTRATE.Clear()
        TXTDESIGNNO.Clear()


        txtadd.Clear()
        JODATE.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Mydate
        txttransref.Clear()
        txttransremarks.Clear()

        TXTWORKTYPE.Clear()
        txtremarks.Clear()
        CHKNOTRETURN.CheckState = CheckState.Unchecked

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""


        lbllocked.Visible = False
        PBlock.Visible = False


        gridJO.RowCount = 0

        cmdselectps.Enabled = True
        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        getmaxno()


        LBLTOTALMTRS.Text = 0
        LBLTOTALpcs.Text = 0
        TXTTOTALBALES.Clear()

        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            TXTTOTALBALES.Text = 0.0
            For Each ROW As DataGridViewRow In gridJO.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(Gpcs.Index).EditedFormattedValue), "0.00")
                End If
            Next
            TXTTOTALBALES.Text = gridJO.RowCount 
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles JODATE.Validating
        If Not datecheck(JODATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JO_no),0) + 1 ", "JOBOUT", " AND JO_cmpid=" & CmpId & " and JO_locationid=" & Locationid & " and JO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTJONO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Company Name ")
                bln = False
            End If

            If cmbmerchant.Text.Trim.Length = 0 Then
                EP.SetError(cmbmerchant, " Please Select Merchant Name")
                bln = False
            End If


            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                bln = False
            End If

            If gridJO.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If Not datecheck(JODATE.Value) Then bln = False

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub TXTCRDAYS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCRDAYS.KeyPress
        numkeypress(e, TXTCRDAYS, Me)
    End Sub

    Private Sub TXTCRDAYS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCRDAYS.Validated
        DELDATE.Value = DateAdd(DateInterval.Day, CDbl(Val(TXTCRDAYS.Text)), JODATE.Value)
    End Sub

    Private Sub deldate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DELDATE.Validating
        daysremains()
    End Sub

    Sub daysremains()
        Dim tsTimeSpan As TimeSpan
        tsTimeSpan = DELDATE.Value.Subtract(JODATE.Value)
        txtcrdays.Text = tsTimeSpan.Days
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(JODATE.Value)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(cmbmerchant.Text.Trim)

            alParaval.Add(TXTPOSTER.Text.Trim)
            alParaval.Add(TXTPHOTO.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(DELDATE.Value.Date)
            alParaval.Add(Val(TXTRATE.Text.Trim))

            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(txttransremarks.Text.Trim)
            alParaval.Add(Val(LBLTOTALPCS.Text.Trim))
            alParaval.Add(Val(LBLTOTALMTRS.Text.Trim))
            alParaval.Add(Val(TXTTOTALBALES.Text.Trim))

            alParaval.Add(TXTDESIGNNO.Text.Trim)
            alParaval.Add(TXTWORKTYPE.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)

            If CHKNOTRETURN.CheckState = CheckState.Checked Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim TSNO As String = ""
            Dim JOBNO As String = ""
            Dim BALENO As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""

            Dim JODONE As String = ""      'WHETHER JO IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In gridJO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        TSNO = row.Cells(gtsno.Index).Value.ToString
                        JOBNO = row.Cells(gjobno.Index).Value.ToString
                        BALENO = row.Cells(Gbaleno.Index).Value.ToString
                        PCS = row.Cells(Gpcs.Index).Value.ToString
                        MTRS = row.Cells(Gmtrs.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            JODONE = "1"
                        Else
                            JODONE = "0"
                        End If

                    Else

                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        TSNO = TSNO & "," & row.Cells(gtsno.Index).Value.ToString
                        JOBNO = JOBNO & "," & row.Cells(gjobno.Index).Value.ToString
                        BALENO = BALENO & "," & row.Cells(Gbaleno.Index).Value.ToString
                        PCS = PCS & "," & row.Cells(Gpcs.Index).Value.ToString
                        MTRS = MTRS & "," & row.Cells(Gmtrs.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            JODONE = JODONE & "," & "1"
                        Else
                            JODONE = JODONE & "," & "0"
                        End If



                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(TSNO)
            alParaval.Add(JOBNO)
            alParaval.Add(BALENO)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(JODONE)



            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "," & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "," & row.Cells(1).Value.ToString
                        name = name & "," & row.Cells(2).Value.ToString
                        imgpath = imgpath & "," & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "," & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)


            Dim objclsJO As New ClsJO()
            objclsJO.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsJO.save()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempjono)

                IntResult = objclsJO.Update()
                MsgBox("Details Updated")

            End If
            edit = False

            TEMPMSG = MsgBox("Wish to Print JO?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                Dim OBJGRN As New JODESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "JOB"
                OBJGRN.FORMULA = "{JOBOUT.JO_NO}=" & TXTJONO.Text & " and {JOBOUT.JO_cmpid}=" & CmpId & " and {JOBOUT.JO_locationid}=" & Locationid & " and {JOBOUT.JO_yearid}=" & YearId
                OBJGRN.Show()
            End If

            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next


            clear()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub JO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB WORK OUT'")
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

                Dim objclsJO As New ClsJO()
                Dim dttable As New DataTable

                dttable = objclsJO.selectJO(tempjono, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTJONO.Text = tempjono
                        JODATE.Value = Format(Convert.ToDateTime(dr("JODATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBAGENT.Text = Convert.ToString(dr("AGENTNAME").ToString)
                        cmbmerchant.Text = Convert.ToString(dr("ITEM_NAME").ToString)

                        TXTPOSTER.Text = Convert.ToString(dr("POSTER").ToString)
                        TXTPHOTO.Text = Convert.ToString(dr("PHOTO").ToString)
                        TXTCRDAYS.Text = Val(dr("CRDAYS"))
                        DELDATE.Value = Format(Convert.ToDateTime(dr("DELDATE")).Date, "dd/MM/yyyy")
                        TXTRATE.Text = VAL(dr("RATE"))


                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("refno").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txttransremarks.Text = dr("transremarks").ToString

                        TXTDESIGNNO.Text = Convert.ToString(dr("TOTALDESIGN").ToString)
                        TXTWORKTYPE.Text = Convert.ToString(dr("WORKTYPE").ToString)
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        CHKNOTRETURN.Checked = Convert.ToBoolean(dr("NOTRETURN"))

                        'Item Grid
                        gridJO.Rows.Add(dr("GRIDSRNO").ToString, dr("TSNO").ToString, dr("JOBNO").ToString, dr("BALENO").ToString, Format(dr("PCS"), "0.00"), Format(dr("MTRS"), "0.00"), dr("GRIDDONE").ToString)

                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    total()
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" JO_GRIDSRNO AS GRIDSRNO, JO_REMARKS AS REMARKS, JO_NAME AS NAME, JO_IMGPATH AS IMGPATH, JO_NEWIMGPATH AS NEWIMGPATH", "", " JOBOUT_UPLOAD", " AND JO_NO = " & tempjono & " AND JO_CMPID = " & CmpId & " AND JO_LOCATIONID = " & Locationid & " AND JO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " and ITEM_FRMSTRING='MERCHANT'")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_NAME = 'Sundry Debtors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.GotFocus
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " and GROUPMASTER.GROUP_NAME = 'Sundry CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, e, Me, txtadd, " and GROUPMASTER.GROUP_NAME = 'Sundry CREDITORS'")
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

            Dim objgrndetails As New JobOutDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
            objgrndetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
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

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectps.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            selectjotable.Clear()
            Dim OBJSELECTPO As New SelectMfgforJob
            OBJSELECTPO.ShowDialog()

            Dim DTDESIGNNO As New DataTable
            DTDESIGNNO.Columns.Add("DESIGNNO")

            Dim i As Integer = 0
            If selectjotable.Rows.Count > 0 Then
                chkchange.Checked = True
                If edit = False Then gridJO.RowCount = 0
                For i = 0 To selectjotable.Rows.Count - 1
                    If CHECKBALENO(selectjotable.Rows(i).Item("BALENO")) = True Then gridJO.Rows.Add(i + 1, "", selectjotable.Rows(i).Item("JOBNO"), selectjotable.Rows(i).Item("BALENO"), Format(Val(selectjotable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectjotable.Rows(i).Item("MTRS")), "0.00"), 0)

                    'GET ALL DESIGN PRESENT IN THAT BALE FROM BALEVIEW
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" DISTINCT DESIGNNO ", "", " BALE_VIEW ", " AND BALENO = " & selectjotable.Rows(i).Item("BALENO") & " AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTROW As DataRow In DT.Rows
                            DTDESIGNNO.Rows.Add(DTROW("DESIGNNO"))
                        Next
                    End If

                Next

                'AFTER GETTING ALL DESIGNNO IN DATATABLE SELECT DUISTINCT DESIGN AND SHOW IN TXTBOX
                Dim DV As DataView = DTDESIGNNO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "DESIGNNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTDESIGNNO.Text.Trim = "" Then
                        TXTDESIGNNO.Text = DTR("DESIGNNO").ToString
                    Else
                        TXTDESIGNNO.Text = TXTDESIGNNO.Text & "," & DTR("DESIGNNO").ToString
                    End If
                Next

                gridJO.FirstDisplayedScrollingRowIndex = gridJO.RowCount - 1
                getsrno(gridJO)
                CMBNAME.Focus()
            End If
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKBALENO(ByVal BALENO As String) As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In gridJO.Rows
                If ROW.Cells(Gbaleno.Index).Value = BALENO Then BLN = False
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridJO.RowCount = 0
                tempjono = Val(tstxtbillno.Text)
                If tempjono > 0 Then
                    edit = True
                    JO_Load(sender, e)
                Else
                    clear()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgridscan()
        Try
            If gridUPLOADdoubleclick = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf gridUPLOADdoubleclick = True Then

                gridupload.Item(0, tempUPLOADrow).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, tempUPLOADrow).Value = txtuploadname.Text.Trim
                gridupload.Item(3, tempUPLOADrow).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, tempUPLOADrow).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, tempUPLOADrow).Value = TXTFILENAME.Text.Trim

                gridUPLOADdoubleclick = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpeg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTJONO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                gridUPLOADdoubleclick = True
                tempUPLOADrow = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If gridUPLOADdoubleclick = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub


    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            gridJO.RowCount = 0

            tempjono = Val(TXTJONO.Text) - 1
            If tempjono > 0 Then
                edit = True
                JO_Load(sender, e)
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
            tempjono = Val(TXTJONO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTJONO.Text) - 1 >= tempjono Then
                edit = True
                JO_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridjo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridJO.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridJO.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                total()
                gridJO.Rows.RemoveAt(gridJO.CurrentRow.Index)
                getsrno(gridJO)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbmerchant_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " and ITEM_FRMSTRING='MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " and ITEM_FRMSTRING='MERCHANT'", "MERCHANT")
        Catch EX As Exception
            Throw EX
        End Try

    End Sub
    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                Dim OBJGRN As New JODESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "JOB"
                OBJGRN.FORMULA = "{JOBOUT.JO_NO}=" & tempjono & " and {JOBOUT.JO_cmpid}=" & CmpId & " and {JOBOUT.JO_locationid}=" & Locationid & " and {JOBOUT.JO_yearid}=" & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
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
                    MsgBox("Packing Slip Raised against this Job,Please Delete Packing Slip First?")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Job?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(tempjono)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJMFG As New ClsJO()
                    OBJMFG.alParaval = alParaval
                    IntResult = OBJMFG.Delete()
                    MsgBox("job Deleted")
                    clear()
                    edit = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
    End Sub

    Private Sub TXTSEARCHBALENO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSEARCHBALENO.Validated
        Try
            If Val(TXTSEARCHBALENO.Text.Trim) > 0 Then
                'GET JOBNO AND OPEN THAT JOB
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("JOBOUT_DESC.JO_NO AS JONO", "", "JOBOUT_DESC", " AND JO_BALENO = " & Val(TXTSEARCHBALENO.Text.Trim) & " AND JO_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    gridJO.RowCount = 0
                    tempjono = Val(DT.Rows(0).Item("JONO"))
                    If tempjono > 0 Then
                        edit = True
                        JO_Load(sender, e)
                    Else
                        clear()
                        edit = False
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(TRANSLEDGERS.Acc_cmpname,'') AS TRANSNAME ", "", " LEDGERS LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON LEDGERS.ACC_TRANSID = TRANSLEDGERS.Acc_id ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso cmbtrans.Text.Trim = "" Then cmbtrans.Text = DT.Rows(0).Item("TRANSNAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class