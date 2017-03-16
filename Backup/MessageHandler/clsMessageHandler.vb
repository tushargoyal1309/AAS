'**********************************************************************
' File Header       :   clsMessageHandler
' File Name 		:   clsMessageHandler.vb
' Author			:   Mangesh Shardul
' Date/Time			:   12-Sep-2004 8:00 pm
' Description		:   Class to provide the common messages to different
'                       application modes and different files. 
'                       All the messages and their types are stored in 
'                       one central location (database) and they retrieved 
'                       by their respective message ids
'Assumptions        :	All the messages are stored in the database.
'Dependencies       :   

'Properties         :   1.	MessageID as Long
'                       2.	ModuleID as Integer
'                       3.	MessageType as enumMessageType
'                       4.	MessageTitle as String
'                       5.	MessageText as String
'                       6.	FileName as String
'                       7.	ErrorNumber as long

'Enumerated Constants/Structures:
'                       1.	EnumMessageType
'                       2.	


'Functions:             1.	GetMessage (ByVal MessageID as Long) as DataRow
'                       2.  ShowMessage(MessageTitle,MessageText,MessageType) as Boolean
'                       2.	GetMessageType (ByVal MessageID as Long) as String
'                       3.	SaveMessage (ByVal MessageType, ByVal MessageTitle as String, ByVal MessageText as String, ModuleID as integer, ByVal Filename as String) as Boolean
'                       4.  GetMessageByErrorNumber (ByVal ErrorNumber as long, ByVal MessageID as Long) as DataRow
'**********************************************************************
Option Explicit On 

<Serializable()> Public Class clsMessageHandler
    Implements IDisposable

#Region " Enumerated Constants "

    Enum enumMessageType
        InformativeMessage = 1
        WarningMessage = 2
        QuestionMessage = 3
        ErrorMessage = 4
        SystemMessage = 5
        UnExpectedMessage = 6
    End Enum

#End Region

#Region " Class Variables "

    Private mMessageID As Long
    Private mModuleID As Integer
    Private mMessageType As enumMessageType
    Private mMessageTitle As String
    Private mMessageText As String
    Private mFileName As String
    Private mApplicationPath As String

    Private mintMessageTextAlignment As Drawing.ContentAlignment

    Public MessageWindowCaption As String = "Color Analysis"

#End Region

#Region " Public Properties "

    Public Property MessageID() As Long
        Get
            Return mMessageID
        End Get
        Set(ByVal Value As Long)
            mMessageID = Value
        End Set
    End Property

    Public Property ModuleID() As Integer
        Get
            Return mModuleID
        End Get
        Set(ByVal Value As Integer)
            mModuleID = Value
        End Set
    End Property

    Public Property MessageType() As enumMessageType
        Get
            Return mMessageType
        End Get
        Set(ByVal Value As enumMessageType)
            mMessageType = Value
        End Set
    End Property

    Public Property MessageTitle() As String
        Get
            Return mMessageTitle
        End Get
        Set(ByVal Value As String)
            mMessageTitle = Value
        End Set
    End Property

    Public Property MessageText() As String
        Get
            Return mMessageText
        End Get
        Set(ByVal Value As String)
            mMessageText = Value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return mFileName
        End Get
        Set(ByVal Value As String)
            mFileName = Value
        End Set
    End Property

    Public Property ApplicationPath() As String
        Get
            Return mApplicationPath
        End Get
        Set(ByVal Value As String)
            mApplicationPath = Value
        End Set
    End Property

    Public Property MessageTextAlignment() As Drawing.ContentAlignment
        Get
            Return mintMessageTextAlignment
        End Get
        Set(ByVal Value As Drawing.ContentAlignment)
            mintMessageTextAlignment = Value
        End Set
    End Property

#End Region

