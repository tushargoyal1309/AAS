using AAS203.Common;
using AAS203Library.Method;

//'these are like header files

//'this class contain a function for setting instrument cond for particuler method
public class frmInstrumentParameters : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmInstrumentParameters()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		////--- Added by Sachin Dokhale on 23.02.08 to display Max No of lamp on screen
		this.subShowMaxLamps();
		////---

	}

	public frmInstrumentParameters(int intMethodMode)
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		////--- Added by Sachin Dokhale on 23.02.08 to display Max No of lamp on screen
		this.subShowMaxLamps();
		////---
		//Add any initialization after the InitializeComponent() call
		OpenMethodMode = intMethodMode;

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
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal GradientPanel.CustomPanel CustomPanelRightBottom;
	internal GradientPanel.CustomPanel CustomPanelBottom;
	internal GradientPanel.CustomPanel CustomPanelBottomTop;
	internal NETXP.Controls.XPButton btnHelp;
	internal NETXP.Controls.XPButton btnOk;
	internal NETXP.Controls.XPButton btnCancel;
	internal GradientPanel.CustomPanel CustomPanelTop;
	internal CodeIntellects.Office2003Controls.Office2003Header Office2003Header1;
	internal System.Windows.Forms.GroupBox gbMeasurementCond;
	internal System.Windows.Forms.Label lblElementName;
	internal System.Windows.Forms.Label lblTurretNum;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label lblLampCurrent;
	internal System.Windows.Forms.Label lblWavelength;
	internal System.Windows.Forms.Label lblSlitWidth;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal NETXP.Controls.XPButton btnOptimiseTurret;
	internal NETXP.Controls.XPButton btnWarmupLamp;
	internal NETXP.Controls.XPButton btnReplaceLamp;
	internal NETXP.Controls.XPButton btnOptimiseAllTurret;
	internal NumberValidator.NumberValidator txtTurretNum;
	internal NumberValidator.NumberValidator txtLampCurrent;
	internal NumberValidator.NumberValidator txtSlitWidth;
	internal System.Windows.Forms.ComboBox cmbWV;

	public System.Windows.Forms.ComboBox cmbElementName;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInstrumentParameters));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.CustomPanelRightBottom = new GradientPanel.CustomPanel();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmbWV = new System.Windows.Forms.ComboBox();
		this.txtSlitWidth = new NumberValidator.NumberValidator();
		this.txtLampCurrent = new NumberValidator.NumberValidator();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.lblLampCurrent = new System.Windows.Forms.Label();
		this.lblWavelength = new System.Windows.Forms.Label();
		this.lblSlitWidth = new System.Windows.Forms.Label();
		this.CustomPanelBottom = new GradientPanel.CustomPanel();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.CustomPanelBottomTop = new GradientPanel.CustomPanel();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.btnOptimiseTurret = new NETXP.Controls.XPButton();
		this.btnWarmupLamp = new NETXP.Controls.XPButton();
		this.btnReplaceLamp = new NETXP.Controls.XPButton();
		this.btnOptimiseAllTurret = new NETXP.Controls.XPButton();
		this.btnHelp = new NETXP.Controls.XPButton();
		this.btnOk = new NETXP.Controls.XPButton();
		this.CustomPanelTop = new GradientPanel.CustomPanel();
		this.gbMeasurementCond = new System.Windows.Forms.GroupBox();
		this.txtTurretNum = new NumberValidator.NumberValidator();
		this.cmbElementName = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblTurretNum = new System.Windows.Forms.Label();
		this.lblElementName = new System.Windows.Forms.Label();
		this.Office2003Header1 = new CodeIntellects.Office2003Controls.Office2003Header();
		this.CustomPanelMain.SuspendLayout();
		this.CustomPanelRightBottom.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.CustomPanelBottom.SuspendLayout();
		this.CustomPanelBottomTop.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.CustomPanelTop.SuspendLayout();
		this.gbMeasurementCond.SuspendLayout();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.BackColor2 = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.CustomPanelRightBottom);
		this.CustomPanelMain.Controls.Add(this.CustomPanelBottom);
		this.CustomPanelMain.Controls.Add(this.CustomPanelTop);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 22);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(424, 367);
		this.CustomPanelMain.TabIndex = 12;
		//
		//CustomPanelRightBottom
		//
		this.CustomPanelRightBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelRightBottom.Controls.Add(this.GroupBox1);
		this.CustomPanelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelRightBottom.Location = new System.Drawing.Point(0, 72);
		this.CustomPanelRightBottom.Name = "CustomPanelRightBottom";
		this.CustomPanelRightBottom.Size = new System.Drawing.Size(424, 127);
		this.CustomPanelRightBottom.TabIndex = 1;
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.cmbWV);
		this.GroupBox1.Controls.Add(this.txtSlitWidth);
		this.GroupBox1.Controls.Add(this.txtLampCurrent);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.lblLampCurrent);
		this.GroupBox1.Controls.Add(this.lblWavelength);
		this.GroupBox1.Controls.Add(this.lblSlitWidth);
		this.GroupBox1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.GroupBox1.Location = new System.Drawing.Point(10, 8);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(406, 112);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Working Conditions";
		//
		//cmbWV
		//
		this.cmbWV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbWV.Location = new System.Drawing.Point(128, 48);
		this.cmbWV.Name = "cmbWV";
		this.cmbWV.Size = new System.Drawing.Size(104, 24);
		this.cmbWV.TabIndex = 1;
		//
		//txtSlitWidth
		//
		this.txtSlitWidth.DigitsAfterDecimalPoint = 1;
		this.txtSlitWidth.ErrorColor = System.Drawing.Color.Empty;
		this.txtSlitWidth.ErrorMessage = null;
		this.txtSlitWidth.Location = new System.Drawing.Point(128, 81);
		this.txtSlitWidth.MaximumRange = 2;
		this.txtSlitWidth.MaxLength = 4;
		this.txtSlitWidth.MinimumRange = 0;
		this.txtSlitWidth.Name = "txtSlitWidth";
		this.txtSlitWidth.RangeValidation = true;
		this.txtSlitWidth.Size = new System.Drawing.Size(104, 22);
		this.txtSlitWidth.TabIndex = 2;
		this.txtSlitWidth.Text = "";
		this.txtSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//txtLampCurrent
		//
		this.txtLampCurrent.DigitsAfterDecimalPoint = 1;
		this.txtLampCurrent.ErrorColor = System.Drawing.Color.Empty;
		this.txtLampCurrent.ErrorMessage = null;
		this.txtLampCurrent.Location = new System.Drawing.Point(128, 18);
		this.txtLampCurrent.MaximumRange = 25;
		this.txtLampCurrent.MaxLength = 4;
		this.txtLampCurrent.MinimumRange = 0;
		this.txtLampCurrent.Name = "txtLampCurrent";
		this.txtLampCurrent.RangeValidation = true;
		this.txtLampCurrent.Size = new System.Drawing.Size(104, 22);
		this.txtLampCurrent.TabIndex = 0;
		this.txtLampCurrent.Text = "";
		this.txtLampCurrent.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
		//
		//Label4
		//
		this.Label4.Enabled = false;
		this.Label4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label4.Location = new System.Drawing.Point(232, 82);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(168, 18);
		this.Label4.TabIndex = 27;
		this.Label4.Text = "0 - 2.0 nm in steps of 0.1 nm";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label3
		//
		this.Label3.Enabled = false;
		this.Label3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label3.Location = new System.Drawing.Point(232, 50);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(168, 18);
		this.Label3.TabIndex = 26;
		this.Label3.Text = "185 .. 950 nm";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Label2
		//
		this.Label2.Enabled = false;
		this.Label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label2.Location = new System.Drawing.Point(232, 18);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(64, 18);
		this.Label2.TabIndex = 25;
		this.Label2.Text = "0 - 25 mA";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblLampCurrent
		//
		this.lblLampCurrent.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblLampCurrent.Location = new System.Drawing.Point(8, 18);
		this.lblLampCurrent.Name = "lblLampCurrent";
		this.lblLampCurrent.Size = new System.Drawing.Size(104, 16);
		this.lblLampCurrent.TabIndex = 23;
		this.lblLampCurrent.Text = "Lamp Current";
		//
		//lblWavelength
		//
		this.lblWavelength.BackColor = System.Drawing.Color.Transparent;
		this.lblWavelength.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblWavelength.Location = new System.Drawing.Point(8, 50);
		this.lblWavelength.Name = "lblWavelength";
		this.lblWavelength.Size = new System.Drawing.Size(104, 16);
		this.lblWavelength.TabIndex = 21;
		this.lblWavelength.Text = "Wavelength";
		//
		//lblSlitWidth
		//
		this.lblSlitWidth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSlitWidth.Location = new System.Drawing.Point(8, 82);
		this.lblSlitWidth.Name = "lblSlitWidth";
		this.lblSlitWidth.Size = new System.Drawing.Size(104, 16);
		this.lblSlitWidth.TabIndex = 20;
		this.lblSlitWidth.Text = "Slit Width";
		//
		//CustomPanelBottom
		//
		this.CustomPanelBottom.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottom.Controls.Add(this.btnCancel);
		this.CustomPanelBottom.Controls.Add(this.CustomPanelBottomTop);
		this.CustomPanelBottom.Controls.Add(this.btnHelp);
		this.CustomPanelBottom.Controls.Add(this.btnOk);
		this.CustomPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelBottom.Location = new System.Drawing.Point(0, 199);
		this.CustomPanelBottom.Name = "CustomPanelBottom";
		this.CustomPanelBottom.Size = new System.Drawing.Size(424, 168);
		this.CustomPanelBottom.TabIndex = 2;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(305, 126);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(86, 34);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "&Cancel";
		//
		//CustomPanelBottomTop
		//
		this.CustomPanelBottomTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelBottomTop.Controls.Add(this.GroupBox2);
		this.CustomPanelBottomTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelBottomTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelBottomTop.Name = "CustomPanelBottomTop";
		this.CustomPanelBottomTop.Size = new System.Drawing.Size(424, 120);
		this.CustomPanelBottomTop.TabIndex = 0;
		//
		//GroupBox2
		//
		this.GroupBox2.Controls.Add(this.btnOptimiseTurret);
		this.GroupBox2.Controls.Add(this.btnWarmupLamp);
		this.GroupBox2.Controls.Add(this.btnReplaceLamp);
		this.GroupBox2.Controls.Add(this.btnOptimiseAllTurret);
		this.GroupBox2.Location = new System.Drawing.Point(10, 8);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(406, 104);
		this.GroupBox2.TabIndex = 0;
		this.GroupBox2.TabStop = false;
		//
		//btnOptimiseTurret
		//
		this.btnOptimiseTurret.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOptimiseTurret.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOptimiseTurret.Image = (System.Drawing.Image)resources.GetObject("btnOptimiseTurret.Image");
		this.btnOptimiseTurret.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOptimiseTurret.Location = new System.Drawing.Point(11, 62);
		this.btnOptimiseTurret.Name = "btnOptimiseTurret";
		this.btnOptimiseTurret.Size = new System.Drawing.Size(176, 34);
		this.btnOptimiseTurret.TabIndex = 2;
		this.btnOptimiseTurret.Text = "Optimise &Turret";
		//
		//btnWarmupLamp
		//
		this.btnWarmupLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnWarmupLamp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnWarmupLamp.Image = (System.Drawing.Image)resources.GetObject("btnWarmupLamp.Image");
		this.btnWarmupLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnWarmupLamp.Location = new System.Drawing.Point(215, 17);
		this.btnWarmupLamp.Name = "btnWarmupLamp";
		this.btnWarmupLamp.Size = new System.Drawing.Size(176, 34);
		this.btnWarmupLamp.TabIndex = 1;
		this.btnWarmupLamp.Text = "&Warm up Lamp";
		//
		//btnReplaceLamp
		//
		this.btnReplaceLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReplaceLamp.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnReplaceLamp.Image = (System.Drawing.Image)resources.GetObject("btnReplaceLamp.Image");
		this.btnReplaceLamp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnReplaceLamp.Location = new System.Drawing.Point(11, 17);
		this.btnReplaceLamp.Name = "btnReplaceLamp";
		this.btnReplaceLamp.Size = new System.Drawing.Size(176, 34);
		this.btnReplaceLamp.TabIndex = 0;
		this.btnReplaceLamp.Text = "&Replace Lamp";
		//
		//btnOptimiseAllTurret
		//
		this.btnOptimiseAllTurret.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOptimiseAllTurret.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOptimiseAllTurret.Image = (System.Drawing.Image)resources.GetObject("btnOptimiseAllTurret.Image");
		this.btnOptimiseAllTurret.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOptimiseAllTurret.Location = new System.Drawing.Point(215, 62);
		this.btnOptimiseAllTurret.Name = "btnOptimiseAllTurret";
		this.btnOptimiseAllTurret.Size = new System.Drawing.Size(176, 34);
		this.btnOptimiseAllTurret.TabIndex = 3;
		this.btnOptimiseAllTurret.Text = "Optimise &All Turret";
		//
		//btnHelp
		//
		this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHelp.Image = (System.Drawing.Image)resources.GetObject("btnHelp.Image");
		this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHelp.Location = new System.Drawing.Point(328, 144);
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.Size = new System.Drawing.Size(86, 34);
		this.btnHelp.TabIndex = 11;
		this.btnHelp.Text = "Help";
		this.btnHelp.Visible = false;
		//
		//btnOk
		//
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnOk.Image = (System.Drawing.Image)resources.GetObject("btnOk.Image");
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(200, 126);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(86, 34);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "&OK";
		//
		//CustomPanelTop
		//
		this.CustomPanelTop.BackColor = System.Drawing.Color.Transparent;
		this.CustomPanelTop.BackColor2 = System.Drawing.Color.Transparent;
		this.CustomPanelTop.Controls.Add(this.gbMeasurementCond);
		this.CustomPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelTop.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelTop.Name = "CustomPanelTop";
		this.CustomPanelTop.Size = new System.Drawing.Size(424, 72);
		this.CustomPanelTop.TabIndex = 0;
		//
		//gbMeasurementCond
		//
		this.gbMeasurementCond.Controls.Add(this.txtTurretNum);
		this.gbMeasurementCond.Controls.Add(this.cmbElementName);
		this.gbMeasurementCond.Controls.Add(this.Label1);
		this.gbMeasurementCond.Controls.Add(this.lblTurretNum);
		this.gbMeasurementCond.Controls.Add(this.lblElementName);
		this.gbMeasurementCond.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.gbMeasurementCond.Location = new System.Drawing.Point(10, 8);
		this.gbMeasurementCond.Name = "gbMeasurementCond";
		this.gbMeasurementCond.Size = new System.Drawing.Size(406, 56);
		this.gbMeasurementCond.TabIndex = 0;
		this.gbMeasurementCond.TabStop = false;
		this.gbMeasurementCond.Text = "Measurement Conditions";
		//
		//txtTurretNum
		//
		this.txtTurretNum.DigitsAfterDecimalPoint = 0;
		this.txtTurretNum.ErrorColor = System.Drawing.Color.Empty;
		this.txtTurretNum.ErrorMessage = "";
		this.txtTurretNum.Location = new System.Drawing.Point(295, 24);
		this.txtTurretNum.MaximumRange = 6;
		this.txtTurretNum.MaxLength = 1;
		this.txtTurretNum.MinimumRange = 1;
		this.txtTurretNum.Name = "txtTurretNum";
		this.txtTurretNum.RangeValidation = true;
		this.txtTurretNum.Size = new System.Drawing.Size(40, 22);
		this.txtTurretNum.TabIndex = 1;
		this.txtTurretNum.Text = "";
		this.txtTurretNum.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
		//
		//cmbElementName
		//
		this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbElementName.Location = new System.Drawing.Point(128, 24);
		this.cmbElementName.Name = "cmbElementName";
		this.cmbElementName.Size = new System.Drawing.Size(80, 24);
		this.cmbElementName.TabIndex = 0;
		//
		//Label1
		//
		this.Label1.Enabled = false;
		this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label1.Location = new System.Drawing.Point(339, 27);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(56, 18);
		this.Label1.TabIndex = 15;
		this.Label1.Text = "1..6 only";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblTurretNum
		//
		this.lblTurretNum.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblTurretNum.Location = new System.Drawing.Point(223, 27);
		this.lblTurretNum.Name = "lblTurretNum";
		this.lblTurretNum.Size = new System.Drawing.Size(64, 18);
		this.lblTurretNum.TabIndex = 13;
		this.lblTurretNum.Text = "Turret No.";
		this.lblTurretNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//lblElementName
		//
		this.lblElementName.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblElementName.Location = new System.Drawing.Point(14, 27);
		this.lblElementName.Name = "lblElementName";
		this.lblElementName.Size = new System.Drawing.Size(96, 18);
		this.lblElementName.TabIndex = 11;
		this.lblElementName.Text = "Element Name";
		this.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		//
		//Office2003Header1
		//
		this.Office2003Header1.BackColor = System.Drawing.SystemColors.Control;
		this.Office2003Header1.Dock = System.Windows.Forms.DockStyle.Top;
		this.Office2003Header1.Location = new System.Drawing.Point(0, 0);
		this.Office2003Header1.Name = "Office2003Header1";
		this.Office2003Header1.Size = new System.Drawing.Size(424, 22);
		this.Office2003Header1.TabIndex = 13;
		this.Office2003Header1.TitleFont = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Office2003Header1.TitleText = "Instrument Parameters";
		//
		//frmInstrumentParameters
		//
		this.AcceptButton = this.btnOk;
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(424, 389);
		this.ControlBox = false;
		this.Controls.Add(this.CustomPanelMain);
		this.Controls.Add(this.Office2003Header1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmInstrumentParameters";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Method ";
		this.CustomPanelMain.ResumeLayout(false);
		this.CustomPanelRightBottom.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.CustomPanelBottom.ResumeLayout(false);
		this.CustomPanelBottomTop.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.CustomPanelTop.ResumeLayout(false);
		this.gbMeasurementCond.ResumeLayout(false);
		this.ResumeLayout(false);

	}
	private void subShowMaxLamps()
	{
		//=====================================================================
		// Procedure Name        : subShowMaxLamps
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To show the Max. lamp No. on screen 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale 
		// Created               : 23.02.08
		// Revisions             : 
		//=====================================================================
		try {
			if (!gobjClsAAS203 == null) {
				this.Label1.Text = "1.." + gobjClsAAS203.funcGetMaxLamp + " only";
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
	#End Region

	#Region " Public Constants, Structures, Events.. "

	public event  MethodInstrumentSettingsChanged;
	//'this is a public event which can called from anywhere of software when instrument setting is changed

	#End Region

	#Region " Private Class Member Variables "
	//'this are the temp variable which are used for storing a value which user entered on screen 

	private bool mblnWarmupLamp;
	private int mintWarmUp_Lamp;
	private int mintTurretNumber;
	private bool mblnIsValid;

	private clsInstrumentParameters mobjInstrumentParameters;
	frmLampPlacements mobjfrmLampPlacements203;
	frmLampPlacements_201 mobjfrmLampPlacements201;
	//'this are the object of other class which have to be used in this class

	private EnumMethodMode mintOpenMethodMode;
	private int mintWavelengthID;
	private bool mblnEnableElement;
	//Private mobjInstrumentParaCollection As clsInstrumentParametersCollection
	//Private mobjInstrumentParameters As clsInstrumentParameters

	#End Region

	#Region " Private Properties "

	//'this are the some property which can be set and used as a cond

	private EnumMethodMode OpenMethodMode {
		get { return mintOpenMethodMode; }
		set { mintOpenMethodMode = Value; }
	}

	private int SelectedWavelengthID {
		get { return mintWavelengthID; }
		set {
			DataRow objRow;
			double dblSlit;
			int intCount;

			try {
				mintWavelengthID = Value;

				objRow = gobjClsAAS203.funcGetCookBookDetailRow(mintWavelengthID);

				if (!IsNothing(objRow)) {
					dblSlit = objRow.Item(ConstColumnSlit);
					txtSlitWidth.Text = dblSlit;
				}

				if (!IsNothing(gobjNewMethod)) {
					gobjNewMethod.InstrumentCondition.SelectedWavelengthID = mintWavelengthID;
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
	}

	#End Region

	#Region "Public Properties"

	#End Region

	#Region " Private Constants "

	//'this are the private constant which we used insted of direct value

	private const  ConstColumnTurretNumber = "TurretNumber";
	private const  Const_TableElement = "Elements";
	private const  ConstIntMinTurretLimit = 1;
	private const  ConstIntMaxTurretLimit = 6;
	private const  ConstIntMinCurrentLimit = 0.1;
	private const  ConstIntMaxCurrentLimit = 25.99;
	private const  ConstIntMinSlitWidthLimit = 0.1;
	private const  ConstIntMaxSlitWidthLimit = 2.0;
	private const  ConstFormLoad = "-Method-InstrumentConditions";

	private const  ConstParentFormLoad = "-Method";
	#End Region

	#Region " Form Load Event Function "

	private void  // ERROR: Handles clauses are not supported in C#
frmInstrumentParameters_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmInstrumentParameters_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To initialize the form
		// Description           : this is called when form is loaded
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : praveen
		//=====================================================================
		//'note:
		//'this is called when form is loaded
		//'this is used To initialize the form
		CWaitCursor objWait = new CWaitCursor();
		int intObjCount;
		DataTable objDtElements;
		//'this is a object of datastructure
		DataRow objRow;
		DataView objDvElementsList;
		int intRowCount;
		int intRowCount1;

		try {
			//Original Code is in 'Else' part
			//Code in 'If' part is done by Saurbah
			//'EnumApplicationMode is a structure which contains some mode info
			//Added by Saurabh
			if (gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				//'by gstructSettings.ExeToRun we can decide which EXE is to be run
				//Added by Saurabh---24.06.07
				OpenMethodMode = modGlobalConstants.EnumMethodMode.NewMode;
				switch (gstructSettings.AppMode) {
					//'case for app mode
					//'validate the status form as application mode
					case EnumAppMode.FullVersion_201:
						btnOptimiseAllTurret.Visible = false;
						btnOptimiseTurret.Visible = false;
					default:
						btnOptimiseAllTurret.Visible = true;
						btnOptimiseTurret.Visible = true;
				}
				cmbElementName.Enabled = true;
				txtTurretNum.Enabled = true;
				//Added by Saurabh---24.06.07

				//gobjService.ShowProgressBar(ConstFormLoad)

				subSetTextValidation();
				//'this set some validation of each textbox on the screen
				//'here you can find all the validation limits

				funcLoadLamps();
				//'this function is called for load all the lamp.

				if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
					//'there is two method mode either open new or edit.

					if (!IsNothing(gobjNewMethod)) {
						//'if gobjNewMethod is not null then
						if (gobjNewMethod.InstrumentCondition.ElementID == 0) {
							gobjNewMethod.InstrumentCondition = new clsInstrumentParameters();
							//cmbElementName.Enabled = True
							if (cmbElementName.Items.Count > 0) {
								if (cmbElementName.SelectedIndex == 0) {
									cmbElementName_SelectedIndexChanged(sender, e);
								//'parfrom event for combobox changed
								} else {
									cmbElementName.SelectedIndex = 0;
								}
							}
						} else {
							//cmbElementName.Enabled = False
							//txtTurretNum.ReadOnly = True
							if (cmbElementName.SelectedValue == gobjNewMethod.InstrumentCondition.ElementID) {
								cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty);
							//'call combo box event
							} else {
								cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID;
							}
						}
					}

				} else {
					//cmbElementName.Enabled = False
					//txtTurretNum.ReadOnly = True
					if (!IsNothing(gobjNewMethod)) {
						if (cmbElementName.SelectedValue == gobjNewMethod.InstrumentCondition.ElementID) {
							cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty);
						} else {
							cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID;
						}
					} else {
						cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty);
					}
				}

				mintWarmUp_Lamp = Get_Warmup_Lamp_Pos();
				//'this will return gobjInst.Lamp_Warm 
				//'which lamp has to be warmup
				mblnWarmupLamp = false;

			} else {
				//---load gobjinst elements should load
				//---if new method then on load of this form it should show first element
				//---if new method and if elementID is already set then load the selected elementID data
				//---if edit mode then on form load load selected instrument settings

				gobjMain.ShowProgressBar(gstrTitleInstrumentType + ConstFormLoad);
				//'shows some instrument info on progress bar

				//---Added by Mangesh on 10-Apr-2007 for AAS202 Changes


				switch (gstructSettings.AppMode) {
					//'case depanding on appmode
					case EnumAppMode.FullVersion_201:
						btnOptimiseAllTurret.Visible = false;
						btnOptimiseTurret.Visible = false;
					default:
						btnOptimiseAllTurret.Visible = true;
						btnOptimiseTurret.Visible = true;
				}


				if (!IsNothing(gobjNewMethod)) {
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA) {
						//'set the title as par operation mode
						Office2003Header1.TitleText = "Quantitative Instrument Conditions - AA Mode";
					} else {
						if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
							if ((gobjCommProtocol.SRLamp)) {
								//SetWindowText(hwnd,"Quantitative Instrument Conditions-AA BGC (SR Lamp) MODE");
								Office2003Header1.TitleText = "Quantitative Instrument Conditions-AA BGC (SR Lamp) MODE";
							} else {
								//SetWindowText(hwnd,"Quantitative Instrument Conditions-AA BGC (D2 Lamp) MODE");
								Office2003Header1.TitleText = "Quantitative Instrument Conditions-AA BGC (D2 Lamp) MODE";
							}
						} else {
							Office2003Header1.TitleText = "Quantitative Instrument Conditions - AA BGC Mode";
						}
					}
				}

				//---number validator settings here
				subSetTextValidation();
				//'for setting text validation
				funcLoadLamps();
				//'for loading all lamp
				if (OpenMethodMode == modGlobalConstants.EnumMethodMode.NewMode) {
					//'if we creating a new method then
					if (!IsNothing(gobjNewMethod)) {
						if (gobjNewMethod.InstrumentCondition.ElementID == 0) {
							gobjNewMethod.InstrumentCondition = new clsInstrumentParameters();
							cmbElementName.Enabled = true;
							if (cmbElementName.Items.Count > 0) {
								if (cmbElementName.SelectedIndex == 0) {
									cmbElementName_SelectedIndexChanged(sender, e);
								} else {
									cmbElementName.SelectedIndex = 0;
								}
							}
						} else {
							cmbElementName.Enabled = false;
							txtTurretNum.ReadOnly = true;
							if (cmbElementName.SelectedValue == gobjNewMethod.InstrumentCondition.ElementID) {
								cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty);
							} else {
								cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID;
							}
						}
					}

				} else {
					cmbElementName.Enabled = false;
					txtTurretNum.Enabled = false;
					//Saurabh ReadOnly to Enabled
					if (!IsNothing(gobjNewMethod)) {
						if (cmbElementName.SelectedValue == gobjNewMethod.InstrumentCondition.ElementID) {
							cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty);
						} else {
							cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID;
						}
					} else {
						cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty);
					}
				}
				if ((gstructSettings.AppMode == EnumAppMode.FullVersion_201)) {
					lblTurretNum.Text = "Lamp No.";
				}
				mintWarmUp_Lamp = Get_Warmup_Lamp_Pos();
				//'this will Return gobjInst.Lamp_Warm
				mblnWarmupLamp = false;

			}

			//Saurabh
			AddHandlers();
			//'add all the handler to control
			Check_OK_Button();
			//'this will call OK button click event 
			if (cmbElementName.Text == "") {
				cmbElementName.Enabled = true;
				//    btnOk.Enabled = False
			}
			btnReplaceLamp.Focus();
			//Saurabh
			//Saurabh 10.07.07 To bring status form in front
			if (!IsInIQOQPQ) {
				gobjfrmStatus.Show();
			}
			//Saurabh

			//added by deepak on 24.07.07
			string strWvRange;
			strWvRange = gstructSettings.WavelengthRange.WvLowerBound + ".." + gstructSettings.WavelengthRange.WvUpperBound + "nm";
			Label3.Text = strWvRange;

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
			//gobjMain.HideProgressBar()     'Sauarbh
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region " Private Functions"

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To add the event handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : praveen
		//=====================================================================
		try {
			btnCancel.Click += btnCancel_Click;
			//'for eg this will add a event of cancel button
			//'means if we click on cancel button then btnCancel_Click will called

			btnReplaceLamp.Click += btnReplaceLamp_Click;
			btnWarmupLamp.Click += btnWarmupLamp_Click;
			btnOk.Click += btnOk_Click;
			txtTurretNum.ValidationStatus += txtTurretNum_ValidationStatus;
			txtLampCurrent.ValidationStatus += txtCurrent_ValidationStatus;
			txtSlitWidth.ValidationStatus += txtSlitWidth_ValidationStatus;
			btnOptimiseTurret.Click += btnOptimiseTurret_Click;
			btnOptimiseAllTurret.Click += btnOptimiseAllTurret_Click;
			txtTurretNum.TextChanged += txtTurretNum_TextChanged;
			cmbWV.SelectedIndexChanged += cmbWV_SelectedIndexChanged;

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

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To close the form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : praveen
		//=====================================================================

		//note:
		//'this is called when user close the form.
		try {
			gobjchkActiveMethod.CancelMethod = true;
			//gobjchkActiveMethod.fillInstruments = False
			//Me.Close()
			funcOK(false);
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

	private void btnReplaceLamp_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnReplaceLamp_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To replace the lamp
		// Description           : this is call when user click on replace lamp button
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//'below are the variable declaration
		//'note:
		//'this is call when user click on replace lamp button
		//'this is used To replace the lamp


		CWaitCursor objWait = new CWaitCursor();
		int intObjCount;
		DataTable objDtElements;
		//'onject ot data structure where we have to tempe store data.
		DataRow objRow;
		DataView objDv;
		double dblCurrent;
		int intLastTurretPositionInLampPlacement;
		int intCount;
		int Tmp_LampPos = 0;
		double Tmp_LampCurr = 0.0;
		try {
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				//'case true for service utility
				gobjMain.mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				//10.12.07
				Application.DoEvents();
			}

			if ((gstructSettings.Enable21CFR == true)) {
				//'this is for 21 cfr 
				if (!funcCheckActivityAuthentication(enumActivityAuthentication.Lamp_Placements, gstructUserDetails.Access)) {
					//'this will check whatever current user has a permision to replace a lamp or Not.
					return;
				}
				gfuncInsertActivityLog(EnumModules.Lamp_Placements, "Lamp Placement Accessed");
			}

			objDtElements = new DataTable(Const_TableElement);

			if (!Trim(txtTurretNum.Text) == "") {
				mintTurretNumber = (int)txtTurretNum.Text;
			}

			if (!Trim(txtLampCurrent.Text) == "" & !Trim(txtTurretNum.Text) == "") {
				gobjCommProtocol.funcSet_Lamp(false, (double)txtLampCurrent.Text, (int)txtTurretNum.Text);
				//Description            :   To set current to the lamp
				//Parameters             :   flag = if true set current else not set current
				//                           dblLampCurrent = current to be set to lamp
				//                           intLampPos = lamp position to which current to be set
				//
				//'this is a communication function for setting a given lamp at given position 
				//Else
				//Call gobjCommProtocol.funcSet_Lamp(False, 0, 0)
			}

			switch (gstructSettings.AppMode) {
				case EnumAppMode.FullVersion_201:
					//'this is a case for 201
					mobjfrmLampPlacements201 = new frmLampPlacements_201(mintTurretNumber, OpenMethodMode);


					if (mobjfrmLampPlacements201.ShowDialog() == DialogResult.OK) {
						//btnOk.Enabled = True
						Application.DoEvents();

						if (!IsNothing(mobjfrmLampPlacements201.mobjInstrumentParameters)) {
							intLastTurretPositionInLampPlacement = mobjfrmLampPlacements201.mobjInstrumentParameters.TurretNumber;
							dblCurrent = mobjfrmLampPlacements201.mobjInstrumentParameters.LampCurrent;

							if (gobjCommProtocol.funcSet_Lamp(true, dblCurrent, intLastTurretPositionInLampPlacement)) {
								//Description            :   To set current to the lamp
								//Parameters             :   flag = if true set current else not set current
								//                           dblLampCurrent = current to be set to lamp
								//                           intLampPos = lamp position to which current to be set
								//
								gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastTurretPositionInLampPlacement);
								//Description            :   To optimise Turret position 
								//Parameters             :   dblLampCurrent = current to be set to lamp
								//                           intLampPos = lamp position to which current to be set

								Application.DoEvents();
								//'allow application to perfrom its panding task


								//---Added By Mangesh on 10-Apr-2007 for 202 Changes

								//if(MessageBox(hwnd,"Do You Want Manual Lamp Optimisation","Lamp Optimisation",MB_YESNO)==IDYES)
								//		  AbsorbanceScan(hwnd);
								if (gobjMessageAdapter.ShowMessage(constManualLampOptimisation)) {
									Application.DoEvents();
									gobjClsAAS203.AbsorbanceScan();
									// Purpose               : To show the window for Manual Optimization
									//                         i.e. Continuous TimeScan Mode
								}
								Application.DoEvents();

							}

						}
					} else {
						checkLampPosition();
						//Added By Pakaj on 27 05 07
						//'checking for lamp position.
						return;

					}
				default:
					mobjfrmLampPlacements203 = new frmLampPlacements(mintTurretNumber, OpenMethodMode);
					//'this is a case for 203 
					Tmp_LampPos = gobjInst.Lamp_Position;
					Tmp_LampCurr = gobjInst.Current;

					if (mobjfrmLampPlacements203.ShowDialog() == DialogResult.OK) {
						//btnOk.Enabled = True        'Saurabh
						Application.DoEvents();
						//'this means, now software will do its
						if (!IsNothing(mobjfrmLampPlacements203.mobjInstrumentParameters)) {
							intLastTurretPositionInLampPlacement = mobjfrmLampPlacements203.mobjInstrumentParameters.TurretNumber;
							dblCurrent = mobjfrmLampPlacements203.mobjInstrumentParameters.LampCurrent;
							if (gobjCommProtocol.funcSet_Lamp(true, dblCurrent, intLastTurretPositionInLampPlacement)) {
								gobjCommProtocol.funcOptimise_Turret_Position(dblCurrent, intLastTurretPositionInLampPlacement);
								//'To optimise Turret position
							}

						}
					} else {
						//checkLampPosition() 'Added By Pakaj on 27 05 07
						////----- Added by Sachin Dokhale
						//gobjInst.Lamp.LampParametersCollection.item(0).LampOptimizePosition()
						if (gobjCommProtocol.funcSet_Lamp(true, Tmp_LampCurr, Tmp_LampPos)) {
							//'To set current to the lamp
							//Parameters             :   flag = if true set current else not set current
							//                           dblLampCurrent = current to be set to lamp
							//                           intLampPos = lamp position to which current to be set
						}
						return;
						////-----
					}
			}

			funcLoadLamps();
			//'Returns               : returns total number of lamps connected
			// 'Purpose               : To load all lamps 

			//-----Saruabh---24.06.07
			if (!IsNothing(gobjNewMethod)) {
				calElement();

			}
			//-----Saruabh---24.06.07

			cmbElementName_SelectedIndexChanged(sender, e);
		//'this is call if we change the element name
		//checkLampPosition() 'Added By Pakaj on 27 05 07

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
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					gobjMain.mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			Check_OK_Button();
			//'this is called when we click on ok button
			//---------------------------------------------------------
		}
	}


	private void checkLampPosition()
	{
		//'not in used .

		//Dim blLamp As Boolean = False
		//Dim intLampPosition As Integer
		//For intLampPosition = 0 To 6
		//    If (gobjInst.Lamp.LampParametersCollection.item(intLampPosition).ElementName = cmbElementName.Text) Then
		//        blLamp = True
		//        Exit For
		//    End If
		//Next
		//If (blLamp = True) Then
		//    If intLampPosition + 1 <> CInt(txtTurretNum.Text) Then
		//        txtTurretNum.Text = intLampPosition + 1
		//    End If
		//Else
		//    cmbElementName.Enabled = True
		//End If
	}

	private void btnWarmupLamp_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnWarmupLamp_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To select and set the WarmUp lamp.
		// Description           : Change the Button Caption and GroupBox 
		//                         captions according to mblnWarmupLamp
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : ??
		// Revisions             : 2
		// Revisions By          : Mangesh Shardul
		//=====================================================================
		int intElementID;
		double dblCurrent;
		int intTurret;
		CWaitCursor objWait = new CWaitCursor();

		try {
			//Added by Saurabh-To stop the Thread---
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				gobjMain.mobjController.Cancel();
				//'stopthe thread if any running
				gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				//10.12.07
				Application.DoEvents();
			}
			//--------------------------------------
			//'get a current value from the screen
			intElementID = (int)cmbElementName.SelectedValue;
			intTurret = (int)txtTurretNum.Text;
			dblCurrent = (double)txtLampCurrent.Text;

			//---Changed and Added By Mangesh 
			mblnWarmupLamp = !mblnWarmupLamp;
			btnOk.Enabled = !mblnWarmupLamp;
			//Added by Pankaj on 26 Aug 07

			if (mblnWarmupLamp) {
				//'do some onscreen validation for warmup
				//'like text change
				gbMeasurementCond.Text = "Warm up Conditions";
				btnWarmupLamp.Text = "Measurement Lamp";
				cmbElementName.Enabled = true;

				mintTurretNumber = (int)txtTurretNum.Text;
				//'get a turret num invarible
				//---Set Previously selected lamp as Measurement Lamp Number
				if ((mintTurretNumber >= 1 & mintTurretNumber <= gobjClsAAS203.funcGetMaxLamp())) {
					//'check for avaliable turrt with lamp
					//---Changed and Added by Mangesh S.
					//---For DisAllowing user to select same Lamp Element Lamp as 
					//---both Measurement Lamp and Warm Lamp.
					if (mintTurretNumber == mintWarmUp_Lamp) {
						gobjMessageAdapter.ShowMessage(constLampInUse);
						Application.DoEvents();
						mintTurretNumber = -1;
						return;
					} else {
						gobjInst.Lamp_Position = mintTurretNumber;
						//---Glow selected element Measurement lamp
						gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, mintTurretNumber);
						//'for setting lamp parameter as par parameter passed
						if (!mintWarmUp_Lamp == -1)
							txtTurretNum.Text = mintWarmUp_Lamp;
					}
					//---Changed and Added by Mangesh S.
				}

			} else {
				gbMeasurementCond.Text = "Measurement Conditions";
				btnWarmupLamp.Text = "Warm up Lamp";
				cmbElementName.Enabled = false;
				//07.12.07

				mintWarmUp_Lamp = (int)txtTurretNum.Text;
				//'get a turrert num.

				//---Set Previously selected lamp as WarmUp Lamp Number
				if ((mintWarmUp_Lamp >= 1 & mintWarmUp_Lamp <= gobjClsAAS203.funcGetMaxLamp())) {
					//---Changed and Added by Mangesh S.
					//---For DisAllowing user to select same Lamp Element Lamp as 
					//---both Measurement Lamp and Warm Lamp.
					if (mintTurretNumber == mintWarmUp_Lamp) {
						gobjMessageAdapter.ShowMessage(constLampAlreadyInUse);

						Application.DoEvents();
						mintWarmUp_Lamp = -1;
						return;
					} else {
						gobjInst.Lamp_Warm = mintWarmUp_Lamp;
						//---Glow selected element WarmUp lamp
						gobjCommProtocol.funcSet_HCL_Cur(dblCurrent, mintWarmUp_Lamp);
						if (!mintTurretNumber == -1)
							txtTurretNum.Text = mintTurretNumber;
					}
					//---Changed and Added by Mangesh S.
				}

				if ((mblnIsValid)) {
					//'disable a control.
					cmbElementName.Enabled = false;
					txtTurretNum.Enabled = false;
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
			//Added by Saurabh-To start the Thread---
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					gobjMain.mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//---------------------------------------
			Check_OK_Button();
			//---------------------------------------------------------
		}
	}

	private void cmbElementName_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbElementName_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To display the element information according the selected element
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		int intObjCount;
		int intElementID;

		//'Note:-
		//'this is called when user changed the element name 
		//'depanding on element name get a data from database 
		//'like lamp current ect...
		//'and display it on screen




		try {
			intElementID = cmbElementName.SelectedValue();

			//---Changed and Added by Mangesh S.
			//---For DisAllowing user to select same Lamp Element Lamp as 
			//---both Measurement Lamp and Warm Lamp.
			if (mblnWarmupLamp) {
				if (mintTurretNumber == mintWarmUp_Lamp) {
					gobjMessageAdapter.ShowMessage(constLampAlreadyInUse);
					//'prompt a message that lamp is already in use
					Application.DoEvents();
					//'allow application to perfrom its panding work.
					return;
				}
			}
			//---Changed and Added by Mangesh S.
			txtTurretNum.TextChanged -= txtTurretNum_TextChanged;
			//'remove a event 
			if (!intElementID == 0) {
				if (!IsNothing(gobjNewMethod)) {
					if (gobjNewMethod.InstrumentCondition.ElementID == 0) {
						for (intObjCount = 0; intObjCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intObjCount++) {
							int intSearchEleId;
							intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber);
							if (intSearchEleId == intElementID) {
								if (funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) == true) {
									break; // TODO: might not be correct. Was : Exit For
								}
							}
						}
					} else {
						//gobjNewMethod.InstrumentCondition.ElementID = intElementID
						//Call funcLoadMethodElement(gobjNewMethod.InstrumentCondition.ElementID)
						funcLoadMethodElement(intElementID);
						//'for loading a method element as per elementID
					}
				} else {
					for (intObjCount = 0; intObjCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intObjCount++) {
						int intSearchEleId;
						intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber);
						if (intSearchEleId == intElementID) {
							if (funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) == true) {
								//for showing a element info.
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
				}

			} else {
				cmbWV.SelectedIndexChanged -= cmbWV_SelectedIndexChanged;
				txtTurretNum.Text = "";
				txtLampCurrent.Text = "";
				cmbWV.DataSource = null;
				cmbWV.Text = "";
				txtSlitWidth.Text = "";
				txtTurretNum.TextChanged += txtTurretNum_TextChanged;
				//AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged
			}

			cmbWV.SelectedIndexChanged += cmbWV_SelectedIndexChanged;
		//AddHandler txtTurretNum.TextChanged, AddressOf txtTurretNum_TextChanged

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
			Check_OK_Button();
			//---------------------------------------------------------
		}
	}

	//Private Function funcShowElementInfo(ByVal objElement As clsInstrumentParameters) As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : funcShowElementInfo
	//    ' Parameters Passed     : Object of clsInstrumentParameters
	//    ' Returns               : True or False
	//    ' Purpose               : To display the element information 
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Deepak Bhati
	//    ' Created               : 07.10.06
	//    ' Revisions             : 
	//    '=====================================================================
	//    Dim intCount As Integer
	//    Dim objDtWavelength As DataTable
	//    Dim intSensitiveWvId As Integer

	//    Try
	//        If Not IsNothing(objElement) Then
	//            txtLampCurrent.Text = FormatNumber(objElement.LampCurrent, 1)
	//            txtSlitWidth.Text = FormatNumber(objElement.SlitWidth, 1)
	//            txtTurretNum.Text = objElement.TurretNumber

	//            RemoveHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged

	//            objDtWavelength = objElement.Wavelength.Copy()

	//            cmbWV.DataSource = objDtWavelength
	//            cmbWV.DisplayMember = objElement.Wavelength.Columns(ConstColumnWV).ColumnName
	//            cmbWV.ValueMember = objElement.Wavelength.Columns(ConstColumnAADetailsID).ColumnName
	//            cmbWV.Refresh()

	//            If cmbWV.Items.Count > 0 Then
	//                If Not objElement.SelectedWavelengthID = 0 Then
	//                    SelectedWavelengthID = objElement.SelectedWavelengthID
	//                    txtSlitWidth.Text = objElement.SlitWidth
	//                    cmbWV.SelectedValue = SelectedWavelengthID
	//                Else
	//                    intSensitiveWvId = gobjClsAAS203.funcGetSensitiveWavelengthID(objDtWavelength)
	//                    If intSensitiveWvId <> 0 Then
	//                        cmbWV.SelectedValue = intSensitiveWvId
	//                        SelectedWavelengthID = intSensitiveWvId
	//                        txtSlitWidth.Text = objElement.SlitWidth
	//                    End If
	//                End If
	//            End If

	//            AddHandler cmbWV.SelectedIndexChanged, AddressOf cmbWV_SelectedIndexChanged

	//        End If

	//        Return True

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return False
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try
	//End Function

	private bool funcShowElementInfo(AAS203Library.Instrument.ClsLampParameters objElement, int intTurretNumber)
	{
		//=====================================================================
		// Procedure Name        : funcShowElementInfo
		// Parameters Passed     : Object of Instrument.ClsLampParameters
		// Returns               : True or False
		// Purpose               : To display the element information 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : 28-Mar-2007
		// Revisions             : 1
		//=====================================================================
		//'note:
		//'this is used to show some element info on screen
		//'here we get a data from database

		int intCount;
		DataTable objDtWavelength;
		int intSensitiveWvId;
		int intElementID;


		try {
			if (!IsNothing(objElement)) {
				intElementID = gobjDataAccess.GetCookBookElementID(objElement.AtomicNumber);
				//'get a element id from database as par atomic num
				txtLampCurrent.Text = FormatNumber(objElement.Current, 1);
				txtSlitWidth.Text = FormatNumber(objElement.SlitWidth, 1);
				//'show some info on screen
				txtTurretNum.TextChanged -= txtTurretNum_TextChanged;
				txtTurretNum.Text = intTurretNumber;
				txtTurretNum.TextChanged += txtTurretNum_TextChanged;

				cmbWV.SelectedIndexChanged -= cmbWV_SelectedIndexChanged;

				objDtWavelength = gobjDataAccess.GetElementWavelengths(intElementID);

				if (!IsNothing(objDtWavelength)) {
					//'bind the control from data structure
					cmbWV.DataSource = objDtWavelength;
					cmbWV.DisplayMember = ConstColumnWV;
					cmbWV.ValueMember = ConstColumnAADetailsID;
				} else {
					cmbWV.DataSource = null;
				}
				cmbWV.Refresh();

				if (cmbWV.Items.Count > 0) {
					if (OpenMethodMode == modGlobalConstants.EnumMethodMode.EditMode) {
					//SelectedWavelengthID = gobjNewMethod.InstrumentCondition.SelectedWavelengthID
					//txtSlitWidth.Text = objElement.SlitWidth
					//cmbWV.SelectedValue = SelectedWavelengthID
					} else {
						intSensitiveWvId = gobjClsAAS203.funcGetSensitiveWavelengthID(objDtWavelength);
						//'objDtWavelength is a object to wavelength data structure
						if (intSensitiveWvId != 0) {
							cmbWV.SelectedValue = intSensitiveWvId;
							SelectedWavelengthID = intSensitiveWvId;
							txtSlitWidth.Text = objElement.SlitWidth;
						}
					}
				}
				cmbWV.SelectedIndexChanged += cmbWV_SelectedIndexChanged;
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

	private void btnOk_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOk_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the instrument information to the object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================

		//'Note:
		//'this is called when user click on ok button
		//'this is set all onscreen info to a data structure

		//i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_CBWV), CB_GETCURSEL, 0, 0L);
		//SendMessage(GetDlgItem(hwnd, IDC_CBWV), CB_GETLBTEXT, i, (DWORD) (LPSTR) str);
		//val = atof(str);

		//if (Inst->Lamp_par.lamp[LampNo].wv != val)
		//   Inst->Lamp_par.lamp[LampNo].wv=val;

		//if (Inst->Lamp_par.lamp[LampNo].wv <190 || Inst->Lamp_par.lamp[LampNo].wv>900)
		//{
		//   Gerror_message_new(" Wavelength entry error", "ENTRY");
		//	break;
		//}

		//If (AAflag) Then
		//   Inst->Lamp_par.lamp[LampNo].mode=AA;
		//Else
		//   Inst->Lamp_par.lamp[LampNo].mode=AABGC;

		//if (warmup)
		//{
		//   if( GetInstrument() == AA202 )
		//	    warm_lamp = GetDlgItemInt(hwnd, IDC_TUR1, NULL,FALSE)-1;
		//   Else
		//	    warm_lamp = GetDlgItemInt(hwnd, IDC_TUR, NULL,FALSE)-1;

		//	//LampNo;
		//	Set_Warmup_Lamp(warm_lamp);
		//	SendMessage(hwnd, WM_COMMAND, IDC_WORKCONDN, 0L);
		//}

		//GetDlgItemText(hwnd, IDC_CUR1, str, 4);
		//val =(double) atof(str);

		//if (LampNo>=0 && LampNo<=5 && val>0 && val<25)
		//   Inst->Lamp_par.lamp[LampNo].cur=val;

		//GetDlgItemText(hwnd, IDC_SW, str, 4);
		//val = atof(str);

		//if (LampNo>=0 && LampNo<=5 && val>=0 && val<=2.0)
		//   Inst->Lamp_par.lamp[LampNo].slitwidth=val;

		//#If !IN203DLL Then
		//	for(i=0;i<GetMaxLamp(); i++) //6
		//	    Set_Lamp_Parameters(&(Inst->Lamp_par.lamp[i]), i);
		//#End If

		//Save_Tuttet_Status();
		//EndDialog(hwnd, 1);

		//break;

		//=====================================================================
		///Dim objWait As New CWaitCursor
		///Dim intCount As Integer
		///Dim intElementID As Integer
		///Dim intLampNo As Integer
		///Dim dblWV As Double
		///Dim objDtWv As New DataTable
		///Dim dblCurrent As Double
		///Dim dblSlitWidth As Double

		///Try
		///    '---added by deepak on 03.09.07
		///    Dim intCounter As Integer
		///    For intCounter = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
		///        ''LampParametersCollection obj to collection
		///        If (intCounter + 1) = gobjInst.Lamp_Position Then
		///            gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection.item(intCounter).ElementName
		///            Exit For
		///        End If
		///    Next
		///    '------------

		///    intElementID = cmbElementName.SelectedValue

		///    If txtTurretNum.Text = "" Or txtLampCurrent.Text = "" Or txtSlitWidth.Text = "" Then
		///        ''check all the value should be enterd
		///        gobjMessageAdapter.ShowMessage(constFieldsRequired)
		///        Exit Sub    'Saurabh
		///        Application.DoEvents()
		///    End If

		///    If Not txtTurretNum.Text < 7 And txtTurretNum.Text > 0 Then
		///        ''set a range for turrt no (1-6)
		///        gobjMessageAdapter.ShowMessage(constEnterTurretNo)
		///        Exit Sub    'Saurabh
		///        Application.DoEvents()
		///    End If

		///    '******************************************************************
		///    '----Added by Mangesh on 29-Mar-2007 for updating the gobjInst
		///    '--- with new Instrument Settings
		///    '******************************************************************
		///    intLampNo = CInt(txtTurretNum.Text)
		///    dblWV = Val(cmbWV.Text)
		///    dblCurrent = Val(txtLampCurrent.Text)
		///    dblSlitWidth = Val(txtSlitWidth.Text)

		///    ''getting some value from screen to temp variables

		///    '---Sets changed Wavelength
		///    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength <> dblWV) Then
		///        gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength = dblWV
		///    End If

		///    'condition added by deepak on 24.07.07
		///    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < gstructSettings.WavelengthRange.WvLowerBound Or gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > gstructSettings.WavelengthRange.WvUpperBound) Then
		///        ''set a wavelength range
		///        gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
		///        Application.DoEvents()
		///        ''allow application to perfrom its panding work
		///        Exit Sub
		///    End If

		///    'If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < 190 Or gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > 900) Then
		///    '    gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
		///    '    Application.DoEvents()
		///    '    Exit Sub
		///    'End If

		///    '---Sets changed Lamp Current
		///    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current <> dblCurrent) Then
		///        gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current = dblCurrent
		///    End If

		///    '---Sets changed Slit Width
		///    If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth <> dblSlitWidth) Then
		///        gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth = dblSlitWidth
		///    End If

		///    objDtWv = gobjClsAAS203.funcGetElementWavelengths(intElementID)

		///    If Not IsNothing(gobjNewMethod) Then
		///        If Not IsNothing(gobjNewMethod.InstrumentCondition) Then
		///            gobjNewMethod.InstrumentCondition.ElementID = intElementID
		///            gobjNewMethod.InstrumentCondition.LampCurrent = CDbl(Trim(txtLampCurrent.Text))
		///            gobjNewMethod.InstrumentCondition.SelectedWavelengthID = cmbWV.SelectedValue
		///            gobjNewMethod.InstrumentCondition.SlitWidth = CDbl(Trim(txtSlitWidth.Text))
		///            gobjNewMethod.InstrumentCondition.LampNumber = intLampNo
		///            gobjNewMethod.InstrumentCondition.TurretNumber = intLampNo
		///            ''get all current parameter in to gobjNewMethod object

		///            If Not objDtWv Is Nothing Then
		///                gobjNewMethod.InstrumentCondition.Wavelength = objDtWv
		///            End If
		///        End If
		///        For intCount = 0 To gobjMethodCollection.Count - 1
		///            ''store method info in data structure

		///            If gobjMethodCollection.item(intCount).MethodID = gobjNewMethod.MethodID Then
		///                gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone()
		///                gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now
		///                gobjNewMethod.DateOfModification = DateTime.Now
		///            End If
		///        Next
		///        If gobjNewMethod.OperationMode = EnumOperationMode.MODE_AA Or gobjNewMethod.OperationMode = EnumOperationMode.MODE_AABGC Then
		///            gobjNewMethod.InstrumentCondition.IsOptimize = False
		///        End If
		///        'Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
		///        'Added By Pankaj on 23 May 07 for adding method of inactive mode
		///        'gobjchkActiveMethod.fillInstruments = True '27.07.07
		///        'If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
		///        If (gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
		///            gobjchkActiveMethod.NewMethod = False
		///            gobjchkActiveMethod.CancelMethod = False
		///            'gobjchkActiveMethod.fillInstruments = False  '27.07.07
		///            'gobjchkActiveMethod.fillParameters = False   '27.07.07
		///            gobjchkActiveMethod.fillStdConcentration = False
		///            gobjNewMethod.Status = True
		///            gobjMethodCollection.Add(gobjNewMethod)
		///        End If
		///        Call funcSaveAllMethods(gobjMethodCollection)
		///        ''now save a method with current info to data structure
		///        RaiseEvent MethodInstrumentSettingsChanged()
		///        ''this is a event which called when method setting is being changed 
		///        ''it update a current info in method
		///    End If

		///    'If Else is added by Saurabh
		///    'If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then   'Added by Saurabh
		///    Call funcSaveInstStatus()
		///    ''To serialize the object gobjinst with current instrument status


		///    'Else
		///    If gstructSettings.ExeToRun = EnumApplicationMode.ServiceUtility Then
		///        gintTurretToOptimizeForServiceUtility = CInt(txtTurretNum.Text)
		///    End If

		///    'End If
		///    'Call funcSaveInstStatus()  'Commented and added this function in the above else part by Saurabh

		///    If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
		///        If Not IsNothing(gobjNewMethod) Then    'Checked by Saurabh 25.06.07
		///            ''now show the current status of instrument on a status form
		///            gobjfrmStatus.ElementName = CStr(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("NAME"))
		///            gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber
		///        End If
		///    End If

		///    '---kept for service mode
		///    gblnIsInstrumentConditionsActive = True

		///    Me.DialogResult = DialogResult.OK

		try {
			funcOK(true);
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
			///objWait.Dispose()
			//---------------------------------------------------------
		}
	}

	private void txtTurretNum_TextChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : txtTurretNum_TextChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To display the element information according to the selected turret 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak, Saurabh
		// Created               : 07.10.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user change the turret no
		//'this will also check the validation for given turret no.
		int intCounter;
		bool blnIsTurretFound = false;
		int intLampNumber;
		int intObjCount;
		int intSearchEleId;
		CWaitCursor objWait = new CWaitCursor();

		try {

			if (txtTurretNum.Text.Length > 0) {
				//-----------Added by Saurabh on 23-05-2007
				if (txtTurretNum.Text < 1 | txtTurretNum.Text > 6) {
				//btnOk.Enabled = False
				} else if (cmbWV.Text == "") {
				//btnOk.Enabled = False
				} else {
					//btnOk.Enabled = True
				}
				//-----------Added by Saurabh on 23-05-2007

				//---Changed and Added by Mangesh S. on 22-Jan-2007

				intLampNumber = Val(Trim(txtTurretNum.Text));

				if (mblnWarmupLamp) {
					mintWarmUp_Lamp = intLampNumber;
				} else {
					mintTurretNumber = intLampNumber;
				}
				//---Changed and Added by Mangesh S. on 22-Jan-2007

				//---Validate turret number

				if (intLampNumber < 7 & intLampNumber > 0) {
					switch (gstructSettings.AppMode) {
						case EnumAppMode.FullVersion_201:

							for (intObjCount = 0; intObjCount <= 1; intObjCount++) {
								if (intObjCount + 1 == intLampNumber) {
									if (funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) == true) {
										blnIsTurretFound = true;
										intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber);
										cmbElementName.SelectedValue = intSearchEleId;
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}


							if (blnIsTurretFound == false) {
								cmbElementName.SelectedIndexChanged -= cmbElementName_SelectedIndexChanged;
								cmbElementName.DropDownStyle = ComboBoxStyle.DropDown;
								cmbElementName.Text = "";
								txtLampCurrent.Text = "";
								cmbWV.DropDownStyle = ComboBoxStyle.DropDown;
								cmbWV.Text = "";
								txtSlitWidth.Text = "";
								cmbElementName.SelectedIndexChanged += cmbElementName_SelectedIndexChanged;

							}
						default:

							for (intObjCount = 0; intObjCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intObjCount++) {
								if (intObjCount + 1 == intLampNumber) {
									if (funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) == true) {
										blnIsTurretFound = true;
										intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber);
										cmbElementName.SelectedValue = intSearchEleId;
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}


							if (blnIsTurretFound == false) {
								cmbElementName.SelectedIndexChanged -= cmbElementName_SelectedIndexChanged;
								cmbElementName.DropDownStyle = ComboBoxStyle.DropDown;
								cmbElementName.Text = "";
								txtLampCurrent.Text = "";
								cmbWV.DropDownStyle = ComboBoxStyle.DropDown;
								cmbWV.Text = "";
								txtSlitWidth.Text = "";
								cmbElementName.SelectedIndexChanged += cmbElementName_SelectedIndexChanged;
							}
					}
				} else {
					Application.DoEvents();
					txtTurretNum.Select();
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
			Check_OK_Button();
			objWait.Dispose();
			//---------------------------------------------------------
		}
	}

	private void txtTurretNum_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//=====================================================================
		// Procedure Name        : txtTurretNum_ValidationStatus
		// Parameters Passed     : NumberValidator.Status,String
		// Returns               : None
		// Purpose               : To validate txtTurretnum text box
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 10.10.06
		// Revisions             : 
		//=====================================================================

		//'note
		//'this is used for the turret no validation
		//'turret num should be in range 1 - 6 .
		try {
			if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
				txtTurretNum.Focus();
			//btnOk.Enabled = False
			} else {
				//btnOk.Enabled = True       'Commented by Saurabh
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

	private void txtCurrent_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//=====================================================================
		// Procedure Name        : txtCurrent_ValidationStatus
		// Parameters Passed     : NumberValidator.Status,String
		// Returns               : None
		// Purpose               : To validate txtCurrent text box
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 10.10.06
		// Revisions             : 
		//=====================================================================


		//'note :
		//'this is used to set the validation for current
		//'current should be in range 0 - 25.

		try {

			if (!(txtLampCurrent.Text == "")) {

				if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
					txtLampCurrent.Focus();
				//btnOk.Enabled = False
				} else {
					//btnOk.Enabled = True
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

	private void txtSlitWidth_ValidationStatus(NumberValidator.NumberValidator.Status Status, string Msg)
	{
		//=====================================================================
		// Procedure Name        : txtSlitWidth_ValidationStatus
		// Parameters Passed     : NumberValidator.Status,String
		// Returns               : None
		// Purpose               : To validate txtSlitWidth text box
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 10.10.06
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is used to set slit width validation
		//'it should be in range 0-2. nm
		try {
			if (Status == NumberValidator.NumberValidator.Status.NotValidated) {
				txtSlitWidth.Focus();
			//btnOk.Enabled = False
			} else {
				//btnOk.Enabled = True
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

	private void btnOptimiseTurret_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOptimiseTurret_Click
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : To call Turret optimisation procedure 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 28.11.06
		// Revisions             : 
		//=====================================================================
		int intCounter;
		double dblCurrent;
		//'note:
		//'this is called when user click on optimise button
		//'get a turret no which has to be optimise
		//'start the optimise thread with current turret no
		//'perfrom all the step in thread
		//'and now display a result in optimise form as graph






		CWaitCursor objWait = new CWaitCursor();
		try {
			//========
			//used in inst.c in 16 bit
			//case IDC_OPTTUR:
			//========

			//--reset lamp parameters like tur_opt_pos etc.
			//If Not IsNothing(mobjfrmLampPlacements.mobjInstrumentParameters) Then   'If mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count > 0 Then
			//    'For intCounter = 0 To mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count - 1
			//    If mobjfrmLampPlacements.mobjInstrumentParameters.TurretNumber = mintTurretNumber Then
			//        dblCurrent = mobjfrmLampPlacements.mobjInstrumentParameters.LampCurrent
			//    End If
			//    'Next

			//    Call gfuncLamp_connected(mintTurretNumber)

			//    Dim mobjfrmturretOptimisation As frmTurretOptimisation
			//    mobjfrmturretOptimisation = New frmTurretOptimisation(dblCurrent, mintTurretNumber)
			//    mobjfrmturretOptimisation.StartOptimizeTread()
			//    mobjfrmturretOptimisation.StartPosition = FormStartPosition.CenterScreen
			//    If mobjfrmturretOptimisation.ShowDialog() = DialogResult.OK Then
			//        mobjfrmturretOptimisation.Close()
			//        mobjfrmturretOptimisation.Dispose()
			//    End If
			//End If

			//If Not IsNothing(mobjfrmLampPlacements.mobjInstrumentParameters) Then   'If mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count > 0 Then
			//For intCounter = 0 To mobjfrmLampPlacements.mobjClsInstrumentParaCollection.Count - 1
			//If mobjfrmLampPlacements.mobjInstrumentParameters.TurretNumber = mintTurretNumber Then
			//    dblCurrent = mobjfrmLampPlacements.mobjInstrumentParameters.LampCurrent
			//End If
			//Next
			if (Trim(txtLampCurrent.Text) == "") {
				return;
			}

			//Added by Saurabh-To stop the Thread---
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				gobjMain.mobjController.Cancel();
				//'stop the thread if any running 
				gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				//10.12.07
				Application.DoEvents();
				//'allow application to perfrom its panding task
			}
			//--------------------------------------

			dblCurrent = (double)txtLampCurrent.Text;
			mintTurretNumber = (int)txtTurretNum.Text;
			//'get a lamp current and turret num in a temp variable

			gfuncLamp_connected(mintTurretNumber);
			//'To set lamp parameters property lamp optimise at selected position

			frmTurretOptimisation mobjfrmturretOptimisation;
			//'this is object of turretoptimisation form
			mobjfrmturretOptimisation = new frmTurretOptimisation(dblCurrent, mintTurretNumber);
			mobjfrmturretOptimisation.StartOptimizeTread();
			//'this called for starting a optimized thread
			//'where thread perfrom all step for turret optimisation
			mobjfrmturretOptimisation.StartPosition = FormStartPosition.CenterScreen;
			if (mobjfrmturretOptimisation.ShowDialog() == DialogResult.OK) {
				//'show the turret optimization dialog
				mobjfrmturretOptimisation.Close();
				mobjfrmturretOptimisation.Dispose();
				//Saurabh on 28 MAy 2007
				if (gobjfrmStatus.lblTurretNo.Visible == false) {
					gobjfrmStatus.lblTurretNo.Visible = true;
				}
				if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_EMMISSION) {
					gobjfrmStatus.ElementName = gobjInst.ElementName;
				}
				//Saurabh on 28 MAy 2007
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
			//Added by Saurabh-To start the Thread---
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					gobjMain.mobjController.Start(gobjclsBgFlameStatus);
				}
				Application.DoEvents();
			}
			//---------------------------------------------------------
		}

	}

	private void btnOptimiseAllTurret_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnOptimiseTurret_Click
		// Parameters Passed     : 
		// Returns               : None
		// Purpose               : To call Turret optimisation procedure 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak B.
		// Created               : 16.12.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user click on optimise all turret button
		//'here we have to optimise all turret
		//'perfrom Zeroorder first.
		//'for this start the zero order thread
		//'this will perfrom all the function and display a zero order graph.
		//'then start the optimise thread with current turret num.
		//'perfrom all the step in thread
		//'and now display a result in optimise form as graph

		CWaitCursor objWait = new CWaitCursor();
		try {
			//Added by Saurabh-To stop the Thread---
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				gobjMain.mobjController.Cancel();
				gobjCommProtocol.mobjCommdll.subTime_Delay(500);
				//10.12.07
				Application.DoEvents();
			}
			//--------------------------------------

			//---21.01.08
			if ((int)txtTurretNum.Text >= 1 & (int)txtTurretNum.Text <= 6) {
				if (!gobjInst == null) {
					if (IsNumeric(txtLampCurrent.Text) == true) {
						gobjInst.Lamp.LampParametersCollection((int)txtTurretNum.Text - 1).Current = (double)txtLampCurrent.Text;
					}
				}
			}
			//---21.01.08

			frmZeroOrder mobjfrmZeroOrder;
			//'object to zero order
			mobjfrmZeroOrder = new frmZeroOrder();
			mobjfrmZeroOrder.StartPosition = FormStartPosition.Manual;
			mobjfrmZeroOrder.Location = new Point(ZeroOrderThreadWindowLocationX, ZeroOrderThreadWindowLocationY);
			mobjfrmZeroOrder.StartOptimizeTread();
			//'for starting a thread
			//'this will start zero order thread.
			if (mobjfrmZeroOrder.ShowDialog() == DialogResult.OK) {
				//'show the zero order form
				mobjfrmZeroOrder.Close();
				mobjfrmZeroOrder.Dispose();
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
				//'destructor
			}
			//Added by Saurabh-To start the Thread---
			if (!gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				//10.12.07
				if (gobjMain.mobjController.IsThreadRunning == false) {
					gobjCommProtocol.mobjCommdll.subTime_Delay(gintTimeDelay);
					Application.DoEvents();
					gobjMain.mobjController.Start(gobjclsBgFlameStatus);
				}
				//'restart the thread if it stoped.
				Application.DoEvents();
				//'allow application to perfrom its panding work.
			}
			//---------------------------------------------------------
		}

	}

	private void cmbWV_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbWV_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set SelectedWavelengthID
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 15.12.06
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is called when user change a wavelength 
		try {
			SelectedWavelengthID = cmbWV.SelectedValue;
		//'get a selected Wavelength.
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
			Check_OK_Button();
			//'this will called OK button procedure for updating current wavelength.
			//---------------------------------------------------------
		}
	}

	private void Set_Warmup_Lamp(int intWarmupLampNumber)
	{
		//=====================================================================
		// Procedure Name        : Set_Warmup_Lamp
		// Parameters Passed     : intWarmupLampNumber
		// Returns               : none
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 
		// Revisions             : praveen
		//=====================================================================

		//'note:
		//'this is used to set a warmup lamp to datastructure.
		//'and later this will used in a software. 

		//void	S4FUNC Set_Warmup_Lamp(int pos)
		//{
		//	Inst.Lamp_warm = pos+1;
		//}

		try {
			gobjInst.Lamp_Warm = intWarmupLampNumber;
		//'save current warmup lamp to data structure
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

	private int Get_Warmup_Lamp_Pos()
	{
		//=====================================================================
		// Procedure Name        : Get_Warmup_Lamp_Pos
		// Parameters Passed     : 
		// Returns               : warmup lamp position.
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		//int	S4FUNC Get_Warmup_Lamp_Pos()
		//{
		//	return Inst.Lamp_warm-1;
		//}
		return gobjInst.Lamp_Warm;
		//'for getting current warm up lamp position from data structure

	}

	private bool Validate_AASetup(bool blnIsWarmUp)
	{
		//=====================================================================
		// Procedure Name        : Validate_AASetup
		// Parameters Passed     : blnIsWarmUp
		// Returns               : this is used for validate a setup as per parameter passed.
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 
		// Revisions             : praveen
		//=====================================================================
		////-----------------
		//BOOL	Validate_AASetup(HWND hwnd, BOOL warmup)
		//{
		//double	tempk=0;
		//int	i;
		//BOOL	flag=TRUE;
		//char	str[80]="";
		//  i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_ELNAME),
		//		 CB_GETCURSEL, 0, 0L);
		//  SendMessage(GetDlgItem(hwnd, IDC_ELNAME), CB_GETLBTEXT,
		//		i, (DWORD) (LPSTR) str);
		//  if (strcmpi(ltrim(trim(str)),"")==0)
		//	 flag=FALSE;
		//  if (flag){
		//	  if( GetInstrument() == AA202 )
		//		 i=GetDlgItemInt(hwnd, IDC_TUR1, NULL,FALSE);
		//                Else
		//		 i=GetDlgItemInt(hwnd, IDC_TUR, NULL,FALSE);
		//	  if (warmup){
		//		 if (i<0 || i>GetMaxLamp()) //6
		//			flag=FALSE;
		//		 }
		//	  else{
		//		 if (i<1 || i>GetMaxLamp()) //6
		//		 flag=FALSE;
		//		}
		//	  if (flag) {
		//		 i= (WORD) SendMessage(GetDlgItem(hwnd, IDC_CBWV),
		//				 CB_GETCURSEL, 0, 0L);
		//		 SendMessage(GetDlgItem(hwnd, IDC_CBWV), CB_GETLBTEXT,
		//			i, (DWORD) (LPSTR) str);
		//		 tempk=atof(str);
		//		 if (tempk<190.0 || tempk >900)
		//			flag=FALSE;
		//		 if (flag){
		//			GetDlgItemText(hwnd, IDC_CUR1, str, 4);
		//			tempk=(double) atof(str);
		//			if (tempk<=0 || tempk>25)
		//			  flag=FALSE;
		//			if (flag){ //cur
		//				GetDlgItemText(hwnd, IDC_SW, str, 4);
		//				tempk= atof(str);
		//				if (tempk<=0.0 || tempk >2.0)
		//					flag=FALSE;
		//			  }//cur
		//		  } //wv
		//		}//tur
		//	 }//el
		//  EnableWindow(GetDlgItem(hwnd, SKOK), FALSE);
		//  If (flag) Then
		//	 EnableWindow(GetDlgItem(hwnd, SKOK), TRUE);
		//  return flag;
		//}
		////-----------------------




		//'note:
		//'this function set all the flag true or false as par validation
		//'in above there is C code and Below .Net code


		double tempk = 0;
		int intTurretNumber;
		bool blnIsValid = true;
		string str = "";

		//---Validate for Element Name
		if (Trim(cmbElementName.Text) == "") {
			blnIsValid = false;
		}

		if ((blnIsValid)) {
			intTurretNumber = (int)txtTurretNum.Text;
			//'type caste text value and store it in temp variable

			if ((mblnWarmupLamp)) {
				if ((intTurretNumber < 1 | intTurretNumber > gobjClsAAS203.funcGetMaxLamp()))
					blnIsValid = false;
			} else {
				if ((intTurretNumber < 1 | intTurretNumber > gobjClsAAS203.funcGetMaxLamp()))
					blnIsValid = false;
			}

			if ((blnIsValid)) {
				//---Get Selected Wavelength from DropDown List
				tempk = Val(cmbWV.Text);
				if ((tempk < gstructSettings.WavelengthRange.WvLowerBound | tempk > gstructSettings.WavelengthRange.WvUpperBound)) {
					blnIsValid = false;
				}

				if ((blnIsValid)) {
					tempk = (double)txtLampCurrent.Text;
					if ((tempk <= 0 | tempk > 25)) {
						blnIsValid = false;
					}

					if ((blnIsValid)) {
						tempk = (double)txtSlitWidth.Text;
						if ((tempk <= 0.0 | tempk > 2.0)) {
							blnIsValid = false;
						}
					}
				}
			}
		}

		if ((blnIsValid)) {
		//btnOk.Enabled = True
		} else {
			//btnOk.Enabled = False
		}

		return blnIsValid;

	}

	private void subSetTextValidation()
	{
		//=====================================================================
		// Procedure Name        : subSetTextValidation
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To validate text boxes
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak
		// Created               : 
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used for setting all text validation range

		try {
			//'for eg here is slit width which can be double 
			//'and in range 1.0 - 2.0
			txtSlitWidth.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			txtSlitWidth.DigitsAfterDecimalPoint = 1;
			txtSlitWidth.RangeValidation = true;
			txtSlitWidth.MinimumRange = ConstIntMinSlitWidthLimit;
			//1.0
			txtSlitWidth.MaximumRange = ConstIntMaxSlitWidthLimit;
			//2.0
			txtSlitWidth.ErrorColor = Color.Gainsboro;
			//'set a validation for txtLampCurrent
			txtLampCurrent.ValidationType = NumberValidator.NumberValidator.Validations.DoubleOnly;
			txtLampCurrent.DigitsAfterDecimalPoint = 2;
			txtLampCurrent.RangeValidation = true;
			txtLampCurrent.MinimumRange = ConstIntMinCurrentLimit;
			//0.1
			txtLampCurrent.MaximumRange = ConstIntMaxCurrentLimit;
			//25.99
			txtLampCurrent.ErrorColor = Color.Gainsboro;
			//'set a validation for txtTurrertNum
			txtTurretNum.ValidationType = NumberValidator.NumberValidator.Validations.IntegerOnly;
			txtTurretNum.RangeValidation = true;
			txtTurretNum.MinimumRange = ConstIntMinTurretLimit;
			//1
			txtTurretNum.MaximumRange = ConstIntMaxTurretLimit;
			//6
			txtTurretNum.ErrorColor = Color.Gainsboro;

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
frmInstrumentParameters_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmInstrumentParameters_Closing 
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To the information 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 
		// Revisions             : 
		//=====================================================================
		try {
			//'note:
			//this is called when user closed the form
			if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
				gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType + ConstParentFormLoad);

			} else {
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

	private int funcLoadLamps()
	{
		//=====================================================================
		// Procedure Name        : funcLoadLamps
		// Parameters Passed     : 
		// Returns               : returns total number of lamps connected
		// Purpose               : To load all lamps 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 31.03.07
		// Revisions             : 
		//=====================================================================
		//'note:
		//'this is used to load all the conected lamp
		//'and it info in a data structure.
		DataTable objDtElements = new DataTable();
		int intEleCount = 0;
		int intObjCount;
		DataRow objRow;
		int intElementID;
		int intLampsCount;
		DataView objDvElementsList = new DataView();

		try {
			objDtElements.Columns.Add(ConstColumnElementID, typeof(int));
			objDtElements.Columns.Add(ConstColumnElementName, typeof(string));
			objDtElements.Columns.Add(ConstColumnTurretNumber, typeof(int));

			for (intObjCount = 0; intObjCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intObjCount++) {
				//'make a counter up to a collection.
				if (gobjInst.Lamp.LampParametersCollection.item(intObjCount).ElementName != "") {
					objRow = objDtElements.NewRow();
					if (gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber != 0) {
						intLampsCount = intLampsCount + 1;
					}
					intElementID = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber);
					objRow.Item(ConstColumnElementID) = intElementID;
					objRow.Item(ConstColumnElementName) = gobjInst.Lamp.LampParametersCollection.item(intObjCount).ElementName;
					objRow.Item(ConstColumnTurretNumber) = intObjCount + 1;
					objDtElements.Rows.Add(objRow);
				}
			}

			cmbElementName.SelectedIndexChanged -= cmbElementName_SelectedIndexChanged;
			objDvElementsList = new DataView(objDtElements);
			objDvElementsList.Sort = ConstColumnTurretNumber;

			cmbElementName.DataSource = objDvElementsList;
			cmbElementName.ValueMember = ConstColumnElementID;
			cmbElementName.DisplayMember = ConstColumnElementName;
			cmbElementName.DropDownStyle = ComboBoxStyle.DropDownList;

			cmbElementName.SelectedIndexChanged += cmbElementName_SelectedIndexChanged;

			return intLampsCount;
		//'return a no of lamp count

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

	private int funcLoadMethodElement(int intElementID)
	{
		//=====================================================================
		// Procedure Name        : funcLoadMethodElement
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 03.04.07
		// Revisions             : 
		//=====================================================================
		DataTable objDtWavelength = new DataTable();

		//'note:
		//'this is used to load a methos info
		//'and display that info on form in a proper control



		try {
			if (!IsNothing(gobjNewMethod)) {
				if (intElementID == gobjNewMethod.InstrumentCondition.ElementID) {
					cmbElementName.SelectedIndexChanged -= cmbElementName_SelectedIndexChanged;
					txtTurretNum.TextChanged -= txtTurretNum_TextChanged;
					cmbWV.SelectedIndexChanged -= cmbWV_SelectedIndexChanged;

					//--set method element to combo box.
					cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID;
					//--set method turret number to text box.
					txtTurretNum.Text = gobjNewMethod.InstrumentCondition.TurretNumber;
					//'set a lamp current to lamp text box.
					txtLampCurrent.Text = gobjNewMethod.InstrumentCondition.LampCurrent;
					//'get a wavelength as per eleID
					objDtWavelength = gobjDataAccess.GetElementWavelengths(intElementID);

					if (!IsNothing(objDtWavelength)) {
						cmbWV.DataSource = objDtWavelength;
						cmbWV.DisplayMember = ConstColumnWV;
						cmbWV.ValueMember = ConstColumnAADetailsID;
					}
					//'get a wavwlength.
					cmbWV.SelectedValue = gobjNewMethod.InstrumentCondition.SelectedWavelengthID;
					//'get a slit width.
					txtSlitWidth.Text = gobjNewMethod.InstrumentCondition.SlitWidth;

					cmbWV.SelectedIndexChanged += cmbWV_SelectedIndexChanged;
					//'for adding a handler.
					cmbElementName.SelectedIndexChanged += cmbElementName_SelectedIndexChanged;
					txtTurretNum.TextChanged += txtTurretNum_TextChanged;
				} else {
					//---28.05.07
					int intObjCount;
					for (intObjCount = 0; intObjCount <= gobjInst.Lamp.LampParametersCollection.Count - 1; intObjCount++) {
						int intSearchEleId;
						intSearchEleId = gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(intObjCount).AtomicNumber);
						//'get a elementID
						if (intSearchEleId == intElementID) {
							if (funcShowElementInfo(gobjInst.Lamp.LampParametersCollection.item(intObjCount), intObjCount + 1) == true) {
								//'for showing a element info.
								break; // TODO: might not be correct. Was : Exit For
							}
						}
					}
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
mobjfrmLampPlacements_LampReplaced()
	{
		//=====================================================================
		// Procedure Name        : mobjfrmLampPlacements_LampReplaced
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : this handle a lamp replaced event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 03.04.07
		// Revisions             : 
		//=====================================================================
		try {
			funcLoadLamps();
			//'it gives a info of all conected lamp


			//-----Saruabh---24.06.07
			if (!IsNothing(gobjNewMethod)) {
				//Added By Pankaj 27 May 07
				calElement();
			}
			//-----Saruabh---24.06.07
			cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty);
		//'called elementname changed event.
		//-------
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
mobjfrmLampPlacements_LampRemoved()
	{
		//=====================================================================
		// Procedure Name        : mobjfrmLampPlacements_LampRemoved
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : this handle a lamp removed event.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 03.04.07
		// Revisions             : 
		//=====================================================================
		try {
			funcLoadLamps();
			//'this called for loading all lamp.

			//'------------------------------------
			//Dim intCount As Integer
			//Dim blnExists As Boolean = False
			//For intCount = 0 To gobjInst.Lamp.LampParametersCollection.Count - 1
			//    If gobjClsAAS203.funcGetElementID(gobjInst.Lamp.LampParametersCollection.item(intCount).AtomicNumber) = gobjNewMethod.InstrumentCondition.ElementID Then
			//        blnExists = True
			//        Exit For
			//    End If
			//Next
			//If blnExists = True Then
			//    cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
			//End If
			//'------------------------------------

			//-----Saruabh---24.06.07
			if (!IsNothing(gobjNewMethod)) {
				//Added By Pankaj 27 May 07
				calElement();
				//'this will calculate a no of element.
			}
		//-----Saruabh---24.06.07
		//Call cmbElementName_SelectedIndexChanged(cmbElementName, EventArgs.Empty)

		//-------
		//If cmbElementName.Text = "" Then
		//cmbElementName.Enabled = True
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
			//---------------------------------------------------------
		}
	}

	private void calElement()
	{
		//=====================================================================
		// Procedure Name        : calElement
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : this will calculate a no of element.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 03.04.07
		// Revisions             : 
		//=====================================================================
		//Added By Pankaj 27 May 07
		bool blFlag = false;
		int i;
		//'i for counter
		try {
			for (i = 0; i <= 5; i++) {
				if ((gobjNewMethod.InstrumentCondition.ElementID == gobjDataAccess.GetCookBookElementID(gobjInst.Lamp.LampParametersCollection.item(i).AtomicNumber))) {
					//'check a ElementID frm database.
					blFlag = true;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			//Or cmbElementName.Text = "" Then
			if (blFlag == false) {
				//If (cmbElementName.Items.Contains(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))) Then
				//    'cmbElementName.Text = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(0)
				//    cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID
				//Else
				txtTurretNum.Enabled = true;
				cmbElementName.Enabled = true;
			//End If
			} else {
				//If (cmbElementName.Items.Contains(gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1))) Then
				//cmbElementName.Text = gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item(1)
				if ((i + 1 != gobjNewMethod.InstrumentCondition.TurretNumber)) {
					gobjNewMethod.InstrumentCondition.TurretNumber = i + 1;
				}
				cmbElementName.SelectedValue = gobjNewMethod.InstrumentCondition.ElementID;
				// Else
				//    txtTurretNum.Enabled = True
				//   cmbElementName.Enabled = True
				//End If
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
		//-------
	}

	private void Check_OK_Button()
	{
		//=====================================================================
		// Procedure Name        : Check_OK_Button
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To enable or disable OK button
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================

		//'note:
		//'this is called when user click on OK button
		//'this will check proper validation 
		//'and accept a user defined value to data structure


		try {
			if (txtTurretNum.Text.Length > 0) {
				if (txtTurretNum.Text > 0 & txtTurretNum.Text < 7) {
					//'check for turrert no bet 0 to 7
					if (!cmbElementName.Text == "") {
						if (!cmbWV.Text == "") {
							if (txtLampCurrent.Text.Length > 0) {
								if (txtLampCurrent.Text > 0 & txtLampCurrent.Text <= 25) {
									//'check for lamp current.
									if (txtSlitWidth.Text.Length > 0) {
										if (txtSlitWidth.Text > 0 & txtSlitWidth.Text < 2.1) {
											//'check for slit width.
											btnOk.Enabled = true;
											this.AcceptButton = btnOk;
										} else {
											btnOk.Enabled = false;
											this.AcceptButton = btnCancel;
											//btnCancel.Focus()
										}
									} else {
										btnOk.Enabled = false;
										this.AcceptButton = btnCancel;
										//btnCancel.Focus()
									}
								} else {
									btnOk.Enabled = false;
									this.AcceptButton = btnCancel;
									//btnCancel.Focus()
								}
							} else {
								btnOk.Enabled = false;
								this.AcceptButton = btnCancel;
								//btnCancel.Focus()
							}
						} else {
							btnOk.Enabled = false;
							this.AcceptButton = btnCancel;
							//btnCancel.Focus()
						}
					} else {
						btnOk.Enabled = false;
						this.AcceptButton = btnCancel;
						//btnCancel.Focus()
					}
				} else {
					btnOk.Enabled = false;
					this.AcceptButton = btnCancel;
					//btnCancel.Focus()
				}
			} else {
				btnOk.Enabled = false;
				this.AcceptButton = btnCancel;
				//btnCancel.Focus()
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
txtLampCurrent_TextChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : txtLampCurrent_TextChanged
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handle an event
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================
		Check_OK_Button();
		//'call a event for OK button.
	}

	private void  // ERROR: Handles clauses are not supported in C#
txtSlitWidth_TextChanged(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : Check_OK_Button
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : for handle an event
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 24.06.07
		// Revisions             : 
		//=====================================================================
		Check_OK_Button();
		//'call a event for OK button.
	}

	private object funcOK(bool blnOk)
	{
		CWaitCursor objWait = new CWaitCursor();
		int intCount;
		int intElementID;
		int intLampNo;
		double dblWV;
		DataTable objDtWv = new DataTable();
		double dblCurrent;
		double dblSlitWidth;
		try {
			//---added by deepak on 03.09.07
			int intCounter;
			for (intCounter = 0; intCounter <= gobjInst.Lamp.LampParametersCollection.Count - 1; intCounter++) {
				//'LampParametersCollection obj to collection
				if ((intCounter + 1) == gobjInst.Lamp_Position) {
					gobjfrmStatus.lblElementName.Text = gobjInst.Lamp.LampParametersCollection.item(intCounter).ElementName;
					break; // TODO: might not be correct. Was : Exit For
				}
			}
			//------------

			intElementID = cmbElementName.SelectedValue;

			if (txtTurretNum.Text == "" | txtLampCurrent.Text == "" | txtSlitWidth.Text == "") {
				//'check all the value should be enterd
				gobjMessageAdapter.ShowMessage(constFieldsRequired);
				return;
				//Saurabh
				Application.DoEvents();
			}

			if (!txtTurretNum.Text < 7 & txtTurretNum.Text > 0) {
				//'set a range for turrt no (1-6)
				gobjMessageAdapter.ShowMessage(constEnterTurretNo);
				return;
				//Saurabh
				Application.DoEvents();
			}

			//******************************************************************
			//----Added by Mangesh on 29-Mar-2007 for updating the gobjInst
			//--- with new Instrument Settings
			//******************************************************************
			intLampNo = (int)txtTurretNum.Text;
			dblWV = Val(cmbWV.Text);
			dblCurrent = Val(txtLampCurrent.Text);
			dblSlitWidth = Val(txtSlitWidth.Text);

			//'getting some value from screen to temp variables

			//---Sets changed Wavelength
			if ((gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength != dblWV)) {
				gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength = dblWV;
			}

			//condition added by deepak on 24.07.07
			if ((gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < gstructSettings.WavelengthRange.WvLowerBound | gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > gstructSettings.WavelengthRange.WvUpperBound)) {
				//'set a wavelength range
				gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage);
				Application.DoEvents();
				//'allow application to perfrom its panding work
				return;
			}

			//If (gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength < 190 Or gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Wavelength > 900) Then
			//    gobjMessageAdapter.ShowMessage("Wavelength entry error", "ENTRY", MessageHandler.clsMessageHandler.enumMessageType.ErrorMessage)
			//    Application.DoEvents()
			//    Exit Sub
			//End If

			//---Sets changed Lamp Current
			if ((gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current != dblCurrent)) {
				gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).Current = dblCurrent;
			}

			//---Sets changed Slit Width
			if ((gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth != dblSlitWidth)) {
				gobjInst.Lamp.LampParametersCollection.item(intLampNo - 1).SlitWidth = dblSlitWidth;
			}

			objDtWv = gobjClsAAS203.funcGetElementWavelengths(intElementID);

			if (!IsNothing(gobjNewMethod)) {
				if (!IsNothing(gobjNewMethod.InstrumentCondition)) {
					gobjNewMethod.InstrumentCondition.ElementID = intElementID;
					gobjNewMethod.InstrumentCondition.LampCurrent = (double)Trim(txtLampCurrent.Text);
					gobjNewMethod.InstrumentCondition.SelectedWavelengthID = cmbWV.SelectedValue;
					gobjNewMethod.InstrumentCondition.SlitWidth = (double)Trim(txtSlitWidth.Text);
					gobjNewMethod.InstrumentCondition.LampNumber = intLampNo;
					gobjNewMethod.InstrumentCondition.TurretNumber = intLampNo;
					//'get all current parameter in to gobjNewMethod object

					if (!objDtWv == null) {
						gobjNewMethod.InstrumentCondition.Wavelength = objDtWv;
					}
				}
				for (intCount = 0; intCount <= gobjMethodCollection.Count - 1; intCount++) {
					//'store method info in data structure

					if (gobjMethodCollection.item(intCount).MethodID == gobjNewMethod.MethodID) {
						gobjMethodCollection.item(intCount).InstrumentCondition = gobjNewMethod.InstrumentCondition.Clone();
						gobjMethodCollection.item(intCount).DateOfModification = DateTime.Now;
						gobjNewMethod.DateOfModification = DateTime.Now;
					}
				}

				if (blnOk == true) {
					if (gobjNewMethod.OperationMode == EnumOperationMode.MODE_AA | gobjNewMethod.OperationMode == EnumOperationMode.MODE_AABGC) {
						gobjNewMethod.InstrumentCondition.IsOptimize = false;
					}
				}

				//Call funcSerialize(ConstMethodsFileName, gobjMethodCollection)
				//Added By Pankaj on 23 May 07 for adding method of inactive mode
				//gobjchkActiveMethod.fillInstruments = True '27.07.07
				//If (gobjchkActiveMethod.fillInstruments = True And gobjchkActiveMethod.fillParameters = True And gobjchkActiveMethod.fillStdConcentration = True And gobjchkActiveMethod.CancelMethod = True And gobjchkActiveMethod.NewMethod = True) Then
				if (blnOk == true) {
					if ((gobjchkActiveMethod.fillStdConcentration == true & gobjchkActiveMethod.CancelMethod == true & gobjchkActiveMethod.NewMethod == true)) {
						gobjchkActiveMethod.NewMethod = false;
						gobjchkActiveMethod.CancelMethod = false;
						//gobjchkActiveMethod.fillInstruments = False  '27.07.07
						//gobjchkActiveMethod.fillParameters = False   '27.07.07
						gobjchkActiveMethod.fillStdConcentration = false;
						gobjNewMethod.Status = true;
						gobjMethodCollection.Add(gobjNewMethod);
					}
				}

				funcSaveAllMethods(gobjMethodCollection);
				//'now save a method with current info to data structure
				if (MethodInstrumentSettingsChanged != null) {
					MethodInstrumentSettingsChanged();
				}
				//'this is a event which called when method setting is being changed 
				//'it update a current info in method
			}

			//If Else is added by Saurabh
			//If gstructSettings.ExeToRun = EnumApplicationMode.AAS Then   'Added by Saurabh
			if (gstructSettings.ExeToRun == EnumApplicationMode.AAS) {
				funcSaveInstStatus();
			}
			//'To serialize the object gobjinst with current instrument status


			//Else
			if (gstructSettings.ExeToRun == EnumApplicationMode.ServiceUtility) {
				gintTurretToOptimizeForServiceUtility = (int)txtTurretNum.Text;
			}

			//End If
			//Call funcSaveInstStatus()  'Commented and added this function in the above else part by Saurabh

			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//Checked by Saurabh 25.06.07
				if (!IsNothing(gobjNewMethod)) {
					//'now show the current status of instrument on a status form
					gobjfrmStatus.ElementName = (string)gobjClsAAS203.funcGetElement(gobjNewMethod.InstrumentCondition.ElementID).Rows(0).Item("NAME");
					gobjfrmStatus.TurretNumber = gobjNewMethod.InstrumentCondition.TurretNumber;
					gobjInst.Lamp_Position = gobjNewMethod.InstrumentCondition.TurretNumber;
					//---11.09.09
				}
			}

			//---kept for service mode
			gblnIsInstrumentConditionsActive = true;

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

	#End Region
}

