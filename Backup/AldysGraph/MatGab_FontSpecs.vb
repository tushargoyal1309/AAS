Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace AldysGraph
	''' <summary>
	''' Summary description for FontSpecs.
	''' </summary>
	Public Class FontSpecs
		Implements ICloneable
				'
				' TODO: Add constructor logic here
				'
		Public Sub New()
		End Sub


		''' <summary>
		''' Private field that stores the color of the font characters for this
		''' <see cref="FontSpec"/>.  Use the public property <see cref="FontColor"/>
		''' to access this value.
		''' </summary>
		''' <value>A system <see cref="System.Drawing.Color"/> reference.</value>
		Private m_fontColor As Color
		''' <summary>
		''' Private field that stores the font family name for this <see cref="FontSpec"/>.
		''' Use the public property <see cref="Family"/> to access this value.
		''' </summary>
		''' <value>A text string with the font family name, e.g., "Arial"</value>
		Private m_family As String
		''' <summary>
		''' Private field that determines whether this <see cref="FontSpec"/> is
		''' drawn with bold typeface.
		''' Use the public property <see cref="IsBold"/> to access this value.
		''' </summary>
		''' <value>A boolean value, true for bold, false for normal</value>
		Private m_isBold As Boolean
		''' <summary>
		''' Private field that determines whether this <see cref="FontSpec"/> is
		''' drawn with italic typeface.
		''' Use the public property <see cref="IsItalic"/> to access this value.
		''' </summary>
		''' <value>A boolean value, true for italic, false for normal</value>
		Private m_isItalic As Boolean
		''' <summary>
		''' Private field that determines whether this <see cref="FontSpec"/> is
		''' drawn with underlined typeface.
		''' Use the public property <see cref="IsUnderline"/> to access this value.
		''' </summary>
		''' <value>A boolean value, true for underline, false for normal</value>
		Private m_isUnderline As Boolean
		''' <summary>
		''' Private field that determines whether this <see cref="FontSpec"/> is
		''' drawn with filled background.
		''' Use the public property <see cref="IsFilled"/> to access this value.
		''' </summary>
		''' <value>A boolean value, true for a color-filled background,
		''' false for transparent background</value>
		Private m_isFilled As Boolean
		''' <summary>
		''' Private field that determines the background fill color for this
		''' <see cref="FontSpec"/>.  This color is only used if
		''' <see cref="isFilled"/> is true.
		''' Use the public property <see cref="FillColor"/> to access this value.
		''' </summary>
		''' <value>A <see cref="System.Drawing.Color"/> value</value>
		Private m_fillColor As Color
		''' <summary>
		''' Private field that determines whether this <see cref="FontSpec"/> is
		''' drawn with a frame around it.
		''' Use the public property <see cref="IsFramed"/> to access this value.
		''' </summary>
		''' <value>A boolean value, true for a frame,
		''' false for no frame</value>
		Private m_isFramed As Boolean
		''' <summary>
		''' Private field that determines the frame color for this
		''' <see cref="FontSpec"/>.  This color is only used if
		''' <see cref="isFramed"/> is true.
		''' Use the public property <see cref="FrameColor"/> to access this value.
		''' </summary>
		''' <value>A <see cref="System.Drawing.Color"/> value</value>
		Private m_frameColor As Color
		''' <summary>
		''' Private field that determines the width of the frame for this
		''' <see cref="FontSpec"/>.  This width is only used if
		''' <see cref="isFramed"/> is true.
		''' Use the public property <see cref="FrameWidth"/> to access this value.
		''' </summary>
		''' <value>The width of the frame, in pixel units</value>
		Private m_frameWidth As Single

		''' <summary>
		''' Private field that determines the angle at which this
		''' <see cref="FontSpec"/> object is drawn.  Use the public property
		''' <see cref="Angle"/> to access this value.
		''' </summary>
		''' <value>The angle of the font, measured in anti-clockwise degrees from
		''' horizontal.  Negative values are permitted.</value>
		Private m_angle As Single
		''' <summary>
		''' Private field that determines the size of the font for this
		''' <see cref="FontSpec"/> object.  Use the public property
		''' <see cref="Size"/> to access this value.
		''' </summary>
		''' <value>The size of the font, measured in points (1/72 inch).</value>
		Private m_size As Single

		''' <summary>
		''' Private field that stores a reference to the <see cref="Font"/>
		''' object for this <see cref="FontSpec"/>.  This font object will be at
		''' the actual drawn size <see cref="scaledSize"/> according to the current
		''' size of the <see cref="AldysPane"/>.  Use the public method
		''' <see cref="GetFont"/> to access this font object.
		''' </summary>
		''' <value>A reference to a <see cref="Font"/> object</value>
		Private font As Font
		''' <summary>
		''' Private field that temporarily stores the scaled size of the font for this
		''' <see cref="FontSpec"/> object.  This represents the actual on-screen
		''' size, rather than the <see cref="Size"/> that represents the reference
		''' size for a "full-sized" <see cref="AldysPane"/>.
		''' </summary>
		''' <value>The size of the font, measured in points (1/72 inch).</value>
		Private scaledSize As Single

		''' <summary>
		''' Construct a <see cref="FontSpec"/> object with the given properties.  All other properties
		''' are defaulted according to the values specified in the <see cref="Def"/>
		''' default class.
		''' </summary>
		''' <param name="family">A text string representing the font family
		''' (default is "Arial")</param>
		''' <param name="size">A size of the font in points.  This size will be scaled
		''' based on the ratio of the <see cref="AldysPane.PaneRect"/> dimension to the
		''' <see cref="AldysPane.BaseDimension"/> of the <see cref="AldysPane"/> object. </param>
		''' <param name="color">The color with which to render the font</param>
		''' <param name="isBold">true for a bold typeface, false otherwise</param>
		''' <param name="isItalic">true for an italic typeface, false otherwise</param>
		''' <param name="isUnderline">true for an underlined font, false otherwise</param>
		Public Sub New(family As String, size As Single, color__1 As Color, isBold As Boolean, isItalic As Boolean, isUnderline As Boolean)
			Me.m_fontColor = color__1
			Me.m_family = family
			Me.m_isBold = isBold
			Me.m_isItalic = isItalic
			Me.m_isUnderline = isUnderline
			Me.m_size = size
			Me.scaledSize = -1
			Me.m_angle = 0F

			Me.m_isFilled = True
			Me.m_fillColor = Color.White
			Me.m_isFramed = True
			Me.m_frameColor = Color.Black
			Me.m_frameWidth = 1F

			Remake(1.0)
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The FontSpec object from which to copy</param>
		Public Sub New(rhs As FontSpecs)
			m_fontColor = rhs.FontColor
			m_family = rhs.Family
			m_isBold = rhs.IsBold
			m_isItalic = rhs.IsItalic
			m_isUnderline = rhs.IsUnderline
			m_isFilled = rhs.IsFilled
			m_fillColor = rhs.FillColor
			m_isFramed = rhs.IsFramed
			m_frameColor = rhs.FrameColor
			m_frameWidth = rhs.FrameWidth

			m_angle = rhs.Angle
			m_size = rhs.Size

			scaledSize = rhs.scaledSize
			Remake(1F)
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the FontSpec</returns>
		Public Function Clone() As Object
			Return New FontSpecs(Me)
		End Function

		''' <summary>
		''' The color of the font characters for this <see cref="FontSpec"/>.
		''' Note that the frame and background
		''' colors are set using the <see cref="FrameColor"/> and
		''' <see cref="FillColor"/> properties, respectively.
		''' </summary>
		''' <value>A system <see cref="System.Drawing.Color"/> reference.</value>
		Public Property FontColor() As Color
			Get
				Return m_fontColor
			End Get
			Set
				m_fontColor = value
			End Set
		End Property
		''' <summary>
		''' The font family name for this <see cref="FontSpec"/>.
		''' </summary>
		''' <value>A text string with the font family name, e.g., "Arial"</value>
		Public Property Family() As String
			Get
				Return m_family
			End Get
			Set
				If value <> m_family Then
					m_family = value
					Remake(DirectCast(scaledSize, Double) / m_size)
				End If
			End Set
		End Property
		''' <summary>
		''' Determines whether this <see cref="FontSpec"/> is
		''' drawn with bold typeface.
		''' </summary>
		''' <value>A boolean value, true for bold, false for normal</value>
		Public Property IsBold() As Boolean
			Get
				Return m_isBold
			End Get
			Set
				If value <> m_isBold Then
					m_isBold = value
					Remake(DirectCast(scaledSize, Double) / m_size)
				End If
			End Set
		End Property
		''' <summary>
		''' Determines whether this <see cref="FontSpec"/> is
		''' drawn with italic typeface.
		''' </summary>
		''' <value>A boolean value, true for italic, false for normal</value>
		Public Property IsItalic() As Boolean
			Get
				Return m_isItalic
			End Get
			Set
				If value <> m_isItalic Then
					m_isItalic = value
					Remake(DirectCast(scaledSize, Double) / m_size)
				End If
			End Set
		End Property
		''' <summary>
		''' Determines whether this <see cref="FontSpec"/> is
		''' drawn with underlined typeface.
		''' </summary>
		''' <value>A boolean value, true for underline, false for normal</value>
		Public Property IsUnderline() As Boolean
			Get
				Return m_isUnderline
			End Get
			Set
				If value <> m_isUnderline Then
					m_isUnderline = value
					Remake(DirectCast(scaledSize, Double) / m_size)
				End If
			End Set
		End Property
		''' <summary>
		''' The angle at which this <see cref="FontSpec"/> object is drawn.
		''' </summary>
		''' <value>The angle of the font, measured in anti-clockwise degrees from
		''' horizontal.  Negative values are permitted.</value>
		Public Property Angle() As Single
			Get
				Return m_angle
			End Get
			Set
				m_angle = value
			End Set
		End Property
		''' <summary>
		''' The size of the font for this <see cref="FontSpec"/> object.
		''' </summary>
		''' <value>The size of the font, measured in points (1/72 inch).</value>
		Public Property Size() As Single
			Get
				Return m_size
			End Get
			Set
				If value <> m_size Then
					Remake(DirectCast(scaledSize, Double) / m_size * value)
					m_size = value
				End If
			End Set
		End Property
		''' <summary>
		''' The pen width used for drawing the frame around this
		''' <see cref="FontSpec"/>.  This width is only used if
		''' <see cref="IsFramed"/> is true.
		''' </summary>
		''' <value>The width of the frame, in pixel units</value>
		Public Property FrameWidth() As Single
			Get
				Return m_frameWidth
			End Get
			Set
				m_frameWidth = value
			End Set
		End Property
		''' <summary>
		''' Determines whether or not to display a frame around the text using the
		''' <see cref="FrameColor"/> color and <see cref="FrameWidth"/>
		''' pen width
		''' </summary>
		''' <value>A boolean value, true for a frame,
		''' false for no frame</value>
		Public Property IsFramed() As Boolean
			Get
				Return m_isFramed
			End Get
			Set
				m_isFramed = value
			End Set
		End Property
		''' <summary>
		''' Determines whether or not the area behind the text of this
		''' <see cref="FontSpec"/> is filled using the
		''' <see cref="FillColor"/> color.
		''' </summary>
		''' <value>A boolean value, true for a color-filled background,
		''' false for transparent background</value>
		Public Property IsFilled() As Boolean
			Get
				Return m_isFilled
			End Get
			Set
				m_isFilled = value
			End Set
		End Property
		''' <summary>
		''' Sets or gets the color of the frame around the text.  This
		''' frame is turned on or off using the <see cref="IsFramed"/>
		''' property and the pen width is specified with the
		''' <see cref="FrameWidth"/> property
		''' </summary>
		''' <value>A system <see cref="System.Drawing.Color"/> reference.</value>
		Public Property FrameColor() As Color
			Get
				Return m_frameColor
			End Get
			Set
				m_frameColor = value
			End Set
		End Property
		''' <summary>
		''' Sets or gets the color of the background behind the text.
		''' This background fill option is turned on or off using the
		''' <see cref="IsFilled"/> property.
		''' </summary>
		''' <value>A system <see cref="System.Drawing.Color"/> reference.</value>
		Public Property FillColor() As Color
			Get
				Return m_fillColor
			End Get
			Set
				m_fillColor = value
			End Set
		End Property


		''' <summary>
		''' Recreate the font based on a new scaled size.  The font
		''' will only be recreated if the scaled size has changed by
		''' at least 0.1 points.
		''' </summary>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		Private Sub Remake(scaleFactor As Double)
			Dim newSize As Single = DirectCast(Me.m_size * scaleFactor, Single)

			' Regenerate the font only if the size has changed significantly
			If Math.Abs(newSize - Me.scaledSize) > 0.1 Then
				Dim style As FontStyle = FontStyle.Regular
				style = (If(Me.m_isBold, FontStyle.Bold, style)) Or (If(Me.m_isItalic, FontStyle.Italic, style)) Or (If(Me.m_isUnderline, FontStyle.Underline, style))

				Me.scaledSize = m_size * DirectCast(scaleFactor, Single)
				Me.font = New Font(Me.m_family, Me.scaledSize, style)
			End If
		End Sub

		''' <summary>
		''' Get the <see cref="Font"/> class for the current scaled font.
		''' </summary>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>Returns a reference to a <see cref="Font"/> object
		''' with a size of <see cref="scaledSize"/>, and font <see cref="Family"/>.
		''' </returns>
		Public Function GetFont(scaleFactor As Double) As Font
			Remake(scaleFactor)
			Return Me.font
		End Function

		''' <summary>
		''' Render the specified <paramref name="text"/> to the specifed
		''' <see cref="Graphics"/> device.  The text, frame, and fill options
		''' will be rendered as required.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="text">A string value containing the text to be
		''' displayed.  This can be multiple lines, separated by newline ('\n')
		''' characters</param>
		''' <param name="x">The X location to display the text, in screen
		''' coordinates, relative to the horizontal (<see cref="FontAlignH"/>)
		''' alignment parameter <paramref name="alignH"/></param>
		''' <param name="y">The Y location to display the text, in screen
		''' coordinates, relative to the vertical (<see cref="FontAlignV"/>
		''' alignment parameter <paramref name="alignV"/></param>
		''' <param name="alignH">A horizontal alignment parameter specified
		''' using the <see cref="FontAlignH"/> enum type</param>
		''' <param name="alignV">A vertical alignment parameter specified
		''' using the <see cref="FontAlignV"/> enum type</param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		Public Sub Draw(g As Graphics, text As String, x As Single, y As Single, alignH As FontAlignH, alignV As FontAlignV, _
			scaleFactor As Double)
			' make sure the font size is properly scaled
			Remake(scaleFactor)

			' Get the width and height of the text
			Dim sizeF As SizeF = g.MeasureString(text, Me.font)

			' Save the old transform matrix for later restoration
			Dim matrix As Matrix = g.Transform

			' Move the coordinate system to local coordinates
			' of this text object (that is, at the specified
			' x,y location)
			g.TranslateTransform(x, y)

			' Since the text will be drawn by g.DrawString()
			' assuming the location is the TopCenter
			' (the Font is aligned using StringFormat to the
			' center so multi-line text is center justified),
			' shift the coordinate system so that we are
			' actually aligned per the caller specified position
			If alignH = FontAlignH.Left Then
				x = sizeF.Width / 2F
			ElseIf alignH = FontAlignH.Right Then
				x = -sizeF.Width / 2F
			Else
				x = 0F
			End If

			If alignV = FontAlignV.Center Then
				y = -sizeF.Height / 2F
			ElseIf alignV = FontAlignV.Bottom Then
				y = -sizeF.Height
			Else
				y = 0F
			End If

			' Rotate the coordinate system according to the 
			' specified angle of the FontSpec
			If m_angle <> 0F Then
				g.RotateTransform(-m_angle)
			End If

			' Shift the coordinates to accomodate the alignment
			' parameters
			g.TranslateTransform(x, y)

			' make a solid brush for rendering the font itself
			Dim brush As New SolidBrush(Me.m_fontColor)

			' make a center justified StringFormat alignment
			' for drawing the text
			Dim strFormat As New StringFormat()
			strFormat.Alignment = StringAlignment.Center

			' Create a rectangle representing the frame around the
			' text.  Note that, while the text is drawn based on the
			' TopCenter position, the rectangle is drawn based on
			' the TopLeft position.  Therefore, move the rectangle
			' width/2 to the left to align it properly
			Dim rectF As New RectangleF(-sizeF.Width / 2F, 0F, sizeF.Width, sizeF.Height)

			' If the background is to be filled, fill it
			If m_isFilled Then
				Dim fillBrush As New SolidBrush(Me.m_fillColor)
				g.FillRectangle(fillBrush, rectF)
			End If

			' Draw the frame around the text if required
			If m_isFramed Then
				Dim pen As New Pen(Me.m_frameColor, Me.m_frameWidth)
				g.DrawRectangle(pen, Rectangle.Round(rectF))
			End If

			' Draw the actual text.  Note that the coordinate system
			' is set up such that 0,0 is at the location where the
			' CenterTop of the text needs to be.
			g.DrawString(text, Me.font, brush, 0F, 0F, strFormat)

			' Restore the transform matrix back to original
			g.Transform = matrix

		End Sub

		''' <summary>
		''' Get the height of the scaled font
		''' </summary>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>The scaled font height, in pixels</returns>
		Public Function GetHeight(scaleFactor As Double) As Single
			Remake(scaleFactor)
			Return Me.font.Height
		End Function
		''' <summary>
		''' Get the average character width of the scaled font.  The average width is
		''' based on the character 'x'
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>The scaled font width, in pixels</returns>
		Public Function GetWidth(g As Graphics, scaleFactor As Double) As Single
			Remake(scaleFactor)
			Return g.MeasureString("x", Me.font).Width
		End Function

		''' <summary>
		''' Get the total width of the specified text string
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="text">The text string for which the width is to be calculated
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>The scaled text width, in pixels</returns>
		Public Function GetWidth(g As Graphics, text As String, scaleFactor As Double) As Single
			Remake(scaleFactor)
			Return g.MeasureString(text, Me.font).Width
		End Function
		''' <summary>
		''' Get a <see cref="SizeF"/> struct representing the width and height
		''' of the specified text string, based on the scaled font size
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="text">The text string for which the width is to be calculated
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>The scaled text dimensions, in pixels, in the form of
		''' a <see cref="SizeF"/> struct</returns>
		Public Function MeasureString(g As Graphics, text As String, scaleFactor As Double) As SizeF
			Remake(scaleFactor)
			Return g.MeasureString(text, Me.font)
		End Function

		''' <summary>
		''' Get a <see cref="SizeF"/> struct representing the width and height
		''' of the bounding box for the specified text string, based on the scaled font size.
		''' This routine differs from <see cref="MeasureString"/> in that it takes into
		''' account the rotation angle of the font, and gives the dimensions of the
		''' bounding box that encloses the text at the specified angle.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="text">The text string for which the width is to be calculated
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>The scaled text dimensions, in pixels, in the form of
		''' a <see cref="SizeF"/> struct</returns>
		Public Function BoundingBox(g As Graphics, text As String, scaleFactor As Double) As SizeF
			Remake(scaleFactor)
			Dim s As SizeF = g.MeasureString(text, Me.font)

			Dim cs As Single = DirectCast(Math.Abs(Math.Cos(Me.m_angle * Math.PI / 180.0)), Single)
			Dim sn As Single = DirectCast(Math.Abs(Math.Sin(Me.m_angle * Math.PI / 180.0)), Single)

			Dim s2 As New SizeF(s.Width * cs + s.Height * sn, s.Width * sn + s.Height * cs)

			Return s2
		End Function



	End Class
End Namespace
