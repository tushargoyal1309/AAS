using Microsoft.Win32;

class modRegistryOperations
{

	private string[] strRegKeyValueNames;

	private int[] mstrDeviceSerialComm;
	public int gFuncGetAvailbleCommPorts()
	{
		//----------------------------------------------------------------------------
		//Procedure Name:    gFuncGetAvailbleCommPorts
		//Description:       To get the Number of Comports Availble in the System
		//Time/Date  :       4.13 14 Oct'2003
		//Dependencies:      Registry Should Contain the Settings of hardware
		//Author:            Sachin Dokhale
		//Revision:           
		//Revision by Person: 
		//----------------------------------------------------------------------------
		RegistryKey Regkey;
		string[] strAvailableCommPorts;
		string strAvailableCommPorts1;
		int intCommSerial;
		string strCommport;
		string strRegKeyValueName;
		int intCommCount = 1;

		try {
			//--- Open the Key To Check number of Comm Ports Supported By the System
			Regkey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");


			if (Regkey.ValueCount > 0) {
				//--- Send the no of Comm ports Available
				 // ERROR: Not supported in C#: ReDimStatement

				 // ERROR: Not supported in C#: ReDimStatement

				 // ERROR: Not supported in C#: ReDimStatement

			} else {
				 // ERROR: Not supported in C#: ReDimStatement

				 // ERROR: Not supported in C#: ReDimStatement

				gintCommPort(0) = 0;
			}

			if (Regkey.ValueCount > 0) {
				strRegKeyValueNames = Regkey.GetValueNames();
				Array.Sort(strRegKeyValueNames);
				for (intCommSerial = 0; intCommSerial <= Regkey.ValueCount - 1; intCommSerial++) {
					strRegKeyValueName = strRegKeyValueNames(intCommSerial);
					strCommport = (Regkey.GetValue(strRegKeyValueName));
					gintCommPort(intCommSerial) = (int)Mid(strCommport, 4);
				}
			}

			intCommCount = Regkey.ValueCount;

			return intCommCount;

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
			//Close the Key 
			Regkey.Close();
			//---------------------------------------------------------
		}
	}

}
