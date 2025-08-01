﻿
Imports DB
Public Class ClsLogsDelete
    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Functions"

    Public Function DELETE() As Integer
        Try
            Dim strCommand As String = "SP_UTILITIES_LOGSDELETE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DELID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
            End With
            Dim intResult As Integer = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE_DATE() As Integer
        Try
            Dim strCommand As String = "SP_UTILITIES_LOGSDELETE_DELETEDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
            End With
            Dim intResult As Integer = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

End Class
