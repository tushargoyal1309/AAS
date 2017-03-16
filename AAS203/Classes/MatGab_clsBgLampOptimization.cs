using BgThread;
using AAS203.Common;
using AAS203Library.Instrument;

public class clsBgLampOptimization : BgThread.IBgWorker
{

	#Region " Constructors "

	public clsBgLampOptimization()
	{
		base.New();
	}

	public clsBgLampOptimization(bool blnIsHCLECalibrationMode, ref AASGraph objGraph, ref Label lblStatusPMT, ref Label lblStatusLampPosition, ref Label lblStatusLampOptimisation, ref Label lblElementName, ref Label lblLampCurrent, ref Label lblWavelength, ref Label lblSlitWidth, ref Label lblFlameBurner)
	{
		//=====================================================================
		// Procedure Name        : New
		// Parameters Passed     : blnIsHCLECalibrationMode,objGraphm,lblStatusPMT
		//                         lblStatusLampPosition,lblStatusLampOptimisation,
		//                         lblElementName,lblLampCurrent,lblWavelength,         
		//                         lblSlitWidth,lblFlameBurner
		// Returns               : None
		// Purpose               : To set reference of passed variables 
		//                         to the module level variables variables
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Dec-2006
		// Revisions             : 
		//=====================================================================
		base.New();

		try {
			mblnIsHCLECalibrationMode = blnIsHCLECalibrationMode;
			mlblStatusPMT = lblStatusPMT;
			mlblLampPosition = lblStatusLampPosition;
			mlblLampOptimisation = lblStatusLampOptimisation;
			mObjGraph = objGraph;
			mlblElementName = lblElementName;
			mlblLampCurrent = lblLampCurrent;
			mlblWavelength = lblWavelength;
			mlblSlitWidth = lblSlitWidth;
			mlblFlameBurner = lblFlameBurner;

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

	#Region " Private member Variables "

	private IBgThread mobjThreadController;
	private bool mblnIsHCLECalibrationMode;
	private bool mblnIsLampOptimized;
	private double mdblLampCurrent;
	private int mintLampPosition;
	private Label mlblStatusPMT;
	private Label mlblLampPosition;
	private Label mlblLampOptimisation;
	private Label mlblElementName;
	private Label mlblLampCurrent;
	private Label mlblWavelength;
	private Label mlblSlitWidth;
	private Label mlblFlameBurner;
	private AASGraph mObjGraph;

	private AldysGraph.CurveItem mobjAnalysisCurve;
	#End Region

	#Region " Public Properties "

	public bool IsLampOptimized {
		get { return mblnIsLampOptimized; }
	}

	#End Region

	#Region " Public Functions "

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		//=====================================================================
		// Procedure Name        : Initialize
		// Parameters Passed     : Controller as BgThread.IBgThread
		// Returns               : None
		// Purpose               : To Initialize the worker thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Dec-2006
		// Revisions             : 
		//=====================================================================
		mobjThreadController = Controller;

	}

	public void BgThread.IBgWorker.Work()
	{
		//=====================================================================
		// Procedure Name        : Work
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To Start the worker thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Dec-2006
		// Revisions             : 
		//=====================================================================
		string strPreviousStatusMessage;
		double wvnew = 0.0;
		double dblSlitWidth = 0.0;
		double wvemis = 0.0;
		bool blnIsCheckIgnite;
		try {
			//--- Added by Sachin Dokhale on 25.03.07
			//--- To know the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBar1.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *Lamp Opti";
				Application.DoEvents();
			}
			//---
			//---For Analytical Peak 

			if (mblnIsHCLECalibrationMode == true) {
				//---STEP 15 : Set Instrument Conditions

				//---to set lamp current,pmt and d2 current
				gobjClsAAS203.funcSetInstrumentCondns(true, mlblElementName, mlblLampCurrent, mlblWavelength, mlblSlitWidth, mlblFlameBurner);

				//---to set calibration mode
				gobjCommProtocol.funcCalibrationMode(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode);

				//---get slit width from object variable
				dblSlitWidth = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).SlitWidth;

				if ((dblSlitWidth == 0)) {
					gobjMessageAdapter.ShowMessage(constSlitWidth);
				}

				//---STEP 16 : Set SlitWidth Value to Instrument
				//gobjCommProtocol.mobjCommdll.subTime_Delay(20)  '18.02.08
				//---set slit widths
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
					gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth, 2);
				} else {
					gobjCommProtocol.funcSet_SlitWidth(dblSlitWidth);
				}
				//gobjCommProtocol.mobjCommdll.subTime_Delay(20)  '18.02.08
				//---STEP 17 : Give Time Delay of 200 milliSeconds

