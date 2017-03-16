
 // ERROR: Not supported in C#: OptionDeclaration
using System;
using System.IO;
using AAS203.Common;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.ComponentModel;

using AAS203Library;
using AAS203Library.Instrument;
using AAS203Library.Method;

class modMain
{
	public void main()
	{
		//=====================================================================
		// Procedure Name        : Main
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Start of the software
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 05.09.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is first starting point of software
		//'this is a function which called first.
		//'do some software initialisation step here.
		//'like checking for user, checking for dependencies etc.

		frmSplash objfrmSplashScreen = new frmSplash();
		frmAASInitialisation objfrmAASInitialisation;
		bool blnResetCmd = false;
		string strPath;
		clsTimer objTimeDelay = new clsTimer(null, 5000);
		bool blnIsUpgradeSessionID;

		try {
			//---Initialize error handler
			subErrorHandlerInitialization(gobjErrorHandler);
			//'Added by pankaj on 29 Jan 08
			INI_SETTINGS_PATH = Application.StartupPath + "\\AAS.ini";
			//---Initialize database settings
			if (funcInitializeAppDatabaseSettings() == true) {
				//---read configuration settings
				if (!gobjHardwareLock.gfuncGetConfigurationSetting()) {
					//display msg -error in configuration settings initialization
					gobjMessageAdapter.ShowMessage(constConfigurationError);
					Application.DoEvents();
					//'allow application to perfrom its panding work.
					System.Environment.Exit(0);
				}
			} else {
				//---display msg -error in database initialization
				gobjMessageAdapter.ShowMessage("AAS ini Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				Application.DoEvents();
				System.Environment.Exit(0);
			}
			//'---------
			//---Display Splash screen
			objfrmSplashScreen.Show();
			//'put a delay of 3000 for splash screen.
			//Call objTimeDelay.subTime_Delay(2000)
			Application.DoEvents();
			//'now allow application to perfrom its panding work
			////----- Added by Sachin Dokhale
			//objTimeDelay = Nothing
			////-----
			//'--- Check for the previous instance of the application
			if (PrevInstance()) {
				//'this function will find that ,is there any other instance of software is running
				//'or not.If running then prompt a message.
				gobjMessageAdapter.ShowMessage("Application Busy", "One instance of the application is already running" + vbCrLf + "Please close the previous instance", EnumMessageType.Information);
				System.Environment.Exit(0);
			}
			objTimeDelay.subTime_Delay(2000);
			objTimeDelay = null;
			Application.DoEvents();
			//---------------
			//INI_SETTINGS_PATH = Application.StartupPath & "\AAS.ini"
			//'---Initialize database settings
			//If funcInitializeAppDatabaseSettings() = True Then
			//    '---read configuration settings
			//    If Not gobjHardwareLock.gfuncGetConfigurationSetting() Then
			//        'display msg -error in configuration settings initialization
			//        Call gobjMessageAdapter.ShowMessage(constConfigurationError)
			//        Call Application.DoEvents()
			//        ''allow application to perfrom its panding work.
			//        End
			//    End If
			//Else
			//    '---display msg -error in database initialization
			//    Call gobjMessageAdapter.ShowMessage("AAS ini Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
			//    Call Application.DoEvents()
			//    End
			//End If
			//---------
			//--path of AAS.ini file 
			//INI_SETTINGS_PATH = Application.StartupPath & "\AAS.ini"

			//---Initialize database settings
			//If funcInitializeAppDatabaseSettings() = True Then
			//    '---read configuration settings
			//    If Not gobjHardwareLock.gfuncGetConfigurationSetting() Then
			//        'display msg -error in configuration settings initialization
			//        Call gobjMessageAdapter.ShowMessage(constConfigurationError)
			//        Call Application.DoEvents()
			//        ''allow application to perfrom its panding work.
			//        End
			//    End If
			//Else
			//    '---display msg -error in database initialization
			//    Call gobjMessageAdapter.ShowMessage("AAS ini Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
			//    Call Application.DoEvents()
			//    End
			//End If

			//---read hardware lock settings
			if (gobjHardwareLock.gfuncReadHardwareLockSetting() == false) {
				if (!IsNothing(objfrmSplashScreen)) {
					objfrmSplashScreen.Close();
					objfrmSplashScreen.Dispose();
					objfrmSplashScreen = null;
				}
				gobjMessageAdapter.ShowMessage("Hardware Lock Error", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				//'prompt a error message if hardware lock failed.
				System.Environment.Exit(0);
			}

			//==========*********Modified by Saurabh**********=========
			if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
				//--- To Get A New session ID and write it back to INI file.
				funcGetSessionID();

				//--- To Create Service LogBook Database Connection.
				gfuncCreateLogBookConnection();

				//--- To Create Userinfo Database Connection.
				gfuncCreateUserInfoConnection();

				//---Insert new row with new sessionsID and 
				//---insert current  Date , time and day 
				funcInsertLogData(gstructUserDetails.SessionID);
			} else {
				//--- To Get A New session ID and write it back to INI file.
				funcGetSessionID();

				gfuncCreateLogBookConnection();

				gfuncCreateUserInfoConnection();

				gSetInstrumentStartTime = System.DateTime.Now;
				gSetWStartTime = System.DateTime.Now;
				gSetD2StartTime = System.DateTime.Now;
			}
			//=========================================================

			//--close and dispose splash screen
			if (!IsNothing(objfrmSplashScreen)) {
				objfrmSplashScreen.Close();
				Application.DoEvents();
				objfrmSplashScreen.Dispose();
				objfrmSplashScreen = null;
			}

			//Saurabh 31.07.07 to Check for Hydride Mode
			//---if application is already in hydride mode then display message box.
			if (gstructSettings.HydrideMode == 1) {
				gobjMessageAdapter.ShowMessage("HYDRIDE MODE", "CONFIGURATION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				Application.DoEvents();
			}
			//Saurabh 31.07.07 to Check for Hydride Mode

			if (gstructSettings.Enable21CFR == true) {
				//'check for 21 CFR

				frmLogin objfrmLogin = new frmLogin();
				if (objfrmLogin.ShowDialog() == DialogResult.OK) {
					Application.DoEvents();
					//If objfrmLogin.DialogResult = DialogResult.OK Then
					if (!objfrmLogin.LoginSuccessfull) {
						return;
					}
				} else {
					System.Environment.Exit(0);
				}
				Application.DoEvents();
			}
			//'get a application path 
			string strConfigPath;
			strConfigPath = Application.ExecutablePath;
			strConfigPath = Right(strConfigPath, Len("AAS_Service.exe"));

			//---check which executable file to run
			if (UCase(strConfigPath) == UCase("AAS_Service.exe")) {
				//'for normal application
				gstructSettings.EnableServiceUtility = true;
				gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility;
			} else {
				//'for service utility
				gstructSettings.EnableServiceUtility = false;
				gstructSettings.ExeToRun = EnumApplicationMode.AAS;
			}

			//---Initialize all global Variable here 
			gobjCommProtocol = new clsCommProtocolFunctions();
			gobjfrmStatus = new frmStatus();

			//--- Get the global variables from AAS.ini file
			gFuncLoadGlobals();


			//---Initialize gobjinst object
			if (funcInitInstrumentSettings() == true) {
				if (gstructSettings.AppMode == EnumAppMode.DemoMode | gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
					//---if demo mode then load gobjinst object from serialized file
					funcLoadInstStatus();
				}
			}

			string strAANameVersion;
			bool blnFlag;

			if (gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				//blnFlag = gobjCommProtocol.funcInitInstrument()
				blnFlag = true;

			} else {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					//'check for the real mode of application
					//If Not gstructSettings.EnableServiceUtility Then    'ToChange    
					objfrmAASInitialisation = new frmAASInitialisation();
					//'show the initialization form and start the initialization here
					objfrmAASInitialisation.Show();
					if (objfrmAASInitialisation.funcInstrumentInitialization()) {
					//'start the initialization
					//objfrmAASInitialisation.Close()
					//objfrmAASInitialisation.Dispose()
					} else {
						objfrmAASInitialisation.Close();
						objfrmAASInitialisation.Dispose();
						System.Environment.Exit(0);
						return;
					}
					//Else

					//End If
				}
			}
			Application.DoEvents();

			//---Load the Methods from serialized file.
			if (!funcLoadMethods()) {
				//---display Msg -error in loading methods

				//---commented on 10.04.09 for ver 4.85
				//Call gobjMessageAdapter.ShowMessage("Error in loading method settings file.", "Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
				//Call Application.DoEvents()
				//----------------

				//End
			}

			//---commented on 19.06.07
			//'check for the demo mode of application.
			if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam;
			} else if (gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam;
			} else if (gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
			}

			//Saurabh 28.07.07 To set Instrument title
			//'set the instrument title as par application mode.

			//--4.85  14.04.09
			if (gstructSettings.NewModelName == false) {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203) {
					gstrTitleInstrumentType = CONST_AA203_FullVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
					gstrTitleInstrumentType = CONST_AA203D_FullVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					gstrTitleInstrumentType = CONST_AA201_FullVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
					gstrTitleInstrumentType = CONST_AA203_DemoVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
					gstrTitleInstrumentType = CONST_AA203D_DemoVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					gstrTitleInstrumentType = CONST_AA201_DemoVersion;
				} else {
					gstrTitleInstrumentType = CONST_AA203;
				}
			} else {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203) {
					gstrTitleInstrumentType = CONST_AA303_FullVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
					gstrTitleInstrumentType = CONST_AA303D_FullVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					gstrTitleInstrumentType = CONST_AA301_FullVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
					gstrTitleInstrumentType = CONST_AA303_DemoVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
					gstrTitleInstrumentType = CONST_AA303D_DemoVersion;
				} else if (gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
					gstrTitleInstrumentType = CONST_AA301_DemoVersion;
				} else {
					gstrTitleInstrumentType = CONST_AA303_FullVersion;
				}
			}
			//--4.85  14.04.09

