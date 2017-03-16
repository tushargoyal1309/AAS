using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

public class clsHardwareLock_USB
{
	//=====================================================================
	// Module Name           :   clsHardwareLock
	// Author                :   Sachin Ashtankar
	// Created               :   25 August 2005
	// Revisions             :   1
	//=====================================================================
	//---Note :
	//---Three memory locations of hardware lock i.e. Index 1=Month,2=Day and 3=Year are used for 
	//---storing installation DateTime. These memory locations should not be overriden 
	//---by some other value.

	#Region "DLL's"

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

	[DllImport("sentrydll5.dll")]
	private static int win_read_rtctime_nt95(ref Int16 rbuff, ref byte op)
	{
	}

	[DllImport("sentrydll5.dll")]
	private static int win_set_rtctime_nt95(ref Int16 rbuff, ref byte time)
	{
	}

	[DllImport("sentrydll5.dll")]
	private static int win_write_val_nt95(ref Int16 keybuff, int index1, int value1)
	{
	}

	[DllImport("sentrydll5.dll")]
	private static int win_read_val_nt95(ref Int16 keybuff, int index1)
	{
	}

	#End Region

	#Region "Constructor"
	public clsHardwareLock_USB()
	{
		try {
			int i = 0;

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

			// Fill pass array with your password, which should be hex, refer keyxxxx.txt
			pass(0) = 78;
			pass(1) = 80;
			pass(2) = 67;
			pass(3) = 72;


		} catch (Exception ex) {
			MsgBox("ERROR : In Initialization " + ex.Message);
		}

	}
	#End Region

	#Region "Private Variables"
	private Int16[] rbuff = new Int16[10];
		#End Region
	private byte[] pass = new byte[2];

	#Region "Public Functions"

