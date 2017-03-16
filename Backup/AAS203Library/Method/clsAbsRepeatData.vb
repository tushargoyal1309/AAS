Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsAbsRepeatData
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            mdblConcentration = 0.0
            mdblAbs = 0.0
            mdblUsed = False
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsAbsRepeatData)
            mdblConcentration = rhs.Concentration
            mdblAbs = rhs.Abs
            mdblUsed = rhs.Used
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAbsRepeatData
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsAbsRepeatData(Me)
        End Function

#End Region

#Region " Private Variables "

        Private mdblConcentration As Double
        Private mdblAbs As Double
        Private mdblUsed As Boolean

#End Region

#Region " Public Properties "

        Public Property Concentration() As Double
            Get
                Return mdblConcentration
            End Get
            Set(ByVal Value As Double)
                mdblConcentration = Value
            End Set
        End Property

        Public Property Abs() As Double
            Get
                Return mdblAbs
            End Get
            Set(ByVal Value As Double)
                mdblAbs = Value
            End Set
        End Property

        Public Property Used() As Boolean
            Get
                Return mdblUsed
            End Get
            Set(ByVal Value As Boolean)
                mdblUsed = Value
            End Set
        End Property

#End Region

    End Class

End Namespace

