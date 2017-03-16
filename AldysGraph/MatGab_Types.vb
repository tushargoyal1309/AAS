Imports System

Namespace AldysGraph
	''' <summary>
	''' Enumeration type for the various axis types that are available
	''' </summary>
	''' <seealso cref="ZedGraph.Axis.Type"/>
	Public Enum AxisType
		''' <summary> An ordinary, cartesian axis </summary>
		Linear
		''' <summary> A base 10 log axis </summary>
		Log
		''' <summary> A cartesian axis with calendar dates or times </summary>
		[Date]
		''' <summary> An ordinal axis with user-defined text labels </summary>
		Text
	End Enum

	''' <summary>
	''' Enumeration type for the various axis date and time unit types that are available
	''' </summary>
	Public Enum DateUnit
		''' <summary> Yearly units <see cref="Axis.MajorUnit"/> and <see cref="Axis.MinorUnit"/> </summary>
		Year
		''' <summary> Monthly units <see cref="Axis.MajorUnit"/> and <see cref="Axis.MinorUnit"/> </summary>
		Month
		''' <summary> Daily units <see cref="Axis.MajorUnit"/> and <see cref="Axis.MinorUnit"/> </summary>
		Day
		''' <summary> Hourly units <see cref="Axis.MajorUnit"/> and <see cref="Axis.MinorUnit"/> </summary>
		Hour
		''' <summary> Minute units <see cref="Axis.MajorUnit"/> and <see cref="Axis.MinorUnit"/> </summary>
		Minute
		''' <summary> Second units <see cref="Axis.MajorUnit"/> and <see cref="Axis.MinorUnit"/> </summary>
		Second
	End Enum

	''' <summary>
	''' Enumeration type for the various symbol shapes that are available
	''' </summary>
	''' <seealso cref="ZedGraph.Symbol.IsFilled"/>
	Public Enum SymbolType
		''' <summary> Square-shaped <see cref="ZedGraph.Symbol"/> </summary>
		Square
		''' <summary> Rhombus-shaped <see cref="ZedGraph.Symbol"/> </summary>
		Diamond
		''' <summary> Equilateral triangle <see cref="ZedGraph.Symbol"/> </summary>
		Triangle
		''' <summary> Uniform circle <see cref="ZedGraph.Symbol"/> </summary>
		Circle
		''' <summary> "X" shaped <see cref="ZedGraph.Symbol"/>.  This symbol cannot
		''' be filled since it has no outline. </summary>
		XCross
		''' <summary> "+" shaped <see cref="ZedGraph.Symbol"/>.  This symbol cannot
		''' be filled since it has no outline. </summary>
		Plus
		''' <summary> Asterisk-shaped <see cref="ZedGraph.Symbol"/>.  This symbol
		''' cannot be filled since it has no outline. </summary>
		Star
		''' <summary> Unilateral triangle <see cref="ZedGraph.Symbol"/>, pointing
		''' down. </summary>
		TriangleDown
		NoSymbol

	End Enum

	''' <summary>
	''' Enumeration type that defines the possible legend locations
	''' </summary>
	''' <seealso cref="Legend.Location"/>
	Public Enum LegendLoc
		''' <summary>
		''' Locate the <see cref="Legend"/> above the <see cref="AldysPane.AxisRect"/>
		''' </summary>
		Top
		''' <summary>
		''' Locate the <see cref="Legend"/> on the left side of the <see cref="AldysPane.AxisRect"/>
		''' </summary>
		Left
		''' <summary>
		''' Locate the <see cref="Legend"/> on the right side of the <see cref="AldysPane.AxisRect"/>
		''' </summary>
		Right
		''' <summary>
		''' Locate the <see cref="Legend"/> below the <see cref="AldysPane.AxisRect"/>
		''' </summary>
		Bottom
		''' <summary>
		''' Locate the <see cref="Legend"/> inside the <see cref="AldysPane.AxisRect"/> in the
		''' top-left corner
		''' </summary>
		InsideTopLeft
		''' <summary>
		''' Locate the <see cref="Legend"/> inside the <see cref="AldysPane.AxisRect"/> in the
		''' top-right corner
		''' </summary>
		InsideTopRight
		''' <summary>
		''' Locate the <see cref="Legend"/> inside the <see cref="AldysPane.AxisRect"/> in the
		''' bottom-left corner
		''' </summary>
		InsideBotLeft
		''' <summary>
		''' Locate the <see cref="Legend"/> inside the <see cref="AldysPane.AxisRect"/> in the
		''' bottom-right corner
		''' </summary>
		InsideBotRight
	End Enum

	''' <summary>
	''' Enumeration type for the different horizontal text alignment options
	''' </summary>
	''' <seealso cref="FontSpec"/>
	Public Enum FontAlignH
		''' <summary>
		''' Position the text so that its left edge is aligned with the
		''' specified X,Y location.  Used by the
		''' <see cref="FontSpec.Draw"/> method.
		''' </summary>
		Left
		''' <summary>
		''' Position the text so that its center is aligned (horizontally) with the
		''' specified X,Y location.  Used by the
		''' <see cref="FontSpec.Draw"/> method.
		''' </summary>
		Center
		''' <summary>
		''' Position the text so that its right edge is aligned with the
		''' specified X,Y location.  Used by the
		''' <see cref="FontSpec.Draw"/> method.
		''' </summary>
		Right
	End Enum

	''' <summary>
	''' Enumeration type for the different vertical text alignment options
	''' </summary>
	''' specified X,Y location.  Used by the
	''' <see cref="FontSpec.Draw"/> method.
	Public Enum FontAlignV
		''' <summary>
		''' Position the text so that its top edge is aligned with the
		''' specified X,Y location.  Used by the
		''' <see cref="FontSpec.Draw"/> method.
		''' </summary>
		Top
		''' <summary>
		''' Position the text so that its center is aligned (vertically) with the
		''' specified X,Y location.  Used by the
		''' <see cref="FontSpec.Draw"/> method.
		''' </summary>
		Center
		''' <summary>
		''' Position the text so that its bottom edge is aligned with the
		''' specified X,Y location.  Used by the
		''' <see cref="FontSpec.Draw"/> method.
		''' </summary>
		Bottom
	End Enum

	''' <summary>
	''' Enumeration type for the user-defined coordinate types available.
	''' These coordinate types are used the <see cref="ArrowItem"/> objects
	''' and <see cref="TextItem"/> objects only.
	''' </summary>
	''' <seealso cref="TextItem.CoordinateFrame"/>
	''' <seealso cref="ArrowItem.CoordinateFrame"/>
	Public Enum CoordType
		''' <summary>
		''' Coordinates are specified as a fraction of the
		''' <see cref="AldysPane.AxisRect"/>.  That is, for the X coordinate, 0.0
		''' is at the left edge of the AxisRect and 1.0
		''' is at the right edge of the AxisRect. A value less
		''' than zero is left of the AxisRect and a value
		''' greater than 1.0 is right of the AxisRect.
		''' </summary>
		AxisFraction
		''' <summary>
		''' Coordinates are specified as a fraction of the
		''' <see cref="AldysPane.PaneRect"/>.  That is, for the X coordinate, 0.0
		''' is at the left edge of the PaneRect and 1.0
		''' is at the right edge of the PaneRect. A value less
		''' than zero is left of the PaneRect and a value
		''' greater than 1.0 is right of the PaneRect.  Note that
		''' any value less than zero or greater than 1.0 will be outside
		''' the PaneRect, and therefore clipped.
		''' </summary>
		PaneFraction
		''' <summary>
		''' Coordinates are specified according to the user axis scales
		''' for the <see cref="AldysPane.XAxis"/> and <see cref="AldysPane.YAxis"/>.
		''' </summary>
		AxisXYScale
		''' <summary>
		''' Coordinates are specified according to the user axis scales
		''' for the <see cref="AldysPane.XAxis"/> and <see cref="AldysPane.Y2Axis"/>.
		''' </summary>
		AxisXY2Scale
	End Enum

	''' <summary>
	''' Enumeration type that defines how a curve is draw.  Curves can be drawn
	''' as ordinary lines by connecting the points directly, or in a stair-step
	''' fashion as a series of discrete, constant values.  In a stair step plot,
	''' all lines segments are either horizontal or vertical.  In a non-step (line)
	''' plot, the lines can be any angle.
	''' </summary>
	''' <seealso cref="Line.StepType"/>
	Public Enum StepType
		''' <summary>
		''' Draw the <see cref="CurveItem"/> as a stair-step in which each
		''' point defines the
		''' beginning (left side) of a new stair.  This implies the points are
		''' defined at the beginning of an "event."
		''' </summary>
		ForwardStep
		''' <summary>
		''' Draw the <see cref="CurveItem"/> as a stair-step in which each
		''' point defines the end (right side) of a new stair.  This implies
		''' the points are defined at the end of an "event."
		''' </summary>
		RearwardStep
		''' <summary>
		''' Draw the <see cref="CurveItem"/> as an ordinary line, in which the
		''' points are connected directly by line segments.
		''' </summary>
		NonStep
	End Enum



End Namespace
