Option Explicit On 

Imports System.Data
Imports System.Data.OleDb
Imports System.IO
'''Imports CrystalDecisions.CrystalReports.Engine
'''Imports CrystalDecisions.Shared
Imports ErrorHandler.ErrorHandler


Module mGeneralFunctions

#Region " Error Logs "

    '    'Public Sub gsubErrorHandlerInitialization(ByRef objErrorHandlerIn As ErrorHandler)

    '        Try
    '            objErrorHandlerIn.CompanyName = Application.ProductName
    '            objErrorHandlerIn.ErrorLogFolder = "ErrorLogs"
    '            objErrorHandlerIn.ErrorLogFileName = Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder & "\ErrorLog-" & DateAndTime.DateString & "-" & DateAndTime.Hour(Now) & "-" & DateAndTime.Minute(Now) & "-" & DateAndTime.Second(Now) & ".log"
    '            objErrorHandlerIn.VersionMajor = Application.ProductVersion
    '            objErrorHandlerIn.ProductName = Application.ProductName

    '            objErrorHandlerIn.ExecutionTrailFolder = "ExecutionLogs"
    '            objErrorHandlerIn.ExecutionLogFileName = Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder & "\ExecutionLog-" & DateAndTime.DateString & "-" & DateAndTime.Hour(Now) & "-" & DateAndTime.Minute(Now) & "-" & DateAndTime.Second(Now) & ".log"

    '            '--- Check for the folders if not create the folders
    '            If Not Directory.Exists(Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder) Then
    '                '--- Create the folder
    '                Directory.CreateDirectory(Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder)
    '            End If

    '            If Not Directory.Exists(Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder) Then
    '                '--- Create the folder
    '                Directory.CreateDirectory(Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder)
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try

    '    End Sub

#End Region

#Region "Validation"

    '''Public Sub gsubPerfomTest(ByVal intTest As Integer)
    '''    Try
    '''        Dim objPQTest As New frmPQTestStatus

    '''        '--- Perform the test
    '''        Select Case intTest
    '''            Case enumValidationTests.NoiseTest
    '''                objPQTest.Test = enumValidationTests.NoiseTest
    '''                Call objPQTest.ShowDialog()
    '''            Case enumValidationTests.BaselineFlatnessTest
    '''                objPQTest.Test = enumValidationTests.BaselineFlatnessTest
    '''                Call objPQTest.ShowDialog()
    '''            Case enumValidationTests.WvAccDeuteriumLamp
    '''                objPQTest.Test = enumValidationTests.WvAccDeuteriumLamp
    '''                Call objPQTest.ShowDialog()
    '''            Case enumValidationTests.PhotometryAccuracyPottasiumDichromate
    '''                objPQTest.Test = enumValidationTests.PhotometryAccuracyPottasiumDichromate
    '''                Call objPQTest.ShowDialog()
    '''            Case enumValidationTests.StrayLight_KCL
    '''                objPQTest.Test = enumValidationTests.StrayLight_KCL
    '''                Call objPQTest.ShowDialog()
    '''            Case enumValidationTests.ResolutionTest
    '''                objPQTest.Test = enumValidationTests.ResolutionTest
    '''                Call objPQTest.ShowDialog()
    '''        End Select

    '''    Catch ex As Exception
    '''        '---------------------------------------------------------
    '''        'Error Handling and logging
    '''        gobjErrorHandler.ErrorDescription = ex.Message
    '''        gobjErrorHandler.ErrorMessage = ex.Message
    '''        gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
    '''        '---------------------------------------------------------
    '''    Finally
    '''        '---------------------------------------------------------
    '''        'Writing Execution log
    '''        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '''            gobjErrorHandler.WriteExecutionLog()
    '''        End If
    '''        '---------------------------------------------------------
    '''    End Try
    '''End Sub

    Public Function mfuncAceptNumeric(ByRef rchtxtstr As RichTextBox, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim OldText As String
            Dim TempText As String
            Dim i As Integer
            Static intDecCount As Integer
            'storing actual Text
            OldText = rchtxtstr.Text
            intDecCount = 0
            'if numeric or "." is entered 
            If ((e.KeyValue) >= 48 And (e.KeyValue) <= 57) Or ((e.KeyValue) >= 96 And (e.KeyValue) <= 105) Or ((e.KeyValue = 190) Or (e.KeyValue = 110)) Then

                For i = 0 To (Len(rchtxtstr.Text) - 1)
                    'retreiving each character
                    TempText = OldText.Substring(i, 1)
                    'loop to check if Decimal is entered once
                    If TempText = "." Then
                        intDecCount = intDecCount + 1
                    End If

                    If intDecCount > 1 Then
                        'MsgBox("Only one Decimal allowed", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Error in Value")
                        'Truncating decimal
                        OldText = OldText.Substring(0, Len(rchtxtstr.Text) - 1)
                        rchtxtstr.Text = OldText
                        rchtxtstr.SelectionStart = Len(rchtxtstr.Text)
                    End If
                Next i
            Else
                Beep()
                'if not numeric
                For i = 1 To (Len(rchtxtstr.Text))
                    'retreiving each character from string
                    TempText = Microsoft.VisualBasic.Mid(OldText, i, 1)
                    'if character is not numeric
                    If Not (IsNumeric(TempText)) Then
                        OldText = OldText.Substring(0, Len(rchtxtstr.Text) - 1)
                        rchtxtstr.Text = OldText
                        rchtxtstr.SelectionStart = Len(rchtxtstr.Text)
                    End If
                Next i
            End If
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function
    Public Function mfuncChangeUcase(ByRef rchtxtstr As RichTextBox) As String
        Try
            Dim FormerText, LaterText As String
            Dim i As Integer
            For i = 1 To ((rchtxtstr.TextLength))
                'changing first character of string to uppercase
                If i = 1 Then
                    FormerText = UCase(Microsoft.VisualBasic.Mid(rchtxtstr.Text, i, 1))
                Else
                    'kepping intact rest of string
                    LaterText = LaterText + Mid(rchtxtstr.Text, i, 1)
                End If

            Next i
            rchtxtstr.Text = FormerText + LaterText

            rchtxtstr.SelectionStart = rchtxtstr.TextLength

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function
    Public Function mfuncChangeUcase(ByRef rchtxtstr As TextBox) As String
        Try

            Dim FormerText, LaterText As String
            Dim i As Integer
            For i = 1 To ((rchtxtstr.TextLength))
                If i = 1 Then
                    FormerText = UCase(Microsoft.VisualBasic.Mid(rchtxtstr.Text, i, 1))
                Else
                    LaterText = LaterText + Mid(rchtxtstr.Text, i, 1)
                End If

            Next i
            rchtxtstr.Text = FormerText + LaterText

            rchtxtstr.SelectionStart = rchtxtstr.TextLength
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function
    Public Function mfuncformatText(ByVal strInfo As String, ByVal strGet As String) As String
        Try

            'stroring "''" in database if value contains "'"
            If strGet = "ToDataBase" Then
                If strInfo <> "" Then
                    strInfo = Replace(strInfo, "'", "''")
                End If
            Else
                'retreiving "''" from database and converting to "'" for display
                If strGet = "FromDataBase" Then
                    If strInfo <> "" Then
                        strInfo = Replace(strInfo, "''", "'")
                    End If
                End If
            End If

            Return (strInfo)
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try

    End Function

    'Public Function gfuncOpenConnection()

    '    'Initialising Connection String
    '    gOleDBconnectiostring = gclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '    ''Initialising Connection 
    '    gOledbConnectionObj = New OleDbConnection(gOleDBconnectiostring)
    '    gOledbConnectionObj.Open()
    'End Function

#End Region

#Region "Check for Mode Locked"
    'Public Function gfuncCheckModeLocked(ByVal intMode As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   gfuncCheckModeLocked
    '    ' Description           :   To Check if Mode is Locked for Edit or Not.
    '    ' Purpose               :   To Check if Mode is Locked for Edit or Not.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   February, 2003 
    '    ' Revisions             :
    '    '=====================================================================
    '    'Dim objReader As OleDbDataReader
    '    Dim sql_string, str_connection As String
    '    Dim reader_status, status As Boolean
    '    Dim intModeState As Integer
    '    'Dim objclsDBFunctions As New clsDatabaseFunctions
    '    'Dim objConnection As OleDbConnection

    '    Try
    '        status = False

    '        'str_connection = objclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)
    '        'objConnection = New OleDbConnection(str_connection)

    '        sql_string = "Select IQModeLocked ,OQModeLocked ,PQModeLocked from CustomerDetails where CustomerID = " & 1 & " "

    '        'reader_status = objclsDBFunctions.GetRecords(sql_string, objConnection, objReader)

    '        If Not (reader_status) Then
    '            Throw New Exception("Error in Opening Connection during Getting Mode Lock Status.")
    '        End If

    '        'While objReader.Read
    '        '    Select Case intMode
    '        '        Case ENUM_IQOQPQ_STATUS.IQ
    '        '            If IsDBNull(objReader.Item("IQModeLocked")) = False Then
    '        '                intModeState = CInt(objReader.Item("IQModeLocked"))
    '        '            Else
    '        '                intModeState = 0
    '        '            End If

    '        '        Case ENUM_IQOQPQ_STATUS.OQ
    '        '            If IsDBNull(objReader.Item("OQModeLocked")) = False Then
    '        '                intModeState = CInt(objReader.Item("OQModeLocked"))
    '        '            Else
    '        '                intModeState = 0
    '        '            End If

    '        '        Case ENUM_IQOQPQ_STATUS.PQ
    '        '            If IsDBNull(objReader.Item("PQModeLocked")) = False Then
    '        '                intModeState = CInt(objReader.Item("PQModeLocked"))
    '        '            Else
    '        '                intModeState = 0
    '        '            End If
    '        '        Case Else
    '        '            intModeState = 0
    '        '    End Select
    '        'End While

    '        If (intModeState = 1) Then
    '            status = True
    '        End If
    '        'objReader.Close()
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Getting Mode Lock Status."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return (False)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    '    Return status
    'End Function

    'Public Function gfuncUpdateModeLockStatus(ByVal intMode As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        :   gfuncUpdateModeLockStatus
    '    ' Description           :   To Update Lock Mode Status in Database.
    '    ' Purpose               :   To Update Lock Mode Status in Database.
    '    ' Parameters Passed     :   None.
    '    ' Returns               :   None.
    '    ' Parameters Affected   :   None.
    '    ' Assumptions           :
    '    ' Dependencies          :
    '    ' Author                :   Gitesh
    '    ' Created               :   February, 2003 
    '    ' Revisions             :
    '    '=====================================================================

    '    Dim Status As Boolean
    '    Dim str_sql, str_connection As String
    '    Dim objCommand As New OleDbCommand
    '    'Dim objclsDBFunctions As New clsDatabaseFunctions
    '    Dim objConnection As OleDbConnection

    '    Try
    '        'str_connection = objclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)
    '        objConnection = New OleDbConnection(str_connection)

    '        'Status = objclsDBFunctions.OpenConnection(objConnection)
    '        If Not (Status) Then
    '            Throw New Exception("Error in Opening Connection during Updating Mode Lock Status.")
    '        End If

    '        Select Case intMode
    '            Case ENUM_IQOQPQ_STATUS.IQ
    '                str_sql = " Update CustomerDetails " & _
    '                          " Set IQModeLocked = 1 where CustomerID = " & 1 & " "
    '            Case ENUM_IQOQPQ_STATUS.OQ
    '                str_sql = " Update CustomerDetails " & _
    '                          " Set OQModeLocked = 1 where CustomerID = " & 1 & " "
    '            Case ENUM_IQOQPQ_STATUS.PQ
    '                str_sql = " Update CustomerDetails " & _
    '                          " Set PQModeLocked = 1 where CustomerID = " & 1 & " "
    '            Case Else
    '                str_sql = ""
    '                Throw New Exception("Mode Selected to Lock is In-correct.")
    '        End Select

    '        '--- Providing command object 
    '        With objCommand
    '            .Connection = objConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = str_sql
    '            .ExecuteNonQuery()
    '        End With

    '        objCommand.Dispose()
    '        Status = True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        '--- Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in Updating Mode Lock Status."
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return (False)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        '--- Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    '    Return Status

    'End Function
