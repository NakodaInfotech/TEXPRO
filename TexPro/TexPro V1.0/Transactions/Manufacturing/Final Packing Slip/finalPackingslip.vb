
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL
Imports System.ComponentModel

Public Class finalPackingslip

    Public Shared dt_SELECT As New DataTable

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public tempfpsno As Integer     'used for poation no while editing
    Public templotno As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public Shared SELECTMFGTABLE As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim billcopy As Boolean = False
    Dim TEMPFBNO As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        fillcmb()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()
        cmbname.Enabled = True
        cmbname.Text = ""
        tstxtbillno.Clear()
        txtcopy.Clear()
        CHKHEADER.Checked = True
        CMBFROM.Enabled = True
        CMBCOLORTYPE.Text = ""

        txtadd.Clear()
        FPSDATE.Value = Mydate
        lblbalmtrs.Text = "0.00"
        LBLBALPCS.Text = "0"
        CMBTRANS.Text = ""
        TXTLRNO.Clear()
        LRDATE.Value = Mydate
        txttransref.Clear()
        TXTTRANSREMARKS.Clear()
        txtremarks.Clear()
        TXTCODE.Clear()
        CMBJOBNO.Text = ""
        txtwidth.Clear()
        TXTORDERNO.Clear()

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""
        txtfbno.Clear()
        TXTORDERNO.Clear()
        TXTPRGNO.Clear()
        TXTCALCFOLD.Clear()


        CMBDYEING.Text = ""
        CMBFROM.Text = "WHITE FOLDING"

        CMBJOBNO.Text = ""
        CMBMERCHANT1.Text = ""
        cmbmerchant.Text = ""
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        CHKYARDS.CheckState = CheckState.Unchecked
        If ClientName = "SHUBHLAXMI" Then CMBPROCESSTYPE.Text = "PACKING" Else CMBPROCESSTYPE.Text = ""

        lbllocked.Visible = False
        PBlock.Visible = False
        CMBTRANS.Text = ""

        'clearing itemgrid textboxes and combos
        txtsrno.Clear()
        If ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI" Then
            cmbpiecetype.Text = "FRESH"
            CMBMERCHANT1.Enabled = False
        Else
            cmbpiecetype.Text = ""
        End If
        TXTDESC.Clear()
        cmbmerchant.Text = ""
        If ClientName = "SHREENATH" Then txtwidth.Text = "116" Else txtwidth.Clear()
        txtcut.Clear()
        cmbdesign.Text = ""
        cmbcolor.Text = ""
        CMBLOTNO.Text = ""
        txtpcs.Clear()
        txtbundle.Clear()
        txttotal.Clear()
        txtwt.Clear()
        txtmtrs.Clear()
        TXTMFGNO.Clear()
        TXTMFGSRNO.Clear()
        TXTQUALITY.Clear()
        TXTTYPE.Clear()
        TXTJOBNO.Clear()

        GRIDFPS.RowCount = 0
        GRIDTOTALFPS.RowCount = 0


        FPSDATE.Enabled = True
        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        getmaxno()
        GRIDCONSUMPTION.RowCount = 0


        gridhelper.RowCount = 0
        txthsrno.Clear()
        cmbdesignation.Text = ""
        txthelpers.Clear()
        txthelpername.Clear()

        If GRIDCONSUMPTION.RowCount > 0 Then
            txtsrno.Text = Val(GRIDCONSUMPTION.Rows(GRIDCONSUMPTION.RowCount - 1).Cells(GCONSUMEDSRNO.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        If gridhelper.RowCount > 0 Then
            txthsrno.Text = Val(gridhelper.Rows(gridhelper.RowCount - 1).Cells(GHSRNO.Index).Value) + 1
        Else
            txthsrno.Text = 1
        End If
        lbltotalmtrs.Text = 0
        LBLTOTALBUNDLES.Text = 0
        LBLTOTAL.Text = 0
        lbltotalpcs.Text = 0
        LBLTOTALWT.Text = 0

        If GRIDFPS.RowCount > 0 Then
            txtsrno.Text = Val(GRIDFPS.Rows(GRIDFPS.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If

        GRIDFPSSUMM.RowCount = 0

    End Sub

    Sub TOTAL()
        Try
            lbltotalpcs.Text = 0.0
            LBLTOTALBUNDLES.Text = 0.0
            LBLTOTAL.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalmtrs.Text = 0.0

            Dim DONE As Boolean = False
            Dim SUMMDONE As Boolean = False
            GRIDTOTALFPS.RowCount = 0
            GRIDFPSSUMM.RowCount = 0

            For Each ROW As DataGridViewRow In GRIDFPS.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    ROW.Cells(GTOTALPCS.Index).Value = Format(Val(ROW.Cells(gpcs.Index).EditedFormattedValue) * Val(ROW.Cells(GBUNDLE.Index).EditedFormattedValue), "0.00")
                    If Val(ROW.Cells(GCUT.Index).Value) <> 0 Then
                        If ClientName = "MONOGRAM" And CHKYARDS.CheckState = CheckState.Checked Then
                            If Val(TXTCALCFOLD.Text.Trim) > 0 Then ROW.Cells(GTOTALMTRS.Index).Value = Format((Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue) * Val(ROW.Cells(GCUT.Index).EditedFormattedValue) * Val(ROW.Cells(gwt.Index).EditedFormattedValue)) / Val(TXTCALCFOLD.Text.Trim) * 100, "0.00") Else ROW.Cells(GTOTALMTRS.Index).Value = Format(Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue) * Val(ROW.Cells(GCUT.Index).EditedFormattedValue) * Val(ROW.Cells(gwt.Index).EditedFormattedValue), "0.00")
                        Else
                            ROW.Cells(GTOTALMTRS.Index).Value = Format(Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue) * Val(ROW.Cells(GCUT.Index).EditedFormattedValue), "0.00")
                        End If
                    End If
                    lbltotalpcs.Text = Format(Val(lbltotalpcs.Text) + Val(ROW.Cells(gpcs.Index).Value), "0.00")
                    LBLTOTALBUNDLES.Text = Format(Val(LBLTOTALBUNDLES.Text) + Val(ROW.Cells(GBUNDLE.Index).Value), "0.00")
                    LBLTOTAL.Text = Format(Val(LBLTOTAL.Text) + Val(ROW.Cells(GTOTALPCS.Index).Value), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(gwt.Index).Value), "0.00")
                    lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(ROW.Cells(GTOTALMTRS.Index).Value), "0.00")

                    'DONE BY GULKIT DO NOT REMOVE STRICTLY
                    '********************************************
                    If CMBFROM.Text.Trim = "FINAL CUTTING" Then ROW.Cells(GLOTNO.Index).Value = 0

                    DONE = False
                    If GRIDTOTALFPS.RowCount = 0 Then
                        GRIDTOTALFPS.Rows.Add(ROW.Cells(GMFGNO.Index).EditedFormattedValue, ROW.Cells(gpiecetype.Index).EditedFormattedValue, ROW.Cells(GLOTNO.Index).EditedFormattedValue, ROW.Cells(GTOTALPCS.Index).EditedFormattedValue, ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue, ROW.Cells(GTYPE.Index).EditedFormattedValue)
                    Else
                        For Each DESCROW As DataGridViewRow In GRIDTOTALFPS.Rows
                            If DESCROW.Cells(DESCMFGNO.Index).Value = ROW.Cells(GMFGNO.Index).EditedFormattedValue And DESCROW.Cells(DESCPIECETYPE.Index).Value = ROW.Cells(gpiecetype.Index).EditedFormattedValue And DESCROW.Cells(DESCLOTNO.Index).Value = ROW.Cells(GLOTNO.Index).EditedFormattedValue Then
                                DESCROW.Cells(DESCTOTAL.Index).Value = Val(DESCROW.Cells(DESCTOTAL.Index).Value) + Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue)
                                DESCROW.Cells(DESCMTRS.Index).Value = Val(DESCROW.Cells(DESCMTRS.Index).Value) + Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue)
                                DESCROW.Cells(TYPE.Index).Value = ROW.Cells(GTYPE.Index).EditedFormattedValue
                                DONE = True
                            End If
                        Next
                        If DONE = False Then GRIDTOTALFPS.Rows.Add(ROW.Cells(GMFGNO.Index).EditedFormattedValue, ROW.Cells(gpiecetype.Index).EditedFormattedValue, ROW.Cells(GLOTNO.Index).EditedFormattedValue, ROW.Cells(GTOTALPCS.Index).EditedFormattedValue, ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue, ROW.Cells(GTYPE.Index).EditedFormattedValue)
                    End If



                    SUMMDONE = False
                    If GRIDFPSSUMM.RowCount = 0 Then
                        GRIDFPSSUMM.Rows.Add(ROW.Cells(gpiecetype.Index).EditedFormattedValue, ROW.Cells(GMERCHANT.Index).EditedFormattedValue, ROW.Cells(GTOTALPCS.Index).EditedFormattedValue, ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue)
                    Else
                        For Each SUMMROW As DataGridViewRow In GRIDFPSSUMM.Rows
                            If SUMMROW.Cells(SPIECETYPE.Index).Value = ROW.Cells(gpiecetype.Index).EditedFormattedValue And SUMMROW.Cells(SMERCHANT.Index).Value = ROW.Cells(GMERCHANT.Index).EditedFormattedValue Then
                                SUMMROW.Cells(SPCS.Index).Value = Val(SUMMROW.Cells(SPCS.Index).Value) + Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue)
                                SUMMROW.Cells(SMTRS.Index).Value = Val(SUMMROW.Cells(SMTRS.Index).Value) + Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue)
                                SUMMDONE = True
                            End If
                        Next
                        If SUMMDONE = False Then GRIDFPSSUMM.Rows.Add(ROW.Cells(gpiecetype.Index).EditedFormattedValue, ROW.Cells(GMERCHANT.Index).EditedFormattedValue, ROW.Cells(GTOTALPCS.Index).EditedFormattedValue, ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue)
                    End If

                    '********************************************
                    '********************************************

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbname.Focus()
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FPSDATE.Validating
        If Not datecheck(FPSDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(FPS_no),0) + 1 ", "FINALPACKINGSLIP", " AND FPS_cmpid=" & CmpId & " and FPS_locationid=" & Locationid & " and FPS_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTFPSNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If

            If CMBDYEING.Text.Trim = "" And CMBCOLORTYPE.Text.Trim <> "" Then CMBCOLORTYPE.Text = ""
            If CMBCOLORTYPE.Text.Trim = "" And ClientName = "DHANLAXMI" And CMBDYEING.Text.Trim <> "" Then
                EP.SetError(CMBCOLORTYPE, " Please Fill Color Type")
                bln = False
            End If

            If CMBMERCHANT1.Text.Trim.Length = 0 Then
                EP.SetError(CMBMERCHANT1, "Please Merchant Name")
                bln = False
            End If

            Dim OBJCMN As New ClsCommon
            Dim dt As New DataTable
            If edit = False Then
                dt = OBJCMN.search(" FPS_NO ", "", " FINALPACKINGSLIP ", "  and FPS_NO=" & Val(TXTFPSNO.Text) & " and FPS_cmpid=" & CmpId & " and FPS_locationid= " & Locationid & " and FPS_yearid= " & YearId)
                If dt.Rows.Count > 0 Then
                    EP.SetError(TXTFPSNO, "Bale No. Already exist?")
                    bln = False
                End If
            End If

            'CHECKING STOCK 
            'DONE BY GULKIT DO NOT CHANGE STRICTLY
            TOTAL()
            If ClientName = "TULSI" Or ClientName = "SHREENATH" Or ClientName = "DHANLAXMI" Then
                For Each ROW As DataGridViewRow In GRIDTOTALFPS.Rows
                    If ROW.Cells(gpiecetype.Index).Value = "GOOD CUT" Then GoTo LINE2
                    If CMBFROM.Text.Trim = "FINAL CUTTING" Then
                        'IF WE HAVE MANUALLY ENTERED DATA HERE THEN WE NEED ANOTHER CODE
                        If Val(ROW.Cells(DESCMFGNO.Index).Value) > 0 Then dt = OBJCMN.search(" ISNULL(SUM(FCP_SAREE - FCP_OUTSAREE ),0) AS ALLOWEDSAREE, ISNULL(SUM(FCP_MTRS - (FCP_CUT*FCP_OUTSAREE)),0) AS ALLOWEDMTRS ", "", " FINALCUTTINGPROCESS_PCSDESC INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = PIECETYPEMASTER.PIECETYPE_yearid  ", " AND FCP_NO = " & ROW.Cells(DESCMFGNO.Index).Value & " AND PIECETYPE_NAME = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND FCP_CMPID = " & CmpId & " AND FCP_LOCATIONID = " & Locationid & " AND FCP_YEARID  = " & YearId) Else dt = OBJCMN.search(" ISNULL(SUM(FCP_SAREE - FCP_OUTSAREE ),0) AS ALLOWEDSAREE, ISNULL(SUM(FCP_MTRS - (FCP_CUT*FCP_OUTSAREE)),0) AS ALLOWEDMTRS ", "", " FINALCUTTINGPROCESS_PCSDESC INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = PIECETYPEMASTER.PIECETYPE_yearid  ", " AND PIECETYPE_NAME = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND FCP_YEARID  = " & YearId)
                    ElseIf CMBFROM.Text = "WHITE FOLDING" Then
                        Dim WHERE As String = ""
                        If Val(ROW.Cells(DESCLOTNO.Index).Value) <> 0 Then WHERE = " AND LOTNO = " & Val(ROW.Cells(DESCLOTNO.Index).Value)


                        If ROW.Cells(TYPE.Index).Value = "PROCESS" Then
                            dt = OBJCMN.Execute_Any_String(" SELECT ISNULL(ROUND(sum(RECDMTRS),2),0) AS ALLOWEDMTRS FROM PACKINGSLIPVIEW WHERE PROCESSNAME = '" & CMBFROM.Text.Trim & "'  " & WHERE & " AND YEARID  = " & YearId, "", "")
                        Else
                            If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                                dt = OBJCMN.Execute_Any_String(" SELECT ISNULL(ROUND(sum(RECDMTRS) - SUM(OUTMTRS),2),0) AS ALLOWEDMTRS FROM PACKINGSLIPVIEW WHERE PROCESSNAME = '" & CMBFROM.Text.Trim & "' " & WHERE & " AND LOCATIONID = 0 AND YEARID  = " & YearId, "", "")
                            Else
                                dt = OBJCMN.Execute_Any_String(" SELECT isnull(sum(mtrs),0) AS ALLOWEDMTRS, isnull(sum(PCS),0) AS PCS  FROM VIEW_SUMMARY_MFG1 WHERE YEARID  = " & YearId & WHERE, "", "")
                            End If
                        End If
                    Else
                        'GET DATA FROM PACKINGSLIPVIEW FOR LOOSE STOCK
                        Dim WHERE As String = " AND PACKINGSLIPVIEW.GRNTYPE = 'LOOSE'"
                        WHERE = WHERE & " AND PIECETYPE = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "'"
                        dt = OBJCMN.Execute_Any_String(" SELECT ISNULL(ROUND(sum(RECDMTRS) - SUM(OUTMTRS),2),0) AS ALLOWEDMTRS FROM PACKINGSLIPVIEW WHERE PROCESSNAME = '" & CMBFROM.Text.Trim & "' " & " AND YEARID  = " & YearId & WHERE, "", "")
                    End If
                    If dt.Rows.Count > 0 Then
                        If edit = False Then
                            If Val(dt.Rows(0).Item("ALLOWEDMTRS")) <= 0 Then GoTo LINE1
                            If CMBFROM.Text.Trim = "FINAL CUTTING" Then
                                If Val(ROW.Cells(DESCTOTAL.Index).Value) > Val(dt.Rows(0).Item("ALLOWEDSAREE")) Then
                                    EP.SetError(CMBMERCHANT1, "Sarees in Cutting No " & ROW.Cells(DESCMFGNO.Index).Value & " Exceeds Stock, Max " & dt.Rows(0).Item("ALLOWEDSAREE") & " Allowed")
                                    bln = False
                                End If
                            Else
                                If Val(ROW.Cells(DESCMTRS.Index).Value) > Val(dt.Rows(0).Item("ALLOWEDMTRS")) And (ClientName = "TULSI" Or ClientName = "SHREENATH") Then
                                    EP.SetError(CMBMERCHANT1, "Mtrs in Mfg No " & ROW.Cells(DESCMFGNO.Index).Value & " Exceeds Stock, Max " & dt.Rows(0).Item("ALLOWEDMTRS") & " Allowed")
                                    bln = False
                                End If
                            End If
                        End If
                    Else
