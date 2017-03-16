using AAS203.Signature;
using AAS203.Common;
using System.Data;
using System.Data.OleDb;


class modGeneralFunctions_21CFR
{
	////----- DECLARE AS GLOBAL DECLARATION
	public OleDb.OleDbConnection gOleDBConnection_LogBook;
	public string gOleDBConnectionString_LogBook;
	public clsDatabaseFunctions gclsDBFunctions = new clsDatabaseFunctions();
	public OleDb.OleDbConnection gOleDBUserInfoConnection;
	public string gOleDBConnectionString_UserInfo;
	//--- Structure used to store the user information for the current
	//--- Session

	public structUserDetails gstructUserDetails;
	//---Structure used to store the User Details logged in
	private struct structUserDetails
	{
		long SessionID;
		string UserName;
		string UserID;
		string UserPassword;
		ArrayList Access;
	}
	////-----
	#Region "Activity Authentication Check"

	public bool funcCheckActivityAuthentication(long lngActivityID, ArrayList arrAccess)
	{
		//=====================================================================
		// Procedure Name        : funcCheckActivityAuthentication
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To check the user anthentication for partic-
		//                       : -ular activity.  
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		OleDb.OleDbDataReader objReaderAccess;
		string strSQL;
		CWaitCursor objWait = new CWaitCursor();

		try {
			//--- Since the administrator has all the authority there is no need for cheking
			//--- Authentications
			if (gstructUserDetails.UserID == 0) {
				return true;
			}

			strSQL = "Select AccessMaster.Suspend From AccessMaster " + "Where AccessMaster.AccessID = " + lngActivityID;

			if (gclsDBFunctions.GetRecords(strSQL, gOleDBUserInfoConnection, objReaderAccess)) {
				while (objReaderAccess.Read) {
					if (Val(Convert.ToInt64(objReaderAccess.Item("Suspend")) + "") == 1) {
						return true;
					}
				}
			}
			objReaderAccess.Close();

			if (arrAccess.Contains(lngActivityID)) {
				return true;
			} else {
				//--- Dispay the message
				gobjMessageAdapter.ShowMessage(gstructUserDetails.UserName + " has no authority granted to access this activity.", "Authentication Check", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				return false;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}
	#End Region

	#Region "Activity/File Log"

	//--------------------------------------------------------
	//    Global functions used to insert into Activity Log and File Log.
	//--- gfuncInsertActivityLog - To Add / Insert a record in Activity Log table.
	//--- gfuncInsertFileLog - To Add / Insert a record in File Log table.

	public bool gfuncGetFileAuthenticationData(ref AAS203.Signature.DigitalSignature obj)
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetFileAuthenticationData
		// Description           :   To Get Digital signature input during File Save if 21CFR is enabled.
		// Purpose               :   To Get Digital signature input during File Save if 21CFR is enabled.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   March, 2003 
		// Revisions             :
		//=====================================================================

		try {
			frmAuthentication frmAuthentication = new frmAuthentication();

			//modified by kamal
			//If gstructUserDetails.UserID = 0 Then
			//    Return True
			//End If
			//-----

			obj.UserID = Convert.ToInt64(gstructUserDetails.UserID);
			obj.UserName = gstructUserDetails.UserName;
			obj.LoginPassword = gstructUserDetails.UserPassword;
			obj.SaveDate = System.DateTime.Today;

			frmAuthentication.subInitialize(obj);
			if (frmAuthentication.ShowDialog() == DialogResult.OK) {
				if (frmAuthentication.RBFile.Checked) {
					frmAuthentication.txtPassword.Focus();
					obj.ActivityType = ENUM_ActivityType.FileAuthentication;
					obj.FilePassword = frmAuthentication.txtPassword.Text;
				} else {
					obj.ActivityType = ENUM_ActivityType.LoginAuthentication;
					obj.FilePassword = gstructUserDetails.UserPassword;
				}
				frmAuthentication.Dispose();
				return true;
			} else {
				frmAuthentication.Dispose();
				return false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	public bool gfuncGetFileAuthenticationData_21CFR_OFF(ref AAS203.Signature.DigitalSignature obj)
	{
		//=====================================================================
		// Procedure Name        :   gfuncGetFileAuthenticationData_21CFR_OFF
		// Description           :   To Get Digital signature input during File Save if 21CFR is Diabled.
		// Purpose               :   To Get Digital signature input during File Save if 21CFR is Diabled.
		// this is to save the file with login Authentication when 21 cfr is disabled
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Nilesh shirode
		// Created               :   28 June 2004
		// Revisions             :
		//=====================================================================


		try {
			obj.UserID = Convert.ToInt64(gstructUserDetails.UserID);
			obj.UserName = gstructUserDetails.UserName;
			obj.LoginPassword = gstructUserDetails.UserPassword;
			obj.SaveDate = System.DateTime.Today;


			obj.ActivityType = ENUM_ActivityType.LoginAuthentication;
			obj.FilePassword = gstructUserDetails.UserPassword;

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	public bool gfuncCheckForFileAuthentication(AAS203.Signature.DigitalSignature objDS)
	{
		//=====================================================================
		// Procedure Name        :   gfuncCheckForFileAuthentication
		// Description           :   To check if the Digital signature passed matches with saved file and not to open file if not.
		// Purpose               :   To check if the Digital signature passed matches with saved file and not to open file if not.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   March, 2003 
		// Revisions             :
		//=====================================================================

		try {
			Int32 intActivityType;

			//---------------------------------------------------------------------------
			//1. Check for the authentication for the user
			//2. Check for Activity type, If Login authentication then, check the password
			//   with the current logged in user's password, If no match than
			//   ask for the password and verify the same.
			//3. If file authentication, then get the password and verify the same.
			//---------------------------------------------------------------------------
			//If gstructUserDetails.UserID = 0 Then
			//    Return True
			//End If

			if (objDS.FilePassword == "") {
				return true;
			}

			frmAuthentication objfrmAuthentication = new frmAuthentication();
			//   Dim objLoginScreen As New frmLoginAuthentication

			objfrmAuthentication.txtPassword.Focus();
			//1. Check for the authentication for the user
			//2. Check for Activity type, If Login authentication then, check the User ID
			//   with the current logged in user's ID, If no match than
			//   ask for the password and verify the same.
			if (objDS.ActivityType == ENUM_ActivityType.LoginAuthentication) {
				//--- Check for UID and password
				if (objDS.UserID == gstructUserDetails.UserID & objDS.LoginPassword == gstructUserDetails.UserPassword) {
					return true;
				} else {
					GetLoginPassword:
					//commented and added by kamal
					//                    '--- Display the login screen
					//GetLogin:
					//                    objLoginScreen = New frmLoginAuthentication
					//                    If objLoginScreen.ShowDialog() = DialogResult.OK Then
					//                        If objLoginScreen.LoginSuccessfull Then
					//                            Return True
					//                        Else
					//                            '--- Display the message for wrong password
					//                            Call gFuncShowMessage("Invalid Password", "Invalid password, Please try again!!!", modConstants.EnumMessageType.Information)
					//                            GoTo GetLogin
					//                        End If
					//                    Else
					//                        Return False
					//                    End If

					//                End If

					//--- The file has a password security
					objfrmAuthentication = new frmAuthentication();
					objfrmAuthentication.subInitialize(objDS);
					objfrmAuthentication.pnlPassword.Visible = true;
					objfrmAuthentication.pnlPassword.Enabled = true;
					objfrmAuthentication.txtPassword.Focus();
					objfrmAuthentication.pnlAuthentication.Enabled = false;

					if (objfrmAuthentication.ShowDialog() == DialogResult.OK) {
						objfrmAuthentication.txtPassword.Focus();
						//--- Check for the password
						if (objDS.FilePassword.ToString == objfrmAuthentication.txtPassword.Text.ToString) {
							return true;
						} else {
							//--- Display the message for wrong password
							gobjMessageAdapter.ShowMessage(constInvalidPassword);
							objfrmAuthentication.txtPassword.Focus();
							goto GetLoginPassword;
						}
					} else {
						return false;
					}
				}
			} else {
				GetPassword:
				//--- The file has a password security
				objfrmAuthentication = new frmAuthentication();
				objfrmAuthentication.subInitialize(objDS);
				objfrmAuthentication.pnlPassword.Visible = true;
				objfrmAuthentication.pnlPassword.Enabled = true;
				objfrmAuthentication.pnlAuthentication.Enabled = false;

				if (objfrmAuthentication.ShowDialog() == DialogResult.OK) {
					objfrmAuthentication.txtPassword.Focus();
					//--- Check for the password
					if (objDS.FilePassword.ToString == objfrmAuthentication.txtPassword.Text.ToString) {
						return true;
					} else {
						//--- Display the message for wrong password
						gobjMessageAdapter.ShowMessage(constInvalidPassword);
						objfrmAuthentication.txtPassword.Focus();
						goto GetPassword;
					}
				} else {
					return false;
				}

			}
			objfrmAuthentication.Dispose();
			//       objLoginScreen.Dispose()
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			//gobjErrorHandler.ProcessError(ErrorHandler.EnumErrorType.Critical, ex)
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

	public long gfuncInsertActivityLog(long Module_ID, string Log_desc, string strPassword = "")
	{
		//=====================================================================
		// Procedure Name        :   gfuncInsertActivityLog
		// Description           :   To Add / Insert a record in Activity Log table.
		// Purpose               :   To Add / Insert a record in Activity Log table.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		string str_sql;
		bool Status;
		OleDbCommand objcommand = new OleDbCommand();
		long Log_ID;
		long Session_ID;
		long User_ID;

		try {
			Session_ID = gstructUserDetails.SessionID;
			User_ID = Convert.ToInt64(gstructUserDetails.UserID);

			Log_ID = gclsDBFunctions.GetNextID("ActivityLog", "ActivityLogID", gOleDBConnection_LogBook);

			if (IsNothing(strPassword)) {
				strPassword = "";
			}
			str_sql = "Insert into ActivityLog " + "(ActivityLogID ,SessionID ,ActivityDateTime ,UserID ,ProcessName ,ModuleID ,PasswordTried)" + " values(?,?,?,?,?,?,?)";

			//--- Providing command object for Infomaster
			 // ERROR: Not supported in C#: WithStatement


			objcommand.Dispose();
			return Log_ID;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	public bool gfuncInsertFileLog(long ActivityLog_ID, string org_file_name, string bck_file_name)
	{
		//=====================================================================
		// Procedure Name        :   gfuncInsertFileLog
		// Description           :   To Add / Insert a record in File Log table.
		// Purpose               :   To Add / Insert a record in File Log table.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2003 
		// Revisions             :
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		string str_sql;
		bool Status;
		OleDbCommand objcommand = new OleDbCommand();
		long FileLog_ID;

		try {
			//Status = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook)
			//If Not (Status) Then
			//    Return False
			//End If

			FileLog_ID = gclsDBFunctions.GetNextID("FileLog", "FileLogID", gOleDBConnection_LogBook);

			str_sql = "Insert into FileLog " + "(FileLogID ,ActivityLogID ,FileName ,FilePath )" + " values(?,?,?,?)";

			//--- Providing command object for Infomaster
			 // ERROR: Not supported in C#: WithStatement


			objcommand.Dispose();
			return true;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	#End Region

	#Region " Public Functions"

	public bool gfuncValidateUser(string user_id, string password)
	{
		//=====================================================================
		// Procedure Name        :   gfuncValidateUser 
		// Description           :   To Validate the User against the Password entered by him.
		// Purpose               :   To Validate the User against the Password entered by him.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   January, 2004
		// Revisions             :   Nilesh Shirode , 11 friday 2004
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		bool result = false;
		string str_sql;
		string str_encryptpass;
		OleDb.OleDbDataReader objReader;
		long password_id;
		int intUserCount;

		try {
			//--- To get encrypted password
			str_encryptpass = gfuncEncryptString(password);

			//--- Generating dynamic query for selection type
			str_sql = "Select PasswordID " + "from Passwords ,Users where Passwords.UserID = " + user_id + " and Passwords.PasswordName = '" + str_encryptpass + "' " + "and Passwords.UserID = Users.UserID and Users.Active = 1 ";

			//result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
			//gOleDBUserInfoConnection = gclsDBFunctions.OpenConnection(CONSTSTR_USERINFORMATION)
			//If Not (result) Then
			//    result = False
			//    Return result
			//End If
			//Call gfuncCreateUserInfoConnection()

			//--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
			if (!gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)) {
				result = false;
				return result;
			}

			while (objReader.Read) {
				password_id = Convert.ToInt64(objReader.Item("PasswordID"));
				result = true;
			}
			objReader.Close();
			return result;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public string gfuncDecryptString(string str_encrypt)
	{
		//=====================================================================
		// Procedure Name        : gfuncDecryptString
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To decrypt the string passed to this function.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		string str_decrypt;
		string[] arr_str;
		byte[] arr_byte;
		byte bt_single;
		int rec_cnt;
		int temp_cnt;
		CWaitCursor objWait = new CWaitCursor();
		try {
			arr_str = str_encrypt.Split(";");
			rec_cnt = arr_str.Length;
			 // ERROR: Not supported in C#: ReDimStatement


			for (temp_cnt = 0; temp_cnt <= (rec_cnt - 1); temp_cnt++) {
				bt_single = Convert.ToByte(arr_str(temp_cnt));
				arr_byte(temp_cnt) = bt_single;
			}

			TripleDES obj_crypt = new TripleDES();
			str_decrypt = obj_crypt.gfuncDecrypt(arr_byte);
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

		return str_decrypt;

	}

	public string gfuncEncryptString(string str_source)
	{
		//=====================================================================
		// Procedure Name        : gfuncEncryptString
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To encrypt the string passed to this function.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		string str_single;
		string str_encrypt;
		byte[] arr_byte;
		int rec_cnt;
		int temp_cnt;
		CWaitCursor objWait = new CWaitCursor();
		try {
			TripleDES obj_crypt = new TripleDES();
			arr_byte = obj_crypt.gfuncEncrypt(str_source);

			rec_cnt = arr_byte.Length;
			for (temp_cnt = 0; temp_cnt <= (rec_cnt - 1); temp_cnt++) {
				str_single = Convert.ToString(arr_byte(temp_cnt));
				if (temp_cnt == 0) {
					str_encrypt = str_single;
				} else {
					str_encrypt = str_encrypt + ";" + str_single;
				}
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

		return str_encrypt;

	}

	public bool gfuncCreateLogBookConnection()
	{
		//=====================================================================
		// Procedure Name        :   gfuncCreateLogBookConnection
		// Description           :   To Create Global Oledb connection to Service LogBook DB.
		// Purpose               :   To Create Global Oledb connection to Service LogBook DB.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Gitesh
		// Created               :   March, 2003 
		// Revisions             :
		//=====================================================================
		bool result;
		CWaitCursor objWait = new CWaitCursor();
		try {
			gfuncCreateLogBookConnection = false;
			//--- Passing database name to clsstrConnString property
			gOleDBConnectionString_LogBook = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME);

			//--- Passing connection string to Connection Object
			gOleDBConnection_LogBook = new OleDb.OleDbConnection(gOleDBConnectionString_LogBook);

			result = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook);
			if (!(result)) {
				gobjMessageAdapter.ShowMessage(constErrorConnectionOpening);
			}

			gfuncCreateLogBookConnection = true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	public bool gfuncCreateUserInfoConnection()
	{
		//=====================================================================
		// Procedure Name        :   gfuncCreateLogBookConnection
		// Description           :   To Create Global Oledb connection to Service LogBook DB.
		// Purpose               :   To Create Global Oledb connection to Service LogBook DB.
		// Parameters Passed     :   None.
		// Returns               :   None.
		// Parameters Affected   :   None.
		// Assumptions           :
		// Dependencies          :
		// Author                :   Sachin Dokhale
		// Created               :   March, 2003 
		// Revisions             :
		//=====================================================================
		bool result;
		CWaitCursor objWait = new CWaitCursor();
		try {
			gfuncCreateUserInfoConnection = false;
			//--- Passing database name to clsstrConnString property
			gOleDBConnectionString_UserInfo = gclsDBFunctions.ConnectionString(CONSTSTR_USERINFORMATION);

			//--- Passing connection string to Connection Object
			gOleDBUserInfoConnection = new OleDb.OleDbConnection(gOleDBConnectionString_UserInfo);

			result = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection);
			if (!(result)) {
				gobjMessageAdapter.ShowMessage(constErrorConnectionOpening);
			}

			gfuncCreateUserInfoConnection = true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

}
