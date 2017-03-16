
public class clsTimer : IConfirmable
{

	#Region " Private Class Member Variables "

	private int intInterval;
	private bool mblnOtherEvent;
	private bool mblnTimerCompleted;
	private bool mblnTimerStop;
	private System.Timers.Timer tmr_AutoZero;

	private System.Object stbrStatus;
	//--- Constant used for the index of the status bar panel
	//--- to display current date and time.

	private const  CONST_CURR_DATE_TIME = 2;
	#End Region

	#Region " Constructors "

	public clsTimer(ref System.Object objStatusBar, int intTimerIntervalMiliSecond)
	{
		//----------------------------------------------------------------------------
		//Procedure Name	    :   New
		//Description	    :   TO start and instanciate the object
		//Parameters 	    :   label and timer interval
		//Time/Date  	    :   21/01/05
		//Dependencies	    :   
		//Author		        :   M.Kamal
		//Revision		    :  
		//Revision by Person	: 
		//----------------------------------------------------------------------------
		try {
			intInterval = 1000;
			mblnOtherEvent = false;
			mblnTimerCompleted = true;
			mblnTimerStop = false;
			tmr_AutoZero = new System.Timers.Timer(intInterval);

			stbrStatus = objStatusBar;

			//--- Display current date and time
			subDisplayCurrDateTime();

			tmr_AutoZero.Elapsed += tmr_AutoZero_Elasped;

			if (intTimerIntervalMiliSecond > 0) {
				intInterval = intTimerIntervalMiliSecond;
			}
			tmr_AutoZero.Start();

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private functions "

	private void subDisplayCurrDateTime()
	{
		//--- Procedure to display the current date and time
		//--- on the screen

		try {
			//check if form objects passed is nothing, if so exit timer application 
			if (IsNothing(stbrStatus)) {
				return;
			} else {
				if (IsNothing(stbrStatus.Panels)) {
					return;
				}
			}

			//stbrStatus.Panels.Item(CONST_CURR_DATE_TIME).Text = Format(Now, "dd-MMM-yyyy").ToString & ", " & FormatDateTime(Now, DateFormat.LongTime).ToString
			if (stbrStatus.Panels.count > 0) {
				if ((stbrStatus.Panels.count - 1) >= CONST_CURR_DATE_TIME) {
					stbrStatus.Panels.Item(CONST_CURR_DATE_TIME).Text = Format(Now, "dd-MMM-yyyy").ToString + ", " + FormatDateTime(Now, DateFormat.LongTime).ToString;
				}
			}
		//----------------------------

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
		}
	}

	private int TimerInterval {
		get { return intInterval; }
		set { intInterval = Value; }
	}

	#End Region

	#Region " Continuous Communication Timer "

	private void tmr_AutoZero_Elasped(object sender, System.Timers.ElapsedEventArgs e)
	{
		//---------------------------------------------------------------------------
		//Procedure Name	    :   tmr_AutoZero_Elasped
		//Description	    :   To get the Current time
		//Parameters 	    :   
		//Time/Date  	    :   21/01/05
		//Dependencies	    :   
		//Author		        :   M.Kamal
		//Revision		    :   
		//Revision by Person	: 
		//---------------------------------------------------------------------------
		int intAdc;
		double dblCompensatedAdcValue;
		double dblADCValue;

		try {
			//check if form objects passed is nothing, if so exit timer application 
			if (stbrStatus == null) {
				if (tmr_AutoZero.Enabled == true) {
					//tmr_AutoZero.Stop()
				}
				//tmr_AutoZero.Stop()
				mblnTimerCompleted = true;
				return;
			}
			//tmr_AutoZero.Stop()
			//--- 2. Explicitly called to start other event
			if (mblnOtherEvent == true) {
				//If tmr_AutoZero.Enabled = True Then
				//    tmr_AutoZero.Stop()
				//End If
				//tmr_AutoZero.Stop()
				mblnTimerCompleted = true;
				return;
			}

			//--- 1. If timer is still running and second timer instance calls again 
			if (mblnTimerCompleted == false) {
				return;
			}

			mblnTimerCompleted = false;

			//--- Display current date and time
			subDisplayCurrDateTime();

			//--- call the interface to set the variable
			Confirm();

			mblnTimerCompleted = true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
		}

	}

	public void subTimerStop()
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   subTimerStop
		//Description	    :   To stop the clock
		//Parameters 	    :   
		//Time/Date  	    :   21/01/05
		//Dependencies	    :   
		//Author		        :   M.Kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		long lngTimer1;
		long lngTimer2;

		try {
			Application.DoEvents();
			mblnOtherEvent = true;
			lngTimer1 = System.DateTime.Now.Ticks / 10000;
			//Or mblnTimerStop = True
			while (!(mblnTimerCompleted == true)) {
				//--- check for the time interval if greater than 500 mseconds then exit
				Application.DoEvents();
				lngTimer2 = System.DateTime.Now.Ticks / 10000;

				if (((lngTimer2 - lngTimer1) > 60000) | mblnTimerCompleted == true) {
					break; // TODO: might not be correct. Was : Exit Do
				}
				Application.DoEvents();
			}
			Application.DoEvents();
			tmr_AutoZero.Stop();
			tmr_AutoZero.Enabled = false;
			Application.DoEvents();
			tmr_AutoZero.Enabled = false;

		} catch (Exception ex) {
			//---------------------------------------------------------
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
		}
	}

	public void subTimerStart(ref System.Object objStatusBar)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   subTimerStart
		//Description	    :   Start the Timer routine again
		//Parameters 	    :   None 
		//Time/Date  	    :   21/01/05
		//Dependencies	    :   
		//Author		        :   M.kamal
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		try {
			mblnOtherEvent = false;
			//mblnTimerStop = False

			//------ modified by Rahul B. 29/03/06------
			//------ On main screen actual time wont get updated. object of status
			//------ bar gets destroyed somewhere so reinitialise object of status 
			//------ bar with main screen status bar.
			if (!objStatusBar == null) {
				stbrStatus = objStatusBar;
				//------ modified by Rahul B. 29/03/06------
				if (tmr_AutoZero.Enabled == false) {
					mblnTimerStop = false;
					tmr_AutoZero.Interval = intInterval;
					tmr_AutoZero.Start();
				}
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
		}

	}

	#End Region
	#Region " Public property "
	public bool TimerStatus {
		get {
			if (!tmr_AutoZero == null) {
				return tmr_AutoZero.Enabled;
			}
		}
	}



	#End Region
	#Region " Public functions "

	public void IConfirmable.Confirm()
	{
		//--- Interface object 
		try {
			mblnTimerCompleted = true;
			Application.DoEvents();
		//----------------------------

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
		}

	}

	public void subTime_Delay(long lngTimeInMSeconds)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name:    subTime_Delay
		//Description:       To generate delay between two successive REad or Write Oerations
		//Parameters :       Time in MiliSeconds, ConstManipulate = 10000 to get time in milliseconds
		//Time/Date  :       3.33 13 oct 2003
		//Dependencies:      Its all depend On God ... if he supplies ticks, delay works else we have manipulated it to make it work
		//Author:            Mandar
		//Revision:
		//Revision by Person:Santosh
		//--------------------------------------------------------------------------------------
		long lngTimeDelay;
		long lng;
		long lng1;
		Int16 intCount;
		long ConstManipulate = 10000;
		// this will manipulate tick count for each mili second

		//Note: Ticks are being calculated at the interval of 100 nano seconds hence calculated the factor to be devided as 10000

		try {
			lngTimeDelay = (long)System.DateTime.Now.Ticks / ConstManipulate;
			lngTimeInMSeconds = lngTimeDelay + lngTimeInMSeconds;

			while (lngTimeDelay < lngTimeInMSeconds) {
				//--- This loop will execute until the delay condition gets satisfied
				//For intCount = 1 To 100
				//intCount = intCount + 1
				//Next
				Application.DoEvents();
				lngTimeDelay = (long)System.DateTime.Now.Ticks / ConstManipulate;
				//lng1 = lngTimeInMSeconds - GetTickCount()
				Application.DoEvents();
			}
		//added and commented by kamal on 19March2004
		//----------------------------
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

}

public interface IConfirmable
{
	void Confirm();
}
