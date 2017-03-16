Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections

Namespace AldysGraph
	''' <summary>
	''' This class handles the drawing of the curve <see cref="Symbol"/> objects.
	''' The symbols are the small shapes that appear over each defined point
	''' along the curve.
	''' </summary>
	Public Class Symbol
		Implements ICloneable
		''' <summary>
		''' Private field that stores the size of this
		''' <see cref="Symbol"/> in pixels.  Use the public
		''' property <see cref="Size"/> to access this value.
		''' </summary>
		Private m_size As Single
		''' <summary>
		''' Private field that stores the <see cref="SymbolType"/> for this
		''' <see cref="Symbol"/>.  Use the public
		''' property <see cref="Type"/> to access this value.
		''' </summary>
		Private m_type As SymbolType
		''' <summary>
		''' Private field that stores the pen width for this
		''' <see cref="Symbol"/>.  Use the public
		''' property <see cref="PenWidth"/> to access this value.
		''' </summary>
		Private m_penWidth As Single
		''' <summary>
		''' Private field that stores the color of this
		''' <see cref="Symbol"/>.  Use the public
		''' property <see cref="Color"/> to access this value.
		''' </summary>
		Private m_color As Color
		''' <summary>
		''' Private field that stores the visibility of this
		''' <see cref="Symbol"/>.  Use the public
		''' property <see cref="IsVisible"/> to access this value.  If this value is
		''' false, the symbols will not be shown (but the <see cref="Line"/> may
		''' still be shown).
		''' </summary>
		Private m_isVisible As Boolean
		''' <summary>
		''' Private field that determines if the shape is filled with color for this
		''' <see cref="Symbol"/>.  Use the public
		''' property <see cref="IsFilled"/> to access this value.  If this value is
		''' false, the symbols will be drawn in outline.
		''' </summary>
		Private m_isFilled As Boolean

		''' <summary>
		''' Default constructor that sets all <see cref="Symbol"/> properties to default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		Public Sub New()
			Init()
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The Symbol object from which to copy</param>
		Public Sub New(rhs As Symbol)
			m_size = rhs.Size
			m_type = rhs.Type
			m_penWidth = rhs.PenWidth
			m_color = rhs.Color
			m_isVisible = rhs.IsVisible
			m_isFilled = rhs.IsFilled
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the Symbol</returns>
		Public Function Clone() As Object
			Return New Symbol(Me)
		End Function

		''' <summary>
		''' Initialize all <see cref="Symbol"/> properties to  default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		Protected Sub Init()
			Me.m_size = Defaults.Symbol.Size
			Me.m_type = Defaults.Symbol.Type
			Me.m_penWidth = Defaults.Symbol.PenWidth
			Me.m_color = Defaults.Symbol.Color
			Me.m_isVisible = Defaults.Symbol.IsVisible
			Me.m_isFilled = Defaults.Symbol.IsFilled
		End Sub

		''' <summary>
		''' Gets or sets the size of the <see cref="Symbol"/>
		''' </summary>
		''' <value>Size in pixels</value>
		Public Property Size() As Single
			Get
				Return m_size
			End Get
			Set
				m_size = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets the type (shape) of the <see cref="Symbol"/>
		''' </summary>
		''' <value>A <see cref="SymbolType"/> enum value indicating the shape</value>
		Public Property Type() As SymbolType
			Get
				Return m_type
			End Get
			Set
				m_type = value
			End Set
		End Property
		''' <summary>
		''' Set to true to fill in the <see cref="Symbol"/> with color, or false for
		''' a simple outline symbol.  Note that some symbols, such as
		''' <see cref="SymbolType.Plus"/> and <see cref="SymbolType.Star"/>
		''' cannot be filled in since they are not a closed shape.
		''' </summary>
		Public Property IsFilled() As Boolean
			Get
				Return m_isFilled
			End Get
			Set
				m_isFilled = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets a property that shows or hides the <see cref="Symbol"/>.
		''' </summary>
		''' <value>true to show the symbol, false to hide it</value>
		Public Property IsVisible() As Boolean
			Get
				Return m_isVisible
			End Get
			Set
				m_isVisible = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets the pen width used to draw the <see cref="Symbol"/> outline
		''' </summary>
		''' <value>Pen width in pixel units</value>
		Public Property PenWidth() As Single
			Get
				Return m_penWidth
			End Get
			Set
				m_penWidth = value
			End Set
		End Property
		''' <summary>
		''' The color of the <see cref="Symbol"/>
		''' </summary>
		Public Property Color() As Color
			Get
				Return m_color
			End Get
			Set
				m_color = value
			End Set
		End Property

		''' <summary>
		''' Draw the <see cref="Symbol"/> to the specified <see cref="Graphics"/> device
		''' at the specified location.  This routine draws a single symbol.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="x">The x position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="y">The y position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="scaleFactor">
		''' The scaling factor for the features of the graph based on the <see cref="AldysPane.BaseDimension"/>.  This
		''' scaling factor is calculated by the <see cref="AldysPane.CalcScaleFactor"/> method.  The scale factor
		''' represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' </param>		
		Public Sub Draw(g As Graphics, x As Single, y As Single, scaleFactor As Double)
			' Only draw if the symbol is visible
			If Me.m_isVisible Then
				Dim brush As New SolidBrush(Me.m_color)
				Dim pen As New Pen(Me.m_color, Me.m_penWidth)

				' Fill or draw the symbol as required
				If Me.m_isFilled Then
					FillPoint(g, x, y, scaleFactor, pen, brush)
				Else
					DrawPoint(g, x, y, scaleFactor, pen)
				End If
			End If
		End Sub



		''' <summary>
		''' Draw the <see cref="Symbol"/> to the specified <see cref="Graphics"/> device
		''' at the specified list of locations.  This routine draws a series of symbols, and
		''' is intended to provide a speed improvement over the single Draw() method.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="x">The x position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="y">The y position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="scaleFactor">
		''' The scaling factor for the features of the graph based on the <see cref="AldysPane.BaseDimension"/>.  This
		''' scaling factor is calculated by the <see cref="AldysPane.CalcScaleFactor"/> method.  The scale factor
		''' represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' </param>	

		Public Sub DrawMany(g As Graphics, x As Single(), y As Single(), scaleFactor As Double)
			' Only draw if the symbol is visible
			If Me.m_isVisible Then
				Dim brush As New SolidBrush(Me.m_color)
				Dim pen As New Pen(Me.m_color, Me.m_penWidth)
				Dim nPts As Integer = x.Length - 1
				Dim i As Integer = 0
				While i < nPts
					If x(i) <> System.[Single].MaxValue AndAlso y(i) <> System.[Single].MaxValue Then
						' Fill or draw the symbol as required
						If Me.m_isFilled Then
							FillPoint(g, x(i), y(i), scaleFactor, pen, brush)
						Else
							DrawPoint(g, x(i), y(i), scaleFactor, pen)
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
			End If
		End Sub
		Public Sub DrawManyEx(g As Graphics, pane As AldysPane, x As Single(), y As Single(), scaleFactor As Double, xY As ArrayList)
			' Only draw if the symbol is visible
			If Me.m_isVisible Then
				Dim brush As New SolidBrush(Me.m_color)
				Dim pen As New Pen(Me.m_color, Me.m_penWidth)
				Dim nPts As Integer = x.Length - 1
				Dim i As Integer = 0
				While i < nPts
					If x(i) <> System.[Single].MaxValue AndAlso y(i) <> System.[Single].MaxValue Then
						' Fill or draw the symbol as required
						If (DirectCast(xY(i), Double) >= pane.YAxis.UpperAlarmLineY) AndAlso pane.YAxis.UpperAlarmLine Then
							pen.Color = pane.YAxis.UpperAlarmLineColor
						ElseIf (DirectCast(xY(i), Double) <= pane.YAxis.LowerAlarmLineY) AndAlso pane.YAxis.LowerAlarmLine Then
							'pen.Color = pane.YAxis.LowerAlarmLineColor;
							pen.Color = Me.m_color
						Else
							pen.Color = Me.m_color
						End If
						If Me.m_isFilled Then
							FillPoint(g, x(i), y(i), scaleFactor, pen, brush)
						Else
							DrawPoint(g, x(i), y(i), scaleFactor, pen)
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
			End If
		End Sub

		Public Sub DrawMany(g As Graphics, x As Single(), y As Single(), scaleFactor As Double, cl As ArrayList, sym As ArrayList)
			' Only draw if the symbol is visible
			If Me.m_isVisible Then
				Dim brush As New SolidBrush(Me.m_color)
				Dim pen As New Pen(Me.m_color, Me.m_penWidth)
				Dim nPts As Integer = x.Length - 1
				If (cl.Count = 0) OrElse (sym.Count = 0) Then
					MessageBox.Show("Invalid Color or Symbol for each point")
					Return
				End If

				Dim i As Integer = 0
				While i < nPts
					If x(i) <> System.[Single].MaxValue AndAlso y(i) <> System.[Single].MaxValue Then
						' Fill or draw the symbol as required
						pen.Color = DirectCast(cl(i), Color)
						brush.Color = DirectCast(cl(i), Color)
						Me.m_type = DirectCast(sym(i), SymbolType)
						If Me.m_isFilled Then

							FillPoint(g, x(i), y(i), scaleFactor, pen, brush)
						Else
							DrawPoint(g, x(i), y(i), scaleFactor, pen)
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
			End If
		End Sub

		''' <summary>
		''' Draw the <see cref="Symbol"/> (outline only) to the specified <see cref="Graphics"/>
		''' device at the specified location.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="x">The x position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="y">The y position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="scaleFactor">
		''' The scaling factor for the features of the graph based on the <see cref="AldysPane.BaseDimension"/>.  This
		''' scaling factor is calculated by the <see cref="AldysPane.CalcScaleFactor"/> method.  The scale factor
		''' represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' <param name="pen">A pen with attributes of <see cref="Color"/> and
		''' <see cref="PenWidth"/> for this symbol</param>
		''' </param>

		Public Sub DrawPoint(g As Graphics, x As Single, y As Single, scaleFactor As Double, pen As Pen)
			Dim scaledSize As Single = DirectCast(Me.m_size * scaleFactor, Single)
			Dim hsize As Single = scaledSize / 2, hsize1 As Single = hsize + 1

			Select Case Me.m_type
				Case SymbolType.Square
					g.DrawLine(pen, x - hsize, y - hsize, x + hsize, y - hsize)
					g.DrawLine(pen, x + hsize, y - hsize, x + hsize, y + hsize)
					g.DrawLine(pen, x + hsize, y + hsize, x - hsize, y + hsize)
					g.DrawLine(pen, x - hsize, y + hsize, x - hsize, y - hsize)
					Exit Select
				Case SymbolType.Diamond
					g.DrawLine(pen, x, y - hsize, x + hsize, y)
					g.DrawLine(pen, x + hsize, y, x, y + hsize)
					g.DrawLine(pen, x, y + hsize, x - hsize, y)
					g.DrawLine(pen, x - hsize, y, x, y - hsize)
					Exit Select
				Case SymbolType.Triangle
					g.DrawLine(pen, x, y - hsize, x + hsize, y + hsize)
					g.DrawLine(pen, x + hsize, y + hsize, x - hsize, y + hsize)
					g.DrawLine(pen, x - hsize, y + hsize, x, y - hsize)
					Exit Select
				Case SymbolType.Circle
					g.DrawEllipse(pen, x - hsize, y - hsize, scaledSize, scaledSize)
					Exit Select
				Case SymbolType.XCross
					g.DrawLine(pen, x - hsize, y - hsize, x + hsize1, y + hsize1)
					g.DrawLine(pen, x + hsize, y - hsize, x - hsize1, y + hsize1)
					Exit Select
				Case SymbolType.Plus
					g.DrawLine(pen, x, y - hsize, x, y + hsize1)
					g.DrawLine(pen, x - hsize, y, x + hsize1, y)
					Exit Select
				Case SymbolType.Star
					g.DrawLine(pen, x, y - hsize, x, y + hsize1)
					g.DrawLine(pen, x - hsize, y, x + hsize1, y)
					g.DrawLine(pen, x - hsize, y - hsize, x + hsize1, y + hsize1)
					g.DrawLine(pen, x + hsize, y - hsize, x - hsize1, y + hsize1)
					Exit Select
				Case SymbolType.TriangleDown
					g.DrawLine(pen, x, y + hsize, x + hsize, y - hsize)
					g.DrawLine(pen, x + hsize, y - hsize, x - hsize, y - hsize)
					g.DrawLine(pen, x - hsize, y - hsize, x, y + hsize)
					Exit Select
			End Select
		End Sub

		''' <summary>
		''' Render the filled <see cref="Symbol"/> to the specified <see cref="Graphics"/>
		''' device at the specified location.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="x">The x position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="y">The y position of the center of the symbol in
		''' screen pixel units</param>
		''' <param name="scaleFactor">
		''' The scaling factor for the features of the graph based on the <see cref="AldysPane.BaseDimension"/>.  This
		''' scaling factor is calculated by the <see cref="AldysPane.CalcScaleFactor"/> method.  The scale factor
		''' represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' </param>		
		''' <param name="pen">A pen with attributes of <see cref="Color"/> and
		''' <see cref="PenWidth"/> for this symbol</param>
		''' <param name="brush">A brush with the <see cref="Color"/> attribute
		''' for this symbol</param>
		Public Sub FillPoint(g As Graphics, x As Single, y As Single, scaleFactor As Double, pen As Pen, brush As Brush)
			Dim scaledSize As Single = DirectCast(Me.m_size * scaleFactor, Single), hsize As Single = scaledSize / 2, hsize4 As Single = scaledSize / 3, hsize41 As Single = hsize4 + 1, hsize1 As Single = hsize + 1

			Dim polyPt As PointF() = New PointF(4) {}

			Select Case Me.m_type
				Case SymbolType.Square
					g.FillRectangle(brush, x - hsize, y - hsize, scaledSize, scaledSize)
					Exit Select
				Case SymbolType.Diamond
					polyPt(0).X = x
					polyPt(0).Y = y - hsize
					polyPt(1).X = x + hsize
					polyPt(1).Y = y
					polyPt(2).X = x
					polyPt(2).Y = y + hsize
					polyPt(3).X = x - hsize
					polyPt(3).Y = y
					polyPt(4) = polyPt(0)
					g.FillPolygon(brush, polyPt)
					Exit Select
				Case SymbolType.Triangle
					polyPt(0).X = x
					polyPt(0).Y = y - hsize
					polyPt(1).X = x + hsize
					polyPt(1).Y = y + hsize
					polyPt(2).X = x - hsize
					polyPt(2).Y = y + hsize
					polyPt(3) = polyPt(0)
					g.FillPolygon(brush, polyPt)
					Exit Select
				Case SymbolType.Circle
					g.FillEllipse(brush, x - hsize, y - hsize, scaledSize, scaledSize)
					Exit Select
				Case SymbolType.XCross
					g.FillRectangle(brush, x - hsize4, y - hsize4, hsize4 + hsize41, hsize4 + hsize41)
					g.DrawLine(pen, x - hsize, y - hsize, x + hsize1, y + hsize1)
					g.DrawLine(pen, x + hsize, y - hsize, x - hsize1, y + hsize1)
					Exit Select
				Case SymbolType.Plus
					g.FillRectangle(brush, x - hsize4, y - hsize4, hsize4 + hsize41, hsize4 + hsize41)
					g.DrawLine(pen, x, y - hsize, x, y + hsize1)
					g.DrawLine(pen, x - hsize, y, x + hsize1, y)
					Exit Select
				Case SymbolType.Star
					g.FillRectangle(brush, x - hsize4, y - hsize4, hsize4 + hsize41, hsize4 + hsize41)
					g.DrawLine(pen, x, y - hsize, x, y + hsize1)
					g.DrawLine(pen, x - hsize, y, x + hsize1, y)
					g.DrawLine(pen, x - hsize, y - hsize, x + hsize1, y + hsize1)
					g.DrawLine(pen, x + hsize, y - hsize, x - hsize1, y + hsize1)
					Exit Select
				Case SymbolType.TriangleDown
					polyPt(0).X = x
					polyPt(0).Y = y + hsize
					polyPt(1).X = x + hsize
					polyPt(1).Y = y - hsize
					polyPt(2).X = x - hsize
					polyPt(2).Y = y - hsize
					polyPt(3) = polyPt(0)
					g.FillPolygon(brush, polyPt)
					Exit Select
			End Select
		End Sub
	End Class
End Namespace

