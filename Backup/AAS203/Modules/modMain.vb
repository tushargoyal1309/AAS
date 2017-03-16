Option Explicit On 
Option Strict Off

Imports System
Imports System.IO
Imports AAS203.Common
Imports System.Collections
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Diagnostics
Imports System.ComponentModel

Imports AAS203Library
Imports AAS203Library.Instrument
Imports AAS203Library.Method

Module modMain
    Public Sub main()
        '=====================================================================
        ' Procedure Name        : Main
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : Start of the software
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 05.09.06
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is first starting point of software
        ''this is a function which called first.
        ''do some software initialisation step here.
        ''like checking for user, checking for dependencies etc.

        Dim objfrmSplashScreen As New frmSplash
        Dim objfrmAASInitialisation As frmAASInitialisation
        Dim blnResetCmd As Boolean = False
        Dim strPath As String
        Dim objTimeDelay As New clsTimer(Nothing, 5000)
        Dim blnIsUpgradeSessionID As Boolean
        Try

            '---Initialize error handler
            Call subErrorHandlerInitialization(gobjErrorHandler)
            ''Added by pankaj on 29 Jan 08
            INI_SETTINGS_PATH = Application.StartupPath & "\AAS.ini"
            '---Initialize database settings
            If funcInitializeAppDatabaseSettings() = True Then
                '---read configuration settings
                If Not gobjHardwareLock.gfuncGetConfigurationSetting() Then
                    'display msg -error in configuration settings initialization
                    Call gobjMessageAdapter.ShowMessage(constConfigurationError)
                    Call Application.DoEvents()
                    ''allow application to perfrom its panding work.
                    End
                End If
            Else
                '---display msg -error in database initialization
                Call gobjMessageAdapter.ShowMessage("AAS ini Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                Call Application.DoEvents()
                End
            End If
            ''---------
            '---Display Splash screen
            Call objfrmSplashScreen.Show()
            ''put a delay of 3000 for splash screen.
            'Call objTimeDelay.subTime_Delay(2000)
            Call Application.DoEvents()
            ''now allow application to perfrom its panding work
            '//----- Added by Sachin Dokhale
            'objTimeDelay = Nothing
            '//-----
            ''--- Check for the previous instance of the application
            If PrevInstance() Then
                ''this function will find that ,is there any other instance of software is running
                ''or not.If running then prompt a message.
                gobjMessageAdapter.ShowMessage("Application Busy", "One instance of the application is already running" & vbCrLf & "Please close the previous instance", EnumMessageType.Information)
                End
            End If
            Call objTimeDelay.subTime_Delay(2000)
            objTimeDelay = Nothing
            Application.DoEvents()
            '---------------
            'INI_SETTINGS_PATH = Application.StartupPath & "\AAS.ini"
            ''---Initialize database settings
            'If funcInitializeAppDatabaseSettings() = True Then
            '    '---read configuration settings
            '    If Not gobjHardwareLock.gfuncGetConfigurationSetting() Then
            '        'display msg -error in configuration settings initialization
            '        Call gobjMessageAdapter.ShowMessage(constConfigurationError)
            '        Call Application.DoEvents()
            '        ''allow application to perfrom its panding work.
            '        End
            '    End If
            'Else
            '    '---display msg -error in database initialization
            '    Call gobjMessageAdapter.ShowMessage("AAS ini Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
            '    Call Application.DoEvents()
            '    End
            'End If
            '---------
            '--path of AAS.ini file 
            'INI_SETTINGS_PATH = Application.StartupPath & "\AAS.ini"

            '---Initialize database settings
            'If funcInitializeAppDatabaseSettings() = True Then
            '    '---read configuration settings
            '    If Not gobjHardwareLock.gfuncGetConfigurationSetting() Then
            '        'display msg -error in configuration settings initialization
            '        Call gobjMessageAdapter.ShowMessage(constConfigurationError)
            '        Call Application.DoEvents()
            '        ''allow application to perfrom its panding work.
            '        End
            '    End If
            'Else
            '    '---display msg -error in database initialization
            '    Call gobjMessageAdapter.ShowMessage("AAS ini Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
            '    Call Application.DoEvents()
            '    End
            'End If

            '---read hardware lock settings
            If gobjHardwareLock.gfuncReadHardwareLockSetting() = False Then
                If Not IsNothing(objfrmSplashScreen) Then
                    objfrmSplashScreen.Close()
                    objfrmSplashScreen.Dispose()
                    objfrmSplashScreen = Nothing
                End If
                gobjMessageAdapter.ShowMessage("Hardware Lock Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                ''prompt a error message if hardware lock failed.
                End
            End If

            '==========*********Modified by Saurabh**********=========
            If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                '--- To Get A New session ID and write it back to INI file.
                Call funcGetSessionID()

                '--- To Create Service LogBook Database Connection.
                Call gfuncCreateLogBookConnection()

                '--- To Create Userinfo Database Connection.
                Call gfuncCreateUserInfoConnection()

                '---Insert new row with new sessionsID and 
                '---insert current  Date , time and day 
                Call funcInsertLogData(gstructUserDetails.SessionID)
            Else
                '--- To Get A New session ID and write it back to INI file.
                Call funcGetSessionID()

                Call gfuncCreateLogBookConnection()

                Call gfuncCreateUserInfoConnection()

                gSetInstrumentStartTime = Date.Now
                gSetWStartTime = Date.Now
                gSetD2StartTime = Date.Now
            End If
            '=========================================================

            '--close and dispose splash screen
            If Not IsNothing(objfrmSplashScreen) Then
                objfrmSplashScreen.Close()
                Application.DoEvents()
                objfrmSplashScreen.Dispose()
                objfrmSplashScreen = Nothing
            End If

            'Saurabh 31.07.07 to Check for Hydride Mode
            '---if application is already in hydride mode then display message box.
            If gstructSettings.HydrideMode = 1 Then
                gobjMessageAdapter.ShowMessage("HYDRIDE MODE", "CONFIGURATION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Application.DoEvents()
            End If
            'Saurabh 31.07.07 to Check for Hydride Mode

            If gstructSettings.Enable21CFR = True Then
                ''check for 21 CFR

                Dim objfrmLogin As New frmLogin
                If objfrmLogin.ShowDialog() = DialogResult.OK Then
                    Application.DoEvents()
                    'If objfrmLogin.DialogResult = DialogResult.OK Then
                    If Not objfrmLogin.LoginSuccessfull Then
                        Exit Sub
                    End If
                Else
                    End
                End If
                Application.DoEvents()
            End If
            ''get a application path 
            Dim strConfigPath As String
            strConfigPath = Application.ExecutablePath
            strConfigPath = Right(strConfigPath, Len("AAS_Service.exe"))

            '---check which executable file to run
            If UCase(strConfigPath) = UCase("AAS_Service.exe") Then
                ''for normal application
                gstructSettings.EnableServiceUtility = True
                gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility
            Else
                ''for service utility
                gstructSettings.EnableServiceUtility = False
                gstructSettings.ExeToRun = EnumApplicationMode.AAS
            End If

            '---Initialize all global Variable here 
            gobjCommProtocol = New clsCommProtocolFunctions
            gobjfrmStatus = New frmStatus

            '--- Get the global variables from AAS.ini file
            Call gFuncLoadGlobals()


            '---Initialize gobjinst object
            If funcInitInstrumentSettings() = True Then
                If gstructSettings.AppMode = EnumAppMode.DemoMode Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                    '---if demo mode then load gobjinst object from serialized file
                    funcLoadInstStatus()
                End If
            End If

            Dim strAANameVersion As String
            Dim blnFlag As Boolean

            If gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
                'blnFlag = gobjCommProtocol.funcInitInstrument()
                blnFlag = True

            Else
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203 _
                               Or gstructSettings.AppMode = EnumAppMode.FullVersion_203D _
                               Or gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    ''check for the real mode of application
                    'If Not gstructSettings.EnableServiceUtility Then    'ToChange    
                    objfrmAASInitialisation = New frmAASInitialisation
                    ''show the initialization form and start the initialization here
                    objfrmAASInitialisation.Show()
                    If objfrmAASInitialisation.funcInstrumentInitialization() Then
                        ''start the initialization
                        'objfrmAASInitialisation.Close()
                        'objfrmAASInitialisation.Dispose()
                    Else
                        objfrmAASInitialisation.Close()
                        objfrmAASInitialisation.Dispose()
                        End
                        Exit Sub
                    End If
                    'Else

                    'End If
                End If
            End If
            Application.DoEvents()

            '---Load the Methods from serialized file.
            If Not funcLoadMethods() Then
                '---display Msg -error in loading methods

                '---commented on 10.04.09 for ver 4.85
                'Call gobjMessageAdapter.ShowMessage("Error in loading method settings file.", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                'Call Application.DoEvents()
                '----------------

                'End
            End If

            '---commented on 19.06.07
            ''check for the demo mode of application.
            If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam
            ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam
            ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
            End If

            'Saurabh 28.07.07 To set Instrument title
            ''set the instrument title as par application mode.

            '--4.85  14.04.09
            If gstructSettings.NewModelName = False Then
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
                    gstrTitleInstrumentType = CONST_AA203_FullVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                    gstrTitleInstrumentType = CONST_AA203D_FullVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    gstrTitleInstrumentType = CONST_AA201_FullVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    gstrTitleInstrumentType = CONST_AA203_DemoVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                    gstrTitleInstrumentType = CONST_AA203D_DemoVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    gstrTitleInstrumentType = CONST_AA201_DemoVersion
                Else
                    gstrTitleInstrumentType = CONST_AA203
                End If
            Else
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
                    gstrTitleInstrumentType = CONST_AA303_FullVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                    gstrTitleInstrumentType = CONST_AA303D_FullVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    gstrTitleInstrumentType = CONST_AA301_FullVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode Then
                    gstrTitleInstrumentType = CONST_AA303_DemoVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                    gstrTitleInstrumentType = CONST_AA303D_DemoVersion
                ElseIf gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    gstrTitleInstrumentType = CONST_AA301_DemoVersion
                Else
                    gstrTitleInstrumentType = CONST_AA303_FullVersion
                End If
            End If
            '--4.85  14.04.09

            'Saurabh 28.07.07 To set Instrument title

            If gstructSettings.EnableServiceUtility Then
                ''this will check which EXE to be run. either main exe or service exe.
                gobjMainService = New frmMDIMainService
                Call Application.Run(gobjMainService)
            Else
                gobjMain = New frmMDIMain
                If Not objfrmAASInitialisation Is Nothing Then
                    objfrmAASInitialisation.Close()
                    objfrmAASInitialisation.Dispose()
                End If
                Application.DoEvents()
                Call Application.Run(gobjMain)
            End If


            Call funcExitApplicationSettings()
            ''fir deinitialise the application setting
            ''It Exit Application parameters 
            gIntMethodID = 0

            '---added by deepak on 19.07.07 to reset the instrument
            '//----- Modified by Sachin Dokhale
            If gobjCommProtocol.mobjCommdll.gFuncIsPortOpen() Then
                '//-----
                gobjCommProtocol.funcResetInstrument()
                ''serial communication function  to  Reset the Instrument
            End If

            End

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub subErrorHandlerInitialization(ByRef objErrorHandlerIn As ErrorHandler.ErrorHandler)
        '=====================================================================
        ' Procedure Name        : gsubErrorHandlerInitialization
        ' Parameters Passed     : Global Object of Error HAndler
        ' Returns               : None
        ' Purpose               : To initialize error handling object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 14 sept 2004 11:30 am
        ' Revisions             : 
        '=====================================================================
        Try
            If IsNothing(gobjErrorHandler) = True Then
                gobjErrorHandler = New ErrorHandler.ErrorHandler
            End If
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

    Public Function funcInitializeAppDatabaseSettings() As Boolean
        '=====================================================================
        ' Procedure Name        : funcInitializeAppDatabaseSettings
        ' Parameters Passed     : None
        ' Returns               : True if DB settings are initialized; false otherwise.
        ' Purpose               : To get the database settings from the App.Config file
        '                         To construct the singleton object of clsDataAccess 
        ' Description           : Get the DataSourceType, Provider, DatabseName, Username, Password
        ' Assumptions           : App.Config file should be present with proper values.
        ' Dependencies          : app.config file and clsDataAccess
        ' Author                : Mangesh Shardul
        ' Created               : 06-Nov-2004 04:15 pm
        ' Revisions             : 1
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim strSystemDataBasePath As String
        Dim strBusinessDataBasePath As String
        Dim strIQOQPQDataBaseName As String
        Dim strIQOQPQDatabasePassword As String
        Dim strProvider As String
        Dim intDataSourceType As Integer
        Dim strUserName As String
        Dim strPassword As String
        Dim strSqlDataSource As String
        Dim strFactorDatabasePath As String
        Dim objConfig As Configuration.ConfigurationSettings
        Dim strConfigPath As String
        Dim strDatabasePath As String

        Try
            strConfigPath = Application.ExecutablePath & ".config"
            ''get a path of config file.
            'MessageBox.Show(strConfigPath.ToString)
            If Not System.IO.File.Exists(strConfigPath) Then
                '---display message "app.config file not found"
                'gobjMessageAdapter.ShowMessage(msgIDAppConfigFileNotFound)
            Else
                intDataSourceType = CInt(objConfig.AppSettings("DataSorceType"))
                strProvider = objConfig.AppSettings.Item("Provider")
                strUserName = objConfig.AppSettings.Item("User Name")
                strPassword = objConfig.AppSettings.Item("Password")
                strBusinessDataBasePath = objConfig.AppSettings.Item("BusinessDatabaseName")
                strSystemDataBasePath = objConfig.AppSettings.Item("SystemDatabaseName")
                strDatabasePath = objConfig.AppSettings.Item("DatabasePath")

                gobjDataAccess = New clsDataAccessLayer(intDataSourceType, strBusinessDataBasePath, strSystemDataBasePath, strProvider, strUserName, strPassword, strSqlDataSource, strDatabasePath)
                ''object of data access layer
            End If

            If IsNothing(gobjDataAccess) = False Then
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcLoadMethods() As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadMethods
        ' Parameters Passed     : 
        ' Returns               : 
        ' Purpose               : It loads all methods from method file
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 05.09.06
        ' Revisions             : 1
        ' Revision By           : Mangesh S. on 07-Apr-2007 for adding a filter
        '                         for loading Methods of selected Beam Type
        '=====================================================================
        Try
            '***************************************************************
            '---Commmented by Mangesh S. on 07-Apr-2007
            '***************************************************************
            'If File.Exists(Application.StartupPath & "\" & ConstMethodsFileName) = True Then
            '    Call funcDeSerialize(ConstMethodsFileName, gobjMethodCollection)
            'End If
            '***************************************************************

            '***************************************************************
            '---Added by Mangesh S. on 07-Apr-2007
            '***************************************************************
            Dim objAllMethodsCollection As AAS203Library.Method.clsMethodCollection
            Dim intCounter As Integer

            If funcLoadAllMethods(objAllMethodsCollection) Then
                If Not IsNothing(objAllMethodsCollection) Then
                    gobjMethodCollection = Nothing
                    gobjMethodCollection = New clsMethodCollection
                    For intCounter = 0 To objAllMethodsCollection.Count - 1
                        'If objAllMethodsCollection.item(intCounter).InstrumentBeamType = gintInstrumentBeamType Then
                        gobjMethodCollection.Add(objAllMethodsCollection.item(intCounter))
                        'End If
                    Next
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
            '***************************************************************

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return True
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Private Function funcInitInstrumentParameters() As Boolean
        '=====================================================================
        ' Procedure Name        : funcInitInstrumentParameters
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : It initialize instrument parameters to initial values
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 05.09.06
        ' Revisions             : 2 
        ' Revision By           : Mangesh S. on 14-Dec-2006
        '=====================================================================
        Try
            gobjInst = New AAS203Library.Instrument.ClsInstrument

            gobjInst.WavelengthCur = 100.0
            ''initialise the wavelength to 100.0 etc .
            gobjInst.Current = 0.0
            gobjInst.SlitPosition = 20

            '//----- Modified by Sachin Dokhale
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                gobjInst.Average = 10
                gobjInst.Lamp_Old = gobjClsAAS203.funcReadLampPosition() + 1
                gobjInst.Lamp_Position = gobjInst.Lamp_Old
            Else
                ''for other.
                gobjInst.Average = 300
                gobjInst.Lamp_Old = 1
                gobjInst.Lamp_Position = 1
            End If
            '//-----

            'gobjInst.Mode = AA
            gobjInst.PmtVoltage = 0
            gobjInst.D2Pmt = 0
            gobjInst.D2Current = 100
            gobjInst.ElementName = ""
            gobjInst.TurretPosition = 1
            gobjInst.NvStep = 0
            gobjInst.BhStep = -1
            gobjInst.Aaf = False
            gobjInst.N2of = False
            gobjInst.Na = False

            '//----- Modified by Sachin Dokhale on 24.01.07
            'gobjInst.Hydride = False
            If gstructSettings.HydrideMode = 1 Then
                gobjInst.Hydride = True
                HydrideMode = True
                If Not gobjfrmStatus Is Nothing Then
                    gobjfrmStatus.IsHydrideMode = True
                End If
            Else
                gobjInst.Hydride = False
                HydrideMode = False
                If Not gobjfrmStatus Is Nothing Then
                    gobjfrmStatus.IsHydrideMode = False
                End If
            End If
            '//-----

            '*********************************************************************
            '---For Double Beam Added by Mangesh on 06-Apr-2007
            '*********************************************************************
            gobjInst.PmtVoltageReference = 0.0
            gobjInst.SlitPositionExit = 20.0
            gobjInst.InstrumentBeamType = gintInstrumentBeamType
            '*********************************************************************

            gobjInst.Lamp_Warm = -1
            gobjInst.Lamp.WavelengthZero = 100
            gobjInst.Lamp.EMSCondition.ElementName = ""
            gobjInst.Lamp.EMSCondition.AtomicNumber = 0
            gobjInst.Lamp.EMSCondition.Wavelength = 0.0
            gobjInst.Lamp.EMSCondition.SlitWidth = 0.0

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Public Function funcInitInstrumentSettings() As Boolean
        '=====================================================================
        ' Procedure Name        : funcInitInstrumentSettings
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : It initialize instrument parameters to initial values
        ' Description           : to initialize gobjInst object variables
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 05.09.06
        ' Revisions             : 
        '=====================================================================
        Dim intPos As Integer
        Dim objLampParameters As ClsLampParameters

        Try
            '---Initialize global object of gobjInst
            Call funcInitInstrumentParameters()

            '---Initialize six position turret variables in gobjinst object
            For intPos = 0 To 5

                objLampParameters = New ClsLampParameters
                objLampParameters.LampOptimizePosition = -1
                objLampParameters.Mel = False
                objLampParameters.ElementName = ""
                objLampParameters.AtomicNumber = 0
                objLampParameters.Current = 0.0
                objLampParameters.Wavelength = 0.0
                objLampParameters.SlitWidth = 2.0
                objLampParameters.Mode = 0
                objLampParameters.Burner = True

                gobjInst.Lamp.LampParametersCollection.Add(objLampParameters)
            Next

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Public Function funcExitApplicationSettings() As Boolean
        '=====================================================================
        ' Procedure Name        : funcExitApplicationSettings
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : It Exit Application parameters 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 24.01.07
        ' Revisions             : 
        '=====================================================================
        Dim intPos As Integer
        'Dim objLampParameters As ClsLampParameters

        Try
            '//----- Added by Sachin Dokhale 
            '//----- Flame Off the instrument at time of exit from application if is ignited
            If gobjInst.Aaf = True Or gobjInst.N2of = True Then
                gobjClsAAS203.funcIgnite(False)
            End If
            '//----

            '---Initialize global object of gobjInst
            'Call funcInitInstrumentParameters()
            Call gobjHardwareLock.gfuncSaveConfigurationSetting()
            'Call funcLoadInstStatus()
            gobjCommProtocol.funcSave_BH_Pos()
            ''serial communication function for saving a burner height 
            gobjCommProtocol.funcSave_NV_Pos()
            ''serial communication function for setting NV position.
            '--- Set InstReset continuous flag
            gblnIsInstReset = False
            gfuncSetInstReset_continuousToINI(gblnIsInstReset)

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            ''allow application to perfrom its panding work.
        End Try
    End Function

    Function funcGetSessionID()
        '=====================================================================
        ' Procedure Name        : funcGetSessionID
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : this is used to get session info.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 24.01.07
        ' Revisions             : 
        '=====================================================================
        'Dim lngSessionID As Long
        Try

            'comented by kamal
            'for reading the data  from the config file rather from ini file
            'If gfuncGetSessionIDFromINI(lngSessionID) Then
            '    lngSessionID += 1
            '    If gfuncSaveSessionIDtoINIFIle(lngSessionID) Then
            '        gstructUserDetails.SessionID = lngSessionID
            '    End If
            'End If
            '---------------------------------------------------

            gstructSettings.SessionID += 1
            gstructUserDetails.SessionID = gstructSettings.SessionID

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

    <System.Diagnostics.DebuggerStepThrough()> Function PrevInstance() As Boolean
        '=====================================================================
        ' Procedure Name        : PrevInstance
        ' Parameters Passed     : 
        ' Returns               : True or False
        ' Purpose               : this is used to fins that previous application is running or not.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 24.01.07
        ' Revisions             : 
        '=====================================================================
        Try
            If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
                'If UBound(System.Diagnostics.Process.GetProcessesByName("AAS.EXE", "RNDSERVER\\soft1")) > 0 Then
                gobjMessageAdapter.ShowMessage(Diagnostics.Process.GetCurrentProcess.ProcessName, "Diagnostics", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Return True
            Else
                ' gobjMessageAdapter.ShowMessage(Diagnostics.Process.GetCurrentProcess.ProcessName, "Diagnostics", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                Return False
            End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            'gobjErrorHandler.ErrorDescription = ex.Message
            'gobjErrorHandler.ErrorMessage = ex.Message
            'gobjErrorHandler.WriteErrorLog(ex)
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

End Module
