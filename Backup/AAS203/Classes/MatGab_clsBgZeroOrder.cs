using BgThread;
using AAS203.Common;
using AAS203Library.Instrument;

public class clsBgZeroOrder : BgThread.IBgWorker
{

	#Region " Constructors "

	public clsBgZeroOrder()
	{
		base.New();
	}

	public clsBgZeroOrder(ref Label lblSt1Zero, ref Label lblSt2Zero, ref Label lblSt3Zero, ref AAS203.AASGraph objGraphZero, ref Label lblWavelengthStatus)
	{
		//=====================================================================
		// Procedure Name        : New
		// Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
		// Returns               : 
		// Purpose               : To initialize the object this class
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		base.New();

		try {
			mlblStatus1ZeroOrder = lblSt1Zero;
			mlblStatus2ZeroOrder = lblSt2Zero;
			mlblStatus3ZeroOrder = lblSt3Zero;
			mObjGraphZeroOrder = objGraphZero;
			mlblWavelengthStatus = lblWavelengthStatus;

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

	#Region " Private Variables "

	private clsBgThread mController;
	private IBgThread mobjThreadController;
	private Label mlblStatus1ZeroOrder;
	private Label mlblStatus2ZeroOrder;
	private Label mlblStatus3ZeroOrder;
	private Label mlblStatus1Opt;
	private Label mlblStatus2Opt;
	private Label mlblStatus3Opt;
	private AASGraph mObjGraphZeroOrder;
	private object mObjGraphOpt;

	private Label mlblWavelengthStatus;
	#End Region

	#Region " Constants "


	private const  Const_Initialize = "Initialising Please Wait  .......";
	#End Region

	#Region " Public Functions "

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
		// Parameters Passed     : None
		// Returns               : None
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
			//--- Added by Sachin Dokhale on 25.03.07
			//--- To know the Status of Thread on Status Bar of MDI Main
			string strPreviousStatusMessage;
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBar1.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *ZeroOrder";
				Application.DoEvents();
			}
			//---

			if (mobjThreadController.Running) {
				//---perform zero order
				if (funcOptimise_Zero_Order(mlblStatus1ZeroOrder, mlblStatus2ZeroOrder, mlblStatus3ZeroOrder, mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt, mObjGraphZeroOrder, mObjGraphOpt, mobjThreadController, mlblWavelengthStatus) == true) {
					mobjThreadController.Completed(false);
					Application.DoEvents();
				}
			} else {
				mobjThreadController.Completed(true);
				Application.DoEvents();
				//--- Added by Sachin Dokhale on 25.03.07
				//--- To remove the Status of Thread on Status Bar of MDI Main
				if (gblnShowThreadOnfrmMDIStatusBar) {
					gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
					Application.DoEvents();
				}
				//---
				return;
			}
			//--- Added by Sachin Dokhale on 25.03.07
			//--- To remove the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
				Application.DoEvents();
			}
		//---
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

	#End Region

	#Region " Private Functions "

