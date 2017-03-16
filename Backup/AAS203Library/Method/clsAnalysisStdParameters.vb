Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsAnalysisStdParameters
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            mintPositionNumber = -1 ' 0 to -1 'by Pankaj for autosampler on 10Sep 07 
            mintStdNumber = 0
            mstrStdName = ""
            mdblConcentration = 0.0
            mdblAbs = 0.0
            mdblnStd = 0.0
            mblnUsed = False
            AbsRepeat = New clsAbsRepeat
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsAnalysisStdParameters)
            mintPositionNumber = rhs.PositionNumber
            mintStdNumber = rhs.StdNumber
            mstrStdName = rhs.StdName
            mdblConcentration = rhs.Concentration
            mdblAbs = rhs.Abs
            mdblnStd = rhs.nStd
            mblnUsed = rhs.Used
            AbsRepeat = rhs.AbsRepeat.Clone()
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAnalysisStdParameters
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsAnalysisStdParameters(Me)
        End Function

#End Region

#Region " Private Variables "

        Private mintPositionNumber As Integer
        Private mintStdNumber As Integer
        Private mstrStdName As String
        Private mdblConcentration As Double
        Private mdblAbs As Double
        Private mdblnStd As Double
        Private mblnUsed As Boolean

        Public AbsRepeat As clsAbsRepeat

#End Region

#Region " Public Properties "

        Public Property StdNumber() As Integer
            Get
                Return mintStdNumber
            End Get
            Set(ByVal Value As Integer)
                mintStdNumber = Value
            End Set
        End Property

        Public Property PositionNumber() As Integer
            Get
                Return mintPositionNumber
            End Get
            Set(ByVal Value As Integer)
                mintPositionNumber = Value
            End Set
        End Property

        Public Property StdName() As String
            Get
                Return mstrStdName
            End Get
            Set(ByVal Value As String)
                mstrStdName = Value
            End Set
        End Property

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

        Public Property nStd() As Double
            Get
                Return mdblnStd
            End Get
            Set(ByVal Value As Double)
                mdblnStd = Value
            End Set
        End Property

        Public Property Used() As Boolean
            Get
                Return mblnUsed
            End Get
            Set(ByVal Value As Boolean)
                mblnUsed = Value
            End Set
        End Property

#End Region

    End Class

End Namespace
