using AAS203.Common;

public class frmMonochromator : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmMonochromator()
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
	internal NETXP.Controls.XPButton btnOk;
	internal GradientPanel.CustomPanel CustomPanel1;
	internal System.Windows.Forms.Label label1;
	internal System.Windows.Forms.Label label2;
	internal System.Windows.Forms.Label label3;
	internal System.Windows.Forms.Label label4;
	internal System.Windows.Forms.Label label5;
	internal System.Windows.Forms.TextBox textbox2;
	internal System.Windows.Forms.TextBox textbox3;
	internal System.Windows.Forms.TextBox textbox4;
	internal System.Windows.Forms.TextBox textbox5;
	internal System.Windows.Forms.TabControl TabControl1;
	internal System.Windows.Forms.TabPage TabPage1;
	internal System.Windows.Forms.TabPage TabPage2;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal System.Windows.Forms.TextBox txtWvRepeats;
	internal System.Windows.Forms.TextBox txtWvPosition;
	internal System.Windows.Forms.Label lblWvHome;
	internal System.Windows.Forms.TextBox txtWvHome;
	internal System.Windows.Forms.Label lblWvRepeats;
	internal System.Windows.Forms.Label lblWvPosition;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.NumericUpDown nudSlitWidth;
	internal System.Windows.Forms.TextBox txtSlitHome;
	internal System.Windows.Forms.Label lblSlitHome;
	internal System.Windows.Forms.TextBox txtSlitRepeats;
	internal System.Windows.Forms.Label lblSlitRepeats;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.Label Label8;
	internal System.Windows.Forms.Button Button1;
	internal NETXP.Controls.XPButton btnSlitHome;
	internal NETXP.Controls.XPButton btnSlitWidth;
	internal NETXP.Controls.XPButton btnSlitContinious;
	internal NETXP.Controls.XPButton btnWvPosition;
	internal NETXP.Controls.XPButton btnWvRepeats;
	internal NETXP.Controls.XPButton btnWvHome;
	internal System.Windows.Forms.Label lblWvRec;
	internal System.Windows.Forms.TextBox txtSlitWidth;
	internal System.Windows.Forms.Panel Panel1;
	internal NETXP.Controls.Bars.CommandBar mnuAutoIgnition;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuIgnite;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnDelete;

	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMonochromator));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.mnuAutoIgnition = new NETXP.Controls.Bars.CommandBar();
		this.mnuIgnite = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExtinguish = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.txtSlitWidth = new System.Windows.Forms.TextBox();
		this.lblWvRec = new System.Windows.Forms.Label();
		this.btnWvPosition = new NETXP.Controls.XPButton();
		this.btnWvRepeats = new NETXP.Controls.XPButton();
		this.btnWvHome = new NETXP.Controls.XPButton();
		this.btnSlitHome = new NETXP.Controls.XPButton();
		this.btnSlitWidth = new NETXP.Controls.XPButton();
		this.btnSlitContinious = new NETXP.Controls.XPButton();
		this.Button1 = new System.Windows.Forms.Button();
		this.Label8 = new System.Windows.Forms.Label();
		this.nudSlitWidth = new System.Windows.Forms.NumericUpDown();
		this.txtSlitHome = new System.Windows.Forms.TextBox();
		this.lblSlitHome = new System.Windows.Forms.Label();
		this.txtSlitRepeats = new System.Windows.Forms.TextBox();
		this.lblSlitRepeats = new System.Windows.Forms.Label();
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.txtWvRepeats = new System.Windows.Forms.TextBox();
		this.txtWvPosition = new System.Windows.Forms.TextBox();
		this.lblWvHome = new System.Windows.Forms.Label();
		this.txtWvHome = new System.Windows.Forms.TextBox();
		this.lblWvRepeats = new System.Windows.Forms.Label();
		this.lblWvPosition = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.btnOk = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanel2.SuspendLayout();
		this.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nudSlitWidth).BeginInit();
		this.TabControl1.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.SystemColors.Control;
		this.CustomPanel1.Controls.Add(this.CustomPanel2);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(506, 327);
		this.CustomPanel1.TabIndex = 0;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel2.Controls.Add(this.Panel1);
		this.CustomPanel2.Controls.Add(this.txtSlitWidth);
		this.CustomPanel2.Controls.Add(this.lblWvRec);
		this.CustomPanel2.Controls.Add(this.btnWvPosition);
		this.CustomPanel2.Controls.Add(this.btnWvRepeats);
		this.CustomPanel2.Controls.Add(this.btnWvHome);
		this.CustomPanel2.Controls.Add(this.btnSlitHome);
		this.CustomPanel2.Controls.Add(this.btnSlitWidth);
		this.CustomPanel2.Controls.Add(this.btnSlitContinious);
		this.CustomPanel2.Controls.Add(this.Button1);
		this.CustomPanel2.Controls.Add(this.Label8);
		this.CustomPanel2.Controls.Add(this.nudSlitWidth);
		this.CustomPanel2.Controls.Add(this.txtSlitHome);
		this.CustomPanel2.Controls.Add(this.lblSlitHome);
		this.CustomPanel2.Controls.Add(this.txtSlitRepeats);
		this.CustomPanel2.Controls.Add(this.lblSlitRepeats);
		this.CustomPanel2.Controls.Add(this.lblSlitWidth);
		this.CustomPanel2.Controls.Add(this.Label7);
		this.CustomPanel2.Controls.Add(this.txtWvRepeats);
		this.CustomPanel2.Controls.Add(this.txtWvPosition);
		this.CustomPanel2.Controls.Add(this.lblWvHome);
		this.CustomPanel2.Controls.Add(this.txtWvHome);
		this.CustomPanel2.Controls.Add(this.lblWvRepeats);
		this.CustomPanel2.Controls.Add(this.lblWvPosition);
		this.CustomPanel2.Controls.Add(this.Label6);
		this.CustomPanel2.Controls.Add(this.TabControl1);
		this.CustomPanel2.Controls.Add(this.btnOk);
		this.CustomPanel2.Controls.Add(this.btnIgnite);
		this.CustomPanel2.Controls.Add(this.btnN2OIgnite);
		this.CustomPanel2.Controls.Add(this.btnExtinguish);
		this.CustomPanel2.Controls.Add(this.btnDelete);
		this.CustomPanel2.Controls.Add(this.btnR);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(506, 327);
		this.CustomPanel2.TabIndex = 13;
		//
		//Panel1
		//
		this.Panel1.Controls.Add(this.mnuAutoIgnition);
		this.Panel1.Location = new System.Drawing.Point(136, 320);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(216, 56);
		this.Panel1.TabIndex = 44;
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
		this.mnuIgnite.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
		this.mnuIgnite.Text = "Ignite";
		//
		//mnuExtinguish
		//
		this.mnuExtinguish.PadHorizontal = 5;
		this.mnuExtinguish.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
		this.mnuExtinguish.Text = "Extinguish";
		//
		//txtSlitWidth
		//
		this.txtSlitWidth.BackColor = System.Drawing.Color.WhiteSmoke;
		this.txtSlitWidth.Enabled = false;
		this.txtSlitWidth.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtSlitWidth.ForeColor = System.Drawing.Color.Black;
		this.txtSlitWidth.Location = new System.Drawing.Point(400, 56);
		this.txtSlitWidth.Name = "txtSlitWidth";
		this.txtSlitWidth.ReadOnly = true;
		this.txtSlitWidth.Size = new System.Drawing.Size(80, 22);
		this.txtSlitWidth.TabIndex = 43;
		this.txtSlitWidth.Text = "2.0";
		this.txtSlitWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblWvRec
		//
		this.lblWvRec.Enabled = false;
		this.lblWvRec.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWvRec.ForeColor = System.Drawing.Color.DodgerBlue;
		this.lblWvRec.Location = new System.Drawing.Point(64, 241);
		this.lblWvRec.Name = "lblWvRec";
		this.lblWvRec.Size = new System.Drawing.Size(248, 24);
		this.lblWvRec.TabIndex = 41;
		this.lblWvRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//
		//btnWvPosition
		//
		this.btnWvPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnWvPosition.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnWvPosition.Image = (System.Drawing.Image)resources.GetObject("btnWvPosition.Image");
		this.btnWvPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnWvPosition.Location = new System.Drawing.Point(208, 154);
		this.btnWvPosition.Name = "btnWvPosition";
		this.btnWvPosition.Size = new System.Drawing.Size(110, 38);
		this.btnWvPosition.TabIndex = 1;
		this.btnWvPosition.Text = "Wv Position";
		this.btnWvPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnWvRepeats
		//
		this.btnWvRepeats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnWvRepeats.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnWvRepeats.Image = (System.Drawing.Image)resources.GetObject("btnWvRepeats.Image");
		this.btnWvRepeats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnWvRepeats.Location = new System.Drawing.Point(336, 154);
		this.btnWvRepeats.Name = "btnWvRepeats";
		this.btnWvRepeats.Size = new System.Drawing.Size(110, 38);
		this.btnWvRepeats.TabIndex = 2;
		this.btnWvRepeats.Text = "Wv Repeats";
		this.btnWvRepeats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnWvHome
		//
		this.btnWvHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnWvHome.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnWvHome.Image = (System.Drawing.Image)resources.GetObject("btnWvHome.Image");
		this.btnWvHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnWvHome.Location = new System.Drawing.Point(80, 154);
		this.btnWvHome.Name = "btnWvHome";
		this.btnWvHome.Size = new System.Drawing.Size(110, 38);
		this.btnWvHome.TabIndex = 0;
		this.btnWvHome.Text = "Wv Home";
		this.btnWvHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnSlitHome
		//
		this.btnSlitHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSlitHome.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSlitHome.Image = (System.Drawing.Image)resources.GetObject("btnSlitHome.Image");
		this.btnSlitHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSlitHome.Location = new System.Drawing.Point(80, 197);
		this.btnSlitHome.Name = "btnSlitHome";
		this.btnSlitHome.Size = new System.Drawing.Size(110, 38);
		this.btnSlitHome.TabIndex = 3;
		this.btnSlitHome.Text = "Slit Home";
		this.btnSlitHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnSlitWidth
		//
		this.btnSlitWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSlitWidth.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSlitWidth.Image = (System.Drawing.Image)resources.GetObject("btnSlitWidth.Image");
		this.btnSlitWidth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSlitWidth.Location = new System.Drawing.Point(208, 197);
		this.btnSlitWidth.Name = "btnSlitWidth";
		this.btnSlitWidth.Size = new System.Drawing.Size(110, 38);
		this.btnSlitWidth.TabIndex = 4;
		this.btnSlitWidth.Text = "Slit Width";
		this.btnSlitWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnSlitContinious
		//
		this.btnSlitContinious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSlitContinious.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSlitContinious.Image = (System.Drawing.Image)resources.GetObject("btnSlitContinious.Image");
		this.btnSlitContinious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSlitContinious.Location = new System.Drawing.Point(336, 197);
		this.btnSlitContinious.Name = "btnSlitContinious";
		this.btnSlitContinious.Size = new System.Drawing.Size(110, 38);
		this.btnSlitContinious.TabIndex = 5;
		this.btnSlitContinious.Text = "Slit Repeats";
		this.btnSlitContinious.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Button1
		//
		this.Button1.Enabled = false;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.Button1.Location = new System.Drawing.Point(16, 144);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(472, 128);
		this.Button1.TabIndex = 34;
		//
		//Label8
		//
		this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Label8.Location = new System.Drawing.Point(8, 136);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(488, 144);
		this.Label8.TabIndex = 33;
		//
		//nudSlitWidth
		//
		this.nudSlitWidth.DecimalPlaces = 1;
		this.nudSlitWidth.Increment = new decimal(new int[] {
			1,
			0,
			0,
			65536
		});
		this.nudSlitWidth.Location = new System.Drawing.Point(104, 288);
		this.nudSlitWidth.Maximum = new decimal(new int[] {
			2,
			0,
			0,
			0
		});
		this.nudSlitWidth.Name = "nudSlitWidth";
		this.nudSlitWidth.Size = new System.Drawing.Size(80, 21);
		this.nudSlitWidth.TabIndex = 32;
		this.nudSlitWidth.Visible = false;
		//
		//txtSlitHome
		//
		this.txtSlitHome.BackColor = System.Drawing.Color.WhiteSmoke;
		this.txtSlitHome.Enabled = false;
		this.txtSlitHome.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtSlitHome.ForeColor = System.Drawing.Color.Black;
		this.txtSlitHome.Location = new System.Drawing.Point(400, 24);
		this.txtSlitHome.Name = "txtSlitHome";
		this.txtSlitHome.ReadOnly = true;
		this.txtSlitHome.Size = new System.Drawing.Size(80, 22);
		this.txtSlitHome.TabIndex = 31;
		this.txtSlitHome.Text = "";
		this.txtSlitHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblSlitHome
		//
		this.lblSlitHome.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitHome.Location = new System.Drawing.Point(272, 26);
		this.lblSlitHome.Name = "lblSlitHome";
		this.lblSlitHome.Size = new System.Drawing.Size(101, 16);
		this.lblSlitHome.TabIndex = 30;
		this.lblSlitHome.Text = "Slit Home";
		//
		//txtSlitRepeats
		//
		this.txtSlitRepeats.BackColor = System.Drawing.Color.WhiteSmoke;
		this.txtSlitRepeats.Enabled = false;
		this.txtSlitRepeats.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtSlitRepeats.ForeColor = System.Drawing.Color.Black;
		this.txtSlitRepeats.Location = new System.Drawing.Point(400, 88);
		this.txtSlitRepeats.Name = "txtSlitRepeats";
		this.txtSlitRepeats.ReadOnly = true;
		this.txtSlitRepeats.Size = new System.Drawing.Size(80, 22);
		this.txtSlitRepeats.TabIndex = 29;
		this.txtSlitRepeats.Text = "";
		this.txtSlitRepeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblSlitRepeats
		//
		this.lblSlitRepeats.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitRepeats.Location = new System.Drawing.Point(272, 93);
		this.lblSlitRepeats.Name = "lblSlitRepeats";
		this.lblSlitRepeats.Size = new System.Drawing.Size(112, 16);
		this.lblSlitRepeats.TabIndex = 28;
		this.lblSlitRepeats.Text = "Slit Repeats(1-100)";
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.Location = new System.Drawing.Point(272, 59);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(101, 16);
		this.lblSlitWidth.TabIndex = 27;
		this.lblSlitWidth.Text = "Slit Width";
		//
		//Label7
		//
		this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label7.Location = new System.Drawing.Point(256, 8);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(240, 120);
		this.Label7.TabIndex = 26;
		//
		//txtWvRepeats
		//
		this.txtWvRepeats.BackColor = System.Drawing.Color.WhiteSmoke;
		this.txtWvRepeats.Enabled = false;
		this.txtWvRepeats.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtWvRepeats.ForeColor = System.Drawing.Color.Black;
		this.txtWvRepeats.Location = new System.Drawing.Point(173, 88);
		this.txtWvRepeats.Name = "txtWvRepeats";
		this.txtWvRepeats.ReadOnly = true;
		this.txtWvRepeats.Size = new System.Drawing.Size(66, 22);
		this.txtWvRepeats.TabIndex = 24;
		this.txtWvRepeats.Text = "";
		this.txtWvRepeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txtWvPosition
		//
		this.txtWvPosition.BackColor = System.Drawing.Color.WhiteSmoke;
		this.txtWvPosition.Enabled = false;
		this.txtWvPosition.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtWvPosition.ForeColor = System.Drawing.Color.Black;
		this.txtWvPosition.Location = new System.Drawing.Point(173, 56);
		this.txtWvPosition.Name = "txtWvPosition";
		this.txtWvPosition.ReadOnly = true;
		this.txtWvPosition.Size = new System.Drawing.Size(66, 22);
		this.txtWvPosition.TabIndex = 23;
		this.txtWvPosition.Text = "0.0";
		this.txtWvPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblWvHome
		//
		this.lblWvHome.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWvHome.Location = new System.Drawing.Point(13, 24);
		this.lblWvHome.Name = "lblWvHome";
		this.lblWvHome.Size = new System.Drawing.Size(117, 16);
		this.lblWvHome.TabIndex = 19;
		this.lblWvHome.Text = "Wavelength Home";
		//
		//txtWvHome
		//
		this.txtWvHome.BackColor = System.Drawing.Color.WhiteSmoke;
		this.txtWvHome.Enabled = false;
		this.txtWvHome.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtWvHome.ForeColor = System.Drawing.Color.Black;
		this.txtWvHome.Location = new System.Drawing.Point(173, 24);
		this.txtWvHome.Name = "txtWvHome";
		this.txtWvHome.ReadOnly = true;
		this.txtWvHome.Size = new System.Drawing.Size(66, 22);
		this.txtWvHome.TabIndex = 22;
		this.txtWvHome.Text = "";
		this.txtWvHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblWvRepeats
		//
		this.lblWvRepeats.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWvRepeats.Location = new System.Drawing.Point(13, 91);
		this.lblWvRepeats.Name = "lblWvRepeats";
		this.lblWvRepeats.Size = new System.Drawing.Size(163, 16);
		this.lblWvRepeats.TabIndex = 21;
		this.lblWvRepeats.Text = "Wavelength Repeats(1-100)";
		//
		//lblWvPosition
		//
		this.lblWvPosition.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWvPosition.Location = new System.Drawing.Point(13, 57);
		this.lblWvPosition.Name = "lblWvPosition";
		this.lblWvPosition.Size = new System.Drawing.Size(149, 16);
		this.lblWvPosition.TabIndex = 20;
		this.lblWvPosition.Text = "Wavelength Position(nm)";
		//
		//Label6
		//
		this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label6.Location = new System.Drawing.Point(8, 8);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(240, 120);
		this.Label6.TabIndex = 25;
		//
		//TabControl1
		//
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Location = new System.Drawing.Point(360, 272);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(96, 40);
		this.TabControl1.TabIndex = 12;
		this.TabControl1.Visible = false;
		//
		//TabPage1
		//
		this.TabPage1.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage1.Location = new System.Drawing.Point(4, 24);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Size = new System.Drawing.Size(88, 12);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "Wavelength";
		//
		//TabPage2
		//
		this.TabPage2.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage2.Location = new System.Drawing.Point(4, 24);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Size = new System.Drawing.Size(88, 12);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "Slit";
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(208, 280);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 6;
		this.btnOk.Text = "OK";
		//
		//btnIgnite
		//
		this.btnIgnite.BackColor = System.Drawing.Color.Transparent;
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(238, 159);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnIgnite.TabIndex = 45;
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
		this.btnN2OIgnite.Location = new System.Drawing.Point(254, 159);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnN2OIgnite.TabIndex = 47;
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
		this.btnExtinguish.Location = new System.Drawing.Point(222, 159);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(8, 8);
		this.btnExtinguish.TabIndex = 46;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(264, 159);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 49;
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
		this.btnR.Location = new System.Drawing.Point(276, 159);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 48;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//frmMonochromator
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.ClientSize = new System.Drawing.Size(506, 327);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmMonochromator";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Monochromator";
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nudSlitWidth).EndInit();
		this.TabControl1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Member Variables "

	private frmEditValues mobjfrmEditValues = new frmEditValues();
	private double mintValue;

	private bool mblnInProcess = false;
	#End Region

	#Region " Private Constants "

	private const  ConstWvPosition = "Enter new Wavelength";
	private const  ConstSlitPosition = "Slit Position(0 - 2.0)";
	private const  ConstWvRepeats = "No. of Repeats";

	private const  ConstSlitcontinious = "No. of Repeats";
	#End Region

	#Region " Private Properties "

	private double InputValue {
		//'this is a property for temp taking a input value
		get { return mintValue; }
		set { mintValue = Value; }
	}

	#End Region

	#Region " Form Load function "

	private void  // ERROR: Handles clauses are not supported in C#
