using AAS203.Common;
using AAS203Library;
using AAS203Library.Method;
using AAS203Library.Instrument;
using AAS203Library.Analysis;
using System.IO;
using AAS203.FuelConditions;
//'these are like header files
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

using System.Runtime.InteropServices;

//'class behind the class
public class ClsAAS203 : MarshalByRefObject
{

	#Region " Private Menber Varaibles "

	////----- Private Variable
	private double mEmsZero = 0.0;
	//'for atroing a Emission zero value.

	private int intTimeConst = 2;
	private int m_intXoldt;
	private int m_intYoldt;
	private bool m_blnFilterFlag = false;
	//'this is a flag for filter flag'
	//'this is used for checking a filter cond.
	private bool blnResetFilterData;
	//'this is used for checking that whatever filter data should be reset or not.
	////------
	//Private tmr As Timer
	//Private m_tmr_tick_count As Integer = 0
	//Dim objfrmTimeScan As New frmTimeScanDBMode

	#End Region

	#Region " Public Constants, Enums, Structures... "

	public enum enumIgniteType
	{
		//'this is a enum for holding a ignite type.
		Blue = 0,
		Yellow = 1,
		Red = 2,
		Green = 3
	}
	public enum enumChangeAxis
	{
		//Pankaj 09 May 07 11 for track axis change
		xAxis = 0,
		yAxis = 1,
		xyAxis = 2
	}

	[DllImport("user32.dll")]
	public static long ExitWindows(long dwReserved, long uReturnCode)
	{
	}

	[DllImport("user32.dll")]
	public static long SendMessage(long hwnd, long wMsg, long wParam, long lParam)
	{
	}

	public const  HWND_BROADCAST = 0xffffL;
	public const  WM_COMMAND = 0x111;

	public const  WM_DESTROY = 0x2;
	#End Region

