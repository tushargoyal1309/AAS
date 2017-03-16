
using System.Runtime.InteropServices;

public class clsRS232 : MarshalByRefObject
{

	#Region " API Dlls Declarations "

	[DllImport("kernel32.dll")]
	private static int CreateFile(	[MarshalAs(UnmanagedType.LPStr)]
string lpFileName, int dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile)
	{
	}

	[DllImport("kernel32.dll")]
	private static int GetCommState(int hCommDev, ref DCB lpDCB)
	{
	}

	[DllImport("kernel32.dll")]
	private static int ReadFile(int hFile, byte[] Buffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, ref OVERLAPPED lpOverlapped)
	{
	}

	[DllImport("kernel32.dll")]
	private static int SetCommState(int hCommDev, ref DCB lpDCB)
	{
	}

	[DllImport("kernel32.dll")]
	private static int WriteFile(int hFile, byte[] Buffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, ref OVERLAPPED lpOverlapped)
	{
	}

	[DllImport("kernel32.dll")]
	private static int CloseHandle(int hObject)
	{
	}

	[DllImport("kernel32.dll")]
	private static int GetLastError()
	{
	}

	[DllImport("kernel32.dll")]
	private static int BuildCommDCB(string lpDef, ref DCB lpDCB)
	{
	}

	[DllImport("kernel32.dll", SetlastError = true, CharSet = CharSet.Auto)]
	private static bool GetDefaultCommConfig(string lpszName, ref COMMCONFIG lpCC, ref int lpdwSize)
	{
	}

	[DllImport("kernel32.dll", SetlastError = true)]
	private static Int32 PurgeComm(int hFile, Int32 dwFlags)
	{
	}
	[DllImport("kernel32.dll", SetlastError = true)]
	private static Int32 SetCommTimeouts(int hFile, ref COMMTIMEOUTS lpCommTimeouts)
	{
	}
	[DllImport("kernel32.dll", SetlastError = true)]
	private static Int32 GetCommTimeouts(int hFile, ref COMMTIMEOUTS lpCommTimeouts)
	{
	}

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

	[StructLayout(LayoutKind.Sequential)]
	private struct OVERLAPPED
	{
		public int ternal;
		public int ternalHigh;
		public int offset;
		public int OffsetHigh;
		public int hEvent;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct COMMTIMEOUTS
	{
		public Int32 ReadIntervalTimeout;
		public Int32 ReadTotalTimeoutMultiplier;
		public Int32 ReadTotalTimeoutConstant;
		public Int32 WriteTotalTimeoutMultiplier;
		public Int32 WriteTotalTimeoutConstant;
	}

	private const  OPEN_EXISTING = 3;
	private const  GENERIC_READ = 0x80000000;
	private const  GENERIC_WRITE = 0x40000000;

	private const  PARITYSTRING = "NOE";

	[Flags()]
	public enum PurgeBuffers
	{
		RXAbort = 0x2,
		RXClear = 0x8,
		TxAbort = 0x1,
		TxClear = 0x4
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

	#Region " Public Enums "

	public enum enumStopBits : byte
	{
		One = 1,
		One5 = 1.5,
		Two = 2
	}

	public enum enumParity : int
	{
		None = 0,
		Odd = 1,
		Even = 2
	}

	public enum CommErrorCode
	{
		CommNotOpen = 1
	}

	#End Region

	#Region " Public Events "

	public event  CommError;

	public event  CommStatus;

	#End Region

	#Region " Private Class variables "


	private int hPort;

	private DCB dcbPort;
	private bool m_opened;
	private int m_port;
	private int m_speed;
	private enumParity m_parity;
	private enumStopBits m_stop;

	private int m_databits;
	#End Region

	#Region "Constants"
	public const  PM_NOYIELD = 0x2;
	public const  PM_NOREMOVE = 0x0;
	public const  QS_KEY = 0x1;
	public const  QS_MOUSEBUTTON = 0x4;
	public const  QS_MOUSEMOVE = 0x2;
	public const  QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON;
	public const  QS_INPUT = QS_MOUSE | QS_KEY;
		#End Region
	public const  PM_QS_INPUT = QS_INPUT << 16;

	#Region " Public functions "

