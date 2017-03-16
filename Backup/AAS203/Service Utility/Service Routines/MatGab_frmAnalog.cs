using AAS203.Common;

//'this is a class behind the analog form
public class frmAnalog : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmAnalog()
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
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuDelete;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuR;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnExtinguish;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAnalog));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.Panel2 = new System.Windows.Forms.Panel();
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
		this.btnClose = new NETXP.Controls.XPButton();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.lblDEC = new System.Windows.Forms.Label();
		this.lblHEX = new System.Windows.Forms.Label();
		this.lblMV = new System.Windows.Forms.Label();
		this.txtDEC = new System.Windows.Forms.TextBox();
		this.txtHEX = new System.Windows.Forms.TextBox();
		this.txtMv = new System.Windows.Forms.TextBox();
		this.lblFiltered = new System.Windows.Forms.Label();
		this.txtGainStatus = new System.Windows.Forms.TextBox();
		this.lblGainStatus = new System.Windows.Forms.Label();
		this.lblMicroStatus = new System.Windows.Forms.Label();
		this.txtMicroStatus = new System.Windows.Forms.TextBox();
		this.Panel3 = new System.Windows.Forms.Panel();
		this.mnuAutoIgnition = new NETXP.Controls.Bars.CommandBar();
		this.mnuIgnite = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExtinguish = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuDelete = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuR = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.CustomPanel1.SuspendLayout();
		this.Panel2.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.Panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.Panel2);
		this.CustomPanel1.Controls.Add(this.btnClose);
		this.CustomPanel1.Controls.Add(this.Panel1);
		this.CustomPanel1.Controls.Add(this.txtGainStatus);
		this.CustomPanel1.Controls.Add(this.lblGainStatus);
		this.CustomPanel1.Controls.Add(this.lblMicroStatus);
		this.CustomPanel1.Controls.Add(this.txtMicroStatus);
		this.CustomPanel1.Controls.Add(this.Panel3);
		this.CustomPanel1.Controls.Add(this.btnIgnite);
		this.CustomPanel1.Controls.Add(this.btnN2OIgnite);
		this.CustomPanel1.Controls.Add(this.btnExtinguish);
		this.CustomPanel1.Controls.Add(this.btnR);
		this.CustomPanel1.Controls.Add(this.btnDelete);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(458, 359);
		this.CustomPanel1.TabIndex = 0;
		//
		//Panel2
		//
		this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
		this.Panel2.Location = new System.Drawing.Point(16, 104);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(430, 176);
		this.Panel2.TabIndex = 1;
		//
		//txtAvgFactor
		//
		this.txtAvgFactor.BackColor = System.Drawing.Color.White;
		this.txtAvgFactor.Enabled = false;
		this.txtAvgFactor.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtAvgFactor.ForeColor = System.Drawing.Color.Blue;
		this.txtAvgFactor.Location = new System.Drawing.Point(232, 10);
		this.txtAvgFactor.Name = "txtAvgFactor";
		this.txtAvgFactor.Size = new System.Drawing.Size(80, 26);
		this.txtAvgFactor.TabIndex = 20;
		this.txtAvgFactor.Text = "300";
		this.txtAvgFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblAvgFactor
		//
		this.lblAvgFactor.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAvgFactor.Location = new System.Drawing.Point(152, 16);
		this.lblAvgFactor.Name = "lblAvgFactor";
		this.lblAvgFactor.Size = new System.Drawing.Size(80, 18);
		this.lblAvgFactor.TabIndex = 19;
		this.lblAvgFactor.Text = "Avg Factor";
		//
		//Label2
		//
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.ForeColor = System.Drawing.SystemColors.ControlDark;
		this.Label2.Location = new System.Drawing.Point(8, 64);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(84, 16);
		this.Label2.TabIndex = 18;
		this.Label2.Text = "(0-1000 Volts)";
		//
		//txtPMT
		//
		this.txtPMT.BackColor = System.Drawing.Color.White;
		this.txtPMT.Enabled = false;
		this.txtPMT.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtPMT.ForeColor = System.Drawing.Color.Blue;
		this.txtPMT.Location = new System.Drawing.Point(98, 48);
		this.txtPMT.Name = "txtPMT";
		this.txtPMT.Size = new System.Drawing.Size(80, 26);
		this.txtPMT.TabIndex = 17;
		this.txtPMT.Text = "0";
		this.txtPMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblPMT
		//
		this.lblPMT.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblPMT.Location = new System.Drawing.Point(8, 48);
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
		this.txtMode.Location = new System.Drawing.Point(64, 10);
		this.txtMode.Name = "txtMode";
		this.txtMode.Size = new System.Drawing.Size(80, 26);
		this.txtMode.TabIndex = 15;
		this.txtMode.Text = "6";
		this.txtMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblMode
		//
		this.lblMode.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMode.Location = new System.Drawing.Point(8, 16);
		this.lblMode.Name = "lblMode";
		this.lblMode.Size = new System.Drawing.Size(54, 16);
		this.lblMode.TabIndex = 14;
		this.lblMode.Text = "Mode";
		//
		//btnAvgValue
		//
		this.btnAvgValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAvgValue.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAvgValue.Image = (System.Drawing.Image)resources.GetObject("btnAvgValue.Image");
		this.btnAvgValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAvgValue.Location = new System.Drawing.Point(174, 128);
		this.btnAvgValue.Name = "btnAvgValue";
		this.btnAvgValue.Size = new System.Drawing.Size(126, 32);
		this.btnAvgValue.TabIndex = 3;
		this.btnAvgValue.Text = "&Avg Value";
		//
		//btnSetMode
		//
		this.btnSetMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetMode.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetMode.Image = (System.Drawing.Image)resources.GetObject("btnSetMode.Image");
		this.btnSetMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetMode.Location = new System.Drawing.Point(40, 88);
		this.btnSetMode.Name = "btnSetMode";
		this.btnSetMode.Size = new System.Drawing.Size(126, 32);
		this.btnSetMode.TabIndex = 0;
		this.btnSetMode.Text = "Set &Mode";
		//
		//btnSetPMT
		//
		this.btnSetPMT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSetPMT.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSetPMT.Image = (System.Drawing.Image)resources.GetObject("btnSetPMT.Image");
		this.btnSetPMT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSetPMT.Location = new System.Drawing.Point(40, 128);
		this.btnSetPMT.Name = "btnSetPMT";
		this.btnSetPMT.Size = new System.Drawing.Size(126, 32);
		this.btnSetPMT.TabIndex = 2;
		this.btnSetPMT.Text = "Set &PMT";
		//
		//TextBox1
		//
		this.TextBox1.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox1.Enabled = false;
		this.TextBox1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.TextBox1.Location = new System.Drawing.Point(320, 5);
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
		this.btnADCFilter.Location = new System.Drawing.Point(174, 88);
		this.btnADCFilter.Name = "btnADCFilter";
		this.btnADCFilter.Size = new System.Drawing.Size(126, 32);
		this.btnADCFilter.TabIndex = 1;
		this.btnADCFilter.Text = "ADC Non&Filter";
		this.btnADCFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnClose
		//
		this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClose.Location = new System.Drawing.Point(325, 312);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(120, 32);
		this.btnClose.TabIndex = 0;
		this.btnClose.Text = "C&LOSE";
		//
		//Panel1
		//
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Panel1.Controls.Add(this.lblDEC);
		this.Panel1.Controls.Add(this.lblHEX);
		this.Panel1.Controls.Add(this.lblMV);
		this.Panel1.Controls.Add(this.txtDEC);
		this.Panel1.Controls.Add(this.txtHEX);
		this.Panel1.Controls.Add(this.txtMv);
		this.Panel1.Controls.Add(this.lblFiltered);
		this.Panel1.Location = new System.Drawing.Point(16, 8);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(430, 88);
		this.Panel1.TabIndex = 0;
		//
		//lblDEC
		//
		this.lblDEC.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblDEC.Location = new System.Drawing.Point(328, 16);
		this.lblDEC.Name = "lblDEC";
		this.lblDEC.Size = new System.Drawing.Size(32, 22);
		this.lblDEC.TabIndex = 7;
		this.lblDEC.Text = "dec";
		//
		//lblHEX
		//
		this.lblHEX.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHEX.Location = new System.Drawing.Point(224, 16);
		this.lblHEX.Name = "lblHEX";
		this.lblHEX.Size = new System.Drawing.Size(32, 16);
		this.lblHEX.TabIndex = 6;
		this.lblHEX.Text = "hex";
		//
		//lblMV
		//
		this.lblMV.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMV.Location = new System.Drawing.Point(112, 16);
		this.lblMV.Name = "lblMV";
		this.lblMV.Size = new System.Drawing.Size(32, 24);
		this.lblMV.TabIndex = 5;
		this.lblMV.Text = "mv";
		//
		//txtDEC
		//
		this.txtDEC.BackColor = System.Drawing.Color.White;
		this.txtDEC.Enabled = false;
		this.txtDEC.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtDEC.Location = new System.Drawing.Point(328, 40);
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
		this.txtHEX.Location = new System.Drawing.Point(224, 40);
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
		this.txtMv.Location = new System.Drawing.Point(112, 40);
		this.txtMv.Name = "txtMv";
		this.txtMv.ReadOnly = true;
		this.txtMv.Size = new System.Drawing.Size(80, 26);
		this.txtMv.TabIndex = 2;
		this.txtMv.Text = "";
		this.txtMv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblFiltered
		//
		this.lblFiltered.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblFiltered.Location = new System.Drawing.Point(0, 40);
		this.lblFiltered.Name = "lblFiltered";
		this.lblFiltered.Size = new System.Drawing.Size(104, 24);
		this.lblFiltered.TabIndex = 1;
		this.lblFiltered.Text = "non filtered";
		//
		//txtGainStatus
		//
		this.txtGainStatus.BackColor = System.Drawing.Color.White;
		this.txtGainStatus.Enabled = false;
		this.txtGainStatus.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtGainStatus.ForeColor = System.Drawing.Color.Blue;
		this.txtGainStatus.Location = new System.Drawing.Point(32, 328);
		this.txtGainStatus.Name = "txtGainStatus";
		this.txtGainStatus.Size = new System.Drawing.Size(80, 26);
		this.txtGainStatus.TabIndex = 18;
		this.txtGainStatus.Text = "";
		this.txtGainStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblGainStatus
		//
		this.lblGainStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblGainStatus.Location = new System.Drawing.Point(32, 307);
		this.lblGainStatus.Name = "lblGainStatus";
		this.lblGainStatus.Size = new System.Drawing.Size(88, 24);
		this.lblGainStatus.TabIndex = 16;
		this.lblGainStatus.Text = "Gain Status";
		//
		//lblMicroStatus
		//
		this.lblMicroStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblMicroStatus.Location = new System.Drawing.Point(152, 307);
		this.lblMicroStatus.Name = "lblMicroStatus";
		this.lblMicroStatus.Size = new System.Drawing.Size(96, 21);
		this.lblMicroStatus.TabIndex = 17;
		this.lblMicroStatus.Text = "Micro Status";
		//
		//txtMicroStatus
		//
		this.txtMicroStatus.BackColor = System.Drawing.Color.White;
		this.txtMicroStatus.Enabled = false;
		this.txtMicroStatus.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtMicroStatus.ForeColor = System.Drawing.Color.Blue;
		this.txtMicroStatus.Location = new System.Drawing.Point(152, 328);
		this.txtMicroStatus.Name = "txtMicroStatus";
		this.txtMicroStatus.Size = new System.Drawing.Size(80, 26);
		this.txtMicroStatus.TabIndex = 19;
		this.txtMicroStatus.Text = "";
		this.txtMicroStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//Panel3
		//
		this.Panel3.Controls.Add(this.mnuAutoIgnition);
		this.Panel3.Location = new System.Drawing.Point(96, 400);
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
			this.mnuExtinguish,
			this.mnuDelete,
			this.mnuR
		});
		this.mnuAutoIgnition.Location = new System.Drawing.Point(66, 16);
		this.mnuAutoIgnition.Margins.Bottom = 1;
		this.mnuAutoIgnition.Margins.Left = 1;
		this.mnuAutoIgnition.Margins.Right = 1;
		this.mnuAutoIgnition.Margins.Top = 1;
		this.mnuAutoIgnition.Name = "mnuAutoIgnition";
		this.mnuAutoIgnition.Size = new System.Drawing.Size(112, 43);
		this.mnuAutoIgnition.Style = NETXP.Controls.Bars.CommandBarStyle.Menu;
		this.mnuAutoIgnition.TabIndex = 2;
		this.mnuAutoIgnition.TabStop = false;
		this.mnuAutoIgnition.Text = "AutoIgnition";
		//
		//mnuIgnite
		//
		this.mnuIgnite.Text = "&Ignite";
		//
		//mnuExtinguish
		//
		this.mnuExtinguish.PadHorizontal = 5;
		this.mnuExtinguish.Text = "&Extinguish";
		//
		//mnuDelete
		//
		this.mnuDelete.Text = "&Delete";
		//
		//mnuR
		//
		this.mnuR.Text = "&R";
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
		this.btnIgnite.TabIndex = 25;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
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
		this.btnN2OIgnite.TabIndex = 27;
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
		this.btnExtinguish.TabIndex = 26;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.Transparent;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(336, 416);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 23;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(320, 416);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 24;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//frmAnalog
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnClose;
		this.ClientSize = new System.Drawing.Size(458, 359);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAnalog";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Analog";
		this.CustomPanel1.ResumeLayout(false);
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
	private  mblnFlag = false;
	private bool mblnADCFlag;
	private bool mblnInProcess = false;
		#End Region
	private bool mblnStatus = false;

	#Region "Constants"
	private const  ConstSetPMT = "PMT volts(0 - 1000)v";
	private const  ConstSetMODE = "Enter Mode";

	private const  constAvgValue = "Avg Value";
	private enum EnumOperation
	{
		OperationNo = 0,
		OperationMode = 1,
		OperationPMT = 2,
		OperationAvgValue = 3,
		OperationExit = 4
	}
	private EnumOperation m_Operation = EnumOperation.OperationNo;
		//by pankaj on 16.1.08
	private EnumOperation m_OperationExit = EnumOperation.OperationNo;

	#End Region

	#Region "Properties"
	private int InputValue {
		//'this is a property for temp storing a inputvalue

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

		//'this is called when the analog form is loaded
		//'add all, the event handler here
		//'initialize the form


		CWaitCursor objWait = new CWaitCursor();
		double dblmv;
		try {
			//If gobjCommProtocol.funcReadADCNonFilter(dblmv) = True Then
			//mblnStatus = True
			mblnADCFlag = true;
			btnADCFilter.Text = "ADC &Filter";
			AddHandlers();
			//'for adding a eventhandler

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
			btnSetMode.Focus();
			txtPMT.Text = (int)gobjInst.PmtVoltage;
			//'get a pmt voltage from gobjInst object to text box
			txtMode.Text = gobjInst.Mode;
			txtAvgFactor.Text = gobjInst.Average;
			Application.DoEvents();
		//Else
		//   Me.Close()
		//End If


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
			//'note:
			//'this is used for adding event handler


			//AddHandler btnOk.Click, AddressOf btnOk_Click
			btnClose.Click += btnClose_Click;
			btnADCFilter.Click += btnADCFilter_Click;
			//AddHandler btnADCNonFilter.Click, AddressOf btnADCNonFilter_Click
			btnAvgValue.Click += btnAvgValue_Click;
			btnSetMode.Click += btnSetMode_Click;
			btnSetPMT.Click += btnSetPMT_Click;
			base.Activated += frmAnalog_Activated;
			//AddHandler mnuExtinguish.Click, AddressOf btnExtinguish_Click
			//AddHandler mnuIgnite.Click, AddressOf btnAutoIgnition_Click
			btnExtinguish.Click += btnExtinguish_Click;
			btnIgnite.Click += btnAutoIgnition_Click;
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

		//'this is called when user  click on OK button
		//'this handle the OK button event


		CWaitCursor objWait = new CWaitCursor();
		try {
			//If gblnInComm = False Then
			this.DialogResult = DialogResult.OK;
		//End If
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


		//'note:
		//'this is called when click on cancel button 

		try {
			//blnFlag = True
			m_Operation = EnumOperation.OperationExit;
			m_OperationExit = EnumOperation.OperationExit;
			this.DialogResult = DialogResult.Cancel;
		//Application.DoEvents()

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

	//Private Sub btnADCNonFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
	//    '=====================================================================
	//    ' Procedure Name        : btnADCNonFilter_Click
	//    ' Parameters Passed     : Object,EventArgs
	//    ' Returns               : None
	//    ' Purpose               : To position the Turret at said position from current position 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Saurabh S
	//    ' Created               : 21.11.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim objWait As New CWaitCursor
	//    Dim dblmv As Double
	//    Dim intAvgFactor As Integer
	//    Try
	//        If blnADCFlag = True Then
	//            lblFiltered.Text = "filtered"
	//            blnFlag = True
	//            Application.DoEvents()

	//            If txtAvgFactor.Text = "" Then
	//                gobjMessageAdapter.ShowMessage(constInputProperData)
	//                Application.DoEvents()
	//            Else
	//                intAvgFactor = CInt(txtAvgFactor.Text)
	//                Application.DoEvents()
	//                If gobjClsAAS203.funcbtnADCFilter(intAvgFactor, dblmv) = True Then
	//                    txtDEC.Text = CDbl(dblmv)
	//                    txtMv.Text = gFuncGetmv(CInt(dblmv))
	//                    txtHEX.Text = Hex(dblmv)
	//                    Application.DoEvents()
	//                End If
	//            End If
	//            blnADCFlag = False
	//        Else
	//            lblFiltered.Text = "non filtered"
	//            Do
	//                Call funcADCNonFilter()
	//                If blnFlag = True Then
	//                    Exit Do
	//                End If
	//                Application.DoEvents()
	//            Loop
	//            blnADCFlag = True
	//        End If

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not objWait Is Nothing Then
	//            objWait.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Sub

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

		//'note:
		//'this is called when user click on Avg Value button
		//'step 1: first show the edit value for input
		//'step 2: take a input in to a variable and validate it
		//'step 3: after validation ,if validation is succes then store it in gobjInst.Average object 
		//'else through error




		CWaitCursor objWait = new CWaitCursor();
		int intAvgValue;
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			mblnFlag = true;
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

			///Added by praveen for validation
			//If IsNumeric(mobjfrmEditValues.txtValue.Text) Then
			//    InputValue = mobjfrmEditValues.txtValue.Text
			//    If InputValue < mobjfrmEditValues.txtValue.MinimumRange Then
			//        InputValue = mobjfrmEditValues.txtValue.MinimumRange
			//    ElseIf InputValue > mobjfrmEditValues.txtValue.MaximumRange Then
			//        InputValue = mobjfrmEditValues.txtValue.MaximumRange
			//    Else
			//        InputValue = mobjfrmEditValues.txtValue.Text
			//    End If
			//Else
			//    InputValue = mobjfrmEditValues.txtValue.MinimumRange
			//End If
			///Ended by praveen
			Application.DoEvents();
			txtAvgFactor.Text = (int)InputValue;
			txtAvgFactor.Refresh();
			mobjfrmEditValues.Dispose();
			gobjInst.Average = (int)InputValue;
		//m_Operation = EnumOperation.OperationAvgValue

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
			mblnInProcess = false;
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
		//'note:
		//'this is called when user click on Set mode button
		//'step 1: first show the edit value for input
		//'step 2: take a input in to a variable and validate it
		//'step 3: after validation ,if validation is succes then store it in gobjInst.Average object 
		//'else through error

		//'as par the list of mode send a int value



		CWaitCursor objWait = new CWaitCursor();
		byte byteSetMode;
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			mblnFlag = true;
			mobjfrmEditValues = new frmEditValues();
			// Application.DoEvents()

			mobjfrmEditValues.LabelText = ConstSetMODE;
			mobjfrmEditValues.txtValue.Visible = true;

			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;

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
			///Added by praveen for validation
			//If IsNumeric(mobjfrmEditValues.txtValue.Text) Then
			//    InputValue = mobjfrmEditValues.txtValue.Text
			//    If InputValue < mobjfrmEditValues.txtValue.MinimumRange Then
			//        InputValue = mobjfrmEditValues.txtValue.MinimumRange
			//    ElseIf InputValue > mobjfrmEditValues.txtValue.MaximumRange Then
			//        InputValue = mobjfrmEditValues.txtValue.MaximumRange
			//    Else
			//        InputValue = mobjfrmEditValues.txtValue.Text
			//    End If
			//Else
			//    InputValue = mobjfrmEditValues.txtValue.MinimumRange
			//End If
			///Ended by praveen


			Application.DoEvents();
			txtMode.Text = (byte)InputValue;
			txtMode.Refresh();
			mobjfrmEditValues.Dispose();
			gobjInst.Mode = (byte)InputValue;
			m_Operation = EnumOperation.OperationMode;


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
			mblnInProcess = false;
			if (!objWait == null) {
				objWait.Dispose();
			}
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
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : Deepak B. on 15.01.07
		//=====================================================================
		//'note:
		//'this is called when user click on set PMT button
		//'step 1: first show the edit value for input
		//'step 2: take a input in to a variable and validate it
		//'step 3: after validation ,if validation is succes then store it in gobjInst.Average object 
		//'else through error



		CWaitCursor objWait = new CWaitCursor();
		double dblPMT;
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			mblnFlag = true;
			mobjfrmEditValues = new frmEditValues();
			// Application.DoEvents()

			mobjfrmEditValues.LabelText = ConstSetPMT;
			mobjfrmEditValues.txtValue.Visible = true;

			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.MaxLength = 4;
			mobjfrmEditValues.txtValue.MinimumRange = 0;
			mobjfrmEditValues.txtValue.MaximumRange = 1000;
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Text = (int)gobjInst.PmtVoltage;
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				Application.DoEvents();
				mobjfrmEditValues.Dispose();
				return;
			}
			///Adeed by praveen
			//If IsNumeric(mobjfrmEditValues.txtValue.Text) Then
			//    InputValue = mobjfrmEditValues.txtValue.Text
			//    If InputValue < mobjfrmEditValues.txtValue.MinimumRange Then
			//        InputValue = mobjfrmEditValues.txtValue.MinimumRange
			//    ElseIf InputValue > mobjfrmEditValues.txtValue.MaximumRange Then
			//        InputValue = mobjfrmEditValues.txtValue.MaximumRange
			//    Else
			//        InputValue = mobjfrmEditValues.txtValue.Text
			//    End If
			//Else
			//    InputValue = mobjfrmEditValues.txtValue.MinimumRange
			//End If
			///Ended by praveen
			Application.DoEvents();
			dblPMT = (double)InputValue;
			if (dblPMT < 0 | dblPMT > 1000) {
				gobjMessageAdapter.ShowMessage(constPMTRange);
				//MsgBox("PMT value should be between 0 and 1000")
				return;
			}
			txtPMT.Text = (double)InputValue;
			txtPMT.Refresh();
			mobjfrmEditValues.Dispose();
			gobjInst.PmtVoltage = (double)InputValue;
			m_Operation = EnumOperation.OperationPMT;

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
			mblnInProcess = false;
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

		//'note:
		//'this is called when user clicked on ADC filter button
		//'mblnADCFlag is a bool flag which later used in a software
		//'and mblnADCFlag is true


		CWaitCursor objWait = new CWaitCursor();
		double dblmv;
		int intAvgFactor;
		try {
			if (mblnADCFlag == true) {
				//'and mblnADCFlag is true then
				lblFiltered.Text = "Filtered";
				btnADCFilter.Text = "ADC &NonFilter";
				//blnFlag = True
				mblnADCFlag = false;

			} else {
				//else
				lblFiltered.Text = "Non Filtered";
				btnADCFilter.Text = "ADC &Filter";

				mblnADCFlag = true;
				//Application.DoEvents()
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
		//'note:
		//'this is called when user click on AutoIgnition button


		try {
			mnuIgnite.Click -= btnAutoIgnition_Click;
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
			// mobjController.Cancel()
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(true);
			mblnInProcess = false;
		///function for auto ignition 
		//'here we are sending True in parameter fpr ignition ON.


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
			//mblnInProcess = False
			Application.DoEvents();
			mnuIgnite.Click += btnAutoIgnition_Click;
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
		//'this is used for putting ignition off
		try {
			mnuExtinguish.Click -= btnExtinguish_Click;
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
			//mobjController.Cancel()
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(false);
			mblnInProcess = false;
		//'here we sre passing False for ignition OFF.

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
			//mblnInProcess = False
			mnuExtinguish.Click += btnExtinguish_Click;
			//---------------------------------------------------------
		}
	}

	private object funcADCNonFilter()
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
		//Dim objWait As New CWaitCursor
		double dblmv;
		try {
			if (mblnInProcess == true) {
				return;
			}
			if (gobjClsAAS203.funcbtnADCNonFilter(dblmv) == true) {
				//'To get the value of ADC Non Filter.
				txtDEC.Text = (double)dblmv;
				txtHEX.Text = Hex(dblmv);
				txtMv.Text = Format(gFuncGetmv((int)dblmv), "0.00");
				txtDEC.Refresh();
				txtHEX.Refresh();
				txtMv.Refresh();
				//Application.DoEvents()
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
			//objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private object funcADCFilter()
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
		//Dim objWait As New CWaitCursor
		double dblmv;
		int intAvgFactor;
		try {
			if (mblnInProcess == true) {
				return;
			}
			intAvgFactor = (int)txtAvgFactor.Text;
			if (intAvgFactor < 1) {
				return;
			}
			if (gobjClsAAS203.funcbtnADCFilter(intAvgFactor, dblmv) == true) {
				//'To get the value of ADC Non Filter.
				txtDEC.Text = (double)dblmv;
				txtMv.Text = Format(gFuncGetmv((int)dblmv), "0.00");
				txtHEX.Text = Hex(dblmv);
				txtDEC.Refresh();
				txtHEX.Refresh();
				txtMv.Refresh();
				//Application.DoEvents()
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
			//objWait.Dispose()
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
		//'this is called for accepting the value form Edit form

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

	private void frmAnalog_Activated(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmAnalog_Activated
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To show the ADC values on form load.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 23.01.07
		// Revisions             : 
		//=====================================================================
		//Dim objWait As CWaitCursor
		//'this is called during the loading of a form
		//'this will show some initial value on screen
		double dblmv;
		try {
			//If mblnStatus = True Then
			if (gobjCommProtocol.funcReadADCNonFilter(dblmv) == true) {
				base.Activated -= frmAnalog_Activated;
				do {
					if (gblnInComm == false) {
						//by pankaj on 16.1.08
						if (m_OperationExit == EnumOperation.OperationExit) {
							break; // TODO: might not be correct. Was : Exit Do
						}
						switch (m_Operation) {
							case EnumOperation.OperationMode:
								//objWait = New CWaitCursor
								funcSetMode((byte)InputValue);
							case EnumOperation.OperationPMT:
								//objWait = New CWaitCursor
								funcSetPMT((double)InputValue);
							case EnumOperation.OperationNo:
								if (mblnADCFlag == true) {
									funcADCNonFilter();
								} else {
									funcADCFilter();
								}
							case EnumOperation.OperationExit:
								//objWait = New CWaitCursor

								break; // TODO: might not be correct. Was : Exit Do

						}
					}
					mblnInProcess = false;
					m_Operation = EnumOperation.OperationNo;
					//If Not objWait Is Nothing Then
					//    objWait.Dispose()
					//End If
					gobjCommProtocol.mobjCommdll.subTime_Delay(100);
					Application.DoEvents();
				} while (true);
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			} else {
				this.DialogResult = DialogResult.Cancel;
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
			//objWait.Dispose()
			Application.DoEvents();
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
		//'note:
		//this is used for setting a given mode to the instrument

		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjClsAAS203.funcbtnSetMode(byteSetMode) == true) {
				//'function for setting a mode to instrument 
				//'here we have to pass the mode to be selected
				txtMode.Text = (byte)byteSetMode;
				txtMode.Refresh();
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
		//'note:
		//this is used for setting the PMT to the instrument

		CWaitCursor objWait = new CWaitCursor();
		try {
			if (gobjClsAAS203.funcbtnSet_PMT(dblPMT) == true) {
				//'function used ofr setting the PMT value
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
		if (mblnInProcess == true) {
			return;
		}

		try {
			mblnInProcess = true;
			gobjMainService.N2OAutoIgnition();
			mblnInProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnInProcess = false;
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
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			Application.DoEvents();
			gobjMainService.funcAltDelete();
			mblnInProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnInProcess = false;
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
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			Application.DoEvents();
			//Alt - R
			gobjMainService.funcAltR();
			mblnInProcess = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnInProcess = false;
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
