using BgThread;
using AAS203.Common;
using AAS203Library.Instrument;

public class clsBgZeroOrder1 : BgThread.IBgWorker, BgThread.Iclient
{


	#Region "Constructors"

	public clsBgZeroOrder1()
	{
		base.New();

	}

	public clsBgZeroOrder1(ref Label lblSt1, ref Label lblSt2, ref Label lblSt3)
	{
		//=====================================================================
		// Procedure Name        : New
		// Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
		// Returns               : 
		// Purpose               : To put the IGNITE ON or OFF.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		base.New();

		try {
			mlblStatus1 = lblSt1;
			mlblStatus2 = lblSt2;
			mlblStatus3 = lblSt3;
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

	#Region "Private Variables"
	private clsBgThread mController;
	private IBgThread mobjThreadController;
	private Label mlblStatus1;
	private Label mlblStatus2;
	private Label mlblStatus3;
		#End Region
	private object mObjGraph;

	#Region "Public Functions"

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		//=====================================================================
		// Procedure Name        : Initialize
		// Parameters Passed     : Controller
		// Returns               : 
		// Purpose               : To Initialize the thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		try {
			mobjThreadController = Controller;
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

	public void BgThread.IBgWorker.StartWorkerThread()
	{
		//=====================================================================
		// Procedure Name        : StartWorkerThread
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : To Start the worker thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objwait = new CWaitCursor();


		try {
			if (mobjThreadController.Running) {
				if (funcOptimise_Zero_Order(mlblStatus1, mlblStatus2, mlblStatus3) == true) {
					mobjThreadController.Completed(false);
					Application.DoEvents();
				}
			} else {
				mobjThreadController.Completed(true);
				Application.DoEvents();
				return;
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mobjThreadController.Failed(ex);
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


	private bool funcOptimise_Zero_Order(ref Label lblStatus1 = null, ref Label lblStatus2 = null, ref Label lblStatus3 = null)
	{


		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcTurret_Optimise
		//Description            :   To optimise Turret position 
		//Parameters             :   dblLampCurrent = current to be set to lamp
		//                           intLampPos = lamp position to which current to be set
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 26.11.06
		//--------------------------------------------------------------------------------------
		//-------------------------------------
		//        void	S4FUNC 	Optimize_Zero_order(HWND hpar)
		//{
		// double   cur=0.0;
		// HWND		hwnd, hwnd1;
		// HDC		hdc, hdc1;
		// BOOL		flag= TRUE, zero = FALSE;
		// char    line1[80]="";
		// int     pos;

		//#ifndef FINAL
		//  Get_Instrument_Parameters(&Inst);
		//#End If

		//  MessageBox(hwnd, "Plz select whether you want to skip zero order or not", "AAS203", MB_OK);

		// if (MessageBox(hwnd, "Do you want to perform zero order", "Confirmation", MB_YESNO)==IDYES)
		// {

		// Inst =  GetInstData();
		// if(GetInstrument() != AA202 )
		//	 AIR_OFF();
		// hwnd1= CreateWindowPeak(hpar, " TURRET OPTIMISATION","SKCK1",2 );
		// hwnd= CreateWindowPeak(hpar, " ZERO ORDER ","SKCK1",1 );
		// if (hwnd && hwnd1){
		//	hdc= GetDC(hwnd);
		//	SetBkColor(hdc, RGB(192, 192, 192));
		//	hdc1= GetDC(hwnd1);
		//	SetBkColor(hdc1, RGB(192, 192, 192));
		//	SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
		//	for (pos = 0; pos<6; pos++)
		//	  Inst->Lamp_par.lamp[pos].lamp_optpos=0;
		//	Inst->Lamp_par.wvzero = 100.0;
		//	if (Find_Turret_Home(hpar)){
		//	  if(Find_Wavelength_Home(hdc, 5, 150)){
		//		 ShowTurretElement(hwnd);
		//		 if (Slit_Home()){
		//		  for (pos = 1; pos<=6; pos++){
		//			 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
		//				continue;
		//			 if(Inst->Lamp_old!=pos){
		//				strcpy(line1,"");
		//				sprintf(line1, " Setting Lamp from %d to %d position. ",Inst->Lamp_old, pos);
		//				SetText(hwnd, IDC_STATUS,line1);
		//				if (!Position_Turret(hpar, pos,TRUE)){
		//					Gerror_message_new("Error in Turret Module ..", "TURRET");
		//					break;
		//				  }
		//			  }
		//			 SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......        ");
		////	       disp_el(); disp_data( 5, 1, 65, lamp_pos-1);	  pc_sound(500,1);
		//			 All_Lamp_Off();
		//			 cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
		//			 Set_HCL_Cur(cur,Inst->Lamp_pos);
		//			 if (Inst->Cur==(double) 0.0){
		////				Gerror_message_new("cur is  0.0", "Warning");
		//				Inst->Cur=cur;
		//			  }

		//			 flag=Test_Lamp_Presence(hwnd);
		//			 if (flag){
		//				if (!zero){
		//				  InitGraphParam(hwnd);SetFocus(hwnd);
		//				  zero = Zero_Order(hwnd, hdc);
		//				  if (!zero) {
		//					 Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
		//					 Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
		//					 flag=FALSE;
		//					}
		//				  InitGraphParam(hwnd1);
		//				 }//!zero
		//			  if (flag){
		//				 SetFocus(hwnd1);
		//				 Tur_Opt(hwnd1, hdc1);
		//				 }
		//			  else break;
		//			}//if flag
		//		 } //for
		//		} //slit home
		//	  } // find_mech_zero
		//	 } //turret home
		//	ReleaseDC(hwnd, hdc);
		//	DestroyWindowPeak(hwnd,hpar);
		//	ReleaseDC(hwnd1, hdc1);
		//	DestroyWindowPeak(hwnd1,hpar);
		//  if(GetInstrument() != AA202 )
		//	  AIR_ON();
		// }  // if oflag
		// } //messagebox if condition true
		//       ReleaseDC(hwnd, hdc);
		//DestroyWindowPeak(hwnd,hpar);
		// if(GetInstrument() != AA202 )
		// AIR_ON();
		//-------------------------------------
		int intCounter;
		bool blnFlag;
		bool blnZeroOrder;
		int intPos;
		double dbllmp_current;
		int intlmp_position;
		try {
			funcOptimise_Zero_Order = false;

			gobjCommProtocol.funcAir_OFF();

			if (!lblStatus3 == null) {
				lblStatus3.Text = "Initialising Please Wait  .......";
			}

			for (intPos = 0; intPos <= 5; intPos++) {
				gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = 0;
			}
			gobjInst.Lamp.WavelengthZero = 100.0;

			if (gobjCommProtocol.gFuncTurret_Home()) {
				if (gobjCommProtocol.funcFind_Wavelength_Home()) {
					//-ShowTurretElement todo for flame
					if (gobjCommProtocol.gFuncSlit_Home()) {
						for (intPos = 1; intPos <= 6; intPos++) {
							if (gobjInst.Lamp.LampParametersCollection.item(intPos - 1).ElementName != "") {
								if (gobjInst.Lamp_Old != intPos) {
									if (!lblStatus2 == null) {
										lblStatus2.Text = "Setting Lamp from " + gobjInst.Lamp_Old + " to " + intPos + " position.";
									}
									if (gobjCommProtocol.gFuncTurret_Position(intPos, true) == false) {
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}

							if (!lblStatus2 == null) {
								lblStatus2.Text = "Initialising Please Wait  .......";
							}

							gobjCommProtocol.funcAll_Lamp_Off();

							dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current;
							intlmp_position = gobjInst.Lamp_Position;

							if (gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, intlmp_position) == true) {
							//--- Do Nothing
							} else {
								//MessageBox.Show("Error in setting HCL current")
								gobjMessageAdapter.ShowMessage(constSetHCLCurError);
								Application.DoEvents();
							}

							if (gobjInst.Current == 0.0) {
								gobjInst.Current = dbllmp_current;
							}

							blnFlag = gobjCommProtocol.funcTestLampPresence();

							if (blnFlag) {
								if (!blnZeroOrder) {
									blnZeroOrder = funcZero_Order();
									if (!blnZeroOrder) {
										gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound);
										Application.DoEvents();
										blnFlag = false;
									}
								}
								if (blnFlag) {
									if (gobjCommProtocol.funcTur_Opt_New()) {
										//do nothing
									}
								} else {
									break; // TODO: might not be correct. Was : Exit For
								}
							}
							//blnflag
						}
						//for loop
					}
					// slit home 
				}
				// wv zero
			}
			// turret home

			gobjCommProtocol.funcAir_ON();

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcZero_Order(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcZero_Order
		//Description            :   To optimise turret
		//Parameters             :   None
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Rahul B.
		//Revision               :
		//Revision by Person     :   Deepak B. on 26.11.06
		//------------------------------------------------------------------
		int rPOs;
		int intCounter;
		int chNew;
		int chBase;
		int max_int;
		int in_pos;
		bool blnFlag = false;
		try {
			funcZero_Order = false;

			if (gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) == false) {
				//MessageBox.Show("Error in setting calibration mode")
				gobjMessageAdapter.ShowMessage(constCalibrationMode);
				Application.DoEvents();
			}

			if (!lblStatus2 == null) {
				((Windows.Forms.Label)lblStatus2).Text = "ZERO-ORDER Peak Search";
			}

			rPOs = gobjCommProtocol.funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0);

			//---to confirm from 16 bit code
			gobjCommProtocol.funcAdj_Pmt_ForValue((double)3500.0, (double)350, false);
			//------

			if (!lblStatus1 == null) {
				((Windows.Forms.Label)lblStatus1).Text = "PMT : " + gobjInst.PmtVoltage.ToString;
			}

			//PeakGraph.Ymin= GetEnergy(2047);
			//PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);

			max_int = 3000;
			blnFlag = false;
			intCounter = 1;

			for (intCounter = 1; intCounter <= rPOs + STEPS_PER_NM; intCounter++) {
				gobjCommProtocol.funcRotate_Anticlock_Wv();
			}

			for (intCounter = 1; intCounter <= STEPS_PER_NM; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
			}

			if (gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)) {
				//MessageBox.Show("Error in setting current wavelength")
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}

			//PeakGraph.Xmin= Inst->Wvcur;
			//PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;

			//Show_Peak_Param(hwnd, WVZERORANGE); to confirm

			if (!lblStatus3 == null) {
				((Windows.Forms.Label)lblStatus3).Text = "ZERO-ORDER  peak Search  Range ( " + gobjInst.WavelengthCur + "nm - " + (gobjInst.WavelengthCur + WVZERORANGE) / STEPS_PER_NM + "nm)";
			}

			in_pos = 1;
			max_int = 0;

			gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chBase);

			for (intCounter = 1; intCounter <= WVZERORANGE; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
				gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew);

				if (chNew > max_int) {
					max_int = chNew;
					in_pos = intCounter;
					if (max_int - chBase > 210) {
						blnFlag = true;
					}
				}

				if (intCounter == 1) {
				//GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy( chnew));
				} else {
					//GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
				}
			}

			//GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
			//SetText(hwnd, IDC_STATUS1," Positioning to 0.00 nm Please Wait ..... ");

			if (!lblStatus3 == null) {
				((Windows.Forms.Label)lblStatus3).Text = " Positioning to 0.00 nm Please Wait ..... ";
			}

			for (intCounter = 1; intCounter <= WVZERORANGE + STEPS_PER_NM; intCounter++) {
				gobjCommProtocol.funcRotate_Anticlock_Wv();
			}

			for (intCounter = 1; intCounter <= in_pos + STEPS_PER_NM; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
			}

			if (gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur)) {
				//MessageBox.Show("Error in setting current wavelength")
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}

			gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur;
			gobjInst.WavelengthCur = 0.0;

			gobjCommProtocol.funcSet_Current_Wv(gobjInst.WavelengthCur);

			gobjCommProtocol.funcSet_SlitWidth(0.3);

			gobjCommProtocol.mobjCommdll.subTime_Delay(200);

			return blnFlag;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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


	public void BgThread.Iclient.Completed(bool Cancelled)
	{
	}


	public void BgThread.Iclient.Display(string Text)
	{
	}


	public void BgThread.Iclient.Failed(System.Exception e)
	{
	}


	public void BgThread.Iclient.Start(BgThread.clsBgThread clsBgThread)
	{
	}

	#End Region

}
