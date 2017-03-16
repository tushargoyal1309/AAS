Namespace Analysis

    <Serializable()> Public Class clsRawDataReadings
        Inherits CollectionBase
        Implements ICloneable

        <Serializable()> Public Structure RAW_DATA
            Public XTime As Double
            Public Absorbance As Double
        End Structure

        '---Default Constructor
        Public Sub New()
            
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsRawDataReadings)
            MyBase.New()
            Dim item As RAW_DATA
            For Each item In rhs
                innerlist.Add(item)
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsRawDataReadings
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsRawDataReadings(Me)
        End Function

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

End Namespace
