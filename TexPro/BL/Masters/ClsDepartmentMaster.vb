﻿
Imports DB

Public Class ClsDepartmentMaster

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

#Region "Function"

    Public Function save() As Integer
        Dim intResult As Integer

        Try

            'save DEPARTMENTMaster
            Dim strCommand As String = "SP_MASTER_DEPARTMENTMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@DEPARTMENTname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@INVENTORY", alParaval(7)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer

        Try

            'save DEPARTMENTMaster
            Dim strCommand As String = "SP_MASTER_DEPARTMENTMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@DEPARTMENTname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@INVENTORY", alParaval(7)))
                .Add(New SqlClient.SqlParameter("DEPARTMENTid", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function savedepartmentpricelist() As Integer
        Dim intResult As Integer

        Try

            'save DEPARTMENTMaster
            Dim strCommand As String = "SP_MASTER_DEPARTMENTPRICELIST_SAVE"
            Dim alParameter As New ArrayList
            With alParameter




                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function
#End Region

End Class
