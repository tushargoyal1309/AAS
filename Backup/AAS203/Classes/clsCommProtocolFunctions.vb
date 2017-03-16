Imports AAS203.Common
Imports AAS203Library.Instrument
  _
'/ <summary>
'/ clss Comm Protocol Functions
'/ </summary>

Public Class clsCommProtocolFunctions

#Region " Class Member Variables "
    Private mobjfrmZeroOrder As frmZeroOrder
    Private mobjfrmturretOptimisation As frmTurretOptimisation

    Private mobjClsInstrument As ClsInstrument

    Private mblnSRLamp As Boolean
    Private mintSSGain As Integer

    '---Public Object for Serial Comm DLL
    'Public WithEvents mobjCommdll As RS232SerialComm.clsRS232Main
    Public WithEvents mobjCommdll As clsRS232Main
    'Public mobjCommdll As VCRS232SERIALCOMMLib.clsRS232MainClass
    'Public mobjCommdll As New CSerial
    'Public WithEvents mobjCommdllAutoSampler As RS232SerialComm.clsRS232Main
    Public WithEvents mobjCommdllAutoSampler As clsRS232Main

    'Public gblnHydrideMode As Boolean = False
    Dim bytRandom As New System.Random
    Dim mintNVpos As Integer = 0
    Private mintFirstDisp As Integer
    'Private Commflag As Boolean = False
#End Region

#Region " Public Properties  "

    Public Property SRLamp() As Boolean
        Get
            Return mblnSRLamp
        End Get
        Set(ByVal Value As Boolean)
            mblnSRLamp = Value
        End Set
    End Property

#End Region

#Region " Constructors and Destructors "

    Public Sub New()

        mobjfrmZeroOrder = New frmZeroOrder
        'mobjCommdll = New VCRS232SERIALCOMMLib.clsRS232MainClass
        'mobjCommdll = New RS232SerialComm.clsRS232Main(9600, 0, 1, 8)
        'mobjCommdllAutoSampler = New RS232SerialComm.clsRS232Main(9600, 0, 1, 8)

        mobjCommdll = New clsRS232Main(9600, 0, 1, 8)
        mobjCommdllAutoSampler = New clsRS232Main(9600, 0, 1, 8)

        mblnSRLamp = False
        mintSSGain = &H0

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

#Region " Private Functions "

    Private Function Wav_Pos(ByVal dblWvNew As Double, Optional ByRef lblUVWavelengthStatus As Label = Nothing) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   Wav_Pos
        'Description            :   To position the wavelength
        'Parameters             :   new wavelength to position
        'Time/Date              :   08.11.06
        'Dependencies           :   communication
        'Author                 :   Deepak Bhati
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'void 	Wav_Pos(HDC hdc, double wvnew, int x, int y)
        '{
        '   double    x1;
        '   unsigned i,ch, j;
        '   hold = Load_Curs();
        '   Inst.Wvcur = Get_Cur_Wv();
        '   if (Inst.Wvcur!=wvnew){ //1
        '       if (wvnew>=0 && wvnew <=1000.0){ //2
        '	        x1 = (wvnew * (double)StepPerNm)+(double)0.1;
        '	        i =(unsigned) x1;
        '	        Transmit(WVSET, (BYTE) i, (BYTE) (i>>8), 0);
        '	        if (Inst.Wvcur> wvnew)  i = (unsigned) ((Inst.Wvcur-wvnew)*(double)1.0);
        '	        else{ //3
        '		        i = (unsigned) ((wvnew-Inst.Wvcur)*(double)1.0);
        '		        Inst.Wvcur = wvnew;
        '		    }//3
        '	        for (j=1; j<=i;j++){ //4
        '		        if (Recev(TRUE)){//5
        '		            ch = Param2*256+Param1;
        '		            if (hdc!=NULL){//6
        '		                if( InstType == AA202 ){//7
        '			                Wprintf(hdc, x, y, "%-5.2f nm  ",(double) (ch/StepPerNm));
        '		                }//7
        '                       Else
        '			                Wprintf(hdc, x, y, "%-5.2f nm  ",Inst.Wvcur - (double) (ch/StepPerNm));
        '		            }//6
        '		        }//5
        '               else
        '	                break;
        '           }//4
        '       } //2
        '	    else {//8
        '	        wvnew = -1;
        '	        Beep();Beep();
        '	        Gerror_message(" Monochromator error \n **ERROR*** out of range");
        '	    }//8
        '	    if( InstType == AA202 ){//9
        '		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
        '		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
        '		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
        '		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
        '		    pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);pc_delay(10000);
        '	    }//9
        '	    Inst.Wvcur = Get_Cur_Wv();
        '	    if( InstType == AA202 )
        '		    wvnew = Inst.Wvcur;
        '       If (Inst.Wvcur != wvnew) Then
        '	        Gerror_message("Error in Monochromator");
        '   }//1
        '   SetCursor(hold);
        '}

        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim dblx1 As Double
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim Int_I, IntCh, IntJ As Int32
        Dim blnIsReceiveBloc As Boolean = False


        ''Dim StepPerNm As Double = 50.0

        Try
            Call funcGet_Current_Wv(gobjInst.WavelengthCur)


            If gobjInst.WavelengthCur <> dblWvNew Then
                If (dblWvNew >= 0 And dblWvNew <= 1000.0) Then

                    '---Commented by Mangesh on 17-Apr-2007 for AA201 
                    ''dblx1 = (dblWvNew * StepPerNm) + 0.1
                    '---Commented by Mangesh on 17-Apr-2007 for AA201 

                    '**********************************************************
                    '---Added and Changed by Mangesh on 17-Apr-2007 for AA201 
                    '**********************************************************
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                        dblx1 = (dblWvNew * CONST_STEPS_PER_NM_AA201) + 0.1
                    Else
                        dblx1 = (dblWvNew * CONST_STEPS_PER_NM) + 0.1
                    End If
                    '**********************************************************

                    Int_I = Fix(dblx1)

                    bytLow = CByte(Int_I And &HFF)
                    bytHigh = CByte(Int_I >> 8)
                    ' gblnInComm = True          '10.12.07
                    If mobjCommdll.gFuncResumeProcess = True Then   '10.12.07
                        mobjCommdll.IsNeedReceive = False   '12.02.08
                        If FuncTransmitCommand(EnumAAS203Protocol.WVSET, bytLow, bytHigh, 0) Then
                            If gobjInst.WavelengthCur > dblWvNew Then
                                Int_I = Fix((gobjInst.WavelengthCur - dblWvNew) * 1.0)
                            Else
                                Int_I = Fix((dblWvNew - gobjInst.WavelengthCur) * 1.0)
                                gobjInst.WavelengthCur = dblWvNew
                            End If
                            '//----- Commeted by Sachin Dokhale on 25.04.08
                            'clsRS232Main.gblnInCommProcess = False  '12.02.08
                            '//-----
                            For IntJ = 1 To Int_I
                                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                                    If bytArray(1) = 1 Then
                                        IntCh = (bytArray(3) * 256) + bytArray(2)
                                        '//----- Added by Sachin Dokhale
                                        If Not IsNothing(lblUVWavelengthStatus) Then
                                            'if( InstType == AA202 )//7
                                            '{
                                            '   Wprintf(hdc, x, y, "%-5.2f nm  ",(double) (ch/StepPerNm));
                                            '}//7
                                            'Else
                                            '   Wprintf(hdc, x, y, "%-5.2f nm  ",Inst.Wvcur-(double) (ch/StepPerNm));
                                            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                                lblUVWavelengthStatus.Text = "Wavelength (nm): " & (IntCh / CONST_STEPS_PER_NM_AA201)
                                            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                                                '//--- Modified by Sachin Dokhale on 13.02.08
                                                lblUVWavelengthStatus.Text = "Wavelength (nm): " & gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM)
                                                'lblUVWavelengthStatus.Text = "Wavelength (nm): " & FormatNumber(gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM), 0)
                                            Else
                                                lblUVWavelengthStatus.Text = "Wavelength (nm): " & gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM)
                                                'lblUVWavelengthStatus.Text = "Wavelength (nm): " & FormatNumber(gobjInst.WavelengthCur - (IntCh / CONST_STEPS_PER_NM), 0)
                                            End If

                                            lblUVWavelengthStatus.Refresh()
                                        End If
                                        '//-----
                                    Else
                                        Exit For
                                    End If
                                End If
                                blnIsReceiveBloc = True
                            Next
                            '//----- Added by Sachin Dokhale on 25.04.08
                            If blnIsReceiveBloc = False Then
                                clsRS232Main.gblnInCommProcess = False
                            End If
                            '//-----
                        End If
                        mobjCommdll.IsNeedReceive = True   '12.02.08
                    End If
                Else
                    dblWvNew = -1
                    Beep()
                    Beep()
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or gstructSettings.AppMode = EnumAppMode.FullVersion_203 Or gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                        Call gobjMessageAdapter.ShowMessage(constMonochromatorError)
                    End If
                End If
                gblnInComm = False
                '//----- Added by Sachin Dokhale on 03.10.07
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                    gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                End If
                '//-----
                gblnInComm = False
                Call funcGet_Current_Wv(gobjInst.WavelengthCur)
                'if( InstType == AA202 )
                '   wvnew = Inst.Wvcur;
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    dblWvNew = gobjInst.WavelengthCur
                End If

                If gobjInst.WavelengthCur <> dblWvNew Then
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or gstructSettings.AppMode = EnumAppMode.FullVersion_203 Or gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                        Call gobjMessageAdapter.ShowMessage(constMonochromatorError)
                    End If
                Else
                    lblUVWavelengthStatus.Text = "Wavelength (nm): " & gobjInst.WavelengthCur
                End If
            Else
                lblUVWavelengthStatus.Text = "Wavelength (nm): " & gobjInst.WavelengthCur
                lblUVWavelengthStatus.Refresh()
            End If
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
            'objWait.Dispose()
            gblnInComm = False
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function FuncTransmitCommand(ByVal intCommand As Integer, ByVal intPar1 As Integer, ByVal intPar2 As Integer, ByVal intPar3 As Integer) As Boolean
        Try
            If gstructSettings.AppMode = EnumAppMode.DemoMode Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                Return True
            Else

                Return mobjCommdll.gFuncTransmitCommand(intCommand, intPar1, intPar2, intPar3)
            End If

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

    Private Function FuncReceiveData(ByRef BytArray() As Byte, ByVal lngTimeOut As Long) As Boolean
        Try
            If gstructSettings.AppMode = EnumAppMode.DemoMode Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                '---todo send random data code here
                'If (flag) Then
                '  flag1=TRUE;
                'flag1=TRUE;
                '  Command = Block[1];
                '  Param1 = 1;
                '  Param2 = random(256);
                '  Param3 = random(256);
                '  Block[0]='2'; 		// Start of Block
                '  Block[1]=command;
                '  Block[2]=para1;
                '  Block[3]=para2;
                '  Block[4]=para3;
                '  Block[5]=0;			/* Checksum	    */
                '  Block[6]=' ';		/* Blank Spcae 	*/
                '  Block[7]='4';		/* End of Block */
                '  Block[8]='\0';
                BytArray(0) = &H32
                BytArray(1) = &H1
                BytArray(2) = CByte(bytRandom.Next(256))
                BytArray(3) = CByte(bytRandom.Next(256))
                BytArray(4) = CByte(bytRandom.Next(256))
                BytArray(5) = 1
                BytArray(6) = &H20
                BytArray(7) = &H34
                Return True
            Else

                Return mobjCommdll.gFuncReceiveData(BytArray, lngTimeOut)
            End If

        Catch threadex As Threading.ThreadAbortException

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

    Private Function FuncTransmitCommand2(ByVal intCommand As Integer) As Boolean
        Try
            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                Return True
            Else
                'Return mobjCommdllAutoSampler.gFuncTransmitByte2(intCommand)
                Return mobjCommdllAutoSampler.gFuncTransmitByte2(intCommand)
            End If

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

    Private Function FuncReceiveData2(ByRef BytArray As Byte, ByVal lngTimeOut As Long) As Boolean
        Try
            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                '---todo send random data code here
                'If (flag) Then
                '  flag1=TRUE;
                'flag1=TRUE;
                '  Command = Block[1];
                '  Param1 = 1;
                '  Param2 = random(256);
                '  Param3 = random(256);
                '  Block[0]='2'; 		// Start of Block
                '  Block[1]=command;
                '  Block[2]=para1;
                '  Block[3]=para2;
                '  Block[4]=para3;
                '  Block[5]=0;			/* Checksum	    */
                '  Block[6]=' ';		/* Blank Spcae 	*/
                '  Block[7]='4';		/* End of Block */
                '  Block[8]='\0';
                'BytArray(0) = &H32
                'BytArray(1) = &H1
                'BytArray(2) = CByte(bytRandom.Next(256))
                'BytArray(3) = CByte(bytRandom.Next(256))
                'BytArray(4) = CByte(bytRandom.Next(256))
                'BytArray(5) = 1
                'BytArray(6) = &H20
                'BytArray(7) = &H34
                BytArray = &H34
                Return True
            Else
                Return mobjCommdllAutoSampler.gFuncReceiveByte2(BytArray, lngTimeOut)
                'Return mobjCommdll.gFuncReceiveData(BytArray, lngTimeOut)
            End If

        Catch threadex As Threading.ThreadAbortException

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

#Region " Public Functions "

    Public Function funcInitInstrument() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :   gFuncInitInstrument
        'Description	    :   to open the COM port and to go though initialization routines 
        'Parameters 	    :   None 
        'Return             :   Bool. if true success
        'Time/Date  	    :   10.51 31/10/03
        'Dependencies	    :   
        'Author		        :   Mandar
        'Revision		    :   name changed from gFuncInitUV2600 to gFuncInitInstrument
        'Revision by Person	:   Rahul B. 25/9/06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        funcInitInstrument = False
        Dim intCount As Int16
        Dim lngtime1 As Long
        Dim lngtime2 As Long
        'Dim intInstrument_Type As Integer

        Dim frmCommPorts_Selection As New frmCommPorts_Selection
        Dim blnFlag As Boolean = False

        Try

            'to open the COM port and to go though initialization routines
            Call mobjCommdll.gFuncOpenCommPort(gintCommPortSelected, False)

            If gblnTestAutoSampler = True Then
                If Not gintCommPortSelectedForAutoSampler = 0 Then
                    'mobjCommdllAutoSampler.gFuncOpenCommPort2(gintCommPortSelectedForAutoSampler, 9600, 0, 1, 8) ''comment by Pankaj for autosampler on 10Sep 07
                End If
            End If

            If mobjCommdll.gFuncIsPortOpen() Then
                funcInitInstrument = True
            Else
                funcInitInstrument = False
                Call gobjMessageAdapter.ShowMessage(constComPortBusy)
                Application.DoEvents()
                'lngtime1 = System.DateTime.Now.Ticks / 10000

                Do While (True)
                    frmCommPorts_Selection.ShowDialog() '--- there is no com port available so select one from this 
                    Application.DoEvents()

                    ' if comm port selection is cancelled
                    If gintCommPortSelected = 0 Then
                        funcInitInstrument = False
                        Exit Function  '-- -End the Communication loop
                    End If

                    If mobjCommdll.gFuncIsPortOpen() Then
                        funcInitInstrument = True
                        Exit Do '-- -End the Communication loop
                    Else
                        funcInitInstrument = False
                    End If

                Loop
                'frmCommPorts_Selection.Dispose()
                Application.DoEvents()
            End If

AgnComm:
            For intCount = 1 To 2
                '--------check communication with Instrument by sending reset command
                blnFlag = funcResetInstrument()
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                    If blnFlag Then
                        blnFlag = funcResetReferenceBeam()
                    End If
                End If
                If blnFlag Then
                    Exit For
                End If
            Next

            If blnFlag = False Then
                funcInitInstrument = False
                gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft
                gobjMessageAdapter.ShowMessage(constCommError)
                Application.DoEvents()
                'lngtime1 = System.DateTime.Now.Ticks / 10000
                Do While (True)

                    frmCommPorts_Selection.ShowDialog()       '--- there is no com port available so select one from this 
                    Application.DoEvents()
                    If gintCommPortSelected = 0 Then
                        funcInitInstrument = False
                        Exit Function  '-- -End the Communication loop
                    End If

                    If mobjCommdll.gFuncIsPortOpen() Then
                        funcInitInstrument = True
                        GoTo AgnComm
                        ' communicate again with the instrument by sending reset command
                    Else
                        funcInitInstrument = False
                        gobjMessageAdapter.ShowMessage(constComPortBusy)
                    End If

                Loop
                frmCommPorts_Selection.Close()
                frmCommPorts_Selection.Dispose()
                Application.DoEvents()
            End If


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
            If Not (frmCommPorts_Selection Is Nothing) Then
                frmCommPorts_Selection.Dispose()
            End If
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncTurret_Home() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncTurret_Home,this also acts as Sample_Turret_Home
        'Description            :   To make the Turret indicater home        
        'Parameters             :   None
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 24.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim blnflag As Boolean = False
        '====================================================================================
        '        BOOL	S4FUNC Find_Turret_Home(HWND hwnd)
        '{
        'BOOL	flag=FALSE;
        'unsigned  oldTout;

        ' if (GetInstrument()==AA202)
        '	return TRUE;

        ' oldTout=Tout;
        ' Tout=LONG_DEALY;
        ' hold = Load_Curs();
        ' Transmit(TARHOME, 0,0 , 0);
        '            If (Recev(True)) Then
        '	 flag=(BOOL)Param1;
        ' SetCursor(hold);
        ' Tout=oldTout;
        ' if (flag) {
        '	Inst.Lamp_old = Inst.Lamp_pos = 0;
        '	flag =Position_Turret(hwnd,1, TRUE);
        '  }
        ' else {
        '	 Gerror_message(" Turret controller error \n Check Turret connections");
        '	 Inst.Lamp_old = -1;
        '	}
        ' return flag;
        '}
        '====================================================================================
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Set Turret home position TURHOME(5)
            If FuncTransmitCommand(EnumAAS203Protocol.TURHOME, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    '1.	If Receive True then turret postion to 1
                    If bytArray(1) <> 1 Then
                        gobjInst.Lamp_Old = -1
                        gFuncTurret_Home = False
                        'gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome)
                        gobjMessageAdapter.ShowMessage(constTurretPositionError)
                        Application.DoEvents()
                    Else
                        blnflag = bytArray(2) 'true '04.12.07 Deepak
                    End If
                Else
                    gFuncTurret_Home = False
                    gobjInst.Lamp_Old = -1
                    gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome)
                    Application.DoEvents()
                End If
            Else
                gFuncTurret_Home = False
                gobjInst.Lamp_Old = -1
                gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome)
                Application.DoEvents()
            End If
            gblnInComm = False
            If blnflag = True Then
                gobjInst.Lamp_Old = 0
                gobjInst.Lamp_Position = 0
                ' Set Turent position to the 1 lamp position
                blnflag = gFuncTurret_Position(1, True)
            Else
                'Saurabh 25-MAY-2007
                gobjMessageAdapter.ShowMessage(constTurretPositionError)
                'Saurabh
                gobjInst.Lamp_Old = -1
            End If

            Return blnflag

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncTurret_Position(ByVal intEndPosition As Int16, Optional ByVal blnShowTurretElement As Boolean = False) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncTurret_Position
        'Description            :   To position the Turret at said position from current position        
        'Parameters             :   End Position is the integer parameter to set the new position
        '                           BlnShowTurretyElement is the boolean parameter when true shows turret position sttus window.
        'Return                 : BOol. True if success
        'Time/Date              :   26/9/06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   Sachin Dokhale on 04.03.07
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor

        Dim bytArray(7) As Byte
        Dim intCounter As Integer = 0
        Dim intStartPosition As Integer
        Dim blnFlag As Boolean = True
        Dim intDemoPosition As Integer
        '--------------------------------------------
        '        BOOL	S4FUNC Position_Turret(HWND hwnd, int end, BOOL first)
        '{
        'int 	i,start;
        'BOOL 	flag = TRUE;
        'char tmsg[100]="";
        ' if (GetInstrument()==AA202){
        '	if(firstdisp){
        '		Inst.Lamp_pos = end;
        '		Inst.Lamp_old =Inst.Lamp_pos;
        '		sprintf(tmsg," Insert / Confirm %s Lamp# %d In Mesurement Hoder ",Inst.Lamp_par.lamp[Inst.Lamp_pos-1].elname, end);//--mdf by sk on 22/1/2002
        '		MessageBox(hwnd,tmsg,"Lamp Placement",MB_OK);
        '	}
        '	firstdisp = 1;
        '	return TRUE;
        ' }
        ' hold = Load_Curs();

        ' start=Inst.Lamp_pos;

        ' if (start>=0 && start <=6 && end >=1 && end<=6 && start!=end) {  //1
        '	Inst.Tpos = 0;
        '	Transmit (TARPOS, (BYTE) start,(BYTE) end , 0);
        '	if (start >end) {i=start; start = end; end = i; }
        '	for (i=start+1; i<=end; i++){  //2
        '		if (Recev(TRUE)){ //3
        '		  Beep();
        '		  Inst.Lamp_pos = Param1;;
        '#If DEMO Then
        '		  Inst.Lamp_pos = i;
        '#End If
        '		  if(first){ //4
        '                                    If (OnShowTurretElement) Then
        '			  (*OnShowTurretElement) (NULL); //	 ShowTurretElement(NULL);
        '			 } //4
        '		 } //3
        '		else { //5
        '		  Gerror_message(" Error While positioning Turret \n Check Turret connections");
        '		  flag = FALSE;
        '		  break;
        '		 } //5
        '	} //2

        ' if (flag && Inst.Lamp_pos>0 && Inst.Lamp_pos<6) { //6
        '	Inst.Lamp_old =Inst.Lamp_pos;
        '	if (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos >0 &&
        '		 Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos <=100){ //7
        '		 for (i=1; i<=RANGEH+10; i++){ //8
        '			Rotate_Anticlock_Tur();
        '			pc_delay(250);
        '		  } //8
        '		 for (i=1; i <= (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos)+10; i++){ //9
        '			Rotate_Clock_Tur();
        '			pc_delay(250);
        '		  } //9
        '		 } //7
        '  } //6
        ' } //1

        ' SetCursor(hold);
        ' return flag;
        '}
        '--------------------------------------------
        Try
            intDemoPosition = intEndPosition  '---16.03.08
            ' gblnInComm = True          '10.12.07

            '//----- Added by Sachin Dokhale for AA 201 on 04.03.07
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                If mintFirstDisp Then
                    gobjInst.Lamp_Position = intEndPosition
                    gobjInst.Lamp_Old = gobjInst.Lamp_Position
                    Call gobjMessageAdapter.ShowMessage("Insert / Confirm " & gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName & " Lamp# " & gobjInst.Lamp_Position & " In Measurement Holder.", "Lamp Placement", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                    Call Application.DoEvents()
                End If
                mintFirstDisp = 1
                Return True
                Exit Function
            End If
            '//-----

            ' start=Inst.Lamp_pos;

            ' if (start>=0 && start <=6 && end >=1 && end<=6 && start!=end) {  //1
            '	Inst.Tpos = 0;
            '	Transmit (TARPOS, (BYTE) start,(BYTE) end , 0);
            '	if (start >end) {i=start; start = end; end = i; }

            intStartPosition = gobjInst.Lamp_Position

            'Validate lamp current Inst.Lamp_Position & end position within limits of 0 to 6.
            If (intStartPosition >= 0 And intStartPosition <= 6 And intEndPosition >= 1 And intEndPosition <= 6 And intStartPosition <> intEndPosition) Then
                'init Set Turret Position of Inst struct to 0
                gobjInst.TurretPosition = 0

                '---03.12.07  Deepak
                '---On element change reference pmt should be zero (for double beam instrument).
                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                    With gobjInst.Lamp.LampParametersCollection
                        If gobjInst.Lamp_Position > 0 And intEndPosition <= 6 Then
                            If LCase(.item(gobjInst.Lamp_Position - 1).ElementName) <> LCase(.item(intEndPosition - 1).ElementName) Then
                                gobjInst.PmtVoltageReference = 0.0
                            End If
                        End If
                    End With
                End If
                Dim blnIsReceiveBloc As Boolean = False
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                ' Transmit the Command to instrument 
                'EnumTURPOS (6); StartPosition; EndPosition.
                If FuncTransmitCommand(EnumAAS203Protocol.TURPOS, CByte(intStartPosition), CByte(intEndPosition), 0) Then
                    'Check StartPosition is greater the End position then interchange value of each
                    If intStartPosition > intEndPosition Then
                        intCounter = intStartPosition
                        intStartPosition = intEndPosition
                        intEndPosition = intCounter
                    End If
                    'clsRS232Main.gblnInCommProcess = False

                    '	for (i=start+1; i<=end; i++){  //2
                    '		if (Recev(TRUE)){ //3
                    '		  Beep();
                    '		  Inst.Lamp_pos = Param1;;
                    '#If DEMO Then
                    '		  Inst.Lamp_pos = i;
                    '#End If
                    '		  if(first){ //4
                    '                                    If (OnShowTurretElement) Then
                    '			  (*OnShowTurretElement) (NULL); //	 ShowTurretElement(NULL);
                    '			 } //4
                    '		 } //3
                    '		else { //5
                    '		  Gerror_message(" Error While positioning Turret \n Check Turret connections");
                    '		  flag = FALSE;
                    '		  break;
                    '		 } //5
                    '	} //2
                    ' Increment positoon by one from start position +1 to end position
                    For intCounter = intStartPosition + 1 To intEndPosition
                        ' Receive Byte Array  
                        If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                            'Receive Byte Array(1) is not one the it has some error in Comm. and exit from function
                            If bytArray(1) <> 1 Then
                                gobjMessageAdapter.ShowMessage(constErrorPosnTurret)
                                Application.DoEvents()
                                blnFlag = False
                                Exit For
                            Else
                                'Receive Byte Array(1) is one then
                                'lamp position is getting from byte array (2) 
                                gobjInst.Lamp_Position = CInt(bytArray(2))

                                ' if it is demo mode then simply set the lamp position with for loop counter
                                'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                                If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                    (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                    'gobjInst.Lamp_Position = intCounter
                                    gobjInst.Lamp_Position = intDemoPosition '---16.03.08
                                End If
                                ' follow the process for to show the turret position on frmStatus window 
                                If blnShowTurretElement = True Then
                                    If Not gobjfrmStatus Is Nothing Then
                                        gobjfrmStatus.TurretNumber = gobjInst.Lamp_Position
                                        If gobjInst.Lamp_Position >= 1 Then
                                            gobjfrmStatus.ElementName = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName
                                        End If
                                        gobjfrmStatus.Refresh()
                                    End If
                                    gobjfrmStatus.Show()
                                    Application.DoEvents()
                                End If
                            End If
                        Else
                            'Error when Receive byte arry function has return false 
                            gobjMessageAdapter.ShowMessage(constErrorPosnTurret)
                            Application.DoEvents()
                            blnFlag = False
                        End If
                        blnIsReceiveBloc = True
                    Next intCounter

                    If blnIsReceiveBloc = False Then
                        clsRS232Main.gblnInCommProcess = False
                    End If
                    gblnInComm = False

                    ' if (flag && Inst.Lamp_pos>0 && Inst.Lamp_pos<6) { //6
                    '	Inst.Lamp_old =Inst.Lamp_pos;
                    '	if (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos >0 &&
                    '		 Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos <=100){ //7
                    '		 for (i=1; i<=RANGEH+10; i++){ //8
                    '			Rotate_Anticlock_Tur();
                    '			pc_delay(250);
                    '		  } //8
                    '		 for (i=1; i <= (Inst.Lamp_par.lamp[Inst.Lamp_pos-1].lamp_optpos)+10; i++){ //9
                    '			Rotate_Clock_Tur();
                    '			pc_delay(250);
                    '		  } //9
                    '		 } //7
                    '  } //6
                    ' } //1

                    'MessageBox.Show("LampPosition  " + gobjInst.Lamp_Position.ToString)  '21.04.08
                    'MessageBox.Show("OptPos  " + gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition.ToString)  '21.04.08

                    'Set the optimised position of Selected turret lamp position 
                    If blnFlag = True And gobjInst.Lamp_Position > 0 And gobjInst.Lamp_Position < 6 Then
                        gobjInst.Lamp_Old = gobjInst.Lamp_Position
                        ''gobjInst.Lamp.LampParametersCollection' in this object its stored for each turret lamp position into steps 
                        If gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition > 0 And _
                        gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition <= 100 Then
                            For intCounter = 1 To RANGEH + 10
                                funcRotate_Anticlock_Tur()
                                'MessageBox.Show("TPos  " + gobjInst.TurretPosition.ToString)  '21.04.08
                                'MessageBox.Show("TPos  " + gobjInst.TurretPosition.ToString)  '21.04.08
                                objWait = New CWaitCursor
                                mobjCommdll.subTime_Delay(5)
                            Next
                            For intCounter = 1 To gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition + 10
                                funcRotate_Clock_Tur()
                                'MessageBox.Show("TPos  " + gobjInst.TurretPosition.ToString)   '21.04.08
                                objWait = New CWaitCursor
                                mobjCommdll.subTime_Delay(5)
                            Next
                        End If
                    End If
                Else
                    blnFlag = False
                    'gobjMessageAdapter.ShowMessage(constErrorPosnTurret)
                    'Application.DoEvents()
                    Return False
                End If
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcRotate_Steps_Tur_Clock(ByVal intSteps As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcRotate_Steps_Tur_Clock
        'Description            :   To Rotate turret clockwise by given steps        
        'Parameters             :   intSteps : turret to be rotate by this num 
        ' Retrutn               :   Bool True if success
        'Time/Date              :   28/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B on 26.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If

            gFunclongtobyte(intSteps, bytLow, bytHigh)
            'bytLow = intSteps And &HFF
            'bytHigh = CByte(intSteps >> 8)

            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send Command EnumTURROTSTEPCLK (58), with high byte and low byte of steps 
            If FuncTransmitCommand(EnumAAS203Protocol.TURROTSTEPCLK, bytHigh, bytLow, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcRotate_Steps_Tur_Clock = False
                        gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                        Application.DoEvents()
                    Else
                        'if  receive byte is one then decrease the turret position by that steps 
                        'gobjInst.TurretPosition -= intSteps
                        gobjInst.TurretPosition = gobjInst.TurretPosition - intSteps
                        'MessageBox.Show(gobjInst.TurretPosition.ToString)
                        funcRotate_Steps_Tur_Clock = True
                    End If

                Else
                    funcRotate_Steps_Tur_Clock = False
                    gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                    Application.DoEvents()
                End If
            Else
                funcRotate_Steps_Tur_Clock = False
                'gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcRotate_Steps_Tur_AntiClock(ByVal intSteps As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcRotate_Steps_Tur_AntiClock
        'Description            :   To Rotate turret anticlockwise by given steps        
        'Parameters             :   intSteps : turret to be rotate by this num 
        ' Retrutn               :   Bool True if success
        'Time/Date              :   10.02.08
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        '        void  S4FUNC Rotate_Steps_Tur_AntiClock(int steps)
        '{
        'unsigned  oldTout;

        ' if (GetInstrument()==AA202)
        '	return ;

        ' oldTout=Tout;
        ' Tout=LONG_DEALY;
        ' hold = Load_Curs();

        ' Transmit(TURROTSTEPANTI, (BYTE) (steps>>8), (BYTE) (steps), 0);
        ' Recev(TRUE); 
        ' Inst.Tpos+=steps;
        ' SetCursor(hold);
        ' Tout=oldTout;
        '}
        '--------------------------------------------------------------------------------------

        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte

        Try

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If

            gFunclongtobyte(intSteps, bytLow, bytHigh)

            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If

            If FuncTransmitCommand(EnumAAS203Protocol.TURROTSTEPANTI, bytHigh, bytLow, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcRotate_Steps_Tur_AntiClock = False
                        'gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                        'Application.DoEvents()
                    Else
                        'if  receive byte is one then decrease the turret position by that steps 
                        gobjInst.TurretPosition = gobjInst.TurretPosition + intSteps
                        funcRotate_Steps_Tur_AntiClock = True
                    End If
                Else
                    funcRotate_Steps_Tur_AntiClock = False
                    gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                    Application.DoEvents()
                End If
            Else
                funcRotate_Steps_Tur_AntiClock = False
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcRotate_Anticlock_Tur() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcRotate_Anticlock_Tur
        'Description            :   To Rotate turret Anticlockwise. Here turret rotates by only one step        
        'Parameters             :   None
        ' Return                :   Bool, True if success
        'Time/Date              :   28/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 16.11.06 minor changes
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send Command EnumTARHANTI (16), with 0 parameter
            If FuncTransmitCommand(EnumAAS203Protocol.TARHANTI, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constRotateAntiTurClkError)
                        Application.DoEvents()
                        Return False
                    Else
                        'if  receive byte is one then increase the turret position by one steps 
                        gobjInst.TurretPosition = gobjInst.TurretPosition + 1
                        'MessageBox.Show(gobjInst.TurretPosition.ToString)
                        Return True
                    End If
                Else
                    gobjMessageAdapter.ShowMessage(constRotateAntiTurClkError)
                    Application.DoEvents()
                    Return False
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constRotateAntiTurClkError)
                'Application.DoEvents()
                Return False
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcRotate_Clock_Tur() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcRotate_Clock_Tur
        'Description            :   To Rotate turret clockwise. Here turret rotates by only one step        
        'Parameters             :   None
        ' Return                :   Bool, True if success
        'Time/Date              :   28/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   deepak B. on 16.11.06 minor changes
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send Command EnumTARHCLK (17), with 0 parameter
            If FuncTransmitCommand(EnumAAS203Protocol.TARHCLK, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constRotateTurClkError)
                        Application.DoEvents()
                        funcRotate_Clock_Tur = False
                    Else
                        'if  receive byte is one then decrease the turret position by one steps 
                        gobjInst.TurretPosition = gobjInst.TurretPosition - 1
                        'MessageBox.Show(gobjInst.TurretPosition.ToString)
                        Return True
                    End If
                Else
                    gobjMessageAdapter.ShowMessage(constRotateTurClkError)
                    Application.DoEvents()
                    funcRotate_Clock_Tur = False
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constRotateTurClkError)
                'Application.DoEvents()
                funcRotate_Clock_Tur = False
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcOptimise_Turret_Position(ByVal dblLampCurrent As Double, ByVal intLampPos As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcOptimise_Turret_Position
        'Description            :   To optimise Turret position 
        'Parameters             :   dblLampCurrent = current to be set to lamp
        '                           intLampPos = lamp position to which current to be set
        'Return                 :   True if success
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 18.11.06 major modifications
        'Revision by Person     :   Mangesh S. on 11-Apr-2007 major modifications for AA201
        '--------------------------------------------------------------------------------------
        'void	S4FUNC 	Optimize_Turret_Position( HWND hpar, BOOL aLamps)
        '{
        '   if( GetInstrument() == AA202 )
        '       if (Inst->Lamp_par.wvzero==100.0 || aLamps)
        '       {
        '	        if(Inst->Lamp_par.lamp[0].lamp_optpos==0)
        '		        pos=0;
        '           Else
        '		        pos=1;
        '	        Optimize_Zero_order_AA202(hpar,pos);
        '	        Save_Tuttet_Status();
        '       }
        '	    return;
        '   else {
        '       if (Inst->Lamp_par.wvzero==100.0 || aLamps) {
        '		    Optimize_Zero_order(hpar);
        '		    Save_Tuttet_Status();
        '	    }
        '       Else
        '	        Turret_Optimise(hpar);
        '   }
        '}
        '---------------------------------
        Dim objWait As New CWaitCursor

        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                '***************************************************************
                '----Added by Mangesh on 11-Apr-2007 for AA201 changes
                '***************************************************************
                Dim intLampPosition As Integer = 0
                If (gobjInst.Lamp.WavelengthZero = 100.0 Or funcIsAllLampEmpty()) Then
                    'commented by Deepak on 01.09.09
                    'If (gobjInst.Lamp.LampParametersCollection.item(0).LampOptimizePosition = 0) Then
                    '    intLampPosition = 0
                    'Else
                    '    intLampPosition = 1
                    'End If
                    '''''''''''''''''''''

                    'written by Deepak on 01.09.09
                    If Not (Trim(gobjInst.Lamp.LampParametersCollection.item(0).ElementName) = "") Then
                        intLampPosition = 1
                    ElseIf Not (Trim(gobjInst.Lamp.LampParametersCollection.item(1).ElementName) = "") Then
                        intLampPosition = 2
                    Else
                        intLampPosition = 0
                    End If
                    ''''''''''''''''''''''

                    Dim objfrmZeroOrder201 As frmZeroOrder_201
                    objfrmZeroOrder201 = New frmZeroOrder_201
                    objfrmZeroOrder201.StartPosition = FormStartPosition.CenterScreen
                    objfrmZeroOrder201.Location = New Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY)
                    objfrmZeroOrder201.StartOptimizeTread(intLampPosition)
                    If objfrmZeroOrder201.ShowDialog() = DialogResult.OK Then
                        If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                            Call funcSaveInstStatus()
                        End If
                        objfrmZeroOrder201.Close()
                        objfrmZeroOrder201.Dispose()
                        objfrmZeroOrder201 = Nothing
                    End If
                End If
                '***************************************************************
                Return True
            End If
            'optimise the turret for 203
            If gobjInst.Lamp.WavelengthZero = 100 Or funcIsAllLampEmpty() = True Then
                Dim mobjfrmZeroOrder As frmZeroOrder
                mobjfrmZeroOrder = New frmZeroOrder
                mobjfrmZeroOrder.StartPosition = FormStartPosition.Manual
                mobjfrmZeroOrder.Location = New Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY)
                mobjfrmZeroOrder.StartOptimizeTread()
                If mobjfrmZeroOrder.ShowDialog() = DialogResult.OK Then
                    If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                        funcSaveInstStatus()
                    End If
                    mobjfrmZeroOrder.Close()
                    mobjfrmZeroOrder.Dispose()
                End If
            Else
                Dim mobjfrmturretOptimisation As frmTurretOptimisation
                mobjfrmturretOptimisation = New frmTurretOptimisation(dblLampCurrent, intLampPos)
                mobjfrmturretOptimisation.StartOptimizeTread()
                If mobjfrmturretOptimisation.ShowDialog() = DialogResult.OK Then
                    mobjfrmturretOptimisation.Close()
                    mobjfrmturretOptimisation.Dispose()
                End If
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcTur_Pre_Opt(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing) As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcTur_Pre_Opt
        'Description            :   To optimise Turret 
        'Parameters             :   lblStatus1 as form Object, lblStatus2 as form Object,
        '                           lblStatus3 as form Object
        'Return                 :   integer position of turret.
        ' Affected parameter    :   show status on lblStatus3 and lblStatus2
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 major modifications
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim chNew As Integer
        Dim max_int As Integer
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '        int  Tur_pre_opt(HWND hwnd)
        '{
        'int 	i;
        'int 	in_pos,  max_int, chnew;
        'char 	line1[80]="";

        '  Set_PMT((double)150.0);
        '  Adj_pmt_NearZeroWv(hwnd);
        '  Show_Pmt(hwnd, Inst->Pmtv);
        '  for (i=1; i<=RANGEH+10; i++){
        '	  Rotate_Anticlock_Tur();
        '	 }
        '  for (i=1; i<=10; i++)  {
        '	 Rotate_Clock_Tur();  
        '	}
        '  in_pos = 1;  max_int = 0;
        '  for (i=1; i<=RANGE; i++)  {
        '	 Rotate_Clock_Tur();
        '	 chnew = ReadADCFilter();
        '	 if (chnew > max_int && i!=1){
        '		max_int = chnew;
        '		in_pos =i;
        '	 }
        '	sprintf(line1," Turpos : %d  Aprox.Peak %d  Energy %5.0f mV ", i, in_pos, GetmV(chnew));
        '	SetText(hwnd, IDC_STATUS1, line1);
        '  }
        '  for (i=1; i <= RANGE+10; i++) {
        '	 Rotate_Anticlock_Tur();
        '	}
        '  for (i=1; i <= in_pos+10; i++){
        '	 Rotate_Clock_Tur();
        '	}
        '  SetText(hwnd, IDC_STATUS1, "");
        ' return in_pos;
        '}
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim int_pos As Integer

        Try


            funcTur_Pre_Opt = False

            '1.	Set PMT voltage 150.0.

            Call funcSet_PMT(150.0)

            funcAdj_Pmt_NearZeroWV(lblStatus1, lblStatus2, lblStatus3)

            If Not lblStatus1 Is Nothing Then
                CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & gobjInst.PmtVoltage
            End If

            '3.	Rotate turret anticlockwise 50 (RangeH) +10 times(i.e. 60 times).

            For intCounter = 1 To RANGEH + 10
                Call funcRotate_Anticlock_Tur()
            Next intCounter

            '4.	Rotate turret clockwise 10 times.

            For intCounter = 1 To 10
                Call funcRotate_Clock_Tur()
            Next

            int_pos = 1
            max_int = 0
            For intCounter = 1 To WVRANGE
                '6.	Rotate turret clockwise.
                funcRotate_Clock_Tur()
                '7.	Read ADC filter.
                funcReadADCFilter(gobjInst.Average, chNew)
                '8.	Memorize highest ADC filter reading throughout 100 steps.
                '9.	Memorize counter number for highest ADC filter reading.
                If ((chNew > max_int) And (intCounter <> 1)) Then
                    max_int = chNew
                    int_pos = intCounter
                End If
                If Not lblStatus2 Is Nothing Then
                    CType(lblStatus2, Windows.Forms.Label).Text = "Turpos : " & Format(intCounter, "000") & "  Aprox.Peak " & Format(int_pos, "000") & "  Energy " & Format(gFuncGetmv(chNew), "#0.00") & " mV "
                End If
            Next intCounter

            '10.	Rotate Turret anticlockwise 100 (WVRange) + 10 times.
            For intCounter = 1 To WVRANGE + 10
                funcRotate_Anticlock_Tur()
            Next

            '11.	Rotate turret clockwise for (counter number for 
            'highest ADC filter reading + 10 ) times.

            For intCounter = 1 To int_pos + 10
                funcRotate_Clock_Tur()
            Next

            CType(lblStatus2, Windows.Forms.Label).Text = ""

            '12.	Return counter number for highest ADC 
            'filter reading to calling routine.

            Return int_pos
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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcTurret_Optimise(ByVal dblLampCurrent As Double, ByVal intLampPos As Integer, Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing, Optional ByRef ObjGraph As Object = Nothing, Optional ByVal ObjThreadController As Object = Nothing, Optional ByRef lblWvStatus As Label = Nothing) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcThreadTurret_Optimise
        'Description            :   To optimise Turret position 
        'Parameters             :   dblLampCurrent,intLampPos
        'Return                 :   
        'Affected parameter     :   lblStatus1, lblStatus2,lblStatus3, ObjGraph, lblWvStatus
        'Time/Date              :   8/11/06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Optimise Turret Steps:
        '1. Set Air Off
        '2. Find wv home
        '3. Turret Home
        '4. Position Turret to selected Turret No.
        '5. Set All Lamp Off
        '6. Set Current to HCL lamp selected.
        '7. Test if Lamp present then optimise turret
        '8. Set Air ON
        Dim objWait As New CWaitCursor
        Dim i, pos As Integer
        Dim strMsg As String
        Dim dbllmp_current As Double = 0.0
        Dim intlmp_position As Integer
        Dim k As Integer
        Dim intK As Integer = 0

        '--------------------
        '        void 		S4FUNC 	Turret_Optimise(HWND hpar)
        '{
        'HWND	hwnd=NULL;
        'double	lmp_cur=0.0;
        'HDC	hdc;
        'char line1[80]="";
        'char line7[80]="";
        'int  i, pos;

        '#ifndef FINAL
        '  Get_Instrument_Parameters(&Inst);
        '#End If
        ' Inst =  GetInstData();

        ' for (i=0; i<6; i++)
        ' {
        '  if (Inst->Lamp_par.lamp[i].lamp_optpos != 0) continue;
        '  else break;
        ' }

        '  if (i<6)  {
        '  if(GetInstrument() != AA202 )
        '	  AIR_OFF();
        '  hwnd= CreateWindowPeak(hpar, " TURRET OPTIMISATION","SKCK1",0 );
        '  if (hwnd){  // hwnd start
        '	hdc= GetDC(hwnd);
        '	SetBkColor(hdc, RGB(192, 192, 192));
        '	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
        '	if(Find_Wavelength_Home(hdc, 5, 150)){ // wavelength start
        '	  ShowTurretElement(hwnd);
        '	  for (pos = i+1; pos<=6; pos++){ //loop start
        '		 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
        '		 continue;
        '		 if ( Inst->Lamp_par.lamp[pos-1].lamp_optpos != 0) continue;
        '		 if(Inst->Lamp_old!=pos){
        '			 sprintf(line1, " Setting Lamp from %d to %d position.     ",Inst->Lamp_old, pos);
        '			 SetText(hwnd, IDC_STATUS1,line1);
        '                                                If (!Position_Turret(hpar, pos, True)) Then
        '				 break;
        '			 SetText(hwnd, IDC_STATUS1,"");
        '		 }
        '		All_Lamp_Off();
        '		lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
        '		Set_HCL_Cur(lmp_cur,Inst->Lamp_pos);
        '		if (Inst->Cur==(double) 0.0){
        '			Inst->Cur=lmp_cur;
        '		  }
        '          If (Test_Lamp_Presence(hwnd)) Then
        '			Tur_Opt(hwnd, hdc);
        '	  } // for loop end
        '	} // wavelength end
        '	ReleaseDC(hwnd, hdc);
        '	DestroyWindowPeak(hwnd,hpar);
        '  } // hwnd end
        '  if(GetInstrument() != AA202 )
        '	  AIR_ON();
        ' } // if already optimised
        ' Save_Tuttet_Status();

        '}
        '//-------------------------------------

        '--------------------
        'System.Threading.Monitor.Enter(ObjThreadController)
        Try
            'Added by pankaj on 21 Jan 08
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                funcSet_PMTReferenceBeam(0)
            End If
            '---for setting ref. pmt to zero

            If Not lblStatus3 Is Nothing Then
                CType(lblStatus3, Windows.Forms.Label).Text = "Initialising Please Wait  ......."
            End If

            '            For i = 0 To 5
            '                If gobjInst.Lamp.LampParametersCollection.item(i).LampOptimizePosition <> 0 Then
            '                    GoTo EndOfLoop
            '                Else
            '                    Exit For
            '                End If
            'EndOfLoop:  Next

            For i = 0 To 5
                If gobjInst.Lamp.LampParametersCollection.item(i).LampOptimizePosition = 0 Then
                    Exit For
                End If
            Next

            If i < 6 Then
                '1.	Check instrument type. If instrument type is not 201 then make air off.
                If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                    funcAir_OFF()
                End If

                If Not lblStatus3 Is Nothing Then
                    CType(lblStatus3, Windows.Forms.Label).Text = "Initialising Please Wait  ......."
                End If

                'Saurabh 06-06-2007
                'if funcFind_Wavelength_Home() then
                '2.	Set Wavelength to Home position.
                If gFuncWavelength_Home(lblWvStatus) Then
                    'Saurabh 06-06-2007
                    '+++++ToDo later
                    'ShowTurretElement(hwnd);
                    '+++++ToDo
                    For pos = i + 1 To 6
                        'If gobjInst.Lamp.LampParametersCollection.item(pos - 1).ElementName = "" Then
                        '    GoTo EndOfLoop1
                        'End If
                        If gobjInst.Lamp.LampParametersCollection.item(pos - 1).ElementName <> "" Then
                            'GoTo EndOfLoop1
                            'End If
                            If gobjInst.Lamp.LampParametersCollection.item(pos - 1).LampOptimizePosition = 0 Then
                                'GoTo EndOfLoop1
                                'End If
                                'If gobjInst.Lamp.LampParametersCollection.item(pos - 1).ElementName <> "" Then
                                'If gobjInst.Lamp.LampParametersCollection.item(pos - 1).LampOptimizePosition <> 0 Then
                                'GoTo EndOfLoop1
                                'End If
                                'If gobjInst.Lamp.LampParametersCollection.item(pos - 1).LampOptimizePosition = 0 Then

                                'the following line is changed on 15.05.07
                                '3.	If lamp, which is to be optimized, is not in current turret position then position turret to that location.
                                If gobjInst.Lamp_Old <> pos Then
                                    'If gobjInst.Lamp_Position <> pos Then

                                    If Not lblStatus2 Is Nothing Then
                                        'the following line is changed on 15.05.07
                                        CType(lblStatus2, Windows.Forms.Label).Text = "Setting Lamp from " & gobjInst.Lamp_Old & " to " & pos & " position."
                                        'CType(lblStatus2, Windows.Forms.Label).Text = "Setting Lamp from " & gobjInst.Lamp_Position & " to " & pos & " position."
                                    End If

                                    If gFuncTurret_Position(pos, True) = False Then
                                        '--take lamp current from inst parameters and set it
                                        Exit For
                                    End If
                                    If Not lblStatus2 Is Nothing Then
                                        CType(lblStatus2, Windows.Forms.Label).Text = " "
                                    End If
                                End If

                                '4.	Set all lamps off.
                                funcAll_Lamp_Off()

                                '---21.01.08 deepak
                                '//----- commented by Sachin Dokhale on 24.04.08
                                '//----- It's set wrong current for turret opt.
                                'gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current = dblLampCurrent
                                dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
                                '---21.01.08 deepak

                                intlmp_position = gobjInst.Lamp_Position

                                '5.	Set HCL current to the current turret position.
                                If funcSet_HCL_Cur(dbllmp_current, intlmp_position) = False Then
                                    gobjMessageAdapter.ShowMessage(constSetHCLCurError)
                                    Application.DoEvents()
                                End If

                                objWait = New CWaitCursor

                                If gobjInst.Current = 0.0 Then
                                    '//----- Uncommentd and commented by Sachin Dokhale on 24.04.08
                                    '//----- It sets all lamp current by set pass param. value, due to loop
                                    gobjInst.Current = dbllmp_current
                                    'gobjInst.Current = dblLampCurrent
                                End If

                                If funcTestLampPresence(lblStatus1, lblStatus2, lblStatus3) Then
                                    intK += 1
                                    If funcTur_Opt_New(lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController, intK) Then
                                    Else
                                    End If
                                End If
                            End If
                        End If
                        'EndOfLoop1:         Next
                    Next
                Else
                    'MessageBox.Show("Wavelength Home Error")
                End If 'wavelength home end

                objWait = New CWaitCursor
                '8.	If instrument type is not 201 then Set Air ON.
                If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                    Call funcAir_ON()
                End If
            End If  ' if i<6 condition end
            '9.	Save lamp position status.
            If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then
                funcSaveInstStatus()
            End If

            'Dim intCounter As Integer
            'For intCounter = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
            '    gobjInst.Lamp.LampParametersCollection.item(intCounter).LampOptimizePosition = 0
            'Next

            mobjCommdll.subTime_Delay(1000)

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
            objWait.Dispose()
            Application.DoEvents()
            'System.Threading.Monitor.Exit(ObjThreadController)
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcTur_Opt_New(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing, Optional ByRef ObjGraph As Object = Nothing, Optional ByVal ObjThreadController As Object = Nothing, Optional ByVal intOccurence As Integer = 1) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcTur_Opt_New
        'Description            :   To optimise turret
        'Parameters             :   
        'Affected parameter     :   lblStatus1,lblStatus2, lblStatus3, ObjGraph, ObjThreadController,intOccurence
        ' Return                :   True if success
        'Time/Date              :   17.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim rPOs As Integer
        Dim intCounter As Integer
        Dim chNew As Integer
        Dim max_int As Integer
        Dim in_pos As Integer
        Dim dblEnergy As Double
        Dim strData As String
        '---------------------------------------------------
        '        void	Tur_Opt(HWND hwnd, HDC hdc)
        '{
        'int    chnew, i;
        'int    in_pos, max_int, rpos;
        'char line7[80]="";

        ' SetFocus(hwnd);
        ' if( GetInstrument() == AA202)
        '	 SetText(hwnd, IDC_STATUS, "Lamp Optimization");
        '        Else
        '	 SetText(hwnd, IDC_STATUS, "Turret Optimization");
        ' Cal_Mode(HCLE);
        ' rpos = Tur_pre_opt(hwnd);

        '#If !NEWZERO Then
        '  Adj_PMT_forvalue(hwnd, (double) 3500.0, (double)350);
        '#Else
        '  Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0 ), (double)350.0);
        '#End If
        ' Show_Pmt(hwnd, Inst->Pmtv);
        ' pc_delay (200);
        ' for (i=1; i<=rpos+10; i++)  {
        '	Rotate_Anticlock_Tur();
        '	}
        ' for (i=1; i<=10; i++) {
        '	Rotate_Clock_Tur();
        '  }
        ' if(GetInstrument() == AA202)
        '	 SetWindowText(hwnd,"OPTIMISING LAMP");
        '                    Else
        '	 SetWindowText(hwnd,"OPTIMISING TURRET");
        ' PeakGraph.Xmin= 1; PeakGraph.Xmax= RANGE;
        ' PeakGraph.Ymin= GetEnergy(2047);
        ' PeakGraph.Ymax= GetEnergy(2047.0+409.6*4);
        ' strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"TURRET STEP");
        ' Show_Peak_Param(hwnd, RANGE);
        ' if( GetInstrument() == AA202 )
        '   SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Lamp Position");
        '                        Else
        '	 SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
        ' in_pos = 1;
        ' max_int = 0;
        ' ReadADCFilter();
        ' for (i=1; i<=RANGE; i++) {
        '	Rotate_Clock_Tur();
        '	pc_delay(100);
        '	chnew = ReadADCFilter();
        '	if (chnew > max_int) {
        '	  max_int = chnew;
        '	  in_pos =i;
        '	 }
        '  if (i==1)
        '		GPlotInit(hdc, (double) i, GetEnergy(chnew));
        '                                    Else
        '		GPlot(hdc, (double) i, GetEnergy(chnew));
        ' }
        ' GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);
        ' SetText(hwnd, IDC_STATUS," Positioning Please Wait  .......        ");
        '#If EMU Then
        ' Wait_For_Some_Msg(5);
        '#End If
        ' for (i=1; i <= RANGE+10; i++) 	Rotate_Anticlock_Tur();
        ' for (i=1; i <= 10+in_pos; i++)  {
        '	Rotate_Clock_Tur();	
        '	}
        'Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = in_pos;	
        'for(i=0;i<500; i++)
        ' pc_delay(10000);
        '}

        '---------------------------------------------------
        Dim dblYMin, dblYMax As Double

        Try

            If Not lblStatus3 Is Nothing Then
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    CType(lblStatus3, Windows.Forms.Label).Text = "Lamp Optimization"
                Else
                    CType(lblStatus3, Windows.Forms.Label).Text = "Turret Optimization"
                End If

            End If

            '1.	Set calibration mode to HCLE.

            If funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
                gobjMessageAdapter.ShowMessage(constCalibrationMode)
                Application.DoEvents()
            End If

            rPOs = funcTur_Pre_Opt(lblStatus1, lblStatus2, lblStatus3)

            If funcAdj_Pmt_ForValue(CDbl(70.0), CDbl(350.0), True) = False Then
                gobjMessageAdapter.ShowMessage(constPMTVolt)
                Application.DoEvents()
            End If

            If Not lblStatus1 Is Nothing Then
                CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & Format(gobjInst.PmtVoltage, "###")
                CType(lblStatus1, Windows.Forms.Label).Refresh()
            End If

            objWait = New CWaitCursor

            'mobjCommdll.subTime_Delay(200)
            '4.	Rotate turret anticlockwise (pre optimize turret position + 10) times.
            For intCounter = 1 To rPOs + 10
                funcRotate_Anticlock_Tur()
            Next

            '5.	Rotate turret 10 times clockwise.
            For intCounter = 1 To 10
                funcRotate_Clock_Tur()
            Next

            objWait = New CWaitCursor

            dblYMin = 0 'CInt(FormatNumber(gFuncGetEnergy(2047), 1))
            dblYMax = CInt(FormatNumber(gFuncGetEnergy(2047.0 + 409.6 * 4), 1))

            If Not ObjGraph Is Nothing Then
                CType(ObjGraph, AASGraph).XAxisMin = 0
                CType(ObjGraph, AASGraph).XAxisMax = WVRANGE
                CType(ObjGraph, AASGraph).YAxisMin = dblYMin
                CType(ObjGraph, AASGraph).YAxisMax = dblYMax
                CType(ObjGraph, AASGraph).XAxisLabel = "TURRET STEP"
                CType(ObjGraph, AASGraph).YAxisLabel = "ENERGY"
                CType(ObjGraph, AASGraph).AldysPane.AxisChange()
                CType(ObjGraph, AASGraph).Invalidate()
                CType(ObjGraph, AASGraph).Refresh()
            End If

            If Not lblStatus2 Is Nothing Then
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    CType(lblStatus2, Windows.Forms.Label).Text = "Scanning for Optimal Lamp Position"
                Else
                    CType(lblStatus2, Windows.Forms.Label).Text = "Scanning for Optimal Turret Position"
                End If
            End If

            objWait = New CWaitCursor
            in_pos = 1
            max_int = 0
            '6.	Read ADC filter.
            funcReadADCFilter(gobjInst.Average, chNew)

            '---todo to be checked
            CType(ObjGraph, AAS203.AASGraph).AldysPane.CurveList.Clear()
            CType(ObjGraph, AAS203.AASGraph).AldysPane.AxisChange()
            CType(ObjGraph, AAS203.AASGraph).RemoveHighPeakLineLabel()
            CType(ObjGraph, AAS203.AASGraph).Refresh()
            Application.DoEvents()
            '---todo to be checked

            For intCounter = 1 To WVRANGE
                '8.	Rotate turret clockwise.
                funcRotate_Clock_Tur()
                'mobjCommdll.subTime_Delay(100)
                '9.	Read ADC filter.
                funcReadADCFilter(gobjInst.Average, chNew)

                '12.	During these 100 ADC readings memorize highest 
                'ADC filter reading and counter number of it.

                If chNew > max_int Then
                    max_int = chNew
                    in_pos = intCounter
                End If
                '10.	Convert ADC filter reading to millivolt.
                dblEnergy = gFuncGetEnergy(chNew)
                strData = ""
                strData = intCounter & "," & dblEnergy & "," & intOccurence
                '11.	Plot this energy point on graph.
                If Not ObjThreadController Is Nothing Then
                    CType(ObjThreadController, BgThread.IBgThread).Display(strData)
                End If
                CType(ObjGraph, AASGraph).Refresh()
            Next
            'GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);  todo later

            If Not lblStatus2 Is Nothing Then
                CType(lblStatus2, Windows.Forms.Label).Text = "Positioning Please Wait  .......        "
            End If

            '13.	Rotate turret anticlockwise 110 times.
            For intCounter = 1 To WVRANGE + 10
                funcRotate_Anticlock_Tur()
            Next

            objWait = New CWaitCursor
            '14.    Rotate turret clockwise (highest ADC counter number + 10) times.
            For intCounter = 1 To 10 + in_pos
                funcRotate_Clock_Tur()
            Next

            gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition = in_pos

            If Not lblStatus2 Is Nothing Then
                CType(lblStatus2, Windows.Forms.Label).Text = "Finished. "
            End If

            If Not ObjThreadController Is Nothing Then
                CType(ObjThreadController, BgThread.IBgThread).Completed(False)
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    'Private Function funcOptimise_Zero_Order(Optional ByRef lblStatus1 As Object = Nothing, _
    '                                         Optional ByRef lblStatus2 As Object = Nothing, _
    '                                         Optional ByRef lblStatus3 As Object = Nothing) As Boolean
    '    '-------------------------------------------------------------------------------------------
    '    'Procedure Name         :   funcTurret_Optimise
    '    'Description            :   To optimise Turret position 
    '    'Parameters             :   dblLampCurrent = current to be set to lamp
    '    '                           intLampPos = lamp position to which current to be set
    '    'Time/Date              :   5/10/06
    '    'Dependencies           :   
    '    'Author                 :   Deepak B.
    '    'Revision               :
    '    'Revision by Person     :   Deepak B. on 26.11.06
    '    '-------------------------------------------------------------------------------------------
    '    '-------------------------------------
    '    '        void	S4FUNC 	Optimize_Zero_order(HWND hpar)
    '    '{
    '    ' double   cur=0.0;
    '    ' HWND		hwnd, hwnd1;
    '    ' HDC		hdc, hdc1;
    '    ' BOOL		flag= TRUE, zero = FALSE;
    '    ' char    line1[80]="";
    '    ' int     pos;

    '    '#ifndef FINAL
    '    '  Get_Instrument_Parameters(&Inst);
    '    '#End If

    '    '  MessageBox(hwnd, "Plz select whether you want to skip zero order or not", "AAS203", MB_OK);

    '    ' if (MessageBox(hwnd, "Do you want to perform zero order", "Confirmation", MB_YESNO)==IDYES)
    '    ' {

    '    ' Inst =  GetInstData();
    '    ' if(GetInstrument() != AA202 )
    '    '	 AIR_OFF();
    '    ' hwnd1= CreateWindowPeak(hpar, " TURRET OPTIMISATION","SKCK1",2 );
    '    ' hwnd= CreateWindowPeak(hpar, " ZERO ORDER ","SKCK1",1 );
    '    ' if (hwnd && hwnd1){
    '    '	hdc= GetDC(hwnd);
    '    '	SetBkColor(hdc, RGB(192, 192, 192));
    '    '	hdc1= GetDC(hwnd1);
    '    '	SetBkColor(hdc1, RGB(192, 192, 192));
    '    '	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
    '    '	for (pos = 0; pos<6; pos++)
    '    '	  Inst->Lamp_par.lamp[pos].lamp_optpos=0;
    '    '	Inst->Lamp_par.wvzero = 100.0;
    '    '	if (Find_Turret_Home(hpar)){
    '    '	  if(Find_Wavelength_Home(hdc, 5, 150)){
    '    '		 ShowTurretElement(hwnd);
    '    '		 if (Slit_Home()){
    '    '		  for (pos = 1; pos<=6; pos++){
    '    '			 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
    '    '				continue;
    '    '			 if(Inst->Lamp_old!=pos){
    '    '				strcpy(line1,"");
    '    '				sprintf(line1, " Setting Lamp from %d to %d position. ",Inst->Lamp_old, pos);
    '    '				SetText(hwnd, IDC_STATUS,line1);
    '    '				if (!Position_Turret(hpar, pos,TRUE)){
    '    '					Gerror_message_new("Error in Turret Module ..", "TURRET");
    '    '					break;
    '    '				  }
    '    '			  }
    '    '			 SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......        ");
    '    '//	       disp_el(); disp_data( 5, 1, 65, lamp_pos-1);	  pc_sound(500,1);
    '    '			 All_Lamp_Off();
    '    '			 cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
    '    '			 Set_HCL_Cur(cur,Inst->Lamp_pos);
    '    '			 if (Inst->Cur==(double) 0.0){
    '    '//				Gerror_message_new("cur is  0.0", "Warning");
    '    '				Inst->Cur=cur;
    '    '			  }

    '    '			 flag=Test_Lamp_Presence(hwnd);
    '    '			 if (flag){
    '    '				if (!zero){
    '    '				  InitGraphParam(hwnd);SetFocus(hwnd);
    '    '				  zero = Zero_Order(hwnd, hdc);
    '    '				  if (!zero) {
    '    '					 Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
    '    '					 Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
    '    '					 flag=FALSE;
    '    '					}
    '    '				  InitGraphParam(hwnd1);
    '    '				 }//!zero
    '    '			  if (flag){
    '    '				 SetFocus(hwnd1);
    '    '				 Tur_Opt(hwnd1, hdc1);
    '    '				 }
    '    '			  else break;
    '    '			}//if flag
    '    '		 } //for
    '    '		} //slit home
    '    '	  } // find_mech_zero
    '    '	 } //turret home
    '    '	ReleaseDC(hwnd, hdc);
    '    '	DestroyWindowPeak(hwnd,hpar);
    '    '	ReleaseDC(hwnd1, hdc1);
    '    '	DestroyWindowPeak(hwnd1,hpar);
    '    '  if(GetInstrument() != AA202 )
    '    '	  AIR_ON();
    '    ' }  // if oflag
    '    ' } //messagebox if condition true
    '    '       ReleaseDC(hwnd, hdc);
    '    'DestroyWindowPeak(hwnd,hpar);
    '    ' if(GetInstrument() != AA202 )
    '    ' AIR_ON();
    '    '-------------------------------------
    '    Dim objWait As New CWaitCursor
    '    Dim intCounter As Integer
    '    Dim blnFlag As Boolean
    '    Dim blnZeroOrder As Boolean
    '    Dim intPos As Integer
    '    Dim dbllmp_current As Double
    '    Dim intlmp_position As Integer

    '    Try
    '        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
    '            Call funcAir_OFF()
    '        End If


    '        If Not lblStatus1 Is Nothing Then
    '            CType(lblStatus1, Windows.Forms.Label).Text = "Initialising Please Wait  ......."
    '        End If

    '        For intPos = 0 To 5
    '            gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = 0
    '        Next
    '        gobjInst.Lamp.WavelengthZero = 100.0

    '        If gFuncTurret_Home() Then
    '            If funcFind_Wavelength_Home() Then
    '                '-ShowTurretElement todo for flame
    '                If gFuncSlit_Home() Then
    '                    For intPos = 1 To 6
    '                        If gobjInst.Lamp.LampParametersCollection.item(intPos - 1).ElementName <> "" Then
    '                            If gobjInst.Lamp_Old <> intPos Then
    '                                If Not lblStatus2 Is Nothing Then
    '                                    CType(lblStatus2, Windows.Forms.Label).Text = "Setting Lamp from " & gobjInst.Lamp_Old & " to " & intPos & " position."
    '                                End If
    '                                If gobjCommProtocol.gFuncTurret_Position(intPos, True) = False Then
    '                                    Exit For
    '                                End If
    '                            End If
    '                        End If

    '                        If Not lblStatus2 Is Nothing Then
    '                            CType(lblStatus2, Windows.Forms.Label).Text = "Initialising Please Wait  ......."
    '                        End If

    '                        Call funcAll_Lamp_Off()

    '                        dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
    '                        intlmp_position = gobjInst.Lamp_Position

    '                        If gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, intlmp_position) = True Then
    '                            '--- Do Nothing
    '                        Else
    '                            'MessageBox.Show("Error in setting HCL current")
    '                            gobjMessageAdapter.ShowMessage(constSetHCLCurError)
    '                            Application.DoEvents()
    '                        End If

    '                        If gobjInst.Current = 0.0 Then
    '                            gobjInst.Current = dbllmp_current
    '                        End If

    '                        blnFlag = funcTestLampPresence()

    '                        If blnFlag Then
    '                            If Not blnZeroOrder Then
    '                                blnZeroOrder = funcZero_Order()
    '                                If Not blnZeroOrder Then
    '                                    gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound)
    '                                    Application.DoEvents()
    '                                    blnFlag = False
    '                                End If
    '                            End If
    '                            If blnFlag Then
    '                                If funcTur_Opt_New() Then
    '                                    'do nothing
    '                                End If
    '                            Else
    '                                Exit For
    '                            End If
    '                        End If 'blnflag
    '                    Next 'for loop
    '                End If ' slit home 
    '            End If ' wv zero
    '        End If ' turret home
    '        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
    '            Call funcAir_ON()
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    'Private Function funcZero_Order(Optional ByRef lblStatus1 As Object = Nothing, _
    '                               Optional ByRef lblStatus2 As Object = Nothing, _
    '                               Optional ByRef lblStatus3 As Object = Nothing) As Boolean
    '    '------------------------------------------------------------------
    '    'Procedure Name         :   funcZero_Order
    '    'Description            :   To optimise turret
    '    'Parameters             :   None
    '    'Time/Date              :   5/10/06
    '    'Dependencies           :   
    '    'Author                 :   Deepak B.
    '    'Revision               :
    '    'Revision by Person     :   Deepak B. on 26.11.06
    '    '------------------------------------------------------------------
    '    Dim objWait As New CWaitCursor
    '    Dim rPOs As Integer
    '    Dim intCounter As Integer
    '    Dim chNew, chBase As Integer
    '    Dim max_int As Integer
    '    Dim in_pos As Integer
    '    Dim blnFlag As Boolean = False

    '    Try
    '        If funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
    '            'MessageBox.Show("Error in setting calibration mode")
    '            gobjMessageAdapter.ShowMessage(constCalibrationMode)
    '            Application.DoEvents()
    '        End If

    '        If Not lblStatus2 Is Nothing Then
    '            CType(lblStatus2, Windows.Forms.Label).Text = "ZERO-ORDER Peak Search"
    '        End If

    '        rPOs = funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0)

    '        '---to confirm from 16 bit code
    '        funcAdj_Pmt_ForValue(CDbl(3500.0), CDbl(350), False)
    '        '------

    '        If Not lblStatus1 Is Nothing Then
    '            CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & gobjInst.PmtVoltage.ToString
    '        End If

    '        'PeakGraph.Ymin= GetEnergy(2047);
    '        'PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);

    '        max_int = 3000
    '        blnFlag = False
    '        intCounter = 1

    '        For intCounter = 1 To rPOs + STEPS_PER_NM
    '            Call funcRotate_Anticlock_Wv()
    '        Next

    '        For intCounter = 1 To STEPS_PER_NM
    '            Call funcRotate_Clock_Wv()
    '        Next

    '        If funcGet_Current_Wv(gobjInst.WavelengthCur) Then
    '            'MessageBox.Show("Error in setting current wavelength")
    '            gobjMessageAdapter.ShowMessage(constSetCurWvError)
    '            Application.DoEvents()
    '        End If

    '        'PeakGraph.Xmin= Inst->Wvcur;
    '        'PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;

    '        'Show_Peak_Param(hwnd, WVZERORANGE); to confirm

    '        If Not lblStatus3 Is Nothing Then
    '            CType(lblStatus3, Windows.Forms.Label).Text = "ZERO-ORDER  peak Search  Range ( " & gobjInst.WavelengthCur & "nm - " & (gobjInst.WavelengthCur + WVZERORANGE) / STEPS_PER_NM & "nm)"
    '        End If

    '        in_pos = 1
    '        max_int = 0

    '        Call funcReadADCFilter(gobjInst.Average, chBase)

    '        For intCounter = 1 To WVZERORANGE
    '            Call funcRotate_Clock_Wv()
    '            Call funcReadADCFilter(gobjInst.Average, chNew)

    '            If chNew > max_int Then
    '                max_int = chNew
    '                in_pos = intCounter
    '                If max_int - chBase > 210 Then
    '                    blnFlag = True
    '                End If
    '            End If

    '            If intCounter = 1 Then
    '                'GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy( chnew));
    '            Else
    '                'GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
    '            End If
    '        Next

    '        'GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
    '        'SetText(hwnd, IDC_STATUS1," Positioning to 0.00 nm Please Wait ..... ");

    '        If Not lblStatus3 Is Nothing Then
    '            CType(lblStatus3, Windows.Forms.Label).Text = " Positioning to 0.00 nm Please Wait ..... "
    '        End If

    '        For intCounter = 1 To WVZERORANGE + STEPS_PER_NM
    '            Call funcRotate_Anticlock_Wv()
    '        Next

    '        For intCounter = 1 To in_pos + STEPS_PER_NM
    '            Call funcRotate_Clock_Wv()
    '        Next

    '        If funcGet_Current_Wv(gobjInst.WavelengthCur) Then
    '            'MessageBox.Show("Error in setting current wavelength")
    '            gobjMessageAdapter.ShowMessage(constSetCurWvError)
    '            Application.DoEvents()
    '        End If

    '        gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur
    '        gobjInst.WavelengthCur = 0.0

    '        funcSet_Current_Wv(gobjInst.WavelengthCur)

    '        funcSet_SlitWidth(0.3)

    '        'mobjCommdll.subTime_Delay(200)

    '        Return blnFlag

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    Public Function funcSearch_Approc_WV_Peak(ByVal intSteps As Integer, ByVal dblPmtv As Double, Optional ByRef lblStatus1 As Object = Nothing, _
    Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing) As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSearch_Approc_WV_Peak
        'Description            :   To optimise Turret 
        'Parameters             :   intSteps,dblPmtv, 
        'Affected Parameter     :   lblStatus1,lblStatus2, lblStatus3
        'Return                 :   Return Highest ADC filter reading counter numbe
        'Time/Date              :   26.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   
        '-------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim intCounter, intCounter1 As Integer
        Dim chNew As Integer
        Dim n_pos As Integer = 1
        Dim max_int As Integer = -1
        Dim int_pos As Integer

        'int Search_Approc_wv_Peak(HWND hwnd, int steps, double	pmt)
        '{
        '   // returns the rough peak value
        '   int 	i, in_pos, chnew;
        '   char 	line1[80]="";
        '   #If !DEMO Then
        '       int   npos=1, j, max_int=-1;
        '   #End If
        '   float stepspernm=50.0;
        '   if (GetInstrument()==AA202){
        '       stepspernm = STEPS_PER_NM_AA202;
        '   }
        '   else{
        '       stepspernm = STEPS_PER_NM;
        '   }

        '   strcpy(line1,"");
        '   Set_PMT(pmt);
        '   Adj_pmt_NearZeroWv(hwnd);
        '   Show_Pmt(hwnd, Inst->Pmtv);
        '   Inst->Wvcur = Get_Cur_Wv();
        '   if (Inst->Wvcur<10)
        '	    sprintf(line1," Positioning to  -2.0 nm Wait ..... "); 
        '   Else
        '	    sprintf(line1," Positioning to  %-5.2f nm Wait ..... ",
        '		Inst->Wvcur-(steps/(double) (stepspernm*(float)2.0)) ); //100.0));

        '   SetText(hwnd, IDC_STATUS1,line1);
        '   for (i=1; i<=(steps/(float)2.0)+stepspernm; i++)   {
        '	    Rotate_Anticlock_Wv(	);
        '	}
        '   for (i=1; i<=stepspernm; i++)  {
        '	    Rotate_Clock_Wv(); 
        '	}
        '   Inst->Wvcur = Get_Cur_Wv();
        '   in_pos = 1;  

        '   for (i=1; i<=steps; i++) {
        '	    Rotate_Clock_Wv();	
        '	    chnew = ReadADCFilter();
        '       #If !DEMO Then
        '	        if ( ((chnew-2047.0)/4096.0*10000.0)>=4900.0)    
        '           {
        '		        SetText(hwnd, IDC_STATUS1, " FULL SCALE RESET  Please Wait ..... ");
        '		        npos++;
        '		        if (npos>2)
        '		            break;
        '		        Adj_pmt_NearZeroWv(hwnd);
        '		        Show_Pmt(hwnd, Inst->Pmtv);
        '		        for (j=1; j<=i+stepspernm; j++)  {
        '		            Rotate_Anticlock_Wv();
        '		        }
        '		        for (j=1; j<=stepspernm; j++) {
        '		            Rotate_Clock_Wv();
        '		        }
        '		        i=0; in_pos = 1;  max_int = 0; chnew=0;
        '		        Inst->Wvcur = Get_Cur_Wv();
        '	        }
        '	        if (chnew > max_int && i!=1) {
        '	            max_int = chnew;
        '	            in_pos =i;
        '	        }
        '       #End If
        '       sprintf(line1," Wv : %5.2f nm  Aprox.Peak %5.2f  Energy %5.0f ",
        '	    Inst->Wvcur+i/(double)stepspernm,
        '		Inst->Wvcur+in_pos/(double)stepspernm,
        '		(double) GetmV(chnew));
        '       SetText(hwnd, IDC_STATUS1,line1);
        '   }

        '   Inst->Wvcur = Get_Cur_Wv();
        '   SetText(hwnd, IDC_STATUS,"Positioning Please Wait  .......");

        '   for (i=1; i <= steps+stepspernm; i++)  {
        '	    Rotate_Anticlock_Wv(); 
        '	}
        '   for (i=1; i <= in_pos+stepspernm; i++) {
        '	    Rotate_Clock_Wv();
        '	}
        '   Inst->Wvcur = Get_Cur_Wv();
        '   chnew = ReadADCFilter();
        '   sprintf(line1," Wv : %5.2f nm  Aprox.Peak %5.2f  Energy %5.0f ", Inst->Wvcur+i/(double)stepspernm,
        '			Inst->Wvcur+in_pos/(double)stepspernm, (double)GetmV(chnew));
        '   SetText(hwnd, IDC_STATUS1,line1);
        '   SetText(hwnd, IDC_STATUS1,"");
        '   return in_pos;
        '}

        Try
            '1.	Set pmt voltage.

            If funcSet_PMT(dblPmtv) = False Then
                '---12.02.08
                Application.DoEvents()
                'If funcSet_PMT(dblPmtv) = False Then
                'End If
            End If

            '2.	Adjust pmt near zero wavelength.
            If funcAdj_Pmt_NearZeroWV(lblStatus1, lblStatus2, lblStatus3) = False Then
                gobjMessageAdapter.ShowMessage(constErrorSettingPMT)
                Application.DoEvents()
            End If

            If Not lblStatus1 Is Nothing Then
                CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & Format(gobjInst.PmtVoltage, "###")
            End If

            'mobjCommdll.subTime_Delay(2000) '''''  extradelay

            '3.	Get Current Wavelength from instrument.
            If funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Application.DoEvents()
            End If

            'If funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then    '''''''' extradelay
            '    gobjMessageAdapter.ShowMessage(constSetCurWvError)
            '    Application.DoEvents()
            'End If


            If gobjInst.WavelengthCur < 10 Then
                If Not lblStatus2 Is Nothing Then
                    CType(lblStatus2, Windows.Forms.Label).Text = "Positioning to  -2.0 nm Wait ..... "
                End If
            Else
                If Not lblStatus2 Is Nothing Then
                    CType(lblStatus2, Windows.Forms.Label).Text = "Positioning to  " & gobjInst.WavelengthCur - (intSteps / (CONST_STEPS_PER_NM * 2.0)) & " nm Wait ..... "
                End If
            End If

            '4.	If instrument type is 201 then rotate wavelength  
            'drive anticlockwise ((WVZERORANGE / 2.0 ) + 25) times.

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                For intCounter = 1 To (intSteps / 2.0) + CONST_STEPS_PER_NM_AA201
                    Call funcRotate_Anticlock_Wv()
                Next intCounter

                '5.	If instrument type is 201 then rotate wavelength  drive clockwise (25) times.

                For intCounter = 1 To CONST_STEPS_PER_NM_AA201
                    Call funcRotate_Clock_Wv()
                Next
            Else
                '6.	If instrument type is not 201 then rotate wavelength  
                'drive anticlockwise ((WVZERORANGE / 2.0 ) + 50) times.

                For intCounter = 1 To (intSteps / 2.0) + CONST_STEPS_PER_NM
                    Call funcRotate_Anticlock_Wv()
                Next intCounter

                '7.	If instrument type is not 201 then rotate wavelength  drive clockwise (50) times.

                For intCounter = 1 To CONST_STEPS_PER_NM
                    Call funcRotate_Clock_Wv()
                Next
            End If

            '8.	Get Current Wavelength from instrument.

            If funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Application.DoEvents()
            End If

            int_pos = 1

            '9.	Repeat following steps for WVZERORANGE times.
            For intCounter = 1 To intSteps
                '10.	Rotate Wavelength drive clockwise.
                Call funcRotate_Clock_Wv()
                'mobjCommdll.subTime_Delay(500) ''''  extradelay
                '11.	Read ADC filter.
                Call funcReadADCFilter(gobjInst.Average, chNew)

                'mobjCommdll.subTime_Delay(500) ''''  extradelay

                '-if not demo
                '12.	Calculate (ADC Filter reading - 2047) / 4096 * 10000
                If ((chNew - 2047.0) / 4096.0 * 10000.0) >= 4900.0 Then
                    If Not lblStatus2 Is Nothing Then
                        CType(lblStatus2, Windows.Forms.Label).Text = "FULL SCALE RESET  Please Wait ..... "
                        CType(lblStatus2, Windows.Forms.Label).Refresh()
                    End If

                    n_pos += 1

                    '---following condition is changed to 3 from 2
                    '---as suggested by mr. VCK on 05.02.08
                    If n_pos > 3 Then
                        Exit For
                    End If
                    '14.	Adjust pmt near zero wavelength.
                    If funcAdj_Pmt_NearZeroWV(lblStatus1, lblStatus2, lblStatus3) = False Then
                        gobjMessageAdapter.ShowMessage(constErrorSettingPMT)
                        Application.DoEvents()
                    End If

                    If Not lblStatus1 Is Nothing Then
                        CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & Format(gobjInst.PmtVoltage, "###")
                    End If

                    '***************************************************
                    '---Added by Mangesh on 12-Apr-2007 for AA201
                    '***************************************************
                    '15.	If instrument type is 201 then rotate wavelength 
                    'drive anticlockwise (Counter number + 25 ) times.
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                        For intCounter1 = 1 To intCounter + CONST_STEPS_PER_NM_AA201
                            Call funcRotate_Anticlock_Wv()
                        Next
                        '16.	If instrument type is 201 then rotate wavelength drive clockwise ( 25 ) times.
                        For intCounter1 = 1 To CONST_STEPS_PER_NM_AA201
                            Call funcRotate_Clock_Wv()
                        Next
                        '***************************************************
                    Else
                        '17.	If instrument type is not 201 then rotate wavelength 
                        'drive anticlockwise ( Counter number + 50 ) times.
                        For intCounter1 = 1 To intCounter + CONST_STEPS_PER_NM
                            Call funcRotate_Anticlock_Wv()
                        Next
                        '18.	If instrument type is not 201 then rotate wavelength 
                        'drive clockwise ( 50 ) times.
                        For intCounter1 = 1 To CONST_STEPS_PER_NM
                            Call funcRotate_Clock_Wv()
                        Next
                    End If

                    intCounter = 0
                    int_pos = 1
                    max_int = 0
                    chNew = 0
                    '19.	Get current Wavelength.
                    If funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                        gobjMessageAdapter.ShowMessage(constSetCurWvError)
                        Application.DoEvents()
                    End If
                End If
                '20.	Memorize highest ADC filter reading throughout iterations and its counter number.
                If (chNew > max_int) And (intCounter <> 1) Then
                    max_int = chNew
                    int_pos = intCounter
                End If

                If Not IsNothing(lblStatus2) Then
                    '***************************************************
                    '---Added by Mangesh on 12-Apr-2007 for AA201
                    '***************************************************
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                        CType(lblStatus2, Windows.Forms.Label).Text = _
                            "Wavelength : " & Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM_AA201, "0.00") & " nm " & _
                            "Approx.Peak : " & Format(gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM_AA201, "0.00") & _
                            " Energy : " & Format(gFuncGetmv(chNew), "#0.00")
                        '***************************************************
                    Else
                        CType(lblStatus2, Windows.Forms.Label).Text = _
                                "Wavelength : " & Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM, "0.00") & " nm " & _
                                "Approx.Peak : " & Format(gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM, "0.00") & _
                                " Energy : " & Format(gFuncGetmv(chNew), "#0.00")
                    End If

                End If

            Next intCounter
            '21.	Get current Wavelength.
            If funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Application.DoEvents()
            End If

            If Not lblStatus3 Is Nothing Then
                CType(lblStatus3, Windows.Forms.Label).Text = "Positioning Please Wait  ......."
            End If

            '***************************************************
            '---Added by Mangesh on 12-Apr-2007 for AA201
            '***************************************************
            '22.	If instrument type is 201 then rotate wavelength 
            'drive anticlockwise (WVZERORANGE + 25 ) times.
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                For intCounter = 1 To intSteps + CONST_STEPS_PER_NM_AA201
                    Call funcRotate_Anticlock_Wv()
                Next
                '23.	If instrument type is 201 then rotate wavelength drive clockwise ( 25 ) times.
                For intCounter = 1 To int_pos + CONST_STEPS_PER_NM_AA201
                    Call funcRotate_Clock_Wv()
                Next
                '***************************************************
            Else

                '24.	If instrument type is not 201 then rotate wavelength 
                'drive anticlockwise (WVZERORANGE + 50 ) times.
                For intCounter = 1 To intSteps + CONST_STEPS_PER_NM
                    Call funcRotate_Anticlock_Wv()
                Next
                '25.	If instrument type is not 201 then rotate wavelength drive clockwise ( 50 ) times.
                For intCounter = 1 To int_pos + CONST_STEPS_PER_NM
                    Call funcRotate_Clock_Wv()
                Next
            End If
            '26.	Get current Wavelength.
            If funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Application.DoEvents()
            End If
            '27.	Read ADC Filter.
            Call funcReadADCFilter(gobjInst.Average, chNew)

            If Not IsNothing(lblStatus2) Then
                '***************************************************
                '---Added by Mangesh on 12-Apr-2007 for AA201
                '***************************************************
                If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                    CType(lblStatus2, Windows.Forms.Label).Text = _
                            "Wavelength : " & Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM_AA201, "0.00") & " nm " & _
                            "Approx.Peak : " & Format((gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM_AA201), "0.00") & _
                            " Energy : " & Format(gFuncGetmv(chNew), "#0.00")
                    '***************************************************
                Else
                    CType(lblStatus2, Windows.Forms.Label).Text = _
                            "Wavelength : " & Format(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM, "0.00") & " nm " & _
                            "Approx.Peak : " & Format((gobjInst.WavelengthCur + int_pos / CONST_STEPS_PER_NM), "0.00") & _
                            " Energy : " & Format(gFuncGetmv(chNew), "#0.00")
                End If

            End If

            If Not IsNothing(lblStatus2) Then
                CType(lblStatus2, Windows.Forms.Label).Text = ""
                CType(lblStatus2, Windows.Forms.Label).Refresh()
            End If
            '28.	Return Highest ADC filter reading counter number.
            Return int_pos

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAdj_Pmt_NearZeroWV(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcAdj_Pmt_NearZeroWV
        'Description            :   To adjust PMT near zero wv
        'Affected parameter     :   lblStatus1,lblStatus2,lblStatus3
        'return                 :   true if success
        'Parameters             :   None
        'Time/Date              :   6/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 major changes
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim chNew As Integer
        Dim dblPmtv As Double = 0.0
        Dim intAvgMV As Integer
        '+++++++++++++++++++++++++++++++++++
        '        void  Adj_pmt_NearZeroWv(HWND hpar)
        '{
        'int 	chnew;
        'double	pmtv=(double)0.0;

        '  chnew = ReadADCFilter();
        '  pmtv=Inst->Pmtv;
        '        If (((chNew - 2047.0) / 4096.0 * 10000.0) >= 2000.0) Then
        '	do  {
        '		pmtv-=(double)5.0;   Set_PMT(pmtv);
        '		Show_Pmt(hpar, Inst->Pmtv);
        '		pc_delay(1000);pc_delay(1000);pc_delay(1000);
        '		chnew = ReadADCFilter();
        '		if ( ((chnew-2047.0)/4096.0*10000.0)<2000.0) break;
        '		if (pmtv>(double)700) {Gerror_message_new("PMT Too high","PMT"); break;}
        '		if (pmtv<(double)50)  {Gerror_message_new("PMT Too low","PMT"); break;}
        '		pc_delay(1000);pc_delay(1000);pc_delay(1000);
        '	 }
        '	while (1);
        '  else  if (((chnew-2047.0)/4096.0*10000.0)< 100.0)
        '  do{
        '	 pmtv++;   Set_PMT(pmtv);
        '	 Show_Pmt(hpar, Inst->Pmtv);
        '	 pc_delay(1000);pc_delay(1000);pc_delay(1000);
        '	 chnew = ReadADCFilter();
        '	 pc_delay(1000);pc_delay(1000);pc_delay(1000);
        '	 if ( ((chnew-2047.0)/4096.0*10000.0)>100.0) break;
        '	 if (pmtv>(double)700) {Gerror_message_new("PMT Too high","PMT"); break;}
        '	 if (pmtv<(double)50) {Gerror_message_new("PMT Too low","PMT"); break;}
        '	}
        '	while (1);
        '}
        '+++++++++++++++++++++++++++++++++++
        Try

            '1.	Read ADC filter

            funcReadADCFilter(gobjInst.Average, chNew)

            dblPmtv = gobjInst.PmtVoltage

            '2.	Calculate ((ADC filter Reading - 2047.0) / 4096.0 * 10000.0)

            If ((chNew - 2047.0) / 4096.0 * 10000.0) >= 2000.0 Then
                Do
                    '6.	pmt voltage = pmt voltage – 5.0

                    dblPmtv -= CDbl(5.0)

                    '7.	set pmt voltage

                    funcSet_PMT(dblPmtv)
                    If Not lblStatus1 Is Nothing Then
                        CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & gobjInst.PmtVoltage
                    End If

                    'mobjCommdll.subTime_Delay(2000) '''''''' extradelay
                    '8.	Read ADC filter

                    funcReadADCFilter(gobjInst.Average, chNew)
                    If ((chNew - 2047.0) / 4096.0 * 10000.0) < 2000.0 Then
                        Exit Do
                    End If
                    If dblPmtv > CDbl(700) Then
                        gobjMessageAdapter.ShowMessage(constPMT2High)
                        'MessageBox.Show("PMT Too high", "PMT")
                        Application.DoEvents()
                        Exit Do
                    End If

                    If dblPmtv < CDbl(50) Then
                        gobjMessageAdapter.ShowMessage(constPMT2Low)
                        'MessageBox.Show("PMT Too low", "PMT")
                        Application.DoEvents()
                        Exit Do
                    End If

                    'mobjCommdll.subTime_Delay(2000) ''''''''''   extradelay

                Loop While (1)

            ElseIf ((chNew - 2047.0) / 4096.0 * 10000.0) < 100.0 Then

                Do
                    '14.	pmt voltage = pmt voltage + 1

                    dblPmtv += 1
                    '15.	set pmt voltage

                    funcSet_PMT(dblPmtv)
                    If Not lblStatus1 Is Nothing Then
                        CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & gobjInst.PmtVoltage
                    End If

                    'mobjCommdll.subTime_Delay(2000) '''''''''' extradelay

                    '16.	Read ADC filter

                    funcReadADCFilter(gobjInst.Average, chNew)

                    'mobjCommdll.subTime_Delay(2000) '''''''''''' extradelay

                    If ((chNew - 2047.0) / 4096.0 * 10000.0) > 100.0 Then
                        Exit Do
                    End If
                    If dblPmtv > CDbl(700) Then
                        gobjMessageAdapter.ShowMessage(constPMT2High)
                        'MessageBox.Show("PMT Too high", "PMT")
                        Application.DoEvents()
                        Exit Do
                    End If

                    If dblPmtv < CDbl(50) Then
                        gobjMessageAdapter.ShowMessage(constPMT2Low)
                        'MessageBox.Show("PMT Too low", "PMT")
                        Application.DoEvents()
                        Exit Do
                    End If
                Loop While (1)
            End If

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAdj_Pmt_ForValue(ByVal dblValue As Double, ByVal dblMaxPmt As Double, ByVal blnNewZero As Boolean) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcAdj_Pmt_ForValue
        'Description            :   To adjust pmt voltage to obtain maximum energy
        'Parameters             :   dblValue : 
        '                           dblMaxPmt : max pmt to be set
        '                           blnNewZero : 
        'Return                 :   True if success
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 major changes
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim chNew As Integer
        Dim intPmtv As Integer = 0
        Dim intAvgMV As Integer
        Dim intCounter As Integer = 0
        Dim dblCurMode As Double = 0.0
        Dim dbltol As Double = 0.0
        Dim dblmulf As Double = 0.0
        Dim addf, avgt As Integer
        Dim mode As EnumCalibrationMode
        Dim intCounterA, intCounterB, intCounterC As Integer
        Dim strEnergy As String
        Dim strEnergyStatus As String
        Dim ObjFrmPmt As New frmPMT
        Dim Strline1 As String

        Try
            mode = gobjInst.Mode
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                ObjFrmPmt.Text = "Setting PMT of Sample"
            End If
            ' Check when adj. not zero value
            If blnNewZero = False Then
                ObjFrmPmt.Show()
                ObjFrmPmt.BringToFront()
                Application.DoEvents()

                avgt = gobjInst.Average
                gobjInst.Average = 10

                If mode = EnumCalibrationMode.AA Or mode = EnumCalibrationMode.AABGC Then
                    dbltol = 5.0
                    dblmulf = 2.0
                Else
                    If dblValue = 0 Then
                        Return False
                    End If
                    dbltol = 100.0
                    dblmulf = 0.6
                End If


                If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                    ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE "
                    ObjFrmPmt.lblTitle.Refresh()
                Else
                    ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
                    ObjFrmPmt.lblTitle.Refresh()
                End If

                If gobjInst.PmtVoltage > 690 Then
                    gobjInst.PmtVoltage = 400
                End If
                If gobjInst.PmtVoltage < 50 Then
                    gobjInst.PmtVoltage = 51
                End If

                intPmtv = CInt((gobjInst.PmtVoltage * CDbl(4095.0)) / CDbl(1000.0))

                Do
                    intCounter = 0
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then    '4.85 14.04.09
                        Do
                            ObjFrmPmt.lblBlink.Text = "X"
                            ObjFrmPmt.lblBlink.Refresh()
                            funcReadADCFilter(gobjInst.Average, chNew)
                            ObjFrmPmt.lblBlink.Text = ""
                            ObjFrmPmt.lblBlink.Refresh()
                            intCounter += 1
                        Loop While (intCounter < 5)
                    Else
                        Do
                            ObjFrmPmt.lblBlink.Text = "X"
                            ObjFrmPmt.lblBlink.Refresh()
                            funcReadADCFilter(gobjInst.Average, chNew)
                            ObjFrmPmt.lblBlink.Text = ""
                            ObjFrmPmt.lblBlink.Refresh()
                            intCounter += 1
                        Loop While (intCounter < 10)
                    End If


                    ' Read ADC value with filter 
                    Call funcReadADCFilter(gobjInst.Average, chNew)

                    dblCurMode = ((chNew - 2047.0) / 4096.0) * 10000.0
                    ' Show the energy status
                    If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                        strEnergyStatus = "PMT " & Format(gobjInst.PmtVoltage, "###") & " V, Energy : " & Format(dblCurMode, "###") & " % (" & Format(dbltol, "###.0") & "%)"
                    Else
                        'sprintf(line1,"PMT -%3.0f V, Abs : %4.3f  ",Inst->Pmtv, x2/2000.0);
                        strEnergyStatus = "PMT " & Format(gobjInst.PmtVoltage, "###") & " V, Abs : " & Format(dblCurMode / 2000, "####.00") & " % "
                    End If

                    ObjFrmPmt.lblMsg.Text = strEnergyStatus
                    ObjFrmPmt.lblMsg.Refresh()
                    ' Adj. the PMT intervals
                    If dblCurMode >= (dblValue + dbltol) Then
                        intCounterA += 1
                        If dblCurMode > (dblValue + dbltol * 12.0 * dblmulf) Then
                            addf = 35
                        ElseIf dblCurMode > (dblValue + dbltol * 5.0 * dblmulf) Then
                            addf = 10
                        ElseIf dblCurMode > (dblValue + dbltol * 4.0 * dblmulf) Then
                            addf = 7
                        ElseIf dblCurMode > (dblValue + dbltol * 3.0 * dblmulf) Then
                            addf = 3
                        Else
                            addf = 1
                        End If
                        If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                            intPmtv -= addf
                        Else
                            intPmtv += addf
                        End If
                        ' Set PMT into minor steps
                        funcSet_PMT_Bit(intPmtv)
                    ElseIf dblCurMode <= (dblValue - dbltol) Then
                        intCounterB += 1
                        If dblCurMode < (dblValue - dbltol * 12.0 * dblmulf) Then
                            addf = 80
                        ElseIf dblCurMode < (dblValue - dbltol * 8.0 * dblmulf) Then
                            addf = 30
                        ElseIf dblCurMode < (dblValue - dbltol * 5.0 * dblmulf) Then
                            addf = 25
                        ElseIf dblCurMode < (dblValue - dbltol * 4.0 * dblmulf) Then
                            addf = 12
                        ElseIf dblCurMode < (dblValue - dbltol * 3.0 * dblmulf) Then
                            addf = 5
                        Else
                            addf = 1
                        End If
                        If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                            intPmtv += addf
                        Else
                            intPmtv -= addf
                        End If
                        ' Set PMT into minor steps
                        funcSet_PMT_Bit(intPmtv)
                    Else
                        If dblCurMode = dblValue Then
                            Exit Do
                        Else
                            intCounterC += 1
                        End If
                        If intCounterC > 2 Then
                            Exit Do
                        End If
                    End If

                    ' this block is use to be not in continues loop the process
                    If intCounterA > 10 Then
                        If intCounterB > 10 Then
                            If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                intPmtv -= addf
                            Else
                                intPmtv += addf
                            End If
                            funcSet_PMT_Bit(intPmtv)
                            Exit Do
                        Else
                            intCounterA = 0
                        End If
                    End If

                    If ObjFrmPmt.mCancelProcess = True Then
                        Exit Do
                    End If

                    '--pmtv goes beyond maxpmt passed as second argument then give error message or warning
                    If gobjInst.PmtVoltage > dblMaxPmt Then
                        gobjMessageAdapter.ShowMessage(constRequireGreaterPMT)
                        Application.DoEvents()
                        Exit Do
                    End If

                    '--pmtv goes below 50 then give error message or warning
                    If gobjInst.PmtVoltage < CDbl(50) Or gobjInst.PmtVoltage < CDbl(0) Then
                        gobjMessageAdapter.ShowMessage(constPMTLessthan50)
                        Application.DoEvents()
                        Exit Do
                    End If
                    ObjFrmPmt.Refresh()
                    ObjFrmPmt.BringToFront()
                    Application.DoEvents()

                Loop While (1)

                ObjFrmPmt.Close()
                ObjFrmPmt.Dispose()
                gobjInst.Average = avgt

            Else
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '        BOOL		Adj_PMT_forvalue(HWND hpar, double value, double	maxpmt)
                '{
                'HWND	hwnd;
                'MSG		msg;
                'double  	x2=0.0, tol=0.0;
                'int   	ch, i;
                'int   	pmt, addf;
                'int  		a=0, b=0, c=0, avgt;
                'char 		line1[80]="";
                'char     str[40]="";
                'int		mode;

                ' Inst = GetInstData();
                ' mode=Inst->Mode;

                'hwnd= CreateWindowPeak(hpar, "SETTING PMT","PMTADJ", 0);
                'if (mode==AA || mode==HCLE || mode==D2E || mode==AABGC || mode==EMISSION) {//0
                '  avgt = Inst->Avg;
                '  Inst->Avg =10;
                '  if(mode==HCLE || mode == D2E|| mode == EMISSION )
                '	SetText(hwnd, IDC_STATUS," Setting FULL SCALE ");
                '            Else
                '  SetText(hwnd, IDC_STATUS," AUTO ZERO ");
                '  if (Inst->Pmtv>(double)690) Inst->Pmtv = (double)400;
                '  if (Inst->Pmtv<(double)50) Inst->Pmtv = (double)51;

                '  pmt = (int) ( (Inst->Pmtv*(double)4095.0)/(double)1000.0);
                '  do  {//1
                '	 i = 0;
                '	 do {//2
                '		SetText(hwnd, IDC_BLINK,"X");
                '		ch=ReadADCFilter();
                '		SetText(hwnd, IDC_BLINK," ");
                '		i++;
                '	  } while (i<10); //2
                '	 ch=ReadADCFilter();
                '	 x2 = GetADConvertedToCurMode(ch);

                '	 if (mode==AA || mode==AABGC ) {//3
                '		if (fabs(x2-value) <0.005){//4
                '		  Set_PMT_Bit(pmt);
                '		  break;
                '		 }//4
                '	  }//3

                '	 strcpy(line1,"");
                '	 if (value!=(double) 0.0)
                '	  tol = x2/value*100.0;
                '                                        Else
                '	  tol = (x2+1.0)/(value+1.0)*100.0;

                '	  if(mode==HCLE || mode ==D2E || mode == EMISSION)   
                '     sprintf(line1,"PMT -%3.0f V, Energy:%3.0f %% (%3.1f%%)",Inst->Pmtv,x2 ,tol);
                '		else{ //5
                '		sprintf(line1,"PMT -%3.0f V, Abs:",Inst->Pmtv);
                '		StoreAbsAccurate(x2,str);
                '		strcat(line1,str);
                '		sprintf(str," (%3.1f %%) ",tol);
                '		strcat(line1,str);
                '	 }//5

                '	 SetText(hwnd, IDC_STATUS1,line1);

                '	 if (tol>99.5 && tol<100.5)
                '		break;

                '	 else if (tol>100.0){//6
                '		a++;
                '		if (tol>=200.0) addf = 120;
                '		if (tol>150.0) addf = 60;
                '		else if (tol>120.0) addf = 20;
                '		else  if (tol>110.0) addf = 12;
                '		else if (tol>105) addf = 5;
                '		else if (tol>103) addf = 3;
                '		else	addf =1;
                '		if(mode==HCLE|| mode==D2E|| mode == EMISSION)
                '		  pmt-=addf;
                '         Else
                '		  pmt+=addf;
                '		 Set_PMT_Bit(pmt);
                '	  } //6

                '	 else if (tol<100.0) {//7
                '		b++;
                '		if (tol<30.0) addf = 100;
                '		else if (tol<50.0) addf = 60;
                '		else if (tol<65.0) addf = 30;
                '		else if (tol<80.0) addf = 20;
                '		else if (tol<90.0) addf = 12;
                '		else if (tol<95.0) addf = 5;
                '		else if (tol<97.0) addf = 3;
                '      Else
                '		  addf = 1;
                '		if(mode==HCLE|| mode==D2E|| mode == EMISSION) 
                '       pmt+=addf;
                '		else pmt-=addf;
                '		Set_PMT_Bit(pmt);
                '	  } //7

                '	 else  { //8
                '		if(tol==100.0)
                '		  break;
                '		else { //9
                '		  c++; if(c>2)
                '		  break;
                '		 } //9
                '	  } //8

                '	 if (a>5){ //10
                '		if (b>5)  { //11
                '		  if(mode==HCLE|| mode==D2E|| mode == EMISSION) pmt-=addf;
                '		  else pmt+=addf; Set_PMT_Bit(pmt);
                '		  break;
                '		 } //11
                '		else a =0;
                '	  } //10

                '	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
                '		break;

                '	 if (Inst->Pmtv > maxpmt){ //12
                '#If REMOVE_INST_MSG Then
                '		MessageBox(hwnd," Warning Requires Greater PMT Volts ", "PMT",MB_ICONASTERISK | MB_OK);
                '#Else
                '		Gerror_message_new(" Warning Requires Greater PMT Volts ", "PMT");
                '#End If
                '		break;
                '	  } //12

                '	 if (Inst->Pmtv < (double)50 || Inst->Pmtv < (double)0) { //13
                '		Gerror_message_new(" Cannot adjust PMT less than 50 Volts ", "PMT");
                '		break;
                '	  } //13
                '	} while(1); //1
                '  DestroyWindowPeak(hwnd, NULL); 
                '  Inst->Avg = avgt;
                ' } //0
                'return TRUE;
                '}
                '//--------------------------------------------
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++

                ObjFrmPmt.Show()
                ObjFrmPmt.BringToFront()
                Application.DoEvents()

                '1.	Perform following steps for any of these modes (HCLE/D2E/Emission/AABGC/AA).
                If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION _
                    Or mode = EnumCalibrationMode.AABGC Or mode = EnumCalibrationMode.AA Then

                    avgt = gobjInst.Average
                    '2.	Set average as 10 instead of 300 in data structure variable.
                    gobjInst.Average = 10

                    If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                        ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE "
                        ObjFrmPmt.lblTitle.Refresh()
                    Else
                        'ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
                        If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                            If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                                ObjFrmPmt.Text = "Setting PMT of sample beam"
                                ObjFrmPmt.lblTitle.Text = "Balancing Beam"
                            Else
                                ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
                            End If
                        Else
                            ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
                        End If

                        ObjFrmPmt.lblTitle.Refresh()
                    End If

                    '3.	If pmt voltage is greater than 690 then set it as 400 in variable which holds pmt.
                    If gobjInst.PmtVoltage > 690 Then
                        gobjInst.PmtVoltage = 400
                    End If

                    '4.	If pmt voltage is less than 50 then set it as 51 in variable which holds pmt.
                    If gobjInst.PmtVoltage < 50 Then
                        gobjInst.PmtVoltage = 51
                    End If

                    Application.DoEvents()
                    '5.	Calculate (PmtVoltage * 4095.0 / 1000.0) in a local variable.
                    intPmtv = CInt(gobjInst.PmtVoltage * CDbl(4095.0) / CDbl(1000.0))

                    Do
                        intCounter = 0

                        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then  '4.85 14.04.09
                            Do
                                ObjFrmPmt.lblBlink.Text = "X"
                                ObjFrmPmt.lblBlink.Refresh()
                                '7.	Read ADC filter 10 times with average of 10.
                                funcReadADCFilter(gobjInst.Average, chNew)
                                ObjFrmPmt.lblBlink.Text = ""
                                ObjFrmPmt.lblBlink.Refresh()
                                intCounter += 1
                            Loop While (intCounter < 5)
                        Else
                            Do
                                ObjFrmPmt.lblBlink.Text = "X"
                                ObjFrmPmt.lblBlink.Refresh()
                                '7.	Read ADC filter 10 times with average of 10.
                                funcReadADCFilter(gobjInst.Average, chNew)
                                ObjFrmPmt.lblBlink.Text = ""
                                ObjFrmPmt.lblBlink.Refresh()
                                intCounter += 1
                            Loop While (intCounter < 10)
                        End If

                        '8.	Read ADC filter once more.
                        funcReadADCFilter(gobjInst.Average, chNew)
                        '9.	Convert ADC filter reading to calibration mode value.
                        dblCurMode = gFuncGetADConvertedToCurMode(chNew)

                        '10.If mode is AA or AABGC and (Output of step no. 9 
                        '– MinVal) is less than 0.005 then set pmt as output of step no. 5.

                        If mode = EnumCalibrationMode.AA Or mode = EnumCalibrationMode.AABGC Then
                            If Math.Abs(dblCurMode - dblValue) < 0.005 Then
                                funcSet_PMT_Bit(intPmtv)
                                Exit Do
                            End If
                        End If

                        '12.	Calculate percent pmt by using formula Output Of 
                        'step number 9 / MinVal * 100.0

                        Strline1 = ""
                        If dblValue <> CDbl(0.0) Then
                            dbltol = dblCurMode / dblValue * 100.0
                        Else
                            dbltol = (dblCurMode + 1.0) / (dblValue + 1.0) * 100.0
                        End If

                        If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                            Strline1 = "PMT " & Format(gobjInst.PmtVoltage, "###") & " V, Energy : " & Format(dblCurMode, "0.00") & " % (" & Format(dbltol, "0.0#") & " %)"
                        Else
                            Strline1 = "PMT " & Format(gobjInst.PmtVoltage, "###") & " V, Abs : " & Format(dblCurMode, "0.000") & " (" & Format(dbltol, "0.00") & ")"
                        End If

                        ObjFrmPmt.lblMsg.Text = Strline1
                        ObjFrmPmt.lblMsg.Refresh()

                        '13.if output of step 12 > 99.5 and it is < 100.5
                        'then Come out of the loop which has stated from step number 6 else continue with following.

                        If dbltol > 99.5 And dbltol < 100.5 Then
                            Exit Do

                            '14.if output of step 12 > 100 then
                            'if output of step 12 >= 200 then AddAmount=120
                            'if output of step 12 > 150 then AddAmount=60
                            'if output of step 12 > 120 then AddAmount=20
                            'if output of step 12 > 110 then AddAmount=12
                            'if output of step 12 > 105 then AddAmount=5
                            'if output of step 12 > 103 then AddAmount=3 else AddAmount=1

                        ElseIf dbltol > 100.0 Then
                            intCounterA += 1
                            If dbltol >= 200.0 Then
                                addf = 120
                            End If
                            If dbltol > 150.0 Then
                                addf = 60
                            ElseIf dbltol > 120.0 Then
                                addf = 20
                            ElseIf dbltol > 110.0 Then
                                addf = 12
                            ElseIf dbltol > 105 Then
                                addf = 5
                            ElseIf dbltol > 103 Then
                                addf = 3
                            Else
                                addf = 1
                            End If

                            '15.if mode is HCLE or D2E or Emission then
                            'Output of step 15 = Output of step 5 – AddAmount
                            'Else
                            'Output of step 15 = Output of step 5 + AddAmount

                            If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                intPmtv -= addf
                            Else
                                intPmtv += addf
                            End If
                            '16.	Set pmt as Output of step 15.
                            funcSet_PMT_Bit(intPmtv)

                            '17.if output of step 12 < 100 then
                            'if output of step 12 < 30 then AddAmount=100
                            'if output of step 12 < 50 then AddAmount=60
                            'if output of step 12 < 65 then AddAmount=30
                            'if output of step 12 < 80 then AddAmount=20
                            'if output of step 12 < 90 then AddAmount=12
                            'if output of step 12 < 95 then AddAmount=5 
                            'if output of step 12 < 97 then AddAmount=3 else AddAmount=1

                        ElseIf dbltol < 100.0 Then
                            intCounterB += 1
                            If dbltol < 30.0 Then
                                addf = 100
                            ElseIf dbltol < 50.0 Then
                                addf = 60
                            ElseIf dbltol < 65.0 Then
                                addf = 30
                            ElseIf dbltol < 80.0 Then
                                addf = 20
                            ElseIf dbltol < 90.0 Then
                                addf = 12
                            ElseIf dbltol < 95.0 Then
                                addf = 5
                            ElseIf dbltol < 97.0 Then
                                addf = 3
                            Else
                                addf = 1
                            End If

                            '18.if mode is HCLE or D2E or Emission then
                            'Output of step 18 = Output of step 5 + AddAmount
                            '                        Else
                            'Output of step 18 = Output of step 5 - AddAmount

                            If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                intPmtv += addf
                            Else
                                intPmtv -= addf
                            End If
                            '19.	Set pmt as Output of step 18.
                            funcSet_PMT_Bit(intPmtv)

                        Else

                            '20.if output of step 12 = 100 then come out of loop 
                            'which has started from step 6 else if occurrence of this step is more than 2 then exit out of loop.

                            If dbltol = 100.0 Then
                                Exit Do
                            Else
                                intCounterC += 1
                                If (intCounterC > 2) Then
                                    Exit Do
                                End If
                            End If
                        End If

                        '21.if occurrence of step 14 and step 17 is more than 
                        '5 then execute step number 15 and 16 and come out of the loop.

                        If intCounterA > 5 Then
                            If intCounterB > 5 Then
                                If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                    intPmtv -= addf
                                Else
                                    intPmtv += addf
                                End If
                                funcSet_PMT_Bit(intPmtv)
                                Exit Do
                            Else
                                intCounterA = 0
                            End If
                        End If
                        ' User wants to terminate the job 
                        If ObjFrmPmt.mCancelProcess = True Then
                            Exit Do
                        End If

                        '22.If pmt is greater than MaxVal then come out of 
                        'the loop.

                        If gobjInst.PmtVoltage > dblMaxPmt Then
                            gobjMessageAdapter.ShowMessage(constRequireGreaterPMT)
                            Application.DoEvents()

                            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                                funcSet_PMT(0)
                                funcSet_PMTReferenceBeam(0)
                            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203 Or gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then  '---02.06.09 to set pmt to zero
                                funcSet_PMT(0)
                            End If
                            '-------
                            Exit Do
                        End If

                        '23.	If pmt is less than 50 or less than 0 then come 
                        'out of the loop.

                        If gobjInst.PmtVoltage < CDbl(50) Or gobjInst.PmtVoltage < CDbl(0) Then
                            gobjMessageAdapter.ShowMessage(constPMTLessthan50)
                            Application.DoEvents()
                            Exit Do
                        End If

                        ObjFrmPmt.Refresh()
                        ObjFrmPmt.BringToFront()
                        Application.DoEvents()
                        '24.	End of loop.
                    Loop While (1)

                    ObjFrmPmt.Close()
                    ObjFrmPmt.Dispose()
                    gobjInst.Average = avgt

                End If
            End If

            Call Application.DoEvents()

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAdj_Pmt_ForValue_Ref(ByVal dblValue As Double, ByVal dblMaxPmt As Double, ByVal blnNewZero As Boolean) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcAdj_Pmt_ForValue_Ref
        'Description            :   To adjust pmt voltage to obtain maximum energy
        'Parameters             :   dblValue : 
        '                           dblMaxPmt : max pmt to be set
        '                           blnNewZero : 
        'Return                 :   True if success
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 major changes
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim chNew As Integer
        Dim intPmtv As Integer = 0
        Dim intAvgMV As Integer
        Dim intCounter As Integer = 0
        Dim dblCurMode As Double = 0.0
        Dim dbltol As Double = 0.0
        Dim dblmulf As Double = 0.0
        Dim addf, avgt As Integer
        Dim mode As EnumCalibrationMode
        Dim intCounterA, intCounterB, intCounterC As Integer
        Dim strEnergy As String
        Dim strEnergyStatus As String
        Dim ObjFrmPmt As New frmPMT
        Dim Strline1 As String

        Try
            '---temporarily it is set here later it should be set from somewhere else
            'gobjInst.Mode = modGlobalConstants.EnumCalibrationMode.HCLE
            '---------------
            mode = gobjInst.Mode

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                ObjFrmPmt.Text = "Setting PMT of Ref. beam"
            End If
            ' Check when adj. not zero value
            If blnNewZero = False Then

                ObjFrmPmt.Show()
                ObjFrmPmt.BringToFront()
                Application.DoEvents()

                avgt = gobjInst.Average
                gobjInst.Average = 10

                If mode = EnumCalibrationMode.AA Or mode = EnumCalibrationMode.AABGC Then
                    dbltol = 5.0
                    dblmulf = 2.0
                Else
                    If dblValue = 0 Then
                        Return False
                    End If
                    dbltol = 100.0
                    dblmulf = 0.6
                End If
                If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                    ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE "
                    ObjFrmPmt.lblTitle.Refresh()
                Else
                    '//----------
                    If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                        If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                            ObjFrmPmt.Text = "Setting PMT of Reference beam"
                            ObjFrmPmt.lblTitle.Text = "Balancing Beam"
                        Else
                            ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
                        End If
                    Else
                        ObjFrmPmt.lblTitle.Text = "AUTO ZERO "

                    End If
                    ObjFrmPmt.lblTitle.Refresh()
                    '//----------
                End If

                If gobjInst.PmtVoltageReference > 690 Then
                    gobjInst.PmtVoltageReference = 400
                End If
                If gobjInst.PmtVoltageReference < 50 Then
                    gobjInst.PmtVoltageReference = 51
                End If

                intPmtv = CInt((gobjInst.PmtVoltageReference * CDbl(4095.0)) / CDbl(1000.0))

                Do
                    intCounter = 0
                    Do
                        ObjFrmPmt.lblBlink.Text = "X"
                        ObjFrmPmt.lblBlink.Refresh()
                        funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew)
                        ObjFrmPmt.lblBlink.Text = ""
                        ObjFrmPmt.lblBlink.Refresh()
                        intCounter += 1
                    Loop While (intCounter < 10)
                    ' Read ADC value with filter and Cal. Energy
                    Call funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew)
                    dblCurMode = ((chNew - 2047.0) / 4096.0) * 10000.0

                    ' Show the energy status
                    If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                        strEnergyStatus = "PMT " & Format(gobjInst.PmtVoltageReference, "###") & " V, Energy : " & Format(dblCurMode, "###") & " % (" & Format(dbltol, "##0.0") & "%)"
                    Else
                        'sprintf(line1,"PMT -%3.0f V, Abs : %4.3f  ",Inst->Pmtv, x2/2000.0);
                        strEnergyStatus = "PMT " & Format(gobjInst.PmtVoltageReference, "###") & " V, Abs : " & Format(dblCurMode / 2000, "###0.00") & " % "
                    End If

                    ObjFrmPmt.lblMsg.Text = strEnergyStatus
                    ObjFrmPmt.lblMsg.Refresh()
                    ' Adj. the PMT interval
                    If dblCurMode >= (dblValue + dbltol) Then
                        intCounterA += 1
                        If dblCurMode > (dblValue + dbltol * 12.0 * dblmulf) Then
                            addf = 35
                        ElseIf dblCurMode > (dblValue + dbltol * 5.0 * dblmulf) Then
                            addf = 10
                        ElseIf dblCurMode > (dblValue + dbltol * 4.0 * dblmulf) Then
                            addf = 7
                        ElseIf dblCurMode > (dblValue + dbltol * 3.0 * dblmulf) Then
                            addf = 3
                        Else
                            addf = 1
                        End If
                        If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                            intPmtv -= addf
                        Else
                            intPmtv += addf
                        End If
                        ' Set PMT into minor steps
                        funcSet_PMT_Ref_Bit(intPmtv)
                    ElseIf dblCurMode <= (dblValue - dbltol) Then
                        intCounterB += 1
                        If dblCurMode < (dblValue - dbltol * 12.0 * dblmulf) Then
                            addf = 80
                        ElseIf dblCurMode < (dblValue - dbltol * 8.0 * dblmulf) Then
                            addf = 30
                        ElseIf dblCurMode < (dblValue - dbltol * 5.0 * dblmulf) Then
                            addf = 25
                        ElseIf dblCurMode < (dblValue - dbltol * 4.0 * dblmulf) Then
                            addf = 12
                        ElseIf dblCurMode < (dblValue - dbltol * 3.0 * dblmulf) Then
                            addf = 5
                        Else
                            addf = 1
                        End If
                        If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                            intPmtv += addf
                        Else
                            intPmtv -= addf
                        End If
                        ' Set PMT into minor steps
                        funcSet_PMT_Ref_Bit(intPmtv)
                    Else
                        If dblCurMode = dblValue Then
                            Exit Do
                        Else
                            intCounterC += 1
                        End If
                        If intCounterC > 2 Then
                            Exit Do
                        End If
                    End If
                    ' this block is use to validate contineous loop process
                    If intCounterA > 10 Then
                        If intCounterB > 10 Then
                            If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                intPmtv -= addf
                            Else
                                intPmtv += addf
                            End If
                            funcSet_PMT_Ref_Bit(intPmtv)
                            Exit Do
                        Else
                            intCounterA = 0
                        End If
                    End If

                    ' User wants to terminate the job 
                    If ObjFrmPmt.mCancelProcess = True Then
                        Exit Do
                    End If

                    '--pmtv goes beyond maxpmt passed as second argument then give error message or warning
                    If gobjInst.PmtVoltageReference > dblMaxPmt Then
                        gobjMessageAdapter.ShowMessage(constRequireGreaterPMT)
                        Application.DoEvents()
                        Exit Do
                    End If

                    '--pmtv goes below 50 then give error message or warning
                    If gobjInst.PmtVoltageReference < CDbl(50) Or gobjInst.PmtVoltageReference < CDbl(0) Then
                        gobjMessageAdapter.ShowMessage(constPMTLessthan50)
                        Application.DoEvents()
                        Exit Do
                    End If
                    ObjFrmPmt.Refresh()
                    ObjFrmPmt.BringToFront()
                    Application.DoEvents()
                Loop While (1)
                ObjFrmPmt.Close()
                ObjFrmPmt.Dispose()
                gobjInst.Average = avgt
            Else
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '        BOOL		Adj_PMT_forvalue(HWND hpar, double value, double	maxpmt)
                '{
                'HWND	hwnd;
                'MSG		msg;
                'double  	x2=0.0, tol=0.0;
                'int   	ch, i;
                'int   	pmt, addf;
                'int  		a=0, b=0, c=0, avgt;
                'char 		line1[80]="";
                'char     str[40]="";
                'int		mode;

                ' Inst = GetInstData();
                ' mode=Inst->Mode;

                'hwnd= CreateWindowPeak(hpar, "SETTING PMT","PMTADJ", 0);
                'if (mode==AA || mode==HCLE || mode==D2E || mode==AABGC || mode==EMISSION) {//0
                '  avgt = Inst->Avg;
                '  Inst->Avg =10;
                '  if(mode==HCLE || mode == D2E|| mode == EMISSION )
                '	SetText(hwnd, IDC_STATUS," Setting FULL SCALE ");
                '            Else
                '  SetText(hwnd, IDC_STATUS," AUTO ZERO ");
                '  if (Inst->Pmtv>(double)690) Inst->Pmtv = (double)400;
                '  if (Inst->Pmtv<(double)50) Inst->Pmtv = (double)51;

                '  pmt = (int) ( (Inst->Pmtv*(double)4095.0)/(double)1000.0);
                '  do  {//1
                '	 i = 0;
                '	 do {//2
                '		SetText(hwnd, IDC_BLINK,"X");
                '		ch=ReadADCFilter();
                '		SetText(hwnd, IDC_BLINK," ");
                '		i++;
                '	  } while (i<10); //2
                '	 ch=ReadADCFilter();
                '	 x2 = GetADConvertedToCurMode(ch);

                '	 if (mode==AA || mode==AABGC ) {//3
                '		if (fabs(x2-value) <0.005){//4
                '		  Set_PMT_Bit(pmt);
                '		  break;
                '		 }//4
                '	  }//3

                '	 strcpy(line1,"");
                '	 if (value!=(double) 0.0)
                '	  tol = x2/value*100.0;
                '                                        Else
                '	  tol = (x2+1.0)/(value+1.0)*100.0;

                '	  if(mode==HCLE || mode ==D2E || mode == EMISSION)   
                '     sprintf(line1,"PMT -%3.0f V, Energy:%3.0f %% (%3.1f%%)",Inst->Pmtv,x2 ,tol);
                '		else{ //5
                '		sprintf(line1,"PMT -%3.0f V, Abs:",Inst->Pmtv);
                '		StoreAbsAccurate(x2,str);
                '		strcat(line1,str);
                '		sprintf(str," (%3.1f %%) ",tol);
                '		strcat(line1,str);
                '	 }//5

                '	 SetText(hwnd, IDC_STATUS1,line1);

                '	 if (tol>99.5 && tol<100.5)
                '		break;

                '	 else if (tol>100.0){//6
                '		a++;
                '		if (tol>=200.0) addf = 120;
                '		if (tol>150.0) addf = 60;
                '		else if (tol>120.0) addf = 20;
                '		else  if (tol>110.0) addf = 12;
                '		else if (tol>105) addf = 5;
                '		else if (tol>103) addf = 3;
                '		else	addf =1;
                '		if(mode==HCLE|| mode==D2E|| mode == EMISSION)
                '		  pmt-=addf;
                '         Else
                '		  pmt+=addf;
                '		 Set_PMT_Bit(pmt);
                '	  } //6

                '	 else if (tol<100.0) {//7
                '		b++;
                '		if (tol<30.0) addf = 100;
                '		else if (tol<50.0) addf = 60;
                '		else if (tol<65.0) addf = 30;
                '		else if (tol<80.0) addf = 20;
                '		else if (tol<90.0) addf = 12;
                '		else if (tol<95.0) addf = 5;
                '		else if (tol<97.0) addf = 3;
                '      Else
                '		  addf = 1;
                '		if(mode==HCLE|| mode==D2E|| mode == EMISSION) 
                '       pmt+=addf;
                '		else pmt-=addf;
                '		Set_PMT_Bit(pmt);
                '	  } //7

                '	 else  { //8
                '		if(tol==100.0)
                '		  break;
                '		else { //9
                '		  c++; if(c>2)
                '		  break;
                '		 } //9
                '	  } //8

                '	 if (a>5){ //10
                '		if (b>5)  { //11
                '		  if(mode==HCLE|| mode==D2E|| mode == EMISSION) pmt-=addf;
                '		  else pmt+=addf; Set_PMT_Bit(pmt);
                '		  break;
                '		 } //11
                '		else a =0;
                '	  } //10

                '	 if (CheckMsg(hwnd, &msg)) if (WP==IDCANCEL)
                '		break;

                '	 if (Inst->Pmtv > maxpmt){ //12
                '#If REMOVE_INST_MSG Then
                '		MessageBox(hwnd," Warning Requires Greater PMT Volts ", "PMT",MB_ICONASTERISK | MB_OK);
                '#Else
                '		Gerror_message_new(" Warning Requires Greater PMT Volts ", "PMT");
                '#End If
                '		break;
                '	  } //12

                '	 if (Inst->Pmtv < (double)50 || Inst->Pmtv < (double)0) { //13
                '		Gerror_message_new(" Cannot adjust PMT less than 50 Volts ", "PMT");
                '		break;
                '	  } //13
                '	} while(1); //1
                '  DestroyWindowPeak(hwnd, NULL); 
                '  Inst->Avg = avgt;
                ' } //0
                'return TRUE;
                '}
                '//--------------------------------------------
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                ' Check when adj. zero value
                ObjFrmPmt.Show()
                ObjFrmPmt.BringToFront()
                Application.DoEvents()

                If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION _
                Or mode = EnumCalibrationMode.AABGC Or mode = EnumCalibrationMode.AA Then
                    avgt = gobjInst.Average
                    gobjInst.Average = 10

                    If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                        ObjFrmPmt.lblTitle.Text = "Setting FULL SCALE "
                        ObjFrmPmt.lblTitle.Refresh()
                    Else
                        If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                            If gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
                                ObjFrmPmt.lblTitle.Text = "Balancing Beam"
                            Else
                                ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
                            End If
                        Else
                            ObjFrmPmt.lblTitle.Text = "AUTO ZERO "
                        End If
                        ObjFrmPmt.lblTitle.Refresh()
                    End If

                    If gobjInst.PmtVoltageReference > 690 Then
                        gobjInst.PmtVoltageReference = 400
                    End If

                    If gobjInst.PmtVoltageReference < 50 Then
                        gobjInst.PmtVoltageReference = 51
                    End If
                    Application.DoEvents()
                    intPmtv = CInt(gobjInst.PmtVoltageReference * CDbl(4095.0) / CDbl(1000.0))

                    Do
                        intCounter = 0
                        Do
                            ObjFrmPmt.lblBlink.Text = "X"
                            ObjFrmPmt.lblBlink.Refresh()
                            funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew)
                            ObjFrmPmt.lblBlink.Text = ""
                            ObjFrmPmt.lblBlink.Refresh()
                            intCounter += 1
                        Loop While (intCounter < 10)

                        ' Read ADC value with filter for Ref. beam
                        funcReadADCFilter_ReferenceBeam(gobjInst.Average, chNew)
                        dblCurMode = gFuncGetADConvertedToCurMode(chNew)


                        If mode = EnumCalibrationMode.AA Or mode = EnumCalibrationMode.AABGC Then
                            ' validate the current value is nearer to given Value and exit from loop. 
                            If Math.Abs(dblCurMode - dblValue) < 0.005 Then
                                ' Set PMT into minor steps
                                funcSet_PMT_Ref_Bit(intPmtv)
                                Exit Do
                            End If
                        End If

                        Strline1 = ""
                        If dblValue <> CDbl(0.0) Then
                            dbltol = dblCurMode / dblValue * 100.0
                        Else
                            dbltol = (dblCurMode + 1.0) / (dblValue + 1.0) * 100.0
                        End If

                        ' Show the Abs. status
                        If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                            Strline1 = "PMT " & Format(gobjInst.PmtVoltageReference, "###") & " V, Energy : " & Format(dblCurMode, "###0.00") & " % (" & Format(dbltol, "0.0#") & " %)"
                        Else
                            Strline1 = "PMT " & Format(gobjInst.PmtVoltageReference, "###") & " V, Abs : " & Format(dblCurMode, "0.000") & " (" & Format(dbltol, "###0.00") & ")"
                        End If

                        ObjFrmPmt.lblMsg.Text = Strline1
                        ObjFrmPmt.lblMsg.Refresh()

                        ' Adj. the PMT interval
                        If dbltol > 99.5 And dbltol < 100.5 Then
                            Exit Do
                        ElseIf dbltol > 100.0 Then
                            intCounterA += 1
                            If dbltol >= 200.0 Then
                                addf = 120
                            End If
                            If dbltol > 150.0 Then
                                addf = 60
                            ElseIf dbltol > 120.0 Then
                                addf = 20
                            ElseIf dbltol > 110.0 Then
                                addf = 12
                            ElseIf dbltol > 105 Then
                                addf = 5
                            ElseIf dbltol > 103 Then
                                addf = 3
                            Else
                                addf = 1
                            End If
                            If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                intPmtv -= addf
                            Else
                                intPmtv += addf
                            End If
                            ' Set PMT into minor steps
                            funcSet_PMT_Ref_Bit(intPmtv)

                        ElseIf dbltol < 100.0 Then
                            intCounterB += 1
                            If dbltol < 30.0 Then
                                addf = 100
                            ElseIf dbltol < 50.0 Then
                                addf = 60
                            ElseIf dbltol < 65.0 Then
                                addf = 30
                            ElseIf dbltol < 80.0 Then
                                addf = 20
                            ElseIf dbltol < 90.0 Then
                                addf = 12
                            ElseIf dbltol < 95.0 Then
                                addf = 5
                            ElseIf dbltol < 97.0 Then
                                addf = 3
                            Else
                                addf = 1
                            End If
                            If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                intPmtv += addf
                            Else
                                intPmtv -= addf
                            End If
                            ' Set PMT into minor steps
                            funcSet_PMT_Ref_Bit(intPmtv)

                        Else
                            If dbltol = 100.0 Then
                                Exit Do
                            Else
                                intCounterC += 1
                                If (intCounterC > 2) Then
                                    Exit Do
                                End If
                            End If
                        End If
                        ' this block is use to validate contineous loop process
                        If intCounterA > 5 Then
                            If intCounterB > 5 Then
                                If mode = EnumCalibrationMode.HCLE Or mode = EnumCalibrationMode.D2E Or mode = EnumCalibrationMode.EMISSION Then
                                    intPmtv -= addf
                                Else
                                    intPmtv += addf
                                End If
                                funcSet_PMT_Ref_Bit(intPmtv)
                                Exit Do
                            Else
                                intCounterA = 0
                            End If
                        End If

                        ' User wants to terminate the job 
                        If ObjFrmPmt.mCancelProcess = True Then
                            Exit Do
                        End If

                        ' pmtv goes beyond maxpmt passed as second argument then give error message or warning
                        If gobjInst.PmtVoltageReference > dblMaxPmt Then
                            gobjMessageAdapter.ShowMessage(constRequireGreaterPMT)

                            Application.DoEvents()
                            
                            Exit Do
                        End If

                        ' pmtv goes below 50 then give error message or warning
                        If gobjInst.PmtVoltageReference < CDbl(50) Or gobjInst.PmtVoltageReference < CDbl(0) Then
                            gobjMessageAdapter.ShowMessage(constPMTLessthan50)
                            Application.DoEvents()
                            Exit Do
                        End If
                        ObjFrmPmt.Refresh()
                        ObjFrmPmt.BringToFront()
                        Application.DoEvents()
                    Loop While (1)
                    ObjFrmPmt.Close()
                    ObjFrmPmt.Dispose()
                    gobjInst.Average = avgt
                End If
            End If
            Application.DoEvents()
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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcTestLampPresence(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcTestLampPresence
        'Description            :   To test if lamp is present at turret position
        'Affected parameter     :   lblStatus1,lblStatus2,lblStatus3
        'Return                 :   True if success
        'Time/Date              :   3/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 Almost entire function is changed
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim intAvgInMV As Integer
        Dim intCounter As Integer
        Dim blnFlag As Boolean = False
        '----------------------------------------------
        '        BOOL	Test_Lamp_Presence(HWND hwnd)
        '{
        'int  	ch1;
        'BOOL	flag = FALSE;
        '	Slit_Home();
        '	Cal_Mode(HCLE);
        '	Set_PMT((double)200.0);
        '	ch1 = 0;
        '	SetText(hwnd, IDC_STATUS1,"PMT -200 V");
        '	do{
        '	  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : X  ");
        '	  ReadADCFilter();
        '	  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... :     ");
        '	  ch1++; if (ch1>10) break;
        '	} while(1);
        '	pc_delay(2000);
        '	if( GetInstrument() == AA202 ){
        '		if (ReadADCFilter()> 2090){
        '		  flag =TRUE;
        '		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : OK  ");
        '		 }
        '		else {
        '		  flag =FALSE;
        '		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : ERROR");
        '		 }
        '	}
        '	else{
        '		if (GetmV(ReadADCFilter())> 1900.0) { //2846){
        '		  flag =TRUE;
        '		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : OK  ");
        '		 }
        '		else {
        '		  flag =FALSE;
        '		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : ERROR");
        '		 }
        '	}
        '	Set_SlitWidth(0.3);
        '	pc_delay(2000);
        '	if (!flag){
        '		Inst = GetInstData();
        '		Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = -1;
        '#If REMOVE_INST_MSG Then
        '		MessageBox(hwnd,"Lamp not connected ....", "Lamp Test",MB_ICONASTERISK | MB_OK);
        '#Else
        '		Gerror_message_new("Lamp not connected ....", "Lamp Test");
        '#End If
        '		pc_delay(3000);
        '	 }
        ' return flag;
        '}
        '----------------------------------------------
        Try
            '1.	Set Slit to Home Position.
            If gFuncSlit_Home() = False Then
                Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                Call Application.DoEvents()
            End If

            '*******************************************************
            '----Added by Mangesh on 13-Apr-2007
            '*******************************************************
            '2.	If instrument type is 203D then Set Exit slit to Home position.
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                If funcExitSlit_Home() = False Then
                    Call gobjMessageAdapter.ShowMessage(constExitSlitHome)
                    Call Application.DoEvents()
                End If
            End If
            '*******************************************************

            '3.	Set HCLE calibration Mode.
            If funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
                Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
                Call Application.DoEvents()
            End If

            '4.	Set pmt as 200.0 volt.
            If funcSet_PMT(200.0) = False Then
                Call gobjMessageAdapter.ShowMessage(constPMTVolt)
                Call Application.DoEvents()
            End If

            If Not lblStatus1 Is Nothing Then
                CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -200 V"
            End If

            '5.	Read ADC Filter reading for 11 times.
            intCounter = 0
            Do
                If Not lblStatus2 Is Nothing Then
                    CType(lblStatus2, Windows.Forms.Label).Text = "Testing for Lamp Presence ... : X  "
                End If

                funcReadADCFilter(gobjInst.Average, intAvgInMV)

                If Not lblStatus2 Is Nothing Then
                    CType(lblStatus2, Windows.Forms.Label).Text = "Testing for Lamp Presence ... :    "
                End If

                intCounter += 1
                If intCounter > 10 Then
                    Exit Do
                End If
            Loop While (1)

            mobjCommdll.subTime_Delay(10)
            '6.	Read ADC Filter reading once more.
            funcReadADCFilter(gobjInst.Average, intAvgInMV)
            'if( GetInstrument() == AA202 ){
            '		if (ReadADCFilter()> 2090){
            '		  flag =TRUE;
            '		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : OK  ");
            '		 }
            '		else {
            '		  flag =FALSE;
            '		  SetText(hwnd, IDC_STATUS1,"Testing for Lamp Presence ... : ERROR");
            '		 }
            '	}

            '7.	If instrument type is 201 and ADC filter reading is more than 2090 then declare 
            'lamp presence OK. If ADC filter reading is less than 2090 then Declare lamp presence Error.

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                If intAvgInMV > 2090 Then
                    blnFlag = True
                    If Not lblStatus2 Is Nothing Then
                        CType(lblStatus2, Windows.Forms.Label).Text = "Testing for Lamp Presence ... : OK  "
                    End If
                Else
                    blnFlag = False
                    If Not lblStatus2 Is Nothing Then
                        CType(lblStatus2, Windows.Forms.Label).Text = "Testing for Lamp Presence ... : ERROR"
                    End If
                End If
            Else
                '8.	If instrument type is 203/203D then convert ADC filter reading to 
                'millivolt. If ADC filter reading converted to millivolt is more than 1900 then 
                'Declare lamp presence OK. If ADC filter reading converted to millivolt is less 
                'than 1900 then Declare lamp presence Error.
                If gFuncGetmv(intAvgInMV) > 1900.0 Then
                    blnFlag = True
                    If Not lblStatus2 Is Nothing Then
                        CType(lblStatus2, Windows.Forms.Label).Text = "Testing for Lamp Presence ... : OK  "
                    End If
                Else
                    blnFlag = False
                    If Not lblStatus2 Is Nothing Then
                        CType(lblStatus2, Windows.Forms.Label).Text = "Testing for Lamp Presence ... : ERROR"
                    End If
                End If
            End If

            '*******************************************************
            '----Added by Mangesh on 13-Apr-2007
            '*******************************************************

            '9.	If instrument type is 203D then position both slits to 0.5 nm. 
            'Else position entry slit to 0.3.

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                'If funcSet_SlitWidth(0.5, enumInstrumentBeamType.DoubleBeam) = False Then
                If funcSet_SlitWidth(0.5, 2) = False Then
                    Call gobjMessageAdapter.ShowMessage(constSlitWidthError)
                    Call Application.DoEvents()
                End If
            Else
                If funcSet_SlitWidth(0.3) = False Then
                    Call gobjMessageAdapter.ShowMessage(constSlitWidthError)
                    Call Application.DoEvents()
                End If
            End If

            'mobjCommdll.subTime_Delay(2000)

            If blnFlag = False Then
                gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition = -1
                'MessageBox.Show("Lamp not connected ....", "Lamp Test")
                gobjMessageAdapter.ShowMessage(constLampNotConnected)
                Application.DoEvents()
                'mobjCommdll.subTime_Delay(3000)
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_Lamp(ByVal blnFlag As Boolean, ByVal dblLampCurrent As Double, ByVal intLampPos As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_Lamp
        'Description            :   To set current to the lamp
        'Parameters             :   flag = if true set current else not set current
        '                           dblLampCurrent = current to be set to lamp
        '                           intLampPos = lamp position to which current to be set
        'Return                 :   True if success
        'Time/Date              :   29/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor

        Try

            ' init Set all lamp current is off
            If funcAll_Lamp_Off() Then
                If blnFlag = True Then
                    '--take lamp current from inst parameters and set it
                    If funcSet_HCL_Cur(dblLampCurrent, intLampPos) Then
                        funcSet_Lamp = True
                    Else
                        funcSet_Lamp = False
                    End If
                Else
                    funcSet_Lamp = True
                End If

            Else
                funcSet_Lamp = False
            End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_Lamp(ByVal blnFlag As Boolean) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_Lamp
        'Description            :   To set current to the lamp
        'Parameters             :   flag = if true set current else not set current
        'Return                 :   True if success
        'Time/Date              :   29/9/06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        '           E4FUNC  void	S4FUNC 	Set_lamp(BOOL flag)
        '{
        'double lmp_cur=0.0;
        ' CheckInst();
        ' All_Lamp_Off();
        ' if (flag){
        '	lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
        '	Set_HCL_Cur(lmp_cur,Inst->Lamp_pos);
        '	if (Inst->Lamp_warm>0) {
        '	  lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_warm-1].cur;
        '	  Set_HCL_Cur(lmp_cur,Inst->Lamp_warm);
        '	 }
        '  }

        '}
        Dim objWait As New CWaitCursor
        Dim dbllmp_cur As Double = 0.0

        Try
            ' init Set all lamp current is off
            If funcAll_Lamp_Off() Then
                If blnFlag = True Then
                    'lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
                    ' Get current of set lamp position from Inst object which is store into lamp parameter collection
                    dbllmp_cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Current
                    'gobjInst.Lamp.LampParametersCollection()
                    '--take lamp current from inst parameters and set it
                    Call funcSet_HCL_Cur(dbllmp_cur, gobjInst.Lamp_Position)
                    'if (Inst->Lamp_warm>0) {
                    'lmp_cur = Inst->Lamp_par.lamp[Inst->Lamp_warm-1].cur;
                    'Set_HCL_Cur(lmp_cur,Inst->Lamp_warm);
                    '}
                    'set the Current of warmup lamp from Inst lamp collection object
                    If (gobjInst.Lamp_Warm > 0) Then
                        dbllmp_cur = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Warm - 1).Current
                        If funcSet_HCL_Cur(dbllmp_cur, gobjInst.Lamp_Warm) Then
                            funcSet_Lamp = True
                        End If
                    End If
                End If
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_HCL_Cur(ByVal dblLampCur As Double, ByVal intLampPos As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_HCL_Cur
        'Description            :   To set current to the lamp
        'Parameters             :   dblLampCur = current to be set to lamp
        '                           intLampPos = lamp position to which current to be set
        'Return                 :   True if success.
        'Time/Date              :   29/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 23.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        '--------------
        '        void S4FUNC Set_HCL_Cur(double cur , BYTE pos)
        '{
        'BYTE	a;

        ' Inst.Cur = cur;
        ' a = (BYTE) (cur*(double)10.0);
        ' if(GetInstrument() == AA202 ){
        '	pos = pos-1;
        '            If (pos < 0) Then
        '		pos = 0;
        ' }
        ' Transmit(HCLCUR, a, pos, 0);
        '#If NEWHANDSHAKE Then
        ' Recev(TRUE);
        '#End If
        '}
        '--------------
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            'gobjInst.Current = dblLampCur  '10.12.07

            bytLow = CByte(dblLampCur * CDbl(10.0))

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                intLampPos = intLampPos - 1
                If (intLampPos < 0) Then
                    intLampPos = 0
                End If
            End If

            '
            bytHigh = CByte(intLampPos)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send Command EnumTARHCLK (17), with Low byte , High byte parameter of Lamp current
            If FuncTransmitCommand(EnumAAS203Protocol.HCLCUR, bytLow, bytHigh, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcSet_HCL_Cur = False
                        gobjMessageAdapter.ShowMessage(constSetHCLCurError)
                        Application.DoEvents()
                    Else
                        gobjInst.Current = dblLampCur
                        funcSet_HCL_Cur = True
                    End If
                Else
                    funcSet_HCL_Cur = False
                    gobjMessageAdapter.ShowMessage(constSetHCLCurError)
                    Application.DoEvents()
                End If
            Else
                funcSet_HCL_Cur = False
                'gobjMessageAdapter.ShowMessage(constSetHCLCurError)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcFind_Wavelength_Home() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcFind_Wavelength_Home
        'Description            :   To find Home wavelength position
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   25/9/06
        'Dependencies           :   PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 18.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        '------------
        'BOOL    S4FUNC Find_Wavelength_Home(HDC hdc, int x, int y)
        '{
        'unsigned  ch, oldTout;
        'int       i, j;
        'BYTE		oParam1;

        ' Inst.Wvcur = Get_Cur_Wv();
        ' oldTout=Tout;
        ' Tout=LONG_DEALY;
        ' hold = Load_Curs();
        ' Transmit(WVHOME, 0, 0, 0);
        '  if (Recev(TRUE)&& Param1==1){
        '	 do{
        '                If (!Recev(True)) Then
        '		  break;
        '		ch = Param2*256+Param1;
        '                    If (hdc! = NULL) Then
        '		 Wprintf(hdc,x, y, "%5.2f nm  ",ch/StepPerNm);
        '                        If (ch < StepPerNm) Then
        '		  break;
        '	  } while(1);
        '	}
        ' Tout=VERY_LONG_DEALY ; 
        ' do {
        '                                If (!Recev(True)) Then
        '	  break;
        '	if (Param1==6 || Param1==5) {
        '	  Beep();
        '	  Beep();
        '	  continue;
        '	 }
        '                                    Else
        '	 break;
        '  } while(1);
        ' Tout =oldTout;
        ' SetCursor(hold);
        ' switch(Param1)  {
        '	case 1:  Inst.Wvcur = 0; break;
        '	case 2: Gerror_message(" Monochromator error \n MECH.HOME Sensor");
        '				break;
        '	case 3: Gerror_message(" Monochromator error \n Opto (COURSE Sensor)");
        '				break;
        '	case 4: Gerror_message(" Monochromator error \n Opto (FINE  Sensor  )");
        '				break;
        '	}
        ' oParam1=Param1;
        'if( GetInstrument() != AA202 ){
        ' if (Inst.Lamp_par.wvzero != 100.0 && Param1==1)  {
        '	j = (int) (Inst.Lamp_par.wvzero*(double)StepPerNm);
        '	if (j<0) j= -j;
        '	if (Inst.Lamp_par.wvzero<0){
        '		for (i= 1; i<=j+StepPerNm; i++) {
        '		  Rotate_Anticlock_Wv();
        '		  pc_delay(200);
        '		 }
        '		for (i= 1; i<=StepPerNm; i++) {
        '		  Rotate_Clock_Wv();
        '		  pc_delay(200);
        '		 }
        '	 }
        '	else  for (i= 1; i<=j; i++) {
        '		Rotate_Clock_Wv();
        '		pc_delay(200);
        '	  }
        '}
        '	Inst.Wvcur= Get_Cur_Wv();
        '	Inst.Wvcur = 0;
        '	Set_Cur_Wv();
        '#If DEMO Then
        '	wvcur=0;
        '#End If
        '  }
        ' if (oParam1==1) return TRUE;
        ' else return FALSE;
        '}
        '------------
        Try
            If gFuncWavelength_Home() Then
                Return True
            Else
                Return False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcRotate_Anticlock_Wv() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcRotate_Anticlock_Wv
        'Description            :   To Rotate turret Anticlockwise. Here turret rotates by only one step        
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   28/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send Command EnumWVANTI (21), with 0 parameter
            If FuncTransmitCommand(EnumAAS203Protocol.WVANTI, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constRotateWvAntiClkError)
                        Application.DoEvents()
                        funcRotate_Anticlock_Wv = False
                    Else
                        'mobjCommdll.subTime_Delay(200)
                        ' Rotate the Anti Clock wise wavelength with one step
                        funcRotate_Anticlock_Wv = True
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(constRotateWvAntiClkError)
                    Application.DoEvents()
                    funcRotate_Anticlock_Wv = False
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constRotateWvAntiClkError)
                'Application.DoEvents()
                funcRotate_Anticlock_Wv = False
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcRotate_Clock_Wv() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcRotate_Clock_Tur
        'Description            :   To Rotate turret clockwise. Here turret rotates by only one step        
        'Parameters             :   None
        'Return                 :   True if succsess
        'Time/Date              :   28/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send Command EnumWVCLK (20), with 0 parameter
            If FuncTransmitCommand(EnumAAS203Protocol.WVCLK, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constRotateWvClkError)
                        Application.DoEvents()
                        funcRotate_Clock_Wv = False
                    Else
                        ' Rotate the Clock wise wavelength with one step
                        funcRotate_Clock_Wv = True
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(constRotateWvClkError)
                    Application.DoEvents()
                    funcRotate_Clock_Wv = False
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constRotateWvClkError)
                'Application.DoEvents()
                funcRotate_Clock_Wv = False
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGet_Current_Wv(ByRef dblCurWv As Double) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcGet_Current_Wv
        'Description            :   To get the current wavelength
        'Parameters             :   [OUT]dblCurWv : returns current wavelength in this variable
        'Return                 :   True if success
        'Time/Date              :   29/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 21.11.06
        '--------------------------------------------------------------------------------------

        '-------------------------------------------------------
        'double S4FUNC Get_Cur_Wv()
        '{
        '   double    x=0;
        '   #If DEMO Then
        '	    x = Inst.Wvcur = wvcur;
        '	    return x;
        '   #Else
        '       unsigned ch;
        '       int      ch1;
        '       Transmit(GETCURWV, 0, 0, 0);
        '       if (Recev(TRUE)){
        '           ch = Param2 *256 + Param1;
        '	        if (ch > 50000u) {
        '	            ch1 = ch;
        '	            x = (double) (ch1/StepPerNm);
        '	        }
        '           Else
        '	            x = (double) (ch/StepPerNm);
        '	    Inst.Wvcur = x;
        '       }
        '       return x;
        '   #End If
        '}
        '-------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim uintCurWv As UInt32
        Dim intCurWv As Int32
        Dim dblTempCurrWv As Double = 0

        Try
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send the Commnad to get the cuurent Wv
            If FuncTransmitCommand(EnumAAS203Protocol.GETCURWV, 0, 0, 0) Then
                'mobjCommdll.subTime_Delay(500)
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constGetCurWvError)
                        Application.DoEvents()
                        funcGet_Current_Wv = False
                    Else
                        'store byte array (3) and byte array (2) into unsign integer
                        uintCurWv = Convert.ToUInt32((bytArray(3) * 256) + bytArray(2))

                        'if (ch > 50000u) {
                        '	ch1 = ch;
                        '	x = (double) (ch1/StepPerNm);
                        '}
                        'Else
                        '   x = (double) (ch/StepPerNm);
                        ' check Unsign integere of 50000 integer value with greater than 0
                        If uintCurWv.CompareTo(UInt32.Parse(50000)) > 0 Then
                            intCurWv = Convert.ToInt32(uintCurWv) - 65536

                            '***************************************************
                            '---Added by Mangesh on 12-Apr-2007 for AA201
                            '***************************************************
                            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                dblTempCurrWv = CDbl(intCurWv / CONST_STEPS_PER_NM_AA201)
                                '***************************************************
                            Else
                                dblTempCurrWv = CDbl(intCurWv / CONST_STEPS_PER_NM)
                            End If

                        Else
                            '//----- Added by Sachin Dokhale on 29.12.06
                            '//----- Store uintCurWv into intcurWv
                            intCurWv = Convert.ToInt32(uintCurWv)

                            '***************************************************
                            '---Added by Mangesh on 12-Apr-2007 for AA201
                            '***************************************************
                            ' intCurWv is total nmo steps so diveide to total no. steps for per NM
                            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                dblTempCurrWv = CDbl(intCurWv / CONST_STEPS_PER_NM_AA201)
                                '***************************************************
                            Else
                                dblTempCurrWv = CDbl(intCurWv / CONST_STEPS_PER_NM)
                            End If

                        End If

                        dblCurWv = dblTempCurrWv
                        funcGet_Current_Wv = True
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(constGetCurWvError)
                    'Application.DoEvents()
                    'Return False
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constGetCurWvError)
                'Application.DoEvents()
                'Return False
            End If

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
            gblnInComm = False
            'objWait.Dispose()
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_Current_Wv(ByRef dblCurWv As Double) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_Current_Wv
        'Description            :   To Set the current wavelength
        'Parameters             :   [OUT]dblCurWv : returns current wavelength in this variable
        'Return                 :   True if success
        'Time/Date              :   29/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 21.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        'Dim uintCurWv As Short
        Dim intCurWv As Integer
        '------------------------------------------------
        '        void   S4FUNC Set_Cur_Wv()
        '{
        'double    x;
        'unsigned i;
        'BYTE     data, data1;
        ' x = Inst.Wvcur*(double)StepPerNm;
        '  i =(unsigned) x;
        '  data =(BYTE) i;
        '  i=i>>8;
        '  data1 =(BYTE) i;
        ' Transmit(SETWV, data, data1, 0);
        ' Recev(TRUE);
        '  Get_Cur_Wv();
        '}

        '------------------------------------------------
        'Dim intX, intI As Integer
        Dim dblX As Double
        Dim intI As UInt32
        Dim data, data1 As Byte

        Try
            '***************************************************
            '---Added by Mangesh on 12-Apr-2007 for AA201
            '***************************************************
            ' dblX is Total no of steps 
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                dblX = dblCurWv * CONST_STEPS_PER_NM_AA201
                '***************************************************
            Else
                dblX = dblCurWv * CONST_STEPS_PER_NM
            End If
            ' convert dblX to Unsign integer intI
            intI = UInt32.Parse(dblX.ToString)
            ' Convrt unsign integer iniI into high byte and low byte
            data = CByte(Convert.ToInt32(intI))
            intI = UInt32.Parse(CStr(Convert.ToInt32(intI.ToString) >> 8))
            data1 = CByte(Convert.ToInt32(intI))

            'intI = CInt(intX)
            'bytLow = CByte(intI)
            'intI = CByte(intI >> 8)
            'bytHigh = CByte(intI)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.SETWV, data, data1, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constSetCurWvError)
                        Application.DoEvents()
                        funcSet_Current_Wv = False
                    Else
                        gblnInComm = False
                        'after to set Wv get current Wv. 
                        If funcGet_Current_Wv(dblCurWv) Then
                            funcSet_Current_Wv = True
                        Else
                            gobjMessageAdapter.ShowMessage(constGetCurWvError)
                            Application.DoEvents()
                            funcSet_Current_Wv = False
                        End If
                    End If
                Else
                    gobjMessageAdapter.ShowMessage(constSetCurWvError)
                    Application.DoEvents()
                    funcSet_Current_Wv = False
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constSetCurWvError)
                'Application.DoEvents()
                funcSet_Current_Wv = False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncWavelength_Home(Optional ByRef lblUVWavelengthStatus As Windows.Forms.Label = Nothing) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncWavelength_Home
        'Description            :   To make the Wavelength indicater home        
        'Parameters             :   None
        'Affected Parameter     :   lblUVWavelengthStatus as Form Label
        'Return                 :   True if success
        'Time/Date              :   26.11.06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 13.1.07
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim intWv As Integer
        Dim BParam2 As Byte
        Dim intJ As Integer
        Dim intCount As Integer
        Dim dblWV As Double

        '------------
        'BOOL    S4FUNC Find_Wavelength_Home(HDC hdc, int x, int y)
        '{
        'unsigned  ch, oldTout;
        'int       i, j;
        'BYTE		oParam1;

        ' Inst.Wvcur = Get_Cur_Wv();
        ' oldTout=Tout;
        ' Tout=LONG_DEALY;
        ' hold = Load_Curs();
        ' Transmit(WVHOME, 0, 0, 0);
        '  if (Recev(TRUE)&& Param1==1){ //1
        '	 do{ //2
        '                If (!Recev(True)) Then
        '		  break;
        '		ch = Param2*256+Param1;
        '                    If (hdc! = NULL) Then
        '		 Wprintf(hdc,x, y, "%5.2f nm  ",ch/StepPerNm);
        '                        If (ch < StepPerNm) Then
        '		  break;
        '	  } while(1);//2
        '	}//1
        ' Tout=VERY_LONG_DEALY ; 
        ' do {//3
        '                                If (!Recev(True)) Then
        '	  break;
        '	if (Param1==6 || Param1==5) {//4
        '	  Beep();
        '	  Beep();
        '	  continue;
        '	 }//4
        '                                    Else
        '	 break;
        '  } while(1);//3
        ' Tout =oldTout;
        ' SetCursor(hold);
        ' switch(Param1)  {//5
        '	case 1:  Inst.Wvcur = 0; break;
        '	case 2: Gerror_message(" Monochromator error \n MECH.HOME Sensor");
        '				break;
        '	case 3: Gerror_message(" Monochromator error \n Opto (COURSE Sensor)");
        '				break;
        '	case 4: Gerror_message(" Monochromator error \n Opto (FINE  Sensor  )");
        '				break;
        '	}//5
        ' oParam1=Param1;
        'if( GetInstrument() != AA202 ){//6
        ' if (Inst.Lamp_par.wvzero != 100.0 && Param1==1)  {//7
        '	j = (int) (Inst.Lamp_par.wvzero*(double)StepPerNm);
        '	if (j<0) j= -j;
        '	if (Inst.Lamp_par.wvzero<0){ //8
        '		for (i= 1; i<=j+StepPerNm; i++) {//9
        '		  Rotate_Anticlock_Wv();
        '		  pc_delay(200);
        '		 }//9
        '		for (i= 1; i<=StepPerNm; i++) {//10
        '		  Rotate_Clock_Wv();
        '		  pc_delay(200);
        '		 }//10
        '	 }//8
        '	else  for (i= 1; i<=j; i++) {//11
        '		Rotate_Clock_Wv();
        '		pc_delay(200);
        '	  }//11
        '}//7
        '	Inst.Wvcur= Get_Cur_Wv();
        '	Inst.Wvcur = 0;
        '	Set_Cur_Wv();
        '#If DEMO Then
        '	wvcur=0;
        '#End If
        '  }//6
        ' if (oParam1==1) return TRUE;
        ' else return FALSE;
        '}
        '------------
        Try
            'before set Wv. Home command Get the current Wv. position
            If funcGet_Current_Wv(gobjInst.WavelengthCur) = True Then
                '' gblnInComm = True          '10.12.07
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                ' Send Wv. Mode Command WVHOME (11)
                If FuncTransmitCommand(EnumAAS203Protocol.WVHOME, 0, 0, 0) = True Then
                    If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) = True And bytArray(2) = 1 Then
                        Do
                            If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) = False Then
                                Exit Do
                            End If

                            intWv = (bytArray(3) * 256) + bytArray(2)

                            '***************************************************
                            '---Added by Mangesh on 12-Apr-2007 for AA201
                            '***************************************************
                            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                If Not IsNothing(lblUVWavelengthStatus) Then
                                    lblUVWavelengthStatus.Text = "Wavelength (nm): " & FormatNumber((intWv / CONST_STEPS_PER_NM_AA201), 2)
                                    lblUVWavelengthStatus.Refresh()
                                End If
                                If intWv < CONST_STEPS_PER_NM_AA201 Then
                                    Exit Do
                                End If
                                '***************************************************
                            Else
                                If Not IsNothing(lblUVWavelengthStatus) Then
                                    lblUVWavelengthStatus.Text = "Wavelength (nm): " & FormatNumber((intWv / CONST_STEPS_PER_NM), 2)
                                    lblUVWavelengthStatus.Refresh()
                                End If
                                If intWv < CONST_STEPS_PER_NM Then
                                    Exit Do
                                End If
                            End If

                        Loop While (1)

                    End If

                    Do
                        If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) = False Then
                            Exit Do
                        End If
                        If bytArray(2) = EnumErrorMessage.SHOME_ERROR Or bytArray(2) = EnumErrorMessage.COMM_ERROR Then
                            Beep()
                            Beep()
                            GoTo EndOfLoop
                        Else
                            Exit Do
                        End If
EndOfLoop:          Loop While (1)

                    Select Case bytArray(2)
                        Case EnumErrorMessage.NO_ERROR
                            gobjInst.WavelengthCur = 0
                            Exit Select
                        Case EnumErrorMessage.LOBYTE_ERROR
                            gobjMessageAdapter.ShowMessage(constMechWVHomeError)
                            Application.DoEvents()
                            Exit Select
                        Case EnumErrorMessage.COARSEHOME_ERROR
                            gobjMessageAdapter.ShowMessage(constCoarseWVHomeError)
                            Application.DoEvents()
                            Exit Select
                        Case EnumErrorMessage.FINEHOME_ERROR
                            gobjMessageAdapter.ShowMessage(constFineWVHomeError)
                            Application.DoEvents()
                            Exit Select
                    End Select

                    BParam2 = bytArray(2)

                    If gobjInst.Lamp.WavelengthZero <> 100.0 And bytArray(2) = 1 Then
                        Call Application.DoEvents()

                        '***************************************************
                        '---Added by Mangesh on 12-Apr-2007 for AA201
                        '***************************************************
                        If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                            intJ = CInt(gobjInst.Lamp.WavelengthZero * CONST_STEPS_PER_NM_AA201)
                        Else
                            intJ = CInt(gobjInst.Lamp.WavelengthZero * CONST_STEPS_PER_NM)
                        End If
                        '***************************************************

                        If intJ < 0 Then
                            intJ = -intJ
                        End If

                        If gobjInst.Lamp.WavelengthZero < 0 Then
                            '***************************************************
                            '---Changed and Added by Mangesh on 12-Apr-2007 for AA201
                            '***************************************************
                            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                                For intCount = 1 To intJ + CONST_STEPS_PER_NM_AA201
                                    Call funcRotate_Anticlock_Wv()
                                Next
                                For intCount = 1 To CONST_STEPS_PER_NM_AA201
                                    Call funcRotate_Clock_Wv()
                                Next
                            Else
                                For intCount = 1 To intJ + CONST_STEPS_PER_NM
                                    Call funcRotate_Anticlock_Wv()
                                Next
                                For intCount = 1 To CONST_STEPS_PER_NM
                                    Call funcRotate_Clock_Wv()
                                Next
                            End If
                            '***************************************************

                        Else
                            For intCount = 1 To intJ
                                Call funcRotate_Clock_Wv()
                            Next
                        End If
                    End If

                    If funcGet_Current_Wv(gobjInst.WavelengthCur) = True Then
                        gobjInst.WavelengthCur = 0
                        funcSet_Current_Wv(gobjInst.WavelengthCur)
                    End If

                    If BParam2 = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(constWVHomeError)
                    'Application.DoEvents()
                    gFuncWavelength_Home = False
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constGetCurWvError)
                'Application.DoEvents()
                gFuncWavelength_Home = False
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncSlit_Home() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncSlit_Home
        'Description            :   To make the Slit indicater home        
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   25/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 as some part of code was left behind by rahul
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim intErrorSlitHome As Integer
        Try
            'send the Slit Home Command
            'SLITHOME (14)
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                intErrorSlitHome = constErrorSlitHome
            Else
                intErrorSlitHome = constErrorEntrySlitHome
            End If
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.SLITHOME, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gFuncSlit_Home = False
                        'gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                        gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                    Else
                        'when byte array (2) is not 0 then set slit position is set to 0
                        If bytArray(2) Then
                            gobjInst.SlitPosition = 0
                            Return True
                        Else
                            'gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                            gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                        End If
                        'If bytArray(2) Then
                        'Return True
                        'End If
                    End If
                Else
                    gFuncSlit_Home = False
                    'gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                    gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                    'gFuncShowMessage("Error...", "Error setting Slit Home.", EnumMessageType.Information)
                End If
            Else
                gFuncSlit_Home = False
                'gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                'gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                'gFuncShowMessage("Error...", "Error setting Slit Home.", EnumMessageType.Information)
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    'Public Function funcSet_SlitWidth(ByVal dblSlitWidth As Double, Optional ByVal intInstrumentBeamTypeIn As enumInstrumentBeamType = enumInstrumentBeamType.SingleBeam) As Boolean
    '    '-----------------------------------  Procedure Header  -------------------------------
    '    'Procedure Name         :   funcSet_SlitWidth
    '    'Description            :   To set the slit width
    '    'Parameters             :   dblSlitWidth : width for slit to be set
    '    'Time/Date              :   28/9/06
    '    'Dependencies           :   obviously PC must communicate with Instrument through COM port
    '    'Author                 :   Rahul B.
    '    'Revision               :
    '    'Revision by Person     :   Deepak B. on 17.11.06
    '    '--------------------------------------------------------------------------------------
    '    Dim objWait As New CWaitCursor
    '    Dim dblS1 As Double = 0.0
    '    Dim intSlit As Integer
    '    Dim blnIsSlitWidthSet As Boolean
    '    '--------------------
    '    '        void   S4FUNC Set_SlitWidth(double sw)
    '    '{
    '    'double s1=0;
    '    'int slit;
    '    '  s1 = sw* (double) 40.0;
    '    '  slit = (int)s1 ;
    '    '  slit=80-slit;
    '    '  Position_Slit(slit);
    '    '}
    '    '--------------------
    '    Try
    '        dblS1 = dblSlitWidth * CDbl(40.0)
    '        intSlit = CInt(dblS1)
    '        intSlit = 80 - intSlit

    '        Select Case intInstrumentBeamTypeIn

    '            Case enumInstrumentBeamType.SingleBeam
    '                If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
    '                    '---For 203D instrument in single beam Mode 
    '                    '---operate both entry & exit slits
    '                    blnIsSlitWidthSet = funcPosition_Slit_EntryExit(intSlit)

    '                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
    '                    '---For 203 instrument in single beam Mode 
    '                    '---operate only entry slit
    '                    blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit)

    '                ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
    '                    '---For 202 instrument in single beam Mode 
    '                    blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit)

    '                End If

    '            Case enumInstrumentBeamType.ReferenceBeam
    '                blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit)

    '            Case enumInstrumentBeamType.DoubleBeam
    '                blnIsSlitWidthSet = funcPosition_Slit_EntryExit(intSlit)

    '        End Select

    '        If blnIsSlitWidthSet Then
    '            Return True
    '        Else
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objWait.Dispose()
    '        Application.DoEvents()
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    Public Function funcSet_SlitWidth(ByVal dblSlitWidth As Double, Optional ByVal intSlitType As Integer = 0) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_SlitWidth
        'Description            :   To set the slit width
        'Parameters             :   intSlitType : width for slit to be set
        'Return                 :   True if success
        'Time/Date              :   08.04.07
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim dblS1 As Double = 0.0
        Dim intSlit As Integer
        Dim blnIsSlitWidthSet As Boolean
        '--------------------
        '        void   S4FUNC Set_SlitWidth(double sw)
        '{
        'double s1=0;
        'int slit;
        '  s1 = sw* (double) 40.0;
        '  slit = (int)s1 ;
        '  slit=80-slit;
        '  Position_Slit(slit);
        '}
        '--------------------
        Try
            dblS1 = dblSlitWidth * CDbl(40.0)
            intSlit = CInt(dblS1)
            intSlit = 80 - intSlit

            'intSlitType int variable is use for 203D whe it is set 
            If intSlitType = 1 Then
                '---For 203 instrument in single beam Mode 
                blnIsSlitWidthSet = funcPosition_Slit_Exit(intSlit)

            ElseIf intSlitType = 2 Then
                '---For 203D instrument in single beam Mode 
                '---operate only Entry and Exit slit
                blnIsSlitWidthSet = funcPosition_Slit_EntryExit(intSlit)
            Else
                '---For 203 instrument in single beam Mode 
                '---operate only entry slit
                blnIsSlitWidthSet = funcPosition_Slit_Entry(intSlit)
            End If

            If blnIsSlitWidthSet Then
                Return True
            Else
                Return False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPosition_Slit_Entry(ByVal intSlit As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcPosition_Slit_Entry
        'Description            :   To position the slit at the said width
        'Parameters             :   intSlit : position at which slit to be adjusted
        'Return                 :   True if Success
        'Time/Date              :   28/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytSlitWidth1 As Byte
        Dim intSlitWidthError As Integer
        '------------------------
        '        void   S4FUNC Position_Slit(int sw)
        '{
        'BYTE  sw1;
        'hold = Load_Curs();
        ' if (Inst.Slitpos!=sw) {
        '	 sw1 = (BYTE) sw;
        '	 Transmit(SLITPOS, sw1, 0 , 0);
        '	 Inst.Slitpos =sw;
        '	 Recev(TRUE);
        ' }
        'SetCursor(hold);
        '}
        '------------------------
        Try

            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                intSlitWidthError = constSlitWidthError
            Else
                intSlitWidthError = constEntrySlitWidthError
            End If

            ' use new Slit position is not = with  Inst object Lsit position
            If gobjInst.SlitPosition <> intSlit Then
                bytSlitWidth1 = CByte(intSlit)
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'send command for slit position SLITPOS(15)
                If FuncTransmitCommand(EnumAAS203Protocol.SLITPOS, bytSlitWidth1, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            gobjMessageAdapter.ShowMessage(intSlitWidthError)
                            Application.DoEvents()
                            Return False
                        Else
                            'Set the slit postion to Inst object when byte array(1) is 1
                            gobjInst.SlitPosition = intSlit
                            Return True
                        End If
                    Else
                        gobjMessageAdapter.ShowMessage(intSlitWidthError)
                        Application.DoEvents()
                        Return False
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(intSlitWidthError)
                    'Application.DoEvents()
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
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncPneumatics() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncPneumatics
        'Description            :   To check pneumatics like Burner parameters and pressure sensors        
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   25/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        '                           and one more thing is that if we wont wait for 10 sec in slit home 
        '                           it returns error code... GOD knows why this happens
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     : deepak b on 16.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bData As Byte
        Dim ps1, ps2, ps3, aa As Boolean
        Dim flag As Boolean = True
        Dim intCount As Integer = 0

        Try
            'funcSetBH_HOME()
            'If funcSetNV_HOME() Then
            '    If funcCheckBurnerParameters() Then
            'If funcPressSensorStatus() Then
            '    gFuncPneumatics = True
            'Else
            '    gFuncPneumatics = False
            'End If
            '    Else
            '        gFuncPneumatics = False
            '    End If
            'Else
            '    gFuncPneumatics = False
            'End If

            ' Set Burner height position to home position
            Call funcSetBH_HOME()
            'Set Needle Valve Position to Home position
            If funcSetNV_HOME() Then
                Do
                    'ps1 is use for Air pressure
                    'ps2 is use for N2O pressure
                    'ps3 is use for FUEL pressure
                    ps1 = True
                    ps2 = True
                    ps3 = True
                    flag = True

                    'bData ref.  parameter in byte for Burner parameter whether AA bur. or N2O
                    funcCheckBurnerParameters(bData)
                    'if AA Bur is conneted the set aa to true
                    If (bData And EnumErrorStatus.AA_CONNECTED) Then
                        aa = True
                    Else
                        aa = False
                    End If
                    ' bData ref.  parameter in byte for pressure sensor status
                    If funcPressSensorStatus(bData) Then
                        'check byte param. and AIR_NOK (128)
                        If (bData And EnumErrorStatus.AIR_NOK) Then
                            ps1 = False
                        End If
                        'check byte param. and N2O_NOK (64)
                        If (bData And EnumErrorStatus.N2O_NOK) Then
                            ps2 = False
                        End If
                        'check byte param. and FUEL_NOK(32)
                        If (bData And EnumErrorStatus.FUEL_NOK) Then
                            ps3 = False
                        End If

                        If ps1 = False Then
                            gobjMessageAdapter.ShowMessage(constLowAirPressureRetry)
                            Application.DoEvents()
                            flag = False
                        End If

                        If aa = False And ps2 = False Then
                            gobjMessageAdapter.ShowMessage(constLowNitrousPressureRetry)
                            Application.DoEvents()
                            flag = False
                        End If
                        If ps3 = False Then
                            gobjMessageAdapter.ShowMessage(constLowFuelPressureRetry)
                            Application.DoEvents()
                            flag = False
                        End If
                        intCount += 1
                    End If

                Loop While (flag = False And intCount < 2)
                'loop untill senssor flag is not set and untill loop count is less than 2  
                Return flag
            Else
                gFuncPneumatics = False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcCheckBurnerParameters(ByRef bdata As Byte, Optional ByVal blnShowErrorMessages As Boolean = True) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcCheckBurnerParameters
        'Description            :   To check Burner parameters
        'Parameters             :   bdata as byte, blnShowErrorMessages as bool 
        'Return                 :   True if success
        'Time/Date              :  16.11.06 
        'Dependencies           :   
        'Author                 :   Deepak
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'check Burner parameters for AA bur. or N2O Bur. 
            If FuncTransmitCommand(EnumAAS203Protocol.CHKBURNER, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        'Return False
                        If blnShowErrorMessages = True Then
                            gobjMessageAdapter.ShowMessage(constBurnerCheckError)
                            Application.DoEvents()
                        End If
                        Return False
                    Else
                        'return value of array of byte from received block
                        bdata = bytArray(2)
                        Return True
                    End If
                Else
                    Return False
                    'If blnShowErrorMessages = True Then
                    '    gobjMessageAdapter.ShowMessage(constBurnerCheckError)
                    '    Application.DoEvents()
                    'End If
                End If
            Else
                Return False
                'If blnShowErrorMessages = True Then
                '    'gobjMessageAdapter.ShowMessage(constBurnerCheckError)
                '    Application.DoEvents()
                'End If
            End If

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPressSensorStatus(ByRef bData As Byte, Optional ByVal blnShowErrorMessages As Boolean = True) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcPressSensorStatus
        'Description            :   To check pressure sensors for AIR, N2O, Fuel etc.
        'Parameters             :   bdata as byte, blnShowErrorMessages as bool to show message of not
        'Return                 :   True if success
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'check pressure sensor parameters  
            If FuncTransmitCommand(EnumAAS203Protocol.PSSTATUS, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    'return value of array of byte from received block
                    bData = bytArray(2)
                    If bytArray(1) = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    If blnShowErrorMessages = True Then
                        gobjMessageAdapter.ShowMessage(constPressureSensorError)
                        Application.DoEvents()
                    End If
                    Return False
                End If
            Else
                'If blnShowErrorMessages = True Then
                '    gobjMessageAdapter.ShowMessage(constLowFuelPressure)
                '    Application.DoEvents()
                'End If
                Return False
            End If

        Catch threadex As Threading.ThreadAbortException
            '---Do Nothing
            Return False
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
            ' objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function gFuncAnalogSelfTest(ByVal intAvgOfADCReadings As Integer, Optional ByRef dblADCValue As Double = 0.0) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncAnalogSelfTest
        'Description            :   To perform a test for ADC count and voltage. if voltage comes 
        '                           around 3000 mv then test is successful else test fails
        'Parameters             :   intAvgOfADCReadings,dblADCValue
        'Return                 :   True if success
        'Time/Date              :   25/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 22.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim intADCFmv As Integer = 0

        Try
            'Set Calibration mode to the Self Test mode. SELFTEST(6)
            If funcCalibrationMode(EnumCalibrationMode.SELFTEST, enumInstrumentBeamType.SingleBeam) Then
                ' Avg of ADC Readings is 1 then 
                'ADC filter voltage is check with 5000 then true

                If intAvgOfADCReadings = 1 Then
                    If funcReadADCNonFilter(intADCFmv) Then
                        If intADCFmv = 5000 Then
                            gFuncAnalogSelfTest = False
                            gobjMessageAdapter.ShowMessage(constADCNonFilter)
                            Application.DoEvents()
                        Else
                            gFuncAnalogSelfTest = True
                        End If
                    Else
                        gFuncAnalogSelfTest = False
                    End If
                Else
                    ' Avg of ADC Readings is not 1 then 
                    'ADC filter voltage should be rage of > 3255 and less than 3296
                    mobjCommdll.subTime_Delay(50)
                    If funcReadADCFilter(intAvgOfADCReadings, intADCFmv) Then
                        If intADCFmv > 3255 And intADCFmv < 3296 Then
                            dblADCValue = intADCFmv
                            gFuncAnalogSelfTest = True
                        Else
                            gFuncAnalogSelfTest = False
                            gobjMessageAdapter.ShowMessage(constADCFilter)
                            Application.DoEvents()
                        End If
                    Else
                        gFuncAnalogSelfTest = False
                    End If
                End If
            Else
                gFuncAnalogSelfTest = False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    '#######################################################
    'TODO Later Name change this function to funcSetBeamAndCalibrationMode
    '#######################################################
    'Public Function funcCalibrationMode(ByVal bytCalibMode As Byte, Optional ByVal intInstrumentBeamType As enumInstrumentBeamType = enumInstrumentBeamType.SingleBeam) As Boolean
    '    '---------------------------------------------------------------------------------------
    '    'Procedure Name         :   funcSetBeamAndCalibrationMode
    '    'Description            :   To set instrument Beam mode and Calibration Mode
    '    'Parameters             :   bytCalibMode : mode in which inst. to be set
    '    '                       :   intInstrumentBeamType as enumInstrumentBeamType
    '    'Return                 :   True if success   
    '    'Time/Date              :   26/9/06
    '    'Dependencies           :   obviously PC must communicate with Instrument through COM port
    '    'Author                 :   Rahul B.
    '    'Revision               :   3
    '    'Revision by Person     :   Deepak B. on 17.11.06 as some part of code was left behind by rahul
    '    'Revision by Person     :   Mangesh S. on 06-Apr-2007 To set Beam type of Instrument as per
    '    '                           selected Single Beam or Double Beam.
    '    '--------------------------------------------------------------------------------------
    '    Dim objWait As New CWaitCursor
    '    Dim bytArray(7) As Byte
    '    Dim intMode As Integer

    '    Try
    '        If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
    '            ' Set Calibration mode for Diff. operation mode and instrument type 
    '            If gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
    '                intMode = EnumAAS203Protocol.MODE
    '            ElseIf gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
    '                'Select Case gobjInst.Mode
    '                Select Case bytCalibMode
    '                    Case EnumCalibrationMode.AA
    '                        intMode = EnumAAS203Protocol.SETMODE_DB
    '                    Case Else
    '                        intMode = EnumAAS203Protocol.MODE
    '                End Select
    '                ' Set the protocol for double beam
    '                'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
    '            ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
    '                intMode = EnumAAS203Protocol.SETMODE_RB
    '            Else
    '                intMode = EnumAAS203Protocol.MODE
    '            End If
    '        Else
    '            'If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
    '            '    intMode = EnumAAS203Protocol.MODE
    '            If intInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
    '                'Select Case gobjInst.Mode
    '                Select Case bytCalibMode
    '                    Case EnumCalibrationMode.AA
    '                        intMode = EnumAAS203Protocol.SETMODE_DB
    '                    Case Else
    '                        intMode = EnumAAS203Protocol.MODE
    '                End Select
    '                ' Set the protocol for double beam
    '                'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
    '            ElseIf intInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
    '                intMode = EnumAAS203Protocol.SETMODE_RB
    '            Else
    '                intMode = EnumAAS203Protocol.MODE
    '            End If
    '        End If
    '        If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
    '            Return False
    '        End If
    '        ' Send command for Calibration Setting 
    '        If FuncTransmitCommand(intMode, bytCalibMode, 0, 0) Then
    '            If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
    '                If bytArray(1) <> 1 Then
    '                    Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
    '                    Call Application.DoEvents()
    '                    Return False
    '                Else
    '                    '---this else block of code is added by deepak on 15.11.06
    '                    gobjInst.Mode = bytCalibMode
    '                    ' check condition for 201 Inst.
    '                    If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
    '                        If mintSSGain > &H0 Then

    '                            If gstructSettings.D2Gain = False Then
    '                                Return True
    '                            Else
    '                                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
    '                                    Return False
    '                                End If
    '                                If FuncTransmitCommand(EnumAAS203Protocol.GAINX10_ON, 0, 0, 0) Then
    '                                    Array.Clear(bytArray, 0, 8)
    '                                    If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
    '                                        If bytArray(1) <> 1 Then
    '                                            Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
    '                                            Call Application.DoEvents()
    '                                            Return False
    '                                        End If
    '                                    End If
    '                                End If
    '                            End If

    '                        End If
    '                    End If
    '                    Return True
    '                End If
    '            Else
    '                Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
    '                Call Application.DoEvents()
    '                Return False
    '            End If
    '        Else
    '            'Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
    '            'Call Application.DoEvents()
    '            Return False
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objWait.Dispose()
    '        Application.DoEvents()
    '        '---------------------------------------------------------
    '    End Try
    'End Function
    '#######################################################

    Public Function funcCalibrationMode(ByVal bytCalibMode As Byte, Optional ByVal intInstrumentBeamType As enumInstrumentBeamType = enumInstrumentBeamType.SingleBeam) As Boolean
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim intMode As Integer
        '---this function is modified on 05.09.08
        Try
            'If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
            '    ' Set Calibration mode for Diff. operation mode and instrument type 
            '    If gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
            '        intMode = EnumAAS203Protocol.MODE
            '    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
            '        'Select Case gobjInst.Mode
            '        Select Case bytCalibMode
            '            Case EnumCalibrationMode.AA
            '                intMode = EnumAAS203Protocol.SETMODE_DB
            '            Case Else
            '                intMode = EnumAAS203Protocol.MODE
            '        End Select
            '        ' Set the protocol for double beam
            '        'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
            '    ElseIf gintInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
            '        intMode = EnumAAS203Protocol.SETMODE_RB
            '    Else
            '        intMode = EnumAAS203Protocol.MODE
            '    End If
            'Else
            '    'If intInstrumentBeamType = enumInstrumentBeamType.SingleBeam Then
            '    '    intMode = EnumAAS203Protocol.MODE
            '    If intInstrumentBeamType = enumInstrumentBeamType.DoubleBeam Then
            '        'Select Case gobjInst.Mode
            '        Select Case bytCalibMode
            '            Case EnumCalibrationMode.AA
            '                intMode = EnumAAS203Protocol.SETMODE_DB
            '            Case Else
            '                intMode = EnumAAS203Protocol.MODE
            '        End Select
            '        ' Set the protocol for double beam
            '        'intMode = EnumAAS203Protocol.SETMODE_DB  '31.07.07
            '    ElseIf intInstrumentBeamType = enumInstrumentBeamType.ReferenceBeam Then
            '        intMode = EnumAAS203Protocol.SETMODE_RB
            '    Else
            '        intMode = EnumAAS203Protocol.MODE
            '    End If
            'End If

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                intMode = EnumAAS203Protocol.SETMODE_DB
            Else
                intMode = EnumAAS203Protocol.MODE
            End If

            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send command for Calibration Setting 
            If FuncTransmitCommand(intMode, bytCalibMode, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
                        Call Application.DoEvents()
                        Return False
                    Else
                        '---this else block of code is added by deepak on 15.11.06
                        gobjInst.Mode = bytCalibMode
                        ' check condition for 201 Inst.
                        If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                            If mintSSGain > &H0 Then

                                If gstructSettings.D2Gain = False Then
                                    Return True
                                Else
                                    If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                                        Return False
                                    End If
                                    If FuncTransmitCommand(EnumAAS203Protocol.GAINX10_ON, 0, 0, 0) Then
                                        Array.Clear(bytArray, 0, 8)
                                        If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                                            If bytArray(1) <> 1 Then
                                                Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
                                                Call Application.DoEvents()
                                                Return False
                                            End If
                                        End If
                                    End If
                                End If

                            End If
                        End If
                        Return True
                    End If
                Else
                    Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
                    Call Application.DoEvents()
                    Return False
                End If
            Else
                'Call gobjMessageAdapter.ShowMessage(constCalibrationMode)
                'Call Application.DoEvents()
                Return False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcReadADCFilter(ByVal intNumOfReadingsForAvg As Integer, ByRef intAvgInMv As Integer) As Boolean
        '--------------------------------------------------------------------------------------
        'Procedure Name         :   funcReadADCFilter
        'Description            :   to read ADC count for filtered data.
        'Parameters             :   intNumOfReadingsForAvg : no of readings taken for averaging
        '                           [OUT] intAvgInmv : avg. of ADC count return
        'Return                 :   True if success
        'Time/Date              :   26/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 minor modifications
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        '++++++++++++++++++++++++++
        'int	S4FUNC ReadADCFilter()
        '{
        'int  i=5000;

        ' if (Inst.Avg==1)
        '	return ReadADC();

        ' Transmit(ADCF, (BYTE) Inst.Avg, (BYTE) (Inst.Avg>>8), 0);
        '            If (Recev(True)) Then
        '	i = Param2*256 + Param1;
        '#If DEMO Then
        '  pc_delay(10000);   pc_delay(10000);
        '  pc_delay(10000);  pc_delay(10000);
        '	i= pmtAd()+random(10);
        '#End If
        '#If QDEMO Then
        '	i= pmtAd()+random(100);
        '#End If
        ' if (i==5000)
        '  Gerror_message_new("ADC Error ","System Error");
        'return(i);
        '}
        '++++++++++++++++++++++++++

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            gFunclongtobyte(intNumOfReadingsForAvg, bytLow, bytHigh)

            If gobjInst.Average = 1 Then
                Return funcReadADCNonFilter(intAvgInMv)
            End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send  ADC Filter commnad for ADCF(2) value
            If FuncTransmitCommand(EnumAAS203Protocol.ADCF, bytLow, bytHigh, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcReadADCFilter = False
                        gobjMessageAdapter.ShowMessage(constADCFilter)
                        Application.DoEvents()
                    Else
                        'Calculate ADC voltage from byte array.
                        intAvgInMv = bytArray(2) + (bytArray(3) * 256)
                        '//----- Added by Sachin Dokhale for Demo mode
                        '#If DEMO Then
                        '	i= pmtAd()+random(10);
                        '#End If
                        ' use ramdom function for Adcf with funcpmtAd for Demo mode then use 
                        'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            intAvgInMv = funcpmtAd() + bytRandom.Next(10)
                        End If
                        '//-----
                        If intAvgInMv = 5000 Then
                            gobjMessageAdapter.ShowMessage(constADCError)
                        End If
                        funcReadADCFilter = True
                    End If
                Else
                    funcReadADCFilter = False
                    gobjMessageAdapter.ShowMessage(constADCFilter)
                    Application.DoEvents()
                End If
            Else
                funcReadADCFilter = False
                'gobjMessageAdapter.ShowMessage(constADCFilter)
                'Application.DoEvents()
            End If

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcReadADCNonFilter(ByRef intAvgInMv As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcReadADCNonFilter
        'Description            :   to read ADC count for non filtered data.
        'Parameters             :   [OUT] intAvgInmv : avg. of ADC count return
        'Return                 :   True if success
        'Time/Date              :   26/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        '++++++++++++++++++++++
        '        int	S4FUNC ReadADC()
        '{
        'int	i=5000;
        ' Transmit(ADCNF, 0, 0, 0);
        '        If (Recev(True)) Then
        '	i = Param2*256 + Param1;
        '#If DEMO Then
        '	i= pmtAd()+random(10);
        '#End If
        ' if (i==5000)
        '	Gerror_message_new("ADC Error ","System Error");
        'return(i);
        '}
        '++++++++++++++++++++++
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.ADCNF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcReadADCNonFilter = False
                        'gFuncShowMessage("Error...", "Error Reading ADC Non Filter Data.", EnumMessageType.Information)
                        gobjMessageAdapter.ShowMessage(constADCNonFilter)
                        Application.DoEvents()
                    Else
                        intAvgInMv = bytArray(2) + (bytArray(3) * 256)
                        '//----- Added by Sachin Dokhale for Demo mode
                        '#If DEMO Then
                        '	i= pmtAd()+random(10);
                        '#End If
                        'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            intAvgInMv = funcpmtAd() + bytRandom.Next(10)
                        End If
                        '//-----
                        funcReadADCNonFilter = True
                    End If
                Else
                    funcReadADCNonFilter = False
                    'gFuncShowMessage("Error...", "Error Reading ADC Non Filter Data.", EnumMessageType.Information)
                    gobjMessageAdapter.ShowMessage(constADCNonFilter)
                    Application.DoEvents()
                End If
            Else
                funcReadADCNonFilter = False
                'gFuncShowMessage("Error...", "Error Reading ADC Non Filter Data.", EnumMessageType.Information)
                'gobjMessageAdapter.ShowMessage(constADCNonFilter)
                'Application.DoEvents()
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcResetInstrument() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcResetInstrument
        'Description            :   To Reset the Instrument
        'Parameters             :   none
        'Return                 :   True if success
        'Time/Date              :   24/9/06
        'Dependencies           :   COM Port must be opened
        'Author                 :   Rahul B.
        'Revision               :   
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            mobjCommdll.IsNeedReceive = False
            If FuncTransmitCommand(EnumAAS203Protocol.RESET, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_DELAY) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAll_Lamp_Off() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcAll_Lamp_Off
        'Description            :   To set all lamps to off position (global.c All_Lamp_Off)
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   27/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 20.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send command for All lamp off HCLOFF(7)
            If FuncTransmitCommand(EnumAAS203Protocol.HCLOFF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcAll_Lamp_Off = False
                        gobjMessageAdapter.ShowMessage(constAllLampOff)
                        Application.DoEvents()
                    Else
                        funcAll_Lamp_Off = True
                    End If
                Else 'timeout
                    funcAll_Lamp_Off = False
                    gobjMessageAdapter.ShowMessage(constAllLampOff)
                    Application.DoEvents()
                End If
            Else
                funcAll_Lamp_Off = False
                'gobjMessageAdapter.ShowMessage(constAllLampOff)
                'Application.DoEvents()
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_PMT(ByVal dblPMT As Double) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_PMT
        'Description            :   To set PMT voltage
        'Parameters             :   dblPMT : pmt voltage to be set
        'Return                 :   True if success
        'Time/Date              :   27/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06 for some modifications
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim dbly1 As Double
        Dim inty As Integer
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim intPMT As Integer
        '++++++++++++++++++++++++++++++++++++++++++++++
        'void	S4FUNC Set_PMT(double pmt) 
        '{
        'double	y1;
        'int	y;

        ' Inst.Pmtv = pmt;
        ' y1 = (double) ( (double) Inst.Pmtv*(double)4095.0/(double)1000.0);
        ' y = (int) y1;
        ' y = y & 0x0fff;
        ' Transmit(PMT, (BYTE) y, (BYTE) (y>>8), 0);
        ' pc_delay(1000);
        ' Recev(TRUE);
        '}
        '++++++++++++++++++++++++++++++++++++++++++++++
        Dim dblPMTTemp As Double

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07
            'If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
            '    Return False
            'End If
            'gobjInst.PmtVoltage = dblPMT       '10.12.07
            'dbly1 = gobjInst.PmtVoltage * 4095.0 / 1000.0
            'inty = CInt(dbly1)
            'inty = inty And &HFFF

            dblPMTTemp = dblPMT
            dblPMTTemp = dblPMTTemp * 4095.0 / 1000.0
            intPMT = CInt(dblPMTTemp)
            intPMT = CInt(intPMT And &HFFF)
            ' Convert integer value of PMT into High byte and low byte
            gFunclongtobyte(intPMT, bytLow, bytHigh)

            'bytLow = CByte(inty)
            'bytHigh = CByte(inty >> 8)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send command to set PMT(4) with param low byte and high byte
            If FuncTransmitCommand(EnumAAS203Protocol.PMT, bytLow, bytHigh, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    'if byte array(1) is one then PMT is set properly
                    If bytArray(1) <> 1 Then
                        funcSet_PMT = False
                        gobjMessageAdapter.ShowMessage(constPMTVolt)
                        Application.DoEvents()
                    Else
                        gobjInst.PmtVoltage = dblPMT    '10.12.07
                        funcSet_PMT = True
                    End If
                Else
                    funcSet_PMT = False
                    gobjMessageAdapter.ShowMessage(constPMTVolt)
                    Application.DoEvents()
                End If
            Else
                funcSet_PMT = False
                'gobjMessageAdapter.ShowMessage(constPMTVolt)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_PMT_Bit(ByVal intPMT As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_PMT_Bit
        'Description            :   To set pmt
        'Parameters             :   intPMT : 
        'Return                 :   True if success
        'Time/Date              :   3/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim dblPMTTemp As Double
        Dim bytLow As Byte
        Dim bytHigh As Byte
        '------------------------------------------------
        '        void    S4FUNC  Set_PMT_Bit(int y)
        '{

        ' if (y>=0) {
        '  Transmit(PMT, (BYTE) (y), (BYTE) (y>>8), 0);
        '  pc_delay(1000);
        '  Recev(TRUE);
        '  Inst.Pmtv = ((double)y*(double)1000.0/(double)4095.0);
        ' }
        '}
        '------------------------------------------------
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            ' Convert integer value of PMT into High byte and low byte
            If intPMT >= 0 Then
                gFunclongtobyte(intPMT, bytLow, bytHigh)
            End If

            'bytLow = CByte(intPMT And &HFF)
            'bytHigh = CByte(intPMT >> 8)

            If intPMT > 0 Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'Send command to set PMT(4) with param low byte and high byte
                If FuncTransmitCommand(EnumAAS203Protocol.PMT, bytLow, bytHigh, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            funcSet_PMT_Bit = False
                            gobjMessageAdapter.ShowMessage(constPMTBit)
                            Application.DoEvents()
                        Else
                            'if byte array(1) is one then PMT is set Inst object of PmtVoltage 
                            gobjInst.PmtVoltage = (CDbl(intPMT) * CDbl(1000.0) / CDbl(4095.0))
                            funcSet_PMT_Bit = True
                        End If
                    Else
                        funcSet_PMT_Bit = False
                        gobjMessageAdapter.ShowMessage(constPMTBit)
                        Application.DoEvents()
                    End If
                Else
                    funcSet_PMT_Bit = False
                    'gobjMessageAdapter.ShowMessage(constPMTBit)
                    'Application.DoEvents()
                End If
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_PMT_Ref_Bit(ByVal intPMT As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSet_PMT_Bit
        'Description            :   To set pmt
        'Parameters             :   intPMT : 
        'Return                 :   True if success
        'Time/Date              :   3/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 17.11.06
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim dblPMTTemp As Double
        Dim bytLow As Byte
        Dim bytHigh As Byte
        '------------------------------------------------
        '        void    S4FUNC  Set_PMT_Bit(int y)
        '{

        ' if (y>=0) {
        '  Transmit(PMT, (BYTE) (y), (BYTE) (y>>8), 0);
        '  pc_delay(1000);
        '  Recev(TRUE);
        '  Inst.Pmtv = ((double)y*(double)1000.0/(double)4095.0);
        ' }
        '}
        '------------------------------------------------
        Try
            'If ' gblnInComm = True          '10.12.07 Then
            '    Return False
            'End If
            gblnInComm = True
            ' Convert integer value of PMT into High byte and low byte
            If intPMT >= 0 Then
                gFunclongtobyte(intPMT, bytLow, bytHigh)
            End If

            'bytLow = CByte(intPMT And &HFF)
            'bytHigh = CByte(intPMT >> 8)
            'Send command to set Ref. beam PMT(4) with param low byte and high byte
            If intPMT > 0 Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                If FuncTransmitCommand(EnumAAS203Protocol.SETPMT_RB, bytLow, bytHigh, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            funcSet_PMT_Ref_Bit = False
                            gobjMessageAdapter.ShowMessage(constPMTBit)
                            Application.DoEvents()
                        Else
                            'if byte array(1) is one then PMT is set Inst object of PmtVoltage 
                            gobjInst.PmtVoltageReference = (CDbl(intPMT) * CDbl(1000.0) / CDbl(4095.0))
                            funcSet_PMT_Ref_Bit = True
                        End If
                    Else
                        funcSet_PMT_Ref_Bit = False
                        gobjMessageAdapter.ShowMessage(constPMTBit)
                        Application.DoEvents()
                    End If
                Else
                    funcSet_PMT_Ref_Bit = False
                    'gobjMessageAdapter.ShowMessage(constPMTBit)
                    'Application.DoEvents()
                End If
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSetBH_HOME() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSetBH_HOME
        'Description            :   To set burner to home position
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   27/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        '        BOOL  S4FUNC BH_HOME()
        '{
        'unsigned oldt;

        ' if (GetInstrument()==AA202)
        '	return TRUE;

        ' oldt=Tout;
        ' Tout=LONG_DEALY;
        ' hold = Load_Curs();
        ' Transmit(BHHOME, 0,0, 0);
        ' if (Recev(TRUE)){
        '                If (!Param1) Then
        '	  Gerror_message(" ***PNEMATICS ERROR*** \n Error encountered while \n initialising Burner Up/Dn assembly");
        '  }
        ' SetCursor(hold);
        ' Tout=oldt;
        ' return Param1;
        '}

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send command to set Burner height home BHHOME(24) with param 0
            If FuncTransmitCommand(EnumAAS203Protocol.BHHOME, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcSetBH_HOME = False
                        gobjMessageAdapter.ShowMessage(constBHHome)
                        Application.DoEvents()
                    Else
                        If bytArray(2) = 0 Then
                            gobjMessageAdapter.ShowMessage(constBHHome)
                        Else
                            funcSetBH_HOME = True
                        End If
                    End If
                Else
                    funcSetBH_HOME = False
                    gobjMessageAdapter.ShowMessage(constBHHome)
                    Application.DoEvents()
                End If
            Else
                funcSetBH_HOME = False
                'gobjMessageAdapter.ShowMessage(constBHHome)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSetNV_HOME() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSetNV_HOME
        'Description            :   To set NV home position       
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   27/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If

            'Send command to set needle valve home NVHOME(23) with param  low byte and high byte is 0
            If FuncTransmitCommand(EnumAAS203Protocol.NVHOME, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcSetNV_HOME = False
                        gobjMessageAdapter.ShowMessage(constNVHome)
                        Application.DoEvents()
                    Else
                        ' show message when NV HOme set
                        If bytArray(2) = 0 Then
                            gobjMessageAdapter.ShowMessage(constNVHome)
                        Else
                            ' Get NV Position from  instrument if byte array(2) is not 0
                            If funcGet_NV_Pos() = True Then
                                funcSetNV_HOME = True
                            End If
                        End If
                    End If
                Else
                    funcSetNV_HOME = False
                    gobjMessageAdapter.ShowMessage(constNVHome)
                    Application.DoEvents()
                End If
            Else
                funcSetNV_HOME = False
                'gobjMessageAdapter.ShowMessage(constNVHome)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGain10X_OFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcGain10X_OFF
        'Description            :   to set Gain10x off 
        'Parameters             :   None
        'Retrun                 :   True if success
        'Time/Date              :   27/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If
            'if D2 Gain flag is seted in INI Setting
            If gstructSettings.D2Gain = True Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'Send command to set GAINX10_OFF(57) with 0
                If FuncTransmitCommand(EnumAAS203Protocol.GAINX10_OFF, 0, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            funcGain10X_OFF = False
                            'gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
                            gobjMessageAdapter.ShowMessage(constGain10XOFF)
                            Application.DoEvents()
                        Else
                            mintSSGain = &H0
                            funcGain10X_OFF = True
                        End If
                    Else
                        funcGain10X_OFF = False
                        'gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
                        gobjMessageAdapter.ShowMessage(constGain10XOFF)
                        Application.DoEvents()
                    End If
                Else
                    funcGain10X_OFF = False
                    'gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
                    'gobjMessageAdapter.ShowMessage(constGain10XOFF)
                    'Application.DoEvents()
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGain10X_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcGain10X_ON
        'Description            :   to set Gain10x on 
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   19.12.06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If
            'if D2 Gain flag is seted in INI Setting
            If gstructSettings.D2Gain = True Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'Send command to set GAINX10_ON(56) with param is 0
                If FuncTransmitCommand(EnumAAS203Protocol.GAINX10_ON, 0, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            funcGain10X_ON = False
                            gobjMessageAdapter.ShowMessage(constGain10XOFF)
                            Application.DoEvents()
                        Else
                            mintSSGain = &H1
                            funcGain10X_ON = True
                        End If
                    Else
                        funcGain10X_ON = False
                        gobjMessageAdapter.ShowMessage(constGain10XOFF)
                        Application.DoEvents()
                    End If
                Else
                    funcGain10X_ON = False
                    'gFuncShowMessage("Error...", "Error setting Gain10X OFF .", EnumMessageType.Information)
                    'gobjMessageAdapter.ShowMessage(constGain10XOFF)
                    'Application.DoEvents()
                End If
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSetMICRO_OFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSetMICRO_OFF
        'Description            :   To set MICRO OFF
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   27/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If
            'if Mesh flag is seted in INI Setting
            If gstructSettings.Mesh = True Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'Send command to set MICROOFF(55) with 0
                If FuncTransmitCommand(EnumAAS203Protocol.MICROOFF, 0, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            funcSetMICRO_OFF = False
                            gobjMessageAdapter.ShowMessage(constMicroOFF)
                            Application.DoEvents()
                        Else
                            funcSetMICRO_OFF = True
                        End If
                    Else
                        funcSetMICRO_OFF = False
                        gobjMessageAdapter.ShowMessage(constMicroOFF)
                        Application.DoEvents()
                    End If
                Else
                    funcSetMICRO_OFF = False
                    'gobjMessageAdapter.ShowMessage(constMicroOFF)
                    'Application.DoEvents()
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSetMICRO_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSetMICRO_ON
        'Description            :   To set MICRO ON
        'Parameters             :   None
        'Retrun                 :   True if success
        'Time/Date              :   03/01/07
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Sachin Dokhale.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If
            'if Mesh  flag is seted in INI Setting
            If gstructSettings.Mesh = True Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'Send command to set MICROON(54) with 0
                If FuncTransmitCommand(EnumAAS203Protocol.MICROON, 0, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            funcSetMICRO_ON = False
                            'gFuncShowMessage("Error...", "Error setting MICRO OFF .", EnumMessageType.Information)
                            gobjMessageAdapter.ShowMessage(constMicroON)
                            Application.DoEvents()
                        Else
                            funcSetMICRO_ON = True
                        End If
                    Else
                        funcSetMICRO_ON = False
                        'gFuncShowMessage("Error...", "Error setting MICRO OFF .", EnumMessageType.Information)
                        gobjMessageAdapter.ShowMessage(constMicroON)
                        Application.DoEvents()
                    End If
                Else
                    funcSetMICRO_ON = False
                    'gFuncShowMessage("Error...", "Error setting MICRO OFF .", EnumMessageType.Information)
                    'gobjMessageAdapter.ShowMessage(constMicroON)
                    'Application.DoEvents()
                End If
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAir_OFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcAir_OFF
        'Description            :   To set AIR off
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   29/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' Before Air off make flame off first
            Call funcFlame_OFF()

            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send command to set AIR OFF(30) with 0
            If FuncTransmitCommand(EnumAAS203Protocol.AIROFF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcAir_OFF = False
                        gobjMessageAdapter.ShowMessage(constAirOFF)
                        Application.DoEvents()
                    Else
                        'if Array of byte(1) is 1 then function return true for air gets off
                        funcAir_OFF = True
                    End If

                Else
                    funcAir_OFF = False
                    gobjMessageAdapter.ShowMessage(constAirOFF)
                    Application.DoEvents()
                End If
            Else
                funcAir_OFF = False
                'gobjMessageAdapter.ShowMessage(constAirOFF)
                'Application.DoEvents()
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAir_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcAir_ON
        'Description            :   To set AIR on
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   29/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send command to set AIR OFF(30) with 0
            If FuncTransmitCommand(EnumAAS203Protocol.AIRON, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcAir_ON = False
                        gobjMessageAdapter.ShowMessage(constAirOn)
                        Application.DoEvents()
                    Else
                        'if Array of byte(1) is 1 then function return true for air gets On
                        funcAir_ON = True
                    End If
                Else
                    funcAir_ON = False
                    ' Show error is "Error setting Air ON."
                    gobjMessageAdapter.ShowMessage(constAirOn)
                    Application.DoEvents()
                End If
            Else
                funcAir_ON = False
                ' Show error is "Error setting Air ON."
                'gobjMessageAdapter.ShowMessage(constAirOn)
                'Application.DoEvents()
            End If

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcFlame_OFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcFlame_OFF
        'Description            :   To set Flame off
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   25/9/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        'BOOL	S4FUNC Flame_Off()
        '{
        '        If (Inst.N2of) Then
        '	Inst.N2of = N2_FLAME_OFF();
        '        ElseIf (Inst.Aaf) Then
        '	 Inst.Aaf = AA_FLAME_OFF();
        '        Else
        '	return FALSE;
        ' return TRUE;
        '}

        Try
            ' Make the flame off any N2o or AA flame 
            ' as per checking setting from Inst object
            If gobjInst.N2of = True Then
                If func_N2_FLAME_OFF() = False Then
                    gobjInst.N2of = False
                End If
            ElseIf gobjInst.Aaf = True Then
                If func_AA_FLAME_OFF() = True Then
                    gobjInst.Aaf = False
                End If
            Else
                Return False
            End If

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcStartSpectrum(ByVal dblWv As Double, ByVal intSpeed As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcStartSpectrum
        'Description            :   to Start Spectrum .
        'Parameters             :   dblWv as Destination Wv., intSpeed is speed of Scan    
        'Retrun                 :   True if success
        'Time/Date              :   26/9/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim bytSpeed As Byte
        Dim intWv As Integer

        Try

            ' gblnInComm = True          '10.12.07

            'Convert Wv. parameter into Low Byte and High byte 
            intWv = CInt(dblWv)
            bytLow = CByte(intWv And &HFF)
            'bytLow = CByte(dblWv)
            bytHigh = CByte(dblWv >> 8)

            'Convert speed parameter into third byte parameter 
            bytSpeed = CByte(intSpeed)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If

            'Send the command for Sectrum SPECT(48) with param low byte and high byte is Wv. to be achive 
            'and third param is the speed of process of spectrum
            'Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
            mobjCommdll.IsNeedReceive = False
            If FuncTransmitCommand(EnumAAS203Protocol.SPECT, bytLow, bytHigh, bytSpeed) Then
                'If FuncTransmitCommand(EnumAAS203Protocol.SPECTRUM_RB, bytLow, bytHigh, bytSpeed) Then

                clsRS232Main.gblnInCommProcess = False
                funcStartSpectrum = True
            Else
                funcStartSpectrum = False
                ' on Error of command show message is "Error Reading ADC Filter Data."
                'gobjMessageAdapter.ShowMessage(constErrorSpectrum)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            'gblnInComm = False
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcStartSpectrum_ReferenceBeam(ByVal dblWv As Double, ByVal intSpeed As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcStartSpectrum_ReferenceBeam
        'Description            :   to Start Spectrum for Reference Beam.
        'Parameters             :   param: dblWv is the achiving Wv. param: intSpeed is Speed of spectrum
        '                           return True if process run successful and without exception
        'Time/Date              :   07.04.07
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim bytSpeed As Byte
        Dim intWv As Integer

        Try
            ' gblnInComm = True          '10.12.07

            'Convert Wv. parameter into Low Byte and High byte 
            intWv = CInt(dblWv)
            bytLow = CByte(intWv And &HFF)
            bytHigh = CByte(dblWv >> 8)

            'Convert speed parameter into third byte parameter 
            bytSpeed = CByte(intSpeed)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send the command for Sectrum SPECT(48) with param low byte and high byte is Wv. to be achive 
            'and third param is the speed of process of spectrum
            'Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
            mobjCommdll.IsNeedReceive = False
            If FuncTransmitCommand(EnumAAS203Protocol.SPECTRUM_RB, bytLow, bytHigh, bytSpeed) Then
                '    If FuncTransmitCommand(EnumAAS203Protocol.SPECT, bytLow, bytHigh, bytSpeed) Then
                clsRS232Main.gblnInCommProcess = False
                funcStartSpectrum_ReferenceBeam = True
            Else
                funcStartSpectrum_ReferenceBeam = False
                ' on Error of command show message is "Error Reading ADC Filter Data."
                'gobjMessageAdapter.ShowMessage(constErrorSpectrum)
                'Application.DoEvents()
            End If

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
            Application.DoEvents()
            'gblnInComm = False
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcBreakSpectrum() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcBreakSpectrum
        'Description            :   to break or stop the Spectrum .
        'Parameters             :   None    
        'Return                 :   True if success
        'Time/Date              :   07/11/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim bytSpeed As Byte
        Dim bytLast As Byte

        Try
            ' gblnInComm = True          '10.12.07

            'Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
            'bytLow = CByte(intNumOfReadingsForAvg)
            'bytHigh = CByte(intNumOfReadingsForAvg >> 8)

            bytLow = 0
            bytHigh = 0 'CByte(dblWv >> 8)
            bytLast = 0 'CByte(intSpeed)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send command to break spectrum SPBREAK(101)
            If FuncTransmitCommand(EnumAAS203Protocol.SPBREAK, bytLow, bytHigh, bytLast) Then
                funcBreakSpectrum = True
            Else
                funcBreakSpectrum = False
                'gFuncShowMessage("Error...", "Error Reading ADC Filter Data.", EnumMessageType.Information)
                'gobjMessageAdapter.ShowMessage(constErrorSpectrum)
                'Application.DoEvents()
            End If
            clsRS232Main.gblnInCommProcess = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            gblnInComm = False
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPC_END() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcPC_END
        'Description            :   to PC End.
        'Parameters             :   None
        'Return                 :   true when success
        'Time/Date              :   07/11/06
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim bytSpeed As Byte
        Dim bytLast As Byte

        Try
            ' gblnInComm = True          '10.12.07

            'Transmit(SPECT, (BYTE)(j), (BYTE) (j>>8), (BYTE) speed);
            'bytLow = CByte(intNumOfReadingsForAvg)
            'bytHigh = CByte(intNumOfReadingsForAvg >> 8)

            bytLow = 0
            bytHigh = 0 'CByte(dblWv >> 8)
            bytLast = 0 'CByte(intSpeed)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return True
            End If
            ' Send command to PC End
            If FuncTransmitCommand(EnumAAS203Protocol.PC_END, bytLow, bytHigh, bytLast) Then
                funcPC_END = True
            Else
                funcPC_END = False
                'gobjMessageAdapter.ShowMessage(constErrorSpectrum)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcReceive_ScanData(ByRef inIndex As Integer, ByRef dblScanData As Double) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncReceive_ScanData  
        'Description            :   To receive the data from the Input buffer
        'Parameters             :   Byref intindex,dbldata,intflag and dblLData
        'Retutn                 :   True if success
        'Time/Date              :   12.06 
        'Dependencies           :   
        'Author                 :   Sachin Dokhale 07.11.06
        'Revision               :   
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        funcReceive_ScanData = False
        Dim blnFlag As Boolean = False
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return True
            'End If

            If FuncReceiveData(bytArray, CONST_DELAY) Then
                mobjCommdll.IsNeedReceive = False
                If bytArray(1) <> 1 Then
                    funcReceive_ScanData = False
                    Application.DoEvents()
                Else
                    dblScanData = bytArray(3) * 256 + bytArray(2)
                    funcReceive_ScanData = True
                End If
            Else
                funcReceive_ScanData = False
                Application.DoEvents()
            End If
            clsRS232Main.gblnInCommProcess = False
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
            objWait.Dispose()
            gblnInComm = False
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function Wavelength_Position(ByVal wvnew As Double, Optional ByRef lblUVWavelengthStatus As Label = Nothing) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   Wavelength_Position
        'Description            :   To position the wavelength
        'Parameters             :   new wavelength to position
        'Affected Parameter     :   lblUVWavelengthStatus Show label
        'Return                 :   True if success
        'Time/Date              :   08.11.06
        'Dependencies           :   communication
        'Author                 :   Deepak Bhati
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'void S4FUNC Wavelength_Position(HDC hdc , double wvnew, int x, int y)
        '{
        '#If DEMO Then
        '	MoveTo(hdc, x, y);
        '	wvcur=wvnew;
        '#Else
        'double temp;

        'if (wvnew<=0) Find_Wavelength_Home(hdc, x, y);
        'else if (wvnew<Inst.Wvcur) {
        '	hold = Load_Curs();
        '	temp  = wvnew;
        '	wvnew = wvnew-(double)1.0;
        '	Wav_Pos(hdc,wvnew, x, y);
        '	wvnew = temp;
        '	Wav_Pos(hdc,wvnew, x, y);
        '	SetCursor(hold);
        '  }
        'else{
        '  Wav_Pos(hdc,wvnew, x, y);

        '}
        '#End If
        '}
        Dim objWait As New CWaitCursor
        Dim temp As Double

        Try
            ' check if new Wv. is less than or equel to (<=) 0 then use Wavelength Home position, if not
            ' check if New Wv. is less than (<) current Wv. then 
            ' for correct Wv tobe achive 
            ' first restore the New Wv into temp location 
            ' minus one Wv. from new Wv. then position to Wavelength
            ' again restore original Wv. and position to Wavelenth.
            ' check above condition is not there the simply position to Wavelenth.

            If wvnew <= 0 Then

                Call gFuncWavelength_Home(lblUVWavelengthStatus)

            ElseIf wvnew < gobjInst.WavelengthCur Then
                temp = wvnew
                wvnew = wvnew - 1.0

                If Wav_Pos(wvnew, lblUVWavelengthStatus) = True Then
                    wvnew = temp
                    If Wav_Pos(wvnew, lblUVWavelengthStatus) = False Then
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                If Wav_Pos(wvnew, lblUVWavelengthStatus) = False Then
                    Return False
                End If
            End If

            Return True

            'if (wvnew<=0) Find_Wavelength_Home(hdc, x, y);
            'else if (wvnew<Inst.Wvcur) {
            '	hold = Load_Curs();
            '	temp  = wvnew;
            '	wvnew = wvnew-(double)1.0;
            '	Wav_Pos(hdc,wvnew, x, y);
            '	wvnew = temp;
            '	Wav_Pos(hdc,wvnew, x, y);
            '	SetCursor(hold);
            '  }
            'else{
            '  Wav_Pos(hdc,wvnew, x, y);
            '}

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
            objWait.Dispose()
            'Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    ''Public Function GetSRLamp() As Boolean
    ''    Return mintSRLamp
    ''End Function

    ''Public Function SetSRLamp(ByVal intSRLamp As Boolean) As Boolean
    ''    '=====================================================================
    ''    ' Procedure Name        : gfuncSetSRLamp
    ''    ' Parameters Passed     : intSRLamp
    ''    ' Returns               : Boolean
    ''    ' Purpose               : Set the SR Lamp
    ''    ' Description           : 
    ''    ' Assumptions           : 
    ''    ' Dependencies          : 
    ''    ' Author                : Sachin Dokahle
    ''    ' Created               : 25.11.06
    ''    ' Revisions             : 
    ''    '=====================================================================
    ''    Try
    ''        mintSRLamp = intSRLamp

    ''    Catch ex As Exception
    ''        '---------------------------------------------------------
    ''        'Error Handling and logging
    ''        gobjErrorHandler.ErrorDescription = ex.Message
    ''        gobjErrorHandler.ErrorMessage = ex.Message
    ''        gobjErrorHandler.WriteErrorLog(ex)
    ''        Return False
    ''        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    ''        '---------------------------------------------------------
    ''    Finally
    ''        '---------------------------------------------------------
    ''        'Writing Execution log
    ''        If CONST_CREATE_EXECUTION_LOG = 1 Then
    ''            gobjErrorHandler.WriteExecutionLog()
    ''        End If
    ''        '---------------------------------------------------------
    ''    End Try
    ''End Function

    Public Function D2_OFF() As Boolean
        '=====================================================================
        ' Procedure Name        : D2_OFF
        ' Parameters Passed     : None
        ' Returns               : True of False 
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 
        ' Revisions             : By Deepak
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            'check SRLamp flag Set SR Lamp
            If Me.SRLamp() Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                If FuncTransmitCommand(SMHCLDIS, 0, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            Else
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'Send the command for D2 Lamp Off
                If FuncTransmitCommand(EnumAAS203Protocol.D2OFF, 0, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            End If

            'If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
            'If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
            '    If bytArray(1) <> 1 Then
            '        Return False
            '    Else
            '        Return True
            '    End If
            'End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function D2_ON() As Boolean
        '=====================================================================
        ' Procedure Name        : D2_ON
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 
        ' Revisions             : By Deepak
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            'check SRLamp flag Set SR Lamp
            If SRLamp() Then
                '
                '    If Inst.Lamp_pos = 0x02 Then
                '    Transmit(SMHCLENB, 1, 0, 0)
                'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.SMHCLENB, 1, 0, 0) Then
                'End If
                'Else
                '    Transmit(SMHCLENB, 2, 0, 0)
                'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.SMHCLENB, 2, 0, 0) Then
                'End If
                'End If
                ' Require to be check below commands
                If gobjInst.Lamp_Position = &H2 Then
                    If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                        Return False
                    End If
                    If FuncTransmitCommand(SMHCLENB, 1, 0, 0) Then
                        If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                            If bytArray(1) <> 1 Then
                                Return False
                            Else
                                Return True
                            End If
                        End If
                    End If
                Else
                    If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                        Return False
                    End If
                    If FuncTransmitCommand(SMHCLENB, 2, 0, 0) Then
                        If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                            If bytArray(1) <> 1 Then
                                Return False
                            Else
                                Return True
                            End If
                        End If
                    End If
                End If
            Else
                'Send the command for D2 Lamp On
                ''Transmit(D2ON, 0, 0, 0)
                'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.D2ON, 0, 0, 0) Then
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                If FuncTransmitCommand(EnumAAS203Protocol.D2ON, 0, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            End If

            'If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function gFunclongtobyte(ByVal lngparameter As Long, ByRef bytParameter1 As Byte, ByRef bytParameter2 As Byte) As Boolean
        '-----------------------------------  Function Header  -------------------------------
        'Function Name          :   gFunclongtobyte 
        'Description            :   Long to bytes conversion     
        'Parameters             :   lngparameter as long
        'Affected Parameter     :   byte_parameter1 as byte , byte2_parameter2 as byte
        'Return Type		    :   True if success
        'Time/Date              :   17 Oct 2003,10:40 Hrs
        'Dependencies           :   
        'Author                 :   Nilesh Shirode
        'Revision               :   
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim data As Long = lngparameter
        Dim multfact(5) As Long
        Dim i As Integer
        Dim longtobyte(4) As Byte

        Try
            ' Convert long integer into Byte data type
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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Function '429

    Public Function funcGet_NV_Pos() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   FuncGet_NV_Pos
        'Description            :   To get NV  position       
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   15.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        '----------------------------------------
        '    void	S4FUNC Get_NV_Pos()
        '{
        ' if (GetInstrument()==AA202)
        '	return ;

        '  Transmit(GETNV, 0,0, 0);
        '  if (Recev(TRUE))
        '	 Inst.Nvstep = Param2*256+Param1;
        '#If DEMO Then
        '	 Inst.Nvstep = NVpos;
        '#End If

        '}
        '----------------------------------------
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return True
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.GETNV, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        funcGet_NV_Pos = False
                        gobjMessageAdapter.ShowMessage(constNVHome)
                        Application.DoEvents()
                    Else
                        'gobjInst.NvStep = (bytArray(3) * 256) + bytArray(2)
                        'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            gobjInst.NvStep = gintNV_POS
                        Else
                            ' Set the needle valve stpes from byte array 
                            gobjInst.NvStep = (bytArray(3) * 256) + bytArray(2)
                        End If
                        funcGet_NV_Pos = True
                    End If
                Else
                    funcGet_NV_Pos = False
                    gobjMessageAdapter.ShowMessage(constNVHome)
                    Application.DoEvents()
                End If
            Else
                funcGet_NV_Pos = False
                'gobjMessageAdapter.ShowMessage(constNVHome)
                'Application.DoEvents()
            End If

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_BHRotateAntiClock_Steps(ByVal intSteps As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_BHRotateAntiClock_Steps
        'Description            :   To Rotate Burner Height Anticlockwise. 
        'Parameters             :   intSteps as integer
        'Return                 :   True if success
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow, bytHigh As Byte
        '    void  BH_RotateAnticlock_Steps(int steps)
        '{
        ' unsigned  oldTout;

        '  if (GetInstrument()==AA202)
        '	return ;

        ' oldTout=Tout;
        ' Tout=VERY_LONG_DEALY;
        ' hold = Load_Curs();

        ' Transmit(BHANTISTEPS, (BYTE) (steps>>8), (BYTE) (steps), 0);
        ' Recev(TRUE); // new addition   1
        ' Get_BH_Pos();
        ' SetCursor(hold);
        ' Tout=oldTout;
        '}
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            gFunclongtobyte(intSteps, bytLow, bytHigh)
            'Send  command for Buener Hight Anti steps high and low byte are the steps 
            If FuncTransmitCommand(EnumAAS203Protocol.BHANTISTEPS, bytHigh, bytLow, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_BHRotateAntiClock_Steps = False
                        'gobjMessageAdapter.ShowMessage("Error")
                        Application.DoEvents()
                    Else
                        ' get and restore steps of burner hight into Inst object for burner position
                        func_Get_BH_Pos()
                        gblnInComm = False
                        func_BHRotateAntiClock_Steps = True
                    End If
                Else
                    func_BHRotateAntiClock_Steps = False
                    'gobjMessageAdapter.ShowMessage("Error")
                    Application.DoEvents()
                End If
            Else
                func_BHRotateAntiClock_Steps = False
                'gobjMessageAdapter.ShowMessage("Error")
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_BHRotateClock_Steps(ByVal intSteps As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_BHRotateClock_Steps
        'Description            :   To Rotate Burner Height Clockwise. 
        'Parameters             :   intSteps into No of Steps
        'Return                 :   if success
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow, bytHigh As Byte

        '    void  BH_RotateClock_Steps(int steps)
        '{
        ' unsigned  oldTout;
        '  if (GetInstrument()==AA202)
        '	return ;

        ' oldTout=Tout;
        ' Tout=VERY_LONG_DEALY;
        ' hold = Load_Curs();

        ' Transmit(BHCLKSTEPS, (BYTE) (steps>>8), (BYTE) (steps), 0);
        ' Recev(TRUE); // new addition   1
        ' Get_BH_Pos();
        ' SetCursor(hold);
        ' Tout=oldTout;
        '}
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send Command EnumBHCLKSTEPS (62), with  parameter High byte and low byte
            gFunclongtobyte(intSteps, bytLow, bytHigh)
            If FuncTransmitCommand(EnumAAS203Protocol.BHCLKSTEPS, bytHigh, bytLow, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_BHRotateClock_Steps = False
                        'gobjMessageAdapter.ShowMessage("Error")
                        Application.DoEvents()
                    Else
                        func_Get_BH_Pos()
                        gblnInComm = False
                        func_BHRotateClock_Steps = True
                    End If
                Else
                    func_BHRotateClock_Steps = False
                    'gobjMessageAdapter.ShowMessage("Error")
                    Application.DoEvents()
                End If
            Else
                func_BHRotateClock_Steps = False
                'gobjMessageAdapter.ShowMessage("Error")
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcBH_File_read() As Boolean
        '---------------------- Procedure Header  -------------------------------
        'Procedure Name         :   funcBH_File_read
        'Description            :   To Read the Burner height file.
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '-------------------------------------------------------------------------

        '    void   S4FUNC BH_File_read()
        '{
        '#If !GRAPHITE Then
        'FILE 	*fptr=NULL;

        '  if ((fptr = fopen("burner.pos", "rt")) != NULL){
        '	 fscanf(fptr, "%d\n",&Inst.Bhstep);
        '	}
        '  fclose(fptr);
        ' if (Commflag){
        '	if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
        '	  BH_HOME();
        '	else{
        '	  SetLastBhPos(Inst.Bhstep);
        '	  Set_BH_Pos();
        '	}
        '	}
        '#End If
        '}

        Dim objWait As New CWaitCursor
        '---commented and added following line of code by deepak on 09.07.07
        'Dim file As New System.IO.StreamReader(Application.StartupPath & "\Burner.pos")
        Dim file As New System.IO.StreamReader(Application.StartupPath & "\bh.bhp")
        Dim words As String = file.ReadToEnd()

        'Saruabh for checking BH file Blank value 11.07.07
        If Trim(words) = "" Then
            gobjInst.BhStep = 0
        Else
            gobjInst.BhStep = CInt(Trim(words))
        End If
        'gobjInst.BhStep = CInt(Trim(words))
        'Saruabh for checking BH file Blank value 11.07.07

        file.Close()

        Try


            If Graphite = False Then
                If mobjCommdll.gFuncIsPortOpen = True Then
                    If gobjInst.BhStep <= 0 Or gobjInst.BhStep > MAXBHHOME Then
                        funcSetBH_HOME()
                    Else
                        func_SetLastBhPos(gobjInst.BhStep)
                        func_Set_BH_POS()
                    End If
                End If
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_SetLastBhPos(ByVal intBHStep As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_SetLastBhPos
        'Description            :   To set last bh position
        'Parameters             :   intBHStep as integer
        'Return                 :   True if success
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        '    void  SetLastBhPos( int bhstep )
        '{
        ' Get_BH_Pos();
        ' if (Inst.Bhstep>bhstep){
        '	 bhstep = Inst.Bhstep-bhstep;
        '	 BH_RotateAnticlock_Steps(bhstep);
        '	}
        'else if (Inst.Bhstep<bhstep){
        '	 bhstep-=Inst.Bhstep;
        '	 BH_RotateClock_Steps(bhstep);
        '  }
        '}
        Dim objWait As New CWaitCursor

        Try

            'to get the current burner position
            func_Get_BH_Pos()
            'check if current burner steps are greater then New buer steps then
            ' Rotate the burner height steps to the anticlockwise , if not then
            ' check if current burner steps are less then New buer steps then
            ' Rotate the burner height steps to the clockwise , if not then
            ' Rotating steps are only in bt'n  current burner steps and  new steps
            If gobjInst.BhStep > intBHStep Then
                intBHStep = gobjInst.BhStep - intBHStep
                func_BHRotateAntiClock_Steps(intBHStep)
            ElseIf gobjInst.BhStep < intBHStep Then
                intBHStep = intBHStep - gobjInst.BhStep
                func_BHRotateClock_Steps(intBHStep)
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_Get_BH_Pos() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_Get_BH_Pos
        'Description            :   To get bh position
        'Parameters             :   None
        'Return                 :   True if success.
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        'Line No.2208
        '    void	S4FUNC Get_BH_Pos()
        '{
        ' if (GetInstrument()==AA202)
        '	return ;

        ' Transmit(GETBH, 0,0, 0);
        ' if (Recev(TRUE))
        '	Inst.Bhstep = Param2*256+Param1;
        '}
        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return True
            End If
            ' Send the command for to get Burner heitht position GETBH(50). it is in setps
            If FuncTransmitCommand(EnumAAS203Protocol.GETBH, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_Get_BH_Pos = False
                        'gobjMessageAdapter.ShowMessage("Error")
                        gobjMessageAdapter.ShowMessage(constErrorGettingBurnerHeight)
                        Application.DoEvents()
                    Else
                        ' Restore the stpes into Inst object fro byre array 
                        gobjInst.BhStep = CInt(bytArray(3) * 256 + bytArray(2))
                        func_Get_BH_Pos = True
                    End If
                Else
                    func_Get_BH_Pos = False
                    'gobjMessageAdapter.ShowMessage("Error")
                    gobjMessageAdapter.ShowMessage(constErrorRecivedBlockBurner)
                    Application.DoEvents()
                End If
            Else
                func_Get_BH_Pos = False
                'gobjMessageAdapter.ShowMessage("Error")
                'gobjMessageAdapter.ShowMessage(constErrorTransmitBlockBurner)
                'Application.DoEvents()
            End If

        Catch threadex As Threading.ThreadAbortException

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_Set_BH_POS() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_Set_BH_POS
        'Description            :   To set bh position
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Line No.2219
        'void S4FUNC Set_BH_Pos()
        '{
        ' if (GetInstrument()==AA202)
        '	return ;
        ' hold = Load_Curs();

        ' Transmit(SETBH, (BYTE) Inst.Bhstep,(BYTE) (Inst.Bhstep>>8) , 0);
        '#If NEWHANDSHAKE Then
        ' Recev(TRUE);
        '#End If
        ' SetCursor(hold);
        '}
        Dim objWait As New CWaitCursor
        Dim bytLow, bytHigh As Byte
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            gFunclongtobyte(gobjInst.BhStep, bytLow, bytHigh)
            ' Send the command for to set Burner heitht position GETBH(52). it is in setps
            If FuncTransmitCommand(EnumAAS203Protocol.SETBH, bytLow, bytHigh, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_Set_BH_POS = False
                        'gobjMessageAdapter.ShowMessage("Error")
                        gobjMessageAdapter.ShowMessage(constErrorSettingBurnerHeight)
                        Application.DoEvents()
                    Else
                        func_Set_BH_POS = True
                    End If
                Else
                    func_Set_BH_POS = False
                    'gobjMessageAdapter.ShowMessage("Error")
                    gobjMessageAdapter.ShowMessage(constErrorRecivedBlockBurner)
                    Application.DoEvents()
                End If
            Else
                func_Set_BH_POS = False
                'gobjMessageAdapter.ShowMessage("Error")
                'gobjMessageAdapter.ShowMessage(constErrorTransmitBlockBurner)
                'Application.DoEvents()
            End If

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_SetParameters() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_SetParameters
        'Description            :   To set other parameters
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   16.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'void	SetParameters(HDC hdc, int x, int y)
        '{
        'int	i;

        ' Wprintf(hdc,RLEFT+10, (RTOP+40)+5*20, " Setting up Optimum Parameters .... Wait");
        ' BH_File_read();
        ' if (!Load_Tuttet_Status()){
        '	for (i=0; i<6; i++)
        '	  if (strcmpi(trim(ltrim(Inst.Lamp_par.lamp[i].elname)),"")!=0)
        '		 break;
        '	if (i==6){
        '                        If (OnLampPlace) Then
        '		 (*OnLampPlace)(NULL); //	  OnLampPlacement(NULL);
        '	  }
        '	else {
        '                            If (OnOptimiseTurPos) Then
        '		(*OnOptimiseTurPos)( NULL, TRUE);//	  Optimize_Turret_Position( NULL, TRUE);
        '	  Save_Tuttet_Status();
        '	 }
        '  }
        ' else  {
        '	for (i=0; i<6; i++)
        '	  if (strcmpi(trim(ltrim(Inst.Lamp_par.lamp[i].elname)),"")!=0)
        '		 break;
        '	  Find_Wavelength_Home(hdc, x, y);
        '	  Position_Turret(NULL, i+1, TRUE);
        '	 }
        ' D2File_Read();
        '                                        If (ReadIniForD2Gain()) Then
        '	GainX10Off();
        '                                            If (ReadIniForMesh()) Then
        '	 SetMicroOff();
        '}

        Dim objWait As New CWaitCursor

        Try
            Call funcBH_File_read()

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_N2_FLAME_OFF() As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   func_N2_FLAME_OFF
        'Description            :   To set N2 Flame off
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   17.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :   2
        'Revision by Person     :   Mangesh on 23-Apr-2007
        '------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        'BOOL(N2_FLAME_OFF())
        '{
        '   Transmit(NAOFF, 0,0, 0);
        '   Recev(TRUE);
        '   If (Param1) Then
        '	    Save_NV_Pos();

        '   If (Param1) Then
        '	    return 	OFF;
        '   Else
        '	    return 	ON;
        '}

        Try
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'Send the command for N2O Flame Off
            If FuncTransmitCommand(EnumAAS203Protocol.NAOFF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                        Return False
                    Else
                        '//----- Commented & Added by Sachin Dokhale
                        'func_N2_FLAME_OFF = True
                        'If (Param1) Then
                        '	return 	OFF;
                        'Else
                        '	return 	ON;

                        'If (Param1) Then
                        '   Save_NV_Pos();
                        '**************************************************************************
                        '---Added by Mangesh on 23-Apr-2007
                        '**************************************************************************
                        ' when flame gets off successfully restore the position of Needale Valve.
                        If bytArray(2) = 1 Then
                            Call funcSave_NV_Pos()
                        End If
                        '**************************************************************************

                        If bytArray(2) = 1 Then
                            Return False
                        Else
                            Return True
                        End If

                    End If

                Else
                    Call gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                    Return False
                End If
            Else
                'Call gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                Return False
            End If

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_N2_FLAME_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_N2_FLAME_ON
        'Description            :   To set N2 Flame On
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   21.12.06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Dim intnvs As Integer
        Dim flag1 As Boolean = False
        Dim intflag2 As Boolean = False
        '-------------------------------------------
        '        BOOL(N2_FLAME_ON())
        '{
        '//		NA BURNER NOT CONNECTED   	09
        '//    N2O PRESSURE ERROR	  		10
        'unsigned oldTout;
        'HWND	hwnd;
        'HDC	hdc;
        'int 	nvs;//, i;
        'BOOL flag1= FALSE;
        'int  flag2=0;

        ' if (GetInstrument()==AA202)
        '  return TRUE;
        ' if (Ignite_Test()!=GREEN)
        '	 return FALSE;
        ' if(InstType == AA202)
        '	 hwnd = Create_Window(NULL, 250, 100, "AA-202  NA FLAME");
        '                Else
        '	 hwnd = Create_Window(NULL, 250, 100, "AA-203  NA FLAME");
        ' hdc=GetDC(hwnd);
        ' Wprintf(hdc, 21, 19, "Setting NA Flame ....");
        ' Get_NV_Pos();
        ' if (Inst.Nvstep>5000){
        '  NV_HOME();
        '  Get_NV_Pos();
        ' }
        ' if (Inst.Nvstep<NVRED || Inst.Nvstep> ((int ) (1.5* (double) (NVRED))) )  {
        '	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
        '                            If (Inst.Nvstep < NVRED) Then
        '	  NV_RotateAnticlock_Steps(abs(NVRED-Inst.Nvstep));
        '                            Else
        '	  NV_RotateClock_Steps(abs(NVRED-Inst.Nvstep));
        '  }
        ' Wprintf(hdc, 21, 20, "        NA IGNITION                       ");
        ' Transmit(NAON, 0,0, 0);
        ' oldTout=Tout;
        ' Tout=VERY_LONG_DEALY; //200;
        ' Recev(TRUE);
        ' Tout=oldTout;
        ' Beep();Beep();
        ' switch(Param1)  {
        '	case 1 : Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED "); break;
        '	case 2 : Gerror_message(" NAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
        '	case 3 : Gerror_message(" NAFLAME ERROR \n DOOR NOT CLOSED "); break;
        '	case 4 : Gerror_message(" NAFLAME ERROR \n AIR PRESSURE LOW "); break;
        '	case 5 : Gerror_message(" NAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
        '	case 6 : Gerror_message(" NAFLAME ERROR \n AUTO IGNITION ERROR "); break;
        '	case 7 : if(!HydrideMode)
        '					Gerror_message(" NAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
        '				else{
        '					flag1 = TRUE;
        '				}
        '	break;
        '	case 8 : if(!HydrideMode)
        '					Gerror_message(" NAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
        '				else{
        '					flag1 = TRUE;
        '				}
        '	break;
        '	case 9:  Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED  "); break;
        '	case 10: Gerror_message(" NAFLAME ERROR \n N2O PRESSURE LOW "); break;
        '	case 11: Gerror_message(" NAFLAME ERROR \n Error while setting max. fuel ");
        '				break;
        '	case 0 : Wprintf(hdc, 21, 19, " NA  FLAME SET ......");
        '				flag1 = TRUE; break;
        '  }
        ' nvs = Load_NV_Pos();
        ' Get_NV_Pos();
        '                                        If (flag1) Then
        '		flag2=TRUE;
        ' if(flag2){
        '	 switch(CheckNvBurFiles()){
        '		case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
        '					 flag2 = FALSE;
        '		break;
        '		case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
        '					 flag2 = FALSE;
        '		break;
        '		case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
        '					 flag2 = FALSE;
        '		break;
        '	 }
        ' }
        ' if (flag2){
        '	 Wprintf(hdc, 21, 20, " Setting Last conditions   .......       ");
        '	 pc_delay(10000);    pc_delay(10000);    pc_delay(10000);
        '//---------added by sss for setting last bh conditions on dt 23/11/2000--------
        '#If !GRAPHITE Then
        '	 if(Load_BH_Pos()!=-1){
        '		 if (Commflag){
        '			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
        '			  BH_HOME();
        '			else
        '			  SetLastBhPos(Inst.Bhstep);
        '		 }
        '	 }
        '#End If
        '//---------------end of set bh logic---------

        ' if (flag2&& nvs<3.0*NVRED){
        '	Wprintf(hdc, 21, 20, " Setting Last conditions   ........     ");
        '	SetLastFuel(nvs);
        '  }
        ' }
        ' ReleaseDC(hwnd, hdc);
        ' Close_Window(hwnd, NULL);
        ' return flag1;
        '}
        '-------------------------------------------
        Try
            ' if (GetInstrument()==AA202)
            '  return TRUE;
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Or _
                gstructSettings.AppMode = EnumAppMode.DemoMode_201 Then
                Return True
            End If

            ' if (Ignite_Test()!=GREEN)
            '	 return FALSE;
            ' check the Ignition status of instrument if it is not green then return false

            '--- Modified function of funcIgnite_Test by Sachin Dokhale on 04.02.07
            'If Not (gobjClsAAS203.funcIgnite_Test() = ClsAAS203.enumIgniteType.Green) Then
            '    Return False
            'End If
            Dim intIgnite_Test As ClsAAS203.enumIgniteType
            '--- 22.02.08
            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
            '---
            If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
                If Not (intIgnite_Test = ClsAAS203.enumIgniteType.Green) Then
                    Return False
                End If
            End If
            Application.DoEvents()
            '---
            'Call gobjMessageAdapter.ShowMessage("N2o First", "N2o First", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)  '22.02.08
            'Application.DoEvents()

            Dim strNAFlameMessageCaption As String
            If gstructSettings.AppMode = EnumAppMode.FullVersion_203 Or _
             gstructSettings.AppMode = EnumAppMode.DemoMode Then
                If gstructSettings.NewModelName = False Then  '---21.07.09
                    strNAFlameMessageCaption = "AA-203  NA FLAME"
                Else
                    strNAFlameMessageCaption = "AA-303  NA FLAME"
                End If
            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203D Or _
             gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
                If gstructSettings.NewModelName = False Then  '---21.07.09
                    strNAFlameMessageCaption = "AA-203D  NA FLAME"
                Else
                    strNAFlameMessageCaption = "AA-303D  NA FLAME"
                End If
            End If

            'gobjMessageAdapter.
            'hwnd = Create_Window(NULL, 250, 100, "AA-203  NA FLAME");
            'hdc=GetDC(hwnd);
            'Wprintf(hdc, 21, 19, "Setting NA Flame ....");
            'show the message status of NV Flame "Setting NV Flame "

            Call gobjMessageAdapter.ShowStatusMessageBox("Setting NV Flame .....", strNAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000, True)
            Application.DoEvents()
            ' Get the NV position from instrument to Inst object
            Call funcGet_NV_Pos()
            '// BH_HOME();  // set bur home

            'check NV steps if steps are grater then 5000
            'Set NV steps to home position and get current NV position
            If (gobjInst.NvStep > 5000) Then
                Call funcSetNV_HOME()
                Call funcGet_NV_Pos()
            End If


            '//----
            ' validate NV steps and set NV Position
            If ((gobjInst.NvStep < NVRED) Or gobjInst.NvStep > CInt((1.5 * NVRED))) Then
                'Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
                Call gobjMessageAdapter.UpdateStatusMessageBox("Setting Fuel Please  Wait ....", strNAFlameMessageCaption)

                If (gobjInst.NvStep < NVRED) Then
                    funcNV_RotateAntiClock_Steps(Math.Abs(NVRED - gobjInst.NvStep))
                Else
                    funcNV_RotateClock_Steps(Math.Abs(NVRED - gobjInst.NvStep))
                End If
            End If

            ' gblnInComm = True          '10.12.07
            ' Wprintf(hdc, 21, 20, "        NA IGNITION                       ");
            'Call gobjMessageAdapter.ShowStatusMessageBox("        NA IGNITION               ", strNAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000, True)
            Call gobjMessageAdapter.UpdateStatusMessageBox("        NA IGNITION               ", strNAFlameMessageCaption)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                gobjMessageAdapter.CloseStatusMessageBox()
                Return False
            End If
            ' Send the N2O ignition On Command to the instument
            If FuncTransmitCommand(EnumAAS203Protocol.NAON, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_N2_FLAME_ON = False
                        gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                    Else
                        Select Case bytArray(2)
                            Case 1
                                'case 1 : Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED "); break;
                                gobjMessageAdapter.ShowMessage(constNABurnerNotConnected)
                            Case 2
                                'case 2 : Gerror_message(" NAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
                                gobjMessageAdapter.ShowMessage(constFillWaterInTrap)
                            Case 3
                                'case 3 : Gerror_message(" NAFLAME ERROR \n DOOR NOT CLOSED "); break;
                                gobjMessageAdapter.ShowMessage(constDoorNotClosed)
                            Case 4
                                '	case 4 : Gerror_message(" NAFLAME ERROR \n AIR PRESSURE LOW "); break;
                                gobjMessageAdapter.ShowMessage(constAirPressureLow)
                            Case 5
                                '	case 5 : Gerror_message(" NAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
                                gobjMessageAdapter.ShowMessage(constFuelPressureLow)
                            Case 6
                                'case 6 : Gerror_message(" NAFLAME ERROR \n AUTO IGNITION ERROR "); break;
                                gobjMessageAdapter.ShowMessage(constErrorAutoIgnition)
                            Case 7
                                '                        Case 7 : If (!HydrideMode) Then
                                '	Gerror_message(" NAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
                                'else{
                                '	flag1 = TRUE;
                                '}
                                'If Not (gblnHydrideMode) Then

                                If Not (HydrideMode = True) Then
                                    gobjMessageAdapter.ShowMessage(constYellowFlameNotObtainable)
                                Else
                                    flag1 = True
                                End If
                            Case 8
                                '                        Case 8 : If (!HydrideMode) Then
                                '	Gerror_message(" NAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
                                'else{
                                '	flag1 = TRUE;
                                '}
                                'If Not (gblnHydrideMode) Then
                                If Not (HydrideMode = True) Then
                                    gobjMessageAdapter.ShowMessage(constBlueFlameNotObtainable)
                                Else
                                    flag1 = True
                                End If
                            Case 9
                                'case 9:  Gerror_message(" NAFLAME ERROR \n NA BURNER NOT CONNECTED  "); break;
                                gobjMessageAdapter.ShowMessage(constNABurnerNotConnected)
                            Case 10
                                '	case 10: Gerror_message(" NAFLAME ERROR \n N2O PRESSURE LOW "); break;
                                gobjMessageAdapter.ShowMessage(constN2OPressureLow)
                            Case 11
                                '	case 11: Gerror_message(" NAFLAME ERROR \n Error while setting max. fuel ");
                                gobjMessageAdapter.ShowMessage(constErrorSettingMaxFuel)
                            Case 0
                                'case 0 : Wprintf(hdc, 21, 19, " NA  FLAME SET ......");
                                'gobjMessageAdapter.ShowMessage("NA BURNER NOT CONNECTED", "NAFLAME ERROR ", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
                                'gobjMessageAdapter.ShowStatusMessageBox("NA  FLAME SET ......", "NAFLAME", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
                                Call gobjMessageAdapter.UpdateStatusMessageBox("NA  FLAME SET ......", "NAFLAME")
                                flag1 = True
                        End Select

                        'nvs = Load_NV_Pos();
                        'Get_NV_Pos();
                        'If (flag1) Then
                        '	flag2=TRUE;
                        gblnInComm = False

                        ' Get the NV Stpes position
                        Dim nvSteps As Integer
                        Dim intBHSteps As Integer

                        nvSteps = gobjInst.NvStep()
                        nvSteps = funcLoad_NV_Pos()
                        Call gobjCommProtocol.funcGet_NV_Pos()
                        If flag1 = True Then
                            intflag2 = True
                        End If
                        '//
                        'if(flag2){
                        ' switch(CheckNvBurFiles()){
                        '	case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
                        '				 flag2 = FALSE;
                        '	break;
                        '	case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
                        '				 flag2 = FALSE;
                        '	break;
                        '	case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
                        '				 flag2 = FALSE;
                        '	break;
                        ' }
                        '}

                        ' check flag2 to chack NV Burner setting
                        If intflag2 Then
                            'chack NV Burner setting and ask for to load previous optimised condition on appropriate instrument condition
                            '---commented on 30.04.10
                            ''Select Case funcCheckNVBurFiles()
                            ''    Case 1
                            ''        If (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelConditions) = False) Then
                            ''            intflag2 = False
                            ''        End If
                            ''    Case 2
                            ''        If (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedBurnerConditions) = False) Then
                            ''            intflag2 = False
                            ''        End If
                            ''    Case 3
                            ''        If (gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) = False) Then
                            ''            intflag2 = False
                            ''        End If
                            ''End Select
                            ''Application.DoEvents()

                            '---written on 30.04.10
                            If gobjClsAAS203.funcCheckPresenceOfLastFuelConditions() = True Then
                                If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) = False Then
                                    intflag2 = False
                                End If
                                Application.DoEvents()
                            Else
                                intflag2 = False
                            End If
                        End If
                        '//-----
                        gblnInComm = False
                        gobjMessageAdapter.CloseStatusMessageBox()
                        If (intflag2) Then
                            If gstructSettings.NewModelName = False Then  '---21.07.09
                                Call gobjMessageAdapter.ShowStatusMessageBox("Setting Last conditions   .......       ", "AA-203  NA FLAME", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
                            Else
                                Call gobjMessageAdapter.ShowStatusMessageBox("Setting Last conditions   .......       ", "AA-303  NA FLAME", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
                            End If

                            'gobjCommProtocol.mobjCommdll.subTime_Delay(3000)
                            '#If !GRAPHITE Then
                            '	 if(Load_BH_Pos()!=-1){
                            '		 if (Commflag){
                            '			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
                            '			  BH_HOME();
                            '			else
                            '			  SetLastBhPos(Inst.Bhstep);
                            '		 }
                            '	 }
                            '#End If
                            mobjCommdll.subTime_Delay(100)
                            'check for (not) Graphite setting  for burner height setting

                            '---commented by Deepak on 30.04.10
                            ''If Not Graphite Then
                            ''    intBHSteps = FuncLoad_BH_Pos()
                            ''    If Not intBHSteps = -1 Then
                            ''        'gobjInst.BhStep = intBHPosition
                            ''        If gobjInst.BhStep <= 0 Or gobjInst.BhStep > MAXBHHOME Then
                            ''            funcSetBH_HOME()
                            ''        Else
                            ''            If intBHSteps > 0 Or intBHSteps <= MAXBHHOME Then
                            ''                func_SetLastBhPos(intBHSteps)
                            ''            End If
                            ''        End If
                            ''    End If
                            ''End If

                            '---written on 30.04.10
                            gobjClsAAS203.funcLoadLastOptimizedConditions(False)
                            func_N2_FLAME_ON = flag1
                            Call gobjMessageAdapter.CloseStatusMessageBox()
                            Application.DoEvents()

                            '---commented by Deepak on 30.04.10
                            ''mobjCommdll.subTime_Delay(100)
                            ''gobjMessageAdapter.CloseStatusMessageBox()


                            '---code from 16 bit software
                            'if (flag2&& nvs<3.0*NVRED){
                            '	Wprintf(hdc, 21, 20, " Setting Last conditions   ........     ");
                            '//	NV_RotateAnticlock_Steps(abs(nvs-Inst.Nvstep));
                            '	SetLastFuel(nvs);
                            'If (intflag2 And nvSteps < 3.0 * NVRED) Then
                            ' Sets the steps for last saving fuel setting 
                            '---------------------------------------

                            '---commented by Deepak on 30.04.10
                            '''If nvSteps < 3.5 * NVRED And nvSteps > NVRED Then
                            '''    'Wprintf(hdc, 21, 20, " Setting Last conditions   ........     ");
                            '''    gobjMessageAdapter.ShowStatusMessageBox(" Setting Last conditions   ........     ", strNAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
                            '''    Call gobjClsAAS203.funcSetLastFuel(nvSteps)
                            '''    'If intnvs < 3.5 * NVRED And intnvs > NVRED Then
                            '''    'funcSet_Last_Fuel(intnvs)
                            '''    'End If
                            '''    func_N2_FLAME_ON = flag1
                            '''    'gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                            '''    'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
                            '''    'Else

                            '''    '  func_N2_FLAME_ON = True
                            '''    'End If
                            '''    Call gobjMessageAdapter.CloseStatusMessageBox()
                            '''    Application.DoEvents()
                            '''End If

                        End If
                        '//------------------------

                        'If intnvs < 3.5 * NVRED And intnvs > NVRED Then
                        '    funcSet_Last_Fuel(intnvs)
                        'End If


                        '//------------------------
                    End If

                Else
                    func_N2_FLAME_ON = False
                    gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                    'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
                End If
            Else
                func_N2_FLAME_ON = False
                'gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
            End If
            Call gobjMessageAdapter.CloseStatusMessageBox()
            Application.DoEvents()
            Return flag1
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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_AA_FLAME_OFF() As Boolean
        '--------------------------------------------------------------------------
        'Procedure Name         :   func_AA_FLAME_OFF
        'Description            :   To set AA Flame off
        'Parameters             :   None
        'Retrun                 :   True if successed received byte from communication
        'Time/Date              :   17.11.06
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :   2
        'Revision by Person     :   Mangesh on 23-Apr-2007
        '--------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        'BOOL(AA_FLAME_OFF())
        '{
        '   Save_NV_Pos();
        '   Transmit(AAOFF, 0,0, 0);
        '   #If NEWHANDSHAKE Then
        '       Recev(TRUE);
        '   #End If
        '   return OFF;
        '}

        Try
            ' gblnInComm = True          '10.12.07

            Call mobjCommdll.subTime_Delay(1000)
            Application.DoEvents()

            '***************************************
            '---Added by Mangesh on 23-Apr-2007
            '***************************************
            'before make AA Falme off Save the NV position 
            Call funcSave_NV_Pos()
            '***************************************
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'send the command for AA Flae off AAOFF(44)
            If FuncTransmitCommand(EnumAAS203Protocol.AAOFF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                        Return False
                    Else
                        Return True
                    End If
                Else
                    gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
                    Return False
                End If
            Else
                Return False
                'gobjMessageAdapter.ShowMessage(constErrorFlameOFF)
            End If

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
            gblnInComm = False
            Call mobjCommdll.subTime_Delay(1000)
            Call Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    'Public Function func_AA_FLAME_ON_1() As Boolean
    '    '-----------------------------------  Procedure Header  -------------------------------
    '    'Procedure Name         :   func_AA_FLAME_OFF
    '    'Description            :   To set AA Flame off
    '    'Parameters             :   None
    '    'Time/Date              :   21.12.06
    '    'Dependencies           :   
    '    'Author                 :   Sachin Dokhale
    '    'Revision               :
    '    'Revision by Person     :
    '    '--------------------------------------------------------------------------------------
    '    Dim objwait As New CWaitCursor
    '    Dim bytArray(7) As Byte
    '    func_AA_FLAME_ON = False
    '    '     

    '    'BOOL(AA_FLAME_ON())
    '    '{
    '    'HWND			hwnd;
    '    'unsigned    oldTout;
    '    'HDC			hdc;
    '    'BOOL 			flag1= FALSE,flag2=FALSE;
    '    'int   		nvs;
    '    'double     bh=0.0;
    '    ' if (GetInstrument()==AA202)
    '    '	return TRUE;

    '    '#ifndef	DEMO
    '    ' if (Ignite_Test()!=GREEN)
    '    '	 return FALSE;
    '    '#End If


    '    ' if( InstType == AA202)
    '    '	 hwnd = Create_Window(NULL, 250, 100, "AA-202  AA FLAME");
    '    '                Else
    '    '	 hwnd = Create_Window(NULL, 250, 100, "AA-203  AA FLAME");
    '    ' hdc=GetDC(hwnd);
    '    ' Get_NV_Pos();
    '    ' if (Inst.Nvstep>4000){
    '    '  NV_HOME();
    '    '  Get_NV_Pos();
    '    ' }
    '    ' if (Inst.Nvstep< ( (int) (2.0* (double) (NVRED)) ) || Inst.Nvstep> ( (int) (2.5* (double) (NVRED))) ) {
    '    '	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
    '    '                            If (Inst.Nvstep < 2 * NVRED) Then
    '    '		NV_RotateAnticlock_Steps(abs(NVRED*2-Inst.Nvstep));
    '    '                            Else
    '    '	  NV_RotateClock_Steps(abs(Inst.Nvstep-NVRED*2));
    '    '  }
    '    ' else
    '    '	Wprintf(hdc, 21, 20, " Setting Optimised AA  flame ...");
    '    ' Wprintf(hdc, 21, 20, "       AA IGNITION                       ");
    '    ' Transmit(AAON, 0,0, 0);
    '    ' oldTout=Tout;
    '    ' Tout=VERY_LONG_DEALY; 
    '    ' Recev(TRUE);
    '    ' Tout=oldTout;
    '    ' Beep();Beep();
    '    ' switch(Param1)  {
    '    '	case 0 : Wprintf(hdc, 21, 20, "       Blue FLAME SET  ........");
    '    '				flag1 = TRUE; break;
    '    '	case 1 : Gerror_message(" AAFLAME ERROR \n AA BURNER NOT CONNECTED "); break;
    '    '	case 2 : Gerror_message(" AAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
    '    '	case 3 : Gerror_message(" AAFLAME ERROR \n DOOR NOT CLOSED "); break;
    '    '	case 4 : Gerror_message(" AAFLAME ERROR \n AIR PRESSURE LOW "); break;
    '    '	case 5 : Gerror_message(" AAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
    '    '	case 6 : Gerror_message(" AAFLAME ERROR \n AUTO IGNITION ERROR "); break;
    '    '	case 7 : if(!HydrideMode){
    '    '					Gerror_message(" AAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
    '    '				}
    '    '                                Else
    '    '					flag1 = TRUE;
    '    '				 break;
    '    '	case 8 : if(!HydrideMode){
    '    '					Gerror_message(" AAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
    '    '				}
    '    '                                    Else
    '    '				 flag1 = TRUE;
    '    '				 break;
    '    '	case 11: Gerror_message(" AAFLAME ERROR \n Error while setting max. fuel ");
    '    '				break;
    '    '  }

    '    ' nvs=Load_NV_Pos();
    '    ' Get_NV_Pos();
    '    '#If DEMO Then
    '    '	flag1=TRUE;
    '    '#End If
    '    'If (flag1) Then
    '    '		flag2=TRUE;
    '    ' if(flag2){
    '    '	 switch(CheckNvBurFiles()){
    '    '		case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
    '    '					 flag2 = FALSE;
    '    '		break;
    '    '		case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
    '    '					 flag2 = FALSE;
    '    '		break;
    '    '		case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
    '    '					 flag2 = FALSE;
    '    '		break;
    '    '	 }
    '    ' }
    '    ' if (flag2){
    '    '	 Wprintf(hdc, 21, 20, " Setting Last conditions   .......       ");
    '    '	 pc_delay(10000);    pc_delay(10000);    pc_delay(10000);

    '    '#If !GRAPHITE Then
    '    '	 if(Load_BH_Pos()!=-1){
    '    '		 if (Commflag){
    '    '			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
    '    '			  BH_HOME();
    '    '			else{
    '    '			  SetLastBhPos(Inst.Bhstep);
    '    '			}
    '    '		}
    '    '	 }
    '    '#End If

    '    '	 if (nvs<3.5*NVRED && nvs>NVRED){ //MAXNVHOME*NVRED
    '    '		  SetLastFuel(nvs);   
    '    '	  }
    '    '	}
    '    ' ReleaseDC(hwnd, hdc);
    '    ' Close_Window(hwnd, NULL);
    '    ' return flag1;
    '    '}

    '    Try
    '        '//------ Tobe required perform
    '        'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.AAON, 0, 0, 0) Then
    '        If FuncTransmitCommand(EnumAAS203Protocol.AAON, 0, 0, 0) Then

    '            'mobjCommdll.subTime_Delay(5000)
    '            'If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
    '            If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
    '                If bytArray(1) <> 1 Then
    '                    func_AA_FLAME_ON = False
    '                    gobjMessageAdapter.ShowMessage(constErrorFlameON)
    '                    'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
    '                Else
    '                    func_AA_FLAME_ON = True
    '                End If

    '            Else
    '                func_AA_FLAME_ON = False
    '                gobjMessageAdapter.ShowMessage(constErrorFlameON)
    '                'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
    '            End If
    '        Else
    '            func_AA_FLAME_ON = False
    '            gobjMessageAdapter.ShowMessage(constErrorFlameON)
    '            'gFuncShowMessage("Error...", "Error setting Flame OFF.", EnumMessageType.Information)
    '        End If

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    '        Return False
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objwait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Function

    Public Function func_AA_FLAME_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_AA_FLAME_ON
        'Description            :   To set AA flame ON
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   16.02.07
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :   Mangesh on 16.02.07
        '--------------------------------------------------------------------------------------
        Dim objwait As New CWaitCursor
        Dim bytArray(7) As Byte
        func_AA_FLAME_ON = False
        Dim flag1 As Boolean = False
        Dim flag2 As Boolean = False
        Dim intNvs As Integer
        Dim bh As Double = 0.0
        'BOOL(AA_FLAME_ON())
        '{
        'HWND			hwnd;
        'unsigned    oldTout;
        'HDC			hdc;
        'BOOL 			flag1= FALSE,flag2=FALSE;
        'int   		nvs;
        'double     bh=0.0;
        ' if (GetInstrument()==AA202)
        '	return TRUE;

        '#ifndef	DEMO
        ' if (Ignite_Test()!=GREEN)
        '	 return FALSE;
        '#End If

        ' if( InstType == AA202)
        '	 hwnd = Create_Window(NULL, 250, 100, "AA-202  AA FLAME");
        '                Else
        '	 hwnd = Create_Window(NULL, 250, 100, "AA-203  AA FLAME");

        ' hdc=GetDC(hwnd);
        ' Get_NV_Pos();
        ' if (Inst.Nvstep>4000){
        '  NV_HOME();
        '  Get_NV_Pos();
        ' }
        ' if (Inst.Nvstep< ( (int) (2.0* (double) (NVRED)) ) || Inst.Nvstep> ( (int) (2.5* (double) (NVRED))) ) {
        '	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
        '                            If (Inst.Nvstep < 2 * NVRED) Then
        '		NV_RotateAnticlock_Steps(abs(NVRED*2-Inst.Nvstep));
        '                            Else
        '	  NV_RotateClock_Steps(abs(Inst.Nvstep-NVRED*2));
        '  }
        ' else
        '	Wprintf(hdc, 21, 20, " Setting Optimised AA  flame ...");
        ' Wprintf(hdc, 21, 20, "       AA IGNITION                       ");
        ' Transmit(AAON, 0,0, 0);
        ' oldTout=Tout;
        ' Tout=VERY_LONG_DEALY; 
        ' Recev(TRUE);
        ' Tout=oldTout;
        ' Beep();Beep();

        ' switch(Param1)  {
        '	case 0 : Wprintf(hdc, 21, 20, "       Blue FLAME SET  ........");
        '				flag1 = TRUE; break;
        '	case 1 : Gerror_message(" AAFLAME ERROR \n AA BURNER NOT CONNECTED "); break;
        '	case 2 : Gerror_message(" AAFLAME ERROR \n FILL WATER IN TRAP AND RETRY "); break;
        '	case 3 : Gerror_message(" AAFLAME ERROR \n DOOR NOT CLOSED "); break;
        '	case 4 : Gerror_message(" AAFLAME ERROR \n AIR PRESSURE LOW "); break;
        '	case 5 : Gerror_message(" AAFLAME ERROR \n FUEL PRESSURE LOW  "); break;
        '	case 6 : Gerror_message(" AAFLAME ERROR \n AUTO IGNITION ERROR "); break;
        '	case 7 : if(!HydrideMode){
        '					Gerror_message(" AAFLAME ERROR \n YELLOW FLAME NOT OBTAINABLE ");
        '				}
        '                                Else
        '					flag1 = TRUE;
        '				 break;
        '	case 8 : if(!HydrideMode){
        '					Gerror_message(" AAFLAME ERROR \n BLUE FLAME NOT OBTAINABLE ");
        '				}
        '                                    Else
        '				 flag1 = TRUE;
        '				 break;
        '	case 11: Gerror_message(" AAFLAME ERROR \n Error while setting max. fuel ");
        '				break;
        '  }

        ' nvs=Load_NV_Pos();
        ' Get_NV_Pos();
        '#If DEMO Then
        '	flag1=TRUE;
        '#End If
        'If (flag1) Then
        '		flag2=TRUE;
        ' if(flag2){
        '	 switch(CheckNvBurFiles()){
        '		case 1:if(MessageBox(hwnd,"Do you want to load the last optimised fuel conditions from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
        '					 flag2 = FALSE;
        '		break;
        '		case 2:if(MessageBox(hwnd,"Do you want to load the last optimised burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
        '					 flag2 = FALSE;
        '		break;
        '		case 3:if(MessageBox(hwnd,"Do you want to load the last optimised fuel condition and burner position from the method?","Optimisation",MB_ICONQUESTION | MB_YESNO) == IDNO )
        '					 flag2 = FALSE;
        '		break;
        '	 }
        ' }
        ' if (flag2){
        '	 Wprintf(hdc, 21, 20, " Setting Last conditions   .......       ");
        '	 pc_delay(10000);    pc_delay(10000);    pc_delay(10000);

        '#If !GRAPHITE Then
        '	 if(Load_BH_Pos()!=-1){
        '		 if (Commflag){
        '			if (Inst.Bhstep<=0||Inst.Bhstep>MAXBHHOME)
        '			  BH_HOME();
        '			else{
        '			  SetLastBhPos(Inst.Bhstep);
        '			}
        '		}
        '	 }
        '#End If

        '	 if (nvs<3.5*NVRED && nvs>NVRED){ //MAXNVHOME*NVRED
        '		  SetLastFuel(nvs);   
        '	  }
        '	}
        ' ReleaseDC(hwnd, hdc);
        ' Close_Window(hwnd, NULL);
        ' return flag1;
        '}

        '''Dm objFrmManualIgnition As New frmManualIgnition

        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                Return True
            End If

            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                Dim intIgnite_Test As ClsAAS203.enumIgniteType
                If gobjClsAAS203.funcIgnite_Test(intIgnite_Test) Then
                    If intIgnite_Test = ClsAAS203.enumIgniteType.Green Then
                        Return False
                    End If
                End If
            End If

            gblnInComm = False
            ' Get the NV Steps
            Call funcGet_NV_Pos()
            'check Inst object NV steps for garbage value when steps are grater than 4000
            ' then Set Needle valve to home position
            ' then get Needle valve positions
            If gobjInst.NvStep > 4000 Then
                funcSetNV_HOME()
                funcGet_NV_Pos()
            End If

            'Dim strAAFlameMessageCaption As String  '05.11.09
            'If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
            '    If gstructSettings.NewModelName = False Then  '---21.07.09
            '        strAAFlameMessageCaption = "AA-201  AA FLAME"
            '    Else
            '        strAAFlameMessageCaption = "AA-301  AA FLAME"
            '    End If
            'Else
            '    If gstructSettings.NewModelName = False Then  '---21.07.09
            '        strAAFlameMessageCaption = "AA-203  AA FLAME"
            '    Else
            '        strAAFlameMessageCaption = "AA-303  AA FLAME"
            '    End If
            'End If


            Dim strAAFlameMessageCaption As String  '05.11.09
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                If gstructSettings.NewModelName = False Then  '---21.07.09
                    strAAFlameMessageCaption = "AA-201  AA FLAME"
                Else
                    strAAFlameMessageCaption = "AA-301  AA FLAME"
                End If
            ElseIf gstructSettings.AppMode = EnumAppMode.FullVersion_203 Then
                If gstructSettings.NewModelName = False Then  '---21.07.09
                    strAAFlameMessageCaption = "AA-203  AA FLAME"
                Else
                    strAAFlameMessageCaption = "AA-303  AA FLAME"
                End If
            Else
                If gstructSettings.NewModelName = False Then
                    strAAFlameMessageCaption = "AA-203D  AA FLAME"
                Else
                    strAAFlameMessageCaption = "AA-303D  AA FLAME"
                End If
            End If

            ' if (Inst.Nvstep< ( (int) (2.0* (double) (NVRED)) ) || Inst.Nvstep> ( (int) (2.5* (double) (NVRED))) ) {
            '	Wprintf(hdc, 21, 20, " Setting Fuel Please  Wait ....");
            '                            If (Inst.Nvstep < 2 * NVRED) Then
            '		NV_RotateAnticlock_Steps(abs(NVRED*2-Inst.Nvstep));
            '                            Else
            '	  NV_RotateClock_Steps(abs(Inst.Nvstep-NVRED*2));
            '  }

            ' Validate the NV Steps
            If (gobjInst.NvStep < CInt(2.0 * NVRED)) Or (gobjInst.NvStep > CInt(2.5 * NVRED)) Then
                Call gobjMessageAdapter.ShowStatusMessageBox("Setting Fuel Please  Wait ....", strAAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000, True)
                Application.DoEvents()

                If gobjInst.NvStep < (2 * NVRED) Then
                    Call funcNV_RotateAntiClock_Steps(Math.Abs((NVRED * 2) - gobjInst.NvStep))
                Else
                    Call funcNV_RotateClock_Steps(Math.Abs(gobjInst.NvStep - (NVRED * 2)))
                End If
            Else
                Call gobjMessageAdapter.UpdateStatusMessageBox("Setting Optimised AA  flame ...", strAAFlameMessageCaption)
                Application.DoEvents()
            End If

            Call gobjMessageAdapter.UpdateStatusMessageBox("  AA Ignition  ", strAAFlameMessageCaption)

            Application.DoEvents()

            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = True Then   '10.12.07
                ' after optimise steps for NV Send the command for AA On
                If FuncTransmitCommand(EnumAAS203Protocol.AAON, 0, 0, 0) Then
                    Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
                    If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            func_AA_FLAME_ON = False
                            gobjMessageAdapter.ShowMessage(constErrorFlameON)
                        Else

                            'Call gobjMessageAdapter.CloseStatusMessageBox()
                            ' Check for flame setting and if not get success the display proper message
                            Select Case bytArray(2)
                                Case 0
                                    'gobjMessageAdapter.ShowMessage(constBlueFlameSet)
                                    gobjfrmStatus.FlameType = ClsAAS203.enumIgniteType.Blue
                                    gobjMessageAdapter.UpdateStatusMessageBox("Blue FLAME SET  ........", strAAFlameMessageCaption)
                                    Application.DoEvents()
                                    gobjCommProtocol.mobjCommdll.subTime_Delay(600)
                                    flag1 = True
                                Case 1
                                    gobjMessageAdapter.ShowMessage(constAABurnerNotConnected)
                                    Application.DoEvents()

                                Case 2
                                    gobjMessageAdapter.ShowMessage(constFillWaterTrap)
                                    Application.DoEvents()

                                Case 3
                                    gobjMessageAdapter.ShowMessage(constAADoorNotCLosed)
                                    Application.DoEvents()

                                Case 4
                                    gobjMessageAdapter.ShowMessage(constAAAirPressureLow)
                                    Application.DoEvents()

                                Case 5
                                    gobjMessageAdapter.ShowMessage(constAAFuelPressureLow)
                                    Application.DoEvents()

                                Case 6
                                    gobjMessageAdapter.ShowMessage(constAAAutoIgnitionError)
                                    Application.DoEvents()

                                Case 7
                                    If gobjInst.Hydride = False Then
                                        gobjMessageAdapter.ShowMessage(constAAYellowFlameNotObtainable)
                                        Application.DoEvents()
                                    Else
                                        flag1 = True
                                    End If

                                Case 8
                                    If gobjInst.Hydride = False Then
                                        gobjMessageAdapter.ShowMessage(constAABlueFlameNotObtainable)
                                        Application.DoEvents()
                                    Else
                                        flag1 = True
                                    End If

                                Case 11
                                    gobjMessageAdapter.ShowMessage(constAAErrorSettingMaxFuel)
                                    Application.DoEvents()
                                Case Is > 11
                                    flag1 = False
                                Case Else
                                    '****************************************************
                                    '---Case Else Added by Mangesh as sometimes it is 
                                    '---returning value of  greater then 11 
                                    '****************************************************
                                    'flag1 = True  'commented by deepak on 28.12.08
                                    '****************************************************
                            End Select

                            gblnInComm = False

                            '---Added by deepak on 29.12.08
                            gobjClsAAS203.funcCheck_Flame()
                            '------------

                            'gobjCommProtocol.mobjCommdll.subTime_Delay(500)
                            Call gobjMessageAdapter.CloseStatusMessageBox()
                            ' after flame setting get the NV steps from instrument
                            intNvs = funcLoad_NV_Pos()
                            funcGet_NV_Pos()
                            Call gobjMessageAdapter.CloseStatusMessageBox()
                            'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                            If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                                (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                                flag1 = True
                            End If

                            If flag1 = True Then
                                flag2 = True
                            End If

                            '---------29.12.08
                            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                            gobjClsAAS203.funcCheck_Flame(flag2)
                            gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                            '---------

                            ' Check NV Burner setting when flame gets proper On 
                            ' display message
                            If flag2 = True Then
                                ' ask for to load previous condition

                                '---commented on 30.04.10
                                ''Select Case funcCheckNVBurFiles()
                                ''    Case 1
                                ''        If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelConditions) = False Then
                                ''            flag2 = False
                                ''        End If
                                ''        Application.DoEvents()
                                ''        Exit Select
                                ''    Case 2
                                ''        If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedBurnerConditions) = False Then
                                ''            flag2 = False
                                ''        End If
                                ''        Application.DoEvents()
                                ''        Exit Select
                                ''    Case 3
                                ''        If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) = False Then
                                ''            flag2 = False
                                ''        End If
                                ''        Application.DoEvents()
                                ''        Exit Select
                                ''End Select

                                '---written on 30.04.10
                                If gobjClsAAS203.funcCheckPresenceOfLastFuelConditions() = True Then
                                    If gobjMessageAdapter.ShowMessage(constLoadLastOptimisedFuelNBurnerConditions) = False Then
                                        flag2 = False
                                    End If
                                    Application.DoEvents()
                                Else
                                    flag2 = False
                                End If
                            End If

                            Dim intBHSteps As Integer
                            Dim intNVSteps As Integer

                            If flag2 Then
                                'Check and follow the steps for Setting Last conditions   
                                gobjMessageAdapter.ShowStatusMessageBox("Setting Last conditions   .......       ", strAAFlameMessageCaption, MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000)
                                mobjCommdll.subTime_Delay(100)

                                '---commented on 30.04.10
                                ''If Not Graphite Then
                                ''    intBHSteps = FuncLoad_BH_Pos()
                                ''    If Not intBHSteps = -1 Then
                                ''        'gobjInst.BhStep = intBHPosition
                                ''        If gobjInst.BhStep <= 0 Or gobjInst.BhStep > MAXBHHOME Then
                                ''            funcSetBH_HOME()
                                ''        Else
                                ''            If intBHSteps > 0 Or intBHSteps <= MAXBHHOME Then
                                ''                func_SetLastBhPos(intBHSteps)
                                ''            End If
                                ''        End If
                                ''    End If
                                ''End If
                                ''mobjCommdll.subTime_Delay(50)
                                ''If intNvs < (3.5 * NVRED) And intNvs > NVRED Then
                                ''    funcSet_Last_Fuel(intNvs)
                                ''End If

                                '---written on 30.04.10
                                gobjClsAAS203.funcLoadLastOptimizedConditions(True)


                                gobjMessageAdapter.CloseStatusMessageBox()
                            End If
                        End If
                    Else
                        func_AA_FLAME_ON = False
                        gobjMessageAdapter.ShowMessage(constErrorFlameON)
                        Application.DoEvents()
                    End If
                Else
                    func_AA_FLAME_ON = False
                    'gobjMessageAdapter.ShowMessage(constErrorFlameON)
                    'Application.DoEvents()
                End If
            End If
            Call gobjMessageAdapter.CloseStatusMessageBox()
            Application.DoEvents()

            Return flag1

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
            objwait.Dispose()
            'If Not objFrmManualIgnition Is Nothing Then
            '    objFrmManualIgnition.Close()
            '    objFrmManualIgnition.Dispose()
            'End If
            gblnInComm = False
            gobjMessageAdapter.CloseStatusMessageBox()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_N2O_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_N2O_ON
        'Description            :   To set N2O on
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   28-11-06
        'Dependencies           :   
        'Author                 :   Saurabh S
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objwait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    gblnInComm = False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send the command for N2O fuel On N2OON(31)
            If FuncTransmitCommand(EnumAAS203Protocol.N2OON, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_N2O_ON = False
                        gobjMessageAdapter.ShowMessage(constN2O_ON)
                        Application.DoEvents()
                    Else
                        func_N2O_ON = True
                    End If
                Else
                    func_N2O_ON = False
                    gobjMessageAdapter.ShowMessage(constN2O_ON)
                    Application.DoEvents()
                End If
            Else
                func_N2O_ON = False
                'gobjMessageAdapter.ShowMessage(constN2O_ON)
                'Application.DoEvents()
            End If

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
            objwait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_N2O_OFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_N2O_OFF
        'Description            :   To set N2O off
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   28-11-06
        'Dependencies           :   
        'Author                 :   Saurabh S.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objwait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    gblnInComm = False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send the command for N2O fuel Off N2OON(31)
            If FuncTransmitCommand(EnumAAS203Protocol.N2OOFF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_N2O_OFF = False
                        gobjMessageAdapter.ShowMessage(constN2O_OFF)
                        Application.DoEvents()
                    Else
                        If bytArray(2) = 0 Then
                            'func_N2O_OFF = False
                            Return False
                        Else
                            'func_N2O_OFF = True
                            Return True
                        End If
                    End If
                Else
                    'func_N2O_OFF = False
                    Return False
                    gobjMessageAdapter.ShowMessage(constN2O_OFF)
                    Application.DoEvents()
                End If
            Else
                'func_N2O_OFF = False
                Return False
                'gobjMessageAdapter.ShowMessage(constN2O_OFF)
                'Application.DoEvents()
            End If

        Catch threadex As Threading.ThreadAbortException
            Return False
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
            'objwait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_FUEL_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_FUEL_ON
        'Description            :   To set FUEL ON
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   29-11-06
        'Dependencies           :   
        'Author                 :   Saurabh S.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' gblnInComm = True          '10.12.07
            ' Send the command for Fuel On FUELON(35)
            If FuncTransmitCommand(EnumAAS203Protocol.FUELON, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_FUEL_ON = False
                        gobjMessageAdapter.ShowMessage(constFUEL_ON)
                        Application.DoEvents()
                    Else
                        func_FUEL_ON = True
                    End If
                Else
                    func_FUEL_ON = False
                    gobjMessageAdapter.ShowMessage(constFUEL_ON)
                    Application.DoEvents()
                End If
            Else
                func_FUEL_ON = False
                'gobjMessageAdapter.ShowMessage(constFUEL_ON)
                'Application.DoEvents()
            End If

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_FUEL_OFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_FUEL_OFF
        'Description            :   To set FUEL OFF
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   29-11-06
        'Dependencies           :   
        'Author                 :   Saurabh S.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send the command for Fuel Off FUELOFF(36)
            If FuncTransmitCommand(EnumAAS203Protocol.FUELOFF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_FUEL_OFF = False
                        gobjMessageAdapter.ShowMessage(constFUEL_OFF)
                        Application.DoEvents()
                    Else
                        func_FUEL_OFF = True
                    End If
                Else
                    func_FUEL_OFF = False
                    gobjMessageAdapter.ShowMessage(constFUEL_OFF)
                    Application.DoEvents()
                End If
            Else
                func_FUEL_OFF = False
                'gobjMessageAdapter.ShowMessage(constFUEL_OFF)
                'Application.DoEvents()
            End If

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
            'If Not objWait Is Nothing Then
            '    objWait.Dispose()
            'End If
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_IGNITE_ON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_IGNITE_ON
        'Description            :   To IGNITE ON
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   29-11-06
        'Dependencies           :   
        'Author                 :   Saurabh S.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send the command for Ignition On IGNITEON(39)
            If FuncTransmitCommand(EnumAAS203Protocol.IGNITEON, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_IGNITE_ON = False
                        gobjMessageAdapter.ShowMessage(constIGNITE_ON)
                        Application.DoEvents()
                    Else
                        func_IGNITE_ON = True
                    End If
                Else
                    func_IGNITE_ON = False
                    gobjMessageAdapter.ShowMessage(constIGNITE_ON)
                    Application.DoEvents()
                End If
            Else
                func_IGNITE_ON = False
                'gobjMessageAdapter.ShowMessage(constIGNITE_ON)
                'Application.DoEvents()
            End If

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function func_IGNITE_OFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   func_IGNITE_OFF
        'Description            :   To IGNITE OFF
        'Parameters             :   None
        'Return                 :   True if successed received byte from communication
        'Time/Date              :   29-11-06
        'Dependencies           :   
        'Author                 :   Saurabh S.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send the command for Ignition Off IGNITEOFF(40)
            If FuncTransmitCommand(EnumAAS203Protocol.IGNITEOFF, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        func_IGNITE_OFF = False
                        gobjMessageAdapter.ShowMessage(constIGNITE_OFF)
                        Application.DoEvents()
                    Else
                        func_IGNITE_OFF = True
                    End If
                Else
                    func_IGNITE_OFF = False
                    gobjMessageAdapter.ShowMessage(constIGNITE_OFF)
                    Application.DoEvents()
                End If
            Else
                func_IGNITE_OFF = False
                'gobjMessageAdapter.ShowMessage(constIGNITE_OFF)
                'Application.DoEvents()
            End If

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSetD2Cur(ByVal intD2Cur As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSet_D2_Cur
        ' Parameters Passed     : intD2Cur
        ' Returns               : Boolean
        ' Purpose               : Set the D2 Current 
        'Return                 : True if successed received byte from communication  
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokahle
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim bytLow, bytHigh As Byte
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If

            ' if (dcur>=100 && dcur<=300){
            '	 Inst.D2cur=dcur;
            '	 D2_ON();
            '	 Transmit(D2CUR, (BYTE)(Inst.D2cur), (BYTE) (Inst.D2cur>>8), 0);
            '#If NEWHANDSHAKE Then
            '	  Recev(TRUE);
            '#End If
            '//  c = D2CUR;  trans(c);  c = d2cur;  trans(c);  c = d2cur>>8;  trans(c);
            '	 if (dcur==100)
            '		D2_OFF();
            '	}
            'Validate to the parameter value from 100 to 300 current   
            'If (intD2Cur >= 100) And (intD2Cur <= 300) Then  '---02.06.09 'on 100 ma d2 curr relay sound was coming
            If (intD2Cur > 100) And (intD2Cur <= 300) Then    '---02.06.09
                gobjInst.D2Current = intD2Cur
                gobjCommProtocol.D2_ON()
                ' gblnInComm = True          '10.12.07
                gFunclongtobyte(intD2Cur, bytHigh, bytLow)

                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.D2CUR, bytHigh, bytLow, 0) Then
                ' Send the Command for D2 current with high byte and low byte
                If FuncTransmitCommand(EnumAAS203Protocol.D2CUR, bytHigh, bytLow, 0) Then
                    'If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            funcSetD2Cur = False
                            'MessageBox.Show("error")
                            gobjMessageAdapter.ShowMessage(constErrorSettingD2Current)
                            Application.DoEvents()
                        Else
                            funcSetD2Cur = True
                        End If
                    Else
                        gobjMessageAdapter.ShowMessage(constErrorSettingD2Current)
                        'MessageBox.Show("error: funcSetD2Cur in Receive Data")
                        Application.DoEvents()
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(constErrorSettingD2Current)
                    'MessageBox.Show("error: funcSetD2Cur in Transmit")
                    Application.DoEvents()
                End If
                gblnInComm = False
                ' Check for D2 current for 100 if it is then makes D2 Off for 100 
                If (intD2Cur = 100) Then
                    gobjCommProtocol.D2_OFF()
                End If
            End If

            If (intD2Cur = 100) Then  '---02.06.09    'on 100 ma d2 curr relay sound was coming
                gobjCommProtocol.D2_OFF()
            End If

            Return funcSetD2Cur

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcNV_RotateClock_Steps(ByVal intNVSteps As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcSet_D2_Cur
        ' Parameters Passed     : intD2Cur
        ' Returns               : Boolean
        ' Purpose               : Rotate NV to Clockwise no of Steps
        ' Return                : True if successed received byte from communication
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokahle
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim bytLow, bytHigh As Byte
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            gFunclongtobyte(intNVSteps, bytLow, bytHigh)
            ' Rotate needle valve to Anticlock Steps for given stpes NVCLKSTEPS(61)
            If FuncTransmitCommand(EnumAAS203Protocol.NVCLKSTEPS, bytHigh, bytLow, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    funcNV_RotateClock_Steps = True
                End If
            Else
                'MessageBox.Show("error: NV_RotateClock_Steps in Transmit")
                'Application.DoEvents()
            End If
            gblnInComm = False
            Call gobjCommProtocol.funcGet_NV_Pos()

            Return funcNV_RotateClock_Steps

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcNV_Rotate_Clock() As Boolean
        '=====================================================================
        ' Procedure Name        : funcNV_Rotate_Clock
        ' Parameters Passed     : None
        ' Returns               : True if successed received byte from communication
        ' Purpose               : 
        ' Description           : Rotate NV to Clockwise for a step
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokahle
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Rotate needle valve to Anticlock Step NVCLOCK(26)
            If FuncTransmitCommand(EnumAAS203Protocol.NVCLOCK, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    funcNV_Rotate_Clock = True
                End If
            Else
                'MessageBox.Show("error: funcNV_Rotate_Clock in Transmit")
                'Application.DoEvents()
                Return False
            End If

            Return funcNV_Rotate_Clock

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcNV_Rotate_AntiClock() As Boolean
        '=====================================================================
        ' Procedure Name        : funcNV_Rotate_AntiClock
        ' Parameters Passed     : None
        ' Returns               : True if successed received byte from communication
        ' Purpose               : Rotate NV to Anticlockwise for a step
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokahle
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Rotate needle valve to Anticlock Step NVANTI(25)
            If FuncTransmitCommand(EnumAAS203Protocol.NVANTI, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    funcNV_Rotate_AntiClock = True
                End If
            Else
                'MessageBox.Show("error: funcNV_Rotate_AntiClock in Transmit")
                'Application.DoEvents()
                Return False
            End If

            Return funcNV_Rotate_AntiClock

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcNV_RotateAntiClock_Steps(ByVal intNVSteps As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        : funcNV_Rotate_AntiClock
        ' Parameters Passed     : None
        ' Returns               : True if successed received byte from communication
        ' Purpose               : Rotate NV to Anticlockwise Steps
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokahle
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow, bytHigh As Byte

        Try
            ' Transmit(NVANTISTEPS, (BYTE) (steps>>8), (BYTE) (steps), 0);
            ' Recev(TRUE);
            '#If DEMO Then
            '	 NVpos+=steps;
            '#End If
            ' Get_NV_Pos();

            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            gFunclongtobyte(intNVSteps, bytLow, bytHigh)
            ' Rotate needle valve to Anticlock Steps for given no of steps NVANTISTEPS(60)
            If FuncTransmitCommand(EnumAAS203Protocol.NVANTISTEPS, bytHigh, bytLow, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    funcNV_RotateAntiClock_Steps = True
                End If
            Else
                '---ToDo change message box
                'MessageBox.Show("error: funcNV_RotateAntiClock_Steps in Transmit")
                'Application.DoEvents()
                Return False
            End If
            gblnInComm = False
            ' Get the NV position
            Call gobjCommProtocol.funcGet_NV_Pos()

            Return funcNV_RotateAntiClock_Steps

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
            objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcIsD2GainOn() As Integer
        '=====================================================================
        ' Procedure Name        : funcIsD2GainOn
        ' Parameters Passed     : None
        ' Returns               : Integer
        ' Purpose               : 
        ' Description           : Return the D2 Gain status
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokahle
        ' Created               : 19.12.06
        ' Revisions             : 
        '=====================================================================
        Try
            'Return the D2 Gain status
            Return mintSSGain

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return &H0
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcNVScanSteps(ByVal intNVScanSteps As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcNVScanSteps
        'Description            :   To Optimise the Fuel        
        'Parameters             :   intSteps : turret to be rotate by this num 
        'Return                 :   True if successed transmit data
        'Time/Date              :   25.12.06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale 
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim bytNVSCANSTEP As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            gFunclongtobyte(intNVScanSteps, bytHigh, bytLow)
            'bytLow = intSteps And &HFF
            'bytHigh = CByte(intSteps >> 8)
            bytNVSCANSTEP = CByte(CONST_NVSCANSTEP)

            '//-------------- For Temp Purpose
            'Transmit(BHSCAN, (BYTE)(xvalmax), (BYTE) (xvalmax>>8), (BYTE) BHSCANSTEP);
            'gobjCommProtocol.gFunclongtobyte(intBHScanSteps, bytHigh, bytLow)
            ''bytLow = intSteps And &HFF
            ''bytHigh = CByte(intSteps >> 8)
            'bytNVSCANSTEP = CByte(CONST_NVSCANSTEP)

            'If FuncTransmitCommand(EnumAAS203Protocol.BHSCAN, bytHigh, bytLow, bytNVSCANSTEP) Then
            '//---------------
            '	Transmit(NVSCAN, (BYTE)(xvalmin), (BYTE) (xvalmin>>8), (BYTE) NVSCANSTEP);
            'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.NVSCAN, bytHigh, bytLow, bytNVSCANSTEP) Then
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            mobjCommdll.IsNeedReceive = False
            ' Send the command for Optimise the Fuel NVSCAN (65)
            If FuncTransmitCommand(EnumAAS203Protocol.NVSCAN, bytHigh, bytLow, bytNVSCANSTEP) Then
                clsRS232Main.gblnInCommProcess = False
                'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.SPECT, bytLow, bytHigh, bytSpeed) Then
                funcNVScanSteps = True
                'gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
            Else
                funcNVScanSteps = False
                'gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                'Application.DoEvents()
            End If

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
            gblnInComm = False
            Application.DoEvents()
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcBHSCAN(ByVal intBHScanSteps As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcBHSCAN
        'Description            :   To Optimise burner height        
        'Parameters             :   intBHScanSteps : turret to be rotate by this num 
        'Return                 :   True if successed, transmit data.
        'Time/Date              :   25.12.06
        'Dependencies           :   
        'Author                 :   Sachin Dokhale 
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim bytNVSCANSTEP As Byte

        Try
            'If gblnInComm = True Then
            '    Return False
            'End If
            ' gblnInComm = True          '10.12.07

            gFunclongtobyte(intBHScanSteps, bytHigh, bytLow)

            'bytLow = intSteps And &HFF
            'bytHigh = CByte(intSteps >> 8)
            bytNVSCANSTEP = CByte(CONST_BHSCANSTEP)
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            mobjCommdll.IsNeedReceive = False
            ' send the command for Optimise burner height BHSCAN(64)
            If FuncTransmitCommand(EnumAAS203Protocol.BHSCAN, bytHigh, bytLow, bytNVSCANSTEP) Then
                clsRS232Main.gblnInCommProcess = False
                funcBHSCAN = True
                'gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                Application.DoEvents()
            Else
                funcBHSCAN = False
                'gobjMessageAdapter.ShowMessage(constRotateStepsTurClkError)
                'Application.DoEvents()
            End If

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
            gblnInComm = False
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcRotate_Wv_Clock_Steps(ByVal intWvNo_steps As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcRotate_Wv_Clock_Steps
        'Description            :   To Rotate Wv to clock wise
        'Parameters             :   intWvNo_steps : no of Wv Steps to be rotate by this num 
        'Return                 :   True if success
        'Time/Date              :   10.01.07
        'Dependencies           :   
        'Author                 :   Sachin Dokhale 
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------

        '===========================
        'void	S4FUNC Rotate_Wv_Clock_Steps(int no_steps)
        '{
        'int	i;
        ' for(i=0; i<no_steps; i++){
        '	Rotate_Clock_Wv();
        '	pc_delay(200);
        '	}
        '}
        Dim objWait As New CWaitCursor
        Dim intIndex As Integer

        Try
            ' Rorate the clock wise Wv for given stpes
            For intIndex = 0 To intWvNo_steps - 1
                Call funcRotate_Clock_Wv()
                'pc_delay(200);
                'mobjCommdll.subTime_Delay(20)
            Next

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
            objWait.Dispose()
            'gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGet_Pneum_Status() As Byte
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcGet_Pneum_Status
        'Description            :   To get the pnueumatics status
        'Parameters             :   None
        'Return                 :   Byte if successed received byte from communication
        'Time/Date              :   01.02.07
        'Dependencies           :   
        'Author                 :   Deepak B.
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        '    BYTE	GET_PNEUM_STATUS()
        '{
        '  Transmit(PNEMSTATUS, 0, 0 , 0);
        ' Recev(TRUE);
        'return Param1;
        '}
        Try
            'If gblnInComm = True Then
            '    Exit Function
            'End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            'send the command for the pnueumatics status PNEMSTATUS(41)
            If FuncTransmitCommand(EnumAAS203Protocol.PNEMSTATUS, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        '---ToDo Message 
                        'gobjMessageAdapter.ShowMessage(constAirOn)
                        'Application.DoEvents()
                    Else
                        Return bytArray(2)
                    End If
                Else
                    '---ToDo Message 
                    'gobjMessageAdapter.ShowMessage(constAirOn)
                    'Application.DoEvents()
                End If
            Else
                '---ToDo Message 
                'gobjMessageAdapter.ShowMessage(constAirOn)
                'Application.DoEvents()
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
            'objWait.Dispose()
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    '//----- This fucntion is use for Demo Mode
    Public Function funcpmtAd() As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcGet_Pneum_Status
        'Description            :   This function is use for Demo mode to read PMT
        'Parameters             :   None
        'Time/Date              :   03.02.07
        'Dependencies           :   
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor

        Try
            '#If DEMO Then
            'int	pmtAd(void)
            '{
            'double	abs=0;
            'int	ad;
            '	 abs = (Inst.Pmtv)*1.0/500.0;
            ' ad = (int) ((double)2047.0+ abs*(double)4096.0/(double)5.0);
            ' ad+=random(100);
            'return ad;
            '}
            '#End If

            Dim dblabs As Double = 0
            Dim intad As Integer
            ' Add the ramdomely value of PMT
            dblabs = (gobjInst.PmtVoltage) * 1.0 / 500.0
            intad = CInt(2047.0 + dblabs * 4096.0 / 5.0)
            intad += bytRandom.Next(100)

            Return intad

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
        '//-----

    End Function
    '//-----

    Private Function funcLoad_NV_Pos() As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcLoad_NV_Pos
        'Description            :   To load needle valve position 
        'Parameters             :   None
        'Return                 :   integer Get from file system
        'Time/Date              :   04.02.07
        'Dependencies           :   
        'Author                 :   
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'int Load_NV_Pos()
        '{
        'FILE    *stream;
        'char    fname[20];
        'int	  NV;
        'char line7[80];

        'sprintf(fname,"%s.nvp",mname); 

        'stream = fopen(fname, "rb");
        '   if (stream !=NULL){
        '       if (fread(&NV , sizeof(NV), 1, stream)==0)
        '	        NV=0;
        '	    fclose(stream);
        '}
        'return NV;
        '}
        Dim intNV As Integer
        Dim objWait As New CWaitCursor
        Dim file As System.IO.StreamReader
        Dim words As String

        Try
            ' Load needle valve position value from file system
            file = New System.IO.StreamReader(Application.StartupPath & "\nv.nvp")
            words = file.ReadToEnd()
            intNV = CInt(Trim(words))
            Return intNV

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
            file.Close()
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSave_NV_Pos() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSave_NV_Pos
        'Description            :   To save needle valve position value
        'Parameters             :   None
        'Return                 :   True if successed Write into file system
        'Time/Date              :   23-Apr-2007
        'Dependencies           :   
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------

        '*********************************************************************
        '---- ORIGINAL CODE
        '*********************************************************************
        'void Save_NV_Pos()
        '{
        '	FILE    *stream;
        '	char    fname[20];

        '   If (!strcmpi(mname, "")) Then
        '	    return;

        '   If (Inst.Nvstep < NVRED) Then
        '		return;

        '	//sprintf(fname,"NV%-s.pos",Inst.El);
        '	sprintf(fname,"%s.nvp",mname); // removed by sss for storing the nv pos against method dt 23/11/2000
        '	stream = fopen(fname, "wb");
        '	if (stream != NULL)
        '	{
        '		fwrite(&Inst.Nvstep, sizeof(Inst.Nvstep), 1, stream);
        '		fclose(stream);
        '	}
        '}
        '*********************************************************************
        Dim objWait As New CWaitCursor
        Dim file As System.IO.StreamWriter

        Try
            ' save needle valve position value into file system
            If (gobjInst.NvStep < NVRED) Then
                Return False
            End If

            file = New System.IO.StreamWriter(Application.StartupPath & "\nv.nvp", False)
            Call file.Write(gobjInst.NvStep)

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
            If Not (file Is Nothing) Then
                file.Close()
            End If
            file = Nothing
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSave_BH_Pos() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcSave_BH_Pos
        'Description            :   To save burner height position value
        'Parameters             :   None
        'Return                 :   True if successed Write into file system
        'Time/Date              :   04-Jul-2007
        'Dependencies           :   
        'Author                 :   Sachin Dokhale
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------

        '*********************************************************************
        '---- ORIGINAL CODE
        '*********************************************************************
        '        void S4FUNC Save_BH_Pos()
        '{
        '#If !GRAPHITE Then
        'FILE    *stream;
        'char    fname[20];
        ' if(!strcmpi(mname,""))
        '	return;
        ' if (Inst.Bhstep>MAXBHHOME)
        '	 return ;
        ' sprintf(fname,"%s.bhp",mname);
        ' stream = fopen(fname, "wb");
        ' if (stream != NULL){
        '	fwrite(&Inst.Bhstep, sizeof(Inst.Bhstep), 1, stream);
        '	fclose(stream);
        '  }
        '#End If
        '}
        '*********************************************************************
        Dim objWait As New CWaitCursor
        Dim file As System.IO.StreamWriter

        Try
            file = New System.IO.StreamWriter(Application.StartupPath & "\bh.bhp", False) 'code added by dinesh wagh on 22.3.2009

            ' save burner height position value into file system
            If gobjInst.BhStep > MAXBHHOME Then
                Return True
            End If

            'file = New System.IO.StreamWriter(Application.StartupPath & "\bh.bhp", False) 'code commented by dinesh wagh on 22.3.2009
            Call file.Write(gobjInst.BhStep)

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
            If Not file Is Nothing Then
                file.Close()
                file = Nothing
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcCheckNVBurFiles() As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcCheckNVBurFiles
        'Description            :   To check nv and bhp files
        'Parameters             :   None
        'Return                 :   Integer 
        'Time/Date              :   04.02.07
        'Dependencies           :   
        'Author                 :   
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'Int(CheckNvBurFiles(void))
        '{
        'FILE  *stream=NULL;
        'char  fname[20];
        'int   flag=0;
        'sprintf(fname,"%s.nvp",mname);
        'stream = fopen(fname, "rb");
        'if(stream){
        '	flag = 1;
        '	fclose(stream);
        '	stream=NULL;
        '}
        'sprintf(fname,"%s.bhp",mname);
        'stream = fopen(fname, "rb");
        'if(stream){
        '                If (flag) Then
        '	  flag = 3;
        '                Else
        '	  flag = 2;
        '	fclose(stream);
        '	stream=NULL;
        '}
        'return flag;
        '}

        Dim intFlag As Integer
        Dim objWait As New CWaitCursor
        Dim f As System.IO.File
        Dim flStream As System.IO.FileStream

        Try
            ' Get NV position from file system
            flStream = f.Open(Application.StartupPath & "\nv.nvp", IO.FileMode.Open)

            If Not flStream Is "" Then
                intFlag = 1
                flStream.Close()
            End If
            ' Get BH position from file system and set flag
            flStream = f.Open(Application.StartupPath & "\bh.bhp", IO.FileMode.Open)

            If Not flStream Is "" Then
                If intFlag Then
                    intFlag = 3
                Else
                    intFlag = 2
                End If
                flStream.Close()
            End If

            Return intFlag

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function FuncLoad_BH_Pos() As Integer
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   FuncLoad_BH_Pos
        'Description            :   To Read Burner height from file system
        'Parameters             :   None
        'Return                 :   Integer
        'Time/Date              :   04.02.07
        'Dependencies           :   
        'Author                 :   Deepak Bhati
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'int Load_BH_Pos()
        '{
        'FILE    *stream;
        'char    fname[20];
        'int	  BH=-1;

        ' sprintf(fname,"%s.bhp",mname);
        ' stream = fopen(fname, "rb");
        ' if (stream !=NULL){
        '  if(fread(&BH, sizeof(BH), 1, stream)==0)
        '	  BH=-1;
        '            Else
        '	  Inst.Bhstep = BH;
        '  fclose(stream);
        ' }
        'return BH;
        '}
        Dim intBH As Integer
        Dim objWait As New CWaitCursor
        Dim file As System.IO.StreamReader
        Dim words As String

        Try
            ' Read Burner height from file system
            intBH = -1
            file = New System.IO.StreamReader(Application.StartupPath & "\bh.bhp")
            words = file.ReadToEnd()

            If Not Trim(words) = "" Then
                intBH = Val(Trim(words))
            Else
                intBH = -1
            End If

            Return intBH

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return -1
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            file.Close()
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_Last_Fuel(ByVal intNvs As Integer) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   FuncLoad_BH_Pos
        'Description            :   To Set Fuel conditions for given steps
        'Parameters             :   intNvs as NV steps
        'Return                 :   True if success
        'Time/Date              :   04.02.07
        'Dependencies           :   
        'Author                 :   Deepak Bhati
        'Revision               :
        'Revision by Person     :
        '--------------------------------------------------------------------------------------
        'void SetLastFuel( int nvs )
        '{
        'int	k;
        'Get_NV_Pos();
        '        If (Inst.Nvstep < nvs) Then
        '  NV_RotateAnticlock_Steps(abs(nvs-Inst.Nvstep));
        '        Else
        '  NV_RotateClock_Steps(abs(Inst.Nvstep-nvs));
        ' Get_NV_Pos();
        '}
        Dim intK As Integer
        Dim objWait As New Common.CWaitCursor

        Try
            ' Set Fuel conditions for given steps
            funcGet_NV_Pos()

            If gobjInst.NvStep < intNvs Then
                funcNV_RotateAntiClock_Steps(Math.Abs(intNvs - gobjInst.NvStep))
            Else
                funcNV_RotateClock_Steps(Math.Abs(gobjInst.NvStep - intNvs))
            End If

            funcGet_NV_Pos()

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Private Function FuncAIR_N2O() As Boolean
        '=====================================================================
        ' Procedure Name        : FuncAIR_N2O
        ' Parameters Passed     : None
        ' Returns               : True if success
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 19.08.07
        ' Revisions             : 
        '=====================================================================
        '        BOOL(AIR_N2O())
        '{
        ' if (GetInstrument()==AA202){
        '	AIR_OFF();
        '	return TRUE;
        '	}
        ' else{

        ' Transmit(AIRN2O, 0,0, 0);
        '#If NEWHANDSHAKE Then
        ' Recev(TRUE);
        '#End If
        ' }
        ' return ON;
        '}
        Dim bytArray(7) As Byte
        Try
            ' Send the comm. for Air N2O AIRN2O(37)
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                funcAir_OFF()
                Return True
            Else
                ' gblnInComm = True          '10.12.07
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                If FuncTransmitCommand(EnumAAS203Protocol.AIRN2O, 0, 0, 0) Then
                    'clsRS232Main.gblnInCommProcess = False
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then

                    End If
                    clsRS232Main.gblnInCommProcess = False

                End If
            End If
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
            gblnInComm = False
        End Try
    End Function

    Private Function FuncN2O_AIR() As Boolean
        '=====================================================================
        ' Procedure Name        : FuncN2O_AIR
        ' Parameters Passed     : None
        ' Returns               : True if success
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 19.08.07
        ' Revisions             : 
        '=====================================================================
        '        BOOL(N2O_AIR())
        '{
        ' if (GetInstrument()==AA202){
        '	AIR_ON();
        '	return TRUE;
        '  }
        'Transmit(N2OAIR, 0,0, 0);
        '#If NEWHANDSHAKE Then
        ' Recev(TRUE);
        '#End If
        ' return ON;
        '}
        Dim bytArray(7) As Byte
        Try
            'Set Air on for 201
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                funcAir_ON()
                Return True
            End If
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            ' Send command for N2O Air (N2OAIR 38)
            If FuncTransmitCommand(EnumAAS203Protocol.N2OAIR, 0, 0, 0) Then
                'clsRS232Main.gblnInCommProcess = False
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then

                End If
                clsRS232Main.gblnInCommProcess = False
            Else
                Return False            '10.12.07
            End If

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
            gblnInComm = False
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSwitchOver() As Boolean
        '=====================================================================
        ' Procedure Name        : funcSwitchOver
        ' Parameters Passed     : None
        ' Returns               : True if success
        ' Purpose               : To Switch to N20 Flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 19.08.07
        ' Revisions             : 
        '=====================================================================
        '        int    S4FUNC Switch_Over()
        '{
        'if (Inst.N2of) {
        '  if (Inst.Na) { AIR_N2O(); Inst.Na = OFF; }
        '  else { N2O_AIR(); Inst.Na = ON;}
        ' }
        'else Gerror_message(" Available only for N-A FLAME");
        'return TRUE;
        '}
        Try
            ' Switch over from Air to N2O or visa. vasa.
            If gobjInst.N2of = True Then
                If gobjInst.Na = True Then
                    gobjCommProtocol.FuncAIR_N2O()
                    gobjInst.Na = False
                Else
                    gobjCommProtocol.FuncN2O_AIR()
                    gobjInst.Na = True
                End If
            Else
                gobjMessageAdapter.ShowMessage("Available only for N-A FLAME", "Warning", MessageHandler.clsMessageHandler.enumMessageType.WarningMessage)
            End If

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

#Region " Analysis Related Communication Functions "

    Public Function ReadADCforFilter() As Integer
        '=====================================================================
        ' Procedure Name        : ReadADCforFilter
        ' Parameters Passed     : None
        ' Returns               : Integer value of ADCount
        ' Purpose               : Read ADC value from instrument.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 11-Jan-2007
        ' Revisions             : 1
        '=====================================================================
        '*******************************************************
        '---ORIGINAL CODE
        '*******************************************************
        'int	S4FUNC ReadADCforFilter()
        '{
        '   int	avg, adval;
        '   avg = Inst.Avg;
        '   Inst.Avg = 5;
        '   adval = ReadADCFilter();
        '#If DEMO Then
        '	adval = pmtAd()+random(10);
        '#End If
        '   Inst.Avg = avg;
        '   return adval;
        '}
        '*******************************************************
        Dim objWait As New CWaitCursor
        Dim intAverage, intADCValue As Integer

        Try
            ' Read ADC Value
            intAverage = gobjInst.Average

            gobjInst.Average = 5

            Call funcReadADCFilter(gobjInst.Average, intADCValue)

            '#If DEMO Then
            '	adval = pmtAd() + random(10);
            '#End If

            gobjInst.Average = intAverage

            Return intADCValue

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
            objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Function

    'Public Function ReadADCFilter() As Integer
    '    '=====================================================================
    '    ' Procedure Name        : ReadADCFilter
    '    ' Parameters Passed     : None
    '    ' Returns               : Integer value of ADCount
    '    ' Purpose               : 
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : Mangesh Shardul
    '    ' Created               : 11-Jan-2007
    '    ' Revisions             : 1
    '    '=====================================================================

    '    Try

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try
    'End Function

#End Region

#End Region

#Region " Communication Error Handling Functions "

    'Private Sub mobjCommdll_CommError(ByVal intErrorCode As RS232SerialComm.clsRS232Main.CommErrorCode) Handles mobjCommdll.CommError
    '    Dim objWait As New CWaitCursor
    '    Try
    '        Select Case intErrorCode
    '            Case RS232SerialComm.clsRS232Main.CommErrorCode.CommNotOpen
    '                gobjMessageAdapter.ShowMessage(constCommPortError)
    '                Application.DoEvents()
    '                'Commflag = False
    '        End Select

    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        objWait.Dispose()
    '        Application.DoEvents()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

#End Region

#Region " AutoSampler Utility Functions "

    Public Function funcAutoSamplerHome() As Boolean
        '=====================================================================
        ' Procedure Name        : funcNV_Rotate_AntiClock
        ' Parameters Passed     : None
        ' Returns               : Boolean
        ' Purpose               : Rotate NV to Anticlock
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokahle
        ' Created               : 25.11.06
        ' Revisions             : 
        '=====================================================================
        'funcAutoSamplerHome = False
        'Dim bytx As Byte
        'Try
        '    'To add the code for sampler home
        '    ' gstructAutoSampler.blnCommunication = True

        '    gFuncTransmitByte2(Asc("H"))
        '    gFuncReceiveByte2(bytx, glng_LongDelay)
        '    If bytx = Asc("1") Then
        '        'gstructAutoSampler.intCoordinateX = 0
        '        'gstructAutoSampler.intCoordinateY = 0
        '        funcAutoSamplerHome = True
        '    End If

        Dim bytRecievedData As Byte

        Try
            ' gblnInComm = True          '10.12.07
            Application.DoEvents()
            If FuncTransmitCommand2(EnumAutoSampler.Home) Then
                If FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY) Then
                    gstructAutoSampler.intCoordinateX = 0
                    gstructAutoSampler.intCoordinateY = 0
                    Return True
                End If
            Else
                MessageBox.Show("error: funcAutoSamplerHome in Transmit")
                Application.DoEvents()
                Return False
            End If

            Return False

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Friend Function funcAutoSamplerGoTo(ByVal bytX As Byte, ByVal bytY As Byte, ByVal structAutoSamplerIn As structAutoSampler) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :gfuncAutoSamplerGoTo
        'Description	    :To Position the sampler to spesified Position 
        'Parameters 	    :None
        'Time/Date  	    :23.02.07
        'Dependencies	    :
        'Author		        :Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim bytRecievedData As Byte

        Try
            ' gblnInComm = True          '10.12.07

            'To add the code for sampler home
            Application.DoEvents()
            If structAutoSamplerIn.intCoordinateX = bytX And structAutoSamplerIn.intCoordinateY = bytY Then
                funcAutoSamplerGoTo = True
                Exit Function
            End If

            'gFuncTransmitByte2(Asc("G"))
            If FuncTransmitCommand2(EnumAutoSampler.GoToXY) Then

                'subTime_Delay(100)
                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(100) 'added by pankaj on 25 Mar 08
                'If bytX > 9 Then
                FuncTransmitCommand2(bytX + Asc("0"))
                'subTime_Delay(100)
                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(100) 'added by pankaj on 25 Mar 08
                'Else
                '    gFuncTransmitByte2(Asc(bytX.ToString))
                '    subTime_Delay(100)
                'End If

                FuncTransmitCommand2(Asc(bytY.ToString))
                'subTime_Delay(100)
                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
                Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(100) 'added by pankaj on 25 Mar 08
                'gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
                If FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY) Then
                    If bytRecievedData = Asc("1") Then
                        'gstructAutoSampler.intCoordinateX = bytX
                        'gstructAutoSampler.intCoordinateY = bytY
                        funcAutoSamplerGoTo = True
                    End If
                End If
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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAutoSamplerProbeDown() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :gfuncAutoSamplerProbeDown
        'Description	    :
        'Parameters 	    :None
        'Time/Date  	    :23.02.07
        'Dependencies	    :
        'Author		        :Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim bytRecievedData As Byte

        Try
            ' gblnInComm = True          '10.12.07

            'To add the code for sampler home
            'gFuncTransmitByte2(Asc("D"))
            'gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
            ''Timedelay is provided for keeping
            ''the probe down for Provided Time
            ''subTime_Delay(gstructAutoSampler.intProbeTime * 1000)
            'Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intProbeTime * 1000)
            'If bytRecievedData = Asc("1") Then
            '    funcAutoSamplerProbeDown = True
            'End If

            If FuncTransmitCommand2(EnumAutoSampler.ProbeDown) Then
                'Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intProbeTime * 1000)
                Call gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(gstructAutoSampler.intProbeTime * 1000)  'added by pankaj on 25 Mar 08
                If FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY) Then
                    If bytRecievedData = Asc("1") Then
                        funcAutoSamplerProbeDown = True
                    End If
                End If
            Else
                MessageBox.Show("error: funcAutoSamplerProbeDown in Transmit")
                Application.DoEvents()
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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAutoSamplerProbeUp() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :gfuncAutoSamplerProbeUp
        'Description	    :To Position the sampler Probe to upward Position 
        'Parameters 	    :None
        'Time/Date  	    :23.02.07
        'Dependencies	    :
        'Author		        :Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim bytRecievedData As Byte

        Try
            ' gblnInComm = True          '10.12.07

            'To add the code for sampler home
            'gFuncTransmitByte2(Asc("U"))
            'gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
            'If bytRecievedData = Asc("1") Then
            '    funcAutoSamplerProbeUp = True
            'End If


            If FuncTransmitCommand2(EnumAutoSampler.ProbeUp) Then
                If FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY) Then
                    funcAutoSamplerProbeUp = True
                End If
            Else
                MessageBox.Show("error: funcAutoSamplerProbeUp  in Transmit")
                Application.DoEvents()
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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAutoSamplerPumpOFF() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :gfuncAutoSamplerPumpOFF
        'Description	    :
        'Parameters 	    :None
        'Time/Date  	    :23.02.07
        'Dependencies	    :
        'Author		        :Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim bytRecievedData As Byte

        Try
            ' gblnInComm = True          '10.12.07

            'To add the code for sampler home
            'gFuncTransmitByte2(Asc("F"))
            'gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
            'If bytRecievedData = Asc("1") Then
            '    funcAutoSamplerPumpOFF = True
            'End If

            If FuncTransmitCommand2(EnumAutoSampler.PumpOFF) Then
                If FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY) Then
                    If bytRecievedData = Asc("1") Then
                        funcAutoSamplerPumpOFF = True
                    End If
                End If
            Else
                MessageBox.Show("error: funcAutoSamplerPumpOFF in Transmit")
                Application.DoEvents()
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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAutoSamplerPumpON() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :gfuncAutoSamplerPumpON
        'Description	    :
        'Parameters 	    :None
        'Time/Date  	    :23.02.07
        'Dependencies	    :
        'Author		        :Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim bytRecievedData As Byte

        Try
            ' gblnInComm = True          '10.12.07

            'To add the code for sampler home
            'gFuncTransmitByte2(Asc("O"))
            'gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
            'If bytRecievedData = Asc("1") Then
            '    funcAutoSamplerPumpON = True
            'End If

            If FuncTransmitCommand2(EnumAutoSampler.PumpON) Then
                If FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY) Then
                    If bytRecievedData = Asc("1") Then
                        funcAutoSamplerPumpON = True
                    End If
                End If
            Else
                MessageBox.Show("error: funcAutoSamplerPumpON  in Transmit")
                Application.DoEvents()
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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcAutoSamplerPumpONRev() As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name	    :gfuncAutoSamplerPumpONRev
        'Description	    :
        'Parameters 	    :None
        'Time/Date  	    :23.02.07
        'Dependencies	    :
        'Author		        :Sachin Dokhale
        'Revision		    :
        'Revision by Person	:
        '--------------------------------------------------------------------------------------
        Dim bytRecievedData As Byte
        Try
            ' gblnInComm = True          '10.12.07

            'To add the code for sampler home
            'gFuncTransmitByte2(Asc("V"))
            'gFuncReceiveByte2(bytRecievedData, glng_LongDelay)
            'If bytRecievedData = Asc("1") Then
            '    funcAutoSamplerPumpONRev = True
            'End If

            If FuncTransmitCommand2(EnumAutoSampler.PumpONRev) Then
                If FuncReceiveData2(bytRecievedData, CONST_LONG_DELAY) Then
                    If bytRecievedData = Asc("1") Then
                        funcAutoSamplerPumpONRev = True
                    End If
                End If
            Else
                MessageBox.Show("error: funcAutoSamplerPumpONRev in Transmit")
                Application.DoEvents()
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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

#End Region

#Region " Functions for Double Beam "

    Public Function gFuncAnalogSelfTest_ReferenceBeam(ByVal intAvgOfADCReadings As Integer, Optional ByRef dblADCValue As Double = 0.0) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   gFuncAnalogSelfTest_ReferenceBeam
        'Description            :   To perform a test for ADC count and voltage. if voltage comes 
        '                           around 3000 mv then test is successful else test fails
        'Parameters             :   intAvgOfADCReadings,dblADCValue
        'Return                 :   True if success
        'Time/Date              :   14-Apr-2007
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim intADCFmv As Integer = 0

        Try
            If funcCalibrationMode(EnumCalibrationMode.SELFTEST, enumInstrumentBeamType.ReferenceBeam) Then
                If intAvgOfADCReadings = 1 Then
                    If funcReadADCFilter_ReferenceBeam(intAvgOfADCReadings, intADCFmv) Then
                        If intADCFmv = 5000 Then
                            Return False
                            gobjMessageAdapter.ShowMessage(constADCNonFilter)
                            Application.DoEvents()
                        Else
                            Return True
                        End If
                    Else
                        Return False
                    End If
                Else
                    If funcReadADCFilter_ReferenceBeam(intAvgOfADCReadings, intADCFmv) Then
                        If intADCFmv > 3255 And intADCFmv < 3296 Then
                            dblADCValue = intADCFmv
                            Return True
                        Else
                            Return False
                            gobjMessageAdapter.ShowMessage(constADCFilter)
                            Application.DoEvents()
                        End If
                    Else
                        Return False
                    End If
                End If
            Else
                Return False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcSet_PMTReferenceBeam(ByVal dblReferencePMTVoltage As Double) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcSet_PMTReferenceBeam
        'Description            :   To set PMT voltage for Reference Beam
        'Parameters             :   dblPMT : Reference PMT voltage to be set
        'Return                 :   True if success
        'Time/Date              :   06-Apr-2007
        'Dependencies           :   
        'Author                 :   Mangesh S.
        'Revision               :
        'Revision by Person     :   
        '------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim dbly1 As Double
        Dim inty As Integer
        Dim bytLow As Byte
        Dim bytHigh As Byte
        Dim intPMT As Integer
        '++++++++++++++++++++++++++++++++++++++++++++++
        'void	S4FUNC Set_PMT(double pmt) 
        '{
        'double	y1;
        'int	y;
        ' Inst.Pmtv = pmt;
        ' y1 = (double) ( (double) Inst.Pmtv*(double)4095.0/(double)1000.0);
        ' y = (int) y1;
        ' y = y & 0x0fff;
        ' Transmit(PMT, (BYTE) y, (BYTE) (y>>8), 0);
        ' pc_delay(1000);
        ' Recev(TRUE);
        '}
        '++++++++++++++++++++++++++++++++++++++++++++++
        Dim dblPMTTemp As Double

        Try
            'gobjInst.PmtVoltageReference = dblReferencePMTVoltage  '10.12.07

            dblPMTTemp = dblReferencePMTVoltage
            dblPMTTemp = dblPMTTemp * 4095.0 / 1000.0
            intPMT = CInt(dblPMTTemp)
            intPMT = CInt(intPMT And &HFFF)

            gFunclongtobyte(intPMT, bytLow, bytHigh)
            'bytLow = CByte(inty)
            'bytHigh = CByte(inty >> 8)
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.SETPMT_RB, bytLow, bytHigh, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        gobjMessageAdapter.ShowMessage(constPMTVolt)
                        Application.DoEvents()
                    Else
                        gobjInst.PmtVoltageReference = dblReferencePMTVoltage   '10.12.07
                        Return True
                    End If
                Else
                    gobjMessageAdapter.ShowMessage(constPMTVolt)
                    Application.DoEvents()
                End If
            Else
                'gobjMessageAdapter.ShowMessage(constPMTVolt)
                Application.DoEvents()
            End If

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
            gblnInComm = False
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcExitSlit_Home() As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcExitSlit_Home
        'Description            :   To make the Exit Slit indicater home        
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   06-Apr-2007
        'Dependencies           :   
        'Author                 :   Mangesh S.
        'Revision               :
        'Revision by Person     :   
        '------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim intErrorSlitHome As Integer
        Try
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                intErrorSlitHome = constErrorSlitHome
            Else
                intErrorSlitHome = constErrorExitSlitHome
            End If
            ' gblnInComm = True          '10.12.07

            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If

            If FuncTransmitCommand(EnumAAS203Protocol.SLIT_HOME_EXIT, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        'Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                        Call gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                        Application.DoEvents()
                    Else
                        If bytArray(2) Then
                            gobjInst.SlitPositionExit = 0
                            Return True
                        Else
                            'Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                            Call gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                            Application.DoEvents()
                            Return False
                        End If
                    End If
                Else
                    'Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                    Call gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                    Application.DoEvents()
                    Return False
                End If
            Else
                'Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                'Call gobjMessageAdapter.ShowMessage(intErrorSlitHome)
                Return False
            End If

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
            gblnInComm = False
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcEntryExitSlit_Home() As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcEntryExitSlit_Home
        'Description            :   To make the both Entry and Exit Slit indicater home        
        'Parameters             :   None
        'Return                 :   True if success
        'Time/Date              :   07-Apr-2007
        'Dependencies           :   
        'Author                 :   Mangesh S.
        'Revision               :
        'Revision by Person     :   
        '------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte

        Try
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.SLIT_HOME_DB, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                    Else
                        If bytArray(2) Then
                            gobjInst.SlitPositionExit = 0
                            Return True
                        Else
                            Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                            Application.DoEvents()
                            Return False
                        End If
                    End If
                Else
                    Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                    Application.DoEvents()
                    Return False
                End If
            Else
                'Call gobjMessageAdapter.ShowMessage(constErrorSlitHome)
                Return False
            End If

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
            gblnInComm = False
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcReadADCFilter_ReferenceBeam(ByVal intNumOfReadingsForAvg As Integer, ByRef intAvgInMv As Integer) As Boolean
        '--------------------------------------------------------------------------------------
        'Procedure Name         :   funcReadADCFilter_ReferenceBeam
        'Description            :   to read ADC count for filtered data for Reference Beam
        'Parameters             :   intNumOfReadingsForAvg : no of readings taken for averaging
        '                           [OUT] intAvgInmv : avg. of ADC count return
        'Return                 :   True if success
        'Time/Date              :   06-Apr-2007
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        '++++++++++++++++++++++++++
        'int	S4FUNC ReadADCFilter()
        '{
        'int  i=5000;

        ' if (Inst.Avg==1)
        '	return ReadADC();

        ' Transmit(ADCF, (BYTE) Inst.Avg, (BYTE) (Inst.Avg>>8), 0);
        '            If (Recev(True)) Then
        '	i = Param2*256 + Param1;
        '#If DEMO Then
        '  pc_delay(10000);   pc_delay(10000);
        '  pc_delay(10000);  pc_delay(10000);
        '	i= pmtAd()+random(10);
        '#End If
        '#If QDEMO Then
        '	i= pmtAd()+random(100);
        '#End If
        ' if (i==5000)
        '  Gerror_message_new("ADC Error ","System Error");
        'return(i);
        '}
        '++++++++++++++++++++++++++

        Try
            Call gFunclongtobyte(intNumOfReadingsForAvg, bytLow, bytHigh)

            'If gobjInst.Average = 1 Then
            '    Return funcReadADCNonFilter_ReferenceBeam(intAvgInMv)
            'End If
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.ADCFILTER_RB, bytLow, bytHigh, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        Return False
                        gobjMessageAdapter.ShowMessage(constADCFilter)
                        Application.DoEvents()
                    Else
                        intAvgInMv = bytArray(2) + (bytArray(3) * 256)
                        '//----- Added by Sachin Dokhale for Demo mode
                        '#If DEMO Then
                        '	i= pmtAd()+random(10);
                        '#End If
                        'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            intAvgInMv = funcpmtAd() + bytRandom.Next(10)
                        End If
                        '//-----
                        If intAvgInMv = 5000 Then
                            'MessageBox.Show("ADC Error", "System Error")
                            gobjMessageAdapter.ShowMessage(constADCFilter)
                        End If
                        Return True
                    End If
                Else
                    Return False
                    'gobjMessageAdapter.ShowMessage(constADCFilter) '28.09.07
                    'Application.DoEvents()                         '28.09.07
                End If
            Else
                Return False
                'gobjMessageAdapter.ShowMessage(constADCFilter) '28.09.07
                'Application.DoEvents()                         '28.09.07
            End If

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcReadADCFilter_DoubleBeam(ByVal intNumOfReadingsForAvg As Integer, ByRef intAvgInMv As Integer) As Boolean
        '--------------------------------------------------------------------------------------
        'Procedure Name         :   funcReadADCFilter_DoubleBeam
        'Description            :   to read ADC count for filtered data for Double Beam
        'Parameters             :   intNumOfReadingsForAvg : no of readings taken for averaging
        '                           [OUT] intAvgInmv : avg. of ADC count return
        'Return                 :   True if success
        'Time/Date              :   07-Apr-2007
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '--------------------------------------------------------------------------------------
        Dim bytArray(7) As Byte
        Dim bytLow As Byte
        Dim bytHigh As Byte
        '++++++++++++++++++++++++++
        'int	S4FUNC ReadADCFilter()
        '{
        'int  i=5000;

        ' if (Inst.Avg==1)
        '	return ReadADC();

        ' Transmit(ADCF, (BYTE) Inst.Avg, (BYTE) (Inst.Avg>>8), 0);
        '            If (Recev(True)) Then
        '	i = Param2*256 + Param1;
        '#If DEMO Then
        '  pc_delay(10000);   pc_delay(10000);
        '  pc_delay(10000);  pc_delay(10000);
        '	i= pmtAd()+random(10);
        '#End If
        '#If QDEMO Then
        '	i= pmtAd()+random(100);
        '#End If
        ' if (i==5000)
        '  Gerror_message_new("ADC Error ","System Error");
        'return(i);
        '}
        '++++++++++++++++++++++++++

        Try
            Call gFunclongtobyte(intNumOfReadingsForAvg, bytLow, bytHigh)

            'If gobjInst.Average = 1 Then
            '    Return funcReadADCNonFilter_ReferenceBeam(intAvgInMv)
            'End If
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.ADCFILTER_DB, bytLow, bytHigh, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        Return False
                        gobjMessageAdapter.ShowMessage(constADCFilter)
                        Application.DoEvents()
                    Else
                        intAvgInMv = bytArray(2) + (bytArray(3) * 256)
                        '//----- Added by Sachin Dokhale for Demo mode
                        '#If DEMO Then
                        '	i= pmtAd()+random(10);
                        '#End If
                        'If gstructSettings.AppMode = EnumAppMode.DemoMode Then
                        If (gstructSettings.AppMode = EnumAppMode.DemoMode) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_201) Or _
                            (gstructSettings.AppMode = EnumAppMode.DemoMode_203D) Then
                            intAvgInMv = funcpmtAd() + bytRandom.Next(10)
                        End If
                        '//-----
                        If intAvgInMv = 5000 Then
                            'MessageBox.Show("ADC Error", "System Error")
                            gobjMessageAdapter.ShowMessage(constADCFilter)

                        End If
                        Return True
                    End If
                Else
                    Return False
                    gobjMessageAdapter.ShowMessage(constADCFilter)
                    Application.DoEvents()
                End If
            Else
                Return False
                'gobjMessageAdapter.ShowMessage(constADCFilter)
                'Application.DoEvents()
            End If

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcReadADCforFilter_DoubleBeam() As Integer
        '=====================================================================
        ' Procedure Name        : funcReadADCforFilter_DoubleBeam
        ' Parameters Passed     : None
        ' Returns               : Integer value of ADCount
        ' Purpose               : Read ADC filter value for Double beam
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 07-Apr-2007
        ' Revisions             : 1
        '=====================================================================
        '*******************************************************
        '---ORIGINAL CODE
        '*******************************************************
        'int	S4FUNC ReadADCforFilter()
        '{
        '   int	avg, adval;
        '   avg = Inst.Avg;
        '   Inst.Avg = 5;
        '   adval = ReadADCFilter();
        '#If DEMO Then
        '	adval = pmtAd()+random(10);
        '#End If
        '   Inst.Avg = avg;
        '   return adval;
        '}
        '*******************************************************
        Dim objWait As New CWaitCursor
        Dim intAverage, intADCValue As Integer

        Try
            intAverage = gobjInst.Average

            gobjInst.Average = 5

            Call funcReadADCFilter_DoubleBeam(gobjInst.Average, intADCValue)

            gobjInst.Average = intAverage

            Return intADCValue

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetAbsOffset() As Boolean
        '=====================================================================
        ' Procedure Name        : funcGetAbsOffset
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : Set Abs offset 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 07-Apr-2007 04:25 pm
        ' Revisions             : 1
        '=====================================================================
        Dim bytArray(7) As Byte

        Try
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.GET_Absoffset, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        Call gobjMessageAdapter.ShowMessage(constErrorGettingAbsOffset)
                        Call Application.DoEvents()
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Call gobjMessageAdapter.ShowMessage(constErrorAbsReceiving)
                    Call Application.DoEvents()
                    Return False
                End If
            Else
                'Call gobjMessageAdapter.ShowMessage(constErrorAbsTransmit)
                'Call Application.DoEvents()
                Return False
            End If

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcGetRefBaseVal() As Boolean
        '=====================================================================
        ' Procedure Name        : funcGetRefBaseVal
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : Get the Ref. base value.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 07-Apr-2007 05:15 pm
        ' Revisions             : 1
        '=====================================================================
        Dim bytArray(7) As Byte

        Try
            ' gblnInComm = True          '10.12.07
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            If FuncTransmitCommand(EnumAAS203Protocol.Get_RefBaseVal, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        Call gobjMessageAdapter.ShowMessage(constErrorGettingAbsOffset)
                        Call Application.DoEvents()
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Call gobjMessageAdapter.ShowMessage(constErrorAbsReceiving)
                    Call Application.DoEvents()
                    Return False
                End If
            Else
                'Call gobjMessageAdapter.ShowMessage(constErrorAbsTransmit)
                'Call Application.DoEvents()
                Return False
            End If

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
            gblnInComm = False
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcResetReferenceBeam() As Boolean
        '=====================================================================
        ' Procedure Name        : funcResetReferenceBeam
        ' Parameters Passed     : None
        ' Returns               : True or false
        ' Purpose               : To initialise refernce beam monitoring controller
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 07-Apr-2007 05:15 pm
        ' Revisions             : 1
        '=====================================================================
        Dim bytArray(7) As Byte

        Try
            If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                Return False
            End If
            mobjCommdll.IsNeedReceive = False
            If FuncTransmitCommand(EnumAAS203Protocol.RESET_RB, 0, 0, 0) Then
                If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
                    If bytArray(1) <> 1 Then
                        'blnIsSingleBeam = True
                        Call gobjMessageAdapter.ShowMessage(constErrorInitRefBeam)
                        Call Application.DoEvents()
                        Return False
                    Else
                        'blnIsSingleBeam = False
                        Return True
                    End If
                Else
                    Call gobjMessageAdapter.ShowMessage(constErrorAbsReceiving)
                    Call Application.DoEvents()
                    Return False
                End If
            Else
                'Call gobjMessageAdapter.ShowMessage(constErrorAbsTransmit)
                'Call Application.DoEvents()
                Return False
            End If

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
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPosition_Slit_Exit(ByVal intSlit As Integer) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcPosition_Slit_Exit
        'Description            :   To position the slit at the said width
        'Parameters             :   intSlit : position at which slit to be adjusted
        'Return                 :   True if success
        'Time/Date              :   07-Apr-2007
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytSlitWidth1 As Byte
        Dim intSlitWidthError As Integer
        '------------------------
        'void   S4FUNC Position_Slit(int sw)
        '{
        'BYTE  sw1;
        'hold = Load_Curs();
        ' if (Inst.Slitpos!=sw) {
        '	 sw1 = (BYTE) sw;
        '	 Transmit(SLITPOS, sw1, 0 , 0);
        '	 Inst.Slitpos =sw;
        '	 Recev(TRUE);
        ' }
        'SetCursor(hold);
        '}
        '------------------------
        Try
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam Then
                intSlitWidthError = constSlitWidthError
            Else
                intSlitWidthError = constExitSlitWidthError
            End If

            If gobjInst.SlitPositionExit <> intSlit Then
                bytSlitWidth1 = CByte(intSlit)
                ' gblnInComm = True          '10.12.07
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                If FuncTransmitCommand(EnumAAS203Protocol.SLIT_POS_EXIT, bytSlitWidth1, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            gobjMessageAdapter.ShowMessage(intSlitWidthError)
                            Application.DoEvents()
                            Return False
                        Else
                            gobjInst.SlitPositionExit = intSlit
                            Return True
                        End If
                    Else
                        gobjMessageAdapter.ShowMessage(intSlitWidthError)
                        Application.DoEvents()
                        Return False
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(intSlitWidthError)
                    'Application.DoEvents()
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
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnInComm = False
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

    Public Function funcPosition_Slit_EntryExit(ByVal intSlit As Integer) As Boolean
        '---------------------------------------------------------------------------
        'Procedure Name         :   funcPosition_Slit_EntryExit
        'Description            :   To position the slit at the said width
        'Parameters             :   intSlit : position at which slit to be adjusted
        'Return                 :   True if success
        'Time/Date              :   07-Apr-2007
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '---------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim bytArray(7) As Byte
        Dim bytSlitWidth1 As Byte
        '------------------------
        'void   S4FUNC Position_Slit(int sw)
        '{
        'BYTE  sw1;
        'hold = Load_Curs();
        ' if (Inst.Slitpos!=sw) {
        '	 sw1 = (BYTE) sw;
        '	 Transmit(SLITPOS, sw1, 0 , 0);
        '	 Inst.Slitpos =sw;
        '	 Recev(TRUE);
        ' }
        'SetCursor(hold);
        '}
        '------------------------
        Try
            If gobjInst.SlitPosition <> intSlit Then
                bytSlitWidth1 = CByte(intSlit)
                ' gblnInComm = True          '10.12.07
                If mobjCommdll.gFuncResumeProcess = False Then   '10.12.07
                    Return False
                End If
                If FuncTransmitCommand(EnumAAS203Protocol.SLIT_POS_DB, bytSlitWidth1, 0, 0) Then
                    If FuncReceiveData(bytArray, CONST_LONG_DELAY) Then
                        If bytArray(1) <> 1 Then
                            gobjMessageAdapter.ShowMessage(constSlitWidthError)
                            Application.DoEvents()
                            Return False
                        Else
                            gobjInst.SlitPosition = intSlit
                            gobjInst.SlitPositionExit = intSlit
                            Return True
                        End If
                    Else
                        gobjMessageAdapter.ShowMessage(constSlitWidthError)
                        Application.DoEvents()
                        Return False
                    End If
                Else
                    'gobjMessageAdapter.ShowMessage(constSlitWidthError)
                    'Application.DoEvents()
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
            Return False
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            gblnInComm = False
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function

#End Region

#Region " Functions for AAS 201 "

    Public Function gFuncAnalogSelfTest_AA201(ByVal intAvgOfADCReadings As Integer, Optional ByRef dblADCValue As Double = 0.0) As Boolean
        '---------------------------------------------------------------------------------------
        'Procedure Name         :   gFuncAnalogSelfTest_AA201
        'Description            :   To perform a test for ADC count and voltage. if voltage comes 
        '                           around 3000 mv then test is successful else test fails
        'Parameters             :   intAvgOfADCReadings,dblADCValue
        'Retrun                 :   True if Comm. success
        'Time/Date              :   11-Apr-2007
        'Dependencies           :   obviously PC must communicate with Instrument through COM port
        'Author                 :   Mangesh Shardul
        'Revision               :
        'Revision by Person     :   
        '---------------------------------------------------------------------------------------
        Dim objWait As New CWaitCursor
        Dim intADCFmv As Integer = 0

        Try
            If funcCalibrationMode(EnumCalibrationMode.SELFTEST) Then
                If intAvgOfADCReadings = 1 Then
                    If funcReadADCNonFilter(intADCFmv) Then
                        If intADCFmv = 5000 Then
                            Return False
                            gobjMessageAdapter.ShowMessage(constADCNonFilter)
                            Application.DoEvents()
                        Else
                            Return True
                        End If
                    Else
                        Return False
                    End If
                Else
                    If funcReadADCFilter(intAvgOfADCReadings, intADCFmv) Then
                        If intADCFmv > 3000 And intADCFmv < 3296 Then
                            dblADCValue = intADCFmv
                            Return True
                        Else
                            Return False
                            gobjMessageAdapter.ShowMessage(constADCFilter)
                            Application.DoEvents()
                        End If
                    Else
                        Return False
                    End If
                End If
            Else
                Return False
            End If

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
            objWait.Dispose()
            Application.DoEvents()
            '---------------------------------------------------------
        End Try
    End Function


#End Region

End Class