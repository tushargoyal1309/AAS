using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace AldysGraph
{
	/// <summary>	
	/// A class representing all the characteristics of a <see cref="Point"/>
	/// that is plotted as separate scattered point on the graph.
	/// </summary>
	/// 
	//---- Added by Sachin Dokhale
//	public enum PointsType 
//	{ Std=1,
//	  Samp=2
//	};
	public class Point : ICloneable
	{
		#region Constructors 
		/// <summary>
		/// Default constructor that sets all <see cref="Point"/> properties to default
		/// values as defined in the <see cref="Def"/> class.
		/// </summary>
		public Point()
		{
			this.x = 0.0F; 
			this.y = 0.0F; 
            this.pointNumber = 0;
			this.isVisible = true;				//Defaults.Point.IsVisible;
			this.isAddedInCurve = false;		//Defaults.Point.IsAddedInCurve;
			this.pointRadius = 10.0F;			//Defaults.Point.Radius;
			this.style = DashStyle.Solid;		//Defaults.Point.Style;			
			this.pointColor = Color.Green;		//Defaults.Point.Color;
			//this.point_info.PointsName = "";
			//this.point_info.PointsType = this.points_type.Std ;
			//this.point_info.IsUsed = false;
			this.point_info = point_infos;
			//this.pointinfo = pointinfos;
			this.pointinfo = pointinfos;

		}


		/// <summary>
		/// An overloaded constructor to construct point.
		/// </summary>
		public Point(float x,float y,int pointNumber,bool isAddedInCurve)
		{
			this.x = x; 
			this.y = y; 
			this.pointNumber = pointNumber;
			this.isAddedInCurve = isAddedInCurve;

			this.isVisible = true;
			this.pointRadius = 10.0F;			
			this.style = DashStyle.Solid;
			this.pointColor = Color.Green;
			this.point_info = point_infos;
			this.pointinfo = pointinfos;
		}


		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The Line object from which to copy</param>
		public Point( Point rhs )
		{
			this.x = rhs.x; 
			this.y = rhs.y; 
			this.pointNumber = rhs.pointNumber;
			this.isVisible = rhs.isVisible;				//Defaults.Point.IsVisible;
			this.isAddedInCurve = rhs.isAddedInCurve;	//Defaults.Point.IsAddedInCurve;
			this.pointRadius = rhs.pointRadius;			//Defaults.Point.Radius;
			this.style = rhs.style;						//Defaults.Point.Style;			
			this.pointColor = rhs.pointColor;			//Defaults.Point.Color;
			this.point_info = rhs.point_infos;
			this.pointinfo = rhs.pointinfo;
		}


		#endregion

		#region ICloneable Members

		/// <summary>
		/// Deep-copy clone routine
		/// </summary>
		/// <returns>A new, independent copy of the Point</returns>
		public object Clone()
		{
			return new Point(this); 
		}

		#endregion

		#region Class Member Variables 

		private float x; 
		private float y; 
		private int pointNumber;
		private bool isVisible;
		private bool blnIsUse_btnRemove = true;
		private bool isAddedInCurve;
		private float pointRadius;
		private DashStyle style;
		private Color pointColor;
		private string mstrPointHeading;
		private ArrayList mobjUserData;
//		//---- Added by Sachin Dokhale
		private  ArrayList pointinfos;
		public enum points_type {Std=1,Samp=2,StdSamp=3};

		//private string PointName;
		//private bool IsUsed;
				
		public struct _point_info
		{
			public int PointNo;
			public string PointsName;
			public bool IsUsed;
			public points_type PointsType;
			public _point_info (int PointNo, string PointsName,bool IsUsed,points_type PointsType)
			{
				this.PointNo = PointNo;
				this.PointsName = PointsName;
				this.IsUsed = IsUsed;
				this.PointsType = PointsType;
			}
		}
		private _point_info point_infos;
		

		//-----
		#endregion

		#region  Public Properties 

		public float X{
			get{
				return x;
			}
			set {
				x = value;
			}
		} 

		public float Y
		{
			get
			{
				return y;
			}
			set 
			{
				y = value;
			}
		} 

		public int PointNumber
		{
			get
			{
				return pointNumber;
			}
			set 
			{
				pointNumber = value;
			}
		}

		public bool IsVisible
		{
			get
			{
				return isVisible;
			}
			set 
			{
				isVisible = value;
			}
		}

		public bool IsAddedInCurve
		{
			get
			{
				return isAddedInCurve;
			}
			set 
			{
				isAddedInCurve = value;
			}
		}

		public float PointRadius
		{
			get
			{
				return pointRadius;
			}
			set 
			{
				pointRadius = value;
			}
		}

		public DashStyle PointStyle
		{
			get
			{
				return style;
			}
			set 
			{
				style = value;
			}
		}

		public Color PointColor
		{
			get
			{
				return pointColor;
			}
			set 
			{
				pointColor = value;
			}
		}

		public string PointHeading
		{
			get
			{
				return mstrPointHeading;
			}
			set 
			{
				mstrPointHeading = value;
			}
		}

		public ArrayList UserData
		{
			get
			{
				return mobjUserData;
			}
			set
			{
				mobjUserData = value;
			}
		}

		public bool IsUse_btnRemove
		{
			get
			{
				return blnIsUse_btnRemove;
			}
			set 
			{
				blnIsUse_btnRemove = value;
			}
		}


		private  _point_info point_info 
		{
			get 
			{
				return point_infos;
			}
			set 
			{
				point_infos = value;
			}
		}


		public   ArrayList pointinfo 
		{
			get 
			{
				return pointinfos;
			}
			set 
			{
				pointinfos = value;
			}
		}

		#endregion

		#region Public Methods 

		public void Draw( Graphics g, double scaleFactor)
		{
			float	scaledSize = (float) ( this.pointRadius * scaleFactor );
			float	hsize = scaledSize / 2;
			
			if ( this.isVisible )
			{
				Pen pen = new Pen( this.pointColor);
				pen.DashStyle = this.style;
				g.DrawEllipse(pen, x-hsize, y-hsize,scaledSize, scaledSize);
			}
		}

		#endregion
	}
}
