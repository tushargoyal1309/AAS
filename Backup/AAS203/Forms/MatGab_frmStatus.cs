using AAS203.Common;
using AAS203Library.Method;
public class frmStatus : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmStatus()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmStatus(int intTurrNo, int intEleID = 0)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		ElementID = intEleID;
		TurretNumber = intTurrNo;
	}

	public frmStatus(int intTurrNo, string strEleName)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		TurretNumber = intTurrNo;
		ElementName = strEleName;
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.Label lblElementName;
	internal System.Windows.Forms.Label lblTurretNo;
	internal System.Windows.Forms.Label pbFlame;
	internal System.Windows.Forms.ImageList ImageList1;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStatus));
		this.lblElementName = new System.Windows.Forms.Label();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.lblTurretNo = new System.Windows.Forms.Label();
		this.pbFlame = new System.Windows.Forms.Label();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.SuspendLayout();
		//
		//lblElementName
		//
		this.lblElementName.BackColor = System.Drawing.Color.DeepSkyBlue;
		this.lblElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblElementName.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblElementName.ForeColor = System.Drawing.Color.White;
		this.lblElementName.ImageList = this.ImageList1;
		this.lblElementName.Location = new System.Drawing.Point(6, 4);
		this.lblElementName.Name = "lblElementName";
		this.lblElementName.Size = new System.Drawing.Size(32, 32);
		this.lblElementName.TabIndex = 0;
		this.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//ImageList1
		//
		this.ImageList1.ImageSize = new System.Drawing.Size(32, 32);
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		//
		//lblTurretNo
		//
		this.lblTurretNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.lblTurretNo.BackColor = System.Drawing.Color.DeepSkyBlue;
		this.lblTurretNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTurretNo.Font = new System.Drawing.Font("Times New Roman", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretNo.ForeColor = System.Drawing.Color.DeepSkyBlue;
		this.lblTurretNo.Location = new System.Drawing.Point(47, 4);
		this.lblTurretNo.Name = "lblTurretNo";
		this.lblTurretNo.Size = new System.Drawing.Size(32, 32);
		this.lblTurretNo.TabIndex = 1;
		this.lblTurretNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//pbFlame
		//
		this.pbFlame.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.pbFlame.BackColor = System.Drawing.Color.DeepSkyBlue;
		this.pbFlame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pbFlame.Location = new System.Drawing.Point(87, 4);
		this.pbFlame.Name = "pbFlame";
		this.pbFlame.Size = new System.Drawing.Size(32, 32);
		this.pbFlame.TabIndex = 2;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(53, 96);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(22, 17);
		this.btnIgnite.TabIndex = 13;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(80, 56);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(38, 18);
		this.btnExtinguish.TabIndex = 14;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(112, 24);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 19;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Gainsboro;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(140, 61);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 24;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.Gainsboro;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(152, 61);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 23;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//frmStatus
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.Gainsboro;
		this.ClientSize = new System.Drawing.Size(128, 40);
		this.ControlBox = false;
		this.Controls.Add(this.btnDelete);
		this.Controls.Add(this.btnR);
		this.Controls.Add(this.btnExtinguish);
		this.Controls.Add(this.btnIgnite);
		this.Controls.Add(this.pbFlame);
		this.Controls.Add(this.lblTurretNo);
		this.Controls.Add(this.lblElementName);
		this.Controls.Add(this.btnN2OIgnite);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Location = new System.Drawing.Point(590, 20);
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmStatus";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.TopMost = true;
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Constants"
	private const  Const_Multi = "Multi";
	private const  Const_CaMg = "Ca-Mg";
	private const  Const_NaK = "Na-K";
		#End Region
	private const  Const_CuZn = "Cu-Zn";

	#Region " Private Variables "

	private int mintTurretNumber;
	private int mintElementID;
	private string mstrEleName;
	private ClsAAS203.enumIgniteType mintFlameType;
	private bool mblnIsHydrideMode;
	private Rectangle mRect = Screen.GetWorkingArea(new frmAASInitialisation());
		#End Region
	private bool mblnAvoidProcessing = false;

	#Region " Public Properties "

	public int TurretNumber {
		get { return mintTurretNumber; }
		set {
			try {
				mintTurretNumber = Value;
				switch (TurretNumber) {
					case 1:
						lblTurretNo.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\turret_po_1.ico");
					case 2:
						lblTurretNo.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\turret_po_2.ico");
					case 3:
						lblTurretNo.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\turret_po_3.ico");
					case 4:
						lblTurretNo.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\turret_po_4.ico");
					case 5:
						lblTurretNo.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\turret_po_5.ico");
					case 6:
						lblTurretNo.Image = Image.FromFile(Application.StartupPath + "\\" + "images\\turret_po_6.ico");
				}

				//lblTurretNo.Text = TurretNumber
				lblTurretNo.Refresh();

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				if (CONST_CREATE_EXECUTION_LOG == 1) {
					gobjErrorHandler.WriteExecutionLog();
				}
				//---------------------------------------------------------
			}
		}
	}

	public string ElementName {
		get { return mstrEleName; }
		set {
			mstrEleName = Value;
			//Saurabh 09.08.07
			if (ElementName == Const_Multi) {
				ElementName = "Cr-Co-Cu-Fe-Mn-Ni";
				this.Left = mRect.Width - 278;
				this.Size = new Size(258, 42);
				lblElementName.Size = new Size(162, 32);
			} else if (ElementName == Const_CaMg | ElementName == Const_NaK | ElementName == Const_CuZn) {
				this.Left = mRect.Width - 178;
				this.Size = new Size(158, 42);
				lblElementName.Size = new Size(62, 32);
			} else {
				this.Left = mRect.Width - 150;
				this.Size = new Size(130, 42);
				lblElementName.Size = new Size(32, 32);
			}
			//Saurabh 09.08.07
			lblElementName.Text = ElementName;
			lblElementName.Refresh();
		}
	}

	public int ElementID {
		get { return mintElementID; }
		set {
			try {
				mintElementID = Value;
				funcFindEleName();

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				if (CONST_CREATE_EXECUTION_LOG == 1) {
					gobjErrorHandler.WriteExecutionLog();
				}
				//---------------------------------------------------------
			}
		}
	}

	public ClsAAS203.enumIgniteType FlameType {
		get { return mintFlameType; }
		set {
			mintFlameType = Value;

			Image objImage;

			//Application.DoEvents()
			if (mblnIsHydrideMode) {
				objImage = Image.FromFile(Application.StartupPath + "\\Images\\Hydride_Mode.ico");
			} else {
				switch (mintFlameType) {
					case ClsAAS203.enumIgniteType.Blue:
						objImage = Image.FromFile(Application.StartupPath + "\\Images\\BLUEF.bmp");
					case ClsAAS203.enumIgniteType.Yellow:
						objImage = Image.FromFile(Application.StartupPath + "\\Images\\YELLOWF.bmp");
					case ClsAAS203.enumIgniteType.Red:
						objImage = Image.FromFile(Application.StartupPath + "\\Images\\REDF.bmp");
					case ClsAAS203.enumIgniteType.Green:
						objImage = Image.FromFile(Application.StartupPath + "\\Images\\GREENF.bmp");
				}
			}

			System.Drawing.Bitmap objBitmap = new System.Drawing.Bitmap(objImage);
			pbFlame.Image = objBitmap;
			pbFlame.Refresh();
			Application.DoEvents();
		}
	}

	public bool IsHydrideMode {
		get { return mblnIsHydrideMode; }
		set { mblnIsHydrideMode = Value; }
	}

	#End Region

	#Region " Form Events "

	private void  // ERROR: Handles clauses are not supported in C#
frmStatus_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmStatus_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak & Saurabh
		// Created               : 05.11.06
		// Revisions             : praveen
		//=====================================================================
		string strElementName;
		DataTable objDtElements = new DataTable();
		//'this is a object for data structure.
		CWaitCursor objWait = new CWaitCursor();
		try {
			//---to add handlers
			this.Top = 20;
			this.Left = mRect.Width - 150;
			btnIgnite.Click += btnIgnite_Click;
			//'for eg if we click on ignite button then btnIgnite_Click will called.
			btnExtinguish.Click += btnExtinguish_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
				//'Destructure

			}
			//---------------------------------------------------------
		}
	}

	private bool funcFindEleName()
	{
		//=====================================================================
		// Procedure Name        : funcFindEleName
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To find the element Name.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak & Saurabh & Sachin Dokhale
		// Created               : 05.11.06
		// Revisions             : praveen
		//=====================================================================
		string strElementName;
		DataTable objDtElements = new DataTable();

		try {
			//---to get element name of selected element id
			if (!ElementID == 0) {
				objDtElements = gobjDataAccess.GetCookBookData(mintElementID);
				if (!objDtElements == null) {
					if (objDtElements.Rows.Count > 0) {
						strElementName = objDtElements.Rows(0).Item(ConstColumnElementName);
					}
				}
				ElementName = strElementName;
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	private void btnIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To auto ignite the flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 05.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user clicked on ignite button
		//'this will call a auto ignition event.
		if (mblnAvoidProcessing == true) {
			//'check a flag for avoiding a process.
			return;
		}

		try {
			//---for auto ignition

			if (!IsNothing(gobjMain)) {
				mblnAvoidProcessing = true;
				gobjMain.AutoIgnition();
				mblnAvoidProcessing = false;
				//'function for auto ignition.)
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void btnExtinguish_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To extinguish the flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 05.11.06
		// Revisions             : praveen
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			//---to extinguish flame

			if (!IsNothing(gobjMain)) {
				mblnAvoidProcessing = true;
				gobjMain.Extinguish();
				//'function for Extinguish
				mblnAvoidProcessing = false;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnN2OIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To auto ignite N2O flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh
		// Created               : 05.11.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when user clicked on N2O ignite button
		try {
			//---for auto ignition of N2O flame
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.N2OAutoIgnition();
			//'for N2O ignition.
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void btnDelete_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDelete_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.funcAltDelete();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void btnR_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnR_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.funcAltR();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}


}
