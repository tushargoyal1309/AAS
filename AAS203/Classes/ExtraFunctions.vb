Public Class ExtraFunctions

    '#Region "Extra Functions"

    '    Private Function funcTurret_Optimise_rahul(ByVal dblLampCurrent As Double, ByVal intLampPos As Integer) As Boolean
    '        '------------------------------------------------------------------
    '        'Procedure Name         :   funcTurret_Optimise
    '        'Description            :   To optimise Turret position 
    '        'Parameters             :   dblLampCurrent = current to be set to lamp
    '        '                           intLampPos = lamp position to which current to be set
    '        'Time/Date              :   5/10/06
    '        'Dependencies           :   
    '        'Author                 :   Rahul B.
    '        'Revision               :
    '        'Revision by Person     :
    '        '--------------------------------------------------------------------------------------
    '        'Optimise Turret Steps:
    '        '1. Set Air Off
    '        '2. Find wv home
    '        '3. Turret Home
    '        '4. Position Turret to selected Turret No.
    '        '5. Set All Lamp Off
    '        '6. Set Current to HCL lamp selected.
    '        '7. Test if Lamp present then optimise turret
    '        '8. Set Air ON

    '        Try
    '            'mobjfrmturretOptimisation = New frmTurretOptimisation(dblLampCurrent, intLampPos)
    '            'mobjfrmturretOptimisation.StartOptimizeTread()

    '            ''following code is commented by deepak to implement thread mentioned above 

    '            '---1. Set Air Off
    '            Call funcAir_OFF()

    '            '---2. Find wv home
    '            If funcFind_Wavelength_Home() Then

    '                '---3. Turret Home
    '                '---check if old lamp posn not equal to current posn 
    '                '---then only perform gfuncTurretPosition
    '                Call gFuncTurret_Home()

    '                '4. Position Turret to selected Turret No.
    '                If gFuncTurret_Position(TURRET_6P_POS, intLampPos) Then
    '                    '--take lamp current from inst parameters and set it
    '                Else
    '                    'funcSet_Lamp = True
    '                End If

    '                '---5. Set All Lamp Off
    '                Call funcAll_Lamp_Off()

    '                '---6. Set Current to HCL lamp selected.
    '                If funcSet_HCL_Cur(dblLampCurrent, intLampPos) Then
    '                    'funcSet_Lamp = True
    '                Else
    '                    'funcSet_Lamp = False
    '                End If

    '                '---7. Test if Lamp present then optimise turret
    '                If funcTestLampPresence() Then
    '                    'call function to start thread in this object
    '                    'mobjfrmturretOptimisation.StartOptimizeTread()

    '                    If funcTur_Opt() Then
    '                        funcTurret_Optimise_rahul = True
    '                    Else
    '                        'MessageBox.Show(" Warning Lamp not Connected", "Turret Optimise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                        gobjMessageAdapter.ShowMessage(constLampNotConnected)
    '                        Application.DoEvents()
    '                        funcTurret_Optimise_rahul = False
    '                    End If
    '                End If
    '            Else
    '                funcTurret_Optimise_rahul = False
    '            End If

    '            '---8. Set Air ON
    '            Call funcAir_ON()

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Function

    '    Private Function funcTur_Opt_rahul() As Boolean
    '        '-----------------------------------  Procedure Header  -------------------------------
    '        'Procedure Name         :   funcTur_Opt
    '        'Description            :   To optimise turret
    '        'Parameters             :   None
    '        'Time/Date              :   5/10/06
    '        'Dependencies           :   
    '        'Author                 :   Rahul B.
    '        'Revision               :
    '        'Revision by Person     :
    '        '--------------------------------------------------------------------------------------
    '        Dim rPOs As Integer
    '        Dim intCounter As Integer
    '        Dim chNew As Integer
    '        Dim max_int As Integer
    '        Dim in_pos As Integer
    '        Try
    '            funcTur_Opt_rahul = False
    '            'Dim mobjfrmturretOptimisation As New frmTurretOptimisation
    '            'mobjfrmturretOptimisation = New frmTurretOptimisation
    '            'mobjfrmturretOptimisation.Show()
    '            gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE)
    '            rPOs = funcTur_Pre_Opt()
    '            '#If !NEWZERO Then
    '            'Adj_PMT_forvalue(hwnd, (double) 3500.0, (double)350);
    '            '#Else
    '            ' Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0 ), (double)350.0);
    '            '#End If
    '            'Show_Pmt(hwnd, Inst->Pmtv);
    '            'funcAdj_Pmt_ForValue(CDbl(3500.0), CDbl(350), False)
    '            'funcAdj_Pmt_ForValue(CDbl(3500.0 * 100.0 / 5000.0), CDbl(350.0), True)
    '            Application.DoEvents()
    '            funcAdj_Pmt_ForValue(CDbl(70.0), CDbl(350.0), True)
    '            mobjCommdll.subTime_Delay(200)
    '            For intCounter = 1 To rPOs + 10
    '                gobjCommProtocol.funcRotate_Anticlock_Tur()
    '            Next

    '            For intCounter = 1 To 10
    '                gobjCommProtocol.funcRotate_Clock_Tur()
    '            Next

    '            'Dim objfrmturretOptimisation As New frmTurretOptimisation
    '            'objfrmturretOptimisation.Show()
    '            'SetWindowText(hwnd,"OPTIMISING TURRET");
    '            'PeakGraph.Xmin= 1; PeakGraph.Xmax= RANGE;
    '            'PeakGraph.Ymin= GetEnergy(2047);
    '            'PeakGraph.Ymax= GetEnergy(2047.0+409.6*4);
    '            'strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"TURRET STEP");
    '            'Show_Peak_Param(hwnd, RANGE);
    '            'SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
    '            in_pos = 1
    '            max_int = 0

    '            gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)
    '            Application.DoEvents()
    '            For intCounter = 1 To RANGE
    '                gobjCommProtocol.funcRotate_Clock_Tur()
    '                'mobjCommdll.subTime_Delay(200)
    '                gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)
    '                If chNew > max_int Then
    '                    max_int = chNew
    '                    in_pos = intCounter
    '                End If

    '                '---deepak
    '                'Dim dbltest As Double
    '                'dbltest = gFuncGetEnergy(intCounter)
    '                '---deepak

    '                If intCounter = 1 Then
    '                    'GPlotInit(hdc, (double) i, GetEnergy(chnew))
    '                Else
    '                    'GPlot(hdc, (double) i, GetEnergy(chnew));
    '                End If

    '            Next


    '            'GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);
    '            'SetText(hwnd, IDC_STATUS," Positioning Please Wait  .......        ");
    '            '#If EMU Then
    '            ' Wait_For_Some_Msg(5);
    '            '#End If
    '            'mobjfrmturretOptimisation.Close()
    '            'mobjfrmturretOptimisation.Dispose()
    '            For intCounter = 1 To RANGE + 10
    '                gobjCommProtocol.funcRotate_Anticlock_Tur()
    '            Next

    '            For intCounter = 1 To 10 + in_pos
    '                gobjCommProtocol.funcRotate_Clock_Tur()
    '            Next

    '            funcTur_Opt_rahul = True
    '            'Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = in_pos;	//i-1;
    '            'for(i=0;i<500; i++)
    '            'pc_delay(10000);
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Function

    '    Private Function funcTurret_Optimise_1(ByVal dblLampCurrent As Double, ByVal intLampPos As Integer) As Boolean
    '        '------------------------------------------------------------------
    '        'Procedure Name         :   funcTurret_Optimise
    '        'Description            :   To optimise Turret position 
    '        'Parameters             :   dblLampCurrent = current to be set to lamp
    '        '                           intLampPos = lamp position to which current to be set
    '        'Time/Date              :   5/10/06
    '        'Dependencies           :   
    '        'Author                 :   Rahul B.
    '        'Revision               :
    '        'Revision by Person     :
    '        '--------------------------------------------------------------------------------------
    '        'Optimise Turret Steps:
    '        '1. Set Air Off
    '        '2. Find wv home
    '        '3. Turret Home
    '        '4. Position Turret to selected Turret No.
    '        '5. Set All Lamp Off
    '        '6. Set Current to HCL lamp selected.
    '        '7. Test if Lamp present then optimise turret
    '        '8. Set Air ON
    '        Dim objWait As New CWaitCursor
    '        Dim i, pos As Integer
    '        Dim strMsg As String
    '        Dim dbllmp_current As Double = 0.0
    '        Dim intlmp_position As Integer
    '        Try

    '            'CType(mlblStatus2, Windows.Forms.Label).Text = "Initialising Please Wait  ......."

    '            '---temporarily lamp optimize position is kept at index 0 later it should be 
    '            '---set from somewhere else.
    '            gobjInst.Lamp.LampParametersCollection.item(2).LampOptimizePosition = 0
    '            'gobjInst.Lamp.LampParametersCollection.item(2).ElementName = "Cu"
    '            '--------

    '            For i = 0 To 5
    '                If gobjInst.Lamp.LampParametersCollection.item(i).LampOptimizePosition = 0 Then
    '                    Exit For
    '                End If
    '            Next

    '            If i < 6 Then

    '                '---1. Set Air Off
    '                gobjCommProtocol.funcAir_OFF()
    '                'RaiseEvent OptimizationStatus("Initialising Please Wait  .......")
    '                'CType(mlblStatus2, Windows.Forms.Label).Text = "Initialising Please Wait  ......."
    '                '---2. Find wv home
    '                If gobjCommProtocol.funcFind_Wavelength_Home() Then
    '                    '+++++ToDo later (for display of flame)
    '                    'ShowTurretElement(hwnd);
    '                    '+++++ToDo

    '                    For pos = i + 1 To 6
    '                        If gobjInst.Lamp.LampParametersCollection.item(pos - 1).ElementName <> "" Then
    '                            If gobjInst.Lamp.LampParametersCollection.item(pos - 1).LampOptimizePosition = 0 Then
    '                                If gobjInst.Lamp_Old <> pos Then
    '                                    'CType(mlblStatus2, Windows.Forms.Label).Text = "Setting Lamp from " & gobjInst.Lamp_Old & " to " & pos & " position."
    '                                    If gobjCommProtocol.gFuncTurret_Position(pos, True) = False Then
    '                                        '--take lamp current from inst parameters and set it
    '                                        Exit For
    '                                    End If
    '                                    'CType(mlblStatus2, Windows.Forms.Label).Text = " "
    '                                End If
    '                            End If
    '                        End If
    '                    Next

    '                    '---5. Set All Lamp Off
    '                    gobjCommProtocol.funcAll_Lamp_Off()

    '                    '----currently these two values are set here but later on it should be written somewhere else
    '                    gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current = dblLampCurrent
    '                    gobjInst.Lamp_Position = intLampPos
    '                    '--------

    '                    dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
    '                    intlmp_position = gobjInst.Lamp_Position
    '                    '---6. Set Current to HCL lamp selected.
    '                    If gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, intlmp_position) Then
    '                    Else
    '                    End If
    '                    If gobjInst.Current = 0.0 Then
    '                        gobjInst.Current = dbllmp_current
    '                    End If

    '                    '---7. Test if Lamp present then optimise turret
    '                    If gobjCommProtocol.funcTestLampPresence() Then
    '                        If funcTur_Opt() Then
    '                            funcTurret_Optimise_1 = True
    '                        Else
    '                            funcTurret_Optimise_1 = False
    '                        End If
    '                    End If
    '                Else
    '                    funcTurret_Optimise_1 = False
    '                End If

    '                '---8. Set Air ON
    '                Call gobjCommProtocol.funcAir_ON()
    '            End If

    '            funcSaveInstStatus()

    '            Return True
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Function

    '    Private Function funcTur_Opt(Optional ByRef lblStatus1 As Object = Nothing, Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing) As Boolean
    '        '-----------------------------------  Procedure Header  -------------------------------
    '        'Procedure Name         :   funcTur_OptThread
    '        'Description            :   To optimise turret
    '        'Parameters             :   None
    '        'Time/Date              :   17.11.06
    '        'Dependencies           :   
    '        'Author                 :   Deepak B.
    '        'Revision               :
    '        'Revision by Person     :   Made major modifications
    '        '--------------------------------------------------------------------------------------
    '        Dim rPOs As Integer
    '        Dim intCounter As Integer
    '        Dim chNew As Integer
    '        Dim max_int As Integer
    '        Dim in_pos As Integer
    '        Dim dblEnergy As Double
    '        Dim strData As String
    '        '---------------------------------------------------
    '        '        void	Tur_Opt(HWND hwnd, HDC hdc)
    '        '{
    '        'int    chnew, i;
    '        'int    in_pos, max_int, rpos;
    '        'char line7[80]="";

    '        ' SetFocus(hwnd);
    '        ' if( GetInstrument() == AA202)
    '        '	 SetText(hwnd, IDC_STATUS, "Lamp Optimization");
    '        '        Else
    '        '	 SetText(hwnd, IDC_STATUS, "Turret Optimization");
    '        ' Cal_Mode(HCLE);
    '        ' rpos = Tur_pre_opt(hwnd);

    '        '#If !NEWZERO Then
    '        '  Adj_PMT_forvalue(hwnd, (double) 3500.0, (double)350);
    '        '#Else
    '        '  Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0 ), (double)350.0);
    '        '#End If
    '        ' Show_Pmt(hwnd, Inst->Pmtv);
    '        ' pc_delay (200);
    '        ' for (i=1; i<=rpos+10; i++)  {
    '        '	Rotate_Anticlock_Tur();
    '        '	}
    '        ' for (i=1; i<=10; i++) {
    '        '	Rotate_Clock_Tur();
    '        '  }
    '        ' if(GetInstrument() == AA202)
    '        '	 SetWindowText(hwnd,"OPTIMISING LAMP");
    '        '                    Else
    '        '	 SetWindowText(hwnd,"OPTIMISING TURRET");
    '        ' PeakGraph.Xmin= 1; PeakGraph.Xmax= RANGE;
    '        ' PeakGraph.Ymin= GetEnergy(2047);
    '        ' PeakGraph.Ymax= GetEnergy(2047.0+409.6*4);
    '        ' strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"TURRET STEP");
    '        ' Show_Peak_Param(hwnd, RANGE);
    '        ' if( GetInstrument() == AA202 )
    '        '   SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Lamp Position");
    '        '                        Else
    '        '	 SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
    '        ' in_pos = 1;
    '        ' max_int = 0;
    '        ' ReadADCFilter();
    '        ' for (i=1; i<=RANGE; i++) {
    '        '	Rotate_Clock_Tur();
    '        '	pc_delay(100);
    '        '	chnew = ReadADCFilter();
    '        '	if (chnew > max_int) {
    '        '	  max_int = chnew;
    '        '	  in_pos =i;
    '        '	 }
    '        '  if (i==1)
    '        '		GPlotInit(hdc, (double) i, GetEnergy(chnew));
    '        '                                    Else
    '        '		GPlot(hdc, (double) i, GetEnergy(chnew));
    '        ' }
    '        ' GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);
    '        ' SetText(hwnd, IDC_STATUS," Positioning Please Wait  .......        ");
    '        '#If EMU Then
    '        ' Wait_For_Some_Msg(5);
    '        '#End If
    '        ' for (i=1; i <= RANGE+10; i++) 	Rotate_Anticlock_Tur();
    '        ' for (i=1; i <= 10+in_pos; i++)  {
    '        '	Rotate_Clock_Tur();	
    '        '	}
    '        'Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = in_pos;	
    '        'for(i=0;i<500; i++)
    '        ' pc_delay(10000);
    '        '}

    '        '---------------------------------------------------
    '        Try
    '            funcTur_Opt = False

    '            If Not lblStatus2 Is Nothing Then
    '                CType(lblStatus2, Windows.Forms.Label).Text = "Turret Optimization"
    '            End If


    '            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
    '                'MessageBox.Show("Error in setting calibration mode")
    '                gobjMessageAdapter.ShowMessage(constCalibrationMode)
    '                Application.DoEvents()
    '            End If

    '            If Not lblStatus1 Is Nothing Then
    '                rPOs = gobjCommProtocol.funcTur_Pre_Opt(lblStatus1, lblStatus2, lblStatus3)
    '            End If

    '            If gobjCommProtocol.funcAdj_Pmt_ForValue(CDbl(70.0), CDbl(350.0), True, lblStatus1, lblStatus2, lblStatus3) = False Then
    '                'MessageBox.Show("Error in adjusting pmt for value")
    '                gobjMessageAdapter.ShowMessage(constPMTVolt)
    '                Application.DoEvents()
    '            End If

    '            If Not lblStatus1 Is Nothing Then
    '                CType(lblStatus1, Windows.Forms.Label).Text = "PMT : -" & gobjInst.PmtVoltage
    '            End If

    '            gobjCommProtocol.mobjCommdll.subTime_Delay(200)

    '            For intCounter = 1 To rPOs + 10
    '                gobjCommProtocol.funcRotate_Anticlock_Tur()
    '            Next

    '            For intCounter = 1 To 10
    '                gobjCommProtocol.funcRotate_Clock_Tur()
    '            Next

    '            If Not lblStatus2 Is Nothing Then
    '                CType(lblStatus2, Windows.Forms.Label).Text = "Scanning for Optimal Turret Position"
    '            End If

    '            in_pos = 1
    '            max_int = 0
    '            gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)
    '            For intCounter = 1 To RANGE
    '                gobjCommProtocol.funcRotate_Clock_Tur()
    '                gobjCommProtocol.mobjCommdll.subTime_Delay(100)
    '                gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)
    '                If chNew > max_int Then
    '                    max_int = chNew
    '                    in_pos = intCounter
    '                End If
    '                'dblEnergy = gFuncGetEnergy(chNew)
    '                'strData = ""
    '                'strData = intCounter & "," & dblEnergy
    '                'mobjThreadController.Display(strData)
    '            Next
    '            'GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);  todo later

    '            If Not lblStatus2 Is Nothing Then
    '                CType(lblStatus2, Windows.Forms.Label).Text = " Positioning Please Wait  .......        "
    '            End If

    '            For intCounter = 1 To RANGE + 10
    '                gobjCommProtocol.funcRotate_Anticlock_Tur()
    '            Next

    '            For intCounter = 1 To 10 + in_pos
    '                gobjCommProtocol.funcRotate_Clock_Tur()
    '            Next

    '            gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition = in_pos

    '            funcTur_Opt = True
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Function

    '    Private Function funcOptimise_Zero_Order_rahul() As Boolean
    '        '-----------------------------------  Procedure Header  -------------------------------
    '        'Procedure Name         :   funcTurret_Optimise
    '        'Description            :   To optimise Turret position 
    '        'Parameters             :   dblLampCurrent = current to be set to lamp
    '        '                           intLampPos = lamp position to which current to be set
    '        'Time/Date              :   5/10/06
    '        'Dependencies           :   
    '        'Author                 :   Rahul B.
    '        'Revision               :
    '        'Revision by Person     :
    '        '--------------------------------------------------------------------------------------
    '        '-------------------------------------
    '        '        void	S4FUNC 	Optimize_Zero_order(HWND hpar)
    '        '{
    '        ' double   cur=0.0;
    '        ' HWND		hwnd, hwnd1;
    '        ' HDC		hdc, hdc1;
    '        ' BOOL		flag= TRUE, zero = FALSE;
    '        ' char    line1[80]="";
    '        ' int     pos;

    '        '#ifndef FINAL
    '        '  Get_Instrument_Parameters(&Inst);
    '        '#End If

    '        '  MessageBox(hwnd, "Plz select whether you want to skip zero order or not", "AAS203", MB_OK);

    '        ' if (MessageBox(hwnd, "Do you want to perform zero order", "Confirmation", MB_YESNO)==IDYES)
    '        ' {

    '        ' Inst =  GetInstData();
    '        ' if(GetInstrument() != AA202 )
    '        '	 AIR_OFF();
    '        ' hwnd1= CreateWindowPeak(hpar, " TURRET OPTIMISATION","SKCK1",2 );
    '        ' hwnd= CreateWindowPeak(hpar, " ZERO ORDER ","SKCK1",1 );
    '        ' if (hwnd && hwnd1){
    '        '	hdc= GetDC(hwnd);
    '        '	SetBkColor(hdc, RGB(192, 192, 192));
    '        '	hdc1= GetDC(hwnd1);
    '        '	SetBkColor(hdc1, RGB(192, 192, 192));
    '        '	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
    '        '	for (pos = 0; pos<6; pos++)
    '        '	  Inst->Lamp_par.lamp[pos].lamp_optpos=0;
    '        '	Inst->Lamp_par.wvzero = 100.0;
    '        '	if (Find_Turret_Home(hpar)){
    '        '	  if(Find_Wavelength_Home(hdc, 5, 150)){
    '        '		 ShowTurretElement(hwnd);
    '        '		 if (Slit_Home()){
    '        '		  for (pos = 1; pos<=6; pos++){
    '        '			 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
    '        '				continue;
    '        '			 if(Inst->Lamp_old!=pos){
    '        '				strcpy(line1,"");
    '        '				sprintf(line1, " Setting Lamp from %d to %d position. ",Inst->Lamp_old, pos);
    '        '				SetText(hwnd, IDC_STATUS,line1);
    '        '				if (!Position_Turret(hpar, pos,TRUE)){
    '        '					Gerror_message_new("Error in Turret Module ..", "TURRET");
    '        '					break;
    '        '				  }
    '        '			  }
    '        '			 SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......        ");
    '        '//	       disp_el(); disp_data( 5, 1, 65, lamp_pos-1);	  pc_sound(500,1);
    '        '			 All_Lamp_Off();
    '        '			 cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
    '        '			 Set_HCL_Cur(cur,Inst->Lamp_pos);
    '        '			 if (Inst->Cur==(double) 0.0){
    '        '//				Gerror_message_new("cur is  0.0", "Warning");
    '        '				Inst->Cur=cur;
    '        '			  }

    '        '			 flag=Test_Lamp_Presence(hwnd);
    '        '			 if (flag){
    '        '				if (!zero){
    '        '				  InitGraphParam(hwnd);SetFocus(hwnd);
    '        '				  zero = Zero_Order(hwnd, hdc);
    '        '				  if (!zero) {
    '        '					 Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
    '        '					 Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
    '        '					 flag=FALSE;
    '        '					}
    '        '				  InitGraphParam(hwnd1);
    '        '				 }//!zero
    '        '			  if (flag){
    '        '				 SetFocus(hwnd1);
    '        '				 Tur_Opt(hwnd1, hdc1);
    '        '				 }
    '        '			  else break;
    '        '			}//if flag
    '        '		 } //for
    '        '		} //slit home
    '        '	  } // find_mech_zero
    '        '	 } //turret home
    '        '	ReleaseDC(hwnd, hdc);
    '        '	DestroyWindowPeak(hwnd,hpar);
    '        '	ReleaseDC(hwnd1, hdc1);
    '        '	DestroyWindowPeak(hwnd1,hpar);
    '        '  if(GetInstrument() != AA202 )
    '        '	  AIR_ON();
    '        ' }  // if oflag
    '        ' } //messagebox if condition true
    '        '       ReleaseDC(hwnd, hdc);
    '        'DestroyWindowPeak(hwnd,hpar);
    '        ' if(GetInstrument() != AA202 )
    '        ' AIR_ON();
    '        '-------------------------------------
    '        Dim intCounter As Integer
    '        Dim blnFlag As Boolean
    '        Dim blnZeroOrder As Boolean
    '        Try
    '            funcOptimise_Zero_Order_rahul = False

    '            Call funcAir_OFF()

    '            '	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
    '            '	for (pos = 0; pos<6; pos++)
    '            '	  Inst->Lamp_par.lamp[pos].lamp_optpos=0;
    '            '	Inst->Lamp_par.wvzero = 100.0;

    '            'gintlamp_opt_pos = 0

    '            'gdblWvzero = 100.0

    '            If gFuncTurret_Home() Then
    '                If funcFind_Wavelength_Home() Then
    '                    '-ShowTurretElement
    '                    '--check if old lamp posn not equal to current posn then only perform gfuncTurretPosition
    '                    If gFuncSlit_Home() Then
    '                        '-position check if turret element not empty then position turret to that position
    '                        '-else continue
    '                        'dim objCLsInstPara as New  
    '                        For intCounter = 0 To gobjNewMethod.InstrumentConditions.Count - 1

    '                            If gFuncTurret_Position(TURRET_6P_POS, gobjNewMethod.InstrumentConditions.item(intCounter).TurretNumber) Then
    '                                '--take lamp current from inst parameters and set it

    '                            Else
    '                                'funcSet_Lamp = True
    '                                'MessageBox.Show(" Error in Turret Module ", "Optimise Zero Order", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                                gobjMessageAdapter.ShowMessage(constTurretModuleError)
    '                                Application.DoEvents()
    '                                Exit For
    '                            End If

    '                            Call funcAll_Lamp_Off()

    '                            If funcSet_HCL_Cur(gobjNewMethod.InstrumentConditions.item(intCounter).LampCurrent, gobjNewMethod.InstrumentConditions.item(intCounter).TurretNumber) Then
    '                                'funcSet_Lamp = True
    '                            Else
    '                                'funcSet_Lamp = False
    '                            End If

    '                            blnFlag = funcTestLampPresence()

    '                            If blnFlag Then
    '                                If Not blnZeroOrder Then
    '                                    '-Init graph
    '                                    blnZeroOrder = funcZero_Order_rahul()
    '                                    If Not blnZeroOrder Then
    '                                        'MessageBox.Show(" Error Zero Order Peak not Found ", "Optimise Zero Order", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                                        gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound)
    '                                        Application.DoEvents()
    '                                        blnFlag = False
    '                                    End If
    '                                    '-init graph
    '                                End If
    '                                If blnFlag Then

    '                                    If funcTur_Opt() Then
    '                                        funcOptimise_Zero_Order_rahul = True
    '                                    Else
    '                                        'MessageBox.Show(" Warning Lamp not Connected", "Turret Optimise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                                        gobjMessageAdapter.ShowMessage(constLampNotConnected)
    '                                        Application.DoEvents()
    '                                        funcOptimise_Zero_Order_rahul = False
    '                                    End If
    '                                Else
    '                                    Exit For
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                End If
    '            End If

    '            Call funcAir_ON()

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Function

    '    Private Function funcZero_Order_rahul() As Boolean
    '        '------------------------------------------------------------------
    '        'Procedure Name         :   funcZero_Order
    '        'Description            :   To optimise turret
    '        'Parameters             :   None
    '        'Time/Date              :   5/10/06
    '        'Dependencies           :   
    '        'Author                 :   Rahul B.
    '        'Revision               :
    '        'Revision by Person     :
    '        '------------------------------------------------------------------
    '        Dim rPOs As Integer
    '        Dim intCounter As Integer
    '        Dim chNew, chBase As Integer
    '        Dim max_int As Integer
    '        Dim in_pos As Integer
    '        Dim blnFlag As Boolean = False
    '        Try
    '            funcZero_Order_rahul = False
    '            'Dim mobjfrmZeroOrder As New frmZeroOrder
    '            mobjfrmZeroOrder = New frmZeroOrder
    '            mobjfrmZeroOrder.Show()

    '            Call funcCalibrationMode(EnumCalibrationMode.HCLE)

    '            rPOs = funcSearch_Approc_WV_Peak(WVZERORANGE, CDbl(120))
    '            '#If !NEWZERO Then
    '            'Adj_PMT_forvalue(hwnd, (double) 3500.0, (double)350);
    '            '#Else
    '            ' Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0 ), (double)350.0);
    '            '#End If
    '            'Show_Pmt(hwnd, Inst->Pmtv);
    '            funcAdj_Pmt_ForValue(CDbl(3500.0), CDbl(350), False)
    '            'funcAdj_Pmt_ForValue(CDbl(4000.0 / 5000.0 * 100.0), CDbl(350.0), True)

    '            'Dim objfrmZeroOrder As New frmZeroOrder
    '            'objfrmZeroOrder.Show()

    '            '-show PMT
    '            'PeakGraph.Ymin= GetEnergy(2047);
    '            'PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);
    '            mobjCommdll.subTime_Delay(200)
    '            max_int = 3000
    '            intCounter = 1
    '            For intCounter = 1 To rPOs + STEPS_PER_NM
    '                Call funcRotate_Anticlock_Wv()
    '            Next

    '            For intCounter = 1 To STEPS_PER_NM
    '                Call funcRotate_Clock_Wv()
    '            Next

    '            'funcGet_Current_Wv(gdblCurWv)
    '            funcGet_Current_Wv(gobjInst.WavelengthCur)

    '            'strcpy(line1,""); sprintf(line1, "ZERO-ORDER  peak Search  Range ( %5.2fnm - %5.2fnm)",
    '            'Inst->Wvcur,Inst->Wvcur+WVZERORANGE/(double)stepspernm);
    '            'PeakGraph.Xmin= Inst->Wvcur;
    '            'PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;
    '            'strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"Wv(nm)");
    '            'Show_Peak_Param(hwnd, WVZERORANGE);
    '            'SetText(hwnd, IDC_STATUS1,line1);

    '            in_pos = 1
    '            max_int = 0

    '            Call funcReadADCFilter(10, chBase)
    '            For intCounter = 1 To WVZERORANGE
    '                Call funcRotate_Clock_Wv()
    '                'mobjCommdll.subTime_Delay(200)
    '                Call funcReadADCFilter(10, chNew)
    '                If chNew > max_int Then
    '                    max_int = chNew
    '                    in_pos = intCounter
    '                    If max_int - chBase > 210 Then
    '                        blnFlag = True
    '                    End If
    '                End If


    '                If intCounter = 1 Then
    '                    'GPlotInit(hdc, (double) i, GetEnergy(chnew))
    '                Else
    '                    'GPlot(hdc, (double) i, GetEnergy(chnew));
    '                End If

    '            Next

    '            'GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);
    '            'SetText(hwnd, IDC_STATUS," Positioning Please Wait  .......        ");
    '            '#If EMU Then
    '            ' Wait_For_Some_Msg(5);
    '            '#End If
    '            mobjfrmZeroOrder.Close()
    '            mobjfrmZeroOrder.Dispose()

    '            For intCounter = 1 To WVZERORANGE + STEPS_PER_NM
    '                Call funcRotate_Anticlock_Wv()
    '            Next

    '            For intCounter = 1 To in_pos + STEPS_PER_NM
    '                Call funcRotate_Clock_Wv()
    '            Next

    '            'Inst->Wvcur = Get_Cur_Wv();

    '            funcGet_Current_Wv(gobjInst.WavelengthCur)

    '            'Inst->Lamp_par.wvzero = Inst->Wvcur;

    '            'gdblWvzero = gobjInst.WavelengthCur
    '            gobjInst.WavelengthCur = CDbl(0.0)
    '            funcSet_Current_Wv(gobjInst.WavelengthCur)
    '            funcSet_SlitWidth(CDbl(0.3))
    '            mobjCommdll.subTime_Delay(200)
    '            funcZero_Order_rahul = True
    '            'Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = in_pos;	//i-1;
    '            'for(i=0;i<500; i++)
    '            'pc_delay(10000);
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Function

    '    Private Function funcSearch_Approc_WV_Peak_rahul(ByVal intSteps As Integer, ByVal dblPmtv As Double) As Integer
    '        '-----------------------------------  Procedure Header  -------------------------------
    '        'Procedure Name         :   funcSearch_Approc_WV_Peak
    '        'Description            :   To optimise Turret 
    '        'Parameters             :   None
    '        'Time/Date              :   5/10/06
    '        'Dependencies           :   
    '        'Author                 :   Rahul B.
    '        'Revision               :
    '        'Revision by Person     :
    '        '--------------------------------------------------------------------------------------
    '        Dim intCounter, intCounter1 As Integer
    '        Dim chNew As Integer
    '        Dim max_int As Integer
    '        Dim int_pos As Integer

    '        Try
    '            funcSearch_Approc_WV_Peak_rahul = False
    '            Call funcSet_PMT(dblPmtv)
    '            'gobjCommProtocol.funcSet_PMT(CDbl(210.0))
    '            funcAdj_Pmt_NearZeroWV()
    '            '-Show Pmt
    '            funcGet_Current_Wv(gobjInst.WavelengthCur)
    '            If gobjInst.WavelengthCur < 10 Then
    '                '	  sprintf(line1," Positioning to  -2.0 nm Wait ..... "); //, Inst->Wvcur-(steps/100.0));
    '            Else
    '                '             sprintf(line1," Positioning to  %-5.2f nm Wait ..... ",
    '                'Inst->Wvcur-(steps/(double) (stepspernm*(float)2.0)) ); //100.0));
    '            End If
    '            'SetText(hwnd, IDC_STATUS1,line1);

    '            For intCounter = 1 To (intSteps / CDbl(2.0)) + STEPS_PER_NM
    '                Call funcRotate_Anticlock_Wv()
    '            Next intCounter

    '            For intCounter = 1 To STEPS_PER_NM
    '                Call funcRotate_Clock_Wv()
    '            Next

    '            funcGet_Current_Wv(gobjInst.WavelengthCur)
    '            int_pos = 1
    '            'max_int = 0
    '            For intCounter = 1 To intSteps
    '                Call funcRotate_Clock_Wv()
    '                Call funcReadADCFilter(10, chNew)
    '                '-if not demo
    '                If ((chNew - 2047.0) / 4096.0 * 10000.0) >= 4900.0 Then
    '                    'SetText(hwnd, IDC_STATUS1, " FULL SCALE RESET  Please Wait ..... ");
    '                    '		npos++;
    '                    '                    If (npos > 2) Then
    '                    '		  break;

    '                    funcAdj_Pmt_NearZeroWV()
    '                    '		Show_Pmt(hwnd, Inst->Pmtv);
    '                    For intCounter1 = 1 To intCounter + STEPS_PER_NM
    '                        Call funcRotate_Anticlock_Wv()
    '                    Next

    '                    For intCounter1 = 1 To STEPS_PER_NM
    '                        Call funcRotate_Clock_Wv()
    '                    Next
    '                    intCounter = 0
    '                    int_pos = 1
    '                    max_int = 0
    '                    chNew = 0
    '                    funcGet_Current_Wv(gobjInst.WavelengthCur)
    '                End If

    '                If (chNew > max_int) And (intCounter <> 1) Then
    '                    max_int = chNew
    '                    int_pos = intCounter
    '                End If
    '                '-endif not demo
    '                '              sprintf(line1," Wv : %5.2f nm  Aprox.Peak %5.2f  Energy %5.0f ",
    '                '		Inst->Wvcur+i/(double)stepspernm,
    '                '		Inst->Wvcur+in_pos/(double)stepspernm,
    '                '		(double) GetmV(chnew));
    '                '//(chnew-2047.0)/4096.0*10000.0);
    '                'SetText(hwnd, IDC_STATUS1,line1);
    '            Next intCounter

    '            funcGet_Current_Wv(gobjInst.WavelengthCur)
    '            ' SetText(hwnd, IDC_STATUS,"Positioning Please Wait  .......");
    '            For intCounter = 1 To intSteps + STEPS_PER_NM
    '                Call funcRotate_Anticlock_Wv()
    '            Next

    '            For intCounter = 1 To int_pos + STEPS_PER_NM
    '                Call funcRotate_Clock_Wv()
    '            Next
    '            funcGet_Current_Wv(gobjInst.WavelengthCur)
    '            Call funcReadADCFilter(10, chNew)
    '            '          sprintf(line1," Wv : %5.2f nm  Aprox.Peak %5.2f  Energy %5.0f ", Inst->Wvcur+i/(double)stepspernm,
    '            '	Inst->Wvcur+in_pos/(double)stepspernm, (double)GetmV(chnew));
    '            'SetText(hwnd, IDC_STATUS1,line1);
    '            'SetText(hwnd, IDC_STATUS1,"");
    '            Return int_pos

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function

    '#End Region

    '    Public Function gFuncWavelength_Home_rahul() As Boolean
    '        '-----------------------------------  Procedure Header  -------------------------------
    '        'Procedure Name         :   gFuncWavelength_Home
    '        'Description            :   To make the Wavelength indicater home        
    '        'Parameters             :   None
    '        'Time/Date              :   25/9/06
    '        'Dependencies           :   obviously PC must communicate with Instrument through COM port
    '        'Author                 :   Rahul B.
    '        'Revision               :
    '        'Revision by Person     :   Deepak B. on 17.11.06 as some part of code was left behind by rahul
    '        '--------------------------------------------------------------------------------------
    '        Dim bytArray(7) As Byte
    '        Dim sintWv As Short
    '        Dim BParam2 As Byte
    '        Dim intJ As Integer
    '        Dim intCount As Integer

    '        gFuncWavelength_Home_rahul = False
    '        '------------
    '        '        BOOL    S4FUNC Find_Wavelength_Home(HDC hdc, int x, int y)
    '        '{
    '        'unsigned  ch, oldTout;
    '        'int       i, j;
    '        'BYTE		oParam1;

    '        ' Inst.Wvcur = Get_Cur_Wv();
    '        ' oldTout=Tout;
    '        ' Tout=LONG_DEALY;
    '        ' hold = Load_Curs();
    '        ' Transmit(WVHOME, 0, 0, 0);
    '        '  if (Recev(TRUE)&& Param1==1){
    '        '	 do{
    '        '                If (!Recev(True)) Then
    '        '		  break;
    '        '		ch = Param2*256+Param1;
    '        '                    If (hdc! = NULL) Then
    '        '		 Wprintf(hdc,x, y, "%5.2f nm  ",ch/StepPerNm);
    '        '                        If (ch < StepPerNm) Then
    '        '		  break;
    '        '	  } while(1);
    '        '	}
    '        ' Tout=VERY_LONG_DEALY ; 
    '        ' do {
    '        '                                If (!Recev(True)) Then
    '        '	  break;
    '        '	if (Param1==6 || Param1==5) {
    '        '	  Beep();
    '        '	  Beep();
    '        '	  continue;
    '        '	 }
    '        '                                    Else
    '        '	 break;
    '        '  } while(1);
    '        ' Tout =oldTout;
    '        ' SetCursor(hold);
    '        ' switch(Param1)  {
    '        '	case 1:  Inst.Wvcur = 0; break;
    '        '	case 2: Gerror_message(" Monochromator error \n MECH.HOME Sensor");
    '        '				break;
    '        '	case 3: Gerror_message(" Monochromator error \n Opto (COURSE Sensor)");
    '        '				break;
    '        '	case 4: Gerror_message(" Monochromator error \n Opto (FINE  Sensor  )");
    '        '				break;
    '        '	}
    '        ' oParam1=Param1;
    '        'if( GetInstrument() != AA202 ){
    '        ' if (Inst.Lamp_par.wvzero != 100.0 && Param1==1)  {
    '        '	j = (int) (Inst.Lamp_par.wvzero*(double)StepPerNm);
    '        '	if (j<0) j= -j;
    '        '	if (Inst.Lamp_par.wvzero<0){
    '        '		for (i= 1; i<=j+StepPerNm; i++) {
    '        '		  Rotate_Anticlock_Wv();
    '        '		  pc_delay(200);
    '        '		 }
    '        '		for (i= 1; i<=StepPerNm; i++) {
    '        '		  Rotate_Clock_Wv();
    '        '		  pc_delay(200);
    '        '		 }
    '        '	 }
    '        '	else  for (i= 1; i<=j; i++) {
    '        '		Rotate_Clock_Wv();
    '        '		pc_delay(200);
    '        '	  }
    '        '}
    '        '	Inst.Wvcur= Get_Cur_Wv();
    '        '	Inst.Wvcur = 0;
    '        '	Set_Cur_Wv();
    '        '#If DEMO Then
    '        '	wvcur=0;
    '        '#End If
    '        '  }
    '        ' if (oParam1==1) return TRUE;
    '        ' else return FALSE;
    '        '}
    '        '------------
    '        Try
    '            If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.WVHOME, 0, 0, 0) Then
    '                'mobjCommdll.subTime_Delay(glng_Delay5sec * 2)
    '                If mobjCommdll.gFuncReceiveData(bytArray, glng_Delay5sec) Then
    '                    If bytArray(1) <> 1 Then

    '                        gFuncWavelength_Home_rahul = False
    '                        gobjMessageAdapter.ShowMessage(constWVHomeError)
    '                        Application.DoEvents()
    '                    Else
    '                        mobjCommdll.subTime_Delay(glng_Delay5sec * 2)
    '                        Do
    '                            Array.Clear(bytArray, 0, 8)
    '                            If mobjCommdll.gFuncReceiveData(bytArray, glng_Delay5sec) Then
    '                                sintWv = (bytArray(3) * 256) + bytArray(2)
    '                                If sintWv < STEPS_PER_NM Then
    '                                    Exit Do
    '                                End If
    '                            Else
    '                                Exit Do
    '                            End If

    '                        Loop While (1)

    '                        mobjCommdll.subTime_Delay(glng_Delay5sec * 2)
    '                        Do
    '                            Array.Clear(bytArray, 0, 8)
    '                            If mobjCommdll.gFuncReceiveData(bytArray, glng_Delay5sec) Then
    '                                If bytArray(2) = EnumErrorMessage.SHOME_ERROR Or bytArray(2) = EnumErrorMessage.COMM_ERROR Then
    '                                    Beep()
    '                                    Beep()
    '                                    GoTo EndOfLoop
    '                                Else
    '                                    Exit Do
    '                                End If

    '                            Else
    '                                Exit Do
    '                            End If

    'EndOFLoop:              Loop While (1)

    '                        'mobjCommdll.subTime_Delay(glng_Delay5sec * 2)
    '                        Select Case bytArray(2)
    '                            Case EnumErrorMessage.NO_ERROR
    '                                gobjInst.WavelengthCur = 0
    '                                Exit Select
    '                            Case EnumErrorMessage.LOBYTE_ERROR
    '                                gobjMessageAdapter.ShowMessage(constMechWVHomeError)
    '                                Application.DoEvents()
    '                                Exit Select
    '                            Case EnumErrorMessage.COARSEHOME_ERROR
    '                                gobjMessageAdapter.ShowMessage(constCoarseWVHomeError)
    '                                Application.DoEvents()
    '                                Exit Select
    '                            Case EnumErrorMessage.FINEHOME_ERROR
    '                                gobjMessageAdapter.ShowMessage(constFineWVHomeError)
    '                                Application.DoEvents()
    '                                Exit Select
    '                        End Select
    '                        '---------------------
    '                        '--- the following block of code is written by deepak b on 15.11.06
    '                        '--- as it was left behind by rahul 
    '                        '--------

    '                        BParam2 = bytArray(2)
    '                        If gobjInst.Lamp.WavelengthZero <> 100.0 And bytArray(2) = 1 Then
    '                            'MessageBox.Show("inside WavelengthZero condition " & gobjInst.Lamp.WavelengthZero)
    '                            intJ = CInt(gobjInst.Lamp.WavelengthZero * STEPS_PER_NM)
    '                            If intJ < 0 Then
    '                                intJ = -intJ
    '                            End If
    '                            If gobjInst.Lamp.WavelengthZero < 0 Then
    '                                For intCount = 1 To intJ + STEPS_PER_NM
    '                                    funcRotate_Anticlock_Wv()
    '                                    mobjCommdll.subTime_Delay(200)
    '                                Next
    '                                For intCount = 1 To STEPS_PER_NM
    '                                    funcRotate_Clock_Wv()
    '                                    mobjCommdll.subTime_Delay(200)
    '                                Next
    '                            Else
    '                                For intCount = 1 To intJ
    '                                    funcRotate_Clock_Wv()
    '                                    mobjCommdll.subTime_Delay(200)
    '                                Next
    '                            End If
    '                        End If
    '                        If funcGet_Current_Wv(gobjInst.WavelengthCur) = True Then
    '                            'MessageBox.Show("setting funcSet_Current_Wv")
    '                            gobjInst.WavelengthCur = 0
    '                            funcSet_Current_Wv(gobjInst.WavelengthCur)
    '                        End If
    '                        '---------------------
    '                        Return True
    '                    End If
    '                Else
    '                    gFuncWavelength_Home_rahul = False
    '                    gobjMessageAdapter.ShowMessage(constWVHomeError)
    '                    Application.DoEvents()
    '                End If
    '            Else
    '                gFuncWavelength_Home_rahul = False
    '                gobjMessageAdapter.ShowMessage(constWVHomeError)
    '                Application.DoEvents()
    '            End If

    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            'gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
    '            Return False
    '            '---------------------------------------------------------
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try
    '    End Function

    'Public Function funcPressSensorStatus() As Boolean
    '    '-----------------------------------  Procedure Header  -------------------------------
    '    'Procedure Name         :   funcPressSensorStatus
    '    'Description            :   To check pressure sensors for AIR, N2O, Fuel etc.
    '    'Parameters             :   None
    '    'Time/Date              :   25/9/06
    '    'Dependencies           :   obviously PC must communicate with Instrument through COM port
    '    'Author                 :   Rahul B.
    '    'Revision               :
    '    'Revision by Person     :
    '    '--------------------------------------------------------------------------------------
    '    Dim objWait As New CWaitCursor
    '    Dim bytArray(7) As Byte
    '    Dim bytPressStatus As Byte
    '    'funcPressSensorStatus = True

    '    '        BYTE CHECK_PS()
    '    '{
    '    ' Transmit(PSSTATUS, 0,0, 0);
    '    '// c = PSSTATUS; trans(c); c = recev();
    '    ' Recev(TRUE);
    '    ' return Param1;
    '    '}

    '    Try
    '        'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.PSSTATUS, 0, 0, 0) Then
    '        If FuncTransmitCommand(EnumAAS203Protocol.PSSTATUS, 0, 0, 0) Then
    '            'mobjCommdll.subTime_Delay(7000)
    '            'If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
    '            If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
    '                bytPressStatus = bytArray(2)
    '                If (bytPressStatus And EnumErrorStatus.AIR_NOK) = EnumErrorStatus.AIR_NOK Then
    '                    funcPressSensorStatus = funcPressSensorStatus And False
    '                    'gFuncShowMessage("Error...", "Low Air Pressure.", EnumMessageType.Information)
    '                    If blnShowErrorMessages = True Then
    '                        gobjMessageAdapter.ShowMessage(constLowAirPressure)
    '                        Application.DoEvents()
    '                    End If
    '                Else
    '                    funcPressSensorStatus = funcPressSensorStatus And True
    '                End If
    '                bytPressStatus = bytArray(2)
    '                If (bytPressStatus And EnumErrorStatus.N2O_NOK) = EnumErrorStatus.N2O_NOK Then
    '                    funcPressSensorStatus = funcPressSensorStatus And False
    '                    'gFuncShowMessage("Error...", "Low N2O Pressure.", EnumMessageType.Information)
    '                    If blnShowErrorMessages = True Then
    '                        gobjMessageAdapter.ShowMessage(constLowN2OPressure)
    '                        Application.DoEvents()
    '                    End If
    '                Else
    '                    funcPressSensorStatus = funcPressSensorStatus And True
    '                End If
    '                bytPressStatus = bytArray(2)
    '                If (bytPressStatus And EnumErrorStatus.FUEL_NOK) = EnumErrorStatus.FUEL_NOK Then
    '                    funcPressSensorStatus = funcPressSensorStatus And False
    '                    'gFuncShowMessage("Error...", "Low Fuel Pressure.", EnumMessageType.Information)
    '                    If blnShowErrorMessages = True Then
    '                        gobjMessageAdapter.ShowMessage(constLowFuelPressure)
    '                        Application.DoEvents()
    '                    End If
    '                Else
    '                    funcPressSensorStatus = funcPressSensorStatus And True
    '                End If
    '            Else
    '                funcPressSensorStatus = False
    '                If blnShowErrorMessages = True Then
    '                    gobjMessageAdapter.ShowMessage(constPressureSensorError)
    '                    Application.DoEvents()
    '                End If
    '            End If
    '        Else
    '            funcPressSensorStatus = False
    '            If blnShowErrorMessages = True Then
    '                gobjMessageAdapter.ShowMessage(constLowFuelPressure)
    '                Application.DoEvents()
    '            End If
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
    '        objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Function

