using BgThread;
using AAS203.Common;
using AAS203.AASGraph;
using AAS203Library.Instrument;
//'this are like a header file.
//'class for burner optimization
public class clsBgBurnerOptimization : BgThread.IBgWorker
{
	//'interface for thread class.

	#Region " Constructors "

	public clsBgBurnerOptimization()
	{
		base.New();

	}

	public clsBgBurnerOptimization(ref object lblSt1, ref object lblSt2, ref object lblSt3, double dblLampCurrent, int intLampPos, ref object objGraph = null)
	{
		//=====================================================================
		// Procedure Name        : New(constructor)
		// Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
		// Returns               : 
		// Purpose               : to initialise the burnerthread object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 29.12.06
		// Revisions             : praveen
		//=====================================================================
		base.New();
		//'note:
		//'this is used to initialise the object with current value
		//' like cblLampCurrent gives a curretn LampCurrent 
		try {
			mdblLampCurrent = dblLampCurrent;
			mintLampPosition = intLampPos;
			mlblStatus1 = lblSt1;
			mlblStatus2 = lblSt2;
			mlblStatus3 = lblSt3;
			mObjGraph = objGraph;
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
	//'this are the private variables
	private IBgThread mobjThreadController;
	//'object for a thread
	private double mdblLampCurrent;
	private int mintLampPosition;
	private object mlblStatus1;
	private object mlblStatus2;
	private object mlblStatus3;
	//'this are the object for lable where we have to show the status
	private object mObjGraph;
	//'
	private bool mblnThTerminate = false;
	//'flag for controling a thread.

	private System.Random objRandom = new System.Random();
	#End Region

	#Region " Public Property "

	public bool ThTerminate {
		//'this property will hold a flag for terminate a burner thread
		get { ThTerminate = mblnThTerminate; }
		set { mblnThTerminate = Value; }
	}

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
		// Author                : Sachin Dokhale
		// Created               : 29.11.06
		// Revisions             : praveen
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
		// Parameters Passed     : none
		// Returns               : IBgWorker.Start as Implements object
		// Purpose               : To Start the worker thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 29.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is main function which is called for starting a burner optimization thread.

		CWaitCursor objwait = new CWaitCursor();
		string strPreviousStatusMessage;
		try {
			while ((true)) {
				//'start a while loop for thread.
				if (mobjThreadController.Running) {
					//'check whatever a thread is started or not.

					//funcThreadTurret_Optimise(mdblLampCurrent, mintLampPosition, mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph, mobjThreadController)
					if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.BurnerHeight) {
						//'check for a gintOptimisation  flag for burner optimisation

						////----- Added by Sachin Dokhale on 25.03.07
						////----- To know the Status of Thread on Status Bar of MDI Main

						if (gblnShowThreadOnfrmMDIStatusBar) {
							//'show the current status message.
							strPreviousStatusMessage = gobjMain.StatusBarPanelInfo.Text;
							gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *Burner Height";
							Application.DoEvents();
							//'allow application to perfrom its panding work.
						}
						////-----

						funcOptimise_BurnerHeight_Auto(mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph);
					//'call a function for optimise the burner height as per given parameter.
					} else if (gintOptimisation == modGlobalDeclarations.EnumBH_FP_Opimisation.FuelPresure) {
						////----- Added by Sachin Dokhale on 25.03.07
						////----- To know the Status of Thread on Status Bar of MDI Main
						if (gblnShowThreadOnfrmMDIStatusBar) {
							//'show a current status on status bar
							strPreviousStatusMessage = gobjMain.StatusBar1.Text;
							gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *Fuel Presure";
							Application.DoEvents();
						}
						////-----
						funcOptimise_Fuel_Auto(mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph);
						//'optimise the fuel 
					}

					//If mobjThreadController.Running Then
					mobjThreadController.Completed(true);
					//'set flag for completion of thread.
					//End If

					Application.DoEvents();
					//'allow application to perfrom its panding work.
					break; // TODO: might not be correct. Was : Exit Do
				} else {
					//If mobjThreadController.Running Then
					mobjThreadController.Completed(true);
					//End If
					////----- Added by Sachin Dokhale on 25.03.07
					////----- To remove the Status of Thread on Status Bar of MDI Main
					if (gblnShowThreadOnfrmMDIStatusBar) {
						gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
					}
					////-----
					Application.DoEvents();
					//---allow application to perfrom its panding work.
					return;
				}
				gobjCommProtocol.mobjCommdll.subTime_Delay(10);
				//'this is for communication delay during a thread.
			}
			////----- Added by Sachin Dokhale on 25.03.07
			////----- To remove the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
			}
			Application.DoEvents();
		//'allow application to perfrom its panding work.
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

	private bool funcOptimise_BurnerHeight_Auto(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null, ref object AASGraphs = null)
	{
		//AASGraph  
		//=====================================================================
		// Procedure Name        :   funcOptimise_Height_Auto
		// Description           :   Optimese , the auto Height of burner.
		// Purpose               :   
		//                           
		// Parameters Passed     :   lblStatus1,lblStatus2,lblStatus3,AASGraphs
		// Returns               :   bool
		// Parameters Affected   :   
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   25.12.06
		// Revisions             :   praveen
		//=====================================================================

		//'note:
		//'this is used to optimise the burner height
		//'this called during the burner optimise thread.

		//double	txmin=0.0, txmax=0.0;
		//double   abs=0.0, max_abs= 0;
		//int		xval=0, max_bh=0, xvalmax, xvalmin, adval;
		//int 		i;
		//HWND		hwnd;
		//HDC		hdc;
		//char     line1[80]="";
		//unsigned	tout;
		//BOOL		pflag=FALSE;
		//int	lMode=0;
		//int		txold, tyold;

		//  if (GetInstrument()==AA202)
		//	return TRUE;

		//            If (!ReadAndSetBHScanConditions(hpar)) Then
		//	return FALSE;
		//                If (!CheckBhPos()) Then
		//	return FALSE;
		// GetXoldYold(&txold, &tyold);
		// txmin= PeakGraph.Xmin;
		// txmax	= PeakGraph.Xmax;
		// Blink_MessageBox(hpar,"Aspirate Max. Standard and Click OK","Height optimisation", 0);
		//// MessageBox(hpar, "Aspirate Max. Standard and Click OK","Height optimisation", MB_OK);
		// hwnd= CreateWindowPeak(hpar, " BURNER OPTIMISATION ","SKCK2",0 );

		// if (hwnd ){
		//	PeakGraph.Xmin=  txmin;
		//	PeakGraph.Xmax = txmax;
		//	PeakGraph.Ymin= 0.0;//GetEnergy(2047);
		//	PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
		//	SetInstrumentCondns(hwnd, TRUE);
		//	xvalmax = ConvertToBhPos(PeakGraph.Xmax) ;
		//	xvalmin = ConvertToBhPos(PeakGraph.Xmin) ;
		//	i= (int )  ((xvalmax-xvalmin)/BHSCANSTEP);
		//	i = abs(i);
		//	strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Burner Height");
		//	Show_Peak_Param(hwnd, i);
		//	PeakGraph.Xmin=txmin ;
		//	PeakGraph.Xmax = txmax;

		//	SetFocus(hwnd);
		//	hdc= GetDC(hwnd);
		//	SetBkColor(hdc, RGB(192, 192, 192));
		//	SetText(hwnd, IDC_STATUS,"INITIALISING Please Wait  ....... ");
		//	strcpy(line1,""); sprintf(line1, " Setting Height from %3.1f mm to %3.1f mm ", ConvertToBurnerHeight(Inst->Bhstep), PeakGraph.Xmin);
		//	SetText(hwnd, IDC_STATUS1,line1);
		//	SetBhPos(PeakGraph.Xmin);
		//	strcpy(line1,"");
		//	sprintf(line1, " Burner Height Optimisation");
		//	SetText(hwnd, IDC_STATUS1,line1);
		//	SetText(hwnd, IDC_STATUS,"");
		//	lMode=Inst->Mode;
		//	Cal_Mode(AA);
		//	SetScanning(TRUE);
		//	Transmit(BHSCAN, (BYTE)(xvalmax), (BYTE) (xvalmax>>8), (BYTE) BHSCANSTEP);
		//	xval= xvalmin;
		//	tout = GetTimeOut();
		//	SetTimeOut(LONG_DEALY);
		//	i=1;
		//	while(1){
		//                            If (Recev(False)) Then
		//		adval= GetParam2()*256 + GetParam1();
		//                            Else
		//		break;
		//                                If (adval >= 6000) Then
		//		break;
		//#If QDEMO Then
		//	  adval=2100+random(20);
		//#End If
		//	  abs = GetADConvertedToCurMode(adval);
		//	  if (abs > max_abs)    {
		//		 max_abs=abs;
		//		 max_bh=xval;
		//		 pflag=TRUE;
		//		}
		//	  sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",ConvertToBurnerHeight(xval), abs, xval, xvalmin, xvalmax);
		//	  SetText(hwnd, IDC_STATUS,line1);
		//	  if (i==1)
		//		 GPlotInit(hdc, ConvertToBurnerHeight(xval), abs);
		//                                        Else
		//		 GPlot(hdc,ConvertToBurnerHeight(xval), abs);
		//	  xval+=BHSCANSTEP;
		//	  i++;
		//	 if (!Transmit(PC_END, (BYTE)0, (BYTE) 0, (BYTE) 0))
		//		break;
		//	 }
		//	SetTimeOut(tout);
		//	if (pflag){
		//	  sprintf(line1,"Optimised at (%4.2f, %4.3f)",ConvertToBurnerHeight(max_bh),  max_abs);
		//	  SetText(hwnd, IDC_STATUS1,line1);
		//	  GShowPeak(hdc,ConvertToBurnerHeight(max_bh),  max_abs, NULL);
		//	  strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
		//	  SetText(hwnd, IDC_STATUS,line1);
		//#If EMU Then
		// Wait_For_Some_Msg(5);
		//#End If
		//	  SetBhPos(ConvertToBurnerHeight(max_bh));
		//	 }
		//	Cal_Mode(lMode);
		//	ReleaseDC(hwnd, hdc);
		//	DestroyWindowPeak(hwnd,hpar);
		//  }
		// SetScanning(FALSE);
		// SetXoldYold(txold, tyold);
		// pc_delay(1500);
		// return TRUE;
		//}


		double txmin = 0.0;
		double txmax = 0.0;
		double abs = 0.0;
		double max_abs = 0.0;
		double xfuel = 0.0;
		int xval = 0;
		int max_fuel = 0;
		int xvalmax;
		int xvalmin;
		int adval;
		int max_bh = 0;
		bool pflag = false;
		int i;
		bool blnStartSpec;
		string line1;
		//unsigned	tout;
		//Dim tout As Integer
		int intlMode;
		int inttxold;
		int inttyold;
		bool blnBHOptim = true;
		int lMode;

		try {
			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				//'return true for 201
				return true;
			}

			//           If (!ReadAndSetFuelScanConditions(hpar)) Then
			//return FALSE;
			lblStatus1.Text = " INITIALISING Please Wait  ....... ";
			lblStatus1.Refresh();
			//" Setting Height from " & gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep) & " mm to " & txmin & " mm", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
			lblStatus2.Text = "Setting Height from " + Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep), "#0.00") + " mm to " + Format(txmin, "#0.00") + " mm";
			lblStatus2.Refresh();
			//'set a status label.

