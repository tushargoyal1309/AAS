Namespace Analysis

<Serializable()> Public Class clsRawData
        Implements ICloneable

#Region " Constructors and Destructors "

        '---Default Constructor
        Public Sub New()
            mintSampleID = 0
            mintSampleType = enumSampleType.BLANK
            mstrSampleName = ""
            mintTotalReadings = 0
            mobjReadings = New clsRawDataReadings
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsRawData)
            mintSampleID = rhs.SampleID
            mintSampleType = rhs.SampleType
            mstrSampleName = rhs.SampleName
            mintTotalReadings = rhs.TotalReadings
            mobjReadings = rhs.Readings.Clone()
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsRawData
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsRawData(Me)
        End Function

#End Region

#Region " Public enums, constants.. "

        Public Enum enumSampleType
            BLANK = 0
            STANDARD = 1
            SAMPLE = 2
        End Enum

#End Region

#Region " Private Variables "

        Private mintSampleID As Integer
        Private mintSampleType As enumSampleType
        Private mstrSampleName As String
        Private mintTotalReadings As Integer
        Private mobjReadings As clsRawDataReadings

#End Region

#Region " Public Properties "

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

#End Region

#Region " Public Functions "

        Public Sub AddReadings(ByVal dblXTime As Double, ByVal dblAbsorbance As Double)
            Dim objRawData As clsRawDataReadings.RAW_DATA

            If IsNothing(mobjReadings) Then
                mobjReadings = New clsRawDataReadings
            End If

            objRawData = New clsRawDataReadings.RAW_DATA
            objRawData.XTime = dblXTime
            objRawData.Absorbance = dblAbsorbance
            mobjReadings.Add(objRawData)

        End Sub

        Public Sub ClearReadings()
            If Not IsNothing(mobjReadings) Then mobjReadings.Clear()
        End Sub

        Public Sub DeleteReading(ByVal objRawData As clsRawDataReadings.RAW_DATA)
            mobjReadings.Remove(objRawData)
        End Sub

#End Region

End Class

End Namespace