using AAS203.Common;
using AAS203Library.Method;
using AAS203Library.Instrument;
//'this will include a supporting files like header file.
//' class behind the Turrert form
public class frmTurret : System.Windows.Forms.Form
{

	public int m_TurretValue;

	#Region " Windows Form Designer generated code "

	public frmTurret()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	public frmTurret(int intValue)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		m_TurretValue = intValue;
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
	internal System.Windows.Forms.TabPage TabPage1;
	internal System.Windows.Forms.TabPage TabPage2;
	internal System.Windows.Forms.TabPage TabPage3;
	internal System.Windows.Forms.TabPage TabPage4;
	internal System.Windows.Forms.TabControl TabControl1;
	internal System.Windows.Forms.TabPage TabPage5;
	internal System.Windows.Forms.TabPage TabPage6;
	internal System.Windows.Forms.TabPage TabPage7;
	internal System.Windows.Forms.TabPage TabPage8;
	internal NETXP.Controls.XPButton btnCancel;
	internal GradientPanel.CustomPanel CustomPanel2;
	internal System.Windows.Forms.ComboBox cmbTurretPosition;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.RadioButton rbOFF;
	internal System.Windows.Forms.RadioButton rbON;
	internal System.Windows.Forms.Label lblD2CurrentStatus;
	internal System.Windows.Forms.TextBox txtD2CurrentValue;
	internal System.Windows.Forms.Label lblD2CurrentValue;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Button Button1;
	internal NETXP.Controls.XPButton btnTurretPosition;
	internal NETXP.Controls.XPButton btnTurretHome;
	internal NETXP.Controls.XPButton btnD2Current;
	internal NETXP.Controls.XPButton btnD2ONOFF;
	internal NETXP.Controls.XPButton btnAllLampOFF;
	internal System.Windows.Forms.Label lblHCLCurrent;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label lblAt;
	internal NETXP.Controls.XPButton btnHCLCurrent;
	internal System.Windows.Forms.TextBox txtHCLTurretPosition;
	internal System.Windows.Forms.TextBox txtHCLCurrent;
	internal System.Windows.Forms.Panel Panel1;
	internal NETXP.Controls.Bars.CommandBar mnuAutoIgnition;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuIgnite;
	internal NETXP.Controls.Bars.CommandBarButtonItem mnuExtinguish;
	internal System.Windows.Forms.Panel PanelTurret;
	internal System.Windows.Forms.TextBox txtTurretPosition;
	internal System.Windows.Forms.NumericUpDown nudTurretMotor;
	internal System.Windows.Forms.Label lblTurretMotor;
	internal System.Windows.Forms.TextBox txtTurretHome;
	internal System.Windows.Forms.Label lblTurretPosition;
	internal System.Windows.Forms.Label lblTurretHome;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.GroupBox grpStep;
	internal System.Windows.Forms.RadioButton rbFullStep;
	internal System.Windows.Forms.RadioButton rbHalfStep;
	internal System.Windows.Forms.Label lblLampStatus;
	internal System.Windows.Forms.TextBox txtLampStatus;
	internal NETXP.Controls.XPButton btnIgnite;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTurret));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.CustomPanel2 = new GradientPanel.CustomPanel();
		this.PanelTurret = new System.Windows.Forms.Panel();
		this.grpStep = new System.Windows.Forms.GroupBox();
		this.rbFullStep = new System.Windows.Forms.RadioButton();
		this.rbHalfStep = new System.Windows.Forms.RadioButton();
		this.lblLampStatus = new System.Windows.Forms.Label();
		this.txtLampStatus = new System.Windows.Forms.TextBox();
		this.txtTurretPosition = new System.Windows.Forms.TextBox();
		this.nudTurretMotor = new System.Windows.Forms.NumericUpDown();
		this.lblTurretMotor = new System.Windows.Forms.Label();
		this.txtTurretHome = new System.Windows.Forms.TextBox();
		this.lblTurretPosition = new System.Windows.Forms.Label();
		this.lblTurretHome = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.mnuAutoIgnition = new NETXP.Controls.Bars.CommandBar();
		this.mnuIgnite = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.mnuExtinguish = new NETXP.Controls.Bars.CommandBarButtonItem();
		this.txtHCLTurretPosition = new System.Windows.Forms.TextBox();
		this.txtHCLCurrent = new System.Windows.Forms.TextBox();
		this.btnHCLCurrent = new NETXP.Controls.XPButton();
		this.lblAt = new System.Windows.Forms.Label();
		this.lblHCLCurrent = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.btnAllLampOFF = new NETXP.Controls.XPButton();
		this.btnD2Current = new NETXP.Controls.XPButton();
		this.btnD2ONOFF = new NETXP.Controls.XPButton();
		this.btnTurretPosition = new NETXP.Controls.XPButton();
		this.btnTurretHome = new NETXP.Controls.XPButton();
		this.Button1 = new System.Windows.Forms.Button();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.rbOFF = new System.Windows.Forms.RadioButton();
		this.rbON = new System.Windows.Forms.RadioButton();
		this.lblD2CurrentStatus = new System.Windows.Forms.Label();
		this.txtD2CurrentValue = new System.Windows.Forms.TextBox();
		this.lblD2CurrentValue = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.cmbTurretPosition = new System.Windows.Forms.ComboBox();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage5 = new System.Windows.Forms.TabPage();
		this.TabPage6 = new System.Windows.Forms.TabPage();
		this.TabPage8 = new System.Windows.Forms.TabPage();
		this.TabPage7 = new System.Windows.Forms.TabPage();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.TabPage4 = new System.Windows.Forms.TabPage();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanel2.SuspendLayout();
		this.PanelTurret.SuspendLayout();
		this.grpStep.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.nudTurretMotor).BeginInit();
		this.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).BeginInit();
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
		this.CustomPanel1.Size = new System.Drawing.Size(466, 383);
		this.CustomPanel1.TabIndex = 0;
		//
		//CustomPanel2
		//
		this.CustomPanel2.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel2.Controls.Add(this.PanelTurret);
		this.CustomPanel2.Controls.Add(this.Panel1);
		this.CustomPanel2.Controls.Add(this.txtHCLTurretPosition);
		this.CustomPanel2.Controls.Add(this.txtHCLCurrent);
		this.CustomPanel2.Controls.Add(this.btnHCLCurrent);
		this.CustomPanel2.Controls.Add(this.lblAt);
		this.CustomPanel2.Controls.Add(this.lblHCLCurrent);
		this.CustomPanel2.Controls.Add(this.Label1);
		this.CustomPanel2.Controls.Add(this.btnAllLampOFF);
		this.CustomPanel2.Controls.Add(this.btnD2Current);
		this.CustomPanel2.Controls.Add(this.btnD2ONOFF);
		this.CustomPanel2.Controls.Add(this.btnTurretPosition);
		this.CustomPanel2.Controls.Add(this.btnTurretHome);
		this.CustomPanel2.Controls.Add(this.Button1);
		this.CustomPanel2.Controls.Add(this.Label5);
		this.CustomPanel2.Controls.Add(this.Label2);
		this.CustomPanel2.Controls.Add(this.rbOFF);
		this.CustomPanel2.Controls.Add(this.rbON);
		this.CustomPanel2.Controls.Add(this.lblD2CurrentStatus);
		this.CustomPanel2.Controls.Add(this.txtD2CurrentValue);
		this.CustomPanel2.Controls.Add(this.lblD2CurrentValue);
		this.CustomPanel2.Controls.Add(this.Label4);
		this.CustomPanel2.Controls.Add(this.cmbTurretPosition);
		this.CustomPanel2.Controls.Add(this.btnCancel);
		this.CustomPanel2.Controls.Add(this.TabControl1);
		this.CustomPanel2.Controls.Add(this.btnIgnite);
		this.CustomPanel2.Controls.Add(this.btnExtinguish);
		this.CustomPanel2.Controls.Add(this.btnDelete);
		this.CustomPanel2.Controls.Add(this.btnR);
		this.CustomPanel2.Controls.Add(this.btnN2OIgnite);
		this.CustomPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel2.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel2.Name = "CustomPanel2";
		this.CustomPanel2.Size = new System.Drawing.Size(466, 383);
		this.CustomPanel2.TabIndex = 0;
		//
		//PanelTurret
		//
		this.PanelTurret.Controls.Add(this.grpStep);
		this.PanelTurret.Controls.Add(this.lblLampStatus);
		this.PanelTurret.Controls.Add(this.txtLampStatus);
		this.PanelTurret.Controls.Add(this.txtTurretPosition);
		this.PanelTurret.Controls.Add(this.nudTurretMotor);
		this.PanelTurret.Controls.Add(this.lblTurretMotor);
		this.PanelTurret.Controls.Add(this.txtTurretHome);
		this.PanelTurret.Controls.Add(this.lblTurretPosition);
		this.PanelTurret.Controls.Add(this.lblTurretHome);
		this.PanelTurret.Controls.Add(this.Label3);
		this.PanelTurret.Location = new System.Drawing.Point(8, 8);
		this.PanelTurret.Name = "PanelTurret";
		this.PanelTurret.Size = new System.Drawing.Size(208, 192);
		this.PanelTurret.TabIndex = 87;
		//
		//grpStep
		//
		this.grpStep.Controls.Add(this.rbFullStep);
		this.grpStep.Controls.Add(this.rbHalfStep);
		this.grpStep.Location = new System.Drawing.Point(4, 147);
		this.grpStep.Name = "grpStep";
		this.grpStep.Size = new System.Drawing.Size(200, 40);
		this.grpStep.TabIndex = 92;
		this.grpStep.TabStop = false;
		//
		//rbFullStep
		//
		this.rbFullStep.BackColor = System.Drawing.Color.Transparent;
		this.rbFullStep.Enabled = false;
		this.rbFullStep.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rbFullStep.Location = new System.Drawing.Point(103, 10);
		this.rbFullStep.Name = "rbFullStep";
		this.rbFullStep.Size = new System.Drawing.Size(80, 24);
		this.rbFullStep.TabIndex = 61;
		this.rbFullStep.Text = "Full Step";
		//
		//rbHalfStep
		//
		this.rbHalfStep.Checked = true;
		this.rbHalfStep.Enabled = false;
		this.rbHalfStep.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rbHalfStep.ForeColor = System.Drawing.Color.Black;
		this.rbHalfStep.Location = new System.Drawing.Point(18, 10);
		this.rbHalfStep.Name = "rbHalfStep";
		this.rbHalfStep.Size = new System.Drawing.Size(85, 24);
		this.rbHalfStep.TabIndex = 60;
		this.rbHalfStep.TabStop = true;
		this.rbHalfStep.Text = "Half Step";
		//
		//lblLampStatus
		//
		this.lblLampStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLampStatus.Location = new System.Drawing.Point(20, 128);
		this.lblLampStatus.Name = "lblLampStatus";
		this.lblLampStatus.Size = new System.Drawing.Size(80, 20);
		this.lblLampStatus.TabIndex = 91;
		this.lblLampStatus.Text = "Lamp Status";
		//
		//txtLampStatus
		//
		this.txtLampStatus.BackColor = System.Drawing.Color.White;
		this.txtLampStatus.Enabled = false;
		this.txtLampStatus.Font = new System.Drawing.Font("Times New Roman", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtLampStatus.Location = new System.Drawing.Point(148, 123);
		this.txtLampStatus.Name = "txtLampStatus";
		this.txtLampStatus.ReadOnly = true;
		this.txtLampStatus.Size = new System.Drawing.Size(40, 22);
		this.txtLampStatus.TabIndex = 90;
		this.txtLampStatus.Text = "";
		this.txtLampStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txtTurretPosition
		//
		this.txtTurretPosition.BackColor = System.Drawing.Color.White;
		this.txtTurretPosition.Enabled = false;
		this.txtTurretPosition.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtTurretPosition.ForeColor = System.Drawing.Color.Black;
		this.txtTurretPosition.Location = new System.Drawing.Point(127, 50);
		this.txtTurretPosition.Name = "txtTurretPosition";
		this.txtTurretPosition.ReadOnly = true;
		this.txtTurretPosition.Size = new System.Drawing.Size(64, 22);
		this.txtTurretPosition.TabIndex = 89;
		this.txtTurretPosition.Text = "";
		this.txtTurretPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//nudTurretMotor
		//
		this.nudTurretMotor.Enabled = false;
		this.nudTurretMotor.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.nudTurretMotor.Location = new System.Drawing.Point(127, 79);
		this.nudTurretMotor.Name = "nudTurretMotor";
		this.nudTurretMotor.Size = new System.Drawing.Size(64, 22);
		this.nudTurretMotor.TabIndex = 87;
		this.nudTurretMotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		//
		//lblTurretMotor
		//
		this.lblTurretMotor.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretMotor.Location = new System.Drawing.Point(15, 82);
		this.lblTurretMotor.Name = "lblTurretMotor";
		this.lblTurretMotor.Size = new System.Drawing.Size(88, 18);
		this.lblTurretMotor.TabIndex = 86;
		this.lblTurretMotor.Text = "Turret Motor";
		this.lblTurretMotor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//txtTurretHome
		//
		this.txtTurretHome.BackColor = System.Drawing.Color.White;
		this.txtTurretHome.Enabled = false;
		this.txtTurretHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtTurretHome.ForeColor = System.Drawing.Color.Black;
		this.txtTurretHome.Location = new System.Drawing.Point(127, 19);
		this.txtTurretHome.Name = "txtTurretHome";
		this.txtTurretHome.ReadOnly = true;
		this.txtTurretHome.Size = new System.Drawing.Size(64, 21);
		this.txtTurretHome.TabIndex = 85;
		this.txtTurretHome.Text = "";
		this.txtTurretHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblTurretPosition
		//
		this.lblTurretPosition.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretPosition.Location = new System.Drawing.Point(15, 52);
		this.lblTurretPosition.Name = "lblTurretPosition";
		this.lblTurretPosition.Size = new System.Drawing.Size(96, 18);
		this.lblTurretPosition.TabIndex = 84;
		this.lblTurretPosition.Text = "Turret Position";
		this.lblTurretPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblTurretHome
		//
		this.lblTurretHome.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretHome.Location = new System.Drawing.Point(15, 22);
		this.lblTurretHome.Name = "lblTurretHome";
		this.lblTurretHome.Size = new System.Drawing.Size(80, 18);
		this.lblTurretHome.TabIndex = 83;
		this.lblTurretHome.Text = "Turret Home";
		this.lblTurretHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.Color.Transparent;
		this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(8, 8);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(192, 104);
		this.Label3.TabIndex = 88;
		//
		//Panel1
		//
		this.Panel1.Controls.Add(this.mnuAutoIgnition);
		this.Panel1.Location = new System.Drawing.Point(200, 376);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(216, 56);
		this.Panel1.TabIndex = 86;
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
		//txtHCLTurretPosition
		//
		this.txtHCLTurretPosition.BackColor = System.Drawing.Color.White;
		this.txtHCLTurretPosition.Enabled = false;
		this.txtHCLTurretPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtHCLTurretPosition.ForeColor = System.Drawing.Color.Black;
		this.txtHCLTurretPosition.Location = new System.Drawing.Point(376, 112);
		this.txtHCLTurretPosition.Name = "txtHCLTurretPosition";
		this.txtHCLTurretPosition.Size = new System.Drawing.Size(64, 21);
		this.txtHCLTurretPosition.TabIndex = 84;
		this.txtHCLTurretPosition.Text = "";
		this.txtHCLTurretPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//txtHCLCurrent
		//
		this.txtHCLCurrent.BackColor = System.Drawing.Color.White;
		this.txtHCLCurrent.Enabled = false;
		this.txtHCLCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtHCLCurrent.ForeColor = System.Drawing.Color.Black;
		this.txtHCLCurrent.Location = new System.Drawing.Point(376, 80);
		this.txtHCLCurrent.Name = "txtHCLCurrent";
		this.txtHCLCurrent.Size = new System.Drawing.Size(64, 21);
		this.txtHCLCurrent.TabIndex = 83;
		this.txtHCLCurrent.Text = "";
		this.txtHCLCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//btnHCLCurrent
		//
		this.btnHCLCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHCLCurrent.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnHCLCurrent.Image = (System.Drawing.Image)resources.GetObject("btnHCLCurrent.Image");
		this.btnHCLCurrent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHCLCurrent.Location = new System.Drawing.Point(305, 224);
		this.btnHCLCurrent.Name = "btnHCLCurrent";
		this.btnHCLCurrent.Size = new System.Drawing.Size(120, 34);
		this.btnHCLCurrent.TabIndex = 3;
		this.btnHCLCurrent.Text = "&HCL Current";
		this.btnHCLCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblAt
		//
		this.lblAt.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblAt.Location = new System.Drawing.Point(232, 115);
		this.lblAt.Name = "lblAt";
		this.lblAt.Size = new System.Drawing.Size(104, 18);
		this.lblAt.TabIndex = 79;
		this.lblAt.Text = "At turret position";
		//
		//lblHCLCurrent
		//
		this.lblHCLCurrent.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblHCLCurrent.Location = new System.Drawing.Point(232, 80);
		this.lblHCLCurrent.Name = "lblHCLCurrent";
		this.lblHCLCurrent.Size = new System.Drawing.Size(80, 18);
		this.lblHCLCurrent.TabIndex = 76;
		this.lblHCLCurrent.Text = "HCL Current";
		//
		//Label1
		//
		this.Label1.Enabled = false;
		this.Label1.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label1.Location = new System.Drawing.Point(232, 96);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(104, 16);
		this.Label1.TabIndex = 78;
		this.Label1.Text = "(Range 0 - 25 mA)";
		//
		//btnAllLampOFF
		//
		this.btnAllLampOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAllLampOFF.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnAllLampOFF.Image = (System.Drawing.Image)resources.GetObject("btnAllLampOFF.Image");
		this.btnAllLampOFF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAllLampOFF.Location = new System.Drawing.Point(305, 267);
		this.btnAllLampOFF.Name = "btnAllLampOFF";
		this.btnAllLampOFF.Size = new System.Drawing.Size(120, 34);
		this.btnAllLampOFF.TabIndex = 6;
		this.btnAllLampOFF.Text = "&All Lamp OFF";
		this.btnAllLampOFF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnD2Current
		//
		this.btnD2Current.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnD2Current.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnD2Current.Image = (System.Drawing.Image)resources.GetObject("btnD2Current.Image");
		this.btnD2Current.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnD2Current.Location = new System.Drawing.Point(177, 224);
		this.btnD2Current.Name = "btnD2Current";
		this.btnD2Current.Size = new System.Drawing.Size(120, 34);
		this.btnD2Current.TabIndex = 2;
		this.btnD2Current.Text = "D2 C&urrent";
		//
		//btnD2ONOFF
		//
		this.btnD2ONOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnD2ONOFF.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnD2ONOFF.Image = (System.Drawing.Image)resources.GetObject("btnD2ONOFF.Image");
		this.btnD2ONOFF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnD2ONOFF.Location = new System.Drawing.Point(177, 267);
		this.btnD2ONOFF.Name = "btnD2ONOFF";
		this.btnD2ONOFF.Size = new System.Drawing.Size(120, 34);
		this.btnD2ONOFF.TabIndex = 5;
		this.btnD2ONOFF.Text = "D2 &ON/OFF";
		//
		//btnTurretPosition
		//
		this.btnTurretPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTurretPosition.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnTurretPosition.Image = (System.Drawing.Image)resources.GetObject("btnTurretPosition.Image");
		this.btnTurretPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTurretPosition.Location = new System.Drawing.Point(40, 267);
		this.btnTurretPosition.Name = "btnTurretPosition";
		this.btnTurretPosition.Size = new System.Drawing.Size(128, 34);
		this.btnTurretPosition.TabIndex = 4;
		this.btnTurretPosition.Text = "Turret &Position";
		this.btnTurretPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//btnTurretHome
		//
		this.btnTurretHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTurretHome.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnTurretHome.Image = (System.Drawing.Image)resources.GetObject("btnTurretHome.Image");
		this.btnTurretHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTurretHome.Location = new System.Drawing.Point(40, 224);
		this.btnTurretHome.Name = "btnTurretHome";
		this.btnTurretHome.Size = new System.Drawing.Size(128, 34);
		this.btnTurretHome.TabIndex = 1;
		this.btnTurretHome.Text = "Turret &Home";
		this.btnTurretHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Button1
		//
		this.Button1.Enabled = false;
		this.Button1.Location = new System.Drawing.Point(40, 208);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(392, 112);
		this.Button1.TabIndex = 70;
		//
		//Label5
		//
		this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Label5.Location = new System.Drawing.Point(31, 200);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(408, 128);
		this.Label5.TabIndex = 0;
		//
		//Label2
		//
		this.Label2.Enabled = false;
		this.Label2.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Label2.Location = new System.Drawing.Point(232, 41);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(120, 16);
		this.Label2.TabIndex = 68;
		this.Label2.Text = "(Range 100 - 300 mA)";
		//
		//rbOFF
		//
		this.rbOFF.Enabled = false;
		this.rbOFF.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rbOFF.Location = new System.Drawing.Point(400, 54);
		this.rbOFF.Name = "rbOFF";
		this.rbOFF.Size = new System.Drawing.Size(48, 24);
		this.rbOFF.TabIndex = 66;
		this.rbOFF.Text = "OFF";
		//
		//rbON
		//
		this.rbON.BackColor = System.Drawing.Color.Transparent;
		this.rbON.Checked = true;
		this.rbON.Enabled = false;
		this.rbON.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.rbON.ForeColor = System.Drawing.Color.Black;
		this.rbON.Location = new System.Drawing.Point(356, 54);
		this.rbON.Name = "rbON";
		this.rbON.Size = new System.Drawing.Size(48, 24);
		this.rbON.TabIndex = 65;
		this.rbON.TabStop = true;
		this.rbON.Text = "ON";
		//
		//lblD2CurrentStatus
		//
		this.lblD2CurrentStatus.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2CurrentStatus.Location = new System.Drawing.Point(232, 56);
		this.lblD2CurrentStatus.Name = "lblD2CurrentStatus";
		this.lblD2CurrentStatus.Size = new System.Drawing.Size(128, 24);
		this.lblD2CurrentStatus.TabIndex = 64;
		this.lblD2CurrentStatus.Text = "D2 Current (Status)";
		//
		//txtD2CurrentValue
		//
		this.txtD2CurrentValue.BackColor = System.Drawing.Color.White;
		this.txtD2CurrentValue.Enabled = false;
		this.txtD2CurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtD2CurrentValue.ForeColor = System.Drawing.Color.Black;
		this.txtD2CurrentValue.Location = new System.Drawing.Point(376, 24);
		this.txtD2CurrentValue.Name = "txtD2CurrentValue";
		this.txtD2CurrentValue.ReadOnly = true;
		this.txtD2CurrentValue.Size = new System.Drawing.Size(64, 21);
		this.txtD2CurrentValue.TabIndex = 67;
		this.txtD2CurrentValue.Text = "";
		this.txtD2CurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		//
		//lblD2CurrentValue
		//
		this.lblD2CurrentValue.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblD2CurrentValue.Location = new System.Drawing.Point(232, 27);
		this.lblD2CurrentValue.Name = "lblD2CurrentValue";
		this.lblD2CurrentValue.Size = new System.Drawing.Size(120, 16);
		this.lblD2CurrentValue.TabIndex = 63;
		this.lblD2CurrentValue.Text = "D2 Current (Value)";
		//
		//Label4
		//
		this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label4.Location = new System.Drawing.Point(224, 16);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(232, 128);
		this.Label4.TabIndex = 62;
		//
		//cmbTurretPosition
		//
		this.cmbTurretPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbTurretPosition.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbTurretPosition.Items.AddRange(new object[] {
			"1",
			"2",
			"3",
			"4",
			"5",
			"6"
		});
		this.cmbTurretPosition.Location = new System.Drawing.Point(64, 352);
		this.cmbTurretPosition.Name = "cmbTurretPosition";
		this.cmbTurretPosition.Size = new System.Drawing.Size(64, 24);
		this.cmbTurretPosition.Sorted = true;
		this.cmbTurretPosition.TabIndex = 0;
		this.cmbTurretPosition.Visible = false;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(191, 336);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(120, 32);
		this.btnCancel.TabIndex = 7;
		this.btnCancel.Text = "C&LOSE";
		//
		//TabControl1
		//
		this.TabControl1.Controls.Add(this.TabPage5);
		this.TabControl1.Controls.Add(this.TabPage6);
		this.TabControl1.Controls.Add(this.TabPage8);
		this.TabControl1.Controls.Add(this.TabPage7);
		this.TabControl1.Location = new System.Drawing.Point(16, 336);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(40, 40);
		this.TabControl1.TabIndex = 26;
		this.TabControl1.Visible = false;
		//
		//TabPage5
		//
		this.TabPage5.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage5.Font = new System.Drawing.Font("Times New Roman", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.TabPage5.Location = new System.Drawing.Point(4, 24);
		this.TabPage5.Name = "TabPage5";
		this.TabPage5.Size = new System.Drawing.Size(32, 12);
		this.TabPage5.TabIndex = 0;
		this.TabPage5.Text = "Turret";
		//
		//TabPage6
		//
		this.TabPage6.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage6.Location = new System.Drawing.Point(4, 24);
		this.TabPage6.Name = "TabPage6";
		this.TabPage6.Size = new System.Drawing.Size(32, 12);
		this.TabPage6.TabIndex = 1;
		this.TabPage6.Text = "D2 Current";
		//
		//TabPage8
		//
		this.TabPage8.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage8.Location = new System.Drawing.Point(4, 24);
		this.TabPage8.Name = "TabPage8";
		this.TabPage8.Size = new System.Drawing.Size(32, 12);
		this.TabPage8.TabIndex = 3;
		this.TabPage8.Text = "Lamp";
		//
		//TabPage7
		//
		this.TabPage7.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage7.Location = new System.Drawing.Point(4, 24);
		this.TabPage7.Name = "TabPage7";
		this.TabPage7.Size = new System.Drawing.Size(32, 12);
		this.TabPage7.TabIndex = 2;
		this.TabPage7.Text = "HCL Current";
		//
		//btnIgnite
		//
		this.btnIgnite.BackColor = System.Drawing.Color.Transparent;
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(360, 304);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnIgnite.TabIndex = 88;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnExtinguish
		//
		this.btnExtinguish.BackColor = System.Drawing.Color.Transparent;
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(344, 304);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(8, 8);
		this.btnExtinguish.TabIndex = 89;
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
		this.btnDelete.Location = new System.Drawing.Point(384, 304);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 92;
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
		this.btnR.Location = new System.Drawing.Point(400, 304);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 91;
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
		this.btnN2OIgnite.Location = new System.Drawing.Point(376, 304);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(8, 8);
		this.btnN2OIgnite.TabIndex = 90;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//TabPage1
		//
		this.TabPage1.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.TabPage1.Location = new System.Drawing.Point(4, 22);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Size = new System.Drawing.Size(304, 238);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "Turret";
		//
		//TabPage2
		//
		this.TabPage2.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage2.Location = new System.Drawing.Point(4, 22);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Size = new System.Drawing.Size(304, 238);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "D2 Current";
		//
		//TabPage3
		//
		this.TabPage3.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage3.Location = new System.Drawing.Point(4, 22);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Size = new System.Drawing.Size(304, 230);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "HCL Current";
		//
		//TabPage4
		//
		this.TabPage4.BackColor = System.Drawing.Color.AliceBlue;
		this.TabPage4.Location = new System.Drawing.Point(4, 22);
		this.TabPage4.Name = "TabPage4";
		this.TabPage4.Size = new System.Drawing.Size(304, 230);
		this.TabPage4.TabIndex = 3;
		this.TabPage4.Text = "Lamp";
		//
		//frmTurret
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.ClientSize = new System.Drawing.Size(466, 383);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmTurret";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Turret";
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanel2.ResumeLayout(false);
		this.PanelTurret.ResumeLayout(false);
		this.grpStep.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.nudTurretMotor).EndInit();
		this.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.mnuAutoIgnition).EndInit();
		this.TabControl1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Variables"
	private frmEditValues mobjfrmEditValues = new frmEditValues();
	private double mintValue;
	private int mintValue1;
	public int Flag = 0;
	private bool mblnInProcess = false;
	//Private mblnCheckButton As Boolean = False
	#End Region

	#Region "Constants"
	private const  ConstTurretPosition = "Enter Turret No. #";
	private const  ConstD2Current = "Enter D2Current(100 - 300mA)";
	private const  ConstHCLCurrent = "HCL Current(0 - 25mA)";
		#End Region
	private const  ConstHCLPosition = "For Turret Position #";

	#Region "Properties"
	//'basic property which can be set by user 
	private double InputValue {
		get { return mintValue; }
		set { mintValue = Value; }
	}

	private int InputValue1 {
		get { return mintValue1; }
		set { mintValue1 = Value1; }
	}
	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmTurret_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmTurret_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this will called when form is loaded
		//'do some intialization here 
		//'intialization must be done as par application mode
		//'eg 203/201



		CWaitCursor objWait = new CWaitCursor();
		try {
			AddHandlers();
			//'this will add all the event handler
			rbOFF.Checked = true;
			rbHalfStep.Checked = true;
			btnTurretHome.Focus();
			if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
				//'for 201
				btnTurretHome.Visible = false;
				btnTurretPosition.Visible = false;
				PanelTurret.Visible = false;
				lblAt.Text = "At Position";

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
		//'note:
		//'this will called when the form is intialise
		//'ot os used for add all the event handler
		try {
			//AddHandler btnOk.Click, AddressOf btnOk_Click
			btnCancel.Click += btnCancel_Click;
			btnTurretHome.Click += btnTurretHome_Click;
			btnTurretPosition.Click += btnTurretPosition_Click;
			btnAllLampOFF.Click += btnAllLampOFF_Click;
			btnHCLCurrent.Click += btnHCLCurrent_Click;
			btnD2Current.Click += btnD2Current_Click;
			btnD2ONOFF.Click += btnD2ONOFF_Click;
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

	private void btnCancel_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To send dialog result as cancel
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when user click on cancel button
		CWaitCursor objWait = new CWaitCursor();
		try {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
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
		//'this is called when user click on OK button
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

	private void btnTurretHome_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnTurretHome_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the Turret indicater home
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on TurrertHome button
		//'this is used for shifting a turrert at home position
		//'for this we used EnumAAS203Protocol.TURHOME protocol

		//------------------------------------------------------------------------------------
		//        BOOL	S4FUNC Find_Turret_Home(HWND hwnd)
		//{
		//BOOL	flag=FALSE;
		//unsigned  oldTout;

		// if (GetInstrument()==AA202)
		//	return TRUE;

		// oldTout=Tout;
		// Tout=LONG_DEALY;
		// hold = Load_Curs();
		// Transmit(TARHOME, 0,0 , 0);
		//    If (Recev(True)) Then
		//	 flag=(BOOL)Param1;
		// SetCursor(hold);
		// Tout=oldTout;
		// if (flag) {
		//	Inst.Lamp_old = Inst.Lamp_pos = 0;
		//	flag =Position_Turret(hwnd,1, TRUE);
		//  }
		// else {
		//	 Gerror_message(" Turret controller error \n Check Turret connections");
		//	 Inst.Lamp_old = -1;
		//	}
		// return flag;
		//}
		//------------------------------------------------------------------------------------

		CWaitCursor objWait = new CWaitCursor();
		try {
			//If gobjMessageAdapter.ShowMessage(constTurretHome) = True Then
			//Application.DoEvents()

			//txtTurretHome.Enabled = False
			if (mblnInProcess == true) {
				//'avoid process if any other process is runnig
				return;
			}
			mblnInProcess = true;

			if (gobjClsAAS203.funcbtnTurretHome() == true) {
				//'function for setting turrert at home position 
				//'by sending protocol
				txtTurretHome.Text = "OK";
				txtTurretPosition.Text = "1";
			//gobjMessageAdapter.ShowMessage(constCongratsTurretHome)
			//Application.DoEvents()
			} else {
				//'show the error message 
				gobjMessageAdapter.ShowMessage(constErrorPosnTurretHome);
			}
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
			mblnInProcess = false;
			//txtTurretHome.Enabled = True
			//---------------------------------------------------------
		}
	}

	private void btnTurretPosition_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnTurretPosition_Click
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
		//'this is called when user click on turrert position button
		//'this is used To position the Turret at said position from current position 

		//'step 1:first display a dialog box . where user can input the posotion to be changed
		//'step 2:validate the value enterd by user
		//'step 3:store the input in a temp variable
		//'step 4:send the value to instrument by using serial communication function
		//'step 5:store the current position in a glibal object to later used.




		CWaitCursor objWait = new CWaitCursor();
		int intTurretPosition;
		string strMessage;
		string strMessage1;
		try {
			//btnTurretPosition.Enabled = False
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			mobjfrmEditValues.LabelText = ConstTurretPosition;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.MaxLength = 1;
			mobjfrmEditValues.txtValue.MinimumRange = 1;
			mobjfrmEditValues.txtValue.MaximumRange = 6;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Text = gobjInst.Lamp_Position;
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				return;
			}
			Application.DoEvents();
			if (InputValue < 1 | InputValue > 6) {
				gobjMessageAdapter.ShowMessage(constEnterTurretNo);
				return;
			}
			intTurretPosition = (int)InputValue;
			if (intTurretPosition == 1) {
				Application.DoEvents();
				if (gobjClsAAS203.funcbtnTurretHome() == true) {
					txtTurretHome.Text = "OK";
					txtTurretPosition.Text = "1";
					Application.DoEvents();
				}

			} else {
				Application.DoEvents();
				txtTurretHome.Text = "";
				txtTurretPosition.Text = "";
				if (gobjClsAAS203.funcbtnTurretPosition(intTurretPosition) == true) {
					Application.DoEvents();
					txtTurretPosition.Text = (int)intTurretPosition;
				} else {
					gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
					gobjMessageAdapter.ShowMessage(constCommError);
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnInProcess = false;
			//btnTurretPosition.Enabled = True
			//---------------------------------------------------------
		}
	}

	private void btnAllLampOFF_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnAllLampOFF_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set all lamps to off position
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh s
		// Created               : 21.11.06
		// Revisions             : 
		//=====================================================================

		//'not:
		//'this is called when user clicked  on all lamp OFF button
		//'for this we are sending EnumAAS203Protocol.HCLOFF protocol


		CWaitCursor objWait = new CWaitCursor();
		try {
			//If gobjMessageAdapter.ShowMessage(constOFFAllLamps) = True Then
			//Application.DoEvents()
			//btnAllLampOFF.Enabled = False
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			if (gobjClsAAS203.funcbtnAllLampOFF() == true) {
				//'function for sending a protocol ofr All lamp off

				txtLampStatus.Text = "OFF";
				txtHCLCurrent.Text = "0";
			//gobjMessageAdapter.ShowMessage(constCongratsOFFAllLamps)
			//Application.DoEvents()
			} else {
				gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
				gobjMessageAdapter.ShowMessage(constCommError);
			}
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
			mblnInProcess = false;
			//btnAllLampOFF.Enabled = True
			//---------------------------------------------------------
		}
	}

	private void btnHCLCurrent_Click(object sender, System.EventArgs e)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   btnHCLCurrent_Click
		//Description            :   To set current to the lamp
		//Parameters             :   dblLampCur = current to be set to lamp
		//                           intLampPos = lamp position to which current to be set
		//Time/Date              :   21/11/06
		//Dependencies           :   
		//Author                 :   Saurabh S.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------


		//'note:
		//'this is called when user clicked on HCL current button
		//'this is used to off a HCL current at given position
		//'by sending a EnumAAS203Protocol.HCLCUR protocol
		//'step 1:show a edit dialog for accepting a value from user
		//'step 2:validate that input enter by user
		//'step 3:store it in a temp variable
		//'step 4:send it to instrument
		//'for putting lamp off at given position


		CWaitCursor objWait = new CWaitCursor();
		double dblCurrent;
		int intTurret;
		string strMessage;
		string strMessage1;
		try {
			//btnHCLCurrent.Enabled = False
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			txtLampStatus.Text = "";

			mobjfrmEditValues.Size = new Size(384, 104);
			mobjfrmEditValues.LabelText = ConstHCLCurrent;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.DigitsAfterDecimalPoint = 1;
			mobjfrmEditValues.txtValue.MaxLength = 4;
			mobjfrmEditValues.txtValue.MinimumRange = 0;
			mobjfrmEditValues.txtValue.MaximumRange = 25;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.Text = "3";

			mobjfrmEditValues.txtValue1.Visible = true;
			mobjfrmEditValues.txtValue1.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.lblText1.Visible = true;
			mobjfrmEditValues.lblText1.Text = "for Turret no. #";
			mobjfrmEditValues.txtValue1.Text = gobjInst.Lamp_Position;
			mobjfrmEditValues.CustomPanelHide.SendToBack();
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				mobjfrmEditValues.txtValue1.Visible = false;
				mobjfrmEditValues.lblText1.Visible = false;
				mobjfrmEditValues.CustomPanelHide.BringToFront();
				return;
			}
			Application.DoEvents();
			mobjfrmEditValues.txtValue1.Visible = false;
			mobjfrmEditValues.lblText1.Visible = false;
			mobjfrmEditValues.CustomPanelHide.BringToFront();
			if (InputValue < 0 | InputValue > 25) {
				gobjMessageAdapter.ShowMessage(constHCLcurrentRange);
				return;
			} else if (InputValue1 < 1 | InputValue1 > 6) {
				gobjMessageAdapter.ShowMessage(constEnterTurretNo);
				return;
			}
			dblCurrent = (double)InputValue;
			intTurret = (int)InputValue1;
			Application.DoEvents();
			if (gobjClsAAS203.funcbtnHCLCurrent(dblCurrent, intTurret) == true) {
				//'function for lamp
				//'here dblcurrent is value of current and intTurret is turret position
				Application.DoEvents();
				txtHCLCurrent.Text = (double)dblCurrent;
				txtHCLTurretPosition.Text = (int)intTurret;
			} else {
				gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
				gobjMessageAdapter.ShowMessage(constCommError);
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
			mblnInProcess = false;
			//btnHCLCurrent.Enabled = True
			//---------------------------------------------------------
		}

	}

	private void btnD2Current_Click(object sender, System.EventArgs e)
	{
		//-----------------------------------  Procedure Header  -------------------------------
		//Procedure Name         :   btnD2Current_Click
		//Description            :   To set the D2 current 
		//Parameters             :   dblLampCur = current to be set to lamp
		//Time/Date              :   04/12/06
		//Dependencies           :   
		//Author                 :   Saurabh S.
		//Revision               :
		//Revision by Person     :
		//--------------------------------------------------------------------------------------
		//'note:
		//'this is called when user clicked on D2 Current button
		//'step 1:show a dialog for accepting a D2 current value from user
		//'step 2:validate that input value
		//'step 3:send it to instrument and store it in a global variable as well

		CWaitCursor objWait = new CWaitCursor();
		double dblD2Cur;
		try {
			//btnD2Current.Enabled = False
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			mobjfrmEditValues.LabelText = ConstD2Current;
			mobjfrmEditValues.txtValue.Visible = true;
			mobjfrmEditValues.txtValue.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			mobjfrmEditValues.txtValue.RangeValidation = true;
			mobjfrmEditValues.txtValue.MaxLength = 3;
			mobjfrmEditValues.txtValue.MinimumRange = 100;
			mobjfrmEditValues.txtValue.MaximumRange = 300;
			mobjfrmEditValues.txtValue.SelectAll();
			mobjfrmEditValues.txtValue.Focus();
			mobjfrmEditValues.txtValue.Text = gobjInst.D2Current;
			if (mobjfrmEditValues.ShowDialog == DialogResult.Cancel) {
				return;
			}
			Application.DoEvents();
			if (InputValue < 100 | InputValue > 300) {
				gobjMessageAdapter.ShowMessage(constD2CurrentRange);
				return;
			}
			dblD2Cur = (int)InputValue;
			Application.DoEvents();
			if (gobjClsAAS203.funcbtnD2Current(dblD2Cur) == true) {
				//'function for setting D2 current 
				Application.DoEvents();
				txtD2CurrentValue.Text = (double)dblD2Cur;
				rbON.Checked = true;
			} else {
				gobjMessageAdapter.MessageTextAlignment = ContentAlignment.MiddleLeft;
				gobjMessageAdapter.ShowMessage(constCommError);
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
			//btnD2Current.Enabled = True
			//---------------------------------------------------------
		}
	}

	private void btnD2ONOFF_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnD2ONOFF_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To make the D2 current ON or OFF
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 04.12.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user clicked on D2 on/off button
		//'this is used to put D2 lamp on or off as par sending communication protocols



		CWaitCursor objWait = new CWaitCursor();
		int Flag1;
		try {
			//btnD2ONOFF.Enabled = False
			if (mblnInProcess == true) {
				return;
			}
			mblnInProcess = true;
			if (rbOFF.Checked == true) {
				Flag = 0;
			} else {
				Flag = 1;
			}
			//'set a flag as par lamp current status
			if (gobjClsAAS203.funcbtnD2ONOFF(Flag, Flag1) == true) {
				//'function for setting D2 lamp on or off.
				//'here we have pass the flag as par ON and OFF.
				if (Flag1 == 1) {
					rbON.Checked = true;
				} else {
					rbOFF.Checked = true;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			mblnInProcess = false;
			//btnD2ONOFF.Enabled = True
			//---------------------------------------------------------
		}
	}

	private void  // ERROR: Handles clauses are not supported in C#
mobjfrmEditValues_ReturnValue(double dblValue, int intValue1)
	{
		//=====================================================================
		// Procedure Name        : mobjfrmEditValues_ReturnValue
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To get the values from form EditValues
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 04.12.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			InputValue = dblValue;
			InputValue1 = intValue1;

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
		//'this is called when user click on auto ignition ON
		//'this is used to ignite a flame


		try {
			mnuIgnite.Click -= btnAutoIgnition_Click;
			if (mblnInProcess == true) {
				return;
			}
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
			// mobjController.Cancel()
			Application.DoEvents();

			gobjClsAAS203.funcIgnite(true);
		//'here we are sending parameter true for ignite a flame
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
		//'note:
		//'this is used to put off the flame ignition
		try {
			mnuExtinguish.Click -= btnExtinguish_Click;
			if (mblnInProcess == true) {
				return;
			}
			//If Not IsNothing(mobjfrmAnalysis) Then mobjfrmAnalysis.tmrAspirationMsg.Enabled = False
			//mobjController.Cancel()
			Application.DoEvents();
			//'allow application to perfrom its panding work

			gobjClsAAS203.funcIgnite(false);
		//'here we pass false parameter for putting ignition off.

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
