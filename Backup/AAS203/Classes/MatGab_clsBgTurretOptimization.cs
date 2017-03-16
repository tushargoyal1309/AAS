using BgThread;
using AAS203.Common;
using AAS203Library.Instrument;

public class clsBgTurretOptimization : BgThread.IBgWorker
{

	#Region " Constructors "

	public clsBgTurretOptimization()
	{
		base.New();

	}

	public clsBgTurretOptimization(ref object lblSt1, ref object lblSt2, ref object lblSt3, double dblLampCurrent, int intLampPos, ref object objGraph = null, ref Label lblWvStatus = null)
	{
		//=====================================================================
		// Procedure Name        : New
		// Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
		// Returns               : 
		// Purpose               : 
		// Description           : To set the references of passed variables to module
		//                         level variables
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 29.11.06
		// Revisions             : 
		//=====================================================================
		base.New();

		try {
			mdblLampCurrent = dblLampCurrent;
			mintLampPosition = intLampPos;
			mlblStatus1 = lblSt1;
			mlblStatus2 = lblSt2;
			mlblStatus3 = lblSt3;
			mObjGraph = objGraph;
			mlblWvStatus = lblWvStatus;

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

	private IBgThread mobjThreadController;
	private double mdblLampCurrent;
	private int mintLampPosition;
	private object mlblStatus1;
	private object mlblStatus2;
	private object mlblStatus3;
	private Label mlblWvStatus;

	private object mObjGraph;
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
			//--- Added by Sachin Dokhale on 25.03.07
			//--- To know the Status of Thread on Status Bar of MDI Main
			string strPreviousStatusMessage;
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBar1.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *Turret Opti";
				Application.DoEvents();
			}
			//---
			if (mobjThreadController.Running) {
				//---optimise turret
				if (funcThreadTurret_Optimise(mdblLampCurrent, mintLampPosition, mlblStatus1, mlblStatus2, mlblStatus3, mObjGraph, mobjThreadController, mlblWvStatus) == true) {
					mobjThreadController.Completed(true);
				}
			} else {
				mobjThreadController.Completed(true);
				//--- Added by Sachin Dokhale on 25.03.07
				//--- To remove the Status of Thread on Status Bar of MDI Main
				if (gblnShowThreadOnfrmMDIStatusBar) {
					gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
				}
				//---
				Application.DoEvents();
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

	private bool funcThreadTurret_Optimise(double dblLampCurrent, int intLampPos, ref object lblStatus1 = null, ref object lblStatus2 = null, ref object lblStatus3 = null, ref object ObjGraph = null, object ObjThreadController = null, ref Label lblWvStatus = null)
	{
		//------------------------------------------------------------------
		//Procedure Name         :   funcThreadTurret_Optimise
		//Description            :   To optimise Turret position 
		//Parameters             :   dblLampCurrent,intLampPos, ObjThreadController as thread Control
		//Parameters affected    :   lblStatus,lblStatus1,lblStatus2,lblStatus3 as label object
		//                       :   ObjGraph   
		//Return                 :   True if success
		//Time/Date              :   8/11/06
		//Dependencies           :   Serial Communication
		//Author                 :   Deepak B.
		//Revision               :
		//Revision by Person     :   15.12.06
		//--------------------------------------------------------------------------------------
		try {
			//---Saruabh 06-06-2007 added parameter lblWvStatus
			//Return gobjCommProtocol.funcTurret_Optimise(dblLampCurrent, intLampPos, lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController)
			return gobjCommProtocol.funcTurret_Optimise(dblLampCurrent, intLampPos, lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController, lblWvStatus);

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
