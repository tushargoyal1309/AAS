using BgThread;
using AAS203.Common;

public class clsBgFlameStatus : BgThread.IBgWorker
{

	#Region " Private Variable"
	private IBgThread mobjThreadController;
	private bool mblnStatusWait;
	//Private mblnStatusEnable As Boolean

	private bool mblnThreadTerminate;

		#End Region
	System.Object mlblObjStatus;

	#Region " Public Properties "

	public bool blnPropStatusWait {
		get { blnPropStatusWait = mblnStatusWait; }
		set { mblnStatusWait = Value; }
	}

	//Public Property blnPropStatusEnable() As Boolean
	//    Get
	//        StatusEnable = mblnStatusEnable
	//    End Get
	//    Set(ByVal Value As Boolean)
	//        mblnStatusEnable = Value
	//    End Set
	//End Property

	public bool blnPropThreadTerminate {
		get { blnPropThreadTerminate = mblnThreadTerminate; }
		set { mblnThreadTerminate = Value; }
	}

	#End Region

	#Region " Constructors "

	public clsBgFlameStatus()
	{
		base.New();
		blnPropStatusWait = false;
		blnPropThreadTerminate = false;
		gobjCommProtocol.mobjCommdll.subTime_Delay(100);
	}

	#End Region

	#Region " Public Functions "

	public void BgThread.IBgWorker.Initialize(BgThread.IBgThread Controller)
	{
		try {
			mobjThreadController = Controller;
		// mblnStatusWait = False
		// mblnThreadTerminate = False
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

	public void BgThread.IBgWorker.Start()
	{
		//=====================================================================
		// Procedure Name        : Start
		// Parameters Passed     : None
		// Returns               : BgThread.IBgWorker.Start
		// Purpose               : to start the process
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale 
		// Created               : 19.03.07
		// Revisions             : 
		//=====================================================================
		bool blnCancel = false;

		try {
			if (mobjThreadController.Running) {
				if (blnPropThreadTerminate == false) {
					if (funcDisplayFlame() == true) {
					} else {
					}
				}
			} else {
				//Client requested a cancel
				mobjThreadController.Completed(true);
				return;
			}

			mobjThreadController.Completed(true);

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
			blnPropThreadTerminate = false;
			//---------------------------------------------------------
		}
	}

	//Public Sub TerminateThread()
	//    '=====================================================================
	//    ' Procedure Name        : TerminateThread
	//    ' Parameters Passed     : None
	//    ' Returns               : None
	//    ' Purpose               : to terminate the process
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Sachin Dokhale 
	//    ' Created               : 19.03.07
	//    ' Revisions             : 
	//    '=====================================================================
	//    Try

	//        Do While True '(blnCancel = False)
	//            If mobjThreadController.Running Then
	//                blnPropThreadTerminate = True
	//            Else
	//                'Client requested a cancel
	//                mobjThreadController.Completed(False)
	//                Exit Sub
	//            End If
	//            'gobjCommProtocol.mobjCommdll.subTime_Delay(100)
	//            Application.DoEvents()
	//        Loop

	//        'If mobjThreadController.Running = True Then
	//        '    mobjThreadController.Completed(True)
	//        'Else
	//        '    mobjThreadController.Completed(False)
	//        'End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        mobjThreadController.Failed(ex)
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

	#End Region

	#Region " Private Functions "

	private bool funcDisplayFlame()
	{
		//=====================================================================
		// Procedure Name        : funcDisplayFlame
		// Parameters Passed     : None
		// Returns               : Boolean
		// Purpose               : to Display Flame status
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale 
		// Created               : 19.03.07
		// Revisions             : 
		//=====================================================================
		int mintIgniteType;
		bool blnReturnValue;

		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion) {
				blnReturnValue = true;

				while ((blnPropThreadTerminate == false)) {
					if (mobjThreadController.Running) {
						if (blnPropStatusWait == false) {
							if (gblnInComm == false) {
								mintIgniteType = gobjClsAAS203.funcIgnite_Test();
								mobjThreadController.Display(mintIgniteType);
							}
						}
						Application.DoEvents();
					} else {
						blnPropThreadTerminate = true;
						break; // TODO: might not be correct. Was : Exit Do
					}
					//Call gobjCommProtocol.mobjCommdll.subTime_Delay(1000)
					Threading.Thread.Sleep(1000);
					Application.DoEvents();
				}
			}

			return true;


		} catch (Threading.ThreadAbortException threadex) {
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			mobjThreadController.Failed(ex);
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