#End Region

#Region "Functions for Printing & Exporting"

    Public Function gfuncPrintExportIQOQPQ(ByVal intActiveFormTag As Integer, ByVal blnFlag As Boolean, ByVal blnExport As Boolean, ByVal strFileName As String)
        Try
            If blnFlag = False Then
                Select Case intActiveFormTag
                    Case ENUM_IQ_Modes.IQ_CustomerDetails
                        Call gfuncPrintCustomerDetails(blnExport, strFileName)
                        'Case ENUM_IQ_Modes.IQ_EquipmentList
                        '    Call gfuncPrintIQEquipmentList(blnExport, strFileName)
                        'Case ENUM_IQ_Modes.IQ_Approval
                        '    Call gfuncPrintIQ_Approval(blnExport, strFileName)
                        'Case ENUM_IQ_Modes.IQ_Deficiency
                        '    Call gfuncPrintIQ_Deficiency(blnExport, strFileName)
                        'Case ENUM_IQ_Modes.IQ_ManualList
                        '    Call gfuncPrintIQ_ManualList(blnExport, strFileName)
                        'Case ENUM_IQ_Modes.IQ_Specifications
                        '    Call gfuncPrintIQ_Specifications(blnExport, strFileName)
                        'Case ENUM_IQ_Modes.IQ_Tests
                        '    Call gfuncPrintIQ_Test(blnExport, strFileName)
                        'Case ENUM_OQ_Modes.OQ_Approval
                        '    Call gfuncPrintOQ_Approval(blnExport, strFileName)
                        'Case ENUM_OQ_Modes.OQ_Deficiency
                        '    Call gfuncPrintOQ_Deficiency(blnExport, strFileName)
                        'Case ENUM_OQ_Modes.OQ_EquipmentList
                        '    Call gfuncPrintOQEquipmentList(blnExport, strFileName)
                        'Case ENUM_OQ_Modes.OQ_Test1
                        '    Call gfuncPrintOQ_Test1(blnExport, strFileName)
                        'Case ENUM_OQ_Modes.OQ_Test2
                        '    Call gfuncPrintOQ_Test2(blnExport, strFileName)
                        'Case ENUM_OQ_Modes.OQ_UserTraining
                        '    Call gfuncPrintOQ_UserTraining(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_Approval
                        '    Call gfuncPrintPQ_Approval(blnExport, strFileName)
                    Case ENUM_PQ_Modes.PQ_Attachment1
                        Call gfuncPrintPQ_Attachment1(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_Attachment2
                        '    Call gfuncPrintPQ_Attachment2(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_Attachment3
                        '    Call gfuncPrintPQ_Attachment3(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_Attachment4
                        '    Call gfuncPrintPQ_Attachment4(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_Attachment5
                        '    Call gfuncPrintPQ_Attachment5(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_Deficiency
                        '    Call gfuncPrintPQ_Deficiency(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_EquipmentList
                        '    Call gfuncPrintPQEquipmentList(blnExport, strFileName)
                        'Case ENUM_PQ_Modes.PQ_Test
                        '    Call gfuncPrintPQ_Test(blnExport, strFileName)
                    Case ENUM_PQ_Modes.PQ_Warranty
                        Call gfuncPrintWarranty(blnExport, strFileName)

                End Select

            Else
                Call gfuncPrintCustomerDetails(blnExport, strFileName)
                'Call gfuncPrintIQEquipmentList(blnExport, strFileName)
                'Call gfuncPrintIQ_Approval(blnExport, strFileName)
                'Call gfuncPrintIQ_Deficiency(blnExport, strFileName)
                'Call gfuncPrintIQ_ManualList(blnExport, strFileName)
                'Call gfuncPrintIQ_Specifications(blnExport, strFileName)
                'Call gfuncPrintIQ_Test(blnExport, strFileName)
                'Call gfuncPrintOQ_Approval(blnExport, strFileName)
                'Call gfuncPrintOQ_Deficiency(blnExport, strFileName)
                'Call gfuncPrintOQEquipmentList(blnExport, strFileName)
                'Call gfuncPrintOQ_Test1(blnExport, strFileName)
                'Call gfuncPrintOQ_Test2(blnExport, strFileName)
                'Call gfuncPrintOQ_UserTraining(blnExport, strFileName)
                'Call gfuncPrintPQ_Approval(blnExport, strFileName)
                Call gfuncPrintPQ_Attachment1(blnExport, strFileName)
                'Call gfuncPrintPQ_Attachment2(blnExport, strFileName)
                'Call gfuncPrintPQ_Attachment3(blnExport, strFileName)
                'Call gfuncPrintPQ_Attachment4(blnExport, strFileName)
                'Call gfuncPrintPQ_Attachment5(blnExport, strFileName)
                'Call gfuncPrintPQ_Deficiency(blnExport, strFileName)
                'Call gfuncPrintPQEquipmentList(blnExport, strFileName)
                'Call gfuncPrintPQ_Test(blnExport, strFileName)
                Call gfuncPrintWarranty(blnExport, strFileName)
                ''  Call gfuncExportAll(strFileName)
                Call gfuncPrintAll()
            End If


            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function gfuncPrintIQOQPQ(ByVal intActiveFormTag As Integer, ByVal blnFlag As Boolean)
        Try
            gobjfrmMdi.objPrintDialog.Document = gobjfrmMdi.PrintDocument1
            gobjfrmMdi.objPrintDialog.PrinterSettings = gobjfrmMdi.PrintDocument1.PrinterSettings
            gobjfrmMdi.objPrintDialog.AllowSomePages = True

            If gobjfrmMdi.objPrintDialog.ShowDialog() = DialogResult.OK Then
                Call gfuncPrintExportIQOQPQ(intActiveFormTag, blnFlag, False, "")
            End If

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function gfuncExportAll(ByVal strFileName As String)
        Dim rptExportAll As New crptAllReport

        Try

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerDetails where CustomerID = 1", objOleDBconnection)
            ''gobjDataSet = New dtsetExportAll
            'gobjDataAdapter.Fill(gobjDataSet, "CustomerDetails")
            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 1", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "EquipmentList")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQManualList", objOleDBconnection)
            'gobjDataAdapter.Fill(gobjDataSet, "IQManualList")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQSpecification", objOleDBconnection)
            '' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "IQSpecification")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQAccessory", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "IQAccessory")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 1", objOleDBconnection)
            '' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "DeficiencyCorrectiveActionPlan")


            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "CustomerRepresentative")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "ManufacturerRepresentative")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from Test", objOleDBconnection)
            '' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "Test")


            ''###################################
            ''forms of OQ
            ''##################################

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQCustomerRepresentative")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQManufacturerRepresentative")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 2", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQEquipmentList")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 2", objOleDBconnection)
            '' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQDeficiencyCorrectiveActionPlan")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUserTraining", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQUserTraining")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUser", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQUser")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQTest", objOleDBconnection)
            '' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQTest")

            ''###################################
            ''forms of PQ
            ''##################################

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQCustomerRepresentative")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQManufacturerRepresentative")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 3", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQEquipmentList")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
            ''// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 3", objOleDBconnection)
            '' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQDeficiencyCorrectiveActionPlan")

            'gobjDataAdapter = New OleDbDataAdapter("Select Distinct ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments From PQTest1 Group by ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments ", objOleDBconnection)
            ''' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
            ''' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQTest1")
            funcGetDataSet()

            rptExportAll.SetDataSource(gobjDataSet)
            rptExportAll.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function gfuncPrintAll()
        Dim rptPrintAll As New crptAllReport
        ' Dim objrptPQTest6 As New PQTest6
        'Dim section As Section
        'Dim fieldText As TextObject

        Try

            funcGetDataSet()

            rptPrintAll.SetDataSource(gobjDataSet)

            gobjfrmMdi.objPrintDialog.Document = gobjfrmMdi.PrintDocument1
            gobjfrmMdi.objPrintDialog.PrinterSettings = gobjfrmMdi.PrintDocument1.PrinterSettings
            gobjfrmMdi.objPrintDialog.AllowSomePages = True

            If gobjfrmMdi.objPrintDialog.ShowDialog() = DialogResult.OK Then
                rptPrintAll.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
                rptPrintAll.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
            End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function funcGetDataSet() As Boolean
        Dim intCount, intColCount As Integer
        Dim mobjDt As DataTable
        Try
            gobjDataSet = New dtsetExportAll

            Dim objDrCDNewRow As dtsetExportAll.CustomerDetailsRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.GetCustomerDetails()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objDrCDNewRow = gobjDataSet.CustomerDetails.NewCustomerDetailsRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objDrCDNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.CustomerDetails.AddCustomerDetailsRow(objDrCDNewRow)
            Next

            Dim objELNewRow As dtsetExportAll.EquipmentListRow
            Dim objELOQNewRow As dtsetExportAll.OQEquipmentListRow '25.2.2010
            Dim objELPQNewRow As dtsetExportAll.PQEquipmentListRow '25.2.2010


            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetIQEquipmentListRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objELNewRow = gobjDataSet.EquipmentList.NewEquipmentListRow()
                objELOQNewRow = gobjDataSet.OQEquipmentList.NewOQEquipmentListRow() '25.2.2010
                objELPQNewRow = gobjDataSet.PQEquipmentList.NewPQEquipmentListRow() '25.2.2010

                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objELNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)


                    '25.2.2010
                    '--------------------------------
                    If objELOQNewRow.Table.Columns.Count > intColCount Then
                        objELOQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                    End If
                    If objELPQNewRow.Table.Columns.Count > intColCount Then
                        objELPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                    End If

                    '-------------------------------

                Next
                gobjDataSet.EquipmentList.AddEquipmentListRow(objELNewRow)
                gobjDataSet.OQEquipmentList.AddOQEquipmentListRow(objELOQNewRow) 'by dinesh wagh on 25.2.2010
                gobjDataSet.PQEquipmentList.AddPQEquipmentListRow(objELPQNewRow) 'by dinesh wagh on 25.2.2010

            Next

            Dim objCANewRow As dtsetExportAll.CompletedAcceptedBYRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetCompleteAcceptRecords(ENUM_IQOQPQ_STATUS.IQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objCANewRow = gobjDataSet.CompletedAcceptedBY.NewCompletedAcceptedBYRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objCANewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.CompletedAcceptedBY.AddCompletedAcceptedBYRow(objCANewRow)
            Next

            Dim objMLNewRow As dtsetExportAll.IQManualListRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetIQManualListRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objMLNewRow = gobjDataSet.IQManualList.NewIQManualListRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objMLNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.IQManualList.AddIQManualListRow(objMLNewRow)
            Next

            Dim objSpNewRow As dtsetExportAll.IQSpecificationRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetIQSpecificationRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objSpNewRow = gobjDataSet.IQSpecification.NewIQSpecificationRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objSpNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.IQSpecification.AddIQSpecificationRow(objSpNewRow)
            Next

            Dim objAcNewRow As dtsetExportAll.IQAccessoryRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetIQAccessoryRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objAcNewRow = gobjDataSet.IQAccessory.NewIQAccessoryRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objAcNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.IQAccessory.AddIQAccessoryRow(objAcNewRow)
            Next

            Dim objDRNewRow As dtsetExportAll.DeficiencyCorrectiveActionPlanRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetDeficiencyRecords(ENUM_IQOQPQ_STATUS.IQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objDRNewRow = gobjDataSet.DeficiencyCorrectiveActionPlan.NewDeficiencyCorrectiveActionPlanRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objDRNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.DeficiencyCorrectiveActionPlan.AddDeficiencyCorrectiveActionPlanRow(objDRNewRow)
            Next

            Dim objCRNewRow As dtsetExportAll.CustomerRepresentativeRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetCustomerRecords(ENUM_IQOQPQ_STATUS.IQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objCRNewRow = gobjDataSet.CustomerRepresentative.NewCustomerRepresentativeRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objCRNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.CustomerRepresentative.AddCustomerRepresentativeRow(objCRNewRow)
            Next

            Dim objSRNewRow As dtsetExportAll.ManufacturerRepresentativeRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetSupplierRecords(ENUM_IQOQPQ_STATUS.IQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objSRNewRow = gobjDataSet.ManufacturerRepresentative.NewManufacturerRepresentativeRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objSRNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.ManufacturerRepresentative.AddManufacturerRepresentativeRow(objSRNewRow)
            Next

            Dim objTNewRow As dtsetExportAll.TestRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetIQTestRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objTNewRow = gobjDataSet.Test.NewTestRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objTNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.Test.AddTestRow(objTNewRow)
            Next

            '###################################
            'forms of OQ
            '##################################

            Dim objCROQNewRow As dtsetExportAll.OQCustomerRepresentativeRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetCustomerRecords(ENUM_IQOQPQ_STATUS.OQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objCROQNewRow = gobjDataSet.OQCustomerRepresentative.NewOQCustomerRepresentativeRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objCROQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.OQCustomerRepresentative.AddOQCustomerRepresentativeRow(objCROQNewRow)
            Next

            Dim objSROQNewRow As dtsetExportAll.OQManufacturerRepresentativeRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetSupplierRecords(ENUM_IQOQPQ_STATUS.OQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objSROQNewRow = gobjDataSet.OQManufacturerRepresentative.NewOQManufacturerRepresentativeRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objSROQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.OQManufacturerRepresentative.AddOQManufacturerRepresentativeRow(objSROQNewRow)
            Next

            'code commented by ; dinesh wagh on 25.2.2010
            '------------------------------------------------------------
            ''Dim objELOQNewRow As dtsetExportAll.OQEquipmentListRow
            ''mobjDt = New DataTable
            ''mobjDt = gobjDataAccess.funcGetOQEquipmentListRecords(ENUM_IQOQPQ_STATUS.OQ)
            ''For intCount = 0 To mobjDt.Rows.Count - 1
            ''    objELOQNewRow = gobjDataSet.OQEquipmentList.NewOQEquipmentListRow()
            ''    For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
            ''        objELOQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
            ''    Next
            ''    gobjDataSet.OQEquipmentList.AddOQEquipmentListRow(objELOQNewRow)
            ''Next
            '---------------------------------------------------------



            Dim objCAOQNewRow As dtsetExportAll.OQCompletedAcceptedByRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetCompleteAcceptRecords(ENUM_IQOQPQ_STATUS.OQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objCAOQNewRow = gobjDataSet.OQCompletedAcceptedBy.NewOQCompletedAcceptedByRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objCAOQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.OQCompletedAcceptedBy.AddOQCompletedAcceptedByRow(objCAOQNewRow)
            Next

            Dim objDROQNewRow As dtsetExportAll.OQDeficiencyCorrectiveActionPlanRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetDeficiencyRecords(ENUM_IQOQPQ_STATUS.OQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objDROQNewRow = gobjDataSet.OQDeficiencyCorrectiveActionPlan.NewOQDeficiencyCorrectiveActionPlanRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objDROQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.OQDeficiencyCorrectiveActionPlan.AddOQDeficiencyCorrectiveActionPlanRow(objDROQNewRow)
            Next

            Dim objOQUTNewRow As dtsetExportAll.OQUserTrainingRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetOQUserTrainingRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objOQUTNewRow = gobjDataSet.OQUserTraining.NewOQUserTrainingRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objOQUTNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.OQUserTraining.AddOQUserTrainingRow(objOQUTNewRow)
            Next

            Dim objOQURNewRow As dtsetExportAll.OQUserRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetOQUserRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objOQURNewRow = gobjDataSet.OQUser.NewOQUserRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objOQURNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.OQUser.AddOQUserRow(objOQURNewRow)
            Next

            Dim objOQT1NewRow As dtsetExportAll.OQTestRow
            Dim intTotalRows As Integer
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetOQTest1AllRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objOQT1NewRow = gobjDataSet.OQTest.NewOQTestRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objOQT1NewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.OQTest.AddOQTestRow(objOQT1NewRow)
            Next

            '###################################
            'forms of PQ
            '##################################

            Dim objCRPQNewRow As dtsetExportAll.PQCustomerRepresentativeRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetCustomerRecords(ENUM_IQOQPQ_STATUS.PQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objCRPQNewRow = gobjDataSet.PQCustomerRepresentative.NewPQCustomerRepresentativeRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objCRPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.PQCustomerRepresentative.AddPQCustomerRepresentativeRow(objCRPQNewRow)
            Next

            Dim objSRPQNewRow As dtsetExportAll.PQManufacturerRepresentativeRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetSupplierRecords(ENUM_IQOQPQ_STATUS.PQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objSRPQNewRow = gobjDataSet.PQManufacturerRepresentative.NewPQManufacturerRepresentativeRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objSRPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.PQManufacturerRepresentative.AddPQManufacturerRepresentativeRow(objSRPQNewRow)
            Next

            'code commented by  : dinesh wagh on 25.2.2010
            '-----------------------------------------------------------------
            ''Dim objELPQNewRow As dtsetExportAll.PQEquipmentListRow
            ''mobjDt = New DataTable
            ''mobjDt = gobjDataAccess.funcGetOQEquipmentListRecords(ENUM_IQOQPQ_STATUS.PQ)
            ''For intCount = 0 To mobjDt.Rows.Count - 1
            ''    objELPQNewRow = gobjDataSet.PQEquipmentList.NewPQEquipmentListRow()
            ''    For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
            ''        objELPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
            ''    Next
            ''    gobjDataSet.PQEquipmentList.AddPQEquipmentListRow(objELPQNewRow)
            ''Next
            '-----------------------------------------------------

            Dim objCAPQNewRow As dtsetExportAll.PQCompletedAcceptedByRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetCompleteAcceptRecords(ENUM_IQOQPQ_STATUS.PQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objCAPQNewRow = gobjDataSet.PQCompletedAcceptedBy.NewPQCompletedAcceptedByRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objCAPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.PQCompletedAcceptedBy.AddPQCompletedAcceptedByRow(objCAPQNewRow)
            Next

            Dim objDRPQNewRow As dtsetExportAll.PQDeficiencyCorrectiveActionPlanRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetDeficiencyRecords(ENUM_IQOQPQ_STATUS.PQ)
            For intCount = 0 To mobjDt.Rows.Count - 1
                objDRPQNewRow = gobjDataSet.PQDeficiencyCorrectiveActionPlan.NewPQDeficiencyCorrectiveActionPlanRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objDRPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.PQDeficiencyCorrectiveActionPlan.AddPQDeficiencyCorrectiveActionPlanRow(objDRPQNewRow)
            Next

            Dim objPQT1NewRow As dtsetExportAll.PQTest1Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQConfirmityRecords()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT1NewRow = gobjDataSet.PQTest1.NewPQTest1Row()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objPQT1NewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.PQTest1.AddPQTest1Row(objPQT1NewRow)
            Next


            'Dim objPQT2NewRow As dtsetExportAll.PQTest2Row
            'mobjDt = New DataTable
            'mobjDt = gobjDataAccess.funcGetPQTest1Records()
            'For intCount = 0 To mobjDt.Rows.Count - 1
            '    objPQT2NewRow = gobjDataSet.PQTest2.NewPQTest2Row()
            '    objPQT2NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
            '    objPQT2NewRow.Item("PQAbsorbance") = mobjDt.Rows(intCount).Item("PQAbsorbance")
            '    objPQT2NewRow.Item("DistBySoapRing") = mobjDt.Rows(intCount).Item("DistBySoapRing")
            '    objPQT2NewRow.Item("Time") = mobjDt.Rows(intCount).Item("Time")
            '    objPQT2NewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
            '    objPQT2NewRow.Item("PQCriteria") = mobjDt.Rows(intCount).Item("PQCriteria")
            '    objPQT2NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
            '    objPQT2NewRow.Item("PQComments") = mobjDt.Rows(intCount).Item("PQComments")
            '    objPQT2NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
            '    objPQT2NewRow.Item("Date") = mobjDt.Rows(intCount).Item("Date")
            '    gobjDataSet.PQTest2.AddPQTest2Row(objPQT2NewRow)
            'Next


            Dim objPQT11NewRow As dtsetExportAll.PQTest11Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest1Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT11NewRow = gobjDataSet.PQTest11.NewPQTest11Row
                objPQT11NewRow.Item("SampleID") = mobjDt.Rows(intCount).Item("SampleID")
                objPQT11NewRow.Item("LampCurrent") = mobjDt.Rows(intCount).Item("LampCurrent")
                objPQT11NewRow.Item("PMTVoltage") = mobjDt.Rows(intCount).Item("PMTVoltage")
                objPQT11NewRow.Item("WaveLength") = mobjDt.Rows(intCount).Item("WaveLength")
                objPQT11NewRow.Item("SlitWidth") = mobjDt.Rows(intCount).Item("SlitWidth")
                objPQT11NewRow.Item("BurnerHeight") = mobjDt.Rows(intCount).Item("BurnerHeight")
                objPQT11NewRow.Item("Fuel") = mobjDt.Rows(intCount).Item("Fuel")
                objPQT11NewRow.Item("Absorbance") = mobjDt.Rows(intCount).Item("Absorbance")
                objPQT11NewRow.Item("Remark") = mobjDt.Rows(intCount).Item("Remark")
                'objPQT11NewRow.Item("Date") = mobjDt.Rows(intCount).Item("Date") '30.3.2010 by dinesh wagh
                objPQT11NewRow.Item("Date") = Format(CDate(mobjDt.Rows(intCount).Item("Date")), "dd-MMM-yyyy") '30.3.2010 by dinesh wagh
                gobjDataSet.PQTest11.AddPQTest11Row(objPQT11NewRow)
            Next

            'Dim objPQT3NewRow As dtsetExportAll.PQTest3Row
            'mobjDt = New DataTable
            'mobjDt = gobjDataAccess.funcGetPQTest2Records()
            'For intCount = 0 To mobjDt.Rows.Count - 1
            '    objPQT3NewRow = gobjDataSet.PQTest3.NewPQTest3Row()
            '    objPQT3NewRow.Item("Parameters") = mobjDt.Rows(intCount).Item("Parameters")
            '    objPQT3NewRow.Item("PQComments") = mobjDt.Rows(intCount).Item("PQComments")
            '    objPQT3NewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
            '    objPQT3NewRow.Item("PQAbsorbance") = mobjDt.Rows(intCount).Item("PQAbsorbance")
            '    objPQT3NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
            '    gobjDataSet.PQTest3.AddPQTest3Row(objPQT3NewRow)
            'Next

            Dim objPQT2NewRow As dtsetExportAll.PQTest2Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest2Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT2NewRow = gobjDataSet.PQTest2.NewPQTest2Row()
                'objPQT2NewRow.Item("SampleID") = mobjDt.Rows(intCount).Item("SampleID") 'commented by ; dinesh wagh on 25.2.2010
                objPQT2NewRow.Item("PQTest2ID") = mobjDt.Rows(intCount).Item("PQTest2ID") 'added by ; dinesh wagh on 25.2.2010
                objPQT2NewRow.Item("Absorbance") = mobjDt.Rows(intCount).Item("Absorbance")
                objPQT2NewRow.Item("Deviation") = mobjDt.Rows(intCount).Item("Deviation")
                gobjDataSet.PQTest2.AddPQTest2Row(objPQT2NewRow)
            Next


            'Dim objPQT4NewRow As dtsetExportAll.PQTest4Row
            'mobjDt = New DataTable
            'mobjDt = gobjDataAccess.funcGetPQTest3Records()
            'For intCount = 0 To mobjDt.Rows.Count - 1
            '    objPQT4NewRow = gobjDataSet.PQTest4.NewPQTest4Row()
            '    'For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
            '    'objPQATNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
            '    'Next
            '    objPQT4NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
            '    objPQT4NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
            '    objPQT4NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
            '    objPQT4NewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
            '    gobjDataSet.PQTest4.AddPQTest4Row(objPQT4NewRow)
            'Next

            Dim objPQT3NewRow As dtsetExportAll.PQTest3Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest3Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT3NewRow = gobjDataSet.PQTest3.NewPQTest3Row()
                'objPQT3NewRow.Item("SampleID") = mobjDt.Rows(intCount).Item("SampleID") 'code commented by ; dinesh wagh on 25.2.2010
                objPQT3NewRow.Item("PQTest3ID") = mobjDt.Rows(intCount).Item("PQTest3ID") 'code added by ; dinesh wagh on 25.2.2010
                objPQT3NewRow.Item("Absorbance") = mobjDt.Rows(intCount).Item("Absorbance")
                objPQT3NewRow.Item("Concentration") = mobjDt.Rows(intCount).Item("Concentration")
                gobjDataSet.PQTest3.AddPQTest3Row(objPQT3NewRow)
            Next


            Dim objPQT5NewRow As dtsetExportAll.PQTest5Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest4Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT5NewRow = gobjDataSet.PQTest5.NewPQTest5Row()
                'For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                'objPQATNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                'Next
                objPQT5NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
                objPQT5NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
                objPQT5NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
                gobjDataSet.PQTest5.AddPQTest5Row(objPQT5NewRow)
            Next

            Dim objPQT6NewRow As dtsetExportAll.PQTest6Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest5Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT6NewRow = gobjDataSet.PQTest6.NewPQTest6Row()

                objPQT6NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
                objPQT6NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
                objPQT6NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
                gobjDataSet.PQTest6.AddPQTest6Row(objPQT6NewRow)
            Next

            Dim objPQT7NewRow As dtsetExportAll.PQTest7Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest6Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT7NewRow = gobjDataSet.PQTest7.NewPQTest7Row()

                objPQT7NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
                objPQT7NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
                objPQT7NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
                gobjDataSet.PQTest7.AddPQTest7Row(objPQT7NewRow)
            Next

            Dim objPQT8NewRow As dtsetExportAll.PQTest8Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest7Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT8NewRow = gobjDataSet.PQTest8.NewPQTest8Row()

                objPQT8NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
                objPQT8NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
                objPQT8NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
                gobjDataSet.PQTest8.AddPQTest8Row(objPQT8NewRow)
            Next

            Dim objPQT9NewRow As dtsetExportAll.PQTest9Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest8Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT9NewRow = gobjDataSet.PQTest9.NewPQTest9Row()

                objPQT9NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
                objPQT9NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
                objPQT9NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
                gobjDataSet.PQTest9.AddPQTest9Row(objPQT9NewRow)
            Next

            Dim objPQT10NewRow As dtsetExportAll.PQTest10Row
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.funcGetPQTest9Records()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objPQT10NewRow = gobjDataSet.PQTest10.NewPQTest10Row()

                objPQT10NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
                objPQT10NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
                objPQT10NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
                gobjDataSet.PQTest10.AddPQTest10Row(objPQT10NewRow)
            Next


            'gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

            ' Get the Section object by name.
            'section = objrptPQTest6.ReportDefinition.Sections.Item("Section4")

            ''--- Type of Instrument
            'If section.ReportObjects("txtRatio").Kind = ReportObjectKind.TextObject Then
            '    fieldText = section.ReportObjects("txtRatio")
            '    fieldText.Text = CStr(gobjValidationTest.ResolutionTest.ObsData.Item(0) / gobjValidationTest.ResolutionTest.ObsData.Item(1))
            'End If

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Function

    Public Function gfuncPrintIQ_Deficiency(ByVal blnExport As Boolean, ByVal strFileName As String)
        Dim rptIQDeficiency As New IQDeficiency
        Dim objOleDBconnection As New OleDbConnection
        Try
            '--- Initialising Connection String
            'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 1", objOleDBconnection)
            'gobjDataSet = New dtsetExportAll

            ' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "DeficiencyCorrectiveActionPlan")

            rptIQDeficiency.SetDataSource(gobjDataSet)


            If blnExport = False Then
                rptIQDeficiency.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
                rptIQDeficiency.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
            Else
                rptIQDeficiency.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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
    Public Function gfuncPrintOQ_Deficiency(ByVal blnExport As Boolean, ByVal strFileName As String)
        Dim rptOQDeficiency As New OQDeficiency
        Dim objOleDBconnection As New OleDbConnection
        Try
            '--- Initialising Connection String
            'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 2", objOleDBconnection)
            'gobjDataSet = New dtsetExportAll

            ' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "OQDeficiencyCorrectiveActionPlan")

            rptOQDeficiency.SetDataSource(gobjDataSet)

            If blnExport = False Then
                rptOQDeficiency.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
                rptOQDeficiency.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)


            Else
                rptOQDeficiency.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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
    Public Function gfuncPrintPQ_Deficiency(ByVal blnExport As Boolean, ByVal strFileName As String)
        Dim rptPQDeficiency As New PQDeficiency
        Dim objOleDBconnection As New OleDbConnection
        Try

            '--- Initialising Connection String
            'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 3", objOleDBconnection)
            'gobjDataSet = New dtsetExportAll

            ' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQDeficiencyCorrectiveActionPlan")

            rptPQDeficiency.SetDataSource(gobjDataSet)


            If blnExport = False Then
                rptPQDeficiency.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
                rptPQDeficiency.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

            Else

                rptPQDeficiency.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

    'Public Function gfuncPrintOQ_Test1(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptOQTest1 As New OQTest1
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQTest", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQTest")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")
    '        rptOQTest1.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptOQTest1.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptOQTest1.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptOQTest1.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintOQ_Test2(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptOQTest2 As New OQTest4
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try


    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQTest", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQTest")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")
    '        rptOQTest2.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptOQTest2.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptOQTest2.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptOQTest2.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If



    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintPQ_Test(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptPQTest As New PQTest1
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

    '        rptPQTest.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptPQTest.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptPQTest.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptPQTest.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintPQ_Attachment5(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptPQAttachment5 As New PQTest6
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
    '        rptPQAttachment5.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptPQAttachment5.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptPQAttachment5.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptPQAttachment5.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If



    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintPQ_Attachment4(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptPQAttachment4 As New PQTest5
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
    '        rptPQAttachment4.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptPQAttachment4.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptPQAttachment4.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

    '        Else
    '            rptPQAttachment4.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If


    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

    'Public Function gfuncPrintPQ_Attachment3(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptPQAttachment3 As New PQTest4
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
    '        rptPQAttachment3.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptPQAttachment3.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptPQAttachment3.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptPQAttachment3.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintPQ_Attachment2(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptPQAttachment2 As New PQTest3
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
    '        rptPQAttachment2.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptPQAttachment2.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptPQAttachment2.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptPQAttachment2.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    Public Function gfuncPrintPQ_Attachment1(ByVal blnExport As Boolean, ByVal strFileName As String)
        Dim rptPQAttachment1 As New PQTest2
        'Dim objOleDBconnection As New OleDbConnection
        Dim intCount, intColCount As Integer
        Dim mobjDt As DataTable
        Try
            '--- Initialising Connection String
            'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
            'gobjDataSet = New dtsetExportAll

            ' Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
            ' gobjDataSet = New dtsetCompletedBy

            '// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
            '---------------Commented on 1 March 2006 by Rahul------------
            'Dim objPQATNewRow As dtsetExportAll.PQTestRow
            'mobjDt = New DataTable
            'mobjDt = gobjDataAccess.funcGetPQAllTestRecords()
            'For intCount = 0 To mobjDt.Rows.Count - 1
            '    objPQATNewRow = gobjDataSet.PQTest1.NewPQTestRow()
            '    'For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
            '    objPQATNewRow.Item("SrNo") = mobjDt.Rows(intCount).Item("SrNo")
            '    objPQATNewRow.Item("PQTestID") = mobjDt.Rows(intCount).Item("PQTestID")
            '    objPQATNewRow.Item("Parameters") = mobjDt.Rows(intCount).Item("Parameters")
            '    objPQATNewRow.Item("PQTestName") = mobjDt.Rows(intCount).Item("PQTestName")
            '    objPQATNewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
            '    objPQATNewRow.Item("PQPurpose") = mobjDt.Rows(intCount).Item("PQPurpose")
            '    objPQATNewRow.Item("PQConformity") = mobjDt.Rows(intCount).Item("PQConformity")
            '    objPQATNewRow.Item("PQComments") = mobjDt.Rows(intCount).Item("PQComments")
            '    objPQATNewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
            '    objPQATNewRow.Item("PQCriteria") = mobjDt.Rows(intCount).Item("PQCriteria")
            '    objPQATNewRow.Item("PQAbsorbance") = mobjDt.Rows(intCount).Item("PQAbsorbance")
            '    'Next
            '    gobjDataSet.PQTest1.AddPQTestRow(objPQATNewRow)
            'Next
            'rptPQAttachment1.SetDataSource(gobjDataSet)
            'If blnExport = False Then
            '    rptPQAttachment1.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
            '    rptPQAttachment1.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
            '        gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
            '        gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
            '        gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
            'Else
            '    rptPQAttachment1.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
            'End If
            '---------------Commented on 1 March 2006 by Rahul------------

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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
    'Public Function gfuncPrintIQ_Test(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptIQTest As New IQTest
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try
    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from Test", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "Test")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")
    '        rptIQTest.SetDataSource(gobjDataSet)
    '        If blnExport = False Then
    '            rptIQTest.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptIQTest.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptIQTest.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintIQ_Specifications(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptIQ_Specifications As New IQInstSpecification
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQSpecification", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        ' Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "IQSpecification")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQAccessory ", objOleDBconnection)

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "IQAccessory")

    '        'PrintDocument1.Print()
    '        rptIQ_Specifications.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptIQ_Specifications.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptIQ_Specifications.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptIQ_Specifications.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintIQ_ManualList(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptManualList As New IQManualListing
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQManualList ", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "IQManualList")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")

    '        'PrintDocument1.Print()
    '        rptManualList.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptManualList.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptManualList.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptManualList.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintOQ_Approval(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptOQApproval As New OQApproval
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQCustomerRepresentative")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
    '        '  gobjDataSet = New dtsetIQApproval

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQManufacturerRepresentative")
    '        'PrintDocument1.Print()
    '        rptOQApproval.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptOQApproval.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptOQApproval.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptOQApproval.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintPQ_Approval(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptPQApproval As New PQApproval
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQCustomerRepresentative")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        '  gobjDataSet = New dtsetIQApproval

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQManufacturerRepresentative")
    '        'PrintDocument1.Print()
    '        rptPQApproval.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptPQApproval.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptPQApproval.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptPQApproval.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintIQ_Approval(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptIQApproval As New IQApproval
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try
    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "CustomerRepresentative")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
    '        '  gobjDataSet = New dtsetIQApproval

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "ManufacturerRepresentative")
    '        'PrintDocument1.Print()
    '        rptIQApproval.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptIQApproval.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptIQApproval.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptIQApproval.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintIQ_Accessory(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptIQ_Accessory As New IQInstAccessory
    '    Dim objOleDBconnection As New OleDbConnection

    '    'Dim aw As New frmReportsViewer
    '    Try
    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQAccessory ", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "IQAccessory")

    '        'PrintDocument1.Print()
    '        rptIQ_Accessory.SetDataSource(gobjDataSet)

    '        'added and commented by kamal on 19March2004
    '        '----------------------------
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintIQEquipmentList(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptIQEquipment As New IQEquipmentList
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try
    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 1", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "EquipmentList")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")
    '        'PrintDocument1.Print()
    '        rptIQEquipment.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptIQEquipment.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptIQEquipment.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

    '        Else
    '            rptIQEquipment.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintOQ_UserTraining(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptOQ_UserTraining As New OQUserTraining
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try
    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUserTraining", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQUserTraining")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUser", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQUser")
    '        rptOQ_UserTraining.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptOQ_UserTraining.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptOQ_UserTraining.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
    '        Else
    '            rptOQ_UserTraining.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintOQEquipmentList(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptOQEquipment As New OQEquipmentList
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try
    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 2", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQEquipmentList")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")
    '        'PrintDocument1.Print()
    '        rptOQEquipment.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptOQEquipment.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptOQEquipment.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

    '        Else
    '            rptOQEquipment.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    'Public Function gfuncPrintPQEquipmentList(ByVal blnExport As Boolean, ByVal strFileName As String)
    '    Dim rptPQEquipment As New PQEquipmentList
    '    Dim objOleDBconnection As New OleDbConnection
    '    Try

    '        '--- Initialising Connection String
    '        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

    '        '--- Initialising Connection 
    '        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        'gobjDataSet = New dtsetExportAll

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQEquipmentList")

    '        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
    '        ' gobjDataSet = New dtsetCompletedBy

    '        '// Connect to, fetch data, and disconnect from database 
    '        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
    '        'PrintDocument1.Print()
    '        rptPQEquipment.SetDataSource(gobjDataSet)

    '        If blnExport = False Then
    '            rptPQEquipment.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
    '            rptPQEquipment.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
    '                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

    '        Else
    '            rptPQEquipment.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
    '        End If


    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function
    Public Function gfuncPrintCustomerDetails(ByVal blnExport As Boolean, ByVal strFileName As String)
        Dim rptCustomerDetail As New CustomerDetails
        'Dim objOleDBconnection As New OleDbConnection
        Dim intCount, intColCount As Integer
        Dim mobjDt As DataTable
        Try
            '--- Initialising Connection String
            'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)
            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerDetails where CustomerID = 1", objOleDBconnection)
            'gobjDataSet = New dtsetExportAll

            '// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "CustomerDetails")
            Dim objDrCDNewRow As dtsetExportAll.CustomerDetailsRow
            mobjDt = New DataTable
            mobjDt = gobjDataAccess.GetCustomerDetails()
            For intCount = 0 To mobjDt.Rows.Count - 1
                objDrCDNewRow = gobjDataSet.CustomerDetails.NewCustomerDetailsRow()
                For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
                    objDrCDNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
                Next
                gobjDataSet.CustomerDetails.AddCustomerDetailsRow(objDrCDNewRow)
            Next
            'gobjDataSet.Tables.Add(gobjDataAccess.GetCustomerDetails())
            'PrintDocument1.Print()
            rptCustomerDetail.SetDataSource(gobjDataSet)

            If blnExport = False Then
                rptCustomerDetail.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
                rptCustomerDetail.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

            Else
                rptCustomerDetail.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)

            End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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
    Public Function gfuncPrintWarranty(ByVal blnExport As Boolean, ByVal strFileName As String)
        Dim rptPQWarranty As New PQWarranty
        Dim objOleDBconnection As New OleDbConnection
        Try

            '--- Initialising Connection String
            'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

            '--- Initialising Connection 
            'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

            'gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
            'gobjDataSet = New dtsetExportAll

            '// Connect to, fetch data, and disconnect from database 
            'gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")

            'PrintDocument1.Print()
            rptPQWarranty.SetDataSource(gobjDataSet)

            If blnExport = False Then
                rptPQWarranty.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
                rptPQWarranty.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
                    gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
            Else
                rptPQWarranty.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
            End If

            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

