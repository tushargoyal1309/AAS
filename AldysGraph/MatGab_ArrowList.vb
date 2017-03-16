Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections

Namespace AldysGraph
	''' <summary>
	''' A collection class containing a list of <see cref="ZedGraph.ArrowItem"/> type graphic objects
	''' to be displayed on the graph.
	''' </summary>
	Public Class ArrowList
		Inherits CollectionBase
		Implements ICloneable
		''' <summary>
		''' Default constructor for the collection class
		''' </summary>
		Public Sub New()
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The ArrowList object from which to copy</param>
		Public Sub New(rhs As ArrowList)
			For Each item As ArrowItem In rhs
				Me.Add(New ArrowItem(item))
			Next
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the ArrowList</returns>
		Public Function Clone() As Object
			Return New ArrowList(Me)
		End Function

		''' <summary>
		''' Indexer to access the specified <see cref="ZedGraph.ArrowItem"/> object by its ordinal
		''' position in the list.
		''' </summary>
		''' <param name="index">The ordinal position (zero-based) of the
		''' <see cref="ZedGraph.ArrowItem"/> object to be accessed.</param>
		''' <value>An <see cref="ZedGraph.ArrowItem"/> object reference.</value>
		Public Default Property Item(index As Integer) As ArrowItem
			Get
				Return DirectCast(List(index), ArrowItem)
			End Get
			Set
				List(index) = value
			End Set
		End Property

		''' <summary>
		''' Add an <see cref="ArrowItem"/> object to the collection at the end of the list.
		''' </summary>
		''' <param name="item">A reference to the <see cref="ArrowItem"/> object to
		''' be added</param>
		Public Sub Add(item As ArrowItem)
			List.Add(item)
		End Sub

		''' <summary>
		''' Remove an <see cref="ArrowItem"/> object from the collection at the
		''' specified ordinal location.
		''' </summary>
		''' <param name="index">An ordinal position in the list at which
		''' the object to be removed is located. </param>
		Public Sub Remove(index As Integer)
			List.RemoveAt(index)
		End Sub

		''' <summary>
		''' Render all objects to the specified <see cref="Graphics"/> device
		''' by calling the Draw method of each <see cref="ArrowItem"/> object in
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
			For Each item As ArrowItem In Me
				item.Draw(g, pane, scaleFactor)
			Next
		End Sub
	End Class

	''' <summary>
	''' A class that represents a graphic arrow or line object on the graph.  A list of
	''' ArrowItem objects is maintained by the <see cref="ArrowList"/> collection class.
	''' </summary>
	Public Class ArrowItem
		Implements ICloneable
		''' <summary>
		''' Private field that stores the X location of the starting point
		''' that defines the arrow segment.  Use the public property
		''' <see cref="X1"/> to access this value.
		''' </summary>
		''' <value>The units are defined as per the <see cref="coordinateFrame"/> setting</value>
		Private m_x1 As Single
		''' <summary>
		''' Private field that stores the Y location of the starting point
		''' that defines the arrow segment.  Use the public property
		''' <see cref="Y1"/> to access this value.
		''' </summary>
		''' <value>The units are defined as per the <see cref="coordinateFrame"/> setting</value>
		Private m_y1 As Single
		''' <summary>
		''' Private field that stores the X location of the ending point
		''' that defines the arrow segment.  Use the public property
		''' <see cref="X2"/> to access this value.
		''' </summary>
		''' <value>The units are defined as per the <see cref="coordinateFrame"/> setting</value>
		Private m_x2 As Single
		''' <summary>
		''' Private field that stores the Y location of the ending point
		''' that defines the arrow segment.  Use the public property
		''' <see cref="Y2"/> to access this value.
		''' </summary>
		''' <value>The units are defined as per the <see cref="coordinateFrame"/> setting</value>
		Private m_y2 As Single

		''' <summary>
		''' Private field that stores the arrowhead size, measured in points.
		''' Use the public property <see cref="Size"/> to access this value.
		''' </summary>
		Private m_size As Single
		''' <summary>
		''' Private field that stores the color of the arrow.
		''' Use the public property <see cref="Color"/> to access this value.
		''' </summary>
		''' <value>The color value is declared with a <see cref="System.Drawing.Color"/>
		''' specification</value>
		Private m_color As Color
		''' <summary>
		''' Private field that stores the width of the pen for drawing the line
		''' segment of the arrow.
		''' Use the public property <see cref="PenWidth"/> to access this value.
		''' </summary>
		''' <value> The width is defined in pixel units </value>
		Private m_penWidth As Single
		''' <summary>
		''' Private boolean field that stores the arrowhead state.
		''' Use the public property <see cref="IsArrowHead"/> to access this value.
		''' </summary>
		''' <value> true if an arrowhead is to be drawn, false otherwise </value>
		Private m_isArrowHead As Boolean
		''' <summary>
		''' Private field that stores the coordinate system to be used for
		''' defining the <see cref="ArrowItem"/> position.  Use the public
		''' property <see cref="CoordinateFrame"/> to access this value.
		''' </summary>
		''' <value> The coordinate system is defined with the <see cref="CoordType"/>
		''' enum</value>
		Private m_coordinateFrame As CoordType

		''' <overloads>Constructors for the <see cref="ArrowItem"/> object</overloads>
		''' <summary>
		''' A constructor that allows the position, color, and size of the
		''' <see cref="ArrowItem"/> to be pre-specified.
		''' </summary>
		''' <param name="color">An arbitrary <see cref="System.Drawing.Color"/> specification
		''' for the arrow</param>
		''' <param name="size">The size of the arrowhead, measured in points.</param>
		''' <param name="x1">The x position of the starting point that defines the
		''' arrow.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		''' <param name="y1">The y position of the starting point that defines the
		''' arrow.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		''' <param name="x2">The x position of the ending point that defines the
		''' arrow.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		''' <param name="y2">The y position of the ending point that defines the
		''' arrow.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		Public Sub New(color As Color, size As Single, x1 As Single, y1 As Single, x2 As Single, y2 As Single)
			Init()
			Me.m_color = color
			Me.m_size = size
			Me.m_x1 = x1
			Me.m_y1 = y1
			Me.m_x2 = x2
			Me.m_y2 = y2
		End Sub

		''' <summary>
		''' A constructor that allows only the position of the
		''' arrow to be pre-specified.  All other properties are set to
		''' default values
		''' </summary>
		''' <param name="x1">The x position of the starting point that defines the
		''' <see cref="ArrowItem"/>.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		''' <param name="y1">The y position of the starting point that defines the
		''' <see cref="ArrowItem"/>.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		''' <param name="x2">The x position of the ending point that defines the
		''' <see cref="ArrowItem"/>.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		''' <param name="y2">The y position of the ending point that defines the
		''' <see cref="ArrowItem"/>.  The units of this position are specified by the
		''' <see cref="CoordinateFrame"/> property.</param>
		Public Sub New(x1 As Single, y1 As Single, x2 As Single, y2 As Single)
			Init()
			Me.m_x1 = x1
			Me.m_y1 = y1
			Me.m_x2 = x2
			Me.m_y2 = y2
		End Sub

		''' <summary>
		''' This method initializes the ArrowItem properties to default values
		''' as defined in class <see cref="Def"/>
		''' </summary>
		Protected Sub Init()
			Me.m_color = Defaults.Arrow.Color
			Me.m_size = Defaults.Arrow.Size
			Me.m_penWidth = Defaults.Arrow.PenWidth
			Me.m_x1 = 0F
			Me.m_y1 = 0F
			Me.m_x2 = 0.2F
			Me.m_y2 = 0.2F
			m_isArrowHead = Defaults.Arrow.IsArrowHead
			m_coordinateFrame = Defaults.Arrow.CoordFrame
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The ArrowItem object from which to copy</param>
		Public Sub New(rhs As ArrowItem)
			m_x1 = rhs.X1
			m_y1 = rhs.Y1
			m_x2 = rhs.X2
			m_y2 = rhs.Y2
			m_size = rhs.Size
			m_color = rhs.Color
			m_penWidth = rhs.PenWidth
			m_isArrowHead = rhs.IsArrowHead
			m_coordinateFrame = rhs.CoordinateFrame
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the ArrowItem</returns>
		Public Function Clone() As Object
			Return New ArrowItem(Me)
		End Function

		''' <summary>
		''' X1 is the X value of the starting point that defines the
		''' <see cref="ArrowItem"/> segment </summary>
		''' <value> The units are defined by the <see cref="CoordinateFrame"/>
		''' property </value>
		Public Property X1() As Single
			Get
				Return m_x1
			End Get
			Set
				m_x1 = value
			End Set
		End Property
		''' <summary>
		''' X2 is the X value of the ending point that defines the
		''' <see cref="ArrowItem"/> segment </summary>
		''' <value> The units are defined by the <see cref="CoordinateFrame"/>
		''' property </value>
		Public Property X2() As Single
			Get
				Return m_x2
			End Get
			Set
				m_x2 = value
			End Set
		End Property
		''' <summary>
		''' Y1 is the Y value of the starting point that defines the
		''' <see cref="ArrowItem"/> segment </summary>
		''' <value> The units are defined by the <see cref="CoordinateFrame"/>
		''' property </value>
		Public Property Y1() As Single
			Get
				Return m_y1
			End Get
			Set
				m_y1 = value
			End Set
		End Property
		''' <summary>
		''' Y2 is the Y value of the ending point that defines the
		''' <see cref="ArrowItem"/> segment </summary>
		''' <value> The units are defined by the <see cref="CoordinateFrame"/>
		''' property </value>
		Public Property Y2() As Single
			Get
				Return m_y2
			End Get
			Set
				m_y2 = value
			End Set
		End Property
		''' <summary>
		''' The size of the arrowhead.  The display of the arrowhead can be
		''' enabled or disabled with the <see cref="IsArrowHead"/> property.
		''' </summary>
		''' <value> The size is defined in pixel units </value>
		Public Property Size() As Single
			Get
				Return m_size
			End Get
			Set
				m_size = value
			End Set
		End Property
		''' <summary>
		''' The width of the line segment for the <see cref="ArrowItem"/>
		''' </summary>
		''' <value> The width is defined in pixel units </value>
		Public Property PenWidth() As Single
			Get
				Return m_penWidth
			End Get
			Set
				m_penWidth = value
			End Set
		End Property
		''' <summary>
		''' The <see cref="System.Drawing.Color"/> of the arrowhead and line segment
		''' </summary>
		''' <value> The color is defined using the
		''' <see cref="System.Drawing.Color"/> class </value>
		Public Property Color() As Color
			Get
				Return m_color
			End Get
			Set
				m_color = value
			End Set
		End Property
		''' <summary>
		''' The coordinate system to be used for defining the <see cref="ArrowItem"/> position
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
		''' <summary>
		''' Determines whether or not to draw an arrowhead
		''' </summary>
		''' <value> true to show the arrowhead, false to show the line segment
		''' only</value>
		Public Property IsArrowHead() As Boolean
			Get
				Return m_isArrowHead
			End Get
			Set
				m_isArrowHead = value
			End Set
		End Property

		''' <summary>
		''' Render this object to the specified <see cref="Graphics"/> device
		''' This method is normally only called by the Draw method
		''' of the parent <see cref="ArrowList"/> collection object.
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
			' Convert the arrow coordinates from the user coordinate system
			' to the screen coordinate system
			Dim pix1 As PointF = pane.GeneralTransform(New PointF(Me.m_x1, Me.m_y1), Me.m_coordinateFrame)
			Dim pix2 As PointF = pane.GeneralTransform(New PointF(Me.m_x2, Me.m_y2), Me.m_coordinateFrame)

			If pix1.X > -10000 AndAlso pix1.X < 100000 AndAlso pix1.Y > -100000 AndAlso pix1.Y < 100000 AndAlso pix2.X > -10000 AndAlso pix2.X < 100000 AndAlso pix2.Y > -100000 AndAlso pix2.Y < 100000 Then
				' get a scaled size for the arrowhead
				Dim scaledSize As Single = DirectCast(Me.m_size * scaleFactor, Single)

				' calculate the length and the angle of the arrow "vector"
				Dim dy As Double = pix2.Y - pix1.Y
				Dim dx As Double = pix2.X - pix1.X
				Dim angle As Single = DirectCast(Math.Atan2(dy, dx), Single) * 180F / DirectCast(Math.PI, Single)
				Dim length As Single = DirectCast(Math.Sqrt(dx * dx + dy * dy), Single)

				' Save the old transform matrix
				Dim transform As Matrix = g.Transform
				' Move the coordinate system so it is located at the starting point
				' of this arrow
				g.TranslateTransform(pix1.X, pix1.Y)
				' Rotate the coordinate system according to the angle of this arrow
				' about the starting point
				g.RotateTransform(angle)

				' get a pen according to this arrow properties
				Dim pen As New Pen(Me.m_color, Me.m_penWidth)

				' Draw the line segment for this arrow
				g.DrawLine(pen, 0, 0, length, 0)

				' Only show the arrowhead if required
				If Me.m_isArrowHead Then
					Dim brush As New SolidBrush(Me.m_color)

					' Create a polygon representing the arrowhead based on the scaled
					' size
					Dim polyPt As PointF() = New PointF(3) {}
					Dim hsize As Single = scaledSize / 3F
					polyPt(0).X = length
					polyPt(0).Y = 0
					polyPt(1).X = length - m_size
					polyPt(1).Y = hsize
					polyPt(2).X = length - m_size
					polyPt(2).Y = -hsize
					polyPt(3) = polyPt(0)

					' render the arrowhead
					g.FillPolygon(brush, polyPt)
				End If

				' Restore the transform matrix back to its original state
				g.Transform = transform
			End If
		End Sub
	End Class
End Namespace