			//---to get burner height position.
			if ((!gobjClsAAS203.funcCheckBHPos())) {
				//'for checking burner position
				return false;
			}

			//GetXoldYold(&txold, &tyold);
			gobjClsAAS203.subGetXoldYold(inttxold, inttyold);
			//'for getting X, Y value for graph.

			//Dim dblGraphXmin, dblGraphXMax As Double
			//txmin = dblGraphXmin    'PeakGraph.Xmin
			//txmax = dblGraphXmax    'PeakGraph.Xmax

			txmin = AASGraphs.XAxisMin;
			txmax = AASGraphs.XAxisMax;


			//blnBHOptim = gobjMessageAdapter.ShowMessage("Aspirate Max. Standard and Click OK", "Height optimisation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)

			//PeakGraph.Xmax=txmin ;
			//PeakGraph.Xmin= txmax;
			//PeakGraph.Ymin= 0.0;//GetEnergy(2047);
			//PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
			//mobjParameters.XaxisMax = txmax
			//mobjParameters.XaxisMin = txmin
			//mobjParameters.YaxisMax = 0.0
			//mobjParameters.YaxisMin = 1
			//AASGraphs.XAxisMax = txmax
			//AASGraphs.XAxisMin = txmin
			// AASGraphs.YAxisMax = 1.0
			//AASGraphs.YAxisMin = 0.0

