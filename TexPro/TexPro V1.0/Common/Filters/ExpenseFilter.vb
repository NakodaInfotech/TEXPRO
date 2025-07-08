
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Imports BL

Public Class ExpenseFilter

    Public FRMSTRING As String
    Dim edit As Boolean = False

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM' AND (MATERIALTYPEMASTER.MATERIAL_NAME='Stores & Supplies - Production' or   MATERIALTYPEMASTER.MATERIAL_NAME='Pakaging Material')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM' and (MATERIALTYPEMASTER.MATERIAL_NAME='Stores & Supplies - Production' or   MATERIALTYPEMASTER.MATERIAL_NAME='Pakaging Material')", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

    Private Sub cmbprocess_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocess.Enter
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE<>''", edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbprocess_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprocess.Validating
        Try
            If cmbprocess.Text.Trim <> "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE<>''", edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE<>''", edit)
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM' AND (MATERIALTYPEMASTER.MATERIAL_NAME='Stores & Supplies - Production' or   MATERIALTYPEMASTER.MATERIAL_NAME='Pakaging Material')")
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If cmbratetype.Text.Trim = "" Then fillRATETYPE(cmbratetype, edit)
            If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGNNO.GotFocus
        Try
            If CMBDESIGNNO.Text.Trim = "" Then fillDESIGN(CMBDESIGNNO, cmbmerchant.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGNNO, e, Me, cmbmerchant.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbratetype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbratetype.GotFocus
        Try
            If cmbratetype.Text.Trim = "" Then fillRATETYPE(cmbratetype, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOLOR.Text.Trim = "" And CMBDESIGNNO.Text.Trim <> "" Then
                fillCOLOR(CMBCOLOR, "  INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & CMBDESIGNNO.Text & "'")
            Else
                fillCOLOR(CMBCOLOR)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOLOR.Text.Trim <> "" And CMBDESIGNNO.Text.Trim <> "" Then
                COLORvalidate(CMBCOLOR, e, Me, " INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID", " AND  DESIGNRECIPE.DESIGN_NO='" & CMBDESIGNNO.Text & "'")
            Else
                COLORvalidate(CMBCOLOR, e, Me)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbratetype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbratetype.Validating
        Try
            If cmbratetype.Text.Trim <> "" Then RATETYPEVALIDATE(cmbratetype, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StoreStockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "EXPENSE FILTER" Then

                cmbitemname.Visible = False
                LBLITEM.Visible = False
                cmbratetype.Visible = False
                LBLRATE.Visible = False
                TXTCUT.Visible = False
                LBLCUT.Visible = False
                TXTLOTNO.Visible = False
                LBLLOT.Visible = False
                CMBPER.Visible = False
                LBLPER.Visible = False
                CMBDESIGNNO.Visible = False
                LBLDESIGN.Visible = False
                CMBCOLOR.Visible = False
                LBLCOLOR.Visible = False
                CMBQUALITY.Visible = False
                LBLQUALITY.Visible = False
                cmbmerchant.Visible = False
                LBLMERCHANT.Visible = False

            End If

            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CostingFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for SHOW REPORT
                'Call cmdShowReport_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click

        Try
            If FRMSTRING = "EXPENSE FILTER" Then

                Dim CONDITION As String = ""
                Dim PERIOD As String = ""
                'If CONDITION <> "" Then
                '    CONDITION = CONDITION & ")"
                '    HEADER = HEADER & ")"
                'Else
                '    'CONDITION = " WHERE 1 = 1"
                'End If

                'If cmbprocess.Text.Trim <> "" Then CONDITION = CONDITION & " AND PROCESSNAME = '" & cmbprocess.Text.Trim & "'"
                'If cmbmerchant.Text.Trim <> "" Then CONDITION = CONDITION & " AND MERCHANT = '" & cmbmerchant.Text.Trim & "'"
                If chkdate.CheckState = CheckState.Checked Then
                    CONDITION = CONDITION & " AND T.DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND T.DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                    PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & "  -  " & Format(dtto.Value.Date, "dd/MM/yyyy")
                Else
                    PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "  -  " & Format(AccTo.Date, "dd/MM/yyyy")
                End If

                If cmbprocess.Text.Trim <> "" Then

                    Dim objclspreq As New ClsCommon()
                    Dim dt As New DataTable
                    'DONE BY GULKIT TO GET ALL THE MERCHANTS
                    'dt = objclspreq.search("  DISTINCT PROCESSMASTER.PROCESS_NAME AS PROCESS, EXPENSEMASTER.EXP_NAME AS EXPENSENAME, ITEMMASTER.item_name AS MERCHANT, EXPENSE_DESC.EXP_RATE AS RATE, CMP_DISPLAYEDNAME AS CMPNAME, CMP_ADD1 AS ADD1, CMP_ADD2 AS ADD2", "", "  EXPENSE_DESC LEFT OUTER JOIN PROCESSMASTER ON EXPENSE_DESC.EXP_yearid = PROCESSMASTER.PROCESS_YEARID AND EXPENSE_DESC.EXP_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND EXPENSE_DESC.EXP_cmpid = PROCESSMASTER.PROCESS_CMPID AND EXPENSE_DESC.EXP_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN ITEMMASTER ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_locationid = ITEMMASTER.item_locationid AND EXPENSE_DESC.EXP_cmpid = ITEMMASTER.item_cmpid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id LEFT OUTER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid AND EXPENSE_DESC.EXP_locationid = EXPENSEMASTER.EXP_locationid AND EXPENSE_DESC.EXP_cmpid = EXPENSEMASTER.EXP_cmpid AND EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id INNER JOIN CMPMASTER ON CMP_ID = EXPENSE_DESC.EXP_cmpid ", "  AND EXPENSE_DESC.EXP_cmpid = " & CmpId & " AND EXPENSE_DESC.EXP_locationid = " & Locationid & " AND EXPENSE_DESC.EXP_yearid = " & YearId & " AND  PROCESSMASTER.PROCESS_NAME = '" & cmbprocess.Text.Trim & "' ORDER BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.item_name, EXPENSEMASTER.EXP_NAME")
                    dt = objclspreq.search(" ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2  ", "", " EXPENSEMASTER INNER JOIN EXPENSE_DESC ON EXPENSEMASTER.EXP_id = EXPENSE_DESC.EXP_id AND EXPENSEMASTER.EXP_yearid = EXPENSE_DESC.EXP_yearid RIGHT OUTER JOIN PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN MFGMASTER2 ON ITEMMASTER.item_id = MFGMASTER2.MFG_MERCHANTID AND ITEMMASTER.item_yearid = MFGMASTER2.MFG_YEARID ON PROCESSMASTER.PROCESS_ID = MFGMASTER2.MFG_TOPROCESSID AND PROCESSMASTER.PROCESS_YEARID = MFGMASTER2.MFG_YEARID ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id  ", "  AND  PROCESSMASTER.PROCESS_NAME = '" & cmbprocess.Text.Trim & "' AND  PROCESSMASTER.PROCESS_NAME <> 'MFG2 DYEING' AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND MFG_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MFG_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME  ORDER BY ISNULL(PROCESSMASTER.PROCESS_NAME, ''), ISNULL(ITEMMASTER.item_name, ''), ISNULL(EXPENSEMASTER.EXP_NAME, '') ")
                    If dt.Rows.Count = 0 Then
                        MsgBox("No Records In Expense", MsgBoxStyle.Critical, "Texpro")
                        Exit Sub
                    End If
                    Dim objrep As New clsReportDesigner("Expense Report", System.AppDomain.CurrentDomain.BaseDirectory & "Expense Report.xlsx", 2)
                    objrep.EXPENSE_REPORT_EXCEL(dt, CmpId, Locationid, YearId, "EXPENSE REPORT (" & PERIOD & ")", CONDITION)
                Else

                    Dim objclspreq As New ClsCommon()
                    Dim dt As New DataTable
                    'DONE BY GULKIT TO GET ALL THE MERCHANTS
                    'dt = objclspreq.search("  DISTINCT PROCESSMASTER.PROCESS_NAME AS PROCESS, EXPENSEMASTER.EXP_NAME AS EXPENSENAME, ITEMMASTER.item_name AS MERCHANT, EXPENSE_DESC.EXP_RATE AS RATE, CMP_DISPLAYEDNAME AS CMPNAME, CMP_ADD1 AS ADD1, CMP_ADD2 AS ADD2", "", "  EXPENSE_DESC LEFT OUTER JOIN PROCESSMASTER ON EXPENSE_DESC.EXP_yearid = PROCESSMASTER.PROCESS_YEARID AND EXPENSE_DESC.EXP_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND EXPENSE_DESC.EXP_cmpid = PROCESSMASTER.PROCESS_CMPID AND EXPENSE_DESC.EXP_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN ITEMMASTER ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_locationid = ITEMMASTER.item_locationid AND EXPENSE_DESC.EXP_cmpid = ITEMMASTER.item_cmpid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id LEFT OUTER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid AND EXPENSE_DESC.EXP_locationid = EXPENSEMASTER.EXP_locationid AND EXPENSE_DESC.EXP_cmpid = EXPENSEMASTER.EXP_cmpid AND EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id INNER JOIN CMPMASTER ON CMP_ID = EXPENSE_DESC.EXP_cmpid ", "  AND EXPENSE_DESC.EXP_cmpid = " & CmpId & " AND EXPENSE_DESC.EXP_locationid = " & Locationid & " AND EXPENSE_DESC.EXP_yearid = " & YearId & " ORDER BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.item_name, EXPENSEMASTER.EXP_NAME")

                    'DONE BY GULKIT TO GET LUMP PROCESS AND JOB IN
                    'dt = objclspreq.search(" ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2  ", "", " EXPENSEMASTER INNER JOIN EXPENSE_DESC ON EXPENSEMASTER.EXP_id = EXPENSE_DESC.EXP_id AND EXPENSEMASTER.EXP_yearid = EXPENSE_DESC.EXP_yearid RIGHT OUTER JOIN PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN MFGMASTER2 ON ITEMMASTER.item_id = MFGMASTER2.MFG_MERCHANTID AND ITEMMASTER.item_yearid = MFGMASTER2.MFG_YEARID ON PROCESSMASTER.PROCESS_ID = MFGMASTER2.MFG_TOPROCESSID AND PROCESSMASTER.PROCESS_YEARID = MFGMASTER2.MFG_YEARID ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id  ", " AND  PROCESSMASTER.PROCESS_NAME <> 'MFG2 DYEING' AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND MFG_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MFG_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME ORDER BY ISNULL(PROCESSMASTER.PROCESS_NAME, ''), ISNULL(ITEMMASTER.item_name, ''), ISNULL(EXPENSEMASTER.EXP_NAME, '')")


                    'DONE BY GULKIT TO GET LUMP PROCESS AND JOB IN AND MFGMASTER (DYEING0
                    'dt = objclspreq.search(" * ", "", " (SELECT ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2  FROM EXPENSEMASTER INNER JOIN EXPENSE_DESC ON EXPENSEMASTER.EXP_id = EXPENSE_DESC.EXP_id AND EXPENSEMASTER.EXP_yearid = EXPENSE_DESC.EXP_yearid RIGHT OUTER JOIN PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN MFGMASTER2 ON ITEMMASTER.item_id = MFGMASTER2.MFG_MERCHANTID AND ITEMMASTER.item_yearid = MFGMASTER2.MFG_YEARID ON PROCESSMASTER.PROCESS_ID = MFGMASTER2.MFG_TOPROCESSID AND PROCESSMASTER.PROCESS_YEARID = MFGMASTER2.MFG_YEARID ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id WHERE PROCESSMASTER.PROCESS_NAME <> 'MFG2 DYEING' AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_yearid = " & YearId & " AND MFG_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MFG_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME  UNION ALL SELECT 'JOB OUT (EMB)' AS PROCESSNAME, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2 FROM PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN PACKINGSLIP_JOB ON ITEMMASTER.item_id = PACKINGSLIP_JOB.PS_ITEMID ON PROCESSMASTER.PROCESS_ID = PACKINGSLIP_JOB.PS_PROCESSID LEFT OUTER JOIN EXPENSE_DESC INNER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id AND EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid ON ItemMaster.item_yearid = EXPENSE_DESC.EXP_yearid And ItemMaster.item_id = EXPENSE_DESC.EXP_QUALITYID  WHERE PS_EXPENSEREPORT = 1 AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND PS_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PS_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME UNION ALL SELECT 'JOB IN' AS PROCESSNAME, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2 FROM PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN FINALPACKINGSLIP ON ITEMMASTER.item_id = FINALPACKINGSLIP.FPS_MERCHANTID AND ITEMMASTER.item_yearid = FINALPACKINGSLIP.FPS_YEARID ON PROCESSMASTER.PROCESS_ID = FINALPACKINGSLIP.FPS_PROCESSID AND PROCESSMASTER.PROCESS_YEARID = FINALPACKINGSLIP.FPS_YEARID LEFT OUTER JOIN EXPENSE_DESC INNER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id AND EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid ON ItemMaster.item_yearid = EXPENSE_DESC.EXP_yearid And ItemMaster.item_id = EXPENSE_DESC.EXP_QUALITYID WHERE PROCESSMASTER.PROCESS_NAME = 'FINAL CUTTING' AND FPS_EXPENSEREPORT = 1 AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND FPS_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND FPS_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME UNION ALL SELECT 'LUMP FINISH' AS PROCESSNAME, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2 FROM PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN FINALPACKINGSLIP ON ITEMMASTER.item_id = FINALPACKINGSLIP.FPS_MERCHANTID AND ITEMMASTER.item_yearid = FINALPACKINGSLIP.FPS_YEARID ON PROCESSMASTER.PROCESS_ID = FINALPACKINGSLIP.FPS_PROCESSID AND PROCESSMASTER.PROCESS_YEARID = FINALPACKINGSLIP.FPS_YEARID LEFT OUTER JOIN EXPENSE_DESC INNER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id AND EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid ON ItemMaster.item_yearid = EXPENSE_DESC.EXP_yearid And ItemMaster.item_id = EXPENSE_DESC.EXP_QUALITYID WHERE PROCESSMASTER.PROCESS_NAME = 'WHITE FOLDING' AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND FPS_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND FPS_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME) AS T", " ORDER BY T.PROCESS, T.MERCHANT,T.EXPENSENAME ")
                    dt = objclspreq.search(" * ", "", " (SELECT ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2  FROM EXPENSEMASTER INNER JOIN EXPENSE_DESC ON EXPENSEMASTER.EXP_id = EXPENSE_DESC.EXP_id AND EXPENSEMASTER.EXP_yearid = EXPENSE_DESC.EXP_yearid RIGHT OUTER JOIN PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN MFGMASTER2 ON ITEMMASTER.item_id = MFGMASTER2.MFG_MERCHANTID AND ITEMMASTER.item_yearid = MFGMASTER2.MFG_YEARID ON PROCESSMASTER.PROCESS_ID = MFGMASTER2.MFG_TOPROCESSID AND PROCESSMASTER.PROCESS_YEARID = MFGMASTER2.MFG_YEARID ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id WHERE PROCESSMASTER.PROCESS_NAME <> 'MFG2 DYEING' AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_yearid = " & YearId & " AND MFG_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MFG_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME  UNION ALL SELECT 'JOB OUT (EMB)' AS PROCESSNAME, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2 FROM PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN PACKINGSLIP_JOB ON ITEMMASTER.item_id = PACKINGSLIP_JOB.PS_ITEMID ON PROCESSMASTER.PROCESS_ID = PACKINGSLIP_JOB.PS_PROCESSID LEFT OUTER JOIN EXPENSE_DESC INNER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id AND EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid ON ItemMaster.item_yearid = EXPENSE_DESC.EXP_yearid And ItemMaster.item_id = EXPENSE_DESC.EXP_QUALITYID  WHERE PS_EXPENSEREPORT = 1 AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND PS_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND PS_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME UNION ALL SELECT 'JOB IN' AS PROCESSNAME, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2 FROM PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN FINALPACKINGSLIP ON ITEMMASTER.item_id = FINALPACKINGSLIP.FPS_MERCHANTID AND ITEMMASTER.item_yearid = FINALPACKINGSLIP.FPS_YEARID ON PROCESSMASTER.PROCESS_ID = FINALPACKINGSLIP.FPS_PROCESSID AND PROCESSMASTER.PROCESS_YEARID = FINALPACKINGSLIP.FPS_YEARID LEFT OUTER JOIN EXPENSE_DESC INNER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id AND EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid ON ItemMaster.item_yearid = EXPENSE_DESC.EXP_yearid And ItemMaster.item_id = EXPENSE_DESC.EXP_QUALITYID WHERE PROCESSMASTER.PROCESS_NAME = 'FINAL CUTTING' AND FPS_EXPENSEREPORT = 1 AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND FPS_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND FPS_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME UNION ALL SELECT 'LUMP FINISH' AS PROCESSNAME, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2 FROM PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN FINALPACKINGSLIP ON ITEMMASTER.item_id = FINALPACKINGSLIP.FPS_MERCHANTID AND ITEMMASTER.item_yearid = FINALPACKINGSLIP.FPS_YEARID ON PROCESSMASTER.PROCESS_ID = FINALPACKINGSLIP.FPS_PROCESSID AND PROCESSMASTER.PROCESS_YEARID = FINALPACKINGSLIP.FPS_YEARID LEFT OUTER JOIN EXPENSE_DESC INNER JOIN EXPENSEMASTER ON EXPENSE_DESC.EXP_id = EXPENSEMASTER.EXP_id AND EXPENSE_DESC.EXP_yearid = EXPENSEMASTER.EXP_yearid ON ItemMaster.item_yearid = EXPENSE_DESC.EXP_yearid And ItemMaster.item_id = EXPENSE_DESC.EXP_QUALITYID WHERE PROCESSMASTER.PROCESS_NAME = 'WHITE FOLDING' AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_cmpid = " & CmpId & " AND ITEM_locationid = " & Locationid & " AND ITEM_yearid = " & YearId & " AND FPS_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND FPS_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME  UNION ALL SELECT ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(EXPENSEMASTER.EXP_NAME, '') AS EXPENSENAME, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(EXPENSE_DESC.EXP_RATE, 0) AS RATE, CMPMASTER.cmp_displayedname AS CMPNAME, CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)) AS ADD1, CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)) AS ADD2  FROM EXPENSEMASTER INNER JOIN EXPENSE_DESC ON EXPENSEMASTER.EXP_id = EXPENSE_DESC.EXP_id AND EXPENSEMASTER.EXP_yearid = EXPENSE_DESC.EXP_yearid RIGHT OUTER JOIN PROCESSMASTER INNER JOIN CMPMASTER INNER JOIN ITEMMASTER ON CMPMASTER.cmp_id = ITEMMASTER.item_cmpid INNER JOIN MFGMASTER ON ITEMMASTER.item_id = MFGMASTER.MFG_MERCHANTID ON PROCESSMASTER.PROCESS_ID = MFGMASTER.MFG_TOPROCESSID  ON EXPENSE_DESC.EXP_yearid = ITEMMASTER.item_yearid AND EXPENSE_DESC.EXP_QUALITYID = ITEMMASTER.item_id AND EXPENSE_DESC.EXP_PROCESSID = PROCESSMASTER.PROCESS_ID WHERE PROCESSMASTER.PROCESS_NAME = 'DYEING' AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT') AND ITEM_yearid = " & YearId & " AND MFG_DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND MFG_DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' GROUP BY ISNULL(PROCESSMASTER.PROCESS_NAME, '') , ISNULL(EXPENSEMASTER.EXP_NAME, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(EXPENSE_DESC.EXP_RATE, 0) , CMPMASTER.cmp_displayedname , CAST(CMPMASTER.cmp_add1 AS VARCHAR(2000)), CAST(CMPMASTER.cmp_add2 AS VARCHAR(2000)), PROCESSMASTER.PROCESS_NAME   ) AS T", " ORDER BY T.PROCESS, T.MERCHANT,T.EXPENSENAME ")
                    If dt.Rows.Count = 0 Then
                        MsgBox("No Records In Expense", MsgBoxStyle.Critical, "Texpro")
                        Exit Sub
                    End If
                    If RBDETAILS.Checked = True Then
                        Dim objrep As New clsReportDesigner("Expense Report Details", System.AppDomain.CurrentDomain.BaseDirectory & "Expense Report Details.xlsx", 2)
                        objrep.EXPENSE_REPORT_EXCEL(dt, CmpId, Locationid, YearId, "EXPENSE REPORT - DETAILS (" & PERIOD & ")", CONDITION)
                    Else
                        Dim objrep As New clsReportDesigner("Expense Report Summary", System.AppDomain.CurrentDomain.BaseDirectory & "Expense Report Summary.xlsx", 2)
                        objrep.EXPENSESUMMARY_REPORT_EXCEL(dt, CmpId, Locationid, YearId, "EXPENSE REPORT - SUMMARY (" & PERIOD & ")", CONDITION)
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class