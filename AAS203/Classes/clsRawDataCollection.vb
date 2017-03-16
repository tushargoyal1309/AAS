Public Class clsRawDataCollection
    Inherits CollectionBase

    Default Public ReadOnly Property item(ByVal index As Integer) As clsRawData
        Get
            Return CType(InnerList.Item(index), clsRawData)
        End Get
    End Property

    Public Function Add(ByVal value As clsRawData) As Integer
        Return InnerList.Add(value)
    End Function

End Class