				mlblLampOptimisation.Text = "INITIALISING Please Wait  ....... ";

				wvnew = gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Wavelength - (double)Fix(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Wavelength);
				if ((wvnew < 0.5)) {
					//wvnew= (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv);
					wvnew = (double)Fix(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Wavelength);
				} else {
					//wvnew= (double) ( (int) Inst->Lamp_par.lamp[Inst->Lamp_pos-1].wv)+(double) 0.5; 
					wvnew = (double)Fix(gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Wavelength) + 0.5;
				}

				mlblStatusPMT.Text = "Setting wavelength from " + gobjInst.WavelengthCur + " nm to " + wvnew + " nm";

				//---position wavelength drive to wavelength of an element
				gobjCommProtocol.Wavelength_Position(wvnew, mlblLampPosition);

				Application.DoEvents();

				mlblLampOptimisation.Text = "Optimizing " + gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).ElementName + " for Analytical Peak.";

				//---Finds Analytical Peak for HCLE Calibration Mode
				mblnIsLampOptimized = Analytical_Peak(mblnIsHCLECalibrationMode);

				//---Processing is Completed; Stop the thread
				mobjThreadController.Completed(false);

				if (!(mblnIsLampOptimized)) {
				//gobjMessageAdapter.ShowMessage(constAnalyticalPeak)
				//Application.DoEvents()
				} else {
					mblnIsLampOptimized = true;
				}

			} else {
				//---emission peak search routine

				//---to set hcl current,pmt,d2 current
				gobjClsAAS203.funcSetInstrumentCondns(false, mlblElementName, mlblLampCurrent, mlblWavelength, mlblSlitWidth, mlblFlameBurner);

				//---set calibration mode as emission
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.EMISSION);

				mlblLampOptimisation.Text = "INITIALISING Please Wait  ....... ";

				//---set all lamps off
				gobjCommProtocol.funcAll_Lamp_Off();
				//---set D2 current as 100
				gobjCommProtocol.funcSetD2Cur(100);
				//---make D2 lamp off
				gobjCommProtocol.D2_OFF();

				//---set slit widths
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
					gobjCommProtocol.funcSet_SlitWidth(gobjInst.Lamp.EMSCondition.SlitWidth, 2);
				} else {
					gobjCommProtocol.funcSet_SlitWidth(gobjInst.Lamp.EMSCondition.SlitWidth);
				}

				//---get emission wavelengths
				wvemis = gobjInst.Lamp.EMSCondition.Wavelength - (double)Fix(gobjInst.Lamp.EMSCondition.Wavelength);
				if ((wvemis < 0.5)) {
					wvemis = Fix(gobjInst.Lamp.EMSCondition.Wavelength);
				} else {
					wvemis = Fix(gobjInst.Lamp.EMSCondition.Wavelength) + 0.5;
				}
				mlblLampOptimisation.Text = "Setting wavelength from " + gobjInst.WavelengthCur + " nm to " + wvemis + " nm";
				//---position wavelength drive to element wavelength
				gobjCommProtocol.Wavelength_Position(wvemis, mlblLampPosition);
				mlblLampOptimisation.Text = "Optimizing " + gobjInst.ElementName + "  for Emission Peak.";

				//---check for air and fuel pressure condtions
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					blnIsCheckIgnite = gobjClsAAS203.funcCheck_Ignite_AA201();
				} else {
					blnIsCheckIgnite = gobjClsAAS203.funcCheck_Ignite();
				}

				if ((blnIsCheckIgnite)) {

					if (gobjMessageAdapter.ShowMessage(constLampOptimisation) == true) {
						Application.DoEvents();
						//---To show the window for Manual Optimization
						//---i.e. Continuous TimeScan Mode

						gobjClsAAS203.AbsorbanceScan();

					} else {
						Application.DoEvents();
					}

					gobjMessageAdapter.ShowMessage(constAspirateMaxStd);
					Application.DoEvents();

					gobjCommProtocol.mobjCommdll.subTime_Delay(100);

					//---Finds Peak for Emission Calibration Mode
					mblnIsLampOptimized = Analytical_Peak(false);

					//---Processing is Completed; Stop the thread
					mobjThreadController.Completed(false);

					if (!mblnIsLampOptimized) {
						gobjMessageAdapter.ShowMessage(constEmissionPeak);
						Application.DoEvents();
						mblnIsLampOptimized = false;
					} else {
						mblnIsLampOptimized = true;
						gobjClsAAS203.Auto_blank_Emission(true);
					}
				} else {
					//---Flame is OFF; Emission Peak Latching NOT Possible.
					//---Stop the thread
					mobjThreadController.Completed(true);
				}
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

	private bool Analytical_Peak(bool blnIsHCLEMode)
	{
		//=====================================================================
		// Procedure Name        : Analytical_Peak
		// Parameters Passed     : blnIsHCLEMode
		// Returns               : Boolean - Return the status of optimisation 
		// Purpose               : To search Analytical Peak
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : Thursday, May 19, 2005 4:00 pm
		// Revisions             : 1
		//=====================================================================
		//        BOOL		Analytical_Peak(HWND hwnd, HDC hdc, BOOL flag1)
		//{
		//double		pmt=(double)0.0;
		//int		chnew, chbase, rpos;
		//int		in_pos, i,max_int;
		//BOOL		flag = FALSE;
		//char    	line1[80]="";
		//float stepspernm=50.0;
		//float wvrange = 100.0;
		// ReinitInstParameters();
		//if (GetInstrument()==AA202){
		// stepspernm = STEPS_PER_NM_AA202;
		// wvrange = WVRANGE_AA202;
		//}
		//else{
		// stepspernm = STEPS_PER_NM;
		// wvrange = WVRANGE;
		//}
		// Set_D2_Cur(100);
		//            If (flag1) Then
		//	Cal_Mode(HCLE);
		//            Else
		//	Cal_Mode(EMISSION);
		// Set_PMT((double)300.0);
		// SetText(hwnd, IDC_STATUS," Analytical Peak Search ");
		// if (flag1){
		//  if (Inst->Lamp_par.lamp[Inst->Lamp_pos-1].mode==AA)
		//	SetWindowText(hwnd,  "ANALYTICAL LINE SEARCH - AA mode");
		//  else if (Inst->Lamp_par.lamp[Inst->Lamp_pos-1].mode==AABGC){
		//	if( GetInstrument() == AA202){
		//                            If (GetSRLamp()) Then
		//		  SetWindowText(hwnd,  "ANALYTICAL LINE SEARCH - AABGC (SR Lamp) mode");
		//                            Else
		//			SetWindowText(hwnd,  "ANALYTICAL LINE SEARCH - AABGC (D2 Lamp) mode");
		//	}
		//	else
		//		SetWindowText(hwnd,  "ANALYTICAL LINE SEARCH - AABGC mode");
		//	}
		//  }
		// else
		//	SetWindowText(hwnd,  "EMISSION LINE SEARCH");
		// PeakGraph.Ymin= GetEnergy(2047);
		//                                If (flag1) Then
		//	PeakGraph.Ymax= GetEnergy(2047.0+409.6*4);
		//                                Else
		//	PeakGraph.Ymax= GetEnergy(2047.0+409.6*5);
		//// XMIN = 1; XMAX = Inst->Wvcur+(double) WVRANGE;/50.0
		// ReinitInstParameters();
		// if (Inst->Slitpos>68)
		//	pmt = (double)380.0;
		// else  if (Inst->Slitpos>64)
		//	pmt = (double)340.0;
		// else pmt = (double)300.0;
		// rpos = Search_Approc_wv_Peak(hwnd, wvrange, pmt);
		//// rpos = set_max_wv(x1, y, WVRANGE, pmt);
		// ReinitInstParameters();
		//                                        If (flag1) Then
		//#If !NEWZERO Then
		//	Adj_PMT_forvalue(hwnd, (double)3500.0, (double)700.0);
		//#Else
		//	Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0), (double)700.0);
		//#End If
		//                                        Else
		//#If !NEWZERO Then
		//  Adj_PMT_forvalue(hwnd, (double)4000.0, (double)700);
		//#Else
		//  Adj_PMT_forvalue(hwnd, (double)(4000.0*100.0/5000.0), (double)700);
		//#End If
		//  Show_Pmt(hwnd, Inst->Pmtv);
		// ReinitInstParameters();
		// for (i=1; i<=rpos+stepspernm; i++){
		//	Rotate_Anticlock_Wv();   //	pc_delay(400);
		//	}
		// for (i=1; i<=stepspernm; i++) {
		//	Rotate_Clock_Wv(); //	pc_delay(400);
		//	}
		// Inst->Wvcur = Get_Cur_Wv();
		// strcpy(line1,"");
		// sprintf(line1, "    Analytical Peak Search   Range ( %5.2fnm - %5.2fnm )",
		//  Inst->Wvcur ,Inst->Wvcur+wvrange/(double)stepspernm);
		// PeakGraph.Xmin= Inst->Wvcur;
		// PeakGraph.Xmax= Inst->Wvcur+(double) wvrange/(double)stepspernm;
		//                                                    If (flag1) Then
		//	 strcpy(PYaxis,"ENERGY");
		//                                                    Else
		//	 strcpy(PYaxis,"EMISSION");
		// strcpy(PXaxis,"Wv (nm)");
		// Show_Peak_Param(hwnd, wvrange);

		// SetText(hwnd, IDC_STATUS,line1);
		// in_pos = 1; max_int = 0;
		// chbase = ReadADCFilter();
		// for (i=1; i<=wvrange; i++)  {
		//	Rotate_Clock_Wv(); //	pc_delay(100);
		//	chnew = ReadADCFilter();
		//	if (chnew > max_int)    {
		//		max_int = chnew;
		//		in_pos =i;
		//		if (max_int - chbase > 100) flag = TRUE;
		//	 }
		//	if (i==1)
		//	  GPlotInit(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
		//                                                                    Else
		//	  GPlot(hdc, Inst->Wvcur+(double)i/(double) stepspernm, GetEnergy(chnew));
		//  }
		//  GShowPeak(hdc,Inst->Wvcur+(double)in_pos/(double) stepspernm,  GetEnergy(max_int),NULL);
		//#If EMU Then
		// Wait_For_Some_Msg(5);
		//#End If
		//  if (flag1){
		//	 if(GetInstrument() != AA202 )
		//		 AIR_ON();
		//  }
		//  strcpy(line1,""); sprintf(line1," Positioning to %5.2f nm Please Wait...",
		//			Inst->Wvcur+ (double) in_pos/(double)stepspernm);
		//  SetText(hwnd, IDC_STATUS,line1);
		//  for (i=wvrange+stepspernm; i > 0 ;i--)  {
		//	Rotate_Anticlock_Wv(); //	pc_delay(400);
		//	}
		//  for (i=1; i<=in_pos+stepspernm; i++) {
		//	 Rotate_Clock_Wv(); //	 pc_delay(400);
		//	}
		//  Inst->Wvcur = Get_Cur_Wv();
		///*  if (flag1)
		//	 AIR_ON();*/
		//  ReinitInstParameters();
		//  if (flag1 && flag)
		//	  if (Auto_blank(hwnd)) //, hdc))
		//		 Bgc(hwnd);
		//#If !DEMO Then
		//  for(i=0;i<100;i++)
		//	pc_delay(10000);
		//#End If
		// ReinitInstParameters();
		// return(flag);
		//}
		//=====================================================================
		double dblPMTVoltage = 0.0;
		int chnew;
		int chbase;
		int rpos;
		int in_pos;
		int i;
		int max_int;
		bool blnIsOptimized = false;
		string line1 = "";
		string strLampOptimisationText = "";
		float sngWVRange = 100.0;
		double dblWavelength;
		double dblEnergy;
		string strData;
		float StepsPerNM;
		try {
			gblnIsPeakSearchStarted = true;
			//---STEP 1 : Reinitialize Instrument Settings

			gobjClsAAS203.ReInitInstParameters();

			//---STEP 2 : Set the Steps/NM for 202 and 203

			//StepsPerNM = STEPS_PER_NM
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				StepsPerNM = CONST_STEPS_PER_NM_AA201;
				sngWVRange = WVRANGE_AA201;
			} else {
				StepsPerNM = CONST_STEPS_PER_NM;
				sngWVRange = WVRANGE;
			}

			//---STEP 3 : Set D2 Lamp Current Value as 100

			gobjCommProtocol.funcSetD2Cur(100);

			//---STEP 4 : Set Calibration Mode

			if (blnIsHCLEMode) {
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE);
			} else {
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.EMISSION);
			}

			//---STEP 5 : Set PMT Voltage as 300.0

			gobjCommProtocol.funcSet_PMT(300.0);

			//---STEP 6,7,8,9,10 : Set Status Labels 

			if ((blnIsHCLEMode)) {
				if ((gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Mode == EnumOperationMode.MODE_AA)) {
					strLampOptimisationText = "ANALYTICAL LINE SEARCH - AA Mode";
				} else if ((gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Mode == EnumOperationMode.MODE_AABGC)) {
					strLampOptimisationText = "ANALYTICAL LINE SEARCH - AABGC Mode";
				} else if ((gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).Mode == EnumOperationMode.MODE_EMMISSION)) {
					strLampOptimisationText = "EMISSION LINE SEARCH";
				} else {
					strLampOptimisationText = "ANALYTICAL LINE SEARCH";
				}
			}

			mlblLampOptimisation.Text = strLampOptimisationText;

			mObjGraph.AldysPane.Legend.IsVisible = false;

			mObjGraph.YAxisMin = gFuncGetEnergy(2047);
			if ((blnIsHCLEMode)) {
				//gFuncGetEnergy(2047.0 + 409.6 * 4)
				mObjGraph.YAxisMax = 80;
			} else {
				//gFuncGetEnergy(2047.0 + 409.6 * 5)  '06.09.07
				mObjGraph.YAxisMax = 100;
			}

			//---STEP 11 : Reinitialize Instrument settings.

			gobjClsAAS203.ReInitInstParameters();

			//---STEP 12 : Set PMT Voltage according to Slit position

			if ((gobjInst.SlitPosition > 68)) {
				dblPMTVoltage = 380.0;
			} else if ((gobjInst.SlitPosition > 64)) {
				dblPMTVoltage = 340.0;
			} else {
				dblPMTVoltage = 300.0;
			}
			//   '18.02.08
			//'**********************************************
			//'---STEP 9 : Set that Measurement lamp on and set the
			//'**********************************************
			//Call gobjCommProtocol.funcSet_HCL_Cur(gobjInst.Current, gobjInst.Lamp_Position)
			//   '18.02.08

			//---STEP 13 : Search Approx. Wavelength Peak for given range

			rpos = gobjCommProtocol.funcSearch_Approc_WV_Peak(sngWVRange, dblPMTVoltage, mlblStatusPMT, mlblLampPosition, mlblLampOptimisation);

			//---STEP 14 : Reinitialize Instrument Settings
			gobjClsAAS203.ReInitInstParameters();

			//---STEP 15 : Adjust PMT Voltage acording to Mode

			if ((blnIsHCLEMode)) {
				//--- if HCLE mode then Adjust pmt between 70-700
				if (gobjCommProtocol.funcAdj_Pmt_ForValue(70.0, 700.0, true) == false) {
					gobjMessageAdapter.ShowMessage(constPMTVolt);
					Application.DoEvents();
				}
			} else {
				//--- Adjust pmt between 80-700
				if (gobjCommProtocol.funcAdj_Pmt_ForValue(80.0, 700.0, true) == false) {
					gobjMessageAdapter.ShowMessage(constPMTVolt);
					Application.DoEvents();
				}
			}

			//---STEP 16 : Show PMT Voltage Value

			mlblStatusPMT.Text = "PMT Voltage :- " + FormatNumber(gobjInst.PmtVoltage, 2) + " V ";

			//---STEP 17 : Reinitialize Instrument Parameters

			gobjClsAAS203.ReInitInstParameters();

			//---STEP 18 : Rotate Turrent AntiClockewise

			//---following for loop is modified by deepak on 06.1.07
			//For i = 1 To i <= rpos + STEPS_PER_NM
			for (i = 1; i <= rpos + StepsPerNM; i++) {
				gobjCommProtocol.funcRotate_Anticlock_Wv();
			}
			//---STEP 19 : Rotate Turret Clockewise

			//---following for loop is modified by deepak on 06.1.07
			//For i = 1 To i<=STEPS_PER_NM
			for (i = 1; i <= StepsPerNM; i++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
			}

			//---STEP 20 : Get Current Wavelength from Instrument and set it
			//---to Instrument Settings

			//--- Added by Sachin Dokhale on 31.08.07 to get corrected Wv.
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//---Get current wavelength
			gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur);

			//---STEP 21 : Set value of Label on form
			mlblLampPosition.Text = "Analytical Peak Search  Range ( " + gobjInst.WavelengthCur + " nm - " + gobjInst.WavelengthCur + sngWVRange / StepsPerNM + " nm )";

			//---STEP 22 : Set Wavelength range as XMIN & XMAX of Graph

			mObjGraph.XAxisMin = (gobjInst.WavelengthCur);
			mObjGraph.XAxisMax = (gobjInst.WavelengthCur) + (sngWVRange / StepsPerNM);

			//---STEP 23 : Set Label Of XAXIS and YAXIS according to Mode

			if (blnIsHCLEMode == true) {
				mObjGraph.YAxisLabel = "ENERGY";
			} else {
				mObjGraph.YAxisLabel = "EMISSION";
			}
			mObjGraph.XAxisLabel = "WAVELENGTH (nm)";

			mObjGraph.AldysPane.XAxis.PickScale(mObjGraph.XAxisMin, mObjGraph.XAxisMax);
			mObjGraph.AldysPane.XAxis.StepAuto = true;
			mObjGraph.AldysPane.XAxis.MinorStepAuto = true;

			mObjGraph.AldysPane.YAxis.PickScale(mObjGraph.YAxisMin, mObjGraph.YAxisMax);
			mObjGraph.AldysPane.YAxis.StepAuto = true;
			mObjGraph.AldysPane.YAxis.MinorStepAuto = true;

			//---STEP 25 : First time Read ADCFilter and get BaseValue

			in_pos = 1;
			max_int = 0;
			chbase = 0;
			gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chbase);

			//---STEP 26 : Iterate over Wavelength range to get energy value

			//---following block of code is commented by Deepak on 06.02.09

			//'i = 1
			//'Do While Not i = sngWVRange
			//'    If mobjThreadController.Running Then
			//'        '---rotate wavelength clockwise
			//'        gobjCommProtocol.funcRotate_Clock_Wv()
			//'        '---read ADC filter
			//'        gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chnew)
			//'        If (chnew > max_int) Then
			//'            max_int = chnew
			//'            in_pos = i
			//'            If (max_int - chbase > 100) Then blnIsOptimized = True
			//'        End If
			//'        dblWavelength = gobjInst.WavelengthCur + (i / StepsPerNM)
			//'        dblEnergy = gFuncGetEnergy(chnew)
			//'        strData = ""
			//'        strData = dblWavelength & "," & dblEnergy
			//'        '---send wv and energy data for plotting graph
			//'        mobjThreadController.Display(strData)
			//'    Else
			//'        '---Client requested a cancel
			//'        Application.DoEvents()
			//'        Exit Do
			//'    End If
			//'    i += 1
			//'    Application.DoEvents()
			//'Loop
			//---------------------

			//---following block of code is written by Deepak on 06.02.09
			for (i = 1; i <= sngWVRange; i++) {
				if (mobjThreadController.Running) {
					//---rotate wavelength clockwise
					gobjCommProtocol.funcRotate_Clock_Wv();
					//---read ADC filter
					gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chnew);
					if ((chnew > max_int)) {
						max_int = chnew;
						in_pos = i;
						if ((max_int - chbase > 100))
							blnIsOptimized = true;
					}
					dblWavelength = gobjInst.WavelengthCur + (i / StepsPerNM);
					dblEnergy = gFuncGetEnergy(chnew);
					strData = "";
					strData = dblWavelength + "," + dblEnergy;
					//---send wv and energy data for plotting graph
					mobjThreadController.Display(strData);
				} else {
					//---Client requested a cancel
					Application.DoEvents();
					break; // TODO: might not be correct. Was : Exit For
				}
				Application.DoEvents();
			}
			//---------------------

			//#If EMU Then
			//   Wait_For_Some_Msg(5);
			//#End If
			if ((blnIsHCLEMode)) {
				//---if HCLE mode then make air ON
				gobjCommProtocol.funcAir_ON();
			}

			//---Draw and Show Highest Peak Line
			if (mObjGraph.AldysPane.CurveList.Count > 0) {
				mObjGraph.StopOnlineGraph(mObjGraph.AldysPane.CurveList(0));
				mObjGraph.DrawHighestPeakLine(mObjGraph.AldysPane.CurveList(0));
				mObjGraph.ShowHighPeakLineLabel("Optimized Wavelength", false, 0);
			}

			mlblLampPosition.Text = "Positioning to " + (gobjInst.WavelengthCur + (in_pos / StepsPerNM)) + " nm Please Wait...";

			//---STEP 27 : Position the wavelength motor to Newly found position
			//---where enegy is maximum by rotating turret clockwise and anticlockwise

			//---following block of code is commented by Deepak on 06.02.09
			//'For i = sngWVRange + StepsPerNM To 0 Step -1
			//'    Call gobjCommProtocol.funcRotate_Anticlock_Wv()
			//'Next
			//--------------------------

			//---following block of code is written by Deepak on 06.02.09
			for (i = sngWVRange + StepsPerNM; i >= 1; i += -1) {
				gobjCommProtocol.funcRotate_Anticlock_Wv();
			}
			//--------------------------

			//---for loop is modified by deepak on 6.1.07
			for (i = 1; i <= in_pos + StepsPerNM; i++) {
				gobjCommProtocol.funcRotate_Clock_Wv();
			}
			gobjCommProtocol.mobjCommdll.subTime_Delay(50);
			//---STEP 28 : Get newly set Wavelength from Instrument and set it 
			//---to the instrument Settings

			gobjCommProtocol.funcGet_Current_Wv(gobjInst.WavelengthCur);

			//---STEP 29 : Reinitialiaze the Instrument Settings

			gobjClsAAS203.ReInitInstParameters();

			//---STEP 30 : Auto BLANK Aspiration for AUTOSAMPLER

			if ((blnIsHCLEMode & blnIsOptimized)) {
				if ((Auto_Blank())) {
					funcBgc();
				}
			}

			gobjCommProtocol.mobjCommdll.subTime_Delay(1000);

			//#If !DEMO Then
			//  for(i=0;i<100;i++)
			//	pc_delay(10000);
			//#End If

			//---STEP 31 : Reinitialiaze the Instrument Settings

			gobjClsAAS203.ReInitInstParameters();

			//---STEP 32 : Return OptimizeFlag (if Analytical Peak is FOUND or NOT.)

			mlblStatusPMT.Text = "Finished.";
			mlblLampPosition.Text = "";
			mlblLampOptimisation.Text = strLampOptimisationText;

			return blnIsOptimized;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			gblnIsPeakSearchStarted = false;
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private bool Auto_Blank()
	{
		//=====================================================================
		// Procedure Name        : Auto_Blank
		// Parameters Passed     : None
		// Returns               : Boolean - Return the status of auto zero
		// Purpose               : adjusting BLANK ZERO 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : Thursday, May 19, 2005 4:00 pm
		// Revisions             : 1
		//=====================================================================

		//BOOL 	S4FUNC 	Auto_blank(HWND hwnd)
		//{
		//int   flag = TRUE;
		//char  line1[80]="";
		//int flag1 = FALSE;
		//int autosamp=0;
		//FILE *fptr = NULL;
		////---------------------autosampler flag test-----
		// fptr=fopen("asampler.pos","rt");
		// if(fptr!=NULL){
		//	  fscanf(fptr,"%d",&autosamp);
		//	  fclose(fptr);
		// }
		////---------------------
		//if(GetInstrument() == AA202 )
		//	flag1 = Check_Ignite_AA202(hwnd);
		//            Else
		//	flag1 = Check_Ignite();
		//  if (flag1)   {
		//	 sprintf(line1," Auto Blank Program  for %s",Inst->Lamp_par.lamp[Inst->Lamp_pos-1].elname);
		//	 SetText(hwnd, IDC_STATUS1,line1);
		//	 Cal_Mode(AA);
		//	 if(!autosamp){
		//		 Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK",0);
		//	 }
		//                    Else
		//			PosAutosamp();
		//	 pc_delay(1000);
		//	 if(!Adj_PMT_forvalue(hwnd, (double) 0.0 , (double)700)){
		//		 Gerror_message_new(" Error while adjusting BLANK ZERO ( 700V PMT)", "AUTOZERO");
		//		 flag = FALSE;
		//		 Set_PMT((double)300.0);
		//		 pc_delay(1000);
		//	  }
		//  }
		//                        Else
		//  flag = FALSE;
		//return flag;
		//}
		//=====================================================================

		//---BOOL 	S4FUNC 	Auto_blank(HWND hwnd)

		bool flag = false;
		string line1 = "";
		bool flag1 = false;
		bool blnIsAutosampler;
		const object constAUTOBLANK = 115;

		//FILE *fptr = NULL;
		////---------------------autosampler flag test-----
		//fptr=fopen("asampler.pos","rt");
		//if(fptr!=NULL){
		//fscanf(fptr,"%d",&autosamp);
		//fclose(fptr);
		//}
		////---------------------

		try {
			flag = true;
			// Start or stop the analysis depending upon setting
			//'by Pankaj for autosampler on 10Sep 07
			if ((gstructAutoSampler.blnAutoSamplerInitialised == true)) {
				blnIsAutosampler = gstructAutoSampler.blnCommunication;
			} else {
				blnIsAutosampler = false;
			}

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				flag1 = gobjClsAAS203.funcCheck_Ignite_AA201;
			} else {
				flag1 = gobjClsAAS203.funcCheck_Ignite();
			}

			if ((flag1)) {
				//line1 = " Auto Blank Program  for " & gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).ElementName
				//Call gobjMessageAdapter.ShowStatusMessageBox(line1, "AUTO BLANK", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 1000, True)
				//Application.DoEvents()

				//lblSTATUS1.Text = line1
				//---Set calibration mode as AA.
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				//If Not (autosamp) Then
				if (!blnIsAutosampler) {
					//Blink_MessageBox(hwnd, "Aspirate Blank and Press OK", " AUTO BLANK", 0)
					gobjMessageAdapter.ShowMessage(constAUTOBLANK);
					Application.DoEvents();
				} else {
					// set Position to Autosampler
					//Call PositionAutosampler()
				}

				//Added by Pankaj on 14 Feb 08
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.DemoMode_203D) {
					gobjCommProtocol.funcSet_PMTReferenceBeam(gobjInst.PmtVoltage);
				}
				//--

				gobjCommProtocol.mobjCommdll.subTime_Delay(1000);

				if (gobjClsAAS203.funcAutoZeroAbsMode() == false) {
					gobjMessageAdapter.ShowMessage(constBlankZero);
					flag = false;
					//---set pmt as 300.0
					gobjCommProtocol.funcSet_PMT(300.0);
				}


				//---Adjust pmt between 0.0 and 700
				//If Not (gobjCommProtocol.funcAdj_Pmt_ForValue(0.0, 700.0, False)) Then
				//End If

				gobjCommProtocol.mobjCommdll.subTime_Delay(1000);
				gobjMessageAdapter.CloseStatusMessageBox();
				Application.DoEvents();
			} else {
				flag = false;
			}

			return flag;

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

	private bool PositionAutosampler()
	{
		//=====================================================================
		// Procedure Name        : PositionAutosampler
		// Parameters Passed     : None
		// Returns               : True if success
		// Purpose               : Position to Auto Sampler
		//                           
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 06.02.08
		// Revisions             : 
		//=====================================================================



		//       BOOL(PosAutosamp(void))
		//{
		//int INTAKE_TIME=20;
		//char str[20]="";

		// GetProfileStringFromIniFile("AutoSampler", "Sample Intake Time (sec)" ,
		//	"10", str, "asampler.ini");
		//  trim(ltrim(str)); INTAKE_TIME=atoi(str);

		//       If (!IsSamplerConnected()) Then
		// return FALSE;
		//           If (ASampler_GoToYhome(0)) Then
		//  {
		//	 if(ASampler_ProbeDown()){
		//	 ASampler_PumpON();
		//	 WaitForSec(INTAKE_TIME);
		//	 ASampler_PumpOFF();
		//	 }
		//               Else
		//	 Gerror_message_new("Error in placing probe down","AUTOSAMPLER ERROR");
		//  }
		// else
		//  Gerror_message_new("Error in positioning Autosampler","AUTOSAMPLER ERROR");
		//return TRUE;
		//}


		//Dim WASH_TIME As Integer = 20
		string strTemp = "";

		try {
			// Set wash time from ini setting
			//strTemp = gFuncGetFromINI(CONST_Section_AutoSampler, CONST_Key_WashTime, "10", CONST_AutoSampler_INI_FileName)
			//WASH_TIME = Val(Trim(strTemp))


			//If Not (IsSamplerConnected()) Then
			//    Return False
			//End If

			if (!gstructAutoSampler.blnAutoSamplerInitialised) {
				return false;
			}

			// position to autosampler
			// Set Home position
			if ((gobjCommProtocol.funcAutoSamplerHome())) {
				// Set probe down for Wash
				if (gobjCommProtocol.funcAutoSamplerProbeDown()) {
					// Set pump On  for wash
					gobjCommProtocol.funcAutoSamplerPumpON();
					//ASampler_PumpON()
					//WaitForSec(WASH_TIME)
					// Delay for wash time
					//Call gobjCommProtocol.mobjCommdll.subTime_Delay(gstructAutoSampler.intWashTime * 1000)
					gobjCommProtocol.mobjCommdllAutoSampler.subTime_Delay(gstructAutoSampler.intWashTime * 1000);
					//added by pankaj on 25 Mar 08
					// Set pump off
					gobjCommProtocol.funcAutoSamplerPumpOFF();
				//ASampler_PumpOFF()
				} else {
					gobjMessageAdapter.ShowMessage("Error in placing probe down", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
					// by Pankaj on 29 Nov 07
					Application.DoEvents();
				}
			} else {
				gobjMessageAdapter.ShowMessage("Error in positioning Autosampler", "AutoSampler", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				//by pankaj on 29 Nov 07
				Application.DoEvents();
			}
			gobjMessageAdapter.CloseStatusMessageBox();
			Application.DoEvents();
			return true;
		//Application.DoEvents()
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

	private bool funcBgc()
	{
		//=====================================================================
		// Procedure Name        : funcBgc
		// Parameters Passed     : None
		// Returns               : Boolean - Return the status of function
		// Purpose               : Auto zero for BGC Mode 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin  Dokhale 
		// Created               : 06.02.08
		// Revisions             : 
		//=====================================================================
		//BOOL	S4FUNC 	Bgc(HWND hpar)
		//{
		//BOOL flag=TRUE;
		// Inst->D2cur = 100;
		// if (Inst->Lamp_par.lamp[Inst->Lamp_pos-1].mode == AABGC){
		//	 flag = Bgc_Zero(hpar, FALSE);
		//	 Cal_Mode(AABGC);
		//	}
		// return flag;
		//}
		try {
			bool flag = true;
			gobjInst.D2Current = 100;
			if (gobjInst.Lamp.LampParametersCollection(gobjInst.Lamp_Position - 1).Mode == EnumOperationMode.MODE_AABGC) {
				//--- Auto zero for BGC.
				flag = gobjClsAAS203.funcBgc_Zero(false);
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AABGC);
				//--- set the calibration mode.
			}
			return flag;
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
