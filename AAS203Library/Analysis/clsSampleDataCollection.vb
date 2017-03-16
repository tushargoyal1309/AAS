
'Imports System
'Imports System.Collections
'Imports System.IO
'Imports System.Runtime.Serialization.Formatters.Binary

'Namespace Analysis
'    <Serializable()> Public Class clsSampleDataCollection
'        Inherits System.Collections.CollectionBase
'        Implements ICloneable

'#Region "Functions"
'        Public Function Clone() As Object Implements System.ICloneable.Clone
'            Return Me
'        End Function
'#End Region

'#Region "Properties"
'        Default Property item(ByVal index As Integer) As clsSampleData
'            Get
'                Return innerlist.Item(index)
'            End Get
'            Set(ByVal Value As clsSampleData)
'                innerlist.Item(index) = Value
'            End Set
'        End Property

'        '--- you can add only data object to this collection
'        Sub Add(ByVal value As clsSampleData)
'            innerlist.Add(value)
'        End Sub
'#End Region

'    End Class
'End Namespace
