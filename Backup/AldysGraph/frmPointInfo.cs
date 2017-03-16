using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NETXP.Controls;
using NETXP.Library;
using NETXP.Win32;


namespace AldysGraph.PointInfo
{
	/// <summary>
	/// A Small Ballon-Shaped Window to display 
	/// the selected point information.
	/// </summary>
	/// 

	public delegate void PointAddRemoveHandler(bool IsAddPoint, Point pointInfos);
//	public interface I 
//				{
//					//event MyDelegate MyEvent;
//					event PointAddRemoveHandler AddRemovePoint;
//					//void FireAway();
//				}
	
	public class frmPointInfo : NETXP.Controls.BalloonWindow
	{
		private NETXP.Controls.XPButton btnClose;
		public  NETXP.Controls.XPButton btnRemove;
		private System.Windows.Forms.Label lblPointCaption;
		private System.Windows.Forms.ListView lstViewUserData;
		public event PointAddRemoveHandler   AddRemovePoint;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//public event PointAddRemoveHandler AddRemovePoint;
		public frmPointInfo()
		{
			//
			// Required for Windows Form Designer support
			//
			
			InitializeComponent();
			//AddRemovePoint += new PointAddRemoveHandler(GetAddRemovePoint);
			//this.AddRemovePoint += new PointAddRemoveHandler(GetAddRemovePoint);
			//this.AddRemovePoint  += new PointAddRemoveHandler(btnRemove_Click);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmPointInfo(Point ptAldysPoint, System.Drawing.PointF anchorPoint, bool blnIsAddPoint)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			mptPointInfo = ptAldysPoint;		
			NewAnchorPoint = anchorPoint;
			mblnIsAddPoint = blnIsAddPoint;		
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblPointCaption = new System.Windows.Forms.Label();
			this.btnClose = new NETXP.Controls.XPButton();
			this.btnRemove = new NETXP.Controls.XPButton();
			this.lstViewUserData = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// lblPointCaption
			// 
			this.lblPointCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPointCaption.Location = new System.Drawing.Point(8, 8);
			this.lblPointCaption.Name = "lblPointCaption";
			this.lblPointCaption.Size = new System.Drawing.Size(184, 24);
			this.lblPointCaption.TabIndex = 2;
			this.lblPointCaption.Text = "Point Information";
			this.lblPointCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(128, 144);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(64, 24);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRemove.Location = new System.Drawing.Point(8, 144);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(64, 24);
			this.btnRemove.TabIndex = 4;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// lstViewUserData
			// 
			this.lstViewUserData.AutoArrange = false;
			this.lstViewUserData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstViewUserData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstViewUserData.FullRowSelect = true;
			this.lstViewUserData.Location = new System.Drawing.Point(8, 32);
			this.lstViewUserData.Name = "lstViewUserData";
			this.lstViewUserData.Size = new System.Drawing.Size(184, 104);
			this.lstViewUserData.TabIndex = 5;
			this.lstViewUserData.View = System.Windows.Forms.View.List;
			// 
			// frmPointInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(200, 176);
			this.Controls.Add(this.lstViewUserData);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lblPointCaption);
			this.Name = "frmPointInfo";
			this.Text = "frmPointInfo";
			this.Load += new System.EventHandler(this.frmPointInfo_Load);
			this.Deactivate += new System.EventHandler(this.frmPointInfo_Deactivate);
			this.ResumeLayout(false);

		}
		#endregion

		private Point mptPointInfo;
		private System.Drawing.PointF NewAnchorPoint;
		private bool mblnIsAddPoint;
		
		//public delegate void PointAddRemoveHandler(bool IsAddPoint, Point pointInfo);
//		public interface I 
//		{
//			event MyDelegate MyEvent;
			//public event PointAddRemoveHandler AddRemovePoint;
//			//void FireAway();
//		}
		#region I Members

		

