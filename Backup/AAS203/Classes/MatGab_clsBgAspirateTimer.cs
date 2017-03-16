using BgThread;

namespace AspirateMessage
{

	internal class clsBgAspirateTimer : BgThread.IBgWorker
	{

		#Region " Constructors "

		public clsBgAspirateTimer()
		{
			base.New();

		}

		public clsBgAspirateTimer(ref object lblSt1)
		{
			//=====================================================================
			// Procedure Name        : New
			// Parameters Passed     : lblSt1 as form object
			// Returns               : 
			// Purpose               : New [Constuctor]
			// Description           : 
			// Assumptions           : 
			// Dependencies          : 
			// Author                : Sachin Dokhale
			// Created               : 29.11.06
			// Revisions             : 
			//=====================================================================
			base.New();


			try {
				mlblStatus1 = lblSt1;

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

		private object mlblStatus1;
		private int mintAspirationTimerCounter;
		private bool mblnIsBlinkMessage = true;
		private string mstrAspirationMessage;

		private bool mIsThreadStared = false;
		#End Region

		#Region " Public Property "

		public string AspirationMessage {
			get { return mstrAspirationMessage; }
			set { mstrAspirationMessage = Value; }
		}

		public bool IsBlinkMessage {
			get { return mblnIsBlinkMessage; }
			set { mblnIsBlinkMessage = Value; }
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
			// Created               : 
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
			// Returns               : IBgWorker.Start
			// Purpose               : To Start the worker thread
			// Description           : 
			// Assumptions           : 
			// Dependencies          : 
			// Author                : Sachin Dokhale
			// Created               : 29.11.06
			// Revisions             : 
			//=====================================================================

			try {
				////----- Added by Sachin Dokhale on 25.03.07
				////----- To know the Status of Thread on Status Bar of MDI Main
				//Dim strPreviousStatusMessage As String
				//If gblnShowThreadOnfrmMDIStatusBar Then
				//    strPreviousStatusMessage = gobjMain.StatusBar1.Text
				//    gobjMain.StatusBarPanelInfo.Text = strPreviousStatusMessage & " *Turret Opti"
				//    Application.DoEvents()
				//End If
				////-----
				Application.DoEvents();
				//If mIsThreadStared = True Then
				//    Exit Sub
				//End If
				mIsThreadStared = true;
				if (mobjThreadController.Running) {
					//SyncLock Me
					if (funcThreadAspirateMsg(mlblStatus1) == true) {
						//mobjThreadController.Completed(True)
						mIsThreadStared = false;
					}
				//End SyncLock
				} else {
					//mobjThreadController.Completed(False)
					////----- Added by Sachin Dokhale on 25.03.07
					Application.DoEvents();
					mIsThreadStared = false;
					return;
				}
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

		private bool funcThreadAspirateMsg(ref object lblStatus1)
		{
			//------------------------------------------------------------------
			//Procedure Name         :   funcThreadTurret_Optimise
			//Description            :   To optimise Turret position 
			//Parameters             :   dblLampCurrent,intLampPos 
			//Return                 :   True if success
			//Time/Date              :   8/11/06
			//Dependencies           :   
			//Author                 :   Deepak B.
			//Revision               :
			//Revision by Person     :   15.12.06
			//--------------------------------------------------------------------------------------
			//Saruabh 06-06-2007 added parameter lblWvStatus
			//Return gobjCommProtocol.funcTurret_Optimise(dblLampCurrent, intLampPos, lblStatus1, lblStatus2, lblStatus3, ObjGraph, ObjThreadController)

			try {
				// Application.DoEvents()
				while ((true)) {
					Application.DoEvents();
					if (mobjThreadController.Running == false) {
						break; // TODO: might not be correct. Was : Exit Do
						Application.DoEvents();
					}
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					Application.DoEvents();
					mintAspirationTimerCounter += 1;
					if ((mintAspirationTimerCounter > 1000)) {
						mintAspirationTimerCounter = 1;
					}

					if ((mintAspirationTimerCounter % 3 == 0)) {
						if (mblnIsBlinkMessage) {
							ShowAspirationMessages(false, lblStatus1);
						} else {
							ShowAspirationMessages(true, lblStatus1);
						}
					//Application.DoEvents()
					} else {
						ShowAspirationMessages(true, lblStatus1);
						//Application.DoEvents()
					}
					Application.DoEvents();
				}
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

		private void ShowAspirationMessages(bool blnIsShow, ref object lblStatus1)
		{
			//=====================================================================
			// Procedure Name        : ShowAspirationMessages
			// Parameters Passed     : Flag to Set or Clear the Message.
			// Returns               : None
			// Purpose               : 
			// Description           : 
			// Assumptions           : 
			// Dependencies          : 
			// Author                : Mangesh Shardul
			// Created               : 17-Jan-2007 03:25 pm
			// Revisions             : 1
			//=====================================================================
			//void	ShowAspMessage(BOOL	flag)
			//{
			//   char str[128]="";
			//   int t=0;
			//   if (flag)
			//   {
			//       GetDlgItemText(Mhwnd, IDC_TASP, str, 120);
			//	    ltrim(trim(str));
			//	    t = Ignite_Test();
			//	    if( (Method->Mode != MODE_UVABS && !GetHydrideModeStatus()) && (t == GREEN || t == RED) )  // mdf by sss for showing the flame error message
			//       {
			//		    SetDlgItemText(Mhwnd, IDC_TASP, "  Flame is OFF  ");
			//	    }
			//   	else
			//       {
			//   		if (strcmpi(str,Aspiratemsg)!=0)
			//		     SetDlgItemText(Mhwnd, IDC_TASP, Aspiratemsg);
			//	    }
			//   }
			//   Else
			//       SetDlgItemText(Mhwnd, IDC_TASP, "");
			//}

			//****************************************************************
			//---CODE BY MANGESH
			//****************************************************************
			ClsAAS203.enumIgniteType intIgniteType;
			string strAspMessage;
			string strTest;
			try {
				//Application.DoEvents()
				if ((blnIsShow)) {
					strAspMessage = Trim(lblStatus1.Text);

					if (gstructSettings.AppMode == EnumAppMode.DemoMode) {
					//intIgniteType = ClsAAS203.enumIgniteType.Blue
					} else {
						//intIgniteType = gobjClsAAS203.funcIgnite_Test()
					}

					//If ((gobjNewMethod.OperationMode <> EnumOperationMode.MODE_UVABS And Not gobjInst.Hydride) _
					//    And (intIgniteType = ClsAAS203.enumIgniteType.Green Or intIgniteType = ClsAAS203.enumIgniteType.Red)) Then
					//intIgniteType = gobjMain.IgniteType

					//code added by : dinesh wagh on 9.2.2010
					//Purpose : if gobjNewMethod is nothing then throws exception.
					//---------------------------------
					if (gobjNewMethod == null) {
						return;
					}
					//-----------------------------------


					if (((gobjNewMethod.OperationMode != EnumOperationMode.MODE_UVABS & !gobjInst.Hydride) & (gobjMain.IgniteType == ClsAAS203.enumIgniteType.Green | gobjMain.IgniteType == ClsAAS203.enumIgniteType.Red))) {
						//for showing the flame error message
						lblStatus1.Text = "  Flame is OFF  ";
					} else {
						if (string.Compare(strAspMessage, AspirationMessage) != 0) {
							lblStatus1.Text = AspirationMessage;

							strTest = AspirationMessage.TrimStart().Substring(0, 8);
							if (string.Compare(strTest, "Aspirate") == 0) {
								FuncAlert();
							}
							//lblStatus1.Refresh()
						}
					}

				} else {
					lblStatus1.Text = "";
					//lblStatus1.Refresh()
				}
			//Application.DoEvents()
			//If btnReadData.Enabled Then
			//    btnReadData.Focus()
			//    btnReadData.Refresh()
			//End If
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
				Application.DoEvents();
				//---------------------------------------------------------
			}
		}

		private object FuncAlert()
		{
			switch (gintAspirationType) {
				case 1:
					BlankAlert();
				case 2:
					StandardAlert();
				case 3:
					SampleAlert();
			}
		}

		#End Region

	}

	public class clsMassageController : System.Windows.Forms.Form, BgThread.Iclient
	{

		#Region " Private Variables "
		private object lblAspirationMessage;
		private clsBgThread mMsgController;
		private clsBgAspirateTimer mobjBgMsgAspirate;
		private bool mblnIsBlinkMessage;
		private string mstrAspirationMessage;
			#End Region
		private bool mblnIsMessageRunning = false;

		#Region " Constructors "

		public clsMassageController()
		{
			base.New();

		}

		public clsMassageController(ref object lblSt1)
		{
			//=====================================================================
			// Procedure Name        : New
			// Parameters Passed     : lblSt1,lblSt2,lblSt3,dblLampCurrent ,intLampPos,objGraph
			// Returns               : 
			// Purpose               : To put the IGNITE ON or OFF.
			// Description           : 
			// Assumptions           : 
			// Dependencies          : 
			// Author                : Sachin Dokhale
			// Created               : 29.11.06
			// Revisions             : 
			//=====================================================================
			base.New();


			try {
				lblAspirationMessage = lblSt1;
				mMsgController = new clsBgThread(this);
				mobjBgMsgAspirate = new clsBgAspirateTimer(lblAspirationMessage);
				mobjBgMsgAspirate.Initialize(mMsgController);
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


		#Region " Public Property "

		public string AspirationMessage {
			get { return mstrAspirationMessage; }
			set {
				mstrAspirationMessage = Value;
				mobjBgMsgAspirate.AspirationMessage = Value;
			}
		}

		public bool IsBlinkMessage {
			get { return mblnIsBlinkMessage; }
			set {
				mblnIsBlinkMessage = Value;
				mobjBgMsgAspirate.IsBlinkMessage = Value;
			}
		}

		public bool IsMessageRunning {
			get { return mblnIsMessageRunning; }
			set { mblnIsMessageRunning = Value; }
		}
		#End Region

		#Region " Public Functions"
		public object Cancel()
		{
			try {
				mMsgController.Cancel();
				IsMessageRunning = false;
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
		public object Start()
		{
			try {
				mblnIsMessageRunning = true;
				mMsgController.Start(mobjBgMsgAspirate);
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

		public void BgThread.Iclient.Completed(bool Cancelled)
		{
			IsMessageRunning = false;
		}


		public void BgThread.Iclient.Display(string Text)
		{
		}

		public void BgThread.Iclient.Failed(System.Exception e)
		{
			IsMessageRunning = false;
		}


		private void BgThread.Iclient.Start1(BgThread.clsBgThread clsBgThread)
		{
		}

	}
}
