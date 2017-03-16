Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsAnalysisSampleParameters
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            mintSampNumber = 0
            mintSampPosNumber = -1 '0 to -1 by Pankaj for autosampler on 10Sep 07
            mdblnSamp = 0.0
            mstrSampleName = ""
            mdblWeight = 0.0
            mdblVolume = 0.0
            mdblDilutionFactor = 0.0
            mdblAbs = 0.0
            mdblConc = 0.0
            mblnUsed = False
            AbsRepeat = New clsAbsRepeat
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsAnalysisSampleParameters)
            mintSampNumber = rhs.SampNumber
            mintSampPosNumber = rhs.SampPosNumber
            mdblnSamp = rhs.nSamp
            mstrSampleName = rhs.SampleName
            mdblWeight = rhs.Weight
            mdblVolume = rhs.Volume
            mdblDilutionFactor = rhs.DilutionFactor
            mdblAbs = rhs.Abs
            mdblConc = rhs.Conc
            mblnUsed = rhs.Used
            ''AbsRepeat = rhs.AbsRepeat commented on 10.03.09
            AbsRepeat = rhs.AbsRepeat.Clone '10.03.09
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAnalysisSampleParameters
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsAnalysisSampleParameters(Me)
        End Function

#End Region

#Region " Private Variables "

        Private mintSampNumber As Integer
        Private mintSampPosNumber As Integer
        Private mdblnSamp As Double
        Private mstrSampleName As String
        Private mdblWeight As Double
        Private mdblVolume As Double
        Private mdblDilutionFactor As Double
        Private mdblAbs As Double
        Private mdblConc As Double
        Private mblnUsed As Boolean

        Public AbsRepeat As clsAbsRepeat

#End Region

#Region " Public Properties "

        Public Property SampNumber() As Integer
            Get
                Return mintSampNumber
            End Get
            Set(ByVal Value As Integer)
                mintSampNumber = Value
            End Set
        End Property

        Public Property SampPosNumber() As Integer
            Get
                Return mintSampPosNumber
            End Get
            Set(ByVal Value As Integer)
                mintSampPosNumber = Value
            End Set
        End Property

        Public Property nSamp() As Double
            Get
                Return mdblnSamp
            End Get
            Set(ByVal Value As Double)
                mdblnSamp = Value
            End Set
        End Property

        Public Property SampleName() As String
            Get
                Return mstrSampleName
            End Get
            Set(ByVal Value As String)
                mstrSampleName = Value
            End Set
        End Property

        Public Property Weight() As Double
            Get
                Return mdblWeight
            End Get
            Set(ByVal Value As Double)
                mdblWeight = Value
            End Set
        End Property

        Public Property Volume() As Double
            Get
                Return mdblVolume
            End Get
            Set(ByVal Value As Double)
                mdblVolume = Value
            End Set
        End Property

        Public Property DilutionFactor() As Double
            Get
                Return mdblDilutionFactor
            End Get
            Set(ByVal Value As Double)
                mdblDilutionFactor = Value
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

        Public Property Conc() As Double
            Get
                Return mdblConc
            End Get
            Set(ByVal Value As Double)
                mdblConc = Value
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

