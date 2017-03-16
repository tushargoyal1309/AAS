using BgThread;
using AAS203.Common;

public class clsBgD2Optimisation : BgThread.IBgWorker
{

	#Region " Private member Variables "

	private IBgThread mobjThreadController;
	private double mdblLampCurrent;
	private int mintLampPosition;
	private System.Object mlblObjWV_ABS;
	private System.Object mlblObjStatus;
	private double mdblMinWavelength;
	private double mdblMaxWavelength;
	private double mdblYMaxValue;
	private double mdblYMinValue;
	private bool mIsPeak486Performed = false;
	private bool mIsPeak656Performed = false;
	private bool mblnUVFlag = false;

	private bool mblnThTerminate = false;
	#End Region

	#Region " Public Property "

	public bool ThTerminate {
		//'---this is hold terminate flag.
		get { return mblnThTerminate; }
		set { mblnThTerminate = Value; }
	}

	public bool IsPeak486Performed {
		get { return mIsPeak486Performed; }
	}

	public bool IsPeak656Performed {
		get { return mIsPeak656Performed; }
	}

	#End Region

	#Region " Constructors "

	public clsBgD2Optimisation()
	{
		base.New();

	}

	public clsBgD2Optimisation(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn)
	{
		base.New();
		mlblObjStatus = lblObjStatusIn;
		mlblObjWV_ABS = lblObjWV_ABSIn;
	}

	#End Region

	#Region " Public Events, Constants .. "

	public event  SpectrumStatus;

	#End Region

