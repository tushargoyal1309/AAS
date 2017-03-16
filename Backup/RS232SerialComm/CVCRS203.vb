Option Explicit On 
Imports System.Runtime.InteropServices

Public Class clsRS232vc
    Inherits MarshalByRefObject

#Region " API Dlls Declarations "
    <DllImport("mfcdllnoauto.dll")> Public Shared Function add1(ByVal a As Integer, ByVal b As Integer) As Integer
    End Function

    <DllImport("mfcdllnoauto.dll")> Public Shared Function Purge( _
          ByVal flag As Integer)
    End Function
    <DllImport("mfcdllnoauto.dll")> Public Shared Function IsOpen(ByVal intCommPort As Integer) As Boolean

    End Function

    <DllImport("mfcdllnoauto.dll")> Public Shared Function Open( _
          ByVal nPort As Integer, _
          ByVal dwBaud As Integer, ByVal parity As Integer, _
          ByVal Databits As Byte, ByVal StopBit As Integer) As Boolean
    End Function

    <DllImport("mfcdllnoauto.dll")> Private Shared Function Read( _
              ByVal lpBuf As Byte(), _
              ByVal dwCount As Integer) As Integer

    End Function
    <DllImport("mfcdllnoauto.dll")> Private Shared Function Write( _
              ByVal lpBuf As Byte(), _
              ByVal dwCount As Integer) As Integer

    End Function
    <DllImport("mfcdllnoauto.dll")> Public Shared Function Close1() As Boolean

    End Function

    <StructLayout(LayoutKind.Sequential)> Public Structure POINTAPI
        Public x As Long
        Public y As Long
    End Structure
    <StructLayout(LayoutKind.Sequential)> Public Structure MSG
        Public hwnd As Long
        Public message As Long
        Public wParam As Long
        Public lParam As Long
        Public time As Long
        Public pt As POINTAPI
    End Structure
    <DllImport("mfcdllnoauto.dll")> Public Shared Function peekmessage() As Long
    End Function

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
    Public Sub Open2()
        Try
            'Open(m_port, m_speed, enumParity.None, 8, enumStopBits.One, enumFlowControl.NoFlowControl, False)
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
    Public Function WriteByte2(ByVal bytArray)

    End Function
    Public Function ReadByte2(ByVal bytArray)

    End Function
    
    Public Function gFuncReadBuffer_test(ByVal bytarray, ByVal lngInTime)

    End Function
    Public Function Close2()

    End Function
    Public Function funcPeekMessage()
        Dim msg As MSG
        Dim lngFlag As Long
        Try
            'lngFlag = peekmessage(msg, Nothing, 0, 0, 2 Or 0)
            lngFlag = peekmessage()
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

    Public Enum enumFlowControl
        NoFlowControl
        CtsRtsFlowControl
        CtsDtrFlowControl
        DsrRtsFlowControl
        DsrDtrFlowControl
        XonXoffFlowControl
    End Enum

    Public Enum CommErrorCode
        CommNotOpen = 1
    End Enum

#End Region

#Region " Private Class variables "
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

#Region "comm function"
    Public Sub Close()
        m_opened = Close1()
    End Sub
    Public Sub Open()
        Try
            Dim a As Integer
            a = add1(2, 4)
            Dim ret As Boolean
            m_opened = Open(m_port, m_speed, enumParity.None, 8, enumStopBits.One)

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
    Public Function IsPortAvailable(ByVal intCommPort) As Boolean
        Dim ret As Boolean = True
        ret = IsOpen(intCommPort)
        m_opened = ret
        Return ret
    End Function
    Public Sub Write(ByVal data As Byte())
        Dim dt As Byte()
        Dim written As Integer

        Try
            dt = Array.CreateInstance(GetType(Byte), 8)
            dt = data 'We have a multi-byte buffer, which you can ofcourse enable...

            'Check if our comport is open
            If m_opened = True Then
                'Call Purge(8)
                'Call Purge(4)
                written = -1

                written = Write(dt, 8)
            Else
                'RaiseEvent CommError(CommErrorCode.CommNotOpen)
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
        'Dim ovl As New OVERLAPPED
        Dim dt As Byte()
        Dim intReturnReadFile = 0

        Try
            dt = Array.CreateInstance(GetType(Byte), 8) 'Initialize the buffer

            'Check if the comport is opened
            If m_opened = True Then
                rd = Read(dt, 8)
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
            'System.Windows.Forms.Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

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

End Class
