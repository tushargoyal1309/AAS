using System.IO;
using System.Text;
using System.Runtime.InteropServices;

class modIniOperations
{

	//--- Constant for the INI file name

	public string CONST_AAS_INI_FileName = IO.Path.GetFullPath("AAS.ini");
	//--- Constant for AutoSampler ini file name

	public string CONST_AutoSampler_INI_FileName = IO.Path.GetFullPath("asampler.ini");
	//--- Constant for the sections and keys in the INI file.
	//--- Spectrum Mode Parameters

	public const string CONST_Section_Parameters = "Parameters";
	const  CONST_Key_AnalysisDate = "AnalysisDate";
	const  CONST_Key_Cal_Mode = "Cal_Mode";
	const  CONST_Key_Comments = "Comments";
	const  CONST_Key_D2Curr = "D2Curr";
	const  CONST_Key_PMTV = "PMTV";
	const  CONST_Key_ScanSpeed = "ScanSpeed";
	const  CONST_Key_SlitWidth = "SlitWidth";
	const  CONST_Key_SpectrumName = "SpectrumName";
	const  CONST_Key_XaxisMax = "XaxisMax";
	const  CONST_Key_XaxisMin = "XaxisMin";
	const  CONST_Key_YaxisMax = "YaxisMax";
	const  CONST_Key_YaxisMin = "YaxisMin";
	const  CONST_Key_BurnerHeight = "BurnerHeight";
	const  CONST_Key_FualRatio = "FualRatio";
	const  CONST_Key_LampTurrNo = "LampTurrNo";
	const  CONST_Key_LampEle = "LampEle";

	const  CONST_Key_HCLCurr = "HCLCurr";
	//---Constants for AutoSampler ini Sections and Keys
	//"AutoSampler", "Wash Time (sec)"
	public const  CONST_Section_AutoSampler = "AutoSampler";

	public const  CONST_Key_WashTime = "Wash Time (sec)";


	//***************Modified By Saurabh on (04-01-2007)******************
	//--- Enable 21CFR
	public const string CONST_Section_21CFR = "21CFR";
	public const string CONST_Key_Enable21CFR = "Enable21CFR";

	public const string CONST_Key_SessionID = "SessionID";
	//--- Printer type
	public const string CONST_Section_PRINTERTYPE = "PRINTERTYPE";

	public const string CONST_Key_ColorPrinter = "ColorPrinter";
	//--- Printer type
	public const string CONST_Section_LOGIN = "LOGIN";

	public const string CONST_Key_USERID = "User";
	public bool gfuncGetSessionIDFromINI(ref long lngSessionid)
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetSessionIDFromINI
		// Description           :   Get the Session ID parameter values from the 
		//                           INI file using the API calls to read the INI
		//                           file and assign it to a Session ID variable 
		//                           passed as a ref to the function.
		// Purpose               :   To get the default parameters from the 
		//                           INI file located in the app path.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :   INI file contains the respective Sections and Keys
		// Dependencies          :   None.
		// Author                :   Gitesh
		// Created               :   Tuesday, March 23, 2004 03:35
		// Revisions             :
		//=====================================================================

		if (!File.Exists(CONST_AAS_INI_FileName)) {
			//Throw New Exception("INI file '" & strINI_FileName & "' do not exist.")
			gobjMessageAdapter.ShowMessage("Error...", "INI file '" + CONST_AAS_INI_FileName + "' does not exist.", modGlobalConstants.EnumMessageType.Information);
		}

