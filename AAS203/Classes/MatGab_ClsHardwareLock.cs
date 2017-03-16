
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.IO;
using AAS203.Common;

public class clsHardwareLock
{

	private const  CONST_TEMP_FILE = "config.tmp";

	private const  CONST_CONFIG_FILE_NAME = "AAS203.config";
	#Region " Import/Declare DLL's "

	[DllImport("sentrydll5.dll")]
	private static int win_xread_nt95(ref Int16 rbuff, ref byte pass)
	{
		//Long
	}

	[DllImport("sentrydll5.dll")]
	private static int win_xwrite_nt95(ref Int16 rbuff, ref Int16 wbuff, ref byte pass)
	{
		//Long
	}


	//--- API declarations for reading the data from the INI file.


	#End Region

	#Region " Public Functions "

 // ERROR: Not supported in C#: DeclareDeclaration
 // ERROR: Not supported in C#: DeclareDeclaration
	private bool WriteHardwareKey(string strKey)
	{
		Int16[] rbuff = new Int16[10];
		Int16[] int16Signature = new Int16[10];
		Int32 int32TempSignature;

		Int32 temp;
		byte[] pass = new byte[2];
		int stat;
		byte[] strTemp = new byte[19];
		string strString;
		string[] strSignature = new string[22];

		char[] chrKey = new char[22];

		int i;
		int intCounter;
		CWaitCursor cWait;

		for (intCounter = 0; intCounter <= 23; intCounter++) {
			chrKey(intCounter) = strKey.Chars(intCounter);
		}

		for (intCounter = 0; intCounter <= 23; intCounter += 2) {
			strSignature(intCounter / 2) = "&H" + Hex(Asc(chrKey(intCounter))) + Hex(Asc(chrKey(intCounter + 1)));
			int32TempSignature = (Int32)strSignature(intCounter / 2);

			if (int32TempSignature > 32767) {
				int16Signature(intCounter / 2) = int32TempSignature - 65536;
			} else {
				int16Signature(intCounter / 2) = int32TempSignature;
			}
		}

		pass(0) = 78;
		pass(1) = 80;
		pass(2) = 67;
		pass(3) = 72;

		for (i = 0; i <= 11; i++) {
			rbuff(i) = 0;
		}

		rbuff(0) = 21334;
		rbuff(1) = 13910;
		rbuff(2) = 17232;
		rbuff(3) = 18477;
		rbuff(4) = 22097;
		rbuff(5) = 14645;
		rbuff(6) = 11600;
		rbuff(7) = 13622;
		rbuff(8) = 19274;
		rbuff(9) = 13874;
		rbuff(10) = 8224;
		rbuff(11) = 8224;

		stat = win_xwrite_nt95(rbuff(0), int16Signature(0), pass(0));
		switch (stat) {
			case 0:
				//            Text5.Text = "Lock Found! Data written Successfully, the one assigned to Signature varibale!!!"
				//gFuncShowMessage("Hardware Lock Check", "Lock Found! Key set successfully!!!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(52);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return true;
			case -1:
				// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
				//gFuncShowMessage("Hardware Lock Error", "Hardware lock not installed OR " & vbCrLf & " the one installed is not having proper identity", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(53);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -2:
				//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
				//gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(54);
				Application.DoEvents();
				cWait = new CWaitCursor();

				return false;
			case -3:
				//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
				// gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(62);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -5:
				//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(55);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -6:
				//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(56);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -7:
				//Text5.Text = " The memory location index entered is out of range (0-29)!"
				//gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(57);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -8:
				//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
				//gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(58);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -9:
				//Text5.Text = " Cannot work on Win3.1!"
				//gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(59);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -10:
				//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
				//gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(60);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
		}

	}