#Region ""
    '=====on air on/off
    'if (ps1)	{
    '									  if (air){ air = AIR_OFF();if(GetInstrument() == AA202) SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O OFF");}
    '									  else{ air = AIR_ON();if(GetInstrument() == AA202) SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O ON");}
    '									 }
    '								  else{  if(GetInstrument() == AA202)
    '												Gerror_message_new("No AIR Pressure ..","AA-202 PNEUM");
    '											else
    '												Gerror_message_new("No AIR Pressure ..","AA-203 PNEUM");
    '												}break;
    '=====on n20 button on/off
    'if (ps2)  {
    '					  if(n2){ n2 = N2O_OFF();}
    '					  else{ n2 = N2O_ON();}
    '					 }
    '					else {
    '					  if(n2) n2 = N2O_OFF();
    '					  if(GetInstrument() == AA202)
    '						Gerror_message_new("No N2O Pressure ..", "AA-202 PNEUM");
    '					  else
    '						Gerror_message_new("No N2O Pressure ..", "AA-203 PNEUM");
    '					} break;
    '=========on fuel on/off button
    'if (ps3){
    '					  if (fuel){ if(GetInstrument() == AA202){  air = AIR_ON(); SetWindowText(GetDlgItem(hwnd,IDC_BAIR),"N2O ON");SetWindowText(GetDlgItem(hwnd,IDC_BFUEL),"FUEL ON");pc_delay(6000);pc_delay(6000);}fuel = FUEL_OFF();}
    '					  else{ if( GetInstrument() == AA202 ){SetWindowText(GetDlgItem(hwnd,IDC_BFUEL),"FUEL OFF");}fuel = FUEL_ON();}
    '					 }
    '					else  {
    '					  if (fuel) fuel = FUEL_OFF();
    '						 if(GetInstrument() == AA202)
    '							 Gerror_message_new("No FUEL Pressure ..", "AA-202 PNEUM");
    '						 else
    '							 Gerror_message_new("No FUEL Pressure ..", "AA-203 PNEUM");
    '					 } break;
    '=======on ignite on/off button
    'if (fuel && air) Inst.Aaf = ON;
    '				  if (fuel && n2) Inst.N2of = ON;
    '				  if (Bignite) Bignite=IGNITE_OFF();
    '				  else   if (!Inst.Aaf && !Inst.N2of)  Bignite = IGNITE_ON();
    '				  pc_delay(250);break;
    '=====on increment fuel button 
    'Incr_Fuel();
    '				  Wprintf(hdc, 10, 70, "%3.2f      ", (double)Inst.Nvstep/(double)NVSTEP);break;
    '======on decrement fuel button
    'Decr_Fuel();
    '				  Wprintf(hdc, 10, 70, "%3.2f      ", (double)Inst.Nvstep/(double)NVSTEP); break;
    '
    '====on form closing
    '   if (Bignite) Bignite=IGNITE_OFF();
    'if (fuel && air) Inst.Aaf = ON;
    'if (fuel && n2) Inst.N2of = ON;

    
    'Public Function funcCheckBurnerParameters() As Boolean
    '    '-----------------------------------  Procedure Header  -------------------------------
    '    'Procedure Name         :   funcCheckBurnerParameters
    '    'Description            :   To check Burner parameters 
    '    'Parameters             :   None
    '    'Time/Date              :   25/9/06
    '    'Dependencies           :   obviously PC must communicate with Instrument through COM port
    '    'Author                 :   Rahul B.
    '    'Revision               :
    '    'Revision by Person     :
    '    '--------------------------------------------------------------------------------------
    '    Dim objWait As New CWaitCursor
    '    Dim bytArray(7) As Byte

    '    funcCheckBurnerParameters = False

    '    Try

    '        'If mobjCommdll.gFuncTransmitCommand(EnumAAS203Protocol.CHKBURNER, 0, 0, 0) Then
    '        If FuncTransmitCommand(EnumAAS203Protocol.CHKBURNER, 0, 0, 0) Then

    '            'mobjCommdll.subTime_Delay(glng_Delay5sec)
    '            'If mobjCommdll.gFuncReceiveData(bytArray, CONST_LONG_DELAY) Then
    '            If FuncReceiveData(bytArray, CONST_VERY_LONG_DELAY) Then
    '                If bytArray(2) <> EnumErrorStatus.AA_CONNECTED Then
    '                    funcCheckBurnerParameters = False
    '                    'gFuncShowMessage("Error...", "Burner Not Connected.", EnumMessageType.Information)
    '                    gobjMessageAdapter.ShowMessage(constBurnerCheckError)
    '                    Application.DoEvents()
    '                Else
    '                    funcCheckBurnerParameters = True
    '                End If
    '            Else
    '                funcCheckBurnerParameters = False
    '                'gFuncShowMessage("Error...", "Burner Not Connected.", EnumMessageType.Information)
    '                gobjMessageAdapter.ShowMessage(constBurnerCheckError)
    '                Application.DoEvents()
    '            End If
    '        Else
    '            funcCheckBurnerParameters = False
    '            'gFuncShowMessage("Error...", "Burner Not Connected.", EnumMessageType.Information)
    '            gobjMessageAdapter.ShowMessage(constBurnerCheckError)
    '            Application.DoEvents()
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
    '        objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Function
    

#End Region

End Class
