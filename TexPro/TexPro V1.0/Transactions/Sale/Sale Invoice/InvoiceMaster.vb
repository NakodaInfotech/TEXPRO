
Imports BL
Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports RestSharp
Imports Newtonsoft.Json
Imports TaxProEInvoice.API

Public Class InvoiceMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public Shared selectsotable As New DataTable
    Dim GRIDDOUBLECLICK, GRIDUPLOADDOUBLECLICK, GRIDCHGSDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPINVOICENO, TEMPREGNAME, TEMPACCCODE, TEMPREFNO As String
    Public tempMsg As Integer
    Dim TEMPUPLOADROW, TEMPCHGSROW, saleregid As Integer
    Dim saleregabbr, salereginitial, TEMPSALEREG As String
    Dim SALERATE, WRATE As Double
    Dim ALLOWMANUALINVNO As Boolean = True

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXIT.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        INVOICEDATE.Text = Mydate
        If ALLOWMANUALINVNO = True Then
            TXTINVOICENO.ReadOnly = False
            TXTINVOICENO.BackColor = Color.LemonChiffon
        Else
            TXTINVOICENO.ReadOnly = True
            TXTINVOICENO.BackColor = Color.Linen
        End If
        CMBSCREENTYPE.Text = INVOICESCREENTYPE
        HIDEVIEW()

        LBLRATE.Visible = False
        LBLRATE.Text = "0.00"
        tstxtbillno.Clear()
        cmbname.Text = ""
        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()
        TXTMULTISONO.Clear()
        sodate.Value = Mydate
        TXTBALENOFROM.Clear()
        TXTBALENOTO.Clear()

        TXTLONGATION.Clear()
        CMBPROCESSTYPE.Text = ""

        TXTMAINMERCHANT.Clear()
        TXTFENTMTRS.Clear()
        TXTSAMPLEMTRS.Clear()
        TXTEWAYBILLNO.Clear()
        CMBHASTE.Text = ""
        CMBAGENT.Text = ""
        CMBHASTE.Enabled = True
        CMBAGENT.Enabled = True
        txtchallan.Clear()
        TXTPSUMMNO.Clear()
        CHALLANDATE.Text = Mydate
        txtrefno.Clear()
        CMBFORMNO.Text = ""
        TXTCRDAYS.Clear()
        duedate.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        LRDATE.Text = Mydate
        TXTVEHICLENO.Clear()
        If CMPCITYNAME <> "" Then CMBFROMCITY.Text = CMPCITYNAME Else CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""
        CMBPACKING.Text = ""

        TXTADD.Clear()
        txtDeliveryadd.Clear()

        CHKBILLCHECKED.Checked = False
        CHKBILLDISPUTE.Checked = False
        chkchange.Checked = False


        EP.Clear()
        PBCN.Visible = False
        PBRECD.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        cmdshowdetails.Visible = False

        txtremarks.Clear()
        txtinwords.Clear()

        TXTSRNO.Text = 1
        CMBITEM.Text = ""
        TXTHSNCODE.Clear()
        CMBQUALITY.Text = ""
        CMBDESIGN.Text = ""
        CMBSHADE.Text = ""
        TXTDESCRIPTION.Clear()
        TXTBALENO.Clear()
        TXTPCS.Clear()
        TXTCUT.Clear()

        TXTMTRS.Clear()
        TXTRATE.Clear()
        CMBPER.Text = "Mtrs"

        TXTAMT.Clear()
        TXTDISCPER.Clear()
        TXTDISCAMT.Clear()
        TXTSPDISCPER.Clear()
        TXTSPDISCAMT.Clear()
        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        txtgrandtotal.Clear()

        txtdescbarcode.Clear()
        GRIDINVOICE.RowCount = 0

        TXTCHGSSRNO.Text = 1
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        GRIDCHGS.RowCount = 0

        txtuploadsrno.Text = 1
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        txtimgpath.Clear()
        TXTFILENAME.Clear()
        TXTNEWIMGPATH.Clear()
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0

        GRIDLOT.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDCHGSDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False

        txtbillamt.Text = 0.0
        TXTSUBTOTAL.Text = 0.0
        TXTCHARGES.Text = 0.0
        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0
        txtremarks.Clear()

        TXTAMTREC.Clear()
        TXTRETURN.Clear()
        TXTEXTRAAMT.Clear()
        TXTBAL.Clear()

        lbltotalpcs.Text = 0.0
        lbltotalmtrs.Text = 0.0
        LBLTOTALAMT.Text = 0.0
        LBLTOTALDISCAMT.Text = 0.0
        LBLTOTALSPDISCAMT.Text = 0.0
        LBLTOTALOTHERAMT.Text = 0.0
        LBLTOTALTAXABLEAMT.Text = 0.0
        LBLTOTALCGSTAMT.Text = 0.0
        LBLTOTALSGSTAMT.Text = 0.0
        LBLTOTALIGSTAMT.Text = 0.0
        LBLTOTALBALES.Text = 0.0

        TXTTOTALLOTMTRS.Clear()

        TXTCGSTPER1.Clear()
        TXTCGSTAMT1.Clear()
        TXTSGSTPER1.Clear()
        TXTSGSTAMT1.Clear()
        TXTIGSTPER1.Clear()
        TXTIGSTAMT1.Clear()

        CMBLEDGERCODE.Text = ""
        cmbname.Text = ""
        CMBLEDGERCODE.Enabled = True
        cmbname.Enabled = True
        getmax_INVOICE_no()

        TXTTEMPRD.Clear()
        TXTTEMPRATE.Clear()

        TXTSOADVANCE.Clear()
        CMDSELECTGDN.Enabled = True
        LBLSMS.Visible = False
        TXTMOBILENO.Clear()
        e.SelectedIndex = 0
        TXTACKNO.Clear()
        TXTIRNNO.Clear()
        ACKDATE.Text = Mydate
        PBQRCODE.Image = Nothing

    End Sub

    Sub getmax_INVOICE_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(INVOICE_no),0) + 1 ", "INVOICEMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' and INVOICE_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTINVOICENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub INVOICEMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                Me.e.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                Me.e.SelectedIndex = 1
            ElseIf e.Alt = True And e.KeyCode = Keys.D3 Then
                Me.e.SelectedIndex = 2
            ElseIf e.Alt = True And e.KeyCode = Keys.D4 Then
                Me.e.SelectedIndex = 3
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDINVOICE.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            fillregister(cmbregister, " and register_type = 'SALE'")
            If cmbname.Text.Trim <> "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_NAME = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")

            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
            If CMBFROMCITY.Text.Trim = "" Then fillcity(CMBFROMCITY)
            If CMBTOCITY.Text.Trim = "" Then fillcity(CMBTOCITY)
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN)
            If CMBSHADE.Text.Trim = "" Then fillCOLOR(CMBSHADE)
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY ='Indirect Income' OR GROUPMASTER.GROUP_SECONDARY ='Indirect Expenses' or GROUPMASTER.GROUP_SECONDARY ='Direct Income' OR GROUPMASTER.GROUP_SECONDARY ='Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY ='Duties & Taxes')")
            If CMBPACKING.Text.Trim = "" Then filljobbername(CMBPACKING, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            If CMBPROCESSTYPE.Text.Trim = "" Then FILLPROCESSTYPE(CMBPROCESSTYPE, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub INVOICEMASTER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

            cmbname.Enabled = True

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim OBJINVOICE As New ClsInvoiceMaster()
                Dim DT As DataTable = OBJINVOICE.SELECTINVOICE(TEMPINVOICENO, TEMPREGNAME, CmpId, Locationid, YearId)


                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows

                        CMBSCREENTYPE.Text = dr("SCREENTYPE")
                        HIDEVIEW()

                        TXTINVOICENO.Text = TEMPINVOICENO
                        TXTINVOICENO.ReadOnly = True

                        cmbregister.Text = Convert.ToString(dr("REGNAME"))
                        INVOICEDATE.Text = Format(Convert.ToDateTime(dr("INVOICEDATE")), "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")



                        If txtchallan.Text <> "" Then
                            cmbname.Enabled = False
                            CMBLEDGERCODE.Enabled = False
                        End If

                        TXTMULTISONO.Text = Convert.ToString(dr("MULTISONO"))
                        sodate.Value = Format(Convert.ToDateTime(dr("SODATE")).Date, "dd/MM/yyyy")
                        TXTBALENOFROM.Text = Val(dr("BALENOFROM"))
                        TXTBALENOTO.Text = Val(dr("BALENOTO"))

                        TXTREADYWIDTH.Text = dr("READYWIDTH")
                        TXTEWAYBILLNO.Text = Convert.ToString(dr("EWAYBILLNO"))
                        CMBHASTE.Text = Convert.ToString(dr("HASTE"))
                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        txtchallan.Text = Convert.ToString(dr("CHALLANNO"))
                        TXTPSUMMNO.Text = Convert.ToString(dr("PSUMMNO"))
                        CHALLANDATE.Text = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        txtrefno.Text = Convert.ToString(dr("REFNO"))
                        TEMPREFNO = Convert.ToString(dr("REFNO"))
                        CMBFORMNO.Text = Convert.ToString(dr("FORM"))
                        TXTCRDAYS.Text = Convert.ToString(dr("CRDAYS"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))

                        TXTMAINMERCHANT.Text = dr("MAINMERCHANT")
                        TXTFENTMTRS.Text = Val(dr("FENTMTRS"))
                        TXTSAMPLEMTRS.Text = Val(dr("SAMPLEMTRS"))

                        cmbtrans.Text = dr("TRANSNAME")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        txtlrno.Text = dr("LRNO")
                        LRDATE.Text = Format(Convert.ToDateTime(dr("LRDATE")), "dd/MM/yyyy")
                        CMBFROMCITY.Text = Convert.ToString(dr("FROMCITY"))
                        CMBTOCITY.Text = Convert.ToString(dr("TOCITY"))
                        CMBPACKING.Text = Convert.ToString(dr("PACKING"))

                        If dr("BILLCHECKED") = 0 Then CHKBILLCHECKED.Checked = False Else CHKBILLCHECKED.Checked = True
                        If dr("BILLDISPUTE") = 0 Then CHKBILLDISPUTE.Checked = False Else CHKBILLDISPUTE.Checked = True

                        TXTLONGATION.Text = Val(dr("LONGATION"))
                        CMBPROCESSTYPE.Text = Convert.ToString(dr("PROCESSTYPE"))

                        TXTCGSTPER1.Text = Val(dr("CGSTPER"))
                        TXTSGSTPER1.Text = Val(dr("SGSTPER"))
                        TXTIGSTPER1.Text = Val(dr("IGSTPER"))

                        txtbillamt.Text = Val(dr("AMOUNT"))
                        TXTCHARGES.Text = Val(dr("CHARGES"))
                        TXTSUBTOTAL.Text = Val(dr("SUBTOTAL"))
                        txtroundoff.Text = Val(dr("ROUNDOFF"))
                        txtgrandtotal.Text = Val(dr("GRANDTOTAL"))

                        TXTAMTREC.Text = Val(dr("AMTREC"))
                        TXTEXTRAAMT.Text = Val(dr("EXTRAAMT"))
                        TXTRETURN.Text = Val(dr("RETURN"))
                        TXTBAL.Text = Val(dr("BALANCE"))

                        TXTSONO.Text = dr("SONO")

                        If Val(dr("AMTREC")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBRECD.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(dr("RETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBCN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        GRIDINVOICE.Rows.Add(dr("GRIDSRNO"), Convert.ToString(dr("ITEMNAME")), Convert.ToString(dr("HSNCODE")), Convert.ToString(dr("QUALITY")), Convert.ToString(dr("DESIGN")), Convert.ToString(dr("COLOR")), dr("GRIDREMARKS"), Convert.ToString(dr("BALENO")), Format(Val(dr("PCS")), "0.00"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER"), Format(Val(dr("AMOUNT")), "0.00"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), 0)


                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If

                    Next
                    GRIDINVOICE.FirstDisplayedScrollingRowIndex = GRIDINVOICE.RowCount - 1

                    'CHARGES GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" INVOICEMASTER_CHGS.INVOICE_gridsrno AS GRIDSRNO, LEDGERS.Acc_cmpname AS CHARGES, INVOICEMASTER_CHGS.INVOICE_PER AS PER, INVOICEMASTER_CHGS.INVOICE_AMT AS AMT, INVOICEMASTER_CHGS.INVOICE_TAXID AS TAXID ", "", " INVOICEMASTER_CHGS INNER JOIN LEDGERS ON INVOICEMASTER_CHGS.INVOICE_CHARGESID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON INVOICEMASTER_CHGS.INVOICE_REGISTERID = REGISTERMASTER.register_id ", " AND REGISTERMASTER.REGISTER_NAME = '" & TEMPREGNAME & "' AND INVOICEMASTER_CHGS.INVOICE_NO = " & TEMPINVOICENO & " AND INVOICEMASTER_CHGS.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER_CHGS.INVOICE_gridsrno")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))

                            If DTR("CHARGES") = "RD DISCOUNT" Then
                                If Val(DTR("PER")) < 0 Then TXTTEMPRD.Text = Val(DTR("PER")) * -1 Else TXTTEMPRD.Text = Val(DTR("PER"))
                            End If
                        Next
                    End If

                    'LOT GRID
                    dttable = OBJCMN.search("INVOICEMASTER_LOTDESC.INVOICE_LOTSRNO AS LOTSRNO, INVOICEMASTER_LOTDESC.INVOICE_LOTNO AS LOTNO, ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS QUALITY, ISNULL(INVOICEMASTER_LOTDESC.INVOICE_LOTRECDDATE, GETDATE()) AS LOTRECDDATE, INVOICEMASTER_LOTDESC.INVOICE_LOTPCS AS LOTPCS, INVOICEMASTER_LOTDESC.INVOICE_LOTMTRS AS LOTMTRS , INVOICEMASTER_LOTDESC.INVOICE_LOTWT AS LOTWT ", "", " INVOICEMASTER_LOTDESC INNER JOIN REGISTERMASTER ON INVOICEMASTER_LOTDESC.INVOICE_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN QUALITYMASTER ON INVOICEMASTER_LOTDESC.INVOICE_LOTQUALITYID = QUALITYMASTER.QUALITY_ID", " AND REGISTERMASTER.REGISTER_NAME = '" & TEMPREGNAME & "' AND INVOICEMASTER_LOTDESC.INVOICE_NO = " & TEMPINVOICENO & " AND INVOICEMASTER_LOTDESC.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER_LOTDESC.INVOICE_LOTSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            GRIDLOT.Rows.Add(Val(DTR("LOTSRNO")), DTR("LOTNO"), DTR("QUALITY"), Format(Convert.ToDateTime(DTR("LOTRECDDATE")).Date, "dd/MM/yyyy"), DTR("LOTPCS"), Val(DTR("LOTMTRS")), Val(DTR("LOTWT")))
                        Next
                    End If


                    'UPLOAD GRID
                    Dim OBJ As New ClsCommon
                    Dim dt2 As DataTable = OBJCMN.search(" INVOICEMASTER_UPLOAD.INVOICE_GRIDSRNO As GRIDSRNO, INVOICEMASTER_UPLOAD.INVOICE_REMARKS As REMARKS, INVOICEMASTER_UPLOAD.INVOICE_NAME As NAME, INVOICEMASTER_UPLOAD.INVOICE_IMGPATH As IMGPATH, INVOICEMASTER_UPLOAD.INVOICE_NEWIMGPATH AS NEWIMGPATH", "", " INVOICEMASTER INNER JOIN INVOICEMASTER_UPLOAD ON INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_UPLOAD.INVOICE_YEARID And INVOICEMASTER.INVOICE_LOCATIONID = INVOICEMASTER_UPLOAD.INVOICE_LOCATIONID And INVOICEMASTER.INVOICE_CMPID = INVOICEMASTER_UPLOAD.INVOICE_CMPID And INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_UPLOAD.INVOICE_REGISTERID And INVOICEMASTER.INVOICE_NO = INVOICEMASTER_UPLOAD.INVOICE_NO LEFT OUTER JOIN REGISTERMASTER ON INVOICEMASTER_UPLOAD.INVOICE_REGISTERID = REGISTERMASTER.register_id And INVOICEMASTER_UPLOAD.INVOICE_CMPID = REGISTERMASTER.register_cmpid And INVOICEMASTER_UPLOAD.INVOICE_LOCATIONID = REGISTERMASTER.register_locationid And INVOICEMASTER_UPLOAD.INVOICE_YEARID = REGISTERMASTER.register_yearid ", " And INVOICEMASTER.INVOICE_NO = " & TEMPINVOICENO & " And REGISTER_NAME ='" & TEMPREGNAME & "' AND REGISTERMASTER.REGISTER_TYPE='SALE' AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_LOCATIONID = " & Locationid & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)

                    If dt2.Rows.Count > 0 Then
                        For Each DTR3 As DataRow In dt2.Rows
                            gridupload.Rows.Add(DTR3("GRIDSRNO"), DTR3("REMARKS"), DTR3("NAME"), DTR3("IMGPATH"), DTR3("NEWIMGPATH"))
                        Next
                    End If


                    Dim clscommon As New ClsCommon
                    Dim dtID As DataTable
                    dtID = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                    If dtID.Rows.Count > 0 Then
                        saleregabbr = dtID.Rows(0).Item(0).ToString
                        salereginitial = dtID.Rows(0).Item(1).ToString
                        saleregid = dtID.Rows(0).Item(2)
                    End If
                    GRIDINVOICE.FirstDisplayedScrollingRowIndex = GRIDINVOICE.RowCount - 1
                    CHKBARCODE.Enabled = False
                Else
                    EDIT = False
                    clear()

                End If
                cmbregister.Enabled = False
                INVOICEDATE.Focus()
                chkchange.CheckState = CheckState.Checked
                TOTAL()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(CMBSCREENTYPE.Text.Trim)

            If TXTINVOICENO.ReadOnly = False Then
                alParaval.Add(Val(TXTINVOICENO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(TXTMULTISONO.Text.Trim)
            alParaval.Add(sodate.Value.Date)
            alParaval.Add(TXTBALENOFROM.Text.Trim)
            alParaval.Add(TXTBALENOTO.Text.Trim)

            alParaval.Add(Format(Convert.ToDateTime(INVOICEDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTREADYWIDTH.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)
            alParaval.Add(CMBHASTE.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(txtchallan.Text.Trim)
            alParaval.Add(TXTPSUMMNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(CMBFORMNO.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(duedate.Value.Date)

            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(LRDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBFROMCITY.Text.Trim)
            alParaval.Add(CMBTOCITY.Text.Trim)
            alParaval.Add(CMBPACKING.Text.Trim)

            If CHKBILLCHECKED.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            If CHKBILLDISPUTE.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(TXTLONGATION.Text.Trim))
            alParaval.Add(CMBPROCESSTYPE.Text.Trim)


            alParaval.Add(Val(LBLTOTALBALES.Text.Trim))
            alParaval.Add(Val(lbltotalpcs.Text.Trim))
            alParaval.Add(Val(lbltotalmtrs.Text.Trim))
            alParaval.Add(Val(TXTTOTALLOTMTRS.Text.Trim))


            If CMBSCREENTYPE.Text = "TOTAL GST" Then
                alParaval.Add(Val(TXTCGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTCGSTAMT1.Text.Trim))
                alParaval.Add(Val(TXTSGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTSGSTAMT1.Text.Trim))
                alParaval.Add(Val(TXTIGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTIGSTAMT1.Text.Trim))
            Else
                alParaval.Add(Val(TXTCGSTPER1.Text.Trim))
                alParaval.Add(Val(LBLTOTALCGSTAMT.Text.Trim))
                alParaval.Add(Val(TXTSGSTPER1.Text.Trim))
                alParaval.Add(Val(LBLTOTALSGSTAMT.Text.Trim))
                alParaval.Add(Val(TXTIGSTPER1.Text.Trim))
                alParaval.Add(Val(LBLTOTALIGSTAMT.Text.Trim))
            End If



            alParaval.Add(Val(txtbillamt.Text.Trim))
            alParaval.Add(Val(TXTCHARGES.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBAL.Text.Trim))

            alParaval.Add(txtinwords.Text)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(Val(TXTSONO.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""

            Dim QUALITY As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim PRINTDESC As String = ""
            Dim BALENO As String = ""
            Dim PCS As String = ""
            Dim CUT As String = ""

            Dim MTRS As String = ""
            Dim RATE As String = ""         'value of RATE
            Dim PER As String = ""
            Dim AMT As String = ""         'value of AMT
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDINVOICE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GSHADE.Index).Value.ToString
                        If row.Cells(GDESCRIPTION.Index).Value <> Nothing Then PRINTDESC = row.Cells(GDESCRIPTION.Index).Value.ToString Else PRINTDESC = ""
                        BALENO = row.Cells(GBALENO.Index).Value.ToString
                        PCS = Val(row.Cells(Gpcs.Index).Value.ToString)
                        CUT = Val(row.Cells(GCUT.Index).Value)

                        MTRS = Val(row.Cells(Gmtrs.Index).Value)
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        PER = row.Cells(GPER.Index).Value.ToString
                        AMT = Val(row.Cells(GAMT.Index).Value)
                        FROMNO = row.Cells(GFROMNO.Index).Value
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value
                    Else

                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString

                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GSHADE.Index).Value.ToString
                        If row.Cells(GDESCRIPTION.Index).Value <> Nothing Then PRINTDESC = PRINTDESC & "|" & row.Cells(GDESCRIPTION.Index).Value.ToString Else PRINTDESC = PRINTDESC & "|" & ""
                        BALENO = BALENO & "|" & row.Cells(GBALENO.Index).Value.ToString
                        PCS = PCS & "|" & Val(row.Cells(Gpcs.Index).Value)
                        CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)

                        MTRS = MTRS & "|" & Val(row.Cells(Gmtrs.Index).Value)
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        PER = PER & "|" & row.Cells(GPER.Index).Value
                        AMT = AMT & "|" & Val(row.Cells(GAMT.Index).Value)
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)

            alParaval.Add(QUALITY)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(PRINTDESC)
            alParaval.Add(BALENO)
            alParaval.Add(PCS)
            alParaval.Add(CUT)

            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(PER)
            alParaval.Add(AMT)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)


            Dim CSRNO As String = ""
            Dim CCHGS As String = ""
            Dim CPER As String = ""
            Dim CAMT As String = ""
            Dim CTAXID As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCHGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If Val(row.Cells(EAMT.Index).Value) <> 0 Then
                        If CSRNO = "" Then
                            CSRNO = row.Cells(ESRNO.Index).Value.ToString
                            CCHGS = row.Cells(ECHARGES.Index).Value.ToString
                            CPER = row.Cells(EPER.Index).Value.ToString
                            CAMT = Val(row.Cells(EAMT.Index).Value)
                            CTAXID = Val(row.Cells(ETAXID.Index).Value)
                        Else
                            CSRNO = CSRNO & "|" & row.Cells(ESRNO.Index).Value.ToString
                            CCHGS = CCHGS & "|" & row.Cells(ECHARGES.Index).Value.ToString
                            CPER = CPER & "|" & row.Cells(EPER.Index).Value.ToString
                            CAMT = CAMT & "|" & Val(row.Cells(EAMT.Index).Value)
                            CTAXID = CTAXID & "|" & Val(row.Cells(ETAXID.Index).Value)
                        End If
                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCHGS)
            alParaval.Add(CPER)
            alParaval.Add(CAMT)
            alParaval.Add(CTAXID)



            Dim LOTSRNO As String = ""
            Dim LOTNO As String = ""
            Dim LOTQUALITY As String = ""
            Dim LOTRECDDATE As String = ""
            Dim LOTPCS As String = ""
            Dim LOTMTRS As String = ""
            Dim LOTWT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDLOT.Rows
                If row.Cells(0).Value <> Nothing Then
                    If LOTSRNO = "" Then
                        LOTSRNO = Val(row.Cells(GLOTSRNO.Index).Value)
                        LOTNO = Val(row.Cells(GLOTNO.Index).Value)
                        LOTQUALITY = row.Cells(GLOTQUALITY.Index).Value
                        LOTRECDDATE = Format(Convert.ToDateTime(row.Cells(GRECDDATE.Index).Value).Date, "MM/dd/yyyy")
                        LOTPCS = Val(row.Cells(GLOTPCS.Index).Value)
                        LOTMTRS = Val(row.Cells(GLOTMTRS.Index).Value)
                        LOTWT = Val(row.Cells(GLOTWT.Index).Value)
                    Else
                        LOTSRNO = LOTSRNO & "|" & Val(row.Cells(GLOTSRNO.Index).Value)
                        LOTNO = LOTNO & "|" & Val(row.Cells(GLOTNO.Index).Value)
                        LOTQUALITY = LOTQUALITY & "|" & row.Cells(GLOTQUALITY.Index).Value
                        LOTRECDDATE = LOTRECDDATE & "|" & Format(Convert.ToDateTime(row.Cells(GRECDDATE.Index).Value).Date, "MM/dd/yyyy")
                        LOTPCS = LOTPCS & "|" & Val(row.Cells(GLOTPCS.Index).Value)
                        LOTMTRS = LOTMTRS & "|" & Val(row.Cells(GLOTMTRS.Index).Value)
                        LOTWT = LOTWT & "|" & Val(row.Cells(GLOTWT.Index).Value)
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
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)

            alParaval.Add(ClientName)
            alParaval.Add(TXTMAINMERCHANT.Text.Trim)
            alParaval.Add(Val(TXTFENTMTRS.Text.Trim))
            alParaval.Add(Val(TXTSAMPLEMTRS.Text.Trim))
            alParaval.Add(TXTIRNNO.Text.Trim)
            alParaval.Add(TXTACKNO.Text.Trim)
            alParaval.Add(Format(ACKDATE.Value.Date, "MM/dd/yyyy"))
            If PBQRCODE.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If


            Dim objclsPurord As New ClsInvoiceMaster()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                PRINTREPORT(DT.Rows(0).Item(0))
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPINVOICENO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                PRINTREPORT(TEMPINVOICENO)
                EDIT = False
            End If

            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)
            If ClientName = "DAKSH" Then TXTINVOICENO.Focus() Else INVOICEDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal INVOICENO As Integer)
        Try
            tempMsg = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            If tempMsg = vbYes Then

                Dim OBJPRINT As New PrintInvoiceFilter
                OBJPRINT.INVOICENO = INVOICENO
                OBJPRINT.REGISTERNAME = cmbregister.Text.Trim
                OBJPRINT.PARTYNAME = cmbname.Text.Trim
                OBJPRINT.AGENTNAME = CMBAGENT.Text.Trim
                OBJPRINT.TEMPSTATECODE = TXTSTATECODE.Text.Trim
                OBJPRINT.BLANKPAPER = CHKBLANKPAPER.Checked

                'INITIIALLY WE HAVE TAKEN WT OF FIRST LOT ONLY
                'NOW AS PER CHITRA MAM WE NEED AVG OF WT 
                'CHANGES DONE ON 23-04-22 
                OBJPRINT.AVG82 = 0
                OBJPRINT.AVG100 = 0
                For Each ROW As DataGridViewRow In GRIDLOT.Rows
                    OBJPRINT.AVG82 = Format(Val(OBJPRINT.AVG82) + Val(ROW.Cells(GLOTWT.Index).Value), "0.000")
                    OBJPRINT.AVG100 = Format(Val(OBJPRINT.AVG100) + Val(ROW.Cells(GLOTWT.Index).Value), "0.000")
                Next
                If Val(OBJPRINT.AVG82) > 0 Then OBJPRINT.AVG82 = Format(Val(OBJPRINT.AVG82) / Val(GRIDLOT.RowCount), "0.000")
                If Val(OBJPRINT.AVG100) > 0 Then OBJPRINT.AVG100 = Format(Val(OBJPRINT.AVG100) / Val(GRIDLOT.RowCount), "0.000")

                OBJPRINT.AVG82 = Format(Val(OBJPRINT.AVG82) * 82, "0.00")
                OBJPRINT.AVG100 = Format(Val(OBJPRINT.AVG100) * 100, "0.00")

                OBJPRINT.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Val(TXTBALENOFROM.Text.Trim) > 0 And Val(TXTBALENOTO.Text.Trim) > 0 Then
            If Val(TXTBALENOFROM.Text.Trim) > Val(TXTBALENOTO.Text.Trim) Then
                EP.SetError(TXTBALENOTO, " From Bale No Cannot Be Greater Than To Bale No ")
                bln = False
            End If
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Enter Register Name")
            bln = False
        End If


        If Val(TXTINVOICENO.Text.Trim) = 0 Then
            EP.SetError(TXTINVOICENO, "Enter Invoice No")
            bln = False
        End If

        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Sale Return Raised, Delete Sale Return First")
            bln = False
        End If

        If GRIDINVOICE.RowCount = 0 Then
            EP.SetError(cmbname, "Enter Bill Details")
            bln = False
        End If

        If ALLOWMANUALINVNO = True Then
            If TXTINVOICENO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_NO, '') AS INVOICENO, REGISTERMASTER.register_name AS REGNAME ", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id AND INVOICEMASTER.INVOICE_CMPID = REGISTERMASTER.register_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = REGISTERMASTER.register_locationid AND INVOICEMASTER.INVOICE_YEARID = REGISTERMASTER.register_yearid ", "  AND INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_LOCATIONID = " & Locationid & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTINVOICENO, "Invoice No Already Exist")
                    bln = False
                End If
            End If
        End If

        If Convert.ToDateTime(INVOICEDATE.Text).Date >= "01/07/2017" Then
            If TXTSTATECODE.Text.Trim.Length = 0 Then
                EP.SetError(TXTSTATECODE, "Please enter the state code")
                bln = False
            End If

            'If TXTGSTIN.Text.Trim.Length = 0 Then
            '    If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '        EP.SetError(TXTSTATECODE, "Enter GSTIN in Party Master")
            '        bln = False
            '    End If
            'End If

            If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(LBLTOTALCGSTAMT.Text) > 0 Or Val(LBLTOTALSGSTAMT.Text.Trim) > 0) Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in CGST/SGST")
                bln = False
            End If

            If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(LBLTOTALIGSTAMT.Text) > 0 Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in IGST")
                bln = False
            End If
        End If

        For Each row As DataGridViewRow In GRIDINVOICE.Rows
            If Val(row.Cells(Gmtrs.Index).Value) = 0 And Val(row.Cells(Gpcs.Index).Value) = 0 Then
                EP.SetError(cmbname, "Mtrs & Pcs Cannot be 0")
                bln = False
            End If
        Next

        If Val(txtgrandtotal.Text.Trim) = 0 Then
            EP.SetError(txtgrandtotal, "Amt Cannot be 0")
            bln = False
        End If

        If UserName <> "Admin" Then
            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
                bln = False
            End If
        End If

        If INVOICEDATE.Text = "__/__/____" Then
            EP.SetError(INVOICEDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(INVOICEDATE.Text) Then
                EP.SetError(INVOICEDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub TOTAL()
        Try
            LBLTOTALBALES.Text = "0.0"
            lbltotalpcs.Text = "0.0"
            lbltotalmtrs.Text = "0.0"
            LBLTOTALMTRSWITHRATE.Text = 0

            LBLTOTALAMT.Text = "0.0"
            LBLTOTALDISCAMT.Text = 0.0
            LBLTOTALSPDISCAMT.Text = 0.0
            LBLTOTALOTHERAMT.Text = "0.0"
            LBLTOTALTAXABLEAMT.Text = "0.0"
            LBLTOTALCGSTAMT.Text = "0.0"
            LBLTOTALSGSTAMT.Text = "0.0"
            LBLTOTALIGSTAMT.Text = "0.0"

            TXTTEMPRATE.Clear()
            TXTTOTALLOTMTRS.Clear()


            txtbillamt.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTSUBTOTAL.Text = 0
            txtroundoff.Text = 0
            txtgrandtotal.Text = 0

            BALECOUNT()

            Dim RDMTRS As Double = 0

            If GRIDINVOICE.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDINVOICE.Rows
                    If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Then
                        row.Cells(GAMT.Index).Value = Format((row.Cells(Gmtrs.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                    ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Pcs" Then
                        row.Cells(GAMT.Index).Value = Format((row.Cells(Gpcs.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                    End If

                    If row.Cells(GRATE.Index).EditedFormattedValue > 0 Then RDMTRS += Val(row.Cells(Gmtrs.Index).EditedFormattedValue)

                    If CMBSCREENTYPE.Text = "LINE GST" Then
                        If Val(row.Cells(GDISCPER.Index).EditedFormattedValue) <> 0 Then row.Cells(GDISCAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).Value) * (Val(row.Cells(GDISCPER.Index).EditedFormattedValue) / 100), "0.00")
                        If Val(row.Cells(GSPDISCPER.Index).EditedFormattedValue) <> 0 Then
                            'CALC ON RUNNING TOTAL FOR EVERYONE
                            row.Cells(GSPDISCAMT.Index).Value = Format((Val(row.Cells(GAMT.Index).Value) - Val(row.Cells(GDISCAMT.Index).Value)) * (Val(row.Cells(GSPDISCPER.Index).EditedFormattedValue) / 100), "0.00")

                            'IF ANY CLIENT DONT WANT ABOVE MENTIONED CODE ENABLE BELOW CODE
                            If ClientName = "" Then
                                row.Cells(GSPDISCAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).Value) * (Val(row.Cells(GSPDISCPER.Index).EditedFormattedValue) / 100), "0.00")
                            End If
                        End If
                        row.Cells(GTAXABLEAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).EditedFormattedValue) - Val(row.Cells(GDISCAMT.Index).EditedFormattedValue) - Val(row.Cells(GSPDISCAMT.Index).EditedFormattedValue) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")

                        row.Cells(GCGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GCGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                        row.Cells(GSGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GSGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                        row.Cells(GIGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GIGSTPER.Index).EditedFormattedValue) / 100), "0.00")

                        row.Cells(GGRIDTOTAL.Index).Value = Format(Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")
                    Else
                        'THIS WAS THE CODE WRITTEN HERE, WE HAVE CHANGED
                        'row.Cells(GTAXABLEAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).EditedFormattedValue) - Val(row.Cells(GDISCAMT.Index).EditedFormattedValue) - Val(row.Cells(GSPDISCAMT.Index).EditedFormattedValue) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                        'row.Cells(GGRIDTOTAL.Index).Value = Format(Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")
                        row.Cells(GTAXABLEAMT.Index).Value = Format(Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                        row.Cells(GGRIDTOTAL.Index).Value = Format(Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue), "0.00")
                    End If

                    If Val(row.Cells(Gpcs.Index).Value) <> 0 Then lbltotalpcs.Text = Format(Val(lbltotalpcs.Text) + Val(row.Cells(Gpcs.Index).EditedFormattedValue), "0")
                    If Val(row.Cells(Gmtrs.Index).Value) <> 0 Then lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(row.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")

                    'FOR EINV CALC, WE NEED ONLY THOSE MTRS WHERE RATE <> 0
                    If Val(row.Cells(Gmtrs.Index).Value) <> 0 And Val(row.Cells(GRATE.Index).EditedFormattedValue) > 0 Then LBLTOTALMTRSWITHRATE.Text = Format(Val(LBLTOTALMTRSWITHRATE.Text) + Val(row.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")

                    If Val(row.Cells(GAMT.Index).Value) <> 0 Then LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")

                    If Val(row.Cells(GDISCAMT.Index).Value) <> 0 Then LBLTOTALDISCAMT.Text = Format(Val(LBLTOTALDISCAMT.Text) + Val(row.Cells(GDISCAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GSPDISCAMT.Index).Value) <> 0 Then LBLTOTALSPDISCAMT.Text = Format(Val(LBLTOTALSPDISCAMT.Text) + Val(row.Cells(GSPDISCAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GOTHERAMT.Index).Value) <> 0 Then LBLTOTALOTHERAMT.Text = Format(Val(LBLTOTALOTHERAMT.Text) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GTAXABLEAMT.Index).Value) <> 0 Then LBLTOTALTAXABLEAMT.Text = Format(Val(LBLTOTALTAXABLEAMT.Text) + Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue), "0.00")

                    If Val(row.Cells(GCGSTAMT.Index).Value) <> 0 Then LBLTOTALCGSTAMT.Text = Format(Val(LBLTOTALCGSTAMT.Text) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GSGSTAMT.Index).Value) <> 0 Then LBLTOTALSGSTAMT.Text = Format(Val(LBLTOTALSGSTAMT.Text) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GIGSTAMT.Index).Value) <> 0 Then LBLTOTALIGSTAMT.Text = Format(Val(LBLTOTALIGSTAMT.Text) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(GGRIDTOTAL.Index).Value) <> 0 Then txtbillamt.Text = Format(Val(txtbillamt.Text) + Val(row.Cells(GGRIDTOTAL.Index).EditedFormattedValue), "0.00")

                Next
            End If


            TXTTEMPRATE.Text = Format(Val(LBLTOTALAMT.Text.Trim) / Val(RDMTRS), "0.00") - Val(TXTTEMPRD.Text.Trim)

            For Each row As DataGridViewRow In GRIDLOT.Rows
                TXTTOTALLOTMTRS.Text = Format(Val(TXTTOTALLOTMTRS.Text) + Val(row.Cells(GLOTMTRS.Index).Value), "0.00")
            Next



            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows

                    If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                        If row.Cells(ECHARGES.Index).Value = "FENT CHGS" Then
                            If GRIDLOT.RowCount > 0 Then row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * (Val(TXTFENTMTRS.Text.Trim) * (Val(GRIDLOT.Rows(0).Cells(GLOTWT.Index).Value) - (Val(GRIDLOT.Rows(0).Cells(GLOTWT.Index).Value) * 0.2)))), "0.00")

                        ElseIf row.Cells(ECHARGES.Index).Value = "RD DISCOUNT" Then
                            row.Cells(EAMT.Index).Value = Format(Val(row.Cells(EPER.Index).Value) * Val(RDMTRS), "0.00")

                        Else
                            Dim OBJCMN As New ClsCommon
                            Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_CALC,'GROSS') AS CALC", "", "LEDGERS", "AND ACC_CMPNAME = '" & row.Cells(ECHARGES.Index).Value & "' AND ACC_YEARID = " & YearId)

                            If DT.Rows(0).Item("CALC") = "GROSS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(txtbillamt.Text.Trim)) / 100, "0.00")
                            ElseIf DT.Rows(0).Item("CALC") = "NETT" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                TXTNETTAMT.Text = Val(txtbillamt.Text.Trim)
                                For I As Integer = 0 To row.Index - 1
                                    TXTNETTAMT.Text = Format(Val(TXTNETTAMT.Text) + Val(GRIDCHGS.Rows(I).Cells(EAMT.Index).Value), "0.00")
                                Next
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(TXTNETTAMT.Text.Trim)) / 100, "0.00")
                            ElseIf DT.Rows(0).Item("CALC") = "BALES" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(LBLTOTALBALES.Text.Trim)), "0.00")
                            ElseIf DT.Rows(0).Item("CALC") = "MTRS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(lbltotalmtrs.Text.Trim)), "0.00")
                            ElseIf DT.Rows(0).Item("CALC") = "PCS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(lbltotalpcs.Text.Trim)), "0.00")
                            End If
                        End If
                    End If

                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If





            TXTSUBTOTAL.Text = Format(Val(txtbillamt.Text) + Val(TXTCHARGES.Text.Trim), "0.00")

            If CMBSCREENTYPE.Text <> "LINE GST" Then
                TXTCGSTAMT1.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTCGSTPER1.Text.Trim)) / 100, "0.00")
                LBLTOTALCGSTAMT.Text = Val(TXTCGSTAMT1.Text.Trim)
                TXTSGSTAMT1.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTSGSTPER1.Text.Trim)) / 100, "0.00")
                LBLTOTALSGSTAMT.Text = Val(TXTSGSTAMT1.Text.Trim)
                TXTIGSTAMT1.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTIGSTPER1.Text.Trim)) / 100, "0.00")
                LBLTOTALIGSTAMT.Text = Val(TXTIGSTAMT1.Text.Trim)

                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim)), "0.00")
            Else
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - Val(TXTSUBTOTAL.Text), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")
            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BALECOUNT()
        Try
            LBLTOTALBALES.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDINVOICE.Rows.Count - 1
                If Not GRIDINVOICE.Rows(i).IsNewRow Then
                    cellValue = GRIDINVOICE(GBALENO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALBALES.Text = Val(dic.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Rec / Return Made, Delete Rec First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                tempMsg = MsgBox("Delete Invoice ?", MsgBoxStyle.YesNo)
                If tempMsg = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTINVOICENO.Text.Trim)
                    alParaval.Add(TEMPREGNAME)
                    alParaval.Add(YearId)
                    'CHANGES'
                    alParaval.Add(Userid)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)


                    Dim clspo As New ClsInvoiceMaster()
                    clspo.alParaval = alParaval
                    IntResult = clspo.Delete()
                    MsgBox("Invoice Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolprevious.Click
        Try
            GRIDINVOICE.RowCount = 0
LINE1:
            TEMPINVOICENO = Val(TXTINVOICENO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPINVOICENO > 0 Then
                EDIT = True
                INVOICEMASTER_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDINVOICE.RowCount = 0 And TEMPINVOICENO > 1 Then
                TXTINVOICENO.Text = TEMPINVOICENO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDINVOICE.RowCount = 0
LINE1:
            TEMPINVOICENO = Val(TXTINVOICENO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmax_INVOICE_no()
            Dim MAXNO As Integer = TXTINVOICENO.Text.Trim
            clear()
            If Val(TXTINVOICENO.Text) - 1 >= TEMPINVOICENO Then
                EDIT = True
                INVOICEMASTER_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDINVOICE.RowCount = 0 And TEMPINVOICENO < MAXNO Then
                TXTINVOICENO.Text = TEMPINVOICENO
                GoTo LINE1
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

            Dim objINVDTLS As New InvoiceDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            ' Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'namevalidate(cmbname, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS")
            namevalidate(cmbname, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry Debtors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            cmdOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPINVOICENO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDINVOICE.RowCount = 0
                TEMPINVOICENO = Val(tstxtbillno.Text)
                TEMPREGNAME = cmbregister.Text.Trim
                If TEMPINVOICENO > 0 Then
                    EDIT = True
                    INVOICEMASTER_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTGDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTGDN.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If cmbname.Text = "" Then
                MsgBox("Select Party Name First !", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim DTTABLE As DataTable
            Dim OBJSELECTPO As New SelectGdn
            OBJSELECTPO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTPO.ShowDialog()

            DTTABLE = OBJSELECTPO.DT1

            Dim i As Integer = 0
            If DTTABLE.Rows.Count > 0 Then
                chkchange.Checked = True

                Me.e.SelectedIndex = 0

                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim OBJCMN As New ClsCommon
                Dim DV As DataView = DTTABLE.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "GDNNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                        If TXTPSUMMNO.Text.Trim = "" Then
                            TXTPSUMMNO.Text = DTR("GDNNO").ToString
                        Else
                            TXTPSUMMNO.Text = TXTPSUMMNO.Text & "," & DTR("GDNNO").ToString
                        End If
                        Dim DTLOT As DataTable = OBJCMN.search(" PS_LOTSRNO AS LOTSRNO, PS_LOTNO AS LOTNO, ISNULL(QUALITY_NAME,'') AS LOTQUALITY, ISNULL(PS_LOTRECDDATE,GETDATE()) AS LOTRECDDATE, PS_LOTPCS AS LOTPCS, PS_LOTMTRS AS LOTMTRS, PS_LOTWT AS LOTWT ", "", " PACKINGSUMMARY_LOTDESC LEFT OUTER JOIN QUALITYMASTER ON PS_LOTQUALITYID = QUALITY_ID", " AND PS_NO = " & Val(DTR("GDNNO")) & " AND PS_YEARID = " & YearId)
                        For Each DRROW As DataRow In DTLOT.Rows
                            GRIDLOT.Rows.Add(Val(DRROW("LOTSRNO")), DRROW("LOTNO"), DRROW("LOTQUALITY"), Format(Convert.ToDateTime(DRROW("LOTRECDDATE")).Date, "dd/MM/yyyy"), DRROW("LOTPCS"), Val(DRROW("LOTMTRS")), Val(DRROW("LOTWT")))
                        Next
                    Else
                        If txtchallan.Text.Trim = "" Then
                            txtchallan.Text = DTR("GDNNO").ToString
                        Else
                            txtchallan.Text = txtchallan.Text & "," & DTR("GDNNO").ToString
                        End If
                    End If
                Next


                'FETCH PROCESSTYPE, COLORTYPE FROM FINALPACKINGSLIP AND LONGATION FROM PACKINGSUMM
                If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                    Dim TEMPDT As DataTable = OBJCMN.search("ISNULL(PROCESSTYPE_NAME,'') AS PROCESSTYPE", "", " FINALPACKINGSLIP LEFT OUTER JOIN PROCESSTYPEMASTER ON FPS_PROCESSTYPEID = PROCESSTYPE_ID", " AND FPS_NO = " & Val(DTTABLE.Rows(0).Item("BALENO")) & " AND FPS_YEARID = " & YearId)
                    If TEMPDT.Rows.Count > 0 Then CMBPROCESSTYPE.Text = TEMPDT.Rows(0).Item("PROCESSTYPE")

                    TEMPDT = OBJCMN.search("ISNULL(PS_LONGATION,0) AS LONGATION", "", " PACKINGSUMMARY", " AND PS_NO = " & Val(DTTABLE.Rows(0).Item("GDNNO")) & " AND PS_YEARID = " & YearId)
                    If TEMPDT.Rows.Count > 0 Then TXTLONGATION.Text = Val(TEMPDT.Rows(0).Item("LONGATION"))

                End If


                For i = 0 To DTTABLE.Rows.Count - 1
                    Dim DT As New DataTable
                    If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                        DT = OBJCMN.search(" ISNULL(PACKINGSUMMARY.PS_NO, 0) AS GDNNO, PACKINGSUMMARY.PS_date AS CHALLANDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, '' AS CONSIGNEE, '' AS AGENT, '' AS TRANS, '' AS LRNO, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALESRNO, 0) AS SRNO, '' AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, '' AS QUALITY, '' AS DESIGN, '' AS COLOR, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALENO, '') AS BALENO, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALEPCS, 0) AS PCS, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALECONVMTRS, PACKINGSUMMARY_BALEDESC.PS_BALEMTRS) AS MTRS, ISNULL(PACKINGSUMMARY_BALEDESC.PS_NO, 0) AS FROMNO, ISNULL(PACKINGSUMMARY_BALEDESC.PS_BALESRNO, 0) AS FROMSRNO, 'PACKINGSUMMARY' AS FROMTYPE, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER, ISNULL(MAINMERCHANT.ITEM_NAME,'') AS MAINMERCHANT, ISNULL(PACKINGSUMMARY.PS_FENTMTRS,0) AS FENTMTRS, ISNULL(PACKINGSUMMARY.PS_SAMPLEMTR,0) AS SAMPLEMTRS, ISNULL(PACKINGSUMMARY.PS_CUTTINGCHGS,0) AS CUTTINGCHGS, ISNULL(PACKINGSUMMARY.PS_CARTONCHGS,0) AS CARTONCHGS, ISNULL(PACKINGSUMMARY.PS_NEWFOLD,0) AS NEWFOLD ", "", "   PACKINGSUMMARY INNER JOIN PACKINGSUMMARY_BALEDESC ON PACKINGSUMMARY.PS_NO = PACKINGSUMMARY_BALEDESC.PS_NO AND PACKINGSUMMARY.PS_YEARID = PACKINGSUMMARY_BALEDESC.PS_YEARID INNER JOIN LEDGERS ON PACKINGSUMMARY.PS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  LEFT OUTER JOIN ITEMMASTER ON PACKINGSUMMARY_BALEDESC.PS_MERCHANTID = ITEMMASTER.item_id LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID LEFT OUTER JOIN ITEMMASTER AS MAINMERCHANT ON PACKINGSUMMARY.PS_QUALITYID = MAINMERCHANT.ITEM_ID", "  and PACKINGSUMMARY.PS_NO=" & Val(DTTABLE.Rows(i).Item("GDNNO")) & "  and PACKINGSUMMARY_BALEDESC.PS_BALESRNO=" & Val(DTTABLE.Rows(i).Item("SRNO")) & " and PACKINGSUMMARY.PS_INVDONE=0 AND PACKINGSUMMARY.PS_YEARID = " & YearId & " ORDER BY PACKINGSUMMARY_BALEDESC.PS_BALESRNO")
                    Else
                        DT = OBJCMN.search(" ISNULL(GDN.GDN_NO, 0) AS GDNNO, GDN.GDN_date AS CHALLANDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, '' AS CONSIGNEE, ISNULL(AGENTMASTER.Acc_cmpname, '') AS AGENT, ISNULL(TRANSLEDGER.Acc_cmpname, '') AS TRANS, ISNULL(GDN_PSDESC.GDN_LRNO, '') AS LRNO, ISNULL(GDN_PSDESC.GDN_SRNO, 0) AS SRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, '' AS DESIGN, '' AS COLOR, ISNULL(GDN_PSDESC.GDN_PSNO, '') AS BALENO, ISNULL(GDN_PSDESC.GDN_PCS, 0) AS PCS, ISNULL(GDN_PSDESC.GDN_MTRS, 0) AS MTRS, ISNULL(GDN_PSDESC.GDN_NO, 0) AS FROMNO, ISNULL(GDN_PSDESC.GDN_SRNO, 0) AS FROMSRNO, 'GDN' AS FROMTYPE, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER, 0 AS FENTMTRS, 0 AS CUTTINGCHGS, 0 AS CARTONCHGS, 0 AS NEWFOLD ", "", "   GDN INNER JOIN GDN_PSDESC ON GDN.GDN_NO = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID INNER JOIN LEDGERS ON GDN_PSDESC.GDN_PARTYID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  LEFT OUTER JOIN QUALITYMASTER ON GDN_PSDESC.GDN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON GDN_PSDESC.GDN_MERCHANTID = ITEMMASTER.item_id LEFT OUTER JOIN PIECETYPEMASTER ON GDN_PSDESC.GDN_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGER ON GDN.GDN_transid = TRANSLEDGER.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTMASTER ON GDN.GDN_AGENTID = AGENTMASTER.Acc_id LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID", "  and GDN.GDN_NO=" & Val(DTTABLE.Rows(i).Item("GDNNO")) & " and GDN_PSDESC.GDN_SRNO=" & Val(DTTABLE.Rows(i).Item("SRNO")) & " and GDN_PSDESC.GDN_DONE=0 AND GDN.GDN_YEARID = " & YearId & " ORDER BY GDN_PSDESC.GDN_SRNO")
                    End If

                    If DT.Rows.Count > 0 Then

                        For Each dr As DataRow In DT.Rows

                            TXTSTATECODE.Text = dr("STATECODE")
                            TXTGSTIN.Text = dr("GSTIN")
                            cmbname.Text = dr("NAME")
                            TXTREADYWIDTH.Text = DTTABLE.Rows(i).Item("READYWIDTH")
                            If dr("AGENT") <> "" Then CMBAGENT.Text = dr("AGENT")
                            CMBHASTE.Text = dr("CONSIGNEE")
                            cmbtrans.Text = dr("TRANS")
                            txtlrno.Text = dr("LRNO")
                            TXTMAINMERCHANT.Text = dr("MAINMERCHANT")
                            TXTFENTMTRS.Text = Val(dr("FENTMTRS"))
                            TXTSAMPLEMTRS.Text = Val(dr("SAMPLEMTRS"))

                            cmbname_Validated(sender, e)

                            'ADD CUTTING AND CARTON CHGS
                            If ClientName = "DHANLAXMI" Then
                                Dim DTCHGS As DataTable = OBJCMN.search(" ISNULL(LEDGERS.ACC_CUTTINGCHGS,0) AS CUTTINGCHGS, ISNULL(LEDGERS.ACC_CARTONCHGS,0) AS CARTONCHGS", "", " LEDGERS ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
                                If Convert.ToBoolean(dr("CUTTINGCHGS")) = True Then
                                    If GRIDCHGS.RowCount > 0 Then
                                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                                            If DTROW.Cells(ECHARGES.Index).Value = "CUTTING CHGS" Then GoTo LINE1
                                        Next
                                        If Val(DTCHGS.Rows(0).Item("CUTTINGCHGS")) > 0 Then GRIDCHGS.Rows.Insert(GRIDCHGS.RowCount - 1, 0, "CUTTING CHGS", Val(DTCHGS.Rows(0).Item("CUTTINGCHGS")), 0, 0)
                                    Else
                                        GRIDCHGS.Rows.Add(0, "CUTTING CHGS", Val(DTCHGS.Rows(0).Item("CUTTINGCHGS")), 0, 0)
                                    End If
                                End If

                                If Convert.ToBoolean(dr("CARTONCHGS")) = True Then
                                    If GRIDCHGS.RowCount > 0 Then
                                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                                            If DTROW.Cells(ECHARGES.Index).Value = "CARTON CHGS" Then GoTo LINE1
                                        Next
                                        If Val(DTCHGS.Rows(0).Item("CARTONCHGS")) > 0 Then GRIDCHGS.Rows.Insert(GRIDCHGS.RowCount - 1, 0, "CARTON CHGS", Val(DTCHGS.Rows(0).Item("CARTONCHGS")), 0, 0)
                                    Else
                                        GRIDCHGS.Rows.Add(0, "CARTON CHGS", Val(DTCHGS.Rows(0).Item("CARTONCHGS")), 0, 0)
                                    End If
                                End If
                            End If



                            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                                'GET RDDISC FROM DISCOUNTMASTER WITH RESPECT TO LEDGER
                                For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                                    If DTROW.Cells(ECHARGES.Index).Value = "RD DISCOUNT" Then GoTo LINE1
                                Next
                                Dim DTDISC As DataTable = OBJCMN.search(" DISC_RATE AS RDDISC", "", " DISCOUNTMASTER INNER JOIN LEDGERS ON DISC_ID = ACC_PRICELISTCOLUMN INNER JOIN DISCOUNTMASTER_DESC ON DISCOUNTMASTER.DISC_ID = DISCOUNTMASTER_DESC.DISC_ID INNER JOIN ITEMMASTER ON DISC_ITEMID = ITEM_ID ", " AND ITEMMASTER.ITEM_NAME = '" & TXTMAINMERCHANT.Text.Trim & "' AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
                                If DTDISC.Rows.Count > 0 AndAlso Val(DTDISC.Rows(0).Item("RDDISC")) > 0 Then
                                    If GRIDCHGS.RowCount > 0 Then GRIDCHGS.Rows.Insert(0, GRIDCHGS.RowCount + 1, "RD DISCOUNT", Val(DTDISC.Rows(0).Item("RDDISC")) * -1, 0, 0) Else GRIDCHGS.Rows.Add(0, "RD DISCOUNT", Val(DTDISC.Rows(0).Item("RDDISC")) * -1, 0, 0)
                                End If
                            End If


LINE1:

                            getsrno(GRIDCHGS)
                            CHALLANDATE.Text = Convert.ToDateTime(dr("CHALLANDATE")).Date
                            cmbname.Enabled = False

                            If dr("ITEM").ToString <> "" And Convert.ToDateTime(INVOICEDATE.Text).Date >= "01/07/2017" Then
                                Dim FOLD As String = dr("NEWFOLD").ToString
                                Dim RATE As Double = 0.0

                                'FETCH FBNO AND RATE FROM BALENO AND SHOW IN DESC
                                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                                    Dim DTFB As DataTable = OBJCMN.search("ISNULL(FBNO,'') AS FOLD, MAINMERCHANT, PIECETYPE, COLORTYPE", "", "ALLBALE_VIEW", " AND BALENO = " & Val(dr("BALENO")) & " AND YEARID = " & YearId)
                                    If DTFB.Rows.Count > 0 Then
                                        If Val(FOLD) = 0 Then FOLD = DTFB.Rows(0).Item("FOLD")

                                        'FETCH RATE
                                        Dim DTRATE As DataTable = OBJCMN.search("ISNULL(MERCHANT_RATE,0) AS RATE, ISNULL(MERCHANTPRICELIST.MERCHANT_WHITE,0) AS WHITE, ISNULL(MERCHANTPRICELIST.MERCHANT_CREAM,0) AS CREAM, ISNULL(MERCHANTPRICELIST.MERCHANT_LIGHT,0) AS LIGHT, ISNULL(MERCHANTPRICELIST.MERCHANT_DARK,0) AS DARK, ISNULL(MERCHANTPRICELIST.MERCHANT_EXTRADARK,0) AS EXTRADARK, ISNULL(MERCHANTPRICELIST.MERCHANT_RAINBOW,0) AS RAINBOW", "", " MERCHANTPRICELIST INNER JOIN ITEMMASTER ON MERCHANT_ID  = ITEM_ID INNER JOIN PIECETYPEMASTER ON MERCHANT_PIECETYPEID = PIECETYPE_ID", " AND ITEMMASTER.ITEM_NAME = '" & DTFB.Rows(0).Item("MAINMERCHANT") & "' AND PIECETYPEMASTER.PIECETYPE_NAME = '" & DTFB.Rows(0).Item("PIECETYPE") & "' AND MERCHANT_YEARID = " & YearId)
                                        If DTRATE.Rows.Count > 0 Then
                                            If DTFB.Rows(0).Item("COLORTYPE") = "" Or DTFB.Rows(0).Item("COLORTYPE") = "MEDIUM" Then RATE = Val(DTRATE.Rows(0).Item("RATE")) Else RATE = Val(DTRATE.Rows(0).Item(DTFB.Rows(0).Item("COLORTYPE")))
                                        End If
                                    End If
                                End If

                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    GRIDINVOICE.Rows.Add(0, dr("ITEM"), dr("HSNCODE"), dr("QUALITY"), "", "", FOLD, dr("BALENO"), Format(Val(dr("PCS")), "0.00"), "0.00", Format(Val(dr("MTRS")), "0.00"), RATE, "Mtrs", "0.00", Val(TXTDISCPER.Text.Trim), 0, 0, 0, "0.00", "0.00", dr("CGSTPER"), "0.00", dr("SGSTPER"), "0.00", "0.00", "0.00", "0.00", "", Val(dr("GDNNO")), Val(dr("SRNO")), dr("FROMTYPE"), 0)
                                    TXTCGSTPER1.Text = Val(dr("CGSTPER"))
                                    TXTSGSTPER1.Text = Val(dr("SGSTPER"))
                                    TXTIGSTPER1.Text = 0
                                Else
                                    GRIDINVOICE.Rows.Add(0, dr("ITEM"), dr("HSNCODE"), dr("QUALITY"), "", "", FOLD, dr("BALENO"), Format(Val(dr("PCS")), "0.00"), "0.00", Format(Val(dr("MTRS")), "0.00"), RATE, "Mtrs", "0.00", Val(TXTDISCPER.Text.Trim), 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", dr("IGSTPER"), "0.00", "0.00", "", Val(dr("GDNNO")), Val(dr("SRNO")), dr("FROMTYPE"), 0)
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = Val(dr("IGSTPER"))
                                End If
                            Else
                                GRIDINVOICE.Rows.Add(0, dr("ITEM"), " ", dr("QUALITY"), "", "", "", dr("BALENO"), Format(Val(dr("PCS")), "0.00"), "0.00", Format(Val(dr("MTRS")), "0.00"), 0, "Mtrs", "0.00", Val(TXTDISCPER.Text.Trim), 0, 0, 0, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "", Val(dr("GDNNO")), Val(dr("SRNO")), dr("FROMTYPE"), 0)
                            End If

                        Next
                    End If
                Next


                GRIDINVOICE.FirstDisplayedScrollingRowIndex = GRIDINVOICE.RowCount - 1
                getsrno(GRIDINVOICE)
                If GRIDINVOICE.RowCount > 0 Then
                    GRIDINVOICE.Focus()
                    GRIDINVOICE.CurrentCell = GRIDINVOICE.Rows(0).Cells(GRATE.Index)
                End If
                CHKBARCODE.Enabled = False
            End If
            ' End If
            TOTAL()
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

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmax_INVOICE_no()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And EDIT = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    saleregabbr = dt.Rows(0).Item(0).ToString
                    salereginitial = dt.Rows(0).Item(1).ToString
                    saleregid = dt.Rows(0).Item(2)
                    getmax_INVOICE_no()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDINVOICE.CurrentRow.Index >= 0 And GRIDINVOICE.Item(GSRNO.Index, GRIDINVOICE.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDINVOICE.Item(GSRNO.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                CMBITEM.Text = GRIDINVOICE.Item(GITEMNAME.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDINVOICE.Item(GHSNCODE.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDINVOICE.Item(GQUALITY.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDINVOICE.Item(GDESIGN.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                CMBSHADE.Text = GRIDINVOICE.Item(GSHADE.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTDESCRIPTION.Text = GRIDINVOICE.Item(GDESCRIPTION.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDINVOICE.Item(GBALENO.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTPCS.Text = GRIDINVOICE.Item(Gpcs.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDINVOICE.Item(GCUT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString

                TXTMTRS.Text = GRIDINVOICE.Item(Gmtrs.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDINVOICE.Item(GRATE.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                CMBPER.Text = GRIDINVOICE.Item(GPER.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTAMT.Text = GRIDINVOICE.Item(GAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTDISCPER.Text = GRIDINVOICE.Item(GDISCPER.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTDISCAMT.Text = GRIDINVOICE.Item(GDISCAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTSPDISCPER.Text = GRIDINVOICE.Item(GSPDISCPER.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTSPDISCAMT.Text = GRIDINVOICE.Item(GSPDISCAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTOTHERAMT.Text = GRIDINVOICE.Item(GOTHERAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTTAXABLEAMT.Text = GRIDINVOICE.Item(GTAXABLEAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTCGSTPER.Text = GRIDINVOICE.Item(GCGSTPER.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTCGSTAMT.Text = GRIDINVOICE.Item(GCGSTAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTSGSTPER.Text = GRIDINVOICE.Item(GSGSTPER.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTSGSTAMT.Text = GRIDINVOICE.Item(GSGSTAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTIGSTPER.Text = GRIDINVOICE.Item(GIGSTPER.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTIGSTAMT.Text = GRIDINVOICE.Item(GIGSTAMT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTGRIDTOTAL.Text = GRIDINVOICE.Item(GGRIDTOTAL.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString

                txtdescbarcode.Text = GRIDINVOICE.Item(GBARCODE.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDINVOICE.CurrentRow.Index
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINVOICE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDINVOICE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDINVOICE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDINVOICE.Rows.RemoveAt(GRIDINVOICE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDINVOICE)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F9 And GRIDINVOICE.CurrentRow.Index > 0 Then
                If GRIDINVOICE.Rows(GRIDINVOICE.CurrentRow.Index - 1).Cells(GRATE.Index).Value <> 0 Then GRIDINVOICE.Rows(GRIDINVOICE.CurrentRow.Index).Cells(GRATE.Index).Value = GRIDINVOICE.Rows(GRIDINVOICE.CurrentRow.Index - 1).Cells(GRATE.Index).Value
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNNOTE.Click
        Try
            If Convert.ToDateTime(INVOICEDATE.Text).Date >= "01/07/2017" Then
                MsgBox("Credit Note Cannot be Raised for This Invoice, Create Sale Return", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If PBRECD.Visible = True Then
                MsgBox("Rec made, Delete Rec First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Credit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New CREDITNOTE
                    OBJdN.MdiParent = MDIMain
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME  = '" & cmbregister.Text.Trim & "' AND REGISTER_CMPID = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    OBJdN.BILLNO = DT.Rows(0).Item("INITIALS") & "-" & Val(TXTINVOICENO.Text.Trim)
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS_1.ACC_CMPNAME,'') AS TRANSNAME,ISNULL(LEDGERS_2.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_DISC,0) AS DISCPER, isnull(LEDGERS.ACC_CRDAYS,0) AS CRDAYS, ISNULL(LEDGERS.ACC_BALEINS,0) AS BALEINS, ISNULL(LEDGERS.ACC_TRANSRS,0) AS TRANSRS, ISNULL(LEDGERS.ACC_SPPACKING,0) AS SPPACKING, ISNULL(LEDGERS.ACC_FENTCHGS,0) AS FENTCHGS, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITY_ID ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbtrans.Text = DT.Rows(0).Item("TRANSNAME")
                    CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")
                    TXTDISCPER.Text = Val(DT.Rows(0).Item("DISCPER"))
                    If CMBTOCITY.Text.Trim = "" Then CMBTOCITY.Text = DT.Rows(0).Item("CITYNAME")

                    If Val(TXTCRDAYS.Text.Trim) = 0 Then
                        If Val(DT.Rows(0).Item("CRDAYS")) > 0 Then TXTCRDAYS.Text = Val(DT.Rows(0).Item("CRDAYS"))
                        If ClientName = "SANGHVI" Then TXTCRDAYS.Text = 30
                        If Val(TXTCRDAYS.Text) > 0 And INVOICEDATE.Text <> "__/__/____" Then Call TXTCRDAYS_Validated(sender, e)
                    End If

                    If DT.Rows(0).Item("REGISTERNAME") <> cmbregister.Text.Trim And DT.Rows(0).Item("REGISTERNAME") <> "" Then
                        Dim TEMPMSG As Integer = MsgBox("Register is Different Change to Default?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbYes Then
                            cmbregister.Text = DT.Rows(0).Item("REGISTERNAME")
                            getmax_BILL_no()
                        End If
                    End If

                    'IN CHARGES GRID ADD DISCOUNT GIVEN 
                    If (ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI") Then


                        'GET RDDISC FROM DISCOUNTMASTER WITH RESPECT TO LEDGER
                        Dim DTDISC As DataTable = OBJCMN.search(" DISC_RATE AS RDDISC", "", " DISCOUNTMASTER INNER JOIN LEDGERS ON DISC_ID = ACC_PRICELISTCOLUMN INNER JOIN DISCOUNTMASTER_DESC ON DISCOUNTMASTER.DISC_ID = DISCOUNTMASTER_DESC.DISC_ID INNER JOIN ITEMMASTER ON DISC_ITEMID = ITEM_ID ", " AND ITEMMASTER.ITEM_NAME = '" & TXTMAINMERCHANT.Text.Trim & "' AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
                        If DTDISC.Rows.Count > 0 AndAlso Val(DTDISC.Rows(0).Item("RDDISC")) > 0 Then

                            For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                                If DTROW.Cells(ECHARGES.Index).Value = "RD DISCOUNT" Then
                                    If Val(DTROW.Cells(EPER.Index).Value) < 0 Then TXTTEMPRD.Text = Val(DTROW.Cells(EPER.Index).Value) * -1 Else TXTTEMPRD.Text = Val(DTROW.Cells(EPER.Index).Value)
                                    GoTo LINE1
                                End If
                            Next

                            If GRIDCHGS.RowCount = 0 Then
                                GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "RD DISCOUNT", Val(DTDISC.Rows(0).Item("RDDISC")) * -1, 0, 0)
                            Else
                                GRIDCHGS.Rows.Insert(0, New String() {0, "RD DISCOUNT", Val(DTDISC.Rows(0).Item("RDDISC")) * -1, 0, 0})
                            End If
                            TXTTEMPRD.Text = Val(DTDISC.Rows(0).Item("RDDISC"))
                        End If


                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "FENT CHGS" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("FENTCHGS")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "FENT CHGS", Val(DT.Rows(0).Item("FENTCHGS")) * -1, 0, 0)


                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "BALE INSURANCE" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("BALEINS")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "BALE INSURANCE", Val(DT.Rows(0).Item("BALEINS")), 0, 0)


                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "TRANSPORT CHGS" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("TRANSRS")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "TRANSPORT CHGS", Val(DT.Rows(0).Item("TRANSRS")), 0, 0)


                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "SPECIAL PACKING" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("SPPACKING")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "SPECIAL PACKING", Val(DT.Rows(0).Item("SPPACKING")), 0, 0)


                        For Each DTROW As DataGridViewRow In GRIDCHGS.Rows
                            If DTROW.Cells(ECHARGES.Index).Value = "CASH DISCOUNT" Then GoTo LINE1
                        Next
                        If Val(DT.Rows(0).Item("DISCPER")) > 0 Then GRIDCHGS.Rows.Add(GRIDCHGS.RowCount + 1, "CASH DISCOUNT", Val(DT.Rows(0).Item("DISCPER")) * -1, 0, 0)

                    End If

LINE1:


                    If CMBPACKING.Text.Trim = "" Then CMBPACKING.Text = cmbname.Text.Trim



                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHASTE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHASTE.Enter
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHASTE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" ADDRESS_alias ", "", "   ADDRESSMASTER INNER JOIN LEDGERS ON ADDRESSMASTER.ADDRESS_LEDGERID = LEDGERS.ACC_id AND ADDRESSMASTER.ADDRESS_cmpid = LEDGERS.ACC_cmpid AND ADDRESSMASTER.ADDRESS_locationid = LEDGERS.ACC_locationid AND ADDRESSMASTER.ADDRESS_yearid = LEDGERS.ACC_yearid  ", "  and  LEDGERS.ACC_cmpname ='" & cmbname.Text.Trim & "' and ADDRESS_cmpid=" & CmpId & " and ADDRESS_Locationid=" & Locationid & " and ADDRESS_Yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ADDRESS_alias"
                    CMBHASTE.DataSource = dt
                    CMBHASTE.DisplayMember = "ADDRESS_alias"
                End If
                CMBHASTE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBHASTE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHASTE.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHASTE.Text.Trim <> "" Then
                pcase(CMBHASTE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ADDRESS_full", "", " ADDRESSMASTER INNER JOIN LEDGERS ON ADDRESSMASTER.ADDRESS_LEDGERID = LEDGERS.ACC_id AND ADDRESSMASTER.ADDRESS_cmpid = LEDGERS.ACC_cmpid AND ADDRESSMASTER.ADDRESS_locationid = LEDGERS.ACC_locationid AND ADDRESSMASTER.ADDRESS_yearid = LEDGERS.ACC_yearid  ", "  and  LEDGERS.ACC_cmpname ='" & cmbname.Text.Trim & "'  and ADDRESS_alias = '" & CMBHASTE.Text.Trim & "' and ADDRESS_cmpid = " & CmpId & " and ADDRESS_Locationid = " & Locationid & " and ADDRESS_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBHASTE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("ADDRESS not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then

                        CMBHASTE.Text = a
                        Dim objADDRESSmaster As New addressMaster
                        objADDRESSmaster.txtname.Text = CMBHASTE.Text
                        objADDRESSmaster.cmbname.Text = cmbname.Text
                        objADDRESSmaster.cmbname.Enabled = False
                        objADDRESSmaster.ShowDialog()
                        dt = objclscommon.search("ADDRESS_alias", "", "ADDRESSMaster", " and ADDRESS_alias = '" & CMBHASTE.Text.Trim & "' and ADDRESS_cmpid = " & CmpId & " and ADDRESS_Locationid = " & Locationid & " and ADDRESS_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBHASTE.DataSource
                            If CMBHASTE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHASTE.Text.Trim)
                                    CMBHASTE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtDeliveryadd.Text = dt.Rows(0).Item(0).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        If CMBAGENT.Text.Trim = "" Then fillledger(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            'If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "AGENT")
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY Creditors'", "Sundry Creditors", "AGENT")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFORMNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFORMNO.Validating
        Try
            If CMBFORMNO.Text.Trim <> "" Then FORMvalidate(CMBFORMNO, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getmax_BILL_no()
        Dim DTTABLE As New DataTable
        If cmbregister.Text <> "" Then
            DTTABLE = getmax(" isnull(max(INVOICEMASTER_no),0) + 1 ", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID AND INVOICE_CMPID = REGISTER_CMPID AND INVOICE_LOCATIONID = REGISTER_LOCATIONID AND INVOICE_YEARID = REGISTER_YEARID ", " and REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER_cmpid=" & CmpId & " and INVOICEMASTER_locationid=" & Locationid & " and INVOICEMASTER_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTINVOICENO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            'If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY Creditors'", "Sundry Creditors", "TRANSPORT")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCITY.Validating
        Try
            If CMBTOCITY.Text.Trim <> "" Then CITYVALIDATE(CMBTOCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEM.Validating
        Try
            If CMBITEM.Text.Trim <> "" Then itemvalidate(CMBITEM, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEM.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then fillCOLOR(CMBSHADE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTPCS.KeyPress
        AMOUNTNUMDOTKYEPRESS(e, sender, Me)
    End Sub

    Private Sub TXTPCS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPCS.Validated
        CALC()
        TOTAL()
    End Sub

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        CALC()
        TOTAL()
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdot(e, TXTRATE, Me)
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        CALC()
        TOTAL()
    End Sub

    Sub CALC()
        Try
            TXTAMT.Text = 0.0
            TXTGRIDTOTAL.Text = 0.0
            If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCAMT.Clear()
            If Val(TXTSPDISCPER.Text.Trim) > 0 Then TXTSPDISCAMT.Clear()
            TXTCGSTAMT.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTAMT.Text = 0.0

            'TXTCGSTAMT1.Text = 0.0
            'TXTSGSTAMT1.Text = 0.0
            'TXTIGSTAMT1.Text = 0.0

            If Val(TXTRATE.Text.Trim) > 0 Then
                If CMBPER.Text = "Mtrs" Then
                    TXTAMT.Text = Format(Val(TXTMTRS.Text) * Val(TXTRATE.Text), "0.00")
                Else
                    TXTAMT.Text = Format(Val(TXTPCS.Text) * Val(TXTRATE.Text), "0.00")
                End If
            End If
            If Val(TXTDISCPER.Text.Trim) > 0 And Val(TXTDISCAMT.Text.Trim) = 0 Then TXTDISCAMT.Text = Format(Val(TXTAMT.Text.Trim) * (Val(TXTDISCPER.Text.Trim) / 100), "0.00")
            If Val(TXTSPDISCPER.Text.Trim) > 0 And Val(TXTSPDISCAMT.Text.Trim) = 0 Then TXTSPDISCAMT.Text = Format((Val(TXTAMT.Text.Trim) - Val(TXTDISCAMT.Text.Trim)) * (Val(TXTSPDISCPER.Text.Trim) / 100), "0.00")
            TXTTAXABLEAMT.Text = Format((Val(TXTAMT.Text.Trim) - Val(TXTDISCAMT.Text.Trim) - Val(TXTSPDISCPER.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0.00")
            If CMBSCREENTYPE.Text = "LINE GST" Then
                TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
            End If
            TXTGRIDTOTAL.Text = Format(Val(TXTTAXABLEAMT.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text), "0.00")
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub calchgs()
        Try
            If Val(TXTCHGSPER.Text) <> 0 Then
                'before CALC CHECK HOW TO CALC CHARGES
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" (CASE WHEN ISNULL(ACC_CALC,'') = '' THEN 'GROSS' ELSE ACC_CALC END) AS CALC", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("CALC") = "GROSS" Then
                    TXTCHGSAMT.Text = Format((Val(txtbillamt.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "NETT" Then
                    'FIRST CALC NETT THEN ADD CHARGES ON THAT NETT TOTAL
                    TXTNETTAMT.Text = Val(txtbillamt.Text.Trim)
                    For Each ROW As DataGridViewRow In GRIDCHGS.Rows
                        If GRIDCHGSDOUBLECLICK = True And ROW.Index >= TEMPCHGSROW Then Exit For
                        TXTNETTAMT.Text = Format(Val(TXTNETTAMT.Text) + Val(ROW.Cells(EAMT.Index).Value), "0.00")
                    Next
                    TXTCHGSAMT.Text = Format((Val(TXTNETTAMT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "QTY" Then
                    TXTCHGSAMT.Text = Format((Val(lbltotalpcs.Text) * Val(TXTCHGSPER.Text)), "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "MTRS" Then
                    TXTCHGSAMT.Text = Format((Val(lbltotalmtrs.Text) * Val(TXTCHGSPER.Text)), "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "BALES" Then
                    TXTCHGSAMT.Text = Format((Val(LBLTOTALBALES.Text) * Val(TXTCHGSPER.Text)), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPER.Validating
        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMT.Validating
        Try
            Try
                If Val(TXTRATE.Text.Trim) = 0 Then
                    If CMBPER.Text = "Pcs" Then
                        TXTRATE.Text = Val(TXTAMT.Text) / Val(TXTPCS.Text)
                    Else
                        TXTRATE.Text = Val(TXTAMT.Text) / Val(TXTMTRS.Text)
                    End If
                End If

                If CMBITEM.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) <> 0 And CMBPER.Text.Trim <> "" Then
                    fillgrid()
                Else
                    If CMBITEM.Text.Trim = "" Then
                        MsgBox("Please Fill Item Name ")
                        CMBITEM.Focus()
                        Exit Sub
                    End If
                    If Val(TXTMTRS.Text.Trim) = 0 Then
                        MsgBox("Please Fill Mtrs  ")
                        TXTMTRS.Focus()
                        Exit Sub
                    End If
                    If CMBPER.Text.Trim = "" Then
                        MsgBox("Please Fill Per ")
                        CMBPER.Focus()
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDINVOICE.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEM.Text.Trim, TXTHSNCODE.Text.Trim, CMBQUALITY.Text.Trim, CMBDESIGN.Text.Trim, CMBSHADE.Text.Trim, TXTDESCRIPTION.Text.Trim, TXTBALENO.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), CMBPER.Text.Trim, Format(Val(TXTAMT.Text.Trim), "0.00"), Format(Val(TXTDISCPER.Text.Trim), "0.00"), Format(Val(TXTDISCAMT.Text.Trim), "0.00"), Format(Val(TXTSPDISCPER.Text.Trim), "0.00"), Format(Val(TXTSPDISCAMT.Text.Trim), "0.00"), Format(Val(TXTOTHERAMT.Text.Trim), "0.00"), Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00"), Val(TXTCGSTPER.Text.Trim), Format(Val(TXTCGSTAMT.Text.Trim), "0.00"), Val(TXTSGSTPER.Text.Trim), Format(Val(TXTSGSTAMT.Text.Trim), "0.00"), Val(TXTIGSTPER.Text.Trim), Format(Val(TXTIGSTAMT.Text.Trim), "0.00"), Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00"), txtdescbarcode.Text.Trim, 0, 0, "", 0)
            getsrno(GRIDINVOICE)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDINVOICE.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDINVOICE.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEM.Text.Trim
            GRIDINVOICE.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim
            GRIDINVOICE.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDINVOICE.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            GRIDINVOICE.Item(GSHADE.Index, TEMPROW).Value = CMBSHADE.Text.Trim
            GRIDINVOICE.Item(GDESCRIPTION.Index, TEMPROW).Value = TXTDESCRIPTION.Text.Trim
            GRIDINVOICE.Item(GBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
            GRIDINVOICE.Item(Gpcs.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
            GRIDINVOICE.Item(GCUT.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")

            GRIDINVOICE.Item(Gmtrs.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDINVOICE.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDINVOICE.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim
            GRIDINVOICE.Item(GAMT.Index, TEMPROW).Value = Format(Val(TXTAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GDISCPER.Index, TEMPROW).Value = Format(Val(TXTDISCPER.Text.Trim), "0.00")
            GRIDINVOICE.Item(GDISCAMT.Index, TEMPROW).Value = Format(Val(TXTDISCAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GSPDISCPER.Index, TEMPROW).Value = Format(Val(TXTSPDISCPER.Text.Trim), "0.00")
            GRIDINVOICE.Item(GSPDISCAMT.Index, TEMPROW).Value = Format(Val(TXTSPDISCAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GOTHERAMT.Index, TEMPROW).Value = Format(Val(TXTOTHERAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GTAXABLEAMT.Index, TEMPROW).Value = Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GCGSTPER.Index, TEMPROW).Value = Val(TXTCGSTPER.Text.Trim)
            GRIDINVOICE.Item(GCGSTAMT.Index, TEMPROW).Value = Format(Val(TXTCGSTAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GSGSTPER.Index, TEMPROW).Value = Val(TXTSGSTPER.Text.Trim)
            GRIDINVOICE.Item(GSGSTAMT.Index, TEMPROW).Value = Format(Val(TXTSGSTAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GIGSTPER.Index, TEMPROW).Value = Val(TXTIGSTPER.Text.Trim)
            GRIDINVOICE.Item(GIGSTAMT.Index, TEMPROW).Value = Format(Val(TXTIGSTAMT.Text.Trim), "0.00")
            GRIDINVOICE.Item(GGRIDTOTAL.Index, TEMPROW).Value = Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00")


            GRIDINVOICE.Item(GBARCODE.Index, TEMPROW).Value = txtdescbarcode.Text.Trim

            GRIDDOUBLECLICK = False

        End If
        TXTAMT.ReadOnly = True
        TOTAL()
        GRIDINVOICE.FirstDisplayedScrollingRowIndex = GRIDINVOICE.RowCount - 1

        TXTSRNO.Clear()
        TXTHSNCODE.Clear()
        TXTDESCRIPTION.Clear()
        TXTBALENO.Clear()
        TXTPCS.Clear()
        TXTCUT.Clear()

        TXTMTRS.Clear()
        TXTRATE.Clear()
        If ClientName = "CC" Or ClientName = "JITUBHAI" Or ClientName = "MAHAVIR" Then
            CMBPER.Text = "Pcs"
        Else
            CMBPER.Text = "Mtrs"
        End If

        TXTAMT.Clear()
        TXTDISCPER.Clear()
        TXTDISCAMT.Clear()
        TXTSPDISCPER.Clear()
        TXTSPDISCAMT.Clear()

        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()
        txtdescbarcode.Clear()

        If GRIDINVOICE.RowCount > 0 Then
            TXTSRNO.Text = Val(GRIDINVOICE.Rows(GRIDINVOICE.RowCount - 1).Cells(0).Value) + 1
            ' TXTSRNO.Text = Val(GRIDINVOICE.RowCount) + 1
        Else
            TXTSRNO.Text = 1
        End If
        TXTSRNO.Focus()

    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        'Try
        '    If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        '    If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

        '    If e.KeyCode = Keys.F1 Then
        '        Dim OBJREMARKS As New SelectRemarks
        '        OBJREMARKS.FRMSTRING = "NARRATION"
        '        OBJREMARKS.ShowDialog()
        '        If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Validated
        Try
            If CMBCHARGES.Text.Trim <> "" Then
                filltax()

                'GET ADDLESS DONE BY GULKIT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_ADDLESS,'ADD') AS ADDLESS ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("ADDLESS") = "LESS" Then
                        If Val(TXTCHGSPER.Text.Trim) = 0 Then TXTCHGSPER.Text = "-"
                        If Val(TXTCHGSAMT.Text.Trim) = 0 Then TXTCHGSAMT.Text = "-"
                        TXTCHGSPER.Select(TXTCHGSPER.Text.Length, 0)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            'If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBCODE, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' )")
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSAMT.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSAMT.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSAMT.Text.Trim) <> 0 Then
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(TXTCHGSAMT.Text.Trim, dDebit)
                If bValid Then
                    TXTCHGSAMT.Text = Convert.ToDecimal(Val(TXTCHGSAMT.Text))
                    ' everything is good
                    fillchgsgrid()
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    'e.Cancel = True
                    TXTCHGSAMT.Clear()
                    TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            Else
                If CMBCHARGES.Text.Trim = "" Then
                    MsgBox("Please Fill Charges Name ")
                    CMBCHARGES.Focus()
                    Exit Sub
                ElseIf Val(TXTCHGSPER.Text.Trim) = 0 And Val(TXTCHGSAMT.Text.Trim) = 0 Then
                    MsgBox("Amount can not be zero")
                    TXTCHGSAMT.Clear()
                    TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillchgsgrid()
        If GRIDCHGSDOUBLECLICK = False Then
            GRIDCHGS.Rows.Add(Val(TXTCHGSSRNO.Text.Trim), CMBCHARGES.Text.Trim, Val(TXTCHGSPER.Text.Trim), Val(TXTCHGSAMT.Text.Trim), Val(TXTTAXID.Text.Trim))
            getsrno(GRIDCHGS)
        ElseIf GRIDCHGSDOUBLECLICK = True Then
            GRIDCHGS.Item(ESRNO.Index, TEMPCHGSROW).Value = Val(TXTCHGSSRNO.Text.Trim)
            GRIDCHGS.Item(ECHARGES.Index, TEMPCHGSROW).Value = CMBCHARGES.Text.Trim
            GRIDCHGS.Item(EPER.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSPER.Text.Trim), "0.00")
            GRIDCHGS.Item(EAMT.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSAMT.Text.Trim), "0.00")
            GRIDCHGS.Item(ETAXID.Index, TEMPCHGSROW).Value = Format(Val(TXTTAXID.Text.Trim))

            GRIDCHGSDOUBLECLICK = False

        End If
        TOTAL()

        GRIDCHGS.FirstDisplayedScrollingRowIndex = GRIDCHGS.RowCount - 1

        TXTCHGSSRNO.Clear()
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTTAXID.Clear()
        If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False

        If GRIDCHGS.RowCount > 0 Then
            TXTCHGSSRNO.Text = Val(GRIDCHGS.Rows(GRIDCHGS.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCHGSSRNO.Text = 1
        End If
        TXTCHGSSRNO.Focus()
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
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

    Private Sub gridupload_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                GRIDUPLOADDOUBLECLICK = True
                TEMPUPLOADROW = e.RowIndex
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

    Sub fillgridscan()
        Try
            If GRIDUPLOADDOUBLECLICK = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf GRIDUPLOADDOUBLECLICK = True Then

                gridupload.Item(0, TEMPUPLOADROW).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
                gridupload.Item(3, TEMPUPLOADROW).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, TEMPUPLOADROW).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, TEMPUPLOADROW).Value = TXTFILENAME.Text.Trim

                GRIDUPLOADDOUBLECLICK = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpeg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTINVOICENO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
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

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        EDITCHGSROW()
    End Sub

    Private Sub GRIDCHGS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCHGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCHGSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCHGS.Rows.RemoveAt(GRIDCHGS.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDCHGS)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITCHGSROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITCHGSROW()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(GSRNO.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(GSRNO.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                TXTCHGSSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINVOICE_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDINVOICE.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub CMBTRANSCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillcity(CMBFROMCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOCITY.Enter
        Try
            If CMBTOCITY.Text.Trim = "" Then fillcity(CMBTOCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCRDAYS.KeyPress
        numdot(e, TXTCRDAYS, Me)
    End Sub

    Private Sub TXTCRDAYS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCRDAYS.Validated
        Try
            If INVOICEDATE.Text <> "__/__/____" Then
                If Val(TXTCRDAYS.Text.Trim) > 0 Then duedate.Value = Convert.ToDateTime(INVOICEDATE.Text).Date.AddDays(Val(TXTCRDAYS.Text.Trim))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBFROMCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBFROMCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTOCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBTOCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEM.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEM.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        'Try
        '    If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        '    If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

        '    If e.KeyCode = Keys.F1 Then
        '        Dim OBJQ As New SelectQuality
        '        OBJQ.FRMSTRING = "QUALITY"
        '        OBJQ.ShowDialog()
        '        If OBJQ.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQ.TEMPNAME
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub CMBDESIGN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJD As New selectdesign
                OBJD.ShowDialog()
                If OBJD.TEMPNAME <> "" Then CMBDESIGN.Text = OBJD.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBSHADE.KeyDown
        'Try
        '    If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        '    If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

        '    If e.KeyCode = Keys.F1 Then
        '        Dim OBJCOLOR As New SelectShade
        '        OBJCOLOR.ShowDialog()
        '        If OBJCOLOR.TEMPNAME <> "" Then CMBSHADE.Text = OBJCOLOR.TEMPNAME
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub TXTCHGSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSPER.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSPER, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSPER.Validating
        Try
            Dim dDebit As Decimal
            Dim bValid As Boolean = Decimal.TryParse(TXTCHGSPER.Text.Trim, dDebit)
            If bValid Then
                If Val(TXTCHGSPER.Text) = 0 Then TXTCHGSPER.Text = ""
                TXTCHGSPER.Text = Convert.ToDecimal(Val(TXTCHGSPER.Text))
                '' everything is good
                calchgs()
            ElseIf Val(TXTCHGSPER.Text.Trim) = 0 Then
                TXTCHGSAMT.ReadOnly = False
            Else
                MessageBox.Show("Invalid Number Entered")
                'e.Cancel = True
                TXTCHGSPER.Clear()
                TXTCHGSPER.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDINVOICE_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDINVOICE.CellValidating
        Dim colNum As Integer = GRIDINVOICE.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GRATE.Index, Gpcs.Index, GOTHERAMT.Index, GDISCPER.Index, GSPDISCPER.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDINVOICE.CurrentCell.Value = Nothing Then GRIDINVOICE.CurrentCell.Value = "0.00"
                    GRIDINVOICE.CurrentCell.Value = Convert.ToDecimal(GRIDINVOICE.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If
            Case GPER.Index
                TOTAL()
        End Select

        'If EDIT = False Then
        '    Dim TEMPITEM As String = ""
        '    For I As Integer = GRIDINVOICE.CurrentRow.Index + 1 To GRIDINVOICE.RowCount - 1
        '        If I = GRIDINVOICE.CurrentRow.Index + 1 Then TEMPITEM = GRIDINVOICE.Item(GITEMNAME.Index, I - 1).Value
        '        If GRIDINVOICE.Item(GITEMNAME.Index, I).Value = TEMPITEM Then
        '            If ClientName <> "CC" And ClientName <> "SANGHVI" And ClientName <> "PURPLE" Then GRIDINVOICE.Item(GRATE.Index, I).Value = GRIDINVOICE.Item(GRATE.Index, I - 1).EditedFormattedValue
        '            GRIDINVOICE.Item(GDISCPER.Index, I).Value = GRIDINVOICE.Item(GDISCPER.Index, I - 1).EditedFormattedValue
        '            GRIDINVOICE.Item(GSPDISCPER.Index, I).Value = GRIDINVOICE.Item(GSPDISCPER.Index, I - 1).EditedFormattedValue
        '        End If
        '    Next
        'End If
        TOTAL()

    End Sub

    Private Sub txtrefno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrefno.Validating
        Try
            If ClientName = "RPRAKASH" Then

                If txtrefno.Text <> "" Then
                    If EDIT = False Or (EDIT = True And TEMPREFNO <> txtrefno.Text.Trim) Then
                        Dim OBJCMN As New ClsCommon
                        Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_REFNO,'') AS REFNO", "", " INVOICEMASTER ", "  AND INVOICEMASTER.INVOICE_REFNO='" & txtrefno.Text.Trim & "' AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_LOCATIONID = " & Locationid & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                        If dttable.Rows.Count > 0 Then
                            MsgBox("Ref No Already Exist")
                            e.Cancel = True
                        End If
                    End If
                End If

            ElseIf ClientName = "MABHAY" Then

                If txtrefno.Text <> "" And cmbname.Text.Trim <> "" Then
                    If EDIT = False Or (EDIT = True And TEMPREFNO <> txtrefno.Text.Trim) Then
                        Dim OBJCMN As New ClsCommon
                        Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_REFNO,'') AS REFNO", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID AND INVOICE_CMPID = ACC_CMPID AND INVOICE_LOCATIONID = ACC_LOCATIONID AND INVOICE_YEARID = ACC_YEARID ", "  AND INVOICEMASTER.INVOICE_REFNO='" & txtrefno.Text.Trim & "' AND INVOICEMASTER.INVOICE_NO <> " & Val(TXTINVOICENO.Text.Trim) & " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_LOCATIONID = " & Locationid & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                        If dttable.Rows.Count > 0 Then
                            MsgBox("Ref No Already Exist")
                            e.Cancel = True
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTINVOICENO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINVOICENO.KeyPress
        numkeypress(e, TXTINVOICENO, Me)
    End Sub

    Private Sub TXTINVOICENO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTINVOICENO.Validating
        Try
            If (Val(TXTINVOICENO.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPINVOICENO <> Val(TXTINVOICENO.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_NO,0)  AS INVNO", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID AND INVOICE_CMPID = REGISTER_CMPID AND INVOICE_LOCATIONID = REGISTER_LOCATIONID AND INVOICE_YEARID = REGISTER_YEARID ", "  AND INVOICEMASTER.INVOICE_NO=" & TXTINVOICENO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_LOCATIONID = " & Locationid & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Invoice No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filltax()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            TXTTAXID.Text = 0
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search(" ISNULL(tax_tax, 0) as TAX, TAX_ID AS TAXID ", "", " TAXMASTER", " AND tax_name = '" & CMBCHARGES.Text & "'  AND tax_cmpid=" & CmpId & " AND tax_LOCATIONID = " & Locationid & " AND tax_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                TXTCHGSPER.Text = dt.Rows(0).Item("TAX")
                TXTTAXID.Text = Val(dt.Rows(0).Item("TAXID"))
                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True
                TXTCHGSPER.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = salereginitial & "-" & TEMPINVOICENO
            OBJRECPAY.SALEBILLINITIALS = salereginitial & "-" & TEMPINVOICENO
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        numdot(e, TXTAMT, Me)
    End Sub

    Private Sub CMBLEDGERCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLEDGERCODE.Enter
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable
        dt = objclscommon.search("acc_CODE", "", " ACCOUNTSMaster ", " and acc_cmpid = " & CmpId & " and acc_locationid = " & Locationid & " and acc_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "acc_CODE"
            CMBLEDGERCODE.DataSource = dt
            CMBLEDGERCODE.DisplayMember = "acc_CODE"
            CMBLEDGERCODE.Text = TEMPACCCODE
        End If
    End Sub

    Private Sub CMBLEDGERCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLEDGERCODE.Validated
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("acc_CMPNAME AS NAME", "", " ACCOUNTSMaster ", " AND ACC_CODE='" & CMBLEDGERCODE.Text.Trim & "' AND acc_cmpid = " & CmpId & " and acc_locationid = " & Locationid & " and acc_yearid = " & YearId)

            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "NAME"
                cmbname.DataSource = dt
                cmbname.DisplayMember = "NAME"
                CMBLEDGERCODE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLEDGERCODE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBLEDGERCODE.KeyDown
        'Try
        '    If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        '    If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

        '    If e.KeyCode = Keys.F1 Then
        '        Dim OBJLEDGER As New SelectLedger
        '        OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
        '        OBJLEDGER.ShowDialog()
        '        If OBJLEDGER.TEMPCODE <> "" Then CMBLEDGERCODE.Text = OBJLEDGER.TEMPCODE
        '        If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub txtrefno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrefno.KeyPress
        Try
            If ClientName = "RPRAKASH" Then
                numkeypress(e, txtrefno, Me)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Validated
        Try


            If CMBITEM.Text.Trim <> "" And Convert.ToDateTime(INVOICEDATE.Text).Date >= "01/07/2017" Then

                TXTHSNCODE.Clear()
                TXTCGSTPER.Clear()
                TXTCGSTAMT.Clear()
                TXTSGSTPER.Clear()
                TXTSGSTAMT.Clear()
                TXTIGSTPER.Clear()
                TXTIGSTAMT.Clear()

                TXTCGSTPER1.Clear()
                TXTCGSTAMT1.Clear()
                TXTSGSTPER1.Clear()
                TXTSGSTAMT1.Clear()
                TXTIGSTPER1.Clear()
                TXTIGSTAMT1.Clear()


                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & CMBITEM.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                        TXTIGSTPER.Text = 0
                        TXTIGSTPER1.Text = 0
                        TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                        TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        TXTCGSTPER1.Text = Val(DT.Rows(0).Item("CGSTPER"))
                        TXTSGSTPER1.Text = Val(DT.Rows(0).Item("SGSTPER"))
                    Else
                        TXTCGSTPER.Text = 0
                        TXTSGSTPER.Text = 0
                        TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        TXTCGSTPER1.Text = 0
                        TXTSGSTPER1.Text = 0
                        TXTIGSTPER1.Text = Val(DT.Rows(0).Item("IGSTPER"))
                    End If
                End If
                CALC()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                Dim WHERECLAUSE As String = ""
                If ClientName <> "YAMUNESH" Then WHERECLAUSE = WHERECLAUSE & " AND DONE = 0"

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "'" & WHERECLAUSE & "  AND YEARID =" & YearId)
                If DT.Rows.Count > 0 Then

                    If cmbname.Text.Trim = "" Then
                        MsgBox("Select Party Name", MsgBoxStyle.Critical)
                        Exit Sub
                    End If


                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    'FOR YAMUNESH MULTIPLE PCS MAY HAVE SAME BARCODE NOS
                    If ClientName <> "YAMUNESH" Then
                        For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
                            If ROW.Cells(GBARCODE.Index).Value = TXTBARCODE.Text.Trim Then GoTo LINE1
                        Next
                    End If

                    'GET WRATE AND SALERATE FROM DESIGN
                    Dim RATE As Double = 0
                    Dim DESC As String = ""
                    Dim DTRATE As New DataTable
                    If ClientName = "YAMUNESH" Then
                        DTRATE = OBJCMN.search("GRN_BALENO AS RATE", "", "GRN_DESC", " AND GRN_BARCODE = '" & TXTBARCODE.Text.Trim & "' AND GRN_YEARID = " & YearId)
                        DESC = DTRATE.Rows(0).Item("RATE").ToString
                        RATE = Val(DTRATE.Rows(0).Item("RATE").ToString.Substring(0, Len(DTRATE.Rows(0).Item("RATE")) - 2))
                        RATE = Format(Val(RATE) / 2, "0.00")
                    Else
                        DTRATE = OBJCMN.search("DESIGN_WRATE AS WRATE, DESIGN_SALERATE AS SALERATE", "", "DESIGNMASTER", " AND DESIGN_NO = '" & DT.Rows(0).Item("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
                        If DTRATE.Rows.Count > 0 Then
                            If CHKRETAIL.CheckState = CheckState.Checked Then RATE = Val(DTRATE.Rows(0).Item("SALERATE")) Else RATE = Val(DTRATE.Rows(0).Item("WRATE"))
                        End If
                    End If

                    'GET HSNCODE AND PERCENTAGES
                    Dim DTHSN As DataTable = OBJCMN.search("HSN_CODE AS HSNCODE, HSN_CGST AS CGST, HSN_SGST AS SGST, HSN_IGST AS IGST ", "", " HSNMASTER INNER JOIN ITEMMASTER ON ITEM_HSNCODEID = HSN_ID", " AND ITEM_NAME = '" & DT.Rows(0).Item("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)

                    'REVERSE CALC
                    'WE HAVE TAKEN IGST COZ WE NEED TO REVERSE WITH RESPECT TO TOTALGST PERCENT
                    If ClientName = "PURPLE" Then If CHKRETAIL.CheckState = CheckState.Checked Then RATE = Format((RATE / (Val(DTHSN.Rows(0).Item("IGST")) + 100)) * 100, "0.00")

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then
                            ROW.Cells(Gpcs.Index).Value = Val(ROW.Cells(Gpcs.Index).Value) + 1
                            TOTAL()
                            GoTo LINE1
                        End If
                    Next


                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                        TXTCGSTPER1.Text = Val(DTHSN.Rows(0).Item("CGST"))
                        TXTSGSTPER1.Text = Val(DTHSN.Rows(0).Item("SGST"))
                        TXTIGSTPER1.Text = 0
                        GRIDINVOICE.Rows.Add(GRIDINVOICE.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DTHSN.Rows(0).Item("HSNCODE"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DESC, "", 1, Format(Val(DT.Rows(0).Item("CUT")), "0.00"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), RATE, "Pcs", 0, 0, 0, 0, 0, 0, 0, Val(DTHSN.Rows(0).Item("CGST")), 0, Val(DTHSN.Rows(0).Item("SGST")), 0, 0, 0, 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0)
                    Else
                        TXTCGSTPER1.Text = 0
                        TXTSGSTPER1.Text = 0
                        TXTIGSTPER1.Text = Val(DTHSN.Rows(0).Item("IGST"))
                        GRIDINVOICE.Rows.Add(GRIDINVOICE.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DTHSN.Rows(0).Item("HSNCODE"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), DESC, "", 1, Format(Val(DT.Rows(0).Item("CUT")), "0.00"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), RATE, "Pcs", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Val(DTHSN.Rows(0).Item("IGST")), 0, 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"), 0)
                    End If
                    TOTAL()
LINE1:
                    TXTBARCODE.Clear()

                End If
            End If

            'OLDCODE
            '            If Len(TXTBARCODE.Text.Trim) > 7 Then

            '                'GET DATA FROM BARCODE
            '                Dim OBJCMN As New ClsCommon
            '                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
            '                If DT.Rows.Count > 0 Then
            '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
            '                    For Each ROW As DataGridViewRow In GRIDGDN.Rows
            '                        If ROW.Cells(GBARCODE.Index).Value = TXTBARCODE.Text.Trim Then GoTo LINE1
            '                    Next
            '                    GRIDGDN.Rows.Add(GRIDGDN.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), "", 1, Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
            '                    total()
            '                    GRIDGDN.FirstDisplayedScrollingRowIndex = GRIDGDN.RowCount - 1

            'LINE1:
            '                    TXTBARCODE.Clear()
            '                Else
            '                    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
            '                    GoTo LINE1
            '                    Exit Sub
            '                End If
            '            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                End If
                TXTBARCODE.Clear()
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKBARCODE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKBARCODE.CheckedChanged
        Try
            If CHKBARCODE.Checked = True Then
                LBLBARCODE.Visible = True
                TXTBARCODE.Visible = True
                CMDSELECTGDN.Enabled = False
                'TXTBARCODE.Focus()
            Else
                CMDSELECTGDN.Enabled = True
                LBLBARCODE.Visible = False
                TXTBARCODE.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InvoiceMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            CMBSCREENTYPE.Text = INVOICESCREENTYPE
            If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                TXTPSUMMNO.Visible = True
                LBLCHALLAN.Text = "Pack Summ No."
                CMDSELECTGDN.Text = "Select P.Summ"
            End If

            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                GDESCRIPTION.HeaderText = "Fold"
                LBLRD.Visible = True
                TXTTEMPRD.Visible = True
                TXTTEMPRATE.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub INVOICEDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles INVOICEDATE.GotFocus
        INVOICEDATE.SelectAll()
    End Sub

    Private Sub INVOICEDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles INVOICEDATE.Validating
        Try
            If INVOICEDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(INVOICEDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHALLANDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHALLANDATE.Validating
        Try
            If CHALLANDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CHALLANDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LRDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles LRDATE.GotFocus
        LRDATE.SelectAll()
    End Sub

    Private Sub BlendPanel1_Click(sender As Object, e As EventArgs) Handles BlendPanel1.Click

    End Sub

    Private Sub LRDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LRDATE.Validating
        Try
            If LRDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(LRDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKING.Enter
        Try
            If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS') AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If EDIT = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If cmbname.Text.Trim = "" Then Exit Sub

            If Val(LBLTOTALCGSTAMT.Text.Trim) = 0 And Val(TXTCGSTAMT1.Text.Trim) = 0 And Val(LBLTOTALSGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT1.Text.Trim) = 0 And Val(LBLTOTALIGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT1.Text.Trim) = 0 Then Exit Sub


            If txtlrno.Text.Trim <> "" AndAlso LRDATE.Text <> "__/__/____" Then
                If Convert.ToDateTime(LRDATE.Text).Date < Convert.ToDateTime(INVOICEDATE.Text).Date Then
                    MsgBox("LR Date cannot be Before Invoice Date", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            If CMBFROMCITY.Text.Trim = "" Then
                MsgBox("Enter From City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBTOCITY.Text.Trim = "" Then
                MsgBox("Enter to City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTIRNNO.Text.Trim <> "" Then
                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim TEMPCMPDISPATCHADD1 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim SHIPTOPINCODE As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim SHIPTOADD1 As String = ""
            Dim SHIPTOADD2 As String = ""
            Dim TRANSGSTIN As String = ""
            Dim KOTHARIPLACE As String = ""  'THIS VARIABLE IS USED TO FETCH RANGE COLUMN ONLY FOR KOTHARI, THEY WILL ENTER FULL SHIPTO ADDRESS THERE
            Dim DISPATCHFROM As String = ""
            Dim DISPATCHFROMGSTIN As String = ""
            Dim DISPATCHFROMPINCODE As String = ""
            Dim DISPATCHFROMSTATECODE As String = ""
            Dim DISPATCHFROMSTATENAME As String = ""
            Dim DISPATCHFROMKMS As Double = 0
            Dim DISPATCHFROMADD1 As String = ""
            Dim DISPATCHFROMADD2 As String = ""


            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_ADD1, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2, ISNULL(CMP_DISPATCHFROM, '') AS DISPATCHADD ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
            TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("DISPATCHADD")
            DISPATCHFROM = CmpName
            DISPATCHFROMGSTIN = CMPGSTIN
            DISPATCHFROMPINCODE = CMPPINCODE
            DISPATCHFROMSTATECODE = CMPSTATECODE
            DISPATCHFROMSTATENAME = CMPSTATENAME

            'PARTY GST DETAILS 

            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            If CMBPACKING.Text.Trim <> "" AndAlso cmbname.Text.Trim <> CMBPACKING.Text.Trim Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN,  ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_RANGE,'') AS KOTHARIPLACE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBPACKING.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                    MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                    SHIPTOPINCODE = DT.Rows(0).Item("PINCODE")
                    'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                    SHIPTOADD1 = DT.Rows(0).Item("ADD1")
                    SHIPTOADD2 = DT.Rows(0).Item("ADD2")
                    SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                    SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                    KOTHARIPLACE = DT.Rows(0).Item("KOTHARIPLACE")
                End If
            End If


            'BY GUKIT SIR THEN ITS COMMENT

            'DISPATCHFROM GST DETAILS AND KMS WILL BE FETCHED FROM TXTKMS
            'If CMBDISPATCHFROM.Text.Trim <> "" AndAlso cmbname.Text.Trim <> CMBDISPATCHFROM.Text.Trim Then
            '    DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBDISPATCHFROM.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Then
            '        MsgBox(" Dispatch From Details are not filled properly ", MsgBoxStyle.Critical)
            '        Exit Sub
            '    Else
            '        DISPATCHFROMGSTIN = DT.Rows(0).Item("GSTIN")
            '        DISPATCHFROMSTATENAME = DT.Rows(0).Item("STATENAME")
            '        DISPATCHFROMSTATECODE = DT.Rows(0).Item("STATECODE")
            '        DISPATCHFROMPINCODE = DT.Rows(0).Item("PINCODE")
            '        'DISPATCHFROMKMS = Val(TXTKMS.Text.Trim)
            '        TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("ADD1")
            '        TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
            '    End If
            'End If



            'TRANSPORT GSTING IS NOT MANDATORY
            'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            If cmbtrans.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
                'FOR LOCAL TRANSPORT THERE IS NO GSTIN
                'If TRANSGSTIN = "" Then
                '    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If
            End If



            'CHECKING COUNTER AND VALIDATE WHETHER EINVOICE WILL BE ALLOWED OR NOT, FOR EACH EINVOICE BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EINVOICE)
            If CMPEINVOICECOUNTER = 0 Then
                MsgBox("E-Invoice Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EINVOICECOUNTER
            Dim USEDEINVOICECOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EINVOICECOUNT", "", "EINVOICEENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER <= 0 Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EINVOICEEXPDATE Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER < Format((CMPEINVOICECOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEINVOICECOUNTER - USEDEINVOICECOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of E-Invoice Package", MsgBoxStyle.Critical)
            End If

            'CALL HERE FOR SAFETY
            TOTAL()

            'FOR GENERATING EINVOICE BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EINVOICEENTRY
            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If

            Dim j As String = ""
            Dim PRINTINITIALS As String = ""

            'GENERATING EINVOICE
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&AuthToken=" & TOKEN & "&user_name=TaxProEnvPON&QrCodeSize=250")
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&AuthToken=" & TOKEN & "&user_name=" & CMPEWBUSER & "&QrCodeSize=250")
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"



                j = "{"
                j = j & """Version"": ""1.1"","
                j = j & """TranDtls"": {"
                j = j & """TaxSch"":""GST"","
                j = j & """SupTyp"":""B2B"","
                j = j & """RegRev"":""N"","
                j = j & """IgstOnIntra"":""N""},"



                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
                Dim DTINI As DataTable = OBJCMN.search("INVOICE_PRINTINITIALS AS PRINTINITIALS", "", "INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID", " AND INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""INV"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & INVOICEDATE.Text & """" & "},"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                j = j & """SellerDtls"": {"
                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
                j = j & """LglNm"":""" & CmpName & """" & ","
                j = j & """TrdNm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMBFROMCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                If PARTYADD1 = "" Then PARTYADD1 = PARTYSTATENAME
                If PARTYADD2 = "" Then PARTYADD2 = PARTYSTATENAME

                j = j & """BuyerDtls"": {"
                j = j & """Gstin"":""" & PARTYGSTIN & """" & ","
                j = j & """LglNm"":""" & cmbname.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & cmbname.Text.Trim & """" & ","
                j = j & """Pos"":""" & PARTYSTATECODE & """" & ","
                j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & PARTYADD2.Replace(vbCrLf, " ") & """" & ","
                If ClientName = "KOTHARI" Then j = j & """Loc"":""" & KOTHARIPLACE & """" & "," Else j = j & """Loc"":""" & CMBTOCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & PARTYPINCODE & "" & ","
                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


                j = j & """DispDtls"": {"
                j = j & """Nm"":""" & DISPATCHFROM & """" & ","
                j = j & """Addr1"":""" & TEMPCMPDISPATCHADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMBFROMCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & DISPATCHFROMPINCODE & "" & ","
                j = j & """Stcd"":""" & DISPATCHFROMSTATECODE & """" & "},"

                j = j & """ShipDtls"": {"
                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBPACKING.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBPACKING.Text.Trim & """" & ","
                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
                j = j & """Loc"":""" & CMBTOCITY.Text.Trim & """" & ","
                If SHIPTOPINCODE = "" Then j = j & """Pin"":" & PARTYPINCODE & "" & "," Else j = j & """Pin"":" & SHIPTOPINCODE & "" & ","
                j = j & """Stcd"":""" & SHIPTOSTATECODE & """" & "},"


                j = j & """ItemList"":[{"



                Dim TEMPLINEDISC As Double = 0
                Dim TEMPLINETAXABLEAMT As Double = 0
                Dim TEMPLINECGSTAMT As Double = 0
                Dim TEMPLINESGSTAMT As Double = 0
                Dim TEMPLINEIGSTAMT As Double = 0
                Dim TEMPLINEGRIDTOTALAMT As Double = 0
                Dim TEMPLINECHARGES As Double = 0
                Dim TEMPRATE As Double = 0
                If Val(TXTCHARGES.Text.Trim) < 0 Then
                    'TEMPLINEDISC = Format(Val(TXTCHARGES.Text.Trim) / Val(lbltotalmtrs.Text.Trim), "0.0000")
                    TEMPLINEDISC = Val(TXTCHARGES.Text.Trim) / Val(LBLTOTALMTRSWITHRATE.Text.Trim)
                Else
                    'If GRIDINVOICE.Rows(0).Cells(GPER.Index).Value = "Pcs" Then TEMPRATE = Format(Val(TXTCHARGES.Text.Trim) / Val(lbltotalpcs.Text.Trim), "0.0000") Else TEMPRATE = Format(Val(TXTCHARGES.Text.Trim) / Val(lbltotalmtrs.Text.Trim), "0.0000")
                    If GRIDINVOICE.Rows(0).Cells(GPER.Index).Value = "Pcs" Then TEMPRATE = Val(TXTCHARGES.Text.Trim) / Val(lbltotalpcs.Text.Trim) Else TEMPRATE = Val(TXTCHARGES.Text.Trim) / Val(LBLTOTALMTRSWITHRATE.Text.Trim)
                End If


                Dim TEMPTOTALAMT As Double = 0
                Dim TEMPTOTALDISC As Double = 0
                Dim TEMPTOTALTAXABLEAMT As Double = 0
                Dim TEMPTOTALCGSTAMT As Double = 0
                Dim TEMPTOTALSGSTAMT As Double = 0
                Dim TEMPTOTALIGSTAMT As Double = 0
                Dim TEMPGTOTALAMT As Double = 0


                'WE NEED TO FETCH ALL ITEMS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT ISNULL(INVOICEMASTER_DESC.INVOICE_SRNO,0) AS SRNO, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGST, ISNULL(HSN_SGST,0) AS SGST, ISNULL(HSN_IGST,0) AS IGST, ISNULL(INVOICEMASTER_DESC.INVOICE_PCS,0) AS PCS, ISNULL(INVOICEMASTER_DESC.INVOICE_MTRS,0) AS MTRS, ISNULL(INVOICEMASTER_DESC.INVOICE_PER,'Mtrs') AS PER, ISNULL(INVOICEMASTER_DESC.INVOICE_RATE,0) AS RATE, ISNULL(INVOICEMASTER_DESC.INVOICE_AMOUNT,0) AS TOTALAMT, 0 AS LINEDISC, 0 AS LINETAXABLEAMT, 0 AS LINECGSTAMT, 0 AS LINESGSTAMT, 0 AS LINEIGSTAMT, 0 AS LINEGRIDDTOTAL, ISNULL(HSN_TYPE,'Goods') HSNTYPE FROM INVOICEMASTER INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN ITEMMASTER ON item_id = INVOICE_ITEMID INNER JOIN HSNMASTER ON HSN_ID = INVOICE_HSNCODEID INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTER_ID WHERE INVOICEMASTER.INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' and INVOICEMASTER.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER_DESC.INVOICE_SRNO", "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows

                    If Val(DTROW("RATE")) > 0 Then
                        TEMPLINECHARGES = Format(Val(TEMPLINEDISC) * Val(DTROW("MTRS")), "0.00")
                        TEMPLINETAXABLEAMT = Format(Val(DTROW("TOTALAMT")) + Val(TEMPLINECHARGES), "0.00")
                        TEMPLINECGSTAMT = Format(Val(TXTCGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINESGSTAMT = Format(Val(TXTSGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINEIGSTAMT = Format(Val(TXTIGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")
                    Else
                        TEMPLINECHARGES = 0
                        TEMPLINETAXABLEAMT = 0
                        TEMPLINECGSTAMT = 0
                        TEMPLINESGSTAMT = 0
                        TEMPLINEIGSTAMT = 0
                        TEMPLINEGRIDTOTALAMT = 0
                    End If


                    If CURRROW > 0 Then j = j & ", {"
                    j = j & """SlNo"": """ & DTROW("SRNO") & """" & ","
                    j = j & """PrdDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    If DTROW("HSNTYPE") = "Goods" Then j = j & """IsServc"":""" & "N" & """" & "," Else j = j & """IsServc"":""" & "Y" & """" & ","
                    j = j & """HsnCd"":""" & DTROW("HSNCODE") & """" & ","
                    j = j & """Barcde"":""REC9999"","
                    If DTROW("PER") = "Pcs" Then j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                    j = j & """FreeQty"":" & "0" & "" & ","
                    j = j & """Unit"":""" & "MTR" & """" & ","


                    Dim DTHSN As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER,  0 AS EXPCGSTPER, 0 AS EXPSGSTPER, 0 AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & DTROW("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId)


                    If Val(TXTCHARGES.Text.Trim) <= 0 Then

                        j = j & """UnitPrice"":" & Val(DTROW("RATE")) & "" & ","
                        j = j & """TotAmt"":" & Format(Val(DTROW("TOTALAMT")), "0.00") & "" & ","


                        If Val(DTROW("RATE")) > 0 Then

                            If INVOICESCREENTYPE = "LINE GST" Then
                                If Val(DTROW("LINEDISC")) < 0 Then j = j & """Discount"":" & Val(DTROW("LINEDISC")) * -1 & "" & "," Else j = j & """Discount"":" & Val(DTROW("LINEDISC")) & "" & ","
                            Else
                                If Val(TEMPLINECHARGES) < 0 Then j = j & """Discount"":" & Val(TEMPLINECHARGES) * -1 & "" & "," Else j = j & """Discount"":" & Val(TEMPLINECHARGES) & "" & ","
                            End If
                            j = j & """PreTaxVal"":" & "1" & "" & ","
                            If INVOICESCREENTYPE = "LINE GST" Then j = j & """AssAmt"":" & Val(DTROW("LINETAXABLEAMT")) & "" & "," Else j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                            'If CHKEXPORTGST.CheckState = CheckState.Unchecked Then j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & "," Else j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("EXPIGSTPER")) & "" & ","
                            j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","

                            If INVOICESCREENTYPE = "LINE GST" Then
                                j = j & """IgstAmt"":" & Val(DTROW("LINEIGSTAMT")) & "" & ","
                                j = j & """CgstAmt"":" & Val(DTROW("LINECGSTAMT")) & "" & ","
                                j = j & """SgstAmt"":" & Val(DTROW("LINESGSTAMT")) & "" & ","
                            Else
                                j = j & """IgstAmt"":" & Val(TEMPLINEIGSTAMT) & "" & ","
                                j = j & """CgstAmt"":" & Val(TEMPLINECGSTAMT) & "" & ","
                                j = j & """SgstAmt"":" & Val(TEMPLINESGSTAMT) & "" & ","
                            End If

                        Else

                            j = j & """Discount"":0,"
                            j = j & """PreTaxVal"":" & "1" & "" & ","
                            j = j & """AssAmt"":0,"
                            j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","
                            j = j & """IgstAmt"":" & Val(TEMPLINEIGSTAMT) & "" & ","
                            j = j & """CgstAmt"":" & Val(TEMPLINECGSTAMT) & "" & ","
                            j = j & """SgstAmt"":" & Val(TEMPLINESGSTAMT) & "" & ","

                        End If



                        j = j & """CesRt"":" & "0" & "" & ","
                        j = j & """CesAmt"":" & "0" & "" & ","
                        j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """StateCesRt"":" & "0" & "" & ","
                        j = j & """StateCesAmt"":" & "0" & "" & ","
                        j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """OthChrg"":" & "0" & "" & ","

                        If INVOICESCREENTYPE = "LINE GST" Then j = j & """TotItemVal"":" & Val(DTROW("LINEGRIDTOTAL")) & "" & "," Else j = j & """TotItemVal"":" & Val(TEMPLINEGRIDTOTALAMT) & "" & ","
                        j = j & """OrdLineRef"":"" "","
                        j = j & """OrgCntry"":""IN"","
                        j = j & """PrdSlNo"":""123"","

                        j = j & """BchDtls"": {"
                        j = j & """Nm"":""123"","
                        j = j & """Expdt"":""" & INVOICEDATE.Text & """" & ","
                        j = j & """wrDt"":""" & INVOICEDATE.Text & """" & "},"

                        j = j & """AttribDtls"": [{"
                        j = j & """Nm"":""" & DTROW("ITEMNAME") & """" & ","
                        j = j & """Val"":""" & Val(TEMPLINEGRIDTOTALAMT) & """" & "}]"

                    Else

                        j = j & """UnitPrice"":" & Format(Val(DTROW("RATE")) + TEMPRATE, "0.00") & "" & ","

                        If Val(DTROW("RATE")) > 0 Then
                            If DTROW("PER") = "Pcs" Then TEMPLINETAXABLEAMT = Format(Val(Val(DTROW("RATE")) + TEMPRATE) * Val(DTROW("PCS")), "0.00") Else TEMPLINETAXABLEAMT = Format(Val(Val(DTROW("RATE")) + TEMPRATE) * Val(DTROW("MTRS")), "0.00")
                            TEMPLINECGSTAMT = Format(Val(TXTCGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                            TEMPLINESGSTAMT = Format(Val(TXTSGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                            TEMPLINEIGSTAMT = Format(Val(TXTIGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                            TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")
                        Else
                            TEMPLINETAXABLEAMT = 0
                            TEMPLINECGSTAMT = 0
                            TEMPLINESGSTAMT = 0
                            TEMPLINEIGSTAMT = 0
                            TEMPLINEGRIDTOTALAMT = 0
                        End If


                        j = j & """TotAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """Discount"":" & "0" & "" & ","
                        j = j & """PreTaxVal"":" & "1" & "" & ","
                        j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        'If CHKEXPORTGST.CheckState = CheckState.Unchecked Then j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & "," Else j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("EXPIGSTPER")) & "" & ","
                        j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","
                        j = j & """IgstAmt"":" & Val(TEMPLINEIGSTAMT) & "" & ","
                        j = j & """CgstAmt"":" & Val(TEMPLINECGSTAMT) & "" & ","
                        j = j & """SgstAmt"":" & Val(TEMPLINESGSTAMT) & "" & ","
                        j = j & """CesRt"":" & "0" & "" & ","
                        j = j & """CesAmt"":" & "0" & "" & ","
                        j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """StateCesRt"":" & "0" & "" & ","
                        j = j & """StateCesAmt"":" & "0" & "" & ","
                        j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """OthChrg"":" & "0" & "" & ","
                        j = j & """TotItemVal"":" & Val(TEMPLINEGRIDTOTALAMT) & "" & ","
                        j = j & """OrdLineRef"":"" "","
                        j = j & """OrgCntry"":""IN"","
                        j = j & """PrdSlNo"":""123"","

                        j = j & """BchDtls"": {"
                        j = j & """Nm"":""123"","
                        j = j & """Expdt"":""" & INVOICEDATE.Text & """" & ","
                        j = j & """wrDt"":""" & INVOICEDATE.Text & """" & "},"

                        j = j & """AttribDtls"": [{"
                        j = j & """Nm"":""" & DTROW("ITEMNAME") & """" & ","
                        j = j & """Val"":""" & Val(TEMPLINEGRIDTOTALAMT) & """" & "}]"
                    End If



                    j = j & " }"
                    CURRROW += 1


                    'THESE VARIABLES ARE JUST FOR TESTING PURPOSE
                    TEMPTOTALAMT += Val(DTROW("TOTALAMT"))
                    TEMPTOTALDISC += Val(TEMPLINECHARGES)
                    TEMPTOTALTAXABLEAMT += Val(TEMPLINETAXABLEAMT)
                    TEMPTOTALCGSTAMT += Val(TEMPLINECGSTAMT)
                    TEMPTOTALSGSTAMT += Val(TEMPLINESGSTAMT)
                    TEMPTOTALIGSTAMT += Val(TEMPLINEIGSTAMT)
                    TEMPGTOTALAMT += Val(TEMPLINEGRIDTOTALAMT)


                Next

                j = j & " ],"



                j = j & """ValDtls"": {"
                If INVOICESCREENTYPE = "TOTAL GST" Then
                    j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                    j = j & """CgstVal"":" & Val(TXTCGSTAMT1.Text.Trim) & "" & ","
                    j = j & """SgstVal"":" & Val(TXTSGSTAMT1.Text.Trim) & "" & ","
                    j = j & """IgstVal"":" & Val(TXTIGSTAMT1.Text.Trim) & "" & ","
                Else
                    j = j & """AssVal"":" & Val(LBLTOTALTAXABLEAMT.Text.Trim) & "" & ","
                    j = j & """CgstVal"":" & Val(LBLTOTALCGSTAMT.Text.Trim) & "" & ","
                    j = j & """SgstVal"":" & Val(LBLTOTALSGSTAMT.Text.Trim) & "" & ","
                    j = j & """IgstVal"":" & Val(LBLTOTALIGSTAMT.Text.Trim) & "" & ","
                End If

                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                'j = j & """OthChrg"":" & Val(TXTTCSAMT.Text.Trim) & "" & ","
                j = j & """OthChrg"":" & "0" & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
                j = j & """TotInvValFc"":" & "0" & "" & "},"


                j = j & """PayDtls"": {"
                j = j & """Nm"":"" "","
                j = j & """Accdet"":"" "","
                j = j & """Mode"":""Credit"","
                j = j & """Fininsbr"":"" "","
                j = j & """Payterm"":"" "","
                j = j & """Payinstr"":"" "","
                j = j & """Crtrn"":"" "","
                j = j & """Dirdr"":"" "","
                j = j & """Crday"":" & Val(TXTCRDAYS.Text.Trim) & "" & ","
                j = j & """Paidamt"":" & "0" & "" & ","
                j = j & """Paymtdue"":" & Val(txtgrandtotal.Text.Trim) & "" & "},"


                j = j & """RefDtls"": {"
                j = j & """InvRm"":""TEST"","
                j = j & """DocPerdDtls"": {"
                j = j & """InvStDt"":""" & INVOICEDATE.Text & """" & ","
                j = j & """InvEndDt"":""" & INVOICEDATE.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & INVOICEDATE.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & INVOICEDATE.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & INVOICEDATE.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"

                j = j & """TransDocNo"":""" & txtlrno.Text.Trim & """" & ","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & INVOICEDATE.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"



                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
                'OR ELSE IT WILL GIVE ERROR
                If DISPATCHFROMPINCODE = PARTYPINCODE Then PARTYKMS = 10

                If TXTVEHICLENO.Text.Trim <> "" Then
                    j = j & ","
                    j = j & """EwbDtls"": {"
                    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
                    j = j & """TransName"":""" & cmbtrans.Text.Trim & """" & ","
                    j = j & """Distance"":""" & PARTYKMS & """" & ","
                    If LRDATE.Text <> "__/__/____" Then j = j & """TransDocDt"":""" & LRDATE.Text & """" & "," Else j = j & """TransDocDt"":"""","
                    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                    j = j & """VehType"":""" & "R" & """" & ","
                    j = j & """TransMode"":""1""" & "}"
                End If

                j = j & "}"


                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()



            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EINVOICEENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                RESPONSE = ex.Response
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                GoTo ERRORMESSAGE
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then
                TEMPSTATUS = "SUCCESS"
                MsgBox("E-Invoice Generated Successfully ")

            Else

ERRORMESSAGE:
                TEMPSTATUS = "FAILED"

                Dim ERRORMSG As String = ""
                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ErrorMessage") + Len("ErrorMessage") + 5
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS) - 2
                ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                MsgBox("Error While Generating E-Invoice, " & REQUESTEDTEXT)

                Exit Sub
            End If


            Dim IRNNO As String = ""
            Dim ACKNO As String = ""
            Dim ADATE As String = ""


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackno") + Len("ACKNO") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ACKNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTACKNO.Text = ACKNO


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackdt") + Len("ACKDT") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ADATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            ACKDATE.Value = ADATE

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("irn") + Len("IRN") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTIRNNO.Text = IRNNO


            'WE NEED TO UPDATE THIS IRNNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_IRNNO = '" & TXTIRNNO.Text.Trim & "', INVOICE_ACKNO = '" & TXTACKNO.Text.Trim & "', INVOICE_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ADD DATA IN EINVOICEENTRY FOR QRCODE
            If TEMPSTATUS = "SUCCESS" Then

                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", j, RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)

                'GET REGINITIALS AS SAVE WITH IT
                Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsInvoiceMaster
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
                    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            End If




            'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("QrCodeImage\", 0) + Len("QrCodeImage\") + 5
            'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS)
            ''Dim QRSTREAM As New MemoryStream
            ''Dim bmp As New Bitmap(QRSTREAM)
            ''bmp.Save(QRSTREAM, Drawing.Imaging.ImageFormat.Bmp)
            ''QRSTREAM.Position = STARTPOS
            ''Dim data As Byte()
            ''QRSTREAM.Read(data, STARTPOS, STARTPOS - ENDPOS)

            'Dim bytes() As Byte
            'Dim ImageInStringFormat As String = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            'Dim MS As System.IO.MemoryStream
            'Dim NewImage As Bitmap

            'Dim nbyte() As Byte = System.Text.Encoding.UTF8.GetBytes(ImageInStringFormat)
            'Dim BASE64STRING As String = Convert.ToBase64String(nbyte)

            'bytes = Convert.FromBase64String(BASE64STRING)
            'NewImage = BytesToBitmap(bytes)
            'MS = New System.IO.MemoryStream(bytes)
            'MS.Write(bytes, 0, bytes.Length)
            'NewImage.Save(MS, Drawing.Imaging.ImageFormat.Bmp)    ' = System.Drawing.Image.FromStream(MS, True)
            'NewImage.Save("d:\qrcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            'IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            ''ADD data IN EINVOICEENTRY
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTINVOICENO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = txtimgpath.Text.Trim
            PBQRCODE.Load(txtimgpath.Text.Trim)
        End If
    End Sub

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If EDIT = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

                'FIRST GETTOKEN AND THEN GET QRCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
                Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim REQUEST As WebRequest
                Dim RESPONSE As WebResponse
                REQUEST = WebRequest.CreateDefault(URL)

                REQUEST.Method = "GET"
                Try
                    RESPONSE = REQUEST.GetResponse()
                Catch ex As WebException
                    RESPONSE = ex.Response
                End Try
                Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
                Dim REQUESTEDTEXT As String = READER.ReadToEnd()

                'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
                Dim STARTPOS As Integer = 0
                Dim TEMPSTATUS As String = ""
                Dim TOKEN As String = ""
                Dim ENDPOS As Integer = 0

                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
                TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
                If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
                TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
                'IF STATUS IS FAILED THEN ERROR MESSAGE
                If TEMPSTATUS = "FAILED" Then
                    MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                    Exit Sub
                End If


                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)



                'bitmap1.Save(Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                'PBQRCODE.ImageLocation = Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                'PBQRCODE.Refresh()


                'GET REGINITIALS AS SAVE WITH IT
                Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()



                'If PBQRCODE.Image IsNot Nothing Then
                '    Dim OBJINVOICE As New ClsInvoiceMaster
                '    Dim MS As New IO.MemoryStream
                '    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                '    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
                '    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                '    OBJINVOICE.alParaval.Add(MS.ToArray)
                '    OBJINVOICE.alParaval.Add(YearId)
                '    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                'End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                cmdOK_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKING.Validating
        Try
            'If CMBPACKING.Text.Trim <> "" Then namevalidate(CMBPACKING, CMBCODE, e, Me, txtDeliveryadd, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")
            If CMBPACKING.Text.Trim <> "" Then namevalidate(CMBPACKING, e, Me, txtDeliveryadd, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOTHERAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOTHERAMT.KeyPress
        AMOUNTNUMDOTKYEPRESS(e, sender, Me)
    End Sub

    Private Sub TXTOTHERAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTOTHERAMT.Validated, TXTDISCPER.Validated, TXTDISCAMT.Validated, TXTSPDISCPER.Validated, TXTSPDISCAMT.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDISCAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCAMT.KeyPress, TXTDISCPER.KeyPress, TXTSPDISCAMT.KeyPress, TXTSPDISCPER.KeyPress
        Try
            numdotkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDISCPER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDISCPER.Validating, TXTSPDISCPER.Validating
        Try
            If Val(TXTDISCPER.Text.Trim) > 100 Or Val(TXTSPDISCPER.Text.Trim) > 100 Then
                MsgBox("Percent Cannot be greater then 100", MsgBoxStyle.Critical)
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALENOFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALENOFROM.KeyPress
        Try
            If ClientName = "KANVASU" Then numdotkeypress(e, sender, Me) Else numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBALENOTO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBALENOTO.KeyPress
        Try
            numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HIDEVIEW()
        Try
            If CMBSCREENTYPE.Text = "LINE GST" Then
                TXTDISCPER.Visible = True
                GDISCPER.Visible = True
                TXTDISCAMT.Visible = True
                GDISCAMT.Visible = True
                LBLTOTALDISCAMT.Visible = True

                TXTSPDISCPER.Visible = True
                GSPDISCPER.Visible = True
                TXTSPDISCAMT.Visible = True
                GSPDISCAMT.Visible = True
                LBLTOTALSPDISCAMT.Visible = True

                TXTOTHERAMT.Visible = True
                GOTHERAMT.Visible = True
                LBLTOTALOTHERAMT.Visible = True

                TXTTAXABLEAMT.Visible = True
                GTAXABLEAMT.Visible = True
                LBLTOTALTAXABLEAMT.Visible = True

                TXTCGSTPER.Visible = True
                GCGSTPER.Visible = True
                TXTCGSTAMT.Visible = True
                GCGSTAMT.Visible = True
                LBLTOTALCGSTAMT.Visible = True

                TXTSGSTPER.Visible = True
                GSGSTPER.Visible = True
                TXTSGSTAMT.Visible = True
                GSGSTAMT.Visible = True
                LBLTOTALSGSTAMT.Visible = True

                TXTIGSTPER.Visible = True
                GIGSTPER.Visible = True
                TXTIGSTAMT.Visible = True
                GIGSTAMT.Visible = True
                LBLTOTALIGSTAMT.Visible = True

                TXTGRIDTOTAL.Visible = True
                GGRIDTOTAL.Visible = True

                GRIDINVOICE.Width = 2094


                LBLCGST.Visible = False
                TXTCGSTPER1.Visible = False
                TXTCGSTAMT1.Visible = False
                LBLSGST.Visible = False
                TXTSGSTPER1.Visible = False
                TXTSGSTAMT1.Visible = False
                LBLIGST.Visible = False
                TXTIGSTPER1.Visible = False
                TXTIGSTAMT1.Visible = False

                TXTAMT.TabStop = False
            Else

                TXTDISCPER.Visible = False
                GDISCPER.Visible = False
                TXTDISCAMT.Visible = False
                GDISCAMT.Visible = False
                LBLTOTALDISCAMT.Visible = False

                TXTSPDISCPER.Visible = False
                GSPDISCPER.Visible = False
                TXTSPDISCAMT.Visible = False
                GSPDISCAMT.Visible = False
                LBLTOTALSPDISCAMT.Visible = False

                TXTOTHERAMT.Visible = False
                GOTHERAMT.Visible = False
                LBLTOTALOTHERAMT.Visible = False

                TXTTAXABLEAMT.Visible = False
                GTAXABLEAMT.Visible = False
                LBLTOTALTAXABLEAMT.Visible = False

                TXTCGSTPER.Visible = False
                GCGSTPER.Visible = False
                TXTCGSTAMT.Visible = False
                GCGSTAMT.Visible = False
                LBLTOTALCGSTAMT.Visible = False

                TXTSGSTPER.Visible = False
                GSGSTPER.Visible = False
                TXTSGSTAMT.Visible = False
                GSGSTAMT.Visible = False
                LBLTOTALSGSTAMT.Visible = False

                TXTIGSTPER.Visible = False
                GIGSTPER.Visible = False
                TXTIGSTAMT.Visible = False
                GIGSTAMT.Visible = False
                LBLTOTALIGSTAMT.Visible = False

                TXTGRIDTOTAL.Visible = False
                GGRIDTOTAL.Visible = False

                GRIDINVOICE.Width = 1230


                LBLCGST.Visible = True
                TXTCGSTPER1.Visible = True
                TXTCGSTAMT1.Visible = True
                LBLSGST.Visible = True
                TXTSGSTPER1.Visible = True
                TXTSGSTAMT1.Visible = True
                LBLIGST.Visible = True
                TXTIGSTPER1.Visible = True
                TXTIGSTAMT1.Visible = True

                TXTAMT.TabStop = True

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSCREENTYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSCREENTYPE.Validated
        Try
            HIDEVIEW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDAUTOPOST.Click
        Try
            'GET INVOICENOS FROM INVOICEMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("MAX(INVOICE_NO) AS INVOICENO", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId)
            For I As Integer = 1 To Val(DT.Rows(0).Item("INVOICENO"))
                GRIDINVOICE.RowCount = 0
                TEMPINVOICENO = Val(I)
                TEMPREGNAME = cmbregister.Text.Trim
                EDIT = True
                INVOICEMASTER_Load(sender, e)
                If GRIDINVOICE.RowCount = 0 Then GoTo NEXTLINE
                cmdOK_Click(sender, e)
NEXTLINE:
                clear()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated
        Try
            If Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTCUT.Text.Trim) * Val(TXTPCS.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESSTYPE_Enter(sender As Object, e As EventArgs) Handles CMBPROCESSTYPE.Enter
        Try
            If CMBPROCESSTYPE.Text.Trim <> "" Then FILLPROCESSTYPE(CMBPROCESSTYPE, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESSTYPE_Validating(sender As Object, e As CancelEventArgs) Handles CMBPROCESSTYPE.Validating
        Try
            If CMBPROCESSTYPE.Text.Trim <> "" Then PROCESSTYPEvalidate(CMBPROCESSTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class