Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Instrument

    <Serializable()> Public Class ClsLampParametersCollection
        Inherits System.Collections.CollectionBase
        Implements ICloneable

        '---Default Constructor
        Public Sub New()

        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As ClsLampParametersCollection)
            MyBase.New()
            Dim item As ClsLampParameters
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the ClsLampParametersCollection
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New ClsLampParametersCollection(Me)
        End Function

        Default Property item(ByVal index As Integer) As ClsLampParameters
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As ClsLampParameters)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only data object to this collection
        Sub Add(ByVal value As ClsLampParameters)
            innerlist.Add(value)
        End Sub

    End Class
End Namespace

