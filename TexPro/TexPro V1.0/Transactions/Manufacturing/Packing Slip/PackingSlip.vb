
Imports System.ComponentModel
Imports BL

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class PackingSlip

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPPSNO As Integer     'used for poation no while editing
    Public templotno As Integer     'used for poation no while editing
    Dim temprow As Integer
    Public Shared SELECTPS As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim billcopy As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub gridmfg_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMFG.CellValueChanged
        If GRIDMFG.Rows.Count > 0 And CMBFROM.Text = "WHITE FOLDING" Then
            If Convert.ToDecimal(GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).Value) > 0 Then
                templotno = Convert.ToDecimal(GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).Value)
            End If
        End If
    End Sub

    Sub CLEAR()

        EP.Clear()
        CMDSELECT.Enabled = True

        lbltotalpcs.Text = 0.0
        LBLTOTALBUNDLES.Text = 0.0
        LBLTOTAL.Text = 0.0
        lbltotalmtrs.Text = 0.0
        lblbalmtrs.Text = "0.00"

        PSDATE.Value = Mydate

        TXTBALENO.Clear()
        TXTBALENO.Enabled = True
        TXTORDERNO.Clear()
        TXTJOBNO.Clear()
        TXTFBNO.Clear()
        CMBNAME.Text = ""
        TXTDESC.Clear()
        cmbmerchant.Text = ""
        CMBFROM.Text = ""
        txtremarks.Clear()
        TXTMFGNO.Text = ""
        TXTMFGSRNO.Text = ""
        TXTCHECKNO.Text = ""
        TXTCHECKSRNO.Text = ""
        TXTGRNTYPE.Text = ""
        TXTTYPE.Text = ""
        cmbitemname.Text = "GREY MATERIAL"
        lbllocked.Visible = False
        PBlock.Visible = False
        txtcopy.Clear()
        GRIDMFG.RowCount = 0
        GRIDTOTALFPS.RowCount = 0
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        CHKEXPENSEREPORT.CheckState = CheckState.Unchecked

        CMDSELECT.Enabled = True
        CMBFROM.Enabled = True
        getmaxno()
        If GRIDMFG.RowCount > 0 Then
            txtsrno.Text = Val(GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
    End Sub

    Sub TOTAL()
        Try
            lbltotalpcs.Text = 0.0
            LBLTOTALBUNDLES.Text = 0.0
            LBLTOTAL.Text = 0.0
            lbltotalmtrs.Text = 0.0

            Dim DONE As Boolean = False
            GRIDTOTALFPS.RowCount = 0

            For Each ROW As DataGridViewRow In GRIDMFG.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    ROW.Cells(GTOTALPCS.Index).Value = Format(Val(ROW.Cells(gpcs.Index).EditedFormattedValue) * Val(ROW.Cells(GBUNDLE.Index).EditedFormattedValue), "0.00")
                    If Val(ROW.Cells(GCUT.Index).Value) <> 0 Then
                        ROW.Cells(GTOTALMTRS.Index).Value = Format(Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue) * Val(ROW.Cells(GCUT.Index).EditedFormattedValue), "0.00")
                    End If
                    lbltotalpcs.Text = Format(Val(lbltotalpcs.Text) + Val(ROW.Cells(gpcs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALBUNDLES.Text = Format(Val(LBLTOTALBUNDLES.Text) + Val(ROW.Cells(GBUNDLE.Index).EditedFormattedValue), "0.00")
                    LBLTOTAL.Text = Format(Val(LBLTOTAL.Text) + Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue), "0.00")
                    lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue), "0.00")

                    'DONE BY GULKIT DO NOT REMOVE STRICTLY
                    '********************************************
                    If CMBFROM.Text.Trim = "FINAL CUTTING" Then ROW.Cells(GLOTNO.Index).Value = 0

                    DONE = False
                    If GRIDTOTALFPS.RowCount = 0 Then
                        GRIDTOTALFPS.Rows.Add(ROW.Cells(GMFGNO.Index).EditedFormattedValue, ROW.Cells(gpiecetype.Index).EditedFormattedValue, ROW.Cells(GLOTNO.Index).EditedFormattedValue, ROW.Cells(GTOTALPCS.Index).EditedFormattedValue, ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue)
                    Else
                        For Each DESCROW As DataGridViewRow In GRIDTOTALFPS.Rows
                            If DESCROW.Cells(DESCMFGNO.Index).Value = ROW.Cells(GMFGNO.Index).EditedFormattedValue And DESCROW.Cells(DESCPIECETYPE.Index).Value = ROW.Cells(gpiecetype.Index).EditedFormattedValue And DESCROW.Cells(DESCLOTNO.Index).Value = ROW.Cells(GLOTNO.Index).EditedFormattedValue Then
                                DESCROW.Cells(DESCTOTAL.Index).Value = Val(DESCROW.Cells(DESCTOTAL.Index).Value) + Val(ROW.Cells(GTOTALPCS.Index).EditedFormattedValue)
                                DESCROW.Cells(DESCMTRS.Index).Value = Val(DESCROW.Cells(DESCMTRS.Index).Value) + Val(ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue)
                                DONE = True
                            End If
                        Next
                        If DONE = False Then GRIDTOTALFPS.Rows.Add(ROW.Cells(GMFGNO.Index).EditedFormattedValue, ROW.Cells(gpiecetype.Index).EditedFormattedValue, ROW.Cells(GLOTNO.Index).EditedFormattedValue, ROW.Cells(GTOTALPCS.Index).EditedFormattedValue, ROW.Cells(GTOTALMTRS.Index).EditedFormattedValue)
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
        CMBFROM.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PS_NO),0) + 1 ", " PACKINGSLIP_JOB", " AND PS_cmpid=" & CmpId & " and PS_locationid=" & Locationid & " and PS_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTBALENO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            'If CMBFROM.Text.Trim.Length = 0 Then
            '    EP.SetError(CMBFROM, " Select Process")
            '    bln = False
            'End If

            If TXTFBNO.Text.Trim.Length = 0 Then
                EP.SetError(TXTFBNO, "Please Select FB No.")
                bln = False
            End If

            If cmbmerchant.Text.Trim.Length = 0 Then
                EP.SetError(cmbmerchant, "Please Merchant Name")
                bln = False
            End If

            If GRIDMFG.RowCount = 0 Then
                EP.SetError(CMBFROM, "Please Select Item")
                bln = False
            End If

            If TXTBALENO.Text <> "" And edit = False Then
                Dim OBJcls As New ClsCommon
                Dim DTROW As DataTable = OBJcls.search(" PS_NO", "", " PACKINGSLIP_JOB", " AND PS_NO = '" & TXTBALENO.Text.Trim & "' AND PS_CMPID = " & CmpId & " AND PS_LOCATIONID = " & Locationid & " AND PS_YEARID = " & YearId)
                If DTROW.Rows.Count > 0 Then
                    EP.SetError(TXTBALENO, "Bale No Already Used !")
                    bln = False
                End If
            End If

            'CHECKING STOCK 
            'DONE BY GULKIT DO NOT CHANGE STRICTLY
            TOTAL()
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            For Each ROW As DataGridViewRow In GRIDTOTALFPS.Rows
                If CMBFROM.Text.Trim = "FINAL CUTTING" Then
                    'DT = OBJCMN.search(" SUM(FCP_SAREE - FCP_OUTSAREE ) AS ALLOWEDSAREE, SUM(FCP_MTRS - (FCP_CUT*FCP_OUTSAREE)) AS ALLOWEDMTRS ", "", " FINALCUTTINGPROCESS_PCSDESC INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = PIECETYPEMASTER.PIECETYPE_yearid  ", " AND FCP_NO = " & ROW.Cells(DESCMFGNO.Index).Value & " AND PIECETYPE_NAME = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND FCP_CMPID = " & CmpId & " AND FCP_LOCATIONID = " & Locationid & " AND FCP_YEARID  = " & YearId)

                    ''NEHA
                    DT = OBJCMN.Execute_Any_String(" SELECT SUM(FCP_SAREE - FCP_OUTSAREE ) AS ALLOWEDSAREE, SUM(FCP_MTRS - (FCP_CUT*FCP_OUTSAREE)) AS ALLOWEDMTRS FROM FINALCUTTINGPROCESS_PCSDESC INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = PIECETYPEMASTER.PIECETYPE_yearid  WHERE FCP_NO = " & ROW.Cells(DESCMFGNO.Index).Value & " AND PIECETYPE_NAME = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND FCP_CMPID = " & CmpId & " AND FCP_LOCATIONID = " & Locationid & " AND FCP_YEARID  = " & YearId, "", "")

                ElseIf CMBFROM.Text.Trim = "CUTTING" Then
                    'DT = OBJCMN.search(" SUM(CP_PCS - CP_MFGRECDPCS) AS ALLOWEDSAREE, SUM(CP_MTRS - CP_MFGRECDMTRS) AS ALLOWEDMTRS ", "", " FINALCUTTINGPROCESS_PCSDESC INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = PIECETYPEMASTER.PIECETYPE_yearid  ", " AND FCP_NO = " & ROW.Cells(DESCMFGNO.Index).Value & " AND PIECETYPE_NAME = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND FCP_CMPID = " & CmpId & " AND FCP_LOCATIONID = " & Locationid & " AND FCP_YEARID  = " & YearId)

                    DT = OBJCMN.Execute_Any_String("SELECT SUM(CP_PCS - CP_MFGRECDPCS) AS ALLOWEDSAREE, SUM(CP_MTRS - CP_MFGRECDMTRS) AS ALLOWEDMTRS FROM FINALCUTTINGPROCESS_PCSDESC INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND FINALCUTTINGPROCESS_PCSDESC.FCP_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND FINALCUTTINGPROCESS_PCSDESC.FCP_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND FINALCUTTINGPROCESS_PCSDESC.FCP_YEARID = PIECETYPEMASTER.PIECETYPE_yearid  WHERE FCP_NO = " & ROW.Cells(DESCMFGNO.Index).Value & " AND PIECETYPE_NAME = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND FCP_CMPID = " & CmpId & " AND FCP_LOCATIONID = " & Locationid & " AND FCP_YEARID  = " & YearId, "", "")
                ElseIf CMBFROM.Text = "WHITE FOLDING" Then
                    Dim WHERE As String = ""
                    If ROW.Cells(DESCLOTNO.Index).Value <> "" Then WHERE = " AND LOTNO = " & ROW.Cells(DESCLOTNO.Index).Value
                    'DT = OBJCMN.search("  ROUND(sum(RECDMTRS) - SUM(OUTMTRS),2) AS ALLOWEDMTRS ", "", " PACKINGSLIPVIEW ", WHERE & " AND PROCESSNAME = '" & CMBFROM.Text.Trim & "' AND PIECETYPE = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID  = " & YearId)
                    DT = OBJCMN.Execute_Any_String("SELECT ROUND(sum(RECDMTRS) - SUM(OUTMTRS),2) AS ALLOWEDMTRS FROM PACKINGSLIPVIEW  WHERE PROCESSNAME = '" & CMBFROM.Text.Trim & "' AND PIECETYPE = '" & ROW.Cells(DESCPIECETYPE.Index).Value & "' AND LOCATIONID = 0 AND YEARID  = " & YearId & WHERE, "", "")

                End If
                If DT.Rows.Count > 0 Then
                    If edit = False Then
                        If Val(DT.Rows(0).Item("ALLOWEDMTRS")) = 0 Then GoTo LINE1
                        If CMBFROM.Text.Trim = "FINAL CUTTING" Then
                            If Val(ROW.Cells(DESCTOTAL.Index).Value) > Val(DT.Rows(0).Item("ALLOWEDSAREE")) Then
                                EP.SetError(cmbmerchant, "Sarees in Cutting No " & ROW.Cells(DESCMFGNO.Index).Value & " Exceeds Stock, Max " & DT.Rows(0).Item("ALLOWEDSAREE") & " Allowed")
                                bln = False
                            End If
                        Else
                            If Val(ROW.Cells(DESCMTRS.Index).Value) > Val(DT.Rows(0).Item("ALLOWEDMTRS")) Then
                                EP.SetError(cmbmerchant, "Mtrs in Mfg No " & ROW.Cells(DESCMFGNO.Index).Value & " Exceeds Stock, Max " & DT.Rows(0).Item("ALLOWEDMTRS") & " Allowed")
                                bln = False
                            End If
                        End If
                    End If
                Else