	private bool funcOptimise_Zero_Order(ref Label lblSt1Zero = null, ref Label lblSt2Zero = null, ref Label lblSt3Zero = null, ref Label lblSt1Opt = null, ref Label lblSt2Opt = null, ref Label lblSt3Opt = null, ref object objGraphZero = null, ref object objGraphOpt = null, BgThread.IBgThread objController = null, ref Label lblWvStatus = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcOptimise_Zero_Order
		//Description            :   To optimise all turret with zero order 
		//Parameters             :   lblSt1Zero,lblSt2Zero,lblSt3Zero
		//                           lblSt1Opt,lblSt2Opt,lblSt3Opt
		//                           objGraphZero,objGraphOpt
		//                           objController,lblWvStatus
		//Time/Date              :   5/10/06
		//Dependencies           :   Serial Communication
		//Author                 :   Deepak B.
		//Revision               :   1
		//Revision by Person     :   Deepak B. on 26.11.06
		//--------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------
		//void	S4FUNC 	Optimize_Zero_order(HWND hpar)
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

		// MessageBox(hwnd, "Plz select whether you want to skip zero order or not", "AAS203", MB_OK);

		//if (MessageBox(hwnd, "Do you want to perform zero order", "Confirmation", MB_YESNO)==IDYES)
		//{
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
		//	if (Find_Turret_Home(hpar)){ //0
		//	  if(Find_Wavelength_Home(hdc, 5, 150)){ //1
		//		 ShowTurretElement(hwnd);
		//		 if (Slit_Home()){ //2
		//		  for (pos = 1; pos<=6; pos++){ //3
		//			 if (strcmp(trim(Inst->Lamp_par.lamp[pos-1].elname),"")==0)
		//				continue;
		//			 if(Inst->Lamp_old!=pos){ //4
		//				strcpy(line1,"");
		//				sprintf(line1, " Setting Lamp from %d to %d position. ",Inst->Lamp_old, pos);
		//				SetText(hwnd, IDC_STATUS,line1);
		//				if (!Position_Turret(hpar, pos,TRUE)){ //5
		//					Gerror_message_new("Error in Turret Module ..", "TURRET");
		//					break;
		//				  } //5
		//			  } //4
		//			 SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......        ");
		//			 All_Lamp_Off();
		//			 cur = Inst->Lamp_par.lamp[Inst->Lamp_pos-1].cur;
		//			 Set_HCL_Cur(cur,Inst->Lamp_pos);
		//			 if (Inst->Cur==(double) 0.0){ //6
		//				Inst->Cur=cur;
		//			  } //6

		//			 flag=Test_Lamp_Presence(hwnd);
		//			 if (flag){ //7
		//				if (!zero){ //8
		//				  InitGraphParam(hwnd);SetFocus(hwnd);
		//				  zero = Zero_Order(hwnd, hdc);
		//				  if (!zero) { //9
		//					 Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
		//					 Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
		//					 flag=FALSE;
		//					} //9
		//				  InitGraphParam(hwnd1);
		//				 }//!zero //8
		//			  if (flag){ //10
		//				 SetFocus(hwnd1);
		//				 Tur_Opt(hwnd1, hdc1);
		//				 } //10
		//			  else break;
		//			}//if flag //7
		//		 } //for //3
		//		} //slit home //2
		//	  } // find_mech_zero //1
		//	 } //turret home //0
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
		//--------------------------------------------------------------------------------------
		int intCounter;
		bool blnFlag;
		bool blnZeroOrder;
		int intPos;
		double dbllmp_current;
		int intlmp_position;
		bool blnIsSlitHome;
		frmZeroOrder2 objfrmOpt;
		try {
			//--- set graph properties
			((AASGraph)objGraphZero).XAxisMin = -2;
			((AASGraph)objGraphZero).XAxisMax = 4;
			((AASGraph)objGraphZero).YAxisLabel = "ENERGY";
			((AASGraph)objGraphZero).XAxisLabel = "WAVELENGTH (nm)";
			((AASGraph)objGraphZero).XAxisMinorStep = 1;
			((AASGraph)objGraphZero).XAxisStep = 1;

			((AASGraph)objGraphZero).AldysPane.XAxis.PickScale(-2, 4);
			((AASGraph)objGraphZero).AldysPane.XAxis.MinorStepAuto = true;
			((AASGraph)objGraphZero).AldysPane.XAxis.StepAuto = true;
			((AASGraph)objGraphZero).Refresh();
			//--- If instrument type is not 201 then set Air off.
			if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				gobjCommProtocol.funcAir_OFF();
			}

			if (!lblSt3Zero == null) {
				lblSt3Zero.Text = Const_Initialize;
				lblSt3Zero.Refresh();
			}

			for (intPos = 0; intPos <= 5; intPos++) {
				gobjInst.Lamp.LampParametersCollection.item(intPos).LampOptimizePosition = 0;
			}
			gobjInst.Lamp.WavelengthZero = 100.0;

			//--- Position turret at home position.
			if (gobjCommProtocol.gFuncTurret_Home()) {
				//--- Position Wavelength drive to home position.
				if (gobjCommProtocol.gFuncWavelength_Home(lblWvStatus)) {
					//--- Added by Mangesh on 13-Apr-2007

					//--- If instrument type is 203D then position entrance and exit slit 
					//--- to home position else position only entrance slit to home position.

					if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
						if (gobjCommProtocol.gFuncSlit_Home()) {
							blnIsSlitHome = gobjCommProtocol.funcExitSlit_Home();
						}
					} else {
						blnIsSlitHome = gobjCommProtocol.gFuncSlit_Home();
					}
					//---

					if (blnIsSlitHome) {
						for (intPos = 1; intPos <= 6; intPos++) {
							//--- Search for the presence of first lamp in turret assembly 
							//--- and position turret to that location.
							if (gobjInst.Lamp.LampParametersCollection.item(intPos - 1).ElementName != "") {
								if (gobjInst.Lamp_Old != intPos) {
									if (!lblSt3Zero == null) {
										lblSt3Zero.Text = "Setting Lamp from " + gobjInst.Lamp_Old + " to " + intPos + " position.";
										lblSt3Zero.Refresh();
									}
									if (gobjCommProtocol.gFuncTurret_Position(intPos, true) == false) {
										break; // TODO: might not be correct. Was : Exit For
									}
								}

								if (!lblSt3Zero == null) {
									lblSt3Zero.Text = Const_Initialize;
									lblSt3Zero.Refresh();
								}

								//--- Set all lamps off.
								gobjCommProtocol.funcAll_Lamp_Off();

								//--- Get current and lamp position to optimize
								dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Current;
								intlmp_position = gobjInst.Lamp_Position;

								//--- Set HCL current to the current turret position.
								if (gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, intlmp_position) == false) {
									gobjMessageAdapter.ShowMessage(constSetHCLCurError);
									Application.DoEvents();
								}

								if (gobjInst.Current == 0.0) {
									gobjInst.Current = dbllmp_current;
								}

								//--- Test for lamp presence.
								blnFlag = gobjCommProtocol.funcTestLampPresence(lblSt1Zero, lblSt2Zero, lblSt3Zero);

								if (blnFlag == true) {
									if (blnZeroOrder == false) {
										//--- If lamp is present then perform zero order.
										blnZeroOrder = funcZero_Order(lblSt1Zero, lblSt2Zero, lblSt3Zero, objGraphZero, objController);
										if (blnZeroOrder == false) {
											gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound);
											Application.DoEvents();
											blnFlag = false;
										}
									}
									if (blnFlag == true) {
										objController.Completed(true);

										//--- Initialize zero order form
										objfrmOpt = new frmZeroOrder2();

										//--- set location of zero order form on screen
										objfrmOpt.StartPosition = FormStartPosition.Manual;
										objfrmOpt.Location = new Point(OptAllThreadWindowLocationX, OptAllThreadWindowLocationY);
										objfrmOpt.StartOptTread();
										if (objfrmOpt.ShowDialog() == DialogResult.OK) {
											objfrmOpt.Close();
											objfrmOpt.Dispose();
										}
									} else {
										break; // TODO: might not be correct. Was : Exit For
									}
								}
								//--- blnflag
							}
							//--- if condition
						}
						//--- for loop
					}
					//--- slit home 
				}
				//--- wv zero
			}
			//--- turret home

			//--- If instrument type is not 201 then set air on
			if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				gobjCommProtocol.funcAir_ON();
			}

			gobjCommProtocol.mobjCommdll.subTime_Delay(1500);

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

	private bool funcZero_Order(ref Label lblSt1Zero = null, ref Label lblSt2Zero = null, ref Label lblSt3Zero = null, ref object objGraphZero = null, BgThread.IBgThread objController = null)
	{
		//--------------------------------------------------------------------------------------------
		//Procedure Name         :   funcZero_Order
		//Description            :   To start zero order
		//Parameters             :   lblSt1Zero,lblSt2Zero,lblSt3Zero
		//                           objGraphZero,objController
		//Time/Date              :   5/10/06
		//Dependencies           :   Serial Communication
		//Author                 :   Deepak B.
		//Revision               :   1
		//Revision by Person     :   Deepak B. on 26.11.06
		//--------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------
		//BOOL	Zero_Order(HWND hwnd, HDC hdc)
		//{
		//int		chnew, chbase;
		//int		in_pos, i,max_int,  rpos;
		//BOOL		flag = FALSE;
		//char    	line1[80]="";
		//float stepspernm=50.0;

		//if (GetInstrument()==AA202)
		//   stepspernm = STEPS_PER_NM_AA202;
		//Else
		//   stepspernm = STEPS_PER_NM;

		// Cal_Mode(HCLE);
		// SetText(hwnd, IDC_STATUS, "ZERO-ORDER Peak Search");
		// pc_delay (200);
		// rpos = Search_Approc_wv_Peak(hwnd, WVZERORANGE, (double) 120.0);
		//#If !NEWZERO Then
		// Adj_PMT_forvalue(hwnd, (double)4000.0, (double)350);
		//#Else
		// Adj_PMT_forvalue(hwnd, (4000.0/5000.0 *100.0), 350);
		//#End If
		// Show_Pmt(hwnd, Inst->Pmtv);
		// PeakGraph.Ymin= GetEnergy(2047);
		// PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);
		// max_int = 3000;   flag = FALSE;
		// i=1;
		// for (i=1; i<=rpos+stepspernm; i++)   {
		//		Rotate_Anticlock_Wv();     
		//	}
		// for (i=1; i<=stepspernm; i++)  {
		//	Rotate_Clock_Wv();    
		//	}
		// Inst->Wvcur = Get_Cur_Wv();
		// strcpy(line1,""); sprintf(line1, "ZERO-ORDER  peak Search  Range ( %5.2fnm - %5.2fnm)",
		//		Inst->Wvcur,Inst->Wvcur+WVZERORANGE/(double)stepspernm);
		// PeakGraph.Xmin= Inst->Wvcur;
		// PeakGraph.Xmax= Inst->Wvcur+WVZERORANGE/(double) stepspernm;
		//  strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"Wv(nm)");
		// Show_Peak_Param(hwnd, WVZERORANGE);

		// SetText(hwnd, IDC_STATUS1,line1);
		// in_pos = 1;
		// max_int = 0;
		// chbase = ReadADCFilter();
		// for (i=1; i<=WVZERORANGE; i++) {
		//	Rotate_Clock_Wv();// pc_delay(100);
		//	chnew = ReadADCFilter();
		//	if (chnew > max_int)	 {
		//	  max_int = chnew;
		//	  in_pos =i;
		//	  if (max_int - chbase > 210) flag = TRUE;
		//	 }
		//	if (i==1)
		//	  GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy( chnew));
		//                                Else
		//	  GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
		//  }
		//  GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
		//  SetText(hwnd, IDC_STATUS1," Positioning to 0.00 nm Please Wait ..... ");
		//#If EMU Then
		// Wait_For_Some_Msg(5);
		//#End If
		//  for (i=1; i <= WVZERORANGE+stepspernm; i++) {
		//	 Rotate_Anticlock_Wv();	 //  pc_delay(400);
		//	 }
		//  for (i=1; i <= in_pos+stepspernm; i++)   {
		//	 Rotate_Clock_Wv();	//	 pc_delay(400);
		//	}
		//  Inst->Wvcur = Get_Cur_Wv();
		//  Inst->Lamp_par.wvzero = Inst->Wvcur;
		//  Inst->Wvcur = (double) 0.0;
		//  Set_Cur_Wv();        

		//  Set_SlitWidth((double)0.3);
		//  pc_delay(200);
		// return(flag);
		//}
		//--------------------------------------------------------------------------------------------
		int rPOs;
		int intCounter;
		int chNew;
		int chBase;
		int max_int;
		int in_pos;
		bool blnFlag = false;
		double dblXval;
		double dblYval;
		string strValue = "";
		try {
			//if (GetInstrument()==AA202)
			//   stepspernm = STEPS_PER_NM_AA202;
			//Else
			//   stepspernm = STEPS_PER_NM;

			//--- Set calibration mode as HCLE.
			if (gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) == false) {
				gobjMessageAdapter.ShowMessage(constCalibrationMode);
				Application.DoEvents();
			}

			if (!lblSt3Zero == null) {
				lblSt3Zero.Text = "ZERO-ORDER Peak Search";
				lblSt3Zero.Refresh();
			}

			//--- Search approximate Wavelength Peak.
			rPOs = gobjCommProtocol.funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0, lblSt1Zero, lblSt2Zero, lblSt3Zero);

			//--	Adjust pmt between 80-350 volt
			gobjCommProtocol.funcAdj_Pmt_ForValue(80, 350, true);

			if (!lblSt1Zero == null) {
				lblSt1Zero.Text = "PMT : -" + Format(gobjInst.PmtVoltage, "###");
			}

			//--- Set graph properties
			((AAS203.AASGraph)objGraphZero).YAxisMin = 0;
			((AAS203.AASGraph)objGraphZero).YAxisMax = (int)FormatNumber(gFuncGetEnergy(2047.0 + 409.6 * 5), 1);
			((AAS203.AASGraph)objGraphZero).AldysPane.YAxis.PickScale((int)((AAS203.AASGraph)objGraphZero).YAxisMin, (int)((AAS203.AASGraph)objGraphZero).YAxisMax);
			((AAS203.AASGraph)objGraphZero).AldysPane.YAxis.MinorStepAuto = true;
			((AAS203.AASGraph)objGraphZero).AldysPane.YAxis.StepAuto = true;
			((AAS203.AASGraph)objGraphZero).Refresh();

			max_int = 3000;
			blnFlag = false;
			intCounter = 1;

			//--- If instrument type is 201 then Rotate Wavelength Drive 
			//--- anticlockwise (Output of step 2 + 25) times and rotate Wavelength 
			//--- drive clockwise 25 times. If instrument type is not 201 then rotate 
			//--- Wavelength drive anticlockwise (Output of step 2 + 50) times and rotate 
			//--- Wavelength drive clockwise 50 times.

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				for (intCounter = 1; intCounter <= rPOs + CONST_STEPS_PER_NM_AA201; intCounter++) {
					gobjCommProtocol.funcRotate_Anticlock_Wv();
				}

				for (intCounter = 1; intCounter <= CONST_STEPS_PER_NM_AA201; intCounter++) {
					gobjCommProtocol.funcRotate_Clock_Wv();
				}
			} else {
				for (intCounter = 1; intCounter <= rPOs + CONST_STEPS_PER_NM; intCounter++) {
					gobjCommProtocol.funcRotate_Anticlock_Wv();
				}

				for (intCounter = 1; intCounter <= CONST_STEPS_PER_NM; intCounter++) {
					gobjCommProtocol.funcRotate_Clock_Wv();
				}
			}

			//--- Get current wavelength.

			if (gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constGetCurWvError);
				Application.DoEvents();
			}

			//--- Display zero order peak search range
			if (!lblSt2Zero == null) {
				lblSt2Zero.Text = "ZERO-ORDER  Peak Search  Range ( " + gobjInst.WavelengthCur + "nm - " + gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM + "nm)";
			}

			//--- Set graph min max properties
			((AAS203.AASGraph)objGraphZero).XAxisMin = (int)gobjInst.WavelengthCur;
			((AAS203.AASGraph)objGraphZero).XAxisMax = (int)gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM;
			((AAS203.AASGraph)objGraphZero).YAxisLabel = "ENERGY";
			((AAS203.AASGraph)objGraphZero).XAxisLabel = "WAVELENGTH (nm)";
			((AAS203.AASGraph)objGraphZero).XAxisMinorStep = 1;
			((AAS203.AASGraph)objGraphZero).XAxisStep = 1;

			((AAS203.AASGraph)objGraphZero).AldysPane.XAxis.PickScale((int)gobjInst.WavelengthCur, (int)gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM);
			((AAS203.AASGraph)objGraphZero).AldysPane.XAxis.MinorStepAuto = true;
			((AAS203.AASGraph)objGraphZero).AldysPane.XAxis.StepAuto = true;
			((AAS203.AASGraph)objGraphZero).Refresh();

			in_pos = 1;
			max_int = 0;

			//--- Read ADC filter.
			gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chBase);

			//--- WVZERORANGE =300
			for (intCounter = 1; intCounter <= WVZERORANGE; intCounter++) {
				strValue = "";
				//--- Rotate Wavelength Clockwise.
				gobjCommProtocol.funcRotate_Clock_Wv();
				//--- Read ADC filter.
				gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew);
				//--- Memorize max ADC filter reading and its position.
				if (chNew > max_int) {
					max_int = chNew;
					in_pos = intCounter;
					if (max_int - chBase > 210) {
						blnFlag = true;
					}
				}
				dblXval = FormatNumber(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM, 2);
				dblYval = gFuncGetEnergy(chNew);
				strValue = dblXval + "," + dblYval;
				//--- send values to plot graph.
				if (!objController == null) {
					objController.Display(strValue);
				}
			}

			if (!lblSt2Zero == null) {
				lblSt2Zero.Text = "Positioning to 0.00 nm Please Wait ..... ";
			}

			//--- Rotate Wavelength drive anticlockwise (300 + 50) 
			//--- times.

			for (intCounter = 1; intCounter <= WVZERORANGE + CONST_STEPS_PER_NM; intCounter++) {
				gobjCommProtocol.funcRotate_Anticlock_Wv();
			}

			//--- Rotate Wavelength drive clockwise (Max ADC filter 
			//--- value position + 50) times.

			for (intCounter = 1; intCounter <= in_pos + CONST_STEPS_PER_NM; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
			}

			//--- Get current Wavelength.

			if (gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}

			//--- Memorize current Wavelength as WVZero Wavelength.
			gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur;
			gobjInst.WavelengthCur = 0.0;

			//--- Set current wavelength.
			gobjCommProtocol.funcSet_Current_Wv(gobjInst.WavelengthCur);

			//--- If instrument type 203D then set entrance and 
			//--- exit slit width as 0.8. If instrument type is not 203D then 
			//--- set entrance slit width as 0.3.

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				//--- parameter 2 is passed for entry and exit slit (both slit)
				//--- Slit width is changed from 0.5 to 0.8 according to V.C.K.
				gobjCommProtocol.funcSet_SlitWidth(0.8, 2);
			} else {
				//--- set entrance slit width as 0.3
				gobjCommProtocol.funcSet_SlitWidth(0.3);
			}

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

	#End Region

}
