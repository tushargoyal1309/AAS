//**********************************************************************
// File Header       :   clsMessageAdapter
// File Name 		:   clsMessageAdapter.vb
// Author			:   Mangesh Shardul
// Date/Time			:   13-Sep-2004 04:20 am
// Description		:   Class to provide the communication between application layer
//                       and MessageHandler Class (in DLL)
//                       To retrieve Messages from Database as per DataAccess Layer
//                       object defined in the Application Layer.
//Assumptions        :	All the messages are stored in the database.
//Dependencies       :   i.  Depends on DataAccessLayer class to retreive message
//                           from database. 
//                       ii. The global object of clsDataAccessLayer wiil be used.
//                       iii.An object of MessageHandler class 
//                           (Reference to Class Library of MessageHandler.dll)

//Properties         :   1.	mobjMessageHandler as MessageHandler.clsMessageHandler
//                       2.	
//                       3.	
//                       4.	


//Enumerated Constants/Structures:
//                       1.	
//                       2.	


//Functions:             1.	GetMessage (ByVal MessageID as Long) as DataRow
//                       2.	
//                       3.	
//                       4.  
//**********************************************************************

public class clsMessageAdapter : IDisposable
{

	#Region " Class Variables "

	//---Class Level object for Message Handling operations.
	private MessageHandler.clsMessageHandler mobjMessageHandler;
	private MessageHandler.frmMessage mobjStatusMessageBox;

	private ContentAlignment mintMessageTextAlignment;
	#End Region

	#Region " Public Properties "

	public ContentAlignment MessageTextAlignment {
		get { return mintMessageTextAlignment; }
		set { mintMessageTextAlignment = Value; }
	}

	#End Region

	#Region " Public Functions "

	public clsMessageAdapter()
	{
		//=====================================================================
		// Procedure Name        : New
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : Constructor
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Sep-2004 05:00 pm
		// Revisions             : 
		//=====================================================================
		mobjMessageHandler = new MessageHandler.clsMessageHandler();
		mobjMessageHandler.MessageWindowCaption = gstrTitleInstrumentType;
		mintMessageTextAlignment = ContentAlignment.MiddleCenter;
	}