LINE1:
                        EP.SetError(CMBMERCHANT1, "Item in Mfg/Cutting No " & ROW.Cells(DESCMFGNO.Index).Value & " not present in Stock")
                        bln = False
                    End If
LINE2:
                Next
            End If


            'VALIDATE STOCK ON PCS
            'THIS IS DONE TEMP
            If ClientName = "SHUBHLAXMI" Then
                For Each ROW As DataGridViewRow In GRIDTOTALFPS.Rows
                    If ROW.Cells(gpiecetype.Index).Value <> "FRESH" Then GoTo LINE4

                    Dim WHERE As String = ""
                    If ROW.Cells(DESCLOTNO.Index).Value <> "" Then WHERE = " AND LOTNO = " & Val(ROW.Cells(DESCLOTNO.Index).Value)
                    dt = OBJCMN.Execute_Any_String(" SELECT ISNULL(sum(RECDPCS) - SUM(OUTPCS),0) AS ALLOWEDPCS FROM PACKINGSLIPVIEW WHERE PROCESSNAME = '" & CMBFROM.Text.Trim & "'  " & WHERE & " AND PIECETYPE = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND YEARID  = " & YearId, "", "")
                    If dt.Rows.Count > 0 Then
                        If edit = False Then
                            If Val(dt.Rows(0).Item("ALLOWEDPCS")) = 0 Then GoTo LINE3
                            If Val(ROW.Cells(DESCTOTAL.Index).Value) > Val(dt.Rows(0).Item("ALLOWEDPCS")) Then
                                EP.SetError(CMBMERCHANT1, "Pcs in Lot No " & ROW.Cells(DESCLOTNO.Index).Value & " Exceeds Stock, Max " & dt.Rows(0).Item("ALLOWEDPCS") & " Allowed")
                                bln = False
                            End If
                        End If
                    Else
LINE3:
                        EP.SetError(CMBMERCHANT1, "Item in Mfg/Cutting No " & ROW.Cells(DESCMFGNO.Index).Value & " not present in Stock")
                        bln = False
                    End If
