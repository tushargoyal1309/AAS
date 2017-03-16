using System;
using System.Drawing;
using System.Collections;

namespace AldysGraph
{
	/// <summary>
	/// A collection class containing a list of <see cref="TextItem"/> objects
	/// to be displayed on the graph.
	/// </summary>
	public class TextList : CollectionBase, ICloneable
	{
		/// <summary>
		/// Default constructor for the <see cref="TextList"/> collection class
		/// </summary>
		public TextList()
		{
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The TextList object from which to copy</param>
		public TextList( TextList rhs )
		{
			foreach ( TextItem item in rhs )
				this.Add( new TextItem( item ) );
		}

		/// <summary>
		/// Deep-copy clone routine
		/// </summary>
		/// <returns>A new, independent copy of the TextList</returns>
		public object Clone()
		{ 
			return new TextList( this ); 
		}
		
		/// <summary>
		/// Indexer to access the specified <see cref="TextItem"/> object by its ordinal
		/// position in the list.
		/// </summary>
		/// <param name="index">The ordinal position (zero-based) of the
		/// <see cref="TextItem"/> object to be accessed.</param>
		/// <value>A <see cref="TextItem"/> object reference.</value>
		public TextItem this[ int index ]  
		{
			get { return( (TextItem) List[index] ); }
			set { List[index] = value; }
		}

		/// <summary>
		/// Add a <see cref="TextItem"/> object to the <see cref="TextList"/>
		/// collection at the end of the list.
		/// </summary>
		/// <param name="item">A reference to the <see cref="TextItem"/> object to
		/// be added</param>
		public void Add( TextItem item )
		{
			List.Add( item );
		}

		/// <summary>
		/// Remove a <see cref="TextItem"/> object from the <see cref="TextList"/>
		/// collection at the specified ordinal location.
		/// </summary>
		/// <param name="index">An ordinal position in the list at which
		/// the object to be removed is located. </param>
		public void Remove( int index )
		{
			List.RemoveAt( index );
		}

		/// <summary>
		/// Render text to the specified <see cref="Graphics"/> device
		/// by calling the Draw method of each <see cref="TextItem"/> object in
		/// the collection.  This method is normally only called by the Draw method
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
		public void Draw( Graphics g, AldysPane pane, double scaleFactor )
		{
			foreach ( TextItem item in this )
			{
				//----- Added by Sachin Dokhale
				item.WidthX  = (float)(item.FontSpec.GetWidth(g, item.Text, scaleFactor)); // * ((float)item.Text.Length); 
				//item.HeightY  = (item.fontSpec.GetHeight);	//* (flot) text.Length ; 
				//item.WidthX  = (item.FontSpec.GetWidth(g, scaleFactor));	// * item.Text.Length); 
				//-----
				
				//The following condition is added by deepak b on 07.04.06
				if(item.X < pane.XAxis.Min || item.X> pane.XAxis.Max || item.Y< pane.YAxis.Min || item.Y> pane.YAxis.Max)
				{
					if (Convert.ToDouble(item.X) < (pane.XAxis.Min))
					{
						item.X = (float)pane.XAxis.Min;
					}

					if (Convert.ToDouble(item.X) > (pane.XAxis.Max))
					{
						item.X=(float)pane.XAxis.Max;
					}
					if (Convert.ToDouble(item.Y) < (pane.YAxis.Min))
					{
						item.Y = (float)pane.YAxis.Min;
					}

					if (Convert.ToDouble(item.Y) > (pane.YAxis.Max))
					{
						item.Y = (float)pane.YAxis.Max;
					}
					
					item.Draw( g, pane, scaleFactor );
				}
				else
				{
					//Added By Pankaj Bamb on 04 Sup 07
					if(item.X <= pane.XAxis.Min + item.Text.Length/2 )
					{
						item.AlignH =FontAlignH.Left ;
					}
					else if(item.X  >= pane.XAxis.Max - item.Text.Length/2 )
					{
						item.AlignH =FontAlignH.Right;
					}
					else					
					{
						item.AlignH =FontAlignH.Center;
					}
					//Ended by pankaj Bamb
					item.Draw( g, pane, scaleFactor );
				}
			}
				//item.Draw( g, pane, scaleFactor );
		}
	}

	/// <summary>
	/// A class that represents a text object on the graph.  A list of
	/// <see cref="TextItem"/> objects is maintained by the
	/// <see cref="TextList"/> collection class.
	/// </summary>
	public class TextItem : ICloneable
	{
		private string		text;
		private FontAlignV	alignV;
		private FontAlignH	alignH;

		private float		x,
							y;
		//----- Added by Sachin Dokhale on 3.09.07
		private float		widthx,
							heighty;
		//-----
		private CoordType	coordinateFrame;
		private FontSpecs	fontSpec;

		private bool blnForCurveLabel;
		private bool blnForHighPeakLabel;

		/// <overloads>
		/// Constructors for the <see cref="TextItem"/> class.
		/// </overloads>
		/// <summary>
		/// Default constructor that sets all <see cref="TextItem"/> properties to default
		/// values as defined in the <see cref="Def"/> class.
		/// </summary>
		public TextItem()
		{
			Init();
		}

		/// <summary>
		/// Initialization method that sets all <see cref="TextItem"/> properties to default
		/// values as defined in the <see cref="Def"/> class.
		/// </summary>
		protected void Init()
		{
			text = "Text";
			alignV = Defaults.Text.AlignV;
			alignH = Defaults.Text.AlignH;
			x = 0;
			y = 0;
			widthx = 0;
			heighty = 0;
	
			coordinateFrame = Defaults.Text.CoordFrame;

			this.fontSpec = new FontSpecs(
				Defaults.Text.FontFamily, Defaults.Text.FontSize,
				Defaults.Text.FontColor, Defaults.Text.FontBold,
				Defaults.Text.FontItalic, Defaults.Text.FontUnderline );
			
			//widthx  = (this.fontSpec.GetWidth( * (float) text.Length ); 
			//heighty  = (this.fontSpec.GetHeight);	//* (flot) text.Length ; 
			blnForCurveLabel=false;
			blnForHighPeakLabel=false;
		}

