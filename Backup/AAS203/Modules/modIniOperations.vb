Option Explicit On 
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices

Module modIniOperations

    '--- Constant for the INI file name
    Public CONST_AAS_INI_FileName As String = IO.Path.GetFullPath("AAS.ini")

    '--- Constant for AutoSampler ini file name
    Public CONST_AutoSampler_INI_FileName As String = IO.Path.GetFullPath("asampler.ini")

    '--- Constant for the sections and keys in the INI file.
    '--- Spectrum Mode Parameters
    Public Const CONST_Section_Parameters As String = "Parameters"

    Const CONST_Key_AnalysisDate = "AnalysisDate"
    Const CONST_Key_Cal_Mode = "Cal_Mode"
    Const CONST_Key_Comments = "Comments"
    Const CONST_Key_D2Curr = "D2Curr"
    Const CONST_Key_PMTV = "PMTV"
    Const CONST_Key_ScanSpeed = "ScanSpeed"
    Const CONST_Key_SlitWidth = "SlitWidth"
    Const CONST_Key_SpectrumName = "SpectrumName"
    Const CONST_Key_XaxisMax = "XaxisMax"
    Const CONST_Key_XaxisMin = "XaxisMin"
    Const CONST_Key_YaxisMax = "YaxisMax"
    Const CONST_Key_YaxisMin = "YaxisMin"
    Const CONST_Key_BurnerHeight = "BurnerHeight"
    Const CONST_Key_FualRatio = "FualRatio"
    Const CONST_Key_LampTurrNo = "LampTurrNo"
    Const CONST_Key_LampEle = "LampEle"
    Const CONST_Key_HCLCurr = "HCLCurr"

    '---Constants for AutoSampler ini Sections and Keys
    '"AutoSampler", "Wash Time (sec)"
    Public Const CONST_Section_AutoSampler = "AutoSampler"
    Public Const CONST_Key_WashTime = "Wash Time (sec)"



    '***************Modified By Saurabh on (04-01-2007)******************
    '--- Enable 21CFR
    Public Const CONST_Section_21CFR As String = "21CFR"
    Public Const CONST_Key_Enable21CFR As String = "Enable21CFR"
    Public Const CONST_Key_SessionID As String = "SessionID"

    '--- Printer type
    Public Const CONST_Section_PRINTERTYPE As String = "PRINTERTYPE"
    Public Const CONST_Key_ColorPrinter As String = "ColorPrinter"

    '--- Printer type
    Public Const CONST_Section_LOGIN As String = "LOGIN"
    Public Const CONST_Key_USERID As String = "User"

    Public Function gfuncGetSessionIDFromINI(ByRef lngSessionid As Long) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetSessionIDFromINI
        ' Description           :   Get the Session ID parameter values from the 
        '                           INI file using the API calls to read the INI
        '                           file and assign it to a Session ID variable 
        '                           passed as a ref to the function.
        ' Purpose               :   To get the default parameters from the 
        '                           INI file located in the app path.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :   INI file contains the respective Sections and Keys
        ' Dependencies          :   None.
        ' Author                :   Gitesh
        ' Created               :   Tuesday, March 23, 2004 03:35
        ' Revisions             :
        '=====================================================================

        If Not File.Exists(CONST_AAS_INI_FileName) Then
            'Throw New Exception("INI file '" & strINI_FileName & "' do not exist.")
            gobjMessageAdapter.ShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' does not exist.", modGlobalConstants.EnumMessageType.Information)
        End If

        '--- Get the parameters from the INI file.
        Try
            lngSessionid = Val(gfuncGetINISystemParameters(CONST_Section_21CFR, CONST_Key_SessionID) & "")

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file."
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

    Public Function gfuncSaveSessionIDtoINIFIle(ByVal lngSessionid As Long) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncSaveSessionIDtoINIFIle
        ' Description           :   To Store the values back the INI FIle.
        ' Purpose               :   To Store the values back the INI FIle.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   Wednesday, March 24, 2004
        ' Revisions             :
        '=====================================================================

        Try
            If Not gfuncWriteINISystemParameters(CONST_Section_21CFR, CONST_Key_SessionID, CStr(lngSessionid & "")) Then
                Return False
            End If
            Return True

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

    Public Function gfuncSetEnable21CFRToINI(ByRef int21CFR As Integer)
        Try
            gFuncWriteToINI(CONST_Section_21CFR, CONST_Key_Enable21CFR, CStr(int21CFR), INI_SETTINGS_PATH)

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

    Public Function gfuncGetInstReset_continuousFromINI() As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetInstReset_continuousFromINI
        ' Description           :   To get InstReset continuousfrom ini file
        ' Purpose               :   To get the InstReset continuousfrom flag from the 
        '                           INI file located in the app path.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :   INI file contains the respective Sections and Keys
        ' Dependencies          :   CONST_AAS_INI_FileName must be set with "AAS.ini"
        ' Author                :   Sachin Dokhale
        ' Created               :   07.01.08
        ' Revisions             :
        '=====================================================================
        Dim intIsInstReset As Integer
        If Not File.Exists(CONST_AAS_INI_FileName) Then
            gobjMessageAdapter.ShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' do not exist.", modGlobalConstants.EnumMessageType.Information)
        End If


        Try
            '--- Get the parameters from the INI file.
            intIsInstReset = CInt(gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, "0", INI_SETTINGS_PATH))
            If intIsInstReset <= 0 Then
                gblnIsInstReset = False
            Else
                gblnIsInstReset = True
            End If
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file."
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

    Public Function gfuncSetInstReset_continuousToINI(ByVal intInstReset_continuous As Boolean)
        Try
            If intInstReset_continuous = False Then
                gFuncWriteToINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, CStr(0), INI_SETTINGS_PATH)
            Else
                gFuncWriteToINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, CStr(1), INI_SETTINGS_PATH)
            End If

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

    Public Function gfuncGetEnable21CFRFromINI() As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetEnable21CFRFromINI
        ' Description           :   Get the enable 21CFR parameter values from the 
        '                           INI file using the API calls to read the INI
        '                           file and assign it to a 21CFREnable application level struct
        '                           object passed as a ref to the function.
        ' Purpose               :   To get the default parameters from the 
        '                           INI file located in the app path.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :   INI file contains the respective Sections and Keys
        ' Dependencies          :   None.
        ' Author                :   Gitesh
        ' Created               :   Tuesday, March 23, 2004 03:35
        ' Revisions             :
        '=====================================================================

        If Not File.Exists(CONST_AAS_INI_FileName) Then
            'Throw New Exception("INI file '" & strINI_FileName & "' do not exist.")
            gobjMessageAdapter.ShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' do not exist.", modGlobalConstants.EnumMessageType.Information)
        End If

        '--- Get the parameters from the INI file.
        Try
            gstructSettings.Enable21CFR = gfuncGetINISystemParameters(CONST_Section_21CFR, CONST_Key_Enable21CFR)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file."
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

    Public Function gfuncSetPrinterTypeToINI(ByRef blnColorPrinter As Boolean)
        Try
            gFuncWriteToINI(CONST_Section_PRINTERTYPE, CONST_Key_ColorPrinter, CStr(blnColorPrinter), INI_SETTINGS_PATH)

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

    Public Function gfuncSetUserIDToINI(ByVal strUserID As String)
        Try

            gFuncWriteToINI(CONST_Section_LOGIN, CONST_Key_USERID, strUserID, INI_SETTINGS_PATH)

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

    Public Function gfuncGetPrinterTypeFromINI() As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetPrinterTypeFromINI
        ' Description           :   To get printer type i,e. is printer B/W or Color from ini file
        ' Purpose               :   To get the default set printer type from the 
        '                           INI file located in the app path.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :   INI file contains the respective Sections and Keys
        ' Dependencies          :   None.
        ' Author                :   Santosh
        ' Created               :   October, 01, 2004 03:35
        ' Revisions             :
        '=====================================================================

        If Not File.Exists(CONST_AAS_INI_FileName) Then
            gobjMessageAdapter.ShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' do not exist.", modGlobalConstants.EnumMessageType.Information)
        End If

        '--- Get the parameters from the INI file.
        Try
            gstructSettings.blnSelectColorPrinter = gfuncGetINISystemParameters(CONST_Section_PRINTERTYPE, CONST_Key_ColorPrinter)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file."
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


    Public Function gfuncGetUserIDFromINI() As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetUserIDFromINI
        ' Description           :   To get User ID from ini file
        ' Purpose               :   To get the last User Id from the 
        '                           INI file located in the app path.
        ' Parameters Passed     :   None.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :   INI file contains the respective Sections and Keys
        ' Dependencies          :   None.
        ' Author                :   Santosh
        ' Created               :   October, 13, 2004 03:35
        ' Revisions             :
        '=====================================================================

        If Not File.Exists(CONST_AAS_INI_FileName) Then
            gobjMessageAdapter.ShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' do not exist.", modGlobalConstants.EnumMessageType.Information)
        End If

        '--- Get the parameters from the INI file.
        Try
            gstructUserDetails.UserID = gfuncGetINISystemParameters(CONST_Section_LOGIN, CONST_Key_USERID)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file."
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


    '*********************\\\\\\\****************************************


    Public Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" _
                    (ByVal strSection As String, ByVal strstring As String, ByVal lpdefault1 As String, ByVal lpreturnedstring1 As String, ByVal buffsize As Integer, ByVal lpfilename1 As String) As Long


    '--- API declarations for reading the data from the INI file.
    Public Declare Ansi Function WritePrivateProfileString Lib "KERNEL32.DLL" Alias "WritePrivateProfileStringA" _
          (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName _
          As String) As Boolean

    Public Function gfuncWriteINISystemParameters(ByVal section As String, ByVal key As String, ByVal value As String) As Boolean
        Try
            If gFuncWriteToINI(section, key, value, CONST_AAS_INI_FileName) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Public Function gfuncGetParametersFromINI(ByRef objParameter As Spectrum.UVSpectrumParameter) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetParametersFromINI
        ' Description           :   Get the default parameter values from the 
        '                           INI file using the API calls to read the INI
        '                           file and populate the values in the parameter
        '                           object passed as a parameter to the function.
        ' Purpose               :   To get the default parameters from the 
        '                           INI file located in the app path.
        ' Parameters Passed     :   Parameter object.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :   INI file contains the respective Sections and Keys
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   Wednesday, November 12, 2003 03:35
        ' Revisions             :
        '=====================================================================

        '--- Get the parameters from the INI file.
        Try
            'Check if INI file exists and give the respective message
            If Not File.Exists(CONST_AAS_INI_FileName) Then
                'gFuncShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' does not exist.", EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("INI file '" & CONST_AAS_INI_FileName & "' does not exist.", "Error...", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Exit Function
            End If

            objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate)
            objParameter.Cal_Mode = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Cal_Mode)
            objParameter.Comments = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Comments)
            objParameter.D2Curr = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_D2Curr)
            objParameter.PMTV = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_PMTV)
            objParameter.ScanSpeed = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanSpeed)
            objParameter.SlitWidth = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SlitWidth)
            objParameter.SpectrumName = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SpectrumName)
            objParameter.XaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMax)
            objParameter.XaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMin)
            objParameter.YaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMax)
            objParameter.YaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMin)

            'objParameter.CalculatedSpeed = gFuncGetSpeed(objParameter.WavelengthMin, objParameter.WavelengthMax)

            '--- Channel name is saved  as Spectrum of' 
            'objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate).ToString
            objParameter.AnalysisDate = DateTime.Today
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in getting parameters from INI file "
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

    Public Function gfuncGetParametersFromINI(ByRef objParameter As Spectrum.EnergySpectrumParameter) As Boolean
        '=====================================================================
        ' Procedure Name        :   gfuncGetParametersFromINI
        ' Description           :   Get the default parameter values from the 
        '                           INI file using the API calls to read the INI
        '                           file and populate the values in the parameter
        '                           object passed as a parameter to the function.
        ' Purpose               :   To get the default parameters from the 
        '                           INI file located in the app path.
        ' Parameters Passed     :   Parameter object.
        ' Returns               :   True, if successful.
        ' Parameters Affected   :   None.
        ' Assumptions           :   INI file contains the respective Sections and Keys
        ' Dependencies          :   None.
        ' Author                :   Sachin Dokhale
        ' Created               :   Wednesday, November 12, 2003 03:35
        ' Revisions             :
        '=====================================================================

        '--- Get the parameters from the INI file.
        Try
            'Check if INI file exists and give the respective message
            If Not File.Exists(CONST_AAS_INI_FileName) Then
                'gFuncShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' does not exist.", EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage("INI file '" & CONST_AAS_INI_FileName & "' does not exist.", "Error...", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Exit Function
            End If

            'objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate)



            objParameter.Cal_Mode = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Cal_Mode)
            objParameter.Comments = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Comments)
            objParameter.D2Curr = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_D2Curr)
            objParameter.PMTV = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_PMTV)
            objParameter.ScanSpeed = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanSpeed)
            objParameter.SlitWidth = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SlitWidth)
            objParameter.BurnerHeight = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_BurnerHeight)
            objParameter.FualRatio = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_FualRatio)
            objParameter.LampTurrNo = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_LampTurrNo)
            objParameter.LampEle = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_LampEle)
            objParameter.HCLCurr = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_HCLCurr)


            objParameter.SpectrumName = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SpectrumName)
            objParameter.XaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMax)
            objParameter.XaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMin)
            objParameter.YaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMax)
            objParameter.YaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMin)

            'objParameter.CalculatedSpeed = gFuncGetSpeed(objParameter.WavelengthMin, objParameter.WavelengthMax)

            '--- Channel name is saved  as Spectrum of' 
            'objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate).ToString
            objParameter.AnalysisDate = DateTime.Today
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = "Error in getting parameters from INI file "
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

    Public Function gFuncWriteToINI(ByVal strSection As String, ByVal strKey As String, _
           ByVal strKeyValues As String, ByVal strINIFilePath As String) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncWriteToINI
        'Description:       To write the specified string to the Key of the given Setion of the INI
        'Parameters :   `   Section Name, KeyName, KeyValue, INI File PAth
        'Time/Date  :       1.21  12'Oct 2003
        'Dependencies:      INI File Should Present Prior
        'Author:            Mandar
        'Revision:          _
        'Revision by Person: _
        '--------------------------------------------------------------------------------------
        Dim bln As Boolean
        gFuncWriteToINI = bln
        Try
            bln = WritePrivateProfileString(Trim$(strSection.ToString), Trim$(strKey.ToString), Trim$(strKeyValues.ToString), Trim$(strINIFilePath.ToString))
            gFuncWriteToINI = bln

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            ''---------------------------------------------------------
            ''Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            ''---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncGetFromINI(ByVal strSection As String, ByVal strKeyValue As String, ByVal strDefaultString As String, _
                    ByVal StrINIFilePath As String) As String
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncGetFromINI
        'Description:   To retrieve the key vale of a specified Section From INI
        'Parameters :   Section, Key , DefaultKeyValue, strFullPath of the INI
        'Time/Date  :   1.09 12'Oct 2003
        'Dependencies:  INI File Should exist
        'Author:    MandarC 
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
            ''---------------------------------------------------------
            ''Writing Execution log
            'If CONST_CREATE_EXECUTION_LOG = 1 Then
            '    gobjErrorHandler.WriteExecutionLog()
            'End If
            ''---------------------------------------------------------
        End Try

    End Function

    '--- This Function returns System Parameters as per the section and key name passed to it.
    Public Function gfuncGetINISystemParameters(ByVal section As String, ByVal key As String) As String
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gfuncGetINISystemParameters
        'Description:       To retrieve the key vale of a specified Section From INI
        'Parameters :       Section, Key 
        'Time/Date  :       1.09 12'Oct 2003
        'Dependencies:      INI File Should exist
        'Author:            Sachin Dokhale
        'Revision: 
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Dim sDefault As String = ""
        Dim strFileName As String

        Try
            Return CStr(gFuncGetFromINI(section, key, sDefault, CONST_AAS_INI_FileName) & "")

        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return ""
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try


    End Function

    'Public Function gfuncSaveSpectrumParameterstoINIFIle(ByVal objSpecParameter As Parameter) As Boolean

    '    Try
    '        gfuncSaveSpectrumParameterstoINIFIle = False

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanMode, objSpecParameter.ScanMode) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanSpeed, objSpecParameter.ScanSpeed) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_CalculatedSpeed, objSpecParameter.CalculatedSpeed) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_Repeats, objSpecParameter.Repeat) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_CycleT, objSpecParameter.CycleT) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_WaveLengthMin, objSpecParameter.WavelengthMin) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_WaveLengthMax, objSpecParameter.WavelengthMax) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMin, objSpecParameter.YaxisMin) Then
    '            gFuncShowMessage("Error...", "Error In Writing System Parameters To INI Files.", modConstants.EnumMessageType.Information)
    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMax, objSpecParameter.YaxisMax) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_ChannelName, objSpecParameter.ChannelName) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalystName, objSpecParameter.AnalystName) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If

    '        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate, objSpecParameter.AnalysisDate) Then
    '            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

    '        End If


    '        gfuncSaveSpectrumParameterstoINIFIle = True
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = "Error in writing time scan parameters to INI"
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        gfuncSaveSpectrumParameterstoINIFIle = False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try

    'End Function

End Module
