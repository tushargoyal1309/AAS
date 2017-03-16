class modGlobalConstants
{

	#Region " Public Constants "

	public const  CONST_FUEL_CONDITIONS_FILE = "LastOpt.bin";
	public const bool gblnShowThreadOnfrmMDIStatusBar = false;
	public const  CONST_CREATE_EXECUTION_LOG = 0;
	public const  CONST_ThemeFileName = "Theme.txt";
	public const  CONST_DELAY = 3000;
	public const  CONST_LONG_DELAY = 30000;
	public const  CONST_VERY_LONG_DELAY = 120000;
		//---4.85  14.04.09
	public const  CONST_LabName = "Thermo Scientific - Application Lab";
	public const  CONST_LabName1 = "Application Lab";
	public const  ConstDataGridPropertiesFileName = "DataGridProperties.txt";
	public const  ConstMethodsFileName = "Methods.bin";
	public const  ConstDBMethodsFileName = "DBMethods.bin";
	////----- Added Sachin Dokhale for AA201  and AA203 Lamp count on 22.05.08
	////--- tobe do and Ref. 
	////Public Const ConstInstFileName = "Inst.bin"
	public const  ConstInstFileName_203 = "Inst.bin";
	public const  ConstInstFileName_201 = "InstB.bin";
	////--- use this const for AAS 2.4
	public const  ConstInstFileName_204 = "InstC.bin";
	////---
	////-----
		//for half step 400 and for full step 200
	public const  TARRATIO = 400.0 * 7.0 / 4.0;
		//6.0 * 50 (wz -2 to 4 = 6 nm and in 1 nm 50 steps for monochromator
	public const  WVZERORANGE = 300;

	public const  RANGEH = 50;
	public const  WVRANGE = 100;

	public const  WVRANGE_AA201 = 50;
	public const double CONST_STEPS_PER_NM = 50;

	public const double CONST_STEPS_PER_NM_AA201 = 25.0;
	public bool Graphite = false;
	public const  VERY_LONG_DEALY = 120;
	public const  LONG_DEALY = 30;
	public const  DEFAULT_DELAY = 3;
	public const  NVSTEP = 10;
	public const  BHRATIO = 2.2;
	public const  MAXNVHOME = 5;
	public const  NVRED = (200 * 4);
	public const  TOTBHLEN = 6;
	public const  MAXBHHOME = (200 * TOTBHLEN * BHRATIO);
	public const  BHSTEP = (20 * BHRATIO);
	public const  UVPMT = 270;

	public const  UVGAINWV = 240;
	public const  ZeroOrderThreadWindowLocationX = 10;
	public const  ZeroOrderThreadWindowLocationY = 65;
	public const  OptAllThreadWindowLocationX = 405;

	public const  OptAllThreadWindowLocationY = 65;
	public const  CONST_FASTStep = CONST_STEPS_PER_NM;
	public const  CONST_MEDIUMStep = CONST_FASTStep / 2;

	public const  CONST_SLOWStep = CONST_FASTStep / 10;
	////----- For AAS201
	public const  CONST_FASTStep_AA201 = CONST_STEPS_PER_NM_AA201;
	public const  CONST_MEDIUMStep_AA201 = CONST_FASTStep_AA201 / 2;
	//Public Const CONST_SLOWStep_AA201 = CONST_FASTStep_AA201 / 10  '---commented on 03.09.09
		//---changed on 03.09.09
	public const  CONST_SLOWStep_AA201 = CONST_FASTStep_AA201 / 8;
	////-----

	//--- File Extensions used in Spectrum mode
	//Public Const CONST_ChannelFileExt As String = ".chn"
	public const string CONST_UVSpectrumFileExt = ".uvs";
	public const string CONST_EnergySpectrumFileExt = ".ens";

	public const string CONST_EnergySpectrumFileExtDB = ".dbe";
	//--- Maximum Buffer Size used in spectrum to calculate result

	public const  MAX_RANGE = 11540;
	//#define	BHSCANSTEP	10
	//#define	NVSCANSTEP	10
	public const  CONST_BHSCANSTEP = 10;

	public const  CONST_NVSCANSTEP = 10;

	public const  ConstFILTMAX = 1001;
	public const  SMHCLDIS = 56;

	public const  SMHCLENB = 57;
	//---System Parameters Settings
	public const string SECTION_SYSTEMPARAMETERS = "SystemParameters";
	public const string KEY_INSTRUMENT_BEAMTYPE = "InstrumentBeamType";
	public const string KEY_INSTRESET_CONTINUOUS = "InstReset_continuous";

	public const string KEY_Customer = "Customer";
	//--- Communication Settings 
	public const  SECTION_COMMSETTINGS = "CommSettings";
	public const  KEY_COMPORT = "ComPort";
	public const  KEY_BAUDRATE = "BaudRate";
	public const  KEY_PARITY = "Parity";
	public const  KEY_DATABITS = "DataBits";

	public const  KEY_STOPBITS = "StopBits";
	//--- AutoSampler Settings 
	public const  SECTION_AUTOSAMPLER = "AutoSampler";
	public const  KEY_SERIALPORT = "SamplerComPort";
	public const  KEY_SAMPLERBAUDRATE = "SamplerBaudRate";
	public const  KEY_INTAKETIME = "SampleIntakeTime";
	public const  KEY_MeasurementTime = "MeasurementTime";
	public const  KEY_WashTime = "WashTime";
	public const  KEY_ProbeWaitTime = "ProbeDownWaitTime";

	public const  KEY_DelayFactor = "DelayFactor";
	//--- Siper Settings 
	public const  SECTION_Siper = "Sipper";
	public const  KEY_SuckTime = "Suck";
	public const  KEY_CleanTime = "Clean";
	public const  KEY_EmptyTime = "Empty";
	//Public Const CONST_ParameterFileExt As String = ".par"

	public const  CONST_FLAME_OK = 0x2;

	public const  CONST_AA_CONNECTED = 0x4;
	//--- Instrument Type        Added by Saurabh 01.08.07
	public const  CONST_AA203_FullVersion = "AA 203";
	public const  CONST_AA203D_FullVersion = "AA 203D";
	public const  CONST_AA201_FullVersion = "AA 201";
	public const  CONST_AA203_DemoVersion = "AA 203 DEMO";
	public const  CONST_AA203D_DemoVersion = "AA 203D DEMO";
	public const  CONST_AA201_DemoVersion = "AA 201 DEMO";

	public const  CONST_AA203 = "AA 203";

	//--4.85  14.04.09
	public const  CONST_AA303_FullVersion = "AA 303";
	public const  CONST_AA303D_FullVersion = "AA 303D";
	public const  CONST_AA301_FullVersion = "AA 301";
	public const  CONST_AA303_DemoVersion = "AA 303 DEMO";
	public const  CONST_AA303D_DemoVersion = "AA 303D DEMO";
	public const  CONST_AA301_DemoVersion = "AA 301 DEMO";
	//--4.85  14.04.09


	//--- No. of places to be formated after decimal     Added by Saurabh 01.08.07
	public const  CONST_Format_Value_Concentration_PPB = 4;
	public const  CONST_Format_Value_Concentration = 2;
	public const  CONST_Format_Value_Absorbance = 3;
	public const  CONST_Format_Value_Emission = 1;
	////----- D2 Setting
	public const  SECTION_D2Setting = "D2Setting";
	public const  KEY_D2Current = "D2Cur";

	public const  KEY_D2PMT = "D2PMT";
	//Public Const gConst_AboutCompany = "Thermo Electron LLS (India) Pvt. Ltd. All rights reserved"  '---4.85  14.04.09
		//---4.85  14.04.09
	public const  gConst_AboutCompany = "Thermo Scientific. All rights reserved";

	public const  Const_PPM = "ppm";
		#End Region
	public const  Const_PPB = "ppb";

	#Region " Public Enums "

	public enum EnumMessageType
	{
		Information = 1,
		Question = 2
	}

	public enum EnumErrorMessage
	{
		NO_ERROR = 1,
		COMM_ERROR = 6,
		LOBYTE_ERROR = 2,
		HIBYTE_ERROR = 3,
		COARSEHOME_ERROR = 3,
		FINEHOME_ERROR = 4,
		SHOME_ERROR = 5,
		SLITHOME_ERROR = 0,
		ADC_ERROR = 7
	}

	public enum EnumCalibrationMode
	{
		AA = 0,
		HCLE = 1,
		D2E = 2,
		EMISSION = 3,
		AABGC = 4,
		MABS = 5,
		SELFTEST = 6,
		AABGCSR = 7
	}

	public enum EnumOperationMode
	{
		MODE_AA = 1,
		MODE_AABGC = 2,
		MODE_EMMISSION = 3,
		MODE_UVABS = 4,
		MODE_SPECT = 5,
		MODE_UVSPECT = 6
	}

	public enum EnumErrorStatus
	{
		AIR_NOK = 0x80,
		N2O_NOK = 0x40,
		FUEL_NOK = 0x20,
		YELLOW_OK = 0xa,
		BLUE_OK = 0x6,
		FLAME_OK = 0x2,
		AA_CONNECTED = 0x4,
		TRAP_NOK = 0x2,
		DOOR_NOK = 0x1,
		SAIR_NON = 0x80,
		SN2O_NON = 0x40,
		//SSHUNT_ON = &H20   '---Commented on 30.03.09 for burner head changes
		BurnerHead_Present = 0x20,
		//---Added on 30.03.09 for burner head changes
		SFUEL_ON = 0x10,
		SIGNITE_ON = 0x8
	}

	public enum EnumAAS203Protocol
	{
		RESET = 0,
		//INSTRUMENT RESET
		ADCNF = 1,
		//READ ADC NONFILTER DATA
		ADCF = 2,
		//READ ADC FILTER DATA
		MODE = 3,
		//CALIBRATION MODE / To set operation mode of sample beam
		PMT = 4,
		//PMT VOLTAGE
		TURHOME = 5,
		//TURRET HOME
		TURPOS = 6,
		//TURRET POSITION
		HCLOFF = 7,
		HCLCUR = 8,
		D2OFF = 9,
		D2CUR = 10,
		WVHOME = 11,
		//CHECK WAVELENGTH HOME
		WVSET = 12,
		GETCURWV = 13,
		SLITHOME = 14,
		//SET ENTRY SLIT TO HOME POSITION
		SLITPOS = 15,
		TARHANTI = 16,
		TARHCLK = 17,
		TARFANTI = 18,
		TARFCLK = 19,
		WVCLK = 20,
		WVANTI = 21,
		SETWV = 22,
		NVHOME = 23,
		BHHOME = 24,
		NVANTI = 25,
		NVCLOCK = 26,
		BHCLOCK = 27,
		BHANTI = 28,
		AIRON = 29,
		AIROFF = 30,
		N2OON = 31,
		N2OOFF = 32,
		SHUNTON = 33,
		SHUNTOFF = 34,
		FUELON = 35,
		FUELOFF = 36,
		AIRN2O = 37,
		N2OAIR = 38,
		IGNITEON = 39,
		IGNITEOFF = 40,
		PNEMSTATUS = 41,
		//CHECK PNEUMATIC STATUS
		PSSTATUS = 42,
		//CHECK PRESSURE SENSORS (AIR, N20, FUEL) ALSO RETURNS FLAME STATUS (YELLOW,BLUE OR NOT OK)
		AAON = 43,
		AAOFF = 44,
		NAON = 45,
		NAOFF = 46,
		CHKBURNER = 47,
		SPECT = 48,
		GETNV = 49,
		GETBH = 50,
		D2ON = 51,
		SETBH = 52,
		ADCFG = 53,
		MICROON = 54,
		MICROOFF = 55,
		GAINX10_ON = 56,
		GAINX10_OFF = 57,
		TURROTSTEPCLK = 58,
		TURROTSTEPANTI = 59,
		NVANTISTEPS = 60,
		NVCLKSTEPS = 61,
		BHCLKSTEPS = 62,
		BHANTISTEPS = 63,
		BHSCAN = 64,
		NVSCAN = 65,
		PRN_INIT = 66,
		PRN_REPORT = 67,
		PRN_PEND = 68,
		PRN_SET_MAXSTD = 69,
		PRN_SET_STD_PTR = 70,
		PRN_SET_STDABS = 71,
		PRN_SET_SAMP_PTR = 72,
		PRN_CHAR_FROM_PC = 73,
		PRN_CRLF_FROM_PC = 74,
		PRN_STD_SPACE_FROM_PC = 75,
		PRN_PRINT_SPACE_FROM_PC = 76,
		PRN_PRINT_LINE_FROM_PC = 77,
		PC_END = 100,
		SPBREAK = 101,
		RESETACK = 102,
		AA203D = 103,
		RESETACK_AA201 = 104,
		CHKSUMERR = 103,
		RETURNACK = 1,
		//---Commands for Double Beam
		//RESET_RB = 68       'To initialise refernce beam monitoring controller
		//Get_RefBaseVal = 69 'To get reference beam base value after its auto zero process
		//SETMODE_RB = 70     'To set operation mode of refernce beam
		//ADCFILTER_RB = 72   'To get average adc reading of reference beam
		//SPECTRUM_RB = 74    'To plot energy spectrum of reference beam
		//SETPMT_RB = 75      'To set pmt voltage of refence beam
		//SLIT_HOME_EXIT = 78 'Sample beam exit slit home position
		//SLIT_POS_EXIT = 79  'Sample beam exit slit positioning
		//SETMODE_DB = 80     'To set operation mode of sample beam & refence beam both
		//ADCFILTER_DB = 82   'To get average adc reading of double beam 
		//SETPMT_DB = 85      'To set both sample pmt voltage & reference pmt voltage
		//SLIT_HOME_DB = 86   'Sample beam entry & exit slits home position
		//SLIT_POS_DB = 87    'Sample beam entry & exit slits positioning
		//GET_Absoffset = 88  'To read offset in zero absorbance value
		////----- Added by Sachin Dokhale Ref. by Vilas Shinde
		RESET_RB = 79,
		//To initialise refernce beam monitoring controller
		Get_RefBaseVal = 80,
		//To get reference beam base value after its auto zero process
		SETMODE_RB = 81,
		//To set operation mode of refernce beam
		ADCFILTER_RB = 83,
		//To get average adc reading of reference beam
		SPECTRUM_RB = 85,
		//To plot energy spectrum of reference beam
		SETPMT_RB = 86,
		//To set pmt voltage of refence beam
		SLIT_HOME_EXIT = 89,
		//Sample beam exit slit home position
		SLIT_POS_EXIT = 90,
		//Sample beam exit slit positioning
		SETMODE_DB = 91,
		//To set operation mode of sample beam & refence beam both
		ADCFILTER_DB = 93,
		//To get average adc reading of double beam 
		SETPMT_DB = 96,
		//To set both sample pmt voltage & reference pmt voltage
		SLIT_HOME_DB = 97,
		//Sample beam entry & exit slits home position
		SLIT_POS_DB = 98,
		//Sample beam entry & exit slits positioning
		GET_Absoffset = 99
		//To read offset in zero absorbance value
		////------

	}

	public enum EnumAutoSampler
	{
		//RESET = 0 'INSTRUMENT RESET
		//ADCNF = 1 ' READ ADC NONFILTER DATA
		//ADCF = 2 'READ ADC FILTER DATA
		//MODE = 3 'CALIBRATION MODE
		//PMT = 4 'PMT VOLTAGE
		//TURHOME = 5 'TURRET HOME
		//TURPOS = 6 'TURRET POSITION
		//HCLOFF = 7
		//HCLCUR = 8
		//D2OFF = 9
		//D2CUR = 10
		//WVHOME = 11 'CHECK WAVELENGTH HOME
		//WVSET = 12
		//GETCURWV = 13
		//SLITHOME = 14 'CHECK SLIT HOME
		//SLITPOS = 15
		//TARHANTI = 16
		//TARHCLK = 17
		//TARFANTI = 18
		//TARFCLK = 19
		//WVCLK = 20
		//WVANTI = 21
		//SETWV = 22
		//NVHOME = 23
		//BHHOME = 24
		//NVANTI = 25
		//NVCLOCK = 26
		//BHCLOCK = 27
		//BHANTI = 28
		//AIRON = 29
		//AIROFF = 30
		//N2OON = 31
		//N2OOFF = 32
		//SHUNTON = 33
		//SHUNTOFF = 34
		//FUELON = 35
		//FUELOFF = 36
		//AIRN2O = 37
		//N2OAIR = 38
		//IGNITEON = 39
		//IGNITEOFF = 40
		//PNEMSTATUS = 41 'CHECK PNEUMATIC STATUS
		//PSSTATUS = 42 'CHECK PRESSURE SENSORS (AIR, N20, FUEL) ALSO RETURNS FLAME STATUS (YELLOW,BLUE OR NOT OK)
		//AAON = 43
		//AAOFF = 44
		//NAON = 45
		//NAOFF = 46
		//CHKBURNER = 47
		//SPECT = 48
		//GETNV = 49
		//GETBH = 50
		//D2ON = 51
		//SETBH = 52
		//ADCFG = 53
		//MICROON = 54
		//MICROOFF = 55
		//GAINX10_ON = 56
		//GAINX10_OFF = 57
		//TURROTSTEPCLK = 58
		//TURROTSTEPANTI = 59
		//NVANTISTEPS = 60
		//NVCLKSTEPS = 61
		//BHCLKSTEPS = 62
		//BHANTISTEPS = 63
		//BHSCAN = 64
		//NVSCAN = 65
		//PRN_INIT = 66
		//PRN_REPORT = 67
		//PRN_PEND = 68
		//PRN_SET_MAXSTD = 69
		//PRN_SET_STD_PTR = 70
		//PRN_SET_STDABS = 71
		//PRN_SET_SAMP_PTR = 72
		//PRN_CHAR_FROM_PC = 73
		//PRN_CRLF_FROM_PC = 74
		//PRN_STD_SPACE_FROM_PC = 75
		//PRN_PRINT_SPACE_FROM_PC = 76
		//PRN_PRINT_LINE_FROM_PC = 77
		//PC_END = 100
		//SPBREAK = 101
		//RESETACK = 102
		//RESETACK_AA202 = 104
		//CHKSUMERR = 103
		Home = Asc("H"),
		GoToXY = Asc("G"),
		ProbeUp = Asc("U"),
		ProbeDown = Asc("D"),
		PumpOFF = Asc("F"),
		PumpON = Asc("O"),
		PumpONRev = Asc("V")

	}

	public enum EnumService_Mode
	{
		Main = 0,
		Spectrum = 1,
		Photometry = 2,
		Kinetics = 3,
		Multiomponent = 4,
		Quantitative = 5,
		TimeScan = 6,
		Serviceutilities = 7
	}

	public enum EnumMethodMode
	{
		NewMode = 1,
		EditMode = 2
	}

	public enum EnumAppMode
	{
		DemoMode = 0,
		//203 Demo
		FullVersion_203 = 1,
		FullVersion_203D = 2,
		FullVersion_201 = 3,
		DemoMode_203D = 4,
		DemoMode_201 = 5
	}

	public enum EnumZeroOrderThreadType
	{
		ZeroOrder = 1,
		Optimization = 2
	}

	public enum enumMeasurementMode
	{
		Integrate = 1,
		PeakHeight = 2,
		PeakArea = 3
	}

	public enum EnumHardwareLockType : int
	{
		Not_Lock = 0,
		LPT_Lock = 1,
		USB_Lock = 2
	}

	public enum EnumApplicationMode
	{
		//Added by Saurabh
		ServiceUtility = 0,
		AAS = 1
	}

	public enum enumUnit
	{
		PPM = 1,
		Percent = 2,
		PPB = 3
	}

	public enum EnumIQOQPQtestId
	{
		//ENUM added by ; dinesh wagh on 2.2.2010
		ePQAtt1 = 1,
		ePQ2 = 2,
		ePQ3 = 3
	}

	#End Region

	#Region " Message Interface Constants "

	public const  constEnterMethodName = 1;
	public const  constEnterUserName = 2;
	public const  contMethodCreatedSuccessfully = 3;
	public const  constEnterTurretNo = 4;
	public const  constNotConnectedToDatabase = 5;
	public const  constEnterOnlyNos = 6;
	public const  constInputProperData = 7;
	public const  constFailedToUpdateFile = 8;
	public const  constFailedToLoadFile = 9;
	public const  constComPortBusy = 10;
	public const  constComPortNotAvailable = 11;
	public const  constPortAlreadyOpen = 12;
	public const  constAirOn = 13;
	public const  constAirOFF = 14;
	public const  constMicroOFF = 15;
	public const  constGain10XOFF = 16;
	public const  constNVHome = 17;
	public const  constBHHome = 18;
	public const  constPMTBit = 19;
	public const  constPMTVolt = 20;
	public const  constAllLampOff = 21;
	public const  constADCNonFilter = 22;
	public const  constADCFilter = 23;
	public const  constCalibrationMode = 24;
	public const  constLowAirPressure = 25;
	public const  constLowN2OPressure = 26;
	public const  constLowFuelPressure = 27;
	public const  constPressureSensorError = 28;
	public const  constBurnerCheckError = 29;
	public const  constSlitWidthError = 30;
	public const  constWVHomeError = 31;
	public const  constCoarseWVHomeError = 32;
	public const  constFineWVHomeError = 33;
	public const  constMechWVHomeError = 34;
	public const  constSetCurWvError = 35;
	public const  constGetCurWvError = 36;
	public const  constRotateWvClkError = 37;
	public const  constRotateWvAntiClkError = 38;
	public const  constSetHCLCurError = 39;
	public const  constRequireGreaterPMT = 40;
	public const  constPMTLessthan50 = 41;
	public const  constTurretModuleError = 42;
	public const  constZeroOrderPeakNotFound = 43;
	public const  constLampNotConnected = 44;
	public const  constRotateTurClkError = 45;
	public const  constRotateAntiTurClkError = 46;
	public const  constRotateStepsTurClkError = 47;
	public const  constRotateStepsTurAntiClkError = 48;
	public const  constErrorPosnTurret = 49;

	public const  constErrorPosnTurretHome = 50;
	public const  constCommError = 51;
	public const  constWantToDelete = 52;
	public const  constDeleteConfirmation = 53;
	public const  constExit = 54;
	public const  constFieldsRequired = 55;
	public const  constMethodNameExists = 56;
	public const  constErrorSpectrum = 57;
	public const  constN2O_ON = 58;
	public const  constN2O_OFF = 59;
	public const  constFUEL_ON = 60;
	public const  constFUEL_OFF = 61;
	public const  constIGNITE_ON = 62;
	public const  constIGNITE_OFF = 63;
	public const  constADCNonFilteredValue = 64;
	public const  constADCNonFilteredValueReceived = 65;
	public const  constOFFAir = 66;
	public const  constCongratsOFFAir = 67;
	public const  constONAir = 68;
	public const  constCongratsONAir = 69;
	public const  constOFFN2O = 70;
	public const  constCongratsOFFN2O = 71;
	public const  constONNN2O = 72;
	public const  constCongratsONN2O = 73;
	public const  constOFFFUEL = 74;
	public const  constCongratsOFFFUEL = 75;
	public const  constONFUEL = 76;
	public const  constCongratsONFUEL = 77;
	public const  constOFFIGNITE = 78;
	public const  constCongratsOFFIGNITE = 79;
	public const  constONIGNITE = 80;
	public const  constCongratsONIGNITE = 81;
	public const  constSlitHome = 82;
	public const  constCongratsSlitHome = 83;
	public const  constWavelengthHome = 84;
	public const  constCongratsWavelengthHome = 85;
	public const  constOFFAllLamps = 86;
	public const  constCongratsOFFAllLamps = 87;
	public const  constTurretHome = 88;
	public const  constCongratsTurretHome = 89;
	public const  constMethodNotLoaded = 90;
	public const  constOFFD2 = 91;
	public const  constCongratsOFFD2 = 92;
	public const  constOND2 = 93;
	public const  constCongratsOND2 = 94;
	public const  constErrorSettingPMT = 95;
	public const  constPMT2High = 96;
	public const  constPMT2Low = 97;
	public const  constLowAirPressureRetry = 98;
	public const  constLowNitrousPressureRetry = 99;

	public const  constLowFuelPressureRetry = 100;
	public const  constErrorSlitHome = 101;
	public const  constCommPortError = 102;
	public const  constErrorFlameOFF = 107;
	public const  constWLMAXlessthanWLMIN = 108;
	public const  constNOPeakORValley = 109;
	public const  constErrorPopulatingPeakValleyData = 110;
	public const  constSpectrumNotPresent = 111;
	public const  constErrorFileSaving = 112;
	public const  constSpectrumScanningFailed = 113;
	public const  constErrorAddingSpectrumData = 114;
	public const  constAspirate_Blank = 115;
	public const  constErrorFlameON = 116;
	public const  constIncorrectPassword = 117;
	public const  constUserNotSelected = 118;
	public const  constPasswordChange = 119;
	public const  constDatabaseNameNull = 120;
	public const  constConnectionStrNotInit = 121;
	public const  constErrorConnectionOpening = 122;
	public const  constNullConnectionStr = 123;
	public const  constNullStrForQuery = 124;
	public const  constNoRowsEffected = 125;
	public const  constNullStrForFieldName = 126;
	public const  constNullStrForTableName = 127;
	public const  constNullStrForIndexField = 128;
	public const  constFileNotFound = 129;
	public const  constFileRetrievedSuccessfully = 130;
	public const  constEnterUserNamePassword = 131;
	public const  constConfirmPassword = 132;
	public const  constInvalidPasswordConfirm = 133;
	public const  constLogDeletedSuccessfully = 134;
	public const  constDeleteLogs = 135;
	public const  constUserPermissionsSaved = 136;
	public const  constNoPeaksValleyDetected = 137;
	public const  constErrorPopulatingPeak = 138;
	//Public Const constErrorLockingModeStatus = 139 Used in IQOQPQ
	////-----  
	public const  constMicroON = 140;
	public const  constReduceHCL = 141;
	public const  constErrorFULLSCALE = 142;
	////-----

	public const  constErrorSettingD2Current = 143;
	public const  constFlameOFF = 144;
	public const  constStandardAbsorbance = 145;
	public const  constSampleAbsorbance = 146;
	public const  constOptimise = 147;
	public const  constNoLamp = 148;
	public const  constErrorTurret = 149;
	public const  constCurrent = 150;
	public const  constSlitWidth = 151;
	public const  constAnalyticalPeak = 152;
	public const  constWavelengthRange = 153;
	public const  constWantManualOptimisation = 154;
	public const  constWorkUnderProcess = 155;
	public const  constAutoSamplerConnLost = 156;
	public const  constTurretNotOptimised = 157;
	public const  constTurretPositionMismatch = 158;
	public const  constCommandValue = 159;
	public const  constSaveAs = 160;
	public const  constNoStandards = 161;
	public const  constNoMethods = 162;
	public const  constDataExists = 163;
	public const  constOnlyDecimal = 164;
	public const  constAlreadyNAFlame = 165;
	public const  constBlankZero = 166;
	public const  constMonochromatorError = 167;
	public const  constADCError = 168;
	public const  constFlameRetry = 169;
	public const  constRepeatValue = 170;
	public const  constStdsInIncreasingOrder = 171;
	public const  constD2CurrentRange = 172;
	public const  constHCLcurrentRange = 173;
	public const  constPMTRange = 174;
	public const  constSamplesChanged = 175;
	//**************31 MAY 2007************************
	public const  constUserExists = 176;
	public const  constPasswordCannotBlank = 177;
	public const  constInvalidPassword = 178;
	public const  constErrorAutoSamplerHome = 179;
	public const  constAutoSamplerPosition = 180;
	public const  constAutoSamplerBetween2and65 = 181;
	public const  constAutoSamplerBlankPositions = 182;
	public const  constAutoSamplerNumericValues = 183;
	public const  constAutoSamplerXaxisValue = 184;
	public const  constAutoSamplerYaxisValue = 185;
	public const  constAutoSamplerConnectionLost = 186;
	public const  constIncreaseHCl = 187;
	public const  constFlameAlreadyExtinguish = 188;
	public const  constAlreadyAAFlame = 189;
	public const  constReadyforFlame = 190;
	public const  constFlameErrorFlameOff = 191;
	public const  constFlameErrorFuelOff = 192;
	public const  constFlameErrorAirOff = 193;
	public const  constFlameErrorN2OOff = 194;
	public const  constRemoveBurner = 195;
	public const  constRemoveCuvette = 196;
	public const  constNoLampMeasurement = 197;
	public const  constErrorLampPosition = 198;
	public const  constLampNotOptimised = 199;
	public const  constD2Peak = 200;
	public const  constLampOptimisation = 201;
	public const  constEmissionPeak = 202;
	public const  constExitEnergyScan = 203;
	public const  constExitBaseLine = 204;
	public const  constTurretPositionError = 205;
	public const  constExitSlitHome = 206;
	public const  constErrorGettingBurnerHeight = 207;
	public const  constErrorRecivedBlockBurner = 208;
	public const  constErrorTransmitBlockBurner = 209;
	public const  constErrorSettingBurnerHeight = 210;
	public const  constNABurnerNotConnected = 211;
	public const  constFillWaterInTrap = 212;
	public const  constDoorNotClosed = 213;
	public const  constAirPressureLow = 214;
	public const  constFuelPressureLow = 215;
	public const  constErrorAutoIgnition = 216;
	public const  constYellowFlameNotObtainable = 217;
	public const  constBlueFlameNotObtainable = 218;
	public const  constLoadLastOptimisedFuelConditions = 219;
	public const  constLoadLastOptimisedBurnerConditions = 220;
	public const  constErrorSettingMaxFuel = 221;
	public const  constNAFlameSet = 222;
	public const  constLoadLastOptimisedFuelNBurnerConditions = 223;
	public const  constSettingLastConditions = 224;
	public const  constBlueFlameSet = 225;
	public const  constAABurnerNotConnected = 226;
	public const  constFillWaterTrap = 227;
	public const  constAADoorNotCLosed = 228;
	public const  constAAAirPressureLow = 229;
	public const  constAAFuelPressureLow = 230;
	public const  constAAAutoIgnitionError = 231;
	public const  constAAYellowFlameNotObtainable = 232;
	public const  constAABlueFlameNotObtainable = 233;
	public const  constAAErrorSettingMaxFuel = 234;
	public const  constErrorGettingAbsOffset = 235;
	public const  constN2OPressureLow = 236;
	public const  constAspirateMaxStd = 237;
	public const  constErrorAbsReceiving = 238;
	public const  constErrorAbsTransmit = 239;
	public const  constErrorInitRefBeam = 240;
	public const  constRemoveUSBHWLock = 241;
	public const  constPlugUSBHWLoack = 242;
	public const  constErrorHWLock = 243;
	public const  constDemoPeriodExpired = 244;
	public const  constSetMaximisePosition = 245;
	public const  constPerformBaseLine = 246;
	public const  constFileNotSaved = 247;
	public const  constAccessDenied = 248;
	public const  constInvalidRange = 249;
	public const  constErrorPeakValley = 250;
	public const  constManualLampOptimisation = 251;
	public const  constPreviousStandards = 252;
	public const  constNewAnalysis = 253;
	public const  constValueMinToMax = 254;
	public const  constLampInUse = 255;
	public const  constLampAlreadyInUse = 256;
	public const  constSelectedRunNoDeletd = 257;
	public const  constSelectedRunNo = 258;
	public const  constLampPositionMismatch = 259;
	public const  constLampNotPresent = 260;
	public const  constNoStds = 261;
	public const  constAnalysisUnderProgress = 262;
	public const  constFlameIgnited = 263;
	public const  constFlameExtinguished = 264;
	public const  constContinueAnalysis = 265;
	public const  constCheckValue = 266;
	public const  constEnterStdConc = 267;
	public const  constFirstZeroStdConc = 268;
	public const  constUVRange = 269;
	public const  constConfigurationError = 270;
	public const  constErrorIni = 271;
	public const  constErrorHardware = 272;
	public const  constExitUV = 273;
	//Public Const constErrorSlitHome = 101
	public const  constErrorEntrySlitHome = 274;
	public const  constErrorExitSlitHome = 275;
	//Public Const constSlitWidthError = 30
	public const  constEntrySlitWidthError = 276;
	public const  constExitSlitWidthError = 277;
	//Public Const constExitSlitWidthError = 277
	//Public Const constExitSlitWidthError = 277
	//Public Const constExitSlitWidthError = 277
	public const  constSetFuelFlow = 278;

	public const  constBurnerHeadMsg = 279;


	#End Region

	#Region " Database Column Name Constants "

	public const  ConstColumnMethodType = "MethodType";
	public const  ConstColumnElementID = "ELE_ID";
	public const  ConstColumnSlit = "SLIT";
	public const  ConstColumnAtNo = "ATNO";
	public const  ConstColumnElementName = "NAME";
	public const  constColumnElementFullName = "ELE_NAME";
	public const  ConstColumnCurrent = "CURRENT";
	public const  ConstColumnSlitEms = "SLITEMS";
	public const  ConstColumnWV = "WV";
	public const  ConstColumnAADetailsID = "AADetails_ID";
	public const  ConstColumnUnit = "Unit";
	public const  ConstColumnUnitID = "UnitID";
	public const  ConstColumnMeasurementMode = "MeasurementMode";
	public const  ConstColumnMeasurementModeID = "MeasurementModeID";

	public const  ConstColumnMethodTypeID = "MethodTypeID";
	#End Region

}