LINE4:
                Next
            End If




            'VALIDATE STOCK ON MTRS IN LOOSE STOCK, 
            If ClientName = "DHANLAXMI" And CMBFROM.Text.Trim = "" Then
                For Each ROW As DataGridViewRow In GRIDFPSSUMM.Rows
                    Dim WHERE As String = ""
                    dt = OBJCMN.Execute_Any_String(" SELECT ISNULL(SUM(MTRS),0) AS ALLOWEDMTRS FROM LOOSE_STOCK WHERE MERCHANT = '" & ROW.Cells(SMERCHANT.Index).Value & "' AND PIECETYPE = '" & ROW.Cells(SPIECETYPE.Index).Value & "' AND YEARID  = " & YearId, "", "")
                    If dt.Rows.Count > 0 Then
                        Dim OLDMTRS As Double = 0.0
                        If edit = True Then
                            Dim DTFPSEDIT As DataTable = OBJCMN.Execute_Any_String("SELECT SUM(FINALPACKINGSLIP_DESC.FPS_MTRS) AS MTRS AS OLDMTRS FROM FINALPACKINGSLIP_DESC INNER JOIN ITEMMASTER ON FPS_ITEMID = ITEM_ID INNER JOIN PIECETYPEMASTER ON FPS_PIECETYPEID = PIECETYPE_ID WHERE FINALPACKINGSLIP_DESC.FPS_NO = " & Val(TXTFPSNO.Text.Trim) & " AND ITEMMASTER.ITEM_NAME = '" & ROW.Cells(SMERCHANT.Index).Value & "' AND PIECETYPEMASTER.PIECETYPE_NAME = '" & ROW.Cells(SPIECETYPE.Index).Value & "' AND FINALPACKINGSLIP_DESC.FPS_YEARID = " & YearId, "", "")
                            If DTFPSEDIT.Rows.Count > 0 Then OLDMTRS = Val(DTFPSEDIT.Rows(0).Item("OLDMTRS"))
                        End If

                        If (edit = False And Val(ROW.Cells(SMTRS.Index).Value) > Val(dt.Rows(0).Item("ALLOWEDMTRS"))) Or (edit = True And Val(ROW.Cells(SMTRS.Index).Value) > (Val(dt.Rows(0).Item("ALLOWEDMTRS")) + OLDMTRS)) Then
                            EP.SetError(CMBMERCHANT1, "Mtrs Exceeds Stock, Max " & dt.Rows(0).Item("ALLOWEDMTRS") + OLDMTRS & " Allowed")
                            bln = False
                        End If
                    End If
                Next
            End If




            For Each row As DataGridViewRow In GRIDFPS.Rows
                If Val(row.Cells(GTOTALMTRS.Index).Value) = 0 Then
                    EP.SetError(lbltotalmtrs, "Mtrs cannot be zero?")
                    bln = False
                End If
            Next

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Challan Made, Delete Challan First")
                bln = False
            End If

            If GRIDFPS.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If ClientName <> "TULSI" And ClientName <> "SHREENATH" And CMBPROCESSTYPE.Text.Trim = "" Then
                EP.SetError(CMBPROCESSTYPE, "Enter Process Type")
                bln = False
            End If

            If Not datecheck(FPSDATE.Value) Then bln = False

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

            alParaval.Add(TXTFPSNO.Text)
            alParaval.Add(FPSDATE.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(TXTLRNO.Text.Trim)
            alParaval.Add(LRDATE.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(TXTTRANSREMARKS.Text.Trim)
            alParaval.Add(CMBFROM.Text.Trim)
            alParaval.Add(CMBMERCHANT1.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBCOLORTYPE.Text.Trim)


            If CHKYARDS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(CMBPROCESSTYPE.Text.Trim)


            alParaval.Add(CMBJOBNO.Text.Trim)
            alParaval.Add(TXTORDERNO.Text.Trim)
            alParaval.Add(txtfbno.Text.Trim)
            alParaval.Add(CMBDYEING.Text.Trim)
            alParaval.Add(TXTPRGNO.Text.Trim)
            alParaval.Add(txtpackedby.Text.Trim)
            alParaval.Add(Val(lbltotalpcs.Text))
            alParaval.Add(Val(LBLTOTALBUNDLES.Text))
            alParaval.Add(Val(LBLTOTAL.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(lbltotalmtrs.Text))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTCODE.Text.Trim)
            alParaval.Add(0)

            If CHKEXPENSEREPORT.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim gridremarks As String = ""
            Dim ITEMNAME As String = ""
            Dim WIDTH As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""

            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim BUNDLE As String = ""
            Dim TOTALPCS As String = ""
            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim DONE As String = ""             'WHETHER GRN IS DONE FOR THIS LINE

            Dim LOTNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim QUALITY As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim TYPE As String = ""          'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDFPS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        PIECETYPE = row.Cells(gpiecetype.Index).Value.ToString
                        If row.Cells(gdesc.Index).Value = Nothing Then row.Cells(gdesc.Index).Value = ""
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        WIDTH = row.Cells(gwidth.Index).Value
                        CUT = Val(row.Cells(GCUT.Index).Value)
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString

                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LOTNO = Val(row.Cells(GLOTNO.Index).Value)
                        PCS = Val(row.Cells(gpcs.Index).Value)
                        BUNDLE = Val(row.Cells(GBUNDLE.Index).Value)
                        TOTALPCS = Val(row.Cells(GTOTALPCS.Index).Value)
                        MTRS = Val(row.Cells(GTOTALMTRS.Index).Value)
                        WT = Val(row.Cells(gwt.Index).Value)

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        MFGSRNO = Val(row.Cells(GMFGSRNO.Index).Value)
                        MFGNO = Val(row.Cells(GMFGNO.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        TYPE = row.Cells(GTYPE.Index).Value.ToString


                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        PIECETYPE = PIECETYPE & "|" & row.Cells(gpiecetype.Index).Value.ToString
                        If row.Cells(gdesc.Index).Value = Nothing Then row.Cells(gdesc.Index).Value = ""
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value

                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        WIDTH = WIDTH & "|" & row.Cells(gwidth.Index).Value
                        CUT = CUT & "|" & Val(row.Cells(GCUT.Index).Value)
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString

                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        LOTNO = LOTNO & "|" & Val(row.Cells(GLOTNO.Index).Value)
                        PCS = PCS & "|" & Val(row.Cells(gpcs.Index).Value)
                        BUNDLE = BUNDLE & "|" & Val(row.Cells(GBUNDLE.Index).Value)
                        TOTALPCS = TOTALPCS & "|" & Val(row.Cells(GTOTALPCS.Index).Value)

                        MTRS = MTRS & "|" & Val(row.Cells(GTOTALMTRS.Index).Value)
                        WT = WT & "|" & Val(row.Cells(gwt.Index).Value)

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        MFGNO = MFGNO & "|" & Val(row.Cells(GMFGNO.Index).Value)

                        MFGSRNO = MFGSRNO & "|" & Val(row.Cells(GMFGSRNO.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(gridremarks)
            alParaval.Add(ITEMNAME)
            alParaval.Add(WIDTH)
            alParaval.Add(CUT)
            alParaval.Add(DESIGN)

            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(PCS)
            alParaval.Add(BUNDLE)
            alParaval.Add(TOTALPCS)
            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(DONE)
            alParaval.Add(MFGNO)
            alParaval.Add(MFGSRNO)
            alParaval.Add(QUALITY)
            alParaval.Add(TYPE)

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



            Dim CONSUMEDSRNO As String = ""
            Dim ITEMNAME1 As String = ""
            Dim DEFQTY As String = ""
            Dim ACTQTY As String = ""
            Dim UNIT As String = ""
            Dim DEFRATE As String = ""
            Dim ACTRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONSUMPTION.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CONSUMEDSRNO = "" Then
                        CONSUMEDSRNO = row.Cells(GCONSUMEDSRNO.Index).Value.ToString
                        ITEMNAME1 = row.Cells(GITEMNAME.Index).Value.ToString
                        DEFQTY = row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = row.Cells(GactQty.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = row.Cells(GdefRATE.Index).Value.ToString
                        ACTRATE = row.Cells(gActRate.Index).Value.ToString

                    Else

                        CONSUMEDSRNO = CONSUMEDSRNO & "|" & row.Cells(GCONSUMEDSRNO.Index).Value
                        ITEMNAME1 = ITEMNAME1 & "|" & row.Cells(GITEMNAME.Index).Value
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        DEFQTY = DEFQTY & "|" & row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = ACTQTY & "|" & row.Cells(GactQty.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = DEFRATE & "|" & row.Cells(GdefRATE.Index).Value
                        ACTRATE = ACTRATE & "|" & row.Cells(gActRate.Index).Value

                    End If
                End If
            Next

            alParaval.Add(CONSUMEDSRNO)
            alParaval.Add(ITEMNAME1)
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

                        HSRNO = HSRNO & "|" & row.Cells(GHSRNO.Index).Value.ToString
                        DESIGNATION = DESIGNATION & "|" & row.Cells(gdesignation.Index).Value.ToString
                        HELPERS = HELPERS & "|" & row.Cells(ghelpers.Index).Value.ToString
                        HELPERNAMES = HELPERNAMES & "|" & row.Cells(gHelperName.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(HSRNO)
            alParaval.Add(DESIGNATION)
            alParaval.Add(HELPERS)
            alParaval.Add(HELPERNAMES)

            alParaval.Add(Val(TXTCALCFOLD.Text.Trim))


            Dim objclsFPS As New ClsFPS()
            objclsFPS.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsFPS.SAVE()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                'alParaval.Add(tempfpsno)

                IntResult = objclsFPS.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False




            If MsgBox("Wish to Print Packing Slip?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then serverprop()





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
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub finalPackingslip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub finalPackingslip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub FPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PACKING SLIP'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            CLEAR()

            If edit = True Or billcopy = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsFPS()
                Dim ALPARAVAL As New ArrayList

                Dim dttable As New DataTable

                ALPARAVAL.Add(tempfpsno)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCHECKING.alParaval = ALPARAVAL

                dttable = OBJCHECKING.selectFPS()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        FPSDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)

                        CMBJOBNO.Text = Convert.ToString(dr("JOBNO").ToString)
                        CMBFROM.Text = Convert.ToString(dr("PROCESS").ToString)
                        txtpackedby.Text = Convert.ToString(dr("PACKEDBY").ToString)
                        TXTORDERNO.Text = Convert.ToString(dr("ORDERNO").ToString)
                        TXTPRGNO.Text = Convert.ToString(dr("PROGNO").ToString)
                        txtfbno.Text = Convert.ToString(dr("FBNO").ToString)
                        TEMPFBNO = Convert.ToString(dr("FBNO").ToString)
                        CMBDYEING.Text = Convert.ToString(dr("DYEINGNO").ToString)
                        CMBMERCHANT1.Text = Convert.ToString(dr("ITEMNAME").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBCOLORTYPE.Text = Convert.ToString(dr("COLORTYPE").ToString)

                        CHKYARDS.Checked = Convert.ToBoolean(dr("YARDS"))
                        CMBPROCESSTYPE.Text = Convert.ToString(dr("PROCESSTYPE").ToString)

                        CMBFROM.Enabled = False

                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("transrefno").ToString
                        TXTLRNO.Text = dr("LRNO").ToString
                        LRDATE.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        TXTTRANSREMARKS.Text = dr("transremarks").ToString
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        CHKEXPENSEREPORT.Checked = Convert.ToBoolean(dr("EXPENSEREPORT"))
                        TXTCODE.Text = Convert.ToString(dr("CODE").ToString)
                        TXTCALCFOLD.Text = Val(dr("CALCFOLD"))

                        If billcopy = False Then
                            GRIDFPS.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("DESC").ToString, dr("MERCHANT"), dr("WIDTH"), Format(Val(dr("CUT")), "0.000"), dr("DESIGNNO"), dr("COLOR"), dr("LOTNO"), Format(Val(dr("PCS")), "0.00"), Format(Val(dr("BUNDLE")), "0.00"), Format(Val(dr("TOTAL")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("MTRS")), "0.00"), dr("GRIDDONE").ToString, dr("MFGNO"), dr("MFGSRNO"), dr("QUALITY"), dr("grntype"), dr("GRIDJOBNO"))
                            TXTFPSNO.Text = tempfpsno
                            If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        Else
                            If Convert.ToString(dr("PROCESS").ToString) = "FINAL CUTTING" Then
                                GRIDFPS.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("DESC").ToString, dr("ITEMNAME"), dr("WIDTH"), Format(Val(dr("CUT")), "0.000"), dr("DESIGNNO"), dr("COLOR"), dr("LOTNO"), Format(Val(dr("PCS")), "0.00"), Format(dr("BUNDLE"), "0.00"), Format(dr("TOTAL"), "0.00"), Format(Val(dr("WT")), "0.00"), Format(dr("MTRS"), "0.00"), 0, dr("MFGNO"), dr("MFGSRNO"), dr("QUALITY"), dr("grntype"), dr("GRIDJOBNO"))
                            Else
                                GRIDFPS.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("DESC").ToString, dr("MERCHANT"), dr("WIDTH"), Format(Val(dr("CUT")), "0.000"), dr("DESIGNNO"), dr("COLOR"), dr("LOTNO"), Format(Val(dr("PCS")), "0.00"), Format(dr("BUNDLE"), "0.00"), Format(dr("TOTAL"), "0.00"), Format(Val(dr("WT")), "0.00"), 0, 0, 0, 0, dr("QUALITY"), "", dr("GRIDJOBNO"))
                            End If
                        End If

                    Next
                    TOTAL()
                End If


                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" FPS_GRIDSRNO AS GRIDSRNO, FPS_REMARKS AS REMARKS, FPS_NAME AS NAME, FPS_IMGPATH AS IMGPATH, FPS_NEWIMGPATH AS NEWIMGPATH", "", " FINALPACKINGSLIP_UPLOAD", " AND FPS_NO = " & tempfpsno & " AND FPS_CMPID = " & CmpId & " AND FPS_LOCATIONID = " & Locationid & " AND FPS_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If
                dttable = OBJCMN.search("  FINALPACKINGSLIP_CONSUMED.FPS_SRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, FINALPACKINGSLIP_CONSUMED.FPS_defQTY AS defQTY, FINALPACKINGSLIP_CONSUMED.FPS_ACTQTY AS actQTY, UNITMASTER.unit_abbr AS UNIT, FINALPACKINGSLIP_CONSUMED.FPS_DEFRATE AS DEFRATE, FINALPACKINGSLIP_CONSUMED.FPS_ACTRATE AS ACTRATE", "", " FINALPACKINGSLIP_CONSUMED INNER JOIN ITEMMASTER ON FINALPACKINGSLIP_CONSUMED.FPS_ITEMID = ITEMMASTER.item_id AND FINALPACKINGSLIP_CONSUMED.FPS_CMPID = ITEMMASTER.item_cmpid AND FINALPACKINGSLIP_CONSUMED.FPS_LOCATIONID = ITEMMASTER.item_locationid AND FINALPACKINGSLIP_CONSUMED.FPS_YEARID = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON FINALPACKINGSLIP_CONSUMED.FPS_UNITID = UNITMASTER.unit_id AND FINALPACKINGSLIP_CONSUMED.FPS_CMPID = UNITMASTER.unit_cmpid AND FINALPACKINGSLIP_CONSUMED.FPS_LOCATIONID = UNITMASTER.unit_locationid AND FINALPACKINGSLIP_CONSUMED.FPS_YEARID = UNITMASTER.unit_yearid", " AND FINALPACKINGSLIP_CONSUMED.FPS_NO = " & tempfpsno & " AND FINALPACKINGSLIP_CONSUMED.FPS_CMPID = " & CmpId & " AND FINALPACKINGSLIP_CONSUMED.FPS_LOCATIONID  = " & Locationid & " AND FINALPACKINGSLIP_CONSUMED.FPS_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        GRIDCONSUMPTION.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEMNAME"), Format(DR("DEFQTY"), "0.00"), Format(DR("ACTQTY"), "0.00"), DR("UNIT"), Format(DR("DEFRATE"), "0.00"), Format(DR("ACTRATE"), "0.00"))
                    Next
                    getsrno(GRIDCONSUMPTION)
                    TOTALCONSUMPTION()
                End If
                dttable = OBJCMN.search(" FINALPACKINGSLIP_HELPERS.FPS_SRNO AS SRNO, DESIGNATIONMASTER.DESIGNATION_name AS DESIGNATION, FINALPACKINGSLIP_HELPERS.FPS_HELPERS AS HELPERS, FINALPACKINGSLIP_HELPERS.FPS_HELPERNAMES AS HELPERNAMES ", "", "  FINALPACKINGSLIP_HELPERS INNER JOIN DESIGNATIONMASTER ON FINALPACKINGSLIP_HELPERS.FPS_DESIGNATIONID = DESIGNATIONMASTER.DESIGNATION_id AND FINALPACKINGSLIP_HELPERS.FPS_CMPID = DESIGNATIONMASTER.DESIGNATION_cmpid AND FINALPACKINGSLIP_HELPERS.FPS_LOCATIONID = DESIGNATIONMASTER.DESIGNATION_locationid AND FINALPACKINGSLIP_HELPERS.FPS_YEARID = DESIGNATIONMASTER.DESIGNATION_yearid ", " AND FINALPACKINGSLIP_HELPERS.FPS_NO = " & tempfpsno & " AND FINALPACKINGSLIP_HELPERS.FPS_CMPID = " & CmpId & " AND FINALPACKINGSLIP_HELPERS.FPS_LOCATIONID  = " & Locationid & " AND FINALPACKINGSLIP_HELPERS.FPS_YEARID = " & YearId & " ORDER BY FINALPACKINGSLIP_HELPERS.FPS_SRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        gridhelper.Rows.Add(DR("SRNO").ToString, DR("DESIGNATION"), DR("HELPERS").ToString, DR("HELPERNAMES").ToString)
                    Next
                    getsrno(gridhelper)
                End If


                chkchange.CheckState = CheckState.Checked
            End If
            billcopy = False
            If GRIDFPS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDFPS.Rows(GRIDFPS.RowCount - 1).Cells(0).Value) + 1
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
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
            If cmbdesign.Text.Trim = "" Then fillDESIGN(cmbdesign, cmbmerchant.Text)
            If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)
            If cmbdesignation.Text.Trim = "" Then filldesignation(cmbdesignation)
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
            If CMBPROCESSTYPE.Text.Trim = "" Then FILLPROCESSTYPE(CMBPROCESSTYPE, edit)
            FILLGODOWN(CMBGODOWN, edit)
            If ClientName <> "TULSI" And ClientName <> "SHREENATH" And billcopy = False Then FILLLOTNO()
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

            Dim objgrndetails As New finalPackingSlipDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
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




    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmdupload.Click
        Try
            GRIDFPS.RowCount = 0
            tempfpsno = Val(tstxtbillno.Text)
            If tempfpsno > 0 Then
                edit = True
                FPS_Load(sender, e)
            Else
                clear()
                edit = False
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTFPSNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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
            GRIDFPS.RowCount = 0

            tempfpsno = Val(TXTFPSNO.Text) - 1
            If tempfpsno > 0 Then
                edit = True
                FPS_Load(sender, e)
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
            tempfpsno = Val(TXTFPSNO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTFPSNO.Text) - 1 >= tempfpsno Then
                edit = True
                FPS_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDFPS_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFPS.CellValueChanged
        If GRIDFPS.Rows.Count > 0 And CMBFROM.Text = "WHITE FOLDING" And e.RowIndex >= 0 Then
            If Convert.ToDecimal(Val(GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).Value)) > 0 Then
                templotno = Convert.ToDecimal(GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).Value)
            End If
        End If
    End Sub

    Private Sub GRIDFPS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFPS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDFPS.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDFPS.Rows.RemoveAt(GRIDFPS.CurrentRow.Index)
                getsrno(GRIDFPS)
                TOTAL()
                TOTALCONSUMPTION()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND ( GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
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

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmtrs.Validated
        Try
            If Val(txtbundle.Text.Trim) = 0 Then txtbundle.Text = 1
            If ClientName = "MONOGRAM" And CMBMERCHANT1.Text.Trim <> "" And CMBMERCHANT1.Text.Trim <> cmbmerchant.Text.Trim Then cmbmerchant.Text = CMBMERCHANT1.Text.Trim
            If cmbpiecetype.Text.Trim <> "" And cmbmerchant.Text.Trim <> "" And Val(txtpcs.Text.Trim) > 0 And Val(txtmtrs.Text.Trim) > 0 Then
                If Val(lblbalmtrs.Text) < -50 And CMBFROM.Text = "WHITE FOLDING" And ClientName <> "DHANLAXMI" Then
                    MsgBox("No Mtrs Found in this lot", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                fillgrid()
                TOTAL()
            Else
                If ClientName = "TULSI" Or ClientName = "SHREENATH" Then MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub check()

    End Sub

    Sub fillgrid()

        GRIDFPS.Enabled = True

        If gridDoubleClick = True Then
            GRIDFPS.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDFPS.Item(gpiecetype.Index, temprow).Value = cmbpiecetype.Text.Trim
            GRIDFPS.Item(gdesc.Index, temprow).Value = TXTDESC.Text.Trim
            GRIDFPS.Item(GMERCHANT.Index, temprow).Value = cmbmerchant.Text.Trim
            GRIDFPS.Item(gwidth.Index, temprow).Value = txtwidth.Text.Trim

            GRIDFPS.Item(GDESIGN.Index, temprow).Value = cmbdesign.Text.Trim

            GRIDFPS.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim
            GRIDFPS.Item(GCUT.Index, temprow).Value = txtcut.Text.Trim
            GRIDFPS.Item(GLOTNO.Index, temprow).Value = CMBLOTNO.Text.Trim
            GRIDFPS.Item(gpcs.Index, temprow).Value = Format(Val(txtpcs.Text.Trim), "0.00")
            GRIDFPS.Item(GBUNDLE.Index, temprow).Value = Format(Val(txtbundle.Text.Trim), "0.00")
            GRIDFPS.Item(GTOTALPCS.Index, temprow).Value = Format(Val(txttotal.Text.Trim), "0.00")
            GRIDFPS.Item(GTOTALMTRS.Index, temprow).Value = Format(Val(txtmtrs.Text.Trim), "0.00")
            GRIDFPS.Item(gwt.Index, temprow).Value = Format(Val(txtwt.Text.Trim), "0.00")
            GRIDFPS.Item(GQUALITY.Index, temprow).Value = TXTQUALITY.Text.Trim

            gridDoubleClick = False
        Else
            If Val(txtmtrs.Text) <> 0 Then
                GRIDFPS.Rows.Add(Val(txtsrno.Text), cmbpiecetype.Text.Trim, TXTDESC.Text.Trim, cmbmerchant.Text.Trim, txtwidth.Text.Trim, txtcut.Text.Trim, cmbdesign.Text.Trim, cmbcolor.Text.Trim, CMBLOTNO.Text.Trim, txtpcs.Text.Trim, txtbundle.Text.Trim, txttotal.Text.Trim, Val(txtwt.Text.Trim), Val(txtmtrs.Text.Trim), 0, Val(TXTMFGNO.Text), Val(TXTMFGSRNO.Text), TXTQUALITY.Text.Trim, TXTTYPE.Text.Trim, TXTJOBNO.Text.Trim)
            End If
        End If

        GRIDFPS.FirstDisplayedScrollingRowIndex = GRIDFPS.RowCount - 1
        getsrno(GRIDFPS)

        TXTDESC.Clear()
        txtsrno.Text = GRIDFPS.RowCount + 1
        txtmtrs.Clear()
        txtwt.Clear()

        If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
            cmbcolor.Text = ""
            cmbdesign.Text = ""
            txtpcs.Clear()
            txttotal.Clear()
            txtbundle.Clear()
            TXTTYPE.Clear()
            cmbpiecetype.Focus()
        ElseIf ClientName = "SHUBHLAXMI" Then
            txtmtrs.Focus()
        Else
            TXTDESC.Focus()
        End If

    End Sub

    Private Sub GRIDFPS_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFPS.CellDoubleClick
        If e.RowIndex >= 0 And GRIDFPS.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            'If Convert.ToBoolean(GRIDFPS.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
            '    MsgBox("Item Locked. First Delete from GRN")
            '    Exit Sub
            'End If


            gridDoubleClick = True
            txtsrno.Text = GRIDFPS.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbmerchant.Text = GRIDFPS.Item(GMERCHANT.Index, e.RowIndex).Value.ToString
            CMBLOTNO.Text = GRIDFPS.Item(GLOTNO.Index, e.RowIndex).Value.ToString

            cmbpiecetype.Text = GRIDFPS.Item(gpiecetype.Index, e.RowIndex).Value.ToString
            cmbdesign.Text = GRIDFPS.Item(GDESIGN.Index, e.RowIndex).Value.ToString
            If GRIDFPS.Item(gdesc.Index, e.RowIndex).Value = Nothing Then GRIDFPS.Item(gdesc.Index, e.RowIndex).Value = ""
            TXTDESC.Text = GRIDFPS.Item(gdesc.Index, e.RowIndex).Value.ToString

            cmbcolor.Text = GRIDFPS.Item(gcolor.Index, e.RowIndex).Value.ToString
            txtcut.Text = GRIDFPS.Item(GCUT.Index, e.RowIndex).Value.ToString
            txtwidth.Text = GRIDFPS.Item(gwidth.Index, e.RowIndex).Value.ToString
            txtwt.Text = GRIDFPS.Item(gwt.Index, e.RowIndex).Value.ToString
            txtpcs.Text = GRIDFPS.Item(gpcs.Index, e.RowIndex).Value.ToString
            txttotal.Text = GRIDFPS.Item(GTOTALPCS.Index, e.RowIndex).Value.ToString
            txtbundle.Text = GRIDFPS.Item(GBUNDLE.Index, e.RowIndex).Value.ToString
            txtmtrs.Text = GRIDFPS.Item(GTOTALMTRS.Index, e.RowIndex).Value.ToString
            TXTMFGNO.Text = GRIDFPS.Item(GMFGNO.Index, e.RowIndex).Value
            TXTMFGSRNO.Text = GRIDFPS.Item(GMFGSRNO.Index, e.RowIndex).Value
            TXTQUALITY.Text = GRIDFPS.Item(GQUALITY.Index, e.RowIndex).Value
            TXTTYPE.Text = GRIDFPS.Item(GTYPE.Index, e.RowIndex).Value
            TXTJOBNO.Text = GRIDFPS.Item(GJOBNO.Index, e.RowIndex).Value

            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub


    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbcolor.Text.Trim = "" And CMBDYEING.Text.Trim <> "" And cmbdesign.Text.Trim = "" Then
                fillCOLOR(cmbcolor, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID ", " AND DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")

            ElseIf cmbcolor.Text.Trim = "" And cmbdesign.Text.Trim <> "" Then
                fillCOLOR(cmbcolor, "  INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesign.Text & "'")
            Else
                If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbcolor.Text.Trim <> "" And CMBDYEING.Text.Trim <> "" And cmbdesign.Text.Trim = "" Then
                COLORvalidate(cmbcolor, e, Me, " INNER JOIN DYEINGRECIPE_DESC ON COLORMASTER.COLOR_id = DYEINGRECIPE_DESC.DYEING_MATCHINGID AND COLORMASTER.COLOR_cmpid = DYEINGRECIPE_DESC.DYEING_CMPID AND COLORMASTER.COLOR_locationid = DYEINGRECIPE_DESC.DYEING_LOCATIONID AND COLORMASTER.COLOR_yearid = DYEINGRECIPE_DESC.DYEING_YEARID INNER JOIN DYEINGRECIPE ON DYEINGRECIPE_DESC.DYEING_ID = DYEINGRECIPE.DYEING_ID AND DYEINGRECIPE_DESC.DYEING_CMPID = DYEINGRECIPE.DYEING_CMPID AND DYEINGRECIPE_DESC.DYEING_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND DYEINGRECIPE_DESC.DYEING_YEARID = DYEINGRECIPE.DYEING_YEARID", " AND  DYEINGRECIPE.DYEING_NO='" & CMBDYEING.Text & "'")
            ElseIf cmbcolor.Text.Trim <> "" And cmbdesign.Text.Trim <> "" Then
                COLORvalidate(cmbcolor, e, Me, " INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesign.Text & "'")
            Else
                If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' OR ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesign.GotFocus
        Try
            If cmbdesign.Text.Trim = "" Then fillDESIGN(cmbdesign, cmbmerchant.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesign.Validating
        'Try
        '    'If cmbdesign.Text.Trim <> "" Then DESIGNvalidate(cmbdesign, cmbmerchant, e, Me)
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbdesign.Text.Trim <> "" Then
                pcase(cmbdesign)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("DESIGN_NO ", "", " DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid ", "  and DESIGN_NO = '" & cmbdesign.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbdesign.Text.Trim
                    Dim tempmsg As Integer = MsgBox("DESIGN not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        cmbdesign.Text = a
                        Dim OBJDESIGN As New DesignRecipe
                        OBJDESIGN.TEMPDESIGNNO = cmbdesign.Text.Trim()
                        OBJDESIGN.TEMPMERCHANT = cmbmerchant.Text.Trim()
                        OBJDESIGN.ShowDialog()
                        dt = OBJCMN.search("DESIGN_NO ", "", "  DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid ", "  and DESIGN_NO = '" & cmbdesign.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbdesign.DataSource
                            If cmbdesign.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbdesign.Text.Trim)
                                    cmbdesign.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Validated
        Try
            If CMBFROM.Text.Trim <> "" Then CMBFROM.Enabled = False
            If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                If CMBFROM.Text.Trim = "" Then CMBMERCHANT1.Enabled = True Else CMBMERCHANT1.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDFPS_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDFPS.CellValidating
        Try
            Dim colNum As Integer = GRIDFPS.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gpcs.Index, GCUT.Index, GBUNDLE.Index, GTOTALMTRS.Index, GLOTNO.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDFPS.CurrentCell.Value = Nothing Then GRIDFPS.CurrentCell.Value = "0.00"
                        GRIDFPS.CurrentCell.Value = Convert.ToDecimal(GRIDFPS.Item(colNum, e.RowIndex).Value)
                        'DONE BY GULKIT
                        'If e.ColumnIndex = GTOTALMTRS.Index Or e.ColumnIndex = GLOTNO.Index Then
                        '    Dim tempsrno As String = "0"

                        '    For Each row As DataGridViewRow In GRIDFPS.Rows
                        '        If tempsrno = "0" Then
                        '            tempsrno = row.Cells(GMFGSRNO.Index).Value
                        '        ElseIf Convert.ToDecimal(row.Cells(GMFGSRNO.Index).Value) <> 0 Then
                        '            tempsrno = tempsrno & "," & row.Cells(GMFGSRNO.Index).Value
                        '        End If
                        '    Next

                        '    If CMBFROM.Text = "WHITE FOLDING" Then
                        '        CALCLOTBAL(GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue)
                        '        If templotno = GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue And edit = True Then Exit Sub
                        '    End If
                        '    If GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue > 0 Then
                        '        Dim OBJCMN As New ClsCommonMaster
                        '        Dim dt As DataTable
                        '        If lblbalmtrs.Text < -50 And CMBFROM.Text = "WHITE FOLDING" Then
                        '            MsgBox("No Mtrs Found in this lot")
                        '            e.Cancel = True
                        '            Exit Sub
                        '        End If
                        '        If GRIDFPS.Rows(e.RowIndex).Cells(GJOBNO.Index).EditedFormattedValue <> "" Then
                        '            'DONE BY GULKIT
                        '            'dt = OBJCMN.search(" DISTINCT MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND JOBNO='" & CMBJOBNO.Text & "'  AND RECDMTRS-OUTMTRS=" & GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                        '            dt = OBJCMN.search(" DISTINCT MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", " AND PIECETYPE = '" & GRIDFPS.Rows(e.RowIndex).Cells(gpiecetype.Index).EditedFormattedValue & "' AND PROCESSNAME='" & CMBFROM.Text & "'  AND JOBNO='" & GRIDFPS.Rows(e.RowIndex).Cells(GJOBNO.Index).EditedFormattedValue & "'  AND RECDMTRS-OUTMTRS=" & GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                        '        Else
                        '            dt = OBJCMN.search(" DISTINCT MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", " AND PIECETYPE = '" & GRIDFPS.Rows(e.RowIndex).Cells(gpiecetype.Index).EditedFormattedValue & "' AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue & "'  AND MFGSRNO NOT IN (" & tempsrno & ")  AND RECDMTRS-OUTMTRS=" & GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                        '        End If
                        '        If dt.Rows.Count > 0 Then
                        '            GRIDFPS.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '            GRIDFPS.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = dt.Rows(0).Item(1)
                        '            GRIDFPS.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(2)
                        '            GRIDFPS.Rows(e.RowIndex).Cells(GTYPE.Index).Value = dt.Rows(0).Item(3)
                        '        Else
                        '            If GRIDFPS.Rows(e.RowIndex).Cells(GJOBNO.Index).EditedFormattedValue <> "" Then
                        '                dt = OBJCMN.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND JOBNO='" & GRIDFPS.Rows(e.RowIndex).Cells(GJOBNO.Index).EditedFormattedValue & "'  AND RECDMTRS-OUTMTRS<" & Val(GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS desc")
                        '            Else
                        '                dt = OBJCMN.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue & "' AND MFGSRNO NOT IN (" & tempsrno & ") AND RECDMTRS-OUTMTRS <" & Val(GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS desc")
                        '            End If
                        '            If dt.Rows.Count > 0 Then
                        '                GRIDFPS.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '                GRIDFPS.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = dt.Rows(0).Item(1)
                        '                GRIDFPS.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(2)
                        '                GRIDFPS.Rows(e.RowIndex).Cells(GTYPE.Index).Value = dt.Rows(0).Item(3)
                        '            Else
                        '                If CMBJOBNO.Text <> "" Then
                        '                    dt = OBJCMN.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND JOBNO='" & CMBJOBNO.Text & "'  AND RECDMTRS-OUTMTRS >" & Val(GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS")
                        '                Else
                        '                    dt = OBJCMN.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).Value & "' AND MFGSRNO NOT IN (" & tempsrno & ") AND RECDMTRS-OUTMTRS >" & Val(GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS")
                        '                End If
                        '                If dt.Rows.Count > 0 Then
                        '                    GRIDFPS.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '                    GRIDFPS.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = dt.Rows(0).Item(1)
                        '                    GRIDFPS.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(2)
                        '                    GRIDFPS.Rows(e.RowIndex).Cells(GTYPE.Index).Value = dt.Rows(0).Item(3)
                        '                Else
                        '                    If CMBJOBNO.Text <> "" Then
                        '                        dt = OBJCMN.search("  GRIDSRNO,QUALITY ,TYPE ", "", " OPENINGSTOCK_VIEW ", "  AND PROCESS='" & CMBFROM.Text & "'  AND JOBNO='" & CMBJOBNO.Text & "'  AND MTRS-OUTMTRS >" & Val(GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by MTRS")
                        '                    Else
                        '                        dt = OBJCMN.search("  GRIDSRNO,QUALITY ,TYPE ", "", " OPENINGSTOCK_VIEW ", "  AND PROCESS='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDFPS.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue & "' AND gridsrno NOT IN (" & tempsrno & ") AND MTRS-OUTMTRS >" & Val(GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by MTRS")
                        '                    End If
                        '                    If dt.Rows.Count > 0 Then
                        '                        GRIDFPS.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '                        GRIDFPS.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = 0
                        '                        GRIDFPS.Rows(e.RowIndex).Cells(GTYPE.Index).Value = dt.Rows(0).Item(2)
                        '                        GRIDFPS.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(1)
                        '                    Else
                        '                        '
                        '                        If Val(lblbalmtrs.Text) < -50 Then
                        '                            e.Cancel = True
                        '                            MsgBox("No Match Found in " & CMBFROM.Text & " Process")
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).Value = 0
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = 0
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = 0
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = ""
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GTYPE.Index).Value = ""
                        '                        Else
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).Value = 0
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = 0
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = 0
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = ""
                        '                            GRIDFPS.Rows(e.RowIndex).Cells(GTYPE.Index).Value = ""
                        '                        End If
                        '                    End If
                        '                End If
                        '            End If
                        '        End If
                        '    End If
                        'End If

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

    Private Sub CMDSELECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECT.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            SELECTMFGTABLE.Clear()
            Dim OBJSELECTMFGTABLE As New SelectMfgforPS
            OBJSELECTMFGTABLE.FRMSTRING = "MFG"
            OBJSELECTMFGTABLE.final = True
            OBJSELECTMFGTABLE.PROCESSNAME = CMBFROM.Text.Trim
            OBJSELECTMFGTABLE.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTMFGTABLE.ShowDialog()


            Dim i As Integer = 0
            If SELECTMFGTABLE.Rows.Count > 0 Then

                chkchange.Checked = True
                'DONE BY GULKIT
                'If edit = False Then GRIDFPS.RowCount = 0

                Dim WIDTH As Integer = 0
                If ClientName = "SHREENATH" Then WIDTH = 116
                For Each DTROW As DataRow In SELECTMFGTABLE.Rows
                    If CMBFROM.Text.Trim = "" Then DTROW("GRNTYPE") = DTROW("TYPE")
                    GRIDFPS.Rows.Add(0, DTROW("PIECETYPE"), "", DTROW("ITEMNAME"), WIDTH, DTROW("CUT"), DTROW("DESIGNNO"), DTROW("COLOR"), DTROW("LOTNO"), DTROW("SAREE"), 1, DTROW("SAREE"), Format(Val(DTROW("WT")), "0.00"), Format(Val(DTROW("MTRS")), "0.00"), 0, DTROW("MFGNO"), DTROW("MFGSRNO"), DTROW("QUALITY"), DTROW("GRNTYPE"), DTROW("JOBNO").ToString)
                Next

                Dim DV As DataView = SELECTMFGTABLE.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "JOBNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If CMBJOBNO.Text.Trim = "" Then
                        CMBJOBNO.Text = DTR("JOBNO").ToString
                    Else
                        CMBJOBNO.Text = CMBJOBNO.Text & "," & DTR("JOBNO").ToString
                    End If
                Next

                'FOR LOOSE STOCK OPEN CMBMERCHANT
                If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                    If CMBFROM.Text.Trim = "" Then CMBMERCHANT1.Enabled = True Else CMBMERCHANT1.Enabled = False
                End If

                getsrno(GRIDFPS)
                TOTAL()
                cmbname.Focus()
            Else
                If GRIDFPS.RowCount = 0 Then CMBFROM.Enabled = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALCLOTBAL(ByVal LOTNO As Integer)
        Try
            If edit = False Then
                lblbalmtrs.Text = 0
                Dim OBJCMN As New ClsCommonMaster
                Dim dt1 As New DataTable
                Dim WHERECLAUSE As String


                Dim DTLOT As DataTable = OBJCMN.search("NAME, [Item Name] AS ITEMNAME, READYWIDTH, TYPE, PARTYMERCHANTNAME", "", "ALLLOTVIEW", " AND [LOT NO.] = " & Val(CMBLOTNO.Text.Trim) & " AND YEARID = " & YearId)
                If DTLOT.Rows.Count > 0 Then
                    'IF LOT NO IS PRESENT IN GRN AND OPENING BOTH THEN ASK USER TO FETCH DATA FROM OPENING OR NOT
                    Dim DTROW() As DataRow
                    If DTLOT.Rows.Count > 1 AndAlso MsgBox("Fetch Lot Details from Opening?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        DTROW = DTLOT.Select("TYPE = 'OPENING'")
                        WHERECLAUSE = " AND TYPE = 'OPENING'"
                    Else
                        If DTLOT.Rows.Count > 1 Then DTROW = DTLOT.Select("TYPE <> 'OPENING'") Else DTROW = DTLOT.Select("")
                        WHERECLAUSE = " AND TYPE <> 'OPENING'"
                    End If
                End If

                If ClientName = "TULSI" Or ClientName = "SHREENATH" Or ClientName = "DHANLAXMI" Then dt1 = OBJCMN.search(" isnull(sum(mtrs),0) AS MTRS, isnull(sum(PCS),0) AS PCS ", "", " VIEW_SUMMARY_MFG1", "   AND LOTNO='" & LOTNO & "'  AND yearid = " & YearId) Else dt1 = OBJCMN.search(" isnull(sum(RECDMTRS),0) AS MTRS, isnull(sum(RECDPCS),0) AS PCS ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME = '" & CMBFROM.Text.Trim & "' AND LOTNO='" & LOTNO & "'  AND yearid = " & YearId & WHERECLAUSE)
                If dt1.Rows.Count > 0 Then
                    For Each ROW As DataGridViewRow In GRIDFPS.Rows
                        If LOTNO = ROW.Cells(GLOTNO.Index).Value Then
                            lblbalmtrs.Text = lblbalmtrs.Text - ROW.Cells(GTOTALMTRS.Index).Value
                        End If
                    Next
                    lblbalmtrs.Text = Format(Val(lblbalmtrs.Text) + Val(dt1.Rows(0).Item(0)), "0.00")
                    LBLBALPCS.Text = Val(dt1.Rows(0).Item("PCS"))
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT1.Enter
        Try
            If CMBMERCHANT1.Text.Trim = "" Then fillitemname(CMBMERCHANT1, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT1.Validating
        Try
            If CMBMERCHANT1.Text.Trim <> "" Then itemvalidate(CMBMERCHANT1, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
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
            cmbcolor.Text = ""
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

    Sub CALC()
        Try
            If Val(txtpcs.Text) <> 0 And Val(txtbundle.Text) <> 0 Then txttotal.Text = Val(txtpcs.Text) * Val(txtbundle.Text) Else txttotal.Text = Val(txtpcs.Text)
            If Val(txtcut.Text.Trim) > 0 Then txtmtrs.Text = Val(txtcut.Text.Trim) * Val(txttotal.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpcs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpcs.Validating, txtbundle.Validating
        CALC()
    End Sub

    Private Sub CMBLOTNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBLOTNO.GotFocus
        Try
            FILLLOTNO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLLOTNO()
        Try
            If CMBLOTNO.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As New DataTable
                If ClientName = "DHANLAXMI" Then
                    dt = OBJCMN.search(" LOTNO ", "", " VIEW_SUMMARY_MFG1 INNER JOIN (SELECT DISTINCT MFG_LOTNO FROM MFGMASTER_DESC INNER JOIN MFGMASTER ON MFGMASTER_DESC.MFG_NO = MFGMASTER.MFG_NO AND MFGMASTER_DESC.MFG_YEARID = MFGMASTER.MFG_YEARID INNER JOIN PROCESSMASTER ON MFG_TOPROCESSID = PROCESS_ID WHERE PROCESS_NAME = '" & CMBFROM.Text.Trim & "' AND MFGMASTER.MFG_CMPID = " & CmpId & " AND MFGMASTER.MFG_YEARID = " & YearId & ") AS T ON VIEW_SUMMARY_MFG1.LOTNO = T.MFG_LOTNO ", " AND CMPID = " & CmpId & " AND yearid = " & YearId & " GROUP BY LOTNO HAVING ROUND(SUM(MTRS),2) > 0 ")
                ElseIf ClientName = "SHUBHLAXMI" Then
                    'dt = OBJCMN.search(" LOTNO ", "", " VIEW_SUMMARY_MFG1 INNER JOIN (SELECT DISTINCT MFG_LOTNO FROM MFGMASTER_DESC INNER JOIN MFGMASTER ON MFGMASTER_DESC.MFG_NO = MFGMASTER.MFG_NO AND MFGMASTER_DESC.MFG_YEARID = MFGMASTER.MFG_YEARID INNER JOIN PROCESSMASTER ON MFG_TOPROCESSID = PROCESS_ID WHERE PROCESS_NAME = '" & CMBFROM.Text.Trim & "' AND MFGMASTER.MFG_YEARID = " & YearId & ") AS T ON VIEW_SUMMARY_MFG1.LOTNO = T.MFG_LOTNO ", " AND yearid = " & YearId & " GROUP BY LOTNO HAVING ROUND(SUM(PCS),0) > 0 ")
                    dt = OBJCMN.search(" LOTNO ", "", " VIEW_SUMMARY_MFG1 ", " AND yearid = " & YearId & " AND LOTNO IN (SELECT DISTINCT MFG_LOTNO FROM MFGMASTER_DESC INNER JOIN MFGMASTER ON MFGMASTER_DESC.MFG_NO = MFGMASTER.MFG_NO AND MFGMASTER_DESC.MFG_YEARID = MFGMASTER.MFG_YEARID INNER JOIN PROCESSMASTER ON MFG_TOPROCESSID = PROCESS_ID WHERE PROCESS_NAME = '" & CMBFROM.Text.Trim & "' AND MFGMASTER.MFG_YEARID = " & YearId & " and MFGMASTER_DESC.MFG_DONE = 0) GROUP BY LOTNO HAVING ROUND(SUM(PCS),0) > 0 ")
                Else
                    dt = OBJCMN.search(" DISTINCT LOTNO ", "", " PACKINGSLIPVIEW", "  And PROCESSNAME='" & CMBFROM.Text & "' and yearid = " & YearId)
                End If
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

    Private Sub CMBJOBNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBJOBNO.GotFocus
        Try
            If CMBJOBNO.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search(" DISTINCT JOBNO ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME='" & CMBFROM.Text & "' and yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "JOBNO"
                    CMBJOBNO.DataSource = dt
                    CMBJOBNO.DisplayMember = "JOBNO"
                    CMBJOBNO.Text = ""
                End If
                CMBJOBNO.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) = 0 Then Exit Sub
            GRIDFPS.RowCount = 0
            tempfpsno = Val(tstxtbillno.Text)
            If tempfpsno > 0 Then
                edit = True
                FPS_Load(sender, e)
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
            If edit = True Then PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            Dim OBJGRN As New FPSDESIGN
            If GRIDFPS.Rows(0).Cells(gpiecetype.Index).Value = "GOOD CUT" Then
                OBJGRN.goodcut = True
            End If
            OBJGRN.MdiParent = MDIMain
            OBJGRN.FRMSTRING = "FPS"
            OBJGRN.fspno = tempfpsno
            OBJGRN.SELFORMULA = "{finalpackingslip.fps_NO}=" & tempfpsno & " and {finalpackingslip.fps_yearid}=" & YearId
            OBJGRN.HEADER = CHKHEADER.Checked
            OBJGRN.VENDORNAME = cmbname.Text.Trim
            If CMBFROM.Text.Trim = "FINAL CUTTING" Then
                Dim JOBNO As String = ""
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DISTINCT   FINALCUTTINGPROCESS.FCP_JOBNO  AS JOBNO ", "", " FINALCUTTINGPROCESS INNER JOIN FINALPACKINGSLIP_DESC ON FINALCUTTINGPROCESS.FCP_NO = FINALPACKINGSLIP_DESC.FPS_MFGNO AND FINALCUTTINGPROCESS.FCP_YEARID = FINALPACKINGSLIP_DESC.FPS_YEARID ", " AND FPS_NO = " & tempfpsno & " AND FPS_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If JOBNO = "" Then
                            JOBNO = DTROW("JOBNO")
                        Else
                            JOBNO = JOBNO & ", " & DTROW("JOBNO")
                        End If
                    Next
                End If
                OBJGRN.JOBNO = JOBNO
            End If
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        Dim OBJ As New Object

        If ClientName = "MONOGRAM" Then
            OBJ = New FINALPACKINGSLIP_MONOGRAM
        ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
            OBJ = New FINALPACKINGSLIP_DHANLAXMI
        Else
            OBJ = New fpsreport
        End If

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

        crTables = OBJ.Database.Tables
        For Each crTable In crTables
            crtableLogonInfo = crTable.LogOnInfo
            crtableLogonInfo.ConnectionInfo = crConnecttionInfo
            crTable.ApplyLogOnInfo(crtableLogonInfo)
        Next

        If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
            If GRIDFPS.Rows(0).Cells(gpiecetype.Index).Value = "GOOD CUT" Then
                OBJ.GroupHeaderSection7.SectionFormat.EnableSuppress = True
                OBJ.GroupHeaderSection10.SectionFormat.EnableSuppress = False
                OBJ.GroupHeaderSection8.SectionFormat.EnableSuppress = True
                OBJ.GroupHeaderSection9.SectionFormat.EnableSuppress = False
                OBJ.GroupFooterSection3.SectionFormat.EnableSuppress = True
                OBJ.GroupFooterSection7.SectionFormat.EnableSuppress = False
            End If
        End If

        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable

        If CHKHEADER.Checked = False Then OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 1 Else OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
        If CMBFROM.Text.Trim = "FINAL CUTTING" Then
            Dim JOBNO As String = ""
            DT = OBJCMN.search(" DISTINCT   FINALCUTTINGPROCESS.FCP_JOBNO  AS JOBNO ", "", " FINALCUTTINGPROCESS INNER JOIN FINALPACKINGSLIP_DESC ON FINALCUTTINGPROCESS.FCP_NO = FINALPACKINGSLIP_DESC.FPS_MFGNO AND FINALCUTTINGPROCESS.FCP_YEARID = FINALPACKINGSLIP_DESC.FPS_YEARID ", " AND FPS_NO = " & TXTFPSNO.Text.Trim & " AND FPS_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    If JOBNO = "" Then
                        JOBNO = DTROW("JOBNO")
                    Else
                        JOBNO = JOBNO & ", " & DTROW("JOBNO")
                    End If
                Next
            End If
            OBJ.DataDefinition.FormulaFields("JOBNO").Text = JOBNO
        End If
        '************************ END *******************


        If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
            'GET MULTIPLELOTNOS
            Dim TEMPLOTNO As String = ""
            DT = OBJCMN.search("DISTINCT FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO", "", " FINALPACKINGSLIP_DESC", " AND FPS_NO = " & Val(TXTFPSNO.Text.Trim) & " AND FPS_YEARID = " & YearId)
            For Each DTROW As DataRow In DT.Rows
                If TEMPLOTNO = "" Then TEMPLOTNO = DTROW("LOTNO") Else TEMPLOTNO = TEMPLOTNO & "," & DTROW("LOTNO")
            Next
            OBJ.DataDefinition.FormulaFields("MULTILOTNO").Text = "'" & TEMPLOTNO & "'"
        End If

        If ClientName = "TULSI" Or ClientName = "SHREENATH" Then OBJ.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
        OBJ.RecordSelectionFormula = "{finalpackingslip.fps_no}=" & TXTFPSNO.Text & " and {finalpackingslip.fps_yearid}=" & YearId
        OBJ.PrintToPrinter(1, True, 0, 0)
    End Sub

    Private Sub txtcopy_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcopy.Validating
        Try

            If Val(txtcopy.Text.Trim) = 0 Then Exit Sub
            GRIDFPS.RowCount = 0

            If Val(txtcopy.Text) < Val(TXTFPSNO.Text) Then
                tempfpsno = Val(txtcopy.Text)
                billcopy = True
                FPS_Load(sender, e)
            Else
                CLEAR()
                edit = False
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
    Sub TOTALCONSUMPTION()
        Try
            LBLACTCONSUMEDQTY.Text = 0.0
            LBLACTCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0

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
    Private Sub txthelpers_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthelpers.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDCONSUMPTION_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCONSUMPTION.KeyDown
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

    Private Sub gridhelper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridhelper.KeyDown
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

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub TXTFPSNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFPSNO.Validating
        If edit = False And Val(TXTFPSNO.Text.Trim) > 0 Then
            Dim OBJCMN As New ClsCommonMaster
            Dim dt As DataTable
            dt = OBJCMN.search(" FPS_NO ", "", " FINALPACKINGSLIP ", "  and FPS_NO=" & Val(TXTFPSNO.Text) & " and FPS_cmpid=" & CmpId & " and FPS_locationid= " & Locationid & " and FPS_yearid= " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Bale No. Already exist?")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtcut_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcut.Validated
        CALC()
    End Sub

    Private Sub txtmtrs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmtrs.Validating
        Try
            If Val(txtbundle.Text.Trim) = 0 Then txtbundle.Text = 1
            If cmbmerchant.Text.Trim <> "" And cmbpiecetype.Text.Trim <> "" And Val(txtpcs.Text.Trim) > 0 And Val(txtmtrs.Text.Trim) > 0 Then
                'If CMBLOTNO.Text = "" And CMBJOBNO.Text = "" Then
                '    MsgBox("LOTNO AND JOBNO BOTH CANNOT BE BLANK  ")
                '    e.Cancel = True
                '    CMBJOBNO.Focus()
                'End If


                'DONE BY GULKIT FROM HERE ABOVE CODE WAS ALREADY COMMENTED
                'If gridDoubleClick = True Then If CMBLOTNO.Text = GRIDFPS.Rows(temprow).Cells(GLOTNO.Index).Value Then Exit Sub
                'If CMBLOTNO.Text.Trim <> "" Or CMBJOBNO.Text <> "" Then
                '    Dim tempsrno As String = "0"

                '    For Each row As DataGridViewRow In GRIDFPS.Rows
                '        If CMBLOTNO.Text = row.Cells(GLOTNO.Index).Value And CMBJOBNO.Text = "" Then
                '            If tempsrno = "0" Then
                '                tempsrno = row.Cells(GMFGSRNO.Index).Value
                '            ElseIf row.Cells(GMFGSRNO.Index).Value <> "" Then
                '                tempsrno = tempsrno & "," & row.Cells(GMFGSRNO.Index).Value

                '            End If
                '        End If
                '    Next

                '    Dim OBJCMN As New ClsCommonMaster
                '    Dim dt As DataTable

                '    If CMBJOBNO.Text <> "" Then
                '        dt = OBJCMN.search(" DISTINCT MFGSRNO,MFGNO,QUALITY,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND JOBNO='" & CMBJOBNO.Text & "'   AND RECDMTRS-OUTMTRS=" & txtmtrs.Text & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                '    ElseIf CMBLOTNO.Text <> "" Then
                '        dt = OBJCMN.search(" DISTINCT MFGSRNO,MFGNO,QUALITY,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & CMBLOTNO.Text & "' and mfgsrno not in (" & tempsrno & ")   AND RECDMTRS-OUTMTRS=" & txtmtrs.Text & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                '    End If
                '    If dt.Rows.Count > 0 Then

                '        TXTMFGSRNO.Text = dt.Rows(0).Item(0)
                '        TXTMFGNO.Text = dt.Rows(0).Item(1)
                '        TXTQUALITY.Text = dt.Rows(0).Item(2)
                '        TXTTYPE.Text = dt.Rows(0).Item(3)

                '    Else
                '        If CMBJOBNO.Text <> "" Then
                '            dt = OBJCMN.search("  MFGSRNO,MFGNO ,QUALITY,GRNTYPE ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME='" & CMBFROM.Text & "'  AND jobno='" & CMBJOBNO.Text & "'  AND RECDMTRS-OUTMTRS <" & Val(txtmtrs.Text) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS desc")
                '        ElseIf CMBLOTNO.Text <> "" Then
                '            dt = OBJCMN.search("  MFGSRNO,MFGNO ,QUALITY,GRNTYPE ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & CMBLOTNO.Text & "' and mfgsrno not in (" & tempsrno & ")   AND RECDMTRS-OUTMTRS <" & Val(txtmtrs.Text) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS desc")
                '        End If
                '        If dt.Rows.Count > 0 Then
                '            TXTMFGNO.Text = dt.Rows(0).Item(1)
                '            TXTMFGSRNO.Text = dt.Rows(0).Item(0)
                '            TXTQUALITY.Text = dt.Rows(0).Item(2)
                '            TXTTYPE.Text = dt.Rows(0).Item(3)
                '        Else
                '            If CMBJOBNO.Text <> "" Then

                '                dt = OBJCMN.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND JOBNO='" & CMBJOBNO.Text & "'  AND RECDMTRS-OUTMTRS >" & Val(txtmtrs.Text) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS")
                '            ElseIf CMBLOTNO.Text <> "" Then
                '                dt = OBJCMN.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & CMBLOTNO.Text & "' and mfgsrno not in (" & tempsrno & ")  AND RECDMTRS-OUTMTRS >" & Val(txtmtrs.Text) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS")

                '            End If
                '            If dt.Rows.Count > 0 Then
                '                TXTMFGSRNO.Text = dt.Rows(0).Item(0)
                '                TXTMFGNO.Text = dt.Rows(0).Item(1)
                '                TXTQUALITY.Text = dt.Rows(0).Item(2)
                '                TXTTYPE.Text = dt.Rows(0).Item(3)
                '            Else
                '                If CMBJOBNO.Text <> "" Then
                '                    dt = OBJCMN.search("  GRIDSRNO,QUALITY ,TYPE ", "", " OPENINGSTOCK_VIEW ", "  AND PROCESS='" & CMBFROM.Text & "'  AND JOBNO='" & CMBLOTNO.Text & "'  AND MTRS-OUTMTRS >" & Val(txtmtrs.Text) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by MTRS")
                '                ElseIf CMBLOTNO.Text <> "" Then
                '                    dt = OBJCMN.search("  GRIDSRNO,QUALITY ,TYPE ", "", " OPENINGSTOCK_VIEW ", "  AND PROCESS='" & CMBFROM.Text & "' and gridsrno not in (" & tempsrno & ")  AND LOTNO='" & CMBLOTNO.Text & "'  AND MTRS-OUTMTRS >" & Val(txtmtrs.Text) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by MTRS")
                '                End If
                '                If dt.Rows.Count > 0 Then
                '                    TXTMFGSRNO.Text = dt.Rows(0).Item(0)
                '                    TXTMFGNO.Text = 0
                '                    TXTQUALITY.Text = dt.Rows(0).Item(1)
                '                    TXTTYPE.Text = dt.Rows(0).Item(2)
                '                Else

                '                    If Val(lblbalmtrs.Text) < -50 Then
                '                        MsgBox("nO Match Found, Enter Proper Details")
                '                        e.Cancel = True
                '                    Else
                '                        TXTMFGSRNO.Text = 0
                '                        TXTMFGNO.Text = 0
                '                        TXTQUALITY.Text = ""
                '                        TXTTYPE.Text = ""
                '                    End If
                '                End If
                '            End If
                '        End If
                '    End If


                'End If
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBLOTNO.Validated
        Try
            'GET MFGNO AND MFGSRNO FROM PACKINGSLIPVIEW
            If CMBFROM.Text.Trim <> "FINAL CUTTING" And CMBLOTNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT MFGNO, MFGSRNO, JOBNO, TYPE, GRNTYPE FROM PACKINGSLIPVIEW WHERE LOTNO = '" & CMBLOTNO.Text.Trim & "' AND PIECETYPE = '" & cmbpiecetype.Text.Trim & "' AND PROCESSNAME = '" & CMBFROM.Text.Trim & "' AND CMPID = " & CmpId & " AND YEARID = " & YearId, "", "")
                If DT.Rows.Count > 0 Then
                    TXTMFGNO.Text = DT.Rows(0).Item("MFGNO")
                    TXTMFGSRNO.Text = DT.Rows(0).Item("MFGSRNO")
                    TXTJOBNO.Text = DT.Rows(0).Item("JOBNO")
                    If DT.Rows(0).Item("TYPE") = "OPENING" Then TXTTYPE.Text = DT.Rows(0).Item("GRNTYPE") Else TXTTYPE.Text = DT.Rows(0).Item("TYPE")
                Else
                    MsgBox("Invalid Lot No", MsgBoxStyle.Critical)
                    If ClientName = "TULSI" Or ClientName = "SHREENATH" Then Exit Sub
                End If

                'FETCH MERCHANT, WIDTH AND PARTYNAME FROM ALLLOT
                If ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI" Then
                    Dim WHERECLAUSE As String = ""
                    Dim DTLOT As DataTable = OBJCMN.search("NAME, [Item Name] AS ITEMNAME, READYWIDTH, TYPE, PARTYMERCHANTNAME", "", "ALLLOTVIEW", " AND [LOT NO.] = " & Val(CMBLOTNO.Text.Trim) & " AND YEARID = " & YearId)
                    If DTLOT.Rows.Count > 0 Then
                        'IF LOT NO IS PRESENT IN GRN AND OPENING BOTH THEN ASK USER TO FETCH DATA FROM OPENING OR NOT
                        Dim DTROW() As DataRow
                        If DTLOT.Rows.Count > 1 AndAlso MsgBox("Fetch Lot Details from Opening?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            DTROW = DTLOT.Select("TYPE = 'OPENING'")
                            WHERECLAUSE = " AND TYPE = 'OPENING'"
                        Else
                            If DTLOT.Rows.Count > 1 Then DTROW = DTLOT.Select("TYPE <> 'OPENING'") Else DTROW = DTLOT.Select("")
                            WHERECLAUSE = " AND TYPE <> 'OPENING'"
                        End If

                        'ADDED THIS CODE AGAIN FROM CALCLOT COZ WE NEED PLZ AND MTRS FROM OPENING IF SELECTED OPENING
                        lblbalmtrs.Text = 0
                        Dim dt1 As DataTable = OBJCMN.search(" isnull(sum(RECDMTRS),0) AS MTRS, isnull(sum(RECDPCS),0) AS PCS ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME = '" & CMBFROM.Text.Trim & "' AND LOTNO='" & CMBLOTNO.Text.Trim & "' AND yearid = " & YearId & WHERECLAUSE)
                        If dt1.Rows.Count > 0 Then
                            For Each ROW As DataGridViewRow In GRIDFPS.Rows
                                If Val(CMBLOTNO.Text.Trim) = ROW.Cells(GLOTNO.Index).Value Then
                                    lblbalmtrs.Text = lblbalmtrs.Text - ROW.Cells(GTOTALMTRS.Index).Value
                                End If
                            Next
                            lblbalmtrs.Text = Format(Val(lblbalmtrs.Text) + Val(dt1.Rows(0).Item(0)), "0.00")
                            LBLBALPCS.Text = Val(dt1.Rows(0).Item("PCS"))
                        End If


                        If DTROW(0).Item("NAME") <> "" Then cmbname.Text = DTROW(0).Item("NAME")
                        If CMBMERCHANT1.Text.Trim <> DTROW(0).Item("ITEMNAME") And CMBMERCHANT1.Text.Trim <> "" Then
                            If MsgBox("Quality Mismatch, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                        End If
                        CMBMERCHANT1.Text = DTROW(0).Item("ITEMNAME")
                        If cmbmerchant.Text.Trim = "" Then cmbmerchant.Text = DTROW(0).Item("PARTYMERCHANTNAME")
                        txtwidth.Text = DTROW(0).Item("READYWIDTH")
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOTNO.Validating
        If Val(CMBLOTNO.Text.Trim) > 0 Then CALCLOTBAL(CMBLOTNO.Text.Trim)
    End Sub

    Private Sub txtpcs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpcs.KeyPress
        numkeypress(e, txtpcs, Me)
    End Sub

    Private Sub txtcut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcut.KeyPress
        numdotkeypress(e, txtcut, Me)
    End Sub

    Private Sub txtwidth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwidth.KeyPress
        If ClientName = "TULSI" Or ClientName = "SHREENATH" Then numkeypress(e, txtwidth, Me)
    End Sub

    Private Sub txttotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotal.KeyPress
        numkeypress(e, txttotal, Me)
    End Sub

    Private Sub txtwt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwt.KeyPress
        numdotkeypress(e, txtwt, Me)
    End Sub

    Private Sub txtmtrs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmtrs.KeyPress
        numdotkeypress(e, txtmtrs, Me)
    End Sub

    Private Sub CHKYARDS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKYARDS.CheckedChanged
        Try
            If ClientName = "MONOGRAM" Then
                If CHKYARDS.CheckState = CheckState.Checked Then
                    gwt.HeaderText = "Yard"
                    txtwt.TabStop = True
                Else
                    gwt.HeaderText = "Wt."
                    txtwt.TabStop = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub finalPackingslip_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
            txtbundle.TabStop = False
            txttotal.TabStop = False
            txtwt.TabStop = False
            LBLFBNO.Text = "Fold"
            CMDSELECT.TabStop = False
            CMBMERCHANT1.TabStop = False

            txtwidth.TabStop = False

            If ClientName = "MONOGRAM" Then
                cmbmerchant.TabStop = False
                TXTCALCFOLD.Visible = True
            End If

            If ClientName = "SHUBHLAXMI" Then
                CMBDYEING.TabStop = False
                TXTDESC.TabStop = False
                cmbcolor.TabStop = False
                cmbmerchant.TabStop = False
                CMBMERCHANT1.Enabled = False
                LBLBALPCS.Visible = True
                BALPCS.Visible = True
            End If

            If ClientName = "DHANLAXMI" Then
                CMBCOLORTYPE.Visible = True
            End If

            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                FPSDATE.TabStop = False
                CMBFROM.TabStop = False
                CHKYARDS.TabStop = False
                TXTPRGNO.TabStop = False
                CMBPROCESSTYPE.TabStop = False
                TXTORDERNO.TabStop = False
                CMBJOBNO.TabStop = False
                txtcut.TabStop = False
                cmbdesign.TabStop = False
            End If

        Else
            CHKYARDS.TabStop = False
            CMBPROCESSTYPE.TabStop = False
        End If
        If UserName = "Admin" Then CMBGODOWN.Enabled = True
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
                        alParaval.Add(TXTFPSNO.Text.Trim)
                        alParaval.Add(Userid)
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(YearId)
                        alParaval.Add(CMBFROM.Text.Trim)

                        Dim ClsGRNChecking As New ClsFPS()
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

    Private Sub CMBPROCESSTYPE_Enter(sender As Object, e As EventArgs) Handles CMBPROCESSTYPE.Enter
        Try
            If CMBPROCESSTYPE.Text.Trim = "" Then FILLPROCESSTYPE(CMBPROCESSTYPE, edit)
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

    Private Sub cmbname_Validated(sender As Object, e As EventArgs) Handles cmbname.Validated
        Try
            If (ClientName = "SHUBHLAXMI" Or ClientName = "DHANLAXMI") And cmbname.Text.Trim <> "" Then CMBLOTNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtwt_Validated(sender As Object, e As EventArgs) Handles txtwt.Validated
        Try
            If CHKYARDS.CheckState = CheckState.Checked Then
                If Val(TXTCALCFOLD.Text.Trim) > 0 Then txtmtrs.Text = Format((Val(txtwt.Text) * Val(txtcut.Text.Trim)) / Val(TXTCALCFOLD.Text.Trim) * 100, "0.00") Else txtmtrs.Text = Format(Val(txtwt.Text) * Val(txtcut.Text.Trim), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub txtfbno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfbno.KeyPress
        If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then numkeypress(e, sender, Me)
    End Sub

    Private Sub cmbcolor_Validated(sender As Object, e As EventArgs) Handles cmbcolor.Validated
        Try
            'FETCH COLORTYPE
            If ClientName = "DHANLAXMI" And cmbcolor.Text.Trim <> "" And CMBCOLORTYPE.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(COLOR_TYPE,'MEDIUM') AS COLORTYPE", "", "COLORMASTER ", " AND COLOR_NAME = '" & cmbcolor.Text.Trim & "' AND COLOR_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBCOLORTYPE.Text = DT.Rows(0).Item("COLORTYPE")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT1_Validated(sender As Object, e As EventArgs) Handles CMBMERCHANT1.Validated
        Try
            If CMBMERCHANT1.Text.Trim <> "" And cmbmerchant.Text.Trim = "" Then cmbmerchant.Text = CMBMERCHANT1.Text.Trim

            'WE NEED TO CHANGE THIS MERCHANT IN GRID FOR ALL LINES
            If ClientName = "MONOGRAM" Then
                For Each ROW As DataGridViewRow In GRIDFPS.Rows
                    ROW.Cells(GMERCHANT.Index).Value = CMBMERCHANT1.Text.Trim
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtfbno_Validating(sender As Object, e As CancelEventArgs) Handles txtfbno.Validating
        Try
            If txtfbno.Text.Trim.Length > 0 And (ClientName = "TULSI" Or ClientName = "SHREENATH") Then
                If (edit = False) Or (edit = True And LCase(TEMPFBNO) <> LCase(txtfbno.Text.Trim)) Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As New DataTable
                    dt = objclscommon.search(" FINALPACKINGSLIP.FPS_FBNO AS FBNO", "", " FINALPACKINGSLIP ", " and FINALPACKINGSLIP.FPS_FBNO = '" & txtfbno.Text.Trim & "' AND FINALPACKINGSLIP.FPS_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("F.B. No Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class