	public clsRS232()
	{
		try {
			//Set all default values
			m_opened = false;
			m_port = 1;
			m_speed = 9600;
			m_parity = enumParity.None;
			m_stop = enumStopBits.One;
			m_databits = 8;

			m_opened2 = false;
			m_port2 = 1;
			m_speed2 = 9600;
			m_parity2 = enumParity.None;
			m_stop2 = enumStopBits.One;
			m_databits2 = 8;
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

	public void Open(int portname, int Spd, enumParity Pty, int Dtb, enumStopBits Stp)
	{
		//This function opens a comport in your system for communication
		string m_CommDCB;
		string m_Baud;
		string m_Parity;
		string m_Data;
		byte m_Stop;

		try {
			//Try to create a filehandle to the comport we want to use
			hPort = CreateFile("COM" + portname.ToString, GENERIC_READ + GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

			//Look if the handle is valid (mus be higher than zero!)
			if (hPort < 1) {
				if (CommError != null) {
					CommError(CommErrorCode.CommNotOpen);
				}
				Commflag = false;
				return;
			}

			//Id = hPort

			PurgeComm(hPort, PurgeBuffers.RXClear);
			PurgeComm(hPort, PurgeBuffers.TxClear);

			//dcbPort.fAbortOnError = True

			GetCommState(hPort, dcbPort);

			//Setup the DCB (comport settings)
			m_Baud = Spd.ToString();
			m_Parity = PARITYSTRING.Substring(Pty, 1);
			m_Data = Dtb.ToString();
			m_Stop = Stp;

			m_CommDCB = string.Format("baud={0} parity={1} data={2} stop={3}", m_Baud, m_Parity, m_Data, m_Stop);

			BuildCommDCB(m_CommDCB, dcbPort);

			//If we can't put the settings in place, we probably can't use the comport
			//for our task.

			if (SetCommState(hPort, dcbPort) == 0) {
				//Throw New Exception("kan de compoort niet openen(" & GetLastError().ToString() & ")")
				//Throw New Exception("Cannot Open Selected Comm Port(" & GetLastError().ToString() & ")")
				//gFuncShowMessage("Error In Opening Communication Port!", "Either the Communication port is not available or another program is utilizing the selected communication port", modConstants.EnumMessageType.Information)
				return;
			}

			//---To Set Time Outs
			funcTimeOut(hPort);
			Commflag = true;
			//---If all's fine we set the opened parameter to true
			m_opened = true;

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

	//This function is pratically the same as the other open
	public void Open()
	{
		try {
			Open(m_port, m_speed, m_parity, m_databits, m_stop);

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

	public void Close()
	{
		try {
			//This function closes the comport
			//by releasing it's filehandle

			CloseHandle(hPort);
			hPort = -1;
			m_opened = false;

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

	public void PurgeBuffer(PurgeBuffers Mode)
	{
		try {
			//This method is used to clear the input and output buffers
			if ((hPort != 0))
				PurgeComm(hPort, Mode);

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

	public void Write(byte[] data)
	{
		byte[] dt;
		int written;

		try {
			dt = Array.CreateInstance(typeof(byte), 8);
			dt = data;
			//We have a multi-byte buffer, which you can ofcourse enable...

			//Check if our comport is open
			if (Opened == true) {
				PurgeBuffer(PurgeBuffers.RXClear);
				PurgeBuffer(PurgeBuffers.TxClear);

				WriteFile(hPort, dt, 8, written, null);
			} else {
				if (CommError != null) {
					CommError(CommErrorCode.CommNotOpen);
				}
			}

			dt = null;
		//System.Windows.Forms.Application.DoEvents()
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
			//System.Windows.Forms.Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public bool Read(ref byte[] bytArray)
	{
		int rd;
		OVERLAPPED ovl = new OVERLAPPED();
		byte[] dt;
		object intReturnReadFile = 0;

		try {
			dt = Array.CreateInstance(typeof(byte), 8);
			//Initialize the buffer

			//Check if the comport is opened
			if (Opened == true) {
				ReadFile(hPort, dt, 8, rd, ovl);
				if (rd >= 8) {
					Read = true;
					bytArray = dt;
				} else {
					Read = false;
				}
			} else {
				Read = false;
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
			//System.Windows.Forms.Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	public void funcTimeOut(int hPort)
	{
		COMMTIMEOUTS m_ComTimeOut;

		try {
			if (hPort == -1) {
				return;
			} else {
					//.ReadIntervalTimeout = 100
					//.ReadTotalTimeoutConstant = 100
					//.ReadTotalTimeoutMultiplier = 100
					//.WriteTotalTimeoutConstant = 100
					//.WriteTotalTimeoutMultiplier = 100
				 // ERROR: Not supported in C#: WithStatement

				SetCommTimeouts(hPort, m_ComTimeOut);
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

	public bool gFuncReadBuffer_test(ref byte[] bytarray, long lngInTime)
	{
		//======Written by Deepak
		//        BOOL(RecevBlock())
		//{
		//int			i;
		//DWORD			w1, w2;
		//COMSTAT 		cm;
		//BOOL			first=TRUE;

		//        If (!Commflag) Then
		//	 return FALSE;
		//  for(i=0; i<8 ; i++)
		//	 Block[i]=0;
		//  w1 = GetTickCount();
		//  GetCommError(Id,&cm);
		//  while (((int)cm.cbInQue < 8)) {
		//	 WaitWindows_my();
		//	 GetCommError(Id,&cm);
		//	 w2 = GetTickCount();
		//	 if ( ((w2-w1)/(DWORD) 1000) > (DWORD) (Tout*2)){
		//		if (first){
		//		  first=FALSE;
		//		  w1 = GetTickCount();
		//		 }
		//		else{
		//		 Commflag=FALSE;
		//		 break;
		//		}
		//	  }
		//  }
		//	if ((int)cm.cbInQue>= 8 && Commflag)
		//	  ReadComm(Id,Block,8);
		// return Commflag;
		//}
		byte[] bytBuff;
		long lngcounter;
		int intcount;
		long lngTmr1;
		long lngTmr2;
		bool blnFirst = true;
		int intI;
		COMSTAT cm = new COMSTAT();
		Int32 IntLpErrors;
		int intFlag;

		try {
			if (Commflag == false) {
				return false;
			}

			cm.cbInQue = 0;

			for (intI = 0; intI <= 7; intI++) {
				bytarray(intI) = 0;
			}

			lngTmr1 = GetTickCount();
			intFlag = ClearCommError(hPort, IntLpErrors, cm);

			while ((cm.cbInQue < 8)) {
				//WaitWindows_my()
				intFlag = ClearCommError(hPort, IntLpErrors, cm);
				lngTmr2 = GetTickCount();

				if ((long)(lngTmr2 - lngTmr1) / 1000 > ((lngInTime / 1000) * 2)) {
					if (blnFirst == true) {
						blnFirst = false;
						lngTmr1 = GetTickCount();
					} else {
						System.Windows.Forms.MessageBox.Show("commflag=false");
						System.Windows.Forms.MessageBox.Show(lngInTime.ToString);
						Commflag = false;
						break; // TODO: might not be correct. Was : Exit Do
					}
				}
			}

			if ((cm.cbInQue >= 8 & Commflag)) {
				if (Read(bytarray)) {
				}
			}

			return Commflag;
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

	public object funcPeekMessage()
	{
		//====written by deepak on 22.06.07
		//        void(WaitWindows_my(void))
		//{
		//MSG msg;
		//  PeekMessage(&msg,NULL,0,0,PM_NOREMOVE|PM_NOYIELD);
		//}
		MSG msg;
		long lngFlag;
		try {
			lngFlag = PeekMessage(msg, null, 0, 0, PM_NOYIELD | PM_NOREMOVE);
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

	#Region " Public Properties "

	public int Port {
		get { return m_port; }
		set { m_port = Value; }
	}

	public int Speed {
		get { return m_speed; }
		set { m_speed = Value; }
	}

	public enumParity Parity {
		get { return m_parity; }
		set { m_parity = Value; }
	}

	public enumStopBits StopBits {
		get { return m_stop; }
		set { m_stop = Value; }
	}

	public int DataBits {
		get { return m_databits; }
		set { m_databits = Value; }
	}

	public bool Opened {
		get { return m_opened; }
	}

	#End Region

	#Region " Private class variables for 2nd Comm Port "
	//needed if we have to open  & use 2 comm port simultaneously
	//--------------------------------------------------------
	private int hPort2;
	private DCB dcbPort2;
	private bool m_opened2;
	private int m_port2;
	private int m_speed2;
	private enumParity m_parity2;
	private enumStopBits m_stop2;

	private int m_databits2;
	#End Region

	#Region " Public Properties for 2nd Comm Port "

	public int Port2 {
		get { return m_port2; }
		set { m_port2 = Value; }
	}

	public int Speed2 {
		get { return m_speed2; }
		set { m_speed2 = Value; }
	}

	public enumParity Parity2 {
		get { return m_parity2; }
		set { m_parity2 = Value; }
	}

	public enumStopBits StopBits2 {
		get { return m_stop2; }
		set { m_stop2 = Value; }
	}

	public int DataBits2 {
		get { return m_databits2; }
		set { m_databits2 = Value; }
	}

	public bool Opened2 {
		get { return m_opened2; }
	}

	#End Region

	#Region " Public functions for 2nd Comm Port "


	public void Open2(int portname, int Spd, enumParity Pty, int Dtb, enumStopBits Stp)
	{
		//This function opens a comport in your system for communication
		string m_CommDCB;
		string m_Baud;
		string m_Parity;
		string m_Data;
		byte m_Stop;

		try {
			//Try to create a filehandle to the comport we want to use
			hPort2 = CreateFile("COM" + portname.ToString, GENERIC_READ + GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

			//Look if the handle is valid (mus be higher than zero!)
			if (hPort2 < 1) {
				throw new Exception("Can't open the comport! (Errorcode :" + GetLastError().ToString() + ")");
			}

			//Setup the DCB (comport settings)
			m_Baud = Spd.ToString();
			m_Parity = PARITYSTRING.Substring(Pty, 1);
			m_Data = Dtb.ToString();
			m_Stop = Stp;

			m_CommDCB = string.Format("baud={0} parity={1} data={2} stop={3}", m_Baud, m_Parity, m_Data, m_Stop);

			BuildCommDCB(m_CommDCB, dcbPort2);

			//If we can't put the settings in place, we probably can't use the comport
			//for our task.
			if (SetCommState(hPort2, dcbPort2) == 0) {
				//Throw New Exception("kan de compoort niet openen(" & GetLastError().ToString() & ")")
				throw new Exception("Cannot Open Selected Comm Port(" + GetLastError().ToString() + ")");
			}
			//----------------------
			//---------
			//added by kamal on 210304
			//--- To Set Time Outs
			funcTimeOut(hPort2);
			//------------------
			//-------------------
			//If all's fine we set the opened parameter to true
			m_opened2 = true;
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

	public void Open2()
	{
		try {
			Open2(m_port2, m_speed2, m_parity2, m_databits2, m_stop2);
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

	public void Close2()
	{
		try {
			//This function closes the comport
			//by releasing it's filehandle
			CloseHandle(hPort2);
			hPort2 = -1;
			m_opened2 = false;
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

	public void PurgeBuffer2(PurgeBuffers Mode)
	{
		try {
			//This method is used to clear the input and output buffers
			if ((hPort2 != 0))
				PurgeComm(hPort2, Mode);
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

	public void WriteByte2(byte[] data)
	{
		byte[] dt;
		int written;
		try {
			dt = Array.CreateInstance(typeof(byte), 1);
			dt = data;
			//We have a multi-byte buffer, which you can ofcourse enable...

			//Check if our comport is open
			if (Opened2 == true) {
				PurgeBuffer(PurgeBuffers.RXClear);
				PurgeBuffer(PurgeBuffers.TxClear);
				WriteFile(hPort2, dt, 1, written, null);
			} else {
				throw new Exception("Com Port Not Opened");
			}

			dt = null;
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

	public bool ReadByte2(ref byte[] bytRead)
	{
		int rd;
		OVERLAPPED ovl = new OVERLAPPED();
		byte[] dt;
		object intReturnReadFile = 0;
		try {
			dt = Array.CreateInstance(typeof(byte), 1);
			//Initialize the buffer

			//Check if the comport is opened
			if (Opened2 == true) {
				//Application.DoEvents()
				ReadFile(hPort2, dt, 1, rd, ovl);

				//Application.DoEvents()

				if (rd >= 1) {
					ReadByte2 = true;
					bytRead = dt;
				} else {
					ReadByte2 = false;
				}
			} else {
				ReadByte2 = false;
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

	#End Region

}
