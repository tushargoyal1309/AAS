using AAS203.Common;
using System.Data;
using System.Data.OleDb;
using System;

public class clsDatabaseFunctions
{

	#Region "Declarations "
	private string mstrConnectionString;
		#End Region
	private Application clsApp;

	#Region "GetConnection string properties"

	//--- Property to Set / Retreive Connection String
	private string ConnectionString {
		get {
			try {
				if (strDatabasename == "") {
					//Throw New InvalidExpressionException("DatabaseName is  Null")
					gobjMessageAdapter.ShowMessage(constDatabaseNameNull);
					Application.DoEvents();
				} else {
					mstrConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + clsApp.StartupPath.ToString + "\\" + strDatabasename + ";Persist Security Info=False;Jet OLEDB:Database Password=Aldys";
					return mstrConnectionString;
				}
			} catch (System.Exception e) {
				gobjMessageAdapter.ShowMessage(e.Message.ToString, "Error...", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
				Application.DoEvents();
			}
		}

		set { mstrConnectionString = Value; }
	}

	#End Region

	#Region "OpenConnection Methods"

	//--- Function of Open DataBase Connection having input parameter as Connection String
	public OleDbConnection OpenConnection(ref string strConnectionstring)
	{
		//=====================================================================
		// Procedure Name        : OpenConnection
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open the database connection.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			OleDbConnection myConnection = new OleDbConnection(strConnectionstring);

			if (strConnectionstring == "") {
				//Throw New InvalidExpressionException("Connection string not initialised")
				gobjMessageAdapter.ShowMessage(constConnectionStrNotInit);
				Application.DoEvents();
			} else {
				if (myConnection.State == ConnectionState.Closed) {
					myConnection.Open();
					if (myConnection.State == ConnectionState.Open) {
						//Return True
						return myConnection;
					} else {
						//Throw New System.Exception("Error in Opening Connection")
						gobjMessageAdapter.ShowMessage(constErrorConnectionOpening);
					}
				} else {
					//Return True
					return myConnection;
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

	}

	//--- Function to Open Database Connection having input as Connection Object
	public bool OpenConnection(ref OleDbConnection conobj)
	{
		//=====================================================================
		// Procedure Name        : OpenConnection
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open the database connection.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (conobj.ConnectionString == "") {
				//Throw New InvalidExpressionException("Connection string not initialised")
				gobjMessageAdapter.ShowMessage(constConnectionStrNotInit);
			} else {
				if (conobj.State == ConnectionState.Closed) {
					conobj.Open();
					if (conobj.State == ConnectionState.Open) {
						return true;
					} else {
						gobjMessageAdapter.ShowMessage(constErrorConnectionOpening);
					}
				} else {
					return true;
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

	}

	//--- Function to Open Database Connection , having input as Connection object and Connection String
	public bool OpenConnection(ref OleDbConnection conobj, string constr)
	{
		//=====================================================================
		// Procedure Name        : OpenConnection
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To open the database connection.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (Len(Trim(constr)) == 0) {
				//Throw New InvalidExpressionException("Connection string priovided is Null")
				gobjMessageAdapter.ShowMessage(constNullConnectionStr);
			} else {
				conobj.ConnectionString = constr;
			}

			if (conobj.State == ConnectionState.Closed) {
				conobj.Open();
				if (conobj.State == ConnectionState.Open) {
					return true;
				} else {
					//Throw New System.Exception("Error in Opening Connection")
					gobjMessageAdapter.ShowMessage(constErrorConnectionOpening);
				}
			} else {
				return true;
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

	#Region "Getting Record Methods"
	public OleDbDataReader GetRecords(string Query, ref OleDbConnection myconnection)
	{
		//=====================================================================
		// Procedure Name        : GetRecords
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To get the records from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		bool statuscon;
		try {
			if (Len(Trim(Query)) == 0) {
				//Throw New InvalidCastException("Null String provided for Query")
				gobjMessageAdapter.ShowMessage(constNullStrForQuery);
			}

			statuscon = OpenConnection(myconnection);
			if (statuscon == true) {
				string myInsertQuery = Query;
				OleDbCommand myCommand = new OleDbCommand(myInsertQuery, myconnection);
				OleDbDataReader myReader = myCommand.ExecuteReader();

				return (myReader);

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

	//--- Function to Create a OLEDB Data Reader for the sql string and connection object passed and return bool value.
	public bool GetRecords(string Query, ref OleDbConnection myconnection, ref OleDbDataReader myReader)
	{
		//=====================================================================
		// Procedure Name        : GetRecords
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To get the records from the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		bool connection_status;
		try {
			if (Len(Trim(Query)) == 0) {
				//Throw New InvalidCastException("Null String provided for Query")
				gobjMessageAdapter.ShowMessage(constErrorConnectionOpening);
			}

			connection_status = OpenConnection(myconnection);
			if (connection_status == true) {
				string myQuery = Query;
				OleDbCommand myCommand = new OleDbCommand(myQuery, myconnection);
				myReader = myCommand.ExecuteReader();
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

	#Region "Adding single Record "

	public bool AddORDeleteRecord(string Query, ref OleDbConnection myconnection)
	{
		//=====================================================================
		// Procedure Name        : AddORDeleteRecord
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To add or delete a record from database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		bool statuscon;
		try {
			statuscon = OpenConnection(myconnection);
			if (statuscon == true) {
				string myInsertQuery = Query;
				OleDbCommand myCommand = new OleDbCommand(myInsertQuery, myconnection);
				//
				if (myCommand.ExecuteNonQuery() > 0) {
					return true;
				} else {
					//Throw New System.Exception("No Rows effected from specified Query")
					gobjMessageAdapter.ShowMessage(constNoRowsEffected);
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

	}

	#End Region

	#Region "Updating single Field "
	public bool UpdateField(string fieldName, string TableName, ref object Value, ref OleDbConnection myconnection)
	{
		//=====================================================================
		// Procedure Name        : UpdateField
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Update single field in database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		bool statuscon;
		try {
			if (Len(Trim(fieldName)) == 0) {
				gobjMessageAdapter.ShowMessage(constNullStrForFieldName);
			}
			if (Len(Trim(TableName)) == 0) {
				gobjMessageAdapter.ShowMessage(constNullStrForTableName);
			}
			statuscon = OpenConnection(myconnection);
			if (statuscon == true) {
				string myInsertQuery = "update " + TableName + " Set " + fieldName + "=" + Value + ";";
				OleDbCommand myCommand = new OleDbCommand(myInsertQuery, myconnection);
				if (myCommand.ExecuteNonQuery() > 0) {
					return true;
				} else {
					//Throw New System.Exception("No Rows affected from specified Query")
					gobjMessageAdapter.ShowMessage(constNoRowsEffected);
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

	}
	#End Region

	#Region "Updating Single record"
	public bool UpdateSingleRecord(string Query, ref OleDbConnection myconnection)
	{
		//=====================================================================
		// Procedure Name        : frmAddUser_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To load the Add User form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		bool statuscon;
		try {
			if (Len(Trim(Query)) == 0) {
				//Throw New InvalidCastException("Null String provided for Query")
				gobjMessageAdapter.ShowMessage(constNullStrForQuery);

			}
			statuscon = OpenConnection(myconnection);
			if (statuscon == true) {
				string myInsertQuery = Query;
				OleDbCommand myCommand = new OleDbCommand(myInsertQuery, myconnection);
				// Dim myReader As OleDbDataReader = myCommand.ExecuteNonQuery 
				if (myCommand.ExecuteNonQuery() > 0) {
					myCommand.Dispose();
					return true;
					//Else
					//    Throw New System.Exception("No Rows affected from specified Query")
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

	}
	#End Region

	#Region "Getting NextID"
	public long GetNextID(string TableName, string Indexfield, ref OleDbConnection myconnection)
	{
		//=====================================================================
		// Procedure Name        : GetNextID
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To generate next ID in the database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		bool statuscon;
		long NextID;
		try {
			if (Len(Trim(TableName)) == 0) {
				//Throw New InvalidCastException("Null String provided for Table Name")
				gobjMessageAdapter.ShowMessage(constNullStrForTableName);
			}
			if (Len(Trim(Indexfield)) == 0) {
				//Throw New InvalidCastException("Null String provided for Index field")
				gobjMessageAdapter.ShowMessage(constNullStrForIndexField);
			}

			statuscon = OpenConnection(myconnection);
			if (statuscon == true) {
				string myInsertQuery = "select " + Indexfield + " from " + TableName + " ORDER BY " + Indexfield + "";
				OleDbCommand myCommand = new OleDbCommand(myInsertQuery, myconnection);
				OleDbDataReader myReader = myCommand.ExecuteReader();
				NextID = 0;
				while (myReader.Read()) {
					NextID = myReader.Item(Indexfield);

				}
				myReader.Close();
				myCommand.Dispose();
				return (NextID + 1);
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

	#Region "Getting Number of records"
	public long GetNoOfRec(ref OleDbDataReader myReader)
	{
		//=====================================================================
		// Procedure Name        : GetNoOfRec
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To get number of record counts from database.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		long NumberOfRecord;
		try {
			NumberOfRecord = 0;
			while (myReader.Read()) {
				NumberOfRecord = NumberOfRecord + 1;
			}

			return (NumberOfRecord);
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

	//--- Returns True if Record Exists or any error occurs.
	public bool RecordExists(string sql_string, OleDbConnection objConnection)
	{
		//=====================================================================
		// Procedure Name        : RecordExists
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To verify whether record is present or not.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		OleDbDataReader objReader;
		bool result;
		CWaitCursor objWait = new CWaitCursor();
		try {
			objReader = GetRecords(sql_string, objConnection);
			while (objReader.Read) {
				result = true;
				return result;
			}
			result = false;


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			result = true;
			return result;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			objReader.Close();
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

		return result;
	}

	#End Region

}
