using DB.IO;
using System.Runtime.InteropServices;

public class CSerial
{

	#Region "Private Variables"
	private comm comm = new comm();
	private bool m_opened;
		#End Region
	private bool m_opened2;

	#Region "Public Properties"

	public bool Opened {
		get { return m_opened; }
	}

	public bool Opened2 {
		get { return m_opened2; }
	}

	#End Region

	#Region "API Declarations"
	[StructLayout(LayoutKind.Sequential)]
	private struct DCB
	{
		public int DCBlength;
		public int BaudRate;
			//See Comments Win32API.Txt
		public int fBitFields;
		public int wReserved;
		public int XonLim;
		public int XoffLim;
		public byte ByteSize;
		public byte Parity;
		public byte StopBits;
		public byte XonChar;
		public byte XoffChar;
		public byte ErrorChar;
		public byte EofChar;
		public byte EvtChar;
			//Reserved - Do Not Use
		public int wReserved1;
		//Public fAbortOnError As Boolean
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct COMMCONFIG
	{
		public Int32 dwSize;
		public Int16 wVersion;
		public Int16 wReserved;
		public DCB dcbx;
		public Int32 dwProviderSubType;
		public Int32 dwProviderOffset;
		public Int32 dwProviderSize;
		public Int32 wcProviderData;
	}

	[DllImport("kernel32.dll", SetlastError = true, CharSet = CharSet.Auto)]
	private static bool GetDefaultCommConfig(string lpszName, ref COMMCONFIG lpCC, ref int lpdwSize)
	{
	}

	//---declared by deepak on 22.06.07
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct COMSTAT
	{
		public Int32 fBitFields;
		public Int32 cbInQue;
		public Int32 cbOutQue;
	}

	//---declared by deepak on 22.06.07
	[DllImport("kernel32.dll", SetlastError = true)]
	public static int ClearCommError(long hFile, long lpErrors, COMSTAT lpStat)
	{
	}

	//'---declared by deepak on 22.06.07
	//<DllImport("user32.dll")> Public Shared Function GetCommError( _
	//    ByVal hFile As Long, ByVal lpStat As COMSTAT) As Integer
	//End Function
	//Public Declare Function ClearCommError Lib "kernel32" Alias "ClearCommError" (ByVal hFile As Long, ByVal lpErrors As Long, ByVal lpStat As COMSTAT) As Long


	//'---declared by deepak on 22.06.07
	//<DllImport("kernel32.dll")> Public Shared Function GetCommError( _
	//    ByVal hFile As Long, ByVal lpStat As COMSTAT) As Integer
	//End Function

	//---declared by deepak on 22.06.07
	[StructLayout(LayoutKind.Sequential)]
	public struct MSG
	{
		public long hwnd;
		public long message;
		public long wParam;
		public long lParam;
		public long time;
		public POINTAPI pt;
	}

	//---declared by deepak on 22.06.07
	[StructLayout(LayoutKind.Sequential)]
	public struct POINTAPI
	{
		public long x;
		public long y;
	}

	//---declared by deepak on 22.06.07
	[DllImport("user32.dll")]
	public static long PeekMessage(MSG lpMsg, long hwnd, long wMsgFilterMin, long wMsgFilterMax, long wRemoveMsg)
	{
	}

	//---declared by deepak on 22.06.07
	[DllImport("kernel32.dll")]
	public static long GetTickCount()
	{
	}

	#End Region

	#Region "Constructor"
	public CSerial()
	{
		m_opened = false;
	}
	#End Region

	#Region "Public Functions"

