Option Explicit On 

Namespace Analysis

    <Serializable()> Public Class clsRawDataCollection
        Inherits CollectionBase
        Implements ICloneable, IDisposable

        '---Default Constructor
        Public Sub New()
           
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsRawDataCollection)
            MyBase.New()
            Dim item As clsRawData
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsRawDataCollection
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsRawDataCollection(Me)
        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose
            innerlist.Clear()
        End Sub

        Default Public Property item(ByVal index As Integer) As clsRawData
            Get
                '//----- Modified by Sachin Dokhale 
                'Return CType(InnerList.Item(index), clsRawData)
                Return InnerList.Item(index)
            End Get
            Set(ByVal Value As clsRawData)
                innerlist.Item(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As clsRawData) As Integer
            Return InnerList.Add(value)
        End Function

    End Class

End Namespace
