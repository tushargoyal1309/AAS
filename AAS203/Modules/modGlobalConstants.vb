Module modGlobalConstants

#Region " Public Constants "
    Public Const CONST_FUEL_CONDITIONS_FILE = "LastOpt.bin"

    Public Const gblnShowThreadOnfrmMDIStatusBar As Boolean = False
    Public Const CONST_CREATE_EXECUTION_LOG = 0
    Public Const CONST_ThemeFileName = "Theme.txt"
    Public Const CONST_DELAY = 3000
    Public Const CONST_LONG_DELAY = 30000
    Public Const CONST_VERY_LONG_DELAY = 120000
    Public Const CONST_LabName = "Thermo Scientific - Application Lab"  '---4.85  14.04.09
    Public Const CONST_LabName1 = "Application Lab"
    Public Const ConstDataGridPropertiesFileName = "DataGridProperties.txt"
    Public Const ConstMethodsFileName = "Methods.bin"
    Public Const ConstDBMethodsFileName = "DBMethods.bin"
    '//----- Added Sachin Dokhale for AA201  and AA203 Lamp count on 22.05.08
    '//--- tobe do and Ref. 
    '//Public Const ConstInstFileName = "Inst.bin"
    Public Const ConstInstFileName_203 = "Inst.bin"
    Public Const ConstInstFileName_201 = "InstB.bin"
    '//--- use this const for AAS 2.4
    Public Const ConstInstFileName_204 = "InstC.bin"
    '//---
    '//-----
    Public Const TARRATIO = 400.0 * 7.0 / 4.0 'for half step 400 and for full step 200
    Public Const WVZERORANGE = 300 '6.0 * 50 (wz -2 to 4 = 6 nm and in 1 nm 50 steps for monochromator

    'Public Const RANGEH = 50 'Original code
    Public Const RANGEH = 165 'Modified by suraj from 50 to 165
    Public Const WVRANGE = 100
    Public Const TURRETOPTRANGE = 333 'Added a new const in place of WVRANGE 100 to 333 (Manoj) 
    Public Const WVRANGE_AA201 = 50

    'Public Const CONST_STEPS_PER_NM As Double = 50
    Public Const CONST_STEPS_PER_NM As Double = 50 'modified by suraj from 50 to 83'
    Public Const CONST_STEPS_PER_NM_AA201 As Double = 25.0

    Public Graphite As Boolean = False
    Public Const VERY_LONG_DEALY = 120
    Public Const LONG_DEALY = 30
    Public Const DEFAULT_DELAY = 3
    Public Const NVSTEP = 10
    Public Const BHRATIO = 2.2
    Public Const MAXNVHOME = 5
    Public Const NVRED = (200 * 4)
    Public Const TOTBHLEN = 6
    Public Const MAXBHHOME = (200 * TOTBHLEN * BHRATIO)
    Public Const BHSTEP = (20 * BHRATIO)
    Public Const UVPMT = 270
    Public Const UVGAINWV = 240

    Public Const ZeroOrderThreadWindowLocationX = 10
    Public Const ZeroOrderThreadWindowLocationY = 65
    Public Const OptAllThreadWindowLocationX = 405
    Public Const OptAllThreadWindowLocationY = 65

    Public Const CONST_FASTStep = CONST_STEPS_PER_NM
    Public Const CONST_MEDIUMStep = CONST_FASTStep / 2
    Public Const CONST_SLOWStep = CONST_FASTStep / 10

    '//----- For AAS201
    Public Const CONST_FASTStep_AA201 = CONST_STEPS_PER_NM_AA201
    Public Const CONST_MEDIUMStep_AA201 = CONST_FASTStep_AA201 / 2
    'Public Const CONST_SLOWStep_AA201 = CONST_FASTStep_AA201 / 10  '---commented on 03.09.09
    Public Const CONST_SLOWStep_AA201 = CONST_FASTStep_AA201 / 8 '---changed on 03.09.09
    '//-----

    '--- File Extensions used in Spectrum mode
    'Public Const CONST_ChannelFileExt As String = ".chn"
    Public Const CONST_UVSpectrumFileExt As String = ".uvs"
    Public Const CONST_EnergySpectrumFileExt As String = ".ens"
    Public Const CONST_EnergySpectrumFileExtDB As String = ".dbe"

    '--- Maximum Buffer Size used in spectrum to calculate result
    Public Const MAX_RANGE = 11540

    '#define	BHSCANSTEP	10
    '#define	NVSCANSTEP	10
    Public Const CONST_BHSCANSTEP = 10
    Public Const CONST_NVSCANSTEP = 10

    Public Const ConstFILTMAX = 1001

    Public Const SMHCLDIS = 56
    Public Const SMHCLENB = 57

    '---System Parameters Settings
    Public Const SECTION_SYSTEMPARAMETERS As String = "SystemParameters"
    Public Const KEY_INSTRUMENT_BEAMTYPE As String = "InstrumentBeamType"
    Public Const KEY_INSTRESET_CONTINUOUS As String = "InstReset_continuous"
    Public Const KEY_Customer As String = "Customer"

    '--- Communication Settings 
    Public Const SECTION_COMMSETTINGS = "CommSettings"
    Public Const KEY_COMPORT = "ComPort"
    Public Const KEY_BAUDRATE = "BaudRate"
    Public Const KEY_PARITY = "Parity"
    Public Const KEY_DATABITS = "DataBits"
    Public Const KEY_STOPBITS = "StopBits"

    '--- AutoSampler Settings 
    Public Const SECTION_AUTOSAMPLER = "AutoSampler"
    Public Const KEY_SERIALPORT = "SamplerComPort"
    Public Const KEY_SAMPLERBAUDRATE = "SamplerBaudRate"
    Public Const KEY_INTAKETIME = "SampleIntakeTime"
    Public Const KEY_MeasurementTime = "MeasurementTime"
    Public Const KEY_WashTime = "WashTime"
    Public Const KEY_ProbeWaitTime = "ProbeDownWaitTime"
    Public Const KEY_DelayFactor = "DelayFactor"

    '--- Siper Settings 
    Public Const SECTION_Siper = "Sipper"
    Public Const KEY_SuckTime = "Suck"
    Public Const KEY_CleanTime = "Clean"
    Public Const KEY_EmptyTime = "Empty"
    'Public Const CONST_ParameterFileExt As String = ".par"

    Public Const CONST_FLAME_OK = &H2
    Public Const CONST_AA_CONNECTED = &H4

    '--- Instrument Type        Added by Saurabh 01.08.07
    Public Const CONST_AA203_FullVersion = "AA 203"
    Public Const CONST_AA203D_FullVersion = "AA 203D"
    Public Const CONST_AA201_FullVersion = "AA 201"
    Public Const CONST_AA203_DemoVersion = "AA 203 DEMO"
    Public Const CONST_AA203D_DemoVersion = "AA 203D DEMO"
    Public Const CONST_AA201_DemoVersion = "AA 201 DEMO"
    Public Const CONST_AA203 = "AA 203"


    '--4.85  14.04.09
    Public Const CONST_AA303_FullVersion = "AA 303"
    Public Const CONST_AA303D_FullVersion = "AA 303D"
    Public Const CONST_AA301_FullVersion = "AA 301"
    Public Const CONST_AA303_DemoVersion = "AA 303 DEMO"
    Public Const CONST_AA303D_DemoVersion = "AA 303D DEMO"
    Public Const CONST_AA301_DemoVersion = "AA 301 DEMO"
    '--4.85  14.04.09


    '--- No. of places to be formated after decimal     Added by Saurabh 01.08.07
    Public Const CONST_Format_Value_Concentration_PPB = 4
    Public Const CONST_Format_Value_Concentration = 2
    Public Const CONST_Format_Value_Absorbance = 3
    Public Const CONST_Format_Value_Emission = 1
    '//----- D2 Setting
    Public Const SECTION_D2Setting = "D2Setting"
    Public Const KEY_D2Current = "D2Cur"
    Public Const KEY_D2PMT = "D2PMT"

    'Public Const gConst_AboutCompany = "Thermo Electron LLS (India) Pvt. Ltd. All rights reserved"  '---4.85  14.04.09
    Public Const gConst_AboutCompany = "Thermo Scientific. All rights reserved"  '---4.85  14.04.09

    Public Const Const_PPM = "ppm"
    Public Const Const_PPB = "ppb"
