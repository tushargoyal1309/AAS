using AAS203.Common;

public class frmAnalogDB : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmAnalogDB()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

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
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.Panel Panel2;
	internal NETXP.Controls.XPButton btnSetMode;
	internal NETXP.Controls.XPButton btnSetPMT;
	internal System.Windows.Forms.Label lblDEC;
	internal System.Windows.Forms.Label lblHEX;
	internal System.Windows.Forms.Label lblMV;
	internal System.Windows.Forms.TextBox txtDEC;
	internal System.Windows.Forms.TextBox txtHEX;
	internal System.Windows.Forms.TextBox txtMv;
	internal NETXP.Controls.XPButton btnClose;
	internal System.Windows.Forms.Label lblFiltered;
	internal NETXP.Controls.XPButton btnADCFilter;
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.TextBox txtMode;
	internal System.Windows.Forms.Label lblMode;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.TextBox txtPMT;
	internal System.Windows.Forms.Label lblPMT;
	internal System.Windows.Forms.TextBox txtMicroStatus;
	internal System.Windows.Forms.TextBox txtGainStatus;
	internal System.Windows.Forms.Label lblMicroStatus;
	internal System.Windows.Forms.Label lblGainStatus;
	internal System.Windows.Forms.TextBox txtAvgFactor;
	internal System.Windows.Forms.Label lblAvgFactor;
	internal NETXP.Controls.XPButton btnAvgValue;
	internal System.Windows.Forms.Panel Panel3;
	internal NETXP.Controls.Bars.CommandBar mnuAutoIgnition;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuIgnite;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExtinguish;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblPMT_Ref;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	internal System.Windows.Forms.GroupBox grpBeamType;
	internal System.Windows.Forms.RadioButton btnRef;
	internal System.Windows.Forms.RadioButton btnSample;
	internal System.Windows.Forms.Timer Timer1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAnalogDB));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.grpBeamType = new System.Windows.Forms.GroupBox();
		this.btnRef = new System.Windows.Forms.RadioButton();
		this.btnSample = new System.Windows.Forms.RadioButton();
		this.btnClose = new NETXP.Controls.XPButton();
		this.txtMicroStatus = new System.Windows.Forms.TextBox();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.lblPMT_Ref = new System.Windows.Forms.Label();
		this.txtAvgFactor = new System.Windows.Forms.TextBox();
		this.lblAvgFactor = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtPMT = new System.Windows.Forms.TextBox();
		this.lblPMT = new System.Windows.Forms.Label();
		this.txtMode = new System.Windows.Forms.TextBox();
		this.lblMode = new System.Windows.Forms.Label();
		this.btnAvgValue = new NETXP.Controls.XPButton();
		this.btnSetMode = new NETXP.Controls.XPButton();
		this.btnSetPMT = new NETXP.Controls.XPButton();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.btnADCFilter = new NETXP.Controls.XPButton();
		this.Label1 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.txtDEC = new System.Windows.Forms.TextBox();
		this.txtHEX = new System.Windows.Forms.TextBox();
		this.txtMv = new System.Windows.Forms.TextBox();
		this.lblDEC = new System.Windows.Forms.Label();
		this.lblHEX = new System.Windows.Forms.Label();
		this.lblMV = new System.Windows.Forms.Label();
		this.lblFiltered = new System.Windows.Forms.Label();
		this.txtGainStatus = new System.Windows.Forms.TextBox();
		this.lblGainStatus = new System.Windows.Forms.Label();
		this.lblMicroStatus = new System.Windows.Forms.Label();
		this.Panel3 = new System.Windows.Forms.Panel();
		this.mnuAutoIgnition = new NETXP.Controls.Bars.CommandBar();
		this.mnuIgnite = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExtinguish = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.Timer1 = new System.Windows.Forms.Timer(this.components);
		this.CustomPanel1.SuspendLayout();
		this.grpBeamType.SuspendLayout();
		this.Panel2.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.Panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.grpBeamType);
		this.CustomPanel1.Controls.Add(this.btnClose);
		this.CustomPanel1.Controls.Add(this.txtMicroStatus);
		this.CustomPanel1.Controls.Add(this.Panel2);
		this.CustomPanel1.Controls.Add(this.Panel1);
		this.CustomPanel1.Controls.Add(this.txtGainStatus);
		this.CustomPanel1.Controls.Add(this.lblGainStatus);
		this.CustomPanel1.Controls.Add(this.lblMicroStatus);
		this.CustomPanel1.Controls.Add(this.Panel3);
		this.CustomPanel1.Controls.Add(this.btnDelete);
		this.CustomPanel1.Controls.Add(this.btnR);
		this.CustomPanel1.Controls.Add(this.btnN2OIgnite);
		this.CustomPanel1.Controls.Add(this.btnExtinguish);
		this.CustomPanel1.Controls.Add(this.btnIgnite);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(458, 375);
		this.CustomPanel1.TabIndex = 0;
		//
		//grpBeamType
		//
		this.grpBeamType.Controls.Add(this.btnRef);
		this.grpBeamType.Controls.Add(this.btnSample);
		this.grpBeamType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.grpBeamType.Location = new System.Drawing.Point(16, 306);
		this.grpBeamType.Name = "grpBeamType";
		this.grpBeamType.Size = new System.Drawing.Size(128, 59);
		this.grpBeamType.TabIndex = 63;
		this.grpBeamType.TabStop = false;
		this.grpBeamType.Text = "Beam Type";
		//
		//btnRef
		//
		this.btnRef.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnRef.Location = new System.Drawing.Point(8, 37);
		this.btnRef.Name = "btnRef";
		this.btnRef.Size = new System.Drawing.Size(120, 18);
		this.btnRef.TabIndex = 1;
		this.btnRef.Text = "Reference Beam";
		//
		//btnSample
		//
		this.btnSample.Checked = true;
		this.btnSample.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSample.Location = new System.Drawing.Point(8, 14);
		this.btnSample.Name = "btnSample";
		this.btnSample.TabIndex = 0;
		this.btnSample.TabStop = true;
		this.btnSample.Text = "Sample Beam";
		//
		//btnClose
		//
		this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClose.Location = new System.Drawing.Point(351, 332);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(96, 32);
		this.btnClose.TabIndex = 11;
		this.btnClose.Text = "C&LOSE";
		//
		//txtMicroStatus
		//
		this.txtMicroStatus.BackColor = System.Drawing.Color.White;
		this.txtMicroStatus.Enabled = false;
		this.txtMicroStatus.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtMicroStatus.ForeColor = System.Drawing.Color.Blue;
		this.txtMicroStatus.Location = new System.Drawing.Point(256, 339);
		this.txtMicroStatus.Name = "txtMicroStatus";
		this.txtMicroStatus.Size = new System.Drawing.Size(80, 26);
		this.txtMicroStatus.TabIndex = 19;
		this.txtMicroStatus.Text = "";
		this.txtMicroStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//Panel2
		//
		this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Panel2.Controls.Add(this.lblPMT_Ref);
		this.Panel2.Controls.Add(this.txtAvgFactor);
		this.Panel2.Controls.Add(this.lblAvgFactor);
		this.Panel2.Controls.Add(this.Label2);
		this.Panel2.Controls.Add(this.txtPMT);
		this.Panel2.Controls.Add(this.lblPMT);
		this.Panel2.Controls.Add(this.txtMode);
		this.Panel2.Controls.Add(this.lblMode);
		this.Panel2.Controls.Add(this.btnAvgValue);
		this.Panel2.Controls.Add(this.btnSetMode);
		this.Panel2.Controls.Add(this.btnSetPMT);
		this.Panel2.Controls.Add(this.TextBox1);
		this.Panel2.Controls.Add(this.btnADCFilter);
		this.Panel2.Controls.Add(this.Label1);
		this.Panel2.Location = new System.Drawing.Point(16, 104);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(430, 192);
		this.Panel2.TabIndex = 1;
		//
		//lblPMT_Ref
		//
		this.lblPMT_Ref.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT_Ref.Location = new System.Drawing.Point(96, 57);
		this.lblPMT_Ref.Name = "lblPMT_Ref";
		this.lblPMT_Ref.Size = new System.Drawing.Size(40, 16);
		this.lblPMT_Ref.TabIndex = 22;
		this.lblPMT_Ref.Text = "PMT";
		this.lblPMT_Ref.Visible = false;
		//
		//txtAvgFactor
		//
		this.txtAvgFactor.BackColor = System.Drawing.Color.White;
		this.txtAvgFactor.Enabled = false;
		this.txtAvgFactor.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtAvgFactor.ForeColor = System.Drawing.Color.Blue;
		this.txtAvgFactor.Location = new System.Drawing.Point(232, 16);
		this.txtAvgFactor.Name = "txtAvgFactor";
		this.txtAvgFactor.Size = new System.Drawing.Size(80, 26);
		this.txtAvgFactor.TabIndex = 20;
		this.txtAvgFactor.Text = "300";
		this.txtAvgFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblAvgFactor
		//
		this.lblAvgFactor.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAvgFactor.Location = new System.Drawing.Point(163, 19);
		this.lblAvgFactor.Name = "lblAvgFactor";
		this.lblAvgFactor.Size = new System.Drawing.Size(72, 18);
		this.lblAvgFactor.TabIndex = 19;
		this.lblAvgFactor.Text = "Avg Factor";
		//
		//Label2
		//
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.ForeColor = System.Drawing.SystemColors.ControlDark;
		this.Label2.Location = new System.Drawing.Point(96, 76);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(80, 16);
		this.Label2.TabIndex = 18;
		this.Label2.Text = "(0-1000 mV)";
		//
		//txtPMT
		//
		this.txtPMT.BackColor = System.Drawing.Color.White;
		this.txtPMT.Enabled = false;
		this.txtPMT.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPMT.ForeColor = System.Drawing.Color.Blue;
		this.txtPMT.Location = new System.Drawing.Point(176, 60);
		this.txtPMT.Name = "txtPMT";
		this.txtPMT.Size = new System.Drawing.Size(80, 26);
		this.txtPMT.TabIndex = 17;
		this.txtPMT.Text = "0";
		this.txtPMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblPMT
		//
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT.Location = new System.Drawing.Point(96, 60);
		this.lblPMT.Name = "lblPMT";
		this.lblPMT.Size = new System.Drawing.Size(48, 16);
		this.lblPMT.TabIndex = 16;
		this.lblPMT.Text = "PMT";
		//
		//txtMode
		//
		this.txtMode.BackColor = System.Drawing.Color.White;
		this.txtMode.Enabled = false;
		this.txtMode.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtMode.ForeColor = System.Drawing.Color.Blue;
		this.txtMode.Location = new System.Drawing.Point(64, 16);
		this.txtMode.Name = "txtMode";
		this.txtMode.Size = new System.Drawing.Size(80, 26);
		this.txtMode.TabIndex = 15;
		this.txtMode.Text = "6";
		this.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblMode
		//
		this.lblMode.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMode.Location = new System.Drawing.Point(24, 21);
		this.lblMode.Name = "lblMode";
		this.lblMode.Size = new System.Drawing.Size(40, 16);
		this.lblMode.TabIndex = 14;
		this.lblMode.Text = "Mode";
		//
		//btnAvgValue
		//
		this.btnAvgValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAvgValue.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAvgValue.Image = (System.Drawing.Image)resources.GetObject("btnAvgValue.Image");
		this.btnAvgValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAvgValue.Location = new System.Drawing.Point(176, 104);
		this.btnAvgValue.Name = "btnAvgValue";
		this.btnAvgValue.Size = new System.Drawing.Size(136, 32);
		this.btnAvgValue.TabIndex = 9;
		this.btnAvgValue.Text = "&Avg Value";
		//
		//btnSetMode
		//
		this.btnSetMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetMode.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetMode.Image = (System.Drawing.Image)resources.GetObject("btnSetMode.Image");
		this.btnSetMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetMode.Location = new System.Drawing.Point(24, 144);
		this.btnSetMode.Name = "btnSetMode";
		this.btnSetMode.Size = new System.Drawing.Size(120, 32);
		this.btnSetMode.TabIndex = 2;
		this.btnSetMode.Text = "Set &Mode";
		//
		//btnSetPMT
		//
		this.btnSetPMT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetPMT.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetPMT.Image = (System.Drawing.Image)resources.GetObject("btnSetPMT.Image");
		this.btnSetPMT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetPMT.Location = new System.Drawing.Point(24, 104);
		this.btnSetPMT.Name = "btnSetPMT";
		this.btnSetPMT.Size = new System.Drawing.Size(120, 32);
		this.btnSetPMT.TabIndex = 0;
		this.btnSetPMT.Text = "Sample &PMT";
		//
		//TextBox1
		//
		this.TextBox1.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.TextBox1.Location = new System.Drawing.Point(320, 16);
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		this.TextBox1.Size = new System.Drawing.Size(96, 160);
		this.TextBox1.TabIndex = 13;
		this.TextBox1.Text = "Modes         0 - AA        1 - HCLE    2 - D2E       3 - Emmsn  4 - BGC       5 " + "- MABS    6 - ST ";
		//
		//btnADCFilter
		//
		this.btnADCFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnADCFilter.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnADCFilter.Image = (System.Drawing.Image)resources.GetObject("btnADCFilter.Image");
		this.btnADCFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnADCFilter.Location = new System.Drawing.Point(176, 144);
		this.btnADCFilter.Name = "btnADCFilter";
		this.btnADCFilter.Size = new System.Drawing.Size(136, 32);
		this.btnADCFilter.TabIndex = 12;
		this.btnADCFilter.Text = "ADC &Filter";
		this.btnADCFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label1
		//
		this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.ForeColor = System.Drawing.SystemColors.ControlDark;
		this.Label1.Location = new System.Drawing.Point(96, 75);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(40, 16);
		this.Label1.TabIndex = 24;
		this.Label1.Text = "(0-1000 mV)";
		this.Label1.Visible = false;
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Panel1.Controls.Add(this.txtDEC);
		this.Panel1.Controls.Add(this.txtHEX);
		this.Panel1.Controls.Add(this.txtMv);
		this.Panel1.Controls.Add(this.lblDEC);
		this.Panel1.Controls.Add(this.lblHEX);
		this.Panel1.Controls.Add(this.lblMV);
		this.Panel1.Controls.Add(this.lblFiltered);
		this.Panel1.Location = new System.Drawing.Point(16, 8);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(430, 88);
		this.Panel1.TabIndex = 0;
		//
		//txtDEC
		//
		this.txtDEC.BackColor = System.Drawing.Color.White;
		this.txtDEC.Enabled = false;
		this.txtDEC.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtDEC.Location = new System.Drawing.Point(336, 34);
		this.txtDEC.Name = "txtDEC";
		this.txtDEC.ReadOnly = true;
		this.txtDEC.Size = new System.Drawing.Size(80, 26);
		this.txtDEC.TabIndex = 4;
		this.txtDEC.Text = "";
		this.txtDEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txtHEX
		//
		this.txtHEX.BackColor = System.Drawing.Color.White;
		this.txtHEX.Enabled = false;
		this.txtHEX.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtHEX.Location = new System.Drawing.Point(248, 34);
		this.txtHEX.Name = "txtHEX";
		this.txtHEX.ReadOnly = true;
		this.txtHEX.Size = new System.Drawing.Size(80, 26);
		this.txtHEX.TabIndex = 3;
		this.txtHEX.Text = "";
		this.txtHEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txtMv
		//
		this.txtMv.BackColor = System.Drawing.Color.White;
		this.txtMv.Enabled = false;
		this.txtMv.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtMv.Location = new System.Drawing.Point(160, 36);
		this.txtMv.Name = "txtMv";
		this.txtMv.ReadOnly = true;
		this.txtMv.Size = new System.Drawing.Size(80, 26);
		this.txtMv.TabIndex = 2;
		this.txtMv.Text = "";
		this.txtMv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblDEC
		//
		this.lblDEC.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblDEC.Location = new System.Drawing.Point(328, 2);
		this.lblDEC.Name = "lblDEC";
		this.lblDEC.Size = new System.Drawing.Size(32, 22);
		this.lblDEC.TabIndex = 7;
		this.lblDEC.Text = "dec";
		//
		//lblHEX
		//
		this.lblHEX.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHEX.Location = new System.Drawing.Point(248, 2);
		this.lblHEX.Name = "lblHEX";
		this.lblHEX.Size = new System.Drawing.Size(32, 16);
		this.lblHEX.TabIndex = 6;
		this.lblHEX.Text = "hex";
		//
		//lblMV
		//
		this.lblMV.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMV.Location = new System.Drawing.Point(160, 2);
		this.lblMV.Name = "lblMV";
		this.lblMV.Size = new System.Drawing.Size(32, 18);
		this.lblMV.TabIndex = 5;
		this.lblMV.Text = "mv";
		//
		//lblFiltered
		//
		this.lblFiltered.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFiltered.Location = new System.Drawing.Point(7, 34);
		this.lblFiltered.Name = "lblFiltered";
		this.lblFiltered.Size = new System.Drawing.Size(141, 24);
		this.lblFiltered.TabIndex = 1;
		this.lblFiltered.Text = "Non Filtered (Sample)";
		//
		//txtGainStatus
		//
		this.txtGainStatus.BackColor = System.Drawing.Color.White;
		this.txtGainStatus.Enabled = false;
		this.txtGainStatus.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtGainStatus.ForeColor = System.Drawing.Color.Blue;
		this.txtGainStatus.Location = new System.Drawing.Point(160, 339);
		this.txtGainStatus.Name = "txtGainStatus";
		this.txtGainStatus.Size = new System.Drawing.Size(80, 26);
		this.txtGainStatus.TabIndex = 18;
		this.txtGainStatus.Text = "";
		this.txtGainStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblGainStatus
		//
		this.lblGainStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblGainStatus.Location = new System.Drawing.Point(160, 311);
		this.lblGainStatus.Name = "lblGainStatus";
		this.lblGainStatus.Size = new System.Drawing.Size(80, 24);
		this.lblGainStatus.TabIndex = 16;
		this.lblGainStatus.Text = "Gain Status";
		//
		//lblMicroStatus
		//
		this.lblMicroStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMicroStatus.Location = new System.Drawing.Point(256, 311);
		this.lblMicroStatus.Name = "lblMicroStatus";
		this.lblMicroStatus.Size = new System.Drawing.Size(80, 24);
		this.lblMicroStatus.TabIndex = 17;
		this.lblMicroStatus.Text = "Micro Status";
		//
		//Panel3
		//
		this.Panel3.Controls.Add(this.mnuAutoIgnition);
		this.Panel3.Location = new System.Drawing.Point(112, 400);
		this.Panel3.Name = "Panel3";
		this.Panel3.Size = new System.Drawing.Size(216, 56);
		this.Panel3.TabIndex = 3;
		//
		//mnuAutoIgnition
		//
		this.mnuAutoIgnition.BackColor = System.Drawing.Color.Transparent;
		this.mnuAutoIgnition.CustomizeText = "&Customize Toolbar...";
		this.mnuAutoIgnition.FullRow = true;
		this.mnuAutoIgnition.ID = 5117;
		this.mnuAutoIgnition.Items.AddRange(new NETXP.Controls.Bars.CommandBarItem[] {
			this.mnuIgnite,
			this.mnuExtinguish
		});
		this.mnuAutoIgnition.Location = new System.Drawing.Point(66, 16);
		this.mnuAutoIgnition.Margins.Bottom = 1;
		this.mnuAutoIgnition.Margins.Left = 1;
		this.mnuAutoIgnition.Margins.Right = 1;
		this.mnuAutoIgnition.Margins.Top = 1;
		this.mnuAutoIgnition.Name = "mnuAutoIgnition";
		this.mnuAutoIgnition.Size = new System.Drawing.Size(112, 23);
		this.mnuAutoIgnition.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.mnuAutoIgnition.TabIndex = 2;
		this.mnuAutoIgnition.TabStop = false;
		this.mnuAutoIgnition.Text = "AutoIgnition";
		//
		//mnuIgnite
		//
		this.mnuIgnite.Text = "Ignite";
		//
		//mnuExtinguish
		//
		this.mnuExtinguish.PadHorizontal = 5;
		this.mnuExtinguish.Text = "Extinguish";
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(219, 179);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 24;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.Transparent;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(231, 179);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 23;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.BackColor = System.Drawing.Color.Transparent;
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(241, 179);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnN2OIgnite.TabIndex = 22;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.BackColor = System.Drawing.Color.Transparent;
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(209, 179);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(8, 8);
		this.btnExtinguish.TabIndex = 21;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.BackColor = System.Drawing.Color.Transparent;
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(225, 179);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnIgnite.TabIndex = 20;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//Timer1
		//
		this.Timer1.Interval = 200;
		//
		//frmAnalogDB
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.ClientSize = new System.Drawing.Size(458, 375);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAnalogDB";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Analog";
		this.CustomPanel1.ResumeLayout(false);
		this.grpBeamType.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		this.Panel1.ResumeLayout(false);
		this.Panel3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Variables"
	private frmEditValues mobjfrmEditValues;
	private int mintValue;
	private  blnFlag = false;
	//Private mblnInProcess As Boolean = False

	private bool mblnStatus = false;
	private bool mblnIsRefBeamType = false;
	private bool mblnADCFilterFlag = false;
	private bool mblnExit = false;
		#End Region
	private bool mblnAvoidProcessing;

	#Region "Constants"
	private const  ConstSetPMT = "PMT volts(0 - 1000)v";
	private const  ConstSetMODE = "Enter Mode";
		#End Region
	private const  constAvgValue = "Avg Value";

	#Region "Properties"
	private int InputValue {
		get { return mintValue; }
		set { mintValue = Value; }
	}
	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmAnalog_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmAnalog_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 22.11.06
		// Revisions             : Deepak on 15.01.07
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			btnADCFilter.Text = "ADC Filter";
			AddHandlers();

			if (gstructSettings.D2Gain == true) {
				txtGainStatus.Text = "ON";
			} else {
				txtGainStatus.Text = "OFF";
			}

			if (gstructSettings.Mesh == true) {
				txtMicroStatus.Text = "ON";
			} else {
				txtMicroStatus.Text = "OFF";
			}
			this.Refresh();

			txtPMT.Text = (int)gobjInst.PmtVoltage;
			txtMode.Text = gobjInst.Mode;
			txtAvgFactor.Text = gobjInst.Average;

			Application.DoEvents();

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
			}
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
frmAnalogDB_Activated(object sender, System.EventArgs e)
	{
		try {
			Timer1.Enabled = true;
			Application.DoEvents();
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

	#End Region

	#Region "Private Functions"

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : SubAddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		try {
			btnClose.Click += btnClose_Click;
			btnADCFilter.Click += btnADCFilter_Click;
			btnAvgValue.Click += btnAvgValue_Click;
			btnSetMode.Click += btnSetMode_Click;
			btnSetPMT.Click += btnSetPMT_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;
			btnExtinguish.Click += btnExtinguish_Click;
			btnIgnite.Click += btnAutoIgnition_Click;
			btnN2OIgnite.Click += btnN2OIgnite_Click;

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

	private void btnOk_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To return to the main screen
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			this.DialogResult = DialogResult.OK;
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
			}
			//---------------------------------------------------------
		}
	}

	private void btnClose_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnClose_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as Close
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 27.11.06
		// Revisions             : 
		//=====================================================================
		try {
			gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam;
			mblnExit = true;
			Timer1.Enabled = false;
			this.DialogResult = DialogResult.Cancel;
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

	private void btnAvgValue_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAvgValue_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To position the Turret at said position from current position 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		int intAvgValue;
		try {
			Timer1.Enabled = false;
			mobjfrmEditValues = new frmEditValues();
			mobjfrmEditValues.LabelText = constAvgValue;
			mobjfrmEditValues.txtValue.Visible = true;

			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.MaxLength = 3;
			mobjfrmEditValues.txtValue.MinimumRange = 1;
			mobjfrmEditValues.txtValue.MaximumRange = 999;
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.SelectAll();

			mobjfrmEditValues.txtValue.Text = gobjInst.Average;
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				Application.DoEvents();
				mobjfrmEditValues.Dispose();
				return;
			}
			Application.DoEvents();
			txtAvgFactor.Text = (int)InputValue;
			txtAvgFactor.Refresh();
			mobjfrmEditValues.Dispose();
			gobjInst.Average = (int)InputValue;

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
			}
			Timer1.Enabled = true;
			//---------------------------------------------------------
		}
	}

	private void btnSetMode_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSetMode_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set instrument mode
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		byte byteSetMode;
		try {
			Timer1.Enabled = false;
			mobjfrmEditValues = new frmEditValues();

			mobjfrmEditValues.LabelText = ConstSetMODE;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.MaxLength = 1;
			mobjfrmEditValues.txtValue.MinimumRange = 0;
			mobjfrmEditValues.txtValue.MaximumRange = 6;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Text = gobjInst.Mode;
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				Application.DoEvents();
				mobjfrmEditValues.Dispose();
				return;
			}
			Application.DoEvents();
			txtMode.Text = (byte)InputValue;
			txtMode.Refresh();
			mobjfrmEditValues.Dispose();
			gobjInst.Mode = (byte)InputValue;
			funcSetMode(gobjInst.Mode);

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
			//mblnInProcess = False
			if (!objWait == null) {
				objWait.Dispose();
			}
			Timer1.Enabled = true;
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	private void btnSetPMT_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSetPMT_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To position the Turret at said position from current position 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : Deepak B. on 15.01.07
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblPMT;
		try {
			Timer1.Enabled = false;
			btnSetPMT.Enabled = false;
			mobjfrmEditValues = new frmEditValues();

			mobjfrmEditValues.LabelText = ConstSetPMT;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.MaxLength = 4;
			mobjfrmEditValues.txtValue.MinimumRange = 0;
			mobjfrmEditValues.txtValue.MaximumRange = 1000;
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.SelectAll();
			if (mblnIsRefBeamType == true) {
				mobjfrmEditValues.txtValue.Text = (int)gobjInst.PmtVoltageReference;
			} else {
				mobjfrmEditValues.txtValue.Text = (int)gobjInst.PmtVoltage;
			}
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				Application.DoEvents();
				mobjfrmEditValues.Dispose();
				return;
			}
			Application.DoEvents();
			dblPMT = (double)InputValue;
			if (dblPMT < 0 | dblPMT > 1000) {
				gobjMessageAdapter.ShowMessage(constPMTRange);
				return;
			}
			txtPMT.Text = (double)InputValue;
			txtPMT.Refresh();
			mobjfrmEditValues.Dispose();
			if (mblnIsRefBeamType == true) {
				gobjInst.PmtVoltageReference = (double)InputValue;
				funcSetPMT_Ref(gobjInst.PmtVoltageReference);
			} else {
				gobjInst.PmtVoltage = (double)InputValue;
				funcSetPMT(gobjInst.PmtVoltage);
			}

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
			}
			btnSetPMT.Enabled = true;
			Timer1.Enabled = true;
			//Application.DoEvents()
			//---------------------------------------------------------
		}
	}

	private void btnADCFilter_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnADCFilter_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To read ADC count for filtered data.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		double dblmv;
		int intAvgFactor;
		try {
			if (mblnADCFilterFlag == true) {
				mblnADCFilterFlag = false;
				btnADCFilter.Text = "ADC Filter";
			} else {
				mblnADCFilterFlag = true;
				btnADCFilter.Text = "ADC Non_Filter";
			}
			funcChangeLabel();

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
			}
			//---------------------------------------------------------
		}
	}

	private void btnAutoIgnition_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAutoIgnition_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;


			mnuIgnite.Click -= btnAutoIgnition_Click;
			Timer1.Enabled = false;
			Application.DoEvents();
			gobjClsAAS203.funcIgnite(true);
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
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
			//mobjController.Start(gobjclsBgFlameStatus)
			Application.DoEvents();
			mnuIgnite.Click += btnAutoIgnition_Click;
			Timer1.Enabled = true;
			//---------------------------------------------------------
		}
	}

	private void btnExtinguish_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 18-Feb-2007 03:15 pm
		// Revisions             : 1
		//=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;

			mnuExtinguish.Click -= btnExtinguish_Click;
			Timer1.Enabled = false;
			gobjClsAAS203.funcIgnite(false);
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
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = True
			//mobjController.Start(gobjclsBgFlameStatus)
			Application.DoEvents();
			mnuExtinguish.Click += btnExtinguish_Click;
			Timer1.Enabled = true;
			//---------------------------------------------------------
		}
	}

	private object funcADCNonFilter(bool blnIsSample)
	{
		//=====================================================================
		// Procedure Name        : funcADCNonFilter
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To show the ADC Non Filter values.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		double dblmv;
		try {
			Timer1.Enabled = false;

			if (blnIsSample == true) {
				if (gobjClsAAS203.funcbtnADCNonFilter(dblmv) == true) {
					txtDEC.Text = (double)dblmv;
					txtHEX.Text = Hex(dblmv);
					txtMv.Text = Format(gFuncGetmv((int)dblmv), "0.00");
				}
			} else {
				if (gobjCommProtocol.funcReadADCFilter_ReferenceBeam(10, dblmv) == true) {
					txtDEC.Text = (double)dblmv;
					txtDEC.Text = Hex(dblmv);
					txtDEC.Text = Format(gFuncGetmv((int)dblmv), "0.00");
				}
			}
			txtDEC.Refresh();
			txtHEX.Refresh();
			txtMv.Refresh();

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
			//objWait.Dispose()
			Timer1.Enabled = true;
			//---------------------------------------------------------
		}
	}

	private object funcADCFilter(bool blnIsSample, int intAverage)
	{
		//=====================================================================
		// Procedure Name        : funcADCFilter
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To show the ADC Filter values.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		double dblmv;
		try {
			Timer1.Enabled = false;

			if (intAverage < 1) {
				return;
			}

			if (blnIsSample == true) {
				if (gobjClsAAS203.funcbtnADCFilter(intAverage, dblmv) == true) {
					txtDEC.Text = (double)dblmv;
					txtMv.Text = Format(gFuncGetmv((int)dblmv), "0.00");
					txtHEX.Text = Hex(dblmv);
				}
			} else {
				if (gobjCommProtocol.funcReadADCFilter_ReferenceBeam(intAverage, dblmv) == true) {
					txtDEC.Text = (double)dblmv;
					txtMv.Text = Format(gFuncGetmv((int)dblmv), "0.00");
					txtHEX.Text = Hex(dblmv);
				}
			}
			txtDEC.Refresh();
			txtHEX.Refresh();
			txtMv.Refresh();

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
			//objWait.Dispose()
			Timer1.Enabled = true;
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mobjfrmEditValues_ReturnValue(double dblValue, int intvalue1)
	{
		//=====================================================================
		// Procedure Name        : mobjfrmEditValues_ReturnValue
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To get the values from EditValues form.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		try {
			InputValue = (long)dblValue;
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

	private object funcSetMode(byte byteSetMode)
	{
		//=====================================================================
		// Procedure Name        : funcSetMode
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the Mode.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			if (mblnIsRefBeamType == true) {
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam;
				if (gobjCommProtocol.funcCalibrationMode(byteSetMode) == true) {
					txtMode.Text = (byte)byteSetMode;
					txtMode.Refresh();
				}
			} else {
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam;
				if (gobjCommProtocol.funcCalibrationMode(byteSetMode) == true) {
					txtMode.Text = (byte)byteSetMode;
					txtMode.Refresh();
				}
			}
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
			objWait.Dispose();
			//---------------------------------------------------------
		}

	}

	private object funcSetPMT(double dblPMT)
	{
		//=====================================================================
		// Procedure Name        : funcSetPMT
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the PMT.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjClsAAS203.funcbtnSet_PMT(dblPMT) == true) {
				txtPMT.Text = (double)dblPMT;
				txtPMT.Refresh();
			}
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
			objWait.Dispose();
			//---------------------------------------------------------
		}

	}

	private object funcSetPMT_Ref(double dblPMT)
	{
		//=====================================================================
		// Procedure Name        : funcSetPMT
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the PMT.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjCommProtocol.funcSet_PMTReferenceBeam(dblPMT) == true) {
				txtPMT.Text = (double)dblPMT;
				txtPMT.Refresh();
			}
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
			objWait.Dispose();
			//---------------------------------------------------------
		}

	}

	private void btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		//    ' Procedure Name        : btnN2OIgnite_Click
		//    ' Parameters Passed     : Object,EventArgs
		//    ' Returns               : None
		//    ' Purpose               : this is calledwhen user clicked on N2O button.
		//    ' Description           : 
		//    ' Assumptions           : 
		//    ' Dependencies          : 
		//    ' Author                : Deepak & Saurabh
		//    ' Created               : 05.10.06
		//    ' Revisions             : 
		//    '=====================================================================
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;


			Timer1.Enabled = false;
			Application.DoEvents();
			gobjMainService.N2OAutoIgnition();
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
			//objWait.Dispose()
			Timer1.Enabled = true;
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
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;


			Timer1.Enabled = false;
			gobjMainService.funcAltDelete();
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
			Timer1.Enabled = true;
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
		if (mblnAvoidProcessing == true) {
			return;
		}
		try {
			mblnAvoidProcessing = true;
			Timer1.Enabled = false;

			gobjMainService.funcAltR();
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
			Timer1.Enabled = true;
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnSample_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		try {
			if (btnSample.Checked == true) {
				//---if sample beam is selected then first 
				//---set reference board to AA mode
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam;
				gobjInst.Mode = EnumCalibrationMode.AA;
				funcSetMode(gobjInst.Mode);
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam;

				mblnIsRefBeamType = false;
				btnSetPMT.Text = "Sample PMT";
			} else {
				//---if ref. beam is selected then first 
				//---set sample board to AA mode
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.SingleBeam;
				gobjInst.Mode = EnumCalibrationMode.AA;
				funcSetMode(gobjInst.Mode);
				gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.ReferenceBeam;

				mblnIsRefBeamType = true;
				btnSetPMT.Text = "Ref. PMT";
			}
			funcChangeLabel();
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

	private object funcChangeLabel()
	{
		try {
			if (mblnADCFilterFlag == true) {
				if (mblnIsRefBeamType == true) {
					lblFiltered.Text = "Filtered (Ref.)";
				} else {
					lblFiltered.Text = "Filtered (Sample)";
				}
			} else {
				if (mblnIsRefBeamType == true) {
					lblFiltered.Text = "Non Filtered (Ref.)";
				} else {
					lblFiltered.Text = "Non Filtered (Sample)";
				}
			}
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

	private object funcGetADCData()
	{
		try {
			if (mblnADCFilterFlag == true) {
				if (mblnIsRefBeamType == true) {
					funcADCFilter(false, gobjInst.Average);
				} else {
					funcADCFilter(true, gobjInst.Average);
				}
			} else {
				if (mblnIsRefBeamType == true) {
					funcADCNonFilter(false);
				} else {
					funcADCNonFilter(true);
				}
			}
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

	private void  // ERROR: Handles clauses are not supported in C#
Timer1_Tick(object sender, System.EventArgs e)
	{
		try {
			funcGetADCData();
			this.txtDEC.Refresh();
			this.txtHEX.Refresh();
			this.txtMv.Refresh();
			Application.DoEvents();
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

	#End Region


}
