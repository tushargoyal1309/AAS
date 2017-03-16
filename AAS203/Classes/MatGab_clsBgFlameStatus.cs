using BgThread;
using AAS203.Common;

public class clsBgFlameStatus : BgThread.IBgWorker
{

	#Region " Private Variable "

	private IBgThread mobjThreadController;
	//---object ot thread class

	#End Region

	#Region " Constructors "

	public clsBgFlameStatus()
	{
		base.New();
		gobjCommProtocol.mobjCommdll.subTime_Delay(100);
		//---communication delay
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
		// Author                : Sachin Dokhale
		// Created               : 26-Dec-2006
		// Revisions             : 1
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
		string strPreviousStatusMessage;
		try {
			//--- Added by Sachin Dokhale on 25.03.07
			//--- To know the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				strPreviousStatusMessage = gobjMain.StatusBarPanelInfo.Text;
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage + " *Flame Status";
			}
			//---
			if (!(gobjfrmStatus == null)) {
				gobjfrmStatus.TopMost = true;
			}
			//---To display flame status
			funcDisplayFlame();

			//--- Added by Sachin Dokhale on 25.03.07
			//--- To remove the Status of Thread on Status Bar of MDI Main
			if (gblnShowThreadOnfrmMDIStatusBar) {
				gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage;
				Application.DoEvents();
				//'---allow application to perfrom its panding work.
			}
		//---

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
		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_203 | gstructSettings.AppMode == EnumAppMode.FullVersion_203D | gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//---check a application mode.
				while ((true)) {
					if (!mobjThreadController.Running) {
						//---Client requested a cancel
						mobjThreadController.Completed(true);
						break; // TODO: might not be correct. Was : Exit Do
					}

					//If gblnInCommProcess = False and = Then
					if (clsRS232Main.IsInCommu == false) {
						//Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
						if (gintCommPortSelected > 0) {
							Application.DoEvents();
							//---to check flame type 

							//mintIgniteType = gobjClsAAS203.funcIgnite_Test()
							ClsAAS203.enumIgniteType intIgnite_Test;
							if (gobjClsAAS203.funcIgnite_Test(intIgnite_Test)) {
								mintIgniteType = intIgnite_Test;
							}
							//---
							if (!mobjThreadController.Running) {
								//---Client requested a cancel
								mobjThreadController.Completed(true);
								break; // TODO: might not be correct. Was : Exit Do
							}
							if (gblnIsInstReset == true) {
								gobjCommProtocol.mobjCommdll.subTime_Delay(30);
								//If gobjCommProtocol.mobjCommdll.gFuncResumeProcess = True Then   '10.12.07
								Application.DoEvents();
								if (!mobjThreadController.Running) {
									//---Client requested a cancel
									mobjThreadController.Completed(true);
									break; // TODO: might not be correct. Was : Exit Do
								}
								gobjClsAAS203.ReInitInstParameters();
								//End If
								//gobjClsAAS203.ReInitInstParameters()
							}

							//---display flame type
							mobjThreadController.Display(mintIgniteType);
							Application.DoEvents();
						//--- Added by Sachin Dokhale on 07.01.08
						//If gblnIsInstReset = True Then
						//    gobjClsAAS203.ReInitInstParameters()
						//End If
						} else {
							//No Communication (No comm port is selected)
							mobjThreadController.Completed(true);
							break; // TODO: might not be correct. Was : Exit Do
						}
					}

					if (!mobjThreadController.Running) {
						//---Client requested a cancel
						mobjThreadController.Completed(true);
						break; // TODO: might not be correct. Was : Exit Do
					}
					if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					} else {
						gobjCommProtocol.mobjCommdll.subTime_Delay(100);
					}
					//---communication delay
					Application.DoEvents();
					//---allow application to perfrom its panding work.
				}
			}

			//'---16.03.08
			//If gstructSettings.AppMode = EnumAppMode.DemoMode _
			//   Or gstructSettings.AppMode = EnumAppMode.DemoMode_201 _
			//   Or gstructSettings.AppMode = EnumAppMode.DemoMode_203D Then
			//    '---check a application mode.
			//    Do While (True)
			//        If Not mobjThreadController.Running Then
			//            '---Client requested a cancel
			//            mobjThreadController.Completed(True)
			//            Exit Do
			//        End If

			//        If clsRS232Main.IsInCommu = False Then
			//            If gintCommPortSelected > 0 Then
			//                Application.DoEvents()
			//                '---display flame type
			//                mobjThreadController.Display(6)
			//                Application.DoEvents()
			//            Else
			//                'No Communication (No comm port is selected)
			//                mobjThreadController.Completed(True)
			//                Exit Do
			//            End If
			//        End If

			//        If Not mobjThreadController.Running Then
			//            '---Client requested a cancel
			//            mobjThreadController.Completed(True)
			//            Exit Do
			//        End If

			//        Call gobjCommProtocol.mobjCommdll.subTime_Delay(100)
			//        '---communication delay
			//        Application.DoEvents()
			//        '---allow application to perfrom its panding work.
			//    Loop
			//End If
			//'---16.03.08

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
			Application.DoEvents();
			//---------------------------------------------------------
		}
	}
	#End Region

}
