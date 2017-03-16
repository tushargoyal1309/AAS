using System;
using System.Drawing;
using System.Collections;

namespace AldysGraph
{
	
	/// <summary>
	/// This class contains the data and methods for an individual curve within
	/// a graph pane.  It carries the settings for the curve including the
	/// key and item names, colors, symbols and sizes, linetypes, etc.
	/// </summary>
	public class CurveItem : ICloneable
	{
		/// <summary>
		/// Private field that stores a reference to the <see cref="AldysGraph.Symbol"/>
		/// class defined for this <see cref="CurveItem"/>.  Use the public
		/// property <see cref="Symbol"/> to access this value.
		/// </summary>
		private Symbol		symbol;

		/// <summary>
		/// Private field that stores a reference to the <see cref="AldysGraph.Line"/>
		/// class defined for this <see cref="CurveItem"/>.  Use the public
		/// property <see cref="Line"/> to access this value.
		/// </summary>
		private Line		line;
		
		/// <summary>
		/// Private field that stores a legend label string for this
		/// <see cref="CurveItem"/>.  Use the public
		/// property <see cref="Label"/> to access this value.
		/// </summary>		
		private string		label;

		/// <summary>
		/// Private field that stores the boolean value that determines whether this
		/// <see cref="CurveItem"/> is on the left Y axis or the right Y axis (Y2).
		/// Use the public property <see cref="IsY2Axis"/> to access this value.
		/// </summary>
		private bool		isY2Axis;

		private bool isHighPeakLine;		
		private double highPeakXValue;
		private double highPeakYValue;

		/// <summary>
		/// The array of independent (X Axis) values that define this
		/// <see cref="CurveItem"/>.
		/// The size of this array determines the number of points that are
		/// plotted.  Note that values defined as
		/// System.Double.MaxValue are considered "missing" values,
		/// and are not plotted.  The curve will have a break at these points
		/// to indicate values are missing.
		/// </summary>
		public ArrayList X;
		
		/// <summary>
		/// The array of dependent (Y Axis) values that define this
		/// <see cref="CurveItem"/>.
		/// The size of this array determines the number of points that are
		/// plotted.  Note that values defined as
		/// System.Double.MaxValue are considered "missing" values,
		/// and are not plotted.  The curve will have a break at these points
		/// to indicate values are missing.
		/// </summary>
		public ArrayList Y;

		// Color for individual points
		public ArrayList CL;

		//Symbol for individual points		
		public ArrayList SYM;

		public bool AddPointFlg;

		public bool DigitalFlg;
		
		//Label for Name of the each curve.
		private string labelX;
		
		//Flag to indicate that curve contains all scattered points
		private bool mblnIsScatteredPointsCurve;
		
		//ArrayList to store multiple scattered points
		public ArrayList ScatteredPoints;
		
		public bool IsHighPeakLine
		{
			get {return isHighPeakLine;} 
			set {isHighPeakLine = value;}
		}
        
		public double HighPeakYValue
		{
			get{return highPeakYValue;}
			set{highPeakYValue= value;}
		}
		public double HighPeakXValue
		{
			get{return highPeakXValue;}
			set{highPeakXValue = value;}
		}

		//A unique No. is assigned to each x & y co-ordinates to indicate
		//the position of the point in the curve.
		//private ArrayList marrPointNumbers;

		/// <summary>
		/// <see cref="CurveItem"/> constructor the pre-specifies the curve label and the
		/// x and y data arrays.  All other properties of the curve are
		/// defaulted to the values in the <see cref="Def"/> class.
		/// </summary>
		/// <param name="label">A string label (legend entry) for this curve</param>
		/// <param name="x">A array of double precision values that define
		/// the independent (X axis) values for this curve</param>
		/// <param name="y">A array of double precision values that define
		/// the dependent (Y axis) values for this curve</param>
		public CurveItem( string label, ArrayList x, ArrayList y )
		{
			this.line = new Line();
			this.symbol = new Symbol();
			this.label = label;
			this.isY2Axis = false;
			this.X = new ArrayList();
			this.Y = new ArrayList();
			this.CL = new ArrayList();
			this.SYM = new ArrayList();
			this.mblnIsScatteredPointsCurve = false;
			this.ScatteredPoints = new ArrayList();

			if ( x.Count > 0 )
				this.X = (ArrayList) x.Clone();
			if ( y.Count > 0 )
				this.Y = (ArrayList) y.Clone();	

			//----- Added by Sachin Dokhale
			IsHighPeakLine = false;
			HighPeakXValue = 0.0;
			HighPeakYValue = 0.0;
			//-----
		}


