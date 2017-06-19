
Public Class clsRS232Main
    'Inherits clsRS232

#Region " Class Member Variables "

    Private mblnTimeOut As Boolean = False
    Private mblnReadComplete As Boolean = False

    Private bytBuffer(7) As Byte

    Private mlngBaudRate As Long
    Private mintParityBits As Int16
    Private mintStopBits As Int16
    Private mintDataBits As Int16
    Private Shared mblnIsNeedReceive As Boolean = False
    'Public Shared mCommflag As Boolean = False '10.12.07
    Public Shared mInCommu As Boolean = False  '10.12.07
    Public Shared gblnInCommProcess As Boolean = False      '10.12.07
    Public Shared glngProcTimeInMSec As Long    '10.12.07

    'Private InCommu As Boolean

#End Region

#Region " Constructors "

    Public Sub New(ByVal lngBaudRate As Long, ByVal intParityBits As Int16, ByVal intStopBits As Int16, ByVal intDataBits As Int16)
        'strPath = Mid(strPath, 1, strPath.Length - (strPath.Length - InStrRev(strPath, "\", strPath.Length, CompareMethod.Text)))
        'INI_SETTINGS_PATH = strPath '& "RS232Settings.ini"
        mlngBaudRate = lngBaudRate
        mintParityBits = intParityBits
        mintStopBits = intStopBits
        mintDataBits = intDataBits
    End Sub

#End Region

#Region " Public Properties, Enums, Events, Constants, Structures.. "

    Public Enum CommErrorCode
        CommNotOpen = 1
        ReceiveBlockError = 2
    End Enum

    Public Event CommError(ByVal intErrorCode As CommErrorCode)

    Public Event CommStatus(ByVal strMessage As String)

    'Public Shared ReadOnly Property IsCommuOk() As Boolean
    '    Get
    '        Return mCommflag
    '    End Get
    '    'Set(ByVal Value As Boolean)
    '    '    mCommflag = Value
    '    'End Set
    'End Property   '10.12.07

    Public Shared Property IsNeedReceive() As Boolean
        Get
            Return mblnIsNeedReceive
        End Get
        Set(ByVal Value As Boolean)
            mblnIsNeedReceive = Value
        End Set
    End Property   '10.12.07

    Public Shared ReadOnly Property IsInCommu() As Boolean
        Get
            'Return mInCommu
            Return gblnInCommProcess
        End Get
        'Set(ByVal Value As Boolean)
        '    mInCommu = Value
        'End Set
    End Property   '10.12.07

#End Region

#Region " Private Functions "

    Private Function gFunclongtobyte(ByVal lngparameter As Long) As Byte
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

    Private Function funcConstructCommandBlock(ByRef bytArray() As Byte, _
                                               ByVal intCommand As Int32, _
                                               ByVal intParameter1 As Int32, _
                                               ByVal intParameter2 As Int32, _
                                               ByVal intParameter3 As Int32) As Boolean
        '-----------------------------------------------------------------------------------------
        'Procedure Name:    funcConstructCommandBlock
        'Description:       Function used to genereate a Block of byte array for the Tx 
        'Parameters :       byref Byte Array , Command , parameters
        'Time/Date  :       9.33 13 Oct' 2003
        'Dependencies:      A proper command and parameters should be provided
        'Author:            Mandar
        'Revision:
        'Revision by Person:
        '-----------------------------------------------------------------------------------------
        Dim intCount As Int16
        Dim lngVal As Long

        Try
            bytArray(0) = CByte(&H32)               '50     '// Start of Block
            bytArray(1) = CByte(intCommand)
            bytArray(2) = CByte(intParameter1)
            bytArray(3) = CByte(intParameter2)
            bytArray(4) = CByte(intParameter3)
            bytArray(5) = CByte(0)                  '       '/* Checksum	    */
            bytArray(6) = CByte(&H20)               '32 '166 'cnyte("A")  '		/* Blank Spcae*
            bytArray(7) = CByte(&H34) '52 'Asc("4") '4';	'	/* End of Block     */

            For intCount = 0 To 7 Step 1
                lngVal += bytArray(intCount)
            Next

            '---conversion of long to byte
            Dim bytConverted As Byte
            lngVal = 0 - lngVal
            bytConverted = gFunclongtobyte(lngVal)

            If bytConverted <> 0 Then
                '-----------change by Rahul B.
                'bytConverted = CByte(256 - bytConverted) '256
                '-----------------------------
                'bytConverted = CByte(lngVal)  '256
            End If
            '--- Add the Check Sum bit
            '------commented by Rahul
            bytArray(5) = bytConverted
            '---------------------

            Return True

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

