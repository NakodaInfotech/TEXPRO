Imports DB

Public Class clsItemmaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_ITEMMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@material", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@category", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPSTOCK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPVALUE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REORDER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@upper", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@lower", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FRMSTRING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SUBCATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer

        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_MASTER_ITEMMASTER_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@material", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@category", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPSTOCK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OPVALUE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REORDER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@upper", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@lower", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FRMSTRING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SUBCATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@itemid", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_MASTER_ITEMMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ITEMID", alParaval(0)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
