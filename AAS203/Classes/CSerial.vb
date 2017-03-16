Imports DB.IO
Imports System.Runtime.InteropServices

Public Class CSerial

#Region "Private Variables"
    Private comm As New comm
    Private m_opened, m_opened2 As Boolean
#End Region

#Region "Public Properties"

    Public ReadOnly Property Opened() As Boolean
        Get
            Return m_opened
        End Get
    End Property

    Public ReadOnly Property Opened2() As Boolean
        Get
            Return m_opened2
        End Get
    End Property

#End Region

#Region "API Declarations"
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

    <DllImport("kernel32.dll", SetlastError:=True, CharSet:=CharSet.Auto)> Private Shared Function GetDefaultCommConfig(ByVal lpszName As String, ByRef lpCC As COMMCONFIG, ByRef lpdwSize As Integer) As Boolean
    End Function

    '---declared by deepak on 22.06.07
    <StructLayout(LayoutKind.Sequential, Pack:=1)> Public Structure COMSTAT
        Public fBitFields As Int32
        Public cbInQue As Int32
        Public cbOutQue As Int32
    End Structure

    '---declared by deepak on 22.06.07
    <DllImport("kernel32.dll", SetlastError:=True)> Public Shared Function ClearCommError( _
        ByVal hFile As Long, ByVal lpErrors As Long, ByVal lpStat As COMSTAT) As Integer
    End Function

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

#Region "Constructor"
    Public Sub New()
        m_opened = False
    End Sub
#End Region

