
using System.Data;
using System.Data.OleDb;
using System.IO;
///Imports CrystalDecisions.CrystalReports.Engine
///Imports CrystalDecisions.Shared
using ErrorHandler.ErrorHandler;


class mGeneralFunctions
{

	#Region " Error Logs "

	//    'Public Sub gsubErrorHandlerInitialization(ByRef objErrorHandlerIn As ErrorHandler)

	//        Try
	//            objErrorHandlerIn.CompanyName = Application.ProductName
	//            objErrorHandlerIn.ErrorLogFolder = "ErrorLogs"
	//            objErrorHandlerIn.ErrorLogFileName = Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder & "\ErrorLog-" & DateAndTime.DateString & "-" & DateAndTime.Hour(Now) & "-" & DateAndTime.Minute(Now) & "-" & DateAndTime.Second(Now) & ".log"
	//            objErrorHandlerIn.VersionMajor = Application.ProductVersion
	//            objErrorHandlerIn.ProductName = Application.ProductName

	//            objErrorHandlerIn.ExecutionTrailFolder = "ExecutionLogs"
	//            objErrorHandlerIn.ExecutionLogFileName = Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder & "\ExecutionLog-" & DateAndTime.DateString & "-" & DateAndTime.Hour(Now) & "-" & DateAndTime.Minute(Now) & "-" & DateAndTime.Second(Now) & ".log"

	//            '--- Check for the folders if not create the folders
	//            If Not Directory.Exists(Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder) Then
	//                '--- Create the folder
	//                Directory.CreateDirectory(Application.StartupPath & "\" & objErrorHandlerIn.ErrorLogFolder)
	//            End If

	//            If Not Directory.Exists(Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder) Then
	//                '--- Create the folder
	//                Directory.CreateDirectory(Application.StartupPath & "\" & objErrorHandlerIn.ExecutionTrailFolder)
	//            End If

	//        Catch ex As Exception
	//            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
	//        End Try

	//    End Sub

	#End Region

	#Region "Validation"

	///Public Sub gsubPerfomTest(ByVal intTest As Integer)
	///    Try
	///        Dim objPQTest As New frmPQTestStatus

	///        '--- Perform the test
	///        Select Case intTest
	///            Case enumValidationTests.NoiseTest
	///                objPQTest.Test = enumValidationTests.NoiseTest
	///                Call objPQTest.ShowDialog()
	///            Case enumValidationTests.BaselineFlatnessTest
	///                objPQTest.Test = enumValidationTests.BaselineFlatnessTest
	///                Call objPQTest.ShowDialog()
	///            Case enumValidationTests.WvAccDeuteriumLamp
	///                objPQTest.Test = enumValidationTests.WvAccDeuteriumLamp
	///                Call objPQTest.ShowDialog()
	///            Case enumValidationTests.PhotometryAccuracyPottasiumDichromate
	///                objPQTest.Test = enumValidationTests.PhotometryAccuracyPottasiumDichromate
	///                Call objPQTest.ShowDialog()
	///            Case enumValidationTests.StrayLight_KCL
	///                objPQTest.Test = enumValidationTests.StrayLight_KCL
	///                Call objPQTest.ShowDialog()
	///            Case enumValidationTests.ResolutionTest
	///                objPQTest.Test = enumValidationTests.ResolutionTest
	///                Call objPQTest.ShowDialog()
	///        End Select

	///    Catch ex As Exception
	///        '---------------------------------------------------------
	///        'Error Handling and logging
	///        gobjErrorHandler.ErrorDescription = ex.Message
	///        gobjErrorHandler.ErrorMessage = ex.Message
	///        gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex)
	///        '---------------------------------------------------------
	///    Finally
	///        '---------------------------------------------------------
	///        'Writing Execution log
	///        If CONST_CREATE_EXECUTION_LOG = 1 Then
	///            gobjErrorHandler.WriteExecutionLog()
	///        End If
	///        '---------------------------------------------------------
	///    End Try
	///End Sub

