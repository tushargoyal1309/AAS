
class modGlobalDeclaration
{
	//**********************************************************************
	// File Header       : modGlobalDeclaration
	// File Name 		: modGlobalDeclaration.vb
	// Author			: Deepak Bhati
	// Date/Time			: 02-Dec-2004 8:25 pm
	// Description		: To define all Project level objects from Other DLLs
	//**********************************************************************

	//---Global object for error Handling operations.

	public ErrorHandler.ErrorHandler gobjErrorHandler = new ErrorHandler.ErrorHandler();
	//--- 1. For Creating Execution log. Used in error handler code  

	public const  CONST_CREATE_EXECUTION_LOG = 0;
	public void InitializeSetting()
	{
		gobjErrorHandler.ErrorLogFolder = "ErrorLogs";
		gobjErrorHandler.ErrorLogFileName = CurDir() + "\\" + gobjErrorHandler.ErrorLogFolder + "\\ErrorGridLayoutPanel.txt";
		gobjErrorHandler.CompanyName = "Aldys Technologies Pvt. Ltd.";
		gobjErrorHandler.ProductName = "GridLayoutPanel";
	}
}

