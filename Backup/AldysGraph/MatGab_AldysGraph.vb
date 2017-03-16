Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace AldysGraph
	''' <summary>
	''' Summary description for AldysGraph.
	''' </summary>
	''' 			
	Public Class AldysGraph
		Inherits System.Windows.Forms.UserControl
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		''' <summary>
		''' This private field contains the instance for the AldysPane object of this control.
		''' You can access the AldysPane object through the public property
		''' <see cref="AldysPane"/>.
		''' </summary>
		Private objAldysPane As AldysPane

		Private mouseDown As Boolean = False
		Private mouseMoving As Boolean = False
		Private haveRect As Boolean = False
		Private XDown As Integer
		Private YDown As Integer
		Private oldX As Integer, oldY As Integer
		Public Zoom As Boolean
		Public ShowXYValues As Boolean
		Private ShowPointInfo As Boolean

		Private tBar As TrackBar
		Private psymbol As PeakSymbol.PSymbol
		Private pXYCord As PeakSymbol.PSymbol
		Public ShowXYPeak As Boolean = False
		Public pXYCordBackColor As Color = Color.White
		Public pXYCordStringColor As Color = Color.Black
		Public pXYFont As FontSpecs

		Public trackBarColor As Color
		Public peakLineColor As Color
		Public peakLineWidth As Integer
		Private pHandler As PeakEditArgs

		Private CustEvent As System.Windows.Forms.MouseEventArgs

		Public Delegate Sub PeakEditHandler(o As Object, e As PeakEditArgs)

		Public Delegate Sub CustPaneEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs)

		'public delegate void PointAddRemoveHandler(bool IsAddPoint, PointF pointInfo);
		'public event PointAddRemoveHandler AddRemovePoint;

		Public Event CustPaneMouseDown As CustPaneEvent

		Public Event peakEvent As PeakEditHandler

		Public blnShowRainboBand As Boolean = False

		Public Delegate Sub AxisChangeEvent()
		'object sender, System.Windows.Forms.MouseEventArgs e);
		Public Event OnAxisChange As AxisChangeEvent

		Private rect As RubberbandRectangle
		Public CustPan As GradientPanel.CustomPanel
		Private pd As PrintDocument
		Private bitGraphBitmap As Bitmap

		Public Delegate Sub SendCurveStatus(o As Object, e As CurveStatus)

		Public Event StatusEvent As SendCurveStatus

		Private HighPeakCurve As CurveItem

		Private mobjAldysGraphCursor As Cursor = Nothing
		Private bln_IsAvoideProcess As Boolean

		Public Delegate Sub PointAddRemoveHandler(IsAddPoint As Boolean, pointInfo As Point)
		Public Event AddRemovePoint As PointAddRemoveHandler

		Private pointToolTip As ToolTip
		Private mobjAldysGraphPrintColor As Color = Color.Black

		<DllImport("GDI32.dll", CharSet := CharSet.Auto)> _
		Public Shared Function BitBlt(hdcDest As IntPtr, nXDest As Integer, nYDest As Integer, nWidth As Integer, nHeight As Integer, hdcSrc As IntPtr, _
			nXSrc As Integer, nYSrc As Integer, dwRop As Int32) As Boolean
		End Function

		Public Sub GetStatusEventEx(cs As CurveStatus)
			If Me.objAldysPane.statusflag Then
				Dim cStatus As New CurveStatus(1)
				If not (StatusEvent  is nothing)  Then
					StatusEvent(Me, cStatus)
				End If
			End If
		End Sub

		Public Property GraphImage() As Bitmap
			Get
				Return bitGraphBitmap
			End Get
			Set
				bitGraphBitmap = value
			End Set
		End Property

		Public Property AldysGraphCursor() As Cursor
			Get
				Return mobjAldysGraphCursor
			End Get
			Set
				mobjAldysGraphCursor = value
			End Set
		End Property

		Public Property AldysGraphPrintColor() As Color
			Get
				Return mobjAldysGraphPrintColor
			End Get
			Set
				mobjAldysGraphPrintColor = value
			End Set
		End Property


		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
			Me.MouseMove += New MouseEventHandler(AldysGraph_MouseMove)
			Me.MouseUp += New MouseEventHandler(AldysGraph_MouseUp)
			Me.MouseDown += New MouseEventHandler(AldysGraph_MouseDown)

			pd = New PrintDocument()
			pd.PrintPage += New PrintPageEventHandler(pd_PrintPage)

			' TODO: Add any initialization after the InitComponent call
			Dim rect As New Rectangle(0, 0, Me.Size.Width, Me.Size.Height)
			objAldysPane = New AldysPane(rect, "Aldys", "X-Axis", "Y-Axis", Me)
			Me.tBar = New TrackBar()
			Me.psymbol = New PeakSymbol.PSymbol()
			Me.pXYCord = New PeakSymbol.PSymbol()
			Me.pXYFont = New FontSpecs("Arial", 10, Color.Black, False, False, False)
			Me.trackBarColor = Color.PowderBlue
			Me.peakLineColor = Color.Violet
			Me.peakLineWidth = 1
			Me.Zoom = False
			Me.pointToolTip = New ToolTip()
		End Sub
		''' <summary>
		''' Gets or sets the <see cref="AldysPane"/> property for the control
		''' </summary>
		Public Property AldysPane() As AldysPane
			Get
				Return objAldysPane
			End Get
			Set
				objAldysPane = value
			End Set
		End Property
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

		#region " Component Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.CustPan = New GradientPanel.CustomPanel()
			Me.SuspendLayout()
			' 
			' CustPan
			' 
			Me.CustPan.BackColor = System.Drawing.Color.FromArgb(DirectCast(205, System.Byte), DirectCast(225, System.Byte), DirectCast(250, System.Byte))
			Me.CustPan.BackColor2 = System.Drawing.Color.FromArgb(DirectCast(175, System.Byte), DirectCast(200, System.Byte), DirectCast(245, System.Byte))
			Me.CustPan.Dock = System.Windows.Forms.DockStyle.Fill
			Me.CustPan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, DirectCast(0, System.Byte))
			Me.CustPan.GradientMode = GradientPanel.LinearGradientMode.Vertical
			Me.CustPan.Location = New System.Drawing.Point(0, 0)
			Me.CustPan.Name = "CustPan"
			Me.CustPan.Size = New System.Drawing.Size(150, 150)
			Me.CustPan.TabIndex = 0
			Me.CustPan.MouseUp += New System.Windows.Forms.MouseEventHandler(Me.CustPan_MouseUp)
			Me.CustPan.Paint += New System.Windows.Forms.PaintEventHandler(Me.CustPan_Paint)
			Me.CustPan.MouseMove += New System.Windows.Forms.MouseEventHandler(Me.CustPan_MouseMove)
			Me.CustPan.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.CustPan_MouseDown)

			' 
			' AldysGraph
			' 
			Me.BackColor = System.Drawing.Color.LightGray
			Me.Controls.Add(Me.CustPan)
			Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, DirectCast(0, System.Byte))
			Me.Name = "AldysGraph"
			Me.Resize += New System.EventHandler(Me.ChangeSize)
			Me.Load += New System.EventHandler(Me.AldysGraph_Load)
			Me.ResumeLayout(False)

		End Sub
		#end region

		''' <summary>
		''' Called by the system to update the control on-screen
		''' </summary>
		''' <param name="e">
		''' A PaintEventArgs object containing the Graphics specifications
		''' for this Paint event.
		''' </param>

		Protected Overrides Sub OnPaint(e As PaintEventArgs)
		End Sub

		' Draws the RubberRectangle onto the client area using the
		' RubberbandRectangle class.

		Private Sub RubberRectangle(X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer)
			Dim g As System.Drawing.Graphics = Graphics.FromHwnd(CustPan.Handle)

			rect = New RubberbandRectangle()
			rect.DrawXORRectangle(g, X1, Y1, X2, Y2)
		End Sub

		Public Sub EnablePeakTrace(CurveIndex As Integer, Flag As Boolean)
			Dim intTotalTic As Integer, intTics As Integer
			Try
				If Flag Then
					Me.objAldysPane.EnablePeakEdit(CurveIndex, Flag)

					CustPan.Controls.Add(tBar)
					CustPan.Controls.Add(psymbol)

					'this.Controls.Add(tBar);
					'this.Controls.Add(psymbol);
					Me.tBar.Scroll += New EventHandler(tBar_Scroll)
					Me.tBar.AutoSize = False
						'-(50*this.objAldysPane.TmpScalefactor)
					Me.tBar.Location = New System.Drawing.Point(DirectCast(Me.objAldysPane.AxisRect.X - (12 * Me.objAldysPane.TmpScalefactor), Integer), DirectCast(Me.objAldysPane.PaneRect.Y, Integer))
					'----- Added by Sachin Dokhale on 07.05.07
					'this.tBar.Size = (new Size((int)(this.objAldysPane.AxisRect.Width+(20*this.objAldysPane.TmpScalefactor)),(int)(10*this.objAldysPane.TmpScalefactor)));

					Me.tBar.Size = (New Size(DirectCast(Me.objAldysPane.AxisRect.Width + (20 * Me.objAldysPane.TmpScalefactor), Integer), DirectCast(45 * Me.objAldysPane.TmpScalefactor, Integer)))
					intTotalTic = DirectCast(Me.objAldysPane.XAxis.Max - Me.objAldysPane.XAxis.Min, Integer)
					intTics = DirectCast(intTotalTic / objAldysPane.CurveList(CurveIndex).NPts, Integer)
					'-----

					Me.tBar.Maximum = Me.objAldysPane.peakX.Count - 1
					Me.tBar.TickFrequency = 1
					Me.tBar.LargeChange = 10
					Me.tBar.SmallChange = 1
					Me.tBar.Visible = True
					Me.tBar.BackColor = Me.trackBarColor
					Dim x As Double, y As Double = 0
					x = DirectCast(Me.objAldysPane.peakX(0), Double)
					y = DirectCast(Me.objAldysPane.peakY(0), Double)
					Me.psymbol.Location = New System.Drawing.Point(DirectCast(x, Integer), DirectCast(y - (30 * Me.objAldysPane.TmpScalefactor), Integer))
					Me.psymbol.Visible = True
					Me.psymbol.BackColor = Me.peakLineColor

					Me.psymbol.Height = DirectCast(60 * Me.objAldysPane.TmpScalefactor, Integer)
					'(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height);
					Me.psymbol.Width = Me.peakLineWidth
					pHandler = New PeakEditArgs(0, 0)
					If not (peakEvent  is nothing)  Then
						peakEvent(Me, pHandler)
					End If

					'this.tBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top ) 
					'	| System.Windows.Forms.AnchorStyles.Left) 
					'	| System.Windows.Forms.AnchorStyles.Right)));
					'this.tBar. = 0;

					If ShowXYPeak = True Then
						'this.Controls.Add(pXYCord);
						CustPan.Controls.Add(pXYCord)
						If objAldysPane.XAxis.IsVisible = False Then
							Me.pXYCord.Location = New System.Drawing.Point(DirectCast(objAldysPane.AxisRect.Right / 2 - (50 * Me.objAldysPane.TmpScalefactor), Integer), DirectCast((objAldysPane.AxisRect.Bottom) - (18 * Me.objAldysPane.TmpScalefactor), Integer))
						Else
							'----- Added by Sachin Dokhale on 07.05.07
							'this.pXYCord.Location = new System.Drawing.Point( (int) (objAldysPane.AxisRect.Right /2 -( 50*this.objAldysPane.TmpScalefactor))  ,(int)((objAldysPane.AxisRect.Bottom)+(20*this.objAldysPane.TmpScalefactor))	);
							Me.pXYCord.Location = New System.Drawing.Point(DirectCast(objAldysPane.AxisRect.Right / 2 - (50 * Me.objAldysPane.TmpScalefactor), Integer), DirectCast((objAldysPane.AxisRect.Bottom) + (30 * Me.objAldysPane.TmpScalefactor), Integer))
						End If
						'------												
						Me.pXYCord.Visible = True
						Me.pXYCord.BackColor = Me.pXYCordBackColor
						'----- Added by Sachin Dokhale on 07.05.07
						'this.pXYCord.Height = (int)(50*this.objAldysPane.TmpScalefactor);//(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height);
						Me.pXYCord.Height = DirectCast(35 * Me.objAldysPane.TmpScalefactor, Integer)
						'(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height);
						'-----
							'(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height); //this.peakLineWidth;
						Me.pXYCord.Width = DirectCast(160 * Me.objAldysPane.TmpScalefactor, Integer)
					End If
				Else
					Me.tBar.Visible = False
					Me.psymbol.Visible = False
					Me.pXYCord.Visible = False
					CustPan.Controls.Remove(tBar)
					CustPan.Controls.Remove(psymbol)
					CustPan.Controls.Remove(pXYCord)

					Me.objAldysPane.EnablePeakEdit(CurveIndex, False)
				End If
			Catch e As IndexOutOfRangeException
				MessageBox.Show(e.Message)
			End Try
		End Sub

		Private Sub AldysGraph_Load(sender As Object, e As System.EventArgs)

		End Sub

		Private Sub ChangeSize(sender As Object, e As System.EventArgs)
			Me.objAldysPane.paneRect = New RectangleF(0, 0, Me.Size.Width, Me.Size.Height)
			Me.Invalidate()
			If Me.objAldysPane.bPeakEdit Then
				Me.EnablePeakTrace(Me.objAldysPane.peakCurveIndex, False)
			End If
		End Sub

		Private Sub AldysGraph_MouseMove(sender As Object, e As MouseEventArgs)
			'			if(!Zoom) return;
			'			if(this.objAldysPane.axisRect.Contains(e.X,e.Y))
			'			{
			'				if( mouseDown )
			'				{
			'				
			'					if( mouseMoving )
			'						RubberRectangle( XDown, YDown, oldX, oldY );
			'					RubberRectangle( XDown, YDown, e.X, e.Y );
			'					mouseMoving = true;
			'					oldX = e.X;
			'					oldY = e.Y;
			'				}
			'			}
		End Sub

		Private Sub AldysGraph_MouseUp(sender As Object, e As MouseEventArgs)
			'			if(!Zoom) return;
			'			try
			'			{
			'			
			'				if(e.Button == MouseButtons.Left && mouseMoving == true)
			'				{
			'					//very bad
			'					//if(this.objAldysPane.XAxis.Type == AxisType.Date) return;
			'					this.EnablePeakTrace(this.objAldysPane.peakCurveIndex,false);
			'					if(this.objAldysPane.XAxis.Type == AxisType.Linear)
			'					{
			'						if(XDown < oldX)
			'						{
			'							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(XDown));
			'							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(oldX));
			'							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(oldY));
			'							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(YDown));
			'						}
			'						else if(XDown > oldX)
			'						{
			'							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(oldX));
			'							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(XDown));
			'							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(YDown));
			'							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(oldY));
			'						}
			'					}
			'					else if(this.objAldysPane.XAxis.Type == AxisType.Date)
			'					{
			'						bool tmpFlag = false;
			'						if(XDown < oldX)
			'						{						
			'							
			'							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
			'							{
			'								if(!tmpFlag)
			'								{
			'									double db = this.objAldysPane.XAxis.TransformRev(XDown);
			'									double db1 = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
			'									if((this.objAldysPane.XAxis.TransformRev(XDown))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			'									{
			'										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
			'										tmpFlag = true;
			'									}
			'								}
			'								if(tmpFlag)
			'								{
			'									if((this.objAldysPane.XAxis.TransformRev(oldX))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			'									{
			'										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
			'										break;
			'									}
			'								}
			'							}
			'							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
			'							{
			'								if(!tmpFlag)
			'								{
			'									if((this.objAldysPane.YAxis.TransformRev(oldY))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			'									{
			'										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
			'										tmpFlag = true;
			'									}
			'								}
			'								if(tmpFlag)
			'								{
			'									if((this.objAldysPane.YAxis.TransformRev(YDown))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			'									{
			'										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
			'										break;
			'									}
			'								}
			'							}
			'
			'
			'
			'						}
			'						else if(XDown > oldX)
			'						{
			'							
			'
			'							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
			'							{
			'								if(!tmpFlag)
			'								{
			'									if((this.objAldysPane.XAxis.TransformRev(oldX))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			'									{
			'										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
			'										tmpFlag = true;
			'									}
			'								}
			'								if(tmpFlag)
			'								{
			'									if((this.objAldysPane.XAxis.TransformRev(XDown))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			'									{
			'										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
			'										break;
			'									}
			'								}
			'							}
			'							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
			'							{
			'								if(!tmpFlag)
			'								{
			'									if((this.objAldysPane.YAxis.TransformRev(YDown))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			'									{
			'										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
			'										tmpFlag = true;
			'									}
			'								}
			'								if(tmpFlag)
			'								{
			'									if((this.objAldysPane.YAxis.TransformRev(oldY))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			'									{
			'										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
			'										break;
			'									}
			'								}
			'							}
			'						}
			'					}
			'
			'					//Find the points 
			'					for(int icount = 0;icount < this.objAldysPane.CurveList.Count;icount++)
			'					{
			'						int arrcount = 0;					
			'						ArrayList arrXd = new ArrayList();
			'						ArrayList arrYd = new ArrayList();										
			'						arrcount = this.objAldysPane.CurveList[icount].X.Count;
			'						for(int pcount = 0;pcount < arrcount;pcount++)
			'						{
			'							if(this.objAldysPane.XAxis.Type == AxisType.Linear)
			'							{
			'								if(((int)((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&((int)((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
			'								{						
			'									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
			'									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
			'								}
			'
			'							}
			'							else if(this.objAldysPane.XAxis.Type == AxisType.Date)
			'							{
			'								if((((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&(((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
			'								{						
			'									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
			'									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
			'								}
			'
			'							}
			'													
			'						}
			'						this.objAldysPane.CurveList[icount].X = arrXd;
			'						this.objAldysPane.CurveList[icount].Y = arrYd;
			'					}
			'				
			'					//take all the points in the rect. get the point which are in the rect
			'
			'					this.objAldysPane.AxisChange();
			'					this.Invalidate();
			'					//this.objAldysPane.Draw(Graphics.FromHwnd(this.Handle));
			'					mouseDown = false;
			'					mouseMoving = false;
			'					haveRect = true;	// Clear the flag
			'					//Invalidate();		// Clear out the rectangle.
			'				}
			'			}
			'			catch(IndexOutOfRangeException err)
			'			{
			'				MessageBox.Show(err.Message);
			'			}
			'			mouseDown = false;
			'			mouseMoving = false;
			'			haveRect = true;	
		End Sub

		Private Sub AldysGraph_MouseDown(sender As Object, e As MouseEventArgs)
			'			if(!Zoom) return;
			'			if( e.Button == MouseButtons.Left )
			'			{
			'				mouseDown = true;
			'				XDown = e.X;
			'				YDown = e.Y;
			'				mouseMoving = false;
			'			}
			'			else if( e.Button == MouseButtons.Right )
			'			{
			'				if( haveRect )
			'				{
			'					haveRect = false;	// Clear the flag
			'					Invalidate();		// Clear out the rectangle.
			'				}
			'			}
		End Sub

		Private Sub tBar_Scroll(sender As Object, e As EventArgs)
			Try
				If Me.objAldysPane.bPeakEdit Then
					Dim strFormat As New StringFormat()

					Dim brush As New SolidBrush(Me.pXYCordStringColor)
					'SolidBrush brush = new SolidBrush(Color.Blue); 

					Dim x As Double, y As Double, xpeak As Double, ypeak As Double

					x = InlineAssignHelper(y, 0)
					x = DirectCast(Me.objAldysPane.peakX(Me.tBar.Value), Double)
					y = DirectCast(Me.objAldysPane.peakY(Me.tBar.Value), Double)

					Me.psymbol.Location = New System.Drawing.Point(DirectCast(x, Integer), DirectCast(y - (30 * Me.objAldysPane.TmpScalefactor), Integer))
					'this.pHandler.X = x;
					'this.pHandler.Y = y;
					pHandler = New PeakEditArgs(DirectCast(Me.objAldysPane.CurveList(Me.objAldysPane.peakCurveIndex).X(Me.tBar.Value), Double), DirectCast(Me.objAldysPane.CurveList(Me.objAldysPane.peakCurveIndex).Y(Me.tBar.Value), Double))
					If not (peakEvent  is nothing)  Then
						peakEvent(Me, pHandler)
					End If

					Dim g As Graphics = Graphics.FromHwnd(pXYCord.Handle)
					Dim strDummy As [String]
					xpeak = DirectCast(Me.objAldysPane.CurveList(Me.objAldysPane.peakCurveIndex).X(Me.tBar.Value), Double)
					xpeak = Math.Round(xpeak, 4)

					ypeak = DirectCast(Me.objAldysPane.CurveList(Me.objAldysPane.peakCurveIndex).Y(Me.tBar.Value), Double)
					ypeak = Math.Round(ypeak, 4)
					'strDummy = "X: "+ xpeak.ToString() + "\nY: "+ ypeak.ToString();
					strDummy = vbLf & "X: " + xpeak.ToString() + ", Y: " + ypeak.ToString()
					pXYCord.Refresh()

					'''28.04.08
					Dim ff As Font = New System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, DirectCast(0, System.Byte))

					If objAldysPane.XAxis.IsVisible = False Then
						g.DrawString(strDummy, pXYFont.GetFont(Me.objAldysPane.TmpScalefactor + 0.1), brush, 0F, 0F, strFormat)
					Else
						g.DrawString(strDummy, ff, New SolidBrush(Color.DarkBlue), 0F, 0F, strFormat)
						'''28.04.08
					End If

				Else
				End If
			Catch err As IndexOutOfRangeException
				MessageBox.Show(err.Message)
			End Try
		End Sub

		Public Function PrintGraph() As Boolean
			Dim printRes As New ArrayList()
			Dim pkResolution As PrinterResolution
			Dim i As Integer = 0
			While i < pd.PrinterSettings.PrinterResolutions.Count
				pkResolution = pd.PrinterSettings.PrinterResolutions(i)
					'MessageBox.Show(pkResolution.ToString());  
				printRes.Add(pkResolution)
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While
			'System.Drawing.Printing.PrintEventArgs p =  new System.Drawing.Printing.PrintEventArgs();
			Dim margins As New Margins(20, 0, 0, 150)
			pd.DefaultPageSettings.Margins = margins
			'pd.DefaultPageSettings.PrinterResolution = (PrinterResolution)printRes[6]; 
			'pd.DefaultPageSettings.Landscape = true; 

			pd.Print()
			'PrintPreviewDialog dlg = new PrintPreviewDialog(); 
			'dlg.Document = pd; 
			'dlg.ShowDialog();
			Return True
		End Function

		Public Function PrintPreViewGraph() As Boolean
			Dim printRes As New ArrayList()
			Dim pkResolution As PrinterResolution
			Dim i As Integer = 0
			While i < pd.PrinterSettings.PrinterResolutions.Count
				pkResolution = pd.PrinterSettings.PrinterResolutions(i)
					'MessageBox.Show(pkResolution.ToString());  
				printRes.Add(pkResolution)
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While

			'System.Drawing.Printing.PrintEventArgs p =  new System.Drawing.Printing.PrintEventArgs();
			Dim margins As New Margins(20, 0, 0, 150)
			pd.DefaultPageSettings.Margins = margins
			'pd.DefaultPageSettings.PrinterResolution = (PrinterResolution)printRes[6]; 
			'pd.DefaultPageSettings.Landscape = true; 

			'pd.Print(); 
			Dim dlg As New PrintPreviewDialog()
			dlg.Document = pd
			dlg.ShowDialog()
			Return True
		End Function

		Private Sub pd_PrintPage(sender As Object, e As PrintPageEventArgs)
			Dim g As Graphics = e.Graphics
			'AldysPane obj =(AldysPane)this.objAldysPane.Clone();
			'AldysPane obj  = (AldysPane)this.AldysPane.CurveList[1].X[1] =   
			Dim obj As AldysPane = DirectCast(Me.AldysPane.Clone(), AldysPane)

			obj.statusflag = False
			Dim rect As New Rectangle(60, 60, 500, 500)
			obj.paneRect = rect
			obj.Draw(g)
		End Sub

		Public Function DrawGraphOnGraphics(g As Graphics, leftpos As Integer, toppos As Integer, width As Integer, height As Integer) As Boolean
			Dim obj As AldysPane = DirectCast(Me.objAldysPane.Clone(), AldysPane)
			obj.statusflag = False
			Dim rect As New Rectangle(leftpos, toppos, width, height)
			obj.paneRect = rect
			obj.IsShowTitle = True
			'obj.Legend.IsVisible =true;
			obj.Legend.FontSpec.FontColor = Color.Black
			obj.Legend.FrameColor = Color.Black
			obj.FontSpec.FontColor = Color.Black
			obj.XAxis.IsShowGrid = True
			obj.XAxis.Color = Me.AldysGraphPrintColor
			obj.YAxis.IsShowGrid = True
			obj.IsPaneFramed = True
			obj.PaneFrameColor = Color.Black
			obj.Draw(g)
			Return True
		End Function

		Public Sub GetImageOfGraph()
			Dim obj As AldysPane = DirectCast(Me.objAldysPane.Clone(), AldysPane)
			obj.statusflag = False
			Dim g As Graphics = Me.CreateGraphics()
			g.Clear(Color.White)
			obj.IsShowTitle = True
			'obj.Legend.IsVisible =true;
			obj.Legend.FontSpec.FontColor = Color.Black
			obj.Legend.FrameColor = Color.Black
			obj.FontSpec.FontColor = Color.Black
			obj.XAxis.IsShowGrid = True
			obj.YAxis.IsShowGrid = True
			obj.IsPaneFramed = True
			obj.PaneFrameColor = Color.Black

			Dim srcBmp As New Bitmap(DirectCast(obj.paneRect.Width, Integer), DirectCast(obj.paneRect.Bottom, Integer), g)
			'srcBmp.Save (Application.StartupPath +  "/Graph.bmp");

			Dim srcMem As Graphics
			srcMem = Graphics.FromImage(srcBmp)

			Dim HDC1 As IntPtr = g.GetHdc()
			Dim HDC2 As IntPtr = srcMem.GetHdc()
			'Get the picture
			BitBlt(HDC2, 0, 0, DirectCast(obj.paneRect.Width, Integer), DirectCast(obj.paneRect.Height, Integer), HDC1, _
				DirectCast(obj.paneRect.X, Integer), DirectCast(obj.paneRect.Y, Integer), 13369376)

			bitGraphBitmap = DirectCast(srcBmp.Clone(), Bitmap)
			g.ReleaseHdc(HDC1)
			srcMem.ReleaseHdc(HDC2)
			g.Dispose()
			srcMem.Dispose()
		End Sub

		Public Sub GetImage()

		End Sub

		Private Sub pict_Paint(s As [Object], e As PaintEventArgs)
			Dim obj As AldysPane = DirectCast(Me.objAldysPane.Clone(), AldysPane)
			obj.statusflag = False
			obj.Draw(e.Graphics)
			'pict.Image.Save(Application.StartupPath + "/GPH.BMP");   
		End Sub

		Private Sub CustPan_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
			MyBase.OnPaint(e)
			'objAldysPane.hwnd = CustPan.Handle; 
			Me.objAldysPane.Draw(e.Graphics)

			objAldysPane.hwnd = Me.Handle

			Me.objAldysPane.CurveList.isResizing = True

			If blnShowRainboBand Then
				If not (OnAxisChange  is nothing)  Then
					OnAxisChange()
				End If
			End If
		End Sub

		'			private void CustPan_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		'			{
		'			if(!Zoom) return;
		'			try
		'			{
		'			
		'				 
		'				if(e.Button == MouseButtons.Left && mouseMoving == true)
		'				{
		'					//very bad
		'					//if(this.objAldysPane.XAxis.Type == AxisType.Date) return;
		'					this.EnablePeakTrace(this.objAldysPane.peakCurveIndex,false);
		'					if(this.objAldysPane.XAxis.Type == AxisType.Linear)
		'					{
		'						if(XDown < oldX)
		'						{
		'							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(XDown));
		'							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(oldX));
		'							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(oldY));
		'							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(YDown));
		'						}
		'						else if(XDown > oldX)
		'						{
		'							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(oldX));
		'							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(XDown));
		'							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(YDown));
		'							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(oldY));
		'						}
		'					}
		'					else if(this.objAldysPane.XAxis.Type == AxisType.Date)
		'					{
		'						bool tmpFlag = false;
		'						if(XDown < oldX)
		'						{						
		'							
		'							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
		'							{
		'								if(!tmpFlag)
		'								{
		'									double db = this.objAldysPane.XAxis.TransformRev(XDown);
		'									double db1 = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
		'									if((this.objAldysPane.XAxis.TransformRev(XDown))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		'									{
		'										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
		'										tmpFlag = true;
		'									}
		'								}
		'								if(tmpFlag)
		'								{
		'									if((this.objAldysPane.XAxis.TransformRev(oldX))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		'									{
		'										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
		'										break;
		'									}
		'								}
		'							}
		'							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
		'							{
		'								if(!tmpFlag)
		'								{
		'									if((this.objAldysPane.YAxis.TransformRev(oldY))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		'									{
		'										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
		'										tmpFlag = true;
		'									}
		'								}
		'								if(tmpFlag)
		'								{
		'									if((this.objAldysPane.YAxis.TransformRev(YDown))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		'									{
		'										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
		'										break;
		'									}
		'								}
		'							}
		'
		'
		'
		'						}
		'						else if(XDown > oldX)
		'						{
		'							
		'
		'							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
		'							{
		'								if(!tmpFlag)
		'								{
		'									if((this.objAldysPane.XAxis.TransformRev(oldX))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		'									{
		'										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
		'										tmpFlag = true;
		'									}
		'								}
		'								if(tmpFlag)
		'								{
		'									if((this.objAldysPane.XAxis.TransformRev(XDown))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		'									{
		'										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
		'										break;
		'									}
		'								}
		'							}
		'							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
		'							{
		'								if(!tmpFlag)
		'								{
		'									if((this.objAldysPane.YAxis.TransformRev(YDown))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		'									{
		'										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
		'										tmpFlag = true;
		'									}
		'								}
		'								if(tmpFlag)
		'								{
		'									if((this.objAldysPane.YAxis.TransformRev(oldY))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		'									{
		'										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
		'										break;
		'									}
		'								}
		'							}
		'						}
		'					}
		'
		'					//Find the points 
		'					for(int icount = 0;icount < this.objAldysPane.CurveList.Count;icount++)
		'					{
		'						int arrcount = 0;					
		'						ArrayList arrXd = new ArrayList();
		'						ArrayList arrYd = new ArrayList();										
		'						arrcount = this.objAldysPane.CurveList[icount].X.Count;
		'						for(int pcount = 0;pcount < arrcount;pcount++)
		'						{
		'							if(this.objAldysPane.XAxis.Type == AxisType.Linear)
		'							{
		'								if(((int)((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&((int)((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
		'								{						
		'									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
		'									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
		'								}
		'
		'							}
		'							else if(this.objAldysPane.XAxis.Type == AxisType.Date)
		'							{
		'								if((((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&(((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
		'								{						
		'									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
		'									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
		'								}
		'
		'							}
		'													
		'						}
		'						this.objAldysPane.CurveList[icount].X = arrXd;
		'						this.objAldysPane.CurveList[icount].Y = arrYd;
		'					}
		'				
		'					//take all the points in the rect. get the point which are in the rect
		'
		'					this.objAldysPane.XAxis.StepAuto =true;
		'					this.objAldysPane.XAxis.MinorStepAuto  =true;
		'
		'					this.objAldysPane.YAxis.StepAuto =true;
		'					this.objAldysPane.YAxis.MinorStepAuto  =true;
		'
		'					this.objAldysPane.AxisChange();
		'					this.Invalidate();
		'					//this.objAldysPane.Draw(Graphics.FromHwnd(this.Handle));
		'					mouseDown = false;
		'					mouseMoving = false;
		'					haveRect = true;	// Clear the flag
		'					//Invalidate();		// Clear out the rectangle.
		'				}
		'			}
		'			catch(IndexOutOfRangeException err)
		'			{
		'				MessageBox.Show(err.Message);
		'			}
		'			mouseDown = false;
		'			mouseMoving = false;
		'			haveRect = true;
		'		}
		Private Sub CustPan_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
			If Not Zoom Then
				Return
			End If
			Try
				If e.Button = MouseButtons.Left AndAlso mouseMoving = True Then
					'very bad
					'if(this.objAldysPane.XAxis.Type == AxisType.Date) return;
					Me.EnablePeakTrace(Me.objAldysPane.peakCurveIndex, False)

					If Me.objAldysPane.XAxis.Type = AxisType.Linear Then
						If XDown < oldX Then
							Me.objAldysPane.XAxis.Min = Math.Floor(Me.objAldysPane.XAxis.TransformRev(XDown))
							Me.objAldysPane.XAxis.Max = Math.Ceiling(Me.objAldysPane.XAxis.TransformRev(oldX))
							Me.objAldysPane.YAxis.Min = Math.Floor(Me.objAldysPane.YAxis.TransformRev(oldY))
							Me.objAldysPane.YAxis.Max = Math.Ceiling(Me.objAldysPane.YAxis.TransformRev(YDown))
						ElseIf XDown > oldX Then
							Me.objAldysPane.XAxis.Min = Math.Floor(Me.objAldysPane.XAxis.TransformRev(oldX))
							Me.objAldysPane.XAxis.Max = Math.Ceiling(Me.objAldysPane.XAxis.TransformRev(XDown))
							Me.objAldysPane.YAxis.Min = Math.Floor(Me.objAldysPane.YAxis.TransformRev(YDown))
							Me.objAldysPane.YAxis.Max = Math.Ceiling(Me.objAldysPane.YAxis.TransformRev(oldY))
						End If
					ElseIf Me.objAldysPane.XAxis.Type = AxisType.[Date] Then
						Dim tmpFlag As Boolean = False
						If XDown < oldX Then

							Dim ncount As Integer = 0
							While ncount < Me.objAldysPane.XAxis.xArrSteps.Count
								If Not tmpFlag Then
									Dim db As Double = Me.objAldysPane.XAxis.TransformRev(XDown)
									Dim db1 As Double = DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount), Double)
									If (Me.objAldysPane.XAxis.TransformRev(XDown)) < DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount), Double) Then
										Me.objAldysPane.XAxis.Min = DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount - 1), Double)
										tmpFlag = True
									End If
								End If
								If tmpFlag Then
									If (Me.objAldysPane.XAxis.TransformRev(oldX)) <= DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount), Double) Then
										Me.objAldysPane.XAxis.Max = DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount), Double)
										Exit While
									End If
								End If
								System.Math.Max(System.Threading.Interlocked.Increment(ncount),ncount - 1)
							End While
							Dim nycount As Integer = 0
							While nycount < Me.objAldysPane.YAxis.yArrSteps.Count
								If Not tmpFlag Then
									If (Me.objAldysPane.YAxis.TransformRev(oldY)) < DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount), Double) Then
										Me.objAldysPane.YAxis.Min = DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount - 1), Double)
										tmpFlag = True
									End If
								End If
								If tmpFlag Then
									If (Me.objAldysPane.YAxis.TransformRev(YDown)) <= DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount), Double) Then
										Me.objAldysPane.YAxis.Max = DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount), Double)
										Exit While
									End If
								End If
								System.Math.Max(System.Threading.Interlocked.Increment(nycount),nycount - 1)
							End While
						ElseIf XDown > oldX Then
							Dim ncount As Integer = 0
							While ncount < Me.objAldysPane.XAxis.xArrSteps.Count
								If Not tmpFlag Then
									If (Me.objAldysPane.XAxis.TransformRev(oldX)) < DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount), Double) Then
										Me.objAldysPane.XAxis.Min = DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount - 1), Double)
										tmpFlag = True
									End If
								End If
								If tmpFlag Then
									If (Me.objAldysPane.XAxis.TransformRev(XDown)) <= DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount), Double) Then
										Me.objAldysPane.XAxis.Max = DirectCast(Me.objAldysPane.XAxis.xArrSteps(ncount), Double)
										Exit While
									End If
								End If
								System.Math.Max(System.Threading.Interlocked.Increment(ncount),ncount - 1)
							End While
							Dim nycount As Integer = 0
							While nycount < Me.objAldysPane.YAxis.yArrSteps.Count
								If Not tmpFlag Then
									If (Me.objAldysPane.YAxis.TransformRev(YDown)) < DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount), Double) Then
										Me.objAldysPane.YAxis.Min = DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount - 1), Double)
										tmpFlag = True
									End If
								End If
								If tmpFlag Then
									If (Me.objAldysPane.YAxis.TransformRev(oldY)) <= DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount), Double) Then
										Me.objAldysPane.YAxis.Max = DirectCast(Me.objAldysPane.YAxis.yArrSteps(nycount), Double)
										Exit While
									End If
								End If
								System.Math.Max(System.Threading.Interlocked.Increment(nycount),nycount - 1)
							End While
						End If
					End If


					'						double x1, x2, y1, y2;
					'						PointF endPoint=new PointF(oldX ,oldY);
					'						PointF startPoint=((Control)sender).PointToClient(new Point(XDown,YDown));
					'
					'						this.AldysPane.ReverseTransform(startPoint, out x1,out y1);
					'						this.AldysPane.ReverseTransform(endPoint, out x2, out y2);  
					'						
					'						x1=this.AldysPane.XAxis.TransformRev(XDown);
					'						x2=this.AldysPane.XAxis.TransformRev(oldX);
					'						y1=this.AldysPane.YAxis.TransformRev(oldY);
					'						y2=this.AldysPane.YAxis.TransformRev(YDown);
					'
					'						this.AldysPane.XAxis.Min = Math.Min(x1,x2);
					'						this.AldysPane.XAxis.Max = Math.Max(x1,x2);
					'						this.AldysPane.YAxis.Min = Math.Min(y1,y2);
					'						this.AldysPane.YAxis.Max = Math.Max(y1,y2);

					'take all the points in the rect. get the point which are in the rect

					Me.objAldysPane.XAxis.StepAuto = True
					Me.objAldysPane.XAxis.MinorStepAuto = True

					Me.objAldysPane.YAxis.StepAuto = True
					Me.objAldysPane.YAxis.MinorStepAuto = True

					Me.objAldysPane.AxisChange()
					Me.Invalidate()
					'this.objAldysPane.Draw(Graphics.FromHwnd(this.Handle));
					mouseDown = False
					mouseMoving = False
						' Clear the flag
						'Invalidate();		// Clear out the rectangle.
					haveRect = True
				End If
			Catch err As IndexOutOfRangeException
				MessageBox.Show(err.Message)
			End Try
			mouseDown = False
			mouseMoving = False
			haveRect = True
		End Sub

		Public Sub CustPan_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)

			If bln_IsAvoideProcess = True Then
				Return
			End If

			bln_IsAvoideProcess = True

			CustEvent = New MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta)
			If not (CustPaneMouseDown  is nothing)  Then
				CustPaneMouseDown(sender, CustEvent)
			End If

			If Zoom Then
				Dim x As Double, y As Double
				Me.objAldysPane.ReverseTransform(New PointF(e.X, e.Y), x, y)

				If x < Me.objAldysPane.XAxis.Min OrElse x > Me.objAldysPane.XAxis.Max OrElse y < Me.objAldysPane.YAxis.Min OrElse y > Me.objAldysPane.YAxis.Max Then
					bln_IsAvoideProcess = False
					Return
				End If

				Select Case e.Button
					Case MouseButtons.Left
						mouseDown = True
						XDown = e.X
						YDown = e.Y
						mouseMoving = False
						Exit Select
					Case MouseButtons.Right
						If haveRect Then
							haveRect = False
							' Clear the flag
								' Clear out the rectangle.
							Invalidate()
						End If
						Exit Select
				End Select
			End If
			'--End of Zoom If

			If ShowPointInfo AndAlso Not Zoom Then
				'---Added By Mangesh S. on 25-Nov-2006
				'---Display a small window showing the Point Information.
				Dim x As Double, y As Double, xpeak As Double, ypeak As Double, x1 As Double, y1 As Double
				Dim i As Integer, peakInfoCurveIndex As Integer, x2 As Integer, y2 As Integer
				Dim blnIsAddPoint As Boolean
				Dim pointIndex As Integer = 0

				Dim objAldysPoint As Point = Nothing
				'objAldysPoint= (Point)this.objAldysPane.CurveList[peakInfoCurveIndex].ScatteredPoints[0]

				'PointInfo.frmPointInfo objfrmPointInfo;
				'objfrmPointInfo.AddRemovePoint  += new PointInfo.PointAddRemoveHandler();
				Me.objAldysPane.ReverseTransform(New PointF(e.X, e.Y), x, y)

				If x < Me.objAldysPane.XAxis.Min OrElse x > Me.objAldysPane.XAxis.Max OrElse y < Me.objAldysPane.YAxis.Min OrElse y > Me.objAldysPane.YAxis.Max Then
					bln_IsAvoideProcess = False
					Return
				End If

				xpeak = InlineAssignHelper(ypeak, InlineAssignHelper(x1, InlineAssignHelper(y1, 0.0)))
				blnIsAddPoint = False
				peakInfoCurveIndex = Me.objAldysPane.peakInfoCurveIndex

				i = 0
				While i < Me.objAldysPane.CurveList(peakInfoCurveIndex).X.Count
					x1 = DirectCast(objAldysPane.CurveList(peakInfoCurveIndex).X(i), Double)
					If x1 >= x - 0.5 AndAlso x1 <= x + 0.5 Then
						xpeak = x1
						pointIndex = i
						Exit While
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
				i = 0
				While i < Me.objAldysPane.CurveList(peakInfoCurveIndex).X.Count
					y1 = DirectCast(objAldysPane.CurveList(peakInfoCurveIndex).Y(i), Double)
					If y1 >= y - 0.5 AndAlso y1 <= y + 0.5 Then
						ypeak = y1
						'pointIndex = i;						
						Exit While
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While

				If xpeak = 0.0 OrElse ypeak = 0.0 Then
					i = 0
					While i < objAldysPane.CurveList(peakInfoCurveIndex).ScatteredPoints.Count
						objAldysPoint = DirectCast(objAldysPane.CurveList(peakInfoCurveIndex).ScatteredPoints(i), Point)
						Dim objPoint As PointF = Me.objAldysPane.GeneralTransform(New PointF(objAldysPoint.X, objAldysPoint.Y), CoordType.AxisXYScale)

						If objPoint.X >= e.X - 5 AndAlso objPoint.X <= e.X + 5 Then
							If objPoint.Y >= e.Y - 5 AndAlso objPoint.Y <= e.Y + 5 Then
								xpeak = DirectCast(objAldysPoint.X, Double)
								ypeak = DirectCast(objAldysPoint.Y, Double)
								'blnIsAddPoint=true; 
								blnIsAddPoint = objAldysPoint.IsAddedInCurve
								pointIndex = objAldysPoint.PointNumber
								Exit While
							End If
						End If
						System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
					End While
				End If

				xpeak = Math.Round(xpeak, 4)
				ypeak = Math.Round(ypeak, 4)

				Select Case e.Button
					Case MouseButtons.Left
						If xpeak > 0.0 AndAlso ypeak > 0.0 Then
							If not (objAldysPoint  is nothing)  Then
								x2 = Me.Location.X + e.X + 4
								y2 = Me.Location.Y + e.Y + 20

								If not (Me.Parent  is nothing)  Then
									x2 = x2 + Me.Parent.Location.X
									y2 = y2 + Me.Parent.Location.Y
								End If
								If not (Me.Parent.Parent  is nothing)  Then
									x2 = x2 + Me.Parent.Parent.Location.X
									y2 = y2 + Me.Parent.Parent.Location.Y
								End If
								If not (Me.Parent.Parent.Parent  is nothing)  Then
									x2 = x2 + Me.Parent.Parent.Parent.Location.X
									y2 = y2 + Me.Parent.Parent.Parent.Location.Y
								End If

								Dim objfrmPointInfo As PointInfo.frmPointInfo
								objfrmPointInfo = Nothing
								objfrmPointInfo = New PointInfo.frmPointInfo(objAldysPoint, New System.Drawing.PointF(x2, y2), blnIsAddPoint)
								Application.DoEvents()
								objfrmPointInfo.AddRemovePoint += New PointInfo.PointAddRemoveHandler(objfrmPointInfo_AddRemovePoint)
								'objfrmPointInfo.ShowBalloon(this.Parent);
								objfrmPointInfo.ShowDialog(Me.Parent)
								Application.DoEvents()
								objfrmPointInfo.Close()
								objfrmPointInfo.Dispose()
								'objfrmPointInfo.ShowDialog(this.Parent);
								'objfrmPointInfo.BringToFront();
								'objfrmPointInfo.Activate();   
								'objfrmPointInfo.Focus();  
								'objfrmPointInfo.TopMost=true; 
								Application.DoEvents()
							End If
						End If
						Exit Select

					Case MouseButtons.Right
						Exit Select
				End Select
			End If
			bln_IsAvoideProcess = False
		End Sub

		Private Sub CustPan_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
			If Zoom = True Then
				If Me.objAldysPane.axisRect.Contains(e.X, e.Y) Then
					If mouseDown Then
						If mouseMoving Then
							RubberRectangle(XDown, YDown, oldX, oldY)
						End If
						RubberRectangle(XDown, YDown, e.X, e.Y)
						mouseMoving = True
						oldX = e.X
						oldY = e.Y
					End If
				End If
			End If
			'--End Zoom If

			If ShowXYValues = True Then
				Dim x As Double, y As Double
				Me.objAldysPane.ReverseTransform(New PointF(e.X, e.Y), x, y)

				Dim toolTip As String = "[X:" + Math.Round(x, 4).ToString() + ",Y:" + Math.Round(y, 4).ToString() + "]"

				'modified by deepak b. on 28.01.06 to set the limit for tooltip.
				If x < Me.objAldysPane.XAxis.Min OrElse x > Me.objAldysPane.XAxis.Max OrElse y < Me.objAldysPane.YAxis.Min OrElse y > Me.objAldysPane.YAxis.Max Then
					Me.pointToolTip.Active = False
				Else
					Me.pointToolTip.SetToolTip(Me.CustPan, toolTip)
					Me.pointToolTip.Active = True
					'					
				End If
			Else
				Me.pointToolTip.Active = False
			End If
			'--End ShowXYValues If		

			If ShowPointInfo AndAlso Not Zoom Then
				'---Added By Mangesh S. on 21-Feb-2007
				'---To change the Mouse Cursor over AldysPane
				Dim x As Double, y As Double

				Me.objAldysPane.ReverseTransform(New PointF(e.X, e.Y), x, y)

				If x < Me.objAldysPane.XAxis.Min OrElse x > Me.objAldysPane.XAxis.Max OrElse y < Me.objAldysPane.YAxis.Min OrElse y > Me.objAldysPane.YAxis.Max Then
					Return
				End If

				If not (Me.mobjAldysGraphCursor  is nothing)  Then
					Cursor.Current = Me.mobjAldysGraphCursor
				End If
				Return
			End If
			'--End Show PointInfo If
		End Sub

		Public Sub EnableShowPointInfo(CurveIndex As Integer, Flag As Boolean)
			Try
				If Flag Then
					Me.objAldysPane.EnableShowPeakInfo(CurveIndex, True)
					Me.ShowPointInfo = True
				Else
					Me.ShowPointInfo = False
					Me.objAldysPane.EnableShowPeakInfo(CurveIndex, False)
				End If
			Catch e As IndexOutOfRangeException
				MessageBox.Show(e.Message)
			End Try
		End Sub

		Public Sub objfrmPointInfo_AddRemovePoint(IsAddPoint As Boolean, pointInfo As Point)
			Dim peakInfoCurveIndex As Integer = Me.objAldysPane.peakInfoCurveIndex
			Dim ptIndex As Integer = -1
			Dim ptPointInfo As Point = Nothing


			'---Enable the Selected Point from the Selected CurveItem in CurveList.
			If IsAddPoint Then
				Dim i As Integer
				i = 0
				While i < objAldysPane.CurveList.Count
					If objAldysPane.CurveList(i).IsScatteredPointsCurve Then
						ptIndex = objAldysPane.CurveList(i).ScatteredPoints.IndexOf(pointInfo)
						If ptIndex > -1 Then
							Exit While
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While

				If ptIndex > -1 Then
					ptPointInfo = DirectCast(objAldysPane.CurveList(i).ScatteredPoints(ptIndex), Point)
					DirectCast(objAldysPane.CurveList(i).ScatteredPoints(ptIndex), Point).IsAddedInCurve = False
					DirectCast(objAldysPane.CurveList(i).ScatteredPoints(ptIndex), Point).PointColor = Color.Red
				End If
			Else
				'---Enable the Selected Point from the Selected CurveItem in CurveList.
				Dim i As Integer
				i = 0
				While i < objAldysPane.CurveList.Count
					If objAldysPane.CurveList(i).IsScatteredPointsCurve Then
						ptIndex = objAldysPane.CurveList(i).ScatteredPoints.IndexOf(pointInfo)
						If ptIndex > -1 Then
							Exit While
						End If
					End If
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While

				If ptIndex > -1 Then
					ptPointInfo = DirectCast(objAldysPane.CurveList(i).ScatteredPoints(ptIndex), Point)
					DirectCast(objAldysPane.CurveList(i).ScatteredPoints(ptIndex), Point).IsAddedInCurve = True
					DirectCast(objAldysPane.CurveList(i).ScatteredPoints(ptIndex), Point).PointColor = Color.Black
				End If
			End If
			objAldysPane.AxisChange()
			Invalidate()
			If ptIndex > -1 Then
				If IsAddPoint Then
					'btnRemove.Text = "Enable";
					If not (AddRemovePoint  is nothing)  Then
						AddRemovePoint(True, ptPointInfo)
					End If
				Else
					'btnRemove.Text ="Disable";
					If not (AddRemovePoint  is nothing)  Then
						AddRemovePoint(False, ptPointInfo)
					End If
				End If
			End If
		End Sub

		Public Sub DrawHighestPeakLine(PeakCurve As CurveItem)
			Dim dblMaxYValue As Double, dblXValue As Double, dblYValue As Double
			dblMaxYValue = InlineAssignHelper(dblXValue, InlineAssignHelper(dblYValue, 0.0))

			For Each curve As CurveItem In Me.AldysPane.CurveList
				If curve.IsHighPeakLine Then
					Return
					'High Peak Line Already exists in the CurveList.
				End If
			Next

			Dim i As Integer = 0
			While i < PeakCurve.X.Count
				dblYValue = DirectCast(PeakCurve.Y(i), Double)
				If dblYValue > dblMaxYValue Then
					dblMaxYValue = dblYValue
					dblXValue = DirectCast(PeakCurve.X(i), Double)
				End If
				System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
			End While

			Dim arrX As New ArrayList()
			Dim arrY As New ArrayList()

			arrX.Add(0.0)
			arrY.Add(0.0)

			HighPeakCurve = AldysPane.AddCurve("Peak Height", arrX, arrY, Color.Blue, SymbolType.NoSymbol)
			HighPeakCurve.IsHighPeakLine = True
			HighPeakCurve.HighPeakXValue = dblXValue
			HighPeakCurve.HighPeakYValue = dblMaxYValue
			HighPeakCurve.Symbol.IsFilled = True
			HighPeakCurve.AddPointFlg = True
			HighPeakCurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid
			AldysPane.CurveList.isResizing = True
			AldysPane.IsIgnoreInitial = True

			AldysPane.AxisChange()
			Invalidate()

			HighPeakCurve.X.Add(dblXValue)
			HighPeakCurve.Y.Add(dblMaxYValue)

			HighPeakCurve.X.Add(dblXValue)
			HighPeakCurve.Y.Add(0.0)

			AldysPane.AxisChange()
			Invalidate()
		End Sub

		Public Sub ShowHighPeakLineLabel(strHighPeakLabel As String, blnIsShowYValue As Boolean, FontSpecSize As Integer)
			Dim name As String = ""
			Dim x As Double, y As Double
			Dim ShowedHighPeakCurve As CurveItem
			Dim HighPeakCurve As CurveItem = Nothing

			For Each curve As CurveItem In Me.AldysPane.CurveList
				If curve.IsHighPeakLine Then
					HighPeakCurve = curve
				Else
					ShowedHighPeakCurve = curve
				End If
			Next
			If HighPeakCurve = Nothing Then
				Return
			End If
			'No High Peak Line exists in the CurveList.
			x = HighPeakCurve.HighPeakXValue
			y = HighPeakCurve.HighPeakYValue
			'y = y + 1.5; 


			If strHighPeakLabel = Nothing Then
				strHighPeakLabel = "Max Y-Value "
			End If

			'following blank space is added by deepak on 06.03.07

			'Show the label vertically offset to actual point by a unit pixel.


			If blnIsShowYValue Then
				name = strHighPeakLabel + " = " + y.ToString() + "    "
			Else
				name = strHighPeakLabel + " = " + x.ToString() + "    "
			End If

			'TextItem text = new TextItem(name, x, y);			

			'if (ShowedHighPeakCurve != null)
'			{ 

			'				if ((AldysPane.YAxis.Max - (double)AldysPane.YAxis.MajorUnit) >= y) 
			'					{	if (FontSpecSize == 0) 
			'							y = AldysPane.YAxis.Max-((double)objAldysPane.TmpScalefactor*10);                       
			'						else 
			'							y = AldysPane.YAxis.Max-((double)objAldysPane.TmpScalefactor*10);
			'							
			'
			'					}
			'}
					'text.FontSpec.Size = AldysPane.CurveLabelSize; 
			If AldysPane.CurveLabelSize <> 0 Then
			End If

			Dim text As New TextItem(name, DirectCast(x, Single), DirectCast(y, Single))
			text.CoordinateFrame = CoordType.AxisXYScale

			text.AlignH = FontAlignH.Center
			text.AlignV = FontAlignV.Bottom

			If FontSpecSize = 0 Then
				text.FontSpec.Size = 17F
			Else
				text.FontSpec.Size = DirectCast(FontSpecSize, Single)
			End If

			text.ForHighPeakLabel = True
			text.FontSpec.IsFramed = True
			text.FontSpec.FontColor = HighPeakCurve.Line.Color
			AldysPane.TextList.Add(text)

			AldysPane.AxisChange()
			Invalidate()
		End Sub

		Public Sub RemoveHighPeakLineLabel()
			For Each curve As CurveItem In Me.AldysPane.CurveList
				If curve.IsHighPeakLine Then
					If not (curve.LabelX  is nothing)  Then
						curve.Label = curve.LabelX
					End If
				End If
			Next
			If HighPeakCurve = Nothing Then
				Return
			End If
			'No High Peak Line exists in the CurveList.
			Dim intTextCount As Integer = 0
			While intTextCount < AldysPane.TextList.Count
				If AldysPane.TextList(intTextCount).ForHighPeakLabel = True Then
					AldysPane.TextList.Remove(intTextCount)
					intTextCount -= 1
					If AldysPane.TextList.Count = 0 Then
						Exit While
					End If
				End If
				System.Math.Max(System.Threading.Interlocked.Increment(intTextCount),intTextCount - 1)
			End While
			AldysPane.AxisChange()
			Invalidate()
		End Sub
		Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
			target = value
			Return value
		End Function


	End Class
End Namespace