	private bool ReadHardwareKey(string strKey)
	{
		Int16[] rbuff = new Int16[10];
		Int16[] int16Signature = new Int16[10];
		Int32 int32TempSignature;

		Int32 temp;
		byte[] pass = new byte[2];
		int stat;
		//eger 'Long
		byte[] strTemp = new byte[19];
		string strString;
		string[] strSignature = new string[22];

		char[] chrKey = new char[22];

		int i;
		int intCounter;
		CWaitCursor cWait;


		for (intCounter = 0; intCounter <= 23; intCounter++) {
			chrKey(intCounter) = strKey.Chars(intCounter);
		}
		for (intCounter = 0; intCounter <= 23; intCounter += 2) {
			strSignature(intCounter / 2) = "&H" + Hex(Asc(chrKey(intCounter))) + Hex(Asc(chrKey(intCounter + 1)));
			int32TempSignature = (Int32)strSignature(intCounter / 2);

			if (int32TempSignature > 32767) {
				int16Signature(intCounter / 2) = int32TempSignature - 65536;
			} else {
				int16Signature(intCounter / 2) = int32TempSignature;
			}
		}

		// Fill pass array with your password, which should be hex, refer keyxxxx.txt

		pass(0) = 78;
		pass(1) = 80;
		pass(2) = 67;
		pass(3) = 72;

		for (i = 0; i <= 11; i++) {
			rbuff(i) = 0;
		}

		//Fill rbuff with your  key (refer keyxxxx.txt)

		rbuff(0) = 21334;
		rbuff(1) = 13910;
		rbuff(2) = 17232;
		rbuff(3) = 18477;
		rbuff(4) = 22097;
		rbuff(5) = 14645;
		rbuff(6) = 11600;
		rbuff(7) = 13622;
		rbuff(8) = 19274;
		rbuff(9) = 13874;
		rbuff(10) = 8224;
		rbuff(11) = 8224;

		stat = win_xread_nt95(rbuff(0), pass(0));

		switch (stat) {
			case 0:

				for (i = 0; i <= 11; i++) {
					if ((rbuff(i) != int16Signature(i)))
						break; // TODO: might not be correct. Was : Exit For
				}

				if ((i < 11)) {
					//gFuncShowMessage("Hardware Lock Error", "Lock Found! Data Read from the lock is not matching with the one assigned to hardware key!", modConstants.EnumMessageType.Information)
					gobjMessageAdapter.ShowMessage(61);
					Application.DoEvents();
					cWait = new CWaitCursor();
					return false;
				} else {
					// gFuncShowMessage("Hardware Lock", "Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!", modConstants.EnumMessageType.Information)
					return true;

				}
			case -1:
				// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
				//gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the one installed is not bearing proper identity", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(53);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -2:
				//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
				//gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(54);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -3:
				//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
				//gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(62);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -5:
				//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(55);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -6:
				//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(56);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -7:
				//Text5.Text = " The memory location index entered is out of range (0-29)!"
				//gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(57);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -8:
				//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
				//gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(58);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -9:
				//Text5.Text = " Cannot work on Win3.1!"
				//gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(59);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
			case -10:
				//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
				//gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(60);
				Application.DoEvents();
				cWait = new CWaitCursor();
				return false;
		}


	}

	private System.DateTime GetRTCDataTime()
	{
		System.DateTime dtRtcDtTime;
	}

	public string gFuncGetFromINI(string strSection, string strKeyValue, string strDefaultString, string StrINIFilePath)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncGetFromINI
		//Description:   To retrieve the key vale of a specified Section From INI
		//Parameters :   Section, Key , DefaultKeyValue, strFullPath of the INI
		//Time/Date  :   1.09 12'Oct 2004
		//Dependencies:  INI File Should exist
		//Author:    M.kamal
		//Revision: 
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		Int32 intBffer = 255;
		string strReturnString = Space(intBffer);
		gFuncGetFromINI = "";

