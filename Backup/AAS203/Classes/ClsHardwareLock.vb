Option Explicit On 

Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports System.IO
Imports AAS203.Common

Public Class clsHardwareLock

    Private Const CONST_TEMP_FILE = "config.tmp"
    Private Const CONST_CONFIG_FILE_NAME = "AAS203.config"

#Region " Import/Declare DLL's "

    <DllImport("sentrydll5.dll")> Private Shared Function win_xread_nt95( _
          ByRef rbuff As Int16, ByRef pass As Byte) As Integer                'Long
    End Function

    <DllImport("sentrydll5.dll")> Private Shared Function win_xwrite_nt95( _
        ByRef rbuff As Int16, ByRef wbuff As Int16, ByRef pass As Byte) As Integer        'Long
    End Function

    Public Declare Auto Function GetPrivateProfileString Lib "kernel32.dll" _
                      (ByVal strSection As String, ByVal strstring As String, ByVal lpdefault1 As String, ByVal lpreturnedstring1 As String, ByVal buffsize As Integer, ByVal lpfilename1 As String) As Long

    '--- API declarations for reading the data from the INI file.
    Public Declare Ansi Function WritePrivateProfileString Lib "KERNEL32.DLL" Alias "WritePrivateProfileStringA" _
          (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName _
          As String) As Boolean


#End Region

