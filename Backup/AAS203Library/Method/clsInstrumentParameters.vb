Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsInstrumentParameters
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            mstrElementName = ""
            mintElementID = 0
            mintTurretNumber = 0
            mintLampNumber = 0
            mdblLampCurrent = 0.0
            mobjDtWavelength = New DataTable
            mdblSlitWidth = 0.0
            mdblPmtVoltage = 0.0
            mdblBurnerHeight = 0.0
            mdblFuelRatio = 0.0
            mblnIsOptimize = False
            mintSelectedWavelengthID = 0
            mintD2Current = 0
            mintInstMode = 0
            mdblnInst = 0.0
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsInstrumentParameters)
            mstrElementName = rhs.ElementName
            mintElementID = rhs.ElementID
            mintTurretNumber = rhs.TurretNumber
            mintLampNumber = rhs.LampNumber
            mdblLampCurrent = rhs.LampCurrent
            mobjDtWavelength = rhs.Wavelength.Copy()
            mdblSlitWidth = rhs.SlitWidth
            mdblPmtVoltage = rhs.PmtVoltage
            mdblBurnerHeight = rhs.BurnerHeight
            mdblFuelRatio = rhs.FuelRatio
            mblnIsOptimize = rhs.IsOptimize
            mintSelectedWavelengthID = rhs.SelectedWavelengthID
            mintD2Current = rhs.D2Current
            mintInstMode = rhs.Inst_Mode
            mdblnInst = rhs.nInst
            EmWavelength = rhs.EmmWavelength
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsInstrumentParameters
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsInstrumentParameters(Me)
        End Function

#End Region

#Region " Private Variables "

        Private mstrElementName As String
        Private mintElementID As Integer
        Private mintTurretNumber As Integer
        Private mintLampNumber As Integer
        Private mdblLampCurrent As Double
        Private mobjDtWavelength As DataTable
        Private mdblSlitWidth As Double
        Private mdblExitSlitWidth As Double
        Private mdblPmtVoltage As Double
        Private mdblRefPmtVoltage As Double
        Private mdblBurnerHeight As Double
        Private mdblFuelRatio As Double
        Private mblnIsOptimize As Boolean
        Private mintSelectedWavelengthID As Integer
        Private mintD2Current As Integer
        Private mintInstMode As Integer
        Private mdblnInst As Double
        Private EmWavelength As Double

#End Region

#Region " Public Properties "

        Public Property ElementName() As String
            Get
                ElementName = mstrElementName
            End Get
            Set(ByVal Value As String)
                mstrElementName = Value
            End Set
        End Property

        Public Property ElementID() As Integer
            Get
                ElementID = mintElementID
            End Get
            Set(ByVal Value As Integer)
                mintElementID = Value
            End Set
        End Property

        Public Property TurretNumber() As Integer
            Get
                TurretNumber = mintTurretNumber
            End Get
            Set(ByVal Value As Integer)
                mintTurretNumber = Value
            End Set
        End Property

        Public Property LampNumber() As Integer
            Get
                Return mintLampNumber
            End Get
            Set(ByVal Value As Integer)
                mintLampNumber = Value
            End Set
        End Property

        Public Property LampCurrent() As Double
            Get
                LampCurrent = mdblLampCurrent
            End Get
            Set(ByVal Value As Double)
                mdblLampCurrent = Value
            End Set
        End Property

        Public Property SelectedWavelengthID() As Integer
            Get
                Return mintSelectedWavelengthID
            End Get
            Set(ByVal Value As Integer)
                mintSelectedWavelengthID = Value
            End Set
        End Property

        Public Property Wavelength() As DataTable
            Get
                Wavelength = mobjDtWavelength
            End Get
            Set(ByVal Value As DataTable)
                mobjDtWavelength = Value
            End Set
        End Property

        Public Property SlitWidth() As Double
            Get
                SlitWidth = mdblSlitWidth
            End Get
            Set(ByVal Value As Double)
                mdblSlitWidth = Value
            End Set
        End Property

        Public Property D2Current() As Integer
            Get
                Return mintD2Current
            End Get
            Set(ByVal Value As Integer)
                mintD2Current = Value
            End Set
        End Property

        Public Property PmtVoltage() As Double
            Get
                Return mdblPmtVoltage
            End Get
            Set(ByVal Value As Double)
                mdblPmtVoltage = Value
            End Set
        End Property

        Public Property BurnerHeight() As Double
            Get
                Return mdblBurnerHeight
            End Get
            Set(ByVal Value As Double)
                mdblBurnerHeight = Value
            End Set
        End Property

        Public Property FuelRatio() As Double
            Get
                Return mdblFuelRatio
            End Get
            Set(ByVal Value As Double)
                mdblFuelRatio = Value
            End Set
        End Property

        Public Property IsOptimize() As Boolean
            Get
                Return mblnIsOptimize
            End Get
            Set(ByVal Value As Boolean)
                mblnIsOptimize = Value
            End Set
        End Property

        Public Property Inst_Mode() As Integer
            Get
                Return mintInstMode
            End Get
            Set(ByVal Value As Integer)
                mintInstMode = Value
            End Set
        End Property

        Public Property nInst() As Double
            Get
                Return mdblnInst
            End Get
            Set(ByVal Value As Double)
                mdblnInst = Value
            End Set
        End Property

        Public Property RefPmtVoltage() As Double
            Get
                Return mdblRefPmtVoltage
            End Get
            Set(ByVal Value As Double)
                mdblRefPmtVoltage = Value
            End Set
        End Property

        Public Property EmmWavelength() As Double
            Get
                EmmWavelength = EmWavelength
            End Get
            Set(ByVal Value As Double)
                EmWavelength = Value
            End Set
        End Property
        Public Property ExitSlitWidth() As Double
            Get
                Return mdblExitSlitWidth
            End Get
            Set(ByVal Value As Double)
                mdblExitSlitWidth = Value
            End Set
        End Property

#End Region

    End Class

End Namespace