	public object mfuncAceptNumeric(ref RichTextBox rchtxtstr, System.Windows.Forms.KeyEventArgs e)
	{
		try {
			string OldText;
			string TempText;
			int i;
			static int intDecCount;
			//storing actual Text
			OldText = rchtxtstr.Text;
			intDecCount = 0;
			//if numeric or "." is entered 

			if (((e.KeyValue) >= 48 & (e.KeyValue) <= 57) | ((e.KeyValue) >= 96 & (e.KeyValue) <= 105) | ((e.KeyValue == 190) | (e.KeyValue == 110))) {
				for (i = 0; i <= (Len(rchtxtstr.Text) - 1); i++) {
					//retreiving each character
					TempText = OldText.Substring(i, 1);
					//loop to check if Decimal is entered once
					if (TempText == ".") {
						intDecCount = intDecCount + 1;
					}

					if (intDecCount > 1) {
						//MsgBox("Only one Decimal allowed", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Error in Value")
						//Truncating decimal
						OldText = OldText.Substring(0, Len(rchtxtstr.Text) - 1);
						rchtxtstr.Text = OldText;
						rchtxtstr.SelectionStart = Len(rchtxtstr.Text);
					}
				}
			} else {
				Beep();
				//if not numeric
				for (i = 1; i <= (Len(rchtxtstr.Text)); i++) {
					//retreiving each character from string
					TempText = Microsoft.VisualBasic.Mid(OldText, i, 1);
					//if character is not numeric
					if (!(IsNumeric(TempText))) {
						OldText = OldText.Substring(0, Len(rchtxtstr.Text) - 1);
						rchtxtstr.Text = OldText;
						rchtxtstr.SelectionStart = Len(rchtxtstr.Text);
					}
				}
			}
		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}
	public string mfuncChangeUcase(ref RichTextBox rchtxtstr)
	{
		try {
			string FormerText;
			string LaterText;
			int i;
			for (i = 1; i <= ((rchtxtstr.TextLength)); i++) {
				//changing first character of string to uppercase
				if (i == 1) {
					FormerText = UCase(Microsoft.VisualBasic.Mid(rchtxtstr.Text, i, 1));
				} else {
					//kepping intact rest of string
					LaterText = LaterText + Mid(rchtxtstr.Text, i, 1);
				}

			}
			rchtxtstr.Text = FormerText + LaterText;

			rchtxtstr.SelectionStart = rchtxtstr.TextLength;

		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}
	public string mfuncChangeUcase(ref TextBox rchtxtstr)
	{

		try {
			string FormerText;
			string LaterText;
			int i;
			for (i = 1; i <= ((rchtxtstr.TextLength)); i++) {
				if (i == 1) {
					FormerText = UCase(Microsoft.VisualBasic.Mid(rchtxtstr.Text, i, 1));
				} else {
					LaterText = LaterText + Mid(rchtxtstr.Text, i, 1);
				}

			}
			rchtxtstr.Text = FormerText + LaterText;

			rchtxtstr.SelectionStart = rchtxtstr.TextLength;
		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}
	public string mfuncformatText(string strInfo, string strGet)
	{

		try {
			//stroring "''" in database if value contains "'"
			if (strGet == "ToDataBase") {
				if (strInfo != "") {
					strInfo = Replace(strInfo, "'", "''");
				}
			} else {
				//retreiving "''" from database and converting to "'" for display
				if (strGet == "FromDataBase") {
					if (strInfo != "") {
						strInfo = Replace(strInfo, "''", "'");
					}
				}
			}

			return (strInfo);
		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}

	}

	//Public Function gfuncOpenConnection()

	//    'Initialising Connection String
	//    gOleDBconnectiostring = gclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//    ''Initialising Connection 
	//    gOledbConnectionObj = New OleDbConnection(gOleDBconnectiostring)
	//    gOledbConnectionObj.Open()
	//End Function

	#End Region

	#Region "Check for Mode Locked"
	//Public Function gfuncCheckModeLocked(ByVal intMode As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   gfuncCheckModeLocked
	//    ' Description           :   To Check if Mode is Locked for Edit or Not.
	//    ' Purpose               :   To Check if Mode is Locked for Edit or Not.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   February, 2003 
	//    ' Revisions             :
	//    '=====================================================================
	//    'Dim objReader As OleDbDataReader
	//    Dim sql_string, str_connection As String
	//    Dim reader_status, status As Boolean
	//    Dim intModeState As Integer
	//    'Dim objclsDBFunctions As New clsDatabaseFunctions
	//    'Dim objConnection As OleDbConnection

	//    Try
	//        status = False

	//        'str_connection = objclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)
	//        'objConnection = New OleDbConnection(str_connection)

	//        sql_string = "Select IQModeLocked ,OQModeLocked ,PQModeLocked from CustomerDetails where CustomerID = " & 1 & " "

	//        'reader_status = objclsDBFunctions.GetRecords(sql_string, objConnection, objReader)

	//        If Not (reader_status) Then
	//            Throw New Exception("Error in Opening Connection during Getting Mode Lock Status.")
	//        End If

	//        'While objReader.Read
	//        '    Select Case intMode
	//        '        Case ENUM_IQOQPQ_STATUS.IQ
	//        '            If IsDBNull(objReader.Item("IQModeLocked")) = False Then
	//        '                intModeState = CInt(objReader.Item("IQModeLocked"))
	//        '            Else
	//        '                intModeState = 0
	//        '            End If

	//        '        Case ENUM_IQOQPQ_STATUS.OQ
	//        '            If IsDBNull(objReader.Item("OQModeLocked")) = False Then
	//        '                intModeState = CInt(objReader.Item("OQModeLocked"))
	//        '            Else
	//        '                intModeState = 0
	//        '            End If

	//        '        Case ENUM_IQOQPQ_STATUS.PQ
	//        '            If IsDBNull(objReader.Item("PQModeLocked")) = False Then
	//        '                intModeState = CInt(objReader.Item("PQModeLocked"))
	//        '            Else
	//        '                intModeState = 0
	//        '            End If
	//        '        Case Else
	//        '            intModeState = 0
	//        '    End Select
	//        'End While

	//        If (intModeState = 1) Then
	//            status = True
	//        End If
	//        'objReader.Close()
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Getting Mode Lock Status."
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return (False)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        '--- Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//    Return status
	//End Function

	//Public Function gfuncUpdateModeLockStatus(ByVal intMode As Integer) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        :   gfuncUpdateModeLockStatus
	//    ' Description           :   To Update Lock Mode Status in Database.
	//    ' Purpose               :   To Update Lock Mode Status in Database.
	//    ' Parameters Passed     :   None.
	//    ' Returns               :   None.
	//    ' Parameters Affected   :   None.
	//    ' Assumptions           :
	//    ' Dependencies          :
	//    ' Author                :   Gitesh
	//    ' Created               :   February, 2003 
	//    ' Revisions             :
	//    '=====================================================================

	//    Dim Status As Boolean
	//    Dim str_sql, str_connection As String
	//    Dim objCommand As New OleDbCommand
	//    'Dim objclsDBFunctions As New clsDatabaseFunctions
	//    Dim objConnection As OleDbConnection

	//    Try
	//        'str_connection = objclsDBFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)
	//        objConnection = New OleDbConnection(str_connection)

	//        'Status = objclsDBFunctions.OpenConnection(objConnection)
	//        If Not (Status) Then
	//            Throw New Exception("Error in Opening Connection during Updating Mode Lock Status.")
	//        End If

	//        Select Case intMode
	//            Case ENUM_IQOQPQ_STATUS.IQ
	//                str_sql = " Update CustomerDetails " & _
	//                          " Set IQModeLocked = 1 where CustomerID = " & 1 & " "
	//            Case ENUM_IQOQPQ_STATUS.OQ
	//                str_sql = " Update CustomerDetails " & _
	//                          " Set OQModeLocked = 1 where CustomerID = " & 1 & " "
	//            Case ENUM_IQOQPQ_STATUS.PQ
	//                str_sql = " Update CustomerDetails " & _
	//                          " Set PQModeLocked = 1 where CustomerID = " & 1 & " "
	//            Case Else
	//                str_sql = ""
	//                Throw New Exception("Mode Selected to Lock is In-correct.")
	//        End Select

	//        '--- Providing command object 
	//        With objCommand
	//            .Connection = objConnection
	//            .CommandType = CommandType.Text
	//            .CommandText = str_sql
	//            .ExecuteNonQuery()
	//        End With

	//        objCommand.Dispose()
	//        Status = True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        '--- Error logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = "Error in Updating Mode Lock Status."
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return (False)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        '--- Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//    Return Status

	//End Function
	#End Region

	#Region "Functions for Printing & Exporting"

	public object gfuncPrintExportIQOQPQ(int intActiveFormTag, bool blnFlag, bool blnExport, string strFileName)
	{
		try {
			if (blnFlag == false) {
				switch (intActiveFormTag) {
					case ENUM_IQ_Modes.IQ_CustomerDetails:
						gfuncPrintCustomerDetails(blnExport, strFileName);
					//Case ENUM_IQ_Modes.IQ_EquipmentList
					//    Call gfuncPrintIQEquipmentList(blnExport, strFileName)
					//Case ENUM_IQ_Modes.IQ_Approval
					//    Call gfuncPrintIQ_Approval(blnExport, strFileName)
					//Case ENUM_IQ_Modes.IQ_Deficiency
					//    Call gfuncPrintIQ_Deficiency(blnExport, strFileName)
					//Case ENUM_IQ_Modes.IQ_ManualList
					//    Call gfuncPrintIQ_ManualList(blnExport, strFileName)
					//Case ENUM_IQ_Modes.IQ_Specifications
					//    Call gfuncPrintIQ_Specifications(blnExport, strFileName)
					//Case ENUM_IQ_Modes.IQ_Tests
					//    Call gfuncPrintIQ_Test(blnExport, strFileName)
					//Case ENUM_OQ_Modes.OQ_Approval
					//    Call gfuncPrintOQ_Approval(blnExport, strFileName)
					//Case ENUM_OQ_Modes.OQ_Deficiency
					//    Call gfuncPrintOQ_Deficiency(blnExport, strFileName)
					//Case ENUM_OQ_Modes.OQ_EquipmentList
					//    Call gfuncPrintOQEquipmentList(blnExport, strFileName)
					//Case ENUM_OQ_Modes.OQ_Test1
					//    Call gfuncPrintOQ_Test1(blnExport, strFileName)
					//Case ENUM_OQ_Modes.OQ_Test2
					//    Call gfuncPrintOQ_Test2(blnExport, strFileName)
					//Case ENUM_OQ_Modes.OQ_UserTraining
					//    Call gfuncPrintOQ_UserTraining(blnExport, strFileName)
					//Case ENUM_PQ_Modes.PQ_Approval
					//    Call gfuncPrintPQ_Approval(blnExport, strFileName)
					case ENUM_PQ_Modes.PQ_Attachment1:
						gfuncPrintPQ_Attachment1(blnExport, strFileName);
					//Case ENUM_PQ_Modes.PQ_Attachment2
					//    Call gfuncPrintPQ_Attachment2(blnExport, strFileName)
					//Case ENUM_PQ_Modes.PQ_Attachment3
					//    Call gfuncPrintPQ_Attachment3(blnExport, strFileName)
					//Case ENUM_PQ_Modes.PQ_Attachment4
					//    Call gfuncPrintPQ_Attachment4(blnExport, strFileName)
					//Case ENUM_PQ_Modes.PQ_Attachment5
					//    Call gfuncPrintPQ_Attachment5(blnExport, strFileName)
					//Case ENUM_PQ_Modes.PQ_Deficiency
					//    Call gfuncPrintPQ_Deficiency(blnExport, strFileName)
					//Case ENUM_PQ_Modes.PQ_EquipmentList
					//    Call gfuncPrintPQEquipmentList(blnExport, strFileName)
					//Case ENUM_PQ_Modes.PQ_Test
					//    Call gfuncPrintPQ_Test(blnExport, strFileName)
					case ENUM_PQ_Modes.PQ_Warranty:

						gfuncPrintWarranty(blnExport, strFileName);
				}

			} else {
				gfuncPrintCustomerDetails(blnExport, strFileName);
				//Call gfuncPrintIQEquipmentList(blnExport, strFileName)
				//Call gfuncPrintIQ_Approval(blnExport, strFileName)
				//Call gfuncPrintIQ_Deficiency(blnExport, strFileName)
				//Call gfuncPrintIQ_ManualList(blnExport, strFileName)
				//Call gfuncPrintIQ_Specifications(blnExport, strFileName)
				//Call gfuncPrintIQ_Test(blnExport, strFileName)
				//Call gfuncPrintOQ_Approval(blnExport, strFileName)
				//Call gfuncPrintOQ_Deficiency(blnExport, strFileName)
				//Call gfuncPrintOQEquipmentList(blnExport, strFileName)
				//Call gfuncPrintOQ_Test1(blnExport, strFileName)
				//Call gfuncPrintOQ_Test2(blnExport, strFileName)
				//Call gfuncPrintOQ_UserTraining(blnExport, strFileName)
				//Call gfuncPrintPQ_Approval(blnExport, strFileName)
				gfuncPrintPQ_Attachment1(blnExport, strFileName);
				//Call gfuncPrintPQ_Attachment2(blnExport, strFileName)
				//Call gfuncPrintPQ_Attachment3(blnExport, strFileName)
				//Call gfuncPrintPQ_Attachment4(blnExport, strFileName)
				//Call gfuncPrintPQ_Attachment5(blnExport, strFileName)
				//Call gfuncPrintPQ_Deficiency(blnExport, strFileName)
				//Call gfuncPrintPQEquipmentList(blnExport, strFileName)
				//Call gfuncPrintPQ_Test(blnExport, strFileName)
				gfuncPrintWarranty(blnExport, strFileName);
				//'  Call gfuncExportAll(strFileName)
				gfuncPrintAll();
			}


		//added and commented by kamal on 19March2004
		//----------------------------
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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

	public object gfuncPrintIQOQPQ(int intActiveFormTag, bool blnFlag)
	{
		try {
			gobjfrmMdi.objPrintDialog.Document = gobjfrmMdi.PrintDocument1;
			gobjfrmMdi.objPrintDialog.PrinterSettings = gobjfrmMdi.PrintDocument1.PrinterSettings;
			gobjfrmMdi.objPrintDialog.AllowSomePages = true;

			if (gobjfrmMdi.objPrintDialog.ShowDialog() == DialogResult.OK) {
				gfuncPrintExportIQOQPQ(intActiveFormTag, blnFlag, false, "");
			}

		//added and commented by kamal on 19March2004
		//----------------------------
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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

	public object gfuncExportAll(string strFileName)
	{
		crptAllReport rptExportAll = new crptAllReport();


		try {
			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerDetails where CustomerID = 1", objOleDBconnection)
			//'gobjDataSet = New dtsetExportAll
			//gobjDataAdapter.Fill(gobjDataSet, "CustomerDetails")
			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 1", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "EquipmentList")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQManualList", objOleDBconnection)
			//gobjDataAdapter.Fill(gobjDataSet, "IQManualList")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQSpecification", objOleDBconnection)
			//' Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "IQSpecification")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQAccessory", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "IQAccessory")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 1", objOleDBconnection)
			//' Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "DeficiencyCorrectiveActionPlan")


			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "CustomerRepresentative")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "ManufacturerRepresentative")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from Test", objOleDBconnection)
			//' Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "Test")


			//'###################################
			//'forms of OQ
			//'##################################

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQCustomerRepresentative")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQManufacturerRepresentative")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 2", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQEquipmentList")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 2", objOleDBconnection)
			//' Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQDeficiencyCorrectiveActionPlan")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUserTraining", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQUserTraining")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUser", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQUser")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQTest", objOleDBconnection)
			//' Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQTest")

			//'###################################
			//'forms of PQ
			//'##################################

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQCustomerRepresentative")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQManufacturerRepresentative")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 3", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQEquipmentList")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
			//'// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 3", objOleDBconnection)
			//' Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQDeficiencyCorrectiveActionPlan")

			//gobjDataAdapter = New OleDbDataAdapter("Select Distinct ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments From PQTest1 Group by ValidationTestID, PQTestName, PQPurpose, PQConformity, PQComments ", objOleDBconnection)
			/// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
			/// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQTest1")
			funcGetDataSet();

			rptExportAll.SetDataSource(gobjDataSet);
			rptExportAll.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, strFileName);

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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

