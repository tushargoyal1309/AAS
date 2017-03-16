Imports System
Imports System.Drawing
Imports System.Collections

Namespace AldysGraph

	''' <summary>
	''' This class contains the data and methods for an individual curve within
	''' a graph pane.  It carries the settings for the curve including the
	''' key and item names, colors, symbols and sizes, linetypes, etc.
	''' </summary>
	Public Class CurveItem
		Implements ICloneable
		''' <summary>
		''' Private field that stores a reference to the <see cref="AldysGraph.Symbol"/>
		''' class defined for this <see cref="CurveItem"/>.  Use the public
		''' property <see cref="Symbol"/> to access this value.
		''' </summary>
		Private m_symbol As Symbol

		''' <summary>
		''' Private field that stores a reference to the <see cref="AldysGraph.Line"/>
		''' class defined for this <see cref="CurveItem"/>.  Use the public
		''' property <see cref="Line"/> to access this value.
		''' </summary>
		Private m_line As Line

		''' <summary>
		''' Private field that stores a legend label string for this
		''' <see cref="CurveItem"/>.  Use the public
		''' property <see cref="Label"/> to access this value.
		''' </summary>		
		Private m_label As String

		''' <summary>
		''' Private field that stores the boolean value that determines whether this
		''' <see cref="CurveItem"/> is on the left Y axis or the right Y axis (Y2).
		''' Use the public property <see cref="IsY2Axis"/> to access this value.
		''' </summary>
		Private m_isY2Axis As Boolean

		Private m_isHighPeakLine As Boolean
		Private m_highPeakXValue As Double
		Private m_highPeakYValue As Double

		''' <summary>
		''' The array of independent (X Axis) values that define this
		''' <see cref="CurveItem"/>.
		''' The size of this array determines the number of points that are
		''' plotted.  Note that values defined as
		''' System.Double.MaxValue are considered "missing" values,
		''' and are not plotted.  The curve will have a break at these points
		''' to indicate values are missing.
		''' </summary>
		Public X As ArrayList

		''' <summary>
		''' The array of dependent (Y Axis) values that define this
		''' <see cref="CurveItem"/>.
		''' The size of this array determines the number of points that are
		''' plotted.  Note that values defined as
		''' System.Double.MaxValue are considered "missing" values,
		''' and are not plotted.  The curve will have a break at these points
		''' to indicate values are missing.
		''' </summary>
		Public Y As ArrayList

		' Color for individual points
		Public CL As ArrayList

		'Symbol for individual points		
		Public SYM As ArrayList

		Public AddPointFlg As Boolean

		Public DigitalFlg As Boolean

		'Label for Name of the each curve.
		Private m_labelX As String

		'Flag to indicate that curve contains all scattered points
		Private mblnIsScatteredPointsCurve As Boolean

		'ArrayList to store multiple scattered points
		Public ScatteredPoints As ArrayList

		Public Property IsHighPeakLine() As Boolean
			Get
				Return m_isHighPeakLine
			End Get
			Set
				m_isHighPeakLine = value
			End Set
		End Property

		Public Property HighPeakYValue() As Double
			Get
				Return m_highPeakYValue
			End Get
			Set
				m_highPeakYValue = value
			End Set
		End Property
		Public Property HighPeakXValue() As Double
			Get
				Return m_highPeakXValue
			End Get
			Set
				m_highPeakXValue = value
			End Set
		End Property

		'A unique No. is assigned to each x & y co-ordinates to indicate
		'the position of the point in the curve.
		'private ArrayList marrPointNumbers;

		''' <summary>
		''' <see cref="CurveItem"/> constructor the pre-specifies the curve label and the
		''' x and y data arrays.  All other properties of the curve are
		''' defaulted to the values in the <see cref="Def"/> class.
		''' </summary>
		''' <param name="label">A string label (legend entry) for this curve</param>
		''' <param name="x">A array of double precision values that define
		''' the independent (X axis) values for this curve</param>
		''' <param name="y">A array of double precision values that define
		''' the dependent (Y axis) values for this curve</param>
		Public Sub New(label As String, x As ArrayList, y As ArrayList)
			Me.m_line = New Line()
			Me.m_symbol = New Symbol()
			Me.m_label = label
			Me.m_isY2Axis = False
			Me.X = New ArrayList()
			Me.Y = New ArrayList()
			Me.CL = New ArrayList()
			Me.SYM = New ArrayList()
			Me.mblnIsScatteredPointsCurve = False
			Me.ScatteredPoints = New ArrayList()

			If x.Count > 0 Then
				Me.X = DirectCast(x.Clone(), ArrayList)
			End If
			If y.Count > 0 Then
				Me.Y = DirectCast(y.Clone(), ArrayList)
			End If

			'----- Added by Sachin Dokhale
			IsHighPeakLine = False
			HighPeakXValue = 0.0
				'-----
			HighPeakYValue = 0.0
		End Sub


		''' <summary>
		''' <see cref="CurveItem"/> constructor the pre-specifies the curve label and the
		''' x and y data arrays.  All other properties of the curve are
		''' defaulted to the values in the <see cref="Def"/> class.
		''' </summary>
		''' <param name="label">A string label (legend entry) for this curve</param>
		''' <param name="x">A array of double precision values that define
		''' the independent (X axis) values for this curve</param>
		''' <param name="y">A array of double precision values that define
		''' the dependent (Y axis) values for this curve</param>
		Public Sub New(label As String, x As ArrayList, y As ArrayList, cl As ArrayList, sym As ArrayList)
			Me.m_line = New Line()
			Me.m_symbol = New Symbol()
			Me.m_label = label
			Me.m_isY2Axis = False
			'-		-----------------
			Me.X = New ArrayList()
			Me.Y = New ArrayList()
			Me.CL = New ArrayList()
			Me.SYM = New ArrayList()
			Me.mblnIsScatteredPointsCurve = False
			Me.ScatteredPoints = New ArrayList()

			'-		-----------------
			If x.Count > 0 Then
				Me.X = DirectCast(x.Clone(), ArrayList)
			End If
			If y.Count > 0 Then
				Me.Y = DirectCast(y.Clone(), ArrayList)
			End If
			If cl.Count > 0 Then
				Me.CL = DirectCast(cl.Clone(), ArrayList)
			End If
			If sym.Count > 0 Then
				Me.SYM = DirectCast(sym.Clone(), ArrayList)
			End If

			'----- Added by Sachin Dokhale
			IsHighPeakLine = False
			HighPeakXValue = 0.0
				'-----

			HighPeakYValue = 0.0
		End Sub


		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The CurveItem object from which to copy</param>
		Public Sub New(rhs As CurveItem)
			m_symbol = New Symbol(rhs.Symbol)
			m_line = New Line(rhs.Line)
			m_label = rhs.Label
			m_isY2Axis = rhs.IsY2Axis
			mblnIsScatteredPointsCurve = rhs.IsScatteredPointsCurve
			ScatteredPoints = rhs.ScatteredPoints

			Dim len As Integer = rhs.X.Count

			Me.X = DirectCast(rhs.X.Clone(), ArrayList)

			Me.Y = DirectCast(rhs.Y.Clone(), ArrayList)

			Me.CL = DirectCast(rhs.CL.Clone(), ArrayList)

			Me.SYM = DirectCast(rhs.SYM.Clone(), ArrayList)

			'----- Added by Sachin Dokhale
			IsHighPeakLine = rhs.IsHighPeakLine
			HighPeakXValue = rhs.HighPeakXValue
				'-----
			HighPeakYValue = rhs.HighPeakYValue
		End Sub


		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the CurveItem</returns>
		Public Function Clone() As Object
			Return New CurveItem(Me)
		End Function


		''' <summary>
		''' Gets a reference to the <see cref="AldysGraph.Symbol"/> class defined
		''' for this <see cref="CurveItem"/>.
		''' </summary>
		Public ReadOnly Property Symbol() As Symbol
			Get
				Return m_symbol
			End Get
		End Property


		''' <summary>
		''' Gets a reference to the <see cref="AldysGraph.Line"/> class defined
		''' for this <see cref="CurveItem"/>.
		''' </summary>
		Public ReadOnly Property Line() As Line
			Get
				Return m_line
			End Get
		End Property


		''' <summary>
		''' A text string that represents the <see cref="AldysGraph.Legend"/>
		''' entry for the this
		''' <see cref="CurveItem"/> object
		''' </summary>
		Public Property Label() As String
			Get
				Return m_label
			End Get
			Set
				m_label = value
			End Set
		End Property

		''' <summary>
		''' A text string that represents the <see cref="ZedGraph.Legend"/>
		''' entry for the this
		''' <see cref="CurveItem"/> object
		''' </summary>
		Public Property LabelX() As String
			Get
				Return m_labelX
			End Get
			Set
				m_labelX = value
			End Set
		End Property


		''' <summary>
		''' Determines which Y axis this <see cref="CurveItem"/>
		'''  is assigned to.  The
		''' <see cref="ZedGraph.YAxis"/> is on the left side of the graph and the
		''' <see cref="ZedGraph.Y2Axis"/> is on the right side.  Assignment to an axis
		''' determines the scale that is used to draw the curve on the graph.
		''' </summary>
		''' <value>true to assign the curve to the <see cref="ZedGraph.Y2Axis"/>,
		''' false to assign the curve to the <see cref="ZedGraph.YAxis"/></value>
		Public Property IsY2Axis() As Boolean
			Get
				Return m_isY2Axis
			End Get
			Set
				m_isY2Axis = value
			End Set
		End Property


		''' <summary>
		''' Readonly property that gives the number of points that define this
		''' <see cref="CurveItem"/> object, which is the number of points in the
		''' <see cref="X"/> and <see cref="Y"/> data arrays.
		''' </summary>
		Public ReadOnly Property NPts() As Integer
			Get
				If Me.X.Count <= 0 OrElse Me.Y.Count <= 0 Then
					Return 0
				Else
					Return If(X.Count < Y.Count, X.Count, Y.Count)
				End If
			End Get
		End Property

		''' <summary>
		''' To indicate that curve contains all scattered points
		''' </summary>
		Public Property IsScatteredPointsCurve() As Boolean
			Get
				Return mblnIsScatteredPointsCurve
			End Get
			Set
				mblnIsScatteredPointsCurve = value
			End Set
		End Property


		''' <summary>
		''' Do all rendering associated with this <see cref="CurveItem"/> to the specified
		''' <see cref="Graphics"/> device.  This method is normally only
		''' called by the Draw method of the parent <see cref="AldysGraph.CurveList"/>
		''' collection object.  This version is optimized for speed and should be much
		''' faster than the regular Draw() routine.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="pane">
		''' A reference to the <see cref="AldysGraph.AldysPane"/> object that is the parent or
		''' owner of this object.
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="ZedGraph.AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		Public Sub Draw(g As Graphics, pane As AldysPane, scaleFactor As Double)
			Dim nPts As Integer = Me.NPts - 1
			Dim tmpX As Single()
			Dim tmpY As Single()
			Dim i As Integer = 0

			If (Me.m_isHighPeakLine = False) AndAlso (Me.AddPointFlg = False) OrElse (Me.AddPointFlg = True AndAlso pane.CurveList.isResizing) Then
				tmpX = New Single(nPts - 1) {}
				tmpY = New Single(nPts - 1) {}

				' Loop over each point in the curve
				i = 0
				While i < nPts
					'( this.isY2Axis && pane.Y2Axis.IsLog && this.Y[i] <= 0.0 ) ||
					If DirectCast(Me.X(i), Double) = System.[Double].MaxValue OrElse DirectCast(Me.Y(i), Double) = System.[Double].MaxValue OrElse (pane.XAxis.IsLog AndAlso DirectCast(Me.X(i), Double) <= 0.0) OrElse (Not Me.m_isY2Axis AndAlso pane.YAxis.IsLog AndAlso DirectCast(Me.Y(i), Double) <= 0.0) Then
						tmpX(i) = Single.MaxValue
						tmpY(i) = Single.MaxValue
					Else
						' Transform the current point from user scale units to
						' screen coordinates
						tmpX(i) = pane.XAxis.Transform(DirectCast(Me.X(i), Double))
						tmpY(i) = pane.YAxis.Transform(DirectCast(Me.Y(i), Double))

						If tmpX(i) < -100000 OrElse tmpX(i) > 100000 OrElse tmpY(i) < -100000 OrElse tmpY(i) > 100000 Then
							tmpX(i) = System.[Single].MaxValue
							tmpY(i) = System.[Single].MaxValue
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While

				Me.Line.ColorList = Me.CL
				Me.Line.DrawManyEx(g, pane, tmpX, tmpY, Me.Y)
				'pane.CurveList.isResizing = false;

				If (Me.SYM.Count > 0) AndAlso (Me.CL.Count > 0) Then
					Me.Symbol.DrawMany(g, tmpX, tmpY, scaleFactor, Me.CL, Me.SYM)
				Else
					Me.Symbol.DrawManyEx(g, pane, tmpX, tmpY, scaleFactor, Me.Y)
				End If

				If Me.mblnIsScatteredPointsCurve Then
					'Plot the scattered points
					i = 0
					While i < Me.ScatteredPoints.Count
						'---Draw the single point						
						Dim objPoint As Point = DirectCast(ScatteredPoints(i), Point)
						Dim fX As Single = pane.XAxis.Transform(DirectCast(objPoint.X, Double))
						Dim fY As Single = pane.YAxis.Transform(DirectCast(objPoint.Y, Double))
						Dim curveColor As Color = Me.Symbol.Color
						Me.Symbol.Color = objPoint.PointColor
						Me.Symbol.Size = objPoint.PointRadius
						Me.Symbol.Draw(g, fX, fY, scaleFactor)
						Me.Symbol.Color = curveColor
						System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
					End While
				End If
			Else
				If nPts = 1 OrElse nPts = 0 Then
					'---in future to draw single point in curve					
					'---Added By Mangesh S. on 26-Nov-2006					
					'if (this.mblnIsScatteredPointsCurve){
					'---Loop over each point in the curve
					'for ( i=0; i < this.NPts ; i++ )
					'{
					'	//---Draw the single point
					'	float fX = pane.XAxis.Transform( ((double)this.X[i]));						
					'	float fY = pane.YAxis.Transform( ((double)this.Y[i]));
					'	this.Symbol.Draw(g,fX,fY,scaleFactor);
					'}
					'}
					Return
				End If

				tmpX = New Single(1) {}
				tmpY = New Single(1) {}
				Dim j As Integer

				'Draw only for last two points 
				i = Me.NPts - 2
				j = 0
				While i < Me.NPts
					If DirectCast(Me.X(i), Double) = System.[Double].MaxValue OrElse DirectCast(Me.Y(i), Double) = System.[Double].MaxValue OrElse (pane.XAxis.IsLog AndAlso DirectCast(Me.X(i), Double) <= 0.0) OrElse (Not Me.m_isY2Axis AndAlso pane.YAxis.IsLog AndAlso DirectCast(Me.Y(i), Double) <= 0.0) Then
						tmpX(j) = System.[Single].MaxValue
						tmpY(j) = System.[Single].MaxValue
					Else
						' Transform the current point from user scale units to
						' screen coordinates
						tmpX(j) = pane.XAxis.Transform(DirectCast(Me.X(i), Double))
						tmpY(j) = pane.YAxis.Transform(DirectCast(Me.Y(i), Double))

						If tmpX(j) < -100000 OrElse tmpX(j) > 100000 OrElse tmpY(j) < -100000 OrElse tmpY(j) > 100000 Then
							tmpX(j) = System.[Single].MaxValue
							tmpY(j) = System.[Single].MaxValue
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
					System.Math.Max(System.Threading.Interlocked.Increment(j),j - 1)
				End While

				Me.Line.DrawManyEx(g, pane, tmpX, tmpY, Me.Y)
				Me.Symbol.DrawMany(g, tmpX, tmpY, scaleFactor)
			End If
		End Sub

		'
