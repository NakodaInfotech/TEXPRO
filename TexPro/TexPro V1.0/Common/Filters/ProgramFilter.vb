
Imports BL
Imports DevExpress.Pdf.Xmp

Public Class ProgramFilter

    Private Sub ProgramFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FILLCMB()
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            fillCATEGORY(CMBPRGCATEGORY, False)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DTITEM As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY ", " ", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' AND ITEMMASTER.ITEM_SHOWINPRGREPORT = 'TRUE' AND ITEMMASTER.ITEM_YEARID = '" & YearId & "' ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDBILLDETAILSITEM.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDBILLITEM.FocusedRowHandle = GRIDBILLITEM.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(sender As Object, e As EventArgs) Handles cmdshow.Click
        Try
            Dim ITEMCLAUSE As String = ""
            Dim OBJMFG As New mfgdesign
            OBJMFG.frmstring = "PRGREPORT"
            OBJMFG.selfor_po = "{PRGREPORTVIEW.YEARID} = " & YearId
            OBJMFG.MdiParent = MDIMain

            'FOR ITEMNAME
            GRIDBILLITEM.ClearColumnsFilter()
            For i As Integer = 0 To GRIDBILLITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then
                        ITEMCLAUSE = " AND ({PRGREPORTVIEW.MERCHANT} = '" & dtrow("ITEMNAME") & "'"
                    Else
                        ITEMCLAUSE = ITEMCLAUSE & " OR {PRGREPORTVIEW.MERCHANT} = '" & dtrow("ITEMNAME") & "'"
                    End If
                End If
            Next
            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                OBJMFG.selfor_po = OBJMFG.selfor_po & ITEMCLAUSE
            End If

            If CMBPRGCATEGORY.Text <> "" Then OBJMFG.selfor_po = OBJMFG.selfor_po & " and {PRGREPORTVIEW.PRGCATEGORY}='" & CMBPRGCATEGORY.Text.Trim & "'"

            OBJMFG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class