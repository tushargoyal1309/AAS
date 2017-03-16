public class clsRS232Main
{
	//Inherits clsRS232

	#Region " Class Member Variables "

	private bool mblnTimeOut = false;

	private bool mblnReadComplete = false;

	private byte[] bytBuffer = new byte[6];
	private long mlngBaudRate;
	private Int16 mintParityBits;
	private Int16 mintStopBits;

	private Int16 mintDataBits;
	#End Region

	#Region " Constructors "

	public clsRS232Main(long lngBaudRate, Int16 intParityBits, Int16 intStopBits, Int16 intDataBits)
	{
		//strPath = Mid(strPath, 1, strPath.Length - (strPath.Length - InStrRev(strPath, "\", strPath.Length, CompareMethod.Text)))
		//INI_SETTINGS_PATH = strPath '& "RS232Settings.ini"
		mlngBaudRate = lngBaudRate;
		mintParityBits = intParityBits;
		mintStopBits = intStopBits;
		mintDataBits = intDataBits;
	}

	#End Region

	#Region " Public Enums, Events, Constants, Structures.. "

	public enum CommErrorCode
	{
		CommNotOpen = 1,
		ReceiveBlockError = 2
	}

	public event  CommError;

	public event  CommStatus;

	#End Region

	#Region " Private Functions "

	private byte gFunclongtobyte(long lngparameter)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFunclongtobyte
		//Description:       To Send back the Check Sum byte for the current calculaed Block of Bytes
		//Parameters :       Added Block bytes Data 
		//Time/Date  :       1st Oct 2003
		//Dependencies:      a calculated value should be provided to recieve the check sum
		//Author:            NileshS
		//Revision:          
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		long data = lngparameter;
		//4294967295 '65518 '1183 '65535 '255 '4008636142 '15658734 '16777215 '2147483647 '4294967294 '1234567890 '
		long[] multfact = new long[4];
		int i;
		byte[] longtobyte = new byte[3];

		try {
			multfact(0) = 0;
			multfact(1) = (Math.Pow(16, 1)) * 15 + 15;
			multfact(2) = (Math.Pow(16, 3)) * 15 + (Math.Pow(16, 2)) * 15;
			multfact(3) = (Math.Pow(16, 5)) * 15 + (Math.Pow(16, 4)) * 15;
			multfact(4) = (Math.Pow(16, 7)) * 15 + (Math.Pow(16, 6)) * 15;

			for (i = 1; i <= 4; i++) {
				//If (data And multfact(i)) > 255 Then
				// multfact(i - 1) = multfact(i - 1) - 1
				//End If

				longtobyte(i - 1) = (data & multfact(i)) / (multfact(i - 1) + 1);
				//MessageBox.Show(longtobyte(i - 1), "Long to Byte")
			}

			return longtobyte(0);

		//'Byte to long Conversion
		//Dim bytetolong As Long = 0
		//For i = 0 To 3
		//    bytetolong += CLng(longtobyte(i)) * (16 ^ (i * 2))
		//Next i
		//MessageBox.Show(bytetolong, "Long Value")

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

	private bool funcConstructCommandBlock(ref byte[] bytArray, Int32 intCommand, Int32 intParameter1, Int32 intParameter2, Int32 intParameter3)
	{
		//-----------------------------------------------------------------------------------------
		//Procedure Name:    funcConstructCommandBlock
		//Description:       Function used to genereate a Block of byte array for the Tx 
		//Parameters :       byref Byte Array , Command , parameters
		//Time/Date  :       9.33 13 Oct' 2003
		//Dependencies:      A proper command and parameters should be provided
		//Author:            Mandar
		//Revision:
		//Revision by Person:
		//-----------------------------------------------------------------------------------------
		Int16 intCount;
		long lngVal;

		try {
			bytArray(0) = (byte)0x32;
			//50     '// Start of Block
			bytArray(1) = (byte)intCommand;
			bytArray(2) = (byte)intParameter1;
			bytArray(3) = (byte)intParameter2;
			bytArray(4) = (byte)intParameter3;
			bytArray(5) = (byte)0;
			//       '/* Checksum	    */
			bytArray(6) = (byte)0x20;
			//32 '166 'cnyte("A")  '		/* Blank Spcae*
			bytArray(7) = (byte)0x34;
			//52 'Asc("4") '4';	'	/* End of Block     */

			for (intCount = 0; intCount <= 7; intCount += 1) {
				lngVal += bytArray(intCount);
			}

			//---conversion of long to byte
			byte bytConverted;
			lngVal = 0 - lngVal;
			bytConverted = gFunclongtobyte(lngVal);

			if (bytConverted != 0) {
				//-----------change by Rahul B.
				//bytConverted = CByte(256 - bytConverted) '256
				//-----------------------------
				//bytConverted = CByte(lngVal)  '256
			}
			//--- Add the Check Sum bit
			//------commented by Rahul
			bytArray(5) = bytConverted;
			//---------------------

			return true;

		//added and commented by kamal
		//----------------------------
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

	#Region " Serial Communication Functions "

	public bool gFuncOpenCommPort(int intComPortIn, bool blnComPortKnown)
	{
		//-----------------------------------------------------------------
		//Procedure Name :   gFuncOpenCommPort
		//Description    :   To open the communication port of the 
		//                   PC for the data transaction    
		//Parameters     :   Port Number, boolean flag
		//Time/Date      :   5/9/06
		//Dependencies   :   Comm port of the pc should present
		//Author         :   Rahul B.
		//Revision       :   2
		//Revision by    :   Mangesh  
		//-----------------------------------------------------------------
		int intCommPort;

		try {
			gFuncOpenCommPort = false;

			intCommPort = intComPortIn;

			if (mrs232.IsPortAvailable(intCommPort) == false)
				return false;

			 // ERROR: Not supported in C#: WithStatement


			//--- Open Port 
			mrs232.Open();

			if (mrs232.Opened) {
				gFuncOpenCommPort = true;
			} else {
				gFuncOpenCommPort = false;
			}

		//added and commented by kamal
		//----------------------------
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
		}
	}

	public bool gFuncTransmitCommand(Int32 intCommand, Int32 intParameter1, Int32 intParameter2, Int32 intParameter3)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncTransmitCommand
		//Description:       Function is used to send the transmit Command to the Tx Buffer
		//Parameters :       Comand, Parameter1, Parameter2, Parameter3
		//Time/Date  :       5/9/06
		//Dependencies:      A proper command and parameters should be provided
		//Author:            Rahul B.
		//Revision:      
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		byte[] bytArray = new byte[6];
		Int16 intCount = 0;

		try {
			//--- ReSet the Boolean flags 
			mblnReadComplete = false;
			mblnTimeOut = false;

			// modified by sns on 26Mar07
			subTime_Delay(14);
			//Added by pankajon 12 sep 07

			//Call subTime_Delay(20)' by pankajon 12 sep 07

			//---funcPeekMssage is added by Deepak B. on 13.08.07 for synchronous messages processing
			//For intCount = 0 To 5 'By Pankaj 12 sep 07
			//mrs232.funcPeekMessage()
			//Next
			//-------

			//---Clear the array contenets first
			for (intCount = 0; intCount <= 7; intCount++) {
				bytBuffer(intCount) = 0;
				bytArray(intCount) = 0;
			}

			if (!funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3)) {
				return false;
				return;
			}

			mrs232.Write(bytArray);
			//System.Windows.Forms.Application.DoEvents() ''Added by praveen as par sachin ,for faster communication

			return true;

		//added and commented by kamal
		//----------------------------
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

	public bool gFuncReadBuffer(ref byte[] bytarray, long lngInTime)
	{
		//---------------------------------------------------------------------------------------
		//Procedure Name :   gFuncReadBuffer
		//Description    :   To read the Specified bits of data from the Rx Buffer
		//Parameters     :   Byte Array & lngInTime
		//Time/Date      :   
		//Dependencies   :   Comm port should be available   
		//Author         :   Santosh
		//Revision       :          
		//Revision by    :   Santosh
		//---------------------------------------------------------------------------------------
		byte[] bytBuff;
		long lngcounter;
		int intcount;
		long lngTmr1;
		long lngTmr2;

		try {
			lngTmr1 = System.DateTime.Now.Ticks / 10000;
			while ((true)) {
				//---funcPeekMessage is added by Deepak B. on 13.08.07 for synchronous messages processing
				//mrs232.funcPeekMessage() 'By Pankaj for vc comm
				//-------
				lngTmr2 = System.DateTime.Now.Ticks / 10000;
				if ((long)lngTmr2 - lngTmr1 < lngInTime) {
					if (mrs232.Read(bytBuff)) {
						//--- Check for the data
						if (bytBuff.Length >= 8) {
							bytarray = bytBuff;
							return true;
							break; // TODO: might not be correct. Was : Exit Do
						}
					}
				// lngInTime timer over
				} else {
					return false;
					break; // TODO: might not be correct. Was : Exit Do
				}
				//System.Windows.Forms.Application.DoEvents()
				mrs232.funcPeekMessage();
				//Added by pankaj for vc dll
			}

		//added and commented by kamal
		//----------------------------
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
			//System.Windows.Forms.Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public void subTime_Delay(long lngTimeInMSeconds)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    subTime_Delay
		//Description:       To generate delay between two successive REad or Write Oerations
		//Parameters :       Time in MiliSeconds, ConstManipulate = 10000 to get time in milliseconds
		//Time/Date  :       3.33 13 oct 2003
		//Dependencies:      Its all depend On God ... if he supplies ticks, delay works else we have manipulated it to make it work
		//Author:            Mandar
		//Revision:
		//Revision by Person: Rahul B.
		//--------------------------------------------------------------------------------------
		long lngTimeDelay;
		long lng;
		long lng1;
		Int16 intCount;
		long ConstManipulate = 10000;
		// this will manipulate tick count for each mili second

		//Note: Ticks are being calculated at the interval of 100 nano seconds hence calculated the factor to be devided as 10000

		try {
			lngTimeDelay = (long)System.DateTime.Now.Ticks / ConstManipulate;
			lngTimeInMSeconds = lngTimeDelay + lngTimeInMSeconds;

			while (lngTimeDelay < lngTimeInMSeconds) {
				//--- This loop will execute until the delay condition gets satisfied
				//For intCount = 1 To 100
				//intCount = intCount + 1
				//Next
				//Application.DoEvents()
				mrs232.funcPeekMessage();
				//System.Windows.Forms.Application.DoEvents()
				lngTimeDelay = (long)System.DateTime.Now.Ticks / ConstManipulate;
				//lng1 = lngTimeInMSeconds - GetTickCount()
				//Application.DoEvents()
				//System.Windows.Forms.Application.DoEvents()
			}

		//added and commented by kamal on 19March2004
		//----------------------------
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

	public bool gFuncIsPortOpen()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncIsPortOpen
		//Description:       To Check is port open by our EXE
		//Parameters :       None
		//Time/Date  :       6.25 13 Oct 2003
		//Dependencies:      Class should be instanciated Prior
		//Author:            Mandar
		//Revision:
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		try {
			if (mrs232.Opened == true) {
				gFuncIsPortOpen = true;
			} else {
				gFuncIsPortOpen = false;
			}
		//added and commented by kamal on 19March2004
		//----------------------------
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

	public bool gFuncISPortAvailable(int intPortNumber)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncISPortAvailable
		//Description:       To Check whether the port is available or not For communication
		//Parameters :       None
		//Time/Date  :       6.32 13 Oct 2003
		//Dependencies:      clsRS232 Class and if applicable At least ONE Comm Port ( joking... )
		//Author:            Mandar
		//Revision:
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		try {
			if (mrs232.IsPortAvailable(intPortNumber)) {
				return true;
			} else {
				return false;
			}

		//added and commented by kamal on 19March2004
		//----------------------------
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

	public bool gFuncCloseComm()
	{
		try {
			if (mrs232.Opened == true) {
				mrs232.Close();
				return true;
			}

		//added and commented by kamal on 19March2004
		//----------------------------
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

	public bool gFuncReceiveData(ref byte[] bytArray, long lngInTime)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gFuncReceiveData
		//Description	    :   To Retrieve the data in the Input Buffer
		//Parameters 	    :   Boolean Double Processing and Time delay in passed as Long
		//Time/Date  	    :   15.50  17 feb 2004
		//Dependencies	    :   port should be open 
		//Author		        :   Santosh
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		//Dim bytArray(7) As Byte
		//-- Creating a thread for the timeout event
		//Dim objTimeOutThread As New ThreadTimeOut()
		//Dim otter As New ThreadStart(AddressOf objTimeOutThread.REadTimeOut)
		//Dim oThread As New Thread(otter)

		try {
			if (!gFuncReadBuffer(bytArray, lngInTime)) {
				//If Not gFuncReadBuffer_test(bytArray, lngInTime) Then
				//--- Check for the byte array
				//Exit Try
				//---changed by deepak 21.06.07
				//System.Windows.Forms.Application.DoEvents() ''Added by praveen as par sachin ,for faster communication
				return false;
			} else {
				//--- Check for the array 
				if (!FuncValidateBlock(bytArray)) {
					//Exit Try
					//---changed by deepak 21.06.07
					return false;
				}
			}

			return true;

		//added and commented by kamal
		//----------------------------
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

	private bool FuncValidateBlock(byte[] bytArray)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    FuncValidateBlock
		//Description:       Validation are to made with respect to the recieved Block From the Rx Buffer
		//Parameters :       Byte array
		//Time/Date  :       9.37 13 Oct 2003
		//Dependencies:      Block should present
		//Author:            Mandar
		//Revision:
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		try {
			if (UBound(bytArray) == 7) {

				if ((int)bytArray(0) == 50 & (int)bytArray(7) == 52) {
					//If CInt(bytArray(1)) = EnumUVProtocol.Ret_Ack Or _
					//CInt(bytArray(1)) = EnumUVProtocol.Reset_Ack Or _
					//CInt(bytArray(1)) = EnumUVProtocol.Data Or _
					//CInt(bytArray(1)) = EnumUVProtocol.CMD_Acknowledge Or _
					//CInt(bytArray(1)) = EnumUVProtocol.Spect_End Or _
					//CInt(bytArray(1)) = EnumUVProtocol.CMD_End Then

					//'--- Get the parameters
					//mbytCommand = bytArray(1)
					//mbytParameter1 = bytArray(2)
					//mbytParameter2 = bytArray(3)
					//mbytParameter3 = bytArray(4)
					//mbytParameter4 = bytArray(5)
					int intCount;
					long lngVal;
					for (intCount = 0; intCount <= 7; intCount += 1) {
						lngVal += bytArray(intCount);
					}
					lngVal = lngVal - bytArray(5);
					byte bytConverted;

					//---conversion of long to byte
					lngVal = 0 - lngVal;
					bytConverted = gFunclongtobyte(lngVal);
					if (bytConverted == bytArray(5)) {
						return true;
					} else {
						return false;
					}
				}
			}

		//added and commented by kamal
		//----------------------------
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

	public bool gFuncReadBuffer_test(ref byte[] bytarray, long lngInTime)
	{
		//======Written by Deepak
		try {
			return mrs232.gFuncReadBuffer_test(bytarray, lngInTime);
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

	#Region " Serial Communication functions for AutoSampler "

	public bool gFuncOpenCommPort2(int intComPortIn, long lngBaudRateIn, int intParityBitIn, int intStopBitIn, int intDataBitIn)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncOpenCommPort2
		//Description:       To open the 2nd communication port of the PC for the data transmission 
		//Parameters :       gintCommPortSelected2 is globaly affected
		//Time/Date  :       
		//Dependencies:      2nd Comm port of the pc should present
		//Author:            Santosh
		//Revision:          
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		try {
			gFuncOpenCommPort2 = false;

			if (mrs232.IsPortAvailable(intComPortIn) == false)
				return;

			 // ERROR: Not supported in C#: WithStatement


			//--- Open Port 
			mrs232.Open2();

			if (mrs232.Opened2) {
				//gintCommPortSelected2 = intComPortIn  '--- For further use
				gFuncOpenCommPort2 = true;
			} else {
				gFuncOpenCommPort2 = false;
			}

		//----------------------------
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

		}

	}

	public bool gFuncCloseComm2()
	{
		try {
			gFuncCloseComm2 = false;
			if (mrs232.Opened2 == true) {
				mrs232.Close2();
				gFuncCloseComm2 = true;
			}
		//added and commented by kamal on 19March2004
		//----------------------------
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

	public bool gFuncReadBuffer2(ref byte[] bytarray, long lngInTime)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name :   gFuncReadBuffer2
		//Description    :   To read the Specified bits of data from the Rx Buffer of 2nd comm port
		//Parameters     :   Byte Array & lngInTime
		//Time/Date      :   
		//Dependencies   :   2nd Comm port should be available & opened   
		//Author         :   Santosh
		//Revision       :          
		//Revision by Person:Santosh
		//--------------------------------------------------------------------------------------
		gFuncReadBuffer2 = false;
		try {
			byte[] bytBuff;
			long lngcounter;
			int intcount;
			long lngTmr1;
			long lngTmr2;

			lngTmr1 = System.DateTime.Now.Ticks / 10000;
			//---
			while ((true)) {
				//Application.DoEvents()
				lngTmr2 = System.DateTime.Now.Ticks / 10000;
				if ((long)lngTmr2 - lngTmr1 < lngInTime) {
					if (mrs232.ReadByte2(bytBuff)) {
						//--- Check for the data
						if (bytBuff.Length >= 1) {
							bytarray = bytBuff;
							gFuncReadBuffer2 = true;
							break; // TODO: might not be correct. Was : Exit Do
						}

					}
				// lngInTime timer over
				} else {
					gFuncReadBuffer2 = false;
					break; // TODO: might not be correct. Was : Exit Do
				}
			}


		//added and commented by kamal
		//----------------------------
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


	public bool gFuncReceiveByte2(ref byte bytCommandReceived, long lngInTime)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gFuncReceiveByte2
		//Description	    :   To Retrieve the data in the Input Buffer
		//Parameters 	    :   Boolean Double Processing and Time delay in passed as Long
		//Time/Date  	    :   15.50  17 feb 2004
		//Dependencies	    :   port should be open 
		//Author		        :   Santosh
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		byte[] bytArray = new byte[0];

		gFuncReceiveByte2 = false;

		try {
			if (gFuncReadBuffer2(bytArray, lngInTime)) {
				bytCommandReceived = bytArray(0);
			}
			gFuncReceiveByte2 = true;

		//added and commented by kamal
		//----------------------------
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

	public bool gFuncTransmitByte2(byte bytCommandTransmit)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncTransmitByte2
		//Description:       Function is used to send the transmit character to 2nd comm port selected for autosampler
		//Parameters :       
		//Time/Date  :       070404 19.29 pm
		//Dependencies:      
		//Author:            Santosh
		//Revision:      
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		byte[] bytArray = new byte[0];
		Int16 intCount = 0;

		gFuncTransmitByte2 = false;

		try {
			//--- Clear the array contenets first
			subTime_Delay(10);

			bytArray(0) = bytCommandTransmit;

			mrs232.WriteByte2(bytArray);
			gFuncTransmitByte2 = true;

		//added and commented by kamal
		//----------------------------
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

	public bool gFuncIsPortOpen2()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncIsPortOpen2
		//Description:       To Check is port open by our EXE
		//Parameters :       None
		//Time/Date  :       070404
		//Dependencies:     
		//Author:            santosh
		//Revision:
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		try {
			if (mrs232.Opened2 == true) {
				gFuncIsPortOpen2 = true;
			} else {
				gFuncIsPortOpen2 = false;
			}
		//added and commented by kamal on 19March2004
		//----------------------------
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

	#End Region


}
