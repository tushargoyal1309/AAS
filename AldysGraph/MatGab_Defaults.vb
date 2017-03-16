Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace AldysGraph
	Public Structure Defaults
		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="ZedGraph.Line"/> class.
		''' </summary>
		Public Structure Line
			' Default Line properties
			''' <summary>
			''' The default color for curves (line segments connecting the points).
			''' This is the default value for the <see cref="Line.Color"/> property.
			''' </summary>
			Public Shared Color As Color = Color.Red
			''' <summary>
			''' The default mode for displaying line segments (<see cref="Line.IsVisible"/>
			''' property).  True to show the line segments, false to hide them.
			''' </summary>
			Public Shared IsVisible As Boolean = True
			''' <summary>
			''' The default width for line segments (<see cref="Line.Width"/> property).
			''' Units are pixels.
			''' </summary>
			Public Shared Width As Single = 1
			''' <summary>
			''' The default drawing style for line segments (<see cref="Line.Style"/> property).
			''' This is defined with the <see cref="DashStyle"/> enumeration.
			''' </summary>
			Public Shared Style As DashStyle = DashStyle.Solid
			''' <summary>
			''' Default value for the curve type property
			''' (<see cref="Line.StepType"/>).  This determines if the curve
			''' will be drawn by directly connecting the points from the
			''' <see cref="CurveItem.X"/> and <see cref="CurveItem.Y"/> data arrays,
			''' or if the curve will be a "stair-step" in which the points are
			''' connected by a series of horizontal and vertical lines that
			''' represent discrete, staticant values.  Note that the values can
			''' be forward oriented <code>ForwardStep</code> (<see cref="StepType"/>) or
			''' rearward oriented <code>RearwardStep</code>.
			''' That is, the points are defined at the beginning or end
			''' of the staticant value for which they apply, respectively.
			''' </summary>
			''' <value><see cref="StepType"/> enum value</value>
			Public Shared Type As StepType = StepType.NonStep
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="ZedGraph.Symbol"/> class.
		''' </summary>
		Public Structure Symbol
			' Default Symbol properties
			''' <summary>
			''' The default size for curve symbols (<see cref="Symbol.Size"/> property),
			''' in units of points.
			''' </summary>
			Public Shared Size As Single = 7
			''' <summary>
			''' The default pen width to be used for drawing curve symbols
			''' (<see cref="Symbol.PenWidth"/> property).  Units are points.
			''' </summary>
			Public Shared PenWidth As Single = 1F
			''' <summary>
			''' The default fill mode for symbols (<see cref="Symbol.IsFilled"/> property).
			''' true to have symbols filled in with color, false to leave them as outlines.
			''' </summary>
			Public Shared IsFilled As Boolean = False
			''' <summary>
			''' The default symbol type for curves (<see cref="Symbol.Type"/> property).
			''' This is defined as a <see cref="ZedGraph.SymbolType"/> enumeration.
			''' </summary>
			Public Shared Type As SymbolType = SymbolType.Square
			''' <summary>
			''' The default display mode for symbols (<see cref="Symbol.IsVisible"/> property).
			''' true to display symbols, false to hide them.
			''' </summary>
			Public Shared IsVisible As Boolean = True
			''' <summary>
			''' The default color for drawing symbols (<see cref="Symbol.Color"/> property).
			''' </summary>
			Public Shared Color As Color = Color.Red
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="AldysPane"/> class.
		''' </summary>
		Public Structure Pane
			' Default AldysPane properties
			''' <summary>
			''' The default display mode for the title at the top of the pane
			''' (<see cref="AldysPane.IsShowTitle"/> property).  true to
			''' display a title, false otherwise.
			''' </summary>
			Public Shared ShowTitle As Boolean = True
			''' <summary>
			''' The default font family for the pane title
			''' (<see cref="AldysPane.Title"/> property).
			''' </summary>
			Public Shared FontFamily As String = "Arial"
			''' <summary>
			''' The default font size (points) for the
			''' <see cref="AldysPane"/> pane title
			''' (<see cref="FontSpec.Size"/> property).
			''' </summary>
			Public Shared FontSize As Single = 16
			''' <summary>
			''' The default font color for the
			''' <see cref="AldysPane"/> pane title
			''' (<see cref="FontSpec.FontColor"/> property).
			''' </summary>
			Public Shared FontColor As Color = Color.Black
			''' <summary>
			''' The default font bold mode for the
			''' <see cref="AldysPane"/> pane title
			''' (<see cref="FontSpec.IsBold"/> property). true
			''' for a bold typeface, false otherwise.
			''' </summary>
			Public Shared FontBold As Boolean = True
			''' <summary>
			''' The default font italic mode for the
			''' <see cref="AldysPane"/> pane title
			''' (<see cref="FontSpec.IsItalic"/> property). true
			''' for an italic typeface, false otherwise.
			''' </summary>
			Public Shared FontItalic As Boolean = False
			''' <summary>
			''' The default font underline mode for the
			''' <see cref="AldysPane"/> pane title
			''' (<see cref="FontSpec.IsUnderline"/> property). true
			''' for an underlined typeface, false otherwise.
			''' </summary>
			Public Shared FontUnderline As Boolean = False

			'		public static bool stepPlot = false;
			''' <summary>
			''' The default frame mode for the <see cref="AldysPane"/>.
			''' (<see cref="AldysPane.IsPaneFramed"/> property). true
			''' to draw a frame around the <see cref="AldysPane.PaneRect"/>,
			''' false otherwise.
			''' </summary>
			Public Shared IsFramed As Boolean = True
			''' <summary>
			''' The default color for the <see cref="AldysPane"/> frame border.
			''' (<see cref="AldysPane.PaneFrameColor"/> property). 
			''' </summary>
			Public Shared FrameColor As Color = Color.Black
			''' <summary>
			''' The default color for the <see cref="AldysPane.PaneRect"/> background.
			''' (<see cref="AldysPane.PaneBackColor"/> property). 
			''' </summary>
			Public Shared BackColor As Color = Color.White
			''' <summary>
			''' The default pen width for the <see cref="AldysPane"/> frame border.
			''' (<see cref="AldysPane.PaneFramePenWidth"/> property).  Units are in pixels.
			''' </summary>
			Public Shared FramePenWidth As Single = 1

			''' <summary>
			''' The default value for the <see cref="AldysPane.PaneGap"/> property.
			''' This is the size of the margin around the edge of the
			''' <see cref="AldysPane.PaneRect"/>, in units of pixels.
			''' </summary>
			Public Shared Gap As Single = 20
			''' <summary>
			''' The default dimension of the <see cref="AldysPane.PaneRect"/>, which
			''' defines a normal sized plot.  This dimension is used to scale the
			''' fonts, symbols, etc. according to the actual size of the
			''' <see cref="AldysPane.PaneRect"/>.
			''' </summary>
			''' <seealso cref="AldysPane.CalcScaleFactor"/>
			Public Shared BaseDimension As Double = 8.0
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="ZedGraph.Legend"/> class.
		''' </summary>
		Public Structure Legend
			' Default Legend properties
			''' <summary>
			''' The default pen width for the <see cref="Legend"/> frame border.
			''' (<see cref="Legend.FrameWidth"/> property).  Units are in pixels.
			''' </summary>
			Public Shared FrameWidth As Single = 1
			''' <summary>
			''' The default color for the <see cref="Legend"/> frame border.
			''' (<see cref="Legend.FrameColor"/> property). 
			''' </summary>
			Public Shared FrameColor As Color = Color.Black
			''' <summary>
			''' The default color for the <see cref="Legend"/> background.
			''' (<see cref="Legend.FillColor"/> property).  Use of this
			''' color depends on the status of the <see cref="Legend.IsFilled"/>
			''' property.
			''' </summary>
			Public Shared FillColor As Color = Color.White
			''' <summary>
			''' The default location for the <see cref="Legend"/> on the graph
			''' (<see cref="Legend.Location"/> property).  This property is
			''' defined as a <see cref="LegendLoc"/> enumeration.
			''' </summary>
			Public Shared Location As LegendLoc = LegendLoc.Top
			''' <summary>
			''' The default frame mode for the <see cref="Legend"/>.
			''' (<see cref="Legend.IsFramed"/> property). true
			''' to draw a frame around the <see cref="Legend.Rect"/>,
			''' false otherwise.
			''' </summary>
			Public Shared IsFramed As Boolean = True
			''' <summary>
			''' The default display mode for the <see cref="Legend"/>.
			''' (<see cref="Legend.IsVisible"/> property). true
			''' to show the legend,
			''' false to hide it.
			''' </summary>
			Public Shared IsVisible As Boolean = True
			''' <summary>
			''' The default fill mode for the <see cref="Legend"/> background
			''' (<see cref="Legend.IsFilled"/> property).
			''' true to fill-in the background with color,
			''' false to leave the background transparent.
			''' </summary>
			Public Shared IsFilled As Boolean = True
			''' <summary>
			''' The default horizontal stacking mode for the <see cref="Legend"/>
			''' (<see cref="Legend.IsHStack"/> property).
			''' true to allow horizontal legend item stacking, false to allow
			''' only vertical legend orientation.
			''' </summary>
			Public Shared HStack As Boolean = True

			''' <summary>
			''' The default font family for the <see cref="Legend"/> entries
			''' (<see cref="FontSpec.Family"/> property).
			''' </summary>
			Public Shared FontFamily As String = "Arial"
			''' <summary>
			''' The default font size for the <see cref="Legend"/> entries
			''' (<see cref="FontSpec.Size"/> property).  Units are
			''' in points (1/72 inch).
			''' </summary>
			Public Shared FontSize As Single = 12
			''' <summary>
			''' The default font color for the <see cref="Legend"/> entries
			''' (<see cref="FontSpec.FontColor"/> property).
			''' </summary>
			Public Shared FontColor As Color = Color.Black
			''' <summary>
			''' The default font bold mode for the <see cref="Legend"/> entries
			''' (<see cref="FontSpec.IsBold"/> property). true
			''' for a bold typeface, false otherwise.
			''' </summary>
			Public Shared FontBold As Boolean = False
			''' <summary>
			''' The default font italic mode for the <see cref="Legend"/> entries
			''' (<see cref="FontSpec.IsItalic"/> property). true
			''' for an italic typeface, false otherwise.
			''' </summary>
			Public Shared FontItalic As Boolean = False
			''' <summary>
			''' The default font underline mode for the <see cref="Legend"/> entries
			''' (<see cref="FontSpec.IsUnderline"/> property). true
			''' for an underlined typeface, false otherwise.
			''' </summary>
			Public Shared FontUnderline As Boolean = False
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="Axis"/> class.
		''' </summary>
		Public Structure Axis
			' Default Axis Properties
			''' <summary>
			''' The default size for the <see cref="Axis"/> tic marks.
			''' (<see cref="Axis.TicSize"/> property). Units are pixels.
			''' </summary>
			Public Shared TicSize As Single = 5
			''' <summary>
			''' The default size for the <see cref="Axis"/> minor tic marks.
			''' (<see cref="Axis.MinorTicSize"/> property). Units are pixels.
			''' </summary>
			Public Shared MinorTicSize As Single = 2.5F
			''' <summary>
			''' The default pen width for drawing the <see cref="Axis"/> tic marks.
			''' (<see cref="Axis.TicPenWidth"/> property). Units are pixels.
			''' </summary>
			Public Shared TicPenWidth As Single = 1F
			''' <summary>
			''' The default "zero lever" for automatically selecting the axis
			''' scale range (see <see cref="Axis.PickScale"/>). This number is
			''' used to determine when an axis scale range should be extended to
			''' include the zero value.  This value is maintained only in the
			''' <see cref="Def"/> class, and cannot be changed after compilation.
			''' </summary>
			Public Shared ZeroLever As Double = 0.25
			''' <summary>
			''' The default target number of steps for automatically selecting the axis
			''' scale step size (see <see cref="Axis.PickScale"/>).
			''' This number is an initial target value for the number of major steps
			''' on an axis.  This value is maintained only in the
			''' <see cref="Def"/> class, and cannot be changed after compilation.
			''' </summary>
			Public Shared TargetSteps As Double = 7.0
			''' <summary>
			''' The default target number of minor steps for automatically selecting the axis
			''' scale minor step size (see <see cref="Axis.PickScale"/>).
			''' This number is an initial target value for the number of minor steps
			''' on an axis.  This value is maintained only in the
			''' <see cref="Def"/> class, and cannot be changed after compilation.
			''' </summary>
			Public Shared TargetMinorSteps As Double = 5.0
			''' <summary>
			''' The default font family for the <see cref="Axis"/> scale values
			''' font specification <see cref="Axis.ScaleFontSpec"/>
			''' (<see cref="FontSpec.Family"/> property).
			''' </summary>
			Public Shared ScaleFontFamily As String = "Arial"
			''' <summary>
			''' The default font size for the <see cref="Axis"/> scale values
			''' font specification <see cref="Axis.ScaleFontSpec"/>
			''' (<see cref="FontSpec.Size"/> property).  Units are
			''' in points (1/72 inch).
			''' </summary>
			Public Shared ScaleFontSize As Single = 14
			''' <summary>
			''' The default font color for the <see cref="Axis"/> scale values
			''' font specification <see cref="Axis.ScaleFontSpec"/>
			''' (<see cref="FontSpec.FontColor"/> property).
			''' </summary>
			Public Shared ScaleFontColor As Color = Color.Black
			''' <summary>
			''' The default font bold mode for the <see cref="Axis"/> scale values
			''' font specification <see cref="Axis.ScaleFontSpec"/>
			''' (<see cref="FontSpec.IsBold"/> property). true
			''' for a bold typeface, false otherwise.
			''' </summary>
			Public Shared ScaleFontBold As Boolean = False
			''' <summary>
			''' The default font italic mode for the <see cref="Axis"/> scale values
			''' font specification <see cref="Axis.ScaleFontSpec"/>
			''' (<see cref="FontSpec.IsItalic"/> property). true
			''' for an italic typeface, false otherwise.
			''' </summary>
			Public Shared ScaleFontItalic As Boolean = False
			''' <summary>
			''' The default font underline mode for the <see cref="Axis"/> scale values
			''' font specification <see cref="Axis.ScaleFontSpec"/>
			''' (<see cref="FontSpec.IsUnderline"/> property). true
			''' for an underlined typeface, false otherwise.
			''' </summary>
			Public Shared ScaleFontUnderline As Boolean = False

			''' <summary>
			''' The default font family for the <see cref="Axis"/> title text
			''' font specification <see cref="Axis.TitleFontSpec"/>
			''' (<see cref="FontSpec.Family"/> property).
			''' </summary>
			Public Shared TitleFontFamily As String = "Arial"
			''' <summary>
			''' The default font size for the <see cref="Axis"/> title text
			''' font specification <see cref="Axis.TitleFontSpec"/>
			''' (<see cref="FontSpec.Size"/> property).  Units are
			''' in points (1/72 inch).
			''' </summary>
			Public Shared TitleFontSize As Single = 14
			''' <summary>
			''' The default font color for the <see cref="Axis"/> title text
			''' font specification <see cref="Axis.TitleFontSpec"/>
			''' (<see cref="FontSpec.FontColor"/> property).
			''' </summary>
			Public Shared TitleFontColor As Color = Color.Black
			''' <summary>
			''' The default font bold mode for the <see cref="Axis"/> title text
			''' font specification <see cref="Axis.TitleFontSpec"/>
			''' (<see cref="FontSpec.IsBold"/> property). true
			''' for a bold typeface, false otherwise.
			''' </summary>
			Public Shared TitleFontBold As Boolean = True
			''' <summary>
			''' The default font italic mode for the <see cref="Axis"/> title text
			''' font specification <see cref="Axis.TitleFontSpec"/>
			''' (<see cref="FontSpec.IsItalic"/> property). true
			''' for an italic typeface, false otherwise.
			''' </summary>
			Public Shared TitleFontItalic As Boolean = False
			''' <summary>
			''' The default font underline mode for the <see cref="Axis"/> title text
			''' font specification <see cref="Axis.TitleFontSpec"/>
			''' (<see cref="FontSpec.IsUnderline"/> property). true
			''' for an underlined typeface, false otherwise.
			''' </summary>
			Public Shared TitleFontUnderline As Boolean = False

			''' <summary>
			''' The default "dash on" size for drawing the <see cref="Axis"/> grid
			''' (<see cref="Axis.GridDashOn"/> property). Units are in pixels.
			''' </summary>
			Public Shared GridDashOn As Single = 1F
			''' <summary>
			''' The default "dash off" size for drawing the <see cref="Axis"/> grid
			''' (<see cref="Axis.GridDashOff"/> property). Units are in pixels.
			''' </summary>
			Public Shared GridDashOff As Single = 0.5F
			''' <summary>
			''' The default pen width for drawing the <see cref="Axis"/> grid
			''' (<see cref="Axis.GridPenWidth"/> property). Units are in pixels.
			''' </summary>
			Public Shared GridPenWidth As Single = 1F
			''' <summary>
			''' The default color for the <see cref="Axis"/> grid lines
			''' (<see cref="Axis.GridColor"/> property).  This color only affects the
			''' grid lines.
			''' </summary>
			Public Shared GridColor As Color = Color.Black
			''' <summary>
			''' The default color for the <see cref="Axis"/> itself
			''' (<see cref="Axis.Color"/> property).  This color only affects the
			''' tic marks and the axis border.
			''' </summary>
			Public Shared Color As Color = Color.Black
			''' <summary>
			''' The default color for the <see cref="Axis"/> frame border.
			''' (<see cref="AldysPane.AxisFrameColor"/> property). 
			''' </summary>
			Public Shared FrameColor As Color = Color.White
			''' <summary>
			''' The default color for the <see cref="AldysPane.AxisRect"/> background.
			''' (<see cref="AldysPane.AxisBackColor"/> property). 
			''' </summary>
			Public Shared BackColor As Color = Color.White
			''' <summary>
			''' The default pen width for drawing the 
			''' <see cref="AldysPane.AxisRect"/> frame border
			''' (<see cref="AldysPane.AxisFramePenWidth"/> property).
			''' Units are in pixels.
			''' </summary>
			Public Shared FramePenWidth As Single = 1F
			''' <summary>
			''' The default display mode for the <see cref="Axis"/> frame border
			''' (<see cref="AldysPane.IsAxisFramed"/> property). true
			''' to show the frame border, false to omit the border
			''' </summary>
			Public Shared IsFramed As Boolean = True
			''' <summary>
			''' The default display mode for the <see cref="Axis"/> grid lines
			''' (<see cref="Axis.IsShowGrid"/> property). true
			''' to show the grid lines, false to hide them.
			''' </summary>
			Public Shared IsShowGrid As Boolean = False
			''' <summary>
			''' The display mode for the <see cref="Axis"/> major outside tic marks
			''' (<see cref="Axis.IsTic"/> property).
			''' The major tic spacing is controlled by <see cref="Axis.Step"/>.
			''' </summary>
			''' <value>true to show the major tic marks (outside the axis),
			''' false otherwise</value>
			Public Shared IsTic As Boolean = True
			''' <summary>
			''' The display mode for the <see cref="Axis"/> minor outside tic marks
			''' (<see cref="Axis.IsMinorTic"/> property).
			''' The minor tic spacing is controlled by <see cref="Axis.MinorStep"/>.
			''' </summary>
			''' <value>true to show the minor tic marks (outside the axis),
			''' false otherwise</value>
			Public Shared IsMinorTic As Boolean = True
			''' <summary>
			''' The display mode for the <see cref="Axis"/> major inside tic marks
			''' (<see cref="Axis.IsInsideTic"/> property).
			''' The major tic spacing is controlled by <see cref="Axis.Step"/>.
			''' </summary>
			''' <value>true to show the major tic marks (inside the axis),
			''' false otherwise</value>
			Public Shared IsInsideTic As Boolean = True
			''' <summary>
			''' The display mode for the <see cref="Axis"/> major opposite tic marks
			''' (<see cref="Axis.IsOppositeTic"/> property).
			''' The major tic spacing is controlled by <see cref="Axis.Step"/>.
			''' </summary>
			''' <value>true to show the major tic marks
			''' (inside the axis on the opposite side),
			''' false otherwise</value>
			Public Shared IsOppositeTic As Boolean = True
			''' <summary>
			''' The display mode for the <see cref="Axis"/> minor inside tic marks
			''' (<see cref="Axis.IsMinorTic"/> property).
			''' The minor tic spacing is controlled by <see cref="Axis.MinorStep"/>.
			''' </summary>
			''' <value>true to show the minor tic marks (inside the axis),
			''' false otherwise</value>
			Public Shared IsMinorInsideTic As Boolean = True
			''' <summary>
			''' The display mode for the <see cref="Axis"/> minor opposite tic marks
			''' (<see cref="Axis.IsMinorOppositeTic"/> property).
			''' The minor tic spacing is controlled by <see cref="Axis.MinorStep"/>.
			''' </summary>
			''' <value>true to show the minor tic marks
			''' (inside the axis on the opposite side),
			''' false otherwise</value>
			Public Shared IsMinorOppositeTic As Boolean = True
			''' <summary>
			''' The default logarithmic mode for the <see cref="Axis"/> scale
			''' (<see cref="Axis.IsLog"/> property). true for a logarithmic scale,
			''' false for a cartesian scale.
			''' </summary>
			Public Shared IsLog As Boolean = False
			''' <summary>
			''' The default reverse mode for the <see cref="Axis"/> scale
			''' (<see cref="Axis.IsReverse"/> property). true for a reversed scale
			''' (X decreasing to the left, Y/Y2 decreasing upwards), false otherwise.
			''' </summary>
			Public Shared IsReverse As Boolean = False
			''' <summary>
			''' The default settings for the <see cref="Axis"/> scale ignore initial
			''' zero values option (<see cref="AldysPane.IsIgnoreInitial"/> property).
			''' true to have the auto-scale-range code ignore the initial data points
			''' until the first non-zero Y value, false otherwise.
			''' </summary>
			Public Shared IgnoreInitial As Boolean = False
			''' <summary>
			''' The default setting for the <see cref="Axis"/> scale axis type
			''' (<see cref="Axis.Type"/> property).  This value is set as per
			''' the <see cref="AxisType"/> enumeration
			''' </summary>
			Public Shared Type As AxisType = AxisType.Linear
			''' <summary>
			''' The default setting for the <see cref="Axis"/> scale date format string
			''' (<see cref="Axis.ScaleFormat"/> property).  This value is set as per
			''' the <see cref="XDate.ToString"/> function.
			''' </summary>
			Public Shared ScaleFormat As String = "&dd-&mmm-&yy &hh:&nn"
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Year"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Year"/>.
			''' This value normally defaults to 1825 days (5 years).
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeYearYear As Double = 1825
			' 5 years
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Year"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Month"/>.
			''' This value normally defaults to 365 days (1 year).
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeYearMonth As Double = 365
			' 1 year
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Month"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Month"/>.
			''' This value normally defaults to 90 days (3 months).
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeMonthMonth As Double = 90
			' 3 months
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Day"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Day"/>.
			''' This value normally defaults to 10 days.
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeDayDay As Double = 10
			' 10 days
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Day"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Hour"/>.
			''' This value normally defaults to 3 days.
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeDayHour As Double = 3
			' 3 days
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Hour"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Hour"/>.
			''' This value normally defaults to 0.4167 days (10 hours).
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeHourHour As Double = 0.4167
			' 10 hours
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Hour"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Minute"/>.
			''' This value normally defaults to 0.125 days (3 hours).
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeHourMinute As Double = 0.125
			' 3 hours
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Minute"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Minute"/>.
			''' This value normally defaults to 6.94e-3 days (10 minutes).
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeMinuteMinute As Double = 0.00694
			' 10 Minutes
			''' <summary>
			''' A default setting for the <see cref="AxisType.Date"/> auto-ranging code.
			''' This values applies only to Date-Time type axes.
			''' If the total span of data exceeds this number (in days), then the auto-range
			''' code will select <see cref="Axis.MajorUnit"/> = <see cref="DateUnit.Minute"/>
			''' and <see cref="Axis.MinorUnit"/> = <see cref="DateUnit.Second"/>.
			''' This value normally defaults to 2.083e-3 days (3 minutes).
			''' This value is used by the <see cref="Axis.CalcDateStepSize"/> method.
			''' </summary>
			Public Shared RangeMinuteSecond As Double = 0.002083
			' 3 Minutes
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="XAxis"/> class.
		''' </summary>
		Public Structure XAxis
			' Default X Axis properties
			''' <summary>
			''' The default display mode for the <see cref="XAxis"/>
			''' (<see cref="Axis.IsVisible"/> property). true to display the scale
			''' values, title, tic marks, false to hide the axis entirely.
			''' </summary>
			Public Shared IsVisible As Boolean = True
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="YAxis"/> class.
		''' </summary>
		Public Structure YAxis
			' Default Y Axis properties
			''' <summary>
			''' The default display mode for the <see cref="YAxis"/>
			''' (<see cref="Axis.IsVisible"/> property). true to display the scale
			''' values, title, tic marks, false to hide the axis entirely.
			''' </summary>
			Public Shared IsVisible As Boolean = True
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="Y2Axis"/> class.
		''' </summary>
		Public Structure Y2Ax
			' Default Y2 Axis properties
			''' <summary>
			''' The default display mode for the <see cref="Y2Axis"/>
			''' (<see cref="Axis.IsVisible"/> property). true to display the scale
			''' values, title, tic marks, false to hide the axis entirely.
			''' </summary>
			Public Shared IsVisible As Boolean = False
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="CurveItem"/> class.
		''' </summary>
		Public Structure Curve
			' Default curve properties
		End Structure

		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="TextItem"/> class.
		''' </summary>
		Public Structure Text
			' Default text item properties
			''' <summary>
			''' Default value for the vertical <see cref="TextItem"/>
			''' text alignment (<see cref="TextItem.AlignV"/> property).
			''' This is specified
			''' using the <see cref="FontAlignV"/> enum type.
			''' </summary>
			Public Shared AlignV As FontAlignV = FontAlignV.Center
			''' <summary>
			''' Default value for the horizontal <see cref="TextItem"/>
			''' text alignment (<see cref="TextItem.AlignH"/> property).
			''' This is specified
			''' using the <see cref="FontAlignH"/> enum type.
			''' </summary>
			Public Shared AlignH As FontAlignH = FontAlignH.Center
			''' <summary>
			''' The default coordinate system to be used for defining the
			''' <see cref="TextItem"/> location coordinates
			''' (<see cref="TextItem.CoordinateFrame"/> property).
			''' </summary>
			''' <value> The coordinate system is defined with the <see cref="CoordType"/>
			''' enum</value>
			Public Shared CoordFrame As CoordType = CoordType.AxisXYScale
			''' <summary>
			''' The default font family for the <see cref="TextItem"/> text
			''' (<see cref="FontSpec.Family"/> property).
			''' </summary>
			Public Shared FontFamily As String = "Arial"
			''' <summary>
			''' The default font size for the <see cref="TextItem"/> text
			''' (<see cref="FontSpec.Size"/> property).  Units are
			''' in points (1/72 inch).
			''' </summary>
			Public Shared FontSize As Single = 14F
			''' <summary>
			''' The default font color for the <see cref="TextItem"/> text
			''' (<see cref="FontSpec.FontColor"/> property).
			''' </summary>
			Public Shared FontColor As Color = Color.Black
			''' <summary>
			''' The default font bold mode for the <see cref="TextItem"/> text
			''' (<see cref="FontSpec.IsBold"/> property). true
			''' for a bold typeface, false otherwise.
			''' </summary>
			Public Shared FontBold As Boolean = True
			''' <summary>
			''' The default font underline mode for the <see cref="TextItem"/> text
			''' (<see cref="FontSpec.IsUnderline"/> property). true
			''' for an underlined typeface, false otherwise.
			''' </summary>
			Public Shared FontUnderline As Boolean = False
			''' <summary>
			''' The default font italic mode for the <see cref="TextItem"/> text
			''' (<see cref="FontSpec.IsItalic"/> property). true
			''' for an italic typeface, false otherwise.
			''' </summary>
			Public Shared FontItalic As Boolean = False
		End Structure


		''' <summary>
		''' A simple subclass of the <see cref="Def"/> class that defines the
		''' default property values for the <see cref="ArrowItem"/> class.
		''' </summary>
		Public Structure Arrow
			''' <summary>
			''' The default size for the <see cref="ArrowItem"/> item arrowhead
			''' (<see cref="ArrowItem.Size"/> property).  Units are in pixels.
			''' </summary>
			Public Shared Size As Single = 12F
			''' <summary>
			''' The default coordinate system to be used for defining the
			''' <see cref="ArrowItem"/> location coordinates
			''' (<see cref="ArrowItem.CoordinateFrame"/> property).
			''' </summary>
			''' <value> The coordinate system is defined with the <see cref="CoordType"/>
			''' enum</value>
			Public Shared CoordFrame As CoordType = CoordType.AxisXYScale
			''' <summary>
			''' The default display mode for the <see cref="ArrowItem"/> item arrowhead
			''' (<see cref="ArrowItem.IsArrowHead"/> property).  true to show the
			''' arrowhead, false to hide it.
			''' </summary>
			Public Shared IsArrowHead As Boolean = True
			''' <summary>
			''' The default pen width used for the <see cref="ArrowItem"/> line segment
			''' (<see cref="ArrowItem.PenWidth"/> property).  Units are pixels.
			''' </summary>
			Public Shared PenWidth As Single = 1F
			''' <summary>
			''' The default color used for the <see cref="ArrowItem"/> line segment
			''' and arrowhead (<see cref="ArrowItem.Color"/> property).
			''' </summary>
			Public Shared Color As Color = Color.Red
		End Structure
	End Structure
End Namespace
