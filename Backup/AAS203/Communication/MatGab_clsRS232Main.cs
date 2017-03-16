
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
	private static bool mblnIsNeedReceive = false;
	//Public Shared mCommflag As Boolean = False '10.12.07
		//10.12.07
	public static bool mInCommu = false;
		//10.12.07
	public static bool gblnInCommProcess = false;
		//10.12.07
	public static long glngProcTimeInMSec;

	//Private InCommu As Boolean

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

	#Region " Public Properties, Enums, Events, Constants, Structures.. "

	public enum CommErrorCode
	{
		CommNotOpen = 1,
		ReceiveBlockError = 2
	}

	public event  CommError;

	public event  CommStatus;

	//Public Shared ReadOnly Property IsCommuOk() As Boolean
	//    Get
	//        Return mCommflag
	//    End Get
	//    'Set(ByVal Value As Boolean)
	//    '    mCommflag = Value
	//    'End Set
	//End Property   '10.12.07

	public static bool IsNeedReceive {
		get { return mblnIsNeedReceive; }
		set { mblnIsNeedReceive = Value; }
	}
	//10.12.07

	public static bool IsInCommu {
//Return mInCommu
		get { return gblnInCommProcess; }
	}
	//Set(ByVal Value As Boolean)
	//    mInCommu = Value
	//End Set
	//10.12.07

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
			mblnIsNeedReceive = true;
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
		//Parameters :       Command, Parameter1, Parameter2, Parameter3
		//Time/Date  :       5/9/06
		//Dependencies:      A proper command and parameters should be provided
		//Return             True/False
		//Author:            Sachin Dokhale
		//Revision:      
		//Revision by Person:
		//--------------------------------------------------------------------------------------
		try {
			//mrs232.funcPeekMessage() '10.12.07
			if (gblnSetSpeedIssue == true) {
				return gFuncTransmitCommand_Speed(intCommand, intParameter1, intParameter2, intParameter3);
			} else {
				return gFuncTransmitCommand_Orig(intCommand, intParameter1, intParameter2, intParameter3);

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
	public bool gFuncTransmitCommand_Orig(Int32 intCommand, Int32 intParameter1, Int32 intParameter2, Int32 intParameter3)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncTransmitCommand_Orig
		//Description:       Function is used to send the transmit Command to the Tx Buffer
		//Parameters :       Command, Parameter1, Parameter2, Parameter3
		//Time/Date  :       5/9/06
		//Dependencies:      A proper command and parameters should be provided
		//Return             True/False
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
			//Call subTime_Delay(18) 'Added by pankajon 12 sep 07

			subTime_Delay(20);

			//---funcPeekMssage is added by Deepak B. on 13.08.07 for synchronous messages processing
			//For intCount = 0 To 5 'By Pankaj 12 sep 07
			//mrs232.funcPeekMessage()
			//Next
			//-------

			//---Clear the array contenets first
			//For intCount = 0 To 7
			//    bytBuffer(intCount) = 0
			//    bytArray(intCount) = 0
			//Next

			if (!funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3)) {
				return false;
				return;
			}

			mrs232.Write(bytArray);

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

	public bool gFuncTransmitCommand_Speed(Int32 intCommand, Int32 intParameter1, Int32 intParameter2, Int32 intParameter3)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    gFuncTransmitCommand_Speed
		//Description:       Function is used to send the transmit Command to the Tx Buffer
		//Parameters :       Command, Parameter1, Parameter2, Parameter3
		//Time/Date  :       5/9/06
		//Dependencies:      A proper command and parameters should be provided
		//Return             True/False
		//Author:            
		//Revision:      
		//Revision by Person:
		//--------------------------------------------------------------------------------------

		//BOOL  Transmit(BYTE command, BYTE para1, BYTE para2, BYTE para3)
		//{
		//BOOL	flag=FALSE;

		//        If (InCommu) Then
		//	 return FALSE;

		//  InCommu =TRUE;

		//	Construct_Block(command, para1, para2, para3);

		//  flag = TransBlock();

		//  InCommu =FALSE;
		//return flag;
		//}
		int tout = CONST_LONG_DELAY;

		byte[] bytArray = new byte[6];
		try {
			if (mInCommu == true)
				return false;
			//10.12.07
			if (gblnInCommProcess == true)
				return false;
			//10.12.07
			mInCommu = true;
			//10.12.07   
			gblnInCommProcess = true;
			//10.12.07
			glngProcTimeInMSec = CONST_LONG_DELAY;
			//10.12.07
			bool flag = false;
			subTime_Delay(1);
			funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3);
			flag = mrs232.funcTransBlock(bytArray, tout);
			//Application.DoEvents() 
			mInCommu = false;
			//10.12.07
			//gblnInCommProcess = False           '10.12.07
			return flag;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mInCommu = false;
			glngProcTimeInMSec = 0;
			gblnInCommProcess = false;
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


	public bool gFuncReadBuffer_orig(ref byte[] bytarray, long lngInTime)
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
			//lngTmr1 = System.DateTime.Now.Ticks / 10000
			//Do While (True)
			//    '---funcPeekMessage is added by Deepak B. on 13.08.07 for synchronous messages processing
			//    'mrs232.funcPeekMessage() 'By Pankaj for vc comm
			//    '-------
			//    lngTmr2 = System.DateTime.Now.Ticks / 10000
			//    If CLng(lngTmr2 - lngTmr1) < lngInTime Then
			//        If mrs232.Read(bytBuff) Then
			//            '--- Check for the data
			//            If bytBuff.Length >= 8 Then
			//                bytarray = bytBuff
			//                Return True
			//                Exit Do
			//            End If
			//        End If
			//    Else ' lngInTime timer over
			//        Return False
			//        Exit Do
			//    End If
			//    Erase bytBuff
			//    'System.Windows.Forms.Application.DoEvents()
			//    'mrs232.funcPeekMessage() 'Added by pankaj for vc dll
			//Loop
			//--- Added by Sachin Dokhale 
			//If Not mCommflag Then Return False
			//Erase bytarray
			//lngTmr1 = System.DateTime.Now.Ticks / 10000

			//Do While (True)
			//    '---funcPeekMessage is added by Deepak B. on 13.08.07 for synchronous messages processing
			//    'mrs232.funcPeekMessage() 'By Pankaj for vc comm
			//    '-------
			//    lngTmr2 = System.DateTime.Now.Ticks / 10000
			//    If CLng(lngTmr2 - lngTmr1) < lngInTime Then
			//        'If mrs232.Read(bytBuff) Then
			//        '    '--- Check for the data
			//        '    If bytBuff.Length >= 8 Then
			//        '        bytarray = bytBuff
			//        '        Return True
			//        '        Exit Do
			//        '    End If
			//        'End If

			//    Else ' lngInTime timer over
			//        Return False
			//        Exit Do
			//    End If
			//    Erase bytBuff
			//    'System.Windows.Forms.Application.DoEvents()
			//    'mrs232.funcPeekMessage() 'Added by pankaj for vc dll
			//Loop

			if (mrs232.Read(bytBuff, lngInTime)) {
				//--- Check for the data
				//If bytBuff.Length >= 8 Then
				bytarray = bytBuff;
				return true;
				//End If
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
			bytBuff = null;
			//System.Windows.Forms.Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public bool gFuncResumeProcess()
	{
		long lngTimeDelay;
		long lngTimeDelay_W;
		long lng;
		long lng1;
		Int16 intCount;
		long ConstManipulate = 10000;
		// this will manipulate tick count for each mili second

		try {
			//Return mobjCommdll.gFuncTransmitCommand(intCommand, intPar1, intPar2, intPar3)
			lngTimeDelay = 0;
			gFuncResumeProcess = false;
			lngTimeDelay_W = (long)System.DateTime.Now.Ticks / ConstManipulate;
			lngTimeDelay_W = lngTimeDelay_W + glngProcTimeInMSec;

			while (lngTimeDelay < lngTimeDelay_W) {
				//--- This loop will execute until the delay condition gets satisfied
				//For intCount = 1 To 100
				//intCount = intCount + 1
				//Next
				Application.DoEvents();
				clsRS232.funcPeekMessage();
				//System.Windows.Forms.Application.DoEvents()
				lngTimeDelay = (long)System.DateTime.Now.Ticks / ConstManipulate;
				//lng1 = lngTimeInMSeconds - GetTickCount()
				//Application.DoEvents()
				//System.Windows.Forms.Application.DoEvents()
				//If (Me.IsInCommu = False) AndAlso (mInCommu = False) Then
				if ((this.IsInCommu == false) & (clsRS232.mCommflag == true)) {
					//If (Me.IsInCommu = False) And (clsRS232.mCommflag = True) Then 'by pankaj on 1 Feb 08
					return true;
				}
			}
			if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
				return true;
			}

			clsRS232.funcPeekMessage();
			return false;
		//If Me.IsInCommu = False Then
		//    Return True
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
				clsRS232.funcPeekMessage();
				//System.Windows.Forms.Application.DoEvents()
				lngTimeDelay = (long)System.DateTime.Now.Ticks / ConstManipulate;
				//lng1 = lngTimeInMSeconds - GetTickCount()
				//Application.DoEvents()
				System.Windows.Forms.Application.DoEvents();
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

	public bool gFuncReceiveData_test(ref byte[] bytArray, long lngInTime)
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
			if (!gFuncReadBuffer_test(bytArray, lngInTime)) {
				//If Not gFuncReadBuffer_test(bytArray, lngInTime) Then
				//--- Check for the byte array
				//Exit Try
				//---changed by deepak 21.06.07
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
			if (mInCommu)
				return false;
			//10.12.07
			mInCommu = true;
			//10.12.07
			gblnInCommProcess = true;
			glngProcTimeInMSec = lngInTime;
			if (!gFuncReadBuffer_orig(bytArray, lngInTime)) {
				//If Not gFuncReadBuffer_test(bytArray, lngInTime) Then
				//--- Check for the byte array
				mInCommu = false;
				//10.12.07
				gblnInCommProcess = false;
				//10.12.07
				glngProcTimeInMSec = 0;
				//10.12.07
				//Exit Try
				//---changed by deepak 21.06.07
				if (mblnIsNeedReceive == true) {
					//Error While Receiving Block
					gobjMessageAdapter.ShowMessage("Error while receiving block", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, false, false);
					Application.ExitThread();
					Application.Exit();
					System.Environment.Exit(0);
				}
				return false;
			} else {
				//--- Check for the array 
				if (!FuncValidateBlock(bytArray)) {
					//Exit Try
					mInCommu = false;
					//10.12.07
					gblnInCommProcess = false;
					//10.12.07
					glngProcTimeInMSec = 0;
					//10.12.07
					//Error in the Recived Block
					if (mblnIsNeedReceive == true) {
						gobjMessageAdapter.ShowMessage("Error in the received block", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, false, false);
						Application.ExitThread();
						Application.Exit();
						System.Environment.Exit(0);
					}
					//---changed by deepak 21.06.07
					return false;
				}
			}
			mInCommu = false;
			//10.12.07
			gblnInCommProcess = false;
			//10.12.07
			glngProcTimeInMSec = 0;
			//10.12.07
			mblnIsNeedReceive = true;
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
			glngProcTimeInMSec = 0;
			//10.12.07
			mInCommu = false;
			//10.12.07
			gblnInCommProcess = false;
			//10.12.07
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
		//Revision by Person: Sachin Dokhale on 6 Jan 08
		//--------------------------------------------------------------------------------------
		int intCount;
		long lngVal;
		try {
			if (UBound(bytArray) == 7) {

				if ((int)bytArray(0) == 50 & (int)bytArray(7) == 52) {
					//If CInt(bytArray(1)) = EnumUVProtocol.Ret_Ack Or _
					//CInt(bytArray(1)) = EnumUVProtocol.Reset_Ack Or _
					//CInt(bytArray(1)) = EnumUVProtocol.Data Or _
					//CInt(bytArray(1)) = EnumUVProtocol.CMD_Acknowledge Or _
					//CInt(bytArray(1)) = EnumUVProtocol.Spect_End Or _
					//CInt(bytArray(1)) = EnumUVProtocol.CMD_End Then

					//--- check Return Flags
					//if (CheckBlock()&&(Block[1]==RETURNACK || Block[1]==RESETACK || Block[1]==RESETACK_AA202) )
					//{
					// if(Block[1]==RESETACK_AA202)
					// {
					//  if( InstType != AA202 )
					//	 {
					//	  if(MessageBox(hpar,"You have selected AA203, but AA202 found. Configure for AA202 ?","INSTRU. ERROR",MB_ICONSTOP | MB_YESNO)== IDYES)
					//		WriteProfileStringFromIniFile("Instrument", "Setting","AA202", "aas.ini");
					//		CloseandExit();
					//	  InstType = AA202;
					//	 }
					// }
					// if(Block[1]==RESETACK)
					//{
					//  if( InstType != AA203 )
					//	{
					//	  if(MessageBox(hpar,"You have selected AA202, but AA203 found. Configure for AA203 ?","INSTRU. ERROR",MB_ICONSTOP | MB_YESNO)== IDYES)
					//		WriteProfileStringFromIniFile("Instrument", "Setting","AA203", "aas.ini");
					//		CloseandExit();
					//	  InstType = AA203;
					//	}
					//}
					if (((int)bytArray(1) == EnumAAS203Protocol.RESETACK_AA201) & (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201))) {
						gobjMessageAdapter.ShowMessage("You have selected different instrument but AA201 found. Please select proper instrument", "Instrument Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
						return false;
						//ElseIf (CInt(bytArray(1)) = EnumAAS203Protocol.RESETACK) And (Not (gstructSettings.AppMode = EnumAppMode.FullVersion_203)) Then
						//    '    gobjMessageAdapter.ShowMessage("You have selected different instrument but AA203 found. Please select proper instrument", "Instrument Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
						//    '    Return False
						//E   'ElseIf (CInt(bytArray(1)) = EnumAAS203Protocol.AA203D) And (Not (gstructSettings.AppMode = EnumAppMode.FullVersion_203D)) Then
						//    '    gobjMessageAdapter.ShowMessage("You have selected different instrument but AA203D found. Please select proper instrument", "Instrument Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
					}

					//'--- Get the parameters
					//mbytCommand = bytArray(1)
					//mbytParameter1 = bytArray(2)
					//mbytParameter2 = bytArray(3)
					//mbytParameter3 = bytArray(4)
					//mbytParameter4 = bytArray(5)
					//Dim intCount As Integer
					//Dim lngVal As Long

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

				} else {
					//else{
					//if(InstType == AA202){
					// if(Block[1] == CHKSUMERR){
					// InCommu =FALSE;
					// return flag1;
					// }
					//}
					if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201) & (bytArray(1) == EnumAAS203Protocol.CHKSUMERR)) {
						//Return flag1
						return false;
					}
				}
			}
			return false;
		//added and commented by kamal
		//----------------------------
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

	public bool gFuncTransmitCommand_test(Int32 intCommand, Int32 intParameter1, Int32 intParameter2, Int32 intParameter3)
	{
		//BOOL  Transmit(BYTE command, BYTE para1, BYTE para2, BYTE para3)
		//{
		//BOOL	flag=FALSE;

		//        If (InCommu) Then
		//	 return FALSE;

		//  InCommu =TRUE;

		//	Construct_Block(command, para1, para2, para3);

		//  flag = TransBlock();

		//  InCommu =FALSE;
		//return flag;
		//}
		int tout = CONST_LONG_DELAY;

		byte[] bytArray = new byte[6];
		try {
			bool flag = false;

			funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3);
			flag = mrs232.funcTransBlock(bytArray, tout);

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
				mrs232.funcPeekMessage();
				//Added by pankaj on 24 Mar 08
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
				gFuncReceiveByte2 = true;
				//moved by pankaj on 23 Mar 08
			}
		//gFuncReceiveByte2 = True

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

	//Private Function PC_Delay(ByVal intDelay As Long)
	//    'void  S4FUNC 	pc_delay(unsigned t)
	//    '{
	//    'unsigned  long i,j, k=1;
	//    '  j = (unsigned long ) ((double) t * 5.0);
	//    ' for (i=1; i<=j; i++)
	//    '	  k++;
	//    '}
	//    Dim intI, intJ, intK As Long
	//    intK = 1
	//    intJ = intDelay * 5
	//    For intI = 1 To intJ
	//        intK = intK + 1
	//    Next
	//End Function

}