			//Saurabh 28.07.07 To set Instrument title

			if (gstructSettings.EnableServiceUtility) {
				//'this will check which EXE to be run. either main exe or service exe.
				gobjMainService = new frmMDIMainService();
				Application.Run(gobjMainService);
			} else {
				gobjMain = new frmMDIMain();
				if (!objfrmAASInitialisation == null) {
					objfrmAASInitialisation.Close();
					objfrmAASInitialisation.Dispose();
				}
				Application.DoEvents();
				Application.Run(gobjMain);
			}


			funcExitApplicationSettings();
			//'fir deinitialise the application setting
			//'It Exit Application parameters 
			gIntMethodID = 0;

			//---added by deepak on 19.07.07 to reset the instrument
			////----- Modified by Sachin Dokhale
			if (gobjCommProtocol.mobjCommdll.gFuncIsPortOpen()) {
				////-----
				gobjCommProtocol.funcResetInstrument();
				//'serial communication function  to  Reset the Instrument
			}

			System.Environment.Exit(0);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	public void subErrorHandlerInitialization(ref ErrorHandler.ErrorHandler objErrorHandlerIn)
	{
		//=====================================================================
		// Procedure Name        : gsubErrorHandlerInitialization
		// Parameters Passed     : Global Object of Error HAndler
		// Returns               : None
		// Purpose               : To initialize error handling object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14 sept 2004 11:30 am
		// Revisions             : 
		//=====================================================================
		try {
			if (IsNothing(gobjErrorHandler) == true) {
				gobjErrorHandler = new ErrorHandler.ErrorHandler();
			}
			objErrorHandlerIn.CompanyName = Application.ProductName;
			objErrorHandlerIn.ErrorLogFolder = "ErrorLogs";
			objErrorHandlerIn.ErrorLogFileName = Application.StartupPath + "\\" + objErrorHandlerIn.ErrorLogFolder + "\\ErrorLog-" + DateAndTime.DateString + "-" + DateAndTime.Hour(Now) + "-" + DateAndTime.Minute(Now) + "-" + DateAndTime.Second(Now) + ".log";
			objErrorHandlerIn.VersionMajor = Application.ProductVersion;
			objErrorHandlerIn.ProductName = Application.ProductName;

			objErrorHandlerIn.ExecutionTrailFolder = "ExecutionLogs";
			objErrorHandlerIn.ExecutionLogFileName = Application.StartupPath + "\\" + objErrorHandlerIn.ExecutionTrailFolder + "\\ExecutionLog-" + DateAndTime.DateString + "-" + DateAndTime.Hour(Now) + "-" + DateAndTime.Minute(Now) + "-" + DateAndTime.Second(Now) + ".log";

			//--- Check for the folders if not create the folders
			if (!Directory.Exists(Application.StartupPath + "\\" + objErrorHandlerIn.ErrorLogFolder)) {
				//--- Create the folder
				Directory.CreateDirectory(Application.StartupPath + "\\" + objErrorHandlerIn.ErrorLogFolder);
			}

			if (!Directory.Exists(Application.StartupPath + "\\" + objErrorHandlerIn.ExecutionTrailFolder)) {
				//--- Create the folder
				Directory.CreateDirectory(Application.StartupPath + "\\" + objErrorHandlerIn.ExecutionTrailFolder);
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	public bool funcInitializeAppDatabaseSettings()
	{
		//=====================================================================
		// Procedure Name        : funcInitializeAppDatabaseSettings
		// Parameters Passed     : None
		// Returns               : True if DB settings are initialized; false otherwise.
		// Purpose               : To get the database settings from the App.Config file
		//                         To construct the singleton object of clsDataAccess 
		// Description           : Get the DataSourceType, Provider, DatabseName, Username, Password
		// Assumptions           : App.Config file should be present with proper values.
		// Dependencies          : app.config file and clsDataAccess
		// Author                : Mangesh Shardul
		// Created               : 06-Nov-2004 04:15 pm
		// Revisions             : 1
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		string strSystemDataBasePath;
		string strBusinessDataBasePath;
		string strIQOQPQDataBaseName;
		string strIQOQPQDatabasePassword;
		string strProvider;
		int intDataSourceType;
		string strUserName;
		string strPassword;
		string strSqlDataSource;
		string strFactorDatabasePath;
		Configuration.ConfigurationSettings objConfig;
		string strConfigPath;
		string strDatabasePath;

		try {
			strConfigPath = Application.ExecutablePath + ".config";
			//'get a path of config file.
			//MessageBox.Show(strConfigPath.ToString)
			if (!System.IO.File.Exists(strConfigPath)) {
			//---display message "app.config file not found"
			//gobjMessageAdapter.ShowMessage(msgIDAppConfigFileNotFound)
			} else {
				intDataSourceType = (int)objConfig.AppSettings("DataSorceType");
				strProvider = objConfig.AppSettings.Item("Provider");
				strUserName = objConfig.AppSettings.Item("User Name");
				strPassword = objConfig.AppSettings.Item("Password");
				strBusinessDataBasePath = objConfig.AppSettings.Item("BusinessDatabaseName");
				strSystemDataBasePath = objConfig.AppSettings.Item("SystemDatabaseName");
				strDatabasePath = objConfig.AppSettings.Item("DatabasePath");

				gobjDataAccess = new clsDataAccessLayer(intDataSourceType, strBusinessDataBasePath, strSystemDataBasePath, strProvider, strUserName, strPassword, strSqlDataSource, strDatabasePath);
				//'object of data access layer
			}

			if (IsNothing(gobjDataAccess) == false) {
				return true;
			} else {
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	public bool funcLoadMethods()
	{
		//=====================================================================
		// Procedure Name        : funcLoadMethods
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : It loads all methods from method file
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 05.09.06
		// Revisions             : 1
		// Revision By           : Mangesh S. on 07-Apr-2007 for adding a filter
		//                         for loading Methods of selected Beam Type
		//=====================================================================
		try {
			//***************************************************************
			//---Commmented by Mangesh S. on 07-Apr-2007
			//***************************************************************
			//If File.Exists(Application.StartupPath & "\" & ConstMethodsFileName) = True Then
			//    Call funcDeSerialize(ConstMethodsFileName, gobjMethodCollection)
			//End If
			//***************************************************************

			//***************************************************************
			//---Added by Mangesh S. on 07-Apr-2007
			//***************************************************************
			AAS203Library.Method.clsMethodCollection objAllMethodsCollection;
			int intCounter;

			if (funcLoadAllMethods(objAllMethodsCollection)) {
				if (!IsNothing(objAllMethodsCollection)) {
					gobjMethodCollection = null;
					gobjMethodCollection = new clsMethodCollection();
					for (intCounter = 0; intCounter <= objAllMethodsCollection.Count - 1; intCounter++) {
						//If objAllMethodsCollection.item(intCounter).InstrumentBeamType = gintInstrumentBeamType Then
						gobjMethodCollection.Add(objAllMethodsCollection.item(intCounter));
						//End If
					}
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}
		//***************************************************************

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return true;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}

	private bool funcInitInstrumentParameters()
	{
		//=====================================================================
		// Procedure Name        : funcInitInstrumentParameters
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : It initialize instrument parameters to initial values
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 05.09.06
		// Revisions             : 2 
		// Revision By           : Mangesh S. on 14-Dec-2006
		//=====================================================================
		try {
			gobjInst = new AAS203Library.Instrument.ClsInstrument();

			gobjInst.WavelengthCur = 100.0;
			//'initialise the wavelength to 100.0 etc .
			gobjInst.Current = 0.0;
			gobjInst.SlitPosition = 20;

			////----- Modified by Sachin Dokhale
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				gobjInst.Average = 10;
				gobjInst.Lamp_Old = gobjClsAAS203.funcReadLampPosition() + 1;
				gobjInst.Lamp_Position = gobjInst.Lamp_Old;
			} else {
				//'for other.
				gobjInst.Average = 300;
				gobjInst.Lamp_Old = 1;
				gobjInst.Lamp_Position = 1;
			}
			////-----

			//gobjInst.Mode = AA
			gobjInst.PmtVoltage = 0;
			gobjInst.D2Pmt = 0;
			gobjInst.D2Current = 100;
			gobjInst.ElementName = "";
			gobjInst.TurretPosition = 1;
			gobjInst.NvStep = 0;
			gobjInst.BhStep = -1;
			gobjInst.Aaf = false;
			gobjInst.N2of = false;
			gobjInst.Na = false;

			////----- Modified by Sachin Dokhale on 24.01.07
			//gobjInst.Hydride = False
			if (gstructSettings.HydrideMode == 1) {
				gobjInst.Hydride = true;
				HydrideMode = true;
				if (!gobjfrmStatus == null) {
					gobjfrmStatus.IsHydrideMode = true;
				}
			} else {
				gobjInst.Hydride = false;
				HydrideMode = false;
				if (!gobjfrmStatus == null) {
					gobjfrmStatus.IsHydrideMode = false;
				}
			}
			////-----

			//*********************************************************************
			//---For Double Beam Added by Mangesh on 06-Apr-2007
			//*********************************************************************
			gobjInst.PmtVoltageReference = 0.0;
			gobjInst.SlitPositionExit = 20.0;
			gobjInst.InstrumentBeamType = gintInstrumentBeamType;
			//*********************************************************************

			gobjInst.Lamp_Warm = -1;
			gobjInst.Lamp.WavelengthZero = 100;
			gobjInst.Lamp.EMSCondition.ElementName = "";
			gobjInst.Lamp.EMSCondition.AtomicNumber = 0;
			gobjInst.Lamp.EMSCondition.Wavelength = 0.0;
			gobjInst.Lamp.EMSCondition.SlitWidth = 0.0;

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}

	public bool funcInitInstrumentSettings()
	{
		//=====================================================================
		// Procedure Name        : funcInitInstrumentSettings
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : It initialize instrument parameters to initial values
		// Description           : to initialize gobjInst object variables
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 05.09.06
		// Revisions             : 
		//=====================================================================
		int intPos;
		ClsLampParameters objLampParameters;

		try {
			//---Initialize global object of gobjInst
			funcInitInstrumentParameters();

			//---Initialize six position turret variables in gobjinst object

			for (intPos = 0; intPos <= 5; intPos++) {
				objLampParameters = new ClsLampParameters();
				objLampParameters.LampOptimizePosition = -1;
				objLampParameters.Mel = false;
				objLampParameters.ElementName = "";
				objLampParameters.AtomicNumber = 0;
				objLampParameters.Current = 0.0;
				objLampParameters.Wavelength = 0.0;
				objLampParameters.SlitWidth = 2.0;
				objLampParameters.Mode = 0;
				objLampParameters.Burner = true;

				gobjInst.Lamp.LampParametersCollection.Add(objLampParameters);
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}

	public bool funcExitApplicationSettings()
	{
		//=====================================================================
		// Procedure Name        : funcExitApplicationSettings
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : It Exit Application parameters 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 24.01.07
		// Revisions             : 
		//=====================================================================
		int intPos;
		//Dim objLampParameters As ClsLampParameters

		try {
			////----- Added by Sachin Dokhale 
			////----- Flame Off the instrument at time of exit from application if is ignited
			if (gobjInst.Aaf == true | gobjInst.N2of == true) {
				gobjClsAAS203.funcIgnite(false);
			}
			////----

			//---Initialize global object of gobjInst
			//Call funcInitInstrumentParameters()
			gobjHardwareLock.gfuncSaveConfigurationSetting();
			//Call funcLoadInstStatus()
			gobjCommProtocol.funcSave_BH_Pos();
			//'serial communication function for saving a burner height 
			gobjCommProtocol.funcSave_NV_Pos();
			//'serial communication function for setting NV position.
			//--- Set InstReset continuous flag
			gblnIsInstReset = false;
			gfuncSetInstReset_continuousToINI(gblnIsInstReset);

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.
		}
	}

	private object funcGetSessionID()
	{
		//=====================================================================
		// Procedure Name        : funcGetSessionID
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : this is used to get session info.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 24.01.07
		// Revisions             : 
		//=====================================================================
		//Dim lngSessionID As Long

		try {
			//comented by kamal
			//for reading the data  from the config file rather from ini file
			//If gfuncGetSessionIDFromINI(lngSessionID) Then
			//    lngSessionID += 1
			//    If gfuncSaveSessionIDtoINIFIle(lngSessionID) Then
			//        gstructUserDetails.SessionID = lngSessionID
			//    End If
			//End If
			//---------------------------------------------------

			gstructSettings.SessionID += 1;
			gstructUserDetails.SessionID = gstructSettings.SessionID;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	[System.Diagnostics.DebuggerStepThrough()]
	private bool PrevInstance()
	{
		//=====================================================================
		// Procedure Name        : PrevInstance
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : this is used to fins that previous application is running or not.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 24.01.07
		// Revisions             : 
		//=====================================================================
		try {
			if (UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0) {
				//If UBound(System.Diagnostics.Process.GetProcessesByName("AAS.EXE", "RNDSERVER\\soft1")) > 0 Then
				gobjMessageAdapter.ShowMessage(Diagnostics.Process.GetCurrentProcess.ProcessName, "Diagnostics", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				return true;
			} else {
				// gobjMessageAdapter.ShowMessage(Diagnostics.Process.GetCurrentProcess.ProcessName, "Diagnostics", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
				return false;
			}


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			//gobjErrorHandler.ErrorDescription = ex.Message
			//gobjErrorHandler.ErrorMessage = ex.Message
			//gobjErrorHandler.WriteErrorLog(ex)
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

}