'				/// <summary>
'				/// Draw the this <see cref="CurveItem"/> to the specified <see cref="Graphics"/>
'				/// device.  The format (stair-step or line) of the curve is
'				/// defined by the <see cref="StepType"/> property.  The routine
'				/// only draws the line segments; the symbols are draw by the
'				/// <see cref="DrawSymbols"/> method.  This method
'				/// is normally only called by the Draw method of the
'				/// <see cref="CurveItem"/> object
'				/// </summary>
'				/// <param name="g">
'				/// A graphic device object to be drawn into.  This is normally e.Graphics from the
'				/// PaintEventArgs argument to the Paint() method.
'				/// </param>
'				/// <param name="pane">
'				/// A reference to the <see cref="AldysPane"/> object that is the parent or
'				/// owner of this object.
'				/// </param>
'				protected void DrawCurve( Graphics g, AldysPane pane )
'				{
'					float	tmpX, tmpY,
'							lastX = 0,
'							lastY = 0;
'					bool	broke = true;
'			
'					// Loop over each point in the curve, building an array of screen
'					// locations.  Invalid points are set to System.Double.MaxValue
'					int nPts = this.NPts;
'					for ( int i=0; i<nPts; i++ )
'					{
'						// Any value set to double max is invalid and should be skipped
'						// This is used for calculated values that are out of range, divide
'						//   by zero, etc.
'						// Also, any value <= zero on a log scale is invalid
'						if ( 	this.X[i] == System.Double.MaxValue ||
'								this.Y[i] == System.Double.MaxValue ||
'								( pane.XAxis.IsLog && this.X[i] <= 0.0 ) ||
'								( this.isY2Axis && pane.Y2Axis.IsLog && this.Y[i] <= 0.0 ) ||
'								( !this.isY2Axis && pane.YAxis.IsLog && this.Y[i] <= 0.0 ) )
'						{
'							broke = true;
'						}
'						else
'						{
'							// Transform the current point from user scale units to
'							// screen coordinates
'							tmpX = pane.XAxis.Transform( this.X[i] );
'							if ( this.isY2Axis )
'								tmpY = pane.Y2Axis.Transform( this.Y[i] );
'							else
'								tmpY = pane.YAxis.Transform( this.Y[i] );
'					
'							// off-scale values "break" the line
'							if ( tmpX < -100000 || tmpX > 100000 ||
'									tmpY < -100000 || tmpY > 100000 )
'								broke = true;
'							else
'							{
'								// If the last two points are valid, draw a line segment
'								if ( !broke )
'								{
'									if ( this.stepType == StepType.ForwardStep )
'									{
'										this.Line.Draw( g, lastX, lastY, tmpX, lastY );
'										this.Line.Draw( g, tmpX, lastY, tmpX, tmpY );
'									}
'									else if ( this.stepType == StepType.RearwardStep )
'									{
'										this.Line.Draw( g, lastX, lastY, lastX, tmpY );
'										this.Line.Draw( g, lastX, tmpY, tmpX, tmpY );
'									}
'									else 		// non-step
'										this.Line.Draw( g, lastX, lastY, tmpX, tmpY );
'
'								}
'
'								// Save some values for the next point
'								broke = false;
'								lastX = tmpX;
'								lastY = tmpY;
'							}
'						}
'					}
'				}
'		

		'