#End Region

#Region " Public Enums "

    Public Enum EnumMessageType
        Information = 1
        Question = 2
    End Enum

    Public Enum EnumErrorMessage
        NO_ERROR = 1
        COMM_ERROR = 6
        LOBYTE_ERROR = 2
        HIBYTE_ERROR = 3
        COARSEHOME_ERROR = 3
        FINEHOME_ERROR = 4
        SHOME_ERROR = 5
        SLITHOME_ERROR = 0
        ADC_ERROR = 7
    End Enum

    Public Enum EnumCalibrationMode
        AA = 0
        HCLE = 1
        D2E = 2
        EMISSION = 3
        AABGC = 4
        MABS = 5
        SELFTEST = 6
        AABGCSR = 7
    End Enum

    Public Enum EnumOperationMode
        MODE_AA = 1
        MODE_AABGC = 2
        MODE_EMMISSION = 3
        MODE_UVABS = 4
        MODE_SPECT = 5
        MODE_UVSPECT = 6
    End Enum

    Public Enum EnumErrorStatus
        AIR_NOK = &H80
        N2O_NOK = &H40
        FUEL_NOK = &H20
        YELLOW_OK = &HA
        BLUE_OK = &H6
        FLAME_OK = &H2
        AA_CONNECTED = &H4
        TRAP_NOK = &H2
        DOOR_NOK = &H1
        SAIR_NON = &H80
        SN2O_NON = &H40
        'SSHUNT_ON = &H20   '---Commented on 30.03.09 for burner head changes
        BurnerHead_Present = &H20  '---Added on 30.03.09 for burner head changes
        SFUEL_ON = &H10
        SIGNITE_ON = &H8
    End Enum

    Public Enum EnumAAS203Protocol
        RESET = 0   'INSTRUMENT RESET
        ADCNF = 1   'READ ADC NONFILTER DATA
        ADCF = 2    'READ ADC FILTER DATA
        MODE = 3    'CALIBRATION MODE / To set operation mode of sample beam
        PMT = 4     'PMT VOLTAGE
        TURHOME = 5 'TURRET HOME
        TURPOS = 6  'TURRET POSITION
        HCLOFF = 7
        HCLCUR = 8
        D2OFF = 9
        D2CUR = 10
        WVHOME = 11 'CHECK WAVELENGTH HOME
        WVSET = 12
        GETCURWV = 13
        SLITHOME = 14 'SET ENTRY SLIT TO HOME POSITION
        SLITPOS = 15
        TARHANTI = 16
        TARHCLK = 17
        TARFANTI = 18
        TARFCLK = 19
        WVCLK = 20
        WVANTI = 21
        SETWV = 22
        NVHOME = 23
        BHHOME = 24
        NVANTI = 25
        NVCLOCK = 26
        BHCLOCK = 27
        BHANTI = 28
        AIRON = 29
        AIROFF = 30
        N2OON = 31
        N2OOFF = 32
        SHUNTON = 33
        SHUNTOFF = 34
        FUELON = 35
        FUELOFF = 36
        AIRN2O = 37
        N2OAIR = 38
        IGNITEON = 39
        IGNITEOFF = 40
        PNEMSTATUS = 41 'CHECK PNEUMATIC STATUS
        PSSTATUS = 42 'CHECK PRESSURE SENSORS (AIR, N20, FUEL) ALSO RETURNS FLAME STATUS (YELLOW,BLUE OR NOT OK)
        AAON = 43
        AAOFF = 44
        NAON = 45
        NAOFF = 46
        CHKBURNER = 47
        SPECT = 48
        GETNV = 49
        GETBH = 50
        D2ON = 51
        SETBH = 52
        ADCFG = 53
        MICROON = 54
        MICROOFF = 55
        GAINX10_ON = 56
        GAINX10_OFF = 57
        TURROTSTEPCLK = 58
        TURROTSTEPANTI = 59
        NVANTISTEPS = 60
        NVCLKSTEPS = 61
        BHCLKSTEPS = 62
        BHANTISTEPS = 63
        BHSCAN = 64
        NVSCAN = 65
        PRN_INIT = 66
        PRN_REPORT = 67
        PRN_PEND = 68
        PRN_SET_MAXSTD = 69
        PRN_SET_STD_PTR = 70
        PRN_SET_STDABS = 71
        PRN_SET_SAMP_PTR = 72
        PRN_CHAR_FROM_PC = 73
        PRN_CRLF_FROM_PC = 74
        PRN_STD_SPACE_FROM_PC = 75
        PRN_PRINT_SPACE_FROM_PC = 76
        PRN_PRINT_LINE_FROM_PC = 77
        PC_END = 100
        SPBREAK = 101
        RESETACK = 102
        AA203D = 103
        RESETACK_AA201 = 104
        CHKSUMERR = 103
        RETURNACK = 1
        '---Commands for Double Beam
        'RESET_RB = 68       'To initialise refernce beam monitoring controller
        'Get_RefBaseVal = 69 'To get reference beam base value after its auto zero process
        'SETMODE_RB = 70     'To set operation mode of refernce beam
        'ADCFILTER_RB = 72   'To get average adc reading of reference beam
        'SPECTRUM_RB = 74    'To plot energy spectrum of reference beam
        'SETPMT_RB = 75      'To set pmt voltage of refence beam
        'SLIT_HOME_EXIT = 78 'Sample beam exit slit home position
        'SLIT_POS_EXIT = 79  'Sample beam exit slit positioning
        'SETMODE_DB = 80     'To set operation mode of sample beam & refence beam both
        'ADCFILTER_DB = 82   'To get average adc reading of double beam 
        'SETPMT_DB = 85      'To set both sample pmt voltage & reference pmt voltage
        'SLIT_HOME_DB = 86   'Sample beam entry & exit slits home position
        'SLIT_POS_DB = 87    'Sample beam entry & exit slits positioning
        'GET_Absoffset = 88  'To read offset in zero absorbance value
        '//----- Added by Sachin Dokhale Ref. by Vilas Shinde
        RESET_RB = 79       'To initialise refernce beam monitoring controller
        Get_RefBaseVal = 80 'To get reference beam base value after its auto zero process
        SETMODE_RB = 81     'To set operation mode of refernce beam
        ADCFILTER_RB = 83   'To get average adc reading of reference beam
        SPECTRUM_RB = 85    'To plot energy spectrum of reference beam
        SETPMT_RB = 86      'To set pmt voltage of refence beam
        SLIT_HOME_EXIT = 89 'Sample beam exit slit home position
        SLIT_POS_EXIT = 90  'Sample beam exit slit positioning
        SETMODE_DB = 91     'To set operation mode of sample beam & refence beam both
        ADCFILTER_DB = 93   'To get average adc reading of double beam 
        SETPMT_DB = 96      'To set both sample pmt voltage & reference pmt voltage
        SLIT_HOME_DB = 97   'Sample beam entry & exit slits home position
        SLIT_POS_DB = 98    'Sample beam entry & exit slits positioning
        GET_Absoffset = 99  'To read offset in zero absorbance value
        DB_CHOPPER_ON = 33  ' Added by Mrutyunjaya
        DB_CHOPPER_OFF = 34  ' Added by Mrutyunjaya
        '//------

    End Enum

    Public Enum EnumAutoSampler
        'RESET = 0 'INSTRUMENT RESET
        'ADCNF = 1 ' READ ADC NONFILTER DATA
        'ADCF = 2 'READ ADC FILTER DATA
        'MODE = 3 'CALIBRATION MODE
        'PMT = 4 'PMT VOLTAGE
        'TURHOME = 5 'TURRET HOME
        'TURPOS = 6 'TURRET POSITION
        'HCLOFF = 7
        'HCLCUR = 8
        'D2OFF = 9
        'D2CUR = 10
        'WVHOME = 11 'CHECK WAVELENGTH HOME
        'WVSET = 12
        'GETCURWV = 13
        'SLITHOME = 14 'CHECK SLIT HOME
        'SLITPOS = 15
        'TARHANTI = 16
        'TARHCLK = 17
        'TARFANTI = 18
        'TARFCLK = 19
        'WVCLK = 20
        'WVANTI = 21
        'SETWV = 22
        'NVHOME = 23
        'BHHOME = 24
        'NVANTI = 25
        'NVCLOCK = 26
        'BHCLOCK = 27
        'BHANTI = 28
        'AIRON = 29
        'AIROFF = 30
        'N2OON = 31
        'N2OOFF = 32
        'SHUNTON = 33
        'SHUNTOFF = 34
        'FUELON = 35
        'FUELOFF = 36
        'AIRN2O = 37
        'N2OAIR = 38
        'IGNITEON = 39
        'IGNITEOFF = 40
        'PNEMSTATUS = 41 'CHECK PNEUMATIC STATUS
        'PSSTATUS = 42 'CHECK PRESSURE SENSORS (AIR, N20, FUEL) ALSO RETURNS FLAME STATUS (YELLOW,BLUE OR NOT OK)
        'AAON = 43
        'AAOFF = 44
        'NAON = 45
        'NAOFF = 46
        'CHKBURNER = 47
        'SPECT = 48
        'GETNV = 49
        'GETBH = 50
        'D2ON = 51
        'SETBH = 52
        'ADCFG = 53
        'MICROON = 54
        'MICROOFF = 55
        'GAINX10_ON = 56
        'GAINX10_OFF = 57
        'TURROTSTEPCLK = 58
        'TURROTSTEPANTI = 59
        'NVANTISTEPS = 60
        'NVCLKSTEPS = 61
        'BHCLKSTEPS = 62
        'BHANTISTEPS = 63
        'BHSCAN = 64
        'NVSCAN = 65
        'PRN_INIT = 66
        'PRN_REPORT = 67
        'PRN_PEND = 68
        'PRN_SET_MAXSTD = 69
        'PRN_SET_STD_PTR = 70
        'PRN_SET_STDABS = 71
        'PRN_SET_SAMP_PTR = 72
        'PRN_CHAR_FROM_PC = 73
        'PRN_CRLF_FROM_PC = 74
        'PRN_STD_SPACE_FROM_PC = 75
        'PRN_PRINT_SPACE_FROM_PC = 76
        'PRN_PRINT_LINE_FROM_PC = 77
        'PC_END = 100
        'SPBREAK = 101
        'RESETACK = 102
        'RESETACK_AA202 = 104
        'CHKSUMERR = 103
        Home = Asc("H")
        GoToXY = Asc("G")
        ProbeUp = Asc("U")
        ProbeDown = Asc("D")
        PumpOFF = Asc("F")
        PumpON = Asc("O")
        PumpONRev = Asc("V")

    End Enum

    Public Enum EnumService_Mode
        Main = 0
        Spectrum = 1
        Photometry = 2
        Kinetics = 3
        Multiomponent = 4
        Quantitative = 5
        TimeScan = 6
        Serviceutilities = 7
    End Enum

    Public Enum EnumMethodMode
        NewMode = 1
        EditMode = 2
    End Enum

    Public Enum EnumAppMode
        DemoMode = 0 '203 Demo
        FullVersion_203 = 1
        FullVersion_203D = 2
        FullVersion_201 = 3
        DemoMode_203D = 4
        DemoMode_201 = 5
    End Enum

    Public Enum EnumZeroOrderThreadType
        ZeroOrder = 1
        Optimization = 2
    End Enum

    Public Enum enumMeasurementMode
        Integrate = 1
        PeakHeight = 2
        PeakArea = 3
    End Enum

    Public Enum EnumHardwareLockType As Integer
        Not_Lock = 0
        LPT_Lock = 1
        USB_Lock = 2
    End Enum

    Public Enum EnumApplicationMode 'Added by Saurabh
        ServiceUtility = 0
        AAS = 1
    End Enum

    Public Enum enumUnit
        PPM = 1
        Percent = 2
        PPB = 3
    End Enum

    Public Enum EnumIQOQPQtestId
        'ENUM added by ; dinesh wagh on 2.2.2010
        ePQAtt1 = 1
        ePQ2 = 2
        ePQ3 = 3
    End Enum

