Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections

Namespace AldysGraph
	''' <summary>
	''' A class representing all the characteristics of the <see cref="Line"/>
	''' segments that make up a curve on the graph.
	''' </summary>
	Public Class Line
		Implements ICloneable
		''' <summary>
		''' Private field that stores the pen width for this
		''' <see cref="Line"/>.  Use the public
		''' property <see cref="Width"/> to access this value.
		''' </summary>
		Private m_width As Single
		''' <summary>
		''' Private field that stores the <see cref="DashStyle"/> for this
		''' <see cref="Line"/>.  Use the public
		''' property <see cref="Style"/> to access this value.
		''' </summary>
		Private m_style As DashStyle
		''' <summary>
		''' Private field that stores the visibility of this
		''' <see cref="Line"/>.  Use the public
		''' property <see cref="IsVisible"/> to access this value.
		''' </summary>
		Private m_isVisible As Boolean
		''' <summary>
		''' Private field that stores the color of this
		''' <see cref="Line"/>.  Use the public
		''' property <see cref="Color"/> to access this value.  If this value is
		''' false, the line will not be shown (but the <see cref="Symbol"/> may
		''' still be shown).
		''' </summary>
		Private m_color As Color
		Private CL As ArrayList
		''' <summary>
		''' Private field that stores the <see cref="ZedGraph.StepType"/> for this
		''' <see cref="CurveItem"/>.  Use the public
		''' property <see cref="StepType"/> to access this value.
		''' </summary>
		Private m_stepType As StepType





		''' <summary>
		''' Default constructor that sets all <see cref="Line"/> properties to default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		Public Sub New()

			Me.CL = New ArrayList()
			Me.m_width = Defaults.Line.Width
			Me.m_style = Defaults.Line.Style
			Me.m_isVisible = Defaults.Line.IsVisible
			Me.m_color = Defaults.Line.Color
			Me.m_stepType = Defaults.Line.Type
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The Line object from which to copy</param>
		Public Sub New(rhs As Line)
			CL = rhs.CL
			m_width = rhs.Width
			m_style = rhs.Style
			m_isVisible = rhs.IsVisible
			m_color = rhs.Color
			m_stepType = rhs.StepType
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the Line</returns>
		Public Function Clone() As Object
			Return New Line(Me)
		End Function

		''' <summary>
		''' The color of the <see cref="Line"/>
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
		''' The style of the <see cref="Line"/>, defined as a <see cref="DashStyle"/> enum.
		''' This allows the line to be solid, dashed, or dotted.
		''' </summary>
		Public Property Style() As DashStyle
			Get
				Return m_style
			End Get
			Set
				m_style = value
			End Set
		End Property
		''' <summary>
		''' The pen width used to draw the <see cref="Line"/>, in pixel units
		''' </summary>
		Public Property Width() As Single
			Get
				Return m_width
			End Get
			Set
				m_width = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets a property that shows or hides the <see cref="Line"/>.
		''' </summary>
		''' <value>true to show the line, false to hide it</value>
		Public Property IsVisible() As Boolean
			Get
				Return m_isVisible
			End Get
			Set
				m_isVisible = value
			End Set
		End Property
		''' <summary>
		''' Determines if the <see cref="CurveItem"/> will be drawn by directly connecting the
		''' points from the <see cref="CurveItem.X"/> and <see cref="CurveItem.Y"/> data arrays,
		''' or if the curve will be a "stair-step" in which the points are
		''' connected by a series of horizontal and vertical lines that
		''' represent discrete, constant values.  Note that the values can
		''' be forward oriented <c>ForwardStep</c> (<see cref="ZedGraph.StepType"/>) or
		''' rearward oriented <c>RearwardStep</c>.
		''' That is, the points are defined at the beginning or end
		''' of the constant value for which they apply, respectively.
		''' </summary>
		''' <value><see cref="ZedGraph.StepType"/> enum value</value>
		Public Property StepType() As StepType
			Get
				Return m_stepType
			End Get
			Set
				m_stepType = value
			End Set
		End Property

		Public Property ColorList() As ArrayList
			Get
				Return Me.CL
			End Get
			Set
				Me.CL = value
			End Set
		End Property


		''' <summary>
		''' Render a single <see cref="Line"/> segment to the specified
		''' <see cref="Graphics"/> device.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="x1">The x position of the starting point that defines the
		''' line segment in screen pixel units</param>
		''' <param name="y1">The y position of the starting point that defines the
		''' line segment in screen pixel units</param>
		''' <param name="x2">The x position of the ending point that defines the
		''' line segment in screen pixel units</param>
		''' <param name="y2">The y position of the ending point that defines the
		''' line segment in screen pixel units</param>
		Public Sub Draw(g As Graphics, x1 As Single, y1 As Single, x2 As Single, y2 As Single)

			If Me.m_isVisible Then
				Dim pen As New Pen(Me.m_color, Me.m_width)
				pen.DashStyle = Me.Style
				g.DrawLine(pen, x1, y1, x2, y2)
			End If
		End Sub

		''' <summary>
		''' Render a series of <see cref="Line"/> segments to the specified
		''' <see cref="Graphics"/> device.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="x">The array of x position values that define the
		''' line segments in screen pixel units</param>
		''' <param name="y">The array of y position values that define the
		''' line segments in screen pixel units</param>

		Public Sub DrawMany(g As Graphics, x As Single(), y As Single())
			If Me.m_isVisible Then
				Dim pen As New Pen(Me.m_color, Me.m_width)
				pen.DashStyle = Me.Style
				Dim nSeg As Integer = x.Length - 1
				Dim iPlus As Integer = 0

				Dim i As Integer = 0
				While i < nSeg
					System.Math.Max(System.Threading.Interlocked.Increment(iPlus),iPlus - 1)
					If x(i) <> System.[Single].MaxValue AndAlso x(iPlus) <> System.[Single].MaxValue AndAlso y(i) <> System.[Single].MaxValue AndAlso y(iPlus) <> System.[Single].MaxValue Then
						If Me.StepType = StepType.NonStep Then
							g.DrawLine(pen, x(i), y(i), x(iPlus), y(iPlus))
						ElseIf Me.StepType = StepType.ForwardStep Then
							g.DrawLine(pen, x(i), y(i), x(iPlus), y(i))
							g.DrawLine(pen, x(iPlus), y(i), x(iPlus), y(iPlus))
						ElseIf Me.StepType = StepType.RearwardStep Then
							g.DrawLine(pen, x(i), y(i), x(i), y(iPlus))
							g.DrawLine(pen, x(i), y(iPlus), x(iPlus), y(iPlus))
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
			End If
		End Sub
		Public Sub DrawManyEx(g As Graphics, pane As AldysPane, x As Single(), y As Single(), xY As ArrayList)
			If Me.m_isVisible Then
				Dim pen As New Pen(Me.m_color, Me.m_width)
				pen.DashStyle = Me.Style
				Dim nSeg As Integer = x.Length - 1
				Dim iPlus As Integer = 0
				Dim xTmp As Single, yTmp As Single
				xTmp = InlineAssignHelper(yTmp, 0)
				Dim slope As Single, constant As Single
				slope = InlineAssignHelper(constant, 0)

				Dim i As Integer = 0
				While i < nSeg
					System.Math.Max(System.Threading.Interlocked.Increment(iPlus),iPlus - 1)
					If x(i) <> System.[Single].MaxValue AndAlso x(iPlus) <> System.[Single].MaxValue AndAlso y(i) <> System.[Single].MaxValue AndAlso y(iPlus) <> System.[Single].MaxValue Then
						If Me.StepType = StepType.NonStep Then
							If (DirectCast(xY(i), Double) >= pane.YAxis.UpperAlarmLineY) AndAlso (DirectCast(xY(iPlus), Double) >= pane.YAxis.UpperAlarmLineY) AndAlso pane.YAxis.UpperAlarmLine Then
								pen.Color = pane.YAxis.UpperAlarmLineColor
								Dim cStatus As New CurveStatus(1)
								pane.GetStatusEvent(cStatus)

								g.DrawLine(pen, x(i), y(i), x(iPlus), y(iPlus))
							ElseIf (DirectCast(xY(i), Double) < pane.YAxis.UpperAlarmLineY) AndAlso (DirectCast(xY(iPlus), Double) > pane.YAxis.UpperAlarmLineY) AndAlso pane.YAxis.UpperAlarmLine Then
								'find the slope of the line								
								If x(i) - x(iPlus) <> 0 Then
									slope = (y(iPlus) - y(i)) / (x(iPlus) - x(i))
									constant = y(i) - (((y(iPlus) - y(i)) / (x(iPlus) - x(i))) * x(i))
								End If
								'find the new point
								yTmp = pane.YAxis.Transform(pane.YAxis.UpperAlarmLineY)
								xTmp = (yTmp - constant) / slope
								pen.Color = Me.m_color
								g.DrawLine(pen, x(i), y(i), xTmp, yTmp)
								pen.Color = pane.YAxis.UpperAlarmLineColor
								Dim cStatus As New CurveStatus(1)
								pane.GetStatusEvent(cStatus)
								g.DrawLine(pen, xTmp, yTmp, x(iPlus), y(iPlus))
							ElseIf (DirectCast(xY(i), Double) > pane.YAxis.UpperAlarmLineY) AndAlso (DirectCast(xY(iPlus), Double) < pane.YAxis.UpperAlarmLineY) AndAlso pane.YAxis.UpperAlarmLine Then
								'find the slope of the line								
								If x(i) - x(iPlus) <> 0 Then
									slope = (y(iPlus) - y(i)) / (x(iPlus) - x(i))
									constant = y(i) - (((y(iPlus) - y(i)) / (x(iPlus) - x(i))) * x(i))
								End If
								'find the new point
								yTmp = pane.YAxis.Transform(pane.YAxis.UpperAlarmLineY)
								xTmp = (yTmp - constant) / slope
								pen.Color = pane.YAxis.UpperAlarmLineColor
								Dim cStatus As New CurveStatus(1)
								pane.GetStatusEvent(cStatus)
								g.DrawLine(pen, x(i), y(i), xTmp, yTmp)
								pen.Color = Me.m_color
								g.DrawLine(pen, xTmp, yTmp, x(iPlus), y(iPlus))

							ElseIf (DirectCast(xY(i), Double) <= pane.YAxis.LowerAlarmLineY) AndAlso (DirectCast(xY(iPlus), Double) <= pane.YAxis.LowerAlarmLineY) AndAlso pane.YAxis.LowerAlarmLine Then
								pen.Color = Me.m_color
								'Sachin Ashtankar
								'pen.Color = pane.YAxis.LowerAlarmLineColor;
								Dim cStatus As New CurveStatus(-1)
								pane.GetStatusEvent(cStatus)
								g.DrawLine(pen, x(i), y(i), x(iPlus), y(iPlus))
							ElseIf (DirectCast(xY(i), Double) > pane.YAxis.LowerAlarmLineY) AndAlso (DirectCast(xY(iPlus), Double) < pane.YAxis.LowerAlarmLineY) AndAlso pane.YAxis.LowerAlarmLine Then
								'find the slope of the line

								If x(i) - x(iPlus) <> 0 Then
									slope = (y(iPlus) - y(i)) / (x(iPlus) - x(i))
									constant = y(i) - (((y(iPlus) - y(i)) / (x(iPlus) - x(i))) * x(i))
								End If
								'find the new point
								yTmp = pane.YAxis.Transform(pane.YAxis.LowerAlarmLineY)
								xTmp = (yTmp - constant) / slope

								pen.Color = Me.m_color
								g.DrawLine(pen, x(i), y(i), xTmp, yTmp)
								pen.Color = pane.YAxis.LowerAlarmLineColor
								Dim cStatus As New CurveStatus(1)
								pane.GetStatusEvent(cStatus)



								g.DrawLine(pen, xTmp, yTmp, x(iPlus), y(iPlus))
							ElseIf (DirectCast(xY(i), Double) < pane.YAxis.LowerAlarmLineY) AndAlso (DirectCast(xY(iPlus), Double) > pane.YAxis.LowerAlarmLineY) AndAlso pane.YAxis.LowerAlarmLine Then
								'find the slope of the line

								If x(i) - x(iPlus) <> 0 Then
									slope = (y(iPlus) - y(i)) / (x(iPlus) - x(i))
									constant = y(i) - (((y(iPlus) - y(i)) / (x(iPlus) - x(i))) * x(i))
								End If
								'find the new point
								yTmp = pane.YAxis.Transform(pane.YAxis.LowerAlarmLineY)
								xTmp = (yTmp - constant) / slope
								pen.Color = Me.m_color
								g.DrawLine(pen, xTmp, yTmp, x(iPlus), y(iPlus))
								pen.Color = pane.YAxis.LowerAlarmLineColor
								Dim cStatus As New CurveStatus(1)
								pane.GetStatusEvent(cStatus)
								g.DrawLine(pen, x(i), y(i), xTmp, yTmp)
							Else
								If Me.CL.Count > 0 Then
									pen.Color = DirectCast(Me.CL(i), Color)
								Else
									'this.color;
									pen.Color = Me.m_color
								End If

								Dim cStatus As New CurveStatus(0)
								pane.GetStatusEvent(cStatus)
								g.DrawLine(pen, x(i), y(i), x(iPlus), y(iPlus))

								'g.DrawLine( pen, xTmp, y[i], x[iPlus], y[iPlus] );
							End If

						ElseIf Me.StepType = StepType.ForwardStep Then

							g.DrawLine(pen, x(i), y(i), x(iPlus), y(i))
							g.DrawLine(pen, x(iPlus), y(i), x(iPlus), y(iPlus))
						ElseIf Me.StepType = StepType.RearwardStep Then
							g.DrawLine(pen, x(i), y(i), x(i), y(iPlus))
							g.DrawLine(pen, x(i), y(iPlus), x(iPlus), y(iPlus))
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
			End If
		End Sub
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function
	End Class
End Namespace
