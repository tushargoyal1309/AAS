Imports System
Imports System.Drawing

Namespace AldysGraph
	''' <summary>
	''' This class encapsulates the chart <see cref="Legend"/> that is displayed
	''' in the <see cref="AldysPane"/>
	''' </summary>
	Public Class Legend
		Implements ICloneable
		Private m_rect As RectangleF
		Private m_location As LegendLoc
		Private m_isFramed As Boolean
		Private m_isFilled As Boolean
		Private m_isHStack As Boolean
		Private m_isVisible As Boolean
		Private m_fillColor As Color
		Private m_frameColor As Color
		Private m_frameWidth As Single

		Private m_fontSpec As FontSpecs

		''' <summary>
		''' Default constructor that sets all <see cref="Legend"/> properties to default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		Public Sub New()
			Me.m_location = Defaults.Legend.Location
			Me.m_isFramed = Defaults.Legend.IsFramed
			Me.m_frameColor = Defaults.Legend.FrameColor
			Me.m_frameWidth = Defaults.Legend.FrameWidth
			Me.m_isFilled = Defaults.Legend.IsFilled
			Me.m_fillColor = Defaults.Legend.FillColor
			Me.m_isHStack = Defaults.Legend.HStack
			Me.m_isVisible = Defaults.Legend.IsVisible

			Me.m_fontSpec = New FontSpecs(Defaults.Legend.FontFamily, Defaults.Legend.FontSize, Defaults.Legend.FontColor, Defaults.Legend.FontBold, Defaults.Legend.FontItalic, Defaults.Legend.FontUnderline)
			Me.m_fontSpec.IsFilled = False
			Me.m_fontSpec.IsFramed = False
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The XAxis object from which to copy</param>
		Public Sub New(rhs As Legend)
			m_rect = rhs.Rect
			m_location = rhs.Location
			m_isFramed = rhs.isFramed
			m_isFilled = rhs.isFilled
			m_isHStack = rhs.IsHStack
			m_isVisible = rhs.IsVisible
			m_fillColor = rhs.FillColor
			m_frameColor = rhs.FrameColor
			m_frameWidth = rhs.FrameWidth

			m_fontSpec = New FontSpecs(rhs.FontSpec)
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the Legend</returns>
		Public Function Clone() As Object
			Return New Legend(Me)
		End Function

		''' <summary>
		''' Get the bounding rectangle for the <see cref="Legend"/> in screen coordinates
		''' </summary>
		''' <value>A screen rectangle in pixel units</value>
		Public ReadOnly Property Rect() As RectangleF
			Get
				Return m_rect
			End Get
		End Property
		''' <summary>
		''' Access the <see cref="ZedGraph.FontSpec"/> class used to render
		''' the <see cref="Legend"/> entries
		''' </summary>
		''' <value>A reference to a <see cref="Legend"/> object</value>
		Public ReadOnly Property FontSpec() As FontSpecs
			Get
				Return m_fontSpec
			End Get
		End Property
		''' <summary>
		''' Gets or sets a property that shows or hides the <see cref="Legend"/> entirely
		''' </summary>
		''' <value> true to show the <see cref="Legend"/>, false to hide it </value>
		Public Property IsVisible() As Boolean
			Get
				Return m_isVisible
			End Get
			Set
				m_isVisible = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets a property that makes the <see cref="Legend"/> background
		''' either filled with a specified color (<see cref="FillColor"/>)
		''' or transparent
		''' </summary>
		''' <value> true to fill the <see cref="Legend"/> background with a color,
		''' false to leave the background transparent</value>
		Public Property IsFilled() As Boolean
			Get
				Return m_isFilled
			End Get
			Set
				m_isFilled = value
			End Set
		End Property
		''' <summary>
		''' Set to true to display a frame around the text using the
		''' <see cref="FrameColor"/> color and <see cref="FrameWidth"/>
		''' pen width, or false for no frame
		''' </summary>
		Public Property IsFramed() As Boolean
			Get
				Return m_isFramed
			End Get
			Set
				m_isFramed = value
			End Set
		End Property
		''' <summary>
		''' The pen width used for drawing the frame around the text
		''' </summary>
		''' <value>A pen width in pixel units</value>
		Public Property FrameWidth() As Single
			Get
				Return m_frameWidth
			End Get
			Set
				m_frameWidth = value
			End Set
		End Property
		''' <summary>
		''' Sets or gets the color of the frame around the <see cref="Legend"/>.  This
		''' frame is turned on or off using the <see cref="IsFramed"/>
		''' property and the pen width is specified with the
		''' <see cref="FrameWidth"/> property
		''' </summary>
		''' <value>A system <see cref="System.Drawing.Color"/> specification.</value>
		Public Property FrameColor() As Color
			Get
				Return m_frameColor
			End Get
			Set
				m_frameColor = value
			End Set
		End Property
		''' <summary>
		''' Sets or gets the color of the background behind the <see cref="Legend"/>.
		''' This background fill option is turned on or off using the
		''' <see cref="IsFilled"/> property.
		''' </summary>
		''' <value>A system <see cref="System.Drawing.Color"/> specification.</value>
		Public Property FillColor() As Color
			Get
				Return m_fillColor
			End Get
			Set
				m_fillColor = value
			End Set
		End Property
		''' <summary>
		''' Sets or gets a property that allows the <see cref="Legend"/> items to
		''' stack horizontally in addition to the vertical stacking
		''' </summary>
		''' <value>true to allow horizontal stacking, false otherwise
		''' </value>
		Public Property IsHStack() As Boolean
			Get
				Return m_isHStack
			End Get
			Set
				m_isHStack = value
			End Set
		End Property
		''' <summary>
		''' Sets or gets the location of the <see cref="Legend"/> on the
		''' <see cref="AldysPane"/> using the <see cref="LegendLoc"/> enum type
		''' </summary>
		Public Property Location() As LegendLoc
			Get
				Return m_location
			End Get
			Set
				m_location = value
			End Set
		End Property

		''' <summary>
		''' Render the <see cref="Legend"/> to the specified <see cref="Graphics"/> device
		''' This method is normally only called by the Draw method
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
		''' <param name="hStack">The number of columns (horizontal stacking) to be used
		''' for drawing the legend</param>
		''' <param name="legendWidth">The width of each column in the legend</param>
		Public Sub Draw(g As Graphics, pane As AldysPane, scaleFactor As Double, hStack As Integer, legendWidth As Single)
			' if the legend is not visible, do nothing
			If Not Me.m_isVisible Then
				Return
			End If

			' Fill the background with the specified color if required
			If Me.m_isFilled Then
				Dim brush As New SolidBrush(Me.m_fillColor)
				g.FillRectangle(brush, Me.m_rect)
			End If

			' Set up some scaled dimensions for calculating sizes and locations
			Dim charHeight As Single = Me.FontSpec.GetHeight(scaleFactor), halfCharHeight As Single = charHeight / 2F
			Dim charWidth As Single = Me.FontSpec.GetWidth(g, scaleFactor)
			Dim gap As Single = pane.ScaledGap(scaleFactor)

			Dim iEntry As Integer = 0
			Dim x As Single, y As Single

			' Get a brush for the legend label text
			Dim brushB As New SolidBrush(Color.Black)

			' Loop for each curve in the CurveList collection
			For Each curve As CurveItem In pane.CurveList
				' Calculate the x,y (TopLeft) location of the current
				' curve legend label
				' assuming:
				'  charHeight/2 for the left margin, plus legendWidth for each
				'    horizontal column
				'  charHeight is the line spacing, with no extra margin above
				If curve.Label.ToString() <> "" Then
					x = Me.m_rect.Left + halfCharHeight + (iEntry Mod hStack) * legendWidth
					y = Me.m_rect.Top + DirectCast(iEntry / hStack, Integer) * charHeight
					' Draw the legend label for the current curve
					Me.FontSpec.Draw(g, curve.Label, x + 2.5F * charHeight, y, FontAlignH.Left, FontAlignV.Top, _
						scaleFactor)

					' Draw a sample curve to the left of the label text
					curve.Line.Draw(g, x, y + charHeight / 2, x + 2 * charHeight, y + halfCharHeight)
					' Draw a sample symbol to the left of the label text				
					curve.Symbol.Draw(g, x + charHeight, y + halfCharHeight, scaleFactor)

					' maintain a curve count for positioning
					System.Math.Max(System.Threading.Interlocked.Increment(iEntry),iEntry - 1)
				End If
			Next


			' Draw a frame around the legend if required
			If iEntry > 0 AndAlso Me.m_isFramed Then
				Dim pen As New Pen(Me.m_frameColor, Me.m_frameWidth)
				g.DrawRectangle(pen, Rectangle.Round(Me.m_rect))
			End If
		End Sub

		''' <summary>
		''' Calculate the <see cref="Legend"/> rectangle (see cref="Rect"/>),
		''' taking into account the number of required legend
		''' entries, and the legend drawing preferences.  Adjust the size of the
		''' <see cref="AldysPane.AxisRect"/> for the parent <see cref="AldysPane"/> to accomodate the
		''' space required by the legend.
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
		''' <param name="axisRect">
		''' The rectangle that contains the area bounded by the axes, in pixel units.
		''' <seealso cref="AldysPane.AxisRect">AxisRect</seealso>
		''' </param>
		''' <param name="hStack">The number of columns (horizontal stacking) to be used
		''' for drawing the legend</param>
		''' <param name="legendWidth">The width of each column in the legend (pixels)</param>
		Public Sub CalcRect(g As Graphics, pane As AldysPane, scaleFactor As Double, ByRef axisRect As RectangleF, ByRef hStack As Integer, ByRef legendWidth As Single)
			' Start with an empty rectangle
			Me.m_rect = Rectangle.Empty
			hStack = 1
			legendWidth = 1

			' If the legend is invisible, don't do anything
			If Not Me.m_isVisible Then
				Return
			End If

			Dim nCurve As Integer = 0
			Dim charHeight As Single = Me.FontSpec.GetHeight(scaleFactor), halfCharHeight As Single = charHeight / 2F, charWidth As Single = Me.FontSpec.GetWidth(g, scaleFactor), gap As Single = pane.ScaledGap(scaleFactor), maxWidth As Single = 0, tmpWidth As Single

			' Loop through each curve in the curve list
			' Find the maximum width of the legend labels
			For Each curve As CurveItem In pane.CurveList
				' Calculate the width of the label save the max width
				If curve.Label.ToString() = "" Then
					Continue For
				End If
				tmpWidth = Me.FontSpec.GetWidth(g, curve.Label, scaleFactor)

				If tmpWidth > maxWidth Then
					maxWidth = tmpWidth
				End If

				System.Math.Max(System.Threading.Interlocked.Increment(nCurve),nCurve - 1)
			Next

			Dim widthAvail As Single

			' Is this legend horizontally stacked?
			If Me.m_isHStack Then
				' Determine the available space for horizontal stacking
				Select Case Me.m_location
					' Never stack if the legend is to the right or left
					Case LegendLoc.Right, LegendLoc.Left
						widthAvail = 0
						Exit Select

					' for the top & bottom, the axis frame width is available
					Case LegendLoc.Top, LegendLoc.Bottom
						widthAvail = pane.AxisRect.Width
						Exit Select

					' for inside the axis area, use 1/2 of the axis frame width
					Case LegendLoc.InsideTopRight, LegendLoc.InsideTopLeft, LegendLoc.InsideBotRight, LegendLoc.InsideBotLeft
						widthAvail = pane.AxisRect.Width / 2
						Exit Select
					Case Else

						' shouldn't ever happen
						widthAvail = 0
						Exit Select
				End Select

				' width of one legend entry
				legendWidth = 3 * charHeight + maxWidth

				' Calculate the number of columns in the legend
				' Normally, the legend is:
				'     available width / ( max width of any entry + space for line&symbol )
				If maxWidth > 0 Then
					hStack = DirectCast((widthAvail - halfCharHeight) / legendWidth, Integer)
				End If

				' You can never have more columns than legend entries
				If hStack > nCurve Then
					hStack = nCurve
				End If

				' a saftey check
				If hStack = 0 Then
					hStack = 1
				End If
			Else
				legendWidth = 3.5F * charHeight + maxWidth
			End If

			' legend is:
			'   item:     space  line  space  text   space
			'   width:     wid  4*wid   wid  maxWid   wid 
			' The symbol is centered on the line
			'
			' legend begins 3 * wid to the right of the plot rect
			'
			' The height of the legend is the actual height of the lines of text
			'   (nCurve * hite) plus wid on top and wid on the bottom

			' total legend width
			Dim totLegWidth As Single = hStack * legendWidth

			' The total legend height
			Dim legHeight As Single = DirectCast(Math.Ceiling(DirectCast(nCurve, Double) / DirectCast(hStack, Double)), Single) * charHeight

			' Now calculate the legend rect based on the above determined parameters
			' Also, adjust the plotArea and axisRect to reflect the space for the legend
			If nCurve > 0 Then
				' The switch statement assigns the left and top edges, and adjusts the axisRect
				' as required.  The right and bottom edges are calculated at the bottom of the switch.
				Select Case Me.m_location
					Case LegendLoc.Right
						Me.m_rect.X = pane.PaneRect.Right - totLegWidth - gap
						Me.m_rect.Y = axisRect.Top

						axisRect.Width -= totLegWidth + halfCharHeight
						Exit Select
					Case LegendLoc.Top
						Me.m_rect.X = axisRect.Left
						Me.m_rect.Y = axisRect.Top

						axisRect.Y += legHeight + halfCharHeight
						axisRect.Height -= legHeight + halfCharHeight
						Exit Select
					Case LegendLoc.Bottom
						Me.m_rect.X = axisRect.Left
						Me.m_rect.Y = pane.PaneRect.Bottom - legHeight - gap

						axisRect.Height -= legHeight + halfCharHeight
						Exit Select
					Case LegendLoc.Left
						Me.m_rect.X = pane.PaneRect.Left + gap
						Me.m_rect.Y = axisRect.Top

						axisRect.X += totLegWidth + halfCharHeight
						axisRect.Width -= totLegWidth + halfCharHeight
						Exit Select
					Case LegendLoc.InsideTopRight
						Me.m_rect.X = axisRect.Right - totLegWidth
						Me.m_rect.Y = axisRect.Top
						Exit Select
					Case LegendLoc.InsideTopLeft
						Me.m_rect.X = axisRect.Left
						Me.m_rect.Y = axisRect.Top
						Exit Select
					Case LegendLoc.InsideBotRight
						Me.m_rect.X = axisRect.Right - totLegWidth
						Me.m_rect.Y = axisRect.Bottom - legHeight
						Exit Select
					Case LegendLoc.InsideBotLeft
						Me.m_rect.X = axisRect.Left
						Me.m_rect.Y = axisRect.Bottom - legHeight
						Exit Select
				End Select

				' Calculate the Right and Bottom edges of the rect
				Me.m_rect.Width = totLegWidth
				Me.m_rect.Height = legHeight
			End If
		End Sub
	End Class
End Namespace

