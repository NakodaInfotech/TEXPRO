
Imports BL
Imports System.Windows.Forms

Public Class ProcessMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean = False
    Public tempprocessName As String
    Public tempprocessId As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMBPROCESS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS, " AND PROCESSMASTER.PROCESS_TYPE<>''", edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then
                pcase(CMBPROCESS)

                'GETTING DATA FOR EDIT MODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" PROCESSMASTER.PROCESS_NAME AS PROCESSNAME, ITEMMASTER.item_name AS ITEMNAME, PROCESS_DESC.PROCESS_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, PROCESS_DESC.PROCESS_RATE AS RATE, PROCESS_DESC.PROCESS_REMARKS AS REMARKS,PROCESS_DESC.PROCESS_perpcs AS PERPCS", "", " PROCESS_DESC INNER JOIN PROCESSMASTER ON PROCESS_DESC.PROCESS_id = PROCESSMASTER.PROCESS_ID AND PROCESS_DESC.PROCESS_cmpid = PROCESSMASTER.PROCESS_CMPID AND PROCESS_DESC.PROCESS_locationid = PROCESSMASTER.PROCESS_LOCATIONID AND PROCESS_DESC.PROCESS_yearid = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN UNITMASTER ON PROCESS_DESC.PROCESS_yearid = UNITMASTER.unit_yearid AND PROCESS_DESC.PROCESS_locationid = UNITMASTER.unit_locationid AND PROCESS_DESC.PROCESS_cmpid = UNITMASTER.unit_cmpid AND PROCESS_DESC.PROCESS_unitid = UNITMASTER.unit_id LEFT OUTER JOIN ITEMMASTER ON PROCESS_DESC.PROCESS_yearid = ITEMMASTER.item_yearid AND PROCESS_DESC.PROCESS_locationid = ITEMMASTER.item_locationid AND PROCESS_DESC.PROCESS_cmpid = ITEMMASTER.item_cmpid AND PROCESS_DESC.PROCESS_ITEMid = ITEMMASTER.item_id", " AND PROCESSMASTER.PROCESS_NAME = '" & CMBPROCESS.Text.Trim & "' AND PROCESS_DESC.PROCESS_CMPID = " & CmpId & " AND PROCESS_DESC.PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_DESC.PROCESS_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    gridprocess.RowCount = 0
                    For Each DTROW As DataRow In DT.Rows
                        gridprocess.Rows.Add(DTROW("ITEMNAME"), Format(DTROW("QTY"), "0.00"), DTROW("UNIT"), Format(DTROW("RATE"), "0.00"))
                        txtremarks.Text = DTROW("REMARKS")
                        txtperpcs.Text = DTROW("perpcs")
                    Next
                    edit = True
                End If

                'DONT ALLOW USER TO ADD NEW PROCESS
                '                Dim objclscommon As New ClsCommonMaster
                '                Dim dt As DataTable
                '                dt = objclscommon.search("process_name", "", "processMaster", " and process_name = '" & CMBPROCESS.Text.Trim & "' and process_cmpid = " & CmpId & " and process_locationid = " & Locationid & " and process_yearid = " & YearId)
                '                If dt.Rows.Count = 0 Then
                '                    Dim a As String = CMBPROCESS.Text.Trim
                '                    Dim tempmsg As Integer = MsgBox("processing  not present, Add New?", MsgBoxStyle.YesNo, "Safex Engg.")
                '                    If tempmsg = vbYes Then

                '                        If USERADD = False Then
                '                            MsgBox("Insufficient Rights")
                '                            Exit Sub
                '                        End If
                '                        CMBPROCESS.Text = a
                '                        Dim alParaval As New ArrayList

                '                        alParaval.Add(CMBPROCESS.Text.Trim)
                '                        alParaval.Add("")
                '                        alParaval.Add(CmpId)
                '                        alParaval.Add(Locationid)
                '                        alParaval.Add(Userid)
                '                        alParaval.Add(YearId)
                '                        alParaval.Add(0)
                '                        alParaval.Add(0)

                '                        Dim objclsprocessname As New ClsprocessMaster
                '                        objclsprocessname.alParaval = alParaval
                '                        IntResult = objclsprocessname.save()
                '                        dt = objclscommon.search("process_name", "", "processMaster", " and process_name = '" & CMBPROCESS.Text.Trim & "' and process_cmpid = " & CmpId & " and process_locationid = " & Locationid & " and process_yearid = " & YearId)
                '                        If dt.Rows.Count > 0 Then
                '                            Dim dt1 As New DataTable
                '                            dt1 = CMBPROCESS.DataSource
                '                            If CMBPROCESS.DataSource <> Nothing Then
                'line1:
                '                                If dt1.Rows.Count > 0 Then
                '                                    dt1.Rows.Add(CMBPROCESS.Text.Trim)
                '                                    CMBPROCESS.Text = a
                '                                End If
                '                            End If
                '                        End If

                '                        e.Cancel = True
                '                    Else
                '                        CMBPROCESS.Focus()
                '                        CMBPROCESS.SelectAll()
                '                        e.Cancel = True
                '                    End If
                '                End If
            End If
        Catch ex As Exception
            'GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdotkeypress(e, txtrate, Me)
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdotkeypress(e, txtqty, Me)
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList


            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(txtperpcs.Text.Trim)

            Dim itemname As String = ""
            Dim QTY As String = ""
            Dim RATE As String = ""
            Dim gridunit As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridprocess.Rows
                If itemname = "" Then
                    itemname = row.Cells(GITEMNAME.Index).Value
                    QTY = row.Cells(GQTY.Index).Value
                    RATE = row.Cells(GRATE.Index).Value
                    gridunit = row.Cells(GUNIT.Index).Value
                Else
                    itemname = itemname & "," & row.Cells(GITEMNAME.Index).Value
                    QTY = QTY & "," & row.Cells(GQTY.Index).Value
                    RATE = RATE & "," & row.Cells(GRATE.Index).Value
                    gridunit = gridunit & "," & row.Cells(GUNIT.Index).Value
                End If
            Next

            alParaval.Add(itemname)
            alParaval.Add(QTY)
            alParaval.Add(gridunit)
            alParaval.Add(RATE)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim obclsprocessmaster As New ClSProcessMaster
            obclsprocessmaster.alParaval = alParaval
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            IntResult = obclsprocessmaster.savePROCESSDESC()
            MsgBox("Details Added")

            clear()
            CMBPROCESS.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        gridprocess.RowCount = 0
        cmbitemname.Text = ""
        txtqty.Clear()
        cmbunit.Text = ""
        txtrate.Clear()
        txtremarks.Clear()
        edit = False
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If CMBPROCESS.Text.Trim.Length = 0 Then
            EP.SetError(CMBPROCESS, "Please Select Process Name")
            bln = False
        End If

        If gridprocess.RowCount = 0 Then
            EP.SetError(txtrate, "Please Fill Item Details")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If gridDoubleClick = False Then
            gridprocess.Rows.Add(cmbitemname.Text.Trim, Val(txtqty.Text.Trim), cmbunit.Text.Trim, Val(txtrate.Text.Trim))
        ElseIf gridDoubleClick = True Then
            gridprocess.Rows(tempRow).Cells(GITEMNAME.Index).Value = cmbitemname.Text.Trim
            gridprocess.Rows(tempRow).Cells(GQTY.Index).Value = Val(txtqty.Text.Trim)
            gridprocess.Rows(tempRow).Cells(GRATE.Index).Value = Val(txtrate.Text.Trim)
            gridprocess.Rows(tempRow).Cells(GUNIT.Index).Value = cmbunit.Text.Trim

            gridDoubleClick = False
        End If
        gridprocess.FirstDisplayedScrollingRowIndex = gridprocess.RowCount - 1
        txtqty.Clear()
        txtrate.Clear()
        cmbunit.Text = ""
        cmbitemname.Focus()

    End Sub

    Private Sub gridprocess_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridprocess.CellDoubleClick
        If e.RowIndex >= 0 And gridprocess.Item(GITEMNAME.Index, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            cmbitemname.Text = gridprocess.Item(GITEMNAME.Index, e.RowIndex).Value
            txtqty.Text = gridprocess.Item(GQTY.Index, e.RowIndex).Value
            txtrate.Text = gridprocess.Item(GRATE.Index, e.RowIndex).Value
            cmbunit.Text = gridprocess.Item(GUNIT.Index, e.RowIndex).Value
            tempRow = e.RowIndex
            cmbitemname.Focus()
        End If
    End Sub

    Private Sub gridprocess_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridprocess.KeyDown
        If e.KeyCode = Keys.Delete Then
            gridprocess.Rows.RemoveAt(gridprocess.CurrentRow.Index)
        End If
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

    Private Sub processMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub processMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PROCESS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                CMBPROCESS.Text = ""
            End If
            fillcombos()
            CMBPROCESS.Text = tempprocessName

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        fillunit(cmbunit)
        fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        FILLPROCESS(CMBPROCESS, " AND PROCESSMASTER.PROCESS_TYPE<>''", edit)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try
            If CMBPROCESS.Text.Trim = "" Then
                MsgBox("Select Process First", MsgBoxStyle.Critical, CmpName)
                CMBPROCESS.Focus()
            End If
            If cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbunit.Text.Trim <> "" Then
                'CHECK WHETHER ITEM IS PRESENT IN GRID BELOW OR NOT
                For Each ROW As DataGridViewRow In gridprocess.Rows
                    If (LCase(ROW.Cells(GITEMNAME.Index).Value) = LCase(cmbitemname.Text.Trim) And gridDoubleClick = False) Or (LCase(ROW.Cells(GITEMNAME.Index).Value) = LCase(cmbitemname.Text.Trim) And gridDoubleClick = True And tempRow <> ROW.Index) Then
                        MsgBox("Item Already Present in Grid Below", MsgBoxStyle.Critical)
                        cmbitemname.Focus()
                        Exit Sub
                    End If
                Next
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class