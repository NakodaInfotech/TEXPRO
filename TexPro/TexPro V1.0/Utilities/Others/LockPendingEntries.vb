
Imports BL

Public Class LockPendingEntries

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LockPendingEntries_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LockPendingEntries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If RBPENDING.Checked = True Then
                dt = objclsCMST.search("*", "", " PENDINGDETAILS ", " AND PENDINGDETAILS.YEARID=" & YearId & " ORDER BY TYPE, NO")
            Else
                dt = objclsCMST.search(" dbo.GRN.grn_no AS NO, dbo.GRN.grn_date AS DATE, LEDGERS_1.Acc_cmpname AS NAME, dbo.GRN.GRN_TOTALQTY AS TOTALPCS,  'PENDING PURCHASE BILL' AS TYPE, dbo.GRN.grn_cmpid AS CMPID, dbo.GRN.grn_yearid AS YEARID ", "", " dbo.GRN INNER JOIN dbo.LEDGERS AS LEDGERS_1 ON dbo.GRN.grn_ledgerid = LEDGERS_1.Acc_id LEFT OUTER JOIN dbo.LEDGERS AS LEDGERS_4 ON dbo.GRN.grn_transledgerid = LEDGERS_4.Acc_id CROSS JOIN  VERSION ", " AND (dbo.GRN.GRN_DONE = 1) AND GRN.GRN_TYPE = 'Inwards'AND GRN.GRN_YEARID = " & YearId & " ORDER BY  dbo.GRN.grn_date, dbo.GRN.grn_no")
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Lock-Unlock Pending Entries.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Lock-Unlock Pending Entries"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Lock-Unlock Pending Entries", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Pending Entries Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'PENDING
            If RBPENDING.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    If DTROW("TYPE") = "PENDING PURCHASE BILL" Then
                        DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_DONE = 'TRUE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_TYPE = 'Inwards' AND GRN_YEARID = " & YearId, "", "")
                        DT = OBJCMN.Execute_Any_String(" UPDATE GRN_DESC SET GRN_DONE = 'TRUE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_GRIDTYPE = 'Inwards' AND GRN_YEARID = " & YearId, "", "")
                    End If
                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If

            'ENTERED
            If RBENTERED.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    If DTROW("TYPE") = "PENDING PURCHASE BILL" Then
                        DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_DONE = 'FALSE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_TYPE = 'Inwards' AND GRN_YEARID = " & YearId, "", "")
                        DT = OBJCMN.Execute_Any_String(" UPDATE GRN_DESC SET GRN_DONE = 'FALSE' WHERE GRN_NO = " & DTROW("NO") & " AND GRN_GRIDTYPE = 'Inwards' AND GRN_YEARID = " & YearId, "", "")
                    End If
                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTERED.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class