		//If (GetPrivateProfileString(section, key, sDefault, strReturnString, intBffer, strINI_FileName) <> 0) Then
		//    Return CStr(strReturnString)
		//Else
		//    Throw New Exception("Error in reading the system parameters INI file.")
		//End If
		try {
			//--- To get the specified key value
			GetPrivateProfileString(Trim(strSection), Trim(strKeyValue), Trim(strDefaultString), strReturnString, intBffer, Trim(StrINIFilePath));
			strReturnString = (string)Replace(Trim(strReturnString), Chr(0), "") + "";
			gFuncGetFromINI = strReturnString;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//'---------------------------------------------------------
			//'Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//'---------------------------------------------------------
		}

	}

	public bool gFuncWriteToINI(string strSection, string strKey, string strKeyValues, string strINIFilePath)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncWriteToINI
		//Description:       To write the specified string to the Key of the given Setion of the INI
		//Parameters :   `   Section Name, KeyName, KeyValue, INI File PAth
		//Time/Date  :       29 Dec 2004
		//Dependencies:      INI File Should Present Prior
		//Author:           M.kamal
		//Revision:          _
		//Revision by Person: _
		//--------------------------------------------------------------------------------------
		bool bln;
		gFuncWriteToINI = bln;
		try {
			bln = WritePrivateProfileString(Trim(strSection.ToString), Trim(strKey.ToString), Trim(strKeyValues.ToString), Trim(strINIFilePath.ToString));
			gFuncWriteToINI = bln;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//'---------------------------------------------------------
			//'Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//'---------------------------------------------------------
		}


	}

	#End Region

	#Region " Configuration Settings "

	public bool gfuncGetConfigurationSetting()
	{
		string strFileName;

		try {
			//Get the configuration settings from the config file
			//and store the data on the global structure
			//------------------------------------e---------------------
			//1. Check for the config file, if not found get the file.
			//2. Read configuration setting.
			//---------------------------------------------------------
			strFileName = Application.StartupPath + "\\" + CONST_CONFIG_FILE_NAME;

			//1. Check for the config file, if not found get the file.
			if (!File.Exists(Application.StartupPath + "\\" + CONST_CONFIG_FILE_NAME)) {
				//--- Get the file from the user
				OpenFileDialog objFileDialog = new OpenFileDialog();
				objFileDialog.InitialDirectory = Application.StartupPath;
				if (objFileDialog.ShowDialog() == DialogResult.Cancel) {
					return false;
				} else {
					strFileName = objFileDialog.FileName();

					if (!File.Exists(strFileName)) {
						return false;
					}

					File.Copy(strFileName, Application.StartupPath + "\\" + CONST_CONFIG_FILE_NAME, true);

					strFileName = Application.StartupPath + "\\" + CONST_CONFIG_FILE_NAME;
				}
			}

			//2. Read configuration setting.
			if (!funcReadConfigSetting(strFileName)) {
				return false;
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
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

	private bool funcReadConfigSetting(string strFileName)
	{
		string strFileData;
		string strTempFileName;

		const object CONST_TEMP_FILE = "config.tmp";
		const object SECTION_Settings = "Settings";
		const object KEY_HardwareKey = "HardwareKey";
		const object KEY_DemoDays = "DemoDays";
		const object KEY_HardwareLockType = "HardwareLockType";

		const object KEY_SessionID = "SessionID";
		const object SECTION_General = "General";
		const object KEY_D2Gain = "D2GAIN";
		const object KEY_SetMinAbsLimit = "Set_Min_Abs_Limit";
		const object KEY_AbsThresholdValue = "Abs_Threshold_Value";
		const object KEY_PrinterType = "PrinterType";
		const object KEY_HydrideMode = "HydrideMode";

		const object KEY_BHStep = "BHStep";
		const object KEY_D2Pmt = "D2Pmt";
		const object KEY_Mesh = "Mesh";

		const object SECTION_Applications = "Applications";

		const object KEY_ApplicationType = "AppMode";
		const object KEY_21CFRInstallation = "21CFRInstallation";
		const object KEY_Enable21CFR = "Enable21CFR";
		const object KEY_HardwareLock = "HardwareLock";

		const object KEY_EnableIQOQPQ = "EnableIQOQPQ";

		const object KEY_EnableServiceUtility = "EnableServiceUtility";
		const object KEY_DisplayConfiguration = "DisplayConfiguration";

		const object KEY_CommPort = "CommPort";
		const object KEY_Instrument = "Instrument";

		const object SECTION_INIFileSettings = "INIFileSettings";
		const object KEY_TimeConstant = "Time_Constant";
		const object KEY_Filter_Window_Size = "Filter_Window_Size";
		const object KEY_Blank_Calculation = "Blank_Calculation";
		const object KEY_Exe_To_Run = "ExeToRun";
		//Saurabh
		const object KEY_ModelName = "ModelName";

		int intD2Gain;
		int intMesh;
		string intMinAbsLimit;
		int int21CFR;
		int intEnableServiceUtility;
		int intDisplayConfiguration;
		int intExeToRun;
		int intModelName;

		try {
			//---------------------------------------------------------
			//1. Copy the file to temp folder.
			//2. Decrypt the file.
			//3. Read the file as ini file.
			//---------------------------------------------------------
			//1. Copy the file to temp folder.
			//2. Decrypt the file.
			strTempFileName = Application.StartupPath + "\\" + CONST_TEMP_FILE;
			strFileData = funcReadFile(Application.StartupPath + "\\" + CONST_CONFIG_FILE_NAME);
			strFileData = gfuncDecryptString(strFileData);
			if (!funcWriteFile(strTempFileName, strFileData)) {
				return false;
			}

			//3. Read the file as ini file.
			//--- [Settings]
			gstructSettings.HardwareLock = Val(gFuncGetFromINI(SECTION_Applications, KEY_HardwareLock, "", strTempFileName) + "");
			gstructSettings.HardwareLockType = gFuncGetFromINI(SECTION_Settings, KEY_HardwareLockType, "", strTempFileName);
			gstructSettings.HardwareKey = gFuncGetFromINI(SECTION_Settings, KEY_HardwareKey, "", strTempFileName);
			gstructSettings.DemoDays = gFuncGetFromINI(SECTION_Settings, KEY_DemoDays, "", strTempFileName);

			gstructSettings.AppMode = Val(gFuncGetFromINI(SECTION_Applications, KEY_ApplicationType, "", strTempFileName) + "");
			gstructSettings.SessionID = Val(gFuncGetFromINI(SECTION_Settings, KEY_SessionID, "", strTempFileName) + "");

			//--- [General]
			intD2Gain = Val(gFuncGetFromINI(SECTION_General, KEY_D2Gain, "0", strTempFileName) + "");
			if (intD2Gain == 0) {
				gstructSettings.D2Gain = false;
			} else {
				gstructSettings.D2Gain = true;
			}

			gstructSettings.BHStep = Val(gFuncGetFromINI(SECTION_General, KEY_BHStep, "", strTempFileName) + "");
			gstructSettings.D2Pmt = Val(gFuncGetFromINI(SECTION_General, KEY_D2Pmt, "0", strTempFileName) + "");
			intMesh = Val(gFuncGetFromINI(SECTION_General, KEY_Mesh, "0", strTempFileName) + "");

			if (intMesh == 0) {
				gstructSettings.Mesh = false;
			} else {
				gstructSettings.Mesh = true;
			}

			//---To enable or Disable 21CFR Utility
			int21CFR = Val(gFuncGetFromINI(SECTION_Applications, KEY_21CFRInstallation, "1", strTempFileName) + "");
			if (int21CFR == 0) {
				gstructSettings.CFR21Installation = false;
				gstructSettings.Enable21CFR = false;
			} else {
				gstructSettings.CFR21Installation = true;
				int21CFR = Val(gFuncGetFromINI(SECTION_Applications, KEY_Enable21CFR, "1", strTempFileName) + "");
				if (int21CFR == 0) {
					gstructSettings.Enable21CFR = false;
				} else {
					gstructSettings.Enable21CFR = true;
				}
			}

			//---To enable or Disable Service Utility
			intEnableServiceUtility = Val(gFuncGetFromINI(SECTION_Applications, KEY_EnableServiceUtility, "1", strTempFileName) + "");
			if (intEnableServiceUtility == 0) {
				gstructSettings.EnableServiceUtility = false;
			} else {
				gstructSettings.EnableServiceUtility = true;
			}

			//---To set Display Configuration
			intDisplayConfiguration = Val(gFuncGetFromINI(SECTION_Applications, KEY_DisplayConfiguration, "1", strTempFileName) + "");
			if (intDisplayConfiguration == 0) {
				gstructSettings.IsCustomerDisplayMode = true;
			} else {
				gstructSettings.IsCustomerDisplayMode = false;
			}

			//---4.85  14.04.09
			intModelName = Val(gFuncGetFromINI(SECTION_Applications, KEY_ModelName, "0", strTempFileName) + "");
			if (intModelName == 0) {
				gstructSettings.NewModelName = false;
			} else {
				gstructSettings.NewModelName = true;
			}
			//---4.85  14.04.09


			//'--- [INI File Settings]
			intMinAbsLimit = (gFuncGetFromINI(SECTION_INIFileSettings, KEY_SetMinAbsLimit, 0, strTempFileName) + "");
			if (intMinAbsLimit == 0) {
				gstructSettings.SetMinAbsLimit = false;
			} else {
				gstructSettings.SetMinAbsLimit = true;
			}

			gstructSettings.AbsThresholdValue = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_AbsThresholdValue, "0.008", strTempFileName) + "");
			gstructSettings.TimeConstant = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_TimeConstant, "2.0", strTempFileName) + "");
			gstructSettings.Filter_Window_Size = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_Filter_Window_Size, "201", strTempFileName) + "");

			//void(FiltRead(void))
			//{
			//char	str[128];
			// GetProfileStringFromIniFile("Filter Setting", "Filter Window Size" ,
			//		"201", str, "aas.ini");
			// Wlen = atoi(str);
			//if (Wlen<20 || Wlen>FILTMAX-1)
			//  Wlen=201;
			//}

			if ((gstructSettings.Filter_Window_Size < 20) | (gstructSettings.Filter_Window_Size > ConstFILTMAX - 1)) {
				gstructSettings.Filter_Window_Size = 201;
			}

			if (Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_PrinterType, "0", strTempFileName) + "") == 0) {
				gstructSettings.blnSelectColorPrinter = false;
			} else {
				gstructSettings.blnSelectColorPrinter = true;
			}

			gstructSettings.HydrideMode = Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_HydrideMode, "0", strTempFileName) + "");

			if (Val(gFuncGetFromINI(SECTION_Applications, KEY_EnableIQOQPQ, "0", strTempFileName) + "")) {
				gstructSettings.EnableIQOQPQ = true;
			} else {
				gstructSettings.EnableIQOQPQ = false;
			}

			if (Val(gFuncGetFromINI(SECTION_INIFileSettings, KEY_Blank_Calculation, "0", strTempFileName) + "") == 0) {
				gstructSettings.BlankCalculation = true;
			} else {
				gstructSettings.BlankCalculation = false;
			}

			//--- delete the temp file
			if (File.Exists(strTempFileName)) {
				File.Delete(strTempFileName);
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			// gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			if (File.Exists(strTempFileName)) {
				File.Delete(strTempFileName);
			}
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

	private bool funcCreateConfigFile(string strFileName, string strConfigFileName)
	{

		string strFileContent;
		string strEncryptedString;
		try {
			//--1. read the Configure file ina string
			//--2. Encrypt the String
			//--3. Write The Encrypted File in a Given Folder

			//--1. read the Configure file ina string
			//--- Check Wether the file Exists
			strFileContent = funcReadFile(strFileName);
			if (strFileContent.Length <= 0) {
				return false;
			}

			//--2. Encrypt the String
			strEncryptedString = gfuncEncryptString(strFileContent);
			if (strEncryptedString.Length <= 0) {
				return false;
			}

			//--2. Decrypt the String(Temporary checking For Decrypting)
			//strEncryptedString = gfuncDecryptString(strFileContent)
			//If strEncryptedString.Length <= 0 Then
			//    Return False
			//End If
			//If Not funcWriteFile(strFolderName & "\" & "Con.Config", strEncryptedString) Then
			//    Return False
			//End If

			//--3. Write The Encrypted File in a Given Folder
			if (!funcWriteFile(strConfigFileName, strEncryptedString)) {
				return false;
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
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

	private string funcReadFile(string strFilePath)
	{

		string strFileContent;

		try {
			if (!File.Exists(strFilePath)) {
				return "";
			}

			StreamReader objStreamReader;
			objStreamReader = new StreamReader(strFilePath);
			strFileContent = objStreamReader.ReadToEnd();
			objStreamReader.Close();

			return strFileContent;

		} catch (IOException exIO) {
			gobjErrorHandler.ErrorDescription = exIO.Message;
			gobjErrorHandler.ErrorMessage = exIO.Message;
			return "";

		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			return "";
		}

	}

	private bool funcWriteFile(string strFilePath, string strFileContent)
	{
		try {
			StreamWriter objStreamWriter;
			objStreamWriter = new StreamWriter(strFilePath);
			objStreamWriter.Write(strFileContent);
			objStreamWriter.Close();

			return true;

		} catch (IOException i) {
			gobjErrorHandler.ErrorDescription = i.Message;
			gobjErrorHandler.ErrorMessage = i.Message;
			return false;

		} catch (Exception e) {
			gobjErrorHandler.ErrorDescription = e.Message;
			gobjErrorHandler.ErrorMessage = e.Message;
			return false;

		}

	}

	public bool gfuncSaveConfigurationSetting()
	{
		string strFileData;

		const object CONST_TEMP_FILE = "config.tmp";
		const object SECTION_Settings = "Settings";
		const object SECTION_INIFileSettings = "INIFileSettings";

		//Const KEY_Accessory = "Accessory"
		//Const KEY_ShowScreen = "ShowScreen"
		//Const KEY_Lamp_Mode = "Lamp_Mode"
		const object KEY_SessionID = "SessionID";
		const object KEY_Abs_Threshold_Value = "Abs_Threshold_Value";
		const object KEY_PrinterType = "PrinterType";
		const object KEY_HydrideMode = "HydrideMode";

		const object KEY_21CFRInstallation = "21CFRInstallation";
		const object KEY_Enable21CFR = "Enable21CFR";
		const object SECTION_Applications = "Applications";
		const object KEY_AbsThresholdValue = "Abs_Threshold_Value";
		const object KEY_TimeConstant = "Time_Constant";
		const object KEY_Filter_Window_Size = "Filter_Window_Size";
		//Const KEY_InstrumentNo = "Instrument_Number"
		//Const SECTION_Range = "Range"
		//Const KEY_MaxABS = "Maximum_ABS"
		//Const KEY_MinABS = "Minimum_ABS"
		try {
			//---------------------------------------------------------
			//1. Decrypt the file in the temp file.
			//2. Write the required parameters to the temp file.
			//3. Encrypt and create the config again.
			//---------------------------------------------------------

			//1. Decrypt the file in the temp file.
			strFileData = funcReadFile(Application.StartupPath + "\\" + CONST_CONFIG_FILE_NAME);
			strFileData = gfuncDecryptString(strFileData);
			if (strFileData.Length > 0) {
				if (!funcWriteFile(Application.StartupPath + "\\" + CONST_TEMP_FILE, strFileData)) {
					return false;
				}
			}

			//2. Write the required parameters to the temp file.
			// Call gFuncWriteToINI(SECTION_Settings, KEY_Accessory, gstructConfigurartionSetting.Accessory, Application.StartupPath & "\" & CONST_TEMP_FILE)
			// Call gFuncWriteToINI(SECTION_Settings, KEY_ShowScreen, gstructConfigurartionSetting.ShowScreen, Application.StartupPath & "\" & CONST_TEMP_FILE)
			//Call gFuncWriteToINI(SECTION_Settings, KEY_Lamp_Mode, gstructConfigurartionSetting.Lamp_Mode, Application.StartupPath & "\" & CONST_TEMP_FILE)
			gFuncWriteToINI(SECTION_Settings, KEY_SessionID, gstructSettings.SessionID, Application.StartupPath + "\\" + CONST_TEMP_FILE);

			gFuncWriteToINI(SECTION_INIFileSettings, KEY_Abs_Threshold_Value, gstructSettings.AbsThresholdValue, Application.StartupPath + "\\" + CONST_TEMP_FILE);


			gFuncWriteToINI(SECTION_INIFileSettings, KEY_AbsThresholdValue, gstructSettings.AbsThresholdValue, Application.StartupPath + "\\" + CONST_TEMP_FILE);
			gFuncWriteToINI(SECTION_INIFileSettings, KEY_TimeConstant, gstructSettings.TimeConstant, Application.StartupPath + "\\" + CONST_TEMP_FILE);
			gFuncWriteToINI(SECTION_INIFileSettings, KEY_Filter_Window_Size, gstructSettings.Filter_Window_Size, Application.StartupPath + "\\" + CONST_TEMP_FILE);

			if (gstructSettings.blnSelectColorPrinter == false) {
				gFuncWriteToINI(SECTION_INIFileSettings, KEY_PrinterType, "0", Application.StartupPath + "\\" + CONST_TEMP_FILE);

			} else {
				gFuncWriteToINI(SECTION_INIFileSettings, KEY_PrinterType, "1", Application.StartupPath + "\\" + CONST_TEMP_FILE);
			}

			if (gstructSettings.HydrideMode == 0) {
				gFuncWriteToINI(SECTION_INIFileSettings, KEY_HydrideMode, "0", Application.StartupPath + "\\" + CONST_TEMP_FILE);
			} else {
				//gstructSettings.blnHydrideMode = True
				gFuncWriteToINI(SECTION_INIFileSettings, KEY_HydrideMode, "1", Application.StartupPath + "\\" + CONST_TEMP_FILE);
			}

			string intEnable21CFR;
			if (gstructSettings.CFR21Installation == true) {
				if (gstructSettings.Enable21CFR == true) {
					intEnable21CFR = "1";
				} else {
					intEnable21CFR = "0";
				}
				//Call gFuncWriteToINI(SECTION_Settings, KEY_SessionID, intEnable21CFR, Application.StartupPath & "\" & CONST_TEMP_FILE)
				//-----Added By Pankaj on 30 May 07
				gFuncWriteToINI(SECTION_Applications, KEY_Enable21CFR, intEnable21CFR, Application.StartupPath + "\\" + CONST_TEMP_FILE);
				//Added By Pankaj on 30 May 07
				//-----

			}
			//Call gFuncWriteToINI(SECTION_Range, KEY_MinABS, gstructConfigurartionSetting.strucRangeY.dblMinimum_ABS, Application.StartupPath & "\" & CONST_TEMP_FILE)
			//Call gFuncWriteToINI(SECTION_Range, KEY_MaxABS, gstructConfigurartionSetting.strucRangeY.dblMaximum_ABS, Application.StartupPath & "\" & CONST_TEMP_FILE)
			//Call gFuncWriteToINI(SECTION_Settings, KEY_InstrumentNo, gstructConfigurartionSetting.Instrument_Number, Application.StartupPath & "\" & CONST_TEMP_FILE)


			//3. Encrypt and create the config again.
			if (!funcCreateConfigFile(Application.StartupPath + "\\" + CONST_TEMP_FILE, Application.StartupPath + "\\" + CONST_CONFIG_FILE_NAME)) {
				return false;
			}

			if (File.Exists(Application.StartupPath + "\\" + CONST_TEMP_FILE)) {
				File.Delete(Application.StartupPath + "\\" + CONST_TEMP_FILE);
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			//  gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			return false;

		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			Application.DoEvents();
		}
	}

	public string gfuncDecryptString(string str_encrypt)
	{
		string str_decrypt;
		string[] arr_str;
		byte[] arr_byte;
		byte bt_single;
		int rec_cnt;
		int temp_cnt;

		try {
			arr_str = str_encrypt.Split(";");
			rec_cnt = arr_str.Length;
			 // ERROR: Not supported in C#: ReDimStatement


			for (temp_cnt = 0; temp_cnt <= (rec_cnt - 1); temp_cnt++) {
				bt_single = Convert.ToByte(arr_str(temp_cnt));
				arr_byte(temp_cnt) = bt_single;
			}

			TripleDES obj_crypt = new TripleDES();
			str_decrypt = obj_crypt.gfuncDecrypt(arr_byte);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			str_decrypt = "";
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
		return str_decrypt;

	}

	public string gfuncEncryptString(string str_source)
	{
		string str_single;
		string str_encrypt;
		byte[] arr_byte;
		int rec_cnt;
		int temp_cnt;

		try {
			TripleDES obj_crypt = new TripleDES();
			arr_byte = obj_crypt.gfuncEncrypt(str_source);

			rec_cnt = arr_byte.Length;
			for (temp_cnt = 0; temp_cnt <= (rec_cnt - 1); temp_cnt++) {
				str_single = Convert.ToString(arr_byte(temp_cnt));
				if (temp_cnt == 0) {
					str_encrypt = str_single;
				} else {
					str_encrypt = str_encrypt + ";" + str_single;
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			str_encrypt = "";
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

		return str_encrypt;

	}

	public bool gfuncReadHardwareLockSetting(bool blnIsStart = false)
	{
		//-----------------------------------------------------------------
		//Procedure Name         :   gfuncReadHardwareLockSetting
		//Description            :   To Read the Setting of Hardware lock and return the status
		//Parameters             :   None
		//Return Value           :   True/False
		//Time/Date              :   14.03.07
		//Dependencies           :   
		//Author                 :   Sachin Dokhale
		//Revision               :
		//Revision by Person     :
		//-----------------------------------------------------------------
		bool IsUpgradeSessionID = false;
		int intLockValue = 0;
		clsTimer objTimeDelay = new clsTimer(null, 3000);

		try {
			gfuncReadHardwareLockSetting = false;
			if (gstructUserDetails.SessionID == 0) {
				if (gstructSettings.HardwareLock == 1) {
					if (gstructSettings.HardwareLockType == EnumHardwareLockType.USB_Lock) {
						////----- Commented and added by Sachin Dokhale 05.05.06
						gobjMessageAdapter.ShowMessage(constRemoveUSBHWLock);
						Application.DoEvents();
						//Process.Start(Application.StartupPath & "\installsentry.bat")
						Process.Start(Application.StartupPath + "\\installsentryUSB.bat");
						Application.DoEvents();
						objTimeDelay.subTime_Delay(4000);
						//gobjCommProtocol.mobjCommdll.subTime_Delay(4000)
						gobjMessageAdapter.ShowMessage(constPlugUSBHWLoack);
						Application.DoEvents();
						//gobjCommProtocol.mobjCommdll.subTime_Delay(10000)
						objTimeDelay.subTime_Delay(10000);
						//gobjMessageAdapter.ShowMessage("If USB Lock is found then click Ok to continue for Lock detection else Cancel", "USB Lock", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage, False, True)
						gobjMessageAdapter.ShowMessage("Click Ok to continue ", "USB Lock", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
						Application.DoEvents();
						int intNoofTime_ReadKey = 0;
						while ((true)) {
							if (intNoofTime_ReadKey <= 4) {
								if (gobjHardwareLock_USB.GetValue(intLockValue) < 0) {
								//gobjMessageAdapter.ShowMessage(constErrorHWLock)
								//Exit Function
								//Return False
								} else {
									break; // TODO: might not be correct. Was : Exit Do
								}
							} else {
								gobjMessageAdapter.ShowMessage(constErrorHWLock);
								Application.DoEvents();
								return false;
								break; // TODO: might not be correct. Was : Exit Do
							}
							//gobjCommProtocol.mobjCommdll.subTime_Delay(4000)
							objTimeDelay.subTime_Delay(4000);
							intNoofTime_ReadKey += 1;
						}
						////-----
						//---Sachin Ashtankar 04-Sept-2005
						////----- Sachin Dokhale 08-Feb-2006
						if (gobjHardwareLock_USB.WriteCurrentDateTime() == false) {
							gobjMessageAdapter.ShowMessage(constErrorHWLock);
							Application.DoEvents();
							//frmSplashScreen.Close()
							//Exit Function
							return false;
						// When USb HardwareLock write current Data & Time then session Id Should be upgrade from 0 next ID else not
						} else {

						}

					} else if (gstructSettings.HardwareLockType == EnumHardwareLockType.LPT_Lock) {
						Process.Start(Application.StartupPath + "\\installsentry.bat");
						//gobjCommProtocol.mobjCommdll.subTime_Delay(300)
						objTimeDelay.subTime_Delay(3);

						//If Not gobjHardwareLock_LPT.ReadHardwareKey(gstructConfigurartionSetting.HardwareKey) Then
						//    frmSplashScreen.Close()
						//End If

					}
				}
				//---------------------------------------
				//Dim objfrmInstallation As New frmInstallation
				//objfrmInstallation.ShowDialog()
				//objfrmInstallation.Dispose()
			}
			//---modified by kamal
			//----for implementing Hardwarelock

			if (gstructSettings.HardwareLock == 1) {
				if (gstructSettings.HardwareLockType == EnumHardwareLockType.USB_Lock) {
					////----- Modified by Sachin Dokhale 
					//If Not gobjHardwareLock_USB.ReadHardwareKey(gstructConfigurartionSetting.HardwareKey) Then
					if (gobjHardwareLock_USB.ReadHardwareKey(gstructSettings.HardwareKey) <= 0) {
						//Exit Function
						return false;
					} else {
						//---Sachin Ashtankar 04-Sept-2005-------
						if (gstructSettings.DemoDays > 0) {
							////----- Added and modified by Sachin Dokhale
							int intDifference;
							//If gobjHardwareLock_USB.GetDifference() Then
							if (gobjHardwareLock_USB.GetDifference(intDifference) == true) {
								if (intDifference > gstructSettings.DemoDays) {
									gobjMessageAdapter.ShowMessage(constDemoPeriodExpired);

									//Exit Function
									return false;
								} else if (intDifference < 0) {
									gobjMessageAdapter.ShowMessage("Hardware Lock Error." + vbCrLf + "Hardware Lock Drivers is not properly installed." + vbCrLf + "Please contact your software vender.", "Hardware Lock Error", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
									//gobjMessageAdapter.ShowMessage(constErrorHWLock)
									//Exit Function
									return false;
								//ElseIf intDifference = 0 Then
								} else if (intDifference == gstructSettings.DemoDays) {
									gobjMessageAdapter.ShowMessage("Hardware Lock." + vbCrLf + "Last day to go expire, Validate this software before expire." + vbCrLf + "Please contact your software vender.", "Hardware Lock Error", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
									//gobjMessageAdapter.ShowMessage(constErrorHWLock)
									IsUpgradeSessionID = true;
								} else {
									//Dim strMessage As String = Math.Abs((intDifference - gstructConfigurartionSetting.DemoDays)).ToString & " Days Left"
									//Dim strMessage As String = Math.Abs((intDifference - gstructSettings.DemoDays)).ToString & " Days left for expiry of this Software."
									//gobjMessageAdapter.ShowMessage(strMessage, "Demo", EnumMessageType.Information)
									////----- Added by Sachin Dokhale if S/W is stated or not
									if (blnIsStart == false) {
										//Dim strMessage As String = Math.Abs((intDifference - gstructConfigurartionSetting.DemoDays)).ToString & " Days Left"
										string strMessage = Math.Abs((intDifference - gstructSettings.DemoDays)).ToString + " Days left for expiry of this Software.";
										gobjMessageAdapter.ShowMessage(strMessage, "Demo", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
										//gobjMessageAdapter.ShowMessage(msgID_ErrorHWLock)
									}
									////----
									IsUpgradeSessionID = true;
								}
							} else {
								//Terminate Aplication
								//gFuncShowMessage("Hardware Lock Error", "Hardware Lock is failed. Please contact your software vender.", modConstants.EnumMessageType.Information)
								gobjMessageAdapter.ShowMessage(constErrorHWLock);

								//Exit Function
								return false;
							}
						} else {
							IsUpgradeSessionID = true;
						}
						//---------------------------------------
					}
				} else if (gstructSettings.HardwareLockType == EnumHardwareLockType.LPT_Lock) {
					if (!gobjHardwareLock_LPT.ReadHardwareKey(gstructSettings.HardwareKey)) {
						//Exit Function
						return false;
					} else {
						IsUpgradeSessionID = true;
					}
				}
			} else {
				IsUpgradeSessionID = true;
			}
			gfuncReadHardwareLockSetting = IsUpgradeSessionID;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
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
			objTimeDelay.subTimerStop();
			objTimeDelay = null;
			//---------------------------------------------------------
		}
	}

	#End Region

}