		/// <summary>
		/// <see cref="CurveItem"/> constructor the pre-specifies the curve label and the
		/// x and y data arrays.  All other properties of the curve are
		/// defaulted to the values in the <see cref="Def"/> class.
		/// </summary>
		/// <param name="label">A string label (legend entry) for this curve</param>
		/// <param name="x">A array of double precision values that define
		/// the independent (X axis) values for this curve</param>
		/// <param name="y">A array of double precision values that define
		/// the dependent (Y axis) values for this curve</param>
		public CurveItem( string label, ArrayList x, ArrayList y ,ArrayList cl ,ArrayList sym)
		{
			this.line = new Line();
			this.symbol = new Symbol();
			this.label = label;
			this.isY2Axis = false;
			//-		-----------------
			this.X = new ArrayList();
			this.Y = new ArrayList();
			this.CL = new ArrayList();
			this.SYM = new ArrayList();
			this.mblnIsScatteredPointsCurve = false;
			this.ScatteredPoints = new ArrayList();

			//-		-----------------
			if ( x.Count > 0 )
				this.X = (ArrayList) x.Clone();
			if ( y.Count > 0 )
				this.Y = (ArrayList) y.Clone();
			if ( cl.Count > 0)
				this.CL = (ArrayList) cl.Clone();
			if ( sym.Count >0 )
				this.SYM = (ArrayList) sym.Clone();

			//----- Added by Sachin Dokhale
			IsHighPeakLine = false;
			HighPeakXValue = 0.0;
			HighPeakYValue = 0.0;
			//-----

		}
								

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The CurveItem object from which to copy</param>
		public CurveItem( CurveItem rhs )
		{
			symbol = new Symbol( rhs.Symbol );
			line = new Line( rhs.Line );
			label = rhs.Label;
			isY2Axis = rhs.IsY2Axis;
			mblnIsScatteredPointsCurve = rhs.IsScatteredPointsCurve;
			ScatteredPoints = rhs.ScatteredPoints;

			int len = rhs.X.Count ;

			this.X = (ArrayList)rhs.X.Clone();
			
			this.Y = (ArrayList)rhs.Y.Clone();
			
			this.CL = (ArrayList)rhs.CL.Clone();
			
			this.SYM = (ArrayList)rhs.SYM.Clone();

			//----- Added by Sachin Dokhale
			IsHighPeakLine = rhs.IsHighPeakLine;
			HighPeakXValue = rhs.HighPeakXValue;
			HighPeakYValue = rhs.HighPeakYValue;
			//-----
		}


		/// <summary>
		/// Deep-copy clone routine
		/// </summary>
		/// <returns>A new, independent copy of the CurveItem</returns>
		public object Clone()
		{ 
			return new CurveItem( this ); 
		}


		/// <summary>
		/// Gets a reference to the <see cref="AldysGraph.Symbol"/> class defined
		/// for this <see cref="CurveItem"/>.
		/// </summary>
		public Symbol Symbol
		{
			get { return symbol; }
		}


		/// <summary>
		/// Gets a reference to the <see cref="AldysGraph.Line"/> class defined
		/// for this <see cref="CurveItem"/>.
		/// </summary>
		public Line Line
		{
			get { return line; }
		}
		

		/// <summary>
		/// A text string that represents the <see cref="AldysGraph.Legend"/>
		/// entry for the this
		/// <see cref="CurveItem"/> object
		/// </summary>
		public string Label
		{
			get { return label; }
			set { label = value;}
		}

