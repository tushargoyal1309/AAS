Option Explicit On 

Imports System.Data
Imports System.Data.OleDb

Module modDatabaseOperations

#Region " Functions for inserting LogBooks data "

    ''Public Function funcInsertDataServiceLogs(ByVal LoggingDate As Date, ByVal Description As String, ByVal ServiceTime As Date, ByVal ServiceDay As Integer, ByVal SelectionType As ENUM_SELECTIONTYPE) As Boolean
    'Public Function funcInsertDataServiceLogs(ByVal Description As String, _
    '                            ByVal SelectionType As enum_LoggingDataFields, _
    '                            ByVal IDSession As Integer, _
    '                            ByVal Logvalue As String) As Boolean
    '    Dim strsqlServiceComments As String
    '    Dim objcmdMaster As New OleDb.OleDbCommand
    '    Dim IDServiceLog As Long
    '    Dim ServiceDay As Integer
    '    Dim LoggingDate As DateTime
    '    Dim ServiceTime As TimeSpan

    '    Try
    '        'Extracting ID for ServiceLogs
    '        IDServiceLog = gclsobj.GetNextID("ServiceLogs", "ServiceLogID", gOleDBConnection_LogBook)

    '        LoggingDate = DateTime.Now.Date
    '        ServiceTime = DateTime.Now.TimeOfDay
    '        ServiceDay = DateTime.Now.Day

    '        'query for adding data to ServiceLogs
    '        strsqlServiceComments = "Insert into ServiceLogs" & _
    '                                "(ServiceLogID ,SessionID ,LoggingDate ,SelectionTypeID ,LogValue ,Description ,ServiceTime ,ServiceDay)" & _
    '                                " values(?,?,?,?,?,?,?,?)"

    '        With objcmdMaster
    '            .Connection = gOleDBConnection_LogBook
    '            .CommandType = CommandType.Text
    '            .CommandText = strsqlServiceComments
    '            .Parameters.Add("ServiceLogID", OleDbType.BigInt).Value = IDServiceLog
    '            .Parameters.Add("SessionID", OleDbType.BigInt).Value = IDSession
    '            .Parameters.Add("LoggingDate", OleDbType.Date).Value = LoggingDate
    '            .Parameters.Add("SelectionTypeID", OleDbType.BigInt).Value = SelectionType
    '            .Parameters.Add("LogValue", OleDbType.VarChar).Value = Trim(Logvalue)
    '            .Parameters.Add("Description", OleDbType.LongVarWChar).Value = Trim(Description)
    '            .Parameters.Add("ServiceTime", OleDbType.Date).Value = ServiceTime
    '            .Parameters.Add("ServiceDay", OleDbType.Integer).Value = ServiceDay
    '            .ExecuteNonQuery()
    '        End With

    '        '--- To dispose command
    '        objcmdMaster.Dispose()
    '        Return True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    Public Function funcInsertLogData(ByVal IDSession As Integer) As Boolean
        Dim strsqlServiceComments As String
        Dim objcmdMaster As New OleDb.OleDbCommand
        Dim ServiceDay As Integer
        Dim LoggingDate As DateTime
        Dim ServiceTime As TimeSpan
        Dim Status As Boolean
        Try
            LoggingDate = DateTime.Now.Date
            ServiceTime = DateTime.Now.TimeOfDay
            ServiceDay = DateTime.Now.DayOfWeek

            'query for adding data to ServiceLogs
            strsqlServiceComments = "Insert into LogData" & _
                                    "(SessionID ,LoggingDate ,LoggingTime ,LoggingDay)" & _
                                    " values(?,?,?,?)"

            With objcmdMaster
                .Connection = gOleDBConnection_LogBook
                .CommandType = CommandType.Text
                .CommandText = strsqlServiceComments
                .Parameters.Add("SessionID", OleDbType.BigInt).Value = IDSession
                .Parameters.Add("LoggingDate", OleDbType.Date).Value = LoggingDate
                .Parameters.Add("LoggingTime", OleDbType.DBTime).Value = ServiceTime
                .Parameters.Add("LoggingDay", OleDbType.Integer).Value = ServiceDay
                .ExecuteNonQuery()
            End With

            '--- To dispose command
            objcmdMaster.Dispose()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
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
    Public Function funcInsertServiceData(ByVal IDSession As Integer) As Boolean
        Dim strsqlServiceComments As String
        Dim objcmdMaster As New OleDb.OleDbCommand
        Dim Status As Boolean
        Try
     
            'query for adding data to ServiceLogs
            strsqlServiceComments = "Insert into ServiceComments" & _
                                    "(ServiceCommentID)" & _
                                    " values(?)"

            With objcmdMaster
                .Connection = gOleDBConnection_LogBook
                .CommandType = CommandType.Text
                .CommandText = strsqlServiceComments
                .Parameters.Add("ServiceCommentID", OleDbType.BigInt).Value = IDSession
                .ExecuteNonQuery()
            End With

            '--- To dispose command
            objcmdMaster.Dispose()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
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

    Public Function funcUpdateLogData(ByVal lngSessionID As Long, _
                                ByVal intField As enum_LoggingDataFields, _
                                ByVal strFieldValue As String) As Boolean
        Dim strsqlServiceComments As String
        Dim objcmdMaster As New OleDb.OleDbCommand
        Dim strFieldname As String
        Dim Status As Boolean
        Try

            strFieldname = gfuncGetFieldName(intField)
            'query for adding data to ServiceLogs

            If strFieldname = "D2ONTIME" Or strFieldname = "WONTIME" Or strFieldname = "INSTRUMENTONTIME" Then
                strsqlServiceComments = "Update LogData set " & _
                                        strFieldname & " = " & strFieldname & " + " & strFieldValue & _
                                        " where SessionID = " & lngSessionID & " "
            Else
                strsqlServiceComments = "Update LogData set " & _
                                       strFieldname & " = " & strFieldValue & _
                                       " where SessionID = " & lngSessionID & " "
            End If

            With objcmdMaster
                .Connection = gOleDBConnection_LogBook
                .CommandType = CommandType.Text
                .CommandText = strsqlServiceComments
                Select Case intField
                    'For Fields Having Double Data Type
                Case modGlobalFunctions.enum_LoggingDataFields.EnergySpectrum, modGlobalFunctions.enum_LoggingDataFields.UVSpectrum
                        .Parameters.Add(strFieldname, OleDbType.BigInt).Value = CDbl(strFieldValue)
                        '    'For Fields having String Data Type
                        'Case modGlobalFunctions.enum_LoggingDataFields.UVSpectrum
                        '    .Parameters.Add(strFieldname, OleDbType.LongVarWChar).Value = CStr(strFieldValue)
                        '    'For Fields Having Double Data Type
                        'Case modConstants.enum_LoggingDataFields.D2Energy, modConstants.enum_LoggingDataFields.WEnergy, modConstants.enum_LoggingDataFields.SystemSpan, modConstants.enum_LoggingDataFields.SpanValue, modConstants.enum_LoggingDataFields.D2OnTime, modConstants.enum_LoggingDataFields.WOnTime, modConstants.enum_LoggingDataFields.InstrumentOnTime, modConstants.enum_LoggingDataFields.ZeroValue, modConstants.enum_LoggingDataFields.DacValue
                        '    .Parameters.Add(strFieldname, OleDbType.BigInt).Value = CDbl(strFieldValue)
                End Select
                .ExecuteNonQuery()
            End With

            '--- To dispose command
            objcmdMaster.Dispose()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
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

    End Function

    'By saraubh
    Public Function gfuncGetFieldName(ByVal intLogField As enum_LoggingDataFields) As String
        Select Case intLogField
            'Case modConstants.enum_LoggingDataFields.WvHome
            '    gfuncGetFieldName = "WVSTATUS"
            'Case modConstants.enum_LoggingDataFields.FilterOutOfPath
            '    gfuncGetFieldName = "FILTEROUT"
            'Case modConstants.enum_LoggingDataFields.FilterHome
            '    gfuncGetFieldName = "FILTERHOME"
            'Case modConstants.enum_LoggingDataFields.D2Optimised
            '    gfuncGetFieldName = "D2OPT"
            'Case modConstants.enum_LoggingDataFields.D2Energy
            '    gfuncGetFieldName = "D2ENERGY"
            'Case modConstants.enum_LoggingDataFields.WOptimised
            '    gfuncGetFieldName = "WOPT"
            'Case modConstants.enum_LoggingDataFields.WEnergy
            '    gfuncGetFieldName = "WENERGY"
            'Case modConstants.enum_LoggingDataFields.Span
            '    gfuncGetFieldName = "SPAN"
            'Case modConstants.enum_LoggingDataFields.SystemSpan
            '    gfuncGetFieldName = "SYSTEMSPAN"
            'Case modConstants.enum_LoggingDataFields.SpanValue
            '    gfuncGetFieldName = "SPANVAL"
            'Case modConstants.enum_LoggingDataFields.D2OnTime
            '    gfuncGetFieldName = "D2ONTIME"
            'Case modConstants.enum_LoggingDataFields.WOnTime
            '    gfuncGetFieldName = "WONTIME"
            'Case modConstants.enum_LoggingDataFields.InstrumentOnTime
            '    gfuncGetFieldName = "INSTRUMENTONTIME"
            'Case modConstants.enum_LoggingDataFields.InstrumentComment
            '    gfuncGetFieldName = "INSTRUMENTCOMMENT"
            'Case modConstants.enum_LoggingDataFields.AccessType
            '    gfuncGetFieldName = "ACCESSTYPE"
            'Case modConstants.enum_LoggingDataFields.AccessoriesUsed
            '    gfuncGetFieldName = "ACCESSORIES"
            'Case modConstants.enum_LoggingDataFields.DacError
            '    gfuncGetFieldName = "DACERROR"
            'Case modConstants.enum_LoggingDataFields.ZeroValue
            '    gfuncGetFieldName = "ZEROVAL"
            'Case modConstants.enum_LoggingDataFields.DacValue
            '    gfuncGetFieldName = "DACVAL"
            'Case modConstants.enum_LoggingDataFields.InstrumentFlag
            '    gfuncGetFieldName = "INSTRUMENTFLAG"
            'Case modConstants.enum_LoggingDataFields.Printer
            '    gfuncGetFieldName = "PRINTER"
            'Case modConstants.enum_LoggingDataFields.Keyboard
            '    gfuncGetFieldName = "KEYBOARD"
            'Case modConstants.enum_LoggingDataFields.Baseline
            '    gfuncGetFieldName = "BASELINE"
        End Select
    End Function


#End Region

End Module
