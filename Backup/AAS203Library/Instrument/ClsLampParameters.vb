Namespace Instrument

    <Serializable()> Public Class ClsLampParameters
        Implements ICloneable

#Region " Private Variables "

        Private strElementName As String
        Private blnMel As Boolean
        Private intAtomicNumber As Integer
        Private dblCurrent As Double
        Private dblWavelength As Double
        Private dblSlitWidth As Double
        Private intMode As Integer
        Private blnBurner As Boolean
        Private intLampOptimizePosition As Integer

#End Region

#Region " Public Properties "

        Public Property ElementName() As String
            Get
                Return strElementName
            End Get
            Set(ByVal Value As String)
                strElementName = Value
            End Set
        End Property

        Public Property Mel() As Boolean
            Get
                Return blnMel
            End Get
            Set(ByVal Value As Boolean)
                blnMel = Value
            End Set
        End Property

        Public Property AtomicNumber() As Integer
            Get
                Return intAtomicNumber
            End Get
            Set(ByVal Value As Integer)
                intAtomicNumber = Value
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

        Public Property Wavelength() As Double
            Get
                Return dblWavelength
            End Get
            Set(ByVal Value As Double)
                dblWavelength = Value
            End Set
        End Property

        Public Property SlitWidth() As Double
            Get
                Return dblSlitWidth
            End Get
            Set(ByVal Value As Double)
                dblSlitWidth = Value
            End Set
        End Property

        Public Property Mode() As Double
            Get
                Return intMode
            End Get
            Set(ByVal Value As Double)
                intMode = Value
            End Set
        End Property

        Public Property Burner() As Boolean
            Get
                Return blnBurner
            End Get
            Set(ByVal Value As Boolean)
                blnBurner = Value
            End Set
        End Property

        Public Property LampOptimizePosition() As Integer
            Get
                Return intLampOptimizePosition
            End Get
            Set(ByVal Value As Integer)
                intLampOptimizePosition = Value
            End Set
        End Property

#End Region

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            strElementName = ""
            blnMel = False
            intAtomicNumber = 0
            dblCurrent = 0.0
            dblWavelength = 0.0
            dblSlitWidth = 0.0
            intMode = 0
            blnBurner = False
            intLampOptimizePosition = 0
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As ClsLampParameters)
            strElementName = rhs.ElementName
            blnMel = rhs.Mel
            intAtomicNumber = rhs.AtomicNumber
            dblCurrent = rhs.Current
            dblWavelength = rhs.Wavelength
            dblSlitWidth = rhs.SlitWidth
            intMode = rhs.Mode
            blnBurner = rhs.Burner
            intLampOptimizePosition = rhs.LampOptimizePosition
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the ClsLampParameters
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New ClsLampParameters(Me)
        End Function

#End Region

    End Class
End Namespace

