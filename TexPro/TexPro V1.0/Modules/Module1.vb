Imports System.IO

Module Module1

    '******** COMMON VARIABLES **************
    Public Mydate As Date                                               'Used for SQL Date throughout the Software at the time of login

    'Public Servername As String = "tcp:sql2k801.discountasp.net"         'Used for Servername for reports
    'Public DatabaseName As String = "SQL2008_671357_jjindustries"
    'Public DBUSERNAME As String = "SQL2008_671357_jjindustries_user"          'Used for Servername username for reports
    'Public Dbpassword As String = "infosys123"         ''Usedrr for Servername password for reports
    'Public Dbsecurity As Boolean = False

    '----------------- NOTEPAD CODE---------
    'Public oFile As System.IO.File
    'Public oRead As System.IO.StreamReader = File.OpenText("C:\SERVERNAME.txt")
    'Public SERVERNAME As String = oRead.ReadToEnd
    ''----------------- NOTEPAD CODE---------

    'Public DatabaseName As String = "TEXPRO"          'Used for Servername for reports'
    'Public DBUSERNAME As String = "sa"
    'Public Dbpassword As String = "Infosys@123"
    'Public Dbsecurity As Boolean = False

    'Public DBUSERNAME As String = ""
    'Public Dbpassword As String = ""
    'Public Dbsecurity As Boolean = True


    Public SERVERNAME As String
    Public DatabaseName As String
    Public DBUSERNAME As String             'Used for Servername username for reports
    Public Dbpassword As String         ''Used for Servername password for reports
    Public Dbsecurity As Boolean


    '******** FORM WISE VARIABLES ************
    '---CMPDETAILS---
    Public CmpName As String            'Used for CmpName throughout the software 
    Public CmpInitials As String        'Used for CmpInitials throughout the software 
    Public DBName As String             'Used for DBName throughout the software 
    Public CmpId As Integer             'Used for CmpId throughout the software
    Public YearId As Integer            'Used for YearId throughout the software
    Public AccFrom, AccTo As DateTime   'Used for A/C year start and end throughout the software
    Public Locationid As Integer        'Used for Locationid while login
    Public strsearch As String        'Used for strsearch 

    '---LOGIN---
    Public Userid As Integer            'Used for Userid while login
    Public UserName As String               'User for UserName while Login
    Public DEPARTMENTNAME As String = ""             'User for DEPARTMENTNAME while Login
    Public USERRIGHTS As DataTable          'USED FOR USER RIGHTS THROUGHOUT THE APPLICATION 
    Public INVOICESCREENTYPE As String
    Public PURCHASESCREENTYPE As String
    Public ALLOWMANUALINVNO As Boolean = True
    Public ALLOWMANUALLOTNO As Boolean
    Public USERGODOWN As String = ""


    'THESE VARIABLES ARE USED FOR EWB AND GST
    Public ALLOWEWAYBILL, ALLOWEINVOICE As Boolean
    Public PRINTEWAYBILL As Boolean
    Public CMPEWBUSER As String       'Used for COMPANY'S EWBUSER
    Public CMPEWBPASS As String       'Used for COMPANY'S EWBPASS
    Public CMPGSTIN As String       'Used for COMPANY'S GSTIN
    Public CMPPINCODE As String       'Used for COMPANY'S PINCODE
    Public CMPCITYNAME As String       'Used for COMPANY'S CITYNAME
    Public CMPSTATENAME As String       'Used for COMPANY'S STATE NAME
    Public CMPSTATECODE As String       'Used for COMPANY'S STATE CODE
    Public CMPEWAYCOUNTER As Integer    'Used for COMPANY'S EWB COUNTER
    Public EWAYEXPDATE As Date          'Used for COMPANY'S EWB EXPIRY DATE
    Public CMPEINVOICECOUNTER As Integer    'Used for COMPANY'S EINVOICE COUNTER
    Public EINVOICEEXPDATE As Date          'Used for COMPANY'S EINVOICE EXPIRY DATE

    Public ALLOWMANUALCNDN As Boolean
    Public ISLOCKYEAR As Boolean = False
    Public CNBLOCKDATE As Date = AccFrom.Date
    Public DNBLOCKDATE As Date = AccFrom.Date
    Public EXPBLOCKDATE As Date = AccFrom.Date
    Public ALLOWWHATSAPP As Boolean
    Public WHATSAPPEXPDATE As Date

    Public ClientName As String = ""

    Public Sub GETCONN()
        Try
            '-------NOTEPAD CODE --------

            Dim STARTPOS, ENDPOS As Integer
            Dim CONNSTR As String
            Dim oRead As System.IO.StreamReader = File.OpenText("C:\CONNECTIONSTRING.txt")
            CONNSTR = oRead.ReadToEnd

            STARTPOS = CONNSTR.IndexOf("=", 0)
            ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
            SERVERNAME = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
            ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
            DatabaseName = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            If CONNSTR.IndexOf("User ID", ENDPOS) > 0 Then
                STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
                ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
                DBUSERNAME = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

                STARTPOS = CONNSTR.IndexOf("=", ENDPOS)
                ENDPOS = CONNSTR.IndexOf(";", STARTPOS)
                Dbpassword = CONNSTR.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

                Dbsecurity = False

            Else
                DBUSERNAME = ""
                Dbpassword = ""
                Dbsecurity = True
            End If

            '----------------- NOTEPAD CODE---------
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




End Module