		/// <summary>
		/// Constructor that sets all <see cref="TextItem"/> properties to default
		/// values as defined in the <see cref="Def"/> class.
		/// </summary>
		/// <param name="text">T</param>
		/// <param name="x">The x position of the text.  The units
		/// of this position are specified by the
		/// <see cref="CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the <see cref="AlignH"/>
		/// property.</param>
		/// <param name="y">The y position of the text.  The units
		/// of this position are specified by the
		/// <see cref="CoordinateFrame"/> property.  The text will be
		/// aligned to this position based on the
		/// <see cref="AlignV"/> property.</param>
		public TextItem( string text, float x, float y )
		{
			Init();
			this.text = text;
			this.x = x;
			this.y = y;
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The TextItem object from which to copy</param>
		public TextItem( TextItem rhs )
		{
			text = rhs.Text;
			alignV = rhs.AlignV;
			alignH = rhs.AlignH;
			x = rhs.X;
			y = rhs.Y;
			widthx = rhs.widthx;
			heighty = rhs.heighty;

			blnForCurveLabel=rhs.blnForCurveLabel;
			blnForHighPeakLabel=rhs.blnForHighPeakLabel;
			coordinateFrame = rhs.CoordinateFrame;
			fontSpec = new FontSpecs( rhs.FontSpec );
			 
		}

		/// <summary>
		/// Deep-copy clone routine
		/// </summary>
		/// <returns>A new, independent copy of the TextItem</returns>
		public object Clone()
		{ 
			return new TextItem( this ); 
		}

		/// <summary>
		/// The <see cref="TextItem"/> to be displayed.  This text can be multi-line by
		/// including newline ('\n') characters between the lines.
		/// </summary>
		public string Text
		{
			get { return text; }
			set { 
				text = value;
				//----- Added by Sachin Dokhale on 03.09.07
				//this.WidthX  = (this.fontSpec.GetWidth( * (float) value.Length); 
				//-----
				}
		}
		/// <summary>
		/// Gets a reference to the <see cref="FontSpec"/> class used to render
		/// this <see cref="TextItem"/>
		/// </summary>
		public FontSpecs FontSpec
		{
			get { return fontSpec; }
		}
		/// <summary>
		/// A horizontal alignment parameter for this <see cref="TextItem"/> specified
		/// using the <see cref="FontAlignH"/> enum type
		/// </summary>
		public FontAlignH AlignH
		{
			get { return alignH; }
			set { alignH = value; }
		}
		/// <summary>
		/// A vertical alignment parameter for this <see cref="TextItem"/> specified
		/// using the <see cref="FontAlignV"/> enum type
		/// </summary>
		public FontAlignV AlignV
		{
			get { return alignV; }
			set { alignV = value; }
		}
		/// <summary>
		/// The x position of the <see cref="TextItem"/>.  The units of this position
		/// are specified by the <see cref="CoordinateFrame"/> property.
		/// The text will be aligned to this position based on the
		/// <see cref="AlignH"/> property.
		/// </summary>
		public float X
		{
			get { return x; }
			set { x = value; }
		}
		/// <summary>
		/// The x position of the <see cref="TextItem"/>.  The units of this position
		/// are specified by the <see cref="CoordinateFrame"/> property.
		/// The text will be aligned to this position based on the
		/// <see cref="AlignV"/> property.
		/// </summary>
		public float Y
		{
			get { return y; }
			set { y = value; }
		}

		
		public bool ForCurveLabel
		{
			get{ return blnForCurveLabel;}
			set{ blnForCurveLabel=value;}
		}

		public bool ForHighPeakLabel
		{
			get{ return blnForHighPeakLabel;}
			set{ blnForHighPeakLabel=value;}
		}

			/// <summary>
			/// The coordinate system to be used for defining the <see cref="TextItem"/> position
			/// </summary>
			/// <value> The coordinate system is defined with the <see cref="CoordType"/>
			/// enum</value>
			public CoordType CoordinateFrame
		{
			get { return coordinateFrame; }
			set { coordinateFrame = value; }
		}

		public float WidthX
		{
			get { return widthx; }
			set { widthx = value; }
		}

		public float HeightY
		{
			get { return heighty; }
			set { heighty = value; }
		}

		/// <summary>
		/// Render this <see cref="TextItem"/> object to the specified <see cref="Graphics"/> device
		/// This method is normally only called by the Draw method
		/// of the parent <see cref="TextList"/> collection object.
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
		public void Draw( Graphics g, AldysPane pane, double scaleFactor )
		{
			// transform the x,y location from the user-defined
			// coordinate frame to the screen pixel location
			PointF pix = pane.GeneralTransform( new PointF(this.x, this.y),
						this.coordinateFrame );
			
			// Draw the text on the screen, including any frame and background
			// fill elements
			if ((pix.X + this.WidthX)>= pane.paneRect.Width) 
			{
 				pix.X = pane.paneRect.Width - (this.WidthX + 5);
			}

			if ( pix.X > -10000 && pix.X < 100000 && pix.Y > -100000 && pix.Y < 100000 )
				this.FontSpec.Draw( g, this.text, pix.X, pix.Y,
								this.alignH, this.alignV, scaleFactor );
		}
	}
}
