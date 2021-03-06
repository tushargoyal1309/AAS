Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Method

    <Serializable()> Public Class clsAnalysisSampleParametersCollection
        Inherits System.Collections.CollectionBase
        Implements ICloneable

        '---Default Constructor
        Public Sub New()

        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsAnalysisSampleParametersCollection)
            MyBase.New()
            Dim item As clsAnalysisSampleParameters
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAnalysisSampleParametersCollection
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsAnalysisSampleParametersCollection(Me)
        End Function

        Default Property item(ByVal index As Integer) As clsAnalysisSampleParameters
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As clsAnalysisSampleParameters)
                innerlist.Item(index) = Value
            End Set
        End Property

        '--- you can add only data object to this collection
        Sub Add(ByVal value As clsAnalysisSampleParameters)
            innerlist.Add(value)
        End Sub

    End Class
End Namespace