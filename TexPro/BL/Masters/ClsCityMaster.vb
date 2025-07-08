Imports DB
Imports System.Data

Public Class ClsCityMaster

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

    Public Function save() As Integer

        Dim intResult As Integer
        'Dim cityid, stateid, countryid As Integer

        'Dim objTrans As SqlClient.SqlTransaction
        'objTrans = objDBOperation.StartNewTransaction
        Try

            Dim strCommand As String = "SP_MASTER_CMPMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                '.Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                '.Add(New SqlClient.SqlParameter("@cmpperson", alParaval(1)))
                '.Add(New SqlClient.SqlParameter("@cmppersontype", alParaval(2)))
                '.Add(New SqlClient.SqlParameter("@cmpdisplayedname", alParaval(3)))
                '.Add(New SqlClient.SqlParameter("@cmpinvinitials", alParaval(4)))
                '.Add(New SqlClient.SqlParameter("@cmpinvfooter", alParaval(5)))
                '.Add(New SqlClient.SqlParameter("@cmpadd1", alParaval(6)))
                '.Add(New SqlClient.SqlParameter("@cmpadd2", alParaval(7)))
                '.Add(New SqlClient.SqlParameter("@cmpcityid", cityid))
                '.Add(New SqlClient.SqlParameter("@cmpzipcode", alParaval(9)))
                '.Add(New SqlClient.SqlParameter("@cmpstateid", stateid))
                '.Add(New SqlClient.SqlParameter("@cmpcountryid", countryid))
                '.Add(New SqlClient.SqlParameter("@cmptel", alParaval(12)))
                '.Add(New SqlClient.SqlParameter("@cmpfax", alParaval(13)))
                '.Add(New SqlClient.SqlParameter("@cmpemail", alParaval(14)))
                '.Add(New SqlClient.SqlParameter("@cmpwebsite", alParaval(15)))
                '.Add(New SqlClient.SqlParameter("@cmpvatno", alParaval(16)))
                '.Add(New SqlClient.SqlParameter("@cmpcstno", alParaval(17)))
                '.Add(New SqlClient.SqlParameter("@cmpstno", alParaval(18)))
                '.Add(New SqlClient.SqlParameter("@cmppanno", alParaval(19)))
                '.Add(New SqlClient.SqlParameter("@cmpeccno", alParaval(20)))
                '.Add(New SqlClient.SqlParameter("@cmpexciseno", alParaval(21)))
                '.Add(New SqlClient.SqlParameter("@cmpplano", alParaval(22)))
                '.Add(New SqlClient.SqlParameter("@cmprange", alParaval(23)))
                '.Add(New SqlClient.SqlParameter("@cmpdivision", alParaval(24)))
                '.Add(New SqlClient.SqlParameter("@cmpexciseoff", alParaval(25)))
                '.Add(New SqlClient.SqlParameter("@cmpdivisionoff", alParaval(26)))
                '.Add(New SqlClient.SqlParameter("@cmpcommissionerate", alParaval(27)))
                '.Add(New SqlClient.SqlParameter("@cmpheadingno", alParaval(28)))
                '.Add(New SqlClient.SqlParameter("@cmpnotificationno", alParaval(29)))
                '.Add(New SqlClient.SqlParameter("@cmppassword", alParaval(30)))
                '.Add(New SqlClient.SqlParameter("@cmpuserid", alParaval(31)))
                '.Add(New SqlClient.SqlParameter("@cmptransfer", alParaval(32)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function search(ByVal fld1 As String, Optional ByVal fld2 As String = "", Optional ByVal tablename As String = "", Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GET_ANYID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@ptable_name", tablename))
                .Add(New SqlClient.SqlParameter("@fld2", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UpdateCity() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_CITYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@city_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@city_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@city_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@city_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@city_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@city_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@city_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cityid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateArea() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_AREAMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@area_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@area_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@area_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@area_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@area_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@area_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@area_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@areaid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateState() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_STATEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@state_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@state_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@state_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@state_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@state_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@state_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@state_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@stateid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateExpense() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_EXPENSEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@EXP_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@EXP_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@EXP_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@EXP_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@EXP_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@EXP_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@EXP_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@EXP_id", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function


    Public Function UpdateCountry() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_COUNTRYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@Country_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Country_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Country_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Country_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Country_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@Country_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@Country_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@Countryid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