#Region " Public Functions "

    Public Sub New()
        MyBase.new()
        InitializeSetting()
        mintMessageTextAlignment = Drawing.ContentAlignment.MiddleCenter
    End Sub

    Public Sub New(ByVal lngMsgId As Long, _
                               ByVal strMsgTitle As String, _
                               ByVal strMsgText As String, _
                               ByVal intMode As Integer, _
                               ByVal strMsgType As String, _
                               ByVal strFileName As String)
        '=====================================================================
        ' Procedure Name        : New [Constructor]
        ' Parameters Passed     : Unique Id of the message.
        ' Returns               : Row containing all Message properties
        ' Purpose               : To retrieve the message from Message Class Object.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 12-Sep-2004 08:30 pm
        ' Revisions             : 
        '=====================================================================
        Try
            InitializeSetting()

            Me.MessageID = lngMsgId
            Me.MessageTitle = strMsgTitle
            Me.MessageText = strMsgText
            Me.ModuleID = intMode
            Me.FileName = strFileName

            mintMessageTextAlignment = Drawing.ContentAlignment.MiddleCenter

            Me.MessageType = funFindMessageTypeNo(strMsgType)

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

    Public Function GetMessage(ByVal objDtRowMessage As DataRow, ByRef objMessageHandlerIn As clsMessageHandler) As Boolean
        '=====================================================================
        ' Procedure Name        : GetMessage
        ' Parameters Passed     : DataRow containing Message Info 
        ' Returns               : An object of MessageHandler with all properties set
        ' Purpose               : To get the message info
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 12-Sep-2004 09:00 pm
        ' Revisions             : 
        '=====================================================================

        '=====================================================================
        ' Description explaning the steps followed: 
        ' 1. Accept DataRow containing Message data which would had been filled
        '    in the MessageAdapter Class from DataBase.
        ' 2. Check the DataRow contains proper values.
        ' 3. Construct an object of MessageHandler.
        ' 4. Return this object to calling function.
        '=====================================================================
        Dim lngMsgId As Long
        Dim intMode As Integer
        'Dim intMsgType As Integer
        Dim strMsgType As String
        Dim strMsgTitle As String
        Dim strMsgText As String
        Dim strFileName As String

        Try
            ' 1. Accept DataRow containing Message data which would had been filled
            '    in the MessageAdapter Class from DataBase.
            ' 2. Check the DataRow contains proper values.
            If Not objDtRowMessage.IsNull("MessageID") Then
                lngMsgId = objDtRowMessage.Item("MessageID")
            Else
                Throw New Exception("The Field MessageID in Table MessageInfo is Null.")
            End If

            If Not objDtRowMessage.IsNull("ModuleID") Then
                intMode = objDtRowMessage.Item("ModuleID")
            Else
                Throw New Exception("The field ModuleID in Table MessageInfo is Null.")
            End If

            If Not objDtRowMessage.IsNull("MessageType") Then
                strMsgType = objDtRowMessage.Item("MessageType")
            Else
                Throw New Exception("The field MessageType in Table MessageInfo is Null.")
            End If

            If Not objDtRowMessage.IsNull("MessageTitle") Then
                strMsgTitle = objDtRowMessage.Item("MessageTitle")
            Else
                Throw New Exception("The field MessageTitle in Table MessageInfo is Null.")
            End If

            If Not objDtRowMessage.IsNull("MessageText") Then
                strMsgText = objDtRowMessage.Item("MessageText")
            Else
                Throw New Exception("The field MessageText in Table MessageInfo is Null.")
            End If

            If Not objDtRowMessage.IsNull("FileName") Then
                strFileName = objDtRowMessage.Item("FileName")
            Else
                Throw New Exception("The field FileName in Table MessageInfo is Null.")
            End If

            ' 3. Construct an object of MessageHandler.
            ''Dim objMessageHandler As clsMessageHandler
            ''objMessageHandlerIn = New clsMessageHandler(lngMsgId, strMsgTitle, strMsgText, intMode, strMsgType, strFileName)
            objMessageHandlerIn.MessageID = lngMsgId
            objMessageHandlerIn.MessageTitle = strMsgTitle
            objMessageHandlerIn.MessageText = strMsgText
            objMessageHandlerIn.ModuleID = intMode
            objMessageHandlerIn.MessageType = funFindMessageTypeNo(strMsgType)
            objMessageHandlerIn.FileName = strFileName

            ' 4. Return this object to calling function.
            Return True

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

    Public Function ShowMessage(ByVal strMessageTitle As String, _
                                 ByVal strMessageText As String, _
                                 ByVal MessageType As enumMessageType, Optional ByVal IsSmallMessageRequired As Boolean = False, Optional ByVal IsOkAndCancelButtonsRequired As Boolean = False) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   ShowMessage
        'Description	    :   To show the formated message 
        'Parameters 	    :   MessageTitle, MessageText, MessageType
        'Time/Date  	    :   13-Sep-2004 08:00 pm
        'Dependencies	    :   
        'Author		        :   Mangesh Shardul
        'Revision		    :   1
        '--------------------------------------------------------------------------------------
        Dim blnFalg As Boolean = False
        Dim objfrmMessage As frmMessage

        Try
            objfrmMessage = New frmMessage

            If IsOkAndCancelButtonsRequired = True Then
                objfrmMessage.cmdyes.Text = "OK"
                objfrmMessage.cmdno.Text = "Cancel"
            End If
            '***********************************************************
            'Changed by saurabh for adding control box on message handler form.
            'objfrmMessage.Office2003Header.TitleText = MessageWindowCaption 
            objfrmMessage.Text = MessageWindowCaption       'Saurabh on 29 May 2007
            '***********************************************************

            If IsSmallMessageRequired = False Then
                objfrmMessage.lblMessage.TextAlign = Me.MessageTextAlignment
            Else
                objfrmMessage.lblMessage.TextAlign = Drawing.ContentAlignment.MiddleCenter
                objfrmMessage.Width = 350
                objfrmMessage.Height = 150
                objfrmMessage.lblMessage.Width = 270
            End If


            objfrmMessage.lblMessage.Text = strMessageText
            objfrmMessage.Office2003HeaderSubMessage.TitleText = strMessageTitle

            'objfrmMessage.CustomPanelBackground.BringToFront()
            'objfrmMessage.Office2003Header.SendToBack()

            If IsNothing(objfrmMessage.ImgLstMessage) = False Then
                If objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                    Call subLoadImages(objfrmMessage.ImgLstMessage)
                End If
            Else
                objfrmMessage.ImgLstMessage = New Windows.Forms.ImageList
            End If

            Select Case MessageType
                Case enumMessageType.InformativeMessage
                    '=====================================================================
                    ' Case For INFORMATIVE Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0)
                    End If
                    objfrmMessage.cmdok.Visible = True
                    objfrmMessage.cmdyes.Visible = False
                    objfrmMessage.cmdno.Visible = False

                    If objfrmMessage.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If

                    '=====================================================================

                Case enumMessageType.WarningMessage
                    '=====================================================================
                    ' Case For WARNING Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1)
                    End If
                    objfrmMessage.cmdok.Visible = True
                    objfrmMessage.cmdyes.Visible = False
                    objfrmMessage.cmdno.Visible = False

                    If objfrmMessage.ShowDialog = Windows.Forms.DialogResult.OK Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If
                    '=====================================================================

                Case enumMessageType.QuestionMessage
                    '=====================================================================
                    ' Case For QUESTION Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(2)
                    End If
                    objfrmMessage.cmdok.Visible = False
                    objfrmMessage.cmdyes.Visible = True
                    objfrmMessage.cmdno.Visible = True

                    If objfrmMessage.ShowDialog = Windows.Forms.DialogResult.Yes Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If
                    '=====================================================================

                Case enumMessageType.ErrorMessage
                    '=====================================================================
                    ' Case For ERROR Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(3)
                    End If
                    objfrmMessage.cmdok.Visible = True
                    objfrmMessage.cmdyes.Visible = False
                    objfrmMessage.cmdno.Visible = False

                    If objfrmMessage.ShowDialog = Windows.Forms.DialogResult.OK Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If
                    '=====================================================================

                Case enumMessageType.SystemMessage
                    '=====================================================================
                    ' Case For SYSTEM (O.S.) Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(4)
                    End If
                    objfrmMessage.cmdok.Visible = True
                    objfrmMessage.cmdyes.Visible = False
                    objfrmMessage.cmdno.Visible = False

                    If objfrmMessage.ShowDialog = Windows.Forms.DialogResult.OK Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If
                    '=====================================================================

                Case enumMessageType.UnExpectedMessage
                    '=====================================================================
                    ' Case For UNEXPECTED Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(5)
                    End If
                    objfrmMessage.cmdok.Visible = True
                    objfrmMessage.cmdyes.Visible = False
                    objfrmMessage.cmdno.Visible = False

                    If objfrmMessage.ShowDialog = Windows.Forms.DialogResult.OK Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If
                    '=====================================================================
            End Select

            objfrmMessage.Dispose()
            objfrmMessage = Nothing

            Return blnFalg

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
    End Function

    Public Function ShowStatusMessageBox(ByVal strMessageText As String, ByVal strMessageTitle As String, _
                         ByVal intMessageType As MessageHandler.clsMessageHandler.enumMessageType, Optional ByVal IsSmallMessageRequired As Boolean = False) As frmMessage
        '-----------------------------------------------------------------
        'Procedure Name	    :   ShowStatusMessageBox
        'Description	    :   To allow message window to auto close
        'Parameters 	    :   true or false
        'Time/Date  	    :   24-Dec-2006 02:30 pm
        'Dependencies	    :   
        'Author		        :   Mangesh Shardul
        'Revision		    :   1
        '-----------------------------------------------------------------
        Dim objfrmMessage As frmMessage

        Try
            objfrmMessage = New frmMessage

            'objfrmMessage.lblMessage.TextAlign = Me.MessageTextAlignment
            If IsSmallMessageRequired = False Then
                objfrmMessage.lblMessage.TextAlign = Me.MessageTextAlignment
            Else
                objfrmMessage.lblMessage.TextAlign = Drawing.ContentAlignment.MiddleCenter
                objfrmMessage.Width = 350
                objfrmMessage.Height = 150
                objfrmMessage.lblMessage.Width = 270
            End If

            objfrmMessage.lblMessage.Text = strMessageText

            'objfrmMessage.Office2003Header.TitleText = MessageWindowCaption

            objfrmMessage.Office2003HeaderSubMessage.TitleText = strMessageTitle

            'objfrmMessage.CustomPanelBackground.BringToFront()
            'objfrmMessage.Office2003Header.SendToBack()

            If IsNothing(objfrmMessage.ImgLstMessage) = False Then
                If objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                    Call subLoadImages(objfrmMessage.ImgLstMessage)
                End If
            Else
                objfrmMessage.ImgLstMessage = New Windows.Forms.ImageList
            End If

            objfrmMessage.cmdok.Visible = False
            objfrmMessage.cmdyes.Visible = False
            objfrmMessage.cmdno.Visible = False

            Select Case intMessageType
                Case enumMessageType.InformativeMessage
                    '=====================================================================
                    ' Case For INFORMATIVE Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0)
                    End If
                    '=====================================================================

                Case enumMessageType.WarningMessage
                    '=====================================================================
                    ' Case For WARNING Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1)
                    End If
                    '=====================================================================

                Case enumMessageType.QuestionMessage
                    '=====================================================================
                    ' Case For QUESTION Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(2)
                    End If
                    '=====================================================================

                Case enumMessageType.ErrorMessage
                    '=====================================================================
                    ' Case For ERROR Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(3)
                    End If
                    '=====================================================================

                Case enumMessageType.SystemMessage
                    '=====================================================================
                    ' Case For SYSTEM (O.S.) Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(4)
                    End If
                    '=====================================================================

                Case enumMessageType.UnExpectedMessage
                    '=====================================================================
                    ' Case For UNEXPECTED Message Type
                    '=====================================================================
                    If Not objfrmMessage.ImgLstMessage.Images.Count = 0 Then
                        objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(5)
                    End If
                    '=====================================================================
            End Select

            Return objfrmMessage

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
    End Function

    Public Sub CloseStatusMessageBox(ByVal objfrmMessage As frmMessage)
        If Not IsNothing(objfrmMessage) Then
            objfrmMessage.Close()
            objfrmMessage.Dispose()
            objfrmMessage = Nothing
        End If
    End Sub

    Public Sub UpdateStatusMessageBox(ByRef objfrmMessage As frmMessage, ByVal strNewMessage As String, ByVal strNewCaption As String)
        '=====================================================================
        ' Procedure Name        : UpdateStatusMessageBox
        ' Parameters Passed     : New Message Text and Caption
        ' Returns               : None
        ' Purpose               : To update the Message Text of a Status MsgBox
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 25-Jan-2007 03:40 pm
        ' Revisions             : 1
        '=====================================================================
        Try
            If Not IsNothing(objfrmMessage) Then
                objfrmMessage.lblMessage.Text = strNewMessage
                objfrmMessage.Office2003HeaderSubMessage.TitleText = strNewCaption

                objfrmMessage.lblMessage.Refresh()
                objfrmMessage.Office2003HeaderSubMessage.Refresh()
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
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region " Private functions "

    Private Function funFindMessageTypeNo(ByVal strMsgTypeIn As String) As Integer
        Dim intMsgTypeNumber As Integer

        Select Case strMsgTypeIn
            Case "InformativeMessage"
                intMsgTypeNumber = 1

            Case "WarningMessage"
                intMsgTypeNumber = 2

            Case "QuestionMessage"
                intMsgTypeNumber = 3

            Case "ErrorMessage"
                intMsgTypeNumber = 4

            Case "SystemMessage"
                intMsgTypeNumber = 5

            Case "UnExpectedMessage"
                intMsgTypeNumber = 6

        End Select

        Return intMsgTypeNumber

    End Function

    Private Sub subLoadImages(ByRef ImgLstMessage As Windows.Forms.ImageList)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   funcLoadImages
        'Description	    :   to load the bitmap as Icons in MessageBox form
        'Parameters 	    :   None
        'Time/Date  	    :   03-Oct-2004 04:15
        'Dependencies	    :   
        'Author		        :   Mangesh Shardul
        'Revision		    :   
        'Revision by Person	:   
        '--------------------------------------------------------------------------------------
        Dim strFilePath As String
        Dim objIconInfo As Drawing.Icon
        Dim objIconWarn As Drawing.Icon
        Dim objIconQue As Drawing.Icon
        Dim objIconErr As Drawing.Icon
        Dim objIconSys As Drawing.Icon
        Dim objIconUnex As Drawing.Icon

        Try
            strFilePath = mApplicationPath & "\MessageHandler"

            objIconInfo = New Drawing.Icon(strFilePath & "\MSGBOX04.ico")
            objIconWarn = New Drawing.Icon(strFilePath & "\MSGBOX01.ico")
            objIconQue = New Drawing.Icon(strFilePath & "\MSGBOX02.ico")
            objIconErr = New Drawing.Icon(strFilePath & "\MSGBOX03.ico")
            objIconSys = New Drawing.Icon(strFilePath & "\W95MBX01.ico")
            objIconUnex = New Drawing.Icon(strFilePath & "\W95MBX01.ico")

            ImgLstMessage.Images.Clear()
            ImgLstMessage.Images.Add(objIconInfo)
            ImgLstMessage.Images.Add(objIconWarn)
            ImgLstMessage.Images.Add(objIconQue)
            ImgLstMessage.Images.Add(objIconErr)
            ImgLstMessage.Images.Add(objIconSys)
            ImgLstMessage.Images.Add(objIconUnex)

            Return

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