#End Region

#Region "Message"
    '--- Enum for the Message types
    Public Enum EnumMessageType
        Information = 1
        Question = 2
        'NONE = "NONE"
    End Enum


    Public Function gfuncShowMessage(ByVal strMessageLabel As String, _
                        ByVal strMessage As String, _
                        ByVal MessageType As EnumMessageType) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gFuncShowMessage
        'Description	    :   to show the formated message 
        'Parameters 	    :   strMessageLabel and Message
        'Time/Date  	    :   12.41 11/01/04
        'Dependencies	    :   
        'Author		        :   
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim objfrmMessage As New frmMessage1
        Dim blnFalg As Boolean = False

        Try
            Return False
            objfrmMessage.lblMessage.Text = strMessage
            objfrmMessage.Text = strMessageLabel
            'objfrmMessage.lblMessageLabel.Text = strMessageLabel

            Select Case MessageType
                Case EnumMessageType.Information
                    objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0)
                    objfrmMessage.cmdOk.Visible = True
                    objfrmMessage.cmdYes.Visible = False
                    objfrmMessage.cmdNo.Visible = False
                    Application.DoEvents()
                    Application.DoEvents()
                    If objfrmMessage.ShowDialog() = DialogResult.OK Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If

                Case EnumMessageType.Question
                    objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1)
                    objfrmMessage.cmdOk.Visible = False
                    objfrmMessage.cmdYes.Visible = True
                    objfrmMessage.cmdNo.Visible = True

                    If objfrmMessage.ShowDialog = DialogResult.Yes Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If
            End Select
            Application.DoEvents()
            objfrmMessage.Dispose()
            objfrmMessage = Nothing
            Application.DoEvents()
            Return blnFalg

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

