using AAS203Library.Method;
using AAS203Library.Instrument;
using IQOQPQ.IQOQPQ.IQOQPQ;
using System.Diagnostics;
using System.Runtime.InteropServices;
using AAS203.FuelConditions;


class modGlobalDeclarations
{

		//29.04.10
	public clsFuelDataCollection gobjFuelDataCollection = new clsFuelDataCollection();

		//---30.03.09
	public bool gblnBurnerMsg;
	//Public gblnMessageDisplayed As Boolean '---30.03.09   'commented on 26.04.09 for ver 4.87

	public int gintAspirationType = 0;
		//29.04.08 
	public int gintCalcMode = 100;
		//16.03.08
	public bool gblnIsDemoWithRealData = false;

		//28.09.07
	public bool gblnIsPeakSearchStarted = false;
		//28.09.07
	public bool gblnSetSpeedIssue = true;

	public ErrorHandler.ErrorHandler gobjErrorHandler;
	public clsTimer gobjclsTimer;
	public frmMDIMain gobjMain;
	public frmMDIMainService gobjMainService;
		//Saurabh
	public frmServiceRoutines gobjService;

		//--global variable for com port selected
	public int gintCommPortSelected;
	public int gintCommPortSelectedForAutoSampler;
	public bool gblnIsAutoSamplerEnabled;
	public bool gblnTestAutoSampler = true;
	public int[] gintCommPort;

	public string gstrCustomer;
		//-- global variable for instrument Name
	public string gstrTitleInstrumentType = "AA 203";
		//-- global variable for initialisation of instrument is done or not
	public bool gblnInitialization = false;

	public clsCommProtocolFunctions gobjCommProtocol;
	//Public gobjCommProtocol As clsProtocol

	public clsMethodCollection gobjMethodCollection = new clsMethodCollection();
	public clsMethod gobjNewMethod;
	public int gIntMethodID;

	public clsDataAccessLayer gobjDataAccess;
	public clsMessageAdapter gobjMessageAdapter = new clsMessageAdapter();
	public ClsAAS203 gobjClsAAS203 = new ClsAAS203();
	public clsMethod gobjReportOptions = new clsMethod();

	public clsStandardGraph gobjclsStandardGraph = new clsStandardGraph();

	public ClsInstrument gobjInst;

	public bool HydrideMode = false;

	public bool gblnInComm = false;

	public int gintTurretToOptimizeForServiceUtility = 0;
	//-----------------------
	//Public gdblPmtv As Double
	//Public gdblCurWv As Double
	//Public gdblWvzero As Double
	//Public gintlamp_opt_pos As Integer
	//-------------------------
	public bool gblnCookBookReport = false;
	public bool gblnDemoMode = true;
	public clsHardwareLock gobjHardwareLock = new clsHardwareLock();
	public clsHardwareLock_USB gobjHardwareLock_USB = new clsHardwareLock_USB();

	public clsHardwareLock_LPT gobjHardwareLock_LPT = new clsHardwareLock_LPT();
	public IniSettings gstructSettings = new IniSettings();
	////----- added by Sachin Dokhale
	////----- Used for Thread control
	public bool gblnSpectrumTerminated = false;
	public bool gblnSpectrumWait = false;
	public bool gblnSmoothFilter = true;

	public bool gblnCheckMinAbsScanLmt = false;
	////'----- Report Page Setting
	public System.Drawing.Printing.PageSettings gobjPageSetting = new System.Drawing.Printing.PageSettings();
	////-----
	public bool gblnBaseLine = false;
	public frmStatus gobjfrmStatus;
	public EnumSpectrumMode gintSpectrumMode = 0;

	public EnumBH_FP_Opimisation gintOptimisation = EnumBH_FP_Opimisation.BurnerHeight;

	public bool gblnUVS = false;
	public bool gblnUVABS = true;
	public int[] gintSample_adc;

	public int[] gintSample_adc_RefBeam;

	public int gintTimeConstant = 2;

	public IQOQPQ.IQOQPQ.IQOQPQ gobjIQOQPQ;
	public int gintNV_POS;
	public System.Random gRandom = new System.Random();
		//--- Photometry , spectrum , time scan , kinetic etc
	public Int16 OPERATION_MODE;

	public clsBgFlameStatus gobjclsBgFlameStatus;
	public methodActiveSettings gobjchkActiveMethod;
		//Added for Lamp parameter screen
	public int gintSelectedLampParameter;
	public enumInstrumentBeamType gintInstrumentBeamType = enumInstrumentBeamType.SingleBeam;
		//by pankaj on 18.1.08  for service beam type
	public enumInstrumentBeamType gintServiceBeamType = enumInstrumentBeamType.DoubleBeam;
	public bool gblnIsInstReset = false;
	public bool gblnSTD_ADDN = true;
	////-----

		//Saurabh 05.07.07
	public double gDblAbsValue_IQOQPQ_Attachment1 = 0;
		//Saurabh 22.07.07
	public bool IsInIQOQPQ = false;
		//200
	public int gintTimeDelay = 25;


	public bool gblnIsInstrumentConditionsActive = true;
	public double M_WvStartRange;

	public double M_WvLastRange;
	public bool ReInitLampInstParameters = false;
	public bool gblnIgnite_Test_Exit = false;
	////--- Added Sachin Dokhale for AA201  and AA203 Lamp count on 22.05.08
	public string ConstInstFileName = "Inst.bin";
	////--- 
	public struct IniSettings
	{

		//---Setting for Hardware key

		public string HardwareKey;
		//---Setting for communication port
		//Public CommPort As Integer

		//---Setting for Hardware lock
		public int HardwareLock;
		public EnumHardwareLockType HardwareLockType;