#Region "Public Functions"

    Public Function OpenComm(ByVal intPort As Integer, ByVal intBaud As Integer, _
        ByVal intDataBits As Integer, ByVal intStopBits As Integer, ByVal intParityBits As Integer) As Boolean
        Dim bln As Boolean
        Dim baud As UInt32
        Try
            baud = UInt32.Parse(intBaud.ToString)
            bln = comm.SetPortSettings(baud, comm.FlowControl.None, intParityBits, intDataBits, intStopBits)
            comm.Open("COM" & intPort.ToString)
            m_opened = True
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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


    Public Function TransmitCommand(ByVal intCommand As Int32, _
                                        ByVal intParameter1 As Int32, _
                                        ByVal intParameter2 As Int32, _
                                        ByVal intParameter3 As Int32) As Boolean
        Dim bytArray(7) As Byte
        Dim intCount As Int16 = 0
        Dim bytConverted As Byte
        Dim lngVal As Long
        Try
            '--- ReSet the Boolean flags 
            'mblnReadComplete = False
            'mblnTimeOut = False

            ' modified by sns on 26Mar07
            Call subTime_Delay(20)
            'Call subTime_Delay(5)

            '---Clear the array contenets first
            For intCount = 0 To 7
                'bytBuffer(intCount) = 0
                bytArray(intCount) = 0
            Next

            'If Not funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3) Then
            '    Return False
            '    Exit Function
            'End If
            bytArray(0) = CByte(&H32)
            bytArray(1) = intCommand
            bytArray(2) = intParameter1
            bytArray(3) = intParameter2
            bytArray(4) = intParameter3
            bytArray(5) = CByte(0)
            bytArray(6) = CByte(&H20)
            bytArray(7) = CByte(&H34)

            For intCount = 0 To 7 Step 1
                lngVal += bytArray(intCount)
            Next


            lngVal = 0 - lngVal
            bytConverted = gFunclongtobyte(lngVal)

            bytArray(5) = bytConverted

            comm.Write(bytArray)

            Call subTime_Delay(2)

            Return True

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


    Public Function ReceiveData(ByRef bytArray() As Byte, ByVal lngInTime As Long) As Boolean
        'Dim bytBuff As Byte()
        Dim lngcounter As Long
        Dim intcount As Integer
        Dim lngTmr1 As Long
        Dim lngTmr2 As Long

        Try

            lngTmr1 = System.DateTime.Now.Ticks / 10000
            Do While (True)
                lngTmr2 = System.DateTime.Now.Ticks / 10000
                If CLng(lngTmr2 - lngTmr1) < lngInTime Then
                    'If comm.Read(bytArray) Then
                    comm.Read(bytArray)
                    '--- Check for the data
                    If bytArray.Length >= 8 Then
                        'bytArray = bytBuff
                        Return True
                        Exit Do
                    End If
                    'End If
                Else ' lngInTime timer over
                    Return False
                    Exit Do
                End If
            Loop

            'comm.Read(bytArray)
            'Return True
            '-----------------------------------------------------
            ''Dim bytBuff As Byte()
            '''Dim lngcounter As Long
            '''Dim intcount As Integer
            '''Dim lngTmr1 As Long
            '''Dim lngTmr2 As Long
            ''Dim blnFirst As Boolean = True
            ''Dim intI As Integer
            ''Dim cm As New COMSTAT
            ''Dim IntLpErrors As Int32
            ''Dim intFlag As Integer

            '''cm.cbInQue = 0

            ''For intI = 0 To 7
            ''    bytArray(intI) = 0
            ''Next

            ''lngTmr1 = GetTickCount()
            '''intFlag = ClearCommError(hPort, IntLpErrors, cm)

            ''Do While (True)
            ''    'WaitWindows_my()
            ''    'intFlag = ClearCommError(hPort, IntLpErrors, cm)
            ''    lngTmr2 = GetTickCount()

            ''    If CLng((lngTmr2 - lngTmr1) / 1000) < ((lngInTime / 1000) * 2) Then
            ''        comm.Read(bytArray)
            ''        '--- Check for the data
            ''        If bytArray.Length >= 8 Then
            ''            'bytArray = bytBuff
            ''            Return True
            ''            Exit Do
            ''        End If
            ''    Else
            ''        Return False
            ''        Exit Do
            ''    End If
            ''Loop

            '''If (cm.cbInQue >= 8 And Commflag) Then
            '''    If Read(bytArray) Then
            '''    End If
            '''End If

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

    Public Sub Close()
        Try
            comm.Close()
            m_opened = False

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

    Public Function gFuncCloseComm() As Boolean
        Try
            If Opened = True Then
                Close()
                Return True
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function gFuncIsPortOpen() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncIsPortOpen
        'Description:       To Check is port open by our EXE
        'Parameters :       None
        'Time/Date  :       6.25 13 Oct 2003
        'Dependencies:      Class should be instanciated Prior
        'Author:            Mandar
        'Revision:
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Try
            If Opened = True Then
                gFuncIsPortOpen = True
            Else
                gFuncIsPortOpen = False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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
                lngTimeDelay = CLng(System.DateTime.Now.Ticks) / ConstManipulate
                'lng1 = lngTimeInMSeconds - GetTickCount()
                'Application.DoEvents()
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

    Public Function gFunclongtobyte(ByVal lngparameter As Long) As Byte
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFunclongtobyte
        'Description:       To Send back the Check Sum byte for the current calculaed Block of Bytes
        'Parameters :       Added Block bytes Data 
        'Time/Date  :       1st Oct 2003
        'Dependencies:      a calculated value should be provided to recieve the check sum
        'Author:            NileshS
        'Revision:          
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Dim data As Long = lngparameter '4294967295 '65518 '1183 '65535 '255 '4008636142 '15658734 '16777215 '2147483647 '4294967294 '1234567890 '
        Dim multfact(5) As Long
        Dim i As Integer
        Dim longtobyte(4) As Byte

        Try
            multfact(0) = 0
            multfact(1) = (16 ^ 1) * 15 + 15
            multfact(2) = (16 ^ 3) * 15 + (16 ^ 2) * 15
            multfact(3) = (16 ^ 5) * 15 + (16 ^ 4) * 15
            multfact(4) = (16 ^ 7) * 15 + (16 ^ 6) * 15

            For i = 1 To 4
                'If (data And multfact(i)) > 255 Then
                ' multfact(i - 1) = multfact(i - 1) - 1
                'End If

                longtobyte(i - 1) = (data And multfact(i)) \ (multfact(i - 1) + 1)
                'MessageBox.Show(longtobyte(i - 1), "Long to Byte")
            Next i

            Return longtobyte(0)

            ''Byte to long Conversion
            'Dim bytetolong As Long = 0
            'For i = 0 To 3
            '    bytetolong += CLng(longtobyte(i)) * (16 ^ (i * 2))
            'Next i
            'MessageBox.Show(bytetolong, "Long Value")

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling And logging
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

    Private Function gFunclongtobyte(ByVal lngparameter As Long, ByRef bytParameter1 As Byte, ByRef bytParameter2 As Byte) As Boolean
        '-----------------------------------  Function Header  -------------------------------
        'Function Name          :   gFunclongtobyte 
        'Description            :   Long to bytes conversion     
        'Parameters             :   byte_parameter1 as byte , byte2_parameter2 as byte
        'Return Type		    :   array of two bytes
        'Time/Date              :   17 Oct 2003,10:40 Hrs
        'Dependencies           :   
        'Author                 :   Nilesh Shirode
        'Revision               :   
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim data As Long = lngparameter
        Dim multfact(5) As Long
        Dim i As Integer
        Dim longtobyte(4) As Byte

        Try
            gFunclongtobyte = False
            multfact(0) = 0
            multfact(1) = (16 ^ 1) * 15 + 15
            multfact(2) = (16 ^ 3) * 15 + (16 ^ 2) * 15
            multfact(3) = (16 ^ 5) * 15 + (16 ^ 4) * 15
            multfact(4) = (16 ^ 7) * 15 + (16 ^ 6) * 15
            For i = 1 To 4
                longtobyte(i - 1) = (data And multfact(i)) \ (multfact(i - 1) + 1)
            Next i
            bytParameter1 = longtobyte(0)
            bytParameter2 = longtobyte(1)

            gFunclongtobyte = True

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Function '429

    Public Function gFuncISPortAvailable(ByVal intPortNumber As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncISPortAvailable
        'Description:       To Check whether the port is available or not For communication
        'Parameters :       None
        'Time/Date  :       6.32 13 Oct 2003
        'Dependencies:      clsRS232 Class and if applicable At least ONE Comm Port ( joking... )
        'Author:            Mandar
        'Revision:
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Try
            If IsPortAvailable(intPortNumber) Then
                Return True
            Else
                Return False
            End If

            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function gFuncOpenCommPort(ByVal intComPortIn As Integer, ByVal blnComPortKnown As Boolean) As Boolean
        '-----------------------------------------------------------------
        'Procedure Name :   gFuncOpenCommPort
        'Description    :   To open the communication port of the 
        '                   PC for the data transaction    
        'Parameters     :   Port Number, boolean flag
        'Time/Date      :   5/9/06
        'Dependencies   :   Comm port of the pc should present
        'Author         :   Rahul B.
        'Revision       :   2
        'Revision by    :   Mangesh  
        '-----------------------------------------------------------------
        Dim intCommPort As Integer

        Try
            OpenComm(intComPortIn, 9600, 0, 1, 8)
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
        End Try
    End Function

    Public Function gFuncReceiveData(ByRef bytArray() As Byte, ByVal lngInTime As Long) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gFuncReceiveData
        'Description	    :   To Retrieve the data in the Input Buffer
        'Parameters 	    :   Boolean Double Processing and Time delay in passed as Long
        'Time/Date  	    :   15.50  17 feb 2004
        'Dependencies	    :   port should be open 
        'Author		        :   Santosh
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        'Dim bytArray(7) As Byte
        '-- Creating a thread for the timeout event
        'Dim objTimeOutThread As New ThreadTimeOut()
        'Dim otter As New ThreadStart(AddressOf objTimeOutThread.REadTimeOut)
        'Dim oThread As New Thread(otter)

        Try
            'Return ReceiveData(bytArray, lngInTime)
            'Return True

            If Not ReceiveData(bytArray, lngInTime) Then
                'If Not gFuncReadBuffer_test(bytArray, lngInTime) Then
                '--- Check for the byte array
                'Exit Try
                '---changed by deepak 21.06.07
                Return False
            Else
                '--- Check for the array 
                If Not FuncValidateBlock(bytArray) Then
                    'Exit Try
                    '---changed by deepak 21.06.07
                    Return False
                End If
            End If

            Return True
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

    Public Function gFuncTransmitCommand(ByVal intCommand As Int32, _
                                       ByVal intParameter1 As Int32, _
                                       ByVal intParameter2 As Int32, _
                                       ByVal intParameter3 As Int32) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncTransmitCommand
        'Description:       Function is used to send the transmit Command to the Tx Buffer
        'Parameters :       Comand, Parameter1, Parameter2, Parameter3
        'Time/Date  :       5/9/06
        'Dependencies:      A proper command and parameters should be provided
        'Author:            Rahul B.
        'Revision:      
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Dim bytArray(7) As Byte
        Dim intCount As Int16 = 0

        Try
            Return TransmitCommand(intCommand, intParameter1, intParameter2, intParameter3)
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

    Private Function FuncValidateBlock(ByVal bytArray As Byte()) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    FuncValidateBlock
        'Description:       Validation are to made with respect to the recieved Block From the Rx Buffer
        'Parameters :       Byte array
        'Time/Date  :       9.37 13 Oct 2003
        'Dependencies:      Block should present
        'Author:            Mandar
        'Revision:
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Try
            If UBound(bytArray) = 7 Then
                If CInt(bytArray(0)) = 50 And CInt(bytArray(7)) = 52 Then

                    'If CInt(bytArray(1)) = EnumUVProtocol.Ret_Ack Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.Reset_Ack Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.Data Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.CMD_Acknowledge Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.Spect_End Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.CMD_End Then

                    ''--- Get the parameters
                    'mbytCommand = bytArray(1)
                    'mbytParameter1 = bytArray(2)
                    'mbytParameter2 = bytArray(3)
                    'mbytParameter3 = bytArray(4)
                    'mbytParameter4 = bytArray(5)
                    Dim intCount As Integer
                    Dim lngVal As Long
                    For intCount = 0 To 7 Step 1
                        lngVal += bytArray(intCount)
                    Next
                    lngVal = lngVal - bytArray(5)
                    Dim bytConverted As Byte

                    '---conversion of long to byte
                    lngVal = 0 - lngVal
                    bytConverted = gFunclongtobyte(lngVal)
                    If bytConverted = bytArray(5) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If

            'added and commented by kamal
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

#Region "Functions For CommPort2"

    Public Sub Close2()
        Try
            'This function closes the comport
            'by releasing it's filehandle
            comm.Close()
            m_opened2 = False

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

    Public Function gFuncOpenCommPort2(ByVal intComPortIn As Integer, _
                                       ByVal lngBaudRateIn As Long, _
                                       ByVal intParityBitIn As Integer, _
                                       ByVal intStopBitIn As Integer, _
                                       ByVal intDataBitIn As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncOpenCommPort2
        'Description:       To open the 2nd communication port of the PC for the data transmission 
        'Parameters :       gintCommPortSelected2 is globaly affected
        'Time/Date  :       
        'Dependencies:      2nd Comm port of the pc should present
        'Author:            Santosh
        'Revision:          
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Try
            OpenComm(intComPortIn, lngBaudRateIn, intParityBitIn, intStopBitIn, intDataBitIn)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If

        End Try

    End Function

    Public Function gFuncIsPortOpen2() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncIsPortOpen2
        'Description:       To Check is port open by our EXE
        'Parameters :       None
        'Time/Date  :       070404
        'Dependencies:     
        'Author:            santosh
        'Revision:
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Try
            If Opened2 = True Then
                gFuncIsPortOpen2 = True
            Else
                gFuncIsPortOpen2 = False
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

    Public Function gFuncCloseComm2() As Boolean
        Try
            gFuncCloseComm2 = False
            If Opened2 = True Then
                Close2()
                gFuncCloseComm2 = True
            End If
            'added and commented by kamal on 19March2004
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

