Option Explicit On 

Namespace Method

    <Serializable()> Public Class clsQuantitativeDataCollection
        Inherits CollectionBase
        Implements ICloneable, IDisposable
        '**********************************************************************
        ' File Header       
        ' File Name 		:   clsQuantitativeDataCollection.vb
        ' Author			:   Mangesh Shardul
        ' Date/Time			:   25-Jan-2007 05:30 pm
        ' Description		:   Class to hold Quantitative Analysis Data of 
        '                       Standards and Samples, Analysis & Report Parameters
        ' Assumptions       :	
        ' Dependencies      :   clsMethod, clsAnalysisParameters, clsReportParameters
        '                       clsAnalysisStdParametersCollection, clsAnalysisSampleParametersCollection
        '**********************************************************************

#Region " Public Properties "

        Default Public Property Item(ByVal index As Integer) As clsQuantitativeData
            Get
                Return innerlist.Item(index)
            End Get
            Set(ByVal Value As clsQuantitativeData)
                innerlist.Item(index) = Value
            End Set
        End Property

#End Region

#Region " Public Functions "

        '---Default constructor
        Public Sub New()
           
        End Sub

        '---Copy constructor
        Public Sub New(ByVal rhs As clsQuantitativeDataCollection)
            MyBase.New()
            Dim item As clsQuantitativeData
            For Each item In rhs
                innerlist.Add(item.Clone())
            Next
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsQuantitativeDataCollection
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsQuantitativeDataCollection(Me)
        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose
            innerlist.Clear()
        End Sub

        Public Sub Add(ByVal value As clsQuantitativeData)
            innerlist.Add(value)
        End Sub

#End Region

    End Class

End Namespace
