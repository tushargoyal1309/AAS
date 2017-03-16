//**********************************************************************
// File Header       :   clsMessageHandler
// File Name 		:   clsMessageHandler.vb
// Author			:   Mangesh Shardul
// Date/Time			:   12-Sep-2004 8:00 pm
// Description		:   Class to provide the common messages to different
//                       application modes and different files. 
//                       All the messages and their types are stored in 
//                       one central location (database) and they retrieved 
//                       by their respective message ids
//Assumptions        :	All the messages are stored in the database.
//Dependencies       :   

//Properties         :   1.	MessageID as Long
//                       2.	ModuleID as Integer
//                       3.	MessageType as enumMessageType
//                       4.	MessageTitle as String
//                       5.	MessageText as String
//                       6.	FileName as String
//                       7.	ErrorNumber as long

//Enumerated Constants/Structures:
//                       1.	EnumMessageType
//                       2.	


//Functions:             1.	GetMessage (ByVal MessageID as Long) as DataRow
//                       2.  ShowMessage(MessageTitle,MessageText,MessageType) as Boolean
//                       2.	GetMessageType (ByVal MessageID as Long) as String
//                       3.	SaveMessage (ByVal MessageType, ByVal MessageTitle as String, ByVal MessageText as String, ModuleID as integer, ByVal Filename as String) as Boolean
//                       4.  GetMessageByErrorNumber (ByVal ErrorNumber as long, ByVal MessageID as Long) as DataRow
//**********************************************************************

[Serializable()]
public class clsMessageHandler : IDisposable
{

	#Region " Enumerated Constants "

	private enum enumMessageType
	{
		InformativeMessage = 1,
		WarningMessage = 2,
		QuestionMessage = 3,
		ErrorMessage = 4,
		SystemMessage = 5,
		UnExpectedMessage = 6
	}

	#End Region

	#Region " Class Variables "

	private long mMessageID;
	private int mModuleID;
	private enumMessageType mMessageType;
	private string mMessageTitle;
	private string mMessageText;
	private string mFileName;

	private string mApplicationPath;

	private Drawing.ContentAlignment mintMessageTextAlignment;

	public string MessageWindowCaption = "Color Analysis";
	#End Region

	#Region " Public Properties "

	public long MessageID {
		get { return mMessageID; }
		set { mMessageID = Value; }
	}

	public int ModuleID {
		get { return mModuleID; }
		set { mModuleID = Value; }
	}

	public enumMessageType MessageType {
		get { return mMessageType; }
		set { mMessageType = Value; }
	}

	public string MessageTitle {
		get { return mMessageTitle; }
		set { mMessageTitle = Value; }
	}

	public string MessageText {
		get { return mMessageText; }
		set { mMessageText = Value; }
	}

	public string FileName {
		get { return mFileName; }
		set { mFileName = Value; }
	}

	public string ApplicationPath {
		get { return mApplicationPath; }
		set { mApplicationPath = Value; }
	}

	public Drawing.ContentAlignment MessageTextAlignment {
		get { return mintMessageTextAlignment; }
		set { mintMessageTextAlignment = Value; }
	}

	#End Region

	#Region " Public Functions "

	public clsMessageHandler()
	{
		base.@new();
		InitializeSetting();
		mintMessageTextAlignment = Drawing.ContentAlignment.MiddleCenter;
	}

