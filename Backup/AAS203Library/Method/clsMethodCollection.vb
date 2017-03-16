Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Method

    <Serializable()> Public Class clsMethodCollection
        Inherits System.Collections.CollectionBase
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()

        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsMethodCollection)
            MyBase.New()
            Dim item As clsMethod
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsMethodCollection
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsMethodCollection(Me)
        End Function

        '--- you can add only data object to this collection
        Public Sub Add(ByVal value As clsMethod)
            innerlist.Add(value)
        End Sub

#End Region

#Region " Public Properties "

        Default Property item(ByVal index As Integer) As clsMethod
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As clsMethod)
                innerlist.Item(index) = Value
            End Set
        End Property

#End Region

    End Class

End Namespace