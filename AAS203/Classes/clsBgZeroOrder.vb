Imports BgThread
Imports AAS203.Common
Imports AAS203Library.Instrument

Public Class clsBgZeroOrder
    Implements BgThread.IBgWorker

#Region " Constructors "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByRef lblSt1Zero As Label, ByRef lblSt2Zero As Label, ByRef lblSt3Zero As Label, ByRef objGraphZero As AAS203.AASGraph, ByRef lblWavelengthStatus As Label)
        '=====================================================================
        ' Procedure Name        : New
        ' Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
        ' Returns               : 
        ' Purpose               : To initialize the object this class
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        MyBase.New()

        Try
            mlblStatus1ZeroOrder = lblSt1Zero
            mlblStatus2ZeroOrder = lblSt2Zero
            mlblStatus3ZeroOrder = lblSt3Zero
            mObjGraphZeroOrder = objGraphZero
            mlblWavelengthStatus = lblWavelengthStatus

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

#Region " Private Variables "

    Private mController As clsBgThread
    Private mobjThreadController As IBgThread
    Private mlblStatus1ZeroOrder, mlblStatus2ZeroOrder, mlblStatus3ZeroOrder As Label
    Private mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt As Label
    Private mObjGraphZeroOrder As AASGraph
    Private mObjGraphOpt As Object
    Private mlblWavelengthStatus As Label

#End Region

#Region " Constants "

    Private Const Const_Initialize = "Initialising Please Wait  ......."

#End Region

#Region " Public Functions "

    Public Sub Initialize(ByVal Controller As BgThread.IBgThread) Implements BgThread.IBgWorker.Initialize
        '=====================================================================
        ' Procedure Name        : Initialize
        ' Parameters Passed     : Controller
        ' Returns               : 
        ' Purpose               : To Initialize the thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        Try
            mobjThreadController = Controller
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

    Public Sub StartWorkerThread() Implements BgThread.IBgWorker.Start
        '=====================================================================
        ' Procedure Name        : StartWorkerThread
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To Start the worker thread
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        Dim objwait As New CWaitCursor

        Try
            '--- Added by Sachin Dokhale on 25.03.07
            '--- To know the Status of Thread on Status Bar of MDI Main
            Dim strPreviousStatusMessage As String
            If gblnShowThreadOnfrmMDIStatusBar Then
                strPreviousStatusMessage = gobjMain.StatusBar1.Text
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *ZeroOrder"
                Application.DoEvents()
            End If
            '---

            If mobjThreadController.Running Then
                '---perform zero order
                If funcOptimise_Zero_Order(mlblStatus1ZeroOrder, mlblStatus2ZeroOrder, mlblStatus3ZeroOrder, _
                   mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt, mObjGraphZeroOrder, mObjGraphOpt, mobjThreadController, mlblWavelengthStatus) = True Then
                    mobjThreadController.Completed(False)
                    Application.DoEvents()
                End If
            Else
                mobjThreadController.Completed(True)
                Application.DoEvents()
                '--- Added by Sachin Dokhale on 25.03.07
                '--- To remove the Status of Thread on Status Bar of MDI Main
                If gblnShowThreadOnfrmMDIStatusBar Then
                    gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                    Application.DoEvents()
                End If
                '---
                Exit Sub
            End If
            '--- Added by Sachin Dokhale on 25.03.07
            '--- To remove the Status of Thread on Status Bar of MDI Main
            If gblnShowThreadOnfrmMDIStatusBar Then
                gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage
                Application.DoEvents()
            End If
            '---
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mobjThreadController.Failed(ex)
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

