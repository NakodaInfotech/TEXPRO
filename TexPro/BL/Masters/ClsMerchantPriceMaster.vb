
Imports DB

Public Class ClsMerchantPriceMaster

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
            'save purchase REQUEST
            Dim strCommand As String = "SP_MASTER_MERCHANTRATE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WHITE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CREAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRADARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RAINBOW", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRESHRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
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
            'Update purchase order
            Dim strCommand As String = "SP_MASTER_MERCHANTRATE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WHITE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CREAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRADARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RAINBOW", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRESHRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Try
            'Update purchase order
            Dim strCommand As String = "SP_MASTER_MERCHANTRATE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MERCHANTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