		/// <summary>
		/// A text string that represents the <see cref="ZedGraph.Legend"/>
		/// entry for the this
		/// <see cref="CurveItem"/> object
		/// </summary>
		public string LabelX
		{
			get { return labelX; }
			set { labelX = value;}
		}


		/// <summary>
		/// Determines which Y axis this <see cref="CurveItem"/>
		///  is assigned to.  The
		/// <see cref="ZedGraph.YAxis"/> is on the left side of the graph and the
		/// <see cref="ZedGraph.Y2Axis"/> is on the right side.  Assignment to an axis
		/// determines the scale that is used to draw the curve on the graph.
		/// </summary>
		/// <value>true to assign the curve to the <see cref="ZedGraph.Y2Axis"/>,
		/// false to assign the curve to the <see cref="ZedGraph.YAxis"/></value>
		public bool IsY2Axis
		{
			get { return isY2Axis; }
			set { isY2Axis = value; }
		}
		

		/// <summary>
		/// Readonly property that gives the number of points that define this
		/// <see cref="CurveItem"/> object, which is the number of points in the
		/// <see cref="X"/> and <see cref="Y"/> data arrays.
		/// </summary>
		public int NPts {
			get {
				if ( this.X.Count <= 0 || this.Y.Count <= 0 )
					return 0;
				else {
					return X.Count < Y.Count ? X.Count : Y.Count;
				}
			}
		}

