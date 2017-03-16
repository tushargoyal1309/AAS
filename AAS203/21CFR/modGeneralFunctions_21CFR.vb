Option Explicit On 
Imports AAS203.Signature
Imports AAS203.Common
Imports System.Data
Imports System.Data.OleDb


Module modGeneralFunctions_21CFR
    '//----- DECLARE AS GLOBAL DECLARATION
    Public gOleDBConnection_LogBook As OleDb.OleDbConnection
    Public gOleDBConnectionString_LogBook As String
    Public gclsDBFunctions As New clsDatabaseFunctions
    Public gOleDBUserInfoConnection As OleDb.OleDbConnection
    Public gOleDBConnectionString_UserInfo As String
    '--- Structure used to store the user information for the current
    '--- Session
    Public gstructUserDetails As structUserDetails

    '---Structure used to store the User Details logged in
    Structure structUserDetails
        Dim SessionID As Long
        Dim UserName As String
        Dim UserID As String
        Dim UserPassword As String
        Dim Access As ArrayList
    End Structure
    '//-----
#Region "Activity Authentication Check"

    Public Function funcCheckActivityAuthentication(ByVal lngActivityID As Long, _
                                                ByVal arrAccess As ArrayList) As Boolean
        '=====================================================================
        ' Procedure Name        : funcCheckActivityAuthentication
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To check the user anthentication for partic-
        '                       : -ular activity.  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objReaderAccess As OleDb.OleDbDataReader
        Dim strSQL As String
        Dim objWait As New CWaitCursor
        Try

            '--- Since the administrator has all the authority there is no need for cheking
            '--- Authentications
            If gstructUserDetails.UserID = 0 Then
                Return True
            End If

            strSQL = "Select AccessMaster.Suspend From AccessMaster " & _
                    "Where AccessMaster.AccessID = " & lngActivityID

            If gclsDBFunctions.GetRecords(strSQL, gOleDBUserInfoConnection, objReaderAccess) Then
                While objReaderAccess.Read
                    If Val(Convert.ToInt64(objReaderAccess.Item("Suspend")) & "") = 1 Then
                        Return True
                    End If
                End While
            End If
            objReaderAccess.Close()

            If arrAccess.Contains(lngActivityID) Then
                Return True
            Else
                '--- Dispay the message
                Call gobjMessageAdapter.ShowMessage(gstructUserDetails.UserName & " has no authority granted to access this activity.", "Authentication Check", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Return False
            End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function
#End Region

#Region "Activity/File Log"

    '--------------------------------------------------------
    '    Global functions used to insert into Activity Log and File Log.
    '--- gfuncInsertActivityLog - To Add / Insert a record in Activity Log table.
    '--- gfuncInsertFileLog - To Add / Insert a record in File Log table.

    Public Function gfuncGetFileAuthenticationData(ByRef obj As AAS203.Signature.DigitalSignature) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetFileAuthenticationData
        ' Description           :   To Get Digital signature input during File Save if 21CFR is enabled.
        ' Purpose               :   To Get Digital signature input during File Save if 21CFR is enabled.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   March, 2003 
        ' Revisions             :
        '=====================================================================

        Try
            Dim frmAuthentication As New frmAuthentication

            'modified by kamal
            'If gstructUserDetails.UserID = 0 Then
            '    Return True
            'End If
            '-----

            obj.UserID = Convert.ToInt64(gstructUserDetails.UserID)
            obj.UserName = gstructUserDetails.UserName
            obj.LoginPassword = gstructUserDetails.UserPassword
            obj.SaveDate = Date.Today

            frmAuthentication.subInitialize(obj)
            If frmAuthentication.ShowDialog() = DialogResult.OK Then
                If frmAuthentication.RBFile.Checked Then
                    frmAuthentication.txtPassword.Focus()
                    obj.ActivityType = ENUM_ActivityType.FileAuthentication
                    obj.FilePassword = frmAuthentication.txtPassword.Text
                Else
                    obj.ActivityType = ENUM_ActivityType.LoginAuthentication
                    obj.FilePassword = gstructUserDetails.UserPassword
                End If
                frmAuthentication.Dispose()
                Return True
            Else
                frmAuthentication.Dispose()
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function gfuncGetFileAuthenticationData_21CFR_OFF(ByRef obj As AAS203.Signature.DigitalSignature) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetFileAuthenticationData_21CFR_OFF
        ' Description           :   To Get Digital signature input during File Save if 21CFR is Diabled.
        ' Purpose               :   To Get Digital signature input during File Save if 21CFR is Diabled.
        ' this is to save the file with login Authentication when 21 cfr is disabled
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Nilesh shirode
        ' Created               :   28 June 2004
        ' Revisions             :
        '=====================================================================

        Try

            obj.UserID = Convert.ToInt64(gstructUserDetails.UserID)
            obj.UserName = gstructUserDetails.UserName
            obj.LoginPassword = gstructUserDetails.UserPassword
            obj.SaveDate = Date.Today


            obj.ActivityType = ENUM_ActivityType.LoginAuthentication
            obj.FilePassword = gstructUserDetails.UserPassword

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function gfuncCheckForFileAuthentication(ByVal objDS As AAS203.Signature.DigitalSignature) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncCheckForFileAuthentication
        ' Description           :   To check if the Digital signature passed matches with saved file and not to open file if not.
        ' Purpose               :   To check if the Digital signature passed matches with saved file and not to open file if not.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   March, 2003 
        ' Revisions             :
        '=====================================================================

        Try
            Dim intActivityType As Int32

            '---------------------------------------------------------------------------
            '1. Check for the authentication for the user
            '2. Check for Activity type, If Login authentication then, check the password
            '   with the current logged in user's password, If no match than
            '   ask for the password and verify the same.
            '3. If file authentication, then get the password and verify the same.
            '---------------------------------------------------------------------------
            'If gstructUserDetails.UserID = 0 Then
            '    Return True
            'End If

            If objDS.FilePassword = "" Then
                Return True
            End If

            Dim objfrmAuthentication As New frmAuthentication
            '   Dim objLoginScreen As New frmLoginAuthentication

            objfrmAuthentication.txtPassword.Focus()
            '1. Check for the authentication for the user
            '2. Check for Activity type, If Login authentication then, check the User ID
            '   with the current logged in user's ID, If no match than
            '   ask for the password and verify the same.
            If objDS.ActivityType = ENUM_ActivityType.LoginAuthentication Then
                '--- Check for UID and password
                If objDS.UserID = gstructUserDetails.UserID And _
                    objDS.LoginPassword = gstructUserDetails.UserPassword Then
                    Return True
                Else
                    'commented and added by kamal
                    '                    '--- Display the login screen
                    'GetLogin:
                    '                    objLoginScreen = New frmLoginAuthentication
                    '                    If objLoginScreen.ShowDialog() = DialogResult.OK Then
                    '                        If objLoginScreen.LoginSuccessfull Then
                    '                            Return True
                    '                        Else
                    '                            '--- Display the message for wrong password
                    '                            Call gFuncShowMessage("Invalid Password", "Invalid password, Please try again!!!", modConstants.EnumMessageType.Information)
                    '                            GoTo GetLogin
                    '                        End If
                    '                    Else
                    '                        Return False
                    '                    End If

                    '                End If

                    '--- The file has a password security
GetLoginPassword:
                    objfrmAuthentication = New frmAuthentication
                    objfrmAuthentication.subInitialize(objDS)
                    objfrmAuthentication.pnlPassword.Visible = True
                    objfrmAuthentication.pnlPassword.Enabled = True
                    objfrmAuthentication.txtPassword.Focus()
                    objfrmAuthentication.pnlAuthentication.Enabled = False

                    If objfrmAuthentication.ShowDialog() = DialogResult.OK Then
                        objfrmAuthentication.txtPassword.Focus()
                        '--- Check for the password
                        If objDS.FilePassword.ToString = objfrmAuthentication.txtPassword.Text.ToString Then
                            Return True
                        Else
                            '--- Display the message for wrong password
                            Call gobjMessageAdapter.ShowMessage(constInvalidPassword)
                            objfrmAuthentication.txtPassword.Focus()
                            GoTo GetLoginPassword
                        End If
                    Else
                        Return False
                    End If
                End If
            Else
                '--- The file has a password security
GetPassword:
                objfrmAuthentication = New frmAuthentication
                objfrmAuthentication.subInitialize(objDS)
                objfrmAuthentication.pnlPassword.Visible = True
                objfrmAuthentication.pnlPassword.Enabled = True
                objfrmAuthentication.pnlAuthentication.Enabled = False

                If objfrmAuthentication.ShowDialog() = DialogResult.OK Then
                    objfrmAuthentication.txtPassword.Focus()
                    '--- Check for the password
                    If objDS.FilePassword.ToString = objfrmAuthentication.txtPassword.Text.ToString Then
                        Return True
                    Else
                        '--- Display the message for wrong password
                        Call gobjMessageAdapter.ShowMessage(constInvalidPassword)
                        objfrmAuthentication.txtPassword.Focus()
                        GoTo GetPassword
                    End If
                Else
                    Return False
                End If

            End If
            objfrmAuthentication.Dispose()
            '       objLoginScreen.Dispose()
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log

            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------


        End Try
    End Function

    Public Function gfuncInsertActivityLog(ByVal Module_ID As Long, ByVal Log_desc As String, Optional ByVal strPassword As String = "") As Long
        '=====================================================================
        ' Procedure Name        :   gfuncInsertActivityLog
        ' Description           :   To Add / Insert a record in Activity Log table.
        ' Purpose               :   To Add / Insert a record in Activity Log table.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim str_sql As String
        Dim Status As Boolean
        Dim objcommand As New OleDbCommand
        Dim Log_ID As Long
        Dim Session_ID As Long
        Dim User_ID As Long

        Try
            Session_ID = gstructUserDetails.SessionID
            User_ID = Convert.ToInt64(gstructUserDetails.UserID)

            Log_ID = gclsDBFunctions.GetNextID("ActivityLog", "ActivityLogID", gOleDBConnection_LogBook)

            If IsNothing(strPassword) Then
                strPassword = ""
            End If
            str_sql = "Insert into ActivityLog " & _
                      "(ActivityLogID ,SessionID ,ActivityDateTime ,UserID ,ProcessName ,ModuleID ,PasswordTried)" & _
                      " values(?,?,?,?,?,?,?)"

            '--- Providing command object for Infomaster
            With objcommand
                .Connection = gOleDBConnection_LogBook
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("ActivityLogID", OleDbType.BigInt).Value = Log_ID
                .Parameters.Add("SessionID", OleDbType.BigInt).Value = Session_ID
                .Parameters.Add("ActivityDateTime", OleDbType.Date).Value = DateTime.Now
                .Parameters.Add("UserID", OleDbType.BigInt).Value = User_ID
                .Parameters.Add("ProcessName", OleDbType.LongVarChar).Value = Log_desc
                .Parameters.Add("ModuleID", OleDbType.BigInt).Value = Module_ID
                If IsDBNull(strPassword) Then
                Else
                    .Parameters.Add("PasswordTried", OleDbType.LongVarChar).Value = strPassword
                End If
                .ExecuteNonQuery()
            End With

            objcommand.Dispose()
            Return Log_ID

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function gfuncInsertFileLog(ByVal ActivityLog_ID As Long, ByVal org_file_name As String, ByVal bck_file_name As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncInsertFileLog
        ' Description           :   To Add / Insert a record in File Log table.
        ' Purpose               :   To Add / Insert a record in File Log table.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim str_sql As String
        Dim Status As Boolean
        Dim objcommand As New OleDbCommand
        Dim FileLog_ID As Long

        Try
            'Status = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook)
            'If Not (Status) Then
            '    Return False
            'End If

            FileLog_ID = gclsDBFunctions.GetNextID("FileLog", "FileLogID", gOleDBConnection_LogBook)

            str_sql = "Insert into FileLog " & _
                      "(FileLogID ,ActivityLogID ,FileName ,FilePath )" & _
                      " values(?,?,?,?)"

            '--- Providing command object for Infomaster
            With objcommand
                .Connection = gOleDBConnection_LogBook
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("FileLogID", OleDbType.BigInt).Value = FileLog_ID
                .Parameters.Add("ActivityLogID", OleDbType.BigInt).Value = ActivityLog_ID
                .Parameters.Add("FileName", OleDbType.LongVarWChar).Value = org_file_name
                .Parameters.Add("FilePath", OleDbType.LongVarWChar).Value = bck_file_name
                .ExecuteNonQuery()
            End With

            objcommand.Dispose()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

#End Region

#Region " Public Functions"

    Public Function gfuncValidateUser(ByVal user_id As String, ByVal password As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncValidateUser 
        ' Description           :   To Validate the User against the Password entered by him.
        ' Purpose               :   To Validate the User against the Password entered by him.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2004
        ' Revisions             :   Nilesh Shirode , 11 friday 2004
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim result As Boolean = False
        Dim str_sql, str_encryptpass As String
        Dim objReader As OleDb.OleDbDataReader
        Dim password_id As Long
        Dim intUserCount As Integer

        Try
            '--- To get encrypted password
            str_encryptpass = gfuncEncryptString(password)

            '--- Generating dynamic query for selection type
            str_sql = "Select PasswordID " & _
                      "from Passwords ,Users where Passwords.UserID = " & user_id & " and Passwords.PasswordName = '" & str_encryptpass & "' " & _
                      "and Passwords.UserID = Users.UserID and Users.Active = 1 "

            'result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            'gOleDBUserInfoConnection = gclsDBFunctions.OpenConnection(CONSTSTR_USERINFORMATION)
            'If Not (result) Then
            '    result = False
            '    Return result
            'End If
            'Call gfuncCreateUserInfoConnection()

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            If Not gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader) Then
                result = False
                Return result
            End If

            While objReader.Read
                password_id = Convert.ToInt64(objReader.Item("PasswordID"))
                result = True
            End While
            objReader.Close()
            Return result

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gfuncDecryptString(ByVal str_encrypt As String) As String
        '=====================================================================
        ' Procedure Name        : gfuncDecryptString
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To decrypt the string passed to this function.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim str_decrypt, arr_str() As String
        Dim arr_byte(), bt_single As Byte
        Dim rec_cnt, temp_cnt As Integer
        Dim objWait As New CWaitCursor
        Try
            arr_str = str_encrypt.Split(";")
            rec_cnt = arr_str.Length
            ReDim arr_byte(rec_cnt - 1)

            For temp_cnt = 0 To (rec_cnt - 1)
                bt_single = Convert.ToByte(arr_str(temp_cnt))
                arr_byte(temp_cnt) = bt_single
            Next

            Dim obj_crypt As New TripleDES
            str_decrypt = obj_crypt.gfuncDecrypt(arr_byte)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

        Return str_decrypt

    End Function

    Public Function gfuncEncryptString(ByVal str_source As String) As String
        '=====================================================================
        ' Procedure Name        : gfuncEncryptString
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To encrypt the string passed to this function.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim str_single, str_encrypt As String
        Dim arr_byte() As Byte
        Dim rec_cnt, temp_cnt As Integer
        Dim objWait As New CWaitCursor
        Try
            Dim obj_crypt As New TripleDES
            arr_byte = obj_crypt.gfuncEncrypt(str_source)

            rec_cnt = arr_byte.Length
            For temp_cnt = 0 To (rec_cnt - 1)
                str_single = Convert.ToString(arr_byte(temp_cnt))
                If temp_cnt = 0 Then
                    str_encrypt = str_single
                Else
                    str_encrypt = str_encrypt & ";" & str_single
                End If
            Next

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

        Return str_encrypt

    End Function

    Public Function gfuncCreateLogBookConnection() As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncCreateLogBookConnection
        ' Description           :   To Create Global Oledb connection to Service LogBook DB.
        ' Purpose               :   To Create Global Oledb connection to Service LogBook DB.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   March, 2003 
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim objWait As New CWaitCursor
        Try
            gfuncCreateLogBookConnection = False
            '--- Passing database name to clsstrConnString property
            gOleDBConnectionString_LogBook = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME)

            '--- Passing connection string to Connection Object
            gOleDBConnection_LogBook = New OleDb.OleDbConnection(gOleDBConnectionString_LogBook)

            result = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook)
            If Not (result) Then
                gobjMessageAdapter.ShowMessage(constErrorConnectionOpening)
            End If

            gfuncCreateLogBookConnection = True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gfuncCreateUserInfoConnection() As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncCreateLogBookConnection
        ' Description           :   To Create Global Oledb connection to Service LogBook DB.
        ' Purpose               :   To Create Global Oledb connection to Service LogBook DB.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Sachin Dokhale
        ' Created               :   March, 2003 
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim objWait As New CWaitCursor
        Try
            gfuncCreateUserInfoConnection = False
            '--- Passing database name to clsstrConnString property
            gOleDBConnectionString_UserInfo = gclsDBFunctions.ConnectionString(CONSTSTR_USERINFORMATION)

            '--- Passing connection string to Connection Object
            gOleDBUserInfoConnection = New OleDb.OleDbConnection(gOleDBConnectionString_UserInfo)

            result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (result) Then
                gobjMessageAdapter.ShowMessage(constErrorConnectionOpening)
            End If

            gfuncCreateUserInfoConnection = True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Module