#End Region

#Region " Message Interface Constants "

    Public Const constEnterMethodName = 1
    Public Const constEnterUserName = 2
    Public Const contMethodCreatedSuccessfully = 3
    Public Const constEnterTurretNo = 4
    Public Const constNotConnectedToDatabase = 5
    Public Const constEnterOnlyNos = 6
    Public Const constInputProperData = 7
    Public Const constFailedToUpdateFile = 8
    Public Const constFailedToLoadFile = 9
    Public Const constComPortBusy = 10
    Public Const constComPortNotAvailable = 11
    Public Const constPortAlreadyOpen = 12
    Public Const constAirOn = 13
    Public Const constAirOFF = 14
    Public Const constMicroOFF = 15
    Public Const constGain10XOFF = 16
    Public Const constNVHome = 17
    Public Const constBHHome = 18
    Public Const constPMTBit = 19
    Public Const constPMTVolt = 20
    Public Const constAllLampOff = 21
    Public Const constADCNonFilter = 22
    Public Const constADCFilter = 23
    Public Const constCalibrationMode = 24
    Public Const constLowAirPressure = 25
    Public Const constLowN2OPressure = 26
    Public Const constLowFuelPressure = 27
    Public Const constPressureSensorError = 28
    Public Const constBurnerCheckError = 29
    Public Const constSlitWidthError = 30
    Public Const constWVHomeError = 31
    Public Const constCoarseWVHomeError = 32
    Public Const constFineWVHomeError = 33
    Public Const constMechWVHomeError = 34
    Public Const constSetCurWvError = 35
    Public Const constGetCurWvError = 36
    Public Const constRotateWvClkError = 37
    Public Const constRotateWvAntiClkError = 38
    Public Const constSetHCLCurError = 39
    Public Const constRequireGreaterPMT = 40
    Public Const constPMTLessthan50 = 41
    Public Const constTurretModuleError = 42
    Public Const constZeroOrderPeakNotFound = 43
    Public Const constLampNotConnected = 44
    Public Const constRotateTurClkError = 45
    Public Const constRotateAntiTurClkError = 46
    Public Const constRotateStepsTurClkError = 47
    Public Const constRotateStepsTurAntiClkError = 48
    Public Const constErrorPosnTurret = 49
    Public Const constErrorPosnTurretHome = 50

    Public Const constCommError = 51
    Public Const constWantToDelete = 52
    Public Const constDeleteConfirmation = 53
    Public Const constExit = 54
    Public Const constFieldsRequired = 55
    Public Const constMethodNameExists = 56
    Public Const constErrorSpectrum = 57
    Public Const constN2O_ON = 58
    Public Const constN2O_OFF = 59
    Public Const constFUEL_ON = 60
    Public Const constFUEL_OFF = 61
    Public Const constIGNITE_ON = 62
    Public Const constIGNITE_OFF = 63
    Public Const constADCNonFilteredValue = 64
    Public Const constADCNonFilteredValueReceived = 65
    Public Const constOFFAir = 66
    Public Const constCongratsOFFAir = 67
    Public Const constONAir = 68
    Public Const constCongratsONAir = 69
    Public Const constOFFN2O = 70
    Public Const constCongratsOFFN2O = 71
    Public Const constONNN2O = 72
    Public Const constCongratsONN2O = 73
    Public Const constOFFFUEL = 74
    Public Const constCongratsOFFFUEL = 75
    Public Const constONFUEL = 76
    Public Const constCongratsONFUEL = 77
    Public Const constOFFIGNITE = 78
    Public Const constCongratsOFFIGNITE = 79
    Public Const constONIGNITE = 80
    Public Const constCongratsONIGNITE = 81
    Public Const constSlitHome = 82
    Public Const constCongratsSlitHome = 83
    Public Const constWavelengthHome = 84
    Public Const constCongratsWavelengthHome = 85
    Public Const constOFFAllLamps = 86
    Public Const constCongratsOFFAllLamps = 87
    Public Const constTurretHome = 88
    Public Const constCongratsTurretHome = 89
    Public Const constMethodNotLoaded = 90
    Public Const constOFFD2 = 91
    Public Const constCongratsOFFD2 = 92
    Public Const constOND2 = 93
    Public Const constCongratsOND2 = 94
    Public Const constErrorSettingPMT = 95
    Public Const constPMT2High = 96
    Public Const constPMT2Low = 97
    Public Const constLowAirPressureRetry = 98
    Public Const constLowNitrousPressureRetry = 99
    Public Const constLowFuelPressureRetry = 100

    Public Const constErrorSlitHome = 101
    Public Const constCommPortError = 102
    Public Const constErrorFlameOFF = 107
    Public Const constWLMAXlessthanWLMIN = 108
    Public Const constNOPeakORValley = 109
    Public Const constErrorPopulatingPeakValleyData = 110
    Public Const constSpectrumNotPresent = 111
    Public Const constErrorFileSaving = 112
    Public Const constSpectrumScanningFailed = 113
    Public Const constErrorAddingSpectrumData = 114
    Public Const constAspirate_Blank = 115
    Public Const constErrorFlameON = 116
    Public Const constIncorrectPassword = 117
    Public Const constUserNotSelected = 118
    Public Const constPasswordChange = 119
    Public Const constDatabaseNameNull = 120
    Public Const constConnectionStrNotInit = 121
    Public Const constErrorConnectionOpening = 122
    Public Const constNullConnectionStr = 123
    Public Const constNullStrForQuery = 124
    Public Const constNoRowsEffected = 125
    Public Const constNullStrForFieldName = 126
    Public Const constNullStrForTableName = 127
    Public Const constNullStrForIndexField = 128
    Public Const constFileNotFound = 129
    Public Const constFileRetrievedSuccessfully = 130
    Public Const constEnterUserNamePassword = 131
    Public Const constConfirmPassword = 132
    Public Const constInvalidPasswordConfirm = 133
    Public Const constLogDeletedSuccessfully = 134
    Public Const constDeleteLogs = 135
    Public Const constUserPermissionsSaved = 136
    Public Const constNoPeaksValleyDetected = 137
    Public Const constErrorPopulatingPeak = 138
    'Public Const constErrorLockingModeStatus = 139 Used in IQOQPQ
    '//-----  
    Public Const constMicroON = 140
    Public Const constReduceHCL = 141
    Public Const constErrorFULLSCALE = 142
    '//-----

    Public Const constErrorSettingD2Current = 143
    Public Const constFlameOFF = 144
    Public Const constStandardAbsorbance = 145
    Public Const constSampleAbsorbance = 146
    Public Const constOptimise = 147
    Public Const constNoLamp = 148
    Public Const constErrorTurret = 149
    Public Const constCurrent = 150
    Public Const constSlitWidth = 151
    Public Const constAnalyticalPeak = 152
    Public Const constWavelengthRange = 153
    Public Const constWantManualOptimisation = 154
    Public Const constWorkUnderProcess = 155
    Public Const constAutoSamplerConnLost = 156
    Public Const constTurretNotOptimised = 157
    Public Const constTurretPositionMismatch = 158
    Public Const constCommandValue = 159
    Public Const constSaveAs = 160
    Public Const constNoStandards = 161
    Public Const constNoMethods = 162
    Public Const constDataExists = 163
    Public Const constOnlyDecimal = 164
    Public Const constAlreadyNAFlame = 165
    Public Const constBlankZero = 166
    Public Const constMonochromatorError = 167
    Public Const constADCError = 168
    Public Const constFlameRetry = 169
    Public Const constRepeatValue = 170
    Public Const constStdsInIncreasingOrder = 171
    Public Const constD2CurrentRange = 172
    Public Const constHCLcurrentRange = 173
    Public Const constPMTRange = 174
    Public Const constSamplesChanged = 175
    '**************31 MAY 2007************************
    Public Const constUserExists = 176
    Public Const constPasswordCannotBlank = 177
    Public Const constInvalidPassword = 178
    Public Const constErrorAutoSamplerHome = 179
    Public Const constAutoSamplerPosition = 180
    Public Const constAutoSamplerBetween2and65 = 181
    Public Const constAutoSamplerBlankPositions = 182
    Public Const constAutoSamplerNumericValues = 183
    Public Const constAutoSamplerXaxisValue = 184
    Public Const constAutoSamplerYaxisValue = 185
    Public Const constAutoSamplerConnectionLost = 186
    Public Const constIncreaseHCl = 187
    Public Const constFlameAlreadyExtinguish = 188
    Public Const constAlreadyAAFlame = 189
    Public Const constReadyforFlame = 190
    Public Const constFlameErrorFlameOff = 191
    Public Const constFlameErrorFuelOff = 192
    Public Const constFlameErrorAirOff = 193
    Public Const constFlameErrorN2OOff = 194
    Public Const constRemoveBurner = 195
    Public Const constRemoveCuvette = 196
    Public Const constNoLampMeasurement = 197
    Public Const constErrorLampPosition = 198
    Public Const constLampNotOptimised = 199
    Public Const constD2Peak = 200
    Public Const constLampOptimisation = 201
    Public Const constEmissionPeak = 202
    Public Const constExitEnergyScan = 203
    Public Const constExitBaseLine = 204
    Public Const constTurretPositionError = 205
    Public Const constExitSlitHome = 206
    Public Const constErrorGettingBurnerHeight = 207
    Public Const constErrorRecivedBlockBurner = 208
    Public Const constErrorTransmitBlockBurner = 209
    Public Const constErrorSettingBurnerHeight = 210
    Public Const constNABurnerNotConnected = 211
    Public Const constFillWaterInTrap = 212
    Public Const constDoorNotClosed = 213
    Public Const constAirPressureLow = 214
    Public Const constFuelPressureLow = 215
    Public Const constErrorAutoIgnition = 216
    Public Const constYellowFlameNotObtainable = 217
    Public Const constBlueFlameNotObtainable = 218
    Public Const constLoadLastOptimisedFuelConditions = 219
    Public Const constLoadLastOptimisedBurnerConditions = 220
    Public Const constErrorSettingMaxFuel = 221
    Public Const constNAFlameSet = 222
    Public Const constLoadLastOptimisedFuelNBurnerConditions = 223
    Public Const constSettingLastConditions = 224
    Public Const constBlueFlameSet = 225
    Public Const constAABurnerNotConnected = 226
    Public Const constFillWaterTrap = 227
    Public Const constAADoorNotCLosed = 228
    Public Const constAAAirPressureLow = 229
    Public Const constAAFuelPressureLow = 230
    Public Const constAAAutoIgnitionError = 231
    Public Const constAAYellowFlameNotObtainable = 232
    Public Const constAABlueFlameNotObtainable = 233
    Public Const constAAErrorSettingMaxFuel = 234
    Public Const constErrorGettingAbsOffset = 235
    Public Const constN2OPressureLow = 236
    Public Const constAspirateMaxStd = 237
    Public Const constErrorAbsReceiving = 238
    Public Const constErrorAbsTransmit = 239
    Public Const constErrorInitRefBeam = 240
    Public Const constRemoveUSBHWLock = 241
    Public Const constPlugUSBHWLoack = 242
    Public Const constErrorHWLock = 243
    Public Const constDemoPeriodExpired = 244
    Public Const constSetMaximisePosition = 245
    Public Const constPerformBaseLine = 246
    Public Const constFileNotSaved = 247
    Public Const constAccessDenied = 248
    Public Const constInvalidRange = 249
    Public Const constErrorPeakValley = 250
    Public Const constManualLampOptimisation = 251
    Public Const constPreviousStandards = 252
    Public Const constNewAnalysis = 253
    Public Const constValueMinToMax = 254
    Public Const constLampInUse = 255
    Public Const constLampAlreadyInUse = 256
    Public Const constSelectedRunNoDeletd = 257
    Public Const constSelectedRunNo = 258
    Public Const constLampPositionMismatch = 259
    Public Const constLampNotPresent = 260
    Public Const constNoStds = 261
    Public Const constAnalysisUnderProgress = 262
    Public Const constFlameIgnited = 263
    Public Const constFlameExtinguished = 264
    Public Const constContinueAnalysis = 265
    Public Const constCheckValue = 266
    Public Const constEnterStdConc = 267
    Public Const constFirstZeroStdConc = 268
    Public Const constUVRange = 269
    Public Const constConfigurationError = 270
    Public Const constErrorIni = 271
    Public Const constErrorHardware = 272
    Public Const constExitUV = 273
    'Public Const constErrorSlitHome = 101
    Public Const constErrorEntrySlitHome = 274
    Public Const constErrorExitSlitHome = 275
    'Public Const constSlitWidthError = 30
    Public Const constEntrySlitWidthError = 276
    Public Const constExitSlitWidthError = 277
    'Public Const constExitSlitWidthError = 277
    'Public Const constExitSlitWidthError = 277
    'Public Const constExitSlitWidthError = 277
    Public Const constSetFuelFlow = 278
    Public Const constBurnerHeadMsg = 279



#End Region

#Region " Database Column Name Constants "

    Public Const ConstColumnMethodType = "MethodType"
    Public Const ConstColumnElementID = "ELE_ID"
    Public Const ConstColumnSlit = "SLIT"
    Public Const ConstColumnAtNo = "ATNO"
    Public Const ConstColumnElementName = "NAME"
    Public Const constColumnElementFullName = "ELE_NAME"
    Public Const ConstColumnCurrent = "CURRENT"
    Public Const ConstColumnSlitEms = "SLITEMS"
    Public Const ConstColumnWV = "WV"
    Public Const ConstColumnAADetailsID = "AADetails_ID"
    Public Const ConstColumnUnit = "Unit"
    Public Const ConstColumnUnitID = "UnitID"
    Public Const ConstColumnMeasurementMode = "MeasurementMode"
    Public Const ConstColumnMeasurementModeID = "MeasurementModeID"
    Public Const ConstColumnMethodTypeID = "MethodTypeID"

#End Region

End Module
