using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace AldysGraph
{
	/// <summary>
	/// The Main Canvas for Drawing the Graph.
	/// </summary>
	public class AldysPane :ICloneable
	{
		
		#region Item subclasses

		private XAxis		xAxis;			// A class representing the X axis
		private YAxis		yAxis;  		// A class representing the Y axis
		private Legend		legend;			// A class for the graph legend
		private CurveList	curveList;		// A collection class for the curves on the graph
		private TextList	textList;		// A collection class for user text items on the graph
		private ArrowList	arrowList;		// A collection class for lines/arrows on the graph
		

		private FontSpecs	fontSpec;		// Describes the title font characteristics
		// Pane Title Properties
		private string		title;			// The main title of the graph
		private bool		isShowTitle;	// true to show the title
		// Pane Frame Properties
		private bool		isPaneFramed;	// True if the AldysPane has a frame border
		private Color		paneFrameColor;		// Color of the pane frame border
		private float		paneFramePenWidth;		// Width of the pane frame border
		private Color		paneBackColor;			// Color of the background behind paneRect

		private bool		isAxisFramed;	// True if the Axis has a frame border
		private Color		axisFrameColor;		// Color of the axis frame border
		private float		axisFramePenWidth;		// Width of the axis frame border
		private Color		axisBackColor;			// Color of the background behind axisRect
		
		private bool		isIgnoreInitial;	// true to ignore initial zero values for auto scale selection
		private float		paneGap;			// Size of the gap (margin) around the edges of the pane and axis
		private double		baseDimension;		// Basic length scale (inches) of the plot for scaling features
		private int			intCurveLabelSize;
		//private bool		xMidAxis;		// if XAxis in the middle of Axis Rect
		
		/// <summary>
		/// The rectangle that defines the full area into which the
		/// graph can be rendered.  Units are pixels.
		/// </summary>
		public RectangleF	paneRect;			// The full area of the graph pane
		/// <summary>
		/// The rectangle that contains the area bounded by the axes, in
		/// pixel units
		/// </summary>
		public RectangleF	axisRect;			// The area of the pane defined by the axes
		
		#endregion

		public bool statusflag;
		public IntPtr hwnd  = new IntPtr();

		public bool bPeakEdit;
		public Cursor cursor;
		
		public int peakCurveIndex;
		public ArrayList peakX;
		public ArrayList peakY;
		
		public bool bPeakInfo;
		public int peakInfoCurveIndex;
		public ArrayList peakInfoX;
		public ArrayList peakInfoY;
		
		public bool ShowCurveLabels;
		
		private AldysGraph objAldysGraphTmp;
		//private System.Windows.Forms.sy  ChangeAxis;  
	

		public void GetStatusEvent(CurveStatus cs)
		{			
			objAldysGraphTmp.GetStatusEventEx(cs);
		}

		public int CurveLabelSize
		{
			get { return intCurveLabelSize; }
			set { intCurveLabelSize = value; }
		}


		public void EnablePeakEdit(int CurveIndex,bool Flag)
		{
			if(Flag)
			{
				bPeakEdit = true;
				peakCurveIndex = CurveIndex;
				//Store all the pixels of courve in array
				this.peakX.Clear();
				this.peakY.Clear();
				this.CurveList[CurveIndex].InsertCurvePixels(this,peakX,peakY);				
			}
			else
			{
				this.peakX.Clear();
				this.peakY.Clear();
				bPeakEdit = false;
				peakCurveIndex = -1;
			}
		}

		public void EnableShowPeakInfo(int CurveIndex,bool Flag)
		{
			if(Flag)
			{
				bPeakInfo = true;
				peakInfoCurveIndex = CurveIndex;
				//Store all the pixels of courve in array
				this.peakInfoX.Clear();
				this.peakInfoY.Clear();
				this.CurveList[CurveIndex].InsertCurvePixels(this,peakInfoX,peakInfoY);				
			}
			else
			{
				this.peakInfoX.Clear();
				this.peakInfoY.Clear();
				bPeakInfo = false;
				peakInfoCurveIndex = -1;
			}
		}

		public AldysPane( RectangleF paneRect, string paneTitle,
			string xTitle, string yTitle ,AldysGraph objAld)
		{			
			statusflag = true;
			bPeakEdit = false;
			cursor = Cursors.NoMove2D;
			this.peakX = new ArrayList();
			this.peakY = new ArrayList();

			//Added By Mangesh S. on 25-Nov-2006
			peakInfoX = new ArrayList();
			peakInfoY = new ArrayList();
			//Added By Mangesh S. on 25-Nov-2006

			this.paneRect = paneRect;
			this.axisRect= axisRect;
			xAxis = new XAxis();
			yAxis = new YAxis();
			legend = new Legend();
			curveList = new CurveList();
			textList = new TextList();
			arrowList = new ArrowList();
			xAxis.Title = xTitle;
			yAxis.Title = xTitle;
			this.title = paneTitle;
			this.isShowTitle = Defaults.Pane.ShowTitle;
			this.fontSpec = new FontSpecs( Defaults.Pane.FontFamily,
				Defaults.Pane.FontSize, Defaults.Pane.FontColor, Defaults.Pane.FontBold,
				Defaults.Pane.FontItalic, Defaults.Pane.FontUnderline );
			this.fontSpec.IsFilled = false;
			this.fontSpec.IsFramed = false;
					
			this.isIgnoreInitial = Defaults.Axis.IgnoreInitial;
			
			this.isPaneFramed = Defaults.Pane.IsFramed;
			this.paneFrameColor = Defaults.Pane.FrameColor;
			this.paneFramePenWidth = Defaults.Pane.FramePenWidth;
			this.paneBackColor = Defaults.Pane.BackColor;

			this.isAxisFramed = Defaults.Axis.IsFramed;
			this.axisFrameColor = Defaults.Axis.FrameColor;
			this.axisFramePenWidth = Defaults.Axis.FramePenWidth;
			this.axisBackColor = Defaults.Axis.BackColor;

			this.baseDimension = Defaults.Pane.BaseDimension;
			this.paneGap = Defaults.Pane.Gap;
			this.objAldysGraphTmp = objAld;					
		}

//		public AldysPane()
//		{
//			//
//			// TODO: Add constructor logic here
//			//
//		}
		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The GraphPane object from which to copy</param>
		public AldysPane( AldysPane rhs )
		{
			statusflag = rhs.statusflag;
			bPeakEdit = rhs.bPeakEdit;
			cursor = Cursors.NoMove2D;
			this.peakX = rhs.peakX;
			this.peakY = rhs.peakY;

			//Added By Mangesh S. on 25-Nov-2006
			this.peakInfoX = rhs.peakInfoX;
			this.peakInfoY = rhs.peakInfoY;
			//Added By Mangesh S. on 25-Nov-2006

			paneRect = rhs.PaneRect;
			axisRect= rhs.AxisRect; 
			xAxis = new XAxis( rhs.XAxis );
			yAxis = new YAxis( rhs.YAxis );
			legend = new Legend( rhs.Legend);
			curveList = new CurveList( rhs.CurveList );
			textList = new TextList( rhs.TextList );
			arrowList = new ArrowList(rhs.ArrowList );
			
			this.title = rhs.Title;
			this.isShowTitle = rhs.IsShowTitle;
			this.fontSpec = new FontSpecs( rhs.fontSpec );
					
			this.isIgnoreInitial = rhs.IsIgnoreInitial;
			
			this.isPaneFramed = rhs.IsPaneFramed;
			this.paneFrameColor = rhs.PaneFrameColor;
			this.paneFramePenWidth = rhs.PaneFramePenWidth;
			this.paneBackColor = rhs.PaneBackColor;

			this.isAxisFramed = rhs.IsAxisFramed;
			this.axisFrameColor = rhs.AxisFrameColor;
			this.axisFramePenWidth = rhs.AxisFramePenWidth;
			this.axisBackColor = rhs.AxisBackColor;

			this.baseDimension = rhs.BaseDimension;
			this.paneGap = rhs.PaneGap;
			this.objAldysGraphTmp = rhs.objAldysGraphTmp;
			this.ShowCurveLabels = rhs.ShowCurveLabels; 
			
		} 

		#region ICloneable Members
		/// <summary>
		/// Deep-copy clone routine
		/// </summary>
		/// <returns>A new, independent copy of the AldysPane</returns>
		public object Clone()
		{
			// TODO:  Add AldysPane.Clone implementation
			return new AldysPane( this ); 
			//return null;
		}

		#endregion
	
		
		
		/// <summary>
		/// Gets or sets the rectangle that defines the full area into which the
		/// <see cref="AldysPane"/> can be rendered.
		/// </summary>
		/// <value>The rectangle units are in screen pixels</value>
		public RectangleF PaneRect
		{
			get { return paneRect; }
			set { paneRect = value; }
		}
		/// <summary>
		/// Gets a reference to the <see cref="FontSpec"/> class used to render
		/// the <see cref="GraphPane"/> <see cref="Title"/>
		/// </summary>
		public FontSpecs FontSpec
		{
			get { return fontSpec; }
		}

		/// <summary>
		/// Gets the rectangle that contains the area bounded by the axes
		/// (<see cref="XAxis"/>, <see cref="YAxis"/>, and <see cref="Y2Axis"/>)
		/// </summary>
		/// <value>The rectangle units are in screen pixels</value>
		public RectangleF AxisRect
		{
			get { return axisRect; }
			set { axisRect=value; }
		}

		/// <summary>
		/// A boolean value that affects the data range that is considered
		/// for the automatic scale ranging.  If true, then initial data points where the Y value
		/// is zero are not included when automatically determining the scale <see cref="Axis.Min"/>,
		/// <see cref="Axis.Max"/>, and <see cref="Axis.Step"/> size.
		/// All data after the first non-zero Y value are included.
		/// </summary>
		public bool IsIgnoreInitial
		{
			get { return isIgnoreInitial; }
			set { isIgnoreInitial = value; }
		}
		/// <summary>
		/// IsShowTitle is a boolean value that determines whether or not the pane title is displayed
		/// on the graph.  If true, the title is displayed.  If false, the title is omitted, and the
		/// screen space that would be occupied by the title is added to the axis area.
		/// </summary>
		public bool IsShowTitle
		{
			get { return isShowTitle; }
			set { isShowTitle = value; }
		}

		/// <summary>
		/// Title is a string representing the pane title text.  This text can be multiple lines,
		/// separated by newline characters ('\n').
		/// </summary>
		/// <seealso cref="FontSpec"/>
		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		/// <summary>
		/// IsShowPaneFrame is a boolean value that determines whether or not a frame border is drawn
		/// around the <see cref="AldysPane"/> area (<see cref="PaneRect"/>).
		/// True to draw the frame, false otherwise.
		/// </summary>
		public bool IsPaneFramed
		{
			get { return isPaneFramed; }
			set { isPaneFramed = value; }
		}
		/// <summary>
		/// Frame color is a <see cref="System.Drawing.Color"/> specification
		/// for the <see cref="AldysPane"/> frame border.
		/// </summary>
		public Color PaneFrameColor
		{
			get { return paneFrameColor; }
			set { paneFrameColor = value; }
		}
		/// <summary>
		/// Gets or sets the <see cref="System.Drawing.Color"/> specification
		/// for the <see cref="AldysPane"/> pane background, which is the
		/// area behind the <see cref="AldysPane.PaneRect"/>.
		/// </summary>
		public Color PaneBackColor
		{
			get { return paneBackColor; }
			set { paneBackColor = value; }
		}
		/// <summary>
		/// FrameWidth is a float value indicating the width (thickness) of the
		/// <see cref="AldysPane"/> frame border.
		/// </summary>
		public float PaneFramePenWidth
		{
			get { return paneFramePenWidth; }
			set { paneFramePenWidth = value; }
		}
		/// <summary>
		/// IsAxisFramed is a boolean value that determines whether or not a frame border is drawn
		/// around the axis area (<see cref="AxisRect"/>).
		/// </summary>
		/// <value>true to draw the frame, false otherwise. </value>
		public bool IsAxisFramed
		{
			get { return isAxisFramed; }
			set { isAxisFramed = value; }
		}
		/// <summary>
		/// Frame color is a <see cref="System.Drawing.Color"/> specification
		/// for the axis frame border.
		/// </summary>
		public Color AxisFrameColor
		{
			get { return axisFrameColor; }
			set { axisFrameColor = value; }
		}
		/// <summary>
		/// Gets or sets the <see cref="System.Drawing.Color"/> specification
		/// for the <see cref="Axis"/> background, which is the
		/// area behind the <see cref="AldysPane.AxisRect"/>.
		/// </summary>
		public Color AxisBackColor
		{
			get { return axisBackColor; }
			set { axisBackColor = value; }
		}
		/// <summary>
		/// FrameWidth is a float value indicating the width (thickness) of the axis frame border.
		/// </summary>
		/// <value>A pen width dimension in pixel units</value>
		public float AxisFramePenWidth
		{
			get { return axisFramePenWidth; }
			set { axisFramePenWidth = value; }
		}
		/// <summary>
		/// PaneGap is a float value that sets the margin area between the edge of the
		/// <see cref="AldysPane"/> rectangle (<see cref="PaneRect"/>)
		/// and the features of the graph.
		/// </summary>
		/// <value>This value is in units of pixels, and is scaled
		/// linearly with the graph size.</value>
		public float PaneGap
		{
			get { return paneGap   ; }
			set { paneGap = value; }
		}
		/// <summary>
		/// BaseDimension is a double precision value that sets "normal" plot size on
		/// which all the settings are based.  The BaseDimension is in inches.  For
		/// example, if the BaseDimension is 8.0 inches and the <see cref="AldysPane"/>
		/// <see cref="Title"/> size is 14 points.  Then the pane title font
		/// will be 14 points high when the <see cref="PaneRect"/> is approximately 8.0
		/// inches wide.  If the PaneRect is 4.0 inches wide, the pane title font will be
		/// 7 points high.  Most features of the graph are scaled in this manner.
		/// </summary>
		/// <value>The base dimension reference for the <see cref="AldysPane"/>, in inches</value>
		public double BaseDimension
		{
			get { return baseDimension; }
			set { baseDimension = value; }
		}
		
		/// <summary>
		/// ScaledGap is a simple utility routine that calculates the <see cref="PaneGap"/> scaled
		/// to the "scaleFactor" fraction.  That is, ScaledGap = PaneGap * scaleFactor
		/// </summary>
		/// <param name="scaleFactor">
		/// The scaling factor for the features of the graph based on the <see cref="BaseDimension"/>.  This
		/// scaling factor is calculated by the <see cref="CalcScaleFactor"/> method.  The scale factor
		/// represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		/// </param>
		/// <returns>Returns the paneGap size, in pixels, after scaling according to
		/// <paramref name="scalefactor"/></returns>
		public float ScaledGap( double scaleFactor )
		{
			return (float) ( this.paneGap * scaleFactor );
		}
		/// <summary>
		/// Draw all elements in the <see cref="AldysPane"/> to the specified graphics device.  This routine
		/// should be part of the Paint() update process.  Calling this routine will redraw all
		/// features of the graph.  No preparation is required other than an instantiated
		/// <see cref="AldysPane"/> object.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// 
		/// <summary>
		/// Accesses the <see cref="XAxis"/> for this graph
		/// </summary>
		/// <value>A reference to a <see cref="XAxis"/> object</value>
		public XAxis XAxis
		{
			get { return xAxis; }
		}

		public YAxis YAxis
		{
			get { return yAxis; }
		}

		/// <summary>
		/// Gets or sets the list of <see cref="TextItem"/> items for this <see cref="GraphPane"/>
		/// </summary>
		/// <value>A reference to a <see cref="TextList"/> collection object</value>
		public TextList TextList
		{
			get { return textList; }
			set { textList = value; }
		}

		/// <summary>
		/// Gets or sets the list of <see cref="ArrowItem"/> items for this <see cref="GraphPane"/>
		/// </summary>
		/// <value>A reference to an <see cref="ArrowList"/> collection object</value>
		public ArrowList ArrowList
		{
			get { return arrowList; }
			set { arrowList = value; }
		}

		/// <summary>
		/// Accesses the <see cref="Legend"/> for this <see cref="GraphPane"/>
		/// </summary>
		/// <value>A reference to a <see cref="Legend"/> object</value>
		public Legend Legend
		{
			get { return legend; }
		}
		/// <summary>
		/// Gets or sets the list of <see cref="CurveItem"/> items for this <see cref="AldysPane"/>
		/// </summary>
		/// <value>A reference to a <see cref="CurveList"/> collection object</value>
		public CurveList CurveList
		{
			get { return curveList; }
			set { curveList = value; }
		}
	
		public double  TmpScalefactor;
		
		public bool Draw( Graphics g )
		{
			try
			{		
				// calculate scaleFactor on "normal" pane size (BaseDimension)
				double scaleFactor = this.CalcScaleFactor( g );
				if(this.statusflag == false)
					scaleFactor += 0.5F; 
				
				TmpScalefactor = scaleFactor;

				// Calculate the axis rect, deducting the area for the scales, titles, legend, etc.
				int		hStack;
				float	legendWidth;

				this.CalcAxisRect( g, scaleFactor, out hStack, out legendWidth );

				// Frame the whole pane
				DrawPaneFrame( g );
				
				// Frame the axis itself
				DrawAxisFrame( g );

				DrawTitle( g, scaleFactor );
				
				if (this.xAxis.Min < this.xAxis.Max &&
					this.yAxis.Min < this.yAxis.Max 	)
				{
					// Clip everything to the paneRect
					g.SetClip( this.paneRect );
					// Draw the Axes
					this.xAxis.Draw( g, this, scaleFactor );
					this.yAxis.Draw( g, this, scaleFactor );
				
					// Clip the points to the actual plot area
					g.SetClip( this.axisRect );
					this.curveList.Draw( g, this, scaleFactor );
					g.SetClip( this.paneRect );

					// Draw the Legend
					this.legend.Draw( g, this, scaleFactor, hStack, legendWidth );
				
					// Draw the Text Items
					this.textList.Draw(g,this,scaleFactor);
				
					// Draw the Arrows
					this.arrowList.Draw( g, this, scaleFactor );
															
					// Reset the clipping
					g.ResetClip();
                  				
			}

			  return true;	
			}
			catch (IndexOutOfRangeException e)
			{
				string a;
				a=e.Message;
				//MessageBox.Show(e.Message);
				return false;
			}
			catch (Exception e)
			{
				string a;
				a=e.Message; 
				return false;				
				//MessageBox.Show(e.Message ); 
				//MessageBox.Show("Error occured while drawing");
			}
		}



		/// <summary>
		/// Calculate the <see cref="AxisRect"/> based on the <see cref="PaneRect"/>.  The axisRect
		/// is the plot area bounded by the axes, and the paneRect is the total area as
		/// specified by the client application.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor for the features of the graph based on the <see cref="BaseDimension"/>.  This
		/// scaling factor is calculated by the <see cref="CalcScaleFactor"/> method.  The scale factor
		/// represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		/// </param>
		/// <param name="hStack">
		/// The number of legend columns to use for horizontal legend stacking.  This is a temporary
		/// variable calculated by the routine for use in the Legend.Draw method.
		/// </param>
		/// <param name="legendWidth">
		/// The wide of a single legend entry, in pixel units.  This is a temporary
		/// variable calculated by the routine for use in the Legend.Draw method.
		/// </param>
		public void CalcAxisRect( Graphics g, double scaleFactor,
			out int hStack, out float legendWidth )
		{
			// get scaled values for the paneGap and character height
			float gap = 0.0F;
			//gap=this.ScaledGap( scaleFactor);
			gap=this.ScaledGap( scaleFactor +1);
		


			float charHeight = this.fontSpec.GetHeight(scaleFactor);
			hStack = 0;
			legendWidth = 0;
			
					

			// Axis rect starts out at the full pane rect.  It gets reduced to make room for the legend,
			// scales, titles, etc.
			this.axisRect = this.paneRect;

			// Calculate the areas required for the X, Y, and Y2 axes, and reduce the AxisRect by
			// these amounts.
			//			this.xAxis.CalcRect( g, this, scaleFactor );
			//			this.yAxis.CalcRect( g, this, scaleFactor );
			//			this.y2Axis.CalcRect( g, this, scaleFactor );

			float space = this.xAxis.CalcSpace( g, this, scaleFactor );
			this.axisRect.Height -= space;
			space = this.yAxis.CalcSpace( g, this, scaleFactor );
			this.axisRect.X += space;
			this.axisRect.Width -= space;
//////			space = this.y2Axis.CalcSpace( g, this, scaleFactor );
			this.axisRect.Width -= space;
//////	
			// Always leave a gap on top, even with no title
			this.axisRect.Y += gap;
			this.axisRect.Height -= gap;
//////
			// Leave room for the pane title
			if ( this.isShowTitle )
			{
				SizeF titleSize = this.fontSpec.MeasureString( g, this.title, scaleFactor );
				// Leave room for the title height, plus a line spacing of charHeight/2
				this.axisRect.Y += titleSize.Height + charHeight / 2.0F;
				this.axisRect.Height -= titleSize.Height + charHeight / 2.0F;
			}
			
//////			// Calculate the legend rect, and back it out of the current axisRect
			this.legend.CalcRect( g, this, scaleFactor, ref this.axisRect,
				out hStack, out legendWidth );
		}


		/// <summary>
		/// Calculate the scaling factor based on the ratio of the current <see cref="PaneRect"/> dimensions and
		/// the <see cref="BaseDimension"/>.  This scaling factor is used to proportionally scale the
		/// features of the <see cref="AldysPane"/> so that small graphs don't have huge fonts, and vice versa.
		/// The scale factor represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <returns>
		/// A double precision value representing the scaling factor to use for the rendering calculations.
		/// </returns>
		protected double CalcScaleFactor( Graphics g )
		{
			double scaleFactor;
			const double ASPECTLIMIT = 2.0;
				
			// Assume the standard width (BaseDimension) is 8.0 inches
			// Therefore, if the paneRect is 8.0 inches wide, then the fonts will be scaled at 1.0
			// if the paneRect is 4.0 inches wide, the fonts will be half-sized.
			// if the paneRect is 16.0 inches wide, the fonts will be double-sized.
			
			// determine the size of the paneRect in inches
			double xInch = (double) this.paneRect.Width / (double) g.DpiX;
			double yInch = (double) this.paneRect.Height / (double) g.DpiY;
						
			// Limit the aspect ratio so long plots don't have outrageous font sizes
			double aspect = (double) xInch / (double) yInch;
			if ( aspect > ASPECTLIMIT )
				xInch = yInch * ASPECTLIMIT;
			
			// Scale the size depending on the client area width in linear fashion
			scaleFactor = (double) xInch / this.baseDimension;
			
			// Don't let the scaleFactor get ridiculous
			if ( scaleFactor < 0.1 )
				scaleFactor = 0.1;
							
			return scaleFactor;
		}
		/// <summary>
		/// Draw the frame border around the <see cref="PaneRect"/> area.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		public void  DrawPaneFrame( Graphics g )
		{
			// Erase the pane background
			SolidBrush brush = new SolidBrush( this.paneBackColor );
			g.FillRectangle( brush, this.paneRect );

			RectangleF tempRect = this.paneRect;
			tempRect.Width -= 1;
			tempRect.Height -= 1;

			if ( this.isPaneFramed )
			{
				Pen pen = new Pen( this.paneFrameColor, this.paneFramePenWidth );
				g.DrawRectangle( pen, Rectangle.Round( tempRect ) );							
				
			}
		}
		/// <summary>
		/// Draw the frame border around the <see cref="AxisRect"/> area.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		public void DrawAxisFrame( Graphics g )
		{
			// Erase the axis background
			SolidBrush brush = new SolidBrush( this.axisBackColor );
			g.FillRectangle( brush, this.axisRect );

			if ( this.isAxisFramed )
			{
				Pen pen = new Pen( this.axisFrameColor, this.axisFramePenWidth );
				g.DrawRectangle( pen, Rectangle.Round( this.axisRect ) );
			}
		}

		/// <summary>
		/// Draw the <see cref="AldysPane"/> <see cref="Title"/> on the graph
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor for the features of the graph based on the <see cref="BaseDimension"/>.  This
		/// scaling factor is calculated by the <see cref="CalcScaleFactor"/> method.  The scale factor
		/// represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		/// </param>		
		/// 
		
		public void DrawTitle( Graphics g, double scaleFactor )
		{	
			// only draw the title if it's required
			
			if ( this.isShowTitle )
			{
				// use the internal fontSpec class to draw the text using user-specified and/or
				// default attributes.
				this.fontSpec.Draw( g, this.title,					( this.paneRect.Left + this.paneRect.Right ) / 2,
					this.paneRect.Top + this.ScaledGap( scaleFactor ),
					FontAlignH.Center, FontAlignV.Top, scaleFactor );
			}
		}

		/// <summary>
		/// Add a curve (<see cref="CurveItem"/> object) to the plot with
		/// the given data points and properties.
		/// This is simplified way to add curves without knowledge of the
		/// <see cref="CurveList"/> class.  An alternative is to use
		/// the <see cref="ZedGraph.CurveList.Add"/> method.
		/// </summary>
		/// <param name="label">The text label (string) for the curve that will be
		/// used as a <see cref="Legend"/> entry.</param>
		/// <param name="x">An array of double precision X values (the
		/// independent values) that define the curve.</param>
		/// <param name="y">An array of double precision Y values (the
		/// dependent values) that define the curve.</param>
		/// <param name="color">The color to used for the curve line,
		/// symbols, etc.</param>
		/// <param name="symbolType">A symbol type (<see cref="SymbolType"/>)
		/// that will be used for this curve.</param>
		/// <returns>A <see cref="CurveItem"/> class for the newly created curve.
		/// This can then be used to access all of the curve properties that
		/// are not defined as arguments to the <see cref="AddCurve"/> method.</returns>
		public CurveItem AddCurve( string label, ArrayList x, ArrayList y,
			Color color, SymbolType symbolType )
		{
			CurveItem curve = new CurveItem(label, x, y );
			curve.Line.Color = color;
			curve.Symbol.Color = color;
			curve.Symbol.Type = symbolType;
			this.curveList.Add( curve );
			
			return curve;
		}
		public CurveItem AddCurve( string label, ArrayList x, ArrayList y,
			Color color, SymbolType symbolType ,ArrayList cl,ArrayList sym)
		{
			CurveItem curve = new CurveItem( label, x,y,cl,sym );
			curve.Line.Color = color;
			curve.Symbol.Color = color;
			curve.Symbol.Type = symbolType;
			this.curveList.Add( curve );
			
			return curve;
		}
//		public CurveItem AddDigitalCurve( string label, double x,
//			Color color)
//		{
//			ArrayList x1 = new ArrayList();
//			ArrayList y1 = new ArrayList();
//			ArrayList cl1 = new ArrayList();
//			ArrayList sym1 = new ArrayList();
//			x1.Add(x);
//			y1.Add(this.YAxis.Min +(2*this.YAxis.MinorStep));
//			cl1.Add(color);
//			sym1.Add(SymbolType.NoSymbol);
//
//
//			CurveItem curve = new CurveItem( label,x1,y1 ,cl1,sym1 );
//			curve.AddPointFlg = true;
//			curve.Line.Color = color;
//			curve.Symbol.Color = color;
//			curve.Symbol.Type = SymbolType.NoSymbol;
//			this.curveList.Add( curve );
//			return curve;
//			
//
//		}
//		public void AddPointInDigitalCurve(int CurveIndex, double x, int Bit,
//			Color color )
//		{
//			
//			if(this.curveList[CurveIndex].AddPointFlg)
//			{
//				this.curveList[CurveIndex].X.Add(x);
//				if(Bit == 1)
//				{
//					this.curveList[CurveIndex].Y.Add(this.YAxis.Min +(4*this.YAxis.MinorStep));
//				}
//				else
//				{
//					this.curveList[CurveIndex].Y.Add(this.YAxis.Min +(2*this.YAxis.MinorStep));
//				}
//				
//				this.curveList[CurveIndex].CL.Add(color);
//				this.curveList[CurveIndex].SYM.Add(SymbolType.NoSymbol);
//				Graphics gr = Graphics.FromHwnd(this.hwnd);
//				gr.SetClip( this.axisRect );
//				this.curveList[CurveIndex].Draw(gr,this,TmpScalefactor );
//				gr.ResetClip();
//				gr.Dispose();
//			}		
//		}

		public CurveItem AddCurveWithPoint( string label, double x, double y,
			Color color, SymbolType symbolType )
		{

			ArrayList x1 = new ArrayList();
			ArrayList y1 = new ArrayList();
			ArrayList cl1 = new ArrayList();
			ArrayList sym1 = new ArrayList();
			x1.Add(x);
			y1.Add(y);
			cl1.Add(color);
			sym1.Add(symbolType);

			CurveItem curve = new CurveItem( label, x1, y1,cl1,sym1 );
			curve.AddPointFlg = true;
			curve.Line.Color = color;
			curve.Symbol.Color = color;
			curve.Symbol.Type = symbolType;
			this.curveList.Add( curve );
			
			return curve;
		}

		
		public void AddPointInCurve(int CurveIndex, string label, double x, double y,
			Color color, SymbolType symbolType )
		{
			if(this.curveList[CurveIndex].AddPointFlg)
			{
				this.curveList[CurveIndex].X.Add(x);
				this.curveList[CurveIndex].Y.Add(y);
				this.curveList[CurveIndex].CL.Add(color);
				this.curveList[CurveIndex].SYM.Add(symbolType);
				Graphics gr = Graphics.FromHwnd(this.hwnd);
				gr.SetClip( this.axisRect );

				this.curveList[CurveIndex].Draw(gr,this,TmpScalefactor );

				gr.ResetClip();
				gr.Dispose();
			}		
		}


		/// <summary>
		/// Transform a data point from the specified coordinate type
		/// (<see cref="CoordType"/>) to screen coordinates (pixels).
		/// </summary>
		/// <param name="ptF">The X,Y pair that defines the point in user
		/// coordinates.</param>
		/// <param name="coord">A <see cref="CoordType"/> type that defines the
		/// coordinate system in which the X,Y pair is defined.</param>
		/// <returns>A point in screen coordinates that corresponds to the
		/// specified user point.</returns>
		public PointF GeneralTransform( PointF ptF, CoordType coord )
		{
			PointF ptPix = new PointF();

			if ( coord == CoordType.AxisFraction )
			{
				ptPix.X = this.axisRect.Left + ptF.X * this.axisRect.Width;
				ptPix.Y = this.axisRect.Top + ptF.Y * this.axisRect.Height;
			}
			else if ( coord == CoordType.AxisXYScale )
			{
				ptPix.X = this.xAxis.Transform( ptF.X );
				ptPix.Y = this.yAxis.Transform( ptF.Y );
			}
			else if ( coord == CoordType.AxisXY2Scale )
			{
				ptPix.X = this.xAxis.Transform( ptF.X );
				//ptPix.Y = this.y2Axis.Transform( ptF.Y );
			}
			else	// PaneFraction
			{
				ptPix.X = this.paneRect.Left + ptF.X * this.paneRect.Width;
				ptPix.Y = this.paneRect.Top + ptF.Y * this.paneRect.Height;
			}

			return ptPix;
		}


		//Sachin Ashtankar 10 Oct 2005
		public void ReverseTransform( PointF ptF, out double x, out double y)
		{
			//Setup the scaling data based on the axis rect
			this.xAxis.SetupScaleData(this);
			this.yAxis.SetupScaleData(this);
  
			x=this.XAxis.TransformRev(ptF.X);
			y=this.YAxis.TransformRev(ptF.Y);   

		}
		/// <summary>
		/// AxisChange causes the axes scale ranges to be recalculated based on the current data range.
		/// Call this function anytime you change, add, or remove curve data.  This routine calculates
		/// a scale minimum, maximum, and step size for each axis based on the current curve data.
		/// Only the axis attributes (min, max, step) that are set to auto-range (<see cref="Axis.MinAuto"/>,
		/// <see cref="Axis.MaxAuto"/>, <see cref="Axis.StepAuto"/>) will be modified.  You must call
		/// Invalidate() after calling AxisChange to make sure the display gets updated.
		/// </summary>
		public void AxisChange()
		{
			double	xMin, xMax, yMin, yMax, y2Min, y2Max;
		
			// Get the scale range of the data (all curves)
			this.curveList.GetRange( out xMin, out xMax, out yMin,
				out yMax, out y2Min, out y2Max,
				this.isIgnoreInitial, this );
		
			// Pick new scales based on the range
			this.xAxis.PickScale( xMin, xMax );
			this.yAxis.PickScale( yMin, yMax );
			//this.y2Axis.PickScale( y2Min, y2Max );
			//ChangeAxis = new MouseEventArgs(e.Button,e.Clicks,e.X,e.Y, e.Delta );     
			
		}

		public void DrawCurveLabels()
		{
			int intCurveCount=0;
			string name;
			double x,y;
			
			if (ShowCurveLabels==false) 
				return;

			try
			{
				//double dblInterval=((this.XAxis.Max - this.XAxis.Min)/this.CurveList.Count -1);
				//after commenting the above line , following block of code is 
				//written by deepak b. on 01.04.06

				////////////----------
				int LastPointOnCurve;
				double XValueOfLastPointOnCurve,MinXValueOfLastPointOnCurve;
				MinXValueOfLastPointOnCurve=0.0;
				foreach( CurveItem curve in CurveList )
				{
					LastPointOnCurve= curve.X.Count - 1;
					XValueOfLastPointOnCurve=(double)curve.X[LastPointOnCurve];
					MinXValueOfLastPointOnCurve=XValueOfLastPointOnCurve;
					if(MinXValueOfLastPointOnCurve<=XValueOfLastPointOnCurve)
					{
						MinXValueOfLastPointOnCurve=XValueOfLastPointOnCurve;
					}
				}

				double dblInterval=((MinXValueOfLastPointOnCurve - this.XAxis.Min)/this.CurveList.Count );
				////////////----------

				double dblFrom, dblTo;
				dblFrom=this.XAxis.Min;
				dblTo=dblFrom + dblInterval;

				foreach( CurveItem curve in CurveList )
				{
					bool blnDrawn=false;
					curve.LabelX = curve.Label; 
					curve.Label += "(" + intCurveCount.ToString() + ")"; 
				
					name= intCurveCount.ToString();
					
					for(int intCount=0;intCount<=curve.X.Count -1;intCount++)
					{
						if ((double)curve.X[intCount] >= dblFrom && (double)curve.X[intCount] <= dblTo)
						{
							x=(double) curve.X[intCount];
							y=(double) curve.Y[intCount];

							TextItem text = new TextItem(name, (float)x,(float)y);
							text.CoordinateFrame = CoordType.AxisXYScale;
							text.AlignH = FontAlignH.Center;
							text.AlignV = FontAlignV.Bottom;
							if (CurveLabelSize != 0 )
							{
							text.FontSpec.Size = CurveLabelSize; 
							}
							text.ForCurveLabel =true;
							text.FontSpec.IsFramed=true;  
							text.FontSpec.FontColor = curve.Line.Color;   
							TextList.Add( text );

							intCurveCount+=1;
							dblFrom=dblTo;
							dblTo=dblFrom + dblInterval;

							blnDrawn=true;
							break;
						}
						blnDrawn=false;
					}
					if(blnDrawn==false)
					{
						//this if block is written by deepak b. on 01.04.06
						int LastPointBeforeEdge=0;
						for(int intCount=curve.X.Count -1;intCount>=0;intCount--)
						{
							if((double)curve.X[intCount]<this.XAxis.Min || (double)curve.X[intCount]>this.XAxis.Max || (double)curve.Y[intCount]<this.YAxis.Min || (double)curve.Y[intCount]>this.YAxis.Max)
							{
								//Do nothing
							}
							else
							{
								LastPointBeforeEdge=intCount;
								break;
							}
						}

						x=(double) curve.X[LastPointBeforeEdge];
						y=(double) curve.Y[LastPointBeforeEdge];

						TextItem text = new TextItem(name, (float)x,(float)y);
						text.CoordinateFrame = CoordType.AxisXYScale;
						text.AlignH = FontAlignH.Center;
						text.AlignV = FontAlignV.Bottom;
						text.ForCurveLabel =true;
						if (CurveLabelSize != 0 )
						{
							text.FontSpec.Size = CurveLabelSize; 
						}
						text.FontSpec.IsFramed=true;  
						text.FontSpec.FontColor = curve.Line.Color;   
						TextList.Add( text );

						intCurveCount+=1;					
						
					}
				}
			}
			catch
			{
			}
			finally
			{
			}
					
		}
		
	}
}