	public object gfuncPrintAll()
	{
		crptAllReport rptPrintAll = new crptAllReport();
		// Dim objrptPQTest6 As New PQTest6
		//Dim section As Section
		//Dim fieldText As TextObject


		try {
			funcGetDataSet();

			rptPrintAll.SetDataSource(gobjDataSet);

			gobjfrmMdi.objPrintDialog.Document = gobjfrmMdi.PrintDocument1;
			gobjfrmMdi.objPrintDialog.PrinterSettings = gobjfrmMdi.PrintDocument1.PrinterSettings;
			gobjfrmMdi.objPrintDialog.AllowSomePages = true;

			if (gobjfrmMdi.objPrintDialog.ShowDialog() == DialogResult.OK) {
				rptPrintAll.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName;
				rptPrintAll.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage);
			}


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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

	public bool funcGetDataSet()
	{
		int intCount;
		int intColCount;
		DataTable mobjDt;
		try {
			gobjDataSet = new dtsetExportAll();

			dtsetExportAll.CustomerDetailsRow objDrCDNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.GetCustomerDetails();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objDrCDNewRow = gobjDataSet.CustomerDetails.NewCustomerDetailsRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objDrCDNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.CustomerDetails.AddCustomerDetailsRow(objDrCDNewRow);
			}

			dtsetExportAll.EquipmentListRow objELNewRow;
			dtsetExportAll.OQEquipmentListRow objELOQNewRow;
			//25.2.2010
			dtsetExportAll.PQEquipmentListRow objELPQNewRow;
			//25.2.2010


			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetIQEquipmentListRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objELNewRow = gobjDataSet.EquipmentList.NewEquipmentListRow();
				objELOQNewRow = gobjDataSet.OQEquipmentList.NewOQEquipmentListRow();
				//25.2.2010
				objELPQNewRow = gobjDataSet.PQEquipmentList.NewPQEquipmentListRow();
				//25.2.2010

				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objELNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);


					//25.2.2010
					//--------------------------------
					if (objELOQNewRow.Table.Columns.Count > intColCount) {
						objELOQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
					}
					if (objELPQNewRow.Table.Columns.Count > intColCount) {
						objELPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
					}

