Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsAnalysisParameters
        Implements ICloneable

#Region " Public Function "

        '---Default Constructor
        Public Sub New()
            mstrAnalystName = ""
            mstrLabName = ""
            mintMeasurementMode = 0
            mintIntegrationTime = 0
            mintNumOfSamples = 0
            mintNumOfSampleRepeats = 0
            mintNumOfStdRepeats = 0
            mblnBlankAfterEverySampleOrStd = False
            mintUnit = 0
            mintNumOfDecimalPlaces = 0
            mDtAnaDate = Now
            mblnBlank = False
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsAnalysisParameters)
            mstrAnalystName = rhs.AnalystName
            mDtAnaDate = rhs.Analysis_Date
            mstrLabName = rhs.LabName
            mintMeasurementMode = rhs.MeasurementMode
            mintIntegrationTime = rhs.IntegrationTime
            mintNumOfSamples = rhs.NumOfSamples
            mintNumOfSampleRepeats = rhs.NumOfSampleRepeats
            mintNumOfStdRepeats = rhs.NumOfStdRepeats
            mintNumOfDecimalPlaces = rhs.NumOfDecimalPlaces
            mblnBlankAfterEverySampleOrStd = rhs.IsBlankAfterEverySampleOrStd
            mblnBlank = rhs.IsBlank
            mintUnit = rhs.Unit
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAnalysisParameters
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsAnalysisParameters(Me)
        End Function

#End Region

#Region " Private Variables "

        Private mstrAnalystName As String
        Private mstrLabName As String
        Private mintMeasurementMode As Integer
        Private mintIntegrationTime As Integer
        Private mintNumOfSamples As Integer
        Private mintNumOfSampleRepeats As Integer
        Private mintNumOfStdRepeats As Integer
        Private mblnBlankAfterEverySampleOrStd As Boolean
        Private mintUnit As Integer
        Private mintNumOfDecimalPlaces As Integer
        Private mDtAnaDate As Date
        Private mblnBlank As Boolean

#End Region

#Region " Public Properties "

        Public Property AnalystName() As String
            Get
                Return mstrAnalystName
            End Get
            Set(ByVal Value As String)
                mstrAnalystName = Value
            End Set
        End Property

        Public Property LabName() As String
            Get
                Return mstrLabName
            End Get
            Set(ByVal Value As String)
                mstrLabName = Value
            End Set
        End Property

        Public Property MeasurementMode() As Integer
            Get
                Return mintMeasurementMode
            End Get
            Set(ByVal Value As Integer)
                mintMeasurementMode = Value
            End Set
        End Property

        Public Property IntegrationTime() As Integer
            Get
                Return mintIntegrationTime
            End Get
            Set(ByVal Value As Integer)
                mintIntegrationTime = Value
            End Set
        End Property

        Public Property NumOfSamples() As Integer
            Get
                Return mintNumOfSamples
            End Get
            Set(ByVal Value As Integer)
                mintNumOfSamples = Value
            End Set
        End Property

        Public Property NumOfSampleRepeats() As Integer
            Get
                Return mintNumOfSampleRepeats
            End Get
            Set(ByVal Value As Integer)
                mintNumOfSampleRepeats = Value
            End Set
        End Property

        Public Property NumOfStdRepeats() As Integer
            Get
                Return mintNumOfStdRepeats
            End Get
            Set(ByVal Value As Integer)
                mintNumOfStdRepeats = Value
            End Set
        End Property

        Public Property IsBlankAfterEverySampleOrStd() As Boolean
            Get
                Return mblnBlankAfterEverySampleOrStd
            End Get
            Set(ByVal Value As Boolean)
                mblnBlankAfterEverySampleOrStd = Value
            End Set
        End Property

        Public Property Unit() As Integer
            Get
                Return mintUnit
            End Get
            Set(ByVal Value As Integer)
                mintUnit = Value
            End Set
        End Property

        Public Property NumOfDecimalPlaces() As Integer
            Get
                Return mintNumOfDecimalPlaces
            End Get
            Set(ByVal Value As Integer)
                mintNumOfDecimalPlaces = Value
            End Set
        End Property

        Public Property Analysis_Date() As Date
            Get
                Return mDtAnaDate
            End Get
            Set(ByVal Value As Date)
                mDtAnaDate = Value
            End Set
        End Property

        Public Property IsBlank() As Boolean
            Get
                Return mblnBlank
            End Get
            Set(ByVal Value As Boolean)
                mblnBlank = Value
            End Set
        End Property

#End Region

    End Class

End Namespace