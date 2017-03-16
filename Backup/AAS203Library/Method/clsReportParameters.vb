Namespace Method
    <Serializable()> Public Class clsReportParameters
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            blnWeightVolumeDilution = False
            blnAbsorbance = False
            blnStandards = False
            blnMethodInfo = False
            blnAnalysisParameters = False
            blnInstrumentCondition = False
            blnReportHeaderAndFooter = False
            blnReportFooter = False
            blnDate = False
            blnLogo = False
            dblLeft = 0.0
            dblTop = 0.0
            dblBottom = 0.0
            strReportHeader = ""
            strReportFooter = ""
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsReportParameters)
            blnWeightVolumeDilution = rhs.IsWeightVolumeDilution
            blnAbsorbance = rhs.IsAbsorbance
            blnStandards = rhs.IsStandards
            blnMethodInfo = rhs.IsMethodInfo
            blnAnalysisParameters = rhs.IsAnalysisParameters
            blnInstrumentCondition = rhs.IsInstrumentCondition
            blnReportHeaderAndFooter = rhs.IsReportHeaderAndFooter
            blnReportFooter = rhs.blnReportFooter
            blnDate = rhs.blnDate
            blnLogo = rhs.blnLogo
            dblLeft = rhs.dblLeft
            dblTop = rhs.dblTop
            dblBottom = rhs.dblBottom
            strReportHeader = rhs.ReportHeader
            strReportFooter = rhs.ReportFooter
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAnalysisParameters
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsReportParameters(Me)
        End Function

#End Region

#Region " Private variables "

        Private blnWeightVolumeDilution As Boolean = False
        Private blnAbsorbance As Boolean = False
        Private blnStandards As Boolean = False
        Private blnMethodInfo As Boolean = False
        Private blnAnalysisParameters As Boolean = False
        Private blnInstrumentCondition As Boolean = False
        Private blnReportHeaderAndFooter As Boolean = False
        Private blnReportFooter As Boolean = False
        Private blnDate As Boolean = False
        Private blnLogo As Boolean = False
        Private dblLeft As Double = 0.0
        Private dblTop As Double = 0.0
        Private dblBottom As Double = 0.0
        Private strReportHeader As String = ""
        Private strReportFooter As String = ""

#End Region

#Region " Public Properties "

        Public Property IsWeightVolumeDilution() As Boolean
            Get
                Return blnWeightVolumeDilution
            End Get
            Set(ByVal Value As Boolean)
                blnWeightVolumeDilution = Value
            End Set
        End Property

        Public Property IsAbsorbance() As Boolean
            Get
                Return blnAbsorbance
            End Get
            Set(ByVal Value As Boolean)
                blnAbsorbance = Value
            End Set
        End Property

        Public Property IsStandards() As Boolean
            Get
                Return blnStandards
            End Get
            Set(ByVal Value As Boolean)
                blnStandards = Value
            End Set
        End Property

        Public Property IsMethodInfo() As Boolean
            Get
                Return blnMethodInfo
            End Get
            Set(ByVal Value As Boolean)
                blnMethodInfo = Value
            End Set
        End Property

        Public Property IsAnalysisParameters() As Boolean
            Get
                Return blnAnalysisParameters
            End Get
            Set(ByVal Value As Boolean)
                blnAnalysisParameters = Value
            End Set
        End Property

        Public Property IsInstrumentCondition() As Boolean
            Get
                Return blnInstrumentCondition
            End Get
            Set(ByVal Value As Boolean)
                blnInstrumentCondition = Value
            End Set
        End Property

        Public Property IsReportHeaderAndFooter() As Boolean
            Get
                Return blnReportHeaderAndFooter
            End Get
            Set(ByVal Value As Boolean)
                blnReportHeaderAndFooter = Value
            End Set
        End Property

        'Public Property IsReportFooter() As Boolean
        '    Get
        '        Return blnReportFooter
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        blnReportFooter = Value
        '    End Set
        'End Property

        'Public Property IsDate() As Boolean
        '    Get
        '        Return blnDate
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        blnDate = Value
        '    End Set
        'End Property

        'Public Property IsLogo() As Boolean
        '    Get
        '        Return blnLogo
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        blnLogo = Value
        '    End Set
        'End Property

        'Public Property LeftMargin() As Double
        '    Get
        '        Return dblLeft
        '    End Get
        '    Set(ByVal Value As Double)
        '        dblLeft = Value
        '    End Set
        'End Property

        'Public Property TopMargin() As Double
        '    Get
        '        Return dblTop
        '    End Get
        '    Set(ByVal Value As Double)
        '        dblTop = Value
        '    End Set
        'End Property

        'Public Property BottomMargin() As Double
        '    Get
        '        Return dblBottom
        '    End Get
        '    Set(ByVal Value As Double)
        '        dblBottom = Value
        '    End Set
        'End Property

        Public Property ReportHeader() As String
            Get
                Return strReportHeader
            End Get
            Set(ByVal Value As String)
                strReportHeader = Value
            End Set
        End Property

        Public Property ReportFooter() As String
            Get
                Return strReportFooter
            End Get
            Set(ByVal Value As String)
                strReportFooter = Value
            End Set
        End Property

#End Region

    End Class

End Namespace
