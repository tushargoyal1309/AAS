
class modConstants_21CFR
{

	#Region " Activity Authentication"

	//Public Enum enumActivityAuthentication  '05.11.09
	//    Method = 1
	//    Analysis = 2
	//    DataFiles = 3
	//    CookBook = 4
	//    UV_Scanning_Spectrum_Mode = 5
	//    Energy_Spectrum_Mode = 6
	//    Time_Scan = 7
	//    Accessories = 8
	//    Lamp_Placements = 9
	//    ServiceUtilities = 10
	//    MethodInfoData = 11
	//    IQOQPQ = 12
	//    DissolutionTester = 13
	//    BeverageApplication = 14
	//    SaveFile = 15
	//    LoadFile = 16
	//    Print = 17
	//    Export = 18
	//    EditMethodInfoData = 19

	//End Enum

	public enum enumActivityAuthentication
	{
		//05.11.09
		Method = 1,
		Analysis = 2,
		DataFiles = 3,
		CookBook = 4,
		UV_Scanning_Spectrum_Mode = 5,
		Energy_Spectrum_Mode = 6,
		Time_Scan = 7,
		Accessories = 8,
		Lamp_Placements = 9,
		ServiceUtilities = 10,
		IQOQPQ = 11,
		HydrideMode = 12,
		SaveFile = 13,
		LoadFile = 14,
		Print = 15,
		Export = 16
	}

	//--- Enum used to specify the authentication level
	//--- used tom save the respective file under 21CFR
	public enum ENUM_ActivityType
	{
		LoginAuthentication = 1,
		FileAuthentication = 2
	}

	#End Region

	//--- Enum constants used for the Activity log for 
	//--- 21CFR Implementation
	public enum EnumModules
	{
		Method = 1,
		Analysis = 2,
		DataFiles = 3,
		CookBook = 4,
		UV_Scanning_Spectrum_Mode = 5,
		Energy_Spectrum_Mode = 6,
		TimeScan = 7,
		AutoSampler = 8,
		Lamp_Placements = 9,
		Service_Utilities = 10,
		IQOQPQ = 11,
		Hydride_Mode = 12,
		SaveFile = 13,
		LoadFile = 14,
		Print = 15,
		Export = 16,
		Login = 17
	}

}
