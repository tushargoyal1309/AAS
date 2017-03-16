using BgThread;
using AAS203.Common;
using AAS203Library.Instrument;

public class clsBgOptimizeAll : BgThread.IBgWorker
{

	#Region " Constructors "

	public clsBgOptimizeAll()
	{
		base.New();
	}

	public clsBgOptimizeAll(ref Label lblSt1Opt, ref Label lblSt2Opt, ref Label lblSt3Opt, ref object objGraphOpt)
	{
		//=====================================================================
		// Procedure Name        : New
		// Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
		// Returns               : 
		// Purpose               : To initialize the object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		base.New();

		try {
			mlblStatus1Opt = lblSt1Opt;
			mlblStatus2Opt = lblSt2Opt;
			mlblStatus3Opt = lblSt3Opt;
			mObjGraphOpt = objGraphOpt;

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
	private Label mlblStatus1Opt;
	private Label mlblStatus2Opt;
	private Label mlblStatus3Opt;

	private object mObjGraphOpt;
	#End Region

	#Region " Public Functions "

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		//=====================================================================
		// Procedure Name        : Initialize
		// Parameters Passed     : Controller
		// Returns               : IBgWorker.Initialize as implements
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
		// Returns               : IBgWorker.Start as Implements
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
			////----- Added by Sachin Dokhale on 25.03.07
			////----- To know the Status of Thread on Status Bar of MDI Main
			string strPreviousStatusMessage;
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBar1.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *Opti All Turret";
				Application.DoEvents();
				//---show a status and allow application to perfrom its panding work.
			}
			////-----
			if (mobjThreadController.Running) {
				if (funcTur_Opt_Zero(mlblStatus1Opt, mlblStatus2Opt, mlblStatus3Opt, mObjGraphOpt, mobjThreadController) == true) {
					//'this is main function for turrert optmization.
					mobjThreadController.Completed(true);
					//Application.DoEvents()
				}
			} else {
				mobjThreadController.Completed(true);
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
			//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
			////----- Added by Sachin Dokhale on 25.03.07
			////----- To remove the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
				//---show a info opn status bar.
				Application.DoEvents();
				//---allow application to perfrom its panding work.
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

	public bool funcTur_Opt_Zero(ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null, ref object ObjGraph = null, object ObjThreadController = null)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   funcTur_OptThread
		//Description            :   To optimise turret
		//Parameters             :   lblStatus1,lblStatus2,lblStatus3 as label,ObjGraph  as AASGraph
		//Parameter Affected     :   ObjThreadController as thread controller
		//Returns                :   True if success
		//Time/Date              :   17.11.06
		//Dependencies           :   
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   
		//--------------------------------------------------------------------------------------
		int rPOs;
		int intCounter;
		int chNew;
		int max_int;
		int in_pos;
		double dblEnergy;
		string strData;
		//---------------------------------------------------
		//        void	Tur_Opt(HWND hwnd, HDC hdc)
		//{
		//int    chnew, i;
		//int    in_pos, max_int, rpos;
		//char line7[80]="";

		// SetFocus(hwnd);
		// if( GetInstrument() == AA202)
		//	 SetText(hwnd, IDC_STATUS, "Lamp Optimization");
		//        Else
		//	 SetText(hwnd, IDC_STATUS, "Turret Optimization");
		// Cal_Mode(HCLE);
		// rpos = Tur_pre_opt(hwnd);

		//#If !NEWZERO Then
		//  Adj_PMT_forvalue(hwnd, (double) 3500.0, (double)350);
		//#Else
		//  Adj_PMT_forvalue(hwnd, (double)(3500.0*100.0/5000.0 ), (double)350.0);
		//#End If
		// Show_Pmt(hwnd, Inst->Pmtv);
		// pc_delay (200);
		// for (i=1; i<=rpos+10; i++)  {
		//	Rotate_Anticlock_Tur();
		//	}
		// for (i=1; i<=10; i++) {
		//	Rotate_Clock_Tur();
		//  }
		// if(GetInstrument() == AA202)
		//	 SetWindowText(hwnd,"OPTIMISING LAMP");
		//                    Else
		//	 SetWindowText(hwnd,"OPTIMISING TURRET");
		// PeakGraph.Xmin= 1; PeakGraph.Xmax= RANGE;
		// PeakGraph.Ymin= GetEnergy(2047);
		// PeakGraph.Ymax= GetEnergy(2047.0+409.6*4);
		// strcpy(PYaxis,"ENERGY"); strcpy(PXaxis,"TURRET STEP");
		// Show_Peak_Param(hwnd, RANGE);
		// if( GetInstrument() == AA202 )
		//   SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Lamp Position");
		//                        Else
		//	 SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
		// in_pos = 1;
		// max_int = 0;
		// ReadADCFilter();
		// for (i=1; i<=RANGE; i++) {
		//	Rotate_Clock_Tur();
		//	pc_delay(100);
		//	chnew = ReadADCFilter();
		//	if (chnew > max_int) {
		//	  max_int = chnew;
		//	  in_pos =i;
		//	 }
		//  if (i==1)
		//		GPlotInit(hdc, (double) i, GetEnergy(chnew));
		//                                    Else
		//		GPlot(hdc, (double) i, GetEnergy(chnew));
		// }
		// GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);
		// SetText(hwnd, IDC_STATUS," Positioning Please Wait  .......        ");
		//#If EMU Then
		// Wait_For_Some_Msg(5);
		//#End If
		// for (i=1; i <= RANGE+10; i++) 	Rotate_Anticlock_Tur();
		// for (i=1; i <= 10+in_pos; i++)  {
		//	Rotate_Clock_Tur();	
		//	}
		//Inst->Lamp_par.lamp[Inst->Lamp_pos-1].lamp_optpos = in_pos;	
		//for(i=0;i<500; i++)
		// pc_delay(10000);
		//}

		//---------------------------------------------------
		CWaitCursor objWait = new CWaitCursor();
		double dblYMin;
		double dblYMax;

		try {
			funcTur_Opt_Zero = false;
			//if( GetInstrument() == AA202)
			//	 SetText(hwnd, IDC_STATUS, "Lamp Optimization");
			//        Else
			//	 SetText(hwnd, IDC_STATUS, "Turret Optimization");
			if (!lblStatus3 == null) {
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					((Windows.Forms.Label)lblStatus3).Text = "Lamp Optimization";
				} else {
					((Windows.Forms.Label)lblStatus3).Text = "Turret Optimization";
				}

			}
			//Added by pankaj on 21 Jan 08
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203D) {
				gobjCommProtocol.funcSet_PMTReferenceBeam(0);
				//Added by pankaj on 21 Jan 08
			}
			//------------

			//---Set calibration mode as HCLE
			if (gobjCommProtocol.funcCalibrationMode(EnumCalibrationMode.HCLE) == false) {
				//MessageBox.Show("Error in setting calibration mode")
				gobjMessageAdapter.ShowMessage(constCalibrationMode);
				Application.DoEvents();
			}

			//---pre optimize turret
			rPOs = gobjCommProtocol.funcTur_Pre_Opt(lblStatus1, lblStatus2, lblStatus3);

			//---adjust pmt between 70-350
			if (gobjCommProtocol.funcAdj_Pmt_ForValue((double)70.0, (double)350.0, true) == false) {
				//MessageBox.Show("Error in adjusting pmt for value")
				gobjMessageAdapter.ShowMessage(constPMTVolt);
				Application.DoEvents();
			}

			if (!lblStatus1 == null) {
				((Windows.Forms.Label)lblStatus1).Text = "PMT : -" + Format(gobjInst.PmtVoltage, "###");
				((Windows.Forms.Label)lblStatus1).Refresh();
			}

			objWait = new CWaitCursor();

			//gobjCommProtocol.mobjCommdll.subTime_Delay(200)

			//---rotate turret anticlockwise preoptimize position + 10 times.
			for (intCounter = 1; intCounter <= rPOs + 10; intCounter++) {
				gobjCommProtocol.funcRotate_Anticlock_Tur();
			}

			//---rotate turret clockwise preoptimize 10 times.
			for (intCounter = 1; intCounter <= 10; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Tur();
			}

			objWait = new CWaitCursor();

			dblYMin = -1;
			//Cint(FormatNumber(gFuncGetEnergy(2047), 1))
			dblYMax = (int)FormatNumber(gFuncGetEnergy(2047.0 + 409.6 * 4), 1);

			if (!ObjGraph == null) {
				((AASGraph)ObjGraph).XAxisMin = 0;
				((AASGraph)ObjGraph).XAxisMax = WVRANGE;
				((AASGraph)ObjGraph).YAxisMin = dblYMin;
				((AASGraph)ObjGraph).YAxisMax = dblYMax;

				((AASGraph)ObjGraph).AldysPane.XAxis.PickScale(1, WVRANGE);
				((AASGraph)ObjGraph).AldysPane.XAxis.MinorStepAuto = true;
				((AASGraph)ObjGraph).AldysPane.XAxis.StepAuto = true;
				((AASGraph)ObjGraph).Refresh();

				((AASGraph)ObjGraph).AldysPane.YAxis.PickScale(dblYMin, dblYMax);
				((AASGraph)ObjGraph).AldysPane.YAxis.MinorStepAuto = true;
				((AASGraph)ObjGraph).AldysPane.YAxis.StepAuto = true;
				((AASGraph)ObjGraph).Refresh();

				((AASGraph)ObjGraph).XAxisLabel = "TURRET STEP";
				((AASGraph)ObjGraph).YAxisLabel = "ENERGY";
				((AASGraph)ObjGraph).AldysPane.AxisChange();
				((AASGraph)ObjGraph).Invalidate();
				((AASGraph)ObjGraph).Refresh();
			}

			if (!lblStatus2 == null) {
				//CType(lblStatus2, Windows.Forms.Label).Text = "Scanning for Optimal Turret Position"
				if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
					((Windows.Forms.Label)lblStatus2).Text = "Scanning for Optimal Lamp Position";
				} else {
					((Windows.Forms.Label)lblStatus2).Text = "Scanning for Optimal Turret Position";
				}
				//   SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Lamp Position");
				//                        Else
				//	 SetText(hwnd, IDC_STATUS1, "Scanning for Optimal Turret Position");
			}

