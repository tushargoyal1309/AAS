Imports System
Imports System.Drawing
Imports System.Collections

Namespace AldysGraph
	''' <summary>
	''' A collection class containing a list of <see cref="CurveItem"/> objects
	''' that define the set of curves to be displayed on the graph.
	''' </summary>
	Public Class CurveList
		Inherits CollectionBase
		Implements ICloneable
		Public isResizing As Boolean
		''' <summary>
		''' Default constructor for the collection class
		''' </summary>
		Public Sub New()
			isResizing = False
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The XAxis object from which to copy</param>
		Public Sub New(rhs As CurveList)
			For Each item As CurveItem In rhs
				Me.Add(New CurveItem(item))
			Next
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the CurveList</returns>
		Public Function Clone() As Object
			Return New CurveList(Me)
		End Function

		''' <summary>
		''' Indexer to access the specified <see cref="CurveItem"/> object by
		''' its ordinal position in the list.
		''' </summary>
		''' <param name="index">The ordinal position (zero-based) of the
		''' <see cref="CurveItem"/> object to be accessed.</param>
		''' <value>A <see cref="CurveItem"/> object reference.</value>
		Public Default Property Item(index As Integer) As CurveItem
			Get
				Return DirectCast(List(index), CurveItem)
			End Get
			Set
				List(index) = value
			End Set
		End Property

		''' <summary>
		''' Add a <see cref="CurveItem"/> object to the collection at the end of the list.
		''' </summary>
		''' <param name="curve">A reference to the <see cref="CurveItem"/> object to
		''' be added</param>
		Public Sub Add(curve As CurveItem)
			List.Add(curve)
		End Sub

		''' <summary>
		''' Remove a <see cref="CurveItem"/> object from the collection at the
		''' specified ordinal location.
		''' </summary>
		''' <param name="index">An ordinal position in the list at which
		''' the object to be removed is located. </param>
		Public Sub Remove(index As Integer)
			List.RemoveAt(index)
		End Sub

		''' <summary>
		''' Go through each <see cref="CurveItem"/> object in the collection,
		''' calling the <see cref="CurveItem.GetRange"/> member to 
		''' determine the minimum and maximum values in the
		''' <see cref="CurveItem.X"/> and <see cref="CurveItem.Y"/> data arrays.  In the event that no
		''' data are available, a default range of min=0.0 and max=1.0 are returned.
		''' If any <see cref="CurveItem"/> in the list has a missing
		''' <see cref="CurveItem.X"/> or <see cref="CurveItem.Y"/> data array, and suitable
		''' default array will be created with ordinal values.
		''' </summary>
		''' <param name="xMinVal">The minimun X value in the data range for all curves
		''' in this collection</param>
		''' <param name="xMaxVal">The maximun X value in the data range for all curves
		''' in this collection</param>
		''' <param name="yMinVal">The minimun Y (left Y axis) value in the data range
		''' for all curves in this collection</param>
		''' <param name="yMaxVal">The maximun Y (left Y axis) value in the data range
		''' for all curves in this collection</param>
		''' <param name="y2MinVal">The minimun Y2 (right Y axis) value in the data range
		''' for all curves in this collection</param>
		''' <param name="y2MaxVal">The maximun Y2 (right Y axis) value in the data range
		''' for all curves in this collection</param>
		''' <param name="bIgnoreInitial">ignoreInitial is a boolean value that
		''' affects the data range that is considered for the automatic scale
		''' ranging (see <see cref="AldysPane.IsIgnoreInitial"/>).  If true, then initial
		''' data points where the Y value is zero are not included when
		''' automatically determining the scale <see cref="Axis.Min"/>,
		''' <see cref="Axis.Max"/>, and <see cref="Axis.Step"/> size.  All data after
		''' the first non-zero Y value are included.
		''' </param>
		''' <param name="pane">
		''' A reference to the <see cref="AldysPane"/> object that is the parent or
		''' owner of this object.
		''' </param>
		Public Sub GetRange(ByRef xMinVal As Double, ByRef xMaxVal As Double, ByRef yMinVal As Double, ByRef yMaxVal As Double, ByRef y2MinVal As Double, ByRef y2MaxVal As Double, _
			bIgnoreInitial As Boolean, pane As AldysPane)
			Dim tXMinVal As Double, tXMaxVal As Double, tYMinVal As Double, tYMaxVal As Double

			' initialize the values to outrageous ones to start
			xMinVal = InlineAssignHelper(yMinVal, InlineAssignHelper(y2MinVal, InlineAssignHelper(tXMinVal, InlineAssignHelper(tYMinVal, 1E+20))))
			xMaxVal = InlineAssignHelper(yMaxVal, InlineAssignHelper(y2MaxVal, InlineAssignHelper(tXMaxVal, InlineAssignHelper(tYMaxVal, -1E+20))))

			' Loop over each curve in the collection
			For Each curve As CurveItem In Me
				' Generate default arrays of ordinal values if any data arrays are missing
				curve.DataCheck(pane)

				' Call the GetRange() member function for the current
				' curve to get the min and max values
				curve.GetRange(tXMinVal, tXMaxVal, tYMinVal, tYMaxVal, bIgnoreInitial)

				' If the min and/or max values from the current curve
				' are the absolute min and/or max, then save the values
				' Also, differentiate between Y and Y2 values		
				If curve.IsY2Axis Then
					If tYMinVal < y2MinVal Then
						y2MinVal = tYMinVal
					End If
					If tYMaxVal > y2MaxVal Then
						y2MaxVal = tYMaxVal
					End If
				Else
					If tYMinVal < yMinVal Then
						yMinVal = tYMinVal
					End If
					If tYMaxVal > yMaxVal Then
						yMaxVal = tYMaxVal
					End If
				End If

				If tXMinVal < xMinVal Then
					xMinVal = tXMinVal
				End If
				If tXMaxVal > xMaxVal Then
					xMaxVal = tXMaxVal

				End If
			Next

			' Define suitable default ranges in the event that
			' no data were available
			If xMinVal >= 1E+20 OrElse xMaxVal <= -1E+20 Then
				xMinVal = 0
				xMaxVal = 1
			End If

			If yMinVal >= 1E+20 OrElse yMaxVal <= -1E+20 Then
				yMinVal = 0
				yMaxVal = 1
			End If

			If y2MinVal >= 1E+20 OrElse y2MaxVal <= -1E+20 Then
				y2MinVal = 0
				y2MaxVal = 1
			End If
		End Sub

		''' <summary>
		''' Determine if there is any data in any of the <see cref="CurveItem"/>
		''' objects for this graph.  This method does not verify valid data, it
		''' only checks to see if <see cref="CurveItem.NPts"/> > 0.
		''' </summary>
		''' <returns>true if there is any data, false otherwise</returns>
		Public Function HasData() As Boolean
			For Each curve As CurveItem In Me
				If curve.NPts > 0 Then
					Return True
				End If
			Next
			Return False
		End Function

		''' <summary>
		''' Render all the <see cref="CurveItem"/> objects in the list to the
		''' specified <see cref="Graphics"/>
		''' device by calling the <see cref="CurveItem.Draw"/> member function of
		''' each <see cref="CurveItem"/> object.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="pane">
		''' A reference to the <see cref="AldysPane"/> object that is the parent or
		''' owner of this object.
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		Public Sub Draw(g As Graphics, pane As AldysPane, scaleFactor As Double)
			' Loop for each curve
			For Each curve As CurveItem In Me
				' Render the curve
				'curve.Draw( g, pane, scaleFactor );

				If curve.IsHighPeakLine Then
					Me.isResizing = False
				End If


				curve.Draw(g, pane, scaleFactor)
			Next
		End Sub
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function
	End Class

End Namespace