'				/// <summary>
'				/// Draw the this <see cref="CurveItem"/> to the specified <see cref="Graphics"/>
'				/// device as a symbol at each defined point.  The routine
'				/// only draws the symbols; the lines are draw by the
'				/// <see cref="DrawCurve"/> method.  This method
'				/// is normally only called by the Draw method of the
'				/// <see cref="CurveItem"/> object
'				/// </summary>
'				/// <param name="g">
'				/// A graphic device object to be drawn into.  This is normally e.Graphics from the
'				/// PaintEventArgs argument to the Paint() method.
'				/// </param>
'				/// <param name="pane">
'				/// A reference to the <see cref="AldysPane"/> object that is the parent or
'				/// owner of this object.
'				/// </param>
'				/// <param name="scaleFactor">
'				/// The scaling factor to be used for rendering objects.  This is calculated and
'				/// passed down by the parent <see cref="AldysPane"/> object using the
'				/// <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
'				/// font sizes, etc. according to the actual size of the graph.
'				/// </param>
'				public void DrawSymbols( Graphics g, AldysPane pane, double scaleFactor )
'				{
'					float tmpX, tmpY;
'			
'					// Loop over each defined point							
'					for ( int i=0; i<this.NPts; i++ )
'					{
'						// Any value set to double max is invalid and should be skipped
'						// This is used for calculated values that are out of range, divide
'						//   by zero, etc.
'						// Also, any value <= zero on a log scale is invalid
'				
'						if (	this.X[i] != System.Double.MaxValue &&
'								this.Y[i] != System.Double.MaxValue &&
'								( this.X[i] > 0 || !pane.XAxis.IsLog ) &&
'								( this.Y[i] > 0 ||
'									(this.isY2Axis && !pane.Y2Axis.IsLog ) ||
'									(!this.isY2Axis && !pane.YAxis.IsLog ) ) )
'						{
'							tmpX = pane.XAxis.Transform( this.X[i] );
'							if ( this.isY2Axis )
'								tmpY = pane.Y2Axis.Transform( this.Y[i] );
'							else
'								tmpY = pane.YAxis.Transform( this.Y[i] );
'
'							this.Symbol.Draw( g, tmpX, tmpY, scaleFactor );		
'						}
'					}
'				}
'		


		''' <summary>
		''' Go through <see cref="X"/> and <see cref="Y"/> data arrays
		''' for this <see cref="CurveItem"/>
		''' and determine the minimum and maximum values in the data.
		''' </summary>
		''' <param name="xMin">The minimum X value in the range of data</param>
		''' <param name="xMax">The maximum X value in the range of data</param>
		''' <param name="yMin">The minimum Y value in the range of data</param>
		''' <param name="yMax">The maximum Y value in the range of data</param>
		''' <param name="ignoreInitial">ignoreInitial is a boolean value that
		''' affects the data range that is considered for the automatic scale
		''' ranging (see <see cref="AldysPane.IsIgnoreInitial"/>).  If true, then initial
		''' data points where the Y value is zero are not included when
		''' automatically determining the scale <see cref="Axis.Min"/>,
		''' <see cref="Axis.Max"/>, and <see cref="Axis.Step"/> size.  All data after
		''' the first non-zero Y value are included.
		''' </param>
		Public Sub GetRange(ByRef xMin As Double, ByRef xMax As Double, ByRef yMin As Double, ByRef yMax As Double, ignoreInitial As Boolean)
			' initialize the values to outrageous ones to start
			xMin = InlineAssignHelper(yMin, 1E+20)
			xMax = InlineAssignHelper(yMax, -1E+20)

			' Loop over each point in the arrays
			Dim i As Integer = 0
			While i < Me.NPts
				' ignoreInitial becomes false at the first non-zero
				' Y value
				If ignoreInitial AndAlso DirectCast(DirectCast(Me.Y(i), Double) <> 0, Boolean) AndAlso DirectCast(Me.Y(i), Double) <> System.[Double].MaxValue Then
					ignoreInitial = False
				End If

				If Not ignoreInitial AndAlso DirectCast(Me.X(i), Double) <> System.[Double].MaxValue AndAlso DirectCast(Me.Y(i), Double) <> System.[Double].MaxValue Then
					If DirectCast(Me.X(i), Double) < xMin Then
						xMin = DirectCast(Me.X(i), Double)
					End If
					If DirectCast(Me.X(i), Double) > xMax Then
						xMax = DirectCast(Me.X(i), Double)
					End If
					If DirectCast(Me.Y(i), Double) < yMin Then
						yMin = DirectCast(Me.Y(i), Double)
					End If
					If DirectCast(Me.Y(i), Double) > yMax Then
						yMax = DirectCast(Me.Y(i), Double)
					End If
				End If
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While
		End Sub


		''' <summary>
		''' See if the <see cref="X"/> or <see cref="Y"/> data arrays are missing
		''' for this <see cref="CurveItem"/>.  If so, provide a suitable default
		''' array using ordinal values.
		''' </summary>
		''' <param name="pane">
		''' A reference to the <see cref="AldysPane"/> object that is the parent or
		''' owner of this object.
		''' </param>
		Public Sub DataCheck(pane As AldysPane)
			' See if a default X array is required
			If Me.X = Nothing Then
				' if a Y array is available, just make the same number of elements
				If not (Me.Y  is nothing)  Then
					Me.X = MakeDefaultArray(Me.Y.Count)
				Else
					Me.X = pane.XAxis.MakeDefaultArray()
				End If
			End If
			' see if a default Y array is required
			If Me.Y = Nothing Then
				' if an X array is available, just make the same number of elements
				If not (Me.X  is nothing)  Then
					Me.Y = MakeDefaultArray(Me.X.Count)
				Else
					'				else if ( this.isY2Axis )
					'					this.Y = pane.Y2Axis.MakeDefaultArray();
					Me.Y = pane.YAxis.MakeDefaultArray()
				End If
			End If
		End Sub


		''' <summary>
		''' Generate a default array of ordinal values.
		''' </summary>
		''' <param name="length">
		''' The number of values to generate.
		''' </param>
		''' <returns>a floating point double type array of default ordinal values</returns>
		Private Function MakeDefaultArray(length As Integer) As ArrayList
			'double[] dArray = new double[length];
			Dim dArray As New ArrayList()
			'dArray.Clear();
			Dim i As Integer = 0
			While i < length
				dArray.Add(DirectCast(i, Double) + 1.0)
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While

			Return dArray
		End Function


		Public Sub InsertCurvePixels(pane As AldysPane, peakx As ArrayList, peaky As ArrayList)
			' Transform the current point from user scale units to
			' screen coordinates
			Dim fX As Single, fY As Single
			fX = 0
			fY = 0
			Dim i As Integer = 0
			While i < Me.NPts
				fX = pane.XAxis.Transform(DirectCast(Me.X(i), Double))
				fY = pane.YAxis.Transform(DirectCast(Me.Y(i), Double))
				If pane.axisRect.Contains(fX, fY) Then
					peakx.Add(DirectCast(fX, Double))
					peaky.Add(DirectCast(fY, Double))
				End If
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While

		End Sub
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function


	End Class
End Namespace