#End Region

#Region " Error Logs "

    Public Sub gsubErrorHandlerInitialization(ByRef objErrorHandlerIn As ErrorHandler.ErrorHandler)

        Try
            objErrorHandlerIn.CompanyName = Application.ProductName
            objErrorHandlerIn.ErrorLogFolder = "ErrorLogs"
            objErrorHandlerIn.ErrorLogFileName = Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder & "\ErrorLog-" & DateAndTime.DateString & "-" & DateAndTime.Hour(Now) & "-" & DateAndTime.Minute(Now) & "-" & DateAndTime.Second(Now) & ".log"
            objErrorHandlerIn.VersionMajor = Application.ProductVersion
            objErrorHandlerIn.ProductName = Application.ProductName

            objErrorHandlerIn.ExecutionTrailFolder = "ExecutionLogs"
            objErrorHandlerIn.ExecutionLogFileName = Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder & "\ExecutionLog-" & DateAndTime.DateString & "-" & DateAndTime.Hour(Now) & "-" & DateAndTime.Minute(Now) & "-" & DateAndTime.Second(Now) & ".log"

            '--- Check for the folders if not create the folders
            If Not Directory.Exists(Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder) Then
                '--- Create the folder
                Directory.CreateDirectory(Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder)
            End If

            If Not Directory.Exists(Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder) Then
                '--- Create the folder
                Directory.CreateDirectory(Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder)
            End If

        Catch ex As Exception
            'it is itself a routine for catch & hence showmessage is used
            gobjMessageAdapter.ShowMessage(ex.Message, "Error", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
        End Try

    End Sub

#End Region

    Public Function gfuncWordWrap(ByVal strFirst_ As String, ByVal Length As Integer) As String
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gfuncWordWrap
        'Description	    :   To apply wrapping on string 
        'Parameters 	    :   Wavelength 
        'Time/Date  	    :   15/03/2010
        'Dependencies	    :   
        'Author		        :   Amit
        'Revision		    :    Dinesh Wagh
        'Revision by Person	:   2.4.2010
        '--------------------------------------------------------------------------------------

        Try

            If strFirst_ = "" Then
                Return ""
            End If

            If Length = 0 Then
                Return strFirst_
            End If

            Dim arrStr() As String = strFirst_.Split(vbCrLf)
            Dim formatedstring As String = ""
            Dim singlestr As String
            Dim al As ArrayList
            Dim l As Integer = Length
            Dim StringWithWidth As String
            Dim StringWithFullWords As String

            For i As Integer = 0 To arrStr.Length - 1

                singlestr = arrStr(i)
                Dim chr() As Char
                al = New ArrayList
                While (singlestr.Length > 0)
                    chr = singlestr.ToCharArray
                    If singlestr.Length >= l + 1 Then
                        StringWithWidth = singlestr.Substring(0, l)
                        If chr(l) = " " Then
                            StringWithFullWords = StringWithWidth
                        Else
                            StringWithFullWords = Mid(StringWithWidth, 1, InStrRev(StringWithWidth, " ") - 1)
                        End If
                    Else
                        StringWithFullWords = singlestr
                    End If

                    al.Add(StringWithFullWords.Trim)
                    singlestr = singlestr.Substring(StringWithFullWords.Length, singlestr.Length - StringWithFullWords.Length)
                End While

                singlestr = ""

                singlestr = al(0)
                For j As Integer = 1 To al.Count - 1
                    singlestr = singlestr & vbCrLf & al(j)
                Next
                formatedstring &= singlestr & vbCrLf
            Next

            gfuncWordWrap = formatedstring
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gfuncWordWrap = ""
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function


End Module