		public int DemoDays;
		//--- Setting for SessionID  

		long SessionID;
		//---Whether Apllication is in Demo Mode or full mode

		public int AppMode;
		public bool D2Gain;
		public int BHStep;
		public int D2Pmt;

		public bool Mesh;
		public bool SetMinAbsLimit;
		public double AbsThresholdValue;

		public double TimeConstant;
		//---Added by Mangesh 
		public int Filter_Window_Size;
		public bool BlankCalculation;
		public bool CFR21Installation;
		public bool Enable21CFR;

		public bool EnableServiceUtility;

		public bool blnSelectColorPrinter;

		public int HydrideMode;
			//Saurabh
		public int ExeToRun;
		public bool IsCustomerDisplayMode;
		public WavelengthRange WavelengthRange;
		public bool EnableIQOQPQ;
			//4.85 14.04.09
		public bool NewModelName;
	}
	//Added By Pankaj  23 May 07 for chaking method inactive to active mode
	public struct methodActiveSettings
	{
		//Public fillInstruments As Boolean
		public bool fillParameters;
		public bool fillStdConcentration;
		public bool NewMethod;
		public bool CancelMethod;
		public bool IsMethodAddedToCollectionInDisconnectedMode;
	}

	public struct WavelengthRange
	{
		public double WvLowerBound;
		public double WvUpperBound;
	}

	////----- To added in method
	public struct _addSpect
	{
		double dblWvMin;
		double dblWvMax;
		double dblYmin;
		double dblYMax;
		int intMode;
		int intSpeed;
		int intCounter;

		bool blnPloted;
	}

	public struct AbsConc
	{
		public double ABS;

		public double CONC;
		public AbsConc(double dblABS, double dblConc)
		{
			ABS = dblABS;
			CONC = dblConc;
		}

	}


	public _addSpect addataSpect;

	public double[] adData;
	////-----
	//--- Enum for the toolbar indexes
	//Private Enum EnumToolBarButtons
	//    Parameter = 0
	//    LoadSpectrumFile = 2
	//    SaveSpectrumFile = 3
	//    StartScan = 5
	//    StopScan = 6
	//    Clear = 8
	//    ClearAndRedraw = 9
	//    Print = 10
	//    Baseline = 12
	//    Autozero = 13
	//    ReturnToSelectModes = 15
	//End Enum

	//Private Enum EnumToolBarImages
	//    ParameterEnabled = 0
	//    StartScanEnabled = 1
	//    StopScanEnabled = 2
	//    ClearEnabled = 3
	//    ClearAndRedrawEnabled = 4
	//    PrintEnabled = 5
	//    BaselineEnabled = 6
	//    AutozeroEnabled = 7
	//    ReturnToSelectModesEnabled = 8
	//    ParameterDisabled = 9
	//    StartScanDisabled = 10
	//    StopScanDisabled = 11
	//    ClearDisabled = 12
	//    ClearAndRedrawDisabled = 13
	//    PrintDisabled = 14
	//    BaselineDisabled = 15
	//    AutozeroDisabled = 16
	//    ReturnToSelectModesDisabled = 17
	//    LoadSpectrumFileEnabled = 18
	//    SaveSpectrumFileEnabled = 19
	//    LoadSpectrumFileDisabled = 20
	//    SaveSpectrumFileDisabled = 21
	//End Enum

	public enum EnumProcesses
	{
		FormInitialize = 1,
		//--- During Form Load

		LoadParameters = 2,
		//--- During Manual Loading of Paramters from a File  
		EditParameters = 3,
		//--- During Click of parameters on the Tool bar i.e Editing Of paramters 
		SaveParameters = 4,
		//--- During the Saving of parmaters after editing wants to save
		EditSystemParamters = 5,
		//--- Edit the Change over Wavelength Parameters


		LoadFile = 6,
		SaveFile = 7,
		//--- During Analysis Click by the User
		LoadChannel = 8,
		//--- When next scan is clicked

		ChannelToConstant = 9,
		ChannelToChannel = 10,
		//--- When repeat has been clicked
		AbsToTransmission = 11,
		//--- When New Analysis has been Clicked
		EnergyToAbs = 12,
		//--- When End of Analysis is Clicked

		Smooth = 13,
		//--- When Autozero is Clicked
		PeakPick = 14,

		StartScan = 15,
		StopsScan = 16,
		ClearAndRedraw = 17,
		Baseline = 18,
		Autozero = 19,
		Clear = 20,

		ChannelUp_Down = 21

	}

	public enum EnumStart_End
	{
		Start_of_Process = 1,
		//--- This is when the Process Starts
		End_of_Process = 2,
		//--- This is when the Process Ends
		Process_Running = 3,
		Process_Waiting = 4
	}

	public enum EnumDeserializeObjType
	{
		Parameter = 1,
		UVSpectrum = 2,
		EnergySpectrum = 3,
		UVSpectrumDB = 4,
		EnergySpectrumDB = 5

	}

	public enum EnumSpectrumMode : int
	{
		EnergySpectrum = 0,
		UVSpetrum = 1,
		TimeScan = 2
	}

	public enum EnumBH_FP_Opimisation : int
	{
		BurnerHeight = 0,
		FuelPresure = 1
	}


	//========Saurabh=============
	public System.DateTime gSetD2StartTime = System.DateTime.Now;
	public System.DateTime gSetWStartTime = System.DateTime.Now;
	public System.DateTime gSetInstrumentStartTime = System.DateTime.Now;
		// --- Path for the Settings.ini
	public string INI_SETTINGS_PATH;
	//============================
	public enum enumSelectBeamType : int
	{
		Sample,
		Reference
	}
}