	public bool OpenComm(int intPort, int intBaud, int intDataBits, int intStopBits, int intParityBits)
	{
		bool bln;
		UInt32 baud;
		try {
			baud = UInt32.Parse(intBaud.ToString);
			bln = comm.SetPortSettings(baud, comm.FlowControl.None, intParityBits, intDataBits, intStopBits);
			comm.Open("COM" + intPort.ToString);
			m_opened = true;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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


	public bool TransmitCommand(Int32 intCommand, Int32 intParameter1, Int32 intParameter2, Int32 intParameter3)
	{
		byte[] bytArray = new byte[6];
		Int16 intCount = 0;
		byte bytConverted;
		long lngVal;
		try {
			//--- ReSet the Boolean flags 
			//mblnReadComplete = False
			//mblnTimeOut = False

			// modified by sns on 26Mar07
			subTime_Delay(20);
			//Call subTime_Delay(5)

			//---Clear the array contenets first
			for (intCount = 0; intCount <= 7; intCount++) {
				//bytBuffer(intCount) = 0
				bytArray(intCount) = 0;
			}

			//If Not funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3) Then
			//    Return False
			//    Exit Function
			//End If
			bytArray(0) = (byte)0x32;
			bytArray(1) = intCommand;
			bytArray(2) = intParameter1;
			bytArray(3) = intParameter2;
			bytArray(4) = intParameter3;
			bytArray(5) = (byte)0;
			bytArray(6) = (byte)0x20;
			bytArray(7) = (byte)0x34;

			for (intCount = 0; intCount <= 7; intCount += 1) {
				lngVal += bytArray(intCount);
			}


			lngVal = 0 - lngVal;
			bytConverted = gFunclongtobyte(lngVal);

			bytArray(5) = bytConverted;

			comm.Write(bytArray);

			subTime_Delay(2);

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


	public bool ReceiveData(ref byte[] bytArray, long lngInTime)
	{
		//Dim bytBuff As Byte()
		long lngcounter;
		int intcount;
		long lngTmr1;
		long lngTmr2;


		try {
			lngTmr1 = System.DateTime.Now.Ticks / 10000;
			while ((true)) {
				lngTmr2 = System.DateTime.Now.Ticks / 10000;
				if ((long)lngTmr2 - lngTmr1 < lngInTime) {
					//If comm.Read(bytArray) Then
					comm.Read(bytArray);
					//--- Check for the data
					if (bytArray.Length >= 8) {
						//bytArray = bytBuff
						return true;
						break; // TODO: might not be correct. Was : Exit Do
					}
				//End If
				// lngInTime timer over
				} else {
					return false;
					break; // TODO: might not be correct. Was : Exit Do
				}
			}

		//comm.Read(bytArray)
		//Return True
		//-----------------------------------------------------
		//'Dim bytBuff As Byte()
		///Dim lngcounter As Long
		///Dim intcount As Integer
		///Dim lngTmr1 As Long
		///Dim lngTmr2 As Long
		//'Dim blnFirst As Boolean = True
		//'Dim intI As Integer
		//'Dim cm As New COMSTAT
		//'Dim IntLpErrors As Int32
		//'Dim intFlag As Integer

		///cm.cbInQue = 0

		//'For intI = 0 To 7
		//'    bytArray(intI) = 0
		//'Next

		//'lngTmr1 = GetTickCount()
		///intFlag = ClearCommError(hPort, IntLpErrors, cm)

		//'Do While (True)
		//'    'WaitWindows_my()
		//'    'intFlag = ClearCommError(hPort, IntLpErrors, cm)
		//'    lngTmr2 = GetTickCount()

		//'    If CLng((lngTmr2 - lngTmr1) / 1000) < ((lngInTime / 1000) * 2) Then
		//'        comm.Read(bytArray)
		//'        '--- Check for the data
		//'        If bytArray.Length >= 8 Then
		//'            'bytArray = bytBuff
		//'            Return True
		//'            Exit Do
		//'        End If
		//'    Else
		//'        Return False
		//'        Exit Do
		//'    End If
		//'Loop

		///If (cm.cbInQue >= 8 And Commflag) Then
		///    If Read(bytArray) Then
		///    End If
		///End If

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

	public void Close()
	{
		try {
			comm.Close();
			m_opened = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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
			if (Opened == true) {
				Close();
				return true;
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
			if (Opened == true) {
				gFuncIsPortOpen = true;
			} else {
				gFuncIsPortOpen = false;
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
				lngTimeDelay = (long)System.DateTime.Now.Ticks / ConstManipulate;
				//lng1 = lngTimeInMSeconds - GetTickCount()
				//Application.DoEvents()
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

	public byte gFunclongtobyte(long lngparameter)
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
			//Error Handling And logging
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

	private bool gFunclongtobyte(long lngparameter, ref byte bytParameter1, ref byte bytParameter2)
	{
		//-----------------------------------  Function Header  -------------------------------
		//Function Name          :   gFunclongtobyte 
		//Description            :   Long to bytes conversion     
		//Parameters             :   byte_parameter1 as byte , byte2_parameter2 as byte
		//Return Type		    :   array of two bytes
		//Time/Date              :   17 Oct 2003,10:40 Hrs
		//Dependencies           :   
		//Author                 :   Nilesh Shirode
		//Revision               :   
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//Dim objWait As New CWaitCursor
		long data = lngparameter;
		long[] multfact = new long[4];
		int i;
		byte[] longtobyte = new byte[3];

		try {
			gFunclongtobyte = false;
			multfact(0) = 0;
			multfact(1) = (Math.Pow(16, 1)) * 15 + 15;
			multfact(2) = (Math.Pow(16, 3)) * 15 + (Math.Pow(16, 2)) * 15;
			multfact(3) = (Math.Pow(16, 5)) * 15 + (Math.Pow(16, 4)) * 15;
			multfact(4) = (Math.Pow(16, 7)) * 15 + (Math.Pow(16, 6)) * 15;
			for (i = 1; i <= 4; i++) {
				longtobyte(i - 1) = (data & multfact(i)) / (multfact(i - 1) + 1);
			}
			bytParameter1 = longtobyte(0);
			bytParameter2 = longtobyte(1);

			gFunclongtobyte = true;

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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}
	//429

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
			if (IsPortAvailable(intPortNumber)) {
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

	public bool IsPortAvailable(Int32 portNumber)
	{
		//===================================================
		//	Description	:	Returns true if a specific port number is supported by the system
		//	portNumber	:	port number to check
		//===================================================
		try {
			if (portNumber <= 0) {
				return false;
			} else {
				COMMCONFIG cfg;
				Int32 cfgsize = Marshal.SizeOf(cfg);
				cfg.dwSize = cfgsize;
				bool ret = GetDefaultCommConfig("COM" + portNumber.ToString, cfg, cfgsize);
				return ret;
			}

		//added and commented by kamal on 19March2004
		//----------------------------
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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
			OpenComm(intComPortIn, 9600, 0, 1, 8);
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
			//Return ReceiveData(bytArray, lngInTime)
			//Return True

			if (!ReceiveData(bytArray, lngInTime)) {
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
			return TransmitCommand(intCommand, intParameter1, intParameter2, intParameter3);
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

	#End Region

	#Region "Functions For CommPort2"

	public void Close2()
	{
		try {
			//This function closes the comport
			//by releasing it's filehandle
			comm.Close();
			m_opened2 = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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
			OpenComm(intComPortIn, lngBaudRateIn, intParityBitIn, intStopBitIn, intDataBitIn);
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
			if (Opened2 == true) {
				gFuncIsPortOpen2 = true;
			} else {
				gFuncIsPortOpen2 = false;
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

	public bool gFuncCloseComm2()
	{
		try {
			gFuncCloseComm2 = false;
			if (Opened2 == true) {
				Close2();
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
	#End Region

}

