Imports BL

Public Class LOTDETAILS

    Public WHERE As String = ""

    Private Sub GDNDetailsReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" GDN.GDN_no AS GDNNO, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, GDN.GDN_date AS DATE, ISNULL(TRANSPORTLEDGERS.Acc_cmpname,'') AS TRANSPORT, ISNULL(GDN.GDN_VEHICLENO,'') AS VEHICLENO, ISNULL(GDN_PSDESC.GDN_PSNO,'') AS BALENO, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, GDN_PSDESC.GDN_CUT AS CUT, GDN_PSDESC.GDN_PCS AS PCS, GDN_PSDESC.GDN_MTRS AS MTRS, ISNULL(GDN_PSDESC.GDN_LRNO,'') AS LRNO, ISNULL(PARTYNAMELEDGERS.Acc_cmpname,'') AS PARTYNAME ", "", " GDN INNER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_CMPID = GDN_PSDESC.GDN_CMPID AND GDN.GDN_LOCATIONID = GDN_PSDESC.GDN_LOCATIONID AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID INNER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id AND GDN.GDN_CMPID = LEDGERS.Acc_cmpid AND GDN.GDN_LOCATIONID = LEDGERS.Acc_locationid AND GDN.GDN_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS PARTYNAMELEDGERS ON GDN_PSDESC.GDN_YEARID = PARTYNAMELEDGERS.Acc_yearid AND  GDN_PSDESC.GDN_LOCATIONID = PARTYNAMELEDGERS.Acc_locationid AND GDN_PSDESC.GDN_CMPID = PARTYNAMELEDGERS.Acc_cmpid AND GDN_PSDESC.GDN_PARTYID = PARTYNAMELEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON GDN_PSDESC.GDN_YEARID = ITEMMASTER.item_yearid AND GDN_PSDESC.GDN_LOCATIONID = ITEMMASTER.item_locationid AND GDN_PSDESC.GDN_CMPID = ITEMMASTER.item_cmpid AND GDN_PSDESC.GDN_MERCHANTID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS TRANSPORTLEDGERS ON GDN.GDN_YEARID = TRANSPORTLEDGERS.Acc_yearid AND GDN.GDN_LOCATIONID = TRANSPORTLEDGERS.Acc_locationid AND GDN.GDN_CMPID = TRANSPORTLEDGERS.Acc_cmpid AND GDN.GDN_transid = TRANSPORTLEDGERS.Acc_id ", WHERECLAUSE & " AND GDN.GDN_CMPID =" & CmpId & " AND GDN.GDN_LOCATIONID = " & Locationid & " AND GDN.GDN_YEARID = " & YearId & " ORDER BY GDN.GDN_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Process Stock.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Process Stock"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Process Stock", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNDetailsReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(WHERE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class