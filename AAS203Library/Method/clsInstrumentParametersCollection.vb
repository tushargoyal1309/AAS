Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Method
    <Serializable()> Public Class clsInstrumentParametersCollection
        Inherits System.Collections.CollectionBase
        Implements ICloneable

        '---Default constructor
        Public Sub New()

        End Sub

        '---Copy constructor
        Public Sub New(ByVal rhs As clsInstrumentParametersCollection)
            MyBase.New()
            Dim item As clsInstrumentParameters
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsInstrumentParametersCollection
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsInstrumentParametersCollection(Me)
        End Function

        Default Property item(ByVal index As Integer) As clsInstrumentParameters
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As clsInstrumentParameters)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only data object to this collection
        Sub Add(ByVal value As clsInstrumentParameters)
            innerlist.Add(value)
        End Sub

    End Class

End Namespace