LINE1:
                    EP.SetError(cmbmerchant, "Item in Mfg/Cutting No " & ROW.Cells(DESCMFGNO.Index).Value & " not present in Stock")
                    bln = False
                End If
            Next


            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Job Out Raised, Delete Job Out First")
                bln = False
            End If


            'Dim objclscommon As New ClsCommonMaster
            'Dim dt As DataTable
            'If TXTJOBNO.Text.Trim <> "" Then

            'Else
            '    For Each ROW As DataGridViewRow In GRIDMFG.Rows

            '    Next
            '    'dt = objclscommon.search(" MTRS ", "", " VIEW_SUMMARY_MFG1 ", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO=" & ROW.Cells(GLOTNO.Index).VALUE & "    and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
            '    If dt.Rows.Count > 0 Then

            '    End If
            'End If
            For Each row As DataGridViewRow In GRIDMFG.Rows
                If Val(row.Cells(GTOTALMTRS.Index).Value) = 0 Then
                    EP.SetError(txtmtrs, "Please Select Item")
                    bln = False
                End If


                If Val(row.Cells(GTOTALPCS.Index).Value) = 0 Then
                    EP.SetError(txtmtrs, "Please Write Proper Pcs and Bundle")
                    bln = False
                End If
            Next
            'If Not datecheck(PSDATE.Value) Then bln = False

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

            alParaval.Add(TXTBALENO.Text.Trim)
            alParaval.Add(PSDATE.Value)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(cmbmerchant.Text.Trim)
            alParaval.Add(CMBFROM.Text.Trim)
            alParaval.Add(TXTFBNO.Text.Trim)
            alParaval.Add(TXTJOBNO.Text.Trim)
            alParaval.Add(TXTORDERNO.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)


            alParaval.Add(Val(lbltotalpcs.Text))
            alParaval.Add(Val(LBLTOTALBUNDLES.Text))
            alParaval.Add(Val(LBLTOTAL.Text))
            alParaval.Add(Val(lbltotalmtrs.Text))

            alParaval.Add(txtremarks.Text.Trim)

            If CHKEXPENSEREPORT.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(0)
            alParaval.Add(0)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim gridremarks As String = ""
            Dim ITEMNAME As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""
            Dim QUALITY As String = ""
            Dim COLOR As String = ""
            Dim PCS As String = ""
            Dim BUNDLE As String = ""
            Dim TOTALPCS As String = ""
            Dim MTRS As String = ""
            Dim DONE As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim TYPE As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim CHECKNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim CHECKGRIDSRNO As String = ""    'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGNO As String = ""            'WHETHER GRN IS DONE FOR THIS LINE
            Dim MFGSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim LOTNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim LOTSRNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRNTYPE As String = ""          'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDMFG.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(gpiecetype.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        PCS = row.Cells(gpcs.Index).Value.ToString
                        BUNDLE = row.Cells(GBUNDLE.Index).Value.ToString
                        TOTALPCS = row.Cells(GTOTALPCS.Index).Value.ToString
                        MTRS = row.Cells(GTOTALMTRS.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = "1"
                        Else
                            DONE = "0"
                        End If
                        TYPE = row.Cells(GMFGTYPE.Index).Value.ToString
                        CHECKNO = row.Cells(GCHECKNO.Index).Value
                        CHECKGRIDSRNO = row.Cells(GCHECKSRNO.Index).Value
                        MFGNO = row.Cells(GMFGNO.Index).Value
                        MFGSRNO = row.Cells(GMFGSRNO.Index).Value
                        LOTSRNO = row.Cells(GLOTSRNO.Index).Value
                        GRNTYPE = row.Cells(GGRNTYPE.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "|" & row.Cells(gpiecetype.Index).Value
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString

                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(GCUT.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        PCS = PCS & "|" & row.Cells(gpcs.Index).Value.ToString
                        BUNDLE = BUNDLE & "|" & row.Cells(GBUNDLE.Index).Value.ToString
                        TOTALPCS = TOTALPCS & "|" & row.Cells(GTOTALPCS.Index).Value.ToString

                        MTRS = MTRS & "|" & row.Cells(GTOTALMTRS.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        TYPE = TYPE & "|" & row.Cells(GMFGTYPE.Index).Value
                        CHECKNO = CHECKNO & "|" & row.Cells(GCHECKNO.Index).Value
                        CHECKGRIDSRNO = CHECKGRIDSRNO & "|" & row.Cells(GCHECKSRNO.Index).Value
                        MFGNO = MFGNO & "|" & row.Cells(GMFGNO.Index).Value
                        MFGSRNO = MFGSRNO & "|" & row.Cells(GMFGSRNO.Index).Value
                        LOTSRNO = LOTSRNO & "|" & row.Cells(GLOTSRNO.Index).Value
                        GRNTYPE = GRNTYPE & "|" & row.Cells(GGRNTYPE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(gridremarks)
            alParaval.Add(ITEMNAME)
            alParaval.Add(CUT)
            alParaval.Add(DESIGN)
            alParaval.Add(QUALITY)
            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(PCS)
            alParaval.Add(BUNDLE)
            alParaval.Add(TOTALPCS)
            alParaval.Add(MTRS)
            alParaval.Add(DONE)
            alParaval.Add(TYPE)
            alParaval.Add(CHECKNO)
            alParaval.Add(CHECKGRIDSRNO)
            alParaval.Add(MFGNO)
            alParaval.Add(MFGSRNO)
            alParaval.Add(LOTSRNO)
            alParaval.Add(GRNTYPE)

            Dim OBJPS As New ClsPSJob
            OBJPS.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJPS.SAVE()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPSNO)

                IntResult = OBJPS.Update()
                MsgBox("Details Updated")

            End If
            edit = False
            TXTBALENO.Enabled = True
            TEMPMSG = MsgBox("Wish to Print Packing?", MsgBoxStyle.YesNo)
            'serverprop()
            If TEMPMSG = vbYes Then
                Dim OBJGRN As New JODESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "PSJOB"
                OBJGRN.FORMULA = "{packingslip_job.ps_NO}=" & TXTBALENO.Text & " and {packingslip_job.ps_cmpid}=" & CmpId & " and {packingslip_job.ps_locationid}=" & Locationid & " and {packingslip_job.ps_yearid}=" & YearId
                OBJGRN.Show()
            End If
            clear()
            CMBFROM.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CALCLOTBAL(ByVal LOTNO As Integer)
        Try

            lblbalmtrs.Text = 0
            Dim objclscommon As New ClsCommon
            Dim dt1 As DataTable = objclscommon.Execute_Any_String(" SELECT isnull(sum(mtrs),0) FROM VIEW_SUMMARY_MFG1 WHERE LOTNO='" & LOTNO & "'  AND yearid = " & YearId, "", "")
            If dt1.Rows.Count > 0 Then
                lblbalmtrs.Text = Format(Val(dt1.Rows(0).Item(0)), "0.00")
                For Each ROW As DataGridViewRow In GRIDMFG.Rows
                    If LOTNO = ROW.Cells(GLOTNO.Index).Value Then
                        lblbalmtrs.Text = lblbalmtrs.Text - ROW.Cells(GTOTALMTRS.Index).Value
                    End If
                Next
                If gridDoubleClick = True Then lblbalmtrs.Text = Val(lblbalmtrs.Text) + Val(GRIDMFG.Item(GTOTALMTRS.Index, temprow).Value)

                'lblbalmtrs.Text = Format(Val(lblbalmtrs.Text) + Val(dt1.Rows(0).Item(0)), "0.00")

                'For Each ROW As DataGridViewRow In GRIDMFG.Rows
                'If LOTNO = ROW.Cells(GLOTNO.Index).Value Then
                'lblbalmtrs.Text = Format(Val(dt1.Rows(0).Item(0)), "0.00")
                'End If
                '   Next

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        Dim objgp As New JODESIGN
        Dim RPTPSJOB As New psjobreport

        Cursor.Current = Cursors.WaitCursor

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

        crTables = RPTPSJOB.Database.Tables

        For Each crTable In crTables
            crtableLogonInfo = crTable.LogOnInfo
            crtableLogonInfo.ConnectionInfo = crConnecttionInfo
            crTable.ApplyLogOnInfo(crtableLogonInfo)
        Next


        '************************ END *******************

        objgp.MdiParent = MDIMain
        RPTPSJOB.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
        RPTPSJOB.RecordSelectionFormula = "{packingslip_job.ps_NO}=" & TXTBALENO.Text & " and {packingslip_job.ps_cmpid}=" & CmpId & " and {packingslip_job.ps_locationid}=" & Locationid & " and {packingslip_job.ps_yearid}=" & YearId
        RPTPSJOB.PrintToPrinter(1, True, 0, 0)

    End Sub

    Private Sub PackingSlip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PackingSlip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
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

            FILLCMB()
            clear()

            If edit = False Then
                TXTBALENO.Enabled = True
            Else
                TXTBALENO.Enabled = False
            End If

            If edit = True Or billcopy = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsPSJob()
                Dim ALPARAVAL As New ArrayList

                Dim dttable As New DataTable

                ALPARAVAL.Add(TEMPPSNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCHECKING.alParaval = ALPARAVAL
                dttable = OBJCHECKING.selectPS()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        PSDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBFROM.Text = Convert.ToString(dr("PROCESS").ToString)
                        TXTFBNO.Text = Convert.ToString(dr("FBNO").ToString)
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        cmbmerchant.Text = Convert.ToString(dr("MERCHANT").ToString)
                        CHKEXPENSEREPORT.Checked = Convert.ToBoolean(dr("EXPENSEREPORT"))
                        TXTJOBNO.Text = Convert.ToString(dr("JOBNO").ToString)
                        TXTORDERNO.Text = Convert.ToString(dr("ORDERNO").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)


                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        If billcopy = False Then
                            GRIDMFG.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("DESC").ToString, dr("ITEMNAME"), Format(dr("CUT"), "0.00"), dr("DESIGNNO"), dr("QUALITY"), dr("COLOR"), dr("LOTNO"), Format(dr("PCS"), "0.00"), Format(dr("BUNDLE"), "0.00"), Format(dr("TOTAL"), "0.00"), Format(dr("MTRS"), "0.00"), dr("GRIDDONE").ToString, dr("TYPE"), dr("CHECKNO"), dr("CHECKSRNO"), dr("MFGNO"), dr("MFGSRNO"), dr("LOTSRNO"), dr("GRNTYPE"))
                            TXTBALENO.Text = TEMPPSNO
                            If Convert.ToBoolean(dr("DONE")) = True Or Convert.ToBoolean(dr("JODONE")) = True Then
                                lbllocked.Visible = True
                                PBlock.Visible = True
                                GRIDMFG.Rows(GRIDMFG.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            'If dr("CUT") > 0 Then
                            '    GRIDMFG.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("DESC").ToString, dr("ITEMNAME"), Format(dr("CUT"), "0.00"), dr("DESIGNNO"), dr("QUALITY"), dr("COLOR"), dr("LOTNO"), Format(dr("PCS"), "0.00"), Format(dr("BUNDLE"), "0.00"), Format(dr("TOTAL"), "0.00"), Format(dr("TOTAL") * dr("cut"), "0.00"), 0, dr("TYPE"), dr("CHECKNO"), dr("CHECKSRNO"), dr("MFGNO"), dr("MFGSRNO"), dr("LOTSRNO"), dr("GRNTYPE"))
                            'Else
                            GRIDMFG.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("DESC").ToString, dr("ITEMNAME"), Format(dr("CUT"), "0.00"), dr("DESIGNNO"), dr("QUALITY"), dr("COLOR"), dr("LOTNO"), Format(dr("PCS"), "0.00"), Format(dr("BUNDLE"), "0.00"), Format(dr("TOTAL"), "0.00"), 0, 0, dr("TYPE"), dr("CHECKNO"), dr("CHECKSRNO"), dr("MFGNO"), dr("MFGSRNO"), dr("LOTSRNO"), dr("GRNTYPE"))
                            'End If
                        End If
                    Next
                    'CMBFROM.Enabled = False
                    TOTAL()
                End If
                chkchange.CheckState = CheckState.Checked
            End If
            billcopy = False
            If GRIDMFG.RowCount > 0 Then
                txtsrno.Text = Val(GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If CMBFROM.Text.Trim = "" Then FILLPROCESS(CMBFROM, " AND PROCESSMASTER.PROCESS_NAME IN ('WHITE FOLDING','FINAL CUTTING')", edit)
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " and ITEM_FRMSTRING='MERCHANT'")
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " and ITEM_FRMSTRING='MERCHANT'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")


            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
            fillDESIGN(cmbdesign, cmbmerchant.Text)
            fillCOLOR(cmbcolor)
            FILLGODOWN(CMBGODOWN, False)



        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDMFG.Enabled = True

        If gridDoubleClick = True Then
            GRIDMFG.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDMFG.Item(gpiecetype.Index, temprow).Value = cmbpiecetype.Text.Trim
            GRIDMFG.Item(gdesc.Index, temprow).Value = TXTDESC.Text.Trim
            GRIDMFG.Item(GMERCHANT.Index, temprow).Value = cmbitemname.Text.Trim

            GRIDMFG.Item(GDESIGN.Index, temprow).Value = cmbdesign.Text.Trim

            GRIDMFG.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim
            GRIDMFG.Item(GCUT.Index, temprow).Value = txtcut.Text.Trim
            GRIDMFG.Item(GLOTNO.Index, temprow).Value = CMBLOTNO.Text.Trim
            GRIDMFG.Item(gpcs.Index, temprow).Value = Format(Val(txtpcs.Text.Trim), "0.00")
            GRIDMFG.Item(GBUNDLE.Index, temprow).Value = Format(Val(txtbundle.Text.Trim), "0.00")
            GRIDMFG.Item(GTOTALPCS.Index, temprow).Value = Format(Val(txttotal.Text.Trim), "0.00")
            GRIDMFG.Item(GTOTALMTRS.Index, temprow).Value = Format(Val(txtmtrs.Text.Trim), "0.00")
            GRIDMFG.Item(GMFGNO.Index, temprow).Value = Val(TXTMFGNO.Text.Trim)
            GRIDMFG.Item(GMFGSRNO.Index, temprow).Value = Val(TXTMFGSRNO.Text.Trim)
            GRIDMFG.Item(GQUALITY.Index, temprow).Value = cmbquality.Text.Trim
            GRIDMFG.Item(GGRNTYPE.Index, temprow).Value = TXTGRNTYPE.Text.Trim
            GRIDMFG.Item(GMFGTYPE.Index, temprow).Value = TXTTYPE.Text.Trim
            gridDoubleClick = False
        Else
            If Val(txtmtrs.Text) <> 0 Then GRIDMFG.Rows.Add(Val(txtsrno.Text), cmbpiecetype.Text.Trim, TXTDESC.Text.Trim, cmbmerchant.Text.Trim, txtcut.Text.Trim, cmbdesign.Text.Trim, cmbquality.Text.Trim, cmbcolor.Text.Trim, CMBLOTNO.Text.Trim, txtpcs.Text.Trim, txtbundle.Text.Trim, txttotal.Text.Trim, Val(txtmtrs.Text.Trim), 0, TXTTYPE.Text, TXTCHECKNO.Text, TXTCHECKSRNO.Text, TXTMFGNO.Text, TXTMFGSRNO.Text, TXTLOTSRNO.Text, TXTGRNTYPE.Text.Trim)
        End If

        GRIDMFG.FirstDisplayedScrollingRowIndex = GRIDMFG.RowCount - 1

        txtsrno.Clear()
        getsrno(GRIDMFG)
        cmbcolor.Text = ""
        TXTDESC.Clear()
        cmbdesign.Text = ""
        txtpcs.Clear()
        txttotal.Clear()
        txtbundle.Clear()
        txtcut.Clear()
        txtmtrs.Clear()

        TXTTYPE.Clear()
        TXTMFGSRNO.Clear()
        If GRIDMFG.RowCount > 0 Then
            txtsrno.Text = Val(GRIDMFG.Rows(GRIDMFG.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        txtsrno.Focus()

    End Sub

    Private Sub GRIDMFG_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMFG.CellDoubleClick
        If e.RowIndex >= 0 And GRIDMFG.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            'If Convert.ToBoolean(GRIDMFG.Rows(e.RowIndex).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
            '    MsgBox("Item Locked. First Delete from GRN")
            '    Exit Sub
            'End If


            gridDoubleClick = True
            txtsrno.Text = GRIDMFG.Item(gsrno.Index, e.RowIndex).Value.ToString
            TXTDESC.Text = GRIDMFG.Item(gdesc.Index, e.RowIndex).Value.ToString
            cmbitemname.Text = GRIDMFG.Item(GMERCHANT.Index, e.RowIndex).Value.ToString
            CMBLOTNO.Text = GRIDMFG.Item(GLOTNO.Index, e.RowIndex).Value.ToString

            cmbpiecetype.Text = GRIDMFG.Item(gpiecetype.Index, e.RowIndex).Value.ToString
            cmbdesign.Text = GRIDMFG.Item(GDESIGN.Index, e.RowIndex).Value.ToString

            cmbcolor.Text = GRIDMFG.Item(gcolor.Index, e.RowIndex).Value.ToString
            txtcut.Text = GRIDMFG.Item(GCUT.Index, e.RowIndex).Value.ToString

            txtpcs.Text = GRIDMFG.Item(gpcs.Index, e.RowIndex).Value.ToString
            txttotal.Text = GRIDMFG.Item(GTOTALPCS.Index, e.RowIndex).Value.ToString
            txtbundle.Text = GRIDMFG.Item(GBUNDLE.Index, e.RowIndex).Value.ToString
            txtmtrs.Text = GRIDMFG.Item(GTOTALMTRS.Index, e.RowIndex).Value.ToString

            TXTTYPE.Text = GRIDMFG.Item(GMFGTYPE.Index, e.RowIndex).Value
            TXTMFGNO.Text = GRIDMFG.Item(GMFGNO.Index, e.RowIndex).Value
            TXTMFGSRNO.Text = GRIDMFG.Item(GMFGSRNO.Index, e.RowIndex).Value
            TXTLOTSRNO.Text = GRIDMFG.Item(GLOTSRNO.Index, e.RowIndex).Value
            TXTCHECKNO.Text = GRIDMFG.Item(GCHECKNO.Index, e.RowIndex).Value
            TXTCHECKSRNO.Text = GRIDMFG.Item(GCHECKSRNO.Index, e.RowIndex).Value
            TXTGRNTYPE.Text = GRIDMFG.Item(GGRNTYPE.Index, e.RowIndex).Value


            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJPSDETAILS As New PackingSlipDetails
            OBJPSDETAILS.MdiParent = MDIMain
            OBJPSDETAILS.Show()
            OBJPSDETAILS.BringToFront()
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

            SELECTPS.Clear()
            Dim OBJSELECTPS As New SelectMfgforPS
            OBJSELECTPS.FRMSTRING = "MFG"
            OBJSELECTPS.PROCESSNAME = CMBFROM.Text.Trim
            OBJSELECTPS.ShowDialog()


            Dim i As Integer = 0
            If SELECTPS.Rows.Count > 0 Then

                chkchange.Checked = True
                'If edit = False Then GRIDMFG.RowCount = 0


                For Each DTROW As DataRow In SELECTPS.Rows
                    GRIDMFG.Rows.Add(0, DTROW("PIECETYPE"), "", DTROW("ITEMNAME"), DTROW("CUT"), DTROW("DESIGNNO"), DTROW("QUALITY"), DTROW("COLOR"), DTROW("LOTNO"), DTROW("PCS"), 1, DTROW("saree"), Format(Val(DTROW("MTRS")), "0.00"), 0, DTROW("TYPE"), DTROW("CHECKNO"), DTROW("CHECKSRNO"), DTROW("MFGNO"), DTROW("MFGSRNO"), DTROW("LOTSRNO"), DTROW("GRNTYPE"))
                Next

                Dim DV As DataView = SELECTPS.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "JOBNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTJOBNO.Text.Trim = "" Then
                        TXTJOBNO.Text = DTR("JOBNO").ToString
                    Else
                        TXTJOBNO.Text = TXTJOBNO.Text & "," & DTR("JOBNO").ToString
                    End If
                Next

                getsrno(GRIDMFG)
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
            TEMPPSNO = Val(tstxtbillno.Text)
            If TEMPPSNO > 0 Then
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
            GRIDMFG.RowCount = 0

            TEMPPSNO = Val(TXTBALENO.Text) - 1
            If TEMPPSNO > 0 Then
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
            TEMPPSNO = Val(TXTBALENO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTBALENO.Text) - 1 >= TEMPPSNO Then
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
                    MsgBox("Despatch Raised against this Packing Slip,Please Delete Despatch First?")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete MFG?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPPSNO)
                    alParaval.Add(Userid)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)
                    alParaval.Add(CMBFROM.Text.Trim)

                    Dim OBJMFG As New ClsPSJob()
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

                Case gpcs.Index, GCUT.Index, GBUNDLE.Index, GTOTALMTRS.Index, GLOTNO.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDMFG.CurrentCell.Value = Nothing Then GRIDMFG.CurrentCell.Value = "0.00"
                        GRIDMFG.CurrentCell.Value = Convert.ToDecimal(GRIDMFG.Item(colNum, e.RowIndex).Value)

                        'DONE BY GULKIT
                        'If e.ColumnIndex = GTOTALMTRS.Index Or e.ColumnIndex = GLOTNO.Index Then
                        '    Dim tempsrno As String = "0"


                        '    For Each row As DataGridViewRow In GRIDMFG.Rows

                        '        If tempsrno = "0" Then
                        '            tempsrno = row.Cells(GMFGSRNO.Index).Value
                        '        ElseIf Convert.ToDecimal(row.Cells(GMFGSRNO.Index).Value) <> 0 Then
                        '            tempsrno = tempsrno & "," & row.Cells(GMFGSRNO.Index).Value

                        '        End If




                        '    Next
                        '    If CMBFROM.Text = "WHITE FOLDING" Then
                        '        CALCLOTBAL(GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue)
                        '        If templotno = GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue And edit = True Then Exit Sub
                        '    End If
                        '    If GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue > 0 Then
                        '        Dim objclscommon As New ClsCommonMaster
                        '        Dim dt As DataTable
                        '        If lblbalmtrs.Text < -50 And CMBFROM.Text = "WHITE FOLDING" Then
                        '            MsgBox("No Mtrs Found in this lot")
                        '            e.Cancel = True
                        '            Exit Sub
                        '        End If

                        '        If tempsrno = "" Then
                        '            dt = objclscommon.search(" DISTINCT MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue & "' AND RECDMTRS-OUTMTRS=" & GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                        '        Else
                        '            dt = objclscommon.search(" DISTINCT MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue & "' AND MFGSRNO NOT IN (" & tempsrno & ")  AND RECDMTRS-OUTMTRS=" & GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                        '        End If

                        '        If dt.Rows.Count > 0 Then

                        '            GRIDMFG.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '            GRIDMFG.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = dt.Rows(0).Item(1)
                        '            GRIDMFG.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(2)
                        '            GRIDMFG.Rows(e.RowIndex).Cells(GGRNTYPE.Index).Value = dt.Rows(0).Item(3)


                        '        Else

                        '            dt = objclscommon.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue & "' AND MFGSRNO NOT IN (" & tempsrno & ") AND RECDMTRS-OUTMTRS <" & Val(GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS desc")

                        '            If dt.Rows.Count > 0 Then
                        '                GRIDMFG.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '                GRIDMFG.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = dt.Rows(0).Item(1)
                        '                GRIDMFG.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(2)
                        '                GRIDMFG.Rows(e.RowIndex).Cells(GGRNTYPE.Index).Value = dt.Rows(0).Item(3)

                        '            Else

                        '                dt = objclscommon.search("  MFGSRNO,MFGNO,QUALITY ,GRNTYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).Value & "' AND MFGSRNO NOT IN (" & tempsrno & ") AND RECDMTRS-OUTMTRS >" & Val(GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS")

                        '                If dt.Rows.Count > 0 Then
                        '                    GRIDMFG.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '                    GRIDMFG.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = dt.Rows(0).Item(1)
                        '                    GRIDMFG.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(2)
                        '                    GRIDMFG.Rows(e.RowIndex).Cells(GGRNTYPE.Index).Value = dt.Rows(0).Item(3)
                        '                Else

                        '                    dt = objclscommon.search("  GRIDSRNO,QUALITY ,TYPE ", "", " OPENINGSTOCK_VIEW ", "  AND PROCESS='" & CMBFROM.Text & "'  AND LOTNO='" & GRIDMFG.Rows(e.RowIndex).Cells(GLOTNO.Index).EditedFormattedValue & "' AND gridsrno NOT IN (" & tempsrno & ") AND MTRS-OUTMTRS >" & Val(GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).EditedFormattedValue) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by MTRS")


                        '                    If dt.Rows.Count > 0 Then
                        '                        GRIDMFG.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = dt.Rows(0).Item(0)
                        '                        GRIDMFG.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = 0
                        '                        GRIDMFG.Rows(e.RowIndex).Cells(GGRNTYPE.Index).Value = dt.Rows(0).Item(2)
                        '                        GRIDMFG.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = dt.Rows(0).Item(1)
                        '                    Else
                        '                        '
                        '                        If Val(lblbalmtrs.Text) < -50 Then
                        '                            e.Cancel = True
                        '                            MsgBox("No Match Found in " & CMBFROM.Text & " Process")
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).Value = 0
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = 0
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = 0
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = ""
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GGRNTYPE.Index).Value = ""

                        '                        Else
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GTOTALMTRS.Index).Value = 0
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GMFGSRNO.Index).Value = 0
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GMFGNO.Index).Value = 0
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GQUALITY.Index).Value = ""
                        '                            GRIDMFG.Rows(e.RowIndex).Cells(GGRNTYPE.Index).Value = ""
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

    Private Sub GRIDMFG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDMFG.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMFG.RowCount > 0 Then

                GRIDMFG.Rows.RemoveAt(GRIDMFG.CurrentRow.Index)
                getsrno(GRIDMFG)

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

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then

                'serverprop()
                Dim OBJGRN As New JODESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "PSJOB"
                OBJGRN.FORMULA = "{packingslip_job.ps_NO}=" & TEMPPSNO & " and {packingslip_job.ps_cmpid}=" & CmpId & " and {packingslip_job.ps_locationid}=" & Locationid & " and {packingslip_job.ps_yearid}=" & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLOTNO.Enter
        Try

            If CMBLOTNO.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                ' as per gulkit bhai instruction for checking purpose i m removing the process name from where clouse from (validating and enter event) on 07.05.14 done by vijay
                'dt = objclscommon.search(" DISTINCT LOTNO ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "' and yearid = " & YearId)
                dt = objclscommon.search(" DISTINCT LOTNO ", "", " PACKINGSLIPVIEW", "  and yearid = " & YearId)
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

    Private Sub txtmtrs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmtrs.Validated
        Try
            If Val(txtbundle.Text.Trim) = 0 Then txtbundle.Text = 1
            If Val(txtpcs.Text.Trim) > 0 And Val(txtmtrs.Text.Trim) > 0 Then
                If Val(lblbalmtrs.Text) < -50 And CMBFROM.Text = "WHITE FOLDING" Then
                    MsgBox("No Mtrs Found in this lot", MsgBoxStyle.Critical)

                    Exit Sub
                End If
                fillgrid()
                TOTAL()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtmtrs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmtrs.Validating

        Try
            If Val(txtbundle.Text.Trim) = 0 Then txtbundle.Text = 1
            If cmbpiecetype.Text.Trim <> "" And cmbmerchant.Text.Trim <> "" And Val(txtpcs.Text.Trim) > 0 And Val(txtmtrs.Text.Trim) > 0 Then


                'DONE BY GULKIT FROM HERE 
                'If gridDoubleClick = True Then
                '    If CMBLOTNO.Text <> "" Then
                '        If CMBLOTNO.Text = GRIDMFG.Rows(temprow).Cells(GLOTNO.Index).Value Then Exit Sub
                '    Else
                '        If cmbdesign.Text = GRIDMFG.Rows(temprow).Cells(GDESIGN.Index).Value Then Exit Sub
                '    End If
                'End If

                'Dim tempsrno As String = "0"

                'For Each row As DataGridViewRow In GRIDMFG.Rows
                '    If CMBLOTNO.Text = row.Cells(GLOTNO.Index).Value Then
                '        If tempsrno = "0" Then
                '            tempsrno = row.Cells(GMFGSRNO.Index).Value
                '        ElseIf row.Cells(GMFGSRNO.Index).Value <> "" Then
                '            tempsrno = tempsrno & "," & row.Cells(GMFGSRNO.Index).Value

                '        End If
                '    End If
                'Next



                'Dim objclscommon As New ClsCommonMaster
                'Dim dt As DataTable
                'If cmbdesign.Text <> "" Then
                '    dt = objclscommon.search("  DISTINCT MFGSRNO,MFGNO,QUALITY,GRNTYPE,CHECKNO,CHECKSRNO,TYPE", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND DESIGNNO='" & cmbdesign.Text & "'   AND RECDMTRS-OUTMTRS=" & txtmtrs.Text & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                'Else
                '    dt = objclscommon.search(" DISTINCT MFGSRNO,MFGNO,QUALITY,GRNTYPE,CHECKNO,CHECKSRNO,TYPE ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & CMBLOTNO.Text & "'   and mfgsrno not in (" & tempsrno & ")   AND RECDMTRS-OUTMTRS=" & txtmtrs.Text & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                'End If
                'If dt.Rows.Count > 0 Then

                '    TXTMFGSRNO.Text = dt.Rows(0).Item("MFGSRNO")
                '    TXTMFGNO.Text = dt.Rows(0).Item("MFGNO")
                '    cmbquality.Text = dt.Rows(0).Item("QUALITY")
                '    TXTTYPE.Text = dt.Rows(0).Item("TYPE")
                '    TXTGRNTYPE.Text = dt.Rows(0).Item("GRNTYPE")
                '    TXTCHECKNO.Text = dt.Rows(0).Item("CHECKNO")
                '    TXTCHECKSRNO.Text = dt.Rows(0).Item("CHECKSRNO")

                'Else
                '    If cmbdesign.Text <> "" Then
                '        dt = objclscommon.search("  MFGSRNO,MFGNO,QUALITY,GRNTYPE,CHECKNO,CHECKSRNO,TYPE  ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND DESIGNNO='" & cmbdesign.Text & "'  AND RECDMTRS-OUTMTRS >" & Val(txtmtrs.Text) & " AND   cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS")

                '    Else
                '        dt = objclscommon.search("  MFGSRNO,MFGNO,QUALITY,GRNTYPE,CHECKNO,CHECKSRNO,TYPE  ", "", " PACKINGSLIPVIEW", "  AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & CMBLOTNO.Text & "'  and mfgsrno not in (" & tempsrno & ")   AND RECDMTRS-OUTMTRS >" & Val(txtmtrs.Text) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS")

                '    End If

                '    If dt.Rows.Count > 0 Then
                '        TXTMFGSRNO.Text = dt.Rows(0).Item("MFGSRNO")
                '        TXTMFGNO.Text = dt.Rows(0).Item("MFGNO")
                '        cmbquality.Text = dt.Rows(0).Item("QUALITY")
                '        TXTTYPE.Text = dt.Rows(0).Item("TYPE")
                '        TXTGRNTYPE.Text = dt.Rows(0).Item("GRNTYPE")
                '        TXTCHECKNO.Text = dt.Rows(0).Item("CHECKNO")
                '        TXTCHECKSRNO.Text = dt.Rows(0).Item("CHECKSRNO")
                '    Else
                '        If cmbdesign.Text <> "" Then

                '            dt = objclscommon.search("  MFGSRNO,MFGNO,QUALITY,GRNTYPE,CHECKNO,CHECKSRNO ,TYPE ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME='" & CMBFROM.Text & "'  AND DESIGNNO='" & cmbdesign.Text & "'  AND RECDMTRS-OUTMTRS <" & Val(txtmtrs.Text) & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS desc")
                '        Else
                '            dt = objclscommon.search("  MFGSRNO,MFGNO,QUALITY,GRNTYPE,CHECKNO,CHECKSRNO ,TYPE ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME='" & CMBFROM.Text & "'  AND LOTNO='" & CMBLOTNO.Text & "'  AND RECDMTRS-OUTMTRS <" & Val(txtmtrs.Text) & " AND MFGSRNO NOT IN (" & tempsrno & ") and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by RECDMTRS desc")
                '        End If
                '        If dt.Rows.Count > 0 Then
                '            TXTMFGSRNO.Text = dt.Rows(0).Item("MFGSRNO")
                '            TXTMFGNO.Text = dt.Rows(0).Item("MFGNO")
                '            cmbquality.Text = dt.Rows(0).Item("QUALITY")
                '            TXTTYPE.Text = dt.Rows(0).Item("TYPE")
                '            TXTGRNTYPE.Text = dt.Rows(0).Item("GRNTYPE")
                '            TXTCHECKNO.Text = dt.Rows(0).Item("CHECKNO")
                '            TXTCHECKSRNO.Text = dt.Rows(0).Item("CHECKSRNO")
                '        Else
                '            If cmbdesign.Text <> "" Then
                '                dt = objclscommon.search("  GRIDSRNO,QUALITY,TYPE ", "", " OPENINGSTOCK_VIEW ", "  AND PROCESS='" & CMBFROM.Text & "'  AND DESIGN='" & cmbdesign.Text & "'  AND MTRS-OUTMTRS >" & Val(txtmtrs.Text) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by MTRS")
                '            Else
                '                dt = objclscommon.search("  GRIDSRNO,QUALITY,TYPE ", "", " OPENINGSTOCK_VIEW ", "  AND PROCESS='" & CMBFROM.Text & "'  AND LOTNO='" & CMBLOTNO.Text & "'  AND MTRS-OUTMTRS >" & Val(txtmtrs.Text) & "  and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId & " order by MTRS")
                '            End If
                '            If dt.Rows.Count > 0 Then
                '                TXTMFGSRNO.Text = dt.Rows(0).Item("GRIDSRNO")
                '                TXTMFGNO.Text = 0
                '                cmbquality.Text = dt.Rows(0).Item("QUALITY")
                '                TXTTYPE.Text = "OPENING"
                '                TXTGRNTYPE.Text = dt.Rows(0).Item("TYPE")
                '                TXTCHECKNO.Text = 0
                '                TXTCHECKSRNO.Text = 0
                '            Else
                '                If Val(lblbalmtrs.Text) < -50 Then
                '                    MsgBox("nO Match Found, Enter Proper Details")
                '                    e.Cancel = True
                '                    TXTMFGSRNO.Text = 0
                '                    TXTMFGNO.Text = 0
                '                    TXTCHECKSRNO.Text = 0
                '                    TXTCHECKNO.Text = 0
                '                    cmbquality.Text = ""
                '                    TXTTYPE.Text = ""
                '                    TXTGRNTYPE.Text = ""
                '                Else
                '                    TXTMFGSRNO.Text = 0
                '                    TXTMFGNO.Text = 0
                '                    TXTCHECKSRNO.Text = 0
                '                    TXTCHECKNO.Text = 0
                '                    cmbquality.Text = ""
                '                    TXTTYPE.Text = ""
                '                    TXTGRNTYPE.Text = ""
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


    Private Sub txtbundle_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbundle.Validating
        Try
            If Val(txtpcs.Text.Trim) > 0 And Val(txtbundle.Text.Trim) > 0 Then
                txttotal.Text = Val(txtpcs.Text.Trim) * Val(txtbundle.Text.Trim)
                If Val(txtcut.Text.Trim) > 0 Then
                    txtmtrs.Text = Val(txttotal.Text.Trim) * Val(txtcut.Text.Trim)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpcs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpcs.Validating
        Try
            If Val(txtpcs.Text.Trim) > 0 And Val(txtbundle.Text.Trim) > 0 Then
                txttotal.Text = Val(txtpcs.Text.Trim) * Val(txtbundle.Text.Trim)
                If Val(txtcut.Text.Trim) > 0 Then
                    txtmtrs.Text = Val(txttotal.Text.Trim) * Val(txtcut.Text.Trim)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBLOTNO.Validated
        Try
            'GET MFGNO AND MFGSRNO FROM PACKINGSLIPVIEW
            If CMBFROM.Text.Trim = "WHITE FOLDING" And CMBLOTNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search(" MFGNO, MFGSRNO, CHECKNO, CHECKSRNO, LOTSRNO, GRNTYPE, TYPE", "", " PACKINGSLIPVIEW", " AND LOTNO = '" & CMBLOTNO.Text.Trim & "' AND PIECETYPE = '" & cmbpiecetype.Text.Trim & "' AND PROCESSNAME = '" & CMBFROM.Text.Trim & "' AND YEARID = " & YearId)
                ' as per gulkit bhai instruction for checking purpose i m removing the process name from where clouse from (validating and enter event) on 07.05.14 done by vijay
                Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT MFGNO, MFGSRNO, CHECKNO, CHECKSRNO, LOTSRNO, GRNTYPE, TYPE, QUALITY FROM PACKINGSLIPVIEW WHERE LOTNO = '" & CMBLOTNO.Text.Trim & "' AND PIECETYPE = '" & cmbpiecetype.Text.Trim & "' AND YEARID = " & YearId, "", "")
                If DT.Rows.Count > 0 Then
                    TXTMFGNO.Text = DT.Rows(0).Item("MFGNO")
                    TXTMFGSRNO.Text = DT.Rows(0).Item("MFGSRNO")
                    TXTCHECKNO.Text = DT.Rows(0).Item("CHECKNO")
                    TXTCHECKSRNO.Text = DT.Rows(0).Item("CHECKSRNO")
                    TXTLOTSRNO.Text = DT.Rows(0).Item("LOTSRNO")
                    TXTGRNTYPE.Text = DT.Rows(0).Item("GRNTYPE")
                    TXTTYPE.Text = DT.Rows(0).Item("TYPE")
                    cmbquality.Text = DT.Rows(0).Item("QUALITY")
                Else
                    MsgBox("Invalid Lot No", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOTNO.Validating
        If Val(CMBLOTNO.Text.Trim) > 0 Then CALCLOTBAL(CMBLOTNO.Text.Trim)
    End Sub

    Private Sub txtcopy_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcopy.Validating
        Try
            GRIDMFG.RowCount = 0

            If Val(txtcopy.Text) < Val(TXTBALENO.Text) Then
                TEMPPSNO = Val(txtcopy.Text)
                billcopy = True
                PackingSlip_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBALENO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBALENO.Validating
        Try
            If TXTBALENO.Text <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" PS_NO", "", " PACKINGSLIP_JOB", " AND PS_NO = '" & TXTBALENO.Text.Trim & "' AND PS_CMPID = " & CmpId & " AND PS_LOCATIONID = " & Locationid & " AND PS_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Bale No Already Used", MsgBoxStyle.Critical)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " and ITEM_FRMSTRING='MERCHANT'", "MERCHANT")
        Catch EX As Exception
            Throw EX
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

    Private Sub PackingSlip_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If UserName = "Admin" Then CMBGODOWN.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class