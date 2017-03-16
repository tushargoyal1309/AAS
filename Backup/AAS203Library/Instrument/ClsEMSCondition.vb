Namespace Instrument
    <Serializable()> Public Class ClsEMSCondition
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            strElementName = ""
            intAtomicNumber = 0
            dblWavelength = 0.0
            dblSlitWidth = 0.0
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As ClsEMSCondition)
            strElementName = rhs.ElementName
            intAtomicNumber = rhs.AtomicNumber
            dblWavelength = rhs.Wavelength
            dblSlitWidth = rhs.SlitWidth
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the ClsEMSCondition
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New ClsEMSCondition(Me)
        End Function

#End Region

#Region " Private Variables "

        Private strElementName As String
        Private intAtomicNumber As Integer
        Private dblWavelength As Double
        Private dblSlitWidth As Double

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

        Public Property AtomicNumber() As Integer
            Get
                Return intAtomicNumber
            End Get
            Set(ByVal Value As Integer)
                intAtomicNumber = Value
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

#End Region

    End Class
End Namespace