			AASGraphs.AldysPane.XAxis.PickScale(AASGraphs.XAxisMin, AASGraphs.XAxisMax);
			//'for setting a XAxis scale
			AASGraphs.AldysPane.YAxis.PickScale(AASGraphs.YAxisMin, AASGraphs.YAxisMax);
			//'for setting a YAxis scale
			AASGraphs.AldysPane.AxisChange();
			//'call the Axis change function for setting X,Y scale
			AASGraphs.Invalidate();
			AASGraphs.Refresh();
			Application.DoEvents();
			//'now allow application to perfrom its panding work.

			////-----------------------------------------

			////------------------------------------------
			//SetInstrumentCondns(hwnd, TRUE);
			//xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
			//abs = ConvertToFuel(xvalmax) ;
			//xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
			//abs = ConvertToFuel(xvalmin) ;
			if (blnBHOptim == true) {
				//'check for burner optmization flag.
				//---To display instrument conditions 
				gobjClsAAS203.funcSetInstrumentCondns(true);
				//xvalmax = funcConvertToBHPos(mobjParameters.XaxisMax)
				//xvalmin = funcConvertToBHPos(mobjParameters.XaxisMin)

				//---to convert x-axis max value to burner height steps
				xvalmax = gobjClsAAS203.funcConvertToBHPos(AASGraphs.XAxisMax);
				//---to convert x-axis min value to burner height steps
				xvalmin = gobjClsAAS203.funcConvertToBHPos(AASGraphs.XAxisMin);
				i = ((xvalmax - xvalmin) / CONST_BHSCANSTEP);
				i = Math.Abs(i);

				//gobjMessageAdapter.ShowStatusMessageBox("INITIALISING Please Wait  ....... " & vbNewLine & _
				//" Setting Height from " & gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep) & " mm to " & txmin & " mm", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)

				// Check the property for interuption from user to terminate the process
				if (ThTerminate == true) {
					//If gobjCommProtocol.funcBreakSpectrum() = False Then
					//Exit Do
					//End If
					goto ExitScan;
				}

				//---Set burner height position.
				gobjClsAAS203.funcSetBHPos(txmin);
				//gobjMessageAdapter.CloseStatusMessageBox()
				//gobjMessageAdapter.ShowStatusMessageBox("Burner Height Optimisation", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
				lblStatus1.Text = "Burner Height Optimisation";
				lblStatus1.Refresh();
				Application.DoEvents();
				//'allow application to perfrom its panding work.

				lMode = gobjInst.Mode;
				//---set calibration mode as aa
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				Application.DoEvents();
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				//'this is for communication delay
				//---to can burner height
				blnStartSpec = gobjCommProtocol.funcBHSCAN(xvalmax);
				xval = xvalmin;
				//tout = GetTimeOut();
				//SetTimeOut(LONG_DEALY);
				i = 1;
				if (blnStartSpec) {
					gblnInComm = false;
					while (true) {
						if (gblnInComm == false) {
							//---to receive burner height scan data.

							if (gobjCommProtocol.funcReceive_ScanData(0, adval) == true) {
							} else {
								break; // TODO: might not be correct. Was : Exit Do
							}
							//adval = GetParam2() * 256 + GetParam1()
							//Else
							if ((adval >= 6000)) {
								break; // TODO: might not be correct. Was : Exit Do
							}
							//If ThTerminate = True Then
							//    Exit Do
							//End If
							////----- For Demo Mode
							//#If QDEMO Then
							//	  adval=2100+random(20);
							//#End If
							//-- in case of demo mode  convert value to random value
							//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
							if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
								adval = 2100 + objRandom.Next(20);
							}
							////-----
							//abs = GetADConvertedToCurMode(adval)
							//---convert scan data to calibration mode value
							abs = gFuncGetADConvertedToCurMode(adval);
							//'this will convert an ADC value in to abs

							//if (abs > max_abs)    {
							// max_abs=abs;
							// max_bh=xval;
							// pflag=TRUE;
							//}
							if ((abs > max_abs)) {
								max_abs = abs;
								max_bh = xval;
								pflag = true;
							}
							//sprintf(lsine1,"(%4.2f, %4.3f) %d (%d-%d)",ConvertToBurnerHeight(xval), abs, xval, xvalmin, xvalmax);
							lblStatus2.Text = "Setting Height " + Format(gobjClsAAS203.funcConvertToBurnerHeight(xval), "#0.00") + " mm " + "Abs " + Format(abs, "#0.000").ToString + " " + "Steps " + Format(xval, "####0.00").ToString + " " + Format(xvalmin, "#####0.00").ToString + " to " + Format(xvalmax, "####0.00").ToString;
							//'display a status

							//lblStatus2.Text = "Setting Height from " & Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep).ToString, "#.00") & " mm to " & Format(txmin, "#.00") & " mm"
							lblStatus2.Refresh();
							//Start to plot the graph
							//if (i==1)
							//GPlotInit(hdc, ConvertToBurnerHeight(xval), abs);
							//Else
							//GPlot(hdc,ConvertToBurnerHeight(xval), abs);


							//---display scanned value on graph
							mobjThreadController.Display(gobjClsAAS203.funcConvertToBurnerHeight(xval).ToString + "|" + abs.ToString);

							xval += CONST_BHSCANSTEP;
							i += 1;
							if (!(gobjCommProtocol.funcPC_END)) {
								//'serial communication function for PC ens.
								break; // TODO: might not be correct. Was : Exit Do
							}
						}
						Application.DoEvents();
						//'allow apllication to perfrom ita panding work
					}
				}

			}
			ExitScan:

			//----called ExitScan routine
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			if (pflag == true) {
				lblStatus2.Text = "Optimised at " + Format(gobjClsAAS203.funcConvertToBurnerHeight(max_bh), "####0.00").ToString + "  " + Format(max_abs, "#0.000").ToString;
				lblStatus2.Refresh();
				lblStatus3.Text = "Positioning to optimised Position ...";
				lblStatus3.Refresh();
				//Show the peak
				//GShowPeak(hdc,ConvertToBurnerHeight(max_bh),  max_abs, NULL);

				//strcpy(line1,""); sprintf(line1," Positioning to Optimised Position ...");
				//SetText(hwnd, IDC_STATUS,line1);
				Application.DoEvents();
				//SetBhPos(ConvertToBurnerHeight(max_bh));
				//---set burner to optimized burner height position.
				gobjClsAAS203.funcSetBHPos(gobjClsAAS203.funcConvertToBurnerHeight(max_bh));
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				lblStatus3.Text = "Position is optimised";
				lblStatus3.Refresh();
			}

			//gobjMessageAdapter.CloseStatusMessageBox()
			gobjCommProtocol.funcCalibrationMode(lMode);
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
			gblnInComm = false;
			//---------------------------------------------------------
		}
	}

	private bool funcOptimise_Fuel_Auto(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null, ref object AASGraphs = null)
	{
		//AASGraph  
		//=====================================================================
		// Procedure Name        :   funcOptimise_Fuel_Auto
		// Description           :   Optimese  the auto fuel
		// Purpose               :   to Optimise fuel conditions
		// Parameters Passed     :   lblStatus1,lblStatus2,lblStatus3,AASGraphs
		// Returns               :   bool
		// Assumptions           :   
		// Dependencies          :   None.
		// Author                :   Sachin Dokhale 
		// Created               :   25.12.06
		// Revisions             :   praveen
		//=====================================================================

		double txmin = 0.0;
		double txmax = 0.0;
		double abs = 0.0;
		double max_abs = 0.0;
		double xfuel = 0.0;
		int xval = 0;
		int max_fuel = 0;
		int xvalmax;
		int xvalmin;
		int adval;
		bool pflag = false;
		int i;

		string line1;
		//unsigned	tout;
		int tout;
		int intlMode;
		int inttxold;
		int inttyold;
		bool blnBHOptim = true;
		int lMode;
		bool blnStartSpec;
		try {
			//if (GetInstrument()=AA202) then
			//return TRUE
			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				//'return true for 201
				return true;
			}
			//           If (!ReadAndSetFuelScanConditions(hpar)) Then
			//return FALSE;
			lblStatus1.Text = " INITIALISING Please Wait  ....... ";
			lblStatus1.Refresh();
			//'show the label status

			//" Setting Height from " & gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep) & " mm to " & txmin & " mm", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
			//lblStatus2.Text = "Setting Fuel from" & Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.NvStep), "#.00") & " mm to " & Format(txmax, "#.00") & " mm"
			//strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
			//lblStatus2.Refresh()


			//If (!Flame_Present(False)) Then
			//return FALSE;
			//               If (!CheckNvPos()) Then
			//return FALSE;

			//---to check flame is present or not
			if (!(gobjClsAAS203.funcFlame_Present(false))) {
				//'check for flame present
				lblStatus1.Text = "";
				lblStatus1.Refresh();
				return false;
			}
			//If Not (funcReadAndSetFuelScanConditions()) Then
			//    Return False
			//End If
			//---to get current nv position.
			if ((!gobjClsAAS203.funcCheckNvPos())) {
				//'check for NV position
				lblStatus1.Text = "";
				lblStatus1.Refresh();
				return false;
			}

			//GetXoldYold(&txold, &tyold);
			//Dim dblGraphXmin, dblGraphXMax As Double
			gobjClsAAS203.subGetXoldYold(inttxold, inttyold);
			//'for setting X,Y old value

			//Dim dblGraphXmin, dblGraphXMax As Double
			//txmin = dblGraphXmin    'PeakGraph.Xmin
			//txmax = dblGraphXmax    'PeakGraph.Xmax

			txmin = AASGraphs.XAxisMin;
			txmax = AASGraphs.XAxisMax;
			//'get a X axis min and max.

			//strcpy(line1,""); sprintf(line1, " Setting Fuel from %4.2f to %4.2f ", ConvertToFuel(Inst->Nvstep) , PeakGraph.Xmax);
			lblStatus2.Text = "Setting Fuel from" + Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.NvStep), "####0.00") + " mm to " + Format(txmax, "####0.00") + " mm";
			lblStatus2.Refresh();
			//'show status on label

			//blnBHOptim = gobjMessageAdapter.ShowMessage("Aspirate Max. Standard and Click OK", "Height optimisation", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)

			//PeakGraph.Xmax=txmin ;
			//PeakGraph.Xmin= txmax;
			//PeakGraph.Ymin= 0.0;//GetEnergy(2047);
			//PeakGraph.Ymax= 1.0;//GetEnergy(2047.0+409.6*4);
			//mobjParameters.XaxisMax = txmax
			//mobjParameters.XaxisMin = txmin
			//mobjParameters.YaxisMax = 0.0
			//mobjParameters.YaxisMin = 1
			//AASGraphs.XAxisMax = txmax
			//AASGraphs.XAxisMin = txmin
			// AASGraphs.YAxisMax = 1.0
			//AASGraphs.YAxisMin = 0.0

			AASGraphs.AldysPane.XAxis.PickScale(AASGraphs.XAxisMin, AASGraphs.XAxisMax);
			AASGraphs.AldysPane.YAxis.PickScale(AASGraphs.YAxisMin, AASGraphs.YAxisMax);
			//'for picking X,Y scale from the graph object.
			AASGraphs.XAxisMax = txmax;
			AASGraphs.XAxisMin = txmin;

			AASGraphs.AldysPane.AxisChange();
			//'change the axis 
			AASGraphs.Invalidate();
			AASGraphs.Refresh();
			Application.DoEvents();
			//'allow application to perfrom it panding work.
			////-----------------------------------------

			////------------------------------------------
			//SetInstrumentCondns(hwnd, TRUE);
			//xvalmax = ConvertToNvPos(PeakGraph.Xmax) ;
			//abs = ConvertToFuel(xvalmax) ;
			//xvalmin = ConvertToNvPos(PeakGraph.Xmin) ;
			//abs = ConvertToFuel(xvalmin) ;
			if (blnBHOptim == true) {
				//'check for burner optimization flag.
				//---to set instrument conditions
				gobjClsAAS203.funcSetInstrumentCondns(true);
				//xvalmax = funcConvertToNvPos(mobjParameters.XaxisMin)
				//---convert x axis max value to nv position.
				xvalmax = gobjClsAAS203.funcConvertToNvPos(AASGraphs.XAxisMax);
				//---convert value to fuel
				abs = gobjClsAAS203.funcConvertToFuel(xvalmax);
				//xvalmin = funcConvertToNvPos(mobjParameters.XaxisMax)
				//---convert x axis min value to nv position.
				xvalmin = gobjClsAAS203.funcConvertToNvPos(AASGraphs.XAxisMin);
				//---convert value to fuel
				abs = gobjClsAAS203.funcConvertToFuel(xvalmin);

				//i= (int )  ((xvalmax-xvalmin)/NVSCANSTEP);
				//i = abs(i)
				i = Fix((xvalmax - xvalmin) / CONST_NVSCANSTEP);
				i = Math.Abs(i);
				//strcpy(PYaxis,"ABS"); strcpy(PXaxis,"Fuel ratio");
				//Show_Peak_Param(hwnd, i);
				//PeakGraph.Xmax=txmin ;
				//PeakGraph.Xmin= txmax;
				//AASGraphs.XAxisMax = txmin
				//AASGraphs.XAxisMin = txmax



				//gobjClsAAS203.funcSetBHPos(txmin)
				//gobjMessageAdapter.CloseStatusMessageBox()
				//gobjMessageAdapter.ShowStatusMessageBox("Burner Height Optimisation", "Burner Height", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage, 0)
				//lblStatus1.Text = "Burner height optimisation"
				//lblStatus1.Refresh()
				lblStatus1.Text = "Fuel optimisation";
				lblStatus1.Refresh();
				//'show the status on label.
				// Check the property for interuption from user to terminate the process
				if (ThTerminate == true) {
					//If gobjCommProtocol.funcBreakSpectrum() = False Then
					//Exit Do
					//End If
					//'if terminate flag is true then exit scan.
					goto ExitScan;
				}

				//--- to set fuel   
				gobjClsAAS203.funcSetFuel(txmax);
				//'for setting a fuel.
				Application.DoEvents();
				//'allow application to perfrom its panding
				lMode = gobjInst.Mode;
				//---set calibration mode as AA.
				gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.AA);
				Application.DoEvents();
				//'set the calibration mode to AA and allow application to perfrom its panding work.
				gobjCommProtocol.mobjCommdll.subTime_Delay(100);
				//'communication function for delay
				Application.DoEvents();
				//---convert value to nv scan steps.
				blnStartSpec = gobjCommProtocol.funcNVScanSteps(xvalmin);
				//Procedure Name         :   funcNVScanSteps
				//Description            :   To Optimise the Fuel        
				//Parameters             :   intSteps : turret to be rotate by this num 
				gobjCommProtocol.mobjCommdll.subTime_Delay(50);
				//'delay
				xval = xvalmax;
				i = 1;
				//tout = GetTimeOut();
				//SetTimeOut(VERY_LONG_DEALY);
				if (blnStartSpec == true) {
					gblnInComm = false;
					while (true) {
						if (gblnInComm == false) {
							//If (Recev(False)) Then
							//		adval= GetParam2()*256 + GetParam1();
							//                Else
							//		break;
							//                    If (adval >= 6000) Then
							//		break;
							//#If QDEMO Then
							//	  adval = 2100+random(20);
							//#End If

							//---to receive scanned data.
							if (gobjCommProtocol.funcReceive_ScanData(0, adval) == true) {
								//'for receiving a scan data
								//adval = GetParam2() * 256 + GetParam1()
								//Else
								//Exit Do

								//adval = GetParam2() * 256 + GetParam1()
								//Else
								if ((adval >= 6000)) {
									break; // TODO: might not be correct. Was : Exit Do
								}

								//--- For Demo Mode
								//#If QDEMO Then
								//	  adval = 2100+random(20);
								//#End If
								//If gstructSettings.AppMode = EnumAppMode.DemoMode Then
								if ((gstructSettings.AppMode == EnumAppMode.DemoMode) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_203D)) {
									//'for demo mode.
									adval = 2100 + objRandom.Next(20);
								}

								//abs = GetADConvertedToCurMode(adval);
								//---convert scanned value to calibration mode value.
								abs = gFuncGetADConvertedToCurMode(adval);

								//if (abs > max_abs)    {
								// max_abs=abs;
								// max_fuel=xval;
								// pflag=TRUE;
								//}
								if ((abs > max_abs)) {
									max_abs = abs;
									max_fuel = xval;
									pflag = true;
								}
								//xfuel=ConvertToFuel(xval);
								//---convert value to fuel
								xfuel = gobjClsAAS203.funcConvertToFuel(xval);
								//sprintf(line1,"(%4.2f, %4.3f) %d (%d-%d)",xfuel, abs, xval, xvalmin, xvalmax);
								//SetText(hwnd, IDC_STATUS,line1);
								lblStatus2.Text = "Setting fuel " + Format(xfuel, "####0.00").ToString + " " + Format(abs, "#0.000").ToString + " " + Format(xval, "#0.00").ToString + " " + Format(xvalmin, "#0.00").ToString + " to " + Format(xvalmax, "####0.00").ToString;
								lblStatus2.Refresh();

								//Start to plot the graph
								//if (i==1)
								//GPlotInit(hdc, ConvertToBurnerHeight(xval), abs);
								//Else
								//GPlot(hdc,ConvertToBurnerHeight(xval), abs);

								//---plot a graph of these values
								mobjThreadController.Display(xfuel + "|" + abs.ToString);

								xval += CONST_NVSCANSTEP;
								//i++;
								i += 1;
								if (!(gobjCommProtocol.funcPC_END)) {
									break; // TODO: might not be correct. Was : Exit Do
								}
							} else {
								break; // TODO: might not be correct. Was : Exit Do
							}
						}
						Application.DoEvents();
					}
				}

			}
			ExitScan:
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			if (pflag == true) {
				//#If QDEMO Then
				//		Get_NV_Pos();
				//#End If

				lblStatus2.Text = "Optimised at " + Format(gobjClsAAS203.funcConvertToFuel(max_fuel), "####0.00").ToString + " " + Format(max_abs, "#0.000").ToString;
				lblStatus2.Refresh();
				lblStatus3.Text = "Positioning to optimised position ...";
				lblStatus3.Refresh();
				Application.DoEvents();
				////----- Show the peak on graph
				//GShowPeak(hdc,ConvertToFuel(max_fuel),  max_abs, NULL);
				////-----


				//#If EMU Then
				// Wait_For_Some_Msg(5);
				//#End If
				//SetFuel(ConvertToFuel(max_fuel));
				//---position nv to optimized fuel condition.
				gobjClsAAS203.funcSetFuel(gobjClsAAS203.funcConvertToFuel(max_fuel));
				lblStatus3.Text = "Position is optimised ";
				lblStatus3.Refresh();
			}
			//Cal_Mode(lMode);
			//---set calibration mode
			gobjCommProtocol.funcCalibrationMode(lMode);

			Application.DoEvents();
			//pc_delay(1500);
			// SetScanning(FALSE);
			// SetXoldYold(txold, tyold);
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);
			gobjClsAAS203.subSetXoldYold(inttxold, inttyold);
			gobjMessageAdapter.CloseStatusMessageBox();
			gobjCommProtocol.mobjCommdll.subTime_Delay(100);

			//gobjMessageAdapter.CloseStatusMessageBox()
			gobjCommProtocol.funcCalibrationMode(lMode);
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
			gblnInComm = false;
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}

	#End Region

}
