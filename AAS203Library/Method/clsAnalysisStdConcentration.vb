Option Explicit On 

<Serializable()> Public Class clsAnalysisStdConcentration

    Private intSrNumber As Integer
    Private strStdName As String
    Private dblConcentration As Double

    Public Property SrNumber() As Integer
        Get
            SrNumber = intSrNumber
        End Get
        Set(ByVal Value As Integer)
            intSrNumber = Value
        End Set
    End Property

    Public Property StdName() As String
        Get
            StdName = strStdName
        End Get
        Set(ByVal Value As String)
            strStdName = Value
        End Set
    End Property

    Public Property Concentration() As Double
        Get
            Concentration = dblConcentration
        End Get
        Set(ByVal Value As Double)
            dblConcentration = Value
        End Set
    End Property

End Class
