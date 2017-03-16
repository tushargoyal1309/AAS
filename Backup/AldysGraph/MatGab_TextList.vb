Imports System
Imports System.Drawing
Imports System.Collections

Namespace AldysGraph
	''' <summary>
	''' A collection class containing a list of <see cref="TextItem"/> objects
	''' to be displayed on the graph.
	''' </summary>
	Public Class TextList
		Inherits CollectionBase
		Implements ICloneable
		''' <summary>
		''' Default constructor for the <see cref="TextList"/> collection class
		''' </summary>
		Public Sub New()
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The TextList object from which to copy</param>
		Public Sub New(rhs As TextList)
			For Each item As TextItem In rhs
				Me.Add(New TextItem(item))
			Next
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the TextList</returns>
		Public Function Clone() As Object
			Return New TextList(Me)
		End Function

		''' <summary>
		''' Indexer to access the specified <see cref="TextItem"/> object by its ordinal
		''' position in the list.
		''' </summary>
		''' <param name="index">The ordinal position (zero-based) of the
		''' <see cref="TextItem"/> object to be accessed.</param>
		''' <value>A <see cref="TextItem"/> object reference.</value>
		Public Default Property Item(index As Integer) As TextItem
			Get
				Return DirectCast(List(index), TextItem)
			End Get
			Set
				List(index) = value
			End Set
		End Property

		''' <summary>
		''' Add a <see cref="TextItem"/> object to the <see cref="TextList"/>
		''' collection at the end of the list.
		''' </summary>
		''' <param name="item">A reference to the <see cref="TextItem"/> object to
		''' be added</param>
		Public Sub Add(item As TextItem)
			List.Add(item)
		End Sub

		''' <summary>
		''' Remove a <see cref="TextItem"/> object from the <see cref="TextList"/>
		''' collection at the specified ordinal location.
		''' </summary>
		''' <param name="index">An ordinal position in the list at which
		''' the object to be removed is located. </param>
		Public Sub Remove(index As Integer)
			List.RemoveAt(index)
		End Sub

		''' <summary>
		''' Render text to the specified <see cref="Graphics"/> device
		''' by calling the Draw method of each <see cref="TextItem"/> object in
		''' the collection.  This method is normally only called by the Draw method
		''' of the parent <see cref="AldysPane"/> object.
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
			For Each item As TextItem In Me
				'----- Added by Sachin Dokhale
				item.WidthX = DirectCast(item.FontSpec.GetWidth(g, item.Text, scaleFactor), Single)
				' * ((float)item.Text.Length); 
				'item.HeightY  = (item.fontSpec.GetHeight);	//* (flot) text.Length ; 
				'item.WidthX  = (item.FontSpec.GetWidth(g, scaleFactor));	// * item.Text.Length); 
				'-----
				'The following condition is added by deepak b on 07.04.06
				If item.X < pane.XAxis.Min OrElse item.X > pane.XAxis.Max OrElse item.Y < pane.YAxis.Min OrElse item.Y > pane.YAxis.Max Then
					If Convert.ToDouble(item.X) < (pane.XAxis.Min) Then
						item.X = DirectCast(pane.XAxis.Min, Single)
					End If

					If Convert.ToDouble(item.X) > (pane.XAxis.Max) Then
						item.X = DirectCast(pane.XAxis.Max, Single)
					End If
					If Convert.ToDouble(item.Y) < (pane.YAxis.Min) Then
						item.Y = DirectCast(pane.YAxis.Min, Single)
					End If

					If Convert.ToDouble(item.Y) > (pane.YAxis.Max) Then
						item.Y = DirectCast(pane.YAxis.Max, Single)
					End If

					item.Draw(g, pane, scaleFactor)
				Else
					'Added By Pankaj Bamb on 04 Sup 07
					If item.X <= pane.XAxis.Min + item.Text.Length / 2 Then
						item.AlignH = FontAlignH.Left
					ElseIf item.X >= pane.XAxis.Max - item.Text.Length / 2 Then
						item.AlignH = FontAlignH.Right
					Else
						item.AlignH = FontAlignH.Center
					End If
					'Ended by pankaj Bamb
					item.Draw(g, pane, scaleFactor)
				End If
			Next
			'item.Draw( g, pane, scaleFactor );
		End Sub
	End Class

	''' <summary>
	''' A class that represents a text object on the graph.  A list of
	''' <see cref="TextItem"/> objects is maintained by the
	''' <see cref="TextList"/> collection class.
	''' </summary>
	Public Class TextItem
		Implements ICloneable
		Private m_text As String
		Private m_alignV As FontAlignV
		Private m_alignH As FontAlignH

		Private m_x As Single, m_y As Single
		'----- Added by Sachin Dokhale on 3.09.07
		Private m_widthx As Single, m_heighty As Single
		'-----
		Private m_coordinateFrame As CoordType
		Private m_fontSpec As FontSpecs

		Private blnForCurveLabel As Boolean
		Private blnForHighPeakLabel As Boolean

		''' <overloads>
		''' Constructors for the <see cref="TextItem"/> class.
		''' </overloads>
		''' <summary>
		''' Default constructor that sets all <see cref="TextItem"/> properties to default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		Public Sub New()
			Init()
		End Sub

		''' <summary>
		''' Initialization method that sets all <see cref="TextItem"/> properties to default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		Protected Sub Init()
			m_text = "Text"
			m_alignV = Defaults.Text.AlignV
			m_alignH = Defaults.Text.AlignH
			m_x = 0
			m_y = 0
			m_widthx = 0
			m_heighty = 0

			m_coordinateFrame = Defaults.Text.CoordFrame

			Me.m_fontSpec = New FontSpecs(Defaults.Text.FontFamily, Defaults.Text.FontSize, Defaults.Text.FontColor, Defaults.Text.FontBold, Defaults.Text.FontItalic, Defaults.Text.FontUnderline)

			'widthx  = (this.fontSpec.GetWidth( * (float) text.Length ); 
			'heighty  = (this.fontSpec.GetHeight);	//* (flot) text.Length ; 
			blnForCurveLabel = False
			blnForHighPeakLabel = False
		End Sub

		''' <summary>
		''' Constructor that sets all <see cref="TextItem"/> properties to default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		''' <param name="text">T</param>
		''' <param name="x">The x position of the text.  The units
		''' of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.  The text will be
		''' aligned to this position based on the <see cref="AlignH"/>
		''' property.</param>
		''' <param name="y">The y position of the text.  The units
		''' of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.  The text will be
		''' aligned to this position based on the
		''' <see cref="AlignV"/> property.</param>
		Public Sub New(text As String, x As Single, y As Single)
			Init()
			Me.m_text = text
			Me.m_x = x
			Me.m_y = y
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The TextItem object from which to copy</param>
		Public Sub New(rhs As TextItem)
			m_text = rhs.Text
			m_alignV = rhs.AlignV
			m_alignH = rhs.AlignH
			m_x = rhs.X
			m_y = rhs.Y
			m_widthx = rhs.widthx
			m_heighty = rhs.heighty

			blnForCurveLabel = rhs.blnForCurveLabel
			blnForHighPeakLabel = rhs.blnForHighPeakLabel
			m_coordinateFrame = rhs.CoordinateFrame

			m_fontSpec = New FontSpecs(rhs.FontSpec)
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the TextItem</returns>
		Public Function Clone() As Object
			Return New TextItem(Me)
		End Function

		''' <summary>
		''' The <see cref="TextItem"/> to be displayed.  This text can be multi-line by
		''' including newline ('\n') characters between the lines.
		''' </summary>
		Public Property Text() As String
			Get
				Return m_text
			End Get
			Set
					'----- Added by Sachin Dokhale on 03.09.07
					'this.WidthX  = (this.fontSpec.GetWidth( * (float) value.Length); 
					'-----
				m_text = value
			End Set
		End Property
		''' <summary>
		''' Gets a reference to the <see cref="FontSpec"/> class used to render
		''' this <see cref="TextItem"/>
		''' </summary>
		Public ReadOnly Property FontSpec() As FontSpecs
			Get
				Return m_fontSpec
			End Get
		End Property
		''' <summary>
		''' A horizontal alignment parameter for this <see cref="TextItem"/> specified
		''' using the <see cref="FontAlignH"/> enum type
		''' </summary>
		Public Property AlignH() As FontAlignH
			Get
				Return m_alignH
			End Get
			Set
				m_alignH = value
			End Set
		End Property
		''' <summary>
		''' A vertical alignment parameter for this <see cref="TextItem"/> specified
		''' using the <see cref="FontAlignV"/> enum type
		''' </summary>
		Public Property AlignV() As FontAlignV
			Get
				Return m_alignV
			End Get
			Set
				m_alignV = value
			End Set
		End Property
		''' <summary>
		''' The x position of the <see cref="TextItem"/>.  The units of this position
		''' are specified by the <see cref="CoordinateFrame"/> property.
		''' The text will be aligned to this position based on the
		''' <see cref="AlignH"/> property.
		''' </summary>
		Public Property X() As Single
			Get
				Return m_x
			End Get
			Set
				m_x = value
			End Set
		End Property
		''' <summary>
		''' The x position of the <see cref="TextItem"/>.  The units of this position
		''' are specified by the <see cref="CoordinateFrame"/> property.
		''' The text will be aligned to this position based on the
		''' <see cref="AlignV"/> property.
		''' </summary>
		Public Property Y() As Single
			Get
				Return m_y
			End Get
			Set
				m_y = value
			End Set
		End Property


		Public Property ForCurveLabel() As Boolean
			Get
				Return blnForCurveLabel
			End Get
			Set
				blnForCurveLabel = value
			End Set
		End Property

		Public Property ForHighPeakLabel() As Boolean
			Get
				Return blnForHighPeakLabel
			End Get
			Set
				blnForHighPeakLabel = value
			End Set
		End Property

		''' <summary>
		''' The coordinate system to be used for defining the <see cref="TextItem"/> position
		''' </summary>
		''' <value> The coordinate system is defined with the <see cref="CoordType"/>
		''' enum</value>
		Public Property CoordinateFrame() As CoordType
			Get
				Return m_coordinateFrame
			End Get
			Set
				m_coordinateFrame = value
			End Set
		End Property

		Public Property WidthX() As Single
			Get
				Return m_widthx
			End Get
			Set
				m_widthx = value
			End Set
		End Property

		Public Property HeightY() As Single
			Get
				Return m_heighty
			End Get
			Set
				m_heighty = value
			End Set
		End Property

		''' <summary>
		''' Render this <see cref="TextItem"/> object to the specified <see cref="Graphics"/> device
		''' This method is normally only called by the Draw method
		''' of the parent <see cref="TextList"/> collection object.
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
			' transform the x,y location from the user-defined
			' coordinate frame to the screen pixel location
			Dim pix As PointF = pane.GeneralTransform(New PointF(Me.m_x, Me.m_y), Me.m_coordinateFrame)

			' Draw the text on the screen, including any frame and background
			' fill elements
			If (pix.X + Me.WidthX) >= pane.paneRect.Width Then
				pix.X = pane.paneRect.Width - (Me.WidthX + 5)
			End If

			If pix.X > -10000 AndAlso pix.X < 100000 AndAlso pix.Y > -100000 AndAlso pix.Y < 100000 Then
				Me.FontSpec.Draw(g, Me.m_text, pix.X, pix.Y, Me.m_alignH, Me.m_alignV, _
					scaleFactor)
			End If
		End Sub
	End Class
End Namespace
