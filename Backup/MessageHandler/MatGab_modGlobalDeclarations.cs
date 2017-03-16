
class modGlobalDeclarations
{
	//**********************************************************************
	// File Header       : modGlobalDeclarations
	// File Name 		: modGlobalDeclarations.vb
	// Author			: Mangesh Shardul
	// Date/Time			: 12-Sep-2004 8:25 pm
	// Description		: To define all Project level objects from Other DLLs
	//**********************************************************************

	//---Global object for error Handling operations.

	public ErrorHandler.ErrorHandler gobjErrorHandler = new ErrorHandler.ErrorHandler();
	//--- 1. For Creating Execution log. Used in error handler code  

	public const  CONST_CREATE_EXECUTION_LOG = 0;
	public void InitializeSetting()
	{
		gobjErrorHandler.ErrorLogFolder = "ErrorLogs";
		//gobjErrorHandler.ErrorLogFileName = Application.StartupPath & "\" & gobjErrorHandler.ErrorLogFolder & "\ErrorLog-" & DateAndTime.DateString & "-" & DateAndTime.Hour(Now) & "-" & DateAndTime.Minute(Now) & "-" & DateAndTime.Second(Now) & ".txt"
		gobjErrorHandler.ErrorLogFileName = CurDir() + "\\" + gobjErrorHandler.ErrorLogFolder + "\\ErrorMessageHandler.txt";
		gobjErrorHandler.CompanyName = "Aldys Technologies Pvt. Ltd.";
		gobjErrorHandler.ProductName = "AAS";
	}
}
