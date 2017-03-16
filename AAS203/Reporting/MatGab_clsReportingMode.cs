//Imports ColorAnalysis.Common

[Serializable()]
public class clsReportingMode : IDisposable
{
	//**********************************************************************
	// File Header       : clsReportingMode
	// File Name 		: clsReportingMode.vb
	// Author			: Mangesh Shardul
	// Date/Time			: 20-Nov-2004 8:10 pm
	// Description		: All the reporting functions are defined
	//**********************************************************************

	#Region " Enums, Constants, Structurs And Other DataTypes "

	public struct structReportFormat
	{
		long ReportFormatID;
		string ReportFormatName;
		bool IsDisplayCompanyLogo;
		bool IsDisplayReportTitle;
		bool IsDisplaySecondReportTitle;
		bool IsDisplayReportDate;
		bool IsDisplaySubsequentPageHeader;
		////-----
		bool IsDisplayReportHeader;
		////-----
		bool IsDisplayReportFooter;
		double LogoHeight;
		double LogoWidth;
		int LogoAlignment;
		string LogoFileName;
		string ReportTitleLine1;
		string ReportTitleLine2;
		string ReportTitleLine3;
		string SecondReportTitleLine1;
		string SecondReportTitleLine2;
		string SecondReportTitleLine3;
		double PageLeftMargin;
		double PageTopMargin;
		double PageBottomMargin;
		string ReportFooterLine1;
		string ReportFooterLine2;
		string ReportFooterLine3;
		////-----
		string AnalystName;
		bool PrinterType;
		////-----
	}

	#End Region

	#Region " Private class variables "

	private Hashtable mobjHashTableRptSetting;

	private structReportFormat mobjstructReportFormat;
	#End Region

	#Region " Public Properties "
	//Public Property ReportFormats() As structReportFormat
	//    Get
	//        Return mobjstructReportFormat
	//    End Get
	//    Set(ByVal Value As structReportFormat)
	//        mobjstructReportFormat = Value
	//    End Set
	//End Property
	#End Region

	#Region " Garbage Collection "

	private IntPtr handle;