#Region " Serial Communication Functions "

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
            gFuncOpenCommPort = False

            intCommPort = intComPortIn

            If mrs232.IsPortAvailable(intCommPort) = False Then Return False

            With mrs232
                .Speed = mlngBaudRate
                .Port = intCommPort
                .DataBits = mintDataBits
                .StopBits = mintStopBits
                .Parity = mintParityBits
            End With

            '--- Open Port 
            mrs232.Open()

            If mrs232.Opened Then
                gFuncOpenCommPort = True
            Else
                gFuncOpenCommPort = False
            End If
            mblnIsNeedReceive = True
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
        End Try
    End Function

    Public Function gFuncTransmitCommand(ByVal intCommand As Int32, _
                                             ByVal intParameter1 As Int32, _
                                             ByVal intParameter2 As Int32, _
                                             ByVal intParameter3 As Int32) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncTransmitCommand
        'Description:       Function is used to send the transmit Command to the Tx Buffer
        'Parameters :       Command, Parameter1, Parameter2, Parameter3
        'Time/Date  :       5/9/06
        'Dependencies:      A proper command and parameters should be provided
        'Return             True/False
        'Author:            Sachin Dokhale
        'Revision:      
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Try
            'mrs232.funcPeekMessage() '10.12.07
            If gblnSetSpeedIssue = True Then
                Return gFuncTransmitCommand_Speed(intCommand, _
                                        intParameter1, _
                                        intParameter2, _
                                        intParameter3)
            Else
                Return gFuncTransmitCommand_Orig(intCommand, _
                                        intParameter1, _
                                        intParameter2, _
                                        intParameter3)

            End If
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
    Public Function gFuncTransmitCommand_Orig(ByVal intCommand As Int32, _
                                         ByVal intParameter1 As Int32, _
                                         ByVal intParameter2 As Int32, _
                                         ByVal intParameter3 As Int32) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncTransmitCommand_Orig
        'Description:       Function is used to send the transmit Command to the Tx Buffer
        'Parameters :       Command, Parameter1, Parameter2, Parameter3
        'Time/Date  :       5/9/06
        'Dependencies:      A proper command and parameters should be provided
        'Return             True/False
        'Author:            Rahul B.
        'Revision:      
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Dim bytArray(7) As Byte
        Dim intCount As Int16 = 0

        Try
            '--- ReSet the Boolean flags 
            mblnReadComplete = False
            mblnTimeOut = False

            ' modified by sns on 26Mar07
            'Call subTime_Delay(18) 'Added by pankajon 12 sep 07

            Call subTime_Delay(20)

            '---funcPeekMssage is added by Deepak B. on 13.08.07 for synchronous messages processing
            'For intCount = 0 To 5 'By Pankaj 12 sep 07
            'mrs232.funcPeekMessage()
            'Next
            '-------

            '---Clear the array contenets first
            'For intCount = 0 To 7
            '    bytBuffer(intCount) = 0
            '    bytArray(intCount) = 0
            'Next

            If Not funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3) Then
                Return False
                Exit Function
            End If

            Call mrs232.Write(bytArray)

            Return True

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

    Public Function gFuncTransmitCommand_Speed(ByVal intCommand As Int32, _
                                        ByVal intParameter1 As Int32, _
                                        ByVal intParameter2 As Int32, _
                                        ByVal intParameter3 As Int32) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncTransmitCommand_Speed
        'Description:       Function is used to send the transmit Command to the Tx Buffer
        'Parameters :       Command, Parameter1, Parameter2, Parameter3
        'Time/Date  :       5/9/06
        'Dependencies:      A proper command and parameters should be provided
        'Return             True/False
        'Author:            
        'Revision:      
        'Revision by Person:
        '--------------------------------------------------------------------------------------

        'BOOL  Transmit(BYTE command, BYTE para1, BYTE para2, BYTE para3)
        '{
        'BOOL	flag=FALSE;

        '        If (InCommu) Then
        '	 return FALSE;

        '  InCommu =TRUE;

        '	Construct_Block(command, para1, para2, para3);

        '  flag = TransBlock();

        '  InCommu =FALSE;
        'return flag;
        '}
        Dim tout As Integer = CONST_LONG_DELAY

        Dim bytArray(7) As Byte
        Try
            If mInCommu = True Then Return False '10.12.07
            If gblnInCommProcess = True Then Return False '10.12.07
            mInCommu = True                      '10.12.07   
            gblnInCommProcess = True             '10.12.07
            glngProcTimeInMSec = CONST_LONG_DELAY   '10.12.07
            Dim flag As Boolean = False
            subTime_Delay(1)
            funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3)
            flag = mrs232.funcTransBlock(bytArray, tout)
            'Application.DoEvents() 
            mInCommu = False                    '10.12.07
            'gblnInCommProcess = False           '10.12.07
            Return flag
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mInCommu = False
            glngProcTimeInMSec = 0
            gblnInCommProcess = False
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


    Public Function gFuncReadBuffer_orig(ByRef bytarray() As Byte, ByVal lngInTime As Long) As Boolean
        '---------------------------------------------------------------------------------------
        'Procedure Name :   gFuncReadBuffer
        'Description    :   To read the Specified bits of data from the Rx Buffer
        'Parameters     :   Byte Array & lngInTime
        'Time/Date      :   
        'Dependencies   :   Comm port should be available   
        'Author         :   Santosh
        'Revision       :          
        'Revision by    :   Santosh
        '---------------------------------------------------------------------------------------
        Dim bytBuff As Byte()
        Dim lngcounter As Long
        Dim intcount As Integer
        Dim lngTmr1 As Long
        Dim lngTmr2 As Long

        Try
            'lngTmr1 = System.DateTime.Now.Ticks / 10000
            'Do While (True)
            '    '---funcPeekMessage is added by Deepak B. on 13.08.07 for synchronous messages processing
            '    'mrs232.funcPeekMessage() 'By Pankaj for vc comm
            '    '-------
            '    lngTmr2 = System.DateTime.Now.Ticks / 10000
            '    If CLng(lngTmr2 - lngTmr1) < lngInTime Then
            '        If mrs232.Read(bytBuff) Then
            '            '--- Check for the data
            '            If bytBuff.Length >= 8 Then
            '                bytarray = bytBuff
            '                Return True
            '                Exit Do
            '            End If
            '        End If
            '    Else ' lngInTime timer over
            '        Return False
            '        Exit Do
            '    End If
            '    Erase bytBuff
            '    'System.Windows.Forms.Application.DoEvents()
            '    'mrs232.funcPeekMessage() 'Added by pankaj for vc dll
            'Loop
            '--- Added by Sachin Dokhale 
            'If Not mCommflag Then Return False
            'Erase bytarray
            'lngTmr1 = System.DateTime.Now.Ticks / 10000

            'Do While (True)
            '    '---funcPeekMessage is added by Deepak B. on 13.08.07 for synchronous messages processing
            '    'mrs232.funcPeekMessage() 'By Pankaj for vc comm
            '    '-------
            '    lngTmr2 = System.DateTime.Now.Ticks / 10000
            '    If CLng(lngTmr2 - lngTmr1) < lngInTime Then
            '        'If mrs232.Read(bytBuff) Then
            '        '    '--- Check for the data
            '        '    If bytBuff.Length >= 8 Then
            '        '        bytarray = bytBuff
            '        '        Return True
            '        '        Exit Do
            '        '    End If
            '        'End If

            '    Else ' lngInTime timer over
            '        Return False
            '        Exit Do
            '    End If
            '    Erase bytBuff
            '    'System.Windows.Forms.Application.DoEvents()
            '    'mrs232.funcPeekMessage() 'Added by pankaj for vc dll
            'Loop

            If mrs232.Read(bytBuff, lngInTime) Then
                '--- Check for the data
                'If bytBuff.Length >= 8 Then
                bytarray = bytBuff
                Return True
                'End If
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
            bytBuff = Nothing
            'System.Windows.Forms.Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncResumeProcess() As Boolean
        Dim lngTimeDelay As Long
        Dim lngTimeDelay_W As Long
        Dim lng As Long
        Dim lng1 As Long
        Dim intCount As Int16
        Dim ConstManipulate As Long = 10000 ' this will manipulate tick count for each mili second

        Try
            'Return mobjCommdll.gFuncTransmitCommand(intCommand, intPar1, intPar2, intPar3)
            lngTimeDelay = 0
            gFuncResumeProcess = False
            lngTimeDelay_W = CLng(System.DateTime.Now.Ticks) / ConstManipulate
            lngTimeDelay_W = lngTimeDelay_W + glngProcTimeInMSec

            Do While lngTimeDelay < lngTimeDelay_W
                '--- This loop will execute until the delay condition gets satisfied
                'For intCount = 1 To 100
                'intCount = intCount + 1
                'Next
                Application.DoEvents()
                clsRS232.funcPeekMessage()
                'System.Windows.Forms.Application.DoEvents()
                lngTimeDelay = CLng(System.DateTime.Now.Ticks) / ConstManipulate
                'lng1 = lngTimeInMSeconds - GetTickCount()
                'Application.DoEvents()
                'System.Windows.Forms.Application.DoEvents()
                'If (Me.IsInCommu = False) AndAlso (mInCommu = False) Then
                If (Me.IsInCommu = False) And (clsRS232.mCommflag = True) Then
                    'If (Me.IsInCommu = False) And (clsRS232.mCommflag = True) Then 'by pankaj on 1 Feb 08
                    Return True
                End If
            Loop
            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                Return True
            End If

            clsRS232.funcPeekMessage()
            Return False
            'If Me.IsInCommu = False Then
            '    Return True
            'End If

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
                clsRS232.funcPeekMessage()
                'System.Windows.Forms.Application.DoEvents()
                lngTimeDelay = CLng(System.DateTime.Now.Ticks) / ConstManipulate
                'lng1 = lngTimeInMSeconds - GetTickCount()
                'Application.DoEvents()
                System.Windows.Forms.Application.DoEvents()
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
            If mrs232.Opened = True Then
                gFuncIsPortOpen = True
            Else
                gFuncIsPortOpen = False
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
            If mrs232.IsPortAvailable(intPortNumber) Then
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

    Public Function gFuncCloseComm() As Boolean
        Try
            If mrs232.Opened = True Then
                mrs232.Close()
                Return True
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

    Public Function gFuncReceiveData_test(ByRef bytArray() As Byte, ByVal lngInTime As Long) As Boolean
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
            If Not gFuncReadBuffer_test(bytArray, lngInTime) Then
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
            If mInCommu Then Return False '10.12.07
            mInCommu = True                 '10.12.07
            gblnInCommProcess = True
            glngProcTimeInMSec = lngInTime
            If Not gFuncReadBuffer_orig(bytArray, lngInTime) Then
                'If Not gFuncReadBuffer_test(bytArray, lngInTime) Then
                '--- Check for the byte array
                mInCommu = False        '10.12.07
                gblnInCommProcess = False '10.12.07
                glngProcTimeInMSec = 0  '10.12.07
                'Exit Try
                '---changed by deepak 21.06.07
                If mblnIsNeedReceive = True Then
                    'Error While Receiving Block
                    gobjMessageAdapter.ShowMessage("Error while receiving block", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, False, False)
                    Application.ExitThread()
                    Application.Exit()
                    End
                End If
                Return False
            Else
                '--- Check for the array 
                If Not FuncValidateBlock(bytArray) Then
                    'Exit Try
                    mInCommu = False        '10.12.07
                    gblnInCommProcess = False '10.12.07
                    glngProcTimeInMSec = 0  '10.12.07
                    'Error in the Recived Block
                    If mblnIsNeedReceive = True Then
                        gobjMessageAdapter.ShowMessage("Error in the received block", "", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage, False, False)
                        Application.ExitThread()
                        Application.Exit()
                        End
                    End If
                    '---changed by deepak 21.06.07
                    Return False
                End If
            End If
            mInCommu = False        '10.12.07
            gblnInCommProcess = False '10.12.07
            glngProcTimeInMSec = 0  '10.12.07
            mblnIsNeedReceive = True
            Return True

            'added and commented by kamal
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            glngProcTimeInMSec = 0  '10.12.07
            mInCommu = False        '10.12.07
            gblnInCommProcess = False '10.12.07
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
        'Revision by Person: Sachin Dokhale on 6 Jan 08
        '--------------------------------------------------------------------------------------
        Dim intCount As Integer
        Dim lngVal As Long
        Try
            If UBound(bytArray) = 7 Then
                If CInt(bytArray(0)) = 50 And CInt(bytArray(7)) = 52 Then

                    'If CInt(bytArray(1)) = EnumUVProtocol.Ret_Ack Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.Reset_Ack Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.Data Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.CMD_Acknowledge Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.Spect_End Or _
                    'CInt(bytArray(1)) = EnumUVProtocol.CMD_End Then

                    '--- check Return Flags
                    'if (CheckBlock()&&(Block[1]==RETURNACK || Block[1]==RESETACK || Block[1]==RESETACK_AA202) )
                    '{
                    ' if(Block[1]==RESETACK_AA202)
                    ' {
                    '  if( InstType != AA202 )
                    '	 {
                    '	  if(MessageBox(hpar,"You have selected AA203, but AA202 found. Configure for AA202 ?","INSTRU. ERROR",MB_ICONSTOP | MB_YESNO)== IDYES)
                    '		WriteProfileStringFromIniFile("Instrument", "Setting","AA202", "aas.ini");
                    '		CloseandExit();
                    '	  InstType = AA202;
                    '	 }
                    ' }
                    ' if(Block[1]==RESETACK)
                    '{
                    '  if( InstType != AA203 )
                    '	{
                    '	  if(MessageBox(hpar,"You have selected AA202, but AA203 found. Configure for AA203 ?","INSTRU. ERROR",MB_ICONSTOP | MB_YESNO)== IDYES)
                    '		WriteProfileStringFromIniFile("Instrument", "Setting","AA203", "aas.ini");
                    '		CloseandExit();
                    '	  InstType = AA203;
                    '	}
                    '}
                    If (CInt(bytArray(1)) = EnumAAS203Protocol.RESETACK_AA201) And (Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201)) Then
                        gobjMessageAdapter.ShowMessage("You have selected different instrument but AA201 found. Please select proper instrument", "Instrument Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                        Return False
                        'ElseIf (CInt(bytArray(1)) = EnumAAS203Protocol.RESETACK) And (Not (gstructSettings.AppMode = EnumAppMode.FullVersion_203)) Then
                        '    '    gobjMessageAdapter.ShowMessage("You have selected different instrument but AA203 found. Please select proper instrument", "Instrument Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                        '    '    Return False
                        'E   'ElseIf (CInt(bytArray(1)) = EnumAAS203Protocol.AA203D) And (Not (gstructSettings.AppMode = EnumAppMode.FullVersion_203D)) Then
                        '    '    gobjMessageAdapter.ShowMessage("You have selected different instrument but AA203D found. Please select proper instrument", "Instrument Error", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                    End If

                    ''--- Get the parameters
                    'mbytCommand = bytArray(1)
                    'mbytParameter1 = bytArray(2)
                    'mbytParameter2 = bytArray(3)
                    'mbytParameter3 = bytArray(4)
                    'mbytParameter4 = bytArray(5)
                    'Dim intCount As Integer
                    'Dim lngVal As Long
                    'Manoj chamged from '0 TO 7' to '0to10'
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

                Else
                    'else{
                    'if(InstType == AA202){
                    ' if(Block[1] == CHKSUMERR){
                    ' InCommu =FALSE;
                    ' return flag1;
                    ' }
                    '}
                    If (gstructSettings.AppMode = EnumAppMode.FullVersion_201) And (bytArray(1) = EnumAAS203Protocol.CHKSUMERR) Then
                        'Return flag1
                        Return False
                    End If
                End If
            End If
            Return False
            'added and commented by kamal
            '----------------------------
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
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
        Try
            Return mrs232.gFuncReadBuffer_test(bytarray, lngInTime)
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

    Public Function gFuncTransmitCommand_test(ByVal intCommand As Int32, _
                                         ByVal intParameter1 As Int32, _
                                         ByVal intParameter2 As Int32, _
                                         ByVal intParameter3 As Int32) As Boolean
        'BOOL  Transmit(BYTE command, BYTE para1, BYTE para2, BYTE para3)
        '{
        'BOOL	flag=FALSE;

        '        If (InCommu) Then
        '	 return FALSE;

        '  InCommu =TRUE;

        '	Construct_Block(command, para1, para2, para3);

        '  flag = TransBlock();

        '  InCommu =FALSE;
        'return flag;
        '}
        Dim tout As Integer = CONST_LONG_DELAY

        Dim bytArray(7) As Byte
        Try
            Dim flag As Boolean = False

            funcConstructCommandBlock(bytArray, intCommand, intParameter1, intParameter2, intParameter3)
            flag = mrs232.funcTransBlock(bytArray, tout)

            Return flag
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


#End Region

#Region " Serial Communication functions for AutoSampler "

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
            gFuncOpenCommPort2 = False

            If mrs232.IsPortAvailable(intComPortIn) = False Then Exit Function

            With mrs232
                .Speed2 = lngBaudRateIn
                .Port2 = intComPortIn
                .DataBits2 = intDataBitIn
                .StopBits2 = intStopBitIn
                .Parity2 = intParityBitIn
            End With

            '--- Open Port 
            mrs232.Open2()

            If mrs232.Opened2 Then
                'gintCommPortSelected2 = intComPortIn  '--- For further use
                gFuncOpenCommPort2 = True
            Else
                gFuncOpenCommPort2 = False
            End If

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

        End Try

    End Function

    Public Function gFuncCloseComm2() As Boolean
        Try
            gFuncCloseComm2 = False
            If mrs232.Opened2 = True Then
                mrs232.Close2()
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

    Public Function gFuncReadBuffer2(ByRef bytarray() As Byte, _
                                        ByVal lngInTime As Long) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name :   gFuncReadBuffer2
        'Description    :   To read the Specified bits of data from the Rx Buffer of 2nd comm port
        'Parameters     :   Byte Array & lngInTime
        'Time/Date      :   
        'Dependencies   :   2nd Comm port should be available & opened   
        'Author         :   Santosh
        'Revision       :          
        'Revision by Person:Santosh
        '--------------------------------------------------------------------------------------
        gFuncReadBuffer2 = False
        Try
            Dim bytBuff As Byte()
            Dim lngcounter As Long
            Dim intcount As Integer
            Dim lngTmr1 As Long
            Dim lngTmr2 As Long

            lngTmr1 = System.DateTime.Now.Ticks / 10000
            '---
            Do While (True)
                'Application.DoEvents()
                mrs232.funcPeekMessage() 'Added by pankaj on 24 Mar 08
                lngTmr2 = System.DateTime.Now.Ticks / 10000
                If CLng(lngTmr2 - lngTmr1) < lngInTime Then
                    If mrs232.ReadByte2(bytBuff) Then
                        '--- Check for the data
                        If bytBuff.Length >= 1 Then
                            bytarray = bytBuff
                            gFuncReadBuffer2 = True
                            Exit Do
                        End If

                    End If
                Else ' lngInTime timer over
                    gFuncReadBuffer2 = False
                    Exit Do
                End If
            Loop


            'added and commented by kamal
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


    Public Function gFuncReceiveByte2(ByRef bytCommandReceived As Byte, ByVal lngInTime As Long) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gFuncReceiveByte2
        'Description	    :   To Retrieve the data in the Input Buffer
        'Parameters 	    :   Boolean Double Processing and Time delay in passed as Long
        'Time/Date  	    :   15.50  17 feb 2004
        'Dependencies	    :   port should be open 
        'Author		        :   Santosh
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim bytArray(1) As Byte

        gFuncReceiveByte2 = False
        Try

            If gFuncReadBuffer2(bytArray, lngInTime) Then
                bytCommandReceived = bytArray(0)
                gFuncReceiveByte2 = True 'moved by pankaj on 23 Mar 08
            End If
            'gFuncReceiveByte2 = True

            'added and commented by kamal
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

    Public Function gFuncTransmitByte2(ByVal bytCommandTransmit As Byte) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name:    gFuncTransmitByte2
        'Description:       Function is used to send the transmit character to 2nd comm port selected for autosampler
        'Parameters :       
        'Time/Date  :       070404 19.29 pm
        'Dependencies:      
        'Author:            Santosh
        'Revision:      
        'Revision by Person:
        '--------------------------------------------------------------------------------------
        Dim bytArray(1) As Byte
        Dim intCount As Int16 = 0

        gFuncTransmitByte2 = False

        Try
            '--- Clear the array contenets first
            subTime_Delay(10)

            bytArray(0) = bytCommandTransmit
            
            mrs232.WriteByte2(bytArray)
            gFuncTransmitByte2 = True

            'added and commented by kamal
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
            If mrs232.Opened2 = True Then
                gFuncIsPortOpen2 = True
            Else
                gFuncIsPortOpen2 = False
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

    'Private Function PC_Delay(ByVal intDelay As Long)
    '    'void  S4FUNC 	pc_delay(unsigned t)
    '    '{
    '    'unsigned  long i,j, k=1;
    '    '  j = (unsigned long ) ((double) t * 5.0);
    '    ' for (i=1; i<=j; i++)
    '    '	  k++;
    '    '}
    '    Dim intI, intJ, intK As Long
    '    intK = 1
    '    intJ = intDelay * 5
    '    For intI = 1 To intJ
    '        intK = intK + 1
    '    Next
    'End Function

End Class

