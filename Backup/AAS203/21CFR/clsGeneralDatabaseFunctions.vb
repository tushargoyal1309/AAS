Imports AAS203.Common
Imports System.Data
Imports System.Data.OleDb
Imports System

Public Class clsDatabaseFunctions

#Region "Declarations "
    Private mstrConnectionString As String
    Private clsApp As Application
#End Region

#Region "GetConnection string properties"

    '--- Property to Set / Retreive Connection String
    Property ConnectionString(ByVal strDatabasename As String) As String
        Get
            Try
                If strDatabasename = "" Then
                    'Throw New InvalidExpressionException("DatabaseName is  Null")
                    gobjMessageAdapter.ShowMessage(constDatabaseNameNull)
                    Application.DoEvents()
                Else
                    mstrConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & clsApp.StartupPath.ToString & "\" & strDatabasename & ";Persist Security Info=False;Jet OLEDB:Database Password=Aldys"
                    Return mstrConnectionString
                End If
            Catch e As System.Exception
                gobjMessageAdapter.ShowMessage(e.Message.ToString, "Error...", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Application.DoEvents()
            End Try
        End Get

        Set(ByVal Value As String)
            mstrConnectionString = Value
        End Set
    End Property

#End Region

#Region "OpenConnection Methods"

    '--- Function of Open DataBase Connection having input parameter as Connection String
    Public Function OpenConnection(ByRef strConnectionstring As String) As OleDbConnection
        '=====================================================================
        ' Procedure Name        : OpenConnection
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open the database connection.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            Dim myConnection As New OleDbConnection(strConnectionstring)

            If strConnectionstring = "" Then
                'Throw New InvalidExpressionException("Connection string not initialised")
                gobjMessageAdapter.ShowMessage(constConnectionStrNotInit)
                Application.DoEvents()
            Else
                If myConnection.State = ConnectionState.Closed Then
                    myConnection.Open()
                    If myConnection.State = ConnectionState.Open Then
                        'Return True
                        Return myConnection
                    Else
                        'Throw New System.Exception("Error in Opening Connection")
                        gobjMessageAdapter.ShowMessage(constErrorConnectionOpening)
                    End If
                Else
                    'Return True
                    Return myConnection
                End If
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

    '--- Function to Open Database Connection having input as Connection Object
    Public Function OpenConnection(ByRef conobj As OleDbConnection) As Boolean
        '=====================================================================
        ' Procedure Name        : OpenConnection
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open the database connection.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If conobj.ConnectionString = "" Then
                'Throw New InvalidExpressionException("Connection string not initialised")
                gobjMessageAdapter.ShowMessage(constConnectionStrNotInit)
            Else
                If conobj.State = ConnectionState.Closed Then
                    conobj.Open()
                    If conobj.State = ConnectionState.Open Then
                        Return True
                    Else
                        gobjMessageAdapter.ShowMessage(constErrorConnectionOpening)
                    End If
                Else
                    Return True
                End If
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

    '--- Function to Open Database Connection , having input as Connection object and Connection String
    Public Function OpenConnection(ByRef conobj As OleDbConnection, ByVal constr As String) As Boolean
        '=====================================================================
        ' Procedure Name        : OpenConnection
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To open the database connection.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If Len(Trim$(constr)) = 0 Then
                'Throw New InvalidExpressionException("Connection string priovided is Null")
                gobjMessageAdapter.ShowMessage(constNullConnectionStr)
            Else
                conobj.ConnectionString = constr
            End If

            If conobj.State = ConnectionState.Closed Then
                conobj.Open()
                If conobj.State = ConnectionState.Open Then
                    Return True
                Else
                    'Throw New System.Exception("Error in Opening Connection")
                    gobjMessageAdapter.ShowMessage(constErrorConnectionOpening)
                End If
            Else
                Return True
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

#Region "Getting Record Methods"
    Public Function GetRecords(ByVal Query As String, ByRef myconnection As OleDbConnection) As OleDbDataReader
        '=====================================================================
        ' Procedure Name        : GetRecords
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To get the records from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim statuscon As Boolean
        Try
            If Len(Trim$(Query)) = 0 Then
                'Throw New InvalidCastException("Null String provided for Query")
                gobjMessageAdapter.ShowMessage(constNullStrForQuery)
            End If

            statuscon = OpenConnection(myconnection)
            If statuscon = True Then
                Dim myInsertQuery As String = Query
                Dim myCommand As New OleDbCommand(myInsertQuery, myconnection)
                Dim myReader As OleDbDataReader = myCommand.ExecuteReader()

                Return (myReader)

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

    '--- Function to Create a OLEDB Data Reader for the sql string and connection object passed and return bool value.
    Public Function GetRecords(ByVal Query As String, ByRef myconnection As OleDbConnection, ByRef myReader As OleDbDataReader) As Boolean
        '=====================================================================
        ' Procedure Name        : GetRecords
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To get the records from the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim connection_status As Boolean
        Try
            If Len(Trim$(Query)) = 0 Then
                'Throw New InvalidCastException("Null String provided for Query")
                gobjMessageAdapter.ShowMessage(constErrorConnectionOpening)
            End If

            connection_status = OpenConnection(myconnection)
            If connection_status = True Then
                Dim myQuery As String = Query
                Dim myCommand As New OleDbCommand(myQuery, myconnection)
                myReader = myCommand.ExecuteReader()
                Return True
            Else
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

#Region "Adding single Record "

    Public Function AddORDeleteRecord(ByVal Query As String, ByRef myconnection As OleDbConnection) As Boolean
        '=====================================================================
        ' Procedure Name        : AddORDeleteRecord
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To add or delete a record from database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim statuscon As Boolean
        Try
            statuscon = OpenConnection(myconnection)
            If statuscon = True Then
                Dim myInsertQuery As String = Query
                Dim myCommand As New OleDbCommand(myInsertQuery, myconnection)
                '
                If myCommand.ExecuteNonQuery() > 0 Then
                    Return True
                Else
                    'Throw New System.Exception("No Rows effected from specified Query")
                    gobjMessageAdapter.ShowMessage(constNoRowsEffected)
                End If
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

#Region "Updating single Field "
    Public Function UpdateField(ByVal fieldName As String, ByVal TableName As String, ByRef Value As Object, ByRef myconnection As OleDbConnection) As Boolean
        '=====================================================================
        ' Procedure Name        : UpdateField
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Update single field in database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim statuscon As Boolean
        Try
            If Len(Trim$(fieldName)) = 0 Then
                gobjMessageAdapter.ShowMessage(constNullStrForFieldName)
            End If
            If Len(Trim$(TableName)) = 0 Then
                gobjMessageAdapter.ShowMessage(constNullStrForTableName)
            End If
            statuscon = OpenConnection(myconnection)
            If statuscon = True Then
                Dim myInsertQuery As String = "update " & TableName & " Set " & fieldName & "=" & Value & ";"
                Dim myCommand As New OleDbCommand(myInsertQuery, myconnection)
                If myCommand.ExecuteNonQuery() > 0 Then
                    Return True
                Else
                    'Throw New System.Exception("No Rows affected from specified Query")
                    gobjMessageAdapter.ShowMessage(constNoRowsEffected)
                End If
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

#Region "Updating Single record"
    Public Function UpdateSingleRecord(ByVal Query As String, ByRef myconnection As OleDbConnection) As Boolean
        '=====================================================================
        ' Procedure Name        : frmAddUser_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Add User form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim statuscon As Boolean
        Try
            If Len(Trim$(Query)) = 0 Then
                'Throw New InvalidCastException("Null String provided for Query")
                gobjMessageAdapter.ShowMessage(constNullStrForQuery)

            End If
            statuscon = OpenConnection(myconnection)
            If statuscon = True Then
                Dim myInsertQuery As String = Query
                Dim myCommand As New OleDbCommand(myInsertQuery, myconnection)
                ' Dim myReader As OleDbDataReader = myCommand.ExecuteNonQuery 
                If myCommand.ExecuteNonQuery() > 0 Then
                    myCommand.Dispose()
                    Return True
                    'Else
                    '    Throw New System.Exception("No Rows affected from specified Query")
                End If
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

#Region "Getting NextID"
    Public Function GetNextID(ByVal TableName As String, ByVal Indexfield As String, ByRef myconnection As OleDbConnection) As Long
        '=====================================================================
        ' Procedure Name        : GetNextID
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To generate next ID in the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim statuscon As Boolean
        Dim NextID As Long
        Try
            If Len(Trim$(TableName)) = 0 Then
                'Throw New InvalidCastException("Null String provided for Table Name")
                gobjMessageAdapter.ShowMessage(constNullStrForTableName)
            End If
            If Len(Trim$(Indexfield)) = 0 Then
                'Throw New InvalidCastException("Null String provided for Index field")
                gobjMessageAdapter.ShowMessage(constNullStrForIndexField)
            End If

            statuscon = OpenConnection(myconnection)
            If statuscon = True Then
                Dim myInsertQuery As String = "select " & Indexfield & " from " & TableName & " ORDER BY " & Indexfield & ""
                Dim myCommand As New OleDbCommand(myInsertQuery, myconnection)
                Dim myReader As OleDbDataReader = myCommand.ExecuteReader()
                NextID = 0
                While myReader.Read()
                    NextID = myReader.Item(Indexfield)

                End While
                myReader.Close()
                myCommand.Dispose()
                Return (NextID + 1)
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

#Region "Getting Number of records"
    Public Function GetNoOfRec(ByRef myReader As OleDbDataReader) As Long
        '=====================================================================
        ' Procedure Name        : GetNoOfRec
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To get number of record counts from database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim NumberOfRecord As Long
        Try
            NumberOfRecord = 0
            While myReader.Read()
                NumberOfRecord = NumberOfRecord + 1
            End While

            Return (NumberOfRecord)
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

    '--- Returns True if Record Exists or any error occurs.
    Public Function RecordExists(ByVal sql_string As String, ByVal objConnection As OleDbConnection) As Boolean
        '=====================================================================
        ' Procedure Name        : RecordExists
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To verify whether record is present or not.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objReader As OleDbDataReader
        Dim result As Boolean
        Dim objWait As New CWaitCursor
        Try
            objReader = GetRecords(sql_string, objConnection)
            While objReader.Read
                result = True
                Return result
            End While
            result = False


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            result = True
            Return result
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objReader.Close()
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

        Return result
    End Function

#End Region

End Class
