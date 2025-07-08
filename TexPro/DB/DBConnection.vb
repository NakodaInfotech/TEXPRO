''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''   Gulkit Jain
''                                                                                                          ''
''                                                                                                          ''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO

Public Class DBConnection

#Region "Common"

    Private objConnection As SqlConnection

    '----------------- NOTEPAD CODE---------
    Public Shared oFile As System.IO.File
    Public Shared oRead As System.IO.StreamReader = File.OpenText("C:\CONNECTIONSTRING.txt")
    Public Shared CONNECTIONSTR As String = oRead.ReadToEnd
    '----------------- NOTEPAD CODE---------

    'Public Shared ConnectionString As String = "Data Source=" & SERVERNAME & ";Initial Catalog=TEXPRO;User ID=sa;Password=Infosys123@#$;Integrated Security=True;connection timeout=2000"
    'Public Shared ConnectionString As String = "Data Source=" & SERVERNAME & ";Initial Catalog=TEXPRO;User ID=sa;Password=Infosys@123;connection timeout=2000"
    'Public Shared ConnectionString As String = "Data Source=" & SERVERNAME & ";Initial Catalog=TEXPRO;Integrated Security=True;connection timeout=2000"
    Public Shared ConnectionString As String = CONNECTIONSTR

    Public Shared CurrentYear As String
    Public Shared CurrentDB As String


    ' This Constrator use for set connection object 
    ' Connection String fetch from web.config 
    Public Sub New()
        Try
            Dim ConnectionString As String = DBConnection.ConnectionString
            SetConnection = ConnectionString

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
    

#Region "FOR DATABASE"

    ' This Property use for set connection object   ---- FOR DATABASE
    ' Property Value is a connection String
    Public WriteOnly Property SetConnection() As String
        Set(ByVal Value As String)
            objConnection = New SqlConnection(Value)
        End Set
    End Property


    ' This Property use for get connection object 
    Public ReadOnly Property GetConnection() As SqlConnection
        Get
            Return objConnection
        End Get
    End Property


    ' This method use for Open connection 
    Public Sub OpenConnection()
        Try
            GetConnection.Open()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ' This method use for Close connection 
    Public Sub CloseConnection()
        Try
            GetConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region




End Class
