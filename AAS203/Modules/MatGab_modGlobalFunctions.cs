
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using AAS203Library.Instrument;
using System.Diagnostics;
using System.Runtime.InteropServices;

class modGlobalFunctions
{




	#Region " Public Global Functions "

 // ERROR: Not supported in C#: DeclareDeclaration
 // ERROR: Not supported in C#: DeclareDeclaration
	public double gFuncGetmv(int intInVal)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncGetmv
		//Description            :   
		//Parameters             :   intInVal as integer
		//Time/Date              :   
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 17.11.06
		//--------------------------------------------------------------------------------------
		//        double S4FUNC GetmV(int adval)
		//{
		//double mv=0.0;
		// mv = ((double)adval-(double)2047.0)/(double)4096.0*(double)10000.0;
		// return mv;
		//}
		//---------
		try {
			//---convert adc filter reading into millivolt by using 
			//---following formula
			gFuncGetmv = ((double)intInVal - (double)2047.0) / 4096.0 * 10000.0;
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

	public double gFuncGetEmission(int intInVal)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncGetEmission
		//Description            :   
		//Parameters             :   intInVal as integer
		//Time/Date              :   
		//Dependencies           :   ADC filter reading
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 31.12.06
		//--------------------------------------------------------------------------------------
		try {
			// Return Emission value from given integer value
			// as adc filter reading
			return ((double)intInVal - 2047.0) / 4096.0 * 200.0;

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

	public double gFuncGetEnergy(int intInVal)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncGetEnergy
		//Description            :   
		//Parameters             :   intInVal as integer
		//Time/Date              :   
		//Dependencies           :     
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 31.12.06
		//--------------------------------------------------------------------------------------
		try {
			// Return Energy value from given integer value
			return gFuncGetEmission(intInVal);

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

	public double gFuncGetAbs(int intInVal)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncGetAbs
		//Description            :   
		//Parameters             :   intInVal as integer
		//Time/Date              :   
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 31.12.06
		//--------------------------------------------------------------------------------------
		try {
			// Return Abs value from given integer value
			//abs = ((double)adval-(double)2047.0)/(double)4096.0*(double)5.0;

			return ((double)intInVal - 2047.0) / 4096.0 * 5.0;

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

	public double gFuncGetADConvertedToCurMode(int intInVal)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gFuncGetADConvertedToCurMode
		//Description            :   
		//Parameters             :   intInVal as integer
		//Time/Date              :   
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 31.12.06
		//--------------------------------------------------------------------------------------
		try {
			// Convert ADC Value into current calibration mode value
			return gfuncGetADConvertedIntoMode(intInVal, gobjInst.Mode);

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

	public double gfuncGetADConvertedIntoMode(int intInVal, EnumCalibrationMode mode)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gfuncGetADConvertedIntoMode
		//Description            :   
		//Parameters             :   intInVal as integer,mode as integer
		//Time/Date              :   
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 31.12.06
		//--------------------------------------------------------------------------------------
		double dblVal;
		string str;

		try {
			// Convert ADC Value into given calibration mode
			switch (mode) {
				//1.	If calibration mode is AA,AABGC,MABS,AABGCSR then return
				//(ADC filter reading - 2047.0) / 4096.0 * 5.0
				case EnumCalibrationMode.AA:
				case EnumCalibrationMode.AABGC:
				case EnumCalibrationMode.MABS:
				case EnumCalibrationMode.AABGCSR:
					// Conver into ABS Mode

					dblVal = gFuncGetAbs(intInVal);
				//2.	If calibration mode is HCLE,D2E,Emission then return
				//(ADC filter reading - 2047.0) / 4096.0 * 200.0
				case EnumCalibrationMode.HCLE:
				case EnumCalibrationMode.EMISSION:
				case EnumCalibrationMode.D2E:
					// Conver into Emission or Energy Mode

					dblVal = gFuncGetEmission(intInVal);
				//3.	If calibration mode is selftest then return
				//(ADC filter reading - 2047.0) / 4096.0 * 10000.0
				case EnumCalibrationMode.SELFTEST:
					// Conver into Mv for Self Test Mode

					dblVal = gFuncGetmv(intInVal);
			}

			return dblVal;

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

	public double gfuncGetADConvertedTo(int intADValue, EnumOperationMode intOperationMode)
	{
		//--------------------------------------------------------------------------------------
		//Procedure Name         :   gfuncGetADConvertedTo
		//Description            :   
		//Parameters             :   ADC Value as integer, Operation Mode as integer
		//Time/Date              :   11-Jan-2007 12:15 pm
		//Dependencies           :   
		//Author                 :   Mangesh Shardul
		//Revision               :   1
		//Revision by Person     :   Sachin Dokhale
		//--------------------------------------------------------------------------------------

		//*********************************************************************************
		//--- ORIGINAL CODE
		//*********************************************************************************
		//double	S4FUNC	GetADConvertedTo(int adval, int mode)
		//{
		//char	str[20]="";
		//double val=0;

		//if( GetInstrument() == AA202 )
		//{
		//            Switch(Mode)
		//	{
		//		case MODE_AA:
		//		case MODE_AABGC:
		//		case MODE_SPECT:
		//			val=GetAbs(adval);
		//			StoreAbsAccurate(val,str);
		////			sprintf(str,"%-4.3f",val);
		//			val=(double) atof(str);
		//			break;

		//		case MODE_EMMISSION:
		//			val=GetEmission(adval);
		//			sprintf(str,"%-4.1f",val);
		//			val=(double) atof(str);
		//			break;
		///*
		//		case MODE_SPECT:
		//			val=GetmV(adval);
		//			sprintf(str,"%-4.1f",val);
		//			val=(double) atof(str);
		//			break;  */
		//	}
		//}
		//else{
		//            Switch(Mode)
		//	{
		//		case	MODE_AA:
		//		case  MODE_AABGC:
		//	//	case  MODE_UVABS:
		//			val=GetAbs(adval);
		////			sprintf(str,"%-4.3f",val);
		//			StoreAbsAccurate(val,str);
		//			val=(double) atof(str);
		//			break;

		//		case MODE_EMMISSION:
		//			val=GetEmission(adval);
		//			sprintf(str,"%-4.1f",val);
		//			val=(double) atof(str);
		//			break;

		//		case MODE_SPECT:
		//			val=GetmV(adval);
		//			sprintf(str,"%-4.1f",val);
		//			val=(double) atof(str);
		//			break;
		//	}
		//}
		//return val;
		//}
		//*********************************************************************************
		double dblNewADValue;

		try {
			// Convert ADC Value into given Operation mode
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				switch (intOperationMode) {
					case modGlobalConstants.EnumOperationMode.MODE_AA:
					case modGlobalConstants.EnumOperationMode.MODE_AABGC:
					case modGlobalConstants.EnumOperationMode.MODE_SPECT:
						//MODE_AA, MODE_AABGC

						//---convert adc value to absorbance value
						dblNewADValue = gFuncGetAbs(intADValue);
					//StoreAbsAccurate(dblNewADValue)

					case modGlobalConstants.EnumOperationMode.MODE_EMMISSION:
						//MODE_EMMISSION

						//---convert adc value to emission value

						dblNewADValue = gFuncGetEmission(intADValue);
					//Case modGlobalConstants.EnumOperationMode.MODE_SPECT
					//MODE_SPECT
					//dblNewADValue = gFuncGetmv(intADValue)
				}

			} else {
				switch (intOperationMode) {
					case modGlobalConstants.EnumOperationMode.MODE_AA:
					case modGlobalConstants.EnumOperationMode.MODE_AABGC:
						//MODE_AA, MODE_AABGC

						//---convert adc value to absorbance value
						dblNewADValue = gFuncGetAbs(intADValue);
					//StoreAbsAccurate(dblNewADValue)

					case modGlobalConstants.EnumOperationMode.MODE_EMMISSION:
						//MODE_EMMISSION

						//---convert adc value to emission value

						dblNewADValue = gFuncGetEmission(intADValue);
					case modGlobalConstants.EnumOperationMode.MODE_SPECT:
						//MODE_SPECT

						//---convert adc value to millivolt

						dblNewADValue = gFuncGetmv(intADValue);
				}
			}

			return dblNewADValue;

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

	public Int16 gfuncTurretStepsForLampTop(int TurretPosition)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   gfuncTurretStepsForLampTop
		//Description            :   
		//Parameters             :   TurretPosition as integer
		//Time/Date              :   
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 31.12.06
		//--------------------------------------------------------------------------------------
		//   if (p1->lamp<2)   nosteps = TARRATIO*(3.0+(p1->lamp)*2.0/3.0);
		//else  nosteps = TARRATIO*((p1->lamp-2)*2.0+1.0)/3.0;
		//--------------------------------------------------------------------------------------

		try {
			//--To calculate Turret STeps required to set turret at top position to insert or remove lamp
			//---where TARRATIO = 700.0
			if ((TurretPosition - 1) < 2) {
				gfuncTurretStepsForLampTop = TARRATIO * (3.0 + (TurretPosition - 1) * 2 / 3);
			} else {
				gfuncTurretStepsForLampTop = TARRATIO * (((TurretPosition - 1) - 2) * 2 + 1) / 3;
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

	public int gfuncGetConvertToUVAbs(int intSampleValue, int RefValue)
	{
		//=====================================================================
		// Procedure Name        : gfuncGetConvertToUVAbs
		// Parameters Passed     : ByVal intSampleValue, ByVal RefValue 
		// Returns               : Integer
		// Purpose               : Convert into Abs to the Sampel Value and Ref Value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 03.12.06
		// Revisions             : 
		//=====================================================================
		int intYnew = 0;
		double dblCalAbs = 0.0;

		try {
			//            int	ynew=0;
			//double	k=0;
			//            If (refval! = 2047.0) Then
			//  k = ((double)sampval-(double)2047.0)/((double)refval-(double)2047.0)*(double)100.0;
			// if (k>(double)0.0)
			//	 k = 2.0-log10(k);
			//                Else
			//	k=(double)0.0;
			// k = (double) 2047.0+(k/(double)2.0)*((double)1638.4);
			// ynew =(int) k;

			// Convert into Abs to the Sampel Value and Ref Value
			if (!(RefValue == 2047)) {
				dblCalAbs = ((double)intSampleValue - 2047) / ((double)RefValue - 2047.0) * 100.0;
			}
			if (dblCalAbs > 0.0) {
				dblCalAbs = 2.0 - Math.Log10(dblCalAbs);
			} else {
				dblCalAbs = 0.0;
			}
			dblCalAbs = 2047.0 + (dblCalAbs / 2.0) * (1638.4);
			intYnew = (int)dblCalAbs;
			return intYnew;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
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

	public double gfuncGetValueInSpectrum(int intValue, int intMode)
	{
		//=====================================================================
		// Procedure Name        : gfuncGetValueInSpectrum
		// Parameters Passed     : Byval intValue , ByVal intMode 
		// Returns               : Double
		// Purpose               : Get the Ratio  of Fuel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 03.12.06
		// Revisions             : 
		//=====================================================================
		double dblAbs = 0.0;

		try {
			////------------------
			//double	abs=0.0;
			//            If (!UVS) Then
			//	abs = GetADConvertedIntoMode(val, mode);
			// else{
			//                If (UVABS) Then
			//		abs = GetADConvertedIntoMode(val, AA);
			//                Else
			//	abs = GetADConvertedIntoMode(val, D2E);
			//  }
			// return abs;
			////------------------
			// Convert ADC Value into given calibration mode if not UVABS
			if (!(gblnUVS == true)) {
				dblAbs = gfuncGetADConvertedIntoMode(intValue, intMode);
			} else {
				// Convert ADC Value into Energy or Abs Mode  if UVABS
				if (gblnUVABS == true) {
					dblAbs = gfuncGetADConvertedIntoMode(intValue, modGlobalConstants.EnumCalibrationMode.AA);
				} else {
					dblAbs = gfuncGetADConvertedIntoMode(intValue, modGlobalConstants.EnumCalibrationMode.D2E);
				}
			}

			return dblAbs;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	public bool funcSaveAllMethods(object obj)
	{
		//=====================================================================
		// Procedure Name        : funcSaveAllMethods
		// Parameters Passed     : Object
		// Returns               : True or False
		// Purpose               : To serialize the clsMethodCollection object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Apr-2007
		// Revisions             : 
		//=====================================================================
		string strFileName;

		try {
			//following block of code is written by deepak on 29.07.07
			// select the file location for Diff. instrument condition
			switch (gstructSettings.AppMode) {
				case EnumAppMode.DemoMode:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				case EnumAppMode.FullVersion_203:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				case EnumAppMode.FullVersion_203D:
					strFileName = Application.StartupPath + "\\" + ConstDBMethodsFileName;
				case EnumAppMode.FullVersion_201:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				case EnumAppMode.DemoMode_203D:
					strFileName = Application.StartupPath + "\\" + ConstDBMethodsFileName;
				case EnumAppMode.DemoMode_201:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				default:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
			}

			//If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
			//    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
			//ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
			//    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
			//Else
			//    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
			//        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
			//    Else
			//        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
			//    End If
			//End If
			// Serialise the method collection data into filer system
			if (funcSerialize(strFileName, obj)) {
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
			return false;
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

	public bool funcLoadAllMethods(ref object obj)
	{
		//=====================================================================
		// Procedure Name        : funcLoadAllMethods
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : To Deserialize the clsMethodCollection object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Apr-2007
		// Revisions             : 
		//=====================================================================
		string strFileName;

		try {
			//following block of code is written by deepak on 29.07.07
			// select the file location for Diff. instrument condition
			switch (gstructSettings.AppMode) {
				case EnumAppMode.DemoMode:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				case EnumAppMode.FullVersion_203:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				case EnumAppMode.FullVersion_203D:
					strFileName = Application.StartupPath + "\\" + ConstDBMethodsFileName;
				case EnumAppMode.FullVersion_201:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				case EnumAppMode.DemoMode_203D:
					strFileName = Application.StartupPath + "\\" + ConstDBMethodsFileName;
				case EnumAppMode.DemoMode_201:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
				default:
					strFileName = Application.StartupPath + "\\" + ConstMethodsFileName;
			}

			//If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
			//    strFileName = Application.StartupPath & "\" & ConstMethodsFileName
			//ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
			//    strFileName = Application.StartupPath & "\" & ConstDBMethodsFileName
			//Else
			//    If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
			//        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
			//    Else
			//        strFileName = Application.StartupPath & "\" & ConstMethodsFileName
			//    End If
			//End If
			// Deserialise the method collection data from filer system
			if (File.Exists(strFileName)) {
				if (funcDeSerialize(strFileName, obj)) {
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}

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

	public bool funcSaveInstStatus()
	{
		//=====================================================================
		// Procedure Name        : funcSaveInstStatus
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To serialize the object gobjinst
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 18.11.06
		// Revisions             : 
		//=====================================================================
		string strPath;
		try {
			// serialize the object gobjinst

			//---03.12.07 Deepak
			strPath = Application.StartupPath + "\\" + ConstInstFileName;

			//If funcSerialize(ConstInstFileName, gobjInst.Lamp) = True Then
			if (funcSerialize(strPath, gobjInst.Lamp) == true) {
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
			return false;
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

	public bool funcLoadInstStatus()
	{
		//=====================================================================
		// Procedure Name        : funcLoadInstStatus
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To deserialize the object gobjinst
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 18.11.06
		// Revisions             : 
		//=====================================================================
		try {
			//deserialize the object gobjinst
			if (File.Exists(Application.StartupPath + "\\" + ConstInstFileName) == true) {
				//'If funcDeSerialize(ConstInstFileName, gobjInst.Lamp) = True Then
				//4.85  12.04.09
				if (funcDeSerialize(Application.StartupPath + "\\" + ConstInstFileName, gobjInst.Lamp) == true) {
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool funcIsAllLampEmpty()
	{
		//=====================================================================
		// Procedure Name        : funcIsAllLampEmpty
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To check whether all lamps are empty or not
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 18.11.06
		// Revisions             : 
		//=====================================================================

		//---------------------------------------------------------------------
		//---16 Bit Software Code
		//---------------------------------------------------------------------
		//    BOOL	S4FUNC IsAllLampEmpty(void)
		//{
		//int	i;
		//BOOL flag=FALSE;

		// for(i=0;i<6; i++)
		//	if (strcmpi(trim(ltrim(Inst.Lamp_par.lamp[i].elname)),"")!=0)
		//	  break;
		// if (i==6)
		//	flag=TRUE;
		//return flag;
		//}
		//---------------------------------------------------------------------

		int intCount;
		bool flag = false;

		try {
			//---19.06.07 following condition is changed by Deepak
			// Checking of all Lamps are presents
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				for (intCount = 0; intCount <= 1; intCount++) {
					if (Trim(gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName) != "") {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			} else {
				for (intCount = 0; intCount <= 5; intCount++) {
					//If gobjInst.Lamp.LampParametersCollection.item(intCount).ElementName <> "" Then
					if (gobjInst.Lamp.LampParametersCollection.item(intCount).LampOptimizePosition != 0) {
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			// check condition for 201 instrument
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				if (intCount == 2) {
					flag = true;
				}
			} else {
				if (intCount == 6) {
					flag = true;
				}
			}

			return flag;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	//Private Function gfuncPeakValley()
	//    '=====================================================================
	//    ' Procedure Name        : gfuncPeakValley
	//    ' Parameters Passed     : None
	//    ' Returns               : True
	//    ' Purpose               : Get Peak and Valley
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 25.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//Public Function gFuncGetIndexWv(ByVal dblWavelegth As Double, ByVal blnFlag As Boolean) As Integer
	//    '-----------------------------------  Procedure Header  -------------------------------
	//    'Procedure Name         :   gFuncGetIndexWv  
	//    'Description            :   To get the index wavelength
	//    'Parameters             :
	//    'Time/Date              :   10.32 22/10/03
	//    'Dependencies           :
	//    'Author                 :   Sachin Dokhale
	//    'Revision               :
	//    'Revision by Person     :
	//    '--------------------------------------------------------------------------------------
	//    gFuncGetIndexWv = 0

	//    Dim dblWvData As Double
	//    Dim intDAta As Integer
	//    'Dim dblWvOff As Double = 1900.0
	//    Dim dblWvOff As Double = 1
	//    Try


	//        ' return the index for Wavelength
	//        If blnFlag Then
	//            dblWvData = dblWavelegth
	//        Else
	//            dblWavelegth = gobjInst.WavelengthCur ' gdblCurrent_Wavelength
	//            dblWvData = dblWavelegth
	//        End If

	//        'If dblWavelegth >= gstructConfigurartionSetting.strucRangeX.dblMinimum_Normal_Wv Or dblWavelegth <= gstructConfigurartionSetting.strucRangeX.dblMaximum_Normal_Wv Then
	//        'dblWvData = (dblWvData * 10.0) + 0.05
	//        'dblWvData = (dblWvData * 10.0) + 40
	//        dblWvData = (dblWvData * 10.0) + 0.05
	//        intDAta = CInt(dblWvData)

	//        If intDAta <= 0 Then intDAta = 0
	//        If intDAta >= MAX_RANGE Then intDAta = MAX_RANGE - 1

	//        gFuncGetIndexWv = intDAta

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	public double gfuncGetSelectedUVElementWavelength(AAS203Library.Method.clsInstrumentParameters objClsInstrumentParameters, EnumOperationMode OperationModeIn = modGlobalConstants.EnumOperationMode.MODE_AA)
	{
		//=====================================================================
		// Procedure Name        : gfuncGetSelectedElementWavelength
		// Parameters Passed     : Instrument Parameter object of Method Setting
		// Returns               : Currently Selected Wavelength
		// Purpose               : To retrieve the currently selected Wavelength from the 
		//                         collection of Wavelengths for a Instrument.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 14-Jul-2007
		// Revisions             : 
		//=====================================================================
		double dblWavelength;
		try {
			// retrieve the currently selected Wavelength from the 
			// collection of Wavelengths for a Instrument for UV mode
			if (!IsNothing(objClsInstrumentParameters.Wavelength)) {
				if (!IsNothing(objClsInstrumentParameters.Wavelength.Rows.Count > 0)) {
					//For intRowCounter = 0 To objClsInstrumentParameters.Wavelength.Rows.Count - 1
					//If CInt(objClsInstrumentParameters.Wavelength.Rows(intRowCounter).Item(ConstColumnAADetailsID)) = objClsInstrumentParameters.SelectedWavelengthID Then
					dblWavelength = objClsInstrumentParameters.Wavelength.Rows(0).Item(ConstColumnWV);
					//Exit For
				}
			}
			return dblWavelength;

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

	public double gfuncGetSelectedElementWavelength(AAS203Library.Method.clsInstrumentParameters objClsInstrumentParameters)
	{
		//=====================================================================
		// Procedure Name        : gfuncGetSelectedElementWavelength
		// Parameters Passed     : Instrument Parameter object of Method Setting
		// Returns               : Currently Selected Wavelength
		// Purpose               : To retrieve the currently selected Wavelength from the 
		//                         collection of Wavelengths for a Instrument.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 14-Dec-2006
		// Revisions             : 1
		//=====================================================================
		int intRowCounter;
		double dblWavelength;
		try {
			// retrieve the currently selected Wavelength from the 
			// collection of Wavelengths for a Instrument.
			if (!IsNothing(objClsInstrumentParameters.Wavelength)) {
				for (intRowCounter = 0; intRowCounter <= objClsInstrumentParameters.Wavelength.Rows.Count - 1; intRowCounter++) {
					if ((int)objClsInstrumentParameters.Wavelength.Rows(intRowCounter).Item(ConstColumnAADetailsID) == objClsInstrumentParameters.SelectedWavelengthID) {
						dblWavelength = objClsInstrumentParameters.Wavelength.Rows(intRowCounter).Item(ConstColumnWV);
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}
			return dblWavelength;
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

	public bool gfuncInit_Lamp_Par(ref AAS203Library.Instrument.ClsLampParameters objLamp)
	{
		//=====================================================================
		// Procedure Name        : gfuncInit_Lamp_Par
		// Parameters Passed     : objLamp
		// Returns               : 
		// Purpose               : 
		// Description           : To initiate the passed lamp parameters
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 15-Dec-2006
		// Revisions             : 
		//=====================================================================
		//    void  	S4FUNC 	Init_Lamp_Par(LAMP_PAR *Lamp)
		//{
		//  Lamp->lamp_optpos=-1;
		//  Lamp->mel = FALSE;
		//  strcpy(Lamp->elname, "");
		//  Lamp->Atno =0;
		//  Lamp->cur = 0.0;
		//  Lamp->wv = 0.0;
		//  Lamp->slitwidth = 0.0;
		//  Lamp->mode = AA;
		//  Lamp->burner = TRUE;
		//}
		try {
			// Init. lamp object parametres (Set default setting for Lamp object)
			objLamp.LampOptimizePosition = -1;
			objLamp.Mel = false;
			objLamp.ElementName = "";
			objLamp.AtomicNumber = 0;
			objLamp.Current = 0.0;
			objLamp.Wavelength = 0.0;
			objLamp.SlitWidth = 0.0;
			objLamp.Mode = 1;
			objLamp.Burner = true;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool gfuncSet_Lamp_Parameters(ref AAS203Library.Instrument.ClsLampParameters objLamp, int intPos)
	{
		//=====================================================================
		// Procedure Name        : gfuncSet_Lamp_Parameters
		// Parameters Passed     : objLamp,intPos
		// Returns               : 
		// Purpose               : 
		// Description           : To set lamp parameters at selected position
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 15-Dec-2006
		// Revisions             : 
		//=====================================================================
		//void  S4FUNC Set_Lamp_Parameters(LAMP_PAR *Par, int pos)
		//{

		//if (Par==NULL)
		//  return;
		//if (pos>=0 && pos<6){
		//  if (strcmpi(Par->elname,Inst.Lamp_par.lamp[pos].elname)!=0)
		//	Inst.Lamp_par.lamp[pos].lamp_optpos=-1;
		//  Inst.Lamp_par.lamp[pos].mel = Par->mel;
		//  strcpy(Inst.Lamp_par.lamp[pos].elname, Par->elname);
		//  Inst.Lamp_par.lamp[pos].Atno= Par->Atno;
		//  Inst.Lamp_par.lamp[pos].cur = Par->cur;
		//  Inst.Lamp_par.lamp[pos].wv = Par->wv;
		//  Inst.Lamp_par.lamp[pos].slitwidth = Par->slitwidth;
		//  Inst.Lamp_par.lamp[pos].mode = Par->mode ;
		//  Inst.Lamp_par.lamp[pos].burner = Par->burner;
		//  Save_Tuttet_Status();
		// }
		//}    
		try {
			// set lamp parameters of Inst. object at given position
			// given position is "intPos"
			if (!objLamp == null) {
				if (intPos >= 0 & intPos < 6) {
					if (gobjInst.Lamp.LampParametersCollection.item(intPos).ElementName != objLamp.ElementName) {
						gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = -1;
					}
					gobjInst.Lamp.LampParametersCollection.item(intPos).Mel = objLamp.Mel;
					gobjInst.Lamp.LampParametersCollection.item(intPos).ElementName = objLamp.ElementName;
					gobjInst.Lamp.LampParametersCollection.item(intPos).AtomicNumber = objLamp.AtomicNumber;
					gobjInst.Lamp.LampParametersCollection.item(intPos).Current = objLamp.Current;
					gobjInst.Lamp.LampParametersCollection.item(intPos).Wavelength = objLamp.Wavelength;
					gobjInst.Lamp.LampParametersCollection.item(intPos).SlitWidth = objLamp.SlitWidth;
					gobjInst.Lamp.LampParametersCollection.item(intPos).Mode = objLamp.Mode;
					gobjInst.Lamp.LampParametersCollection.item(intPos).Burner = objLamp.Burner;
					if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
						funcSaveInstStatus();
					}
				}
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool gfuncLamp_connected(int intPos)
	{
		//=====================================================================
		// Procedure Name        : gfuncLamp_connected
		// Parameters Passed     : intPos
		// Returns               : 
		// Purpose               : 
		// Description           : To set lamp parameters property lamp optpos at selected position
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 15-Dec-2006
		// Revisions             : 
		//=====================================================================
		//    void	S4FUNC Lamp_connected(int pos)
		//{
		//Inst.Lamp_par.lamp[pos].lamp_optpos = 0;
		//}
		try {
			// set lamp parameters property lamp optpos at selected position
			gobjInst.Lamp.LampParametersCollection.item(intPos - 1).LampOptimizePosition = 0;

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool gfuncGet_Lamp_Parameters(ref AAS203Library.Instrument.ClsLampParameters objLamp, int intPos)
	{
		//=====================================================================
		// Procedure Name        : gfuncGet_Lamp_Parameters
		// Parameters Passed     : objLamp,intPos
		// Returns               : 
		// Purpose               : 
		// Description           : To Get lamp parameters for selected position
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 15-Dec-2006
		// Revisions             : 
		//=====================================================================
		//    void	S4FUNC Get_Lamp_Parameters(LAMP_PAR *Par, int pos)
		//{
		//if (pos>=0 && pos<6 && Par!=NULL){
		//  Par->mel = Inst.Lamp_par.lamp[pos].mel;
		//  strcpy(Par->elname, Inst.Lamp_par.lamp[pos].elname);
		//  Par->Atno = Inst.Lamp_par.lamp[pos].Atno;
		//  Par->cur = Inst.Lamp_par.lamp[pos].cur;
		//  Par->wv = Inst.Lamp_par.lamp[pos].wv ;
		//  Par->slitwidth = Inst.Lamp_par.lamp[pos].slitwidth ;
		//  Par->mode = Inst.Lamp_par.lamp[pos].mode;
		//  Par->burner = Inst.Lamp_par.lamp[pos].burner ;
		// }
		//}
		try {
			// Get lamp parameters for selected position from Inst. object
			if (!objLamp == null) {
				if (intPos >= 0 & intPos < 6) {
					objLamp.Mel = gobjInst.Lamp.LampParametersCollection.item(intPos).Mel;
					objLamp.ElementName = gobjInst.Lamp.LampParametersCollection.item(intPos).ElementName;
					objLamp.AtomicNumber = gobjInst.Lamp.LampParametersCollection.item(intPos).AtomicNumber;
					objLamp.Current = gobjInst.Lamp.LampParametersCollection.item(intPos).Current;
					objLamp.Wavelength = gobjInst.Lamp.LampParametersCollection.item(intPos).Wavelength;
					objLamp.SlitWidth = gobjInst.Lamp.LampParametersCollection.item(intPos).SlitWidth;
					objLamp.Mode = gobjInst.Lamp.LampParametersCollection.item(intPos).Mode;
					objLamp.Burner = gobjInst.Lamp.LampParametersCollection.item(intPos).Burner;
				}
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public int CheckMethod()
	{
		//=====================================================================
		// Procedure Name        : CheckMethod
		// Parameters Passed     : None
		// Returns               : Status Value as Integer 
		// Purpose               : Return Method Status
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//int CheckMethod(void)
		//{
		//	if (AnaMethod.Nmet>=0 && (AnaMethod.QuantData!=NULL))
		//	{
		//	    if (GetTotStds(AnaMethod.QuantData->StdTopData, FALSE)>0)
		//		    return 2;
		//	}
		//   If (AnaMethod.Nmet > 0) Then
		//	    return 1;
		//	return 3;
		//}
		try {
			//---18.06.07
			// Return Method Status
			if ((gobjNewMethod.MethodID >= 0)) {
				//If gobjNewMethod.QuantitativeDataCollection.Count > 0 Then
				if (clsStandardGraph.GetTotStds(gobjNewMethod.StandardDataCollection, false) > 0) {
					return 2;
				}
				//End If
			}

			if ((gobjNewMethod.MethodID > 0)) {
				return 1;
			}

			return 3;

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

	public int gfuncGetSelectedMethodRunNumberIndex(int intSelectedMethodID, int intSelectedRunNumber)
	{
		//=====================================================================
		// Procedure Name        : gfuncGetSelectedMethodRunNumber
		// Parameters Passed     : None
		// Returns               : Selected Index of QuantitativeData item
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 25-Feb-2007 02:25 pm
		// Revisions             : 1
		//=====================================================================
		int intMethodCounter;
		int intCounter;
		int intRunNumberIndex;

		try {
			//Selected Index of QuantitativeData item from given Method ID and Run Number

			intRunNumberIndex = -1;

			for (intMethodCounter = 0; intMethodCounter <= gobjMethodCollection.Count - 1; intMethodCounter++) {
				if (intSelectedMethodID == gobjMethodCollection.item(intMethodCounter).MethodID) {
					for (intCounter = 0; intCounter <= gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count - 1; intCounter++) {
						if (intSelectedRunNumber == (int)gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(intCounter).RunNumber) {
							intRunNumberIndex = intCounter;
							return intRunNumberIndex;
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return -1;
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

	#End Region

	#Region " Private Function "

	private object gfuncGetPeakValley(int i, bool blnIsPeak)
	{
		//=====================================================================
		// Procedure Name        : gfuncGetPeakValley
		// Parameters Passed     : None
		// Returns               : True
		// Purpose               : Get Peak and Valley
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		int k;
		int j;
		int maxmin = 5000;
		try {
		//int 	k;
		//int	j;
		//int	maxmin=5000;

		//if (peak)
		//  maxmin=-1;
		//j=i;
		//if (i>5 && i<addata.counter-5){
		//  for(k=i-5; k<i+5; k++){
		//	 if (peak){
		//		if (chanel0[k]>maxmin){
		//		  maxmin=chanel0[k];
		//		  j=k;
		//		}
		//	  }
		//	 else{
		//		if (chanel0[k]<maxmin){
		//		  maxmin=chanel0[k];
		//		  j=k;
		//		}
		//	 }
		//	}
		// }
		// i=j;
		// if (i>5 && i<addata.counter-10){
		//	j=0;
		//	for(k=i; k<i+10; k++){
		//	  if (chanel0[k]==chanel0[k+1])
		//		 j++;
		//	  else
		//		 break;
		//	 }
		//	j=i+j/2;
		// }
		//return j;
		//}
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
	//ByVal channel As channel,

	private object gfuncValidatePeakValley()
	{
		//=====================================================================
		// Procedure Name        : gfuncValidatePeakValley
		// Parameters Passed     : None
		// Returns               : True
		// Purpose               : Validate Peak and Valley
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================

		try {

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

	private object gfuncGetMV()
	{
		//=====================================================================
		// Procedure Name        : gfuncGetMV
		// Parameters Passed     : None
		// Returns               : True
		// Purpose               : Get M.Volt.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================

		try {
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

	//Private Function gfuncGetPeakValley()
	//    '=====================================================================
	//    ' Procedure Name        : gfuncGetPeakValley
	//    ' Parameters Passed     : None
	//    ' Returns               : True
	//    ' Purpose               : Get Peak and Valley
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 25.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//Private Function gfuncGetPeakValley()
	//    '=====================================================================
	//    ' Procedure Name        : gfuncGetPeakValley
	//    ' Parameters Passed     : None
	//    ' Returns               : True
	//    ' Purpose               : Get Peak and Valley
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 25.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function
	//Private Function gfuncGetPeakValley()
	//    '=====================================================================
	//    ' Procedure Name        : gfuncGetPeakValley
	//    ' Parameters Passed     : None
	//    ' Returns               : True
	//    ' Purpose               : Get Peak and Valley
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 25.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function
	//Private Function gfuncGetPeakValley()
	//    '=====================================================================
	//    ' Procedure Name        : gfuncGetPeakValley
	//    ' Parameters Passed     : None
	//    ' Returns               : True
	//    ' Purpose               : Get Peak and Valley
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 25.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function
	//Private Function gfuncGetPeakValley()
	//    '=====================================================================
	//    ' Procedure Name        : gfuncGetPeakValley
	//    ' Parameters Passed     : None
	//    ' Returns               : True
	//    ' Purpose               : Get Peak and Valley
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 25.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	//    int	GetPeak(int *chanel0, int i, BOOL peak)
	//{

	private bool funcSerialize(string strFileName, object obj)
	{
		//=====================================================================
		// Procedure Name        : funcSerialize
		// Parameters Passed     : Object
		// Returns               : True or False
		// Purpose               : To serialize the object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 09.10.06
		// Revisions             : 
		//=====================================================================
		int intCount;
		BinaryFormatter Formatter;
		Stream stream;
		string strPath = "";
		try {
			Formatter = new BinaryFormatter();
			stream = new FileStream(strFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);

			try {
				Formatter.Serialize(stream, obj);

			} catch (Exception ex2) {
				gobjErrorHandler.ErrorDescription = ex2.Message;
				gobjErrorHandler.ErrorMessage = ex2.Message;
				gobjErrorHandler.WriteErrorLog(ex2);
				gobjMessageAdapter.ShowMessage(constFailedToUpdateFile);
				Application.DoEvents();
				stream.Close();
			} finally {
				stream.Close();
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool funcDeSerialize(string strFileName, ref object obj)
	{
		//=====================================================================
		// Procedure Name        : funcDeSerialize
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : To Deserialize the object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 09.10.06
		// Revisions             : 
		//=====================================================================
		BinaryFormatter Formatter;
		FileStream fs;

		try {
			fs = new FileStream(strFileName, FileMode.Open);

			//// Added by Sachin Dokhale 
			if (IsNothing(fs)) {
				return false;
			} else {
				if (fs.Length <= 0) {
					return false;
				}
			}
			////-----

			Formatter = new BinaryFormatter();
			obj = Formatter.Deserialize(fs);

			return true;

		} catch (SerializationException ex1) {
			//---------------------------------------------------------
			//Error Handling and logging
			//gobjErrorHandler.ErrorDescription = ex1.Message
			//gobjErrorHandler.ErrorMessage = ex1.Message
			//gobjErrorHandler.WriteErrorLog(ex1)
			gobjMessageAdapter.ShowMessage(constFailedToLoadFile);
			Application.DoEvents();
			if (!fs == null) {
				fs.Close();
			}
			return false;
		} catch (Exception ex) {
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
			if (!fs == null) {
				fs.Close();
			}
		}
	}

	#End Region

	#Region " Serialization function "

	public object gfuncDeSerializeObject(string filepath, Int16 objtype)
	{
		//--- This function De-Serializes the Object as per the input Object Type passed to it.
		//=====================================================================
		// Procedure Name        :   gfuncDeSerializeObject
		// Description           :   Get the file from the user and load the
		//                           file data to the object as reqd. by the user.
		// Purpose               :   To load the file in the object.
		// Parameters Passed     :   FilePath and Object type.
		// Returns               :   Object.
		// Parameters Affected   :   File data is added to the object specified.
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   08 Dec. 2006
		// Revisions             :   
		//=====================================================================

		FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
		BinaryFormatter bf = new BinaryFormatter();
		try {
			// Deserialise the Spectrum objects for perticular Spectrum type
			switch ((objtype)) {
				case EnumDeserializeObjType.EnergySpectrum:
					//Dim objEnergyChannels As New SpectrumMode.Channel(True)
					Spectrum.Channel objEnergyChannels;
					objEnergyChannels = (Spectrum.Channel)bf.Deserialize(fs);
					return objEnergyChannels;
				case EnumDeserializeObjType.UVSpectrum:
					//Dim objUVChannels As New SpectrumMode.Channel(False)
					Spectrum.Channel objUVChannels;
					objUVChannels = (Spectrum.Channel)bf.Deserialize(fs);
					return objUVChannels;
				case EnumDeserializeObjType.UVSpectrumDB:
					Spectrum.EnergyChannels objUVChannelsDB;
					objUVChannelsDB = (Spectrum.EnergyChannels)bf.Deserialize(fs);
					return objUVChannelsDB;
				case EnumDeserializeObjType.EnergySpectrumDB:
					Spectrum.EnergyChannels objEnergyChannelsDB;
					objEnergyChannelsDB = (Spectrum.EnergyChannels)bf.Deserialize(fs);
					return objEnergyChannelsDB;
			}
		} catch (System.Runtime.Serialization.SerializationException SerializeException) {
			//Error Handling
			//gobjMessageAdapter.ShowMessage(constFailedToLoadFile)
			gobjMessageAdapter.ShowMessage("Selected data file is mismatch", "Load file", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage, false, false);
			Application.DoEvents();
			return null;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log

			if (!fs == null) {
				fs.Close();
			}
			fs = null;
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	public bool gfuncSerializeObject(string filepath, Spectrum.Channel objchannel)
	{
		//--- This function Serializes the Spectrum Channel Object
		//=====================================================================
		// Procedure Name        :   gfuncSerializeObject
		// Description           :   Get the Channels object and save it to the filename and path
		//                           specified by the user.
		// Purpose               :   To Save the Channel Object in the Channel file.
		// Parameters Passed     :   FilePath and Parameter Object.
		// Returns               :   None.
		// Parameters Affected   :   Adds a file the directory path specified.
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   8 Dec. 2006
		// Revisions             :
		//=====================================================================
		FileStream fs;
		BinaryFormatter bf;
		try {
			fs = new FileStream(filepath, FileMode.Create);
			bf = new BinaryFormatter();
			//Serialise the Spectrum objects 
			gfuncSerializeObject = false;
			bf.Serialize(fs, objchannel);
			fs.Close();
			gfuncSerializeObject = true;
		//Catch FileException As System.io.FileLoadException
		} catch (System.UnauthorizedAccessException FileException) {
			//Catch FileException As System.SystemException
			gobjMessageAdapter.ShowMessage(constFailedToLoadFile);
			Application.DoEvents();
			if (!fs == null) {
				fs.Close();
			}
			return false;
		} catch (System.Runtime.Serialization.SerializationException SerializeException) {
			//Error Handling
			gobjMessageAdapter.ShowMessage(constFailedToLoadFile);
			Application.DoEvents();
			if (!fs == null) {
				fs.Close();
			}
			return false;
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
			//fs.Close()
			fs = null;
			bf = null;
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	public bool gfuncSerializeObjectDB(string filepath, Spectrum.EnergyChannels objchannels)
	{
		//--- This function Serializes the Spectrum Channel Object
		//=====================================================================
		// Procedure Name        :   gfuncSerializeObject
		// Description           :   Get the Channels object and save it to the filename and path
		//                           specified by the user.
		// Purpose               :   To Save the Channel Object in the Channel file.
		// Parameters Passed     :   FilePath and Parameter Object.
		// Returns               :   None.
		// Parameters Affected   :   Adds a file the directory path specified.
		// Assumptions           :   None.
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale
		// Created               :   8 Dec. 2006
		// Revisions             :
		//=====================================================================
		FileStream fs = new FileStream(filepath, FileMode.Create);
		BinaryFormatter bf = new BinaryFormatter();
		try {
			//Serialise the Spectrum objects 
			gfuncSerializeObjectDB = false;
			bf.Serialize(fs, objchannels);
			gfuncSerializeObjectDB = true;
		} catch (System.Runtime.Serialization.SerializationException SerializeException) {
			//Error Handling
			gobjMessageAdapter.ShowMessage(constFailedToLoadFile);
			Application.DoEvents();
			return false;
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
			if (!fs == null) {
				fs.Close();
			}
			fs = null;
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	#End Region

	#Region " Service Log-Book "

	//-----------------LOCBOOK Section---------------------------------------
	//Declaration of Database name for SpectraScan
	public const string CONSTSTR_LOGERRORDATABASENAME = "Database\\ServiceLogBook.mdb";
	public const string CONSTSTR_USERINFORMATION = "Database\\UserInfo.mdb";

	public string CONST_FILELOG_PATH = Application.StartupPath.ToString + "\\FileLog";
	//--- Enum for SelectionTypes 
	public enum enum_LoggingDataFields
	{
		UVSpectrum = 1,
		EnergySpectrum = 2
	}
	//enum for setting the time

	//-----------------LOGBOOK Section ends---------------------------------------

	#End Region

	#Region " General Functions "

	public bool gfuncValidateGrid(string txtVal, int intDecPlace)
	{
		//=====================================================================
		// Procedure Name        : gfuncValidateGrid
		// Parameters Passed     : None
		// Returns               : return True for validation
		// Purpose               : Validate Grid Control 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 24.02.07
		// Revisions             : 
		//=====================================================================
		string strWavelength;
		string[] strSplit;
		try {
			// Validate Grid Control for given no of decimal places
			strWavelength = txtVal;
			// Slit the object
			strSplit = strWavelength.Split(new Char[] { "." });
			// Check the decimal places
			if (strSplit.Length > 1) {
				if (strSplit(1).Length > intDecPlace) {
					if (intDecPlace == 0) {
						//gFuncShowMessage("Invalid Input", "Enter integer values ", modConstants.EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage(constCheckValue);
						return false;
					} else {
						//gFuncShowMessage("Invalid Input", "Enter upto " & intDecPlace & " decimal points ", modConstants.EnumMessageType.Information)
						gobjMessageAdapter.ShowMessage("Enter upto " + intDecPlace + " decimal points ", "Invalid Input", EnumMessageType.Information);
						return false;
					}
				} else {
					return true;
				}
			} else {
				return true;
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

	public bool gFuncLoadGlobals()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gFuncLoadGlobals
		//Description	    :   To load the global variables required through out the system
		//Parameters 	    :   None
		//Time/Date  	    :   13.03.07
		//Dependencies	    :   
		//Author		        :   Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		bool Status;
		int intBeamType;
		int intIsInstReset;

		try {
			//---Get Comm Port for AAS Instrument
			gintCommPortSelected = (int)gFuncGetFromINI(SECTION_COMMSETTINGS, KEY_COMPORT, "0", INI_SETTINGS_PATH);
			gintCommPortSelectedForAutoSampler = (int)gFuncGetFromINI(SECTION_AUTOSAMPLER, KEY_SERIALPORT, "0", INI_SETTINGS_PATH);
			//---Get Instrument Beam Type
			intBeamType = (int)gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRUMENT_BEAMTYPE, "0", INI_SETTINGS_PATH);
			if (intBeamType == 0) {
				gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam;
			} else if (intBeamType == 2) {
				gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam;
			}

			gstrCustomer = (string)gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_Customer, CONST_LabName, INI_SETTINGS_PATH);

			// Set the Wavelength range
			DataTable objDtWvRange = new DataTable();
			objDtWvRange = gobjDataAccess.GetWavelengthRange(gstructSettings.AppMode);
			if (!objDtWvRange == null) {
				if (objDtWvRange.Rows.Count > 0) {
					gstructSettings.WavelengthRange.WvLowerBound = objDtWvRange.Rows(0).Item("WvLowerBound");
					gstructSettings.WavelengthRange.WvUpperBound = objDtWvRange.Rows(0).Item("WvUpperBound");
				}
			}
			//intIsInstReset = CInt(gFuncGetFromINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRESET_CONTINUOUS, "0", INI_SETTINGS_PATH))
			//If intIsInstReset <= 0 Then
			//    gblnIsInstReset = False
			//Else
			//    gblnIsInstReset = True
			//End If
			//--- Load the inst. Reset continuous flag.
			gfuncGetInstReset_continuousFromINI();
			////--- Added Sachin Dokhale for AA201  and AA203 Lamp count on 22.05.08
			switch (gstructSettings.AppMode) {
				case EnumAppMode.DemoMode_201:
				case EnumAppMode.FullVersion_201:
					ConstInstFileName = ConstInstFileName_201;
				//Case EnumAppMode.DemoMode_204, EnumAppMode.FullVersion_204
				//ConstInstFileName = ConstInstFileName_204
				default:
					ConstInstFileName = ConstInstFileName_203;
			}
			////---

			gobjClsAAS203.funcLoad_Fuel_Conditions();
			//---30.04.10

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
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

	public string gfuncReturnstrCalMode(EnumCalibrationMode intCalMode)
	{
		//=====================================================================
		// Procedure Name        : gfuncReturnstrCalMode
		// Parameters Passed     : EnumCalibrationMode
		// Returns               : string of Calibration mode
		// Purpose               : Return Calibration mode in String format for display Mode
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Aug 02, 2007
		// Revisions             : 1
		//=====================================================================
		try {
			// return the Calibraiotn mode into string data type from given mode
			switch (intCalMode) {
				case modGlobalConstants.EnumCalibrationMode.AA:
					return "AA";
				case modGlobalConstants.EnumCalibrationMode.AABGC:
					return "AABGC";
				case modGlobalConstants.EnumCalibrationMode.AABGCSR:
					return "AABGCSR";
				case modGlobalConstants.EnumCalibrationMode.D2E:
					return "D2E";
				case modGlobalConstants.EnumCalibrationMode.EMISSION:
					return "EMISSION";
				case modGlobalConstants.EnumCalibrationMode.HCLE:
					return "HCLE";
				case modGlobalConstants.EnumCalibrationMode.MABS:
					return "MABS";
				case modGlobalConstants.EnumCalibrationMode.SELFTEST:
					return "SELFTEST";
				default:
					return "";
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return "";
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

	public bool gfuncIsDBNull_Ext(object InDBValue)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gfuncIsDBNull_Ext
		//Description	    :   To check the DB value with Null or empty value
		//Parameters 	    :   inDBValue as object
		//Return             :   Return True
		//Time/Date  	    :   13.03.07
		//Dependencies	    :   
		//Author		        :   Sachin Dokhale
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------

		try {
			//---
			if (IsDBNull(InDBValue) == true) {
				return true;
			} else if ((string)InDBValue == "") {
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
			//---------------------------------------------------------
		}
	}

	public object BlankAlert()
	{
		try {
			Beep2(500, 100);
			Sleep(70);
			Beep2(500, 100);
			Sleep(70);
			Beep2(500, 100);
			Sleep(70);
			Beep2(500, 100);
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

	public object StandardAlert()
	{
		try {
			Beep2(400, 100);
			Sleep(50);
			Beep2(500, 100);
			Sleep(50);
			Beep2(400, 100);
			Sleep(50);
			Beep2(500, 100);
			Sleep(50);
			Beep2(400, 100);
			Sleep(50);
			Beep2(500, 100);
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

	public object SampleAlert()
	{
		try {
			Beep2(500, 100);
			Sleep(50);
			Beep2(400, 100);
			Sleep(50);
			Beep2(700, 100);
			Sleep(50);
			Beep2(500, 100);
			Sleep(50);
			Beep2(400, 100);
			Sleep(50);
			Beep2(700, 100);
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

	#End Region

}

