Imports BgThread
Imports AAS203.Common
Imports AAS203Library.Instrument

Public Class clsBgZeroOrder1
    Implements BgThread.IBgWorker
    Implements BgThread.Iclient


#Region "Constructors"

    Public Sub New()
        MyBase.New()

    End Sub

    Public Sub New(ByRef lblSt1 As Label, ByRef lblSt2 As Label, ByRef lblSt3 As Label)
        '=====================================================================
        ' Procedure Name        : New
        ' Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
        ' Returns               : 
        ' Purpose               : To put the IGNITE ON or OFF.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak B.
        ' Created               : 29.11.06
        ' Revisions             : 
        '=====================================================================
        MyBase.New()

        Try
            mlblStatus1 = lblSt1
            mlblStatus2 = lblSt2
            mlblStatus3 = lblSt3
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

#Region "Private Variables"
    Private mController As clsBgThread
    Private mobjThreadController As IBgThread
    Private mlblStatus1, mlblStatus2, mlblStatus3 As Label
    Private mObjGraph As Object
#End Region

#Region "Public Functions"

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
        ' Parameters Passed     : 
        ' Returns               : 
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

            If mobjThreadController.Running Then
                If funcOptimise_Zero_Order(mlblStatus1, mlblStatus2, mlblStatus3) = True Then
                    mobjThreadController.Completed(False)
                    Application.DoEvents()
                End If
            Else
                mobjThreadController.Completed(True)
                Application.DoEvents()
                Exit Sub
            End If
            gobjCommProtocol.mobjCommdll.subTime_Delay(100)

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


    Private Function funcOptimise_Zero_Order(Optional ByRef lblStatus1 As Label = Nothing, _
   Optional ByRef lblStatus2 As Label = Nothing, Optional ByRef lblStatus3 As Label = Nothing) As Boolean


        '-----------------------------------  Procedure Header  -------------------------------
        'Procedure Name         :   funcTurret_Optimise
        'Description            :   To optimise Turret position 
        'Parameters             :   dblLampCurrent = current to be set to lamp
        '                           intLampPos = lamp position to which current to be set
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 26.11.06
        '--------------------------------------------------------------------------------------
        '-------------------------------------
        '        void	S4FUNC 	Optimize_Zero_order(HWND hpar)
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

        '  MessageBox(hwnd, "Plz select whether you want to skip zero order or not", "AAS203", MB_OK);

        ' if (MessageBox(hwnd, "Do you want to perform zero order", "Confirmation", MB_YESNO)==IDYES)
        ' {

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
        '	if (Find_Turret_Home(hpar)){
        '	  if(Find_Wavelength_Home(hdc, 5, 150)){
        '		 ShowTurretElement(hwnd);
        '		 if (Slit_Home()){
        '		  for (pos = 1; pos<=6; pos++){
        '			 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
        '				continue;
        '			 if(Inst->Lamp_old!=pos){
        '				strcpy(line1,"");
        '				sprintf(line1, " Setting Lamp from %d to %d position. ",Inst->Lamp_old, pos);
        '				SetText(hwnd, IDC_STATUS,line1);
        '				if (!Position_Turret(hpar, pos,TRUE)){
        '					Gerror_message_new("Error in Turret Module ..", "TURRET");
        '					break;
        '				  }
        '			  }
        '			 SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......        ");
        '//	       disp_el(); disp_data( 5, 1, 65, lamp_pos-1);	  pc_sound(500,1);
        '			 All_Lamp_Off();
        '			 cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
        '			 Set_HCL_Cur(cur,Inst->Lamp_pos);
        '			 if (Inst->Cur==(double) 0.0){
        '//				Gerror_message_new("cur is  0.0", "Warning");
        '				Inst->Cur=cur;
        '			  }

        '			 flag=Test_Lamp_Presence(hwnd);
        '			 if (flag){
        '				if (!zero){
        '				  InitGraphParam(hwnd);SetFocus(hwnd);
        '				  zero = Zero_Order(hwnd, hdc);
        '				  if (!zero) {
        '					 Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
        '					 Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
        '					 flag=FALSE;
        '					}
        '				  InitGraphParam(hwnd1);
        '				 }//!zero
        '			  if (flag){
        '				 SetFocus(hwnd1);
        '				 Tur_Opt(hwnd1, hdc1);
        '				 }
        '			  else break;
        '			}//if flag
        '		 } //for
        '		} //slit home
        '	  } // find_mech_zero
        '	 } //turret home
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
        '-------------------------------------
        Dim intCounter As Integer
        Dim blnFlag As Boolean
        Dim blnZeroOrder As Boolean
        Dim intPos As Integer
        Dim dbllmp_current As Double
        Dim intlmp_position As Integer
        Try
            funcOptimise_Zero_Order = False

            Call gobjCommProtocol.funcAir_OFF()

            If Not lblStatus3 Is Nothing Then
                lblStatus3.Text = "Initialising Please Wait  ......."
            End If

            For intPos = 0 To 5
                gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = 0
            Next
            gobjInst.Lamp.WavelengthZero = 100.0

            If gobjCommProtocol.gFuncTurret_Home() Then
                If gobjCommProtocol.funcFind_Wavelength_Home() Then
                    '-ShowTurretElement todo for flame
                    If gobjCommProtocol.gFuncSlit_Home() Then
                        For intPos = 1 To 6
                            If gobjInst.Lamp.LampParametersCollection.item(intPos - 1).ElementName <> "" Then
                                If gobjInst.Lamp_Old <> intPos Then
                                    If Not lblStatus2 Is Nothing Then
                                        lblStatus2.Text = "Setting Lamp from " & gobjInst.Lamp_Old & " to " & intPos & " position."
                                    End If
                                    If gobjCommProtocol.gFuncTurret_Position(intPos, True) = False Then
                                        Exit For
                                    End If
                                End If
                            End If

                            If Not lblStatus2 Is Nothing Then
                                lblStatus2.Text = "Initialising Please Wait  ......."
                            End If

                            Call gobjCommProtocol.funcAll_Lamp_Off()

                            dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current
                            intlmp_position = gobjInst.Lamp_Position

                            If gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, intlmp_position) = True Then
                                '--- Do Nothing
                            Else
                                'MessageBox.Show("Error in setting HCL current")
                                gobjMessageAdapter.ShowMessage(constSetHCLCurError)
                                Application.DoEvents()
                            End If

                            If gobjInst.Current = 0.0 Then
                                gobjInst.Current = dbllmp_current
                            End If

                            blnFlag = gobjCommProtocol.funcTestLampPresence()

                            If blnFlag Then
                                If Not blnZeroOrder Then
                                    blnZeroOrder = funcZero_Order()
                                    If Not blnZeroOrder Then
                                        gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound)
                                        Application.DoEvents()
                                        blnFlag = False
                                    End If
                                End If
                                If blnFlag Then
                                    If gobjCommProtocol.funcTur_Opt_New() Then
                                        'do nothing
                                    End If
                                Else
                                    Exit For
                                End If
                            End If 'blnflag
                        Next 'for loop
                    End If ' slit home 
                End If ' wv zero
            End If ' turret home

            Call gobjCommProtocol.funcAir_ON()

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

    Private Function funcZero_Order(Optional ByRef lblStatus1 As Object = Nothing, _
   Optional ByRef lblStatus2 As Object = Nothing, Optional ByRef lblStatus3 As Object = Nothing) As Boolean
        '------------------------------------------------------------------
        'Procedure Name         :   funcZero_Order
        'Description            :   To optimise turret
        'Parameters             :   None
        'Time/Date              :   5/10/06
        'Dependencies           :   
        'Author                 :   Rahul B.
        'Revision               :
        'Revision by Person     :   Deepak B. on 26.11.06
        '------------------------------------------------------------------
        Dim rPOs As Integer
        Dim intCounter As Integer
        Dim chNew, chBase As Integer
        Dim max_int As Integer
        Dim in_pos As Integer
        Dim blnFlag As Boolean = False
        Try
            funcZero_Order = False

            If gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) = False Then
                'MessageBox.Show("Error in setting calibration mode")
                gobjMessageAdapter.ShowMessage(constCalibrationMode)
                Application.DoEvents()
            End If

            If Not lblStatus2 Is Nothing Then
                CType(lblStatus2, Windows.Forms.Label).Text = "ZERO-ORDER Peak Search"
            End If

            rPOs = gobjCommProtocol.funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0)

            '---to confirm from 16 bit code
            gobjCommProtocol.funcAdj_Pmt_ForValue(CDbl(3500.0), CDbl(350), False)
            '------

            If Not lblStatus1 Is Nothing Then
                CType(lblStatus1, Windows.Forms.Label).Text = "PMT : " & gobjInst.PmtVoltage.ToString
            End If

            'PeakGraph.Ymin= GetEnergy(2047);
            'PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);

            max_int = 3000
            blnFlag = False
            intCounter = 1

            For intCounter = 1 To rPOs + STEPS_PER_NM
                Call gobjCommProtocol.funcRotate_Anticlock_Wv()
            Next

            For intCounter = 1 To STEPS_PER_NM
                Call gobjCommProtocol.funcRotate_Clock_Wv()
            Next

            If gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) Then
                'MessageBox.Show("Error in setting current wavelength")
                gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Application.DoEvents()
            End If

            'PeakGraph.Xmin= Inst->Wvcur;
            'PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;

            'Show_Peak_Param(hwnd, WVZERORANGE); to confirm

            If Not lblStatus3 Is Nothing Then
                CType(lblStatus3, Windows.Forms.Label).Text = "ZERO-ORDER  peak Search  Range ( " & gobjInst.WavelengthCur & "nm - " & (gobjInst.WavelengthCur + WVZERORANGE) / STEPS_PER_NM & "nm)"
            End If

            in_pos = 1
            max_int = 0

            Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chBase)

            For intCounter = 1 To WVZERORANGE
                Call gobjCommProtocol.funcRotate_Clock_Wv()
                Call gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew)

                If chNew > max_int Then
                    max_int = chNew
                    in_pos = intCounter
                    If max_int - chBase > 210 Then
                        blnFlag = True
                    End If
                End If

                If intCounter = 1 Then
                    'GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy( chnew));
                Else
                    'GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
                End If
            Next

            'GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
            'SetText(hwnd, IDC_STATUS1," Positioning to 0.00 nm Please Wait ..... ");

            If Not lblStatus3 Is Nothing Then
                CType(lblStatus3, Windows.Forms.Label).Text = " Positioning to 0.00 nm Please Wait ..... "
            End If

            For intCounter = 1 To WVZERORANGE + STEPS_PER_NM
                Call gobjCommProtocol.funcRotate_Anticlock_Wv()
            Next

            For intCounter = 1 To in_pos + STEPS_PER_NM
                Call gobjCommProtocol.funcRotate_Clock_Wv()
            Next

            If gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) Then
                'MessageBox.Show("Error in setting current wavelength")
                gobjMessageAdapter.ShowMessage(constSetCurWvError)
                Application.DoEvents()
            End If

            gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur
            gobjInst.WavelengthCur = 0.0

            gobjCommProtocol.funcSet_Current_Wv(gobjInst.WavelengthCur)

            gobjCommProtocol.funcSet_SlitWidth(0.3)

            gobjCommProtocol.mobjCommdll.subTime_Delay(200)

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

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed

    End Sub

    Public Sub Display(ByVal Text As String) Implements BgThread.Iclient.Display

    End Sub

    Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed

    End Sub

    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start

    End Sub

#End Region

End Class
