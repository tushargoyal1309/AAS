using BgThread;
using AAS203.Common;
using AAS203Library.Instrument;

public class clsBgZeroOrder_AA201 : BgThread.IBgWorker
{

	#Region " Constructors "

	public clsBgZeroOrder_AA201()
	{
		base.New();
	}

	public clsBgZeroOrder_AA201(int intLampPosition, ref Label lblSt1Zero, ref Label lblSt2Zero, ref Label lblSt3Zero, ref AAS203.AASGraph objGraphZero)
	{
		//=====================================================================
		// Procedure Name        : New
		// Parameters Passed     : intLampPosition,lblSt1Zero,lblSt2Zero,lblSt3Zero,objGraphZero
		// Returns               : None
		// Purpose               : To initialize the object of this class
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 11-Apr-2007
		// Revisions             : 
		//=====================================================================
		base.New();

		try {
			//--- set reference of passed variables to module level variables
			mlblStatus1ZeroOrder = lblSt1Zero;
			mlblStatus2ZeroOrder = lblSt2Zero;
			mlblStatus3ZeroOrder = lblSt3Zero;
			mObjGraphZeroOrder = objGraphZero;
			mintLampPosition = intLampPosition;

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
	private AASGraph mObjGraphOpt;

	private int mintLampPosition;
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
		// Returns               : None
		// Purpose               : To Initialize the thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 11-Apr-2007
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
		// Author                : Mangesh Shardul
		// Created               : 11-Apr-2007
		// Revisions             : 
		//=====================================================================
		CWaitCursor objwait = new CWaitCursor();
		string strPreviousStatusMessage;
		try {
			//--- Added by Sachin Dokhale on 25.03.07
			//--- To know the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBar1.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *ZeroOrder";
				Application.DoEvents();
			}
			//---

			if (mobjThreadController.Running) {
				//--- perform zero order for 201
				if (funcOptimise_Zero_Order_201(mlblStatus1ZeroOrder, mlblStatus2ZeroOrder, mlblStatus3ZeroOrder, mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt, mObjGraphZeroOrder, mObjGraphOpt, mobjThreadController) == true) {
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

	private bool funcOptimise_Zero_Order_201(ref Label lblSt1Zero = null, ref Label lblSt2Zero = null, ref Label lblSt3Zero = null, ref Label lblSt1Opt = null, ref Label lblSt2Opt = null, ref Label lblSt3Opt = null, ref AASGraph objGraphZero = null, ref object objGraphOpt = null, BgThread.IBgThread objController = null)
	{
		//---------------------------------------------------------------------------------------
		//Procedure Name         :   funcOptimise_Zero_Order_201
		//Description            :   To optimise Turret position 
		//Parameters             :   objController as Thread controler
		//Parameters affected    :   lblSt1Zero,lblSt1Opt,lblSt2Zero,lblSt3Zero,lblSt2Opt,lblSt3Opt as label object
		//                           objGraphZero,objGraphOpt as AASGraph
		//Return                 :   True if success
		//Time/Date              :   11-Apr-2007
		//Dependencies           :   parameter objects must be passed
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------
		//void	Optimize_Zero_order_AA202(HWND hpar,int pos)
		//{
		//	double   cur=0.0;
		//	HWND		hwnd;
		//	HDC		hdc;
		//	BOOL		flag= TRUE, zero = FALSE;
		//   #ifndef FINAL
		//	    Get_Instrument_Parameters(&Inst);
		//   #End If
		//	Inst =  GetInstData();

		//	if(GetInstrument() != AA202 )
		//		AIR_OFF();

		//	hwnd= CreateWindowPeak(hpar, " ZERO ORDER ","SKCK1",0 );
		//   If (hwnd) Then
		//	{
		//		hdc= GetDC(hwnd);
		//		SetBkColor(hdc, RGB(192, 192, 192));
		//		SetText(hwnd, IDC_STATUS,"Initialising Please Wait  .......");
		//		Inst->Lamp_par.lamp[pos].lamp_optpos=1;//0;
		//		Inst->Lamp_par.wvzero = 100.0;
		//       If (Find_Wavelength_Home(hdc, 5, 150)) Then
		//		{
		//			ShowTurretElement(hwnd);
		//           If (Slit_Home()) Then
		//			{
		//				//All_Lamp_Off(); //--mdf by sk on 24/10/2001
		//				cur = Inst->Lamp_par.lamp[pos].cur;
		//				Set_HCL_Cur(cur,pos);
		//				flag=Test_Lamp_Presence(hwnd);
		//               If (flag) Then
		//				{
		//                   If (!zero) Then
		//					{
		//						InitGraphParam(hwnd);SetFocus(hwnd);
		//						zero = Zero_Order(hwnd, hdc);
		//                       If (!zero) Then
		//						{
		//							Gerror_message_new("ZERO-ORDER Peak not found", "ZERO ORDER");
		//							Beep();//pc_sound(1000,2);;pc_sound(1000,2); pc_sound(1000,2);
		//							flag=FALSE;
		//						}
		//					}//!zero
		//				}//if flag
		//			} //slit home
		//		} // find_mech_zero
		//		ReleaseDC(hwnd, hdc);
		//		DestroyWindowPeak(hwnd,hpar);

		//		if(GetInstrument() != AA202 )
		//			AIR_ON();
		//	}  // if oflag
		//}
		//--------------------------------------------------------------------------------------
		int intCounter;
		bool blnFlag;
		bool blnZeroOrder;
		int intPos;
		double dbllmp_current;
		int intlmp_position;

		try {
			//---make air off is instrument type is not 201
			if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				gobjCommProtocol.funcAir_OFF();
			}

			if (!IsNothing(lblSt3Zero)) {
				lblSt3Zero.Text = Const_Initialize;
				lblSt3Zero.Refresh();
			}

			gobjInst.Lamp.LampParametersCollection.item(mintLampPosition).LampOptimizePosition = 1;
			gobjInst.Lamp.WavelengthZero = 100.0;

			//---find wavelength home 
			if (gobjCommProtocol.funcFind_Wavelength_Home()) {
				//---set slit to home position
				if (gobjCommProtocol.gFuncSlit_Home()) {
					//--- Get current and slit position of lamp 

					//---commented on 11.09.09
					//dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(mintLampPosition).Current
					//---added on 11.09.09
					dbllmp_current = gobjInst.Lamp.LampParametersCollection.item(mintLampPosition - 1).Current;

					gobjInst.Lamp_Position = mintLampPosition;

					//---set hcl current to turret
					if (!gobjCommProtocol.funcSet_HCL_Cur(dbllmp_current, mintLampPosition)) {
						gobjMessageAdapter.ShowMessage(constSetHCLCurError);
						Application.DoEvents();
					}

					if (gobjInst.Current == 0.0) {
						gobjInst.Current = dbllmp_current;
					}

					//---test for lamp presence
					blnFlag = gobjCommProtocol.funcTestLampPresence(lblSt1Zero, lblSt2Zero, lblSt3Zero);

					if (blnFlag) {
						if (!blnZeroOrder) {
							//---perform zero order
							blnZeroOrder = funcZero_Order_201(lblSt1Zero, lblSt2Zero, lblSt3Zero, objGraphZero, objController);
							if (!blnZeroOrder) {
								gobjMessageAdapter.ShowMessage(constZeroOrderPeakNotFound);
								Application.DoEvents();
								blnFlag = false;
							}
							//---Not blnZeroOrder 
						}
						//---blnZeroOrder 
					}
					//---blnflag
				}
				//---slit home 
			}
			//---wv zero

			//---set air on if instrument type is not 201
			if (!(gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				gobjCommProtocol.funcAir_ON();
			}

			gobjCommProtocol.mobjCommdll.subTime_Delay(100);

			Application.DoEvents();

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

	private bool funcZero_Order_201(ref Label lblSt1Zero = null, ref Label lblSt2Zero = null, ref Label lblSt3Zero = null, ref AASGraph objGraphZero = null, BgThread.IBgThread objController = null)
	{
		//---------------------------------------------------------------------------
		//Procedure Name         :   funcZero_Order_201
		//Description            :   To set zero order
		//Parameters             :   lblSt1Zero,lblSt2Zero,lblSt3Zero,objGraphZero,objController
		//Time/Date              :   11-Apr-2007
		//Dependencies           :   Serial communication
		//Author                 :   Mangesh Shardul
		//Revision               :
		//Revision by Person     :   
		//---------------------------------------------------------------------------
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
		//---------------------------------------------------------------------------
		int rPOs;
		int intCounter;
		int chNew;
		int chBase;
		int max_int;
		int in_pos;
		bool blnFlag = false;
		double dblStepsPerNM = 50.0;
		double dblXval;
		double dblYval;
		string strValue = "";
		try {
			//--- set steps per nm for 201
			dblStepsPerNM = CONST_STEPS_PER_NM_AA201;

			//---set calibration mode as HCLE
			if (gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) == false) {
				gobjMessageAdapter.ShowMessage(constCalibrationMode);
				Application.DoEvents();
			}

			if (!IsNothing(lblSt3Zero)) {
				lblSt3Zero.Text = "ZERO-ORDER Peak Search";
				lblSt3Zero.Refresh();
			}

			//---search for approximate wavelength peak
			//---where WVZERORANGE=300
			rPOs = gobjCommProtocol.funcSearch_Approc_WV_Peak(WVZERORANGE, 120.0, lblSt1Zero, lblSt2Zero, lblSt3Zero);

			//---adjust pmt between 80-350
			gobjCommProtocol.funcAdj_Pmt_ForValue(80, 350, true);

			if (!IsNothing(lblSt1Zero)) {
				lblSt1Zero.Text = "PMT : -" + Format(gobjInst.PmtVoltage, "000");
			}

			//---set graph properties
			objGraphZero.YAxisMin = gFuncGetEnergy(2047);
			objGraphZero.YAxisMax = gFuncGetEnergy(2047.0 + 409.6 * 5);
			objGraphZero.Refresh();
			Application.DoEvents();

			max_int = 3000;
			blnFlag = false;
			intCounter = 1;

			//---rotate wavelength drive anticlockwise
			//---approximate wavelength peak + 25 times.
			for (intCounter = 1; intCounter <= rPOs + CONST_STEPS_PER_NM_AA201; intCounter++) {
				gobjCommProtocol.funcRotate_Anticlock_Wv();
			}

			//---rotate wavelength drive clockwise
			//---25 times.
			for (intCounter = 1; intCounter <= CONST_STEPS_PER_NM_AA201; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
			}

			//---get current wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constGetCurWvError);
				Application.DoEvents();
			}

			//--- Set zero order peak search range
			if (!IsNothing(lblSt2Zero)) {
				lblSt2Zero.Text = "ZERO-ORDER  Peak Search  Range ( " + gobjInst.WavelengthCur + "nm - " + FormatNumber(gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM_AA201, 2) + "nm)";
				lblSt2Zero.Refresh();
			}

			//--- Set graph properties
			objGraphZero.XAxisMin = (int)gobjInst.WavelengthCur;
			objGraphZero.XAxisMax = (int)gobjInst.WavelengthCur + WVZERORANGE / CONST_STEPS_PER_NM_AA201;
			objGraphZero.YAxisLabel = "ENERGY";
			objGraphZero.XAxisLabel = "WAVELENGTH (nm)";
			objGraphZero.Refresh();

			in_pos = 1;
			max_int = 0;

			//---read ADC filter
			gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chBase);

			//---iterate 300 times 
			//---where WVZERORANGE=300
			for (intCounter = 1; intCounter <= WVZERORANGE; intCounter++) {
				strValue = "";
				//---rotate wavelength clockwise
				gobjCommProtocol.funcRotate_Clock_Wv();
				//---read ADC filter.
				gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew);
				if (chNew > max_int) {
					//---memorize highest ADC filter reading and its position
					max_int = chNew;
					in_pos = intCounter;
					if (max_int - chBase > 210) {
						blnFlag = true;
					}
				}
				dblXval = FormatNumber(gobjInst.WavelengthCur + intCounter / CONST_STEPS_PER_NM_AA201, 4);
				dblYval = gFuncGetEnergy(chNew);
				strValue = dblXval + "," + dblYval;
				if (!objController == null) {
					//---send x,y axis data to plot graph 
					objController.Display(strValue);
				}
			}

			if (!IsNothing(lblSt2Zero)) {
				lblSt2Zero.Text = "Positioning to 0.00 nm Please Wait ..... ";
				lblSt2Zero.Refresh();
			}

			//---rotate wavelength drive anticlockwise 300 +25 times
			for (intCounter = 1; intCounter <= WVZERORANGE + CONST_STEPS_PER_NM_AA201; intCounter++) {
				gobjCommProtocol.funcRotate_Anticlock_Wv();
			}

			//---rotate wavelength drive clockwise  highest ADC filter reading counter +25 times
			for (intCounter = 1; intCounter <= in_pos + CONST_STEPS_PER_NM_AA201; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
			}

			//---get current wavelength
			if (gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur) == false) {
				gobjMessageAdapter.ShowMessage(constSetCurWvError);
				Application.DoEvents();
			}

			gobjInst.Lamp.WavelengthZero = gobjInst.WavelengthCur;
			gobjInst.WavelengthCur = 0.0;

			//---set current wavelength
			gobjCommProtocol.funcSet_Current_Wv(gobjInst.WavelengthCur);

			//---set slit width as 0.3
			gobjCommProtocol.funcSet_SlitWidth(0.3);

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
