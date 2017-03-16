using System.Runtime.InteropServices;

public class clsRS232vc : MarshalByRefObject
{

	#Region " API Dlls Declarations "
	[DllImport("mfcdllnoauto.dll")]
	public static int add1(int a, int b)
	{
	}

	[DllImport("mfcdllnoauto.dll")]
	public static object Purge(int flag)
	{
	}
	[DllImport("mfcdllnoauto.dll")]
	public static bool IsOpen(int intCommPort)
	{

	}

	[DllImport("mfcdllnoauto.dll")]
	public static bool Open(int nPort, int dwBaud, int parity, byte Databits, int StopBit)
	{
	}

	[DllImport("mfcdllnoauto.dll")]
	private static int Read(byte[] lpBuf, int dwCount)
	{

	}
	[DllImport("mfcdllnoauto.dll")]
	private static int Write(byte[] lpBuf, int dwCount)
	{

	}
	[DllImport("mfcdllnoauto.dll")]
	public static bool Close1()
	{

	}

	[StructLayout(LayoutKind.Sequential)]
	public struct POINTAPI
	{
		public long x;
		public long y;
	}
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
	[DllImport("mfcdllnoauto.dll")]
	public static long peekmessage()
	{
	}

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
	public void Open2()
	{
		try {
		//Open(m_port, m_speed, enumParity.None, 8, enumStopBits.One, enumFlowControl.NoFlowControl, False)
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
	public object WriteByte2(bytArray)
	{

	}
	public object ReadByte2(bytArray)
	{

	}

	public object gFuncReadBuffer_test(bytarray, lngInTime)
	{

	}
	public object Close2()
	{

	}
	public object funcPeekMessage()
	{
		MSG msg;
		long lngFlag;
		try {
			//lngFlag = peekmessage(msg, Nothing, 0, 0, 2 Or 0)
			lngFlag = peekmessage();
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

	public enum enumFlowControl
	{
		NoFlowControl,
		CtsRtsFlowControl,
		CtsDtrFlowControl,
		DsrRtsFlowControl,
		DsrDtrFlowControl,
		XonXoffFlowControl
	}

	public enum CommErrorCode
	{
		CommNotOpen = 1
	}

	#End Region

	#Region " Private Class variables "
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

	#Region "comm function"
	public void Close()
	{
		m_opened = Close1();
	}
	public void Open()
	{
		try {
			int a;
			a = add1(2, 4);
			bool ret;
			m_opened = Open(m_port, m_speed, enumParity.None, 8, enumStopBits.One);

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
	public bool IsPortAvailable(intCommPort)
	{
		bool ret = true;
		ret = IsOpen(intCommPort);
		m_opened = ret;
		return ret;
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
			if (m_opened == true) {
				//Call Purge(8)
				//Call Purge(4)
				written = -1;

				written = Write(dt, 8);
			} else {
				//RaiseEvent CommError(CommErrorCode.CommNotOpen)
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
		//Dim ovl As New OVERLAPPED
		byte[] dt;
		object intReturnReadFile = 0;

		try {
			dt = Array.CreateInstance(typeof(byte), 8);
			//Initialize the buffer

			//Check if the comport is opened
			if (m_opened == true) {
				rd = Read(dt, 8);
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

}
