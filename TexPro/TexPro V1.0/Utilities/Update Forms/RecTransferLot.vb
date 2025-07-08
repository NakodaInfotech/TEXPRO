
Imports BL

Public Class RecTransferLot

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RecTransferLot_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RecTransferLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                dt = objclsCMST.search(" INTERGODOWNTRANSFER.TRANSFER_no AS TEMPGODOWNNO, INTERGODOWNTRANSFER.TRANSFER_date AS DATE, FROMGODOWN.GODOWN_name AS FROMGODOWN, TOGODOWN.GODOWN_name AS TOGODOWN, LEDGERS.Acc_cmpname AS TRANSNAME, INTERGODOWNTRANSFER.TRANSFER_VEHICLENO AS VEHICLENO, INTERGODOWNTRANSFER.TRANSFER_LBLTOTALPCS AS TOTALPCS, INTERGODOWNTRANSFER.TRANSFER_LBLTOTALMTRS AS TOTALMTRS, INTERGODOWNTRANSFER.TRANSFER_LBLTOTALBALES AS TOTALBALES, INTERGODOWNTRANSFER.TRANSFER_remarks AS REMARKS ", "", " LEDGERS INNER JOIN GODOWNMASTER AS TOGODOWN INNER JOIN INTERGODOWNTRANSFER INNER JOIN GODOWNMASTER AS FROMGODOWN ON INTERGODOWNTRANSFER.TRANSFER_FROMGODOWNID = FROMGODOWN.GODOWN_id ON TOGODOWN.GODOWN_id = INTERGODOWNTRANSFER.TRANSFER_TOGODOWNID ON LEDGERS.Acc_id = INTERGODOWNTRANSFER.TRANSFER_TRANSID ", " AND INTERGODOWNTRANSFER.TRANSFER_DONE = 'FALSE' AND INTERGODOWNTRANSFER.TRANSFER_YEARID=" & YearId & " ORDER BY INTERGODOWNTRANSFER.TRANSFER_NO")
            Else
                dt = objclsCMST.search(" INTERGODOWNTRANSFER.TRANSFER_no AS TEMPGODOWNNO, INTERGODOWNTRANSFER.TRANSFER_date AS DATE, FROMGODOWN.GODOWN_name AS FROMGODOWN, TOGODOWN.GODOWN_name AS TOGODOWN, LEDGERS.Acc_cmpname AS TRANSNAME, INTERGODOWNTRANSFER.TRANSFER_VEHICLENO AS VEHICLENO, INTERGODOWNTRANSFER.TRANSFER_LBLTOTALPCS AS TOTALPCS, INTERGODOWNTRANSFER.TRANSFER_LBLTOTALMTRS AS TOTALMTRS, INTERGODOWNTRANSFER.TRANSFER_LBLTOTALBALES AS TOTALBALES, INTERGODOWNTRANSFER.TRANSFER_remarks AS REMARKS ", "", " LEDGERS INNER JOIN GODOWNMASTER AS TOGODOWN INNER JOIN INTERGODOWNTRANSFER INNER JOIN GODOWNMASTER AS FROMGODOWN ON INTERGODOWNTRANSFER.TRANSFER_FROMGODOWNID = FROMGODOWN.GODOWN_id ON TOGODOWN.GODOWN_id = INTERGODOWNTRANSFER.TRANSFER_TOGODOWNID ON LEDGERS.Acc_id = INTERGODOWNTRANSFER.TRANSFER_TRANSID ", " AND INTERGODOWNTRANSFER.TRANSFER_DONE = 'TRUE' AND INTERGODOWNTRANSFER.TRANSFER_YEARID=" & YearId & " ORDER BY INTERGODOWNTRANSFER.TRANSFER_NO")
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
            PATH = Application.StartupPath & "\Rec Transfer Entries.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Rec Transfer Entries"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Rec Transfer Entries", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim OBJTRANFER As New ClsInterGodownTransfer
            Dim DT As New DataTable


            Dim INTRES As Integer
            Dim GODOWNNO As String = ""
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                If GODOWNNO = "" Then
                    GODOWNNO = Val(DTROW("TEMPGODOWNNO"))
                Else
                    GODOWNNO = GODOWNNO & "|" & Val(DTROW("TEMPGODOWNNO"))
                End If
            Next
            OBJTRANFER.alParaval.Add(GODOWNNO)
            OBJTRANFER.alParaval.Add(YearId)


            If RBPENDING.Checked = True Then
                INTRES = OBJTRANFER.SAVEREC()
            ElseIf RBENTERED.Checked = True Then
                INTRES = OBJTRANFER.DELETEREC()
            End If

            MsgBox("Details Updated Successfully")
            fillgrid()
            gridbill.Focus()

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