Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections
Namespace AldysGraph
	''' <summary>
	''' Summary description for XAxis.
	''' </summary>
	Public Class XAxis
		Implements ICloneable
		#region " Class Fields"
		''' <summary> Private fields for the <see cref="Axis"/> scale definitions.
		''' Use the public properties <see cref="Min"/>, <see cref="Max"/>,
		''' <see cref="Step"/>, and <see cref="MinorStep"/> for access to these values.
		''' </summary>
		Private m_min As Double, m_max As Double, m_step As Double, m_minorStep As Double
		''' <summary> Private fields for the <see cref="Axis"/> automatic scaling modes.
		''' Use the public properties <see cref="MinAuto"/>, <see cref="MaxAuto"/>,
		''' <see cref="StepAuto"/>, <see cref="MinorStepAuto"/>, <see cref="MinorStepAuto"/>,
		''' <see cref="NumDecAuto"/>, and <see cref="ScaleMagAuto"/> for access to these values.
		''' </summary>
		Private m_minAuto As Boolean, m_maxAuto As Boolean, m_stepAuto As Boolean, m_minorStepAuto As Boolean, m_numDecAuto As Boolean, m_scaleMagAuto As Boolean
		''' <summary> Private fields for the <see cref="Axis"/> scale value display.
		''' Use the public properties <see cref="NumDec"/> and <see cref="ScaleMag"/>
		''' for access to these values. </summary>
		Private m_numDec As Integer, m_scaleMag As Integer
		''' <summary> Private fields for the <see cref="Axis"/> attributes.
		''' Use the public properties <see cref="IsVisible"/>, <see cref="IsShowGrid"/>,
		''' <see cref="IsTic"/>, <see cref="IsInsideTic"/>, <see cref="IsOppositeTic"/>,
		''' <see cref="IsMinorTic"/>, <see cref="IsMinorInsideTic"/>,
		''' <see cref="IsMinorOppositeTic"/>, <see cref="IsLog"/>, <see cref="IsReverse"/>,
		''' <see cref="IsOmitMag"/>, <see cref="IsText"/>,
		''' and <see cref="IsDate"/> for access to these values.
		''' </summary>
		Private m_isVisible As Boolean, m_isShowGrid As Boolean, m_isTic As Boolean, m_isInsideTic As Boolean, m_isOppositeTic As Boolean, m_isMinorTic As Boolean, _
			m_isMinorInsideTic As Boolean, m_isMinorOppositeTic As Boolean, m_isReverse As Boolean, m_isOmitMag As Boolean
		''' <summary> Private field for the <see cref="Axis"/> type.  This can be one of the
		''' types as defined in the <see cref="AxisType"/> enumeration.
		''' Use the public property <see cref="Type"/>
		''' for access to this value. </summary>
		Private m_type As AxisType
		''' <summary> Private field for the <see cref="Axis"/> title string.
		''' Use the public property <see cref="Title"/>
		''' for access to this value. </summary>
		Private m_title As String
		''' <summary> Private field for the format of the <see cref="Axis"/> tic labels.
		''' This field is only used if the <see cref="Type"/> is set to <see cref="AxisType.Date"/>.
		''' Use the public property <see cref="ScaleFormat"/>
		''' for access to this value. </summary>
		Private m_scaleFormat As String
		''' <summary> Public field for the <see cref="Axis"/> array of text labels.
		''' This property is only used if <see cref="Type"/> is set to
		''' <see cref="AxisType.Text"/>.
		''' is set to true. </summary>
		Public TextLabels As String() = Nothing
		''' <summary> Private fields for the <see cref="Axis"/> font specificatios.
		''' Use the public properties <see cref="TitleFontSpec"/> and
		''' <see cref="ScaleFontSpec"/> for access to these values. </summary>
		Private m_titleFontSpec As FontSpecs, m_scaleFontSpec As FontSpecs
		''' <summary> Private fields for the <see cref="Axis"/> drawing dimensions.
		''' Use the public properties <see cref="TicPenWidth"/>, <see cref="TicSize"/>,
		''' <see cref="MinorTicSize"/>, <see cref="GridDashOn"/>, <see cref="GridDashOff"/>,
		''' and <see cref="GridPenWidth"/> for access to these values. </summary>
		Private m_ticPenWidth As Single, m_ticSize As Single, m_minorTicSize As Single, m_gridDashOn As Single, m_gridDashOff As Single, m_gridPenWidth As Single
		''' <summary> Private fields for the <see cref="Axis"/> colors.
		''' Use the public properties <see cref="Color"/> and
		''' <see cref="GridColor"/> for access to these values. </summary>
		Private m_color As Color, m_gridColor As Color

		''' <summary>
		''' Scale values for calculating transforms.  These are temporary values
		''' used only during the Draw process.
		''' </summary>
		Private minPix As Single, maxPix As Single
		''' <summary>
		''' Scale values for calculating transforms.  These are temporary values
		''' used only during the Draw process.
		''' </summary>
		Private minScale As Double, maxScale As Double

		''' <summary>
		''' Private fields for Unit types to be used for the major and minor tics.
		''' See <see cref="MajorUnit"/> and <see cref="MinorUnit"/> for the corresponding
		''' public properties.
		''' These types only apply for date-time scales (<see cref="IsDate"/>).
		''' </summary>
		''' <value>The value of these types is of enumeration type <see cref="DateUnit"/>
		''' </value>
		Private m_majorUnit As DateUnit, m_minorUnit As DateUnit

		Public xArrSteps As ArrayList



		#end region
		Public Sub New()
			'
			' TODO: Add constructor logic here
			'
			Me.m_min = 0.0
			Me.m_max = 1.0
			Me.m_step = 0.1
			Me.m_minorStep = 0.1

			Me.m_minAuto = True
			Me.m_maxAuto = True
			Me.m_stepAuto = True
			Me.m_minorStepAuto = True
			Me.m_numDecAuto = True
			Me.m_scaleMagAuto = True

			Me.m_numDec = 0
			Me.m_scaleMag = 0

			Me.m_ticSize = Defaults.Axis.TicSize
			Me.m_minorTicSize = Defaults.Axis.MinorTicSize
			Me.m_gridDashOn = Defaults.Axis.GridDashOn
			Me.m_gridDashOff = Defaults.Axis.GridDashOff
			Me.m_gridPenWidth = Defaults.Axis.GridPenWidth

			Me.m_isVisible = True
			Me.m_isShowGrid = Defaults.Axis.IsShowGrid
			Me.m_isReverse = Defaults.Axis.IsReverse
			Me.m_isOmitMag = False
			Me.m_isTic = Defaults.Axis.IsTic
			Me.m_isInsideTic = Defaults.Axis.IsInsideTic
			Me.m_isOppositeTic = Defaults.Axis.IsOppositeTic
			Me.m_isMinorTic = Defaults.Axis.IsMinorTic
			Me.m_isMinorInsideTic = Defaults.Axis.IsMinorInsideTic
			Me.m_isMinorOppositeTic = Defaults.Axis.IsMinorOppositeTic

			Me.m_type = Defaults.Axis.Type
			Me.m_title = ""
			Me.TextLabels = Nothing
			Me.m_scaleFormat = Nothing

			Me.m_majorUnit = DateUnit.Year
			Me.m_minorUnit = DateUnit.Year

			Me.m_ticPenWidth = Defaults.Axis.TicPenWidth
			Me.m_color = Defaults.Axis.Color
			Me.m_gridColor = Defaults.Axis.GridColor

			Me.m_titleFontSpec = New FontSpecs(Defaults.Axis.TitleFontFamily, Defaults.Axis.TitleFontSize, Defaults.Axis.TitleFontColor, Defaults.Axis.TitleFontBold, Defaults.Axis.TitleFontUnderline, Defaults.Axis.TitleFontItalic)
			Me.m_titleFontSpec.IsFilled = False
			Me.m_titleFontSpec.IsFramed = False

			Me.m_scaleFontSpec = New FontSpecs(Defaults.Axis.ScaleFontFamily, Defaults.Axis.ScaleFontSize, Defaults.Axis.ScaleFontColor, Defaults.Axis.ScaleFontBold, Defaults.Axis.ScaleFontUnderline, Defaults.Axis.ScaleFontItalic)
			Me.m_scaleFontSpec.IsFilled = False
			Me.m_scaleFontSpec.IsFramed = False

			Me.xArrSteps = New ArrayList()
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The XAxis object from which to copy</param>
		Public Sub New(rhs As XAxis)
			m_min = rhs.Min
			m_max = rhs.Max
			m_step = rhs.[Step]
			m_minorStep = rhs.MinorStep
			m_minAuto = rhs.MinAuto
			m_maxAuto = rhs.MaxAuto
			m_stepAuto = rhs.StepAuto
			m_minorStepAuto = rhs.MinorStepAuto
			m_numDecAuto = rhs.NumDecAuto
			m_scaleMagAuto = rhs.ScaleMagAuto

			m_numDec = rhs.numDec
			m_scaleMag = rhs.scaleMag
			m_isVisible = rhs.IsVisible
			m_isShowGrid = rhs.IsShowGrid
			m_isTic = rhs.IsTic
			m_isInsideTic = rhs.IsInsideTic
			m_isOppositeTic = rhs.IsOppositeTic
			m_isMinorTic = rhs.IsMinorTic
			m_isMinorInsideTic = rhs.IsMinorInsideTic
			m_isMinorOppositeTic = rhs.IsMinorOppositeTic
			m_isReverse = rhs.IsReverse
			m_isOmitMag = rhs.IsOmitMag
			m_title = rhs.Title

			m_type = rhs.Type

			m_majorUnit = rhs.MajorUnit
			m_minorUnit = rhs.MinorUnit

			If not (rhs.TextLabels  is nothing)  Then
				TextLabels = DirectCast(rhs.TextLabels.Clone(), String())
			Else
				TextLabels = Nothing
			End If

			m_titleFontSpec = New FontSpecs(rhs.TitleFontSpec)
			m_scaleFontSpec = New FontSpecs(rhs.ScaleFontSpec)

			m_ticPenWidth = rhs.TicPenWidth
			m_ticSize = rhs.TicSize
			m_minorTicSize = rhs.MinorTicSize
			m_gridDashOn = rhs.GridDashOn
			m_gridDashOff = rhs.GridDashOff
			m_gridPenWidth = rhs.GridPenWidth

			m_color = rhs.Color
			m_gridColor = rhs.GridColor
			xArrSteps = rhs.xArrSteps
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the XAxis</returns>
		Public Function Clone() As Object
			'return new XAxis( this );
			Return New XAxis()

		End Function

		#region " Scale Properties"
		''' <summary>
		''' The minimum scale value for this axis.  This value can be set
		''' automatically based on the state of <see cref="MinAuto"/>.  If
		''' this value is set manually, then <see cref="MinAuto"/> will
		''' also be set to false.
		''' </summary>
		''' <value> The value is defined in user scale units for <see cref="AxisType.Log"/>
		''' and <see cref="AxisType.Linear"/> axes. For <see cref="AxisType.Text"/> axes,
		''' this value is an ordinal starting with 1.0.  For <see cref="AxisType.Date"/>
		''' axes, this value is in XL Date format (see <see cref="XDate"/>, which is the
		''' number of days since the reference date of January 1, 1900.</value>
		Public Property Min() As Double
			Get
				Return m_min
			End Get
			Set
				m_min = value
				Me.m_minAuto = False
			End Set
		End Property
		''' <summary>
		''' The maximum scale value for this axis.  This value can be set
		''' automatically based on the state of <see cref="MaxAuto"/>.  If
		''' this value is set manually, then <see cref="MaxAuto"/> will
		''' also be set to false.
		''' </summary>
		''' <value> The value is defined in user scale units for <see cref="AxisType.Log"/>
		''' and <see cref="AxisType.Linear"/> axes. For <see cref="AxisType.Text"/> axes,
		''' this value is an ordinal starting with 1.0.  For <see cref="AxisType.Date"/>
		''' axes, this value is in XL Date format (see <see cref="XDate"/>, which is the
		''' number of days since the reference date of January 1, 1900.</value>
		Public Property Max() As Double
			Get
				Return m_max
			End Get
			Set
				m_max = value
				Me.m_maxAuto = False
			End Set
		End Property
		''' <summary>
		''' The scale step size for this axis (the increment between
		''' labeled axis values).  This value can be set
		''' automatically based on the state of <see cref="StepAuto"/>.  If
		''' this value is set manually, then <see cref="StepAuto"/> will
		''' also be set to false.  This value is ignored for <see cref="AxisType.Log"/> and
		''' <see cref="AxisType.Text"/> axes.  For <see cref="AxisType.Date"/> axes, this
		''' value is defined in units of <see cref="MajorUnit"/>.
		''' </summary>
		''' <value> The value is defined in user scale units </value>
		Public Property [Step]() As Double
			Get
				Return m_step
			End Get
			Set
				m_step = value
				Me.m_stepAuto = False
			End Set
		End Property
		''' <summary>
		''' The type of units used for the major step size (<see cref="Step"/>).
		''' This unit type only applies to Date-Time axes (<see cref="AxisType.Date"/> = true).
		''' The axis is set to date type with the <see cref="Type"/> property.
		''' The unit types are defined as <see cref="DateUnit"/>.
		''' </summary>
		''' <value> The value is a <see cref="DateUnit"/> enum type </value>
		Public Property MajorUnit() As DateUnit
			Get
				Return m_majorUnit
			End Get
			Set
				m_majorUnit = value
			End Set
		End Property
		''' <summary>
		''' The type of units used for the minor step size (<see cref="MinorStep"/>).
		''' This unit type only applies to Date-Time axes (<see cref="AxisType.Date"/> = true).
		''' The axis is set to date type with the <see cref="Type"/> property.
		''' The unit types are defined as <see cref="DateUnit"/>.
		''' </summary>
		''' <value> The value is a <see cref="DateUnit"/> enum type </value>
		Public Property MinorUnit() As DateUnit
			Get
				Return m_minorUnit
			End Get
			Set
				m_minorUnit = value
			End Set
		End Property
		''' <summary>
		''' The scale minor step size for this axis (the spacing between
		''' minor tics).  This value can be set
		''' automatically based on the state of <see cref="MinorStepAuto"/>.  If
		''' this value is set manually, then <see cref="MinorStepAuto"/> will
		''' also be set to false.  This value is ignored for <see cref="AxisType.Log"/> and
		''' <see cref="AxisType.Text"/> axes.  For <see cref="AxisType.Date"/> axes, this
		''' value is defined in units of <see cref="MinorUnit"/>.
		''' </summary>
		''' <value> The value is defined in user scale units </value>
		Public Property MinorStep() As Double
			Get
				Return m_minorStep
			End Get
			Set
				m_minorStep = value
				Me.m_minorStepAuto = False
			End Set
		End Property
		''' <summary>
		''' Determines whether or not the minimum scale value <see cref="Min"/>
		''' is set automatically.  This value will be set to false if
		''' <see cref="Min"/> is manually changed.
		''' </summary>
		''' <value>true for automatic mode, false for manual mode</value>
		Public Property MinAuto() As Boolean
			Get
				Return m_minAuto
			End Get
			Set
				m_minAuto = value
			End Set
		End Property
		''' <summary>
		''' Determines whether or not the maximum scale value <see cref="Max"/>
		''' is set automatically.  This value will be set to false if
		''' <see cref="Max"/> is manually changed.
		''' </summary>
		''' <value>true for automatic mode, false for manual mode</value>
		Public Property MaxAuto() As Boolean
			Get
				Return m_maxAuto
			End Get
			Set
				m_maxAuto = value
			End Set
		End Property
		''' <summary>
		''' Determines whether or not the scale step size <see cref="Step"/>
		''' is set automatically.  This value will be set to false if
		''' <see cref="Step"/> is manually changed.
		''' </summary>
		''' <value>true for automatic mode, false for manual mode</value>
		Public Property StepAuto() As Boolean
			Get
				Return m_stepAuto
			End Get
			Set
				m_stepAuto = value
			End Set
		End Property
		''' <summary>
		''' Determines whether or not the minor scale step size <see cref="MinorStep"/>
		''' is set automatically.  This value will be set to false if
		''' <see cref="MinorStep"/> is manually changed.
		''' </summary>
		''' <value>true for automatic mode, false for manual mode</value>
		Public Property MinorStepAuto() As Boolean
			Get
				Return m_minorStepAuto
			End Get
			Set
				m_minorStepAuto = value
			End Set
		End Property
		#end region


		#region " Tic Properties"
		''' <summary>
		''' The color to use for drawing this <see cref="Axis"/>.  This affects only the tic
		''' marks, since the <see cref="TitleFontSpec"/> and
		''' <see cref="ScaleFontSpec"/> both have their own color specification.
		''' </summary>
		''' <value> The color is defined using the
		''' <see cref="System.Drawing.Color"/> class</value>
		Public Property Color() As Color
			Get
				Return m_color
			End Get
			Set
				m_color = value
			End Set
		End Property
		''' <summary>
		''' The length of the <see cref="Axis"/> tic marks.  This length will be scaled
		''' according to the <see cref="AldysPane.CalcScaleFactor"/> for the
		''' <see cref="AldysPane"/>
		''' </summary>
		''' <value>The tic size is measured in pixels</value>
		Public Property TicSize() As Single
			Get
				Return m_ticSize
			End Get
			Set
				m_ticSize = value
			End Set
		End Property
		''' <summary>
		''' The length of the <see cref="Axis"/> minor tic marks.  This length will be scaled
		''' according to the <see cref="AldysPane.CalcScaleFactor"/> for the
		''' <see cref="AldysPane"/>
		''' </summary>
		''' <value>The tic size is measured in pixels</value>
		Public Property MinorTicSize() As Single
			Get
				Return m_minorTicSize
			End Get
			Set
				m_minorTicSize = value
			End Set
		End Property
		''' <summary>
		''' Calculate the scaled tic size for this <see cref="Axis"/>
		''' </summary>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>The scaled tic size, in pixels</returns>
		Public Function ScaledTic(scaleFactor As Double) As Single
			Return DirectCast(Me.m_ticSize * scaleFactor + 0.5, Single)
		End Function
		''' <summary>
		''' Calculate the scaled minor tic size for this <see cref="Axis"/>
		''' </summary>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <returns>The scaled tic size, in pixels</returns>
		Public Function ScaledMinorTic(scaleFactor As Double) As Single
			Return DirectCast(Me.m_minorTicSize * scaleFactor + 0.5, Single)
		End Function
		''' <summary>
		''' This property determines whether or not the major outside tic marks
		''' are shown.  These are the tic marks on the outside of the <see cref="Axis"/> frame.
		''' The major tic spacing is controlled by <see cref="Step"/>.
		''' </summary>
		''' <value>true to show the major outside tic marks, false otherwise</value>
		Public Property IsTic() As Boolean
			Get
				Return m_isTic
			End Get
			Set
				m_isTic = value
			End Set
		End Property
		''' <summary>
		''' This property determines whether or not the minor outside tic marks
		''' are shown.  These are the tic marks on the outside of the <see cref="Axis"/> frame.
		''' The minor tic spacing is controlled by <see cref="MinorStep"/>.  This setting is
		''' ignored (no minor tics are drawn) for text axes (see <see cref="IsText"/>).
		''' </summary>
		''' <value>true to show the minor outside tic marks, false otherwise</value>
		Public Property IsMinorTic() As Boolean
			Get
				Return m_isMinorTic
			End Get
			Set
				m_isMinorTic = value
			End Set
		End Property
		''' <summary>
		''' This property determines whether or not the major inside tic marks
		''' are shown.  These are the tic marks on the inside of the <see cref="Axis"/> frame.
		''' The major tic spacing is controlled by <see cref="Step"/>.
		''' </summary>
		''' <value>true to show the major inside tic marks, false otherwise</value>
		Public Property IsInsideTic() As Boolean
			Get
				Return m_isInsideTic
			End Get
			Set
				m_isInsideTic = value
			End Set
		End Property
		''' <summary>
		''' This property determines whether or not the major opposite tic marks
		''' are shown.  These are the tic marks on the inside of the <see cref="Axis"/> frame on
		''' the opposite side from the axis.
		''' The major tic spacing is controlled by <see cref="Step"/>.
		''' </summary>
		''' <value>true to show the major opposite tic marks, false otherwise</value>
		Public Property IsOppositeTic() As Boolean
			Get
				Return m_isOppositeTic
			End Get
			Set
				m_isOppositeTic = value
			End Set
		End Property
		''' <summary>
		''' This property determines whether or not the minor inside tic marks
		''' are shown.  These are the tic marks on the inside of the <see cref="Axis"/> frame.
		''' The minor tic spacing is controlled by <see cref="MinorStep"/>.
		''' </summary>
		''' <value>true to show the minor inside tic marks, false otherwise</value>
		Public Property IsMinorInsideTic() As Boolean
			Get
				Return m_isMinorInsideTic
			End Get
			Set
				m_isMinorInsideTic = value
			End Set
		End Property
		''' <summary>
		''' This property determines whether or not the minor opposite tic marks
		''' are shown.  These are the tic marks on the inside of the <see cref="Axis"/> frame on
		''' the opposite side from the axis.
		''' The minor tic spacing is controlled by <see cref="MinorStep"/>.
		''' </summary>
		''' <value>true to show the minor opposite tic marks, false otherwise</value>
		Public Property IsMinorOppositeTic() As Boolean
			Get
				Return m_isMinorOppositeTic
			End Get
			Set
				m_isMinorOppositeTic = value
			End Set
		End Property
		''' <summary>
		''' The pen width to be used when drawing the tic marks for this <see cref="Axis"/>
		''' </summary>
		''' <value>The pen width is defined in pixels</value>
		Public Property TicPenWidth() As Single
			Get
				Return m_ticPenWidth
			End Get
			Set
				m_ticPenWidth = value
			End Set
		End Property
		#end region

		#region " Grid Properties"
		''' <summary>
		''' Determines if the major <see cref="Axis"/> gridlines (at each labeled value) will be shown
		''' </summary>
		''' <value>true to show the gridlines, false otherwise</value>
		Public Property IsShowGrid() As Boolean
			Get
				Return m_isShowGrid
			End Get
			Set
				m_isShowGrid = value
			End Set
		End Property
		''' <summary>
		''' The "Dash On" mode for drawing the grid.  This is the distance,
		''' in pixels, of the dash segments that make up the dashed grid lines.
		''' </summary>
		''' <value>The dash on length is defined in pixel units</value>
		''' <seealso cref="GridDashOff"/>
		''' <seealso cref="IsShowGrid"/>
		Public Property GridDashOn() As Single
			Get
				Return m_gridDashOn
			End Get
			Set
				m_gridDashOn = value
			End Set
		End Property
		''' <summary>
		''' The "Dash Off" mode for drawing the grid.  This is the distance,
		''' in pixels, of the spaces between the dash segments that make up
		''' the dashed grid lines.
		''' </summary>
		''' <value>The dash off length is defined in pixel units</value>
		''' <seealso cref="GridDashOn"/>
		''' <seealso cref="IsShowGrid"/>
		Public Property GridDashOff() As Single
			Get
				Return m_gridDashOff
			End Get
			Set
				m_gridDashOff = value
			End Set
		End Property
		''' <summary>
		''' The default pen width used for drawing the grid lines.
		''' </summary>
		''' <value>The grid pen width is defined in pixel units</value>
		''' <seealso cref="IsShowGrid"/>
		Public Property GridPenWidth() As Single
			Get
				Return m_gridPenWidth
			End Get
			Set
				m_gridPenWidth = value
			End Set
		End Property
		''' <summary>
		''' The color to use for drawing this <see cref="Axis"/> grid.  This affects only the grid
		''' lines, since the <see cref="TitleFontSpec"/> and
		''' <see cref="ScaleFontSpec"/> both have their own color specification.
		''' </summary>
		''' <value> The color is defined using the
		''' <see cref="System.Drawing.Color"/> class</value>
		Public Property GridColor() As Color
			Get
				Return m_gridColor
			End Get
			Set
				m_gridColor = value
			End Set
		End Property
		#end region

		#region " Type Properties"
		''' <summary>
		''' This property determines whether or not the <see cref="Axis"/> is shown.
		''' Note that even if
		''' the axis is not visible, it can still be actively used to draw curves on a
		''' graph, it will just be invisible to the user
		''' </summary>
		''' <value>true to show the axis, false to disable all drawing of this axis</value>
		Public Property IsVisible() As Boolean
			Get
				Return m_isVisible
			End Get
			Set
				m_isVisible = value
			End Set
		End Property
		''' <summary>
		''' Determines if the scale values are reversed for this <see cref="Axis"/>
		''' </summary>
		''' <value>true for the X values to decrease to the right or the Y values to
		''' decrease upwards, false otherwise</value>
		Public Property IsReverse() As Boolean
			Get
				Return m_isReverse
			End Get
			Set
				m_isReverse = value
			End Set
		End Property
		''' <summary>
		''' Determines if this <see cref="Axis"/> is logarithmic (base 10).  To make this property
		''' true, set <see cref="Type"/> to <see cref="AxisType.Log"/>.
		''' </summary>
		''' <value>true for a logarithmic axis, false for a linear, date, or text axis</value>
		Public ReadOnly Property IsLog() As Boolean
			Get
				Return m_type = AxisType.Log
			End Get
		End Property
		''' <summary>
		''' Determines if this <see cref="Axis"/> is of the date-time type.  To make this property
		''' true, set <see cref="Type"/> to <see cref="AxisType.Date"/>.
		''' </summary>
		''' <value>true for a date axis, false for a linear, log, or text axis</value>
		Public ReadOnly Property IsDate() As Boolean
			Get
				Return m_type = AxisType.[Date]
			End Get
		End Property
		''' <summary>
		''' Tests if this <see cref="Axis"/> is labeled with user provided text
		''' labels rather than calculated numeric values.  The text labels are provided via the
		''' <see cref="TextLabels"/> property.  Internally, the axis is still handled with ordinal values
		''' such that the axis <see cref="Min"/> is set to 1.0, and the axis <see cref="Max"/> is set
		''' to the number of labels.  To make this property true, set <see cref="Type"/> to
		''' <see cref="AxisType.Text"/>.
		''' </summary>
		''' <value>true for a text-based axis, false for a linear, log, or date axes.
		''' If this property is true, then you should also provide
		''' an array of labels via <see cref="TextLabels"/>.
		''' </value>
		Public ReadOnly Property IsText() As Boolean
			Get
				Return m_type = AxisType.Text
			End Get
		End Property
		''' <summary>
		''' Gets or sets the <see cref="AxisType"/> for this <see cref="Axis"/>.
		''' The type can be either <see cref="AxisType.Linear"/>,
		''' <see cref="AxisType.Log"/>, <see cref="AxisType.Date"/>,
		''' or <see cref="AxisType.Text"/>.
		''' </summary>
		Public Property Type() As AxisType
			Get
				Return m_type
			End Get
			Set
				m_type = value
			End Set
		End Property
		#end region

		#region " Label Properties"
		''' <summary>
		''' For large scale values, a "magnitude" value (power of 10) is automatically
		''' used for scaling the graph.  This magnitude value is automatically appended
		''' to the end of the <see cref="Axis"/> <see cref="Title"/> (e.g., "(10^4)") to indicate
		''' that a magnitude is in use.  This property controls whether or not the
		''' magnitude is included in the title.  Note that it only affects the axis
		''' title; a magnitude value may still be used even if it is not shown in the title.
		''' </summary>
		''' <value>true to show the magnitude value, false to hide it</value>
		Public Property IsOmitMag() As Boolean
			Get
				Return m_isOmitMag
			End Get
			Set
				m_isOmitMag = value
			End Set
		End Property
		''' <summary>
		''' The text title of this <see cref="Axis"/>.  This normally shows the basis and dimensions of
		''' the scale range, such as "Time (Years)"
		''' </summary>
		''' <value>the title is a string value</value>
		Public Property Title() As String
			Get
				Return m_title
			End Get
			Set
				m_title = value
			End Set
		End Property
		''' <summary>
		''' The format of the <see cref="Axis"/> tic labels.
		''' This field is only used if the <see cref="Type"/> is set to <see cref="AxisType.Date"/>.
		''' </summary>
		''' <value>This format string is as defined for the <see cref="XDate.ToString"/> function</value>
		Public Property ScaleFormat() As String
			Get
				Return m_scaleFormat
			End Get
			Set
				m_scaleFormat = value
			End Set
		End Property
		''' <summary>
		''' Determines whether or not the number of decimal places for value
		''' labels <see cref="NumDec"/> is determined automatically based
		''' on the magnitudes of the scale values.  This value will be set to false if
		''' <see cref="NumDec"/> is manually changed.
		''' </summary>
		''' <value>true if <see cref="NumDec"/> will be set automatically, false
		''' if it is to be set manually by the user</value>
		Public Property NumDecAuto() As Boolean
			Get
				Return m_numDecAuto
			End Get
			Set
				m_numDecAuto = value
			End Set
		End Property
		''' <summary>
		''' The number of decimal places displayed for axis value labels.  This
		''' value can be determined automatically depending on the state of
		''' <see cref="NumDecAuto"/>.  If this value is set manually by the user,
		''' then <see cref="NumDecAuto"/> will also be set to false.
		''' </summary>
		''' <value>the number of decimal places to be displayed for the axis
		''' scale labels</value>
		Public Property NumDec() As Integer
			Get
				Return m_numDec
			End Get
			Set
				m_numDec = value
				Me.m_numDecAuto = False
			End Set
		End Property
		''' <summary>
		''' The magnitude multiplier for scale values.  This is used to limit
		''' the size of the displayed value labels.  For example, if the value
		''' is really 2000000, then the graph will display 2000 with a 10^3
		''' magnitude multiplier.  This value can be determined automatically
		''' depending on the state of <see cref="ScaleMagAuto"/>.
		''' If this value is set manually by the user,
		''' then <see cref="ScaleMagAuto"/> will also be set to false.
		''' </summary>
		''' <value>The magnitude multiplier (power of 10) for the scale
		''' value labels</value>
		Public Property ScaleMag() As Integer
			Get
				Return m_scaleMag
			End Get
			Set
				m_scaleMag = value
				Me.m_scaleMagAuto = False
			End Set
		End Property
		''' <summary>
		''' Determines whether the <see cref="ScaleMag"/> value will be set
		''' automatically based on the data, or manually by the user.  If the
		''' user manually sets the <see cref="ScaleMag"/> value, then this
		''' flag will be set to false.
		''' </summary>
		''' <value>true to have <see cref="ScaleMag"/> set automatically,
		''' false otherwise</value>
		Public Property ScaleMagAuto() As Boolean
			Get
				Return m_scaleMagAuto
			End Get
			Set
				m_scaleMagAuto = value
			End Set
		End Property
		''' <summary>
		''' Gets a reference to the <see cref="ZedGraph.FontSpec"/> class used to render
		''' the scale values
		''' </summary>
		Public ReadOnly Property ScaleFontSpec() As FontSpecs
			Get
				Return m_scaleFontSpec
			End Get
		End Property
		''' <summary>
		''' Gets a reference to the <see cref="ZedGraph.FontSpec"/> class used to render
		''' the <see cref="Axis"/> <see cref="Title"/>,
		''' </summary>
		Public ReadOnly Property TitleFontSpec() As FontSpecs
			Get
				Return m_titleFontSpec
			End Get
		End Property
		#end region

		''' <summary>
		''' Calculate the space required for this <see cref="Axis"/>
		''' object.  This is the space between the paneRect and the axisRect for
		''' this particular axis.
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
		''' <returns>Returns the space, in pixels, required for this axis (between the
		''' paneRect and axisRect)</returns>
		Public Function CalcSpace(g As Graphics, pane As AldysPane, scaleFactor As Double) As Single
			Dim charHeight As Single = Me.ScaleFontSpec.GetHeight(scaleFactor)
			Dim gap As Single = pane.ScaledGap(scaleFactor)
			Dim ticSize As Single = Me.ScaledTic(scaleFactor)

			' axisRect is the actual area of the plot as bounded by the axes

			' Always leave 1xgap space, even if no axis is displayed
			Dim space As Single = gap

			' Account for the Axis
			If Me.m_isVisible Then
				' value text gets actual width, gap gets charHeight / 4, tic gets ticSize
				' charHeight / 4 + 
				space += Me.GetScaleMaxSpace(g, pane, scaleFactor).Height + ticSize

				' Only add space for the label if there is one
				' Axis Title gets actual height plus 1x gap
				If Me.m_title.Length > 0 Then
						' + charHeight / 2 
					space += Me.TitleFontSpec.MeasureString(g, Me.m_title, scaleFactor).Height
				End If
			End If

			Return space
		End Function


		''' <summary>
		''' Get the maximum width of the scale value text that is required to label this
		''' <see cref="Axis"/>.
		''' The results of this method are used to determine how much space is required for
		''' the axis labels.
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
		''' <returns>the maximum width of the text in pixel units</returns>
		Public Function GetScaleMaxSpace(g As Graphics, pane As AldysPane, scaleFactor As Double) As SizeF
			Dim tmpStr As String
			Dim dVal As Double, scaleMult As Double = Math.Pow(DirectCast(10.0, Double), Me.m_scaleMag)
			Dim i As Integer

			Dim nTics As Integer = CalcNumTics()

			Dim startVal As Double = CalcBaseTic()

			Dim maxSpace As New SizeF(0, 0)

			' Repeat for each tic
			i = 0
			While i < nTics
				dVal = CalcMajorTicValue(startVal, i)

				' draw the label
				MakeLabel(i, dVal, tmpStr)

				Dim sizeF As SizeF = Me.ScaleFontSpec.BoundingBox(g, tmpStr, scaleFactor)
				If sizeF.Height > maxSpace.Height Then
					maxSpace.Height = sizeF.Height
				End If
				If sizeF.Width > maxSpace.Width Then
					maxSpace.Width = sizeF.Width
				End If
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While

			Return maxSpace
		End Function
		''' <summary>
		''' Do all rendering associated with this <see cref="Axis"/> to the specified
		''' <see cref="Graphics"/> device.  This method is normally only
		''' called by the Draw method of the parent <see cref="AldysPane"/> object.
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
			Dim saveMatrix As Matrix = g.Transform

			SetupScaleData(pane)

			SetTransformMatrix(g, pane, scaleFactor)

			DrawScale(g, pane, scaleFactor)

			DrawTitle(g, pane, scaleFactor)

			g.Transform = saveMatrix
		End Sub

		''' <summary>
		''' Setup some temporary transform values in preparation for rendering the
		''' <see cref="Axis"/>.  This method is only called by the parent
		''' <see cref="AldysPane"/>
		''' object as part of the Draw method.
		''' </summary>
		''' <param name="pane">
		''' A reference to the <see cref="AldysPane"/> object that is the parent or
		''' owner of this object.
		''' </param>
		Public Sub SetupScaleData(pane As AldysPane)
			' save the axisRect data for transforming scale values to pixels
			Me.minPix = pane.AxisRect.Left
			Me.maxPix = pane.AxisRect.Right



			If Me.m_type = AxisType.Log Then
				Me.minScale = SafeLog(Me.m_min)
				Me.maxScale = SafeLog(Me.m_max)
			Else
				Me.minScale = Me.m_min
				Me.maxScale = Me.m_max
			End If
		End Sub

		''' <summary>
		''' Setup the Transform Matrix to handle drawing of this <see cref="XAxis"/>
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
		Public Sub SetTransformMatrix(g As Graphics, pane As AldysPane, scaleFactor As Double)
			' Move the origin to the BottomLeft of the axisRect, which is the left
			' side of the X axis (facing from the label side)
			g.TranslateTransform(pane.AxisRect.Left, pane.AxisRect.Bottom)
		End Sub
		''' <summary>
		''' Draw the scale, including the tic marks, value labels, and grid lines as
		''' required for this <see cref="Axis"/>.
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
		Public Sub DrawScale(g As Graphics, pane As AldysPane, scaleFactor As Double)
			Dim rightPix As Single, topPix As Single

			rightPix = pane.AxisRect.Width
			topPix = -pane.AxisRect.Height


			' sanity check
			If Me.m_min >= Me.m_max Then
				Return
			End If

			' if the step size is outrageous, then quit
			' (step size not used for log scales)
			If Not Me.IsLog Then
				If Me.m_step <= 0 OrElse Me.m_minorStep <= 0 Then
					Return
				End If

				Dim tMajor As Double = (Me.m_max - Me.m_min) / Me.m_step, tMinor As Double = (Me.m_max - Me.m_min) / Me.m_minorStep
				If IsDate Then
					tMajor /= GetUnitMultiple(m_majorUnit)
					tMinor /= GetUnitMultiple(m_minorUnit)
				End If
				If tMajor > 1000 OrElse ((Me.m_isMinorTic OrElse Me.m_isMinorInsideTic OrElse Me.m_isMinorOppositeTic) AndAlso tMinor > 5000) Then
					Return
				End If
			End If

			' calculate the total number of major tics required
			Dim nTics As Integer = CalcNumTics()
			' get the first major tic value
			Dim baseVal As Double = CalcBaseTic()

			Dim pen As New Pen(Me.m_color, Me.m_ticPenWidth)

			' redraw the axis border
			g.DrawLine(pen, 0F, 0F, rightPix, 0F)

			' draw the major tics and labels
			DrawLabels(g, pane, baseVal, nTics, topPix, scaleFactor)

			DrawMinorTics(g, baseVal, scaleFactor, topPix)

		End Sub
		''' <summary>
		''' Draw the title for this <see cref="Axis"/>.  On entry, it is assumed that the
		''' graphics transform has been configured so that the origin is at the left side
		''' of this axis, and the axis is aligned along the X coordinate direction.
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
		Public Sub DrawTitle(g As Graphics, pane As AldysPane, scaleFactor As Double)
			Dim str As String

			If Me.ScaleMag <> 0 AndAlso Not Me.IsOmitMag Then
				str = Me.m_title + [String].Format(" (10^{0})", Me.ScaleMag)
			Else
				str = Me.m_title
			End If

			' If the Axis is visible, draw the title
			If Me.m_isVisible AndAlso str.Length > 0 Then
				' Calculate the title position in screen coordinates
				Dim x As Single = (Me.maxPix - Me.minPix) / 2
				Dim y As Single = ScaledTic(scaleFactor) + GetScaleMaxSpace(g, pane, scaleFactor).Height
				Dim alignV As FontAlignV = FontAlignV.Top


				' Draw the title
				Me.TitleFontSpec.Draw(g, str, x, y, FontAlignH.Center, alignV, _
					scaleFactor)
			End If
		End Sub
		''' <summary>
		''' Calculate a base 10 logarithm in a safe manner to avoid math exceptions
		''' </summary>
		''' <param name="x">The value for which the logarithm is to be calculated</param>
		''' <returns>The value of the logarithm, or 0 if the <paramref name="x"/>
		''' argument was negative or zero</returns>
		Public Function SafeLog(x As Double) As Double
			If x > 1E-20 Then
				Return Math.Log10(x)
			Else
				Return 0.0
			End If
		End Function
		''' <summary>
		''' Internal routine to determine the ordinals of the first and last major axis label.
		''' </summary>
		''' <returns>
		''' This is the total number of major tics for this axis.
		''' </returns>
		Private Function CalcNumTics() As Integer
			If Me.IsText Then
				' text labels (ordinal scale)
				' If no array of labels is available, just assume 10 labels so we don't blow up.
				If Me.TextLabels = Nothing Then
					Return 10
				Else
					Return Me.TextLabels.Length
				End If
			ElseIf Me.IsDate Then
				' Date-Time scale
				Dim year1 As Integer, year2 As Integer, month1 As Integer, month2 As Integer, day1 As Integer, day2 As Integer, _
					hour1 As Integer, hour2 As Integer, minute1 As Integer, minute2 As Integer, second1 As Integer, second2 As Integer
				Dim nTics As Integer

				XDate.XLDateToCalendarDate(Me.m_min, year1, month1, day1, hour1, minute1, _
					second1)
				XDate.XLDateToCalendarDate(Me.m_max, year2, month2, day2, hour2, minute2, _
					second2)

				Select Case Me.m_majorUnit
					Case DateUnit.Year, Else
						nTics = DirectCast((year2 - year1 + 1.0) / Me.m_step, Integer)
						Exit Select
					Case DateUnit.Month
						nTics = DirectCast((month2 - month1 + 12.0 * (year2 - year1) + 1.0) / Me.m_step, Integer)
						Exit Select
					Case DateUnit.Day
						nTics = DirectCast(((Me.m_max - Me.m_min) + 1.0) / Me.m_step, Integer)
						Exit Select
					Case DateUnit.Hour
						nTics = DirectCast((Me.m_max - Me.m_min) * XDate.HoursPerDay + 1.0, Integer)
						Exit Select
					Case DateUnit.Minute
						nTics = DirectCast((Me.m_max - Me.m_min) * XDate.MinutesPerDay + 1.0, Integer)
						Exit Select
					Case DateUnit.Second
						nTics = DirectCast((Me.m_max - Me.m_min) * XDate.SecondsPerDay + 1.0, Integer)
						Exit Select
				End Select

				If nTics < 1 Then
					nTics = 1
				End If

				Return nTics
			ElseIf Me.IsLog Then
				' log scale
				'iStart = (int) ( Math.Ceiling( SafeLog( this.min ) - 1.0e-12 ) );
				'iEnd = (int) ( Math.Floor( SafeLog( this.max ) + 1.0e-12 ) );
				Return DirectCast(Math.Floor(SafeLog(Me.m_max) + 1E-12), Integer) - DirectCast(Math.Ceiling(SafeLog(Me.m_min) - 1E-12), Integer) + 1
			Else
				' regular linear scale
				Return DirectCast((Me.m_max - Me.m_min) / Me.m_step + 0.01, Integer) + 1
			End If
		End Function

		''' <summary>
		''' Determine the value for the first major tic.  This is done by finding the first possible
		''' value that is an integral multiple of the step size, taking into account the date/time units
		''' if appropriate.
		''' This routine properly
		''' accounts for <see cref="IsLog"/>, <see cref="IsText"/>, and other axis format settings.
		''' </summary>
		''' <returns>
		''' First major tic value (floating point double).
		''' </returns>
		Private Function CalcBaseTic() As Double
			If Me.IsDate Then
				Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer
				XDate.XLDateToCalendarDate(Me.m_min, year, month, day, hour, minute, _
					second)
				Select Case Me.m_majorUnit
					Case DateUnit.Year, Else
						month = 1
						day = 1
						hour = 0
						minute = 0
						second = 0
						Exit Select
					Case DateUnit.Month
						day = 1
						hour = 0
						minute = 0
						second = 0
						Exit Select
					Case DateUnit.Day
						hour = 0
						minute = 0
						second = 0
						Exit Select
					Case DateUnit.Hour
						minute = 0
						second = 0
						Exit Select
					Case DateUnit.Minute
						second = 0
						Exit Select
					Case DateUnit.Second
						Exit Select

				End Select

				Dim xlDate As Double = XDate.CalendarDateToXLDate(year, month, day, hour, minute, second)
				If xlDate < Me.m_min Then
					Select Case Me.m_majorUnit
						Case DateUnit.Year, Else
							System.Math.Max(System.Threading.Interlocked.Increment(year),year - 1)
							Exit Select
						Case DateUnit.Month
							System.Math.Max(System.Threading.Interlocked.Increment(month),month - 1)
							Exit Select
						Case DateUnit.Day
							System.Math.Max(System.Threading.Interlocked.Increment(day),day - 1)
							Exit Select
						Case DateUnit.Hour
							System.Math.Max(System.Threading.Interlocked.Increment(hour),hour - 1)
							Exit Select
						Case DateUnit.Minute
							System.Math.Max(System.Threading.Interlocked.Increment(minute),minute - 1)
							Exit Select
						Case DateUnit.Second
							System.Math.Max(System.Threading.Interlocked.Increment(second),second - 1)
							Exit Select

					End Select

					xlDate = XDate.CalendarDateToXLDate(year, month, day, hour, minute, second)
				End If

				Return xlDate
			ElseIf Me.IsLog Then
				' go to the nearest even multiple of the step size
				Return Math.Ceiling(SafeLog(Me.m_min) - 1E-08)
			ElseIf Me.IsText Then
				Return 1.0
			Else
				' go to the nearest even multiple of the step size
				Return Math.Ceiling(DirectCast(Me.m_min, Double) / DirectCast(Me.m_step, Double) - 1E-08) * DirectCast(Me.m_step, Double)
			End If

		End Function



		''' <summary>
		''' Draw the value labels, tic marks, and grid lines as
		''' required for this <see cref="Axis"/>.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="pane">
		''' A reference to the <see cref="AldysPane"/> object that is the parent or
		''' owner of this object.
		''' </param>
		''' <param name="baseVal">
		''' The first major tic value for the axis
		''' </param>
		''' <param name="nTics">
		''' The total number of major tics for the axis
		''' </param>
		''' <param name="topPix">
		''' The pixel location of the far side of the axisRect from this axis.
		''' This value is the axisRect.Height for the XAxis, or the axisRect.Width
		''' for the YAxis and Y2Axis.
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		Public Sub DrawLabels(g As Graphics, pane As AldysPane, baseVal As Double, nTics As Integer, topPix As Single, scaleFactor As Double)
			Dim dVal As Double
			Dim pixVal As Single
			Dim tmpStr As String
			Dim scaledTic As Single = Me.ScaledTic(scaleFactor)
			Dim scaleMult As Double = Math.Pow(DirectCast(10.0, Double), Me.m_scaleMag)
			Dim pen As New Pen(Me.m_color, Me.m_ticPenWidth)
			Dim dottedPen As New Pen(Me.m_gridColor, Me.m_gridPenWidth)

			dottedPen.DashStyle = DashStyle.[Custom]
			Dim pattern As Single() = New Single(1) {}
			pattern(0) = Me.m_gridDashOn
			pattern(1) = Me.m_gridDashOff
			dottedPen.DashPattern = pattern

			' get the Y position of the center of the axis labels
			' (the axis itself is referenced at zero)
			Dim textCenter As Single = m_ticSize + Me.GetScaleMaxSpace(g, pane, scaleFactor).Height / 2F

			' loop for each major tic
			Dim i As Integer = 0
			While i < nTics
				dVal = CalcMajorTicValue(baseVal, i)

				' If we're before the start of the scale, just go to the next tic
				If dVal < Me.minScale Then
					Continue While
				End If
				' if we've already past the end of the scale, then we're done
				If dVal > Me.maxScale Then
					Exit While
				End If

				' convert the value to a pixel position
				Me.xArrSteps.Add(dVal)
				pixVal = Me.LocalTransform(dVal)

				If Me.m_isVisible Then
					' draw the outside tic
					If Me.m_isTic Then
						g.DrawLine(pen, pixVal, 0F, pixVal, 0F + scaledTic)
					End If

					' draw the inside tic
					If Me.m_isInsideTic Then
						g.DrawLine(pen, pixVal, 0F, pixVal, 0F - scaledTic)
					End If
					'
					'					// draw the opposite tic
					'					if ( this.isOppositeTic )
					'						g.DrawLine( pen, pixVal, topPix, pixVal, topPix + scaledTic );

					' draw the label
					MakeLabel(i, dVal, tmpStr)


					Me.ScaleFontSpec.Draw(g, tmpStr, pixVal, 0F + textCenter, FontAlignH.Center, FontAlignV.Center, _
						scaleFactor)
				End If

				' draw the grid
				If Me.m_isVisible AndAlso Me.m_isShowGrid Then
					g.DrawLine(dottedPen, pixVal, 0F, pixVal, topPix)
				End If
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While
		End Sub

		''' <summary>
		''' Determine the value for any major tic.  This routine properly
		''' accounts for <see cref="IsLog"/>, <see cref="IsText"/>, and other axis format settings.
		''' </summary>
		''' <param name="baseVal">
		''' The value of the first major tic (floating point double)
		''' </param>
		''' <param name="iTic">
		''' The major tic number (0 = first major tic).  For log scales, this is the actual power of 10.
		''' </param>
		''' <returns>
		''' The specified major tic value (floating point double).
		''' </returns>
		Private Function CalcMajorTicValue(baseVal As Double, iTic As Integer) As Double
			If Me.IsDate Then
				' date scale
				Dim xDate As New XDate(baseVal)

				Select Case Me.m_majorUnit
					Case DateUnit.Year, Else
						xDate.AddYears(DirectCast(iTic, Double) * Me.m_step)
						Exit Select
					Case DateUnit.Month
						xDate.AddMonths(DirectCast(iTic, Double) * Me.m_step)
						Exit Select
					Case DateUnit.Day
						xDate.AddDays(DirectCast(iTic, Double) * Me.m_step)
						Exit Select
					Case DateUnit.Hour
						xDate.AddHours(DirectCast(iTic, Double) * Me.m_step)
						Exit Select
					Case DateUnit.Minute
						xDate.AddMinutes(DirectCast(iTic, Double) * Me.m_step)
						Exit Select
					Case DateUnit.Second
						xDate.AddSeconds(DirectCast(iTic, Double) * Me.m_step)
						Exit Select
				End Select

				Return xDate.XLDate
			ElseIf Me.IsLog Then
				' log scale
				Return baseVal * Math.Pow(10.0, DirectCast(iTic, Double))
			Else
				' regular linear scale
				Return baseVal + DirectCast(Me.m_step, Double) * DirectCast(iTic, Double)
			End If
		End Function
		''' <summary>
		''' Transform the coordinate value from user coordinates (scale value)
		''' to graphics device coordinates (pixels), assuming that the origin
		''' has been set to the "left" of this axis, facing from the label side.
		''' Note that the left side corresponds to the scale minimum for the X and
		''' Y2 axes, but it is the scale maximum for the Y axis.
		''' This method takes into
		''' account the scale range (<see cref="Min"/> and <see cref="Max"/>),
		''' logarithmic state (<see cref="IsLog"/>), scale reverse state
		''' (<see cref="IsReverse"/>) and axis type (<see cref="XAxis"/>,
		''' <see cref="YAxis"/>, or <see cref="Y2Axis"/>).  Note that
		''' <see cref="SetupScaleData"/> must be called for the
		''' current configuration before using this method.
		''' </summary>
		''' <param name="x">The coordinate value, in user scale units, to
		''' be transformed</param>
		''' <returns>the coordinate value transformed to screen coordinates
		''' for use in calling the <see cref="DrawScale"/> method</returns>
		Public Function LocalTransform(x As Double) As Single
			' Must take into account Log, and Reverse Axes
			Dim ratio As Double
			Dim rv As Single

			If Me.IsLog Then
				ratio = (SafeLog(x) - Me.minScale) / (Me.maxScale - Me.minScale)
			Else
				ratio = (x - Me.minScale) / (Me.maxScale - Me.minScale)
			End If

			'''/			if ( ( this.isReverse && !(this is YAxis) ) ||
			'''/				( !this.isReverse && (this is YAxis ) ) )
			'''/				rv = (float) ( ( this.maxPix - this.minPix ) * ( 1.0F - ratio ) );
			'''/			else
			rv = DirectCast((Me.maxPix - Me.minPix) * ratio, Single)

			Return rv
		End Function


		''' <summary>
		''' Transform the coordinate value from user coordinates (scale value)
		''' to graphics device coordinates (pixels).  This method takes into
		''' account the scale range (<see cref="Min"/> and <see cref="Max"/>),
		''' logarithmic state (<see cref="IsLog"/>), scale reverse state
		''' (<see cref="IsReverse"/>) and axis type (<see cref="XAxis"/>,
		''' <see cref="YAxis"/>, or <see cref="Y2Axis"/>).  Note that
		''' <see cref="SetupScaleData"/> must be called for the
		''' current configuration before using this method.
		''' </summary>
		''' <param name="x">The coordinate value, in user scale units, to
		''' be transformed</param>
		''' <returns>the coordinate value transformed to screen coordinates
		''' for use in calling the <see cref="Graphics"/> draw routines</returns>
		Public Function Transform(x As Double) As Single
			' Must take into account Log, and Reverse Axes
			Dim ratio As Double
			If Me.IsLog Then
				ratio = (SafeLog(x) - Me.minScale) / (Me.maxScale - Me.minScale)
			Else
				ratio = (x - Me.minScale) / (Me.maxScale - Me.minScale)
			End If

			If Me.m_isReverse Then
				Return DirectCast(Me.maxPix - (Me.maxPix - Me.minPix) * ratio, Single)
			Else
				Return DirectCast(Me.minPix + (Me.maxPix - Me.minPix) * ratio, Single)
			End If

		End Function

		Public Function TransformRev(x As Single) As Double
			' Must take into account Log, and Reverse Axes
			Dim ratio As Double
			If Me.IsLog Then
				ratio = (SafeLog(x) - Me.minScale) / (Me.maxScale - Me.minScale)
			Else
				ratio = (x - Me.minPix) / (Me.maxPix - Me.minPix)
			End If

			If Me.m_isReverse Then
				Return DirectCast(Me.maxScale - (Me.maxScale - Me.minScale) * ratio, Single)
			Else
				Return DirectCast(Me.minScale + (Me.maxScale - Me.minScale) * ratio, Double)
			End If
		End Function

		Public Function ReverseTransform(pixVal As Single) As Double
			Dim val As Double

			val = DirectCast(pixVal - Me.maxPix, Double) / DirectCast(Me.minPix - Me.maxPix, Double) * (Me.maxScale - Me.minScale) + Me.minScale

			If Me.IsLog Then
				val = Math.Pow(10.0, val)
			End If

			Return val
		End Function

		''' <summary>
		''' Make a value label for the axis at the specified ordinal position.  This routine properly
		''' accounts for <see cref="IsLog"/>, <see cref="IsText"/>, and other axis format settings.
		''' </summary>
		''' <param name="index">
		''' The zero-based, ordinal index of the label to be generated.  For example, a value of 2 would
		''' cause the third value label on the axis to be generated.
		''' </param>
		''' <param name="dVal">
		''' The numeric value associated with the label.  This value is ignored for log (<see cref="IsLog"/>)
		''' and text (<see cref="IsText"/>) type axes.
		''' </param>
		''' <param name="label">
		''' Output only.  The resulting value label.
		''' </param>
		Private Sub MakeLabel(index As Integer, dVal As Double, ByRef label As String)
			' draw the label
			If Me.IsText Then
				If Me.TextLabels = Nothing OrElse index < 0 OrElse index >= TextLabels.Length Then
					label = ""
				Else
					label = TextLabels(index)
				End If
			ElseIf Me.IsDate Then
				If Me.m_scaleFormat = Nothing Then
					Me.m_scaleFormat = Defaults.Axis.ScaleFormat
				End If
				label = XDate.ToString(dVal, Me.m_scaleFormat)
			ElseIf Me.IsLog Then
				If index >= -3 AndAlso index <= 4 Then
					label = String.Format("{0}", Math.Pow(10.0, index))
				Else
					label = String.Format("1e{0}", index)
				End If
			Else
				Dim scaleMult As Double = Math.Pow(DirectCast(10.0, Double), Me.m_scaleMag)

				Dim tmpStr As String = "{0:F*}"
				tmpStr = tmpStr.Replace("*", Me.m_numDec.ToString("D"))
				label = [String].Format(tmpStr, dVal / scaleMult)
			End If
		End Sub
		''' <summary>
		''' Internal routine to calculate a multiplier to the selected unit back to days.
		''' </summary>
		''' <param name="unit">The unit type for which the multiplier is to be
		''' calculated</param>
		''' <returns>
		''' This is ratio of days/selected unit
		''' </returns>
		Private Function GetUnitMultiple(unit As DateUnit) As Double
			Select Case unit
				Case DateUnit.Year, Else
					Return 365.0
				Case DateUnit.Month
					Return 30.0
				Case DateUnit.Day
					Return 1.0
				Case DateUnit.Hour
					Return 1.0 / XDate.HoursPerDay
				Case DateUnit.Minute
					Return 1.0 / XDate.MinutesPerDay
				Case DateUnit.Second
					Return 1.0 / XDate.SecondsPerDay
			End Select
		End Function
		''' <summary>
		''' Draw the minor tic marks as
		''' required for this <see cref="Axis"/>.
		''' </summary>
		''' <param name="g">
		''' A graphic device object to be drawn into.  This is normally e.Graphics from the
		''' PaintEventArgs argument to the Paint() method.
		''' </param>
		''' <param name="baseVal">
		''' The scale value for the first major tic position.  This is the reference point
		''' for all other tic marks.
		''' </param>
		''' <param name="scaleFactor">
		''' The scaling factor to be used for rendering objects.  This is calculated and
		''' passed down by the parent <see cref="AldysPane"/> object using the
		''' <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		''' font sizes, etc. according to the actual size of the graph.
		''' </param>
		''' <param name="topPix">
		''' The pixel location of the far side of the axisRect from this axis.
		''' This value is the axisRect.Height for the XAxis, or the axisRect.Width
		''' for the YAxis and Y2Axis.
		''' </param>
		Public Sub DrawMinorTics(g As Graphics, baseVal As Double, scaleFactor As Double, topPix As Single)
			If Me.m_isMinorTic AndAlso Me.m_isVisible AndAlso Not Me.IsText Then
				Dim tMajor As Double = Me.m_step * (If(IsDate, GetUnitMultiple(m_majorUnit), 1.0)), tMinor As Double = Me.m_minorStep * (If(IsDate, GetUnitMultiple(m_minorUnit), 1.0))

				If Me.IsLog OrElse tMinor < tMajor Then
					Dim minorScaledTic As Single = Me.ScaledMinorTic(scaleFactor)

					' Minor tics start at the minimum value and step all the way thru
					' the full scale.  This means that if the minor step size is not
					' an even division of the major step size, the minor tics won't
					' line up with all of the scale labels and major tics.
					Dim dVal As Double = Me.m_min
					Dim pixVal As Single
					Dim pen As New Pen(Me.m_color, Me.m_ticPenWidth)

					Dim iTic As Integer = CalcMinorStart(baseVal)

					' Draw the minor tic marks
					While dVal < Me.m_max AndAlso iTic < 5000
						dVal = CalcMinorTicValue(baseVal, iTic)

						If dVal >= Me.m_min AndAlso dVal <= Me.m_max Then
							pixVal = Me.LocalTransform(dVal)

							' draw the outside tic
							If Me.m_isMinorTic Then
								g.DrawLine(pen, pixVal, 0F, pixVal, 0F + minorScaledTic)
							End If

							' draw the inside tic
							If Me.m_isMinorInsideTic Then
								g.DrawLine(pen, pixVal, 0F, pixVal, 0F - minorScaledTic)

								'							// draw the opposite tic
								'							if ( this.isMinorOppositeTic )
								'								g.DrawLine( pen, pixVal, topPix, pixVal, topPix + minorScaledTic );
							End If
						End If

						System.Math.Max(System.Threading.Interlocked.Increment(iTic),iTic - 1)
					End While
				End If
			End If
		End Sub

		''' <summary>
		''' Determine the value for any minor tic.  This routine properly
		''' accounts for <see cref="IsLog"/>, <see cref="IsText"/>, and other axis format settings.
		''' </summary>
		''' <param name="baseVal">
		''' The value of the first major tic (floating point double).  This tic value is the base
		''' reference for all tics (including minor ones).
		''' </param>
		''' <param name="iTic">
		''' The major tic number (0 = first major tic).  For log scales, this is the actual power of 10.
		''' </param>
		''' <returns>
		''' The specified minor tic value (floating point double).
		''' </returns>
		Private Function CalcMinorTicValue(baseVal As Double, iTic As Integer) As Double
			If Me.IsDate Then
				' date scale
				Dim xDate As New XDate(baseVal)

				Select Case Me.m_minorUnit
					Case DateUnit.Year, Else
						xDate.AddYears(DirectCast(iTic, Double) * Me.m_minorStep)
						Exit Select
					Case DateUnit.Month
						xDate.AddMonths(DirectCast(iTic, Double) * Me.m_minorStep)
						Exit Select
					Case DateUnit.Day
						xDate.AddDays(DirectCast(iTic, Double) * Me.m_minorStep)
						Exit Select
					Case DateUnit.Hour
						xDate.AddHours(DirectCast(iTic, Double) * Me.m_minorStep)
						Exit Select
					Case DateUnit.Minute
						xDate.AddMinutes(DirectCast(iTic, Double) * Me.m_minorStep)
						Exit Select
					Case DateUnit.Second
						xDate.AddSeconds(DirectCast(iTic, Double) * Me.m_minorStep)
						Exit Select
				End Select

				Return xDate.XLDate
			ElseIf Me.IsLog Then
				' log scale
				Return baseVal * Math.Pow(10.0, DirectCast(iTic / 9, Double)) * DirectCast((iTic Mod 9) + 1, Double)
			Else
				' regular linear scale
				Return baseVal + DirectCast(Me.m_minorStep, Double) * DirectCast(iTic, Double)
			End If
		End Function
		''' <summary>
		''' Internal routine to determine the ordinals of the first minor tic mark
		''' </summary>
		''' <param name="baseVal">
		''' The value of the first major tic for the axis.
		''' </param>
		''' <returns>
		''' The ordinal position of the first minor tic, relative to the first major tic.
		''' This value can be negative (e.g., -3 means the first minor tic is 3 minor step
		''' increments before the first major tic.
		''' </returns>
		Private Function CalcMinorStart(baseVal As Double) As Integer
			If Me.IsText Then
				' text labels (ordinal scale)
				' This should never happen (no minor tics for text labels)
				Return 0
			ElseIf Me.IsDate Then
				' Date-Time scale
				Select Case Me.m_majorUnit
					Case DateUnit.Year, Else
						Return DirectCast((Me.m_min - baseVal) / 365.0, Integer)
					Case DateUnit.Month
						Return DirectCast((Me.m_min - baseVal) / 28.0, Integer)
					Case DateUnit.Day
						Return DirectCast(Me.m_min - baseVal, Integer)
					Case DateUnit.Hour
						Return DirectCast((Me.m_min - baseVal) * XDate.HoursPerDay, Integer)
					Case DateUnit.Minute
						Return DirectCast((Me.m_min - baseVal) * XDate.MinutesPerDay, Integer)
					Case DateUnit.Second
						Return DirectCast((Me.m_min - baseVal) * XDate.SecondsPerDay, Integer)
				End Select
			ElseIf Me.IsLog Then
				' log scale
				Return -9
			Else
				' regular linear scale
				Return DirectCast((Me.m_min - baseVal) / Me.m_minorStep, Integer)
			End If
		End Function


		''' <summary>
		''' Create an array of default values for a curve associated with this axis.  The default
		''' values are simple ordinals based on the number of axis labels.
		''' </summary>
		''' <returns>an ordinal array of floating point double values</returns>
		Public Function MakeDefaultArray() As ArrayList
			Dim length As Integer = 10
			If not (Me.IsText AndAlso Me.TextLabels  is nothing)  Then
				length = Me.TextLabels.Length
			End If

			Dim dArray As New ArrayList()

			Dim i As Integer = 0
			While i < length
				dArray.Add(DirectCast(i, Double))
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While

			Return dArray
		End Function


		''' <summary>
		''' Select a reasonable scale given a range of data values.  The scale range is chosen
		''' based on increments of 1, 2, or 5 (because they are even divisors of 10).  This
		''' routine honors the <see cref="MinAuto"/>, <see cref="MaxAuto"/>,
		''' and <see cref="StepAuto"/> autorange settings as well as the <see cref="IsLog"/>
		''' setting.  In the event that any of the autorange settings are false, the
		''' corresponding <see cref="Min"/>, <see cref="Max"/>, or <see cref="Step"/>
		''' setting is explicitly honored, and the remaining autorange settings (if any) will
		''' be calculated to accomodate the non-autoranged values.  The basic defaults for
		''' scale selection are defined using <see cref="Def.Ax.ZeroLever"/> and
		''' <see cref="Def.Ax.TargetSteps"/> from the <see cref="Def"/> default class.
		''' <para>On Exit:</para>
		''' <para><see cref="Min"/> is set to scale minimum (if <see cref="MinAuto"/> = true)</para>
		''' <para><see cref="Max"/> is set to scale maximum (if <see cref="MaxAuto"/> = true)</para>
		''' <para><see cref="Step"/> is set to scale step size (if <see cref="StepAuto"/> = true)</para>
		''' <para><see cref="MinorStep"/> is set to scale minor step size (if <see cref="MinorStepAuto"/> = true)</para>
		''' <para><see cref="ScaleMag"/> is set to a magnitude multiplier according to the data</para>
		''' <para><see cref="NumDec"/> is set to the number of decimal places to display (if <see cref="NumDecAuto"/> = true)</para>
		''' </summary>
		''' <param name="minVal">The minimum value of the data range for setting this
		''' <see cref="Axis"/> scale range</param>
		''' <param name="maxVal">The maximum value of the data range for setting this
		''' <see cref="Axis"/> scale range</param>
		Public Sub PickScale(minVal As Double, maxVal As Double)
			' if the scales are autoranged, use the actual data values for the range
			If Me.m_minAuto Then
				Me.m_min = minVal
			End If
			If Me.m_maxAuto Then
				Me.m_max = maxVal
			End If

			' if this is a text-based axis, then ignore all settings and make it simply ordinal
			If Me.IsText Then
				' if text labels are provided, then autorange to the number of labels
				If not (Me.TextLabels  is nothing)  Then
					If Me.m_minAuto Then
						Me.m_min = 0
					End If
					If Me.m_maxAuto Then
						Me.m_max = Me.TextLabels.Length + 1
					End If
				End If

				' Test for trivial condition of range = 0 and pick a suitable default
				If Me.m_max - Me.m_min < 0.1 Then
					If Me.m_maxAuto Then
						Me.m_max = Me.m_min + 10.0
					Else
						Me.m_min = Me.m_max - 10.0
					End If
				End If

				Me.m_step = 1.0
				Me.m_numDec = 0
				Me.m_scaleMag = 0
			ElseIf Me.IsLog Then
				' Log Scale
				If Me.m_scaleMagAuto Then
					Me.m_scaleMag = 0
				End If
				' Never use a magnitude shift for log scales
				If Me.m_numDecAuto Then
					Me.m_numDec = 0
				End If
				' The number of decimal places to display is not used
				' Check for bad data range
				If Me.m_min <= 0.0 AndAlso Me.m_max <= 0.0 Then
					Me.m_min = 1.0
					Me.m_max = 10.0
				ElseIf Me.m_min <= 0.0 Then
					Me.m_min = Me.m_max / 10.0
				ElseIf Me.m_max <= 0.0 Then
					Me.m_max = Me.m_min * 10.0
				End If

				' Test for trivial condition of range = 0 and pick a suitable default
				If Me.m_max - Me.m_min < 1E-20 Then
					If Me.m_maxAuto Then
						Me.m_max = Me.m_min * 10.0
					Else
						Me.m_min = Me.m_max / 10.0
					End If
				End If

				' Get the nearest power of 10 (no partial log cycles allowed)
				If Me.m_minAuto Then
					Me.m_min = Math.Pow(DirectCast(10.0, Double), Math.Floor(Math.Log10(Me.m_min)))
				End If
				If Me.m_maxAuto Then
					Me.m_max = Math.Pow(DirectCast(10.0, Double), Math.Ceiling(Math.Log10(Me.m_max)))

				End If
			ElseIf Me.IsDate Then
				' Date Scale

				' Test for trivial condition of range = 0 and pick a suitable default
				If Me.m_max - Me.m_min < 1E-20 Then
					If Me.m_maxAuto Then
						Me.m_max = 1.0 + Me.m_min
					Else
						Me.m_min = Me.m_max - 1.0
					End If
				End If

				' Calculate the new step size
				If Me.m_stepAuto Then
					Me.m_step = CalcDateStepSize(Me.m_max - Me.m_min, Defaults.Axis.TargetSteps)
				End If

				' Calculate the scale minimum
				If Me.m_minAuto Then
					Me.m_min = CalcEvenStepDate(Me.m_min, -1)
				End If

				' Calculate the scale maximum
				If Me.m_maxAuto Then
					Me.m_max = CalcEvenStepDate(Me.m_max, 1)
				End If

				Me.m_scaleMag = 0
				' Never use a magnitude shift for date scales
					' The number of decimal places to display is not used
				Me.m_numDec = 0
			Else
				' Linear Scale

				' Test for trivial condition of range = 0 and pick a suitable default
				If Me.m_max - Me.m_min < 1E-20 Then
					If Me.m_maxAuto Then
						Me.m_max = 1.0 + Me.m_min
					Else
						Me.m_min = Me.m_max - 1.0
					End If
				End If

				' This is the zero-lever test.  If minVal is within the zero lever fraction
				' of the data range, then use zero.

				If Me.m_minAuto AndAlso Me.m_min > 0 AndAlso Me.m_min / (Me.m_max - Me.m_min) < Defaults.Axis.ZeroLever Then
					Me.m_min = 0
				End If

				' Repeat the zero-lever test for cases where the maxVal is less than zero
				If Me.m_maxAuto AndAlso Me.m_max < 0 AndAlso Math.Abs(Me.m_max / (Me.m_max - Me.m_min)) < Defaults.Axis.ZeroLever Then
					Me.m_max = 0
				End If

				' Calculate the new step size
				If Me.m_stepAuto Then
					Me.m_step = CalcStepSize(Me.m_max - Me.m_min, Defaults.Axis.TargetSteps)
				End If

				' Calculate the new step size
				If Me.m_minorStepAuto Then
					Me.m_minorStep = CalcStepSize(Me.m_step, Defaults.Axis.TargetMinorSteps)
				End If

				' Calculate the scale minimum
				If Me.m_minAuto Then
					Me.m_min = Me.m_min - MyMod(Me.m_min, Me.m_step)
				End If

				' Calculate the scale maximum
				If Me.m_maxAuto Then
					Me.m_max = If(MyMod(Me.m_max, Me.m_step) = 0.0, Me.m_max, Me.m_max + Me.m_step - MyMod(Me.m_max, Me.m_step))
				End If

				' set the scale magnitude if required
				If Me.m_scaleMagAuto Then
					' Find the optimal scale display multiple
					Dim mag As Double = 0
					Dim mag2 As Double = 0

					If Math.Abs(Me.m_min) > 1E-10 Then
						mag = Math.Floor(Math.Log10(Math.Abs(Me.m_min)))
					End If
					If Math.Abs(Me.m_max) > 1E-10 Then
						mag2 = Math.Floor(Math.Log10(Math.Abs(Me.m_max)))
					End If
					If Math.Abs(mag2) > Math.Abs(mag) Then
						mag = mag2
					End If

					' Do not use scale multiples for magnitudes below 4
					If Math.Abs(mag) <= 3 Then
						mag = 0
					End If

					' Use a power of 10 that is a multiple of 3 (engineering scale)
					Me.m_scaleMag = DirectCast(Math.Floor(mag / 3.0) * 3.0, Integer)
				End If

				' Calculate the appropriate number of dec places to display if required
				If Me.m_numDecAuto Then
					Me.m_numDec = 0 - DirectCast(Math.Floor(Math.Log10(Me.m_step)) - Me.m_scaleMag, Integer)
					If Me.m_numDec < 0 Then
						Me.m_numDec = 0
					End If
				End If
			End If

			Return
		End Sub

		''' <summary>
		''' Calculate a step size for a <see cref="AxisType.Date"/> scale.
		''' This method is used by <see cref="PickScale"/>.
		''' </summary>
		''' <param name="range">The range of data in units of days</param>
		''' <param name="targetSteps">The desired "typical" number of steps
		''' to divide the range into</param>
		''' <returns>The calculated step size for the specified data range.  Also
		''' calculates and sets the values for <see cref="MajorUnit"/>,
		''' <see cref="MinorUnit"/>, <see cref="MinorStep"/>, and
		''' <see cref="ScaleFormat"/></returns>
		Protected Function CalcDateStepSize(range As Double, targetSteps As Double) As Double
			' Calculate an initial guess at step size
			Dim tempStep As Double = range / targetSteps

			If range > Defaults.Axis.RangeYearYear Then
				m_majorUnit = DateUnit.Year
				Me.m_scaleFormat = "&yyyy"
				tempStep = Math.Floor(tempStep / 365.0)
				If tempStep < 1.0 Then
					tempStep = 1.0
				End If

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Year
					If tempStep = 1.0 Then
						m_minorStep = 0.25
					Else
						m_minorStep = CalcStepSize(tempStep, targetSteps)
					End If
				End If
			ElseIf range > Defaults.Axis.RangeYearMonth Then
				m_majorUnit = DateUnit.Year
				Me.m_scaleFormat = "&mmm-&yy"
				tempStep = 1.0

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Month
					' Calculate the minor steps to give an estimated 4 steps
					' per major step.
					m_minorStep = Math.Ceiling(range / (targetSteps * 3) / 30.0)
					' make sure the minorStep is 1, 2, 3, 6, or 12 months
					If m_minorStep > 6 Then
						m_minorStep = 12
					ElseIf m_minorStep > 3 Then
						m_minorStep = 6
					End If
				End If
			ElseIf range > Defaults.Axis.RangeMonthMonth Then
				m_majorUnit = DateUnit.Month
				Me.m_scaleFormat = "&mmm-&yy"
				tempStep = Math.Floor(tempStep / 30.0)
				If tempStep < 1.0 Then
					tempStep = 1.0
				End If
				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Month
					m_minorStep = 0.25
				End If
			ElseIf range > Defaults.Axis.RangeDayDay Then
				m_majorUnit = DateUnit.Day
				m_scaleFormat = "&d-&mmm"
				tempStep = Math.Floor(tempStep)
				If tempStep < 1.0 Then
					tempStep = 1.0
				End If
				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Day
					m_minorStep = 1.0
				End If
			ElseIf range > Defaults.Axis.RangeDayHour Then
				m_majorUnit = DateUnit.Day
				Me.m_scaleFormat = "&d-&mmm &hh:&nn"
				tempStep = 1.0

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Hour
					' Calculate the minor steps to give an estimated 4 steps
					' per major step.
					m_minorStep = Math.Ceiling(range / (targetSteps * 3) * XDate.HoursPerDay)
					' make sure the minorStep is 1, 2, 3, 6, or 12 hours
					If m_minorStep > 6 Then
						m_minorStep = 12
					ElseIf m_minorStep > 3 Then
						m_minorStep = 6
					ElseIf m_minorStep < 1 Then
						m_minorStep = 1
					End If
				End If
			ElseIf range > Defaults.Axis.RangeHourHour Then
				m_majorUnit = DateUnit.Hour
				tempStep = Math.Floor(tempStep * XDate.HoursPerDay)
				m_scaleFormat = "&hh:&nn"

				If tempStep > 12.0 Then
					tempStep = 24.0
				ElseIf tempStep > 6.0 Then
					tempStep = 12.0
				ElseIf tempStep > 3.0 Then
					tempStep = 6.0
				ElseIf tempStep < 1.0 Then
					tempStep = 1.0
				End If

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Hour
					m_minorStep = 0.25
				End If
			ElseIf range > Defaults.Axis.RangeHourMinute Then
				m_majorUnit = DateUnit.Hour
				tempStep = 1.0
				m_scaleFormat = "&hh:&nn"

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Minute
					' Calculate the minor steps to give an estimated 4 steps
					' per major step.
					m_minorStep = Math.Ceiling(range / (targetSteps * 3) * XDate.MinutesPerDay)
					' make sure the minorStep is 1, 5, 15, or 30 minutes
					If m_minorStep > 15.0 Then
						m_minorStep = 30.0
					ElseIf m_minorStep > 5.0 Then
						m_minorStep = 15.0
					ElseIf m_minorStep > 1.0 Then
						m_minorStep = 5.0
					ElseIf m_minorStep < 1.0 Then
						m_minorStep = 1.0
					End If
				End If
			ElseIf range > Defaults.Axis.RangeMinuteMinute Then
				m_majorUnit = DateUnit.Minute
				m_scaleFormat = "&hh:&nn"

				tempStep = Math.Floor(tempStep * XDate.MinutesPerDay)
				' make sure the minute step size is 1, 5, 15, or 30 minutes
				If tempStep > 15.0 Then
					tempStep = 30.0
				ElseIf tempStep > 5.0 Then
					tempStep = 15.0
				ElseIf tempStep > 1.0 Then
					tempStep = 5.0
				ElseIf tempStep < 1.0 Then
					tempStep = 1.0
				End If

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Minute
					m_minorStep = 0.25
				End If
			ElseIf range > Defaults.Axis.RangeMinuteSecond Then
				m_majorUnit = DateUnit.Minute
				tempStep = 1.0
				m_scaleFormat = "&nn:&ss"

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Second
					' Calculate the minor steps to give an estimated 4 steps
					' per major step.
					m_minorStep = Math.Ceiling(range / (targetSteps * 3) * XDate.SecondsPerDay)
					' make sure the minorStep is 1, 5, 15, or 30 seconds
					If m_minorStep > 15.0 Then
						m_minorStep = 30.0
					ElseIf m_minorStep > 5.0 Then
						m_minorStep = 15.0
					ElseIf m_minorStep > 1.0 Then
						m_minorStep = 5.0
					ElseIf m_minorStep < 1.0 Then
						m_minorStep = 1.0
					End If
				End If
			Else
				' SecondSecond
				m_majorUnit = DateUnit.Second
				m_scaleFormat = "&nn:&ss"

				tempStep = Math.Floor(tempStep * XDate.SecondsPerDay)
				' make sure the second step size is 1, 5, 15, or 30 seconds
				If tempStep > 15.0 Then
					tempStep = 30.0
				ElseIf tempStep > 5.0 Then
					tempStep = 15.0
				ElseIf tempStep > 1.0 Then
					tempStep = 5.0
				ElseIf tempStep < 1.0 Then
					tempStep = 1.0
				End If

				If m_minorStepAuto Then
					m_minorUnit = DateUnit.Second
					m_minorStep = 0.25
				End If
			End If

			Return tempStep
		End Function

		''' <summary>
		''' Calculate a date that is close to the specified date and an
		''' even multiple of the selected
		''' <see cref="MajorUnit"/> for a <see cref="AxisType.Date"/> scale.
		''' This method is used by <see cref="PickScale"/>.
		''' </summary>
		''' <param name="date">The date which the calculation should be close to</param>
		''' <param name="direction">The desired direction for the date to take.
		''' 1 indicates the result date should be greater than the specified
		''' date parameter.  -1 indicates the other direction.</param>
		''' <returns>The calculated date</returns>
		Protected Function CalcEvenStepDate([date] As Double, direction As Integer) As Double
			Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer

			XDate.XLDateToCalendarDate([date], year, month, day, hour, minute, _
				second)

			' If the direction is -1, then it is sufficient to go to the beginning of
			' the current time period, .e.g., for 15-May-95, and monthly steps, we
			' can just back up to 1-May-95
			If direction < 0 Then
				direction = 0
			End If

			Select Case m_majorUnit
				Case DateUnit.Year, Else
					' If the date is already an exact year, then don't step to the next year
					If direction = 1 AndAlso month = 1 AndAlso day = 1 AndAlso hour = 0 AndAlso minute = 0 AndAlso second = 0 Then
						Return [date]
					Else
						Return XDate.CalendarDateToXLDate(year + direction, 1, 1, 0, 0, 0)
					End If
				Case DateUnit.Month
					' If the date is already an exact month, then don't step to the next month
					If direction = 1 AndAlso day = 1 AndAlso hour = 0 AndAlso minute = 0 AndAlso second = 0 Then
						Return [date]
					Else
						Return XDate.CalendarDateToXLDate(year, month + direction, 1, 0, 0, 0)
					End If
				Case DateUnit.Day
					' If the date is already an exact Day, then don't step to the next day
					If direction = 1 AndAlso hour = 0 AndAlso minute = 0 AndAlso second = 0 Then
						Return [date]
					Else
						Return XDate.CalendarDateToXLDate(year, month, day + direction, 0, 0, 0)
					End If
				Case DateUnit.Hour
					' If the date is already an exact hour, then don't step to the next hour
					If direction = 1 AndAlso minute = 0 AndAlso second = 0 Then
						Return [date]
					Else
						Return XDate.CalendarDateToXLDate(year, month, day, hour + direction, 0, 0)
					End If
				Case DateUnit.Minute
					' If the date is already an exact minute, then don't step to the next minute
					If direction = 1 AndAlso second = 0 Then
						Return [date]
					Else
						Return XDate.CalendarDateToXLDate(year, month, day, hour, minute + direction, 0)
					End If
				Case DateUnit.Second
					Return XDate.CalendarDateToXLDate(year, month, day, hour, minute, second + direction)

			End Select
		End Function


		''' <summary>
		''' Calculate the modulus (remainder) in a safe manner so that divide
		''' by zero errors are avoided
		''' </summary>
		''' <param name="x">The divisor</param>
		''' <param name="y">The dividend</param>
		''' <returns>the value of the modulus, or zero for the divide-by-zero
		''' case</returns>
		Protected Function MyMod(x As Double, y As Double) As Double
			Dim temp As Double

			If y = 0 Then
				Return 0
			End If

			temp = x / y
			Return y * (temp - Math.Floor(temp))
		End Function
		''' <summary>
		''' Calculate a step size based on a data range.  This utility routine
		''' will try to honor the <see cref="Def.Ax.TargetSteps"/> number of
		''' steps while using a rational increment (1, 2, or 5 -- which are
		''' even divisors of 10).  This method is used by <see cref="PickScale"/>.
		''' </summary>
		''' <param name="range">The range of data in user scale units.  This can
		''' be a full range of the data for the major step size, or just the
		''' value of the major step size to calculate the minor step size</param>
		''' <param name="targetSteps">The desired "typical" number of steps
		''' to divide the range into</param>
		''' <returns>The calculated step size for the specified data range.</returns>
		Protected Function CalcStepSize(range As Double, targetSteps As Double) As Double
			' Calculate an initial guess at step size
			Dim tempStep As Double = range / targetSteps

			' Get the magnitude of the step size
			Dim mag As Double = Math.Floor(Math.Log10(tempStep))
			Dim magPow As Double = Math.Pow(DirectCast(10.0, Double), mag)

			' Calculate most significant digit of the new step size
			Dim magMsd As Double = DirectCast(tempStep / magPow + 0.5, Integer)

			' promote the MSD to either 1, 2, or 5
			If magMsd > 5.0 Then
				magMsd = 10.0
			ElseIf magMsd > 2.0 Then
				magMsd = 5.0
			ElseIf magMsd > 1.0 Then
				magMsd = 2.0
			End If

			Return magMsd * magPow
		End Function










	End Class


End Namespace
