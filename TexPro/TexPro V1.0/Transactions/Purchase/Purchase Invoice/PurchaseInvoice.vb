
Imports BL
Imports System.Windows.Forms

Public Class PurchaseMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDCHGSDOUBLECLICK, GRIDEXTRADBLCLICK, GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPCHGSROW, TEMPEXTRAROW, TEMPUPLOADROW, PURREGID As Integer
    Dim TEMPPARTYBILLNO As String
    Public EDIT As Boolean
    Public TEMPBILLNO, TEMPREGNAME As String
    Dim PURREGABBR, PURREGINITIAL As String
    Public Shared selectPURtable As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        CMBSCREENTYPE.Enabled = True
        CMBSCREENTYPE.Text = "LINE GST"
        HIDEVIEW()

        CMBSERVICETYPE.Enabled = True
        If ALLOWMANUALINVNO = True Then
            TXTBILLNO.ReadOnly = False
            TXTBILLNO.BackColor = Color.LemonChiffon
        Else
            TXTBILLNO.ReadOnly = True
            TXTBILLNO.BackColor = Color.Linen
        End If

        TXTSACCODE.Clear()
        CMBSACDESC.Enabled = True

        cmbname.Text = ""
        cmbname.Enabled = True
        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()
        TXTPARTYBILLNO.Clear()

        tstxtbillno.Clear()
        BILLDATE.Text = Mydate
        DTPARTYBILLDATE.Text = Mydate

        CMBAGENT.Text = ""
        CMBTRANSPORT.Text = ""
        TXTCRDAYS.Clear()
        duedate.Value = Mydate

        CHALLANDATE.Value = Mydate
        txtrefno.Clear()
        txtlrno.Clear()
        lrdate.Value = Mydate
        TXTVEHICLENO.Clear()
        CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""
        txtadd.Clear()
        txtremarks.Clear()
        CHKBILLCHECKED.Checked = False
        CHKBILLDISPUTE.Checked = False

        CHKTDS.CheckState = CheckState.Unchecked
        CHKRCM.CheckState = CheckState.Unchecked
        CHKMANUAL.CheckState = CheckState.Unchecked

        For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
            Dim DTR As DataRowView = CHKFORMBOX.Items(I)
            CHKFORMBOX.SetItemCheckState(I, CheckState.Unchecked)
        Next
        CHKFORMBOX.SetItemChecked(CHKFORMBOX.FindStringExact("GST"), True)
        EP.Clear()
        PBDN.Visible = False
        PBPAID.Visible = False
        PBTDS.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        CMDSHOWDETAILS.Visible = False
        cmdgrn.Enabled = True

        TXTSRNO.Text = 1
        CMBITEM.Text = ""
        TXTHSNCODE.Clear()
        
        TXTQTY.Clear()
        CMBQTYUNIT.Text = ""
        TXTMTRS.Clear()
        TXTRATE.Clear()
        CMBPER.Text = "Mtrs"
        TXTAMT.Clear()
        TXTDISCPER.Clear()
        TXTDISCAMT.Clear()
        TXTSPDISCAMT.Clear()
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

        GRIDBILL.RowCount = 0

        TXTCHGSSRNO.Text = 1
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        txtnett.Clear()
        TXTTDSAMT.Clear()
        TXTBAL.Clear()
        GRIDCHGS.RowCount = 0


        getmax_BILL_no()

        GRIDDOUBLECLICK = False
        GRIDCHGSDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False


        chkexcise.Checked = True
        TXTEXCISE.ReadOnly = True
        TXTEDUCESS.ReadOnly = True
        TXTHSECESS.ReadOnly = True
        'getexcise()
        TXTAMTPAID.Text = 0.0
        TXTEXTRAAMT.Text = 0.0
        TXTRETURN.Text = 0.0
        TXTBAL.Text = 0.0
        txtbillamt.Text = 0.0
        txtdisper.Text = 0.0
        txtdisamt.Text = 0.0
        txtpfper.Text = 0.0
        txtpfamt.Text = 0.0
        txttestchgs.Text = 0.0
        txtnett.Text = 0.0

        TXTEXCISE.Text = 0.0
        txtexciseAMT.Text = 0.0

        TXTEDUCESS.Text = 0.0
        txteducessAMT.Text = 0.0

        TXTHSECESS.Text = 0.0
        txthsecessAMT.Text = 0.0

        txtsubtotal.Text = 0.0
        chkexcise.CheckState = CheckState.Unchecked
        cmbtax.Text = ""
        txttax.Text = 0.0

        cmbaddtax.Text = ""
        txtaddtax.Text = 0.0

        txtfrper.Text = 0.0
        txtfreight.Text = 0.0

        cmboctroi.Text = ""
        txtoctroi.Text = 0.0

        txtinspchgs.Text = 0.0

        txtremarks.Clear()
        txtinwordedu.Clear()
        txtinwordexcise.Clear()
        txtinwordhse.Clear()
        txtinwords.Clear()



        txtbillamt.Text = 0.0
        TXTTOTALTAXAMT.Clear()
        TXTTOTALOTHERCHGSAMT.Clear()
        TXTCHARGES.Text = 0.0
        txtsubtotal.Text = 0.0
        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0

        lbltotalqty.Text = 0.0
        lbltotalmtrs.Text = 0.0
        LBLTOTALAMT.Text = 0.0
        LBLTOTALDISCAMT.Text = 0.0
        LBLTOTALSPDISCAMT.Text = 0.0
        LBLTOTALOTHERAMT.Text = 0.0
        LBLTOTALTAXABLEAMT.Text = 0.0
        LBLTOTALCGSTAMT.Text = 0.0
        LBLTOTALSGSTAMT.Text = 0.0
        LBLTOTALIGSTAMT.Text = 0.0
        TXTCGSTPER1.Clear()
        TXTCGSTAMT1.Clear()
        TXTSGSTPER1.Clear()
        TXTSGSTAMT1.Clear()
        TXTIGSTPER1.Clear()
        TXTIGSTAMT1.Clear()

        txtinwords.Clear()
        TXTEWAYBILLNO.Clear()

        TabControl1.SelectedIndex = 0

    End Sub

    'Sub getexcise()
    '    Try
    '        TXTEXCISEID.Text = 0
    '        TXTEXCISE.Text = 0.0
    '        TXTEDUCESS.Text = 0.0
    '        TXTHSECESS.Text = 0.0
    '        Dim objcmn As New ClsCommon
    '        'Dim DT As DataTable = objcmn.search(" ISNULL(MAX(EXCISE_ID),0)", "", " EXCISEMASTER ", " AND EXCISE_wef <= '" & Format(BILLDATE.Text, "MM/dd/yyyy") & "' AND EXCISE_YEARID = " & YearId)


    '        Dim DT As DataTable = objcmn.search(" ISNULL(MAX(EXCISE_ID),0)", "", " EXCISEMASTER ", " AND EXCISE_wef <= '" & Format(Convert.ToDateTime("DATE").Date, "dd/MM/yyyy") & "' AND EXCISE_YEARID = " & YearId)
    '        If DT.Rows.Count > 0 Then
    '            TXTEXCISEID.Text = DT.Rows(0).Item(0)
    '        End If

    '        DT.Clear()

    '        DT = objcmn.search(" EXCISE_NAME, EXCISE_EDU, EXCISE_HSE", "", " EXCISEMASTER", " AND EXCISE_ID = " & TXTEXCISEID.Text.Trim & "AND EXCISE_CMPID = " & CmpId & " AND EXCISE_LOCATIONID = " & Locationid & " AND EXCISE_YEARID = " & YearId)
    '        If DT.Rows.Count > 0 Then
    '            TXTEXCISE.Text = DT.Rows(0).Item(0)
    '            TXTEDUCESS.Text = DT.Rows(0).Item(1)
    '            TXTHSECESS.Text = DT.Rows(0).Item(2)
    '            total()
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Sub getmax_BILL_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(BILL_NO),0) + 1 ", "  PURCHASEMaster INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND BILL_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTBILLNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub PurchaseMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Or e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3) Then       'for CLEAR
                TabControl1.SelectedIndex = (2)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D4) Then       'for CLEAR
                TabControl1.SelectedIndex = (3)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDBILL.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for DIRECT CURSOR ON BILLNO
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F3 Then
                TabControl1.SelectedIndex = 1
                CMBCHARGES.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Sub FILLCMB()
        fillregister(cmbregister, " and register_type = 'PURCHASE'")
        If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        If CMBTRANSPORT.Text.Trim = "" Then filltransname(CMBTRANSPORT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Sale A/C' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C' )")
        If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        fillcity(CMBFROMCITY)
        fillcity(CMBTOCITY)
        fillform(CHKFORMBOX, EDIT)
        If CMBSACDESC.Text.Trim = "" Then FILLSACCODE(CMBSACDESC, EDIT)

        If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, "")
        If CMBQTYUNIT.Text.Trim = "" Then fillunit(CMBQTYUNIT)

        If cmbtax.Text.Trim = "" Then FILLTAXNAME(cmbtax, EDIT)
        If cmbaddtax.Text.Trim = "" Then FILLTAXNAME(cmbaddtax, EDIT)
        If cmboctroi.Text.Trim = "" Then fillOCTROI(cmboctroi, EDIT)

    End Sub

    Private Sub PurchaseMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            FILLCMB()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList
                Dim objclsINV As New ClsPurchaseMaster

                ALPARAVAL.Add(tempBILLno)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsINV.alParaval = ALPARAVAL
                dt = objclsINV.selectpurchase()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        CMBSCREENTYPE.Text = dr("SCREENTYPE")
                        CMBSCREENTYPE.Enabled = False
                        TXTBILLNO.Text = TEMPBILLNO
                        TXTBILLNO.ReadOnly = True

                        If Convert.ToBoolean(dr("RCM")) = False Then CHKRCM.Checked = False Else CHKRCM.Checked = True

                        cmbregister.Text = Convert.ToString(dr("REGNAME"))
                        CMBSERVICETYPE.Text = Convert.ToString(dr("PURTYPE"))
                        CMBSACDESC.Text = dr("SACDESC")
                        TXTSACCODE.Text = dr("SACCODE")
                        HIDEVIEW()
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")


                        BILLDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        TXTPARTYBILLNO.Text = Convert.ToString(dr("PARTYBILLNO"))
                        TEMPPARTYBILLNO = Convert.ToString(dr("PARTYBILLNO"))
                        DTPARTYBILLDATE.Text = Format(Convert.ToDateTime(dr("PARTYBILLDATE")).Date, "dd/MM/yyyy")

                        CMBAGENT.Text = Convert.ToString(dr("AGENT"))
                        CMBTRANSPORT.Text = dr("TRANSNAME")
                        TXTCRDAYS.Text = Convert.ToString(dr("CRDAYS"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))

                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO"))
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        txtrefno.Text = Convert.ToString(dr("REFFNO"))
                        txtlrno.Text = dr("LRNO")
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        TXTTRANSFREIGHT.Text = dr("TRANSFREIGHT")
                        CMBFROMCITY.Text = dr("FROMCITY")
                        CMBTOCITY.Text = dr("TOCITY")

                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")
                        If dr("BILLCHECKED") = 0 Then CHKBILLCHECKED.Checked = False Else CHKBILLCHECKED.Checked = True
                        If dr("BILLDISPUTE") = 0 Then CHKBILLDISPUTE.Checked = False Else CHKBILLDISPUTE.Checked = True
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True

                        txtremarks.Text = Convert.ToString(dr("Remarks"))

                        TXTCGSTPER1.Text = Val(dr("TOTALCGSTPER"))
                        TXTSGSTPER1.Text = Val(dr("TOTALSGSTPER"))
                        TXTIGSTPER1.Text = Val(dr("TOTALIGSTPER"))

                        If CMBSCREENTYPE.Text = "TOTAL GST" And CHKMANUAL.Checked = True Then
                            TXTCGSTAMT1.Text = Format(Val(dr("TOTALCGSTAMT")), "0.00")
                            TXTSGSTAMT1.Text = Format(Val(dr("TOTALSGSTAMT")), "0.00")
                            TXTIGSTAMT1.Text = Format(Val(dr("TOTALIGSTAMT")), "0.00")
                        End If

                        txtbillamt.Text = Val(dr("BILLAMT"))
                        TXTCHARGES.Text = Val(dr("CHARGES"))
                        txtroundoff.Text = Val(dr("ROUNDOFF"))
                        txtgrandtotal.Text = Val(dr("GRANDTOTAL"))

                        TXTAMTPAID.Text = Val(dr("AMTPAID"))
                        TXTEXTRAAMT.Text = Val(dr("EXTRAAMT"))
                        TXTRETURN.Text = Val(dr("BILLRETURN"))
                        TXTBAL.Text = Val(dr("BALANCE"))




                        txtdisper.Text = dr("DISPER")
                        txtdisamt.Text = dr("DISAMT")
                        txtpfper.Text = dr("PFPER")
                        txtpfamt.Text = dr("PFAMT")
                        txttestchgs.Text = dr("TESTCHGS")
                        txtnett.Text = dr("NETT")
                        If dr("EXCISEID") > 0 Then chkexcise.CheckState = CheckState.Checked Else chkexcise.CheckState = CheckState.Unchecked
                        TXTEXCISEID.Text = dr("EXCISEID")
                        TXTEXCISE.Text = dr("EXCISENAME")
                        txtexciseAMT.Text = dr("EXCISEAMT")
                        TXTEDUCESS.Text = dr("EDUCESSNAME")
                        txteducessAMT.Text = dr("EDUCESSAMT")
                        TXTHSECESS.Text = dr("HSECESSNAME")
                        txthsecessAMT.Text = dr("HSECESSAMT")
                        txtsubtotal.Text = dr("SUBTOTAL")
                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        cmbaddtax.Text = dr("ADDTAXNAME")
                        txtaddtax.Text = dr("ADDTAXAMT")
                        txtfrper.Text = dr("FRPER")
                        txtfreight.Text = dr("FREIGHT")
                        cmboctroi.Text = dr("OCTROINAME")
                        txtoctroi.Text = dr("OCTROIAMT")
                        txtinspchgs.Text = dr("INSAMT")

                        GRIDBILL.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("HSNCODE").ToString, dr("QUALITY").ToString, dr("COLOR"), dr("QTY").ToString, dr("UNIT").ToString, dr("MTRS").ToString, Format(Val(dr("RATE")), "0.0000"), dr("PER"), dr("AMT").ToString, Val(dr("DISCPER")), Val(dr("DISCAMT")), Val(dr("SPDISCPER")), Val(dr("SPDISCAMT")), Val(dr("OTHERAMT")), Val(dr("TAXABLEAMT")), Val(dr("CGSTPER")), Val(dr("CGSTAMT")), Val(dr("SGSTPER")), Val(dr("SGSTAMT")), Val(dr("IGSTPER")), Val(dr("IGSTAMT")), Val(dr("GRIDTOTAL")), dr("GRNNO"), dr("GRNGRIDSRNO"), dr("GRIDDONE"))

                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = False
                            GRIDBILL.Rows(GRIDBILL.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                            cmbname.Enabled = False
                        End If

                        TabControl1.SelectedIndex = 0

                        ''CHECKING WHETHER TDS IS DEDUCTED OR NOT
                        Dim OBJCMNTDS As New ClsCommon
                        Dim DTTDS As DataTable = OBJCMNTDS.search(" ISNULL(SUM(JOURNALMASTER.journal_credit),0) AS TDS", "", " JOURNALMASTER INNER JOIN PURCHASEMASTER ON JOURNALMASTER.journal_refno = PURCHASEMASTER.BILL_INITIALS AND  JOURNALMASTER.journal_yearid = PURCHASEMASTER.BILL_YEARID INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id ", " AND (LEDGERS.ACC_TDSAC = 'True') AND BILL_NO = " & TEMPBILLNO & " AND REGISTER_NAME = '" & TEMPREGNAME & "' AND BILL_YEARID = " & YearId)
                        If DTTDS.Rows.Count > 0 Then
                            If Val(DTTDS.Rows(0).Item("TDS")) > 0 Then
                                TXTTDSAMT.Text = Format(Val(DTTDS.Rows(0).Item("TDS")), "0.00")
                                CMDSHOWDETAILS.Visible = True
                                PBTDS.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        End If

                        If PBTDS.Visible = False Then
                            If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                                CMDSHOWDETAILS.Visible = True
                                PBPAID.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        End If

                        If Val(dr("BILLRETURN")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBDN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    'CHARGES GRID
                    Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search(" ISNULL(PURCHASEMASTER_CHGS.BILL_gridsrno,0) AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CHARGES, ISNULL(PURCHASEMASTER_CHGS.BILL_PER, 0) AS PER, ISNULL(PURCHASEMASTER_CHGS.BILL_AMT, 0) AS AMT, ISNULL(TAXMASTER.TAX_ID, 0) AS TAXID ", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN PURCHASEMASTER_CHGS LEFT OUTER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID LEFT OUTER JOIN LEDGERS ON PURCHASEMASTER_CHGS.BILL_CHARGESID = LEDGERS.Acc_id", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND PURCHASEMASTER_CHGS.BILL_NO = " & TEMPBILLNO & " AND PURCHASEMASTER_CHGS.BILL_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If

                    dt = OBJCMN.search(" ISNULL(FORMTYPE.FORM_NAME, '') AS FORMNAME ", "", "  PURCHASEMASTER_FORMTYPE INNER JOIN REGISTERMASTER ON PURCHASEMASTER_FORMTYPE.BILL_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTERMASTER.REGISTER_TYPE = 'PURCHASE' AND PURCHASEMASTER_FORMTYPE.BILL_NO = " & TEMPBILLNO & " AND PURCHASEMASTER_FORMTYPE.BILL_YEARID= " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each ROW As DataRow In dt.Rows
                            For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
                                Dim DTR As DataRowView = CHKFORMBOX.Items(I)
                                If ROW("FORMNAME") = DTR.Item(0) Then
                                    CHKFORMBOX.SetItemCheckState(I, CheckState.Checked)
                                End If
                            Next
                        Next
                    End If


                    dt = OBJCMN.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        PURREGABBR = dt.Rows(0).Item(0).ToString
                        PURREGINITIAL = dt.Rows(0).Item(1).ToString
                        PURREGID = dt.Rows(0).Item(2)
                    End If

                    GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1

                End If

                cmbregister.Enabled = False
                CMBSERVICETYPE.Enabled = False
                cmdgrn.Enabled = False
                cmbname.Enabled = False
                total()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            If TXTBILLNO.ReadOnly = False Then
                alParaval.Add(Val(TXTBILLNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBSCREENTYPE.Text.Trim)

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(CMBSERVICETYPE.Text.Trim)
            alParaval.Add(TXTSACCODE.Text.Trim)
            If CHKRCM.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(BILLDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text)
            alParaval.Add(CHALLANDATE.Value)
            alParaval.Add(txtrefno.Text)

            alParaval.Add(TXTCRDAYS.Text)
            alParaval.Add(duedate.Value.Date)

            alParaval.Add(CMBTRANSPORT.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(TXTTRANSFREIGHT.Text.Trim)
            alParaval.Add(CMBFROMCITY.Text.Trim)
            alParaval.Add(CMBTOCITY.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)
            If CHKBILLCHECKED.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKBILLDISPUTE.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUAL.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)



            alParaval.Add(txtdisper.Text.Trim)
            alParaval.Add(txtdisamt.Text.Trim)
            alParaval.Add(txtpfper.Text.Trim)
            alParaval.Add(txtpfamt.Text.Trim)
            alParaval.Add(txttestchgs.Text.Trim)
            alParaval.Add(txtnett.Text.Trim)
            alParaval.Add(Val(TXTEXCISE.Text.Trim))
            alParaval.Add(txtexciseAMT.Text.Trim)
            alParaval.Add(Val(TXTEDUCESS.Text.Trim))
            alParaval.Add(txteducessAMT.Text.Trim)
            alParaval.Add(Val(TXTHSECESS.Text.Trim))
            alParaval.Add(txthsecessAMT.Text.Trim)
            'alParaval.Add(txtsubtotal.Text.Trim)
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(txttax.Text.Trim)
            alParaval.Add(cmbaddtax.Text.Trim)
            alParaval.Add(txtaddtax.Text.Trim)
            alParaval.Add(txtfrper.Text.Trim)
            alParaval.Add(txtfreight.Text.Trim)
            alParaval.Add(cmboctroi.Text.Trim)
            alParaval.Add(txtoctroi.Text.Trim)
            alParaval.Add(txtinspchgs.Text.Trim)
            alParaval.Add(TXTEXCISEID.Text)


            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(lbltotalqty.Text.Trim)
            alParaval.Add(lbltotalmtrs.Text.Trim)
            alParaval.Add(Val(LBLTOTALAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALDISCAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALSPDISCAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALOTHERAMT.Text.Trim))
            alParaval.Add(Val(LBLTOTALTAXABLEAMT.Text.Trim))

            If CMBSCREENTYPE.Text = "TOTAL GST" Then
                alParaval.Add(Val(TXTCGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTCGSTAMT1.Text.Trim))
                alParaval.Add(Val(TXTSGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTSGSTAMT1.Text.Trim))
                alParaval.Add(Val(TXTIGSTPER1.Text.Trim))
                alParaval.Add(Val(TXTIGSTAMT1.Text.Trim))
            Else
                alParaval.Add(Val(TXTCGSTPER.Text.Trim))
                alParaval.Add(Val(LBLTOTALCGSTAMT.Text.Trim))
                alParaval.Add(Val(TXTSGSTPER.Text.Trim))
                alParaval.Add(Val(LBLTOTALSGSTAMT.Text.Trim))
                alParaval.Add(Val(TXTIGSTPER.Text.Trim))
                alParaval.Add(Val(LBLTOTALIGSTAMT.Text.Trim))
            End If



            alParaval.Add(txtinwords.Text)
            alParaval.Add(txtinwordexcise.Text)
            alParaval.Add(txtinwordedu.Text)
            alParaval.Add(txtinwordhse.Text)


            alParaval.Add(Val(txtbillamt.Text.Trim))
            alParaval.Add(Format(Val(TXTTOTALTAXAMT.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTTOTALOTHERCHGSAMT.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTCHARGES.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtsubtotal.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtroundoff.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(txtgrandtotal.Text.Trim), "0.00"))

            alParaval.Add(Val(TXTAMTPAID.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBAL.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            'ADDING FORMTYPE
            Dim FORMTYPE As String = ""
            For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
                If FORMTYPE = "" Then
                    FORMTYPE = DTROW.Item(0)
                Else
                    FORMTYPE = FORMTYPE & "|" & DTROW.Item(0)
                End If
            Next
            alParaval.Add(FORMTYPE)


            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""
            Dim QUALITY As String = ""
            Dim COLOR As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim MTRS As String = ""
            Dim RATE As String = ""         'value of RATE
            Dim PER As String = ""
            Dim AMT As String = ""         'value of AMT
            Dim DISCPER As String = ""
            Dim DISCAMT As String = ""
            Dim SPDISCPER As String = ""
            Dim SPDISCAMT As String = ""
            Dim OTHERAMT As String = ""
            Dim TAXABLEAMT As String = ""
            Dim CGSTPER As String = ""
            Dim CGSTAMT As String = ""
            Dim SGSTPER As String = ""
            Dim SGSTAMT As String = ""
            Dim IGSTPER As String = ""
            Dim IGSTAMT As String = ""
            Dim GRIDTOTAL As String = ""
            Dim GRNNO As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRNGRIDSRNO As String = ""   'value of GRNGRIDSRNO
            Dim BILLDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDBILL.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        qty = row.Cells(gQty.Index).Value.ToString
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value
                        RATE = Format(Val(row.Cells(GRATE.Index).Value), "0.0000")
                        PER = row.Cells(GPER.Index).Value.ToString

                        If row.Cells(GAMT.Index).Value <> Nothing Then AMT = row.Cells(GAMT.Index).Value Else AMT = 0
                        If row.Cells(GDISCPER.Index).Value <> Nothing Then DISCPER = row.Cells(GDISCPER.Index).Value Else DISCPER = 0
                        If row.Cells(GDISCAMT.Index).Value <> Nothing Then DISCAMT = row.Cells(GDISCAMT.Index).Value Else DISCAMT = 0
                        If row.Cells(GSPDISCPER.Index).Value <> Nothing Then SPDISCPER = row.Cells(GSPDISCPER.Index).Value Else SPDISCPER = 0
                        If row.Cells(GSPDISCAMT.Index).Value <> Nothing Then SPDISCAMT = row.Cells(GSPDISCAMT.Index).Value Else SPDISCAMT = 0
                        If row.Cells(GOTHERAMT.Index).Value <> Nothing Then OTHERAMT = row.Cells(GOTHERAMT.Index).Value Else OTHERAMT = 0

                        TAXABLEAMT = row.Cells(GTAXABLEAMT.Index).Value
                        CGSTPER = row.Cells(GCGSTPER.Index).Value
                        CGSTAMT = row.Cells(GCGSTAMT.Index).Value
                        SGSTPER = row.Cells(GSGSTPER.Index).Value
                        SGSTAMT = row.Cells(GSGSTAMT.Index).Value
                        IGSTPER = row.Cells(GIGSTPER.Index).Value
                        IGSTAMT = row.Cells(GIGSTAMT.Index).Value
                        GRIDTOTAL = row.Cells(GGRIDTOTAL.Index).Value

                        GRNNO = row.Cells(GGRNNO.Index).Value

                        If row.Cells(GGRNSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = row.Cells(GGRNSRNO.Index).Value
                        Else
                            GRNGRIDSRNO = 0
                        End If
                        'GRIDTYPE = GRIDTYPE & "|" & row.Cells(GTYPE.Index).Value


                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            BILLDONE = "1"
                        Else
                            BILLDONE = "0"
                        End If

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        qty = qty & "|" & row.Cells(gQty.Index).Value
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        RATE = RATE & "|" & Format(Val(row.Cells(GRATE.Index).Value), "0.0000")
                        PER = PER & "|" & row.Cells(GPER.Index).Value

                        If row.Cells(GAMT.Index).Value <> Nothing Then AMT = AMT & "|" & row.Cells(GAMT.Index).Value Else AMT = AMT & "|" & "0"
                        DISCPER = DISCPER & "|" & Val(row.Cells(GDISCPER.Index).Value)
                        DISCAMT = DISCAMT & "|" & Val(row.Cells(GDISCAMT.Index).Value)
                        SPDISCPER = SPDISCPER & "|" & Val(row.Cells(GSPDISCPER.Index).Value)
                        SPDISCAMT = SPDISCAMT & "|" & Val(row.Cells(GSPDISCAMT.Index).Value)
                        OTHERAMT = OTHERAMT & "|" & Val(row.Cells(GOTHERAMT.Index).Value)

                        TAXABLEAMT = TAXABLEAMT & "|" & Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = CGSTPER & "|" & Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = CGSTAMT & "|" & Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = SGSTPER & "|" & Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = SGSTAMT & "|" & Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = IGSTPER & "|" & Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = IGSTAMT & "|" & Val(row.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = GRIDTOTAL & "|" & Val(row.Cells(GGRIDTOTAL.Index).Value)

                        GRNNO = GRNNO & "|" & row.Cells(GGRNNO.Index).Value

                        If row.Cells(GGRNSRNO.Index).Value <> Nothing Then
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & Val(row.Cells(GGRNSRNO.Index).Value)
                        Else
                            GRNGRIDSRNO = GRNGRIDSRNO & "|" & " 0"
                        End If
                        'GRIDTYPE = row.Cells(GTYPE.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            BILLDONE = BILLDONE & "|" & "1"
                        Else
                            BILLDONE = BILLDONE & "|" & "0"
                        End If


                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)
            alParaval.Add(QUALITY)
            alParaval.Add(COLOR)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(RATE)
            alParaval.Add(PER)

            alParaval.Add(AMT)
            alParaval.Add(DISCPER)
            alParaval.Add(DISCAMT)
            alParaval.Add(SPDISCPER)
            alParaval.Add(SPDISCAMT)
            alParaval.Add(OTHERAMT)
            alParaval.Add(TAXABLEAMT)
            alParaval.Add(CGSTPER)
            alParaval.Add(CGSTAMT)
            alParaval.Add(SGSTPER)
            alParaval.Add(SGSTAMT)
            alParaval.Add(IGSTPER)
            alParaval.Add(IGSTAMT)
            alParaval.Add(GRIDTOTAL)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNGRIDSRNO)
            alParaval.Add(BILLDONE)


            Dim CSRNO As String = ""
            Dim CCHGS As String = ""
            Dim CPER As String = ""
            Dim CAMT As String = ""
            Dim CTAXID As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCHGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = Val(row.Cells(ESRNO.Index).Value)
                        CCHGS = row.Cells(ECHARGES.Index).Value.ToString
                        CPER = Val(row.Cells(EPER.Index).Value)
                        CAMT = Val(row.Cells(EAMT.Index).Value)
                        CTAXID = Val(row.Cells(ETAXID.Index).Value)

                    Else
                        CSRNO = CSRNO & "|" & Val(row.Cells(ESRNO.Index).Value)
                        CCHGS = CCHGS & "|" & row.Cells(ECHARGES.Index).Value.ToString
                        CPER = CPER & "|" & Val(row.Cells(EPER.Index).Value)
                        CAMT = CAMT & "|" & Val(row.Cells(EAMT.Index).Value)
                        CTAXID = CTAXID & "|" & Val(row.Cells(ETAXID.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCHGS)
            alParaval.Add(CPER)
            alParaval.Add(CAMT)
            alParaval.Add(CTAXID)


            Dim OBJINV As New ClsPurchaseMaster
            OBJINV.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJINV.SAVE()
                MessageBox.Show("Details Added")

                If CHKTDS.CheckState = CheckState.Checked Then
                    Dim OBJTDS As New DeductTDS
                    OBJTDS.BILLNO = DTTABLE.Rows(0).Item(0)
                    OBJTDS.REGISTER = cmbregister.Text.Trim
                    OBJTDS.ShowDialog()
                End If


            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBILLNO)
                IntResult = OBJINV.Update()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If


            'SHOW NEXT BILL ON EDIT MODE DONT CLEAR
            'clear()
            Call toolnext_Click(sender, e)

            If CMBSERVICETYPE.Visible = True Then CMBSERVICETYPE.Focus() Else BILLDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub CALC()
        Try
            TXTAMT.Text = 0.0
            TXTGRIDTOTAL.Text = 0.0
            If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCAMT.Clear()
            If Val(TXTSPDISCPER.Text.Trim) > 0 Then TXTSPDISCAMT.Clear()
            'If CHKMANUAL.CheckState = CheckState.Unchecked Then
            '    TXTCGSTAMT.Text = 0.0
            '    TXTSGSTAMT.Text = 0.0
            '    TXTIGSTAMT.Text = 0.0

            '    TXTCGSTAMT1.Text = 0.0
            '    TXTSGSTAMT1.Text = 0.0
            '    TXTIGSTAMT1.Text = 0.0
            'End If
            If Val(TXTRATE.Text.Trim) > 0 Then
                If CMBPER.Text = "Mtrs" Then
                    TXTAMT.Text = Format(Val(TXTMTRS.Text) * Val(TXTRATE.Text), "0.00")
                Else
                    TXTAMT.Text = Format(Val(TXTQTY.Text) * Val(TXTRATE.Text), "0.00")
                End If
            End If

            If Val(TXTDISCPER.Text.Trim) > 0 And Val(TXTDISCAMT.Text.Trim) = 0 Then TXTDISCAMT.Text = Format(Val(TXTAMT.Text.Trim) * (Val(TXTDISCPER.Text.Trim) / 100), "0.00")
            If Val(TXTSPDISCPER.Text.Trim) > 0 And Val(TXTSPDISCAMT.Text.Trim) = 0 Then TXTSPDISCAMT.Text = Format((Val(TXTAMT.Text.Trim) - Val(TXTDISCAMT.Text.Trim)) * (Val(TXTSPDISCPER.Text.Trim) / 100), "0.00")
            TXTTAXABLEAMT.Text = Format((Val(TXTAMT.Text.Trim) - Val(TXTDISCAMT.Text.Trim) - Val(TXTSPDISCPER.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0.00")
            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")

                TXTCGSTAMT1.Text = Format(Val(TXTCGSTPER1.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")
                TXTSGSTAMT1.Text = Format(Val(TXTSGSTPER1.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")
                TXTIGSTAMT1.Text = Format(Val(TXTIGSTPER1.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")

            End If
            TXTGRIDTOTAL.Text = Format(Val(TXTTAXABLEAMT.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text), "0.00")

            'If CMBSCREENTYPE.Text = "TOTAL GST" Then TXTGRIDTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text) + Val(TXTSGSTAMT1.Text) + Val(TXTIGSTAMT1.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Enter Register Name")
            bln = False
        End If

        If ALLOWMANUALINVNO = True Then
            If TXTBILLNO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon

                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(CONTRA.CONTRA_no,0) AS CONTRANO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN CONTRA ON REGISTERMASTER.register_id = CONTRA.CONTRA_registerid AND REGISTERMASTER.register_cmpid = CONTRA.CONTRA_cmpid AND REGISTERMASTER.register_yearid = CONTRA.CONTRA_yearid AND REGISTERMASTER.register_locationid = CONTRA.CONTRA_locationid ", "  AND CONTRA.CONTRA_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND CONTRA.CONTRA_CMPID = " & CmpId & " AND CONTRA.CONTRA_LOCATIONID = " & Locationid & " AND CONTRA.CONTRA_YEARID = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PURCHASEMASTER.BILL_NO, 0) AS BILLNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN PURCHASEMASTER ON REGISTERMASTER.register_id = PURCHASEMASTER.BILL_REGISTERID AND REGISTERMASTER.register_cmpid = PURCHASEMASTER.BILL_CMPID AND REGISTERMASTER.register_yearid = PURCHASEMASTER.BILL_YEARID AND REGISTERMASTER.register_locationid = PURCHASEMASTER.BILL_LOCATIONID ", "  AND PURCHASEMASTER.BILL_NO=" & TXTBILLNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PURCHASEMASTER.BILL_cmpid = " & CmpId & " AND PURCHASEMASTER.BILL_locationid = " & Locationid & " AND PURCHASEMASTER.BILL_yearid = " & YearId)

                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTBILLNO, "Bill No Already Exist")
                    bln = False
                End If
            End If
        End If


        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If

        If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTPARTYBILLNO, "Enter Party Bill No")
            bln = False
        End If

        If Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then
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

        'If CMBAGENT.Text.Trim.Length = 0 Then
        '    EP.SetError(CMBAGENT, " Please Enter Agent Name ")
        '    bln = False
        'End If

        If GRIDBILL.RowCount = 0 Then
            EP.SetError(cmbname, "Select grn")
            bln = False
        End If

        For Each row As DataGridViewRow In GRIDBILL.Rows
            If Val(row.Cells(GAMT.Index).Value) = 0 Then
                EP.SetError(cmbname, "Amt Cannot be 0")
                bln = False
            End If
        Next

        Dim FORMTYPE As String = ""
        For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
            FORMTYPE = DTROW.Item(0)
        Next
        If FORMTYPE = Nothing Then
            EP.SetError(CHKFORMBOX, "Pls Select Form Type")
            bln = False
        End If

        If UserName <> "Admin" Then
            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Rec/Pay/TDS Made, Delete Rec/Pay/TDS First")
                bln = False
            End If
        End If

        If BILLDATE.Text = "__/__/____" Then
            EP.SetError(BILLDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(BILLDATE.Text) Then
                EP.SetError(BILLDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If DTPARTYBILLDATE.Text = "__/__/____" Then
            EP.SetError(DTPARTYBILLDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTPARTYBILLDATE.Text) Then
                EP.SetError(DTPARTYBILLDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If TXTPARTYBILLNO.Text.Trim <> "" Then
            If (EDIT = False) Or (EDIT = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BILL_INITIALS AS BILLNO", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND BILL_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Party Bill No Already Exists in Entry No " & DT.Rows(0).Item("BILLNO"))
                    bln = False
                End If
            End If
        End If
        Return bln
    End Function

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE ='ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub total()
        Try


            lbltotalqty.Text = "0.00"
            lbltotalmtrs.Text = "0.00"
            LBLTOTALAMT.Text = "0.0"
            LBLTOTALDISCAMT.Text = 0.0
            LBLTOTALSPDISCAMT.Text = 0.0
            LBLTOTALOTHERAMT.Text = "0.0"
            LBLTOTALTAXABLEAMT.Text = "0.0"
            LBLTOTALCGSTAMT.Text = "0.0"
            LBLTOTALSGSTAMT.Text = "0.0"
            LBLTOTALIGSTAMT.Text = "0.0"


            'txtexciseAMT.Text = 0.0
            'txteducessAMT.Text = 0.0
            'txthsecessAMT.Text = 0.0
            'txtsubtotal.Text = 0.0
            'txttax.Text = 0.0
            'txtaddtax.Text = 0.0
            'If Val(txtfrper.Text) > 0 Then txtfreight.Text = 0.0
            'txtnett.Text = 0.0
            'txtoctroi.Text = 0.0

            txtbillamt.Text = 0.0
            TXTCHARGES.Text = 0.0
            txtsubtotal.Text = 0
            txtroundoff.Text = 0
            txtgrandtotal.Text = 0

            If GRIDBILL.RowCount > 0 Then

                For Each row As DataGridViewRow In GRIDBILL.Rows
                    If row.Cells(GPER.Index).EditedFormattedValue = "Mtrs" Then
                        row.Cells(GAMT.Index).Value = (row.Cells(GMTRS.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue)
                    ElseIf row.Cells(GPER.Index).EditedFormattedValue = "Qty" Then
                        row.Cells(GAMT.Index).Value = (row.Cells(gQty.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue)
                    End If
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

                    If CHKMANUAL.CheckState = CheckState.Unchecked And CMBSCREENTYPE.Text = "LINE GST" Then
                        row.Cells(GCGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GCGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                        row.Cells(GSGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GSGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                        row.Cells(GIGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GIGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                    End If
                    row.Cells(GGRIDTOTAL.Index).Value = Format(Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")

                    If Val(row.Cells(gQty.Index).Value) <> 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).Value), "0.00")
                    If Val(row.Cells(GMTRS.Index).Value) <> 0 Then lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(row.Cells(GMTRS.Index).Value), "0.00")
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

                If GRIDCHGS.RowCount > 0 Then
                    For Each row As DataGridViewRow In GRIDCHGS.Rows
                        TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                        If Val(row.Cells(ETAXID.Index).Value) > 0 Then TXTTOTALTAXAMT.Text = Format(Val(TXTTOTALTAXAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00") Else TXTTOTALOTHERCHGSAMT.Text = Format(Val(TXTTOTALOTHERCHGSAMT.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                    Next
                End If

                If Format(Convert.ToDateTime(DTPARTYBILLDATE.Text).Date, "dd/MM/yyyy") < "01/07/2017" Then
                    If Val(txtdisper.Text) > 0 Then txtdisamt.Text = Format((Val(txtdisper.Text) * Val(txtbillamt.Text)) / 100, "0.00")
                    If Val(txtpfper.Text) > 0 Then txtpfamt.Text = Format((Val(txtpfper.Text) * Val(txtbillamt.Text)) / 100, "0.00")
                    txtnett.Text = Format((txtbillamt.Text) - Val(txtdisamt.Text) + Val(txtpfamt.Text) + Val(txttestchgs.Text), "0.00")
                    txtexciseAMT.Text = Format((Val(TXTEXCISE.Text) * Val(txtnett.Text)) / 100, "0.00")
                    txteducessAMT.Text = Format(Val((Val(TXTEDUCESS.Text) * Val(txtexciseAMT.Text)) / 100), "0.00")
                    txthsecessAMT.Text = Format((Val(TXTHSECESS.Text) * Val(txtexciseAMT.Text)) / 100, "0.00")
                    txtsubtotal.Text = Format(Val(txtnett.Text) + Val(txteducessAMT.Text) + Val(txtexciseAMT.Text) + Val(txthsecessAMT.Text), "0.00")


                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(txtsubtotal.Text)) / 100, "0.00")

                    dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbaddtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then txtaddtax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(txtsubtotal.Text)) / 100, "0.00")

                    If Val(txtfrper.Text) > 0 Then txtfreight.Text = Format((Val(txtfrper.Text) * Val(txtbillamt.Text)) / 100, "0.00")

                    dt = objclscommon.search("OCTROI_NAME,OCTROI_octroi", "", "OCTROIMaster", " and OCTROI_NAME = '" & cmboctroi.Text.Trim & "' and OCTROI_cmpid = " & CmpId & " and OCTROI_Locationid = " & Locationid & " and OCTROI_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then txtoctroi.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text))) / 100, "0.00")

                    txtgrandtotal.Text = Format(Val(txtoctroi.Text) + Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text) + Val(txtinspchgs.Text), "0")

                    txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtaddtax.Text) + Val(txtfreight.Text) + Val(txtoctroi.Text) + Val(txtinspchgs.Text)), "0.00")


                Else

                    txtsubtotal.Text = Format(Val(txtbillamt.Text) + Val(TXTCHARGES.Text.Trim), "0.00")
                    If CMBSCREENTYPE.Text = "TOTAL GST" Then
                        If CHKMANUAL.CheckState = CheckState.Unchecked Then
                            TXTCGSTAMT1.Text = Format((Val(txtsubtotal.Text.Trim) * Val(TXTCGSTPER1.Text.Trim)) / 100, "0.00")
                            LBLTOTALCGSTAMT.Text = Val(TXTCGSTAMT1.Text.Trim)
                            TXTSGSTAMT1.Text = Format((Val(txtsubtotal.Text.Trim) * Val(TXTSGSTPER1.Text.Trim)) / 100, "0.00")
                            LBLTOTALSGSTAMT.Text = Val(TXTSGSTAMT1.Text.Trim)
                            TXTIGSTAMT1.Text = Format((Val(txtsubtotal.Text.Trim) * Val(TXTIGSTPER1.Text.Trim)) / 100, "0.00")
                            LBLTOTALIGSTAMT.Text = Val(TXTIGSTAMT1.Text.Trim)
                        End If
                        txtgrandtotal.Text = Format(Val(txtsubtotal.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim), "0")
                        txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtsubtotal.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim)), "0.00")
                    Else
                        txtgrandtotal.Text = Format(Val(txtsubtotal.Text), "0")
                        txtroundoff.Text = Format(Val(txtgrandtotal.Text) - Val(txtsubtotal.Text), "0.00")
                    End If


                End If

                If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
                If Val(txtexciseAMT.Text) > 0 Then txtinwordexcise.Text = CurrencyToWord(txtexciseAMT.Text)
                If Val(txteducessAMT.Text) > 0 Then txtinwordedu.Text = CurrencyToWord(txteducessAMT.Text)
                If Val(txthsecessAMT.Text) > 0 Then txtinwordhse.Text = CurrencyToWord(txthsecessAMT.Text)
                txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If EDIT = True Then
                If lbllocked.Visible = True Then
                    MsgBox("Invoice Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim intresult As Integer
                Dim objcls As New ClsPurchaseMaster()
                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPBILLNO)
                    alParaval.Add(TEMPREGNAME)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)
                    objcls.alParaval = alParaval
                    intresult = objcls.DELETE()
                    MsgBox("Purchase Invoice Delete Successfully")
                    clear()
                    EDIT = False

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBILL.RowCount = 0
LINE1:
            TEMPBILLNO = Val(TXTBILLNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPBILLNO > 0 Then
                EDIT = True
                PurchaseMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDBILL.RowCount = 0 And TEMPBILLNO > 1 Then
                TXTBILLNO.Text = TEMPBILLNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBILL.RowCount = 0
LINE1:
            TEMPBILLNO = Val(TXTBILLNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmax_BILL_no()
            Dim MAXNO As Integer = TXTBILLNO.Text.Trim
            clear()
            If Val(TXTBILLNO.Text) - 1 >= TEMPBILLNO Then
                EDIT = True
                PurchaseMaster_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDBILL.RowCount = 0 And TEMPBILLNO < MAXNO Then
                TXTBILLNO.Text = TEMPBILLNO
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

            Dim objINVDTLS As New PurchaseDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS_1.ACC_CMPNAME,'') AS TRANSNAME,ISNULL(LEDGERS_2.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, isnull(LEDGERS.ACC_CRDAYS,0) AS CRDAYS ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    CMBTRANSPORT.Text = DT.Rows(0).Item("TRANSNAME")
                    CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")

                    If Val(TXTCRDAYS.Text.Trim) = 0 Then
                        If Val(DT.Rows(0).Item("CRDAYS")) > 0 Then TXTCRDAYS.Text = Val(DT.Rows(0).Item("CRDAYS"))
                        If Val(TXTCRDAYS.Text) > 0 And DTPARTYBILLDATE.Text <> "__/__/____" Then Call TXTCRDAYS_Validated(sender, e)
                    End If

                    If DT.Rows(0).Item("REGISTERNAME") <> cmbregister.Text.Trim And DT.Rows(0).Item("REGISTERNAME") <> "" Then
                        Dim TEMPMSG As Integer = MsgBox("Register is Different Change to Default?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbYes Then
                            cmbregister.Text = DT.Rows(0).Item("REGISTERNAME")
                            getmax_BILL_no()
                        End If
                    End If
                End If

                'GET TDSAPPLICABLE
                DT = OBJCMN.search("ISNULL(ACC_TDSPER,0) AS TDSPER ", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TDSPER")) > 0 Then CHKTDS.CheckState = CheckState.Checked
                End If

                GETHSNCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE ='ACCOUNTS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub cmdselectgrn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgrn.Click
        Try
            'If cmbname.Text.Trim = "" Then
            '    MsgBox("Please Select Party Name First")
            '    cmbname.Focus()
            '    Exit Sub
            'End If

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            'clear()
            Dim OBJSELECTgrn As New SelectGRNforPurchase
            OBJSELECTgrn.PARTYNAME = cmbname.Text.Trim
            Dim DT As DataTable = OBJSELECTgrn.dt1
            OBJSELECTgrn.ShowDialog()

            Dim i As Integer = 0
            If DT.Rows.Count > 0 Then
                GRIDBILL.RowCount = 0
                cmdgrn.Enabled = False
                For Each dr As DataRow In DT.Rows

                    If ClientName = "MONOGRAM" Then TXTBILLNO.Text = Val(dr("GRNNO"))

                    cmbname.Text = dr("cusname")
                    TXTCHALLANNO.Text = dr("Challanno")
                    CHALLANDATE.Value = dr("Challandate")
                    txtlrno.Text = dr("lrno").ToString
                    lrdate.Value = Convert.ToDateTime(dr("lrdate").ToString)
                    CMBTRANSPORT.Text = dr("trans").ToString

                    Dim OBJCMN As New ClsCommon
                    Dim DTCODE As DataTable = OBJCMN.search("ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                    If DTCODE.Rows.Count > 0 Then
                        TXTSTATECODE.Text = DTCODE.Rows(0).Item("STATECODE")
                        TXTGSTIN.Text = DTCODE.Rows(0).Item("GSTIN")
                    End If

                    If dr("ITEM").ToString <> "" And Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then

                        Dim CGSTPER As Double = 0
                        Dim SGSTPER As Double = 0
                        Dim IGSTPER As Double = 0
                        Dim HSNCODE As String = ""

                        DTCODE = OBJCMN.search("ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER,ISNULL(HSN_IGST,0) AS IGSTPER ", "", " ITEMMASTER LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID ", " and ITEMMASTER.ITEM_NAME = '" & dr("ITEM") & "' AND ITEMMASTER.ITEM_YEARid = " & YearId)
                        If DTCODE.Rows.Count > 0 Then
                            HSNCODE = DTCODE.Rows(0).Item("HSNCODE")

                            If PURCHASESCREENTYPE = "LINE GST" Then
                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    CGSTPER = Val(DTCODE.Rows(0).Item("CGSTPER"))
                                    SGSTPER = Val(DTCODE.Rows(0).Item("SGSTPER"))
                                    IGSTPER = 0
                                    GRIDBILL.Rows.Add(0, dr("item"), HSNCODE, dr("quality"), dr("color"), dr("Qty").ToString, dr("Qtyunit"), Val(dr("Qty")), 0, "Mtrs", 0, 0, 0, 0, 0, 0, 0, CGSTPER, 0, SGSTPER, 0, 0, 0, 0, dr("GrNNO"), dr("GrNGRIDSRNO"), 0)
                                Else
                                    CGSTPER = 0
                                    SGSTPER = 0
                                    IGSTPER = Val(DTCODE.Rows(0).Item("IGSTPER"))
                                    GRIDBILL.Rows.Add(0, dr("item"), HSNCODE, dr("quality"), dr("color"), dr("Qty").ToString, dr("Qtyunit"), Val(dr("Qty")), 0, "Mtrs", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, IGSTPER, 0, 0, dr("GrNNO"), dr("GrNGRIDSRNO"), 0)
                                End If
                                TXTCGSTPER1.Text = 0
                                TXTSGSTPER1.Text = 0
                                TXTIGSTPER1.Text = 0
                            Else
                                GRIDBILL.Rows.Add(0, dr("item"), HSNCODE, dr("quality"), dr("color"), dr("Qty").ToString, dr("Qtyunit"), Val(dr("Qty")), 0, "Mtrs", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dr("GrNNO"), dr("GrNGRIDSRNO"), 0)
                                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                    TXTCGSTPER1.Text = CGSTPER
                                    TXTSGSTPER1.Text = SGSTPER
                                    TXTIGSTPER1.Text = 0
                                Else
                                    TXTCGSTPER1.Text = 0
                                    TXTSGSTPER1.Text = 0
                                    TXTIGSTPER1.Text = IGSTPER
                                End If
                            End If
                        End If

                    Else
                        GRIDBILL.Rows.Add(0, dr("item"), "", dr("quality"), dr("color"), dr("Qty").ToString, dr("Qtyunit"), Val(dr("Qty")), 0, "Mtrs", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dr("GrNNO"), dr("GrNGRIDSRNO"), 0)
                    End If

                Next


                getsrno(GRIDBILL)
                total()
                GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1
                If GRIDBILL.RowCount > 0 Then
                    GRIDBILL.Focus()
                    GRIDBILL.CurrentCell = GRIDBILL.Rows(0).Cells(GRATE.Index)
                End If


            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
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
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmax_BILL_no()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Validated
        Try
            'GET DEFAUKLT SCREENTYPE
            If EDIT = False And cmbregister.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(DTYPE_PURSCREENTYPE,'GOODS PURCHASE') AS SERVICETYPE", "", " DEFAULTPURSCREENTYPE INNER JOIN REGISTERMASTER ON DTYPE_PURREGID = REGISTER_ID ", " AND REGISTER_NAME = '" & cmbregister.Text & "' AND DTYPE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBSERVICETYPE.Text = DT.Rows(0).Item("SERVICETYPE")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURregabbr = dt.Rows(0).Item(0).ToString
                    PURreginitial = dt.Rows(0).Item(1).ToString
                    PURregid = dt.Rows(0).Item(2)
                    getmax_BILL_no()
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

    Private Sub gridinv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDBILL.CellValidating
        Dim colNum As Integer = GRIDBILL.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case GRATE.Index, gQty.Index, GMTRS.Index, GDISCAMT.Index, GDISCPER.Index, GSPDISCPER.Index, GSPDISCAMT.Index, GOTHERAMT.Index, GCGSTAMT.Index, GSGSTAMT.Index, GIGSTAMT.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDBILL.CurrentCell.Value = Nothing Then GRIDBILL.CurrentCell.Value = "0.00"
                    GRIDBILL.CurrentCell.Value = Convert.ToDecimal(GRIDBILL.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    total()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If

        End Select


        'If EDIT = False Then
        '    For I As Integer = GRIDBILL.CurrentRow.Index + 1 To GRIDBILL.RowCount - 1
        '        If Val(GRIDBILL.Item(GRATE.Index, I).Value) = 0 Then
        '            GRIDBILL.Item(GRATE.Index, I).Value = GRIDBILL.Item(GRATE.Index, I - 1).EditedFormattedValue
        '            GRIDBILL.Item(GPER.Index, I).Value = GRIDBILL.Item(GPER.Index, I - 1).EditedFormattedValue
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORT.Enter
        Try
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT' ")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORT.Validating
        Try
            If CMBTRANSPORT.Text.Trim <> "" Then namevalidate(CMBTRANSPORT, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDBILL.RowCount = 0

                TEMPBILLNO = Val(tstxtbillno.Text)
                TEMPREGNAME = cmbregister.Text.Trim
                If TEMPBILLNO > 0 Then
                    EDIT = True
                    PurchaseMaster_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then FILLTAXNAME(cmbtax, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbaddtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaddtax.GotFocus
        Try
            If cmbaddtax.Text.Trim = "" Then FILLTAXNAME(cmbaddtax, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbaddtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbaddtax.Validating
        Try
            If cmbaddtax.Text.Trim <> "" Then TAXvalidate(cmbaddtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmboctroi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboctroi.GotFocus
        Try
            If cmboctroi.Text.Trim = "" Then fillOCTROI(cmboctroi, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmboctroi_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmboctroi.Validating
        Try
            If cmboctroi.Text.Trim <> "" Then OCTROIvalidate(cmboctroi, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkexcise_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkexcise.CheckedChanged
        If chkexcise.Checked = True Then
            TXTEXCISE.ReadOnly = False
            txtexciseAMT.ReadOnly = True
            TXTEDUCESS.ReadOnly = False
            txteducessAMT.ReadOnly = True
            TXTHSECESS.ReadOnly = False
            txthsecessAMT.ReadOnly = True
            'getexcise()

        Else
            TXTEXCISE.Text = 0.0
            txtexciseAMT.Text = 0.0
            TXTEDUCESS.Text = 0.0
            txteducessAMT.Text = 0.0
            TXTHSECESS.Text = 0.0
            txthsecessAMT.Text = 0.0
            txtinwordedu.Text = "NIL"
            txtinwordhse.Text = "NIL"
            txtinwordexcise.Text = "NIL"
            TXTEXCISEID.Text = 0
        End If
        total()
    End Sub

    Private Sub txtinspchgs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinspchgs.Validated, txtpfper.Validated, txttestchgs.Validated, txtdisamt.Validated, txtfreight.Validated, txtexciseAMT.Validating, txtdisper.Validated, txtfrper.Validated, txtsubtotal.Validated, txtnett.Validated, TXTHSECESS.Validated, txthsecessAMT.Validated, txtpfamt.Validating, TXTEXCISE.Validating, TXTEDUCESS.Validating, TXTHSECESS.Validating
        total()
    End Sub

    Private Sub txtdisper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdisper.KeyPress, txtpfper.KeyPress, txtfrper.KeyPress, TXTEXCISE.KeyPress, TXTEDUCESS.KeyPress, TXTHSECESS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDBILL.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDBILL.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEM.Text.Trim, TXTHSNCODE.Text.Trim, cmbquality.Text.Trim, cmbcolor.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBQTYUNIT.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.0000"), CMBPER.Text.Trim, Format(Val(TXTAMT.Text.Trim), "0.0000"), Format(Val(TXTDISCPER.Text.Trim), "0.00"), Format(Val(TXTDISCAMT.Text.Trim), "0.00"), Format(Val(TXTSPDISCPER.Text.Trim), "0.00"), Format(Val(TXTSPDISCAMT.Text.Trim), "0.00"), Format(Val(TXTOTHERAMT.Text.Trim), "0.00"), Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00"), Format(Val(TXTCGSTPER.Text.Trim), "0.00"), Format(Val(TXTCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTSGSTPER.Text.Trim), "0.00"), Format(Val(TXTSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTIGSTPER.Text.Trim), "0.00"), Format(Val(TXTIGSTAMT.Text.Trim), "0.00"), Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00"), 0, 0, 0)
            getsrno(GRIDBILL)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDBILL.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDBILL.Item(gitemname.Index, TEMPROW).Value = CMBITEM.Text.Trim
            GRIDBILL.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim
            GRIDBILL.Item(GQUALITY.Index, TEMPROW).Value = cmbquality.Text.Trim
            GRIDBILL.Item(gcolor.Index, TEMPROW).Value = cmbcolor.Text.Trim
            GRIDBILL.Item(gQty.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
            GRIDBILL.Item(gqtyunit.Index, TEMPROW).Value = CMBQTYUNIT.Text.Trim

            GRIDBILL.Item(GMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDBILL.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.0000")
            GRIDBILL.Item(GPER.Index, TEMPROW).Value = CMBPER.Text.Trim
            GRIDBILL.Item(GAMT.Index, TEMPROW).Value = Format(Val(TXTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GDISCPER.Index, TEMPROW).Value = Format(Val(TXTDISCPER.Text.Trim), "0.00")
            GRIDBILL.Item(GDISCAMT.Index, TEMPROW).Value = Format(Val(TXTDISCAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GSPDISCPER.Index, TEMPROW).Value = Format(Val(TXTSPDISCPER.Text.Trim), "0.00")
            GRIDBILL.Item(GSPDISCAMT.Index, TEMPROW).Value = Format(Val(TXTSPDISCAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GOTHERAMT.Index, TEMPROW).Value = Format(Val(TXTOTHERAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GTAXABLEAMT.Index, TEMPROW).Value = Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GCGSTPER.Index, TEMPROW).Value = Format(Val(TXTCGSTPER.Text.Trim), "0.00")
            GRIDBILL.Item(GCGSTAMT.Index, TEMPROW).Value = Format(Val(TXTCGSTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GSGSTPER.Index, TEMPROW).Value = Format(Val(TXTSGSTPER.Text.Trim), "0.00")
            GRIDBILL.Item(GSGSTAMT.Index, TEMPROW).Value = Format(Val(TXTSGSTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GIGSTPER.Index, TEMPROW).Value = Format(Val(TXTIGSTPER.Text.Trim), "0.00")
            GRIDBILL.Item(GIGSTAMT.Index, TEMPROW).Value = Format(Val(TXTIGSTAMT.Text.Trim), "0.00")
            GRIDBILL.Item(GGRIDTOTAL.Index, TEMPROW).Value = Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00")


            GRIDDOUBLECLICK = False

        End If
        If ClientName <> "SKF" Then TXTAMT.ReadOnly = True
        total()
        GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1

        TXTSRNO.Text = GRIDBILL.RowCount + 1
        TXTQTY.Clear()

        TXTMTRS.Clear()
        TXTRATE.Clear()
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

        CMBITEM.Focus()

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
        total()
        TXTCHGSPER.ReadOnly = False
        GRIDCHGS.FirstDisplayedScrollingRowIndex = GRIDCHGS.RowCount - 1

        TXTCHGSSRNO.Text = Val(GRIDCHGS.RowCount - 1) + 1
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTTAXID.Clear()

        If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False

        CMBCHARGES.Focus()
    End Sub

    Sub EDITROW()
        Try
            If GRIDBILL.CurrentRow.Index >= 0 And GRIDBILL.Item(gsrno.Index, GRIDBILL.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDBILL.Item(gsrno.Index, GRIDBILL.CurrentRow.Index).Value)
                CMBITEM.Text = GRIDBILL.Item(gitemname.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDBILL.Item(GHSNCODE.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                cmbquality.Text = GRIDBILL.Item(GQUALITY.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDBILL.Item(gcolor.Index, GRIDBILL.CurrentRow.Index).Value.ToString

                TXTQTY.Text = Val(GRIDBILL.Item(gQty.Index, GRIDBILL.CurrentRow.Index).Value)
                CMBQTYUNIT.Text = GRIDBILL.Item(gqtyunit.Index, GRIDBILL.CurrentRow.Index).Value.ToString

                TXTMTRS.Text = Val(GRIDBILL.Item(GMTRS.Index, GRIDBILL.CurrentRow.Index).Value)

                TXTRATE.Text = Val(GRIDBILL.Item(GRATE.Index, GRIDBILL.CurrentRow.Index).Value)
                CMBPER.Text = GRIDBILL.Item(GPER.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTAMT.Text = Val(GRIDBILL.Item(GAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTDISCPER.Text = Val(GRIDBILL.Item(GDISCPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTDISCAMT.Text = Val(GRIDBILL.Item(GDISCAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSPDISCPER.Text = Val(GRIDBILL.Item(GSPDISCPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSPDISCAMT.Text = Val(GRIDBILL.Item(GSPDISCAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTOTHERAMT.Text = Val(GRIDBILL.Item(GOTHERAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTTAXABLEAMT.Text = Val(GRIDBILL.Item(GTAXABLEAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTCGSTPER.Text = Val(GRIDBILL.Item(GCGSTPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTCGSTAMT.Text = Val(GRIDBILL.Item(GCGSTAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSGSTPER.Text = Val(GRIDBILL.Item(GSGSTPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTSGSTAMT.Text = Val(GRIDBILL.Item(GSGSTAMT.Index, GRIDBILL.CurrentRow.Index).Value)

                TXTIGSTPER.Text = Val(GRIDBILL.Item(GIGSTPER.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTIGSTAMT.Text = Val(GRIDBILL.Item(GIGSTAMT.Index, GRIDBILL.CurrentRow.Index).Value)
                TXTGRIDTOTAL.Text = Val(GRIDBILL.Item(GGRIDTOTAL.Index, GRIDBILL.CurrentRow.Index).Value)

                TEMPROW = GRIDBILL.CurrentRow.Index
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBILL.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub GRIDBILL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDBILL.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDBILL.Rows.RemoveAt(GRIDBILL.CurrentRow.Index)
                getsrno(GRIDBILL)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDBILL.RowCount > 0 Then
                If GRIDBILL.CurrentRow.Cells(gitemname.Index).Value <> "" Then GRIDBILL.Rows.Add(CloneWithValues(GRIDBILL.CurrentRow))
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub TXTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated, TXTMTRS.Validated, TXTQTY.Validated, CMBPER.Validated, TXTDISCPER.Validated, TXTDISCAMT.Validated, TXTSPDISCAMT.Validated, TXTSPDISCPER.Validated, TXTOTHERAMT.Validated, TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        CALC()
        total()
    End Sub


    Private Sub CMBITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBITEM.Text.Trim = "" Then fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEM.Validating
        Try
            If CMBITEM.Text.Trim <> "" Then itemvalidate(CMBITEM, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQTYUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQTYUNIT.Validating
        Try
            If CMBQTYUNIT.Text.Trim <> "" Then unitvalidate(CMBQTYUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTMTRS.KeyPress, TXTRATE.KeyPress, TXTDISCAMT.KeyPress, TXTDISCPER.KeyPress, TXTSPDISCPER.KeyPress, TXTSPDISCAMT.KeyPress, TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub


    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.SALEBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDN.Click
        Try
            'If (Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" And CMBSERVICETYPE.Text.Trim = "GOODS PURCHASE") Then
            '    MsgBox("Debit Note Cannot be Raised for This Invoice, Create Purchase Return", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            If PBPAID.Visible = True Then
                MsgBox("Pay made, Delete Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME  = '" & cmbregister.Text.Trim & "' AND REGISTER_CMPID = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    OBJdN.BILLNO = DT.Rows(0).Item("INITIALS") & "-" & Val(TXTBILLNO.Text.Trim)
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses'  or GROUPMASTER.GROUP_SECONDARY = 'Purchase A/C')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        Try
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                CMBCHARGES.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCHGS.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCHGSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDCHGS.Rows.RemoveAt(GRIDCHGS.CurrentRow.Index)
                getsrno(GRIDCHGS)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSAMT.KeyPress, TXTOTHERAMT.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSAMT, Me)
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

    Private Sub TXTCHGSAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSAMT.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSAMT.Text.Trim) <> 0 Then
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(TXTCHGSAMT.Text.Trim, dDebit)
                If bValid Then
                    TXTCHGSAMT.Text = Convert.ToDecimal(Val(TXTCHGSAMT.Text))
                    ' everything is good
                    fillchgsgrid()
                    total()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    'e.Cancel = True
                    TXTCHGSAMT.Clear()
                    'TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            Else
                If CMBCHARGES.Text.Trim = "" Then
                    MsgBox("Please Fill Charges Name ")

                ElseIf Val(TXTCHGSPER.Text.Trim) = 0 And Val(TXTCHGSAMT.Text.Trim) = 0 Then
                    MsgBox("Amount can not be zero")
                    TXTCHGSAMT.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillagentledger(CMBAGENT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPAGENT
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillcity(CMBFROMCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
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

    Private Sub CMBTOCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCITY.Validating
        Try
            If CMBTOCITY.Text.Trim <> "" Then CITYVALIDATE(CMBTOCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCRDAYS.Validated
        Try
            If Val(TXTCRDAYS.Text.Trim) > 0 Then DUEDATE.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), Convert.ToDateTime(DTPARTYBILLDATE.Text).Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTs'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
                If OBJLEDGER.TEMPAGENT <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPAGENT
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
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEM.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub calchgs()
        Try
            If Val(TXTCHGSPER.Text) <> 0 Then
                'before CALC CHECK HOW TO CALC CHARGES
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("(CASE WHEN ISNULL(ACC_CALC,'') = '' THEN 'GROSS' ELSE ACC_CALC END) AS CALC", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("CALC") = "GROSS" Then
                    TXTCHGSAMT.Text = Format((Val(txtbillamt.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "NETT" Then
                    'FIRST CALC NETT THEN ADD CHARGES ON THAT NETT TOTAL
                    txtnett.Text = Val(txtbillamt.Text.Trim)
                    For Each ROW As DataGridViewRow In GRIDCHGS.Rows
                        If GRIDCHGSDOUBLECLICK = True And ROW.Index >= TEMPCHGSROW Then Exit For
                        txtnett.Text = Format(Val(txtnett.Text) + Val(ROW.Cells(EAMT.Index).Value), "0.00")
                    Next
                    TXTCHGSAMT.Text = Format((Val(txtnett.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "QTY" Then
                    TXTCHGSAMT.Text = Format((Val(lbltotalqty.Text) * Val(TXTCHGSPER.Text)), "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "MTRS" Then
                    TXTCHGSAMT.Text = Format((Val(lbltotalmtrs.Text) * Val(TXTCHGSPER.Text)), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
            calchgs()
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

    Private Sub CMBCHARGES_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Validated
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

    Private Sub PurchaseMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        PURCHASESCREENTYPE = CMBSCREENTYPE.Text
        CMBSERVICETYPE.Enabled = True
        CMBSERVICETYPE.SelectedIndex = 0
        HIDEVIEW()

        If ClientName = "TULSI" Then CHKBILLDISPUTE.Text = "Bill Checked By Boss"
    End Sub


    Private Sub TXTPARTYBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPARTYBILLNO.Validating
        Try
            If TXTPARTYBILLNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" BILL_INITIALS AS BILLNO", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND BILL_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Party Bill No Already Exists in Entry No " & DT.Rows(0).Item("BILLNO"))
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCHARGES.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBCHARGES.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTPARTYBILLDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPARTYBILLDATE.GotFocus
        DTPARTYBILLDATE.SelectAll()
    End Sub

    Private Sub DTPARTYBILLDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTPARTYBILLDATE.Validating
        Try
            If DTPARTYBILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTPARTYBILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                    If EDIT = False Then DUEDATE.Value = DTPARTYBILLDATE.Text
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BILLDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BILLDATE.GotFocus
        BILLDATE.SelectAll()
    End Sub

    Private Sub BILLDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BILLDATE.Validating
        Try
            If BILLDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(BILLDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                Else
                    If Val(TXTCRDAYS.Text) = 0 Then DUEDATE.Text = BILLDATE.Text
                    'SAME DATE FOR CHALLANDATE / LRDATE 
                    If ClientName = "DAKSH" Or ClientName = "SHALIBHADRA" Or ClientName = "SAFFRONOFF" Or ClientName = "SAFFRON" Then
                        DTPARTYBILLDATE.Text = BILLDATE.Text
                        lrdate.Value = Convert.ToDateTime(BILLDATE.Text).Date
                        CHALLANDATE.Value = Convert.ToDateTime(BILLDATE.Text).Date
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEM.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOTHERAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOTHERAMT.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGRIDTOTAL.Validating
        'If ClientName = "SKF" And Val(TXTAMT.Text.Trim) > 0 Then
        'GET RATE AUTO IF RATE IS NOT PRESENT
        If CMBPER.Text = "Mtrs" Then TXTRATE.Text = Format(Val(TXTAMT.Text.Trim) / Val(TXTMTRS.Text.Trim), "0.00") Else TXTRATE.Text = Format(Val(TXTAMT.Text.Trim) / Val(TXTQTY.Text.Trim), "0.00")
        'End If

        If CMBITEM.Text.Trim <> "" And Val(TXTQTY.Text.Trim) <> 0 And CMBQTYUNIT.Text.Trim <> "" And Val(TXTMTRS.Text.Trim) <> 0 And Val(TXTRATE.Text.Trim) <> 0 And CMBPER.Text.Trim <> "" And Val(TXTAMT.Text.Trim) <> 0 And Val(TXTTAXABLEAMT.Text.Trim) <> 0 And Val(TXTGRIDTOTAL.Text.Trim) <> 0 Then
            fillgrid()
            total()
        Else
            If CMBITEM.Text.Trim = "" Then
                MsgBox("Please Fill Item Name ")
                CMBITEM.Focus()
                Exit Sub
            End If

            If Val(TXTQTY.Text.Trim) = 0 Then
                MsgBox("Please Fill Quantity ")
                TXTQTY.Focus()
                Exit Sub
            End If
            If CMBQTYUNIT.Text.Trim = "" Then
                MsgBox("Please Fill Quantity Unit ")
                CMBQTYUNIT.Focus()
                Exit Sub
            End If
            If TXTMTRS.Text.Trim = "" Then
                MsgBox("Please Fill Mtrs ")
                TXTMTRS.Focus()
                Exit Sub
            End If
            If Val(TXTRATE.Text.Trim) <= 0 Then
                MsgBox("Please Fill Rate")
                TXTRATE.Focus()
                Exit Sub
            End If
            If CMBPER.Text.Trim = "" Then
                MsgBox("Please Fill Per ")
                CMBPER.Focus()
                Exit Sub
            End If

        End If

    End Sub

    Sub HIDEVIEW()
        Try
            If CMBSERVICETYPE.Text = "GOODS PURCHASE" Then
                CMBSACDESC.Visible = False
                LBLSACDESC.Visible = False
                LBLSACCODE.Visible = False
                TXTSACCODE.Visible = False
                TXTOTHERAMT.Visible = True
                GOTHERAMT.Visible = True
                LBLTOTALOTHERAMT.Visible = True
            Else
                CMBSACDESC.Visible = True
                LBLSACDESC.Visible = True
                LBLSACCODE.Visible = True
                TXTSACCODE.Visible = True
            End If


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

                GRIDBILL.Width = 1660

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
                GRIDBILL.Width = 740
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

    Private Sub CMBSERVICETYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSERVICETYPE.Validated
        Try
            HIDEVIEW()
            CMBSERVICETYPE.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon

                TXTCGSTAMT1.ReadOnly = False
                TXTCGSTAMT1.TabStop = True
                TXTCGSTAMT1.BackColor = Color.LemonChiffon
                TXTSGSTAMT1.ReadOnly = False
                TXTSGSTAMT1.TabStop = True
                TXTSGSTAMT1.BackColor = Color.LemonChiffon
                TXTIGSTAMT1.ReadOnly = False
                TXTIGSTAMT1.TabStop = True
                TXTIGSTAMT1.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen

                TXTCGSTAMT1.ReadOnly = True
                TXTCGSTAMT1.TabStop = False
                TXTCGSTAMT1.BackColor = Color.Linen
                TXTSGSTAMT1.ReadOnly = True
                TXTSGSTAMT1.TabStop = False
                TXTSGSTAMT1.BackColor = Color.Linen
                TXTIGSTAMT1.ReadOnly = True
                TXTIGSTAMT1.TabStop = False
                TXTIGSTAMT1.BackColor = Color.Linen
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSACDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSACDESC.Validated
        Try
            If CMBSACDESC.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBSACDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then TXTSACCODE.Text = DT.Rows(0).Item("HSNCODE")
                CMBSACDESC.Enabled = False
                GETHSNCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            If DTPARTYBILLDATE.Text = "__/__/____" Then Exit Sub

            If Convert.ToDateTime(DTPARTYBILLDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If CMBSERVICETYPE.Text = "GOODS PURCHASE" Then
                    DT = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & CMBITEM.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                Else
                    DT = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSN_CODE= '" & TXTSACCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                End If
                If DT.Rows.Count > 0 Then
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBSCREENTYPE.Text.Trim = "LINE GST" Then

                        TXTCGSTPER.Clear()
                        TXTCGSTAMT.Clear()
                        TXTSGSTPER.Clear()
                        TXTSGSTAMT.Clear()
                        TXTIGSTPER.Clear()
                        TXTIGSTAMT.Clear()


                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    Else
                        TXTCGSTPER1.Clear()
                        TXTCGSTAMT1.Clear()
                        TXTSGSTPER1.Clear()
                        TXTSGSTAMT1.Clear()
                        TXTIGSTPER1.Clear()
                        TXTIGSTAMT1.Clear()

                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER1.Text = 0
                            TXTCGSTPER1.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER1.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER1.Text = 0
                            TXTSGSTPER1.Text = 0
                            TXTIGSTPER1.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If
                End If
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSCREENTYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSCREENTYPE.Validated
        Try
            PURCHASESCREENTYPE = CMBSCREENTYPE.Text
            HIDEVIEW()
            CMBSCREENTYPE.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMT.Validating
        Try
            If CMBSCREENTYPE.Text = "TOTAL GST" Then
                Call TXTGRIDTOTAL_Validating(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        numdot(e, TXTAMT, Me)
    End Sub

    Private Sub TXTCGSTAMT1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT1.Validated, TXTSGSTAMT1.Validated, TXTIGSTAMT1.Validated
        Try
            CALC()
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBILLNO.KeyPress
        numkeypress(e, TXTBILLNO, Me)
    End Sub

    Private Sub TXTBILLNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBILLNO.Validating
        Try
            If (Val(TXTBILLNO.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPBILLNO <> Val(TXTBILLNO.Text.Trim)) Then
                Dim OBJCMN As New ClsCommon
                'Dim dttable As DataTable = OBJCMN.search(" ISNULL(PAYMENTMASTER.PAYMENT_no,0)  AS PAYMENTNO", "", " REGISTERMASTER INNER JOIN PAYMENTMASTER ON REGISTERMASTER.register_id = PAYMENTMASTER.PAYMENT_registerid AND REGISTERMASTER.register_cmpid = PAYMENTMASTER.PAYMENT_cmpid AND REGISTERMASTER.register_locationid = PAYMENTMASTER.PAYMENT_locationid AND REGISTERMASTER.register_yearid = PAYMENTMASTER.PAYMENT_yearid ", "  AND PAYMENTMASTER.PAYMENT_no=" & txtjournalno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & " AND PAYMENTMASTER.PAYMENT_locationid = " & Locationid & " AND PAYMENTMASTER.PAYMENT_yearid = " & YearId)
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(PURCHASEMASTER.BILL_NO, 0) AS BILLNO ", "", " REGISTERMASTER INNER JOIN PURCHASEMASTER ON REGISTERMASTER.register_id = PURCHASEMASTER.BILL_REGISTERID AND REGISTERMASTER.register_cmpid = PURCHASEMASTER.BILL_CMPID AND REGISTERMASTER.register_yearid = PURCHASEMASTER.BILL_YEARID AND REGISTERMASTER.register_locationid = PURCHASEMASTER.BILL_LOCATIONID ", "  AND PURCHASEMASTER.BILL_NO=" & TXTBILLNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND PURCHASEMASTER.BILL_cmpid = " & CmpId & " AND PURCHASEMASTER.BILL_locationid = " & Locationid & " AND PURCHASEMASTER.BILL_yearid = " & YearId)

                If dttable.Rows.Count > 0 Then
                    MsgBox("Purchase Invoice No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class