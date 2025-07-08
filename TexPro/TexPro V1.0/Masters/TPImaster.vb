
Imports BL
Imports System.Windows.Forms

Public Class TPImaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public edit As Boolean           'Used for edit
    Public tempTPIName As String
    Public tempctperson As String
    Public tempphone As String
    Public tempaddress As String
    Public tempremarks As String
    Public tempTPIId As Integer
    
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtctperson.Text.Trim)
            alParaval.Add(txtphone.Text.Trim)
            alParaval.Add(txtaddress.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim objtpiMaster As New ClsTPIMaster
            objtpiMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objtpiMaster.save()
                MsgBox("Details Added")
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempTPIId)
                IntResult = objtpiMaster.Update()
                MsgBox("Details Updated")
                edit = False

            End If
            clear()
            txtname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill TPI Name")
            bln = False
        End If
        'If txtctperson.Text.Trim.Length = 0 Then
        '    Ep.SetError(txtctperson, "Fill Diameter Size")
        '    bln = False
        'End If       
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtctperson.Clear()
        txtphone.Clear()
        txtaddress.Clear()
        txtremarks.Clear()
        edit = False
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(tempTPIName) <> LCase(txtname.Text.Trim)) Then
                dt = objclscommon.search("TPI_Name", "", "TpiMaster", " and TPI_Name= '" & txtname.Text.Trim & "' and TPI_cmpid = " & CmpId & " and TPI_locationid = " & Locationid & " and TPI_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("TPI Name Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                    e.Cancel = True
                End If
            End If
            pcase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TPImaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Then
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Showing Report
            Call cmdok_Click(sender, e)
        End If
    End Sub

    Private Sub TPImaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'TPI MASTER'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If edit = True Then
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            txtname.Text = tempTPIName
            txtctperson.Text = tempctperson
            txtphone.Text = tempphone
            txtaddress.Text = tempaddress
            txtremarks.Text = tempremarks
        End If

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click

        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        If txtname.Text.Trim = "" Then
            MsgBox("TPI Name Can Not Be Blank ")
            Exit Sub
        End If

        If edit = False Then
            'since user can delete Master only in edit mode
            MsgBox("TPI Name Can Delete only in Edit Mode", MsgBoxStyle.Critical, "Tex Pro")
            Exit Sub
        End If

        'TPI name used in Work Order so check it exists in SalesOrder table
        'searching in Sales Order table
        If txtname.Text.Trim <> "" Then
            pcase(txtname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("TPI_name", "", "   dbo.TPIMASTER RIGHT OUTER JOIN dbo.SALEORDER ON dbo.TPIMASTER.TPI_id = dbo.SALEORDER.so_tpi ", " and TPI_Name= '" & txtname.Text.Trim & "' and TPI_cmpid = " & CmpId & " and TPI_locationid = " & Locationid & " and TPI_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("TPI Name Already Used in Transaction Forms Can't be Delete It", MsgBoxStyle.Critical, "Tex Pro")
                Exit Sub
            End If

        End If
        'code for deleting tpi master 
        Dim tempMsg As Integer
        Dim IntResult As Integer
        'if above all conditions are false then only user can delete Particular Master
        tempMsg = MsgBox("Delete TPI Name ?", MsgBoxStyle.YesNo)
        If tempMsg = vbYes Then
            Dim alParaval As New ArrayList
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)
            Dim clsTPImst As New ClsTPIMaster
            clsTPImst.alParaval = alParaval
            IntResult = clsTPImst.Delete()
            MsgBox("TPI Name Deleted")
            clear()
        End If

    End Sub
End Class