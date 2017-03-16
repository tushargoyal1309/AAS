//Option Explicit On 

//Namespace Analysis

//    <Serializable()> Public Class clsAnalysis
//        Implements ICloneable

//#Region " Public Functions "

//        Public Function Clone() As Object Implements System.ICloneable.Clone
//            Return Me
//        End Function

//#End Region

//#Region " Private Variables "

//        Private intTurretNum As Integer
//        Private intElementNum As Integer
//        Private intTypeOfFlame As Integer
//        Private intFlameStatus As Integer
//        Private dblAbsobance As Double
//        Private dblAvgAbsorbance As Double
//        Private dblCorrectedAbsorbance As Double
//        Private lngSampleID As Long
//        Private intRepeatNum As Integer
//        Private dblConcentration As Double
//        Private dblPMTVoltage As Double
//        Private dblD2Current As Double
//        Private dblHCLCurrent As Double
//        Private dblLampCurrent As Double
//        Private dblSlitWidth As Double
//        Private intOperationMode As Integer
//        Private blnAutoZeroYesNo As Boolean
//        Private dblFuelRatio As Double
//        Private dblBurnerHeight As Double
//        Private blnAutoFuelFlowAdjustment As Boolean
//        Private blnAutoBurnerHeightAdjustment As Boolean
//        Private dblFlameRatio As Double
//        Private dblAirPressure As Double
//        Private dblN2OPressure As Double
//        Private dblFuelPressure As Double
//        Private intAirPressureValve As Integer
//        Private intN2OPressureValve As Integer
//        Private intFuelPressureValve As Integer
//        Private intIgnition As Integer
//        Private lngRunNumber As Long
//        Private intLampHolderPosition As Integer
//        Private strElementName As String
//        Private dblRunTime As Double
//        Private dblEnergy As Double
//        Private dblStdConcentration As Double
//        Private dblSampleConcentration As Double
//        Private intDoorStatus As Integer
//        Private intMethodId As Integer
//        Private strMethodName As String
//        Private mobjStdDataCollection As clsStandardDataCollection
//        Private mobjSampleDataCollection As clsSampleDataCollection

//#End Region

//#Region " Public Properties "

//        Public Property MethodId() As Integer
//            Get
//                MethodId = intMethodId
//            End Get
//            Set(ByVal Value As Integer)
//                intMethodId = Value
//            End Set
//        End Property

//        Public Property MethodName() As String
//            Get
//                MethodName = strMethodName
//            End Get
//            Set(ByVal Value As String)
//                strMethodName = Value
//            End Set
//        End Property

//        Public Property TurretNum() As Integer
//            Get
//                TurretNum = intTurretNum
//            End Get
//            Set(ByVal Value As Integer)
//                intTurretNum = Value
//            End Set
//        End Property

//        Public Property ElementNum() As Integer
//            Get
//                ElementNum = intElementNum
//            End Get
//            Set(ByVal Value As Integer)
//                intElementNum = Value
//            End Set
//        End Property

//        Public Property TypeOfFlame() As Integer
//            Get
//                TypeOfFlame = intTypeOfFlame
//            End Get
//            Set(ByVal Value As Integer)
//                intTypeOfFlame = Value
//            End Set
//        End Property

//        Public Property FlameStatus() As Integer
//            Get
//                FlameStatus = intFlameStatus
//            End Get
//            Set(ByVal Value As Integer)
//                intFlameStatus = Value
//            End Set
//        End Property

//        'Public Property Absorbance() As Double
//        '    Get
//        '        Absorbance = dblAbsobance
//        '    End Get
//        '    Set(ByVal Value As Double)
//        '        dblAbsobance = Value
//        '    End Set
//        'End Property

//        'Public Property AvgAbsorbance() As Double
//        '    Get
//        '        AvgAbsorbance = dblAvgAbsorbance
//        '    End Get
//        '    Set(ByVal Value As Double)
//        '        dblAvgAbsorbance = Value
//        '    End Set
//        'End Property