		/// <summary>
		/// To indicate that curve contains all scattered points
		/// </summary>
		public bool IsScatteredPointsCurve{
			get {
                return mblnIsScatteredPointsCurve;
			}
			set {
				mblnIsScatteredPointsCurve = value;
			}
		}

		
		/// <summary>
		/// Do all rendering associated with this <see cref="CurveItem"/> to the specified
		/// <see cref="Graphics"/> device.  This method is normally only
		/// called by the Draw method of the parent <see cref="AldysGraph.CurveList"/>
		/// collection object.  This version is optimized for speed and should be much
		/// faster than the regular Draw() routine.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see cref="AldysGraph.AldysPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see cref="ZedGraph.AldysPane"/> object using the
		/// <see cref="AldysPane.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		public void Draw( Graphics g, AldysPane pane, double scaleFactor )
		{
			int nPts = this.NPts - 1;
			float[]	tmpX ;
			float[] tmpY ;
			int i = 0;

			if((this.isHighPeakLine == false) && (this.AddPointFlg == false )|| (this.AddPointFlg == true && pane.CurveList.isResizing))
			{
				tmpX = new float[nPts];
				tmpY = new float[nPts];

				// Loop over each point in the curve
				for ( i=0; i < nPts; i++ )
				{
					if (((double)this.X[i]) == System.Double.MaxValue ||
						((double)this.Y[i]) == System.Double.MaxValue ||
						( pane.XAxis.IsLog && ((double)this.X[i]) <= 0.0 ) ||
						//( this.isY2Axis && pane.Y2Axis.IsLog && this.Y[i] <= 0.0 ) ||
						( !this.isY2Axis && pane.YAxis.IsLog && ((double)this.Y[i]) <= 0.0 ) )
					{
						tmpX[i] = float.MaxValue;
						tmpY[i] = float.MaxValue;
					}
					else
					{
						// Transform the current point from user scale units to
						// screen coordinates
						tmpX[i] = pane.XAxis.Transform( ((double)this.X[i]));						
						tmpY[i] = pane.YAxis.Transform( ((double)this.Y[i]));

						if ( tmpX[i] < -100000 || tmpX[i] > 100000 ||
							 tmpY[i] < -100000 || tmpY[i] > 100000 )
						{
							tmpX[i] = System.Single.MaxValue;
							tmpY[i] = System.Single.MaxValue;
						}
					}
				}
							
				this.Line.ColorList =this.CL;  
				this.Line.DrawManyEx( g, pane,tmpX, tmpY,this.Y);
				//pane.CurveList.isResizing = false;

				if((this.SYM.Count > 0) && (this.CL.Count > 0 ))
					this.Symbol.DrawMany(g, tmpX, tmpY, scaleFactor,this.CL,this.SYM);			
				else
					this.Symbol.DrawManyEx( g,pane, tmpX, tmpY, scaleFactor,this.Y );
			
				if (this.mblnIsScatteredPointsCurve)
				{
					//Plot the scattered points
					for ( i=0 ; i < this.ScatteredPoints.Count ; i++ )
					{
						//---Draw the single point						
						Point objPoint = (Point)ScatteredPoints[i];
						float fX  = pane.XAxis.Transform( (double)objPoint.X );	
						float fY  = pane.YAxis.Transform( (double)objPoint.Y );						
						Color curveColor = this.Symbol.Color;
						this.Symbol.Color = objPoint.PointColor;
						this.Symbol.Size = objPoint.PointRadius;
						this.Symbol.Draw(g,fX,fY,scaleFactor);
						this.Symbol.Color = curveColor;
					}
				}
			}
			else
			{			
				if(nPts == 1 || nPts == 0)		
				{
					//---in future to draw single point in curve					
					//---Added By Mangesh S. on 26-Nov-2006					
					//if (this.mblnIsScatteredPointsCurve){
					//---Loop over each point in the curve
					//for ( i=0; i < this.NPts ; i++ )
					//{
					//	//---Draw the single point
					//	float fX = pane.XAxis.Transform( ((double)this.X[i]));						
					//	float fY = pane.YAxis.Transform( ((double)this.Y[i]));
					//	this.Symbol.Draw(g,fX,fY,scaleFactor);
					//}
					//}
					return;
				}

				tmpX = new float[2];
				tmpY = new float[2];
				int j;

				//Draw only for last two points 
				for(i = this.NPts-2, j = 0; i<this.NPts ; i++, j++)
				{
					if (((double)this.X[i]) == System.Double.MaxValue ||
						((double)this.Y[i]) == System.Double.MaxValue ||
						( pane.XAxis.IsLog && ((double)this.X[i]) <= 0.0 ) ||
						(!this.isY2Axis && pane.YAxis.IsLog && ((double)this.Y[i]) <= 0.0 ) )
					{
						tmpX[j] = System.Single.MaxValue;
						tmpY[j] = System.Single.MaxValue;
					}
					else
					{
						// Transform the current point from user scale units to
						// screen coordinates
						tmpX[j] = pane.XAxis.Transform( ((double)this.X[i]) );
						tmpY[j] = pane.YAxis.Transform( ((double)this.Y[i]) );

						if ( tmpX[j] < -100000 || tmpX[j] > 100000 ||
							tmpY[j] < -100000 || tmpY[j] > 100000 )
						{
							tmpX[j] = System.Single.MaxValue;
							tmpY[j] = System.Single.MaxValue;
						}
					}
				}

				this.Line.DrawManyEx( g, pane,tmpX, tmpY,this.Y);
				this.Symbol.DrawMany( g, tmpX, tmpY, scaleFactor);
			}			
		}

