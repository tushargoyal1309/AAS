
Option Explicit On 
Imports System.io
Imports DataObject

<Serializable()> Public Class clsDataAccessLayer
    Implements IDisposable
    '--------------------------------------------------------------------------------------------
    'Class Name     :   clsDataAccessLayer
    'Purpose        :   To provide access between the Data Object Layer
    '                   and Business Logic Layer, thus separating these two layers. 
    '                   All the database operations requested by the business 
    '                   logic layer are received by Data Access Layer and 
    '                   Sql Queries are generated which are executed and 
    '                   implemented in DataObject class
    'Assumptions    :   
    'Dependencies   :   1.Depend on DataObject Class for connection to Database
    '                   2.Depend on globalDeclararation module for Names of Databases
    'Author         :   Mangesh Shardul
    'Date/Time      :   31-Aug-2004 9:30 am
    'Revision By    :
    'Revision For   :
    '--------------------------------------------------------------------------------------------

#Region " Private Class Variables "
    Private WithEvents mobjBusinessData As clsDataObject
    Private WithEvents mobjSystemData As clsDataObject
    Private mobjDatabaseConstants As New clsDatabaseConstants
#End Region

#Region " Constructors and Destructors "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal intDataSourceTypeIn As Integer, _
               ByVal strBusinessDatabaseNameIn As String, _
               ByVal strSystemDatabaseNameIn As String, _
               ByVal strDBProviderIn As String, _
               ByVal strUserNameIn As String, _
               ByVal strPasswordIn As String, _
               ByVal strSqlDataSourceIn As String, _
               ByVal strDBPathIn As String)
        '=====================================================================
        ' Procedure Name        : New [Constructor]
        ' Parameters Passed     : None
        ' Returns               : An object this class
        ' Purpose               : To constructs/instantiate object of this class
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 06-Nov-2004 3:30 pm
        ' Revisions             : 
        '=====================================================================
        Dim DataSourceType As clsDataObject.enumDataSourceType
        Try
            If intDataSourceTypeIn = "1" Then
                DataSourceType = clsDataObject.enumDataSourceType.Access
            End If
            If intDataSourceTypeIn = "2" Then
                DataSourceType = clsDataObject.enumDataSourceType.SqlServer
            End If

            mobjBusinessData = New clsDataObject(DataSourceType, strBusinessDatabaseNameIn, strDBPathIn, strDBProviderIn, strUserNameIn, strPasswordIn, strSqlDataSourceIn)
            ' mobjSystemData = New clsDataObject(DataSourceType, strSystemDatabaseNameIn, strDBPathIn, strDBProviderIn, strUserNameIn, strPasswordIn, strSqlDataSourceIn)
            mobjBusinessData.OpenConnection()

            mobjSystemData = New clsDataObject(DataSourceType, strSystemDatabaseNameIn, strDBPathIn, strDBProviderIn, strUserNameIn, strPasswordIn, strSqlDataSourceIn)
            Call funcBuildConnectionString_ReadOnly(mobjSystemData)
            mobjSystemData.OpenConnection()

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
            '---------------------------------------------------------
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        Try
            '--DESRTUCTOR
            MyBase.Finalize()

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
            '---------------------------------------------------------
        End Try

    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
        '**********************************************************************
        ' Procedure Name 	: Dispose
        ' Author			: Mangesh Shardul
        ' Date/Time			: 02-Nov-2004 01:10 pm
        ' Description		: To dispose the objects this class instance
        '**********************************************************************
        Try
            mobjBusinessData.Dispose()
            mobjSystemData.Dispose()
            mobjDatabaseConstants.Dispose()

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
            '---------------------------------------------------------
        End Try

    End Sub

#End Region