	public int WriteHardwareKey(string strKey)
	{
		Int16[] int16Signature = new Int16[10];
		Int32 int32TempSignature;
		Int32 temp;
		int stat;
		byte[] strTemp = new byte[19];
		string strString;
		string[] strSignature = new string[22];
		char[] chrKey = new char[22];

		int i;
		int intCounter;
		try {
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



			stat = win_xwrite_nt95(rbuff(0), int16Signature(0), pass(0));
			switch (stat) {
				case 0:
					//            Text5.Text = "Lock Found! Data written Successfully, the one assigned to Signature varibale!!!"
					gobjMessageAdapter.ShowMessage("Lock Found! Key set successfully!!!", "Hardware Lock Check", EnumMessageType.Information);
					return 1;
				case -1:
					// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
					gobjMessageAdapter.ShowMessage("Hardware lock not installed OR " + vbCrLf + " The installed one is not having proper identity", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -2:
					//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
					gobjMessageAdapter.ShowMessage("The Password you have issued is not matching with the one assigned for the Lock attached !", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -3:
					//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
					gobjMessageAdapter.ShowMessage("Sentrymsp.vxd is not found in the current path  ", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -5:
					//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
					gobjMessageAdapter.ShowMessage("Sentry.sys is not started or not installed on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -6:
					//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
					gobjMessageAdapter.ShowMessage(" Sentry.sys could not close its operations on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -7:
					//Text5.Text = " The memory location index entered is out of range (0-29)!"
					gobjMessageAdapter.ShowMessage(" The memory location index entered is out of range (0-29)!", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -8:
					//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
					gobjMessageAdapter.ShowMessage(" The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -9:
					//Text5.Text = " Cannot work on Win3.1!"
					gobjMessageAdapter.ShowMessage(" Cannot work on Win3.1!", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -10:
					//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
					gobjMessageAdapter.ShowMessage(" The KEY passed with this function is not made for the lock attached to the machine !", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				default:
					if (stat < 0) {
						return stat;
					}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			return 0;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public int ReadHardwareKey(string strKey)
	{
		Int16[] int16Signature = new Int16[10];
		Int32 int32TempSignature;
		Int32 temp;
		int stat;
		//eger 'Long
		byte[] strTemp = new byte[19];
		string strString;
		string[] strSignature = new string[22];

		char[] chrKey = new char[22];

		Int16[] Brbuff = new Int16[10];
		int i;
		int intCounter;
		try {
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


			for (i = 0; i <= 11; i++) {
				Brbuff(i) = 0;
			}

			//Fill rbuff with your  key (refer keyxxxx.txt)
			Brbuff(0) = 21334;
			Brbuff(1) = 13910;
			Brbuff(2) = 17232;
			Brbuff(3) = 18477;
			Brbuff(4) = 22097;
			Brbuff(5) = 14645;
			Brbuff(6) = 11600;
			Brbuff(7) = 13622;
			Brbuff(8) = 19274;
			Brbuff(9) = 13874;
			Brbuff(10) = 8224;
			Brbuff(11) = 8224;

			stat = win_xread_nt95(Brbuff(0), pass(0));

			switch (stat) {
				case 0:

					for (i = 0; i <= 11; i++) {
						if ((Brbuff(i) != int16Signature(i))) {
							i = 0;
							break; // TODO: might not be correct. Was : Exit For
						}
					}

					if ((i < 11)) {
						gobjMessageAdapter.ShowMessage("Lock Found! Data read from the lock is not matching with the one assigned to hardware key!", "Hardware Lock Error", EnumMessageType.Information);
						return 0;
					} else {
						// gFuncShowMessage("Hardware Lock", "Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!", modConstants.EnumMessageType.Information)
						return 1;

					}
				case -1:
					// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
					gobjMessageAdapter.ShowMessage("Hardware Lock not installed OR the installed one is not bearing proper identity", "Hardware Lock Error", EnumMessageType.Information);
					return stat;
				case -2:
					//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
					//gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
					return stat;
				case -3:
					//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
					//gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
					return stat;
				case -5:
					//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
					//gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
					return stat;
				case -6:
					//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
					//gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
					return stat;
				case -7:
					//Text5.Text = " The memory location index entered is out of range (0-29)!"
					//gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
					return stat;
				case -8:
					//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
					//gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
					return stat;
				case -9:
					//Text5.Text = " Cannot work on Win3.1!"
					//gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
					return stat;
				case -10:
					//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
					//gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
					return stat;
				default:
					if (stat < 0) {
						return stat;
					}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			//gobjErrorHandler.ErrorDescription = ex.Message
			//gobjErrorHandler.ErrorMessage = ex.Message
			//gobjErrorHandler.WriteErrorLog(ex)
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			return 0;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//---------------------------------------------------------
		}

	}

	public int GetRTCDateTime(ref DateTime RTCDateTime)
	{
		//Public Function GetRTCDateTime() As DateTime
		byte[] time = new byte[7];
		int stat;
		//eger 'Long
		int i;
		int intCounter;
		try {
			stat = win_read_rtctime_nt95(rbuff(0), time(0));
			switch (stat) {
				case 0:
					System.DateTime dtRTCDate;
					dtRTCDate = new System.DateTime((int)"200" + (string)time(6), (int)(string)time(4), (int)(string)time(3), (int)(string)time(2), (int)(string)time(1), (int)(string)time(0));
					RTCDateTime = dtRTCDate;
					return 1;
				case -1:
					// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
					//gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the installed one is not bearing proper identity", modConstants.EnumMessageType.Information)
					return stat;
				case -2:
					//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
					//gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
					return stat;
				case -3:
					//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
					//gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
					return stat;
				case -5:
					//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
					//gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
					return stat;
				case -6:
					//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
					//gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
					return stat;
				case -7:
					//Text5.Text = " The memory location index entered is out of range (0-29)!"
					//gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
					return stat;
				case -8:
					//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
					//gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
					return stat;
				case -9:
					//Text5.Text = " Cannot work on Win3.1!"
					//gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
					return stat;
				case -10:
					//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
					//gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
					return stat;
				default:
					if (stat < 0) {
						return stat;

					}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			//gobjErrorHandler.ErrorDescription = ex.Message
			//gobjErrorHandler.ErrorMessage = ex.Message
			//gobjErrorHandler.WriteErrorLog(ex)
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			return 0;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//---------------------------------------------------------
		}
	}

	public int SetRTCDateTime(DateTime RTCDateTime)
	{
		byte[] time = new byte[7];
		int stat;
		//eger 'Long
		try {
			string strYear;

			strYear = RTCDateTime.Year.ToString;

			time(0) = RTCDateTime.Second;
			//&H22 'Seconds
			time(1) = RTCDateTime.Minute;
			//&H2 'minutes
			time(2) = RTCDateTime.Hour;
			// &H1  'hours
			time(3) = RTCDateTime.Day;
			//&HA 'Date of  month     hex 11 means 17 decimal
			time(4) = RTCDateTime.Month;
			//&H2 'Month of year
			time(5) = RTCDateTime.DayOfWeek;
			//&H6 'Day of Week
			time(6) = (int)Microsoft.VisualBasic.Mid(strYear, 3);
			//&H3  'Year
			time(7) = 0;


			stat = win_set_rtctime_nt95(rbuff(0), time(0));
			switch (stat) {
				case 0:

					return 1;
				case -1:
					// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
					//gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the installed one is not bearing proper identity", modConstants.EnumMessageType.Information)
					return stat;
				case -2:
					//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
					//gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
					return stat;
				case -3:
					//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
					//gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
					return stat;
				case -5:
					//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
					//gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
					return stat;
				case -6:
					//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
					//gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
					return stat;
				case -7:
					//Text5.Text = " The memory location index entered is out of range (0-29)!"
					//gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
					return stat;
				case -8:
					//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
					//gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)Return stat
					return stat;
				case -9:
					//Text5.Text = " Cannot work on Win3.1!"
					//gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
					return stat;
				case -10:
					//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
					//gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
					return stat;
				default:
					if (stat < 0) {
						return stat;
					}
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			//gobjErrorHandler.ErrorDescription = ex.Message
			//gobjErrorHandler.ErrorMessage = ex.Message
			//gobjErrorHandler.WriteErrorLog(ex)
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
			//---------------------------------------------------------
			return 0;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//---------------------------------------------------------
		}
	}

	public bool SetValue(int intIndex, int intValue)
	{
		int stat;
		//eger 'Long
		try {
			stat = win_write_val_nt95(rbuff(0), intIndex, intValue);
			if (stat >= 0) {
				return true;
			} else {
				return false;
			}
		} catch (Exception ex) {
		//---------------------------------------------------------
		//Error Handling and logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//---------------------------------------------------------
		}
	}

	public int GetValue(int intIndex)
	{
		int stat;
		//eger 'Long
		try {
			stat = win_read_val_nt95(rbuff(0), intIndex);
			return stat;
		} catch (Exception ex) {
		//---------------------------------------------------------
		//Error Handling and logging
		//gobjErrorHandler.ErrorDescription = ex.Message
		//gobjErrorHandler.ErrorMessage = ex.Message
		//gobjErrorHandler.WriteErrorLog(ex)
		//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			//If CONST_CREATE_EXECUTION_LOG = 1 Then
			//    gobjErrorHandler.WriteExecutionLog()
			//End If
			//---------------------------------------------------------
		}
	}

	public bool WriteCurrentDateTime()
	{
		//---Note :
		//---Three memory locations of hardware lock i.e. Index 1,2 and 3 are used for 
		//---storing installation DateTime. 
		//---This function writes the current DateTime in Real Time Clock of Hardware Lock and 
		//---in above three memory  locations.
		try {
			DateTime CurrentDate = new DateTime();
			bool blnSet = false;
			CurrentDate = System.DateTime.Now();
			if (SetRTCDateTime(CurrentDate) > 0) {
				//---Set same date into following mem locations
				//--- Memory Location 1 = Month of CurrentDate
				blnSet = SetValue(1, CurrentDate.Month);
				if (blnSet == true) {
					//--- Memory Location 2 = Day of CurrentDate
					blnSet = SetValue(2, CurrentDate.Day);
					if (blnSet == true) {
						//--- Memory Location 3 = Year of CurrentDate
						blnSet = SetValue(3, CurrentDate.Year);
						return blnSet;
					} else {
						return false;
					}
				} else {
					return false;
				}
			} else {
				return false;
			}
		} catch (Exception ex) {
			MsgBox(ex.Message.ToString());
			return false;

		} finally {
		}
	}

	public DateTime GetMemoryDate()
	{
		////--- return the Memorise date, Stored into hardware lock. 
		try {
			int intDay = 0;
			int intMonth = 0;
			int intYear = 0;

			//---Getting month part
			intMonth = GetValue(1);
			if (intMonth > 0) {
				//---Getting day part
				intDay = GetValue(2);
				if (intDay > 0) {
					//---Getting year part
					intYear = GetValue(3);
					return new DateTime(intYear, intMonth, intDay);
				}
			}
		} catch (Exception ex) {
			MsgBox(ex.Message.ToString());

		} finally {
		}
	}

	public bool GetDifference(ref int RTCTimeDifference)
	{
		////----- Modified by Sachin Dokhale

		//--- This function Calculate the difference between the installation Date And
		//--- Current Real time Clock Date in no. of days.
		try {
			DateTime MemoryDate = new DateTime();
			DateTime RTCDate = new DateTime();
			int intGetRTCStatus;

			//---Installation Date
			MemoryDate = GetMemoryDate();
			//---Real Time Date
			//RTCDate = GetRTCDateTime()
			intGetRTCStatus = GetRTCDateTime(RTCDate);

			//Return RTCDate.Subtract(MemoryDate).Days
			if (intGetRTCStatus > 0) {
				RTCTimeDifference = RTCDate.Subtract(MemoryDate).Days;
				return true;
			} else {
				return false;
			}


		} catch (Exception ex) {
			MsgBox(ex.Message);
			return false;

		} finally {
		}
	}
	#End Region

}