	public clsMessageHandler(long lngMsgId, string strMsgTitle, string strMsgText, int intMode, string strMsgType, string strFileName)
	{
		//=====================================================================
		// Procedure Name        : New [Constructor]
		// Parameters Passed     : Unique Id of the message.
		// Returns               : Row containing all Message properties
		// Purpose               : To retrieve the message from Message Class Object.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 12-Sep-2004 08:30 pm
		// Revisions             : 
		//=====================================================================
		try {
			InitializeSetting();

			this.MessageID = lngMsgId;
			this.MessageTitle = strMsgTitle;
			this.MessageText = strMsgText;
			this.ModuleID = intMode;
			this.FileName = strFileName;

			mintMessageTextAlignment = Drawing.ContentAlignment.MiddleCenter;

			this.MessageType = funFindMessageTypeNo(strMsgType);

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

	public bool GetMessage(DataRow objDtRowMessage, ref clsMessageHandler objMessageHandlerIn)
	{
		//=====================================================================
		// Procedure Name        : GetMessage
		// Parameters Passed     : DataRow containing Message Info 
		// Returns               : An object of MessageHandler with all properties set
		// Purpose               : To get the message info
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 12-Sep-2004 09:00 pm
		// Revisions             : 
		//=====================================================================

		//=====================================================================
		// Description explaning the steps followed: 
		// 1. Accept DataRow containing Message data which would had been filled
		//    in the MessageAdapter Class from DataBase.
		// 2. Check the DataRow contains proper values.
		// 3. Construct an object of MessageHandler.
		// 4. Return this object to calling function.
		//=====================================================================
		long lngMsgId;
		int intMode;
		//Dim intMsgType As Integer
		string strMsgType;
		string strMsgTitle;
		string strMsgText;
		string strFileName;

		try {
			// 1. Accept DataRow containing Message data which would had been filled
			//    in the MessageAdapter Class from DataBase.
			// 2. Check the DataRow contains proper values.
			if (!objDtRowMessage.IsNull("MessageID")) {
				lngMsgId = objDtRowMessage.Item("MessageID");
			} else {
				throw new Exception("The Field MessageID in Table MessageInfo is Null.");
			}

			if (!objDtRowMessage.IsNull("ModuleID")) {
				intMode = objDtRowMessage.Item("ModuleID");
			} else {
				throw new Exception("The field ModuleID in Table MessageInfo is Null.");
			}

			if (!objDtRowMessage.IsNull("MessageType")) {
				strMsgType = objDtRowMessage.Item("MessageType");
			} else {
				throw new Exception("The field MessageType in Table MessageInfo is Null.");
			}

			if (!objDtRowMessage.IsNull("MessageTitle")) {
				strMsgTitle = objDtRowMessage.Item("MessageTitle");
			} else {
				throw new Exception("The field MessageTitle in Table MessageInfo is Null.");
			}

			if (!objDtRowMessage.IsNull("MessageText")) {
				strMsgText = objDtRowMessage.Item("MessageText");
			} else {
				throw new Exception("The field MessageText in Table MessageInfo is Null.");
			}

			if (!objDtRowMessage.IsNull("FileName")) {
				strFileName = objDtRowMessage.Item("FileName");
			} else {
				throw new Exception("The field FileName in Table MessageInfo is Null.");
			}

			// 3. Construct an object of MessageHandler.
			//'Dim objMessageHandler As clsMessageHandler
			//'objMessageHandlerIn = New clsMessageHandler(lngMsgId, strMsgTitle, strMsgText, intMode, strMsgType, strFileName)
			objMessageHandlerIn.MessageID = lngMsgId;
			objMessageHandlerIn.MessageTitle = strMsgTitle;
			objMessageHandlerIn.MessageText = strMsgText;
			objMessageHandlerIn.ModuleID = intMode;
			objMessageHandlerIn.MessageType = funFindMessageTypeNo(strMsgType);
			objMessageHandlerIn.FileName = strFileName;

			// 4. Return this object to calling function.
			return true;

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

	public bool ShowMessage(string strMessageTitle, string strMessageText, enumMessageType MessageType, bool IsSmallMessageRequired = false, bool IsOkAndCancelButtonsRequired = false)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   ShowMessage
		//Description	    :   To show the formated message 
		//Parameters 	    :   MessageTitle, MessageText, MessageType
		//Time/Date  	    :   13-Sep-2004 08:00 pm
		//Dependencies	    :   
		//Author		        :   Mangesh Shardul
		//Revision		    :   1
		//--------------------------------------------------------------------------------------
		bool blnFalg = false;
		frmMessage objfrmMessage;

		try {
			objfrmMessage = new frmMessage();

			if (IsOkAndCancelButtonsRequired == true) {
				objfrmMessage.cmdyes.Text = "OK";
				objfrmMessage.cmdno.Text = "Cancel";
			}
			//***********************************************************
			//Changed by saurabh for adding control box on message handler form.
			//objfrmMessage.Office2003Header.TitleText = MessageWindowCaption 
			objfrmMessage.Text = MessageWindowCaption;
			//Saurabh on 29 May 2007
			//***********************************************************

			if (IsSmallMessageRequired == false) {
				objfrmMessage.lblMessage.TextAlign = this.MessageTextAlignment;
			} else {
				objfrmMessage.lblMessage.TextAlign = Drawing.ContentAlignment.MiddleCenter;
				objfrmMessage.Width = 350;
				objfrmMessage.Height = 150;
				objfrmMessage.lblMessage.Width = 270;
			}


			objfrmMessage.lblMessage.Text = strMessageText;
			objfrmMessage.Office2003HeaderSubMessage.TitleText = strMessageTitle;

			//objfrmMessage.CustomPanelBackground.BringToFront()
			//objfrmMessage.Office2003Header.SendToBack()

			if (IsNothing(objfrmMessage.ImgLstMessage) == false) {
				if (objfrmMessage.ImgLstMessage.Images.Count == 0) {
					subLoadImages(objfrmMessage.ImgLstMessage);
				}
			} else {
				objfrmMessage.ImgLstMessage = new Windows.Forms.ImageList();
			}

			switch (MessageType) {
				case enumMessageType.InformativeMessage:
					//=====================================================================
					// Case For INFORMATIVE Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0);
					}
					objfrmMessage.cmdok.Visible = true;
					objfrmMessage.cmdyes.Visible = false;
					objfrmMessage.cmdno.Visible = false;

					if (objfrmMessage.ShowDialog() == Windows.Forms.DialogResult.OK) {
						blnFalg = true;
					} else {
						blnFalg = false;

					}
				//=====================================================================

				case enumMessageType.WarningMessage:
					//=====================================================================
					// Case For WARNING Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1);
					}
					objfrmMessage.cmdok.Visible = true;
					objfrmMessage.cmdyes.Visible = false;
					objfrmMessage.cmdno.Visible = false;

					if (objfrmMessage.ShowDialog == Windows.Forms.DialogResult.OK) {
						blnFalg = true;
					} else {
						blnFalg = false;
					}
				//=====================================================================

				case enumMessageType.QuestionMessage:
					//=====================================================================
					// Case For QUESTION Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(2);
					}
					objfrmMessage.cmdok.Visible = false;
					objfrmMessage.cmdyes.Visible = true;
					objfrmMessage.cmdno.Visible = true;

					if (objfrmMessage.ShowDialog == Windows.Forms.DialogResult.Yes) {
						blnFalg = true;
					} else {
						blnFalg = false;
					}
				//=====================================================================

				case enumMessageType.ErrorMessage:
					//=====================================================================
					// Case For ERROR Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(3);
					}
					objfrmMessage.cmdok.Visible = true;
					objfrmMessage.cmdyes.Visible = false;
					objfrmMessage.cmdno.Visible = false;

					if (objfrmMessage.ShowDialog == Windows.Forms.DialogResult.OK) {
						blnFalg = true;
					} else {
						blnFalg = false;
					}
				//=====================================================================

				case enumMessageType.SystemMessage:
					//=====================================================================
					// Case For SYSTEM (O.S.) Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(4);
					}
					objfrmMessage.cmdok.Visible = true;
					objfrmMessage.cmdyes.Visible = false;
					objfrmMessage.cmdno.Visible = false;

					if (objfrmMessage.ShowDialog == Windows.Forms.DialogResult.OK) {
						blnFalg = true;
					} else {
						blnFalg = false;
					}
				//=====================================================================

				case enumMessageType.UnExpectedMessage:
					//=====================================================================
					// Case For UNEXPECTED Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(5);
					}
					objfrmMessage.cmdok.Visible = true;
					objfrmMessage.cmdyes.Visible = false;
					objfrmMessage.cmdno.Visible = false;

