Imports DB

Public Class ClsFinalCUTTINGPROCESS

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
            Dim strCommand As String = "SP_TRANS_MFG_FINALCUTTINGPROCESS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LEDGERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALDEFQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDEFRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CPSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CONSUMEDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSUMEDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEFQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEFRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTRATE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CONSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDMERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                'HELPERS
                .Add(New SqlClient.SqlParameter("@HSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HELPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HELPERNAMES", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@GREYMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTAGEPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFFMTRS", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_MFG_FINALCUTTINGPROCESS_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LEDGERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALDEFQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDEFRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CPSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CONSUMEDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSUMEDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEFQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEFRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTRATE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CONSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDMERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                'HELPERS
                .Add(New SqlClient.SqlParameter("@HSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HELPERS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HELPERNAMES", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@GREYMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTAGEPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFFMTRS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@FCP_NO", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectFCP() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTFCP_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@FCPno", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_Mfg_FINALCUTTINGPROCESS_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fCP_no", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@process", alParaval(5)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
