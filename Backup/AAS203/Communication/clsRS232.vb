Option Explicit On 
Imports System.Diagnostics
Imports System.Runtime.InteropServices
'Namespace RS232SerialComm



Public Class clsRS232
    Inherits MarshalByRefObject

#Region " API Dlls Declarations "

    <DllImport("kernel32.dll")> Private Shared Function CreateFile( _
           <MarshalAs(UnmanagedType.LPStr)> ByVal lpFileName As String, _
           ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, _
           ByVal lpSecurityAttributes As Integer, _
           ByVal dwCreationDisposition As Integer, _
           ByVal dwFlagsAndAttributes As Integer, _
           ByVal hTemplateFile As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function GetCommState( _
        ByVal hCommDev As Integer, ByRef lpDCB As DCB) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function ReadFile( _
    ByVal hFile As Integer, ByVal Buffer As Byte(), _
    ByVal nNumberOfBytesToRead As Integer, _
    ByRef lpNumberOfBytesRead As Integer, _
    ByRef lpOverlapped As OVERLAPPED) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function SetCommState( _
    ByVal hCommDev As Integer, ByRef lpDCB As DCB) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function WriteFile( _
    ByVal hFile As Integer, ByVal Buffer As Byte(), _
    ByVal nNumberOfBytesToWrite As Integer, _
    ByRef lpNumberOfBytesWritten As Integer, _
    ByRef lpOverlapped As OVERLAPPED) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function CloseHandle(ByVal hObject As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function GetLastError() As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function BuildCommDCB( _
        ByVal lpDef As String, ByRef lpDCB As DCB) As Integer
    End Function

    <DllImport("kernel32.dll", SetlastError:=True, CharSet:=CharSet.Auto)> Private Shared Function GetDefaultCommConfig(ByVal lpszName As String, ByRef lpCC As COMMCONFIG, ByRef lpdwSize As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetlastError:=True)> Private Shared Function PurgeComm(ByVal hFile As Integer, ByVal dwFlags As Int32) As Int32
    End Function
    <DllImport("kernel32.dll", SetlastError:=True)> Private Shared Function SetCommTimeouts(ByVal hFile As Integer, ByRef lpCommTimeouts As COMMTIMEOUTS) As Int32
    End Function
    <DllImport("kernel32.dll", SetlastError:=True)> Private Shared Function GetCommTimeouts(ByVal hFile As Integer, ByRef lpCommTimeouts As COMMTIMEOUTS) As Int32
    End Function

    <StructLayout(LayoutKind.Sequential)> Structure DCB
        Public DCBlength As Integer
        Public BaudRate As Integer
        Public fBitFields As Integer 'See Comments Win32API.Txt
        Public wReserved As Integer
        Public XonLim As Integer
        Public XoffLim As Integer
        Public ByteSize As Byte
        Public Parity As Byte
        Public StopBits As Byte
        Public XonChar As Byte
        Public XoffChar As Byte
        Public ErrorChar As Byte
        Public EofChar As Byte
        Public EvtChar As Byte
        Public wReserved1 As Integer 'Reserved - Do Not Use
        'Public fAbortOnError As Boolean
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> Private Structure COMMCONFIG
        Public dwSize As Int32
        Public wVersion As Int16
        Public wReserved As Int16
        Public dcbx As DCB
        Public dwProviderSubType As Int32
        Public dwProviderOffset As Int32
        Public dwProviderSize As Int32
        Public wcProviderData As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)> Structure OVERLAPPED
        Public ternal As Integer
        Public ternalHigh As Integer
        Public offset As Integer
        Public OffsetHigh As Integer
        Public hEvent As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> Private Structure COMMTIMEOUTS
        Public ReadIntervalTimeout As Int32
        Public ReadTotalTimeoutMultiplier As Int32
        Public ReadTotalTimeoutConstant As Int32
        Public WriteTotalTimeoutMultiplier As Int32
        Public WriteTotalTimeoutConstant As Int32
    End Structure

    Private Const OPEN_EXISTING = 3
    Private Const GENERIC_READ = &H80000000
    Private Const GENERIC_WRITE = &H40000000
    Private Const PARITYSTRING = "NOE"

    <Flags()> Public Enum PurgeBuffers
        RXAbort = &H2
        RXClear = &H8
        TxAbort = &H1
        TxClear = &H4
    End Enum

    '---declared by deepak on 22.06.07
    <StructLayout(LayoutKind.Sequential, Pack:=1)> Public Structure COMSTAT
        Public fBitFields As Int32
        Public cbInQue As Int32
        Public cbOutQue As Int32
    End Structure

    '---declared by deepak on 22.06.07
    <DllImport("kernel32.dll", SetlastError:=True)> Public Shared Function ClearCommError( _
        ByVal hFile As Int32, ByRef lpErrors As Int32, ByRef lpStat As COMSTAT) As Integer
    End Function

    Public Declare Function ClearCommBreak Lib "kernel32" Alias "ClearCommBreak" (ByVal nCid As Long) As Long

    ''---declared by deepak on 22.06.07
    '<DllImport("user32.dll")> Public Shared Function GetCommError( _
    '    ByVal hFile As Long, ByVal lpStat As COMSTAT) As Integer
    'End Function
    'Public Declare Function ClearCommError Lib "kernel32" Alias "ClearCommError" (ByVal hFile As Long, ByVal lpErrors As Long, ByVal lpStat As COMSTAT) As Long


    ''---declared by deepak on 22.06.07
    '<DllImport("kernel32.dll")> Public Shared Function GetCommError( _
    '    ByVal hFile As Long, ByVal lpStat As COMSTAT) As Integer
    'End Function

    '---declared by deepak on 22.06.07
    <StructLayout(LayoutKind.Sequential)> Public Structure MSG
        Public hwnd As Long
        Public message As Long
        Public wParam As Long
        Public lParam As Long
        Public time As Long
        Public pt As POINTAPI
    End Structure

    '---declared by deepak on 22.06.07
    <StructLayout(LayoutKind.Sequential)> Public Structure POINTAPI
        Public x As Long
        Public y As Long
    End Structure

    '---declared by deepak on 22.06.07
    <DllImport("user32.dll")> Public Shared Function PeekMessage _
    (ByVal lpMsg As MSG, ByVal hwnd As Long, ByVal wMsgFilterMin As Long, _
    ByVal wMsgFilterMax As Long, ByVal wRemoveMsg As Long) As Long
    End Function

    '---declared by deepak on 22.06.07
    <DllImport("kernel32.dll")> Public Shared Function GetTickCount() As Long
    End Function

#End Region

#Region " Public Enums "

    Public Enum enumStopBits As Byte
        One = 1
        One5 = 1.5
        Two = 2
    End Enum

    Public Enum enumParity As Integer
        None = 0
        Odd = 1
        Even = 2
    End Enum

    Public Enum CommErrorCode
        CommNotOpen = 1
    End Enum

#End Region

#Region " Public Events "

    Public Event CommError(ByVal intErrorCode As CommErrorCode)

    Public Event CommStatus(ByVal strMessage As String)

#End Region

#Region " Private Class variables "

    Private hPort As Integer

    Private dcbPort As DCB

    Private m_opened As Boolean
    Private m_port As Integer
    Private m_speed As Integer
    Private m_parity As enumParity
    Private m_stop As enumStopBits
    Private m_databits As Integer
    Private Shared nT As Integer = 0
    Public Shared mCommflag As Boolean = False '10.12.07

    Public Shared ReadOnly Property IsCommuOk() As Boolean
        Get
            Return mCommflag
        End Get
        'Set(ByVal Value As Boolean)
        '    mCommflag = Value
        'End Set
    End Property   '10.12.07
#End Region

#Region "Constants"
    Public Const PM_NOYIELD = &H2
    Public Const PM_NOREMOVE = &H0
    Public Const QS_KEY = &H1
    Public Const QS_MOUSEBUTTON = &H4
    Public Const QS_MOUSEMOVE = &H2
    Public Const QS_MOUSE = QS_MOUSEMOVE Or QS_MOUSEBUTTON
    Public Const QS_INPUT = QS_MOUSE Or QS_KEY
    Public Const PM_QS_INPUT = QS_INPUT << 16
    Public Const CE_BREAK = &H10
    Public Const CE_IOE = &H400
#End Region

#Region " Public functions "

    Public Sub New()
        Try
            'Set all default values
            m_opened = False
            m_port = 1
            m_speed = 9600
            m_parity = enumParity.None
            m_stop = enumStopBits.One
            m_databits = 8

            m_opened2 = False
            m_port2 = 1
            m_speed2 = 9600
            m_parity2 = enumParity.None
            m_stop2 = enumStopBits.One
            m_databits2 = 8
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub Open(ByVal portname As Integer, ByVal Spd As Integer, ByVal Pty As enumParity, ByVal Dtb As Integer, ByVal Stp As enumStopBits)
        'This function opens a comport in your system for communication
        Dim m_CommDCB As String
        Dim m_Baud As String
        Dim m_Parity As String
        Dim m_Data As String
        Dim m_Stop As Byte

        Try
            m_opened = False
            clsRS232Main.mInCommu = True
            clsRS232Main.gblnInCommProcess = True
            'Try to create a filehandle to the comport we want to use
            hPort = CreateFile("COM" & portname.ToString, GENERIC_READ + GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0)

            'Look if the handle is valid (mus be higher than zero!)
            If hPort < 1 Then
                RaiseEvent CommError(CommErrorCode.CommNotOpen)
                mCommflag = False
                clsRS232Main.mInCommu = False
                clsRS232Main.gblnInCommProcess = False
                Exit Sub
            End If

            'Id = hPort

            Call PurgeComm(hPort, PurgeBuffers.RXClear)
            Call PurgeComm(hPort, PurgeBuffers.TxClear)

            'dcbPort.fAbortOnError = True

            Call GetCommState(hPort, dcbPort)

            'Setup the DCB (comport settings)
            m_Baud = Spd.ToString()
            m_Parity = PARITYSTRING.Substring(Pty, 1)
            m_Data = Dtb.ToString()
            m_Stop = Stp

            m_CommDCB = String.Format("baud={0} parity={1} data={2} stop={3}", m_Baud, m_Parity, m_Data, m_Stop)

            Call BuildCommDCB(m_CommDCB, dcbPort)

            'If we can't put the settings in place, we probably can't use the comport
            'for our task.

            If SetCommState(hPort, dcbPort) = 0 Then
                'Throw New Exception("kan de compoort niet openen(" & GetLastError().ToString() & ")")
                'Throw New Exception("Cannot Open Selected Comm Port(" & GetLastError().ToString() & ")")
                'gFuncShowMessage("Error In Opening Communication Port!", "Either the Communication port is not available or another program is utilizing the selected communication port", modConstants.EnumMessageType.Information)
                clsRS232Main.mInCommu = False
                clsRS232Main.gblnInCommProcess = False
                Exit Sub
            End If

            '---To Set Time Outs
            Call funcTimeOut(hPort)
            mCommflag = True
            '---If all's fine we set the opened parameter to true
            m_opened = True
            clsRS232Main.mInCommu = False
            clsRS232Main.gblnInCommProcess = False
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    'This function is pratically the same as the other open
    Public Sub Open()
        Try
            Open(m_port, m_speed, m_parity, m_databits, m_stop)

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub Close()
        Try
            'This function closes the comport
            'by releasing it's filehandle

            Call CloseHandle(hPort)
            hPort = -1
            m_opened = False

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub PurgeBuffer(ByVal Mode As PurgeBuffers)
        Try
            'This method is used to clear the input and output buffers
            If (hPort <> 0) Then PurgeComm(hPort, Mode)

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub Write(ByVal data As Byte())
        Dim dt As Byte()
        Dim written As Integer
        Dim IntLpErrors As Integer
        Dim cm As New COMSTAT
        Try
            'uncommented by pankaj on 1 Nov 07

            ClearCommError(hPort, IntLpErrors, cm)

            Select Case IntLpErrors
                Case CE_BREAK
                    gobjMessageAdapter.ShowMessage("Error in received block", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, False, False)
                    Application.ExitThread()
                    Application.Exit()
                    'Dim cs As Process = Process.GetCurrentProcess()
                    'cs.Kill()
                Case CE_IOE
                    gobjMessageAdapter.ShowMessage("Error in getting response from instrument", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, False, False)
                    Application.ExitThread()
                    Application.Exit()
                    'Dim cs As Process = Process.GetCurrentProcess()
                    'cs.Kill()
                    End
            End Select

            '-------

            dt = Array.CreateInstance(GetType(Byte), 8)
            dt = data 'We have a multi-byte buffer, which you can ofcourse enable...

            'Check if our comport is open
            If Opened = True Then
                Call PurgeBuffer(PurgeBuffers.RXClear)
                Call PurgeBuffer(PurgeBuffers.TxClear)

                Call WriteFile(hPort, dt, 8, written, Nothing)
            Else
                RaiseEvent CommError(CommErrorCode.CommNotOpen)
            End If

            dt = Nothing
            'System.Windows.Forms.Application.DoEvents()
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'System.Windows.Forms.Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Sub

    Public Function Read(ByRef bytArray As Byte()) As Boolean
        Dim rd As Integer
        Dim ovl As New OVERLAPPED
        Dim dt As Byte()
        Dim intReturnReadFile = 0

        Try
            If Not mCommflag Then Return False

            dt = Array.CreateInstance(GetType(Byte), 8) 'Initialize the buffer

            'Check if the comport is opened
            If Opened = True Then
                Call ReadFile(hPort, dt, 8, rd, ovl)
                If rd >= 8 Then
                    Read = True
                    bytArray = dt
                Else
                    Read = False
                End If
            Else
                Read = False
            End If

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            dt = Nothing
            'System.Windows.Forms.Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function Read(ByRef bytArray As Byte(), ByVal lngInTime As Long) As Boolean
        Dim bytBuff As Byte()
        Dim lngcounter As Long
        Dim intcount As Integer
        Dim lngTmr1 As Long
        Dim lngTmr2 As Long
        Dim intErrNo As Integer
        Dim cm As New COMSTAT
        Try
            Read = False
            If Not mCommflag Then Return False
            Erase bytArray
            lngTmr1 = System.DateTime.Now.Ticks / 10000
            'funcClearComm(hPort, intErrNo, cm)
            'subTime_Delay(10) '03.02.08
            Do While (True)
                'Do While cm.cbInQue < 8
                '---funcPeekMessage is added by Deepak B. on 13.08.07 for synchronous messages processing
                'mrs232.funcPeekMessage() 'By Pankaj for vc comm
                '-------
                funcDelayWindows(5)
                If funcClearComm(hPort, intErrNo, cm) = 0 Then
                    mCommflag = False
                    Exit Do
                End If

                lngTmr2 = System.DateTime.Now.Ticks / 10000
                If CLng(lngTmr2 - lngTmr1) < lngInTime Then
                    If cm.cbInQue >= 8 Then
                        Exit Do
                    End If

                Else ' lngInTime timer over
                    'If cm.cbInQue < 8 Then
                    '    mCommflag = False
                    'End If
                    mCommflag = False
                    Exit Do
                End If
                'subTime_Delay(5) '03.02.08
            Loop

            If (cm.cbInQue >= 8 And mCommflag = True) Then
                'subTime_Delay(4) '03.02.08
                If mrs232.ReadSpeed(bytBuff) Then
                    '--- Check for the data
                    If bytBuff.Length >= 8 Then
                        bytArray = bytBuff
                        'Read = True
                        Return True
                    End If
                End If
            End If
            Erase bytBuff
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            cm = Nothing
            bytBuff = Nothing
            'System.Windows.Forms.Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function ReadSpeed(ByRef bytArray As Byte()) As Boolean
        Dim rd As Integer
        Dim ovl As New OVERLAPPED
        Dim dt As Byte()
        Dim intReturnReadFile = 0
        Dim intErrNo As Integer
        Dim cm As New COMSTAT
        Dim nReadResult As Integer
        Try
            If Not mCommflag Then Return False

            dt = Array.CreateInstance(GetType(Byte), 8) 'Initialize the buffer

            'Check if the comport is opened
            If Opened = True Then
                nReadResult = ReadFile(hPort, dt, 8, rd, ovl)
                If nReadResult = 0 Then
                    Return False
                End If
                If rd >= 8 Then
                    ReadSpeed = True
                    bytArray = dt
                Else
                    ReadSpeed = False
                End If
            Else
                ReadSpeed = False
            End If

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            dt = Nothing
            cm = Nothing
            'System.Windows.Forms.Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Sub funcTimeOut(ByVal hPort As Integer)
        Dim m_ComTimeOut As COMMTIMEOUTS

        Try
            If hPort = -1 Then
                Exit Sub
            Else
                With m_ComTimeOut
                    '.ReadIntervalTimeout = 100
                    '.ReadTotalTimeoutConstant = 100
                    '.ReadTotalTimeoutMultiplier = 100
                    '.WriteTotalTimeoutConstant = 100
                    '.WriteTotalTimeoutMultiplier = 100
                    .ReadIntervalTimeout = 0
                    .ReadTotalTimeoutConstant = 0
                    .ReadTotalTimeoutMultiplier = 500 '500   '500
                    .WriteTotalTimeoutConstant = 10 '10
                    .WriteTotalTimeoutMultiplier = 100 '100
                End With
                Call SetCommTimeouts(hPort, m_ComTimeOut)
            End If

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Function IsPortAvailable(ByVal portNumber As Int32) As Boolean
        '===================================================
        '	Description	:	Returns true if a specific port number is supported by the system
        '	portNumber	:	port number to check
        '===================================================
        Try
            If portNumber <= 0 Then
                Return False
            Else
                Dim cfg As COMMCONFIG
                Dim cfgsize As Int32 = Marshal.SizeOf(cfg)
                cfg.dwSize = cfgsize
                Dim ret As Boolean = GetDefaultCommConfig("COM" + portNumber.ToString, cfg, cfgsize)
                Return ret
            End If

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Public Function gFuncReadBuffer_test(ByRef bytarray() As Byte, ByVal lngInTime As Long) As Boolean
        '======Written by Deepak
        '        BOOL(RecevBlock())
        '{
        'int			i;
        'DWORD			w1, w2;
        'COMSTAT 		cm;
        'BOOL			first=TRUE;

        '        If (!Commflag) Then
        '	 return FALSE;
        '  for(i=0; i<8 ; i++)
        '	 Block[i]=0;
        '  w1 = GetTickCount();
        '  GetCommError(Id,&cm);
        '  while (((int)cm.cbInQue < 8)) {
        '	 WaitWindows_my();
        '	 GetCommError(Id,&cm);
        '	 w2 = GetTickCount();
        '	 if ( ((w2-w1)/(DWORD) 1000) > (DWORD) (Tout*2)){
        '		if (first){
        '		  first=FALSE;
        '		  w1 = GetTickCount();
        '		 }
        '		else{
        '		 Commflag=FALSE;
        '		 break;
        '		}
        '	  }
        '  }
        '	if ((int)cm.cbInQue>= 8 && Commflag)
        '	  ReadComm(Id,Block,8);
        ' return Commflag;
        '}
        Dim bytBuff As Byte()
        Dim lngcounter As Long
        Dim intcount As Integer
        Dim lngTmr1 As Long
        Dim lngTmr2 As Long
        Dim blnFirst As Boolean = True
        Dim intI As Integer
        Dim cm As New COMSTAT
        Dim IntLpErrors As Int16
        Dim intFlag As Integer
        Dim intdd As Integer
        Dim ovl As New OVERLAPPED
        Try
            '---------------------------------------
            'logic 1
            ''If hPort <= 0 Then
            ''    Return False
            ''End If

            ''For intI = 0 To 7
            ''    bytarray(intI) = 0
            ''Next

            ''lngTmr1 = GetTickCount()
            '''intFlag = ClearCommError(hPort, IntLpErrors, cm)
            ''intFlag = funcClearComm(hPort, IntLpErrors, cm)

            ''Do While (cm.cbInQue < 8)
            ''    funcPeekMessage()
            ''    'intFlag = ClearCommError(hPort, IntLpErrors, cm)
            ''    intFlag = funcClearComm(hPort, IntLpErrors, cm)
            ''    lngTmr2 = GetTickCount()

            ''    If CLng((lngTmr2 - lngTmr1) / 1000) > ((lngInTime / 1000) * 2) Then
            ''        If blnFirst = True Then
            ''            blnFirst = False
            ''            lngTmr1 = GetTickCount()
            ''        Else
            ''            Exit Do
            ''        End If
            ''    End If
            ''Loop

            ''intI = 0
            ''If (cm.cbInQue >= 8) Then
            ''    intI = ReadFile(hPort, bytarray, 8, intdd, ovl)
            ''End If
            ''If intI > 0 Then
            ''    Return True
            ''Else
            ''    Return False
            ''End If
            '-------------------------------
            'logic 2
            If hPort <= 0 Then
                Return False
            End If

            For intI = 0 To 7
                bytarray(intI) = 0
            Next

            lngTmr1 = System.DateTime.Now.Ticks / 10000
            intFlag = funcClearComm(hPort, IntLpErrors, cm)
            While (cm.cbInQue < 8)
                funcPeekMessage()
                lngTmr2 = System.DateTime.Now.Ticks / 10000
                If CLng(lngTmr2 - lngTmr1) < lngInTime Then
                    intFlag = funcClearComm(hPort, IntLpErrors, cm)
                    If cm.cbInQue >= 8 Then
                        Exit While
                    End If
                Else
                    Return False
                End If
            End While

            intI = 0
            If (cm.cbInQue >= 8) Then
                intI = ReadFile(hPort, bytarray, 8, intdd, ovl)
            End If
            If intI > 0 Then
                Return True
            Else
                Return False
            End If
            '---------------------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Shared Function funcPeekMessage()
        '====written by deepak on 22.06.07
        '        void(WaitWindows_my(void))
        '{
        'MSG msg;
        '  PeekMessage(&msg,NULL,0,0,PM_NOREMOVE|PM_NOYIELD);
        '}
        Dim msg As MSG
        Dim lngFlag As Long
        Try
            '---commented on 30.03.09

            ''Do While (True)
            ''    lngFlag = PeekMessage(msg, Nothing, 0, 0, PM_NOYIELD Or PM_NOREMOVE)
            ''    If lngFlag <= 0 Then
            ''        Exit Do
            ''    Else
            ''        If msg.message <= 0 Then
            ''            Exit Do
            ''        End If
            ''    End If
            ''Loop
            '----------------------------

            '---added on 30.03.09
            lngFlag = PeekMessage(msg, Nothing, 0, 0, PM_NOYIELD Or PM_NOREMOVE)
            '---------------------

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcTransBlock(ByVal bytArray() As Byte, ByVal tout As Integer) As Boolean
        'static	int nT=0;

        'BOOL TransBlock()
        '{
        'int i;

        '        If (!Commflag) Then
        '	 return FALSE;
        ' if (Commflag){
        '	nT++;
        '	if (nT%25==0){
        '	  	PurgeComm(Id,0);
        '		PurgeComm(Id,1); 
        '	 }
        '  }
        '  for(i=0; i<8 && Commflag ; i++){
        '	 obj.WriteRSChar(Block[i]);
        '  }
        '  return Commflag;
        '}
        Dim intI As Integer
        Dim blnFlag As Boolean = False
        Dim intk As Integer
        Try
            funcPeekMessage()
            'nT = nT + 1
            'If nT Mod 25 = 0 Then
            '    PurgeComm(hPort, 8)
            '    PurgeComm(hPort, 4)
            'End If

            'If hPort <= 0 Then
            '    Return False
            'End If
            funcDelayWindows(10)
            If Not mCommflag = True Then Return False

            If gblnSetSpeedIssue = True Then
                If gblnIsPeakSearchStarted = True Then
                    'subTime_Delay(5)
                End If
            End If
            For intI = 0 To 7
                intk = intI + 1
                If intk Mod 2 = 0 Then
                    PurgeComm(hPort, 8)
                    PurgeComm(hPort, 4)
                End If

                blnFlag = funcWriteRSChar(bytArray(intI), tout)
                If blnFlag = False Then
                    Exit For
                End If
            Next
            Return blnFlag
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcWriteRSChar(ByVal bytArray As Byte, ByVal tout As Integer) As Boolean
        '        BOOL WriteRSChar(BYTE ch)
        '{
        'DWORD		w1, w2;
        'COMSTAT 	cm;
        'int  errno;
        'int  numWritten;
        'OVERLAPPED ovl;

        '        If (!Commflag) Then
        '	 return FALSE;
        '  w1 = GetTickCount();
        '  WriteFile(Id,&ch,1,(DWORD*) &numWritten,&ovl);
        '  ClearCommError(Id,(DWORD*) &errno, &cm);
        '  while ((int)cm.cbOutQue != 0)  {
        '	 obj.WaitWindows_my();
        '	 ClearCommError(Id,(DWORD*) &errno, &cm);
        '	  w2 = GetTickCount();
        '	 if (((w2-w1)/(DWORD) 1000) > (DWORD) (Tout)){
        '		Commflag=FALSE;
        '		break;
        '	 }
        '	}
        ' obj.DelayWindows(50); 
        ' return Commflag;
        '}
        Dim intErrNo As Integer
        Dim intNoWritten As Integer
        Dim w1, w2 As Long
        Dim cm As New COMSTAT
        Dim ovl As New OVERLAPPED
        'Dim fl As Boolean
        Dim fl As Integer
        Dim btarr(1) As Byte
        Try
            '----------------------------------
            'logic 1
            'If hPort <= 0 Then
            '    Return False
            'End If
            'btarr(0) = bytArray
            'w1 = GetTickCount()
            'fl = WriteFile(hPort, btarr, 1, intNoWritten, Nothing)
            ''ClearCommError(hPort, intErrNo, cm)
            'funcClearComm(hPort, intErrNo, cm)

            'While Not cm.cbOutQue = 0
            '    funcPeekMessage()
            '    'ClearCommError(hPort, intErrNo, cm)
            '    funcClearComm(hPort, intErrNo, cm)
            '    w2 = GetTickCount()
            '    If ((w2 - w1) / 1000) > (tout / 1000) Then
            '        fl = False
            '        Exit While
            '    End If
            'End While
            'funcDelayWindows(50)
            'Return fl

            '----------------------------------
            'logic 2
            'If hPort <= 0 Then
            '    Return False
            'End If
            'btarr(0) = bytArray
            'w1 = System.DateTime.Now.Ticks / 10000
            'fl = WriteFile(hPort, btarr, 1, intNoWritten, Nothing)
            ''funcClearComm(hPort, intErrNo, cm)
            ''While Not cm.cbOutQue = 0
            ''    funcPeekMessage()
            ''    funcClearComm(hPort, intErrNo, cm)
            ''    w2 = System.DateTime.Now.Ticks / 10000
            ''    If CLng(w2 - w1) > tout Then
            ''        fl = False
            ''        Exit While
            ''    End If
            ''End While
            'funcDelayWindows(10)
            'Return fl
            '----------------------------------
            'logic 3

            'If hPort <= 0 Then
            '    Return False
            'End If
            If Not mCommflag = True Then Return False

            btarr(0) = bytArray
            w1 = System.DateTime.Now.Ticks / 10000
            fl = WriteFile(hPort, btarr, 1, intNoWritten, Nothing)
            If funcClearComm(hPort, intErrNo, cm) = 0 Then
                mCommflag = False
                Return False
            End If
            While Not cm.cbOutQue = 0
                'subTime_Delay(3)
                funcDelayWindows(10)
                If funcClearComm(hPort, intErrNo, cm) = 0 Then
                    fl = False
                    mCommflag = False
                    Exit While
                End If
                w2 = System.DateTime.Now.Ticks / 10000
                If CLng(w2 - w1) > tout Then
                    fl = False
                    mCommflag = False
                    Exit While
                End If
            End While
            funcDelayWindows(10)
            mCommflag = fl
            Return fl
            'Return mCommflag
            '----------------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcDelayWindows(ByVal intCh As Integer)
        '---------------------------------------------------------------------------------------
        'Procedure Name :   funcDelayWindows
        'Description    :   To delay 
        'Parameters     :   intch
        'Time/Date      :   26.09.07
        'Dependencies   :   
        'Author         :   Deepak 
        'Revision       :          
        '---------------------------------------------------------------------------------------
        'void DelayWindows(int ch)
        '{
        'int i;
        'for (i=0;i<ch; i++)
        '  obj.WaitWindows_my();
        '}
        Dim i As Integer
        Try
            For i = 0 To intCh - 1
                funcPeekMessage()
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Friend Shared Function funcClearComm(ByVal port As Long, _
                                       ByRef intErrNo As Int32, _
                                       ByRef cm As COMSTAT) As Integer
        '---------------------------------------------------------------------------------------
        'Procedure Name :   funcClearComm
        'Description    :   To clear communication  error and to detect communication break
        'Parameters     :   port,intErrNo,cm
        'Time/Date      :   26.09.07
        'Dependencies   :   Comm port should be available   
        'Author         :   Deepak 
        'Revision       :          
        '---------------------------------------------------------------------------------------
        Dim intflag As Integer
        Try
            intflag = ClearCommError(port, intErrNo, cm)
            Select Case intErrNo
                Case CE_BREAK
                    gobjMessageAdapter.ShowMessage("Error in received block", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, False, False)
                    Application.ExitThread()
                    Application.Exit()
                    End
                Case CE_IOE
                    gobjMessageAdapter.ShowMessage("Error in getting response from instrument", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, False, False)
                    Application.ExitThread()
                    Application.Exit()
                    End
            End Select
            Return intflag
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return 0
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Public Sub subTime_Delay(ByVal lngTimeInMSeconds As Long)
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    subTime_Delay
        'Description:       To generate delay between two successive REad or Write Oerations
        'Parameters :       Time in MiliSeconds, ConstManipulate = 10000 to get time in milliseconds
        'Time/Date  :       3.33 13 oct 2003
        'Dependencies:      Its all depend On God ... if he supplies ticks, delay works else we have manipulated it to make it work
        'Author:            Mandar
        'Revision:
        'Revision by Person: Rahul B.
        '--------------------------------------------------------------------------------------
        Dim lngTimeDelay As Long
        Dim lng As Long
        Dim lng1 As Long
        Dim intCount As Int16
        Dim ConstManipulate As Long = 10000 ' this will manipulate tick count for each mili second

        'Note: Ticks are being calculated at the interval of 100 nano seconds hence calculated the factor to be devided as 10000

        Try
            lngTimeDelay = CLng(System.DateTime.Now.Ticks) / ConstManipulate
            lngTimeInMSeconds = lngTimeDelay + lngTimeInMSeconds

            Do While lngTimeDelay < lngTimeInMSeconds
                '--- This loop will execute until the delay condition gets satisfied
                'For intCount = 1 To 100
                'intCount = intCount + 1
                'Next
                'Application.DoEvents()
                Call funcPeekMessage()
                'System.Windows.Forms.Application.DoEvents()
                lngTimeDelay = CLng(System.DateTime.Now.Ticks) / ConstManipulate
                'lng1 = lngTimeInMSeconds - GetTickCount()
                'Application.DoEvents()
                'System.Windows.Forms.Application.DoEvents()
            Loop

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub
#End Region

#Region " Public Properties "

    Public Property Port() As Integer
        Get
            Return m_port
        End Get
        Set(ByVal Value As Integer)
            m_port = Value
        End Set
    End Property

    Public Property Speed() As Integer
        Get
            Return m_speed
        End Get
        Set(ByVal Value As Integer)
            m_speed = Value
        End Set
    End Property

    Public Property Parity() As enumParity
        Get
            Return m_parity
        End Get
        Set(ByVal Value As enumParity)
            m_parity = Value
        End Set
    End Property

    Public Property StopBits() As enumStopBits
        Get
            Return m_stop
        End Get
        Set(ByVal Value As enumStopBits)
            m_stop = Value
        End Set
    End Property

    Public Property DataBits() As Integer
        Get
            Return m_databits
        End Get
        Set(ByVal Value As Integer)
            m_databits = Value
        End Set
    End Property

    Public ReadOnly Property Opened() As Boolean
        Get
            Return m_opened
        End Get
    End Property

#End Region

#Region " Private class variables for 2nd Comm Port "
    'needed if we have to open  & use 2 comm port simultaneously
    '--------------------------------------------------------
    Private hPort2 As Integer
    Private dcbPort2 As DCB
    Private m_opened2 As Boolean
    Private m_port2 As Integer
    Private m_speed2 As Integer
    Private m_parity2 As enumParity
    Private m_stop2 As enumStopBits
    Private m_databits2 As Integer

#End Region

#Region " Public Properties for 2nd Comm Port "

    Public Property Port2() As Integer
        Get
            Return m_port2
        End Get
        Set(ByVal Value As Integer)
            m_port2 = Value
        End Set
    End Property

    Public Property Speed2() As Integer
        Get
            Return m_speed2
        End Get
        Set(ByVal Value As Integer)
            m_speed2 = Value
        End Set
    End Property

    Public Property Parity2() As enumParity
        Get
            Return m_parity2
        End Get
        Set(ByVal Value As enumParity)
            m_parity2 = Value
        End Set
    End Property

    Public Property StopBits2() As enumStopBits
        Get
            Return m_stop2
        End Get
        Set(ByVal Value As enumStopBits)
            m_stop2 = Value
        End Set
    End Property

    Public Property DataBits2() As Integer
        Get
            Return m_databits2
        End Get
        Set(ByVal Value As Integer)
            m_databits2 = Value
        End Set
    End Property

    Public ReadOnly Property Opened2() As Boolean
        Get
            Return m_opened2
        End Get
    End Property

#End Region

#Region " Public functions for 2nd Comm Port "

    Public Sub Open2(ByVal portname As Integer, ByVal Spd As Integer, ByVal Pty As enumParity, ByVal Dtb As Integer, ByVal Stp As enumStopBits)

        'This function opens a comport in your system for communication
        Dim m_CommDCB As String
        Dim m_Baud As String
        Dim m_Parity As String
        Dim m_Data As String
        Dim m_Stop As Byte
        Try

            'Try to create a filehandle to the comport we want to use
            hPort2 = CreateFile("COM" & portname.ToString, GENERIC_READ + GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0)

            'Look if the handle is valid (mus be higher than zero!)
            If hPort2 < 1 Then
                Throw New Exception("Can't open the comport! (Errorcode :" & GetLastError().ToString() & ")")
            End If

            'Setup the DCB (comport settings)
            m_Baud = Spd.ToString()
            m_Parity = PARITYSTRING.Substring(Pty, 1)
            m_Data = Dtb.ToString()
            m_Stop = Stp

            m_CommDCB = String.Format("baud={0} parity={1} data={2} stop={3}", m_Baud, m_Parity, m_Data, m_Stop)

            BuildCommDCB(m_CommDCB, dcbPort2)

            'If we can't put the settings in place, we probably can't use the comport
            'for our task.
            If SetCommState(hPort2, dcbPort2) = 0 Then
                'Throw New Exception("kan de compoort niet openen(" & GetLastError().ToString() & ")")
                Throw New Exception("Cannot Open Selected Comm Port(" & GetLastError().ToString() & ")")
            End If
            '----------------------
            '---------
            'added by kamal on 210304
            '--- To Set Time Outs
            Call funcTimeOut(hPort2)
            '------------------
            '-------------------
            'If all's fine we set the opened parameter to true
            m_opened2 = True
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub Open2()
        Try
            Open2(m_port2, m_speed2, m_parity2, m_databits2, m_stop2)
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub Close2()
        Try
            'This function closes the comport
            'by releasing it's filehandle
            CloseHandle(hPort2)
            hPort2 = -1
            m_opened2 = False
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub PurgeBuffer2(ByVal Mode As PurgeBuffers)
        Try
            'This method is used to clear the input and output buffers
            If (hPort2 <> 0) Then PurgeComm(hPort2, Mode)
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Sub WriteByte2(ByVal data As Byte())
        Dim dt As Byte()
        Dim written As Integer
        Try
            dt = Array.CreateInstance(GetType(Byte), 1)
            dt = data 'We have a multi-byte buffer, which you can ofcourse enable...

            'Check if our comport is open
            If Opened2 = True Then
                Call PurgeBuffer(PurgeBuffers.RXClear)
                Call PurgeBuffer(PurgeBuffers.TxClear)
                WriteFile(hPort2, dt, 1, written, Nothing)
            Else
                Throw New Exception("Com Port Not Opened")
            End If

            dt = Nothing
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Function ReadByte2(ByRef bytRead As Byte()) As Boolean
        Dim rd As Integer
        Dim ovl As New OVERLAPPED
        Dim dt As Byte()
        Dim intReturnReadFile = 0
        Try
            dt = Array.CreateInstance(GetType(Byte), 1) 'Initialize the buffer

            'Check if the comport is opened
            If Opened2 = True Then
                'Application.DoEvents()
                Call ReadFile(hPort2, dt, 1, rd, ovl)

                'Application.DoEvents()

                If rd >= 1 Then
                    ReadByte2 = True
                    bytRead = dt
                Else
                    ReadByte2 = False
                End If
            Else
                ReadByte2 = False
            End If
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Class
'End Namespace