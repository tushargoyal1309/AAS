
using System.io;
using DataObject;

[Serializable()]
public class clsDataAccessLayer : IDisposable
{
	//--------------------------------------------------------------------------------------------
	//Class Name     :   clsDataAccessLayer
	//Purpose        :   To provide access between the Data Object Layer
	//                   and Business Logic Layer, thus separating these two layers. 
	//                   All the database operations requested by the business 
	//                   logic layer are received by Data Access Layer and 
	//                   Sql Queries are generated which are executed and 
	//                   implemented in DataObject class
	//Assumptions    :   
	//Dependencies   :   1.Depend on DataObject Class for connection to Database
	//                   2.Depend on globalDeclararation module for Names of Databases
	//Author         :   Mangesh Shardul
	//Date/Time      :   31-Aug-2004 9:30 am
	//Revision By    :
	//Revision For   :
	//--------------------------------------------------------------------------------------------

	#Region " Private Class Variables "
	private clsDataObject mobjBusinessData;
	private clsDataObject mobjSystemData;
		#End Region
	private clsDatabaseConstants mobjDatabaseConstants = new clsDatabaseConstants();

	#Region " Constructors and Destructors "

	public clsDataAccessLayer()
	{
		base.New();
	}

	public clsDataAccessLayer(int intDataSourceTypeIn, string strBusinessDatabaseNameIn, string strSystemDatabaseNameIn, string strDBProviderIn, string strUserNameIn, string strPasswordIn, string strSqlDataSourceIn, string strDBPathIn)
	{
		//=====================================================================
		// Procedure Name        : New [Constructor]
		// Parameters Passed     : None
		// Returns               : An object this class
		// Purpose               : To constructs/instantiate object of this class
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 06-Nov-2004 3:30 pm
		// Revisions             : 
		//=====================================================================
		clsDataObject.enumDataSourceType DataSourceType;
		try {
			if (intDataSourceTypeIn == 1) {
				DataSourceType = clsDataObject.enumDataSourceType.Access;
			}
			if (intDataSourceTypeIn == 2) {
				DataSourceType = clsDataObject.enumDataSourceType.SqlServer;
			}

			mobjBusinessData = new clsDataObject(DataSourceType, strBusinessDatabaseNameIn, strDBPathIn, strDBProviderIn, strUserNameIn, strPasswordIn, strSqlDataSourceIn);
			// mobjSystemData = New clsDataObject(DataSourceType, strSystemDatabaseNameIn, strDBPathIn, strDBProviderIn, strUserNameIn, strPasswordIn, strSqlDataSourceIn)
			mobjBusinessData.OpenConnection();

			mobjSystemData = new clsDataObject(DataSourceType, strSystemDatabaseNameIn, strDBPathIn, strDBProviderIn, strUserNameIn, strPasswordIn, strSqlDataSourceIn);
			funcBuildConnectionString_ReadOnly(mobjSystemData);
			mobjSystemData.OpenConnection();

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

	protected override void Finalize()
	{
		try {
			//--DESRTUCTOR
			base.Finalize();

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

	public void System.IDisposable.Dispose()
	{
		//**********************************************************************
		// Procedure Name 	: Dispose
		// Author			: Mangesh Shardul
		// Date/Time			: 02-Nov-2004 01:10 pm
		// Description		: To dispose the objects this class instance
		//**********************************************************************
		try {
			mobjBusinessData.Dispose();
			mobjSystemData.Dispose();
			mobjDatabaseConstants.Dispose();

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

	#Region " Message Handler Functions "

	public DataTable GetMessage()
	{
		//=====================================================================
		// Procedure Name        : GetMessage
		// Parameters Passed     : None
		// Returns               : DataTable containing message data
		// Purpose               : To retrieve the Message from Table
		// Description           : 
		// Assumptions           : The table should not be empty.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 02-Sep-2004 2:45 pm
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objMessageData = new DataTable();

		try {
			ConnStatus = mobjSystemData.CheckConnectionStatus();
			if (ConnStatus == true) {
				strQuery = "SELECT * FROM [MessageInfo] ORDER BY [MessageID]";
				objMessageData = mobjSystemData.GetRecord(strQuery);
			} else {
				//---Connection NOT OPEN
				objMessageData = null;
			}

			if (IsNothing(objMessageData) == false) {
				if (objMessageData.Rows.Count > 0) {
					return objMessageData;
				} else {
					return null;
				}
			} else {
				return null;
			}

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

			objMessageData.Dispose();
			//---------------------------------------------------------
		}

	}

	public DataRow GetMessage(long lngMessageId)
	{
		//=====================================================================
		// Procedure Name        : GetMessage
		// Parameters Passed     : ID of the Message
		// Returns               : DataRow containing message data
		// Purpose               : To retrieve the Message from Table
		// Description           : 
		// Assumptions           : The table should not be empty.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 02-Sep-2004 3:45 pm
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtMessageData = new DataTable();
		DataRow objDrMessageDataRow = null;

		try {
			ConnStatus = mobjSystemData.CheckConnectionStatus();
			//=====================================================================
			// Description explaning the steps followed: 
			// 1. using global object of clsDataObject get the message data
			//    from database as DataTable
			// 2. Set the first column as Unique Key of table
			// 3. Set the first column as Primary Key of table
			// 4. then find the given Message Id in the returned DataTable
			// 5. return the DataRow for that found Message ID
			//=====================================================================
			if (ConnStatus == true) {
				strQuery = "select * from [MessageInfo] order by [MessageID]";
				objDtMessageData = mobjSystemData.GetRecord(strQuery);


				if (!IsNothing(objDtMessageData)) {
					if (objDtMessageData.Rows.Count > 0) {
						objDtMessageData.Columns("MessageID").Unique = true;
						// Create the Primary Key columns.
						DataColumn[] messagePrimaryKey = new DataColumn[0];
						messagePrimaryKey(0) = objDtMessageData.Columns("MessageID");
						objDtMessageData.PrimaryKey = messagePrimaryKey;
						objDrMessageDataRow = objDtMessageData.Rows.Find(lngMessageId);
					} else {
						objDrMessageDataRow = null;
					}
					objDtMessageData.Dispose();
				} else {
					objDrMessageDataRow = null;
				}
			} else {
				//---Connection NOT OPEN
				objDrMessageDataRow = null;
			}

			if (IsNothing(objDrMessageDataRow) == false) {
				if (objDrMessageDataRow.ItemArray.Length > 0) {
					return objDrMessageDataRow;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			//objDtMessageData.Dispose()
			objDrMessageDataRow = null;
		}

	}
	private void  // ERROR: Handles clauses are not supported in C#
mobjBusinessData_ErrorHandler(string aa)
	{
		//gobjErrorHandler.ErrorDescription = aa
		//gobjErrorHandler.ErrorMessage = aa
		//gobjErrorHandler.WriteErrorLog()
		//'---------------------------------------------------------
	}
	private void  // ERROR: Handles clauses are not supported in C#
mobjSystemData_ErrorHandler(string aa)
	{
		//gobjErrorHandler.ErrorDescription = aa
		//gobjErrorHandler.ErrorMessage = aa
		//gobjErrorHandler.WriteErrorLog()
		//'---------------------------------------------------------
	}
	public DataTable GetMessage(int intModuleId)
	{
		//=====================================================================
		// Procedure Name        : GetMessage
		// Parameters Passed     : Module ID of the Message
		// Returns               : DataTable containing message data
		// Purpose               : To retrieve the Message from Table
		// Description           : 
		// Assumptions           : The table should not be empty.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 12-Sep-2004 6:15 pm
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtMessageData = new DataTable();
		DataRow objDtMessageDataRow;

		try {
			ConnStatus = mobjSystemData.CheckConnectionStatus();
			//=====================================================================
			// Description explaning the steps followed: 
			// 1. using global object of clsDataObject get the message data
			//    from database as DataTable
			// 2. return the DataTable for that found Module ID
			//=====================================================================
			if (ConnStatus == true) {
				strQuery = "select * from MessageInfo where ModuleID=" + intModuleId + " order by MessageID";
				objDtMessageData = mobjSystemData.GetRecord(strQuery);
			} else {
				//---Connection NOT OPEN
				objDtMessageData = null;
			}

			if (IsNothing(objDtMessageData) == false) {
				if (objDtMessageData.Rows.Count > 0) {
					return objDtMessageData;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			if (!objDtMessageData == null) {
				objDtMessageData.Dispose();
			}
		}

	}

	public bool SaveErrorInfo(long lngErrNum, string strErrDesc)
	{
		//=====================================================================
		// Procedure Name        : saveErrorInfo
		// Parameters Passed     : None
		// Returns               : True if data saved successfully; false otherwise
		// Purpose               : To save Error No and Descriptions into the database
		// Description           : 
		// Assumptions           : The table should not be empty.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Sep-2004 3:30 pm
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strInsertQuery = "";
		try {
			strInsertQuery = " INSERT INTO [ErrorInfo] " + " ([ErrorNumber], [ErrorDesc]) " + " values (" + Val(lngErrNum) + ",'" + Trim(strErrDesc) + "');";

			ConnStatus = mobjSystemData.CheckConnectionStatus();
			if (ConnStatus == true) {
				if (mobjSystemData.BeginTransaction) {
					if (mobjSystemData.InsertRecords(strInsertQuery)) {
						mobjSystemData.IsCommitTransaction = true;
						return true;
					} else {
						mobjSystemData.IsCommitTransaction = false;
						return false;
					}
				} else {
					//---Transaction can not be started
					return false;
				}
			} else {
				//---Connection NOT OPEN
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

	public DataTable GetModules()
	{
		//=====================================================================
		// Procedure Name        : GetModules
		// Parameters Passed     : None
		// Returns               : DataRow containing Modules data
		// Purpose               : To retrieve the Modules Names from Table
		// Description           : 
		// Assumptions           : The table should not be empty.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 10-Sep-2004 6:15 pm
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objModulesData = new DataTable();

		try {
			ConnStatus = mobjSystemData.CheckConnectionStatus();
			if (ConnStatus == true) {
				strQuery = "select * from ModulesMst";
				objModulesData = mobjSystemData.GetRecord(strQuery);
			} else {
				//---Connection NOT OPEN
				objModulesData = null;
			}

			if (IsNothing(objModulesData) == false) {
				if (objModulesData.Rows.Count > 0) {
					return objModulesData;
				} else {
					return null;
				}
			} else {
				return null;
			}

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

			objModulesData.Dispose();
			//---------------------------------------------------------
		}

	}

	public bool SaveMessageInfo(long lngMsgIDIn, string strMessageTitle, string strMessageText, int intModuleID, string strMessageType, string strVBFileName)
	{
		//=====================================================================
		// Procedure Name        : SaveMessageInfo
		// Parameters Passed     : None
		// Returns               : True if data saved successfully; false otherwise
		// Purpose               : To save Message Ifo into the database
		// Description           : 
		// Assumptions           : The table should not be empty.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 12-Sep-2004 3:30 pm
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strInsertQuery = "";
		try {
			///strInsertQuery = " INSERT INTO [MessageInfo] " & _
			///                 " ([MessageID], [ModuleID], [MessageType], [MessageTitle], [MessageText]) " & _
			///                 " values (" & Val(lngMsgIDIn) & "," & Val(intModuleID) & "," & _
			///                 "'" & Trim(strMessageType) & "','" & Trim(strMessageTitle) & "'," & _
			///                 "'" & Trim(strMessageText) & "')"


			strInsertQuery = " INSERT INTO MessageInfo " + " (MessageID, ModuleID, MessageType, MessageTitle, MessageText, FileName) " + " values (" + Val(lngMsgIDIn) + "," + Val(intModuleID) + ",'" + Trim(strMessageType) + "'," + "'" + Trim(strMessageTitle) + "', '" + Trim(strMessageText) + "', '" + Trim(strVBFileName) + "')";


			ConnStatus = mobjSystemData.CheckConnectionStatus();
			if (ConnStatus == true) {
				if (mobjSystemData.BeginTransaction) {
					if (mobjSystemData.InsertRecords(strInsertQuery)) {
						mobjSystemData.IsCommitTransaction = true;
						return true;
					} else {
						mobjSystemData.IsCommitTransaction = false;
						return false;
					}
				} else {
					//---Transaction can not be started.
					return false;
				}
			} else {
				//---Connection NOT OPEN
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

	public bool UpdateMessageInfo(long lngMsgIDIn, string strMessageTitle, string strMessageText, int intModuleID, string strMessageType, string strVBFileName)
	{
		//=====================================================================
		// Procedure Name        : UpdateMessageInfo
		// Parameters Passed     : None
		// Returns               : True if data Updated successfully; false otherwise
		// Purpose               : To Update Message Ifo into the database
		// Description           : 
		// Assumptions           : The table should not be empty.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 13-Jan-2005 12:30 pm
		// Revisions             : 
		//=====================================================================
		bool ConnStatus;
		string strUpdateQuery;
		try {
			strUpdateQuery = " UPDATE [MessageInfo] " + " SET " + " [ModuleID]= " + Val(intModuleID) + ", " + " [MessageType] = '" + Trim(strMessageType) + "', " + " [MessageTitle]= '" + Trim(strMessageTitle) + "', " + " [MessageText] = '" + Trim(strMessageText) + "', " + " [FileName] = '" + Trim(strVBFileName) + "'" + " WHERE " + " [MessageID]=" + Val(lngMsgIDIn) + "";

			ConnStatus = mobjSystemData.CheckConnectionStatus();
			if (ConnStatus == true) {
				if (mobjSystemData.BeginTransaction) {
					if (mobjSystemData.UpdateRecord(strUpdateQuery)) {
						mobjSystemData.IsCommitTransaction = true;
						return true;
					} else {
						mobjSystemData.IsCommitTransaction = false;
						return false;
					}
				} else {
					//---Transaction can not be started.
					return false;
				}
			} else {
				//---Connection NOT OPEN
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

	//Public Function GetMessageHandlerObject(ByVal lngMessageId As Long, ByRef objMessageHandlerIn As MessageHandler.clsMessageHandler) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : GetMessage
	//    ' Parameters Passed     : Unique Id of the message.
	//    ' Returns               : The Global Object of MessageHandler with Message Info
	//    ' Purpose               : To retrieve the message from database.
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : Global Object of MessageHandler
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 13-Sep-2004 05:00 pm
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objMessageDataRow As DataRow
	//    Try
	//        '=====================================================================
	//        ' Description explaning the steps followed: 
	//        ' 1. using global object of clsDataAccessLayer get the message data
	//        '    from database
	//        ' 2. return the DataRow for that found Message ID
	//        ' 3. Pass this DataRow to MessageHandler class' GetMessage
	//        ' 4. Return the global object of MessageHandler with Message Info.
	//        '=====================================================================
	//        objMessageDataRow = Me.GetMessage(lngMessageId)

	//        Call objMessageHandlerIn.GetMessage(objMessageDataRow, objMessageHandlerIn)

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//        'Return Nothing
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	private bool funcBuildConnectionString_ReadOnly(ref clsDataObject InobjDataObject)
	{
		//=====================================================================
		// Procedure Name        : BuildConnectionString
		// Parameters Passed     : None
		// Returns               : True if successful, false otherwise
		// Purpose               : to build connection string from properties of class
		// Description           : 
		// Assumptions           : All properties are set.
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 30-Aug-2004 6:30 pm
		// Revisions             : 
		//=====================================================================
		clsDataObject.enumDataSourceType strDataSourceType;
		string strConnectionString;
		string strProvider;
		string strDataSourceName;
		string strInitialCatalog;
		string strUserName;
		string strPassword;
		bool blnPersistSecurity;
		bool blnEncryptDatabase;
		int intConnectionTimeout;
		string strMode;

		//'Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & clsApp.StartupPath.ToString & "\" & strDatabasename & ";Persist Security Info=False;Jet OLEDB:Database Password=Aldys"
		//'Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Initial Catalog=master;Data Source=RNDSERVER\ALDYS

		try {
			strDataSourceType = InobjDataObject.DataSourceType;
			strProvider = InobjDataObject.Provider;
			strDataSourceName = InobjDataObject.DataSourceName;
			strInitialCatalog = InobjDataObject.InitialCatalog;
			blnPersistSecurity = InobjDataObject.PersistSecurityInfo;
			strUserName = InobjDataObject.UserName;
			strPassword = InobjDataObject.Password;
			intConnectionTimeout = InobjDataObject.ConnectionTimeout;
			blnEncryptDatabase = InobjDataObject.EncryptDatabase;
			//strMode = ";Mode=Share Deny Read|Share Deny Write;"
			strMode = ";Mode=ReadWrite|Share Deny None;";
			switch (strDataSourceType) {
				case clsDataObject.enumDataSourceType.Access:
					//--Connection string for Access Database

					strConnectionString = "Provider=" + strProvider + ";Data Source=" + strDataSourceName + strMode + "Persist Security Info=" + blnPersistSecurity + ";Jet OLEDB:Database Password=" + strPassword + ";";
				case clsDataObject.enumDataSourceType.SqlServer:
					//--Connection string for SQL Server Database

					strConnectionString = "Persist Security Info=" + blnPersistSecurity + ";User ID=" + strUserName + ";Password=" + strPassword + ";Integrated Security=False;database=" + strInitialCatalog + ";server=" + strDataSourceName + ";Connect Timeout=" + intConnectionTimeout;
			}

			InobjDataObject.ConnectionString = strConnectionString;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			//------ Raises event to Error Status of function----
			//RaiseEvent ErrorHandler(clsDatabaseConstants.ConstErrorDBConnString)
			return true;
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

	#Region " Event Handlers "

	private void  // ERROR: Handles clauses are not supported in C#
BusinessDataErrorHandler(string strMessageText)
	{
		//=====================================================================
		// Procedure Name        : BusinessDataErrorHandler
		// Parameters Passed     : Message Text
		// Returns               : None
		// Purpose               : To handle the errors occured during 
		//                         the execution of sql query
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 05-Nov-2004 06:30 pm
		// Revisions             : 1
		//=====================================================================
		try {
			switch (strMessageText) {
				case mobjDatabaseConstants.ConstErrorDBOpen:
					gobjMessageAdapter.ShowMessage(constNotConnectedToDatabase);
					Application.DoEvents();

				case mobjDatabaseConstants.ConstErrorDBGetData:
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




	#Region "Public Functions"

	public DataTable GetCookBookData()
	{
		//=====================================================================
		// Procedure Name        : GetCookBookData
		// Parameters Passed     : Nothing
		// Returns               : Records
		// Purpose               : for getting cookbock data from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtCookBook = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				//'check a flag for connection status
				strQuery = "SELECT * FROM [CookBook_Master] Where Not (CookBook_Master.ELE_ID = 200)";
				objDtCookBook = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtCookBook = null;
			}

			if (IsNothing(objDtCookBook) == false) {
				if (objDtCookBook.Rows.Count > 0) {
					return objDtCookBook;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtCookBook.Dispose();
			//---------------------------------------------------------
		}

	}

	public DataTable GetCookBookData(int intElementID)
	{
		//=====================================================================
		// Procedure Name        : GetCookBookData
		// Parameters Passed     : intElementID
		// Returns               : Records
		// Purpose               : for getting cookbokk data from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtCookBook = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				//'check a flag for connection status
				strQuery = "SELECT * FROM [CookBook_Master] where Ele_ID=" + intElementID;
				objDtCookBook = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtCookBook = null;
			}

			if (IsNothing(objDtCookBook) == false) {
				if (objDtCookBook.Rows.Count > 0) {
					return objDtCookBook;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtCookBook.Dispose();
			//---------------------------------------------------------
		}

	}

	public DataTable GetCookBookData_AtomicNo(int intElementID)
	{
		//=====================================================================
		// Procedure Name        : GetCookBookData
		// Parameters Passed     : intElementID
		// Returns               : Records
		// Purpose               : for getting cookbook data from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtCookBook = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				//'check a flag for connection status
				strQuery = "SELECT * FROM [CookBook_AtomicNo] where Ele_ID=" + intElementID;
				objDtCookBook = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtCookBook = null;
			}

			if (IsNothing(objDtCookBook) == false) {
				if (objDtCookBook.Rows.Count > 0) {
					return objDtCookBook;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtCookBook.Dispose();
			//---------------------------------------------------------
		}

	}

	public int GetCookBookElementID(int intAtomicNumber)
	{
		//=====================================================================
		// Procedure Name        : GetCookBookElementID
		// Parameters Passed     : intAtomicNumber
		// Returns               : Records
		// Purpose               : for getting cookbook element id from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		int intElementID = new int();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				//'check a flag for connection status
				//strQuery = "SELECT ELE_ID FROM [CookBook_Master] where ATNO=" & intAtomicNumber
				intElementID = mobjBusinessData.GetRecord("CookBook_Master", "ELE_ID", "ATNO=" + intAtomicNumber.ToString);
			} else {
				intElementID = 0;
			}

			return intElementID;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return 0;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}

	}

	public DataTable EmissionData(int intAppMode)
	{
		//=====================================================================
		// Procedure Name        : EmissionData
		// Parameters Passed     : Nothing
		// Returns               : Records
		// Purpose               : To show the element symbol of those elements 
		//                         whose FUELEMS value is 0.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtCookBook = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (intAppMode == EnumAppMode.FullVersion_203D) {
				if (ConnStatus == true) {
					//'check a flag for connection status
					strQuery = "SELECT [ATNO],[ELE_ID],[NAME],[ELE_NAME],[WVEMS],[SLITEMS] FROM [CookBook_Master_DB] where [FUELEMS] = 0";
					objDtCookBook = mobjBusinessData.GetRecord(strQuery);
				} else {
					objDtCookBook = null;
				}
			} else {
				if (ConnStatus == true) {
					strQuery = "SELECT [ATNO],[ELE_ID],[NAME],[ELE_NAME],[WVEMS],[SLITEMS] FROM [CookBook_Master] where [FUELEMS] = 0";
					objDtCookBook = mobjBusinessData.GetRecord(strQuery);
				} else {
					objDtCookBook = null;
				}
			}

			if (IsNothing(objDtCookBook) == false) {
				if (objDtCookBook.Rows.Count > 0) {
					return objDtCookBook;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtCookBook.Dispose();
			//---------------------------------------------------------
		}

	}

	public DataTable GetElementWavelengths(int intElementID)
	{
		//=====================================================================
		// Procedure Name        : GetElementWavelengths
		// Parameters Passed     : intElementID
		// Returns               : Records
		// Purpose               : for getting a element wavelength from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtWavelengths = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				//'check a flag for connection status
				strQuery = "SELECT * FROM [CookBook_AADetails] where Ele_ID=" + intElementID;
				objDtWavelengths = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtWavelengths = null;
			}

			if (IsNothing(objDtWavelengths) == false) {
				if (objDtWavelengths.Rows.Count > 0) {
					return objDtWavelengths;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtWavelengths.Dispose();
			//---------------------------------------------------------
		}

	}

	public DataTable GetMethodTypes(int intMethodType, bool IsAA301 = false)
	{
		//=====================================================================
		// Procedure Name        : GetMethodTypes
		// Parameters Passed     : intMethodType
		// Returns               : Records
		// Purpose               : for getting a element method type from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtMethod = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();

			if (ConnStatus == true) {
				//---'---21.07.09
				if (IsAA301 == false) {
					if (intMethodType == 0) {
						//'check a flag for connection status
						strQuery = "SELECT * FROM [StMethodTypes]";
					} else {
						strQuery = "SELECT * FROM [StMethodTypes] where MethodTypeID=" + intMethodType;
					}
				} else {
					strQuery = "SELECT * FROM [StMethodTypes] where MethodTypeID <> 4";
				}

				objDtMethod = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtMethod = null;
			}

			if (IsNothing(objDtMethod) == false) {
				if (objDtMethod.Rows.Count > 0) {
					return objDtMethod;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtMethod.Dispose();
			//---------------------------------------------------------
		}

	}

	public DataTable GetUnits(int intUnitID = 0)
	{
		//=====================================================================
		// Procedure Name        : GetUnits
		// Parameters Passed     : intMethodType
		// Returns               : Records
		// Purpose               : for getting a element units from the database.
		// Description       
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtUnits = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				if (intUnitID == 0) {
					strQuery = "SELECT * FROM [StUnits]";
				} else {
					strQuery = "SELECT * FROM [StUnits] where UnitID=" + intUnitID;
				}

				objDtUnits = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtUnits = null;
			}

			if (IsNothing(objDtUnits) == false) {
				if (objDtUnits.Rows.Count > 0) {
					return objDtUnits;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtUnits.Dispose();
			//---------------------------------------------------------
		}
	}

	public DataTable GetMeasurementModes(int intMeasurementModeID = 0)
	{
		//=====================================================================
		// Procedure Name        : GetMeasurementModes
		// Parameters Passed     : intMeasurementModeID
		// Returns               : Records
		// Purpose               : for getting a measurementMode from the database.
		// Description       
		// Assumptions           : 
		// Dependencies          : database connection   
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtMeasurementModes = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				//'check a flag for connection status
				if (intMeasurementModeID == 0) {
					strQuery = "SELECT * FROM [StMeasurementMode]";
				} else {
					strQuery = "SELECT * FROM [StMeasurementMode] where MeasurementModeID=" + intMeasurementModeID;
				}

				objDtMeasurementModes = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtMeasurementModes = null;
			}

			if (IsNothing(objDtMeasurementModes) == false) {
				if (objDtMeasurementModes.Rows.Count > 0) {
					return objDtMeasurementModes;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtMeasurementModes.Dispose();
			//---------------------------------------------------------
		}
	}

	public DataRow GetCookBookDetailRow(int intDetailID)
	{
		//=====================================================================
		// Procedure Name        : GetCookBookDetailRow
		// Parameters Passed     : intDetailID
		// Returns               : Records
		// Purpose               : for getting a cookbook details from the database.
		// Description       
		// Assumptions           : 
		// Dependencies          : database
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataRow objDr;
		DataTable objDtWavelengths = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			if (ConnStatus == true) {
				//'check a flag for connection status
				strQuery = "SELECT * FROM [CookBook_AADetails] where AADetails_ID=" + intDetailID;
				objDtWavelengths = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtWavelengths = null;
			}

			if (IsNothing(objDtWavelengths) == false) {
				if (objDtWavelengths.Rows.Count > 0) {
					return objDtWavelengths.Rows(0);
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			if (!objDtWavelengths == null) {
				objDtWavelengths.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	public DataTable GetWavelengthRange(int intAppMode)
	{
		//=====================================================================
		// Procedure Name        : GetWavelengthRange
		// Parameters Passed     : intAppMode
		// Returns               : Records
		// Purpose               : for getting a wavelength range  from the database.
		//'                        as par application mode.
		// Description       
		// Assumptions           : 
		// Dependencies          : database connection
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtCookBook = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();

			switch (intAppMode) {
				case EnumAppMode.FullVersion_203D:
					if (ConnStatus == true) {
						//'check a flag for connection status
						strQuery = "SELECT * FROM [stWavelengthRange_DB]";
						objDtCookBook = mobjBusinessData.GetRecord(strQuery);
					} else {
						objDtCookBook = null;
					}
				case EnumAppMode.DemoMode_203D:
					if (ConnStatus == true) {
						//'check a flag for connection status
						strQuery = "SELECT * FROM [stWavelengthRange_DB]";
						objDtCookBook = mobjBusinessData.GetRecord(strQuery);
					} else {
						objDtCookBook = null;
					}
				case EnumAppMode.FullVersion_203:
					if (ConnStatus == true) {
						//'check a flag for connection status
						strQuery = "SELECT * FROM [stWavelengthRange]";
						objDtCookBook = mobjBusinessData.GetRecord(strQuery);
					} else {
						objDtCookBook = null;
					}
				case EnumAppMode.DemoMode:
					if (ConnStatus == true) {
						//'check a flag for connection status
						strQuery = "SELECT * FROM [stWavelengthRange]";
						objDtCookBook = mobjBusinessData.GetRecord(strQuery);
					} else {
						objDtCookBook = null;
					}
				case EnumAppMode.DemoMode_201:
					if (ConnStatus == true) {
						//'check a flag for connection status
						strQuery = "SELECT * FROM [stWavelengthRange]";
						objDtCookBook = mobjBusinessData.GetRecord(strQuery);
					} else {
						objDtCookBook = null;
					}
				case EnumAppMode.FullVersion_201:
					if (ConnStatus == true) {
						//'check a flag for connection status
						strQuery = "SELECT * FROM [stWavelengthRange]";
						objDtCookBook = mobjBusinessData.GetRecord(strQuery);
					} else {
						objDtCookBook = null;
					}
			}

			//If intAppMode = EnumAppMode.FullVersion_203D Or intAppMode = EnumAppMode.DemoMode_203D Then
			//    If ConnStatus = True Then
			//        ''check a flag for connection status
			//        strQuery = "SELECT * FROM [stWavelengthRange_DB]"
			//        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
			//    Else
			//        objDtCookBook = Nothing
			//    End If
			//Else
			//    If ConnStatus = True Then
			//        ''check a flag for connection status
			//        strQuery = "SELECT * FROM [stWavelengthRange]"
			//        objDtCookBook = mobjBusinessData.GetRecord(strQuery)
			//    Else
			//        objDtCookBook = Nothing
			//    End If
			//End If

			if (IsNothing(objDtCookBook) == false) {
				if (objDtCookBook.Rows.Count > 0) {
					return objDtCookBook;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtCookBook.Dispose();
			//---------------------------------------------------------
		}

	}

	public DataTable GetStdSampInfo()
	{
		//=====================================================================
		// Procedure Name        : GetStdSampInfo
		// Parameters Passed     : 
		// Returns               : Records
		// Purpose               : getting std /sam info.
		// Description       
		// Assumptions           : 
		// Dependencies          : database connection.
		// Author                : Saurabh S.
		// Created               : 22-12-2006
		// Revisions             : 
		//=====================================================================
		bool ConnStatus = false;
		string strQuery = "";
		DataTable objDtStdSampInfo = new DataTable();
		try {
			ConnStatus = mobjBusinessData.CheckConnectionStatus();
			//'check a flag for connection status

			if (ConnStatus == true) {
				strQuery = "SELECT * FROM [StdSampInfo]";

				objDtStdSampInfo = mobjBusinessData.GetRecord(strQuery);
			} else {
				objDtStdSampInfo = null;
			}

			if (IsNothing(objDtStdSampInfo) == false) {
				if (objDtStdSampInfo.Rows.Count > 0) {
					return objDtStdSampInfo;
				} else {
					return null;
				}
			} else {
				return null;
			}

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
			objDtStdSampInfo.Dispose();
			//---------------------------------------------------------
		}
	}

	#End Region

}