#Region " Commented Code "

    '''    Public Function SaveMessage(ByVal lngMessageID As Long, ByVal strMessageType As String, ByVal strMessageTitle As String, _
    '''                                ByVal strMessageText As String, ByVal intModuleID As Integer, _
    '''                                ByVal strFilename As String) As Boolean
    '''        '=====================================================================
    '''        ' Procedure Name        : SaveMessage
    '''        ' Parameters Passed     : Message Id, Title of the message, Message Text, 
    '''        '                         Id of the Module, File name
    '''        ' Returns               : True if successful; false otherwise 
    '''        ' Purpose               : To save the message in the database.
    '''        ' Description           : 
    '''        ' Assumptions           : 
    '''        ' Dependencies          : 
    '''        ' Author                : Mangesh Shardul
    '''        ' Created               : 12-Sep-2004 12:30 pm
    '''        ' Revisions             : 
    '''        '=====================================================================
    '''        Try
    '''            'If gobjDataAccess.SaveMessageInfo(lngMessageID, strMessageTitle, strMessageText, intModuleID, strMessageType) Then
    '''            '    Return True
    '''            'Else
    '''            '    Return False
    '''            'End If

    '''        Catch ex As Exception
    '''            '---------------------------------------------------------
    '''            'Error Handling and logging
    '''            gobjErrorHandler.ErrorDescription = ex.Message
    '''            gobjErrorHandler.ErrorMessage = ex.Message
    '''            gobjErrorHandler.WriteErrorLog(ex)
    '''            '---------------------------------------------------------
    '''            Return False
    '''        Finally
    '''            '---------------------------------------------------------
    '''            'Writing Execution log
    '''            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '''                gobjErrorHandler.WriteExecutionLog()
    '''            End If
    '''            '---------------------------------------------------------
    '''        End Try

    '''    End Function

    '''    Public Function SaveMessageObject(ByVal objMessageInfoIn As clsMessageHandler) As Boolean
    '''        '=====================================================================
    '''        ' Procedure Name        : SaveMessageObject
    '''        ' Parameters Passed     : An object of MessageHandler Class
    '''        ' Returns               : True if successful; false otherwise 
    '''        ' Purpose               : To save the message info in the database.
    '''        ' Description           : 
    '''        ' Assumptions           : 
    '''        ' Dependencies          : 
    '''        ' Author                : Mangesh Shardul
    '''        ' Created               : 12-Sep-2004 03:30 pm
    '''        ' Revisions             : 
    '''        '=====================================================================
    '''        Dim lngMsgId As Long
    '''        Dim strMsgTitle As String
    '''        Dim strMsgText As String
    '''        Dim intMode As Integer
    '''        Dim intMsgType As Integer

    '''        Try
    '''            lngMsgId = objMessageInfoIn.MessageID
    '''            strMsgTitle = objMessageInfoIn.MessageTitle
    '''            strMsgText = objMessageInfoIn.MessageText
    '''            intMode = objMessageInfoIn.ModuleID
    '''            intMsgType = objMessageInfoIn.MessageType

    '''            'If gobjDataAccess.SaveMessageInfo(lngMsgId, strMsgTitle, strMsgText, intMode, intMsgType) Then
    '''            '    Return True
    '''            'Else
    '''            '    Return False
    '''            'End If

    '''        Catch ex As Exception
    '''            '---------------------------------------------------------
    '''            'Error Handling and logging
    '''            gobjErrorHandler.ErrorDescription = ex.Message
    '''            gobjErrorHandler.ErrorMessage = ex.Message
    '''            gobjErrorHandler.WriteErrorLog(ex)
    '''            '---------------------------------------------------------
    '''            Return False
    '''        Finally
    '''            '---------------------------------------------------------
    '''            'Writing Execution log
    '''            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '''                gobjErrorHandler.WriteExecutionLog()
    '''            End If
    '''            '---------------------------------------------------------
    '''        End Try

    '''    End Function

    '''    Public Function SaveErrorMessage(ByVal lngErrNum As Long, _
    '''                             ByVal strErrDesc As String) As Boolean
    '''        '=====================================================================
    '''        ' Procedure Name        : SaveErrorMessage
    '''        ' Parameters Passed     : Error No, Error Description
    '''        ' Returns               : True if successful; false otherwise 
    '''        ' Purpose               : To save the Error No and their Descriptions in the database.
    '''        ' Description           : 
    '''        ' Assumptions           : 
    '''        ' Dependencies          : 
    '''        ' Author                : Mangesh Shardul
    '''        ' Created               : 10-Sep-2004 3:30 pm
    '''        ' Revisions             : 
    '''        '=====================================================================

    '''        Dim ConnStatus As Boolean
    '''        Dim strQuery As String
    '''        Dim IniDataList As New DataTable

    '''        Try
    '''            'gobjDataAccess.SaveErrorInfo(lngErrNum, strErrDesc)

    '''        Catch ex As Exception
    '''            '---------------------------------------------------------
    '''            'Error Handling and logging
    '''            gobjErrorHandler.ErrorDescription = ex.Message
    '''            gobjErrorHandler.ErrorMessage = ex.Message
    '''            gobjErrorHandler.WriteErrorLog(ex)
    '''            '---------------------------------------------------------
    '''            Return Nothing
    '''        Finally
    '''            '---------------------------------------------------------
    '''            'Writing Execution log
    '''            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '''                gobjErrorHandler.WriteExecutionLog()
    '''            End If
    '''            '---------------------------------------------------------
    '''        End Try

    '''    End Function

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
        ' Date/Time			: 02-Nov-2004 01:25 pm
        ' Description		: To dispose the objects this class instance
        '**********************************************************************
        Call Dispose(True)

        ' This object will be cleaned up by the Dispose method.
        ' Therefore, you should call GC.SupressFinalize to
        ' take this object off the finalization queue 
        ' and prevent finalization code for this object
        ' from executing a second time.
        Call GC.SuppressFinalize(Me)

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
