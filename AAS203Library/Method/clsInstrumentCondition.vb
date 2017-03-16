Option Explicit On 

<Serializable()> Public Class clsInstrumentCondition

    Private strElementName As String
    Private intElementNumber As Integer
    Private intTurretNumber As Integer
    Private dblLampCurrent As Double
    Private dblWavelength As Double
    Private dblSlitWidth As Double
    Private blnBurnerYesNo As Boolean

    Public Property ElementName() As String
        Get
            ElementName = strElementName
        End Get
        Set(ByVal Value As String)
            strElementName = Value
        End Set
    End Property

    Public Property ElementNumber() As Integer
        Get
            ElementNumber = intElementNumber
        End Get
        Set(ByVal Value As Integer)
            intElementNumber = Value
        End Set
    End Property

    Public Property TurretNumber() As Integer
        Get
            TurretNumber = intTurretNumber
        End Get
        Set(ByVal Value As Integer)
            intTurretNumber = Value
        End Set
    End Property

    Public Property LampCurrent() As Double
        Get
            LampCurrent = dblLampCurrent
        End Get
        Set(ByVal Value As Double)
            dblLampCurrent = Value
        End Set
    End Property

    Public Property Wavelength() As Double
        Get
            Wavelength = dblWavelength
        End Get
        Set(ByVal Value As Double)
            dblWavelength = Value
        End Set
    End Property

    Public Property SlitWidth() As Double
        Get
            SlitWidth = dblSlitWidth
        End Get
        Set(ByVal Value As Double)
            dblSlitWidth = Value
        End Set
    End Property

    Public Property Burner() As Boolean
        Get
            Burner = blnBurnerYesNo
        End Get
        Set(ByVal Value As Boolean)
            blnBurnerYesNo = Value
        End Set
    End Property

End Class
