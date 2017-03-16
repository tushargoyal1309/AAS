'**********************************************************************
' File Header       :   clsMessageAdapter
' File Name 		:   clsMessageAdapter.vb
' Author			:   Mangesh Shardul
' Date/Time			:   13-Sep-2004 04:20 am
' Description		:   Class to provide the communication between application layer
'                       and MessageHandler Class (in DLL)
'                       To retrieve Messages from Database as per DataAccess Layer
'                       object defined in the Application Layer.
'Assumptions        :	All the messages are stored in the database.
'Dependencies       :   i.  Depends on DataAccessLayer class to retreive message
'                           from database. 
'                       ii. The global object of clsDataAccessLayer wiil be used.
'                       iii.An object of MessageHandler class 
'                           (Reference to Class Library of MessageHandler.dll)

'Properties         :   1.	mobjMessageHandler as MessageHandler.clsMessageHandler
'                       2.	
'                       3.	
'                       4.	


'Enumerated Constants/Structures:
'                       1.	
'                       2.	


'Functions:             1.	GetMessage (ByVal MessageID as Long) as DataRow
'                       2.	
'                       3.	
'                       4.  
'**********************************************************************
Option Explicit On 

Public Class clsMessageAdapter
    Implements IDisposable

#Region " Class Variables "

    '---Class Level object for Message Handling operations.
    Private mobjMessageHandler As MessageHandler.clsMessageHandler
    Private mobjStatusMessageBox As MessageHandler.frmMessage

#End Region

#Region " Public Functions "

    Public Sub New()
        mobjMessageHandler = New MessageHandler.clsMessageHandler
        mobjMessageHandler.MessageWindowCaption = "AAS203"
    End Sub

    Public Function GetMessage(ByVal lngMessageId As Long, ByRef objMessageHandlerIn As MessageHandler.clsMessageHandler) As Boolean
        '=====================================================================
        ' Procedure Name        : GetMessage
        ' Parameters Passed     : Unique Id of the message.
        ' Returns               : The Global Object of MessageHandler with Message Info
        ' Purpose               : To retrieve the message from database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : Global Object of MessageHandler
        ' Author                : Mangesh Shardul
        ' Created               : 13-Sep-2004 05:00 pm
        ' Revisions             : 
        '=====================================================================
        Dim objMessageDataRow As DataRow
        Try
            '=====================================================================
            ' Description explaning the steps followed: 
            ' 1. using global object of clsDataAccessLayer get the message data
            '    from database
            ' 2. return the DataRow for that found Message ID
            ' 3. Pass this DataRow to MessageHandler class' GetMessage
            ' 4. Return the global object of MessageHandler with Message Info.
            '=====================================================================
            objMessageDataRow = gobjDataAccess.GetMessage(lngMessageId)

            Call objMessageHandlerIn.GetMessage(objMessageDataRow, objMessageHandlerIn)

            Return True

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

    Public Function ShowMessage(ByVal lngMessageID As Long) As Boolean
        '=====================================================================
        ' Procedure Name        : ShowMessage
        ' Parameters Passed     : Unique Id of the message.
        ' Returns               : Displays the Message Form with Message
        '                         and returns DialogResult
        ' Purpose               : To show the message stored in database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : Global Object of MessageHandler
        ' Author                : Mangesh Shardul
        ' Created               : 03-Oct-2004 02:30 pm
        ' Revisions             : 1
        '=====================================================================
        Dim strMessageTitle As String
        Dim strMessageText As String
        Dim enumMessageType As MessageHandler.clsMessageHandler.enumMessageType

        Try
            mobjMessageHandler.ApplicationPath = Application.StartupPath

            Call Me.GetMessage(lngMessageID, mobjMessageHandler)

            strMessageTitle = mobjMessageHandler.MessageTitle
            strMessageText = mobjMessageHandler.MessageText
            enumMessageType = mobjMessageHandler.MessageType

            If mobjMessageHandler.ShowMessage(strMessageTitle, strMessageText, enumMessageType) Then
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

    Public Function ShowMessage(ByVal MessageText As String, ByVal MessageTitle As String, _
                                ByVal enumMessageType As MessageHandler.clsMessageHandler.enumMessageType) As Boolean
        '=====================================================================
        ' Procedure Name        : ShowMessage
        ' Parameters Passed     : User-Defined Message String and Title.
        ' Returns               : Displays the Message Form with Message
        '                         and returns DialogResult
        ' Purpose               : To show the message stored in database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : Global Object of MessageHandler
        ' Author                : Mangesh Shardul
        ' Created               : 03-Oct-2006 12:20 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If mobjMessageHandler.ShowMessage(MessageTitle, MessageText, enumMessageType) Then
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


    'Public Function ShowStatusMessageBox(ByVal strMessageText As String, ByVal strMessageTitle As String, _
    '                        ByVal intMessageType As MessageHandler.clsMessageHandler.enumMessageType, _
    '                        ByVal intWaitForMilliSeconds As Integer) As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : ShowStatusMessageBox
    '    ' Parameters Passed     : User-Defined Message String and Title.
    '    ' Returns               : Displays the Message Form with Message
    '    '                         and returns DialogResult
    '    ' Purpose               : To show the message stored in database.
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : Global Object of MessageHandler
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 03-Oct-2006 12:20 pm
    '    ' Revisions             : 1
    '    '=====================================================================
    '    Try
    '        mobjStatusMessageBox = mobjMessageHandler.ShowStatusMessageBox(strMessageText, strMessageTitle, intMessageType)

    '        gobjclsTimer = New clsTimer(Nothing, intWaitForMilliSeconds)

    '        mobjStatusMessageBox.Show()

    '        Call gobjclsTimer.subTime_Delay(intWaitForMilliSeconds)

    '        Return True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
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

    'Public Sub CloseStatusMessageBox()
    '    Call mobjMessageHandler.CloseStatusMessageBox(mobjStatusMessageBox)
    'End Sub