//        'Public Property CorrectedAbsorbance() As Double
//        '    Get
//        '        CorrectedAbsorbance = dblCorrectedAbsorbance
//        '    End Get
//        '    Set(ByVal Value As Double)
//        '        dblCorrectedAbsorbance = Value
//        '    End Set
//        'End Property

//        'Public Property SampleID() As Long
//        '    Get
//        '        SampleID = lngSampleID
//        '    End Get
//        '    Set(ByVal Value As Long)
//        '        lngSampleID = Value
//        '    End Set
//        'End Property

//        'Public Property RepeatNum() As Integer
//        '    Get
//        '        RepeatNum = intRepeatNum
//        '    End Get
//        '    Set(ByVal Value As Integer)
//        '        intRepeatNum = Value
//        '    End Set
//        'End Property

//        'Public Property Concentration() As Double
//        '    Get
//        '        Concentration = dblConcentration
//        '    End Get
//        '    Set(ByVal Value As Double)
//        '        dblConcentration = Value
//        '    End Set
//        'End Property

//        Public Property PMTVoltage() As Double
//            Get
//                PMTVoltage = dblPMTVoltage
//            End Get
//            Set(ByVal Value As Double)
//                dblPMTVoltage = Value
//            End Set
//        End Property

//        Public Property D2Current() As Double
//            Get
//                D2Current = dblD2Current
//            End Get
//            Set(ByVal Value As Double)
//                dblD2Current = Value
//            End Set
//        End Property

//        Public Property HCLCurrent() As Double
//            Get
//                HCLCurrent = dblHCLCurrent
//            End Get
//            Set(ByVal Value As Double)
//                dblHCLCurrent = Value
//            End Set
//        End Property

//        Public Property LampCurrent() As Double
//            Get
//                LampCurrent = dblLampCurrent
//            End Get
//            Set(ByVal Value As Double)
//                dblLampCurrent = Value
//            End Set
//        End Property

//        Public Property SlitWidth() As Double
//            Get
//                SlitWidth = dblSlitWidth
//            End Get
//            Set(ByVal Value As Double)
//                dblSlitWidth = Value
//            End Set
//        End Property

//        Public Property OperationMode() As Integer
//            Get
//                OperationMode = intOperationMode
//            End Get
//            Set(ByVal Value As Integer)
//                intOperationMode = Value
//            End Set
//        End Property

//        Public Property AutoZero() As Boolean
//            Get
//                AutoZero = blnAutoZeroYesNo
//            End Get
//            Set(ByVal Value As Boolean)
//                blnAutoZeroYesNo = Value
//            End Set
//        End Property

//        Public Property FuelRatio() As Double
//            Get
//                FuelRatio = dblFuelRatio
//            End Get
//            Set(ByVal Value As Double)
//                dblFuelRatio = Value
//            End Set
//        End Property

//        Public Property BurnerHeight() As Double
//            Get
//                BurnerHeight = dblBurnerHeight
//            End Get
//            Set(ByVal Value As Double)
//                dblBurnerHeight = Value
//            End Set
//        End Property

//        Public Property AutoFuelFlowAdjustment() As Boolean
//            Get
//                AutoFuelFlowAdjustment = blnAutoFuelFlowAdjustment
//            End Get
//            Set(ByVal Value As Boolean)
//                blnAutoFuelFlowAdjustment = Value
//            End Set
//        End Property

//        Public Property AutoBurnerHeightAdjustment() As Boolean
//            Get
//                AutoBurnerHeightAdjustment = blnAutoBurnerHeightAdjustment
//            End Get
//            Set(ByVal Value As Boolean)
//                blnAutoBurnerHeightAdjustment = Value
//            End Set
//        End Property

//        Public Property FlameRatio() As Double
//            Get
//                FlameRatio = dblFlameRatio
//            End Get
//            Set(ByVal Value As Double)
//                dblFlameRatio = Value
//            End Set
//        End Property

