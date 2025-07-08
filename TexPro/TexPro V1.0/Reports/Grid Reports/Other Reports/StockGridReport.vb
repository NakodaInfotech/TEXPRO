Imports Microsoft.Office.Interop

Imports BL
Imports System.Windows.Forms
Public Class StockGridReport

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean
    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String
            If rdbApproved.Checked = True Then
                PATH = Application.StartupPath & "\APPROVED STOCK DETAILS"
            ElseIf RdbOnApproval.Checked = True Then
                PATH = Application.StartupPath & "\ONAPPROVAL STOCK DETAILS"
            ElseIf rdbReject.Checked = True Then
                PATH = Application.StartupPath & "\REJECTED STOCK DETAILS"
            ElseIf rdbprocess.Checked = True Then
                PATH = Application.StartupPath & "\PROCESS DETAILS"

            End If

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            If rdbApproved.Checked = True Then
                opti.SheetName = "APPROVED STOCK DETAILS"

                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "APPROVED STOCK DETAILS", gridbill.VisibleColumns.Count + gridbill.GroupCount)
            ElseIf RdbOnApproval.Checked = True Then
                opti.SheetName = "ONAPPROVAL STOCK DETAILS"
                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "ONAPPROVAL STOCK DETAILS", gridbill.VisibleColumns.Count + gridbill.GroupCount)
            ElseIf rdbReject.Checked = True Then
                opti.SheetName = "REJECTED STOCK DETAILS"
                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "REJECTED STOCK DETAILS", gridbill.VisibleColumns.Count + gridbill.GroupCount)
            ElseIf rdbprocess.Checked = True Then
                opti.SheetName = "PROCESS DETAILS"
                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "PROCESS DETAILS", gridbill.VisibleColumns.Count + gridbill.GroupCount)
            ElseIf rdbprocess.Checked = True Then
                opti.SheetName = "DESPATCH DETAILS"
                gridbill.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "DESPATCH DETAILS", gridbill.VisibleColumns.Count + gridbill.GroupCount)

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub stockFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and CMPID=" & CmpId & " and locationid=" & Locationid & " and yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If rdbReject.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and [Date] between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("   item_name AS ITEMNAME, QUALITY_name AS QUALITY, UNIT,  DATE, GRNNO AS SRNO, Acc_cmpname AS NAME, REJMTRS AS MTRS,REJPCS AS PCS", "", "  approvedstock_view ", " AND REJMTRS>0 and returnpcs=0" & tepmcondition & " and CMPID=" & CmpId & " and locationid=" & Locationid & " and yearid=" & YearId & " order by SRNO")
            ElseIf rdbApproved.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and [Date] between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("   item_name AS ITEMNAME, QUALITY_name AS QUALITY, UNIT,  DATE, GRNNO AS SRNO, Acc_cmpname AS NAME, CHECKMTRS AS MTRS,PCS", "", "  approvedstock_view ", tepmcondition & " and CMPID=" & CmpId & " and locationid=" & Locationid & " and yearid=" & YearId & " order by SRNO")
            ElseIf RdbOnApproval.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and [Date] between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("   item_name AS ITEMNAME, QUALITY_name AS QUALITY,UNIT_ABBR AS UNIT,  DATE, GRNNO AS SRNO, Acc_cmpname AS NAME, MTRS AS MTRS,QTY AS PCS", "", "  approvALstock_view ", tepmcondition & " and CMPID=" & CmpId & " and locationid=" & Locationid & " and yearid=" & YearId & " order by SRNO")
            ElseIf rdbprocess.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and [MFGDATE] between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("   [ITEMNAME] AS ITEMNAME, [QUALITY] AS QUALITY,'' AS UNIT, [MFGDATE] AS DATE, [LOTNO] AS SRNO, [PROCESSNAME] AS NAME, sum(RECDMTRS) AS MTRS,sum(RECDPCS) AS PCS", "", "  [PACKINGSLIPVIEW] ", tepmcondition & " and CMPID=" & CmpId & " and locationid=" & Locationid & " and yearid=" & YearId & " group by ITEMNAME, QUALITY, MFGDATE, LOTNO, PROCESSNAME HAVING sum(RECDPCS)>0 AND sum(RECDMTRS)>0 AND PROCESSNAME<>''")
            ElseIf rdbBale.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and FINALPACKINGSLIP.FPS_DATE between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("    FINALPACKINGSLIP.FPS_NO AS SRNO, FINALPACKINGSLIP.FPS_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, 'PACKING SLIP' AS PROCESS, ITEMMASTER_1.item_name AS ITEMNAME, FINALPACKINGSLIP.FPS_TOTAL AS PCS, FINALPACKINGSLIP.FPS_TOTALMTRS AS MTRS ", "", "   FINALPACKINGSLIP INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID AND FINALPACKINGSLIP.FPS_CMPID = PROCESSMASTER.PROCESS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN DYEINGRECIPE ON FINALPACKINGSLIP.FPS_DYEINGID = DYEINGRECIPE.DYEING_ID AND FINALPACKINGSLIP.FPS_CMPID = DYEINGRECIPE.DYEING_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = DYEINGRECIPE.DYEING_YEARID LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 ON FINALPACKINGSLIP.FPS_MERCHANTID = ITEMMASTER_1.item_id AND FINALPACKINGSLIP.FPS_CMPID = ITEMMASTER_1.item_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = ITEMMASTER_1.item_locationid AND FINALPACKINGSLIP.FPS_YEARID = ITEMMASTER_1.item_yearid LEFT OUTER JOIN LEDGERS ON FINALPACKINGSLIP.FPS_LEDGERID = LEDGERS.Acc_id AND FINALPACKINGSLIP.FPS_CMPID = LEDGERS.Acc_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = LEDGERS.Acc_locationid AND FINALPACKINGSLIP.FPS_YEARID = LEDGERS.Acc_yearid ", "  and FPS_CMPID=" & CmpId & " and FPS_locationid=" & Locationid & " and FPS_yearid=" & YearId & tepmcondition)
            ElseIf Rdbout.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and JOBOUT.JO_date between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("  JOBOUT.JO_no AS SRNO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME,ITEMMASTER.item_name as ITEMNAME,QUALITY_NAME AS QUALITY,(PACKINGSLIP_DESC_JOB.PS_TOTAL-PACKINGSLIP_DESC_JOB.PS_RECTOTAL) AS PCS,  (PACKINGSLIP_DESC_JOB.PS_MTRS-PACKINGSLIP_DESC_JOB.PS_RECMTRS) AS MTRS ", "", "    PACKINGSLIP_DESC_JOB INNER JOIN JOBOUT_DESC ON PACKINGSLIP_DESC_JOB.PS_NO = JOBOUT_DESC.JO_BALENO AND PACKINGSLIP_DESC_JOB.PS_CMPID = JOBOUT_DESC.JO_CMPID AND PACKINGSLIP_DESC_JOB.PS_LOCATIONID = JOBOUT_DESC.JO_LOCATIONID AND PACKINGSLIP_DESC_JOB.PS_YEARID = JOBOUT_DESC.JO_YEARID INNER JOIN LEDGERS INNER JOIN JOBOUT ON LEDGERS.Acc_id = JOBOUT.JO_ledgerid AND LEDGERS.Acc_cmpid = JOBOUT.JO_cmpid AND LEDGERS.Acc_locationid = JOBOUT.JO_locationid AND LEDGERS.Acc_yearid = JOBOUT.JO_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON JOBOUT.JO_transledgerid = LEDGERS_1.Acc_id AND JOBOUT.JO_cmpid = LEDGERS_1.Acc_cmpid AND JOBOUT.JO_locationid = LEDGERS_1.Acc_locationid AND JOBOUT.JO_yearid = LEDGERS_1.Acc_yearid ON JOBOUT_DESC.JO_NO = JOBOUT.JO_no AND JOBOUT_DESC.JO_CMPID = JOBOUT.JO_cmpid AND JOBOUT_DESC.JO_LOCATIONID = JOBOUT.JO_locationid AND JOBOUT_DESC.JO_YEARID = JOBOUT.JO_yearid LEFT OUTER JOIN DESIGNRECIPE ON PACKINGSLIP_DESC_JOB.PS_YEARID = DESIGNRECIPE.DESIGN_YEARID AND PACKINGSLIP_DESC_JOB.PS_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND PACKINGSLIP_DESC_JOB.PS_CMPID = DESIGNRECIPE.DESIGN_CMPID AND PACKINGSLIP_DESC_JOB.PS_DESIGNID = DESIGNRECIPE.DESIGN_ID LEFT OUTER JOIN ITEMMASTER ON PACKINGSLIP_DESC_JOB.PS_ITEMID = ITEMMASTER.item_id AND PACKINGSLIP_DESC_JOB.PS_CMPID = ITEMMASTER.item_cmpid AND PACKINGSLIP_DESC_JOB.PS_LOCATIONID = ITEMMASTER.item_locationid AND PACKINGSLIP_DESC_JOB.PS_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN QUALITYMASTER ON PACKINGSLIP_DESC_JOB.PS_QUALITYID = QUALITYMASTER.QUALITY_id AND PACKINGSLIP_DESC_JOB.PS_CMPID = QUALITYMASTER.QUALITY_cmpid AND PACKINGSLIP_DESC_JOB.PS_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PACKINGSLIP_DESC_JOB.PS_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN COLORMASTER ON PACKINGSLIP_DESC_JOB.PS_COLORID = COLORMASTER.COLOR_id AND PACKINGSLIP_DESC_JOB.PS_CMPID = COLORMASTER.COLOR_cmpid AND PACKINGSLIP_DESC_JOB.PS_LOCATIONID = COLORMASTER.COLOR_locationid AND PACKINGSLIP_DESC_JOB.PS_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN PIECETYPEMASTER ON PACKINGSLIP_DESC_JOB.PS_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND PACKINGSLIP_DESC_JOB.PS_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND PACKINGSLIP_DESC_JOB.PS_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND PACKINGSLIP_DESC_JOB.PS_YEARID = PIECETYPEMASTER.PIECETYPE_yearid ", " AND (PACKINGSLIP_DESC_JOB.PS_MTRS-PACKINGSLIP_DESC_JOB.PS_RECMTRS)>0  and dbo.JOBOUT.JO_CMPID=" & CmpId & " and dbo.JOBOUT.JO_locationid=" & Locationid & " and dbo.JOBOUT.JO_yearid=" & YearId & tepmcondition & " order by dbo.JOBOUT.JO_no ")
            ElseIf rdbin.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and JOBIN.JI_date between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("  JOBIN.JI_no AS SRNO, JOBIN.JI_date AS DATE, LEDGERS.Acc_cmpname AS NAME, JOBIN_DESC.JI_JOBNO AS JOBNO, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, SUM(JOBIN_DESC.JI_PCS) AS PCS, SUM(JOBIN_DESC.JI_MTRS) AS MTRS ", "", "    JOBIN INNER JOIN JOBIN_DESC ON JOBIN.JI_no = JOBIN_DESC.JI_NO AND JOBIN.JI_cmpid = JOBIN_DESC.JI_CMPID AND JOBIN.JI_locationid = JOBIN_DESC.JI_LOCATIONID AND JOBIN.JI_yearid = JOBIN_DESC.JI_YEARID INNER JOIN LEDGERS ON JOBIN.JI_ledgerid = LEDGERS.Acc_id AND JOBIN.JI_cmpid = LEDGERS.Acc_cmpid AND JOBIN.JI_locationid = LEDGERS.Acc_locationid AND JOBIN.JI_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN QUALITYMASTER ON JOBIN_DESC.JI_QUALITYID = QUALITYMASTER.QUALITY_id AND JOBIN_DESC.JI_CMPID = QUALITYMASTER.QUALITY_cmpid AND JOBIN_DESC.JI_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND JOBIN_DESC.JI_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON JOBIN_DESC.JI_ITEMID = ITEMMASTER.item_id AND JOBIN_DESC.JI_CMPID = ITEMMASTER.item_cmpid AND JOBIN_DESC.JI_LOCATIONID = ITEMMASTER.item_locationid AND JOBIN_DESC.JI_YEARID = ITEMMASTER.item_yearid ", " and dbo.JOBIN.JI_CMPID=" & CmpId & " and dbo.JOBIN.JI_locationid=" & Locationid & " and dbo.JOBIN.JI_yearid=" & YearId & tepmcondition & " GROUP BY JOBIN.JI_no, JOBIN.JI_date, LEDGERS.Acc_cmpname, JOBIN_DESC.JI_JOBNO, ITEMMASTER.item_name, QUALITYMASTER.QUALITY_name ")
            ElseIf rdbDespatch.Checked = True Then
                If chkdate.Checked = True Then
                    tepmcondition = tepmcondition & " and GDN.GDN_date between '" & Format(dtfrom.Value, "MM/dd/yyyy") & "' and '" & Format(dtto.Value, "MM/dd/yyyy") & "'"
                End If
                dt = objclsCMST.search("  GDN.GDN_no AS SRNO, GDN.GDN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, GDN_PSDESC.GDN_PSNO AS JOBNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(MAX(QUALITYMASTER.QUALITY_name),'') AS QUALITY, SUM(GDN_PSDESC.GDN_PCS) AS PCS, SUM(GDN_PSDESC.GDN_MTRS) AS MTRS ", "", "    GDN INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_cmpid = GDN_PSDESC.GDN_CMPID AND GDN.GDN_locationid = GDN_PSDESC.GDN_LOCATIONID AND GDN.GDN_yearid = GDN_PSDESC.GDN_YEARID INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id AND GDN.GDN_cmpid = LEDGERS.Acc_cmpid AND GDN.GDN_locationid = LEDGERS.Acc_locationid AND GDN.GDN_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN QUALITYMASTER ON GDN_PSDESC.GDN_QUALITYID = QUALITYMASTER.QUALITY_id AND GDN_PSDESC.GDN_CMPID = QUALITYMASTER.QUALITY_cmpid AND GDN_PSDESC.GDN_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND GDN_PSDESC.GDN_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON GDN_PSDESC.GDN_MERCHANTID = ITEMMASTER.item_id AND GDN_PSDESC.GDN_CMPID = ITEMMASTER.item_cmpid AND GDN_PSDESC.GDN_LOCATIONID = ITEMMASTER.item_locationid AND GDN_PSDESC.GDN_YEARID = ITEMMASTER.item_yearid  ", " and dbo.GDN.GDN_CMPID=" & CmpId & " and dbo.GDN.GDN_locationid=" & Locationid & " and dbo.GDN.GDN_yearid=" & YearId & tepmcondition & " GROUP BY GDN.GDN_no, GDN.GDN_date, LEDGERS.Acc_cmpname, GDN_PSDESC.GDN_PSNO, ITEMMASTER.item_name ")

            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then

                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub rdbReject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbReject.CheckedChanged
        fillgrid("")

    End Sub

    Private Sub rdbApproved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbApproved.CheckedChanged
        fillgrid("")

    End Sub

    Private Sub RdbOnApproval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbOnApproval.CheckedChanged
        fillgrid("")

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub rdbprocess_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbprocess.CheckedChanged
        fillgrid("")

    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click

    End Sub

    Private Sub rdbBale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbBale.CheckedChanged
        fillgrid("")

    End Sub

    Private Sub Rdbout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdbout.CheckedChanged
        fillgrid("")
    End Sub

    Private Sub rdbin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbin.CheckedChanged
        fillgrid("")

    End Sub
End Class