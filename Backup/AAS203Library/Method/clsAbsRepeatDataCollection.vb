Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Method

    <Serializable()> Public Class clsAbsRepeatDataCollection
        Inherits System.Collections.CollectionBase
        Implements ICloneable

#Region " Public Function "

        '---Default Constructor
        Public Sub New()

        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsAbsRepeatDataCollection)
            MyBase.New()
            Dim item As clsAbsRepeatData
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAbsRepeat
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsAbsRepeatDataCollection(Me)
        End Function

#End Region

        Default Property item(ByVal index As Integer) As clsAbsRepeatData
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As clsAbsRepeatData)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only data object to this collection
        Sub Add(ByVal value As clsAbsRepeatData)
            innerlist.Add(value)
        End Sub

    End Class
End Namespace