					//-------------------------------

				}
				gobjDataSet.EquipmentList.AddEquipmentListRow(objELNewRow);
				gobjDataSet.OQEquipmentList.AddOQEquipmentListRow(objELOQNewRow);
				//by dinesh wagh on 25.2.2010
				gobjDataSet.PQEquipmentList.AddPQEquipmentListRow(objELPQNewRow);
				//by dinesh wagh on 25.2.2010

			}

			dtsetExportAll.CompletedAcceptedBYRow objCANewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetCompleteAcceptRecords(ENUM_IQOQPQ_STATUS.IQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objCANewRow = gobjDataSet.CompletedAcceptedBY.NewCompletedAcceptedBYRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objCANewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.CompletedAcceptedBY.AddCompletedAcceptedBYRow(objCANewRow);
			}

			dtsetExportAll.IQManualListRow objMLNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetIQManualListRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objMLNewRow = gobjDataSet.IQManualList.NewIQManualListRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objMLNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.IQManualList.AddIQManualListRow(objMLNewRow);
			}

			dtsetExportAll.IQSpecificationRow objSpNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetIQSpecificationRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objSpNewRow = gobjDataSet.IQSpecification.NewIQSpecificationRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objSpNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.IQSpecification.AddIQSpecificationRow(objSpNewRow);
			}

			dtsetExportAll.IQAccessoryRow objAcNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetIQAccessoryRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objAcNewRow = gobjDataSet.IQAccessory.NewIQAccessoryRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objAcNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.IQAccessory.AddIQAccessoryRow(objAcNewRow);
			}

			dtsetExportAll.DeficiencyCorrectiveActionPlanRow objDRNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetDeficiencyRecords(ENUM_IQOQPQ_STATUS.IQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objDRNewRow = gobjDataSet.DeficiencyCorrectiveActionPlan.NewDeficiencyCorrectiveActionPlanRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objDRNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.DeficiencyCorrectiveActionPlan.AddDeficiencyCorrectiveActionPlanRow(objDRNewRow);
			}

			dtsetExportAll.CustomerRepresentativeRow objCRNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetCustomerRecords(ENUM_IQOQPQ_STATUS.IQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objCRNewRow = gobjDataSet.CustomerRepresentative.NewCustomerRepresentativeRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objCRNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.CustomerRepresentative.AddCustomerRepresentativeRow(objCRNewRow);
			}

			dtsetExportAll.ManufacturerRepresentativeRow objSRNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetSupplierRecords(ENUM_IQOQPQ_STATUS.IQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objSRNewRow = gobjDataSet.ManufacturerRepresentative.NewManufacturerRepresentativeRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objSRNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.ManufacturerRepresentative.AddManufacturerRepresentativeRow(objSRNewRow);
			}

			dtsetExportAll.TestRow objTNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetIQTestRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objTNewRow = gobjDataSet.Test.NewTestRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objTNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.Test.AddTestRow(objTNewRow);
			}

			//###################################
			//forms of OQ
			//##################################

			dtsetExportAll.OQCustomerRepresentativeRow objCROQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetCustomerRecords(ENUM_IQOQPQ_STATUS.OQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objCROQNewRow = gobjDataSet.OQCustomerRepresentative.NewOQCustomerRepresentativeRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objCROQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.OQCustomerRepresentative.AddOQCustomerRepresentativeRow(objCROQNewRow);
			}

			dtsetExportAll.OQManufacturerRepresentativeRow objSROQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetSupplierRecords(ENUM_IQOQPQ_STATUS.OQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objSROQNewRow = gobjDataSet.OQManufacturerRepresentative.NewOQManufacturerRepresentativeRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objSROQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.OQManufacturerRepresentative.AddOQManufacturerRepresentativeRow(objSROQNewRow);
			}

			//code commented by ; dinesh wagh on 25.2.2010
			//------------------------------------------------------------
			//'Dim objELOQNewRow As dtsetExportAll.OQEquipmentListRow
			//'mobjDt = New DataTable
			//'mobjDt = gobjDataAccess.funcGetOQEquipmentListRecords(ENUM_IQOQPQ_STATUS.OQ)
			//'For intCount = 0 To mobjDt.Rows.Count - 1
			//'    objELOQNewRow = gobjDataSet.OQEquipmentList.NewOQEquipmentListRow()
			//'    For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
			//'        objELOQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
			//'    Next
			//'    gobjDataSet.OQEquipmentList.AddOQEquipmentListRow(objELOQNewRow)
			//'Next
			//---------------------------------------------------------



			dtsetExportAll.OQCompletedAcceptedByRow objCAOQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetCompleteAcceptRecords(ENUM_IQOQPQ_STATUS.OQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objCAOQNewRow = gobjDataSet.OQCompletedAcceptedBy.NewOQCompletedAcceptedByRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objCAOQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.OQCompletedAcceptedBy.AddOQCompletedAcceptedByRow(objCAOQNewRow);
			}

			dtsetExportAll.OQDeficiencyCorrectiveActionPlanRow objDROQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetDeficiencyRecords(ENUM_IQOQPQ_STATUS.OQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objDROQNewRow = gobjDataSet.OQDeficiencyCorrectiveActionPlan.NewOQDeficiencyCorrectiveActionPlanRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objDROQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.OQDeficiencyCorrectiveActionPlan.AddOQDeficiencyCorrectiveActionPlanRow(objDROQNewRow);
			}

			dtsetExportAll.OQUserTrainingRow objOQUTNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetOQUserTrainingRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objOQUTNewRow = gobjDataSet.OQUserTraining.NewOQUserTrainingRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objOQUTNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.OQUserTraining.AddOQUserTrainingRow(objOQUTNewRow);
			}

			dtsetExportAll.OQUserRow objOQURNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetOQUserRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objOQURNewRow = gobjDataSet.OQUser.NewOQUserRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objOQURNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.OQUser.AddOQUserRow(objOQURNewRow);
			}

			dtsetExportAll.OQTestRow objOQT1NewRow;
			int intTotalRows;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetOQTest1AllRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objOQT1NewRow = gobjDataSet.OQTest.NewOQTestRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objOQT1NewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.OQTest.AddOQTestRow(objOQT1NewRow);
			}

			//###################################
			//forms of PQ
			//##################################

			dtsetExportAll.PQCustomerRepresentativeRow objCRPQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetCustomerRecords(ENUM_IQOQPQ_STATUS.PQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objCRPQNewRow = gobjDataSet.PQCustomerRepresentative.NewPQCustomerRepresentativeRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objCRPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.PQCustomerRepresentative.AddPQCustomerRepresentativeRow(objCRPQNewRow);
			}

			dtsetExportAll.PQManufacturerRepresentativeRow objSRPQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetSupplierRecords(ENUM_IQOQPQ_STATUS.PQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objSRPQNewRow = gobjDataSet.PQManufacturerRepresentative.NewPQManufacturerRepresentativeRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objSRPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.PQManufacturerRepresentative.AddPQManufacturerRepresentativeRow(objSRPQNewRow);
			}

			//code commented by  : dinesh wagh on 25.2.2010
			//-----------------------------------------------------------------
			//'Dim objELPQNewRow As dtsetExportAll.PQEquipmentListRow
			//'mobjDt = New DataTable
			//'mobjDt = gobjDataAccess.funcGetOQEquipmentListRecords(ENUM_IQOQPQ_STATUS.PQ)
			//'For intCount = 0 To mobjDt.Rows.Count - 1
			//'    objELPQNewRow = gobjDataSet.PQEquipmentList.NewPQEquipmentListRow()
			//'    For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
			//'        objELPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
			//'    Next
			//'    gobjDataSet.PQEquipmentList.AddPQEquipmentListRow(objELPQNewRow)
			//'Next
			//-----------------------------------------------------

			dtsetExportAll.PQCompletedAcceptedByRow objCAPQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetCompleteAcceptRecords(ENUM_IQOQPQ_STATUS.PQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objCAPQNewRow = gobjDataSet.PQCompletedAcceptedBy.NewPQCompletedAcceptedByRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objCAPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.PQCompletedAcceptedBy.AddPQCompletedAcceptedByRow(objCAPQNewRow);
			}

			dtsetExportAll.PQDeficiencyCorrectiveActionPlanRow objDRPQNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetDeficiencyRecords(ENUM_IQOQPQ_STATUS.PQ);
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objDRPQNewRow = gobjDataSet.PQDeficiencyCorrectiveActionPlan.NewPQDeficiencyCorrectiveActionPlanRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objDRPQNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.PQDeficiencyCorrectiveActionPlan.AddPQDeficiencyCorrectiveActionPlanRow(objDRPQNewRow);
			}

			dtsetExportAll.PQTest1Row objPQT1NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQConfirmityRecords();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT1NewRow = gobjDataSet.PQTest1.NewPQTest1Row();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objPQT1NewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.PQTest1.AddPQTest1Row(objPQT1NewRow);
			}


			//Dim objPQT2NewRow As dtsetExportAll.PQTest2Row
			//mobjDt = New DataTable
			//mobjDt = gobjDataAccess.funcGetPQTest1Records()
			//For intCount = 0 To mobjDt.Rows.Count - 1
			//    objPQT2NewRow = gobjDataSet.PQTest2.NewPQTest2Row()
			//    objPQT2NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
			//    objPQT2NewRow.Item("PQAbsorbance") = mobjDt.Rows(intCount).Item("PQAbsorbance")
			//    objPQT2NewRow.Item("DistBySoapRing") = mobjDt.Rows(intCount).Item("DistBySoapRing")
			//    objPQT2NewRow.Item("Time") = mobjDt.Rows(intCount).Item("Time")
			//    objPQT2NewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
			//    objPQT2NewRow.Item("PQCriteria") = mobjDt.Rows(intCount).Item("PQCriteria")
			//    objPQT2NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
			//    objPQT2NewRow.Item("PQComments") = mobjDt.Rows(intCount).Item("PQComments")
			//    objPQT2NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
			//    objPQT2NewRow.Item("Date") = mobjDt.Rows(intCount).Item("Date")
			//    gobjDataSet.PQTest2.AddPQTest2Row(objPQT2NewRow)
			//Next


			dtsetExportAll.PQTest11Row objPQT11NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest1Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT11NewRow = gobjDataSet.PQTest11.NewPQTest11Row;
				objPQT11NewRow.Item("SampleID") = mobjDt.Rows(intCount).Item("SampleID");
				objPQT11NewRow.Item("LampCurrent") = mobjDt.Rows(intCount).Item("LampCurrent");
				objPQT11NewRow.Item("PMTVoltage") = mobjDt.Rows(intCount).Item("PMTVoltage");
				objPQT11NewRow.Item("WaveLength") = mobjDt.Rows(intCount).Item("WaveLength");
				objPQT11NewRow.Item("SlitWidth") = mobjDt.Rows(intCount).Item("SlitWidth");
				objPQT11NewRow.Item("BurnerHeight") = mobjDt.Rows(intCount).Item("BurnerHeight");
				objPQT11NewRow.Item("Fuel") = mobjDt.Rows(intCount).Item("Fuel");
				objPQT11NewRow.Item("Absorbance") = mobjDt.Rows(intCount).Item("Absorbance");
				objPQT11NewRow.Item("Remark") = mobjDt.Rows(intCount).Item("Remark");
				//objPQT11NewRow.Item("Date") = mobjDt.Rows(intCount).Item("Date") '30.3.2010 by dinesh wagh
				objPQT11NewRow.Item("Date") = Format((System.DateTime)mobjDt.Rows(intCount).Item("Date"), "dd-MMM-yyyy");
				//30.3.2010 by dinesh wagh
				gobjDataSet.PQTest11.AddPQTest11Row(objPQT11NewRow);
			}

			//Dim objPQT3NewRow As dtsetExportAll.PQTest3Row
			//mobjDt = New DataTable
			//mobjDt = gobjDataAccess.funcGetPQTest2Records()
			//For intCount = 0 To mobjDt.Rows.Count - 1
			//    objPQT3NewRow = gobjDataSet.PQTest3.NewPQTest3Row()
			//    objPQT3NewRow.Item("Parameters") = mobjDt.Rows(intCount).Item("Parameters")
			//    objPQT3NewRow.Item("PQComments") = mobjDt.Rows(intCount).Item("PQComments")
			//    objPQT3NewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
			//    objPQT3NewRow.Item("PQAbsorbance") = mobjDt.Rows(intCount).Item("PQAbsorbance")
			//    objPQT3NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
			//    gobjDataSet.PQTest3.AddPQTest3Row(objPQT3NewRow)
			//Next

			dtsetExportAll.PQTest2Row objPQT2NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest2Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT2NewRow = gobjDataSet.PQTest2.NewPQTest2Row();
				//objPQT2NewRow.Item("SampleID") = mobjDt.Rows(intCount).Item("SampleID") 'commented by ; dinesh wagh on 25.2.2010
				objPQT2NewRow.Item("PQTest2ID") = mobjDt.Rows(intCount).Item("PQTest2ID");
				//added by ; dinesh wagh on 25.2.2010
				objPQT2NewRow.Item("Absorbance") = mobjDt.Rows(intCount).Item("Absorbance");
				objPQT2NewRow.Item("Deviation") = mobjDt.Rows(intCount).Item("Deviation");
				gobjDataSet.PQTest2.AddPQTest2Row(objPQT2NewRow);
			}


			//Dim objPQT4NewRow As dtsetExportAll.PQTest4Row
			//mobjDt = New DataTable
			//mobjDt = gobjDataAccess.funcGetPQTest3Records()
			//For intCount = 0 To mobjDt.Rows.Count - 1
			//    objPQT4NewRow = gobjDataSet.PQTest4.NewPQTest4Row()
			//    'For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
			//    'objPQATNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
			//    'Next
			//    objPQT4NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
			//    objPQT4NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea")
			//    objPQT4NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT")
			//    objPQT4NewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
			//    gobjDataSet.PQTest4.AddPQTest4Row(objPQT4NewRow)
			//Next

			dtsetExportAll.PQTest3Row objPQT3NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest3Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT3NewRow = gobjDataSet.PQTest3.NewPQTest3Row();
				//objPQT3NewRow.Item("SampleID") = mobjDt.Rows(intCount).Item("SampleID") 'code commented by ; dinesh wagh on 25.2.2010
				objPQT3NewRow.Item("PQTest3ID") = mobjDt.Rows(intCount).Item("PQTest3ID");
				//code added by ; dinesh wagh on 25.2.2010
				objPQT3NewRow.Item("Absorbance") = mobjDt.Rows(intCount).Item("Absorbance");
				objPQT3NewRow.Item("Concentration") = mobjDt.Rows(intCount).Item("Concentration");
				gobjDataSet.PQTest3.AddPQTest3Row(objPQT3NewRow);
			}


			dtsetExportAll.PQTest5Row objPQT5NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest4Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT5NewRow = gobjDataSet.PQTest5.NewPQTest5Row();
				//For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
				//objPQATNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount)
				//Next
				objPQT5NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID");
				objPQT5NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea");
				objPQT5NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT");
				gobjDataSet.PQTest5.AddPQTest5Row(objPQT5NewRow);
			}

			dtsetExportAll.PQTest6Row objPQT6NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest5Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT6NewRow = gobjDataSet.PQTest6.NewPQTest6Row();

				objPQT6NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID");
				objPQT6NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea");
				objPQT6NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT");
				gobjDataSet.PQTest6.AddPQTest6Row(objPQT6NewRow);
			}

			dtsetExportAll.PQTest7Row objPQT7NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest6Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT7NewRow = gobjDataSet.PQTest7.NewPQTest7Row();

				objPQT7NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID");
				objPQT7NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea");
				objPQT7NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT");
				gobjDataSet.PQTest7.AddPQTest7Row(objPQT7NewRow);
			}

			dtsetExportAll.PQTest8Row objPQT8NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest7Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT8NewRow = gobjDataSet.PQTest8.NewPQTest8Row();

				objPQT8NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID");
				objPQT8NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea");
				objPQT8NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT");
				gobjDataSet.PQTest8.AddPQTest8Row(objPQT8NewRow);
			}

			dtsetExportAll.PQTest9Row objPQT9NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest8Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT9NewRow = gobjDataSet.PQTest9.NewPQTest9Row();

				objPQT9NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID");
				objPQT9NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea");
				objPQT9NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT");
				gobjDataSet.PQTest9.AddPQTest9Row(objPQT9NewRow);
			}

			dtsetExportAll.PQTest10Row objPQT10NewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.funcGetPQTest9Records();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objPQT10NewRow = gobjDataSet.PQTest10.NewPQTest10Row();

				objPQT10NewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID");
				objPQT10NewRow.Item("PeakArea") = mobjDt.Rows(intCount).Item("PeakArea");
				objPQT10NewRow.Item("RT") = mobjDt.Rows(intCount).Item("RT");
				gobjDataSet.PQTest10.AddPQTest10Row(objPQT10NewRow);
			}


		//gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

		// Get the Section object by name.
		//section = objrptPQTest6.ReportDefinition.Sections.Item("Section4")

		//'--- Type of Instrument
		//If section.ReportObjects("txtRatio").Kind = ReportObjectKind.TextObject Then
		//    fieldText = section.ReportObjects("txtRatio")
		//    fieldText.Text = CStr(gobjValidationTest.ResolutionTest.ObsData.Item(0) / gobjValidationTest.ResolutionTest.ObsData.Item(1))
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	public object gfuncPrintIQ_Deficiency(bool blnExport, string strFileName)
	{
		IQDeficiency rptIQDeficiency = new IQDeficiency();
		OleDbConnection objOleDBconnection = new OleDbConnection();
		try {
			//--- Initialising Connection String
			//gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

			//--- Initialising Connection 
			//objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 1", objOleDBconnection)
			//gobjDataSet = New dtsetExportAll

			// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "DeficiencyCorrectiveActionPlan")

			rptIQDeficiency.SetDataSource(gobjDataSet);


			if (blnExport == false) {
				rptIQDeficiency.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName;
				rptIQDeficiency.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage);
			} else {
				rptIQDeficiency.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, strFileName);
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
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
	public object gfuncPrintOQ_Deficiency(bool blnExport, string strFileName)
	{
		OQDeficiency rptOQDeficiency = new OQDeficiency();
		OleDbConnection objOleDBconnection = new OleDbConnection();
		try {
			//--- Initialising Connection String
			//gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

			//--- Initialising Connection 
			//objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 2", objOleDBconnection)
			//gobjDataSet = New dtsetExportAll

			// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "OQDeficiencyCorrectiveActionPlan")

			rptOQDeficiency.SetDataSource(gobjDataSet);

			if (blnExport == false) {
				rptOQDeficiency.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName;
				rptOQDeficiency.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage);


			} else {
				rptOQDeficiency.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, strFileName);
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
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
	public object gfuncPrintPQ_Deficiency(bool blnExport, string strFileName)
	{
		PQDeficiency rptPQDeficiency = new PQDeficiency();
		OleDbConnection objOleDBconnection = new OleDbConnection();

		try {
			//--- Initialising Connection String
			//gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

			//--- Initialising Connection 
			//objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = 3", objOleDBconnection)
			//gobjDataSet = New dtsetExportAll

			// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQDeficiencyCorrectiveActionPlan")

			rptPQDeficiency.SetDataSource(gobjDataSet);


			if (blnExport == false) {
				rptPQDeficiency.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName;
				rptPQDeficiency.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage);

			} else {
				rptPQDeficiency.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, strFileName);
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
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

	//Public Function gfuncPrintOQ_Test1(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptOQTest1 As New OQTest1
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQTest", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQTest")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")
	//        rptOQTest1.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptOQTest1.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptOQTest1.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptOQTest1.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintOQ_Test2(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptOQTest2 As New OQTest4
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try


	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQTest", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQTest")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")
	//        rptOQTest2.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptOQTest2.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptOQTest2.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptOQTest2.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If



	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintPQ_Test(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptPQTest As New PQTest1
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

	//        rptPQTest.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptPQTest.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptPQTest.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptPQTest.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintPQ_Attachment5(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptPQAttachment5 As New PQTest6
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
	//        rptPQAttachment5.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptPQAttachment5.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptPQAttachment5.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptPQAttachment5.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If



	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintPQ_Attachment4(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptPQAttachment4 As New PQTest5
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
	//        rptPQAttachment4.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptPQAttachment4.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptPQAttachment4.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

	//        Else
	//            rptPQAttachment4.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If


	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	//Public Function gfuncPrintPQ_Attachment3(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptPQAttachment3 As New PQTest4
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
	//        rptPQAttachment3.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptPQAttachment3.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptPQAttachment3.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptPQAttachment3.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintPQ_Attachment2(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptPQAttachment2 As New PQTest3
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
	//        rptPQAttachment2.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptPQAttachment2.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptPQAttachment2.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptPQAttachment2.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	public object gfuncPrintPQ_Attachment1(bool blnExport, string strFileName)
	{
		PQTest2 rptPQAttachment1 = new PQTest2();
		//Dim objOleDBconnection As New OleDbConnection
		int intCount;
		int intColCount;
		DataTable mobjDt;
		try {
		//--- Initialising Connection String
		//gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

		//--- Initialising Connection 
		//objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

		//gobjDataAdapter = New OleDbDataAdapter("SELECT * from PQTest1", objOleDBconnection)
		//gobjDataSet = New dtsetExportAll

		// Connect to, fetch data, and disconnect from database 
		//gobjDataAdapter.Fill(gobjDataSet, "PQTest1")

		//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
		// gobjDataSet = New dtsetCompletedBy

		//// Connect to, fetch data, and disconnect from database 
		//gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
		//---------------Commented on 1 March 2006 by Rahul------------
		//Dim objPQATNewRow As dtsetExportAll.PQTestRow
		//mobjDt = New DataTable
		//mobjDt = gobjDataAccess.funcGetPQAllTestRecords()
		//For intCount = 0 To mobjDt.Rows.Count - 1
		//    objPQATNewRow = gobjDataSet.PQTest1.NewPQTestRow()
		//    'For intColCount = 0 To mobjDt.Rows(intCount).ItemArray.Length - 1
		//    objPQATNewRow.Item("SrNo") = mobjDt.Rows(intCount).Item("SrNo")
		//    objPQATNewRow.Item("PQTestID") = mobjDt.Rows(intCount).Item("PQTestID")
		//    objPQATNewRow.Item("Parameters") = mobjDt.Rows(intCount).Item("Parameters")
		//    objPQATNewRow.Item("PQTestName") = mobjDt.Rows(intCount).Item("PQTestName")
		//    objPQATNewRow.Item("ValidationTestID") = mobjDt.Rows(intCount).Item("ValidationTestID")
		//    objPQATNewRow.Item("PQPurpose") = mobjDt.Rows(intCount).Item("PQPurpose")
		//    objPQATNewRow.Item("PQConformity") = mobjDt.Rows(intCount).Item("PQConformity")
		//    objPQATNewRow.Item("PQComments") = mobjDt.Rows(intCount).Item("PQComments")
		//    objPQATNewRow.Item("ActualAbsorbance") = mobjDt.Rows(intCount).Item("ActualAbsorbance")
		//    objPQATNewRow.Item("PQCriteria") = mobjDt.Rows(intCount).Item("PQCriteria")
		//    objPQATNewRow.Item("PQAbsorbance") = mobjDt.Rows(intCount).Item("PQAbsorbance")
		//    'Next
		//    gobjDataSet.PQTest1.AddPQTestRow(objPQATNewRow)
		//Next
		//rptPQAttachment1.SetDataSource(gobjDataSet)
		//If blnExport = False Then
		//    rptPQAttachment1.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
		//    rptPQAttachment1.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
		//        gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
		//        gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
		//        gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
		//Else
		//    rptPQAttachment1.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
		//End If
		//---------------Commented on 1 March 2006 by Rahul------------

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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
	//Public Function gfuncPrintIQ_Test(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptIQTest As New IQTest
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try
	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from Test", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "Test")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")
	//        rptIQTest.SetDataSource(gobjDataSet)
	//        If blnExport = False Then
	//            rptIQTest.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptIQTest.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptIQTest.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintIQ_Specifications(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptIQ_Specifications As New IQInstSpecification
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQSpecification", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        ' Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "IQSpecification")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQAccessory ", objOleDBconnection)

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "IQAccessory")

	//        'PrintDocument1.Print()
	//        rptIQ_Specifications.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptIQ_Specifications.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptIQ_Specifications.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptIQ_Specifications.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintIQ_ManualList(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptManualList As New IQManualListing
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQManualList ", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "IQManualList")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")

	//        'PrintDocument1.Print()
	//        rptManualList.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptManualList.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptManualList.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptManualList.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintOQ_Approval(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptOQApproval As New OQApproval
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQCustomerRepresentative")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 2", objOleDBconnection)
	//        '  gobjDataSet = New dtsetIQApproval

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQManufacturerRepresentative")
	//        'PrintDocument1.Print()
	//        rptOQApproval.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptOQApproval.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptOQApproval.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptOQApproval.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintPQ_Approval(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptPQApproval As New PQApproval
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQCustomerRepresentative")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        '  gobjDataSet = New dtsetIQApproval

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQManufacturerRepresentative")
	//        'PrintDocument1.Print()
	//        rptPQApproval.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptPQApproval.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptPQApproval.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptPQApproval.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintIQ_Approval(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptIQApproval As New IQApproval
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try
	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "CustomerRepresentative")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from ManufacturerRepresentative where CheckStatusIQOQPQ = 1", objOleDBconnection)
	//        '  gobjDataSet = New dtsetIQApproval

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "ManufacturerRepresentative")
	//        'PrintDocument1.Print()
	//        rptIQApproval.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptIQApproval.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptIQApproval.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptIQApproval.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintIQ_Accessory(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptIQ_Accessory As New IQInstAccessory
	//    Dim objOleDBconnection As New OleDbConnection

	//    'Dim aw As New frmReportsViewer
	//    Try
	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from IQAccessory ", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "IQAccessory")

	//        'PrintDocument1.Print()
	//        rptIQ_Accessory.SetDataSource(gobjDataSet)

	//        'added and commented by kamal on 19March2004
	//        '----------------------------
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintIQEquipmentList(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptIQEquipment As New IQEquipmentList
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try
	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 1", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "EquipmentList")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 1", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "CompletedAcceptedBY")
	//        'PrintDocument1.Print()
	//        rptIQEquipment.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptIQEquipment.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptIQEquipment.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

	//        Else
	//            rptIQEquipment.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintOQ_UserTraining(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptOQ_UserTraining As New OQUserTraining
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try
	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUserTraining", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQUserTraining")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from OQUser", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQUser")
	//        rptOQ_UserTraining.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptOQ_UserTraining.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptOQ_UserTraining.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)
	//        Else
	//            rptOQ_UserTraining.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintOQEquipmentList(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptOQEquipment As New OQEquipmentList
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try
	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 2", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQEquipmentList")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 2", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "OQCompletedAcceptedBY")
	//        'PrintDocument1.Print()
	//        rptOQEquipment.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptOQEquipment.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptOQEquipment.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

	//        Else
	//            rptOQEquipment.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	//Public Function gfuncPrintPQEquipmentList(ByVal blnExport As Boolean, ByVal strFileName As String)
	//    Dim rptPQEquipment As New PQEquipmentList
	//    Dim objOleDBconnection As New OleDbConnection
	//    Try

	//        '--- Initialising Connection String
	//        'gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

	//        '--- Initialising Connection 
	//        'objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from EquipmentList where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        'gobjDataSet = New dtsetExportAll

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQEquipmentList")

	//        gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
	//        ' gobjDataSet = New dtsetCompletedBy

	//        '// Connect to, fetch data, and disconnect from database 
	//        gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")
	//        'PrintDocument1.Print()
	//        rptPQEquipment.SetDataSource(gobjDataSet)

	//        If blnExport = False Then
	//            rptPQEquipment.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName
	//            rptPQEquipment.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, _
	//                gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage)

	//        Else
	//            rptPQEquipment.ExportToDisk(CrystalDecisions.[Shared].ExportFormatType.RichText, strFileName)
	//        End If


	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function
	public object gfuncPrintCustomerDetails(bool blnExport, string strFileName)
	{
		CustomerDetails rptCustomerDetail = new CustomerDetails();
		//Dim objOleDBconnection As New OleDbConnection
		int intCount;
		int intColCount;
		DataTable mobjDt;
		try {
			//--- Initialising Connection String
			//gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

			//--- Initialising Connection 
			//objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)
			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CustomerDetails where CustomerID = 1", objOleDBconnection)
			//gobjDataSet = New dtsetExportAll

			//// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "CustomerDetails")
			dtsetExportAll.CustomerDetailsRow objDrCDNewRow;
			mobjDt = new DataTable();
			mobjDt = gobjDataAccess.GetCustomerDetails();
			for (intCount = 0; intCount <= mobjDt.Rows.Count - 1; intCount++) {
				objDrCDNewRow = gobjDataSet.CustomerDetails.NewCustomerDetailsRow();
				for (intColCount = 0; intColCount <= mobjDt.Rows(intCount).ItemArray.Length - 1; intColCount++) {
					objDrCDNewRow.Item(intColCount) = mobjDt.Rows(intCount).Item(intColCount);
				}
				gobjDataSet.CustomerDetails.AddCustomerDetailsRow(objDrCDNewRow);
			}
			//gobjDataSet.Tables.Add(gobjDataAccess.GetCustomerDetails())
			//PrintDocument1.Print()
			rptCustomerDetail.SetDataSource(gobjDataSet);

			if (blnExport == false) {
				rptCustomerDetail.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName;
				rptCustomerDetail.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage);

			} else {
				rptCustomerDetail.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, strFileName);

			}


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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
	public object gfuncPrintWarranty(bool blnExport, string strFileName)
	{
		PQWarranty rptPQWarranty = new PQWarranty();
		OleDbConnection objOleDBconnection = new OleDbConnection();

		try {
			//--- Initialising Connection String
			//gOleDBconnectiostring = gobjGeneralDatabaseFunctions.ConnectionString(CONST_IQOQPQ_DATABASENAME)

			//--- Initialising Connection 
			//objOleDBconnection = New OleDbConnection(gOleDBconnectiostring)

			//gobjDataAdapter = New OleDbDataAdapter("SELECT * from CompletedAcceptedBY where CheckStatusIQOQPQ = 3", objOleDBconnection)
			//gobjDataSet = New dtsetExportAll

			//// Connect to, fetch data, and disconnect from database 
			//gobjDataAdapter.Fill(gobjDataSet, "PQCompletedAcceptedBY")

			//PrintDocument1.Print()
			rptPQWarranty.SetDataSource(gobjDataSet);

			if (blnExport == false) {
				rptPQWarranty.PrintOptions.PrinterName = gobjfrmMdi.objPrintDialog.PrinterSettings.PrinterName;
				rptPQWarranty.PrintToPrinter(gobjfrmMdi.objPrintDialog.PrinterSettings.Copies, gobjfrmMdi.objPrintDialog.PrinterSettings.Collate, gobjfrmMdi.objPrintDialog.PrinterSettings.FromPage, gobjfrmMdi.objPrintDialog.PrinterSettings.ToPage);
			} else {
				rptPQWarranty.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, strFileName);
			}

		//----------------------------
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
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

	#Region "Message"
	//--- Enum for the Message types
	public enum EnumMessageType
	{
		Information = 1,
		Question = 2
		//NONE = "NONE"
	}


	public bool gfuncShowMessage(string strMessageLabel, string strMessage, EnumMessageType MessageType)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gFuncShowMessage
		//Description	    :   to show the formated message 
		//Parameters 	    :   strMessageLabel and Message
		//Time/Date  	    :   12.41 11/01/04
		//Dependencies	    :   
		//Author		        :   
		//Revision		    :
		//Revision by Person	:
		//--------------------------------------------------------------------------------------
		frmMessage1 objfrmMessage = new frmMessage1();
		bool blnFalg = false;

		try {
			return false;
			objfrmMessage.lblMessage.Text = strMessage;
			objfrmMessage.Text = strMessageLabel;
			//objfrmMessage.lblMessageLabel.Text = strMessageLabel

			switch (MessageType) {
				case EnumMessageType.Information:
					objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(0);
					objfrmMessage.cmdOk.Visible = true;
					objfrmMessage.cmdYes.Visible = false;
					objfrmMessage.cmdNo.Visible = false;
					Application.DoEvents();
					Application.DoEvents();
					if (objfrmMessage.ShowDialog() == DialogResult.OK) {
						blnFalg = true;
					} else {
						blnFalg = false;

					}
				case EnumMessageType.Question:
					objfrmMessage.picMessage.Image = objfrmMessage.ImgLstMessage.Images(1);
					objfrmMessage.cmdOk.Visible = false;
					objfrmMessage.cmdYes.Visible = true;
					objfrmMessage.cmdNo.Visible = true;

					if (objfrmMessage.ShowDialog == DialogResult.Yes) {
						blnFalg = true;
					} else {
						blnFalg = false;
					}
			}
			Application.DoEvents();
			objfrmMessage.Dispose();
			objfrmMessage = null;
			Application.DoEvents();
			return blnFalg;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(EnumErrorType.Critical, ex);
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

	#Region " Error Logs "


	public void gsubErrorHandlerInitialization(ref ErrorHandler.ErrorHandler objErrorHandlerIn)
	{
		try {
			objErrorHandlerIn.CompanyName = Application.ProductName;
			objErrorHandlerIn.ErrorLogFolder = "ErrorLogs";
			objErrorHandlerIn.ErrorLogFileName = Application.StartupPath + "\\" + objErrorHandlerIn.ErrorLogFolder + "\\ErrorLog-" + DateAndTime.DateString + "-" + DateAndTime.Hour(Now) + "-" + DateAndTime.Minute(Now) + "-" + DateAndTime.Second(Now) + ".log";
			objErrorHandlerIn.VersionMajor = Application.ProductVersion;
			objErrorHandlerIn.ProductName = Application.ProductName;

			objErrorHandlerIn.ExecutionTrailFolder = "ExecutionLogs";
			objErrorHandlerIn.ExecutionLogFileName = Application.StartupPath + "\\" + objErrorHandlerIn.ExecutionTrailFolder + "\\ExecutionLog-" + DateAndTime.DateString + "-" + DateAndTime.Hour(Now) + "-" + DateAndTime.Minute(Now) + "-" + DateAndTime.Second(Now) + ".log";

			//--- Check for the folders if not create the folders
			if (!Directory.Exists(Application.StartupPath + "\\" + objErrorHandlerIn.ErrorLogFolder)) {
				//--- Create the folder
				Directory.CreateDirectory(Application.StartupPath + "\\" + objErrorHandlerIn.ErrorLogFolder);
			}

			if (!Directory.Exists(Application.StartupPath + "\\" + objErrorHandlerIn.ExecutionTrailFolder)) {
				//--- Create the folder
				Directory.CreateDirectory(Application.StartupPath + "\\" + objErrorHandlerIn.ExecutionTrailFolder);
			}

		} catch (Exception ex) {
			//it is itself a routine for catch & hence showmessage is used
			gobjMessageAdapter.ShowMessage(ex.Message, "Error", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage);
		}

	}

	#End Region

	public string gfuncWordWrap(string strFirst_, int Length)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name	    :   gfuncWordWrap
		//Description	    :   To apply wrapping on string 
		//Parameters 	    :   Wavelength 
		//Time/Date  	    :   15/03/2010
		//Dependencies	    :   
		//Author		        :   Amit
		//Revision		    :    Dinesh Wagh
		//Revision by Person	:   2.4.2010
		//--------------------------------------------------------------------------------------


		try {
			if (strFirst_ == "") {
				return "";
			}

			if (Length == 0) {
				return strFirst_;
			}

			string[] arrStr = strFirst_.Split(vbCrLf);
			string formatedstring = "";
			string singlestr;
			ArrayList al;
			int l = Length;
			string StringWithWidth;
			string StringWithFullWords;


			for (int i = 0; i <= arrStr.Length - 1; i++) {
				singlestr = arrStr(i);
				char[] chr;
				al = new ArrayList();
				while ((singlestr.Length > 0)) {
					chr = singlestr.ToCharArray;
					if (singlestr.Length >= l + 1) {
						StringWithWidth = singlestr.Substring(0, l);
						if (chr(l) == " ") {
							StringWithFullWords = StringWithWidth;
						} else {
							StringWithFullWords = Mid(StringWithWidth, 1, InStrRev(StringWithWidth, " ") - 1);
						}
					} else {
						StringWithFullWords = singlestr;
					}

					al.Add(StringWithFullWords.Trim);
					singlestr = singlestr.Substring(StringWithFullWords.Length, singlestr.Length - StringWithFullWords.Length);
				}

				singlestr = "";

				singlestr = al(0);
				for (int j = 1; j <= al.Count - 1; j++) {
					singlestr = singlestr + vbCrLf + al(j);
				}
				formatedstring += singlestr + vbCrLf;
			}

			gfuncWordWrap = formatedstring;
		} catch (Exception ex) {
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gfuncWordWrap = "";
		} finally {
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
		}
	}


}
