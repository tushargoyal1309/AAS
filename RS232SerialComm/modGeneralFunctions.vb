Option Explicit On 

Module modGeneralFunctions

#Region " General Functions "

    Public Function gFuncShowMessage(ByVal strMessageLabel As String, ByVal strMessage As String, ByVal MessageType As EnumMessageType) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gFuncShowMessage
        'Description	    :   to show the formated message 
        'Parameters 	    :   strMessageLabel and Message
        'Time/Date  	    :   12.41 11/01/04
        'Dependencies	    :   
        'Author		        :   Mandar
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim objfrmMessage As New frmMessage1
        Dim blnFalg As Boolean = False

        Try
            gFuncShowMessage = False
            objfrmMessage.lblMessage.Text = strMessage
            objfrmMessage.Text = strMessageLabel
            'objfrmMessage.lblMessageLabel.Text = strMessageLabel

            Select Case MessageType
                Case EnumMessageType.Information
                    objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0)
                    objfrmMessage.cmdOk.Visible = True
                    objfrmMessage.cmdYes.Visible = False
                    objfrmMessage.cmdNo.Visible = False
                    'Application.DoEvents()
                    'Application.DoEvents()
                    If objfrmMessage.ShowDialog() = objfrmMessage.DialogResult.OK Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If

                Case EnumMessageType.Question
                    objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1)
                    objfrmMessage.cmdOk.Visible = False
                    objfrmMessage.cmdYes.Visible = True
                    objfrmMessage.cmdNo.Visible = True

                    If objfrmMessage.ShowDialog = objfrmMessage.DialogResult.Yes Then
                        blnFalg = True
                    Else
                        blnFalg = False
                    End If
            End Select
            'Application.DoEvents()
            objfrmMessage.Dispose()
            objfrmMessage = Nothing
            'Application.DoEvents()
            gFuncShowMessage = blnFalg

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

#Region " .ini file Operations "

    '--- API declarations for reading the data from the INI file.
    Public Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" _
                    (ByVal strSection As String, ByVal strstring As String, ByVal lpdefault1 As String, ByVal lpreturnedstring1 As String, ByVal buffsize As Integer, ByVal lpfilename1 As String) As Long

    Public Function gFuncGetFromINI(ByVal strSection As String, ByVal strKeyValue As String, ByVal strDefaultString As String, _
       ByVal StrINIFilePath As String) As String
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncGetFromINI
        'Description:   To retrieve the key vale of a specified Section From INI
        'Parameters :   Section, Key , DefaultKeyValue, strFullPath of the INI
        'Time/Date  :   5/9/06
        'Dependencies:  INI File Should exist
        'Author:        Rahul B.
        'Revision: 
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Dim intBffer As Int32 = 255
        Dim strReturnString As String = Space(intBffer)
        gFuncGetFromINI = ""

        Try
            '--- To get the specified key value
            GetPrivateProfileString(Trim$(strSection), Trim$(strKeyValue), Trim$(strDefaultString), strReturnString, intBffer, Trim$(StrINIFilePath))
            strReturnString = CStr(Replace(Trim$(strReturnString), Chr(0), "") & "")
            gFuncGetFromINI = strReturnString

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
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

#End Region

End Module
