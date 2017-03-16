Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsMethod
        Implements ICloneable

#Region " Private Variables "

        Private intMethodId As Integer
        Private strMethodName As String
        Private intOperationMode As Integer
        Private blnStandardAddition As Boolean
        Private strUserName As String
        Private strComments As String
        Private CreationDate As DateTime
        Private ModificationDate As DateTime
        Private LastUseDate As DateTime
        Private blnStatus As Boolean

        Private mobjInstrumentCondition As New clsInstrumentParameters

        Private mintSelectedElementID As Integer = 0

        Private mobjQuantitativeDataCollection As New clsQuantitativeDataCollection

        Private mintInstrumentBeamType As AAS203Library.Instrument.enumInstrumentBeamType

        Private mobjStandardData As New clsAnalysisStdParametersCollection


        Private mobjSampleData As clsAnalysisSampleParametersCollection
        Private mobjReportParameters As clsReportParameters
        Private mobjAnalysisParameters As clsAnalysisParameters

#End Region

#Region " Public Variables "

#End Region

#Region " Public Properties "

        Public Property MethodID() As Integer
            Get
                Return intMethodId
            End Get
            Set(ByVal Value As Integer)
                intMethodId = Value
            End Set
        End Property

        Public Property SelectedElementID() As Integer
            Get
                Return mintSelectedElementID
            End Get
            Set(ByVal Value As Integer)
                mintSelectedElementID = Value
            End Set
        End Property

        Public Property MethodName() As String
            Get
                MethodName = strMethodName
            End Get
            Set(ByVal Value As String)
                strMethodName = Value
            End Set
        End Property

        Public Property UserName() As String
            Get
                UserName = strUserName
            End Get
            Set(ByVal Value As String)
                strUserName = Value
            End Set
        End Property

        Public Property Comments() As String
            Get
                Comments = strComments
            End Get
            Set(ByVal Value As String)
                strComments = Value
            End Set
        End Property

        Public Property OperationMode() As Integer
            Get
                OperationMode = intOperationMode
            End Get
            Set(ByVal Value As Integer)
                intOperationMode = Value
            End Set
        End Property

        Public Property DateOfCreation() As DateTime
            Get
                Return CreationDate
            End Get
            Set(ByVal Value As DateTime)
                CreationDate = Value
            End Set
        End Property

        Public Property DateOfModification() As DateTime
            Get
                Return ModificationDate
            End Get
            Set(ByVal Value As DateTime)
                ModificationDate = Value
            End Set
        End Property

        Public Property DateOfLastUse() As DateTime
            Get
                Return LastUseDate
            End Get
            Set(ByVal Value As DateTime)
                LastUseDate = Value
            End Set
        End Property

        Public Property Status() As Boolean
            Get
                Return blnStatus
            End Get
            Set(ByVal Value As Boolean)
                blnStatus = Value
            End Set
        End Property

        Public Property StandardAddition() As Boolean
            Get
                StandardAddition = blnStandardAddition
            End Get
            Set(ByVal Value As Boolean)
                blnStandardAddition = Value
            End Set
        End Property

        'Public Property InstrumentConditions() As clsInstrumentParametersCollection
        '    Get
        '        Return mobjInstrumentConditions
        '    End Get
        '    Set(ByVal Value As clsInstrumentParametersCollection)
        '        mobjInstrumentConditions = New clsInstrumentParametersCollection
        '        mobjInstrumentConditions = Value
        '    End Set
        'End Property

        Public Property InstrumentCondition() As clsInstrumentParameters
            Get
                Return mobjInstrumentCondition
            End Get
            Set(ByVal Value As clsInstrumentParameters)
                mobjInstrumentCondition = Value
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

        Public Property QuantitativeDataCollection() As clsQuantitativeDataCollection
            Get
                Return mobjQuantitativeDataCollection
            End Get
            Set(ByVal Value As clsQuantitativeDataCollection)
                mobjQuantitativeDataCollection = Value
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

#End Region

#Region " Public functions "

        '---Default constructor
        Public Sub New()
            intMethodId = 0
            strMethodName = ""
            intOperationMode = 0
            blnStandardAddition = False
            strUserName = ""
            strComments = ""
            CreationDate = Now
            ModificationDate = Now
            LastUseDate = Now
            blnStatus = False
            mintSelectedElementID = 0
            mobjInstrumentCondition = New clsInstrumentParameters
            mintInstrumentBeamType = Instrument.enumInstrumentBeamType.SingleBeam
            mobjQuantitativeDataCollection = New clsQuantitativeDataCollection
        End Sub

        '---Copy constructor
        Public Sub New(ByVal rhs As clsMethod)
            Try
                intMethodId = rhs.MethodID
                strMethodName = rhs.MethodName
                intOperationMode = rhs.OperationMode
                blnStandardAddition = rhs.StandardAddition
                strUserName = rhs.UserName
                strComments = rhs.Comments
                CreationDate = rhs.DateOfCreation
                ModificationDate = rhs.DateOfModification
                LastUseDate = rhs.DateOfLastUse
                blnStatus = rhs.Status
                mintSelectedElementID = rhs.SelectedElementID
                mintInstrumentBeamType = rhs.InstrumentBeamType

                If Not rhs.InstrumentCondition Is Nothing Then
                    mobjInstrumentCondition = rhs.InstrumentCondition.Clone()
                End If

                If Not rhs.QuantitativeDataCollection Is Nothing Then
                    mobjQuantitativeDataCollection = rhs.QuantitativeDataCollection.Clone()
                End If

                If Not rhs.AnalysisParameters Is Nothing Then
                    mobjAnalysisParameters = rhs.AnalysisParameters.Clone
                End If

                If Not rhs.ReportParameters Is Nothing Then
                    mobjReportParameters = rhs.ReportParameters.Clone
                End If

                If Not rhs.StandardDataCollection Is Nothing Then
                    mobjStandardData = rhs.StandardDataCollection.Clone
                End If

                If Not rhs.SampleDataCollection Is Nothing Then
                    mobjSampleData = rhs.SampleDataCollection.Clone
                End If
            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                'gobjErrorHandler.ErrorDescription = ex.Message
                'gobjErrorHandler.ErrorMessage = ex.Message
                'gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                'If CONST_CREATE_EXECUTION_LOG = 1 Then
                '    gobjErrorHandler.WriteExecutionLog()
                'End If
                'If Not objWait Is Nothing Then
                '    objWait.Dispose()
                'End If
                '---------------------------------------------------------
            End Try
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsMethod(Me)
        End Function

#End Region

    End Class

End Namespace