	private bool disposed = false;
	public void IDisposable.Dispose()
	{
		//**********************************************************************
		// Procedure Header  : Dispose
		// Author			: Mangesh Shardul
		// Date/Time			: 20-Nov-2004 8:20 pm
		// Description		: destructor for class
		//**********************************************************************
		try {
			Dispose(true);
			GC.SuppressFinalize(this);

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

	private void dispose(bool disposing)
	{
		//**********************************************************************
		// Procedure Header  : Dispose
		// Author			: Mangesh Shardul
		// Date/Time			: 20-Nov-2004 8:20 pm
		// Description		: destructor for class
		//**********************************************************************
		try {
			if (!this.disposed) {
				if (disposing) {
					mobjHashTableRptSetting = null;
					mobjstructReportFormat = null;
				}
				CloseHandle(handle);
				handle = IntPtr.Zero;
			}
			disposed = true;

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

	[System.Runtime.InteropServices.DllImport("kernel32")]
	private static bool CloseHandle(IntPtr handle)
	{
	}

	protected override void finalize()
	{
		//**********************************************************************
		// Procedure Header  : Dispose
		// Author			: Mangesh Shardul
		// Date/Time			: 20-Nov-2004 8:20 pm
		// Description		: destructor for class
		//**********************************************************************
		try {
			Dispose(false);
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

	#End Region

	#Region " Public Functions "

	public clsReportingMode()
	{
		//**********************************************************************
		// Procedure Header  :
		// Author			: Mangesh Shardul
		// Date/Time			: 20-Nov-2004 8:20 pm
		// Description		: Constructor for class
		//**********************************************************************
		try {
			mobjHashTableRptSetting = new Hashtable();
			mobjstructReportFormat = new structReportFormat();

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

	public Hashtable funcGetReportFormatSettings(long lngReportFormatIDIn)
	{
		//=====================================================================
		// Procedure Name        : InitializeReportFormatStruct
		// Parameters Passed     : Report format ID 
		// Returns               : Hash Table
		// Purpose               : To get the data from database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : structure of ReportFormat
		// Author                : Mangesh Shardul
		// Created               : Sunday, November 21, 2004 8:25 pm
		// Revisions             : 
		//=====================================================================
		DataRow objDrReportFormatData;
		Hashtable objHtReportFormat = new Hashtable();

		try {
			//objDrReportFormatData = gobjDataAccess.GetReportFormatData(lngReportFormatIDIn)

			if (IsNothing(objDrReportFormatData) == false) {
				objHtReportFormat.Item("ReportFormatID") = (long)objDrReportFormatData.Item("ReportFormatID");
				objHtReportFormat.Item("ReportFormatName") = (string)objDrReportFormatData.Item("ReportFormatName");

				objHtReportFormat.Item("IsDisplayCompanyLogo") = (bool)objDrReportFormatData("IsDisplayCompanyLogo");
				objHtReportFormat.Item("IsDisplayReportTitle") = (bool)objDrReportFormatData("IsDisplayReportTitle");
				objHtReportFormat.Item("IsDisplaySecondReportTitle") = (bool)objDrReportFormatData("IsDisplaySecondReportTitle");
				objHtReportFormat.Item("IsDisplayReportDate") = (bool)objDrReportFormatData("IsDisplayReportDate");
				objHtReportFormat.Item("IsDisplaySubsequentPageHeader") = (bool)objDrReportFormatData("IsDisplaySubsequentPageHeader");
				objHtReportFormat.Item("IsDisplayReportFooter") = (bool)objDrReportFormatData("IsDisplayReportFooter");
				objHtReportFormat.Item("LogoHeight") = (double)objDrReportFormatData("LogoHeight");
				objHtReportFormat.Item("LogoWidth") = (double)objDrReportFormatData("LogoWidth");
				objHtReportFormat.Item("LogoAlignment") = (int)objDrReportFormatData("LogoAlignment");
				objHtReportFormat.Item("LogoFileName") = (string)objDrReportFormatData("LogoFileName");
				objHtReportFormat.Item("ReportTitleLine1") = (string)objDrReportFormatData("ReportTitleLine1");
				objHtReportFormat.Item("ReportTitleLine2") = (string)objDrReportFormatData("ReportTitleLine2");
				objHtReportFormat.Item("ReportTitleLine3") = (string)objDrReportFormatData("ReportTitleLine3");
				objHtReportFormat.Item("SecondReportTitleLine1") = (string)objDrReportFormatData("SecondReportTitleLine1");
				objHtReportFormat.Item("SecondReportTitleLine2") = (string)objDrReportFormatData("SecondReportTitleLine2");
				objHtReportFormat.Item("SecondReportTitleLine3") = (string)objDrReportFormatData("SecondReportTitleLine3");
				objHtReportFormat.Item("PageLeftMargin") = (double)objDrReportFormatData("PageLeftMargin");
				objHtReportFormat.Item("PageTopMargin") = (double)objDrReportFormatData("PageTopMargin");
				objHtReportFormat.Item("PageBottomMargin") = (double)objDrReportFormatData("PageBottomMargin");
				objHtReportFormat.Item("ReportFooterLine1") = (string)objDrReportFormatData("ReportFooterLine1");
				objHtReportFormat.Item("ReportFooterLine2") = (string)objDrReportFormatData("ReportFooterLine2");
				objHtReportFormat.Item("ReportFooterLine3") = (string)objDrReportFormatData("ReportFooterLine3");
				objHtReportFormat.Item("AnalystName") = (string)objDrReportFormatData("AnasystName");
				objHtReportFormat.Item("PrinterType") = (bool)objDrReportFormatData("PrinterType");

				return objHtReportFormat;
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

			objDrReportFormatData = null;
			objHtReportFormat = null;
			//---------------------------------------------------------
		}

	}

	public DataTable funcGetReportFormats()
	{
		//=====================================================================
		// Procedure Name        : funcGetReportFormats
		// Parameters Passed     : None
		// Returns               : DataTable
		// Purpose               : To retrieve all the data from database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : clsDataAccessLayer
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Sunday, January 30, 2005
		// Revisions             : 1
		//=====================================================================
		try {
		//Return gobjDataAccess.GetReportFormatData()

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

	public bool funcInitializeReportFormatStruct(long lngReportFormatID)
	{
		//=====================================================================
		// Procedure Name        : InitializeReportFormatStruct
		// Parameters Passed     : Report format ID 
		// Returns               : True or false
		// Purpose               : To get the data from database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : structure of ReportFormat
		// Author                : Mangesh Shardul
		// Created               : Sunday, November 21, 2004 8:25 pm
		// Revisions             : 
		//=====================================================================
		DataRow objDrReportFormatData;

		try {
			//objDrReportFormatData = gobjDataAccess.GetReportFormatData(lngReportFormatID)

			if (IsNothing(objDrReportFormatData) == false) {
				mobjstructReportFormat.ReportFormatID = (long)objDrReportFormatData.Item("ReportFormatID");
				mobjstructReportFormat.ReportFormatName = (string)objDrReportFormatData.Item("ReportFormatName");


				mobjstructReportFormat.IsDisplayCompanyLogo = (bool)objDrReportFormatData("IsDisplayCompanyLogo");
				mobjstructReportFormat.IsDisplayReportTitle = (bool)objDrReportFormatData("IsDisplayReportTitle");
				mobjstructReportFormat.IsDisplaySecondReportTitle = (bool)objDrReportFormatData("IsDisplaySecondReportTitle");
				mobjstructReportFormat.IsDisplayReportDate = (bool)objDrReportFormatData("IsDisplayReportDate");
				mobjstructReportFormat.IsDisplaySubsequentPageHeader = (bool)objDrReportFormatData("IsDisplaySubsequentPageHeader");
				mobjstructReportFormat.IsDisplayReportFooter = (bool)objDrReportFormatData("IsDisplayReportFooter");
				mobjstructReportFormat.LogoHeight = (double)objDrReportFormatData("LogoHeight");
				mobjstructReportFormat.LogoWidth = (double)objDrReportFormatData("LogoWidth");
				mobjstructReportFormat.LogoAlignment = (int)objDrReportFormatData("LogoAlignment");
				mobjstructReportFormat.LogoFileName = (string)objDrReportFormatData("LogoFileName");
				mobjstructReportFormat.ReportTitleLine1 = (string)objDrReportFormatData("ReportTitleLine1");
				mobjstructReportFormat.ReportTitleLine2 = (string)objDrReportFormatData("ReportTitleLine2");
				mobjstructReportFormat.ReportTitleLine3 = (string)objDrReportFormatData("ReportTitleLine3");
				mobjstructReportFormat.SecondReportTitleLine1 = (string)objDrReportFormatData("SecondReportTitleLine1");
				mobjstructReportFormat.SecondReportTitleLine2 = (string)objDrReportFormatData("SecondReportTitleLine2");
				mobjstructReportFormat.SecondReportTitleLine3 = (string)objDrReportFormatData("SecondReportTitleLine3");
				mobjstructReportFormat.PageLeftMargin = (double)objDrReportFormatData("PageLeftMargin");
				mobjstructReportFormat.PageTopMargin = (double)objDrReportFormatData("PageTopMargin");
				mobjstructReportFormat.PageBottomMargin = (double)objDrReportFormatData("PageBottomMargin");
				mobjstructReportFormat.ReportFooterLine1 = (string)objDrReportFormatData("ReportFooterLine1");
				mobjstructReportFormat.ReportFooterLine2 = (string)objDrReportFormatData("ReportFooterLine2");
				mobjstructReportFormat.ReportFooterLine3 = (string)objDrReportFormatData("ReportFooterLine3");
				mobjstructReportFormat.PrinterType = (bool)objDrReportFormatData("PrinterType");


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

			objDrReportFormatData = null;
			//---------------------------------------------------------
		}

	}

	//Public Function Print(ByVal intReportTypeIn As clsPrintDocument.enumReportType, _
	//                             ByVal strPageHeaderIn As String, ByVal strPageTextIn As String, _
	//                             Optional ByVal arrGraphControlsListIn As ArrayList = Nothing, _
	//                             Optional ByVal arrDtTablesListIn As ArrayList = Nothing, _
	//                             Optional ByVal objDtImagesListIn As DataTable = Nothing) As Boolean
	//    Dim objfrmReport As frmReportSettings
	//    Try
	//        objfrmReport = New frmReportSettings(mobjstructReportFormat, _
	//        strPageHeaderIn, strPageTextIn, arrGraphControlsListIn, arrDtTablesListIn, objDtImagesListIn, intReportTypeIn)

	//        If objfrmReport.ShowDialog() = (DialogResult.OK Or DialogResult.None) Then

	//            'gstructSettings.ReportFormatID = objfrmReport.SelectedReportFormatID
	//            If objfrmReport.IsDefaultReportFormat = True Then
	//                'Call funcSaveReportFormatIDToINIData()
	//            End If

	//            'Call funcInitializeReportFormatStruct(gstructSettings.ReportFormatID)

	//            objfrmReport.Close()
	//            objfrmReport.Dispose()
	//            objfrmReport = Nothing
	//            Return True
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//        'If Not cWait Is Nothing Then
	//        '    cWait.Dispose()
	//        'End If
	//    End Try

	//End Function

	public long funcGetLastReportFormatID()
	{
		//Return gobjDataAccess.GetIncrementedReportFormatID
	}

	public bool AddNewReportFormatInDataBase(Hashtable objHtRptSettingIn)
	{
		//=====================================================================
		// Procedure Name        : AddNewReportFormatInDataBase
		// Parameters Passed     : HashTable
		// Returns               : True Or false
		// Purpose               : To add new report format in Database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : clsDataAccesLayer
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Monday, January 31, 2005
		// Revisions             : 1
		//=====================================================================
		try {
			DataRow objDrNewReportFormat;
			//= CType(gobjDataAccess.GetEmptyTableStructure("ReportFormat", True).NewRow, DataRow)

			objDrNewReportFormat.Item("ReportFormatID") = objHtRptSettingIn.Item("ReportFormatID");
			objDrNewReportFormat.Item("ReportFormatName") = objHtRptSettingIn.Item("ReportFormatName");
			objDrNewReportFormat.Item("ReportTitleLine1") = objHtRptSettingIn.Item("ReportTitleLine1");
			objDrNewReportFormat.Item("ReportTitleLine2") = objHtRptSettingIn.Item("ReportTitleLine2");
			objDrNewReportFormat.Item("ReportTitleLine3") = objHtRptSettingIn.Item("ReportTitleLine3");
			objDrNewReportFormat.Item("SecondReportTitleLine1") = objHtRptSettingIn.Item("SecondReportTitleLine1");
			objDrNewReportFormat.Item("SecondReportTitleLine2") = objHtRptSettingIn.Item("SecondReportTitleLine2");
			objDrNewReportFormat.Item("SecondReportTitleLine3") = objHtRptSettingIn.Item("SecondReportTitleLine3");
			objDrNewReportFormat.Item("ReportFooterLine1") = objHtRptSettingIn.Item("ReportFooterLine1");
			objDrNewReportFormat.Item("ReportFooterLine2") = objHtRptSettingIn.Item("ReportFooterLine2");
			objDrNewReportFormat.Item("ReportFooterLine3") = objHtRptSettingIn.Item("ReportFooterLine3");
			objDrNewReportFormat.Item("IsDisplayCompanyLogo") = objHtRptSettingIn.Item("IsDisplayCompanyLogo");
			objDrNewReportFormat.Item("IsDisplayReportDate") = objHtRptSettingIn.Item("IsDisplayReportDate");
			objDrNewReportFormat.Item("IsDisplayReportFooter") = objHtRptSettingIn.Item("IsDisplayReportFooter");
			objDrNewReportFormat.Item("IsDisplayReportTitle") = objHtRptSettingIn.Item("IsDisplayReportTitle");
			objDrNewReportFormat.Item("IsDisplaySecondReportTitle") = objHtRptSettingIn.Item("IsDisplaySecondReportTitle");
			objDrNewReportFormat.Item("IsDisplaySubsequentPageHeader") = objHtRptSettingIn.Item("IsDisplaySubsequentPageHeader");
			objDrNewReportFormat.Item("LogoAlignment") = objHtRptSettingIn.Item("LogoAlignment");
			objDrNewReportFormat.Item("LogoFileName") = objHtRptSettingIn.Item("LogoFileName");
			objDrNewReportFormat.Item("LogoWidth") = objHtRptSettingIn.Item("LogoWidth");
			objDrNewReportFormat.Item("LogoHeight") = objHtRptSettingIn.Item("LogoHeight");
			objDrNewReportFormat.Item("PageBottomMargin") = objHtRptSettingIn.Item("PageBottomMargin");
			objDrNewReportFormat.Item("PageLeftMargin") = objHtRptSettingIn.Item("PageLeftMargin");
			objDrNewReportFormat.Item("PageTopMargin") = objHtRptSettingIn.Item("PageTopMargin");
			objDrNewReportFormat.Item("PrinterType") = objHtRptSettingIn.Item("PrinterType");

		//Dim objDrNewReportFormat = CType(gobjDataAccess.GetEmptyTableStructure("ReportFormat", True).NewRow, DataRow)
		//If gobjDataAccess.AddNewReportFormatData(objDrNewReportFormat) Then
		//    Return True
		//Else
		//    Return False
		//End If

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
			objHtRptSettingIn = null;
			//---------------------------------------------------------
		}

	}

	public bool UpdateReportFormatInDataBase(Hashtable objHtRptSettingIn)
	{
		//=====================================================================
		// Procedure Name        : UpdateReportFormatInDataBase
		// Parameters Passed     : HashTable
		// Returns               : True or false
		// Purpose               : To update selected report format in database
		// Description           : 
		// Assumptions           : 
		// Dependencies          : clsDataAccessLayer
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Monday, January 31, 2005
		// Revisions             : 1
		//=====================================================================
		try {
			DataRow objDrNewReportFormat;
			//= CType(gobjDataAccess.GetEmptyTableStructure("ReportFormat", True).NewRow, DataRow)

			objDrNewReportFormat.Item("ReportFormatID") = objHtRptSettingIn.Item("ReportFormatID");
			objDrNewReportFormat.Item("ReportFormatName") = objHtRptSettingIn.Item("ReportFormatName");
			objDrNewReportFormat.Item("ReportTitleLine1") = objHtRptSettingIn.Item("ReportTitleLine1");
			objDrNewReportFormat.Item("ReportTitleLine2") = objHtRptSettingIn.Item("ReportTitleLine2");
			objDrNewReportFormat.Item("ReportTitleLine3") = objHtRptSettingIn.Item("ReportTitleLine3");
			objDrNewReportFormat.Item("SecondReportTitleLine1") = objHtRptSettingIn.Item("SecondReportTitleLine1");
			objDrNewReportFormat.Item("SecondReportTitleLine2") = objHtRptSettingIn.Item("SecondReportTitleLine2");
			objDrNewReportFormat.Item("SecondReportTitleLine3") = objHtRptSettingIn.Item("SecondReportTitleLine3");
			objDrNewReportFormat.Item("ReportFooterLine1") = objHtRptSettingIn.Item("ReportFooterLine1");
			objDrNewReportFormat.Item("ReportFooterLine2") = objHtRptSettingIn.Item("ReportFooterLine2");
			objDrNewReportFormat.Item("ReportFooterLine3") = objHtRptSettingIn.Item("ReportFooterLine3");
			objDrNewReportFormat.Item("IsDisplayCompanyLogo") = objHtRptSettingIn.Item("IsDisplayCompanyLogo");
			objDrNewReportFormat.Item("IsDisplayReportDate") = objHtRptSettingIn.Item("IsDisplayReportDate");
			objDrNewReportFormat.Item("IsDisplayReportFooter") = objHtRptSettingIn.Item("IsDisplayReportFooter");
			objDrNewReportFormat.Item("IsDisplayReportTitle") = objHtRptSettingIn.Item("IsDisplayReportTitle");
			objDrNewReportFormat.Item("IsDisplaySecondReportTitle") = objHtRptSettingIn.Item("IsDisplaySecondReportTitle");
			objDrNewReportFormat.Item("IsDisplaySubsequentPageHeader") = objHtRptSettingIn.Item("IsDisplaySubsequentPageHeader");
			objDrNewReportFormat.Item("LogoAlignment") = objHtRptSettingIn.Item("LogoAlignment");
			objDrNewReportFormat.Item("LogoFileName") = objHtRptSettingIn.Item("LogoFileName");
			objDrNewReportFormat.Item("LogoWidth") = objHtRptSettingIn.Item("LogoWidth");
			objDrNewReportFormat.Item("LogoHeight") = objHtRptSettingIn.Item("LogoHeight");
			objDrNewReportFormat.Item("PageBottomMargin") = objHtRptSettingIn.Item("PageBottomMargin");
			objDrNewReportFormat.Item("PageLeftMargin") = objHtRptSettingIn.Item("PageLeftMargin");
			objDrNewReportFormat.Item("PageTopMargin") = objHtRptSettingIn.Item("PageTopMargin");
			objDrNewReportFormat.Item("PrinterType") = objHtRptSettingIn.Item("PrinterType");

		//If gobjDataAccess.UpdateReportFormatData(objDrNewReportFormat) Then
		//    Return True
		//Else
		//    Return False
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
			objHtRptSettingIn = null;
			//---------------------------------------------------------
		}

	}

	//Public Function funcSaveReportFormatIDToINIData() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcSaveReportFormatIDToINIData
	//    ' Parameters Passed     : None
	//    ' Returns               : true if succesfull otherwise false
	//    ' Purpose               : to save Selected ReportFormatID to the IniData Table
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul
	//    ' Created               : 26-Feb-2005 5:15 pm
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Dim objdtIniData As New DataTable
	//    Dim objdvIniData As DataView

	//    Try
	//        objdtIniData = gobjDataAccess.GetINIData(gIntActiveMethodID)
	//        objdvIniData = New DataView(objdtIniData)

	//        objdvIniData.RowFilter = "SectionName ='" & Const_ReportFormat_Section & "'"
	//        objdvIniData.Item(0).Item(Const_IniData_Value) = gstructSettings.ReportFormatID

	//        If gobjDataAccess.UpdateINIData(objdtIniData, gIntActiveMethodID) = True Then
	//            Return True
	//        Else
	//            Return False
	//        End If


	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        objdtIniData.Dispose()
	//        objdvIniData.Dispose()
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	public static void GetShadeColorImages(ref DataTable objDtImagesList, string strCaptionIn, Color objColorIn, System.Drawing.Image imgImageIn = null, int ImageWidth = 0, int ImageHeight = 0)
	{
		//=====================================================================
		// Procedure Name        : funcGetShadeColorImages
		// Parameters Passed     : 1.Reference to DataTable in which image and caption is added,
		//                         2.String for Caption of Image
		//                         3.Color object if r,g,b values are known
		//                         4.Optional Image object from form's controls
		// Returns               : DataTable with Image and ImageCaption
		// Purpose               : To get bitmap image of the color shown in the ShapeControl
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 06-Apr-2005 1:50 pm
		// Revisions             : 1
		//=====================================================================
		DataRow objDrNewRow;
		System.Drawing.Bitmap objColorImage;

		int intXCounter;
		int intYCounter;

		try {
			if (!IsNothing(objDtImagesList) == true) {
				if (objDtImagesList.Rows.Count == 0) {
					objDtImagesList = new DataTable();
					objDtImagesList.Columns.Add("ImageCaption", typeof(string));
					objDtImagesList.Columns.Add("Image", typeof(System.Drawing.Bitmap));
				} else {
					if (objDtImagesList.Columns.Contains("ImageCaption") == false | objDtImagesList.Columns.Contains("Image") == false) {
						objDtImagesList.Columns.Clear();
						objDtImagesList.Columns.Add("ImageCaption", typeof(string));
						objDtImagesList.Columns.Add("Image", typeof(System.Drawing.Bitmap));
					}
				}
			} else {
				//---DataTable is nothing
				objDtImagesList = new DataTable();
				objDtImagesList.Columns.Add("ImageCaption", typeof(string));
				objDtImagesList.Columns.Add("Image", typeof(System.Drawing.Bitmap));
			}

			if (objColorIn.Equals(Color.Empty) == false) {
				if (ImageWidth == 0 & ImageHeight == 0) {
					objColorImage = new Bitmap(150, 40);
				} else {
					objColorImage = new Bitmap(ImageWidth, ImageHeight);
				}

				for (intXCounter = 0; intXCounter <= objColorImage.Width - 1; intXCounter++) {
					for (intYCounter = 0; intYCounter <= objColorImage.Height - 1; intYCounter++) {
						objColorImage.SetPixel(intXCounter, intYCounter, objColorIn);
					}
				}

			}
			if (IsNothing(imgImageIn) == false) {
				//objColorImage = New Bitmap(imgImageIn)
				objColorImage = (System.Drawing.Bitmap)imgImageIn.Clone;
			}

			//---4.Add Image and ImageCaption in the DataTable
			if (!IsNothing(objColorImage) == true) {
				objDrNewRow = objDtImagesList.NewRow();
				objDrNewRow.Item("ImageCaption") = strCaptionIn;
				objDrNewRow.Item("Image") = objColorImage;
				objDtImagesList.Rows.Add(objDrNewRow);
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

	public bool funcCookBookPrinting(ref DataTable objDtCookBook, ref DataTable objDtElementWavelengths)
	{
		//************************************************************************************************************
		// Function Header   : btnPrintPreViewClick
		// Author			: Sachin Dokhale
		// Date/Time			: 08-Oct-2005 11:25 am
		// Description		: To preview the report before printing
		//************************************************************************************************************
		clsPrintDocument objclsPrintDocument;

		try {
			if ((objDtCookBook == null) | (objDtElementWavelengths == null)) {
				return true;
			}

			//objclsPrintDocument = funcSetPrintDocument(mobjstructReportFormat, _
			//            mstrPageHeader, mstrPageText, _
			//            marrGraphControlsList, mobjarrDtTablesList, _
			//            mobjDtImagesList, mintReportType)
			//objclsPrintDocument()

			//objDtCookBook()


			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
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
			if (!IsNothing(objclsPrintDocument) == true)
				objclsPrintDocument.Dispose();
			//---------------------------------------------------------
		}

	}

	#End Region

}
