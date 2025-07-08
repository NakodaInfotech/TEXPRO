
Imports DB

Public Class ClsPSJob

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_MFG_PACKINGSLIP_JOB_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PS_NO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@fbno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@jobno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@orderno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalbundle", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gtotal", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPENSEREPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JODONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BUNDLE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNTYPE", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_MFG_PACKINGSLIP_JOB_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter


                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMP_PS_NO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@fbno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@jobno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@orderno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalbundle", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gtotal", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPENSEREPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JODONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BUNDLE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PS_NO", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectPS() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPSJOB_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@PSno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CmpID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(I)))
                I = I + 1

            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_MFG_PACKINGSLIP_JOB_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PS_no", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Userid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(5)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
