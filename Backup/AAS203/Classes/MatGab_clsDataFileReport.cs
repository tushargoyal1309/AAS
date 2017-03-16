using AAS203Library.Method;
using System.Drawing;

public class clsDataFileReport
{

	#Region " Private Class Member Variables "

	private int mintSelectedMethodID;
	private long mlngSelectedRunNumber;
	private long mlngSelectedRunIndex;
	private System.Drawing.Font mFontStyle;
		#End Region
	int intMethodsIdxId;

	#Region " Public Properties "

	public int MethodID {
		get { return mintSelectedMethodID; }
		set { mintSelectedMethodID = Value; }
	}

	public long RunNumber {
		get { return mlngSelectedRunNumber; }
		set { mlngSelectedRunNumber = Value; }
	}

	public System.Drawing.Font DefaultFont {
		get { return mFontStyle; }
		set { mFontStyle = Value; }
	}

	#End Region

	#Region " Public Functions "

	public bool funcDatafilePrint()
	{
		//=====================================================================
		// Procedure Name        : funcDatafilePrint
		// Parameters Passed     : None
		// Returns               : return true if success
		// Purpose               : print data file report of entire analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		clsPrintDocument.struHeaderString strPageFooter = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Footer "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		bool blnGetHeaderFooter;
		try {
			//Seting Report format and text
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			if (funcSetDatafileTable(objarrMoreTabularData, objarrMoreTextListData, blnGetHeaderFooter) == false) {
				return false;
			}
			if (blnGetHeaderFooter == true) {
				strPageHeader.TextString = "";
				strPageFooter.TextString = "";
			}
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, blnGetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile);

			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}

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

	public bool funcDatafilePrintForMethod()
	{
		//=====================================================================
		// Procedure Name        : funcDatafilePrint
		// Parameters Passed     : None
		// Returns               : return true if success
		// Purpose               : print data file report from method
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj bamb
		// Created               : 21Feb08
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		clsPrintDocument.struHeaderString strPageFooter = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Footer "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		bool blnGetHeaderFooter;
		try {
			//Seting Report format and text
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			if (funcSetDatafileTableForMethod(objarrMoreTabularData, objarrMoreTextListData, blnGetHeaderFooter) == false) {
				return false;
			}
			if (blnGetHeaderFooter == true) {
				strPageHeader.TextString = "";
				strPageFooter.TextString = "";
			}
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, blnGetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile);

			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}

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

