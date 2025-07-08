
Imports BL

Public Class ProcessContractorConfig

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean = False

    Sub FillCombo()
        Try
            FILLPROCESS(CMBPROCESS, " AND (PROCESSMASTER.PROCESS_TYPE='CHECKING' OR  PROCESSMASTER.PROCESS_TYPE='MFG')", EDIT)
            If CMBCONTRACTOR.Text.Trim = "" Then fillCONTRACTOR(CMBCONTRACTOR)
            If CMBSUPERVISOR.Text.Trim = "" Then fillSUPERVISIOR(CMBSUPERVISOR)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVE()
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList


            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(CMBCONTRACTOR.Text.Trim)
            alParaval.Add(CMBSUPERVISOR.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(YearId)

            Dim obclsexpns As New ClsProcessContractorConfig
            obclsexpns.alParaval = alParaval
            IntResult = obclsexpns.save()
            MsgBox("Details Added")
            CMBPROCESS.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub UPDATERECORD()
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList


            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(CMBCONTRACTOR.Text.Trim)
            alParaval.Add(CMBSUPERVISOR.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(YearId)

            Dim obclsexpns As New ClsProcessContractorConfig
            obclsexpns.alParaval = alParaval
            IntResult = obclsexpns.Update()

            CMBPROCESS.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBPROCESS.Text.Trim.Length = 0 Then
            EP.SetError(CMBPROCESS, "Fill Process Name")
            bln = False
        End If
        If CMBCONTRACTOR.Text.Trim.Length = 0 Then
            EP.SetError(CMBCONTRACTOR, "Fill Contractor")
            bln = False
        End If
        If CMBSUPERVISOR.Text.Trim.Length = 0 Then
            EP.SetError(CMBSUPERVISOR, "Fill Supervisor")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        CMBPROCESS.SelectedIndex = 0
        CMBCONTRACTOR.Text = ""
        CMBSUPERVISOR.Text = ""
        EDIT = False
    End Sub

    Private Sub MerchantPriceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillCombo()
            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(PROCESS_NAME, '') AS PROCESS, ISNULL(CONTRACTOR_NAME,'') AS CONTRACTOR, SUPERVISIOR_NAME AS SUPERVISOR ", "", " PROCESSMASTER INNER JOIN  PROCESSCONTRACTOR ON PROCESSMASTER.PROCESS_ID = PROCESSCONTRACTOR.PROCESSID INNER JOIN CONTRACTORMASTER ON PROCESSCONTRACTOR.CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id INNER JOIN SUPERVISIORMASTER ON PROCESSCONTRACTOR.SUPERVISORID = SUPERVISIORMASTER.SUPERVISIOR_id  ", " AND PROCESSCONTRACTOR.YEARID = " & YearId & "")
            GRIDBILLDETAILS.DataSource = DT
            If DT.Rows.Count > 0 Then
                GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
                GRIDBILL.TopRowIndex = GRIDBILL.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            GRIDDOUBLECLICK = True
            CMBPROCESS.Text = GRIDBILL.GetFocusedRowCellValue("PROCESS")
            CMBCONTRACTOR.Text = GRIDBILL.GetFocusedRowCellValue("CONTRACTOR")
            CMBSUPERVISOR.Text = GRIDBILL.GetFocusedRowCellValue("SUPERVISOR")
            CMBPROCESS.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown
        If e.KeyCode = Keys.Delete Then
            If GRIDBILL.GetFocusedRowCellValue("PROCESS") = "" Then Exit Sub

            'DELETE FROM TABLE ALSO
            Dim TEMPMSG As Integer = MsgBox("Delete Entry of " & GRIDBILL.GetFocusedRowCellValue("PROCESS") & "?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim DT As New DataTable
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(GRIDBILL.GetFocusedRowCellValue("PROCESS"))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)

                Dim OBJ As New ClsProcessContractorConfig
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

                fillgrid()
            End If
        End If
    End Sub

    Private Sub cmbCONTRACTOR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCONTRACTOR.GotFocus
        Try
            If CMBCONTRACTOR.Text.Trim = "" Then fillCONTRACTOR(CMBCONTRACTOR)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbCONTRACTOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCONTRACTOR.Validating
        Try
            If CMBCONTRACTOR.Text.Trim <> "" Then CONTRACTORvalidate(CMBCONTRACTOR, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbSUPERVISIOR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSUPERVISOR.GotFocus
        Try
            If CMBSUPERVISOR.Text.Trim = "" Then fillSUPERVISIOR(CMBSUPERVISOR)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbSUPERVISIOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSUPERVISOR.Validating
        Try
            If CMBSUPERVISOR.Text.Trim <> "" Then
                SUPERVISIORvalidate(CMBSUPERVISOR, e, Me)

                If CMBPROCESS.Text.Trim = "" Or CMBCONTRACTOR.Text.Trim = "" Or CMBSUPERVISOR.Text.Trim = "" Then
                    MsgBox("Select Proper Data", MsgBoxStyle.Critical, CmpName)
                    CMBPROCESS.Focus()
                    Exit Sub
                End If
                If CMBPROCESS.Text.Trim <> "" And CMBCONTRACTOR.Text.Trim <> "" And CMBSUPERVISOR.Text.Trim <> "" Then
                    If Not CHECKDUPLICATE() Then
                        e.Cancel = True
                        Exit Sub
                    End If
                    If GRIDDOUBLECLICK = False Then
                        SAVE()
                    Else
                        UPDATERECORD()
                    End If
                    fillgrid()
                Else
                    MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MerchantPriceList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(PROCESS_name, '') AS PROCESS", "", " PROCESSMASTER INNER JOIN  PROCESSCONTRACTOR ON PROCESSMASTER.PROCESS_ID = PROCESSCONTRACTOR.PROCESSID INNER JOIN CONTRACTORMASTER ON PROCESSCONTRACTOR.CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id INNER JOIN SUPERVISIORMASTER ON PROCESSCONTRACTOR.SUPERVISORID = SUPERVISIORMASTER.SUPERVISIOR_id ", "  AND PROCESS_name='" & CMBPROCESS.Text.Trim & "' AND YEARID = " & YearId & "")
            If DT.Rows.Count > 0 Then
                MsgBox(" Entry already Done")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDEXCEL_Click(sender As Object, e As EventArgs) Handles CMDEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Merchant Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Merchant Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Merchant Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class