		/*
				/// <summary>
				/// Draw the this <see cref="CurveItem"/> to the specified <see cref="Graphics"/>
				/// device.  The format (stair-step or line) of the curve is
				/// defined by the <see cref="StepType"/> property.  The routine
				/// only draws the line segments; the symbols are draw by the
				/// <see cref="DrawSymbols"/> method.  This method
				/// is normally only called by the Draw method of the
				/// <see cref="CurveItem"/> object
				/// </summary>
				/// <param name="g">
				/// A graphic device object to be drawn into.  This is normally e.Graphics from the
				/// PaintEventArgs argument to the Paint() method.
				/// </param>
				/// <param name="pane">
				/// A reference to the <see cref="AldysPane"/> object that is the parent or
				/// owner of this object.
				/// </param>
				protected void DrawCurve( Graphics g, AldysPane pane )
				{
					float	tmpX, tmpY,
							lastX = 0,
							lastY = 0;
					bool	broke = true;
			
					// Loop over each point in the curve, building an array of screen
					// locations.  Invalid points are set to System.Double.MaxValue
					int nPts = this.NPts;
					for ( int i=0; i<nPts; i++ )
					{
						// Any value set to double max is invalid and should be skipped
						// This is used for calculated values that are out of range, divide
						//   by zero, etc.
						// Also, any value <= zero on a log scale is invalid
						if ( 	this.X[i] == System.Double.MaxValue ||
								this.Y[i] == System.Double.MaxValue ||
								( pane.XAxis.IsLog && this.X[i] <= 0.0 ) ||
								( this.isY2Axis && pane.Y2Axis.IsLog && this.Y[i] <= 0.0 ) ||
								( !this.isY2Axis && pane.YAxis.IsLog && this.Y[i] <= 0.0 ) )
						{
							broke = true;
						}
						else
						{
							// Transform the current point from user scale units to
							// screen coordinates
							tmpX = pane.XAxis.Transform( this.X[i] );
							if ( this.isY2Axis )
								tmpY = pane.Y2Axis.Transform( this.Y[i] );
							else
								tmpY = pane.YAxis.Transform( this.Y[i] );
					
							// off-scale values "break" the line
							if ( tmpX < -100000 || tmpX > 100000 ||
									tmpY < -100000 || tmpY > 100000 )
								broke = true;
							else
							{
								// If the last two points are valid, draw a line segment
								if ( !broke )
								{
									if ( this.stepType == StepType.ForwardStep )
									{
										this.Line.Draw( g, lastX, lastY, tmpX, lastY );
										this.Line.Draw( g, tmpX, lastY, tmpX, tmpY );
									}
									else if ( this.stepType == StepType.RearwardStep )
									{
										this.Line.Draw( g, lastX, lastY, lastX, tmpY );
										this.Line.Draw( g, lastX, tmpY, tmpX, tmpY );
									}
									else 		// non-step
										this.Line.Draw( g, lastX, lastY, tmpX, tmpY );

								}

								// Save some values for the next point
								broke = false;
								lastX = tmpX;
								lastY = tmpY;
							}
						}
					}
				}
		*/
		/*
				/// <summary>
				/// Draw the this <see cref="CurveItem"/> to the specified <see cref="Graphics"/>
				/// device as a symbol at each defined point.  The routine
				/// only draws the symbols; the lines are draw by the
				/// <see cref="DrawCurve"/> method.  This method
				/// is normally only called by the Draw method of the
				/// <see cref="CurveItem"/> object
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
				public void DrawSymbols( Graphics g, AldysPane pane, double scaleFactor )
				{
					float tmpX, tmpY;
			
					// Loop over each defined point							
					for ( int i=0; i<this.NPts; i++ )
					{
						// Any value set to double max is invalid and should be skipped
						// This is used for calculated values that are out of range, divide
						//   by zero, etc.
						// Also, any value <= zero on a log scale is invalid
				
						if (	this.X[i] != System.Double.MaxValue &&
								this.Y[i] != System.Double.MaxValue &&
								( this.X[i] > 0 || !pane.XAxis.IsLog ) &&
								( this.Y[i] > 0 ||
									(this.isY2Axis && !pane.Y2Axis.IsLog ) ||
									(!this.isY2Axis && !pane.YAxis.IsLog ) ) )
						{
							tmpX = pane.XAxis.Transform( this.X[i] );
							if ( this.isY2Axis )
								tmpY = pane.Y2Axis.Transform( this.Y[i] );
							else
								tmpY = pane.YAxis.Transform( this.Y[i] );

							this.Symbol.Draw( g, tmpX, tmpY, scaleFactor );		
						}
					}
				}
		*/

