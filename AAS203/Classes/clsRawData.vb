Public Class clsRawData

    Public Enum enumSampleType
        BLANK = 0
        STANDARD = 1
        SAMPLE = 2
    End Enum

    Private mintSampleID As Integer
    Private mintSampleType As enumSampleType
    Private mstrSampleName As String
    Private mintTotalReadings As Integer
    Private mobjReadings As clsRawDataReadings


    Public Property SampleID() As Integer
        Get
            Return mintSampleID
        End Get
        Set(ByVal Value As Integer)
            mintSampleID = Value
        End Set
    End Property

    Public Property SampleType() As enumSampleType
        Get
            Return mintSampleType
        End Get
        Set(ByVal Value As enumSampleType)
            mintSampleType = Value
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

    Public ReadOnly Property TotalReadings() As Integer
        Get
            If Not IsNothing(mobjReadings) Then
                mintTotalReadings = mobjReadings.Count
            Else
                mintTotalReadings = 0
            End If
            Return mintTotalReadings
        End Get
    End Property

    Public ReadOnly Property Readings() As clsRawDataReadings
        Get
            Return mobjReadings
        End Get
    End Property

    Public Sub AddReadings(ByVal dblConcentration As Double, ByVal dblAbsorbance As Double)
        Dim objRawData As clsRawDataReadings.RAW_DATA

        If IsNothing(mobjReadings) Then
            mobjReadings = New clsRawDataReadings
        End If

        objRawData = New clsRawDataReadings.RAW_DATA
        objRawData.Concentration = dblConcentration
        objRawData.Absorbance = dblAbsorbance
        mobjReadings.Add(objRawData)

    End Sub

    Public Sub ClearReadings()
        If Not IsNothing(mobjReadings) Then mobjReadings.Clear()
    End Sub

    Public Sub DeleteReading(ByVal objRawData As clsRawDataReadings.RAW_DATA)
        mobjReadings.Remove(objRawData)
    End Sub

End Class
