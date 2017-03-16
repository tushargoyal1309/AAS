Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace FuelConditions
    <Serializable()> Public Class clsFuelDataCollection
        Inherits System.Collections.CollectionBase
        Implements ICloneable

#Region " Public Function "

        '---Default Constructor
        Public Sub New()

        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsFuelDataCollection)
            MyBase.New()
            Dim item As clsFuelData
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsFuelDataCollection(Me)
        End Function

#End Region

        Default Property item(ByVal index As Integer) As clsFuelData
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As clsFuelData)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only data object to this collection
        Sub Add(ByVal value As clsFuelData)
            innerlist.Add(value)

        End Sub
    End Class
End Namespace
