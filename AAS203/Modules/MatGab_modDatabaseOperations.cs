
using System.Data;
using System.Data.OleDb;

class modDatabaseOperations
{

	#Region " Functions for inserting LogBooks data "

	//'Public Function funcInsertDataServiceLogs(ByVal LoggingDate As Date, ByVal Description As String, ByVal ServiceTime As Date, ByVal ServiceDay As Integer, ByVal SelectionType As ENUM_SELECTIONTYPE) As Boolean
	//Public Function funcInsertDataServiceLogs(ByVal Description As String, _
	//                            ByVal SelectionType As enum_LoggingDataFields, _
	//                            ByVal IDSession As Integer, _
	//                            ByVal Logvalue As String) As Boolean
	//    Dim strsqlServiceComments As String
	//    Dim objcmdMaster As New OleDb.OleDbCommand
	//    Dim IDServiceLog As Long
	//    Dim ServiceDay As Integer
	//    Dim LoggingDate As DateTime
	//    Dim ServiceTime As TimeSpan

	//    Try
	//        'Extracting ID for ServiceLogs
	//        IDServiceLog = gclsobj.GetNextID("ServiceLogs", "ServiceLogID", gOleDBConnection_LogBook)

	//        LoggingDate = DateTime.Now.Date
	//        ServiceTime = DateTime.Now.TimeOfDay
	//        ServiceDay = DateTime.Now.Day

	//        'query for adding data to ServiceLogs
	//        strsqlServiceComments = "Insert into ServiceLogs" & _
	//                                "(ServiceLogID ,SessionID ,LoggingDate ,SelectionTypeID ,LogValue ,Description ,ServiceTime ,ServiceDay)" & _
	//                                " values(?,?,?,?,?,?,?,?)"

	//        With objcmdMaster
	//            .Connection = gOleDBConnection_LogBook
	//            .CommandType = CommandType.Text
	//            .CommandText = strsqlServiceComments
	//            .Parameters.Add("ServiceLogID", OleDbType.BigInt).Value = IDServiceLog
	//            .Parameters.Add("SessionID", OleDbType.BigInt).Value = IDSession
	//            .Parameters.Add("LoggingDate", OleDbType.Date).Value = LoggingDate
	//            .Parameters.Add("SelectionTypeID", OleDbType.BigInt).Value = SelectionType
	//            .Parameters.Add("LogValue", OleDbType.VarChar).Value = Trim(Logvalue)
	//            .Parameters.Add("Description", OleDbType.LongVarWChar).Value = Trim(Description)
	//            .Parameters.Add("ServiceTime", OleDbType.Date).Value = ServiceTime
	//            .Parameters.Add("ServiceDay", OleDbType.Integer).Value = ServiceDay
	//            .ExecuteNonQuery()
	//        End With

