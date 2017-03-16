 // ERROR: Not supported in C#: OptionDeclaration
using BgThread;
using AAS203.Common;

public class ClsBgManualIgnition : BgThread.IBgWorker
{

	#Region " Private Variables "
	private bool mblnIgnitionWait = false;
	private bool mblnThTerminate = false;
	bool mblnEndProcess = false;
		#End Region
	private IBgThread mobjThreadController;

	#Region " Public Property "

	public bool ThTerminate {
		//'this is public property for setting a terminating a thread 
		get { return mblnThTerminate; }
		set {
			mblnThTerminate = Value;
			mblnIgnitionWait = Value;
		}
	}

	public bool IgnitionWait {
		//'flag for Ignition wait.
		get { return mblnIgnitionWait; }
		set { mblnIgnitionWait = Value; }
	}

	#End Region

	#Region " Public Events "

	public event  ManualIgnition;

	#End Region

	#Region " Constructors "

	public ClsBgManualIgnition()
	{
		base.New();
		ThTerminate = false;
		mblnIgnitionWait = false;
	}

	#End Region

	#Region " Public Functions "

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		//=====================================================================
		// Procedure Name        : Initialize
		// Parameters Passed     : Controller As BgThread.IBgThread
		// Returns               : None
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
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : to Start the thread
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale 
		// Created               : 19.03.07
		// Revisions             : 
		//=====================================================================
		bool blnCancel = false;
		CWaitCursor objwait = new CWaitCursor();
		try {
			mblnEndProcess = true;
			while ((blnCancel == false)) {
				if (mobjThreadController.Running) {
					//---check  thread is either running or not. 
					if (mblnThTerminate == true) {
						//'---this is a flag for terminating a thread.
						blnCancel = true;
					} else {
						if (mblnIgnitionWait == false) {
							if (ManualIgnition != null) {
								ManualIgnition(!(blnCancel));
							}
							//--call a event for manual ignition
						}
					}
				} else {
					//---Client requested a cancel
					blnCancel = true;
					break; // TODO: might not be correct. Was : Exit Do
				}
			}
			blnCancel = true;
			if (mobjThreadController.Running == true) {
				mobjThreadController.Completed(true);
				//---complete the thread.
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			//mobjThreadController.Failed(ex)
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

}
