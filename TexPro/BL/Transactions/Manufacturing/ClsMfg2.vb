
Imports DB

Public Class ClsMfg2
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
            Dim strCommand As String = "SP_TRANS_MANUFACTURING_MFGAFTERCUTTING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@MFGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMPROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOPROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALHRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDEFQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTQTY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALDEFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDAVG", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@jobno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CHART", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWCOLOR", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CPSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DEFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAINSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLSRNO1", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@srno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@colsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@screen", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@shade", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@wt", alParaval(I)))
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

                'AMTS
                .Add(New SqlClient.SqlParameter("@LABOURRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABOURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRAAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EXTRASRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATEON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRARATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@WORKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRESENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_MANUFACTURING_MFGAFTERCUTTING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@MFGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMPROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOPROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUPERVISOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALHRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDEFQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDEFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALACTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDAVG", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@jobno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CHART", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWCOLOR", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CPSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MFGSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DEFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MAINSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLSRNO1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@srno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@colsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@screen", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@shade", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@wt", alParaval(I)))
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


                'AMTS
                .Add(New SqlClient.SqlParameter("@LABOURRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABOURAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLORAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALEXTRAAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EXTRASRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATEON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRARATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@WORKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRESENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPMFGNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectmfg() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTMFGAFTERCUTTING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@MFGNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_MANUFACTURING_MFGAFTERCUTTING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@TEMPMFGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CmpID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
