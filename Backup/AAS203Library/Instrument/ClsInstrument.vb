Namespace Instrument

    <Serializable()> Public Class ClsInstrument
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            dblWavelengthCur = 0.0
            dblCurrent = 0.0
            dblPmtVoltage = 0.0
            intD2Pmt = 0
            intAverage = 0
            dblEntrySlitPosition = 0.0
            intLamp_Old = 0
            intLamp_Position = 0
            intLamp_Warm = 0
            intMode = 0
            intD2Current = 0
            strElementName = ""
            intTurretPosition = 0
            intNvStep = 0
            intBhStep = 0
            blnAaf = False
            blnN2of = False
            blnNa = False
            blnHydride = False
            mintInstrumentBeamType = enumInstrumentBeamType.SingleBeam
            dblReferencePmtVoltage = 0.0
            dblExitSlitPosition = 0.0

            Lamp = New ClsLamp
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As ClsInstrument)
            dblWavelengthCur = rhs.WavelengthCur
            dblCurrent = rhs.Current
            dblPmtVoltage = rhs.PmtVoltage
            intD2Pmt = rhs.D2Pmt
            intAverage = rhs.Average
            dblEntrySlitPosition = rhs.SlitPosition
            intLamp_Old = rhs.Lamp_Old
            intLamp_Position = rhs.Lamp_Position
            intLamp_Warm = rhs.Lamp_Warm
            intMode = rhs.Mode
            intD2Current = rhs.D2Current
            strElementName = rhs.ElementName
            intTurretPosition = rhs.TurretPosition
            intNvStep = rhs.NvStep
            intBhStep = rhs.BhStep
            blnAaf = rhs.Aaf
            blnN2of = rhs.N2of
            blnNa = rhs.Na
            blnHydride = rhs.Hydride
            mintInstrumentBeamType = rhs.InstrumentBeamType
            dblReferencePmtVoltage = rhs.PmtVoltageReference
            dblExitSlitPosition = rhs.SlitPositionExit

            Lamp = rhs.Lamp.Clone()
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the ClsInstrument
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New ClsInstrument(Me)
        End Function

#End Region

#Region " Public Variables "

        Public Lamp As ClsLamp

#End Region

#Region " Private Variables "

        Private dblWavelengthCur As Double
        Private dblCurrent As Double
        Private dblPmtVoltage As Double
        Private intD2Pmt As Integer
        Private intAverage As Integer
        Private dblEntrySlitPosition As Double
        Private intLamp_Old As Integer
        Private intLamp_Position As Integer
        Private intLamp_Warm As Integer
        Private intMode As Integer
        Private intD2Current As Integer
        Private strElementName As String
        Private intTurretPosition As Integer
        Private intNvStep As Integer
        Private intBhStep As Integer
        Private blnAaf As Boolean
        Private blnN2of As Boolean
        Private blnNa As Boolean
        Private blnHydride As Boolean
        Private mintInstrumentBeamType As AAS203Library.Instrument.enumInstrumentBeamType
        Private dblReferencePmtVoltage As Double
        Private dblExitSlitPosition As Double

#End Region

#Region " Public Properties "

        Public Property WavelengthCur() As Double
            Get
                Return dblWavelengthCur
            End Get
            Set(ByVal Value As Double)
                dblWavelengthCur = Value
            End Set
        End Property

        Public Property Current() As Double
            Get
                Return dblCurrent
            End Get
            Set(ByVal Value As Double)
                dblCurrent = Value
            End Set
        End Property

        Public Property PmtVoltage() As Double
            Get
                Return dblPmtVoltage
            End Get
            Set(ByVal Value As Double)
                dblPmtVoltage = Value
            End Set
        End Property

        Public Property D2Pmt() As Integer
            Get
                Return intD2Pmt
            End Get
            Set(ByVal Value As Integer)
                intD2Pmt = Value
            End Set
        End Property

        Public Property Average() As Integer
            Get
                Return intAverage
            End Get
            Set(ByVal Value As Integer)
                intAverage = Value
            End Set
        End Property

        '---Return type Changed By Mangesh 
        Public Property SlitPosition() As Double
            Get
                Return dblEntrySlitPosition
            End Get
            Set(ByVal Value As Double)
                dblEntrySlitPosition = Value
            End Set
        End Property

        Public Property Lamp_Old() As Integer
            Get
                Return intLamp_Old
            End Get
            Set(ByVal Value As Integer)
                intLamp_Old = Value
            End Set
        End Property

        Public Property Lamp_Position() As Integer
            Get
                Return intLamp_Position
            End Get
            Set(ByVal Value As Integer)
                intLamp_Position = Value
            End Set
        End Property

        Public Property Lamp_Warm() As Integer
            Get
                Return intLamp_Warm
            End Get
            Set(ByVal Value As Integer)
                intLamp_Warm = Value
            End Set
        End Property

        Public Property Mode() As Integer
            Get
                Return intMode
            End Get
            Set(ByVal Value As Integer)
                intMode = Value
            End Set
        End Property

        Public Property D2Current() As Integer
            Get
                Return intD2Current
            End Get
            Set(ByVal Value As Integer)
                intD2Current = Value
            End Set
        End Property

        Public Property ElementName() As String
            Get
                Return strElementName
            End Get
            Set(ByVal Value As String)
                strElementName = Value
            End Set
        End Property

        Public Property TurretPosition() As Integer
            Get
                Return intTurretPosition
            End Get
            Set(ByVal Value As Integer)
                intTurretPosition = Value
            End Set
        End Property

        Public Property NvStep() As Integer
            Get
                Return intNvStep
            End Get
            Set(ByVal Value As Integer)
                intNvStep = Value
            End Set
        End Property

        Public Property BhStep() As Integer
            Get
                Return intBhStep
            End Get
            Set(ByVal Value As Integer)
                intBhStep = Value
            End Set
        End Property

        Public Property Aaf() As Boolean
            Get
                Return blnAaf
            End Get
            Set(ByVal Value As Boolean)
                blnAaf = Value
            End Set
        End Property

        Public Property N2of() As Boolean
            Get
                Return blnN2of
            End Get
            Set(ByVal Value As Boolean)
                blnN2of = Value
            End Set
        End Property

        Public Property Na() As Boolean
            Get
                Return blnNa
            End Get
            Set(ByVal Value As Boolean)
                blnNa = Value
            End Set
        End Property

        Public Property Hydride() As Boolean
            Get
                Return blnHydride
            End Get
            Set(ByVal Value As Boolean)
                blnHydride = Value
            End Set
        End Property

        Public Property InstrumentBeamType() As AAS203Library.Instrument.enumInstrumentBeamType
            Get
                Return mintInstrumentBeamType
            End Get
            Set(ByVal Value As AAS203Library.Instrument.enumInstrumentBeamType)
                mintInstrumentBeamType = Value
            End Set
        End Property

        Public Property PmtVoltageReference() As Double
            Get
                Return dblReferencePmtVoltage
            End Get
            Set(ByVal Value As Double)
                dblReferencePmtVoltage = Value
            End Set
        End Property

        Public Property SlitPositionExit() As Double
            Get
                Return dblExitSlitPosition
            End Get
            Set(ByVal Value As Double)
                dblExitSlitPosition = Value
            End Set
        End Property

#End Region

    End Class

    Public Enum enumInstrumentBeamType
        SingleBeam
        ReferenceBeam
        DoubleBeam
    End Enum

End Namespace