			objWait = new CWaitCursor();
			in_pos = 1;
			max_int = 0;
			//---read adc filter value
			gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew);

			for (intCounter = 1; intCounter <= WVRANGE; intCounter++) {
				//---rotate turret clockwise
				gobjCommProtocol.funcRotate_Clock_Tur();
				//gobjCommProtocol.mobjCommdll.subTime_Delay(100)
				//---read adc filter.
				gobjCommProtocol.funcReadADCFilter(gobjInst.Average, chNew);
				if (chNew > max_int) {
					max_int = chNew;
					in_pos = intCounter;
				}
				//---get energy
				dblEnergy = gFuncGetEnergy(chNew);
				strData = "";
				strData = intCounter + "," + dblEnergy;
				if (!ObjThreadController == null) {
					((BgThread.IBgThread)ObjThreadController).Display(strData);
				}
				((AASGraph)ObjGraph).Refresh();
			}
			//GShowPeak(hdc,(double) in_pos,  GetEnergy(max_int),NULL);  todo later

			if (!lblStatus2 == null) {
				((Windows.Forms.Label)lblStatus2).Text = "Positioning Please Wait  .......        ";
			}

			//---rotate turret anticlockwise 110 times.
			for (intCounter = 1; intCounter <= WVRANGE + 10; intCounter++) {
				gobjCommProtocol.funcRotate_Anticlock_Tur();
			}

			objWait = new CWaitCursor();

			//---rotate turret 10 + in_pos times.
			for (intCounter = 1; intCounter <= 10 + in_pos; intCounter++) {
				gobjCommProtocol.funcRotate_Clock_Tur();
			}

			//---store lamp optimize position.
			gobjInst.Lamp.LampParametersCollection.item(gobjInst.Lamp_Position - 1).LampOptimizePosition = in_pos;

			//---save instrument conditions status.
			if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
				funcSaveInstStatus();
			}

			if (!lblStatus2 == null) {
				((Windows.Forms.Label)lblStatus2).Text = "Finished. ";
			}

			if (!ObjThreadController == null) {
				((BgThread.IBgThread)ObjThreadController).Completed(false);
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

	#End Region

}