	public bool funcDatafileExport(AAS203Library.Method.clsReportParameters objDataFileReportParameterIn)
	{
		//=====================================================================
		// Procedure Name        : funcDatafileExport
		// Parameters Passed     : AAS203Library.Method.clsReportParameters
		// Returns               : Boolean True if success
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18.07.07
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		clsPrintDocument.struHeaderString strPageFooter = new clsPrintDocument.struHeaderString();
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		bool GetHeaderFooter;

		try {
			//--- Seting Report format and text

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			if (funcSetDatafileTable(objarrMoreTabularData, objarrMoreTextListData) == false) {
				return false;
			}

			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile);

			GetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsReportHeaderAndFooter;
			if (GetHeaderFooter == true) {
				strPageHeader.TextString = "";
				strPageHeader.TextFormat = new clsReportHeaderFormat();
				strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;
				strPageFooter.TextString = "";
				strPageFooter.TextFormat = new clsReportHeaderFormat();
				strPageFooter.TextFormat.Alignment = ContentAlignment.MiddleCenter;

				strPageHeader.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader;
				strPageFooter.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter;
				objclsPrintDocument.PageHeader = strPageHeader;
				objclsPrintDocument.ReportFooter = strPageFooter;
			}

			// Send the data report to the export option
			if (!IsNothing(objclsPrintDocument) == true) {
				objclsPrintDocument.DataFileReportParameter = objDataFileReportParameterIn;
				if (objclsPrintDocument.SendExportData() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}

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

	public bool funcDatafileExportForMethod(AAS203Library.Method.clsReportParameters objDataFileReportParameterIn)
	{
		//=====================================================================
		// Procedure Name        : funcDatafileExportforMethod
		// Parameters Passed     : AAS203Library.Method.clsReportParameters
		// Returns               : Boolean True if success
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Pankaj
		// Created               : 21.02.08
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		clsPrintDocument.struHeaderString strPageFooter = new clsPrintDocument.struHeaderString();
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		bool GetHeaderFooter;

		try {
			//--- Seting Report format and text

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			if (funcSetDatafileTableForMethod(objarrMoreTabularData, objarrMoreTextListData) == false) {
				return false;
			}

			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.DataFile);

			GetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsReportHeaderAndFooter;
			if (GetHeaderFooter == true) {
				strPageHeader.TextString = "";
				strPageHeader.TextFormat = new clsReportHeaderFormat();
				strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;
				strPageFooter.TextString = "";
				strPageFooter.TextFormat = new clsReportHeaderFormat();
				strPageFooter.TextFormat.Alignment = ContentAlignment.MiddleCenter;

				strPageHeader.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader;
				strPageFooter.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter;
				objclsPrintDocument.PageHeader = strPageHeader;
				objclsPrintDocument.ReportFooter = strPageFooter;
			}

			// Send the data report to the export option
			if (!IsNothing(objclsPrintDocument) == true) {
				objclsPrintDocument.DataFileReportParameter = objDataFileReportParameterIn;
				if (objclsPrintDocument.SendExportData() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}

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

	public bool funcStandardGraphPrint(AAS203.AASGraph PrintGraph, string strEquation, clsMethod mobjclsMethod)
	{
		//=====================================================================
		// Procedure Name        : funcStandardGraphPrint
		// Parameters Passed     : AAS203.AASGraph, strEquation as String,clsMethod
		// Returns               : Boolean True if success
		// Purpose               : 
		// Description           : Print the Stadard Graph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.02.07
		// Revisions             : 1
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtStdSampleData;
		DataTable DtReportData;
		DataTable objDtElements;
		int intInstID;
		int intCount;
		string strElementName;
		DataRow dtRow;
		bool GetHeaderFooter;
		int intStdUsedIndex;
		bool blnFoundStd = false;
		int intCounter;
		Font TmpFont;
		try {
			//--- Seting Report format and text
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;

			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));

			//--- Search Element ID
			if (mobjclsMethod.MethodID == mintSelectedMethodID) {
				intInstID = intCount;
			}

			for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection.Count - 1; intCounter++) {
				if (mobjclsMethod.QuantitativeDataCollection(intCounter).RunNumber == mlngSelectedRunNumber) {
					mlngSelectedRunIndex = intCounter;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			objDtElements = gobjDataAccess.GetCookBookData(mobjclsMethod.InstrumentCondition.ElementID);
			if (!objDtElements == null) {
				if (objDtElements.Rows.Count > 0) {
					strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
				}
				objDtElements = null;
			}



			DtReportData = new DataTable();
			DtReportData.TableName = "Standard Graph ";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = "Standard Graph Report";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(1).Caption = "Element Name ";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(2).Caption = "Run No: ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "Analysed On";

			dtRow = DtReportData.NewRow();

			dtRow(1) = strElementName;
			dtRow(2) = (string)mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber;
			//  ""

			//code added by ; dinesh wagh on 24.2.2010
			//Without disturbing main code if in iqoqpq then.
			//-----------------------------------------------------------
			if (IsInIQOQPQ) {
				dtRow(3) = (string)Format(mobjclsMethod.AnalysisParameters.Analysis_Date, "dd-MMM-yyyy hh:mm tt");
			} else {
				//-----------------------------------------------------------------------------
				dtRow(3) = (string)Format(mobjclsMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt");
				//  ""
			}



			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);

			strPageText = strEquation;
			////**********

			for (intStdUsedIndex = 0; intStdUsedIndex <= mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count - 1; intStdUsedIndex++) {
				if (mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection(intStdUsedIndex).Used == true) {
					blnFoundStd = true;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			//Pankaj Uncomment on 25 Aug 07
			if (blnFoundStd == true) {

				if (mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count > 0) {

					DataColumn StdSampleDtCol01 = new DataColumn("Col01", typeof(string));
					DataColumn StdSampleDtCol02 = new DataColumn("Col02", typeof(string));
					DataColumn StdSampleDtCol03 = new DataColumn("Col03", typeof(string));
					DataColumn StdSampleDtCol04 = new DataColumn("Col04", typeof(string));
					DtStdSampleData = new DataTable();

					DtStdSampleData.Columns.Add(StdSampleDtCol01);
					DtStdSampleData.Columns.Item(0).Caption = "Std. Name";

					DtStdSampleData.Columns.Add(StdSampleDtCol02);
					////----- Added by Sachin Dokhale on 9.09.07
					//DtStdSampleData.Columns.Item(1).Caption = "Abs"
					switch (mobjclsMethod.OperationMode) {

						case EnumOperationMode.MODE_EMMISSION:
							DtStdSampleData.Columns.Item(1).Caption = "%E";
						default:
							DtStdSampleData.Columns.Item(1).Caption = "Abs";
					}
					////-----

					DtStdSampleData.Columns.Add(StdSampleDtCol03);

					//---commented on 27.03.09
					///DtStdSampleData.Columns.Item(2).Caption = "Conc. (ppm)"
					//-----------

					//---written on 27.03.09
					if (mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit == enumUnit.PPB) {
						DtStdSampleData.Columns.Item(2).Caption = "Conc. (ppb)";
					} else {
						DtStdSampleData.Columns.Item(2).Caption = "Conc. (ppm)";
					}
					//---------------

					DtStdSampleData.Columns.Add(StdSampleDtCol04);
					DtStdSampleData.Columns.Item(3).Caption = "Cons. in Unit";
					intCount = 0;

					while (intCount < mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count) {
						if (mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection(intCount).Used == true) {
							dtRow = DtStdSampleData.NewRow();
							dtRow(0) = (string)mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).StdName;
							//dtRow(1) = CStr(Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Abs, "###0.000"))
							switch (mobjclsMethod.OperationMode) {
								case EnumOperationMode.MODE_EMMISSION:
									dtRow(1) = (string)Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Abs, "###0.");
								default:
									dtRow(1) = (string)Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Abs, "###0.000");
							}

							dtRow(2) = (string)Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Concentration, "####0.000");
							dtRow(3) = (string)Format(mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.item(intCount).Concentration, "###0.000");
							DtStdSampleData.Rows.Add(dtRow);
						}
						intCount += 1;
					}
					objarrMoreTabularData.Add(DtStdSampleData);
				}
			}
			//End pankaj
			arrGraphControlsList = new ArrayList();

			arrGraphControlsList.Add(PrintGraph);
			TmpFont = this.DefaultFont;
			this.DefaultFont = new Font(this.DefaultFont.Name, 10, FontStyle.Regular);
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.StadardGraph);
			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
			this.DefaultFont = TmpFont;
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

			if (!(objDtElements == null)) {
				objDtElements = null;
			}
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			if (!(DtStdSampleData == null)) {
				DtStdSampleData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcSampleGraphPrint(AAS203.AASGraph PrintGraph, string strEquation, clsMethod mobjclsMethod)
	{
		//=====================================================================
		// Procedure Name        : funcSampleGraphPrint
		// Parameters Passed     : AAS203.AASGraph, strEquation as String,clsMethod
		// Returns               : Return if success
		// Purpose               : Print the report of the Sample graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable objDtElements;
		DataTable DtReportData;
		int intCount;
		DataRow dtRow;
		string strElementName;
		int intInstID;
		bool GetHeaderFooter;
		int intCounter;
		int intStdUsedIndex;
		bool blnFoundStd = false;
		Font TmpFont;
		try {
			//Seting Report format and text
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;

			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));

			////----- Search Element ID
			//For intCount = 0 To gobjMethodCollection.Count - 1
			//    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
			//        'If gobjMethodCollection(intCount).SelectedElementID = gobjMethodCollection(intCount).InstrumentCondition.ElementID Then
			//        intInstID = intCount
			//        Exit For
			//        'End If
			//    End If
			//Next


			for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection.Count - 1; intCounter++) {
				if (mobjclsMethod.QuantitativeDataCollection(intCounter).RunNumber == mlngSelectedRunNumber) {
					mlngSelectedRunIndex = intCounter;
					break; // TODO: might not be correct. Was : Exit For
				}
			}


			objDtElements = gobjDataAccess.GetCookBookData(mobjclsMethod.InstrumentCondition.ElementID);
			if (!objDtElements == null) {
				if (objDtElements.Rows.Count > 0) {
					strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
				}
				objDtElements = null;
			}

			DtReportData = new DataTable();
			DtReportData.TableName = "Sample Graph ";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = "Sample Graph Report";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(1).Caption = "Element Name ";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(2).Caption = "Run No: ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "Analysed On";

			dtRow = DtReportData.NewRow();

			dtRow(1) = strElementName;
			dtRow(2) = (string)mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber;
			//  ""
			dtRow(3) = (string)Format(mobjclsMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt");
			//  ""


			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);

			strPageText = strEquation;
			////***********


			for (intStdUsedIndex = 0; intStdUsedIndex <= mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count - 1; intStdUsedIndex++) {
				if (mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intStdUsedIndex).Used == true) {
					blnFoundStd = true;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			arrGraphControlsList = new ArrayList();
			arrGraphControlsList.Add(PrintGraph);
			TmpFont = this.DefaultFont;
			this.DefaultFont = new Font(this.DefaultFont.Name, 10, FontStyle.Regular);

			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.StadardGraph);

			//--- View the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
			this.DefaultFont = TmpFont;
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
			if (!(objDtElements == null)) {
				objDtElements = null;
			}
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcEditDataRepeatResult(clsMethod objclsMethodIn)
	{
		//=====================================================================
		// Procedure Name        : funcEditDataRepeatResult
		// Parameters Passed     : objclsMethodIn as clsMethod 
		// Returns               : Boolean Return true if success
		// Purpose               : Fill the Data to the Print Document
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 03.08.07
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtReportData;
		DataTable DtReportData_InitInfo;
		DataTable DtReportDataStatistics;
		int intCount;
		DataRow dtRow;
		int intInstID;
		bool GetHeaderFooter;
		int intCounter;
		int intSerNo = 0;
		int intStdIdx;
		int intSampIdx;
		int intAbsRepeat;
		string strlblStatistics_1;
		string strlblStatistics_2;
		string strAbsRepeat;
		string strConcRepeat;
		string strElementName;
		DataTable objDtElements;

		//------------------ '---05.03.09
		double dblConc;
		string strConcUnit;
		int intUnit;
		//------------------

		//Print the data of Repeat result
		try {
			//--- Seting Report format and text
			strPageHeader.TextString = "Data Print";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;


			////----- Search Element ID
			//For intCount = 0 To gobjMethodCollection.Count - 1
			//    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
			//        intInstID = intCount
			//        Exit For
			//    End If
			//Next


			//For intCounter = 0 To objclsMethodIn.QuantitativeDataCollection.Count - 1
			//    If objclsMethodIn.QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
			//        mlngSelectedRunIndex = intCounter
			//        Exit For
			//    End If
			//Next
			mlngSelectedRunIndex = -1;
			intMethodsIdxId = -1;
			////----- Search Element ID
			//objclsMethodIn
			//For intCount = 0 To gobjMethodCollection.Count - 1
			//If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
			//intMethodsIdxId = intCount

			//For intCounter = 0 To gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count - 1
			for (intCounter = 0; intCounter <= objclsMethodIn.QuantitativeDataCollection.Count - 1; intCounter++) {
				//If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(intCounter).RunNumber = mlngSelectedRunNumber Then
				if (objclsMethodIn.QuantitativeDataCollection(intCounter).RunNumber == mlngSelectedRunNumber) {
					mlngSelectedRunIndex = intCounter;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			//End If
			//Next

			if (mlngSelectedRunIndex == -1) {
				return false;
			}


			//With gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex)

				// Set the object for titel " Report" 









				//  ""

				//If (gobjMethodCollection.item(intMethodsIdxId).AnalysisParameters.Analysis_Date) > Convert.ToDateTime("1/1/1900") Then

				//  ""   ' code commented by : dinesh wagh on 9.4.2009
				//dtRow(3) = CStr(Format(objclsMethodIn.DateOfLastUse, "dd-MMM-yyyy hh:mm tt")) ' code added by : dinesh wagh on 9.4.2009


			 // ERROR: Not supported in C#: WithStatement

			//---


			////----- Master Table
			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportCol01 = new DataColumn("SerNo", typeof(int));
			DataColumn ReportCol02 = new DataColumn("StdSampSerNo", typeof(string));
			DataColumn ReportCol03 = new DataColumn("StdSampName", typeof(string));
			DataColumn ReportCol04 = new DataColumn("Abso", typeof(string));
			DataColumn ReportCol05 = new DataColumn("Conc", typeof(string));
			DataColumn ReportCol06 = new DataColumn("StdSamp", typeof(bool));
			////----- Details Table
			DataColumn ReportDtlHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtlCol01 = new DataColumn("SerNo", typeof(int));
			DataColumn ReportDtlCol02 = new DataColumn("Observation", typeof(string));
			DataColumn ReportDtlCol03 = new DataColumn("ProcessMean", typeof(string));
			DataColumn ReportDtlCol04 = new DataColumn("StdDivation", typeof(string));
			DataColumn ReportDtlCol05 = new DataColumn("Variance", typeof(string));
			DataColumn ReportDtlCol06 = new DataColumn("CoeffVariance", typeof(string));
			DataColumn ReportDtlCol07 = new DataColumn("MinValue", typeof(string));
			DataColumn ReportDtlCol08 = new DataColumn("MaxValue", typeof(string));
			DataColumn ReportDtlCol09 = new DataColumn("Range", typeof(string));
			DataColumn ReportDtlCol10 = new DataColumn("IsAbs", typeof(bool));


			//commented on 27.03.09
			//--------------------- '---05.03.09
			//'intUnit = objclsMethodIn.QuantitativeDataCollection(mlngSelectedRunIndex).AnalysisParameters.Unit
			//'If intUnit = 1 Then
			//'    strConcUnit = "Conc. (ppm)"
			//'Else
			//'    strConcUnit = "Conc. (%)"
			//'End If
			//---------------------


			//----written on 27.03.09
			intUnit = objclsMethodIn.QuantitativeDataCollection(mlngSelectedRunIndex).AnalysisParameters.Unit;
			if (intUnit == enumUnit.PPM) {
				strConcUnit = "Conc. (ppm)";
			} else if (intUnit == enumUnit.Percent) {
				strConcUnit = "Conc. (ppm)";
				//---19.04.09
			} else if (intUnit == enumUnit.PPB) {
				strConcUnit = "Conc. (ppb)";
			}
			//----------------


			DtReportData = new DataTable();
			DtReportData.TableName = "Master Statics";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = "Master Statistic";

			DtReportData.Columns.Add(ReportCol01);
			DtReportData.Columns.Item(1).Caption = "Ser No.";

			DtReportData.Columns.Add(ReportCol02);
			DtReportData.Columns.Item(2).Caption = "Std Samp Ser No.";

			DtReportData.Columns.Add(ReportCol03);

			//---commented on 27.03.09
			//'DtReportData.Columns.Item(3).Caption = "Name : "
			//-----

			//---written on 27.03.09
			DtReportData.Columns.Item(3).Caption = strConcUnit + Space(1) + " :";
			//---03.06.09
			//-----


			DtReportData.Columns.Add(ReportCol04);
			DtReportData.Columns.Item(4).Caption = "Abs";

			DtReportData.Columns.Add(ReportCol05);
			DtReportData.Columns.Item(5).Caption = "Conc";

			DtReportData.Columns.Add(ReportCol06);
			DtReportData.Columns.Item(6).Caption = "IsStd";

			////----- Details Table
			DtReportDataStatistics = new DataTable();
			DtReportDataStatistics.TableName = "Details Statics";
			DtReportDataStatistics.Columns.Add(ReportDtlHeader1);
			DtReportDataStatistics.Columns.Item(0).Caption = "Details Statistic";

			DtReportDataStatistics.Columns.Add(ReportDtlCol01);
			DtReportDataStatistics.Columns.Item(1).Caption = "Ser No.";

			DtReportDataStatistics.Columns.Add(ReportDtlCol02);
			DtReportDataStatistics.Columns.Item(2).Caption = "Valid Observation";

			DtReportDataStatistics.Columns.Add(ReportDtlCol03);
			DtReportDataStatistics.Columns.Item(3).Caption = "Process Mean";

			DtReportDataStatistics.Columns.Add(ReportDtlCol04);
			DtReportDataStatistics.Columns.Item(4).Caption = "Standard Deviation";

			DtReportDataStatistics.Columns.Add(ReportDtlCol05);
			DtReportDataStatistics.Columns.Item(5).Caption = "Variance";

			DtReportDataStatistics.Columns.Add(ReportDtlCol06);
			DtReportDataStatistics.Columns.Item(6).Caption = "Coeff. of  Variance";

			DtReportDataStatistics.Columns.Add(ReportDtlCol07);
			DtReportDataStatistics.Columns.Item(7).Caption = "Minimum Value";

			DtReportDataStatistics.Columns.Add(ReportDtlCol08);
			DtReportDataStatistics.Columns.Item(8).Caption = "Maximun Value";

			DtReportDataStatistics.Columns.Add(ReportDtlCol09);
			DtReportDataStatistics.Columns.Item(9).Caption = "Range";

			DtReportDataStatistics.Columns.Add(ReportDtlCol10);
			DtReportDataStatistics.Columns.Item(10).Caption = "IsAbs";

			if (objclsMethodIn.OperationMode == EnumOperationMode.MODE_EMMISSION) {
				strlblStatistics_1 = "Statistics on Emission";
			} else {
				strlblStatistics_1 = "Statistics on Abs";
			}


			strlblStatistics_2 = "Statistics on Conc";
			bool blnIsStartRepeat = false;

				//If intAbsRepeat = 0 Then '.StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData.Count - 1 Then



				//1 -Ser No.
				//2 - "Std Samp Ser No."

				//---commented on 27.03.09
				///dtRow(3) = .StandardDataCollection(intStdIdx).StdName      '3 - "Std Samp Name"  
				//----

				//---written on 27.03.09
				//---03.06.09
				//---03.06.09
				//-----

				//Format(.StandardDataCollection(intStdIdx).AbsRepeat. , "#0.00000")      '4 - "Abs"   '---03.06.09
				//Format(.StandardDataCollection(intStdIdx).Concentration, "#0.00000")      '5    -   "Conc"

				//1  -   "Ser No."
				//2 - "Observation"
				//3 - "Process Mean"
				//4 - "Standard Divation"
				//5 - "Variance"
				//6 - "Coeff.of Varaince"
				//7 - "Minimum Value"
				//8 - "Maximun Value"
				//9 - "Range"
				// 10 - "Range"

				//---03.07.09
				//---03.07.09

				////------ Sample Data




				//---03.07.09
				//---03.07.09
				//---03.07.09


				//If intAbsRepeat = 0 Then '.StandardDataCollection(intStdIdx).AbsRepeat.AbsRepeatData.Count - 1 Then


				//---03.07.09


				// code added by : dinesh wagh on 8.3.2009

				//---03.07.09


				//---03.07.09

				//---03.07.09


				//strConcRepeat = Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, "#0.000") ' commented by : dinesh wagh on 8.3.2009
				//---03.06.09

				//strAbsRepeat = strAbsRepeat & ", " & Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Abs, "#0.000")  '---03.06.09

				//strConcRepeat = strConcRepeat & ", " & Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, "#0.000")' commented by : dinesh wagh on 8.3.2009

				// code added by : dinesh wagh on 8.3.2009   '---03.06.09

				//strConcRepeat = strConcRepeat & ", " & FormatNumber(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intAbsRepeat).Concentration, objclsMethodIn.AnalysisParameters.NumOfDecimalPlaces)  '---03.06.09

				//1 - "Ser No."
				//2 - "Std Samp Ser No."
				//3 - "Std Samp Name"
				//Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intRepeatIdx).Abs, "#0.00000")          '4 - "Abs"
				//Format(.SampleDataCollection(intSampIdx).AbsRepeat.AbsRepeatData(intRepeatIdx).Concentration, "#0.00000")       '5 - "Conc"
				////----- Statistics Data
				////----- Statistics of Abs
				//1 - "Ser No."
				//2 "Observation"
				//3 - "Process Mean"
				//4 "Standard Divation"
				//5 - "Variance"
				//6 - "Coeff.of Varaince"
				//7 - "Minimum Value"
				//8 - "Maximun Value"
				//9 - "Range"
				//10 - "IsAbs"

				////----- Statistics of Conc
				//DtReportData.Rows.Add(dtRow)
				//1 - "Ser No."
				//2 - "Observation"
				//3 - "Process Mean"
				//4 - "Standard Divation"
				//5 - "Variance"
				// 6 - "Coeff.of Varaince"
				//7 - "Minimum Value"
				//8 - "Maximun Value"
				//9 - "Range"
				//10 - "IsAbs"
				////-----
				//Next
			 // ERROR: Not supported in C#: WithStatement


			objarrMoreTextListData.Add(DtReportData);
			objarrMoreTextListData.Add(DtReportDataStatistics);
			objarrMoreTextListData.Add(DtReportData_InitInfo);

			strPageText = "";
			////***********
			int intStdUsedIndex;
			bool blnFoundStd = false;

			for (intStdUsedIndex = 0; intStdUsedIndex <= objclsMethodIn.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection.Count - 1; intStdUsedIndex++) {
				if (objclsMethodIn.QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intStdUsedIndex).Used == true) {
					blnFoundStd = true;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			objclsPrintDocument.DisplayFont = this.DefaultFont;
			GetHeaderFooter = true;
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, objarrMoreTabularData, objarrMoreTextListData, clsPrintDocument.enumReportType.RepeatResults);

			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (GetHeaderFooter == true) {
					strPageHeader.TextString = "";
					strPageHeader.TextFormat = new clsReportHeaderFormat();
					strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

					strPageHeader.TextString = "Data Print";
					//gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader
					//strPageFooter.TextString = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter
					objclsPrintDocument.PageHeader = strPageHeader;
					//objclsPrintDocument.ReportFooter = strPageFooter
				}

				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
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

			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcHistographPrint(AAS203.AASGraph PrintGraph, clsMethod mobjclsMethod)
	{
		//=====================================================================
		// Procedure Name        : funcHistographPrint
		// Parameters Passed     : AAS203.AASGraph, clsMethod
		// Returns               : Return if success
		// Purpose               : 
		// Description           : Print the Histograph
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 21.02.07
		// Revisions             : 1
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "  ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtReportData;
		DataTable objDtElements;
		int intInstID;
		int intCount;
		string strElementName;
		DataRow dtRow;
		bool GetHeaderFooter;
		int intCounter;

		try {
			//Seting Report format and text
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;


			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));

			////----- Search Element ID
			if (mobjclsMethod.MethodID == mintSelectedMethodID) {
				intInstID = intCount;
			}

			for (intCounter = 0; intCounter <= mobjclsMethod.QuantitativeDataCollection.Count - 1; intCounter++) {
				if (mobjclsMethod.QuantitativeDataCollection(intCounter).RunNumber == mlngSelectedRunNumber) {
					mlngSelectedRunIndex = intCounter;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			objDtElements = gobjDataAccess.GetCookBookData(mobjclsMethod.InstrumentCondition.ElementID);
			if (!objDtElements == null) {
				if (objDtElements.Rows.Count > 0) {
					strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
				}
				objDtElements = null;
			}



			DtReportData = new DataTable();
			DtReportData.TableName = "Histogram Print";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = "Histogram Print";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(1).Caption = "Element Name ";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(2).Caption = "Run No: ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "Analysed On";

			dtRow = DtReportData.NewRow();

			//dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
			dtRow(1) = strElementName;
			if ((mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber > 0)) {
				dtRow(2) = (string)mobjclsMethod.QuantitativeDataCollection(mlngSelectedRunIndex).RunNumber;
				//  ""
			} else {
				dtRow(2) = (string)" ";
			}
			dtRow(3) = (string)Format(mobjclsMethod.DateOfLastUse, "dd-MMM-yyyy hh:mm tt");
			//  ""


			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);

			////**********
			int intStdUsedIndex;
			bool blnFoundStd = false;

			for (intStdUsedIndex = 0; intStdUsedIndex <= mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection.Count - 1; intStdUsedIndex++) {
				if (mobjclsMethod.QuantitativeDataCollection.Item(mlngSelectedRunIndex).StandardDataCollection(intStdUsedIndex).Used == true) {
					blnFoundStd = true;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			arrGraphControlsList = new ArrayList();

			arrGraphControlsList.Add(PrintGraph);

			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.Histograph);

			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
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

			if (!(objDtElements == null)) {
				objDtElements = null;
			}
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcPeakValleyPrintUV(AAS203.AASGraph PrintGraph, DataTable objDataTable_PeakValley, Spectrum.UVSpectrumParameter objInstrumentParameter, string strEquation)
	{
		//=====================================================================
		// Procedure Name        : funcPeakValleyPrintUV
		// Parameters Passed     : AAS203.AASGraph,DataTable, Spectrum.UVSpectrumParameter,
		//                       : strEquation As String
		// Returns               : True if success
		// Purpose               : Print report of Peak Valley for UV Abs.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtReportData;
		int intCount;
		DataRow dtRow;
		int intInstID;
		bool GetHeaderFooter;

		try {
			//--- Seting Report format and text
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;

			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));
			DataColumn ReportDtCol04 = new DataColumn("Col04", typeof(string));
			DataColumn ReportDtCol05 = new DataColumn("Col05", typeof(string));
			DataColumn ReportDtCol06 = new DataColumn("Col06", typeof(string));
			DataColumn ReportDtCol07 = new DataColumn("Col07", typeof(string));

			////----- Search Element ID
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (gobjMethodCollection.item(intCount).MethodID == mintSelectedMethodID) {
					intInstID = intCount;
					break; // TODO: might not be correct. Was : Exit For
				}
			}

			////----- Print Page Header Text
			strPageText = "<# Spectrum Print";

			DtReportData = new DataTable();
			DtReportData.TableName = "Sample Graph ";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(1).Caption = "Sample : ";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(2).Caption = "Date : ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "PMT : ";

			DtReportData.Columns.Add(ReportDtCol04);
			DtReportData.Columns.Item(4).Caption = "D2 Cur : ";

			DtReportData.Columns.Add(ReportDtCol05);
			DtReportData.Columns.Item(5).Caption = "Slit : ";

			DtReportData.Columns.Add(ReportDtCol06);
			DtReportData.Columns.Item(6).Caption = "Speed : ";

			DtReportData.Columns.Add(ReportDtCol07);
			DtReportData.Columns.Item(7).Caption = "Mode : ";



			dtRow = DtReportData.NewRow();

			//dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
			//dtRow(1) = "  " 'intObjCount
			if (objInstrumentParameter.SpectrumName == "" | objInstrumentParameter.SpectrumName == null) {
				objInstrumentParameter.SpectrumName = "       ";
			}
			dtRow(1) = objInstrumentParameter.SpectrumName;
			//dtRow(2) = objInstrumentParameter.AnalysisDate     'strElementName
			dtRow(2) = (string)Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt");
			// Added by Pankaj on 06 Sep 07
			dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString + " Volts";
			dtRow(4) = objInstrumentParameter.D2Curr + " mA";
			dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString + " nm";



			string strSpeed;

			//Pankaj for 201
			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201)) {
				if (objInstrumentParameter.ScanSpeed == CONST_FASTStep_AA201) {
					strSpeed = "Fast";
					//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
				} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep_AA201) {
					strSpeed = "Medium";
				} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep_AA201) {
					strSpeed = "Slow";
				}
			} else {
				if (objInstrumentParameter.ScanSpeed == CONST_FASTStep) {
					strSpeed = "Fast";
					//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
				} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep) {
					strSpeed = "Medium";
				} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep) {
					strSpeed = "Slow";
				}
			}
			//End
			dtRow(6) = strSpeed;
			dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode);


			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);
			strPageText = Trim("Comments : " + objInstrumentParameter.Comments);


			arrGraphControlsList = new ArrayList();
			arrGraphControlsList.Add(PrintGraph);
			objDataTable_PeakValley.TableName = gstrTitleInstrumentType + " SPECTRUM PEAKS AND VALLEYS";

			objarrMoreTabularData.Add(objDataTable_PeakValley);

			GetHeaderFooter = true;
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.PrintPeak_Valley);

			strPageHeader.TextString = "Spectrum Print";
			objclsPrintDocument.PageHeader = strPageHeader;
			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
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
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcPeakValleyPrintEnergy(AAS203.AASGraph PrintGraph, DataTable objDataTable_PeakValley, Spectrum.EnergySpectrumParameter objInstrumentParameter, string strEquation)
	{
		//=====================================================================
		// Procedure Name        : funcPeakValleyPrintEnergy
		// Parameters Passed     : AAS203.AASGraph,DataTable, Spectrum.EnergySpectrumParameter,
		//                       : strEquation As String
		// Returns               : True if success
		// Purpose               : Print report of Peak Valley for Energy
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtReportData;
		DataRow dtRow;
		bool GetHeaderFooter;
		string strSpeed;
		try {
			//--- Ini page header for clsPrintDocument object
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;

			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));
			DataColumn ReportDtCol04 = new DataColumn("Col04", typeof(string));
			DataColumn ReportDtCol05 = new DataColumn("Col05", typeof(string));
			DataColumn ReportDtCol06 = new DataColumn("Col06", typeof(string));
			DataColumn ReportDtCol07 = new DataColumn("Col07", typeof(string));

			////----- Print Page Header Text
			strPageText = "<# Spectrum Print";

			DtReportData = new DataTable();
			DtReportData.TableName = "Sample Graph ";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(1).Caption = "Turret No. :";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(2).Caption = "Element : ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "PMT :";

			DtReportData.Columns.Add(ReportDtCol04);
			DtReportData.Columns.Item(4).Caption = "D2 Cur : ";

			DtReportData.Columns.Add(ReportDtCol05);
			DtReportData.Columns.Item(5).Caption = "Slit : ";

			DtReportData.Columns.Add(ReportDtCol06);
			DtReportData.Columns.Item(6).Caption = "Speed : ";

			DtReportData.Columns.Add(ReportDtCol07);
			DtReportData.Columns.Item(7).Caption = "Mode : ";


			dtRow = DtReportData.NewRow();


			dtRow(1) = objInstrumentParameter.LampTurrNo;
			dtRow(2) = objInstrumentParameter.LampEle;
			//strElementName
			dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString + " Volts";
			dtRow(4) = objInstrumentParameter.D2Curr + " mA";
			dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString + " nm";



			//Pankaj for 201
			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201) | (gstructSettings.AppMode == EnumAppMode.DemoMode_201)) {
				if (objInstrumentParameter.ScanSpeed == CONST_FASTStep_AA201) {
					strSpeed = "Fast";
					//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
				} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep_AA201) {
					strSpeed = "Medium";
				} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep_AA201) {
					strSpeed = "Slow";
				}

			} else {
				if (objInstrumentParameter.ScanSpeed == CONST_FASTStep) {
					strSpeed = "Fast";
					//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
				} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep) {
					strSpeed = "Medium";
				} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep) {
					strSpeed = "Slow";
				}
			}
			//End
			dtRow(6) = strSpeed;
			dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode);


			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);

			//--- "Comments" field is disable in Energy report
			//strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
			strPageText = "";

			arrGraphControlsList = new ArrayList();
			arrGraphControlsList.Add(PrintGraph);
			objDataTable_PeakValley.TableName = gstrTitleInstrumentType + " SPECTRUM PEAKS AND VALLEYS";

			objarrMoreTabularData.Add(objDataTable_PeakValley);

			GetHeaderFooter = true;
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.PrintPeak_Valley);


			strPageHeader.TextString = "Spectrum Print";
			objclsPrintDocument.PageHeader = strPageHeader;
			//--- View the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
			return true;
		} catch (Exception ex) {
			//----s-----------------------------------------------------
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
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcPrintEnergy(AAS203.AASGraph PrintGraph, Spectrum.EnergySpectrumParameter objInstrumentParameter, string strEquation)
	{
		//=====================================================================
		// Procedure Name        : funcPrintEnergy
		// Parameters Passed     : AAS203.AASGraph, Spectrum.EnergySpectrumParameter, strEquation As String
		// Returns               : True if success
		// Purpose               : Print report of Energy graph
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtMethosDefination;
		DataTable objDtElements;
		DataTable DtReportData;
		int intCount;
		DataRow dtRow;
		DataTable DtStdSampleData;
		string strElementName;
		int intInstID;
		bool GetHeaderFooter;

		try {
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			//If funcSetDatafieTable(objarrMoreTabularData, objarrMoreTextListData) = False Then
			//    Return False
			//End If


			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));
			DataColumn ReportDtCol04 = new DataColumn("Col04", typeof(string));
			DataColumn ReportDtCol05 = new DataColumn("Col05", typeof(string));
			DataColumn ReportDtCol06 = new DataColumn("Col06", typeof(string));
			DataColumn ReportDtCol07 = new DataColumn("Col07", typeof(string));
			DataColumn ReportDtCol08 = new DataColumn("Col08", typeof(string));

			////----- Search Element ID
			//For intCount = 0 To gobjMethodCollection.Count - 1
			//    If gobjMethodCollection.item(intCount).MethodID = mintSelectedMethodID Then
			//        'If gobjMethodCollection(intCount).SelectedElementID = gobjMethodCollection(intCount).InstrumentCondition.ElementID Then
			//        intInstID = intCount
			//        Exit For
			//        'End If
			//    End If
			//Next

			//objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(MethodID).InstrumentCondition.ElementID)
			//If Not objDtElements Is Nothing Then
			//    If objDtElements.Rows.Count > 0 Then
			//        strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
			//    End If
			//    objDtElements = Nothing
			//End If
			////----- Print Page Header Text
			strPageText = "<# Spectrum Print";

			DtReportData = new DataTable();
			DtReportData.TableName = "Sample Graph ";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(1).Caption = "Turret No. :";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(2).Caption = "Element : ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "PMT :";

			DtReportData.Columns.Add(ReportDtCol04);
			DtReportData.Columns.Item(4).Caption = "D2 Cur : ";

			DtReportData.Columns.Add(ReportDtCol05);
			DtReportData.Columns.Item(5).Caption = "Slit : ";

			DtReportData.Columns.Add(ReportDtCol06);
			DtReportData.Columns.Item(6).Caption = "Speed : ";

			DtReportData.Columns.Add(ReportDtCol07);
			DtReportData.Columns.Item(7).Caption = "Mode : ";

			DtReportData.Columns.Add(ReportDtCol08);
			DtReportData.Columns.Item(8).Caption = "Analysed On : ";

			int intObjCount;

			//For intObjCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
			//    Dim intSearchEleId As Integer
			//    intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber)
			//    If intSearchEleId = gobjMethodCollection.item(MethodID).InstrumentCondition.ElementID Then
			//        'If funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) = True Then
			//        intObjCount = intObjCount + 1
			//        Exit For
			//        'End If
			//    End If
			//Next

			dtRow = DtReportData.NewRow();

			//dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""

			//dtRow(1) = intObjCount
			dtRow(1) = objInstrumentParameter.LampTurrNo;
			dtRow(2) = objInstrumentParameter.LampEle;
			//strElementName
			dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString + " Volts";
			dtRow(4) = objInstrumentParameter.D2Curr + " mA";
			dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString + " nm";
			string strSpeed;
			//If objInstrumentParameter.ScanSpeed = CONST_FASTStep Or _
			//        objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
			//    strSpeed = "Slow"
			//ElseIf objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep Or _
			//        objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
			//    strSpeed = "Medium"
			//ElseIf objInstrumentParameter.ScanSpeed = CONST_SLOWStep Or _
			//        objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then
			//    strSpeed = "Fast"
			//End If
			if (objInstrumentParameter.ScanSpeed == CONST_FASTStep) {
				strSpeed = "Fast";
				//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
			} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep) {
				strSpeed = "Medium";
			} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep) {
				strSpeed = "Slow";
			}
			//Pankaj for 201
			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				if (objInstrumentParameter.ScanSpeed == CONST_FASTStep_AA201) {
					strSpeed = "Fast";
					//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
				} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep_AA201) {
					strSpeed = "Medium";
				} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep_AA201) {
					strSpeed = "Slow";
				}

			}
			//End
			dtRow(6) = strSpeed;
			dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode);
			dtRow(8) = (string)Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt");
			//  ""



			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);
			//--- "Comments" field is disable in Energy report
			//strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
			strPageText = "";

			arrGraphControlsList = new ArrayList();
			arrGraphControlsList.Add(PrintGraph);
			//objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

			//objarrMoreTabularData.Add(objDataTable_PeakValley)
			//objclsPrintDocument.PageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter
			GetHeaderFooter = true;
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.EnergySpectrum);

			strPageHeader.TextString = "Spectrum Print";
			objclsPrintDocument.PageHeader = strPageHeader;

			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
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
			if (!(DtMethosDefination == null)) {
				DtMethosDefination = null;
			}
			if (!(objDtElements == null)) {
				objDtElements = null;
			}
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcPrintD2Peak(AAS203.AASGraph PrintGraph_486Peak, AAS203.AASGraph PrintGraph_656Peak)
	{
		//=====================================================================
		// Procedure Name        : funcPrintD2Peak
		// Parameters Passed     : PrintGraph_486Peak  and PrintGraph_656Peak as AAS203.AASGraph
		// Returns               : True if success
		// Purpose               : Print report of D2 Peak
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtMethosDefination;
		DataTable objDtElements;
		DataTable DtReportData;
		int intCount;
		DataRow dtRow;
		DataTable DtStdSampleData;
		string strElementName;
		int intInstID;
		bool GetHeaderFooter;

		try {
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			//If funcSetDatafieTable(objarrMoreTabularData, objarrMoreTextListData) = False Then
			//    Return False
			//End If


			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));

			////----- Print Page Header Text
			strPageText = " ";
			//"<# D2 Peak Print"

			DtReportData = new DataTable();
			DtReportData.TableName = "D2 Graph ";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = " ";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(1).Caption = "Analysed On : ";
			dtRow = DtReportData.NewRow();
			dtRow(0) = " ";
			dtRow(1) = (string)Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt");
			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);
			//--- "Comments" field is disable in Energy report
			//strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
			//strPageText = ""

			arrGraphControlsList = new ArrayList();
			arrGraphControlsList.Add(PrintGraph_486Peak);
			arrGraphControlsList.Add(PrintGraph_656Peak);
			//objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

			//objarrMoreTabularData.Add(objDataTable_PeakValley)
			//objclsPrintDocument.PageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter
			GetHeaderFooter = true;
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.EnergySpectrum);

			strPageHeader.TextString = "D2 Peak Print";
			objclsPrintDocument.PageHeader = strPageHeader;
			objclsPrintDocument.DisplayFont = this.DefaultFont;
			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				PrintGraph_486Peak.AldysPane.Legend.IsVisible = true;
				PrintGraph_656Peak.AldysPane.Legend.IsVisible = true;

				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
				PrintGraph_486Peak.AldysPane.Legend.IsVisible = false;
				PrintGraph_656Peak.AldysPane.Legend.IsVisible = false;
			}
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
			if (!(DtMethosDefination == null)) {
				DtMethosDefination = null;
			}
			if (!(objDtElements == null)) {
				objDtElements = null;
			}
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcPrintTimescan(AAS203.AASGraph PrintGraph_Timescan)
	{
		//=====================================================================
		// Procedure Name        : funcPrintTimescan
		// Parameters Passed     : PrintGraph_Timescan as AAS203.AASGraph, mobjclsMethod As clsMethod
		// Returns               : True if success
		// Purpose               : Print report of Time Sacan
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 05.12.2007
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtMethosDefination;
		DataTable objDtElements;
		DataTable DtReportData;
		int intCount;
		DataRow dtRow;
		DataTable DtStdSampleData;
		string strElementName;
		int intInstID;
		bool GetHeaderFooter;
		double mdblFuelRatio;
		//--- Column defination 
		DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
		DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
		DataColumn ReportDtCol01_1 = new DataColumn("Col01_1", typeof(string));
		DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
		DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));
		DataColumn ReportDtCol04 = new DataColumn("Col04", typeof(string));
		DataColumn ReportDtCol04_1 = new DataColumn("Col04_1", typeof(string));
		DataColumn ReportDtCol05 = new DataColumn("Col05", typeof(string));
		DataColumn ReportDtCol06 = new DataColumn("Col06", typeof(string));
		DataColumn ReportDtCol07 = new DataColumn("Col07", typeof(string));
		DataColumn ReportDtCol08 = new DataColumn("Col08", typeof(string));
		DataColumn ReportDtCol09 = new DataColumn("Col09", typeof(string));
		//----
		int ColIndex;

		try {
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			//If funcSetDatafieTable(objarrMoreTabularData, objarrMoreTextListData) = False Then
			//    Return False
			//End If

			DtReportData = new DataTable();
			DtReportData.TableName = "Timescan";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(ColIndex).Caption = "TIMESCAN";
			ColIndex += 1;

			DtReportData.Columns.Add(ReportDtCol01);
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				DtReportData.Columns.Item(ColIndex).Caption = "PMT :";
			} else {
				DtReportData.Columns.Item(ColIndex).Caption = "Sample PMT :";
			}

			ColIndex += 1;
			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(ColIndex).Caption = "Date : ";
			ColIndex += 1;

			if (!gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				DtReportData.Columns.Add(ReportDtCol01_1);
				DtReportData.Columns.Item(ColIndex).Caption = "Ref. PMT :";
				ColIndex += 1;
			} else {
				ReportDtCol01_1 = null;
			}

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(ColIndex).Caption = "Current : ";
			ColIndex += 1;

			DtReportData.Columns.Add(ReportDtCol04);
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				DtReportData.Columns.Item(ColIndex).Caption = "Entry Slit : ";
			} else {
				DtReportData.Columns.Item(ColIndex).Caption = "Slit : ";
			}
			ColIndex += 1;

			DtReportData.Columns.Add(ReportDtCol05);
			DtReportData.Columns.Item(ColIndex).Caption = "D2 Cur : ";
			ColIndex += 1;

			if (!gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				DtReportData.Columns.Add(ReportDtCol04_1);
				DtReportData.Columns.Item(ColIndex).Caption = "Exit Slit : ";
				ColIndex += 1;
			} else {
				ReportDtCol04_1 = null;
			}

			DtReportData.Columns.Add(ReportDtCol06);
			DtReportData.Columns.Item(ColIndex).Caption = "Mode : ";
			ColIndex += 1;

			DtReportData.Columns.Add(ReportDtCol07);
			DtReportData.Columns.Item(ColIndex).Caption = "Fuel Ratio : ";
			ColIndex += 1;

			DtReportData.Columns.Add(ReportDtCol08);
			DtReportData.Columns.Item(ColIndex).Caption = "Wavelength : ";
			ColIndex += 1;

			DtReportData.Columns.Add(ReportDtCol09);
			DtReportData.Columns.Item(ColIndex).Caption = "Burner Ht. : ";
			ColIndex += 1;

			int intObjCount;

			dtRow = DtReportData.NewRow();

			ColIndex = 1;
			//1  PMT
			dtRow(ColIndex) = (string)Format(gobjInst.PmtVoltage, "#0.0");

			ColIndex += 1;
			//2 current Date
			dtRow(ColIndex) = (string)Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt");

			//3  Ref PMT
			if (!gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				//1.1
				ColIndex += 1;
				dtRow(ColIndex) = (string)Format(gobjInst.PmtVoltageReference, "#0.0");
			}

			ColIndex += 1;
			dtRow(ColIndex) = Format(gobjInst.Current, " #0.0").ToString;

			ColIndex += 1;
			//4  Entry Slit 
			dtRow(ColIndex) = Format(gobjClsAAS203.funcGet_SlitWidth(), "0.0").ToString;

			ColIndex += 1;
			//5 D2 Current
			if (gobjInst.D2Current <= 100) {
				dtRow(ColIndex) = "D2 Off";
			} else {
				dtRow(ColIndex) = gobjInst.D2Current;
			}


			if (!gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam) {
				ColIndex += 1;
				//4.1    Exit slit
				dtRow(ColIndex) = gobjClsAAS203.funcGet_SlitWidth(1);
			}

			ColIndex += 1;
			//6 Inst Mode
			dtRow(ColIndex) = gfuncReturnstrCalMode(gobjInst.Mode);
			//mdblFuelRatio = gobjClsAAS203.funcGet_Fuel_Ratio(True) '10.12.07
			mdblFuelRatio = gobjClsAAS203.funcRead_Fuel_Ratio();
			//10.12.07
			if (mdblFuelRatio < 0.0) {
				mdblFuelRatio = 0.0;
			}
			ColIndex += 1;
			//7  Fuel Ratio
			dtRow(ColIndex) = Format(mdblFuelRatio, "0.00").ToString;

			ColIndex += 1;
			//8  Wavelength
			dtRow(ColIndex) = Format(gobjInst.WavelengthCur, "0.0").ToString;

			ColIndex += 1;
			//9  Burner Height
			dtRow(ColIndex) = Format(gobjClsAAS203.funcConvertToBurnerHeight(gobjInst.BhStep), "0.0").ToString;

			////----- Print Page Header Text

			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);
			//--- "Comments" field is disable in Energy report
			//strPageText = Trim("Comments : " & objInstrumentParameter.Comments)
			//strPageText = ""

			arrGraphControlsList = new ArrayList();
			arrGraphControlsList.Add(PrintGraph_Timescan);

			//objDataTable_PeakValley.TableName = gstrTitleInstrumentType & " SPECTRUM PEAKS AND VALLEYS"

			//objarrMoreTabularData.Add(objDataTable_PeakValley)
			//objclsPrintDocument.PageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter
			GetHeaderFooter = true;
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.EnergySpectrum);

			strPageHeader.TextString = "Timescan Print";
			objclsPrintDocument.PageHeader = strPageHeader;
			objclsPrintDocument.DisplayFont = this.DefaultFont;
			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
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
			if (!(DtMethosDefination == null)) {
				DtMethosDefination = null;
			}
			if (!(objDtElements == null)) {
				objDtElements = null;
			}
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			//---------------------------------------------------------
		}
	}

	public bool funcPrintUV(AAS203.AASGraph PrintGraph, Spectrum.UVSpectrumParameter objInstrumentParameter, string strEquation)
	{
		//=====================================================================
		// Procedure Name        : funcPrintUV
		// Parameters Passed     : AAS203.AASGraph,Spectrum.UVSpectrumParameter,strEquation As String
		// Returns               : True if success
		// Purpose               : Print report of UV Abs.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================
		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "  ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtReportData;
		DataRow dtRow;
		bool GetHeaderFooter;

		try {
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;

			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));
			DataColumn ReportDtCol04 = new DataColumn("Col04", typeof(string));
			DataColumn ReportDtCol05 = new DataColumn("Col05", typeof(string));
			DataColumn ReportDtCol06 = new DataColumn("Col06", typeof(string));
			DataColumn ReportDtCol07 = new DataColumn("Col07", typeof(string));

			////----- Print Page Header Text
			DtReportData = new DataTable();
			DtReportData.TableName = "Sample Graph ";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = " INSTRUMENT CONDITIONS";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(1).Caption = "Sample : ";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(2).Caption = "Date : ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "PMT : ";

			DtReportData.Columns.Add(ReportDtCol04);
			DtReportData.Columns.Item(4).Caption = "D2 Cur : ";

			DtReportData.Columns.Add(ReportDtCol05);
			DtReportData.Columns.Item(5).Caption = "Slit : ";

			DtReportData.Columns.Add(ReportDtCol06);
			DtReportData.Columns.Item(6).Caption = "Speed : ";

			DtReportData.Columns.Add(ReportDtCol07);
			DtReportData.Columns.Item(7).Caption = "Mode : ";



			dtRow = DtReportData.NewRow();
			if (objInstrumentParameter.SpectrumName == "" | objInstrumentParameter.SpectrumName == null) {
				objInstrumentParameter.SpectrumName = "       ";
			}
			//dtRow(0) = strElementName   'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
			dtRow(1) = objInstrumentParameter.SpectrumName;
			//' Added by Pankaj on 06 Sep 07" " 'intObjCount '
			//dtRow(2) = objInstrumentParameter.AnalysisDate     'strElementName' Comment by pankaj on 06 Sep 07

			dtRow(2) = (string)Format(DateTime.Now, "dd-MMM-yyyy hh:mm tt");
			// Added by Pankaj on 06 Sep 07
			dtRow(3) = Format(objInstrumentParameter.PMTV, " #0.0").ToString + " Volts";
			dtRow(4) = objInstrumentParameter.D2Curr + " mA";
			dtRow(5) = Format(objInstrumentParameter.SlitWidth, "0.0").ToString + " nm";
			string strSpeed;
			if (objInstrumentParameter.ScanSpeed == CONST_FASTStep) {
				//Or _
				//objInstrumentParameter.ScanSpeed = CONST_FASTStep_AA201 Then
				strSpeed = "Fast";
				//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
			//Or _
			} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep) {
				//objInstrumentParameter.ScanSpeed = CONST_MEDIUMStep_AA201 Then
				strSpeed = "Medium";
			//Or _
			} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep) {
				//objInstrumentParameter.ScanSpeed = CONST_SLOWStep_AA201 Then 'By Pankaj correcting wrongly written condn
				strSpeed = "Slow";
			}
			//Pankaj for 201
			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				if (objInstrumentParameter.ScanSpeed == CONST_FASTStep_AA201) {
					strSpeed = "Fast";
					//strSpeed = "Slow" 'By Pankaj correcting wrongly written condn
				} else if (objInstrumentParameter.ScanSpeed == CONST_MEDIUMStep_AA201) {
					strSpeed = "Medium";
				} else if (objInstrumentParameter.ScanSpeed == CONST_SLOWStep_AA201) {
					strSpeed = "Slow";
				}

			}
			//End
			dtRow(6) = strSpeed;
			dtRow(7) = gfuncReturnstrCalMode(objInstrumentParameter.Cal_Mode);


			DtReportData.Rows.Add(dtRow);
			objarrMoreTextListData.Add(DtReportData);
			strPageText = Trim("Comments : " + objInstrumentParameter.Comments);


			arrGraphControlsList = new ArrayList();
			arrGraphControlsList.Add(PrintGraph);
			//
			GetHeaderFooter = true;
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.UVSpectrum);
			strPageHeader.TextString = "Spectrum Print";
			objclsPrintDocument.PageHeader = strPageHeader;

			// See the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					//If objclsPrintDocument.PrintToPrinter() = True Then
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
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
			if (!(DtReportData == null)) {
				DtReportData = null;
			}
			arrGraphControlsList = null;
			objarrMoreTextListData = null;
			objarrMoreTabularData = null;
			dtRow = null;
			//---------------------------------------------------------
		}
	}

	public bool funcMultiReport(int[,] arrRunNoList)
	{
		//=====================================================================
		// Procedure Name        : funcMultiReport
		// Parameters Passed     : arrRunNoList as integer array
		// Returns               : TRUE if success
		// Purpose               : Print report of Multiple analysis
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = "   ";
		ArrayList objarrMoreTextListData = new ArrayList();
		ArrayList objarrMoreTabularData = new ArrayList();
		bool GetHeaderFooter;
		try {
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter;

			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			if (funcSetMultiReport(arrRunNoList, objarrMoreTabularData, objarrMoreTextListData) == false) {
				return false;
			}

			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, GetHeaderFooter, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, objarrMoreTextListData, clsPrintDocument.enumReportType.Others);


			//--- View the print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.SendExportData() == true) {
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}

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

	#End Region

	#Region " Private Functions "

	private bool funcSetDatafileTable(ref ArrayList ArrListMoreTabularData, ref ArrayList DtArrDatafile, ref bool blnGetHeaderFooter = false)
	{
		//=====================================================================
		// Procedure Name        :   funcSetDatafileTable
		// Parameters Passed     : 
		// Parameters Affected   : ArrListMoreTabularData As ArrayList,DtArrDatafile As ArrayList,
		//                       : blnGetHeaderFooter
		// Returns               : True if success
		// Purpose               : Set data file results into array object to the print object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                :   Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		string strMethodMode;
		string strStatus;
		string strIsBlank;
		string strD2Curr;
		string strCalculationMode;
		string strElementName;

		int intCount;
		DataTable DtMethosDefination;
		DataTable DtAnalysisParam;
		DataTable DtInstCondition;
		DataTable DtStdSampleData;
		DataTable DtReportData;
		DataTable DtCalculationMode;
		DataTable objDtElements;
		bool blnWvFound;
		int intNoOfDecimalPlaces;
		double dblConcInPpm;
		int intCounter;
		try {
			funcSetDatafileTable = false;
			if (mlngSelectedRunNumber == 0) {
				return false;
			}
			//--- Data table property declaration
			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));


			DataColumn CalculationModeHeader = new DataColumn("HeaderDefination", typeof(string));
			DataColumn CalculationModeDtCol01 = new DataColumn("Col01", typeof(string));

			DataColumn Header1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn DtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn DtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn DtCol03 = new DataColumn("Col03", typeof(string));
			DataColumn DtCol04 = new DataColumn("Col04", typeof(string));
			DataColumn DtCol05 = new DataColumn("Col05", typeof(string));
			DataColumn DtCol06 = new DataColumn("Col06", typeof(string));
			DataColumn DtCol07 = new DataColumn("Col07", typeof(string));
			DataColumn DtCol08 = new DataColumn("Col08", typeof(string));
			DataColumn DtCol09 = new DataColumn("Col09", typeof(string));
			DataColumn DtCol10 = new DataColumn("Col10", typeof(string));
			//--- Data row 
			DataRow dtRow;


			////----- Search Element ID
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (gobjMethodCollection.item(intCount).MethodID == mintSelectedMethodID) {
					intMethodsIdxId = intCount;
					for (intCounter = 0; intCounter <= gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count - 1; intCounter++) {
						if (gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(intCounter).RunNumber == mlngSelectedRunNumber) {
							mlngSelectedRunIndex = intCounter;
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
			}

			if (mlngSelectedRunIndex == -1) {
				return false;
			}
			//--- Detect Enement name from data table
			objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(intMethodsIdxId).InstrumentCondition.ElementID);
			if (!objDtElements == null) {
				if (objDtElements.Rows.Count > 0) {
					strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
				}
				objDtElements = null;
			}

			if (gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count <= 0) {
				return true;
			}

				// Set the object for titel "Quantitative Report" 






				//  ""
				//  ""



				////**********
				// Set the object for "Method Definition"
				//---4.85  12.04.09
				//If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(mlngSelectedRunIndex).ReportParameters.IsMethodInfo = True Then  '---4.85  12.04.09












				//  ""


				//  ""
				//  ""
				//  ""
				//CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfModification, "dd-MM-yyyy HH:MM"))   '  ""                    

				//CStr(Format(gobjMethodCollection.item(intInstId).DateOfLastUse, "dd-MM-yyyy HH:MM"))   '  ""
				//  ""


				// Set the object for "Analysis Parameters"

				//Dim AnalysisParamDtCol10 As New DataColumn("Col10", GetType(String))













				//If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtUnits.Rows.Item(i).Item(0) Then
				//If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtMeasurementMode.Rows.Item(i).Item(0) Then


				//  ""
				//CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.MeasurementMode)
				//CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.Unit)
				////****************
				// Set the object for "Instrument Condition"



















				////-----
				//If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current <= 100 Then
				//    strD2Curr = "OFF"
				//Else
				//    strD2Curr = CStr(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current)
				//End If

				//dtRow(0) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.ElementName
				//dtRow(1) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.TurretNumber.ToString

				//If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count > 0 Then
				//    For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
				//        If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
				//            blnWvFound = True
				//            Exit For
				//        End If
				//    Next
				//    If blnWvFound = True Then
				//        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
				//    Else
				//        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(0).Item(2), "0.0")
				//    End If
				//Else
				//    dtRow(2) = 0.0
				//End If

				//dtRow(3) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.LampCurrent, "0.0")
				//dtRow(4) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.SlitWidth, "0.0").ToString
				//dtRow(5) = strD2Curr
				//dtRow(6) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.FuelRatio, "0.00").ToString
				//dtRow(7) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.PmtVoltage, "####").ToString
				//dtRow(8) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.BurnerHeight, "0.00").ToString
				////-----

				//.InstrumentParameterForRunNumber.ElementName
				////----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
				////-----
				//For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
				//If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
				//dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
				//dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode

				//by pankaj for lamp current=0 if emmission mode



				////----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
				////-----
				///If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
				///    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
				///        If .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(5) Then
				///            blnWvFound = True
				///            Exit For
				///        End If
				///    Next
				///    If blnWvFound = True Then
				///        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
				///    Else
				///        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(0).Item(2), 2)
				///    End If
				///Else
				///    dtRow(2) = 0.0
				///End If
				//dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode
				//dtRow(3) = 0 'by pankaj for lamp current=0 if emmission mode
				//by pankaj for lamp current=0 if emmission mode


				//dtRow(8) = FormatNumber(.InstrumentParameterForRunNumber.BurnerHeight, 1).ToString ' code commented by :dinesh wagh on 24.3.2009


				// code added by: dinesh wagh on 24.3.2009
				// code start
				// code ends





				////*******************
				// Set the object for "Calculation Mode"









				////****************

				// Set the object for detail info "Standard/Sample Information"



				//Dim StdSampleDtCol08 As New DataColumn("Col08", GetType(String))
				//Dim StdSampleDtCol09 As New DataColumn("Col09", GetType(String))
				//Dim StdSampleDtCol10 As New DataColumn("Col10", GetType(String))

				//unit = .AnalysisParameters.Unit


				//DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Emission"     ' Added by Sachin Dokhale on ref. VCK
				// Added by Deepak Bhati with ref. to VCK/Ramesh on 26.07.09


				//---commented on 27.03.09
				//'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppm)"
				//-------------

				//---written on 27.03.09
				//---------



				/// code commenented by : dinesh wagh on 27.3.2009
				///.......
				//'If unit = 1 Then
				//'    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in ppm"
				//'Else
				//'    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
				//'    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in %"
				//'End If
				///........

				// code added by :dinesh wagh on 27.3.2009
				// code start
				//DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
				//code ends

				//  ""


				//dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, intNoOfDecimalPlaces))


				// dtRow(intColIndexCount) = CStr(Format(.StandardDataCollection(intCount).Concentration, "0.000"))
				//dtRow(7) = ""
				// Set the object for detail info "Sample Information"
				//dtRow(intColIndexCount) = CStr(.SampleDataCollection(intCount).SampleName)         '  ""
				//  ""

				//dtRow(intColIndexCount) = CStr(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight)
				//By PAnkaj for formatting upto 4 digit
				////----- added by Sachin Dokhale on 29.05.07
				//dblConc = Format(gobjclsStandardGraph.Get_Conc(.SampleDataCollection(intCount).Abs, 0.0), "0.000")

				//dblConc = .SampleDataCollection(intCount).Conc
				//dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))
				//dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))

				//Dim dblConcInPercent As Double


				//---27.03.09
				//'If unit = 1 Then
				//'    'dtRow(intColIndexCount) = CStr(FormatNumber(dblConc, intNoOfDecimalPlaces))
				//'    dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
				//'    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
				//'Else
				//'    'dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
				//'    dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
				//'    dblConcInPercent = dblConcInPercent * 100
				//'    'dtRow(7) = ""
				//'    'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "###0.00#####"))
				//'    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPercent, intNoOfDecimalPlaces))
				//'End If
				//-----

				//---27.03.09
				//--------------


				//dblConcInPercent = (dblConc * samp.Volume * samp.DilutionFactor * Math.Pow(10, -6)) / samp.Weight

				////***************

				//Add the result objects into array list
			 // ERROR: Not supported in C#: WithStatement


			funcSetDatafileTable = true;

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
			if (!DtMethosDefination == null) {
				DtMethosDefination = null;
			}
			if (!DtAnalysisParam == null) {
				DtAnalysisParam = null;
			}
			if (!DtInstCondition == null) {
				DtInstCondition = null;
			}
			if (!DtStdSampleData == null) {
				DtStdSampleData = null;
			}
			if (!DtReportData == null) {
				DtReportData = null;
			}
			if (!DtCalculationMode == null) {
				DtCalculationMode = null;
			}
			//---------------------------------------------------------
		}
	}

	private bool funcSetDatafileTableForMethod(ref ArrayList ArrListMoreTabularData, ref ArrayList DtArrDatafile, ref bool blnGetHeaderFooter = false)
	{
		//=====================================================================
		// Procedure Name        :   funcSetDatafileTableForMethod
		// Parameters Passed     : 
		// Parameters Affected   : ArrListMoreTabularData As ArrayList,DtArrDatafile As ArrayList,
		//                       : blnGetHeaderFooter
		// Returns               : True if success
		// Purpose               : Set data file results into array object to the print object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                :   pankaj bamb
		// Created               : 21 feb 08
		// Revisions             : 
		//=====================================================================

		string strMethodMode;
		string strStatus;
		string strIsBlank;
		string strD2Curr;
		string strCalculationMode;
		string strElementName;

		int intCount;
		DataTable DtMethosDefination;
		DataTable DtAnalysisParam;
		DataTable DtInstCondition;
		DataTable DtStdSampleData;
		DataTable DtReportData;
		DataTable DtCalculationMode;
		DataTable objDtElements;
		bool blnWvFound;
		int intNoOfDecimalPlaces;
		double dblConcInPpm;
		int intCounter;
		try {
			funcSetDatafileTableForMethod = false;
			if (mlngSelectedRunNumber == 0) {
				return false;
			}
			//--- Data table property declaration
			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));


			DataColumn CalculationModeHeader = new DataColumn("HeaderDefination", typeof(string));
			DataColumn CalculationModeDtCol01 = new DataColumn("Col01", typeof(string));

			DataColumn Header1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn DtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn DtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn DtCol03 = new DataColumn("Col03", typeof(string));
			DataColumn DtCol04 = new DataColumn("Col04", typeof(string));
			DataColumn DtCol05 = new DataColumn("Col05", typeof(string));
			DataColumn DtCol06 = new DataColumn("Col06", typeof(string));
			DataColumn DtCol07 = new DataColumn("Col07", typeof(string));
			DataColumn DtCol08 = new DataColumn("Col08", typeof(string));
			DataColumn DtCol09 = new DataColumn("Col09", typeof(string));
			DataColumn DtCol10 = new DataColumn("Col10", typeof(string));
			//--- Data row 
			DataRow dtRow;


			////----- Search Element ID
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (gobjMethodCollection.item(intCount).MethodID == mintSelectedMethodID) {
					intMethodsIdxId = intCount;
					for (intCounter = 0; intCounter <= gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count - 1; intCounter++) {
						if (gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection(intCounter).RunNumber == mlngSelectedRunNumber) {
							mlngSelectedRunIndex = intCounter;
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
			}

			if (mlngSelectedRunIndex == -1) {
				return false;
			}
			//--- Detect Enement name from data table
			objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(intMethodsIdxId).InstrumentCondition.ElementID);
			if (!objDtElements == null) {
				if (objDtElements.Rows.Count > 0) {
					strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
				}
				objDtElements = null;
			}

			if (gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Count <= 0) {
				return true;
			}

				// Set the object for titel "Quantitative Report" 






				//  ""
				//dtRow(2) = CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfLastUse, "dd-MMM-yyyy hh:mm tt"))   '  "" 'commented by ; dinesh wagh on 10.2.2010
				//code added by ; dinesh wagh on 10.2.2010




				////**********
				// Set the object for "Method Definition"
				//If gobjMethodCollection.item(intInstId).ReportParameters.IsMethodInfo = True Then












				//  ""


				//  ""
				//  ""
				//  ""
				//CStr(Format(gobjMethodCollection.item(intMethodsIdxId).DateOfModification, "dd-MM-yyyy HH:MM"))   '  ""                    

				//CStr(Format(gobjMethodCollection.item(intInstId).DateOfLastUse, "dd-MM-yyyy HH:MM"))   '  ""
				//  ""


				// Set the object for "Analysis Parameters"

				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAnalysisParameters = True Then '4.85 12.04.09
				//4.85 12.04.09


				//Dim AnalysisParamDtCol10 As New DataColumn("Col10", GetType(String))













				//If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtUnits.Rows.Item(i).Item(0) Then
				//If gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).AnalysisParameters.Unit = objDtMeasurementMode.Rows.Item(i).Item(0) Then


				//  ""
				//CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.MeasurementMode)
				//CStr(gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mintSelectedRunIndex).AnalysisParameters.Unit)
				////****************
				// Set the object for "Instrument Condition"

				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsInstrumentCondition = True Then   '4.85 12.04.09
				//4.85 12.04.09




















				////-----
				//If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current <= 100 Then
				//    strD2Curr = "OFF"
				//Else
				//    strD2Curr = CStr(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.D2Current)
				//End If

				//dtRow(0) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.ElementName
				//dtRow(1) = gobjMethodCollection(intMethodsIdxId).InstrumentCondition.TurretNumber.ToString

				//If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count > 0 Then
				//    For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
				//        If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
				//            blnWvFound = True
				//            Exit For
				//        End If
				//    Next
				//    If blnWvFound = True Then
				//        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
				//    Else
				//        dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(0).Item(2), "0.0")
				//    End If
				//Else
				//    dtRow(2) = 0.0
				//End If

				//dtRow(3) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.LampCurrent, "0.0")
				//dtRow(4) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.SlitWidth, "0.0").ToString
				//dtRow(5) = strD2Curr
				//dtRow(6) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.FuelRatio, "0.00").ToString
				//dtRow(7) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.PmtVoltage, "####").ToString
				//dtRow(8) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.BurnerHeight, "0.00").ToString
				////-----

				//.InstrumentParameterForRunNumber.ElementName
				////----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
				////-----
				//For intCount = 0 To gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Count - 1
				//If gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(5) Then
				//dtRow(2) = Format(gobjMethodCollection(intMethodsIdxId).InstrumentCondition.Wavelength.Rows.Item(intCount).Item(2), "0.0")
				//dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode

				//by pankaj for lamp current=0 if emmission mode



				////----- Modified by Sachin On 31.08.07 Ref. Adding new Wv. field for Emission Mode
				////-----
				///If .InstrumentParameterForRunNumber.Wavelength.Rows.Count > 0 Then
				///    For intCount = 0 To .InstrumentParameterForRunNumber.Wavelength.Rows.Count - 1
				///        If .InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(5) Then
				///            blnWvFound = True
				///            Exit For
				///        End If
				///    Next
				///    If blnWvFound = True Then
				///        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(intCount).Item(2), 2)
				///    Else
				///        dtRow(2) = FormatNumber(.InstrumentParameterForRunNumber.Wavelength.Rows.Item(0).Item(2), 2)
				///    End If
				///Else
				///    dtRow(2) = 0.0
				///End If
				//dtRow(3) = FormatNumber(.InstrumentParameterForRunNumber.LampCurrent, 1) 'comment 'by pankaj for lamp current=0 if emmission mode
				//dtRow(3) = 0 'by pankaj for lamp current=0 if emmission mode
				//by pankaj for lamp current=0 if emmission mode



				// code added by:dinesh wagh on 24.3.2009
				// code start
				// code ends

				// dtRow(8) = FormatNumber(.InstrumentParameterForRunNumber.BurnerHeight, 1).ToString ' code commented by : dinesh wagh on 24.3.2009



				////*******************
				// Set the object for "Calculation Mode"









				////****************

				// Set the object for detail info "Standard/Sample Information"



				//Dim StdSampleDtCol08 As New DataColumn("Col08", GetType(String))
				//Dim StdSampleDtCol09 As New DataColumn("Col09", GetType(String))
				//Dim StdSampleDtCol10 As New DataColumn("Col10", GetType(String))

				//unit = .AnalysisParameters.Unit

				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then   '4.85 12.04.09
				//4.85 12.04.09


				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then    '4.85 12.04.09
				//4.85 12.04.09

				// Added by Sachin Dokhale on ref. VCK
				// Added by Deepak Bhati with ref. to VCK/Ramesh on 26.07.09


				//---commented on 27.03.09
				//'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. (ppm)"
				//-----------

				//---written on 27.03.09
				//---------



				/// code commented by :dinesh wagh on 27.3.2009
				/// ........
				//'If unit = 1 Then
				//'    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc. in ppm"
				//'Else
				//'    'DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
				//'    DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in %"
				//'End If
				///..................

				// code added by : dinesh wagh on 27.3.2009
				//code start
				//DtStdSampleData.Columns.Item(intColIndexCount).Caption = "Conc.in Unit"
				// code ends

				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsStandards = True Then   '4.85 12.04.09
				//4.85 12.04.09

				//  ""

				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then  '4.85 12.04.09
				//4.85 12.04.09


				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then  '4.85 12.04.09
				//4.85 12.04.09

				//dtRow(intColIndexCount) = CStr(FormatNumber(.StandardDataCollection(intCount).Abs, intNoOfDecimalPlaces))


				// dtRow(intColIndexCount) = CStr(Format(.StandardDataCollection(intCount).Concentration, "0.000"))
				//dtRow(7) = ""
				// Set the object for detail info "Sample Information"
				//  ""
				//dtRow(intColIndexCount) = CStr(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).SampleName)         '  ""

				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsWeightVolumeDilution = True Then  '4.85 12.04.09
				//4.85 12.04.09

				//dtRow(intColIndexCount) = CStr(gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight)
				//By PAnkaj for formatting upto 4 digit

				//If gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsAbsorbance = True Then   '4.85 12.04.09
				//4.85 12.04.09

				////----- added by Sachin Dokhale on 29.05.07
				//dblConc = Format(gobjclsStandardGraph.Get_Conc(.SampleDataCollection(intCount).Abs, 0.0), "0.000")

				//dblConc = .SampleDataCollection(intCount).Conc
				//dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))
				//dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "0.000"))

				//Dim dblConcInPercent As Double


				//---commented on 27.03.09
				//'If unit = 1 Then
				//'    'dtRow(intColIndexCount) = CStr(FormatNumber(dblConc, intNoOfDecimalPlaces))
				//'    dblConcInPpm = (dblConc * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor) / gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight
				//'    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPpm, intNoOfDecimalPlaces))
				//'Else
				//'    'dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).SampleDataCollection(intCount).Weight
				//'    dblConcInPercent = (dblConc * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Volume * gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(intMethodsIdxId).QuantitativeDataCollection.Item(mlngSelectedRunIndex).SampleDataCollection(intCount).Weight
				//'    dblConcInPercent = dblConcInPercent * 100

				//'    'dtRow(7) = ""
				//'    'dtRow(intColIndexCount) = CStr(Format(.SampleDataCollection(intCount).Conc, "###0.00#####"))
				//'    dtRow(intColIndexCount) = CStr(FormatNumber(dblConcInPercent, intNoOfDecimalPlaces))
				//'End If
				//--------

				//---written on 27.03.09
				//--------

				//dblConcInPercent = (dblConc * samp.Volume * samp.DilutionFactor * Math.Pow(10, -6)) / samp.Weight

				////***************

				//blnGetHeaderFooter = gobjMethodCollection.item(intMethodsIdxId).ReportParameters.IsReportHeaderAndFooter  '4.85 12.04.09
				//4.85 12.04.09

				//Add the result objects into array list
				//--4.85 12.04.09
				//Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportHeader)
				//Call ArrListMoreTabularData.Add(gobjMethodCollection.item(intMethodsIdxId).ReportParameters.ReportFooter)
				//--4.85 12.04.09

				//----4.85 12.04.09
				//-----
			 // ERROR: Not supported in C#: WithStatement


			funcSetDatafileTableForMethod = true;

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
			if (!DtMethosDefination == null) {
				DtMethosDefination = null;
			}
			if (!DtAnalysisParam == null) {
				DtAnalysisParam = null;
			}
			if (!DtInstCondition == null) {
				DtInstCondition = null;
			}
			if (!DtStdSampleData == null) {
				DtStdSampleData = null;
			}
			if (!DtReportData == null) {
				DtReportData = null;
			}
			if (!DtCalculationMode == null) {
				DtCalculationMode = null;
			}
			//---------------------------------------------------------
		}
	}

	private bool funcSetMultiReport(int[,] arrRunNoList, ref ArrayList ArrListMoreTabularData, ref ArrayList DtArrDatafile)
	{
		//=====================================================================
		// Procedure Name        : funcSetMultiReport
		// Parameters Passed     : arrRunNoList array holds Selected Run No of perticulor Method
		// Parameters Affected   : ArrListMoreTabularData  array list return the detail records of result
		//                       : DtArrDatafile array list return the parent records of result
		// Returns               : True if success
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : Method collection object must be present.
		// Author                : Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		string strMethodMode;

		DataTable DtStdSampleData;
		DataTable DtReportData;
		DataTable objDtElements;
		DataTable objDtRunNos;
		//Sauarbh
		int intCount;
		int intFstDimeUpperBoundLength;
		int intSndDimeUpperBoundLength;
		int intInstId;
		int intCount2;
		int intColCounter;
		int intCount3;
		int intLastPos;
		int TempCount;
		string strElementName;
		string strRunNo;
		//Saurabh
		string strRunNos;
		funcSetMultiReport = false;
		try {
			// Filter out the detail records of result
			DataColumn ReportHeader1 = new DataColumn("HeaderDefination", typeof(string));
			DataColumn ReportDtCol01 = new DataColumn("Col01", typeof(string));
			DataColumn ReportDtCol02 = new DataColumn("Col02", typeof(string));
			DataColumn ReportDtCol03 = new DataColumn("Col03", typeof(string));
			DataColumn StdSampleDtCol01 = new DataColumn("Sample_ID", typeof(string));
			DataColumn RunNoDtCol01 = new DataColumn("RunNo_ID", typeof(string));
			//Saurabh   15.07.07
			DataRow dtRow;
			DataRow dtSingleRow;
			string[] arrstrRunNo;

			//With gobjMethodCollection.item(mintSelectedMethodID).QuantitativeDataCollection(mintSelectedRunNumber)
			for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
				if (gobjMethodCollection.item(intCount).MethodID == mintSelectedMethodID) {
					//If gobjMethodCollection(intCount).SelectedElementID = gobjMethodCollection(intCount).InstrumentCondition.ElementID Then
					intInstId = intCount;
					break; // TODO: might not be correct. Was : Exit For
					//End If
				}
			}

			DtReportData = new DataTable();
			DtReportData.TableName = "MULTI-ELEMENT REPORT";

			DtReportData.Columns.Add(ReportHeader1);
			DtReportData.Columns.Item(0).Caption = "MULTI-ELEMENT REPORT";

			DtReportData.Columns.Add(ReportDtCol01);
			DtReportData.Columns.Item(1).Caption = "Lab Name ";

			DtReportData.Columns.Add(ReportDtCol02);
			DtReportData.Columns.Item(2).Caption = "Analyst Name ";

			DtReportData.Columns.Add(ReportDtCol03);
			DtReportData.Columns.Item(3).Caption = "Sample Name ";

			//

			dtSingleRow = DtReportData.NewRow();

			//dtRow(1) = CStr(gobjMethodCollection.item(intInstId).QuantitativeDataCollection(0).AnalysisParameters.LabName)     '  ""
			dtSingleRow(1) = (string)gobjMethodCollection.item(intInstId).AnalysisParameters.LabName;
			dtSingleRow(2) = (string)gobjMethodCollection.item(intInstId).UserName;
			//gobjMethodCollection.item(arrRunNoList(0, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(0, 1) - 1).SampleDataCollection.Count()


			//dtRow(3) = CStr(gobjMethodCollection.item(intInstId).QuantitativeDataCollection(RunNumber).SampleDataCollection.item(0).SampleName)
			//dtRow(3) = CStr(gobjMethodCollection.item(arrRunNoList(0, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(0, 1) - 1).SampleDataCollection.item(0).SampleName)
			dtSingleRow(3) = (string)gobjMethodCollection.item(arrRunNoList(0, 0) - 1).SampleDataCollection.item(0).SampleName;


			//DtReportData.Rows.Add(dtSingleRow)
			//Call DtArrDatafile.Add(DtReportData)

			////****************

			// Filter out the parent records of result
			intFstDimeUpperBoundLength = arrRunNoList.GetUpperBound(0);
			intSndDimeUpperBoundLength = arrRunNoList.GetUpperBound(1);


			DtStdSampleData = new DataTable();

			DtStdSampleData.TableName = "Sample Information";


			DtStdSampleData.Columns.Add(StdSampleDtCol01);
			DtStdSampleData.Columns.Item(0).Caption = "Sample Name";

			//Saurabh for Adding Run Nos. to the report 12.07.07
			objDtRunNos = new DataTable();
			objDtRunNos.TableName = " ";
			objDtRunNos.Columns.Add(RunNoDtCol01);
			objDtRunNos.Columns.Item(0).Caption = "Run Numbers";
			//Saurabh for Adding Run Nos. to the report 12.07.07


			for (intCount = 0; intCount <= intFstDimeUpperBoundLength; intCount++) {
				if (gobjMethodCollection.Count > 0) {
					for (intCount2 = 1; intCount2 <= intSndDimeUpperBoundLength; intCount2++) {
						//If gobjMethodCollection.Count > 0 Then
						if ((arrRunNoList(intCount, intCount2) - 1) > -1) {
							DtStdSampleData.Columns.Add(new DataColumn("Col" + Format(intColCounter + 1, "00"), typeof(string)));
							//objDtRunNos.Columns.Add(New DataColumn("Col" & Format(intColCounter + 1, "00"), GetType(String)))
							////----- Search Element ID
							objDtElements = gobjDataAccess.GetCookBookData(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).InstrumentCondition.ElementID);
							if (!objDtElements == null) {
								if (objDtElements.Rows.Count > 0) {
									strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
								}
							}
							//Saurabh for RunNos
							//strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(0).RunNumber
							//strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).RunNumber()
							//
							strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection(arrRunNoList(intCount, intCount2) - 1).RunNumber;
							if (funcAddRunNoString(strRunNo, arrstrRunNo)) {
								objDtRunNos.Columns.Add(new DataColumn("Col_" + Format(intColCounter + 1, "00"), typeof(string)));
								objDtRunNos.Columns.Item(intColCounter + 1).Caption = strRunNo;
							}
							//Saurabh
							DtStdSampleData.Columns.Item(intColCounter + 1).Caption = strElementName;
							//gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).InstrumentConditions(0).ElementName()
							////-----
							intColCounter += 1;
						}
						//End If
					}
				} else {
					return false;
				}
			}



			////----- find last Record
			TempCount = 0;
			intColCounter = 0;
			for (intCount = 0; intCount <= intFstDimeUpperBoundLength; intCount++) {
				if ((arrRunNoList(intCount, 0) - 1) > -1) {
					if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Count > 0) {
						for (intCount2 = 1; intCount2 <= intSndDimeUpperBoundLength; intCount2++) {
							if ((arrRunNoList(intCount, intCount2) - 1) > -1) {
								if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.Count > 0) {
									//dtRow(intCount2 + 1) = CStr(gobjMethodCollection.item(arrRunNoList(intCount, 0)).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2)).SampleDataCollection.item(intCount3).Conc)
									TempCount = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.Count;
									if (TempCount > intLastPos) {
										intLastPos = TempCount;
									}

								}
							}
						}
					} else {
						//Return False
					}
				}
			}

			////----- 
			//intLastPos = intFstDimeUpperBoundLength
			double dblConc;
			intCount3 = 0;
			while (intCount3 < intLastPos) {
				intColCounter = 0;
				dtRow = DtStdSampleData.NewRow();
				dtRow(0) = "Sample " + (intCount3 + 1).ToString;
				for (intCount = 0; intCount <= intFstDimeUpperBoundLength; intCount++) {
					if ((arrRunNoList(intCount, 0) - 1) > -1) {
						if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Count > 0) {
							for (intCount2 = 1; intCount2 <= intSndDimeUpperBoundLength; intCount2++) {
								if ((arrRunNoList(intCount, intCount2) - 1) > -1) {
									if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.Count > intCount3) {
										//'Commented by pankaj on 20 Feb 08
										//'dtRow(intColCounter + 1) = CStr(Format(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc, "0.000"))
										//'Added by Pankaj on 20 Feb 08
										dblConc = 0;
										//If gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).AnalysisParameters.Unit = 1 Then 'from method
										if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).AnalysisParameters.Unit == enumUnit.PPM) {
											if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight > 0) {
												//'dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).DilutionFactor) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Weight 'from method
												dblConc = (double)gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).DilutionFactor / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight;
											}
											dtRow(intColCounter + 1) = (string)Format(dblConc, "0.0000") + " ";
										} else if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).AnalysisParameters.Unit == enumUnit.Percent) {
											if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight > 0) {
												//'dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).DilutionFactor * Math.Pow(10, -6)) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Weight 'from method
												dblConc = (double)gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).DilutionFactor * Math.Pow(10, -6) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight;
												dblConc = dblConc * 100;
											}
											dtRow(intColCounter + 1) = (string)Format(dblConc, "0.0000") + "%";

										//---27.03.09
										} else if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).AnalysisParameters.Unit == enumUnit.PPB) {
											if (gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight > 0) {
												//'dblConc = CDbl(gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).DilutionFactor) / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).SampleDataCollection.item(intCount3).Weight 'from method
												dblConc = (double)gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Conc * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Volume * gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).DilutionFactor / gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).SampleDataCollection.item(intCount3).Weight;
											}
											dtRow(intColCounter + 1) = (string)Format(dblConc, "0.0000") + " ";
										}
									//'dtRow(intColCounter + 1) = CStr(Format(dblConc, "0.000"))

									//'------------------------

									} else {
										dtRow(intColCounter + 1) = "-";
									}
									intColCounter += 1;
									//strRunNo = gobjMethodCollection.item(arrRunNoList(intCount, 0) - 1).QuantitativeDataCollection.Item(arrRunNoList(intCount, intCount2) - 1).RunNumber()
									//funcAddRunNoString(strRunNo, arrstrRunNo, RunNoString)

								}

							}
						} else {
							//    Return False
						}
					}
				}
				DtStdSampleData.Rows.Add(dtRow);
				intCount3 += 1;
			}
			////***************
			//dtSingleRow(4) = RunNoString
			DtReportData.Rows.Add(dtSingleRow);

			//Add the result objects into array list
			DtArrDatafile.Add(DtReportData);
			ArrListMoreTabularData.Add(objDtRunNos);
			ArrListMoreTabularData.Add(DtStdSampleData);
			//End With

			funcSetMultiReport = true;

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

			if (!DtStdSampleData == null) {
				DtStdSampleData = null;
			}
			if (!DtReportData == null) {
				DtReportData = null;
			}
			if (!objDtElements == null) {
				objDtElements = null;
			}
			//---------------------------------------------------------
		}
	}

	private bool funcAddRunNoString(string strRunNo, ref string[] arrstrRunNo)
	{
		//=====================================================================
		// Procedure Name        : funcAddRunNoString
		// Parameters Passed     : strRunNo, arrstrRunNo()
		// Returns               : True if success adding of Run No into array.
		// Purpose               : To adding of Run No into multidimention array.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Monday, January 31, 2005
		// Revisions             : 1
		//=====================================================================
		int arrIdx;
		bool blnFoundRunNo = false;

		try {
			if (!(arrstrRunNo == null)) {
				for (arrIdx = 0; arrIdx <= arrstrRunNo.GetUpperBound(0); arrIdx++) {
					if (strRunNo == arrstrRunNo(arrIdx)) {
						blnFoundRunNo = true;
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			if (blnFoundRunNo == false) {
				if (!(arrstrRunNo == null)) {
					Array.Resize(ref arrstrRunNo, arrstrRunNo.GetUpperBound(0) + 2);
				} else {
					Array.Resize(ref arrstrRunNo, 1);
				}
				arrstrRunNo(arrstrRunNo.GetUpperBound(0)) = strRunNo;
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
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}

		}
	}

	private clsPrintDocument funcSetPrintDocument(clsReportingMode.structReportFormat objstructReportFormatIn, clsPrintDocument.struHeaderString strPageHeaderIn, string strPageTextIn, bool blnGetHeaderFooter, ArrayList arrGraphControlsListIn, ArrayList arrDtTablesListIn, DataTable objDtImagesListIn, ArrayList arrDtTextListIn, clsPrintDocument.enumReportType intReportTypeIn)
	{
		//=====================================================================
		// Procedure Name        : funcSetPrintDocument
		// Parameters Passed     : As above
		// Returns               : True or false
		// Purpose               : To set the clsPrintDocument object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Monday, January 31, 2005
		// Revisions             : 1
		//=====================================================================
		int intCount;
		DataTable objDtTable2In;
		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		System.Drawing.Font FontStyles = DefaultFont;
		//=Me.DefaultFont
		bool blnSeekFooter = false;
		AAS203.clsPrintDocument.struHeaderString struRptHeader;
		AAS203.clsPrintDocument.struHeaderString struRotFooter;
		try {
			//--- Seting Report format and text object
			////----- commented by Sachin Dokhale as per Requirement
			objstructReportFormatIn.IsDisplayReportTitle = false;
			objstructReportFormatIn.IsDisplayReportHeader = blnGetHeaderFooter;
			objstructReportFormatIn.IsDisplayReportFooter = blnGetHeaderFooter;
			objstructReportFormatIn.IsDisplayCompanyLogo = false;
			objstructReportFormatIn.LogoAlignment = 1;
			//Left()
			objstructReportFormatIn.LogoFileName = Application.StartupPath + "\\" + "CHEMITO.BMP";
			//"D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"
			objclsPrintDocument.ReportFormat = objstructReportFormatIn;

			objclsPrintDocument.PageText = strPageTextIn;
			objclsPrintDocument.DisplayFont = this.DefaultFont;
			objclsPrintDocument.TableHeaderFont = FontStyles;
			objclsPrintDocument.ReportImageList = objDtImagesListIn;
			objclsPrintDocument.ReportType = intReportTypeIn;
			objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate;
			objclsPrintDocument.PageSetting = gobjPageSetting;

			//---Set Property ReportDataTables
			if (IsNothing(arrDtTablesListIn) == false) {
				objclsPrintDocument.ReportDataTables = new ArrayList();
				for (intCount = 0; intCount <= arrDtTablesListIn.Count - 1; intCount++) {
					if (arrDtTablesListIn.Item(intCount) is DataTable) {
						objDtTable2In = arrDtTablesListIn.Item(intCount);
						if (IsNothing(objDtTable2In) == false) {
							objclsPrintDocument.ReportDataTables.Add(objDtTable2In);
						}
					}
				}

				struRptHeader = new AAS203.clsPrintDocument.struHeaderString();
				struRotFooter = new AAS203.clsPrintDocument.struHeaderString();
				struRptHeader.TextFormat = new clsReportHeaderFormat();
				struRotFooter.TextFormat = new clsReportHeaderFormat();
				struRptHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;
				struRotFooter.TextFormat.Alignment = ContentAlignment.MiddleLeft;
				objclsPrintDocument.PageHeader = struRptHeader;
				for (intCount = 0; intCount <= arrDtTablesListIn.Count - 1; intCount++) {
					if (arrDtTablesListIn.Item(intCount) is string) {
						if (blnSeekFooter == false) {
							struRptHeader.TextString = (string)arrDtTablesListIn.Item(intCount);
							objclsPrintDocument.PageHeader = struRptHeader;
							//CStr(arrDtTablesListIn.Item(intCount))
						}
						if (blnSeekFooter == true) {
							struRotFooter.TextString = arrDtTablesListIn.Item(intCount);
							objclsPrintDocument.ReportFooter = struRotFooter;
						}
						blnSeekFooter = true;
					}
				}
			}

			//---Set Property ReportGraphControls
			if (IsNothing(arrGraphControlsListIn) == false) {
				objclsPrintDocument.ReportGraphControls = new ArrayList();
				for (intCount = 0; intCount <= arrGraphControlsListIn.Count - 1; intCount++) {
					if (IsNothing(arrGraphControlsListIn.Item(intCount)) == false) {
						objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount));
					}
				}
			}

			if (IsNothing(arrDtTextListIn) == false) {
				objclsPrintDocument.ReportTextList = new ArrayList();
				for (intCount = 0; intCount <= arrDtTextListIn.Count - 1; intCount++) {
					if (IsNothing(arrDtTextListIn.Item(intCount)) == false) {
						objclsPrintDocument.ReportTextList.Add(arrDtTextListIn.Item(intCount));
					}
				}
			}

			//--- Return the clsPrintDocument object
			return objclsPrintDocument;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!IsNothing(objclsPrintDocument) == true) {
				objclsPrintDocument.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private clsPrintDocument funcSetPrintDocument(clsReportingMode.structReportFormat objstructReportFormatIn, clsPrintDocument.struHeaderString strPageHeaderIn, string strPageTextIn, bool blnGetHeaderFooter, ArrayList arrDtTablesListIn, ArrayList arrDtTextListIn, clsPrintDocument.enumReportType intReportTypeIn)
	{
		//=====================================================================
		// Procedure Name        : funcSetPrintDocument
		// Parameters Passed     : As above
		// Returns               : True or false
		// Purpose               : To set the clsPrintDocument object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Monday, January 31, 2005
		// Revisions             : 1
		//=====================================================================
		int intCount;
		DataTable objDtTable2In;
		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		System.Drawing.Font FontStyles = DefaultFont;
		//=Me.DefaultFont
		try {
			//Seting Report format and text
			////----- commented by Sachin Dokhale as per Requirement
			objstructReportFormatIn.IsDisplayReportTitle = false;
			objstructReportFormatIn.IsDisplayReportHeader = blnGetHeaderFooter;
			objstructReportFormatIn.IsDisplayReportFooter = blnGetHeaderFooter;
			objstructReportFormatIn.IsDisplayCompanyLogo = false;
			objstructReportFormatIn.LogoAlignment = 1;
			//Left()
			objstructReportFormatIn.LogoFileName = Application.StartupPath + "\\" + "CHEMITO.BMP";
			//"D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"

			//'gobjNewMethod.ReportParameters.
			objclsPrintDocument.ReportFormat = objstructReportFormatIn;

			objclsPrintDocument.PageText = strPageTextIn;
			objclsPrintDocument.DisplayFont = this.DefaultFont;
			objclsPrintDocument.TableHeaderFont = FontStyles;
			objclsPrintDocument.ReportType = intReportTypeIn;
			objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate;
			objclsPrintDocument.PageSetting = gobjPageSetting;

			//'---Set Property ReportDataTables
			if (IsNothing(arrDtTablesListIn) == false) {
				objclsPrintDocument.ReportDataTables = new ArrayList();
				for (intCount = 0; intCount <= arrDtTablesListIn.Count - 1; intCount++) {
					if (arrDtTablesListIn.Item(intCount) is DataTable) {
						objDtTable2In = arrDtTablesListIn.Item(intCount);
						if (IsNothing(objDtTable2In) == false) {
							objclsPrintDocument.ReportDataTables.Add(objDtTable2In);
						}
					}
				}

				bool blnSeekFooter = false;
				AAS203.clsPrintDocument.struHeaderString struRptHeader = new AAS203.clsPrintDocument.struHeaderString();
				AAS203.clsPrintDocument.struHeaderString struRotFooter = new AAS203.clsPrintDocument.struHeaderString();
				struRptHeader.TextFormat = new clsReportHeaderFormat();
				struRotFooter.TextFormat = new clsReportHeaderFormat();
				struRptHeader.TextFormat.Alignment = ContentAlignment.MiddleLeft;
				//struRotFooter.TextFormat.Alignment = ContentAlignment.MiddleCenter
				struRotFooter.TextFormat.Alignment = ContentAlignment.MiddleLeft;

				for (intCount = 0; intCount <= arrDtTablesListIn.Count - 1; intCount++) {
					if (arrDtTablesListIn.Item(intCount) is string) {
						if (blnSeekFooter == false) {
							struRptHeader.TextString = (string)arrDtTablesListIn.Item(intCount);
							objclsPrintDocument.PageHeader = struRptHeader;
							//CStr(arrDtTablesListIn.Item(intCount))
						}
						if (blnSeekFooter == true) {
							struRotFooter.TextString = arrDtTablesListIn.Item(intCount);
							objclsPrintDocument.ReportFooter = struRotFooter;
						}
						blnSeekFooter = true;
					}
				}
			}



			if (IsNothing(arrDtTextListIn) == false) {
				//objclsPrintDocument.ReportTextList = New ArrayList
				objclsPrintDocument.RepeatDatafile = new ArrayList();
				for (intCount = 0; intCount <= arrDtTextListIn.Count - 1; intCount++) {
					if (IsNothing(arrDtTextListIn.Item(intCount)) == false) {
						objclsPrintDocument.RepeatDatafile.Add(arrDtTextListIn.Item(intCount));
					}
				}
			}



			return objclsPrintDocument;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!IsNothing(objclsPrintDocument) == true) {
				objclsPrintDocument.Dispose();
			}
			//---------------------------------------------------------
		}

	}
	#End Region

}