	//        '--- To dispose command
	//        objcmdMaster.Dispose()
	//        Return True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//        Return False
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	public bool funcInsertLogData(int IDSession)
	{
		string strsqlServiceComments;
		OleDb.OleDbCommand objcmdMaster = new OleDb.OleDbCommand();
		int ServiceDay;
		DateTime LoggingDate;
		TimeSpan ServiceTime;
		bool Status;
		try {
			LoggingDate = DateTime.Now.Date;
			ServiceTime = DateTime.Now.TimeOfDay;
			ServiceDay = DateTime.Now.DayOfWeek;

			//query for adding data to ServiceLogs
			strsqlServiceComments = "Insert into LogData" + "(SessionID ,LoggingDate ,LoggingTime ,LoggingDay)" + " values(?,?,?,?)";

			 // ERROR: Not supported in C#: WithStatement


			//--- To dispose command
			objcmdMaster.Dispose();
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
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
	public bool funcInsertServiceData(int IDSession)
	{
		string strsqlServiceComments;
		OleDb.OleDbCommand objcmdMaster = new OleDb.OleDbCommand();
		bool Status;
		try {

			//query for adding data to ServiceLogs
			strsqlServiceComments = "Insert into ServiceComments" + "(ServiceCommentID)" + " values(?)";

			 // ERROR: Not supported in C#: WithStatement


			//--- To dispose command
			objcmdMaster.Dispose();
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
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

	public bool funcUpdateLogData(long lngSessionID, enum_LoggingDataFields intField, string strFieldValue)
	{
		string strsqlServiceComments;
		OleDb.OleDbCommand objcmdMaster = new OleDb.OleDbCommand();
		string strFieldname;
		bool Status;

		try {
			strFieldname = gfuncGetFieldName(intField);
			//query for adding data to ServiceLogs

			if (strFieldname == "D2ONTIME" | strFieldname == "WONTIME" | strFieldname == "INSTRUMENTONTIME") {
				strsqlServiceComments = "Update LogData set " + strFieldname + " = " + strFieldname + " + " + strFieldValue + " where SessionID = " + lngSessionID + " ";
			} else {
				strsqlServiceComments = "Update LogData set " + strFieldname + " = " + strFieldValue + " where SessionID = " + lngSessionID + " ";
			}

				//For Fields Having Double Data Type
				//    'For Fields having String Data Type
				//Case modGlobalFunctions.enum_LoggingDataFields.UVSpectrum
				//    .Parameters.Add(strFieldname, OleDbType.LongVarWChar).Value = CStr(strFieldValue)
				//    'For Fields Having Double Data Type
				//Case modConstants.enum_LoggingDataFields.D2Energy, modConstants.enum_LoggingDataFields.WEnergy, modConstants.enum_LoggingDataFields.SystemSpan, modConstants.enum_LoggingDataFields.SpanValue, modConstants.enum_LoggingDataFields.D2OnTime, modConstants.enum_LoggingDataFields.WOnTime, modConstants.enum_LoggingDataFields.InstrumentOnTime, modConstants.enum_LoggingDataFields.ZeroValue, modConstants.enum_LoggingDataFields.DacValue
				//    .Parameters.Add(strFieldname, OleDbType.BigInt).Value = CDbl(strFieldValue)
			 // ERROR: Not supported in C#: WithStatement


			//--- To dispose command
			objcmdMaster.Dispose();
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
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

	//By saraubh
	public string gfuncGetFieldName(enum_LoggingDataFields intLogField)
	{
		switch (intLogField) {
			//Case modConstants.enum_LoggingDataFields.WvHome
			//    gfuncGetFieldName = "WVSTATUS"
			//Case modConstants.enum_LoggingDataFields.FilterOutOfPath
			//    gfuncGetFieldName = "FILTEROUT"
			//Case modConstants.enum_LoggingDataFields.FilterHome
			//    gfuncGetFieldName = "FILTERHOME"
			//Case modConstants.enum_LoggingDataFields.D2Optimised
			//    gfuncGetFieldName = "D2OPT"
			//Case modConstants.enum_LoggingDataFields.D2Energy
			//    gfuncGetFieldName = "D2ENERGY"
			//Case modConstants.enum_LoggingDataFields.WOptimised
			//    gfuncGetFieldName = "WOPT"
			//Case modConstants.enum_LoggingDataFields.WEnergy
			//    gfuncGetFieldName = "WENERGY"
			//Case modConstants.enum_LoggingDataFields.Span
			//    gfuncGetFieldName = "SPAN"
			//Case modConstants.enum_LoggingDataFields.SystemSpan
			//    gfuncGetFieldName = "SYSTEMSPAN"
			//Case modConstants.enum_LoggingDataFields.SpanValue
			//    gfuncGetFieldName = "SPANVAL"
			//Case modConstants.enum_LoggingDataFields.D2OnTime
			//    gfuncGetFieldName = "D2ONTIME"
			//Case modConstants.enum_LoggingDataFields.WOnTime
			//    gfuncGetFieldName = "WONTIME"
			//Case modConstants.enum_LoggingDataFields.InstrumentOnTime
			//    gfuncGetFieldName = "INSTRUMENTONTIME"
			//Case modConstants.enum_LoggingDataFields.InstrumentComment
			//    gfuncGetFieldName = "INSTRUMENTCOMMENT"
			//Case modConstants.enum_LoggingDataFields.AccessType
			//    gfuncGetFieldName = "ACCESSTYPE"
			//Case modConstants.enum_LoggingDataFields.AccessoriesUsed
			//    gfuncGetFieldName = "ACCESSORIES"
			//Case modConstants.enum_LoggingDataFields.DacError
			//    gfuncGetFieldName = "DACERROR"
			//Case modConstants.enum_LoggingDataFields.ZeroValue
			//    gfuncGetFieldName = "ZEROVAL"
			//Case modConstants.enum_LoggingDataFields.DacValue
			//    gfuncGetFieldName = "DACVAL"
			//Case modConstants.enum_LoggingDataFields.InstrumentFlag
			//    gfuncGetFieldName = "INSTRUMENTFLAG"
			//Case modConstants.enum_LoggingDataFields.Printer
			//    gfuncGetFieldName = "PRINTER"
			//Case modConstants.enum_LoggingDataFields.Keyboard
			//    gfuncGetFieldName = "KEYBOARD"
			//Case modConstants.enum_LoggingDataFields.Baseline
			//    gfuncGetFieldName = "BASELINE"
		}
	}


	#End Region

}