#Region " Public Functions "

    Private Function WriteHardwareKey(ByVal strKey As String) As Boolean
        Dim rbuff(11) As Int16
        Dim int16Signature(11) As Int16
        Dim int32TempSignature As Int32

        Dim temp As Int32
        Dim pass(3) As Byte
        Dim stat As Integer
        Dim strTemp(20) As Byte
        Dim strString As String
        Dim strSignature(23) As String

        Dim chrKey(23) As Char

        Dim i As Integer
        Dim intCounter As Integer
        Dim cWait As CWaitCursor

        For intCounter = 0 To 23
            chrKey(intCounter) = strKey.Chars(intCounter)
        Next

        For intCounter = 0 To 23 Step 2
            strSignature(intCounter / 2) = "&H" & Hex(Asc(chrKey(intCounter))) & Hex(Asc(chrKey(intCounter + 1)))
            int32TempSignature = CType(strSignature(intCounter / 2), Int32)

            If int32TempSignature > 32767 Then
                int16Signature(intCounter / 2) = int32TempSignature - 65536
            Else
                int16Signature(intCounter / 2) = int32TempSignature
            End If
        Next

        pass(0) = 78
        pass(1) = 80
        pass(2) = 67
        pass(3) = 72

        For i = 0 To 11
            rbuff(i) = 0
        Next i

        rbuff(0) = 21334
        rbuff(1) = 13910
        rbuff(2) = 17232
        rbuff(3) = 18477
        rbuff(4) = 22097
        rbuff(5) = 14645
        rbuff(6) = 11600
        rbuff(7) = 13622
        rbuff(8) = 19274
        rbuff(9) = 13874
        rbuff(10) = 8224
        rbuff(11) = 8224

        stat = win_xwrite_nt95(rbuff(0), int16Signature(0), pass(0))
        Select Case stat
            Case 0
                '            Text5.Text = "Lock Found! Data written Successfully, the one assigned to Signature varibale!!!"
                'gFuncShowMessage("Hardware Lock Check", "Lock Found! Key set successfully!!!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(52)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return True
            Case -1
                ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                'gFuncShowMessage("Hardware Lock Error", "Hardware lock not installed OR " & vbCrLf & " the one installed is not having proper identity", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(53)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -2
                'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                'gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(54)
                Application.DoEvents()
                cWait = New CWaitCursor

                Return False
            Case -3
                'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                ' gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(62)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -5
                'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(55)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -6
                'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(56)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -7
                'Text5.Text = " The memory location index entered is out of range (0-29)!"
                'gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(57)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -8
                'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                'gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(58)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -9
                'Text5.Text = " Cannot work on Win3.1!"
                'gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(59)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -10
                'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                'gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(60)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
        End Select

    End Function

    Private Function ReadHardwareKey(ByVal strKey As String) As Boolean
        Dim rbuff(11) As Int16
        Dim int16Signature(11) As Int16
        Dim int32TempSignature As Int32

        Dim temp As Int32
        Dim pass(3) As Byte
        Dim stat As Integer   'eger 'Long
        Dim strTemp(20) As Byte
        Dim strString As String
        Dim strSignature(23) As String

        Dim chrKey(23) As Char

        Dim i As Integer
        Dim intCounter As Integer
        Dim cWait As CWaitCursor


        For intCounter = 0 To 23
            chrKey(intCounter) = strKey.Chars(intCounter)
        Next
        For intCounter = 0 To 23 Step 2
            strSignature(intCounter / 2) = "&H" & Hex(Asc(chrKey(intCounter))) & Hex(Asc(chrKey(intCounter + 1)))
            int32TempSignature = CType(strSignature(intCounter / 2), Int32)

            If int32TempSignature > 32767 Then
                int16Signature(intCounter / 2) = int32TempSignature - 65536
            Else
                int16Signature(intCounter / 2) = int32TempSignature
            End If
        Next

        ' Fill pass array with your password, which should be hex, refer keyxxxx.txt

        pass(0) = 78
        pass(1) = 80
        pass(2) = 67
        pass(3) = 72

        For i = 0 To 11
            rbuff(i) = 0
        Next i

        'Fill rbuff with your  key (refer keyxxxx.txt)

        rbuff(0) = 21334
        rbuff(1) = 13910
        rbuff(2) = 17232
        rbuff(3) = 18477
        rbuff(4) = 22097
        rbuff(5) = 14645
        rbuff(6) = 11600
        rbuff(7) = 13622
        rbuff(8) = 19274
        rbuff(9) = 13874
        rbuff(10) = 8224
        rbuff(11) = 8224

        stat = win_xread_nt95(rbuff(0), pass(0))

        Select Case stat
            Case 0

                For i = 0 To 11
                    If (rbuff(i) <> int16Signature(i)) Then Exit For
                Next i
                If (i < 11) Then
                    'gFuncShowMessage("Hardware Lock Error", "Lock Found! Data Read from the lock is not matching with the one assigned to hardware key!", modConstants.EnumMessageType.Information)
                    gobjMessageAdapter.ShowMessage(61)
                    Application.DoEvents()
                    cWait = New CWaitCursor
                    Return False
                Else
                    ' gFuncShowMessage("Hardware Lock", "Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!", modConstants.EnumMessageType.Information)
                    Return True
                End If

            Case -1
                ' Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
                'gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the one installed is not bearing proper identity", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(53)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -2
                'Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
                'gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(54)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -3
                'Text5.Text = "Sentrymsp.vxd is not found in the current path  "
                'gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(62)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -5
                'Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(55)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -6
                'Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
                'gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(56)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -7
                'Text5.Text = " The memory location index entered is out of range (0-29)!"
                'gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(57)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -8
                'Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
                'gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(58)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -9
                'Text5.Text = " Cannot work on Win3.1!"
                'gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(59)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
            Case -10
                'Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
                'gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
                gobjMessageAdapter.ShowMessage(60)
                Application.DoEvents()
                cWait = New CWaitCursor
                Return False
        End Select


    End Function

    Private Function GetRTCDataTime() As Date
        Dim dtRtcDtTime As Date
    End Function

    Public Function gFuncGetFromINI(ByVal strSection As String, ByVal strKeyValue As String, ByVal strDefaultString As String, _
           ByVal StrINIFilePath As String) As String
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncGetFromINI
        'Description:   To retrieve the key vale of a specified Section From INI
        'Parameters :   Section, Key , DefaultKeyValue, strFullPath of the INI
        'Time/Date  :   1.09 12'Oct 2004
        'Dependencies:  INI File Should exist
        'Author:    M.kamal
        'Revision: 
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Dim intBffer As Int32 = 255
        Dim strReturnString As String = Space(intBffer)
        gFuncGetFromINI = ""

        'If (GetPrivateProfileString(section, key, sDefault, strReturnString, intBffer, strINI_FileName) <> 0) Then
        '    Return CStr(strReturnString)
        'Else
        '    Throw New Exception("Error in reading the system parameters INI file.")
        'End If
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

    Public Function gFuncWriteToINI(ByVal strSection As String, ByVal strKey As String, _
               ByVal strKeyValues As String, ByVal strINIFilePath As String) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncWriteToINI
        'Description:       To write the specified string to the Key of the given Setion of the INI
        'Parameters :   `   Section Name, KeyName, KeyValue, INI File PAth
        'Time/Date  :       29 Dec 2004
        'Dependencies:      INI File Should Present Prior
        'Author:           M.kamal
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

#End Region

