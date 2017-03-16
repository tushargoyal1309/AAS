Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections

Namespace AldysGraph
	''' <summary>	
	''' A class representing all the characteristics of a <see cref="Point"/>
	''' that is plotted as separate scattered point on the graph.
	''' </summary>
	''' 
	'---- Added by Sachin Dokhale
	'	public enum PointsType 
	'	{ Std=1,
	'	  Samp=2
	'	};
	Public Class Point
		Implements ICloneable
		#region " Constructors"
		''' <summary>
		''' Default constructor that sets all <see cref="Point"/> properties to default
		''' values as defined in the <see cref="Def"/> class.
		''' </summary>
		Public Sub New()
			Me.m_x = 0F
			Me.m_y = 0F
			Me.m_pointNumber = 0
			Me.m_isVisible = True
			'Defaults.Point.IsVisible;
			Me.m_isAddedInCurve = False
			'Defaults.Point.IsAddedInCurve;
			Me.m_pointRadius = 10F
			'Defaults.Point.Radius;
			Me.style = DashStyle.Solid
			'Defaults.Point.Style;			
			Me.m_pointColor = Color.Green
			'Defaults.Point.Color;
			'this.point_info.PointsName = "";
			'this.point_info.PointsType = this.points_type.Std ;
			'this.point_info.IsUsed = false;
			Me.point_info = point_infos
			'this.pointinfo = pointinfos;

			Me.pointinfo = pointinfos
		End Sub


		''' <summary>
		''' An overloaded constructor to construct point.
		''' </summary>
		Public Sub New(x As Single, y As Single, pointNumber As Integer, isAddedInCurve As Boolean)
			Me.m_x = x
			Me.m_y = y
			Me.m_pointNumber = pointNumber
			Me.m_isAddedInCurve = isAddedInCurve

			Me.m_isVisible = True
			Me.m_pointRadius = 10F
			Me.style = DashStyle.Solid
			Me.m_pointColor = Color.Green
			Me.point_info = point_infos
			Me.pointinfo = pointinfos
		End Sub


		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The Line object from which to copy</param>
		Public Sub New(rhs As Point)
			Me.m_x = rhs.x
			Me.m_y = rhs.y
			Me.m_pointNumber = rhs.pointNumber
			Me.m_isVisible = rhs.isVisible
			'Defaults.Point.IsVisible;
			Me.m_isAddedInCurve = rhs.isAddedInCurve
			'Defaults.Point.IsAddedInCurve;
			Me.m_pointRadius = rhs.pointRadius
			'Defaults.Point.Radius;
			Me.style = rhs.style
			'Defaults.Point.Style;			
			Me.m_pointColor = rhs.pointColor
			'Defaults.Point.Color;
			Me.point_info = rhs.point_infos
			Me.pointinfo = rhs.pointinfo
		End Sub


		#end region

		#region " ICloneable Members"

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the Point</returns>
		Public Function Clone() As Object
			Return New Point(Me)
		End Function

		#end region

		#region " Class Member Variables"

		Private m_x As Single
		Private m_y As Single
		Private m_pointNumber As Integer
		Private m_isVisible As Boolean
		Private blnIsUse_btnRemove As Boolean = True
		Private m_isAddedInCurve As Boolean
		Private m_pointRadius As Single
		Private style As DashStyle
		Private m_pointColor As Color
		Private mstrPointHeading As String
		Private mobjUserData As ArrayList
		'		//---- Added by Sachin Dokhale
		Private pointinfos As ArrayList
		Public Enum points_type
			Std = 1
			Samp = 2
			StdSamp = 3
		End Enum

		'private string PointName;
		'private bool IsUsed;

		Public Structure _point_info
			Public PointNo As Integer
			Public PointsName As String
			Public IsUsed As Boolean
			Public PointsType As points_type
			Public Sub New(PointNo As Integer, PointsName As String, IsUsed As Boolean, PointsType As points_type)
				Me.PointNo = PointNo
				Me.PointsName = PointsName
				Me.IsUsed = IsUsed
				Me.PointsType = PointsType
			End Sub
		End Structure
		Private point_infos As _point_info


		'-----
		#end region

		#region " Public Properties"

		Public Property X() As Single
			Get
				Return m_x
			End Get
			Set
				m_x = value
			End Set
		End Property

		Public Property Y() As Single
			Get
				Return m_y
			End Get
			Set
				m_y = value
			End Set
		End Property

		Public Property PointNumber() As Integer
			Get
				Return m_pointNumber
			End Get
			Set
				m_pointNumber = value
			End Set
		End Property

		Public Property IsVisible() As Boolean
			Get
				Return m_isVisible
			End Get
			Set
				m_isVisible = value
			End Set
		End Property

		Public Property IsAddedInCurve() As Boolean
			Get
				Return m_isAddedInCurve
			End Get
			Set
				m_isAddedInCurve = value
			End Set
		End Property

		Public Property PointRadius() As Single
			Get
				Return m_pointRadius
			End Get
			Set
				m_pointRadius = value
			End Set
		End Property

		Public Property PointStyle() As DashStyle
			Get
				Return style
			End Get
			Set
				style = value
			End Set
		End Property

		Public Property PointColor() As Color
			Get
				Return m_pointColor
			End Get
			Set
				m_pointColor = value
			End Set
		End Property

		Public Property PointHeading() As String
			Get
				Return mstrPointHeading
			End Get
			Set
				mstrPointHeading = value
			End Set
		End Property

		Public Property UserData() As ArrayList
			Get
				Return mobjUserData
			End Get
			Set
				mobjUserData = value
			End Set
		End Property

		Public Property IsUse_btnRemove() As Boolean
			Get
				Return blnIsUse_btnRemove
			End Get
			Set
				blnIsUse_btnRemove = value
			End Set
		End Property


		Private Property point_info() As _point_info
			Get
				Return point_infos
			End Get
			Set
				point_infos = value
			End Set
		End Property


		Public Property pointinfo() As ArrayList
			Get
				Return pointinfos
			End Get
			Set
				pointinfos = value
			End Set
		End Property

		#end region

		#region " Public Methods"

		Public Sub Draw(g As Graphics, scaleFactor As Double)
			Dim scaledSize As Single = DirectCast(Me.m_pointRadius * scaleFactor, Single)
			Dim hsize As Single = scaledSize / 2

			If Me.m_isVisible Then
				Dim pen As New Pen(Me.m_pointColor)
				pen.DashStyle = Me.style
				g.DrawEllipse(pen, m_x - hsize, m_y - hsize, scaledSize, scaledSize)
			End If
		End Sub

		#end region
	End Class
End Namespace