frmMonochromator_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmMonochromator_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 22.11.06
		// Revisions             : 
		//=====================================================================
		//'note;/
		//this is called when monochromator form is loaded
		//'To initialize the form
		CWaitCursor objWait = new CWaitCursor();

		try {
			AddHandlers();

			if (gobjInst.WavelengthCur == 0) {
				txtWvHome.Text = "HOME";
				//'display a HOME text
				txtWvPosition.Text = (double)gobjInst.WavelengthCur;
			//'get a current wavelength position from gobjinst object
			} else {
				txtWvPosition.Text = (double)gobjInst.WavelengthCur;
			}
			btnWvHome.Focus();

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

	#End Region

	#Region " Private Functions "

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

		//'note:
		//'this is to add a event handler



		try {
			btnOk.Click += btnOk_Click;
			btnSlitContinious.Click += btnSlitContinious_Click;
			btnSlitWidth.Click += btnSlitWidth_Click;
			btnWvPosition.Click += btnWvPosition_Click;
			btnWvRepeats.Click += btnWvRepeats_Click;
			btnSlitHome.Click += btnSlitHome_Click;
			btnWvHome.Click += btnWvHome_Click;
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


		//'this is called for OK button click
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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void btnSlitContinious_Click(object sender, System.EventArgs e)
	{
		//               case IDC_BSCONT:
		//							rpt=10;
		//							strcpy(Cap[0], "No. of repeats");
		//							sprintf(Str[0],"%-2d ",rpt);
		//							Len[0]=2;
		//							Len[1]=-1;
		//							GetValues(hwnd, Cap, Str, Len);
		//							rpt=atoi(Str[0]);
		//							i=0; sw = Inst_par->Slitpos; op = 40;
		//							do{
		//							  if (Inst_par->Slitpos>=0 && Inst_par->Slitpos<=80)
		//								 sprintf(Str[0],"%-2.1f nm",(80-Inst_par->Slitpos)/40.0);
		//            Else
		//								 strcpy(Str[0],"ERROR");
		//							  SetDlgItemText(hwnd,IDC_SLIT, Str[0]);
		//							  sw+=op;
		//							  if (sw>80){
		//								  sw =80; op = -40;
		//								  SetDlgItemInt(hwnd,IDC_SRPT, i+1, FALSE);
		//								  i++; }
		//                    If (i >= rpt) Then
		//								 break;
		//							  if (sw<0) {
		//								 sw = 0; op=40;
		//								 SetDlgItemInt(hwnd,IDC_SRPT, i+1, FALSE);
		//								 i++; }
		//							  Position_Slit(sw);
		//							  UpdateWindow(hwnd);
		//							  for(j=0; j<15; j++)
		//							    pc_delay(20000); 
		//							 } while(i<rpt);
		//							break;
		//=====================================================================
		// Procedure Name        : btnSlitContinious_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To position the Slit
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note: 
		//'this is used for clite position
		//'what ever the number of repeats user want stroe it in a temp variable
		//'and as par that number made a loop for positioning the slit.
		CWaitCursor objWait = new CWaitCursor();
		int intSlitRepeats;
		double dblSlitWidth;
		int intcount;
		try {
			if (txtSlitWidth.Text == "") {
				//'for validation
				gobjMessageAdapter.ShowMessage(constInputProperData);
				return;
			}
			if (mblnInProcess == true) {
				//'if true then exit from function with out any change
				return;
			}
			mblnInProcess = true;

			//For Password protection----------------------------------------------------------------
			if (Check_Password() == false) {
				mobjfrmEditValues.txtValue.PasswordChar = "";
				//'promt for a correct password
				return;
			}
			mobjfrmEditValues.txtValue.PasswordChar = "";
			//-----------------------------------------------------------------------------------------
			mobjfrmEditValues.Text = "Slit Repeats";
			mobjfrmEditValues.LabelText = ConstSlitcontinious;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 0;
			mobjfrmEditValues.txtValue.MaxLength = 3;
			mobjfrmEditValues.txtValue.MinimumRange = 1;
			mobjfrmEditValues.txtValue.MaximumRange = 100;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.Text = "10";

			//'done some basic validation above
			//'and show the dialog
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				return;
			}
			Application.DoEvents();
			//'allow application to perfrom its panding work
			//If InputValue >= 100 Then
			//    gobjMessageAdapter.ShowMessage(constRepeatValue)
			//    Exit Sub
			//End If
			intSlitRepeats = (int)InputValue;
			//'take a number of repeat in a temp variable
			if (intSlitRepeats < 1 | intSlitRepeats > 100) {
				//'ckeck that repeat should be in  bet 1 to 100
				gobjMessageAdapter.ShowMessage(constRepeatValue);
				return;
			}
			dblSlitWidth = Format((double)txtSlitWidth.Text, "0.0");
			//'format  the text slit
			if (dblSlitWidth < 0) {
				dblSlitWidth = 0.0;
				//'format the decibal point
			}

			for (intcount = 1; intcount <= intSlitRepeats; intcount++) {
				//'make a counter up to user defined repeat
				if (intcount == 1) {
					if (dblSlitWidth < 1) {
						gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth);
						//'this is a function for setting a given slit width
						txtSlitWidth.Text = (double)dblSlitWidth;
					//'and display current slitwidth on screen also
					} else if (dblSlitWidth == 1 | dblSlitWidth == 2) {
						gobjClsAAS203.funcbtnSlitWidth(0.0);
						txtSlitWidth.Text = "0.0";
						txtSlitWidth.Refresh();
					} else if (dblSlitWidth > 1 & dblSlitWidth < 2) {
						gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth - 1);
						txtSlitWidth.Text = (double)dblSlitWidth - 1;
						txtSlitWidth.Refresh();
					}
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				} else if (intcount > 1 & intcount % 2 == 1) {
					txtSlitWidth.Text = "0.0";
					txtSlitWidth.Refresh();
					txtSlitRepeats.Text = (int)intcount;
					txtSlitRepeats.Refresh();
					gobjClsAAS203.funcbtnSlitWidth(0.0);
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				} else {
					gobjClsAAS203.funcbtnSlitWidth(0.0);
					txtSlitWidth.Text = "0.0";
					txtSlitWidth.Refresh();
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);

					txtSlitRepeats.Text = (int)intcount;
					txtSlitRepeats.Refresh();

					txtSlitWidth.Text = "2.0";
					txtSlitWidth.Refresh();
					gobjClsAAS203.funcbtnSlitHome();
					//'function for setting slit at home position
					gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					//'delay
				}
				txtSlitRepeats.Text = (int)intcount;
				txtSlitRepeats.Refresh();
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
			mblnInProcess = false;
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void btnSlitHome_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSlitHome_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the Slit to its home position.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on slithome button
		CWaitCursor objWait = new CWaitCursor();
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			if (gobjClsAAS203.funcbtnSlitHome() == true) {
				//'function for setting slit at home position
				txtSlitHome.Text = "HOME";
				txtSlitWidth.Text = "2.0";
				//'display it on screen
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
			mblnInProcess = false;
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void btnWvHome_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnWvHome_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the Wavelength indicator home
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'this is called when user click on Wavlength home button


		CWaitCursor objWait = new CWaitCursor();

		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			if (gobjClsAAS203.funcbtnWvHome(lblWvRec) == true) {
				//'function for setting wavlength at home position
				txtWvHome.Text = "HOME";
				txtWvPosition.Text = "0.0";
				//'display the current wavelength position
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
			mblnInProcess = false;
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void btnWvPosition_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnWvPosition_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To position the Wavelength
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		//'this is called when user click on wavwlength position button
		//'first show a edit form for accepting the value
		//'check for validation
		//'store it in a variable
		//'and send it to instrument 

		CWaitCursor objWait = new CWaitCursor();
		double dblWvPosition;
		double dblWv;

		try {
			mobjfrmEditValues.LabelText = ConstWvPosition;
			mobjfrmEditValues.txtValue.Visible = true;
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;

			mobjfrmEditValues.Text = "Wavelength Position";
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 2;
			mobjfrmEditValues.txtValue.MaxLength = 6;
			mobjfrmEditValues.txtValue.MinimumRange = 0;
			mobjfrmEditValues.txtValue.MaximumRange = 1000.0;
			mobjfrmEditValues.txtValue.TabIndex = 0;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.Text = gobjInst.WavelengthCur;

			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				return;
			}
			Application.DoEvents();

			dblWvPosition = Format(InputValue, "0.00");

			if (dblWvPosition < 0 | dblWvPosition > 1000) {
				//gobjMessageAdapter.ShowMessage("Invalid Wavelength position", "Wavelength", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
				gobjMessageAdapter.ShowMessage("Invalid Wavelength position" + vbCrLf + "Please enter wavelength range between 0-1000 nm", "Wavelength", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				return;
			}

			Application.DoEvents();
			txtWvHome.Text = "";

			if (gobjClsAAS203.funcbtnWvPosition(dblWvPosition, lblWvRec) == true) {
				//'function for position the wavelength as par given value
				dblWv = gobjInst.WavelengthCur;
			}

			txtWvPosition.Text = dblWv;

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
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void btnWvRepeats_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnWvRepeats_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To get the Wavelength repeats.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when user clicked on wavwlength repeat button
		//'this will first show a edit value dialog
		//'accepts the value from user
		//'chech for the validation 
		//'store it in a temp variable
		//'and then made a counter for wavelength up to the user defined value.

		CWaitCursor objWait = new CWaitCursor();
		int intWvRepeats;
		double dblWvPosition;
		int intcount;
		double dblWv;
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			//For Password protection----------------------------------------------------------------
			if (Check_Password() == false) {
				mobjfrmEditValues.txtValue.PasswordChar = "";
				return;
			}
			//-----------------------------------------------------------------------------------------
			mobjfrmEditValues.Text = "Wavelength Repeats";
			mobjfrmEditValues.LabelText = ConstWvRepeats;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 0;
			mobjfrmEditValues.txtValue.MaxLength = 3;
			mobjfrmEditValues.txtValue.MinimumRange = 1;
			mobjfrmEditValues.txtValue.MaximumRange = 100;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.Text = "10";
			mobjfrmEditValues.txtValue.PasswordChar = "";
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				return;
			}
			Application.DoEvents();
			//lblWvPos.Visible = True
			//If InputValue >= 100 Then
			//    gobjMessageAdapter.ShowMessage(constRepeatValue)
			//    Exit Sub
			//End If
			intWvRepeats = (int)InputValue;
			if (intWvRepeats < 1 | intWvRepeats > 100) {
				gobjMessageAdapter.ShowMessage(constRepeatValue);
				return;
			}
			//txtWvRepeats.Text = CInt(InputValue)
			//dblWvPosition = Format(CDbl(txtWvPosition.Text), "0.00")
			if (txtWvPosition.Text == "") {
				gobjMessageAdapter.ShowMessage(constInputProperData);
			} else {
				for (intcount = 1; intcount <= intWvRepeats; intcount++) {
					txtWvRepeats.Text = (int)intcount;
					txtWvRepeats.Refresh();
					if (intcount % 2 == 1) {
						gobjClsAAS203.funcbtnWvPosition(0.0, lblWvRec);
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					//txtWvPosition.Text = CDbl(gobjInst.WavelengthCur)
					//txtWvHome.Text = "HOME"
					} else {
						dblWvPosition = (double)txtWvPosition.Text;
						txtWvHome.Text = "";
						gobjClsAAS203.funcbtnWvPosition(dblWvPosition, lblWvRec);
						//'function for setting a wavelength as par given repeat
						Application.DoEvents();
						gobjCommProtocol.mobjCommdll.subTime_Delay(500);
					}
				}
			}
			if (gobjInst.WavelengthCur == 0) {
				txtWvHome.Text = "HOME";
				txtWvPosition.Text = (double)gobjInst.WavelengthCur;
			} else {
				txtWvPosition.Text = (double)gobjInst.WavelengthCur;
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
			mblnInProcess = false;
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	private void btnSlitWidth_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSlitWidth_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the slit width
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is to used for setting a slit width
		//'first show a dialog box 
		//'accept the value from user
		///validate the input
		//'store it in a temp variable
		//'as set a slit width as par given input
		CWaitCursor objWait = new CWaitCursor();
		double dblSlitWidth;
		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			txtSlitRepeats.Text = "";
			txtSlitRepeats.Refresh();
			mobjfrmEditValues.Text = "Slit Width";
			mobjfrmEditValues.LabelText = ConstSlitPosition;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 1;
			mobjfrmEditValues.txtValue.MaxLength = 3;
			mobjfrmEditValues.txtValue.MinimumRange = 0;
			mobjfrmEditValues.txtValue.MaximumRange = 2.0;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.Text = gobjInst.SlitPosition;
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				return;
			}
			//mobjfrmEditValues.Dispose()
			Application.DoEvents();
			dblSlitWidth = (double)InputValue;
			if (dblSlitWidth < 0 | dblSlitWidth > 2.0) {
				gobjMessageAdapter.ShowMessage("Invalid Slit width", "Slit", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				return;
			}
			if (gobjClsAAS203.funcbtnSlitWidth(dblSlitWidth) == true) {
				txtSlitWidth.Text = (double)InputValue;
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
			mblnInProcess = false;
			if (!objWait == null) {
				objWait.Dispose();
			}
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
		// Purpose               : Part of an event which is used to get value
		//                       : from frmEditValues
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'this will show the return value for edit form.
		CWaitCursor objWait = new CWaitCursor();
		try {
			InputValue = dblValue;

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
		//this is called when user click on autoignition button
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
			//'function for ignition ON.
			mblnInProcess = false;

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

		//'this is used for putting ignition OFF.

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

		try {
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			Application.DoEvents();
			//If Not gstructSettings.AppMode = EnumAppMode.DemoMode Then
			//    Call gobjCommProtocol.mobjCommdll.subTime_Delay(50)
			//    '---switch over to N2O flame
			//    Call gobjCommProtocol.funcSwitchOver()
			//    ''function for N2O ignition.
			//End If
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
			gobjMainService.funcAltR();
			//Call gobjMain.funcAltR()
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

	private bool Check_Password()
	{
		//'note:'
		//'this is used for checking a password enterd by a user
		//'if password is correct then proceed else prompt the user that
		//'Enter the correct password




		bool blnPass = true;
		mobjfrmEditValues.Text = "Password Required!!!";
		mobjfrmEditValues.LabelText = "Enter The Password";
		mobjfrmEditValues.txtValue.Text = "";
		mobjfrmEditValues.txtValue.Visible = true;
		mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.AlphaNumeric;
		//mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly
		mobjfrmEditValues.txtValue.RangeValidation = false;
		mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 0;
		mobjfrmEditValues.txtValue.MaxLength = 5;
		mobjfrmEditValues.txtValue.MinimumRange = 1;
		mobjfrmEditValues.txtValue.MaximumRange = 99999;
		//mobjfrmEditValues.txtValue.SelectAll()
		do {
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.PasswordChar = "*";
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				blnPass = false;
				mobjfrmEditValues.Text = "Edit Values";
				mobjfrmEditValues.txtValue.Text = "";
				mobjfrmEditValues.txtValue.PasswordChar = "";
				return false;
			} else if (mobjfrmEditValues.txtValue.Text == "shree") {
				blnPass = false;
				mobjfrmEditValues.Text = "Edit Values";
				mobjfrmEditValues.txtValue.Text = "";
				mobjfrmEditValues.txtValue.PasswordChar = "";
				return true;
			} else {
				gobjMessageAdapter.ShowMessage("Please enter the correct password", "Confirm password", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);

			}
			Application.DoEvents();

		} while ((blnPass == true));



	}

	#End Region

}
