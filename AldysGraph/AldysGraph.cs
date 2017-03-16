using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AldysGraph
{	
	/// <summary>
	/// Summary description for AldysGraph.
	/// </summary>
	/// 			
	public class AldysGraph : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// This private field contains the instance for the AldysPane object of this control.
		/// You can access the AldysPane object through the public property
		/// <see cref="AldysPane"/>.
		/// </summary>
		private AldysPane objAldysPane;
		
		private bool mouseDown = false;
		private bool mouseMoving = false;
		private bool haveRect = false;
		private int XDown;
		private int YDown;
		private int oldX,oldY;
		public bool Zoom;
		public bool ShowXYValues;
		private bool ShowPointInfo;

		private TrackBar  tBar;
		private PeakSymbol.PSymbol psymbol;
		private PeakSymbol.PSymbol pXYCord;
		public bool ShowXYPeak=false; 
		public Color pXYCordBackColor = Color.White;
		public Color pXYCordStringColor = Color.Black;
		public FontSpecs pXYFont;

		public Color trackBarColor;
		public Color peakLineColor;
		public int peakLineWidth;
		private  PeakEditArgs pHandler;
			
		private System.Windows.Forms.MouseEventArgs CustEvent;  

		public delegate void PeakEditHandler(object o, PeakEditArgs e);

		public delegate void CustPaneEvent(object sender, System.Windows.Forms.MouseEventArgs e);

		//public delegate void PointAddRemoveHandler(bool IsAddPoint, PointF pointInfo);
		//public event PointAddRemoveHandler AddRemovePoint;

		public event CustPaneEvent CustPaneMouseDown;

		public event PeakEditHandler peakEvent;

		public bool blnShowRainboBand=false;
		
		public delegate void AxisChangeEvent(); //object sender, System.Windows.Forms.MouseEventArgs e);
		
		public event AxisChangeEvent OnAxisChange;

		private RubberbandRectangle rect;
		public  GradientPanel.CustomPanel CustPan;
		private PrintDocument pd ;
		private Bitmap bitGraphBitmap;
		
		public delegate void SendCurveStatus(object o, CurveStatus e);

		public event SendCurveStatus StatusEvent;	

		private CurveItem HighPeakCurve;
		
		private Cursor mobjAldysGraphCursor = null;
		private bool bln_IsAvoideProcess;

		public delegate void PointAddRemoveHandler(bool IsAddPoint, Point pointInfo);
		public event PointAddRemoveHandler AddRemovePoint;

		private ToolTip pointToolTip;
		private Color mobjAldysGraphPrintColor = Color.Black ;

		[DllImport("GDI32.dll", CharSet=CharSet.Auto)]
		public static extern bool BitBlt( IntPtr hdcDest,int nXDest,int nYDest,int nWidth,int nHeight,IntPtr hdcSrc, int nXSrc, int nYSrc, Int32 dwRop);

		public void GetStatusEventEx(CurveStatus cs)
		{
			if(this.objAldysPane.statusflag)
			{
				CurveStatus cStatus = new CurveStatus(1);
				if (StatusEvent!=null)
					StatusEvent(this,cStatus );
			}
		}
		
		public Bitmap GraphImage
		{
			get{ return bitGraphBitmap;}
			set{ bitGraphBitmap= value;}
		}

		public Cursor AldysGraphCursor
		{
			get
			{
				return mobjAldysGraphCursor;
			}
			set
			{
				mobjAldysGraphCursor = value;
			}
		}

		public Color AldysGraphPrintColor 
		{
			get
			{
				return mobjAldysGraphPrintColor;
			}
			set
			{
				mobjAldysGraphPrintColor = value;
			}
		}


		public AldysGraph()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.MouseMove +=new MouseEventHandler(AldysGraph_MouseMove);
			this.MouseUp +=new MouseEventHandler(AldysGraph_MouseUp);
			this.MouseDown += new MouseEventHandler(AldysGraph_MouseDown);
			
			pd = new PrintDocument();
			pd.PrintPage +=new PrintPageEventHandler(pd_PrintPage);
			
			// TODO: Add any initialization after the InitComponent call
			Rectangle rect = new Rectangle( 0, 0, this.Size.Width, this.Size.Height );
			objAldysPane = new AldysPane( rect, "Aldys", "X-Axis", "Y-Axis",this );
			this.tBar = new TrackBar();
			this.psymbol  = new PeakSymbol.PSymbol();
			this.pXYCord =  new PeakSymbol.PSymbol();
			this.pXYFont = new FontSpecs("Arial",10,Color.Black,false,false,false); 
			this.trackBarColor = Color.PowderBlue;
			this.peakLineColor = Color.Violet;
			this.peakLineWidth = 1;
			this.Zoom = false;
			this.pointToolTip = new ToolTip(); 
		}
		/// <summary>
		/// Gets or sets the <see cref="AldysPane"/> property for the control
		/// </summary>
		public AldysPane AldysPane
		{
			get { return objAldysPane ; }
			set { objAldysPane = value; }
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CustPan = new GradientPanel.CustomPanel();
			this.SuspendLayout();
			// 
			// CustPan
			// 
			this.CustPan.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(225)), ((System.Byte)(250)));
			this.CustPan.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(175)), ((System.Byte)(200)), ((System.Byte)(245)));
			this.CustPan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CustPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CustPan.GradientMode = GradientPanel.LinearGradientMode.Vertical;
			this.CustPan.Location = new System.Drawing.Point(0, 0);
			this.CustPan.Name = "CustPan";
			this.CustPan.Size = new System.Drawing.Size(150, 150);
			this.CustPan.TabIndex = 0;
			this.CustPan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustPan_MouseUp);
			this.CustPan.Paint += new System.Windows.Forms.PaintEventHandler(this.CustPan_Paint);
			this.CustPan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustPan_MouseMove);
			this.CustPan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustPan_MouseDown);
			
			// 
			// AldysGraph
			// 
			this.BackColor = System.Drawing.Color.LightGray;
			this.Controls.Add(this.CustPan);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "AldysGraph";
			this.Resize += new System.EventHandler(this.ChangeSize);
			this.Load += new System.EventHandler(this.AldysGraph_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called by the system to update the control on-screen
		/// </summary>
		/// <param name="e">
		/// A PaintEventArgs object containing the Graphics specifications
		/// for this Paint event.
		/// </param>
	
		protected override void OnPaint( PaintEventArgs e )
		{
		}
	
		// Draws the RubberRectangle onto the client area using the
		// RubberbandRectangle class.
	
		private void RubberRectangle( int X1, int Y1, int X2, int Y2 )
		{
			System.Drawing.Graphics g = Graphics.FromHwnd( CustPan.Handle );
			
			rect = new RubberbandRectangle();
			rect.DrawXORRectangle( g, X1, Y1, X2, Y2 );	
		}
		
		public void EnablePeakTrace(int CurveIndex,bool Flag)
		{
			int intTotalTic, intTics;
			try
			{
				if(Flag)
				{
					this.objAldysPane.EnablePeakEdit(CurveIndex,Flag);

					CustPan.Controls.Add(tBar);  
					CustPan.Controls.Add(psymbol);

					//this.Controls.Add(tBar);
					//this.Controls.Add(psymbol);
					this.tBar.Scroll +=new EventHandler(tBar_Scroll);
					this.tBar.AutoSize = false; 
					this.tBar.Location = new System.Drawing.Point ((int)(this.objAldysPane.AxisRect.X-(12*this.objAldysPane.TmpScalefactor)),((int)(this.objAldysPane.PaneRect.Y/*-(50*this.objAldysPane.TmpScalefactor)*/)));
					//----- Added by Sachin Dokhale on 07.05.07
					//this.tBar.Size = (new Size((int)(this.objAldysPane.AxisRect.Width+(20*this.objAldysPane.TmpScalefactor)),(int)(10*this.objAldysPane.TmpScalefactor)));
					
					this.tBar.Size = (new Size((int)(this.objAldysPane.AxisRect.Width+(20*this.objAldysPane.TmpScalefactor)),(int)(45*this.objAldysPane.TmpScalefactor)));
					intTotalTic = (int)(this.objAldysPane.XAxis.Max -this.objAldysPane.XAxis.Min);
					intTics = (int)(intTotalTic  / objAldysPane.CurveList[CurveIndex].NPts);
					//-----

					this.tBar.Maximum = this.objAldysPane.peakX.Count-1;
					this.tBar.TickFrequency = 1;
					this.tBar.LargeChange = 10;
					this.tBar.SmallChange = 1;
					this.tBar.Visible = true;
					this.tBar.BackColor = this.trackBarColor;
					double x,y = 0;
					x = (((double)this.objAldysPane.peakX[0]));					
					y = (((double)this.objAldysPane.peakY[0]));							
					this.psymbol.Location = new System.Drawing.Point((int)x,(int)(y-(30*this.objAldysPane.TmpScalefactor))	);
					this.psymbol.Visible = true;
					this.psymbol.BackColor = this.peakLineColor;
					
					this.psymbol.Height = (int)(60*this.objAldysPane.TmpScalefactor);//(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height);
					this.psymbol.Width = this.peakLineWidth;
					pHandler = new PeakEditArgs(0,0);
					if (peakEvent!=null)
						peakEvent(this,pHandler);

					//this.tBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top ) 
					//	| System.Windows.Forms.AnchorStyles.Left) 
					//	| System.Windows.Forms.AnchorStyles.Right)));
					//this.tBar. = 0;

					if (ShowXYPeak==true )
					{
						//this.Controls.Add(pXYCord);
						CustPan.Controls.Add(pXYCord);  
						if (objAldysPane.XAxis.IsVisible==false)
							this.pXYCord.Location = new System.Drawing.Point( (int) (objAldysPane.AxisRect.Right /2 -( 50*this.objAldysPane.TmpScalefactor))  ,(int)((objAldysPane.AxisRect.Bottom)-(18*this.objAldysPane.TmpScalefactor))	);
						else
							//----- Added by Sachin Dokhale on 07.05.07
							//this.pXYCord.Location = new System.Drawing.Point( (int) (objAldysPane.AxisRect.Right /2 -( 50*this.objAldysPane.TmpScalefactor))  ,(int)((objAldysPane.AxisRect.Bottom)+(20*this.objAldysPane.TmpScalefactor))	);
							this.pXYCord.Location = new System.Drawing.Point((int) (objAldysPane.AxisRect.Right /2 -( 50*this.objAldysPane.TmpScalefactor))  ,(int)((objAldysPane.AxisRect.Bottom)+(30*this.objAldysPane.TmpScalefactor))	);
							//------												
						this.pXYCord.Visible = true;
						this.pXYCord.BackColor = this.pXYCordBackColor;
						//----- Added by Sachin Dokhale on 07.05.07
						//this.pXYCord.Height = (int)(50*this.objAldysPane.TmpScalefactor);//(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height);
						this.pXYCord.Height = (int)(35*this.objAldysPane.TmpScalefactor);//(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height);
						//-----
						this.pXYCord.Width = (int)(160*this.objAldysPane.TmpScalefactor);//(PointToScreen(new Point(0,(int)y))).Y;//(this.objAldysPane.axisRect.Height); //this.peakLineWidth;
					}
				}
				else
				{
					this.tBar.Visible = false;
					this.psymbol.Visible = false;
					this.pXYCord.Visible =false; 
					CustPan.Controls.Remove(tBar);
					CustPan.Controls.Remove(psymbol);
					CustPan.Controls.Remove(pXYCord);  
				
					this.objAldysPane.EnablePeakEdit(CurveIndex,false);					
				}
			}
			catch (IndexOutOfRangeException e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void AldysGraph_Load(object sender, System.EventArgs e)
		{
					
		}
			
		private void ChangeSize(object sender, System.EventArgs e)
		{
			this.objAldysPane.paneRect = new RectangleF(0, 0, this.Size.Width, this.Size.Height );
			this.Invalidate();
			if(this.objAldysPane.bPeakEdit)
			{
				this.EnablePeakTrace(this.objAldysPane.peakCurveIndex,false);
			}
		}
		
		private void AldysGraph_MouseMove(object sender, MouseEventArgs e)
		{
			//			if(!Zoom) return;
			//			if(this.objAldysPane.axisRect.Contains(e.X,e.Y))
			//			{
			//				if( mouseDown )
			//				{
			//				
			//					if( mouseMoving )
			//						RubberRectangle( XDown, YDown, oldX, oldY );
			//					RubberRectangle( XDown, YDown, e.X, e.Y );
			//					mouseMoving = true;
			//					oldX = e.X;
			//					oldY = e.Y;
			//				}
			//			}
		}
		
		private void AldysGraph_MouseUp(object sender, MouseEventArgs e)
		{
			//			if(!Zoom) return;
			//			try
			//			{
			//			
			//				if(e.Button == MouseButtons.Left && mouseMoving == true)
			//				{
			//					//very bad
			//					//if(this.objAldysPane.XAxis.Type == AxisType.Date) return;
			//					this.EnablePeakTrace(this.objAldysPane.peakCurveIndex,false);
			//					if(this.objAldysPane.XAxis.Type == AxisType.Linear)
			//					{
			//						if(XDown < oldX)
			//						{
			//							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(XDown));
			//							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(oldX));
			//							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(oldY));
			//							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(YDown));
			//						}
			//						else if(XDown > oldX)
			//						{
			//							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(oldX));
			//							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(XDown));
			//							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(YDown));
			//							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(oldY));
			//						}
			//					}
			//					else if(this.objAldysPane.XAxis.Type == AxisType.Date)
			//					{
			//						bool tmpFlag = false;
			//						if(XDown < oldX)
			//						{						
			//							
			//							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
			//							{
			//								if(!tmpFlag)
			//								{
			//									double db = this.objAldysPane.XAxis.TransformRev(XDown);
			//									double db1 = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
			//									if((this.objAldysPane.XAxis.TransformRev(XDown))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			//									{
			//										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
			//										tmpFlag = true;
			//									}
			//								}
			//								if(tmpFlag)
			//								{
			//									if((this.objAldysPane.XAxis.TransformRev(oldX))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			//									{
			//										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
			//										break;
			//									}
			//								}
			//							}
			//							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
			//							{
			//								if(!tmpFlag)
			//								{
			//									if((this.objAldysPane.YAxis.TransformRev(oldY))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			//									{
			//										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
			//										tmpFlag = true;
			//									}
			//								}
			//								if(tmpFlag)
			//								{
			//									if((this.objAldysPane.YAxis.TransformRev(YDown))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			//									{
			//										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
			//										break;
			//									}
			//								}
			//							}
			//
			//
			//
			//						}
			//						else if(XDown > oldX)
			//						{
			//							
			//
			//							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
			//							{
			//								if(!tmpFlag)
			//								{
			//									if((this.objAldysPane.XAxis.TransformRev(oldX))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			//									{
			//										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
			//										tmpFlag = true;
			//									}
			//								}
			//								if(tmpFlag)
			//								{
			//									if((this.objAldysPane.XAxis.TransformRev(XDown))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
			//									{
			//										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
			//										break;
			//									}
			//								}
			//							}
			//							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
			//							{
			//								if(!tmpFlag)
			//								{
			//									if((this.objAldysPane.YAxis.TransformRev(YDown))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			//									{
			//										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
			//										tmpFlag = true;
			//									}
			//								}
			//								if(tmpFlag)
			//								{
			//									if((this.objAldysPane.YAxis.TransformRev(oldY))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
			//									{
			//										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
			//										break;
			//									}
			//								}
			//							}
			//						}
			//					}
			//
			//					//Find the points 
			//					for(int icount = 0;icount < this.objAldysPane.CurveList.Count;icount++)
			//					{
			//						int arrcount = 0;					
			//						ArrayList arrXd = new ArrayList();
			//						ArrayList arrYd = new ArrayList();										
			//						arrcount = this.objAldysPane.CurveList[icount].X.Count;
			//						for(int pcount = 0;pcount < arrcount;pcount++)
			//						{
			//							if(this.objAldysPane.XAxis.Type == AxisType.Linear)
			//							{
			//								if(((int)((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&((int)((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
			//								{						
			//									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
			//									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
			//								}
			//
			//							}
			//							else if(this.objAldysPane.XAxis.Type == AxisType.Date)
			//							{
			//								if((((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&(((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
			//								{						
			//									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
			//									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
			//								}
			//
			//							}
			//													
			//						}
			//						this.objAldysPane.CurveList[icount].X = arrXd;
			//						this.objAldysPane.CurveList[icount].Y = arrYd;
			//					}
			//				
			//					//take all the points in the rect. get the point which are in the rect
			//
			//					this.objAldysPane.AxisChange();
			//					this.Invalidate();
			//					//this.objAldysPane.Draw(Graphics.FromHwnd(this.Handle));
			//					mouseDown = false;
			//					mouseMoving = false;
			//					haveRect = true;	// Clear the flag
			//					//Invalidate();		// Clear out the rectangle.
			//				}
			//			}
			//			catch(IndexOutOfRangeException err)
			//			{
			//				MessageBox.Show(err.Message);
			//			}
			//			mouseDown = false;
			//			mouseMoving = false;
			//			haveRect = true;	
		}
		
		private void AldysGraph_MouseDown(object sender, MouseEventArgs e)
		{
			//			if(!Zoom) return;
			//			if( e.Button == MouseButtons.Left )
			//			{
			//				mouseDown = true;
			//				XDown = e.X;
			//				YDown = e.Y;
			//				mouseMoving = false;
			//			}
			//			else if( e.Button == MouseButtons.Right )
			//			{
			//				if( haveRect )
			//				{
			//					haveRect = false;	// Clear the flag
			//					Invalidate();		// Clear out the rectangle.
			//				}
			//			}
		}
		
		private void tBar_Scroll(object sender, EventArgs e)
		{
			try
			{	
				if(this.objAldysPane.bPeakEdit)
				{	
					StringFormat strFormat = new StringFormat();
					
					SolidBrush brush = new SolidBrush( this.pXYCordStringColor);
					//SolidBrush brush = new SolidBrush(Color.Blue); 

					double x,y,xpeak,ypeak;	
					
					x = y = 0;
					x = (((double)this.objAldysPane.peakX[this.tBar.Value ]));					
					y = (((double)this.objAldysPane.peakY[this.tBar.Value]));	
					
					this.psymbol.Location = new System.Drawing.Point((int)x,(int)(y-(30*this.objAldysPane.TmpScalefactor))	);
					//this.pHandler.X = x;
					//this.pHandler.Y = y;
					pHandler = new PeakEditArgs((double)(this.objAldysPane.CurveList[this.objAldysPane.peakCurveIndex].X[this.tBar.Value ]),(double)(this.objAldysPane.CurveList[this.objAldysPane.peakCurveIndex].Y[this.tBar.Value ]));
					if (peakEvent!=null)
						peakEvent(this,pHandler);
								
					Graphics g = Graphics.FromHwnd(pXYCord.Handle);
					String strDummy;
					xpeak = ((double)(this.objAldysPane.CurveList[this.objAldysPane.peakCurveIndex].X[this.tBar.Value]));
					xpeak = Math.Round(xpeak,4);

					ypeak = ((double)(this.objAldysPane.CurveList[this.objAldysPane.peakCurveIndex].Y[this.tBar.Value]));
					ypeak = Math.Round(ypeak,4);
					//strDummy = "X: "+ xpeak.ToString() + "\nY: "+ ypeak.ToString();
					strDummy = "\nX: "+ xpeak.ToString() + ", Y: "+ ypeak.ToString();
					pXYCord.Refresh();

					///28.04.08
					Font ff=new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

					if (objAldysPane.XAxis.IsVisible==false)
						g.DrawString(strDummy,pXYFont.GetFont(this.objAldysPane.TmpScalefactor+0.1),brush,0.0F, 0.0F, strFormat);  
					else
					    g.DrawString(strDummy, ff,new SolidBrush(Color.DarkBlue ),0.0F, 0.0F, strFormat);  ///28.04.08
				}
				else
				{
					
				}
			}
			catch (IndexOutOfRangeException err)
			{
				MessageBox.Show(err.Message);
			}
		}
		
		public bool PrintGraph()
		{
			ArrayList printRes=new ArrayList();
			PrinterResolution pkResolution;
			for (int i = 0; i < pd.PrinterSettings.PrinterResolutions.Count; i++)
			{
				pkResolution = pd.PrinterSettings.PrinterResolutions[i];
				printRes.Add(pkResolution);
				//MessageBox.Show(pkResolution.ToString());  
			}
			//System.Drawing.Printing.PrintEventArgs p =  new System.Drawing.Printing.PrintEventArgs();
			Margins margins = new Margins(20,00,00,150);
			pd.DefaultPageSettings.Margins = margins;
			//pd.DefaultPageSettings.PrinterResolution = (PrinterResolution)printRes[6]; 
			//pd.DefaultPageSettings.Landscape = true; 
				 
			pd.Print(); 
			//PrintPreviewDialog dlg = new PrintPreviewDialog(); 
			//dlg.Document = pd; 
			//dlg.ShowDialog();
			return true;					
		}
		
		public bool PrintPreViewGraph()
		{
			ArrayList printRes=new ArrayList();
			PrinterResolution pkResolution;
			for (int i = 0; i < pd.PrinterSettings.PrinterResolutions.Count; i++)
			{
				pkResolution = pd.PrinterSettings.PrinterResolutions[i];
				printRes.Add(pkResolution);
				//MessageBox.Show(pkResolution.ToString());  
			}

			//System.Drawing.Printing.PrintEventArgs p =  new System.Drawing.Printing.PrintEventArgs();
			Margins margins = new Margins(20,00,00,150);
			pd.DefaultPageSettings.Margins = margins;
			//pd.DefaultPageSettings.PrinterResolution = (PrinterResolution)printRes[6]; 
			//pd.DefaultPageSettings.Landscape = true; 
							 
			//pd.Print(); 
			PrintPreviewDialog dlg = new PrintPreviewDialog(); 
			dlg.Document = pd; 
			dlg.ShowDialog();
			return true;			
		}
		
		private void pd_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics g =  e.Graphics;
			//AldysPane obj =(AldysPane)this.objAldysPane.Clone();
			//AldysPane obj  = (AldysPane)this.AldysPane.CurveList[1].X[1] =   
			AldysPane obj =(AldysPane)this.AldysPane.Clone();

			obj.statusflag = false;
			Rectangle rect = new Rectangle( 60, 60, 500, 500 );
			obj.paneRect = rect;	
			obj.Draw( g );
		}
		
		public bool DrawGraphOnGraphics(Graphics g, int leftpos, int toppos, int width, int height)
		{
			AldysPane obj =(AldysPane)this.objAldysPane.Clone();
			obj.statusflag = false;
			Rectangle rect = new Rectangle(leftpos,toppos,width,height);
			obj.paneRect = rect;	
			obj.IsShowTitle = true;
			//obj.Legend.IsVisible =true;
			obj.Legend.FontSpec.FontColor  = Color.Black;
			obj.Legend.FrameColor = Color.Black; 
			obj.FontSpec.FontColor  =Color.Black;
			obj.XAxis.IsShowGrid =true;
			obj.XAxis.Color = this.AldysGraphPrintColor;
			obj.YAxis.IsShowGrid =true;
			obj.IsPaneFramed =true;
			obj.PaneFrameColor=Color.Black;  
			obj.Draw(g);
			return true;
		}
		
		public void GetImageOfGraph()
		{
			AldysPane obj =(AldysPane)this.objAldysPane.Clone();
			obj.statusflag = false;
			Graphics g=this.CreateGraphics();  
			g.Clear(Color.White);  
			obj.IsShowTitle = true;
			//obj.Legend.IsVisible =true;
			obj.Legend.FontSpec.FontColor  = Color.Black;
			obj.Legend.FrameColor = Color.Black; 
			obj.FontSpec.FontColor  =Color.Black;
			obj.XAxis.IsShowGrid =true;
			obj.YAxis.IsShowGrid =true;
			obj.IsPaneFramed =true;
			obj.PaneFrameColor=Color.Black;  
			
			Bitmap srcBmp= new Bitmap((int)obj.paneRect.Width,(int)obj.paneRect.Bottom ,g);
			//srcBmp.Save (Application.StartupPath +  "/Graph.bmp");

			Graphics srcMem;
			srcMem=Graphics.FromImage(srcBmp);  
        
			IntPtr HDC1 = g.GetHdc();
			IntPtr HDC2 = srcMem.GetHdc();
			//Get the picture
			BitBlt(HDC2,0,0,(int)obj.paneRect.Width,(int) obj.paneRect.Height,HDC1,(int)obj.paneRect.X , (int)obj.paneRect.Y,13369376);
											
			bitGraphBitmap=(Bitmap) srcBmp.Clone();
 		   	g.ReleaseHdc(HDC1);
			srcMem.ReleaseHdc(HDC2); 
			g.Dispose();
			srcMem.Dispose(); 			
		}
	
		public void GetImage()
		{

		}			
			
		private void pict_Paint(Object s , PaintEventArgs e)
		{	
			AldysPane obj =(AldysPane)this.objAldysPane.Clone();
			obj.statusflag = false;
			obj.Draw(e.Graphics);
			//pict.Image.Save(Application.StartupPath + "/GPH.BMP");   
		}
			
		private void CustPan_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint( e );	
			//objAldysPane.hwnd = CustPan.Handle; 
			this.objAldysPane.Draw( e.Graphics );
			
			objAldysPane.hwnd = this.Handle;
						
			this.objAldysPane.CurveList.isResizing = true;
		
			if (blnShowRainboBand) 
				if(OnAxisChange!=null)
					OnAxisChange();
		}

		//			private void CustPan_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		//			{
		//			if(!Zoom) return;
		//			try
		//			{
		//			
		//				 
		//				if(e.Button == MouseButtons.Left && mouseMoving == true)
		//				{
		//					//very bad
		//					//if(this.objAldysPane.XAxis.Type == AxisType.Date) return;
		//					this.EnablePeakTrace(this.objAldysPane.peakCurveIndex,false);
		//					if(this.objAldysPane.XAxis.Type == AxisType.Linear)
		//					{
		//						if(XDown < oldX)
		//						{
		//							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(XDown));
		//							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(oldX));
		//							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(oldY));
		//							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(YDown));
		//						}
		//						else if(XDown > oldX)
		//						{
		//							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(oldX));
		//							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(XDown));
		//							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(YDown));
		//							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(oldY));
		//						}
		//					}
		//					else if(this.objAldysPane.XAxis.Type == AxisType.Date)
		//					{
		//						bool tmpFlag = false;
		//						if(XDown < oldX)
		//						{						
		//							
		//							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
		//							{
		//								if(!tmpFlag)
		//								{
		//									double db = this.objAldysPane.XAxis.TransformRev(XDown);
		//									double db1 = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
		//									if((this.objAldysPane.XAxis.TransformRev(XDown))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		//									{
		//										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
		//										tmpFlag = true;
		//									}
		//								}
		//								if(tmpFlag)
		//								{
		//									if((this.objAldysPane.XAxis.TransformRev(oldX))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		//									{
		//										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
		//										break;
		//									}
		//								}
		//							}
		//							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
		//							{
		//								if(!tmpFlag)
		//								{
		//									if((this.objAldysPane.YAxis.TransformRev(oldY))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		//									{
		//										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
		//										tmpFlag = true;
		//									}
		//								}
		//								if(tmpFlag)
		//								{
		//									if((this.objAldysPane.YAxis.TransformRev(YDown))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		//									{
		//										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
		//										break;
		//									}
		//								}
		//							}
		//
		//
		//
		//						}
		//						else if(XDown > oldX)
		//						{
		//							
		//
		//							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
		//							{
		//								if(!tmpFlag)
		//								{
		//									if((this.objAldysPane.XAxis.TransformRev(oldX))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		//									{
		//										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
		//										tmpFlag = true;
		//									}
		//								}
		//								if(tmpFlag)
		//								{
		//									if((this.objAldysPane.XAxis.TransformRev(XDown))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
		//									{
		//										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
		//										break;
		//									}
		//								}
		//							}
		//							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
		//							{
		//								if(!tmpFlag)
		//								{
		//									if((this.objAldysPane.YAxis.TransformRev(YDown))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		//									{
		//										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
		//										tmpFlag = true;
		//									}
		//								}
		//								if(tmpFlag)
		//								{
		//									if((this.objAldysPane.YAxis.TransformRev(oldY))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
		//									{
		//										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
		//										break;
		//									}
		//								}
		//							}
		//						}
		//					}
		//
		//					//Find the points 
		//					for(int icount = 0;icount < this.objAldysPane.CurveList.Count;icount++)
		//					{
		//						int arrcount = 0;					
		//						ArrayList arrXd = new ArrayList();
		//						ArrayList arrYd = new ArrayList();										
		//						arrcount = this.objAldysPane.CurveList[icount].X.Count;
		//						for(int pcount = 0;pcount < arrcount;pcount++)
		//						{
		//							if(this.objAldysPane.XAxis.Type == AxisType.Linear)
		//							{
		//								if(((int)((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&((int)((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
		//								{						
		//									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
		//									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
		//								}
		//
		//							}
		//							else if(this.objAldysPane.XAxis.Type == AxisType.Date)
		//							{
		//								if((((double)this.objAldysPane.CurveList[icount].X[pcount])>= this.objAldysPane.XAxis.Min )&&(((double)this.objAldysPane.CurveList[icount].X[pcount])<= this.objAldysPane.XAxis.Max  ) ) 
		//								{						
		//									arrXd.Add((double)this.objAldysPane.CurveList[icount].X[pcount]);
		//									arrYd.Add((double)this.objAldysPane.CurveList[icount].Y[pcount]);
		//								}
		//
		//							}
		//													
		//						}
		//						this.objAldysPane.CurveList[icount].X = arrXd;
		//						this.objAldysPane.CurveList[icount].Y = arrYd;
		//					}
		//				
		//					//take all the points in the rect. get the point which are in the rect
		//
		//					this.objAldysPane.XAxis.StepAuto =true;
		//					this.objAldysPane.XAxis.MinorStepAuto  =true;
		//
		//					this.objAldysPane.YAxis.StepAuto =true;
		//					this.objAldysPane.YAxis.MinorStepAuto  =true;
		//
		//					this.objAldysPane.AxisChange();
		//					this.Invalidate();
		//					//this.objAldysPane.Draw(Graphics.FromHwnd(this.Handle));
		//					mouseDown = false;
		//					mouseMoving = false;
		//					haveRect = true;	// Clear the flag
		//					//Invalidate();		// Clear out the rectangle.
		//				}
		//			}
		//			catch(IndexOutOfRangeException err)
		//			{
		//				MessageBox.Show(err.Message);
		//			}
		//			mouseDown = false;
		//			mouseMoving = false;
		//			haveRect = true;
		//		}
		private void CustPan_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!Zoom) return;
			try
			{
				if(e.Button == MouseButtons.Left && mouseMoving == true)
				{
					//very bad
					//if(this.objAldysPane.XAxis.Type == AxisType.Date) return;
					this.EnablePeakTrace(this.objAldysPane.peakCurveIndex,false);

					if(this.objAldysPane.XAxis.Type == AxisType.Linear)
					{
						if(XDown < oldX)
						{
							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(XDown));
							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(oldX));
							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(oldY));
							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(YDown));
						}
						else if(XDown > oldX)
						{
							this.objAldysPane.XAxis.Min = Math.Floor(this.objAldysPane.XAxis.TransformRev(oldX));
							this.objAldysPane.XAxis.Max = Math.Ceiling(this.objAldysPane.XAxis.TransformRev(XDown));
							this.objAldysPane.YAxis.Min = Math.Floor(this.objAldysPane.YAxis.TransformRev(YDown));
							this.objAldysPane.YAxis.Max = Math.Ceiling(this.objAldysPane.YAxis.TransformRev(oldY));
						}
					}
					else if(this.objAldysPane.XAxis.Type == AxisType.Date)
					{
						bool tmpFlag = false;
						if(XDown < oldX)
						{						
							
							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
							{
								if(!tmpFlag)
								{
									double db = this.objAldysPane.XAxis.TransformRev(XDown);
									double db1 = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
									if((this.objAldysPane.XAxis.TransformRev(XDown))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
									{
										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
										tmpFlag = true;
									}
								}
								if(tmpFlag)
								{
									if((this.objAldysPane.XAxis.TransformRev(oldX))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
									{
										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
										break;
									}
								}
							}
							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
							{
								if(!tmpFlag)
								{
									if((this.objAldysPane.YAxis.TransformRev(oldY))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
									{
										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
										tmpFlag = true;
									}
								}
								if(tmpFlag)
								{
									if((this.objAldysPane.YAxis.TransformRev(YDown))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
									{
										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
										break;
									}
								}
							}
						}
						else if(XDown > oldX)
						{
							for(int ncount = 0;ncount < this.objAldysPane.XAxis.xArrSteps.Count;ncount++)
							{
								if(!tmpFlag)
								{
									if((this.objAldysPane.XAxis.TransformRev(oldX))< (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
									{
										this.objAldysPane.XAxis.Min = (double)(this.objAldysPane.XAxis.xArrSteps[ncount-1]);
										tmpFlag = true;
									}
								}
								if(tmpFlag)
								{
									if((this.objAldysPane.XAxis.TransformRev(XDown))<= (double)(this.objAldysPane.XAxis.xArrSteps[ncount]))
									{
										this.objAldysPane.XAxis.Max = (double)(this.objAldysPane.XAxis.xArrSteps[ncount]);
										break;
									}
								}
							}
							for(int nycount = 0;nycount < this.objAldysPane.YAxis.yArrSteps.Count;nycount++)
							{
								if(!tmpFlag)
								{
									if((this.objAldysPane.YAxis.TransformRev(YDown))< (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
									{
										this.objAldysPane.YAxis.Min = (double)(this.objAldysPane.YAxis.yArrSteps[nycount-1]);
										tmpFlag = true;
									}
								}
								if(tmpFlag)
								{
									if((this.objAldysPane.YAxis.TransformRev(oldY))<= (double)(this.objAldysPane.YAxis.yArrSteps[nycount]))
									{
										this.objAldysPane.YAxis.Max = (double)(this.objAldysPane.YAxis.yArrSteps[nycount]);
										break;
									}
								}
							}
						}
					}

						
					//						double x1, x2, y1, y2;
					//						PointF endPoint=new PointF(oldX ,oldY);
					//						PointF startPoint=((Control)sender).PointToClient(new Point(XDown,YDown));
					//
					//						this.AldysPane.ReverseTransform(startPoint, out x1,out y1);
					//						this.AldysPane.ReverseTransform(endPoint, out x2, out y2);  
					//						
					//						x1=this.AldysPane.XAxis.TransformRev(XDown);
					//						x2=this.AldysPane.XAxis.TransformRev(oldX);
					//						y1=this.AldysPane.YAxis.TransformRev(oldY);
					//						y2=this.AldysPane.YAxis.TransformRev(YDown);
					//
					//						this.AldysPane.XAxis.Min = Math.Min(x1,x2);
					//						this.AldysPane.XAxis.Max = Math.Max(x1,x2);
					//						this.AldysPane.YAxis.Min = Math.Min(y1,y2);
					//						this.AldysPane.YAxis.Max = Math.Max(y1,y2);
						
					//take all the points in the rect. get the point which are in the rect

					this.objAldysPane.XAxis.StepAuto =true;
					this.objAldysPane.XAxis.MinorStepAuto  =true;

					this.objAldysPane.YAxis.StepAuto =true;
					this.objAldysPane.YAxis.MinorStepAuto  =true;

					this.objAldysPane.AxisChange();
					this.Invalidate();
					//this.objAldysPane.Draw(Graphics.FromHwnd(this.Handle));
					mouseDown = false;
					mouseMoving = false;
					haveRect = true;	// Clear the flag
					//Invalidate();		// Clear out the rectangle.
				}
			}
			catch(IndexOutOfRangeException err)
			{
				MessageBox.Show(err.Message);
			}
			mouseDown = false;
			mouseMoving = false;
			haveRect = true;
		}

		public  void CustPan_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			if (bln_IsAvoideProcess==true)
				return;

			bln_IsAvoideProcess=true;

			CustEvent = new MouseEventArgs(e.Button,e.Clicks,e.X,e.Y, e.Delta );     
			if(CustPaneMouseDown!=null)
				CustPaneMouseDown(sender,CustEvent );

			if (Zoom) 
			{
				double x,y;
				this.objAldysPane.ReverseTransform(new PointF(e.X,e.Y),out x,out y);   

				if(x < this.objAldysPane.XAxis.Min || x > this.objAldysPane.XAxis.Max 
					|| y < this.objAldysPane.YAxis.Min || y > this.objAldysPane.YAxis.Max)
				{
					bln_IsAvoideProcess=false; 
					return;
				}
	
				switch (e.Button)
				{
					case MouseButtons.Left:
						mouseDown = true;
						XDown = e.X;
						YDown = e.Y;
						mouseMoving = false;
						break;
					case MouseButtons.Right:
						if( haveRect )
						{
							haveRect = false;	// Clear the flag
							Invalidate();		// Clear out the rectangle.
						}
						break;
				}
			}//--End of Zoom If

			
			if (ShowPointInfo && !Zoom) 
			{
				//---Added By Mangesh S. on 25-Nov-2006
				//---Display a small window showing the Point Information.
				double x ,y, xpeak, ypeak, x1, y1;
				int i, peakInfoCurveIndex, x2, y2;
				bool blnIsAddPoint;				
				int pointIndex = 0;
				
				Point objAldysPoint = null; 
				//objAldysPoint= (Point)this.objAldysPane.CurveList[peakInfoCurveIndex].ScatteredPoints[0]
					
				//PointInfo.frmPointInfo objfrmPointInfo;
				//objfrmPointInfo.AddRemovePoint  += new PointInfo.PointAddRemoveHandler();
				this.objAldysPane.ReverseTransform(new PointF(e.X,e.Y),out x,out y);   

				if(x < this.objAldysPane.XAxis.Min || x > this.objAldysPane.XAxis.Max 
					|| y < this.objAldysPane.YAxis.Min || y > this.objAldysPane.YAxis.Max)
				{
					bln_IsAvoideProcess=false; 
					return;
				}
				
				xpeak = ypeak = x1= y1 = 0.0;
				blnIsAddPoint = false;
				peakInfoCurveIndex = this.objAldysPane.peakInfoCurveIndex;		

				for (i=0; i<this.objAldysPane.CurveList[peakInfoCurveIndex].X.Count; i++)
				{
					x1 = (double)objAldysPane.CurveList[peakInfoCurveIndex].X[i];
					if (x1 >=x-0.5 && x1 <= x+0.5)
					{
						xpeak = x1;
						pointIndex = i;
						break;
					}
				}
				for (i=0; i<this.objAldysPane.CurveList[peakInfoCurveIndex].X.Count; i++)
				{
					y1 = (double)objAldysPane.CurveList[peakInfoCurveIndex].Y[i];
					if (y1 >=y-0.5 && y1 <= y+0.5)
					{
						ypeak = y1;
						//pointIndex = i;						
						break;
					}
				}
				
				if (xpeak == 0.0 || ypeak == 0.0)
				{
					for (i=0; i < objAldysPane.CurveList[peakInfoCurveIndex].ScatteredPoints.Count; i++)
					{
						objAldysPoint = (Point)objAldysPane.CurveList[peakInfoCurveIndex].ScatteredPoints[i];
						PointF objPoint = this.objAldysPane.GeneralTransform(new PointF(objAldysPoint.X , objAldysPoint.Y), CoordType.AxisXYScale); 
						
						if (objPoint.X >=e.X-5 && objPoint.X <= e.X+5)	
						{
							if (objPoint.Y >=e.Y-5 && objPoint.Y <= e.Y+5)	
							{
								xpeak = (double)objAldysPoint.X; 
								ypeak = (double)objAldysPoint.Y;
								//blnIsAddPoint=true; 
								blnIsAddPoint = objAldysPoint.IsAddedInCurve;
								pointIndex = objAldysPoint.PointNumber;
								break;
							}							
						}
					} 
				}
				
				xpeak = Math.Round(xpeak,4);
				ypeak = Math.Round(ypeak,4);

				switch (e.Button)
				{
					case MouseButtons.Left :
						if (xpeak > 0.0 && ypeak > 0.0)
						{
							if (objAldysPoint != null)
							{
								x2 = this.Location.X + e.X + 4;
								y2 = this.Location.Y + e.Y + 20;

								if (this.Parent != null)
								{
									x2 = x2 + this.Parent.Location.X;
									y2 = y2 + this.Parent.Location.Y;
								}
								if (this.Parent.Parent != null)
								{
									x2 = x2 + this.Parent.Parent.Location.X; 
									y2 = y2 + this.Parent.Parent.Location.Y;
								}
								if (this.Parent.Parent.Parent != null)
								{
									x2 = x2 + this.Parent.Parent.Parent.Location.X; 
									y2 = y2 + this.Parent.Parent.Parent.Location.Y;
								}
								
								PointInfo.frmPointInfo objfrmPointInfo;
								objfrmPointInfo=null;
								objfrmPointInfo = new PointInfo.frmPointInfo (objAldysPoint, new System.Drawing.PointF(x2, y2), blnIsAddPoint);
								Application.DoEvents();
								objfrmPointInfo.AddRemovePoint += new PointInfo.PointAddRemoveHandler(objfrmPointInfo_AddRemovePoint);
								//objfrmPointInfo.ShowBalloon(this.Parent);
								objfrmPointInfo.ShowDialog (this.Parent);
								Application.DoEvents();
								objfrmPointInfo.Close();
								objfrmPointInfo.Dispose();
 								//objfrmPointInfo.ShowDialog(this.Parent);
								//objfrmPointInfo.BringToFront();
								//objfrmPointInfo.Activate();   
								//objfrmPointInfo.Focus();  
								//objfrmPointInfo.TopMost=true; 
								Application.DoEvents();
							}
						}
						break;
					
					case MouseButtons.Right :
						break;
				}
			}
			bln_IsAvoideProcess=false;
		}
				
		private void CustPan_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(Zoom==true)
			{
				if(this.objAldysPane.axisRect.Contains(e.X,e.Y))
				{
					if( mouseDown )
					{					
						if( mouseMoving )
							RubberRectangle( XDown, YDown, oldX, oldY );
						RubberRectangle( XDown, YDown, e.X, e.Y );
						mouseMoving = true;
						oldX = e.X;
						oldY = e.Y;
					}
				}
			}
			//--End Zoom If
	
			if(ShowXYValues==true)
			{
				double x,y;
				this.objAldysPane.ReverseTransform(new PointF(e.X,e.Y),out x,out y);
				
				string toolTip="[X:" + Math.Round(x,4).ToString() + ",Y:" + Math.Round(y,4).ToString() +"]";
					
				//modified by deepak b. on 28.01.06 to set the limit for tooltip.
				if(x<this.objAldysPane.XAxis.Min || x>this.objAldysPane.XAxis.Max || y<this.objAldysPane.YAxis.Min || y>this.objAldysPane.YAxis.Max)
				{
					this.pointToolTip.Active =false;
				}
				else
				{
					this.pointToolTip.SetToolTip(this.CustPan ,toolTip);
					this.pointToolTip.Active=true;
				}				
				//					
			}
			else
			{
				this.pointToolTip.Active=false;
			}
			//--End ShowXYValues If		

			if (ShowPointInfo && !Zoom) 
			{
				//---Added By Mangesh S. on 21-Feb-2007
				//---To change the Mouse Cursor over AldysPane
				double x ,y;

				this.objAldysPane.ReverseTransform(new PointF(e.X,e.Y),out x,out y);   

				if(x < this.objAldysPane.XAxis.Min || x > this.objAldysPane.XAxis.Max 
					|| y < this.objAldysPane.YAxis.Min || y > this.objAldysPane.YAxis.Max)
					return;
							
				if (this.mobjAldysGraphCursor != null )
					Cursor.Current = this.mobjAldysGraphCursor;
				return;				 												
			}
			//--End Show PointInfo If
		}
			
		public void EnableShowPointInfo(int CurveIndex,bool Flag)
		{
			try
			{
				if(Flag)
				{
					this.objAldysPane.EnableShowPeakInfo(CurveIndex,true);
					this.ShowPointInfo = true;
				}
				else
				{
					this.ShowPointInfo = false;
					this.objAldysPane.EnableShowPeakInfo(CurveIndex,false);
				}
			}
			catch (IndexOutOfRangeException e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public void objfrmPointInfo_AddRemovePoint(bool IsAddPoint, Point pointInfo)
		{		
			int peakInfoCurveIndex = this.objAldysPane.peakInfoCurveIndex;
			int ptIndex = -1;
			Point ptPointInfo = null;
			

			//---Enable the Selected Point from the Selected CurveItem in CurveList.
			if (IsAddPoint)
			{		
				int i;	
				for (i=0; i<objAldysPane.CurveList.Count;i++)
					if (objAldysPane.CurveList[i].IsScatteredPointsCurve)
					{
						ptIndex = objAldysPane.CurveList[i].ScatteredPoints.IndexOf(pointInfo);
						if (ptIndex > -1 ) break;
					}

				if (ptIndex > -1 )
				{
					ptPointInfo = (Point)objAldysPane.CurveList[i].ScatteredPoints[ptIndex];
					((Point)objAldysPane.CurveList[i].ScatteredPoints[ptIndex]).IsAddedInCurve = false;
					((Point)objAldysPane.CurveList[i].ScatteredPoints[ptIndex]).PointColor = Color.Red;
				}				
			}
			else
			{
				//---Enable the Selected Point from the Selected CurveItem in CurveList.
				int i;				
				for (i=0; i<objAldysPane.CurveList.Count;i++)
					if (objAldysPane.CurveList[i].IsScatteredPointsCurve)
					{
						ptIndex = objAldysPane.CurveList[i].ScatteredPoints.IndexOf( pointInfo);
						if (ptIndex > -1 ) break;
					}

				if (ptIndex > -1 )
				{
					ptPointInfo = (Point)objAldysPane.CurveList[i].ScatteredPoints[ptIndex];
					((Point)objAldysPane.CurveList[i].ScatteredPoints[ptIndex]).IsAddedInCurve = true;
					((Point)objAldysPane.CurveList[i].ScatteredPoints[ptIndex]).PointColor = Color.Black;
				}								
			}
			objAldysPane.AxisChange();
			Invalidate();
			if (ptIndex>-1)
			{
				if (IsAddPoint)
				{
					//btnRemove.Text = "Enable";
					if (AddRemovePoint != null)
						AddRemovePoint(true, ptPointInfo);
				}
				else
				{
					//btnRemove.Text ="Disable";
					if (AddRemovePoint != null)
						AddRemovePoint(false, ptPointInfo);
				}
			}
		}
			
		public void DrawHighestPeakLine(CurveItem PeakCurve)
		{
			double dblMaxYValue, dblXValue, dblYValue;
			dblMaxYValue = dblXValue = dblYValue = 0.0;

			foreach( CurveItem curve in this.AldysPane.CurveList)
			{
				if (curve.IsHighPeakLine)
					return;	//High Peak Line Already exists in the CurveList.
			}

			for (int i=0; i < PeakCurve.X.Count; i++)
			{				
				dblYValue = (double)PeakCurve.Y[i];
				if (dblYValue > dblMaxYValue)
				{
					dblMaxYValue = dblYValue;
					dblXValue = (double)PeakCurve.X[i];
				}
			}
			
			ArrayList arrX = new ArrayList();
			ArrayList arrY = new ArrayList();

			arrX.Add (0.0);
			arrY.Add (0.0);
				
			HighPeakCurve = AldysPane.AddCurve("Peak Height",arrX,arrY,Color.Blue,SymbolType.NoSymbol);
			HighPeakCurve.IsHighPeakLine = true;
			HighPeakCurve.HighPeakXValue = dblXValue;
			HighPeakCurve.HighPeakYValue = dblMaxYValue;
			HighPeakCurve.Symbol.IsFilled = true;
			HighPeakCurve.AddPointFlg = true;
			HighPeakCurve.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;
			AldysPane.CurveList.isResizing = true;
			AldysPane.IsIgnoreInitial = true;
			
			AldysPane.AxisChange();
			Invalidate();

			HighPeakCurve.X.Add (dblXValue);
			HighPeakCurve.Y.Add (dblMaxYValue);

			HighPeakCurve.X.Add (dblXValue);
			HighPeakCurve.Y.Add (0.0);
				
			AldysPane.AxisChange();
			Invalidate(); 
		}
		
		public void ShowHighPeakLineLabel(string strHighPeakLabel, bool blnIsShowYValue, int FontSpecSize)
		{			
			string name="";
			double x,y;
			CurveItem ShowedHighPeakCurve;
			CurveItem HighPeakCurve = null;

			foreach( CurveItem curve in this.AldysPane.CurveList)
			{
				if (curve.IsHighPeakLine)
				{
					HighPeakCurve = curve;
				}
				else
				{
					ShowedHighPeakCurve = curve;
				}
			}
			if (HighPeakCurve == null )
				return;	//No High Peak Line exists in the CurveList.

			x = HighPeakCurve.HighPeakXValue;
			y = HighPeakCurve.HighPeakYValue;
			//y = y + 1.5; 
			
			
			if (strHighPeakLabel == null)
				strHighPeakLabel = "Max Y-Value ";
								
			//following blank space is added by deepak on 06.03.07
			
			//Show the label vertically offset to actual point by a unit pixel.
			
		
				if (blnIsShowYValue)
					name = strHighPeakLabel + " = " + y.ToString() + "    ";	
				else
					name = strHighPeakLabel + " = " + x.ToString() + "    ";	

			//TextItem text = new TextItem(name, x, y);			
			
			/*if (ShowedHighPeakCurve != null)
			{ */
//				if ((AldysPane.YAxis.Max - (double)AldysPane.YAxis.MajorUnit) >= y) 
//					{	if (FontSpecSize == 0) 
//							y = AldysPane.YAxis.Max-((double)objAldysPane.TmpScalefactor*10);                       
//						else 
//							y = AldysPane.YAxis.Max-((double)objAldysPane.TmpScalefactor*10);
//							
//
//					}
			//}
			if (AldysPane.CurveLabelSize != 0 )
			{
				//text.FontSpec.Size = AldysPane.CurveLabelSize; 
			}
		
			TextItem text = new TextItem(name, (float)x, (float)y );
			text.CoordinateFrame = CoordType.AxisXYScale;
			
			text.AlignH = FontAlignH.Center;
			text.AlignV = FontAlignV.Bottom;

			if (FontSpecSize == 0) 
				text.FontSpec.Size = 17.0F;
			else
				text.FontSpec.Size  = (float)FontSpecSize;
					
			text.ForHighPeakLabel = true;
			text.FontSpec.IsFramed = true;  
			text.FontSpec.FontColor = HighPeakCurve.Line.Color;   
			AldysPane.TextList.Add( text );	

			AldysPane.AxisChange();
            Invalidate();
		}

		public void RemoveHighPeakLineLabel()
		{			
			foreach( CurveItem curve in this.AldysPane.CurveList)
			{
				if (curve.IsHighPeakLine)
				{					
					if (curve.LabelX != null)
						curve.Label = curve.LabelX;
				}
			}
			if (HighPeakCurve == null )
				return;	//No High Peak Line exists in the CurveList.

			for (int intTextCount = 0; intTextCount < AldysPane.TextList.Count; intTextCount++ )
			{	
				if (AldysPane.TextList[intTextCount].ForHighPeakLabel == true ) 
				{
					AldysPane.TextList.Remove(intTextCount);
					intTextCount -= 1;
					if (AldysPane.TextList.Count == 0) 
						break;
				}
			}
			AldysPane.AxisChange();
			Invalidate();
		}

		
	}
}