#End Region

#Region " Private functions "

    Private Function SaveMessage(ByVal lngMessageID As Long, ByVal strMessageType As String, ByVal strMessageTitle As String, _
                                ByVal strMessageText As String, ByVal intModuleID As Integer, _
                                ByVal strFilename As String) As Boolean
        '=====================================================================
        ' Procedure Name        : SaveMessage
        ' Parameters Passed     : Message Id, Title of the message, Message Text, 
        '                         Id of the Module, File name
        ' Returns               : True if successful; false otherwise 
        ' Purpose               : To save the message in the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 12-Sep-2004 12:30 pm
        ' Revisions             : 
        '=====================================================================
        Try
            If gobjDataAccess.SaveMessageInfo(lngMessageID, strMessageTitle, strMessageText, intModuleID, strMessageType, strFilename) Then
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


    Private Function SaveMessageObject(ByVal objMessageInfoIn As MessageHandler.clsMessageHandler) As Boolean
        '=====================================================================
        ' Procedure Name        : SaveMessageObject
        ' Parameters Passed     : An object of MessageHandler Class
        ' Returns               : True if successful; false otherwise 
        ' Purpose               : To save the message info in the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 12-Sep-2004 03:30 pm
        ' Revisions             : 
        '=====================================================================
        Dim lngMsgId As Long
        Dim strMsgTitle As String
        Dim strMsgText As String
        Dim intMode As Integer
        Dim intMsgType As Integer
        Dim strVBFileName As String = ""

        Try
            lngMsgId = objMessageInfoIn.MessageID
            strMsgTitle = objMessageInfoIn.MessageTitle
            strMsgText = objMessageInfoIn.MessageText
            intMode = objMessageInfoIn.ModuleID
            intMsgType = objMessageInfoIn.MessageType
            strVBFileName = objMessageInfoIn.FileName

            If gobjDataAccess.SaveMessageInfo(lngMsgId, strMsgTitle, strMsgText, intMode, intMsgType, strVBFileName) Then
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


    Private Function SaveErrorMessage(ByVal lngErrNum As Long, _
                             ByVal strErrDesc As String) As Boolean
        '=====================================================================
        ' Procedure Name        : SaveErrorMessage
        ' Parameters Passed     : Error No, Error Description
        ' Returns               : True if successful; false otherwise 
        ' Purpose               : To save the Error No and their Descriptions in the database.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Sep-2004 3:30 pm
        ' Revisions             : 
        '=====================================================================

        Dim ConnStatus As Boolean
        Dim strQuery As String
        Dim IniDataList As New DataTable

        Try
            gobjDataAccess.SaveErrorInfo(lngErrNum, strErrDesc)

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
        End Try

    End Function

#End Region

#Region " Dispose And Garbage Collection Code "

    Private Handle As IntPtr
    'Other managed resource this class uses.
    'Private component As New component
    ' Track whether Dispose has been called.
    Private disposed As Boolean = False

    Public Overloads Sub Dispose() Implements System.IDisposable.Dispose
        '**********************************************************************
        ' Procedure Name 	: Dispose
        ' Author			: Mangesh Shardul
        ' Date/Time			: 02-Nov-2004 01:20 pm
        ' Description		: To dispose the objects this class instance
        '**********************************************************************
        Call Dispose(True)
        ' This object will be cleaned up by the Dispose method.
        ' Therefore, you should call GC.SupressFinalize to
        ' take this object off the finalization queue 
        ' and prevent finalization code for this object
        ' from executing a second time.
        GC.SuppressFinalize(Me)
    End Sub

    ' Dispose(bool disposing) executes in two distinct scenarios.
    ' If disposing equals true, the method has been called directly
    ' or indirectly by a user's code. Managed and unmanaged resources
    ' can be disposed.
    ' If disposing equals false, the method has been called by the 
    ' runtime from inside the finalizer and you should not reference 
    ' other objects. Only unmanaged resources can be disposed.
    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        ' Check to see if Dispose has already been called.
        If Not Me.disposed Then
            ' If disposing equals true, dispose all managed 
            ' and unmanaged resources.
            If disposing Then
                ' Dispose managed resources.
                If Not IsNothing(mobjMessageHandler) Then
                    mobjMessageHandler.Dispose()
                    mobjMessageHandler = Nothing
                End If
            End If

            ' Call the appropriate methods to clean up 
            ' unmanaged resources here.
            ' If disposing is false, 
            ' only the following code is executed.
            CloseHandle(Handle)
            Handle = IntPtr.Zero
        End If
        disposed = True

    End Sub

    <System.Runtime.InteropServices.DllImport("Kernel32")> _
    Private Shared Function CloseHandle(ByVal handle As IntPtr) As [Boolean]
    End Function

    ' This finalizer will run only if the Dispose method 
    ' does not get called.
    ' It gives your base class the opportunity to finalize.
    ' Do not provide finalize methods in types derived from this class.
    Protected Overrides Sub Finalize()
        ' Do not re-create Dispose clean-up code here.
        ' Calling Dispose(false) is optimal in terms of
        ' readability and maintainability.
        Dispose(False)
        MyBase.Finalize()
    End Sub

#End Region

End Class