	#Region " Public Functions "

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		//=====================================================================
		// Procedure Name        : Initialize
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : To Initialize the worker thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 26-Dec-2006
		// Revisions             : 1
		//=====================================================================
		mobjThreadController = Controller;
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
		// Author                : Sachin Dokhale
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		bool blnCancel = false;
		CWaitCursor objwait = new CWaitCursor();
		try {
			////----- Added by Sachin Dokhale on 25.03.07
			////----- To know the Status of Thread on Status Bar of MDI Main
			string strPreviousStatusMessage;
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBar1.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *D2 Opti";
				Application.DoEvents();
			}
			////-----
			while ((blnCancel == false)) {
				if (mobjThreadController.Running) {
					//funcThreadSpectrum(mdblLampCurrent, mintLampPosition)

					funcThreadD2Peak(mlblObjStatus, mlblObjWV_ABS, mblnUVFlag);
					gobjCommProtocol.mobjCommdll.subTime_Delay(100);
					blnCancel = true;

				//End If
				} else {
					//Client requested a cancel

					blnCancel = true;
					mobjThreadController.Completed(true);
					////----- Added by Sachin Dokhale on 25.03.07
					////----- To remove the Status of Thread on Status Bar of MDI Main
					if (gblnShowThreadOnfrmMDIStatusBar) {
						gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
						Application.DoEvents();
					}
					////-----
					return;
				}

				//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
			}
			blnCancel = true;
			if (mobjThreadController.Running == true) {
				mobjThreadController.Completed(true);
			} else {
				mobjThreadController.Completed(false);
			}
			////----- Added by Sachin Dokhale on 25.03.07
			////----- To remove the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
				Application.DoEvents();
			}
		////-----
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

	private bool funcThreadD2Peak(ref System.Object lblObjStatusIn, ref System.Object lblObjWV_ABSIn, bool blnUVFlag)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadD2Peak
		//Description            :   search D2 Peak
		//Parameters             :   blnUVFlag check UV bool flag
		//Parameters Affected    :   lblObjStatusIn ,lblObjWV_ABSIn as label
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//------------------------------------------------

		//------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		double dblYNew;
		double blYasisReading;
		bool blnStartSpec;
		int intIniMode;
		int MAXSIZE;
		int intsamp_adcCounter;
		////----- Added new 
		bool blnFlag = false;
		//Dim blnUVFlag As Boolean = False

		try {
			Application.DoEvents();

			CWaitCursor objWait1 = new CWaitCursor();
			////----- 1  Set Wv '& Abs/En
			gobjInst.D2Pmt = 0;
			lblObjStatusIn.Text = "Wavelength Positioning : ";
			lblObjStatusIn.Refresh();
			// set UV Spectrum contions for 480nm.
			gobjClsAAS203.funcSetRest_uvs_Condn(480.0, false, lblObjWV_ABSIn, blnUVFlag);
			// Check the property for interuption from user to terminate the process
			if (ThTerminate == true) {
				funcThreadD2Peak = true;
				return;
			}
			Application.DoEvents();
			//Start to detect D2 peak for 480
			blnFlag = funcGetD2Peaks(480.0, 490.0, blnUVFlag, lblObjWV_ABSIn);
			//Application.DoEvents()
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			//Send the flag for changeing peak from 480nm  to 565nm.
			mobjThreadController.Display((string)0 + "|" + (string)0 + "|" + ((int)1).ToString + "|" + ((int)1).ToString);
			//Application.DoEvents()
			// Terminate the process if user interupts 
			if (ThTerminate == true) {
				funcThreadD2Peak = true;
				return;
			}
			if ((blnFlag == true)) {
				mIsPeak486Performed = true;
				//Application.DoEvents()
				//Start to detect D2 peak for 656nm when 480nm peak is detect.
				blnFlag = funcGetD2Peaks(650.0, 660.0, blnUVFlag, lblObjWV_ABSIn);
			}


			if ((blnFlag == false)) {
			//gobjMessageAdapter.ShowMessage(constD2Peak)
			} else {
				mIsPeak656Performed = true;
				//gobjMessageAdapter.ShowMessage("D2 peaks found", "D2 Peaks", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
			}

			//Application.DoEvents()
			//gobjCommProtocol.mobjCommdll.subTime_Delay(50)

			// set UV Spectrum contions for 200nm.
			gobjClsAAS203.funcSetRest_uvs_Condn(200.0, false, lblObjWV_ABSIn, blnUVFlag);
			Application.DoEvents();
			//========================================================================

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
			ThTerminate = false;
			Application.DoEvents();
		}
	}

	private bool funcGetD2Peaks(double dblXMin, double dblXMax, bool blnUVFlag, ref object lblWv, ref object lblobjStatus = null)
	{

		//------------------------------------------------------------------
		//Procedure Name         :   funcGetD2Peaks
		//Description            :   Detect D2 peak for desire wavelength  
		//Parameters             :   Min X and max X value is Wv., lblWv is text object to display status,
		//Return                 :   Return true value if success or false when Terminate
		//Time/Date              :   5/10/06
		//Dependencies           :   
		//Author                 :   Sachin Dokhale.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------

		//BOOL	GetD2Peaks(HWND hwnd, double xmin, double xmax, int type)
		//{
		//HDC		hdc;
		//#If !D2PRINT Then
		//int		*arr;
		//#End If
		//int		i, n,tavg=0;
		//int		ymin, ymax, ioff;
		//BOOL		flag=FALSE;
		//char		str[40]="";
		//float stepspernm=50.0;
		//if (GetInstrument()==AA202)
		// stepspernm = STEPS_PER_NM_AA202;
		//        Else
		// stepspernm = STEPS_PER_NM;

		// hdc = GetDC(hwnd);
		// InitGraphParam1(hwnd, type);
		// SetText(hwnd, IDC_STATUS," D2 Peak search ...");
		// strcpy(PYaxis,"Energy");
		// strcpy(PXaxis,"Wv");
		// Cal_Mode(D2E);
		// Wavelength_Position(hdc, xmin,5, 150);

		// PeakGraph.Xmin=xmin;
		// PeakGraph.Xmax=xmax;
		// if (GetInstrument()==AA202)
		////n = (xmax-xmin)*(stepspernm/SLOWSTEP_AA202)+1;
		//  n = (xmax-xmin)*(stepspernm)+1;
		//            Else
		//  n = (xmax-xmin)*(stepspernm/SLOWSTEP)+1;
		// Calculate_Peak_Param(&PeakGraph, n);
		// Display_Peak_Graph_Param1(hdc, &PeakGraph, type);
		//#If D2PRINT Then
		// if(type)
		//  arr1 = (int *) malloc(sizeof(int)*n);
		// else
		// arr = (int *) malloc(sizeof(int)*n);
		//#Else
		// arr = (int *) malloc(sizeof(int)*n);
		//#End If
		// if(GetInstrument() == AA202 ){
		//	 tavg = Inst->Avg;
		//	 Inst->Avg = 100;
		// }
		// if (arr !=NULL) {
		//  arr[0] = ReadADCFilter();
		//  ymin = 4096;
		//  ymax=0;
		//  for (i=1; i<n; i++)  {
		//	  if (GetInstrument()==AA202){
		////		 Rotate_Wv_Clock_Steps(SLOWSTEP_AA202); // for (j=1; j<=5; j++)    rotate_clock();
		//		Rotate_Clock_Wv();
		//	  }
		//                            Else
		//		 Rotate_Wv_Clock_Steps(SLOWSTEP); // for (j=1; j<=5; j++)    rotate_clock();

		//	 arr[i] = ReadADCFilter();
		//	 if(GetInstrument()==AA202)
		//		 sprintf(str,"%4.3f ,%4.2f", PeakGraph.Xmin+(double)i*(double)SLOWSTEP_AA202/(double)stepspernm,GetEnergy(arr[i]));
		//                                Else
		//	 sprintf(str,"%4.3f ,%4.2f", PeakGraph.Xmin+(double)i*(double)SLOWSTEP/(double)stepspernm,GetEnergy(arr[i]));
		//	 SetText(hwnd, IDC_STATUS1,str);
		//	}
		//	for (i=0; i<n; i++){
		//	  if (arr[i]>ymax) {
		//		  ymax = arr[i];
		//		  ioff=i;
		//		  flag=TRUE;
		//		  }
		//	  if (arr[i]<ymin) ymin = arr[i];
		//		 }
		//	PeakGraph.Ymax=  GetEnergy(ymax+8.192);
		//	PeakGraph.Ymin=  GetEnergy(ymin-4.096);
		//	for (i=0; i<n; i++)  {
		//	 if (i==0){
		//		if (GetInstrument()==AA202)
		//			 GPlotInit(hdc, PeakGraph.Xmin+( (double)((i+1)*SLOWSTEP_AA202)/(double) stepspernm),
		//			 GetEnergy(arr[i]));
		//                                                        Else
		//			 GPlotInit(hdc, PeakGraph.Xmin+( (double)((i+1)*SLOWSTEP)/(double) stepspernm),
		//			 GetEnergy(arr[i]));

		//	 }
		//	 else{
		//		if (GetInstrument()==AA202)
		//			GPlot(hdc, PeakGraph.Xmin+ (((double)(i+1)*SLOWSTEP_AA202)/(double) stepspernm),
		//				GetEnergy(arr[i]));
		//                                                            Else
		//			GPlot(hdc, PeakGraph.Xmin+ (((double)(i+1)*SLOWSTEP)/(double) stepspernm),
		//				GetEnergy(arr[i]));
		//	 }
		//	 }
		//	if (flag){
		//	  if (GetInstrument()==AA202)
		//		 GShowPeak(hdc,PeakGraph.Xmin+ ( ((double)(ioff+1)*SLOWSTEP_AA202)/(double) stepspernm),
		//					GetEnergy(ymax),NULL);
		//                                                                    Else
		//		 GShowPeak(hdc,PeakGraph.Xmin+ ( ((double)(ioff+1)*SLOWSTEP)/(double) stepspernm),
		//					GetEnergy(ymax),NULL);

		//	}
		//#If !D2PRINT Then
		//	free(arr); arr=NULL; // removed by sss for printing the d2 peaks
		//#End If
		//  }
		// ReleaseDC(hwnd, hdc);
		// if(GetInstrument() == AA202 )
		//	 Inst->Avg= tavg;
		//#If D2PRINT Then
		// OnD2Print();
		// if(arr){
		// free(arr); arr=NULL;
		// }
		// if(arr1){
		// free(arr1); arr1=NULL;
		// }
		//#End If
		// return flag;
		//}
		////---------
		long lngN_Wv;
		int intTmpAvg = 0.0;
		double dblReadWv;
		double dblReadYValue;
		int intTimeDelay = 20;
		//         if (GetInstrument()==AA202)
		////n = (xmax-xmin)*(stepspernm/SLOWSTEP_AA202)+1;
		//  n = (xmax-xmin)*(stepspernm)+1;
		//        Else
		lblWv.Text = "Wavelength Positioning ";
		lblWv.Refresh();
		//Set the D2E Calibration Mode
		gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.D2E);
		// Set Wv. position with X min (Wv.) value
		gobjCommProtocol.Wavelength_Position(dblXMin, lblWv);

		lblWv.Text = "";
		lblWv.Refresh();
		// Calculate total diff. of steps bt'n from X(Wv.) min and X(Wv.) max 
		if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
			lngN_Wv = (dblXMax - dblXMin) * (CONST_STEPS_PER_NM_AA201 / CONST_SLOWStep_AA201) + 1;
		} else {
			lngN_Wv = (dblXMax - dblXMin) * (CONST_STEPS_PER_NM / CONST_SLOWStep) + 1;
		}


		//if(GetInstrument() == AA202 ){
		// tavg = Inst->Avg;
		// Inst->Avg = 100;
		//}
		//Set instrument  Avg count is set to 100 for 201
		if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
			intTmpAvg = gobjInst.Average;
			gobjInst.Average = 100;
		}

		//if (arr !=NULL) {
		long lngWvIndex;
		if ((lngN_Wv > 0)) {
			//arr[0] = ReadADCFilter();
			//mobjThreadController.Display(dblXaxisTime1.ToString & "|" & dblAbs.ToString)
			//ymin = 4096;
			//ymax=0;


			Application.DoEvents();
			////----- Move Wv position tilllngN_Wv
			for (lngWvIndex = 0; lngWvIndex <= lngN_Wv - 1; lngWvIndex++) {
				//                if (GetInstrument()==AA202){
				////		 Rotate_Wv_Clock_Steps(SLOWSTEP_AA202); // for (j=1; j<=5; j++)    rotate_clock();
				//		Rotate_Clock_Wv();
				//	  }
				//                Else
				//'		 Rotate_Wv_Clock_Steps(SLOWSTEP); // for (j=1; j<=5; j++)    rotate_clock();
				////----- Commented by Sachin Dokhale on 03.02.07
				//Call gobjCommProtocol.funcRotate_Wv_Clock_Steps(CONST_SLOWStep)
				////-----
				//sprintf(str,"%4.3f ,%4.2f", PeakGraph.Xmin+(double)i*(double)SLOWSTEP/(double)stepspernm,GetEnergy(arr[i]));
				//dblReadWv = dblXMin + (lngWvIndex * CONST_SLOWStep / CONST_STEPS_PER_NM)
				// Check the property for interuption from user to terminate the process
				if (ThTerminate == true) {
					break; // TODO: might not be correct. Was : Exit For
				}
				// Calulate the Wv. steps for 201
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					// Move the Wv. postion to the lock wise with slow steps for 201
					gobjCommProtocol.funcRotate_Wv_Clock_Steps(CONST_SLOWStep_AA201);
					// Calculate the Wv for next steps
					dblReadWv = dblXMin + (lngWvIndex * CONST_SLOWStep_AA201 / CONST_STEPS_PER_NM_AA201);
				} else {
					// Calulate the Wv. steps for not 201
					// Move the Wv. postion to the lock wise with slow steps 
					gobjCommProtocol.funcRotate_Wv_Clock_Steps(CONST_SLOWStep);
					// Calculate the Wv for next steps
					dblReadWv = dblXMin + (lngWvIndex * CONST_SLOWStep / CONST_STEPS_PER_NM);
				}

				//gobjCommProtocol.mobjCommdll.subTime_Delay(1)
				//Call gobjCommProtocol.funcReadADCFilter(10, dblReadYValue)
				gobjCommProtocol.mobjCommdll.subTime_Delay(intTimeDelay);
				// Read ADC Filter value from Inst. and return to main program.
				gobjCommProtocol.funcReadADCFilter(gobjInst.Average, dblReadYValue);
				mobjThreadController.Display(dblReadWv.ToString + "|" + dblReadYValue.ToString + "|" + ((int)mIsPeak486Performed).ToString + "|" + ((int)mIsPeak656Performed).ToString);
				//Application.DoEvents()
			}

		}
		//Set Inst. Avg. count with previousely stored value 
		if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
			gobjInst.Average = intTmpAvg;
		}

		return true;
	}

	#End Region

}
