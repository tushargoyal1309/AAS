Namespace FuelConditions
    <Serializable()> Public Class clsFuelData
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()

        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsFuelData)

        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAbsRepeat
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsFuelData(Me)
        End Function

#End Region

#Region "Private Variables"
        Private mstrElementName As String
        Private mintAtomicNumber As Integer
        Private mdblBurnerHeight As Double
        Private mdblNVStep As Double
        Private mblnIsAAFlame As Boolean
#End Region

#Region "Public Properties"
        Public Property ElementName() As String
            Get
                Return mstrElementName
            End Get
            Set(ByVal Value As String)
                mstrElementName = Value
            End Set
        End Property

        Public Property AtomicNumber() As Integer
            Get
                Return mintAtomicNumber
            End Get
            Set(ByVal Value As Integer)
                mintAtomicNumber = Value
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

        Public Property NVStep() As Double
            Get
                Return mdblNVStep
            End Get
            Set(ByVal Value As Double)
                mdblNVStep = Value
            End Set
        End Property

        Public Property IsAAFlame() As Boolean
            Get
                Return mblnIsAAFlame
            End Get
            Set(ByVal Value As Boolean)
                mblnIsAAFlame = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