#Region " Configuration Settings "

    Public Function gfuncGetConfigurationSetting() As Boolean
        Dim strFileName As String

        Try
            'Get the configuration settings from the config file
            'and store the data on the global structure
            '------------------------------------e---------------------
            '1. Check for the config file, if not found get the file.
            '2. Read configuration setting.
            '---------------------------------------------------------
            strFileName = Application.StartupPath & "\" & CONST_CONFIG_FILE_NAME

            '1. Check for the config file, if not found get the file.
            If Not File.Exists(Application.StartupPath & "\" & CONST_CONFIG_FILE_NAME) Then
                '--- Get the file from the user
                Dim objFileDialog As New OpenFileDialog
                objFileDialog.InitialDirectory = Application.StartupPath
                If objFileDialog.ShowDialog() = DialogResult.Cancel Then
                    Return False
                Else
                    strFileName = objFileDialog.FileName()

                    If Not File.Exists(strFileName) Then
                        Return False
                    End If

                    Call File.Copy(strFileName, Application.StartupPath & "\" & CONST_CONFIG_FILE_NAME, True)

                    strFileName = Application.StartupPath & "\" & CONST_CONFIG_FILE_NAME
                End If
            End If

            '2. Read configuration setting.
            If Not funcReadConfigSetting(strFileName) Then
                Return False
            End If

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
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

    Private Function funcReadConfigSetting(ByVal strFileName As String) As Boolean
        Dim strFileData As String
        Dim strTempFileName As String

        Const CONST_TEMP_FILE = "config.tmp"
        Const SECTION_Settings = "Settings"
        Const KEY_HardwareKey = "HardwareKey"
        Const KEY_DemoDays = "DemoDays"
        Const KEY_HardwareLockType = "HardwareLockType"

        Const KEY_SessionID = "SessionID"
        Const SECTION_General = "General"
        Const KEY_D2Gain = "D2GAIN"
        Const KEY_SetMinAbsLimit = "Set_Min_Abs_Limit"
        Const KEY_AbsThresholdValue = "Abs_Threshold_Value"
        Const KEY_PrinterType = "PrinterType"
        Const KEY_HydrideMode = "HydrideMode"

        Const KEY_BHStep = "BHStep"
        Const KEY_D2Pmt = "D2Pmt"
        Const KEY_Mesh = "Mesh"
        
        Const SECTION_Applications = "Applications"

        Const KEY_ApplicationType = "AppMode"
        Const KEY_21CFRInstallation = "21CFRInstallation"
        Const KEY_Enable21CFR = "Enable21CFR"
        Const KEY_HardwareLock = "HardwareLock"

        Const KEY_EnableIQOQPQ = "EnableIQOQPQ"

        Const KEY_EnableServiceUtility = "EnableServiceUtility"
        Const KEY_DisplayConfiguration = "DisplayConfiguration"

        Const KEY_CommPort = "CommPort"
        Const KEY_Instrument = "Instrument"

        Const SECTION_INIFileSettings = "INIFileSettings"
        Const KEY_TimeConstant = "Time_Constant"
        Const KEY_Filter_Window_Size = "Filter_Window_Size"
        Const KEY_Blank_Calculation = "Blank_Calculation"
        Const KEY_Exe_To_Run = "ExeToRun"       'Saurabh
        Const KEY_ModelName = "ModelName"

        Dim intD2Gain As Integer
        Dim intMesh As Integer
        Dim intMinAbsLimit As String
        Dim int21CFR As Integer
        Dim intEnableServiceUtility As Integer
        Dim intDisplayConfiguration As Integer
        Dim intExeToRun As Integer
        Dim intModelName As Integer

        Try
            '---------------------------------------------------------
            '1. Copy the file to temp folder.
            '2. Decrypt the file.
            '3. Read the file as ini file.
            '---------------------------------------------------------
            '1. Copy the file to temp folder.
            '2. Decrypt the file.
            strTempFileName = Application.StartupPath & "\" & CONST_TEMP_FILE
            strFileData = funcReadFile(Application.StartupPath & "\" & CONST_CONFIG_FILE_NAME)
            strFileData = gfuncDecryptString(strFileData)
            If Not funcWriteFile(strTempFileName, strFileData) Then
                Return False
            End If

            '3. Read the file as ini file.
            '--- [Settings]
            gstructSettings.HardwareLock = Val(gFuncGetFromINI(SECTION_Applications, KEY_HardwareLock, "", strTempFileName) & "")
            gstructSettings.HardwareLockType = gFuncGetFromINI(SECTION_Settings, KEY_HardwareLockType, "", strTempFileName)
            gstructSettings.HardwareKey = gFuncGetFromINI(SECTION_Settings, KEY_HardwareKey, "", strTempFileName)
            gstructSettings.DemoDays = gFuncGetFromINI(SECTION_Settings, KEY_DemoDays, "", strTempFileName)

            gstructSettings.AppMode = Val(gFuncGetFromINI(SECTION_Applications, KEY_ApplicationType, "", strTempFileName) & "")
            gstructSettings.SessionID = Val(gFuncGetFromINI(SECTION_Settings, KEY_SessionID, "", strTempFileName) & "")

            '--- [General]
            intD2Gain = Val(gFuncGetFromINI(SECTION_General, KEY_D2Gain, "0", strTempFileName) & "")
            If intD2Gain = 0 Then
                gstructSettings.D2Gain = False
            Else
                gstructSettings.D2Gain = True
            End If

            gstructSettings.BHStep = Val(gFuncGetFromINI(SECTION_General, KEY_BHStep, "", strTempFileName) & "")
            gstructSettings.D2Pmt = Val(gFuncGetFromINI(SECTION_General, KEY_D2Pmt, "0", strTempFileName) & "")
            intMesh = Val(gFuncGetFromINI(SECTION_General, KEY_Mesh, "0", strTempFileName) & "")

            If intMesh = 0 Then
                gstructSettings.Mesh = False
            Else
                gstructSettings.Mesh = True
            End If

            '---To enable or Disable 21CFR Utility
            int21CFR = Val(gFuncGetFromINI(SECTION_Applications, KEY_21CFRInstallation, "1", strTempFileName) & "")
            If int21CFR = 0 Then
                gstructSettings.CFR21Installation = False
                gstructSettings.Enable21CFR = False
            Else
                gstructSettings.CFR21Installation = True
                int21CFR = Val(gFuncGetFromINI(SECTION_Applications, KEY_Enable21CFR, "1", strTempFileName) & "")
                If int21CFR = 0 Then
                    gstructSettings.Enable21CFR = False
                Else
                    gstructSettings.Enable21CFR = True
                End If
            End If

            '---To enable or Disable Service Utility
            intEnableServiceUtility = Val(gFuncGetFromINI(SECTION_Applications, KEY_EnableServiceUtility, "1", strTempFileName) & "")
            If intEnableServiceUtility = 0 Then
                gstructSettings.EnableServiceUtility = False
            Else
                gstructSettings.EnableServiceUtility = True
            End If

            '---To set Display Configuration
            intDisplayConfiguration = Val(gFuncGetFromINI(SECTION_Applications, KEY_DisplayConfiguration, "1", strTempFileName) & "")
            If intDisplayConfiguration = 0 Then
                gstructSettings.IsCustomerDisplayMode = True
            Else
                gstructSettings.IsCustomerDisplayMode = False
            End If

            '---4.85  14.04.09
            intModelName = Val(gFuncGetFromINI(SECTION_Applications, KEY_ModelName, "0", strTempFileName) & "")
            If intModelName = 0 Then
                gstructSettings.NewModelName = False
            Else
                gstructSettings.NewModelName = True
            End If
            '---4.85  14.04.09


            ''--- [INI File Settings]
            intMinAbsLimit = (gFuncGetFromINI(SECTION_INIFileSettings, KEY_SetMinAbsLimit, 0, strTempFileName) & "")
            If intMinAbsLimit = 0 Then
                gstructSettings.SetMinAbsLimit = False
            Else
                gstructSettings.SetMinAbsLimit = True
            End If

            gstructSettings.AbsThresholdValue = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_AbsThresholdValue, "0.008", strTempFileName) & "")
            gstructSettings.TimeConstant = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_TimeConstant, "2.0", strTempFileName) & "")
            gstructSettings.Filter_Window_Size = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_Filter_Window_Size, "201", strTempFileName) & "")

            'void(FiltRead(void))
            '{
            'char	str[128];
            ' GetProfileStringFromIniFile("Filter Setting", "Filter Window Size" ,
            '		"201", str, "aas.ini");
            ' Wlen = atoi(str);
            'if (Wlen<20 || Wlen>FILTMAX-1)
            '  Wlen=201;
            '}

            If (gstructSettings.Filter_Window_Size < 20) Or (gstructSettings.Filter_Window_Size > ConstFILTMAX - 1) Then
                gstructSettings.Filter_Window_Size = 201
            End If

            If Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_PrinterType, "0", strTempFileName) & "") = 0 Then
                gstructSettings.blnSelectColorPrinter = False
            Else
                gstructSettings.blnSelectColorPrinter = True
            End If

            gstructSettings.HydrideMode = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_HydrideMode, "0", strTempFileName) & "")

            If Val(gFuncGetFromINI(SECTION_Applications, KEY_EnableIQOQPQ, "0", strTempFileName) & "") Then
                gstructSettings.EnableIQOQPQ = True
            Else
                gstructSettings.EnableIQOQPQ = False
            End If

            If Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_Blank_Calculation, "0", strTempFileName) & "") = 0 Then
                gstructSettings.BlankCalculation = True
            Else
                gstructSettings.BlankCalculation = False
            End If

            '--- delete the temp file
            If File.Exists(strTempFileName) Then
                Call File.Delete(strTempFileName)
            End If

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            ' gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            If File.Exists(strTempFileName) Then
                Call File.Delete(strTempFileName)
            End If
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

    Private Function funcCreateConfigFile(ByVal strFileName As String, _
                                    ByVal strConfigFileName As String) As Boolean

        Dim strFileContent As String
        Dim strEncryptedString As String
        Try
            '--1. read the Configure file ina string
            '--2. Encrypt the String
            '--3. Write The Encrypted File in a Given Folder

            '--1. read the Configure file ina string
            '--- Check Wether the file Exists
            strFileContent = funcReadFile(strFileName)
            If strFileContent.Length <= 0 Then
                Return False
            End If

            '--2. Encrypt the String
            strEncryptedString = gfuncEncryptString(strFileContent)
            If strEncryptedString.Length <= 0 Then
                Return False
            End If

            '--2. Decrypt the String(Temporary checking For Decrypting)
            'strEncryptedString = gfuncDecryptString(strFileContent)
            'If strEncryptedString.Length <= 0 Then
            '    Return False
            'End If
            'If Not funcWriteFile(strFolderName & "\" & "Con.Config", strEncryptedString) Then
            '    Return False
            'End If

            '--3. Write The Encrypted File in a Given Folder
            If Not funcWriteFile(strConfigFileName, strEncryptedString) Then
                Return False
            End If

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
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

    Private Function funcReadFile(ByVal strFilePath As String) As String

        Dim strFileContent As String

        Try
            If Not File.Exists(strFilePath) Then
                Return ""
            End If

            Dim objStreamReader As StreamReader
            objStreamReader = New StreamReader(strFilePath)
            strFileContent = objStreamReader.ReadToEnd()
            objStreamReader.Close()

            Return strFileContent

        Catch exIO As IOException
            gobjErrorHandler.ErrorDescription = exIO.Message
            gobjErrorHandler.ErrorMessage = exIO.Message
            Return ""

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            Return ""
        End Try

    End Function

    Private Function funcWriteFile(ByVal strFilePath As String, _
                                ByVal strFileContent As String) As Boolean
        Try
            Dim objStreamWriter As StreamWriter
            objStreamWriter = New StreamWriter(strFilePath)
            objStreamWriter.Write(strFileContent)
            objStreamWriter.Close()

            Return True

        Catch i As IOException
            gobjErrorHandler.ErrorDescription = i.Message
            gobjErrorHandler.ErrorMessage = i.Message
            Return False

        Catch e As Exception
            gobjErrorHandler.ErrorDescription = e.Message
            gobjErrorHandler.ErrorMessage = e.Message
            Return False

        End Try

    End Function

    Public Function gfuncSaveConfigurationSetting() As Boolean
        Dim strFileData As String

        Const CONST_TEMP_FILE = "config.tmp"
        Const SECTION_Settings = "Settings"
        Const SECTION_INIFileSettings = "INIFileSettings"

        'Const KEY_Accessory = "Accessory"
        'Const KEY_ShowScreen = "ShowScreen"
        'Const KEY_Lamp_Mode = "Lamp_Mode"
        Const KEY_SessionID = "SessionID"
        Const KEY_Abs_Threshold_Value = "Abs_Threshold_Value"
        Const KEY_PrinterType = "PrinterType"
        Const KEY_HydrideMode = "HydrideMode"

        Const KEY_21CFRInstallation = "21CFRInstallation"
        Const KEY_Enable21CFR = "Enable21CFR"
        Const SECTION_Applications = "Applications"
        Const KEY_AbsThresholdValue = "Abs_Threshold_Value"
        Const KEY_TimeConstant = "Time_Constant"
        Const KEY_Filter_Window_Size = "Filter_Window_Size"
        'Const KEY_InstrumentNo = "Instrument_Number"
        'Const SECTION_Range = "Range"
        'Const KEY_MaxABS = "Maximum_ABS"
        'Const KEY_MinABS = "Minimum_ABS"
        Try
            '---------------------------------------------------------
            '1. Decrypt the file in the temp file.
            '2. Write the required parameters to the temp file.
            '3. Encrypt and create the config again.
            '---------------------------------------------------------

            '1. Decrypt the file in the temp file.
            strFileData = funcReadFile(Application.StartupPath & "\" & CONST_CONFIG_FILE_NAME)
            strFileData = gfuncDecryptString(strFileData)
            If strFileData.Length > 0 Then
                If Not funcWriteFile(Application.StartupPath & "\" & CONST_TEMP_FILE, strFileData) Then
                    Return False
                End If
            End If

            '2. Write the required parameters to the temp file.
            ' Call gFuncWriteToINI(SECTION_Settings, KEY_Accessory, gstructConfigurartionSetting.Accessory, Application.StartupPath & "\" & CONST_TEMP_FILE)
            ' Call gFuncWriteToINI(SECTION_Settings, KEY_ShowScreen, gstructConfigurartionSetting.ShowScreen, Application.StartupPath & "\" & CONST_TEMP_FILE)
            'Call gFuncWriteToINI(SECTION_Settings, KEY_Lamp_Mode, gstructConfigurartionSetting.Lamp_Mode, Application.StartupPath & "\" & CONST_TEMP_FILE)
            Call gFuncWriteToINI(SECTION_Settings, KEY_SessionID, gstructSettings.SessionID, Application.StartupPath & "\" & CONST_TEMP_FILE)

            Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_Abs_Threshold_Value, gstructSettings.AbsThresholdValue, Application.StartupPath & "\" & CONST_TEMP_FILE)


            Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_AbsThresholdValue, gstructSettings.AbsThresholdValue, Application.StartupPath & "\" & CONST_TEMP_FILE)
            Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_TimeConstant, gstructSettings.TimeConstant, Application.StartupPath & "\" & CONST_TEMP_FILE)
            Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_Filter_Window_Size, gstructSettings.Filter_Window_Size, Application.StartupPath & "\" & CONST_TEMP_FILE)

            If gstructSettings.blnSelectColorPrinter = False Then
                Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_PrinterType, "0", Application.StartupPath & "\" & CONST_TEMP_FILE)
            Else

                Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_PrinterType, "1", Application.StartupPath & "\" & CONST_TEMP_FILE)
            End If

            If gstructSettings.HydrideMode = 0 Then
                Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_HydrideMode, "0", Application.StartupPath & "\" & CONST_TEMP_FILE)
            Else
                'gstructSettings.blnHydrideMode = True
                Call gFuncWriteToINI(SECTION_INIFileSettings, KEY_HydrideMode, "1", Application.StartupPath & "\" & CONST_TEMP_FILE)
            End If

            Dim intEnable21CFR As String
            If gstructSettings.CFR21Installation = True Then
                If gstructSettings.Enable21CFR = True Then
                    intEnable21CFR = "1"
                Else
                    intEnable21CFR = "0"
                End If
                'Call gFuncWriteToINI(SECTION_Settings, KEY_SessionID, intEnable21CFR, Application.StartupPath & "\" & CONST_TEMP_FILE)
                '-----Added By Pankaj on 30 May 07
                Call gFuncWriteToINI(SECTION_Applications, KEY_Enable21CFR, intEnable21CFR, Application.StartupPath & "\" & CONST_TEMP_FILE) 'Added By Pankaj on 30 May 07
                '-----

            End If
            'Call gFuncWriteToINI(SECTION_Range, KEY_MinABS, gstructConfigurartionSetting.strucRangeY.dblMinimum_ABS, Application.StartupPath & "\" & CONST_TEMP_FILE)
            'Call gFuncWriteToINI(SECTION_Range, KEY_MaxABS, gstructConfigurartionSetting.strucRangeY.dblMaximum_ABS, Application.StartupPath & "\" & CONST_TEMP_FILE)
            'Call gFuncWriteToINI(SECTION_Settings, KEY_InstrumentNo, gstructConfigurartionSetting.Instrument_Number, Application.StartupPath & "\" & CONST_TEMP_FILE)


            '3. Encrypt and create the config again.
            If Not funcCreateConfigFile(Application.StartupPath & "\" & CONST_TEMP_FILE, Application.StartupPath & "\" & CONST_CONFIG_FILE_NAME) Then
                Return False
            End If

            If File.Exists(Application.StartupPath & "\" & CONST_TEMP_FILE) Then
                Call File.Delete(Application.StartupPath & "\" & CONST_TEMP_FILE)
            End If

            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            '  gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
            Return False

        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            Application.DoEvents()
        End Try
    End Function

    Public Function gfuncDecryptString(ByVal str_encrypt As String) As String
        Dim str_decrypt, arr_str() As String
        Dim arr_byte(), bt_single As Byte
        Dim rec_cnt, temp_cnt As Integer

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
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            str_decrypt = ""
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
        Return str_decrypt

    End Function

    Public Function gfuncEncryptString(ByVal str_source As String) As String
        Dim str_single, str_encrypt As String
        Dim arr_byte() As Byte
        Dim rec_cnt, temp_cnt As Integer

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
            'Error logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            str_encrypt = ""
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

        Return str_encrypt

    End Function

    Public Function gfuncReadHardwareLockSetting(Optional ByVal blnIsStart As Boolean = False) As Boolean
        '-----------------------------------------------------------------
        'Procedure Name         :   gfuncReadHardwareLockSetting
        'Description            :   To Read the Setting of Hardware lock and return the status
        'Parameters             :   None
        'Return Value           :   True/False
        'Time/Date              :   14.03.07
        'Dependencies           :   
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '-----------------------------------------------------------------
        Dim IsUpgradeSessionID As Boolean = False
        Dim intLockValue As Integer = 0
        Dim objTimeDelay As New clsTimer(Nothing, 3000)
        Try

            gfuncReadHardwareLockSetting = False
            If gstructUserDetails.SessionID = 0 Then
                If gstructSettings.HardwareLock = 1 Then
                    If gstructSettings.HardwareLockType = EnumHardwareLockType.USB_Lock Then
                        '//----- Commented and added by Sachin Dokhale 05.05.06
                        gobjMessageAdapter.ShowMessage(constRemoveUSBHWLock)
                        Application.DoEvents()
                        'Process.Start(Application.StartupPath & "\installsentry.bat")
                        Process.Start(Application.StartupPath & "\installsentryUSB.bat")
                        Application.DoEvents()
                        Call objTimeDelay.subTime_Delay(4000)
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(4000)
                        gobjMessageAdapter.ShowMessage(constPlugUSBHWLoack)
                        Application.DoEvents()
                        'gobjCommProtocol.mobjCommdll.subTime_Delay(10000)
                        Call objTimeDelay.subTime_Delay(10000)
                        'gobjMessageAdapter.ShowMessage("If USB Lock is found then click Ok to continue for Lock detection else Cancel", "USB Lock", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage, False, True)
                        gobjMessageAdapter.ShowMessage("Click Ok to continue ", "USB Lock", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                        Application.DoEvents()
                        Dim intNoofTime_ReadKey As Integer = 0
                        Do While (True)
                            If intNoofTime_ReadKey <= 4 Then
                                If gobjHardwareLock_USB.GetValue(intLockValue) < 0 Then
                                    'gobjMessageAdapter.ShowMessage(constErrorHWLock)
                                    'Exit Function
                                    'Return False
                                Else
                                    Exit Do
                                End If
                            Else
                                gobjMessageAdapter.ShowMessage(constErrorHWLock)
                                Application.DoEvents()
                                Return False
                                Exit Do
                            End If
                            'gobjCommProtocol.mobjCommdll.subTime_Delay(4000)
                            Call objTimeDelay.subTime_Delay(4000)
                            intNoofTime_ReadKey += 1
                        Loop
                        '//-----
                        '---Sachin Ashtankar 04-Sept-2005
                        '//----- Sachin Dokhale 08-Feb-2006
                        If gobjHardwareLock_USB.WriteCurrentDateTime() = False Then
                            gobjMessageAdapter.ShowMessage(constErrorHWLock)
                            Application.DoEvents()
                            'frmSplashScreen.Close()
                            'Exit Function
                            Return False
                        Else ' When USb HardwareLock write current Data & Time then session Id Should be upgrade from 0 next ID else not

                        End If

                    ElseIf gstructSettings.HardwareLockType = EnumHardwareLockType.LPT_Lock Then
                            Process.Start(Application.StartupPath & "\installsentry.bat")
                            'gobjCommProtocol.mobjCommdll.subTime_Delay(300)
                            objTimeDelay.subTime_Delay(3)

                            'If Not gobjHardwareLock_LPT.ReadHardwareKey(gstructConfigurartionSetting.HardwareKey) Then
                            '    frmSplashScreen.Close()
                            'End If

                    End If
                End If
                '---------------------------------------
                'Dim objfrmInstallation As New frmInstallation
                'objfrmInstallation.ShowDialog()
                'objfrmInstallation.Dispose()
            End If
            '---modified by kamal
            '----for implementing Hardwarelock

            If gstructSettings.HardwareLock = 1 Then
                If gstructSettings.HardwareLockType = EnumHardwareLockType.USB_Lock Then
                    '//----- Modified by Sachin Dokhale 
                    'If Not gobjHardwareLock_USB.ReadHardwareKey(gstructConfigurartionSetting.HardwareKey) Then
                    If gobjHardwareLock_USB.ReadHardwareKey(gstructSettings.HardwareKey) <= 0 Then
                        'Exit Function
                        Return False
                    Else
                        '---Sachin Ashtankar 04-Sept-2005-------
                        If gstructSettings.DemoDays > 0 Then
                            '//----- Added and modified by Sachin Dokhale
                            Dim intDifference As Integer
                            'If gobjHardwareLock_USB.GetDifference() Then
                            If gobjHardwareLock_USB.GetDifference(intDifference) = True Then
                                If intDifference > gstructSettings.DemoDays Then
                                    gobjMessageAdapter.ShowMessage(constDemoPeriodExpired)

                                    'Exit Function
                                    Return False
                                ElseIf intDifference < 0 Then
                                    gobjMessageAdapter.ShowMessage("Hardware Lock Error." & vbCrLf & _
                                                                            "Hardware Lock Drivers is not properly installed." & vbCrLf & _
                                                                            "Please contact your software vender.", "Hardware Lock Error", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                                    'gobjMessageAdapter.ShowMessage(constErrorHWLock)
                                    'Exit Function
                                    Return False
                                    'ElseIf intDifference = 0 Then
                                ElseIf intDifference = gstructSettings.DemoDays Then
                                    gobjMessageAdapter.ShowMessage("Hardware Lock." & vbCrLf & _
                                                                            "Last day to go expire, Validate this software before expire." & vbCrLf & _
                                                                            "Please contact your software vender.", "Hardware Lock Error", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                                    'gobjMessageAdapter.ShowMessage(constErrorHWLock)
                                    IsUpgradeSessionID = True
                                Else
                                    'Dim strMessage As String = Math.Abs((intDifference - gstructConfigurartionSetting.DemoDays)).ToString & " Days Left"
                                    'Dim strMessage As String = Math.Abs((intDifference - gstructSettings.DemoDays)).ToString & " Days left for expiry of this Software."
                                    'gobjMessageAdapter.ShowMessage(strMessage, "Demo", EnumMessageType.Information)
                                    '//----- Added by Sachin Dokhale if S/W is stated or not
                                    If blnIsStart = False Then
                                        'Dim strMessage As String = Math.Abs((intDifference - gstructConfigurartionSetting.DemoDays)).ToString & " Days Left"
                                        Dim strMessage As String = Math.Abs((intDifference - gstructSettings.DemoDays)).ToString & " Days left for expiry of this Software."
                                        gobjMessageAdapter.ShowMessage(strMessage, "Demo", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                                        'gobjMessageAdapter.ShowMessage(msgID_ErrorHWLock)
                                    End If
                                    '//----
                                    IsUpgradeSessionID = True
                                End If
                            Else
                                'Terminate Aplication
                                'gFuncShowMessage("Hardware Lock Error", "Hardware Lock is failed. Please contact your software vender.", modConstants.EnumMessageType.Information)
                                gobjMessageAdapter.ShowMessage(constErrorHWLock)

                                'Exit Function
                                Return False
                            End If
                        Else
                            IsUpgradeSessionID = True
                        End If
                        '---------------------------------------
                    End If
                ElseIf gstructSettings.HardwareLockType = EnumHardwareLockType.LPT_Lock Then
                    If Not gobjHardwareLock_LPT.ReadHardwareKey(gstructSettings.HardwareKey) Then
                        'Exit Function
                        Return False
                    Else
                        IsUpgradeSessionID = True
                    End If
                End If
            Else
                IsUpgradeSessionID = True
            End If
            gfuncReadHardwareLockSetting = IsUpgradeSessionID
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
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
            objTimeDelay.subTimerStop()
            objTimeDelay = Nothing
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Class
