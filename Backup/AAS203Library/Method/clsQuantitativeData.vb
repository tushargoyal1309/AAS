Option Explicit On 

Namespace Method

    <Serializable()> Public Class clsQuantitativeData
        Implements ICloneable, IDisposable
        '**********************************************************************
        ' File Header       
        ' File Name 		:   clsQuantitativeData.vb
        ' Author			:   Mangesh Shardul
        ' Date/Time			:   25-Jan-2007 05:15 pm
        ' Description		:   Class to hold Quantitative Analysis Data of 
        '                       Standards and Samples, Analysis & Report Parameters
        ' Assumptions       :	
        ' Dependencies      :   clsMethod, clsAnalysisParameters, clsReportParameters
        '                       clsAnalysisStdParametersCollection, clsAnalysisSampleParametersCollection
        '**********************************************************************

#Region " Private Member Variables "

        Private mstrRunNumber As String
        Private mintCalculationMode As enumCalculationMode
        Private mobjInstParameters As clsInstrumentParameters
        Private mobjAnalysisParameters As clsAnalysisParameters
        Private mobjReportParameters As clsReportParameters
        Private mobjStandardData As clsAnalysisStdParametersCollection
        Private mobjSampleData As clsAnalysisSampleParametersCollection
        Private mobjAnalysisRawData As Analysis.clsRawDataCollection
        'Private mobjLastStandardData As clsAnalysisStdParameters
        'Private mobjLastSampleData As clsAnalysisSampleParameters

#End Region

#Region " Public Enums, Constants, structures .. "

        Public Enum enumCalculationMode
            DIRECT = -1
            RATIONAL = 0
            LINEAR = 1
            QUADRATIC = 2
            CUBIC = 3
            FOURTH_ORDER = 4
            FIFTH_ORDER = 5
        End Enum

#End Region

#Region " Public Properties "

        Public Property RunNumber() As String
            Get
                Return mstrRunNumber
            End Get
            Set(ByVal Value As String)
                mstrRunNumber = Value
            End Set
        End Property

        Public Property CalculationMode() As enumCalculationMode
            Get
                Return mintCalculationMode
            End Get
            Set(ByVal Value As enumCalculationMode)
                mintCalculationMode = Value
            End Set
        End Property

        Public Property AnalysisParameters() As clsAnalysisParameters
            Get
                Return mobjAnalysisParameters
            End Get
            Set(ByVal Value As clsAnalysisParameters)
                mobjAnalysisParameters = Value
            End Set
        End Property

        Public Property ReportParameters() As clsReportParameters
            Get
                Return mobjReportParameters
            End Get
            Set(ByVal Value As clsReportParameters)
                mobjReportParameters = Value
            End Set
        End Property

        Public Property StandardDataCollection() As clsAnalysisStdParametersCollection
            Get
                Return mobjStandardData
            End Get
            Set(ByVal Value As clsAnalysisStdParametersCollection)
                mobjStandardData = Value
            End Set
        End Property

        Public Property SampleDataCollection() As clsAnalysisSampleParametersCollection
            Get
                Return mobjSampleData
            End Get
            Set(ByVal Value As clsAnalysisSampleParametersCollection)
                mobjSampleData = Value
            End Set
        End Property

        Public Property AnalysisRawData() As Analysis.clsRawDataCollection
            Get
                Return mobjAnalysisRawData
            End Get
            Set(ByVal Value As Analysis.clsRawDataCollection)
                mobjAnalysisRawData = Value
            End Set
        End Property

        Public Property InstrumentParameterForRunNumber() As clsInstrumentParameters
            Get
                Return mobjInstParameters
            End Get
            Set(ByVal Value As clsInstrumentParameters)
                mobjInstParameters = Value
            End Set
        End Property

        'Public Property LastStandardData() As clsAnalysisStdParameters
        '    Get
        '        Return mobjLastStandardData
        '    End Get
        '    Set(ByVal Value As clsAnalysisStdParameters)
        '        mobjLastStandardData = Value
        '    End Set
        'End Property

        'Public Property LastSampleData() As clsAnalysisSampleParameters
        '    Get
        '        Return mobjLastSampleData
        '    End Get
        '    Set(ByVal Value As clsAnalysisSampleParameters)
        '        mobjLastSampleData = Value
        '    End Set
        'End Property

#End Region

#Region " Public functions "

        '---Default Constructor
        Public Sub New()
            '=====================================================================
            ' Procedure Name        : New [Constructor]
            ' Parameters Passed     : None
            ' Returns               : None
            ' Purpose               : To initialize the member variables
            ' Description           : 
            ' Assumptions           : 
            ' Dependencies          : 
            ' Author                : Mangesh Shardul
            ' Created               : 25-Jan-2007 05:20 pm
            ' Revisions             : 1
            '=====================================================================
            mstrRunNumber = ""
            mintCalculationMode = enumCalculationMode.DIRECT
            mobjAnalysisParameters = New clsAnalysisParameters
            mobjReportParameters = New clsReportParameters
            mobjStandardData = New clsAnalysisStdParametersCollection
            mobjSampleData = New clsAnalysisSampleParametersCollection
            mobjAnalysisRawData = New Analysis.clsRawDataCollection
            'mobjLastStandardData = New clsAnalysisStdParameters
            'mobjLastSampleData = New clsAnalysisSampleParameters
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsQuantitativeData)
            '=====================================================================
            ' Procedure Name        : New [Copy Constructor]
            ' Parameters Passed     : None
            ' Returns               : None
            ' Purpose               : To initialize the member variables
            ' Description           : 
            ' Assumptions           : 
            ' Dependencies          : 
            ' Author                : Mangesh Shardul
            ' Created               : 25-Jan-2007 05:20 pm
            ' Revisions             : 1
            '=====================================================================
            mstrRunNumber = rhs.RunNumber
            mintCalculationMode = rhs.CalculationMode
            mobjAnalysisParameters = rhs.AnalysisParameters.Clone()
            mobjReportParameters = rhs.ReportParameters.Clone()
            mobjStandardData = rhs.StandardDataCollection.Clone()
            mobjSampleData = rhs.SampleDataCollection.Clone()
            mobjAnalysisRawData = rhs.AnalysisRawData.Clone()
            'mobjLastStandardData = rhs.LastStandardData.Clone
            'mobjLastSampleData = rhs.LastSampleData.Clone
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsQuantitativeData
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsQuantitativeData(Me)
        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose
            '=====================================================================
            ' Procedure Name        : Dispose [Constructor]
            ' Parameters Passed     : None
            ' Returns               : None
            ' Purpose               : To dispose off the member variables
            ' Description           : 
            ' Assumptions           : 
            ' Dependencies          : 
            ' Author                : Mangesh Shardul
            ' Created               : 25-Jan-2007 05:20 pm
            ' Revisions             : 1
            '=====================================================================
            mstrRunNumber = Nothing
            mintCalculationMode = Nothing
            mobjAnalysisParameters = Nothing
            mobjReportParameters = Nothing
            mobjStandardData = Nothing
            mobjSampleData = Nothing
            'mobjLastStandardData = Nothing
            'mobjLastSampleData = Nothing
        End Sub

#End Region

    End Class

End Namespace