#Region " Message Handler Functions "

    Public Function GetMessage() As DataTable
        '=====================================================================
        ' Procedure Name        : GetMessage
        ' Parameters Passed     : None
        ' Returns               : DataTable containing message data
        ' Purpose               : To retrieve the Message from Table
        ' Description           : 
        ' Assumptions           : The table should not be empty.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 02-Sep-2004 2:45 pm
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objMessageData As New DataTable

        Try
            ConnStatus = mobjSystemData.CheckConnectionStatus()
            If ConnStatus = True Then
                strQuery = "SELECT * FROM [MessageInfo] ORDER BY [MessageID]"
                objMessageData = mobjSystemData.GetRecord(strQuery)
            Else
                '---Connection NOT OPEN
                objMessageData = Nothing
            End If

            If IsNothing(objMessageData) = False Then
                If objMessageData.Rows.Count > 0 Then
                    Return objMessageData
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            objMessageData.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetMessage(ByVal lngMessageId As Long) As DataRow
        '=====================================================================
        ' Procedure Name        : GetMessage
        ' Parameters Passed     : ID of the Message
        ' Returns               : DataRow containing message data
        ' Purpose               : To retrieve the Message from Table
        ' Description           : 
        ' Assumptions           : The table should not be empty.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 02-Sep-2004 3:45 pm
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtMessageData As New DataTable
        Dim objDrMessageDataRow As DataRow = Nothing

        Try
            ConnStatus = mobjSystemData.CheckConnectionStatus()
            '=====================================================================
            ' Description explaning the steps followed: 
            ' 1. using global object of clsDataObject get the message data
            '    from database as DataTable
            ' 2. Set the first column as Unique Key of table
            ' 3. Set the first column as Primary Key of table
            ' 4. then find the given Message Id in the returned DataTable
            ' 5. return the DataRow for that found Message ID
            '=====================================================================
            If ConnStatus = True Then
                strQuery = "select * from [MessageInfo] order by [MessageID]"
                objDtMessageData = mobjSystemData.GetRecord(strQuery)


                If Not IsNothing(objDtMessageData) Then
                    If objDtMessageData.Rows.Count > 0 Then
                        objDtMessageData.Columns("MessageID").Unique = True
                        ' Create the Primary Key columns.
                        Dim messagePrimaryKey(1) As DataColumn
                        messagePrimaryKey(0) = objDtMessageData.Columns("MessageID")
                        objDtMessageData.PrimaryKey = messagePrimaryKey
                        objDrMessageDataRow = objDtMessageData.Rows.Find(lngMessageId)
                    Else
                        objDrMessageDataRow = Nothing
                    End If
                    objDtMessageData.Dispose()
                Else
                    objDrMessageDataRow = Nothing
                End If
            Else
                '---Connection NOT OPEN
                objDrMessageDataRow = Nothing
            End If

            If IsNothing(objDrMessageDataRow) = False Then
                If objDrMessageDataRow.ItemArray.Length > 0 Then
                    Return objDrMessageDataRow
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            'objDtMessageData.Dispose()
            objDrMessageDataRow = Nothing
        End Try

    End Function
    Private Sub mobjBusinessData_ErrorHandler(ByVal aa As String) Handles mobjBusinessData.ErrorHandler
        'gobjErrorHandler.ErrorDescription = aa
        'gobjErrorHandler.ErrorMessage = aa
        'gobjErrorHandler.WriteErrorLog()
        ''---------------------------------------------------------
    End Sub
    Private Sub mobjSystemData_ErrorHandler(ByVal aa As String) Handles mobjSystemData.ErrorHandler
        'gobjErrorHandler.ErrorDescription = aa
        'gobjErrorHandler.ErrorMessage = aa
        'gobjErrorHandler.WriteErrorLog()
        ''---------------------------------------------------------
    End Sub
    Public Function GetMessage(ByVal intModuleId As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : GetMessage
        ' Parameters Passed     : Module ID of the Message
        ' Returns               : DataTable containing message data
        ' Purpose               : To retrieve the Message from Table
        ' Description           : 
        ' Assumptions           : The table should not be empty.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 12-Sep-2004 6:15 pm
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtMessageData As New DataTable
        Dim objDtMessageDataRow As DataRow

        Try
            ConnStatus = mobjSystemData.CheckConnectionStatus()
            '=====================================================================
            ' Description explaning the steps followed: 
            ' 1. using global object of clsDataObject get the message data
            '    from database as DataTable
            ' 2. return the DataTable for that found Module ID
            '=====================================================================
            If ConnStatus = True Then
                strQuery = "select * from MessageInfo where ModuleID=" & intModuleId & " order by MessageID"
                objDtMessageData = mobjSystemData.GetRecord(strQuery)
            Else
                '---Connection NOT OPEN
                objDtMessageData = Nothing
            End If

            If IsNothing(objDtMessageData) = False Then
                If objDtMessageData.Rows.Count > 0 Then
                    Return objDtMessageData
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            If Not objDtMessageData Is Nothing Then
                objDtMessageData.Dispose()
            End If
        End Try

    End Function

    Public Function SaveErrorInfo(ByVal lngErrNum As Long, ByVal strErrDesc As String) As Boolean
        '=====================================================================
        ' Procedure Name        : saveErrorInfo
        ' Parameters Passed     : None
        ' Returns               : True if data saved successfully; false otherwise
        ' Purpose               : To save Error No and Descriptions into the database
        ' Description           : 
        ' Assumptions           : The table should not be empty.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Sep-2004 3:30 pm
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strInsertQuery As String = ""
        Try
            strInsertQuery = " INSERT INTO [ErrorInfo] " & _
                             " ([ErrorNumber], [ErrorDesc]) " & _
                             " values (" & Val(lngErrNum) & ",'" & Trim(strErrDesc) & "');"

            ConnStatus = mobjSystemData.CheckConnectionStatus()
            If ConnStatus = True Then
                If mobjSystemData.BeginTransaction Then
                    If mobjSystemData.InsertRecords(strInsertQuery) Then
                        mobjSystemData.IsCommitTransaction = True
                        Return True
                    Else
                        mobjSystemData.IsCommitTransaction = False
                        Return False
                    End If
                Else
                    '---Transaction can not be started
                    Return False
                End If
            Else
                '---Connection NOT OPEN
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
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

    Public Function GetModules() As DataTable
        '=====================================================================
        ' Procedure Name        : GetModules
        ' Parameters Passed     : None
        ' Returns               : DataRow containing Modules data
        ' Purpose               : To retrieve the Modules Names from Table
        ' Description           : 
        ' Assumptions           : The table should not be empty.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Sep-2004 6:15 pm
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objModulesData As New DataTable

        Try
            ConnStatus = mobjSystemData.CheckConnectionStatus()
            If ConnStatus = True Then
                strQuery = "select * from ModulesMst"
                objModulesData = mobjSystemData.GetRecord(strQuery)
            Else
                '---Connection NOT OPEN
                objModulesData = Nothing
            End If

            If IsNothing(objModulesData) = False Then
                If objModulesData.Rows.Count > 0 Then
                    Return objModulesData
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

            objModulesData.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function SaveMessageInfo(ByVal lngMsgIDIn As Long, ByVal strMessageTitle As String, _
                             ByVal strMessageText As String, ByVal intModuleID As Integer, _
                             ByVal strMessageType As String, ByVal strVBFileName As String) As Boolean
        '=====================================================================
        ' Procedure Name        : SaveMessageInfo
        ' Parameters Passed     : None
        ' Returns               : True if data saved successfully; false otherwise
        ' Purpose               : To save Message Ifo into the database
        ' Description           : 
        ' Assumptions           : The table should not be empty.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 12-Sep-2004 3:30 pm
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strInsertQuery As String = ""
        Try
            '''strInsertQuery = " INSERT INTO [MessageInfo] " & _
            '''                 " ([MessageID], [ModuleID], [MessageType], [MessageTitle], [MessageText]) " & _
            '''                 " values (" & Val(lngMsgIDIn) & "," & Val(intModuleID) & "," & _
            '''                 "'" & Trim(strMessageType) & "','" & Trim(strMessageTitle) & "'," & _
            '''                 "'" & Trim(strMessageText) & "')"


            strInsertQuery = " INSERT INTO MessageInfo " & _
                 " (MessageID, ModuleID, MessageType, MessageTitle, MessageText, FileName) " & _
                 " values (" & Val(lngMsgIDIn) & "," & Val(intModuleID) & ",'" & Trim(strMessageType) & "'," & _
                 "'" & Trim(strMessageTitle) & "', '" & Trim(strMessageText) & "', '" & Trim(strVBFileName) & "')"


            ConnStatus = mobjSystemData.CheckConnectionStatus()
            If ConnStatus = True Then
                If mobjSystemData.BeginTransaction Then
                    If mobjSystemData.InsertRecords(strInsertQuery) Then
                        mobjSystemData.IsCommitTransaction = True
                        Return True
                    Else
                        mobjSystemData.IsCommitTransaction = False
                        Return False
                    End If
                Else
                    '---Transaction can not be started.
                    Return False
                End If
            Else
                '---Connection NOT OPEN
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
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

    Public Function UpdateMessageInfo(ByVal lngMsgIDIn As Long, ByVal strMessageTitle As String, _
                                 ByVal strMessageText As String, ByVal intModuleID As Integer, _
                                 ByVal strMessageType As String, ByVal strVBFileName As String) As Boolean
        '=====================================================================
        ' Procedure Name        : UpdateMessageInfo
        ' Parameters Passed     : None
        ' Returns               : True if data Updated successfully; false otherwise
        ' Purpose               : To Update Message Ifo into the database
        ' Description           : 
        ' Assumptions           : The table should not be empty.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 13-Jan-2005 12:30 pm
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean
        Dim strUpdateQuery As String
        Try
            strUpdateQuery = " UPDATE [MessageInfo] " & _
                             " SET " & _
                             " [ModuleID]= " & Val(intModuleID) & ", " & _
                             " [MessageType] = '" & Trim(strMessageType) & "', " & _
                             " [MessageTitle]= '" & Trim(strMessageTitle) & "', " & _
                             " [MessageText] = '" & Trim(strMessageText) & "', " & _
                             " [FileName] = '" & Trim(strVBFileName) & "'" & _
                             " WHERE " & _
                             " [MessageID]=" & Val(lngMsgIDIn) & ""

            ConnStatus = mobjSystemData.CheckConnectionStatus()
            If ConnStatus = True Then
                If mobjSystemData.BeginTransaction Then
                    If mobjSystemData.UpdateRecord(strUpdateQuery) Then
                        mobjSystemData.IsCommitTransaction = True
                        Return True
                    Else
                        mobjSystemData.IsCommitTransaction = False
                        Return False
                    End If
                Else
                    '---Transaction can not be started.
                    Return False
                End If
            Else
                '---Connection NOT OPEN
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
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

    'Public Function GetMessageHandlerObject(ByVal lngMessageId As Long, ByRef objMessageHandlerIn As MessageHandler.clsMessageHandler) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : GetMessage
    '    ' Parameters Passed     : Unique Id of the message.
    '    ' Returns               : The Global Object of MessageHandler with Message Info
    '    ' Purpose               : To retrieve the message from database.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : Global Object of MessageHandler
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 13-Sep-2004 05:00 pm
    '    ' Revisions             : 
    '    '=====================================================================
    '    Dim objMessageDataRow As DataRow
    '    Try
    '        '=====================================================================
    '        ' Description explaning the steps followed: 
    '        ' 1. using global object of clsDataAccessLayer get the message data
    '        '    from database
    '        ' 2. return the DataRow for that found Message ID
    '        ' 3. Pass this DataRow to MessageHandler class' GetMessage
    '        ' 4. Return the global object of MessageHandler with Message Info.
    '        '=====================================================================
    '        objMessageDataRow = Me.GetMessage(lngMessageId)

    '        Call objMessageHandlerIn.GetMessage(objMessageDataRow, objMessageHandlerIn)

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        'Return Nothing
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    Private Function funcBuildConnectionString_ReadOnly(ByRef InobjDataObject As clsDataObject) As Boolean
        '=====================================================================
        ' Procedure Name        : BuildConnectionString
        ' Parameters Passed     : None
        ' Returns               : True if successful, false otherwise
        ' Purpose               : to build connection string from properties of class
        ' Description           : 
        ' Assumptions           : All properties are set.
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 30-Aug-2004 6:30 pm
        ' Revisions             : 
        '=====================================================================
        Dim strDataSourceType As clsDataObject.enumDataSourceType
        Dim strConnectionString As String
        Dim strProvider As String
        Dim strDataSourceName As String
        Dim strInitialCatalog As String
        Dim strUserName As String
        Dim strPassword As String
        Dim blnPersistSecurity, blnEncryptDatabase As Boolean
        Dim intConnectionTimeout As Integer
        Dim strMode As String

        ''Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & clsApp.StartupPath.ToString & "\" & strDatabasename & ";Persist Security Info=False;Jet OLEDB:Database Password=Aldys"
        ''Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Initial Catalog=master;Data Source=RNDSERVER\ALDYS

        Try
            strDataSourceType = InobjDataObject.DataSourceType
            strProvider = InobjDataObject.Provider
            strDataSourceName = InobjDataObject.DataSourceName
            strInitialCatalog = InobjDataObject.InitialCatalog
            blnPersistSecurity = InobjDataObject.PersistSecurityInfo
            strUserName = InobjDataObject.UserName
            strPassword = InobjDataObject.Password
            intConnectionTimeout = InobjDataObject.ConnectionTimeout
            blnEncryptDatabase = InobjDataObject.EncryptDatabase
            'strMode = ";Mode=Share Deny Read|Share Deny Write;"
            strMode = ";Mode=ReadWrite|Share Deny None;"
            Select Case strDataSourceType
                Case clsDataObject.enumDataSourceType.Access
                    '--Connection string for Access Database
                    strConnectionString = "Provider=" & strProvider & ";Data Source=" & strDataSourceName & strMode & "Persist Security Info=" & blnPersistSecurity & ";Jet OLEDB:Database Password=" & strPassword & ";"

                Case clsDataObject.enumDataSourceType.SqlServer
                    '--Connection string for SQL Server Database
                    strConnectionString = "Persist Security Info=" & blnPersistSecurity & ";User ID=" & strUserName & ";Password=" & strPassword & ";Integrated Security=False;database=" & strInitialCatalog & ";server=" & strDataSourceName & ";Connect Timeout=" & intConnectionTimeout

            End Select

            InobjDataObject.ConnectionString = strConnectionString
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            '------ Raises event to Error Status of function----
            'RaiseEvent ErrorHandler(clsDatabaseConstants.ConstErrorDBConnString)
            Return True
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function
#End Region

#Region " Event Handlers "

    Private Sub BusinessDataErrorHandler(ByVal strMessageText As String) Handles mobjBusinessData.ErrorHandler
        '=====================================================================
        ' Procedure Name        : BusinessDataErrorHandler
        ' Parameters Passed     : Message Text
        ' Returns               : None
        ' Purpose               : To handle the errors occured during 
        '                         the execution of sql query
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 05-Nov-2004 06:30 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            Select Case strMessageText
                Case mobjDatabaseConstants.ConstErrorDBOpen
                    gobjMessageAdapter.ShowMessage(constNotConnectedToDatabase)
                    Application.DoEvents()
                Case mobjDatabaseConstants.ConstErrorDBGetData

            End Select

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
            '---------------------------------------------------------
        End Try

    End Sub

#End Region




#Region "Public Functions"

    Public Function GetCookBookData() As DataTable
        '=====================================================================
        ' Procedure Name        : GetCookBookData
        ' Parameters Passed     : Nothing
        ' Returns               : Records
        ' Purpose               : for getting cookbock data from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtCookBook As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                ''check a flag for connection status
                strQuery = "SELECT * FROM [CookBook_Master] Where Not (CookBook_Master.ELE_ID = 200)"
                objDtCookBook = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtCookBook = Nothing
            End If

            If IsNothing(objDtCookBook) = False Then
                If objDtCookBook.Rows.Count > 0 Then
                    Return objDtCookBook
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtCookBook.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetCookBookData(ByVal intElementID As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : GetCookBookData
        ' Parameters Passed     : intElementID
        ' Returns               : Records
        ' Purpose               : for getting cookbokk data from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtCookBook As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                ''check a flag for connection status
                strQuery = "SELECT * FROM [CookBook_Master] where Ele_ID=" & intElementID
                objDtCookBook = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtCookBook = Nothing
            End If

            If IsNothing(objDtCookBook) = False Then
                If objDtCookBook.Rows.Count > 0 Then
                    Return objDtCookBook
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtCookBook.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetCookBookData_AtomicNo(ByVal intElementID As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : GetCookBookData
        ' Parameters Passed     : intElementID
        ' Returns               : Records
        ' Purpose               : for getting cookbook data from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtCookBook As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                ''check a flag for connection status
                strQuery = "SELECT * FROM [CookBook_AtomicNo] where Ele_ID=" & intElementID
                objDtCookBook = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtCookBook = Nothing
            End If

            If IsNothing(objDtCookBook) = False Then
                If objDtCookBook.Rows.Count > 0 Then
                    Return objDtCookBook
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtCookBook.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetCookBookElementID(ByVal intAtomicNumber As Integer) As Integer
        '=====================================================================
        ' Procedure Name        : GetCookBookElementID
        ' Parameters Passed     : intAtomicNumber
        ' Returns               : Records
        ' Purpose               : for getting cookbook element id from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim intElementID As New Integer
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                ''check a flag for connection status
                'strQuery = "SELECT ELE_ID FROM [CookBook_Master] where ATNO=" & intAtomicNumber
                intElementID = mobjBusinessData.GetRecord("CookBook_Master", "ELE_ID", "ATNO=" & intAtomicNumber.ToString)
            Else
                intElementID = 0
            End If

            Return intElementID

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return 0
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function EmissionData(ByVal intAppMode As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : EmissionData
        ' Parameters Passed     : Nothing
        ' Returns               : Records
        ' Purpose               : To show the element symbol of those elements 
        '                         whose FUELEMS value is 0.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtCookBook As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If intAppMode = EnumAppMode.FullVersion_203D Then
                If ConnStatus = True Then
                    ''check a flag for connection status
                    strQuery = "SELECT [ATNO],[ELE_ID],[NAME],[ELE_NAME],[WVEMS],[SLITEMS] FROM [CookBook_Master_DB] where [FUELEMS] = 0"
                    objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                Else
                    objDtCookBook = Nothing
                End If
            Else
                If ConnStatus = True Then
                    strQuery = "SELECT [ATNO],[ELE_ID],[NAME],[ELE_NAME],[WVEMS],[SLITEMS] FROM [CookBook_Master] where [FUELEMS] = 0"
                    objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                Else
                    objDtCookBook = Nothing
                End If
            End If

            If IsNothing(objDtCookBook) = False Then
                If objDtCookBook.Rows.Count > 0 Then
                    Return objDtCookBook
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtCookBook.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetElementWavelengths(ByVal intElementID As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : GetElementWavelengths
        ' Parameters Passed     : intElementID
        ' Returns               : Records
        ' Purpose               : for getting a element wavelength from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtWavelengths As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                ''check a flag for connection status
                strQuery = "SELECT * FROM [CookBook_AADetails] where Ele_ID=" & intElementID
                objDtWavelengths = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtWavelengths = Nothing
            End If

            If IsNothing(objDtWavelengths) = False Then
                If objDtWavelengths.Rows.Count > 0 Then
                    Return objDtWavelengths
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtWavelengths.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetMethodTypes(ByVal intMethodType As Integer, Optional ByVal IsAA301 As Boolean = False) As DataTable
        '=====================================================================
        ' Procedure Name        : GetMethodTypes
        ' Parameters Passed     : intMethodType
        ' Returns               : Records
        ' Purpose               : for getting a element method type from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtMethod As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then

                If IsAA301 = False Then   '---'---21.07.09
                    If intMethodType = 0 Then
                        ''check a flag for connection status
                        strQuery = "SELECT * FROM [StMethodTypes]"
                    Else
                        strQuery = "SELECT * FROM [StMethodTypes] where MethodTypeID=" & intMethodType
                    End If
                Else
                    strQuery = "SELECT * FROM [StMethodTypes] where MethodTypeID <> 4"
                End If

                objDtMethod = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtMethod = Nothing
            End If

            If IsNothing(objDtMethod) = False Then
                If objDtMethod.Rows.Count > 0 Then
                    Return objDtMethod
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtMethod.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetUnits(Optional ByVal intUnitID As Integer = 0) As DataTable
        '=====================================================================
        ' Procedure Name        : GetUnits
        ' Parameters Passed     : intMethodType
        ' Returns               : Records
        ' Purpose               : for getting a element units from the database.
        ' Description       
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtUnits As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                If intUnitID = 0 Then
                    strQuery = "SELECT * FROM [StUnits]"
                Else
                    strQuery = "SELECT * FROM [StUnits] where UnitID=" & intUnitID
                End If

                objDtUnits = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtUnits = Nothing
            End If

            If IsNothing(objDtUnits) = False Then
                If objDtUnits.Rows.Count > 0 Then
                    Return objDtUnits
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtUnits.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function GetMeasurementModes(Optional ByVal intMeasurementModeID As Integer = 0) As DataTable
        '=====================================================================
        ' Procedure Name        : GetMeasurementModes
        ' Parameters Passed     : intMeasurementModeID
        ' Returns               : Records
        ' Purpose               : for getting a measurementMode from the database.
        ' Description       
        ' Assumptions           : 
        ' Dependencies          : database connection   
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtMeasurementModes As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                ''check a flag for connection status
                If intMeasurementModeID = 0 Then
                    strQuery = "SELECT * FROM [StMeasurementMode]"
                Else
                    strQuery = "SELECT * FROM [StMeasurementMode] where MeasurementModeID=" & intMeasurementModeID
                End If

                objDtMeasurementModes = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtMeasurementModes = Nothing
            End If

            If IsNothing(objDtMeasurementModes) = False Then
                If objDtMeasurementModes.Rows.Count > 0 Then
                    Return objDtMeasurementModes
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtMeasurementModes.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function GetCookBookDetailRow(ByVal intDetailID As Integer) As DataRow
        '=====================================================================
        ' Procedure Name        : GetCookBookDetailRow
        ' Parameters Passed     : intDetailID
        ' Returns               : Records
        ' Purpose               : for getting a cookbook details from the database.
        ' Description       
        ' Assumptions           : 
        ' Dependencies          : database
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDr As DataRow
        Dim objDtWavelengths As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            If ConnStatus = True Then
                ''check a flag for connection status
                strQuery = "SELECT * FROM [CookBook_AADetails] where AADetails_ID=" & intDetailID
                objDtWavelengths = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtWavelengths = Nothing
            End If

            If IsNothing(objDtWavelengths) = False Then
                If objDtWavelengths.Rows.Count > 0 Then
                    Return objDtWavelengths.Rows(0)
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objDtWavelengths Is Nothing Then
                objDtWavelengths.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetWavelengthRange(ByVal intAppMode As Integer) As DataTable
        '=====================================================================
        ' Procedure Name        : GetWavelengthRange
        ' Parameters Passed     : intAppMode
        ' Returns               : Records
        ' Purpose               : for getting a wavelength range  from the database.
        ''                        as par application mode.
        ' Description       
        ' Assumptions           : 
        ' Dependencies          : database connection
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtCookBook As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()

            Select Case intAppMode
                Case EnumAppMode.FullVersion_203D
                    If ConnStatus = True Then
                        ''check a flag for connection status
                        strQuery = "SELECT * FROM [stWavelengthRange_DB]"
                        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                    Else
                        objDtCookBook = Nothing
                    End If
                Case EnumAppMode.DemoMode_203D
                    If ConnStatus = True Then
                        ''check a flag for connection status
                        strQuery = "SELECT * FROM [stWavelengthRange_DB]"
                        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                    Else
                        objDtCookBook = Nothing
                    End If
                Case EnumAppMode.FullVersion_203
                    If ConnStatus = True Then
                        ''check a flag for connection status
                        strQuery = "SELECT * FROM [stWavelengthRange]"
                        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                    Else
                        objDtCookBook = Nothing
                    End If
                Case EnumAppMode.DemoMode
                    If ConnStatus = True Then
                        ''check a flag for connection status
                        strQuery = "SELECT * FROM [stWavelengthRange]"
                        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                    Else
                        objDtCookBook = Nothing
                    End If
                Case EnumAppMode.DemoMode_201
                    If ConnStatus = True Then
                        ''check a flag for connection status
                        strQuery = "SELECT * FROM [stWavelengthRange]"
                        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                    Else
                        objDtCookBook = Nothing
                    End If
                Case EnumAppMode.FullVersion_201
                    If ConnStatus = True Then
                        ''check a flag for connection status
                        strQuery = "SELECT * FROM [stWavelengthRange]"
                        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
                    Else
                        objDtCookBook = Nothing
                    End If
            End Select

            'If intAppMode = EnumAppMode.FullVersion_203D Or intAppMode = EnumAppMode.DemoMode_203D Then
            '    If ConnStatus = True Then
            '        ''check a flag for connection status
            '        strQuery = "SELECT * FROM [stWavelengthRange_DB]"
            '        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
            '    Else
            '        objDtCookBook = Nothing
            '    End If
            'Else
            '    If ConnStatus = True Then
            '        ''check a flag for connection status
            '        strQuery = "SELECT * FROM [stWavelengthRange]"
            '        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
            '    Else
            '        objDtCookBook = Nothing
            '    End If
            'End If

            If IsNothing(objDtCookBook) = False Then
                If objDtCookBook.Rows.Count > 0 Then
                    Return objDtCookBook
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtCookBook.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function GetStdSampInfo() As DataTable
        '=====================================================================
        ' Procedure Name        : GetStdSampInfo
        ' Parameters Passed     : 
        ' Returns               : Records
        ' Purpose               : getting std /sam info.
        ' Description       
        ' Assumptions           : 
        ' Dependencies          : database connection.
        ' Author                : Saurabh S.
        ' Created               : 22-12-2006
        ' Revisions             : 
        '=====================================================================
        Dim ConnStatus As Boolean = False
        Dim strQuery As String = ""
        Dim objDtStdSampInfo As New DataTable
        Try
            ConnStatus = mobjBusinessData.CheckConnectionStatus()
            ''check a flag for connection status
            If ConnStatus = True Then

                strQuery = "SELECT * FROM [StdSampInfo]"

                objDtStdSampInfo = mobjBusinessData.GetRecord(strQuery)
            Else
                objDtStdSampInfo = Nothing
            End If

            If IsNothing(objDtStdSampInfo) = False Then
                If objDtStdSampInfo.Rows.Count > 0 Then
                    Return objDtStdSampInfo
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objDtStdSampInfo.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Class
