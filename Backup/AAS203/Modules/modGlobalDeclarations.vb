Imports AAS203Library.Method
Imports AAS203Library.Instrument
Imports IQOQPQ.IQOQPQ.IQOQPQ
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports AAS203.FuelConditions


Module modGlobalDeclarations

    Public gobjFuelDataCollection As New clsFuelDataCollection '29.04.10

    Public gblnBurnerMsg As Boolean '---30.03.09
    'Public gblnMessageDisplayed As Boolean '---30.03.09   'commented on 26.04.09 for ver 4.87

    Public gintAspirationType As Integer = 0
    Public gintCalcMode As Integer = 100 '29.04.08 
    Public gblnIsDemoWithRealData As Boolean = False       '16.03.08

    Public gblnIsPeakSearchStarted As Boolean = False  '28.09.07
    Public gblnSetSpeedIssue As Boolean = True '28.09.07

    Public gobjErrorHandler As ErrorHandler.ErrorHandler
    Public gobjclsTimer As clsTimer
    Public gobjMain As frmMDIMain
    Public gobjMainService As frmMDIMainService
    Public gobjService As frmServiceRoutines        'Saurabh

    Public gintCommPortSelected As Integer '--global variable for com port selected
    Public gintCommPortSelectedForAutoSampler As Integer
    Public gblnIsAutoSamplerEnabled As Boolean
    Public gblnTestAutoSampler As Boolean = True
    Public gintCommPort() As Integer
    Public gstrCustomer As String

    Public gstrTitleInstrumentType As String = "AA 203"     '-- global variable for instrument Name
    Public gblnInitialization As Boolean = False '-- global variable for initialisation of instrument is done or not

    Public gobjCommProtocol As clsCommProtocolFunctions
    'Public gobjCommProtocol As clsProtocol

    Public gobjMethodCollection As New clsMethodCollection
    Public gobjNewMethod As clsMethod
    Public gIntMethodID As Integer
    Public gobjDataAccess As clsDataAccessLayer

    Public gobjMessageAdapter As New clsMessageAdapter
    Public gobjClsAAS203 As New ClsAAS203
    Public gobjReportOptions As New clsMethod
    Public gobjclsStandardGraph As New clsStandardGraph

    Public gobjInst As ClsInstrument

    Public HydrideMode As Boolean = False

    Public gblnInComm As Boolean = False

    Public gintTurretToOptimizeForServiceUtility As Integer = 0

    '-----------------------
    'Public gdblPmtv As Double
    'Public gdblCurWv As Double
    'Public gdblWvzero As Double
    'Public gintlamp_opt_pos As Integer
    '-------------------------
    Public gblnCookBookReport As Boolean = False
    Public gblnDemoMode As Boolean = True
    Public gobjHardwareLock As New clsHardwareLock
    Public gobjHardwareLock_USB As New clsHardwareLock_USB
    Public gobjHardwareLock_LPT As New clsHardwareLock_LPT

    Public gstructSettings As New IniSettings
    '//----- added by Sachin Dokhale
    '//----- Used for Thread control
    Public gblnSpectrumTerminated As Boolean = False
    Public gblnSpectrumWait As Boolean = False
    Public gblnSmoothFilter As Boolean = True
    Public gblnCheckMinAbsScanLmt As Boolean = False

    '//'----- Report Page Setting
    Public gobjPageSetting As New System.Drawing.Printing.PageSettings
    '//-----
    Public gblnBaseLine As Boolean = False
    Public gobjfrmStatus As frmStatus
    Public gintSpectrumMode As EnumSpectrumMode = 0
    Public gintOptimisation As EnumBH_FP_Opimisation = EnumBH_FP_Opimisation.BurnerHeight


    Public gblnUVS As Boolean = False
    Public gblnUVABS As Boolean = True
    Public gintSample_adc() As Integer
    Public gintSample_adc_RefBeam() As Integer

    Public gintTimeConstant As Integer = 2

    Public gobjIQOQPQ As IQOQPQ.IQOQPQ.IQOQPQ

    Public gintNV_POS As Integer
    Public gRandom As New System.Random
    Public OPERATION_MODE As Int16            '--- Photometry , spectrum , time scan , kinetic etc

    Public gobjclsBgFlameStatus As clsBgFlameStatus
    Public gobjchkActiveMethod As methodActiveSettings
    Public gintSelectedLampParameter As Integer 'Added for Lamp parameter screen
    Public gintInstrumentBeamType As enumInstrumentBeamType = enumInstrumentBeamType.SingleBeam
    Public gintServiceBeamType As enumInstrumentBeamType = enumInstrumentBeamType.DoubleBeam  'by pankaj on 18.1.08  for service beam type
    Public gblnIsInstReset As Boolean = False
    Public gblnSTD_ADDN As Boolean = True
    '//-----

    Public gDblAbsValue_IQOQPQ_Attachment1 As Double = 0       'Saurabh 05.07.07
    Public IsInIQOQPQ As Boolean = False        'Saurabh 22.07.07
    Public gintTimeDelay As Integer = 25 '200

    Public gblnIsInstrumentConditionsActive As Boolean = True

    Public M_WvStartRange As Double
    Public M_WvLastRange As Double

    Public ReInitLampInstParameters As Boolean = False
    Public gblnIgnite_Test_Exit As Boolean = False
    '//--- Added Sachin Dokhale for AA201  and AA203 Lamp count on 22.05.08
    Public ConstInstFileName As String = "Inst.bin"
    '//--- 
    Public Structure IniSettings

        '---Setting for Hardware key
        Public HardwareKey As String

        '---Setting for communication port
        'Public CommPort As Integer

        '---Setting for Hardware lock
        Public HardwareLock As Integer
        Public HardwareLockType As EnumHardwareLockType
        Public DemoDays As Integer

        '--- Setting for SessionID  
        Dim SessionID As Long

        '---Whether Apllication is in Demo Mode or full mode
        Public AppMode As Integer

        Public D2Gain As Boolean
        Public BHStep As Integer
        Public D2Pmt As Integer
        Public Mesh As Boolean

        Public SetMinAbsLimit As Boolean
        Public AbsThresholdValue As Double
        Public TimeConstant As Double

        '---Added by Mangesh 
        Public Filter_Window_Size As Integer
        Public BlankCalculation As Boolean
        Public CFR21Installation As Boolean
        Public Enable21CFR As Boolean
        Public EnableServiceUtility As Boolean

        Public blnSelectColorPrinter As Boolean

        Public HydrideMode As Integer

        Public ExeToRun As Integer      'Saurabh
        Public IsCustomerDisplayMode As Boolean
        Public WavelengthRange As WavelengthRange
        Public EnableIQOQPQ As Boolean
        Public NewModelName As Boolean '4.85 14.04.09
    End Structure
    'Added By Pankaj  23 May 07 for chaking method inactive to active mode
    Public Structure methodActiveSettings
        'Public fillInstruments As Boolean
        Public fillParameters As Boolean
        Public fillStdConcentration As Boolean
        Public NewMethod As Boolean
        Public CancelMethod As Boolean
        Public IsMethodAddedToCollectionInDisconnectedMode As Boolean
    End Structure

    Public Structure WavelengthRange
        Public WvLowerBound As Double
        Public WvUpperBound As Double
    End Structure

    '//----- To added in method
    Public Structure _addSpect
        Dim dblWvMin As Double
        Dim dblWvMax As Double
        Dim dblYmin As Double
        Dim dblYMax As Double
        Dim intMode As Integer
        Dim intSpeed As Integer
        Dim intCounter As Integer
        Dim blnPloted As Boolean

    End Structure

    Public Structure AbsConc
        Public ABS As Double
        Public CONC As Double

        Public Sub New(ByVal dblABS As Double, ByVal dblConc As Double)
            ABS = dblABS
            CONC = dblConc
        End Sub

    End Structure

    Public addataSpect As _addSpect

    Public adData() As Double

    '//-----
    '--- Enum for the toolbar indexes
    'Private Enum EnumToolBarButtons
    '    Parameter = 0
    '    LoadSpectrumFile = 2
    '    SaveSpectrumFile = 3
    '    StartScan = 5
    '    StopScan = 6
    '    Clear = 8
    '    ClearAndRedraw = 9
    '    Print = 10
    '    Baseline = 12
    '    Autozero = 13
    '    ReturnToSelectModes = 15
    'End Enum

    'Private Enum EnumToolBarImages
    '    ParameterEnabled = 0
    '    StartScanEnabled = 1
    '    StopScanEnabled = 2
    '    ClearEnabled = 3
    '    ClearAndRedrawEnabled = 4
    '    PrintEnabled = 5
    '    BaselineEnabled = 6
    '    AutozeroEnabled = 7
    '    ReturnToSelectModesEnabled = 8
    '    ParameterDisabled = 9
    '    StartScanDisabled = 10
    '    StopScanDisabled = 11
    '    ClearDisabled = 12
    '    ClearAndRedrawDisabled = 13
    '    PrintDisabled = 14
    '    BaselineDisabled = 15
    '    AutozeroDisabled = 16
    '    ReturnToSelectModesDisabled = 17
    '    LoadSpectrumFileEnabled = 18
    '    SaveSpectrumFileEnabled = 19
    '    LoadSpectrumFileDisabled = 20
    '    SaveSpectrumFileDisabled = 21
    'End Enum

    Public Enum EnumProcesses
        FormInitialize = 1 '--- During Form Load

        LoadParameters = 2 '--- During Manual Loading of Paramters from a File  
        EditParameters = 3 '--- During Click of parameters on the Tool bar i.e Editing Of paramters 
        SaveParameters = 4 '--- During the Saving of parmaters after editing wants to save
        EditSystemParamters = 5 '--- Edit the Change over Wavelength Parameters


        LoadFile = 6
        SaveFile = 7 '--- During Analysis Click by the User
        LoadChannel = 8 '--- When next scan is clicked

        ChannelToConstant = 9
        ChannelToChannel = 10 '--- When repeat has been clicked
        AbsToTransmission = 11 '--- When New Analysis has been Clicked
        EnergyToAbs = 12 '--- When End of Analysis is Clicked

        Smooth = 13 '--- When Autozero is Clicked
        PeakPick = 14

        StartScan = 15
        StopsScan = 16
        ClearAndRedraw = 17
        Baseline = 18
        Autozero = 19
        Clear = 20

        ChannelUp_Down = 21

    End Enum

    Public Enum EnumStart_End
        Start_of_Process = 1  '--- This is when the Process Starts
        End_of_Process = 2    '--- This is when the Process Ends
        Process_Running = 3
        Process_Waiting = 4
    End Enum

    Public Enum EnumDeserializeObjType
        Parameter = 1
        UVSpectrum = 2
        EnergySpectrum = 3
        UVSpectrumDB = 4
        EnergySpectrumDB = 5

    End Enum

    Public Enum EnumSpectrumMode As Integer
        EnergySpectrum = 0
        UVSpetrum = 1
        TimeScan = 2
    End Enum

    Public Enum EnumBH_FP_Opimisation As Integer
        BurnerHeight = 0
        FuelPresure = 1
    End Enum


    '========Saurabh=============
    Public gSetD2StartTime As Date = Date.Now
    Public gSetWStartTime As Date = Date.Now
    Public gSetInstrumentStartTime As Date = Date.Now
    Public INI_SETTINGS_PATH As String ' --- Path for the Settings.ini
    '============================
    Public Enum enumSelectBeamType As Integer
        Sample
        Reference
    End Enum
End Module

