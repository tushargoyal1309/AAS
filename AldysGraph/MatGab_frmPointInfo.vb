Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports NETXP.Controls
Imports NETXP.Library
Imports NETXP.Win32


Namespace AldysGraph.PointInfo
	''' <summary>
	''' A Small Ballon-Shaped Window to display 
	''' the selected point information.
	''' </summary>
	''' 

	Public Delegate Sub PointAddRemoveHandler(IsAddPoint As Boolean, pointInfos As Point)
	'	public interface I 
	'				{
	'					//event MyDelegate MyEvent;
	'					event PointAddRemoveHandler AddRemovePoint;
	'					//void FireAway();
	'				}

	Public Class frmPointInfo
		Inherits NETXP.Controls.BalloonWindow
		Private btnClose As NETXP.Controls.XPButton
		Public btnRemove As NETXP.Controls.XPButton
		Private lblPointCaption As System.Windows.Forms.Label
		Private lstViewUserData As System.Windows.Forms.ListView
		Public Event AddRemovePoint As PointAddRemoveHandler
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		'public event PointAddRemoveHandler AddRemovePoint;
		Public Sub New()
			'
			' Required for Windows Form Designer support
			'

				'AddRemovePoint += new PointAddRemoveHandler(GetAddRemovePoint);
				'this.AddRemovePoint += new PointAddRemoveHandler(GetAddRemovePoint);
				'this.AddRemovePoint  += new PointAddRemoveHandler(btnRemove_Click);
				'
				' TODO: Add any constructor code after InitializeComponent call
				'
			InitializeComponent()
		End Sub

		Public Sub New(ptAldysPoint As Point, anchorPoint As System.Drawing.PointF, blnIsAddPoint As Boolean)
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()
			'
			' TODO: Add any constructor code after InitializeComponent call
			'
			mptPointInfo = ptAldysPoint
			NewAnchorPoint = anchorPoint
			mblnIsAddPoint = blnIsAddPoint
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing Then
				If not (components  is nothing)  Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#region " Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.lblPointCaption = New System.Windows.Forms.Label()
			Me.btnClose = New NETXP.Controls.XPButton()
			Me.btnRemove = New NETXP.Controls.XPButton()
			Me.lstViewUserData = New System.Windows.Forms.ListView()
			Me.SuspendLayout()
			' 
			' lblPointCaption
			' 
			Me.lblPointCaption.Font = New System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, DirectCast(0, System.Byte))
			Me.lblPointCaption.Location = New System.Drawing.Point(8, 8)
			Me.lblPointCaption.Name = "lblPointCaption"
			Me.lblPointCaption.Size = New System.Drawing.Size(184, 24)
			Me.lblPointCaption.TabIndex = 2
			Me.lblPointCaption.Text = "Point Information"
			Me.lblPointCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter
			' 
			' btnClose
			' 
			Me.btnClose.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
			Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.btnClose.Location = New System.Drawing.Point(128, 144)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New System.Drawing.Size(64, 24)
			Me.btnClose.TabIndex = 3
			Me.btnClose.Text = "&Close"
			Me.btnClose.Click += New System.EventHandler(Me.btnClose_Click)
			' 
			' btnRemove
			' 
			Me.btnRemove.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
			Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRemove.Location = New System.Drawing.Point(8, 144)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.Size = New System.Drawing.Size(64, 24)
			Me.btnRemove.TabIndex = 4
			Me.btnRemove.Text = "&Remove"
			Me.btnRemove.Click += New System.EventHandler(Me.btnRemove_Click)
			' 
			' lstViewUserData
			' 
			Me.lstViewUserData.AutoArrange = False
			Me.lstViewUserData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lstViewUserData.Font = New System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, DirectCast(0, System.Byte))
			Me.lstViewUserData.FullRowSelect = True
			Me.lstViewUserData.Location = New System.Drawing.Point(8, 32)
			Me.lstViewUserData.Name = "lstViewUserData"
			Me.lstViewUserData.Size = New System.Drawing.Size(184, 104)
			Me.lstViewUserData.TabIndex = 5
			Me.lstViewUserData.View = System.Windows.Forms.View.List
			' 
			' frmPointInfo
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.btnClose
			Me.ClientSize = New System.Drawing.Size(200, 176)
			Me.Controls.Add(Me.lstViewUserData)
			Me.Controls.Add(Me.btnRemove)
			Me.Controls.Add(Me.btnClose)
			Me.Controls.Add(Me.lblPointCaption)
			Me.Name = "frmPointInfo"
			Me.Text = "frmPointInfo"
			Me.Load += New System.EventHandler(Me.frmPointInfo_Load)
			Me.Deactivate += New System.EventHandler(Me.frmPointInfo_Deactivate)
			Me.ResumeLayout(False)

		End Sub
		#end region

		Private mptPointInfo As Point
		Private NewAnchorPoint As System.Drawing.PointF
		Private mblnIsAddPoint As Boolean

		'public delegate void PointAddRemoveHandler(bool IsAddPoint, Point pointInfo);
		'		public interface I 
		'		{
		'			event MyDelegate MyEvent;
		'public event PointAddRemoveHandler AddRemovePoint;
		'			//void FireAway();
		'		}
		#region " I Members"



		#end region


		Private Sub frmPointInfo_Load(sender As Object, e As System.EventArgs)
			Dim btnVisible As Boolean = True
			'Point._point_info eachPointinfo ;

			'this.Focus();

			If mptPointInfo.PointHeading = Nothing Then
				lblPointCaption.Text = "Point Summary"
			Else
				lblPointCaption.Text = mptPointInfo.PointHeading
			End If


			If mptPointInfo.UserData = Nothing Then
				Me.lstViewUserData.Items.Add("X-Value: " + mptPointInfo.X.ToString())
				Me.lstViewUserData.Items.Add("Y-Value: " + mptPointInfo.Y.ToString())
			Else
				Dim i As Integer = 0
				i = 0
				While i < mptPointInfo.UserData.Count
					Me.lstViewUserData.Items.Add(mptPointInfo.UserData(i).ToString())
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
				Me.Focus()
			End If

			'this.AnchorPoint = NewAnchorPoint;
			Me.AnchorPoint = New System.Drawing.Point(DirectCast(NewAnchorPoint.X, Integer), DirectCast(NewAnchorPoint.Y, Integer))


			'			if (mblnIsAddPoint)
			'				btnRemove.Text ="Enable";
			'			else
			'				btnRemove.Text ="Disable";

			If mptPointInfo.IsUse_btnRemove = True Then
				btnRemove.Visible = True
				btnVisible = True
				'				if (mblnIsAddPoint)
				'					btnRemove.Text ="Enable";
				'				else
				'					btnRemove.Text ="Disable";
				For Each m_objptPointInfo As Point._point_info In mptPointInfo.pointinfo
					If m_objptPointInfo.IsUsed <> True Then
						btnRemove.Text = "Enable"
						mblnIsAddPoint = True
						Exit For
					Else
						btnRemove.Text = "Disable"
						mblnIsAddPoint = False
					End If
				Next
			Else
				btnVisible = False
			End If
			'btnRemove.Visible = false;

			'bool btnVisible;
			'point eachPont;
			For Each eachPointinfo As Point._point_info In mptPointInfo.pointinfo
				'eachPointinfo= (Point._point_info)mptPointInfo.pointinfo[i];
				If eachPointinfo.PointsType = Point.points_type.Samp Then
					btnVisible = False
				Else
					If mptPointInfo.IsUse_btnRemove = True Then
						btnVisible = True
						Exit For
					End If
				End If
			Next
			'if (mptPointInfo.pointinfo[0].PointsType == Point.points_type.Samp) 
			If btnVisible = True Then
				btnRemove.Visible = True
			Else
				'if (mptPointInfo.point_info.PointsType = points_type.Samp) 
				btnRemove.Visible = False
			End If
			Me.Focus()
			Me.BringToFront()
			Me.Activate()
			Me.Focus()
			Me.TopMost = True
			Application.DoEvents()
		End Sub

		Private Sub frmPointInfo_Deactivate(sender As Object, e As System.EventArgs)
			'this.Close();
			'this.Dispose();
		End Sub

		Private Sub btnClose_Click(sender As Object, e As System.EventArgs)
			'this.Close();
			'this.Dispose();
			Application.DoEvents()
		End Sub

		Private Sub btnRemove_Click(sender As Object, e As System.EventArgs)
			If mblnIsAddPoint Then
				'if (!m_objptPointInfo.IsUsed)
				btnRemove.Text = "Enable"
				'if (AddRemovePoint != null)
				GetAddRemovePoint(True, mptPointInfo)
			Else
				btnRemove.Text = "Disable"
				'if (AddRemovePoint != null)
				GetAddRemovePoint(False, mptPointInfo)
			End If
			'mblnIsAddPoint = !mblnIsAddPoint;
			Me.Close()
			Me.Dispose()
			Application.DoEvents()
		End Sub
		Public Sub GetAddRemovePoint(IsAddPointIn As Boolean, pointInfosIn As Point)
			If not (AddRemovePoint  is nothing)  Then
				AddRemovePoint(IsAddPointIn, pointInfosIn)
			End If
		End Sub

		'		#region " I Members"
		'
		'		event AldysGraph.PointInfo.PointAddRemoveHandler AldysGraph.PointInfo.I.AddRemovePoint;
		'
		'		#end region
	End Class
End Namespace
