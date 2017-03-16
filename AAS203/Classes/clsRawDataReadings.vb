Public Class clsRawDataReadings
    Inherits CollectionBase

    Public Structure RAW_DATA
        Public Concentration As Double
        Public Absorbance As Double
    End Structure

    Default Public ReadOnly Property item(ByVal index As Integer) As RAW_DATA
        Get
            Return CType(InnerList.Item(index), RAW_DATA)
        End Get
    End Property

    Public Function Add(ByVal value As RAW_DATA) As Integer
        Return InnerList.Add(value)
    End Function

    Public Sub Remove(ByVal value As RAW_DATA)
        If InnerList.Contains(value) Then
            InnerList.Remove(value)
        End If
    End Sub

End Class