		#endregion
		
        		
		private void frmPointInfo_Load(object sender, System.EventArgs e)
		{
			bool btnVisible=true;
			//Point._point_info eachPointinfo ;
			
			//this.Focus();

			if (mptPointInfo.PointHeading == null )
				lblPointCaption.Text = "Point Summary";
			else
				lblPointCaption.Text = mptPointInfo.PointHeading;

			
			if (mptPointInfo.UserData == null )
			{
				this.lstViewUserData.Items.Add("X-Value: " + mptPointInfo.X.ToString());
				this.lstViewUserData.Items.Add("Y-Value: " + mptPointInfo.Y.ToString());
			}
			else
			{												
				int i=0;
				for (i=0;i<mptPointInfo.UserData.Count;i++)
					this.lstViewUserData.Items.Add(mptPointInfo.UserData[i].ToString());
			this.Focus();
			}

			//this.AnchorPoint = NewAnchorPoint;
			this.AnchorPoint = new System.Drawing.Point( (int)NewAnchorPoint.X, (int)NewAnchorPoint.Y);

			
//			if (mblnIsAddPoint)
//				btnRemove.Text ="Enable";
//			else
//				btnRemove.Text ="Disable";

			if (mptPointInfo.IsUse_btnRemove == true)
			{
				btnRemove.Visible = true;
				btnVisible = true;
//				if (mblnIsAddPoint)
//					btnRemove.Text ="Enable";
//				else
//					btnRemove.Text ="Disable";
				foreach (Point._point_info  m_objptPointInfo in mptPointInfo.pointinfo )
				{
					if (m_objptPointInfo.IsUsed!=true)
					{
						btnRemove.Text ="Enable";
						mblnIsAddPoint=true;
						break;
					}
					else
					{
						btnRemove.Text ="Disable";
						mblnIsAddPoint=false;
					}
				}
			}
			else
				btnVisible = false;
				//btnRemove.Visible = false;
			
			//bool btnVisible;
			//point eachPont;
			foreach (Point._point_info eachPointinfo in mptPointInfo.pointinfo) 
			{
				//eachPointinfo= (Point._point_info)mptPointInfo.pointinfo[i];
				if (eachPointinfo.PointsType ==Point.points_type.Samp)
				{
					btnVisible=false;
				}
				else
				{
					if (mptPointInfo.IsUse_btnRemove == true)
					{
						btnVisible=true;
						break;
					}
				}
			}
			//if (mptPointInfo.pointinfo[0].PointsType == Point.points_type.Samp) 
			if (btnVisible==true) 
				btnRemove.Visible = true;
			else //if (mptPointInfo.point_info.PointsType = points_type.Samp) 
				btnRemove.Visible = false;
			this.Focus();
			this.BringToFront();
			this.Activate();   
			this.Focus();  
			this.TopMost=true; 
			Application.DoEvents();
	}

		private void frmPointInfo_Deactivate(object sender, System.EventArgs e)
		{
			//this.Close();
			//this.Dispose();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			//this.Close();
			//this.Dispose();
			Application.DoEvents();
		}

		 private void btnRemove_Click(object sender, System.EventArgs e)
		 {
			if (mblnIsAddPoint)
			//if (!m_objptPointInfo.IsUsed)
			{
				btnRemove.Text = "Enable";
				//if (AddRemovePoint != null)
					GetAddRemovePoint (true, mptPointInfo);
			}
			else
			{
				btnRemove.Text ="Disable";
				//if (AddRemovePoint != null)
					GetAddRemovePoint(false, mptPointInfo);
			}
			//mblnIsAddPoint = !mblnIsAddPoint;
			this.Close();
			this.Dispose();
			Application.DoEvents();
		}
		public void GetAddRemovePoint(bool IsAddPointIn, Point pointInfosIn)
		{
			if (AddRemovePoint != null)
				AddRemovePoint(IsAddPointIn,pointInfosIn);
		}

//		#region I Members
//
//		event AldysGraph.PointInfo.PointAddRemoveHandler AldysGraph.PointInfo.I.AddRemovePoint;
//
//		#endregion
	}
}
