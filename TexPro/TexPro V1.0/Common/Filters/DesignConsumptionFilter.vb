
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Imports BL

Public Class DesignConsumptionFilter

    Public FRMSTRING As String
    Dim edit As Boolean = False
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub FILLJOBNO(ByRef CMBJOBNO As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBJOBNO.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" distinct mfg_jobno ", "", " MFGMaster2 ", " and mfg_cmpid=" & CmpId & " and mfg_Locationid=" & Locationid & " and mfg_Yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "mfg_jobno"
                    CMBJOBNO.DataSource = dt
                    CMBJOBNO.DisplayMember = "mfg_jobno"
                    CMBJOBNO.Text = ""
                End If
                CMBJOBNO.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FillCombo()
        If CMBDESIGNNO.Text.Trim = "" Then fillDESIGN(CMBDESIGNNO)
        If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR)
        If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE='MFG2'", False)
        If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
    End Sub

    Private Sub DesignConsumptionFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJCOST As New consumedesign
            If RDBJOBDTLS.Checked = True Then
                OBJCOST.FRMSTRING = "JOBCOSTDTLS"
            ElseIf RDBJOBDESIGNDTLS.Checked = True Then
                OBJCOST.FRMSTRING = "JOBDESIGNCOSTDTLS"
            ElseIf RDBPROCESSDTLS.Checked = True Then
                OBJCOST.FRMSTRING = "DESIGNPROCESSCUNSUMPTIONDTLS"
            End If

            OBJCOST.CONDITION = "{CONSUMPTION_DESIGN_COST_VIEW.YEARID}= " & YearId

            If CMBJOBNO.Text.Trim <> "" Then OBJCOST.CONDITION = OBJCOST.CONDITION & " and {CONSUMPTION_DESIGN_COST_VIEW.JOBNO}= '" & CMBJOBNO.Text.Trim & "'"
            If CMBDESIGNNO.Text.Trim <> "" Then OBJCOST.CONDITION = OBJCOST.CONDITION & " and {CONSUMPTION_DESIGN_COST_VIEW.DESIGNNO}='" & CMBDESIGNNO.Text.Trim & "'"
            If CMBCOLOR.Text.Trim <> "" Then OBJCOST.CONDITION = OBJCOST.CONDITION & " and {CONSUMPTION_DESIGN_COST_VIEW.COLOR}='" & CMBCOLOR.Text.Trim & "'"
            If cmbprocess.Text.Trim <> "" Then OBJCOST.CONDITION = OBJCOST.CONDITION & " and {CONSUMPTION_DESIGN_COST_VIEW.PROCESS}='" & cmbprocess.Text.Trim & "'"
            If CMBMERCHANT.Text.Trim <> "" Then OBJCOST.CONDITION = OBJCOST.CONDITION & " and {CONSUMPTION_DESIGN_COST_VIEW.ITEMNAME}='" & CMBMERCHANT.Text.Trim & "'"

            If chkdate.Checked = True Then
                getFromToDate()
                OBJCOST.CONDITION = OBJCOST.CONDITION & " and ({@date} in date " & fromD & " to date " & toD & ")"
                OBJCOST.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy")
            Else
                OBJCOST.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            OBJCOST.MdiParent = MDIMain
            OBJCOST.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbprocess_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocess.Enter
        If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE='MFG2'", False)
    End Sub

    Private Sub DesignConsumptionFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILLJOBNO(CMBJOBNO)
        FillCombo()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class