	public bool GetMessage(long lngMessageId, ref MessageHandler.clsMessageHandler objMessageHandlerIn)
	{
		//=====================================================================
		// Procedure Name        : GetMessage
		// Parameters Passed     : Unique Id of the message.
		// Returns               : The Global Object of MessageHandler with Message Info
		// Purpose               : To retrieve the message from database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : Global Object of MessageHandler
		// Author                : Mangesh Shardul
		// Created               : 13-Sep-2004 05:00 pm
		// Revisions             : 
		//=====================================================================
		DataRow objMessageDataRow;
		try {
			//=====================================================================
			// Description explaning the steps followed: 
			// 1. using global object of clsDataAccessLayer get the message data
			//    from database
			// 2. return the DataRow for that found Message ID
			// 3. Pass this DataRow to MessageHandler class' GetMessage
			// 4. Return the global object of MessageHandler with Message Info.
			//=====================================================================
			objMessageDataRow = gobjDataAccess.GetMessage(lngMessageId);

			objMessageHandlerIn.GetMessage(objMessageDataRow, objMessageHandlerIn);

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	public bool ShowMessage(long lngMessageID, bool IsOkAndCancelButtonsRequired = false)
	{
		//=====================================================================
		// Procedure Name        : ShowMessage
		// Parameters Passed     : Unique Id of the message.
		// Returns               : Displays the Message Form with Message
		//                         and returns DialogResult
		// Purpose               : To show the message stored in database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : Global Object of MessageHandler
		// Author                : Mangesh Shardul
		// Created               : 03-Oct-2004 02:30 pm
		// Revisions             : 1
		//=====================================================================
		string strMessageTitle;
		string strMessageText;
		MessageHandler.clsMessageHandler.enumMessageType enumMessageType;

		try {
			mobjMessageHandler.ApplicationPath = Application.StartupPath;

			this.GetMessage(lngMessageID, mobjMessageHandler);

			strMessageTitle = mobjMessageHandler.MessageTitle;
			strMessageText = mobjMessageHandler.MessageText;
			enumMessageType = mobjMessageHandler.MessageType;

			mobjMessageHandler.MessageTextAlignment = this.MessageTextAlignment;

			mobjMessageHandler.MessageWindowCaption = gstrTitleInstrumentType;

			if (mobjMessageHandler.ShowMessage(strMessageTitle, strMessageText, enumMessageType, false, IsOkAndCancelButtonsRequired)) {
				return true;
			} else {
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mintMessageTextAlignment = ContentAlignment.MiddleCenter;
			mobjMessageHandler.MessageTextAlignment = ContentAlignment.MiddleCenter;
			//---------------------------------------------------------
		}
	}

	public bool ShowMessage(string MessageText, string MessageTitle, MessageHandler.clsMessageHandler.enumMessageType enumMessageType, bool IsSmallMessageRequired = false, bool IsOkAndCancelButtonsRequired = false)
	{
		//=====================================================================
		// Procedure Name        : ShowMessage
		// Parameters Passed     : User-Defined Message String and Title.
		// Returns               : Displays the Message Form with Message
		//                         and returns DialogResult
		// Purpose               : To show the message stored in database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : Global Object of MessageHandler
		// Author                : Mangesh Shardul
		// Created               : 03-Oct-2006 12:20 pm
		// Revisions             : 1
		//=====================================================================
		try {
			mobjMessageHandler.MessageWindowCaption = gstrTitleInstrumentType;

			mobjMessageHandler.MessageTextAlignment = this.MessageTextAlignment;

			if (mobjMessageHandler.ShowMessage(MessageTitle, MessageText, enumMessageType, IsSmallMessageRequired, IsOkAndCancelButtonsRequired)) {
				return true;
			} else {
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mintMessageTextAlignment = ContentAlignment.MiddleCenter;
			mobjMessageHandler.MessageTextAlignment = ContentAlignment.MiddleCenter;
			//---------------------------------------------------------
		}
	}

	public bool ShowStatusMessageBox(string strMessageText, string strMessageTitle, MessageHandler.clsMessageHandler.enumMessageType intMessageType, int intWaitForMilliSeconds, bool IsSmallMessageRequired = false)
	{
		//=====================================================================
		// Procedure Name        : ShowStatusMessageBox
		// Parameters Passed     : User-Defined Message String and Title.
		//                       : intWaitForMilliSeconds as show for message for that sec. 
		//                       : optional IsSmallMessageRequired shows message in small window
		// Returns               : Displays the Message Form with Message
		//                         and returns DialogResult
		// Purpose               : To show the message stored in database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : Global Object of MessageHandler
		// Author                : Mangesh Shardul
		// Created               : 03-Oct-2006 12:20 pm
		// Revisions             : 1
		//=====================================================================
		clsTimer objclsTimer;

		try {
			mobjMessageHandler.MessageTextAlignment = this.MessageTextAlignment;

			mobjStatusMessageBox = mobjMessageHandler.ShowStatusMessageBox(strMessageText, strMessageTitle, intMessageType, IsSmallMessageRequired);
			mobjStatusMessageBox.ShowInTaskbar = false;
			objclsTimer = new clsTimer(null, intWaitForMilliSeconds);
			//mobjStatusMessageBox.TopMost = True
			mobjStatusMessageBox.Show();

			objclsTimer.subTime_Delay(intWaitForMilliSeconds);

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			mintMessageTextAlignment = ContentAlignment.MiddleCenter;
			mobjMessageHandler.MessageTextAlignment = ContentAlignment.MiddleCenter;
			objclsTimer = null;
			//---------------------------------------------------------
		}
	}

	public void CloseStatusMessageBox()
	{
		mobjMessageHandler.CloseStatusMessageBox(mobjStatusMessageBox);
	}

	public void UpdateStatusMessageBox(string strNewMessage, string strNewCaption)
	{
		//=====================================================================
		// Procedure Name        : UpdateStatusMessageBox
		// Parameters Passed     : New Message Text and Caption
		// Returns               : None
		// Purpose               : To update the Message Text of a Status MsgBox
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 25-Jan-2007 03:40 pm
		// Revisions             : 1
		//=====================================================================
		try {
			//--- update the Message Text of a Status MsgBox
			if (!IsNothing(mobjStatusMessageBox)) {
				mobjMessageHandler.UpdateStatusMessageBox(mobjStatusMessageBox, strNewMessage, strNewCaption);
			}

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

	#Region " Private functions "

	private bool SaveMessage(long lngMessageID, string strMessageType, string strMessageTitle, string strMessageText, int intModuleID, string strFilename)
	{
		//=====================================================================
		// Procedure Name        : SaveMessage
		// Parameters Passed     : Message Id, Title of the message, Message Text, 
		//                         Id of the Module, File name
		// Returns               : True if successful; false otherwise 
		// Purpose               : To save the message in the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 12-Sep-2004 12:30 pm
		// Revisions             : 
		//=====================================================================
		try {
			//--- save the message in the database.
			if (gobjDataAccess.SaveMessageInfo(lngMessageID, strMessageTitle, strMessageText, intModuleID, strMessageType, strFilename)) {
				return true;
			} else {
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}


	private bool SaveMessageObject(MessageHandler.clsMessageHandler objMessageInfoIn)
	{
		//=====================================================================
		// Procedure Name        : SaveMessageObject
		// Parameters Passed     : An object of MessageHandler Class
		// Returns               : True if successful; false otherwise 
		// Purpose               : To save the message info in the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 12-Sep-2004 03:30 pm
		// Revisions             : 
		//=====================================================================
		long lngMsgId;
		string strMsgTitle;
		string strMsgText;
		int intMode;
		int intMsgType;
		string strVBFileName = "";

		try {
			lngMsgId = objMessageInfoIn.MessageID;
			strMsgTitle = objMessageInfoIn.MessageTitle;
			strMsgText = objMessageInfoIn.MessageText;
			intMode = objMessageInfoIn.ModuleID;
			intMsgType = objMessageInfoIn.MessageType;
			strVBFileName = objMessageInfoIn.FileName;
			//--- save the message in the database.
			if (gobjDataAccess.SaveMessageInfo(lngMsgId, strMsgTitle, strMsgText, intMode, intMsgType, strVBFileName)) {
				return true;
			} else {
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}


	private bool SaveErrorMessage(long lngErrNum, string strErrDesc)
	{
		//=====================================================================
		// Procedure Name        : SaveErrorMessage
		// Parameters Passed     : Error No, Error Description
		// Returns               : True if successful; false otherwise 
		// Purpose               : To save the Error No and their Descriptions in the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Sep-2004 3:30 pm
		// Revisions             : 
		//=====================================================================

		bool ConnStatus;
		string strQuery;
		DataTable IniDataList = new DataTable();

		try {
			gobjDataAccess.SaveErrorInfo(lngErrNum, strErrDesc);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return null;
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

	#Region " Dispose And Garbage Collection Code "

	private IntPtr Handle;
	//Other managed resource this class uses.
	//Private component As New component
	// Track whether Dispose has been called.

	private bool disposed = false;
	public void System.IDisposable.Dispose()
	{
		//**********************************************************************
		// Procedure Name 	: Dispose
		// Author			: Mangesh Shardul
		// Date/Time			: 02-Nov-2004 01:20 pm
		// Description		: To dispose the objects this class instance
		//**********************************************************************
		Dispose(true);
		// This object will be cleaned up by the Dispose method.
		// Therefore, you should call GC.SupressFinalize to
		// take this object off the finalization queue 
		// and prevent finalization code for this object
		// from executing a second time.
		GC.SuppressFinalize(this);
	}

	// Dispose(bool disposing) executes in two distinct scenarios.
	// If disposing equals true, the method has been called directly
	// or indirectly by a user's code. Managed and unmanaged resources
	// can be disposed.
	// If disposing equals false, the method has been called by the 
	// runtime from inside the finalizer and you should not reference 
	// other objects. Only unmanaged resources can be disposed.
	private void Dispose(bool disposing)
	{
		// Check to see if Dispose has already been called.
		if (!this.disposed) {
			// If disposing equals true, dispose all managed 
			// and unmanaged resources.
			if (disposing) {
				// Dispose managed resources.
				if (!IsNothing(mobjMessageHandler)) {
					mobjMessageHandler.Dispose();
					mobjMessageHandler = null;
				}
			}

			// Call the appropriate methods to clean up 
			// unmanaged resources here.
			// If disposing is false, 
			// only the following code is executed.
			CloseHandle(Handle);
			Handle = IntPtr.Zero;
		}
		disposed = true;

	}

	[System.Runtime.InteropServices.DllImport("Kernel32")]
	private static Boolean CloseHandle(IntPtr handle)
	{
	}

	// This finalizer will run only if the Dispose method 
	// does not get called.
	// It gives your base class the opportunity to finalize.
	// Do not provide finalize methods in types derived from this class.
	protected override void Finalize()
	{
		// Do not re-create Dispose clean-up code here.
		// Calling Dispose(false) is optimal in terms of
		// readability and maintainability.
		Dispose(false);
		base.Finalize();
	}

	#End Region

}