	public DataTable funcGetElement(int intElementID)
	{
		//=====================================================================
		// Procedure Name        : funcGetElement
		// Parameters Passed     : intElementID
		// Returns               : table holding a element info
		// Purpose               : Toget element details from cookBook
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'here we have element id as parameter.
		//'then we connect with database.
		//'and get all element info as per given elementID.
		//'by sending a query
		DataTable objDtElement = new DataTable();
		try {
			objDtElement = gobjDataAccess.GetCookBookData(intElementID);
			//'gobjDataAccess is a object of dataaccesslayer
			return objDtElement;
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public DataTable funcGetElement_AtomicNo(int intElementID)
	{
		//=====================================================================
		// Procedure Name        : funcGetElement
		// Parameters Passed     : intElementID
		// Returns               : 
		// Purpose               : Toget element details from cookBook
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'here we have to a pass element id as parameter.
		//'then we connect with database.
		//'and get a element atomicno  as per given elementID.
		//'by sending a query
		DataTable objDtElement = new DataTable();
		try {
			objDtElement = gobjDataAccess.GetCookBookData_AtomicNo(intElementID);
			//here gobjDataAccess is object of data access layer.
			return objDtElement;

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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public int funcGetElementID(int intAtomicNumber)
	{
		//=====================================================================
		// Procedure Name        : funcGetElementID
		// Parameters Passed     : intAtomicNumber
		// Returns               : Element ID
		// Purpose               : Toget element ID from cookBook
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 27.03.07
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'here we have to pass a element AtomicNumber as parameter.
		//'then we connect with database.
		//'and get a elementID  as per given element AtomicNum.
		//'by sending a query
		int intElementID;
		try {
			intElementID = gobjDataAccess.GetCookBookElementID(intAtomicNumber);
			//here gobjDataAccess is object of data access layer.
			return intElementID;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
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

	public DataTable funcGetElementWavelengths(int intElementID)
	{
		//=====================================================================
		// Procedure Name        : funcGetElementWavelengths
		// Parameters Passed     : intElementID
		// Returns               : returan a data table holding a info
		// Purpose               : To get element wavelength details from cookBook
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'here we have to pass a element ElementID  as parameter.
		//'then we connect with database.
		//'and get a element wavwlengths  as per given elemenID.
		//'by sending a query
		DataTable objDtElement = new DataTable();

		try {
			objDtElement = gobjDataAccess.GetElementWavelengths(intElementID);
			//here gobjDataAccess is object of data access layer.
			return objDtElement;

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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public int funcGetSensitiveWavelengthID(DataTable objDtWv)
	{
		//=====================================================================
		// Procedure Name        : funcGetSensitiveWavelengthID
		// Parameters Passed     : datatable ,holding all wavwlength value.
		// Returns               : Sensitive wv id
		// Purpose               : To get sensitive wavelength ID
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Deepak B.
		// Created               : 07.1.07
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'here we have to pass a datatable holding all wavelwngth value as parameter.
		//'then we connect with database.
		//'and get a sensitivewavelength  from a given data table.
		//'by sending a query


		int intCount;
		int intSensitiveWvID;
		//'this will hold a return value.
		bool blnIsSensitiveWv = false;
		double dblWv = 0.0;
		try {
			for (intCount = 0; intCount <= objDtWv.Rows.Count - 1; intCount++) {
				//'make a counter up last row a data table.
				if (objDtWv.Rows.Item(intCount).Item("Sensitive_WV") == true) {
					//'if sensitivity wavelength has been got then store it. 
					intSensitiveWvID = objDtWv.Rows.Item(intCount).Item("AADetails_ID");
					blnIsSensitiveWv = true;
					//'set a flag true after finding a sensitivewavelength
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			//'else follow the same step
			if (blnIsSensitiveWv == false) {
				//'if blnIsSensitiveWv  is false ,it means we did't find a sensitive wavelwngth
				//'then
				if (objDtWv.Rows.Count > 0) {
					dblWv = objDtWv.Rows.Item(0).Item("WV");
					//now get a wavelength in dblWv 
				}
				for (intCount = 0; intCount <= objDtWv.Rows.Count - 1; intCount++) {
					if (objDtWv.Rows.Item(intCount).Item("WV") >= dblWv) {
						//'check for dblWv value
						intSensitiveWvID = objDtWv.Rows.Item(intCount).Item("AADetails_ID");
						//'store the value in sensitive wavelength
					}
				}
			}
			return intSensitiveWvID;
		//'return a sensitive wavelength.

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
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

	public DataTable funcGetMethodTypes()
	{
		//=====================================================================
		// Procedure Name        : funcGetMethodTypes
		// Parameters Passed     : none
		// Returns               : datatable with mwthod type.
		// Purpose               : To get method types from database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection 
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : Mangesh on 14-Apr-2007 for Double Beam Changes
		//                         praveen  
		//=====================================================================
		//'note:
		//'this will get a all method type.
		//'like AA mode,emission mode etc.
		//'and store a datatable object.
		//'which used later in a software through this datatable object
		DataTable objDtMethod;
		DataTable objDtDBMethodTypes;
		DataRow objDrNewRow;
		int intRowsCounter;
		bool IsAA301 = false;

		try {
			//---21.07.09
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				if (gstructSettings.NewModelName == true) {
					IsAA301 = true;
				}
			}

			objDtMethod = gobjDataAccess.GetMethodTypes(0, IsAA301);
			//'here gobjDataAccess is a object of dataaccesslayer.

			if (!IsNothing(objDtMethod)) {
				if (objDtMethod.Rows.Count > 0) {
					//'start commented code not in used.

					//***********************************************************
					//---Added by Mangesh on 14-Apr-2007
					//***********************************************************
					//Commented If & Else by Saurabh 0n 14-May-2007
					//If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then

					//    objDtDBMethodTypes = objDtMethod.Clone()
					//    For intRowsCounter = 0 To objDtMethod.Rows.Count - 1
					//        If CInt(objDtMethod.Rows(intRowsCounter).Item("MethodTypeID")) = EnumOperationMode.MODE_AA _
					//                                   Or CInt(objDtMethod.Rows(intRowsCounter).Item("MethodTypeID")) = EnumOperationMode.MODE_AABGC Then

					//            objDrNewRow = objDtDBMethodTypes.NewRow()
					//            objDrNewRow.Item("MethodTypeID") = objDtMethod.Rows(intRowsCounter).Item("MethodTypeID")
					//            objDrNewRow.Item("MethodType") = objDtMethod.Rows(intRowsCounter).Item("MethodType")
					//            objDtDBMethodTypes.Rows.Add(objDrNewRow)

					//        End If
					//    Next intRowsCounter
					//    Return objDtDBMethodTypes
					//Else
					//'End commented code not in used.
					return objDtMethod;
				//End If
				//***********************************************************

				} else {
					return null;
				}
			} else {
				return null;
			}

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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public DataRow funcGetMethodType(int intMethodTypeId)
	{
		//=====================================================================
		// Procedure Name        : funcGetMethodType
		// Parameters Passed     : intMethodTypeId
		// Returns               : return a data row holding method type.
		// Purpose               : To get method type details from database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//this is used to get a method type name as per method type ID.
		DataTable objDtMethod = new DataTable();
		try {
			objDtMethod = gobjDataAccess.GetMethodTypes(intMethodTypeId);
			//'dataaccesslayer function for getting info from database
			if (!objDtMethod == null) {
				if (objDtMethod.Rows.Count > 0) {
					//'cack if datatable holding any value.
					//'if yes then it will be method type.
					//'return that row.
					return objDtMethod.Rows(0);
				}
			}
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public DataTable funcGetUnits()
	{
		//=====================================================================
		// Procedure Name        : funcGetUnits
		// Parameters Passed     : none
		// Returns               : data table holding a Units info
		// Purpose               : To get units from database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection.
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to get a all unitsType from a database.
		DataTable objDtUnits = new DataTable();

		try {
			objDtUnits = gobjDataAccess.GetUnits;
			//'get a data of unit type from database 
			return objDtUnits;
		//'return all units in the datatable
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public DataTable funcGetMeasurementMode()
	{
		//=====================================================================
		// Procedure Name        : funcGetMeasurementMode
		// Parameters Passed     : none
		// Returns               : data table holding a mode.
		// Purpose               : To get measurement modes from database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database Connection
		// Author                : Deepak B.
		// Created               : 08.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to get a different type of measurementMode from the database.
		DataTable objDtMeasurementMode = new DataTable();
		//'temp datatable object for holding mode info.
		try {
			objDtMeasurementMode = gobjDataAccess.GetMeasurementModes;
			//'database function for getting a value.
			return objDtMeasurementMode;
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}


	//============Functions of \Service Utility\Service Routine\frmTurret===================================

	public bool funcbtnTurretPosition(int intTurretPosition)
	{
		//=====================================================================
		// Procedure Name        : funcbtnTurretPosition
		// Parameters Passed     : intTurretPosition
		// Returns               : True or False
		// Purpose               : To position the Turret at given position from current position 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument should be connected
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to set a turrert at a given positon 
		//'for this we used serial communication function
		//'for sending proper protocol to instrument.
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.gFuncTurret_Position(intTurretPosition, true) == true) {
				//'serial communicaation function for setting turrert position.
				return true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	public bool funcbtnTurretHome()
	{
		//=====================================================================
		// Procedure Name        : funcbtnTurretHome
		// Parameters Passed     : none
		// Returns               : True or False
		// Purpose               : To position the Turret at its Home position.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument should be connected
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to set turrert at home position. 
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.gFuncTurret_Home() == true) {
				//'serial communication function for setting turrert at home position.
				return true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnAllLampOFF()
	{
		//=====================================================================
		// Procedure Name        : funcbtnAllLampOFF
		// Parameters Passed     : 
		// Returns               : True or False
		// Purpose               : To turn all the Lamp OFF 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument should be connected
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to turn off all the lamp .

		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.funcAll_Lamp_Off == true) {
				//'serial communication function for setting all lamp off protocol.
				return true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnHCLCurrent(double dblCurrent, int intTurret)
	{
		//=====================================================================
		// Procedure Name        : funcbtnHCLCurrent
		// Parameters Passed     : dblCurrent,intTurret
		// Returns               : bool
		// Purpose               : 
		// Description           : To set given HCL current to the turret position.
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//note:
		//'this is used to set given HCL current to the turret position.
		//'by using a serial communication function
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, intTurret) == true) {
				//'serial communication function for setting all lamp off
				return true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnD2Current(double d2Cur)
	{
		//=====================================================================
		// Procedure Name        : funcbtnD2Current
		// Parameters Passed     : d2Cur 
		// Returns               : True if success
		// Purpose               : To set D2 Current
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument 
		// Author                : Saurabh S
		// Created               : 04.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to set a D2 current.

		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.funcSetD2Cur(d2Cur) == true) {
				//'serial communication function for setting D2 current
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnD2ONOFF(int Flag, ref int Flag1)
	{
		//=====================================================================
		// Procedure Name        : funcbtnD2ONOFF
		// Parameters Passed     : Flag
		// Parameters Affected   : Flag1
		// Returns               : True or False
		// Purpose               : To put the D2 Current ON or OFF.

		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Saurabh S
		// Created               : 04.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to set D2 lamp on or off as per given cond.
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (Flag == 0) {
				if (gobjCommProtocol.D2_ON() == true) {
					//serial communication for setting D2 lamp on 
					//--- If D2 lamp is ON successfully then flag1 is set to 1. And return true
					Flag1 = 1;
					return true;
				} else {
					gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
					gobjMessageAdapter.ShowMessage(constCommError);
				}
			} else {
				if (gobjCommProtocol.D2_OFF() == true) {
					//'serial communication for setting D2 off.
					//--- If D2 lamp is OFF successfully then flag1 is set to 0. And return true
					Flag1 = 0;
					return true;
				} else {
					gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
					gobjMessageAdapter.ShowMessage(constCommError);
				}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	//=============== By Sachin Dokhale ========================================

	public double funcGet_SlitWidth(ref int intInstrumentSlitType = 0)
	{
		//=====================================================================
		// Procedure Name        : funcGet_SlitWidth
		// Parameters Passed     : intInstrumentSlitType,it is a slit type
		// Parameters affected   : intInstrumentSlitType.
		// Returns               : Double,slit width
		// Purpose               : Get the Slit width
		// Description           : 
		// Assumptions           : 
		// Dependencies          : global data structure,instrument connection.
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to get slit width value
		//'from the value of global data structure
		//'as per the slitType.
		double dblSWidth;

		try {
			//  sw = ((double)80.0-(double) Inst.Slitpos)/(double)40.0;
			if (intInstrumentSlitType == 0) {
				//'check a cond as per instrument slit type.
				dblSWidth = (80.0 - (double)gobjInst.SlitPosition) / 40;
			} else if (intInstrumentSlitType == 1) {
				dblSWidth = (80.0 - (double)gobjInst.SlitPositionExit) / 40;
			}
			funcGet_SlitWidth = dblSWidth;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			funcGet_SlitWidth = -1;
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

	public bool funcDecr_Height()
	{
		//=====================================================================
		// Procedure Name        : funcDecr_Height
		// Parameters Passed     : None
		// Returns               : Boolean
		// Purpose               : Decrease the burner Height
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : praveen
		// =====================================================================
		//'note:
		//'this is used to decrement the burner height 
		//'first get a current burner position 
		//'convert it in to step.
		//'check the cond for burner step
		//'and now decrement the burner heigth by roating it in anti clock wise direction.


		//void     S4FUNC Decr_Height()
		//{
		// Get_BH_Pos();
		//If (Inst.Bhstep >= BHSTEP) Then
		//BH_RotateAnticlock_Steps(BHSTEP);
		//}
		try {
			funcDecr_Height = false;
			if (gobjCommProtocol.func_Get_BH_Pos() == true) {
				if (gobjInst.BhStep >= BHSTEP) {
					//'here BHSTEP is a constant=44.0
					//'serial communication function for roating a burner in a anti clock direction
					gobjCommProtocol.func_BHRotateAntiClock_Steps(BHSTEP);
				}
				funcDecr_Height = true;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool funcIncr_Height()
	{
		//=====================================================================
		// Procedure Name        : funcIncr_Height
		// Parameters Passed     : None
		// Returns               : Boolean
		// Purpose               : Increase the burner Height
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to Increment the burner height 
		//'first get a current burner position 
		//'convert it in to step.
		//'check the cond for burner step
		//'and now decrement the burner heigth by roating it in clock wise direction.

		double dblSWidth;

		try {
			funcIncr_Height = false;
			if (gobjCommProtocol.func_Get_BH_Pos() == true) {
				//'for getting burner current position.
				if (gobjInst.BhStep <= (MAXBHHOME - BHSTEP)) {
					//'serial communication function for roating burner height in a clock wise direction for step.
					gobjCommProtocol.func_BHRotateClock_Steps(BHSTEP);
				}
				funcIncr_Height = true;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool funcBurner_Type()
	{
		//=====================================================================
		// Procedure Name        : funcBurner_Type
		// Parameters Passed     : none
		// Returns               : Boolean
		// Purpose               : to get a burner type
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note;
		//'get a burner parameter from instrument.
		//'and return a true or false as per.

		byte bytBUR_PAR;

		try {
			////---------------
			//           BYTE st1;

			//st1 = CHECK_BUR_PAR();
			//           If (st1 & AA_CONNECTED) Then
			//return TRUE; // 100 mm Burner
			//           Else
			//return FALSE;
			////--------------
			//'To check Burner parameters
			if (gobjCommProtocol.funcCheckBurnerParameters(bytBUR_PAR) == true) {
				//'bytBUR_PAR,bdata as byte
				//---following line is code is changed by Deepak on 09.12.08
				//If (bytBUR_PAR & EnumErrorStatus.AA_CONNECTED) Then
				if ((bytBUR_PAR & EnumErrorStatus.AA_CONNECTED)) {
					return true;
					////---- 100 mm Burner
				} else {
					return false;
				}
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

	public int funcGetMaxLamp()
	{
		//=====================================================================
		// Procedure Name        : funcGetMaxLamp
		// Parameters Passed     : None
		// Returns               : Integer
		// Purpose               : Get max no of lamps.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : praveen
		//=====================================================================

		//'note;
		//'this is used to get max no of lamp ,that can be connected to instrument'
		//'as per application mode.

		////---------------
		//if( InstType == AA202 )
		//	return 2;
		//else
		//	return 6;
		////--------------

		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				return 2;
			//'2 for 201
			} else {
				return 6;
				//'for other
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

	public double funcReadBurnerHeight()
	{
		//=====================================================================
		// Procedure Name        : funcReadBurnerHeight
		// Parameters Passed     : None
		// Returns               : double
		// Purpose               : Read the burner Height
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to get burner height as per burner step.
		//'for it we used global inst object, for getting a burnerstep.
		double dblBH = 0.0;

		try {
			//double	bh=0.0;
			//bh=  ConvertToBurnerHeight(Inst.Bhstep);
			if (gobjInst.BhStep > -1) {
				dblBH = funcConvertToBurnerHeight(gobjInst.BhStep);
				//'function for converting burner step in to height
			}

			return dblBH;
		//'return a burner height.

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

	public object funcAdj_D2Gain(bool blnSetWvFlag, ref object lblWvStatus = null)
	{
		//=====================================================================
		// Procedure Name        : funcAdj_D2Gain
		// Parameters Passed     : blnSetWvFlag,lblWvStatus
		// Returns               : None
		// Purpose               : Adj D2 Gain  
		// Description           : this is called for adjusting a D2gain
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		double dblIniWv = 0.0;

		try {
			dblIniWv = gobjInst.WavelengthCur;
			//'gobjInst is a global object which contain a instrument parameter
			if (gobjCommProtocol.Wavelength_Position((double)UVGAINWV, lblWvStatus) == true) {
				//'this is bool function which position the wavelength and return true
				gobjCommProtocol.funcSet_PMT(220.0);
				//'this is a serial communication function for setting a given pmt value to
				//'instrument
				if (gobjCommProtocol.funcAdj_Pmt_ForValue((4600.0 * 100.0 / 5000.0), 700.0, true)) {
					//'To adjust pmt voltage to obtain maximum energy
					gobjInst.D2Pmt = (int)gobjInst.PmtVoltage;
				}
			}

			if (blnSetWvFlag == true) {
				gobjCommProtocol.Wavelength_Position((double)dblIniWv, lblWvStatus);
				//communication function for position the wavelength
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

	//======================================================================================================


	//============Functions of \Service Utility\Service Routine\frmAnalog===================================

	public bool funcbtnSet_PMT(double dblPMT)
	{
		//=====================================================================
		// Procedure Name        : funcbtnSet_PMT
		// Parameters Passed     : dblPMT
		// Returns               : True or False
		// Purpose               : To Set the PMT voltage.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user click on set PMT.
		//'this will used a serial communication and set a given PMT to instrument.
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.funcSet_PMT(dblPMT) == true) {
				//'serial communication function for setting pmt
				return true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	public bool funcbtnADCNonFilter(ref double dblmv)
	{
		//=====================================================================
		// Procedure Name        : funcbtnADCNonFilter
		// Parameters Passed     : dblmv
		// Returns               : True or False
		// Purpose               : To get the value of ADC Non Filter.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user click on ADC non Filter button.
		//'here [OUT] intAvgInmv : avg. of ADC count return =dblmv
		//Dim objWait As New CWaitCursor
		try {
			if (gobjCommProtocol.funcReadADCNonFilter(dblmv) == true) {
				//'serial communication function for reading a ADC Non filter
				return true;
			}
			return false;
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

	public bool funcbtnADCFilter(int intAvgFactor, ref double dblmv)
	{
		//=====================================================================
		// Procedure Name        : funcbtnADCNonFilter
		// Parameters Passed     : intAvgFactor,dblmv
		// Returns               : True or False
		// Purpose               : To get th value of ADC Filter.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user click on ADC filter button
		//'this is used to read a ADC filter.
		//Dim objWait As New CWaitCursor
		try {
			if (gobjCommProtocol.funcReadADCFilter(intAvgFactor, dblmv) == true) {
				//'serial communication function for reading ADC filter
				return true;
			}
			return false;
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
			//If Not objWait Is Nothing Then
			//    objWait.Dispose()
			//End If
			//---------------------------------------------------------
		}
	}

	public bool funcbtnSetMode(byte byteSetMode)
	{
		//=====================================================================
		// Procedure Name        : funcbtnSetMode
		// Parameters Passed     : byteSetMode 
		// Returns               : True or False
		// Purpose               : To set instrument mode.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Sachin Dokhale
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user click on set mode button
		//'this is used to set a given mode 
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.funcCalibrationMode(byteSetMode) == true) {
				//'serial communication for setting calibration mode to instrument
				return true;
			}

			return false;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	//======================================================================================================


	//============Functions of \Service Utility\Service Routine\frmMonochromator============================

	public bool funcbtnWvHome(ref Label objWv = null)
	{
		//=====================================================================
		// Procedure Name        : funcbtnWvHome
		// Parameters Passed     : objWv,it is a label for showing a status.
		// Returns               : True or False
		// Purpose               : To position the wavelength at its Home position.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user clicked on wave length home button.
		//'this is use for setting a wavelength at home position.
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (gobjCommProtocol.gFuncWavelength_Home(objWv) == true) {
				//'serial communication function for setting wavelength home from the given posotion
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnSlitHome()
	{
		//=====================================================================
		// Procedure Name        : funcbtnSlitHome
		// Parameters Passed     : none
		// Returns               : True or False
		// Purpose               : To position the slit at its Home position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user clicked on slit home buttton.
		//'this is used to set slit at home position.
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.gFuncSlit_Home() == true) {
				//'serial communication function for setting slit at HOME position
				return true;
			}
		//End If
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	public bool funcbtnWvPosition(double dblWvPosition, ref object lblWvRec = null)
	{
		//=====================================================================
		// Procedure Name        : funcbtnWvPosition
		// Parameters Passed     : dblWvPosition,lblWvRec
		// Returns               : True or False
		// Purpose               : To position the Wavelength at said position from current position 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on wavelength position button.
		//'this is used to set a wavelength at given position.
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.Wavelength_Position(dblWvPosition, lblWvRec) == true) {
				//'serial communication function for setting wavelength.
				//'here lblWvRec is a status label.
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnSlitWidth(double dblSlitWidth)
	{
		//=====================================================================
		// Procedure Name        : funcbtnSlitWidth
		// Parameters Passed     : dblSlitWidth
		// Returns               : True or False
		// Purpose               : To set the slit width
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to slit width 
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth) == true) {
				//'serial communication function for setting given slit width to instrument
				return true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	//======================================================================================================


	//============Functions of \Service Utility\Service Routine\frmManualIgnition===========================

	public bool funcbtnAIRONOFF(bool blnAir, ref bool blnAir1)
	{
		//=====================================================================
		// Procedure Name        : funcbtnAIRONOFF
		// Parameters Passed     : blnAir,blnAir1
		// Returns               : True or False
		// Purpose               : To put the AIt pressure ON or OFF.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is to put air ON/OFF as per given flag. 
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (blnAir == false) {

				if (gobjCommProtocol.funcAir_OFF() == true) {
					//'serial communication function for setting airoff.
					//gobjMessageAdapter.ShowMessage(constCongratsOFFAir)
					blnAir1 = true;
					return true;
				}
			} else {
				if (gobjCommProtocol.funcAir_ON() == true) {
					//'serial communicatioin for setting air ON.
					//gobjMessageAdapter.ShowMessage(constCongratsONAir)
					blnAir1 = false;
					return true;
				}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnN2OONOFF(bool blnN2O, ref bool blnN2O1)
	{
		//=====================================================================
		// Procedure Name        : funcbtnN2OONOFF
		// Parameters Passed     : blnN2O,blnN2O1
		// Returns               : True or False
		// Purpose               : To put the N2O pressure ON or OFF.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		///'this is used to set N2 ON/OFF as per given flag.
		CWaitCursor objWait = new CWaitCursor();
		try {

			if (blnN2O == false) {
				if (gobjCommProtocol.func_N2O_OFF() == true) {
					//'serial communication function for setting N2O OFF
					blnN2O1 = true;
					return true;
				}
			} else {
				if (gobjCommProtocol.func_N2O_ON() == true) {
					//'serial communication function for setting N2O ON
					blnN2O1 = false;
					return true;
				}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnFUELONOFF(bool blnFUEL, ref bool blnFUEL1)
	{
		//=====================================================================
		// Procedure Name        : funcbtnFUELONOFF
		// Parameters Passed     : blnFUEL,blnFUEL1
		// Returns               : True or False
		// Purpose               : To put the FUEL ON or OFF.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : praveen
		//=====================================================================

		//'note:
		//'this is used to set fuel ON/OFF as per given falg value.
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (blnFUEL == false) {
				if (gobjCommProtocol.func_FUEL_OFF() == true) {
					//'serial communication for setting fuel OFF

					blnFUEL1 = true;
					return true;
				}
			//End If
			} else {

				if (gobjCommProtocol.func_FUEL_ON() == true) {
					//'serial communication for setting fuel ON
					blnFUEL1 = false;
					return true;
				}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcbtnIGNITEONOFF(string strIgnite, ref string strIgnite1)
	{
		//=====================================================================
		// Procedure Name        : funcbtnIGNITEONOFF
		// Parameters Passed     : strIgnite,strIgnite1
		// Returns               : True or False
		// Purpose               : To put the IGNITE ON or OFF.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : instrument connection.
		// Author                : Saurabh S
		// Created               : 29.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used to set ignite on/off as per given flag value
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (strIgnite == "YES") {
				//--- Set Ignition off

				if (gobjCommProtocol.func_IGNITE_OFF() == true) {
					strIgnite1 = "NO";
					//gobjInst.Aaf = False
					return true;
				}
			} else {
				//--- Ignition on

				if (gobjCommProtocol.func_IGNITE_ON() == true) {
					//'serial communication function for 
					//gobjMessageAdapter.ShowMessage(constCongratsONIGNITE)
					//Application.DoEvents()
					strIgnite1 = "YES";
					//gobjInst.Aaf = True
					return true;
				}
				//End If
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	//======================================================================================================

	public DataRow funcGetCookBookDetailRow(int intDetailsID)
	{
		//=====================================================================
		// Procedure Name        : funcGetCookBookDetailRow
		// Parameters Passed     : intDetailsID
		// Returns               : DataRow
		// Purpose               : To get cook book details row
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection.
		// Author                : Deepak B.
		// Created               : 15.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'here info is come from the database.
		DataRow objDr;
		try {
			//--- Get the data row of Element from given element ID
			objDr = gobjDataAccess.GetCookBookDetailRow(intDetailsID);
			//--- Return Data row
			return objDr;
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	//============================================================================
	public void ReInitInstParameters()
	{
		//=====================================================================
		// Procedure Name        : ReInitInstParameters
		// Parameters Passed     : none
		// Returns               : None
		// Purpose               : this is used to set warmupcurrent to warmup lamp if any else set current to lamp.
		//                         the set a PMT'and validate a D2 lamp.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : serial communication 
		// Author                : 
		// Created               : 15.12.06
		// Revisions             : Deepak on 23.01.08 removed bug
		//=====================================================================
		//int i,dcur;
		//double lampcur,warmupcur;

		//                            If (!Commflag) Then
		//	return;
		//if(Inst.Lamp_pos>=1 && Inst.Lamp_pos<=6) {
		//  if (Inst.Mode==AA || Inst.Mode ==HCLE || Inst.Mode==AABGC ||Inst.Mode==AABGCSR){
		//		lampcur=Inst.Cur;
		//		warmupcur=Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur;
		//	  for(i=1;i<=6;i++){
		//		  if( (i == Inst.Lamp_pos) || ((Inst.Lamp_warm>0 && Inst.Lamp_warm<7) && (i == Inst.Lamp_warm))){
		//			  if(i == Inst.Lamp_warm)
		//				  Set_HCL_Cur(warmupcur,Inst.Lamp_warm);
		//                                                Else
		//				  Set_HCL_Cur(lampcur,Inst.Lamp_pos);
		//		  }
		//		  else
		//			  Set_HCL_Cur(0,i);
		//	  }
		//	  Inst.Cur=lampcur;
		//	  Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur=warmupcur;
		//  }
		//  Set_PMT(Inst.Pmtv);
		//                                                    If (Inst.D2cur > 100) Then
		//	 Set_D2_Cur(Inst.D2cur);
		//  else{
		//	 dcur=100;
		//	 Transmit(D2CUR, (BYTE)(dcur), (BYTE) (dcur>>8), 0);
		//#If NEWHANDSHAKE Then
		//	 Recev(TRUE);
		//#End If
		//	 D2_OFF();
		//  }
		//}

		int i;
		int dcur;
		//'here i used for counter
		double lampcur;
		double warmupcur;
		int intMaxLamp;
		try {
			intMaxLamp = funcGetMaxLamp();

			//10.12.07
			if (gobjCommProtocol.mobjCommdll.gFuncResumeProcess == true) {
				//If (gobjInst.Lamp_Position >= 1 And gobjInst.Lamp_Position <= 6) Then
				if ((gobjInst.Lamp_Position >= 1 & gobjInst.Lamp_Position <= intMaxLamp)) {
					//checking a lamp position for lamp betw1 to 6.

					ReInitLampInstParameters = true;
					//If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
					//'checking for warmup lamp position 
					if ((gobjInst.Mode == EnumCalibrationMode.AA | gobjInst.Mode == EnumCalibrationMode.HCLE | gobjInst.Mode == EnumCalibrationMode.AABGC | gobjInst.Mode == EnumCalibrationMode.AABGCSR)) {
						//'setting current as par selected mode

						//changed by Deepak on 07.12.07
						//lampcur = gobjInst.Current
						//lampcur = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
						//changed by Sachin Dokhaler on 14.02.08
						lampcur = gobjInst.Current;
						//'for eg here we are storing gobjInst.Current value in to temp valiable 

						//If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
						if ((gobjInst.Lamp_Warm > 0) & (gobjInst.Lamp_Warm <= intMaxLamp)) {
							warmupcur = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Warm - 1).Current;
						}
						//
						//For i = 1 To 6
						for (i = 1; i <= intMaxLamp; i++) {
							//If ((i = gobjInst.Lamp_Position) Or ((gobjInst.Lamp_Warm > 0 And gobjInst.Lamp_Warm < 7) And (i = gobjInst.Lamp_Warm))) Then
							if (((i == gobjInst.Lamp_Position) | ((gobjInst.Lamp_Warm > 0 & gobjInst.Lamp_Warm <= intMaxLamp) & (i == gobjInst.Lamp_Warm)))) {
								if ((i == gobjInst.Lamp_Warm)) {
									//'if lamp is warmup then
									//If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
									if ((gobjInst.Lamp_Warm > 0) & (gobjInst.Lamp_Warm <= intMaxLamp)) {
										gobjCommProtocol.funcSet_HCL_Cur(warmupcur, gobjInst.Lamp_Warm);
									}
								//'serial communication function for setting HCL current for warmmup lamp
								} else {
									//'else
									gobjCommProtocol.funcSet_HCL_Cur(lampcur, gobjInst.Lamp_Position);
								}
							} else {
								gobjCommProtocol.funcSet_HCL_Cur(0, i);
								//'otherwise set a lamp current 0.
							}
						}
						gobjInst.Current = lampcur;
						//
						//If (gobjInst.Lamp_Warm > 0) And (gobjInst.Lamp_Warm < 7) Then
						if ((gobjInst.Lamp_Warm > 0) & (gobjInst.Lamp_Warm <= intMaxLamp)) {
							gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Warm - 1).Current = warmupcur;
						}

						//'store current vale of lampcurrent and warmup lamp current
					}
					//End If

					gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage);
					//'set a pmt value
					if ((gobjInst.D2Current > 100)) {
						//'check for D2 current
						gobjCommProtocol.funcSetD2Cur(gobjInst.D2Current);
					} else {
						//'else put D2 lamp off.
						dcur = 100;

						//gobjCommProtocol.mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.D2CUR, CByte(dcur), CByte(dcur >> 8), 0)


						//'gobjCommProtocol.funcSetD2Cur(dcur)     '---27.05.09

						//---'---27.05.09 DB
						if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
							if (gstructSettings.NewModelName == true) {
								if (!gobjNewMethod == null) {
									if (!gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA & !gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
										gobjCommProtocol.funcSetD2Cur(dcur);
										//10.12.07
									}
								} else {
									gobjCommProtocol.funcSetD2Cur(dcur);
									//10.12.07
								}
							} else {
								gobjCommProtocol.funcSetD2Cur(dcur);
								//10.12.07
							}
						} else {
							gobjCommProtocol.funcSetD2Cur(dcur);
							//10.12.07
						}
						//---'---27.05.09


						//#If NEWHANDSHAKE Then
						//	 Recev(TRUE);
						//#End If
						gobjCommProtocol.D2_OFF();
					}
					ReInitLampInstParameters = false;
				}
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

	public bool funcInstReset()
	{
		//=====================================================================
		// Procedure Name        : ReInitInstParameters
		// Parameters Passed     : none
		// Returns               : None
		// Purpose               : this is used to set warmupcurrent to warmup lamp if any else set current to lamp.
		//                         the set a PMT'and validate a D2 lamp.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : serial communication 
		// Author                : Sachin Dokhale
		// Created               : 15.1.08
		// Revisions             : 
		//=====================================================================
		// if(Resetcont){
		// Resetcont=0;
		// MessageBox(NULL,"Instrument Continuous Reset Flag Cleared","Information",MB_OK);
		//}
		//else{
		// Resetcont=1;
		// MessageBox(NULL,"Instrument Continuous Reset Flag Enabled","Information",MB_OK);
		//}
		try {
			if (gblnIsInstReset == true) {
				gblnIsInstReset = false;
				//m_tmr_tick_count = 0
				//If Not tmr Is Nothing Then
				//    RemoveHandler tmr.Tick, AddressOf tmr_tick
				//    tmr.Enabled = False
				//    tmr.Dispose()
				//End If
				gobjMessageAdapter.ShowMessage("Instrument Continuous Reset Flag Cleared", "Information", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
			} else {
				gblnIsInstReset = true;
				gobjMessageAdapter.ShowMessage("Instrument Continuous Reset Flag Enabled", "Information", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				//---to call function for alt R
				//funcAlt_R()
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

	//Public Function funcAlt_R() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcAlt_R
	//    ' Parameters Passed     : none
	//    ' Returns               : None
	//    ' Purpose               : For shortcut alt R
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : serial communication 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 23.01.08
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try
	//        tmr = New Timer
	//        tmr.Interval = 1000
	//        AddHandler tmr.Tick, AddressOf tmr_tick
	//        tmr.Enabled = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        tmr.Enabled = False
	//        Return False
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

	//Private Sub tmr_tick(ByVal sender As Object, ByVal e As EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : tmr_tick
	//    ' Parameters Passed     : 
	//    ' Returns               : None
	//    ' Purpose               : For shortcut alt R
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : serial communication 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 23.01.08
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim dbltime_sec, dbltime_min As Double
	//    Try
	//        m_tmr_tick_count = m_tmr_tick_count + 1
	//        dbltime_sec = m_tmr_tick_count * (tmr.Interval / 1000)
	//        dbltime_min = dbltime_sec / 60

	//        If dbltime_min <= 1 Then
	//            If clsRS232Main.IsInCommu = False Then
	//                If gintCommPortSelected > 0 Then
	//                    Application.DoEvents()
	//                    If gblnIsInstReset = True Then
	//                        gobjClsAAS203.ReInitInstParameters()
	//                    End If
	//                End If
	//            End If
	//        Else
	//            m_tmr_tick_count = 0
	//            RemoveHandler tmr.Tick, AddressOf tmr_tick
	//            tmr.Enabled = False
	//            tmr.Dispose()
	//            gblnIsInstReset = False
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	public bool funcAutoZeroAbsMode()
	{
		//=====================================================================
		// Procedure Name        : funcAutoZeroAbsMode
		// Parameters Passed     :  
		// Returns               : True or False
		// Purpose               : To set Auto zero for abs mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen 
		//=====================================================================
		//'note:
		//-- this is used to call auto zero function.

		try {
			//    BOOL 	S4FUNC 	AutoZeroAbsMode(HWND hpar)
			//{
			//  Cal_Mode(AA);
			//  return Adj_PMT_forvalue(hpar, (double) 0.0 , (double)600);
			//}
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//'check for 203D

				return funcAutoZeroAbsModeDB();
			//'for 203D
			} else {
				//Return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, True)
				return funcAutoZeroAbsModeSB();
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

	public bool funcAutoZeroAbsModeSB()
	{
		//=====================================================================
		// Procedure Name        : funcAutoZeroAbsModeSB
		// Parameters Passed     :  
		// Returns               : True or False
		// Purpose               : To set Auto zero for abs mode, Single mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note
		//'this is a auto zero function for single beam.
		try {
			//    BOOL 	S4FUNC 	AutoZeroAbsMode(HWND hpar)
			//{
			//  Cal_Mode(AA);
			//  return Adj_PMT_forvalue(hpar, (double) 0.0 , (double)600);
			//}
			gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
			//'serial communication function
			//'set the calibration mode as AA
			return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, true);
		//'adjust a PMT voltage.

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

	public bool funcAutoZeroAbsModeDB()
	{
		//=====================================================================
		// Procedure Name        : funcAutoZeroAbsModeDB
		// Parameters Passed     :  None
		// Returns               : True or False
		// Purpose               : To set Auto zero for abs mode.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//this will call a autozero function for double beam.
		try {
			//    BOOL 	S4FUNC 	AutoZeroAbsMode(HWND hpar)
			//{
			//  Cal_Mode(AA);
			//  return Adj_PMT_forvalue(hpar, (double) 0.0 , (double)600);
			//}
			gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
			//'serial communication for setting a calibration mode.

			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				//'set a PMT for SingleBeam
				return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, true);
			//'for adjusting PMT 
			} else if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam) {
				//'set a PMT for ReferenceBeam
				return gobjCommProtocol.funcAdj_Pmt_ForValue_Ref(0.0, 600, true);
			//'for adjusting PMT 
			} else if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				//'set a PMT for DoubleBeam
				if (gobjCommProtocol.funcAdj_Pmt_ForValue_Ref(0.0, 600, true) == true) {
					//'for adjusting PMT 
					gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, true);
					gobjCommProtocol.funcGetRefBaseVal();
					//'for getting reference baseline.
					return true;
				}
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

	public bool funcBgc_Zero(bool blnFlag)
	{
		//=====================================================================
		// Procedure Name        : funcBgc_Zero
		// Parameters Passed     :  blnFlag
		// Returns               : True or False
		// Purpose               : To set Auto zero for BGC mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this will call a function for Auto zero of BGC mode.
		try {
			// BOOL	S4FUNC 	Bgc_Zero(HWND hpar, BOOL flag1)
			//{
			// return(Bgc_Zero1(hpar, flag1, 3000.0));
			//}
			//--- To set Auto zero for BGC mode
			return funcBgc_Zero1(blnFlag, 3000.0);

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

	private bool funcBgc_Zero1(bool flag1, double Value)
	{
		//=====================================================================
		// Procedure Name        : funcBgc_Zero1
		// Parameters Passed     :  flag1,Value
		// Returns               : True or False
		// Purpose               : To set Auto zero for BGC mode 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================

		try {
			//           BOOL	S4FUNC 	Bgc_Zero1(HWND hpar, BOOL  flag1, double value)
			//{
			// if (ReadIniForD2Gain()|| ReadIniForMesh())
			//	  return Bgc_Zero3(hpar, flag1, value);
			//            Else
			//	  return Bgc_Zero2(hpar, flag1, value);
			//}

			//--- To set Auto zero for BGC mode when Mesh is used or D2 Gain is used
			if ((gstructSettings.D2Gain == true) | (gstructSettings.Mesh == true)) {
				//'check for a D2 gain and Mesh
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
					//'for 203D 

					//    If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
					//        If funcBgc_Zero3_RefBeam(flag1, Value) Then
					//            funcBgc_Zero3(flag1, Value)
					//            Call gobjCommProtocol.funcGetRefBaseVal()
					//            Return True
					//        End If
					//    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
					//        Return funcBgc_Zero3_RefBeam(flag1, Value)
					//    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
					//        Return funcBgc_Zero3(flag1, Value)
					//    End If
					return funcBgc_Zero3(flag1, Value);
					//Added by Saurabh
				} else {
					//'for other 201,203
					return funcBgc_Zero3(flag1, Value);
				}
			} else {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
					//Commented by Saurabh
					//If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
					//    If funcBgc_Zero2_RefBeam(flag1, Value) Then
					//        funcBgc_Zero2(flag1, Value)
					//        Call gobjCommProtocol.funcGetRefBaseVal()
					//        Return True
					//    End If
					//ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
					//    Return funcBgc_Zero2_RefBeam(flag1, Value)
					//ElseIf gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
					//    Return funcBgc_Zero2(flag1, Value)
					//End If
					//Commented by Saurabh
					//'for 203
					return funcBgc_Zero2(flag1, Value);
					//Added by Saurabh
				} else {
					//'for other instrument
					return funcBgc_Zero2(flag1, Value);
				}
				//Return funcBgc_Zero2(flag1, Value)
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

	private bool funcBgc_Zero2(bool flag1, double dblvalue)
	{
		//===========================================================s==========
		// Procedure Name        : funcBgc_Zero2
		// Parameters Passed     : flag1, value
		// Returns               : True or False
		// Purpose               : To set Auto zero for BGC mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		int intXmode;
		int chnew;
		int a;
		int b;
		int MaxD2Cur;
		int MinD2Cur;
		int intD2cur;
		frmPMT objfrmSettingPMT = new frmPMT();
		//'this is a object for form pmt Setting dialog box.
		double x1;
		int addf = 1;
		int chIdx;
		//'this is "chIdx" for index counter
		bool Flag = true;

		a = 0;
		b = 0;
		MaxD2Cur = 300;
		MinD2Cur = 100;
		//'intialise the variables
		try {
			////------
			//Set_D2_Cur(d2cur);
			//		if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//	  }
			//	 for(i=0; i<4; i++)
			//		chnew = ReadADCFilter();
			//	 strcpy(line1,"");
			//	 x1 = (chnew-2047.0)/4096.0*10000.0;
			//                    If (GetSRLamp()) Then
			//		sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
			//                    Else
			//		sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
			//	 SetText(hwnd, IDC_STATUS1,line1);
			//	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
			//	 if (x1>(value+1000.0))  addf=-10;
			//	 else if (x1>(value+200.0))  addf=-5;
			//	 else if (x1>(value+20.0)) { addf=-1; a++;
			//			 if (b>10) b=1; }
			//	 if (x1<(value-1000.0)) addf=10;
			//	 else if (x1<(value-200.0)) addf=5;
			//	 else if (x1<(value-20.0)) { addf=1; b++;}
			//	 d2cur+=addf;
			//	 if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
			//		 if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
			//		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
			//		 pc_delay(5000);
			//		 flag = FALSE; d2cur=MinD2Cur; break;}
			//	 if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
			//		 if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
			//		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
			//		 pc_delay(5000);
			//		 flag = FALSE; d2cur=MaxD2Cur;break;}
			//                                                        If (a > 10) Then
			//		{ if (b>10)  break;
			//		 else a =0;
			//		}
			//	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
			//		break;
			//	}
			////-------

			if (gobjCommProtocol.SRLamp) {
				//'check for SR lamp.
				MaxD2Cur = 600;
				MinD2Cur = 100;
			} else {
				MaxD2Cur = 300;
				MinD2Cur = 100;
			}

			intXmode = gobjInst.Mode;
			//'get instrument current mode in a intXmode

			if ((flag1)) {
				//'this is a flag pass by user

				//objfrmSettingPMT.Show()
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				//'set a calibration mode
				//--- adjusting PMT to the 0.0 range and max Pmt volt limit is 700, 
				//--- and Set 'True' flag for setting autozero
				gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 700.0, true);

				//objfrmSettingPMT.Close()
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			objfrmSettingPMT = new frmPMT();
			objfrmSettingPMT.Text = "BGC ZERO";
			objfrmSettingPMT.Refresh();
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			if (gobjCommProtocol.SRLamp) {
				//'check for SR lamp.
				//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
				objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :";
			//'set a dialog title. 
			} else {
				//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
				objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT :";
			}
			objfrmSettingPMT.lblTitle.Refresh();

			objfrmSettingPMT.Show();
			//'show pmt dialog box
			objfrmSettingPMT.BringToFront();
			//'show the dialog of PMT 
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E);
			//'set a calibration mode to D2E

			//if( GetInstrument() == AA202 ){
			//              If (GetSRLamp()) Then
			//d2cur = d2cur;
			//              Else
			//d2cur=Inst->D2cur;
			//}
			//else
			// d2cur=Inst->D2cur;

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				//If (GetSRLamp()) Then
				if (gobjCommProtocol.SRLamp == true) {
					//'check for SR lamp in 201
					intD2cur = intD2cur;
				} else {
					intD2cur = gobjInst.D2Current;
				}
			} else {
				intD2cur = gobjInst.D2Current;
			}
			//intD2cur = gobjInst.D2Current

			////
			while ((true)) {
				//'loop start

				//Set_D2_Cur(d2cur);
				//		if(GetInstrument() == AA203 ){
				//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
				//		 Set_PMT(Inst->Pmtv);
				//	  }
				gobjCommProtocol.funcSetD2Cur(intD2cur);
				//'set a D2 current as per passed value.
				//if(GetInstrument() = AA203 ) then
				gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
				//'set a HCL current at given lamp position.
				gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage);
				//'set a PMT
				//end if

				//5    '02.08.07
				for (chIdx = 0; chIdx <= 3; chIdx++) {
					//for(i=0; i<4; i++)
					//chnew = ReadADCFilter();
					gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chnew);
					//read a ADC filter value.
				}
				//x1 = (chnew-2047.0)/4096.0*10000.0;
				x1 = (chnew - 2047.0) / 4096.0 * 10000.0;
				//'get X1 as per chnew 

				//If (GetSRLamp()) Then
				//sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
				//              Else
				//sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

				if (gobjCommProtocol.SRLamp) {
					//'draw a PMT setting dialog as per SR lamp.

					//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
					objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " + intD2cur.ToString + " mA " + "Energy. : " + (string)Format(((100.0 / dblvalue) * x1), "#0.00");
				} else {
					//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
					objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " + intD2cur.ToString + " mA " + "Energy. : " + (string)Format(((100.0 / dblvalue) * x1), "#0.00");
				}
				objfrmSettingPMT.lblMsg.Refresh();
				Application.DoEvents();

				//'allow application to perfrom its panding work.


				//	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
				//	 if (x1>(value+1000.0))  addf=-10;
				//	 else if (x1>(value+200.0))  addf=-5;
				//	 else if (x1>(value+20.0)) { addf=-1; a++;
				//			 if (b>10) b=1; }
				//	 if (x1<(value-1000.0)) addf=10;
				//	 else if (x1<(value-200.0)) addf=5;
				//	 else if (x1<(value-20.0)) { addf=1; b++;}
				//	 d2cur+=addf;

				//02.08.07
				if ((x1 <= (dblvalue + 20.0) & x1 >= (dblvalue - 20.0))) {
					break; // TODO: might not be correct. Was : Exit Do
				}

				//If (x1 <= (dblvalue + 10.0) And x1 >= (dblvalue - 10.0)) Then     '02.08.07
				//    Exit Do
				//End If

				////
				//if (x1>(value+1000.0))  addf=-10;
				//else if (x1>(value+200.0))  addf=-5;
				//else if (x1>(value+20.0)) { addf=-1; a++;
				//if (b>10) b=1; }
				////

				if ((x1 > (dblvalue + 1000.0))) {
					addf = -10;
				} else if ((x1 > (dblvalue + 200.0))) {
					addf = -5;
				} else if ((x1 > (dblvalue + 20.0))) {
					addf = -1;
					a += 1;
					if ((b > 10))
						b = 1;
				}

				//if (x1<(value-1000.0)) addf=10;
				//else if (x1<(value-200.0)) addf=5;
				//else if (x1<(value-20.0)) { addf=1; b++;}
				if ((x1 < (dblvalue - 1000.0))) {
					addf = 10;
				} else if ((x1 < (dblvalue - 200.0))) {
					addf = 5;
				} else if ((x1 < (dblvalue - 20.0))) {
					addf = 1;
					b += 1;
				}

				//d2cur+=addf;
				intD2cur += addf;
				//          if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
				// if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
				// else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
				// pc_delay(5000);
				// flag = FALSE; d2cur=MinD2Cur; break;}

				//if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
				// if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
				// else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
				// pc_delay(5000);
				// flag = FALSE; d2cur=MaxD2Cur;break;}
				//                              If (a > 10) Then
				//{ if (b>10)  break;
				// else a =0;
				//}

				if ((x1 > (dblvalue + 200.0) & intD2cur <= MinD2Cur)) {
					if ((dblvalue == 3000)) {
						//Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO")
						//gobjMessageAdapter.ShowMessage(constReduceHCL)
						gobjMessageAdapter.ShowMessage(constIncreaseHCl);
					} else {
						//Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
						gobjMessageAdapter.ShowMessage(constErrorFULLSCALE);
					}

					//pc_delay(5000);
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
					//'communication delay
					intD2cur = MinD2Cur;
					Flag = false;
					break; // TODO: might not be correct. Was : Exit Do
				}
				if ((x1 < (dblvalue - 200.0) & intD2cur >= MaxD2Cur)) {
					if ((dblvalue == 3000)) {
						//Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
						gobjMessageAdapter.ShowMessage(constReduceHCL);
					} else {
						//Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
						gobjMessageAdapter.ShowMessage(constErrorFULLSCALE);
					}
					//pc_delay(5000);
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
					intD2cur = MaxD2Cur;
					Flag = false;
					break; // TODO: might not be correct. Was : Exit Do
				}
				//;break;}

				if ((a > 10)) {
					if ((b > 10)) {
						break; // TODO: might not be correct. Was : Exit Do
					} else {
						a = 0;
					}
				}
				////-

				if (objfrmSettingPMT.mCancelProcess == true) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				objfrmSettingPMT.BringToFront();
				objfrmSettingPMT.Refresh();
				Application.DoEvents();
			}

			//if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//Set_D2_Cur(d2cur);
			//if(GetInstrument() == AA203 ){
			// Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			// Set_PMT(Inst->Pmtv);
			//}

			if ((intD2cur < MinD2Cur)) {
				intD2cur = MinD2Cur;
			}

			if ((intD2cur > MaxD2Cur)) {
				intD2cur = MaxD2Cur;
			}
			gobjCommProtocol.funcSetD2Cur(intD2cur);
			//'serial communication for setting D2 current.

			//if(GetInstrument() == AA203 ){
			gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
			//'set a HCL current at given position
			gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage);
			//'for setting given pmt voltage.
			//}
			objfrmSettingPMT.Close();
			//'close the PMT voltage form
			Application.DoEvents();
			//Cal_Mode(xmode);
			gobjCommProtocol.funcCalibrationMode(intXmode);
			//'set a calibration mode
			funcBgc_Zero2 = Flag;
		////---

		////

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
			if (!(objfrmSettingPMT == null)) {
				objfrmSettingPMT.Dispose();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool funcBgc_Zero3(bool flag1, double dblvalue)
	{
		//=====================================================================
		// Procedure Name        : funcBgc_Zero3
		// Parameters Passed     :  flag1, value
		// Returns               : True or False
		// Purpose               : To set Auto zero for BGC mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		//int 		d2cur;
		//double   x1=0;
		//int     addf=1,i;
		//char    line1[80]="";
		//BOOL	  flag=TRUE;
		//int     xmode, chnew, a=0, b=0;
		//int	gtry=0;
		//BOOL	Micro=FALSE;
		//BOOL	Gain=FALSE;
		//int MaxD2Cur=300,MinD2Cur = 100;
		////-----
		int intd2cur;
		double dblx1 = 0;
		int intaddf = 1;
		int inti;
		//char    line1[80]="";
		bool blnflag = true;
		int intxmode;
		int intchnew;
		int a = 0;
		int b = 0;
		int intgtry = 0;
		bool blnMicro = false;
		bool blnGain = false;
		int MaxD2Cur = 300;
		int MinD2Cur = 100;
		frmPMT objfrmSettingPMT = new frmPMT();
		//'this is a object for PMT setting dialog.
		int chIdx;
		////-----
		try {
			//if( GetSRLamp() ){
			//	MaxD2Cur = 600;
			//	MinD2Cur = 100;
			//}
			//else{
			//	MaxD2Cur = 300;
			//	MinD2Cur = 100;
			//}
			//  GainX10Off();
			//  SetMicroOff();
			//  WaitForAdc();
			//  xmode = Inst->Mode;

			//  if(GetInstrument() == AA202 ){
			//	 if( GetSRLamp()){
			//		d2cur=Inst->D2cur;
			//                        If (d2cur <= 100) Then
			//			d2cur = 101;
			//		Set_D2_Cur(d2cur);
			//	 }
			//  }
			//  if (flag1) {
			//	 Cal_Mode(AA);
			//	 Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
			//	 }
			//  hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
			//                                If (GetSRLamp()) Then
			//	  SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
			//                                Else
			//	  SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
			//  Cal_Mode(D2E);

			//  if( GetInstrument() == AA202 ){
			//                                        If (GetSRLamp()) Then
			//		d2cur = d2cur;
			//                                        Else
			//		d2cur=Inst->D2cur;
			//  }
			//  else
			//	  d2cur=Inst->D2cur;

			//  while(flag){
			//	 Set_D2_Cur(d2cur);
			//	 if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//	 }
			//	 for(i=0; i<4; i++)
			//		chnew = ReadADCFilter();
			//	 strcpy(line1,"");
			//	 x1 = (chnew-2047.0)/4096.0*10000.0;

			//                                                        If (GetSRLamp()) Then
			//		 sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
			//                                                        Else
			//		 sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

			//	 SetText(hwnd, IDC_STATUS1,line1);
			//	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
			//	 if (x1>(value+1000.0))  addf=-10;
			//	 else if (x1>(value+200.0))  addf=-5;
			//	 else if (x1>(value+20.0)) { addf=-1; a++;
			//			 if (b>10) b=1; }
			//	 if (x1<(value-1000.0)) addf=10;
			//	 else if (x1<(value-200.0)) addf=5;
			//	 else if (x1<(value-20.0)) { addf=1; b++;}
			//	 d2cur+=addf;
			//	 if (d2cur<=MinD2Cur ){
			//		d2cur=MinD2Cur;
			//		Set_D2_Cur(d2cur);

			//		if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//		}

			//	 TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
			//	  }
			//	 if ( d2cur>=MaxD2Cur ){// || (x1<(value-200.0) && d2cur>=300)) {
			////		d2cur=MinD2Cur;
			//		d2cur=101;//MaxD2Cur;
			//		Set_D2_Cur(d2cur);
			//		if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//		}
			//		TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur,value);
			//		}
			//	 if (gtry==4){
			//		if (value==3000)
			//		  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
			//                                                                                                Else
			//		  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
			//		pc_delay(5000);
			//		flag = FALSE; d2cur=MinD2Cur; break;
			//	  }
			//	 if (a>10)	{
			//		 if (b>10)  break;
			//		 else a =0;
			//		}
			//	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
			//		break;
			//	}
			//  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//  if (!flag){
			//	 GainX10Off();
			//	 SetMicroOff();
			//	 Gain = FALSE;
			//	}

			//  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//  Set_D2_Cur(d2cur);
			//  if(GetInstrument() == AA203 ){
			//	Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//	  Set_PMT(Inst->Pmtv);
			//  }
			//  DestroyWindowPeak(hwnd, hpar);
			//  Cal_Mode(xmode);
			//                                                                                                                                        If (Gain) Then
			//	 GainX10On();
			// return flag;
			//}
			//If (GetSRLamp()) Then
			//	MaxD2Cur = 600;
			//	MinD2Cur = 100;
			//}
			//else{
			//	MaxD2Cur = 300;
			//	MinD2Cur = 100;
			//}  

			//======================================

			if (gobjCommProtocol.SRLamp) {
				//'as per the SR lamp set the D2 current.
				MaxD2Cur = 600;
				MinD2Cur = 100;
			} else {
				MaxD2Cur = 300;
				MinD2Cur = 100;
			}

			intxmode = gobjInst.Mode;
			gobjCommProtocol.funcGain10X_OFF();
			//'to set Gain10x off
			gobjCommProtocol.funcSetMICRO_OFF();
			//'to set Micro off
			subWaitForAdc();
			//'wait for ADC.
			//xmode = Inst->Mode;
			intxmode = gobjInst.Mode;
			//'get a mode in to temp variable

			////----- for AA202 
			//if(GetInstrument() == AA202 ){
			//if( GetSRLamp()){
			//d2cur=Inst->D2cur;
			//                  If (d2cur <= 100) Then
			//	d2cur = 101;
			//Set_D2_Cur(d2cur);
			//}
			//}
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				//If (GetSRLamp()) Then
				if (gobjCommProtocol.SRLamp == true) {
					//'check for SR lamp in 201
					//intd2cur = intd2cur
					intd2cur = gobjInst.D2Current;
					if (intd2cur <= 100) {
						intd2cur = 101;
					}
					gobjCommProtocol.funcSetD2Cur(intd2cur);
					//'set as D2 current as per the passed value.
				}
			}
			//if (flag1) {
			//Cal_Mode(AA);
			//Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
			//}
			if ((flag1) == true) {
				//'flag passed by user as parameter

				//objfrmSettingPMT.Show()
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				//'set the calibration mode.

				//--- adjusting PMT to the 0.0 range, max Pmt volt limit is 700, 
				//--- and Set 'True' flag for setting autozero
				gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 700.0, true);

				//'objfrmSettingPMT.Close()
			}

			//hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
			//          If (GetSRLamp()) Then
			// SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
			//          Else
			// SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
			//Cal_Mode(D2E);

			Application.DoEvents();

			objfrmSettingPMT = new frmPMT();
			objfrmSettingPMT.Text = "BGC ZERO";
			objfrmSettingPMT.Refresh();
			//'initialise the  objfrmSettingPMT form object.

			if (gobjCommProtocol.SRLamp) {
				//'for SR lamp
				//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
				//objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :"
				objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT : ";

			} else {
				//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
				objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT : ";
			}
			objfrmSettingPMT.lblTitle.Refresh();

			objfrmSettingPMT.Show();
			Application.DoEvents();
			//'show the dialog and allow application to perfrom its panding work.
			gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E);
			//'set a calibration mode to D2E

			//if( GetInstrument() == AA202 ){
			//              If (GetSRLamp()) Then
			//d2cur = d2cur;
			//              Else
			//d2cur=Inst->D2cur;
			//}
			//else
			// d2cur=Inst->D2cur;

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				//If (GetSRLamp()) Then
				if (gobjCommProtocol.SRLamp == true) {
					//'check for SR lamp.
					//intd2cur = intd2cur
					intd2cur = intd2cur;
				} else {
					intd2cur = gobjInst.D2Current;
				}
			} else {
				intd2cur = gobjInst.D2Current;
			}
			//intd2cur = gobjInst.D2Current

			while ((true)) {
				//'start loop
				gobjCommProtocol.funcSetD2Cur(intd2cur);
				//'set the D2 current
				//if(GetInstrument() = AA203 ) then
				gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
				//'set a given HCL current at given position

				gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage);
				//'for setting given pmt voltage


				//for(i=0; i<4; i++)
				//chnew = ReadADCFilter();
				//strcpy(line1,"");

				for (chIdx = 0; chIdx <= 4; chIdx++) {
					//for(i=0; i<4; i++)
					//chnew = ReadADCFilter();
					gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intchnew);
					//'function for reading a adc FLITER
				}

				//--- Calculate the Abs value
				//x1 = (chnew-2047.0)/4096.0*10000.0;
				dblx1 = (intchnew - 2047.0) / 4096.0 * 10000.0;

				//If (GetSRLamp()) Then
				// sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
				//              Else
				// sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

				//SetText(hwnd, IDC_STATUS1,line1);
				if (gobjCommProtocol.SRLamp) {
					//'for SR lamp
					//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
					objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " + intd2cur.ToString + " mA " + "Energy. : " + (string)Format(((100.0 / dblvalue) * dblx1), "#0.00");
				//objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
				} else {
					//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
					objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " + intd2cur.ToString + " mA " + " Energy. : " + (string)Format(((100.0 / dblvalue) * dblx1), "#0.00");
					//objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
				}

				objfrmSettingPMT.lblMsg.Refresh();
				Application.DoEvents();
				//'allow application to perfrom its panding work.

				//if (x1<=(value+20.0) && x1>=(value-20.0)) break;
				if ((dblx1 <= (dblvalue + 20.0) & dblx1 >= (dblvalue - 20.0))) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				//if (x1>(value+1000.0))  addf=-10;
				//	 else if (x1>(value+200.0))  addf=-5;
				//	 else if (x1>(value+20.0)) { addf=-1; a++;
				//			 if (b>10) b=1; }

				if ((dblx1 > (dblvalue + 1000.0))) {
					intaddf = -10;
				} else if ((dblx1 > (dblvalue + 200.0))) {
					intaddf = -5;
				} else if ((dblx1 > (dblvalue + 20.0))) {
					intaddf = -1;
					a += 1;
					if ((b > 10))
						b = 1;
				}

				//	 if (x1<(value-1000.0)) addf=10;
				//	 else if (x1<(value-200.0)) addf=5;
				//	 else if (x1<(value-20.0)) { addf=1; b++;}
				if ((dblx1 < (dblvalue - 1000.0))) {
					intaddf = 10;
				} else if ((dblx1 < (dblvalue - 200.0))) {
					intaddf = 5;
				} else if ((dblx1 < (dblvalue - 20.0))) {
					intaddf = 1;
					b += 1;
				}
				//d2cur+=addf;
				intd2cur += intaddf;

				//if (d2cur<=MinD2Cur ){
				//d2cur=MinD2Cur;
				//Set_D2_Cur(d2cur);

				//if(GetInstrument() == AA203 ){
				// Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
				// Set_PMT(Inst->Pmtv);
				//}

				//TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
				// }
				if ((intd2cur <= MinD2Cur)) {
					intd2cur = MinD2Cur;
					gobjCommProtocol.funcSetD2Cur(intd2cur);
					//'for setting D2 current

					//If (GetInstrument() = AA203) Then
					gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
					//'set the current at given position
					gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage);
					//'set a PMT voltage.
					//End If
					subTryNextMode(blnGain, blnMicro, intgtry, intd2cur, dblvalue);
				}
				//if (gtry==4){
				//if (value==3000)
				//  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
				//                  Else
				//  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
				//pc_delay(5000);
				//flag = FALSE; d2cur=MinD2Cur; break;
				// }
				if ((intgtry == 4)) {
					if ((dblvalue == 3000)) {
						gobjMessageAdapter.ShowMessage(constReduceHCL);
					} else {
						gobjMessageAdapter.ShowMessage(constErrorFULLSCALE);
					}
					//pc_delay(5000)
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
					//'function for delay
					blnflag = false;
					intd2cur = MinD2Cur;
					//break()
					break; // TODO: might not be correct. Was : Exit Do
				}
				//              if (a>10)	{
				// if (b>10)  break;
				// else a =0;
				//}
				if ((a > 10)) {
					if ((b > 10)) {
						break; // TODO: might not be correct. Was : Exit Do
					} else {
						a = 0;
					}
				}
				////=-=---- Define by Sachin Dokhale
				////----- Set the interupt for exit 
				//if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
				//break;
				if (objfrmSettingPMT.mCancelProcess == true) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				////-----
				objfrmSettingPMT.BringToFront();
				objfrmSettingPMT.Refresh();
				Application.DoEvents();
				//'show the dialog and allow application to perfrom its panding work.
			}
			//if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//  if (!flag){
			//	 GainX10Off();
			//	 SetMicroOff();
			//	 Gain = FALSE;
			//	}
			//--- Set the Min or Max D2 Current if it out of limits 
			if ((intd2cur < MinD2Cur))
				intd2cur = MinD2Cur;
			if ((intd2cur > MaxD2Cur))
				intd2cur = MaxD2Cur;

			if (!(blnflag == true)) {
				gobjCommProtocol.funcGain10X_OFF();
				//'put off the Gain10X
				gobjCommProtocol.funcSetMICRO_OFF();
				//'put off the MICRO
				blnGain = false;
			}
			//if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			// if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			// Set_D2_Cur(d2cur);
			// if(GetInstrument() == AA203 ){
			//Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//  Set_PMT(Inst->Pmtv);
			// }
			//--- Set the Min or Max D2 Current if it out of limits 
			if ((intd2cur < MinD2Cur))
				intd2cur = MinD2Cur;
			if ((intd2cur > MaxD2Cur))
				intd2cur = MaxD2Cur;
			gobjCommProtocol.funcSetD2Cur(intd2cur);
			//'for setting D2 current.
			//if(GetInstrument() = AA203 ) then
			gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
			//'setting HCL current at given position 
			gobjCommProtocol.funcSet_PMT(gobjInst.PmtVoltage);
			//'setting PMT voltage.
			//end if
			//DestroyWindowPeak(hwnd, hpar);
			//Cal_Mode(xmode);

			objfrmSettingPMT.Close();
			Application.DoEvents();
			//'close the PMT form and allow application to perfrom its panding work.
			gobjCommProtocol.funcCalibrationMode(intxmode);
			//'for setting calibration mode.
			//If (Gain) Then
			//GainX10On();
			//return flag;
			if ((blnGain == true)) {
				gobjCommProtocol.funcGain10X_ON();
				//'put Gain10X on
			}
			return blnflag;
		//'it will return true if succed.


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
			if (!(objfrmSettingPMT) == null) {
				objfrmSettingPMT.Dispose();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool funcBgc_Zero2_RefBeam(bool flag1, double dblvalue)
	{
		//===========================================================s==========
		// Procedure Name        : funcBgc_Zero2
		// Parameters Passed     : flag1, value
		// Returns               : True or False
		// Purpose               : To set Auto zero for BGC mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		int intXmode;
		int chnew;
		int a;
		int b;
		int MaxD2Cur;
		int MinD2Cur;
		int intD2cur;
		frmPMT objfrmSettingPMT = new frmPMT();
		//'object for PMT from.
		double x1;
		int addf = 1;
		int chIdx;
		bool Flag = true;

		a = 0;
		b = 0;
		MaxD2Cur = 300;
		MinD2Cur = 100;

		try {
			////------
			//Set_D2_Cur(d2cur);
			//		if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//	  }
			//	 for(i=0; i<4; i++)
			//		chnew = ReadADCFilter();
			//	 strcpy(line1,"");
			//	 x1 = (chnew-2047.0)/4096.0*10000.0;
			//                    If (GetSRLamp()) Then
			//		sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
			//                    Else
			//		sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
			//	 SetText(hwnd, IDC_STATUS1,line1);
			//	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
			//	 if (x1>(value+1000.0))  addf=-10;
			//	 else if (x1>(value+200.0))  addf=-5;
			//	 else if (x1>(value+20.0)) { addf=-1; a++;
			//			 if (b>10) b=1; }
			//	 if (x1<(value-1000.0)) addf=10;
			//	 else if (x1<(value-200.0)) addf=5;
			//	 else if (x1<(value-20.0)) { addf=1; b++;}
			//	 d2cur+=addf;
			//	 if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
			//		 if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
			//		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
			//		 pc_delay(5000);
			//		 flag = FALSE; d2cur=MinD2Cur; break;}
			//	 if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
			//		 if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
			//		 else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
			//		 pc_delay(5000);
			//		 flag = FALSE; d2cur=MaxD2Cur;break;}
			//                                                        If (a > 10) Then
			//		{ if (b>10)  break;
			//		 else a =0;
			//		}
			//	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
			//		break;
			//	}
			////-------

			if (gobjCommProtocol.SRLamp) {
				//'check for SR lamp.
				MaxD2Cur = 600;
				MinD2Cur = 100;
			} else {
				MaxD2Cur = 300;
				MinD2Cur = 100;
			}

			intXmode = gobjInst.Mode;
			//'get a current mode
			if ((flag1)) {
				//'flag set by user
				//objfrmSettingPMT.Show()
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				//'set a calibration mode
				gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 700.0, true);
				//'adjust the PMT in given range.
				//objfrmSettingPMT.Close()
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			objfrmSettingPMT = new frmPMT();
			objfrmSettingPMT.Text = "Balancing Beam";
			objfrmSettingPMT.Refresh();
			//'initialise the objfrmSettingPMT object.
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			if (gobjCommProtocol.SRLamp) {
				//'set for SR lamp.
				//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
				objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :";

			} else {
				//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
				objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT :";
			}
			objfrmSettingPMT.lblTitle.Refresh();

			objfrmSettingPMT.Show();
			objfrmSettingPMT.BringToFront();
			Application.DoEvents();
			//'show the dialog and allow application to perfrom its panding work.
			gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E);
			//'set a calibration mode to D3E

			//if( GetInstrument() == AA202 ){
			//              If (GetSRLamp()) Then
			//d2cur = d2cur;
			//              Else
			//d2cur=Inst->D2cur;
			//}
			//else
			// d2cur=Inst->D2cur;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				//If (GetSRLamp()) Then
				if (gobjCommProtocol.SRLamp == true) {
					//'check for SR lamp in 201
					intD2cur = intD2cur;
				} else {
					intD2cur = gobjInst.D2Current;
				}
			} else {
				intD2cur = gobjInst.D2Current;
			}
			//intD2cur = gobjInst.D2Current

			////
			while ((true)) {
				//'start loop
				gobjCommProtocol.funcSetD2Cur(intD2cur);
				//'set D2 current
				//if(GetInstrument() = AA203 ) then
				gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
				//'set a HCL curr at given position.
				gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference);
				//'set a PMT for reference beam.
				//end if

				for (chIdx = 0; chIdx <= 5; chIdx++) {
					//for(i=0; i<4; i++)
					//chnew = ReadADCFilter();
					gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, chnew);
					//'read a ADC filter
				}
				//x1 = (chnew-2047.0)/4096.0*10000.0;
				x1 = (chnew - 2047.0) / 4096.0 * 10000.0;

				//If (GetSRLamp()) Then
				//sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
				//              Else
				//sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

				if (gobjCommProtocol.SRLamp) {
					//'set for the SR lamp.
					//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
					objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " + intD2cur.ToString + " mA " + "Energy. : " + (string)Format(((100.0 / dblvalue) * x1), "###0.00");
				} else {
					//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
					objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " + intD2cur.ToString + " mA " + "Energy. : " + (string)Format(((100.0 / dblvalue) * x1), "###0.00");
				}
				objfrmSettingPMT.lblMsg.Refresh();
				Application.DoEvents();
				//'allow application to perfrom its panding work.

				//If (x1 <= (dblvalue + 20.0) And x1 >= (dblvalue - 20.0)) Then
				//    Exit Do
				//End If
				if ((x1 <= (dblvalue + 10.0) & x1 >= (dblvalue - 10.0))) {
					break; // TODO: might not be correct. Was : Exit Do
				}

				////
				//if (x1>(value+1000.0))  addf=-10;
				//else if (x1>(value+200.0))  addf=-5;
				//else if (x1>(value+20.0)) { addf=-1; a++;
				//if (b>10) b=1; }
				////

				if ((x1 > (dblvalue + 1000.0))) {
					addf = -10;
				} else if ((x1 > (dblvalue + 200.0))) {
					addf = -5;
				} else if ((x1 > (dblvalue + 20.0))) {
					addf = -1;
					a += 1;
					if ((b > 10))
						b = 1;
				}

				//if (x1<(value-1000.0)) addf=10;
				//else if (x1<(value-200.0)) addf=5;
				//else if (x1<(value-20.0)) { addf=1; b++;}
				if ((x1 < (dblvalue - 1000.0))) {
					addf = 10;
				} else if ((x1 < (dblvalue - 200.0))) {
					addf = 5;
				} else if ((x1 < (dblvalue - 20.0))) {
					addf = 1;
					b += 1;
				}

				//d2cur+=addf;
				intD2cur += addf;
				//          if ( x1>(value+200.0) && d2cur<=MinD2Cur) {
				// if (value==3000)       Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO");
				// else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
				// pc_delay(5000);
				// flag = FALSE; d2cur=MinD2Cur; break;}
				//if ( x1<(value-200.0) && d2cur>=MaxD2Cur) {
				// if (value==3000)  Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
				// else Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
				// pc_delay(5000);
				// flag = FALSE; d2cur=MaxD2Cur;break;}
				//                              If (a > 10) Then
				//{ if (b>10)  break;
				// else a =0;
				//}

				if ((x1 > (dblvalue + 200.0) & intD2cur <= MinD2Cur)) {
					if ((dblvalue == 3000)) {
						//Gerror_message_new(" Increase HCL Current and retry ", "AABGC ZERO")
						//gobjMessageAdapter.ShowMessage(constReduceHCL)
						gobjMessageAdapter.ShowMessage(constIncreaseHCl);
					} else {
						//Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
						gobjMessageAdapter.ShowMessage(constErrorFULLSCALE);
					}

					//pc_delay(5000);
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
					//'communication delay
					intD2cur = MinD2Cur;
					Flag = false;
					break; // TODO: might not be correct. Was : Exit Do
				}
				if ((x1 < (dblvalue - 200.0) & intD2cur >= MaxD2Cur)) {
					if ((dblvalue == 3000)) {
						//Gerror_message_new(" Reduce HCL Current and retry again ", "AABGC ZERO");
						gobjMessageAdapter.ShowMessage(constReduceHCL);
					} else {
						//Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
						gobjMessageAdapter.ShowMessage(constErrorFULLSCALE);
					}
					//pc_delay(5000);
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
					intD2cur = MaxD2Cur;
					Flag = false;
					break; // TODO: might not be correct. Was : Exit Do
				}
				//;break;}

				if ((a > 10)) {
					if ((b > 10)) {
						break; // TODO: might not be correct. Was : Exit Do
					} else {
						a = 0;
					}
				}
				////-

				if (objfrmSettingPMT.mCancelProcess == true) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				objfrmSettingPMT.BringToFront();
				objfrmSettingPMT.Refresh();
				Application.DoEvents();
				//'show the PMT dialog and allow application to perfrom its panding work.
			}

			//if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//Set_D2_Cur(d2cur);
			//if(GetInstrument() == AA203 ){
			// Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			// Set_PMT(Inst->Pmtv);
			//}

			//--- Set the Min or Max D2 Current if it out of limits 
			if ((intD2cur < MinD2Cur)) {
				intD2cur = MinD2Cur;
			}

			if ((intD2cur > MaxD2Cur)) {
				intD2cur = MaxD2Cur;
			}
			gobjCommProtocol.funcSetD2Cur(intD2cur);
			//'SERIAL COMMUNICATION FOR setting given D2 current.

			//if(GetInstrument() == AA203 ){
			gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
			//'set the HCL current
			gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference);
			//'set a PMT for reference beam
			//}
			objfrmSettingPMT.Close();
			Application.DoEvents();
			//'close the form and allow application to perfrom its panding work.
			//Cal_Mode(xmode);
			gobjCommProtocol.funcCalibrationMode(intXmode);
			//'set a calibration mode
			funcBgc_Zero2_RefBeam = Flag;
		////---

		////

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
			if (!(objfrmSettingPMT == null)) {
				objfrmSettingPMT.Dispose();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private bool funcBgc_Zero3_RefBeam(bool flag1, double dblvalue)
	{
		//=====================================================================
		// Procedure Name        : funcBgc_Zero3
		// Parameters Passed     :  flag1, value
		// Returns               : True or False
		// Purpose               : To set Auto zero for BGC mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		//int 		d2cur;
		//double   x1=0;
		//int     addf=1,i;
		//char    line1[80]="";
		//BOOL	  flag=TRUE;
		//int     xmode, chnew, a=0, b=0;
		//int	gtry=0;
		//BOOL	Micro=FALSE;
		//BOOL	Gain=FALSE;
		//int MaxD2Cur=300,MinD2Cur = 100;
		////-----
		int intd2cur;
		double dblx1 = 0;
		int intaddf = 1;
		int inti;
		//char    line1[80]="";
		bool blnflag = true;
		int intxmode;
		int intchnew;
		int a = 0;
		int b = 0;
		int intgtry = 0;
		bool blnMicro = false;
		bool blnGain = false;
		int MaxD2Cur = 300;
		int MinD2Cur = 100;
		frmPMT objfrmSettingPMT = new frmPMT();
		int chIdx;
		////-----
		try {
			//if( GetSRLamp() ){
			//	MaxD2Cur = 600;
			//	MinD2Cur = 100;
			//}
			//else{
			//	MaxD2Cur = 300;
			//	MinD2Cur = 100;
			//}
			//  GainX10Off();
			//  SetMicroOff();
			//  WaitForAdc();
			//  xmode = Inst->Mode;

			//  if(GetInstrument() == AA202 ){
			//	 if( GetSRLamp()){
			//		d2cur=Inst->D2cur;
			//                        If (d2cur <= 100) Then
			//			d2cur = 101;
			//		Set_D2_Cur(d2cur);
			//	 }
			//  }
			//  if (flag1) {
			//	 Cal_Mode(AA);
			//	 Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
			//	 }
			//  hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
			//                                If (GetSRLamp()) Then
			//	  SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
			//                                Else
			//	  SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
			//  Cal_Mode(D2E);

			//  if( GetInstrument() == AA202 ){
			//                                        If (GetSRLamp()) Then
			//		d2cur = d2cur;
			//                                        Else
			//		d2cur=Inst->D2cur;
			//  }
			//  else
			//	  d2cur=Inst->D2cur;

			//  while(flag){
			//	 Set_D2_Cur(d2cur);
			//	 if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//	 }
			//	 for(i=0; i<4; i++)
			//		chnew = ReadADCFilter();
			//	 strcpy(line1,"");
			//	 x1 = (chnew-2047.0)/4096.0*10000.0;

			//                                                        If (GetSRLamp()) Then
			//		 sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
			//                                                        Else
			//		 sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

			//	 SetText(hwnd, IDC_STATUS1,line1);
			//	 if (x1<=(value+20.0) && x1>=(value-20.0)) break;
			//	 if (x1>(value+1000.0))  addf=-10;
			//	 else if (x1>(value+200.0))  addf=-5;
			//	 else if (x1>(value+20.0)) { addf=-1; a++;
			//			 if (b>10) b=1; }
			//	 if (x1<(value-1000.0)) addf=10;
			//	 else if (x1<(value-200.0)) addf=5;
			//	 else if (x1<(value-20.0)) { addf=1; b++;}
			//	 d2cur+=addf;
			//	 if (d2cur<=MinD2Cur ){
			//		d2cur=MinD2Cur;
			//		Set_D2_Cur(d2cur);

			//		if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//		}

			//	 TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
			//	  }
			//	 if ( d2cur>=MaxD2Cur ){// || (x1<(value-200.0) && d2cur>=300)) {
			////		d2cur=MinD2Cur;
			//		d2cur=101;//MaxD2Cur;
			//		Set_D2_Cur(d2cur);
			//		if(GetInstrument() == AA203 ){
			//		 Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//		 Set_PMT(Inst->Pmtv);
			//		}
			//		TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur,value);
			//		}
			//	 if (gtry==4){
			//		if (value==3000)
			//		  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
			//                                                                                                Else
			//		  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
			//		pc_delay(5000);
			//		flag = FALSE; d2cur=MinD2Cur; break;
			//	  }
			//	 if (a>10)	{
			//		 if (b>10)  break;
			//		 else a =0;
			//		}
			//	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
			//		break;
			//	}
			//  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//  if (!flag){
			//	 GainX10Off();
			//	 SetMicroOff();
			//	 Gain = FALSE;
			//	}

			//  if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//  Set_D2_Cur(d2cur);
			//  if(GetInstrument() == AA203 ){
			//	Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//	  Set_PMT(Inst->Pmtv);
			//  }
			//  DestroyWindowPeak(hwnd, hpar);
			//  Cal_Mode(xmode);
			//                                                                                                                                        If (Gain) Then
			//	 GainX10On();
			// return flag;
			//}
			//If (GetSRLamp()) Then
			//	MaxD2Cur = 600;
			//	MinD2Cur = 100;
			//}
			//else{
			//	MaxD2Cur = 300;
			//	MinD2Cur = 100;
			//}  

			//======================================

			if (gobjCommProtocol.SRLamp) {
				//'for checking SR lamp
				MaxD2Cur = 600;
				MinD2Cur = 100;
			} else {
				MaxD2Cur = 300;
				MinD2Cur = 100;
			}

			intxmode = gobjInst.Mode;
			gobjCommProtocol.funcGain10X_OFF();
			//'for gain 10 off
			gobjCommProtocol.funcSetMICRO_OFF();
			//'for micro offf
			subWaitForAdc();
			//xmode = Inst->Mode;
			intxmode = gobjInst.Mode;
			//'get a mode.

			////----- for AA202 
			//if(GetInstrument() == AA202 ){
			//if( GetSRLamp()){
			//d2cur=Inst->D2cur;
			//                  If (d2cur <= 100) Then
			//	d2cur = 101;
			//Set_D2_Cur(d2cur);
			//}
			//}
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				//If (GetSRLamp()) Then
				if (gobjCommProtocol.SRLamp == true) {
					//'for SR lamp
					//intd2cur = intd2cur
					intd2cur = gobjInst.D2Current;
					if (intd2cur <= 100) {
						intd2cur = 101;
					}
					gobjCommProtocol.funcSetD2Cur(intd2cur);
					//'for setting D2 current
					//'function for setting D2 current
				}
			}
			//if (flag1) {
			//Cal_Mode(AA);
			//Adj_PMT_forvalue(hpar, (double) 0.0 , (double)700.0);
			//}
			if ((flag1) == true) {
				//objfrmSettingPMT.Show()
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				//'check a calibration mode.
				gobjCommProtocol.funcAdj_Pmt_ForValue_Ref(0.0, 700.0, true);
				//'for adjust a PMT for given range.
				//objfrmSettingPMT.Close()
			}



			//hwnd= CreateWindowPeak(hpar, "BGC ZERO","PMTADJ", 0);
			//          If (GetSRLamp()) Then
			// SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
			//          Else
			// SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
			//Cal_Mode(D2E);

			Application.DoEvents();
			//'allow application to perfrom its panding work
			objfrmSettingPMT = new frmPMT();
			objfrmSettingPMT.Text = "BGC ZERO";
			objfrmSettingPMT.Refresh();

			if (gobjCommProtocol.SRLamp) {
				//'set for SR lamp
				//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
				//objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT :"
				objfrmSettingPMT.lblTitle.Text = "Setting SRCURRENT : ";

			} else {
				//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
				objfrmSettingPMT.lblTitle.Text = "Setting D2CURRENT : ";
			}
			objfrmSettingPMT.lblTitle.Refresh();

			objfrmSettingPMT.Show();
			Application.DoEvents();
			//'show the form and allow application to perfrom its panding work.
			gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E);
			//'set a calibration mode to D2E
			//'set a given calibration mode.

			//if( GetInstrument() == AA202 ){
			//              If (GetSRLamp()) Then
			//d2cur = d2cur;
			//              Else
			//d2cur=Inst->D2cur;
			//}
			//else
			// d2cur=Inst->D2cur;
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				//If (GetSRLamp()) Then
				if (gobjCommProtocol.SRLamp == true) {
					//intd2cur = intd2cur
					intd2cur = intd2cur;
				} else {
					intd2cur = gobjInst.D2Current;
				}
			} else {
				intd2cur = gobjInst.D2Current;
			}
			//intd2cur = gobjInst.D2Current


			while ((true)) {
				gobjCommProtocol.funcSetD2Cur(intd2cur);
				//'set a D2 curr
				//if(GetInstrument() = AA203 ) then
				gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
				//'set a HCL current at given position.
				gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference);
				//'for setting PMT of reference beam 
				//end if

				//for(i=0; i<4; i++)
				//chnew = ReadADCFilter();
				//strcpy(line1,"");

				for (chIdx = 0; chIdx <= 4; chIdx++) {
					//for(i=0; i<4; i++)
					//chnew = ReadADCFilter();
					gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, intchnew);
					//'for read a ADC filter
				}
				//x1 = (chnew-2047.0)/4096.0*10000.0;
				dblx1 = (intchnew - 2047.0) / 4096.0 * 10000.0;

				//If (GetSRLamp()) Then
				// sprintf(line1,"SRCur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);
				//              Else
				// sprintf(line1,"D2Cur.:%d mA  Energy: %4.1f   ",d2cur, (100.0/value)*x1);

				//SetText(hwnd, IDC_STATUS1,line1);

				if (gobjCommProtocol.SRLamp) {
					//'check for SR lamp.

					//SetText(hwnd, IDC_STATUS,"Setting SRCURRENT :");
					objfrmSettingPMT.lblMsg.Text = "SRCURRENT. : " + intd2cur.ToString + " mA " + "Energy. : " + (string)Format(((100.0 / dblvalue) * dblx1), "###0.00");
				//objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
				} else {
					//SetText(hwnd, IDC_STATUS,"Setting D2CURRENT :");
					objfrmSettingPMT.lblMsg.Text = "D2CURRENT : " + intd2cur.ToString + " mA " + " Energy. : " + (string)Format(((100.0 / dblvalue) * dblx1), "###0.00");
					//objfrmSettingPMT.lblMsg.Text = "Energy. : " & CStr(((100.0 / dblvalue) * dblx1))
				}

				objfrmSettingPMT.lblMsg.Refresh();
				Application.DoEvents();
				//'allow application to perfrom its panding work

				//if (x1<=(value+20.0) && x1>=(value-20.0)) break;
				if ((dblx1 <= (dblvalue + 20.0) & dblx1 >= (dblvalue - 20.0))) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				//if (x1>(value+1000.0))  addf=-10;
				//	 else if (x1>(value+200.0))  addf=-5;
				//	 else if (x1>(value+20.0)) { addf=-1; a++;
				//			 if (b>10) b=1; }

				if ((dblx1 > (dblvalue + 1000.0))) {
					intaddf = -10;
				} else if ((dblx1 > (dblvalue + 200.0))) {
					intaddf = -5;
				} else if ((dblx1 > (dblvalue + 20.0))) {
					intaddf = -1;
					a += 1;
					if ((b > 10))
						b = 1;
				}

				//	 if (x1<(value-1000.0)) addf=10;
				//	 else if (x1<(value-200.0)) addf=5;
				//	 else if (x1<(value-20.0)) { addf=1; b++;}
				if ((dblx1 < (dblvalue - 1000.0))) {
					intaddf = 10;
				} else if ((dblx1 < (dblvalue - 200.0))) {
					intaddf = 5;
				} else if ((dblx1 < (dblvalue - 20.0))) {
					intaddf = 1;
					b += 1;
				}
				//d2cur+=addf;
				intd2cur += intaddf;

				//if (d2cur<=MinD2Cur ){
				//d2cur=MinD2Cur;
				//Set_D2_Cur(d2cur);

				//if(GetInstrument() == AA203 ){
				// Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
				// Set_PMT(Inst->Pmtv);
				//}

				//TryNextMode(hwnd, &Gain, &Micro, &gtry, d2cur, value);
				// }
				if ((intd2cur <= MinD2Cur)) {
					intd2cur = MinD2Cur;
					gobjCommProtocol.funcSetD2Cur(intd2cur);
					//'for setting D2 current
					//If (GetInstrument() = AA203) Then
					gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
					//'set a HCL current at given turreart position
					gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference);
					//'for setting PMT of reference beam.
					//End If
					subTryNextMode(blnGain, blnMicro, intgtry, intd2cur, dblvalue);
				}
				//if (gtry==4){
				//if (value==3000)
				//  Gerror_message_new(" Reduce HCL Current and retry ","AABGC ZERO");
				//                  Else
				//  Gerror_message_new("Error in FULL SCALE SET", "AABGC ZERO");
				//pc_delay(5000);
				//flag = FALSE; d2cur=MinD2Cur; break;
				// }
				if ((intgtry == 4)) {
					if ((dblvalue == 3000)) {
						gobjMessageAdapter.ShowMessage(constReduceHCL);
					} else {
						gobjMessageAdapter.ShowMessage(constErrorFULLSCALE);
					}
					//pc_delay(5000)
					gobjCommProtocol.mobjCommdll.subTime_Delay(50);
					//'for delay
					blnflag = false;
					intd2cur = MinD2Cur;
					//break()
					break; // TODO: might not be correct. Was : Exit Do
				}
				//              if (a>10)	{
				// if (b>10)  break;
				// else a =0;
				//}
				if ((a > 10)) {
					if ((b > 10)) {
						break; // TODO: might not be correct. Was : Exit Do
					} else {
						a = 0;
					}
				}
				////=-=---- Define by Sachin Dokhale
				////----- Set the interupt for exit 
				//if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
				//break;
				if (objfrmSettingPMT.mCancelProcess == true) {
					//'exit if true.
					break; // TODO: might not be correct. Was : Exit Do
				}
				////-----
				objfrmSettingPMT.BringToFront();
				objfrmSettingPMT.Refresh();
				Application.DoEvents();
				//'allow application to perfrom its panding work bet loop
			}
			//if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			//  if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			//  if (!flag){
			//	 GainX10Off();
			//	 SetMicroOff();
			//	 Gain = FALSE;
			//	}

			//--- Set the Min or Max D2 Current if it out of limits 
			if ((intd2cur < MinD2Cur))
				intd2cur = MinD2Cur;
			if ((intd2cur > MaxD2Cur))
				intd2cur = MaxD2Cur;

			if (!(blnflag == true)) {
				gobjCommProtocol.funcGain10X_OFF();
				//'put Gain10 off
				gobjCommProtocol.funcSetMICRO_OFF();
				//'put MICRO off
				blnGain = false;
			}
			//if ( d2cur<MinD2Cur) d2cur = MinD2Cur;
			// if ( d2cur>MaxD2Cur) d2cur = MaxD2Cur;
			// Set_D2_Cur(d2cur);
			// if(GetInstrument() == AA203 ){
			//Set_HCL_Cur(Inst->Cur,Inst->Lamp_pos);
			//  Set_PMT(Inst->Pmtv);
			// }

			//--- Set the Min or Max D2 Current if it out of limits 
			if ((intd2cur < MinD2Cur))
				intd2cur = MinD2Cur;
			if ((intd2cur > MaxD2Cur))
				intd2cur = MaxD2Cur;
			gobjCommProtocol.funcSetD2Cur(intd2cur);
			//'for setting D2 Curr

			//if(GetInstrument() = AA203 ) then
			gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position);
			//'for setting HCL current at given position 
			gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltageReference);
			//'for setting PMT of reference beam
			//end if
			//DestroyWindowPeak(hwnd, hpar);
			//Cal_Mode(xmode);

			objfrmSettingPMT.Close();
			Application.DoEvents();
			//'close the from and allow application to perfrom its panding work
			gobjCommProtocol.funcCalibrationMode(intxmode);
			//'for setting calibration mode.
			//If (Gain) Then
			//GainX10On();
			//return flag;
			if ((blnGain == true)) {
				gobjCommProtocol.funcGain10X_ON();
				//'put on the Gain10x on.
			}
			return blnflag;
		//Return gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 600, True)

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
			if (!(objfrmSettingPMT) == null) {
				objfrmSettingPMT.Dispose();
			}
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	private void subTryNextMode(ref bool Gain, ref bool Micro, ref int gtry, int intd2cur, double dblvalue)
	{
		//=====================================================================
		// Procedure Name        : subTryNextMode
		// Parameters Passed     :  Gain,Micro,gtry,intd2cur,dblvalue
		// Returns               :  None
		// Purpose               : 
		// Description           : Try Next Mode
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 03.01.07
		// Revisions             : praveen
		//=====================================================================
		int intchnew;
		int inti;
		int dblx1 = 0;
		try {
			//if (ReadIniForD2Gain() && Re0adIniForMesh()){
			// if (*gtry==0){
			// if (*Gain || *Micro){
			//	if (*Gain){
			//	  *Gain=FALSE;
			//	  GainX10Off();
			//	  WaitForAdc();
			//	 }
			//	if (*Micro){
			//	  SetMicroOff();
			//	  *Micro=FALSE;
			//	  WaitForAdc();
			//	 }
			//	}
			// else{
			//	*gtry=1;
			//	SetMicroOn();
			//	*Micro=TRUE;
			//	WaitForAdc();
			//  }
			//}
			// else if (*gtry==1){
			// SetMicroOff();
			// *Micro=FALSE;
			// GainX10On();
			// *Gain=TRUE;
			// WaitForAdc();
			// *gtry=2;
			//}
			// else if (*gtry==2){
			// GainX10On(); *Gain=TRUE;
			// SetMicroOn();*Micro=TRUE;
			// WaitForAdc();
			// *gtry=3;
			//}
			// else if (*gtry==3){
			// *gtry=4;
			//}
			// }
			//else  if (ReadIniForD2Gain()){
			//if (*gtry==0){
			//	*gtry=1;
			//	GainX10On();
			//	*Gain=TRUE;
			//	WaitForAdc();
			// }
			//else if (*gtry==1)
			// *gtry=4;
			// }
			//else if  (ReadIniForMesh()){
			// if (*gtry==0){
			//	*gtry=1;
			//	SetMicroOn();
			//	*Micro=TRUE;
			//	WaitForAdc();
			//  }
			// else if (*gtry==1)
			//	*gtry=4;
			//}

			//If (ReadIniForD2Gain() And ReadIniForMesh()) Then
			if ((gstructSettings.D2Gain & gstructSettings.Mesh)) {
				//'check for D2 gain and MESH
				if ((gtry == 0)) {
					if ((Gain | Micro)) {
						if ((Gain == true)) {
							Gain = false;
							gobjCommProtocol.funcGain10X_OFF();
							//'for putting Gain10X off 
							subWaitForAdc();
							//'set wait for ADC filter
						}
						if ((Micro)) {
							gobjCommProtocol.funcSetMICRO_OFF();
							//'for putting micro off 
							Micro = false;
							subWaitForAdc();
							//'wait for ADC
						}
					} else {
						gtry = 1;
						gobjCommProtocol.funcSetMICRO_ON();
						//'set ON micro
						Micro = true;
						//'make true the micro flag 
						subWaitForAdc();
						//'wait for ADC
					}

				} else if ((gtry == 1)) {
					gobjCommProtocol.funcSetMICRO_OFF();
					//'set micro OFF
					Micro = false;
					//'set flag false
					gobjCommProtocol.funcGain10X_ON();
					//'on the gain
					Gain = true;
					subWaitForAdc();
					//'wait for ADC
					gtry = 2;

				} else if ((gtry == 2)) {
					gobjCommProtocol.funcGain10X_ON();
					//'on the gain
					Gain = true;
					//SetMicroOn()
					gobjCommProtocol.funcSetMICRO_ON();
					//'set micro on
					Micro = true;
					subWaitForAdc();
					//'wait for ADC
					gtry = 3;

				} else if ((gtry == 3)) {
					gtry = 4;
				}

			} else if ((gstructSettings.D2Gain == true)) {
				if ((gtry == 0)) {
					gtry = 1;
					gobjCommProtocol.funcGain10X_ON();
					//'put on gain
					Gain = true;
					subWaitForAdc();
				//'wait for ADC
				} else {
					if ((gtry == 1)) {
						gtry = 4;
					}
				}
			} else if ((gstructSettings.Mesh)) {
				if ((gtry == 0)) {
					gtry = 1;
					gobjCommProtocol.funcSetMICRO_ON();
					//'set on micro
					Micro = true;
					subWaitForAdc();
				//'wait for ADC reading
				//' To set some wait time in ADC reading.
				} else if ((gtry == 1)) {
					gtry = 4;
				}
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

	public bool funcReadFilterSetting()
	{
		//=====================================================================
		// Procedure Name        : funcReadFilterSetting
		// Parameters Passed     :  none
		// Returns               : True if success
		// Purpose               : Read Filter Setting
		// Description           : 
		// Assumptions           : gstructSettings is initiated
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is used for reading a filter setting.
		//'set gintTimeConstant here.
		try {
			switch (gstructSettings.TimeConstant) {
				//'set a gintTimeConstant  as par case for the fliter setting 
				case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual
10:
					gintTimeConstant = 0;
				case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual
5.0:
					gintTimeConstant = 1;
				case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual
2.0:
					gintTimeConstant = 2;
				case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual
1.0:
					gintTimeConstant = 3;
				case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual
0.2:
					gintTimeConstant = 4;
				case  // ERROR: Case labels with binary operators are unsupported : GreaterThanOrEqual
0.1:
					gintTimeConstant = 5;
				default:
					gintTimeConstant = 2;
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

	public double funcGetAbsScanX()
	{
		//=====================================================================
		// Procedure Name        : funcGetAbsScanX
		// Parameters Passed     :  None
		// Returns               : double
		// Purpose               : To Get Abs value from ADC
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		double dblAbsdata;
		int intadval;
		try {
			//Application.DoEvents()
			gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval);
			//'get a current ADC value in to intadval

			dblAbsdata = gFuncGetADConvertedToCurMode(intadval);
			if ((gobjInst.Mode == EnumCalibrationMode.EMISSION)) {
				dblAbsdata -= funcGet_Emission_Zero();
			}
			return dblAbsdata;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	public double funcGetAbsScanX_RefBeam()
	{
		//=====================================================================
		// Procedure Name        : funcGetAbsScanX
		// Parameters Passed     : none 
		// Returns               : double
		// Purpose               : To Get Abs value from ADC for Ref. Beam
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.04.07
		// Revisions             : praveen
		//=====================================================================

		try {
			//double	GetAbsScanX(void)
			//{
			double dblAbsdata;
			int intadval;
			//Application.DoEvents()
			gobjCommProtocol.funcReadADCFilter_ReferenceBeam(gobjInst.Average, intadval);
			//'function for reading ADC filter reading for reference beam
			//data = (double) GetADConvertedToCurMode(adval);
			dblAbsdata = gFuncGetADConvertedToCurMode(intadval);
			//'get ADC converted in to mode.
			if ((gobjInst.Mode == EnumCalibrationMode.EMISSION)) {
				//'for emission mode
				//--- Set Abs value for Emission mode
				dblAbsdata -= funcGet_Emission_Zero();
			}
			//Application.DoEvents()
			return dblAbsdata;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	public double funcGetAbsScanX_DoubleBeam()
	{
		//=====================================================================
		// Procedure Name        : funcGetAbsScanX_DoubleBeam
		// Parameters Passed     :  None
		// Returns               : double,Abs value
		// Purpose               : To Get Abs value from ADC for Duoble Beam
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 07.04.07
		// Revisions             : praveen
		//=====================================================================

		try {
			//double	GetAbsScanX(void)
			//{
			double dblAbsdata;
			int intadval;
			//Application.DoEvents()
			gobjCommProtocol.funcReadADCFilter_DoubleBeam(gobjInst.Average, intadval);
			//'for reading a ADC filter
			//data = (double) GetADConvertedToCurMode(adval);
			dblAbsdata = gFuncGetADConvertedToCurMode(intadval);
			//'convert ADC to mode
			//dblAbsdata = intadval
			if ((gobjInst.Mode == EnumCalibrationMode.EMISSION)) {
				//'for emission
				//--- Set Abs value for Emission mode
				dblAbsdata -= funcGet_Emission_Zero();
			}
			//Application.DoEvents()
			return dblAbsdata;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	public double funcGet_Emission_Zero()
	{
		//=====================================================================
		// Procedure Name        : funcGet_Emission_Zero
		// Parameters Passed     :  None
		// Returns               : double
		// Purpose               : To Get Autozero for Emission
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		try {
			return mEmsZero;
		//'it will return a emission zero value.

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	public bool Auto_blank_Emission(bool blnFlag)
	{
		//=====================================================================
		// Procedure Name        : Auto_blank_Emission
		// Parameters Passed     : blnFlag   
		// Returns               : True or false
		// Purpose               : To Get Auto Blank to Emission
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================

		try {
			Auto_blank_Emission = false;
			//    BOOL 	S4FUNC 	Auto_blank_Emission(HWND hwnd, BOOL flag)
			//{
			//char  line1[80]="";
			int intadval;
			bool blnflag1 = false;
			if (!(gobjInst.Mode == EnumCalibrationMode.EMISSION)) {
				return false;
			}
			if ((blnFlag == true)) {
				//if(GetInstrument() == AA202 )
				//Check_Ignite_AA202(hwnd);
				//Else

				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					//'check for 201
					blnflag1 = funcCheck_Ignite_AA201();
				} else {
					//'for other instrument
					blnflag1 = funcCheck_Ignite();
				}

				if (blnflag1 == true) {
					//funcCheck_Ignite_AA202()
					//sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
					//	  SetText(hwnd, IDC_STATUS1,line1);
					//	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
					////	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
					//	  pc_delay(1000);
					//	  adval = ReadADCFilter();
					//	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
					//MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);

					//Call gobjMessageAdapter.ShowMessage(constAspirate_Blank) 'commented by pankaj on 1 Dec 07 for unnecessary showing message box on analysis
					//'show the Aspirate blank message
					gobjCommProtocol.mobjCommdll.subTime_Delay(10);
					//'dely of 10
					gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval);
					//'for reading a ADC filter
					//mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
					mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION);
				//'convert ADC in to mode.
				} else {
					return false;
				}
			} else {
				gobjCommProtocol.mobjCommdll.subTime_Delay(10);
				//'for delay
				gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval);
				//'for reading a ADC filter
				//mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
				mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION);
				//'convert ADC into mode.
			}

			return true;


		// if (flag){
		//	if(GetInstrument() == AA202 )
		//		Check_Ignite_AA202(hwnd);
		//                    Else
		//		Check_Ignite();
		//	if (flag1)   {
		//	  sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
		//	  SetText(hwnd, IDC_STATUS1,line1);
		//	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
		////	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
		//	  pc_delay(1000);
		//	  adval = ReadADCFilter();
		//	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
		//	}
		//                        Else
		//		return FALSE;
		//  }
		// else{
		//	 pc_delay(1000);
		//	 adval = ReadADCFilter();
		//	 EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
		//	}
		//return TRUE;
		//}
		//{


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

	public bool Auto_blank_Emission_DoubleBeam(bool blnFlag)
	{
		//=====================================================================
		// Procedure Name        : Auto_blank_Emission
		// Parameters Passed     : blnFlag 
		// Returns               : True / False
		// Purpose               : To Get Auto Blank to Emission
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 19.12.06
		// Revisions             : praveen
		//=====================================================================
		int intadval;
		bool blnflag1 = false;
		try {
			Auto_blank_Emission_DoubleBeam = false;
			//    BOOL 	S4FUNC 	Auto_blank_Emission(HWND hwnd, BOOL flag)
			//{
			//char  line1[80]="";
			if (!(gobjInst.Mode == EnumCalibrationMode.EMISSION)) {
				return false;
			}
			//--- Check tha flag for Ignite condition
			if ((blnFlag == true)) {
				//if(GetInstrument() == AA202 )
				//Check_Ignite_AA202(hwnd);
				//Else

				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					//'check for 201
					blnflag1 = funcCheck_Ignite_AA201();
				} else {
					blnflag1 = funcCheck_Ignite();
				}

				if (blnflag1 == true) {
					//funcCheck_Ignite_AA202()
					//sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
					//	  SetText(hwnd, IDC_STATUS1,line1);
					//	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
					////	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
					//	  pc_delay(1000);
					//	  adval = ReadADCFilter();
					//	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
					//MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);

					gobjMessageAdapter.ShowMessage(constAspirate_Blank);
					//'set a aspirate blank mess
					gobjCommProtocol.mobjCommdll.subTime_Delay(10);
					//'delay
					gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval);
					//'read ADC filter
					//mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
					mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION);
				//'convert ADC in to mode.
				} else {
					return false;
				}
			} else {
				gobjCommProtocol.mobjCommdll.subTime_Delay(10);
				//'delay
				gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intadval);
				//'read ADC filter
				//mEmsZero =  gobjCommProtocol. funcGetADConvertedTo(adval, MODE_EMISSION);
				mEmsZero = gfuncGetADConvertedIntoMode(intadval, modGlobalConstants.EnumCalibrationMode.EMISSION);
				//'convert ADC in to mode
			}

			return true;


		// if (flag){
		//	if(GetInstrument() == AA202 )
		//		Check_Ignite_AA202(hwnd);
		//                    Else
		//		Check_Ignite();
		//	if (flag1)   {
		//	  sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
		//	  SetText(hwnd, IDC_STATUS1,line1);
		//	  Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0);
		////	  MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", MB_OK);
		//	  pc_delay(1000);
		//	  adval = ReadADCFilter();
		//	  EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
		//	}
		//                        Else
		//		return FALSE;
		//  }
		// else{
		//	 pc_delay(1000);
		//	 adval = ReadADCFilter();
		//	 EmsZero= (double) GetADConvertedTo(adval, MODE_EMISSION);
		//	}
		//return TRUE;
		//}
		//{


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

	//Public Function funcCheck_Ignite_sachin() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcCheck_Ignite
	//    ' Parameters Passed     : None
	//    ' Returns               : 
	//    ' Purpose               : 
	//    ' Description           : not in used
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.12.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim str As String
	//    'char 		str[80]="";
	//    Dim aa, ps1, ps2, ps3 As Integer
	//    Dim flag As Boolean = True
	//    'int   	aa, ps1, ps2, ps3, flag = TRUE;
	//    Dim data As Byte
	//    'BYTE  	data;
	//    Dim count As Integer = 1
	//    'int   	count=1;
	//    Dim bData As Byte
	//    Dim blnFlame_Present As Boolean = False

	//    '        BOOL 		S4FUNC Check_Ignite()
	//    '{
	//    '#If DEMO Then
	//    ' return TRUE;
	//    '#Else
	//    'char 		str[80]="";
	//    'int   	aa, ps1, ps2, ps3, flag = TRUE;
	//    'BYTE  	data;
	//    'int   	count=1;
	//    'HWND hpar=NULL;
	//    '	hpar = GetTopWindow(NULL);
	//    ' if(!Flame_Present(FALSE))  {
	//    '	ps1 = ps2 = ps3 = ON;
	//    '	data = CHECK_BUR_PAR();
	//    '	if (data & AA_CONNECTED) aa = ON;
	//    '	else aa = OFF;
	//    '	data  = CHECK_PS();
	//    '	if (data & AIR_NOK)  ps1 = OFF;
	//    '	if (data & N2O_NOK)  ps2 = OFF;
	//    '	if (data & FUEL_NOK) ps3 = OFF;
	//    '	if (ps1==OFF) {
	//    '	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//    '	  flag=FALSE;
	//    '	 }
	//    '	if (aa!=ON && ps2==OFF) {
	//    '		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//    '		flag = FALSE;
	//    '	  }
	//    '	if (ps3==OFF) {
	//    '	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//    '	  flag = FALSE;
	//    '	 }
	//    '	strcpy (str,"");
	//    '	if (Ignite_Test()!=GREEN)
	//    '	 flag=FALSE;
	//    '	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
	//    '	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
	//    '	if (flag){
	//    '		  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '		 Ignite(TRUE);
	//    '	}
	//    '	while(!Flame_Present(FALSE)&&count<3)	{
	//    '	  count++;
	//    '                                                            If (flag) Then
	//    '//		  if (MessageBox(NULL, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '		  if (MessageBox(hpar, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '			 Ignite(TRUE);
	//    '	  }
	//    '  }
	//    '                                                                    If (Flame_Present(False)) Then
	//    '	return TRUE;
	//    '                                                                    Else
	//    '	return FALSE;
	//    '#End If
	//    '}
	//    Try
	//        ' if(!Flame_Present(FALSE))  {
	//        '	ps1 = ps2 = ps3 = ON;
	//        '	data = CHECK_BUR_PAR();
	//        '	if (data & AA_CONNECTED) aa = ON;
	//        '	else aa = OFF;
	//        '	data  = CHECK_PS();
	//        '	if (data & AIR_NOK)  ps1 = OFF;
	//        '	if (data & N2O_NOK)  ps2 = OFF;
	//        '	if (data & FUEL_NOK) ps3 = OFF;
	//        If Not funcFlame_Present(False) Then
	//            '  ps1 = ps2 = ps3 = ON
	//            'ps1 = True
	//            'ps2 = True
	//            'ps3 = True

	//            If gobjCommProtocol.gFuncPneumatics() Then
	//            End If

	//            gobjCommProtocol.funcCheckBurnerParameters(bData)
	//            ''for checking a burner parameter.

	//            If (bData And EnumErrorStatus.AA_CONNECTED) Then
	//                aa = True
	//            Else
	//                aa = False
	//            End If

	//            If Not funcIgnite_Test() = enumIgniteType.Green Then
	//                flag = False
	//            End If

	//            If aa Then
	//                str = "Ready for Air-Acetelyne Flame ..  IGNITE ?"
	//            Else
	//                str = "Ready for N2O-Acetelyne Flame ..  IGNITE ?"
	//            End If

	//            If flag Then
	//                'If MessageBox.Show(str, "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
	//                '    Ignite(True)
	//                'End If
	//                gobjMessageAdapter.ShowMessage(str, "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
	//                funcIgnite(True)
	//            End If

	//            'if (flag){
	//            '	  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//            '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//            '		 Ignite(TRUE);
	//            '	}
	//            blnFlame_Present = funcFlame_Present(False)

	//            While (Not blnFlame_Present) And count < 3
	//                count += 1
	//                If flag Then
	//                    'If MessageBox.Show("Flame not Ignited. Retry?", "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
	//                    If gobjMessageAdapter.ShowMessage(constFlameRetry) = True Then
	//                        Application.DoEvents()
	//                        funcIgnite(True)
	//                    End If
	//                End If
	//            End While
	//        End If

	//        If funcFlame_Present(False) Then
	//            Return True
	//        Else
	//            Return False
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//        Return False
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	public bool funcCheck_Ignite()
	{
		//=====================================================================
		// Procedure Name        : funcCheck_Ignite
		// Parameters Passed     : None
		// Returns               : boolean
		// Purpose               : for checking a ignition setting.like air , fuel , N2o etc.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin 
		// Created               : 09.03.07
		// Revisions             : modified by deepak on 09.03.07
		//=====================================================================
		//BOOL 		S4FUNC Check_Ignite()
		//{
		//#If DEMO Then
		// return TRUE;
		//#Else
		//char 		str[80]="";
		//int   	aa, ps1, ps2, ps3, flag = TRUE;
		//BYTE  	data;
		//int   	count=1;
		//HWND hpar=NULL;

		//	hpar = GetTopWindow(NULL);
		// if(!Flame_Present(FALSE))  { //0
		//	ps1 = ps2 = ps3 = ON;
		//	data = CHECK_BUR_PAR();
		//	if (data & AA_CONNECTED) aa = ON;
		//	else aa = OFF;
		//	data  = CHECK_PS();
		//	if (data & AIR_NOK)  ps1 = OFF;
		//	if (data & N2O_NOK)  ps2 = OFF;
		//	if (data & FUEL_NOK) ps3 = OFF;
		//	if (ps1==OFF) { //1
		//	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
		//	  flag=FALSE;
		//	 } //1
		//	if (aa!=ON && ps2==OFF) {//2
		//		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
		//		flag = FALSE;
		//	  }//2
		//	if (ps3==OFF) {//3
		//	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
		//	  flag = FALSE;
		//	 }//3
		//	strcpy (str,"");
		//	if (Ignite_Test()!=GREEN)
		//	 flag=FALSE;
		//	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
		//	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
		//	if (flag){//4
		//		  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
		//		 Ignite(TRUE);
		//	}//4
		//	while(!Flame_Present(FALSE)&&count<3)	{//5
		//	  count++;
		//   If (flag) Then
		//		  if (MessageBox(hpar, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
		//			 Ignite(TRUE);
		//	  }//5
		//  }//0
		//If (Flame_Present(False)) Then
		//	return TRUE;
		//Else
		//	return FALSE;
		//#End If
		//}

		string str;
		bool aa;
		bool ps1;
		bool ps2;
		bool ps3;
		bool flag = true;
		//Dim data As Byte
		int count = 1;
		byte bData;
		bool blnFlame_Present = false;

		try {
			//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				//'always return true for demo mode
				return true;
			}

			if (!funcFlame_Present(false)) {
				//'check for a flame present
				ps1 = true;
				// To check for Air pressure 
				ps2 = true;
				// To check for N2O pressure 
				ps3 = true;
				// To check for Fuel pressure 

				gobjCommProtocol.funcCheckBurnerParameters(bData);
				//'check a burner parameter
				if ((bData & EnumErrorStatus.AA_CONNECTED)) {
					//'check a cond
					aa = true;
				} else {
					aa = false;
				}

				gobjCommProtocol.funcPressSensorStatus(bData);
				//'get a pressSensor status
				if ((bData & EnumErrorStatus.AIR_NOK)) {
					//'check Air nok flag.
					ps1 = false;
				}
				if ((bData & EnumErrorStatus.N2O_NOK)) {
					//'check N2O nok flag.
					ps2 = false;
				}
				if ((bData & EnumErrorStatus.FUEL_NOK)) {
					//'ckeck FUEL nok
					ps3 = false;
				}

				if (ps1 == false) {
					//MessageBox.Show("Low Air Pressure Switch on Tank and RETRY", "PNEUMATICS ERROR")
					gobjMessageAdapter.ShowMessage(constLowAirPressureRetry);
					flag = false;
				}

				if ((aa != true & ps2 == false)) {
					gobjMessageAdapter.ShowMessage(constLowNitrousPressureRetry);
					flag = false;
				}

				if (ps3 == false) {
					gobjMessageAdapter.ShowMessage(constLowFuelPressureRetry);
					flag = false;
				}

				str = "";
				//--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
				//If Not funcIgnite_Test() = enumIgniteType.Green Then
				//    ''test the ignition by color
				//    flag = False
				//End If
				enumIgniteType intIgnite_Test;
				if (!funcIgnite_Test(intIgnite_Test)) {
					if (intIgnite_Test == enumIgniteType.Green) {
						flag = false;
					}
				}
				//---

				if (aa == true) {
					//'prompt a mess as per cond
					str = "Ready for Air-Acetelyne Flame ..  IGNITE ?";
				} else {
					str = "Ready for N2O-Acetelyne Flame ..  IGNITE ?";
				}

				if (flag) {
					if (gobjMessageAdapter.ShowMessage(str, "AUTO IGNITION", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == true) {
						Application.DoEvents();
						//'allow application to perfrom its panding work
						funcIgnite(true);
						//'ignite the flame
					}
				}
				Application.DoEvents();
				//'allow application to perfrom its panding work.
				while ((!funcFlame_Present(false) & count < 3)) {
					//'start loop
					count += 1;
					if (flag) {
						if (gobjMessageAdapter.ShowMessage(constFlameRetry) == true) {
							Application.DoEvents();
							//'allow application to perfrom its panding work 
							//'and ignite a flame.
							funcIgnite(true);
						}
					}
					Application.DoEvents();
					//'allow application to perfrom its panding work.

				}
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work.
			if (funcFlame_Present(false)) {
				//'if flame is not present
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

	public bool funcCheck_Ignite_AA201()
	{
		//=====================================================================
		// Procedure Name        : funcCheck_Ignite_AA201
		// Parameters Passed     : bool
		// Returns               : 
		// Purpose               : for checking ignition setting for 201
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.12.06
		// Revisions             : praveen
		//=====================================================================
		string str;
		//char 		str[80]="";
		int aa;
		int ps1;
		int ps2;
		int ps3;
		bool flag = true;
		//int   	aa, ps1, ps2, ps3, flag = TRUE;
		byte data;
		//BYTE  	data;
		int count = 1;
		//int   	count=1;
		byte bData;
		bool blnFlame_Present = false;
		bool blnFlagCheckIgnite = false;
		//Saurabh----22.06.2007

		try {
			////-----()
			//BOOL 		S4FUNC Check_Ignite_AA202(HWND hwnd)
			//{
			//#If DEMO Then
			// return TRUE;
			//#Else
			//char 		str[80]="";
			//int   	aa, ps1, ps2, ps3, flag = TRUE;
			//BYTE  	data;
			//int   	count=1;

			// if(!Flame_Present(FALSE))  {
			//	ps1 = ps2 = ps3 = ON;
			//	data = CHECK_BUR_PAR();
			//	if (data & AA_CONNECTED) aa = ON;
			//	else aa = OFF;
			//	data  = CHECK_PS();
			//	if (data & AIR_NOK)  ps1 = OFF;
			//	if (data & N2O_NOK)  ps2 = OFF;
			//	if (data & FUEL_NOK) ps3 = OFF;
			//	if (ps1==OFF) {
			//	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
			//	  flag=FALSE;
			//	 }
			//	if (aa!=ON && ps2==OFF) {
			//		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
			//		flag = FALSE;
			//	  }
			//	if (ps3==OFF) {
			//	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
			//	  flag = FALSE;
			//	 }
			//	strcpy (str,"");
			//	if (Ignite_Test()!=GREEN)
			//	 flag=FALSE;
			//	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
			//	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
			//	if (flag){
			////	  if (MessageBox(NULL, str , " MANUAL IGNITION ", MB_YESNO)==IDYES)
			//	  if (MessageBox(hwnd, str , " MANUAL IGNITION ", MB_YESNO)==IDYES)
			//			Manual_Init(hwnd);
			//	}
			//	while(!Flame_Present(FALSE)&&count<3)	{
			//	  count++;
			//                                                                If (flag) Then
			////		  if (MessageBox(NULL, " Flame not Ignited . Retry ? ", " MANUAL IGNITION ", MB_YESNO)==IDYES)
			//		  if (MessageBox(hwnd, " Flame not Ignited . Retry ? ", " MANUAL IGNITION ", MB_YESNO)==IDYES)
			//			 Manual_Init(hwnd);
			//	  }
			//  }
			//                                                                        If (Flame_Present(False)) Then
			//	return TRUE;
			//                                                                        Else
			//	return FALSE;
			//#End If
			//}

			////-----

			//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				//always return true for demo mode.
				return true;
			}

			if (!funcFlame_Present(false)) {
				//check for flame present
				//  ps1 = ps2 = ps3 = ON

				if (gobjCommProtocol.gFuncPneumatics()) {
					//check for pneumatics setting

				}

				gobjCommProtocol.funcCheckBurnerParameters(bData);
				//check burner parameter
				//--- Assign flag of AA burner connection
				if ((bData & EnumErrorStatus.AA_CONNECTED)) {
					aa = true;
				} else {
					aa = false;
				}

				//--- Check the Ignite test for green color type for analysis
				//--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
				//If Not funcIgnite_Test() = enumIgniteType.Green Then
				//    'check a ignite with respect to color
				//    flag = False
				//End If
				enumIgniteType intIgnite_Test;
				if (!funcIgnite_Test(intIgnite_Test)) {
					if (intIgnite_Test == enumIgniteType.Green) {
						flag = false;
					}
				}
				//---

				if (aa) {
					str = "Ready for Air-Acetelyne Flame ..  IGNITE ?";
				} else {
					str = "Ready for N2O-Acetelyne Flame ..  IGNITE ?";
				}

				//****************Commented by Saurabh--22.06.07
				//If flag Then
				//    'If MessageBox.Show(str, "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
				//    '    Ignite(True)
				//    'End If
				//    gobjMessageAdapter.ShowMessage(str, "MANUAL IGNITION", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
				//    '//----- To be required change for manual Ignition of AA201
				//    'funcIgnite(True)

				//End If

				//'if (flag){
				//'	  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
				//'//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
				//'		 Ignite(TRUE);
				//'	}
				//blnFlame_Present = funcFlame_Present(False)

				//While (Not blnFlame_Present) And count < 3
				//    count += 1
				//    If flag Then
				//        If gobjMessageAdapter.ShowMessage(constFlameRetry) = True Then
				//            '    funcIgnite(True)

				//        End If
				//    End If
				//End While
				//****************Commented by Saurabh--22.06.07

				//Saurabh----22.06.07
				if (flag) {
					if (gobjMessageAdapter.ShowMessage(str, "MANUAL IGNITION", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == true) {
						frmManualIgnition objfrmManualIgnition = new frmManualIgnition();

						// code added by : dinesh wagh on 22.3.2009
						// code start
						if (gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
							objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175;
							objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen;
						}
						//........code ends.

						objfrmManualIgnition.ShowDialog();
					//'if flag is true then show manualignition dialog
					} else {
						if (gobjMessageAdapter.ShowMessage(constFlameRetry) == true) {
							frmManualIgnition objfrmManualIgnition = new frmManualIgnition();
							// code added by : dinesh wagh on 22.3.2009
							// code start
							if (gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175;
								objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen;
							}
							//........code ends.

							objfrmManualIgnition.ShowDialog();
							//show the manualIgnition dialog.
							//Else

						}
					}
				}
				blnFlame_Present = funcFlame_Present(false);
				//'set a value for blnFlame_Present  flag.

				while ((!blnFlame_Present) & count < 2) {
					count += 1;
					if (flag) {
						if (gobjMessageAdapter.ShowMessage(constFlameRetry) == true) {
							frmManualIgnition objfrmManualIgnition = new frmManualIgnition();
							// code added by : dinesh wagh on 22.3.2009
							// code start
							if (gstructSettings.AppMode == EnumAppMode.DemoMode_201 | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								objfrmManualIgnition.Width = objfrmManualIgnition.Width - 175;
								objfrmManualIgnition.StartPosition = FormStartPosition.CenterScreen;
							}
							//........code ends.

							objfrmManualIgnition.ShowDialog();
							//show the manualIgnition dialog.
						}
					}
				}
				//Saurabh----22.06.07

			}
			//--- Check the flame for it's presenty and it is the return true
			if (funcFlame_Present(false)) {
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

	public enumIgniteType funcIgnite_Test()
	{
		//=====================================================================
		// Procedure Name        : Check_Ignite
		// Parameters Passed     : None
		// Returns               : enumIgniteType
		// Purpose               : for ignite status display
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.12.06
		// Revisions             : praveen
		//=====================================================================
		//#define    ON  1
		//#define    OFF 0

		//int S4FUNC Ignite_Test()
		//{
		//   BYTE st, st1;
		//   BOOL  ps1, ps2, ps3,aa,tr, dr;
		//   int	 flag = 0;

		//   if (!Inst.Aaf && !Inst.N2of) 
		//   {
		//       ps1 = ps2 = ps3 = ON;
		//	    st  = CHECK_PS();
		//	    if (st & AIR_NOK) ps1 = OFF;
		//	    if (st & N2O_NOK) ps2 = OFF;
		//	    if (st & FUEL_NOK) ps3 = OFF;
		//	    st1 = CHECK_BUR_PAR();
		//	    if (st1 & AA_CONNECTED) aa=ON;	// N2O/AA
		//	        else aa=OFF;
		//	    if (st1 & TRAP_NOK) tr=OFF;
		//	        else tr=ON;
		//	    if (st1 &DOOR_NOK) dr=OFF;
		//	        else dr=ON;
		//	    if (!ps3) flag=2;
		//	    if (!ps1) flag = 3;
		//	    if (!aa) if (!ps2) flag = 4;
		//	    if (!dr) flag=5;
		//	    if (!tr) flag=6;
		//   }
		//   else 
		//   {
		//       Check_Flame();
		//	    st = CHECK_PS();
		//	    if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
		//	    else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
		//	    else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
		//   }
		//   #If DEMO Then
		//       flag = random(8)-2;
		//   #End If

		//   if (flag==-1)
		//	    return BLUE;
		//   if (flag==-2)
		//       return YELLOW;

		//   If (flag) Then
		//       return RED;
		//   Else
		//	    return GREEN;
		//}

		byte st;
		byte st1;
		bool ps1;
		bool ps2;
		bool ps3;
		bool aa;
		bool tr;
		bool dr;
		int flag = 0;

		const object const_ON = 1;
		const object const_OFF = 0;


		try {
			//----------------------------------------
			//If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
			//    Application.DoEvents()
			//    Call funcCheck_Flame()
			//    If gobjCommProtocol.funcPressSensorStatus(st, False) Then
			//        ''check a presssensor status
			//        If ((st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK) Then
			//            flag = -2
			//            gobjInst.Aaf = True
			//        ElseIf ((st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK) Then
			//            flag = -1
			//            gobjInst.Aaf = True
			//        ElseIf ((st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
			//            flag = -1
			//            gobjInst.Aaf = True
			//        Else
			//            gobjInst.Aaf = False
			//        End If
			//    End If
			//End If
			//----------------------------------------

			Application.DoEvents();
			//'allow application to perfrom its panding work
			if ((!(gobjInst.Aaf == true)) & (!(gobjInst.N2of == true))) {
				//ps1 = ps2 = ps3 = ON;
				ps1 = true;
				// To check for Air pressure 
				ps2 = true;
				// To check for N2O pressure 
				ps3 = true;
				// To check for Fuel pressure 

				if (gobjCommProtocol.funcPressSensorStatus(st, false)) {
					//'check a presssensor status
					if ((st & EnumErrorStatus.AIR_NOK)) {
						ps1 = false;
					}
					if ((st & EnumErrorStatus.N2O_NOK)) {
						ps2 = false;
					}
					if ((st & EnumErrorStatus.FUEL_NOK)) {
						ps3 = false;
					}
				}

				if (gobjCommProtocol.funcCheckBurnerParameters(st1, false)) {
					//'check for burner parameter

					//if (st1 and  EnumErrorStatus.AA_CONNECTED) aa=ON;	// N2O/AA
					//else aa=OFF;
					if ((st1 & EnumErrorStatus.AA_CONNECTED)) {
						aa = true;
					} else {
						aa = false;
					}
					//if (st1 & TRAP_NOK) tr=OFF;
					//else tr=ON;
					if ((st1 & EnumErrorStatus.TRAP_NOK)) {
						tr = false;
					} else {
						tr = true;
					}

					//if (st1 &DOOR_NOK) dr=OFF;
					//else dr=ON;
					if ((st1 & EnumErrorStatus.DOOR_NOK)) {
						//'check for door
						dr = false;
					} else {
						dr = true;
					}
				}

				if (!(ps3))
					flag = 2;
				if (!(ps1))
					flag = 3;
				if (!(aa))
					if (!(ps2))
						flag = 4;
				if (!(dr))
					flag = 5;
				if (!(tr))
					flag = 6;
			//if (!ps3) flag=2;
			//if (!ps1) flag = 3;
			//if (!aa) if (!ps2) flag = 4;
			//if (!dr) flag=5;
			//if (!tr) flag=6;

			} else {
				funcCheck_Flame();
				//'for checking flame.
				//st = CHECK_PS();
				//--- Get the info. of pressor sensor from instrument
				if (gobjCommProtocol.funcPressSensorStatus(st, false)) {
					if (((st & EnumErrorStatus.YELLOW_OK) == EnumErrorStatus.YELLOW_OK)) {
						flag = -2;
					} else if (((st & EnumErrorStatus.BLUE_OK) == EnumErrorStatus.BLUE_OK)) {
						flag = -1;
					} else if (((st & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
						flag = -1;
					}

				} else {
				}
				//if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
				//else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
				//else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
			}
			//#If DEMO Then
			// flag = random(8)-2;
			//#End If

			//if (flag == -1)
			//   return BLUE;
			//if (flag == -2)
			//   return YELLOW;

			//If (flag) Then
			//   return RED;
			//Else
			//   return GREEN;
			//}
			//Dim nRandom As New Random
			//#If DEMO Then
			//   intflag = nRandom.Next(8) -2
			//#End If

			if ((flag == -1)) {
				//'set a igniteType as per flag.
				return enumIgniteType.Blue;
			}

			if ((flag == -2)) {
				//'set a igniteType as per flag.
				return enumIgniteType.Yellow;
			}

			if ((flag)) {
				//'set a igniteType as per flag.
				return enumIgniteType.Red;
			} else {
				return enumIgniteType.Green;
			}
			Application.DoEvents();
		//'allow application to perfrom its panding work
		} catch (Threading.ThreadAbortException threadex) {
		//---Do Nothing
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

	public bool funcIgnite_Test(ref enumIgniteType InIgniteType)
	{
		//=====================================================================
		// Procedure Name        : Check_Ignite
		// Parameters Passed     : None
		// Returns               : enumIgniteType
		// Purpose               : for ignite status display
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.12.06
		// Revisions             : praveen
		//=====================================================================
		//#define    ON  1
		//#define    OFF 0

		//int S4FUNC Ignite_Test()
		//{
		//   BYTE st, st1;
		//   BOOL  ps1, ps2, ps3,aa,tr, dr;
		//   int	 flag = 0;

		//   if (!Inst.Aaf && !Inst.N2of) 
		//   {
		//       ps1 = ps2 = ps3 = ON;
		//	    st  = CHECK_PS();
		//	    if (st & AIR_NOK) ps1 = OFF;
		//	    if (st & N2O_NOK) ps2 = OFF;
		//	    if (st & FUEL_NOK) ps3 = OFF;
		//	    st1 = CHECK_BUR_PAR();
		//	    if (st1 & AA_CONNECTED) aa=ON;	// N2O/AA
		//	        else aa=OFF;
		//	    if (st1 & TRAP_NOK) tr=OFF;
		//	        else tr=ON;
		//	    if (st1 &DOOR_NOK) dr=OFF;
		//	        else dr=ON;
		//	    if (!ps3) flag=2;
		//	    if (!ps1) flag = 3;
		//	    if (!aa) if (!ps2) flag = 4;
		//	    if (!dr) flag=5;
		//	    if (!tr) flag=6;
		//   }
		//   else 
		//   {
		//       Check_Flame();
		//	    st = CHECK_PS();
		//	    if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
		//	    else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
		//	    else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
		//   }
		//   #If DEMO Then
		//       flag = random(8)-2;
		//   #End If

		//   if (flag==-1)
		//	    return BLUE;
		//   if (flag==-2)
		//       return YELLOW;

		//   If (flag) Then
		//       return RED;
		//   Else
		//	    return GREEN;
		//}

		byte st;
		byte st1;
		bool ps1;
		bool ps2;
		bool ps3;
		bool aa;
		bool tr;
		bool dr;
		int flag = 0;

		const object const_ON = 1;
		const object const_OFF = 0;


		try {
			//----------------------------------------
			//If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
			//    Application.DoEvents()

			//    Call funcCheck_Flame()
			//    If gobjCommProtocol.funcPressSensorStatus(st, False) Then
			//        ''check a presssensor status
			//        If ((st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK) Then
			//            flag = -2
			//            'gobjInst.Aaf = True
			//        ElseIf ((st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK) Then
			//            flag = -1
			//            'gobjInst.Aaf = True
			//        ElseIf ((st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK) Then
			//            flag = -1
			//            'gobjInst.Aaf = True
			//        Else
			//            gobjInst.Aaf = False
			//        End If
			//    Else
			//        Return False
			//    End If
			//End If
			//----------------------------------------

			Application.DoEvents();
			//'allow application to perfrom its panding work
			if ((!(gobjInst.Aaf == true)) & (!(gobjInst.N2of == true))) {
				//ps1 = ps2 = ps3 = ON;
				ps1 = true;
				// To check for Air pressure 
				ps2 = true;
				// To check for N2O pressure 
				ps3 = true;
				// To check for Fuel pressure 
				if (gobjCommProtocol.funcPressSensorStatus(st, false)) {
					//'check a presssensor status
					if ((st & EnumErrorStatus.AIR_NOK)) {
						ps1 = false;
					}
					if ((st & EnumErrorStatus.N2O_NOK)) {
						ps2 = false;
					}
					if ((st & EnumErrorStatus.FUEL_NOK)) {
						ps3 = false;
					}
				} else {
					return false;
				}
				if (gobjCommProtocol.funcCheckBurnerParameters(st1, false)) {
					//'check for burner parameter

					//if (st1 and  EnumErrorStatus.AA_CONNECTED) aa=ON;	// N2O/AA
					//else aa=OFF;
					if ((st1 & EnumErrorStatus.AA_CONNECTED)) {
						aa = true;
					} else {
						aa = false;
					}
					//if (st1 & TRAP_NOK) tr=OFF;
					//else tr=ON;
					if ((st1 & EnumErrorStatus.TRAP_NOK)) {
						tr = false;
					} else {
						tr = true;
					}

					//---Burner Head Confirmation    'added on 30.03.09
					//---------------------------------------------------------
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						//---changed for ver 6.89
						if (gstructSettings.NewModelName == true) {
							if ((st1 & EnumErrorStatus.BurnerHead_Present)) {
								gblnBurnerMsg = false;
							} else {
								gobjCommProtocol.func_N2O_OFF();
								gobjCommProtocol.func_FUEL_OFF();
								if (gblnBurnerMsg == false) {
									//Call gobjMessageAdapter.ShowMessage("Burner Head/Tether not present", "Warning", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
									gobjMessageAdapter.ShowMessage(constBurnerHeadMsg);
									gblnBurnerMsg = true;
								}
							}
						}
					}
					//---------------------------------------------------------

					//if (st1 &DOOR_NOK) dr=OFF;
					//else dr=ON;
					if ((st1 & EnumErrorStatus.DOOR_NOK)) {
						//'check for door
						dr = false;
					} else {
						dr = true;
					}
				} else {
					return false;
				}

				if (!(ps3))
					flag = 2;
				if (!(ps1))
					flag = 3;
				if (!(aa))
					if (!(ps2))
						flag = 4;
				if (!(dr))
					flag = 5;
				if (!(tr))
					flag = 6;
			//if (!ps3) flag=2;
			//if (!ps1) flag = 3;
			//if (!aa) if (!ps2) flag = 4;
			//if (!dr) flag=5;
			//if (!tr) flag=6;

			} else {
				//Call funcCheck_Flame()
				if (funcCheck_Flame() == false) {
					return false;
				}
				//'for checking flame.
				//st = CHECK_PS();
				//--- Get the info. of pressor sensor from instrument
				if (gobjCommProtocol.funcPressSensorStatus(st, false)) {
					if (((st & EnumErrorStatus.YELLOW_OK) == EnumErrorStatus.YELLOW_OK)) {
						flag = -2;
					} else if (((st & EnumErrorStatus.BLUE_OK) == EnumErrorStatus.BLUE_OK)) {
						flag = -1;
					} else if (((st & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
						flag = -1;
					}
				} else {
					return false;
				}
				//if ((st&YELLOW_OK) ==YELLOW_OK) flag=-2;
				//else  if ((st&BLUE_OK)==BLUE_OK)  flag=-1;
				//else if ((st & FLAME_OK)==FLAME_OK) flag=-1;
			}
			//#If DEMO Then
			// flag = random(8)-2;
			//#End If

			//if (flag == -1)
			//   return BLUE;
			//if (flag == -2)
			//   return YELLOW;

			//If (flag) Then
			//   return RED;
			//Else
			//   return GREEN;
			//}
			Random nRandom = new Random();
			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				flag = nRandom.Next(8) - 2;
			}

			if ((flag == -1)) {
				//'set a igniteType as per flag.
				//Return enumIgniteType.Blue
				InIgniteType = enumIgniteType.Blue;
				return true;
			}

			if ((flag == -2)) {
				//'set a igniteType as per flag.
				//Return enumIgniteType.Yellow
				InIgniteType = enumIgniteType.Yellow;
				return true;
			}

			if ((flag)) {
				//'set a igniteType as per flag.
				//Return enumIgniteType.Red
				InIgniteType = enumIgniteType.Red;
				return true;
			} else {
				//Return enumIgniteType.Green
				InIgniteType = enumIgniteType.Green;
				return true;
			}
		//'allow application to perfrom its panding work
		//Catch threadex As Threading.ThreadAbortException
		//---Do Nothing
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

	public int funcIgnite(bool blnFlameIgniteOn)
	{
		//Line No.2917
		//=====================================================================
		// Procedure Name        : funcIgnite
		// Parameters Passed     : blnFlameIgniteOn
		// Returns               : Integer
		// Purpose               : used for Ignite a flame or off a flame as per parameter
		//                         
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh 
		// Created               : 09.03.07
		// Revisions             : modified by Deepak B.
		//=====================================================================
		bool flag = true;
		int count = 0;
		byte bData;
		bool aa;
		int ch;
		frmFlameStatusDisplay objfrmFlameStatusDisplayIn;
		//'this is a object of form status

		//void 	S4FUNC 	Ignite(BOOL flag1)
		//{
		//BOOL 		flag=TRUE, count =0;
		//BYTE    	data, aa;
		//HWND		hwnd;
		//int   	ch;
		//HWND     hpar=NULL;
		//hpar = GetTopWindow(NULL);

		//If (!Commflag) Then
		//	return;

		//if( InstType == AA202)
		//   hwnd = Create_Window_Pneum("AA-202  AA FLAME");
		//Else
		//   hwnd = Create_Window_Pneum("AA-203  AA FLAME");

		//StHwnd=hwnd;
		//ReinitInstParameters();

		//do 
		//{ //0
		//   count++;
		//	Status_Disp();
		//	if (flag && count==5) 
		//   { //1
		//	    flag = FALSE;
		//	    if (!flag1)	  
		//       { //2
		//		    if (!Flame_Off())
		//           {//3
		//		        Beep(); Gerror_message_new(" Already Flame is Extinguished"," AUTOEXTINGUISH");
		//		    }//3
		//	    }//2
		//	    else
		//       { //4
		//		    data = CHECK_BUR_PAR();
		//		    if (data & AA_CONNECTED) aa = ON;
		//		    else aa = OFF;
		//		    if (aa) 
		//           {//5
		//			    if (!Inst.Aaf) Inst.Aaf = AA_FLAME_ON();
		//			    else {Beep(); Gerror_message(" Already in AA-Flame");}
		//			}//5
		//		    else
		//           { //6
		//			    ch=MessageBox(hpar,"    Ready for flame    Click \n Yes for AA flame \n No for NA flame ", "AA AUTO-IGNITION ", MB_YESNOCANCEL);
		//			    if (ch==IDYES)
		//               { //7
		//				    if (!Inst.Aaf) Inst.Aaf = AA_FLAME_ON();
		//				    else 
		//                   {
		//                       Beep(); 
		//                       Gerror_message_new(" Already in AA-Flame"," AUTOIGNITION");
		//                   }
		//                   #If DEMO Then
		//				        Inst.Aaf=TRUE;
		//                   #End If
		//			    }//7
		//			    else if (ch==IDNO)
		//               { //8
		//				    if (!Inst.N2of) Inst.N2of = N2_FLAME_ON();
		//				    else {Beep(); Gerror_message_new(" Already in nA-Flame"," AUTOIGNITION");}
		//			    }//8
		//		    }//6
		//       }//4
		//   }//1
		//} while(count<15); //0

		//Close_Window(hwnd, NULL);
		//ReinitInstParameters();
		//StHwnd=NULL;
		//}

		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'for 201
				return;
			}
			if (!gobjCommProtocol.mobjCommdll.gFuncIsPortOpen == true) {
				//'for checking a comm port
				return;
			}

			//Call ReInitInstParameters()
			///for reinitialise the instrument
			objfrmFlameStatusDisplayIn = new frmFlameStatusDisplay();
			objfrmFlameStatusDisplayIn.StartPosition = FormStartPosition.Manual;
			objfrmFlameStatusDisplayIn.Location = new Point(10, 50);
			Status_Disp(objfrmFlameStatusDisplayIn);
			objfrmFlameStatusDisplayIn.Show();
			Application.DoEvents();
			//'show the status display form and allow application to perfrom its panding work
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				//---21.07.09
				if (gstructSettings.NewModelName == false) {
					objfrmFlameStatusDisplayIn.Text = "AA-201  AA FLAME";
				} else {
					objfrmFlameStatusDisplayIn.Text = "AA-301  AA FLAME";
				}
			} else {
				//else
				//---21.07.09
				if (gstructSettings.NewModelName == false) {
					objfrmFlameStatusDisplayIn.Text = "AA-203  AA FLAME";
				} else {
					objfrmFlameStatusDisplayIn.Text = "AA-303  AA FLAME";
				}
			}

			ReInitInstParameters();
			//'for reinitialise the instrument

			do {
				count += 1;
				Status_Disp(objfrmFlameStatusDisplayIn);
				//'call this function for status display.
				//If (flag And count = 5) Then
				if ((flag & count == 1)) {
					flag = false;

					//--- Set flame OFF when flame ignition is ON
					if (!blnFlameIgniteOn) {
						if (!gobjCommProtocol.funcFlame_OFF()) {
							//'check the flag if not then put flame off
							Beep();
							//'noise a beep
							gobjMessageAdapter.ShowMessage(constFlameAlreadyExtinguish);
							//'show a already Extinguish the flame message.
							Application.DoEvents();
							//'allow application to perfrom it panding work.
						}
					} else {
						//--- Set flame On when flame ignition is OFF
						//--- Check the burner parameter
						gobjCommProtocol.funcCheckBurnerParameters(bData);
						//check for burner parameter 
						if ((bData & EnumErrorStatus.AA_CONNECTED)) {
							aa = true;
						} else {
							aa = false;
						}

						if (aa == true) {
							if (!gobjInst.Aaf == true) {
								gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON();
							//for AA flame on
							} else {
								Beep();
								gobjMessageAdapter.ShowMessage(constAlreadyAAFlame);
							}
						} else {
							////----- Added by Sachin on 03.03.08
							frmMessageFlame objfrmMessageFlame = new frmMessageFlame();
							DialogResult intDialogResult;
							//If gobjMessageAdapter.ShowMessage(constReadyforFlame) = True Then
							intDialogResult = objfrmMessageFlame.ShowDialog;
							if (intDialogResult == DialogResult.Yes) {
								Application.DoEvents();
								if (!gobjInst.Aaf) {
									gobjInst.Aaf = gobjCommProtocol.func_AA_FLAME_ON();
								//'set AA flame on and set a flag.
								} else {
									Beep();
									gobjMessageAdapter.ShowMessage(constAlreadyAAFlame);
									Application.DoEvents();
									//'allow application to perfrom its panding work.
								}
							//Else
							} else if (intDialogResult == DialogResult.No) {
								if (!gobjInst.N2of) {
									gobjInst.N2of = gobjCommProtocol.func_N2_FLAME_ON();
								} else {
									Beep();
									gobjMessageAdapter.ShowMessage(constAlreadyNAFlame);
									Application.DoEvents();
									//'allow application to perfrom its panding work
								}
							//---03.05.10
							} else if (intDialogResult == DialogResult.Cancel) {
								if (!objfrmMessageFlame == null) {
									objfrmMessageFlame.Dispose();
								}
								Application.DoEvents();
							}
							if (!objfrmMessageFlame == null) {
								objfrmMessageFlame.Dispose();
							}
							Application.DoEvents();
							//objfrmMessageFlame.Dispose()
							//objfrmMessageFlame = Nothing
							//Application.DoEvents()
						}
					}
				}
			//Loop While count < 15
			} while (count < 5);

			ReInitInstParameters();
		//'reinitialise the instrument.

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
			if (!IsNothing(objfrmFlameStatusDisplayIn)) {
				objfrmFlameStatusDisplayIn.Close();
				objfrmFlameStatusDisplayIn.Dispose();
				objfrmFlameStatusDisplayIn = null;
			}
			//---------------------------------------------------------
		}
	}

	//Public Function Status_Disp(ByRef objFrmManualIgnitionIn As frmManualIgnition) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : Status_Disp
	//    ' Parameters Passed     : objFrmManualIgnitionIn 
	//    ' Returns               : None
	//    ' Purpose               : To set the parameters on form load.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 23-Mar-2007
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Dim line1 As String
	//    Dim status, st, st1 As Byte
	//    Dim flag As Boolean = True

	//    Try
	//        status = gobjCommProtocol.funcGet_Pneum_Status()
	//        gobjCommProtocol.funcPressSensorStatus(st, False)
	//        gobjCommProtocol.funcCheckBurnerParameters(st1)

	//        If (st And EnumErrorStatus.AIR_NOK) Then
	//            flag = False
	//            objFrmManualIgnitionIn.pbPressureAir.Image = Image.FromFile("images\ERROR.BMP")
	//        Else
	//            objFrmManualIgnitionIn.pbPressureAir.Image = Image.FromFile("images\OK.BMP")
	//        End If

	//        If (st And EnumErrorStatus.N2O_NOK) Then
	//            flag = False
	//            objFrmManualIgnitionIn.pbPressureN2O.Image = Image.FromFile("images\ERROR.BMP")
	//        Else
	//            objFrmManualIgnitionIn.pbPressureN2O.Image = Image.FromFile("images\OK.BMP")
	//        End If

	//        If (st And EnumErrorStatus.FUEL_NOK) Then
	//            flag = False
	//            objFrmManualIgnitionIn.pbPressureFuel.Image = Image.FromFile("images\ERROR.BMP")
	//        Else
	//            objFrmManualIgnitionIn.pbPressureFuel.Image = Image.FromFile("images\OK.BMP")
	//        End If

	//        If (status And EnumErrorStatus.SAIR_NON) Then
	//            flag = False
	//            objFrmManualIgnitionIn.pbStatusAir.Image = Image.FromFile("images\close.BMP")
	//        Else
	//            objFrmManualIgnitionIn.pbStatusAir.Image = Image.FromFile("images\open.BMP")
	//        End If

	//        If (status And EnumErrorStatus.SN2O_NON) Then
	//            objFrmManualIgnitionIn.pbStatusN2O.Image = Image.FromFile("images\open.BMP")
	//        Else
	//            flag = False
	//            objFrmManualIgnitionIn.pbStatusN2O.Image = Image.FromFile("images\close.BMP")
	//        End If

	//        If (status And EnumErrorStatus.SFUEL_ON) Then
	//            objFrmManualIgnitionIn.pbStatusFuel.Image = Image.FromFile("images\open.BMP")
	//        Else
	//            flag = False
	//            objFrmManualIgnitionIn.pbStatusFuel.Image = Image.FromFile("images\close.BMP")
	//        End If

	//        If (st1 And EnumErrorStatus.AA_CONNECTED) Then
	//            objFrmManualIgnitionIn.pbBurnerType.Image = Image.FromFile("images\BTAA.bmp")
	//        Else
	//            objFrmManualIgnitionIn.pbBurnerType.Image = Image.FromFile("images\BTNA.bmp")
	//        End If

	//        If (st1 And EnumErrorStatus.TRAP_NOK) Then
	//            flag = False
	//            objFrmManualIgnitionIn.pbSafetyControlsTrap.Image = Image.FromFile("images\topen.bmp")
	//        Else
	//            objFrmManualIgnitionIn.pbSafetyControlsTrap.Image = Image.FromFile("images\OK.BMP")
	//        End If

	//        If (st1 And EnumErrorStatus.DOOR_NOK) Then
	//            flag = False
	//            objFrmManualIgnitionIn.pbSafetyControlsDoor.Image = Image.FromFile("images\DOPEN.bmp")
	//        Else
	//            objFrmManualIgnitionIn.pbSafetyControlsDoor.Image = Image.FromFile("images\DCLOSE.bmp")
	//        End If

	//        If (st And EnumErrorStatus.YELLOW_OK) = EnumErrorStatus.YELLOW_OK Then
	//            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\YELLOW.BMP")

	//        ElseIf (st And EnumErrorStatus.BLUE_OK) = EnumErrorStatus.BLUE_OK Then
	//            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\BLUE.BMP")

	//        ElseIf (st And EnumErrorStatus.FLAME_OK) = EnumErrorStatus.FLAME_OK Then
	//            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\BYELLOW.BMP")

	//        ElseIf flag Then
	//            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\GREEN.BMP")
	//        Else
	//            objFrmManualIgnitionIn.pbFlameType.Image = Image.FromFile("images\RED.BMP")
	//        End If

	//        gobjCommProtocol.funcGet_NV_Pos()

	//        objFrmManualIgnitionIn.lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00")

	//        gobjCommProtocol.func_Get_BH_Pos()
	//        objFrmManualIgnitionIn.lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00")

	//        objFrmManualIgnitionIn.lblNVStep.Text = "NV : " & gobjInst.NvStep & ""

	//        objFrmManualIgnitionIn.Refresh()

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
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

	public bool Status_Disp(ref frmFlameStatusDisplay objfrmFlameStatusDisplayIn)
	{
		//=====================================================================
		// Procedure Name        : Status_Disp
		// Parameters Passed     : objfrmFlameStatusDisplayIn
		// Returns               : True/False
		// Purpose               : to set a status of status form..
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Mar-2007
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is used for display a current status of application
		//'at status disply form.
		//'here we are setting a image as per current status



		string line1;
		byte status;
		byte st;
		byte st1;
		bool flag = true;

		try {
			status = gobjCommProtocol.funcGet_Pneum_Status();
			//'get pneumentics setting of instrument.
			gobjCommProtocol.funcPressSensorStatus(st, false);
			//'check a pressure sensor status
			gobjCommProtocol.funcCheckBurnerParameters(st1);
			//'check for burner parameter
			if ((st & EnumErrorStatus.AIR_NOK)) {
				//'check for air nok
				flag = false;
				objfrmFlameStatusDisplayIn.pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				objfrmFlameStatusDisplayIn.pbPressureAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((st & EnumErrorStatus.N2O_NOK)) {
				//'check for N2O nok.
				flag = false;
				objfrmFlameStatusDisplayIn.pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				objfrmFlameStatusDisplayIn.pbPressureN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((st & EnumErrorStatus.FUEL_NOK)) {
				//'check for FUEL nok.
				flag = false;
				objfrmFlameStatusDisplayIn.pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\ERROR.BMP");
			} else {
				objfrmFlameStatusDisplayIn.pbPressureFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((status & EnumErrorStatus.SAIR_NON)) {
				flag = false;
				objfrmFlameStatusDisplayIn.pbStatusAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
			} else {
				objfrmFlameStatusDisplayIn.pbStatusAir.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
			}

			if ((status & EnumErrorStatus.SN2O_NON)) {
				objfrmFlameStatusDisplayIn.pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
			} else {
				flag = false;
				objfrmFlameStatusDisplayIn.pbStatusN2O.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
			}

			if ((status & EnumErrorStatus.SFUEL_ON)) {
				objfrmFlameStatusDisplayIn.pbStatusFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\open.BMP");
			} else {
				flag = false;
				objfrmFlameStatusDisplayIn.pbStatusFuel.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\close.BMP");
			}

			if ((st1 & EnumErrorStatus.AA_CONNECTED)) {
				//'set a image as per cond
				objfrmFlameStatusDisplayIn.pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTAA.bmp");
			} else {
				objfrmFlameStatusDisplayIn.pbBurnerType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BTNA.bmp");
			}

			if ((st1 & EnumErrorStatus.TRAP_NOK)) {
				//'set a image as per cond
				flag = false;
				objfrmFlameStatusDisplayIn.pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\topen.bmp");
			} else {
				objfrmFlameStatusDisplayIn.pbSafetyControlsTrap.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\OK.BMP");
			}

			if ((st1 & EnumErrorStatus.DOOR_NOK)) {
				//'set a image as per cond
				//'check for door_nok
				flag = false;
				objfrmFlameStatusDisplayIn.pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\DOPEN.bmp");
			} else {
				objfrmFlameStatusDisplayIn.pbSafetyControlsDoor.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\DCLOSE.bmp");
			}

			if ((st & EnumErrorStatus.YELLOW_OK) == EnumErrorStatus.YELLOW_OK) {
				objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\YELLOW.BMP");

			} else if ((st & EnumErrorStatus.BLUE_OK) == EnumErrorStatus.BLUE_OK) {
				objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BLUE.BMP");

			} else if ((st & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK) {
				objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\BYELLOW.BMP");

			} else if (flag) {
				objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\GREEN.BMP");
			} else {
				objfrmFlameStatusDisplayIn.pbFlameType.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\RED.BMP");
			}

			gobjCommProtocol.funcGet_NV_Pos();
			//'for getting NV position
			objfrmFlameStatusDisplayIn.lblFRatio.Text = Format(gobjClsAAS203.funcRead_Fuel(), "0.00");

			gobjCommProtocol.func_Get_BH_Pos();
			//'for getting burner position
			objfrmFlameStatusDisplayIn.lblBHeight.Text = Format(gobjClsAAS203.funcReadBurnerHeight(), "0.00");

			objfrmFlameStatusDisplayIn.Refresh();

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

	public bool funcSetLastFuel(int intNVS)
	{
		//=====================================================================
		// Procedure Name        : funcSetLastFuel
		// Parameters Passed     :  intNVS
		// Returns               : Boolean
		// Purpose               : for setting last fuel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.12.06
		// Revisions             : parveen
		//=====================================================================

		try {
			//            void SetLastFuel( int nvs )
			//{
			//int	k;
			//Get_NV_Pos();
			//            If (Inst.Nvstep < nvs) Then
			//  NV_RotateAnticlock_Steps(abs(nvs-Inst.Nvstep));
			//            Else
			//  NV_RotateClock_Steps(abs(Inst.Nvstep-nvs));
			// Get_NV_Pos();
			//}

			gobjCommProtocol.funcGet_NV_Pos();
			//'for gettin NV setting
			if ((gobjInst.NvStep < intNVS)) {
				gobjCommProtocol.funcNV_RotateAntiClock_Steps(Math.Abs(intNVS - gobjInst.NvStep));
			//'for rotating a NV at anti clock wise direction 
			} else {
				gobjCommProtocol.funcNV_RotateClock_Steps(Math.Abs(gobjInst.NvStep - intNVS));
				//'for rotating a NV at  clock wise direction 

				gobjCommProtocol.funcGet_NV_Pos();
				//'now get NV current position
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	//Public Function funcGetFiltData(ByVal ADCVolt As Double) As Double
	//    '=====================================================================
	//    ' Procedure Name        : funcGetFiltData
	//    ' Parameters Passed     :  ADCVolts
	//    ' Returns               : Boolean
	//    ' Purpose               : To Check Ignite position
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale
	//    ' Created               : 21.12.06
	//    ' Revisions             : 
	//    '=====================================================================

	//    Try
	//        '            int TimeConst=2;
	//        'double 	S4FUNC	GetFiltData( double ADCVolt )
	//        '{
	//        'double xcoeff1002[6][3] ={
	//        '					{0.067455,0.134911,0.067455}, //0.131106,0.262213,0.131106, 	 // fc = 10 Hz, fs = 100 Hz, O = 2
	//        '					{0.020083,0.040167,0.020083}, // fc = 5 Hz, fs = 100 Hz, O = 2
	//        '					{0.003622,0.007243,0.003622}, //fc = 2 Hz fs = 100 Hz, O = 2
	//        '					{0.000945,0.001889,0.000945}, // fc = 1 Hz fs = 100 Hz O = 2
	//        '					{0.000039,0.000078,0.000039}, // fc = 0.2 Hz fs = 100 Hz O = 2
	//        '					{0.000010,0.000020,0.000010}
	//        '				 }; // fc = 0.1 Hz fs = 100 Hz O = 2
	//        'double ycoeff1002[6][2] ={
	//        '					{1.14298,-0.412802},  // 0.747789,-0.272215, 	// fc = 10 Hz, fs = 100 Hz, O = 2
	//        '					{1.56102,-0.641352},		 // fc = 5 Hz, fs = 100 Hz, O = 2
	//        '					{1.8227,-0.837182},		// fc = 2 Hz, fs = 100 Hz, O = 2
	//        '					{1.9112,-0.914976},		// fc = 1 hz fs = 100 O Hz O = 2
	//        '					{1.98223,-0.982385},       // fc = 0.2 Hz fs = 100 Hz O = 2
	//        '					{1.99111,-0.991154}};		// fc = 0.1 Hz fs = 100 Hz O = 2
	//        '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
	//        'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;

	//        '			filtdata  = xcoeff1002[TimeConst][0]*ADCVolt;
	//        '			filtdata += xcoeff1002[TimeConst][1]*Xn_1;
	//        '			filtdata += xcoeff1002[TimeConst][2]*Xn_2;
	//        '			filtdata += ycoeff1002[TimeConst][0]*Yn_1;
	//        '			filtdata += ycoeff1002[TimeConst][1]*Yn_2;
	//        '			Xn_2 = Xn_1;
	//        '			Xn_1 = ADCVolt;
	//        '			Yn_2 = Yn_1;
	//        '			Yn_1 = filtdata;
	//        'return filtdata;
	//        '}
	//        '//----- Start from here
	//        'Dim intTimeConst As Integer = 2
	//        Dim xcoeff1002(,) As Double = {{0.067455, 0.134911, 0.067455}, {0.020083, 0.040167, 0.020083}, {0.003622, 0.007243, 0.003622}, {0.000945, 0.001889, 0.000945}, {0.000039, 0.000078, 0.000039}, {0.00001, 0.00002, 0.00001}}
	//        '}; // fc = 0.1 Hz fs = 100 Hz O = 2
	//        Dim ycoeff1002(,) As Double = { _
	//             {1.14298, -0.412802}, {1.56102, -0.641352}, {1.8227, -0.837182}, {1.9112, -0.914976}, {1.98223, -0.982385}, {1.99111, -0.991154}}

	//        '//-----butterworth filter Order = 2 Sampling Freq = 100Hz ------------
	//        'static	double Xn_2=0,Xn_1=0,Yn_1=0,Yn_2=0,filtdata=0;
	//        Static Dim Xn_2 As Double = 0
	//        Static Dim Xn_1 As Double = 0
	//        Static Dim Yn_1 As Double = 0
	//        Static Dim Yn_2 As Double = 0
	//        Static Dim filtdata As Double = 0
	//        Static intCal_Mode As Integer

	//        If Not (intCal_Mode = gobjInst.Mode) Or (blnResetFilterData = True) Then
	//            intCal_Mode = gobjInst.Mode
	//            Xn_2 = 0
	//            Xn_1 = 0
	//            Yn_1 = 0
	//            Yn_2 = 0
	//            filtdata = 0
	//            blnResetFilterData = False
	//        End If


	//        filtdata = xcoeff1002(gintTimeConstant, 0) * ADCVolt
	//        filtdata += xcoeff1002(gintTimeConstant, 1) * Xn_1
	//        filtdata += xcoeff1002(gintTimeConstant, 2) * Xn_2
	//        filtdata += ycoeff1002(gintTimeConstant, 0) * Yn_1
	//        filtdata += ycoeff1002(gintTimeConstant, 1) * Yn_2
	//        Xn_2 = Xn_1
	//        Xn_1 = ADCVolt
	//        Yn_2 = Yn_1
	//        Yn_1 = filtdata

	//        Return filtdata
	//        '}

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return 0.0
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

	public bool funcCheck_Flame()
	{
		//=====================================================================
		// Procedure Name        : funcCheck_Flame
		// Parameters Passed     :  none.
		// Returns               : Boolean
		// Purpose               : To Check Flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.12.06
		// Revisions             : 
		//=====================================================================
		try {
			//BYTE 		st;
			//BOOL 	ps1, ps2, ps3, flag=0;

			//if (Inst.Aaf || Inst.N2of) {
			//	ps1 = ps2 = ps3 = ON;
			//	st  = CHECK_PS();
			//	if (st & AIR_NOK) ps1 = OFF;
			//	if (st & N2O_NOK) ps2 = OFF;
			//	if (st & FUEL_NOK) ps3 = OFF;
			//#If HYRD_MODE Then
			//	if (!HydrideMode){
			//#Else
			//	if (!Inst.Hydride){
			//#End If
			//	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
			//	  }
			//	if (!ps3) flag=2;
			//	if (Inst.Aaf) if (!ps1) flag = 3;
			//	if (Inst.N2of) if (!ps2) flag = 4;
			//#If DEMO Then
			//		flag=FALSE;
			//#End If

			//	if (flag){
			//	  Flame_Off();
			//	  switch(flag) {
			//		 case 1 : Inst.Nvstep-= (5*NVSTEP);Save_NV_Pos();
			//					 Gerror_message(" **FLAME ERROR *** \n Flame OFF "); break;
			//		 case 2 : Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
			//		 case 3 : Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
			//		 case 4 : Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
			//	  }
			//	}
			// }
			//}

			byte bdata;
			bool ps1;
			bool ps2;
			bool ps3;
			int intflag = 0;

			//if (Inst.Aaf || Inst.N2of) {
			//	ps1 = ps2 = ps3 = ON;
			if (((gobjInst.Aaf) | (gobjInst.N2of))) {
				//if true
				ps1 = true;
				// To check for Air pressure 
				ps2 = true;
				// To check for N2O pressure 
				ps3 = true;
				// To check for Fuel pressure 

				if (gobjCommProtocol.funcPressSensorStatus(bdata)) {
					//'get a presssensor status
					if ((bdata & EnumErrorStatus.AIR_NOK)) {
						//'check for air nok
						ps1 = false;
					}
					if ((bdata & EnumErrorStatus.N2O_NOK)) {
						//'check for n2o nok
						ps2 = false;
					}
					if ((bdata & EnumErrorStatus.FUEL_NOK)) {
						//'check for fuel nok
						ps3 = false;
					}
					//End If

					//#If HYRD_MODE Then
					//	if (!HydrideMode){
					//#Else
					//	if (!Inst.Hydride){
					//#End If
					//	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
					//	  }


					if (gstructSettings.HydrideMode) {
						//'check for hydride mode
						if (!HydrideMode) {
							if ((!(bdata & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
								intflag = 1;
							}
						}
					} else {
						if (!(gobjInst.Hydride)) {
							if ((!(bdata & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
								intflag = 1;
							}
						}
					}

					//	if (!ps3) flag=2;
					//	if (Inst.Aaf) if (!ps1) flag = 3;
					//	if (Inst.N2of) if (!ps2) flag = 4;

					if (!(ps3)) {
						intflag = 2;
					}

					if ((gobjInst.Aaf)) {
						if (!(ps1)) {
							intflag = 3;
						}
					}

					if ((gobjInst.N2of)) {
						if (!(ps2)) {
							intflag = 4;
						}
					}

					//#If DEMO Then
					//		flag=FALSE;
					//#endif
					//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
					if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
						intflag = false;
					}

					if ((intflag)) {
						gobjCommProtocol.funcFlame_OFF();
						//'for flame off
						////--- check the flame status for AA201 03.10.08

						if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
							//---added on 30.03.09
							gobjCommProtocol.func_N2O_OFF();
							gobjCommProtocol.func_FUEL_OFF();
							//-------------

							////--- Set the Fuel volve off  when flame is not present
							if (gobjCommProtocol.func_FUEL_OFF() == true) {
							}
							////--- Set the N2O volve off when flame is not present
							if ((gobjInst.N2of)) {
								if (gobjCommProtocol.func_N2O_OFF() == true) {
								}
							}
						}
						////---
						switch (intflag) {
							//'select case as per flag
							case 1:
								////--- check the flame status for AA201 03.10.08
								if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
									//---added on 30.03.09
									gobjCommProtocol.func_N2O_OFF();
									gobjCommProtocol.func_FUEL_OFF();
									//-------------

									gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
								} else {
									gobjInst.NvStep -= (5 * NVSTEP);
									//**************************************************************************
									//---Added function by Mangesh on 23-Apr-2007
									//**************************************************************************
									gobjCommProtocol.funcSave_NV_Pos();
									//'for saving a NV position
									//**************************************************************************
									gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff);
									//break;
								}
							////---
							case 2:

								//----added on 30.03.09 to close the valve before message display '30.03.09
								if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
									//---added on 30.03.09
									gobjCommProtocol.func_N2O_OFF();
									gobjCommProtocol.func_FUEL_OFF();
									//-------------                                    
								}
								//---------

								// Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;

								gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff);
							case 3:
								if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
									//---added on 30.03.09
									gobjCommProtocol.func_N2O_OFF();
									gobjCommProtocol.func_FUEL_OFF();
									//-------------
								}

								// Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
								gobjMessageAdapter.ShowMessage(constFlameErrorAirOff);
							case 4:
								//----added on 30.03.09 to close the valve before message display '30.03.09
								if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
									//---added on 30.03.09
									gobjCommProtocol.func_N2O_OFF();
									gobjCommProtocol.func_FUEL_OFF();
									//-------------                                    
								}
								//--------------

								// Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
								gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff);
						}
					}
				}
			}

			funcCheck_Flame = true;

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

	public bool funcCheck_Flame(ref bool flag)
	{
		//=====================================================================
		// Procedure Name        : funcCheck_Flame
		// Parameters Passed     :  none.
		// Returns               : Boolean
		// Purpose               : To Check Flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.12.06
		// Revisions             : 
		//=====================================================================
		try {
			//BYTE 		st;
			//BOOL 	ps1, ps2, ps3, flag=0;

			//if (Inst.Aaf || Inst.N2of) {
			//	ps1 = ps2 = ps3 = ON;
			//	st  = CHECK_PS();
			//	if (st & AIR_NOK) ps1 = OFF;
			//	if (st & N2O_NOK) ps2 = OFF;
			//	if (st & FUEL_NOK) ps3 = OFF;
			//#If HYRD_MODE Then
			//	if (!HydrideMode){
			//#Else
			//	if (!Inst.Hydride){
			//#End If
			//	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
			//	  }
			//	if (!ps3) flag=2;
			//	if (Inst.Aaf) if (!ps1) flag = 3;
			//	if (Inst.N2of) if (!ps2) flag = 4;
			//#If DEMO Then
			//		flag=FALSE;
			//#End If

			//	if (flag){
			//	  Flame_Off();
			//	  switch(flag) {
			//		 case 1 : Inst.Nvstep-= (5*NVSTEP);Save_NV_Pos();
			//					 Gerror_message(" **FLAME ERROR *** \n Flame OFF "); break;
			//		 case 2 : Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;
			//		 case 3 : Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
			//		 case 4 : Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
			//	  }
			//	}
			// }
			//}

			byte bdata;
			bool ps1;
			bool ps2;
			bool ps3;
			int intflag = 0;

			//if (Inst.Aaf || Inst.N2of) {
			//	ps1 = ps2 = ps3 = ON;
			//If ((gobjInst.Aaf) Or (gobjInst.N2of)) Then
			//if true
			ps1 = true;
			// To check for Air pressure 
			ps2 = true;
			// To check for N2O pressure 
			ps3 = true;
			// To check for Fuel pressure 

			if (gobjCommProtocol.funcPressSensorStatus(bdata)) {
				//'get a presssensor status
				if ((bdata & EnumErrorStatus.AIR_NOK)) {
					//'check for air nok
					ps1 = false;
				}
				if ((bdata & EnumErrorStatus.N2O_NOK)) {
					//'check for n2o nok
					ps2 = false;
				}
				if ((bdata & EnumErrorStatus.FUEL_NOK)) {
					//'check for fuel nok
					ps3 = false;
				}
				//End If

				//#If HYRD_MODE Then
				//	if (!HydrideMode){
				//#Else
				//	if (!Inst.Hydride){
				//#End If
				//	  if ((st&FLAME_OK) !=FLAME_OK ) flag=1;
				//	  }


				if (gstructSettings.HydrideMode) {
					//'check for hydride mode
					if (!HydrideMode) {
						if ((!(bdata & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
							intflag = 1;
						}
					}
				} else {
					if (!(gobjInst.Hydride)) {
						if ((!(bdata & EnumErrorStatus.FLAME_OK) == EnumErrorStatus.FLAME_OK)) {
							intflag = 1;
						}
					}
				}

				//	if (!ps3) flag=2;
				//	if (Inst.Aaf) if (!ps1) flag = 3;
				//	if (Inst.N2of) if (!ps2) flag = 4;

				if (!(ps3)) {
					intflag = 2;
				}

				if ((gobjInst.Aaf)) {
					if (!(ps1)) {
						intflag = 3;
					}
				}

				if ((gobjInst.N2of)) {
					if (!(ps2)) {
						intflag = 4;
					}
				}

				//#If DEMO Then
				//		flag=FALSE;
				//#endif
				//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
				if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
					intflag = false;
				}

				if ((intflag)) {
					gobjCommProtocol.funcFlame_OFF();
					//'for flame off
					////--- check the flame status for AA201 03.10.08
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						////--- Set the Fuel volve off  when flame is not present
						if (gobjCommProtocol.func_FUEL_OFF() == true) {
						}
						////--- Set the N2O volve off when flame is not present
						if ((gobjInst.N2of)) {
							if (gobjCommProtocol.func_N2O_OFF() == true) {
							}
						}
					}
					////---
					switch (intflag) {
						//'select case as per flag
						case 1:
							////--- check the flame status for AA201 03.10.08
							if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
								gobjMessageAdapter.ShowMessage("Flame is off", "Flame Off", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
							} else {
								gobjInst.NvStep -= (5 * NVSTEP);
								//**************************************************************************
								//---Added function by Mangesh on 23-Apr-2007
								//**************************************************************************
								gobjCommProtocol.funcSave_NV_Pos();
								//'for saving a NV position
								//**************************************************************************
								gobjMessageAdapter.ShowMessage(constFlameErrorFlameOff);
								//break;
								flag = false;
								//29.12.08
							}
						////---
						case 2:
							flag = false;
							//29.12.08
							// Gerror_message(" **FLAME ERROR *** \n Fuel not enough "); break;

							gobjMessageAdapter.ShowMessage(constFlameErrorFuelOff);
						case 3:
							flag = false;
							//29.12.08
							// Gerror_message(" **FLAME ERROR *** \n Air  not enough "); break;
							gobjMessageAdapter.ShowMessage(constFlameErrorAirOff);
						case 4:
							flag = false;
							//29.12.08
							// Gerror_message(" **FLAME ERROR *** \n N2o  not enough "); break;
							gobjMessageAdapter.ShowMessage(constFlameErrorN2OOff);
					}
				}
			}
			//End If

			funcCheck_Flame = true;

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

	public void funcSetInstrumentCondns(bool flag, ref Label lblElementName = null, ref Label lblLampCurrent = null, ref Label lblWavelength = null, ref Label lblSlitWidth = null, ref Label lblFlameBurner = null)
	{
		//=====================================================================
		// Procedure Name        : funcSetInstrumentCondns
		// Parameters Passed     :  flag,lblElementName rest are the optional
		// Returns               : 
		// Purpose               : To set the instrument cond 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.12.06
		// Revisions             : Deepak on 17.02.07
		//=====================================================================
		//--------ORIGINAL CODE
		///char	str[40]="";
		///        If (flag) Then
		///	sprintf(str, "%s ",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
		///        Else
		///	sprintf(str, "%s ",Inst->Lamp_par.Ems.elname);
		/// SetWindowText(GetDlgItem(hwnd, IDC_TELNAME), str);
		///            If (flag) Then
		///	sprintf(str, "Cur : %-3.1f mA",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur);
		/// else strcpy(str,"");
		/// SetWindowText(GetDlgItem(hwnd, IDC_TCUR), str);
		///                If (flag) Then
		///	sprintf(str, "Wv : %-5.2f nm",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv);
		///                Else
		///	sprintf(str, "Wv : %-5.2f nm",Inst->Lamp_par.Ems.wv);
		/// SetWindowText(GetDlgItem(hwnd, IDC_TWV), str);
		///                    If (flag) Then
		///	sprintf(str, "Slit : %-2.1f nm",Inst->Lamp_par.lamp[Inst->Lamp_pos-1]. slitwidth);
		///                    Else
		///	sprintf(str, "Slit : %-2.1f nm",Inst->Lamp_par.Ems.slitwidth);
		/// SetWindowText(GetDlgItem(hwnd, IDC_TSLIT), str);
		/// if (flag){
		///	if (Inst->Lamp_par.lamp[Inst->Lamp_pos-1].burner)
		///		strcpy(str, "Flame : AA");
		///                            Else
		///		strcpy(str, "Flame : NA");
		///	 }
		///  else strcpy(str,"");
		/// SetWindowText(GetDlgItem(hwnd, IDC_TFUEL), str);

		//******************************************************************
		//--- CODE BY MANGESH 
		//******************************************************************
		string str = "";

		try {
			if ((flag)) {
				str = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName;
			//'for setting element name
			} else {
				str = gobjInst.Lamp.EMSCondition.ElementName;
			}
			if (!IsNothing(lblElementName))
				lblElementName.Text = str;

			if ((flag)) {
				str = "Current : " + gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current + " mA";
			//'setting lamp current
			} else {
				str = "";
			}
			if (!IsNothing(lblLampCurrent))
				lblLampCurrent.Text = str;

			if ((flag)) {
				str = "Wavelength : " + gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Wavelength + " nm";
			//'for setting wavelength
			} else {
				str = "Wavelength : " + gobjInst.Lamp.EMSCondition.Wavelength + " nm";
			}
			if (!IsNothing(lblWavelength))
				lblWavelength.Text = str;

			if ((flag)) {
				str = "Slit Width : " + gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).SlitWidth + " nm";
			//'for setting slit width
			} else {
				str = "Slit Width : " + gobjInst.Lamp.EMSCondition.SlitWidth + " nm";
			}
			if (!IsNothing(lblSlitWidth))
				lblSlitWidth.Text = str;

			if ((flag)) {
				//'for setting flame as per the burner
				if ((gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Burner)) {
					str = "Flame : AA ";
				} else {
					str = "Flame : NA ";
				}
			} else {
				str = "";
			}
			if (!IsNothing(lblFlameBurner))
				lblFlameBurner.Text = str;

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

	public void subWaitForAdc()
	{
		//=====================================================================
		// Procedure Name        : subWaitForAdc
		// Parameters Passed     : None 
		// Returns               : None
		// Purpose               : To set some wait time in ADC reading.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.12.06
		// Revisions             : praveen
		//=====================================================================
		//{
		//int	ad;
		// for(ad=0;ad<10; ad++)
		//	ReadADCFilter();
		//}
		int intad;
		int intAvgValue;
		for (intad = 0; intad <= 10; intad++) {
			gobjCommProtocol.funcReadADCFilter(1, intAvgValue);
			//'wait for ADC and Read ADC filter.
		}

	}

	//Private blnUVFlag As Boolean = False

	public bool funcSetRest_uvs_Condn(double WvNew, bool blnflag, ref Label lblUVWavelength, ref bool blnUVFlag)
	{
		//=====================================================================
		// Procedure Name        : funcSetRest_uvs_Condn
		// Parameters Passed     :  WvNew,blnflag,lblUVWavelength,blnUVFlag
		// Returns               : Boolean
		// Purpose               : to set a cond forUV mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.12.06
		// Revisions             : praveen
		//=====================================================================
		try {
			//void	S4FUNC 	SetRest_uvs_Condn(HWND hwnd, double wvnew, BOOL flag,int x, int y)
			//{
			////char *ell=NULL;
			//static	int	sp=0;
			//HDC		hdc;
			//#If !GRAPHITE Then
			// if (!uvflag)
			//  Flame_Off();
			//// if (Flame_Present()) Ignite(FALSE);
			// if(GetInstrument() == AA202)
			//	 AIR_ON();
			// else
			//	 AIR_OFF();
			//#End If
			// if (!uvflag){
			//                If (flag) Then
			//	  Blink_MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n then PRESS OK BUTTON ", "UV Mode",0);
			////	  MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n                     then PRESS OK BUTTON ", "UV Mode",MB_OK);
			//	Set_lamp(FALSE);
			//	Cal_Mode(D2E);
			//	sp =Inst->Slitpos;
			//	Slit_Home();
			//	Set_D2_Cur(300);
			//	if (Inst->d2Pmt==0)
			//	  Adj_D2Gain(hwnd, FALSE, x, y);
			//	Set_PMT(Inst->d2Pmt);
			//	hdc=GetDC(hwnd);
			//	Wavelength_Position(hdc, wvnew,x, y);
			//	ReleaseDC(hwnd, hdc);
			//	}
			//  else{
			//  Cal_Mode(AA);
			//                        If (flag) Then
			//	 Blink_MessageBox(hwnd,"REMOVE CUVETTE HOLDER and INSERT  BURNER \n then PRESS OK BUTTON ", "UVS Node",0);
			////    MessageBox(hwnd,"REMOVE CUVETTE HOLDER and INSERT  BURNER \n                     then PRESS OK BUTTON ", "UVS Node",MB_OK);
			//  Set_lamp(TRUE);
			//#If !GRAPHITE Then
			// if(GetInstrument() != AA202 )
			//  AIR_ON();
			//#End If
			//  Set_D2_Cur(100); D2_OFF();
			//  Position_Slit(sp);
			//  }
			// uvflag^=1;
			//}

			static int intsp = 0;
			//'static variable
			funcSetRest_uvs_Condn = false;
			//'flag for function
			//#If !GRAPHITE Then
			// if (!uvflag)
			//  Flame_Off();

			// if(GetInstrument() == AA202)
			//	 AIR_ON();
			// else
			//	 AIR_OFF();
			//#End If
			// Check the condition for Flame off when Graphite not set and UV setting is not seted
			if (!(Graphite == true)) {
				if ((blnUVFlag) == false) {
					gobjCommProtocol.funcFlame_OFF();
					//'if blnUVFlag is false then put flame off
				}


				//If (GetInstrument() = AA202) Then
				//   AIR_ON()
				//Else
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					//'check for 201
					gobjCommProtocol.funcAir_ON();
				//'for putting air on
				} else {
					gobjCommProtocol.funcAir_OFF();
					//'for putting air off
				}
			}
			//End If
			//#End If

			//if (!uvflag){
			//If (flag) Then
			//Blink_MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n then PRESS OK BUTTON ", "UV Mode",0);
			if ((blnUVFlag == false)) {
				if ((blnflag == true)) {
					//Blink_MessageBox(hwnd,"REMOVE BURNER and INSERT CUVETTE HOLDER \n then PRESS OK BUTTON ", "UV Mode",0);
					gobjMessageAdapter.ShowMessage(constRemoveBurner);
					Application.DoEvents();
					//'show the mess and allow application to perfrom its panding work.
				}

				////----- Set all lamp tobe off
				//Set_lamp(FALSE);
				gobjCommProtocol.funcSet_Lamp(false, 0, 0);
				//'for setting lamp
				//Cal_Mode(D2E);
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E);
				//'for setting calibration mode
				////----- Restore the Slit Position and move to Home position
				//sp =Inst->Slitpos;
				intsp = gobjInst.SlitPosition;
				gobjCommProtocol.gFuncSlit_Home();
				//'for making a clit home
				gobjCommProtocol.funcSetD2Cur(300);
				//'for setting D2 current
				//if (Inst->d2Pmt==0)
				//Adj_D2Gain(hwnd, FALSE, x, y);
				if ((gobjInst.D2Pmt == 0)) {
					//Call gobjCommProtocol.func Adj_D2Gain(False)
					funcAdj_D2Gain(false, lblUVWavelength);
					//'for adjusting a D2 gain.
				}

				//Set_PMT(Inst->d2Pmt);
				gobjCommProtocol.funcSet_PMT(gobjInst.D2Pmt);
				//'for setting PMT
				//Wavelength_Position(hdc, wvnew,x, y);
				gobjCommProtocol.Wavelength_Position(WvNew, lblUVWavelength);
			//'for position the wavelength
			} else {
				//Cal_Mode(AA);
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				//---for setting calibration mode
				//If (flag) Then
				//Blink_MessageBox(hwnd,"REMOVE CUVETTE HOLDER and INSERT  BURNER \n then PRESS OK BUTTON ", "UVS Node",0);
				if ((blnflag == true)) {
					gobjMessageAdapter.ShowMessage(constRemoveCuvette);
					Application.DoEvents();
					//'for allowing application to perfrom its panding work
				}

				//Set_lamp(True);
				gobjCommProtocol.funcSet_Lamp(true);
				//--- function for setting lamp true.
				//#If !GRAPHITE Then
				// if(GetInstrument() != AA202 )
				//  AIR_ON();
				//#End If
				if (!(Graphite == true)) {
					if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
						gobjCommProtocol.funcAir_ON();
						//--- for air on
					}
				}

				gobjCommProtocol.funcSetD2Cur(100);
				//--- for setting D2 curr
				gobjCommProtocol.D2_OFF();
				//--- for setting D2 off
				//  Position_Slit(sp);
				gobjCommProtocol.funcPosition_Slit_Entry(intsp);
				//--- for position slit entry
				//  }
				// uvflag^=1;
				//}
			}

			blnUVFlag = blnUVFlag ^ 1;

			funcSetRest_uvs_Condn = true;

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

	#Region " Functions Related to Analysis Mode "

	//--- Enumarator for Sample type
	public enum enumSampleType
	{
		//'this is a enum for sampler type
		BLANK = 0,
		STANDARD = 1,
		SAMPLE = 2
	}

	//#define	BLANKCOLOR		RGB(0, 127,128)
	//#define	STDCOLOR		RGB(255, 0,0)
	//#define	SAMPCOLOR		RGB(0, 0, 255)
	public static Color BLANKCOLOR = Color.FromArgb(0, 127, 128);
	public static Color STDCOLOR = Color.FromArgb(255, 0, 0);
	public static Color SAMPCOLOR = Color.FromArgb(0, 0, 255);
	public static Color BLACKCOLOR = Color.FromArgb(0, 0, 0);
		// FromArgb(0, 0, 0)
	public static Color GREEN = Color.Green;
		//FromArgb(0, 0, 0)
	public static Color YELLOW = Color.Yellow;


	//--- For Emission Peak 
	//double	 EmsZero=(double) 0.0;

	private double EmsZero = 0.0;
	//Public Sub GetValueIsString(ByVal dblValue As Double, ByVal intMode As Integer, ByRef ValueInString As String)
	//    'void GetValInString(double val, char *str, int mode)
	//    '{
	//    ' switch(mode){
	//    '	case	MODE_AA:
	//    '	case  MODE_AABGC:
	//    '	case	MODE_UVABS:
	//    '			StoreAbsAccurate(val,str);
	//    '		break;
	//    '	case MODE_EMMISSION:
	//    '	case MODE_SPECT:
	//    '		sprintf(str,"%-4.1f",val);
	//    '		break;
	//    '	}
	//    '}

	//    '********************************************
	//    '---CODE BY MANGESH 
	//    '********************************************

	//    Select Case (intMode)
	//        Case EnumOperationMode.MODE_AA
	//        Case EnumOperationMode.MODE_AABGC
	//        Case EnumOperationMode.MODE_UVABS
	//            'StoreAbsAccurate(dblValue, ValueInString)

	//        Case EnumOperationMode.MODE_EMMISSION
	//        Case EnumOperationMode.MODE_SPECT
	//            ValueInString = dblValue '"%-4.1f",  
	//    End Select


	//End Sub

	public double Get_Reading(enumSampleType intSampleType, AAS203Library.Method.clsAnalysisStdParameters CurStd, bool blnIsForFilter, AAS203Library.Method.clsAnalysisSampleParameters CurSample)
	{

		//=====================================================================
		// Procedure Name        : Get_Reading
		// Parameters Passed     : sampler type,STD,flag for fliter ,current sampler 
		// Returns               : double
		// Purpose               : to get a reading in analysis

		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 22.12.06
		// Revisions             : 
		//=====================================================================
		//double  Get_Reading(void)
		//{
		//int	adval;
		//double data=0.0;
		//adval = adcscan();
		//data = (double) GetADConvertedTo(adval, Method->Mode);
		//if (Method->Mode==MODE_EMISSION)
		//   data-= Get_Emission_Zero();
		//#If GRAPHITE Then
		//	if (ReadGrRawFile(&data))
		//	    data=500.0;
		//#End If

		//#If QDEMO Then
		//	data = GetDataFromDemo(data);
		//#End If

		//if(checkmindetect)
		//  {
		//	data=CheckForMinAbsLevel(data);  
		//  }
		//return data;
		//}

		//****************************************
		//---CODE BY MANGESH 
		//****************************************
		int intADCValue;
		double dblAbsorbanceReading = 0.0;

		try {
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if (!((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D))) {
				intADCValue = ADCScan(blnIsForFilter, intSampleType);
				dblAbsorbanceReading = gfuncGetADConvertedTo(intADCValue, gobjNewMethod.OperationMode);
			}

			if ((gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION)) {
				dblAbsorbanceReading -= funcGet_Emission_Zero();
			}

			//#If GRAPHITE Then
			//	if (ReadGrRawFile(&data))
			//	    data=500.0;
			//#End If

			//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				dblAbsorbanceReading = GetDataFromDemo(intSampleType, dblAbsorbanceReading, CurStd, CurSample);
			}

			if ((gstructSettings.SetMinAbsLimit)) {
				dblAbsorbanceReading = CheckForMinAbsLevel(dblAbsorbanceReading);
			}

			return dblAbsorbanceReading;

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

	public int ADCScan(bool blnIsForFilter, enumSampleType intSampleType)
	{
		//=====================================================================
		// Procedure Name        : ADCScan
		// Parameters Passed     : Is filter or not flag,sampler type
		// Returns               : ADC Count
		// Purpose               : To read the ADC Count as Reading
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//int ADCScan(void)
		//{
		//   #If QDEMO Then
		//	    return  adcscan1();
		//   #Else
		//       int	adval;
		//       if (InstType==AADEMO)
		//	        return  adcscan1();

		//       If (Filter_flag) Then
		//	        adval = ReadADCforFilter();
		//       Else
		//	        adval = ReadADCFilter();

		//       return adval;
		//   #End If
		//}
		//**********************************
		//----CODE BY MANGESH 
		//**********************************
		long intADCValue;

		try {
			switch (gintInstrumentBeamType) {
				case enumInstrumentBeamType.SingleBeam:
					if ((blnIsForFilter)) {
						intADCValue = gobjCommProtocol.ReadADCforFilter();
					} else {
						gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intADCValue);

					}
				case enumInstrumentBeamType.DoubleBeam:
					if (gobjInst.Mode == EnumCalibrationMode.AA) {
						if ((blnIsForFilter)) {
							intADCValue = gobjCommProtocol.funcReadADCforFilter_DoubleBeam();
						} else {
							gobjCommProtocol.funcReadADCFilter_DoubleBeam(gobjInst.Average, intADCValue);
						}
					} else {
						if ((blnIsForFilter)) {
							intADCValue = gobjCommProtocol.ReadADCforFilter();
						} else {
							gobjCommProtocol.funcReadADCFilter(gobjInst.Average, intADCValue);
						}
					}
			}

			return intADCValue;

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

	public double GetDataFromDemo(enumSampleType SampType, double data, Method.clsAnalysisStdParameters CurStd, Method.clsAnalysisSampleParameters CurSample)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   GetDataFromDemo
		//Description            :   
		//Parameters             :   None
		//Time/Date              :   27/9/06
		//Dependencies           :   
		//Author                 :   
		//Revision               :
		//Revision by Person     :
		//-----------------------------------------------

		//typedef  struct absxonc{
		//   double	abs;
		//   double conc;
		//}
		//AbsConc;

		//double	GetDataFromDemo(double data)
		//{
		//   AbsConc	abs1[]={
		//		{0.103, 20.0},
		//		{0.157, 40.0},
		//		{0.241, 60.0},
		//		{0.306, 80.0},
		//		{0.352, 100.0},
		//		{0.152 ,1.0},
		//		{0.125 ,2.0},
		//		{0.125 ,7.0},
		//		{0.005 ,5.0},
		//		{0.772 ,6.0},
		//		{0, 0}
		//	};
		//   double	data1 = data;
		//   double	conc = 0.0;
		//   int	i;
		//   if (SampType==STD && CurStd)
		//   {
		//	    conc = CurStd->Data.Conc;
		//	    i=0;
		//	    while (abs1[i].abs!=(double) 0.0 && abs1[i].conc!=(double) 0.0 )
		//       {
		//	        if (conc==abs1[i].conc)
		//           {
		//		        data1= abs1[i].abs;
		//		        break;
		//		    }
		//	        i++;
		//       }
		//	    data1 += (double) (random(50)/(double)10000.0);
		//   }
		//   return data1;
		//}


		//*********************************************
		//---CODE BY MANEGSH 
		//*********************************************
		AbsConc[] abs1 = {
			new AbsConc(0.142, 20.0),
			new AbsConc(0.265, 40.0),
			new AbsConc(0.378, 60.0),
			new AbsConc(0.426, 80.0),
			new AbsConc(0.562, 100.0),
			new AbsConc(0.682, 1.0),
			new AbsConc(0.725, 2.0),
			new AbsConc(0.825, 3.0),
			new AbsConc(0.805, 4.0),
			new AbsConc(0.972, 5.0),
			new AbsConc(0, 0)
		};


		double data1 = data;
		double conc = 0.0;
		int i;
		Random objRandom = new Random();
		try {
			if (SampType == enumSampleType.STANDARD) {
				if (!IsNothing(CurStd)) {
					conc = CurStd.Concentration;
					i = 0;
					while ((abs1(i).ABS != 0.0 & abs1(i).CONC != 0.0)) {
						if ((conc == abs1(i).CONC)) {
							data1 = abs1(i).ABS;
							break; // TODO: might not be correct. Was : Exit While
						}
						i += 1;
					}
					data1 += (objRandom.Next(50) / 1000.0);
				}

			} else if (SampType == enumSampleType.BLANK) {
				data1 = 0.0;

			} else if (SampType == enumSampleType.SAMPLE) {
				if (!IsNothing(CurSample)) {
					conc = CurSample.Conc;
					i = 0;
					while ((abs1(i).ABS != 0.0 & abs1(i).CONC != 0.0)) {
						if ((conc == abs1(i).CONC)) {
							data1 = abs1(i).ABS;
							break; // TODO: might not be correct. Was : Exit While
						}
						i += 1;
					}
					data1 += (objRandom.Next(50) / 1000.0);
				}

			}

			return data1;
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
			objRandom = null;
		}
	}

	public double CheckForMinAbsLevel(double ABSTP)
	{

		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   CheckForMinAbsLevel
		//Description            :   for checking min abs level
		//Parameters             :   None
		//Time/Date              :   
		//Dependencies           :   
		//Author                 :   
		//Revision               :
		//Revision by Person     :
		//-----------------------------------------------
		////----mdf by sk on 24/5/2001 for locking min detect level of abs
		//double CheckForMinAbsLevel(double abstp)
		//{
		// /*
		//  this func checks if abs is less than 0.008(by default) then it is locked to 0
		//  since our minimum detection of absorbance is 0.005
		//  and it can change with respect to parameters and lamp.
		// */

		//	if(abstp < absthldval) // 0.008 mdf by sk on 3/6/2001
		//	  return 0.0;
		//        Else
		//	  return abstp;
		//}


		//**************************************************
		//---CODE BY MANGESH 
		//**************************************************
		//---for locking min detect level of abs
		//  this func checks if abs is less than 0.008(by default) then it is locked to 0
		//  since our minimum detection of absorbance is 0.005
		//  and it can change with respect to parameters and lamp.

		if ((ABSTP < gstructSettings.AbsThresholdValue)) {
			return 0.0;
		} else {
			return ABSTP;
		}


	}

	////----- Added by Sachin Dokhale
	////----- Fuel control function

	public bool funcIncr_Fuel()
	{
		//=====================================================================
		// Procedure Name        : funcIncr_Fuel
		// Parameters Passed     : None
		// Returns               : Boolean
		// Purpose               : Increase the Fuel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		double dblSWidth;

		try {
			funcIncr_Fuel = false;

			if (gobjCommProtocol.funcGet_NV_Pos == true) {
				if (gobjInst.NvStep >= NVSTEP) {
					gobjCommProtocol.funcNV_RotateClock_Steps(NVSTEP);
				}
				gobjCommProtocol.funcGet_NV_Pos();
				funcIncr_Fuel = true;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool funcDecr_Fuel()
	{
		//=====================================================================
		// Procedure Name        : funcDecr_Fuel
		// Parameters Passed     : None
		// Returns               : Boolean
		// Purpose               : Decrease the Fuel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================

		int Indr_Idx;
		try {
			////=------ Original Func

			//void	S4FUNC Decr_Fuel()
			//{
			//int k;
			// Get_NV_Pos();
			//// if (Inst.Aaf|| Inst.N2of) {
			//            If (Inst.Nvstep <= (NVRED * MAXNVHOME - NVSTEP)) Then
			//	  for (k=1; k<=NVSTEP; k++){
			//		if (!Flame_Present(FALSE)) {
			//			NV_RotateClock();
			//			pc_delay(200);
			//			break;
			//		  }
			//		NV_RotateAnticlock();
			//	}
			//#If DEMO Then
			//	 NVpos+=NVSTEP;
			//#End If
			//// }
			// Get_NV_Pos();
			//}
			////------
			funcDecr_Fuel = false;
			if (gobjCommProtocol.funcGet_NV_Pos == true) {
				if (gobjInst.NvStep <= (NVRED * MAXNVHOME - NVSTEP)) {
					for (Indr_Idx = 1; Indr_Idx <= NVSTEP; Indr_Idx++) {
						if (gobjClsAAS203.funcFlame_Present(false) == false) {
							if (gobjCommProtocol.funcNV_Rotate_Clock() == false) {
								//'for roating NV in clock wise
								//    'PC Delay(200) '2MS
								break; // TODO: might not be correct. Was : Exit For
							}
							break; // TODO: might not be correct. Was : Exit For
						}
						gobjCommProtocol.funcNV_Rotate_AntiClock();
						//BY Pankaj bamb on 22 Jan 08
					}
					//Call gobjCommProtocol.funcNV_Rotate_AntiClock()'commented BY Pankaj bamb on 22 Jan 08
				}
				gobjCommProtocol.funcGet_NV_Pos();
				//'for getting NV position
				funcDecr_Fuel = true;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public bool funcFlame_Present(bool blnFlag_Flame_Present)
	{
		//=====================================================================
		// Procedure Name        : funcFlame_Present
		// Parameters Passed     : blnFlag_Flame_Present
		// Returns               : Boolean
		// Purpose               : Set the status of Flame presence
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		byte bytPS;
		bool blnFlagFlamePresent = false;
		try {
			//blnFlag_Flame_Present = False
			////---------------
			//BYTE st;
			// if (Inst.Aaf || Inst.N2of) {
			//	st = CHECK_PS();
			//	if ((st&FLAME_OK) ==FLAME_OK)
			//		return TRUE;
			//                Else
			//		return FALSE;
			//  }
			// else {
			//                    If (flag1) Then
			//	  return TRUE;
			//                    Else
			//	  return FALSE;
			//	}
			////--------------

			if ((gobjInst.Aaf == true) | (gobjInst.N2of == true)) {
				//bytPS = funcCHECK_PS()
				if (gobjCommProtocol.funcPressSensorStatus(bytPS) == true) {
					if (((bytPS & CONST_FLAME_OK) == CONST_FLAME_OK)) {
						blnFlagFlamePresent = true;
					} else {
						blnFlagFlamePresent = false;
					}
				}
			} else {
				if (blnFlag_Flame_Present == true) {
					blnFlagFlamePresent = true;
				} else {
					blnFlagFlamePresent = false;
				}
			}

			return blnFlagFlamePresent;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	public double funcGet_Fuel_Ratio(bool blnFlag_Fuel)
	{
		//=====================================================================
		// Procedure Name        : funcGet_Fuel_Ratio
		// Parameters Passed     : blnFlag_Flame_Present
		// Returns               : Boolean
		// Purpose               : Get the Ratio  of Fuel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		byte bytPS;
		try {
			if (blnFlag_Fuel == true) {
				return funcRead_Fuel();
			} else {
				if (funcFlame_Present(true)) {
					return funcRead_Fuel();
				}
				return 0.0;
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return -1.0;
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

	public double funcRead_Fuel()
	{
		//=====================================================================
		// Procedure Name        : funcRead_Fuel
		// Parameters Passed     : 
		// Returns               : Double
		// Purpose               : Read fuel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 25.11.06
		// Revisions             : 
		//=====================================================================
		double dblFuel;
		long lngFuel;

		try {
			dblFuel = 0.0;
			if (gobjCommProtocol.funcGet_NV_Pos == true) {
				dblFuel = funcConvertToFuel(gobjInst.NvStep);
			}
			////----- Fuel Ratio is required 2 decimal point 
			lngFuel = dblFuel * 100;
			dblFuel = lngFuel / 100;
			////-----
			return dblFuel;

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

	public double funcRead_Fuel_Ratio()
	{
		//=====================================================================
		// Procedure Name        : funcRead_Fuel
		// Parameters Passed     : 
		// Returns               : Double
		// Purpose               : Read fuel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 16.12.06
		// Revisions             : 
		//=====================================================================
		double dblFuel;
		long lngFuel;

		try {
			dblFuel = 0.0;
			//If gobjCommProtocol.funcGet_NV_Pos = True Then
			dblFuel = funcConvertToFuel(gobjInst.NvStep);
			//End If
			////----- Fuel Ratio is required 2 decimal point 
			lngFuel = dblFuel * 100;
			dblFuel = lngFuel / 100;
			////-----

			if (dblFuel < 0.0) {
				//'setting some validation
				dblFuel = 0.0;
			} else {
				dblFuel = Format(dblFuel, "#0.00");
			}

			return dblFuel;

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

	//Public Function funcOptimise_Fuel_Auto(ByRef AASGraphs As AASGraph) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   funcOptimise_Fuel_Auto
	//    ' Description           :   Optimese  the auto fuel
	//    ' Purpose               :   
	//    '                           
	//    ' Parameters Passed     :   None
	//    ' Returns               :   True
	//    ' Parameters Affected   :   
	//    ' Assumptions           :   
	//    ' Dependencies          :   None.
	//    ' Author                :   Sachin Dokhale 
	//    ' Created               :   25.12.06
	//    ' Revisions             :
	//    '=====================================================================

	//    '        BOOL	  Optimise_Fuel_Auto(HWND hpar)
	//    '//void	Lamp_optimize(boolean oflag)
	//    '{
	//    'double	txmin=0.0, txmax=0.0;
	//    'double   abs=0.0, max_abs= 0;
	//    'double	xfuel=0;
	//    'int		xval=0, max_fuel=0, xvalmax, xvalmin, adval;
	//    'BOOL		pflag=FALSE;
	//    'int 		i;
	//    'HWND		hwnd;
	//    'HDC		hdc;
	//    'char     line1[80]="";
	//    'unsigned	tout;
	//    'int		lMode;
	//    'int		txold, tyold;

	//    '  if (GetInstrument()==AA202)
	//    '	return TRUE;
	//    '            If (!Flame_Present(False)) Then
	//    '	return FALSE;
	//    '                If (!ReadAndSetFuelScanConditions(hpar)) Then
	//    '	return FALSE;
	//    '                    If (!CheckNvPos()) Then
	//    '	return FALSE;
	//    ' GetXoldYold(&txold, &tyold);
	//    ' txmin= PeakGraph.Xmin;
	//    ' txmax	= PeakGraph.Xmax;
	//    ' Blink_MessageBox(hpar,"Aspirate Max. Standard and Click OK","Fuel optimisation", 0);
	//    '// MessageBox(hpar, "Aspirate Max. Standard and Click OK","Fuel optimisation", MB_OK);
	//    ' hwnd= CreateWindowPeak(hpar, " FUEL OPTIMISATION ","SKCK2",0 );
	//    ' if (hwnd ){
	//    '	PeakGraph.Xmax=txmin ;
	//    '	PeakGraph.Xmin= txmax;
	//    '	PeakGraph.Ymin= 0.0;//GetEnergy(2047);
	//    '	PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
	//    '	SetInstrumentCondns(hwnd, TRUE);
	//    '	xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
	//    '	abs = ConvertToFuel(xvalmax) ;
	//    '	xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
	//    '	abs = ConvertToFuel(xvalmin) ;
	//    '	i= (int )  ((xvalmax-xvalmin)/NVSCANSTEP);
	//    '	i = abs(i);
	//    '	strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Fuel ratio");
	//    '	Show_Peak_Param(hwnd, i);
	//    '	PeakGraph.Xmax=txmin ;
	//    '	PeakGraph.Xmin= txmax;
	//    '	SetFocus(hwnd);
	//    '	hdc= GetDC(hwnd);
	//    '	SetBkColor(hdc, RGB(192, 192, 192));
	//    '	SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");
	//    '	strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
	//    '	SetText(hwnd, IDC_STATUS1,line1);
	//    '	SetFuel(PeakGraph.Xmax);
	//    '	strcpy(line1,"");
	//    '	lMode=Inst->Mode;
	//    '	Cal_Mode(AA);
	//    '	SetScanning(TRUE);
	//    '	sprintf(line1, " Fuel Optimisation");
	//    '	SetText(hwnd, IDC_STATUS1,line1);
	//    '	SetText(hwnd, IDC_STATUS,"");
	//    '	Transmit(NVSCAN, (BYTE)(xvalmin), (BYTE) (xvalmin>>8), (BYTE) NVSCANSTEP);
	//    '	xval= xvalmax;
	//    '	i=1;
	//    '	tout = GetTimeOut();
	//    '	SetTimeOut(VERY_LONG_DEALY);
	//    '	while(1){
	//    '                                If (Recev(False)) Then
	//    '		adval= GetParam2()*256 + GetParam1();
	//    '                                Else
	//    '		break;
	//    '                                    If (adval >= 6000) Then
	//    '		break;
	//    '#If QDEMO Then
	//    '	  adval = 2100+random(20);
	//    '#End If
	//    '	  abs = GetADConvertedToCurMode(adval);
	//    '	  if (abs > max_abs)    {
	//    '		 max_abs=abs;
	//    '		 max_fuel=xval;
	//    '		 pflag=TRUE;
	//    '		}
	//    '	  xfuel=ConvertToFuel(xval);
	//    '	  sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",xfuel, abs, xval, xvalmin, xvalmax);
	//    '	  SetText(hwnd, IDC_STATUS,line1);
	//    '	  if (i==1)
	//    '		 GPlotInit(hdc, xfuel, abs);
	//    '                                            Else
	//    '		 GPlot(hdc,xfuel, abs);
	//    '	  xval+=NVSCANSTEP;
	//    '/*	  if (xval> xvalmin)
	//    '		 break;*/
	//    '	  i++;
	//    '		if (!Transmit(PC_END, (BYTE)0, (BYTE) 0, (BYTE) 0))
	//    '			break;
	//    '	 }
	//    '	SetTimeOut(tout);
	//    '	if (pflag){
	//    '	  sprintf(line1,"Optimised at (%4.2f, %4.3f)",ConvertToFuel(max_fuel),  max_abs);
	//    '	  SetText(hwnd, IDC_STATUS1,line1);
	//    '#If QDEMO Then
	//    '		Get_NV_Pos();
	//    '#End If
	//    '	  GShowPeak(hdc,ConvertToFuel(max_fuel),  max_abs, NULL);
	//    '	  strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
	//    '	  SetText(hwnd, IDC_STATUS,line1);
	//    '#If EMU Then
	//    ' Wait_For_Some_Msg(5);
	//    '#End If
	//    '	  SetFuel(ConvertToFuel(max_fuel));
	//    '	  }
	//    '	Cal_Mode(lMode);
	//    '	ReleaseDC(hwnd, hdc);
	//    '	DestroyWindowPeak(hwnd,hpar);
	//    '  }
	//    ' pc_delay(1500);
	//    ' SetScanning(FALSE);
	//    ' SetXoldYold(txold, tyold);
	//    ' return TRUE;
	//    '}
	//    Dim txmin As Double = 0.0
	//    Dim txmax As Double = 0.0
	//    Dim abs As Double = 0.0
	//    Dim max_abs As Double = 0.0
	//    Dim xfuel As Double = 0.0
	//    Dim xval As Integer = 0
	//    Dim max_fuel As Integer = 0
	//    Dim xvalmax, xvalmin, adval As Integer
	//    Dim pflag As Boolean = False
	//    Dim i As Integer

	//    Dim line1 As String
	//    'unsigned	tout;
	//    Dim tout As Integer
	//    Dim intlMode As Integer
	//    Dim inttxold, inttyold As Integer
	//    Try
	//        'if (GetInstrument()=AA202) then
	//        'return TRUE
	//        'If (!Flame_Present(False)) Then
	//        'return FALSE;
	//        '           If (!ReadAndSetFuelScanConditions(hpar)) Then
	//        'return FALSE;
	//        '               If (!CheckNvPos()) Then
	//        'return FALSE;
	//        If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
	//            Return True
	//        End If

	//        If Not (gobjClsAAS203.funcFlame_Present(False)) Then
	//            Return False
	//        End If
	//        'If Not (funcReadAndSetFuelScanConditions()) Then
	//        '    Return False
	//        'End If
	//        If (Not funcCheckNvPos()) Then
	//            Return False
	//        End If

	//        'GetXoldYold(&txold, &tyold);
	//        subGetXoldYold(inttxold, inttyold)
	//        Dim dblGraphXmin, dblGraphXMax As Double
	//        Dim blnFuelOptim As Boolean
	//        blnFuelOptim = gobjMessageAdapter.ShowMessage("Aspirate Max. Standard and Click OK", "Fuel optimisation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)

	//        'PeakGraph.Xmax=txmin ;
	//        'PeakGraph.Xmin= txmax;
	//        'PeakGraph.Ymin= 0.0;//GetEnergy(2047);
	//        'PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
	//        'mobjParameters.XaxisMax = txmax
	//        'mobjParameters.XaxisMin = txmin
	//        'mobjParameters.YaxisMax = 0.0
	//        'mobjParameters.YaxisMin = 1
	//        AASGraphs.XAxisMax = txmax
	//        AASGraphs.XAxisMin = txmin
	//        AASGraphs.YAxisMax = 0.0
	//        AASGraphs.YAxisMin = 1.0
	//        AASGraphs.Refresh()


	//        'SetInstrumentCondns(hwnd, TRUE);
	//        'xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
	//        'abs = ConvertToFuel(xvalmax) ;
	//        'xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
	//        'abs = ConvertToFuel(xvalmin) ;

	//        Call gobjClsAAS203.funcSetInstrumentCondns(True)


	//        'xvalmax = funcConvertToNvPos(mobjParameters.XaxisMin)
	//        xvalmax = funcConvertToNvPos(AASGraphs.XAxisMin)

	//        abs = funcConvertToFuel(xvalmax)
	//        'xvalmin = funcConvertToNvPos(mobjParameters.XaxisMax)
	//        xvalmin = funcConvertToNvPos(AASGraphs.XAxisMax)
	//        abs = funcConvertToFuel(xvalmin)

	//        'i= (int )  ((xvalmax-xvalmin)/NVSCANSTEP);
	//        'i = abs(i)
	//        i = ((xvalmax - xvalmin) / CONST_NVSCANSTEP)
	//        i = Math.Abs(i)

	//        'strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Fuel ratio");
	//        'Show_Peak_Param(hwnd, i);
	//        'PeakGraph.Xmax=txmin ;
	//        'PeakGraph.Xmin= txmax;
	//        AASGraphs.XAxisMax = txmax
	//        AASGraphs.XAxisMin = txmin

	//        'SetFocus(hwnd);
	//        'hdc= GetDC(hwnd);
	//        'SetBkColor(hdc, RGB(192, 192, 192));
	//        'SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");

	//        'strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
	//        'SetText(hwnd, IDC_STATUS1,line1);
	//        gobjMessageAdapter.ShowStatusMessageBox("Setting Fuel from " & funcConvertToFuel(gobjInst.NvStep) & " to " & txmax, "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
	//        'SetFuel(PeakGraph.Xmax);
	//        '//----- Set here Fuel to auto
	//        'Call funcSetFuelParameter(dblXmax)
	//        '//-----

	//        Dim lMode As Integer
	//        'strcpy(line1,"");
	//        lMode = gobjInst.Mode
	//        'Cal_Mode(AA);
	//        gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA)

	//        'SetScanning(TRUE);
	//        'sprintf(line1, " Fuel Optimisation");
	//        'SetText(hwnd, IDC_STATUS1,line1);
	//        'SetText(hwnd, IDC_STATUS,"");
	//        gobjMessageAdapter.CloseStatusMessageBox()
	//        gobjMessageAdapter.ShowStatusMessageBox("Fuel Optimisation", "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
	//        Call gobjCommProtocol.funcNVScanSteps(xvalmin)
	//        xval = xvalmax
	//        i = 1
	//        'tout = GetTimeOut();
	//        'SetTimeOut(VERY_LONG_DEALY);
	//        Do While (True)
	//            'If (Recev(False)) Then
	//            '		adval= GetParam2()*256 + GetParam1();
	//            '                Else
	//            '		break;
	//            '                    If (adval >= 6000) Then
	//            '		break;
	//            '#If QDEMO Then
	//            '	  adval = 2100+random(20);
	//            '#End If
	//            If gobjCommProtocol.funcReceive_ScanData(0, adval) = True Then
	//                'adval = GetParam2() * 256 + GetParam1()
	//                'Else


	//                If (adval >= 6000) Then
	//                    Exit Do
	//                End If

	//                '//----- For Demo Mode
	//                '#If QDEMO Then
	//                '	  adval = 2100+random(20);
	//                '#End If
	//                If gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//                    adval = 2100 + gRandom.Next(20)
	//                End If
	//                'abs = GetADConvertedToCurMode(adval);
	//                abs = gFuncGetADConvertedToCurMode(adval)
	//                '                  if (abs > max_abs)    {
	//                ' max_abs=abs;
	//                ' max_fuel=xval;
	//                ' pflag=TRUE;
	//                '}
	//                If (abs > max_abs) Then
	//                    max_abs = abs
	//                    max_fuel = xval
	//                    pflag = True
	//                End If
	//                'xfuel=ConvertToFuel(xval);
	//                xfuel = funcConvertToFuel(xval)
	//                'sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",xfuel, abs, xval, xvalmin, xvalmax);
	//                'SetText(hwnd, IDC_STATUS,line1);
	//                gobjMessageAdapter.ShowStatusMessageBox(xfuel.ToString & " " & abs.ToString & " " & xval.ToString & " " & xvalmin.ToString & " " & xvalmax.ToString, " ", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
	//                '//----- Plot graph 
	//                '                 if (i==1)
	//                'GPlotInit(hdc, xfuel, abs);
	//                '                 Else
	//                'GPlot(hdc,xfuel, abs);
	//                xval += CONST_NVSCANSTEP
	//                'i++;
	//                i += 1
	//                'if (!Transmit(PC_END, (BYTE)0, (BYTE) 0, (BYTE) 0))
	//                '	break;

	//                If gobjCommProtocol.funcPC_END Then
	//                    Exit Do
	//                End If

	//            Else
	//                Exit Do
	//            End If
	//        Loop
	//        'SetTimeOut(tout);
	//        'if (pflag){
	//        'sprintf(line1,"Optimised at (%4.2f, %4.3f)",ConvertToFuel(max_fuel),  max_abs);

	//        gobjMessageAdapter.CloseStatusMessageBox()
	//        gobjMessageAdapter.ShowStatusMessageBox("Optimised at " & funcConvertToFuel(max_fuel).ToString & " " & max_abs.ToString, "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
	//        '#If QDEMO Then
	//        '		Get_NV_Pos();
	//        '#End If
	//        If gstructSettings.AppMode = EnumAppMode.DemoMode Then
	//            Call gobjCommProtocol.funcGet_NV_Pos()
	//        End If

	//        '//----- Show the peak on graph
	//        'GShowPeak(hdc,ConvertToFuel(max_fuel),  max_abs, NULL);
	//        '//-----

	//        'strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
	//        'SetText(hwnd, IDC_STATUS,line1);
	//        gobjMessageAdapter.CloseStatusMessageBox()
	//        gobjMessageAdapter.ShowStatusMessageBox(" Positioning to Optimised Position ...", "", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
	//        '#If EMU Then
	//        ' Wait_For_Some_Msg(5);
	//        '#End If
	//        'SetFuel(ConvertToFuel(max_fuel));
	//        funcSetFuel(funcConvertToFuel(max_fuel))
	//        'Cal_Mode(lMode);
	//        gobjCommProtocol.funcCalibrationMode(lMode)

	//        'pc_delay(1500);
	//        ' SetScanning(FALSE);
	//        ' SetXoldYold(txold, tyold);
	//        Call gobjCommProtocol.mobjCommdll.subTime_Delay(15)
	//        Call subSetXoldYold(inttxold, inttyold)
	//        Call gobjMessageAdapter.CloseStatusMessageBox()
	//        Return True
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
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

	public bool funcCheckNvPos()
	{
		//=====================================================================
		// Procedure Name        : funcCheckNvPos
		// Parameters Passed     : To check the NV Position
		// Returns               : True/False
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.012.06
		// Revisions             : 
		//=====================================================================

		try {
			//        BOOL	S4FUNC CheckNvPos()
			//{
			// Get_NV_Pos();
			//            If (Inst.Nvstep < 0) Then
			//	NV_HOME();
			//                If (Inst.Nvstep < 0) Then
			//	return FALSE;
			// return TRUE;
			//}    

			gobjCommProtocol.funcGet_NV_Pos();
			//'serial communication function for getting NV position
			if ((gobjInst.NvStep < 0)) {
				gobjCommProtocol.funcSetNV_HOME();
				//'set NV to home 
			}
			if ((gobjInst.NvStep < 0)) {
				return false;
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

	public int funcConvertToNvPos(double dblFuel)
	{
		//=====================================================================
		// Procedure Name        : funcConvertToNvPos
		// Parameters Passed     : dblfuel
		// Returns               : True/False
		// Purpose               : To convert to fuel to NV Position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================
		double dblNVS;
		int intNVSteps;
		try {
			//int	S4FUNC	ConvertToNvPos(double fuel)
			//{
			//double nvs;
			//int	nvsteps;

			//            If (Burner_Type()) Then
			//	 nvs = (double) MAXNVHOME+(double)0.1561 - fuel*(double)0.6733;
			//	else                    
			//	nvs = (double) MAXNVHOME  +(double)0.1732 - fuel*(double)0.7232;
			//  nvsteps= (int) ((double) NVRED *nvs);
			// return nvsteps;
			//}
			if (gobjClsAAS203.funcBurner_Type() == true) {
				//	 nvs = (double) MAXNVHOME+(double)0.1561 - fuel*(double)0.6733;
				dblNVS = MAXNVHOME + 0.1561 - (dblFuel * 0.6733);
			////	 fuel = (fuel+(double)0.1561)/(double)0.6733;
			//// 50 mm Burner
			} else {
				//nvs = (double) MAXNVHOME  +(double)0.1732 - fuel*(double)0.7232;
				dblNVS = MAXNVHOME + 0.1732 - (dblFuel * 0.7232);
			}
			////	  fuel = (fuel+(double)0.1732)/(double)0.7232;
			intNVSteps = (int)(double)NVRED * dblNVS;
			return intNVSteps;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
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

	public double funcConvertToFuel(int intNVSteps)
	{
		//=====================================================================
		// Procedure Name        : funcConvertToFuel
		// Parameters Passed     : intNVSteps
		// Returns               : 
		// Purpose               : to convert NV step in to a Fuel.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 08.11.06
		// Revisions             : 
		//=====================================================================
		double dblFuel = 0.0;
		try {
			//double  S4FUNC ConvertToFuel(int nvsteps)
			//{
			//double fuel = (double)0.0;

			//            If (nvsteps < 0) Then
			//	return 0.0;
			//  fuel = (double) MAXNVHOME*(double)1.0-((double)nvsteps/(double)(NVRED));
			//                If (Burner_Type()) Then
			//	 fuel = (fuel+(double)0.1561)/(double)0.6733;
			//	else                    // 50 mm Burner
			//	  fuel = (fuel+(double)0.1732)/(double)0.7232;
			// return fuel;
			//}
			if ((intNVSteps < 0)) {
				return 0.0;
			}
			dblFuel = MAXNVHOME * 1.0 - (intNVSteps / (NVRED));
			if ((gobjClsAAS203.funcBurner_Type)) {
				dblFuel = (dblFuel + 0.1561) / 0.6733;
			//// 50 mm Burner
			} else {
				dblFuel = (dblFuel + 0.1732) / 0.7232;
			}
			return dblFuel;
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcSetFuel_old(double dblFuel)
	{
		//=====================================================================
		// Procedure Name        : funcSetFuel
		// Parameters Passed     : fuel to be set.
		// Returns               : True/False
		// Purpose               : for setting fuel.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================
		int intk;
		int intNVStep;
		try {
			//            void		S4FUNC	SetFuel(double fuel)
			//{  //0
			//int	k;
			//int	nvstep =ConvertToNvPos(fuel);
			// Get_NV_Pos();
			//if (Inst.Nvstep>nvstep){  //1
			//	 nvstep=Inst.Nvstep-nvstep;
			//	 NV_RotateClock_Steps(nvstep);
			//	} //1
			// else if (Inst.Nvstep<nvstep) {  //2
			//if (nvstep<=(NVRED*MAXNVHOME))
			//	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
			//		 if ( !Flame_Present(FALSE)) {  //4
			//			NV_RotateClock();
			//			pc_delay(200);
			//			break;
			//		  } //4
			//		NV_RotateAnticlock();
			//#If QDEMO Then
			//	 Get_NV_Pos();
			//#End If
			//	  } //3
			//	if (k==nvstep+2)
			//	  for (k=0; k<2; k++){ //5
			//		 NV_RotateClock();
			//			pc_delay(200);
			//	  } //5
			//  } //2
			// Get_NV_Pos();
			//} //0
			//-------------------------------------------------------

			intNVStep = funcConvertToNvPos(dblFuel);

			gobjCommProtocol.funcGet_NV_Pos();
			if ((gobjInst.NvStep > intNVStep)) {
				if (intNVStep >= 0) {
					intNVStep = gobjInst.NvStep - intNVStep;
					gobjCommProtocol.funcNV_RotateClock_Steps(intNVStep);
				}

			//'2
			} else if ((gobjInst.NvStep < intNVStep)) {
				//if (nvstep<=(NVRED*MAXNVHOME))
				//	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
				//		 if ( !Flame_Present(FALSE)) {  //4
				//			NV_RotateClock();
				//			pc_delay(200);
				//			break;
				//		  } //4
				//		NV_RotateAnticlock();
				//#If QDEMO Then
				//	 Get_NV_Pos();
				//#End If
				//	  } //3

				//---02.09.07
				if ((intNVStep <= (NVRED * MAXNVHOME))) {
					//For intk = gobjInst.NvStep To intNVStep + 2
					//---02.09.07
					for (intk = gobjInst.NvStep; intk <= intNVStep + 1; intk++) {
						if (!(gobjClsAAS203.funcFlame_Present(false))) {
							if (!gobjInst.NvStep == 0) {
								//gobjCommProtocol.funcNV_Rotate_Clock()
								gobjCommProtocol.funcGet_NV_Pos();
								break; // TODO: might not be correct. Was : Exit For
							} else {
								gobjCommProtocol.funcGet_NV_Pos();
								break; // TODO: might not be correct. Was : Exit For
							}

							//gobjCommProtocol.mobjCommdll.subTime_Delay(50)
							//break;
							//Exit For
						}
						gobjCommProtocol.funcNV_Rotate_AntiClock();
						//#If QDEMO Then
						//	 Get_NV_Pos()
						//#End If
						if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
							gobjCommProtocol.funcGet_NV_Pos();
						}
					}
				}
				if ((intk == intNVStep + 2)) {
					//For intk = 0 To 2
					for (intk = 0; intk <= 1; intk++) {
						gobjCommProtocol.funcNV_Rotate_Clock();
						//gobjCommProtocol.mobjCommdll.subTime_Delay(20)
					}
				}
			}
			gobjCommProtocol.funcGet_NV_Pos();
			////----- Added by Sachin Dokhale on 04.07.07
			gobjCommProtocol.funcSave_NV_Pos();
			////-----
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

	public bool funcLoadLastOptimizedConditions(bool Is_AA_Flame)
	{
		//=====================================================================
		// Procedure Name        : funcLoadLastOptimizedConditions
		// Parameters Passed     : None
		// Returns               : True/False
		// Purpose               : to read and implement last optimized conditions
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 29.04.10
		// Revisions             : 
		//=====================================================================    
		int intBHSteps;
		int intCount;
		int intNvs;
		int intPresentElementAtomicNumber;
		try {
			intPresentElementAtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber;

			if (!gobjFuelDataCollection == null) {
				for (intCount = 0; intCount <= gobjFuelDataCollection.Count - 1; intCount++) {
					if (gobjFuelDataCollection.item(intCount).AtomicNumber == intPresentElementAtomicNumber) {
						//---set burner height 
						intBHSteps = gobjFuelDataCollection.item(intCount).BurnerHeight;
						if (!intBHSteps == -1) {
							if (intBHSteps <= 0 | intBHSteps > MAXBHHOME) {
								if (gobjCommProtocol.funcSetBH_HOME() == false) {
									return false;
								}
							} else {
								if (intBHSteps > 0 | intBHSteps <= MAXBHHOME) {
									if (gobjCommProtocol.func_SetLastBhPos(intBHSteps) == false) {
										return false;
									}
								}
							}
						}
						//---set fuel ratio
						intNvs = gobjFuelDataCollection.item(intCount).NVStep;
						gobjCommProtocol.mobjCommdll.subTime_Delay(50);

						if (Is_AA_Flame) {
							if (gobjCommProtocol.funcSet_Last_Fuel(intNvs) == false) {
								return false;
							}
						} else {
							//if nvs<3.0*NVRED then
							if (gobjCommProtocol.funcSet_Last_Fuel(intNvs) == false) {
								return false;
							}
						}

						//If intNvs < (3.5 * NVRED) And intNvs > NVRED Then                        
						//End If

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

	public bool funcCheckPresenceOfLastFuelConditions()
	{
		//=====================================================================
		// Procedure Name        : funcCheckPresenceOfLastFuelConditions
		// Parameters Passed     : None
		// Returns               : True/False
		// Purpose               : to check the presence of last optimized conditions
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 29.04.10
		// Revisions             : 
		//=====================================================================
		clsFuelData objFuelData;
		int intCount;
		int intPresentElementAtomicNumber;
		BinaryFormatter Formatter;
		Stream stream;
		string strPath = "";
		try {
			intPresentElementAtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber;

			if (!gobjFuelDataCollection == null) {
				for (intCount = 0; intCount <= gobjFuelDataCollection.Count - 1; intCount++) {
					if (gobjFuelDataCollection.item(intCount).AtomicNumber == intPresentElementAtomicNumber) {
						return true;
					}
				}
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

	public bool funcSave_Fuel_Conditions()
	{
		//=====================================================================
		// Procedure Name        : funcSave_Fuel_Conditions
		// Parameters Passed     : None
		// Returns               : True/False
		// Purpose               : to save fuel conditions in file
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 29.04.10
		// Revisions             : 
		//=====================================================================
		clsFuelData objFuelData;
		int intCount;
		int intPresentElementAtomicNumber;
		BinaryFormatter Formatter;
		Stream stream;
		string strPath = "";
		bool blnIsAddNew = true;

		try {
			int intIgniteType;
			//---25.08.11
			ClsAAS203.enumIgniteType intIgnite_Test;
			if (gobjClsAAS203.funcIgnite_Test(intIgnite_Test)) {
				intIgniteType = intIgnite_Test;
			}
			//-----


			if (intIgniteType == enumIgniteType.Blue | intIgniteType == enumIgniteType.Yellow) {
				intPresentElementAtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber;

				if (!gobjFuelDataCollection == null) {
					if (gobjFuelDataCollection.Count > 0) {
						for (intCount = 0; intCount <= gobjFuelDataCollection.Count - 1; intCount++) {
							if (gobjFuelDataCollection.item(intCount).AtomicNumber == intPresentElementAtomicNumber) {
								blnIsAddNew = false;
								gobjFuelDataCollection.item(intCount).ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber;
								//gobjInst.ElementName
								gobjFuelDataCollection.item(intCount).BurnerHeight = gobjInst.BhStep;
								gobjFuelDataCollection.item(intCount).NVStep = gobjInst.NvStep;
								gobjFuelDataCollection.item(intCount).IsAAFlame = gobjInst.Aaf;
							}
						}
					}

					if (blnIsAddNew) {
						objFuelData = new clsFuelData();
						objFuelData.AtomicNumber = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).AtomicNumber;
						objFuelData.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName;
						//gobjInst.ElementName
						objFuelData.BurnerHeight = gobjInst.BhStep;
						objFuelData.NVStep = gobjInst.NvStep;
						objFuelData.IsAAFlame = gobjInst.Aaf;
						gobjFuelDataCollection.Add(objFuelData);
					}
				}

				Formatter = new BinaryFormatter();
				stream = new FileStream(CONST_FUEL_CONDITIONS_FILE, FileMode.Create, FileAccess.ReadWrite, FileShare.None);

				Formatter.Serialize(stream, gobjFuelDataCollection);
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

	public bool funcLoad_Fuel_Conditions()
	{
		//=====================================================================
		// Procedure Name        : funcLoad_Fuel_Conditions
		// Parameters Passed     : None
		// Returns               : True/False
		// Purpose               : to load the fuel conditions in object from file
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 29.04.10
		// Revisions             : 
		//=====================================================================
		BinaryFormatter Formatter;
		FileStream fs;
		File fileLastOpt;
		try {
			if ((fileLastOpt.Exists(Application.StartupPath + "\\" + CONST_FUEL_CONDITIONS_FILE))) {
				fs = new FileStream(CONST_FUEL_CONDITIONS_FILE, FileMode.Open);

				if (IsNothing(fs)) {
					return false;
				} else {
					if (fs.Length <= 0) {
						return false;
					}
				}

				Formatter = new BinaryFormatter();
				gobjFuelDataCollection = Formatter.Deserialize(fs);

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


	public bool funcSetFuel(double dblFuel)
	{
		//=====================================================================
		// Procedure Name        : funcSetFuel
		// Parameters Passed     : fuel to be set
		// Returns               : True/False
		// Purpose               : for setting fuel.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 02.09.07
		//=====================================================================
		int intk;
		int intNVStep;
		try {
			//            void		S4FUNC	SetFuel(double fuel)
			//{  //0
			//int	k;
			//int	nvstep =ConvertToNvPos(fuel);
			// Get_NV_Pos();
			//if (Inst.Nvstep>nvstep){  //1
			//	 nvstep=Inst.Nvstep-nvstep;
			//	 NV_RotateClock_Steps(nvstep);
			//	} //1
			// else if (Inst.Nvstep<nvstep) {  //2
			//if (nvstep<=(NVRED*MAXNVHOME))
			//	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
			//		 if ( !Flame_Present(FALSE)) {  //4
			//			NV_RotateClock();
			//			pc_delay(200);
			//			break;
			//		  } //4
			//		NV_RotateAnticlock();
			//#If QDEMO Then
			//	 Get_NV_Pos();
			//#End If
			//	  } //3
			//	if (k==nvstep+2)
			//	  for (k=0; k<2; k++){ //5
			//		 NV_RotateClock();
			//			pc_delay(200);
			//	  } //5
			//  } //2
			// Get_NV_Pos();
			//} //0
			//-------------------------------------------------------
			if (gobjInst.Aaf == true | gobjInst.N2of == true) {
				intNVStep = funcConvertToNvPos(dblFuel);
				//'convert fuel in to a NV step.
				gobjCommProtocol.funcGet_NV_Pos();
				if ((gobjInst.NvStep > intNVStep)) {
					if (intNVStep >= 0) {
						intNVStep = gobjInst.NvStep - intNVStep;
						gobjCommProtocol.funcNV_RotateClock_Steps(intNVStep);
					}

				//'2
				} else if ((gobjInst.NvStep < intNVStep)) {
					//if (nvstep<=(NVRED*MAXNVHOME))
					//	  for (k=Inst.Nvstep; k<nvstep+2; k++){ //3
					//		 if ( !Flame_Present(FALSE)) {  //4
					//			NV_RotateClock();
					//			pc_delay(200);
					//			break;
					//		  } //4
					//		NV_RotateAnticlock();
					//#If QDEMO Then
					//	 Get_NV_Pos();
					//#End If
					//	  } //3

					if ((intNVStep <= (NVRED * MAXNVHOME))) {
						for (intk = gobjInst.NvStep; intk <= intNVStep + 1; intk++) {
							if (!(gobjClsAAS203.funcFlame_Present(false))) {
								gobjCommProtocol.funcNV_Rotate_Clock();
								gobjCommProtocol.mobjCommdll.subTime_Delay(50);
								break; // TODO: might not be correct. Was : Exit For
							}
							gobjCommProtocol.funcNV_Rotate_AntiClock();
							//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
							if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
								gobjCommProtocol.funcGet_NV_Pos();
							}
						}
					}

					//	if (k==nvstep+2)
					//	  for (k=0; k<2; k++){ //5
					//		 NV_RotateClock();
					//			pc_delay(200);
					//	  } //5
					//  } //2

					if ((intk == intNVStep + 2)) {
						for (intk = 0; intk <= 1; intk++) {
							gobjCommProtocol.funcNV_Rotate_Clock();
							gobjCommProtocol.mobjCommdll.subTime_Delay(50);
						}
					}
				}

				gobjCommProtocol.funcGet_NV_Pos();
			}
			//'for getting NV posotion
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

	//'//----- Burner Height
	public bool funcReadAndSetBHScanConditions()
	{
		//=====================================================================
		// Procedure Name        : funcReadAndSetBHScanConditions
		// Parameters Passed     : 
		// Returns               : True/False
		// Purpose               : for scanning a burner height cond.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================


		try {
			//string1	Cap[2];
			//string1	Str[2];
			//int		Len[3]={5,5,-1};

			// strcpy(Cap[0], "Burner Height Scan Start(0-6mm)");
			// sprintf(Str[0],"1");
			// strcpy(Cap[1], "Burner Height Scan End(0-6mm)");
			// sprintf(Str[1],"6");
			// if (GetValues(hwnd, Cap, Str, Len)){
			//	PeakGraph.Ymin= 0.0;//GetEnergy(2047);
			//	PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
			//	PeakGraph.Xmin= atof(Str[0]);
			//	PeakGraph.Xmax= atof(Str[1]);
			//	if (PeakGraph.Xmin< PeakGraph.Xmax &&
			//	 ValidateHt(PeakGraph.Xmin) && ValidateHt(PeakGraph.Xmax))
			//	 return TRUE;
			//  }
			// return FALSE;
			//Show the getValues Windows

			return true;
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcCheckBHPos()
	{
		//=====================================================================
		// Procedure Name        : funcCheckBHPos
		// Parameters Passed     : To check the BH Position
		// Returns               : True/False
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.012.06
		// Revisions             : 
		//=====================================================================

		try {
			//            BOOL	S4FUNC CheckBhPos()
			//{
			// Get_BH_Pos();
			//            If (Inst.Bhstep < 0) Then
			//	BH_HOME();
			//                If (Inst.Bhstep < 0) Then
			//	return FALSE;
			// return TRUE;
			//}

			gobjCommProtocol.func_Get_BH_Pos();
			//'serial communication for getting burner height position

			if ((gobjInst.BhStep < 0)) {
				gobjCommProtocol.funcSetBH_HOME();
				//'set burner to home position
			}

			if ((gobjInst.NvStep < 0)) {
				return false;
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

	public int funcConvertToBHPos(double dblBH)
	{
		//=====================================================================
		// Procedure Name        : funcConvertToBHPos
		// Parameters Passed     : dblBH 
		// Returns               : Integer
		// Purpose               : for converting burner height in to position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================

		int intBHSteps = 0;

		try {
			//int	S4FUNC	ConvertToBhPos(double bh)
			//{
			//int	bhsteps=0;
			//// bh = bhstep/(200.0*BHRATIO);
			// bhsteps=(int) (bh*(200.0*BHRATIO));
			// return bhsteps;
			//}
			intBHSteps = (int)dblBH * (200.0 * BHRATIO);
			return intBHSteps;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
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

	public double funcConvertToBurnerHeight(int intBHStep)
	{
		//=====================================================================
		// Procedure Name        : funcConvertToBurnerHeight
		// Parameters Passed     : intBHStep
		// Returns               : 
		// Purpose               : function for converting a burner step in height
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 08.11.06
		// Revisions             : 
		//=====================================================================
		double dblBH = 0.0;
		try {
			//double	S4FUNC ConvertToBurnerHeight(int steps)
			//{
			//double	bh=0.0;
			// bh = steps/(200.0*BHRATIO);
			//return bh;
			//}

			dblBH = intBHStep / (200.0 * BHRATIO);
			return dblBH;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	public bool funcSetBHPos(double dblBH)
	{
		//=====================================================================
		// Procedure Name        : funcSetBHPos
		// Parameters Passed     : burner height
		// Returns               : True/False
		// Purpose               : for setting burner position as par burner height
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================
		int intk;
		int intBHStep;
		try {
			//            int	bhstep =ConvertToBhPos(bh);
			// Get_BH_Pos();
			// if (Inst.Bhstep>bhstep){
			//	 bhstep = Inst.Bhstep-bhstep;
			//	 BH_RotateAnticlock_Steps(bhstep);
			//	}
			//else if (Inst.Bhstep<bhstep){
			//	 bhstep-=Inst.Bhstep;
			//	 BH_RotateClock_Steps(bhstep);
			//  }

			intBHStep = funcConvertToBHPos(dblBH);
			//'function for converting burner height in to burner position

			gobjCommProtocol.func_Get_BH_Pos();
			//'get burner position

			if ((gobjInst.BhStep > intBHStep) & (intBHStep >= 0)) {
				//	 bhstep = Inst.Bhstep-bhstep;
				//	 BH_RotateAnticlock_Steps(bhstep);
				intBHStep = gobjInst.BhStep - intBHStep;
				gobjCommProtocol.func_BHRotateAntiClock_Steps(intBHStep);
			//'for roating burner in anticlock step.

			} else if ((gobjInst.BhStep < intBHStep) & (intBHStep <= MAXBHHOME)) {
				//   bhstep-=Inst.Bhstep;
				//   BH_RotateClock_Steps(bhstep);
				intBHStep -= gobjInst.BhStep;
				gobjCommProtocol.func_BHRotateClock_Steps(intBHStep);
				//for roating burner in clockwise step.
			}
			////-------------
			////----- Added by Sachin Dokhale on 04.07.07
			//Call gobjCommProtocol.funcSave_BH_Pos()
			////-----
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

	public bool funcValidateHt(double dblBH)
	{
		//=====================================================================
		// Procedure Name        : funcValidateHt
		// Parameters Passed     : dblBH
		// Returns               : True/False
		// Purpose               : this is used to validate Burner Height.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================
		int intk;
		int intBHStep;
		try {
			//            BOOL	ValidateHt(double bh)
			//{
			// if (bh>=0 && bh<=6.0)
			//  return TRUE;
			//return FALSE;
			//}

			if ((dblBH >= 0 & dblBH <= 6.0)) {
				return true;
			}
			////-------------
			return false;
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

	////-----
	public void subSetXoldYold(int intXoldt, int intYoldt)
	{
		//=====================================================================
		// Procedure Name        : funcSetXoldYold
		// Parameters Passed     : intElementID
		// Returns               : 
		// Purpose               : to set x,y old value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================

		try {
			//E4FUNC  void	 S4FUNC SetXoldYold(int Xoldt, int Yoldt)
			//{
			//Xold=Xoldt;
			//Yold= Yoldt;
			//}
			////---------------

			m_intXoldt = intXoldt;
			m_intYoldt = intYoldt;

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

	public void subGetXoldYold(ref int intXoldt, ref int intYoldt)
	{
		//=====================================================================
		// Procedure Name        : subGetXoldYold
		// Parameters Passed     : intXoldt, intYoldt
		// Returns               : 
		// Purpose               : to get x,y old value
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================

		try {
			//E4FUNC  void	 S4FUNC GetXoldYold(int *Xoldt, int *Yoldt)
			//{
			//*Xoldt=Xold;
			//*Yoldt= Yold;

			//}
			intXoldt = m_intXoldt;
			intYoldt = m_intYoldt;

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

	////----- Time Scan object function
	public bool funcReadAndSetFuelScanConditions(ArrayList frmobjArrlist)
	{
		//=====================================================================
		// Procedure Name        : ReadAndSetFuelScanConditions
		// Parameters Passed     : 
		// Returns               : True/False
		// Purpose               : used for scanning fuel condi
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26.12.06
		// Revisions             : 
		//=====================================================================
		int intCount;
		try {
			//---Set Property ReportGraphControls
			if (IsNothing(frmobjArrlist) == false) {
				//objclsPrintDocument.ReportGraphControls = New ArrayList
				object[] objBH;

				for (intCount = 0; intCount <= frmobjArrlist.Count - 1; intCount++) {
					if (IsNothing(frmobjArrlist.Item(intCount)) == false) {
						// objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount))
					}
				}
			}
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
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public void AbsorbanceScan()
	{
		//=====================================================================
		// Procedure Name        : AbsorbanceScan
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To show the window for Manual Optimization
		//                         i.e. Continuous TimeScan Mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 09-Jan-2007
		// Revisions             : 1
		//=====================================================================
		try {
			//code added by : dinesh wagh on 28.3.2010
			//----------------------------------------------
			if ((gstructSettings.Enable21CFR == true)) {
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Time_Scan, gstructUserDetails.Access)) {
					return;
				}
				gfuncInsertActivityLog(EnumModules.TimeScan, "Energy Spectrum Mode->TimeScan_Mode Accessed");
			}
			//-----------------------------------------------

			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan;


			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				if (gintInstrumentBeamType == enumInstrumentBeamType.SingleBeam | gintInstrumentBeamType == enumInstrumentBeamType.ReferenceBeam) {
					frmTimeScanDBMode objfrmTimeScan = new frmTimeScanDBMode();
					objfrmTimeScan.ShowDialog();
					Application.DoEvents();
					objfrmTimeScan.Close();
					objfrmTimeScan.Dispose();
					Application.DoEvents();
					objfrmTimeScan = null;
				} else {
					frmTimeScanDBMode objfrmTimeScan = new frmTimeScanDBMode();
					objfrmTimeScan.ShowDialog();
					Application.DoEvents();
					objfrmTimeScan.Close();
					objfrmTimeScan.Dispose();
					Application.DoEvents();
					objfrmTimeScan = null;
				}
			} else {
				frmTimeScanMode objfrmTimeScan = new frmTimeScanMode();
				objfrmTimeScan.ShowDialog();
				Application.DoEvents();
				objfrmTimeScan.Close();
				objfrmTimeScan.Dispose();
				Application.DoEvents();
				objfrmTimeScan = null;
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

		//gobjMessageAdapter.ShowMessage(constWorkUnderProcess)

		//E4FUNC  void	S4FUNC 	AbsorbanceScan(HWND hpar)
		//{
		//double	tval=0.0;
		//char		str[100]="";
		//HWND		hwnd=NULL;
		//MSG		msg;
		//double	xtime1=0, abs=0;
		//clock_t	CEnd, CEnd1;
		//HDC		hdc;
		//BOOL		Smooth=TRUE; // new changes
		// DLGPROC  skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnAbsScanProc,hInst);
		//  ReinitInstParameters();
		// Inst =  GetInstData();
		// if (GetInstrument()==AA202)
		//  hwnd = CreateDialog(hInst,"ABSSCAN202", hpar, skp1);
		//        Else
		// hwnd = CreateDialog(hInst,"ABSSCAN", hpar, skp1);
		// WP1=-1;
		// /*CheckInst();*/
		// Inst =  GetInstData();
		// ReadFilterSetting();   // new changes
		// Afirst=TRUE;
		// if (hwnd){
		//	UpdateWindow(hwnd);
		//	hdc= GetDC(hwnd);
		//	CEnd1=CEnd=clock();
		//	xtime1= ((CEnd-CEnd1)/(double) CLK_TCK);
		//	SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
		//	do  {
		//	  if (CheckMsg(hwnd, &msg)){
		//		 if (WP1==IDC_FILT){ // new changes
		//			Smooth ^= TRUE;
		//                            If (Smooth) Then
		//			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
		//                            Else
		//			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");

		//			WP1=-1;
		//		  }
		//		 if (WP1==IDC_RET){
		//			pc_delay(1000);
		//			ReleaseDC(hwnd, hdc);
		//			DestroyWindow(hwnd);
		//			break;
		//		  }
		//		}
		//                                    If (IsInAltProcess()) Then
		//		 continue;
		//	  abs = GetAbsScanX();
		//	  if (Smooth)          	// new changes
		//		  abs = GetFiltData(abs);

		//		//---mdf by sk on 3/6/2001
		//                                            If (CheckMinAbsScanLmt) Then
		//		 {
		//		  if(abs<Absscanthldval) //0.008 mdf by sk on 3/6/2001
		//         abs=0.0;
		//		 }
		//      //---mdf by sk on 3/6/2001

		//	  CEnd=clock();
		//	  if (CEnd!=CEnd1 ){
		//		 xtime1 += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
		//		 CEnd1 = CEnd;
		//		 GetWvAndDataInString(abs, str);
		//		 SetDlgItemText(hwnd,IDC_QAABS, str);
		//		 if (xtime1>=AbsGraph.Xmax){
		//			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
		//			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
		//			AbsGraph.Xmax +=tval;// (double)5.0;
		//			Calculate_Abs_Scan_Param(&AbsGraph);
		//			Afirst=TRUE;
		//			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
		//			UpdateWindow(hwnd);
		//			CEnd1 = clock();
		////			CStart += (CEnd1-CEnd);
		//		  }
		//		 if (Afirst){
		//			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
		//			Afirst=FALSE;
		//		  }
		//                                                            Else
		//			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
		//		}
		//	  }
		//	 while(1);

		//  }
		// FreeProcInstance(skp1);
		//  WP1=-1;
		// ReinitInstParameters();
		//}
	}

	//09.05.08
	public void AbsorbanceScan_Testing()
	{
		//=====================================================================
		// Procedure Name        : AbsorbanceScan
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To show the window for Manual Optimization
		//                         i.e. Continuous TimeScan Mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 09-Jan-2007
		// Revisions             : 1
		//=====================================================================
		try {
			gintSpectrumMode = modGlobalDeclarations.EnumSpectrumMode.TimeScan;


			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				if (gintInstrumentBeamType == enumInstrumentBeamType.SingleBeam | gintInstrumentBeamType == enumInstrumentBeamType.ReferenceBeam) {
					frmTimeScanDBMode objfrmTimeScan = new frmTimeScanDBMode();
					//Call objfrmTimeScan.ShowDialog()
					//---------------------------  '09.05.08
					objfrmTimeScan.Show();
					Application.DoEvents();
					gobjMain.Visible = false;
					objfrmTimeScan.btnAutoZero.Focus();
					Label lblTime = new Label();
					Label lblYValue = new Label();
					gobjCommProtocol.funcGetRefBaseVal();
					objfrmTimeScan.funcOnSpect(false, lblTime, lblYValue);
				//---------------------------

				//objfrmTimeScan.Close()
				//objfrmTimeScan.Dispose()
				//Application.DoEvents()
				//objfrmTimeScan = Nothing
				} else {
					frmTimeScanDBMode objfrmTimeScan = new frmTimeScanDBMode();
					//Call objfrmTimeScan.ShowDialog()
					//---------------------------  '09.05.08
					objfrmTimeScan.Show();
					Application.DoEvents();
					gobjMain.Visible = false;
					objfrmTimeScan.btnAutoZero.Focus();
					Label lblTime = new Label();
					Label lblYValue = new Label();
					gobjCommProtocol.funcGetRefBaseVal();
					objfrmTimeScan.funcOnSpect(false, lblTime, lblYValue);
					//---------------------------

					//Application.DoEvents()
					//objfrmTimeScan.Close()
					//objfrmTimeScan.Dispose()
					//Application.DoEvents()
					//objfrmTimeScan = Nothing
				}
			} else {
				frmTimeScanMode objfrmTimeScan = new frmTimeScanMode();
				objfrmTimeScan.ShowDialog();
				Application.DoEvents();
				objfrmTimeScan.Close();
				objfrmTimeScan.Dispose();
				Application.DoEvents();
				objfrmTimeScan = null;
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

		//gobjMessageAdapter.ShowMessage(constWorkUnderProcess)

		//E4FUNC  void	S4FUNC 	AbsorbanceScan(HWND hpar)
		//{
		//double	tval=0.0;
		//char		str[100]="";
		//HWND		hwnd=NULL;
		//MSG		msg;
		//double	xtime1=0, abs=0;
		//clock_t	CEnd, CEnd1;
		//HDC		hdc;
		//BOOL		Smooth=TRUE; // new changes
		// DLGPROC  skp1 =(DLGPROC) MakeProcInstance((DLGPROC) OnAbsScanProc,hInst);
		//  ReinitInstParameters();
		// Inst =  GetInstData();
		// if (GetInstrument()==AA202)
		//  hwnd = CreateDialog(hInst,"ABSSCAN202", hpar, skp1);
		//        Else
		// hwnd = CreateDialog(hInst,"ABSSCAN", hpar, skp1);
		// WP1=-1;
		// /*CheckInst();*/
		// Inst =  GetInstData();
		// ReadFilterSetting();   // new changes
		// Afirst=TRUE;
		// if (hwnd){
		//	UpdateWindow(hwnd);
		//	hdc= GetDC(hwnd);
		//	CEnd1=CEnd=clock();
		//	xtime1= ((CEnd-CEnd1)/(double) CLK_TCK);
		//	SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
		//	do  {
		//	  if (CheckMsg(hwnd, &msg)){
		//		 if (WP1==IDC_FILT){ // new changes
		//			Smooth ^= TRUE;
		//                            If (Smooth) Then
		//			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"Filt");
		//                            Else
		//			  SetWindowText(GetDlgItem(hwnd,IDC_FILT),"No Filt");

		//			WP1=-1;
		//		  }
		//		 if (WP1==IDC_RET){
		//			pc_delay(1000);
		//			ReleaseDC(hwnd, hdc);
		//			DestroyWindow(hwnd);
		//			break;
		//		  }
		//		}
		//                                    If (IsInAltProcess()) Then
		//		 continue;
		//	  abs = GetAbsScanX();
		//	  if (Smooth)          	// new changes
		//		  abs = GetFiltData(abs);

		//		//---mdf by sk on 3/6/2001
		//                                            If (CheckMinAbsScanLmt) Then
		//		 {
		//		  if(abs<Absscanthldval) //0.008 mdf by sk on 3/6/2001
		//         abs=0.0;
		//		 }
		//      //---mdf by sk on 3/6/2001

		//	  CEnd=clock();
		//	  if (CEnd!=CEnd1 ){
		//		 xtime1 += ( ((double)(CEnd-CEnd1)/(double) CLK_TCK));
		//		 CEnd1 = CEnd;
		//		 GetWvAndDataInString(abs, str);
		//		 SetDlgItemText(hwnd,IDC_QAABS, str);
		//		 if (xtime1>=AbsGraph.Xmax){
		//			tval =(AbsGraph.Xmax-AbsGraph.Xmin);
		//			AbsGraph.Xmin = AbsGraph.Xmax;//(double)5.0;
		//			AbsGraph.Xmax +=tval;// (double)5.0;
		//			Calculate_Abs_Scan_Param(&AbsGraph);
		//			Afirst=TRUE;
		//			InvalidateRect(hwnd, NULL, TRUE); //AbsGraph.RC, TRUE);
		//			UpdateWindow(hwnd);
		//			CEnd1 = clock();
		////			CStart += (CEnd1-CEnd);
		//		  }
		//		 if (Afirst){
		//			PlotInit(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
		//			Afirst=FALSE;
		//		  }
		//                                                            Else
		//			Plotg(hdc, xtime1, abs, AbsGraph.RC, &AbsGraph);
		//		}
		//	  }
		//	 while(1);

		//  }
		// FreeProcInstance(skp1);
		//  WP1=-1;
		// ReinitInstParameters();
		//}
	}

	public bool IsFilter()
	{
		//=====================================================================
		// Procedure Name        : IsFilter
		// Parameters Passed     : None
		// Returns               : True/False
		// Purpose               : return Filter condition
		// Description           : check for filter
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 23.Jan.2007
		// Revisions             : 
		//=====================================================================

		try {
			IsFilter = m_blnFilterFlag;

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

	public bool funcEnableDisableFilter(bool blnFilterFlag)
	{
		//=====================================================================
		// Procedure Name        : EnableDisableFilter
		// Parameters Passed     : True/False
		// Returns               : True/False
		// Purpose               : for enable disable a filter
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 23.Jan.2007
		// Revisions             : 
		//=====================================================================

		try {
			m_blnFilterFlag = blnFilterFlag;

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

	public bool Find_Analytical_Peak(int intLampNo, ref double dblWvOptIn, ref Label lblOptimizedWavelengthIn = null)
	{
		//=====================================================================
		// Procedure Name        : Find_Analytical_Peak
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : this is used to find analytical peak.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		//'BOOL	S4FUNC 	Find_Analytical_Peak(HWND hpar, int intLampNo)
		//'{
		//'HWND		hwnd;
		//'HDC		hdc;
		//'double   	cur=0.0, wvnew=0.0;
		//'BOOL		flag= TRUE;
		//'char     line1[80]="";

		//**********************************************
		//---STEP 1
		//**********************************************
		//'#ifndef FINAL
		//'  Get_Instrument_Parameters(&Inst);
		//'#End If
		//' Inst =  GetInstData();
		//' if (intLampNo<0 || intLampNo>(GetMaxLamp()-1)) //5
		//'	return FALSE;

		//**********************************************
		//---STEP 2
		//**********************************************
		//'  wvnew = Inst->Lamp_par.lamp[intLampNo].wv;

		//'  if (strcmp(trim(Inst->Lamp_par.lamp[intLampNo].elname),"")==0){
		//'	 if( GetInstrument() == AA202)
		//'		 Gerror_message_new(" No Lamp in Mesurement Holder Position ...", "PEAK SEARCH");
		//'                            Else
		//'		 Gerror_message_new(" No Lamp in Turret Position ...", "PEAK SEARCH");
		//'	 return FALSE;
		//'	}

		//**********************************************
		//---STEP 3
		//**********************************************
		//' if(GetInstrument() != AA202 )
		//'	 AIR_OFF();

		//**********************************************
		//---STEP 4
		//**********************************************
		//' if((intLampNo+1) !=Inst->Lamp_pos){
		//'      strcpy(line1,"");        
		//' if (!Position_Turret(hpar, intLampNo+1,TRUE)){
		//'      if(GetInstrument() != AA202 )
		//'	        AIR_ON();
		//'	    if( GetInstrument() == AA202)
		//'	        Gerror_message_new("Error in Lamp Position ..", "LAMP");
		//'      Else
		//'	        Gerror_message_new("Error in Turret Module ..", "TURRET");
		//'	return FALSE;
		//'	}
		//'  }

		//**********************************************
		//---STEP 5
		//**********************************************
		//' wvnew = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv;
		//' All_Lamp_Off();

		//**********************************************
		//---STEP 6 and 7
		//**********************************************
		//' if (Inst->Lamp_warm>0) 
		//' {
		//'      if (strcmp(trim(Inst->Lamp_par.lamp[Inst->Lamp_warm-1].elname),"")!=0)
		//'      {
		//'          cur = Inst->Lamp_par.lamp[Inst->Lamp_warm-1].cur;
		//'          If (cur > 0) Then        
		//' 	            Set_HCL_Cur(cur,Inst->Lamp_warm);
		//'      }
		//' }

		//**********************************************
		//---STEP 8 
		//**********************************************
		//' cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
		//' if (cur==0)
		//'      Gerror_message_new("Current is 0.0 nm ", "WARNING");

		//**********************************************
		//---STEP 9 
		//**********************************************
		//' if( GetInstrument() == AA202)
		//'      Set_HCL_Cur(cur,Inst->Lamp_pos);
		//' Else
		//'      Set_HCL_Cur(cur,Inst->Lamp_pos);

		//**********************************************
		//---STEP 10 
		//**********************************************
		//'  if (Inst->Cur==(double) 0.0){        
		//'	    Inst->Cur=cur;
		//'	}

		//'#If !DEMO Then
		//' if(GetInstrument() == AA202 )
		//'#End If

		//**********************************************
		//---STEP 11 
		//**********************************************
		//' Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = 1;

		//**********************************************
		//---STEP 12
		//**********************************************
		//' if ( Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos != 0 &&
		//'      Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos != -1)
		//' {
		//**********************************************
		//---STEP 13
		//**********************************************
		//'      if (wvnew>=190.0 && wvnew<=900.0)
		//'      {

		//**********************************************
		//---STEP 14
		//**********************************************
		//' 	        hwnd= CreateWindowPeak(hpar, " ANALYTICAL LINE ","SKCK2",0 );
		//' 	        if (hwnd )
		//'          {

		//**********************************************
		//---STEP 15
		//**********************************************
		//' 		        SetInstrumentCondns(hwnd, TRUE);
		//' 		        cur=Inst->Lamp_par.lamp[Inst->Lamp_pos-1].slitwidth;
		//' 		        if (cur==0)
		//' 			        Gerror_message_new("Slitwidth is is 0.0 nm ", "WARNING");

		//**********************************************
		//---STEP 16
		//**********************************************
		//' 		        Set_SlitWidth(cur);

		//**********************************************
		//---STEP 17
		//**********************************************
		//' 		        pc_delay (200);

		//' 		        hdc= GetDC(hwnd);
		//' 		        SetBkColor(hdc, RGB(192, 192, 192));
		//' 		        SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");

		//**********************************************
		//---STEP 18
		//**********************************************
		//' 		        wvnew = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv- (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv);
		//'              If (wvnew < 0.5) Then
		//'	 		        wvnew= (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv);
		//'              Else
		//'			        wvnew= (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv)+(double) 0.5; //floor

		//**********************************************
		//---STEP 19
		//**********************************************
		//'		        strcpy(line1,""); sprintf(line1, " Setting wavelength from %6.2f nm to %6.2f nm", Inst->Wvcur, wvnew);
		//'		        SetText(hwnd, IDC_STATUS1,line1);
		//'		        Wavelength_Position(hdc, wvnew,5, 150);

		//**********************************************
		//---STEP 20
		//**********************************************
		//'		        strcpy(line1,"");
		//'		        sprintf(line1, " Optimizing %s  for Analytical Peak. ", Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
		//'		        SetText(hwnd, IDC_STATUS1,line1);

		//**********************************************
		//---STEP 21
		//**********************************************
		//' 		        if (!Analytical_Peak(hwnd , hdc, TRUE)) {
		//' 			        Gerror_message_new("Analytical Peak not found", "Analytical Peak");
		//' 			        pc_delay(300);
		//' 			        flag = FALSE;
		//' 		        }
		//' 		        else{
		//'			        wvopt = Inst->Wvcur;
		//' 			        flag=TRUE;
		//'		        }
		//' 		    } //hwnd
		//' 	        ReleaseDC(hwnd, hdc);
		//' 	        DestroyWindowPeak(hwnd,hpar);
		//'      } // wv 190-1000.0
		//'      else
		//'		{
		//'			Gerror_message_new("Wavelength Range 190.0..900.0 Only ","PEAK SEARCH");
		//'			flag = FALSE;
		//'		}
		//'	} // lamp-present
		//'  else
		//'	{
		//'		if(GetInstrument() == AA202)
		//'			Gerror_message_new("Lamp Not Optimised ..", "PEAK SEARCH");
		//'                                                                                                    Else
		//'			Gerror_message_new("Turret Not Optimised ..", "PEAK SEARCH");
		//'			//pc_sound(1000,2);;pc_sound(1000,1) ;pc_sound(1000,2);
		//'		pc_delay(3000);  flag = FALSE;
		//'	}
		//'  strcpy(line1,"");
		//'  Cal_Mode(Inst->Lamp_par.lamp[Inst->Lamp_pos-1].mode);
		//'  if (flag){
		//'	    if (MessageBox(hpar, " Do you want manual Optimisation ?", "INSTRUMENT CONDITIONS", MB_YESNO)==IDYES)
		//'		    AbsorbanceScan(hpar);
		//'	}
		//'  pc_delay(1500);
		//'  return flag;        
		//' }


		//*********************************************************
		//----Code By Mangesh S.
		//*********************************************************
		double cur = 0.0;
		bool blnIsLampOptimized;
		double wvnew = 0.0;
		AAS203Library.Instrument.ClsInstrument objInstTemp = new AAS203Library.Instrument.ClsInstrument();
		int intCount;

		try {


			//**********************************************
			//---STEP 1 : Get Instrument Settings and Check 
			//---         lamp present or not. 
			//**********************************************
			//'#ifndef FINAL
			//Get_Instrument_Parameters(Inst)
			//'#End If
			//Inst = GetInstData()

			if ((intLampNo < 1 | intLampNo > (gobjClsAAS203.funcGetMaxLamp()))) {
				return false;
			}

			//**********************************************
			//---STEP 2 : Get Wavelength of the selected lamp
			//---Check lamp present or not; if not give error message
			//**********************************************
			//'  if (strcmp(trim(Inst->Lamp_par.lamp[intLampNo].elname),"")==0){
			//'	 if( GetInstrument() == AA202)
			//'		 Gerror_message_new(" No Lamp in Mesurement Holder Position ...", "PEAK SEARCH");
			//'                            Else
			//'		 Gerror_message_new(" No Lamp in Turret Position ...", "PEAK SEARCH");
			//'	 return FALSE;
			//'	}
			wvnew = gobjInst.Lamp.LampParametersCollection(intLampNo - 1).Wavelength;

			if (Trim(gobjInst.Lamp.LampParametersCollection(intLampNo - 1).ElementName) == "") {
				//gobjMessageAdapter.ShowMessage(" No Lamp in Turret Position ...", "PEAK SEARCH", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
				//gobjMessageAdapter.ShowMessage(constNoLamp)
				//Return False
				if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
					//Gerror_message_new(" No Lamp in Mesurement Holder Position ...", "PEAK SEARCH");
					gobjMessageAdapter.ShowMessage(constNoLampMeasurement);
					Application.DoEvents();
				} else {
					//Gerror_message_new(" No Lamp in Turret Position ...", "PEAK SEARCH");
					gobjMessageAdapter.ShowMessage(constNoLamp);
					Application.DoEvents();
				}

				return false;
			}

			if (gobjInst.Lamp.LampParametersCollection(intLampNo - 1).LampOptimizePosition == -1) {
				if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				//Call gobjMessageAdapter.ShowMessage(constNoLampMeasurement)
				//Call Application.DoEvents()
				} else {
					////----- Commented and added by Sachin Dokhale for message
					//Call gobjMessageAdapter.ShowMessage("Turret is not optimized.")
					gobjMessageAdapter.ShowMessage("Turret is not optimized.", "Lamp Oprimization", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage);
					////-----
					Application.DoEvents();
				}


				return false;
			}

			//**********************************************
			//---STEP 3 : Sets Air OFF
			//**********************************************
			if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				gobjCommProtocol.funcAir_OFF();
			}

			//**********************************************
			//---STEP 4 : Sets Position of lamp turret to the 
			//---current lamp position; if not give error message.
			//**********************************************

			//---commented for ver 4.85 10.04.09
			//'If ((intLampNo) <> gobjInst.Lamp_Position) Then
			//'    If Not (gobjCommProtocol.gFuncTurret_Position(intLampNo, True)) Then
			//'        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
			//'            Call gobjCommProtocol.funcAir_ON()
			//'        End If
			//'        If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
			//'            gobjMessageAdapter.ShowMessage(constErrorLampPosition)
			//'        Else
			//'            gobjMessageAdapter.ShowMessage(constErrorTurret)
			//'        End If
			//'        Call Application.DoEvents()
			//'        Return False
			//'    End If
			//'End If
			//-----------------

			//---written for ver 4.85 10.04.09
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201 | gstructSettings.AppMode == EnumAppMode.DemoMode_201) {
				gobjInst.Lamp_Position = intLampNo;
			} else {
				if (((intLampNo) != gobjInst.Lamp_Position)) {
					if (!(gobjCommProtocol.gFuncTurret_Position(intLampNo, true))) {
						if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
							gobjCommProtocol.funcAir_ON();
						}
						if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
							gobjMessageAdapter.ShowMessage(constErrorLampPosition);
						} else {
							gobjMessageAdapter.ShowMessage(constErrorTurret);
						}
						Application.DoEvents();
						return false;
					}
				}
			}
			//------------------------------

			wvnew = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Wavelength;


			//**********************************************
			//---STEP 5 : Set Lamps OFF (Lamp Current is 0.0 amp)
			//**********************************************
			gobjCommProtocol.funcAll_Lamp_Off();

			//**********************************************
			//---STEP 6 and 7 : Get WarmUp Lamp's Position and Current in Amp
			//--- and set that warmup lamp on (Glow it)
			//**********************************************
			if ((gobjInst.Lamp_Warm > 0)) {
				if (Trim(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Warm - 1).ElementName) == "") {
					cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Warm - 1).Current;
					if ((cur > 0)) {
						//Set_HCL_Cur(cur,Inst->Lamp_warm);
						gobjCommProtocol.funcSet_HCL_Cur(cur, gobjInst.Lamp_Warm);
					}
				}
			}

			//**********************************************
			//---STEP 8 : Get Current Value of selected measurement
			//--- lamp; if it is zero give warning message.
			//**********************************************
			cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Current;

			if ((cur == 0)) {
				//gobjMessageAdapter.ShowMessage("Current is 0.0 nm ", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
				gobjMessageAdapter.ShowMessage(constCurrent);
			}

			//**********************************************
			//---STEP 9 : Set that Measurement lamp on and set the
			//**********************************************
			gobjCommProtocol.funcSet_HCL_Cur(cur, gobjInst.Lamp_Position);

			//**********************************************
			//---STEP 10 : Set taht Lamp Current value to Instrument Settings
			//**********************************************
			if ((gobjInst.Current == 0.0)) {
				//gobjMessageAdapter.ShowMessage("Current is  0.0", "Warning", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
				gobjMessageAdapter.ShowMessage(constCurrent);
				gobjInst.Current = cur;
			}

			//**********************************************
			//---STEP 11 : Sets Lamp Optimized Position as 1
			//**********************************************
			//Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = 1
			gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).LampOptimizePosition = 1;

			//**********************************************
			//---STEP 12 : Check Lamp Optimized Position as 0 or -1
			//**********************************************

			if ((gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).LampOptimizePosition != 0 & gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).LampOptimizePosition != -1)) {
				//**********************************************
				//---STEP 13 : Check Wavelength is between 190.0 to 900.0 nm
				//**********************************************

				//commented and added by deepak on 24.07.07
				//If (wvnew >= 190.0 And wvnew <= 900.0) Then
				if ((wvnew >= gstructSettings.WavelengthRange.WvLowerBound & wvnew <= gstructSettings.WavelengthRange.WvUpperBound)) {
					//**********************************************
					//---STEP 14 : Show Window for Analytical Peak
					//**********************************************
					frmLampOptimisation objfrmLampOptimisation;
					objfrmLampOptimisation = new frmLampOptimisation(true);
					//---------------------------------------------------------------------------------
					//---Steps No. from 15 to 17 are in the clsBgLampOptimization.
					//---------------------------------------------------------------------------------
					objfrmLampOptimisation.ShowDialog();

					if (!(objfrmLampOptimisation.IsLampOptimized)) {
						//gobjMessageAdapter.ShowMessage("Analytical Peak not found", "Analytical Peak", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
						gobjMessageAdapter.ShowMessage(constAnalyticalPeak);
						Application.DoEvents();
						blnIsLampOptimized = false;
					} else {
						dblWvOptIn = gobjInst.WavelengthCur;
						if (!IsNothing(lblOptimizedWavelengthIn)) {
							lblOptimizedWavelengthIn.Text = "Optimized Wavelength : " + FormatNumber(objfrmLampOptimisation.OptimizedWavelength, 2) + " nm";
						}
						blnIsLampOptimized = true;
					}

				//// wv 190-1000.0
				} else {
					//gobjMessageAdapter.ShowMessage("Wavelength Range 190.0..900.0 Only ", "PEAK SEARCH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
					gobjMessageAdapter.ShowMessage(constWavelengthRange);
					blnIsLampOptimized = false;
				}
			// // lamp-present
			} else {
				//if(GetInstrument() == AA202)
				//'			Gerror_message_new("Lamp Not Optimised ..", "PEAK SEARCH");
				//'                                                                                                    Else
				//'			Gerror_message_new("Turret Not Optimised ..", "PEAK SEARCH");

				//gobjMessageAdapter.ShowMessage("Turret Not Optimised ..", "PEAK SEARCH", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
				//gobjMessageAdapter.ShowMessage(constTurretNotOptimised)
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					gobjMessageAdapter.ShowMessage(constLampNotOptimised);
				} else {
					gobjMessageAdapter.ShowMessage(constTurretNotOptimised);
				}
				////pc_sound(1000,2);;pc_sound(1000,1) ;pc_sound(1000,2);
				gobjCommProtocol.mobjCommdll.subTime_Delay(30);
				blnIsLampOptimized = false;
			}
			//---------------------------------------------------------------------------------

			//---Changed by Mangesh on 08-Jan-2007
			//'Cal_Mode(Inst->Lamp_par.lamp[Inst->Lamp_pos-1].mode)
			if (!IsNothing(gobjNewMethod)) {
				switch (gobjNewMethod.OperationMode) {
					case EnumOperationMode.MODE_AA:
						gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode = EnumCalibrationMode.AA;
					case EnumOperationMode.MODE_AABGC:
						gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode = EnumCalibrationMode.AABGC;
					case EnumOperationMode.MODE_EMMISSION:
						gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode = EnumCalibrationMode.EMISSION;
				}
			}

			gobjCommProtocol.funcCalibrationMode(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode);

			//====================================================
			if (File.Exists(Application.StartupPath + "\\" + ConstInstFileName) == true) {
				//'If funcDeSerialize(ConstInstFileName, objInstTemp.Lamp) = True Then
				//4.85  12.04.09
				if (funcDeSerialize(Application.StartupPath + "\\" + ConstInstFileName, objInstTemp.Lamp) == true) {
					for (intCount = 0; intCount <= objInstTemp.Lamp.LampParametersCollection.Count - 1; intCount++) {
						gobjInst.Lamp.LampParametersCollection.item(intCount).LampOptimizePosition = objInstTemp.Lamp.LampParametersCollection.item(intCount).LampOptimizePosition;
					}
				}
			}
			//====================================================


			if ((blnIsLampOptimized)) {
				//---written by Deepak on 03.05.10
				if (IsInIQOQPQ) {
					Application.DoEvents();
					AbsorbanceScan();
				} else {
					if ((gobjMessageAdapter.ShowMessage(constWantManualOptimisation) == true)) {
						Application.DoEvents();
						//---Manual Optimization or Instrument Setup
						AbsorbanceScan();
					}
				}
				Application.DoEvents();

				//---commented by Deepak on 03.05.10
				///code commented by ; dinesh wagh on 8.4.2010
				///------------------------------------------------------
				///If (gobjMessageAdapter.ShowMessage(constWantManualOptimisation) = True) Then
				///    Application.DoEvents()
				///    '---Manual Optimization or Instrument Setup
				///    Call AbsorbanceScan()
				///End If
				///-------------------------------------------------------

				///code added by ; dinesh wagh on 8.4.2010
				///removes the message.
				///------------------------
				//'Application.DoEvents()
				//'Call AbsorbanceScan()
				///------------------------------
				//'Application.DoEvents()
			}

			gobjCommProtocol.mobjCommdll.subTime_Delay(15);
			Application.DoEvents();

			return blnIsLampOptimized;

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

	public bool Find_Emmission_Peak()
	{
		//=====================================================================
		// Procedure Name        : Find_Emmission_Peak
		// Parameters Passed     : None
		// Returns               : Boolean
		// Purpose               : Finds Emmision Peak
		// Description           : Finds Emmision Peak
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 08-Jan-2007 3:45 pm
		// Revisions             : 
		//=====================================================================

		//*********************************************************
		//--- ORIGINAL  CODE
		//*********************************************************
		//BOOL	S4FUNC 	Find_Emmission_Peak(HWND hpar) //, double wv, double sw)
		//{
		//double	wvemis=0.0;
		//HWND	hwnd;
		//HDC	hdc;
		//BOOL	flag=FALSE,flag1=FALSE;
		//char  line1[180]="";
		// if (strcmpi(trim(ltrim(Inst->Lamp_par.Ems.elname)),"")==0)
		//	return FALSE;
		// if (Inst->Lamp_par.Ems.wv<190 || Inst->Lamp_par.Ems.wv>900)
		//	return FALSE;
		// hwnd= CreateWindowPeak(hpar, " EMISSION LINE ","SKCK2",0 );
		// EmsZero=(double) 0.0;
		// if (hwnd){
		//	SetInstrumentCondns(hwnd, FALSE);
		//	hdc= GetDC(hwnd);
		//	SetBkColor(hdc, RGB(192, 192, 192));
		//	strcpy(line1,"");
		//	Cal_Mode(EMISSION);
		//	SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");
		//	All_Lamp_Off();
		//	Set_D2_Cur(100);D2_OFF();
		//	Set_SlitWidth(Inst->Lamp_par.Ems.slitwidth);// pos_slit(slit);
		//	wvemis = Inst->Lamp_par.Ems.wv- (double) ( (int) Inst->Lamp_par.Ems.wv);
		//                    If (wvemis < 0.5) Then
		//	  wvemis = (double) ( (int) Inst->Lamp_par.Ems.wv);
		//                    Else
		//	  wvemis = (double) ( (int) Inst->Lamp_par.Ems.wv)+(double) 0.5; //floor
		//	strcpy(line1,""); sprintf(line1, " Setting wavelength from %6.2f nm to %6.2f nm", Inst->Wvcur, wvemis);
		//	SetText(hwnd, IDC_STATUS1,line1);
		//	Wavelength_Position(hdc, wvemis ,5, 150);
		//	strcpy(line1,""); sprintf(line1, " Optimizing %s  for Emission Peak.          ",Inst->El);
		//	SetText(hwnd, IDC_STATUS, line1);
		//	if(GetInstrument() == AA202)
		//	  flag1 =  Check_Ignite_AA202(hwnd);
		//                        Else
		//		flag1 =  Check_Ignite();
		//	if (flag1) {
		//	  if (MessageBox(hwnd, "Press YES for flame optimization\nPress No for emission line lacthing\n[Note:-If flame is not ignited it can not lacth on emission line]", "EMMISION PEAK", MB_YESNO)==IDYES)
		//		AbsorbanceScan(hpar);
		//	  Blink_MessageBox(hwnd, "Aspirate MAXIMUM STD. and Press OK", "EMMISION PEAK", 0);
		////	  MessageBox(hwnd, "Aspirate MAXIMUM STD. and Press OK", "EMMISION PEAK", MB_OK);
		//	  ShowWindow(hwnd,SW_SHOW);
		//	  pc_delay(1000);
		//	  if (!Analytical_Peak(hwnd , hdc, FALSE)){
		//		 Gerror_message_new("Emission Peak not found","PEAK SEARCH");
		//		 pc_delay(300);
		//		 SetFocus(hwnd);
		//		}
		//	  else{
		//		 flag=TRUE;
		//		  Auto_blank_Emission(hwnd, TRUE);
		//		 }
		///*	  else{
		//		wvopt = wvcur;
		//		if (button(20, 12, " Modify Analysis Parameters ? (Y/N) ", FALSE)) Parameters();

		//       If (Button(20, 12, " Do you want manual optimization ?", False)) Then
		//		    abs_scan();
		//		emmision();
		//		}*/
		//	}
		//  ReleaseDC(hwnd, hdc);
		//  DestroyWindowPeak(hwnd,hpar);
		//  if (flag && MessageBox(hpar, " Do you want manual Optimisation ?", "INSTRUMENT CONDITIONS", MB_YESNO)==IDYES)
		//	AbsorbanceScan(hpar);

		// }
		//return flag;
		//}
		//*********************************************************
		bool blnIsLampOptimized;
		frmLampOptimisation objfrmLampOptimisation;

		try {
			//*********************************************************
			//--- CODE BY MANGESH
			//*********************************************************
			if (Trim(gobjInst.Lamp.EMSCondition.ElementName) == "") {
				return false;
			}

			if ((gobjInst.Lamp.EMSCondition.Wavelength < gstructSettings.WavelengthRange.WvLowerBound | gobjInst.Lamp.EMSCondition.Wavelength > gstructSettings.WavelengthRange.WvUpperBound)) {
				return false;
			}

			objfrmLampOptimisation = new frmLampOptimisation(false);

			objfrmLampOptimisation.ShowDialog();

			blnIsLampOptimized = objfrmLampOptimisation.IsLampOptimized;

			objfrmLampOptimisation.Close();
			objfrmLampOptimisation.Dispose();
			objfrmLampOptimisation = null;

			EmsZero = 0.0;

			if ((blnIsLampOptimized)) {
				if ((gobjMessageAdapter.ShowMessage(constWantManualOptimisation) == true)) {
					Application.DoEvents();
					gobjClsAAS203.AbsorbanceScan();
				}
			} else {
				Application.DoEvents();
			}

			return blnIsLampOptimized;

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

	public bool SaveQuantResults(ref Method.clsMethod objMethodInfo, double[] A1, bool reprocess, bool ShowMessages = true)
	{
		//=====================================================================
		// Procedure Name        : SaveQuantResults
		// Parameters Passed     : objMethodInfo, A1(),reprocess,ShowMessages
		// Returns               : Boolean
		// Purpose               : Save Quantitative data into method object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 17-Jan-2007 03:25 pm
		// Revisions             : 1
		//=====================================================================
		CWaitCursor objWaitCursor = new CWaitCursor();
		double nmetc = 0.0;
		double ninst;
		double nrep;
		double nparam;

		int intRunNumberIndex;
		int intMethodCounter;

		try {
			//***************************************************************
			//DATA4  	*mthdata=NULL,*aadata=NULL;
			//DATA4  	*aainstdata=NULL,*aarepdata=NULL;
			//DATA4  	*aaparamdata=NULL,*stdinfodata=NULL;
			//DATA4  	*sampinfodata=NULL,*methstddata=NULL;
			//DATA4  	*methsampdata=NULL,*aastatdata=NULL,*aaresultdata=NULL;
			//INDEX4  *mthidx=NULL,*aaidx=NULL;
			//INDEX4  *aainstidx=NULL,*aarepidx=NULL;
			//INDEX4  *aaparamidx=NULL,*stdinfoidx=NULL;
			//INDEX4  *sampinfoidx=NULL,*methstdidx=NULL;
			//INDEX4  *methsampidx=NULL,*aastatidx=NULL, *aaresultidx=NULL;

			//DLGPROC skp1=NULL;
			//char		fname[80]="";
			//char		rsultfname[80]="";

			//If (!temp) Then return FALSE;
			//--- Check if objMethodInfo object is nothing then exit from function
			if (IsNothing(objMethodInfo))
				return false;

			//--- Set the last index No of QuantitativeDataCollection object
			//if (!temp->QuantData) return FALSE;
			if (gobjNewMethod.QuantitativeDataCollection.Count > 0) {
				intRunNumberIndex = gobjNewMethod.QuantitativeDataCollection.Count - 1;
			} else {
				intRunNumberIndex = 0;
			}
			//--- Check if StandardDataCollection object is nothing then exit from function
			//--- Check if SampleDataCollection object is nothing then exit from function
			if (IsNothing(objMethodInfo.QuantitativeDataCollection.Item(intRunNumberIndex).StandardDataCollection))
				return false;
			if (IsNothing(objMethodInfo.QuantitativeDataCollection.Item(intRunNumberIndex).SampleDataCollection))
				return false;

			//GetInstrumentData(&(temp->Aas));

			//if (GetAnalysedStandards(temp->QuantData->StdTopData)<1)
			//   return FALSE;
			//If GetAnalysedStandards(objMethodInfo.StdParametersCollection) < 1 Then
			//    Return False
			//End If

			if (!reprocess) {
				//--- Check if instrument contion is not valid then exit from function
				if (!(CheckValidInstConditions(objMethodInfo.InstrumentCondition))) {
					return false;
				}
			}

			//if (!QDIopen("METHOD",&mthdata, &mthidx))
			//	return  FALSE;

			//if (!QDIopen("AAMETHOD",&aadata, &aaidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("AAINST",&aainstdata, &aainstidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("AAREPORT",&aarepdata, &aarepidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("AAPARAM",&aaparamdata, &aaparamidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("STDINFO",&stdinfodata, &stdinfoidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("METHSTD",&methstddata, &methstdidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("SAMPINFO",&sampinfodata, &sampinfoidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("METHSAMP",&methsampdata, &methsampidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("AASTAT",&aastatdata, &aastatidx))
			//{
			//	d4close_all(cb);
			//	return  FALSE;
			//}
			//if (!QDIopen("AARESULT",&aaresultdata, &aaresultidx))
			//{
			//d4close_all(cb);
			//return  FALSE;
			//}

			if (!(reprocess)) {
				//SaveInstrumentData(aainstdata,  temp->Aas)
			}
			//--- Set the saving messages
			if (ShowMessages == true) {
				gobjMessageAdapter.ShowStatusMessageBox("Updating Results", "QUANTITATIVE RESULTS", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000);
				Application.DoEvents();
			}

			//If NOT (reprocess) Then
			//	AppendAndCopyAAParam( aaparamdata,mthdata, mthidx, &(temp->QuantData->Param));
			//end if

			//AppendAndCopyAAReport(aarepdata, mthdata, mthidx,&(temp->QuantData->RepData));

			//If NOT (reprocess) Then
			//	AppendandCopyAAInstFile(aainstdata, mthdata,mthidx,  &(temp->Aas));
			//end if

			//--- Set the saving messages
			if (ShowMessages == true) {
				gobjMessageAdapter.UpdateStatusMessageBox("Updating Method ...", "QUANTITATIVE RESULTS");
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			}

			//AppendandCopyMethodFile(mthdata, temp->NmetC, temp->Nmet, temp->Aas.nInst, temp->QuantData->Param.nParam,temp->QuantData->RepData.nRep);

			//AppendandAARESULTS(aaresultdata, temp,A1);

			//--- Set the saving messages
			if (ShowMessages == true) {
				gobjMessageAdapter.UpdateStatusMessageBox("Creating Reports for standards ...", "QUANTITATIVE RESULTS");
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			}

			//if ( temp->NmetC>0 && temp->QuantData->StdTopData )
			//	AppendStandardsFile(methstddata, methstdidx, mthdata, stdinfodata, aastatdata, temp->NmetC, (temp->QuantData->StdTopData), TRUE, NULL);
			//end if

			//--- Set the saving messages
			if (ShowMessages == true) {
				gobjMessageAdapter.UpdateStatusMessageBox("Creating Reports for samples ...", "QUANTITATIVE RESULTS");
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			}

			//if (temp->NmetC>0 && temp->QuantData->SampTopData )
			//   AppendSamplesFile(methsampdata, methsampidx, mthdata,sampinfodata,aastatdata, temp->NmetC, (temp->QuantData->SampTopData), temp, TRUE,NULL);
			//end if

			//--- Set the saving messages
			if (ShowMessages == true) {
				gobjMessageAdapter.UpdateStatusMessageBox("Storing RawData File ...", "QUANTITATIVE RESULTS");
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			}

			//strcpy(fname,Data_Dir.rawdir);

			//if (fname[strlen(fname)-1]!='\\')
			//	strcat(fname,"\\");
			//end if

			//sprintf(rsultfname,"%08.0f.dat",temp->QuantData->Fname );
			//strcat(fname, rsultfname);
			//If (RawDataSaveFn) Then
			//    (*RawDataSaveFn) (fname); 
			//end if

			//--- Set the saving messages
			if (ShowMessages == true) {
				gobjMessageAdapter.UpdateStatusMessageBox("Updating Method File ...", "QUANTITATIVE RESULTS");
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(200);
			}
			//--- save the method info into method object 
			int intRunNoIdx;
			intRunNoIdx = objMethodInfo.QuantitativeDataCollection.Count - 1;
			for (intMethodCounter = 0; intMethodCounter <= gobjMethodCollection.Count - 1; intMethodCounter++) {
				if (gobjMethodCollection.item(intMethodCounter).MethodID == objMethodInfo.MethodID) {
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber = new clsInstrumentParameters();
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber = objMethodInfo.InstrumentCondition.Clone;
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.D2Current = gobjInst.D2Current;
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.SlitWidth = funcGet_SlitWidth();
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.ExitSlitWidth = funcGet_SlitWidth(1);
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.PmtVoltage = gobjInst.PmtVoltage;
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.RefPmtVoltage = gobjInst.PmtVoltageReference;
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.FuelRatio = funcRead_Fuel_Ratio();
					//funcGet_Fuel_Ratio(False)
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.LampCurrent = gobjInst.Current;
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.LampNumber = gobjInst.Lamp_Position;
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.TurretNumber = objMethodInfo.InstrumentCondition.TurretNumber;
					objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.BurnerHeight = funcReadBurnerHeight();
					objMethodInfo.DateOfLastUse = Now();

					//--- Make the clone object of Method into Method collection object
					//--- Assign object of clsInstrumentParameters into Method collection object
					gobjMethodCollection.item(intMethodCounter) = objMethodInfo.Clone();
					gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection(intRunNoIdx).InstrumentParameterForRunNumber = objMethodInfo.QuantitativeDataCollection.Item(intRunNoIdx).InstrumentParameterForRunNumber.Clone;
					//4.85 12.04.09
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			//Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
			//--- Save the method collection object into file system
			funcSaveAllMethods(gobjMethodCollection);

			//nmetc = temp->NmetC
			//nparam = temp->QuantData->Param.nParam
			//nrep = temp->QuantData->RepData.nRep
			//ninst= temp->Aas.nInst
			//temp->RepReady=FALSE

			if (!(reprocess)) {
				//AppendMethod(temp, QALL)
			}

			if (ShowMessages == true) {
				gobjMessageAdapter.UpdateStatusMessageBox("Completed", "QUANTITATIVE RESULTS");
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			}

			if (ShowMessages == true) {
				gobjMessageAdapter.CloseStatusMessageBox();
				Application.DoEvents();
			}

			//temp->RepReady=TRUE;

			return true;
		//***************************************************************

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
			if (ShowMessages == true) {
				gobjMessageAdapter.CloseStatusMessageBox();
				Application.DoEvents();
			}
			objWaitCursor.Dispose();
			//---------------------------------------------------------
		}
	}

	public bool ReadRawDataFile(string strFullFileName, ref double dblMinXTime, ref double dblMaxXTime, ref Analysis.clsRawDataCollection objAnalysisRawData)
	{
		//=====================================================================
		// Procedure Name        : ReadRawDataFile
		// Parameters Passed     : File Name,, which is to be read.
		//                       : dblMinXTime,dblMaxXTime,objAnalysisRawData
		// Returns               : True/False
		// Purpose               : for reading a row data file.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 24-Feb-2007 02:55 pm
		// Revisions             : 1
		//=====================================================================
		IO.FileStream fs;
		IO.StreamReader sr;
		Analysis.clsRawData.enumSampleType intSampleType;
		int intSampleID;
		string strSampleName;
		int intNoOfReadings;
		double dblXTime;
		double dblAbsorbance;
		Analysis.clsRawData objRawData;
		bool blnIsFirstTime = true;

		try {
			//--- for reading a row data file.
			if (!IO.File.Exists(strFullFileName)) {
				return;
			}

			fs = new IO.FileStream(strFullFileName, IO.FileMode.Open, IO.FileAccess.Read);
			//'open a file for reading
			sr = new IO.StreamReader(fs);

			string strLine;
			string[] strArrHeader;
			string[] strArrValues;

			if (!IsNothing(sr)) {
				dblMinXTime = 0.0;
				objAnalysisRawData = new Analysis.clsRawDataCollection();
				///object for raw data collection.

				while ((true)) {
					strLine = sr.ReadLine();
					if (!IsNothing(strLine)) {
						if (strLine.Length == 0) {
						//---Empty line.. Do Nothing...
						} else {
							strArrHeader = strLine.Split(';');
							if (strArrHeader.Length > 3) {
								if (Trim(strArrHeader(0)) == "BLANK") {
									intSampleType = ClsAAS203.enumSampleType.BLANK;
								} else if (Trim(strArrHeader(0)) == "STANDARD") {
									intSampleType = ClsAAS203.enumSampleType.STANDARD;
								} else if (Trim(strArrHeader(0)) == "SAMPLE") {
									intSampleType = ClsAAS203.enumSampleType.SAMPLE;
								}
								intSampleID = Val(strArrHeader(1));
								strSampleName = Trim(strArrHeader(2));
								intNoOfReadings = Val(strArrHeader(3));

								objRawData = new Analysis.clsRawData();
								objRawData.SampleType = intSampleType;
								objRawData.SampleID = intSampleID;
								objRawData.SampleName = strSampleName;
								if (!IsNothing(objRawData)) {
									objAnalysisRawData.Add(objRawData);
								}
							}

							strArrValues = strLine.Split(',');
							if (strArrValues.Length > 1) {
								dblXTime = Val(strArrValues(0));
								dblAbsorbance = Val(strArrValues(1));
								objRawData.AddReadings(dblXTime, dblAbsorbance);

								if (blnIsFirstTime == true) {
									dblMinXTime = dblXTime;
									blnIsFirstTime = false;
								}
								dblMaxXTime += dblXTime;
							}
						}
					} else {
						break; // TODO: might not be correct. Was : Exit Do
					}
				}

			}

			if (!IsNothing(objAnalysisRawData)) {
				if (objAnalysisRawData.Count > 0) {
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
			if (!IsNothing(sr)){sr.Close();sr = null;}
			if (!IsNothing(fs)){fs.Close();fs = null;}
			//---------------------------------------------------------
		}
	}

	public void subShowGraphPreview(ref AASGraph PreviewGraph, ref AldysGraph.CurveItem objPreviewCurve, string strRunNumber, clsMethod objclsMethod)
	{
		//=====================================================================
		// Procedure Name        : subShowGraphPreview
		// Parameters Passed     : PreviewGraph,objPreviewCurve,strRunNumber,objclsMethod
		// Returns               : None
		// Purpose               : To plot graph of Time Vs. Absorbance
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 25-Feb-2007 03:05 pm
		// Revisions             : 1
		//=====================================================================
		string strRunNumberFileName;
		double dblXMin;
		double dblXMax;
		AAS203Library.Analysis.clsRawDataCollection objAnalysisRawData;
		int intCounter;
		int intReadingsCounter;
		double dblXTime;
		double dblAbsorbance;
		Color curveColor;
		bool blnIsFirstTime;
		int intRunNumberCounter;

		try {
			//--- To plot graph of Time Vs. Absorbance
			for (intRunNumberCounter = 0; intRunNumberCounter <= objclsMethod.QuantitativeDataCollection.Count - 1; intRunNumberCounter++) {
				if (objclsMethod.QuantitativeDataCollection.Item(intRunNumberCounter).RunNumber == strRunNumber) {
					objAnalysisRawData = objclsMethod.QuantitativeDataCollection(intRunNumberCounter).AnalysisRawData;
				}
			}

			if (!IsNothing(objAnalysisRawData)) {
				if (objAnalysisRawData.Count > 0) {
					blnIsFirstTime = true;
					objPreviewCurve = null;
					PreviewGraph.AldysPane.CurveList.Clear();

					PreviewGraph.XAxisMin = 0.0;
					PreviewGraph.XAxisMax = 100.0;
					//PreviewGraph.YAxisMin = -0.2
					//PreviewGraph.YAxisMax = 1.1

					PreviewGraph.Invalidate();
					PreviewGraph.Refresh();
					Application.DoEvents();

					for (intCounter = 0; intCounter <= objAnalysisRawData.Count - 1; intCounter++) {
						for (intReadingsCounter = 0; intReadingsCounter <= objAnalysisRawData.item(intCounter).Readings.Count - 1; intReadingsCounter++) {
							dblXTime = objAnalysisRawData.item(intCounter).Readings.item(intReadingsCounter).XTime;
							dblAbsorbance = objAnalysisRawData.item(intCounter).Readings.item(intReadingsCounter).Absorbance;

							switch (objAnalysisRawData.item(intCounter).SampleType) {
								case clsRawData.enumSampleType.BLANK:
									curveColor = ClsAAS203.BLANKCOLOR;
								case clsRawData.enumSampleType.STANDARD:
									curveColor = ClsAAS203.STDCOLOR;
								case clsRawData.enumSampleType.SAMPLE:
									curveColor = ClsAAS203.SAMPCOLOR;
							}

							if (blnIsFirstTime) {
								objPreviewCurve = PreviewGraph.StartOnlineGraph(strRunNumber, Color.Red, AldysGraph.SymbolType.NoSymbol, true);
								blnIsFirstTime = false;
								PreviewGraph.PlotPoint(objPreviewCurve, dblXTime, dblAbsorbance);
							} else {
								objPreviewCurve.CL.Add(curveColor);
								PreviewGraph.PlotPoint(objPreviewCurve, dblXTime, dblAbsorbance);
							}
						}
					}
					PreviewGraph.AldysPane.Legend.IsVisible = false;
					PreviewGraph.IsShowGrid = false;
				} else {
					objPreviewCurve = null;
					PreviewGraph.AldysPane.CurveList.Clear();
				}
			} else {
				objPreviewCurve = null;
				PreviewGraph.AldysPane.CurveList.Clear();
			}

			PreviewGraph.Invalidate();
			PreviewGraph.Refresh();
			Application.DoEvents();

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

	////----- Auto Zero
	public void subAutoZero(bool Flag)
	{
		//=====================================================================
		// Procedure Name        :   subAutoZero
		// Description           :   To set Auto Zero for AA,BGC and Emission Mode
		// Purpose               :   
		//                           
		// Parameters Passed     :   Boolean Flag
		// Returns               :   None
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   10.12.06
		// Revisions             :
		//=====================================================================
		try {
			//       Auto_Zero(hwnd, TRUE);

			////-----------------

			// ReinitInstParameters();
			// Inst = GetInstData();
			// if (Inst->Mode==AA) {
			//	AutoZeroAbsMode(hwnd);
			//	if (flag){
			//#If !IN203DLL Then
			//		Get_Instrument_Parameters(&Inst);
			//#End If
			//	  Scroll_Pmt(hwnd,IDC_PMT, -1);
			//	 }
			//	}
			// else if (Inst->Mode==AABGC) {
			//	  ReinitInstParameters();
			//	  Bgc_Zero(hwnd, TRUE);
			//	  ReinitInstParameters();
			//#If !IN203DLL Then
			//		Get_Instrument_Parameters(&Inst);
			//#End If
			//	  if (flag){
			//		 Scroll_Cur(hwnd,IDC_CUR, -1 );
			//		 Scroll_D2Cur(hwnd,IDC_D2CUR, -1 );
			//		 Scroll_Pmt(hwnd,IDC_PMT, -1);
			//		}
			//	}
			//  else if (Inst->Mode==EMISSION){
			//	  ReinitInstParameters();
			//	  Auto_blank_Emission(hwnd, FALSE);
			//     ReinitInstParameters();
			//	}
			// ReinitInstParameters();
			// }

			//if(ReadIniForD2Gain()){
			//           If (IsD2GainOn()) Then
			//		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain OFF");
			//           Else
			//		SetWindowText(GetDlgItem(hwnd,IDC_PBD2GAIN),"D2 Gain ON");
			//}
			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			Application.DoEvents();
			gobjClsAAS203.ReInitInstParameters();
			switch (gobjInst.Mode) {
				case EnumCalibrationMode.AA:
					gobjClsAAS203.funcAutoZeroAbsMode();
					Application.DoEvents();
					blnResetFilterData = true;
				case EnumCalibrationMode.AABGC:
					//gobjClsAAS203.ReInitInstParameters()
					gobjClsAAS203.funcBgc_Zero(true);
					Application.DoEvents();
					//gobjClsAAS203.ReInitInstParameters()
					blnResetFilterData = true;
				case EnumCalibrationMode.EMISSION:
					gobjClsAAS203.Auto_blank_Emission(false);
					Application.DoEvents();
					//Call gobjCommProtocol.funcGetRefBaseVal()
					blnResetFilterData = true;
				//gobjClsAAS203.ReInitInstParameters()
			}
			Application.DoEvents();
			gobjClsAAS203.ReInitInstParameters();

			Application.DoEvents();
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			Application.DoEvents();
		//	
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
	////-----

	public int funcReadLampPosition()
	{
		//=====================================================================
		// Procedure Name        :   funcReadLampPosition
		// Description           :   
		// Purpose               :   to return default lamp position as 0.
		//                           
		// Parameters Passed     :   None
		// Returns               :   an integer holding lamp position
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   04.03.07
		// Revisions             :
		//=====================================================================
		//FILE *fptr = NULL;
		//int lamppos;
		//fptr = fopen("lstlamp.pos","rt");
		//if( fptr ){
		//	fscanf(fptr,"%d",&lamppos);
		//	fclose(fptr);
		//	return lamppos;
		//}
		//        Else
		//	return 1;
		//}

		try {
			return 0;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0;
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

	#Region " Functions for Double Beam "

	//, ByRef blnIsSingleBeam As Boolean)
	public void subSetInstrumentBeamType(enumInstrumentBeamType intInstrumentBeamType, bool blnIsWriteToIni = true)
	{
		//=====================================================================
		// Procedure Name        : subSetInstrumentBeamType
		// Parameters Passed     : enumInstrumentBeamType datatype of intInstrumentBeamType for Double or Single Beam
		// Returns               : None
		// Purpose               : To set the Instrument Beam Type
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 06-Apr-2007 06:45 pm
		// Revisions             : 1
		//=====================================================================
		int intBeamType;

		try {
			//--- To set the Instrument Beam Type
			switch (intInstrumentBeamType) {
				case enumInstrumentBeamType.SingleBeam:
					intBeamType = 0;

					gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam;
				case enumInstrumentBeamType.ReferenceBeam:
					intBeamType = 1;

					gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam;
				case enumInstrumentBeamType.DoubleBeam:
					intBeamType = 2;

					gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam;
			}

			if (blnIsWriteToIni == true) {
				//---Save the User Selected value of Instrument Beam Type in AAS.ini file
				gFuncWriteToINI(SECTION_SYSTEMPARAMETERS, KEY_INSTRUMENT_BEAMTYPE, intBeamType.ToString, INI_SETTINGS_PATH);
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

	public bool funcSelectDoubleBeamType(bool blnIsDoubleBeamType)
	{
		//=====================================================================
		// Procedure Name        : funcSelectDoubleBeamType
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : To set the Instrument Beam Type
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 06-Apr-2007 06:45 pm
		// Revisions             : 1
		//=====================================================================
		//Dim blnIsDoubleBeamType As Boolean
		bool blnIsAA203DNOTFound;

		try {
			//blnIsDoubleBeamType = gobjMessageAdapter.ShowMessage("Select Instrument Beam Type." & vbCrLf & "Press YES For Double Beam" & vbCrLf & "Press NO For Single Beam", "Select Beam Type", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage)
			//Call Application.DoEvents()
			//'---Set Beam Type to Instrument
			if (blnIsDoubleBeamType) {
				subSetInstrumentBeamType(enumInstrumentBeamType.DoubleBeam);
			} else {
				subSetInstrumentBeamType(enumInstrumentBeamType.SingleBeam);
			}

			//'---Set Beam Type to Instrument
			//If Not gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.SELFTEST) Then
			//    blnIsAA203DNOTFound = True
			//Else
			//    blnIsAA203DNOTFound = False
			//End If
			//If blnIsAA203DNOTFound Then
			//    Call gobjMessageAdapter.ShowMessage("The AA 203D (Double Beam Instrument) not found." & vbCrLf & "Application will now exit.", "AAS203D Not Found", MessageHandler.clsMessageHandler.enumMessageType.UnExpectedMessage)
			//    Call Application.DoEvents()
			//    Return False
			//End If

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

	#End Region

	public double Calculate_Analysis_Graph_Param(ref AASGraph Curve, enumChangeAxis GraphAxis)
	{
		//=====================================================================
		// Procedure Name        : Calculate_Analysis_Graph_Param
		// Parameters Passed     : AASGraph Reference
		// Returns               : Double value
		// Purpose               : for calculate a graph parameter
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj Bamb
		// Created               : 09-May-2007 011:05 am
		// Revisions             : 1
		//=====================================================================
		double FrqIntv = 0.0;
		double xmax1 = 0;
		double xmin1 = 0;
		double Fmin = 0;
		double Fmax = 0;
		double Fx = 0;
		int fn;
		int tot1;

		try {
			if (IsNothing(Curve)) {
				//'if there is nothing curve.
				return 0.0;
			}

			xmax1 = Curve.YAxisMax;
			xmin1 = Curve.YAxisMin;
			tot1 = (xmax1 - xmin1) * 60;

			FrqIntv = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, true);
			//FrqIntv = 100

			fn = (xmax1 / FrqIntv);
			Fmax = (double)fn * FrqIntv;
			if (xmax1 > Fmax) {
				Fmax = Fmax + FrqIntv;
			}
			fn = (int)xmin1 / FrqIntv;
			Fmin = (double)fn * FrqIntv;

			if ((xmin1 < Fmin)) {
				Fmin = Fmin - FrqIntv;
			}

			if ((Fmin > xmin1) & (FrqIntv != -1.0)) {
				while ((Fmin > xmin1)) {
					Fmax -= FrqIntv;
				}
			}

			if ((Fmax < xmax1 & FrqIntv != -1.0)) {
				while ((Fmax < xmax1)) {
					Fmax += FrqIntv;
				}
			}

			if ((GraphAxis == enumChangeAxis.xyAxis | GraphAxis == enumChangeAxis.yAxis)) {
				Curve.YAxisMin = Fmin;
				Curve.YAxisMax = Fmax;
				Curve.YAxisStep = FrqIntv;
			}


			xmax1 = Curve.XAxisMax;
			xmin1 = Curve.XAxisMin;
			tot1 = 60;
			Fx = gobjclsStandardGraph.GetInterval(xmax1, xmin1, tot1, true);

			if ((Fx > 0)) {
				fn = xmax1 / Fx;
			} else {
				fn = 0;
			}

			Fmax = fn * Fx;
			if ((xmax1 > Fmax)) {
				Fmax += Fx;
			}

			if ((GraphAxis == enumChangeAxis.xyAxis | GraphAxis == enumChangeAxis.xAxis)) {
				Curve.XAxisMin = xmin1;
				Curve.XAxisMax = Fmax;
				Curve.XAxisStep = gobjclsStandardGraph.GetInterval(Curve.XAxisMax, Curve.XAxisMin, tot1, true);
			}
			Curve.IsShowGrid = true;
			return FrqIntv;

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

	//Public Function Status_Disp_To_Check_Flame() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : Status_Disp
	//    ' Parameters Passed     : None
	//    ' Returns               : None
	//    ' Purpose               : To set gobjInst.Aaf = False is Flame goes OFF
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh
	//    ' Created               : 20-June-2007
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Dim line1 As String
	//    Dim status, st, st1 As Byte
	//    Dim flag As Boolean = True

	//    Try
	//        status = gobjCommProtocol.funcGet_Pneum_Status()

	//        If (status And EnumErrorStatus.SFUEL_ON) Then
	//            flag = True
	//            gobjInst.Aaf = True
	//        Else
	//            flag = False
	//            gobjInst.Aaf = False
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
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

	//Public Function LoadMethod_IQOQPQ_Test_Attachment() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : LoadMethod_IQOQPQ_Test_Attachment
	//    ' Parameters Passed     : None
	//    ' Returns               : None
	//    ' Purpose               : To Load method for IQOQPQ
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 04.07.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim objDtMethodNames As New DataTable
	//    Dim intCounter As Integer
	//    Dim objRow As DataRow
	//    Dim objAllMethodsCollection As AAS203Library.Method.clsMethodCollection

	//    Try
	//        '*********************LoadMethods*****************************
	//        If funcLoadAllMethods(objAllMethodsCollection) Then
	//            If Not IsNothing(objAllMethodsCollection) Then
	//                gobjMethodCollection = Nothing
	//                gobjMethodCollection = New clsMethodCollection
	//                For intCounter = 0 To objAllMethodsCollection.Count - 1
	//                    'If objAllMethodsCollection.item(intCounter).InstrumentBeamType = gintInstrumentBeamType Then
	//                    gobjMethodCollection.Add(objAllMethodsCollection.item(intCounter))
	//                    'End If
	//                Next
	//                Return True
	//            Else
	//                Return False
	//            End If
	//        Else
	//            Return False
	//        End If
	//        '*********************LoadMethods*****************************
	//        objDtMethodNames.Columns.Add(ConstColumnMethodID)
	//        objDtMethodNames.Columns.Add(ConstColumnMethodName)

	//        For intCounter = 0 To gobjMethodCollection.Count - 1
	//            objRow = objDtMethodNames.NewRow
	//            objRow.Item(ConstColumnMethodID) = gobjMethodCollection.item(intCounter).MethodID
	//            objRow.Item(ConstColumnMethodName) = gobjMethodCollection.item(intCounter).MethodName
	//            objDtMethodNames.Rows.Add(objRow)
	//        Next
	//        lstMethodName.DataSource = objDtMethodNames
	//        lstMethodName.DisplayMember = ConstColumnMethodName
	//        lstMethodName.ValueMember = ConstColumnMethodID


	//        Call lstMethodName_SelectedIndexChanged(lstMethodName, EventArgs.Empty)

	//        AddHandler lstMethodName.SelectedIndexChanged, AddressOf lstMethodName_SelectedIndexChanged

	//        Call funcLoadElementsList()
	//        '----Added By Pankaj 11 May 07
	//        rbMethodName.Checked = True
	//        rbMethodName_CheckedChanged2(sender, e)

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        gobjMain.HideProgressBar()
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	public bool CheckValidInstConditions(clsInstrumentParameters objMethod_Instrument_Conditions)
	{
		//=====================================================================
		// Procedure Name        : CheckValidInstConditions
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To validation Instrument parameters
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 01.08.07
		// Revisions             : praveen
		//=====================================================================
		//BOOL CheckValidInstConditions(HWND hwnd,AAINST *temp)
		try {
			//{
			//   char buf[200]="";
			//   if(!strcmpi(temp->elName,""))
			//       {
			//           if(MessageBox(hwnd,"ELEMENT NAME IS BLANK\nDo you want to save the report?","WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//	        return FALSE;
			//       }
			//Dim buf() As String
			if (!(objMethod_Instrument_Conditions.ElementName == "")) {
				//check for element name
				if (gobjMessageAdapter.ShowMessage("ELEMENT NAME IS BLANK. Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
					return false;
				} else {
					return true;
				}
			}
			////if( temp->Inst_Mode >= 1 &&
			//   if(GetInstrument() == AA202){
			//  if(temp->TurNo < 1 || temp->TurNo > 2){
			//	 sprintf(buf,"LAMP NUMBER %d IS INVALID\nDo you want to save the report?",(int)temp->TurNo);
			//	 if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//		return FALSE;
			//	}
			//}
			//else{
			//	if(temp->TurNo < 1 || temp->TurNo > 6){
			//	  sprintf(buf,"TURRET NUMBER %d IS INVALID\nDo you want to save the report?",(int)temp->TurNo);
			//	  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//		return FALSE;
			//	}
			//}
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//checking a turrert num as per 201
				if (objMethod_Instrument_Conditions.TurretNumber < 1 | objMethod_Instrument_Conditions.TurretNumber > 2) {
					if (gobjMessageAdapter.ShowMessage("LAMP NUMBER " + objMethod_Instrument_Conditions.TurretNumber + " IS INVALID." + vbCrLf + "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
						return false;
					} else {
						return true;
					}
				}
			} else {
				if (objMethod_Instrument_Conditions.TurretNumber < 1 | objMethod_Instrument_Conditions.TurretNumber > 6) {
					//checking a turrert num as per other
					if (gobjMessageAdapter.ShowMessage("LAMP NUMBER " + objMethod_Instrument_Conditions.TurretNumber + " IS INVALID." + vbCrLf + "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
						return false;
					} else {
						return true;
					}
				}
			}
			//if( temp->Cur <= 0.0 || temp->Cur > 25.0 ){
			//	sprintf(buf,"LAMP CURRENT IS %0.2f mA\nDo you want to save the report?",(float)temp->Cur);
			//	if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//		return FALSE;
			//}
			if (objMethod_Instrument_Conditions.LampCurrent <= 0.0 | objMethod_Instrument_Conditions.LampCurrent > 25.0) {
				//'check for lamp current bet 0 to 25.
				if (gobjMessageAdapter.ShowMessage("LAMP CURRENT IS " + gobjInst.Current + "mA. " + vbCrLf + "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
					return false;
				} else {
					return true;
				}
			}
			//if( temp->Wv <= 0.0 ){
			//  if(MessageBox(hwnd,"WAVELENGTH IS 0.0 nm\nDo you want to save the report?","WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//	  return FALSE;
			//}
			if (gobjInst.WavelengthCur <= 0.0) {
				//'check for wavelength
				if (gobjMessageAdapter.ShowMessage("WAVELENGTH IS 0.0 nm. " + vbCrLf + "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
					return false;
				} else {
					return true;
				}
			}
			//if( temp->Slit <= 0.0 || temp->Slit > 2.0 ){
			//  sprintf(buf,"SLIT IS %0.2f nm\nDo you want to save the report?",(float)temp->Slit);
			//  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//	  return FALSE;
			//}
			if (objMethod_Instrument_Conditions.SlitWidth <= 0.0 | objMethod_Instrument_Conditions.SlitWidth > 2.0) {
				//'check for slit width bet 0.0 to 2.0
				if (gobjMessageAdapter.ShowMessage("SLIT IS " + objMethod_Instrument_Conditions.SlitWidth + "nm. " + vbCrLf + "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
					return false;
				} else {
					return true;
				}
			}
			//if( temp->D2cur < 100.0 || temp->D2cur >= 300.0 ){
			//  sprintf(buf,"PMT VOLTAGE IS %0.2f V\nDo you want to save the report?",(float)temp->Pmtv);
			//  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//	  return FALSE;
			//}
			if (objMethod_Instrument_Conditions.D2Current < 100.0 | objMethod_Instrument_Conditions.D2Current >= 300.0) {
				//'check for D2 current.
				return true;
				//added by ; dinesh wagh on 29.1.2010
				//code commented by ;dinesh wagh on 29.1.2010
				//-------------------------------------------
				//'If gobjMessageAdapter.ShowMessage("PMT VOLTAGE IS " & objMethod_Instrument_Conditions.PmtVoltage & "V. " & vbCrLf & "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = False Then
				//'    Return False
				//'Else
				//'    Return True
				//'End If
				//-------------------------------------------
			}
			//if( temp->Pmtv <= 0.0 || temp->Pmtv > 1000.0 ){
			//  sprintf(buf,"PMT VOLTAGE IS %0.2f V\nDo you want to save the report?",(float)temp->Pmtv);
			//  if(MessageBox(hwnd,buf,"WARNING",MB_ICONQUESTION | MB_YESNO) == IDNO)
			//	  return FALSE;
			//}
			if (objMethod_Instrument_Conditions.PmtVoltage <= 0.0 | objMethod_Instrument_Conditions.PmtVoltage > 1000.0) {
				//'check for PMT voltage
				if (gobjMessageAdapter.ShowMessage("PMT VOLTAGE IS " + objMethod_Instrument_Conditions.PmtVoltage + "V" + vbCrLf + "Do you want to save the report?", "WARNING", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) == false) {
					return false;
				} else {
					return true;
				}
			}
			//return TRUE;
			return true;
		//}

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	public bool funcExitWindows()
	{
		//=====================================================================
		// Procedure Name        : funcExitWindows
		// Parameters Passed     : None
		// Returns               : True or False
		// Purpose               : To exit from windows
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 19.08.07
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called whenexit from window.
		try {
			SendMessage(HWND_BROADCAST, WM_COMMAND, 51, 0L);
			SendMessage(HWND_BROADCAST, WM_DESTROY, 0L, 0L);

			ExitWindows(0, 0);
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

}

