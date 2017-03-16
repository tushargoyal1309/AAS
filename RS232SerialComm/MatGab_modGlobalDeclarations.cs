
class modGlobalDeclarations
{

	#Region " Global Variables and Objects "

	//---Object for RS232 communication
	public clsRS232 mrs232 = new clsRS232();
	//Public mrs232 As New clsRS232vc 'by Pankaj for vc dll on 12 Sep 07
	//---Error Initialization
	public ErrorHandler.ErrorHandler gobjErrorHandler = new ErrorHandler.ErrorHandler();
	//---Path for the Settings.ini

	public string INI_SETTINGS_PATH;

	public bool Commflag = true;
	#End Region


	#Region " Public Enums, Constants, Structures... "

	//--- Communication Settings 
	public const  SECTION_SETTINGS = "CommSettings";
	public const  KEY_COMPORT = "ComPort";
	public const  KEY_BAUDRATE = "BaudRate";
	public const  KEY_PARITY = "Parity";
	public const  KEY_DATABITS = "DataBits";

	public const  KEY_STOPBITS = "StopBits";

	public const  CONST_CREATE_EXECUTION_LOG = 0;
	public enum EnumMessageType
	{
		Information = 1,
		Question = 2
	}

	#End Region

}