		/// <summary>
		/// Go through <see cref="X"/> and <see cref="Y"/> data arrays
		/// for this <see cref="CurveItem"/>
		/// and determine the minimum and maximum values in the data.
		/// </summary>
		/// <param name="xMin">The minimum X value in the range of data</param>
		/// <param name="xMax">The maximum X value in the range of data</param>
		/// <param name="yMin">The minimum Y value in the range of data</param>
		/// <param name="yMax">The maximum Y value in the range of data</param>
		/// <param name="ignoreInitial">ignoreInitial is a boolean value that
		/// affects the data range that is considered for the automatic scale
		/// ranging (see <see cref="AldysPane.IsIgnoreInitial"/>).  If true, then initial
		/// data points where the Y value is zero are not included when
		/// automatically determining the scale <see cref="Axis.Min"/>,
		/// <see cref="Axis.Max"/>, and <see cref="Axis.Step"/> size.  All data after
		/// the first non-zero Y value are included.
		/// </param>
		public void GetRange( ref double xMin, ref double xMax,
			ref double yMin, ref double yMax,
			bool ignoreInitial )
		{
			// initialize the values to outrageous ones to start
			xMin = yMin = 1.0e20;
			xMax = yMax = -1.0e20;
			
			// Loop over each point in the arrays
			for ( int i=0; i<this.NPts; i++ )
			{
				// ignoreInitial becomes false at the first non-zero
				// Y value
				if (ignoreInitial && (bool)((double)(this.Y[i]) != 0) && ((double)this.Y[i]) != System.Double.MaxValue)
					ignoreInitial = false;
				
				if (!ignoreInitial && ((double)this.X[i]) != System.Double.MaxValue && ((double)this.Y[i]) != System.Double.MaxValue)
				{
					if ( ((double)this.X[i]) < xMin )
						xMin = (double)this.X[i];
					if ( ((double)this.X[i]) > xMax )
						xMax = (double)this.X[i];
					if ( ((double)this.Y[i]) < yMin )
						yMin = (double)this.Y[i];
					if ( ((double)this.Y[i]) > yMax )
						yMax = (double)this.Y[i];
				}
			}	
		}
		

		/// <summary>
		/// See if the <see cref="X"/> or <see cref="Y"/> data arrays are missing
		/// for this <see cref="CurveItem"/>.  If so, provide a suitable default
		/// array using ordinal values.
		/// </summary>
		/// <param name="pane">
		/// A reference to the <see cref="AldysPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		public void DataCheck( AldysPane pane )
		{
			// See if a default X array is required
			if ( this.X == null )
			{
				// if a Y array is available, just make the same number of elements
				if ( this.Y != null )
					this.X = MakeDefaultArray( this.Y.Count  );
				else
					this.X = pane.XAxis.MakeDefaultArray();
			}
			// see if a default Y array is required
			if ( this.Y == null )
			{
				// if an X array is available, just make the same number of elements
				if ( this.X != null )
					this.Y = MakeDefaultArray( this.X.Count );
					//				else if ( this.isY2Axis )
					//					this.Y = pane.Y2Axis.MakeDefaultArray();
				else
					this.Y = pane.YAxis.MakeDefaultArray();
			}
		}
		

		/// <summary>
		/// Generate a default array of ordinal values.
		/// </summary>
		/// <param name="length">
		/// The number of values to generate.
		/// </param>
		/// <returns>a floating point double type array of default ordinal values</returns>
		private ArrayList MakeDefaultArray( int length )
		{
			//double[] dArray = new double[length];
			ArrayList dArray = new ArrayList();
			//dArray.Clear();
			for ( int i=0; i<length; i++ )
				dArray.Add((double) i + 1.0);
			
			return dArray;
		}


		public void InsertCurvePixels(AldysPane pane, ArrayList peakx, ArrayList peaky)
		{
			// Transform the current point from user scale units to
			// screen coordinates
			float fX, fY;
			fX = 0;
			fY = 0;
			for(int i = 0; i < this.NPts; i++)
			{
				fX = pane.XAxis.Transform( ((double)this.X[i]) );
				fY = pane.YAxis.Transform( ((double)this.Y[i]) );
				if(pane.axisRect.Contains(fX,fY))
				{
					peakx.Add((double)fX);	
					peaky.Add((double)fY);
				}
			}

		}

		
	}
}
