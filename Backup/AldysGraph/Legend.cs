using System;
using System.Drawing;

namespace AldysGraph
{
	/// <summary>
	/// This class encapsulates the chart <see cref="Legend"/> that is displayed
	/// in the <see cref="AldysPane"/>
	/// </summary>
	public class Legend : ICloneable
	{
		private RectangleF rect;
		private LegendLoc location;
		private bool		isFramed;
		private bool		isFilled;
		private bool		isHStack;
		private bool		isVisible;
		private Color		fillColor;
		private Color		frameColor;
		private float		frameWidth;
		
		private FontSpecs	fontSpec;

		/// <summary>
		/// Default constructor that sets all <see cref="Legend"/> properties to default
		/// values as defined in the <see cref="Def"/> class.
		/// </summary>
		public Legend()
		{
			this.location = Defaults.Legend.Location;
			this.isFramed = Defaults.Legend.IsFramed;
			this.frameColor = Defaults.Legend.FrameColor;
			this.frameWidth = Defaults.Legend.FrameWidth;
			this.isFilled = Defaults.Legend.IsFilled;
			this.fillColor = Defaults.Legend.FillColor;
			this.isHStack = Defaults.Legend.HStack;
			this.isVisible = Defaults.Legend.IsVisible;
			
			this.fontSpec = new FontSpecs( Defaults.Legend.FontFamily, Defaults.Legend.FontSize,
									Defaults.Legend.FontColor, Defaults.Legend.FontBold,
									Defaults.Legend.FontItalic, Defaults.Legend.FontUnderline );						
			this.fontSpec.IsFilled = false;
			this.fontSpec.IsFramed = false;
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The XAxis object from which to copy</param>
		public Legend( Legend rhs )
		{
			rect = rhs.Rect;
			location = rhs.Location;
			isFramed = rhs.isFramed;
			isFilled = rhs.isFilled;
			isHStack = rhs.IsHStack;
			isVisible = rhs.IsVisible;
			fillColor = rhs.FillColor;
			frameColor = rhs.FrameColor;
			frameWidth = rhs.FrameWidth;
			
			fontSpec = new FontSpecs( rhs.FontSpec );
		}

		/// <summary>
		/// Deep-copy clone routine
		/// </summary>
		/// <returns>A new, independent copy of the Legend</returns>
		public object Clone()
		{ 
			return new Legend( this ); 
		}

		/// <summary>
		/// Get the bounding rectangle for the <see cref="Legend"/> in screen coordinates
		/// </summary>
		/// <value>A screen rectangle in pixel units</value>
		public RectangleF Rect
		{
			get { return rect; }
		}
		/// <summary>
		/// Access the <see cref="ZedGraph.FontSpec"/> class used to render
		/// the <see cref="Legend"/> entries
		/// </summary>
		/// <value>A reference to a <see cref="Legend"/> object</value>
		public FontSpecs FontSpec
		{
			get { return fontSpec; }
		}
		/// <summary>
		/// Gets or sets a property that shows or hides the <see cref="Legend"/> entirely
		/// </summary>
		/// <value> true to show the <see cref="Legend"/>, false to hide it </value>
		public bool IsVisible
		{
			get { return isVisible; }
			set { isVisible = value; }
		}
		/// <summary>
		/// Gets or sets a property that makes the <see cref="Legend"/> background
		/// either filled with a specified color (<see cref="FillColor"/>)
		/// or transparent
		/// </summary>
		/// <value> true to fill the <see cref="Legend"/> background with a color,
		/// false to leave the background transparent</value>
		public bool IsFilled
		{
			get { return isFilled; }
			set { isFilled = value; }
		}
		/// <summary>
		/// Set to true to display a frame around the text using the
		/// <see cref="FrameColor"/> color and <see cref="FrameWidth"/>
		/// pen width, or false for no frame
		/// </summary>
		public bool IsFramed
		{
			get { return isFramed; }
			set { isFramed = value; }
		}
		/// <summary>
		/// The pen width used for drawing the frame around the text
		/// </summary>
		/// <value>A pen width in pixel units</value>
		public float FrameWidth
		{
			get { return frameWidth; }
			set { frameWidth = value; }
		}
		/// <summary>
		/// Sets or gets the color of the frame around the <see cref="Legend"/>.  This
		/// frame is turned on or off using the <see cref="IsFramed"/>
		/// property and the pen width is specified with the
		/// <see cref="FrameWidth"/> property
		/// </summary>
		/// <value>A system <see cref="System.Drawing.Color"/> specification.</value>
		public Color FrameColor
		{
			get { return frameColor; }
			set { frameColor = value; }
		}
		/// <summary>
		/// Sets or gets the color of the background behind the <see cref="Legend"/>.
		/// This background fill option is turned on or off using the
		/// <see cref="IsFilled"/> property.
		/// </summary>
		/// <value>A system <see cref="System.Drawing.Color"/> specification.</value>
		public Color FillColor
		{
			get { return fillColor; }
			set { fillColor = value; }
		}
		/// <summary>
		/// Sets or gets a property that allows the <see cref="Legend"/> items to
		/// stack horizontally in addition to the vertical stacking
		/// </summary>
		/// <value>true to allow horizontal stacking, false otherwise
		/// </value>
		public bool IsHStack
		{
			get { return isHStack; }
			set { isHStack = value; }
		}
		/// <summary>
		/// Sets or gets the location of the <see cref="Legend"/> on the
		/// <see cref="AldysPane"/> using the <see cref="LegendLoc"/> enum type
		/// </summary>
		public LegendLoc Location
		{
			get { return location; }
			set { location = value; }
		}

		/// <summary>
		/// Render the <see cref="Legend"/> to the specified <see cref="Graphics"/> device
		/// This method is normally only called by the Draw method
		/// of the parent <see cref="AldysPane"/> object.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see cref="AldysPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see cref="AldysPane"/> object using the
		/// <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		/// <param name="hStack">The number of columns (horizontal stacking) to be used
		/// for drawing the legend</param>
		/// <param name="legendWidth">The width of each column in the legend</param>
		public void Draw( Graphics g, AldysPane pane, double scaleFactor,
							int hStack, float legendWidth )
		{
			// if the legend is not visible, do nothing
			if ( ! this.isVisible )
				return;
								
			// Fill the background with the specified color if required
			if ( this.isFilled )
			{
				SolidBrush brush = new SolidBrush( this.fillColor );
				g.FillRectangle( brush, this.rect );
			}
		
			// Set up some scaled dimensions for calculating sizes and locations
			float	charHeight = this.FontSpec.GetHeight( scaleFactor ),
					halfCharHeight = charHeight / 2.0F;
			float charWidth = this.FontSpec.GetWidth( g, scaleFactor );
			float gap = pane.ScaledGap( scaleFactor );

			int		iEntry = 0;
			float	x, y;
			
			// Get a brush for the legend label text
			SolidBrush brushB = new SolidBrush( Color.Black );
			
			// Loop for each curve in the CurveList collection
			foreach( CurveItem curve in pane.CurveList )
			{	
				// Calculate the x,y (TopLeft) location of the current
				// curve legend label
				// assuming:
				//  charHeight/2 for the left margin, plus legendWidth for each
				//    horizontal column
				//  charHeight is the line spacing, with no extra margin above
				if (curve.Label.ToString() != "" )  
				{
					x = this.rect.Left + halfCharHeight +
						( iEntry % hStack ) * legendWidth;
					y = this.rect.Top + (int)( iEntry / hStack ) * charHeight;
					// Draw the legend label for the current curve
					this.FontSpec.Draw( g, curve.Label, x + 2.5F * charHeight, y,
						FontAlignH.Left, FontAlignV.Top, scaleFactor );
					
					// Draw a sample curve to the left of the label text
					curve.Line.Draw( g, x, y + charHeight / 2,
						x + 2 * charHeight, y + halfCharHeight );
					// Draw a sample symbol to the left of the label text				
					curve.Symbol.Draw( g, x + charHeight, y + halfCharHeight,
						scaleFactor );
									
					// maintain a curve count for positioning
					iEntry++;
				}
			}
		
		
			// Draw a frame around the legend if required
			if ( iEntry > 0 && this.isFramed )
			{
				Pen pen = new Pen( this.frameColor, this.frameWidth );
				g.DrawRectangle( pen, Rectangle.Round( this.rect ) );
			}
		}

		/// <summary>
		/// Calculate the <see cref="Legend"/> rectangle (see cref="Rect"/>),
		/// taking into account the number of required legend
		/// entries, and the legend drawing preferences.  Adjust the size of the
		/// <see cref="AldysPane.AxisRect"/> for the parent <see cref="AldysPane"/> to accomodate the
		/// space required by the legend.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see cref="AldysPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see cref="AldysPane"/> object using the
		/// <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		/// <param name="axisRect">
		/// The rectangle that contains the area bounded by the axes, in pixel units.
		/// <seealso cref="AldysPane.AxisRect">AxisRect</seealso>
		/// </param>
		/// <param name="hStack">The number of columns (horizontal stacking) to be used
		/// for drawing the legend</param>
		/// <param name="legendWidth">The width of each column in the legend (pixels)</param>
		public void CalcRect( Graphics g, AldysPane pane, double scaleFactor,
								ref RectangleF axisRect, out int hStack,
								out float legendWidth )
		{
			// Start with an empty rectangle
			this.rect = Rectangle.Empty;
			hStack = 1;
			legendWidth = 1;
		
			// If the legend is invisible, don't do anything
			if ( !this.isVisible )
				return;
		
			int		nCurve = 0;
			float	charHeight = this.FontSpec.GetHeight( scaleFactor ),
					halfCharHeight = charHeight / 2.0F,
					charWidth = this.FontSpec.GetWidth( g, scaleFactor ),
					gap = pane.ScaledGap( scaleFactor ),
					maxWidth = 0,
					tmpWidth;
							
			// Loop through each curve in the curve list
			// Find the maximum width of the legend labels
			foreach( CurveItem curve in pane.CurveList )
			{
				// Calculate the width of the label save the max width
				if (curve.Label.ToString() == "" )  	continue;
				tmpWidth = this.FontSpec.GetWidth( g, curve.Label, scaleFactor );

				if ( tmpWidth > maxWidth )
					maxWidth = tmpWidth;
	
				nCurve++;
			}
		
			float widthAvail;
		
			// Is this legend horizontally stacked?
			if ( this.isHStack )
			{
				// Determine the available space for horizontal stacking
				switch( this.location )
				{
					// Never stack if the legend is to the right or left
					case LegendLoc.Right:
					case LegendLoc.Left:
						widthAvail = 0;
						break;
		
					// for the top & bottom, the axis frame width is available
					case LegendLoc.Top:
					case LegendLoc.Bottom:
						widthAvail = pane.AxisRect.Width;
						break;
		
					// for inside the axis area, use 1/2 of the axis frame width
					case LegendLoc.InsideTopRight:
					case LegendLoc.InsideTopLeft:
					case LegendLoc.InsideBotRight:
					case LegendLoc.InsideBotLeft:
						widthAvail = pane.AxisRect.Width / 2;
						break;
		
					// shouldn't ever happen
					default:
						widthAvail = 0;
						break;
				}
		
				// width of one legend entry
				legendWidth = 3 * charHeight + maxWidth;

				// Calculate the number of columns in the legend
				// Normally, the legend is:
				//     available width / ( max width of any entry + space for line&symbol )
				if ( maxWidth > 0 )
					hStack = (int) ( (widthAvail - halfCharHeight) / legendWidth );
		
				// You can never have more columns than legend entries
				if ( hStack > nCurve )
					hStack = nCurve;
		
				// a saftey check
				if ( hStack == 0 )
					hStack = 1;
			}
			else
				legendWidth = 3.5F * charHeight + maxWidth;
		
			// legend is:
			//   item:     space  line  space  text   space
			//   width:     wid  4*wid   wid  maxWid   wid 
			// The symbol is centered on the line
			//
			// legend begins 3 * wid to the right of the plot rect
			//
			// The height of the legend is the actual height of the lines of text
			//   (nCurve * hite) plus wid on top and wid on the bottom
		
			// total legend width
			float totLegWidth = hStack * legendWidth;	
		
			// The total legend height
			float legHeight = (float) Math.Ceiling( (double) nCurve / (double) hStack )
									* charHeight;
					
			// Now calculate the legend rect based on the above determined parameters
			// Also, adjust the plotArea and axisRect to reflect the space for the legend
			if ( nCurve > 0 )
			{
				// The switch statement assigns the left and top edges, and adjusts the axisRect
				// as required.  The right and bottom edges are calculated at the bottom of the switch.
				switch( this.location )
				{
					case LegendLoc.Right:
						this.rect.X = pane.PaneRect.Right - totLegWidth - gap;
						this.rect.Y = axisRect.Top;
		
						axisRect.Width -= totLegWidth + halfCharHeight;
						break;
					case LegendLoc.Top:
						this.rect.X = axisRect.Left;
						this.rect.Y = axisRect.Top;
						
						axisRect.Y += legHeight + halfCharHeight;
						axisRect.Height -= legHeight + halfCharHeight;
						break;
					case LegendLoc.Bottom:
						this.rect.X = axisRect.Left;
						this.rect.Y = pane.PaneRect.Bottom - legHeight - gap;
						
						axisRect.Height -= legHeight + halfCharHeight;
						break;
					case LegendLoc.Left:
						this.rect.X = pane.PaneRect.Left + gap;
						this.rect.Y = axisRect.Top;
						
						axisRect.X += totLegWidth + halfCharHeight;
						axisRect.Width -= totLegWidth + halfCharHeight;
						break;
					case LegendLoc.InsideTopRight:
						this.rect.X = axisRect.Right - totLegWidth;
						this.rect.Y = axisRect.Top;
						break;
					case LegendLoc.InsideTopLeft:
						this.rect.X = axisRect.Left;
						this.rect.Y = axisRect.Top;
						break;
					case LegendLoc.InsideBotRight:
						this.rect.X = axisRect.Right - totLegWidth;
						this.rect.Y = axisRect.Bottom - legHeight;
						break;
					case LegendLoc.InsideBotLeft:
						this.rect.X = axisRect.Left;
						this.rect.Y = axisRect.Bottom - legHeight;
						break;
				}
				
				// Calculate the Right and Bottom edges of the rect
				this.rect.Width = totLegWidth;
				this.rect.Height = legHeight;
			}
		}
	}
}

