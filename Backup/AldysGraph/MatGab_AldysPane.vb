Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections

Namespace AldysGraph
	''' <summary>
	''' The Main Canvas for Drawing the Graph.
	''' </summary>
	Public Class AldysPane
		Implements ICloneable

		#region " Item subclasses"

		Private m_xAxis As XAxis
		' A class representing the X axis
		Private m_yAxis As YAxis
		' A class representing the Y axis
		Private m_legend As Legend
		' A class for the graph legend
		Private m_curveList As CurveList
		' A collection class for the curves on the graph
		Private m_textList As TextList
		' A collection class for user text items on the graph
		Private m_arrowList As ArrowList
		' A collection class for lines/arrows on the graph

		Private m_fontSpec As FontSpecs
		' Describes the title font characteristics
		' Pane Title Properties
		Private m_title As String
		' The main title of the graph
		Private m_isShowTitle As Boolean
		' true to show the title
		' Pane Frame Properties
		Private m_isPaneFramed As Boolean
		' True if the AldysPane has a frame border
		Private m_paneFrameColor As Color
		' Color of the pane frame border
		Private m_paneFramePenWidth As Single
		' Width of the pane frame border
		Private m_paneBackColor As Color
		' Color of the background behind paneRect
		Private m_isAxisFramed As Boolean
		' True if the Axis has a frame border
		Private m_axisFrameColor As Color
		' Color of the axis frame border
		Private m_axisFramePenWidth As Single
		' Width of the axis frame border
		Private m_axisBackColor As Color
		' Color of the background behind axisRect
		Private m_isIgnoreInitial As Boolean
		' true to ignore initial zero values for auto scale selection
		Private m_paneGap As Single
		' Size of the gap (margin) around the edges of the pane and axis
		Private m_baseDimension As Double
		' Basic length scale (inches) of the plot for scaling features
		Private intCurveLabelSize As Integer
		'private bool		xMidAxis;		// if XAxis in the middle of Axis Rect

		''' <summary>
		''' The rectangle that defines the full area into which the
		''' graph can be rendered.  Units are pixels.
		''' </summary>
		Public m_paneRect As RectangleF
		' The full area of the graph pane
		''' <summary>
		''' The rectangle that contains the area bounded by the axes, in
		''' pixel units
		''' </summary>
		Public m_axisRect As RectangleF
		' The area of the pane defined by the axes
		#end region

		Public statusflag As Boolean
		Public hwnd As New IntPtr()

		Public bPeakEdit As Boolean
		Public cursor As Cursor

		Public peakCurveIndex As Integer
		Public peakX As ArrayList
		Public peakY As ArrayList

		Public bPeakInfo As Boolean
		Public peakInfoCurveIndex As Integer
		Public peakInfoX As ArrayList
		Public peakInfoY As ArrayList

		Public ShowCurveLabels As Boolean

		Private objAldysGraphTmp As AldysGraph
		'private System.Windows.Forms.sy  ChangeAxis;  


		Public Sub GetStatusEvent(cs As CurveStatus)
			objAldysGraphTmp.GetStatusEventEx(cs)
		End Sub

		Public Property CurveLabelSize() As Integer
			Get
				Return intCurveLabelSize
			End Get
			Set
				intCurveLabelSize = value
			End Set
		End Property


		Public Sub EnablePeakEdit(CurveIndex As Integer, Flag As Boolean)
			If Flag Then
				bPeakEdit = True
				peakCurveIndex = CurveIndex
				'Store all the pixels of courve in array
				Me.peakX.Clear()
				Me.peakY.Clear()
				Me.CurveList(CurveIndex).InsertCurvePixels(Me, peakX, peakY)
			Else
				Me.peakX.Clear()
				Me.peakY.Clear()
				bPeakEdit = False
				peakCurveIndex = -1
			End If
		End Sub

		Public Sub EnableShowPeakInfo(CurveIndex As Integer, Flag As Boolean)
			If Flag Then
				bPeakInfo = True
				peakInfoCurveIndex = CurveIndex
				'Store all the pixels of courve in array
				Me.peakInfoX.Clear()
				Me.peakInfoY.Clear()
				Me.CurveList(CurveIndex).InsertCurvePixels(Me, peakInfoX, peakInfoY)
			Else
				Me.peakInfoX.Clear()
				Me.peakInfoY.Clear()
				bPeakInfo = False
				peakInfoCurveIndex = -1
			End If
		End Sub

		Public Sub New(paneRect As RectangleF, paneTitle As String, xTitle As String, yTitle As String, objAld As AldysGraph)
			statusflag = True
			bPeakEdit = False
			cursor = Cursors.NoMove2D
			Me.peakX = New ArrayList()
			Me.peakY = New ArrayList()

			'Added By Mangesh S. on 25-Nov-2006
			peakInfoX = New ArrayList()
			peakInfoY = New ArrayList()
			'Added By Mangesh S. on 25-Nov-2006

			Me.m_paneRect = paneRect
			Me.m_axisRect = m_axisRect
			m_xAxis = New XAxis()
			m_yAxis = New YAxis()
			m_legend = New Legend()
			m_curveList = New CurveList()
			m_textList = New TextList()
			m_arrowList = New ArrowList()
			m_xAxis.Title = xTitle
			m_yAxis.Title = xTitle
			Me.m_title = paneTitle
			Me.m_isShowTitle = Defaults.Pane.ShowTitle
			Me.m_fontSpec = New FontSpecs(Defaults.Pane.FontFamily, Defaults.Pane.FontSize, Defaults.Pane.FontColor, Defaults.Pane.FontBold, Defaults.Pane.FontItalic, Defaults.Pane.FontUnderline)
			Me.m_fontSpec.IsFilled = False
			Me.m_fontSpec.IsFramed = False

			Me.m_isIgnoreInitial = Defaults.Axis.IgnoreInitial

			Me.m_isPaneFramed = Defaults.Pane.IsFramed
			Me.m_paneFrameColor = Defaults.Pane.FrameColor
			Me.m_paneFramePenWidth = Defaults.Pane.FramePenWidth
			Me.m_paneBackColor = Defaults.Pane.BackColor

			Me.m_isAxisFramed = Defaults.Axis.IsFramed
			Me.m_axisFrameColor = Defaults.Axis.FrameColor
			Me.m_axisFramePenWidth = Defaults.Axis.FramePenWidth
			Me.m_axisBackColor = Defaults.Axis.BackColor

			Me.m_baseDimension = Defaults.Pane.BaseDimension
			Me.m_paneGap = Defaults.Pane.Gap
			Me.objAldysGraphTmp = objAld
		End Sub

		'		public AldysPane()
		'		{
		'			//
		'			// TODO: Add constructor logic here
		'			//
		'		}
		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The GraphPane object from which to copy</param>
		Public Sub New(rhs As AldysPane)
			statusflag = rhs.statusflag
			bPeakEdit = rhs.bPeakEdit
			cursor = Cursors.NoMove2D
			Me.peakX = rhs.peakX
			Me.peakY = rhs.peakY

			'Added By Mangesh S. on 25-Nov-2006
			Me.peakInfoX = rhs.peakInfoX
			Me.peakInfoY = rhs.peakInfoY
			'Added By Mangesh S. on 25-Nov-2006

			m_paneRect = rhs.PaneRect
			m_axisRect = rhs.AxisRect
			m_xAxis = New XAxis(rhs.XAxis)
			m_yAxis = New YAxis(rhs.YAxis)
			m_legend = New Legend(rhs.Legend)
			m_curveList = New CurveList(rhs.CurveList)
			m_textList = New TextList(rhs.TextList)
			m_arrowList = New ArrowList(rhs.ArrowList)

			Me.m_title = rhs.Title
			Me.m_isShowTitle = rhs.IsShowTitle
			Me.m_fontSpec = New FontSpecs(rhs.fontSpec)

			Me.m_isIgnoreInitial = rhs.IsIgnoreInitial

			Me.m_isPaneFramed = rhs.IsPaneFramed
			Me.m_paneFrameColor = rhs.PaneFrameColor
			Me.m_paneFramePenWidth = rhs.PaneFramePenWidth
			Me.m_paneBackColor = rhs.PaneBackColor

			Me.m_isAxisFramed = rhs.IsAxisFramed
			Me.m_axisFrameColor = rhs.AxisFrameColor
			Me.m_axisFramePenWidth = rhs.AxisFramePenWidth
			Me.m_axisBackColor = rhs.AxisBackColor

			Me.m_baseDimension = rhs.BaseDimension
			Me.m_paneGap = rhs.PaneGap
			Me.objAldysGraphTmp = rhs.objAldysGraphTmp

			Me.ShowCurveLabels = rhs.ShowCurveLabels
		End Sub

		#region " ICloneable Members"
		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the AldysPane</returns>
		Public Function Clone() As Object
			' TODO:  Add AldysPane.Clone implementation
			Return New AldysPane(Me)
			'return null;
		End Function

		#end region



		''' <summary>
		''' Gets or sets the rectangle that defines the full area into which the
		''' <see cref="AldysPane"/> can be rendered.
		''' </summary>
		''' <value>The rectangle units are in screen pixels</value>
		Public Property PaneRect() As RectangleF
			Get
				Return m_paneRect
			End Get
			Set
				m_paneRect = value
			End Set
		End Property
		''' <summary>
		''' Gets a reference to the <see cref="FontSpec"/> class used to render
		''' the <see cref="GraphPane"/> <see cref="Title"/>
		''' </summary>
		Public ReadOnly Property FontSpec() As FontSpecs
			Get
				Return m_fontSpec
			End Get
		End Property

		''' <summary>
		''' Gets the rectangle that contains the area bounded by the axes
		''' (<see cref="XAxis"/>, <see cref="YAxis"/>, and <see cref="Y2Axis"/>)
		''' </summary>
		''' <value>The rectangle units are in screen pixels</value>
		Public Property AxisRect() As RectangleF
			Get
				Return m_axisRect
			End Get
			Set
				m_axisRect = value
			End Set
		End Property

		''' <summary>
		''' A boolean value that affects the data range that is considered
		''' for the automatic scale ranging.  If true, then initial data points where the Y value
		''' is zero are not included when automatically determining the scale <see cref="Axis.Min"/>,
		''' <see cref="Axis.Max"/>, and <see cref="Axis.Step"/> size.
		''' All data after the first non-zero Y value are included.
		''' </summary>
		Public Property IsIgnoreInitial() As Boolean
			Get
				Return m_isIgnoreInitial
			End Get
			Set
				m_isIgnoreInitial = value
			End Set
		End Property
		''' <summary>
		''' IsShowTitle is a boolean value that determines whether or not the pane title is displayed
		''' on the graph.  If true, the title is displayed.  If false, the title is omitted, and the
		''' screen space that would be occupied by the title is added to the axis area.
		''' </summary>
		Public Property IsShowTitle() As Boolean
			Get
				Return m_isShowTitle
			End Get
			Set
				m_isShowTitle = value
			End Set
		End Property

		''' <summary>
		''' Title is a string representing the pane title text.  This text can be multiple lines,
		''' separated by newline characters ('\n').
		''' </summary>
		''' <seealso cref="FontSpec"/>
		Public Property Title() As String
			Get
				Return m_title
			End Get
			Set
				m_title = value
			End Set
		End Property
		''' <summary>
		''' IsShowPaneFrame is a boolean value that determines whether or not a frame border is drawn
		''' around the <see cref="AldysPane"/> area (<see cref="PaneRect"/>).
		''' True to draw the frame, false otherwise.
		''' </summary>
		Public Property IsPaneFramed() As Boolean
			Get
				Return m_isPaneFramed
			End Get
			Set
				m_isPaneFramed = value
			End Set
		End Property
		''' <summary>
		''' Frame color is a <see cref="System.Drawing.Color"/> specification
		''' for the <see cref="AldysPane"/> frame border.
		''' </summary>
		Public Property PaneFrameColor() As Color
			Get
				Return m_paneFrameColor
			End Get
			Set
				m_paneFrameColor = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets the <see cref="System.Drawing.Color"/> specification
		''' for the <see cref="AldysPane"/> pane background, which is the
		''' area behind the <see cref="AldysPane.PaneRect"/>.
		''' </summary>
		Public Property PaneBackColor() As Color
			Get
				Return m_paneBackColor
			End Get
			Set
				m_paneBackColor = value
			End Set
		End Property
		''' <summary>
		''' FrameWidth is a float value indicating the width (thickness) of the
		''' <see cref="AldysPane"/> frame border.
		''' </summary>
		Public Property PaneFramePenWidth() As Single
			Get
				Return m_paneFramePenWidth
			End Get
			Set
				m_paneFramePenWidth = value
			End Set
		End Property
		''' <summary>
		''' IsAxisFramed is a boolean value that determines whether or not a frame border is drawn
		''' around the axis area (<see cref="AxisRect"/>).
		''' </summary>
		''' <value>true to draw the frame, false otherwise. </value>
		Public Property IsAxisFramed() As Boolean
			Get
				Return m_isAxisFramed
			End Get
			Set
				m_isAxisFramed = value
			End Set
		End Property
		''' <summary>
		''' Frame color is a <see cref="System.Drawing.Color"/> specification
		''' for the axis frame border.
		''' </summary>
		Public Property AxisFrameColor() As Color
			Get
				Return m_axisFrameColor
			End Get
			Set
				m_axisFrameColor = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets the <see cref="System.Drawing.Color"/> specification
		''' for the <see cref="Axis"/> background, which is the
		''' area behind the <see cref="AldysPane.AxisRect"/>.
		''' </summary>
		Public Property AxisBackColor() As Color
			Get
				Return m_axisBackColor
			End Get
			Set
				m_axisBackColor = value
			End Set
		End Property
		''' <summary>
		''' FrameWidth is a float value indicating the width (thickness) of the axis frame border.
		''' </summary>
		''' <value>A pen width dimension in pixel units</value>
		Public Property AxisFramePenWidth() As Single
			Get
				Return m_axisFramePenWidth
			End Get
			Set
				m_axisFramePenWidth = value
			End Set
		End Property
		''' <summary>
		''' PaneGap is a float value that sets the margin area between the edge of the
		''' <see cref="AldysPane"/> rectangle (<see cref="PaneRect"/>)
		''' and the features of the graph.
		''' </summary>
		''' <value>This value is in units of pixels, and is scaled
		''' linearly with the graph size.</value>
		Public Property PaneGap() As Single
			Get
				Return m_paneGap
			End Get
			Set
				m_paneGap = value
			End Set
		End Property
		''' <summary>
		''' BaseDimension is a double precision value that sets "normal" plot size on
		''' which all the settings are based.  The BaseDimension is in inches.  For
		''' example, if the BaseDimension is 8.0 inches and the <see cref="AldysPane"/>
		''' <see cref="Title"/> size is 14 points.  Then the pane title font
		''' will be 14 points high when the <see cref="PaneRect"/> is approximately 8.0
		''' inches wide.  If the PaneRect is 4.0 inches wide, the pane title font will be
		''' 7 points high.  Most features of the graph are scaled in this manner.
		''' </summary>
		''' <value>The base dimension reference for the <see cref="AldysPane"/>, in inches</value>
		Public Property BaseDimension() As Double
			Get
				Return m_baseDimension
			End Get
			Set
				m_baseDimension = value
			End Set
		End Property

		''' <summary>
		''' ScaledGap is a simple utility routine that calculates the <see cref="PaneGap"/> scaled
		''' to the "scaleFactor" fraction.  That is, ScaledGap = PaneGap * scaleFactor
		''' </summary>
		''' <param name="scaleFactor">
		''' The scaling factor for the features of the graph based on the <see cref="BaseDimension"/>.  This
		''' scaling factor is calculated by the <see cref="CalcScaleFactor"/> method.  The scale factor
		''' represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' </param>
		''' <returns>Returns the paneGap size, in pixels, after scaling according to
		''' <paramref name="scalefactor"/></returns>
		Public Function ScaledGap(scaleFactor As Double) As Single
			Return DirectCast(Me.m_paneGap * scaleFactor, Single)
		End Function
		''' <summary>
		''' Draw all elements in the <see cref="AldysPane"/> to the specified graphics device.  This routine
		''' should be part of the Paint() update process.  Calling this routine will redraw all
		''' features of the graph.  No preparation is required other than an instantiated
		''' <see cref="AldysPane"/> object.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' 
		''' <summary>
		''' Accesses the <see cref="XAxis"/> for this graph
		''' </summary>
		''' <value>A reference to a <see cref="XAxis"/> object</value>
		Public ReadOnly Property XAxis() As XAxis
			Get
				Return m_xAxis
			End Get
		End Property

		Public ReadOnly Property YAxis() As YAxis
			Get
				Return m_yAxis
			End Get
		End Property

		''' <summary>
		''' Gets or sets the list of <see cref="TextItem"/> items for this <see cref="GraphPane"/>
		''' </summary>
		''' <value>A reference to a <see cref="TextList"/> collection object</value>
		Public Property TextList() As TextList
			Get
				Return m_textList
			End Get
			Set
				m_textList = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the list of <see cref="ArrowItem"/> items for this <see cref="GraphPane"/>
		''' </summary>
		''' <value>A reference to an <see cref="ArrowList"/> collection object</value>
		Public Property ArrowList() As ArrowList
			Get
				Return m_arrowList
			End Get
			Set
				m_arrowList = value
			End Set
		End Property

		''' <summary>
		''' Accesses the <see cref="Legend"/> for this <see cref="GraphPane"/>
		''' </summary>
		''' <value>A reference to a <see cref="Legend"/> object</value>
		Public ReadOnly Property Legend() As Legend
			Get
				Return m_legend
			End Get
		End Property
		''' <summary>
		''' Gets or sets the list of <see cref="CurveItem"/> items for this <see cref="AldysPane"/>
		''' </summary>
		''' <value>A reference to a <see cref="CurveList"/> collection object</value>
		Public Property CurveList() As CurveList
			Get
				Return m_curveList
			End Get
			Set
				m_curveList = value
			End Set
		End Property

		Public TmpScalefactor As Double

		Public Function Draw(g As Graphics) As Boolean
			Try
				' calculate scaleFactor on "normal" pane size (BaseDimension)
				Dim scaleFactor As Double = Me.CalcScaleFactor(g)
				If Me.statusflag = False Then
					scaleFactor += 0.5F
				End If

				TmpScalefactor = scaleFactor

				' Calculate the axis rect, deducting the area for the scales, titles, legend, etc.
				Dim hStack As Integer
				Dim legendWidth As Single

				Me.CalcAxisRect(g, scaleFactor, hStack, legendWidth)

				' Frame the whole pane
				DrawPaneFrame(g)

				' Frame the axis itself
				DrawAxisFrame(g)

				DrawTitle(g, scaleFactor)

				If Me.m_xAxis.Min < Me.m_xAxis.Max AndAlso Me.m_yAxis.Min < Me.m_yAxis.Max Then
					' Clip everything to the paneRect
					g.SetClip(Me.m_paneRect)
					' Draw the Axes
					Me.m_xAxis.Draw(g, Me, scaleFactor)
					Me.m_yAxis.Draw(g, Me, scaleFactor)

					' Clip the points to the actual plot area
					g.SetClip(Me.m_axisRect)
					Me.m_curveList.Draw(g, Me, scaleFactor)
					g.SetClip(Me.m_paneRect)

					' Draw the Legend
					Me.m_legend.Draw(g, Me, scaleFactor, hStack, legendWidth)

					' Draw the Text Items
					Me.m_textList.Draw(g, Me, scaleFactor)

					' Draw the Arrows
					Me.m_arrowList.Draw(g, Me, scaleFactor)

					' Reset the clipping

					g.ResetClip()
				End If

				Return True
			Catch e As IndexOutOfRangeException
				Dim a As String
				a = e.Message
				'MessageBox.Show(e.Message);
				Return False
			Catch e As Exception
				Dim a As String
				a = e.Message
					'MessageBox.Show(e.Message ); 
					'MessageBox.Show("Error occured while drawing");
				Return False
			End Try
		End Function



		''' <summary>
		''' Calculate the <see cref="AxisRect"/> based on the <see cref="PaneRect"/>.  The axisRect
		''' is the plot area bounded by the axes, and the paneRect is the total area as
		''' specified by the client application.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor for the features of the graph based on the <see cref="BaseDimension"/>.  This
		''' scaling factor is calculated by the <see cref="CalcScaleFactor"/> method.  The scale factor
		''' represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' </param>
		''' <param name="hStack">
		''' The number of legend columns to use for horizontal legend stacking.  This is a temporary
		''' variable calculated by the routine for use in the Legend.Draw method.
		''' </param>
		''' <param name="legendWidth">
		''' The wide of a single legend entry, in pixel units.  This is a temporary
		''' variable calculated by the routine for use in the Legend.Draw method.
		''' </param>
		Public Sub CalcAxisRect(g As Graphics, scaleFactor As Double, ByRef hStack As Integer, ByRef legendWidth As Single)
			' get scaled values for the paneGap and character height
			Dim gap As Single = 0F
			'gap=this.ScaledGap( scaleFactor);
			gap = Me.ScaledGap(scaleFactor + 1)



			Dim charHeight As Single = Me.m_fontSpec.GetHeight(scaleFactor)
			hStack = 0
			legendWidth = 0



			' Axis rect starts out at the full pane rect.  It gets reduced to make room for the legend,
			' scales, titles, etc.
			Me.m_axisRect = Me.m_paneRect

			' Calculate the areas required for the X, Y, and Y2 axes, and reduce the AxisRect by
			' these amounts.
			'			this.xAxis.CalcRect( g, this, scaleFactor );
			'			this.yAxis.CalcRect( g, this, scaleFactor );
			'			this.y2Axis.CalcRect( g, this, scaleFactor );

			Dim space As Single = Me.m_xAxis.CalcSpace(g, Me, scaleFactor)
			Me.m_axisRect.Height -= space
			space = Me.m_yAxis.CalcSpace(g, Me, scaleFactor)
			Me.m_axisRect.X += space
			Me.m_axisRect.Width -= space
			'''///			space = this.y2Axis.CalcSpace( g, this, scaleFactor );
			Me.m_axisRect.Width -= space
			'''///	
			' Always leave a gap on top, even with no title
			Me.m_axisRect.Y += gap
			Me.m_axisRect.Height -= gap
			'''///
			' Leave room for the pane title
			If Me.m_isShowTitle Then
				Dim titleSize As SizeF = Me.m_fontSpec.MeasureString(g, Me.m_title, scaleFactor)
				' Leave room for the title height, plus a line spacing of charHeight/2
				Me.m_axisRect.Y += titleSize.Height + charHeight / 2F
				Me.m_axisRect.Height -= titleSize.Height + charHeight / 2F
			End If

			'''///			// Calculate the legend rect, and back it out of the current axisRect
			Me.m_legend.CalcRect(g, Me, scaleFactor, Me.m_axisRect, hStack, legendWidth)
		End Sub


		''' <summary>
		''' Calculate the scaling factor based on the ratio of the current <see cref="PaneRect"/> dimensions and
		''' the <see cref="BaseDimension"/>.  This scaling factor is used to proportionally scale the
		''' features of the <see cref="AldysPane"/> so that small graphs don't have huge fonts, and vice versa.
		''' The scale factor represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <returns>
		''' A double precision value representing the scaling factor to use for the rendering calculations.
		''' </returns>
		Protected Function CalcScaleFactor(g As Graphics) As Double
			Dim scaleFactor As Double
			Const  ASPECTLIMIT As Double = 2.0

			' Assume the standard width (BaseDimension) is 8.0 inches
			' Therefore, if the paneRect is 8.0 inches wide, then the fonts will be scaled at 1.0
			' if the paneRect is 4.0 inches wide, the fonts will be half-sized.
			' if the paneRect is 16.0 inches wide, the fonts will be double-sized.

			' determine the size of the paneRect in inches
			Dim xInch As Double = DirectCast(Me.m_paneRect.Width, Double) / DirectCast(g.DpiX, Double)
			Dim yInch As Double = DirectCast(Me.m_paneRect.Height, Double) / DirectCast(g.DpiY, Double)

			' Limit the aspect ratio so long plots don't have outrageous font sizes
			Dim aspect As Double = DirectCast(xInch, Double) / DirectCast(yInch, Double)
			If aspect > ASPECTLIMIT Then
				xInch = yInch * ASPECTLIMIT
			End If

			' Scale the size depending on the client area width in linear fashion
			scaleFactor = DirectCast(xInch, Double) / Me.m_baseDimension

			' Don't let the scaleFactor get ridiculous
			If scaleFactor < 0.1 Then
				scaleFactor = 0.1
			End If

			Return scaleFactor
		End Function
		''' <summary>
		''' Draw the frame border around the <see cref="PaneRect"/> area.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		Public Sub DrawPaneFrame(g As Graphics)
			' Erase the pane background
			Dim brush As New SolidBrush(Me.m_paneBackColor)
			g.FillRectangle(brush, Me.m_paneRect)

			Dim tempRect As RectangleF = Me.m_paneRect
			tempRect.Width -= 1
			tempRect.Height -= 1

			If Me.m_isPaneFramed Then
				Dim pen As New Pen(Me.m_paneFrameColor, Me.m_paneFramePenWidth)

				g.DrawRectangle(pen, Rectangle.Round(tempRect))
			End If
		End Sub
		''' <summary>
		''' Draw the frame border around the <see cref="AxisRect"/> area.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		Public Sub DrawAxisFrame(g As Graphics)
			' Erase the axis background
			Dim brush As New SolidBrush(Me.m_axisBackColor)
			g.FillRectangle(brush, Me.m_axisRect)

			If Me.m_isAxisFramed Then
				Dim pen As New Pen(Me.m_axisFrameColor, Me.m_axisFramePenWidth)
				g.DrawRectangle(pen, Rectangle.Round(Me.m_axisRect))
			End If
		End Sub

		''' <summary>
		''' Draw the <see cref="AldysPane"/> <see cref="Title"/> on the graph
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor for the features of the graph based on the <see cref="BaseDimension"/>.  This
		''' scaling factor is calculated by the <see cref="CalcScaleFactor"/> method.  The scale factor
		''' represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		''' </param>		
		''' 

		Public Sub DrawTitle(g As Graphics, scaleFactor As Double)
			' only draw the title if it's required

			If Me.m_isShowTitle Then
				' use the internal fontSpec class to draw the text using user-specified and/or
				' default attributes.
				Me.m_fontSpec.Draw(g, Me.m_title, (Me.m_paneRect.Left + Me.m_paneRect.Right) / 2, Me.m_paneRect.Top + Me.ScaledGap(scaleFactor), FontAlignH.Center, FontAlignV.Top, _
					scaleFactor)
			End If
		End Sub

		''' <summary>
		''' Add a curve (<see cref="CurveItem"/> object) to the plot with
		''' the given data points and properties.
		''' This is simplified way to add curves without knowledge of the
		''' <see cref="CurveList"/> class.  An alternative is to use
		''' the <see cref="ZedGraph.CurveList.Add"/> method.
		''' </summary>
		''' <param name="label">The text label (string) for the curve that will be
		''' used as a <see cref="Legend"/> entry.</param>
		''' <param name="x">An array of double precision X values (the
		''' independent values) that define the curve.</param>
		''' <param name="y">An array of double precision Y values (the
		''' dependent values) that define the curve.</param>
		''' <param name="color">The color to used for the curve line,
		''' symbols, etc.</param>
		''' <param name="symbolType">A symbol type (<see cref="SymbolType"/>)
		''' that will be used for this curve.</param>
		''' <returns>A <see cref="CurveItem"/> class for the newly created curve.
		''' This can then be used to access all of the curve properties that
		''' are not defined as arguments to the <see cref="AddCurve"/> method.</returns>
		Public Function AddCurve(label As String, x As ArrayList, y As ArrayList, color As Color, symbolType As SymbolType) As CurveItem
			Dim curve As New CurveItem(label, x, y)
			curve.Line.Color = color
			curve.Symbol.Color = color
			curve.Symbol.Type = symbolType
			Me.m_curveList.Add(curve)

			Return curve
		End Function
		Public Function AddCurve(label As String, x As ArrayList, y As ArrayList, color As Color, symbolType As SymbolType, cl As ArrayList, _
			sym As ArrayList) As CurveItem
			Dim curve As New CurveItem(label, x, y, cl, sym)
			curve.Line.Color = color
			curve.Symbol.Color = color
			curve.Symbol.Type = symbolType
			Me.m_curveList.Add(curve)

			Return curve
		End Function
		'		public CurveItem AddDigitalCurve( string label, double x,
		'			Color color)
		'		{
		'			ArrayList x1 = new ArrayList();
		'			ArrayList y1 = new ArrayList();
		'			ArrayList cl1 = new ArrayList();
		'			ArrayList sym1 = new ArrayList();
		'			x1.Add(x);
		'			y1.Add(this.YAxis.Min +(2*this.YAxis.MinorStep));
		'			cl1.Add(color);
		'			sym1.Add(SymbolType.NoSymbol);
		'
		'
		'			CurveItem curve = new CurveItem( label,x1,y1 ,cl1,sym1 );
		'			curve.AddPointFlg = true;
		'			curve.Line.Color = color;
		'			curve.Symbol.Color = color;
		'			curve.Symbol.Type = SymbolType.NoSymbol;
		'			this.curveList.Add( curve );
		'			return curve;
		'			
		'
		'		}
		'		public void AddPointInDigitalCurve(int CurveIndex, double x, int Bit,
		'			Color color )
		'		{
		'			
		'			if(this.curveList[CurveIndex].AddPointFlg)
		'			{
		'				this.curveList[CurveIndex].X.Add(x);
		'				if(Bit == 1)
		'				{
		'					this.curveList[CurveIndex].Y.Add(this.YAxis.Min +(4*this.YAxis.MinorStep));
		'				}
		'				else
		'				{
		'					this.curveList[CurveIndex].Y.Add(this.YAxis.Min +(2*this.YAxis.MinorStep));
		'				}
		'				
		'				this.curveList[CurveIndex].CL.Add(color);
		'				this.curveList[CurveIndex].SYM.Add(SymbolType.NoSymbol);
		'				Graphics gr = Graphics.FromHwnd(this.hwnd);
		'				gr.SetClip( this.axisRect );
		'				this.curveList[CurveIndex].Draw(gr,this,TmpScalefactor );
		'				gr.ResetClip();
		'				gr.Dispose();
		'			}		
		'		}

		Public Function AddCurveWithPoint(label As String, x As Double, y As Double, color As Color, symbolType As SymbolType) As CurveItem

			Dim x1 As New ArrayList()
			Dim y1 As New ArrayList()
			Dim cl1 As New ArrayList()
			Dim sym1 As New ArrayList()
			x1.Add(x)
			y1.Add(y)
			cl1.Add(color)
			sym1.Add(symbolType)

			Dim curve As New CurveItem(label, x1, y1, cl1, sym1)
			curve.AddPointFlg = True
			curve.Line.Color = color
			curve.Symbol.Color = color
			curve.Symbol.Type = symbolType
			Me.m_curveList.Add(curve)

			Return curve
		End Function


		Public Sub AddPointInCurve(CurveIndex As Integer, label As String, x As Double, y As Double, color As Color, symbolType As SymbolType)
			If Me.m_curveList(CurveIndex).AddPointFlg Then
				Me.m_curveList(CurveIndex).X.Add(x)
				Me.m_curveList(CurveIndex).Y.Add(y)
				Me.m_curveList(CurveIndex).CL.Add(color)
				Me.m_curveList(CurveIndex).SYM.Add(symbolType)
				Dim gr As Graphics = Graphics.FromHwnd(Me.hwnd)
				gr.SetClip(Me.m_axisRect)

				Me.m_curveList(CurveIndex).Draw(gr, Me, TmpScalefactor)

				gr.ResetClip()
				gr.Dispose()
			End If
		End Sub


		''' <summary>
		''' Transform a data point from the specified coordinate type
		''' (<see cref="CoordType"/>) to screen coordinates (pixels).
		''' </summary>
		''' <param name="ptF">The X,Y pair that defines the point in user
		''' coordinates.</param>
		''' <param name="coord">A <see cref="CoordType"/> type that defines the
		''' coordinate system in which the X,Y pair is defined.</param>
		''' <returns>A point in screen coordinates that corresponds to the
		''' specified user point.</returns>
		Public Function GeneralTransform(ptF As PointF, coord As CoordType) As PointF
			Dim ptPix As New PointF()

			If coord = CoordType.AxisFraction Then
				ptPix.X = Me.m_axisRect.Left + ptF.X * Me.m_axisRect.Width
				ptPix.Y = Me.m_axisRect.Top + ptF.Y * Me.m_axisRect.Height
			ElseIf coord = CoordType.AxisXYScale Then
				ptPix.X = Me.m_xAxis.Transform(ptF.X)
				ptPix.Y = Me.m_yAxis.Transform(ptF.Y)
			ElseIf coord = CoordType.AxisXY2Scale Then
					'ptPix.Y = this.y2Axis.Transform( ptF.Y );
				ptPix.X = Me.m_xAxis.Transform(ptF.X)
			Else
				' PaneFraction
				ptPix.X = Me.m_paneRect.Left + ptF.X * Me.m_paneRect.Width
				ptPix.Y = Me.m_paneRect.Top + ptF.Y * Me.m_paneRect.Height
			End If

			Return ptPix
		End Function


		'Sachin Ashtankar 10 Oct 2005
		Public Sub ReverseTransform(ptF As PointF, ByRef x As Double, ByRef y As Double)
			'Setup the scaling data based on the axis rect
			Me.m_xAxis.SetupScaleData(Me)
			Me.m_yAxis.SetupScaleData(Me)

			x = Me.XAxis.TransformRev(ptF.X)
			y = Me.YAxis.TransformRev(ptF.Y)

		End Sub
		''' <summary>
		''' AxisChange causes the axes scale ranges to be recalculated based on the current data range.
		''' Call this function anytime you change, add, or remove curve data.  This routine calculates
		''' a scale minimum, maximum, and step size for each axis based on the current curve data.
		''' Only the axis attributes (min, max, step) that are set to auto-range (<see cref="Axis.MinAuto"/>,
		''' <see cref="Axis.MaxAuto"/>, <see cref="Axis.StepAuto"/>) will be modified.  You must call
		''' Invalidate() after calling AxisChange to make sure the display gets updated.
		''' </summary>
		Public Sub AxisChange()
			Dim xMin As Double, xMax As Double, yMin As Double, yMax As Double, y2Min As Double, y2Max As Double

			' Get the scale range of the data (all curves)
			Me.m_curveList.GetRange(xMin, xMax, yMin, yMax, y2Min, y2Max, _
				Me.m_isIgnoreInitial, Me)

			' Pick new scales based on the range
			Me.m_xAxis.PickScale(xMin, xMax)
			Me.m_yAxis.PickScale(yMin, yMax)
			'this.y2Axis.PickScale( y2Min, y2Max );
			'ChangeAxis = new MouseEventArgs(e.Button,e.Clicks,e.X,e.Y, e.Delta );     

		End Sub

		Public Sub DrawCurveLabels()
			Dim intCurveCount As Integer = 0
			Dim name As String
			Dim x As Double, y As Double

			If ShowCurveLabels = False Then
				Return
			End If

			Try
				'double dblInterval=((this.XAxis.Max - this.XAxis.Min)/this.CurveList.Count -1);
				'after commenting the above line , following block of code is 
				'written by deepak b. on 01.04.06

				'''/////////----------
				Dim LastPointOnCurve As Integer
				Dim XValueOfLastPointOnCurve As Double, MinXValueOfLastPointOnCurve As Double
				MinXValueOfLastPointOnCurve = 0.0
				For Each curve As CurveItem In CurveList
					LastPointOnCurve = curve.X.Count - 1
					XValueOfLastPointOnCurve = DirectCast(curve.X(LastPointOnCurve), Double)
					MinXValueOfLastPointOnCurve = XValueOfLastPointOnCurve
					If MinXValueOfLastPointOnCurve <= XValueOfLastPointOnCurve Then
						MinXValueOfLastPointOnCurve = XValueOfLastPointOnCurve
					End If
				Next

				Dim dblInterval As Double = ((MinXValueOfLastPointOnCurve - Me.XAxis.Min) / Me.CurveList.Count)
				'''/////////----------

				Dim dblFrom As Double, dblTo As Double
				dblFrom = Me.XAxis.Min
				dblTo = dblFrom + dblInterval

				For Each curve As CurveItem In CurveList
					Dim blnDrawn As Boolean = False
					curve.LabelX = curve.Label
					curve.Label += "(" + intCurveCount.ToString() + ")"

					name = intCurveCount.ToString()

					Dim intCount As Integer = 0
					While intCount <= curve.X.Count - 1
						If DirectCast(curve.X(intCount), Double) >= dblFrom AndAlso DirectCast(curve.X(intCount), Double) <= dblTo Then
							x = DirectCast(curve.X(intCount), Double)
							y = DirectCast(curve.Y(intCount), Double)

							Dim text As New TextItem(name, DirectCast(x, Single), DirectCast(y, Single))
							text.CoordinateFrame = CoordType.AxisXYScale
							text.AlignH = FontAlignH.Center
							text.AlignV = FontAlignV.Bottom
							If CurveLabelSize <> 0 Then
								text.FontSpec.Size = CurveLabelSize
							End If
							text.ForCurveLabel = True
							text.FontSpec.IsFramed = True
							text.FontSpec.FontColor = curve.Line.Color
							TextList.Add(text)

							intCurveCount += 1
							dblFrom = dblTo
							dblTo = dblFrom + dblInterval

							blnDrawn = True
							Exit While
						End If
						blnDrawn = False
						System.Math.Max(System.Threading.Interlocked.Increment(intCount),intCount - 1)
					End While
					If blnDrawn = False Then
						'this if block is written by deepak b. on 01.04.06
						Dim LastPointBeforeEdge As Integer = 0
						Dim intCount As Integer = curve.X.Count - 1
						While intCount >= 0
									'Do nothing
							If DirectCast(curve.X(intCount), Double) < Me.XAxis.Min OrElse DirectCast(curve.X(intCount), Double) > Me.XAxis.Max OrElse DirectCast(curve.Y(intCount), Double) < Me.YAxis.Min OrElse DirectCast(curve.Y(intCount), Double) > Me.YAxis.Max Then
							Else
								LastPointBeforeEdge = intCount
								Exit While
							End If
							System.Math.Max(System.Threading.Interlocked.Decrement(intCount),intCount + 1)
						End While

						x = DirectCast(curve.X(LastPointBeforeEdge), Double)
						y = DirectCast(curve.Y(LastPointBeforeEdge), Double)

						Dim text As New TextItem(name, DirectCast(x, Single), DirectCast(y, Single))
						text.CoordinateFrame = CoordType.AxisXYScale
						text.AlignH = FontAlignH.Center
						text.AlignV = FontAlignV.Bottom
						text.ForCurveLabel = True
						If CurveLabelSize <> 0 Then
							text.FontSpec.Size = CurveLabelSize
						End If
						text.FontSpec.IsFramed = True
						text.FontSpec.FontColor = curve.Line.Color
						TextList.Add(text)


						intCurveCount += 1
					End If
				Next
			Catch
			Finally
			End Try

		End Sub

	End Class
End Namespace