					if (objfrmMessage.ShowDialog == Windows.Forms.DialogResult.OK) {
						blnFalg = true;
					} else {
						blnFalg = false;
					}
				//=====================================================================
			}

			objfrmMessage.Dispose();
			objfrmMessage = null;

			return blnFalg;

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

	public frmMessage ShowStatusMessageBox(string strMessageText, string strMessageTitle, MessageHandler.clsMessageHandler.enumMessageType intMessageType, bool IsSmallMessageRequired = false)
	{
		//-----------------------------------------------------------------
		//Procedure Name	    :   ShowStatusMessageBox
		//Description	    :   To allow message window to auto close
		//Parameters 	    :   true or false
		//Time/Date  	    :   24-Dec-2006 02:30 pm
		//Dependencies	    :   
		//Author		        :   Mangesh Shardul
		//Revision		    :   1
		//-----------------------------------------------------------------
		frmMessage objfrmMessage;

		try {
			objfrmMessage = new frmMessage();

			//objfrmMessage.lblMessage.TextAlign = Me.MessageTextAlignment
			if (IsSmallMessageRequired == false) {
				objfrmMessage.lblMessage.TextAlign = this.MessageTextAlignment;
			} else {
				objfrmMessage.lblMessage.TextAlign = Drawing.ContentAlignment.MiddleCenter;
				objfrmMessage.Width = 350;
				objfrmMessage.Height = 150;
				objfrmMessage.lblMessage.Width = 270;
			}

			objfrmMessage.lblMessage.Text = strMessageText;

			//objfrmMessage.Office2003Header.TitleText = MessageWindowCaption

			objfrmMessage.Office2003HeaderSubMessage.TitleText = strMessageTitle;

			//objfrmMessage.CustomPanelBackground.BringToFront()
			//objfrmMessage.Office2003Header.SendToBack()

			if (IsNothing(objfrmMessage.ImgLstMessage) == false) {
				if (objfrmMessage.ImgLstMessage.Images.Count == 0) {
					subLoadImages(objfrmMessage.ImgLstMessage);
				}
			} else {
				objfrmMessage.ImgLstMessage = new Windows.Forms.ImageList();
			}

			objfrmMessage.cmdok.Visible = false;
			objfrmMessage.cmdyes.Visible = false;
			objfrmMessage.cmdno.Visible = false;

			switch (intMessageType) {
				case enumMessageType.InformativeMessage:
					//=====================================================================
					// Case For INFORMATIVE Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0);
					}
				//=====================================================================

				case enumMessageType.WarningMessage:
					//=====================================================================
					// Case For WARNING Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1);
					}
				//=====================================================================

				case enumMessageType.QuestionMessage:
					//=====================================================================
					// Case For QUESTION Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(2);
					}
				//=====================================================================

				case enumMessageType.ErrorMessage:
					//=====================================================================
					// Case For ERROR Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(3);
					}
				//=====================================================================

				case enumMessageType.SystemMessage:
					//=====================================================================
					// Case For SYSTEM (O.S.) Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(4);
					}
				//=====================================================================

				case enumMessageType.UnExpectedMessage:
					//=====================================================================
					// Case For UNEXPECTED Message Type
					//=====================================================================
					if (!objfrmMessage.ImgLstMessage.Images.Count == 0) {
						objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(5);
					}
				//=====================================================================
			}

			return objfrmMessage;

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

	public void CloseStatusMessageBox(frmMessage objfrmMessage)
	{
		if (!IsNothing(objfrmMessage)) {
			objfrmMessage.Close();
			objfrmMessage.Dispose();
			objfrmMessage = null;
		}
	}

	public void UpdateStatusMessageBox(ref frmMessage objfrmMessage, string strNewMessage, string strNewCaption)
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
			if (!IsNothing(objfrmMessage)) {
				objfrmMessage.lblMessage.Text = strNewMessage;
				objfrmMessage.Office2003HeaderSubMessage.TitleText = strNewCaption;

				objfrmMessage.lblMessage.Refresh();
				objfrmMessage.Office2003HeaderSubMessage.Refresh();
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

	private int funFindMessageTypeNo(string strMsgTypeIn)
	{
		int intMsgTypeNumber;

		switch (strMsgTypeIn) {
			case "InformativeMessage":

				intMsgTypeNumber = 1;
			case "WarningMessage":

				intMsgTypeNumber = 2;
			case "QuestionMessage":

				intMsgTypeNumber = 3;
			case "ErrorMessage":

				intMsgTypeNumber = 4;
			case "SystemMessage":

				intMsgTypeNumber = 5;
			case "UnExpectedMessage":

				intMsgTypeNumber = 6;
		}

		return intMsgTypeNumber;

	}

	private void subLoadImages(ref Windows.Forms.ImageList ImgLstMessage)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   funcLoadImages
		//Description	    :   to load the bitmap as Icons in MessageBox form
		//Parameters 	    :   None
		//Time/Date  	    :   03-Oct-2004 04:15
		//Dependencies	    :   
		//Author		        :   Mangesh Shardul
		//Revision		    :   
		//Revision by Person	:   
		//--------------------------------------------------------------------------------------
		string strFilePath;
		Drawing.Icon objIconInfo;
		Drawing.Icon objIconWarn;
		Drawing.Icon objIconQue;
		Drawing.Icon objIconErr;
		Drawing.Icon objIconSys;
		Drawing.Icon objIconUnex;

		try {
			strFilePath = mApplicationPath + "\\MessageHandler";

			objIconInfo = new Drawing.Icon(strFilePath + "\\MSGBOX04.ico");
			objIconWarn = new Drawing.Icon(strFilePath + "\\MSGBOX01.ico");
			objIconQue = new Drawing.Icon(strFilePath + "\\MSGBOX02.ico");
			objIconErr = new Drawing.Icon(strFilePath + "\\MSGBOX03.ico");
			objIconSys = new Drawing.Icon(strFilePath + "\\W95MBX01.ico");
			objIconUnex = new Drawing.Icon(strFilePath + "\\W95MBX01.ico");

			ImgLstMessage.Images.Clear();
			ImgLstMessage.Images.Add(objIconInfo);
			ImgLstMessage.Images.Add(objIconWarn);
			ImgLstMessage.Images.Add(objIconQue);
			ImgLstMessage.Images.Add(objIconErr);
			ImgLstMessage.Images.Add(objIconSys);
			ImgLstMessage.Images.Add(objIconUnex);

			return;

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

	#Region " Commented Code "

	///    Public Function SaveMessage(ByVal lngMessageID As Long, ByVal strMessageType As String, ByVal strMessageTitle As String, _
	///                                ByVal strMessageText As String, ByVal intModuleID As Integer, _
	///                                ByVal strFilename As String) As Boolean
	///        '=====================================================================
	///        ' Procedure Name        : SaveMessage
	///        ' Parameters Passed     : Message Id, Title of the message, Message Text, 
	///        '                         Id of the Module, File name
	///        ' Returns               : True if successful; false otherwise 
	///        ' Purpose               : To save the message in the database.
	///        ' Description           : 
	///        ' Assumptions           : 
	///        ' Dependencies          : 
	///        ' Author                : Mangesh Shardul
	///        ' Created               : 12-Sep-2004 12:30 pm
	///        ' Revisions             : 
	///        '=====================================================================
	///        Try
	///            'If gobjDataAccess.SaveMessageInfo(lngMessageID, strMessageTitle, strMessageText, intModuleID, strMessageType) Then
	///            '    Return True
	///            'Else
	///            '    Return False
	///            'End If

	///        Catch ex As Exception
	///            '---------------------------------------------------------
	///            'Error Handling and logging
	///            gobjErrorHandler.ErrorDescription = ex.Message
	///            gobjErrorHandler.ErrorMessage = ex.Message
	///            gobjErrorHandler.WriteErrorLog(ex)
	///            '---------------------------------------------------------
	///            Return False
	///        Finally
	///            '---------------------------------------------------------
	///            'Writing Execution log
	///            If CONST_CREATE_EXECUTION_LOG = 1 Then
	///                gobjErrorHandler.WriteExecutionLog()
	///            End If
	///            '---------------------------------------------------------
	///        End Try

	///    End Function

	///    Public Function SaveMessageObject(ByVal objMessageInfoIn As clsMessageHandler) As Boolean
	///        '=====================================================================
	///        ' Procedure Name        : SaveMessageObject
	///        ' Parameters Passed     : An object of MessageHandler Class
	///        ' Returns               : True if successful; false otherwise 
	///        ' Purpose               : To save the message info in the database.
	///        ' Description           : 
	///        ' Assumptions           : 
	///        ' Dependencies          : 
	///        ' Author                : Mangesh Shardul
	///        ' Created               : 12-Sep-2004 03:30 pm
	///        ' Revisions             : 
	///        '=====================================================================
	///        Dim lngMsgId As Long
	///        Dim strMsgTitle As String
	///        Dim strMsgText As String
	///        Dim intMode As Integer
	///        Dim intMsgType As Integer

	///        Try
	///            lngMsgId = objMessageInfoIn.MessageID
	///            strMsgTitle = objMessageInfoIn.MessageTitle
	///            strMsgText = objMessageInfoIn.MessageText
	///            intMode = objMessageInfoIn.ModuleID
	///            intMsgType = objMessageInfoIn.MessageType

	///            'If gobjDataAccess.SaveMessageInfo(lngMsgId, strMsgTitle, strMsgText, intMode, intMsgType) Then
	///            '    Return True
	///            'Else
	///            '    Return False
	///            'End If

	///        Catch ex As Exception
	///            '---------------------------------------------------------
	///            'Error Handling and logging
	///            gobjErrorHandler.ErrorDescription = ex.Message
	///            gobjErrorHandler.ErrorMessage = ex.Message
	///            gobjErrorHandler.WriteErrorLog(ex)
	///            '---------------------------------------------------------
	///            Return False
	///        Finally
	///            '---------------------------------------------------------
	///            'Writing Execution log
	///            If CONST_CREATE_EXECUTION_LOG = 1 Then
	///                gobjErrorHandler.WriteExecutionLog()
	///            End If
	///            '---------------------------------------------------------
	///        End Try

	///    End Function

	///    Public Function SaveErrorMessage(ByVal lngErrNum As Long, _
	///                             ByVal strErrDesc As String) As Boolean
	///        '=====================================================================
	///        ' Procedure Name        : SaveErrorMessage
	///        ' Parameters Passed     : Error No, Error Description
	///        ' Returns               : True if successful; false otherwise 
	///        ' Purpose               : To save the Error No and their Descriptions in the database.
	///        ' Description           : 
	///        ' Assumptions           : 
	///        ' Dependencies          : 
	///        ' Author                : Mangesh Shardul
	///        ' Created               : 10-Sep-2004 3:30 pm
	///        ' Revisions             : 
	///        '=====================================================================

	///        Dim ConnStatus As Boolean
	///        Dim strQuery As String
	///        Dim IniDataList As New DataTable

	///        Try
	///            'gobjDataAccess.SaveErrorInfo(lngErrNum, strErrDesc)

	///        Catch ex As Exception
	///            '---------------------------------------------------------
	///            'Error Handling and logging
	///            gobjErrorHandler.ErrorDescription = ex.Message
	///            gobjErrorHandler.ErrorMessage = ex.Message
	///            gobjErrorHandler.WriteErrorLog(ex)
	///            '---------------------------------------------------------
	///            Return Nothing
	///        Finally
	///            '---------------------------------------------------------
	///            'Writing Execution log
	///            If CONST_CREATE_EXECUTION_LOG = 1 Then
	///                gobjErrorHandler.WriteExecutionLog()
	///            End If
	///            '---------------------------------------------------------
	///        End Try

	///    End Function

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
		// Date/Time			: 02-Nov-2004 01:25 pm
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