#Region " Private Functions "

    Private Function funcOptimise_Zero_Order(Optional ByRef lblSt1Zero As Label = Nothing, Optional ByRef lblSt2Zero As Label = Nothing, Optional ByRef lblSt3Zero As Label = Nothing, _
                                             Optional ByRef lblSt1Opt As Label = Nothing, Optional ByRef lblSt2Opt As Label = Nothing, Optional ByRef lblSt3Opt As Label = Nothing, _
                                             Optional ByRef objGraphZero As Object = Nothing, Optional ByRef objGraphOpt As Object = Nothing, _
                                             Optional ByVal objController As BgThread.IBgThread = Nothing, Optional ByRef lblWvStatus As Label = Nothing) As Boolean
        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcOptimise_Zero_Order
        'Description            :   To optimise all turret with zero order 
        'Parameters             :   lblSt1Zero,lblSt2Zero,lblSt3Zero
        '                           lblSt1Opt,lblSt2Opt,lblSt3Opt
        '                           objGraphZero,objGraphOpt
        '                           objController,lblWvStatus
        'Time/Date              :   5/10/06
        'Dependencies           :   Serial Communication
        'Author                 :   Deepak B.
        'Revision               :   1
        'Revision by Person     :   Deepak B. on 26.11.06
        '--------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------
        'void	S4FUNC 	Optimize_Zero_order(HWND hpar)
        '{
        ' double   cur=0.0;
        ' HWND		hwnd, hwnd1;
        ' HDC		hdc, hdc1;
        ' BOOL		flag= TRUE, zero = FALSE;
        ' char    line1[80]="";
        ' int     pos;

        '#ifndef FINAL
        '  Get_Instrument_Parameters(&Inst);
        '#End If

        ' MessageBox(hwnd, "Plz select whether you want to skip zero order or not", "AAS203", MB_OK);

        'if (MessageBox(hwnd, "Do you want to perform zero order", "Confirmation", MB_YESNO)==IDYES)
        '{
        ' Inst =  GetInstData();
        ' if(GetInstrument() != AA202 )
        '	 AIR_OFF();
        ' hwnd1= CreateWindowPeak(hpar, " TURRET OPTIMISATION","SKCK1",2 );
        ' hwnd= CreateWindowPeak(hpar, " ZERO ORDER ","SKCK1",1 );
        ' if (hwnd && hwnd1){
        '	hdc= GetDC(hwnd);
        '	SetBkColor(hdc, RGB(192, 192, 192));
        '	hdc1= GetDC(hwnd1);
        '	SetBkColor(hdc1, RGB(192, 192, 192));
        '	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
        '	for (pos = 0; pos<6; pos++)
        '	  Inst->Lamp_par.lamp[pos].lamp_optpos=0;
        '	Inst->Lamp_par.wvzero = 100.0;
        '	if (Find_Turret_Home(hpar)){ //0
        '	  if(Find_Wavelength_Home(hdc, 5, 150)){ //1
        '		 ShowTurretElement(hwnd);
        '		 if (Slit_Home()){ //2
        '		  for (pos = 1; pos<=6; pos++){ //3
        '			 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
        '				continue;
        '			 if(Inst->Lamp_old!=pos){ //4
        '				strcpy(line1,"");
        '				sprintf(line1, " Setting Lamp from %d to %d position. ",Inst->Lamp_old, pos);
        '				SetText(hwnd, IDC_STATUS,line1);
        '				if (!Position_Turret(hpar, pos,TRUE)){ //5
        '					Gerror_message_new("Error in Turret Module ..", "TURRET");
        '					break;
        '				  } //5
        '			  } //4
        '			 SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......        ");
        '			 All_Lamp_Off();
        '			 cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
        '			 Set_HCL_Cur(cur,Inst->Lamp_pos);
        '			 if (Inst->Cur==(double) 0.0){ //6
        '				Inst->Cur=cur;
        '			  } //6

        '			 flag=Test_Lamp_Presence(hwnd);
        '			 if (flag){ //7
        '				if (!zero){ //8
        '				  InitGraphParam(hwnd);SetFocus(hwnd);
        '				  zero = Zero_Order(hwnd, hdc);
        '				  if (!zero) { //9
        '					 Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
        '					 Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
        '					 flag=FALSE;
        '					} //9
        '				  InitGraphParam(hwnd1);
        '				 }//!zero //8
        '			  if (flag){ //10
        '				 SetFocus(hwnd1);
        '				 Tur_Opt(hwnd1, hdc1);
        '				 } //10
        '			  else break;
        '			}//if flag //7
        '		 } //for //3
        '		} //slit home //2
        '	  } // find_mech_zero //1
        '	 } //turret home //0
        '	ReleaseDC(hwnd, hdc);
        '	DestroyWindowPeak(hwnd,hpar);
        '	ReleaseDC(hwnd1, hdc1);
        '	DestroyWindowPeak(hwnd1,hpar);
        '  if(GetInstrument() != AA202 )
        '	  AIR_ON();
        ' }  // if oflag
        ' } //messagebox if condition true
        '       ReleaseDC(hwnd, hdc);
        'DestroyWindowPeak(hwnd,hpar);
        ' if(GetInstrument() != AA202 )
        ' AIR_ON();
        '--------------------------------------------------------------------------------------
        Dim intCounter As Integer
        Dim blnFlag As Boolean
        Dim blnZeroOrder As Boolean
        Dim intPos As Integer
        Dim dbllmp_current As Double
        Dim intlmp_position As Integer
        Dim blnIsSlitHome As Boolean
        Dim objfrmOpt As frmZeroOrder2
        Try
            '--- set graph properties
            CType(objGraphZero, AASGraph).XAxisMin = -2
            CType(objGraphZero, AASGraph).XAxisMax = 4
            CType(objGraphZero, AASGraph).YAxisLabel = "ENERGY"
            CType(objGraphZero, AASGraph).XAxisLabel = "WAVELENGTH (nm)"
            CType(objGraphZero, AASGraph).XAxisMinorStep = 1
            CType(objGraphZero, AASGraph).XAxisStep = 1

            CType(objGraphZero, AASGraph).AldysPane.XAxis.PickScale(-2, 4)
            CType(objGraphZero, AASGraph).AldysPane.XAxis.MinorStepAuto = True
            CType(objGraphZero, AASGraph).AldysPane.XAxis.StepAuto = True
            CType(objGraphZero, AASGraph).Refresh()
            '--- If instrument type is not 201 then set Air off.
            If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                Call gobjCommProtocol.funcAir_OFF()
            End If

            If Not lblSt3Zero Is Nothing Then
                lblSt3Zero.Text = Const_Initialize
                lblSt3Zero.Refresh()
            End If

            For intPos = 0 To 9
                gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = 0
            Next
            gobjInst.Lamp.WavelengthZero = 100.0

            '--- Position turret at home position.
            If gobjCommProtocol.gFuncTurret_Home() Then
                '--- Position Wavelength drive to home position.
                If gobjCommProtocol.gFuncWavelength_Home(lblWvStatus) Then
                    '--- Added by Mangesh on 13-Apr-2007

                    '--- If instrument type is 203D then position entrance and exit slit 
                    '--- to home position else position only entrance slit to home position.

                    If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                        If gobjCommProtocol.gFuncSlit_Home() Then
                            blnIsSlitHome = gobjCommProtocol.funcExitSlit_Home()
                        End If
                    Else
                        blnIsSlitHome = gobjCommProtocol.gFuncSlit_Home()
                    End If
                    '---

                    If blnIsSlitHome Then
                        For intPos = 1 To 10
                            '--- Search for the presence of first lamp in turret assembly 
                            '--- and position turret to that location.
                            If gobjInst.Lamp.LampParametersCollection.item(intPos - 1).ElementName <> "" Then
                                If gobjInst.Lamp_Old <> intPos Then
                                    If Not lblSt3Zero Is Nothing Then
                                        lblSt3Zero.Text = "Setting Lamp from " & gobjInst.Lamp_Old & " to " & intPos & " position."
                                        lblSt3Zero.Refresh()
                                    End If
                                    If gobjCommProtocol.gFuncTurret_Position(intPos, True) = False Then
                                        Exit For
                                    End If
                                End If

                                If Not lblSt3Zero Is Nothing Then
                                    lblSt3Zero.Text = Const_Initialize
                                    lblSt3Zero.Refresh()
                                End If

                                '--- Set all lamps off.
                                gobjCommProtocol.funcAll_Lamp_Off()

                                '--- Get current and lamp position to optimize
                                dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
                                intlmp_position = gobjInst.Lamp_Position

                                '--- Set HCL current to the current turret position.
                                If gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, intlmp_position) = False Then
                                    gobjMessageAdapter.ShowMessage(constSetHCLCurError)
                                    Application.DoEvents()
                                End If

                                If gobjInst.Current = 0.0 Then
                                    gobjInst.Current = dbllmp_current
                                End If

                                '--- Test for lamp presence.
                                blnFlag = gobjCommProtocol.funcTestLampPresence(lblSt1Zero, lblSt2Zero, lblSt3Zero)

                                If blnFlag = True Then
                                    If blnZeroOrder = False Then
                                        '--- If lamp is present then perform zero order.
                                        blnZeroOrder = funcZero_Order(lblSt1Zero, lblSt2Zero, lblSt3Zero, objGraphZero, objController)
                                        If blnZeroOrder = False Then
                                            gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound)
                                            Application.DoEvents()
                                            blnFlag = False
                                        End If
                                    End If
                                    If blnFlag = True Then
                                        objController.Completed(True)

                                        '--- Initialize zero order form
                                        objfrmOpt = New frmZeroOrder2

                                        '--- set location of zero order form on screen
                                        objfrmOpt.StartPosition = FormStartPosition.Manual
                                        objfrmOpt.Location = New Point(OptAllThreadWindowLocationX, OptAllThreadWindowLocationY)
                                        objfrmOpt.StartOptTread()
                                        If objfrmOpt.ShowDialog() = DialogResult.OK Then
                                            objfrmOpt.Close()
                                            objfrmOpt.Dispose()
                                        End If
                                    Else
                                        Exit For
                                    End If
                                End If '--- blnflag
                            End If '--- if condition
                        Next '--- for loop
                    End If '--- slit home 
                End If '--- wv zero
            End If '--- turret home

            '--- If instrument type is not 201 then set air on
            If Not (gstructSettings.AppMode = EnumAppMode.FullVersion_201) Then
                gobjCommProtocol.funcAir_ON()
            End If

            Call gobjCommProtocol.mobjCommdll.subTime_Delay(1500)

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

    Private Function funcZero_Order(Optional ByRef lblSt1Zero As Label = Nothing, _
                                    Optional ByRef lblSt2Zero As Label = Nothing, Optional ByRef lblSt3Zero As Label = Nothing, _
                                    Optional ByRef objGraphZero As Object = Nothing, Optional ByVal objController As BgThread.IBgThread = Nothing) As Boolean
        '--------------------------------------------------------------------------------------------
        'Procedure Name         :   funcZero_Order
        'Description            :   To start zero order
        'Parameters             :   lblSt1Zero,lblSt2Zero,lblSt3Zero
        '                           objGraphZero,objController
        'Time/Date              :   5/10/06
        'Dependencies           :   Serial Communication
        'Author                 :   Deepak B.
        'Revision               :   1
        'Revision by Person     :   Deepak B. on 26.11.06
        '--------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------
        'BOOL	Zero_Order(HWND hwnd, HDC hdc)
        '{
        'int		chnew, chbase;
        'int		in_pos, i,max_int,  rpos;
        'BOOL		flag = FALSE;
        'char    	line1[80]="";
        'float stepspernm=50.0;

        'if (GetInstrument()==AA202)
        '   stepspernm = STEPS_PER_NM_AA202;
        'Else
        '   stepspernm = STEPS_PER_NM;

        ' Cal_Mode(HCLE);
        ' SetText(hwnd, IDC_STATUS, "ZERO-ORDER Peak Search");
        ' pc_delay (200);
        ' rpos = Search_Approc_wv_Peak(hwnd, WVZERORANGE, (double) 120.0);
        '#If !NEWZERO Then
        ' Adj_PMT_forvalue(hwnd, (double)4000.0, (double)350);
        '#Else
        ' Adj_PMT_forvalue(hwnd, (4000.0/5000.0 *100.0), 350);
        '#End If
        ' Show_Pmt(hwnd, Inst->Pmtv);
        ' PeakGraph.Ymin= GetEnergy(2047);
        ' PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);
        ' max_int = 3000;   flag = FALSE;
        ' i=1;
        ' for (i=1; i<=rpos+stepspernm; i++)   {
        '		Rotate_Anticlock_Wv();     
        '	}
        ' for (i=1; i<=stepspernm; i++)  {
        '	Rotate_Clock_Wv();    
        '	}
        ' Inst->Wvcur = Get_Cur_Wv();
        ' strcpy(line1,""); sprintf(line1, "ZERO-ORDER  peak Search  Range ( %5.2fnm - %5.2fnm)",
        '		Inst->Wvcur,Inst->Wvcur+WVZERORANGE/(double)stepspernm);
        ' PeakGraph.Xmin= Inst->Wvcur;
        ' PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;
        '  strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"Wv(nm)");
        ' Show_Peak_Param(hwnd, WVZERORANGE);

        ' SetText(hwnd, IDC_STATUS1,line1);
        ' in_pos = 1;
        ' max_int = 0;
        ' chbase = ReadADCFilter();
        ' for (i=1; i<=WVZERORANGE; i++) {
        '	Rotate_Clock_Wv();// pc_delay(100);
        '	chnew = ReadADCFilter();
        '	if (chnew > max_int)	 {
        '	  max_int = chnew;
        '	  in_pos =i;
        '	  if (max_int - chbase > 210) flag = TRUE;
        '	 }
        '	if (i==1)
        '	  GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy( chnew));
        '                                Else
        '	  GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
        '  }
        '  GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
        '  SetText(hwnd, IDC_STATUS1," Positioning to 0.00 nm Please Wait ..... ");
        '#If EMU Then
        ' Wait_For_Some_Msg(5);
        '#End If
        '  for (i=1; i <= WVZERORANGE+stepspernm; i++) {
        '	 Rotate_Anticlock_Wv();	 //  pc_delay(400);
        '	 }
        '  for (i=1; i <= in_pos+stepspernm; i++)   {
        '	 Rotate_Clock_Wv();	//	 pc_delay(400);
        '	}
        '  Inst->Wvcur = Get_Cur_Wv();
        '  Inst->Lamp_par.wvzero = Inst->Wvcur;
        '  Inst->Wvcur = (double) 0.0;
        '  Set_Cur_Wv();        

        '  Set_SlitWidth((double)0.3);
        '  pc_delay(200);
        ' return(flag);
        '}
        '--------------------------------------------------------------------------------------------
        Dim rPOs As Integer
        Dim intCounter As Integer
        Dim chNew, chBase As Integer
        Dim max_int As Integer
        Dim in_pos As Integer
        Dim blnFlag As Boolean = False
        Dim dblXval, dblYval As Double
        Dim strValue As String = ""
        Try
            'if (GetInstrument()==AA202)
            '   stepspernm = STEPS_PER_NM_AA202;
            'Else
            '   stepspernm = STEPS_PER_NM;

            '--- Set calibration mode as HCLE.
            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
                gobjMessageAdapter.ShowMessage(constCalibrationMode)
                Application.DoEvents()
            End If

            If Not lblSt3Zero Is Nothing Then
                lblSt3Zero.Text = "ZERO-ORDER Peak Search"
                lblSt3Zero.Refresh()
            End If

            '--- Search approximate Wavelength Peak.
            rPOs = gobjCommProtocol.funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0, lblSt1Zero, lblSt2Zero, lblSt3Zero)

            '--	Adjust pmt between 80-350 volt
            gobjCommProtocol.funcAdj_Pmt_ForValue(80, 350, True)

            If Not lblSt1Zero Is Nothing Then
                lblSt1Zero.Text = "PMT : -" & Format(gobjInst.PmtVoltage, "###")
            End If

            '--- Set graph properties
            CType(objGraphZero, AAS203.AASGraph).YAxisMin = 0
            'CType(objGraphZero, AAS203.AASGraph).YAxisMax = CInt(FormatNumber(gFuncGetEnergy(2047.0 + 409.6 * 5), 1))
            CType(objGraphZero, AAS203.AASGraph).YAxisMax = CInt(FormatNumber(gFuncGetEnergy(4094.0 + 819.2 * 5), 1))
            CType(objGraphZero, AAS203.AASGraph).AldysPane.YAxis.PickScale(CInt(CType(objGraphZero, AAS203.AASGraph).YAxisMin), CInt(CType(objGraphZero, AAS203.AASGraph).YAxisMax))
            CType(objGraphZero, AAS203.AASGraph).AldysPane.YAxis.MinorStepAuto = True
            CType(objGraphZero, AAS203.AASGraph).AldysPane.YAxis.StepAuto = True
            CType(objGraphZero, AAS203.AASGraph).Refresh()

            max_int = 3000
            blnFlag = False
            intCounter = 1

            '--- If instrument type is 201 then Rotate Wavelength Drive 
            '--- anticlockwise (Output of step 2 + 25) times and rotate Wavelength 
            '--- drive clockwise 25 times. If instrument type is not 201 then rotate 
            '--- Wavelength drive anticlockwise (Output of step 2 + 50) times and rotate 
            '--- Wavelength drive clockwise 50 times.

            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                For intCounter = 1 To rPOs + CONST_STEPS_PER_NM_AA201
                    Call gobjCommProtocol.funcRotate_Anticlock_Wv()
                Next

                For intCounter = 1 To CONST_STEPS_PER_NM_AA201
                    Call gobjCommProtocol.funcRotate_Clock_Wv()
                Next
            Else
                For intCounter = 1 To rPOs + CONST_STEPS_PER_NM
                    gobjCommProtocol.funcRotate_Anticlock_Wv()
                Next

                For intCounter = 1 To CONST_STEPS_PER_NM
                    gobjCommProtocol.funcRotate_Clock_Wv()
                Next
            End If

            '--- Get current wavelength.

            If gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                gobjMessageAdapter.ShowMessage(constGetCurWvError)
                Application.DoEvents()
            End If

            '--- Display zero order peak search range
            If Not lblSt2Zero Is Nothing Then
                lblSt2Zero.Text = "ZERO-ORDER  Peak Search  Range ( " & gobjInst.WavelengthCur & "nm - " & gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM & "nm)"
            End If

            '--- Set graph min max properties
            CType(objGraphZero, AAS203.AASGraph).XAxisMin = CInt(gobjInst.WavelengthCur)
            CType(objGraphZero, AAS203.AASGraph).XAxisMax = CInt(gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM)
            CType(objGraphZero, AAS203.AASGraph).YAxisLabel = "ENERGY"
            CType(objGraphZero, AAS203.AASGraph).XAxisLabel = "WAVELENGTH (nm)"
            CType(objGraphZero, AAS203.AASGraph).XAxisMinorStep = 1
            CType(objGraphZero, AAS203.AASGraph).XAxisStep = 1

            CType(objGraphZero, AAS203.AASGraph).AldysPane.XAxis.PickScale(CInt(gobjInst.WavelengthCur), CInt(gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM))
            CType(objGraphZero, AAS203.AASGraph).AldysPane.XAxis.MinorStepAuto = True
            CType(objGraphZero, AAS203.AASGraph).AldysPane.XAxis.StepAuto = True
            CType(objGraphZero, AAS203.AASGraph).Refresh()

            in_pos = 1
            max_int = 0

            '--- Read ADC filter.
            Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chBase)

            '--- WVZERORANGE =300
            For intCounter = 1 To WVZERORANGE
                strValue = ""
                '--- Rotate Wavelength Clockwise.
                gobjCommProtocol.funcRotate_Clock_Wv()
                '--- Read ADC filter.
                gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)
                '--- Memorize max ADC filter reading and its position.
                If chNew > max_int Then
                    max_int = chNew
                    in_pos = intCounter
                    If max_int - chBase > 210 Then
                        blnFlag = True
                    End If
                End If
                dblXval = FormatNumber(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM, 2)
                dblYval = gFuncGetEnergy(chNew)
                strValue = dblXval & "," & dblYval
                '--- send values to plot graph.
                If Not objController Is Nothing Then
                    objController.Display(strValue)
                End If
            Next

            If Not lblSt2Zero Is Nothing Then
                lblSt2Zero.Text = "Positioning to 0.00 nm Please Wait ..... "
            End If

            '--- Rotate Wavelength drive anticlockwise (300 + 50) 
            '--- times.

            For intCounter = 1 To WVZERORANGE + CONST_STEPS_PER_NM
                gobjCommProtocol.funcRotate_Anticlock_Wv()
            Next

            '--- Rotate Wavelength drive clockwise (Max ADC filter 
            '--- value position + 50) times.

            For intCounter = 1 To in_pos + CONST_STEPS_PER_NM
                gobjCommProtocol.funcRotate_Clock_Wv()
            Next

            '--- Get current Wavelength.

            If gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) = False Then
                gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Application.DoEvents()
            End If

            '--- Memorize current Wavelength as WVZero Wavelength.
            gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur
            gobjInst.WavelengthCur = 0.0

            '--- Set current wavelength.
            gobjCommProtocol.funcSet_Current_Wv(gobjInst.WavelengthCur)

            '--- If instrument type 203D then set entrance and 
            '--- exit slit width as 0.8. If instrument type is not 203D then 
            '--- set entrance slit width as 0.3.

            If gstructSettings.AppMode = EnumAppMode.FullVersion_203D Then
                '--- parameter 2 is passed for entry and exit slit (both slit)
                '--- Slit width is changed from 0.5 to 0.8 according to V.C.K.
                gobjCommProtocol.funcSet_SlitWidth(0.8, 2)
            Else
                '--- set entrance slit width as 0.3
                gobjCommProtocol.funcSet_SlitWidth(0.3)
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
            '---------------------------------------------------------
        End Try
    End Function

#End Region

End Class