//        Public Property AirPressure() As Double
//            Get
//                AirPressure = dblAirPressure
//            End Get
//            Set(ByVal Value As Double)
//                dblAirPressure = Value
//            End Set
//        End Property

//        Public Property N2OPressure() As Double
//            Get
//                N2OPressure = dblN2OPressure
//            End Get
//            Set(ByVal Value As Double)
//                dblN2OPressure = Value
//            End Set
//        End Property

//        Public Property FuelPressure() As Double
//            Get
//                FuelPressure = dblFuelPressure
//            End Get
//            Set(ByVal Value As Double)
//                dblFuelPressure = Value
//            End Set
//        End Property

//        Public Property AirPressureValve() As Integer
//            Get
//                AirPressureValve = intAirPressureValve
//            End Get
//            Set(ByVal Value As Integer)
//                intAirPressureValve = Value
//            End Set
//        End Property

//        Public Property N2OPressureValve() As Integer
//            Get
//                N2OPressureValve = intN2OPressureValve
//            End Get
//            Set(ByVal Value As Integer)
//                intN2OPressureValve = Value
//            End Set
//        End Property

//        Public Property FuelPressureValve() As Integer
//            Get
//                FuelPressureValve = intFuelPressureValve
//            End Get
//            Set(ByVal Value As Integer)
//                intFuelPressureValve = Value
//            End Set
//        End Property

//        Public Property Ignition() As Integer
//            Get
//                Ignition = intIgnition
//            End Get
//            Set(ByVal Value As Integer)
//                intIgnition = Value
//            End Set
//        End Property

//        Public Property RunNumber() As Long
//            Get
//                RunNumber = lngRunNumber
//            End Get
//            Set(ByVal Value As Long)
//                lngRunNumber = Value
//            End Set
//        End Property

//        Public Property LampHolderPosition() As Integer
//            Get
//                LampHolderPosition = intLampHolderPosition
//            End Get
//            Set(ByVal Value As Integer)
//                intLampHolderPosition = Value
//            End Set
//        End Property

//        Public Property ElementName() As String
//            Get
//                ElementName = strElementName
//            End Get
//            Set(ByVal Value As String)
//                strElementName = Value
//            End Set
//        End Property

//        Public Property RunTime() As Double
//            Get
//                RunTime = dblRunTime
//            End Get
//            Set(ByVal Value As Double)
//                dblRunTime = Value
//            End Set
//        End Property

//        Public Property Energy() As Double
//            Get
//                Energy = dblEnergy
//            End Get
//            Set(ByVal Value As Double)
//                dblEnergy = Value
//            End Set
//        End Property

//        'Public Property StdConcentration() As Double
//        '    Get
//        '        StdConcentration = dblStdConcentration
//        '    End Get
//        '    Set(ByVal Value As Double)
//        '        dblStdConcentration = Value
//        '    End Set
//        'End Property

//        'Public Property SampleConcentration() As Double
//        '    Get
//        '        SampleConcentration = dblSampleConcentration
//        '    End Get
//        '    Set(ByVal Value As Double)
//        '        dblSampleConcentration = Value
//        '    End Set
//        'End Property

//        Public Property DoorStatus() As Integer
//            Get
//                DoorStatus = intDoorStatus
//            End Get
//            Set(ByVal Value As Integer)
//                intDoorStatus = Value
//            End Set
//        End Property

//        Public Property StandardDataCollection() As clsStandardDataCollection
//            Get
//                StandardDataCollection = mobjStdDataCollection
//            End Get
//            Set(ByVal Value As clsStandardDataCollection)
//                StandardDataCollection = New clsStandardDataCollection
//                StandardDataCollection = Value
//            End Set
//        End Property

//        Public Property SampleDataCollection() As clsSampleDataCollection
//            Get
//                SampleDataCollection = mobjSampleDataCollection
//            End Get
//            Set(ByVal Value As clsSampleDataCollection)
//                SampleDataCollection = New clsSampleDataCollection
//                SampleDataCollection = Value
//            End Set
//        End Property

//#End Region

//    End Class

//End Namespace