		//--- Get the parameters from the INI file.
		try {
			lngSessionid = Val(gfuncGetINISystemParameters(CONST_Section_21CFR, CONST_Key_SessionID) + "");

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file.";
			gobjErrorHandler.WriteErrorLog(ex);
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

	public bool gfuncSaveSessionIDtoINIFIle(long lngSessionid)
	{
		//=====================================================================
		// Procedure Name        :   gfuncSaveSessionIDtoINIFIle
		// Description           :   To Store the values back the INI FIle.
		// Purpose               :   To Store the values back the INI FIle.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   Wednesday, March 24, 2004
		// Revisions             :
		//=====================================================================

		try {
			if (!gfuncWriteINISystemParameters(CONST_Section_21CFR, CONST_Key_SessionID, (string)lngSessionid + "")) {
				return false;
			}
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
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

	public object gfuncSetEnable21CFRToINI(ref int int21CFR)
	{
		try {
			gFuncWriteToINI(CONST_Section_21CFR, CONST_Key_Enable21CFR, (string)int21CFR, INI_SETTINGS_PATH);

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

	public bool gfuncGetInstReset_continuousFromINI()
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetInstReset_continuousFromINI
		// Description           :   To get InstReset continuousfrom ini file
		// Purpose               :   To get the InstReset continuousfrom flag from the 
		//                           INI file located in the app path.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :   INI file contains the respective Sections and Keys
		// Dependencies          :   CONST_AAS_INI_FileName must be set with "AAS.ini"
		// Author                :   Sachin Dokhale
		// Created               :   07.01.08
		// Revisions             :
		//=====================================================================
		int intIsInstReset;
		if (!File.Exists(CONST_AAS_INI_FileName)) {
			gobjMessageAdapter.ShowMessage("Error...", "INI file '" + CONST_AAS_INI_FileName + "' do not exist.", modGlobalConstants.EnumMessageType.Information);
		}


		try {
			//--- Get the parameters from the INI file.
			intIsInstReset = (int)gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, "0", INI_SETTINGS_PATH);
			if (intIsInstReset <= 0) {
				gblnIsInstReset = false;
			} else {
				gblnIsInstReset = true;
			}
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file.";
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

	public object gfuncSetInstReset_continuousToINI(bool intInstReset_continuous)
	{
		try {
			if (intInstReset_continuous == false) {
				gFuncWriteToINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, (string)0, INI_SETTINGS_PATH);
			} else {
				gFuncWriteToINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, (string)1, INI_SETTINGS_PATH);
			}

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

	public bool gfuncGetEnable21CFRFromINI()
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetEnable21CFRFromINI
		// Description           :   Get the enable 21CFR parameter values from the 
		//                           INI file using the API calls to read the INI
		//                           file and assign it to a 21CFREnable application level struct
		//                           object passed as a ref to the function.
		// Purpose               :   To get the default parameters from the 
		//                           INI file located in the app path.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :   INI file contains the respective Sections and Keys
		// Dependencies          :   None.
		// Author                :   Gitesh
		// Created               :   Tuesday, March 23, 2004 03:35
		// Revisions             :
		//=====================================================================

		if (!File.Exists(CONST_AAS_INI_FileName)) {
			//Throw New Exception("INI file '" & strINI_FileName & "' do not exist.")
			gobjMessageAdapter.ShowMessage("Error...", "INI file '" + CONST_AAS_INI_FileName + "' do not exist.", modGlobalConstants.EnumMessageType.Information);
		}

		//--- Get the parameters from the INI file.
		try {
			gstructSettings.Enable21CFR = gfuncGetINISystemParameters(CONST_Section_21CFR, CONST_Key_Enable21CFR);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file.";
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

	public object gfuncSetPrinterTypeToINI(ref bool blnColorPrinter)
	{
		try {
			gFuncWriteToINI(CONST_Section_PRINTERTYPE, CONST_Key_ColorPrinter, (string)blnColorPrinter, INI_SETTINGS_PATH);

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

	public object gfuncSetUserIDToINI(string strUserID)
	{

		try {
			gFuncWriteToINI(CONST_Section_LOGIN, CONST_Key_USERID, strUserID, INI_SETTINGS_PATH);

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

	public bool gfuncGetPrinterTypeFromINI()
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetPrinterTypeFromINI
		// Description           :   To get printer type i,e. is printer B/W or Color from ini file
		// Purpose               :   To get the default set printer type from the 
		//                           INI file located in the app path.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :   INI file contains the respective Sections and Keys
		// Dependencies          :   None.
		// Author                :   Santosh
		// Created               :   October, 01, 2004 03:35
		// Revisions             :
		//=====================================================================

		if (!File.Exists(CONST_AAS_INI_FileName)) {
			gobjMessageAdapter.ShowMessage("Error...", "INI file '" + CONST_AAS_INI_FileName + "' do not exist.", modGlobalConstants.EnumMessageType.Information);
		}

		//--- Get the parameters from the INI file.
		try {
			gstructSettings.blnSelectColorPrinter = gfuncGetINISystemParameters(CONST_Section_PRINTERTYPE, CONST_Key_ColorPrinter);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file.";
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


	public bool gfuncGetUserIDFromINI()
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetUserIDFromINI
		// Description           :   To get User ID from ini file
		// Purpose               :   To get the last User Id from the 
		//                           INI file located in the app path.
		// Parameters Passed     :   None.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :   INI file contains the respective Sections and Keys
		// Dependencies          :   None.
		// Author                :   Santosh
		// Created               :   October, 13, 2004 03:35
		// Revisions             :
		//=====================================================================

		if (!File.Exists(CONST_AAS_INI_FileName)) {
			gobjMessageAdapter.ShowMessage("Error...", "INI file '" + CONST_AAS_INI_FileName + "' do not exist.", modGlobalConstants.EnumMessageType.Information);
		}

		//--- Get the parameters from the INI file.
		try {
			gstructUserDetails.UserID = gfuncGetINISystemParameters(CONST_Section_LOGIN, CONST_Key_USERID);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in getting Enable 21CFR Parameter from INI file.";
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


	//*********************\\\\\\\****************************************




	//--- API declarations for reading the data from the INI file.

 // ERROR: Not supported in C#: DeclareDeclaration
 // ERROR: Not supported in C#: DeclareDeclaration
	public bool gfuncWriteINISystemParameters(string section, string key, string value)
	{
		try {
			if (gFuncWriteToINI(section, key, value, CONST_AAS_INI_FileName)) {
				return true;
			} else {
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
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

	public bool gfuncGetParametersFromINI(ref Spectrum.UVSpectrumParameter objParameter)
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetParametersFromINI
		// Description           :   Get the default parameter values from the 
		//                           INI file using the API calls to read the INI
		//                           file and populate the values in the parameter
		//                           object passed as a parameter to the function.
		// Purpose               :   To get the default parameters from the 
		//                           INI file located in the app path.
		// Parameters Passed     :   Parameter object.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :   INI file contains the respective Sections and Keys
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   Wednesday, November 12, 2003 03:35
		// Revisions             :
		//=====================================================================

		//--- Get the parameters from the INI file.
		try {
			//Check if INI file exists and give the respective message
			if (!File.Exists(CONST_AAS_INI_FileName)) {
				//gFuncShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' does not exist.", EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("INI file '" + CONST_AAS_INI_FileName + "' does not exist.", "Error...", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				return;
			}

			objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate);
			objParameter.Cal_Mode = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Cal_Mode);
			objParameter.Comments = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Comments);
			objParameter.D2Curr = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_D2Curr);
			objParameter.PMTV = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_PMTV);
			objParameter.ScanSpeed = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanSpeed);
			objParameter.SlitWidth = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SlitWidth);
			objParameter.SpectrumName = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SpectrumName);
			objParameter.XaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMax);
			objParameter.XaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMin);
			objParameter.YaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMax);
			objParameter.YaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMin);

			//objParameter.CalculatedSpeed = gFuncGetSpeed(objParameter.WavelengthMin, objParameter.WavelengthMax)

			//--- Channel name is saved  as Spectrum of' 
			//objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate).ToString
			objParameter.AnalysisDate = DateTime.Today;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in getting parameters from INI file ";
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

	public bool gfuncGetParametersFromINI(ref Spectrum.EnergySpectrumParameter objParameter)
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetParametersFromINI
		// Description           :   Get the default parameter values from the 
		//                           INI file using the API calls to read the INI
		//                           file and populate the values in the parameter
		//                           object passed as a parameter to the function.
		// Purpose               :   To get the default parameters from the 
		//                           INI file located in the app path.
		// Parameters Passed     :   Parameter object.
		// Returns               :   True, if successful.
		// Parameters Affected   :   None.
		// Assumptions           :   INI file contains the respective Sections and Keys
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   Wednesday, November 12, 2003 03:35
		// Revisions             :
		//=====================================================================

		//--- Get the parameters from the INI file.
		try {
			//Check if INI file exists and give the respective message
			if (!File.Exists(CONST_AAS_INI_FileName)) {
				//gFuncShowMessage("Error...", "INI file '" & CONST_AAS_INI_FileName & "' does not exist.", EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("INI file '" + CONST_AAS_INI_FileName + "' does not exist.", "Error...", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				return;
			}

			//objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate)



			objParameter.Cal_Mode = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Cal_Mode);
			objParameter.Comments = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_Comments);
			objParameter.D2Curr = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_D2Curr);
			objParameter.PMTV = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_PMTV);
			objParameter.ScanSpeed = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanSpeed);
			objParameter.SlitWidth = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SlitWidth);
			objParameter.BurnerHeight = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_BurnerHeight);
			objParameter.FualRatio = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_FualRatio);
			objParameter.LampTurrNo = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_LampTurrNo);
			objParameter.LampEle = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_LampEle);
			objParameter.HCLCurr = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_HCLCurr);


			objParameter.SpectrumName = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_SpectrumName);
			objParameter.XaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMax);
			objParameter.XaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_XaxisMin);
			objParameter.YaxisMax = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMax);
			objParameter.YaxisMin = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMin);

			//objParameter.CalculatedSpeed = gFuncGetSpeed(objParameter.WavelengthMin, objParameter.WavelengthMax)

			//--- Channel name is saved  as Spectrum of' 
			//objParameter.AnalysisDate = gfuncGetINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate).ToString
			objParameter.AnalysisDate = DateTime.Today;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in getting parameters from INI file ";
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

	public bool gFuncWriteToINI(string strSection, string strKey, string strKeyValues, string strINIFilePath)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncWriteToINI
		//Description:       To write the specified string to the Key of the given Setion of the INI
		//Parameters :   `   Section Name, KeyName, KeyValue, INI File PAth
		//Time/Date  :       1.21  12'Oct 2003
		//Dependencies:      INI File Should Present Prior
		//Author:            Mandar
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

	public string gFuncGetFromINI(string strSection, string strKeyValue, string strDefaultString, string StrINIFilePath)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncGetFromINI
		//Description:   To retrieve the key vale of a specified Section From INI
		//Parameters :   Section, Key , DefaultKeyValue, strFullPath of the INI
		//Time/Date  :   1.09 12'Oct 2003
		//Dependencies:  INI File Should exist
		//Author:    MandarC 
		//Revision: 
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		Int32 intBffer = 255;
		string strReturnString = Space(intBffer);
		gFuncGetFromINI = "";

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

	//--- This Function returns System Parameters as per the section and key name passed to it.
	public string gfuncGetINISystemParameters(string section, string key)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gfuncGetINISystemParameters
		//Description:       To retrieve the key vale of a specified Section From INI
		//Parameters :       Section, Key 
		//Time/Date  :       1.09 12'Oct 2003
		//Dependencies:      INI File Should exist
		//Author:            Sachin Dokhale
		//Revision: 
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		string sDefault = "";
		string strFileName;

		try {
			return (string)gFuncGetFromINI(section, key, sDefault, CONST_AAS_INI_FileName) + "";

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return "";
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}


	}

	//Public Function gfuncSaveSpectrumParameterstoINIFIle(ByVal objSpecParameter As Parameter) As Boolean

	//    Try
	//        gfuncSaveSpectrumParameterstoINIFIle = False

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanMode, objSpecParameter.ScanMode) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_ScanSpeed, objSpecParameter.ScanSpeed) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_CalculatedSpeed, objSpecParameter.CalculatedSpeed) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_Repeats, objSpecParameter.Repeat) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_CycleT, objSpecParameter.CycleT) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_WaveLengthMin, objSpecParameter.WavelengthMin) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_WaveLengthMax, objSpecParameter.WavelengthMax) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMin, objSpecParameter.YaxisMin) Then
	//            gFuncShowMessage("Error...", "Error In Writing System Parameters To INI Files.", modConstants.EnumMessageType.Information)
	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_YaxisMax, objSpecParameter.YaxisMax) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_ChannelName, objSpecParameter.ChannelName) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalystName, objSpecParameter.AnalystName) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If

	//        If Not gfuncWriteINISystemParameters(CONST_Section_Parameters, CONST_Key_AnalysisDate, objSpecParameter.AnalysisDate) Then
	//            gFuncShowMessage("Error...", "Error in writing system parameters to INI file.", modConstants.EnumMessageType.Information)

	//        End If


	//        gfuncSaveSpectrumParameterstoINIFIle = True
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in writing time scan parameters to INI"
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//        gfuncSaveSpectrumParameterstoINIFIle = False
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function

}
